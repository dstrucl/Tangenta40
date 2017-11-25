using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DBConnectionControl40;
using LanguageControl;
using LogFile;
using System.Security.Cryptography;

namespace LoginControl
{
    public partial class LoginControl : UserControl
    {
        public const string ROLE_Administrator = "Administrator";
        public const string ROLE_UserManagement = "UserManagement";
        public const string ROLE_WriteInvoice = "WriteInvoice";
        public const string ROLE_WriteProformainvoice = "WriteProformaInvoice";
        public const string ROLE_StockTakeManagement = "StockTakeManagement";
        public const string ROLE_PriceListManagement = "PriceListManagement";
        public const string ROLE_ViewAndExport = "ViewAndExport";
        public const string ROLE_WorkInShopA = "WorkInShopA";
        public const string ROLE_WorkInShopB = "WorkInShopB";
        public const string ROLE_WorkInShopC = "WorkInShopC";


        public delegate bool delegate_Get_Atom_WorkPeriod(long myOrganisation_Person_ID, ref long Atom_WordPeriod_ID);
        public delegate bool delegate_Edit_myOrganisationPerson(Form parentform,long myOrganisation_Person_ID, ref bool Changed, ref long myOrganisation_Person_ID_new);

        public enum eDataTableCreationMode {/*STAND_ALONE*/STD,/*Atom_WorkPeriod*/ AWP };

        internal AWPBindingData awpd = new AWPBindingData();

        internal delegate_Edit_myOrganisationPerson call_Edit_myOrganisationPerson = null;

        LoginDB_DataSet.Login_VIEW m_Login_VIEW = null;
        DataTable AWP_dtLoginView = null;

        LoginDB_DataSet.LoginDB_DataSet_Procedures m_LoginDB_DataSet_Procedures = null;

        internal STDLoginData m_STDLoginData = new STDLoginData();
        internal AWPLoginData m_AWPLoginData = new AWPLoginData();
        internal DBConnection Login_con;

        internal int m_MinPasswordLength = 5;

        private eDataTableCreationMode m_eDataTableCreationMode = eDataTableCreationMode.STD; 

        public eDataTableCreationMode DataTableCreationMode
        {
            get { return m_eDataTableCreationMode; }
            set { m_eDataTableCreationMode = value; }
        }

        private string m_RecentItemsFolder = "";
        
        public string RecentItemsFolder
        {
            get { return m_RecentItemsFolder; }
            set { m_RecentItemsFolder = value; }
        }

        public bool IsAdministrator
        {
            get { return m_STDLoginData.IsAdministrator; }
        }

        public bool UserNameIsAdministrator
        {
            get { return m_STDLoginData.UserNameIsAdministrator; }
        }

        public int LoginSession_id
        {
            get { return m_STDLoginData.m_LoginSession_id; }
        }

        public int LoginUsers_id
        {
            get { return m_STDLoginData.m_LoginUsers_id; }
        }

        public string UserName
        {
            get {
                    if (m_eDataTableCreationMode == eDataTableCreationMode.AWP)
                    {
                        return m_AWPLoginData.UserName;
                    }
                    else
                    {
                        return m_STDLoginData.m_UserName;
                    }
                }
        }

        public string FirstName
        {
            get
            {
                if (m_eDataTableCreationMode == eDataTableCreationMode.AWP)
                {
                    return m_AWPLoginData.myOrganisation_Person__per__cfn_FirstName;
                }
                else
                {
                    return m_STDLoginData.m_FirstName;
                }
            }
        }

        public string LastName
        {
            get
            {
                if (m_eDataTableCreationMode == eDataTableCreationMode.AWP)
                {
                    return m_AWPLoginData.myOrganisation_Person__per__cln_LastName;
                }
                else
                {
                    return m_STDLoginData.m_LastName;
                }
            }
        }

        public string Identity
        {
            get
            {
                if (m_eDataTableCreationMode == eDataTableCreationMode.AWP)
                {
                    return m_AWPLoginData.myOrganisation_Person__per_Registration_ID;
                }
                else
                {
                    return m_STDLoginData.m_Identity;
                }
            }
        }

        public string Contact
        {
            get
            {
                if (m_eDataTableCreationMode == eDataTableCreationMode.AWP)
                {
                    return m_AWPLoginData.PersonData__cemailper_Email;
                }
                else
                {
                    return m_STDLoginData.m_Contact;
                }
            }
        }

        public List<STDRole> LoginSTDRoles
        {
            get
            {
                return m_STDLoginData.m_STDRoles;
            }
        }

        public List<AWPRole> LoginAWP_AllRoles
        {
            get
            {
                return m_AWPLoginData.m_AWPRoles;
            }
        }


        internal List<AWPRole> LoginAWP_UserRoles
        {
            get { return m_AWPLoginData.m_AWP_UserRoles; }
        }

        public bool PasswordNeverExpires
        {
            get
            {
                if (m_eDataTableCreationMode == eDataTableCreationMode.AWP)
                {
                    return m_AWPLoginData.PasswordNeverExpires;
                }
                else
                {
                    return m_STDLoginData.m_PasswordNeverExpires;
                }
            }
        }

        public bool NotActiveAfterPasswordExpires
        {
            get
            {
                if (m_eDataTableCreationMode == eDataTableCreationMode.AWP)
                {
                    return m_AWPLoginData.NotActiveAfterPasswordExpires;
                }
                else
                {
                    return m_STDLoginData.m_NotActiveAfterPasswordExpires;
                }
            }
        }

        public bool bPasswordExpiresInNumberOfDays
        {
            get
            {
                if (m_eDataTableCreationMode == eDataTableCreationMode.AWP)
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
                else
                {
                    if ((!m_STDLoginData.m_PasswordNeverExpires) && (!m_STDLoginData.m_NotActiveAfterPasswordExpires))
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

        public int PasswordExpiresInNumberOfDays
        {
            get
            {
                if (m_eDataTableCreationMode == eDataTableCreationMode.AWP)
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
                else
                {
                    if (!m_STDLoginData.m_PasswordNeverExpires)
                    {
                        TimeSpan tspan = new TimeSpan();
                        if (m_STDLoginData.Time_When_UserSetsItsOwnPassword_LastTime != DateTime.MinValue)
                        {
                            tspan = DateTime.Now - m_STDLoginData.Time_When_UserSetsItsOwnPassword_LastTime;
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
        }

        public int Maximum_password_age_in_days
        {
            get
            {
                if (m_eDataTableCreationMode == eDataTableCreationMode.AWP)
                {
                    return m_AWPLoginData.Maximum_password_age_in_days;
                }
                else
                {
                    return m_STDLoginData.NumberOfDaysAfterPasswordExpires;
                }
            }
        }

        public DateTime LastUserPasswordDefinitionTime
        {
            get
            {
                if (m_eDataTableCreationMode == eDataTableCreationMode.AWP)
                {
                    return m_AWPLoginData.Time_When_UserSetsItsOwnPassword_LastTime;
                }
                else
                {
                    return m_STDLoginData.Time_When_UserSetsItsOwnPassword_LastTime;
                }
            }
        }

        public int MinPasswordLength
        {
            get { return m_MinPasswordLength;  }
            set {m_MinPasswordLength = value;
                    if (m_MinPasswordLength < 5)
                    {
                        MessageBox.Show(lng.s_YouCanNotSetMinumumPasswordLengthLessThan5.s);
                    }
                }
        }

        public LoginControl()
        {
            InitializeComponent();
        }
        public bool CheckConnection(Form pParentForm)
        {
            return Login_con.CheckDataBaseConnection(pParentForm, lng.s_LoginConnection.s);
        }


        public static byte[] CalculateSHA256(string InputString)
        {
            //encrypt password
            byte[] encryptedPass;
            UTF8Encoding encoder = new UTF8Encoding();
            SHA256Managed shaTranscode = new SHA256Managed();
            encryptedPass = shaTranscode.ComputeHash(encoder.GetBytes(InputString));
            return encryptedPass;
        }

        public bool GetTables(eDataTableCreationMode xeDataTableCreationMode, DBConnection Login_con, ref string Err)
        {
            
            if (Read_Login_VIEW(m_eDataTableCreationMode,this.Login_con,ref Err))
            {
                return true;
            }
            else
            {
                switch (m_eDataTableCreationMode)
                {
                    case eDataTableCreationMode.STD:
                        {
                            if (CreateTables(xeDataTableCreationMode, Login_con))
                            {
                                if (Read_Login_VIEW(m_eDataTableCreationMode, this.Login_con,ref Err))
                                {
                                    return true;
                                }
                                else
                                {
                                    LogFile.Error.Show("ERROR:Reading Login Tables !");
                                    return false;
                                }

                            }
                            else
                            {
                                return false;
                            }
                        }

                    default:
                        return false;

                }
            }
        }


        public bool CreateTables(eDataTableCreationMode xeDataTableCreationMode, DBConnection Login_con)
        {
            switch (xeDataTableCreationMode)
            {
                case eDataTableCreationMode.STD:
                    switch (Login_con.DBType)
                    {
                        case DBConnection.eDBType.MSSQL:
                            return STAND_ALONE_MSSQL_CreateTables.CreateTables(Login_con);
                        case DBConnection.eDBType.MYSQL:
                            LogFile.Error.Show("ERROR:CreateTables: Not implemented for " + xeDataTableCreationMode.ToString() + " and " + Login_con.DBType.ToString());
                            return false;
                        case DBConnection.eDBType.SQLITE:
                            LogFile.Error.Show("ERROR:CreateTables: Not implemented for " + xeDataTableCreationMode.ToString() + " and " + Login_con.DBType.ToString());
                            return false;
                    }
                    return false;

                case eDataTableCreationMode.AWP:
                    switch (Login_con.DBType)
                    {
                        case DBConnection.eDBType.MSSQL:
                            LogFile.Error.Show("ERROR:CreateTables: Not implemented for " + xeDataTableCreationMode.ToString() + " and " + Login_con.DBType.ToString());
                            break;
                        case DBConnection.eDBType.MYSQL:
                            LogFile.Error.Show("ERROR:CreateTables: Not implemented for " + xeDataTableCreationMode.ToString() + " and " + Login_con.DBType.ToString());
                            return false;
                        case DBConnection.eDBType.SQLITE:
                            LogFile.Error.Show("ERROR:CreateTables: Not implemented for " + xeDataTableCreationMode.ToString() + " and " + Login_con.DBType.ToString());
                            return false;
                    }
                    return false;

            }
            return false;
        }



        internal bool Read_Login_VIEW(eDataTableCreationMode xeDataTableCreationMode, DBConnection Login_con,ref string Err)
        {
            switch (xeDataTableCreationMode)
            {
                case eDataTableCreationMode.STD:
                    switch (Login_con.DBType)
                    {
                        case DBConnection.eDBType.MSSQL:
                            return STD_MSSQL.Read_Login_VIEW(ref m_Login_VIEW, Login_con, ref Err);
                        case DBConnection.eDBType.MYSQL:
                            LogFile.Error.Show("ERROR:Read_Login_VIEW: Not implemented for " + xeDataTableCreationMode.ToString() + " and " + Login_con.DBType.ToString());
                            return false;
                        case DBConnection.eDBType.SQLITE:
                            LogFile.Error.Show("ERROR:Read_Login_VIEW: Not implemented for " + xeDataTableCreationMode.ToString() + " and " + Login_con.DBType.ToString());
                            return false;
                    }
                    LogFile.Error.Show("ERROR:Read_Login_VIEW: Not implemented for " + xeDataTableCreationMode.ToString() + " and " + Login_con.DBType.ToString());
                    return false;

                case eDataTableCreationMode.AWP:
                    switch (AWP_func.con.DBType)
                    {
                        case DBConnection.eDBType.MSSQL:
                            return AWP_func.Read_Login_VIEW( ref AWP_dtLoginView,null,null);

                        case DBConnection.eDBType.MYSQL:
                            LogFile.Error.Show("ERROR:Read_Login_VIEW: Not implemented for " + xeDataTableCreationMode.ToString() + " and " + Login_con.DBType.ToString());
                            return false;
                        case DBConnection.eDBType.SQLITE:
                            return AWP_func.Read_Login_VIEW(ref AWP_dtLoginView,null, null);
                    }
                    LogFile.Error.Show("ERROR:Read_Login_VIEW: Not implemented for " + xeDataTableCreationMode.ToString() + " and " + Login_con.DBType.ToString());
                    return false;

            }
            LogFile.Error.Show("ERROR:Read_Login_VIEW: Not implemented for " + xeDataTableCreationMode.ToString() + " and " + Login_con.DBType.ToString());
            return false;
        }

        public bool InitSTDMode(Form pParentForm, DBConnection con,object DBParam,int Language_id,ref bool bCancel, ref string Err )
        {
            m_eDataTableCreationMode = eDataTableCreationMode.STD;
            LoginDB_DataSet.DynSettings.LanguageID = Language_id;
            Login_con = con;
            if (CheckConnection(pParentForm))
            {
                    return GetTables(m_eDataTableCreationMode, Login_con, ref Err);
            }
            else
            {
                LogFile.Error.Show("ERROR:LoginControl:Init:There si no database connection to:" + Login_con.DataBase);
               return false;
            }
        }

        public void InitAWPMode(Form pParentForm, 
                                DBConnection xcon, 
                                int Language_id,
                                delegate_Edit_myOrganisationPerson xcall_Edit_myOrganisationPerson
                                )
        {
            call_Edit_myOrganisationPerson = xcall_Edit_myOrganisationPerson;
            m_eDataTableCreationMode = eDataTableCreationMode.AWP;
            LoginDB_DataSet.DynSettings.LanguageID = Language_id;
            AWP_func.con= xcon;
            AWP_func.UpdateRoles(awpd.AllRoles);
        }

        public bool STD_Login()
        {
            string Err = null;
            if (Read_Login_VIEW(m_eDataTableCreationMode,this.Login_con,ref Err))
            {
                if (STD_dtLogin_Vaild(ref Err))
                {
                    return DoSTDLogin();
                }
                else
                {
                    // Login as SuperAdministrator to edit Login Tables !
                    LoginSuperAdministratorForm lgsForm = new LoginSuperAdministratorForm();
                    if (lgsForm.ShowDialog() == DialogResult.OK)
                    {
                        DataRow[] dr = m_Login_VIEW.dt.Select(LoginDB_DataSet.Login_VIEW.username.name + " = 'Administrator'");
                        if (dr != null)
                        {
                            m_STDLoginData.m_LoginUsers_id = (int) dr[0][LoginDB_DataSet.Login_VIEW.Users_id.name];

                            STD_UserManager edtLogin = new STD_UserManager(null,this);
                            if (edtLogin.ShowDialog() == DialogResult.OK)
                            {
                                if (Read_Login_VIEW(m_eDataTableCreationMode, this.Login_con,ref Err))
                                {
                                    if (STD_dtLogin_Vaild(ref Err))
                                    {
                                        return DoSTDLogin();
                                    }
                                    else
                                    {
                                        LogFile.Error.Show("ERROR:LoginControl:Login: Read Login data Tables are not valid:" + Err);
                                        return false;
                                    }
                                }
                                else
                                {
                                    LogFile.Error.Show("ERROR:LoginControl:Login: Read Login_VIEW Err=:" + Err);
                                    return false;
                                }
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }
                }
                return false;
            }
            else
            {
                LogFile.Error.Show("ERROR LOGIN !: Read Login Tables :" + Err);
                return false;
            }
        }

        public bool AWP_Login(NavigationButtons.Navigation xnav,
                              delegate_Get_Atom_WorkPeriod call_Get_Atom_WorkPeriod)
        {
            string Err = null;
            if (Read_Login_VIEW(m_eDataTableCreationMode, this.Login_con, ref Err))
            {
                if (AWP_dtLogin_Vaild(ref Err))
                {
                    return DoAWPLogin(call_Get_Atom_WorkPeriod);
                }
                else
                {
                    // First time instalation because AWP_dtLoginView.Rows[0]["Password"] == null ! or AWP_dtLoginView.Rows.Count==0
                    Form parent_form = GetParentForm();
                    AWP_Select_users_from_myOrganisation_Person_Table frm_awp_mopt = new AWP_Select_users_from_myOrganisation_Person_Table(xnav,Login_con, awpd,lng.s_ImportUsersWithAtLeastOneAadministratorRights);
                    DialogResult dlgRes = DialogResult.None;
                    if (parent_form != null)
                    {
                        frm_awp_mopt.TopMost = parent_form.TopMost;
                        dlgRes = frm_awp_mopt.ShowDialog(parent_form);
                    }
                    else
                    {
                        dlgRes=frm_awp_mopt.ShowDialog();
                    }
                    if (dlgRes==DialogResult.OK)
                    {
                        if (AWP_func.Import_myOrganisationPerson(awpd,frm_awp_mopt.drsImportAdministrator, frm_awp_mopt.drsImportOthers))
                        {
                            AWP_UserManager awp_usrmgt_frm = new AWP_UserManager(xnav,parent_form, this);
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
                                    return true;
                            }
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
                return false;
            }
            else
            {
                LogFile.Error.Show("ERROR LOGIN !: Read Login Tables :" + Err);
                return false;
            }
        }


        private Form GetParentForm()
        {
            Control ctrlParent = this.Parent;
            for (int i=0;i<20;i++)
            {
                if (ctrlParent != null)
                {
                    if (ctrlParent is Form)
                    {
                        return (Form)ctrlParent;
                    }
                    else
                    {
                        ctrlParent = ctrlParent.Parent;
                    }
                }
                else
                {
                    return null;
                }
            }
            return null;
        }

        private bool DoSTDLogin()
        {
            STDLoginForm loginf = new STDLoginForm(this);
            if (loginf.ShowDialog() == DialogResult.OK)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool DoAWPLogin(delegate_Get_Atom_WorkPeriod call_Get_Atom_WorkPeriod)
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

        public bool Logout()
        {
            return DoLogout();
        }

        private bool DoLogout()
        {
            string Err = null;
            if (m_STDLoginData.m_LoginSession_id >= 0)
            {
                if (m_STDLoginData.m_LoginUsers_id >= 0)
                {
                    string Res = null;
                    LoginDB_DataSet.LoginDB_DataSet_Procedures logProc = new LoginDB_DataSet.LoginDB_DataSet_Procedures(Login_con);
                    logProc.LoginSession_End(m_STDLoginData.m_LoginSession_id, ref Res, ref Err);
                    if (Res.Equals("OK"))
                    {
                        return true;
                    }
                    else
                    {
                        if (Err == null)
                        {
                            Err = "null";
                        }
                        LogFile.Error.Show("Error:DoLogout:LoginSession_End:Res=" + Res + ", Err=" + Err);
                    }
                }
            }
            return false;
        }

        private bool STD_dtLogin_Vaild(ref string Err)
        {

            if (m_Login_VIEW.dt.Rows.Count > 0)
            {
                if (m_Login_VIEW.dt.Rows[0]["password"].GetType() != typeof(DBNull))
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
                Err = "Error : dtLogin Table is empty (dtLogin.Rows.Count = 0)!";
                return false;
            }
        }
        private bool AWP_dtLogin_Vaild(ref string Err)
        {

            if (AWP_dtLoginView.Rows.Count > 0)
            {
                if (AWP_dtLoginView.Rows[0]["Password"].GetType() != typeof(DBNull))
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
                Err = "Error : AWP_dtLoginView Table is empty (AWP_dtLoginView.Rows.Count = 0)!";
                return false;
            }
        }

        internal bool PasswordMatch(byte[] encrypted_password, string password)
        {
            byte[] encrypted_password2 = LoginControl.CalculateSHA256(password);

            if ((encrypted_password.Length == encrypted_password2.Length))
            {
                for (int i = 0; i < encrypted_password.Length; i++)
                {
                    if (encrypted_password[i] != encrypted_password2[i])
                    {
                        return false;
                    }
                }
            }
            return true;
        }



        internal bool LoginSTDRoles_Get(int LoginUser_id,List<STDRole> roles, ref string Err)
        {
            LoginDB_DataSet.Login_VIEW xLogin_VIEW = new LoginDB_DataSet.Login_VIEW(Login_con);
            xLogin_VIEW.Clear();
            xLogin_VIEW.select.all(false);
            xLogin_VIEW.select.Role_id = true;
            xLogin_VIEW.select.Role_Name = true;
            xLogin_VIEW.select.Role_PrivilegesLevel = true;
            xLogin_VIEW.select.Role_description = true;
            xLogin_VIEW.where.all(false);
            xLogin_VIEW.where.Users_id = true;
            xLogin_VIEW.where.Users_id_Expression(" = " + LoginUser_id.ToString());
            if (xLogin_VIEW.Read(ref Err))
            {
                roles.Clear();
                foreach (DataRow dr in xLogin_VIEW.dt.Rows)
                {
                    int LoginRole_id = -1;
                    string LoginRole_Name = null;
                    int LoginRole_PrivilegesLevel = -1;
                    string LoginRole_description = "";
                    if (dr[LoginDB_DataSet.Login_VIEW.Role_id.name].GetType()== typeof(int))
                    {
                        LoginRole_id = (int)dr[LoginDB_DataSet.Login_VIEW.Role_id.name];
                    }
                    if (dr[LoginDB_DataSet.Login_VIEW.Role_Name.name].GetType() == typeof(string))
                    {
                        LoginRole_Name = (string)dr[LoginDB_DataSet.Login_VIEW.Role_Name.name];
                    }
                    if (dr[LoginDB_DataSet.Login_VIEW.Role_PrivilegesLevel.name].GetType() == typeof(int))
                    {
                        LoginRole_PrivilegesLevel = (int)dr[LoginDB_DataSet.Login_VIEW.Role_PrivilegesLevel.name];
                    }
                    if (dr[LoginDB_DataSet.Login_VIEW.Role_description.name].GetType() == typeof(string))
                    {
                        LoginRole_description = (string)dr[LoginDB_DataSet.Login_VIEW.Role_description.name];
                    }

                    if ((LoginRole_Name != null) && (LoginRole_PrivilegesLevel >= 0))
                    {
                        STDRole role = new STDRole();
                        role.id = LoginRole_id;
                        role.Name = LoginRole_Name;
                        role.PrivilegesLevel = LoginRole_PrivilegesLevel;
                        role.description = LoginRole_description;
                        roles.Add(role);
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        internal bool AWPLoginRoles_Get(long LoginUser_id,ref List<AWPRole> roles, ref string Err)
        {
            DataTable dtRoles = new DataTable();
            if (AWP_func.AWPRoles_GetUserRoles(LoginUser_id,ref roles))
            { 
                return true;
            }
            else
            {
                return false;
            }
        }

        private void btn_UserManager_Click(object sender, EventArgs e)
        {
            STD_UserManager usr_mangaer = new STD_UserManager(this.ParentForm, this);
            usr_mangaer.ShowDialog();
        }

        private void btn_UserInfo_Click(object sender, EventArgs e)
        {
            STDUserInfoForm usrinfo = new STDUserInfoForm(this);
            usrinfo.ShowDialog();
        }

        internal bool STDLoginData_Get(LoginDB_DataSet.LoginUsers LoginUsers, ref string Err)
        {
            m_STDLoginData.m_LoginUsers_id = LoginUsers.o_id.id_;
            m_STDLoginData.m_UserName = LoginUsers.o_username.username_;
            m_STDLoginData.m_FirstName = LoginUsers.o_first_name.first_name_;
            m_STDLoginData.m_LastName = LoginUsers.o_last_name.last_name_;
            m_STDLoginData.m_Identity = LoginUsers.o_Identity.Identity_;


            m_STDLoginData.m_PasswordNeverExpires = LoginUsers.o_PasswordNeverExpires.PasswordNeverExpires_;
            m_STDLoginData.m_NotActiveAfterPasswordExpires = LoginUsers.o_NotActiveAfterPasswordExpires.NotActiveAfterPasswordExpires_;
            m_STDLoginData.NumberOfDaysAfterPasswordExpires = LoginUsers.o_Maximum_password_age_in_days.Maximum_password_age_in_days_;

            lbl_username.Text = lng.s_UserName.s + ":" + m_STDLoginData.m_UserName;

            try
            {
                m_STDLoginData.Time_When_UserSetsItsOwnPassword_LastTime = LoginUsers.o_Time_When_UserSetsItsOwnPassword_LastTime.Time_When_UserSetsItsOwnPassword_LastTime_;
            }
            catch
            {
                m_STDLoginData.Time_When_UserSetsItsOwnPassword_LastTime = DateTime.MinValue;
            }
            
            if (LoginSTDRoles_Get(LoginUsers.o_id.id_,m_STDLoginData.m_STDRoles, ref Err))
            {
                if (IsAdministrator)
                {
                    btn_UserManager.Visible = true;
                }
                else
                {
                    btn_UserManager.Visible = false;
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool my_AddSTDRole(string LoginRole_Name, int LoginRole_PrivilegesLevel, string LoginRole_description, ref int LoginRole_id)
        {
            if (m_LoginDB_DataSet_Procedures == null)
            {
                m_LoginDB_DataSet_Procedures = new LoginDB_DataSet.LoginDB_DataSet_Procedures(Login_con);
            }

            string Res = null;
            string Err = null;
            m_LoginDB_DataSet_Procedures.LoginUsers_Administrator_AddRole(LoginRole_Name, LoginRole_PrivilegesLevel, LoginRole_description,1, ref LoginRole_id,ref Res, ref Err);
            if (Res.Equals("OK"))
            {
                return true;
            }
            else
            {
                LogFile.Error.Show("Error:LoginControl:my_AddRole:LoginUsers_Administrator_AddRole:Res="+Res);
            }
            return false;
        }


        private bool my_AddRole(string LoginRole_Name, int LoginRole_PrivilegesLevel, string LoginRole_description, ref int LoginRole_id)
        {
            if (m_LoginDB_DataSet_Procedures == null)
            {
                m_LoginDB_DataSet_Procedures = new LoginDB_DataSet.LoginDB_DataSet_Procedures(Login_con);
            }

            string Res = null;
            string Err = null;
            m_LoginDB_DataSet_Procedures.LoginUsers_Administrator_AddRole(LoginRole_Name, LoginRole_PrivilegesLevel, LoginRole_description, 1, ref LoginRole_id, ref Res, ref Err);
            if (Res.Equals("OK"))
            {
                return true;
            }
            else
            {
                LogFile.Error.Show("Error:LoginControl:my_AddRole:LoginUsers_Administrator_AddRole:Res=" + Res);
            }
            return false;
        }

        public bool AddRole(string LoginRole_Name, int LoginRole_PrivilegesLevel, string LoginRole_description, ref int LoginRole_id)
        {
            if (IsAdministrator)
            {
                return my_AddRole(LoginRole_Name, LoginRole_PrivilegesLevel, LoginRole_description, ref LoginRole_id);
            }
            else
            {
                LogFile.Error.Show("WARNING:LoginControl:AddRole: You can not add roles if DataTableCreationMode property is NONE  or Administrator is not logged in !");
                return false;
            }
        }

        public bool AddUser(string username, string frist_name, string last_name, string Identity, string Contact, bool enabled, bool PasswordNeverExpires, bool NotActiveAfterPasswordExpires, int NumberOfDaysPasswordIsValid, ref int LoginUsers_id)
        {
            if (m_LoginDB_DataSet_Procedures == null)
            {
                m_LoginDB_DataSet_Procedures = new LoginDB_DataSet.LoginDB_DataSet_Procedures(Login_con);
            }

            string Res = null;
            string Err = null;
            byte[] pass = CalculateSHA256("123");
            m_LoginDB_DataSet_Procedures.LoginUsers_Administrator_AddUser(username, pass, true, frist_name, last_name, Identity, Contact, 1, true, true, 90, false, ref LoginUsers_id, ref Res, ref Err);
            if (Res.Equals("OK"))
            {
                return true;
            }
            else
            {
                LogFile.Error.Show("Error:LoginControl:AddUser:LoginUsers_Administrator_AddUser:Res=" + Res);
            }
            return false;
        }

        public bool LoginUsersAndLoginRoles_Add(int LoginUsers_id, int LoginRoles_id, ref int LoginUsersAndLoginRoles_id)
        {
            if (m_LoginDB_DataSet_Procedures == null)
            {
                m_LoginDB_DataSet_Procedures = new LoginDB_DataSet.LoginDB_DataSet_Procedures(Login_con);
            }

            string Res = null;
            string Err = null;
            m_LoginDB_DataSet_Procedures.LoginUsersAndLoginRoles_Add(LoginUsers_id, LoginRoles_id, 1, ref LoginUsersAndLoginRoles_id, ref Res, ref Err);
            if (Res.Equals("OK"))
            {
                return true;
            }
            else
            {
                LogFile.Error.Show("Error:LoginControl:LoginUsersAndLoginRoles_Add:LoginUsersAndLoginRoles_Add:Res=" + Res);
            }
            return false;
        }

        public bool STDContainsRole(string RoleName)
        {
            foreach (STDRole role in m_STDLoginData.m_STDRoles)
            {
                if (RoleName.Equals(role.Name))
                {
                    return true;
                }
            }
            return false;
        }

        public bool STDContainsRoles(string[] sroles)
        {
            foreach (STDRole role in m_STDLoginData.m_STDRoles)
            {
                foreach (string s in sroles)
                {
                    if (s.Equals(role.Name))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
