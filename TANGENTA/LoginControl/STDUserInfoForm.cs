using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LanguageControl;

namespace LoginControl
{
    public partial class STDUserInfoForm : Form
    {
        STD std=null;
        public STDUserInfoForm(STD xstd)
        {
            InitializeComponent();
            try
            {
                this.Text = lng.s_UserInfo.s;
                lbl_Roles.Text = lng.s_Roles.s;
                std = xstd;
                lbl_UserName.Text = lng.s_UserName.s;
                lbl_first_name.Text = lng.s_FirstName.s;
                lbl_last_name.Text = lng.s_LastName.s;
                lbl_Identity.Text = lng.s_IdentityNumber.s;
                lbl_Contact.Text = lng.s_Contact.s;
                txt_UserName.Text = std.lctrl.awp.LMO1User.UserName;
                txt_first_name.Text = std.lctrl.awp.LMO1User.FirstName;
                txt_last_name.Text = std.lctrl.awp.LMO1User.LastName;
                txt_Identiy.Text = std.lctrl.awp.LMO1User.Identity;
                txt_Contact.Text = std.lctrl.awp.LMO1User.Email;
                chk_NotActiveAfterPasswordExpires.Checked = std.lctrl.awp.LMO1User.NotActiveAfterPasswordExpires;
                chk_PasswordExpiresInNumberOfDays.Checked = std.lctrl.awp.LMO1User.bPasswordExpiresInNumberOfDays;
                chk_PasswordNeverExpires.Checked = std.lctrl.awp.LMO1User.PasswordNeverExpires;
                txt_NumberOfDays.Text = std.lctrl.awp.LMO1User.Maximum_password_age_in_days.ToString();
                txt_LastUserPasswordDefinitionTime.Text = std.lctrl.awp.LMO1User.LastUserPasswordDefinitionTime.ToString();
                if (!std.lctrl.awp.LMO1User.PasswordNeverExpires)
                {
                    lbl_Password_expires_on.Visible = true;
                    lbl_Password_expires_on.Text = lng.s_PasswordExpiresAfter.s + std.lctrl.PasswordExpiresInNumberOfDays.ToString();
                    txt_NumberOfDays.Visible = true;
                }
                else
                {
                    lbl_Password_expires_on.Visible = false;
                    txt_NumberOfDays.Visible = false;
                }
                btn_LoginHistory.Text = lng.s_LoginHistoryAndActiveUsers.s;
                
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Error:UserInfoForm:UserInfoForm:Exception=" + Ex.Message);
            }
        }

        private void UserInfoForm_Load(object sender, EventArgs e)
        {
            SetRoles();
        }

        private void SetRoles()
        {
            DataGridViewColumn dgvcol_Name = new DataGridViewTextBoxColumn();
            dgvcol_Name.Name = LoginDB_DataSet.LoginRoles.Name.name;
            DataGridViewColumn dgvcol_PrivilegesLevel =  new DataGridViewTextBoxColumn();
            dgvcol_PrivilegesLevel.Name = LoginDB_DataSet.LoginRoles.PrivilegesLevel.name;
            DataGridViewColumn dgvcol_description =  new DataGridViewTextBoxColumn();
            dgvcol_description.Name = LoginDB_DataSet.LoginRoles.description.name;
            dgv_Roles.Columns.Add(dgvcol_Name);
            dgv_Roles.Columns.Add(dgvcol_PrivilegesLevel);
            dgv_Roles.Columns.Add(dgvcol_description);
            LoginDB_DataSet.LoginRoles_lang LoginRoles_lang = new LoginDB_DataSet.LoginRoles_lang();
            LoginDB_DataSet.HeaderText.Set(dgv_Roles, LoginRoles_lang.col_headers);
            foreach (STDRole role in std.LoginSTDRoles)
            {
                int iRow = dgv_Roles.Rows.Add();
                dgv_Roles.Rows[iRow].Cells[LoginDB_DataSet.LoginRoles.Name.name].Value = role.Name;
                dgv_Roles.Rows[iRow].Cells[LoginDB_DataSet.LoginRoles.PrivilegesLevel.name].Value = role.PrivilegesLevel;
                dgv_Roles.Rows[iRow].Cells[LoginDB_DataSet.LoginRoles.description.name].Value = role.description;
            }

        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btn_LoginHistory_Click(object sender, EventArgs e)
        {
            STDLoginHistoryForm login_history_form = new STDLoginHistoryForm(std,Convert.ToInt32(std.lctrl.awp.LMO1User.LoginUsers_id), std.lctrl.awp.LMO1User.UserName);
            login_history_form.ShowDialog();
        }
    }
}
