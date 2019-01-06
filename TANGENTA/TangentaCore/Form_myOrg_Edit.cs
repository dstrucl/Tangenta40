#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion
//Form_myOrg_Edit.Designer.cs:line 145
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LanguageControl;
using CodeTables;
using TangentaTableClass;
using TangentaDB;
using NavigationButtons;
using DBConnectionControl40;
using DBTypes;

namespace TangentaCore
{
    public partial class Form_myOrg_Edit : Form
    {
        private DataTable dt_my_company = new DataTable();
        private CodeTables.DBTableControl dbTables = null;
        private SQLTable tbl = null;
        private NavigationButtons.Navigation nav = null;
        private PostAddress_v myorg_PostAddress_v = null;

        public Form_myOrg_Edit(CodeTables.DBTableControl xdbTables,SQLTable xtbl,bool bAllowNew, NavigationButtons.Navigation xnav, PostAddress_v xmyorg_PostAddress_v)
        {
            InitializeComponent();
            myorg_PostAddress_v = xmyorg_PostAddress_v;
            nav = xnav;
            this.usrc_NavigationButtons1.Init(nav);
            dbTables = xdbTables;
            tbl = xtbl;
            usrc_EditRow.AllowUserToAddNew = bAllowNew;
            lng.s_Edit_Offices.Text(btn_Office);
        }

        private bool InitDataTable(ID xID)
        {
            dt_my_company.Clear();
            string sql = null;
             sql = @"select * from myOrganisation_VIEW";

            string Err = null;
            if (DBSync.DBSync.ReadDataTable(ref dt_my_company,sql,ref Err))
            {
                dgvx_MyOrganisation.DataSource = dt_my_company;
                tbl.SetVIEW_DataGridViewImageColumns_Headers((DataGridView)dgvx_MyOrganisation, dbTables);
                foreach (DataGridViewColumn dgvc in dgvx_MyOrganisation.Columns)
                {
                    if (dgvc.HeaderText.Equals("ID"))
                    {
                        dgvc.Visible = false;
                    }
                }
                return true;
            }
            else
            {
                LogFile.Error.Show(Err);
                return false;
            }
        }

        private bool Init()
        {
            Cursor = Cursors.WaitCursor;
            if (InitDataTable(null))
            {
                usrc_EditRow.Init(dbTables,
                                  DBSync.DBSync.MyTransactionLog_delegates,
                                  tbl, null,false,nav);

                usrc_EditRow.FillInitialData();
                if (dt_my_company.Rows.Count > 0)
                {
                    ID Identity = tf.set_ID(dt_my_company.Rows[0]["ID"]);
                    usrc_EditRow.ShowTableRow(Identity);
                    usrc_EditRow.AllowUserToAddNew = false;
                }
                else
                {
                    usrc_EditRow.AllowUserToAddNew = true;
                }
                Cursor = Cursors.Arrow;
                return true;
            }
            else
            {
                Cursor = Cursors.Arrow;
                return false;
            }

        }

        private void MyOrganisationData_EditForm_Load(object sender, EventArgs e)
        {
            this.btn_BankAccounts.Text = lng.s_BankAccounts.s;
            this.Text = lng.s_MyOrganisation.s;
            if (!Init())
            {
                Close();
                DialogResult = DialogResult.Abort;
            }
        }

        private void usrc_EditTable_Update(bool res,ID xID, string Err)
        {
            if (res)
            {
                InitDataTable(xID);
                usrc_EditRow.ShowTableRow(xID);
            }
        }

        private bool do_OK()
        {
            if (usrc_EditRow.Changed)
            {
                if (XMessage.Box.Show(this, lng.s_YouDidNotWriteDataToDB_SaveData_YesOrNo, lng.s_Warning.s, MessageBoxButtons.YesNo, TangentaResources.Properties.Resources.Tangenta_Question, MessageBoxDefaultButton.Button1)== DialogResult.Yes)
                {
                    Transaction transaction_Form_myOrg_Edit_do_OK_usrc_EditRow_Save = DBSync.DBSync.NewTransaction("Form_myOrg_Edit.do_OK.usrc_EditRow.Save");
                    if (usrc_EditRow.Save(transaction_Form_myOrg_Edit_do_OK_usrc_EditRow_Save))
                    {
                        if (transaction_Form_myOrg_Edit_do_OK_usrc_EditRow_Save.Commit())
                        {
                            Close();
                            DialogResult = DialogResult.OK;
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        transaction_Form_myOrg_Edit_do_OK_usrc_EditRow_Save.Rollback();
                        if (XMessage.Box.Show(this, lng.s_DataNotSavedEndYesNo, "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                        {
                            this.Close();
                            DialogResult = DialogResult.OK;
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    if (nav.m_eButtons == NavigationButtons.Navigation.eButtons.OkCancel)
                    {
                        Close();
                        DialogResult = DialogResult.OK;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            else
            {
                if (dt_my_company.Rows.Count > 0)
                {
                    Close();
                    DialogResult = DialogResult.OK;
                    return true;
                }
                else
                {
                    XMessage.Box.Show(this, lng.s_YouMustEnterYourOrganisationData, "", MessageBoxButtons.OK, TangentaResources.Properties.Resources.Tangenta_Question, MessageBoxDefaultButton.Button1);
                    return false;
                }
            }
        }

        private bool do_Cancel()
        {

            if (dt_my_company.Rows.Count > 0)
            {
                Close();
                DialogResult = DialogResult.OK;
                return true;
            }
            else
            {
                if (XMessage.Box.Show(this, lng.s_YouDidNotEnterYourOrganisationData, "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    Close();
                    DialogResult = DialogResult.Cancel;
                    return true;
                }
            }
            return false;
        }

    
        internal bool Edit_OrganisationAccount(Navigation ynav)
        {
            SQLTable tbl_OrganisationAccount = new SQLTable(DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(OrganisationAccount)));
            Form_OrganisationAccount_Edit edt_Item_dlg = new Form_OrganisationAccount_Edit(DBSync.DBSync.DB_for_Tangenta.m_DBTables,
                                                                        tbl_OrganisationAccount,
                                                            " OrganisationAccount_$_org_$$Name desc",ynav);
            edt_Item_dlg.ShowDialog(this);
            Init();
            return true;
        }
    

        private void btn_BankAccounts_Click(object sender, EventArgs e)
        {
            if (myOrg.ID != null)
            {
                Navigation xnav = new Navigation();
                xnav.bDoModal = true;
                xnav.m_eButtons = Navigation.eButtons.OkCancel;
                Edit_OrganisationAccount(xnav);
            }
            else
            {
                XMessage.Box.Show(this, lng.s_ThereAreNoBasicOragnisationDataPleaseEnterOrganisationDataBeforeBankAccounts, MessageBoxIcon.Information);
            }
        }

        private void usrc_EditRow_after_InsertInDataBase(SQLTable m_tbl, ID id, bool bRes)
        {
            if (bRes)
            {
                usrc_EditRow.AllowUserToAddNew = false;
                myOrg.Get();
            }
        }

        private void btn_Office_Edit(object sender, EventArgs e)
        {
            if (myOrg.ID != null)
            {

                this.Cursor = Cursors.WaitCursor;
                Navigation xnav = new Navigation();
                xnav.bDoModal = true;
                xnav.m_eButtons = Navigation.eButtons.OkCancel;
                Form_myOrg_Office frm_office = new Form_myOrg_Office(this, xnav);
                frm_office.ShowDialog(this);
                this.Cursor = Cursors.Arrow;
            }
            else
            {
                XMessage.Box.Show(this, lng.s_ThereAreNoBasicOragnisationDataPleaseEnterOrganisationDataBeforeOfficeData, MessageBoxIcon.Information);
            }
        }

        private void usrc_NavigationButtons1_ButtonPressed(NavigationButtons.Navigation.eEvent evt)
        {
            switch (nav.m_eButtons)
            {
                case NavigationButtons.Navigation.eButtons.PrevNextExit:
                    {
                        switch (evt)
                        {
                            case NavigationButtons.Navigation.eEvent.NEXT:
                                nav.eExitResult = evt;
                                if (!do_OK())
                                {
                                    nav.eExitResult = NavigationButtons.Navigation.eEvent.NOTHING;
                                }
                                break;
                            case NavigationButtons.Navigation.eEvent.PREV:
                                nav.eExitResult = evt;
                                Close();
                                DialogResult = DialogResult.OK;
                                break;
                            case NavigationButtons.Navigation.eEvent.EXIT:
                                nav.eExitResult = evt;
                                Close();
                                DialogResult = DialogResult.OK;
                                break;
                        }
                    }
                    break;
                case NavigationButtons.Navigation.eButtons.OkCancel:
                    {
                        switch (evt)
                        {
                            case NavigationButtons.Navigation.eEvent.OK:
                                nav.eExitResult = evt;
                                if (!do_OK())
                                {
                                    nav.eExitResult = NavigationButtons.Navigation.eEvent.NOTHING;
                                }
                                break;
                            case NavigationButtons.Navigation.eEvent.CANCEL:
                                nav.eExitResult = evt;
                                if (!do_Cancel())
                                {
                                    nav.eExitResult = NavigationButtons.Navigation.eEvent.NOTHING; 
                                }
                                break;
                        }
                    }
                    break;
            }
        }

        private void usrc_EditRow_FillTable(SQLTable tbl)
        {
            if (myorg_PostAddress_v != null)
            {
                if ((myorg_PostAddress_v.Country_v != null))
                {
                    if (tbl.TableName.Equals("cCountry_Org"))
                    {
                        foreach (Column col in tbl.Column)
                        {
                            if (col.Name.Equals("Country"))
                            {
                                col.InputControl.SetValue(myorg_PostAddress_v.Country);
                            }
                            else if (col.Name.Equals("Country_ISO_3166_a2"))
                            {
                                col.InputControl.SetValue(myorg_PostAddress_v.Country_ISO_3166_a2);
                            }
                            else if (col.Name.Equals("Country_ISO_3166_a3"))
                            {
                                col.InputControl.SetValue(myorg_PostAddress_v.Country_ISO_3166_a3);
                            }
                            else if (col.Name.Equals("Country_ISO_3166_num"))
                            {
                                col.InputControl.SetValue(myorg_PostAddress_v.Country_ISO_3166_num);
                            }
                        }
                    }
                }
            }
            else if (TangentaDB.myOrg.Address_v != null)
            {
                if ((TangentaDB.myOrg.Address_v.Country_v != null))
                {
                    if (tbl.TableName.Equals("cCountry_Org"))
                    {
                        foreach (Column col in tbl.Column)
                        {
                            if (col.Name.Equals("Country"))
                            {
                                col.InputControl.SetValue(TangentaDB.myOrg.Address_v.Country);
                            }
                            else if (col.Name.Equals("Country_ISO_3166_a2"))
                            {
                                col.InputControl.SetValue(TangentaDB.myOrg.Address_v.Country_ISO_3166_a2);
                            }
                            else if (col.Name.Equals("Country_ISO_3166_a3"))
                            {
                                col.InputControl.SetValue(TangentaDB.myOrg.Address_v.Country_ISO_3166_a3);
                            }
                            else if (col.Name.Equals("Country_ISO_3166_num"))
                            {
                                col.InputControl.SetValue(TangentaDB.myOrg.Address_v.Country_ISO_3166_num);
                            }
                        }
                    }
                }
            }
        }

        private void usrc_EditRow_SetInputControlProperties(Column col, object obj)
        {
            if (myorg_PostAddress_v!=null)
            {
                if ((myorg_PostAddress_v.Country_v != null))
                {
                    if (col.ownerTable.TableName.Equals("cCountry_Org"))
                    {
                        if (col.Name.Equals("Country"))
                        {
                            col.InputControl.SetValue(myorg_PostAddress_v.Country);
                        }
                        else if (col.Name.Equals("Country_ISO_3166_a2"))
                        {
                            col.InputControl.SetValue(myorg_PostAddress_v.Country_ISO_3166_a2);
                        }
                        else if (col.Name.Equals("Country_ISO_3166_a3"))
                        {
                            col.InputControl.SetValue(myorg_PostAddress_v.Country_ISO_3166_a3);
                        }
                        else if (col.Name.Equals("Country_ISO_3166_num"))
                        {
                            col.InputControl.SetValue(myorg_PostAddress_v.Country_ISO_3166_num);
                        }
                    }
                }
            }
            else if (TangentaDB.myOrg.Address_v != null)
            {
                if ((TangentaDB.myOrg.Address_v.Country_v != null))
                {
                    if (col.ownerTable.TableName.Equals("cCountry_Org"))
                    {
                        if (col.Name.Equals("Country"))
                        {
                            col.InputControl.SetValue(TangentaDB.myOrg.Address_v.Country);
                        }
                        else if (col.Name.Equals("Country_ISO_3166_a2"))
                        {
                            col.InputControl.SetValue(TangentaDB.myOrg.Address_v.Country_ISO_3166_a2);
                        }
                        else if (col.Name.Equals("Country_ISO_3166_a3"))
                        {
                            col.InputControl.SetValue(TangentaDB.myOrg.Address_v.Country_ISO_3166_a3);
                        }
                        else if (col.Name.Equals("Country_ISO_3166_num"))
                        {
                            col.InputControl.SetValue(TangentaDB.myOrg.Address_v.Country_ISO_3166_num);
                        }
                    }
                }
            }
        }

        private void Form_myOrg_Edit_KeyUp(object sender, KeyEventArgs e)
        {
            this.usrc_EditRow.KeyPressed(e.KeyCode);
        }


        private bool Check_TaxID(SQLTable xtbl)
        {
            Column col = xtbl.FindColumn(typeof(TangentaTableClass.OrganisationData));
            if (col != null)
            {
                if (col.fKey != null)
                {
                    if (col.fKey.fTable != null)
                    {
                        Column colorg = col.fKey.fTable.FindColumn(typeof(TangentaTableClass.Organisation));
                        if (colorg != null)
                        {
                            if (colorg.fKey != null)
                            {
                                if (colorg.fKey.fTable != null)
                                {

                                    Column col_Tax_ID = colorg.fKey.fTable.FindColumn(typeof(TangentaTableClass.Tax_ID));
                                    if (col_Tax_ID != null)
                                    {
                                        if (col_Tax_ID.InputControl != null)
                                        {
                                            if (col_Tax_ID.InputControl.Null_Selected)
                                            {
                                                XMessage.Box.Show(this, lng.s_SLO_Organisation_Tax_ID_must_be_defined, MessageBoxIcon.Stop);
                                                return false;
                                            }
                                            else
                                            {
                                                object xobj = null;
                                                SQL_Parameter.eSQL_Parameter epar = SQL_Parameter.eSQL_Parameter.Int;
                                                if (col_Tax_ID.InputControl.SetColumnObject(ref xobj, ref epar))
                                                {
                                                    if (xobj is string)
                                                    {
                                                        if (Country_ISO_3166.ISO_3166_Table.m_Slovenia.Tax_ID_checkproc != null)
                                                        {
                                                            string Err = null;
                                                            if (!Country_ISO_3166.ISO_3166_Table.m_Slovenia.Tax_ID_checkproc(((string)xobj), ref Err))
                                                            {
                                                                if (XMessage.Box.Show(this, lng.s_SLO_Organisation_Tax_ID_checksum_is_not_valid, "", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2) == DialogResult.No)
                                                                {
                                                                    return false;
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return true;
        }


        private void usrc_EditRow_before_InsertInDataBase(SQLTable m_tbl, ref bool bCancel)
        {
            if (myorg_PostAddress_v != null)
            {
                if (myorg_PostAddress_v.Country_ISO_3166_num == Country_ISO_3166.ISO_3166_Table.m_Slovenia.State_Number)
                {
                    if (!Check_TaxID(m_tbl))
                    {
                        bCancel = true;
                    }
                }
            }

        }

        private void usrc_EditRow_before_UpdateDataBase(SQLTable m_tbl, ref bool bCancel)
        {
            if (myorg_PostAddress_v != null)
            {
                if (myorg_PostAddress_v.Country_ISO_3166_num == Country_ISO_3166.ISO_3166_Table.m_Slovenia.State_Number)
                {
                    if (!Check_TaxID(m_tbl))
                    {
                        bCancel = true;
                    }
                }
            }
        }
    }
}
