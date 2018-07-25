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
        internal int_v PIN_v = null;
        private string m_UserName = null;
        private ID LoginUsers_ID = null;
        private ID LoginSession_ID = null;
        private ID Atom_WorkPeriod_ID = null;
        private List<AWPRole> m_AWP_UserRoles = new List<AWPRole>();
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

        private bool IsAdministrator
        {
            get
            {
                if (m_AWP_UserRoles!=null)
                {
                    foreach (AWPRole r in m_AWP_UserRoles)
                    {
                        if (r.Role.Equals(AWP.ROLE_Administrator))
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
        }

        private bool IsUserManager
        {
            get
            {
                if (m_AWP_UserRoles != null)
                {
                    foreach (AWPRole r in m_AWP_UserRoles)
                    {
                        if (r.Role.Equals(AWP.ROLE_UserManagement))
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
        }

        internal void SetData(DataRow dr)
        {
            m_UserName = tf._set_string(dr["UserName"]);
            LoginUsers_ID = tf.set_ID(dr["ID"]);
            if (AWP_func.AWPRoles_GetUserRoles(LoginUsers_ID, ref m_AWP_UserRoles))
            {
                if (IsAdministrator)
                {
                    pic_administrator.Image = Properties.Resources.Login.ToBitmap();
                    pic_administrator.Visible = true;
                }
                else
                {
                    pic_administrator.Visible = false;
                }

                if (IsUserManager)
                {
                    pic_UserManager.Image = Properties.Resources.RoleManager.ToBitmap();
                    pic_UserManager.Visible = true;
                }
                else
                {
                    pic_UserManager.Visible = false;
                }
            }
            
            byte_array_v imagebytes_v = tf.set_byte_array(dr["PersonData_$_perimg_$$Image_Data"]);
            PIN_v = tf.set_int(dr["PersonData_$$PIN"]);
            if (imagebytes_v!=null)
            {
                this.pictureBox1.Image = DBTypes.func.byteArrayToImage(imagebytes_v.v);
            }
            else
            {

            }
            this.lbl_User.Text = m_UserName;
            LoginSession_ID = null;
            LoggedIn = AWP_func.IsUserLoggedIn(LoginUsers_ID, ref LoginSession_ID);
            
        }


        private bool Authentificate_PASSWORD()
        {
            AWPLoginForm_OneFromMultipleUsers awpLoginForm_OneFromMultipleUsers = new AWPLoginForm_OneFromMultipleUsers(m_awp, m_UserName, m_call_Get_Atom_WorkPeriod, false, AWPLoginForm_OneFromMultipleUsers.LoginType.LOGIN, this.Atom_WorkPeriod_ID);
            if (awpLoginForm_OneFromMultipleUsers.ShowDialog(this) == DialogResult.OK)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        private bool Authentificate_PIN()
        {
            AWPLoginForm_AuthentificatePIN awpLoginForm__AuthentificatePIN = new AWPLoginForm_AuthentificatePIN(m_awp, m_UserName, PIN_v);
            if (awpLoginForm__AuthentificatePIN.ShowDialog(this) == DialogResult.OK)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void btn_LoginLogout_Click(object sender, EventArgs e)
        {
            if (LoggedIn)
            {
                bool bLogoutAll = (IsAdministrator || IsUserManager);
                if (bLogoutAll)
                {
                    if (m_usrc_MultipleUsers.LoggedIn_Count() == 1)
                    {
                        bLogoutAll = false;
                    }
                }

                AWPLoginForm_OneFromMultipleUsers awpLoginForm_OneFromMultipleUsers = new AWPLoginForm_OneFromMultipleUsers(m_awp, m_UserName, m_call_Get_Atom_WorkPeriod, bLogoutAll, AWPLoginForm_OneFromMultipleUsers.LoginType.LOGOUT, this.Atom_WorkPeriod_ID);
                if (awpLoginForm_OneFromMultipleUsers.ShowDialog(this) == DialogResult.OK)
                {
                    if (awpLoginForm_OneFromMultipleUsers.LogoutALL)
                    {
                        this.m_usrc_MultipleUsers.LogoutAll();
                    }
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
                AWPLoginForm_OneFromMultipleUsers awpLoginForm_OneFromMultipleUsers = new AWPLoginForm_OneFromMultipleUsers(m_awp, m_UserName, m_call_Get_Atom_WorkPeriod, false, AWPLoginForm_OneFromMultipleUsers.LoginType.LOGIN,null);
                if (awpLoginForm_OneFromMultipleUsers.ShowDialog(this) == DialogResult.OK)
                {
                    this.awpld = awpLoginForm_OneFromMultipleUsers.awpld;
                    this.LoginSession_ID = awpLoginForm_OneFromMultipleUsers.LoginSession_id;
                    this.Atom_WorkPeriod_ID = awpLoginForm_OneFromMultipleUsers.Atom_WorkPeriod_ID;
                    LoggedIn = true;
                }
            }
        }

        internal void DoLogout()
        {
            if (LoginControl.LoginCtrl.Logout(this.Atom_WorkPeriod_ID))
            {
                LoggedIn = false;
            }
        }

        private void btn_GetAccess_Click(object sender, EventArgs e)
        {
            switch (m_awp.lctrl.AuthentificationType)
            {
                case LoginCtrl.eAuthentificationType.PASSWORD:
                    if (!Authentificate_PASSWORD())
                    {
                        MessageBox.Show(lng.s_Password_does_not_match.s);
                        return;
                    }
                    break;

                case LoginCtrl.eAuthentificationType.PIN:
                    if (!Authentificate_PIN())
                    {
                        return;
                    }
                    break;

            }
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
