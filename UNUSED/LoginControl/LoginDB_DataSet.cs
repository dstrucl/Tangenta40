
using System;
using System.Data;
using System.Collections.Generic;
using System.Windows.Forms;
using DBConnectionControl4;
using LoginaDatasetCommonClasses;
namespace LoginDB_DataSet
{

    public class LoginRoles:XTable
    {
        public const string tablename_const = "LoginRoles";
        public selection select;
        public WHERE where;

        public void Set_DataGridView_Headers(DataGridView dgv)
        {
            LoginRoles_lang m_LoginRoles_lang = new LoginRoles_lang();
            foreach (DataGridViewColumn dgvc in dgv.Columns)
            {
                foreach (ltext lt in m_LoginRoles_lang.col_headers)
                {
                    if (dgvc.Name.Equals(lt.name))
                    {
                        dgvc.HeaderText = lt.s;
                    }
                }
            }
        }


        public int RowsCount
        {
            get {return RowsCount();}
        }
        public void Clear()
        {
            clear();
        }

        public bool Read(ref string csError)
        {
          bool bRead = read(ref csError);
          if (Cursor>=0)
          {
             UpdateObjects(dt.Rows[Cursor]);
          }
          return bRead;
        }
        
        public class id:ValSet
           { 
             public const string name = "id";

             public int id_
             {
                get {return (int) obj;}
                set {obj = value;}
             }
           }
           public id o_id = new id();

        public class Name:ValSet
           { 
             public const string name = "Name";

             public string Name_
             {
                get {return (string) obj;}
                set {obj = value;}
             }
           }
           public Name o_Name = new Name();

        public class description:ValSet
           { 
             public const string name = "description";

             public string description_
             {
                get {return (string) obj;}
                set {obj = value;}
             }
           }
           public description o_description = new description();

        public LoginRoles(DBConnectionControl4.DBConnection xcon)
           {
                select = new selection(this);
                where  = new WHERE(this);
                m_con = xcon;
                tablename = LoginRoles.tablename_const;
                myUpdateObjects = UpdateObjects;


                    o_id.col_name = LoginRoles.id.name;
                    o_id.col_type.m_Type = "int";
                    o_id.col_type.bPRIMARY_KEY = true;
                    o_id.col_type.bFOREIGN_KEY = false;
                    o_id.col_type.bUNIQUE = false;
                    o_id.col_type.bNULL = false;
                    Add(o_id);
                    
                    o_Name.col_name = LoginRoles.Name.name;
                    o_Name.col_type.m_Type = "nvarchar";
                    o_Name.col_type.bPRIMARY_KEY = false;
                    o_Name.col_type.bFOREIGN_KEY = false;
                    o_Name.col_type.bUNIQUE = false;
                    o_Name.col_type.bNULL = true;
                    Add(o_Name);
                    
                    o_description.col_name = LoginRoles.description.name;
                    o_description.col_type.m_Type = "nvarchar";
                    o_description.col_type.bPRIMARY_KEY = false;
                    o_description.col_type.bFOREIGN_KEY = false;
                    o_description.col_type.bUNIQUE = false;
                    o_description.col_type.bNULL = true;
                    Add(o_description);
                    
           }

        public class selection
           {
                private LoginRoles m_LoginRoles;
                public selection(LoginRoles xLoginRoles)
                {
                    m_LoginRoles =  xLoginRoles;
                }

                    public bool id
                    {
                        get {return m_LoginRoles.o_id.Select.enabled;}
                        set {m_LoginRoles.o_id.Select.enabled = value;}
                    }
                    
                    public void id_Expression(string Expression,string xalternate_column_name)
                    {
                        m_LoginRoles.o_id.Select.expression = Expression;
                        m_LoginRoles.o_id.Select.alternate_column_name = xalternate_column_name;
                    }
                    
                    public bool Name
                    {
                        get {return m_LoginRoles.o_Name.Select.enabled;}
                        set {m_LoginRoles.o_Name.Select.enabled = value;}
                    }
                    
                    public void Name_Expression(string Expression,string xalternate_column_name)
                    {
                        m_LoginRoles.o_Name.Select.expression = Expression;
                        m_LoginRoles.o_Name.Select.alternate_column_name = xalternate_column_name;
                    }
                    
                    public bool description
                    {
                        get {return m_LoginRoles.o_description.Select.enabled;}
                        set {m_LoginRoles.o_description.Select.enabled = value;}
                    }
                    
                    public void description_Expression(string Expression,string xalternate_column_name)
                    {
                        m_LoginRoles.o_description.Select.expression = Expression;
                        m_LoginRoles.o_description.Select.alternate_column_name = xalternate_column_name;
                    }
                    
               public void all(bool bVal)
               {

                    this.id = bVal;
                    
                    this.Name = bVal;
                    
                    this.description = bVal;
                    
               }
    
           }

        public class WHERE
           {
                private LoginRoles m_LoginRoles;
                public WHERE(LoginRoles xLoginRoles)
                {
                    m_LoginRoles =  xLoginRoles;
                }

                    public bool id
                    {
                        get {return m_LoginRoles.o_id.Where.enabled;}
                        set {m_LoginRoles.o_id.Where.enabled = value;}
                    }
                    
                    public void id_Expression(string Expression)
                    {
                        m_LoginRoles.o_id.Where.expression = Expression;
                    }
                    

                    public void id_AddParameter(DBConnectionControl4.SQL_Parameter par)
                    {
                        m_LoginRoles.o_id.Where.AddParameter(par);
                    }
                    
                    public bool Name
                    {
                        get {return m_LoginRoles.o_Name.Where.enabled;}
                        set {m_LoginRoles.o_Name.Where.enabled = value;}
                    }
                    
                    public void Name_Expression(string Expression)
                    {
                        m_LoginRoles.o_Name.Where.expression = Expression;
                    }
                    

                    public void Name_AddParameter(DBConnectionControl4.SQL_Parameter par)
                    {
                        m_LoginRoles.o_Name.Where.AddParameter(par);
                    }
                    
                    public bool description
                    {
                        get {return m_LoginRoles.o_description.Where.enabled;}
                        set {m_LoginRoles.o_description.Where.enabled = value;}
                    }
                    
                    public void description_Expression(string Expression)
                    {
                        m_LoginRoles.o_description.Where.expression = Expression;
                    }
                    

                    public void description_AddParameter(DBConnectionControl4.SQL_Parameter par)
                    {
                        m_LoginRoles.o_description.Where.AddParameter(par);
                    }
                    
               public void all(bool bVal)
               {

                    this.id = bVal;
                    
                    this.Name = bVal;
                    
                    this.description = bVal;
                    
               }
    
           }

        public void UpdateObjects(DataRow dr)
           {

                    if (o_id.Select.enabled)
                    {
                        if (o_id.Select.IsExpression)
                        {
                          if (dr[o_id.Select.alternate_column_name] != null)
                          {
                            if (dr[o_id.Select.alternate_column_name].GetType() != typeof(System.DBNull))
                            {
                              o_id.obj  = dr[o_id.Select.alternate_column_name];
                            }
                          }
                        }
                        else
                        {
                          if (dr[LoginRoles.id.name] != null)
                          {
                            if (dr[LoginRoles.id.name].GetType() != typeof(System.DBNull))
                            {
                            o_id.id_  = (int) dr[LoginRoles.id.name];
                            }
                          }
                        }

                    }
                    if (o_Name.Select.enabled)
                    {
                        if (o_Name.Select.IsExpression)
                        {
                          if (dr[o_Name.Select.alternate_column_name] != null)
                          {
                            if (dr[o_Name.Select.alternate_column_name].GetType() != typeof(System.DBNull))
                            {
                              o_Name.obj  = dr[o_Name.Select.alternate_column_name];
                            }
                          }
                        }
                        else
                        {
                          if (dr[LoginRoles.Name.name] != null)
                          {
                            if (dr[LoginRoles.Name.name].GetType() != typeof(System.DBNull))
                            {
                            o_Name.Name_  = (string) dr[LoginRoles.Name.name];
                            }
                          }
                        }

                    }
                    if (o_description.Select.enabled)
                    {
                        if (o_description.Select.IsExpression)
                        {
                          if (dr[o_description.Select.alternate_column_name] != null)
                          {
                            if (dr[o_description.Select.alternate_column_name].GetType() != typeof(System.DBNull))
                            {
                              o_description.obj  = dr[o_description.Select.alternate_column_name];
                            }
                          }
                        }
                        else
                        {
                          if (dr[LoginRoles.description.name] != null)
                          {
                            if (dr[LoginRoles.description.name].GetType() != typeof(System.DBNull))
                            {
                            o_description.description_  = (string) dr[LoginRoles.description.name];
                            }
                          }
                        }

                    }
           }

    }
    public class LoginUsers:XTable
    {
        public const string tablename_const = "LoginUsers";
        public selection select;
        public WHERE where;

        public void Set_DataGridView_Headers(DataGridView dgv)
        {
            LoginUsers_lang m_LoginUsers_lang = new LoginUsers_lang();
            foreach (DataGridViewColumn dgvc in dgv.Columns)
            {
                foreach (ltext lt in m_LoginUsers_lang.col_headers)
                {
                    if (dgvc.Name.Equals(lt.name))
                    {
                        dgvc.HeaderText = lt.s;
                    }
                }
            }
        }


        public int RowsCount
        {
            get {return RowsCount();}
        }
        public void Clear()
        {
            clear();
        }

        public bool Read(ref string csError)
        {
          bool bRead = read(ref csError);
          if (Cursor>=0)
          {
             UpdateObjects(dt.Rows[Cursor]);
          }
          return bRead;
        }
        
        public class id:ValSet
           { 
             public const string name = "id";

             public int id_
             {
                get {return (int) obj;}
                set {obj = value;}
             }
           }
           public id o_id = new id();

        public class first_name:ValSet
           { 
             public const string name = "first_name";

             public string first_name_
             {
                get {return (string) obj;}
                set {obj = value;}
             }
           }
           public first_name o_first_name = new first_name();

        public class last_name:ValSet
           { 
             public const string name = "last_name";

             public string last_name_
             {
                get {return (string) obj;}
                set {obj = value;}
             }
           }
           public last_name o_last_name = new last_name();

        public class Identity:ValSet
           { 
             public const string name = "Identity";

             public string Identity_
             {
                get {return (string) obj;}
                set {obj = value;}
             }
           }
           public Identity o_Identity = new Identity();

        public class Contact:ValSet
           { 
             public const string name = "Contact";

             public string Contact_
             {
                get {return (string) obj;}
                set {obj = value;}
             }
           }
           public Contact o_Contact = new Contact();

        public class username:ValSet
           { 
             public const string name = "username";

             public string username_
             {
                get {return (string) obj;}
                set {obj = value;}
             }
           }
           public username o_username = new username();

        public class password:ValSet
           { 
             public const string name = "password";

             public Byte[] password_
             {
                get {return (Byte[]) obj;}
                set {obj = value;}
             }
           }
           public password o_password = new password();

        public class enabled:ValSet
           { 
             public const string name = "enabled";

             public bool enabled_
             {
                get {return (bool) obj;}
                set {obj = value;}
             }
           }
           public enabled o_enabled = new enabled();

        public class ChangePasswordOnFirstLogin:ValSet
           { 
             public const string name = "ChangePasswordOnFirstLogin";

             public bool ChangePasswordOnFirstLogin_
             {
                get {return (bool) obj;}
                set {obj = value;}
             }
           }
           public ChangePasswordOnFirstLogin o_ChangePasswordOnFirstLogin = new ChangePasswordOnFirstLogin();

        public class Time_When_UserSetsItsOwnPassword:ValSet
           { 
             public const string name = "Time_When_UserSetsItsOwnPassword";

             public DateTime Time_When_UserSetsItsOwnPassword_
             {
                get {return (DateTime) obj;}
                set {obj = value;}
             }
           }
           public Time_When_UserSetsItsOwnPassword o_Time_When_UserSetsItsOwnPassword = new Time_When_UserSetsItsOwnPassword();

        public class PasswordNeverExpires:ValSet
           { 
             public const string name = "PasswordNeverExpires";

             public bool PasswordNeverExpires_
             {
                get {return (bool) obj;}
                set {obj = value;}
             }
           }
           public PasswordNeverExpires o_PasswordNeverExpires = new PasswordNeverExpires();

        public class Maximum_password_age_in_days:ValSet
           { 
             public const string name = "Maximum_password_age_in_days";

             public int Maximum_password_age_in_days_
             {
                get {return (int) obj;}
                set {obj = value;}
             }
           }
           public Maximum_password_age_in_days o_Maximum_password_age_in_days = new Maximum_password_age_in_days();

        public LoginUsers(DBConnectionControl4.DBConnection xcon)
           {
                select = new selection(this);
                where  = new WHERE(this);
                m_con = xcon;
                tablename = LoginUsers.tablename_const;
                myUpdateObjects = UpdateObjects;


                    o_id.col_name = LoginUsers.id.name;
                    o_id.col_type.m_Type = "int";
                    o_id.col_type.bPRIMARY_KEY = true;
                    o_id.col_type.bFOREIGN_KEY = false;
                    o_id.col_type.bUNIQUE = false;
                    o_id.col_type.bNULL = false;
                    Add(o_id);
                    
                    o_first_name.col_name = LoginUsers.first_name.name;
                    o_first_name.col_type.m_Type = "nvarchar";
                    o_first_name.col_type.bPRIMARY_KEY = false;
                    o_first_name.col_type.bFOREIGN_KEY = false;
                    o_first_name.col_type.bUNIQUE = false;
                    o_first_name.col_type.bNULL = true;
                    Add(o_first_name);
                    
                    o_last_name.col_name = LoginUsers.last_name.name;
                    o_last_name.col_type.m_Type = "nvarchar";
                    o_last_name.col_type.bPRIMARY_KEY = false;
                    o_last_name.col_type.bFOREIGN_KEY = false;
                    o_last_name.col_type.bUNIQUE = false;
                    o_last_name.col_type.bNULL = true;
                    Add(o_last_name);
                    
                    o_Identity.col_name = LoginUsers.Identity.name;
                    o_Identity.col_type.m_Type = "nvarchar";
                    o_Identity.col_type.bPRIMARY_KEY = false;
                    o_Identity.col_type.bFOREIGN_KEY = false;
                    o_Identity.col_type.bUNIQUE = false;
                    o_Identity.col_type.bNULL = true;
                    Add(o_Identity);
                    
                    o_Contact.col_name = LoginUsers.Contact.name;
                    o_Contact.col_type.m_Type = "nvarchar";
                    o_Contact.col_type.bPRIMARY_KEY = false;
                    o_Contact.col_type.bFOREIGN_KEY = false;
                    o_Contact.col_type.bUNIQUE = false;
                    o_Contact.col_type.bNULL = true;
                    Add(o_Contact);
                    
                    o_username.col_name = LoginUsers.username.name;
                    o_username.col_type.m_Type = "nvarchar";
                    o_username.col_type.bPRIMARY_KEY = false;
                    o_username.col_type.bFOREIGN_KEY = false;
                    o_username.col_type.bUNIQUE = true;
                    o_username.col_type.bNULL = false;
                    Add(o_username);
                    
                    o_password.col_name = LoginUsers.password.name;
                    o_password.col_type.m_Type = "varbinary";
                    o_password.col_type.bPRIMARY_KEY = false;
                    o_password.col_type.bFOREIGN_KEY = false;
                    o_password.col_type.bUNIQUE = false;
                    o_password.col_type.bNULL = true;
                    Add(o_password);
                    
                    o_enabled.col_name = LoginUsers.enabled.name;
                    o_enabled.col_type.m_Type = "bit";
                    o_enabled.col_type.bPRIMARY_KEY = false;
                    o_enabled.col_type.bFOREIGN_KEY = false;
                    o_enabled.col_type.bUNIQUE = false;
                    o_enabled.col_type.bNULL = false;
                    Add(o_enabled);
                    
                    o_ChangePasswordOnFirstLogin.col_name = LoginUsers.ChangePasswordOnFirstLogin.name;
                    o_ChangePasswordOnFirstLogin.col_type.m_Type = "bit";
                    o_ChangePasswordOnFirstLogin.col_type.bPRIMARY_KEY = false;
                    o_ChangePasswordOnFirstLogin.col_type.bFOREIGN_KEY = false;
                    o_ChangePasswordOnFirstLogin.col_type.bUNIQUE = false;
                    o_ChangePasswordOnFirstLogin.col_type.bNULL = false;
                    Add(o_ChangePasswordOnFirstLogin);
                    
                    o_Time_When_UserSetsItsOwnPassword.col_name = LoginUsers.Time_When_UserSetsItsOwnPassword.name;
                    o_Time_When_UserSetsItsOwnPassword.col_type.m_Type = "datetime";
                    o_Time_When_UserSetsItsOwnPassword.col_type.bPRIMARY_KEY = false;
                    o_Time_When_UserSetsItsOwnPassword.col_type.bFOREIGN_KEY = false;
                    o_Time_When_UserSetsItsOwnPassword.col_type.bUNIQUE = false;
                    o_Time_When_UserSetsItsOwnPassword.col_type.bNULL = true;
                    Add(o_Time_When_UserSetsItsOwnPassword);
                    
                    o_PasswordNeverExpires.col_name = LoginUsers.PasswordNeverExpires.name;
                    o_PasswordNeverExpires.col_type.m_Type = "bit";
                    o_PasswordNeverExpires.col_type.bPRIMARY_KEY = false;
                    o_PasswordNeverExpires.col_type.bFOREIGN_KEY = false;
                    o_PasswordNeverExpires.col_type.bUNIQUE = false;
                    o_PasswordNeverExpires.col_type.bNULL = false;
                    Add(o_PasswordNeverExpires);
                    
                    o_Maximum_password_age_in_days.col_name = LoginUsers.Maximum_password_age_in_days.name;
                    o_Maximum_password_age_in_days.col_type.m_Type = "int";
                    o_Maximum_password_age_in_days.col_type.bPRIMARY_KEY = false;
                    o_Maximum_password_age_in_days.col_type.bFOREIGN_KEY = false;
                    o_Maximum_password_age_in_days.col_type.bUNIQUE = false;
                    o_Maximum_password_age_in_days.col_type.bNULL = true;
                    Add(o_Maximum_password_age_in_days);
                    
           }

        public class selection
           {
                private LoginUsers m_LoginUsers;
                public selection(LoginUsers xLoginUsers)
                {
                    m_LoginUsers =  xLoginUsers;
                }

                    public bool id
                    {
                        get {return m_LoginUsers.o_id.Select.enabled;}
                        set {m_LoginUsers.o_id.Select.enabled = value;}
                    }
                    
                    public void id_Expression(string Expression,string xalternate_column_name)
                    {
                        m_LoginUsers.o_id.Select.expression = Expression;
                        m_LoginUsers.o_id.Select.alternate_column_name = xalternate_column_name;
                    }
                    
                    public bool first_name
                    {
                        get {return m_LoginUsers.o_first_name.Select.enabled;}
                        set {m_LoginUsers.o_first_name.Select.enabled = value;}
                    }
                    
                    public void first_name_Expression(string Expression,string xalternate_column_name)
                    {
                        m_LoginUsers.o_first_name.Select.expression = Expression;
                        m_LoginUsers.o_first_name.Select.alternate_column_name = xalternate_column_name;
                    }
                    
                    public bool last_name
                    {
                        get {return m_LoginUsers.o_last_name.Select.enabled;}
                        set {m_LoginUsers.o_last_name.Select.enabled = value;}
                    }
                    
                    public void last_name_Expression(string Expression,string xalternate_column_name)
                    {
                        m_LoginUsers.o_last_name.Select.expression = Expression;
                        m_LoginUsers.o_last_name.Select.alternate_column_name = xalternate_column_name;
                    }
                    
                    public bool Identity
                    {
                        get {return m_LoginUsers.o_Identity.Select.enabled;}
                        set {m_LoginUsers.o_Identity.Select.enabled = value;}
                    }
                    
                    public void Identity_Expression(string Expression,string xalternate_column_name)
                    {
                        m_LoginUsers.o_Identity.Select.expression = Expression;
                        m_LoginUsers.o_Identity.Select.alternate_column_name = xalternate_column_name;
                    }
                    
                    public bool Contact
                    {
                        get {return m_LoginUsers.o_Contact.Select.enabled;}
                        set {m_LoginUsers.o_Contact.Select.enabled = value;}
                    }
                    
                    public void Contact_Expression(string Expression,string xalternate_column_name)
                    {
                        m_LoginUsers.o_Contact.Select.expression = Expression;
                        m_LoginUsers.o_Contact.Select.alternate_column_name = xalternate_column_name;
                    }
                    
                    public bool username
                    {
                        get {return m_LoginUsers.o_username.Select.enabled;}
                        set {m_LoginUsers.o_username.Select.enabled = value;}
                    }
                    
                    public void username_Expression(string Expression,string xalternate_column_name)
                    {
                        m_LoginUsers.o_username.Select.expression = Expression;
                        m_LoginUsers.o_username.Select.alternate_column_name = xalternate_column_name;
                    }
                    
                    public bool password
                    {
                        get {return m_LoginUsers.o_password.Select.enabled;}
                        set {m_LoginUsers.o_password.Select.enabled = value;}
                    }
                    
                    public void password_Expression(string Expression,string xalternate_column_name)
                    {
                        m_LoginUsers.o_password.Select.expression = Expression;
                        m_LoginUsers.o_password.Select.alternate_column_name = xalternate_column_name;
                    }
                    
                    public bool enabled
                    {
                        get {return m_LoginUsers.o_enabled.Select.enabled;}
                        set {m_LoginUsers.o_enabled.Select.enabled = value;}
                    }
                    
                    public void enabled_Expression(string Expression,string xalternate_column_name)
                    {
                        m_LoginUsers.o_enabled.Select.expression = Expression;
                        m_LoginUsers.o_enabled.Select.alternate_column_name = xalternate_column_name;
                    }
                    
                    public bool ChangePasswordOnFirstLogin
                    {
                        get {return m_LoginUsers.o_ChangePasswordOnFirstLogin.Select.enabled;}
                        set {m_LoginUsers.o_ChangePasswordOnFirstLogin.Select.enabled = value;}
                    }
                    
                    public void ChangePasswordOnFirstLogin_Expression(string Expression,string xalternate_column_name)
                    {
                        m_LoginUsers.o_ChangePasswordOnFirstLogin.Select.expression = Expression;
                        m_LoginUsers.o_ChangePasswordOnFirstLogin.Select.alternate_column_name = xalternate_column_name;
                    }
                    
                    public bool Time_When_UserSetsItsOwnPassword
                    {
                        get {return m_LoginUsers.o_Time_When_UserSetsItsOwnPassword.Select.enabled;}
                        set {m_LoginUsers.o_Time_When_UserSetsItsOwnPassword.Select.enabled = value;}
                    }
                    
                    public void Time_When_UserSetsItsOwnPassword_Expression(string Expression,string xalternate_column_name)
                    {
                        m_LoginUsers.o_Time_When_UserSetsItsOwnPassword.Select.expression = Expression;
                        m_LoginUsers.o_Time_When_UserSetsItsOwnPassword.Select.alternate_column_name = xalternate_column_name;
                    }
                    
                    public bool PasswordNeverExpires
                    {
                        get {return m_LoginUsers.o_PasswordNeverExpires.Select.enabled;}
                        set {m_LoginUsers.o_PasswordNeverExpires.Select.enabled = value;}
                    }
                    
                    public void PasswordNeverExpires_Expression(string Expression,string xalternate_column_name)
                    {
                        m_LoginUsers.o_PasswordNeverExpires.Select.expression = Expression;
                        m_LoginUsers.o_PasswordNeverExpires.Select.alternate_column_name = xalternate_column_name;
                    }
                    
                    public bool Maximum_password_age_in_days
                    {
                        get {return m_LoginUsers.o_Maximum_password_age_in_days.Select.enabled;}
                        set {m_LoginUsers.o_Maximum_password_age_in_days.Select.enabled = value;}
                    }
                    
                    public void Maximum_password_age_in_days_Expression(string Expression,string xalternate_column_name)
                    {
                        m_LoginUsers.o_Maximum_password_age_in_days.Select.expression = Expression;
                        m_LoginUsers.o_Maximum_password_age_in_days.Select.alternate_column_name = xalternate_column_name;
                    }
                    
               public void all(bool bVal)
               {

                    this.id = bVal;
                    
                    this.first_name = bVal;
                    
                    this.last_name = bVal;
                    
                    this.Identity = bVal;
                    
                    this.Contact = bVal;
                    
                    this.username = bVal;
                    
                    this.password = bVal;
                    
                    this.enabled = bVal;
                    
                    this.ChangePasswordOnFirstLogin = bVal;
                    
                    this.Time_When_UserSetsItsOwnPassword = bVal;
                    
                    this.PasswordNeverExpires = bVal;
                    
                    this.Maximum_password_age_in_days = bVal;
                    
               }
    
           }

        public class WHERE
           {
                private LoginUsers m_LoginUsers;
                public WHERE(LoginUsers xLoginUsers)
                {
                    m_LoginUsers =  xLoginUsers;
                }

                    public bool id
                    {
                        get {return m_LoginUsers.o_id.Where.enabled;}
                        set {m_LoginUsers.o_id.Where.enabled = value;}
                    }
                    
                    public void id_Expression(string Expression)
                    {
                        m_LoginUsers.o_id.Where.expression = Expression;
                    }
                    

                    public void id_AddParameter(DBConnectionControl4.SQL_Parameter par)
                    {
                        m_LoginUsers.o_id.Where.AddParameter(par);
                    }
                    
                    public bool first_name
                    {
                        get {return m_LoginUsers.o_first_name.Where.enabled;}
                        set {m_LoginUsers.o_first_name.Where.enabled = value;}
                    }
                    
                    public void first_name_Expression(string Expression)
                    {
                        m_LoginUsers.o_first_name.Where.expression = Expression;
                    }
                    

                    public void first_name_AddParameter(DBConnectionControl4.SQL_Parameter par)
                    {
                        m_LoginUsers.o_first_name.Where.AddParameter(par);
                    }
                    
                    public bool last_name
                    {
                        get {return m_LoginUsers.o_last_name.Where.enabled;}
                        set {m_LoginUsers.o_last_name.Where.enabled = value;}
                    }
                    
                    public void last_name_Expression(string Expression)
                    {
                        m_LoginUsers.o_last_name.Where.expression = Expression;
                    }
                    

                    public void last_name_AddParameter(DBConnectionControl4.SQL_Parameter par)
                    {
                        m_LoginUsers.o_last_name.Where.AddParameter(par);
                    }
                    
                    public bool Identity
                    {
                        get {return m_LoginUsers.o_Identity.Where.enabled;}
                        set {m_LoginUsers.o_Identity.Where.enabled = value;}
                    }
                    
                    public void Identity_Expression(string Expression)
                    {
                        m_LoginUsers.o_Identity.Where.expression = Expression;
                    }
                    

                    public void Identity_AddParameter(DBConnectionControl4.SQL_Parameter par)
                    {
                        m_LoginUsers.o_Identity.Where.AddParameter(par);
                    }
                    
                    public bool Contact
                    {
                        get {return m_LoginUsers.o_Contact.Where.enabled;}
                        set {m_LoginUsers.o_Contact.Where.enabled = value;}
                    }
                    
                    public void Contact_Expression(string Expression)
                    {
                        m_LoginUsers.o_Contact.Where.expression = Expression;
                    }
                    

                    public void Contact_AddParameter(DBConnectionControl4.SQL_Parameter par)
                    {
                        m_LoginUsers.o_Contact.Where.AddParameter(par);
                    }
                    
                    public bool username
                    {
                        get {return m_LoginUsers.o_username.Where.enabled;}
                        set {m_LoginUsers.o_username.Where.enabled = value;}
                    }
                    
                    public void username_Expression(string Expression)
                    {
                        m_LoginUsers.o_username.Where.expression = Expression;
                    }
                    

                    public void username_AddParameter(DBConnectionControl4.SQL_Parameter par)
                    {
                        m_LoginUsers.o_username.Where.AddParameter(par);
                    }
                    
                    public bool password
                    {
                        get {return m_LoginUsers.o_password.Where.enabled;}
                        set {m_LoginUsers.o_password.Where.enabled = value;}
                    }
                    
                    public void password_Expression(string Expression)
                    {
                        m_LoginUsers.o_password.Where.expression = Expression;
                    }
                    

                    public void password_AddParameter(DBConnectionControl4.SQL_Parameter par)
                    {
                        m_LoginUsers.o_password.Where.AddParameter(par);
                    }
                    
                    public bool enabled
                    {
                        get {return m_LoginUsers.o_enabled.Where.enabled;}
                        set {m_LoginUsers.o_enabled.Where.enabled = value;}
                    }
                    
                    public void enabled_Expression(string Expression)
                    {
                        m_LoginUsers.o_enabled.Where.expression = Expression;
                    }
                    

                    public void enabled_AddParameter(DBConnectionControl4.SQL_Parameter par)
                    {
                        m_LoginUsers.o_enabled.Where.AddParameter(par);
                    }
                    
                    public bool ChangePasswordOnFirstLogin
                    {
                        get {return m_LoginUsers.o_ChangePasswordOnFirstLogin.Where.enabled;}
                        set {m_LoginUsers.o_ChangePasswordOnFirstLogin.Where.enabled = value;}
                    }
                    
                    public void ChangePasswordOnFirstLogin_Expression(string Expression)
                    {
                        m_LoginUsers.o_ChangePasswordOnFirstLogin.Where.expression = Expression;
                    }
                    

                    public void ChangePasswordOnFirstLogin_AddParameter(DBConnectionControl4.SQL_Parameter par)
                    {
                        m_LoginUsers.o_ChangePasswordOnFirstLogin.Where.AddParameter(par);
                    }
                    
                    public bool Time_When_UserSetsItsOwnPassword
                    {
                        get {return m_LoginUsers.o_Time_When_UserSetsItsOwnPassword.Where.enabled;}
                        set {m_LoginUsers.o_Time_When_UserSetsItsOwnPassword.Where.enabled = value;}
                    }
                    
                    public void Time_When_UserSetsItsOwnPassword_Expression(string Expression)
                    {
                        m_LoginUsers.o_Time_When_UserSetsItsOwnPassword.Where.expression = Expression;
                    }
                    

                    public void Time_When_UserSetsItsOwnPassword_AddParameter(DBConnectionControl4.SQL_Parameter par)
                    {
                        m_LoginUsers.o_Time_When_UserSetsItsOwnPassword.Where.AddParameter(par);
                    }
                    
                    public bool PasswordNeverExpires
                    {
                        get {return m_LoginUsers.o_PasswordNeverExpires.Where.enabled;}
                        set {m_LoginUsers.o_PasswordNeverExpires.Where.enabled = value;}
                    }
                    
                    public void PasswordNeverExpires_Expression(string Expression)
                    {
                        m_LoginUsers.o_PasswordNeverExpires.Where.expression = Expression;
                    }
                    

                    public void PasswordNeverExpires_AddParameter(DBConnectionControl4.SQL_Parameter par)
                    {
                        m_LoginUsers.o_PasswordNeverExpires.Where.AddParameter(par);
                    }
                    
                    public bool Maximum_password_age_in_days
                    {
                        get {return m_LoginUsers.o_Maximum_password_age_in_days.Where.enabled;}
                        set {m_LoginUsers.o_Maximum_password_age_in_days.Where.enabled = value;}
                    }
                    
                    public void Maximum_password_age_in_days_Expression(string Expression)
                    {
                        m_LoginUsers.o_Maximum_password_age_in_days.Where.expression = Expression;
                    }
                    

                    public void Maximum_password_age_in_days_AddParameter(DBConnectionControl4.SQL_Parameter par)
                    {
                        m_LoginUsers.o_Maximum_password_age_in_days.Where.AddParameter(par);
                    }
                    
               public void all(bool bVal)
               {

                    this.id = bVal;
                    
                    this.first_name = bVal;
                    
                    this.last_name = bVal;
                    
                    this.Identity = bVal;
                    
                    this.Contact = bVal;
                    
                    this.username = bVal;
                    
                    this.password = bVal;
                    
                    this.enabled = bVal;
                    
                    this.ChangePasswordOnFirstLogin = bVal;
                    
                    this.Time_When_UserSetsItsOwnPassword = bVal;
                    
                    this.PasswordNeverExpires = bVal;
                    
                    this.Maximum_password_age_in_days = bVal;
                    
               }
    
           }

        public void UpdateObjects(DataRow dr)
           {

                    if (o_id.Select.enabled)
                    {
                        if (o_id.Select.IsExpression)
                        {
                          if (dr[o_id.Select.alternate_column_name] != null)
                          {
                            if (dr[o_id.Select.alternate_column_name].GetType() != typeof(System.DBNull))
                            {
                              o_id.obj  = dr[o_id.Select.alternate_column_name];
                            }
                          }
                        }
                        else
                        {
                          if (dr[LoginUsers.id.name] != null)
                          {
                            if (dr[LoginUsers.id.name].GetType() != typeof(System.DBNull))
                            {
                            o_id.id_  = (int) dr[LoginUsers.id.name];
                            }
                          }
                        }

                    }
                    if (o_first_name.Select.enabled)
                    {
                        if (o_first_name.Select.IsExpression)
                        {
                          if (dr[o_first_name.Select.alternate_column_name] != null)
                          {
                            if (dr[o_first_name.Select.alternate_column_name].GetType() != typeof(System.DBNull))
                            {
                              o_first_name.obj  = dr[o_first_name.Select.alternate_column_name];
                            }
                          }
                        }
                        else
                        {
                          if (dr[LoginUsers.first_name.name] != null)
                          {
                            if (dr[LoginUsers.first_name.name].GetType() != typeof(System.DBNull))
                            {
                            o_first_name.first_name_  = (string) dr[LoginUsers.first_name.name];
                            }
                          }
                        }

                    }
                    if (o_last_name.Select.enabled)
                    {
                        if (o_last_name.Select.IsExpression)
                        {
                          if (dr[o_last_name.Select.alternate_column_name] != null)
                          {
                            if (dr[o_last_name.Select.alternate_column_name].GetType() != typeof(System.DBNull))
                            {
                              o_last_name.obj  = dr[o_last_name.Select.alternate_column_name];
                            }
                          }
                        }
                        else
                        {
                          if (dr[LoginUsers.last_name.name] != null)
                          {
                            if (dr[LoginUsers.last_name.name].GetType() != typeof(System.DBNull))
                            {
                            o_last_name.last_name_  = (string) dr[LoginUsers.last_name.name];
                            }
                          }
                        }

                    }
                    if (o_Identity.Select.enabled)
                    {
                        if (o_Identity.Select.IsExpression)
                        {
                          if (dr[o_Identity.Select.alternate_column_name] != null)
                          {
                            if (dr[o_Identity.Select.alternate_column_name].GetType() != typeof(System.DBNull))
                            {
                              o_Identity.obj  = dr[o_Identity.Select.alternate_column_name];
                            }
                          }
                        }
                        else
                        {
                          if (dr[LoginUsers.Identity.name] != null)
                          {
                            if (dr[LoginUsers.Identity.name].GetType() != typeof(System.DBNull))
                            {
                            o_Identity.Identity_  = (string) dr[LoginUsers.Identity.name];
                            }
                          }
                        }

                    }
                    if (o_Contact.Select.enabled)
                    {
                        if (o_Contact.Select.IsExpression)
                        {
                          if (dr[o_Contact.Select.alternate_column_name] != null)
                          {
                            if (dr[o_Contact.Select.alternate_column_name].GetType() != typeof(System.DBNull))
                            {
                              o_Contact.obj  = dr[o_Contact.Select.alternate_column_name];
                            }
                          }
                        }
                        else
                        {
                          if (dr[LoginUsers.Contact.name] != null)
                          {
                            if (dr[LoginUsers.Contact.name].GetType() != typeof(System.DBNull))
                            {
                            o_Contact.Contact_  = (string) dr[LoginUsers.Contact.name];
                            }
                          }
                        }

                    }
                    if (o_username.Select.enabled)
                    {
                        if (o_username.Select.IsExpression)
                        {
                          if (dr[o_username.Select.alternate_column_name] != null)
                          {
                            if (dr[o_username.Select.alternate_column_name].GetType() != typeof(System.DBNull))
                            {
                              o_username.obj  = dr[o_username.Select.alternate_column_name];
                            }
                          }
                        }
                        else
                        {
                          if (dr[LoginUsers.username.name] != null)
                          {
                            if (dr[LoginUsers.username.name].GetType() != typeof(System.DBNull))
                            {
                            o_username.username_  = (string) dr[LoginUsers.username.name];
                            }
                          }
                        }

                    }
                    if (o_password.Select.enabled)
                    {
                        if (o_password.Select.IsExpression)
                        {
                          if (dr[o_password.Select.alternate_column_name] != null)
                          {
                            if (dr[o_password.Select.alternate_column_name].GetType() != typeof(System.DBNull))
                            {
                              o_password.obj  = dr[o_password.Select.alternate_column_name];
                            }
                          }
                        }
                        else
                        {
                          if (dr[LoginUsers.password.name] != null)
                          {
                            if (dr[LoginUsers.password.name].GetType() != typeof(System.DBNull))
                            {
                            o_password.password_  = (Byte[]) dr[LoginUsers.password.name];
                            }
                          }
                        }

                    }
                    if (o_enabled.Select.enabled)
                    {
                        if (o_enabled.Select.IsExpression)
                        {
                          if (dr[o_enabled.Select.alternate_column_name] != null)
                          {
                            if (dr[o_enabled.Select.alternate_column_name].GetType() != typeof(System.DBNull))
                            {
                              o_enabled.obj  = dr[o_enabled.Select.alternate_column_name];
                            }
                          }
                        }
                        else
                        {
                          if (dr[LoginUsers.enabled.name] != null)
                          {
                            if (dr[LoginUsers.enabled.name].GetType() != typeof(System.DBNull))
                            {
                            o_enabled.enabled_  = (bool) dr[LoginUsers.enabled.name];
                            }
                          }
                        }

                    }
                    if (o_ChangePasswordOnFirstLogin.Select.enabled)
                    {
                        if (o_ChangePasswordOnFirstLogin.Select.IsExpression)
                        {
                          if (dr[o_ChangePasswordOnFirstLogin.Select.alternate_column_name] != null)
                          {
                            if (dr[o_ChangePasswordOnFirstLogin.Select.alternate_column_name].GetType() != typeof(System.DBNull))
                            {
                              o_ChangePasswordOnFirstLogin.obj  = dr[o_ChangePasswordOnFirstLogin.Select.alternate_column_name];
                            }
                          }
                        }
                        else
                        {
                          if (dr[LoginUsers.ChangePasswordOnFirstLogin.name] != null)
                          {
                            if (dr[LoginUsers.ChangePasswordOnFirstLogin.name].GetType() != typeof(System.DBNull))
                            {
                            o_ChangePasswordOnFirstLogin.ChangePasswordOnFirstLogin_  = (bool) dr[LoginUsers.ChangePasswordOnFirstLogin.name];
                            }
                          }
                        }

                    }
                    if (o_Time_When_UserSetsItsOwnPassword.Select.enabled)
                    {
                        if (o_Time_When_UserSetsItsOwnPassword.Select.IsExpression)
                        {
                          if (dr[o_Time_When_UserSetsItsOwnPassword.Select.alternate_column_name] != null)
                          {
                            if (dr[o_Time_When_UserSetsItsOwnPassword.Select.alternate_column_name].GetType() != typeof(System.DBNull))
                            {
                              o_Time_When_UserSetsItsOwnPassword.obj  = dr[o_Time_When_UserSetsItsOwnPassword.Select.alternate_column_name];
                            }
                          }
                        }
                        else
                        {
                          if (dr[LoginUsers.Time_When_UserSetsItsOwnPassword.name] != null)
                          {
                            if (dr[LoginUsers.Time_When_UserSetsItsOwnPassword.name].GetType() != typeof(System.DBNull))
                            {
                            o_Time_When_UserSetsItsOwnPassword.Time_When_UserSetsItsOwnPassword_  = (DateTime) dr[LoginUsers.Time_When_UserSetsItsOwnPassword.name];
                            }
                          }
                        }

                    }
                    if (o_PasswordNeverExpires.Select.enabled)
                    {
                        if (o_PasswordNeverExpires.Select.IsExpression)
                        {
                          if (dr[o_PasswordNeverExpires.Select.alternate_column_name] != null)
                          {
                            if (dr[o_PasswordNeverExpires.Select.alternate_column_name].GetType() != typeof(System.DBNull))
                            {
                              o_PasswordNeverExpires.obj  = dr[o_PasswordNeverExpires.Select.alternate_column_name];
                            }
                          }
                        }
                        else
                        {
                          if (dr[LoginUsers.PasswordNeverExpires.name] != null)
                          {
                            if (dr[LoginUsers.PasswordNeverExpires.name].GetType() != typeof(System.DBNull))
                            {
                            o_PasswordNeverExpires.PasswordNeverExpires_  = (bool) dr[LoginUsers.PasswordNeverExpires.name];
                            }
                          }
                        }

                    }
                    if (o_Maximum_password_age_in_days.Select.enabled)
                    {
                        if (o_Maximum_password_age_in_days.Select.IsExpression)
                        {
                          if (dr[o_Maximum_password_age_in_days.Select.alternate_column_name] != null)
                          {
                            if (dr[o_Maximum_password_age_in_days.Select.alternate_column_name].GetType() != typeof(System.DBNull))
                            {
                              o_Maximum_password_age_in_days.obj  = dr[o_Maximum_password_age_in_days.Select.alternate_column_name];
                            }
                          }
                        }
                        else
                        {
                          if (dr[LoginUsers.Maximum_password_age_in_days.name] != null)
                          {
                            if (dr[LoginUsers.Maximum_password_age_in_days.name].GetType() != typeof(System.DBNull))
                            {
                            o_Maximum_password_age_in_days.Maximum_password_age_in_days_  = (int) dr[LoginUsers.Maximum_password_age_in_days.name];
                            }
                          }
                        }

                    }
           }

    }
    public class LoginUsersAndLoginRoles:XTable
    {
        public const string tablename_const = "LoginUsersAndLoginRoles";
        public selection select;
        public WHERE where;

        public void Set_DataGridView_Headers(DataGridView dgv)
        {
            LoginUsersAndLoginRoles_lang m_LoginUsersAndLoginRoles_lang = new LoginUsersAndLoginRoles_lang();
            foreach (DataGridViewColumn dgvc in dgv.Columns)
            {
                foreach (ltext lt in m_LoginUsersAndLoginRoles_lang.col_headers)
                {
                    if (dgvc.Name.Equals(lt.name))
                    {
                        dgvc.HeaderText = lt.s;
                    }
                }
            }
        }


        public int RowsCount
        {
            get {return RowsCount();}
        }
        public void Clear()
        {
            clear();
        }

        public bool Read(ref string csError)
        {
          bool bRead = read(ref csError);
          if (Cursor>=0)
          {
             UpdateObjects(dt.Rows[Cursor]);
          }
          return bRead;
        }
        
        public class id:ValSet
           { 
             public const string name = "id";

             public int id_
             {
                get {return (int) obj;}
                set {obj = value;}
             }
           }
           public id o_id = new id();

        public class LoginUsers_id:ValSet
           { 
             public const string name = "LoginUsers_id";

             public int LoginUsers_id_
             {
                get {return (int) obj;}
                set {obj = value;}
             }
           }
           public LoginUsers_id o_LoginUsers_id = new LoginUsers_id();

        public class LoginRoles_id:ValSet
           { 
             public const string name = "LoginRoles_id";

             public int LoginRoles_id_
             {
                get {return (int) obj;}
                set {obj = value;}
             }
           }
           public LoginRoles_id o_LoginRoles_id = new LoginRoles_id();

        public LoginUsersAndLoginRoles(DBConnectionControl4.DBConnection xcon)
           {
                select = new selection(this);
                where  = new WHERE(this);
                m_con = xcon;
                tablename = LoginUsersAndLoginRoles.tablename_const;
                myUpdateObjects = UpdateObjects;


                    o_id.col_name = LoginUsersAndLoginRoles.id.name;
                    o_id.col_type.m_Type = "int";
                    o_id.col_type.bPRIMARY_KEY = true;
                    o_id.col_type.bFOREIGN_KEY = false;
                    o_id.col_type.bUNIQUE = false;
                    o_id.col_type.bNULL = false;
                    Add(o_id);
                    
                    o_LoginUsers_id.col_name = LoginUsersAndLoginRoles.LoginUsers_id.name;
                    o_LoginUsers_id.col_type.m_Type = "int";
                    o_LoginUsers_id.col_type.bPRIMARY_KEY = false;
                    o_LoginUsers_id.col_type.bFOREIGN_KEY = true;
                    o_LoginUsers_id.col_type.bUNIQUE = false;
                    o_LoginUsers_id.col_type.bNULL = false;
                    Add(o_LoginUsers_id);
                    
                    o_LoginRoles_id.col_name = LoginUsersAndLoginRoles.LoginRoles_id.name;
                    o_LoginRoles_id.col_type.m_Type = "int";
                    o_LoginRoles_id.col_type.bPRIMARY_KEY = false;
                    o_LoginRoles_id.col_type.bFOREIGN_KEY = true;
                    o_LoginRoles_id.col_type.bUNIQUE = false;
                    o_LoginRoles_id.col_type.bNULL = false;
                    Add(o_LoginRoles_id);
                    
           }

        public class selection
           {
                private LoginUsersAndLoginRoles m_LoginUsersAndLoginRoles;
                public selection(LoginUsersAndLoginRoles xLoginUsersAndLoginRoles)
                {
                    m_LoginUsersAndLoginRoles =  xLoginUsersAndLoginRoles;
                }

                    public bool id
                    {
                        get {return m_LoginUsersAndLoginRoles.o_id.Select.enabled;}
                        set {m_LoginUsersAndLoginRoles.o_id.Select.enabled = value;}
                    }
                    
                    public void id_Expression(string Expression,string xalternate_column_name)
                    {
                        m_LoginUsersAndLoginRoles.o_id.Select.expression = Expression;
                        m_LoginUsersAndLoginRoles.o_id.Select.alternate_column_name = xalternate_column_name;
                    }
                    
                    public bool LoginUsers_id
                    {
                        get {return m_LoginUsersAndLoginRoles.o_LoginUsers_id.Select.enabled;}
                        set {m_LoginUsersAndLoginRoles.o_LoginUsers_id.Select.enabled = value;}
                    }
                    
                    public void LoginUsers_id_Expression(string Expression,string xalternate_column_name)
                    {
                        m_LoginUsersAndLoginRoles.o_LoginUsers_id.Select.expression = Expression;
                        m_LoginUsersAndLoginRoles.o_LoginUsers_id.Select.alternate_column_name = xalternate_column_name;
                    }
                    
                    public bool LoginRoles_id
                    {
                        get {return m_LoginUsersAndLoginRoles.o_LoginRoles_id.Select.enabled;}
                        set {m_LoginUsersAndLoginRoles.o_LoginRoles_id.Select.enabled = value;}
                    }
                    
                    public void LoginRoles_id_Expression(string Expression,string xalternate_column_name)
                    {
                        m_LoginUsersAndLoginRoles.o_LoginRoles_id.Select.expression = Expression;
                        m_LoginUsersAndLoginRoles.o_LoginRoles_id.Select.alternate_column_name = xalternate_column_name;
                    }
                    
               public void all(bool bVal)
               {

                    this.id = bVal;
                    
                    this.LoginUsers_id = bVal;
                    
                    this.LoginRoles_id = bVal;
                    
               }
    
           }

        public class WHERE
           {
                private LoginUsersAndLoginRoles m_LoginUsersAndLoginRoles;
                public WHERE(LoginUsersAndLoginRoles xLoginUsersAndLoginRoles)
                {
                    m_LoginUsersAndLoginRoles =  xLoginUsersAndLoginRoles;
                }

                    public bool id
                    {
                        get {return m_LoginUsersAndLoginRoles.o_id.Where.enabled;}
                        set {m_LoginUsersAndLoginRoles.o_id.Where.enabled = value;}
                    }
                    
                    public void id_Expression(string Expression)
                    {
                        m_LoginUsersAndLoginRoles.o_id.Where.expression = Expression;
                    }
                    

                    public void id_AddParameter(DBConnectionControl4.SQL_Parameter par)
                    {
                        m_LoginUsersAndLoginRoles.o_id.Where.AddParameter(par);
                    }
                    
                    public bool LoginUsers_id
                    {
                        get {return m_LoginUsersAndLoginRoles.o_LoginUsers_id.Where.enabled;}
                        set {m_LoginUsersAndLoginRoles.o_LoginUsers_id.Where.enabled = value;}
                    }
                    
                    public void LoginUsers_id_Expression(string Expression)
                    {
                        m_LoginUsersAndLoginRoles.o_LoginUsers_id.Where.expression = Expression;
                    }
                    

                    public void LoginUsers_id_AddParameter(DBConnectionControl4.SQL_Parameter par)
                    {
                        m_LoginUsersAndLoginRoles.o_LoginUsers_id.Where.AddParameter(par);
                    }
                    
                    public bool LoginRoles_id
                    {
                        get {return m_LoginUsersAndLoginRoles.o_LoginRoles_id.Where.enabled;}
                        set {m_LoginUsersAndLoginRoles.o_LoginRoles_id.Where.enabled = value;}
                    }
                    
                    public void LoginRoles_id_Expression(string Expression)
                    {
                        m_LoginUsersAndLoginRoles.o_LoginRoles_id.Where.expression = Expression;
                    }
                    

                    public void LoginRoles_id_AddParameter(DBConnectionControl4.SQL_Parameter par)
                    {
                        m_LoginUsersAndLoginRoles.o_LoginRoles_id.Where.AddParameter(par);
                    }
                    
               public void all(bool bVal)
               {

                    this.id = bVal;
                    
                    this.LoginUsers_id = bVal;
                    
                    this.LoginRoles_id = bVal;
                    
               }
    
           }

        public void UpdateObjects(DataRow dr)
           {

                    if (o_id.Select.enabled)
                    {
                        if (o_id.Select.IsExpression)
                        {
                          if (dr[o_id.Select.alternate_column_name] != null)
                          {
                            if (dr[o_id.Select.alternate_column_name].GetType() != typeof(System.DBNull))
                            {
                              o_id.obj  = dr[o_id.Select.alternate_column_name];
                            }
                          }
                        }
                        else
                        {
                          if (dr[LoginUsersAndLoginRoles.id.name] != null)
                          {
                            if (dr[LoginUsersAndLoginRoles.id.name].GetType() != typeof(System.DBNull))
                            {
                            o_id.id_  = (int) dr[LoginUsersAndLoginRoles.id.name];
                            }
                          }
                        }

                    }
                    if (o_LoginUsers_id.Select.enabled)
                    {
                        if (o_LoginUsers_id.Select.IsExpression)
                        {
                          if (dr[o_LoginUsers_id.Select.alternate_column_name] != null)
                          {
                            if (dr[o_LoginUsers_id.Select.alternate_column_name].GetType() != typeof(System.DBNull))
                            {
                              o_LoginUsers_id.obj  = dr[o_LoginUsers_id.Select.alternate_column_name];
                            }
                          }
                        }
                        else
                        {
                          if (dr[LoginUsersAndLoginRoles.LoginUsers_id.name] != null)
                          {
                            if (dr[LoginUsersAndLoginRoles.LoginUsers_id.name].GetType() != typeof(System.DBNull))
                            {
                            o_LoginUsers_id.LoginUsers_id_  = (int) dr[LoginUsersAndLoginRoles.LoginUsers_id.name];
                            }
                          }
                        }

                    }
                    if (o_LoginRoles_id.Select.enabled)
                    {
                        if (o_LoginRoles_id.Select.IsExpression)
                        {
                          if (dr[o_LoginRoles_id.Select.alternate_column_name] != null)
                          {
                            if (dr[o_LoginRoles_id.Select.alternate_column_name].GetType() != typeof(System.DBNull))
                            {
                              o_LoginRoles_id.obj  = dr[o_LoginRoles_id.Select.alternate_column_name];
                            }
                          }
                        }
                        else
                        {
                          if (dr[LoginUsersAndLoginRoles.LoginRoles_id.name] != null)
                          {
                            if (dr[LoginUsersAndLoginRoles.LoginRoles_id.name].GetType() != typeof(System.DBNull))
                            {
                            o_LoginRoles_id.LoginRoles_id_  = (int) dr[LoginUsersAndLoginRoles.LoginRoles_id.name];
                            }
                          }
                        }

                    }
           }

    }

    public class Login_VIEW:XView
    {
        public const string tablename_const = "Login_VIEW";
        public selection select;
        public WHERE where;
        public int RowsCount
        {
            get {return RowsCount();}
        }
        public void Clear()
        {
            clear();
        }

        public bool Read(ref string csError)
        {
          bool bRead = read(ref csError);
          if (Cursor>=0)
          {
             UpdateObjects(dt.Rows[Cursor]);
          }
          return bRead;
        }
        
        public class Users_id:ValSet
           { 
             public const string name = "Users_id";
             public int Users_id_
             {
                get {return (int) obj;}
                set {obj = value;}
             }
           }
           public Users_id o_Users_id = new Users_id();

        public class first_name:ValSet
           { 
             public const string name = "first_name";
             public string first_name_
             {
                get {return (string) obj;}
                set {obj = value;}
             }
           }
           public first_name o_first_name = new first_name();

        public class last_name:ValSet
           { 
             public const string name = "last_name";
             public string last_name_
             {
                get {return (string) obj;}
                set {obj = value;}
             }
           }
           public last_name o_last_name = new last_name();

        public class Identity:ValSet
           { 
             public const string name = "Identity";
             public string Identity_
             {
                get {return (string) obj;}
                set {obj = value;}
             }
           }
           public Identity o_Identity = new Identity();

        public class Contact:ValSet
           { 
             public const string name = "Contact";
             public string Contact_
             {
                get {return (string) obj;}
                set {obj = value;}
             }
           }
           public Contact o_Contact = new Contact();

        public class username:ValSet
           { 
             public const string name = "username";
             public string username_
             {
                get {return (string) obj;}
                set {obj = value;}
             }
           }
           public username o_username = new username();

        public class password:ValSet
           { 
             public const string name = "password";
             public Byte[] password_
             {
                get {return (Byte[]) obj;}
                set {obj = value;}
             }
           }
           public password o_password = new password();

        public class PasswordNeverExpires:ValSet
           { 
             public const string name = "PasswordNeverExpires";
             public bool PasswordNeverExpires_
             {
                get {return (bool) obj;}
                set {obj = value;}
             }
           }
           public PasswordNeverExpires o_PasswordNeverExpires = new PasswordNeverExpires();

        public class enabled:ValSet
           { 
             public const string name = "enabled";
             public bool enabled_
             {
                get {return (bool) obj;}
                set {obj = value;}
             }
           }
           public enabled o_enabled = new enabled();

        public class Maximum_password_age_in_days:ValSet
           { 
             public const string name = "Maximum_password_age_in_days";
             public int Maximum_password_age_in_days_
             {
                get {return (int) obj;}
                set {obj = value;}
             }
           }
           public Maximum_password_age_in_days o_Maximum_password_age_in_days = new Maximum_password_age_in_days();

        public class Time_When_UserSetsItsOwnPassword:ValSet
           { 
             public const string name = "Time_When_UserSetsItsOwnPassword";
             public DateTime Time_When_UserSetsItsOwnPassword_
             {
                get {return (DateTime) obj;}
                set {obj = value;}
             }
           }
           public Time_When_UserSetsItsOwnPassword o_Time_When_UserSetsItsOwnPassword = new Time_When_UserSetsItsOwnPassword();

        public class ChangePasswordOnFirstLogin:ValSet
           { 
             public const string name = "ChangePasswordOnFirstLogin";
             public bool ChangePasswordOnFirstLogin_
             {
                get {return (bool) obj;}
                set {obj = value;}
             }
           }
           public ChangePasswordOnFirstLogin o_ChangePasswordOnFirstLogin = new ChangePasswordOnFirstLogin();

        public class Role_id:ValSet
           { 
             public const string name = "Role_id";
             public int Role_id_
             {
                get {return (int) obj;}
                set {obj = value;}
             }
           }
           public Role_id o_Role_id = new Role_id();

        public class RoleName:ValSet
           { 
             public const string name = "RoleName";
             public string RoleName_
             {
                get {return (string) obj;}
                set {obj = value;}
             }
           }
           public RoleName o_RoleName = new RoleName();

        public class RoleDescription:ValSet
           { 
             public const string name = "RoleDescription";
             public string RoleDescription_
             {
                get {return (string) obj;}
                set {obj = value;}
             }
           }
           public RoleDescription o_RoleDescription = new RoleDescription();

        public Login_VIEW(DBConnectionControl4.DBConnection xcon)
           {
                select = new selection(this);
                where  = new WHERE(this);
                m_con = xcon;
                tablename = Login_VIEW.tablename_const;
                myUpdateObjects = UpdateObjects;


                    o_Users_id.col_name = Login_VIEW.Users_id.name;
                    o_Users_id.col_type.m_Type = "int";
                    Add(o_Users_id);
                    
                    o_first_name.col_name = Login_VIEW.first_name.name;
                    o_first_name.col_type.m_Type = "nvarchar";
                    Add(o_first_name);
                    
                    o_last_name.col_name = Login_VIEW.last_name.name;
                    o_last_name.col_type.m_Type = "nvarchar";
                    Add(o_last_name);
                    
                    o_Identity.col_name = Login_VIEW.Identity.name;
                    o_Identity.col_type.m_Type = "nvarchar";
                    Add(o_Identity);
                    
                    o_Contact.col_name = Login_VIEW.Contact.name;
                    o_Contact.col_type.m_Type = "nvarchar";
                    Add(o_Contact);
                    
                    o_username.col_name = Login_VIEW.username.name;
                    o_username.col_type.m_Type = "nvarchar";
                    Add(o_username);
                    
                    o_password.col_name = Login_VIEW.password.name;
                    o_password.col_type.m_Type = "varbinary";
                    Add(o_password);
                    
                    o_PasswordNeverExpires.col_name = Login_VIEW.PasswordNeverExpires.name;
                    o_PasswordNeverExpires.col_type.m_Type = "bit";
                    Add(o_PasswordNeverExpires);
                    
                    o_enabled.col_name = Login_VIEW.enabled.name;
                    o_enabled.col_type.m_Type = "bit";
                    Add(o_enabled);
                    
                    o_Maximum_password_age_in_days.col_name = Login_VIEW.Maximum_password_age_in_days.name;
                    o_Maximum_password_age_in_days.col_type.m_Type = "int";
                    Add(o_Maximum_password_age_in_days);
                    
                    o_Time_When_UserSetsItsOwnPassword.col_name = Login_VIEW.Time_When_UserSetsItsOwnPassword.name;
                    o_Time_When_UserSetsItsOwnPassword.col_type.m_Type = "datetime";
                    Add(o_Time_When_UserSetsItsOwnPassword);
                    
                    o_ChangePasswordOnFirstLogin.col_name = Login_VIEW.ChangePasswordOnFirstLogin.name;
                    o_ChangePasswordOnFirstLogin.col_type.m_Type = "bit";
                    Add(o_ChangePasswordOnFirstLogin);
                    
                    o_Role_id.col_name = Login_VIEW.Role_id.name;
                    o_Role_id.col_type.m_Type = "int";
                    Add(o_Role_id);
                    
                    o_RoleName.col_name = Login_VIEW.RoleName.name;
                    o_RoleName.col_type.m_Type = "nvarchar";
                    Add(o_RoleName);
                    
                    o_RoleDescription.col_name = Login_VIEW.RoleDescription.name;
                    o_RoleDescription.col_type.m_Type = "nvarchar";
                    Add(o_RoleDescription);
                    
           }

        public class selection
           {
                private Login_VIEW m_Login_VIEW;
                public selection(Login_VIEW xLogin_VIEW)
                {
                    m_Login_VIEW =  xLogin_VIEW;
                }

                    public bool Users_id
                    {
                        get {return m_Login_VIEW.o_Users_id.Select.enabled;}
                        set {m_Login_VIEW.o_Users_id.Select.enabled = value;}
                    }
                    
                    public void Users_id_Expression(string Expression,string xalternate_column_name)
                    {
                        m_Login_VIEW.o_Users_id.Select.expression = Expression;
                        m_Login_VIEW.o_Users_id.Select.alternate_column_name = xalternate_column_name;
                    }
                    
                    public bool first_name
                    {
                        get {return m_Login_VIEW.o_first_name.Select.enabled;}
                        set {m_Login_VIEW.o_first_name.Select.enabled = value;}
                    }
                    
                    public void first_name_Expression(string Expression,string xalternate_column_name)
                    {
                        m_Login_VIEW.o_first_name.Select.expression = Expression;
                        m_Login_VIEW.o_first_name.Select.alternate_column_name = xalternate_column_name;
                    }
                    
                    public bool last_name
                    {
                        get {return m_Login_VIEW.o_last_name.Select.enabled;}
                        set {m_Login_VIEW.o_last_name.Select.enabled = value;}
                    }
                    
                    public void last_name_Expression(string Expression,string xalternate_column_name)
                    {
                        m_Login_VIEW.o_last_name.Select.expression = Expression;
                        m_Login_VIEW.o_last_name.Select.alternate_column_name = xalternate_column_name;
                    }
                    
                    public bool Identity
                    {
                        get {return m_Login_VIEW.o_Identity.Select.enabled;}
                        set {m_Login_VIEW.o_Identity.Select.enabled = value;}
                    }
                    
                    public void Identity_Expression(string Expression,string xalternate_column_name)
                    {
                        m_Login_VIEW.o_Identity.Select.expression = Expression;
                        m_Login_VIEW.o_Identity.Select.alternate_column_name = xalternate_column_name;
                    }
                    
                    public bool Contact
                    {
                        get {return m_Login_VIEW.o_Contact.Select.enabled;}
                        set {m_Login_VIEW.o_Contact.Select.enabled = value;}
                    }
                    
                    public void Contact_Expression(string Expression,string xalternate_column_name)
                    {
                        m_Login_VIEW.o_Contact.Select.expression = Expression;
                        m_Login_VIEW.o_Contact.Select.alternate_column_name = xalternate_column_name;
                    }
                    
                    public bool username
                    {
                        get {return m_Login_VIEW.o_username.Select.enabled;}
                        set {m_Login_VIEW.o_username.Select.enabled = value;}
                    }
                    
                    public void username_Expression(string Expression,string xalternate_column_name)
                    {
                        m_Login_VIEW.o_username.Select.expression = Expression;
                        m_Login_VIEW.o_username.Select.alternate_column_name = xalternate_column_name;
                    }
                    
                    public bool password
                    {
                        get {return m_Login_VIEW.o_password.Select.enabled;}
                        set {m_Login_VIEW.o_password.Select.enabled = value;}
                    }
                    
                    public void password_Expression(string Expression,string xalternate_column_name)
                    {
                        m_Login_VIEW.o_password.Select.expression = Expression;
                        m_Login_VIEW.o_password.Select.alternate_column_name = xalternate_column_name;
                    }
                    
                    public bool PasswordNeverExpires
                    {
                        get {return m_Login_VIEW.o_PasswordNeverExpires.Select.enabled;}
                        set {m_Login_VIEW.o_PasswordNeverExpires.Select.enabled = value;}
                    }
                    
                    public void PasswordNeverExpires_Expression(string Expression,string xalternate_column_name)
                    {
                        m_Login_VIEW.o_PasswordNeverExpires.Select.expression = Expression;
                        m_Login_VIEW.o_PasswordNeverExpires.Select.alternate_column_name = xalternate_column_name;
                    }
                    
                    public bool enabled
                    {
                        get {return m_Login_VIEW.o_enabled.Select.enabled;}
                        set {m_Login_VIEW.o_enabled.Select.enabled = value;}
                    }
                    
                    public void enabled_Expression(string Expression,string xalternate_column_name)
                    {
                        m_Login_VIEW.o_enabled.Select.expression = Expression;
                        m_Login_VIEW.o_enabled.Select.alternate_column_name = xalternate_column_name;
                    }
                    
                    public bool Maximum_password_age_in_days
                    {
                        get {return m_Login_VIEW.o_Maximum_password_age_in_days.Select.enabled;}
                        set {m_Login_VIEW.o_Maximum_password_age_in_days.Select.enabled = value;}
                    }
                    
                    public void Maximum_password_age_in_days_Expression(string Expression,string xalternate_column_name)
                    {
                        m_Login_VIEW.o_Maximum_password_age_in_days.Select.expression = Expression;
                        m_Login_VIEW.o_Maximum_password_age_in_days.Select.alternate_column_name = xalternate_column_name;
                    }
                    
                    public bool Time_When_UserSetsItsOwnPassword
                    {
                        get {return m_Login_VIEW.o_Time_When_UserSetsItsOwnPassword.Select.enabled;}
                        set {m_Login_VIEW.o_Time_When_UserSetsItsOwnPassword.Select.enabled = value;}
                    }
                    
                    public void Time_When_UserSetsItsOwnPassword_Expression(string Expression,string xalternate_column_name)
                    {
                        m_Login_VIEW.o_Time_When_UserSetsItsOwnPassword.Select.expression = Expression;
                        m_Login_VIEW.o_Time_When_UserSetsItsOwnPassword.Select.alternate_column_name = xalternate_column_name;
                    }
                    
                    public bool ChangePasswordOnFirstLogin
                    {
                        get {return m_Login_VIEW.o_ChangePasswordOnFirstLogin.Select.enabled;}
                        set {m_Login_VIEW.o_ChangePasswordOnFirstLogin.Select.enabled = value;}
                    }
                    
                    public void ChangePasswordOnFirstLogin_Expression(string Expression,string xalternate_column_name)
                    {
                        m_Login_VIEW.o_ChangePasswordOnFirstLogin.Select.expression = Expression;
                        m_Login_VIEW.o_ChangePasswordOnFirstLogin.Select.alternate_column_name = xalternate_column_name;
                    }
                    
                    public bool Role_id
                    {
                        get {return m_Login_VIEW.o_Role_id.Select.enabled;}
                        set {m_Login_VIEW.o_Role_id.Select.enabled = value;}
                    }
                    
                    public void Role_id_Expression(string Expression,string xalternate_column_name)
                    {
                        m_Login_VIEW.o_Role_id.Select.expression = Expression;
                        m_Login_VIEW.o_Role_id.Select.alternate_column_name = xalternate_column_name;
                    }
                    
                    public bool RoleName
                    {
                        get {return m_Login_VIEW.o_RoleName.Select.enabled;}
                        set {m_Login_VIEW.o_RoleName.Select.enabled = value;}
                    }
                    
                    public void RoleName_Expression(string Expression,string xalternate_column_name)
                    {
                        m_Login_VIEW.o_RoleName.Select.expression = Expression;
                        m_Login_VIEW.o_RoleName.Select.alternate_column_name = xalternate_column_name;
                    }
                    
                    public bool RoleDescription
                    {
                        get {return m_Login_VIEW.o_RoleDescription.Select.enabled;}
                        set {m_Login_VIEW.o_RoleDescription.Select.enabled = value;}
                    }
                    
                    public void RoleDescription_Expression(string Expression,string xalternate_column_name)
                    {
                        m_Login_VIEW.o_RoleDescription.Select.expression = Expression;
                        m_Login_VIEW.o_RoleDescription.Select.alternate_column_name = xalternate_column_name;
                    }
                    
               public void all(bool bVal)
               {

                    this.Users_id = bVal;
                    
                    this.first_name = bVal;
                    
                    this.last_name = bVal;
                    
                    this.Identity = bVal;
                    
                    this.Contact = bVal;
                    
                    this.username = bVal;
                    
                    this.password = bVal;
                    
                    this.PasswordNeverExpires = bVal;
                    
                    this.enabled = bVal;
                    
                    this.Maximum_password_age_in_days = bVal;
                    
                    this.Time_When_UserSetsItsOwnPassword = bVal;
                    
                    this.ChangePasswordOnFirstLogin = bVal;
                    
                    this.Role_id = bVal;
                    
                    this.RoleName = bVal;
                    
                    this.RoleDescription = bVal;
                    
               }
    
           }

        public class WHERE
           {
                private Login_VIEW m_Login_VIEW;
                public WHERE(Login_VIEW xLogin_VIEW)
                {
                    m_Login_VIEW =  xLogin_VIEW;
                }

                    public bool Users_id
                    {
                        get {return m_Login_VIEW.o_Users_id.Where.enabled;}
                        set {m_Login_VIEW.o_Users_id.Where.enabled = value;}
                    }
                    
                    public void Users_id_Expression(string Expression)
                    {
                        m_Login_VIEW.o_Users_id.Where.expression = Expression;
                    }
                    

                    public void Users_id_AddParameter(DBConnectionControl4.SQL_Parameter par)
                    {
                        m_Login_VIEW.o_Users_id.Where.AddParameter(par);
                    }
                    
                    public bool first_name
                    {
                        get {return m_Login_VIEW.o_first_name.Where.enabled;}
                        set {m_Login_VIEW.o_first_name.Where.enabled = value;}
                    }
                    
                    public void first_name_Expression(string Expression)
                    {
                        m_Login_VIEW.o_first_name.Where.expression = Expression;
                    }
                    

                    public void first_name_AddParameter(DBConnectionControl4.SQL_Parameter par)
                    {
                        m_Login_VIEW.o_first_name.Where.AddParameter(par);
                    }
                    
                    public bool last_name
                    {
                        get {return m_Login_VIEW.o_last_name.Where.enabled;}
                        set {m_Login_VIEW.o_last_name.Where.enabled = value;}
                    }
                    
                    public void last_name_Expression(string Expression)
                    {
                        m_Login_VIEW.o_last_name.Where.expression = Expression;
                    }
                    

                    public void last_name_AddParameter(DBConnectionControl4.SQL_Parameter par)
                    {
                        m_Login_VIEW.o_last_name.Where.AddParameter(par);
                    }
                    
                    public bool Identity
                    {
                        get {return m_Login_VIEW.o_Identity.Where.enabled;}
                        set {m_Login_VIEW.o_Identity.Where.enabled = value;}
                    }
                    
                    public void Identity_Expression(string Expression)
                    {
                        m_Login_VIEW.o_Identity.Where.expression = Expression;
                    }
                    

                    public void Identity_AddParameter(DBConnectionControl4.SQL_Parameter par)
                    {
                        m_Login_VIEW.o_Identity.Where.AddParameter(par);
                    }
                    
                    public bool Contact
                    {
                        get {return m_Login_VIEW.o_Contact.Where.enabled;}
                        set {m_Login_VIEW.o_Contact.Where.enabled = value;}
                    }
                    
                    public void Contact_Expression(string Expression)
                    {
                        m_Login_VIEW.o_Contact.Where.expression = Expression;
                    }
                    

                    public void Contact_AddParameter(DBConnectionControl4.SQL_Parameter par)
                    {
                        m_Login_VIEW.o_Contact.Where.AddParameter(par);
                    }
                    
                    public bool username
                    {
                        get {return m_Login_VIEW.o_username.Where.enabled;}
                        set {m_Login_VIEW.o_username.Where.enabled = value;}
                    }
                    
                    public void username_Expression(string Expression)
                    {
                        m_Login_VIEW.o_username.Where.expression = Expression;
                    }
                    

                    public void username_AddParameter(DBConnectionControl4.SQL_Parameter par)
                    {
                        m_Login_VIEW.o_username.Where.AddParameter(par);
                    }
                    
                    public bool password
                    {
                        get {return m_Login_VIEW.o_password.Where.enabled;}
                        set {m_Login_VIEW.o_password.Where.enabled = value;}
                    }
                    
                    public void password_Expression(string Expression)
                    {
                        m_Login_VIEW.o_password.Where.expression = Expression;
                    }
                    

                    public void password_AddParameter(DBConnectionControl4.SQL_Parameter par)
                    {
                        m_Login_VIEW.o_password.Where.AddParameter(par);
                    }
                    
                    public bool PasswordNeverExpires
                    {
                        get {return m_Login_VIEW.o_PasswordNeverExpires.Where.enabled;}
                        set {m_Login_VIEW.o_PasswordNeverExpires.Where.enabled = value;}
                    }
                    
                    public void PasswordNeverExpires_Expression(string Expression)
                    {
                        m_Login_VIEW.o_PasswordNeverExpires.Where.expression = Expression;
                    }
                    

                    public void PasswordNeverExpires_AddParameter(DBConnectionControl4.SQL_Parameter par)
                    {
                        m_Login_VIEW.o_PasswordNeverExpires.Where.AddParameter(par);
                    }
                    
                    public bool enabled
                    {
                        get {return m_Login_VIEW.o_enabled.Where.enabled;}
                        set {m_Login_VIEW.o_enabled.Where.enabled = value;}
                    }
                    
                    public void enabled_Expression(string Expression)
                    {
                        m_Login_VIEW.o_enabled.Where.expression = Expression;
                    }
                    

                    public void enabled_AddParameter(DBConnectionControl4.SQL_Parameter par)
                    {
                        m_Login_VIEW.o_enabled.Where.AddParameter(par);
                    }
                    
                    public bool Maximum_password_age_in_days
                    {
                        get {return m_Login_VIEW.o_Maximum_password_age_in_days.Where.enabled;}
                        set {m_Login_VIEW.o_Maximum_password_age_in_days.Where.enabled = value;}
                    }
                    
                    public void Maximum_password_age_in_days_Expression(string Expression)
                    {
                        m_Login_VIEW.o_Maximum_password_age_in_days.Where.expression = Expression;
                    }
                    

                    public void Maximum_password_age_in_days_AddParameter(DBConnectionControl4.SQL_Parameter par)
                    {
                        m_Login_VIEW.o_Maximum_password_age_in_days.Where.AddParameter(par);
                    }
                    
                    public bool Time_When_UserSetsItsOwnPassword
                    {
                        get {return m_Login_VIEW.o_Time_When_UserSetsItsOwnPassword.Where.enabled;}
                        set {m_Login_VIEW.o_Time_When_UserSetsItsOwnPassword.Where.enabled = value;}
                    }
                    
                    public void Time_When_UserSetsItsOwnPassword_Expression(string Expression)
                    {
                        m_Login_VIEW.o_Time_When_UserSetsItsOwnPassword.Where.expression = Expression;
                    }
                    

                    public void Time_When_UserSetsItsOwnPassword_AddParameter(DBConnectionControl4.SQL_Parameter par)
                    {
                        m_Login_VIEW.o_Time_When_UserSetsItsOwnPassword.Where.AddParameter(par);
                    }
                    
                    public bool ChangePasswordOnFirstLogin
                    {
                        get {return m_Login_VIEW.o_ChangePasswordOnFirstLogin.Where.enabled;}
                        set {m_Login_VIEW.o_ChangePasswordOnFirstLogin.Where.enabled = value;}
                    }
                    
                    public void ChangePasswordOnFirstLogin_Expression(string Expression)
                    {
                        m_Login_VIEW.o_ChangePasswordOnFirstLogin.Where.expression = Expression;
                    }
                    

                    public void ChangePasswordOnFirstLogin_AddParameter(DBConnectionControl4.SQL_Parameter par)
                    {
                        m_Login_VIEW.o_ChangePasswordOnFirstLogin.Where.AddParameter(par);
                    }
                    
                    public bool Role_id
                    {
                        get {return m_Login_VIEW.o_Role_id.Where.enabled;}
                        set {m_Login_VIEW.o_Role_id.Where.enabled = value;}
                    }
                    
                    public void Role_id_Expression(string Expression)
                    {
                        m_Login_VIEW.o_Role_id.Where.expression = Expression;
                    }
                    

                    public void Role_id_AddParameter(DBConnectionControl4.SQL_Parameter par)
                    {
                        m_Login_VIEW.o_Role_id.Where.AddParameter(par);
                    }
                    
                    public bool RoleName
                    {
                        get {return m_Login_VIEW.o_RoleName.Where.enabled;}
                        set {m_Login_VIEW.o_RoleName.Where.enabled = value;}
                    }
                    
                    public void RoleName_Expression(string Expression)
                    {
                        m_Login_VIEW.o_RoleName.Where.expression = Expression;
                    }
                    

                    public void RoleName_AddParameter(DBConnectionControl4.SQL_Parameter par)
                    {
                        m_Login_VIEW.o_RoleName.Where.AddParameter(par);
                    }
                    
                    public bool RoleDescription
                    {
                        get {return m_Login_VIEW.o_RoleDescription.Where.enabled;}
                        set {m_Login_VIEW.o_RoleDescription.Where.enabled = value;}
                    }
                    
                    public void RoleDescription_Expression(string Expression)
                    {
                        m_Login_VIEW.o_RoleDescription.Where.expression = Expression;
                    }
                    

                    public void RoleDescription_AddParameter(DBConnectionControl4.SQL_Parameter par)
                    {
                        m_Login_VIEW.o_RoleDescription.Where.AddParameter(par);
                    }
                    
               public void all(bool bVal)
               {

                    this.Users_id = bVal;
                    
                    this.first_name = bVal;
                    
                    this.last_name = bVal;
                    
                    this.Identity = bVal;
                    
                    this.Contact = bVal;
                    
                    this.username = bVal;
                    
                    this.password = bVal;
                    
                    this.PasswordNeverExpires = bVal;
                    
                    this.enabled = bVal;
                    
                    this.Maximum_password_age_in_days = bVal;
                    
                    this.Time_When_UserSetsItsOwnPassword = bVal;
                    
                    this.ChangePasswordOnFirstLogin = bVal;
                    
                    this.Role_id = bVal;
                    
                    this.RoleName = bVal;
                    
                    this.RoleDescription = bVal;
                    
               }
    
           }

        public void UpdateObjects(DataRow dr)
           {

                    if (o_Users_id.Select.enabled)
                    {
                      if (dr[Login_VIEW.Users_id.name] != null)
                      {
                        if (dr[Login_VIEW.Users_id.name].GetType() != typeof(System.DBNull))
                        {
                        o_Users_id.obj  =  dr[Login_VIEW.Users_id.name];
                        }
                      }
                    }
                    if (o_first_name.Select.enabled)
                    {
                      if (dr[Login_VIEW.first_name.name] != null)
                      {
                        if (dr[Login_VIEW.first_name.name].GetType() != typeof(System.DBNull))
                        {
                        o_first_name.obj  =  dr[Login_VIEW.first_name.name];
                        }
                      }
                    }
                    if (o_last_name.Select.enabled)
                    {
                      if (dr[Login_VIEW.last_name.name] != null)
                      {
                        if (dr[Login_VIEW.last_name.name].GetType() != typeof(System.DBNull))
                        {
                        o_last_name.obj  =  dr[Login_VIEW.last_name.name];
                        }
                      }
                    }
                    if (o_Identity.Select.enabled)
                    {
                      if (dr[Login_VIEW.Identity.name] != null)
                      {
                        if (dr[Login_VIEW.Identity.name].GetType() != typeof(System.DBNull))
                        {
                        o_Identity.obj  =  dr[Login_VIEW.Identity.name];
                        }
                      }
                    }
                    if (o_Contact.Select.enabled)
                    {
                      if (dr[Login_VIEW.Contact.name] != null)
                      {
                        if (dr[Login_VIEW.Contact.name].GetType() != typeof(System.DBNull))
                        {
                        o_Contact.obj  =  dr[Login_VIEW.Contact.name];
                        }
                      }
                    }
                    if (o_username.Select.enabled)
                    {
                      if (dr[Login_VIEW.username.name] != null)
                      {
                        if (dr[Login_VIEW.username.name].GetType() != typeof(System.DBNull))
                        {
                        o_username.obj  =  dr[Login_VIEW.username.name];
                        }
                      }
                    }
                    if (o_password.Select.enabled)
                    {
                      if (dr[Login_VIEW.password.name] != null)
                      {
                        if (dr[Login_VIEW.password.name].GetType() != typeof(System.DBNull))
                        {
                        o_password.obj  =  dr[Login_VIEW.password.name];
                        }
                      }
                    }
                    if (o_PasswordNeverExpires.Select.enabled)
                    {
                      if (dr[Login_VIEW.PasswordNeverExpires.name] != null)
                      {
                        if (dr[Login_VIEW.PasswordNeverExpires.name].GetType() != typeof(System.DBNull))
                        {
                        o_PasswordNeverExpires.obj  =  dr[Login_VIEW.PasswordNeverExpires.name];
                        }
                      }
                    }
                    if (o_enabled.Select.enabled)
                    {
                      if (dr[Login_VIEW.enabled.name] != null)
                      {
                        if (dr[Login_VIEW.enabled.name].GetType() != typeof(System.DBNull))
                        {
                        o_enabled.obj  =  dr[Login_VIEW.enabled.name];
                        }
                      }
                    }
                    if (o_Maximum_password_age_in_days.Select.enabled)
                    {
                      if (dr[Login_VIEW.Maximum_password_age_in_days.name] != null)
                      {
                        if (dr[Login_VIEW.Maximum_password_age_in_days.name].GetType() != typeof(System.DBNull))
                        {
                        o_Maximum_password_age_in_days.obj  =  dr[Login_VIEW.Maximum_password_age_in_days.name];
                        }
                      }
                    }
                    if (o_Time_When_UserSetsItsOwnPassword.Select.enabled)
                    {
                      if (dr[Login_VIEW.Time_When_UserSetsItsOwnPassword.name] != null)
                      {
                        if (dr[Login_VIEW.Time_When_UserSetsItsOwnPassword.name].GetType() != typeof(System.DBNull))
                        {
                        o_Time_When_UserSetsItsOwnPassword.obj  =  dr[Login_VIEW.Time_When_UserSetsItsOwnPassword.name];
                        }
                      }
                    }
                    if (o_ChangePasswordOnFirstLogin.Select.enabled)
                    {
                      if (dr[Login_VIEW.ChangePasswordOnFirstLogin.name] != null)
                      {
                        if (dr[Login_VIEW.ChangePasswordOnFirstLogin.name].GetType() != typeof(System.DBNull))
                        {
                        o_ChangePasswordOnFirstLogin.obj  =  dr[Login_VIEW.ChangePasswordOnFirstLogin.name];
                        }
                      }
                    }
                    if (o_Role_id.Select.enabled)
                    {
                      if (dr[Login_VIEW.Role_id.name] != null)
                      {
                        if (dr[Login_VIEW.Role_id.name].GetType() != typeof(System.DBNull))
                        {
                        o_Role_id.obj  =  dr[Login_VIEW.Role_id.name];
                        }
                      }
                    }
                    if (o_RoleName.Select.enabled)
                    {
                      if (dr[Login_VIEW.RoleName.name] != null)
                      {
                        if (dr[Login_VIEW.RoleName.name].GetType() != typeof(System.DBNull))
                        {
                        o_RoleName.obj  =  dr[Login_VIEW.RoleName.name];
                        }
                      }
                    }
                    if (o_RoleDescription.Select.enabled)
                    {
                      if (dr[Login_VIEW.RoleDescription.name] != null)
                      {
                        if (dr[Login_VIEW.RoleDescription.name].GetType() != typeof(System.DBNull))
                        {
                        o_RoleDescription.obj  =  dr[Login_VIEW.RoleDescription.name];
                        }
                      }
                    }
           }

    }

    public class LoginDB_DataSet_ScalarFunctions:XFunction
    {
                public LoginDB_DataSet_ScalarFunctions(DBConnectionControl4.DBConnection xcon)
                {
                        m_con = xcon;
        
                }
            }
        

    public class LoginDB_DataSet_Procedures:XProcedure
    {
                public LoginDB_DataSet_Procedures(DBConnectionControl4.DBConnection xcon)
                {
                        m_con = xcon;
        
                }
            }
        
}
