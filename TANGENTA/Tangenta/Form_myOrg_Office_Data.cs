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
    public partial class Form_myOrg_Office_Data : Form
    {
        private UniqueControlName uctrln = new UniqueControlName();
        private bool bclose = false;
        private string ColumnToOrderBy = "Office_Data_$_office_$$Name asc";
        private ID m_Office_ID = null;
        private SQLTable tbl_Office_Data = null;
        private NavigationButtons.Navigation nav = null;

        public Form_myOrg_Office_Data(ID xOffice_ID,NavigationButtons.Navigation xnav)
        {
            InitializeComponent();
            nav = xnav;
            usrc_NavigationButtons1.Init(nav);
            if (Program.b_FVI_SLO)
            {
                lng.s_Edit_Office_Data_FVI_SLO_RealEstateBP.Text(this.btn_FVI_SLO_RealEstateBP);
            }
            else
            {
                this.btn_FVI_SLO_RealEstateBP.Visible = false;
            }

            m_Office_ID = xOffice_ID;
            tbl_Office_Data = new SQLTable(DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(Office_Data)));
            tbl_Office_Data.SetColumnStyle("Office_ID", Column.eStyle.none);
            this.Text = lng.s_Edit_Office_Data.s;
            this.usrc_EditTable1.Title = lng.s_Edit_Office_Data.s;
            string selection = @" Office_Data_$_office_$_mo_$_orgd_$_org_$$Name,
                                    Office_Data_$_office_$$Name,
                                    Office_Data_$_office_$$ShortName,
                                    Office_Data_$_cadrorg_$_cstrnorg_$$StreetName,
                                    Office_Data_$_cadrorg_$_chounorg_$$HouseNumber,
                                    Office_Data_$_cadrorg_$_cziporg_$$ZIP,
                                    Office_Data_$_cadrorg_$_ccitorg_$$City,
                                    Office_Data_$_cadrorg_$_ccouorg_$$Country,
                                    Office_Data_$_cadrorg_$_cstorg_$$State,
                                    ID";
            string swhere = "";
            if (ID.Validate(m_Office_ID))
            {
                swhere = " where  Office_Data_$_office_$$ID = " + m_Office_ID.ToString() + " ";
            }
            if (usrc_EditTable1.Init(DBSync.DBSync.DB_for_Tangenta.m_DBTables,
                                     DBSync.DBSync.MyTransactionLog_delegates,
                                     tbl_Office_Data, selection, ColumnToOrderBy, false, swhere, null, false,nav))
            {
                if (usrc_EditTable1.RowsCount > 0)
                {
                    usrc_EditTable1.AllowUserToAddNew = false;
                }
                else
                {
                    usrc_EditTable1.FillInitialData();
                    usrc_EditTable1.AllowUserToAddNew = true;
                }
            }
            else
            {
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
            if (ID.Validate(m_Office_ID))
            {
                if (m_tbl.TableName.ToLower().Equals("office"))
                {
                    string Err = null;
                    m_tbl.FillDataInputControl(DBSync.DBSync.Con,uctrln, m_Office_ID, true, ref Err);
                }
            }
            else if (ID.Validate(myOrg.ID))
            {
                if (m_tbl.TableName.ToLower().Equals("myorganisation"))
                {
                    string Err = null;
                    m_tbl.FillDataInputControl(DBSync.DBSync.Con, uctrln, myOrg.ID, true, ref Err);
                }
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
                //myOrg.Get(1);
                //if (Program.b_FVI_SLO)
                //{
                //    this.Cursor = Cursors.WaitCursor;
                //    Form_myOrg_Office_Data_FVI_SLO_RealEstateBP frm_offd_fvislo_resbp = new Form_myOrg_Office_Data_FVI_SLO_RealEstateBP(ID,nav);
                //    frm_offd_fvislo_resbp.ShowDialog();
                //    this.Cursor = Cursors.Arrow;
                //}
                this.usrc_EditTable1.AllowUserToAddNew = false; //Only one row !!!
            }
        }

        private void btn_FVI_SLO_RealEstateBP_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            Form_myOrg_Office_Data_FVI_SLO_RealEstateBP frm_offd_fvislo_resbp = new Form_myOrg_Office_Data_FVI_SLO_RealEstateBP(this.usrc_EditTable1.Identity,nav);
            frm_offd_fvislo_resbp.ShowDialog();
            this.Cursor = Cursors.Arrow;
        }

        private bool do_OK()
        {
            if (usrc_EditTable1.Changed)
            {
                if (XMessage.Box.Show(this, lng.s_YouDidNotWriteDataToDB_SaveData_YesOrNo, lng.s_Warning.s, MessageBoxButtons.YesNo, Properties.Resources.Tangenta_Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    Transaction transaction_Form_myOrg_Office_Data_do_OK_usrc_EditTable1_Save = new Transaction("Form_myOrg_Office_Data.do_OK.usrc_EditTable1.Save", DBSync.DBSync.MyTransactionLog_delegates);
                    if (usrc_EditTable1.Save(transaction_Form_myOrg_Office_Data_do_OK_usrc_EditTable1_Save))
                    {
                        transaction_Form_myOrg_Office_Data_do_OK_usrc_EditTable1_Save.Commit();
                    }
                    else
                    {
                        transaction_Form_myOrg_Office_Data_do_OK_usrc_EditTable1_Save.Rollback();
                    }
                }
            }
            else
            {
                if (usrc_EditTable1.RowsCount == 0)
                {
                    XMessage.Box.Show(this, lng.s_YouMustEnterYourOfficeAddressData, "", MessageBoxButtons.OK, Properties.Resources.Tangenta_Question, MessageBoxDefaultButton.Button1);
                    return false;
                }
            }

            if (myOrg.m_myOrg_Office == null)
            {
                if (ID.Validate(usrc_EditTable1.Identity))
                {
                    if (XMessage.Box.Show(this, lng.s_YourOfficeIsNotDefined_DefineSelectedOffice_AsYourOffice_YesOrNo, lng.s_Warning.s, MessageBoxButtons.YesNo, Properties.Resources.Tangenta_Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        if (myOrg.Get())
                        {

                            ID xOffice_ID = null;
                            if (f_Office_Data.Get_Office_ID(usrc_EditTable1.Identity, ref xOffice_ID))
                            {
                                myOrg.SetOffice(xOffice_ID);
                            }
                        }
                    }
                    else
                    {
                        return false;
                    }
                }

                if (myOrg.m_myOrg_Office == null)
                {
                    XMessage.Box.Show(this, lng.s_YourOfficeIsNotDefined_SelectedOffice_AsYourOffice, "", MessageBoxButtons.OK, Properties.Resources.Tangenta_Question, MessageBoxDefaultButton.Button1);
                    return false;
                }
            }
            Close();
            DialogResult = DialogResult.OK;
            return true;
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

        private void Form_myOrg_Office_Data_KeyUp(object sender, KeyEventArgs e)
        {
            this.usrc_EditTable1.KeyPressed(e.KeyCode);
        }
    }
}
