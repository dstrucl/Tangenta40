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
    public partial class UserInfoForm : Form
    {
        LoginControl login_control;
        public UserInfoForm(LoginControl logctrl)
        {
            InitializeComponent();
            try
            {
                this.Text = lngRPM.s_UserInfo.s;
                lbl_Roles.Text = lngRPM.s_Roles.s;
                login_control = logctrl;
                lbl_UserName.Text = lngRPM.s_UserName.s;
                lbl_first_name.Text = lngRPM.s_FirstName.s;
                lbl_last_name.Text = lngRPM.s_LastName.s;
                lbl_Identity.Text = lngRPM.s_IdentityNumber.s;
                lbl_Contact.Text = lngRPM.s_Contact.s;
                txt_UserName.Text = login_control.UserName;
                txt_first_name.Text = login_control.FirstName;
                txt_last_name.Text = login_control.LastName;
                txt_Identiy.Text = login_control.Identity;
                txt_Contact.Text = login_control.Contact;
                chk_NotActiveAfterPasswordExpires.Checked = login_control.NotActiveAfterPasswordExpires;
                chk_PasswordExpiresInNumberOfDays.Checked = login_control.bPasswordExpiresInNumberOfDays;
                chk_PasswordNeverExpires.Checked = login_control.PasswordNeverExpires;
                txt_NumberOfDays.Text = login_control.NumberOfDaysAfterPasswordExpires.ToString();
                txt_LastUserPasswordDefinitionTime.Text = login_control.LastUserPasswordDefinitionTime.ToString();
                if (!login_control.PasswordNeverExpires)
                {
                    lbl_Password_expires_on.Visible = true;
                    lbl_Password_expires_on.Text = lngRPM.s_PasswordExpiresAfter.s + login_control.NumberOfDaysAfterPasswordExpires.ToString();
                    txt_NumberOfDays.Visible = true;
                }
                else
                {
                    lbl_Password_expires_on.Visible = false;
                    txt_NumberOfDays.Visible = false;
                }
                btn_LoginHistory.Text = lngRPM.s_LoginHistoryAndActiveUsers.s;
                
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
            foreach (Role role in login_control.LoginRoles)
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
            LoginHistoryForm login_history_form = new LoginHistoryForm(login_control, login_control.LoginUsers_id, login_control.UserName);
            login_history_form.ShowDialog();
        }
    }
}
