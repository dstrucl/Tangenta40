using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DBTypes;
using DBConnectionControl40;

namespace LoginControl
{
    public partial class usrc_LoginOfMyOrgUser : UserControl
    {
        internal AWP m_awp = null;
        internal AWPLoginData awpld = null;
        internal usrc_MultipleUsers m_usrc_MultipleUsers = null;
        internal LoginCtrl.delegate_Get_Atom_WorkPeriod m_call_Get_Atom_WorkPeriod = null;
        internal LoginCtrl.delegate_Activate_usrc_DocumentMan m_call_Activate_usrc_DocumentMan = null;
        private string m_UserName = null;
        private ID LoginUsers_ID = null;
        private ID LoginSession_ID = null;
        private ID Atom_WorkPeriod_ID = null;

        private bool m_LoggedIn = false;

        internal bool LoggedIn
        {
            get
            {
                return m_LoggedIn;
            }
            set
            {
                m_LoggedIn = value;
                if (m_LoggedIn)
                {
                    lng.s_Logout.Text(btn_LoginLogout);
                    btn_LoginLogout.BackColor = ColorSettings.Sheme.Current().Colorpair[4].BackColor;
                    this.btn_GetAccess.Visible = true;
                }
                else
                {
                    lng.s_Login.Text(btn_LoginLogout);
                    btn_LoginLogout.BackColor = ColorSettings.Sheme.Current().Colorpair[0].BackColor;
                    this.btn_GetAccess.Visible = false;
                }
            }
        }


        public usrc_LoginOfMyOrgUser()
        {
            InitializeComponent();
            lng.s_btn_GetAccess.Text(btn_GetAccess);
        }

        private void RePaint()
        {

        }

        internal void DoPaint(DataRow dr, string[] s_name_Group, object xobj)
        {
            RePaint();
        }

        internal void SetData(DataRow dr)
        {
            m_UserName = tf._set_string(dr["UserName"]);
            LoginUsers_ID = tf.set_ID(dr["ID"]);
            this.lbl_User.Text = m_UserName;
            LoginSession_ID = null;
            LoggedIn = AWP_func.IsUserLoggedIn(LoginUsers_ID, ref LoginSession_ID);
        }

        private void btn_LoginLogout_Click(object sender, EventArgs e)
        {
            if (LoggedIn)
            {
                AWPLoginForm_OneFromMultipleUsers awpLoginForm_OneFromMultipleUsers = new AWPLoginForm_OneFromMultipleUsers(m_awp, m_UserName, m_call_Get_Atom_WorkPeriod, AWPLoginForm_OneFromMultipleUsers.LoginType.LOGOUT,this.Atom_WorkPeriod_ID);
                if (awpLoginForm_OneFromMultipleUsers.ShowDialog(this) == DialogResult.OK)
                {
                    this.LoginSession_ID = awpLoginForm_OneFromMultipleUsers.LoginSession_id;
                    this.Atom_WorkPeriod_ID = null;
                    this.awpld = null;
                    LoggedIn = false;

                }
            }
            else
            {
                this.LoginSession_ID = null;
                this.Atom_WorkPeriod_ID = null;
                this.awpld = null;
                AWPLoginForm_OneFromMultipleUsers awpLoginForm_OneFromMultipleUsers = new AWPLoginForm_OneFromMultipleUsers(m_awp, m_UserName, m_call_Get_Atom_WorkPeriod, AWPLoginForm_OneFromMultipleUsers.LoginType.LOGIN,null);
                if (awpLoginForm_OneFromMultipleUsers.ShowDialog(this) == DialogResult.OK)
                {
                    this.awpld = awpLoginForm_OneFromMultipleUsers.awpld;
                    this.LoginSession_ID = awpLoginForm_OneFromMultipleUsers.LoginSession_id;
                    this.Atom_WorkPeriod_ID = awpLoginForm_OneFromMultipleUsers.Atom_WorkPeriod_ID;
                    LoggedIn = true;
                }
            }
        }

        private void btn_GetAccess_Click(object sender, EventArgs e)
        {
            TangentaDB.GlobalData.Atom_WorkPeriod_ID = this.Atom_WorkPeriod_ID;
            m_awp.m_AWPLoginData = awpld;
            if (m_awp.IsUserManager)
            {
                m_awp.lctrl.btn_UserManager.Visible = true;
            }
            m_awp.lctrl.lbl_username.Text = m_awp.UserName + ": " + m_awp.FirstName + " " + m_awp.LastName;
            m_call_Activate_usrc_DocumentMan(m_usrc_MultipleUsers);
            
        }
    }
}
