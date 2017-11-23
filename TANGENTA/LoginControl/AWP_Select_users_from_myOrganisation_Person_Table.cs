using LanguageControl;
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
    public partial class AWP_Select_users_from_myOrganisation_Person_Table : Form
    {

        private AWP_UserManager usrmgtfrm = null;
        public DataTable dtmyOrganisation_Person_not_in_LoginUsers = null;
        private DBConnectionControl40.DBConnection logincon = null;
        public DataRow[] drsImportAdministrator = null;
        public DataRow[] drsImportOthers = null;

        public AWP_Select_users_from_myOrganisation_Person_Table(DBConnectionControl40.DBConnection con, AWP_UserManager xawp_usrmgt_frm,ltext ltInstruction)
        {
            usrmgtfrm = xawp_usrmgt_frm;
            InitializeComponent();
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
            lng.s_Import.Text(btn_Import);
            lng.s_Cancel.Text(btn_Cancel);
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

                foreach (AWPColName cn in usrmgtfrm.awpd.AWP_col_Names)
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

        private void btn_Import_Click(object sender, EventArgs e)
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

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
