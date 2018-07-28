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
using TangentaDB;

namespace LoginControl
{
    public partial class usrc_LoginOfMyOrgUser : UserControl
    {
        internal usrc_MultipleUsers m_usrc_MultipleUsers = null;

        internal LoginCtrl lctrl = null;

        internal LoginOfMyOrgUser m_LoginOfMyOrgUser = null;

        public usrc_LoginOfMyOrgUser(LoginCtrl xlxtrl)
        {
            InitializeComponent();
            lctrl = xlxtrl;
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
                if (m_LoginOfMyOrgUser.awpld != null)
                {
                    return m_LoginOfMyOrgUser.IsAdministrator;
                }
                return false;
            }
        }

        private bool IsUserManager
        {
            get
            {
                if (m_LoginOfMyOrgUser.awpld != null)
                {
                    return m_LoginOfMyOrgUser.IsUserManager;
                }
                return false;
            }
        }

        internal void SetData(DataRow dr)
        {
            if (m_LoginOfMyOrgUser==null)
            {
                m_LoginOfMyOrgUser = new LoginOfMyOrgUser(this);
            }
            m_LoginOfMyOrgUser.SetData(dr);

        }


        private bool Authentificate_PASSWORD()
        {
            AWPLoginForm_OneFromMultipleUsers awpLoginForm_OneFromMultipleUsers = new AWPLoginForm_OneFromMultipleUsers(m_LoginOfMyOrgUser,  false, AWPLoginForm_OneFromMultipleUsers.LoginType.LOGIN, m_LoginOfMyOrgUser.Atom_WorkPeriod_ID);
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
            AWPLoginForm_AuthentificatePIN awpLoginForm__AuthentificatePIN = new AWPLoginForm_AuthentificatePIN(m_LoginOfMyOrgUser);
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
            if (this.m_LoginOfMyOrgUser.LoggedIn)
            {
                bool bLogoutAll = (IsAdministrator || IsUserManager);
                if (bLogoutAll)
                {
                    if (m_usrc_MultipleUsers.LoggedIn_Count() == 1)
                    {
                        bLogoutAll = false;
                    }
                }

                AWPLoginForm_OneFromMultipleUsers awpLoginForm_OneFromMultipleUsers = new AWPLoginForm_OneFromMultipleUsers(m_LoginOfMyOrgUser,  bLogoutAll, AWPLoginForm_OneFromMultipleUsers.LoginType.LOGOUT, m_LoginOfMyOrgUser.Atom_WorkPeriod_ID);
                if (awpLoginForm_OneFromMultipleUsers.ShowDialog(this) == DialogResult.OK)
                {
                    if (awpLoginForm_OneFromMultipleUsers.LogoutALL)
                    {
                        this.m_usrc_MultipleUsers.LogoutAll();
                    }
                    else
                    {
                        lctrl.Trigger_EventUserLoggedOut(this.m_LoginOfMyOrgUser);
                    }
                    m_LoginOfMyOrgUser.LoginSession_ID = awpLoginForm_OneFromMultipleUsers.LoginSession_id;
                    m_LoginOfMyOrgUser.Atom_WorkPeriod_ID = null;
                    m_LoginOfMyOrgUser.awpld = null;
                    m_LoginOfMyOrgUser.LoggedIn = false;
                }
            }
            else
            {
                m_LoginOfMyOrgUser.LoginSession_ID = null;
                m_LoginOfMyOrgUser.Atom_WorkPeriod_ID = null;
                m_LoginOfMyOrgUser.awpld = null;
                AWPLoginForm_OneFromMultipleUsers awpLoginForm_OneFromMultipleUsers = new AWPLoginForm_OneFromMultipleUsers(m_LoginOfMyOrgUser,  false, AWPLoginForm_OneFromMultipleUsers.LoginType.LOGIN,null);
                if (awpLoginForm_OneFromMultipleUsers.ShowDialog(this) == DialogResult.OK)
                {
                    m_LoginOfMyOrgUser.LoginSession_ID = awpLoginForm_OneFromMultipleUsers.LoginSession_id;
                    m_LoginOfMyOrgUser.Atom_WorkPeriod_ID = awpLoginForm_OneFromMultipleUsers.Atom_WorkPeriod_ID;
                    m_LoginOfMyOrgUser.LoggedIn = true;
                    lctrl.Trigger_EventUserLoggedIn(m_LoginOfMyOrgUser);
                }
            }
        }

        internal void DoLogout()
        {
            if (LoginControl.LoginCtrl.Logout(m_LoginOfMyOrgUser.Atom_WorkPeriod_ID))
            {
                m_LoginOfMyOrgUser.LoggedIn = false;
                lctrl.Trigger_EventUserLoggedOut(m_LoginOfMyOrgUser);
            }
        }

        private void btn_GetAccess_Click(object sender, EventArgs e)
        {
            switch (lctrl.AuthentificationType)
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
            if (m_LoginOfMyOrgUser.IsUserManager)
            {
                if (lctrl.m_usrc_LoginCtrl != null)
                {
                    lctrl.m_usrc_LoginCtrl.btn_UserManager.Visible = true;
                }
            }
            if (lctrl.m_usrc_LoginCtrl != null)
            {
                lctrl.m_usrc_LoginCtrl.lbl_username.Text = m_LoginOfMyOrgUser.UserName + ": " + m_LoginOfMyOrgUser.FirstName + " " + m_LoginOfMyOrgUser.LastName;
            }

            lctrl.Trigger_EventUserActivateDocumentMan(this.m_LoginOfMyOrgUser);

        }
    }
}
