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
    public partial class AWPChangePasswordForm : Form
    {
        LoginCtrl login_control = null;
        AWPLoginData awpld = null;

        public AWPChangePasswordForm(LoginCtrl loginctrl,AWPLoginData xawpld, string sInstruction)
        {
            InitializeComponent();
            login_control = loginctrl;
            awpld = xawpld;
            this.Text = lng.s_UserThatChangesPassword.s + login_control.UserName;
            lbl_New_Password.Text = lng.s_New_Password.s;
            lbl_Confirm_New_Pasword.Text = lng.s_Confirm_New_Password.s;
            lbl_Instruction.Text = sInstruction;
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text.Length >= login_control.MinPasswordLength)
            {
                if (txtPassword.Text.Equals(txtConfirmPassword.Text))
                {

                    if (AWP_func.LoginUsers_UserChangeItsOwnPassword(awpld, LoginCtrl.CalculateSHA256(txtConfirmPassword.Text)))
                    {
                        DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {                       
                        DialogResult = DialogResult.Abort;
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show(lng.s_Password_does_not_match.s);
                }
            }
        }
    }
}
