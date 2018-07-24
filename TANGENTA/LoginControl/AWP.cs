using DBConnectionControl40;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LoginControl
{
    public class AWP
    {
        public const string ROLE_Administrator = "Administrator";
        public const string ROLE_UserManagement = "UserManagement";
        public const string ROLE_StockTakeManagement = "StockTakeManagement";
        public const string ROLE_PriceListManagement = "PriceListManagement";
        public const string ROLE_WriteInvoiceAndProformaInvoice = "WriteInvoiceAndProformaInvoice";
        // next roles maybe planed in the future
        //public const string ROLE_WriteInvoice = "WriteInvoice";
        //public const string ROLE_WriteProformainvoice = "WriteProformaInvoice";
        //public const string ROLE_ViewAndExport = "ViewAndExport";
        //public const string ROLE_WorkInShopA = "WorkInShopA";
        //public const string ROLE_WorkInShopB = "WorkInShopB";
        //public const string ROLE_WorkInShopC = "WorkInShopC";

        internal usrc_MultipleUsers m_usrc_MultipleUsers = null;

        internal LoginCtrl.delegate_Edit_myOrganisationPerson call_Edit_myOrganisationPerson = null;

        internal AWPBindingData awpd = new AWPBindingData();
        DataTable AWP_dtLoginView = null;

        internal AWPLoginData m_AWPLoginData = new AWPLoginData();

        private Form pParentForm = null;
        internal LoginCtrl lctrl = null;
        private DBConnection m_con = null;
        internal DBConnection con
        {
            get { return m_con; }
            set { m_con = value; }
        }

        public bool IsUserManager
        {
            get
            {
                if (m_AWPLoginData != null)
                {
                    foreach (AWPRole r in m_AWPLoginData.m_AWP_UserRoles)
                    {
                        if (r.Role.Equals(ROLE_Administrator) || r.Role.Equals(ROLE_UserManagement))
                        {
                            return true;
                        }
                    }
                    return false;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool IsAdministrator
        {
            get
            {
                if (m_AWPLoginData != null)
                {
                    foreach (AWPRole r in m_AWPLoginData.m_AWP_UserRoles)
                    {
                        if (r.Role.Equals(ROLE_Administrator))
                        {
                            return true;
                        }
                    }
                    return false;
                }
                else
                {
                    return false;
                }
            }
        }

        public ID LoginSession_id
        {
            get { return m_AWPLoginData.LoginSession_id; }
        }


        public ID myOrganisation_Person_ID
        {
            get { return m_AWPLoginData.myOrganisation_Person_ID; }
        }
        
        public ID LoginUsers_id
        {
            get
            {
                return m_AWPLoginData.ID;
            }
        }

        public string UserName
        {
            get
            {
                return m_AWPLoginData.UserName;
            }
        }

        public string FirstName
        {
            get
            {
                return m_AWPLoginData.myOrganisation_Person__per__cfn_FirstName;
            }
        }

        internal bool HasLoginControlRole(string[] oenofpossiblerequestedrole)
        {
            foreach (string rolepossible in oenofpossiblerequestedrole)
            {
                foreach (string usrrole in UserRoles)
                {
                    if (usrrole.Equals(rolepossible))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public string LastName
        {
            get
            {
                return m_AWPLoginData.myOrganisation_Person__per__cln_LastName;
            }
        }

        public string Identity
        {
            get
            {
                return m_AWPLoginData.myOrganisation_Person__per_Registration_ID;
            }
        }

        public string Email
        {
            get
            {
                return m_AWPLoginData.PersonData__cemailper_Email;
            }
        }

        public List<AWPRole> LoginAWP_AllRoles
        {
            get
            {
                return m_AWPLoginData.m_AWPRoles;
            }
        }

        public List<string> AllRoles
        {
            get
            {
                List<string> roles = new List<string>();
                foreach (AWPRole r in m_AWPLoginData.m_AWPRoles)
                {
                    roles.Add(r.Role);
                }
                return roles;
            }
        }

        public List<string> UserRoles {
            get
            {
                List<string> roles = new List<string>();
                foreach (AWPRole r in m_AWPLoginData.m_AWP_UserRoles)
                {
                    roles.Add(r.Role);
                }
                return roles;
            }
        }

        public bool PasswordNeverExpires
        {
            get
            {
                return m_AWPLoginData.PasswordNeverExpires;
            }
        }

        public bool NotActiveAfterPasswordExpires
        {
            get
            {
                return m_AWPLoginData.NotActiveAfterPasswordExpires;
            }
        }

        public bool bPasswordExpiresInNumberOfDays
        {
            get
            {
                if ((!m_AWPLoginData.PasswordNeverExpires) && (!m_AWPLoginData.NotActiveAfterPasswordExpires))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public int PasswordExpiresInNumberOfDays
        {
            get
            {
                if (!m_AWPLoginData.PasswordNeverExpires)
                {
                    TimeSpan tspan = new TimeSpan();
                    if (m_AWPLoginData.Time_When_UserSetsItsOwnPassword_LastTime != DateTime.MinValue)
                    {
                        tspan = DateTime.Now - m_AWPLoginData.Time_When_UserSetsItsOwnPassword_LastTime;
                        return tspan.Days;
                    }
                    else
                    {
                        return -1;
                    }
                }
                else
                {
                    return -1;
                }
            }
        }

        public int Maximum_password_age_in_days
        {
            get
            {
               return m_AWPLoginData.Maximum_password_age_in_days;
            }
        }

        public DateTime LastUserPasswordDefinitionTime
        {
            get
            {
               return m_AWPLoginData.Time_When_UserSetsItsOwnPassword_LastTime;
            }
        }


        public void Init(Form xpParentForm,
                          LoginCtrl xlctrl,
                          DBConnection xcon,
                          LoginCtrl.delegate_Edit_myOrganisationPerson xcall_Edit_myOrganisationPerson
                          )
        {
            pParentForm = xpParentForm;
            lctrl = xlctrl;
            call_Edit_myOrganisationPerson = xcall_Edit_myOrganisationPerson;
            AWP_func.con = xcon;
            AWP_func.UpdateRoles(awpd.AllRoles);
            TemplatesLoader.Init();
        }


        public bool CheckConnection(Form pParentForm)
        {
            return con.CheckDataBaseConnection(pParentForm, lng.s_LoginConnection.s);
        }


        internal bool Login(NavigationButtons.Navigation xnav,
                      LoginCtrl.delegate_Get_Atom_WorkPeriod call_Get_Atom_WorkPeriod)
        {
            string Err = null;
            eAWP_dtLogin_Vaild_result xres = Check_LoginTable(xnav, call_Get_Atom_WorkPeriod);
            if (xres == eAWP_dtLogin_Vaild_result.OK)
            {
                bool bres = CallLoginForm(call_Get_Atom_WorkPeriod);
                if (bres)
                {
                    if (IsUserManager)
                    {
                        lctrl.btn_UserManager.Visible = true;
                    }
                    lctrl.lbl_username.Text = UserName + ": " + FirstName + " " + LastName;
                }

                return bres;
            }
            else
            {
                return false;
            }
        }


        public bool Login_MultipleUsers_ShowControlAtStartup(NavigationButtons.Navigation xnav,
                                  LoginCtrl.delegate_Get_Atom_WorkPeriod call_Get_Atom_WorkPeriod,
                                  LoginCtrl.delegate_Activate_usrc_DocumentMan call_Activate_usrc_DocumentMan,
                                  UserControl xusrc_DocumentMan)
        {
            if (xusrc_DocumentMan != null) //MultipleUsers can login at the same time
            {
                eAWP_dtLogin_Vaild_result xres = Check_LoginTable(xnav, call_Get_Atom_WorkPeriod);
                if (xres == eAWP_dtLogin_Vaild_result.OK)
                {
                    Form parent_form = Global.f.GetParentForm(lctrl);
                    return Login_MultipleUsers_SetControl(AWP_dtLoginView, call_Get_Atom_WorkPeriod, call_Activate_usrc_DocumentMan, parent_form, xusrc_DocumentMan);
                }
                else
                {
                    return false;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:LoginControl:AWP:ShowLoginForm:xusrc_DocumentMan == null");
                return false;
            }
        }

        internal void Login_MultipleUsers_ShowControl()
        {
            if (m_usrc_MultipleUsers!=null)
            {
                m_usrc_MultipleUsers.Visible = true;
            }
        }

        internal eAWP_dtLogin_Vaild_result Check_LoginTable(NavigationButtons.Navigation xnav,
                                  LoginCtrl.delegate_Get_Atom_WorkPeriod call_Get_Atom_WorkPeriod)
        {
            string Err = null;
            if (AWP_func.Read_Login_VIEW(ref AWP_dtLoginView, null, null))
            {
                Form parent_form = Global.f.GetParentForm(lctrl);
                eAWP_dtLogin_Vaild_result eres = AWP_dtLogin_Vaild();
                switch (eres)
                {
                    case eAWP_dtLogin_Vaild_result.OK:
                        return eres;

                    case eAWP_dtLogin_Vaild_result.NO_USERS:
                        // First time instalation because  AWP_dtLoginView.Rows.Count==0

                        AWP_Select_users_from_myOrganisation_Person_Table frm_awp_mopt = new AWP_Select_users_from_myOrganisation_Person_Table(xnav, awpd, lng.s_ImportUsersWithAtLeastOneAadministratorRights);
                        DialogResult dlgRes = DialogResult.None;
                        if (parent_form != null)
                        {
                            frm_awp_mopt.TopMost = parent_form.TopMost;
                            dlgRes = frm_awp_mopt.ShowDialog(parent_form);
                        }
                        else
                        {
                            dlgRes = frm_awp_mopt.ShowDialog();
                        }
                        if (dlgRes == DialogResult.OK)
                        {
                            if (AWP_func.Import_myOrganisationPerson(awpd, frm_awp_mopt.drsImportAdministrator, frm_awp_mopt.drsImportOthers))
                            {
                                AWP_UserManager awp_usrmgt_frm = new AWP_UserManager(xnav, parent_form, this);
                                if (parent_form != null)
                                {
                                    awp_usrmgt_frm.TopMost = parent_form.TopMost;
                                    dlgRes = awp_usrmgt_frm.ShowDialog(parent_form);
                                }
                                else
                                {
                                    dlgRes = awp_usrmgt_frm.ShowDialog();
                                }
                                switch (dlgRes)
                                {
                                    case DialogResult.OK:
                                        if (IsUserManager)
                                        {
                                            lctrl.btn_UserManager.Visible = true;
                                        }
                                        ID Atom_WorkPeriod_ID = null;
                                        if (call_Get_Atom_WorkPeriod(m_AWPLoginData.myOrganisation_Person__per_ID, ref Atom_WorkPeriod_ID))
                                        {
                                            ID LoginSession_ID = null;
                                            if (AWP_func.WriteLoginSession(m_AWPLoginData.ID, Atom_WorkPeriod_ID, ref LoginSession_ID))
                                            {
                                                lctrl.lbl_username.Text = UserName + ": " + FirstName + " " + LastName;
                                                return eAWP_dtLogin_Vaild_result.OK;
                                            }
                                        }
                                        return eres;
                                }
                            }
                            else
                            {
                                return eres;
                            }
                        }
                        return eres;

                    case eAWP_dtLogin_Vaild_result.NO_PASSWORD_FOR_FIRST_USER:
                        AWP_UserManager awp_usrmgt2_frm = new AWP_UserManager(xnav, parent_form, this);
                        if (parent_form != null)
                        {
                            awp_usrmgt2_frm.TopMost = parent_form.TopMost;
                            dlgRes = awp_usrmgt2_frm.ShowDialog(parent_form);
                        }
                        else
                        {
                            dlgRes = awp_usrmgt2_frm.ShowDialog();
                        }
                        switch (dlgRes)
                        {
                            case DialogResult.OK:
                                if (IsUserManager)
                                {
                                    lctrl.btn_UserManager.Visible = true;
                                }
                                ID Atom_WorkPeriod_ID = null;
                                if (call_Get_Atom_WorkPeriod(m_AWPLoginData.myOrganisation_Person__per_ID, ref Atom_WorkPeriod_ID))
                                {
                                    ID LoginSession_ID = null;
                                    if (AWP_func.WriteLoginSession(m_AWPLoginData.ID, Atom_WorkPeriod_ID, ref LoginSession_ID))
                                    {
                                        lctrl.lbl_username.Text = UserName + ": " + FirstName + " " + LastName;
                                        return eAWP_dtLogin_Vaild_result.OK; 
                                    }
                                }
                                return eres;
                        }
                        return eres;

                }
                return eres;
            }
            else
            {
                LogFile.Error.Show("ERROR LOGIN !: Read Login Tables :" + Err);
                return eAWP_dtLogin_Vaild_result.NO_USERS;
            }
        }


        private bool CallLoginForm(LoginCtrl.delegate_Get_Atom_WorkPeriod call_Get_Atom_WorkPeriod)
        {
            AWPLoginForm loginf = new AWPLoginForm(this, call_Get_Atom_WorkPeriod);
            if (loginf.ShowDialog() == DialogResult.OK)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private usrc_MultipleUsers FindMutipleUsersControl(Form xparent_form)
        {
            foreach (Control c in xparent_form.Controls)
            {
                if (c is usrc_MultipleUsers)
                {
                    return (usrc_MultipleUsers)c;
                }
            }
            return null;
        }

        private bool Login_MultipleUsers_SetControl(DataTable dtAWP_dtLoginView, 
                                                    LoginCtrl.delegate_Get_Atom_WorkPeriod call_Get_Atom_WorkPeriod,
                                                    LoginCtrl.delegate_Activate_usrc_DocumentMan call_Activate_usrc_DocumentMan,
                                                    Form parent_form, UserControl xusrc_DocumentMan)
        {
            xusrc_DocumentMan.Visible = false;
            m_usrc_MultipleUsers = FindMutipleUsersControl(parent_form);
            if (m_usrc_MultipleUsers == null)
            {
                m_usrc_MultipleUsers = new usrc_MultipleUsers();
                m_usrc_MultipleUsers.Dock = DockStyle.Fill;
                parent_form.Controls.Add(m_usrc_MultipleUsers);
            }
            m_usrc_MultipleUsers.AWP_dtLoginView = dtAWP_dtLoginView;
            m_usrc_MultipleUsers.Visible = true;
            m_usrc_MultipleUsers.Init(this, call_Get_Atom_WorkPeriod, call_Activate_usrc_DocumentMan);
            return true;
        }


        internal enum eAWP_dtLogin_Vaild_result { OK,NO_PASSWORD_FOR_FIRST_USER,NO_USERS}

        private eAWP_dtLogin_Vaild_result AWP_dtLogin_Vaild()
        {

            if (AWP_dtLoginView.Rows.Count > 0)
            {
                if (AWP_dtLoginView.Rows[0]["Password"].GetType() != typeof(DBNull))
                {
                    return eAWP_dtLogin_Vaild_result.OK;
                }
                else
                {
                    return eAWP_dtLogin_Vaild_result.NO_PASSWORD_FOR_FIRST_USER;
                }
            }
            else
            {
               
                return eAWP_dtLogin_Vaild_result.NO_USERS;
            }
        }

        internal bool AWPLoginRoles_Get(ID LoginUser_id, ref List<AWPRole> roles, ref string Err)
        {
            DataTable dtRoles = new DataTable();
            if (AWP_func.AWPRoles_GetUserRoles(LoginUser_id, ref roles))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
