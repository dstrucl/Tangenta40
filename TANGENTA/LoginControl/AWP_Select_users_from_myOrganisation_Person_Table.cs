using LanguageControl;
using NavigationButtons;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LoginControl
{
    internal partial class AWP_Select_users_from_myOrganisation_Person_Table : Form
    {

        internal DataTable dtmyOrganisation_Person_not_in_LoginUsers = null;
        private DBConnectionControl40.DBConnection logincon = null;
        internal DataRow[] drsImportAdministrator = null;
        internal DataRow[] drsImportOthers = null;
        internal AWPBindingData awpd  = null;

        internal AWP_Select_users_from_myOrganisation_Person_Table(Navigation xnav,DBConnectionControl40.DBConnection con, AWPBindingData xawpd,ltext ltInstruction)
        {
            InitializeComponent();
            awpd = xawpd;
            logincon = con;
            this.Text = "";
            if (ltInstruction != null)
            {
                ltInstruction.Text(lbl_Instruction);
            }
            else
            {
                lbl_Instruction.Text = "";
            }
            usrc_NavigationButtons1.Init(xnav);
            //lng.s_Import.Text(btn_Import);
            //lng.s_Cancel.Text(btn_Cancel);
        }

        private void AWP_Select_users_from_myOrganisation_Person_Table_Load(object sender, EventArgs e)
        {
            dtmyOrganisation_Person_not_in_LoginUsers = new DataTable();
            string Err = null;
            if (AWP_func.Read_myOrganisation_Person_not_in_LoginUsers( ref dtmyOrganisation_Person_not_in_LoginUsers,ref Err))
            {
                DataColumn dcol_selected = new DataColumn("Selected", typeof(bool));
                DataColumn dcol_Administrator = new DataColumn("Administrator", typeof(bool));
                dtmyOrganisation_Person_not_in_LoginUsers.Columns.Add(dcol_selected);
                dtmyOrganisation_Person_not_in_LoginUsers.Columns.Add(dcol_Administrator);
                dgvx_myOrganisationPerson.DataSource = dtmyOrganisation_Person_not_in_LoginUsers;
                foreach (DataGridViewColumn dgvc in dgvx_myOrganisationPerson.Columns)
                {
                    dgvc.Visible = false;
                }

                foreach (AWPColName cn in awpd.AWP_col_Names)
                {
                    if (dgvx_myOrganisationPerson.Columns.Contains(cn.ColumnName))
                    {
                        if (cn.NameInLanguage != null)
                        {
                            dgvx_myOrganisationPerson.Columns[cn.ColumnName].Visible = true;
                            dgvx_myOrganisationPerson.Columns[cn.ColumnName].DisplayIndex = cn.DisplayIndex;
                            dgvx_myOrganisationPerson.Columns[cn.ColumnName].HeaderText = cn.NameInLanguage.s;
                            dgvx_myOrganisationPerson.Columns[cn.ColumnName].ReadOnly = true;
                            dgvx_myOrganisationPerson.Columns[cn.ColumnName].DefaultCellStyle.BackColor = Color.FromArgb(210, 210, 210);
                        }
                        else
                        {
                            dgvx_myOrganisationPerson.Columns[cn.ColumnName].Visible = false;
                        }
                    }
                }

                dgvx_myOrganisationPerson.Columns["Selected"].ReadOnly = false;
                dgvx_myOrganisationPerson.Columns["Selected"].DefaultCellStyle.BackColor = Color.White;
                dgvx_myOrganisationPerson.Columns["Administrator"].ReadOnly = false;
                dgvx_myOrganisationPerson.Columns["Administrator"].DefaultCellStyle.BackColor = Color.White;
                if (dtmyOrganisation_Person_not_in_LoginUsers.Rows.Count==1)
                {
                    dtmyOrganisation_Person_not_in_LoginUsers.Rows[0]["Selected"] = true;
                    dtmyOrganisation_Person_not_in_LoginUsers.Rows[0]["Administrator"] = true;
                    //dgvx_myOrganisationPerson.RefreshEdit();
                }
            }
            else
            {
                this.Close();
                DialogResult = DialogResult.Abort;
            }
        }

        private void DoImport()
        {
            drsImportAdministrator = dtmyOrganisation_Person_not_in_LoginUsers.Select("Selected = 1 and Administrator=1");
            drsImportOthers = dtmyOrganisation_Person_not_in_LoginUsers.Select("Selected = 1 and Administrator=0");
            if (drsImportAdministrator.Count()>0)
            {
                DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                XMessage.Box.Show(this, lng.s_YouMustSelectAtLeastOnePersonWithAdministratorChecked, "", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            }
        }


        private void dgvx_myOrganisationPerson_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void usrc_NavigationButtons1_ButtonPressed(NavigationButtons.Navigation.eEvent evt)
        {
            switch (evt)
            {
                case Navigation.eEvent.NEXT:
                    DoImport();
                    break;

                case Navigation.eEvent.PREV:
                    DialogResult = DialogResult.Cancel;
                    this.Close();
                    break;

                case Navigation.eEvent.EXIT:
                    DialogResult = DialogResult.Abort;
                    this.Close();
                    break;

            }
        }
    }
}
