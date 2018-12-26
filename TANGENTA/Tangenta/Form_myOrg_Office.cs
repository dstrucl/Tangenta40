// Copyright (c) 2011 rubicon IT GmbH
using TangentaTableClass;
using DBTypes;
using TangentaDB;
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
using UniqueControlNames;
using DBConnectionControl40;

namespace Tangenta
{
    public partial class Form_myOrg_Office : Form
    {
        private UniqueControlName uctrln = new UniqueControlName();
        private bool bclose = false;
        private string ColumnToOrderBy = "Office_$_mo_$_orgd_$_org_$$Name asc";
        private ID myOrganisation_ID = null;
        private SQLTable tbl_Office = null;
        private NavigationButtons.Navigation nav = null;

        public Form_myOrg_Office(Control parentcontrol,NavigationButtons.Navigation xnav)
        {
            InitializeComponent();
            nav = xnav;
            usrc_NavigationButtons1.Init(nav);
            lng.s_Edit_Office_Data.Text(btn_Office_Data_And_FVI_SLO_RealEstateBP);
            if (myOrg.ID != null)
            {
                myOrganisation_ID = myOrg.ID;
                tbl_Office = new SQLTable(DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(Office)));
                this.Text = lng.s_Edit_Offices.s;
                this.usrc_EditTable1.Title = lng.s_Edit_Offices.s;
                string selection = "Office_$$Name,Office_$$ShortName,Office_$_mo_$_orgd_$_org_$$Name,Office_$_mo_$_orgd_$_orgt_$$OrganisationTYPE,Office_$_mo_$_orgd_$_org_$$Tax_ID,ID";
                string where_condition = " where Office_$_mo_$$ID = " + myOrganisation_ID.ToString() + " ";
                if (usrc_EditTable1.Init(DBSync.DBSync.DB_for_Tangenta.m_DBTables,
                                         DBSync.DBSync.MyTransactionLog_delegates,
                                         tbl_Office, selection, ColumnToOrderBy, false, null, null, false, nav))
                {
                    usrc_EditTable1.FillInitialData();
                }
                else
                {
                    bclose = true;
                }
            }
            else
            {
                //LogFile.Error.Show("ERROR:Tangenta:Form_myOrg_Offices_Edit():myOrg.ID_v is not defined!");
                XMessage.Box.Show(parentcontrol, lng.s_ThereAreNoBasicOragnisationDataPleaseEnterOrganisationDataBeforeOfficeData, MessageBoxIcon.Information);
                bclose = true;
            }
        }
        private void do_Cancel()
        {
            this.Close();
            DialogResult = DialogResult.Cancel;
        }

        #region Fill ReadOnlyDaTa
        private void usrc_EditTable1_FillTable(SQLTable m_tbl)
        {
            if (m_tbl.TableName.ToLower().Equals("myorganisation"))
            {
                string Err = null;
                m_tbl.FillDataInputControl(DBSync.DBSync.Con, uctrln, myOrganisation_ID, true, ref Err);
            }
        }

        private void usrc_EditTable1_after_New(SQLTable m_tbl, bool bRes)
        {
            usrc_EditTable1.FillInitialData();
        }
        #endregion

        private void Form_myOrg_Offices_Edit_Load(object sender, EventArgs e)
        {


            if (bclose)
            {
                DialogResult = DialogResult.Abort;
                this.Close();
            }
        }

        private void usrc_EditTable1_after_InsertInDataBase(SQLTable m_tbl, ID xID, bool bRes)
        {
            if (bRes)
            {
                this.Cursor = Cursors.WaitCursor;
                NavigationButtons.Navigation nav_frm_offdata = null;
                if (nav!=null)
                {
                    nav_frm_offdata = nav;
                }
                else
                {
                    nav_frm_offdata = new NavigationButtons.Navigation(null);
                    nav_frm_offdata.bDoModal = true;
                    nav_frm_offdata.m_eButtons = NavigationButtons.Navigation.eButtons.OkCancel;
                }
                nav_frm_offdata.ChildDialog = new Form_myOrg_Office_Data(xID, nav_frm_offdata);
                this.Cursor = Cursors.Arrow;
                this.Visible = false;
                nav_frm_offdata.ShowDialog();
                if (nav_frm_offdata.eExitResult == NavigationButtons.Navigation.eEvent.PREV)
                {
                    this.Visible = true;
                    nav.ChildDialog = this;
                }
                else if (nav_frm_offdata.eExitResult == NavigationButtons.Navigation.eEvent.NEXT)
                {
                    myOrg.Get();
                }
                else if (nav_frm_offdata.eExitResult == NavigationButtons.Navigation.eEvent.EXIT)
                {
                    this.Close();
                    DialogResult = DialogResult.Cancel;
                    return;
                }
            }
        }

        private void btn_Office_Data_And_FVI_SLO_RealEstateBP_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            Form_myOrg_Office_Data frm_offdata = new Form_myOrg_Office_Data(this.usrc_EditTable1.Identity,nav);
            frm_offdata.ShowDialog(this);
            this.Cursor = Cursors.Arrow;
        }

        private bool do_OK()
        {
            if (usrc_EditTable1.Changed)
            {
                if (XMessage.Box.Show(this, lng.s_YouDidNotWriteDataToDB_SaveData_YesOrNo, lng.s_Warning.s, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    Transaction transaction_Form_myOrg_Office_do_OK_usrc_EditTable1_Save = DBSync.DBSync.NewTransaction("Form_myOrg_Office.do_OK.usrc_EditTable1.Save");
                    if (usrc_EditTable1.Save(transaction_Form_myOrg_Office_do_OK_usrc_EditTable1_Save))
                    {
                        if (transaction_Form_myOrg_Office_do_OK_usrc_EditTable1_Save.Commit())
                        {
                            this.Close();
                            DialogResult = DialogResult.OK;
                            return true;
                        }
                    }
                    else
                    {
                        transaction_Form_myOrg_Office_do_OK_usrc_EditTable1_Save.Rollback();
                        if (XMessage.Box.Show(this, lng.s_DataNotSavedEndYesNo, "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)==DialogResult.Yes)
                        {
                            this.Close();
                            DialogResult = DialogResult.OK;
                            return true;
                        }
                    }
                }
                return false;
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
                    XMessage.Box.Show(this, lng.s_YouMustEnterYourOfficeData, "", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                    return false;
                }
            }
        }

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

        private void Form_myOrg_Office_KeyUp(object sender, KeyEventArgs e)
        {
            this.usrc_EditTable1.KeyPressed(e.KeyCode);
        }
    }
}
