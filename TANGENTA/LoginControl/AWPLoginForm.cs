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

namespace LoginControl
{
    public partial class AWPLoginForm : Form
    {

        internal DataTable dtLoginUsers = null;
        AWPLoginData awpld = null;
        AWP awp = null;
        LoginControl.delegate_Get_Atom_WorkPeriod call_Get_Atom_WorkPeriod = null;

        public AWPLoginForm(AWP xawp, LoginControl.delegate_Get_Atom_WorkPeriod xcall_Get_Atom_WorkPeriod)
        {
            InitializeComponent();
            awp = xawp;
            awpld = awp.m_AWPLoginData;
            call_Get_Atom_WorkPeriod = xcall_Get_Atom_WorkPeriod;
            cmbR_UserName.RecentItemsFolder = awp.lctrl.RecentItemsFolder;
            this.Text = lng.s_Login.s;
            this.btn_OK.Text = lng.s_OK.s;
            this.btn_Cancel.Text = lng.s_Cancel.s;
            lbl_UserName.Text = lng.s_UserName.s;
            lbl_Password.Text = lng.s_Password.s;
            dtLoginUsers = new DataTable();
        }

        private void DoLogin()
        {
            this.cmbR_UserName.Set(this.cmbR_UserName.Text);
            switch (awpld.GetData(ref dtLoginUsers,cmbR_UserName.Text, awp.awpd))
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
                        MessageBox.Show(lng.s_Password_does_not_match.s);
                    }
                    break;

                case AWPLoginData.eGetDateResult.USER_HAS_NO_RULES:
                    MessageBox.Show(lng.s_UserHasNoAccessRights.s+ cmbR_UserName.Text+"\r\n"+lng.s_AskAdministratorToSetupYourUserAccessRights.s);
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
            long Atom_WorkPeriod_ID = -1;
            if (call_Get_Atom_WorkPeriod(awpld.myOrganisation_Person_ID,ref Atom_WorkPeriod_ID))
            {
                    long LoginSession_id = -1;
                    if (AWP_func.GetLoginSession(awpld.ID,Atom_WorkPeriod_ID, ref LoginSession_id))
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
    }
}
