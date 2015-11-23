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
    public partial class ChangePasswordForm : Form
    {
        LoginControl login_control = null;
        LoginDB_DataSet.LoginUsers LoginUsers = null;
        LoginDB_DataSet.LoginDB_DataSet_Procedures m_LoginDB_DataSet_Procedures = null;

        public ChangePasswordForm(LoginControl loginctrl,LoginDB_DataSet.LoginUsers login_users, string sInstruction)
        {
            InitializeComponent();
            login_control = loginctrl;
            LoginUsers = login_users;
            this.Text = lngRPM.s_UserThatChangesPassword.s + login_control.UserName;
            lbl_New_Password.Text = lngRPM.s_New_Password.s;
            lbl_Confirm_New_Pasword.Text = lngRPM.s_Confirm_New_Password.s;
            lbl_Instruction.Text = sInstruction;
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            string Err = null;
            if (txtPassword.Text.Length >= login_control.MinPasswordLength)
            {
                if (txtPassword.Text.Equals(txtConfirmPassword.Text))
                {
                    string Res = null;
                    m_LoginDB_DataSet_Procedures.LoginUsers_UserChangeItsOwnPassword(LoginUsers.o_id.id_, login_control.CalculateSHA256(txtConfirmPassword.Text), ref Res, ref Err);
                    if (Res.Equals("OK"))
                    {
                        login_control.m_LoginData.Time_When_UserSetsItsOwnPassword_LastTime = DateTime.Now;
                        DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        LogFile.Error.Show("Error:ChangePasswordForm:LoginUsers_UserChangeItsOwnPassword: Res= " + Res.ToString() + ",Err = " + Err.ToString());
                    }
                }
                else
                {
                    MessageBox.Show(lngRPM.s_Password_does_not_match.s);
                }
            }
        }

        private void ChangePasswordForm_Load(object sender, EventArgs e)
        {
            m_LoginDB_DataSet_Procedures = new LoginDB_DataSet.LoginDB_DataSet_Procedures(login_control.Login_con);
        }
    }
}
