
using System;
using System.Data;
using System.Collections.Generic;
using System.Windows.Forms;
using DBConnectionControl40;
using LoginaDatasetCommonClasses;
namespace LoginDB_DataSet
{

    public class LoginComputer:XTable
    {
        public const string tablename_const = "LoginComputer";
        public selection select;
        public WHERE where;

        public void Set_DataGridView_Headers(DataGridView dgv)
        {
            LoginComputer_lang m_LoginComputer_lang = new LoginComputer_lang();
            foreach (DataGridViewColumn dgvc in dgv.Columns)
            {
                foreach (ltext lt in m_LoginComputer_lang.col_headers)
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

        public class ComputerName:ValSet
           { 
             public const string name = "ComputerName";

             public string ComputerName_
             {
                get {return (string) obj;}
                set {obj = value;}
             }
           }
           public ComputerName o_ComputerName = new ComputerName();

        public LoginComputer(DBConnectionControl40.DBConnection xcon)
           {
                select = new selection(this);
                where  = new WHERE(this);
                m_con = xcon;
                tablename = LoginComputer.tablename_const;
                myUpdateObjects = UpdateObjects;


                    o_id.col_name = LoginComputer.id.name;
                    o_id.col_type.m_Type = "int";
                    o_id.col_type.bPRIMARY_KEY = true;
                    o_id.col_type.bFOREIGN_KEY = false;
                    o_id.col_type.bUNIQUE = false;
                    o_id.col_type.bNULL = false;
                    Add(o_id);
                    
                    o_ComputerName.col_name = LoginComputer.ComputerName.name;
                    o_ComputerName.col_type.m_Type = "nvarchar";
                    o_ComputerName.col_type.bPRIMARY_KEY = false;
                    o_ComputerName.col_type.bFOREIGN_KEY = false;
                    o_ComputerName.col_type.bUNIQUE = false;
                    o_ComputerName.col_type.bNULL = true;
                    Add(o_ComputerName);
                    
           }

        public class selection
           {
                private LoginComputer m_LoginComputer;
                public selection(LoginComputer xLoginComputer)
                {
                    m_LoginComputer =  xLoginComputer;
                }

                    public bool id
                    {
                        get {return m_LoginComputer.o_id.Select.enabled;}
                        set {m_LoginComputer.o_id.Select.enabled = value;}
                    }
                    
                    public void id_Expression(string Expression,string xalternate_column_name)
                    {
                        m_LoginComputer.o_id.Select.expression = Expression;
                        m_LoginComputer.o_id.Select.alternate_column_name = xalternate_column_name;
                    }
                    
                    public bool ComputerName
                    {
                        get {return m_LoginComputer.o_ComputerName.Select.enabled;}
                        set {m_LoginComputer.o_ComputerName.Select.enabled = value;}
                    }
                    
                    public void ComputerName_Expression(string Expression,string xalternate_column_name)
                    {
                        m_LoginComputer.o_ComputerName.Select.expression = Expression;
                        m_LoginComputer.o_ComputerName.Select.alternate_column_name = xalternate_column_name;
                    }
                    
               public void all(bool bVal)
               {

                    this.id = bVal;
                    
                    this.ComputerName = bVal;
                    
               }
    
           }

        public class WHERE
           {
                private LoginComputer m_LoginComputer;
                public WHERE(LoginComputer xLoginComputer)
                {
                    m_LoginComputer =  xLoginComputer;
                }

                    public bool id
                    {
                        get {return m_LoginComputer.o_id.Where.enabled;}
                        set {m_LoginComputer.o_id.Where.enabled = value;}
                    }
                    
                    public void id_Expression(string Expression)
                    {
                        m_LoginComputer.o_id.Where.expression = Expression;
                    }
                    

                    public void id_AddParameter(DBConnectionControl40.SQL_Parameter par)
                    {
                        m_LoginComputer.o_id.Where.AddParameter(par);
                    }
                    
                    public bool ComputerName
                    {
                        get {return m_LoginComputer.o_ComputerName.Where.enabled;}
                        set {m_LoginComputer.o_ComputerName.Where.enabled = value;}
                    }
                    
                    public void ComputerName_Expression(string Expression)
                    {
                        m_LoginComputer.o_ComputerName.Where.expression = Expression;
                    }
                    

                    public void ComputerName_AddParameter(DBConnectionControl40.SQL_Parameter par)
                    {
                        m_LoginComputer.o_ComputerName.Where.AddParameter(par);
                    }
                    
               public void all(bool bVal)
               {

                    this.id = bVal;
                    
                    this.ComputerName = bVal;
                    
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
                          if (dr[LoginComputer.id.name] != null)
                          {
                            if (dr[LoginComputer.id.name].GetType() != typeof(System.DBNull))
                            {
                            o_id.id_  = (int) dr[LoginComputer.id.name];
                            }
                          }
                        }

                    }
                    if (o_ComputerName.Select.enabled)
                    {
                        if (o_ComputerName.Select.IsExpression)
                        {
                          if (dr[o_ComputerName.Select.alternate_column_name] != null)
                          {
                            if (dr[o_ComputerName.Select.alternate_column_name].GetType() != typeof(System.DBNull))
                            {
                              o_ComputerName.obj  = dr[o_ComputerName.Select.alternate_column_name];
                            }
                          }
                        }
                        else
                        {
                          if (dr[LoginComputer.ComputerName.name] != null)
                          {
                            if (dr[LoginComputer.ComputerName.name].GetType() != typeof(System.DBNull))
                            {
                            o_ComputerName.ComputerName_  = (string) dr[LoginComputer.ComputerName.name];
                            }
                          }
                        }

                    }
           }

    }
    public class LoginComputerUser:XTable
    {
        public const string tablename_const = "LoginComputerUser";
        public selection select;
        public WHERE where;

        public void Set_DataGridView_Headers(DataGridView dgv)
        {
            LoginComputerUser_lang m_LoginComputerUser_lang = new LoginComputerUser_lang();
            foreach (DataGridViewColumn dgvc in dgv.Columns)
            {
                foreach (ltext lt in m_LoginComputerUser_lang.col_headers)
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

        public class ComputerUserName:ValSet
           { 
             public const string name = "ComputerUserName";

             public string ComputerUserName_
             {
                get {return (string) obj;}
                set {obj = value;}
             }
           }
           public ComputerUserName o_ComputerUserName = new ComputerUserName();

        public LoginComputerUser(DBConnectionControl40.DBConnection xcon)
           {
                select = new selection(this);
                where  = new WHERE(this);
                m_con = xcon;
                tablename = LoginComputerUser.tablename_const;
                myUpdateObjects = UpdateObjects;


                    o_id.col_name = LoginComputerUser.id.name;
                    o_id.col_type.m_Type = "int";
                    o_id.col_type.bPRIMARY_KEY = true;
                    o_id.col_type.bFOREIGN_KEY = false;
                    o_id.col_type.bUNIQUE = false;
                    o_id.col_type.bNULL = false;
                    Add(o_id);
                    
                    o_ComputerUserName.col_name = LoginComputerUser.ComputerUserName.name;
                    o_ComputerUserName.col_type.m_Type = "nvarchar";
                    o_ComputerUserName.col_type.bPRIMARY_KEY = false;
                    o_ComputerUserName.col_type.bFOREIGN_KEY = false;
                    o_ComputerUserName.col_type.bUNIQUE = false;
                    o_ComputerUserName.col_type.bNULL = true;
                    Add(o_ComputerUserName);
                    
           }

        public class selection
           {
                private LoginComputerUser m_LoginComputerUser;
                public selection(LoginComputerUser xLoginComputerUser)
                {
                    m_LoginComputerUser =  xLoginComputerUser;
                }

                    public bool id
                    {
                        get {return m_LoginComputerUser.o_id.Select.enabled;}
                        set {m_LoginComputerUser.o_id.Select.enabled = value;}
                    }
                    
                    public void id_Expression(string Expression,string xalternate_column_name)
                    {
                        m_LoginComputerUser.o_id.Select.expression = Expression;
                        m_LoginComputerUser.o_id.Select.alternate_column_name = xalternate_column_name;
                    }
                    
                    public bool ComputerUserName
                    {
                        get {return m_LoginComputerUser.o_ComputerUserName.Select.enabled;}
                        set {m_LoginComputerUser.o_ComputerUserName.Select.enabled = value;}
                    }
                    
                    public void ComputerUserName_Expression(string Expression,string xalternate_column_name)
                    {
                        m_LoginComputerUser.o_ComputerUserName.Select.expression = Expression;
                        m_LoginComputerUser.o_ComputerUserName.Select.alternate_column_name = xalternate_column_name;
                    }
                    
               public void all(bool bVal)
               {

                    this.id = bVal;
                    
                    this.ComputerUserName = bVal;
                    
               }
    
           }

        public class WHERE
           {
                private LoginComputerUser m_LoginComputerUser;
                public WHERE(LoginComputerUser xLoginComputerUser)
                {
                    m_LoginComputerUser =  xLoginComputerUser;
                }

                    public bool id
                    {
                        get {return m_LoginComputerUser.o_id.Where.enabled;}
                        set {m_LoginComputerUser.o_id.Where.enabled = value;}
                    }
                    
                    public void id_Expression(string Expression)
                    {
                        m_LoginComputerUser.o_id.Where.expression = Expression;
                    }
                    

                    public void id_AddParameter(DBConnectionControl40.SQL_Parameter par)
                    {
                        m_LoginComputerUser.o_id.Where.AddParameter(par);
                    }
                    
                    public bool ComputerUserName
                    {
                        get {return m_LoginComputerUser.o_ComputerUserName.Where.enabled;}
                        set {m_LoginComputerUser.o_ComputerUserName.Where.enabled = value;}
                    }
                    
                    public void ComputerUserName_Expression(string Expression)
                    {
                        m_LoginComputerUser.o_ComputerUserName.Where.expression = Expression;
                    }
                    

                    public void ComputerUserName_AddParameter(DBConnectionControl40.SQL_Parameter par)
                    {
                        m_LoginComputerUser.o_ComputerUserName.Where.AddParameter(par);
                    }
                    
               public void all(bool bVal)
               {

                    this.id = bVal;
                    
                    this.ComputerUserName = bVal;
                    
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
                          if (dr[LoginComputerUser.id.name] != null)
                          {
                            if (dr[LoginComputerUser.id.name].GetType() != typeof(System.DBNull))
                            {
                            o_id.id_  = (int) dr[LoginComputerUser.id.name];
                            }
                          }
                        }

                    }
                    if (o_ComputerUserName.Select.enabled)
                    {
                        if (o_ComputerUserName.Select.IsExpression)
                        {
                          if (dr[o_ComputerUserName.Select.alternate_column_name] != null)
                          {
                            if (dr[o_ComputerUserName.Select.alternate_column_name].GetType() != typeof(System.DBNull))
                            {
                              o_ComputerUserName.obj  = dr[o_ComputerUserName.Select.alternate_column_name];
                            }
                          }
                        }
                        else
                        {
                          if (dr[LoginComputerUser.ComputerUserName.name] != null)
                          {
                            if (dr[LoginComputerUser.ComputerUserName.name].GetType() != typeof(System.DBNull))
                            {
                            o_ComputerUserName.ComputerUserName_  = (string) dr[LoginComputerUser.ComputerUserName.name];
                            }
                          }
                        }

                    }
           }

    }
    public class LoginFailed:XTable
    {
        public const string tablename_const = "LoginFailed";
        public selection select;
        public WHERE where;

        public void Set_DataGridView_Headers(DataGridView dgv)
        {
            LoginFailed_lang m_LoginFailed_lang = new LoginFailed_lang();
            foreach (DataGridViewColumn dgvc in dgv.Columns)
            {
                foreach (ltext lt in m_LoginFailed_lang.col_headers)
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

        public class AttemptTime:ValSet
           { 
             public const string name = "AttemptTime";

             public DateTime AttemptTime_
             {
                get {return (DateTime) obj;}
                set {obj = value;}
             }
           }
           public AttemptTime o_AttemptTime = new AttemptTime();

        public class username_does_not_exist:ValSet
           { 
             public const string name = "username_does_not_exist";

             public bool username_does_not_exist_
             {
                get {return (bool) obj;}
                set {obj = value;}
             }
           }
           public username_does_not_exist o_username_does_not_exist = new username_does_not_exist();

        public class password_wrong:ValSet
           { 
             public const string name = "password_wrong";

             public bool password_wrong_
             {
                get {return (bool) obj;}
                set {obj = value;}
             }
           }
           public password_wrong o_password_wrong = new password_wrong();

        public class LoginComputer_id:ValSet
           { 
             public const string name = "LoginComputer_id";

             public int LoginComputer_id_
             {
                get {return (int) obj;}
                set {obj = value;}
             }
           }
           public LoginComputer_id o_LoginComputer_id = new LoginComputer_id();

        public class LoginComputerUser_id:ValSet
           { 
             public const string name = "LoginComputerUser_id";

             public int LoginComputerUser_id_
             {
                get {return (int) obj;}
                set {obj = value;}
             }
           }
           public LoginComputerUser_id o_LoginComputerUser_id = new LoginComputerUser_id();

        public LoginFailed(DBConnectionControl40.DBConnection xcon)
           {
                select = new selection(this);
                where  = new WHERE(this);
                m_con = xcon;
                tablename = LoginFailed.tablename_const;
                myUpdateObjects = UpdateObjects;


                    o_id.col_name = LoginFailed.id.name;
                    o_id.col_type.m_Type = "int";
                    o_id.col_type.bPRIMARY_KEY = true;
                    o_id.col_type.bFOREIGN_KEY = false;
                    o_id.col_type.bUNIQUE = false;
                    o_id.col_type.bNULL = false;
                    Add(o_id);
                    
                    o_username.col_name = LoginFailed.username.name;
                    o_username.col_type.m_Type = "nvarchar";
                    o_username.col_type.bPRIMARY_KEY = false;
                    o_username.col_type.bFOREIGN_KEY = false;
                    o_username.col_type.bUNIQUE = false;
                    o_username.col_type.bNULL = false;
                    Add(o_username);
                    
                    o_AttemptTime.col_name = LoginFailed.AttemptTime.name;
                    o_AttemptTime.col_type.m_Type = "datetime";
                    o_AttemptTime.col_type.bPRIMARY_KEY = false;
                    o_AttemptTime.col_type.bFOREIGN_KEY = false;
                    o_AttemptTime.col_type.bUNIQUE = false;
                    o_AttemptTime.col_type.bNULL = false;
                    Add(o_AttemptTime);
                    
                    o_username_does_not_exist.col_name = LoginFailed.username_does_not_exist.name;
                    o_username_does_not_exist.col_type.m_Type = "bit";
                    o_username_does_not_exist.col_type.bPRIMARY_KEY = false;
                    o_username_does_not_exist.col_type.bFOREIGN_KEY = false;
                    o_username_does_not_exist.col_type.bUNIQUE = false;
                    o_username_does_not_exist.col_type.bNULL = false;
                    Add(o_username_does_not_exist);
                    
                    o_password_wrong.col_name = LoginFailed.password_wrong.name;
                    o_password_wrong.col_type.m_Type = "bit";
                    o_password_wrong.col_type.bPRIMARY_KEY = false;
                    o_password_wrong.col_type.bFOREIGN_KEY = false;
                    o_password_wrong.col_type.bUNIQUE = false;
                    o_password_wrong.col_type.bNULL = true;
                    Add(o_password_wrong);
                    
                    o_LoginComputer_id.col_name = LoginFailed.LoginComputer_id.name;
                    o_LoginComputer_id.col_type.m_Type = "int";
                    o_LoginComputer_id.col_type.bPRIMARY_KEY = false;
                    o_LoginComputer_id.col_type.bFOREIGN_KEY = false;
                    o_LoginComputer_id.col_type.bUNIQUE = false;
                    o_LoginComputer_id.col_type.bNULL = true;
                    Add(o_LoginComputer_id);
                    
                    o_LoginComputerUser_id.col_name = LoginFailed.LoginComputerUser_id.name;
                    o_LoginComputerUser_id.col_type.m_Type = "int";
                    o_LoginComputerUser_id.col_type.bPRIMARY_KEY = false;
                    o_LoginComputerUser_id.col_type.bFOREIGN_KEY = false;
                    o_LoginComputerUser_id.col_type.bUNIQUE = false;
                    o_LoginComputerUser_id.col_type.bNULL = true;
                    Add(o_LoginComputerUser_id);
                    
           }

        public class selection
           {
                private LoginFailed m_LoginFailed;
                public selection(LoginFailed xLoginFailed)
                {
                    m_LoginFailed =  xLoginFailed;
                }

                    public bool id
                    {
                        get {return m_LoginFailed.o_id.Select.enabled;}
                        set {m_LoginFailed.o_id.Select.enabled = value;}
                    }
                    
                    public void id_Expression(string Expression,string xalternate_column_name)
                    {
                        m_LoginFailed.o_id.Select.expression = Expression;
                        m_LoginFailed.o_id.Select.alternate_column_name = xalternate_column_name;
                    }
                    
                    public bool username
                    {
                        get {return m_LoginFailed.o_username.Select.enabled;}
                        set {m_LoginFailed.o_username.Select.enabled = value;}
                    }
                    
                    public void username_Expression(string Expression,string xalternate_column_name)
                    {
                        m_LoginFailed.o_username.Select.expression = Expression;
                        m_LoginFailed.o_username.Select.alternate_column_name = xalternate_column_name;
                    }
                    
                    public bool AttemptTime
                    {
                        get {return m_LoginFailed.o_AttemptTime.Select.enabled;}
                        set {m_LoginFailed.o_AttemptTime.Select.enabled = value;}
                    }
                    
                    public void AttemptTime_Expression(string Expression,string xalternate_column_name)
                    {
                        m_LoginFailed.o_AttemptTime.Select.expression = Expression;
                        m_LoginFailed.o_AttemptTime.Select.alternate_column_name = xalternate_column_name;
                    }
                    
                    public bool username_does_not_exist
                    {
                        get {return m_LoginFailed.o_username_does_not_exist.Select.enabled;}
                        set {m_LoginFailed.o_username_does_not_exist.Select.enabled = value;}
                    }
                    
                    public void username_does_not_exist_Expression(string Expression,string xalternate_column_name)
                    {
                        m_LoginFailed.o_username_does_not_exist.Select.expression = Expression;
                        m_LoginFailed.o_username_does_not_exist.Select.alternate_column_name = xalternate_column_name;
                    }
                    
                    public bool password_wrong
                    {
                        get {return m_LoginFailed.o_password_wrong.Select.enabled;}
                        set {m_LoginFailed.o_password_wrong.Select.enabled = value;}
                    }
                    
                    public void password_wrong_Expression(string Expression,string xalternate_column_name)
                    {
                        m_LoginFailed.o_password_wrong.Select.expression = Expression;
                        m_LoginFailed.o_password_wrong.Select.alternate_column_name = xalternate_column_name;
                    }
                    
                    public bool LoginComputer_id
                    {
                        get {return m_LoginFailed.o_LoginComputer_id.Select.enabled;}
                        set {m_LoginFailed.o_LoginComputer_id.Select.enabled = value;}
                    }
                    
                    public void LoginComputer_id_Expression(string Expression,string xalternate_column_name)
                    {
                        m_LoginFailed.o_LoginComputer_id.Select.expression = Expression;
                        m_LoginFailed.o_LoginComputer_id.Select.alternate_column_name = xalternate_column_name;
                    }
                    
                    public bool LoginComputerUser_id
                    {
                        get {return m_LoginFailed.o_LoginComputerUser_id.Select.enabled;}
                        set {m_LoginFailed.o_LoginComputerUser_id.Select.enabled = value;}
                    }
                    
                    public void LoginComputerUser_id_Expression(string Expression,string xalternate_column_name)
                    {
                        m_LoginFailed.o_LoginComputerUser_id.Select.expression = Expression;
                        m_LoginFailed.o_LoginComputerUser_id.Select.alternate_column_name = xalternate_column_name;
                    }
                    
               public void all(bool bVal)
               {

                    this.id = bVal;
                    
                    this.username = bVal;
                    
                    this.AttemptTime = bVal;
                    
                    this.username_does_not_exist = bVal;
                    
                    this.password_wrong = bVal;
                    
                    this.LoginComputer_id = bVal;
                    
                    this.LoginComputerUser_id = bVal;
                    
               }
    
           }

        public class WHERE
           {
                private LoginFailed m_LoginFailed;
                public WHERE(LoginFailed xLoginFailed)
                {
                    m_LoginFailed =  xLoginFailed;
                }

                    public bool id
                    {
                        get {return m_LoginFailed.o_id.Where.enabled;}
                        set {m_LoginFailed.o_id.Where.enabled = value;}
                    }
                    
                    public void id_Expression(string Expression)
                    {
                        m_LoginFailed.o_id.Where.expression = Expression;
                    }
                    

                    public void id_AddParameter(DBConnectionControl40.SQL_Parameter par)
                    {
                        m_LoginFailed.o_id.Where.AddParameter(par);
                    }
                    
                    public bool username
                    {
                        get {return m_LoginFailed.o_username.Where.enabled;}
                        set {m_LoginFailed.o_username.Where.enabled = value;}
                    }
                    
                    public void username_Expression(string Expression)
                    {
                        m_LoginFailed.o_username.Where.expression = Expression;
                    }
                    

                    public void username_AddParameter(DBConnectionControl40.SQL_Parameter par)
                    {
                        m_LoginFailed.o_username.Where.AddParameter(par);
                    }
                    
                    public bool AttemptTime
                    {
                        get {return m_LoginFailed.o_AttemptTime.Where.enabled;}
                        set {m_LoginFailed.o_AttemptTime.Where.enabled = value;}
                    }
                    
                    public void AttemptTime_Expression(string Expression)
                    {
                        m_LoginFailed.o_AttemptTime.Where.expression = Expression;
                    }
                    

                    public void AttemptTime_AddParameter(DBConnectionControl40.SQL_Parameter par)
                    {
                        m_LoginFailed.o_AttemptTime.Where.AddParameter(par);
                    }
                    
                    public bool username_does_not_exist
                    {
                        get {return m_LoginFailed.o_username_does_not_exist.Where.enabled;}
                        set {m_LoginFailed.o_username_does_not_exist.Where.enabled = value;}
                    }
                    
                    public void username_does_not_exist_Expression(string Expression)
                    {
                        m_LoginFailed.o_username_does_not_exist.Where.expression = Expression;
                    }
                    

                    public void username_does_not_exist_AddParameter(DBConnectionControl40.SQL_Parameter par)
                    {
                        m_LoginFailed.o_username_does_not_exist.Where.AddParameter(par);
                    }
                    
                    public bool password_wrong
                    {
                        get {return m_LoginFailed.o_password_wrong.Where.enabled;}
                        set {m_LoginFailed.o_password_wrong.Where.enabled = value;}
                    }
                    
                    public void password_wrong_Expression(string Expression)
                    {
                        m_LoginFailed.o_password_wrong.Where.expression = Expression;
                    }
                    

                    public void password_wrong_AddParameter(DBConnectionControl40.SQL_Parameter par)
                    {
                        m_LoginFailed.o_password_wrong.Where.AddParameter(par);
                    }
                    
                    public bool LoginComputer_id
                    {
                        get {return m_LoginFailed.o_LoginComputer_id.Where.enabled;}
                        set {m_LoginFailed.o_LoginComputer_id.Where.enabled = value;}
                    }
                    
                    public void LoginComputer_id_Expression(string Expression)
                    {
                        m_LoginFailed.o_LoginComputer_id.Where.expression = Expression;
                    }
                    

                    public void LoginComputer_id_AddParameter(DBConnectionControl40.SQL_Parameter par)
                    {
                        m_LoginFailed.o_LoginComputer_id.Where.AddParameter(par);
                    }
                    
                    public bool LoginComputerUser_id
                    {
                        get {return m_LoginFailed.o_LoginComputerUser_id.Where.enabled;}
                        set {m_LoginFailed.o_LoginComputerUser_id.Where.enabled = value;}
                    }
                    
                    public void LoginComputerUser_id_Expression(string Expression)
                    {
                        m_LoginFailed.o_LoginComputerUser_id.Where.expression = Expression;
                    }
                    

                    public void LoginComputerUser_id_AddParameter(DBConnectionControl40.SQL_Parameter par)
                    {
                        m_LoginFailed.o_LoginComputerUser_id.Where.AddParameter(par);
                    }
                    
               public void all(bool bVal)
               {

                    this.id = bVal;
                    
                    this.username = bVal;
                    
                    this.AttemptTime = bVal;
                    
                    this.username_does_not_exist = bVal;
                    
                    this.password_wrong = bVal;
                    
                    this.LoginComputer_id = bVal;
                    
                    this.LoginComputerUser_id = bVal;
                    
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
                          if (dr[LoginFailed.id.name] != null)
                          {
                            if (dr[LoginFailed.id.name].GetType() != typeof(System.DBNull))
                            {
                            o_id.id_  = (int) dr[LoginFailed.id.name];
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
                          if (dr[LoginFailed.username.name] != null)
                          {
                            if (dr[LoginFailed.username.name].GetType() != typeof(System.DBNull))
                            {
                            o_username.username_  = (string) dr[LoginFailed.username.name];
                            }
                          }
                        }

                    }
                    if (o_AttemptTime.Select.enabled)
                    {
                        if (o_AttemptTime.Select.IsExpression)
                        {
                          if (dr[o_AttemptTime.Select.alternate_column_name] != null)
                          {
                            if (dr[o_AttemptTime.Select.alternate_column_name].GetType() != typeof(System.DBNull))
                            {
                              o_AttemptTime.obj  = dr[o_AttemptTime.Select.alternate_column_name];
                            }
                          }
                        }
                        else
                        {
                          if (dr[LoginFailed.AttemptTime.name] != null)
                          {
                            if (dr[LoginFailed.AttemptTime.name].GetType() != typeof(System.DBNull))
                            {
                            o_AttemptTime.AttemptTime_  = (DateTime) dr[LoginFailed.AttemptTime.name];
                            }
                          }
                        }

                    }
                    if (o_username_does_not_exist.Select.enabled)
                    {
                        if (o_username_does_not_exist.Select.IsExpression)
                        {
                          if (dr[o_username_does_not_exist.Select.alternate_column_name] != null)
                          {
                            if (dr[o_username_does_not_exist.Select.alternate_column_name].GetType() != typeof(System.DBNull))
                            {
                              o_username_does_not_exist.obj  = dr[o_username_does_not_exist.Select.alternate_column_name];
                            }
                          }
                        }
                        else
                        {
                          if (dr[LoginFailed.username_does_not_exist.name] != null)
                          {
                            if (dr[LoginFailed.username_does_not_exist.name].GetType() != typeof(System.DBNull))
                            {
                            o_username_does_not_exist.username_does_not_exist_  = (bool) dr[LoginFailed.username_does_not_exist.name];
                            }
                          }
                        }

                    }
                    if (o_password_wrong.Select.enabled)
                    {
                        if (o_password_wrong.Select.IsExpression)
                        {
                          if (dr[o_password_wrong.Select.alternate_column_name] != null)
                          {
                            if (dr[o_password_wrong.Select.alternate_column_name].GetType() != typeof(System.DBNull))
                            {
                              o_password_wrong.obj  = dr[o_password_wrong.Select.alternate_column_name];
                            }
                          }
                        }
                        else
                        {
                          if (dr[LoginFailed.password_wrong.name] != null)
                          {
                            if (dr[LoginFailed.password_wrong.name].GetType() != typeof(System.DBNull))
                            {
                            o_password_wrong.password_wrong_  = (bool) dr[LoginFailed.password_wrong.name];
                            }
                          }
                        }

                    }
                    if (o_LoginComputer_id.Select.enabled)
                    {
                        if (o_LoginComputer_id.Select.IsExpression)
                        {
                          if (dr[o_LoginComputer_id.Select.alternate_column_name] != null)
                          {
                            if (dr[o_LoginComputer_id.Select.alternate_column_name].GetType() != typeof(System.DBNull))
                            {
                              o_LoginComputer_id.obj  = dr[o_LoginComputer_id.Select.alternate_column_name];
                            }
                          }
                        }
                        else
                        {
                          if (dr[LoginFailed.LoginComputer_id.name] != null)
                          {
                            if (dr[LoginFailed.LoginComputer_id.name].GetType() != typeof(System.DBNull))
                            {
                            o_LoginComputer_id.LoginComputer_id_  = (int) dr[LoginFailed.LoginComputer_id.name];
                            }
                          }
                        }

                    }
                    if (o_LoginComputerUser_id.Select.enabled)
                    {
                        if (o_LoginComputerUser_id.Select.IsExpression)
                        {
                          if (dr[o_LoginComputerUser_id.Select.alternate_column_name] != null)
                          {
                            if (dr[o_LoginComputerUser_id.Select.alternate_column_name].GetType() != typeof(System.DBNull))
                            {
                              o_LoginComputerUser_id.obj  = dr[o_LoginComputerUser_id.Select.alternate_column_name];
                            }
                          }
                        }
                        else
                        {
                          if (dr[LoginFailed.LoginComputerUser_id.name] != null)
                          {
                            if (dr[LoginFailed.LoginComputerUser_id.name].GetType() != typeof(System.DBNull))
                            {
                            o_LoginComputerUser_id.LoginComputerUser_id_  = (int) dr[LoginFailed.LoginComputerUser_id.name];
                            }
                          }
                        }

                    }
           }

    }
    public class LoginManagerEvent:XTable
    {
        public const string tablename_const = "LoginManagerEvent";
        public selection select;
        public WHERE where;

        public void Set_DataGridView_Headers(DataGridView dgv)
        {
            LoginManagerEvent_lang m_LoginManagerEvent_lang = new LoginManagerEvent_lang();
            foreach (DataGridViewColumn dgvc in dgv.Columns)
            {
                foreach (ltext lt in m_LoginManagerEvent_lang.col_headers)
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

        public LoginManagerEvent(DBConnectionControl40.DBConnection xcon)
           {
                select = new selection(this);
                where  = new WHERE(this);
                m_con = xcon;
                tablename = LoginManagerEvent.tablename_const;
                myUpdateObjects = UpdateObjects;


                    o_id.col_name = LoginManagerEvent.id.name;
                    o_id.col_type.m_Type = "int";
                    o_id.col_type.bPRIMARY_KEY = true;
                    o_id.col_type.bFOREIGN_KEY = false;
                    o_id.col_type.bUNIQUE = false;
                    o_id.col_type.bNULL = false;
                    Add(o_id);
                    
                    o_Name.col_name = LoginManagerEvent.Name.name;
                    o_Name.col_type.m_Type = "nvarchar";
                    o_Name.col_type.bPRIMARY_KEY = false;
                    o_Name.col_type.bFOREIGN_KEY = false;
                    o_Name.col_type.bUNIQUE = true;
                    o_Name.col_type.bNULL = false;
                    Add(o_Name);
                    
           }

        public class selection
           {
                private LoginManagerEvent m_LoginManagerEvent;
                public selection(LoginManagerEvent xLoginManagerEvent)
                {
                    m_LoginManagerEvent =  xLoginManagerEvent;
                }

                    public bool id
                    {
                        get {return m_LoginManagerEvent.o_id.Select.enabled;}
                        set {m_LoginManagerEvent.o_id.Select.enabled = value;}
                    }
                    
                    public void id_Expression(string Expression,string xalternate_column_name)
                    {
                        m_LoginManagerEvent.o_id.Select.expression = Expression;
                        m_LoginManagerEvent.o_id.Select.alternate_column_name = xalternate_column_name;
                    }
                    
                    public bool Name
                    {
                        get {return m_LoginManagerEvent.o_Name.Select.enabled;}
                        set {m_LoginManagerEvent.o_Name.Select.enabled = value;}
                    }
                    
                    public void Name_Expression(string Expression,string xalternate_column_name)
                    {
                        m_LoginManagerEvent.o_Name.Select.expression = Expression;
                        m_LoginManagerEvent.o_Name.Select.alternate_column_name = xalternate_column_name;
                    }
                    
               public void all(bool bVal)
               {

                    this.id = bVal;
                    
                    this.Name = bVal;
                    
               }
    
           }

        public class WHERE
           {
                private LoginManagerEvent m_LoginManagerEvent;
                public WHERE(LoginManagerEvent xLoginManagerEvent)
                {
                    m_LoginManagerEvent =  xLoginManagerEvent;
                }

                    public bool id
                    {
                        get {return m_LoginManagerEvent.o_id.Where.enabled;}
                        set {m_LoginManagerEvent.o_id.Where.enabled = value;}
                    }
                    
                    public void id_Expression(string Expression)
                    {
                        m_LoginManagerEvent.o_id.Where.expression = Expression;
                    }
                    

                    public void id_AddParameter(DBConnectionControl40.SQL_Parameter par)
                    {
                        m_LoginManagerEvent.o_id.Where.AddParameter(par);
                    }
                    
                    public bool Name
                    {
                        get {return m_LoginManagerEvent.o_Name.Where.enabled;}
                        set {m_LoginManagerEvent.o_Name.Where.enabled = value;}
                    }
                    
                    public void Name_Expression(string Expression)
                    {
                        m_LoginManagerEvent.o_Name.Where.expression = Expression;
                    }
                    

                    public void Name_AddParameter(DBConnectionControl40.SQL_Parameter par)
                    {
                        m_LoginManagerEvent.o_Name.Where.AddParameter(par);
                    }
                    
               public void all(bool bVal)
               {

                    this.id = bVal;
                    
                    this.Name = bVal;
                    
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
                          if (dr[LoginManagerEvent.id.name] != null)
                          {
                            if (dr[LoginManagerEvent.id.name].GetType() != typeof(System.DBNull))
                            {
                            o_id.id_  = (int) dr[LoginManagerEvent.id.name];
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
                          if (dr[LoginManagerEvent.Name.name] != null)
                          {
                            if (dr[LoginManagerEvent.Name.name].GetType() != typeof(System.DBNull))
                            {
                            o_Name.Name_  = (string) dr[LoginManagerEvent.Name.name];
                            }
                          }
                        }

                    }
           }

    }
    public class LoginManagerJournal:XTable
    {
        public const string tablename_const = "LoginManagerJournal";
        public selection select;
        public WHERE where;

        public void Set_DataGridView_Headers(DataGridView dgv)
        {
            LoginManagerJournal_lang m_LoginManagerJournal_lang = new LoginManagerJournal_lang();
            foreach (DataGridViewColumn dgvc in dgv.Columns)
            {
                foreach (ltext lt in m_LoginManagerJournal_lang.col_headers)
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

        public class LoginManagerEvent_id:ValSet
           { 
             public const string name = "LoginManagerEvent_id";

             public int LoginManagerEvent_id_
             {
                get {return (int) obj;}
                set {obj = value;}
             }
           }
           public LoginManagerEvent_id o_LoginManagerEvent_id = new LoginManagerEvent_id();

        public class Time:ValSet
           { 
             public const string name = "Time";

             public DateTime Time_
             {
                get {return (DateTime) obj;}
                set {obj = value;}
             }
           }
           public Time o_Time = new Time();

        public LoginManagerJournal(DBConnectionControl40.DBConnection xcon)
           {
                select = new selection(this);
                where  = new WHERE(this);
                m_con = xcon;
                tablename = LoginManagerJournal.tablename_const;
                myUpdateObjects = UpdateObjects;


                    o_id.col_name = LoginManagerJournal.id.name;
                    o_id.col_type.m_Type = "int";
                    o_id.col_type.bPRIMARY_KEY = true;
                    o_id.col_type.bFOREIGN_KEY = false;
                    o_id.col_type.bUNIQUE = false;
                    o_id.col_type.bNULL = false;
                    Add(o_id);
                    
                    o_LoginUsers_id.col_name = LoginManagerJournal.LoginUsers_id.name;
                    o_LoginUsers_id.col_type.m_Type = "int";
                    o_LoginUsers_id.col_type.bPRIMARY_KEY = false;
                    o_LoginUsers_id.col_type.bFOREIGN_KEY = false;
                    o_LoginUsers_id.col_type.bUNIQUE = false;
                    o_LoginUsers_id.col_type.bNULL = false;
                    Add(o_LoginUsers_id);
                    
                    o_LoginManagerEvent_id.col_name = LoginManagerJournal.LoginManagerEvent_id.name;
                    o_LoginManagerEvent_id.col_type.m_Type = "int";
                    o_LoginManagerEvent_id.col_type.bPRIMARY_KEY = false;
                    o_LoginManagerEvent_id.col_type.bFOREIGN_KEY = false;
                    o_LoginManagerEvent_id.col_type.bUNIQUE = false;
                    o_LoginManagerEvent_id.col_type.bNULL = false;
                    Add(o_LoginManagerEvent_id);
                    
                    o_Time.col_name = LoginManagerJournal.Time.name;
                    o_Time.col_type.m_Type = "datetime";
                    o_Time.col_type.bPRIMARY_KEY = false;
                    o_Time.col_type.bFOREIGN_KEY = false;
                    o_Time.col_type.bUNIQUE = false;
                    o_Time.col_type.bNULL = false;
                    Add(o_Time);
                    
           }

        public class selection
           {
                private LoginManagerJournal m_LoginManagerJournal;
                public selection(LoginManagerJournal xLoginManagerJournal)
                {
                    m_LoginManagerJournal =  xLoginManagerJournal;
                }

                    public bool id
                    {
                        get {return m_LoginManagerJournal.o_id.Select.enabled;}
                        set {m_LoginManagerJournal.o_id.Select.enabled = value;}
                    }
                    
                    public void id_Expression(string Expression,string xalternate_column_name)
                    {
                        m_LoginManagerJournal.o_id.Select.expression = Expression;
                        m_LoginManagerJournal.o_id.Select.alternate_column_name = xalternate_column_name;
                    }
                    
                    public bool LoginUsers_id
                    {
                        get {return m_LoginManagerJournal.o_LoginUsers_id.Select.enabled;}
                        set {m_LoginManagerJournal.o_LoginUsers_id.Select.enabled = value;}
                    }
                    
                    public void LoginUsers_id_Expression(string Expression,string xalternate_column_name)
                    {
                        m_LoginManagerJournal.o_LoginUsers_id.Select.expression = Expression;
                        m_LoginManagerJournal.o_LoginUsers_id.Select.alternate_column_name = xalternate_column_name;
                    }
                    
                    public bool LoginManagerEvent_id
                    {
                        get {return m_LoginManagerJournal.o_LoginManagerEvent_id.Select.enabled;}
                        set {m_LoginManagerJournal.o_LoginManagerEvent_id.Select.enabled = value;}
                    }
                    
                    public void LoginManagerEvent_id_Expression(string Expression,string xalternate_column_name)
                    {
                        m_LoginManagerJournal.o_LoginManagerEvent_id.Select.expression = Expression;
                        m_LoginManagerJournal.o_LoginManagerEvent_id.Select.alternate_column_name = xalternate_column_name;
                    }
                    
                    public bool Time
                    {
                        get {return m_LoginManagerJournal.o_Time.Select.enabled;}
                        set {m_LoginManagerJournal.o_Time.Select.enabled = value;}
                    }
                    
                    public void Time_Expression(string Expression,string xalternate_column_name)
                    {
                        m_LoginManagerJournal.o_Time.Select.expression = Expression;
                        m_LoginManagerJournal.o_Time.Select.alternate_column_name = xalternate_column_name;
                    }
                    
               public void all(bool bVal)
               {

                    this.id = bVal;
                    
                    this.LoginUsers_id = bVal;
                    
                    this.LoginManagerEvent_id = bVal;
                    
                    this.Time = bVal;
                    
               }
    
           }

        public class WHERE
           {
                private LoginManagerJournal m_LoginManagerJournal;
                public WHERE(LoginManagerJournal xLoginManagerJournal)
                {
                    m_LoginManagerJournal =  xLoginManagerJournal;
                }

                    public bool id
                    {
                        get {return m_LoginManagerJournal.o_id.Where.enabled;}
                        set {m_LoginManagerJournal.o_id.Where.enabled = value;}
                    }
                    
                    public void id_Expression(string Expression)
                    {
                        m_LoginManagerJournal.o_id.Where.expression = Expression;
                    }
                    

                    public void id_AddParameter(DBConnectionControl40.SQL_Parameter par)
                    {
                        m_LoginManagerJournal.o_id.Where.AddParameter(par);
                    }
                    
                    public bool LoginUsers_id
                    {
                        get {return m_LoginManagerJournal.o_LoginUsers_id.Where.enabled;}
                        set {m_LoginManagerJournal.o_LoginUsers_id.Where.enabled = value;}
                    }
                    
                    public void LoginUsers_id_Expression(string Expression)
                    {
                        m_LoginManagerJournal.o_LoginUsers_id.Where.expression = Expression;
                    }
                    

                    public void LoginUsers_id_AddParameter(DBConnectionControl40.SQL_Parameter par)
                    {
                        m_LoginManagerJournal.o_LoginUsers_id.Where.AddParameter(par);
                    }
                    
                    public bool LoginManagerEvent_id
                    {
                        get {return m_LoginManagerJournal.o_LoginManagerEvent_id.Where.enabled;}
                        set {m_LoginManagerJournal.o_LoginManagerEvent_id.Where.enabled = value;}
                    }
                    
                    public void LoginManagerEvent_id_Expression(string Expression)
                    {
                        m_LoginManagerJournal.o_LoginManagerEvent_id.Where.expression = Expression;
                    }
                    

                    public void LoginManagerEvent_id_AddParameter(DBConnectionControl40.SQL_Parameter par)
                    {
                        m_LoginManagerJournal.o_LoginManagerEvent_id.Where.AddParameter(par);
                    }
                    
                    public bool Time
                    {
                        get {return m_LoginManagerJournal.o_Time.Where.enabled;}
                        set {m_LoginManagerJournal.o_Time.Where.enabled = value;}
                    }
                    
                    public void Time_Expression(string Expression)
                    {
                        m_LoginManagerJournal.o_Time.Where.expression = Expression;
                    }
                    

                    public void Time_AddParameter(DBConnectionControl40.SQL_Parameter par)
                    {
                        m_LoginManagerJournal.o_Time.Where.AddParameter(par);
                    }
                    
               public void all(bool bVal)
               {

                    this.id = bVal;
                    
                    this.LoginUsers_id = bVal;
                    
                    this.LoginManagerEvent_id = bVal;
                    
                    this.Time = bVal;
                    
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
                          if (dr[LoginManagerJournal.id.name] != null)
                          {
                            if (dr[LoginManagerJournal.id.name].GetType() != typeof(System.DBNull))
                            {
                            o_id.id_  = (int) dr[LoginManagerJournal.id.name];
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
                          if (dr[LoginManagerJournal.LoginUsers_id.name] != null)
                          {
                            if (dr[LoginManagerJournal.LoginUsers_id.name].GetType() != typeof(System.DBNull))
                            {
                            o_LoginUsers_id.LoginUsers_id_  = (int) dr[LoginManagerJournal.LoginUsers_id.name];
                            }
                          }
                        }

                    }
                    if (o_LoginManagerEvent_id.Select.enabled)
                    {
                        if (o_LoginManagerEvent_id.Select.IsExpression)
                        {
                          if (dr[o_LoginManagerEvent_id.Select.alternate_column_name] != null)
                          {
                            if (dr[o_LoginManagerEvent_id.Select.alternate_column_name].GetType() != typeof(System.DBNull))
                            {
                              o_LoginManagerEvent_id.obj  = dr[o_LoginManagerEvent_id.Select.alternate_column_name];
                            }
                          }
                        }
                        else
                        {
                          if (dr[LoginManagerJournal.LoginManagerEvent_id.name] != null)
                          {
                            if (dr[LoginManagerJournal.LoginManagerEvent_id.name].GetType() != typeof(System.DBNull))
                            {
                            o_LoginManagerEvent_id.LoginManagerEvent_id_  = (int) dr[LoginManagerJournal.LoginManagerEvent_id.name];
                            }
                          }
                        }

                    }
                    if (o_Time.Select.enabled)
                    {
                        if (o_Time.Select.IsExpression)
                        {
                          if (dr[o_Time.Select.alternate_column_name] != null)
                          {
                            if (dr[o_Time.Select.alternate_column_name].GetType() != typeof(System.DBNull))
                            {
                              o_Time.obj  = dr[o_Time.Select.alternate_column_name];
                            }
                          }
                        }
                        else
                        {
                          if (dr[LoginManagerJournal.Time.name] != null)
                          {
                            if (dr[LoginManagerJournal.Time.name].GetType() != typeof(System.DBNull))
                            {
                            o_Time.Time_  = (DateTime) dr[LoginManagerJournal.Time.name];
                            }
                          }
                        }

                    }
           }

    }
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

        public class PrivilegesLevel:ValSet
           { 
             public const string name = "PrivilegesLevel";

             public int PrivilegesLevel_
             {
                get {return (int) obj;}
                set {obj = value;}
             }
           }
           public PrivilegesLevel o_PrivilegesLevel = new PrivilegesLevel();

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

        public LoginRoles(DBConnectionControl40.DBConnection xcon)
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
                    
                    o_PrivilegesLevel.col_name = LoginRoles.PrivilegesLevel.name;
                    o_PrivilegesLevel.col_type.m_Type = "int";
                    o_PrivilegesLevel.col_type.bPRIMARY_KEY = false;
                    o_PrivilegesLevel.col_type.bFOREIGN_KEY = false;
                    o_PrivilegesLevel.col_type.bUNIQUE = false;
                    o_PrivilegesLevel.col_type.bNULL = true;
                    Add(o_PrivilegesLevel);
                    
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
                    
                    public bool PrivilegesLevel
                    {
                        get {return m_LoginRoles.o_PrivilegesLevel.Select.enabled;}
                        set {m_LoginRoles.o_PrivilegesLevel.Select.enabled = value;}
                    }
                    
                    public void PrivilegesLevel_Expression(string Expression,string xalternate_column_name)
                    {
                        m_LoginRoles.o_PrivilegesLevel.Select.expression = Expression;
                        m_LoginRoles.o_PrivilegesLevel.Select.alternate_column_name = xalternate_column_name;
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
                    
                    this.PrivilegesLevel = bVal;
                    
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
                    

                    public void id_AddParameter(DBConnectionControl40.SQL_Parameter par)
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
                    

                    public void Name_AddParameter(DBConnectionControl40.SQL_Parameter par)
                    {
                        m_LoginRoles.o_Name.Where.AddParameter(par);
                    }
                    
                    public bool PrivilegesLevel
                    {
                        get {return m_LoginRoles.o_PrivilegesLevel.Where.enabled;}
                        set {m_LoginRoles.o_PrivilegesLevel.Where.enabled = value;}
                    }
                    
                    public void PrivilegesLevel_Expression(string Expression)
                    {
                        m_LoginRoles.o_PrivilegesLevel.Where.expression = Expression;
                    }
                    

                    public void PrivilegesLevel_AddParameter(DBConnectionControl40.SQL_Parameter par)
                    {
                        m_LoginRoles.o_PrivilegesLevel.Where.AddParameter(par);
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
                    

                    public void description_AddParameter(DBConnectionControl40.SQL_Parameter par)
                    {
                        m_LoginRoles.o_description.Where.AddParameter(par);
                    }
                    
               public void all(bool bVal)
               {

                    this.id = bVal;
                    
                    this.Name = bVal;
                    
                    this.PrivilegesLevel = bVal;
                    
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
                    if (o_PrivilegesLevel.Select.enabled)
                    {
                        if (o_PrivilegesLevel.Select.IsExpression)
                        {
                          if (dr[o_PrivilegesLevel.Select.alternate_column_name] != null)
                          {
                            if (dr[o_PrivilegesLevel.Select.alternate_column_name].GetType() != typeof(System.DBNull))
                            {
                              o_PrivilegesLevel.obj  = dr[o_PrivilegesLevel.Select.alternate_column_name];
                            }
                          }
                        }
                        else
                        {
                          if (dr[LoginRoles.PrivilegesLevel.name] != null)
                          {
                            if (dr[LoginRoles.PrivilegesLevel.name].GetType() != typeof(System.DBNull))
                            {
                            o_PrivilegesLevel.PrivilegesLevel_  = (int) dr[LoginRoles.PrivilegesLevel.name];
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
    public class LoginSession:XTable
    {
        public const string tablename_const = "LoginSession";
        public selection select;
        public WHERE where;

        public void Set_DataGridView_Headers(DataGridView dgv)
        {
            LoginSession_lang m_LoginSession_lang = new LoginSession_lang();
            foreach (DataGridViewColumn dgvc in dgv.Columns)
            {
                foreach (ltext lt in m_LoginSession_lang.col_headers)
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

        public class Login_time:ValSet
           { 
             public const string name = "Login_time";

             public DateTime Login_time_
             {
                get {return (DateTime) obj;}
                set {obj = value;}
             }
           }
           public Login_time o_Login_time = new Login_time();

        public class Logout_time:ValSet
           { 
             public const string name = "Logout_time";

             public DateTime Logout_time_
             {
                get {return (DateTime) obj;}
                set {obj = value;}
             }
           }
           public Logout_time o_Logout_time = new Logout_time();

        public class LoginComputer_id:ValSet
           { 
             public const string name = "LoginComputer_id";

             public int LoginComputer_id_
             {
                get {return (int) obj;}
                set {obj = value;}
             }
           }
           public LoginComputer_id o_LoginComputer_id = new LoginComputer_id();

        public class LoginComputerUser_id:ValSet
           { 
             public const string name = "LoginComputerUser_id";

             public int LoginComputerUser_id_
             {
                get {return (int) obj;}
                set {obj = value;}
             }
           }
           public LoginComputerUser_id o_LoginComputerUser_id = new LoginComputerUser_id();

        public LoginSession(DBConnectionControl40.DBConnection xcon)
           {
                select = new selection(this);
                where  = new WHERE(this);
                m_con = xcon;
                tablename = LoginSession.tablename_const;
                myUpdateObjects = UpdateObjects;


                    o_id.col_name = LoginSession.id.name;
                    o_id.col_type.m_Type = "int";
                    o_id.col_type.bPRIMARY_KEY = true;
                    o_id.col_type.bFOREIGN_KEY = false;
                    o_id.col_type.bUNIQUE = false;
                    o_id.col_type.bNULL = false;
                    Add(o_id);
                    
                    o_LoginUsers_id.col_name = LoginSession.LoginUsers_id.name;
                    o_LoginUsers_id.col_type.m_Type = "int";
                    o_LoginUsers_id.col_type.bPRIMARY_KEY = false;
                    o_LoginUsers_id.col_type.bFOREIGN_KEY = false;
                    o_LoginUsers_id.col_type.bUNIQUE = false;
                    o_LoginUsers_id.col_type.bNULL = false;
                    Add(o_LoginUsers_id);
                    
                    o_Login_time.col_name = LoginSession.Login_time.name;
                    o_Login_time.col_type.m_Type = "datetime";
                    o_Login_time.col_type.bPRIMARY_KEY = false;
                    o_Login_time.col_type.bFOREIGN_KEY = false;
                    o_Login_time.col_type.bUNIQUE = false;
                    o_Login_time.col_type.bNULL = false;
                    Add(o_Login_time);
                    
                    o_Logout_time.col_name = LoginSession.Logout_time.name;
                    o_Logout_time.col_type.m_Type = "datetime";
                    o_Logout_time.col_type.bPRIMARY_KEY = false;
                    o_Logout_time.col_type.bFOREIGN_KEY = false;
                    o_Logout_time.col_type.bUNIQUE = false;
                    o_Logout_time.col_type.bNULL = true;
                    Add(o_Logout_time);
                    
                    o_LoginComputer_id.col_name = LoginSession.LoginComputer_id.name;
                    o_LoginComputer_id.col_type.m_Type = "int";
                    o_LoginComputer_id.col_type.bPRIMARY_KEY = false;
                    o_LoginComputer_id.col_type.bFOREIGN_KEY = false;
                    o_LoginComputer_id.col_type.bUNIQUE = false;
                    o_LoginComputer_id.col_type.bNULL = true;
                    Add(o_LoginComputer_id);
                    
                    o_LoginComputerUser_id.col_name = LoginSession.LoginComputerUser_id.name;
                    o_LoginComputerUser_id.col_type.m_Type = "int";
                    o_LoginComputerUser_id.col_type.bPRIMARY_KEY = false;
                    o_LoginComputerUser_id.col_type.bFOREIGN_KEY = false;
                    o_LoginComputerUser_id.col_type.bUNIQUE = false;
                    o_LoginComputerUser_id.col_type.bNULL = true;
                    Add(o_LoginComputerUser_id);
                    
           }

        public class selection
           {
                private LoginSession m_LoginSession;
                public selection(LoginSession xLoginSession)
                {
                    m_LoginSession =  xLoginSession;
                }

                    public bool id
                    {
                        get {return m_LoginSession.o_id.Select.enabled;}
                        set {m_LoginSession.o_id.Select.enabled = value;}
                    }
                    
                    public void id_Expression(string Expression,string xalternate_column_name)
                    {
                        m_LoginSession.o_id.Select.expression = Expression;
                        m_LoginSession.o_id.Select.alternate_column_name = xalternate_column_name;
                    }
                    
                    public bool LoginUsers_id
                    {
                        get {return m_LoginSession.o_LoginUsers_id.Select.enabled;}
                        set {m_LoginSession.o_LoginUsers_id.Select.enabled = value;}
                    }
                    
                    public void LoginUsers_id_Expression(string Expression,string xalternate_column_name)
                    {
                        m_LoginSession.o_LoginUsers_id.Select.expression = Expression;
                        m_LoginSession.o_LoginUsers_id.Select.alternate_column_name = xalternate_column_name;
                    }
                    
                    public bool Login_time
                    {
                        get {return m_LoginSession.o_Login_time.Select.enabled;}
                        set {m_LoginSession.o_Login_time.Select.enabled = value;}
                    }
                    
                    public void Login_time_Expression(string Expression,string xalternate_column_name)
                    {
                        m_LoginSession.o_Login_time.Select.expression = Expression;
                        m_LoginSession.o_Login_time.Select.alternate_column_name = xalternate_column_name;
                    }
                    
                    public bool Logout_time
                    {
                        get {return m_LoginSession.o_Logout_time.Select.enabled;}
                        set {m_LoginSession.o_Logout_time.Select.enabled = value;}
                    }
                    
                    public void Logout_time_Expression(string Expression,string xalternate_column_name)
                    {
                        m_LoginSession.o_Logout_time.Select.expression = Expression;
                        m_LoginSession.o_Logout_time.Select.alternate_column_name = xalternate_column_name;
                    }
                    
                    public bool LoginComputer_id
                    {
                        get {return m_LoginSession.o_LoginComputer_id.Select.enabled;}
                        set {m_LoginSession.o_LoginComputer_id.Select.enabled = value;}
                    }
                    
                    public void LoginComputer_id_Expression(string Expression,string xalternate_column_name)
                    {
                        m_LoginSession.o_LoginComputer_id.Select.expression = Expression;
                        m_LoginSession.o_LoginComputer_id.Select.alternate_column_name = xalternate_column_name;
                    }
                    
                    public bool LoginComputerUser_id
                    {
                        get {return m_LoginSession.o_LoginComputerUser_id.Select.enabled;}
                        set {m_LoginSession.o_LoginComputerUser_id.Select.enabled = value;}
                    }
                    
                    public void LoginComputerUser_id_Expression(string Expression,string xalternate_column_name)
                    {
                        m_LoginSession.o_LoginComputerUser_id.Select.expression = Expression;
                        m_LoginSession.o_LoginComputerUser_id.Select.alternate_column_name = xalternate_column_name;
                    }
                    
               public void all(bool bVal)
               {

                    this.id = bVal;
                    
                    this.LoginUsers_id = bVal;
                    
                    this.Login_time = bVal;
                    
                    this.Logout_time = bVal;
                    
                    this.LoginComputer_id = bVal;
                    
                    this.LoginComputerUser_id = bVal;
                    
               }
    
           }

        public class WHERE
           {
                private LoginSession m_LoginSession;
                public WHERE(LoginSession xLoginSession)
                {
                    m_LoginSession =  xLoginSession;
                }

                    public bool id
                    {
                        get {return m_LoginSession.o_id.Where.enabled;}
                        set {m_LoginSession.o_id.Where.enabled = value;}
                    }
                    
                    public void id_Expression(string Expression)
                    {
                        m_LoginSession.o_id.Where.expression = Expression;
                    }
                    

                    public void id_AddParameter(DBConnectionControl40.SQL_Parameter par)
                    {
                        m_LoginSession.o_id.Where.AddParameter(par);
                    }
                    
                    public bool LoginUsers_id
                    {
                        get {return m_LoginSession.o_LoginUsers_id.Where.enabled;}
                        set {m_LoginSession.o_LoginUsers_id.Where.enabled = value;}
                    }
                    
                    public void LoginUsers_id_Expression(string Expression)
                    {
                        m_LoginSession.o_LoginUsers_id.Where.expression = Expression;
                    }
                    

                    public void LoginUsers_id_AddParameter(DBConnectionControl40.SQL_Parameter par)
                    {
                        m_LoginSession.o_LoginUsers_id.Where.AddParameter(par);
                    }
                    
                    public bool Login_time
                    {
                        get {return m_LoginSession.o_Login_time.Where.enabled;}
                        set {m_LoginSession.o_Login_time.Where.enabled = value;}
                    }
                    
                    public void Login_time_Expression(string Expression)
                    {
                        m_LoginSession.o_Login_time.Where.expression = Expression;
                    }
                    

                    public void Login_time_AddParameter(DBConnectionControl40.SQL_Parameter par)
                    {
                        m_LoginSession.o_Login_time.Where.AddParameter(par);
                    }
                    
                    public bool Logout_time
                    {
                        get {return m_LoginSession.o_Logout_time.Where.enabled;}
                        set {m_LoginSession.o_Logout_time.Where.enabled = value;}
                    }
                    
                    public void Logout_time_Expression(string Expression)
                    {
                        m_LoginSession.o_Logout_time.Where.expression = Expression;
                    }
                    

                    public void Logout_time_AddParameter(DBConnectionControl40.SQL_Parameter par)
                    {
                        m_LoginSession.o_Logout_time.Where.AddParameter(par);
                    }
                    
                    public bool LoginComputer_id
                    {
                        get {return m_LoginSession.o_LoginComputer_id.Where.enabled;}
                        set {m_LoginSession.o_LoginComputer_id.Where.enabled = value;}
                    }
                    
                    public void LoginComputer_id_Expression(string Expression)
                    {
                        m_LoginSession.o_LoginComputer_id.Where.expression = Expression;
                    }
                    

                    public void LoginComputer_id_AddParameter(DBConnectionControl40.SQL_Parameter par)
                    {
                        m_LoginSession.o_LoginComputer_id.Where.AddParameter(par);
                    }
                    
                    public bool LoginComputerUser_id
                    {
                        get {return m_LoginSession.o_LoginComputerUser_id.Where.enabled;}
                        set {m_LoginSession.o_LoginComputerUser_id.Where.enabled = value;}
                    }
                    
                    public void LoginComputerUser_id_Expression(string Expression)
                    {
                        m_LoginSession.o_LoginComputerUser_id.Where.expression = Expression;
                    }
                    

                    public void LoginComputerUser_id_AddParameter(DBConnectionControl40.SQL_Parameter par)
                    {
                        m_LoginSession.o_LoginComputerUser_id.Where.AddParameter(par);
                    }
                    
               public void all(bool bVal)
               {

                    this.id = bVal;
                    
                    this.LoginUsers_id = bVal;
                    
                    this.Login_time = bVal;
                    
                    this.Logout_time = bVal;
                    
                    this.LoginComputer_id = bVal;
                    
                    this.LoginComputerUser_id = bVal;
                    
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
                          if (dr[LoginSession.id.name] != null)
                          {
                            if (dr[LoginSession.id.name].GetType() != typeof(System.DBNull))
                            {
                            o_id.id_  = (int) dr[LoginSession.id.name];
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
                          if (dr[LoginSession.LoginUsers_id.name] != null)
                          {
                            if (dr[LoginSession.LoginUsers_id.name].GetType() != typeof(System.DBNull))
                            {
                            o_LoginUsers_id.LoginUsers_id_  = (int) dr[LoginSession.LoginUsers_id.name];
                            }
                          }
                        }

                    }
                    if (o_Login_time.Select.enabled)
                    {
                        if (o_Login_time.Select.IsExpression)
                        {
                          if (dr[o_Login_time.Select.alternate_column_name] != null)
                          {
                            if (dr[o_Login_time.Select.alternate_column_name].GetType() != typeof(System.DBNull))
                            {
                              o_Login_time.obj  = dr[o_Login_time.Select.alternate_column_name];
                            }
                          }
                        }
                        else
                        {
                          if (dr[LoginSession.Login_time.name] != null)
                          {
                            if (dr[LoginSession.Login_time.name].GetType() != typeof(System.DBNull))
                            {
                            o_Login_time.Login_time_  = (DateTime) dr[LoginSession.Login_time.name];
                            }
                          }
                        }

                    }
                    if (o_Logout_time.Select.enabled)
                    {
                        if (o_Logout_time.Select.IsExpression)
                        {
                          if (dr[o_Logout_time.Select.alternate_column_name] != null)
                          {
                            if (dr[o_Logout_time.Select.alternate_column_name].GetType() != typeof(System.DBNull))
                            {
                              o_Logout_time.obj  = dr[o_Logout_time.Select.alternate_column_name];
                            }
                          }
                        }
                        else
                        {
                          if (dr[LoginSession.Logout_time.name] != null)
                          {
                            if (dr[LoginSession.Logout_time.name].GetType() != typeof(System.DBNull))
                            {
                            o_Logout_time.Logout_time_  = (DateTime) dr[LoginSession.Logout_time.name];
                            }
                          }
                        }

                    }
                    if (o_LoginComputer_id.Select.enabled)
                    {
                        if (o_LoginComputer_id.Select.IsExpression)
                        {
                          if (dr[o_LoginComputer_id.Select.alternate_column_name] != null)
                          {
                            if (dr[o_LoginComputer_id.Select.alternate_column_name].GetType() != typeof(System.DBNull))
                            {
                              o_LoginComputer_id.obj  = dr[o_LoginComputer_id.Select.alternate_column_name];
                            }
                          }
                        }
                        else
                        {
                          if (dr[LoginSession.LoginComputer_id.name] != null)
                          {
                            if (dr[LoginSession.LoginComputer_id.name].GetType() != typeof(System.DBNull))
                            {
                            o_LoginComputer_id.LoginComputer_id_  = (int) dr[LoginSession.LoginComputer_id.name];
                            }
                          }
                        }

                    }
                    if (o_LoginComputerUser_id.Select.enabled)
                    {
                        if (o_LoginComputerUser_id.Select.IsExpression)
                        {
                          if (dr[o_LoginComputerUser_id.Select.alternate_column_name] != null)
                          {
                            if (dr[o_LoginComputerUser_id.Select.alternate_column_name].GetType() != typeof(System.DBNull))
                            {
                              o_LoginComputerUser_id.obj  = dr[o_LoginComputerUser_id.Select.alternate_column_name];
                            }
                          }
                        }
                        else
                        {
                          if (dr[LoginSession.LoginComputerUser_id.name] != null)
                          {
                            if (dr[LoginSession.LoginComputerUser_id.name].GetType() != typeof(System.DBNull))
                            {
                            o_LoginComputerUser_id.LoginComputerUser_id_  = (int) dr[LoginSession.LoginComputerUser_id.name];
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

        public class Time_When_AdministratorSetsPassword:ValSet
           { 
             public const string name = "Time_When_AdministratorSetsPassword";

             public DateTime Time_When_AdministratorSetsPassword_
             {
                get {return (DateTime) obj;}
                set {obj = value;}
             }
           }
           public Time_When_AdministratorSetsPassword o_Time_When_AdministratorSetsPassword = new Time_When_AdministratorSetsPassword();

        public class Administrator_LoginUsers_id:ValSet
           { 
             public const string name = "Administrator_LoginUsers_id";

             public int Administrator_LoginUsers_id_
             {
                get {return (int) obj;}
                set {obj = value;}
             }
           }
           public Administrator_LoginUsers_id o_Administrator_LoginUsers_id = new Administrator_LoginUsers_id();

        public class Time_When_UserSetsItsOwnPassword_FirstTime:ValSet
           { 
             public const string name = "Time_When_UserSetsItsOwnPassword_FirstTime";

             public DateTime Time_When_UserSetsItsOwnPassword_FirstTime_
             {
                get {return (DateTime) obj;}
                set {obj = value;}
             }
           }
           public Time_When_UserSetsItsOwnPassword_FirstTime o_Time_When_UserSetsItsOwnPassword_FirstTime = new Time_When_UserSetsItsOwnPassword_FirstTime();

        public class Time_When_UserSetsItsOwnPassword_LastTime:ValSet
           { 
             public const string name = "Time_When_UserSetsItsOwnPassword_LastTime";

             public DateTime Time_When_UserSetsItsOwnPassword_LastTime_
             {
                get {return (DateTime) obj;}
                set {obj = value;}
             }
           }
           public Time_When_UserSetsItsOwnPassword_LastTime o_Time_When_UserSetsItsOwnPassword_LastTime = new Time_When_UserSetsItsOwnPassword_LastTime();

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

        public class NotActiveAfterPasswordExpires:ValSet
           { 
             public const string name = "NotActiveAfterPasswordExpires";

             public bool NotActiveAfterPasswordExpires_
             {
                get {return (bool) obj;}
                set {obj = value;}
             }
           }
           public NotActiveAfterPasswordExpires o_NotActiveAfterPasswordExpires = new NotActiveAfterPasswordExpires();

        public LoginUsers(DBConnectionControl40.DBConnection xcon)
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
                    
                    o_Time_When_AdministratorSetsPassword.col_name = LoginUsers.Time_When_AdministratorSetsPassword.name;
                    o_Time_When_AdministratorSetsPassword.col_type.m_Type = "datetime";
                    o_Time_When_AdministratorSetsPassword.col_type.bPRIMARY_KEY = false;
                    o_Time_When_AdministratorSetsPassword.col_type.bFOREIGN_KEY = false;
                    o_Time_When_AdministratorSetsPassword.col_type.bUNIQUE = false;
                    o_Time_When_AdministratorSetsPassword.col_type.bNULL = true;
                    Add(o_Time_When_AdministratorSetsPassword);
                    
                    o_Administrator_LoginUsers_id.col_name = LoginUsers.Administrator_LoginUsers_id.name;
                    o_Administrator_LoginUsers_id.col_type.m_Type = "int";
                    o_Administrator_LoginUsers_id.col_type.bPRIMARY_KEY = false;
                    o_Administrator_LoginUsers_id.col_type.bFOREIGN_KEY = false;
                    o_Administrator_LoginUsers_id.col_type.bUNIQUE = false;
                    o_Administrator_LoginUsers_id.col_type.bNULL = true;
                    Add(o_Administrator_LoginUsers_id);
                    
                    o_Time_When_UserSetsItsOwnPassword_FirstTime.col_name = LoginUsers.Time_When_UserSetsItsOwnPassword_FirstTime.name;
                    o_Time_When_UserSetsItsOwnPassword_FirstTime.col_type.m_Type = "datetime";
                    o_Time_When_UserSetsItsOwnPassword_FirstTime.col_type.bPRIMARY_KEY = false;
                    o_Time_When_UserSetsItsOwnPassword_FirstTime.col_type.bFOREIGN_KEY = false;
                    o_Time_When_UserSetsItsOwnPassword_FirstTime.col_type.bUNIQUE = false;
                    o_Time_When_UserSetsItsOwnPassword_FirstTime.col_type.bNULL = true;
                    Add(o_Time_When_UserSetsItsOwnPassword_FirstTime);
                    
                    o_Time_When_UserSetsItsOwnPassword_LastTime.col_name = LoginUsers.Time_When_UserSetsItsOwnPassword_LastTime.name;
                    o_Time_When_UserSetsItsOwnPassword_LastTime.col_type.m_Type = "datetime";
                    o_Time_When_UserSetsItsOwnPassword_LastTime.col_type.bPRIMARY_KEY = false;
                    o_Time_When_UserSetsItsOwnPassword_LastTime.col_type.bFOREIGN_KEY = false;
                    o_Time_When_UserSetsItsOwnPassword_LastTime.col_type.bUNIQUE = false;
                    o_Time_When_UserSetsItsOwnPassword_LastTime.col_type.bNULL = true;
                    Add(o_Time_When_UserSetsItsOwnPassword_LastTime);
                    
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
                    
                    o_NotActiveAfterPasswordExpires.col_name = LoginUsers.NotActiveAfterPasswordExpires.name;
                    o_NotActiveAfterPasswordExpires.col_type.m_Type = "bit";
                    o_NotActiveAfterPasswordExpires.col_type.bPRIMARY_KEY = false;
                    o_NotActiveAfterPasswordExpires.col_type.bFOREIGN_KEY = false;
                    o_NotActiveAfterPasswordExpires.col_type.bUNIQUE = false;
                    o_NotActiveAfterPasswordExpires.col_type.bNULL = false;
                    Add(o_NotActiveAfterPasswordExpires);
                    
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
                    
                    public bool Time_When_AdministratorSetsPassword
                    {
                        get {return m_LoginUsers.o_Time_When_AdministratorSetsPassword.Select.enabled;}
                        set {m_LoginUsers.o_Time_When_AdministratorSetsPassword.Select.enabled = value;}
                    }
                    
                    public void Time_When_AdministratorSetsPassword_Expression(string Expression,string xalternate_column_name)
                    {
                        m_LoginUsers.o_Time_When_AdministratorSetsPassword.Select.expression = Expression;
                        m_LoginUsers.o_Time_When_AdministratorSetsPassword.Select.alternate_column_name = xalternate_column_name;
                    }
                    
                    public bool Administrator_LoginUsers_id
                    {
                        get {return m_LoginUsers.o_Administrator_LoginUsers_id.Select.enabled;}
                        set {m_LoginUsers.o_Administrator_LoginUsers_id.Select.enabled = value;}
                    }
                    
                    public void Administrator_LoginUsers_id_Expression(string Expression,string xalternate_column_name)
                    {
                        m_LoginUsers.o_Administrator_LoginUsers_id.Select.expression = Expression;
                        m_LoginUsers.o_Administrator_LoginUsers_id.Select.alternate_column_name = xalternate_column_name;
                    }
                    
                    public bool Time_When_UserSetsItsOwnPassword_FirstTime
                    {
                        get {return m_LoginUsers.o_Time_When_UserSetsItsOwnPassword_FirstTime.Select.enabled;}
                        set {m_LoginUsers.o_Time_When_UserSetsItsOwnPassword_FirstTime.Select.enabled = value;}
                    }
                    
                    public void Time_When_UserSetsItsOwnPassword_FirstTime_Expression(string Expression,string xalternate_column_name)
                    {
                        m_LoginUsers.o_Time_When_UserSetsItsOwnPassword_FirstTime.Select.expression = Expression;
                        m_LoginUsers.o_Time_When_UserSetsItsOwnPassword_FirstTime.Select.alternate_column_name = xalternate_column_name;
                    }
                    
                    public bool Time_When_UserSetsItsOwnPassword_LastTime
                    {
                        get {return m_LoginUsers.o_Time_When_UserSetsItsOwnPassword_LastTime.Select.enabled;}
                        set {m_LoginUsers.o_Time_When_UserSetsItsOwnPassword_LastTime.Select.enabled = value;}
                    }
                    
                    public void Time_When_UserSetsItsOwnPassword_LastTime_Expression(string Expression,string xalternate_column_name)
                    {
                        m_LoginUsers.o_Time_When_UserSetsItsOwnPassword_LastTime.Select.expression = Expression;
                        m_LoginUsers.o_Time_When_UserSetsItsOwnPassword_LastTime.Select.alternate_column_name = xalternate_column_name;
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
                    
                    public bool NotActiveAfterPasswordExpires
                    {
                        get {return m_LoginUsers.o_NotActiveAfterPasswordExpires.Select.enabled;}
                        set {m_LoginUsers.o_NotActiveAfterPasswordExpires.Select.enabled = value;}
                    }
                    
                    public void NotActiveAfterPasswordExpires_Expression(string Expression,string xalternate_column_name)
                    {
                        m_LoginUsers.o_NotActiveAfterPasswordExpires.Select.expression = Expression;
                        m_LoginUsers.o_NotActiveAfterPasswordExpires.Select.alternate_column_name = xalternate_column_name;
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
                    
                    this.Time_When_AdministratorSetsPassword = bVal;
                    
                    this.Administrator_LoginUsers_id = bVal;
                    
                    this.Time_When_UserSetsItsOwnPassword_FirstTime = bVal;
                    
                    this.Time_When_UserSetsItsOwnPassword_LastTime = bVal;
                    
                    this.PasswordNeverExpires = bVal;
                    
                    this.Maximum_password_age_in_days = bVal;
                    
                    this.NotActiveAfterPasswordExpires = bVal;
                    
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
                    

                    public void id_AddParameter(DBConnectionControl40.SQL_Parameter par)
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
                    

                    public void first_name_AddParameter(DBConnectionControl40.SQL_Parameter par)
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
                    

                    public void last_name_AddParameter(DBConnectionControl40.SQL_Parameter par)
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
                    

                    public void Identity_AddParameter(DBConnectionControl40.SQL_Parameter par)
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
                    

                    public void Contact_AddParameter(DBConnectionControl40.SQL_Parameter par)
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
                    

                    public void username_AddParameter(DBConnectionControl40.SQL_Parameter par)
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
                    

                    public void password_AddParameter(DBConnectionControl40.SQL_Parameter par)
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
                    

                    public void enabled_AddParameter(DBConnectionControl40.SQL_Parameter par)
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
                    

                    public void ChangePasswordOnFirstLogin_AddParameter(DBConnectionControl40.SQL_Parameter par)
                    {
                        m_LoginUsers.o_ChangePasswordOnFirstLogin.Where.AddParameter(par);
                    }
                    
                    public bool Time_When_AdministratorSetsPassword
                    {
                        get {return m_LoginUsers.o_Time_When_AdministratorSetsPassword.Where.enabled;}
                        set {m_LoginUsers.o_Time_When_AdministratorSetsPassword.Where.enabled = value;}
                    }
                    
                    public void Time_When_AdministratorSetsPassword_Expression(string Expression)
                    {
                        m_LoginUsers.o_Time_When_AdministratorSetsPassword.Where.expression = Expression;
                    }
                    

                    public void Time_When_AdministratorSetsPassword_AddParameter(DBConnectionControl40.SQL_Parameter par)
                    {
                        m_LoginUsers.o_Time_When_AdministratorSetsPassword.Where.AddParameter(par);
                    }
                    
                    public bool Administrator_LoginUsers_id
                    {
                        get {return m_LoginUsers.o_Administrator_LoginUsers_id.Where.enabled;}
                        set {m_LoginUsers.o_Administrator_LoginUsers_id.Where.enabled = value;}
                    }
                    
                    public void Administrator_LoginUsers_id_Expression(string Expression)
                    {
                        m_LoginUsers.o_Administrator_LoginUsers_id.Where.expression = Expression;
                    }
                    

                    public void Administrator_LoginUsers_id_AddParameter(DBConnectionControl40.SQL_Parameter par)
                    {
                        m_LoginUsers.o_Administrator_LoginUsers_id.Where.AddParameter(par);
                    }
                    
                    public bool Time_When_UserSetsItsOwnPassword_FirstTime
                    {
                        get {return m_LoginUsers.o_Time_When_UserSetsItsOwnPassword_FirstTime.Where.enabled;}
                        set {m_LoginUsers.o_Time_When_UserSetsItsOwnPassword_FirstTime.Where.enabled = value;}
                    }
                    
                    public void Time_When_UserSetsItsOwnPassword_FirstTime_Expression(string Expression)
                    {
                        m_LoginUsers.o_Time_When_UserSetsItsOwnPassword_FirstTime.Where.expression = Expression;
                    }
                    

                    public void Time_When_UserSetsItsOwnPassword_FirstTime_AddParameter(DBConnectionControl40.SQL_Parameter par)
                    {
                        m_LoginUsers.o_Time_When_UserSetsItsOwnPassword_FirstTime.Where.AddParameter(par);
                    }
                    
                    public bool Time_When_UserSetsItsOwnPassword_LastTime
                    {
                        get {return m_LoginUsers.o_Time_When_UserSetsItsOwnPassword_LastTime.Where.enabled;}
                        set {m_LoginUsers.o_Time_When_UserSetsItsOwnPassword_LastTime.Where.enabled = value;}
                    }
                    
                    public void Time_When_UserSetsItsOwnPassword_LastTime_Expression(string Expression)
                    {
                        m_LoginUsers.o_Time_When_UserSetsItsOwnPassword_LastTime.Where.expression = Expression;
                    }
                    

                    public void Time_When_UserSetsItsOwnPassword_LastTime_AddParameter(DBConnectionControl40.SQL_Parameter par)
                    {
                        m_LoginUsers.o_Time_When_UserSetsItsOwnPassword_LastTime.Where.AddParameter(par);
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
                    

                    public void PasswordNeverExpires_AddParameter(DBConnectionControl40.SQL_Parameter par)
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
                    

                    public void Maximum_password_age_in_days_AddParameter(DBConnectionControl40.SQL_Parameter par)
                    {
                        m_LoginUsers.o_Maximum_password_age_in_days.Where.AddParameter(par);
                    }
                    
                    public bool NotActiveAfterPasswordExpires
                    {
                        get {return m_LoginUsers.o_NotActiveAfterPasswordExpires.Where.enabled;}
                        set {m_LoginUsers.o_NotActiveAfterPasswordExpires.Where.enabled = value;}
                    }
                    
                    public void NotActiveAfterPasswordExpires_Expression(string Expression)
                    {
                        m_LoginUsers.o_NotActiveAfterPasswordExpires.Where.expression = Expression;
                    }
                    

                    public void NotActiveAfterPasswordExpires_AddParameter(DBConnectionControl40.SQL_Parameter par)
                    {
                        m_LoginUsers.o_NotActiveAfterPasswordExpires.Where.AddParameter(par);
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
                    
                    this.Time_When_AdministratorSetsPassword = bVal;
                    
                    this.Administrator_LoginUsers_id = bVal;
                    
                    this.Time_When_UserSetsItsOwnPassword_FirstTime = bVal;
                    
                    this.Time_When_UserSetsItsOwnPassword_LastTime = bVal;
                    
                    this.PasswordNeverExpires = bVal;
                    
                    this.Maximum_password_age_in_days = bVal;
                    
                    this.NotActiveAfterPasswordExpires = bVal;
                    
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
                    if (o_Time_When_AdministratorSetsPassword.Select.enabled)
                    {
                        if (o_Time_When_AdministratorSetsPassword.Select.IsExpression)
                        {
                          if (dr[o_Time_When_AdministratorSetsPassword.Select.alternate_column_name] != null)
                          {
                            if (dr[o_Time_When_AdministratorSetsPassword.Select.alternate_column_name].GetType() != typeof(System.DBNull))
                            {
                              o_Time_When_AdministratorSetsPassword.obj  = dr[o_Time_When_AdministratorSetsPassword.Select.alternate_column_name];
                            }
                          }
                        }
                        else
                        {
                          if (dr[LoginUsers.Time_When_AdministratorSetsPassword.name] != null)
                          {
                            if (dr[LoginUsers.Time_When_AdministratorSetsPassword.name].GetType() != typeof(System.DBNull))
                            {
                            o_Time_When_AdministratorSetsPassword.Time_When_AdministratorSetsPassword_  = (DateTime) dr[LoginUsers.Time_When_AdministratorSetsPassword.name];
                            }
                          }
                        }

                    }
                    if (o_Administrator_LoginUsers_id.Select.enabled)
                    {
                        if (o_Administrator_LoginUsers_id.Select.IsExpression)
                        {
                          if (dr[o_Administrator_LoginUsers_id.Select.alternate_column_name] != null)
                          {
                            if (dr[o_Administrator_LoginUsers_id.Select.alternate_column_name].GetType() != typeof(System.DBNull))
                            {
                              o_Administrator_LoginUsers_id.obj  = dr[o_Administrator_LoginUsers_id.Select.alternate_column_name];
                            }
                          }
                        }
                        else
                        {
                          if (dr[LoginUsers.Administrator_LoginUsers_id.name] != null)
                          {
                            if (dr[LoginUsers.Administrator_LoginUsers_id.name].GetType() != typeof(System.DBNull))
                            {
                            o_Administrator_LoginUsers_id.Administrator_LoginUsers_id_  = (int) dr[LoginUsers.Administrator_LoginUsers_id.name];
                            }
                          }
                        }

                    }
                    if (o_Time_When_UserSetsItsOwnPassword_FirstTime.Select.enabled)
                    {
                        if (o_Time_When_UserSetsItsOwnPassword_FirstTime.Select.IsExpression)
                        {
                          if (dr[o_Time_When_UserSetsItsOwnPassword_FirstTime.Select.alternate_column_name] != null)
                          {
                            if (dr[o_Time_When_UserSetsItsOwnPassword_FirstTime.Select.alternate_column_name].GetType() != typeof(System.DBNull))
                            {
                              o_Time_When_UserSetsItsOwnPassword_FirstTime.obj  = dr[o_Time_When_UserSetsItsOwnPassword_FirstTime.Select.alternate_column_name];
                            }
                          }
                        }
                        else
                        {
                          if (dr[LoginUsers.Time_When_UserSetsItsOwnPassword_FirstTime.name] != null)
                          {
                            if (dr[LoginUsers.Time_When_UserSetsItsOwnPassword_FirstTime.name].GetType() != typeof(System.DBNull))
                            {
                            o_Time_When_UserSetsItsOwnPassword_FirstTime.Time_When_UserSetsItsOwnPassword_FirstTime_  = (DateTime) dr[LoginUsers.Time_When_UserSetsItsOwnPassword_FirstTime.name];
                            }
                          }
                        }

                    }
                    if (o_Time_When_UserSetsItsOwnPassword_LastTime.Select.enabled)
                    {
                        if (o_Time_When_UserSetsItsOwnPassword_LastTime.Select.IsExpression)
                        {
                          if (dr[o_Time_When_UserSetsItsOwnPassword_LastTime.Select.alternate_column_name] != null)
                          {
                            if (dr[o_Time_When_UserSetsItsOwnPassword_LastTime.Select.alternate_column_name].GetType() != typeof(System.DBNull))
                            {
                              o_Time_When_UserSetsItsOwnPassword_LastTime.obj  = dr[o_Time_When_UserSetsItsOwnPassword_LastTime.Select.alternate_column_name];
                            }
                          }
                        }
                        else
                        {
                          if (dr[LoginUsers.Time_When_UserSetsItsOwnPassword_LastTime.name] != null)
                          {
                            if (dr[LoginUsers.Time_When_UserSetsItsOwnPassword_LastTime.name].GetType() != typeof(System.DBNull))
                            {
                            o_Time_When_UserSetsItsOwnPassword_LastTime.Time_When_UserSetsItsOwnPassword_LastTime_  = (DateTime) dr[LoginUsers.Time_When_UserSetsItsOwnPassword_LastTime.name];
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
                    if (o_NotActiveAfterPasswordExpires.Select.enabled)
                    {
                        if (o_NotActiveAfterPasswordExpires.Select.IsExpression)
                        {
                          if (dr[o_NotActiveAfterPasswordExpires.Select.alternate_column_name] != null)
                          {
                            if (dr[o_NotActiveAfterPasswordExpires.Select.alternate_column_name].GetType() != typeof(System.DBNull))
                            {
                              o_NotActiveAfterPasswordExpires.obj  = dr[o_NotActiveAfterPasswordExpires.Select.alternate_column_name];
                            }
                          }
                        }
                        else
                        {
                          if (dr[LoginUsers.NotActiveAfterPasswordExpires.name] != null)
                          {
                            if (dr[LoginUsers.NotActiveAfterPasswordExpires.name].GetType() != typeof(System.DBNull))
                            {
                            o_NotActiveAfterPasswordExpires.NotActiveAfterPasswordExpires_  = (bool) dr[LoginUsers.NotActiveAfterPasswordExpires.name];
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

        public LoginUsersAndLoginRoles(DBConnectionControl40.DBConnection xcon)
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
                    o_LoginUsers_id.col_type.bFOREIGN_KEY = false;
                    o_LoginUsers_id.col_type.bUNIQUE = false;
                    o_LoginUsers_id.col_type.bNULL = false;
                    Add(o_LoginUsers_id);
                    
                    o_LoginRoles_id.col_name = LoginUsersAndLoginRoles.LoginRoles_id.name;
                    o_LoginRoles_id.col_type.m_Type = "int";
                    o_LoginRoles_id.col_type.bPRIMARY_KEY = false;
                    o_LoginRoles_id.col_type.bFOREIGN_KEY = false;
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
                    

                    public void id_AddParameter(DBConnectionControl40.SQL_Parameter par)
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
                    

                    public void LoginUsers_id_AddParameter(DBConnectionControl40.SQL_Parameter par)
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
                    

                    public void LoginRoles_id_AddParameter(DBConnectionControl40.SQL_Parameter par)
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
           public Users_id o_LoginUsers_id = new Users_id();

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

        public class NotActiveAfterPasswordExpires:ValSet
           { 
             public const string name = "NotActiveAfterPasswordExpires";
             public bool NotActiveAfterPasswordExpires_
             {
                get {return (bool) obj;}
                set {obj = value;}
             }
           }
           public NotActiveAfterPasswordExpires o_NotActiveAfterPasswordExpires = new NotActiveAfterPasswordExpires();

        public class Time_When_UserSetsItsOwnPassword_FirstTime:ValSet
           { 
             public const string name = "Time_When_UserSetsItsOwnPassword_FirstTime";
             public DateTime Time_When_UserSetsItsOwnPassword_FirstTime_
             {
                get {return (DateTime) obj;}
                set {obj = value;}
             }
           }
           public Time_When_UserSetsItsOwnPassword_FirstTime o_Time_When_UserSetsItsOwnPassword_FirstTime = new Time_When_UserSetsItsOwnPassword_FirstTime();

        public class Time_When_UserSetsItsOwnPassword_LastTime:ValSet
           { 
             public const string name = "Time_When_UserSetsItsOwnPassword_LastTime";
             public DateTime Time_When_UserSetsItsOwnPassword_LastTime_
             {
                get {return (DateTime) obj;}
                set {obj = value;}
             }
           }
           public Time_When_UserSetsItsOwnPassword_LastTime o_Time_When_UserSetsItsOwnPassword_LastTime = new Time_When_UserSetsItsOwnPassword_LastTime();

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

        public class Role_Name:ValSet
           { 
             public const string name = "Role_Name";
             public string Role_Name_
             {
                get {return (string) obj;}
                set {obj = value;}
             }
           }
           public Role_Name o_Role_Name = new Role_Name();

        public class Role_PrivilegesLevel:ValSet
           { 
             public const string name = "Role_PrivilegesLevel";
             public int Role_PrivilegesLevel_
             {
                get {return (int) obj;}
                set {obj = value;}
             }
           }
           public Role_PrivilegesLevel o_Role_PrivilegesLevel = new Role_PrivilegesLevel();

        public class Role_description:ValSet
           { 
             public const string name = "Role_description";
             public string Role_description_
             {
                get {return (string) obj;}
                set {obj = value;}
             }
           }
           public Role_description o_Role_description = new Role_description();

        public Login_VIEW(DBConnectionControl40.DBConnection xcon)
           {
                select = new selection(this);
                where  = new WHERE(this);
                m_con = xcon;
                tablename = Login_VIEW.tablename_const;
                myUpdateObjects = UpdateObjects;


                    o_LoginUsers_id.col_name = Login_VIEW.Users_id.name;
                    o_LoginUsers_id.col_type.m_Type = "int";
                    Add(o_LoginUsers_id);
                    
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
                    
                    o_NotActiveAfterPasswordExpires.col_name = Login_VIEW.NotActiveAfterPasswordExpires.name;
                    o_NotActiveAfterPasswordExpires.col_type.m_Type = "bit";
                    Add(o_NotActiveAfterPasswordExpires);
                    
                    o_Time_When_UserSetsItsOwnPassword_FirstTime.col_name = Login_VIEW.Time_When_UserSetsItsOwnPassword_FirstTime.name;
                    o_Time_When_UserSetsItsOwnPassword_FirstTime.col_type.m_Type = "datetime";
                    Add(o_Time_When_UserSetsItsOwnPassword_FirstTime);
                    
                    o_Time_When_UserSetsItsOwnPassword_LastTime.col_name = Login_VIEW.Time_When_UserSetsItsOwnPassword_LastTime.name;
                    o_Time_When_UserSetsItsOwnPassword_LastTime.col_type.m_Type = "datetime";
                    Add(o_Time_When_UserSetsItsOwnPassword_LastTime);
                    
                    o_ChangePasswordOnFirstLogin.col_name = Login_VIEW.ChangePasswordOnFirstLogin.name;
                    o_ChangePasswordOnFirstLogin.col_type.m_Type = "bit";
                    Add(o_ChangePasswordOnFirstLogin);
                    
                    o_Role_id.col_name = Login_VIEW.Role_id.name;
                    o_Role_id.col_type.m_Type = "int";
                    Add(o_Role_id);
                    
                    o_Role_Name.col_name = Login_VIEW.Role_Name.name;
                    o_Role_Name.col_type.m_Type = "nvarchar";
                    Add(o_Role_Name);
                    
                    o_Role_PrivilegesLevel.col_name = Login_VIEW.Role_PrivilegesLevel.name;
                    o_Role_PrivilegesLevel.col_type.m_Type = "int";
                    Add(o_Role_PrivilegesLevel);
                    
                    o_Role_description.col_name = Login_VIEW.Role_description.name;
                    o_Role_description.col_type.m_Type = "nvarchar";
                    Add(o_Role_description);
                    
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
                        get {return m_Login_VIEW.o_LoginUsers_id.Select.enabled;}
                        set {m_Login_VIEW.o_LoginUsers_id.Select.enabled = value;}
                    }
                    
                    public void Users_id_Expression(string Expression,string xalternate_column_name)
                    {
                        m_Login_VIEW.o_LoginUsers_id.Select.expression = Expression;
                        m_Login_VIEW.o_LoginUsers_id.Select.alternate_column_name = xalternate_column_name;
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
                    
                    public bool NotActiveAfterPasswordExpires
                    {
                        get {return m_Login_VIEW.o_NotActiveAfterPasswordExpires.Select.enabled;}
                        set {m_Login_VIEW.o_NotActiveAfterPasswordExpires.Select.enabled = value;}
                    }
                    
                    public void NotActiveAfterPasswordExpires_Expression(string Expression,string xalternate_column_name)
                    {
                        m_Login_VIEW.o_NotActiveAfterPasswordExpires.Select.expression = Expression;
                        m_Login_VIEW.o_NotActiveAfterPasswordExpires.Select.alternate_column_name = xalternate_column_name;
                    }
                    
                    public bool Time_When_UserSetsItsOwnPassword_FirstTime
                    {
                        get {return m_Login_VIEW.o_Time_When_UserSetsItsOwnPassword_FirstTime.Select.enabled;}
                        set {m_Login_VIEW.o_Time_When_UserSetsItsOwnPassword_FirstTime.Select.enabled = value;}
                    }
                    
                    public void Time_When_UserSetsItsOwnPassword_FirstTime_Expression(string Expression,string xalternate_column_name)
                    {
                        m_Login_VIEW.o_Time_When_UserSetsItsOwnPassword_FirstTime.Select.expression = Expression;
                        m_Login_VIEW.o_Time_When_UserSetsItsOwnPassword_FirstTime.Select.alternate_column_name = xalternate_column_name;
                    }
                    
                    public bool Time_When_UserSetsItsOwnPassword_LastTime
                    {
                        get {return m_Login_VIEW.o_Time_When_UserSetsItsOwnPassword_LastTime.Select.enabled;}
                        set {m_Login_VIEW.o_Time_When_UserSetsItsOwnPassword_LastTime.Select.enabled = value;}
                    }
                    
                    public void Time_When_UserSetsItsOwnPassword_LastTime_Expression(string Expression,string xalternate_column_name)
                    {
                        m_Login_VIEW.o_Time_When_UserSetsItsOwnPassword_LastTime.Select.expression = Expression;
                        m_Login_VIEW.o_Time_When_UserSetsItsOwnPassword_LastTime.Select.alternate_column_name = xalternate_column_name;
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
                    
                    public bool Role_Name
                    {
                        get {return m_Login_VIEW.o_Role_Name.Select.enabled;}
                        set {m_Login_VIEW.o_Role_Name.Select.enabled = value;}
                    }
                    
                    public void Role_Name_Expression(string Expression,string xalternate_column_name)
                    {
                        m_Login_VIEW.o_Role_Name.Select.expression = Expression;
                        m_Login_VIEW.o_Role_Name.Select.alternate_column_name = xalternate_column_name;
                    }
                    
                    public bool Role_PrivilegesLevel
                    {
                        get {return m_Login_VIEW.o_Role_PrivilegesLevel.Select.enabled;}
                        set {m_Login_VIEW.o_Role_PrivilegesLevel.Select.enabled = value;}
                    }
                    
                    public void Role_PrivilegesLevel_Expression(string Expression,string xalternate_column_name)
                    {
                        m_Login_VIEW.o_Role_PrivilegesLevel.Select.expression = Expression;
                        m_Login_VIEW.o_Role_PrivilegesLevel.Select.alternate_column_name = xalternate_column_name;
                    }
                    
                    public bool Role_description
                    {
                        get {return m_Login_VIEW.o_Role_description.Select.enabled;}
                        set {m_Login_VIEW.o_Role_description.Select.enabled = value;}
                    }
                    
                    public void Role_description_Expression(string Expression,string xalternate_column_name)
                    {
                        m_Login_VIEW.o_Role_description.Select.expression = Expression;
                        m_Login_VIEW.o_Role_description.Select.alternate_column_name = xalternate_column_name;
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
                    
                    this.NotActiveAfterPasswordExpires = bVal;
                    
                    this.Time_When_UserSetsItsOwnPassword_FirstTime = bVal;
                    
                    this.Time_When_UserSetsItsOwnPassword_LastTime = bVal;
                    
                    this.ChangePasswordOnFirstLogin = bVal;
                    
                    this.Role_id = bVal;
                    
                    this.Role_Name = bVal;
                    
                    this.Role_PrivilegesLevel = bVal;
                    
                    this.Role_description = bVal;
                    
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
                        get {return m_Login_VIEW.o_LoginUsers_id.Where.enabled;}
                        set {m_Login_VIEW.o_LoginUsers_id.Where.enabled = value;}
                    }
                    
                    public void Users_id_Expression(string Expression)
                    {
                        m_Login_VIEW.o_LoginUsers_id.Where.expression = Expression;
                    }
                    

                    public void Users_id_AddParameter(DBConnectionControl40.SQL_Parameter par)
                    {
                        m_Login_VIEW.o_LoginUsers_id.Where.AddParameter(par);
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
                    

                    public void first_name_AddParameter(DBConnectionControl40.SQL_Parameter par)
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
                    

                    public void last_name_AddParameter(DBConnectionControl40.SQL_Parameter par)
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
                    

                    public void Identity_AddParameter(DBConnectionControl40.SQL_Parameter par)
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
                    

                    public void Contact_AddParameter(DBConnectionControl40.SQL_Parameter par)
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
                    

                    public void username_AddParameter(DBConnectionControl40.SQL_Parameter par)
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
                    

                    public void password_AddParameter(DBConnectionControl40.SQL_Parameter par)
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
                    

                    public void PasswordNeverExpires_AddParameter(DBConnectionControl40.SQL_Parameter par)
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
                    

                    public void enabled_AddParameter(DBConnectionControl40.SQL_Parameter par)
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
                    

                    public void Maximum_password_age_in_days_AddParameter(DBConnectionControl40.SQL_Parameter par)
                    {
                        m_Login_VIEW.o_Maximum_password_age_in_days.Where.AddParameter(par);
                    }
                    
                    public bool NotActiveAfterPasswordExpires
                    {
                        get {return m_Login_VIEW.o_NotActiveAfterPasswordExpires.Where.enabled;}
                        set {m_Login_VIEW.o_NotActiveAfterPasswordExpires.Where.enabled = value;}
                    }
                    
                    public void NotActiveAfterPasswordExpires_Expression(string Expression)
                    {
                        m_Login_VIEW.o_NotActiveAfterPasswordExpires.Where.expression = Expression;
                    }
                    

                    public void NotActiveAfterPasswordExpires_AddParameter(DBConnectionControl40.SQL_Parameter par)
                    {
                        m_Login_VIEW.o_NotActiveAfterPasswordExpires.Where.AddParameter(par);
                    }
                    
                    public bool Time_When_UserSetsItsOwnPassword_FirstTime
                    {
                        get {return m_Login_VIEW.o_Time_When_UserSetsItsOwnPassword_FirstTime.Where.enabled;}
                        set {m_Login_VIEW.o_Time_When_UserSetsItsOwnPassword_FirstTime.Where.enabled = value;}
                    }
                    
                    public void Time_When_UserSetsItsOwnPassword_FirstTime_Expression(string Expression)
                    {
                        m_Login_VIEW.o_Time_When_UserSetsItsOwnPassword_FirstTime.Where.expression = Expression;
                    }
                    

                    public void Time_When_UserSetsItsOwnPassword_FirstTime_AddParameter(DBConnectionControl40.SQL_Parameter par)
                    {
                        m_Login_VIEW.o_Time_When_UserSetsItsOwnPassword_FirstTime.Where.AddParameter(par);
                    }
                    
                    public bool Time_When_UserSetsItsOwnPassword_LastTime
                    {
                        get {return m_Login_VIEW.o_Time_When_UserSetsItsOwnPassword_LastTime.Where.enabled;}
                        set {m_Login_VIEW.o_Time_When_UserSetsItsOwnPassword_LastTime.Where.enabled = value;}
                    }
                    
                    public void Time_When_UserSetsItsOwnPassword_LastTime_Expression(string Expression)
                    {
                        m_Login_VIEW.o_Time_When_UserSetsItsOwnPassword_LastTime.Where.expression = Expression;
                    }
                    

                    public void Time_When_UserSetsItsOwnPassword_LastTime_AddParameter(DBConnectionControl40.SQL_Parameter par)
                    {
                        m_Login_VIEW.o_Time_When_UserSetsItsOwnPassword_LastTime.Where.AddParameter(par);
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
                    

                    public void ChangePasswordOnFirstLogin_AddParameter(DBConnectionControl40.SQL_Parameter par)
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
                    

                    public void Role_id_AddParameter(DBConnectionControl40.SQL_Parameter par)
                    {
                        m_Login_VIEW.o_Role_id.Where.AddParameter(par);
                    }
                    
                    public bool Role_Name
                    {
                        get {return m_Login_VIEW.o_Role_Name.Where.enabled;}
                        set {m_Login_VIEW.o_Role_Name.Where.enabled = value;}
                    }
                    
                    public void Role_Name_Expression(string Expression)
                    {
                        m_Login_VIEW.o_Role_Name.Where.expression = Expression;
                    }
                    

                    public void Role_Name_AddParameter(DBConnectionControl40.SQL_Parameter par)
                    {
                        m_Login_VIEW.o_Role_Name.Where.AddParameter(par);
                    }
                    
                    public bool Role_PrivilegesLevel
                    {
                        get {return m_Login_VIEW.o_Role_PrivilegesLevel.Where.enabled;}
                        set {m_Login_VIEW.o_Role_PrivilegesLevel.Where.enabled = value;}
                    }
                    
                    public void Role_PrivilegesLevel_Expression(string Expression)
                    {
                        m_Login_VIEW.o_Role_PrivilegesLevel.Where.expression = Expression;
                    }
                    

                    public void Role_PrivilegesLevel_AddParameter(DBConnectionControl40.SQL_Parameter par)
                    {
                        m_Login_VIEW.o_Role_PrivilegesLevel.Where.AddParameter(par);
                    }
                    
                    public bool Role_description
                    {
                        get {return m_Login_VIEW.o_Role_description.Where.enabled;}
                        set {m_Login_VIEW.o_Role_description.Where.enabled = value;}
                    }
                    
                    public void Role_description_Expression(string Expression)
                    {
                        m_Login_VIEW.o_Role_description.Where.expression = Expression;
                    }
                    

                    public void Role_description_AddParameter(DBConnectionControl40.SQL_Parameter par)
                    {
                        m_Login_VIEW.o_Role_description.Where.AddParameter(par);
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
                    
                    this.NotActiveAfterPasswordExpires = bVal;
                    
                    this.Time_When_UserSetsItsOwnPassword_FirstTime = bVal;
                    
                    this.Time_When_UserSetsItsOwnPassword_LastTime = bVal;
                    
                    this.ChangePasswordOnFirstLogin = bVal;
                    
                    this.Role_id = bVal;
                    
                    this.Role_Name = bVal;
                    
                    this.Role_PrivilegesLevel = bVal;
                    
                    this.Role_description = bVal;
                    
               }
    
           }

        public void UpdateObjects(DataRow dr)
           {

                    if (o_LoginUsers_id.Select.enabled)
                    {
                      if (dr[Login_VIEW.Users_id.name] != null)
                      {
                        if (dr[Login_VIEW.Users_id.name].GetType() != typeof(System.DBNull))
                        {
                        o_LoginUsers_id.obj  =  dr[Login_VIEW.Users_id.name];
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
                    if (o_NotActiveAfterPasswordExpires.Select.enabled)
                    {
                      if (dr[Login_VIEW.NotActiveAfterPasswordExpires.name] != null)
                      {
                        if (dr[Login_VIEW.NotActiveAfterPasswordExpires.name].GetType() != typeof(System.DBNull))
                        {
                        o_NotActiveAfterPasswordExpires.obj  =  dr[Login_VIEW.NotActiveAfterPasswordExpires.name];
                        }
                      }
                    }
                    if (o_Time_When_UserSetsItsOwnPassword_FirstTime.Select.enabled)
                    {
                      if (dr[Login_VIEW.Time_When_UserSetsItsOwnPassword_FirstTime.name] != null)
                      {
                        if (dr[Login_VIEW.Time_When_UserSetsItsOwnPassword_FirstTime.name].GetType() != typeof(System.DBNull))
                        {
                        o_Time_When_UserSetsItsOwnPassword_FirstTime.obj  =  dr[Login_VIEW.Time_When_UserSetsItsOwnPassword_FirstTime.name];
                        }
                      }
                    }
                    if (o_Time_When_UserSetsItsOwnPassword_LastTime.Select.enabled)
                    {
                      if (dr[Login_VIEW.Time_When_UserSetsItsOwnPassword_LastTime.name] != null)
                      {
                        if (dr[Login_VIEW.Time_When_UserSetsItsOwnPassword_LastTime.name].GetType() != typeof(System.DBNull))
                        {
                        o_Time_When_UserSetsItsOwnPassword_LastTime.obj  =  dr[Login_VIEW.Time_When_UserSetsItsOwnPassword_LastTime.name];
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
                    if (o_Role_Name.Select.enabled)
                    {
                      if (dr[Login_VIEW.Role_Name.name] != null)
                      {
                        if (dr[Login_VIEW.Role_Name.name].GetType() != typeof(System.DBNull))
                        {
                        o_Role_Name.obj  =  dr[Login_VIEW.Role_Name.name];
                        }
                      }
                    }
                    if (o_Role_PrivilegesLevel.Select.enabled)
                    {
                      if (dr[Login_VIEW.Role_PrivilegesLevel.name] != null)
                      {
                        if (dr[Login_VIEW.Role_PrivilegesLevel.name].GetType() != typeof(System.DBNull))
                        {
                        o_Role_PrivilegesLevel.obj  =  dr[Login_VIEW.Role_PrivilegesLevel.name];
                        }
                      }
                    }
                    if (o_Role_description.Select.enabled)
                    {
                      if (dr[Login_VIEW.Role_description.name] != null)
                      {
                        if (dr[Login_VIEW.Role_description.name].GetType() != typeof(System.DBNull))
                        {
                        o_Role_description.obj  =  dr[Login_VIEW.Role_description.name];
                        }
                      }
                    }
           }

    }

    public class LoginManagerJournal_VIEW:XView
    {
        public const string tablename_const = "LoginManagerJournal_VIEW";
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
        
        public class Time:ValSet
           { 
             public const string name = "Time";
             public DateTime Time_
             {
                get {return (DateTime) obj;}
                set {obj = value;}
             }
           }
           public Time o_Time = new Time();

        public class LoginManagerEvent_id:ValSet
           { 
             public const string name = "LoginManagerEvent_id";
             public int LoginManagerEvent_id_
             {
                get {return (int) obj;}
                set {obj = value;}
             }
           }
           public LoginManagerEvent_id o_LoginManagerEvent_id = new LoginManagerEvent_id();

        public class LoginManagerEvent_Message:ValSet
           { 
             public const string name = "LoginManagerEvent_Message";
             public string LoginManagerEvent_Message_
             {
                get {return (string) obj;}
                set {obj = value;}
             }
           }
           public LoginManagerEvent_Message o_LoginManagerEvent_Message = new LoginManagerEvent_Message();

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

        public LoginManagerJournal_VIEW(DBConnectionControl40.DBConnection xcon)
           {
                select = new selection(this);
                where  = new WHERE(this);
                m_con = xcon;
                tablename = LoginManagerJournal_VIEW.tablename_const;
                myUpdateObjects = UpdateObjects;


                    o_Time.col_name = LoginManagerJournal_VIEW.Time.name;
                    o_Time.col_type.m_Type = "datetime";
                    Add(o_Time);
                    
                    o_LoginManagerEvent_id.col_name = LoginManagerJournal_VIEW.LoginManagerEvent_id.name;
                    o_LoginManagerEvent_id.col_type.m_Type = "int";
                    Add(o_LoginManagerEvent_id);
                    
                    o_LoginManagerEvent_Message.col_name = LoginManagerJournal_VIEW.LoginManagerEvent_Message.name;
                    o_LoginManagerEvent_Message.col_type.m_Type = "nvarchar";
                    Add(o_LoginManagerEvent_Message);
                    
                    o_LoginUsers_id.col_name = LoginManagerJournal_VIEW.LoginUsers_id.name;
                    o_LoginUsers_id.col_type.m_Type = "int";
                    Add(o_LoginUsers_id);
                    
                    o_username.col_name = LoginManagerJournal_VIEW.username.name;
                    o_username.col_type.m_Type = "nvarchar";
                    Add(o_username);
                    
           }

        public class selection
           {
                private LoginManagerJournal_VIEW m_LoginManagerJournal_VIEW;
                public selection(LoginManagerJournal_VIEW xLoginManagerJournal_VIEW)
                {
                    m_LoginManagerJournal_VIEW =  xLoginManagerJournal_VIEW;
                }

                    public bool Time
                    {
                        get {return m_LoginManagerJournal_VIEW.o_Time.Select.enabled;}
                        set {m_LoginManagerJournal_VIEW.o_Time.Select.enabled = value;}
                    }
                    
                    public void Time_Expression(string Expression,string xalternate_column_name)
                    {
                        m_LoginManagerJournal_VIEW.o_Time.Select.expression = Expression;
                        m_LoginManagerJournal_VIEW.o_Time.Select.alternate_column_name = xalternate_column_name;
                    }
                    
                    public bool LoginManagerEvent_id
                    {
                        get {return m_LoginManagerJournal_VIEW.o_LoginManagerEvent_id.Select.enabled;}
                        set {m_LoginManagerJournal_VIEW.o_LoginManagerEvent_id.Select.enabled = value;}
                    }
                    
                    public void LoginManagerEvent_id_Expression(string Expression,string xalternate_column_name)
                    {
                        m_LoginManagerJournal_VIEW.o_LoginManagerEvent_id.Select.expression = Expression;
                        m_LoginManagerJournal_VIEW.o_LoginManagerEvent_id.Select.alternate_column_name = xalternate_column_name;
                    }
                    
                    public bool LoginManagerEvent_Message
                    {
                        get {return m_LoginManagerJournal_VIEW.o_LoginManagerEvent_Message.Select.enabled;}
                        set {m_LoginManagerJournal_VIEW.o_LoginManagerEvent_Message.Select.enabled = value;}
                    }
                    
                    public void LoginManagerEvent_Message_Expression(string Expression,string xalternate_column_name)
                    {
                        m_LoginManagerJournal_VIEW.o_LoginManagerEvent_Message.Select.expression = Expression;
                        m_LoginManagerJournal_VIEW.o_LoginManagerEvent_Message.Select.alternate_column_name = xalternate_column_name;
                    }
                    
                    public bool LoginUsers_id
                    {
                        get {return m_LoginManagerJournal_VIEW.o_LoginUsers_id.Select.enabled;}
                        set {m_LoginManagerJournal_VIEW.o_LoginUsers_id.Select.enabled = value;}
                    }
                    
                    public void LoginUsers_id_Expression(string Expression,string xalternate_column_name)
                    {
                        m_LoginManagerJournal_VIEW.o_LoginUsers_id.Select.expression = Expression;
                        m_LoginManagerJournal_VIEW.o_LoginUsers_id.Select.alternate_column_name = xalternate_column_name;
                    }
                    
                    public bool username
                    {
                        get {return m_LoginManagerJournal_VIEW.o_username.Select.enabled;}
                        set {m_LoginManagerJournal_VIEW.o_username.Select.enabled = value;}
                    }
                    
                    public void username_Expression(string Expression,string xalternate_column_name)
                    {
                        m_LoginManagerJournal_VIEW.o_username.Select.expression = Expression;
                        m_LoginManagerJournal_VIEW.o_username.Select.alternate_column_name = xalternate_column_name;
                    }
                    
               public void all(bool bVal)
               {

                    this.Time = bVal;
                    
                    this.LoginManagerEvent_id = bVal;
                    
                    this.LoginManagerEvent_Message = bVal;
                    
                    this.LoginUsers_id = bVal;
                    
                    this.username = bVal;
                    
               }
    
           }

        public class WHERE
           {
                private LoginManagerJournal_VIEW m_LoginManagerJournal_VIEW;
                public WHERE(LoginManagerJournal_VIEW xLoginManagerJournal_VIEW)
                {
                    m_LoginManagerJournal_VIEW =  xLoginManagerJournal_VIEW;
                }

                    public bool Time
                    {
                        get {return m_LoginManagerJournal_VIEW.o_Time.Where.enabled;}
                        set {m_LoginManagerJournal_VIEW.o_Time.Where.enabled = value;}
                    }
                    
                    public void Time_Expression(string Expression)
                    {
                        m_LoginManagerJournal_VIEW.o_Time.Where.expression = Expression;
                    }
                    

                    public void Time_AddParameter(DBConnectionControl40.SQL_Parameter par)
                    {
                        m_LoginManagerJournal_VIEW.o_Time.Where.AddParameter(par);
                    }
                    
                    public bool LoginManagerEvent_id
                    {
                        get {return m_LoginManagerJournal_VIEW.o_LoginManagerEvent_id.Where.enabled;}
                        set {m_LoginManagerJournal_VIEW.o_LoginManagerEvent_id.Where.enabled = value;}
                    }
                    
                    public void LoginManagerEvent_id_Expression(string Expression)
                    {
                        m_LoginManagerJournal_VIEW.o_LoginManagerEvent_id.Where.expression = Expression;
                    }
                    

                    public void LoginManagerEvent_id_AddParameter(DBConnectionControl40.SQL_Parameter par)
                    {
                        m_LoginManagerJournal_VIEW.o_LoginManagerEvent_id.Where.AddParameter(par);
                    }
                    
                    public bool LoginManagerEvent_Message
                    {
                        get {return m_LoginManagerJournal_VIEW.o_LoginManagerEvent_Message.Where.enabled;}
                        set {m_LoginManagerJournal_VIEW.o_LoginManagerEvent_Message.Where.enabled = value;}
                    }
                    
                    public void LoginManagerEvent_Message_Expression(string Expression)
                    {
                        m_LoginManagerJournal_VIEW.o_LoginManagerEvent_Message.Where.expression = Expression;
                    }
                    

                    public void LoginManagerEvent_Message_AddParameter(DBConnectionControl40.SQL_Parameter par)
                    {
                        m_LoginManagerJournal_VIEW.o_LoginManagerEvent_Message.Where.AddParameter(par);
                    }
                    
                    public bool LoginUsers_id
                    {
                        get {return m_LoginManagerJournal_VIEW.o_LoginUsers_id.Where.enabled;}
                        set {m_LoginManagerJournal_VIEW.o_LoginUsers_id.Where.enabled = value;}
                    }
                    
                    public void LoginUsers_id_Expression(string Expression)
                    {
                        m_LoginManagerJournal_VIEW.o_LoginUsers_id.Where.expression = Expression;
                    }
                    

                    public void LoginUsers_id_AddParameter(DBConnectionControl40.SQL_Parameter par)
                    {
                        m_LoginManagerJournal_VIEW.o_LoginUsers_id.Where.AddParameter(par);
                    }
                    
                    public bool username
                    {
                        get {return m_LoginManagerJournal_VIEW.o_username.Where.enabled;}
                        set {m_LoginManagerJournal_VIEW.o_username.Where.enabled = value;}
                    }
                    
                    public void username_Expression(string Expression)
                    {
                        m_LoginManagerJournal_VIEW.o_username.Where.expression = Expression;
                    }
                    

                    public void username_AddParameter(DBConnectionControl40.SQL_Parameter par)
                    {
                        m_LoginManagerJournal_VIEW.o_username.Where.AddParameter(par);
                    }
                    
               public void all(bool bVal)
               {

                    this.Time = bVal;
                    
                    this.LoginManagerEvent_id = bVal;
                    
                    this.LoginManagerEvent_Message = bVal;
                    
                    this.LoginUsers_id = bVal;
                    
                    this.username = bVal;
                    
               }
    
           }

        public void UpdateObjects(DataRow dr)
           {

                    if (o_Time.Select.enabled)
                    {
                      if (dr[LoginManagerJournal_VIEW.Time.name] != null)
                      {
                        if (dr[LoginManagerJournal_VIEW.Time.name].GetType() != typeof(System.DBNull))
                        {
                        o_Time.obj  =  dr[LoginManagerJournal_VIEW.Time.name];
                        }
                      }
                    }
                    if (o_LoginManagerEvent_id.Select.enabled)
                    {
                      if (dr[LoginManagerJournal_VIEW.LoginManagerEvent_id.name] != null)
                      {
                        if (dr[LoginManagerJournal_VIEW.LoginManagerEvent_id.name].GetType() != typeof(System.DBNull))
                        {
                        o_LoginManagerEvent_id.obj  =  dr[LoginManagerJournal_VIEW.LoginManagerEvent_id.name];
                        }
                      }
                    }
                    if (o_LoginManagerEvent_Message.Select.enabled)
                    {
                      if (dr[LoginManagerJournal_VIEW.LoginManagerEvent_Message.name] != null)
                      {
                        if (dr[LoginManagerJournal_VIEW.LoginManagerEvent_Message.name].GetType() != typeof(System.DBNull))
                        {
                        o_LoginManagerEvent_Message.obj  =  dr[LoginManagerJournal_VIEW.LoginManagerEvent_Message.name];
                        }
                      }
                    }
                    if (o_LoginUsers_id.Select.enabled)
                    {
                      if (dr[LoginManagerJournal_VIEW.LoginUsers_id.name] != null)
                      {
                        if (dr[LoginManagerJournal_VIEW.LoginUsers_id.name].GetType() != typeof(System.DBNull))
                        {
                        o_LoginUsers_id.obj  =  dr[LoginManagerJournal_VIEW.LoginUsers_id.name];
                        }
                      }
                    }
                    if (o_username.Select.enabled)
                    {
                      if (dr[LoginManagerJournal_VIEW.username.name] != null)
                      {
                        if (dr[LoginManagerJournal_VIEW.username.name].GetType() != typeof(System.DBNull))
                        {
                        o_username.obj  =  dr[LoginManagerJournal_VIEW.username.name];
                        }
                      }
                    }
           }

    }

    public class LoginSession_VIEW:XView
    {
        public const string tablename_const = "LoginSession_VIEW";
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
        
        public class LoginSession_id:ValSet
           { 
             public const string name = "LoginSession_id";
             public int LoginSession_id_
             {
                get {return (int) obj;}
                set {obj = value;}
             }
           }
           public LoginSession_id o_LoginSession_id = new LoginSession_id();

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

        public class Login_time:ValSet
           { 
             public const string name = "Login_time";
             public DateTime Login_time_
             {
                get {return (DateTime) obj;}
                set {obj = value;}
             }
           }
           public Login_time o_Login_time = new Login_time();

        public class Logout_time:ValSet
           { 
             public const string name = "Logout_time";
             public DateTime Logout_time_
             {
                get {return (DateTime) obj;}
                set {obj = value;}
             }
           }
           public Logout_time o_Logout_time = new Logout_time();

        public class LoginComputer_id:ValSet
           { 
             public const string name = "LoginComputer_id";
             public int LoginComputer_id_
             {
                get {return (int) obj;}
                set {obj = value;}
             }
           }
           public LoginComputer_id o_LoginComputer_id = new LoginComputer_id();

        public class ComputerName:ValSet
           { 
             public const string name = "ComputerName";
             public string ComputerName_
             {
                get {return (string) obj;}
                set {obj = value;}
             }
           }
           public ComputerName o_ComputerName = new ComputerName();

        public class LoginComputerUser_id:ValSet
           { 
             public const string name = "LoginComputerUser_id";
             public int LoginComputerUser_id_
             {
                get {return (int) obj;}
                set {obj = value;}
             }
           }
           public LoginComputerUser_id o_LoginComputerUser_id = new LoginComputerUser_id();

        public class ComputerUserName:ValSet
           { 
             public const string name = "ComputerUserName";
             public string ComputerUserName_
             {
                get {return (string) obj;}
                set {obj = value;}
             }
           }
           public ComputerUserName o_ComputerUserName = new ComputerUserName();

        public LoginSession_VIEW(DBConnectionControl40.DBConnection xcon)
           {
                select = new selection(this);
                where  = new WHERE(this);
                m_con = xcon;
                tablename = LoginSession_VIEW.tablename_const;
                myUpdateObjects = UpdateObjects;


                    o_LoginSession_id.col_name = LoginSession_VIEW.LoginSession_id.name;
                    o_LoginSession_id.col_type.m_Type = "int";
                    Add(o_LoginSession_id);
                    
                    o_LoginUsers_id.col_name = LoginSession_VIEW.LoginUsers_id.name;
                    o_LoginUsers_id.col_type.m_Type = "int";
                    Add(o_LoginUsers_id);
                    
                    o_username.col_name = LoginSession_VIEW.username.name;
                    o_username.col_type.m_Type = "nvarchar";
                    Add(o_username);
                    
                    o_first_name.col_name = LoginSession_VIEW.first_name.name;
                    o_first_name.col_type.m_Type = "nvarchar";
                    Add(o_first_name);
                    
                    o_last_name.col_name = LoginSession_VIEW.last_name.name;
                    o_last_name.col_type.m_Type = "nvarchar";
                    Add(o_last_name);
                    
                    o_Identity.col_name = LoginSession_VIEW.Identity.name;
                    o_Identity.col_type.m_Type = "nvarchar";
                    Add(o_Identity);
                    
                    o_Contact.col_name = LoginSession_VIEW.Contact.name;
                    o_Contact.col_type.m_Type = "nvarchar";
                    Add(o_Contact);
                    
                    o_Login_time.col_name = LoginSession_VIEW.Login_time.name;
                    o_Login_time.col_type.m_Type = "datetime";
                    Add(o_Login_time);
                    
                    o_Logout_time.col_name = LoginSession_VIEW.Logout_time.name;
                    o_Logout_time.col_type.m_Type = "datetime";
                    Add(o_Logout_time);
                    
                    o_LoginComputer_id.col_name = LoginSession_VIEW.LoginComputer_id.name;
                    o_LoginComputer_id.col_type.m_Type = "int";
                    Add(o_LoginComputer_id);
                    
                    o_ComputerName.col_name = LoginSession_VIEW.ComputerName.name;
                    o_ComputerName.col_type.m_Type = "nvarchar";
                    Add(o_ComputerName);
                    
                    o_LoginComputerUser_id.col_name = LoginSession_VIEW.LoginComputerUser_id.name;
                    o_LoginComputerUser_id.col_type.m_Type = "int";
                    Add(o_LoginComputerUser_id);
                    
                    o_ComputerUserName.col_name = LoginSession_VIEW.ComputerUserName.name;
                    o_ComputerUserName.col_type.m_Type = "nvarchar";
                    Add(o_ComputerUserName);
                    
           }

        public class selection
           {
                private LoginSession_VIEW m_LoginSession_VIEW;
                public selection(LoginSession_VIEW xLoginSession_VIEW)
                {
                    m_LoginSession_VIEW =  xLoginSession_VIEW;
                }

                    public bool LoginSession_id
                    {
                        get {return m_LoginSession_VIEW.o_LoginSession_id.Select.enabled;}
                        set {m_LoginSession_VIEW.o_LoginSession_id.Select.enabled = value;}
                    }
                    
                    public void LoginSession_id_Expression(string Expression,string xalternate_column_name)
                    {
                        m_LoginSession_VIEW.o_LoginSession_id.Select.expression = Expression;
                        m_LoginSession_VIEW.o_LoginSession_id.Select.alternate_column_name = xalternate_column_name;
                    }
                    
                    public bool LoginUsers_id
                    {
                        get {return m_LoginSession_VIEW.o_LoginUsers_id.Select.enabled;}
                        set {m_LoginSession_VIEW.o_LoginUsers_id.Select.enabled = value;}
                    }
                    
                    public void LoginUsers_id_Expression(string Expression,string xalternate_column_name)
                    {
                        m_LoginSession_VIEW.o_LoginUsers_id.Select.expression = Expression;
                        m_LoginSession_VIEW.o_LoginUsers_id.Select.alternate_column_name = xalternate_column_name;
                    }
                    
                    public bool username
                    {
                        get {return m_LoginSession_VIEW.o_username.Select.enabled;}
                        set {m_LoginSession_VIEW.o_username.Select.enabled = value;}
                    }
                    
                    public void username_Expression(string Expression,string xalternate_column_name)
                    {
                        m_LoginSession_VIEW.o_username.Select.expression = Expression;
                        m_LoginSession_VIEW.o_username.Select.alternate_column_name = xalternate_column_name;
                    }
                    
                    public bool first_name
                    {
                        get {return m_LoginSession_VIEW.o_first_name.Select.enabled;}
                        set {m_LoginSession_VIEW.o_first_name.Select.enabled = value;}
                    }
                    
                    public void first_name_Expression(string Expression,string xalternate_column_name)
                    {
                        m_LoginSession_VIEW.o_first_name.Select.expression = Expression;
                        m_LoginSession_VIEW.o_first_name.Select.alternate_column_name = xalternate_column_name;
                    }
                    
                    public bool last_name
                    {
                        get {return m_LoginSession_VIEW.o_last_name.Select.enabled;}
                        set {m_LoginSession_VIEW.o_last_name.Select.enabled = value;}
                    }
                    
                    public void last_name_Expression(string Expression,string xalternate_column_name)
                    {
                        m_LoginSession_VIEW.o_last_name.Select.expression = Expression;
                        m_LoginSession_VIEW.o_last_name.Select.alternate_column_name = xalternate_column_name;
                    }
                    
                    public bool Identity
                    {
                        get {return m_LoginSession_VIEW.o_Identity.Select.enabled;}
                        set {m_LoginSession_VIEW.o_Identity.Select.enabled = value;}
                    }
                    
                    public void Identity_Expression(string Expression,string xalternate_column_name)
                    {
                        m_LoginSession_VIEW.o_Identity.Select.expression = Expression;
                        m_LoginSession_VIEW.o_Identity.Select.alternate_column_name = xalternate_column_name;
                    }
                    
                    public bool Contact
                    {
                        get {return m_LoginSession_VIEW.o_Contact.Select.enabled;}
                        set {m_LoginSession_VIEW.o_Contact.Select.enabled = value;}
                    }
                    
                    public void Contact_Expression(string Expression,string xalternate_column_name)
                    {
                        m_LoginSession_VIEW.o_Contact.Select.expression = Expression;
                        m_LoginSession_VIEW.o_Contact.Select.alternate_column_name = xalternate_column_name;
                    }
                    
                    public bool Login_time
                    {
                        get {return m_LoginSession_VIEW.o_Login_time.Select.enabled;}
                        set {m_LoginSession_VIEW.o_Login_time.Select.enabled = value;}
                    }
                    
                    public void Login_time_Expression(string Expression,string xalternate_column_name)
                    {
                        m_LoginSession_VIEW.o_Login_time.Select.expression = Expression;
                        m_LoginSession_VIEW.o_Login_time.Select.alternate_column_name = xalternate_column_name;
                    }
                    
                    public bool Logout_time
                    {
                        get {return m_LoginSession_VIEW.o_Logout_time.Select.enabled;}
                        set {m_LoginSession_VIEW.o_Logout_time.Select.enabled = value;}
                    }
                    
                    public void Logout_time_Expression(string Expression,string xalternate_column_name)
                    {
                        m_LoginSession_VIEW.o_Logout_time.Select.expression = Expression;
                        m_LoginSession_VIEW.o_Logout_time.Select.alternate_column_name = xalternate_column_name;
                    }
                    
                    public bool LoginComputer_id
                    {
                        get {return m_LoginSession_VIEW.o_LoginComputer_id.Select.enabled;}
                        set {m_LoginSession_VIEW.o_LoginComputer_id.Select.enabled = value;}
                    }
                    
                    public void LoginComputer_id_Expression(string Expression,string xalternate_column_name)
                    {
                        m_LoginSession_VIEW.o_LoginComputer_id.Select.expression = Expression;
                        m_LoginSession_VIEW.o_LoginComputer_id.Select.alternate_column_name = xalternate_column_name;
                    }
                    
                    public bool ComputerName
                    {
                        get {return m_LoginSession_VIEW.o_ComputerName.Select.enabled;}
                        set {m_LoginSession_VIEW.o_ComputerName.Select.enabled = value;}
                    }
                    
                    public void ComputerName_Expression(string Expression,string xalternate_column_name)
                    {
                        m_LoginSession_VIEW.o_ComputerName.Select.expression = Expression;
                        m_LoginSession_VIEW.o_ComputerName.Select.alternate_column_name = xalternate_column_name;
                    }
                    
                    public bool LoginComputerUser_id
                    {
                        get {return m_LoginSession_VIEW.o_LoginComputerUser_id.Select.enabled;}
                        set {m_LoginSession_VIEW.o_LoginComputerUser_id.Select.enabled = value;}
                    }
                    
                    public void LoginComputerUser_id_Expression(string Expression,string xalternate_column_name)
                    {
                        m_LoginSession_VIEW.o_LoginComputerUser_id.Select.expression = Expression;
                        m_LoginSession_VIEW.o_LoginComputerUser_id.Select.alternate_column_name = xalternate_column_name;
                    }
                    
                    public bool ComputerUserName
                    {
                        get {return m_LoginSession_VIEW.o_ComputerUserName.Select.enabled;}
                        set {m_LoginSession_VIEW.o_ComputerUserName.Select.enabled = value;}
                    }
                    
                    public void ComputerUserName_Expression(string Expression,string xalternate_column_name)
                    {
                        m_LoginSession_VIEW.o_ComputerUserName.Select.expression = Expression;
                        m_LoginSession_VIEW.o_ComputerUserName.Select.alternate_column_name = xalternate_column_name;
                    }
                    
               public void all(bool bVal)
               {

                    this.LoginSession_id = bVal;
                    
                    this.LoginUsers_id = bVal;
                    
                    this.username = bVal;
                    
                    this.first_name = bVal;
                    
                    this.last_name = bVal;
                    
                    this.Identity = bVal;
                    
                    this.Contact = bVal;
                    
                    this.Login_time = bVal;
                    
                    this.Logout_time = bVal;
                    
                    this.LoginComputer_id = bVal;
                    
                    this.ComputerName = bVal;
                    
                    this.LoginComputerUser_id = bVal;
                    
                    this.ComputerUserName = bVal;
                    
               }
    
           }

        public class WHERE
           {
                private LoginSession_VIEW m_LoginSession_VIEW;
                public WHERE(LoginSession_VIEW xLoginSession_VIEW)
                {
                    m_LoginSession_VIEW =  xLoginSession_VIEW;
                }

                    public bool LoginSession_id
                    {
                        get {return m_LoginSession_VIEW.o_LoginSession_id.Where.enabled;}
                        set {m_LoginSession_VIEW.o_LoginSession_id.Where.enabled = value;}
                    }
                    
                    public void LoginSession_id_Expression(string Expression)
                    {
                        m_LoginSession_VIEW.o_LoginSession_id.Where.expression = Expression;
                    }
                    

                    public void LoginSession_id_AddParameter(DBConnectionControl40.SQL_Parameter par)
                    {
                        m_LoginSession_VIEW.o_LoginSession_id.Where.AddParameter(par);
                    }
                    
                    public bool LoginUsers_id
                    {
                        get {return m_LoginSession_VIEW.o_LoginUsers_id.Where.enabled;}
                        set {m_LoginSession_VIEW.o_LoginUsers_id.Where.enabled = value;}
                    }
                    
                    public void LoginUsers_id_Expression(string Expression)
                    {
                        m_LoginSession_VIEW.o_LoginUsers_id.Where.expression = Expression;
                    }
                    

                    public void LoginUsers_id_AddParameter(DBConnectionControl40.SQL_Parameter par)
                    {
                        m_LoginSession_VIEW.o_LoginUsers_id.Where.AddParameter(par);
                    }
                    
                    public bool username
                    {
                        get {return m_LoginSession_VIEW.o_username.Where.enabled;}
                        set {m_LoginSession_VIEW.o_username.Where.enabled = value;}
                    }
                    
                    public void username_Expression(string Expression)
                    {
                        m_LoginSession_VIEW.o_username.Where.expression = Expression;
                    }
                    

                    public void username_AddParameter(DBConnectionControl40.SQL_Parameter par)
                    {
                        m_LoginSession_VIEW.o_username.Where.AddParameter(par);
                    }
                    
                    public bool first_name
                    {
                        get {return m_LoginSession_VIEW.o_first_name.Where.enabled;}
                        set {m_LoginSession_VIEW.o_first_name.Where.enabled = value;}
                    }
                    
                    public void first_name_Expression(string Expression)
                    {
                        m_LoginSession_VIEW.o_first_name.Where.expression = Expression;
                    }
                    

                    public void first_name_AddParameter(DBConnectionControl40.SQL_Parameter par)
                    {
                        m_LoginSession_VIEW.o_first_name.Where.AddParameter(par);
                    }
                    
                    public bool last_name
                    {
                        get {return m_LoginSession_VIEW.o_last_name.Where.enabled;}
                        set {m_LoginSession_VIEW.o_last_name.Where.enabled = value;}
                    }
                    
                    public void last_name_Expression(string Expression)
                    {
                        m_LoginSession_VIEW.o_last_name.Where.expression = Expression;
                    }
                    

                    public void last_name_AddParameter(DBConnectionControl40.SQL_Parameter par)
                    {
                        m_LoginSession_VIEW.o_last_name.Where.AddParameter(par);
                    }
                    
                    public bool Identity
                    {
                        get {return m_LoginSession_VIEW.o_Identity.Where.enabled;}
                        set {m_LoginSession_VIEW.o_Identity.Where.enabled = value;}
                    }
                    
                    public void Identity_Expression(string Expression)
                    {
                        m_LoginSession_VIEW.o_Identity.Where.expression = Expression;
                    }
                    

                    public void Identity_AddParameter(DBConnectionControl40.SQL_Parameter par)
                    {
                        m_LoginSession_VIEW.o_Identity.Where.AddParameter(par);
                    }
                    
                    public bool Contact
                    {
                        get {return m_LoginSession_VIEW.o_Contact.Where.enabled;}
                        set {m_LoginSession_VIEW.o_Contact.Where.enabled = value;}
                    }
                    
                    public void Contact_Expression(string Expression)
                    {
                        m_LoginSession_VIEW.o_Contact.Where.expression = Expression;
                    }
                    

                    public void Contact_AddParameter(DBConnectionControl40.SQL_Parameter par)
                    {
                        m_LoginSession_VIEW.o_Contact.Where.AddParameter(par);
                    }
                    
                    public bool Login_time
                    {
                        get {return m_LoginSession_VIEW.o_Login_time.Where.enabled;}
                        set {m_LoginSession_VIEW.o_Login_time.Where.enabled = value;}
                    }
                    
                    public void Login_time_Expression(string Expression)
                    {
                        m_LoginSession_VIEW.o_Login_time.Where.expression = Expression;
                    }
                    

                    public void Login_time_AddParameter(DBConnectionControl40.SQL_Parameter par)
                    {
                        m_LoginSession_VIEW.o_Login_time.Where.AddParameter(par);
                    }
                    
                    public bool Logout_time
                    {
                        get {return m_LoginSession_VIEW.o_Logout_time.Where.enabled;}
                        set {m_LoginSession_VIEW.o_Logout_time.Where.enabled = value;}
                    }
                    
                    public void Logout_time_Expression(string Expression)
                    {
                        m_LoginSession_VIEW.o_Logout_time.Where.expression = Expression;
                    }
                    

                    public void Logout_time_AddParameter(DBConnectionControl40.SQL_Parameter par)
                    {
                        m_LoginSession_VIEW.o_Logout_time.Where.AddParameter(par);
                    }
                    
                    public bool LoginComputer_id
                    {
                        get {return m_LoginSession_VIEW.o_LoginComputer_id.Where.enabled;}
                        set {m_LoginSession_VIEW.o_LoginComputer_id.Where.enabled = value;}
                    }
                    
                    public void LoginComputer_id_Expression(string Expression)
                    {
                        m_LoginSession_VIEW.o_LoginComputer_id.Where.expression = Expression;
                    }
                    

                    public void LoginComputer_id_AddParameter(DBConnectionControl40.SQL_Parameter par)
                    {
                        m_LoginSession_VIEW.o_LoginComputer_id.Where.AddParameter(par);
                    }
                    
                    public bool ComputerName
                    {
                        get {return m_LoginSession_VIEW.o_ComputerName.Where.enabled;}
                        set {m_LoginSession_VIEW.o_ComputerName.Where.enabled = value;}
                    }
                    
                    public void ComputerName_Expression(string Expression)
                    {
                        m_LoginSession_VIEW.o_ComputerName.Where.expression = Expression;
                    }
                    

                    public void ComputerName_AddParameter(DBConnectionControl40.SQL_Parameter par)
                    {
                        m_LoginSession_VIEW.o_ComputerName.Where.AddParameter(par);
                    }
                    
                    public bool LoginComputerUser_id
                    {
                        get {return m_LoginSession_VIEW.o_LoginComputerUser_id.Where.enabled;}
                        set {m_LoginSession_VIEW.o_LoginComputerUser_id.Where.enabled = value;}
                    }
                    
                    public void LoginComputerUser_id_Expression(string Expression)
                    {
                        m_LoginSession_VIEW.o_LoginComputerUser_id.Where.expression = Expression;
                    }
                    

                    public void LoginComputerUser_id_AddParameter(DBConnectionControl40.SQL_Parameter par)
                    {
                        m_LoginSession_VIEW.o_LoginComputerUser_id.Where.AddParameter(par);
                    }
                    
                    public bool ComputerUserName
                    {
                        get {return m_LoginSession_VIEW.o_ComputerUserName.Where.enabled;}
                        set {m_LoginSession_VIEW.o_ComputerUserName.Where.enabled = value;}
                    }
                    
                    public void ComputerUserName_Expression(string Expression)
                    {
                        m_LoginSession_VIEW.o_ComputerUserName.Where.expression = Expression;
                    }
                    

                    public void ComputerUserName_AddParameter(DBConnectionControl40.SQL_Parameter par)
                    {
                        m_LoginSession_VIEW.o_ComputerUserName.Where.AddParameter(par);
                    }
                    
               public void all(bool bVal)
               {

                    this.LoginSession_id = bVal;
                    
                    this.LoginUsers_id = bVal;
                    
                    this.username = bVal;
                    
                    this.first_name = bVal;
                    
                    this.last_name = bVal;
                    
                    this.Identity = bVal;
                    
                    this.Contact = bVal;
                    
                    this.Login_time = bVal;
                    
                    this.Logout_time = bVal;
                    
                    this.LoginComputer_id = bVal;
                    
                    this.ComputerName = bVal;
                    
                    this.LoginComputerUser_id = bVal;
                    
                    this.ComputerUserName = bVal;
                    
               }
    
           }

        public void UpdateObjects(DataRow dr)
           {

                    if (o_LoginSession_id.Select.enabled)
                    {
                      if (dr[LoginSession_VIEW.LoginSession_id.name] != null)
                      {
                        if (dr[LoginSession_VIEW.LoginSession_id.name].GetType() != typeof(System.DBNull))
                        {
                        o_LoginSession_id.obj  =  dr[LoginSession_VIEW.LoginSession_id.name];
                        }
                      }
                    }
                    if (o_LoginUsers_id.Select.enabled)
                    {
                      if (dr[LoginSession_VIEW.LoginUsers_id.name] != null)
                      {
                        if (dr[LoginSession_VIEW.LoginUsers_id.name].GetType() != typeof(System.DBNull))
                        {
                        o_LoginUsers_id.obj  =  dr[LoginSession_VIEW.LoginUsers_id.name];
                        }
                      }
                    }
                    if (o_username.Select.enabled)
                    {
                      if (dr[LoginSession_VIEW.username.name] != null)
                      {
                        if (dr[LoginSession_VIEW.username.name].GetType() != typeof(System.DBNull))
                        {
                        o_username.obj  =  dr[LoginSession_VIEW.username.name];
                        }
                      }
                    }
                    if (o_first_name.Select.enabled)
                    {
                      if (dr[LoginSession_VIEW.first_name.name] != null)
                      {
                        if (dr[LoginSession_VIEW.first_name.name].GetType() != typeof(System.DBNull))
                        {
                        o_first_name.obj  =  dr[LoginSession_VIEW.first_name.name];
                        }
                      }
                    }
                    if (o_last_name.Select.enabled)
                    {
                      if (dr[LoginSession_VIEW.last_name.name] != null)
                      {
                        if (dr[LoginSession_VIEW.last_name.name].GetType() != typeof(System.DBNull))
                        {
                        o_last_name.obj  =  dr[LoginSession_VIEW.last_name.name];
                        }
                      }
                    }
                    if (o_Identity.Select.enabled)
                    {
                      if (dr[LoginSession_VIEW.Identity.name] != null)
                      {
                        if (dr[LoginSession_VIEW.Identity.name].GetType() != typeof(System.DBNull))
                        {
                        o_Identity.obj  =  dr[LoginSession_VIEW.Identity.name];
                        }
                      }
                    }
                    if (o_Contact.Select.enabled)
                    {
                      if (dr[LoginSession_VIEW.Contact.name] != null)
                      {
                        if (dr[LoginSession_VIEW.Contact.name].GetType() != typeof(System.DBNull))
                        {
                        o_Contact.obj  =  dr[LoginSession_VIEW.Contact.name];
                        }
                      }
                    }
                    if (o_Login_time.Select.enabled)
                    {
                      if (dr[LoginSession_VIEW.Login_time.name] != null)
                      {
                        if (dr[LoginSession_VIEW.Login_time.name].GetType() != typeof(System.DBNull))
                        {
                        o_Login_time.obj  =  dr[LoginSession_VIEW.Login_time.name];
                        }
                      }
                    }
                    if (o_Logout_time.Select.enabled)
                    {
                      if (dr[LoginSession_VIEW.Logout_time.name] != null)
                      {
                        if (dr[LoginSession_VIEW.Logout_time.name].GetType() != typeof(System.DBNull))
                        {
                        o_Logout_time.obj  =  dr[LoginSession_VIEW.Logout_time.name];
                        }
                      }
                    }
                    if (o_LoginComputer_id.Select.enabled)
                    {
                      if (dr[LoginSession_VIEW.LoginComputer_id.name] != null)
                      {
                        if (dr[LoginSession_VIEW.LoginComputer_id.name].GetType() != typeof(System.DBNull))
                        {
                        o_LoginComputer_id.obj  =  dr[LoginSession_VIEW.LoginComputer_id.name];
                        }
                      }
                    }
                    if (o_ComputerName.Select.enabled)
                    {
                      if (dr[LoginSession_VIEW.ComputerName.name] != null)
                      {
                        if (dr[LoginSession_VIEW.ComputerName.name].GetType() != typeof(System.DBNull))
                        {
                        o_ComputerName.obj  =  dr[LoginSession_VIEW.ComputerName.name];
                        }
                      }
                    }
                    if (o_LoginComputerUser_id.Select.enabled)
                    {
                      if (dr[LoginSession_VIEW.LoginComputerUser_id.name] != null)
                      {
                        if (dr[LoginSession_VIEW.LoginComputerUser_id.name].GetType() != typeof(System.DBNull))
                        {
                        o_LoginComputerUser_id.obj  =  dr[LoginSession_VIEW.LoginComputerUser_id.name];
                        }
                      }
                    }
                    if (o_ComputerUserName.Select.enabled)
                    {
                      if (dr[LoginSession_VIEW.ComputerUserName.name] != null)
                      {
                        if (dr[LoginSession_VIEW.ComputerUserName.name].GetType() != typeof(System.DBNull))
                        {
                        o_ComputerUserName.obj  =  dr[LoginSession_VIEW.ComputerUserName.name];
                        }
                      }
                    }
           }

    }

    public class LoginDB_DataSet_ScalarFunctions:XFunction
    {
            public const string Login_Server_GetDate_const = "Login_Server_GetDate";

            public DateTime Login_Server_GetDate(ref string Err)
            {
              FuncParams.Clear();
              
                    SQL_Parameter Par_Login_Server_GetDate_1 = new SQL_Parameter();
                    Par_Login_Server_GetDate_1.dbType = System.Data.SqlDbType.DateTime;
                    Par_Login_Server_GetDate_1.Name = "@Par_Login_Server_GetDate_1";
                    Par_Login_Server_GetDate_1.size = 8;
                    Par_Login_Server_GetDate_1.IsOutputParameter = true;
                    FuncParams.Add(Par_Login_Server_GetDate_1);
                    
              object Result = exec("Login_Server_GetDate",ref Err);
              return (DateTime)Result;
            }
            
            public const string Login_PasswordExpired_const = "Login_PasswordExpired";

            public bool Login_PasswordExpired(int LoginUsers_id, ref string Err)
            {
              FuncParams.Clear();
              
                    SQL_Parameter Par_Login_PasswordExpired_1 = new SQL_Parameter();
                    Par_Login_PasswordExpired_1.dbType = System.Data.SqlDbType.Bit;
                    Par_Login_PasswordExpired_1.Name = "@Par_Login_PasswordExpired_1";
                    Par_Login_PasswordExpired_1.size = 1;
                    Par_Login_PasswordExpired_1.IsOutputParameter = true;
                    FuncParams.Add(Par_Login_PasswordExpired_1);
                    
                    SQL_Parameter Par_Login_PasswordExpired_2 = new SQL_Parameter();
                    Par_Login_PasswordExpired_2.dbType = System.Data.SqlDbType.Int;
                    Par_Login_PasswordExpired_2.Name = "@Par_Login_PasswordExpired_2";
                    Par_Login_PasswordExpired_2.size = 4;
                    Par_Login_PasswordExpired_2.Value = LoginUsers_id;
                    Par_Login_PasswordExpired_2.IsOutputParameter = false;
                    FuncParams.Add(Par_Login_PasswordExpired_2);
                    
              object Result = exec("Login_PasswordExpired",ref Err);
              return (bool)Result;
            }
            
                public LoginDB_DataSet_ScalarFunctions(DBConnectionControl40.DBConnection xcon)
                {
                        m_con = xcon;
        
                }
            }
        

    public class LoginDB_DataSet_Procedures:XProcedure
    {
                    public const string LoginUsers_Administrator_AddRole_const = "LoginUsers_Administrator_AddRole";

                    public int LoginUsers_Administrator_AddRole(string NewRoleName,int PrivilegesLeveL,string description,int LoginUsers_id_Administrator, ref int LoginRole_id, ref string Res, ref string Err)
                    {
                      
                    ProcParams.Clear();
                    SQL_Parameter Ret_code_CopyRight_Logina_AuthorDamjanStrucl = new SQL_Parameter();
                    Ret_code_CopyRight_Logina_AuthorDamjanStrucl.dbType = System.Data.SqlDbType.Int;
                    Ret_code_CopyRight_Logina_AuthorDamjanStrucl.Name = "@Ret_code_CopyRight_Logina_AuthorDamjanStrucl";
                    Ret_code_CopyRight_Logina_AuthorDamjanStrucl.size = 4;
                    Ret_code_CopyRight_Logina_AuthorDamjanStrucl.IsOutputParameter = true;
                    ProcParams.Add(Ret_code_CopyRight_Logina_AuthorDamjanStrucl);
                    
                    SQL_Parameter Par_LoginUsers_Administrator_AddRole_NewRoleName = new SQL_Parameter();
                    Par_LoginUsers_Administrator_AddRole_NewRoleName.dbType = System.Data.SqlDbType.NVarChar;
                    Par_LoginUsers_Administrator_AddRole_NewRoleName.Name = "@Par_LoginUsers_Administrator_AddRole_NewRoleName";
                    Par_LoginUsers_Administrator_AddRole_NewRoleName.size = 250;
                    Par_LoginUsers_Administrator_AddRole_NewRoleName.Value = NewRoleName;
                    Par_LoginUsers_Administrator_AddRole_NewRoleName.IsOutputParameter = false;
                    ProcParams.Add(Par_LoginUsers_Administrator_AddRole_NewRoleName);
                    
                    SQL_Parameter Par_LoginUsers_Administrator_AddRole_PrivilegesLeveL = new SQL_Parameter();
                    Par_LoginUsers_Administrator_AddRole_PrivilegesLeveL.dbType = System.Data.SqlDbType.Int;
                    Par_LoginUsers_Administrator_AddRole_PrivilegesLeveL.Name = "@Par_LoginUsers_Administrator_AddRole_PrivilegesLeveL";
                    Par_LoginUsers_Administrator_AddRole_PrivilegesLeveL.size = 4;
                    Par_LoginUsers_Administrator_AddRole_PrivilegesLeveL.Value = PrivilegesLeveL;
                    Par_LoginUsers_Administrator_AddRole_PrivilegesLeveL.IsOutputParameter = false;
                    ProcParams.Add(Par_LoginUsers_Administrator_AddRole_PrivilegesLeveL);
                    
                    SQL_Parameter Par_LoginUsers_Administrator_AddRole_description = new SQL_Parameter();
                    Par_LoginUsers_Administrator_AddRole_description.dbType = System.Data.SqlDbType.NVarChar;
                    Par_LoginUsers_Administrator_AddRole_description.Name = "@Par_LoginUsers_Administrator_AddRole_description";
                    Par_LoginUsers_Administrator_AddRole_description.size = 2000;
                    Par_LoginUsers_Administrator_AddRole_description.Value = description;
                    Par_LoginUsers_Administrator_AddRole_description.IsOutputParameter = false;
                    ProcParams.Add(Par_LoginUsers_Administrator_AddRole_description);
                    
                    SQL_Parameter Par_LoginUsers_Administrator_AddRole_LoginUsers_id_Administrator = new SQL_Parameter();
                    Par_LoginUsers_Administrator_AddRole_LoginUsers_id_Administrator.dbType = System.Data.SqlDbType.Int;
                    Par_LoginUsers_Administrator_AddRole_LoginUsers_id_Administrator.Name = "@Par_LoginUsers_Administrator_AddRole_LoginUsers_id_Administrator";
                    Par_LoginUsers_Administrator_AddRole_LoginUsers_id_Administrator.size = 4;
                    Par_LoginUsers_Administrator_AddRole_LoginUsers_id_Administrator.Value = LoginUsers_id_Administrator;
                    Par_LoginUsers_Administrator_AddRole_LoginUsers_id_Administrator.IsOutputParameter = false;
                    ProcParams.Add(Par_LoginUsers_Administrator_AddRole_LoginUsers_id_Administrator);
                    
                    SQL_Parameter Par_LoginUsers_Administrator_AddRole_LoginRole_id = new SQL_Parameter();
                    Par_LoginUsers_Administrator_AddRole_LoginRole_id.dbType = System.Data.SqlDbType.Int;
                    Par_LoginUsers_Administrator_AddRole_LoginRole_id.Name = "@Par_LoginUsers_Administrator_AddRole_LoginRole_id";
                    Par_LoginUsers_Administrator_AddRole_LoginRole_id.size = 4;
                    Par_LoginUsers_Administrator_AddRole_LoginRole_id.IsOutputParameter = true;
                    ProcParams.Add(Par_LoginUsers_Administrator_AddRole_LoginRole_id);
                    
                    SQL_Parameter Par_LoginUsers_Administrator_AddRole_Res = new SQL_Parameter();
                    Par_LoginUsers_Administrator_AddRole_Res.dbType = System.Data.SqlDbType.NVarChar;
                    Par_LoginUsers_Administrator_AddRole_Res.Name = "@Par_LoginUsers_Administrator_AddRole_Res";
                    Par_LoginUsers_Administrator_AddRole_Res.size = 2000;
                    Par_LoginUsers_Administrator_AddRole_Res.IsOutputParameter = true;
                    ProcParams.Add(Par_LoginUsers_Administrator_AddRole_Res);
                    
                      object Result = exec("LoginUsers_Administrator_AddRole",new string[] {"@NewRoleName","@PrivilegesLeveL","@description","@LoginUsers_id_Administrator","@LoginRole_id","@Res"},ref Err);
                      LoginRole_id = (int) ProcParamValue("@Par_LoginUsers_Administrator_AddRole_LoginRole_id");
Res = (string) ProcParamValue("@Par_LoginUsers_Administrator_AddRole_Res");

                      if (Result==null)
                      {
                         return 0;
                      }
                      else if (Result.GetType()==typeof(int))
                      {
                        return (int) Result;
                      }
                      else 
                      {
                        return -1;
                      }
                    }
                
                    public const string LoginUsersAndLoginRoles_Add_const = "LoginUsersAndLoginRoles_Add";

                    public int LoginUsersAndLoginRoles_Add(int LoginUsers_id,int LoginRoles_id,int LoginUsers_id_Administrator, ref int LoginUsersAndLoginRoles_id, ref string Res, ref string Err)
                    {
                      
                    ProcParams.Clear();
                    SQL_Parameter Ret_code_CopyRight_Logina_AuthorDamjanStrucl = new SQL_Parameter();
                    Ret_code_CopyRight_Logina_AuthorDamjanStrucl.dbType = System.Data.SqlDbType.Int;
                    Ret_code_CopyRight_Logina_AuthorDamjanStrucl.Name = "@Ret_code_CopyRight_Logina_AuthorDamjanStrucl";
                    Ret_code_CopyRight_Logina_AuthorDamjanStrucl.size = 4;
                    Ret_code_CopyRight_Logina_AuthorDamjanStrucl.IsOutputParameter = true;
                    ProcParams.Add(Ret_code_CopyRight_Logina_AuthorDamjanStrucl);
                    
                    SQL_Parameter Par_LoginUsersAndLoginRoles_Add_LoginUsers_id = new SQL_Parameter();
                    Par_LoginUsersAndLoginRoles_Add_LoginUsers_id.dbType = System.Data.SqlDbType.Int;
                    Par_LoginUsersAndLoginRoles_Add_LoginUsers_id.Name = "@Par_LoginUsersAndLoginRoles_Add_LoginUsers_id";
                    Par_LoginUsersAndLoginRoles_Add_LoginUsers_id.size = 4;
                    Par_LoginUsersAndLoginRoles_Add_LoginUsers_id.Value = LoginUsers_id;
                    Par_LoginUsersAndLoginRoles_Add_LoginUsers_id.IsOutputParameter = false;
                    ProcParams.Add(Par_LoginUsersAndLoginRoles_Add_LoginUsers_id);
                    
                    SQL_Parameter Par_LoginUsersAndLoginRoles_Add_LoginRoles_id = new SQL_Parameter();
                    Par_LoginUsersAndLoginRoles_Add_LoginRoles_id.dbType = System.Data.SqlDbType.Int;
                    Par_LoginUsersAndLoginRoles_Add_LoginRoles_id.Name = "@Par_LoginUsersAndLoginRoles_Add_LoginRoles_id";
                    Par_LoginUsersAndLoginRoles_Add_LoginRoles_id.size = 4;
                    Par_LoginUsersAndLoginRoles_Add_LoginRoles_id.Value = LoginRoles_id;
                    Par_LoginUsersAndLoginRoles_Add_LoginRoles_id.IsOutputParameter = false;
                    ProcParams.Add(Par_LoginUsersAndLoginRoles_Add_LoginRoles_id);
                    
                    SQL_Parameter Par_LoginUsersAndLoginRoles_Add_LoginUsers_id_Administrator = new SQL_Parameter();
                    Par_LoginUsersAndLoginRoles_Add_LoginUsers_id_Administrator.dbType = System.Data.SqlDbType.Int;
                    Par_LoginUsersAndLoginRoles_Add_LoginUsers_id_Administrator.Name = "@Par_LoginUsersAndLoginRoles_Add_LoginUsers_id_Administrator";
                    Par_LoginUsersAndLoginRoles_Add_LoginUsers_id_Administrator.size = 4;
                    Par_LoginUsersAndLoginRoles_Add_LoginUsers_id_Administrator.Value = LoginUsers_id_Administrator;
                    Par_LoginUsersAndLoginRoles_Add_LoginUsers_id_Administrator.IsOutputParameter = false;
                    ProcParams.Add(Par_LoginUsersAndLoginRoles_Add_LoginUsers_id_Administrator);
                    
                    SQL_Parameter Par_LoginUsersAndLoginRoles_Add_LoginUsersAndLoginRoles_id = new SQL_Parameter();
                    Par_LoginUsersAndLoginRoles_Add_LoginUsersAndLoginRoles_id.dbType = System.Data.SqlDbType.Int;
                    Par_LoginUsersAndLoginRoles_Add_LoginUsersAndLoginRoles_id.Name = "@Par_LoginUsersAndLoginRoles_Add_LoginUsersAndLoginRoles_id";
                    Par_LoginUsersAndLoginRoles_Add_LoginUsersAndLoginRoles_id.size = 4;
                    Par_LoginUsersAndLoginRoles_Add_LoginUsersAndLoginRoles_id.IsOutputParameter = true;
                    ProcParams.Add(Par_LoginUsersAndLoginRoles_Add_LoginUsersAndLoginRoles_id);
                    
                    SQL_Parameter Par_LoginUsersAndLoginRoles_Add_Res = new SQL_Parameter();
                    Par_LoginUsersAndLoginRoles_Add_Res.dbType = System.Data.SqlDbType.NVarChar;
                    Par_LoginUsersAndLoginRoles_Add_Res.Name = "@Par_LoginUsersAndLoginRoles_Add_Res";
                    Par_LoginUsersAndLoginRoles_Add_Res.size = 2000;
                    Par_LoginUsersAndLoginRoles_Add_Res.IsOutputParameter = true;
                    ProcParams.Add(Par_LoginUsersAndLoginRoles_Add_Res);
                    
                      object Result = exec("LoginUsersAndLoginRoles_Add",new string[] {"@LoginUsers_id","@LoginRoles_id","@LoginUsers_id_Administrator","@LoginUsersAndLoginRoles_id","@Res"},ref Err);
                      LoginUsersAndLoginRoles_id = (int) ProcParamValue("@Par_LoginUsersAndLoginRoles_Add_LoginUsersAndLoginRoles_id");
Res = (string) ProcParamValue("@Par_LoginUsersAndLoginRoles_Add_Res");

                      if (Result==null)
                      {
                         return 0;
                      }
                      else if (Result.GetType()==typeof(int))
                      {
                        return (int) Result;
                      }
                      else 
                      {
                        return -1;
                      }
                    }
                
                    public const string LoginManager_AddJournal_const = "LoginManager_AddJournal";

                    public int LoginManager_AddJournal(int LoginUsers_id,string EventMsg, ref string Res, ref string Err)
                    {
                      
                    ProcParams.Clear();
                    SQL_Parameter Ret_code_CopyRight_Logina_AuthorDamjanStrucl = new SQL_Parameter();
                    Ret_code_CopyRight_Logina_AuthorDamjanStrucl.dbType = System.Data.SqlDbType.Int;
                    Ret_code_CopyRight_Logina_AuthorDamjanStrucl.Name = "@Ret_code_CopyRight_Logina_AuthorDamjanStrucl";
                    Ret_code_CopyRight_Logina_AuthorDamjanStrucl.size = 4;
                    Ret_code_CopyRight_Logina_AuthorDamjanStrucl.IsOutputParameter = true;
                    ProcParams.Add(Ret_code_CopyRight_Logina_AuthorDamjanStrucl);
                    
                    SQL_Parameter Par_LoginManager_AddJournal_LoginUsers_id = new SQL_Parameter();
                    Par_LoginManager_AddJournal_LoginUsers_id.dbType = System.Data.SqlDbType.Int;
                    Par_LoginManager_AddJournal_LoginUsers_id.Name = "@Par_LoginManager_AddJournal_LoginUsers_id";
                    Par_LoginManager_AddJournal_LoginUsers_id.size = 4;
                    Par_LoginManager_AddJournal_LoginUsers_id.Value = LoginUsers_id;
                    Par_LoginManager_AddJournal_LoginUsers_id.IsOutputParameter = false;
                    ProcParams.Add(Par_LoginManager_AddJournal_LoginUsers_id);
                    
                    SQL_Parameter Par_LoginManager_AddJournal_EventMsg = new SQL_Parameter();
                    Par_LoginManager_AddJournal_EventMsg.dbType = System.Data.SqlDbType.NVarChar;
                    Par_LoginManager_AddJournal_EventMsg.Name = "@Par_LoginManager_AddJournal_EventMsg";
                    Par_LoginManager_AddJournal_EventMsg.size = 1000;
                    Par_LoginManager_AddJournal_EventMsg.Value = EventMsg;
                    Par_LoginManager_AddJournal_EventMsg.IsOutputParameter = false;
                    ProcParams.Add(Par_LoginManager_AddJournal_EventMsg);
                    
                    SQL_Parameter Par_LoginManager_AddJournal_Res = new SQL_Parameter();
                    Par_LoginManager_AddJournal_Res.dbType = System.Data.SqlDbType.NVarChar;
                    Par_LoginManager_AddJournal_Res.Name = "@Par_LoginManager_AddJournal_Res";
                    Par_LoginManager_AddJournal_Res.size = 2000;
                    Par_LoginManager_AddJournal_Res.IsOutputParameter = true;
                    ProcParams.Add(Par_LoginManager_AddJournal_Res);
                    
                      object Result = exec("LoginManager_AddJournal",new string[] {"@LoginUsers_id","@EventMsg","@Res"},ref Err);
                      Res = (string) ProcParamValue("@Par_LoginManager_AddJournal_Res");

                      if (Result==null)
                      {
                         return 0;
                      }
                      else if (Result.GetType()==typeof(int))
                      {
                        return (int) Result;
                      }
                      else 
                      {
                        return -1;
                      }
                    }
                
                    public const string LoginSession_Start_const = "LoginSession_Start";

                    public int LoginSession_Start(int LoginUsers_id,string ComputerName,string ComputerUserName, ref int LoginSession_id, ref string Res, ref string Err)
                    {
                      
                    ProcParams.Clear();
                    SQL_Parameter Ret_code_CopyRight_Logina_AuthorDamjanStrucl = new SQL_Parameter();
                    Ret_code_CopyRight_Logina_AuthorDamjanStrucl.dbType = System.Data.SqlDbType.Int;
                    Ret_code_CopyRight_Logina_AuthorDamjanStrucl.Name = "@Ret_code_CopyRight_Logina_AuthorDamjanStrucl";
                    Ret_code_CopyRight_Logina_AuthorDamjanStrucl.size = 4;
                    Ret_code_CopyRight_Logina_AuthorDamjanStrucl.IsOutputParameter = true;
                    ProcParams.Add(Ret_code_CopyRight_Logina_AuthorDamjanStrucl);
                    
                    SQL_Parameter Par_LoginSession_Start_LoginUsers_id = new SQL_Parameter();
                    Par_LoginSession_Start_LoginUsers_id.dbType = System.Data.SqlDbType.Int;
                    Par_LoginSession_Start_LoginUsers_id.Name = "@Par_LoginSession_Start_LoginUsers_id";
                    Par_LoginSession_Start_LoginUsers_id.size = 4;
                    Par_LoginSession_Start_LoginUsers_id.Value = LoginUsers_id;
                    Par_LoginSession_Start_LoginUsers_id.IsOutputParameter = false;
                    ProcParams.Add(Par_LoginSession_Start_LoginUsers_id);
                    
                    SQL_Parameter Par_LoginSession_Start_ComputerName = new SQL_Parameter();
                    Par_LoginSession_Start_ComputerName.dbType = System.Data.SqlDbType.NVarChar;
                    Par_LoginSession_Start_ComputerName.Name = "@Par_LoginSession_Start_ComputerName";
                    Par_LoginSession_Start_ComputerName.size = 260;
                    Par_LoginSession_Start_ComputerName.Value = ComputerName;
                    Par_LoginSession_Start_ComputerName.IsOutputParameter = false;
                    ProcParams.Add(Par_LoginSession_Start_ComputerName);
                    
                    SQL_Parameter Par_LoginSession_Start_ComputerUserName = new SQL_Parameter();
                    Par_LoginSession_Start_ComputerUserName.dbType = System.Data.SqlDbType.NVarChar;
                    Par_LoginSession_Start_ComputerUserName.Name = "@Par_LoginSession_Start_ComputerUserName";
                    Par_LoginSession_Start_ComputerUserName.size = 260;
                    Par_LoginSession_Start_ComputerUserName.Value = ComputerUserName;
                    Par_LoginSession_Start_ComputerUserName.IsOutputParameter = false;
                    ProcParams.Add(Par_LoginSession_Start_ComputerUserName);
                    
                    SQL_Parameter Par_LoginSession_Start_LoginSession_id = new SQL_Parameter();
                    Par_LoginSession_Start_LoginSession_id.dbType = System.Data.SqlDbType.Int;
                    Par_LoginSession_Start_LoginSession_id.Name = "@Par_LoginSession_Start_LoginSession_id";
                    Par_LoginSession_Start_LoginSession_id.size = 4;
                    Par_LoginSession_Start_LoginSession_id.IsOutputParameter = true;
                    ProcParams.Add(Par_LoginSession_Start_LoginSession_id);
                    
                    SQL_Parameter Par_LoginSession_Start_Res = new SQL_Parameter();
                    Par_LoginSession_Start_Res.dbType = System.Data.SqlDbType.NVarChar;
                    Par_LoginSession_Start_Res.Name = "@Par_LoginSession_Start_Res";
                    Par_LoginSession_Start_Res.size = 2000;
                    Par_LoginSession_Start_Res.IsOutputParameter = true;
                    ProcParams.Add(Par_LoginSession_Start_Res);
                    
                      object Result = exec("LoginSession_Start",new string[] {"@LoginUsers_id","@ComputerName","@ComputerUserName","@LoginSession_id","@Res"},ref Err);
                      LoginSession_id = (int) ProcParamValue("@Par_LoginSession_Start_LoginSession_id");
Res = (string) ProcParamValue("@Par_LoginSession_Start_Res");

                      if (Result==null)
                      {
                         return 0;
                      }
                      else if (Result.GetType()==typeof(int))
                      {
                        return (int) Result;
                      }
                      else 
                      {
                        return -1;
                      }
                    }
                
                    public const string LoginSession_End_const = "LoginSession_End";

                    public int LoginSession_End(int LoginSession_id, ref string Res, ref string Err)
                    {
                      
                    ProcParams.Clear();
                    SQL_Parameter Ret_code_CopyRight_Logina_AuthorDamjanStrucl = new SQL_Parameter();
                    Ret_code_CopyRight_Logina_AuthorDamjanStrucl.dbType = System.Data.SqlDbType.Int;
                    Ret_code_CopyRight_Logina_AuthorDamjanStrucl.Name = "@Ret_code_CopyRight_Logina_AuthorDamjanStrucl";
                    Ret_code_CopyRight_Logina_AuthorDamjanStrucl.size = 4;
                    Ret_code_CopyRight_Logina_AuthorDamjanStrucl.IsOutputParameter = true;
                    ProcParams.Add(Ret_code_CopyRight_Logina_AuthorDamjanStrucl);
                    
                    SQL_Parameter Par_LoginSession_End_LoginSession_id = new SQL_Parameter();
                    Par_LoginSession_End_LoginSession_id.dbType = System.Data.SqlDbType.Int;
                    Par_LoginSession_End_LoginSession_id.Name = "@Par_LoginSession_End_LoginSession_id";
                    Par_LoginSession_End_LoginSession_id.size = 4;
                    Par_LoginSession_End_LoginSession_id.Value = LoginSession_id;
                    Par_LoginSession_End_LoginSession_id.IsOutputParameter = false;
                    ProcParams.Add(Par_LoginSession_End_LoginSession_id);
                    
                    SQL_Parameter Par_LoginSession_End_Res = new SQL_Parameter();
                    Par_LoginSession_End_Res.dbType = System.Data.SqlDbType.NVarChar;
                    Par_LoginSession_End_Res.Name = "@Par_LoginSession_End_Res";
                    Par_LoginSession_End_Res.size = 2000;
                    Par_LoginSession_End_Res.IsOutputParameter = true;
                    ProcParams.Add(Par_LoginSession_End_Res);
                    
                      object Result = exec("LoginSession_End",new string[] {"@LoginSession_id","@Res"},ref Err);
                      Res = (string) ProcParamValue("@Par_LoginSession_End_Res");

                      if (Result==null)
                      {
                         return 0;
                      }
                      else if (Result.GetType()==typeof(int))
                      {
                        return (int) Result;
                      }
                      else 
                      {
                        return -1;
                      }
                    }
                
                    public const string LoginUsers_ChangeData_const = "LoginUsers_ChangeData";

                    public int LoginUsers_ChangeData(int LoginUsers_id,string first_name,string last_name,string Identity,string Contact, ref string Res, ref string Err)
                    {
                      
                    ProcParams.Clear();
                    SQL_Parameter Ret_code_CopyRight_Logina_AuthorDamjanStrucl = new SQL_Parameter();
                    Ret_code_CopyRight_Logina_AuthorDamjanStrucl.dbType = System.Data.SqlDbType.Int;
                    Ret_code_CopyRight_Logina_AuthorDamjanStrucl.Name = "@Ret_code_CopyRight_Logina_AuthorDamjanStrucl";
                    Ret_code_CopyRight_Logina_AuthorDamjanStrucl.size = 4;
                    Ret_code_CopyRight_Logina_AuthorDamjanStrucl.IsOutputParameter = true;
                    ProcParams.Add(Ret_code_CopyRight_Logina_AuthorDamjanStrucl);
                    
                    SQL_Parameter Par_LoginUsers_ChangeData_LoginUsers_id = new SQL_Parameter();
                    Par_LoginUsers_ChangeData_LoginUsers_id.dbType = System.Data.SqlDbType.Int;
                    Par_LoginUsers_ChangeData_LoginUsers_id.Name = "@Par_LoginUsers_ChangeData_LoginUsers_id";
                    Par_LoginUsers_ChangeData_LoginUsers_id.size = 4;
                    Par_LoginUsers_ChangeData_LoginUsers_id.Value = LoginUsers_id;
                    Par_LoginUsers_ChangeData_LoginUsers_id.IsOutputParameter = false;
                    ProcParams.Add(Par_LoginUsers_ChangeData_LoginUsers_id);
                    
                    SQL_Parameter Par_LoginUsers_ChangeData_first_name = new SQL_Parameter();
                    Par_LoginUsers_ChangeData_first_name.dbType = System.Data.SqlDbType.NVarChar;
                    Par_LoginUsers_ChangeData_first_name.Name = "@Par_LoginUsers_ChangeData_first_name";
                    Par_LoginUsers_ChangeData_first_name.size = 250;
                    Par_LoginUsers_ChangeData_first_name.Value = first_name;
                    Par_LoginUsers_ChangeData_first_name.IsOutputParameter = false;
                    ProcParams.Add(Par_LoginUsers_ChangeData_first_name);
                    
                    SQL_Parameter Par_LoginUsers_ChangeData_last_name = new SQL_Parameter();
                    Par_LoginUsers_ChangeData_last_name.dbType = System.Data.SqlDbType.NVarChar;
                    Par_LoginUsers_ChangeData_last_name.Name = "@Par_LoginUsers_ChangeData_last_name";
                    Par_LoginUsers_ChangeData_last_name.size = 250;
                    Par_LoginUsers_ChangeData_last_name.Value = last_name;
                    Par_LoginUsers_ChangeData_last_name.IsOutputParameter = false;
                    ProcParams.Add(Par_LoginUsers_ChangeData_last_name);
                    
                    SQL_Parameter Par_LoginUsers_ChangeData_Identity = new SQL_Parameter();
                    Par_LoginUsers_ChangeData_Identity.dbType = System.Data.SqlDbType.NVarChar;
                    Par_LoginUsers_ChangeData_Identity.Name = "@Par_LoginUsers_ChangeData_Identity";
                    Par_LoginUsers_ChangeData_Identity.size = 4000;
                    Par_LoginUsers_ChangeData_Identity.Value = Identity;
                    Par_LoginUsers_ChangeData_Identity.IsOutputParameter = false;
                    ProcParams.Add(Par_LoginUsers_ChangeData_Identity);
                    
                    SQL_Parameter Par_LoginUsers_ChangeData_Contact = new SQL_Parameter();
                    Par_LoginUsers_ChangeData_Contact.dbType = System.Data.SqlDbType.NVarChar;
                    Par_LoginUsers_ChangeData_Contact.Name = "@Par_LoginUsers_ChangeData_Contact";
                    Par_LoginUsers_ChangeData_Contact.size = 1000;
                    Par_LoginUsers_ChangeData_Contact.Value = Contact;
                    Par_LoginUsers_ChangeData_Contact.IsOutputParameter = false;
                    ProcParams.Add(Par_LoginUsers_ChangeData_Contact);
                    
                    SQL_Parameter Par_LoginUsers_ChangeData_Res = new SQL_Parameter();
                    Par_LoginUsers_ChangeData_Res.dbType = System.Data.SqlDbType.NVarChar;
                    Par_LoginUsers_ChangeData_Res.Name = "@Par_LoginUsers_ChangeData_Res";
                    Par_LoginUsers_ChangeData_Res.size = 2000;
                    Par_LoginUsers_ChangeData_Res.IsOutputParameter = true;
                    ProcParams.Add(Par_LoginUsers_ChangeData_Res);
                    
                      object Result = exec("LoginUsers_ChangeData",new string[] {"@LoginUsers_id","@first_name","@last_name","@Identity","@Contact","@Res"},ref Err);
                      Res = (string) ProcParamValue("@Par_LoginUsers_ChangeData_Res");

                      if (Result==null)
                      {
                         return 0;
                      }
                      else if (Result.GetType()==typeof(int))
                      {
                        return (int) Result;
                      }
                      else 
                      {
                        return -1;
                      }
                    }
                
                    public const string LoginUsers_UserChangeItsOwnPassword_const = "LoginUsers_UserChangeItsOwnPassword";

                    public int LoginUsers_UserChangeItsOwnPassword(int LoginUsers_id,Byte[] password, ref string Res, ref string Err)
                    {
                      
                    ProcParams.Clear();
                    SQL_Parameter Ret_code_CopyRight_Logina_AuthorDamjanStrucl = new SQL_Parameter();
                    Ret_code_CopyRight_Logina_AuthorDamjanStrucl.dbType = System.Data.SqlDbType.Int;
                    Ret_code_CopyRight_Logina_AuthorDamjanStrucl.Name = "@Ret_code_CopyRight_Logina_AuthorDamjanStrucl";
                    Ret_code_CopyRight_Logina_AuthorDamjanStrucl.size = 4;
                    Ret_code_CopyRight_Logina_AuthorDamjanStrucl.IsOutputParameter = true;
                    ProcParams.Add(Ret_code_CopyRight_Logina_AuthorDamjanStrucl);
                    
                    SQL_Parameter Par_LoginUsers_UserChangeItsOwnPassword_LoginUsers_id = new SQL_Parameter();
                    Par_LoginUsers_UserChangeItsOwnPassword_LoginUsers_id.dbType = System.Data.SqlDbType.Int;
                    Par_LoginUsers_UserChangeItsOwnPassword_LoginUsers_id.Name = "@Par_LoginUsers_UserChangeItsOwnPassword_LoginUsers_id";
                    Par_LoginUsers_UserChangeItsOwnPassword_LoginUsers_id.size = 4;
                    Par_LoginUsers_UserChangeItsOwnPassword_LoginUsers_id.Value = LoginUsers_id;
                    Par_LoginUsers_UserChangeItsOwnPassword_LoginUsers_id.IsOutputParameter = false;
                    ProcParams.Add(Par_LoginUsers_UserChangeItsOwnPassword_LoginUsers_id);
                    
                    SQL_Parameter Par_LoginUsers_UserChangeItsOwnPassword_password = new SQL_Parameter();
                    Par_LoginUsers_UserChangeItsOwnPassword_password.dbType = System.Data.SqlDbType.VarBinary;
                    Par_LoginUsers_UserChangeItsOwnPassword_password.Name = "@Par_LoginUsers_UserChangeItsOwnPassword_password";
                    Par_LoginUsers_UserChangeItsOwnPassword_password.size = -1;
                    Par_LoginUsers_UserChangeItsOwnPassword_password.Value = password;
                    Par_LoginUsers_UserChangeItsOwnPassword_password.IsOutputParameter = false;
                    ProcParams.Add(Par_LoginUsers_UserChangeItsOwnPassword_password);
                    
                    SQL_Parameter Par_LoginUsers_UserChangeItsOwnPassword_Res = new SQL_Parameter();
                    Par_LoginUsers_UserChangeItsOwnPassword_Res.dbType = System.Data.SqlDbType.NVarChar;
                    Par_LoginUsers_UserChangeItsOwnPassword_Res.Name = "@Par_LoginUsers_UserChangeItsOwnPassword_Res";
                    Par_LoginUsers_UserChangeItsOwnPassword_Res.size = 2000;
                    Par_LoginUsers_UserChangeItsOwnPassword_Res.IsOutputParameter = true;
                    ProcParams.Add(Par_LoginUsers_UserChangeItsOwnPassword_Res);
                    
                      object Result = exec("LoginUsers_UserChangeItsOwnPassword",new string[] {"@LoginUsers_id","@password","@Res"},ref Err);
                      Res = (string) ProcParamValue("@Par_LoginUsers_UserChangeItsOwnPassword_Res");

                      if (Result==null)
                      {
                         return 0;
                      }
                      else if (Result.GetType()==typeof(int))
                      {
                        return (int) Result;
                      }
                      else 
                      {
                        return -1;
                      }
                    }
                
                    public const string LoginUsers_Administrator_ChangePassword_const = "LoginUsers_Administrator_ChangePassword";

                    public int LoginUsers_Administrator_ChangePassword(int LoginUsers_id,Byte[] password,int LoginUsers_id_Administrator_that_is_changing_password, ref string Res, ref string Err)
                    {
                      
                    ProcParams.Clear();
                    SQL_Parameter Ret_code_CopyRight_Logina_AuthorDamjanStrucl = new SQL_Parameter();
                    Ret_code_CopyRight_Logina_AuthorDamjanStrucl.dbType = System.Data.SqlDbType.Int;
                    Ret_code_CopyRight_Logina_AuthorDamjanStrucl.Name = "@Ret_code_CopyRight_Logina_AuthorDamjanStrucl";
                    Ret_code_CopyRight_Logina_AuthorDamjanStrucl.size = 4;
                    Ret_code_CopyRight_Logina_AuthorDamjanStrucl.IsOutputParameter = true;
                    ProcParams.Add(Ret_code_CopyRight_Logina_AuthorDamjanStrucl);
                    
                    SQL_Parameter Par_LoginUsers_Administrator_ChangePassword_LoginUsers_id = new SQL_Parameter();
                    Par_LoginUsers_Administrator_ChangePassword_LoginUsers_id.dbType = System.Data.SqlDbType.Int;
                    Par_LoginUsers_Administrator_ChangePassword_LoginUsers_id.Name = "@Par_LoginUsers_Administrator_ChangePassword_LoginUsers_id";
                    Par_LoginUsers_Administrator_ChangePassword_LoginUsers_id.size = 4;
                    Par_LoginUsers_Administrator_ChangePassword_LoginUsers_id.Value = LoginUsers_id;
                    Par_LoginUsers_Administrator_ChangePassword_LoginUsers_id.IsOutputParameter = false;
                    ProcParams.Add(Par_LoginUsers_Administrator_ChangePassword_LoginUsers_id);
                    
                    SQL_Parameter Par_LoginUsers_Administrator_ChangePassword_password = new SQL_Parameter();
                    Par_LoginUsers_Administrator_ChangePassword_password.dbType = System.Data.SqlDbType.VarBinary;
                    Par_LoginUsers_Administrator_ChangePassword_password.Name = "@Par_LoginUsers_Administrator_ChangePassword_password";
                    Par_LoginUsers_Administrator_ChangePassword_password.size = -1;
                    Par_LoginUsers_Administrator_ChangePassword_password.Value = password;
                    Par_LoginUsers_Administrator_ChangePassword_password.IsOutputParameter = false;
                    ProcParams.Add(Par_LoginUsers_Administrator_ChangePassword_password);
                    
                    SQL_Parameter Par_LoginUsers_Administrator_ChangePassword_LoginUsers_id_Administrator_that_is_changing_password = new SQL_Parameter();
                    Par_LoginUsers_Administrator_ChangePassword_LoginUsers_id_Administrator_that_is_changing_password.dbType = System.Data.SqlDbType.Int;
                    Par_LoginUsers_Administrator_ChangePassword_LoginUsers_id_Administrator_that_is_changing_password.Name = "@Par_LoginUsers_Administrator_ChangePassword_LoginUsers_id_Administrator_that_is_changing_password";
                    Par_LoginUsers_Administrator_ChangePassword_LoginUsers_id_Administrator_that_is_changing_password.size = 4;
                    Par_LoginUsers_Administrator_ChangePassword_LoginUsers_id_Administrator_that_is_changing_password.Value = LoginUsers_id_Administrator_that_is_changing_password;
                    Par_LoginUsers_Administrator_ChangePassword_LoginUsers_id_Administrator_that_is_changing_password.IsOutputParameter = false;
                    ProcParams.Add(Par_LoginUsers_Administrator_ChangePassword_LoginUsers_id_Administrator_that_is_changing_password);
                    
                    SQL_Parameter Par_LoginUsers_Administrator_ChangePassword_Res = new SQL_Parameter();
                    Par_LoginUsers_Administrator_ChangePassword_Res.dbType = System.Data.SqlDbType.NVarChar;
                    Par_LoginUsers_Administrator_ChangePassword_Res.Name = "@Par_LoginUsers_Administrator_ChangePassword_Res";
                    Par_LoginUsers_Administrator_ChangePassword_Res.size = 2000;
                    Par_LoginUsers_Administrator_ChangePassword_Res.IsOutputParameter = true;
                    ProcParams.Add(Par_LoginUsers_Administrator_ChangePassword_Res);
                    
                      object Result = exec("LoginUsers_Administrator_ChangePassword",new string[] {"@LoginUsers_id","@password","@LoginUsers_id_Administrator_that_is_changing_password","@Res"},ref Err);
                      Res = (string) ProcParamValue("@Par_LoginUsers_Administrator_ChangePassword_Res");

                      if (Result==null)
                      {
                         return 0;
                      }
                      else if (Result.GetType()==typeof(int))
                      {
                        return (int) Result;
                      }
                      else 
                      {
                        return -1;
                      }
                    }
                
                    public const string LoginUsers_Administrator_ChangePasswordParameters_const = "LoginUsers_Administrator_ChangePasswordParameters";

                    public int LoginUsers_Administrator_ChangePasswordParameters(int LoginUsers_id,int LoginUsers_id_Administrator_that_is_changing_password,bool enabled,bool PasswordNeverExpires,bool ChangePasswordOnFirstLogin,int Maximum_password_age_in_days,bool NotActiveAfterPasswordExpires, ref string Res, ref string Err)
                    {
                      
                    ProcParams.Clear();
                    SQL_Parameter Ret_code_CopyRight_Logina_AuthorDamjanStrucl = new SQL_Parameter();
                    Ret_code_CopyRight_Logina_AuthorDamjanStrucl.dbType = System.Data.SqlDbType.Int;
                    Ret_code_CopyRight_Logina_AuthorDamjanStrucl.Name = "@Ret_code_CopyRight_Logina_AuthorDamjanStrucl";
                    Ret_code_CopyRight_Logina_AuthorDamjanStrucl.size = 4;
                    Ret_code_CopyRight_Logina_AuthorDamjanStrucl.IsOutputParameter = true;
                    ProcParams.Add(Ret_code_CopyRight_Logina_AuthorDamjanStrucl);
                    
                    SQL_Parameter Par_LoginUsers_Administrator_ChangePasswordParameters_LoginUsers_id = new SQL_Parameter();
                    Par_LoginUsers_Administrator_ChangePasswordParameters_LoginUsers_id.dbType = System.Data.SqlDbType.Int;
                    Par_LoginUsers_Administrator_ChangePasswordParameters_LoginUsers_id.Name = "@Par_LoginUsers_Administrator_ChangePasswordParameters_LoginUsers_id";
                    Par_LoginUsers_Administrator_ChangePasswordParameters_LoginUsers_id.size = 4;
                    Par_LoginUsers_Administrator_ChangePasswordParameters_LoginUsers_id.Value = LoginUsers_id;
                    Par_LoginUsers_Administrator_ChangePasswordParameters_LoginUsers_id.IsOutputParameter = false;
                    ProcParams.Add(Par_LoginUsers_Administrator_ChangePasswordParameters_LoginUsers_id);
                    
                    SQL_Parameter Par_LoginUsers_Administrator_ChangePasswordParameters_LoginUsers_id_Administrator_that_is_changing_password = new SQL_Parameter();
                    Par_LoginUsers_Administrator_ChangePasswordParameters_LoginUsers_id_Administrator_that_is_changing_password.dbType = System.Data.SqlDbType.Int;
                    Par_LoginUsers_Administrator_ChangePasswordParameters_LoginUsers_id_Administrator_that_is_changing_password.Name = "@Par_LoginUsers_Administrator_ChangePasswordParameters_LoginUsers_id_Administrator_that_is_changing_password";
                    Par_LoginUsers_Administrator_ChangePasswordParameters_LoginUsers_id_Administrator_that_is_changing_password.size = 4;
                    Par_LoginUsers_Administrator_ChangePasswordParameters_LoginUsers_id_Administrator_that_is_changing_password.Value = LoginUsers_id_Administrator_that_is_changing_password;
                    Par_LoginUsers_Administrator_ChangePasswordParameters_LoginUsers_id_Administrator_that_is_changing_password.IsOutputParameter = false;
                    ProcParams.Add(Par_LoginUsers_Administrator_ChangePasswordParameters_LoginUsers_id_Administrator_that_is_changing_password);
                    
                    SQL_Parameter Par_LoginUsers_Administrator_ChangePasswordParameters_enabled = new SQL_Parameter();
                    Par_LoginUsers_Administrator_ChangePasswordParameters_enabled.dbType = System.Data.SqlDbType.Bit;
                    Par_LoginUsers_Administrator_ChangePasswordParameters_enabled.Name = "@Par_LoginUsers_Administrator_ChangePasswordParameters_enabled";
                    Par_LoginUsers_Administrator_ChangePasswordParameters_enabled.size = 1;
                    Par_LoginUsers_Administrator_ChangePasswordParameters_enabled.Value = enabled;
                    Par_LoginUsers_Administrator_ChangePasswordParameters_enabled.IsOutputParameter = false;
                    ProcParams.Add(Par_LoginUsers_Administrator_ChangePasswordParameters_enabled);
                    
                    SQL_Parameter Par_LoginUsers_Administrator_ChangePasswordParameters_PasswordNeverExpires = new SQL_Parameter();
                    Par_LoginUsers_Administrator_ChangePasswordParameters_PasswordNeverExpires.dbType = System.Data.SqlDbType.Bit;
                    Par_LoginUsers_Administrator_ChangePasswordParameters_PasswordNeverExpires.Name = "@Par_LoginUsers_Administrator_ChangePasswordParameters_PasswordNeverExpires";
                    Par_LoginUsers_Administrator_ChangePasswordParameters_PasswordNeverExpires.size = 1;
                    Par_LoginUsers_Administrator_ChangePasswordParameters_PasswordNeverExpires.Value = PasswordNeverExpires;
                    Par_LoginUsers_Administrator_ChangePasswordParameters_PasswordNeverExpires.IsOutputParameter = false;
                    ProcParams.Add(Par_LoginUsers_Administrator_ChangePasswordParameters_PasswordNeverExpires);
                    
                    SQL_Parameter Par_LoginUsers_Administrator_ChangePasswordParameters_ChangePasswordOnFirstLogin = new SQL_Parameter();
                    Par_LoginUsers_Administrator_ChangePasswordParameters_ChangePasswordOnFirstLogin.dbType = System.Data.SqlDbType.Bit;
                    Par_LoginUsers_Administrator_ChangePasswordParameters_ChangePasswordOnFirstLogin.Name = "@Par_LoginUsers_Administrator_ChangePasswordParameters_ChangePasswordOnFirstLogin";
                    Par_LoginUsers_Administrator_ChangePasswordParameters_ChangePasswordOnFirstLogin.size = 1;
                    Par_LoginUsers_Administrator_ChangePasswordParameters_ChangePasswordOnFirstLogin.Value = ChangePasswordOnFirstLogin;
                    Par_LoginUsers_Administrator_ChangePasswordParameters_ChangePasswordOnFirstLogin.IsOutputParameter = false;
                    ProcParams.Add(Par_LoginUsers_Administrator_ChangePasswordParameters_ChangePasswordOnFirstLogin);
                    
                    SQL_Parameter Par_LoginUsers_Administrator_ChangePasswordParameters_Maximum_password_age_in_days = new SQL_Parameter();
                    Par_LoginUsers_Administrator_ChangePasswordParameters_Maximum_password_age_in_days.dbType = System.Data.SqlDbType.Int;
                    Par_LoginUsers_Administrator_ChangePasswordParameters_Maximum_password_age_in_days.Name = "@Par_LoginUsers_Administrator_ChangePasswordParameters_Maximum_password_age_in_days";
                    Par_LoginUsers_Administrator_ChangePasswordParameters_Maximum_password_age_in_days.size = 4;
                    Par_LoginUsers_Administrator_ChangePasswordParameters_Maximum_password_age_in_days.Value = Maximum_password_age_in_days;
                    Par_LoginUsers_Administrator_ChangePasswordParameters_Maximum_password_age_in_days.IsOutputParameter = false;
                    ProcParams.Add(Par_LoginUsers_Administrator_ChangePasswordParameters_Maximum_password_age_in_days);
                    
                    SQL_Parameter Par_LoginUsers_Administrator_ChangePasswordParameters_NotActiveAfterPasswordExpires = new SQL_Parameter();
                    Par_LoginUsers_Administrator_ChangePasswordParameters_NotActiveAfterPasswordExpires.dbType = System.Data.SqlDbType.Bit;
                    Par_LoginUsers_Administrator_ChangePasswordParameters_NotActiveAfterPasswordExpires.Name = "@Par_LoginUsers_Administrator_ChangePasswordParameters_NotActiveAfterPasswordExpires";
                    Par_LoginUsers_Administrator_ChangePasswordParameters_NotActiveAfterPasswordExpires.size = 1;
                    Par_LoginUsers_Administrator_ChangePasswordParameters_NotActiveAfterPasswordExpires.Value = NotActiveAfterPasswordExpires;
                    Par_LoginUsers_Administrator_ChangePasswordParameters_NotActiveAfterPasswordExpires.IsOutputParameter = false;
                    ProcParams.Add(Par_LoginUsers_Administrator_ChangePasswordParameters_NotActiveAfterPasswordExpires);
                    
                    SQL_Parameter Par_LoginUsers_Administrator_ChangePasswordParameters_Res = new SQL_Parameter();
                    Par_LoginUsers_Administrator_ChangePasswordParameters_Res.dbType = System.Data.SqlDbType.NVarChar;
                    Par_LoginUsers_Administrator_ChangePasswordParameters_Res.Name = "@Par_LoginUsers_Administrator_ChangePasswordParameters_Res";
                    Par_LoginUsers_Administrator_ChangePasswordParameters_Res.size = 2000;
                    Par_LoginUsers_Administrator_ChangePasswordParameters_Res.IsOutputParameter = true;
                    ProcParams.Add(Par_LoginUsers_Administrator_ChangePasswordParameters_Res);
                    
                      object Result = exec("LoginUsers_Administrator_ChangePasswordParameters",new string[] {"@LoginUsers_id","@LoginUsers_id_Administrator_that_is_changing_password","@enabled","@PasswordNeverExpires","@ChangePasswordOnFirstLogin","@Maximum_password_age_in_days","@NotActiveAfterPasswordExpires","@Res"},ref Err);
                      Res = (string) ProcParamValue("@Par_LoginUsers_Administrator_ChangePasswordParameters_Res");

                      if (Result==null)
                      {
                         return 0;
                      }
                      else if (Result.GetType()==typeof(int))
                      {
                        return (int) Result;
                      }
                      else 
                      {
                        return -1;
                      }
                    }
                
                    public const string LoginUsers_Administrator_AddUser_const = "LoginUsers_Administrator_AddUser";

                    public int LoginUsers_Administrator_AddUser(string username,Byte[] password,bool enabled,string first_name,string last_name,string Identity,string Contact,int LoginUsers_id_Administrator_that_is_changing_password,bool PasswordNeverExpires,bool ChangePasswordOnFirstLogin,int Maximum_password_age_in_days,bool NotActiveAfterPasswordExpires, ref int LoginUsers_id, ref string Res, ref string Err)
                    {
                      
                    ProcParams.Clear();
                    SQL_Parameter Ret_code_CopyRight_Logina_AuthorDamjanStrucl = new SQL_Parameter();
                    Ret_code_CopyRight_Logina_AuthorDamjanStrucl.dbType = System.Data.SqlDbType.Int;
                    Ret_code_CopyRight_Logina_AuthorDamjanStrucl.Name = "@Ret_code_CopyRight_Logina_AuthorDamjanStrucl";
                    Ret_code_CopyRight_Logina_AuthorDamjanStrucl.size = 4;
                    Ret_code_CopyRight_Logina_AuthorDamjanStrucl.IsOutputParameter = true;
                    ProcParams.Add(Ret_code_CopyRight_Logina_AuthorDamjanStrucl);
                    
                    SQL_Parameter Par_LoginUsers_Administrator_AddUser_username = new SQL_Parameter();
                    Par_LoginUsers_Administrator_AddUser_username.dbType = System.Data.SqlDbType.NVarChar;
                    Par_LoginUsers_Administrator_AddUser_username.Name = "@Par_LoginUsers_Administrator_AddUser_username";
                    Par_LoginUsers_Administrator_AddUser_username.size = 250;
                    Par_LoginUsers_Administrator_AddUser_username.Value = username;
                    Par_LoginUsers_Administrator_AddUser_username.IsOutputParameter = false;
                    ProcParams.Add(Par_LoginUsers_Administrator_AddUser_username);
                    
                    SQL_Parameter Par_LoginUsers_Administrator_AddUser_password = new SQL_Parameter();
                    Par_LoginUsers_Administrator_AddUser_password.dbType = System.Data.SqlDbType.VarBinary;
                    Par_LoginUsers_Administrator_AddUser_password.Name = "@Par_LoginUsers_Administrator_AddUser_password";
                    Par_LoginUsers_Administrator_AddUser_password.size = -1;
                    Par_LoginUsers_Administrator_AddUser_password.Value = password;
                    Par_LoginUsers_Administrator_AddUser_password.IsOutputParameter = false;
                    ProcParams.Add(Par_LoginUsers_Administrator_AddUser_password);
                    
                    SQL_Parameter Par_LoginUsers_Administrator_AddUser_enabled = new SQL_Parameter();
                    Par_LoginUsers_Administrator_AddUser_enabled.dbType = System.Data.SqlDbType.Bit;
                    Par_LoginUsers_Administrator_AddUser_enabled.Name = "@Par_LoginUsers_Administrator_AddUser_enabled";
                    Par_LoginUsers_Administrator_AddUser_enabled.size = 1;
                    Par_LoginUsers_Administrator_AddUser_enabled.Value = enabled;
                    Par_LoginUsers_Administrator_AddUser_enabled.IsOutputParameter = false;
                    ProcParams.Add(Par_LoginUsers_Administrator_AddUser_enabled);
                    
                    SQL_Parameter Par_LoginUsers_Administrator_AddUser_first_name = new SQL_Parameter();
                    Par_LoginUsers_Administrator_AddUser_first_name.dbType = System.Data.SqlDbType.NVarChar;
                    Par_LoginUsers_Administrator_AddUser_first_name.Name = "@Par_LoginUsers_Administrator_AddUser_first_name";
                    Par_LoginUsers_Administrator_AddUser_first_name.size = 250;
                    Par_LoginUsers_Administrator_AddUser_first_name.Value = first_name;
                    Par_LoginUsers_Administrator_AddUser_first_name.IsOutputParameter = false;
                    ProcParams.Add(Par_LoginUsers_Administrator_AddUser_first_name);
                    
                    SQL_Parameter Par_LoginUsers_Administrator_AddUser_last_name = new SQL_Parameter();
                    Par_LoginUsers_Administrator_AddUser_last_name.dbType = System.Data.SqlDbType.NVarChar;
                    Par_LoginUsers_Administrator_AddUser_last_name.Name = "@Par_LoginUsers_Administrator_AddUser_last_name";
                    Par_LoginUsers_Administrator_AddUser_last_name.size = 250;
                    Par_LoginUsers_Administrator_AddUser_last_name.Value = last_name;
                    Par_LoginUsers_Administrator_AddUser_last_name.IsOutputParameter = false;
                    ProcParams.Add(Par_LoginUsers_Administrator_AddUser_last_name);
                    
                    SQL_Parameter Par_LoginUsers_Administrator_AddUser_Identity = new SQL_Parameter();
                    Par_LoginUsers_Administrator_AddUser_Identity.dbType = System.Data.SqlDbType.NVarChar;
                    Par_LoginUsers_Administrator_AddUser_Identity.Name = "@Par_LoginUsers_Administrator_AddUser_Identity";
                    Par_LoginUsers_Administrator_AddUser_Identity.size = 4000;
                    Par_LoginUsers_Administrator_AddUser_Identity.Value = Identity;
                    Par_LoginUsers_Administrator_AddUser_Identity.IsOutputParameter = false;
                    ProcParams.Add(Par_LoginUsers_Administrator_AddUser_Identity);
                    
                    SQL_Parameter Par_LoginUsers_Administrator_AddUser_Contact = new SQL_Parameter();
                    Par_LoginUsers_Administrator_AddUser_Contact.dbType = System.Data.SqlDbType.NVarChar;
                    Par_LoginUsers_Administrator_AddUser_Contact.Name = "@Par_LoginUsers_Administrator_AddUser_Contact";
                    Par_LoginUsers_Administrator_AddUser_Contact.size = 1000;
                    Par_LoginUsers_Administrator_AddUser_Contact.Value = Contact;
                    Par_LoginUsers_Administrator_AddUser_Contact.IsOutputParameter = false;
                    ProcParams.Add(Par_LoginUsers_Administrator_AddUser_Contact);
                    
                    SQL_Parameter Par_LoginUsers_Administrator_AddUser_LoginUsers_id_Administrator_that_is_changing_password = new SQL_Parameter();
                    Par_LoginUsers_Administrator_AddUser_LoginUsers_id_Administrator_that_is_changing_password.dbType = System.Data.SqlDbType.Int;
                    Par_LoginUsers_Administrator_AddUser_LoginUsers_id_Administrator_that_is_changing_password.Name = "@Par_LoginUsers_Administrator_AddUser_LoginUsers_id_Administrator_that_is_changing_password";
                    Par_LoginUsers_Administrator_AddUser_LoginUsers_id_Administrator_that_is_changing_password.size = 4;
                    Par_LoginUsers_Administrator_AddUser_LoginUsers_id_Administrator_that_is_changing_password.Value = LoginUsers_id_Administrator_that_is_changing_password;
                    Par_LoginUsers_Administrator_AddUser_LoginUsers_id_Administrator_that_is_changing_password.IsOutputParameter = false;
                    ProcParams.Add(Par_LoginUsers_Administrator_AddUser_LoginUsers_id_Administrator_that_is_changing_password);
                    
                    SQL_Parameter Par_LoginUsers_Administrator_AddUser_PasswordNeverExpires = new SQL_Parameter();
                    Par_LoginUsers_Administrator_AddUser_PasswordNeverExpires.dbType = System.Data.SqlDbType.Bit;
                    Par_LoginUsers_Administrator_AddUser_PasswordNeverExpires.Name = "@Par_LoginUsers_Administrator_AddUser_PasswordNeverExpires";
                    Par_LoginUsers_Administrator_AddUser_PasswordNeverExpires.size = 1;
                    Par_LoginUsers_Administrator_AddUser_PasswordNeverExpires.Value = PasswordNeverExpires;
                    Par_LoginUsers_Administrator_AddUser_PasswordNeverExpires.IsOutputParameter = false;
                    ProcParams.Add(Par_LoginUsers_Administrator_AddUser_PasswordNeverExpires);
                    
                    SQL_Parameter Par_LoginUsers_Administrator_AddUser_ChangePasswordOnFirstLogin = new SQL_Parameter();
                    Par_LoginUsers_Administrator_AddUser_ChangePasswordOnFirstLogin.dbType = System.Data.SqlDbType.Bit;
                    Par_LoginUsers_Administrator_AddUser_ChangePasswordOnFirstLogin.Name = "@Par_LoginUsers_Administrator_AddUser_ChangePasswordOnFirstLogin";
                    Par_LoginUsers_Administrator_AddUser_ChangePasswordOnFirstLogin.size = 1;
                    Par_LoginUsers_Administrator_AddUser_ChangePasswordOnFirstLogin.Value = ChangePasswordOnFirstLogin;
                    Par_LoginUsers_Administrator_AddUser_ChangePasswordOnFirstLogin.IsOutputParameter = false;
                    ProcParams.Add(Par_LoginUsers_Administrator_AddUser_ChangePasswordOnFirstLogin);
                    
                    SQL_Parameter Par_LoginUsers_Administrator_AddUser_Maximum_password_age_in_days = new SQL_Parameter();
                    Par_LoginUsers_Administrator_AddUser_Maximum_password_age_in_days.dbType = System.Data.SqlDbType.Int;
                    Par_LoginUsers_Administrator_AddUser_Maximum_password_age_in_days.Name = "@Par_LoginUsers_Administrator_AddUser_Maximum_password_age_in_days";
                    Par_LoginUsers_Administrator_AddUser_Maximum_password_age_in_days.size = 4;
                    Par_LoginUsers_Administrator_AddUser_Maximum_password_age_in_days.Value = Maximum_password_age_in_days;
                    Par_LoginUsers_Administrator_AddUser_Maximum_password_age_in_days.IsOutputParameter = false;
                    ProcParams.Add(Par_LoginUsers_Administrator_AddUser_Maximum_password_age_in_days);
                    
                    SQL_Parameter Par_LoginUsers_Administrator_AddUser_NotActiveAfterPasswordExpires = new SQL_Parameter();
                    Par_LoginUsers_Administrator_AddUser_NotActiveAfterPasswordExpires.dbType = System.Data.SqlDbType.Bit;
                    Par_LoginUsers_Administrator_AddUser_NotActiveAfterPasswordExpires.Name = "@Par_LoginUsers_Administrator_AddUser_NotActiveAfterPasswordExpires";
                    Par_LoginUsers_Administrator_AddUser_NotActiveAfterPasswordExpires.size = 1;
                    Par_LoginUsers_Administrator_AddUser_NotActiveAfterPasswordExpires.Value = NotActiveAfterPasswordExpires;
                    Par_LoginUsers_Administrator_AddUser_NotActiveAfterPasswordExpires.IsOutputParameter = false;
                    ProcParams.Add(Par_LoginUsers_Administrator_AddUser_NotActiveAfterPasswordExpires);
                    
                    SQL_Parameter Par_LoginUsers_Administrator_AddUser_LoginUsers_id = new SQL_Parameter();
                    Par_LoginUsers_Administrator_AddUser_LoginUsers_id.dbType = System.Data.SqlDbType.Int;
                    Par_LoginUsers_Administrator_AddUser_LoginUsers_id.Name = "@Par_LoginUsers_Administrator_AddUser_LoginUsers_id";
                    Par_LoginUsers_Administrator_AddUser_LoginUsers_id.size = 4;
                    Par_LoginUsers_Administrator_AddUser_LoginUsers_id.IsOutputParameter = true;
                    ProcParams.Add(Par_LoginUsers_Administrator_AddUser_LoginUsers_id);
                    
                    SQL_Parameter Par_LoginUsers_Administrator_AddUser_Res = new SQL_Parameter();
                    Par_LoginUsers_Administrator_AddUser_Res.dbType = System.Data.SqlDbType.NVarChar;
                    Par_LoginUsers_Administrator_AddUser_Res.Name = "@Par_LoginUsers_Administrator_AddUser_Res";
                    Par_LoginUsers_Administrator_AddUser_Res.size = 2000;
                    Par_LoginUsers_Administrator_AddUser_Res.IsOutputParameter = true;
                    ProcParams.Add(Par_LoginUsers_Administrator_AddUser_Res);
                    
                      object Result = exec("LoginUsers_Administrator_AddUser",new string[] {"@username","@password","@enabled","@first_name","@last_name","@Identity","@Contact","@LoginUsers_id_Administrator_that_is_changing_password","@PasswordNeverExpires","@ChangePasswordOnFirstLogin","@Maximum_password_age_in_days","@NotActiveAfterPasswordExpires","@LoginUsers_id","@Res"},ref Err);
                      LoginUsers_id = (int) ProcParamValue("@Par_LoginUsers_Administrator_AddUser_LoginUsers_id");
Res = (string) ProcParamValue("@Par_LoginUsers_Administrator_AddUser_Res");

                      if (Result==null)
                      {
                         return 0;
                      }
                      else if (Result.GetType()==typeof(int))
                      {
                        return (int) Result;
                      }
                      else 
                      {
                        return -1;
                      }
                    }
                
                    public const string LoginUsers_Administrator_DeleteUser_const = "LoginUsers_Administrator_DeleteUser";

                    public int LoginUsers_Administrator_DeleteUser(int LoginUsers_id,int LoginUsers_id_Administrator_that_is_changing_password, ref string Res, ref string Err)
                    {
                      
                    ProcParams.Clear();
                    SQL_Parameter Ret_code_CopyRight_Logina_AuthorDamjanStrucl = new SQL_Parameter();
                    Ret_code_CopyRight_Logina_AuthorDamjanStrucl.dbType = System.Data.SqlDbType.Int;
                    Ret_code_CopyRight_Logina_AuthorDamjanStrucl.Name = "@Ret_code_CopyRight_Logina_AuthorDamjanStrucl";
                    Ret_code_CopyRight_Logina_AuthorDamjanStrucl.size = 4;
                    Ret_code_CopyRight_Logina_AuthorDamjanStrucl.IsOutputParameter = true;
                    ProcParams.Add(Ret_code_CopyRight_Logina_AuthorDamjanStrucl);
                    
                    SQL_Parameter Par_LoginUsers_Administrator_DeleteUser_LoginUsers_id = new SQL_Parameter();
                    Par_LoginUsers_Administrator_DeleteUser_LoginUsers_id.dbType = System.Data.SqlDbType.Int;
                    Par_LoginUsers_Administrator_DeleteUser_LoginUsers_id.Name = "@Par_LoginUsers_Administrator_DeleteUser_LoginUsers_id";
                    Par_LoginUsers_Administrator_DeleteUser_LoginUsers_id.size = 4;
                    Par_LoginUsers_Administrator_DeleteUser_LoginUsers_id.Value = LoginUsers_id;
                    Par_LoginUsers_Administrator_DeleteUser_LoginUsers_id.IsOutputParameter = false;
                    ProcParams.Add(Par_LoginUsers_Administrator_DeleteUser_LoginUsers_id);
                    
                    SQL_Parameter Par_LoginUsers_Administrator_DeleteUser_LoginUsers_id_Administrator_that_is_changing_password = new SQL_Parameter();
                    Par_LoginUsers_Administrator_DeleteUser_LoginUsers_id_Administrator_that_is_changing_password.dbType = System.Data.SqlDbType.Int;
                    Par_LoginUsers_Administrator_DeleteUser_LoginUsers_id_Administrator_that_is_changing_password.Name = "@Par_LoginUsers_Administrator_DeleteUser_LoginUsers_id_Administrator_that_is_changing_password";
                    Par_LoginUsers_Administrator_DeleteUser_LoginUsers_id_Administrator_that_is_changing_password.size = 4;
                    Par_LoginUsers_Administrator_DeleteUser_LoginUsers_id_Administrator_that_is_changing_password.Value = LoginUsers_id_Administrator_that_is_changing_password;
                    Par_LoginUsers_Administrator_DeleteUser_LoginUsers_id_Administrator_that_is_changing_password.IsOutputParameter = false;
                    ProcParams.Add(Par_LoginUsers_Administrator_DeleteUser_LoginUsers_id_Administrator_that_is_changing_password);
                    
                    SQL_Parameter Par_LoginUsers_Administrator_DeleteUser_Res = new SQL_Parameter();
                    Par_LoginUsers_Administrator_DeleteUser_Res.dbType = System.Data.SqlDbType.NVarChar;
                    Par_LoginUsers_Administrator_DeleteUser_Res.Name = "@Par_LoginUsers_Administrator_DeleteUser_Res";
                    Par_LoginUsers_Administrator_DeleteUser_Res.size = 2000;
                    Par_LoginUsers_Administrator_DeleteUser_Res.IsOutputParameter = true;
                    ProcParams.Add(Par_LoginUsers_Administrator_DeleteUser_Res);
                    
                      object Result = exec("LoginUsers_Administrator_DeleteUser",new string[] {"@LoginUsers_id","@LoginUsers_id_Administrator_that_is_changing_password","@Res"},ref Err);
                      Res = (string) ProcParamValue("@Par_LoginUsers_Administrator_DeleteUser_Res");

                      if (Result==null)
                      {
                         return 0;
                      }
                      else if (Result.GetType()==typeof(int))
                      {
                        return (int) Result;
                      }
                      else 
                      {
                        return -1;
                      }
                    }
                
                public LoginDB_DataSet_Procedures(DBConnectionControl40.DBConnection xcon)
                {
                        m_con = xcon;
        
                }
            }
        
}
