﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LanguageControl;
using System.Runtime.InteropServices;
using DBConnectionControl40;

namespace LoginControl
{
    internal partial class AWPLoginForm_OneFromMultipleUsers : Form
    {
        internal enum LoginType { LOGIN,LOGOUT};

        private LoginType m_loginType = LoginType.LOGIN;

        internal ID LoginSession_id = null;
        internal ID Atom_WorkPeriod_ID = null;

        internal DataTable dtLoginUsers = null;
        internal AWPLoginData awpld = null;
        internal AWP awp = null;

        LoginCtrl.delegate_Get_Atom_WorkPeriod call_Get_Atom_WorkPeriod = null;

        internal bool LogoutALL
        {
            get
            {
                return chk_LogoutAll.Checked;
            }
        }

        public AWPLoginForm_OneFromMultipleUsers(AWP xawp,
                                                string username,
                                                LoginCtrl.delegate_Get_Atom_WorkPeriod xcall_Get_Atom_WorkPeriod,
                                                bool blogoutall,
                                                LoginType xloginType,
                                                ID xAtom_WorkPeriod_ID)
        {
            InitializeComponent();
            awp = xawp;
            awpld = new AWPLoginData();
            Atom_WorkPeriod_ID = xAtom_WorkPeriod_ID;
            m_loginType = xloginType;
            call_Get_Atom_WorkPeriod = xcall_Get_Atom_WorkPeriod;
            txt_UserName.Text = username;
            if (xloginType == LoginType.LOGIN)
            {
                this.Text = lng.s_Login.s;
                this.btn_OK.Text = lng.s_Login.s;
                chk_LogoutAll.Visible = false;
            }
            else
            {
                if (blogoutall)
                {
                    chk_LogoutAll.Visible = true;
                    lng.s_chk_LogoutAll.Text(chk_LogoutAll);
                }
                else
                {
                    chk_LogoutAll.Visible = false;
                }

                this.Text = lng.s_Logout.s;
                this.btn_OK.Text = lng.s_Logout.s;
            }

            this.btn_Cancel.Text = "";//lng.s_Cancel.s;
            lbl_UserName.Text = lng.s_UserName.s+":";
            lbl_Password.Text = lng.s_Password.s;
            dtLoginUsers = new DataTable();
        }

        private void DoLogin()
        {
            switch (awpld.GetData(ref dtLoginUsers, txt_UserName.Text, awp.awpd))
            {
                case AWPLoginData.eGetDateResult.OK:
                    if (awp.lctrl.PasswordMatch(awpld.Password, txt_Password.Text))
                    {
                        if (awpld.ChangePasswordOnFirstLogin)
                        {
                            AWPChangePasswordForm change_pass_form = new AWPChangePasswordForm(awp.lctrl, awpld, lng.s_AdministratorRequestForNewPassword.s);
                            if (change_pass_form.ShowDialog() == DialogResult.OK)
                            {
                                Login_Start();
                                DialogResult = DialogResult.OK;
                                Close();
                                return;
                            }
                            else
                            {
                                DialogResult = DialogResult.Cancel;
                                Close();
                                return;
                            }
                        }
                        else
                        {
                            if (Login_PasswordExpired(awpld))
                            {
                                if (awpld.NotActiveAfterPasswordExpires)
                                {
                                    AWP_func.DeactivateUserName(awpld.ID);
                                    MessageBox.Show(lng.s_YourUsernameHasExpired.s);
                                }
                                else
                                {
                                    AWPChangePasswordForm change_pass_form = new AWPChangePasswordForm(awp.lctrl, awpld, lng.s_PasswordExpiredSetNewPassword.s);
                                    if (change_pass_form.ShowDialog() == DialogResult.OK)
                                    {
                                        if (AWP_func.Remove_ChangePasswordOnFirstLogin(awpld))
                                        {
                                            // change password dialog
                                            if (Login_Start())
                                            {

                                                DialogResult = DialogResult.OK;
                                                Close();
                                                return;
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                if (m_loginType == AWPLoginForm_OneFromMultipleUsers.LoginType.LOGIN)
                                {
                                    if (Login_Start())
                                    {
                                        DialogResult = DialogResult.OK;
                                        Close();
                                        return;
                                    }
                                }
                                else
                                {
                                    if (LoginControl.LoginCtrl.Logout(this.Atom_WorkPeriod_ID))
                                    {
                                        DialogResult = DialogResult.OK;
                                        Close();
                                        return;
                                    }

                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show(lng.s_Password_does_not_match.s);
                        DialogResult = DialogResult.Cancel;
                        Close();
                    }
                    break;

                case AWPLoginData.eGetDateResult.USER_HAS_NO_RULES:
                    MessageBox.Show(lng.s_UserHasNoAccessRights.s+ txt_UserName.Text+"\r\n"+lng.s_AskAdministratorToSetupYourUserAccessRights.s);
                    DialogResult = DialogResult.Cancel;
                    Close();
                    return;

              }
            }

        private bool Login_PasswordExpired(AWPLoginData awpld)
        {
            if (awpld.Time_When_UserSetsItsOwnPassword_LastTime != DateTime.MinValue)
            {
                DateTime dtnow = DateTime.Now;
                DateTime dtToExpire = awpld.Time_When_UserSetsItsOwnPassword_LastTime.AddDays(awpld.Maximum_password_age_in_days);
                if (dtnow > dtToExpire)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:LoginControl:AWPLoginForm:Login_PasswordExpired:Time_When_UserSetsItsOwnPassword_LastTime not defined!");
                return false;
            }
        }


        private void btn_OK_Click(object sender, EventArgs e)
        {
            DoLogin();
        }

        private bool Login_Start()
        {
            DateTime TimeOnServer = new DateTime();
            if (AWP_func.con.DBType == DBConnectionControl40.DBConnection.eDBType.MSSQL)
            {
                // Get time from server
                //TimeOnServer = m_LoginDB_DataSet_ScalarFunctions.Login_Server_GetDate(ref Err);
                string Err = null;
                if (LoginControl.LoginCtrl.SetThisComputerSystemTime(TimeOnServer, ref Err))
                {
                }
            }
            if (call_Get_Atom_WorkPeriod(awpld.myOrganisation_Person_ID,ref Atom_WorkPeriod_ID))
            {
                if (AWP_func.GetLoginSession(awpld.ID,Atom_WorkPeriod_ID, ref LoginSession_id))
                {
                    if (awp.IsUserManager)
                    {
                        awp.lctrl.btn_UserManager.Visible = true;
                    }
                    awp.lctrl.lbl_username.Text = awp.UserName + ": " + awp.FirstName + " " + awp.LastName;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                 return false;
            }
        }


      


        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void AWPLoginForm_OneFromMultipleUsers_Shown(object sender, EventArgs e)
        {
            txt_Password.Focus();
        }


        private void txt_Password_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                DoLogin();
                e.Handled = true;
            }
        }
    }
}
