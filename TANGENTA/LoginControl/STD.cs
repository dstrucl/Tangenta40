using DBConnectionControl40;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LoginControl
{
    public class STD
    {
        LoginDB_DataSet.Login_VIEW m_Login_VIEW = null;
        LoginDB_DataSet.LoginDB_DataSet_Procedures m_LoginDB_DataSet_Procedures = null;

        internal STDLoginData m_STDLoginData = new STDLoginData();

        internal DBConnection Login_con;

        Form pParentForm = null;

        internal LoginCtrl lctrl = null;

        public bool IsUserManager
        {
            get
            {
                return m_STDLoginData.IsAdministrator;
            }
        }

        public bool IsAdministrator
        {
            get
            {
                return m_STDLoginData.IsAdministrator;
            }
        }

        public int LoginSession_id
        {
            get { return m_STDLoginData.m_LoginSession_id; }
        }

        public int LoginUsers_id
        {
            get
            {
                    return m_STDLoginData.m_LoginUsers_id;
            }
        }

        public string UserName
        {
            get
            {
               return m_STDLoginData.m_UserName;
            }
        }

        public string FirstName
        {
            get
            {
               return m_STDLoginData.m_FirstName;
            }
        }
        public string LastName
        {
            get
            {
               return m_STDLoginData.m_LastName;
            }
        }

        public string Identity
        {
            get
            {
               return m_STDLoginData.m_Identity;
            }
        }

        public string Email
        {
            get
            {
                return m_STDLoginData.m_Contact;
            }
        }

        public bool PasswordNeverExpires
        {
            get
            {
               return m_STDLoginData.m_PasswordNeverExpires;
            }
        }

        public bool NotActiveAfterPasswordExpires
        {
            get
            {
                return m_STDLoginData.m_NotActiveAfterPasswordExpires;
            }
        }

        public bool bPasswordExpiresInNumberOfDays
        {
            get
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

        public int PasswordExpiresInNumberOfDays
        {
            get
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

        public int Maximum_password_age_in_days
        {
            get
            {
               return m_STDLoginData.NumberOfDaysAfterPasswordExpires;
            }
        }

        public DateTime LastUserPasswordDefinitionTime
        {
            get
            {
               return m_STDLoginData.Time_When_UserSetsItsOwnPassword_LastTime;
            }
        }

        public bool CheckConnection(Form pParentForm)
        {
            return Login_con.CheckDataBaseConnection(pParentForm, lng.s_LoginConnection.s);
        }

        internal bool Read_Login_VIEW(DBConnection Login_con, ref string Err)
        {
           
           return STD_MSSQL.Read_Login_VIEW(ref m_Login_VIEW, Login_con, ref Err);
        }


        public List<STDRole> LoginSTDRoles
        {
            get
            {
                return m_STDLoginData.m_STDRoles;
            }
        }

        public bool Init(Form xpParentForm,LoginCtrl xlctrl, DBConnection con, object DBParam, int Language_id, ref bool bCancel, ref string Err)
        {
            pParentForm = xpParentForm;
            lctrl = xlctrl;
            LoginDB_DataSet.DynSettings.LanguageID = Language_id;
            Login_con = con;
            if (CheckConnection(pParentForm))
            {
                return GetTables( Login_con, ref Err);
            }
            else
            {
                LogFile.Error.Show("ERROR:LoginControl:Init:There si no database connection to:" + Login_con.DataBase);
                return false;
            }
        }

        public bool STD_Login()
        {
            string Err = null;
            if (Read_Login_VIEW(this.Login_con, ref Err))
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
                            m_STDLoginData.m_LoginUsers_id = (int)dr[0][LoginDB_DataSet.Login_VIEW.Users_id.name];

                            STD_UserManager edtLogin = new STD_UserManager(null, this);
                            if (edtLogin.ShowDialog() == DialogResult.OK)
                            {
                                if (Read_Login_VIEW(this.Login_con, ref Err))
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

        internal bool LoginSTDRoles_Get(int LoginUser_id, List<STDRole> roles, ref string Err)
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
                    if (dr[LoginDB_DataSet.Login_VIEW.Role_id.name].GetType() == typeof(int))
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

            if (lctrl.m_usrc_LoginCtrl != null)
            {
                lctrl.m_usrc_LoginCtrl.lbl_username.Text = lng.s_UserName.s + ":" + m_STDLoginData.m_UserName;
            }

            try
            {
                m_STDLoginData.Time_When_UserSetsItsOwnPassword_LastTime = LoginUsers.o_Time_When_UserSetsItsOwnPassword_LastTime.Time_When_UserSetsItsOwnPassword_LastTime_;
            }
            catch
            {
                m_STDLoginData.Time_When_UserSetsItsOwnPassword_LastTime = DateTime.MinValue;
            }

            if (LoginSTDRoles_Get(LoginUsers.o_id.id_, m_STDLoginData.m_STDRoles, ref Err))
            {
                if (IsAdministrator)
                {
                    if (lctrl.m_usrc_LoginCtrl != null)
                    {
                        lctrl.m_usrc_LoginCtrl.btn_UserManager.Visible = true;
                    }
                }
                else
                {
                    if (lctrl.m_usrc_LoginCtrl != null)
                    {
                        lctrl.m_usrc_LoginCtrl.btn_UserManager.Visible = false;
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
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

        public bool GetTables( DBConnection Login_con, ref string Err)
        {

            if (Read_Login_VIEW(this.Login_con, ref Err))
            {
                return true;
            }
            else
            {
                if (this.CreateTables(Login_con))
                {
                    if (Read_Login_VIEW(this.Login_con, ref Err))
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
        }

        internal bool CreateTables(DBConnection Login_con)
        {
                switch (Login_con.DBType)
                {
                    case DBConnection.eDBType.MSSQL:
                        return STAND_ALONE_MSSQL_CreateTables.CreateTables(Login_con);
                    case DBConnection.eDBType.MYSQL:
                        LogFile.Error.Show("ERROR:CreateTables: Not implemented for "+ Login_con.DBType.ToString());
                        return false;
                    case DBConnection.eDBType.SQLITE:
                        LogFile.Error.Show("ERROR:CreateTables: Not implemented for " + Login_con.DBType.ToString());
                        return false;
                }
                return false;
        }

        internal bool Logout()
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

        private bool my_AddSTDRole(string LoginRole_Name, int LoginRole_PrivilegesLevel, string LoginRole_description, ref int LoginRole_id)
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
            byte[] pass = LoginCtrl.CalculateSHA256("123");
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
    }
}
