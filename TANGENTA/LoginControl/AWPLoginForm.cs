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
        LoginControl login_control = null;
        DataTable dtLoginUsers = null;
        //LoginDB_DataSet.LoginUsers LoginUsers = null;
        //LoginDB_DataSet.LoginDB_DataSet_Procedures m_LoginDB_DataSet_Procedures = null;
        //LoginDB_DataSet.LoginDB_DataSet_ScalarFunctions m_LoginDB_DataSet_ScalarFunctions = null;
        public AWPLoginForm(LoginControl logctrl)
        {
            InitializeComponent();
            login_control = logctrl;
            cmbR_UserName.RecentItemsFolder = login_control.RecentItemsFolder;
            this.Text = lng.s_Login.s;
            this.btn_OK.Text = lng.s_OK.s;
            this.btn_Cancel.Text = lng.s_Cancel.s;
            lbl_UserName.Text = lng.s_UserName.s;
            lbl_Password.Text = lng.s_Password.s;
        }

        private void DoLogin()
        {
            string Err = null;
            this.cmbR_UserName.Set(this.cmbR_UserName.Text);
            //LoginUsers.Clear();
            //LoginUsers.select.all(false);
            //LoginUsers.select.id = true;
            //LoginUsers.select.username = true;
            //LoginUsers.select.first_name = true;
            //LoginUsers.select.last_name = true;
            //LoginUsers.select.Identity = true;
            //LoginUsers.select.Contact = true;
            //LoginUsers.select.password = true;
            //LoginUsers.select.PasswordNeverExpires = true;
            //LoginUsers.select.ChangePasswordOnFirstLogin = true;
            //LoginUsers.select.Maximum_password_age_in_days = true;
            //LoginUsers.select.Time_When_UserSetsItsOwnPassword_LastTime = true;
            //LoginUsers.select.enabled = true;
            //LoginUsers.select.NotActiveAfterPasswordExpires = true;
            //LoginUsers.select.PasswordNeverExpires = true;
            //LoginUsers.where.all(false);
            //LoginUsers.where.username = true;
            //LoginUsers.where.username_Expression(" = '" + cmbR_UserName.Text + "'");
            if (AWP_func.Read_Login_VIEW(ref dtLoginUsers, "where myOrganisation_Person_$$UserName = '" + cmbR_UserName.Text + "'", ref Err))
            {
                if (dtLoginUsers.Rows.Count > 0)
                {
                    DataRow dr = dtLoginUsers.Rows[0];
                    long LoginUsers_ID = (long)dr["ID"];
                    byte[] passw = (byte[])dr["myOrganisation_Person_$$Password"];
                    bool bNotActiveAfterPasswordExpires = (bool)dtLoginUsers.Rows[0]["NotActiveAfterPasswordExpires"];

                    if (login_control.PasswordMatch(passw, txt_Password.Text))
                    {
                        bool bChangePasswordOnFirstLogin = (bool)dtLoginUsers.Rows[0]["ChangePasswordOnFirstLogin"];
                        if (bChangePasswordOnFirstLogin)
                        {
                            if (Login_Start(dr))
                            {
                                AWPChangePasswordForm change_pass_form = new AWPChangePasswordForm(login_control, dr, lng.s_AdministratorRequestForNewPassword.s);
                                if (change_pass_form.ShowDialog() == DialogResult.OK)
                                {
                                    string sql_change_enabled = "UPDATE " + LoginDB_DataSet.LoginUsers.tablename_const + " SET ChangePasswordOnFirstLogin = 0 where id = " + LoginUsers_ID.ToString();
                                    object res = null;
                                    if (login_control.Login_con.ExecuteNonQuerySQL(sql_change_enabled, null, ref res, ref Err))
                                    {
                                        DialogResult = DialogResult.OK;
                                        Close();
                                        return;
                                    }
                                    else
                                    {
                                        LogFile.Error.Show("Error:LoginForm:" + sql_change_enabled + ":Err=" + Err);
                                    }
                                }
                            }

                        }
                        else
                        {
                            if (Login_PasswordExpired(dr, ref Err))
                            {
                                if (bNotActiveAfterPasswordExpires)
                                {
                                    string sql_change_enabled = "UPDATE LoginUsers SET enabled = 0 where id = " + LoginUsers_ID.ToString();
                                    object res = null;
                                    if (!login_control.Login_con.ExecuteNonQuerySQL(sql_change_enabled, null, ref res, ref Err))
                                    {
                                        LogFile.Error.Show("Error:LoginForm:" + sql_change_enabled + ":Err=" + Err);
                                    }
                                    MessageBox.Show(lng.s_YourUsernameHasExpired.s);

                                }
                                else
                                {
                                    // change password dialog
                                    if (Login_Start(dr))
                                    {
                                        AWPChangePasswordForm change_pass_form = new AWPChangePasswordForm(login_control, dr, lng.s_PasswordExpiredSetNewPassword.s);
                                        if (change_pass_form.ShowDialog() == DialogResult.OK)
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
                                if (Login_Start(dr))
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
                }
                else
                {
                    LogFile.Error.Show("Error:LoginForm_Load:LoginUsers.Read:Err=" + Err);
                }
            }
        }

        private bool Login_PasswordExpired(DataRow dr, ref string err)
        {
            throw new NotImplementedException();
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            DoLogin();
        }

        private bool Login_Start(DataRow dr)
        {
            string Err = null;
            string Res = null;
            if (login_control.AWPLoginData_Get(dr, ref Err))
            {
                DateTime TimeOnServer = new DateTime();
                Err= null;
                //TimeOnServer = m_LoginDB_DataSet_ScalarFunctions.Login_Server_GetDate(ref Err);
                if (Err==null)
                {
                    if (SetThisComputerSystemTime(TimeOnServer,ref Err))
                    {
                        int LoginSession_id = -1;
                        //m_LoginDB_DataSet_Procedures.LoginSession_Start(LoginUsers.o_id.id_, System.Environment.MachineName, System.Environment.UserName,
                        //                                                ref LoginSession_id, ref Res, ref Err);
                        if (Res.Equals("OK"))
                        {
                            login_control.m_STDLoginData.m_LoginSession_id = LoginSession_id;
                            return true;
                        }
                        else
                        {
                            if (Res == null) Res = "null";
                            LogFile.Error.Show("Error:LoginForm:m_LoginDB_DataSet_Procedures.LoginSession_Start:Result=" + Res + ", Err=" + Err);
                        }
                    }
                    else
                    {
                        LogFile.Error.Show("Error:LoginForm:Login_Start:.SetThisComputerSystemTime: Err=" + Err);
                    }
                }
                else
                {
                    LogFile.Error.Show("Error:LoginForm:m_LoginDB_DataSet_ScalarFunctions.Login_Server_GetDate: Err=" + Err);
                }
            }
            else
            {
                LogFile.Error.Show("Error:LoginForm:LoginData_Get: Err=" + Err);
            }
            return false;
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

        private void LoginForm_Load(object sender, EventArgs e)
        {

            //LoginUsers = new LoginDB_DataSet.LoginUsers(login_control.Login_con);
            //m_LoginDB_DataSet_Procedures = new LoginDB_DataSet.LoginDB_DataSet_Procedures(login_control.Login_con);
            //m_LoginDB_DataSet_ScalarFunctions = new LoginDB_DataSet.LoginDB_DataSet_ScalarFunctions(login_control.Login_con);
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
