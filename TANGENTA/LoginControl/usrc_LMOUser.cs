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
    public partial class usrc_LMOUser : UserControl
    {
        internal usrc_MultipleUsers m_usrc_MultipleUsers = null;

        internal LoginCtrl lctrl = null;

        internal LMOUser m_LMOUser = null;

        public usrc_LMOUser(LoginCtrl xlxtrl)
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
                if (m_LMOUser.awpld != null)
                {
                    return m_LMOUser.IsAdministrator;
                }
                return false;
            }
        }

        private bool IsUserManager
        {
            get
            {
                if (m_LMOUser.awpld != null)
                {
                    return m_LMOUser.IsUserManager;
                }
                return false;
            }
        }

        internal void SetData(DataRow dr)
        {
            if (m_LMOUser==null)
            {
                m_LMOUser = new LMOUser(this);
            }
            m_LMOUser.SetData(dr);

        }


        private bool Authentificate_PASSWORD()
        {
            AWPLoginForm_OneFromMultipleUsers awpLoginForm_OneFromMultipleUsers = new AWPLoginForm_OneFromMultipleUsers(m_LMOUser,  false, AWPLoginForm_OneFromMultipleUsers.LoginType.LOGIN, m_LMOUser.Atom_WorkPeriod_ID);
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
            AWPLoginForm_AuthentificatePIN awpLoginForm__AuthentificatePIN = new AWPLoginForm_AuthentificatePIN(m_LMOUser);
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
            lctrl.IdleCtrl.TimerCounter_Stop();
            if (this.m_LMOUser.LoggedIn)
            {
                bool bLogoutAll = (IsAdministrator || IsUserManager);
                if (bLogoutAll)
                {
                    if (m_usrc_MultipleUsers.LoggedIn_Count() == 1)
                    {
                        bLogoutAll = false;
                    }
                }

                AWPLoginForm_OneFromMultipleUsers awpLoginForm_OneFromMultipleUsers = new AWPLoginForm_OneFromMultipleUsers(m_LMOUser,  bLogoutAll, AWPLoginForm_OneFromMultipleUsers.LoginType.LOGOUT, m_LMOUser.Atom_WorkPeriod_ID);
                if (awpLoginForm_OneFromMultipleUsers.ShowDialog(this) == DialogResult.OK)
                {
                    if (awpLoginForm_OneFromMultipleUsers.LogoutALL)
                    {
                        this.m_usrc_MultipleUsers.LogoutAll();
                    }
                    else
                    {
                        lctrl.Trigger_EventUserLoggedOut(this.m_LMOUser);
                    }
                    m_LMOUser.LoginSession_ID = awpLoginForm_OneFromMultipleUsers.LoginSession_id;
                    m_LMOUser.Atom_WorkPeriod_ID = null;
                    m_LMOUser.awpld = null;
                    m_LMOUser.LoggedIn = false;
                }
            }
            else
            {
                m_LMOUser.LoginSession_ID = null;
                m_LMOUser.Atom_WorkPeriod_ID = null;
                m_LMOUser.awpld = null;

                int last_LoggedIn_Count = m_usrc_MultipleUsers.LoggedIn_Count();

                AWPLoginForm_OneFromMultipleUsers awpLoginForm_OneFromMultipleUsers = new AWPLoginForm_OneFromMultipleUsers(m_LMOUser,  false, AWPLoginForm_OneFromMultipleUsers.LoginType.LOGIN,null);
                if (awpLoginForm_OneFromMultipleUsers.ShowDialog(this) == DialogResult.OK)
                {
                    m_LMOUser.LoginSession_ID = awpLoginForm_OneFromMultipleUsers.LoginSession_id;
                    m_LMOUser.Atom_WorkPeriod_ID = awpLoginForm_OneFromMultipleUsers.Atom_WorkPeriod_ID;
                    m_LMOUser.LoggedIn = true;
                    lctrl.Trigger_EventUserLoggedIn(m_LMOUser);
                    if (m_usrc_MultipleUsers.CashierActivity == usrc_MultipleUsers.eCashierActivity.CLOSED)
                    {
                        Form_OpenCashier frm_opencashier = new Form_OpenCashier();
                        if (frm_opencashier.ShowDialog(this) == DialogResult.Yes)
                        {
                            m_usrc_MultipleUsers.CashierActivity = usrc_MultipleUsers.eCashierActivity.OPENED;
                        }
                    }
                }
            }
            lctrl.IdleCtrl.TimerCounter_Start();
        }

        internal void DoLogout()
        {
            if (LoginControl.LoginCtrl.Logout(m_LMOUser.Atom_WorkPeriod_ID))
            {
                m_LMOUser.LoggedIn = false;
                lctrl.Trigger_EventUserLoggedOut(m_LMOUser);
            }
        }

        private void btn_GetAccess_Click(object sender, EventArgs e)
        {
            lctrl.IdleCtrl.TimerCounter_Stop();
            switch (lctrl.AuthentificationType)
            {
                case LoginCtrl.eAuthentificationType.PASSWORD:
                    if (!Authentificate_PASSWORD())
                    {
                        XMessage.Box.Show(this,lng.s_Password_does_not_match,MessageBoxIcon.Information);
                        lctrl.IdleCtrl.TimerCounter_Start();
                        return;
                    }
                    break;

                case LoginCtrl.eAuthentificationType.PIN:
                    if (!Authentificate_PIN())
                    {
                        lctrl.IdleCtrl.TimerCounter_Start();
                        return;
                    }
                    break;
            }
            myOrg.m_myOrg_Office.m_myOrg_Person = myOrg.m_myOrg_Office.Find_myOrg_Person(m_LMOUser.myOrganisation_Person_ID);
            if (myOrg.m_myOrg_Office.m_myOrg_Person==null)
            {
                LogFile.Error.Show("ERROR:LoginControl:usrc_LMOUser:btn_GetAccess_Click:myOrg.m_myOrg_Office.m_myOrg_Person==null");
            }
            if (m_LMOUser.IsUserManager)
            {
                if (lctrl.m_usrc_LoginCtrl != null)
                {
                    lctrl.m_usrc_LoginCtrl.btn_UserManager.Visible = true;
                }
            }
            if (lctrl.m_usrc_LoginCtrl != null)
            {
                lctrl.m_usrc_LoginCtrl.lbl_username.Text = m_LMOUser.UserName + ": " + m_LMOUser.FirstName + " " + m_LMOUser.LastName;
            }

            lctrl.Trigger_EventUserActivateDocumentMan(this.m_LMOUser);

        }
    }
}
