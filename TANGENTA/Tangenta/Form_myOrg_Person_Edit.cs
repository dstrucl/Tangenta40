#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion

using TangentaTableClass;
using DBTypes;
using LanguageControl;
using CodeTables;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TangentaDB;
using UniqueControlNames;
using DBConnectionControl40;

namespace Tangenta
{
    public partial class Form_myOrg_Person_Edit : Form
    {
        private UniqueControlName uctrln = new UniqueControlName();
        private bool bclose = false;
        private ID m_Office_ID = null;
        private ID m_myOrganisation_Person_ID = null;
        private SQLTable tbl_myOrganisation_Person;
        private string ColumnToOrderBy = "myOrganisation_Person_$_per_$_cln_$$LastName asc";
        private NavigationButtons.Navigation nav = null;

        public Form_myOrg_Person_Edit(ID xOffice_ID, ID xmyOrganisation_Person_ID,NavigationButtons.Navigation xnav)
        {
            InitializeComponent();
            nav = xnav;
            usrc_NavigationButtons1.Init(nav);
            m_Office_ID = xOffice_ID;
            m_myOrganisation_Person_ID = xmyOrganisation_Person_ID;
            lng.s_myOrganisation_Person_Data.Text(this);
            this.Icon = Properties.Resources.Person;
            this.usrc_EditTable1.Title = "";
            Init();
        }

        private void Init()
        {
            tbl_myOrganisation_Person = new SQLTable(DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(myOrganisation_Person)));
            string selection = @"  myOrganisation_Person_$_per_$_cfn_$$FirstName,
                                    myOrganisation_Person_$_per_$_cln_$$LastName,
                                    myOrganisation_Person_$_per_$$DateOfBirth,
                                    myOrganisation_Person_$_per_$$Tax_ID,
                                    myOrganisation_Person_$_per_$$Registration_ID,
                                    myOrganisation_Person_$_office_$_mo_$_orgd_$_org_$$Name,
                                    myOrganisation_Person_$_office_$$Name,
                                    myOrganisation_Person_$_office_$$ShortName,
                                    myOrganisation_Person_$_per_$$ID,
                                    ID
            ";
            if (usrc_EditTable1.Init(DBSync.DBSync.DB_for_Tangenta.m_DBTables, tbl_myOrganisation_Person, selection, ColumnToOrderBy, false, " where  myOrganisation_Person_$_office_$$ID = " + m_Office_ID.ToString() + " ", null, false, nav))
            {
                if (!ID.Validate(m_myOrganisation_Person_ID))
                {
                    usrc_EditTable1.FillInitialData();
                }
                else
                {
                    if (usrc_EditTable1.IdentitySelect(m_myOrganisation_Person_ID))
                    {

                    }
                }
            }
            else
            {
                bclose = true;
            }
        }

        private void Form_myOrg_Person_Edit_Load(object sender, EventArgs e)
        {
            if (bclose)
            {
                DialogResult = DialogResult.Abort;
                this.Close();
            }
        }

     
        private bool do_OK()
        {
            if (usrc_EditTable1.Changed)
            {
                if (XMessage.Box.Show(this, lng.s_YouDidNotWriteDataToDB_SaveData_YesOrNo, lng.s_Warning.s, MessageBoxButtons.YesNo, Properties.Resources.Tangenta_Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    if (usrc_EditTable1.Save())
                    {
                        Close();
                        DialogResult = DialogResult.OK;
                        return true;
                    }
                    else
                    {
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
                    Close();
                    DialogResult = DialogResult.OK;
                    return true;
                }
            }
            else
            {
                if (usrc_EditTable1.RowsCount > 0)
                {
                    Close();
                    DialogResult = DialogResult.OK;
                    return true;
                }
                else
                {
                    XMessage.Box.Show(this, lng.s_YouMustEnterYourOfficePersonData, "", MessageBoxButtons.OK, Properties.Resources.Tangenta_Question, MessageBoxDefaultButton.Button1);
                    return false;
                }
            }
        }

        private void do_Cancel()
        {
            Close();
            DialogResult = DialogResult.OK;
            //if (usrc_EditTable1.RowsCount > 0)
            //{
            //    Close();
            //    DialogResult = DialogResult.OK;
            //}
            //else
            //{
            //    if (XMessage.Box.Show(this, lng.s_YouDidNotEnterYourOrganisationPersonData, "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            //    {
            //        Close();
            //        DialogResult = DialogResult.Cancel;
            //    }
            //}
        }

        private void usrc_EditTable1_after_FillDataInputControl(SQLTable m_tbl, long ID)
        {

        }
        #region Fill ReadOnlyDaTa
        private void usrc_EditTable1_FillTable(SQLTable m_tbl)
        {
            if (m_tbl.TableName.ToLower().Equals("office"))
            {
                string Err = null;
                m_tbl.FillDataInputControl(DBSync.DBSync.Con,uctrln, m_Office_ID, true, ref Err);
            }
        }

        private void usrc_EditTable1_after_New(SQLTable m_tbl, bool bRes)
        {
            if (bRes)
            {
                usrc_EditTable1.FillInitialData();
            }
        }
        #endregion

        private void usrc_NavigationButtons1_ButtonPressed(NavigationButtons.Navigation.eEvent evt)
        {
            switch (nav.m_eButtons)
            {
                case NavigationButtons.Navigation.eButtons.OkCancel:
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
                            do_Cancel();
                            break;
                    }
                    break;
                case NavigationButtons.Navigation.eButtons.PrevNextExit:
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
                            do_Cancel();
                            break;
                        case NavigationButtons.Navigation.eEvent.EXIT:
                            nav.eExitResult = evt;
                            do_Cancel();
                            break;
                    }
                    break;

            }
        }

        private void btn_PersonData_Edit_Click(object sender, EventArgs e)
        {
            ID Person_ID = tf.set_ID(usrc_EditTable1.GetColumnObject("myOrganisation_Person_$_per_$$ID"));
            SQLTable tbl_PersonData = new SQLTable(DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(PersonData)));
            Form_PersonData_Edit edt_PersonData_dlg = null;
            if (ID.Validate(Person_ID))
            {
                ID PersonData_ID = null;
                if (f_PersonData.Find(Person_ID, ref PersonData_ID))
                {
                    if (ID.Validate(PersonData_ID))
                    {
                        edt_PersonData_dlg = new Form_PersonData_Edit(Person_ID,
                                                                      " where PersonData_$_per_$$ID = " + Person_ID.ToString(),
                                                                      DBSync.DBSync.DB_for_Tangenta.m_DBTables,
                                                                                    tbl_PersonData,
                                                                                    "PersonData_$_per_$_cln_$$LastName desc",
                                                                                    PersonData_ID,
                                                                                    nav);
                    }
                }
                else
                {
                    if (f_PersonData.InsertEmptyRow(Person_ID, ref  PersonData_ID))
                    {
                        edt_PersonData_dlg = new Form_PersonData_Edit(Person_ID,
                                                                      " where PersonData_$_per_$$ID = " + Person_ID.ToString(),
                                                                      DBSync.DBSync.DB_for_Tangenta.m_DBTables,
                                                                      tbl_PersonData,
                                                                      "PersonData_$_per_$_cln_$$LastName desc",
                                                                      PersonData_ID,
                                                                      nav);
                    }
                }
            }
            
            if (edt_PersonData_dlg!=null)
            {
                edt_PersonData_dlg.ShowDialog(this);
                Init();
            }

        }

        private void usrc_EditTable1_after_FillDataInputControl_1(SQLTable m_tbl, ID xID)
        {
            string sbtn_PersonData_Edit = "";
            object oFirstName = usrc_EditTable1.GetColumnObject("myOrganisation_Person_$_per_$_cfn_$$FirstName");
            if (oFirstName is string)
            {
                sbtn_PersonData_Edit = lng.s_MoreDataForPerson.s + " " + (string)oFirstName;
            }
            object oLastName = usrc_EditTable1.GetColumnObject("myOrganisation_Person_$_per_$_cln_$$LastName");
            if (oLastName is string)
            {
                sbtn_PersonData_Edit +=  " " + (string)oLastName;
            }
            this.btn_PersonData_Edit.Text = sbtn_PersonData_Edit;

        }

        private void Form_myOrg_Person_Edit_KeyUp(object sender, KeyEventArgs e)
        {
            this.usrc_EditTable1.KeyPressed(e.KeyCode);
        }

        private void usrc_EditTable1_before_InsertInDataBase(SQLTable m_tbl, ref bool bCancel)
        {
            if (myOrg.Address_v.Country_ISO_3166_num==Country_ISO_3166.ISO_3166_Table.m_Slovenia.State_Number)
            {
                if (!Check_TaxID(m_tbl))
                {
                    bCancel = true;
                }
            }
        }

        private bool Check_TaxID(SQLTable xtbl)
        {
            Column col = xtbl.FindColumn(typeof(TangentaTableClass.Person));
            if (col != null)
            {
                if (col.fKey != null)
                {
                    if (col.fKey.fTable != null)
                    {
                        Column col_Tax_ID = col.fKey.fTable.FindColumn(typeof(TangentaTableClass.Tax_ID));
                        if (col_Tax_ID != null)
                        {
                            if (col_Tax_ID.InputControl != null)
                            {
                                if (col_Tax_ID.InputControl.Null_Selected)
                                {
                                    XMessage.Box.Show(this, lng.s_SLO_Person_Tax_ID_must_be_defined, MessageBoxIcon.Stop);
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
                                                    if (XMessage.Box.Show(this, lng.s_SLO_Person_Tax_ID_checksum_is_not_valid, "", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2) == DialogResult.No)
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
            return true;
        }

        private void usrc_EditTable1_before_UpdateDataBase(SQLTable m_tbl, ref bool bCancel)
        {
            if (myOrg.Address_v.Country_ISO_3166_num == Country_ISO_3166.ISO_3166_Table.m_Slovenia.State_Number)
            {
                if (!Check_TaxID(m_tbl))
                {
                    bCancel = true;
                }
            }
        }
    }
}
