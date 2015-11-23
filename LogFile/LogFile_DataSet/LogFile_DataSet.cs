
using System;
using System.Data;
using System.Collections.Generic;
using System.Windows.Forms;
using LogFile;

namespace LogFile_DataSet
{

    public class Log:XTable
    {
        public const string tablename_const = "Log";
        public selection select;
        public WHERE where;

        public void Set_DataGridView_Headers(DataGridView dgv)
        {
            Log_lang m_Log_lang = new Log_lang();
            foreach (DataGridViewColumn dgvc in dgv.Columns)
            {
                foreach (ltext lt in m_Log_lang.col_headers)
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

        public bool Read(int Limit,ref string csError)
        {
          bool bRead = read(Limit, ref csError);
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

        public class LogFile_id:ValSet
           { 
             public const string name = "LogFile_id";

             public int LogFile_id_
             {
                get {return (int) obj;}
                set {obj = value;}
             }
           }
           public LogFile_id o_LogFile_id = new LogFile_id();

        public class LogTime:ValSet
           { 
             public const string name = "LogTime";

             public DateTime LogTime_
             {
                get {return (DateTime) obj;}
                set {obj = value;}
             }
           }
           public LogTime o_LogTime = new LogTime();

        public class Log_Type_id:ValSet
           { 
             public const string name = "Log_Type_id";

             public int Log_Type_id_
             {
                get {return (int) obj;}
                set {obj = value;}
             }
           }
           public Log_Type_id o_Log_Type_id = new Log_Type_id();

        public class Log_Description_id:ValSet
           { 
             public const string name = "Log_Description_id";

             public int Log_Description_id_
             {
                get {return (int) obj;}
                set {obj = value;}
             }
           }
           public Log_Description_id o_Log_Description_id = new Log_Description_id();

        public Log(Log_DBConnection xcon)
           {
                select = new selection(this);
                where  = new WHERE(this);
                m_con = xcon;
                tablename = Log.tablename_const;
                myUpdateObjects = UpdateObjects;


                    o_id.col_name = Log.id.name;
                    o_id.col_type.m_Type = "int";
                    o_id.col_type.bPRIMARY_KEY = true;
                    o_id.col_type.bFOREIGN_KEY = false;
                    o_id.col_type.bUNIQUE = false;
                    o_id.col_type.bNULL = false;
                    Add(o_id);
                    
                    o_LogFile_id.col_name = Log.LogFile_id.name;
                    o_LogFile_id.col_type.m_Type = "int";
                    o_LogFile_id.col_type.bPRIMARY_KEY = false;
                    o_LogFile_id.col_type.bFOREIGN_KEY = true;
                    o_LogFile_id.col_type.bUNIQUE = false;
                    o_LogFile_id.col_type.bNULL = false;
                    Add(o_LogFile_id);
                    
                    o_LogTime.col_name = Log.LogTime.name;
                    o_LogTime.col_type.m_Type = "datetime";
                    o_LogTime.col_type.bPRIMARY_KEY = false;
                    o_LogTime.col_type.bFOREIGN_KEY = false;
                    o_LogTime.col_type.bUNIQUE = false;
                    o_LogTime.col_type.bNULL = false;
                    Add(o_LogTime);
                    
                    o_Log_Type_id.col_name = Log.Log_Type_id.name;
                    o_Log_Type_id.col_type.m_Type = "int";
                    o_Log_Type_id.col_type.bPRIMARY_KEY = false;
                    o_Log_Type_id.col_type.bFOREIGN_KEY = true;
                    o_Log_Type_id.col_type.bUNIQUE = false;
                    o_Log_Type_id.col_type.bNULL = false;
                    Add(o_Log_Type_id);
                    
                    o_Log_Description_id.col_name = Log.Log_Description_id.name;
                    o_Log_Description_id.col_type.m_Type = "int";
                    o_Log_Description_id.col_type.bPRIMARY_KEY = false;
                    o_Log_Description_id.col_type.bFOREIGN_KEY = true;
                    o_Log_Description_id.col_type.bUNIQUE = false;
                    o_Log_Description_id.col_type.bNULL = false;
                    Add(o_Log_Description_id);
                    
           }

        public class selection
           {
                private Log m_Log;
                public selection(Log xLog)
                {
                    m_Log =  xLog;
                }

                    public bool id
                    {
                        get {return m_Log.o_id.Select.enabled;}
                        set {m_Log.o_id.Select.enabled = value;}
                    }
                    
                    public void id_Expression(string Expression,string xalternate_column_name)
                    {
                        m_Log.o_id.Select.expression = Expression;
                        m_Log.o_id.Select.alternate_column_name = xalternate_column_name;
                    }
                    
                    public bool LogFile_id
                    {
                        get {return m_Log.o_LogFile_id.Select.enabled;}
                        set {m_Log.o_LogFile_id.Select.enabled = value;}
                    }
                    
                    public void LogFile_id_Expression(string Expression,string xalternate_column_name)
                    {
                        m_Log.o_LogFile_id.Select.expression = Expression;
                        m_Log.o_LogFile_id.Select.alternate_column_name = xalternate_column_name;
                    }
                    
                    public bool LogTime
                    {
                        get {return m_Log.o_LogTime.Select.enabled;}
                        set {m_Log.o_LogTime.Select.enabled = value;}
                    }
                    
                    public void LogTime_Expression(string Expression,string xalternate_column_name)
                    {
                        m_Log.o_LogTime.Select.expression = Expression;
                        m_Log.o_LogTime.Select.alternate_column_name = xalternate_column_name;
                    }
                    
                    public bool Log_Type_id
                    {
                        get {return m_Log.o_Log_Type_id.Select.enabled;}
                        set {m_Log.o_Log_Type_id.Select.enabled = value;}
                    }
                    
                    public void Log_Type_id_Expression(string Expression,string xalternate_column_name)
                    {
                        m_Log.o_Log_Type_id.Select.expression = Expression;
                        m_Log.o_Log_Type_id.Select.alternate_column_name = xalternate_column_name;
                    }
                    
                    public bool Log_Description_id
                    {
                        get {return m_Log.o_Log_Description_id.Select.enabled;}
                        set {m_Log.o_Log_Description_id.Select.enabled = value;}
                    }
                    
                    public void Log_Description_id_Expression(string Expression,string xalternate_column_name)
                    {
                        m_Log.o_Log_Description_id.Select.expression = Expression;
                        m_Log.o_Log_Description_id.Select.alternate_column_name = xalternate_column_name;
                    }
                    
               public void all(bool bVal)
               {

                    this.id = bVal;
                    
                    this.LogFile_id = bVal;
                    
                    this.LogTime = bVal;
                    
                    this.Log_Type_id = bVal;
                    
                    this.Log_Description_id = bVal;
                    
               }
    
           }

        public class WHERE
           {
                private Log m_Log;
                public WHERE(Log xLog)
                {
                    m_Log =  xLog;
                }

                    public bool id
                    {
                        get {return m_Log.o_id.Where.enabled;}
                        set {m_Log.o_id.Where.enabled = value;}
                    }
                    
                    public void id_Expression(string Expression)
                    {
                        m_Log.o_id.Where.expression = Expression;
                    }
                    

                    public void id_AddParameter(Log_SQL_Parameter par)
                    {
                        m_Log.o_id.Where.AddParameter(par);
                    }
                    
                    public bool LogFile_id
                    {
                        get {return m_Log.o_LogFile_id.Where.enabled;}
                        set {m_Log.o_LogFile_id.Where.enabled = value;}
                    }
                    
                    public void LogFile_id_Expression(string Expression)
                    {
                        m_Log.o_LogFile_id.Where.expression = Expression;
                    }
                    

                    public void LogFile_id_AddParameter(Log_SQL_Parameter par)
                    {
                        m_Log.o_LogFile_id.Where.AddParameter(par);
                    }
                    
                    public bool LogTime
                    {
                        get {return m_Log.o_LogTime.Where.enabled;}
                        set {m_Log.o_LogTime.Where.enabled = value;}
                    }
                    
                    public void LogTime_Expression(string Expression)
                    {
                        m_Log.o_LogTime.Where.expression = Expression;
                    }
                    

                    public void LogTime_AddParameter(Log_SQL_Parameter par)
                    {
                        m_Log.o_LogTime.Where.AddParameter(par);
                    }
                    
                    public bool Log_Type_id
                    {
                        get {return m_Log.o_Log_Type_id.Where.enabled;}
                        set {m_Log.o_Log_Type_id.Where.enabled = value;}
                    }
                    
                    public void Log_Type_id_Expression(string Expression)
                    {
                        m_Log.o_Log_Type_id.Where.expression = Expression;
                    }
                    

                    public void Log_Type_id_AddParameter(Log_SQL_Parameter par)
                    {
                        m_Log.o_Log_Type_id.Where.AddParameter(par);
                    }
                    
                    public bool Log_Description_id
                    {
                        get {return m_Log.o_Log_Description_id.Where.enabled;}
                        set {m_Log.o_Log_Description_id.Where.enabled = value;}
                    }
                    
                    public void Log_Description_id_Expression(string Expression)
                    {
                        m_Log.o_Log_Description_id.Where.expression = Expression;
                    }
                    

                    public void Log_Description_id_AddParameter(Log_SQL_Parameter par)
                    {
                        m_Log.o_Log_Description_id.Where.AddParameter(par);
                    }
                    
               public void all(bool bVal)
               {

                    this.id = bVal;
                    
                    this.LogFile_id = bVal;
                    
                    this.LogTime = bVal;
                    
                    this.Log_Type_id = bVal;
                    
                    this.Log_Description_id = bVal;
                    
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
                          if (dr[Log.id.name] != null)
                          {
                            if (dr[Log.id.name].GetType() != typeof(System.DBNull))
                            {
                            o_id.id_  = (int) dr[Log.id.name];
                            }
                          }
                        }

                    }
                    if (o_LogFile_id.Select.enabled)
                    {
                        if (o_LogFile_id.Select.IsExpression)
                        {
                          if (dr[o_LogFile_id.Select.alternate_column_name] != null)
                          {
                            if (dr[o_LogFile_id.Select.alternate_column_name].GetType() != typeof(System.DBNull))
                            {
                              o_LogFile_id.obj  = dr[o_LogFile_id.Select.alternate_column_name];
                            }
                          }
                        }
                        else
                        {
                          if (dr[Log.LogFile_id.name] != null)
                          {
                            if (dr[Log.LogFile_id.name].GetType() != typeof(System.DBNull))
                            {
                            o_LogFile_id.LogFile_id_  = (int) dr[Log.LogFile_id.name];
                            }
                          }
                        }

                    }
                    if (o_LogTime.Select.enabled)
                    {
                        if (o_LogTime.Select.IsExpression)
                        {
                          if (dr[o_LogTime.Select.alternate_column_name] != null)
                          {
                            if (dr[o_LogTime.Select.alternate_column_name].GetType() != typeof(System.DBNull))
                            {
                              o_LogTime.obj  = dr[o_LogTime.Select.alternate_column_name];
                            }
                          }
                        }
                        else
                        {
                          if (dr[Log.LogTime.name] != null)
                          {
                            if (dr[Log.LogTime.name].GetType() != typeof(System.DBNull))
                            {
                            o_LogTime.LogTime_  = (DateTime) dr[Log.LogTime.name];
                            }
                          }
                        }

                    }
                    if (o_Log_Type_id.Select.enabled)
                    {
                        if (o_Log_Type_id.Select.IsExpression)
                        {
                          if (dr[o_Log_Type_id.Select.alternate_column_name] != null)
                          {
                            if (dr[o_Log_Type_id.Select.alternate_column_name].GetType() != typeof(System.DBNull))
                            {
                              o_Log_Type_id.obj  = dr[o_Log_Type_id.Select.alternate_column_name];
                            }
                          }
                        }
                        else
                        {
                          if (dr[Log.Log_Type_id.name] != null)
                          {
                            if (dr[Log.Log_Type_id.name].GetType() != typeof(System.DBNull))
                            {
                            o_Log_Type_id.Log_Type_id_  = (int) dr[Log.Log_Type_id.name];
                            }
                          }
                        }

                    }
                    if (o_Log_Description_id.Select.enabled)
                    {
                        if (o_Log_Description_id.Select.IsExpression)
                        {
                          if (dr[o_Log_Description_id.Select.alternate_column_name] != null)
                          {
                            if (dr[o_Log_Description_id.Select.alternate_column_name].GetType() != typeof(System.DBNull))
                            {
                              o_Log_Description_id.obj  = dr[o_Log_Description_id.Select.alternate_column_name];
                            }
                          }
                        }
                        else
                        {
                          if (dr[Log.Log_Description_id.name] != null)
                          {
                            if (dr[Log.Log_Description_id.name].GetType() != typeof(System.DBNull))
                            {
                            o_Log_Description_id.Log_Description_id_  = (int) dr[Log.Log_Description_id.name];
                            }
                          }
                        }

                    }
           }

    }
    public class Log_Computer:XTable
    {
        public const string tablename_const = "Log_Computer";
        public selection select;
        public WHERE where;

        public void Set_DataGridView_Headers(DataGridView dgv)
        {
            Log_Computer_lang m_Log_Computer_lang = new Log_Computer_lang();
            foreach (DataGridViewColumn dgvc in dgv.Columns)
            {
                foreach (ltext lt in m_Log_Computer_lang.col_headers)
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

        public bool Read(int Limit,ref string csError)
        {
          bool bRead = read(Limit, ref csError);
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

        public Log_Computer(Log_DBConnection xcon)
           {
                select = new selection(this);
                where  = new WHERE(this);
                m_con = xcon;
                tablename = Log_Computer.tablename_const;
                myUpdateObjects = UpdateObjects;


                    o_id.col_name = Log_Computer.id.name;
                    o_id.col_type.m_Type = "int";
                    o_id.col_type.bPRIMARY_KEY = true;
                    o_id.col_type.bFOREIGN_KEY = false;
                    o_id.col_type.bUNIQUE = false;
                    o_id.col_type.bNULL = false;
                    Add(o_id);
                    
                    o_ComputerName.col_name = Log_Computer.ComputerName.name;
                    o_ComputerName.col_type.m_Type = "nvarchar";
                    o_ComputerName.col_type.bPRIMARY_KEY = false;
                    o_ComputerName.col_type.bFOREIGN_KEY = false;
                    o_ComputerName.col_type.bUNIQUE = false;
                    o_ComputerName.col_type.bNULL = false;
                    Add(o_ComputerName);
                    
           }

        public class selection
           {
                private Log_Computer m_Log_Computer;
                public selection(Log_Computer xLog_Computer)
                {
                    m_Log_Computer =  xLog_Computer;
                }

                    public bool id
                    {
                        get {return m_Log_Computer.o_id.Select.enabled;}
                        set {m_Log_Computer.o_id.Select.enabled = value;}
                    }
                    
                    public void id_Expression(string Expression,string xalternate_column_name)
                    {
                        m_Log_Computer.o_id.Select.expression = Expression;
                        m_Log_Computer.o_id.Select.alternate_column_name = xalternate_column_name;
                    }
                    
                    public bool ComputerName
                    {
                        get {return m_Log_Computer.o_ComputerName.Select.enabled;}
                        set {m_Log_Computer.o_ComputerName.Select.enabled = value;}
                    }
                    
                    public void ComputerName_Expression(string Expression,string xalternate_column_name)
                    {
                        m_Log_Computer.o_ComputerName.Select.expression = Expression;
                        m_Log_Computer.o_ComputerName.Select.alternate_column_name = xalternate_column_name;
                    }
                    
               public void all(bool bVal)
               {

                    this.id = bVal;
                    
                    this.ComputerName = bVal;
                    
               }
    
           }

        public class WHERE
           {
                private Log_Computer m_Log_Computer;
                public WHERE(Log_Computer xLog_Computer)
                {
                    m_Log_Computer =  xLog_Computer;
                }

                    public bool id
                    {
                        get {return m_Log_Computer.o_id.Where.enabled;}
                        set {m_Log_Computer.o_id.Where.enabled = value;}
                    }
                    
                    public void id_Expression(string Expression)
                    {
                        m_Log_Computer.o_id.Where.expression = Expression;
                    }
                    

                    public void id_AddParameter(Log_SQL_Parameter par)
                    {
                        m_Log_Computer.o_id.Where.AddParameter(par);
                    }
                    
                    public bool ComputerName
                    {
                        get {return m_Log_Computer.o_ComputerName.Where.enabled;}
                        set {m_Log_Computer.o_ComputerName.Where.enabled = value;}
                    }
                    
                    public void ComputerName_Expression(string Expression)
                    {
                        m_Log_Computer.o_ComputerName.Where.expression = Expression;
                    }
                    

                    public void ComputerName_AddParameter(Log_SQL_Parameter par)
                    {
                        m_Log_Computer.o_ComputerName.Where.AddParameter(par);
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
                          if (dr[Log_Computer.id.name] != null)
                          {
                            if (dr[Log_Computer.id.name].GetType() != typeof(System.DBNull))
                            {
                            o_id.id_  = (int) dr[Log_Computer.id.name];
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
                          if (dr[Log_Computer.ComputerName.name] != null)
                          {
                            if (dr[Log_Computer.ComputerName.name].GetType() != typeof(System.DBNull))
                            {
                            o_ComputerName.ComputerName_  = (string) dr[Log_Computer.ComputerName.name];
                            }
                          }
                        }

                    }
           }

    }
    public class Log_Description:XTable
    {
        public const string tablename_const = "Log_Description";
        public selection select;
        public WHERE where;

        public void Set_DataGridView_Headers(DataGridView dgv)
        {
            Log_Description_lang m_Log_Description_lang = new Log_Description_lang();
            foreach (DataGridViewColumn dgvc in dgv.Columns)
            {
                foreach (ltext lt in m_Log_Description_lang.col_headers)
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

        public bool Read(int Limit,ref string csError)
        {
          bool bRead = read(Limit, ref csError);
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

        public class Description:ValSet
           { 
             public const string name = "Description";

             public string Description_
             {
                get {return (string) obj;}
                set {obj = value;}
             }
           }
           public Description o_Description = new Description();

        public Log_Description(Log_DBConnection xcon)
           {
                select = new selection(this);
                where  = new WHERE(this);
                m_con = xcon;
                tablename = Log_Description.tablename_const;
                myUpdateObjects = UpdateObjects;


                    o_id.col_name = Log_Description.id.name;
                    o_id.col_type.m_Type = "int";
                    o_id.col_type.bPRIMARY_KEY = true;
                    o_id.col_type.bFOREIGN_KEY = false;
                    o_id.col_type.bUNIQUE = false;
                    o_id.col_type.bNULL = false;
                    Add(o_id);
                    
                    o_Description.col_name = Log_Description.Description.name;
                    o_Description.col_type.m_Type = "nvarchar";
                    o_Description.col_type.bPRIMARY_KEY = false;
                    o_Description.col_type.bFOREIGN_KEY = false;
                    o_Description.col_type.bUNIQUE = false;
                    o_Description.col_type.bNULL = false;
                    Add(o_Description);
                    
           }

        public class selection
           {
                private Log_Description m_Log_Description;
                public selection(Log_Description xLog_Description)
                {
                    m_Log_Description =  xLog_Description;
                }

                    public bool id
                    {
                        get {return m_Log_Description.o_id.Select.enabled;}
                        set {m_Log_Description.o_id.Select.enabled = value;}
                    }
                    
                    public void id_Expression(string Expression,string xalternate_column_name)
                    {
                        m_Log_Description.o_id.Select.expression = Expression;
                        m_Log_Description.o_id.Select.alternate_column_name = xalternate_column_name;
                    }
                    
                    public bool Description
                    {
                        get {return m_Log_Description.o_Description.Select.enabled;}
                        set {m_Log_Description.o_Description.Select.enabled = value;}
                    }
                    
                    public void Description_Expression(string Expression,string xalternate_column_name)
                    {
                        m_Log_Description.o_Description.Select.expression = Expression;
                        m_Log_Description.o_Description.Select.alternate_column_name = xalternate_column_name;
                    }
                    
               public void all(bool bVal)
               {

                    this.id = bVal;
                    
                    this.Description = bVal;
                    
               }
    
           }

        public class WHERE
           {
                private Log_Description m_Log_Description;
                public WHERE(Log_Description xLog_Description)
                {
                    m_Log_Description =  xLog_Description;
                }

                    public bool id
                    {
                        get {return m_Log_Description.o_id.Where.enabled;}
                        set {m_Log_Description.o_id.Where.enabled = value;}
                    }
                    
                    public void id_Expression(string Expression)
                    {
                        m_Log_Description.o_id.Where.expression = Expression;
                    }
                    

                    public void id_AddParameter(Log_SQL_Parameter par)
                    {
                        m_Log_Description.o_id.Where.AddParameter(par);
                    }
                    
                    public bool Description
                    {
                        get {return m_Log_Description.o_Description.Where.enabled;}
                        set {m_Log_Description.o_Description.Where.enabled = value;}
                    }
                    
                    public void Description_Expression(string Expression)
                    {
                        m_Log_Description.o_Description.Where.expression = Expression;
                    }
                    

                    public void Description_AddParameter(Log_SQL_Parameter par)
                    {
                        m_Log_Description.o_Description.Where.AddParameter(par);
                    }
                    
               public void all(bool bVal)
               {

                    this.id = bVal;
                    
                    this.Description = bVal;
                    
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
                          if (dr[Log_Description.id.name] != null)
                          {
                            if (dr[Log_Description.id.name].GetType() != typeof(System.DBNull))
                            {
                            o_id.id_  = (int) dr[Log_Description.id.name];
                            }
                          }
                        }

                    }
                    if (o_Description.Select.enabled)
                    {
                        if (o_Description.Select.IsExpression)
                        {
                          if (dr[o_Description.Select.alternate_column_name] != null)
                          {
                            if (dr[o_Description.Select.alternate_column_name].GetType() != typeof(System.DBNull))
                            {
                              o_Description.obj  = dr[o_Description.Select.alternate_column_name];
                            }
                          }
                        }
                        else
                        {
                          if (dr[Log_Description.Description.name] != null)
                          {
                            if (dr[Log_Description.Description.name].GetType() != typeof(System.DBNull))
                            {
                            o_Description.Description_  = (string) dr[Log_Description.Description.name];
                            }
                          }
                        }

                    }
           }

    }
    public class Log_PathFile:XTable
    {
        public const string tablename_const = "Log_PathFile";
        public selection select;
        public WHERE where;

        public void Set_DataGridView_Headers(DataGridView dgv)
        {
            Log_PathFile_lang m_Log_PathFile_lang = new Log_PathFile_lang();
            foreach (DataGridViewColumn dgvc in dgv.Columns)
            {
                foreach (ltext lt in m_Log_PathFile_lang.col_headers)
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

        public bool Read(int Limit,ref string csError)
        {
          bool bRead = read(Limit, ref csError);
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

        public class PathFile:ValSet
           { 
             public const string name = "PathFile";

             public string PathFile_
             {
                get {return (string) obj;}
                set {obj = value;}
             }
           }
           public PathFile o_PathFile = new PathFile();

        public Log_PathFile(Log_DBConnection xcon)
           {
                select = new selection(this);
                where  = new WHERE(this);
                m_con = xcon;
                tablename = Log_PathFile.tablename_const;
                myUpdateObjects = UpdateObjects;


                    o_id.col_name = Log_PathFile.id.name;
                    o_id.col_type.m_Type = "int";
                    o_id.col_type.bPRIMARY_KEY = true;
                    o_id.col_type.bFOREIGN_KEY = false;
                    o_id.col_type.bUNIQUE = false;
                    o_id.col_type.bNULL = false;
                    Add(o_id);
                    
                    o_PathFile.col_name = Log_PathFile.PathFile.name;
                    o_PathFile.col_type.m_Type = "nvarchar";
                    o_PathFile.col_type.bPRIMARY_KEY = false;
                    o_PathFile.col_type.bFOREIGN_KEY = false;
                    o_PathFile.col_type.bUNIQUE = false;
                    o_PathFile.col_type.bNULL = false;
                    Add(o_PathFile);
                    
           }

        public class selection
           {
                private Log_PathFile m_Log_PathFile;
                public selection(Log_PathFile xLog_PathFile)
                {
                    m_Log_PathFile =  xLog_PathFile;
                }

                    public bool id
                    {
                        get {return m_Log_PathFile.o_id.Select.enabled;}
                        set {m_Log_PathFile.o_id.Select.enabled = value;}
                    }
                    
                    public void id_Expression(string Expression,string xalternate_column_name)
                    {
                        m_Log_PathFile.o_id.Select.expression = Expression;
                        m_Log_PathFile.o_id.Select.alternate_column_name = xalternate_column_name;
                    }
                    
                    public bool PathFile
                    {
                        get {return m_Log_PathFile.o_PathFile.Select.enabled;}
                        set {m_Log_PathFile.o_PathFile.Select.enabled = value;}
                    }
                    
                    public void PathFile_Expression(string Expression,string xalternate_column_name)
                    {
                        m_Log_PathFile.o_PathFile.Select.expression = Expression;
                        m_Log_PathFile.o_PathFile.Select.alternate_column_name = xalternate_column_name;
                    }
                    
               public void all(bool bVal)
               {

                    this.id = bVal;
                    
                    this.PathFile = bVal;
                    
               }
    
           }

        public class WHERE
           {
                private Log_PathFile m_Log_PathFile;
                public WHERE(Log_PathFile xLog_PathFile)
                {
                    m_Log_PathFile =  xLog_PathFile;
                }

                    public bool id
                    {
                        get {return m_Log_PathFile.o_id.Where.enabled;}
                        set {m_Log_PathFile.o_id.Where.enabled = value;}
                    }
                    
                    public void id_Expression(string Expression)
                    {
                        m_Log_PathFile.o_id.Where.expression = Expression;
                    }
                    

                    public void id_AddParameter(Log_SQL_Parameter par)
                    {
                        m_Log_PathFile.o_id.Where.AddParameter(par);
                    }
                    
                    public bool PathFile
                    {
                        get {return m_Log_PathFile.o_PathFile.Where.enabled;}
                        set {m_Log_PathFile.o_PathFile.Where.enabled = value;}
                    }
                    
                    public void PathFile_Expression(string Expression)
                    {
                        m_Log_PathFile.o_PathFile.Where.expression = Expression;
                    }
                    

                    public void PathFile_AddParameter(Log_SQL_Parameter par)
                    {
                        m_Log_PathFile.o_PathFile.Where.AddParameter(par);
                    }
                    
               public void all(bool bVal)
               {

                    this.id = bVal;
                    
                    this.PathFile = bVal;
                    
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
                          if (dr[Log_PathFile.id.name] != null)
                          {
                            if (dr[Log_PathFile.id.name].GetType() != typeof(System.DBNull))
                            {
                            o_id.id_  = (int) dr[Log_PathFile.id.name];
                            }
                          }
                        }

                    }
                    if (o_PathFile.Select.enabled)
                    {
                        if (o_PathFile.Select.IsExpression)
                        {
                          if (dr[o_PathFile.Select.alternate_column_name] != null)
                          {
                            if (dr[o_PathFile.Select.alternate_column_name].GetType() != typeof(System.DBNull))
                            {
                              o_PathFile.obj  = dr[o_PathFile.Select.alternate_column_name];
                            }
                          }
                        }
                        else
                        {
                          if (dr[Log_PathFile.PathFile.name] != null)
                          {
                            if (dr[Log_PathFile.PathFile.name].GetType() != typeof(System.DBNull))
                            {
                            o_PathFile.PathFile_  = (string) dr[Log_PathFile.PathFile.name];
                            }
                          }
                        }

                    }
           }

    }
    public class Log_Program:XTable
    {
        public const string tablename_const = "Log_Program";
        public selection select;
        public WHERE where;

        public void Set_DataGridView_Headers(DataGridView dgv)
        {
            Log_Program_lang m_Log_Program_lang = new Log_Program_lang();
            foreach (DataGridViewColumn dgvc in dgv.Columns)
            {
                foreach (ltext lt in m_Log_Program_lang.col_headers)
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

        public bool Read(int Limit,ref string csError)
        {
          bool bRead = read(Limit, ref csError);
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

        public class Program:ValSet
           { 
             public const string name = "Program";

             public string Program_
             {
                get {return (string) obj;}
                set {obj = value;}
             }
           }
           public Program o_Program = new Program();

        public Log_Program(Log_DBConnection xcon)
           {
                select = new selection(this);
                where  = new WHERE(this);
                m_con = xcon;
                tablename = Log_Program.tablename_const;
                myUpdateObjects = UpdateObjects;


                    o_id.col_name = Log_Program.id.name;
                    o_id.col_type.m_Type = "int";
                    o_id.col_type.bPRIMARY_KEY = true;
                    o_id.col_type.bFOREIGN_KEY = false;
                    o_id.col_type.bUNIQUE = false;
                    o_id.col_type.bNULL = false;
                    Add(o_id);
                    
                    o_Program.col_name = Log_Program.Program.name;
                    o_Program.col_type.m_Type = "nvarchar";
                    o_Program.col_type.bPRIMARY_KEY = false;
                    o_Program.col_type.bFOREIGN_KEY = false;
                    o_Program.col_type.bUNIQUE = false;
                    o_Program.col_type.bNULL = false;
                    Add(o_Program);
                    
           }

        public class selection
           {
                private Log_Program m_Log_Program;
                public selection(Log_Program xLog_Program)
                {
                    m_Log_Program =  xLog_Program;
                }

                    public bool id
                    {
                        get {return m_Log_Program.o_id.Select.enabled;}
                        set {m_Log_Program.o_id.Select.enabled = value;}
                    }
                    
                    public void id_Expression(string Expression,string xalternate_column_name)
                    {
                        m_Log_Program.o_id.Select.expression = Expression;
                        m_Log_Program.o_id.Select.alternate_column_name = xalternate_column_name;
                    }
                    
                    public bool Program
                    {
                        get {return m_Log_Program.o_Program.Select.enabled;}
                        set {m_Log_Program.o_Program.Select.enabled = value;}
                    }
                    
                    public void Program_Expression(string Expression,string xalternate_column_name)
                    {
                        m_Log_Program.o_Program.Select.expression = Expression;
                        m_Log_Program.o_Program.Select.alternate_column_name = xalternate_column_name;
                    }
                    
               public void all(bool bVal)
               {

                    this.id = bVal;
                    
                    this.Program = bVal;
                    
               }
    
           }

        public class WHERE
           {
                private Log_Program m_Log_Program;
                public WHERE(Log_Program xLog_Program)
                {
                    m_Log_Program =  xLog_Program;
                }

                    public bool id
                    {
                        get {return m_Log_Program.o_id.Where.enabled;}
                        set {m_Log_Program.o_id.Where.enabled = value;}
                    }
                    
                    public void id_Expression(string Expression)
                    {
                        m_Log_Program.o_id.Where.expression = Expression;
                    }
                    

                    public void id_AddParameter(Log_SQL_Parameter par)
                    {
                        m_Log_Program.o_id.Where.AddParameter(par);
                    }
                    
                    public bool Program
                    {
                        get {return m_Log_Program.o_Program.Where.enabled;}
                        set {m_Log_Program.o_Program.Where.enabled = value;}
                    }
                    
                    public void Program_Expression(string Expression)
                    {
                        m_Log_Program.o_Program.Where.expression = Expression;
                    }
                    

                    public void Program_AddParameter(Log_SQL_Parameter par)
                    {
                        m_Log_Program.o_Program.Where.AddParameter(par);
                    }
                    
               public void all(bool bVal)
               {

                    this.id = bVal;
                    
                    this.Program = bVal;
                    
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
                          if (dr[Log_Program.id.name] != null)
                          {
                            if (dr[Log_Program.id.name].GetType() != typeof(System.DBNull))
                            {
                            o_id.id_  = (int) dr[Log_Program.id.name];
                            }
                          }
                        }

                    }
                    if (o_Program.Select.enabled)
                    {
                        if (o_Program.Select.IsExpression)
                        {
                          if (dr[o_Program.Select.alternate_column_name] != null)
                          {
                            if (dr[o_Program.Select.alternate_column_name].GetType() != typeof(System.DBNull))
                            {
                              o_Program.obj  = dr[o_Program.Select.alternate_column_name];
                            }
                          }
                        }
                        else
                        {
                          if (dr[Log_Program.Program.name] != null)
                          {
                            if (dr[Log_Program.Program.name].GetType() != typeof(System.DBNull))
                            {
                            o_Program.Program_  = (string) dr[Log_Program.Program.name];
                            }
                          }
                        }

                    }
           }

    }
    public class Log_Type:XTable
    {
        public const string tablename_const = "Log_Type";
        public selection select;
        public WHERE where;

        public void Set_DataGridView_Headers(DataGridView dgv)
        {
            Log_Type_lang m_Log_Type_lang = new Log_Type_lang();
            foreach (DataGridViewColumn dgvc in dgv.Columns)
            {
                foreach (ltext lt in m_Log_Type_lang.col_headers)
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

        public bool Read(int Limit,ref string csError)
        {
          bool bRead = read(Limit, ref csError);
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

        public class TypeName:ValSet
           { 
             public const string name = "TypeName";

             public string TypeName_
             {
                get {return (string) obj;}
                set {obj = value;}
             }
           }
           public TypeName o_TypeName = new TypeName();

        public Log_Type(Log_DBConnection xcon)
           {
                select = new selection(this);
                where  = new WHERE(this);
                m_con = xcon;
                tablename = Log_Type.tablename_const;
                myUpdateObjects = UpdateObjects;


                    o_id.col_name = Log_Type.id.name;
                    o_id.col_type.m_Type = "int";
                    o_id.col_type.bPRIMARY_KEY = true;
                    o_id.col_type.bFOREIGN_KEY = false;
                    o_id.col_type.bUNIQUE = false;
                    o_id.col_type.bNULL = false;
                    Add(o_id);
                    
                    o_TypeName.col_name = Log_Type.TypeName.name;
                    o_TypeName.col_type.m_Type = "nvarchar";
                    o_TypeName.col_type.bPRIMARY_KEY = false;
                    o_TypeName.col_type.bFOREIGN_KEY = false;
                    o_TypeName.col_type.bUNIQUE = false;
                    o_TypeName.col_type.bNULL = false;
                    Add(o_TypeName);
                    
           }

        public class selection
           {
                private Log_Type m_Log_Type;
                public selection(Log_Type xLog_Type)
                {
                    m_Log_Type =  xLog_Type;
                }

                    public bool id
                    {
                        get {return m_Log_Type.o_id.Select.enabled;}
                        set {m_Log_Type.o_id.Select.enabled = value;}
                    }
                    
                    public void id_Expression(string Expression,string xalternate_column_name)
                    {
                        m_Log_Type.o_id.Select.expression = Expression;
                        m_Log_Type.o_id.Select.alternate_column_name = xalternate_column_name;
                    }
                    
                    public bool TypeName
                    {
                        get {return m_Log_Type.o_TypeName.Select.enabled;}
                        set {m_Log_Type.o_TypeName.Select.enabled = value;}
                    }
                    
                    public void TypeName_Expression(string Expression,string xalternate_column_name)
                    {
                        m_Log_Type.o_TypeName.Select.expression = Expression;
                        m_Log_Type.o_TypeName.Select.alternate_column_name = xalternate_column_name;
                    }
                    
               public void all(bool bVal)
               {

                    this.id = bVal;
                    
                    this.TypeName = bVal;
                    
               }
    
           }

        public class WHERE
           {
                private Log_Type m_Log_Type;
                public WHERE(Log_Type xLog_Type)
                {
                    m_Log_Type =  xLog_Type;
                }

                    public bool id
                    {
                        get {return m_Log_Type.o_id.Where.enabled;}
                        set {m_Log_Type.o_id.Where.enabled = value;}
                    }
                    
                    public void id_Expression(string Expression)
                    {
                        m_Log_Type.o_id.Where.expression = Expression;
                    }
                    

                    public void id_AddParameter(Log_SQL_Parameter par)
                    {
                        m_Log_Type.o_id.Where.AddParameter(par);
                    }
                    
                    public bool TypeName
                    {
                        get {return m_Log_Type.o_TypeName.Where.enabled;}
                        set {m_Log_Type.o_TypeName.Where.enabled = value;}
                    }
                    
                    public void TypeName_Expression(string Expression)
                    {
                        m_Log_Type.o_TypeName.Where.expression = Expression;
                    }
                    

                    public void TypeName_AddParameter(Log_SQL_Parameter par)
                    {
                        m_Log_Type.o_TypeName.Where.AddParameter(par);
                    }
                    
               public void all(bool bVal)
               {

                    this.id = bVal;
                    
                    this.TypeName = bVal;
                    
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
                          if (dr[Log_Type.id.name] != null)
                          {
                            if (dr[Log_Type.id.name].GetType() != typeof(System.DBNull))
                            {
                            o_id.id_  = (int) dr[Log_Type.id.name];
                            }
                          }
                        }

                    }
                    if (o_TypeName.Select.enabled)
                    {
                        if (o_TypeName.Select.IsExpression)
                        {
                          if (dr[o_TypeName.Select.alternate_column_name] != null)
                          {
                            if (dr[o_TypeName.Select.alternate_column_name].GetType() != typeof(System.DBNull))
                            {
                              o_TypeName.obj  = dr[o_TypeName.Select.alternate_column_name];
                            }
                          }
                        }
                        else
                        {
                          if (dr[Log_Type.TypeName.name] != null)
                          {
                            if (dr[Log_Type.TypeName.name].GetType() != typeof(System.DBNull))
                            {
                            o_TypeName.TypeName_  = (string) dr[Log_Type.TypeName.name];
                            }
                          }
                        }

                    }
           }

    }
    public class Log_UserName:XTable
    {
        public const string tablename_const = "Log_UserName";
        public selection select;
        public WHERE where;

        public void Set_DataGridView_Headers(DataGridView dgv)
        {
            Log_UserName_lang m_Log_UserName_lang = new Log_UserName_lang();
            foreach (DataGridViewColumn dgvc in dgv.Columns)
            {
                foreach (ltext lt in m_Log_UserName_lang.col_headers)
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

        public bool Read(int Limit,ref string csError)
        {
          bool bRead = read(Limit, ref csError);
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

        public class UserName:ValSet
           { 
             public const string name = "UserName";

             public string UserName_
             {
                get {return (string) obj;}
                set {obj = value;}
             }
           }
           public UserName o_UserName = new UserName();

        public Log_UserName(Log_DBConnection xcon)
           {
                select = new selection(this);
                where  = new WHERE(this);
                m_con = xcon;
                tablename = Log_UserName.tablename_const;
                myUpdateObjects = UpdateObjects;


                    o_id.col_name = Log_UserName.id.name;
                    o_id.col_type.m_Type = "int";
                    o_id.col_type.bPRIMARY_KEY = true;
                    o_id.col_type.bFOREIGN_KEY = false;
                    o_id.col_type.bUNIQUE = false;
                    o_id.col_type.bNULL = false;
                    Add(o_id);
                    
                    o_UserName.col_name = Log_UserName.UserName.name;
                    o_UserName.col_type.m_Type = "nvarchar";
                    o_UserName.col_type.bPRIMARY_KEY = false;
                    o_UserName.col_type.bFOREIGN_KEY = false;
                    o_UserName.col_type.bUNIQUE = false;
                    o_UserName.col_type.bNULL = false;
                    Add(o_UserName);
                    
           }

        public class selection
           {
                private Log_UserName m_Log_UserName;
                public selection(Log_UserName xLog_UserName)
                {
                    m_Log_UserName =  xLog_UserName;
                }

                    public bool id
                    {
                        get {return m_Log_UserName.o_id.Select.enabled;}
                        set {m_Log_UserName.o_id.Select.enabled = value;}
                    }
                    
                    public void id_Expression(string Expression,string xalternate_column_name)
                    {
                        m_Log_UserName.o_id.Select.expression = Expression;
                        m_Log_UserName.o_id.Select.alternate_column_name = xalternate_column_name;
                    }
                    
                    public bool UserName
                    {
                        get {return m_Log_UserName.o_UserName.Select.enabled;}
                        set {m_Log_UserName.o_UserName.Select.enabled = value;}
                    }
                    
                    public void UserName_Expression(string Expression,string xalternate_column_name)
                    {
                        m_Log_UserName.o_UserName.Select.expression = Expression;
                        m_Log_UserName.o_UserName.Select.alternate_column_name = xalternate_column_name;
                    }
                    
               public void all(bool bVal)
               {

                    this.id = bVal;
                    
                    this.UserName = bVal;
                    
               }
    
           }

        public class WHERE
           {
                private Log_UserName m_Log_UserName;
                public WHERE(Log_UserName xLog_UserName)
                {
                    m_Log_UserName =  xLog_UserName;
                }

                    public bool id
                    {
                        get {return m_Log_UserName.o_id.Where.enabled;}
                        set {m_Log_UserName.o_id.Where.enabled = value;}
                    }
                    
                    public void id_Expression(string Expression)
                    {
                        m_Log_UserName.o_id.Where.expression = Expression;
                    }
                    

                    public void id_AddParameter(Log_SQL_Parameter par)
                    {
                        m_Log_UserName.o_id.Where.AddParameter(par);
                    }
                    
                    public bool UserName
                    {
                        get {return m_Log_UserName.o_UserName.Where.enabled;}
                        set {m_Log_UserName.o_UserName.Where.enabled = value;}
                    }
                    
                    public void UserName_Expression(string Expression)
                    {
                        m_Log_UserName.o_UserName.Where.expression = Expression;
                    }
                    

                    public void UserName_AddParameter(Log_SQL_Parameter par)
                    {
                        m_Log_UserName.o_UserName.Where.AddParameter(par);
                    }
                    
               public void all(bool bVal)
               {

                    this.id = bVal;
                    
                    this.UserName = bVal;
                    
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
                          if (dr[Log_UserName.id.name] != null)
                          {
                            if (dr[Log_UserName.id.name].GetType() != typeof(System.DBNull))
                            {
                            o_id.id_  = (int) dr[Log_UserName.id.name];
                            }
                          }
                        }

                    }
                    if (o_UserName.Select.enabled)
                    {
                        if (o_UserName.Select.IsExpression)
                        {
                          if (dr[o_UserName.Select.alternate_column_name] != null)
                          {
                            if (dr[o_UserName.Select.alternate_column_name].GetType() != typeof(System.DBNull))
                            {
                              o_UserName.obj  = dr[o_UserName.Select.alternate_column_name];
                            }
                          }
                        }
                        else
                        {
                          if (dr[Log_UserName.UserName.name] != null)
                          {
                            if (dr[Log_UserName.UserName.name].GetType() != typeof(System.DBNull))
                            {
                            o_UserName.UserName_  = (string) dr[Log_UserName.UserName.name];
                            }
                          }
                        }

                    }
           }

    }
    public class LogFile:XTable
    {
        public const string tablename_const = "LogFile";
        public selection select;
        public WHERE where;

        public void Set_DataGridView_Headers(DataGridView dgv)
        {
            LogFile_lang m_LogFile_lang = new LogFile_lang();
            foreach (DataGridViewColumn dgvc in dgv.Columns)
            {
                foreach (ltext lt in m_LogFile_lang.col_headers)
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

        public bool Read(int Limit,ref string csError)
        {
          bool bRead = read(Limit, ref csError);
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

        public class LogFileImportTime:ValSet
           { 
             public const string name = "LogFileImportTime";

             public DateTime LogFileImportTime_
             {
                get {return (DateTime) obj;}
                set {obj = value;}
             }
           }
           public LogFileImportTime o_LogFileImportTime = new LogFileImportTime();

        public class Log_Computer_id:ValSet
           { 
             public const string name = "Log_Computer_id";

             public int Log_Computer_id_
             {
                get {return (int) obj;}
                set {obj = value;}
             }
           }
           public Log_Computer_id o_Log_Computer_id = new Log_Computer_id();

        public class Log_UserName_id:ValSet
           { 
             public const string name = "Log_UserName_id";

             public int Log_UserName_id_
             {
                get {return (int) obj;}
                set {obj = value;}
             }
           }
           public Log_UserName_id o_Log_UserName_id = new Log_UserName_id();

        public class Log_Program_id:ValSet
           { 
             public const string name = "Log_Program_id";

             public int Log_Program_id_
             {
                get {return (int) obj;}
                set {obj = value;}
             }
           }
           public Log_Program_id o_Log_Program_id = new Log_Program_id();

        public class Log_PathFile_id:ValSet
           { 
             public const string name = "Log_PathFile_id";

             public int Log_PathFile_id_
             {
                get {return (int) obj;}
                set {obj = value;}
             }
           }
           public Log_PathFile_id o_Log_PathFile_id = new Log_PathFile_id();

        public class LogFile_Description_id:ValSet
           { 
             public const string name = "LogFile_Description_id";

             public int LogFile_Description_id_
             {
                get {return (int) obj;}
                set {obj = value;}
             }
           }
           public LogFile_Description_id o_LogFile_Description_id = new LogFile_Description_id();

        public LogFile(Log_DBConnection xcon)
           {
                select = new selection(this);
                where  = new WHERE(this);
                m_con = xcon;
                tablename = LogFile.tablename_const;
                myUpdateObjects = UpdateObjects;


                    o_id.col_name = LogFile.id.name;
                    o_id.col_type.m_Type = "int";
                    o_id.col_type.bPRIMARY_KEY = true;
                    o_id.col_type.bFOREIGN_KEY = false;
                    o_id.col_type.bUNIQUE = false;
                    o_id.col_type.bNULL = false;
                    Add(o_id);
                    
                    o_LogFileImportTime.col_name = LogFile.LogFileImportTime.name;
                    o_LogFileImportTime.col_type.m_Type = "datetime";
                    o_LogFileImportTime.col_type.bPRIMARY_KEY = false;
                    o_LogFileImportTime.col_type.bFOREIGN_KEY = false;
                    o_LogFileImportTime.col_type.bUNIQUE = false;
                    o_LogFileImportTime.col_type.bNULL = false;
                    Add(o_LogFileImportTime);
                    
                    o_Log_Computer_id.col_name = LogFile.Log_Computer_id.name;
                    o_Log_Computer_id.col_type.m_Type = "int";
                    o_Log_Computer_id.col_type.bPRIMARY_KEY = false;
                    o_Log_Computer_id.col_type.bFOREIGN_KEY = true;
                    o_Log_Computer_id.col_type.bUNIQUE = false;
                    o_Log_Computer_id.col_type.bNULL = false;
                    Add(o_Log_Computer_id);
                    
                    o_Log_UserName_id.col_name = LogFile.Log_UserName_id.name;
                    o_Log_UserName_id.col_type.m_Type = "int";
                    o_Log_UserName_id.col_type.bPRIMARY_KEY = false;
                    o_Log_UserName_id.col_type.bFOREIGN_KEY = true;
                    o_Log_UserName_id.col_type.bUNIQUE = false;
                    o_Log_UserName_id.col_type.bNULL = true;
                    Add(o_Log_UserName_id);
                    
                    o_Log_Program_id.col_name = LogFile.Log_Program_id.name;
                    o_Log_Program_id.col_type.m_Type = "int";
                    o_Log_Program_id.col_type.bPRIMARY_KEY = false;
                    o_Log_Program_id.col_type.bFOREIGN_KEY = true;
                    o_Log_Program_id.col_type.bUNIQUE = false;
                    o_Log_Program_id.col_type.bNULL = false;
                    Add(o_Log_Program_id);
                    
                    o_Log_PathFile_id.col_name = LogFile.Log_PathFile_id.name;
                    o_Log_PathFile_id.col_type.m_Type = "int";
                    o_Log_PathFile_id.col_type.bPRIMARY_KEY = false;
                    o_Log_PathFile_id.col_type.bFOREIGN_KEY = true;
                    o_Log_PathFile_id.col_type.bUNIQUE = false;
                    o_Log_PathFile_id.col_type.bNULL = false;
                    Add(o_Log_PathFile_id);
                    
                    o_LogFile_Description_id.col_name = LogFile.LogFile_Description_id.name;
                    o_LogFile_Description_id.col_type.m_Type = "int";
                    o_LogFile_Description_id.col_type.bPRIMARY_KEY = false;
                    o_LogFile_Description_id.col_type.bFOREIGN_KEY = true;
                    o_LogFile_Description_id.col_type.bUNIQUE = false;
                    o_LogFile_Description_id.col_type.bNULL = true;
                    Add(o_LogFile_Description_id);
                    
           }

        public class selection
           {
                private LogFile m_LogFile;
                public selection(LogFile xLogFile)
                {
                    m_LogFile =  xLogFile;
                }

                    public bool id
                    {
                        get {return m_LogFile.o_id.Select.enabled;}
                        set {m_LogFile.o_id.Select.enabled = value;}
                    }
                    
                    public void id_Expression(string Expression,string xalternate_column_name)
                    {
                        m_LogFile.o_id.Select.expression = Expression;
                        m_LogFile.o_id.Select.alternate_column_name = xalternate_column_name;
                    }
                    
                    public bool LogFileImportTime
                    {
                        get {return m_LogFile.o_LogFileImportTime.Select.enabled;}
                        set {m_LogFile.o_LogFileImportTime.Select.enabled = value;}
                    }
                    
                    public void LogFileImportTime_Expression(string Expression,string xalternate_column_name)
                    {
                        m_LogFile.o_LogFileImportTime.Select.expression = Expression;
                        m_LogFile.o_LogFileImportTime.Select.alternate_column_name = xalternate_column_name;
                    }
                    
                    public bool Log_Computer_id
                    {
                        get {return m_LogFile.o_Log_Computer_id.Select.enabled;}
                        set {m_LogFile.o_Log_Computer_id.Select.enabled = value;}
                    }
                    
                    public void Log_Computer_id_Expression(string Expression,string xalternate_column_name)
                    {
                        m_LogFile.o_Log_Computer_id.Select.expression = Expression;
                        m_LogFile.o_Log_Computer_id.Select.alternate_column_name = xalternate_column_name;
                    }
                    
                    public bool Log_UserName_id
                    {
                        get {return m_LogFile.o_Log_UserName_id.Select.enabled;}
                        set {m_LogFile.o_Log_UserName_id.Select.enabled = value;}
                    }
                    
                    public void Log_UserName_id_Expression(string Expression,string xalternate_column_name)
                    {
                        m_LogFile.o_Log_UserName_id.Select.expression = Expression;
                        m_LogFile.o_Log_UserName_id.Select.alternate_column_name = xalternate_column_name;
                    }
                    
                    public bool Log_Program_id
                    {
                        get {return m_LogFile.o_Log_Program_id.Select.enabled;}
                        set {m_LogFile.o_Log_Program_id.Select.enabled = value;}
                    }
                    
                    public void Log_Program_id_Expression(string Expression,string xalternate_column_name)
                    {
                        m_LogFile.o_Log_Program_id.Select.expression = Expression;
                        m_LogFile.o_Log_Program_id.Select.alternate_column_name = xalternate_column_name;
                    }
                    
                    public bool Log_PathFile_id
                    {
                        get {return m_LogFile.o_Log_PathFile_id.Select.enabled;}
                        set {m_LogFile.o_Log_PathFile_id.Select.enabled = value;}
                    }
                    
                    public void Log_PathFile_id_Expression(string Expression,string xalternate_column_name)
                    {
                        m_LogFile.o_Log_PathFile_id.Select.expression = Expression;
                        m_LogFile.o_Log_PathFile_id.Select.alternate_column_name = xalternate_column_name;
                    }
                    
                    public bool LogFile_Description_id
                    {
                        get {return m_LogFile.o_LogFile_Description_id.Select.enabled;}
                        set {m_LogFile.o_LogFile_Description_id.Select.enabled = value;}
                    }
                    
                    public void LogFile_Description_id_Expression(string Expression,string xalternate_column_name)
                    {
                        m_LogFile.o_LogFile_Description_id.Select.expression = Expression;
                        m_LogFile.o_LogFile_Description_id.Select.alternate_column_name = xalternate_column_name;
                    }
                    
               public void all(bool bVal)
               {

                    this.id = bVal;
                    
                    this.LogFileImportTime = bVal;
                    
                    this.Log_Computer_id = bVal;
                    
                    this.Log_UserName_id = bVal;
                    
                    this.Log_Program_id = bVal;
                    
                    this.Log_PathFile_id = bVal;
                    
                    this.LogFile_Description_id = bVal;
                    
               }
    
           }

        public class WHERE
           {
                private LogFile m_LogFile;
                public WHERE(LogFile xLogFile)
                {
                    m_LogFile =  xLogFile;
                }

                    public bool id
                    {
                        get {return m_LogFile.o_id.Where.enabled;}
                        set {m_LogFile.o_id.Where.enabled = value;}
                    }
                    
                    public void id_Expression(string Expression)
                    {
                        m_LogFile.o_id.Where.expression = Expression;
                    }
                    

                    public void id_AddParameter(Log_SQL_Parameter par)
                    {
                        m_LogFile.o_id.Where.AddParameter(par);
                    }
                    
                    public bool LogFileImportTime
                    {
                        get {return m_LogFile.o_LogFileImportTime.Where.enabled;}
                        set {m_LogFile.o_LogFileImportTime.Where.enabled = value;}
                    }
                    
                    public void LogFileImportTime_Expression(string Expression)
                    {
                        m_LogFile.o_LogFileImportTime.Where.expression = Expression;
                    }
                    

                    public void LogFileImportTime_AddParameter(Log_SQL_Parameter par)
                    {
                        m_LogFile.o_LogFileImportTime.Where.AddParameter(par);
                    }
                    
                    public bool Log_Computer_id
                    {
                        get {return m_LogFile.o_Log_Computer_id.Where.enabled;}
                        set {m_LogFile.o_Log_Computer_id.Where.enabled = value;}
                    }
                    
                    public void Log_Computer_id_Expression(string Expression)
                    {
                        m_LogFile.o_Log_Computer_id.Where.expression = Expression;
                    }
                    

                    public void Log_Computer_id_AddParameter(Log_SQL_Parameter par)
                    {
                        m_LogFile.o_Log_Computer_id.Where.AddParameter(par);
                    }
                    
                    public bool Log_UserName_id
                    {
                        get {return m_LogFile.o_Log_UserName_id.Where.enabled;}
                        set {m_LogFile.o_Log_UserName_id.Where.enabled = value;}
                    }
                    
                    public void Log_UserName_id_Expression(string Expression)
                    {
                        m_LogFile.o_Log_UserName_id.Where.expression = Expression;
                    }
                    

                    public void Log_UserName_id_AddParameter(Log_SQL_Parameter par)
                    {
                        m_LogFile.o_Log_UserName_id.Where.AddParameter(par);
                    }
                    
                    public bool Log_Program_id
                    {
                        get {return m_LogFile.o_Log_Program_id.Where.enabled;}
                        set {m_LogFile.o_Log_Program_id.Where.enabled = value;}
                    }
                    
                    public void Log_Program_id_Expression(string Expression)
                    {
                        m_LogFile.o_Log_Program_id.Where.expression = Expression;
                    }
                    

                    public void Log_Program_id_AddParameter(Log_SQL_Parameter par)
                    {
                        m_LogFile.o_Log_Program_id.Where.AddParameter(par);
                    }
                    
                    public bool Log_PathFile_id
                    {
                        get {return m_LogFile.o_Log_PathFile_id.Where.enabled;}
                        set {m_LogFile.o_Log_PathFile_id.Where.enabled = value;}
                    }
                    
                    public void Log_PathFile_id_Expression(string Expression)
                    {
                        m_LogFile.o_Log_PathFile_id.Where.expression = Expression;
                    }
                    

                    public void Log_PathFile_id_AddParameter(Log_SQL_Parameter par)
                    {
                        m_LogFile.o_Log_PathFile_id.Where.AddParameter(par);
                    }
                    
                    public bool LogFile_Description_id
                    {
                        get {return m_LogFile.o_LogFile_Description_id.Where.enabled;}
                        set {m_LogFile.o_LogFile_Description_id.Where.enabled = value;}
                    }
                    
                    public void LogFile_Description_id_Expression(string Expression)
                    {
                        m_LogFile.o_LogFile_Description_id.Where.expression = Expression;
                    }
                    

                    public void LogFile_Description_id_AddParameter(Log_SQL_Parameter par)
                    {
                        m_LogFile.o_LogFile_Description_id.Where.AddParameter(par);
                    }
                    
               public void all(bool bVal)
               {

                    this.id = bVal;
                    
                    this.LogFileImportTime = bVal;
                    
                    this.Log_Computer_id = bVal;
                    
                    this.Log_UserName_id = bVal;
                    
                    this.Log_Program_id = bVal;
                    
                    this.Log_PathFile_id = bVal;
                    
                    this.LogFile_Description_id = bVal;
                    
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
                          if (dr[LogFile.id.name] != null)
                          {
                            if (dr[LogFile.id.name].GetType() != typeof(System.DBNull))
                            {
                            o_id.id_  = (int) dr[LogFile.id.name];
                            }
                          }
                        }

                    }
                    if (o_LogFileImportTime.Select.enabled)
                    {
                        if (o_LogFileImportTime.Select.IsExpression)
                        {
                          if (dr[o_LogFileImportTime.Select.alternate_column_name] != null)
                          {
                            if (dr[o_LogFileImportTime.Select.alternate_column_name].GetType() != typeof(System.DBNull))
                            {
                              o_LogFileImportTime.obj  = dr[o_LogFileImportTime.Select.alternate_column_name];
                            }
                          }
                        }
                        else
                        {
                          if (dr[LogFile.LogFileImportTime.name] != null)
                          {
                            if (dr[LogFile.LogFileImportTime.name].GetType() != typeof(System.DBNull))
                            {
                            o_LogFileImportTime.LogFileImportTime_  = (DateTime) dr[LogFile.LogFileImportTime.name];
                            }
                          }
                        }

                    }
                    if (o_Log_Computer_id.Select.enabled)
                    {
                        if (o_Log_Computer_id.Select.IsExpression)
                        {
                          if (dr[o_Log_Computer_id.Select.alternate_column_name] != null)
                          {
                            if (dr[o_Log_Computer_id.Select.alternate_column_name].GetType() != typeof(System.DBNull))
                            {
                              o_Log_Computer_id.obj  = dr[o_Log_Computer_id.Select.alternate_column_name];
                            }
                          }
                        }
                        else
                        {
                          if (dr[LogFile.Log_Computer_id.name] != null)
                          {
                            if (dr[LogFile.Log_Computer_id.name].GetType() != typeof(System.DBNull))
                            {
                            o_Log_Computer_id.Log_Computer_id_  = (int) dr[LogFile.Log_Computer_id.name];
                            }
                          }
                        }

                    }
                    if (o_Log_UserName_id.Select.enabled)
                    {
                        if (o_Log_UserName_id.Select.IsExpression)
                        {
                          if (dr[o_Log_UserName_id.Select.alternate_column_name] != null)
                          {
                            if (dr[o_Log_UserName_id.Select.alternate_column_name].GetType() != typeof(System.DBNull))
                            {
                              o_Log_UserName_id.obj  = dr[o_Log_UserName_id.Select.alternate_column_name];
                            }
                          }
                        }
                        else
                        {
                          if (dr[LogFile.Log_UserName_id.name] != null)
                          {
                            if (dr[LogFile.Log_UserName_id.name].GetType() != typeof(System.DBNull))
                            {
                            o_Log_UserName_id.Log_UserName_id_  = (int) dr[LogFile.Log_UserName_id.name];
                            }
                          }
                        }

                    }
                    if (o_Log_Program_id.Select.enabled)
                    {
                        if (o_Log_Program_id.Select.IsExpression)
                        {
                          if (dr[o_Log_Program_id.Select.alternate_column_name] != null)
                          {
                            if (dr[o_Log_Program_id.Select.alternate_column_name].GetType() != typeof(System.DBNull))
                            {
                              o_Log_Program_id.obj  = dr[o_Log_Program_id.Select.alternate_column_name];
                            }
                          }
                        }
                        else
                        {
                          if (dr[LogFile.Log_Program_id.name] != null)
                          {
                            if (dr[LogFile.Log_Program_id.name].GetType() != typeof(System.DBNull))
                            {
                            o_Log_Program_id.Log_Program_id_  = (int) dr[LogFile.Log_Program_id.name];
                            }
                          }
                        }

                    }
                    if (o_Log_PathFile_id.Select.enabled)
                    {
                        if (o_Log_PathFile_id.Select.IsExpression)
                        {
                          if (dr[o_Log_PathFile_id.Select.alternate_column_name] != null)
                          {
                            if (dr[o_Log_PathFile_id.Select.alternate_column_name].GetType() != typeof(System.DBNull))
                            {
                              o_Log_PathFile_id.obj  = dr[o_Log_PathFile_id.Select.alternate_column_name];
                            }
                          }
                        }
                        else
                        {
                          if (dr[LogFile.Log_PathFile_id.name] != null)
                          {
                            if (dr[LogFile.Log_PathFile_id.name].GetType() != typeof(System.DBNull))
                            {
                            o_Log_PathFile_id.Log_PathFile_id_  = (int) dr[LogFile.Log_PathFile_id.name];
                            }
                          }
                        }

                    }
                    if (o_LogFile_Description_id.Select.enabled)
                    {
                        if (o_LogFile_Description_id.Select.IsExpression)
                        {
                          if (dr[o_LogFile_Description_id.Select.alternate_column_name] != null)
                          {
                            if (dr[o_LogFile_Description_id.Select.alternate_column_name].GetType() != typeof(System.DBNull))
                            {
                              o_LogFile_Description_id.obj  = dr[o_LogFile_Description_id.Select.alternate_column_name];
                            }
                          }
                        }
                        else
                        {
                          if (dr[LogFile.LogFile_Description_id.name] != null)
                          {
                            if (dr[LogFile.LogFile_Description_id.name].GetType() != typeof(System.DBNull))
                            {
                            o_LogFile_Description_id.LogFile_Description_id_  = (int) dr[LogFile.LogFile_Description_id.name];
                            }
                          }
                        }

                    }
           }

    }
    public class LogFile_Attachment:XTable
    {
        public const string tablename_const = "LogFile_Attachment";
        public selection select;
        public WHERE where;

        public void Set_DataGridView_Headers(DataGridView dgv)
        {
            LogFile_Attachment_lang m_LogFile_Attachment_lang = new LogFile_Attachment_lang();
            foreach (DataGridViewColumn dgvc in dgv.Columns)
            {
                foreach (ltext lt in m_LogFile_Attachment_lang.col_headers)
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

        public bool Read(int Limit,ref string csError)
        {
          bool bRead = read(Limit, ref csError);
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

        public class LogFile_id:ValSet
           { 
             public const string name = "LogFile_id";

             public int LogFile_id_
             {
                get {return (int) obj;}
                set {obj = value;}
             }
           }
           public LogFile_id o_LogFile_id = new LogFile_id();

        public class LogFile_Attachment_Type_id:ValSet
           { 
             public const string name = "LogFile_Attachment_Type_id";

             public int LogFile_Attachment_Type_id_
             {
                get {return (int) obj;}
                set {obj = value;}
             }
           }
           public LogFile_Attachment_Type_id o_LogFile_Attachment_Type_id = new LogFile_Attachment_Type_id();

        public class Attachment:ValSet
           { 
             public const string name = "Attachment";

             public Byte[] Attachment_
             {
                get {return (Byte[]) obj;}
                set {obj = value;}
             }
           }
           public Attachment o_Attachment = new Attachment();

        public class Description:ValSet
           { 
             public const string name = "Description";

             public string Description_
             {
                get {return (string) obj;}
                set {obj = value;}
             }
           }
           public Description o_Description = new Description();

        public LogFile_Attachment(Log_DBConnection xcon)
           {
                select = new selection(this);
                where  = new WHERE(this);
                m_con = xcon;
                tablename = LogFile_Attachment.tablename_const;
                myUpdateObjects = UpdateObjects;


                    o_id.col_name = LogFile_Attachment.id.name;
                    o_id.col_type.m_Type = "int";
                    o_id.col_type.bPRIMARY_KEY = true;
                    o_id.col_type.bFOREIGN_KEY = false;
                    o_id.col_type.bUNIQUE = false;
                    o_id.col_type.bNULL = false;
                    Add(o_id);
                    
                    o_LogFile_id.col_name = LogFile_Attachment.LogFile_id.name;
                    o_LogFile_id.col_type.m_Type = "int";
                    o_LogFile_id.col_type.bPRIMARY_KEY = false;
                    o_LogFile_id.col_type.bFOREIGN_KEY = true;
                    o_LogFile_id.col_type.bUNIQUE = false;
                    o_LogFile_id.col_type.bNULL = false;
                    Add(o_LogFile_id);
                    
                    o_LogFile_Attachment_Type_id.col_name = LogFile_Attachment.LogFile_Attachment_Type_id.name;
                    o_LogFile_Attachment_Type_id.col_type.m_Type = "int";
                    o_LogFile_Attachment_Type_id.col_type.bPRIMARY_KEY = false;
                    o_LogFile_Attachment_Type_id.col_type.bFOREIGN_KEY = true;
                    o_LogFile_Attachment_Type_id.col_type.bUNIQUE = false;
                    o_LogFile_Attachment_Type_id.col_type.bNULL = false;
                    Add(o_LogFile_Attachment_Type_id);
                    
                    o_Attachment.col_name = LogFile_Attachment.Attachment.name;
                    o_Attachment.col_type.m_Type = "varbinary";
                    o_Attachment.col_type.bPRIMARY_KEY = false;
                    o_Attachment.col_type.bFOREIGN_KEY = false;
                    o_Attachment.col_type.bUNIQUE = false;
                    o_Attachment.col_type.bNULL = true;
                    Add(o_Attachment);
                    
                    o_Description.col_name = LogFile_Attachment.Description.name;
                    o_Description.col_type.m_Type = "nvarchar";
                    o_Description.col_type.bPRIMARY_KEY = false;
                    o_Description.col_type.bFOREIGN_KEY = false;
                    o_Description.col_type.bUNIQUE = false;
                    o_Description.col_type.bNULL = true;
                    Add(o_Description);
                    
           }

        public class selection
           {
                private LogFile_Attachment m_LogFile_Attachment;
                public selection(LogFile_Attachment xLogFile_Attachment)
                {
                    m_LogFile_Attachment =  xLogFile_Attachment;
                }

                    public bool id
                    {
                        get {return m_LogFile_Attachment.o_id.Select.enabled;}
                        set {m_LogFile_Attachment.o_id.Select.enabled = value;}
                    }
                    
                    public void id_Expression(string Expression,string xalternate_column_name)
                    {
                        m_LogFile_Attachment.o_id.Select.expression = Expression;
                        m_LogFile_Attachment.o_id.Select.alternate_column_name = xalternate_column_name;
                    }
                    
                    public bool LogFile_id
                    {
                        get {return m_LogFile_Attachment.o_LogFile_id.Select.enabled;}
                        set {m_LogFile_Attachment.o_LogFile_id.Select.enabled = value;}
                    }
                    
                    public void LogFile_id_Expression(string Expression,string xalternate_column_name)
                    {
                        m_LogFile_Attachment.o_LogFile_id.Select.expression = Expression;
                        m_LogFile_Attachment.o_LogFile_id.Select.alternate_column_name = xalternate_column_name;
                    }
                    
                    public bool LogFile_Attachment_Type_id
                    {
                        get {return m_LogFile_Attachment.o_LogFile_Attachment_Type_id.Select.enabled;}
                        set {m_LogFile_Attachment.o_LogFile_Attachment_Type_id.Select.enabled = value;}
                    }
                    
                    public void LogFile_Attachment_Type_id_Expression(string Expression,string xalternate_column_name)
                    {
                        m_LogFile_Attachment.o_LogFile_Attachment_Type_id.Select.expression = Expression;
                        m_LogFile_Attachment.o_LogFile_Attachment_Type_id.Select.alternate_column_name = xalternate_column_name;
                    }
                    
                    public bool Attachment
                    {
                        get {return m_LogFile_Attachment.o_Attachment.Select.enabled;}
                        set {m_LogFile_Attachment.o_Attachment.Select.enabled = value;}
                    }
                    
                    public void Attachment_Expression(string Expression,string xalternate_column_name)
                    {
                        m_LogFile_Attachment.o_Attachment.Select.expression = Expression;
                        m_LogFile_Attachment.o_Attachment.Select.alternate_column_name = xalternate_column_name;
                    }
                    
                    public bool Description
                    {
                        get {return m_LogFile_Attachment.o_Description.Select.enabled;}
                        set {m_LogFile_Attachment.o_Description.Select.enabled = value;}
                    }
                    
                    public void Description_Expression(string Expression,string xalternate_column_name)
                    {
                        m_LogFile_Attachment.o_Description.Select.expression = Expression;
                        m_LogFile_Attachment.o_Description.Select.alternate_column_name = xalternate_column_name;
                    }
                    
               public void all(bool bVal)
               {

                    this.id = bVal;
                    
                    this.LogFile_id = bVal;
                    
                    this.LogFile_Attachment_Type_id = bVal;
                    
                    this.Attachment = bVal;
                    
                    this.Description = bVal;
                    
               }
    
           }

        public class WHERE
           {
                private LogFile_Attachment m_LogFile_Attachment;
                public WHERE(LogFile_Attachment xLogFile_Attachment)
                {
                    m_LogFile_Attachment =  xLogFile_Attachment;
                }

                    public bool id
                    {
                        get {return m_LogFile_Attachment.o_id.Where.enabled;}
                        set {m_LogFile_Attachment.o_id.Where.enabled = value;}
                    }
                    
                    public void id_Expression(string Expression)
                    {
                        m_LogFile_Attachment.o_id.Where.expression = Expression;
                    }
                    

                    public void id_AddParameter(Log_SQL_Parameter par)
                    {
                        m_LogFile_Attachment.o_id.Where.AddParameter(par);
                    }
                    
                    public bool LogFile_id
                    {
                        get {return m_LogFile_Attachment.o_LogFile_id.Where.enabled;}
                        set {m_LogFile_Attachment.o_LogFile_id.Where.enabled = value;}
                    }
                    
                    public void LogFile_id_Expression(string Expression)
                    {
                        m_LogFile_Attachment.o_LogFile_id.Where.expression = Expression;
                    }
                    

                    public void LogFile_id_AddParameter(Log_SQL_Parameter par)
                    {
                        m_LogFile_Attachment.o_LogFile_id.Where.AddParameter(par);
                    }
                    
                    public bool LogFile_Attachment_Type_id
                    {
                        get {return m_LogFile_Attachment.o_LogFile_Attachment_Type_id.Where.enabled;}
                        set {m_LogFile_Attachment.o_LogFile_Attachment_Type_id.Where.enabled = value;}
                    }
                    
                    public void LogFile_Attachment_Type_id_Expression(string Expression)
                    {
                        m_LogFile_Attachment.o_LogFile_Attachment_Type_id.Where.expression = Expression;
                    }
                    

                    public void LogFile_Attachment_Type_id_AddParameter(Log_SQL_Parameter par)
                    {
                        m_LogFile_Attachment.o_LogFile_Attachment_Type_id.Where.AddParameter(par);
                    }
                    
                    public bool Attachment
                    {
                        get {return m_LogFile_Attachment.o_Attachment.Where.enabled;}
                        set {m_LogFile_Attachment.o_Attachment.Where.enabled = value;}
                    }
                    
                    public void Attachment_Expression(string Expression)
                    {
                        m_LogFile_Attachment.o_Attachment.Where.expression = Expression;
                    }
                    

                    public void Attachment_AddParameter(Log_SQL_Parameter par)
                    {
                        m_LogFile_Attachment.o_Attachment.Where.AddParameter(par);
                    }
                    
                    public bool Description
                    {
                        get {return m_LogFile_Attachment.o_Description.Where.enabled;}
                        set {m_LogFile_Attachment.o_Description.Where.enabled = value;}
                    }
                    
                    public void Description_Expression(string Expression)
                    {
                        m_LogFile_Attachment.o_Description.Where.expression = Expression;
                    }
                    

                    public void Description_AddParameter(Log_SQL_Parameter par)
                    {
                        m_LogFile_Attachment.o_Description.Where.AddParameter(par);
                    }
                    
               public void all(bool bVal)
               {

                    this.id = bVal;
                    
                    this.LogFile_id = bVal;
                    
                    this.LogFile_Attachment_Type_id = bVal;
                    
                    this.Attachment = bVal;
                    
                    this.Description = bVal;
                    
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
                          if (dr[LogFile_Attachment.id.name] != null)
                          {
                            if (dr[LogFile_Attachment.id.name].GetType() != typeof(System.DBNull))
                            {
                            o_id.id_  = (int) dr[LogFile_Attachment.id.name];
                            }
                          }
                        }

                    }
                    if (o_LogFile_id.Select.enabled)
                    {
                        if (o_LogFile_id.Select.IsExpression)
                        {
                          if (dr[o_LogFile_id.Select.alternate_column_name] != null)
                          {
                            if (dr[o_LogFile_id.Select.alternate_column_name].GetType() != typeof(System.DBNull))
                            {
                              o_LogFile_id.obj  = dr[o_LogFile_id.Select.alternate_column_name];
                            }
                          }
                        }
                        else
                        {
                          if (dr[LogFile_Attachment.LogFile_id.name] != null)
                          {
                            if (dr[LogFile_Attachment.LogFile_id.name].GetType() != typeof(System.DBNull))
                            {
                            o_LogFile_id.LogFile_id_  = (int) dr[LogFile_Attachment.LogFile_id.name];
                            }
                          }
                        }

                    }
                    if (o_LogFile_Attachment_Type_id.Select.enabled)
                    {
                        if (o_LogFile_Attachment_Type_id.Select.IsExpression)
                        {
                          if (dr[o_LogFile_Attachment_Type_id.Select.alternate_column_name] != null)
                          {
                            if (dr[o_LogFile_Attachment_Type_id.Select.alternate_column_name].GetType() != typeof(System.DBNull))
                            {
                              o_LogFile_Attachment_Type_id.obj  = dr[o_LogFile_Attachment_Type_id.Select.alternate_column_name];
                            }
                          }
                        }
                        else
                        {
                          if (dr[LogFile_Attachment.LogFile_Attachment_Type_id.name] != null)
                          {
                            if (dr[LogFile_Attachment.LogFile_Attachment_Type_id.name].GetType() != typeof(System.DBNull))
                            {
                            o_LogFile_Attachment_Type_id.LogFile_Attachment_Type_id_  = (int) dr[LogFile_Attachment.LogFile_Attachment_Type_id.name];
                            }
                          }
                        }

                    }
                    if (o_Attachment.Select.enabled)
                    {
                        if (o_Attachment.Select.IsExpression)
                        {
                          if (dr[o_Attachment.Select.alternate_column_name] != null)
                          {
                            if (dr[o_Attachment.Select.alternate_column_name].GetType() != typeof(System.DBNull))
                            {
                              o_Attachment.obj  = dr[o_Attachment.Select.alternate_column_name];
                            }
                          }
                        }
                        else
                        {
                          if (dr[LogFile_Attachment.Attachment.name] != null)
                          {
                            if (dr[LogFile_Attachment.Attachment.name].GetType() != typeof(System.DBNull))
                            {
                            o_Attachment.Attachment_  = (Byte[]) dr[LogFile_Attachment.Attachment.name];
                            }
                          }
                        }

                    }
                    if (o_Description.Select.enabled)
                    {
                        if (o_Description.Select.IsExpression)
                        {
                          if (dr[o_Description.Select.alternate_column_name] != null)
                          {
                            if (dr[o_Description.Select.alternate_column_name].GetType() != typeof(System.DBNull))
                            {
                              o_Description.obj  = dr[o_Description.Select.alternate_column_name];
                            }
                          }
                        }
                        else
                        {
                          if (dr[LogFile_Attachment.Description.name] != null)
                          {
                            if (dr[LogFile_Attachment.Description.name].GetType() != typeof(System.DBNull))
                            {
                            o_Description.Description_  = (string) dr[LogFile_Attachment.Description.name];
                            }
                          }
                        }

                    }
           }

    }
    public class LogFile_Attachment_Type:XTable
    {
        public const string tablename_const = "LogFile_Attachment_Type";
        public selection select;
        public WHERE where;

        public void Set_DataGridView_Headers(DataGridView dgv)
        {
            LogFile_Attachment_Type_lang m_LogFile_Attachment_Type_lang = new LogFile_Attachment_Type_lang();
            foreach (DataGridViewColumn dgvc in dgv.Columns)
            {
                foreach (ltext lt in m_LogFile_Attachment_Type_lang.col_headers)
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

        public bool Read(int Limit,ref string csError)
        {
          bool bRead = read(Limit, ref csError);
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

        public class Attachment_type:ValSet
           { 
             public const string name = "Attachment_type";

             public string Attachment_type_
             {
                get {return (string) obj;}
                set {obj = value;}
             }
           }
           public Attachment_type o_Attachment_type = new Attachment_type();

        public LogFile_Attachment_Type(Log_DBConnection xcon)
           {
                select = new selection(this);
                where  = new WHERE(this);
                m_con = xcon;
                tablename = LogFile_Attachment_Type.tablename_const;
                myUpdateObjects = UpdateObjects;


                    o_id.col_name = LogFile_Attachment_Type.id.name;
                    o_id.col_type.m_Type = "int";
                    o_id.col_type.bPRIMARY_KEY = true;
                    o_id.col_type.bFOREIGN_KEY = false;
                    o_id.col_type.bUNIQUE = false;
                    o_id.col_type.bNULL = false;
                    Add(o_id);
                    
                    o_Attachment_type.col_name = LogFile_Attachment_Type.Attachment_type.name;
                    o_Attachment_type.col_type.m_Type = "nvarchar";
                    o_Attachment_type.col_type.bPRIMARY_KEY = false;
                    o_Attachment_type.col_type.bFOREIGN_KEY = false;
                    o_Attachment_type.col_type.bUNIQUE = false;
                    o_Attachment_type.col_type.bNULL = true;
                    Add(o_Attachment_type);
                    
           }

        public class selection
           {
                private LogFile_Attachment_Type m_LogFile_Attachment_Type;
                public selection(LogFile_Attachment_Type xLogFile_Attachment_Type)
                {
                    m_LogFile_Attachment_Type =  xLogFile_Attachment_Type;
                }

                    public bool id
                    {
                        get {return m_LogFile_Attachment_Type.o_id.Select.enabled;}
                        set {m_LogFile_Attachment_Type.o_id.Select.enabled = value;}
                    }
                    
                    public void id_Expression(string Expression,string xalternate_column_name)
                    {
                        m_LogFile_Attachment_Type.o_id.Select.expression = Expression;
                        m_LogFile_Attachment_Type.o_id.Select.alternate_column_name = xalternate_column_name;
                    }
                    
                    public bool Attachment_type
                    {
                        get {return m_LogFile_Attachment_Type.o_Attachment_type.Select.enabled;}
                        set {m_LogFile_Attachment_Type.o_Attachment_type.Select.enabled = value;}
                    }
                    
                    public void Attachment_type_Expression(string Expression,string xalternate_column_name)
                    {
                        m_LogFile_Attachment_Type.o_Attachment_type.Select.expression = Expression;
                        m_LogFile_Attachment_Type.o_Attachment_type.Select.alternate_column_name = xalternate_column_name;
                    }
                    
               public void all(bool bVal)
               {

                    this.id = bVal;
                    
                    this.Attachment_type = bVal;
                    
               }
    
           }

        public class WHERE
           {
                private LogFile_Attachment_Type m_LogFile_Attachment_Type;
                public WHERE(LogFile_Attachment_Type xLogFile_Attachment_Type)
                {
                    m_LogFile_Attachment_Type =  xLogFile_Attachment_Type;
                }

                    public bool id
                    {
                        get {return m_LogFile_Attachment_Type.o_id.Where.enabled;}
                        set {m_LogFile_Attachment_Type.o_id.Where.enabled = value;}
                    }
                    
                    public void id_Expression(string Expression)
                    {
                        m_LogFile_Attachment_Type.o_id.Where.expression = Expression;
                    }
                    

                    public void id_AddParameter(Log_SQL_Parameter par)
                    {
                        m_LogFile_Attachment_Type.o_id.Where.AddParameter(par);
                    }
                    
                    public bool Attachment_type
                    {
                        get {return m_LogFile_Attachment_Type.o_Attachment_type.Where.enabled;}
                        set {m_LogFile_Attachment_Type.o_Attachment_type.Where.enabled = value;}
                    }
                    
                    public void Attachment_type_Expression(string Expression)
                    {
                        m_LogFile_Attachment_Type.o_Attachment_type.Where.expression = Expression;
                    }
                    

                    public void Attachment_type_AddParameter(Log_SQL_Parameter par)
                    {
                        m_LogFile_Attachment_Type.o_Attachment_type.Where.AddParameter(par);
                    }
                    
               public void all(bool bVal)
               {

                    this.id = bVal;
                    
                    this.Attachment_type = bVal;
                    
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
                          if (dr[LogFile_Attachment_Type.id.name] != null)
                          {
                            if (dr[LogFile_Attachment_Type.id.name].GetType() != typeof(System.DBNull))
                            {
                            o_id.id_  = (int) dr[LogFile_Attachment_Type.id.name];
                            }
                          }
                        }

                    }
                    if (o_Attachment_type.Select.enabled)
                    {
                        if (o_Attachment_type.Select.IsExpression)
                        {
                          if (dr[o_Attachment_type.Select.alternate_column_name] != null)
                          {
                            if (dr[o_Attachment_type.Select.alternate_column_name].GetType() != typeof(System.DBNull))
                            {
                              o_Attachment_type.obj  = dr[o_Attachment_type.Select.alternate_column_name];
                            }
                          }
                        }
                        else
                        {
                          if (dr[LogFile_Attachment_Type.Attachment_type.name] != null)
                          {
                            if (dr[LogFile_Attachment_Type.Attachment_type.name].GetType() != typeof(System.DBNull))
                            {
                            o_Attachment_type.Attachment_type_  = (string) dr[LogFile_Attachment_Type.Attachment_type.name];
                            }
                          }
                        }

                    }
           }

    }
    public class LogFile_Description:XTable
    {
        public const string tablename_const = "LogFile_Description";
        public selection select;
        public WHERE where;

        public void Set_DataGridView_Headers(DataGridView dgv)
        {
            LogFile_Description_lang m_LogFile_Description_lang = new LogFile_Description_lang();
            foreach (DataGridViewColumn dgvc in dgv.Columns)
            {
                foreach (ltext lt in m_LogFile_Description_lang.col_headers)
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

        public bool Read(int Limit,ref string csError)
        {
          bool bRead = read(Limit, ref csError);
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

        public class Description:ValSet
           { 
             public const string name = "Description";

             public string Description_
             {
                get {return (string) obj;}
                set {obj = value;}
             }
           }
           public Description o_Description = new Description();

        public LogFile_Description(Log_DBConnection xcon)
           {
                select = new selection(this);
                where  = new WHERE(this);
                m_con = xcon;
                tablename = LogFile_Description.tablename_const;
                myUpdateObjects = UpdateObjects;


                    o_id.col_name = LogFile_Description.id.name;
                    o_id.col_type.m_Type = "int";
                    o_id.col_type.bPRIMARY_KEY = true;
                    o_id.col_type.bFOREIGN_KEY = false;
                    o_id.col_type.bUNIQUE = false;
                    o_id.col_type.bNULL = false;
                    Add(o_id);
                    
                    o_Description.col_name = LogFile_Description.Description.name;
                    o_Description.col_type.m_Type = "nvarchar";
                    o_Description.col_type.bPRIMARY_KEY = false;
                    o_Description.col_type.bFOREIGN_KEY = false;
                    o_Description.col_type.bUNIQUE = false;
                    o_Description.col_type.bNULL = false;
                    Add(o_Description);
                    
           }

        public class selection
           {
                private LogFile_Description m_LogFile_Description;
                public selection(LogFile_Description xLogFile_Description)
                {
                    m_LogFile_Description =  xLogFile_Description;
                }

                    public bool id
                    {
                        get {return m_LogFile_Description.o_id.Select.enabled;}
                        set {m_LogFile_Description.o_id.Select.enabled = value;}
                    }
                    
                    public void id_Expression(string Expression,string xalternate_column_name)
                    {
                        m_LogFile_Description.o_id.Select.expression = Expression;
                        m_LogFile_Description.o_id.Select.alternate_column_name = xalternate_column_name;
                    }
                    
                    public bool Description
                    {
                        get {return m_LogFile_Description.o_Description.Select.enabled;}
                        set {m_LogFile_Description.o_Description.Select.enabled = value;}
                    }
                    
                    public void Description_Expression(string Expression,string xalternate_column_name)
                    {
                        m_LogFile_Description.o_Description.Select.expression = Expression;
                        m_LogFile_Description.o_Description.Select.alternate_column_name = xalternate_column_name;
                    }
                    
               public void all(bool bVal)
               {

                    this.id = bVal;
                    
                    this.Description = bVal;
                    
               }
    
           }

        public class WHERE
           {
                private LogFile_Description m_LogFile_Description;
                public WHERE(LogFile_Description xLogFile_Description)
                {
                    m_LogFile_Description =  xLogFile_Description;
                }

                    public bool id
                    {
                        get {return m_LogFile_Description.o_id.Where.enabled;}
                        set {m_LogFile_Description.o_id.Where.enabled = value;}
                    }
                    
                    public void id_Expression(string Expression)
                    {
                        m_LogFile_Description.o_id.Where.expression = Expression;
                    }
                    

                    public void id_AddParameter(Log_SQL_Parameter par)
                    {
                        m_LogFile_Description.o_id.Where.AddParameter(par);
                    }
                    
                    public bool Description
                    {
                        get {return m_LogFile_Description.o_Description.Where.enabled;}
                        set {m_LogFile_Description.o_Description.Where.enabled = value;}
                    }
                    
                    public void Description_Expression(string Expression)
                    {
                        m_LogFile_Description.o_Description.Where.expression = Expression;
                    }
                    

                    public void Description_AddParameter(Log_SQL_Parameter par)
                    {
                        m_LogFile_Description.o_Description.Where.AddParameter(par);
                    }
                    
               public void all(bool bVal)
               {

                    this.id = bVal;
                    
                    this.Description = bVal;
                    
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
                          if (dr[LogFile_Description.id.name] != null)
                          {
                            if (dr[LogFile_Description.id.name].GetType() != typeof(System.DBNull))
                            {
                            o_id.id_  = (int) dr[LogFile_Description.id.name];
                            }
                          }
                        }

                    }
                    if (o_Description.Select.enabled)
                    {
                        if (o_Description.Select.IsExpression)
                        {
                          if (dr[o_Description.Select.alternate_column_name] != null)
                          {
                            if (dr[o_Description.Select.alternate_column_name].GetType() != typeof(System.DBNull))
                            {
                              o_Description.obj  = dr[o_Description.Select.alternate_column_name];
                            }
                          }
                        }
                        else
                        {
                          if (dr[LogFile_Description.Description.name] != null)
                          {
                            if (dr[LogFile_Description.Description.name].GetType() != typeof(System.DBNull))
                            {
                            o_Description.Description_  = (string) dr[LogFile_Description.Description.name];
                            }
                          }
                        }

                    }
           }

    }
    public class sysdiagrams:XTable
    {
        public const string tablename_const = "sysdiagrams";
        public selection select;
        public WHERE where;

        public void Set_DataGridView_Headers(DataGridView dgv)
        {
            sysdiagrams_lang m_sysdiagrams_lang = new sysdiagrams_lang();
            foreach (DataGridViewColumn dgvc in dgv.Columns)
            {
                foreach (ltext lt in m_sysdiagrams_lang.col_headers)
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

        public bool Read(int Limit,ref string csError)
        {
          bool bRead = read(Limit, ref csError);
          if (Cursor>=0)
          {
             UpdateObjects(dt.Rows[Cursor]);
          }
          return bRead;
        }
        
        public class name__:ValSet
           { 
             public const string name = "name";

             public string name_
             {
                get {return (string) obj;}
                set {obj = value;}
             }
           }
           public name__ o_name = new name__();

        public class principal_id:ValSet
           { 
             public const string name = "principal_id";

             public int principal_id_
             {
                get {return (int) obj;}
                set {obj = value;}
             }
           }
           public principal_id o_principal_id = new principal_id();

        public class diagram_id:ValSet
           { 
             public const string name = "diagram_id";

             public int diagram_id_
             {
                get {return (int) obj;}
                set {obj = value;}
             }
           }
           public diagram_id o_diagram_id = new diagram_id();

        public class version:ValSet
           { 
             public const string name = "version";

             public int version_
             {
                get {return (int) obj;}
                set {obj = value;}
             }
           }
           public version o_version = new version();

        public class definition:ValSet
           { 
             public const string name = "definition";

             public Byte[] definition_
             {
                get {return (Byte[]) obj;}
                set {obj = value;}
             }
           }
           public definition o_definition = new definition();

        public sysdiagrams(Log_DBConnection xcon)
           {
                select = new selection(this);
                where  = new WHERE(this);
                m_con = xcon;
                tablename = sysdiagrams.tablename_const;
                myUpdateObjects = UpdateObjects;


                    o_name.col_name = sysdiagrams.name__.name;
                    o_name.col_type.m_Type = "nvarchar";
                    o_name.col_type.bPRIMARY_KEY = false;
                    o_name.col_type.bFOREIGN_KEY = false;
                    o_name.col_type.bUNIQUE = true;
                    o_name.col_type.bNULL = false;
                    Add(o_name);
                    
                    o_principal_id.col_name = sysdiagrams.principal_id.name;
                    o_principal_id.col_type.m_Type = "int";
                    o_principal_id.col_type.bPRIMARY_KEY = false;
                    o_principal_id.col_type.bFOREIGN_KEY = false;
                    o_principal_id.col_type.bUNIQUE = true;
                    o_principal_id.col_type.bNULL = false;
                    Add(o_principal_id);
                    
                    o_diagram_id.col_name = sysdiagrams.diagram_id.name;
                    o_diagram_id.col_type.m_Type = "int";
                    o_diagram_id.col_type.bPRIMARY_KEY = true;
                    o_diagram_id.col_type.bFOREIGN_KEY = false;
                    o_diagram_id.col_type.bUNIQUE = false;
                    o_diagram_id.col_type.bNULL = false;
                    Add(o_diagram_id);
                    
                    o_version.col_name = sysdiagrams.version.name;
                    o_version.col_type.m_Type = "int";
                    o_version.col_type.bPRIMARY_KEY = false;
                    o_version.col_type.bFOREIGN_KEY = false;
                    o_version.col_type.bUNIQUE = false;
                    o_version.col_type.bNULL = true;
                    Add(o_version);
                    
                    o_definition.col_name = sysdiagrams.definition.name;
                    o_definition.col_type.m_Type = "varbinary";
                    o_definition.col_type.bPRIMARY_KEY = false;
                    o_definition.col_type.bFOREIGN_KEY = false;
                    o_definition.col_type.bUNIQUE = false;
                    o_definition.col_type.bNULL = true;
                    Add(o_definition);
                    
           }

        public class selection
           {
                private sysdiagrams m_sysdiagrams;
                public selection(sysdiagrams xsysdiagrams)
                {
                    m_sysdiagrams =  xsysdiagrams;
                }

                    public bool name
                    {
                        get {return m_sysdiagrams.o_name.Select.enabled;}
                        set {m_sysdiagrams.o_name.Select.enabled = value;}
                    }
                    
                    public void name_Expression(string Expression,string xalternate_column_name)
                    {
                        m_sysdiagrams.o_name.Select.expression = Expression;
                        m_sysdiagrams.o_name.Select.alternate_column_name = xalternate_column_name;
                    }
                    
                    public bool principal_id
                    {
                        get {return m_sysdiagrams.o_principal_id.Select.enabled;}
                        set {m_sysdiagrams.o_principal_id.Select.enabled = value;}
                    }
                    
                    public void principal_id_Expression(string Expression,string xalternate_column_name)
                    {
                        m_sysdiagrams.o_principal_id.Select.expression = Expression;
                        m_sysdiagrams.o_principal_id.Select.alternate_column_name = xalternate_column_name;
                    }
                    
                    public bool diagram_id
                    {
                        get {return m_sysdiagrams.o_diagram_id.Select.enabled;}
                        set {m_sysdiagrams.o_diagram_id.Select.enabled = value;}
                    }
                    
                    public void diagram_id_Expression(string Expression,string xalternate_column_name)
                    {
                        m_sysdiagrams.o_diagram_id.Select.expression = Expression;
                        m_sysdiagrams.o_diagram_id.Select.alternate_column_name = xalternate_column_name;
                    }
                    
                    public bool version
                    {
                        get {return m_sysdiagrams.o_version.Select.enabled;}
                        set {m_sysdiagrams.o_version.Select.enabled = value;}
                    }
                    
                    public void version_Expression(string Expression,string xalternate_column_name)
                    {
                        m_sysdiagrams.o_version.Select.expression = Expression;
                        m_sysdiagrams.o_version.Select.alternate_column_name = xalternate_column_name;
                    }
                    
                    public bool definition
                    {
                        get {return m_sysdiagrams.o_definition.Select.enabled;}
                        set {m_sysdiagrams.o_definition.Select.enabled = value;}
                    }
                    
                    public void definition_Expression(string Expression,string xalternate_column_name)
                    {
                        m_sysdiagrams.o_definition.Select.expression = Expression;
                        m_sysdiagrams.o_definition.Select.alternate_column_name = xalternate_column_name;
                    }
                    
               public void all(bool bVal)
               {

                    this.name = bVal;
                    
                    this.principal_id = bVal;
                    
                    this.diagram_id = bVal;
                    
                    this.version = bVal;
                    
                    this.definition = bVal;
                    
               }
    
           }

        public class WHERE
           {
                private sysdiagrams m_sysdiagrams;
                public WHERE(sysdiagrams xsysdiagrams)
                {
                    m_sysdiagrams =  xsysdiagrams;
                }

                    public bool name
                    {
                        get {return m_sysdiagrams.o_name.Where.enabled;}
                        set {m_sysdiagrams.o_name.Where.enabled = value;}
                    }
                    
                    public void name_Expression(string Expression)
                    {
                        m_sysdiagrams.o_name.Where.expression = Expression;
                    }
                    

                    public void name_AddParameter(Log_SQL_Parameter par)
                    {
                        m_sysdiagrams.o_name.Where.AddParameter(par);
                    }
                    
                    public bool principal_id
                    {
                        get {return m_sysdiagrams.o_principal_id.Where.enabled;}
                        set {m_sysdiagrams.o_principal_id.Where.enabled = value;}
                    }
                    
                    public void principal_id_Expression(string Expression)
                    {
                        m_sysdiagrams.o_principal_id.Where.expression = Expression;
                    }
                    

                    public void principal_id_AddParameter(Log_SQL_Parameter par)
                    {
                        m_sysdiagrams.o_principal_id.Where.AddParameter(par);
                    }
                    
                    public bool diagram_id
                    {
                        get {return m_sysdiagrams.o_diagram_id.Where.enabled;}
                        set {m_sysdiagrams.o_diagram_id.Where.enabled = value;}
                    }
                    
                    public void diagram_id_Expression(string Expression)
                    {
                        m_sysdiagrams.o_diagram_id.Where.expression = Expression;
                    }
                    

                    public void diagram_id_AddParameter(Log_SQL_Parameter par)
                    {
                        m_sysdiagrams.o_diagram_id.Where.AddParameter(par);
                    }
                    
                    public bool version
                    {
                        get {return m_sysdiagrams.o_version.Where.enabled;}
                        set {m_sysdiagrams.o_version.Where.enabled = value;}
                    }
                    
                    public void version_Expression(string Expression)
                    {
                        m_sysdiagrams.o_version.Where.expression = Expression;
                    }
                    

                    public void version_AddParameter(Log_SQL_Parameter par)
                    {
                        m_sysdiagrams.o_version.Where.AddParameter(par);
                    }
                    
                    public bool definition
                    {
                        get {return m_sysdiagrams.o_definition.Where.enabled;}
                        set {m_sysdiagrams.o_definition.Where.enabled = value;}
                    }
                    
                    public void definition_Expression(string Expression)
                    {
                        m_sysdiagrams.o_definition.Where.expression = Expression;
                    }
                    

                    public void definition_AddParameter(Log_SQL_Parameter par)
                    {
                        m_sysdiagrams.o_definition.Where.AddParameter(par);
                    }
                    
               public void all(bool bVal)
               {

                    this.name = bVal;
                    
                    this.principal_id = bVal;
                    
                    this.diagram_id = bVal;
                    
                    this.version = bVal;
                    
                    this.definition = bVal;
                    
               }
    
           }

        public void UpdateObjects(DataRow dr)
           {

                    if (o_name.Select.enabled)
                    {
                        if (o_name.Select.IsExpression)
                        {
                          if (dr[o_name.Select.alternate_column_name] != null)
                          {
                            if (dr[o_name.Select.alternate_column_name].GetType() != typeof(System.DBNull))
                            {
                              o_name.obj  = dr[o_name.Select.alternate_column_name];
                            }
                          }
                        }
                        else
                        {
                          if (dr[sysdiagrams.name__.name] != null)
                          {
                            if (dr[sysdiagrams.name__.name].GetType() != typeof(System.DBNull))
                            {
                            o_name.name_  = (string) dr[sysdiagrams.name__.name];
                            }
                          }
                        }

                    }
                    if (o_principal_id.Select.enabled)
                    {
                        if (o_principal_id.Select.IsExpression)
                        {
                          if (dr[o_principal_id.Select.alternate_column_name] != null)
                          {
                            if (dr[o_principal_id.Select.alternate_column_name].GetType() != typeof(System.DBNull))
                            {
                              o_principal_id.obj  = dr[o_principal_id.Select.alternate_column_name];
                            }
                          }
                        }
                        else
                        {
                          if (dr[sysdiagrams.principal_id.name] != null)
                          {
                            if (dr[sysdiagrams.principal_id.name].GetType() != typeof(System.DBNull))
                            {
                            o_principal_id.principal_id_  = (int) dr[sysdiagrams.principal_id.name];
                            }
                          }
                        }

                    }
                    if (o_diagram_id.Select.enabled)
                    {
                        if (o_diagram_id.Select.IsExpression)
                        {
                          if (dr[o_diagram_id.Select.alternate_column_name] != null)
                          {
                            if (dr[o_diagram_id.Select.alternate_column_name].GetType() != typeof(System.DBNull))
                            {
                              o_diagram_id.obj  = dr[o_diagram_id.Select.alternate_column_name];
                            }
                          }
                        }
                        else
                        {
                          if (dr[sysdiagrams.diagram_id.name] != null)
                          {
                            if (dr[sysdiagrams.diagram_id.name].GetType() != typeof(System.DBNull))
                            {
                            o_diagram_id.diagram_id_  = (int) dr[sysdiagrams.diagram_id.name];
                            }
                          }
                        }

                    }
                    if (o_version.Select.enabled)
                    {
                        if (o_version.Select.IsExpression)
                        {
                          if (dr[o_version.Select.alternate_column_name] != null)
                          {
                            if (dr[o_version.Select.alternate_column_name].GetType() != typeof(System.DBNull))
                            {
                              o_version.obj  = dr[o_version.Select.alternate_column_name];
                            }
                          }
                        }
                        else
                        {
                          if (dr[sysdiagrams.version.name] != null)
                          {
                            if (dr[sysdiagrams.version.name].GetType() != typeof(System.DBNull))
                            {
                            o_version.version_  = (int) dr[sysdiagrams.version.name];
                            }
                          }
                        }

                    }
                    if (o_definition.Select.enabled)
                    {
                        if (o_definition.Select.IsExpression)
                        {
                          if (dr[o_definition.Select.alternate_column_name] != null)
                          {
                            if (dr[o_definition.Select.alternate_column_name].GetType() != typeof(System.DBNull))
                            {
                              o_definition.obj  = dr[o_definition.Select.alternate_column_name];
                            }
                          }
                        }
                        else
                        {
                          if (dr[sysdiagrams.definition.name] != null)
                          {
                            if (dr[sysdiagrams.definition.name].GetType() != typeof(System.DBNull))
                            {
                            o_definition.definition_  = (Byte[]) dr[sysdiagrams.definition.name];
                            }
                          }
                        }

                    }
           }

    }

    public class Log_VIEW:XView
    {
        public const string tablename_const = "Log_VIEW";
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

        public bool Read(int Limit, ref string csError)
        {
          bool bRead = read(Limit, ref csError);
          if (Cursor>=0)
          {
             UpdateObjects(dt.Rows[Cursor]);
          }
          return bRead;
        }
        
        public class LogFile_id:ValSet
           { 
             public const string name = "LogFile_id";
             public int LogFile_id_
             {
                get {return (int) obj;}
                set {obj = value;}
             }
           }
           public LogFile_id o_LogFile_id = new LogFile_id();

        public class Log_Time:ValSet
           { 
             public const string name = "Log_Time";
             public DateTime Log_Time_
             {
                get {return (DateTime) obj;}
                set {obj = value;}
             }
           }
           public Log_Time o_Log_Time = new Log_Time();

        public class Log_TypeName:ValSet
           { 
             public const string name = "Log_TypeName";
             public string Log_TypeName_
             {
                get {return (string) obj;}
                set {obj = value;}
             }
           }
           public Log_TypeName o_Log_TypeName = new Log_TypeName();

        public class Log_Type_id:ValSet
           { 
             public const string name = "Log_Type_id";
             public int Log_Type_id_
             {
                get {return (int) obj;}
                set {obj = value;}
             }
           }
           public Log_Type_id o_Log_Type_id = new Log_Type_id();

        public class Log_Description:ValSet
           { 
             public const string name = "Log_Description";
             public string Log_Description_
             {
                get {return (string) obj;}
                set {obj = value;}
             }
           }
           public Log_Description o_Log_Description = new Log_Description();

        public class Log_Description_id:ValSet
           { 
             public const string name = "Log_Description_id";
             public int Log_Description_id_
             {
                get {return (int) obj;}
                set {obj = value;}
             }
           }
           public Log_Description_id o_Log_Description_id = new Log_Description_id();

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

        public class Log_Computer_id:ValSet
           { 
             public const string name = "Log_Computer_id";
             public int Log_Computer_id_
             {
                get {return (int) obj;}
                set {obj = value;}
             }
           }
           public Log_Computer_id o_Log_Computer_id = new Log_Computer_id();

        public class UserName:ValSet
           { 
             public const string name = "UserName";
             public string UserName_
             {
                get {return (string) obj;}
                set {obj = value;}
             }
           }
           public UserName o_UserName = new UserName();

        public class Log_UserName_id:ValSet
           { 
             public const string name = "Log_UserName_id";
             public int Log_UserName_id_
             {
                get {return (int) obj;}
                set {obj = value;}
             }
           }
           public Log_UserName_id o_Log_UserName_id = new Log_UserName_id();

        public class Program:ValSet
           { 
             public const string name = "Program";
             public string Program_
             {
                get {return (string) obj;}
                set {obj = value;}
             }
           }
           public Program o_Program = new Program();

        public class Log_Program_id:ValSet
           { 
             public const string name = "Log_Program_id";
             public int Log_Program_id_
             {
                get {return (int) obj;}
                set {obj = value;}
             }
           }
           public Log_Program_id o_Log_Program_id = new Log_Program_id();

        public class LogFile_Description:ValSet
           { 
             public const string name = "LogFile_Description";
             public string LogFile_Description_
             {
                get {return (string) obj;}
                set {obj = value;}
             }
           }
           public LogFile_Description o_LogFile_Description = new LogFile_Description();

        public class LogFile_Description_id:ValSet
           { 
             public const string name = "LogFile_Description_id";
             public int LogFile_Description_id_
             {
                get {return (int) obj;}
                set {obj = value;}
             }
           }
           public LogFile_Description_id o_LogFile_Description_id = new LogFile_Description_id();


        public Log_VIEW(Log_DBConnection xcon)
           {
                select = new selection(this);
                where  = new WHERE(this);
                m_con = xcon;
                tablename = Log_VIEW.tablename_const;
                myUpdateObjects = UpdateObjects;


                    o_LogFile_id.col_name = Log_VIEW.LogFile_id.name;
                    o_LogFile_id.col_type.m_Type = "int";
                    Add(o_LogFile_id);
                    
                    o_Log_Time.col_name = Log_VIEW.Log_Time.name;
                    o_Log_Time.col_type.m_Type = "datetime";
                    Add(o_Log_Time);
                    
                    o_Log_TypeName.col_name = Log_VIEW.Log_TypeName.name;
                    o_Log_TypeName.col_type.m_Type = "nvarchar";
                    Add(o_Log_TypeName);
                    
                    o_Log_Type_id.col_name = Log_VIEW.Log_Type_id.name;
                    o_Log_Type_id.col_type.m_Type = "int";
                    Add(o_Log_Type_id);
                    
                    o_Log_Description.col_name = Log_VIEW.Log_Description.name;
                    o_Log_Description.col_type.m_Type = "nvarchar";
                    Add(o_Log_Description);
                    
                    o_Log_Description_id.col_name = Log_VIEW.Log_Description_id.name;
                    o_Log_Description_id.col_type.m_Type = "int";
                    Add(o_Log_Description_id);
                    
                    o_ComputerName.col_name = Log_VIEW.ComputerName.name;
                    o_ComputerName.col_type.m_Type = "nvarchar";
                    Add(o_ComputerName);
                    
                    o_Log_Computer_id.col_name = Log_VIEW.Log_Computer_id.name;
                    o_Log_Computer_id.col_type.m_Type = "int";
                    Add(o_Log_Computer_id);
                    
                    o_UserName.col_name = Log_VIEW.UserName.name;
                    o_UserName.col_type.m_Type = "nvarchar";
                    Add(o_UserName);
                    
                    o_Log_UserName_id.col_name = Log_VIEW.Log_UserName_id.name;
                    o_Log_UserName_id.col_type.m_Type = "int";
                    Add(o_Log_UserName_id);
                    
                    o_Program.col_name = Log_VIEW.Program.name;
                    o_Program.col_type.m_Type = "nvarchar";
                    Add(o_Program);
                    
                    o_Log_Program_id.col_name = Log_VIEW.Log_Program_id.name;
                    o_Log_Program_id.col_type.m_Type = "int";
                    Add(o_Log_Program_id);
                    
                    o_LogFile_Description.col_name = Log_VIEW.LogFile_Description.name;
                    o_LogFile_Description.col_type.m_Type = "nvarchar";
                    Add(o_LogFile_Description);
                    
                    o_LogFile_Description_id.col_name = Log_VIEW.LogFile_Description_id.name;
                    o_LogFile_Description_id.col_type.m_Type = "int";
                    Add(o_LogFile_Description_id);
                    
           }

        public class selection
           {
                private Log_VIEW m_Log_VIEW;
                public selection(Log_VIEW xLog_VIEW)
                {
                    m_Log_VIEW =  xLog_VIEW;
                }

                    public bool LogFile_id
                    {
                        get {return m_Log_VIEW.o_LogFile_id.Select.enabled;}
                        set {m_Log_VIEW.o_LogFile_id.Select.enabled = value;}
                    }
                    
                    public void LogFile_id_Expression(string Expression,string xalternate_column_name)
                    {
                        m_Log_VIEW.o_LogFile_id.Select.expression = Expression;
                        m_Log_VIEW.o_LogFile_id.Select.alternate_column_name = xalternate_column_name;
                    }
                    
                    public bool Log_Time
                    {
                        get {return m_Log_VIEW.o_Log_Time.Select.enabled;}
                        set {m_Log_VIEW.o_Log_Time.Select.enabled = value;}
                    }
                    
                    public void Log_Time_Expression(string Expression,string xalternate_column_name)
                    {
                        m_Log_VIEW.o_Log_Time.Select.expression = Expression;
                        m_Log_VIEW.o_Log_Time.Select.alternate_column_name = xalternate_column_name;
                    }
                    
                    public bool Log_TypeName
                    {
                        get {return m_Log_VIEW.o_Log_TypeName.Select.enabled;}
                        set {m_Log_VIEW.o_Log_TypeName.Select.enabled = value;}
                    }
                    
                    public void Log_TypeName_Expression(string Expression,string xalternate_column_name)
                    {
                        m_Log_VIEW.o_Log_TypeName.Select.expression = Expression;
                        m_Log_VIEW.o_Log_TypeName.Select.alternate_column_name = xalternate_column_name;
                    }
                    
                    public bool Log_Type_id
                    {
                        get {return m_Log_VIEW.o_Log_Type_id.Select.enabled;}
                        set {m_Log_VIEW.o_Log_Type_id.Select.enabled = value;}
                    }
                    
                    public void Log_Type_id_Expression(string Expression,string xalternate_column_name)
                    {
                        m_Log_VIEW.o_Log_Type_id.Select.expression = Expression;
                        m_Log_VIEW.o_Log_Type_id.Select.alternate_column_name = xalternate_column_name;
                    }
                    
                    public bool Log_Description
                    {
                        get {return m_Log_VIEW.o_Log_Description.Select.enabled;}
                        set {m_Log_VIEW.o_Log_Description.Select.enabled = value;}
                    }
                    
                    public void Log_Description_Expression(string Expression,string xalternate_column_name)
                    {
                        m_Log_VIEW.o_Log_Description.Select.expression = Expression;
                        m_Log_VIEW.o_Log_Description.Select.alternate_column_name = xalternate_column_name;
                    }
                    
                    public bool Log_Description_id
                    {
                        get {return m_Log_VIEW.o_Log_Description_id.Select.enabled;}
                        set {m_Log_VIEW.o_Log_Description_id.Select.enabled = value;}
                    }
                    
                    public void Log_Description_id_Expression(string Expression,string xalternate_column_name)
                    {
                        m_Log_VIEW.o_Log_Description_id.Select.expression = Expression;
                        m_Log_VIEW.o_Log_Description_id.Select.alternate_column_name = xalternate_column_name;
                    }
                    
                    public bool ComputerName
                    {
                        get {return m_Log_VIEW.o_ComputerName.Select.enabled;}
                        set {m_Log_VIEW.o_ComputerName.Select.enabled = value;}
                    }
                    
                    public void ComputerName_Expression(string Expression,string xalternate_column_name)
                    {
                        m_Log_VIEW.o_ComputerName.Select.expression = Expression;
                        m_Log_VIEW.o_ComputerName.Select.alternate_column_name = xalternate_column_name;
                    }
                    
                    public bool Log_Computer_id
                    {
                        get {return m_Log_VIEW.o_Log_Computer_id.Select.enabled;}
                        set {m_Log_VIEW.o_Log_Computer_id.Select.enabled = value;}
                    }
                    
                    public void Log_Computer_id_Expression(string Expression,string xalternate_column_name)
                    {
                        m_Log_VIEW.o_Log_Computer_id.Select.expression = Expression;
                        m_Log_VIEW.o_Log_Computer_id.Select.alternate_column_name = xalternate_column_name;
                    }
                    
                    public bool UserName
                    {
                        get {return m_Log_VIEW.o_UserName.Select.enabled;}
                        set {m_Log_VIEW.o_UserName.Select.enabled = value;}
                    }
                    
                    public void UserName_Expression(string Expression,string xalternate_column_name)
                    {
                        m_Log_VIEW.o_UserName.Select.expression = Expression;
                        m_Log_VIEW.o_UserName.Select.alternate_column_name = xalternate_column_name;
                    }
                    
                    public bool Log_UserName_id
                    {
                        get {return m_Log_VIEW.o_Log_UserName_id.Select.enabled;}
                        set {m_Log_VIEW.o_Log_UserName_id.Select.enabled = value;}
                    }
                    
                    public void Log_UserName_id_Expression(string Expression,string xalternate_column_name)
                    {
                        m_Log_VIEW.o_Log_UserName_id.Select.expression = Expression;
                        m_Log_VIEW.o_Log_UserName_id.Select.alternate_column_name = xalternate_column_name;
                    }
                    
                    public bool Program
                    {
                        get {return m_Log_VIEW.o_Program.Select.enabled;}
                        set {m_Log_VIEW.o_Program.Select.enabled = value;}
                    }
                    
                    public void Program_Expression(string Expression,string xalternate_column_name)
                    {
                        m_Log_VIEW.o_Program.Select.expression = Expression;
                        m_Log_VIEW.o_Program.Select.alternate_column_name = xalternate_column_name;
                    }
                    
                    public bool Log_Program_id
                    {
                        get {return m_Log_VIEW.o_Log_Program_id.Select.enabled;}
                        set {m_Log_VIEW.o_Log_Program_id.Select.enabled = value;}
                    }
                    
                    public void Log_Program_id_Expression(string Expression,string xalternate_column_name)
                    {
                        m_Log_VIEW.o_Log_Program_id.Select.expression = Expression;
                        m_Log_VIEW.o_Log_Program_id.Select.alternate_column_name = xalternate_column_name;
                    }
                    
                    public bool LogFile_Description
                    {
                        get {return m_Log_VIEW.o_LogFile_Description.Select.enabled;}
                        set {m_Log_VIEW.o_LogFile_Description.Select.enabled = value;}
                    }
                    
                    public void LogFile_Description_Expression(string Expression,string xalternate_column_name)
                    {
                        m_Log_VIEW.o_LogFile_Description.Select.expression = Expression;
                        m_Log_VIEW.o_LogFile_Description.Select.alternate_column_name = xalternate_column_name;
                    }
                    
                    public bool LogFile_Description_id
                    {
                        get {return m_Log_VIEW.o_LogFile_Description_id.Select.enabled;}
                        set {m_Log_VIEW.o_LogFile_Description_id.Select.enabled = value;}
                    }
                    
                    public void LogFile_Description_id_Expression(string Expression,string xalternate_column_name)
                    {
                        m_Log_VIEW.o_LogFile_Description_id.Select.expression = Expression;
                        m_Log_VIEW.o_LogFile_Description_id.Select.alternate_column_name = xalternate_column_name;
                    }
                    
               public void all(bool bVal)
               {

                    this.LogFile_id = bVal;
                    
                    this.Log_Time = bVal;
                    
                    this.Log_TypeName = bVal;
                    
                    this.Log_Type_id = bVal;
                    
                    this.Log_Description = bVal;
                    
                    this.Log_Description_id = bVal;
                    
                    this.ComputerName = bVal;
                    
                    this.Log_Computer_id = bVal;
                    
                    this.UserName = bVal;
                    
                    this.Log_UserName_id = bVal;
                    
                    this.Program = bVal;
                    
                    this.Log_Program_id = bVal;
                    
                    this.LogFile_Description = bVal;
                    
                    this.LogFile_Description_id = bVal;
                    
                    
               }
    
           }

        public class WHERE
           {
                private Log_VIEW m_Log_VIEW;
                public WHERE(Log_VIEW xLog_VIEW)
                {
                    m_Log_VIEW =  xLog_VIEW;
                }

                    public bool LogFile_id
                    {
                        get {return m_Log_VIEW.o_LogFile_id.Where.enabled;}
                        set {m_Log_VIEW.o_LogFile_id.Where.enabled = value;}
                    }
                    
                    public void LogFile_id_Expression(string Expression)
                    {
                        m_Log_VIEW.o_LogFile_id.Where.expression = Expression;
                    }
                    

                    public void LogFile_id_AddParameter(Log_SQL_Parameter par)
                    {
                        m_Log_VIEW.o_LogFile_id.Where.AddParameter(par);
                    }
                    
                    public bool Log_Time
                    {
                        get {return m_Log_VIEW.o_Log_Time.Where.enabled;}
                        set {m_Log_VIEW.o_Log_Time.Where.enabled = value;}
                    }
                    
                    public void Log_Time_Expression(string Expression)
                    {
                        m_Log_VIEW.o_Log_Time.Where.expression = Expression;
                    }
                    

                    public void Log_Time_AddParameter(Log_SQL_Parameter par)
                    {
                        m_Log_VIEW.o_Log_Time.Where.AddParameter(par);
                    }
                    
                    public bool Log_TypeName
                    {
                        get {return m_Log_VIEW.o_Log_TypeName.Where.enabled;}
                        set {m_Log_VIEW.o_Log_TypeName.Where.enabled = value;}
                    }
                    
                    public void Log_TypeName_Expression(string Expression)
                    {
                        m_Log_VIEW.o_Log_TypeName.Where.expression = Expression;
                    }
                    

                    public void Log_TypeName_AddParameter(Log_SQL_Parameter par)
                    {
                        m_Log_VIEW.o_Log_TypeName.Where.AddParameter(par);
                    }
                    
                    public bool Log_Type_id
                    {
                        get {return m_Log_VIEW.o_Log_Type_id.Where.enabled;}
                        set {m_Log_VIEW.o_Log_Type_id.Where.enabled = value;}
                    }
                    
                    public void Log_Type_id_Expression(string Expression)
                    {
                        m_Log_VIEW.o_Log_Type_id.Where.expression = Expression;
                    }
                    

                    public void Log_Type_id_AddParameter(Log_SQL_Parameter par)
                    {
                        m_Log_VIEW.o_Log_Type_id.Where.AddParameter(par);
                    }
                    
                    public bool Log_Description
                    {
                        get {return m_Log_VIEW.o_Log_Description.Where.enabled;}
                        set {m_Log_VIEW.o_Log_Description.Where.enabled = value;}
                    }
                    
                    public void Log_Description_Expression(string Expression)
                    {
                        m_Log_VIEW.o_Log_Description.Where.expression = Expression;
                    }
                    

                    public void Log_Description_AddParameter(Log_SQL_Parameter par)
                    {
                        m_Log_VIEW.o_Log_Description.Where.AddParameter(par);
                    }
                    
                    public bool Log_Description_id
                    {
                        get {return m_Log_VIEW.o_Log_Description_id.Where.enabled;}
                        set {m_Log_VIEW.o_Log_Description_id.Where.enabled = value;}
                    }
                    
                    public void Log_Description_id_Expression(string Expression)
                    {
                        m_Log_VIEW.o_Log_Description_id.Where.expression = Expression;
                    }
                    

                    public void Log_Description_id_AddParameter(Log_SQL_Parameter par)
                    {
                        m_Log_VIEW.o_Log_Description_id.Where.AddParameter(par);
                    }
                    
                    public bool ComputerName
                    {
                        get {return m_Log_VIEW.o_ComputerName.Where.enabled;}
                        set {m_Log_VIEW.o_ComputerName.Where.enabled = value;}
                    }
                    
                    public void ComputerName_Expression(string Expression)
                    {
                        m_Log_VIEW.o_ComputerName.Where.expression = Expression;
                    }
                    

                    public void ComputerName_AddParameter(Log_SQL_Parameter par)
                    {
                        m_Log_VIEW.o_ComputerName.Where.AddParameter(par);
                    }
                    
                    public bool Log_Computer_id
                    {
                        get {return m_Log_VIEW.o_Log_Computer_id.Where.enabled;}
                        set {m_Log_VIEW.o_Log_Computer_id.Where.enabled = value;}
                    }
                    
                    public void Log_Computer_id_Expression(string Expression)
                    {
                        m_Log_VIEW.o_Log_Computer_id.Where.expression = Expression;
                    }
                    

                    public void Log_Computer_id_AddParameter(Log_SQL_Parameter par)
                    {
                        m_Log_VIEW.o_Log_Computer_id.Where.AddParameter(par);
                    }
                    
                    public bool UserName
                    {
                        get {return m_Log_VIEW.o_UserName.Where.enabled;}
                        set {m_Log_VIEW.o_UserName.Where.enabled = value;}
                    }
                    
                    public void UserName_Expression(string Expression)
                    {
                        m_Log_VIEW.o_UserName.Where.expression = Expression;
                    }
                    

                    public void UserName_AddParameter(Log_SQL_Parameter par)
                    {
                        m_Log_VIEW.o_UserName.Where.AddParameter(par);
                    }
                    
                    public bool Log_UserName_id
                    {
                        get {return m_Log_VIEW.o_Log_UserName_id.Where.enabled;}
                        set {m_Log_VIEW.o_Log_UserName_id.Where.enabled = value;}
                    }
                    
                    public void Log_UserName_id_Expression(string Expression)
                    {
                        m_Log_VIEW.o_Log_UserName_id.Where.expression = Expression;
                    }
                    

                    public void Log_UserName_id_AddParameter(Log_SQL_Parameter par)
                    {
                        m_Log_VIEW.o_Log_UserName_id.Where.AddParameter(par);
                    }
                    
                    public bool Program
                    {
                        get {return m_Log_VIEW.o_Program.Where.enabled;}
                        set {m_Log_VIEW.o_Program.Where.enabled = value;}
                    }
                    
                    public void Program_Expression(string Expression)
                    {
                        m_Log_VIEW.o_Program.Where.expression = Expression;
                    }
                    

                    public void Program_AddParameter(Log_SQL_Parameter par)
                    {
                        m_Log_VIEW.o_Program.Where.AddParameter(par);
                    }
                    
                    public bool Log_Program_id
                    {
                        get {return m_Log_VIEW.o_Log_Program_id.Where.enabled;}
                        set {m_Log_VIEW.o_Log_Program_id.Where.enabled = value;}
                    }
                    
                    public void Log_Program_id_Expression(string Expression)
                    {
                        m_Log_VIEW.o_Log_Program_id.Where.expression = Expression;
                    }
                    

                    public void Log_Program_id_AddParameter(Log_SQL_Parameter par)
                    {
                        m_Log_VIEW.o_Log_Program_id.Where.AddParameter(par);
                    }
                    
                    public bool LogFile_Description
                    {
                        get {return m_Log_VIEW.o_LogFile_Description.Where.enabled;}
                        set {m_Log_VIEW.o_LogFile_Description.Where.enabled = value;}
                    }
                    
                    public void LogFile_Description_Expression(string Expression)
                    {
                        m_Log_VIEW.o_LogFile_Description.Where.expression = Expression;
                    }
                    

                    public void LogFile_Description_AddParameter(Log_SQL_Parameter par)
                    {
                        m_Log_VIEW.o_LogFile_Description.Where.AddParameter(par);
                    }
                    
                    public bool LogFile_Description_id
                    {
                        get {return m_Log_VIEW.o_LogFile_Description_id.Where.enabled;}
                        set {m_Log_VIEW.o_LogFile_Description_id.Where.enabled = value;}
                    }
                    
                    public void LogFile_Description_id_Expression(string Expression)
                    {
                        m_Log_VIEW.o_LogFile_Description_id.Where.expression = Expression;
                    }
                    

                    public void LogFile_Description_id_AddParameter(Log_SQL_Parameter par)
                    {
                        m_Log_VIEW.o_LogFile_Description_id.Where.AddParameter(par);
                    }
                    
                    
               public void all(bool bVal)
               {

                    this.LogFile_id = bVal;
                    
                    this.Log_Time = bVal;
                    
                    this.Log_TypeName = bVal;
                    
                    this.Log_Type_id = bVal;
                    
                    this.Log_Description = bVal;
                    
                    this.Log_Description_id = bVal;
                    
                    this.ComputerName = bVal;
                    
                    this.Log_Computer_id = bVal;
                    
                    this.UserName = bVal;
                    
                    this.Log_UserName_id = bVal;
                    
                    this.Program = bVal;
                    
                    this.Log_Program_id = bVal;
                    
                    this.LogFile_Description = bVal;
                    
                    this.LogFile_Description_id = bVal;
                    
               }
    
           }

        public void UpdateObjects(DataRow dr)
           {

                    if (o_LogFile_id.Select.enabled)
                    {
                      if (dr[Log_VIEW.LogFile_id.name] != null)
                      {
                        if (dr[Log_VIEW.LogFile_id.name].GetType() != typeof(System.DBNull))
                        {
                        o_LogFile_id.obj  =  dr[Log_VIEW.LogFile_id.name];
                        }
                      }
                    }
                    if (o_Log_Time.Select.enabled)
                    {
                      if (dr[Log_VIEW.Log_Time.name] != null)
                      {
                        if (dr[Log_VIEW.Log_Time.name].GetType() != typeof(System.DBNull))
                        {
                        o_Log_Time.obj  =  dr[Log_VIEW.Log_Time.name];
                        }
                      }
                    }
                    if (o_Log_TypeName.Select.enabled)
                    {
                      if (dr[Log_VIEW.Log_TypeName.name] != null)
                      {
                        if (dr[Log_VIEW.Log_TypeName.name].GetType() != typeof(System.DBNull))
                        {
                        o_Log_TypeName.obj  =  dr[Log_VIEW.Log_TypeName.name];
                        }
                      }
                    }
                    if (o_Log_Type_id.Select.enabled)
                    {
                      if (dr[Log_VIEW.Log_Type_id.name] != null)
                      {
                        if (dr[Log_VIEW.Log_Type_id.name].GetType() != typeof(System.DBNull))
                        {
                        o_Log_Type_id.obj  =  dr[Log_VIEW.Log_Type_id.name];
                        }
                      }
                    }
                    if (o_Log_Description.Select.enabled)
                    {
                      if (dr[Log_VIEW.Log_Description.name] != null)
                      {
                        if (dr[Log_VIEW.Log_Description.name].GetType() != typeof(System.DBNull))
                        {
                        o_Log_Description.obj  =  dr[Log_VIEW.Log_Description.name];
                        }
                      }
                    }
                    if (o_Log_Description_id.Select.enabled)
                    {
                      if (dr[Log_VIEW.Log_Description_id.name] != null)
                      {
                        if (dr[Log_VIEW.Log_Description_id.name].GetType() != typeof(System.DBNull))
                        {
                        o_Log_Description_id.obj  =  dr[Log_VIEW.Log_Description_id.name];
                        }
                      }
                    }
                    if (o_ComputerName.Select.enabled)
                    {
                      if (dr[Log_VIEW.ComputerName.name] != null)
                      {
                        if (dr[Log_VIEW.ComputerName.name].GetType() != typeof(System.DBNull))
                        {
                        o_ComputerName.obj  =  dr[Log_VIEW.ComputerName.name];
                        }
                      }
                    }
                    if (o_Log_Computer_id.Select.enabled)
                    {
                      if (dr[Log_VIEW.Log_Computer_id.name] != null)
                      {
                        if (dr[Log_VIEW.Log_Computer_id.name].GetType() != typeof(System.DBNull))
                        {
                        o_Log_Computer_id.obj  =  dr[Log_VIEW.Log_Computer_id.name];
                        }
                      }
                    }
                    if (o_UserName.Select.enabled)
                    {
                      if (dr[Log_VIEW.UserName.name] != null)
                      {
                        if (dr[Log_VIEW.UserName.name].GetType() != typeof(System.DBNull))
                        {
                        o_UserName.obj  =  dr[Log_VIEW.UserName.name];
                        }
                      }
                    }
                    if (o_Log_UserName_id.Select.enabled)
                    {
                      if (dr[Log_VIEW.Log_UserName_id.name] != null)
                      {
                        if (dr[Log_VIEW.Log_UserName_id.name].GetType() != typeof(System.DBNull))
                        {
                        o_Log_UserName_id.obj  =  dr[Log_VIEW.Log_UserName_id.name];
                        }
                      }
                    }
                    if (o_Program.Select.enabled)
                    {
                      if (dr[Log_VIEW.Program.name] != null)
                      {
                        if (dr[Log_VIEW.Program.name].GetType() != typeof(System.DBNull))
                        {
                        o_Program.obj  =  dr[Log_VIEW.Program.name];
                        }
                      }
                    }
                    if (o_Log_Program_id.Select.enabled)
                    {
                      if (dr[Log_VIEW.Log_Program_id.name] != null)
                      {
                        if (dr[Log_VIEW.Log_Program_id.name].GetType() != typeof(System.DBNull))
                        {
                        o_Log_Program_id.obj  =  dr[Log_VIEW.Log_Program_id.name];
                        }
                      }
                    }
                    if (o_LogFile_Description.Select.enabled)
                    {
                      if (dr[Log_VIEW.LogFile_Description.name] != null)
                      {
                        if (dr[Log_VIEW.LogFile_Description.name].GetType() != typeof(System.DBNull))
                        {
                        o_LogFile_Description.obj  =  dr[Log_VIEW.LogFile_Description.name];
                        }
                      }
                    }
                    if (o_LogFile_Description_id.Select.enabled)
                    {
                      if (dr[Log_VIEW.LogFile_Description_id.name] != null)
                      {
                        if (dr[Log_VIEW.LogFile_Description_id.name].GetType() != typeof(System.DBNull))
                        {
                        o_LogFile_Description_id.obj  =  dr[Log_VIEW.LogFile_Description_id.name];
                        }
                      }
                    }
           }

    }

    public class LogFile_VIEW : XView
    {
        public const string tablename_const = "LogFile_VIEW";
        public selection select;
        public WHERE where;
        public int RowsCount
        {
            get { return RowsCount(); }
        }
        public void Clear()
        {
            clear();
        }

        public bool Read(int Limit, ref string csError)
        {
            bool bRead = read(Limit, ref csError);
            if (Cursor >= 0)
            {
                UpdateObjects(dt.Rows[Cursor]);
            }
            return bRead;
        }

        public class id : ValSet
        {
            public const string name = "id";
            public int id_
            {
                get { return (int)obj; }
                set { obj = value; }
            }
        }
        public id o_id = new id();

        public class LogFileImportTime : ValSet
        {
            public const string name = "LogFileImportTime";
            public DateTime LogFileImportTime_
            {
                get { return (DateTime)obj; }
                set { obj = value; }
            }
        }
        public LogFileImportTime o_LogFileImportTime = new LogFileImportTime();

        public class ComputerName : ValSet
        {
            public const string name = "ComputerName";
            public string ComputerName_
            {
                get { return (string)obj; }
                set { obj = value; }
            }
        }
        public ComputerName o_ComputerName = new ComputerName();

        public class Description : ValSet
        {
            public const string name = "Description";
            public string Description_
            {
                get { return (string)obj; }
                set { obj = value; }
            }
        }
        public Description o_Description = new Description();

        public class Program : ValSet
        {
            public const string name = "Program";
            public string Program_
            {
                get { return (string)obj; }
                set { obj = value; }
            }
        }
        public Program o_Program = new Program();

        public class PathFile : ValSet
        {
            public const string name = "PathFile";
            public string PathFile_
            {
                get { return (string)obj; }
                set { obj = value; }
            }
        }
        public PathFile o_PathFile = new PathFile();

        public class UserName : ValSet
        {
            public const string name = "UserName";
            public string UserName_
            {
                get { return (string)obj; }
                set { obj = value; }
            }
        }
        public UserName o_UserName = new UserName();

        public class Log_Computer_id : ValSet
        {
            public const string name = "Log_Computer_id";
            public int Log_Computer_id_
            {
                get { return (int)obj; }
                set { obj = value; }
            }
        }
        public Log_Computer_id o_Log_Computer_id = new Log_Computer_id();

        public class Log_UserName_id : ValSet
        {
            public const string name = "Log_UserName_id";
            public int Log_UserName_id_
            {
                get { return (int)obj; }
                set { obj = value; }
            }
        }
        public Log_UserName_id o_Log_UserName_id = new Log_UserName_id();

        public class Log_Program_id : ValSet
        {
            public const string name = "Log_Program_id";
            public int Log_Program_id_
            {
                get { return (int)obj; }
                set { obj = value; }
            }
        }
        public Log_Program_id o_Log_Program_id = new Log_Program_id();

        public class LogFile_Description_id : ValSet
        {
            public const string name = "LogFile_Description_id";
            public int LogFile_Description_id_
            {
                get { return (int)obj; }
                set { obj = value; }
            }
        }
        public LogFile_Description_id o_LogFile_Description_id = new LogFile_Description_id();

        public class Log_PathFile_id : ValSet
        {
            public const string name = "Log_PathFile_id";
            public int Log_PathFile_id_
            {
                get { return (int)obj; }
                set { obj = value; }
            }
        }
        public Log_PathFile_id o_Log_PathFile_id = new Log_PathFile_id();

        public LogFile_VIEW(Log_DBConnection xcon)
        {
            select = new selection(this);
            where = new WHERE(this);
            m_con = xcon;
            tablename = LogFile_VIEW.tablename_const;
            myUpdateObjects = UpdateObjects;


            o_id.col_name = LogFile_VIEW.id.name;
            o_id.col_type.m_Type = "int";
            Add(o_id);

            o_LogFileImportTime.col_name = LogFile_VIEW.LogFileImportTime.name;
            o_LogFileImportTime.col_type.m_Type = "datetime";
            Add(o_LogFileImportTime);

            o_ComputerName.col_name = LogFile_VIEW.ComputerName.name;
            o_ComputerName.col_type.m_Type = "nvarchar";
            Add(o_ComputerName);

            o_Description.col_name = LogFile_VIEW.Description.name;
            o_Description.col_type.m_Type = "nvarchar";
            Add(o_Description);

            o_Program.col_name = LogFile_VIEW.Program.name;
            o_Program.col_type.m_Type = "nvarchar";
            Add(o_Program);

            o_PathFile.col_name = LogFile_VIEW.PathFile.name;
            o_PathFile.col_type.m_Type = "nvarchar";
            Add(o_PathFile);

            o_UserName.col_name = LogFile_VIEW.UserName.name;
            o_UserName.col_type.m_Type = "nvarchar";
            Add(o_UserName);

            o_Log_Computer_id.col_name = LogFile_VIEW.Log_Computer_id.name;
            o_Log_Computer_id.col_type.m_Type = "int";
            Add(o_Log_Computer_id);

            o_Log_UserName_id.col_name = LogFile_VIEW.Log_UserName_id.name;
            o_Log_UserName_id.col_type.m_Type = "int";
            Add(o_Log_UserName_id);

            o_Log_Program_id.col_name = LogFile_VIEW.Log_Program_id.name;
            o_Log_Program_id.col_type.m_Type = "int";
            Add(o_Log_Program_id);

            o_LogFile_Description_id.col_name = LogFile_VIEW.LogFile_Description_id.name;
            o_LogFile_Description_id.col_type.m_Type = "int";
            Add(o_LogFile_Description_id);

            o_Log_PathFile_id.col_name = LogFile_VIEW.Log_PathFile_id.name;
            o_Log_PathFile_id.col_type.m_Type = "int";
            Add(o_Log_PathFile_id);

        }

        public class selection
        {
            private LogFile_VIEW m_LogFile_VIEW;
            public selection(LogFile_VIEW xLogFile_VIEW)
            {
                m_LogFile_VIEW = xLogFile_VIEW;
            }

            public bool id
            {
                get { return m_LogFile_VIEW.o_id.Select.enabled; }
                set { m_LogFile_VIEW.o_id.Select.enabled = value; }
            }

            public void id_Expression(string Expression, string xalternate_column_name)
            {
                m_LogFile_VIEW.o_id.Select.expression = Expression;
                m_LogFile_VIEW.o_id.Select.alternate_column_name = xalternate_column_name;
            }

            public bool LogFileImportTime
            {
                get { return m_LogFile_VIEW.o_LogFileImportTime.Select.enabled; }
                set { m_LogFile_VIEW.o_LogFileImportTime.Select.enabled = value; }
            }

            public void LogFileImportTime_Expression(string Expression, string xalternate_column_name)
            {
                m_LogFile_VIEW.o_LogFileImportTime.Select.expression = Expression;
                m_LogFile_VIEW.o_LogFileImportTime.Select.alternate_column_name = xalternate_column_name;
            }

            public bool ComputerName
            {
                get { return m_LogFile_VIEW.o_ComputerName.Select.enabled; }
                set { m_LogFile_VIEW.o_ComputerName.Select.enabled = value; }
            }

            public void ComputerName_Expression(string Expression, string xalternate_column_name)
            {
                m_LogFile_VIEW.o_ComputerName.Select.expression = Expression;
                m_LogFile_VIEW.o_ComputerName.Select.alternate_column_name = xalternate_column_name;
            }

            public bool Description
            {
                get { return m_LogFile_VIEW.o_Description.Select.enabled; }
                set { m_LogFile_VIEW.o_Description.Select.enabled = value; }
            }

            public void Description_Expression(string Expression, string xalternate_column_name)
            {
                m_LogFile_VIEW.o_Description.Select.expression = Expression;
                m_LogFile_VIEW.o_Description.Select.alternate_column_name = xalternate_column_name;
            }

            public bool Program
            {
                get { return m_LogFile_VIEW.o_Program.Select.enabled; }
                set { m_LogFile_VIEW.o_Program.Select.enabled = value; }
            }

            public void Program_Expression(string Expression, string xalternate_column_name)
            {
                m_LogFile_VIEW.o_Program.Select.expression = Expression;
                m_LogFile_VIEW.o_Program.Select.alternate_column_name = xalternate_column_name;
            }

            public bool PathFile
            {
                get { return m_LogFile_VIEW.o_PathFile.Select.enabled; }
                set { m_LogFile_VIEW.o_PathFile.Select.enabled = value; }
            }

            public void PathFile_Expression(string Expression, string xalternate_column_name)
            {
                m_LogFile_VIEW.o_PathFile.Select.expression = Expression;
                m_LogFile_VIEW.o_PathFile.Select.alternate_column_name = xalternate_column_name;
            }

            public bool UserName
            {
                get { return m_LogFile_VIEW.o_UserName.Select.enabled; }
                set { m_LogFile_VIEW.o_UserName.Select.enabled = value; }
            }

            public void UserName_Expression(string Expression, string xalternate_column_name)
            {
                m_LogFile_VIEW.o_UserName.Select.expression = Expression;
                m_LogFile_VIEW.o_UserName.Select.alternate_column_name = xalternate_column_name;
            }

            public bool Log_Computer_id
            {
                get { return m_LogFile_VIEW.o_Log_Computer_id.Select.enabled; }
                set { m_LogFile_VIEW.o_Log_Computer_id.Select.enabled = value; }
            }

            public void Log_Computer_id_Expression(string Expression, string xalternate_column_name)
            {
                m_LogFile_VIEW.o_Log_Computer_id.Select.expression = Expression;
                m_LogFile_VIEW.o_Log_Computer_id.Select.alternate_column_name = xalternate_column_name;
            }

            public bool Log_UserName_id
            {
                get { return m_LogFile_VIEW.o_Log_UserName_id.Select.enabled; }
                set { m_LogFile_VIEW.o_Log_UserName_id.Select.enabled = value; }
            }

            public void Log_UserName_id_Expression(string Expression, string xalternate_column_name)
            {
                m_LogFile_VIEW.o_Log_UserName_id.Select.expression = Expression;
                m_LogFile_VIEW.o_Log_UserName_id.Select.alternate_column_name = xalternate_column_name;
            }

            public bool Log_Program_id
            {
                get { return m_LogFile_VIEW.o_Log_Program_id.Select.enabled; }
                set { m_LogFile_VIEW.o_Log_Program_id.Select.enabled = value; }
            }

            public void Log_Program_id_Expression(string Expression, string xalternate_column_name)
            {
                m_LogFile_VIEW.o_Log_Program_id.Select.expression = Expression;
                m_LogFile_VIEW.o_Log_Program_id.Select.alternate_column_name = xalternate_column_name;
            }

            public bool LogFile_Description_id
            {
                get { return m_LogFile_VIEW.o_LogFile_Description_id.Select.enabled; }
                set { m_LogFile_VIEW.o_LogFile_Description_id.Select.enabled = value; }
            }

            public void LogFile_Description_id_Expression(string Expression, string xalternate_column_name)
            {
                m_LogFile_VIEW.o_LogFile_Description_id.Select.expression = Expression;
                m_LogFile_VIEW.o_LogFile_Description_id.Select.alternate_column_name = xalternate_column_name;
            }

            public bool Log_PathFile_id
            {
                get { return m_LogFile_VIEW.o_Log_PathFile_id.Select.enabled; }
                set { m_LogFile_VIEW.o_Log_PathFile_id.Select.enabled = value; }
            }

            public void Log_PathFile_id_Expression(string Expression, string xalternate_column_name)
            {
                m_LogFile_VIEW.o_Log_PathFile_id.Select.expression = Expression;
                m_LogFile_VIEW.o_Log_PathFile_id.Select.alternate_column_name = xalternate_column_name;
            }

            public void all(bool bVal)
            {

                this.id = bVal;

                this.LogFileImportTime = bVal;

                this.ComputerName = bVal;

                this.Description = bVal;

                this.Program = bVal;

                this.PathFile = bVal;

                this.UserName = bVal;

                this.Log_Computer_id = bVal;

                this.Log_UserName_id = bVal;

                this.Log_Program_id = bVal;

                this.LogFile_Description_id = bVal;

                this.Log_PathFile_id = bVal;

            }

        }

        public class WHERE
        {
            private LogFile_VIEW m_LogFile_VIEW;
            public WHERE(LogFile_VIEW xLogFile_VIEW)
            {
                m_LogFile_VIEW = xLogFile_VIEW;
            }

            public bool id
            {
                get { return m_LogFile_VIEW.o_id.Where.enabled; }
                set { m_LogFile_VIEW.o_id.Where.enabled = value; }
            }

            public void id_Expression(string Expression)
            {
                m_LogFile_VIEW.o_id.Where.expression = Expression;
            }


            public void id_AddParameter(Log_SQL_Parameter par)
            {
                m_LogFile_VIEW.o_id.Where.AddParameter(par);
            }

            public bool LogFileImportTime
            {
                get { return m_LogFile_VIEW.o_LogFileImportTime.Where.enabled; }
                set { m_LogFile_VIEW.o_LogFileImportTime.Where.enabled = value; }
            }

            public void LogFileImportTime_Expression(string Expression)
            {
                m_LogFile_VIEW.o_LogFileImportTime.Where.expression = Expression;
            }


            public void LogFileImportTime_AddParameter(Log_SQL_Parameter par)
            {
                m_LogFile_VIEW.o_LogFileImportTime.Where.AddParameter(par);
            }

            public bool ComputerName
            {
                get { return m_LogFile_VIEW.o_ComputerName.Where.enabled; }
                set { m_LogFile_VIEW.o_ComputerName.Where.enabled = value; }
            }

            public void ComputerName_Expression(string Expression)
            {
                m_LogFile_VIEW.o_ComputerName.Where.expression = Expression;
            }


            public void ComputerName_AddParameter(Log_SQL_Parameter par)
            {
                m_LogFile_VIEW.o_ComputerName.Where.AddParameter(par);
            }

            public bool Description
            {
                get { return m_LogFile_VIEW.o_Description.Where.enabled; }
                set { m_LogFile_VIEW.o_Description.Where.enabled = value; }
            }

            public void Description_Expression(string Expression)
            {
                m_LogFile_VIEW.o_Description.Where.expression = Expression;
            }


            public void Description_AddParameter(Log_SQL_Parameter par)
            {
                m_LogFile_VIEW.o_Description.Where.AddParameter(par);
            }

            public bool Program
            {
                get { return m_LogFile_VIEW.o_Program.Where.enabled; }
                set { m_LogFile_VIEW.o_Program.Where.enabled = value; }
            }

            public void Program_Expression(string Expression)
            {
                m_LogFile_VIEW.o_Program.Where.expression = Expression;
            }


            public void Program_AddParameter(Log_SQL_Parameter par)
            {
                m_LogFile_VIEW.o_Program.Where.AddParameter(par);
            }

            public bool PathFile
            {
                get { return m_LogFile_VIEW.o_PathFile.Where.enabled; }
                set { m_LogFile_VIEW.o_PathFile.Where.enabled = value; }
            }

            public void PathFile_Expression(string Expression)
            {
                m_LogFile_VIEW.o_PathFile.Where.expression = Expression;
            }


            public void PathFile_AddParameter(Log_SQL_Parameter par)
            {
                m_LogFile_VIEW.o_PathFile.Where.AddParameter(par);
            }

            public bool UserName
            {
                get { return m_LogFile_VIEW.o_UserName.Where.enabled; }
                set { m_LogFile_VIEW.o_UserName.Where.enabled = value; }
            }

            public void UserName_Expression(string Expression)
            {
                m_LogFile_VIEW.o_UserName.Where.expression = Expression;
            }


            public void UserName_AddParameter(Log_SQL_Parameter par)
            {
                m_LogFile_VIEW.o_UserName.Where.AddParameter(par);
            }

            public bool Log_Computer_id
            {
                get { return m_LogFile_VIEW.o_Log_Computer_id.Where.enabled; }
                set { m_LogFile_VIEW.o_Log_Computer_id.Where.enabled = value; }
            }

            public void Log_Computer_id_Expression(string Expression)
            {
                m_LogFile_VIEW.o_Log_Computer_id.Where.expression = Expression;
            }


            public void Log_Computer_id_AddParameter(Log_SQL_Parameter par)
            {
                m_LogFile_VIEW.o_Log_Computer_id.Where.AddParameter(par);
            }

            public bool Log_UserName_id
            {
                get { return m_LogFile_VIEW.o_Log_UserName_id.Where.enabled; }
                set { m_LogFile_VIEW.o_Log_UserName_id.Where.enabled = value; }
            }

            public void Log_UserName_id_Expression(string Expression)
            {
                m_LogFile_VIEW.o_Log_UserName_id.Where.expression = Expression;
            }


            public void Log_UserName_id_AddParameter(Log_SQL_Parameter par)
            {
                m_LogFile_VIEW.o_Log_UserName_id.Where.AddParameter(par);
            }

            public bool Log_Program_id
            {
                get { return m_LogFile_VIEW.o_Log_Program_id.Where.enabled; }
                set { m_LogFile_VIEW.o_Log_Program_id.Where.enabled = value; }
            }

            public void Log_Program_id_Expression(string Expression)
            {
                m_LogFile_VIEW.o_Log_Program_id.Where.expression = Expression;
            }


            public void Log_Program_id_AddParameter(Log_SQL_Parameter par)
            {
                m_LogFile_VIEW.o_Log_Program_id.Where.AddParameter(par);
            }

            public bool LogFile_Description_id
            {
                get { return m_LogFile_VIEW.o_LogFile_Description_id.Where.enabled; }
                set { m_LogFile_VIEW.o_LogFile_Description_id.Where.enabled = value; }
            }

            public void LogFile_Description_id_Expression(string Expression)
            {
                m_LogFile_VIEW.o_LogFile_Description_id.Where.expression = Expression;
            }


            public void LogFile_Description_id_AddParameter(Log_SQL_Parameter par)
            {
                m_LogFile_VIEW.o_LogFile_Description_id.Where.AddParameter(par);
            }

            public bool Log_PathFile_id
            {
                get { return m_LogFile_VIEW.o_Log_PathFile_id.Where.enabled; }
                set { m_LogFile_VIEW.o_Log_PathFile_id.Where.enabled = value; }
            }

            public void Log_PathFile_id_Expression(string Expression)
            {
                m_LogFile_VIEW.o_Log_PathFile_id.Where.expression = Expression;
            }


            public void Log_PathFile_id_AddParameter(Log_SQL_Parameter par)
            {
                m_LogFile_VIEW.o_Log_PathFile_id.Where.AddParameter(par);
            }

            public void all(bool bVal)
            {

                this.id = bVal;

                this.LogFileImportTime = bVal;

                this.ComputerName = bVal;

                this.Description = bVal;

                this.Program = bVal;

                this.PathFile = bVal;

                this.UserName = bVal;

                this.Log_Computer_id = bVal;

                this.Log_UserName_id = bVal;

                this.Log_Program_id = bVal;

                this.LogFile_Description_id = bVal;

                this.Log_PathFile_id = bVal;

            }

        }

        public void UpdateObjects(DataRow dr)
        {

            if (o_id.Select.enabled)
            {
                if (dr[LogFile_VIEW.id.name] != null)
                {
                    if (dr[LogFile_VIEW.id.name].GetType() != typeof(System.DBNull))
                    {
                        o_id.obj = dr[LogFile_VIEW.id.name];
                    }
                }
            }
            if (o_LogFileImportTime.Select.enabled)
            {
                if (dr[LogFile_VIEW.LogFileImportTime.name] != null)
                {
                    if (dr[LogFile_VIEW.LogFileImportTime.name].GetType() != typeof(System.DBNull))
                    {
                        o_LogFileImportTime.obj = dr[LogFile_VIEW.LogFileImportTime.name];
                    }
                }
            }
            if (o_ComputerName.Select.enabled)
            {
                if (dr[LogFile_VIEW.ComputerName.name] != null)
                {
                    if (dr[LogFile_VIEW.ComputerName.name].GetType() != typeof(System.DBNull))
                    {
                        o_ComputerName.obj = dr[LogFile_VIEW.ComputerName.name];
                    }
                }
            }
            if (o_Description.Select.enabled)
            {
                if (dr[LogFile_VIEW.Description.name] != null)
                {
                    if (dr[LogFile_VIEW.Description.name].GetType() != typeof(System.DBNull))
                    {
                        o_Description.obj = dr[LogFile_VIEW.Description.name];
                    }
                }
            }
            if (o_Program.Select.enabled)
            {
                if (dr[LogFile_VIEW.Program.name] != null)
                {
                    if (dr[LogFile_VIEW.Program.name].GetType() != typeof(System.DBNull))
                    {
                        o_Program.obj = dr[LogFile_VIEW.Program.name];
                    }
                }
            }
            if (o_PathFile.Select.enabled)
            {
                if (dr[LogFile_VIEW.PathFile.name] != null)
                {
                    if (dr[LogFile_VIEW.PathFile.name].GetType() != typeof(System.DBNull))
                    {
                        o_PathFile.obj = dr[LogFile_VIEW.PathFile.name];
                    }
                }
            }
            if (o_UserName.Select.enabled)
            {
                if (dr[LogFile_VIEW.UserName.name] != null)
                {
                    if (dr[LogFile_VIEW.UserName.name].GetType() != typeof(System.DBNull))
                    {
                        o_UserName.obj = dr[LogFile_VIEW.UserName.name];
                    }
                }
            }
            if (o_Log_Computer_id.Select.enabled)
            {
                if (dr[LogFile_VIEW.Log_Computer_id.name] != null)
                {
                    if (dr[LogFile_VIEW.Log_Computer_id.name].GetType() != typeof(System.DBNull))
                    {
                        o_Log_Computer_id.obj = dr[LogFile_VIEW.Log_Computer_id.name];
                    }
                }
            }
            if (o_Log_UserName_id.Select.enabled)
            {
                if (dr[LogFile_VIEW.Log_UserName_id.name] != null)
                {
                    if (dr[LogFile_VIEW.Log_UserName_id.name].GetType() != typeof(System.DBNull))
                    {
                        o_Log_UserName_id.obj = dr[LogFile_VIEW.Log_UserName_id.name];
                    }
                }
            }
            if (o_Log_Program_id.Select.enabled)
            {
                if (dr[LogFile_VIEW.Log_Program_id.name] != null)
                {
                    if (dr[LogFile_VIEW.Log_Program_id.name].GetType() != typeof(System.DBNull))
                    {
                        o_Log_Program_id.obj = dr[LogFile_VIEW.Log_Program_id.name];
                    }
                }
            }
            if (o_LogFile_Description_id.Select.enabled)
            {
                if (dr[LogFile_VIEW.LogFile_Description_id.name] != null)
                {
                    if (dr[LogFile_VIEW.LogFile_Description_id.name].GetType() != typeof(System.DBNull))
                    {
                        o_LogFile_Description_id.obj = dr[LogFile_VIEW.LogFile_Description_id.name];
                    }
                }
            }
            if (o_Log_PathFile_id.Select.enabled)
            {
                if (dr[LogFile_VIEW.Log_PathFile_id.name] != null)
                {
                    if (dr[LogFile_VIEW.Log_PathFile_id.name].GetType() != typeof(System.DBNull))
                    {
                        o_Log_PathFile_id.obj = dr[LogFile_VIEW.Log_PathFile_id.name];
                    }
                }
            }
        }

    }


    public class LogFile_Attachment_VIEW : XView
    {
        public const string tablename_const = "LogFile_Attachment_VIEW";
        public selection select;
        public WHERE where;
        public int RowsCount
        {
            get { return RowsCount(); }
        }
        public void Clear()
        {
            clear();
        }

        public bool Read(int Limit, ref string csError)
        {
            bool bRead = read(Limit, ref csError);
            if (Cursor >= 0)
            {
                UpdateObjects(dt.Rows[Cursor]);
            }
            return bRead;
        }

        public class id : ValSet
        {
            public const string name = "id";
            public int id_
            {
                get { return (int)obj; }
                set { obj = value; }
            }
        }
        public id o_id = new id();

        public class LogFile_id : ValSet
        {
            public const string name = "LogFile_id";
            public int LogFile_id_
            {
                get { return (int)obj; }
                set { obj = value; }
            }
        }
        public LogFile_id o_LogFile_id = new LogFile_id();

        public class Attachment : ValSet
        {
            public const string name = "Attachment";
            public Byte[] Attachment_
            {
                get { return (Byte[])obj; }
                set { obj = value; }
            }
        }
        public Attachment o_Attachment = new Attachment();

        public class Attachment_type : ValSet
        {
            public const string name = "Attachment_type";
            public string Attachment_type_
            {
                get { return (string)obj; }
                set { obj = value; }
            }
        }
        public Attachment_type o_Attachment_type = new Attachment_type();

        public class LogFile_Attachment_Type_id : ValSet
        {
            public const string name = "LogFile_Attachment_Type_id";
            public int LogFile_Attachment_Type_id_
            {
                get { return (int)obj; }
                set { obj = value; }
            }
        }
        public LogFile_Attachment_Type_id o_LogFile_Attachment_Type_id = new LogFile_Attachment_Type_id();

        public LogFile_Attachment_VIEW(Log_DBConnection xcon)
        {
            select = new selection(this);
            where = new WHERE(this);
            m_con = xcon;
            tablename = LogFile_Attachment_VIEW.tablename_const;
            myUpdateObjects = UpdateObjects;


            o_id.col_name = LogFile_Attachment_VIEW.id.name;
            o_id.col_type.m_Type = "int";
            Add(o_id);

            o_LogFile_id.col_name = LogFile_Attachment_VIEW.LogFile_id.name;
            o_LogFile_id.col_type.m_Type = "int";
            Add(o_LogFile_id);

            o_Attachment.col_name = LogFile_Attachment_VIEW.Attachment.name;
            o_Attachment.col_type.m_Type = "varbinary";
            Add(o_Attachment);

            o_Attachment_type.col_name = LogFile_Attachment_VIEW.Attachment_type.name;
            o_Attachment_type.col_type.m_Type = "nvarchar";
            Add(o_Attachment_type);

            o_LogFile_Attachment_Type_id.col_name = LogFile_Attachment_VIEW.LogFile_Attachment_Type_id.name;
            o_LogFile_Attachment_Type_id.col_type.m_Type = "int";
            Add(o_LogFile_Attachment_Type_id);

        }

        public class selection
        {
            private LogFile_Attachment_VIEW m_LogFile_Attachment_VIEW;
            public selection(LogFile_Attachment_VIEW xLogFile_Attachment_VIEW)
            {
                m_LogFile_Attachment_VIEW = xLogFile_Attachment_VIEW;
            }

            public bool id
            {
                get { return m_LogFile_Attachment_VIEW.o_id.Select.enabled; }
                set { m_LogFile_Attachment_VIEW.o_id.Select.enabled = value; }
            }

            public void id_Expression(string Expression, string xalternate_column_name)
            {
                m_LogFile_Attachment_VIEW.o_id.Select.expression = Expression;
                m_LogFile_Attachment_VIEW.o_id.Select.alternate_column_name = xalternate_column_name;
            }

            public bool LogFile_id
            {
                get { return m_LogFile_Attachment_VIEW.o_LogFile_id.Select.enabled; }
                set { m_LogFile_Attachment_VIEW.o_LogFile_id.Select.enabled = value; }
            }

            public void LogFile_id_Expression(string Expression, string xalternate_column_name)
            {
                m_LogFile_Attachment_VIEW.o_LogFile_id.Select.expression = Expression;
                m_LogFile_Attachment_VIEW.o_LogFile_id.Select.alternate_column_name = xalternate_column_name;
            }

            public bool Attachment
            {
                get { return m_LogFile_Attachment_VIEW.o_Attachment.Select.enabled; }
                set { m_LogFile_Attachment_VIEW.o_Attachment.Select.enabled = value; }
            }

            public void Attachment_Expression(string Expression, string xalternate_column_name)
            {
                m_LogFile_Attachment_VIEW.o_Attachment.Select.expression = Expression;
                m_LogFile_Attachment_VIEW.o_Attachment.Select.alternate_column_name = xalternate_column_name;
            }

            public bool Attachment_type
            {
                get { return m_LogFile_Attachment_VIEW.o_Attachment_type.Select.enabled; }
                set { m_LogFile_Attachment_VIEW.o_Attachment_type.Select.enabled = value; }
            }

            public void Attachment_type_Expression(string Expression, string xalternate_column_name)
            {
                m_LogFile_Attachment_VIEW.o_Attachment_type.Select.expression = Expression;
                m_LogFile_Attachment_VIEW.o_Attachment_type.Select.alternate_column_name = xalternate_column_name;
            }

            public bool LogFile_Attachment_Type_id
            {
                get { return m_LogFile_Attachment_VIEW.o_LogFile_Attachment_Type_id.Select.enabled; }
                set { m_LogFile_Attachment_VIEW.o_LogFile_Attachment_Type_id.Select.enabled = value; }
            }

            public void LogFile_Attachment_Type_id_Expression(string Expression, string xalternate_column_name)
            {
                m_LogFile_Attachment_VIEW.o_LogFile_Attachment_Type_id.Select.expression = Expression;
                m_LogFile_Attachment_VIEW.o_LogFile_Attachment_Type_id.Select.alternate_column_name = xalternate_column_name;
            }

            public void all(bool bVal)
            {

                this.id = bVal;

                this.LogFile_id = bVal;

                this.Attachment = bVal;

                this.Attachment_type = bVal;

                this.LogFile_Attachment_Type_id = bVal;

            }

        }

        public class WHERE
        {
            private LogFile_Attachment_VIEW m_LogFile_Attachment_VIEW;
            public WHERE(LogFile_Attachment_VIEW xLogFile_Attachment_VIEW)
            {
                m_LogFile_Attachment_VIEW = xLogFile_Attachment_VIEW;
            }

            public bool id
            {
                get { return m_LogFile_Attachment_VIEW.o_id.Where.enabled; }
                set { m_LogFile_Attachment_VIEW.o_id.Where.enabled = value; }
            }

            public void id_Expression(string Expression)
            {
                m_LogFile_Attachment_VIEW.o_id.Where.expression = Expression;
            }


            public void id_AddParameter(Log_SQL_Parameter par)
            {
                m_LogFile_Attachment_VIEW.o_id.Where.AddParameter(par);
            }

            public bool LogFile_id
            {
                get { return m_LogFile_Attachment_VIEW.o_LogFile_id.Where.enabled; }
                set { m_LogFile_Attachment_VIEW.o_LogFile_id.Where.enabled = value; }
            }

            public void LogFile_id_Expression(string Expression)
            {
                m_LogFile_Attachment_VIEW.o_LogFile_id.Where.expression = Expression;
            }


            public void LogFile_id_AddParameter(Log_SQL_Parameter par)
            {
                m_LogFile_Attachment_VIEW.o_LogFile_id.Where.AddParameter(par);
            }

            public bool Attachment
            {
                get { return m_LogFile_Attachment_VIEW.o_Attachment.Where.enabled; }
                set { m_LogFile_Attachment_VIEW.o_Attachment.Where.enabled = value; }
            }

            public void Attachment_Expression(string Expression)
            {
                m_LogFile_Attachment_VIEW.o_Attachment.Where.expression = Expression;
            }


            public void Attachment_AddParameter(Log_SQL_Parameter par)
            {
                m_LogFile_Attachment_VIEW.o_Attachment.Where.AddParameter(par);
            }

            public bool Attachment_type
            {
                get { return m_LogFile_Attachment_VIEW.o_Attachment_type.Where.enabled; }
                set { m_LogFile_Attachment_VIEW.o_Attachment_type.Where.enabled = value; }
            }

            public void Attachment_type_Expression(string Expression)
            {
                m_LogFile_Attachment_VIEW.o_Attachment_type.Where.expression = Expression;
            }


            public void Attachment_type_AddParameter(Log_SQL_Parameter par)
            {
                m_LogFile_Attachment_VIEW.o_Attachment_type.Where.AddParameter(par);
            }

            public bool LogFile_Attachment_Type_id
            {
                get { return m_LogFile_Attachment_VIEW.o_LogFile_Attachment_Type_id.Where.enabled; }
                set { m_LogFile_Attachment_VIEW.o_LogFile_Attachment_Type_id.Where.enabled = value; }
            }

            public void LogFile_Attachment_Type_id_Expression(string Expression)
            {
                m_LogFile_Attachment_VIEW.o_LogFile_Attachment_Type_id.Where.expression = Expression;
            }


            public void LogFile_Attachment_Type_id_AddParameter(Log_SQL_Parameter par)
            {
                m_LogFile_Attachment_VIEW.o_LogFile_Attachment_Type_id.Where.AddParameter(par);
            }

            public void all(bool bVal)
            {

                this.id = bVal;

                this.LogFile_id = bVal;

                this.Attachment = bVal;

                this.Attachment_type = bVal;

                this.LogFile_Attachment_Type_id = bVal;

            }

        }

        public void UpdateObjects(DataRow dr)
        {

            if (o_id.Select.enabled)
            {
                if (dr[LogFile_Attachment_VIEW.id.name] != null)
                {
                    if (dr[LogFile_Attachment_VIEW.id.name].GetType() != typeof(System.DBNull))
                    {
                        o_id.obj = dr[LogFile_Attachment_VIEW.id.name];
                    }
                }
            }
            if (o_LogFile_id.Select.enabled)
            {
                if (dr[LogFile_Attachment_VIEW.LogFile_id.name] != null)
                {
                    if (dr[LogFile_Attachment_VIEW.LogFile_id.name].GetType() != typeof(System.DBNull))
                    {
                        o_LogFile_id.obj = dr[LogFile_Attachment_VIEW.LogFile_id.name];
                    }
                }
            }
            if (o_Attachment.Select.enabled)
            {
                if (dr[LogFile_Attachment_VIEW.Attachment.name] != null)
                {
                    if (dr[LogFile_Attachment_VIEW.Attachment.name].GetType() != typeof(System.DBNull))
                    {
                        o_Attachment.obj = dr[LogFile_Attachment_VIEW.Attachment.name];
                    }
                }
            }
            if (o_Attachment_type.Select.enabled)
            {
                if (dr[LogFile_Attachment_VIEW.Attachment_type.name] != null)
                {
                    if (dr[LogFile_Attachment_VIEW.Attachment_type.name].GetType() != typeof(System.DBNull))
                    {
                        o_Attachment_type.obj = dr[LogFile_Attachment_VIEW.Attachment_type.name];
                    }
                }
            }
            if (o_LogFile_Attachment_Type_id.Select.enabled)
            {
                if (dr[LogFile_Attachment_VIEW.LogFile_Attachment_Type_id.name] != null)
                {
                    if (dr[LogFile_Attachment_VIEW.LogFile_Attachment_Type_id.name].GetType() != typeof(System.DBNull))
                    {
                        o_LogFile_Attachment_Type_id.obj = dr[LogFile_Attachment_VIEW.LogFile_Attachment_Type_id.name];
                    }
                }
            }
        }
    }


    public class LogFile_DataSet_ScalarFunctions:XFunction
    {
                public LogFile_DataSet_ScalarFunctions(Log_DBConnection xcon)
                {
                        m_con = xcon;
        
                }
            }
        

    public class LogFile_DataSet_Procedures:XProcedure
    {
                    public const string LogFile_Import_const = "LogFile_Import";

                    public int LogFile_Import(string LogComputer,string LogProgram,string LogUserName,string LogPathFile,string Description, ref int LogFile_id, ref string Res, ref string Err)
                    {
                      
                    ProcParams.Clear();
                    Log_SQL_Parameter Ret_code_CopyRight_Logina_AuthorDamjanStrucl = new Log_SQL_Parameter();
                    Ret_code_CopyRight_Logina_AuthorDamjanStrucl.dbType = System.Data.SqlDbType.Int;
                    Ret_code_CopyRight_Logina_AuthorDamjanStrucl.Name = "@Ret_code_CopyRight_Logina_AuthorDamjanStrucl";
                    Ret_code_CopyRight_Logina_AuthorDamjanStrucl.size = 4;
                    Ret_code_CopyRight_Logina_AuthorDamjanStrucl.IsOutputParameter = true;
                    ProcParams.Add(Ret_code_CopyRight_Logina_AuthorDamjanStrucl);
                    
                    Log_SQL_Parameter Par_LogFile_Import_LogComputer = new Log_SQL_Parameter();
                    Par_LogFile_Import_LogComputer.dbType = System.Data.SqlDbType.NVarChar;
                    Par_LogFile_Import_LogComputer.Name = "@Par_LogFile_Import_LogComputer";
                    Par_LogFile_Import_LogComputer.size = 264;
                    Par_LogFile_Import_LogComputer.Value = LogComputer;
                    Par_LogFile_Import_LogComputer.IsOutputParameter = false;
                    ProcParams.Add(Par_LogFile_Import_LogComputer);
                    
                    Log_SQL_Parameter Par_LogFile_Import_LogProgram = new Log_SQL_Parameter();
                    Par_LogFile_Import_LogProgram.dbType = System.Data.SqlDbType.NVarChar;
                    Par_LogFile_Import_LogProgram.Name = "@Par_LogFile_Import_LogProgram";
                    Par_LogFile_Import_LogProgram.size = 264;
                    Par_LogFile_Import_LogProgram.Value = LogProgram;
                    Par_LogFile_Import_LogProgram.IsOutputParameter = false;
                    ProcParams.Add(Par_LogFile_Import_LogProgram);
                    
                    Log_SQL_Parameter Par_LogFile_Import_LogUserName = new Log_SQL_Parameter();
                    Par_LogFile_Import_LogUserName.dbType = System.Data.SqlDbType.NVarChar;
                    Par_LogFile_Import_LogUserName.Name = "@Par_LogFile_Import_LogUserName";
                    Par_LogFile_Import_LogUserName.size = 264;
                    Par_LogFile_Import_LogUserName.Value = LogUserName;
                    Par_LogFile_Import_LogUserName.IsOutputParameter = false;
                    ProcParams.Add(Par_LogFile_Import_LogUserName);
                    
                    Log_SQL_Parameter Par_LogFile_Import_LogPathFile = new Log_SQL_Parameter();
                    Par_LogFile_Import_LogPathFile.dbType = System.Data.SqlDbType.NVarChar;
                    Par_LogFile_Import_LogPathFile.Name = "@Par_LogFile_Import_LogPathFile";
                    Par_LogFile_Import_LogPathFile.size = 1000;
                    Par_LogFile_Import_LogPathFile.Value = LogPathFile;
                    Par_LogFile_Import_LogPathFile.IsOutputParameter = false;
                    ProcParams.Add(Par_LogFile_Import_LogPathFile);
                    
                    Log_SQL_Parameter Par_LogFile_Import_Description = new Log_SQL_Parameter();
                    Par_LogFile_Import_Description.dbType = System.Data.SqlDbType.NVarChar;
                    Par_LogFile_Import_Description.Name = "@Par_LogFile_Import_Description";
                    Par_LogFile_Import_Description.size = 2000;
                    Par_LogFile_Import_Description.Value = Description;
                    Par_LogFile_Import_Description.IsOutputParameter = false;
                    ProcParams.Add(Par_LogFile_Import_Description);
                    
                    Log_SQL_Parameter Par_LogFile_Import_LogFile_id = new Log_SQL_Parameter();
                    Par_LogFile_Import_LogFile_id.dbType = System.Data.SqlDbType.Int;
                    Par_LogFile_Import_LogFile_id.Name = "@Par_LogFile_Import_LogFile_id";
                    Par_LogFile_Import_LogFile_id.size = 4;
                    Par_LogFile_Import_LogFile_id.IsOutputParameter = true;
                    ProcParams.Add(Par_LogFile_Import_LogFile_id);
                    
                    Log_SQL_Parameter Par_LogFile_Import_Res = new Log_SQL_Parameter();
                    Par_LogFile_Import_Res.dbType = System.Data.SqlDbType.NVarChar;
                    Par_LogFile_Import_Res.Name = "@Par_LogFile_Import_Res";
                    Par_LogFile_Import_Res.size = 265;
                    Par_LogFile_Import_Res.IsOutputParameter = true;
                    ProcParams.Add(Par_LogFile_Import_Res);
                    
                      object Result = exec("LogFile_Import",new string[] {"@LogComputer","@LogProgram","@LogUserName","@LogPathFile","@Description","@LogFile_id","@Res"},ref Err);
                      
object obj = null;

obj = ProcParamValue("@Par_LogFile_Import_LogFile_id");
if (obj!=null)
  if (obj.GetType() == typeof(int))
     LogFile_id = (int) obj;

obj = ProcParamValue("@Par_LogFile_Import_Res");
if (obj!=null)
  if (obj.GetType() == typeof(string))
     Res = (string) obj;


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
                
                    public const string LogWrite_const = "LogWrite";

                    public int LogWrite(int LogFile_id,DateTime LogTime,string LogType,string LogDescription, ref int Log_id, ref string Res, ref string Err)
                    {
                      
                    ProcParams.Clear();
                    Log_SQL_Parameter Ret_code_CopyRight_Logina_AuthorDamjanStrucl = new Log_SQL_Parameter();
                    Ret_code_CopyRight_Logina_AuthorDamjanStrucl.dbType = System.Data.SqlDbType.Int;
                    Ret_code_CopyRight_Logina_AuthorDamjanStrucl.Name = "@Ret_code_CopyRight_Logina_AuthorDamjanStrucl";
                    Ret_code_CopyRight_Logina_AuthorDamjanStrucl.size = 4;
                    Ret_code_CopyRight_Logina_AuthorDamjanStrucl.IsOutputParameter = true;
                    ProcParams.Add(Ret_code_CopyRight_Logina_AuthorDamjanStrucl);
                    
                    Log_SQL_Parameter Par_LogWrite_LogFile_id = new Log_SQL_Parameter();
                    Par_LogWrite_LogFile_id.dbType = System.Data.SqlDbType.Int;
                    Par_LogWrite_LogFile_id.Name = "@Par_LogWrite_LogFile_id";
                    Par_LogWrite_LogFile_id.size = 4;
                    Par_LogWrite_LogFile_id.Value = LogFile_id;
                    Par_LogWrite_LogFile_id.IsOutputParameter = false;
                    ProcParams.Add(Par_LogWrite_LogFile_id);
                    
                    Log_SQL_Parameter Par_LogWrite_LogTime = new Log_SQL_Parameter();
                    Par_LogWrite_LogTime.dbType = System.Data.SqlDbType.DateTime;
                    Par_LogWrite_LogTime.Name = "@Par_LogWrite_LogTime";
                    Par_LogWrite_LogTime.size = 8;
                    Par_LogWrite_LogTime.Value = LogTime;
                    Par_LogWrite_LogTime.IsOutputParameter = false;
                    ProcParams.Add(Par_LogWrite_LogTime);
                    
                    Log_SQL_Parameter Par_LogWrite_LogType = new Log_SQL_Parameter();
                    Par_LogWrite_LogType.dbType = System.Data.SqlDbType.NVarChar;
                    Par_LogWrite_LogType.Name = "@Par_LogWrite_LogType";
                    Par_LogWrite_LogType.size = 10;
                    Par_LogWrite_LogType.Value = LogType;
                    Par_LogWrite_LogType.IsOutputParameter = false;
                    ProcParams.Add(Par_LogWrite_LogType);
                    
                    Log_SQL_Parameter Par_LogWrite_LogDescription = new Log_SQL_Parameter();
                    Par_LogWrite_LogDescription.dbType = System.Data.SqlDbType.NVarChar;
                    Par_LogWrite_LogDescription.Name = "@Par_LogWrite_LogDescription";
                    Par_LogWrite_LogDescription.size = 2000;
                    Par_LogWrite_LogDescription.Value = LogDescription;
                    Par_LogWrite_LogDescription.IsOutputParameter = false;
                    ProcParams.Add(Par_LogWrite_LogDescription);
                    
                    Log_SQL_Parameter Par_LogWrite_Log_id = new Log_SQL_Parameter();
                    Par_LogWrite_Log_id.dbType = System.Data.SqlDbType.Int;
                    Par_LogWrite_Log_id.Name = "@Par_LogWrite_Log_id";
                    Par_LogWrite_Log_id.size = 4;
                    Par_LogWrite_Log_id.IsOutputParameter = true;
                    ProcParams.Add(Par_LogWrite_Log_id);
                    
                    Log_SQL_Parameter Par_LogWrite_Res = new Log_SQL_Parameter();
                    Par_LogWrite_Res.dbType = System.Data.SqlDbType.NVarChar;
                    Par_LogWrite_Res.Name = "@Par_LogWrite_Res";
                    Par_LogWrite_Res.size = 265;
                    Par_LogWrite_Res.IsOutputParameter = true;
                    ProcParams.Add(Par_LogWrite_Res);
                    
                      object Result = exec("LogWrite",new string[] {"@LogFile_id","@LogTime","@LogType","@LogDescription","@Log_id","@Res"},ref Err);
                      
object obj = null;

obj = ProcParamValue("@Par_LogWrite_Log_id");
if (obj!=null)
  if (obj.GetType() == typeof(int))
     Log_id = (int) obj;

obj = ProcParamValue("@Par_LogWrite_Res");
if (obj!=null)
  if (obj.GetType() == typeof(string))
     Res = (string) obj;


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
                
                public LogFile_DataSet_Procedures(Log_DBConnection xcon)
                {
                        m_con = xcon;
        
                }
            }
        
}
