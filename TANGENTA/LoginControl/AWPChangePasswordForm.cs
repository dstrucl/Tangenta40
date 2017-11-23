﻿using System;
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
        LoginControl login_control = null;

        public AWPChangePasswordForm(LoginControl loginctrl,DataRow dr, string sInstruction)
        {
            InitializeComponent();
            login_control = loginctrl;
            this.Text = lng.s_UserThatChangesPassword.s + login_control.UserName;
            lbl_New_Password.Text = lng.s_New_Password.s;
            lbl_Confirm_New_Pasword.Text = lng.s_Confirm_New_Password.s;
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
//                    m_LoginDB_DataSet_Procedures.LoginUsers_UserChangeItsOwnPassword(LoginUsers.o_id.id_, LoginControl.CalculateSHA256(txtConfirmPassword.Text), ref Res, ref Err);
                    if (Res.Equals("OK"))
                    {
                        login_control.m_STDLoginData.Time_When_UserSetsItsOwnPassword_LastTime = DateTime.Now;
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
                    MessageBox.Show(lng.s_Password_does_not_match.s);
                }
            }
        }

        private void ChangePasswordForm_Load(object sender, EventArgs e)
        {
  //          m_LoginDB_DataSet_Procedures = new LoginDB_DataSet.LoginDB_DataSet_Procedures(login_control.Login_con);
        }
    }
}
