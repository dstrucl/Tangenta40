﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DBConnectionControl40;
using LanguageControl;

namespace LoginControl
{
    public partial class AWPChangePasswordForm : Form
    {

        LMOUser m_LMOUser = null;

        public AWPChangePasswordForm(LMOUser xLMOUser, string sInstruction)
        {
            InitializeComponent();
            m_LMOUser = xLMOUser;
            this.Text = lng.s_UserThatChangesPassword.s + xLMOUser.UserName;
            lbl_New_Password.Text = lng.s_New_Password.s;
            lbl_Confirm_New_Pasword.Text = lng.s_Confirm_New_Password.s;
            lbl_Instruction.Text = sInstruction;
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text.Length >= LoginCtrl.MinPasswordLength)
            {
                if (txtPassword.Text.Equals(txtConfirmPassword.Text))
                {
                    Transaction transaction_AWPChangePasswordForm_btn_OK_Click_AWP_func_LoginUsers_UserChangeItsOwnPassword = DBSync.DBSync.NewTransaction("AWPChangePasswordForm.btn_OK_Click.AWP_func.LoginUsers_UserChangeItsOwnPassword");
                    if (AWP_func.LoginUsers_UserChangeItsOwnPassword(m_LMOUser.awpld, LoginCtrl.CalculateSHA256(txtConfirmPassword.Text), transaction_AWPChangePasswordForm_btn_OK_Click_AWP_func_LoginUsers_UserChangeItsOwnPassword))
                    {
                        if (transaction_AWPChangePasswordForm_btn_OK_Click_AWP_func_LoginUsers_UserChangeItsOwnPassword.Commit())
                        {
                            DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        else
                        {
                            return;
                        }
                    }
                    else
                    {
                        transaction_AWPChangePasswordForm_btn_OK_Click_AWP_func_LoginUsers_UserChangeItsOwnPassword.Rollback();
                        DialogResult = DialogResult.Abort;
                        this.Close();
                    }
                }
                else
                {
                    XMessage.Box.Show(this,lng.s_Password_does_not_match,MessageBoxIcon.Information);
                }
            }
        }

        private void btn_Cance_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

    }
}
