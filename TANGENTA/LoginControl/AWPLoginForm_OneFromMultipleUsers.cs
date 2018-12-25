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
        internal LMOUser m_LMOUser = null;

        private bool m_blogoutall = false;

        internal bool LogoutALL
        {
            get
            {
                return chk_LogoutAll.Checked;
            }
        }

        public AWPLoginForm_OneFromMultipleUsers(LMOUser xLMOUser,
                                                bool blogoutall,
                                                LoginType xloginType,
                                                ID xAtom_WorkPeriod_ID)
        {
            InitializeComponent();
            m_LMOUser = xLMOUser;
            m_blogoutall = blogoutall;
            Atom_WorkPeriod_ID = xAtom_WorkPeriod_ID;
            m_loginType = xloginType;
            this.txt_Password.UseSystemPasswordChar = true;
        }

        private void AWPLoginForm_OneFromMultipleUsers_Load(object sender, EventArgs e)
        {
            if (m_LMOUser.awpld==null)
            {
                m_LMOUser.awpld = new AWPLoginData();
            }
            txt_UserName.Text = m_LMOUser.m_UserName;
            m_LMOUser.awpld.GetData(ref dtLoginUsers, txt_UserName.Text, AWP.awpd);

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
            switch (m_LMOUser.awpld.GetData(ref dtLoginUsers, txt_UserName.Text, AWP.awpd))
            {
                case AWPLoginData.eGetDateResult.OK:

                    if (LoginCtrl.PasswordMatch(m_LMOUser.awpld.Password, txt_Password.Text))
                    {
                        if (m_LMOUser.awpld.ChangePasswordOnFirstLogin)
                        {
                            AWPChangePasswordForm change_pass_form = new AWPChangePasswordForm(m_LMOUser,  lng.s_AdministratorRequestForNewPassword.s);
                            if (change_pass_form.ShowDialog() == DialogResult.OK)
                            {

                                Transaction transaction_MultipleUsers_LoginStart = new Transaction("MultipleUsers_LoginStart", DBSync.DBSync.MyTransactionLog_delegates);
                                if (Login_Start(transaction_MultipleUsers_LoginStart))
                                {
                                    if (transaction_MultipleUsers_LoginStart.Commit())
                                    {
                                        DialogResult = DialogResult.OK;
                                        Close();
                                        return;
                                    }
                                    else
                                    {
                                        return;
                                    }
                                }
                                else
                                {
                                    transaction_MultipleUsers_LoginStart.Rollback();
                                    return;
                                }
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
                            if (Login_PasswordExpired(m_LMOUser.awpld))
                            {
                                if (m_LMOUser.NotActiveAfterPasswordExpires)
                                {
                                    Transaction transaction_AWPLoginForm_OneFromMultipleUsers_AWP_func_DeactivateUserName = new Transaction("AWPLoginForm.OneFromMultipleUsers.AWP_func.DeactivateUserName", DBSync.DBSync.MyTransactionLog_delegates);
                                    if (AWP_func.DeactivateUserName(m_LMOUser.awpld.ID, transaction_AWPLoginForm_OneFromMultipleUsers_AWP_func_DeactivateUserName))
                                    {
                                        if (transaction_AWPLoginForm_OneFromMultipleUsers_AWP_func_DeactivateUserName.Commit())
                                        {
                                            XMessage.Box.Show(this, lng.s_YourUsernameHasExpired, MessageBoxIcon.Information);
                                        }
                                    }
                                    else
                                    {
                                        transaction_AWPLoginForm_OneFromMultipleUsers_AWP_func_DeactivateUserName.Rollback();
                                    }
                                }
                                else
                                {
                                    AWPChangePasswordForm change_pass_form = new AWPChangePasswordForm(m_LMOUser, lng.s_PasswordExpiredSetNewPassword.s);
                                    if (change_pass_form.ShowDialog() == DialogResult.OK)
                                    {
                                        Transaction transaction_AWPLoginForm_OneFromMultipleUsers_AWP_func_Remove_ChangePasswordOnFirstLogin = new Transaction("AWPLoginForm.OneFromMultipleUsers.AWP_func.Remove_ChangePasswordOnFirstLogin", DBSync.DBSync.MyTransactionLog_delegates);
                                        if (AWP_func.Remove_ChangePasswordOnFirstLogin(m_LMOUser.awpld, transaction_AWPLoginForm_OneFromMultipleUsers_AWP_func_Remove_ChangePasswordOnFirstLogin))
                                        {
                                            // change password dialog
                                            if (transaction_AWPLoginForm_OneFromMultipleUsers_AWP_func_Remove_ChangePasswordOnFirstLogin.Commit())
                                            {
                                                Transaction transaction_MultipleUsers_LoginStart = new Transaction("MultipleUsers_LoginStart", DBSync.DBSync.MyTransactionLog_delegates);
                                                if (Login_Start(transaction_MultipleUsers_LoginStart))
                                                {

                                                    if (transaction_MultipleUsers_LoginStart.Commit())
                                                    {
                                                        DialogResult = DialogResult.OK;
                                                        Close();
                                                        return;
                                                    }
                                                    else
                                                    {
                                                        return;
                                                    }
                                                }
                                                else
                                                {
                                                    transaction_MultipleUsers_LoginStart.Rollback();
                                                }
                                            }
                                        }
                                        else
                                        {
                                            transaction_AWPLoginForm_OneFromMultipleUsers_AWP_func_Remove_ChangePasswordOnFirstLogin.Rollback();
                                        }
                                    }
                                }
                            }
                            else
                            {
                                if (m_loginType == AWPLoginForm_OneFromMultipleUsers.LoginType.LOGIN)
                                {
                                    Transaction transaction_MultipleUsers_LoginStart = new Transaction("MultipleUsers_LoginStart", DBSync.DBSync.MyTransactionLog_delegates);
                                    if (Login_Start(transaction_MultipleUsers_LoginStart))
                                    {
                                        if (transaction_MultipleUsers_LoginStart.Commit())
                                        {
                                            DialogResult = DialogResult.OK;
                                            Close();
                                            return;
                                        }
                                        else
                                        {
                                            return;
                                        }
                                    }
                                    else
                                    {
                                        transaction_MultipleUsers_LoginStart.Rollback();
                                        return;
                                    }
                                }
                                else
                                {
                                    Transaction transaction_MultipleUsers_Logout = new Transaction("MultipleUsers_Logout", DBSync.DBSync.MyTransactionLog_delegates);
                                    if (LoginControl.LoginCtrl.Logout(this.Atom_WorkPeriod_ID, transaction_MultipleUsers_Logout))
                                    {
                                        if (transaction_MultipleUsers_Logout.Commit())
                                        {
                                            DialogResult = DialogResult.OK;
                                            Close();
                                            return;
                                        }
                                        else
                                        {
                                            return;
                                        }
                                    }
                                    else
                                    {
                                        transaction_MultipleUsers_Logout.Rollback();
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        XMessage.Box.Show(this,lng.s_Password_does_not_match,MessageBoxIcon.Information);
                        DialogResult = DialogResult.Cancel;
                        Close();
                    }
                    break;

                case AWPLoginData.eGetDateResult.USER_HAS_NO_RULES:
                    XMessage.Box.Show(this,lng.s_UserHasNoAccessRights,txt_UserName.Text+"\r\n"+lng.s_AskAdministratorToSetupYourUserAccessRights.s,"",MessageBoxButtons.OK,MessageBoxIcon.Information,MessageBoxDefaultButton.Button1);
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

        private bool Login_Start(Transaction transaction)
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
            if (LoginCtrl.GetWorkPeriodEx(m_LMOUser,
                                        ref Atom_WorkPeriod_ID,
                                        transaction))
            {

                if (AWP_func.GetLoginSession(m_LMOUser.awpld.ID,Atom_WorkPeriod_ID, ref LoginSession_id, transaction))
                {
                    if (m_LMOUser.IsUserManager)
                    {
                        if (m_LMOUser.m_usrc_LMOUser != null)
                        {
                            if (m_LMOUser.m_usrc_LMOUser.lctrl != null)
                            {
                                if (m_LMOUser.m_usrc_LMOUser.lctrl.m_usrc_LoginCtrl != null)
                                {
                                    m_LMOUser.m_usrc_LMOUser.lctrl.m_usrc_LoginCtrl.btn_UserManager.Visible = true;
                                }
                            }
                        }
                    }
                    if (m_LMOUser.m_usrc_LMOUser != null)
                    {
                        if (m_LMOUser.m_usrc_LMOUser.lctrl != null)
                        {
                            if (m_LMOUser.m_usrc_LMOUser.lctrl.m_usrc_LoginCtrl != null)
                            {
                                m_LMOUser.m_usrc_LMOUser.lctrl.m_usrc_LoginCtrl.lbl_username.Text = m_LMOUser.UserName + ": " + m_LMOUser.FirstName + " " + m_LMOUser.LastName;
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

        private void btn_ViewPassword_Click(object sender, EventArgs e)
        {
            this.txt_Password.UseSystemPasswordChar = false;
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.txt_Password.UseSystemPasswordChar = true;
            timer1.Enabled = false;

        }
    }
}
