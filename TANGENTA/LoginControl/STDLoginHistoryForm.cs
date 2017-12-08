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
    public partial class STDLoginHistoryForm : Form
    {
        LoginDB_DataSet.LoginSession_VIEW m_LoginSession_VIEW_active = null;
        LoginDB_DataSet.LoginSession_VIEW m_LoginSession_VIEW_notactive = null;
        STD std = null;
        int LoginUsers_id;
        public STDLoginHistoryForm(STD xstd, int Users_id, string UserName)
        {
            InitializeComponent();
            std = xstd;
            LoginUsers_id = Users_id;
            this.lbl_ActiveUsers.Text = lng.s_ActiveUsers.s;
            this.lbl_LoginHistory.Text = lng.s_LoginHistoryForUser.s + UserName;
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void LoginHistoryForm_Load(object sender, EventArgs e)
        {
            string Err = null;
            m_LoginSession_VIEW_active = new LoginDB_DataSet.LoginSession_VIEW(std.Login_con);
            m_LoginSession_VIEW_active.Clear();
            m_LoginSession_VIEW_active.select.all(false);
            m_LoginSession_VIEW_active.select.username = true;
            m_LoginSession_VIEW_active.select.first_name = true;
            m_LoginSession_VIEW_active.select.last_name = true;
            m_LoginSession_VIEW_active.select.Identity = true;
            m_LoginSession_VIEW_active.select.Contact = true;
            m_LoginSession_VIEW_active.select.Login_time = true;
            m_LoginSession_VIEW_active.select.Logout_time = true;
            m_LoginSession_VIEW_active.where.all(false);
            m_LoginSession_VIEW_active.where.Logout_time = true;
            m_LoginSession_VIEW_active.where.Logout_time_Expression(" is null");
            m_LoginSession_VIEW_active.order = " order by " + LoginDB_DataSet.LoginSession_VIEW.Login_time.name + " desc";
            
            if (m_LoginSession_VIEW_active.Read(ref Err))
            {
                dgv_ActiveUsers.DataSource = m_LoginSession_VIEW_active.m_bs_dt;
                dgv_ActiveUsers.Columns[LoginDB_DataSet.LoginSession_VIEW.username.name].HeaderText = lng.s_UserName.s;
                dgv_ActiveUsers.Columns[LoginDB_DataSet.LoginSession_VIEW.first_name.name].HeaderText = lng.s_FirstName.s;
                dgv_ActiveUsers.Columns[LoginDB_DataSet.LoginSession_VIEW.last_name.name].HeaderText = lng.s_LastName.s;
                dgv_ActiveUsers.Columns[LoginDB_DataSet.LoginSession_VIEW.Identity.name].HeaderText = lng.s_IdentityNumber.s;
                dgv_ActiveUsers.Columns[LoginDB_DataSet.LoginSession_VIEW.Contact.name].HeaderText = lng.s_Contact.s;
                dgv_ActiveUsers.Columns[LoginDB_DataSet.LoginSession_VIEW.Login_time.name].HeaderText = lng.s_LoginTime.s;
                dgv_ActiveUsers.Columns[LoginDB_DataSet.LoginSession_VIEW.Logout_time.name].HeaderText = lng.s_LogoutTime.s;

                m_LoginSession_VIEW_notactive = new LoginDB_DataSet.LoginSession_VIEW(std.Login_con);
                m_LoginSession_VIEW_notactive.Clear();
                m_LoginSession_VIEW_notactive.select.all(false);
                m_LoginSession_VIEW_notactive.select.username = true;
                m_LoginSession_VIEW_notactive.select.first_name = true;
                m_LoginSession_VIEW_notactive.select.last_name = true;
                m_LoginSession_VIEW_notactive.select.Identity = true;
                m_LoginSession_VIEW_notactive.select.Contact = true;
                m_LoginSession_VIEW_notactive.select.Login_time = true;
                m_LoginSession_VIEW_notactive.select.Logout_time = true;
                m_LoginSession_VIEW_notactive.where.all(false);
                m_LoginSession_VIEW_notactive.where.LoginUsers_id = true;
                m_LoginSession_VIEW_notactive.where.LoginUsers_id_Expression(" = " + LoginUsers_id.ToString());
                m_LoginSession_VIEW_notactive.where.Logout_time = true;
                m_LoginSession_VIEW_notactive.where.Logout_time_Expression(" is not null");
                m_LoginSession_VIEW_notactive.order = " order by " + LoginDB_DataSet.LoginSession_VIEW.Logout_time.name + " desc";
                if (m_LoginSession_VIEW_notactive.Read(ref Err))
                {
                    dgv_LoginHistory.DataSource = m_LoginSession_VIEW_notactive.m_bs_dt;
                    dgv_LoginHistory.Columns[LoginDB_DataSet.LoginSession_VIEW.username.name].HeaderText = lng.s_UserName.s;
                    dgv_LoginHistory.Columns[LoginDB_DataSet.LoginSession_VIEW.first_name.name].HeaderText = lng.s_FirstName.s;
                    dgv_LoginHistory.Columns[LoginDB_DataSet.LoginSession_VIEW.last_name.name].HeaderText = lng.s_LastName.s;
                    dgv_LoginHistory.Columns[LoginDB_DataSet.LoginSession_VIEW.Identity.name].HeaderText = lng.s_IdentityNumber.s;
                    dgv_LoginHistory.Columns[LoginDB_DataSet.LoginSession_VIEW.Contact.name].HeaderText = lng.s_Contact.s;
                    dgv_LoginHistory.Columns[LoginDB_DataSet.LoginSession_VIEW.Login_time.name].HeaderText = lng.s_LoginTime.s;
                    dgv_LoginHistory.Columns[LoginDB_DataSet.LoginSession_VIEW.Logout_time.name].HeaderText = lng.s_LogoutTime.s;
                }
                else
                {
                    LogFile.Error.Show("Error:LoginHistoryForm:m_LoginSession_VIEW_notactive.Read:Err=" + Err);
                    DialogResult = DialogResult.Abort;
                    this.Close();
                }
            }
            else
            {
                LogFile.Error.Show("Error:LoginHistoryForm:m_LoginSession_VIEW_active.Read:Err=" + Err);
                DialogResult = DialogResult.Abort;
                this.Close();
            }
        }
    }
}
