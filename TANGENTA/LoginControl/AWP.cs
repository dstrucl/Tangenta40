using DBConnectionControl40;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TangentaDB;
using static TangentaDB.CashierActivity;

namespace LoginControl
{
    public class AWP
    {
        public const string ROLE_Administrator = "Administrator";
        public const string ROLE_UserManagement = "UserManagement";
        public const string ROLE_StockTakeManagement = "StockTakeManagement";
        public const string ROLE_PriceListManagement = "PriceListManagement";
        public const string ROLE_WriteInvoice = "WriteInvoice";
        public const string ROLE_WriteProformaInvoice = "WriteProformaInvoice";

        // next roles maybe planed in the future
        //public const string ROLE_WriteInvoice = "WriteInvoice";
        //public const string ROLE_WriteProformainvoice = "WriteProformaInvoice";
        //public const string ROLE_ViewAndExport = "ViewAndExport";
        //public const string ROLE_WorkInShopA = "WorkInShopA";
        //public const string ROLE_WorkInShopB = "WorkInShopB";
        //public const string ROLE_WorkInShopC = "WorkInShopC";

        internal usrc_MultipleUsers m_usrc_MultipleUsers = null;


        internal static AWPBindingData awpd = new AWPBindingData();


        DataTable AWP_dtLoginView = null;

        public LMOUser LMO1User = new LMOUser(null);

        private Form pParentForm = null;
        internal LoginCtrl lctrl = null;
        private DBConnection m_con = null;
        internal DBConnection con
        {
            get { return m_con; }
            set { m_con = value; }
        }

        public eCashierState CashierActivity
        {
            get
            {
                if (m_usrc_MultipleUsers!=null)
                {
                    return m_usrc_MultipleUsers.CashierState;
                }
                else
                {
                    return eCashierState.CLOSED;
                }
            }
        }

        public void Init(Form xpParentForm,
                          LoginCtrl xlctrl,
                          DBConnection xcon,
                          bool bSingleUser
                          )
        {
            pParentForm = xpParentForm;
            lctrl = xlctrl;
            AWP_func.con = xcon;
            AWP_func.UpdateRoles(awpd.AllRoles);
            TemplatesLoader.Init();
            if (bSingleUser)
            {
                LMO1User.awpld = new AWPLoginData();
                AWPRole awpr = new AWPRole(null, ROLE_Administrator);
                LMO1User.awpld.m_AWP_UserRoles = new List<AWPRole>();
                LMO1User.awpld.m_AWP_UserRoles.Add(awpr);
                string sfirstname = "";
                if (myOrg.m_myOrg_Office.m_myOrg_Person.FirstName_v != null)
                {
                    sfirstname = myOrg.m_myOrg_Office.m_myOrg_Person.FirstName_v.v;
                }
                string slastname = "";
                if (myOrg.m_myOrg_Office.m_myOrg_Person.LastName_v != null)
                {
                    slastname = myOrg.m_myOrg_Office.m_myOrg_Person.LastName_v.v;
                }
                LMO1User.awpld.myOrganisation_Person__per__cfn_FirstName = sfirstname;
                LMO1User.awpld.myOrganisation_Person__per__cln_LastName = slastname;
                LMO1User.awpld.UserName = sfirstname + " " + slastname; 

            }
        }


        public bool CheckConnection(Form pParentForm)
        {
            return con.CheckDataBaseConnection(pParentForm, lng.s_LoginConnection.s);
        }


        internal bool LoginSingleUser(NavigationButtons.Navigation xnav)
        {
            eAWP_dtLogin_Vaild_result xres = Check_LoginTable(xnav);
            if (xres == eAWP_dtLogin_Vaild_result.OK)
            {
                bool bres = CallLoginForm();
                if (bres)
                {
                    if (LMO1User.IsUserManager)
                    {
                        if (lctrl.m_usrc_LoginCtrl != null)
                        {
                            lctrl.m_usrc_LoginCtrl.btn_UserManager.Visible = true;
                        }
                    }

                    if (lctrl.m_usrc_LoginCtrl != null)
                    {
                        lctrl.m_usrc_LoginCtrl.lbl_username.Text = LMO1User.UserName + ": " + LMO1User.FirstName + " " + LMO1User.LastName;
                    }
                }

                return bres;
            }
            else
            {
                return false;
            }
        }


        public bool Login_MultipleUsers_ShowControlAtStartup(NavigationButtons.Navigation xnav,bool bShowAdministratorUsers)
        {
            eAWP_dtLogin_Vaild_result xres = Check_LoginTable(xnav);
            if (xres == eAWP_dtLogin_Vaild_result.OK)
            {
                Form parent_form = LoginCtrl.m_parent_form;
                return Login_MultipleUsers_SetControl(AWP_dtLoginView,parent_form, bShowAdministratorUsers);
            }
            else
            {
                return false;
            }
        }

        internal void Login_MultipleUsers_ShowControl()
        {
            if (m_usrc_MultipleUsers!=null)
            {
                m_usrc_MultipleUsers.Visible = true;
                if (lctrl!=null)
                {
                    if (lctrl.IdleControlActive)
                    {
                        if (lctrl.IdleCtrl.m_usrc_MultipleUsers == null)
                        {
                            lctrl.IdleCtrl.m_usrc_MultipleUsers = this.m_usrc_MultipleUsers;
                        }
                        lctrl.IdleCtrl.TimerCounter_Start();
                        return;
                    }
                    lctrl.IdleCtrl.TimerCounter_Stop();
                }

            }
        }

        internal eAWP_dtLogin_Vaild_result Check_LoginTable(NavigationButtons.Navigation xnav)
        {
            string Err = null;
            if (AWP_func.Read_Login_VIEW(ref AWP_dtLoginView, null, null))
            {
                Form parent_form = LoginCtrl.m_parent_form;
                eAWP_dtLogin_Vaild_result eres = AWP_dtLogin_Vaild();
eres_check:
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
                                AWP_UserManager awp_usrmgt_frm = new AWP_UserManager(lctrl,xnav, parent_form,LMO1User);
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
                                        if (LMO1User.IsUserManager)
                                        {
                                            if (lctrl.m_usrc_LoginCtrl != null)
                                            {
                                                lctrl.m_usrc_LoginCtrl.btn_UserManager.Visible = true;
                                            }
                                        }

                                        if (lctrl.LMUsers)
                                        {
                                            if (AWP_func.Read_Login_VIEW(ref AWP_dtLoginView, null, null))
                                            {
                                                eres = AWP_dtLogin_Vaild();
                                                if (eres != eAWP_dtLogin_Vaild_result.OK)
                                                {
                                                    goto eres_check;
                                                }
                                            }

                                        }
                                        else
                                        {
                                            ID Atom_WorkPeriod_ID = null;
                                            if (LoginCtrl.GetWorkPeriodEx(LMO1User,
                                                          ref LMO1User.Atom_myOrganisation_Person_ID 
                                                          ))
                                            {
                                                ID LoginSession_ID = null;
                                                if (AWP_func.WriteLoginSession(LMO1User.awpld.ID, Atom_WorkPeriod_ID, ref LoginSession_ID))
                                                {
                                                    if (lctrl.m_usrc_LoginCtrl != null)
                                                    {
                                                        lctrl.m_usrc_LoginCtrl.lbl_username.Text = LMO1User.UserName + ": " + LMO1User.FirstName + " " + LMO1User.LastName;
                                                    }
                                                    return eAWP_dtLogin_Vaild_result.OK;
                                                }
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
                        AWP_UserManager awp_usrmgt2_frm = new AWP_UserManager(lctrl,xnav, parent_form, LMO1User);
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
                                if (LMO1User.IsUserManager)
                                {
                                    if (lctrl.m_usrc_LoginCtrl != null)
                                    {
                                        lctrl.m_usrc_LoginCtrl.btn_UserManager.Visible = true;
                                    }
                                }
                                ID xAtom_WorkPeriod_ID = null;

                                if (LoginCtrl.GetWorkPeriodEx(LMO1User,
                                                            ref xAtom_WorkPeriod_ID
                                                            ))
                                {
                                    ID LoginSession_ID = null;
                                    LMO1User.Atom_WorkPeriod_ID = xAtom_WorkPeriod_ID;
                                    if (AWP_func.WriteLoginSession(LMO1User.awpld.ID, LMO1User.Atom_WorkPeriod_ID, ref LoginSession_ID))
                                    {
                                        if (lctrl.m_usrc_LoginCtrl != null)
                                        {
                                            lctrl.m_usrc_LoginCtrl.lbl_username.Text = LMO1User.UserName + ": " + LMO1User.FirstName + " " + LMO1User.LastName;
                                        }
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


        private bool CallLoginForm()
        {
            AWPLoginForm loginf = new AWPLoginForm(this);
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
                                                    Form parent_form,
                                                    bool bShowAdministratorUsers)
        {
            m_usrc_MultipleUsers = FindMutipleUsersControl(parent_form);
            if (m_usrc_MultipleUsers == null)
            {
                m_usrc_MultipleUsers = new usrc_MultipleUsers();
                m_usrc_MultipleUsers.Dock = DockStyle.Fill;
                parent_form.Controls.Add(m_usrc_MultipleUsers);
            }
            m_usrc_MultipleUsers.AWP_dtLoginView = dtAWP_dtLoginView;
            m_usrc_MultipleUsers.Visible = true;
            m_usrc_MultipleUsers.Init(this,lctrl.RecordCashierActivity, bShowAdministratorUsers);
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
