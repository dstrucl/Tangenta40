using System;
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
        internal ID xAtom_myOrganisation_Person_ID = null;

        internal DataTable dtLoginUsers = null;
        internal LoginOfMyOrgUser m_LoginOfMyOrgUser = null;

        private bool m_blogoutall = false;

        internal bool LogoutALL
        {
            get
            {
                return chk_LogoutAll.Checked;
            }
        }

        public AWPLoginForm_OneFromMultipleUsers(LoginOfMyOrgUser xLoginOfMyOrgUser,
                                                bool blogoutall,
                                                LoginType xloginType,
                                                ID xAtom_WorkPeriod_ID)
        {
            InitializeComponent();
            m_LoginOfMyOrgUser = xLoginOfMyOrgUser;
            m_blogoutall = blogoutall;
            Atom_WorkPeriod_ID = xAtom_WorkPeriod_ID;
            m_loginType = xloginType;
        }

        private void AWPLoginForm_OneFromMultipleUsers_Load(object sender, EventArgs e)
        {
            if (m_LoginOfMyOrgUser.awpld==null)
            {
                m_LoginOfMyOrgUser.awpld = new AWPLoginData();
            }
            txt_UserName.Text = m_LoginOfMyOrgUser.m_UserName;
            m_LoginOfMyOrgUser.awpld.GetData(ref dtLoginUsers, txt_UserName.Text, AWP.awpd);

            if (m_loginType == LoginType.LOGIN)
            {
                this.Text = lng.s_Login.s;
                this.btn_OK.Text = lng.s_Login.s;
                chk_LogoutAll.Visible = false;
            }
            else
            {
                if (m_blogoutall)
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
            lbl_UserName.Text = lng.s_UserName.s + ":";
            lbl_Password.Text = lng.s_Password.s;
            dtLoginUsers = new DataTable();

        }


        private void DoLogin()
        {
            switch (m_LoginOfMyOrgUser.awpld.GetData(ref dtLoginUsers, txt_UserName.Text, AWP.awpd))
            {
                case AWPLoginData.eGetDateResult.OK:
                    if (LoginCtrl.PasswordMatch(m_LoginOfMyOrgUser.awpld.Password, txt_Password.Text))
                    {
                        if (m_LoginOfMyOrgUser.awpld.ChangePasswordOnFirstLogin)
                        {
                            AWPChangePasswordForm change_pass_form = new AWPChangePasswordForm(m_LoginOfMyOrgUser,  lng.s_AdministratorRequestForNewPassword.s);
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
                            if (Login_PasswordExpired(m_LoginOfMyOrgUser.awpld))
                            {
                                if (m_LoginOfMyOrgUser.NotActiveAfterPasswordExpires)
                                {
                                    AWP_func.DeactivateUserName(m_LoginOfMyOrgUser.awpld.ID);
                                    MessageBox.Show(lng.s_YourUsernameHasExpired.s);
                                }
                                else
                                {
                                    AWPChangePasswordForm change_pass_form = new AWPChangePasswordForm(m_LoginOfMyOrgUser, lng.s_PasswordExpiredSetNewPassword.s);
                                    if (change_pass_form.ShowDialog() == DialogResult.OK)
                                    {
                                        if (AWP_func.Remove_ChangePasswordOnFirstLogin(m_LoginOfMyOrgUser.awpld))
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
            if (LoginCtrl.getWorkPeriod(m_LoginOfMyOrgUser.awpld.myOrganisation_Person_ID,ref m_LoginOfMyOrgUser.Atom_myOrganisation_Person_ID, ref Atom_WorkPeriod_ID))
            {
                if (AWP_func.GetLoginSession(m_LoginOfMyOrgUser.awpld.ID,Atom_WorkPeriod_ID, ref LoginSession_id))
                {
                    if (m_LoginOfMyOrgUser.IsUserManager)
                    {
                        if (m_LoginOfMyOrgUser.m_usrc_LoginOfMyOrgUser != null)
                        {
                            if (m_LoginOfMyOrgUser.m_usrc_LoginOfMyOrgUser.lctrl != null)
                            {
                                if (m_LoginOfMyOrgUser.m_usrc_LoginOfMyOrgUser.lctrl.m_usrc_LoginCtrl != null)
                                {
                                    m_LoginOfMyOrgUser.m_usrc_LoginOfMyOrgUser.lctrl.m_usrc_LoginCtrl.btn_UserManager.Visible = true;
                                }
                            }
                        }
                    }
                    if (m_LoginOfMyOrgUser.m_usrc_LoginOfMyOrgUser != null)
                    {
                        if (m_LoginOfMyOrgUser.m_usrc_LoginOfMyOrgUser.lctrl != null)
                        {
                            if (m_LoginOfMyOrgUser.m_usrc_LoginOfMyOrgUser.lctrl.m_usrc_LoginCtrl != null)
                            {
                                m_LoginOfMyOrgUser.m_usrc_LoginOfMyOrgUser.lctrl.m_usrc_LoginCtrl.lbl_username.Text = m_LoginOfMyOrgUser.UserName + ": " + m_LoginOfMyOrgUser.FirstName + " " + m_LoginOfMyOrgUser.LastName;
                            }
                        }
                    }
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
