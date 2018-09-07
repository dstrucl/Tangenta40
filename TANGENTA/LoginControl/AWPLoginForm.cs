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
    public partial class AWPLoginForm : Form
    {

        internal DataTable dtLoginUsers = null;
        LMOUser m_LMOUser = null;
        AWP awp = null;

        public AWPLoginForm(AWP xawp)
        {
            InitializeComponent();
            awp = xawp;
            m_LMOUser = awp.LMO1User;
            cmbR_UserName.RecentItemsFolder = awp.lctrl.RecentItemsFolder;
            this.Text = lng.s_Login.s;
            this.btn_OK.Text = lng.s_Login.s;
            this.btn_Cancel.Text = lng.s_Cancel.s;
            lbl_UserName.Text = lng.s_UserName.s;
            lbl_Password.Text = lng.s_Password.s;
            dtLoginUsers = new DataTable();
            this.txt_Password.UseSystemPasswordChar = true;
        }

        private void DoLogin()
        {
            this.cmbR_UserName.Set(this.cmbR_UserName.Text);
            switch (m_LMOUser.awpld.GetData(ref dtLoginUsers,cmbR_UserName.Text, AWP.awpd))
            {
                case AWPLoginData.eGetDateResult.OK:
                    if (LoginCtrl.PasswordMatch(m_LMOUser.awpld.Password, txt_Password.Text))
                    {
                        if (m_LMOUser.awpld.ChangePasswordOnFirstLogin)
                        {
                            AWPChangePasswordForm change_pass_form = new AWPChangePasswordForm(m_LMOUser, lng.s_AdministratorRequestForNewPassword.s);
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
                            if (Login_PasswordExpired(m_LMOUser.awpld))
                            {
                                if (m_LMOUser.awpld.NotActiveAfterPasswordExpires)
                                {
                                    AWP_func.DeactivateUserName(m_LMOUser.awpld.ID);
                                    XMessage.Box.Show(this,lng.s_YourUsernameHasExpired,MessageBoxIcon.Information);
                                }
                                else
                                {
                                    AWPChangePasswordForm change_pass_form = new AWPChangePasswordForm(m_LMOUser, lng.s_PasswordExpiredSetNewPassword.s);
                                    if (change_pass_form.ShowDialog() == DialogResult.OK)
                                    {
                                        if (AWP_func.Remove_ChangePasswordOnFirstLogin(m_LMOUser.awpld))
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
                                if (Login_Start())
                                {
                                    DialogResult = DialogResult.OK;
                                    Close();
                                    return;
                                }
                            }
                        }
                    }
                    else
                    {
                        XMessage.Box.Show(this,lng.s_Password_does_not_match,MessageBoxIcon.Information);
                    }
                    break;

                case AWPLoginData.eGetDateResult.USER_HAS_NO_RULES:
                    XMessage.Box.Show(this,lng.s_UserHasNoAccessRights, cmbR_UserName.Text+"\r\n"+lng.s_AskAdministratorToSetupYourUserAccessRights.s,"",MessageBoxButtons.OK,MessageBoxIcon.Information,MessageBoxDefaultButton.Button1);
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
                if (SetThisComputerSystemTime(TimeOnServer, ref Err))
                {
                }
            }
            ID Atom_WorkPeriod_ID = null;
            if (LoginCtrl.getWorkPeriodEx(m_LMOUser,ref Atom_WorkPeriod_ID))
            {
                    ID LoginSession_id = null;
                    if (AWP_func.GetLoginSession(m_LMOUser.awpld.ID,Atom_WorkPeriod_ID, ref LoginSession_id))
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
                        return false;
            }
        }

        public struct SystemTime
        {
            public ushort Year;
            public ushort Month;
            public ushort DayOfWeek;
            public ushort Day;
            public ushort Hour;
            public ushort Minute;
            public ushort Second;
            public ushort Millisecond;
        };

        [DllImport("kernel32.dll", EntryPoint = "SetSystemTime", SetLastError = true)]
        public extern static bool Win32SetSystemTime(ref SystemTime sysTime);

        private bool SetThisComputerSystemTime(DateTime TimeOnServer, ref string Err)
        {
            try
            {
                SystemTime updatedTime = new SystemTime();
                updatedTime.Year = Convert.ToUInt16(TimeOnServer.Year);
                updatedTime.Month = Convert.ToUInt16(TimeOnServer.Month);
                updatedTime.Day = Convert.ToUInt16(TimeOnServer.Day);
                updatedTime.Hour = Convert.ToUInt16(TimeOnServer.Hour);
                updatedTime.Minute = Convert.ToUInt16(TimeOnServer.Minute);
                updatedTime.Second = Convert.ToUInt16(TimeOnServer.Second);
                updatedTime.Millisecond = Convert.ToUInt16(TimeOnServer.Millisecond);
                // Call the unmanaged function that sets the new date and time instantly
                Win32SetSystemTime(ref updatedTime);
                return true;
            }
            catch (Exception ex)
            {
                Err = ex.Message;
                return false;
            }
        }


        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void LoginForm_Shown(object sender, EventArgs e)
        {
            if (this.cmbR_UserName.Text.Length > 0)
            {
                txt_Password.Focus();
            }
            else
            {
                cmbR_UserName.Focus();
            }
        }

        private void cmbR_UserName_EnterPressed(object sender)
        {
            ComboBox_Recent.ComboBox_RecentList cmbR = (ComboBox_Recent.ComboBox_RecentList)sender;
            if (cmbR.Text.Length > 0)
            {
                txt_Password.Focus();
            }
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
