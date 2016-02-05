#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using System.Net.NetworkInformation;
using System.Net;
using System.Net.Sockets;
using System.Collections;
//using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
//using System.Windows.Forms;
//using System.Diagnostics;
using MySql.Data.MySqlClient;
using System.Data.SQLite;
using System.Data.Common;
using System.IO;
using LanguageControl;

 
namespace LogFile
{
    [ToolboxItem(true)]
    //[ToolboxBitmapAttribute(typeof(SQLServerConnection), "SQLServerConnection2.bmp")]
    //[ToolboxBitmap(@"E:\ManualReader\ctLogina\SearchLocalNetworkControl\Resources\SearchLocalNetwork.bmp")]
    //[ToolboxBitmap(@"E:\ManualReader\ctLogina\Log_DBConnection\Resources\Log_DBConnection.SQLServerConnection.bmp")]
    //[ToolboxBitmap(typeof(Log_DBConnection.SQLServerConnection), "Log_DBConnection.SQLServerConnection.bmp")]
    //[ToolboxBitmap(typeof(Log_DBConnection.SQLServerConnection), "Resources\\Log_DBConnection.SQLServerConnection.bmp")]
    //F:\\RFID\\DBProjects\\Log_DBConnection
    [ToolboxBitmap("E:\\ManualReader\\ctlogina\\DBConectionControl4\\Resources\\Log_DBConnection.ico")]
    public partial class Log_DBConnection : Component
    {
        public string m_inifile_prefix = null;


        private SqlConnection m_con_MSSQL = null;

        private MySqlConnection m_con_MYSQL = null;

        private SQLiteConnection m_con_SQLite = null;

        public enum eStartPositionOfTestConnectionForm { CENTER_SCREEN, TOP_LEFT_CORNER, TOP_RIGHT_CORNER, BOTTOM_LEFT_CORNER, BOTTOM_RIGHT_CORNER }

        private eStartPositionOfTestConnectionForm m_eStartPositionOfTestConnectionForm = eStartPositionOfTestConnectionForm.CENTER_SCREEN;

        public eStartPositionOfTestConnectionForm StartPositionOfTestConnectionForm
        {
            get {return m_eStartPositionOfTestConnectionForm;}
            set { m_eStartPositionOfTestConnectionForm = value; }
        }

        #region PUBLIC CONSTRUCTORS

        public object DB_Param = null; // this object can be of type Log_RemoteDB_data or  Log_LocalDB_data

        public Log_Settings_LocalDB Log_Settings_LocalDB
        {
            get
            {
                if (DB_Param != null)
                {
                    if (DBType == eDBType.SQLITE)
                    {
                        Log_LocalDB_data ldbdata = (Log_LocalDB_data)DB_Param;
                        return ldbdata.m_Settings_LocalDB;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }

        }

        public Settings_RemoteDB Settings_RemoteDB
        {
            get
            {
                if (DB_Param != null)
                {
                    if (DBType != eDBType.SQLITE)
                    {
                        Log_RemoteDB_data rdbdata = (Log_RemoteDB_data)DB_Param;
                        return rdbdata.m_Settings_RemoteDB;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
        }

        public Log_Settings_LocalDB.eType Settings_LocalDB_eType
        {
            get
            {
                if (DB_Param != null)
                {
                    if (DBType != eDBType.SQLITE)
                    {
                        Log_LocalDB_data rdbdata = (Log_LocalDB_data)DB_Param;
                        return rdbdata.m_Settings_LocalDB.m_eType;
                    }
                    else
                    {
                        return Log_Settings_LocalDB.eType.IniFile_Setting;
                    }
                }
                else
                {
                    return Log_Settings_LocalDB.eType.IniFile_Setting;
                }
            }

            set
            {
                if (DB_Param != null)
                {
                    if (DBType != eDBType.SQLITE)
                    {
                        Log_LocalDB_data rdbdata = (Log_LocalDB_data)DB_Param;
                        rdbdata.m_Settings_LocalDB.m_eType = value;
                    }
                }
            }
        }


        public Settings_RemoteDB.eType Settings_RemoteDB_eType
        {
            get
            {
                if (DB_Param != null)
                {
                    if (DBType != eDBType.SQLITE)
                    {
                        Log_RemoteDB_data rdbdata = (Log_RemoteDB_data)DB_Param;
                        return rdbdata.m_Settings_RemoteDB.m_eType;
                    }
                    else
                    {
                        return Settings_RemoteDB.eType.IniFile_Setting;
                    }
                }
                else
                {
                    return Settings_RemoteDB.eType.IniFile_Setting;
                }
            }

            set
            {
                if (DB_Param != null)
                {
                    if (DBType != eDBType.SQLITE)
                    {
                        Log_RemoteDB_data rdbdata = (Log_RemoteDB_data)DB_Param;
                        rdbdata.m_Settings_RemoteDB.m_eType = value;
                    }
                }
            }
        }

        public Log_DBConnection()
        {
            InitializeComponent();
        }

        public Log_DBConnection(string rfolder)
        {
            m_con_SQLite = new SQLiteConnection();
            m_con_MYSQL = new MySqlConnection();
            m_con_MSSQL = new SqlConnection();
            InitializeComponent();
            m_RecentItemsFolder = rfolder;

        }

        public Log_DBConnection(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            m_con_SQLite = new SQLiteConnection();
            m_con_MYSQL = new MySqlConnection();
            try
            {
                m_con_MSSQL = new SqlConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("eXCEPTION = " + ex.Message);
                MessageBox.Show("eXCEPTION = " + ex.Message +"\r\nINNER:"+ ex.InnerException.Message);
                string inner_ex = ex.Message;
                Exception eix = ex.InnerException;

                while(eix!=null)
                {
                    if (eix.Message!=null)
                    {
                        inner_ex += "\r\n inner->" + eix.Message+ "\r\n";
                    }
                    eix = eix.InnerException;
                }
                Error.Show("Exception = " + ex.Message + "\r\nInner Exception = " + inner_ex); 
            }

        }

        #endregion PUBLIC CONSTRUCTORS

        #region PRIVATE
        private bool m_ShowDBErrorMessages = false;
        public string ConnectionName = null;

        private const string const_MSSQL_ALTER_ANY_DATABASE = "ALTER ANY DATABASE";

        private ConnectionDialog ConnectionDialog = null;
        private SQLiteConnectionDialog SQLiteConnectionDialog = null;

        private string m_LogTableName;
        private int m_CommandTimeout = 20000;


        private conData_MSSQL m_conData_MSSQL = null;
        private conData_MYSQL m_conData_MYSQL = null;
        private conData_SQLITE m_conData_SQLITE = null;

        private eDBType m_DBType = eDBType.SQLITE;

        private string m_RecentItemsFolder = "";


        #endregion

        #region PUBLIC

        #region PUBLIC ENUMS

        public enum  eDBType:int  { MSSQL, MYSQL, SQLITE };
        public enum ConnectResult_ENUM { OK, OK_SAVE, CANCELED };

        #endregion PUBLIC ENUMS

        #region PUBLIC PROPERTIES
        public bool SQLite_AllwaysCreateNew
        {
            get
            {
                if (m_conData_SQLITE != null)
                {
                    return m_conData_SQLITE.SQLite_AllwaysCreateNew;
                }
                else
                {
                    return false;
                }
            }

            set
            {
                if (m_conData_SQLITE != null)
                {
                    m_conData_SQLITE.SQLite_AllwaysCreateNew = value;
                }
            }
        }
        public string RecentItemsFolder
        {
            get { return m_RecentItemsFolder; }
            set { m_RecentItemsFolder = value; }
        }


        public bool bShowDBErrorMessages
        {
            get { return m_ShowDBErrorMessages; }
            set { m_ShowDBErrorMessages = value; }
        }


        public eDBType DBType
        {
            get { return m_DBType; }
            set
            {
                if (m_DBType != value)
                {
                    // set other type;
                    m_DBType = value;

                    m_conData_MSSQL = null;
                    m_conData_MYSQL = null;
                    m_conData_MYSQL = null;

                    switch (m_DBType)
                    {
                        case eDBType.MSSQL:
                            m_conData_MSSQL = new conData_MSSQL();
                            break;
                        case eDBType.MYSQL:
                            m_conData_MYSQL = new conData_MYSQL();
                            break;
                        case eDBType.SQLITE:
                            m_conData_SQLITE = new conData_SQLITE();
                            break;
                    }
                }
                else
                {
                    switch (m_DBType)
                    {
                        case eDBType.MSSQL:
                            if (m_conData_MSSQL == null)
                            {
                                m_conData_MSSQL = new conData_MSSQL();
                            }
                            break;
                        case eDBType.MYSQL:
                            if (m_conData_MYSQL == null)
                            {
                                m_conData_MYSQL = new conData_MYSQL();
                            }
                            break;
                        case eDBType.SQLITE:
                            if (m_conData_SQLITE == null)
                            {
                                m_conData_SQLITE = new conData_SQLITE();
                            }
                            break;
                    }
                }
            }
        }

        public string ServerType
        {
            get
            {
                switch (DBType)
                {
                    case eDBType.MSSQL:
                        return "Microsoft TSQL";

                    case eDBType.MYSQL:
                        return "MySQL";

                    case eDBType.SQLITE:
                        return "SQLite";
                }
                return "";
            }
        }

        public int CommandTimeout
        {
            get { return m_CommandTimeout; }
            set { m_CommandTimeout = value; }
        }


        public bool WindowsAuthentication 
                    {
                        get
                        {
                            switch (m_DBType)
                            {
                                case eDBType.MSSQL:
                                    return m_conData_MSSQL.m_bWindowsAuthentication;

                                case eDBType.MYSQL:
                                    return false;

                                case eDBType.SQLITE:
                                    return false;

                            }
                            return false;
                        }
                        set
                        {
                            switch (m_DBType)
                            {
                                case eDBType.MSSQL:
                                    m_conData_MSSQL.m_bWindowsAuthentication = value;
                                    break;
                                case eDBType.MYSQL:
                                    MessageBox.Show("Error setting property WindowsAuthentication in module Log_DBConnection. MYSQL server does not support Windows Authentication");
                                    break;

                                case eDBType.SQLITE:
                                    MessageBox.Show("Error setting property WindowsAuthentication in module Log_DBConnection. SQLite database does not support Windows Authentication");
                                    break;

                            }
                            return;
                        }
                    }

        public string WindowsAuthentication_UserName
        {
            get
            {
                switch (m_DBType)
                {
                    case eDBType.MSSQL:
                        return m_conData_MSSQL.m_WindowsAuthentication_UserName;

                    case eDBType.MYSQL:
                        return "";

                    case eDBType.SQLITE:
                        return "";

                }
                return "";
            }
        }

        public string ServerConnectionString
        {
            get
            {
                switch (m_DBType)
                {
                    case eDBType.MSSQL:
                        return m_conData_MSSQL.GetServerConnectionString();

                    case eDBType.MYSQL:
                        return m_conData_MYSQL.GetServerConnectionString();

                    case eDBType.SQLITE:
                        return m_conData_SQLITE.GetConnectionString();

                }
                return "";
            }
        }

        public string SQLiteDataBaseFile
        {
            get
            {
                switch (m_DBType)
                {
                    case eDBType.MSSQL:
                        return null;

                    case eDBType.MYSQL:
                        return null;

                    case eDBType.SQLITE:
                        return m_conData_SQLITE.DataBaseFile;

                }
                return null;
            }
            set
            {
                switch (m_DBType)
                {
                    case eDBType.MSSQL:
                        MessageBox.Show("Error setting property DataBaseFile in module Log_DBConnection. MSSQL server does not support DataBaseFile definition");
                        break;

                    case eDBType.MYSQL:
                        MessageBox.Show("Error setting property DataBaseFilePath in module Log_DBConnection. MYSQL server does not support DataBaseFilePath definition");
                        break;

                    case eDBType.SQLITE:
                        m_conData_SQLITE.DataBaseFile = value;
                        break;

                }
                return;
            }
        }

        public DateTime SQLiteDataBaseFileCreationTime
        {
            get
            {
                switch (m_DBType)
                {
                    case eDBType.MSSQL:
                        LogFile.Write(LogFile.LOG_LEVEL_RUN_RELEASE, "Error: SQLiteDataBaseFileCreationTime is not supported for eDBType.MSSQL!");
                        return DateTime.MinValue;

                    case eDBType.MYSQL:
                        LogFile.Write(LogFile.LOG_LEVEL_RUN_RELEASE, "Error: SQLiteDataBaseFileCreationTime is not supported for eDBType.MYSQL!");
                        return DateTime.MinValue;

                    case eDBType.SQLITE:
                        return m_conData_SQLITE.DataBaseFileCreationTime;
                }
                return DateTime.MinValue;
            }
        }

        public string DataBaseFilePath
        {
            get
            {
                switch (m_DBType)
                {
                    case eDBType.MSSQL:
                        return m_conData_MSSQL.m_strDataBaseFilePath;

                    case eDBType.MYSQL:
                        return null;

                    case eDBType.SQLITE:
                        return null;

                }
                return null;
            }
            set
            {
                switch (m_DBType)
                {
                    case eDBType.MSSQL:
                        m_conData_MSSQL.m_strDataBaseFilePath = value;
                        break;

                    case eDBType.MYSQL:
                        MessageBox.Show("Error setting property DataBaseFilePath in module Log_DBConnection. MYSQL server does not support DataBaseFilePath definition");
                        break;

                    case eDBType.SQLITE:
                        m_conData_SQLITE.DataBaseFile = value;
                        break;

                }
                return;
            }
        }

        public string DataBaseLogFilePath 
        {
            get
            {
                switch (m_DBType)
                {
                    case eDBType.MSSQL:
                        return m_conData_MSSQL.m_strDataBaseLogFilePath;

                    case eDBType.MYSQL:
                        return null;

                    case eDBType.SQLITE:
                        return null;

                }
                return null;
            }
            set
            {
                switch (m_DBType)
                {
                    case eDBType.MSSQL:
                        m_conData_MSSQL.m_strDataBaseLogFilePath = value;
                        break;

                    case eDBType.MYSQL:
                        MessageBox.Show("Error setting property DataBaseLogFilePath in module Log_DBConnection. MYSQL server does not support DataBaseLogFilePath definition");
                        break;

                    case eDBType.SQLITE:
                        MessageBox.Show("Error setting property DataBaseLogFilePath in module Log_DBConnection. SQLite does not support DataBaseLogFilePath definition");
                        break;

                }
                return;
            }
        }

        #endregion PUBLIC PROPERTIES


        #region PUBLIC MEMBER FUNCTIONS

        public bool SQLiteTableInfo(ref DataTable tables,ref DataTable columns, ref string csError)
        {
            try
            {
                string serverversion = null;
                System.Data.SQLite.SQLiteFactory factory = System.Data.SQLite.SQLiteFactory.Instance;
                DbConnection connection = factory.CreateConnection();
                connection.ConnectionString = ConnectionString;
                connection.Open();
                serverversion = connection.ServerVersion;
                tables = connection.GetSchema("Tables");
                columns = connection.GetSchema("Columns");
                connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                csError = ex.Message;
                return false;
            }
        }

        public bool CheckServerConnection(Form pParentForm, string sTitle)
        {
            if (IsValidServerConnectionString())
            {
                if (m_DBType == eDBType.SQLITE)
                {
                    if (File.Exists(m_conData_SQLITE.DataBaseFile))
                    {
                        TestConnectionForm tConForm = new TestConnectionForm(pParentForm, this, true, false, sTitle);
                        if (tConForm.ShowDialog() == DialogResult.OK)
                        {
                            tConForm.Dispose();
                            return true;
                        }
                        else
                        {
                            tConForm.Dispose();
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    TestConnectionForm tConForm = new TestConnectionForm(pParentForm, this, true, false, sTitle);
                    if (tConForm.ShowDialog() == DialogResult.OK)
                    {
                        tConForm.Dispose();
                        return true;
                    }
                    else
                    {
                        tConForm.Dispose();
                        return false;
                    }
                }
            }
            else
            {
                return false;
            }
        }

        public bool CheckDataBaseConnection(Form pParentForm, string sTitle)
        {
            if (IsValidDataBaseConnectionString())
            {
                if (m_DBType == eDBType.SQLITE)
                {
                    if (File.Exists(m_conData_SQLITE.DataBaseFile))
                    {
                        TestConnectionForm tConForm = new TestConnectionForm(pParentForm, this, true, true, sTitle);
                        if (tConForm.ShowDialog() == DialogResult.OK)
                        {
                            tConForm.Dispose();
                            return true;
                        }
                        else
                        {
                            tConForm.Dispose();
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    TestConnectionForm tConForm = new TestConnectionForm(pParentForm, this, true, true, sTitle);
                    if (tConForm.ShowDialog() == DialogResult.OK)
                    {
                        tConForm.Dispose();
                        return true;
                    }
                    else
                    {
                        tConForm.Dispose();
                        return false;
                    }
                }
            }
            else
            {
                return false;
            }
        }

        private bool RenameFile_ToDateTimeVersion(string LocalDB_FileName)
        {
            DateTime time_now = DateTime.Now;
            string s_BackupFileName = null;
            s_BackupFileName = LocalDB_FileName + "_" + time_now.Year.ToString() + "-" + time_now.Month.ToString() + "-" + time_now.Day.ToString() + "_" + time_now.Hour.ToString() + "h" + time_now.Minute.ToString() + "m" + time_now.Second.ToString() + "s";
            string sVerN = "";
            string sVerFile = s_BackupFileName +sVerN;
            int i = 1;
            while (File.Exists(sVerFile))
            {
                sVerN = "_v" + i.ToString();
                sVerFile = s_BackupFileName + sVerN;
                i++;
                if (i > 20)
                {
                    Error.Show("ERROR:LogFile:RenameFile_ToDateTimeVersion:Cannot find unique file name!");
                    return false;
                }
                Application.DoEvents();
                Thread.Sleep(10);
            }

            try
            {
                File.Copy(LocalDB_FileName, sVerFile);
                File.Delete(LocalDB_FileName);
                return true;
            }
            catch (Exception Ex)
            {
                Error.Show("ERROR:LogFile:RenameFile_ToDateTimeVersion:Ex=" + Ex.Message);
                return false;
            }
        }

        private bool IsValidServerConnectionString()
        {
            if (DataSource.Length > 0)
            {
               return true;
            }
            return false;
        }

        private bool IsValidDataBaseConnectionString()
        {
            if (DataSource.Length > 0)
            {
                if (DataBase.Length > 0)
                {
                    return true;
                }
            }
            return false;
        }

        public bool CheckConnection(Object DB_Param)
        {
            SetConnectionData(DB_Param);
            return CheckDataBaseConnection(null, LanguageControl.lngConn.s_TestConnection.s);
        }

        public bool CreateNewDataBaseConnection(Form pParentForm, Object DB_Param)
        {
            SetConnectionData(DB_Param);
            bool bxNewDatabase = false;
            while (true)
            {
                Log_DBConnection.ConnectResult_ENUM dRes;
                string sDBaseConnectionName = null;
                if (DB_Param.GetType() == typeof(Log_RemoteDB_data))
                {
                    Log_RemoteDB_data xRemoteDB_data = (Log_RemoteDB_data)DB_Param;
                    sDBaseConnectionName = xRemoteDB_data.ConnectionName;
                }
                else if (DB_Param.GetType() == typeof(Log_LocalDB_data))
                {
                    Log_LocalDB_data xLocalDB_data = (Log_LocalDB_data)DB_Param;
                    sDBaseConnectionName = xLocalDB_data.ConnectionName;
                }
                else
                {
                    MessageBox.Show("ERROR:Log_DBConnection:CreateNewDataBaseConnection Object DB_Param not valid !");
                    return false;
                }
                dRes = do_ConnectionDialog(pParentForm, sDBaseConnectionName, ref bxNewDatabase);
                switch (dRes)
                {
                    case Log_DBConnection.ConnectResult_ENUM.OK_SAVE:
                    case Log_DBConnection.ConnectResult_ENUM.OK:
                        switch (DBType)
                        {
                            case Log_DBConnection.eDBType.MSSQL:
                                {
                                    Log_RemoteDB_data remote_DB_Param = (Log_RemoteDB_data)DB_Param;
                                    if (remote_DB_Param.DBType != Log_DBConnection.eDBType.MSSQL)
                                    {
                                        remote_DB_Param.DBType = Log_DBConnection.eDBType.MSSQL;
                                    }
                                    remote_DB_Param.bNewDatabase = bxNewDatabase;
                                    remote_DB_Param.bChanged = true;
                                    remote_DB_Param.bWindowsAuthentication = WindowsAuthentication;
                                    remote_DB_Param.DataSource = DataSource;
                                    remote_DB_Param.DataBase = DataBase;
                                    remote_DB_Param.UserName = UserName;
                                    remote_DB_Param.crypted_Password = PasswordCrypted;
                                    remote_DB_Param.strDataBaseFilePath = DataBaseFilePath;
                                    remote_DB_Param.strDataBaseFilePath = DataBaseLogFilePath;
                                    
                                }
                                break;

                            case Log_DBConnection.eDBType.MYSQL:
                                {
                                    Log_RemoteDB_data remote_DB_Param = (Log_RemoteDB_data)DB_Param;
                                    if (remote_DB_Param.DBType != Log_DBConnection.eDBType.MYSQL)
                                    {
                                        remote_DB_Param.DBType = Log_DBConnection.eDBType.MYSQL;
                                    }
                                    remote_DB_Param.bChanged = true;
                                    remote_DB_Param.bNewDatabase = bxNewDatabase;
                                    remote_DB_Param.bWindowsAuthentication = false;
                                    remote_DB_Param.DataSource = DataSource;
                                    remote_DB_Param.DataBase = DataBase;
                                    remote_DB_Param.UserName = UserName;
                                    remote_DB_Param.crypted_Password = PasswordCrypted;
                                    remote_DB_Param.strDataBaseFilePath = "";
                                    remote_DB_Param.strDataBaseFilePath = "";
                                }
                                break;

                            case Log_DBConnection.eDBType.SQLITE:
                                Log_LocalDB_data local_DB_Param = (Log_LocalDB_data)DB_Param;
                                local_DB_Param.bChanged = true;
                                local_DB_Param.bNewDatabase = bxNewDatabase;
                                local_DB_Param.DataBaseFileName = m_conData_SQLITE.m_DataBaseFileName;
                                local_DB_Param.DataBaseFilePath = m_conData_SQLITE.m_DataBaseFilePath;
                                break;
                        }
                       // DB_Param = DB_Param;
                        return true;

                    case Log_DBConnection.ConnectResult_ENUM.CANCELED:
                        return false;
                }
            }
        }

        public bool SetNewConnection(Form pParentForm, object xDB_Param)
        {
            bool bxNewDatabase = false;
            while (true)
            {
                Log_DBConnection.ConnectResult_ENUM dRes;
                dRes = do_ConnectionDialog(pParentForm, this.ConnectionName, ref bxNewDatabase);
                switch (dRes)
                {
                    case Log_DBConnection.ConnectResult_ENUM.OK_SAVE:
                    case Log_DBConnection.ConnectResult_ENUM.OK:
                        switch (DBType)
                        {
                            case Log_DBConnection.eDBType.MSSQL:
                                {
                                    Log_RemoteDB_data remote_DB_Param = (Log_RemoteDB_data)xDB_Param;
                                    remote_DB_Param.bNewDatabase = bxNewDatabase;
                                    remote_DB_Param.bChanged = true;
                                    remote_DB_Param.bWindowsAuthentication = WindowsAuthentication;
                                    remote_DB_Param.DataSource = DataSource;
                                    remote_DB_Param.DataBase = DataBase;
                                    remote_DB_Param.UserName = UserName;
                                    remote_DB_Param.crypted_Password = PasswordCrypted;
                                    remote_DB_Param.strDataBaseFilePath = DataBaseFilePath;
                                    remote_DB_Param.strDataBaseFilePath = DataBaseLogFilePath;
                                }
                                break;

                            case Log_DBConnection.eDBType.MYSQL:
                                {
                                    Log_RemoteDB_data remote_DB_Param = (Log_RemoteDB_data)xDB_Param;
                                    remote_DB_Param.bChanged = true;
                                    remote_DB_Param.bNewDatabase = bxNewDatabase;
                                    remote_DB_Param.bWindowsAuthentication = false;
                                    remote_DB_Param.DataSource = DataSource;
                                    remote_DB_Param.DataBase = DataBase;
                                    remote_DB_Param.UserName = UserName;
                                    remote_DB_Param.crypted_Password = PasswordCrypted;
                                    remote_DB_Param.strDataBaseFilePath = "";
                                    remote_DB_Param.strDataBaseFilePath = "";
                                }
                                break;

                            case Log_DBConnection.eDBType.SQLITE:
                                Log_LocalDB_data local_DB_Param = (Log_LocalDB_data)xDB_Param;
                                local_DB_Param.bChanged = true;
                                local_DB_Param.bNewDatabase = bxNewDatabase;
                                local_DB_Param.DataBaseFileName = m_conData_SQLITE.m_DataBaseFileName;
                                local_DB_Param.DataBaseFilePath = m_conData_SQLITE.m_DataBaseFilePath;
                                break;
                        }

                        DB_Param = xDB_Param;
                        return true;

                    case Log_DBConnection.ConnectResult_ENUM.CANCELED:
                        return false;
                }
            }

        }

        public bool MakeDataBaseConnection(Form pParentForm, Object xDB_Param)
        {
            SetConnectionData(xDB_Param);
            if (DBType == eDBType.SQLITE)
            {
                if (SQLite_AllwaysCreateNew)
                {
                    if (File.Exists(m_conData_SQLITE.DataBaseFile))
                    {
                        if (!RenameFile_ToDateTimeVersion(m_conData_SQLITE.DataBaseFile))
                        {
                            return false;
                        }
                    }
                }
            }
            if (CheckDataBaseConnection(pParentForm, LanguageControl.lngConn.s_TestConnection.s))
            {
                //if (DB_Param.GetType() == typeof(Log_RemoteDB_data))
                //{
                //    Log_RemoteDB_data rmtd = (Log_RemoteDB_data)DB_Param;
                //    rmtd.Save();
                //}
                //else if (DB_Param.GetType() == typeof(Log_LocalDB_data))
                //{
                //    Log_LocalDB_data ld = (Log_LocalDB_data)DB_Param;
                //    ld.Save();
                //}
                DB_Param = xDB_Param;
                return true;
            }
            else
            {
                if (SetNewConnection(pParentForm, xDB_Param))
                {
                    DB_Param = xDB_Param;
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

 

        public bool CheckConnectionToServerOnly()
        {
            try
            {
                //conData.SetConnectionString();
                switch (m_DBType)
                {
                    case eDBType.MYSQL:
                        m_con_MYSQL.ConnectionString = m_conData_MYSQL.GetServerConnectionString();
                        m_con_MYSQL.Open();
                        return true;
                    case eDBType.MSSQL:
                        m_con_MSSQL.ConnectionString = m_conData_MSSQL.GetServerConnectionString();
                        m_con_MSSQL.Open();
                        return true;

                    case eDBType.SQLITE:
                        m_con_SQLite.ConnectionString = m_conData_SQLITE.DataBaseFile;
                        m_con_SQLite.Open();
                        return true;

                    default:
                        MessageBox.Show("Uknonwn eSQLType in function public bool CheckConnectionToServerOnly()");
                        return false;
                }
            }
            catch (Exception ex)
            {
                //sError = SetConnectionError() + "\n" + ex.Message;
                //if (dbg.bON) dbg.Print(sError);
                //Log.Write(1, sError);
                LogFile.Write(LogFile.LOG_LEVEL_RUN_RELEASE,"Error:CheckConnectionToServerOnly: Exception = "+ex.Message);
                return false;
            }
        }

        public bool Connect_ToServerOnly(ref string sError)
        {
            try
            {
                //conData.SetConnectionString();
                switch (m_DBType)
                {
                    case eDBType.MYSQL:
                        m_con_MYSQL.Open();
                        return true;
                    case eDBType.MSSQL:
                        m_con_MSSQL.Open();
                        return true;
                    case eDBType.SQLITE:
                        m_con_SQLite.Open();
                        return true;
                    default:
                        MessageBox.Show("Error unknown eSQLType in function public bool Connect_ToServerOnly(ref string sError)");
                        return false;
                }
            }
            catch (Exception ex)
            {
                sError = SetConnectionError() + "\n" + ex.Message;
                //if (dbg.bON) dbg.Print(sError);
                //Log.Write(1, sError);
                return false;
            }
        }

        public bool Connect(ref string sError)
        {
            try
            {
                SetConnectionString();
                switch (m_DBType)
                {
                    case eDBType.MYSQL:
                        m_con_MYSQL.Open();
                        return true;
                    case eDBType.MSSQL:
                        m_con_MSSQL.Open();
                        return true;

                    case eDBType.SQLITE:
                        m_con_SQLite.Open();
                        return true;

                    default:
                        MessageBox.Show("Error unknown eSQLType in function: public bool Connect(ref string sError)");
                        return false;
                }
            }
            catch (Exception ex)
            {
                sError = SetConnectionError() +"\n" + ex.Message;
                if (dbg.bON) dbg.Print(sError);
                Log.Write(1, sError);
                return false;
            }
        }

        private void SetConnectionString()
        {
            switch (m_DBType)
            {
                case eDBType.MYSQL:
                    m_con_MYSQL.ConnectionString = ConnectionString;
                    break;

                case eDBType.MSSQL:
                    m_con_MSSQL.ConnectionString = ConnectionString;
                    break;

                case eDBType.SQLITE:
                    m_con_SQLite.ConnectionString = ConnectionString;
                    break;

                default:
                    MessageBox.Show("Error unknown eSQLType in function: public bool Connect(ref string sError)");
                    break;
            }
        }


        public bool Disconnect()
        {
            try
            {
                switch (m_DBType)
                {
                    case eDBType.MYSQL:
                        m_con_MYSQL.Close();
                        return true;

                    case eDBType.MSSQL:
                        m_con_MSSQL.Close();
                        return true;

                    case eDBType.SQLITE:
                        m_con_SQLite.Close();
                        return true;

                    default:
                        MessageBox.Show("Error unknown eSQLType in function:  public bool Disconnect().");
                        return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error can not disconnect from:" + ConnectionString + "\n\n Exception = " + ex.Message, "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public ConnectResult_ENUM do_ConnectionDialog(Form m_ParentForm, string sTitle, ref bool bNewDatabase)
        {
                DialogResult dRes;
                bNewDatabase = false;
                switch (m_DBType)
                {
                    case eDBType.MYSQL:
                        if ((m_conData_MYSQL.m_DataSource.Length > 0) && (m_conData_MYSQL.m_DataBase.Length > 0))
                        {
                            ConnectionDialog = new ConnectionDialog(m_ParentForm, ConnectionDialog.ConnectionDialog_enum.EditLoginAndPassword, this, sTitle);
                        }
                        else
                        {
                            ConnectionDialog = new ConnectionDialog(m_ParentForm, ConnectionDialog.ConnectionDialog_enum.EditAll, this, sTitle);
                        }
                        break;

                    case eDBType.MSSQL:
                        if ((m_conData_MSSQL.m_DataSource.Length > 0) && (m_conData_MSSQL.m_DataBase.Length > 0))
                        {
                            ConnectionDialog = new ConnectionDialog(m_ParentForm, ConnectionDialog.ConnectionDialog_enum.EditLoginAndPassword, this, sTitle);
                        }
                        else
                        {
                            ConnectionDialog = new ConnectionDialog(m_ParentForm, ConnectionDialog.ConnectionDialog_enum.EditAll, this, sTitle);
                        }
                        break;

                    case eDBType.SQLITE:
                        SQLiteConnectionDialog = new SQLiteConnectionDialog(m_ParentForm,  m_conData_SQLITE,this.RecentItemsFolder);
                        break;


                    default:
                        MessageBox.Show("Error unknown eSQLType in function:  public ConnectResult_ENUM do_ConnectionDialog(string sTitle).");
                        break;
                }

            while (true)
            {

                if (m_DBType == eDBType.SQLITE)
                {
                    dRes = SQLiteConnectionDialog.ShowDialog(m_ParentForm);
                }
                else 
                {
                    dRes = ConnectionDialog.ShowDialog(m_ParentForm);
                }

                if (dRes == DialogResult.Cancel)
                {
                    if (m_DBType == eDBType.SQLITE)
                    {
                        SQLiteConnectionDialog.Dispose();
                    }
                    else
                    {
                        ConnectionDialog.Dispose();
                    }
                    return ConnectResult_ENUM.CANCELED;
                }
                else if (dRes == DialogResult.OK)
                {
                    
                    try
                    {
                        if (m_DBType == eDBType.SQLITE)
                        {

                            if (!File.Exists(DataBase))
                            {

                                string sErr = null;
                                if (m_con_SQLite != null)
                                {
                                    m_con_SQLite.Dispose();
                                }
                                m_con_SQLite = new SQLiteConnection(ConnectionString);
                                //}
                                //else
                                //{
                                //    m_con_SQLite.ConnectionString = ConnectionString;
                                //}
                                //if (m_con_SQLite.ConnectionString.Length == 0)
                                //{
                                //    m_con_SQLite.ConnectionString = ConnectionString;
                                //}
                                if (Connect_ToServerOnly(ref sErr))
                                {
                                    Disconnect();
                                    bNewDatabase = true;
                                }
                                else
                                {
                                    Error.Show(sErr);
                                    continue;
                                }
                            }

                        }
                        else
                        {
                            bNewDatabase = ConnectionDialog.m_bNewDataBase;
                        }

                        if (this.CheckDataBaseConnection(m_ParentForm, sTitle))
                        {
                            if (dRes == DialogResult.OK)
                            {
                                return ConnectResult_ENUM.OK;
                            }
                            else if (dRes == DialogResult.Yes)
                            {
                                ConnectionDialog.my_ConnectionDialog_enum = ConnectionDialog.ConnectionDialog_enum.SaveConnectionData;
                                dRes = ConnectionDialog.ShowDialog(m_ParentForm);
                                if (dRes == DialogResult.Yes)
                                {
                                    return ConnectResult_ENUM.OK_SAVE;
                                }
                                return ConnectResult_ENUM.OK;
                            }
                        }
                        else
                        {
                            if (m_DBType != eDBType.SQLITE)
                            {
                                ConnectionDialog.my_ConnectionDialog_enum = ConnectionDialog.ConnectionDialog_enum.TryAgain_EditAll;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        if (m_DBType != eDBType.SQLITE)
                        {
                            ConnectionDialog.my_ConnectionDialog_enum = ConnectionDialog.ConnectionDialog_enum.TryAgain_EditAll;
                        }
                        else
                        {
                            Error.Show("ERROR SQLITE:Excpetion = " + ex.Message);
                        }
                    }
                }
            }
        }


        public bool WizzardForDataBaseConnection(Form m_ParentForm,                    
                    string sTitle,ref bool bNewDatabase)
        {

            return false;
        }


        public bool FillDataTable(ref DataTable dt, string sqlGetColumnsNamesAndTypes, List<Log_SQL_Parameter> lSQL_Parameter, ref string csError)
        {
            //SqlConnection Conn = new SqlConnection("Data Source=razvoj1;Initial Catalog=NOS_BIH;Persist Security Info=True;User ID=sa;Password=sa;");
            if (DynSettings.bPreviewSQLBeforeExecution)
            {
                string new_sql = "";
                bool bChanged = false;
                PreviewSQLCommand(sqlGetColumnsNamesAndTypes, null, ref new_sql, ref bChanged, "ReadDataTable");
                if (bChanged)
                {
                    sqlGetColumnsNamesAndTypes = new_sql;
                }
            }
            try
            {
                switch (m_DBType)
                {
                    case eDBType.MYSQL:
                        {
                            MySqlDataAdapter adapter = new MySqlDataAdapter();

                            if (Connect(ref csError))
                            {
                                MySqlCommand SqlCommandcommandGetColumnsNamesAndTypes = new MySqlCommand(sqlGetColumnsNamesAndTypes, m_con_MYSQL);
                                SqlCommandcommandGetColumnsNamesAndTypes.CommandTimeout = CommandTimeout;
                                if (lSQL_Parameter != null)
                                {
                                    foreach (Log_SQL_Parameter sqlPar in lSQL_Parameter)
                                    {
                                        if (sqlPar.size > 0)
                                        {
                                            SqlCommandcommandGetColumnsNamesAndTypes.Parameters.Add(sqlPar.Name, sqlPar.MySQLdbType, sqlPar.size).Value = sqlPar.Value;
                                        }
                                        else
                                        {
                                            SqlCommandcommandGetColumnsNamesAndTypes.Parameters.Add(new MySqlParameter(sqlPar.Name, sqlPar.Value)).Value = sqlPar.Value;
                                        }
                                    }
                                }

                                adapter.SelectCommand = SqlCommandcommandGetColumnsNamesAndTypes;
                                adapter.Fill(dt);
                                adapter.Dispose();
                                SqlCommandcommandGetColumnsNamesAndTypes.Dispose();
                                Disconnect();
                            }
                            else
                            {
                                MessageBox.Show(csError, "ERROR", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                            }
                        }
                        return true;

                    case eDBType.MSSQL:
                        {
                            SqlDataAdapter adapter = new SqlDataAdapter();

                            if (Connect(ref csError))
                            {
                                SqlCommand SqlCommandcommandGetColumnsNamesAndTypes = new SqlCommand(sqlGetColumnsNamesAndTypes, m_con_MSSQL);
                                if (lSQL_Parameter != null)
                                {
                                    foreach (Log_SQL_Parameter sqlPar in lSQL_Parameter)
                                    {
                                        if (sqlPar.size > 0)
                                        {
                                            SqlCommandcommandGetColumnsNamesAndTypes.Parameters.Add(sqlPar.Name, sqlPar.dbType, sqlPar.size).Value = sqlPar.Value;
                                        }
                                        else
                                        {
                                            SqlCommandcommandGetColumnsNamesAndTypes.Parameters.Add(new SqlParameter(sqlPar.Name, sqlPar.Value)).Value = sqlPar.Value;
                                        }
                                    }
                                }
                                adapter.SelectCommand = SqlCommandcommandGetColumnsNamesAndTypes;
                                adapter.Fill(dt);
                                adapter.Dispose();
                                SqlCommandcommandGetColumnsNamesAndTypes.Dispose();
                                Disconnect();
                            }
                            else
                            {
                                MessageBox.Show(csError, "ERROR", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                            }
                        }
                        return true;

                    case eDBType.SQLITE:
                        {
                            SQLiteDataAdapter adapter = new SQLiteDataAdapter();

                            if (Connect(ref csError))
                            {

                                SQLiteCommand SqlCommandcommandGetColumnsNamesAndTypes = new SQLiteCommand(sqlGetColumnsNamesAndTypes, m_con_SQLite);
                                if (lSQL_Parameter != null)
                                {
                                    foreach (Log_SQL_Parameter sqlPar in lSQL_Parameter)
                                    {
                                        if (sqlPar.size > 0)
                                        {
                                            SQLiteParameter mySQLiteParameter = new SQLiteParameter(sqlPar.Name, sqlPar.SQLiteDbType, sqlPar.size);
                                            mySQLiteParameter.Value = sqlPar.Value;
                                            SqlCommandcommandGetColumnsNamesAndTypes.Parameters.Add(mySQLiteParameter);
                                        }
                                        else
                                        {
                                            SQLiteParameter mySQLiteParameter = new SQLiteParameter(sqlPar.Name, sqlPar.Value);
                                            SqlCommandcommandGetColumnsNamesAndTypes.Parameters.Add(mySQLiteParameter);
                                        }
                                    }
                                }

                                adapter.SelectCommand = SqlCommandcommandGetColumnsNamesAndTypes;
                                adapter.Fill(dt);
                                adapter.Dispose();
                                SqlCommandcommandGetColumnsNamesAndTypes.Dispose();
                                Disconnect();
                            }
                            else
                            {
                                MessageBox.Show(csError, "ERROR", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                            }
                        }
                        return true;

                    default:
                        MessageBox.Show("Error eSQLType in function: public bool ReadDataTable( ..)");
                        return false;
                }
            }
            catch (Exception ex)
            {
                Disconnect();

                ShowDBErrorMessage(ex.Message, null, "ExecuteNonQuerySQL");

                WriteLogTable(ex);
                return false;
            }
        }
        
        public bool ReadDataTable(ref DataTable dt, string sqlGetColumnsNamesAndTypes, ref string csError)
        {

            //SqlConnection Conn = new SqlConnection("Data Source=razvoj1;Initial Catalog=NOS_BIH;Persist Security Info=True;User ID=sa;Password=sa;");
            if (DynSettings.bPreviewSQLBeforeExecution)
            {
                string new_sql = "";
                bool bChanged = false;
                PreviewSQLCommand(sqlGetColumnsNamesAndTypes,null,ref new_sql,ref bChanged, "ReadDataTable");
                if (bChanged)
                {
                    sqlGetColumnsNamesAndTypes = new_sql;
                }
            }
            try
            {
                switch (m_DBType)
                {
                    case eDBType.MYSQL:
                        {
                            MySqlDataAdapter adapter = new MySqlDataAdapter();

                            if (Connect(ref csError))
                            {
                                MySqlCommand SqlCommandcommandGetColumnsNamesAndTypes = new MySqlCommand(sqlGetColumnsNamesAndTypes, m_con_MYSQL);
                                adapter.SelectCommand = SqlCommandcommandGetColumnsNamesAndTypes;
                                adapter.Fill(dt);
                                adapter.Dispose();
                                SqlCommandcommandGetColumnsNamesAndTypes.Dispose();
                                Disconnect();
                            }
                            else
                            {
                                MessageBox.Show(csError, "ERROR", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                            }
                        }
                        return true;

                    case eDBType.MSSQL:
                        {
                            SqlDataAdapter adapter = new SqlDataAdapter();

                            if (Connect(ref csError))
                            {
                                SqlCommand SqlCommandcommandGetColumnsNamesAndTypes = new SqlCommand(sqlGetColumnsNamesAndTypes, m_con_MSSQL);
                                adapter.SelectCommand = SqlCommandcommandGetColumnsNamesAndTypes;
                                adapter.Fill(dt);
                                adapter.Dispose();
                                SqlCommandcommandGetColumnsNamesAndTypes.Dispose();
                                Disconnect();
                            }
                            else
                            {
                                MessageBox.Show(csError, "ERROR", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                            }
                        }
                        return true;

                    case eDBType.SQLITE:
                        {
                            SQLiteDataAdapter adapter = new SQLiteDataAdapter();

                            if (Connect(ref csError))
                            {
                                SQLiteCommand SqlCommandcommandGetColumnsNamesAndTypes = new SQLiteCommand(sqlGetColumnsNamesAndTypes, m_con_SQLite);
                                adapter.SelectCommand = SqlCommandcommandGetColumnsNamesAndTypes;
                                adapter.Fill(dt);
                                adapter.Dispose();
                                SqlCommandcommandGetColumnsNamesAndTypes.Dispose();
                                Disconnect();
                            }
                            else
                            {
                                MessageBox.Show(csError, "ERROR", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                            }
                        }
                        return true;

                    default:
                        MessageBox.Show("Error eSQLType in function: public bool ReadDataTable( ..)");
                        return false;
                }
            }
            catch (Exception ex)
            {
                Disconnect();

                ShowDBErrorMessage(ex.Message, null, "ExecuteNonQuerySQL");
                csError = "ERROR:" + ex.Message;

                WriteLogTable(ex);
                return false;
            }
        }

        private string SetConnectionError()
        {
            switch (m_DBType)
            {
                case eDBType.MYSQL:
                return "ERROR Connection failed for MySQL Server Authetnication:\"" + m_conData_MYSQL.m_DataSource + "\" DataBase:\"" + m_conData_MYSQL.m_DataBase + "\" UserName:\"" + m_conData_MYSQL.m_UserName + "\" and Password:*******\n";

                case eDBType.MSSQL:
                    if (m_conData_MSSQL.m_bWindowsAuthentication)
                    {
                        return "ERROR Connection failed for SQL WINDOWS Authetnication:\"" + m_conData_MSSQL.m_DataSource + "\" DataBase:\"" + m_conData_MSSQL.m_DataBase + "\" UserName:\"" + m_conData_MSSQL.m_WindowsAuthentication_UserName + "\"\n";
                    }
                    else
                    {
                        return "ERROR Connection failed for SQL Server Authetnication:\"" + m_conData_MSSQL.m_DataSource + "\" DataBase:\"" + m_conData_MSSQL.m_DataBase + "\" UserName:\"" + m_conData_MSSQL.m_UserName + "\" and Password:*******\n";
                    }

                case eDBType.SQLITE:
                    return "ERROR Connection failed for SQLite DataBaseFile:\"" + this.SQLiteDataBaseFile + "\"\n";

                default:
                    MessageBox.Show("ERROR eSQLType in function:private string SetConnectionError()");
                    return "ERROR eSQLType in function:        private string SetConnectionError()";

            }
        }

        public bool ReadDataSet(ref DataSet ds, string sqlGetColumnsNamesAndTypes, ref string csError)
        {

            //SqlConnection Conn = new SqlConnection("Data Source=razvoj1;Initial Catalog=NOS_BIH;Persist Security Info=True;User ID=sa;Password=sa;");
            if (DynSettings.bPreviewSQLBeforeExecution)
            {
                string new_sql = "";
                bool bChanged = false;
                PreviewSQLCommand(sqlGetColumnsNamesAndTypes, null, ref new_sql, ref bChanged, "ReadDataSet");
                if (bChanged)
                {
                    sqlGetColumnsNamesAndTypes = new_sql;
                }
            }
            try
            {
                switch (m_DBType)
                {
                    case eDBType.MYSQL:
                        {
                            MySqlDataAdapter adapter = new MySqlDataAdapter();
                            string sError = "";
                            if (Connect(ref sError))
                            {
                                MySqlCommand SqlCommandcommandGetColumnsNamesAndTypes = new MySqlCommand(sqlGetColumnsNamesAndTypes, m_con_MYSQL);
                                adapter.SelectCommand = SqlCommandcommandGetColumnsNamesAndTypes;
                                adapter.Fill(ds);
                                adapter.Dispose();
                                SqlCommandcommandGetColumnsNamesAndTypes.Dispose();
                                Disconnect();
                            }
                            else
                            {
                                MessageBox.Show(sError, "ERROR", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                            }
                        }
                        return true;
                    case eDBType.MSSQL:
                        {
                            SqlDataAdapter adapter = new SqlDataAdapter();
                            string sError = "";
                            if (Connect(ref sError))
                            {
                                SqlCommand SqlCommandcommandGetColumnsNamesAndTypes = new SqlCommand(sqlGetColumnsNamesAndTypes, m_con_MSSQL);
                                adapter.SelectCommand = SqlCommandcommandGetColumnsNamesAndTypes;
                                adapter.Fill(ds);
                                adapter.Dispose();
                                SqlCommandcommandGetColumnsNamesAndTypes.Dispose();
                                Disconnect();
                            }
                            else
                            {
                                MessageBox.Show(sError, "ERROR", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                            }
                        }
                        return true;

                    case eDBType.SQLITE:
                        {
                            SQLiteDataAdapter adapter = new SQLiteDataAdapter();
                            string sError = "";
                            if (Connect(ref sError))
                            {
                                SQLiteCommand SqlCommandcommandGetColumnsNamesAndTypes = new SQLiteCommand(sqlGetColumnsNamesAndTypes, m_con_SQLite);
                                adapter.SelectCommand = SqlCommandcommandGetColumnsNamesAndTypes;
                                adapter.Fill(ds);
                                adapter.Dispose();
                                SqlCommandcommandGetColumnsNamesAndTypes.Dispose();
                                Disconnect();
                            }
                            else
                            {
                                MessageBox.Show(sError, "ERROR", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                            }
                        }
                        return true;


                    default:
                        MessageBox.Show("ERROR eSQLType in function:public bool ReadDataSet(..)");
                        return false;
                }
            }
            catch (Exception ex)
            {
                //System.Windows.Forms.MessageBox.Show("SQL ERROR:" + ex.Message);
                Disconnect();

                ShowDBErrorMessage(ex.Message, null, "ReadDataSet");
                WriteLogTable(ex);
                return false;
            }
        }

        private bool IsNumber(string s)
        {
            s = s.Trim();
            for (int i = 0; i < s.Length; i++)
            {
                string numbers = "0123456789";
                if (!numbers.Contains(s.Substring(i, 1)))
                {
                    return false;
                }
            }
            return true;
        }



        public bool ExecuteQuerySQL(StringBuilder sql,List<Log_SQL_Parameter> lSQL_Parameter, ref Int32 id_new, ref Object objRet, ref string csError,string SQlite_table_name)
        {
            //SqlConnection Conn = new SqlConnection("Data Source=razvoj1;Initial Catalog=NOS_BIH;Persist Security Info=True;User ID=sa;Password=sa;");

            if (DynSettings.bPreviewSQLBeforeExecution)
            {
                string new_sql = "";
                bool bChanged = false;
                PreviewSQLCommand(sql.ToString(), lSQL_Parameter, ref new_sql, ref bChanged, "ExecuteQuerySQL");
                if (bChanged)
                {
                    sql = new StringBuilder(new_sql);
                }
            }

            StringBuilder sqlTran = new StringBuilder();

            id_new = -1;
            try
            {
                switch (m_DBType)
                {
                    case eDBType.MYSQL:
                        {
                            sqlTran.Append("START TRANSACTION; \n");
                            sqlTran.Append(sql);
                            sqlTran.Append("\nCOMMIT;\n");
                            MySqlCommand command;
                            string sError = "";
                            if (Connect(ref sError))
                            {
                                command = new MySqlCommand(sqlTran.ToString(), m_con_MYSQL);
                                command.CommandTimeout = 20000;
                                if (lSQL_Parameter != null)
                                {
                                    foreach (Log_SQL_Parameter sqlPar in lSQL_Parameter)
                                    {
                                        if (sqlPar.size > 0)
                                        {
                                            command.Parameters.Add(sqlPar.Name, sqlPar.MySQLdbType, sqlPar.size).Value = sqlPar.Value;
                                        }
                                        else
                                        {
                                            command.Parameters.Add(new MySqlParameter(sqlPar.Name, sqlPar.Value)).Value = sqlPar.Value;
                                        }
                                    }
                                }

                                Object ReturnObject = command.ExecuteScalar();
                                if (ReturnObject != null)
                                {
                                    if (ReturnObject.GetType() == typeof(string))
                                    {
                                        string s;
                                        s = (string)ReturnObject;
                                        if (IsNumber(s))
                                        {
                                            id_new = Convert.ToInt32(s);
                                        }
                                    }
                                    else if (ReturnObject.GetType() == typeof(Int32))
                                    {
                                        id_new = (int) ReturnObject;
                                    }
                                    else if (ReturnObject.GetType() == typeof(Int64))
                                    {
                                        id_new = Convert.ToInt32(ReturnObject);
                                    }
                                    objRet = ReturnObject;
                                }
                                Disconnect();
                                return true;
                            }
                            else
                            {
                                MessageBox.Show(sError, "ERROR", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                                return false;
                            }
                        }
                        //break;

                    case eDBType.MSSQL:
                        {
                            sqlTran.Append("BEGIN TRAN TRANSACTION_EVLicence; \n");
                            sqlTran.Append(sql);
                            sqlTran.Append("\nCOMMIT TRAN TRANSACTION_EVLicence; \n");

                            SqlCommand command;
                            string sError = "";
                            if (Connect(ref sError))
                            {
                                command = new SqlCommand(sqlTran.ToString(), m_con_MSSQL);
                                command.CommandTimeout = 200000;
                                if (lSQL_Parameter != null)
                                {
                                    foreach (Log_SQL_Parameter sqlPar in lSQL_Parameter)
                                    {
                                        if (sqlPar.size > 0)
                                        {
                                            command.Parameters.Add(sqlPar.Name, sqlPar.dbType, sqlPar.size).Value = sqlPar.Value;
                                        }
                                        else
                                        {
                                            command.Parameters.Add(new SqlParameter(sqlPar.Name, sqlPar.Value)).Value = sqlPar.Value;
                                        }
                                    }
                                }

                                Object ReturnObject = command.ExecuteScalar();
                                if (ReturnObject != null)
                                {
                                    if (ReturnObject.GetType() == typeof(string))
                                    {
                                        string s;
                                        s = (string)ReturnObject;
                                        if (IsNumber(s))
                                        {
                                            id_new = Convert.ToInt32(s);
                                        }
                                    }
                                    objRet = ReturnObject;
                                }
                                Disconnect();
                                return true;
                            }
                            else
                            {
                                MessageBox.Show(sError, "ERROR", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                                return false;
                            }
                        }
                        //break;

                    case eDBType.SQLITE:
                        {
                            sqlTran.Append("BEGIN TRANSACTION;\n");
                            sqlTran.Append(sql);
                            sqlTran.Append(";\nCOMMIT TRANSACTION;\n");
                            SQLiteCommand command;
                            string sError = "";
                            if (Connect(ref sError))
                            {
                                command = new SQLiteCommand(sqlTran.ToString(), m_con_SQLite);
                                command.CommandTimeout = 200000;
                                if (lSQL_Parameter != null)
                                {
                                    foreach (Log_SQL_Parameter sqlPar in lSQL_Parameter)
                                    {
                                        if (sqlPar.size > 0)
                                        {
                                            SQLiteParameter mySQLiteParameter = new SQLiteParameter(sqlPar.Name, sqlPar.SQLiteDbType, sqlPar.size);
                                            mySQLiteParameter.Value = sqlPar.Value;
                                            command.Parameters.Add(mySQLiteParameter);
                                        }
                                        else
                                        {
                                            SQLiteParameter mySQLiteParameter = new SQLiteParameter(sqlPar.Name, sqlPar.Value);
                                            command.Parameters.Add(mySQLiteParameter);
                                        }
                                    }
                                }

                                Object ReturnObject = command.ExecuteScalar();
                                Disconnect();
                                if (ReturnObject == null)
                                {
                                    //SQLiteCommand cmd = new SQLiteCommand("SELECT last_insert_rowid() AS ID" , m_con_SQLite);
                                    // On different Sqlite.dll runs different !
//                                    SQLiteCommand cmd = new SQLiteCommand("SELECT last_insert_rowid() from " + SQlite_table_name, m_con_SQLite);
                                    SQLiteCommand cmd = new SQLiteCommand("SELECT last_insert_rowid()", m_con_SQLite);
                                    // Bepaal de nieuwe ID en sla deze op in het juiste veld
                                    if (Connect(ref sError))
                                    {
                                        object nieuweID = cmd.ExecuteScalar();
                                        id_new = Convert.ToInt32(nieuweID);
                                        Disconnect();
                                    }
                                    else
                                    {
                                        Error.Show(sError);
                                        return false;
                                    }
                                }
                                else
                                {
                                    if (ReturnObject.GetType() == typeof(string))
                                    {
                                        string s;
                                        s = (string)ReturnObject;
                                        if (IsNumber(s))
                                        {
                                            id_new = Convert.ToInt32(s);
                                        }
                                    }
                                    else if (ReturnObject.GetType() == typeof(long))
                                    {
                                        id_new = Convert.ToInt32(ReturnObject);
                                    }
                                    else if (ReturnObject.GetType() == typeof(Int32))
                                    {
                                        id_new = Convert.ToInt32(ReturnObject);
                                    }
                                    else if (ReturnObject.GetType() == typeof(Int64))
                                    {
                                        id_new = Convert.ToInt32(ReturnObject);
                                    }
                                    objRet = ReturnObject;
                                }
                                return true;
                            }
                            else
                            {
                                Error.Show(sError);
                                return false;
                            }
                        }
                        //break;

                    default:
                        Error.Show("Error eSQLType in function:public bool ExecuteQuerySQL(...)");
                        return false;
                }
            }
            catch (System.Exception ex)
            {
                //System.Windows.Forms.MessageBox.Show("SQL ERROR:" + ex.Message);
                csError = "Error ExecuteQuerySQL :" + ex.Message;
                ShowDBErrorMessage(ex.Message, lSQL_Parameter, "ExecuteNonQuerySQL");
                Disconnect();
                WriteLogTable(ex);
                return false;
            }
        }




        public bool ExecuteNonQuerySQL(string sql, List<Log_SQL_Parameter> lSQL_Parameter, ref object Result, ref string ErrorMsg)
        {
            //SqlConnection Conn = new SqlConnection(xString);
            if (DynSettings.bPreviewSQLBeforeExecution)
            {
                string new_sql = "";
                bool bChanged = false;
                PreviewSQLCommand(sql, lSQL_Parameter, ref new_sql, ref bChanged, "ExecuteNonQuerySQL");
                if (bChanged)
                {
                    sql = new_sql;
                }

            }
            StringBuilder sqlTran = new StringBuilder();


            try
            {
                if (Connect(ref ErrorMsg))
                {
                    switch (m_DBType)
                    {
                        case eDBType.MYSQL:
                        {
                            sqlTran.Append("START TRANSACTION; \n");
                            sqlTran.Append(sql);
                            sqlTran.Append("\nCOMMIT; \n");
                            MySqlCommand command;
                            command = new MySqlCommand(sqlTran.ToString(), m_con_MYSQL);
                            if (lSQL_Parameter != null)
                            {
                                foreach (Log_SQL_Parameter sqlPar in lSQL_Parameter)
                                {
                                    if (sqlPar.size > 0)
                                    {
                                        command.Parameters.Add(sqlPar.Name, sqlPar.MySQLdbType, sqlPar.size).Value = sqlPar.Value;
                                    }
                                    else
                                    {
                                        command.Parameters.Add(new MySqlParameter(sqlPar.Name, sqlPar.Value)).Value = sqlPar.Value;
                                    }
                                }
                            }

                            command.CommandTimeout = 200000;
                            command.ExecuteNonQuery();
                            Disconnect();
                        }
                        return true;

                        case eDBType.MSSQL:
                        {
                            sqlTran.Append("BEGIN TRAN TRANSACTION_EVLicence; \n");
                            sqlTran.Append(sql);
                            sqlTran.Append("\nCOMMIT TRAN TRANSACTION_EVLicence; \n");
                            SqlCommand command;
                            SqlParameter OutPar = null;
                            command = new SqlCommand(sqlTran.ToString(), m_con_MSSQL);
                            if (lSQL_Parameter != null)
                            {
                                foreach (Log_SQL_Parameter sqlPar in lSQL_Parameter)
                                {
                                    if (sqlPar.size > 0)
                                    {
                                        SqlParameter SqlP = new SqlParameter(sqlPar.Name, sqlPar.dbType, sqlPar.size);
                                        sqlPar.MS_SqlSqlParameter = SqlP;
                                        if (sqlPar.IsOutputParameter)
                                        {
                                            SqlP.Direction = ParameterDirection.Output;
                                            if (OutPar == null)
                                            {
                                                // only first is return value!
                                                OutPar = SqlP;
                                            }
                                        }
                                        else
                                        {
                                            SqlP.Direction = ParameterDirection.Input;
                                        }
                                        command.Parameters.Add(SqlP).Value = sqlPar.Value;
                                    }
                                    else
                                    {
                                        SqlParameter SqlP = new SqlParameter(sqlPar.Name, sqlPar.Value);
                                        sqlPar.MS_SqlSqlParameter = SqlP;
                                        if (sqlPar.IsOutputParameter)
                                        {
                                            SqlP.Direction = ParameterDirection.Output;
                                            sqlPar.Value = SqlP.Value;
                                            if (OutPar == null)
                                            {
                                                // only first is return value!
                                                OutPar = SqlP;
                                            }
                                        }
                                        else
                                        {
                                            SqlP.Direction = ParameterDirection.Input;
                                        }
                                        command.Parameters.Add(SqlP).Value = sqlPar.Value;
                                    }
                                }
                            }

                            command.CommandTimeout = 3600;
                            command.ExecuteNonQuery();
                            if (Result != null)
                            {
                                if (OutPar != null)
                                {
                                    Result = OutPar.Value;
                                }
                                else
                                {
                                    Result = OutPar;
                                }
                            }
                            Disconnect();
                            return true;
                        }
                        //return true;

                        case eDBType.SQLITE:
                        {
                            sqlTran.Append("BEGIN TRANSACTION; \n");
                            sqlTran.Append(sql);
                            sqlTran.Append(";\nCOMMIT TRANSACTION; \n");
                            SQLiteCommand command;
                            command = new SQLiteCommand(sqlTran.ToString(), m_con_SQLite);
                            if (lSQL_Parameter != null)
                            {
                                foreach (Log_SQL_Parameter sqlPar in lSQL_Parameter)
                                {

                                    if (sqlPar.size > 0)
                                    {
                                        sqlPar.mySQLiteParameter = new SQLiteParameter(sqlPar.Name, sqlPar.SQLiteDbType, sqlPar.size);
                                        sqlPar.mySQLiteParameter.Value = sqlPar.Value;

                                    }
                                    else
                                    {
                                        sqlPar.mySQLiteParameter = new SQLiteParameter(sqlPar.Name, sqlPar.Value);
                                        sqlPar.mySQLiteParameter.Value = sqlPar.Value;
                                    }
                                    command.Parameters.Add(sqlPar.mySQLiteParameter);

                                }
                            }
                            command.CommandTimeout = 20000;
                            command.ExecuteNonQuery();
                            Disconnect();
                        }
                        return true;

                        default:
                            MessageBox.Show("Error eSQLType in function: ExecuteNonQuerySQL(...)");
                            return false;
                    }
                }
                else
                {
     //               MessageBox.Show(csError, "ERROR", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (Exception ex)
            {
                //System.Windows.Forms.MessageBox.Show("SQL ERROR:" + ex.Message);
                ErrorMsg = ex.Message;
                Disconnect();

                ShowDBErrorMessage(ex.Message, lSQL_Parameter, "ExecuteNonQuerySQL");


                try
                {
                    WriteLogTable(ex);
                    return false;
                }
                catch (Exception ee)
                {
                    Disconnect();
                    Console.WriteLine(ee.ToString());
                    return false;
                    //throw new Exception(ee.ToString(), ee);
                }
            }
        }

        private void WriteLogTable(Exception ex)
        {
            if (LogTableName != null)
            {
                if (LogTableName.Length > 0)
                {
                    switch (m_DBType)
                    {
                        case eDBType.MYSQL:
                            InsertTo_MYSQL_Log(ex);
                            break;

                        case eDBType.MSSQL:
                            InsertTo_MSSQL_Log(ex);
                            break;
                        case eDBType.SQLITE:
                            InsertTo_SQLite_Log(ex);
                            break;

                        default:
                            MessageBox.Show("Error eSQLType in function ExecuteNonQuerySQL(...)");
                            break;
                    }
                }
            }
        }

        private bool InsertTo_MYSQL_Log(Exception ex)
        {
            try
            {
                string sqlLog = @"
                            SET DATEFORMAT dmy
                            INSERT INTO  " + LogTableName + @"
                              (
                                 LogTime, 
                                 message
                              )
                             VALUES 
                            ("
               + "getdate(),\n"
               + "'" + ex.ToString().Replace("'", "\"") + @"'
                            );";

                string sErr = "";
                if (Connect(ref sErr))
                {
                    MySqlCommand command;
                    command = new MySqlCommand(sqlLog, m_con_MYSQL);
                    command.ExecuteNonQuery();
                    Disconnect();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ee)
            {
                Disconnect();
                Console.WriteLine(ee.Message);
                return false;
            }
        }

        private bool InsertTo_MSSQL_Log(Exception ex)
        {
            try
            {
               string sqlLog = @"
                        SET DATEFORMAT dmy
                        INSERT INTO  " + LogTableName  + @"
                          (
                             LogTime, 
                             message
                          )
                         VALUES 
                        ("
              + "getdate(),\n"
              + "'" + ex.ToString().Replace("'", "\"") + @"'
                        );";

                string sErr = "";
                if (Connect(ref sErr))
                {
                    SqlCommand command;
                    command = new SqlCommand(sqlLog, m_con_MSSQL);
                    command.ExecuteNonQuery();
                    Disconnect();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ee)
            {
                Disconnect();
                Console.WriteLine(ee.Message);
                return false;
            }
        }

        private bool InsertTo_SQLite_Log(Exception ex)
        {
            try
            {
                string sqlLog = @"
                        SET DATEFORMAT dmy
                        INSERT INTO  " + LogTableName + @"
                          (
                             LogTime, 
                             message
                          )
                         VALUES 
                        ("
               + "getdate(),\n"
               + "'" + ex.ToString().Replace("'", "\"") + @"'
                        );";

                string sErr = "";
                if (Connect(ref sErr))
                {
                    SQLiteCommand command;
                    command = new SQLiteCommand(sqlLog, m_con_SQLite);
                    command.ExecuteNonQuery();
                    Disconnect();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ee)
            {
                Disconnect();
                Console.WriteLine(ee.Message);
                return false;
            }
        }

        public bool CreateMySQLDatabase(string sql, ref string ErrorMsg)
        {
            if (DynSettings.bPreviewSQLBeforeExecution)
            {
                string new_sql = "";
                bool bChanged = false;
                PreviewSQLCommand(sql, null, ref new_sql, ref bChanged,  null);
                if (bChanged)
                {
                    sql = new_sql;
                }
            }
            try
            {
                if (this.Connect_ToServerOnly(ref ErrorMsg))
                {
                    switch (m_DBType)
                    {
                        case eDBType.MYSQL:
                            {
                                MySqlCommand command;
                                command = new MySqlCommand(sql, m_con_MYSQL);
                                command.CommandTimeout = 200000;
                                command.ExecuteNonQuery();
                                Disconnect();
                            }
                            return true;

                        case eDBType.MSSQL:
                            {
                                SqlCommand command;
                                command = new SqlCommand(sql, m_con_MSSQL);
                                command.CommandTimeout = 200000;
                                command.ExecuteNonQuery();
                                Disconnect();
                            }
                            return true;

                        default:
                            MessageBox.Show("Error eSQLType in function ExecuteNonQuerySQL(...)");
                            return false;
                        
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                //System.Windows.Forms.MessageBox.Show("SQL ERROR:" + ex.Message);
                ErrorMsg = ex.Message;
                Disconnect();

                ShowDBErrorMessage(ex.Message, null, "ExecuteNonQuerySQL_NoMultiTrans");

                WriteLogTable(ex);
                return false;
                    //throw new Exception(ee.ToString(), ee);
            }
        }

        public bool ExecuteNonQuerySQL_NoMultiTrans(string sql, List<Log_SQL_Parameter> lSQL_Parameter, ref string ErrorMsg)
        {
            //SqlConnection Conn = new SqlConnection(xString);
            if (DynSettings.bPreviewSQLBeforeExecution)
            {
                string new_sql = "";
                bool bChanged = false;
                PreviewSQLCommand(sql, lSQL_Parameter, ref new_sql, ref bChanged, "ExecuteNonQuerySQL_NoMultiTrans");
                if (bChanged)
                {
                    sql = new_sql;
                }

            }
            try
            {
                if (Connect(ref ErrorMsg))
                {
                    switch (m_DBType)
                    {
                        case eDBType.MYSQL:
                         {
                            MySqlCommand command;
                            command = new MySqlCommand(sql, m_con_MYSQL);
                            if (lSQL_Parameter != null)
                            {
                                foreach (Log_SQL_Parameter sqlPar in lSQL_Parameter)
                                {
                                    if (sqlPar.size > 0)
                                    {
                                        command.Parameters.Add(sqlPar.Name, sqlPar.MySQLdbType, sqlPar.size).Value = sqlPar.Value;
                                    }
                                    else
                                    {
                                        command.Parameters.Add(new MySqlParameter(sqlPar.Name, sqlPar.Value)).Value = sqlPar.Value;
                                    }
                                }
                            }

                            command.CommandTimeout = 200000;
                            command.ExecuteNonQuery();
                            Disconnect();
                         }
                        return true;

                        case eDBType.MSSQL:
                        {

                            SqlCommand command;
                            command = new SqlCommand(sql, m_con_MSSQL);
                            if (lSQL_Parameter != null)
                            {
                                foreach (Log_SQL_Parameter sqlPar in lSQL_Parameter)
                                {
                                    if (sqlPar.size > 0)
                                    {
                                        command.Parameters.Add(sqlPar.Name, sqlPar.dbType, sqlPar.size).Value = sqlPar.Value;
                                    }
                                    else
                                    {
                                        command.Parameters.Add(new SqlParameter(sqlPar.Name, sqlPar.Value)).Value = sqlPar.Value;
                                    }
                                }
                            }

                            command.CommandTimeout = 200000;
                            command.ExecuteNonQuery();
                            Disconnect();
                        }
                        return true;

                        case eDBType.SQLITE:
                        {

                            SQLiteCommand command;
                            command = new SQLiteCommand(sql, m_con_SQLite);
                            if (lSQL_Parameter != null)
                            {
                                foreach (Log_SQL_Parameter sqlPar in lSQL_Parameter)
                                {
                                    if (sqlPar.size > 0)
                                    {
                                        sqlPar.mySQLiteParameter = new SQLiteParameter(sqlPar.Name, sqlPar.SQLiteDbType, sqlPar.size);
                                        sqlPar.mySQLiteParameter.Value = sqlPar.Value;
                                        command.Parameters.Add(sqlPar.mySQLiteParameter);
                                    }
                                    else
                                    {
                                        sqlPar.mySQLiteParameter = new SQLiteParameter(sqlPar.Name, sqlPar.Value);
                                        sqlPar.mySQLiteParameter.Value = sqlPar.Value;
                                        command.Parameters.Add(sqlPar.mySQLiteParameter);
                                    }
                                }
                            }

                            command.CommandTimeout = 200000;
                            command.ExecuteNonQuery();
                            Disconnect();

                        }
                        return true;

                        default:
                            MessageBox.Show("Error eSQLType in function public bool ExecuteNonQuerySQL_NoMultiTrans(...)");
                            return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                //System.Windows.Forms.MessageBox.Show("SQL ERROR:" + ex.Message);
                ErrorMsg = ex.Message;
                Disconnect();

                ShowDBErrorMessage(ex.Message, lSQL_Parameter, "ExecuteNonQuerySQL_NoMultiTrans");

                WriteLogTable(ex);
                return false;
            }
        }

        private bool Execute_SQLReadData(string sql, List<Log_SQL_Parameter> lSQL_Parameter,out SQLReaderTable ReaderTable, ref string ErrorMsg)
        {
            //SqlConnection Conn = new SqlConnection(xString);
            ReaderTable = null;
            if (DynSettings.bPreviewSQLBeforeExecution)
            {
                string new_sql = "";
                bool bChanged = false;
                PreviewSQLCommand(sql, null, ref new_sql, ref bChanged, "Execute_SQLReadData");
                if (bChanged)
                {
                    sql = new_sql;
                }
                
            }
            try
            {
                if (Connect(ref ErrorMsg))
                {
                    switch (m_DBType)
                    {
                        case eDBType.MYSQL:
                        {
                            MySqlCommand command;
                            command = new MySqlCommand(sql, m_con_MYSQL);
                            if (lSQL_Parameter != null)
                            {
                                foreach (Log_SQL_Parameter sqlPar in lSQL_Parameter)
                                {
                                    if (sqlPar.size > 0)
                                    {
                                        command.Parameters.Add(sqlPar.Name, sqlPar.MySQLdbType, sqlPar.size).Value = sqlPar.Value;
                                    }
                                    else
                                    {
                                        command.Parameters.Add(new MySqlParameter(sqlPar.Name, sqlPar.Value)).Value = sqlPar.Value;
                                    }
                                }
                            }

                            command.CommandTimeout = 200000;

                            MySqlDataReader reader = command.ExecuteReader();

                            ReaderTable = new SQLReaderTable();

                            try
                            {
                                while (reader.Read())
                                {
                                    SQLReaderRow ReaderRow = new SQLReaderRow();
                                    foreach (Object obj in reader)
                                    {
                                        ReaderRow.column.Add(obj);
                                    }
                                    ReaderTable.row.Add(ReaderRow);
                                }
                            }
                            finally
                            {
                                // Always call Close when done reading.
                                reader.Close();
                            }

                            Disconnect();
                        }
                        return true;


                        case eDBType.MSSQL:
                        {
                            SqlCommand command;
                            command = new SqlCommand(sql, m_con_MSSQL);
                            if (lSQL_Parameter != null)
                            {
                                foreach (Log_SQL_Parameter sqlPar in lSQL_Parameter)
                                {
                                    if (sqlPar.size > 0)
                                    {
                                        command.Parameters.Add(sqlPar.Name, sqlPar.dbType, sqlPar.size).Value = sqlPar.Value;
                                    }
                                    else
                                    {
                                        command.Parameters.Add(new SqlParameter(sqlPar.Name, sqlPar.Value)).Value = sqlPar.Value;
                                    }
                                }
                            }

                            command.CommandTimeout = 200000;

                            SqlDataReader reader = command.ExecuteReader();

                            ReaderTable = new SQLReaderTable();

                            try
                            {
                                while (reader.Read())
                                {
                                    SQLReaderRow ReaderRow = new SQLReaderRow();
                                    foreach (Object obj in reader)
                                    {
                                        ReaderRow.column.Add(obj);
                                    }
                                    ReaderTable.row.Add(ReaderRow);
                                }
                            }
                            finally
                            {
                                // Always call Close when done reading.
                                reader.Close();
                            }


                            Disconnect();
                        }
                        return true;

                        case eDBType.SQLITE:
                        {
                            SQLiteCommand command;
                            command = new SQLiteCommand(sql, m_con_SQLite);
                            if (lSQL_Parameter != null)
                            {
                                foreach (Log_SQL_Parameter sqlPar in lSQL_Parameter)
                                {
                                    if (sqlPar.size > 0)
                                    {
                                        SQLiteParameter mySQLiteParameter = new SQLiteParameter(sqlPar.Name, sqlPar.SQLiteDbType);
                                        mySQLiteParameter.Value = sqlPar.Value;
                                        command.Parameters.Add(mySQLiteParameter);
                                    }
                                    else
                                    {
                                        command.Parameters.Add(new SQLiteParameter(sqlPar.Name, sqlPar.Value));
                                    }
                                }
                            }

                            command.CommandTimeout = 200000;

                            SQLiteDataReader reader = command.ExecuteReader();

                            ReaderTable = new SQLReaderTable();

                            try
                            {
                                while (reader.Read())
                                {
                                    SQLReaderRow ReaderRow = new SQLReaderRow();
                                    foreach (Object obj in reader)
                                    {
                                        ReaderRow.column.Add(obj);
                                    }
                                    ReaderTable.row.Add(ReaderRow);
                                }
                            }
                            finally
                            {
                                // Always call Close when done reading.
                                reader.Close();
                            }

                            Disconnect();
                        }
                        return true;

                        default:
                            MessageBox.Show("Error eSQLType in function: private bool Execute_SQLReadData(...)");
                            return false;

                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                //System.Windows.Forms.MessageBox.Show("SQL ERROR:" + ex.Message);
                ErrorMsg = ex.Message;
                Disconnect();

                ShowDBErrorMessage(ex.Message, lSQL_Parameter, "Execute_SQLReadData");

                WriteLogTable(ex);
                return false;
            }
        }

        public bool CheckPermission_ALTER_ANY_DATABASE()
        {
            switch (m_DBType)
            {
                case eDBType.MSSQL:
                {
                    DataSet ds = new DataSet();
                    string csError = "";
                    string sql_cmd = @"SELECT permission_name
                                       FROM fn_my_permissions(NULL, 'SERVER') WHERE permission_name = '" + const_MSSQL_ALTER_ANY_DATABASE + "'";

                    string saved_DataBaseName = m_conData_MSSQL.m_DataBase;
                    m_conData_MSSQL.m_DataBase = "";

                    if (ReadDataSet(ref ds, sql_cmd, ref csError))
                    {
                        m_conData_MSSQL.m_DataBase = saved_DataBaseName;

                        if (ds.Tables.Count > 0)
                        {
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                if (ds.Tables[0].Rows[0].ItemArray[0] != null)
                                {
                                    if (ds.Tables[0].Rows[0].ItemArray[0].GetType() == typeof(String))
                                    {
                                        string sValue = ds.Tables[0].Rows[0].ItemArray[0].ToString();
                                        if (sValue.Equals(const_MSSQL_ALTER_ANY_DATABASE))
                                        {
                                            return true;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        m_conData_MSSQL.m_DataBase = saved_DataBaseName;
                    }
                }
                return false;

                case eDBType.MYSQL:
                {
                    DataSet ds = new DataSet();
                    string csError = "";
                    string sql_cmd = @"SELECT Create_priv
                                            FROM USER WHERE User = '" + m_conData_MSSQL.m_UserName + "'";

                    string saved_DataBaseName = m_conData_MSSQL.m_DataBase;
                    m_conData_MSSQL.m_DataBase = "";

                    if (ReadDataSet(ref ds, sql_cmd, ref csError))
                    {
                        m_conData_MSSQL.m_DataBase = saved_DataBaseName;

                        if (ds.Tables.Count > 0)
                        {
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                if (ds.Tables[0].Rows[0].ItemArray[0] != null)
                                {
                                    if (ds.Tables[0].Rows[0].ItemArray[0].GetType() == typeof(String))
                                    {
                                        string sValue = ds.Tables[0].Rows[0].ItemArray[0].ToString();
                                        if (sValue.Equals(const_MSSQL_ALTER_ANY_DATABASE))
                                        {
                                            return true;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        m_conData_MSSQL.m_DataBase = saved_DataBaseName;
                    }
                }
                return false;

                case eDBType.SQLITE:
                    return true;

                default:
                    MessageBox.Show("Error eSQLType in function:public bool CheckPermission(string csPermission)");
                    return false;

            }
        }

        private void PreviewSQLCommand(string sql, List<Log_SQL_Parameter> lSQL_Parameter, ref string OutString, ref bool bChanged, string Title)
        {
            bChanged = false;
            SqlBuilder.Forms.frmEditor frmEditor = new SqlBuilder.Forms.frmEditor(sql,lSQL_Parameter, Title);
            if (frmEditor.ShowDialog()==DialogResult.OK)
            {
                bChanged = true;
                OutString = frmEditor.s_sql_text;
            }
        }

        private void ShowDBErrorMessage(string ErrorMsg, List<Log_SQL_Parameter> lSQL_Parameter, string Title)
        {
            if (m_ShowDBErrorMessages)
            {
                SqlBuilder.Forms.frmEditor frmEditor = new SqlBuilder.Forms.frmEditor(ErrorMsg, lSQL_Parameter, Title);
                if (frmEditor.ShowDialog() == DialogResult.OK)
                {
                }
            }
        }

        public string DataBase
        {
            get
            {
                switch (m_DBType)
                {
                    case eDBType.MYSQL:
                        if (m_conData_MYSQL != null)
                        {
                            return m_conData_MYSQL.m_DataBase;
                        }
                        else
                        {
                            return null;
                        }

                    case eDBType.MSSQL:
                        if (m_conData_MSSQL != null)
                        {
                            return m_conData_MSSQL.m_DataBase;
                        }
                        else
                        {
                            return null;
                        }

                    case eDBType.SQLITE:
                        return m_conData_SQLITE.DataBaseFile;
                    default:
                        Error.Show("Error: Illegal m_DBType in properrty DataBase");
                        return "";
                        
                }
            }
            set
            {
                switch (m_DBType)
                {
                    case eDBType.MYSQL:
                        m_conData_MYSQL.m_DataBase = value;
                        break;
                    case eDBType.MSSQL:
                        m_conData_MSSQL.m_DataBase = value;
                        break;
                    case eDBType.SQLITE:
                        m_conData_SQLITE.DataBaseFile = value;
                        break;
                    default:
                        Error.Show("Error: Illegal m_DBType in properrty DataBase");
                        break;
                }
            }
        }

        public string DataSource
        {
            get
            {
                switch (m_DBType)
                {
                    case eDBType.MYSQL:
                        return m_conData_MYSQL.m_DataSource;

                    case eDBType.MSSQL:
                        return m_conData_MSSQL.m_DataSource;

                    case eDBType.SQLITE:
                        return m_conData_SQLITE.DataBaseFile;

                    default:
                        MessageBox.Show("Error eSQLType in property:  public string DataSource");
                        return "Error public string DataSource";
                }
            }
            set
            {
                switch (m_DBType)
                {
                    case eDBType.MYSQL:
                        m_conData_MYSQL.m_DataSource = value;
                        break;
                    case eDBType.MSSQL:
                        m_conData_MSSQL.m_DataSource = value;
                        break;
                    case eDBType.SQLITE:
                        m_conData_SQLITE.DataBaseFile = value;
                        break;
                }
            }
        }

        public string UserName
        {
            get
            {
                switch (m_DBType)
                {
                    case eDBType.MYSQL:
                        return m_conData_MYSQL.m_UserName;

                    case eDBType.MSSQL:
                        return m_conData_MSSQL.m_UserName;

                    case eDBType.SQLITE:
                        Error.Show("Error in get property UserName:  SQLITE does not support UserName");
                        return "";
                    default:
                        Error.Show("Error in get property UserName:  unvalid m_DBType");
                        return "";

                }
            }
            set
            {
                switch (m_DBType)
                {
                    case eDBType.MYSQL:
                        m_conData_MYSQL.m_UserName = value;
                        break;
                    case eDBType.MSSQL:
                        m_conData_MSSQL.m_UserName = value;
                        break;
                    case eDBType.SQLITE:
                        Error.Show("Error in property:  public string UserName : SQLITE does not have user name!");
                        break;
                    default:
                        Error.Show("Error in set property UserName:  unvalid m_DBType");
                        break;
                }
            }
        }

        public string PasswordCrypted
        {
            get
            {
                switch (m_DBType)
                {
                    case eDBType.MYSQL:
                        return m_conData_MYSQL.m_crypted_Password;

                    case eDBType.MSSQL:
                        return m_conData_MSSQL.m_crypted_Password;

                    case eDBType.SQLITE:
                        return m_conData_MSSQL.m_crypted_Password;

                    default:
                        MessageBox.Show("Error eSQLType in property:  public string PasswordCrypted {}");
                        return "Error";
                }
            }
            set
            {
                switch (m_DBType)
                {
                    case eDBType.MYSQL:
                    m_conData_MYSQL.m_crypted_Password = value;
                    break;

                    case eDBType.MSSQL:
                    m_conData_MSSQL.m_crypted_Password = value;
                    break;
                }
            }

        }

        public string Password
        {
            get
            {
                switch (m_DBType)
                {
                    case eDBType.MYSQL:
                    return m_conData_MYSQL.m_Crypt.DecryptString(m_conData_MYSQL.m_crypted_Password);
                    case eDBType.MSSQL:
                    return m_conData_MSSQL.m_Crypt.DecryptString(m_conData_MSSQL.m_crypted_Password);
                    default:
                    MessageBox.Show("Error eSQLType in property: public string Password");
                        return "Error Password";
                }
            }
            set
            {
                switch (m_DBType)
                {
                    case eDBType.MYSQL:
                    m_conData_MYSQL.m_crypted_Password = m_conData_MYSQL.m_Crypt.EncryptString(value);
                    break;
                    case eDBType.MSSQL:
                    m_conData_MSSQL.m_crypted_Password = m_conData_MSSQL.m_Crypt.EncryptString(value); ;
                    break;
                }
            }
        }





        public string ConnectionString 
        { 
            get{
                    switch (m_DBType)
                    {
                        case eDBType.MYSQL:
                            return m_conData_MYSQL.GetConnectionString();

                        case eDBType.MSSQL:
                            return m_conData_MSSQL.GetConnectionString();

                        case eDBType.SQLITE:
                            return "Data Source=" + m_conData_SQLITE.DataBaseFile + ";Version=3;";//Password=Logina2761962SQLite";

                        default:
                            MessageBox.Show("Program Error in public string ConnectionString");
                            return "ERROE UNKNOWN";
                    }
               }
        }



        public string LogTableName
         {
             get { return m_LogTableName; }
             set { m_LogTableName = value; }

         }
        #endregion PUBLIC MEMBER FUNCTIONS
        #endregion PUBLIC




        internal void Create_m_conData_MSSQL(bool p, string p_2, string p_3, string p_4, string p_5, string p_6, string p_7)
        {
            throw new NotImplementedException();
        }


        private void SetConnectionData(Object DB_Param)
        {
            if (DB_Param.GetType() == typeof(Log_RemoteDB_data))
            {
                Log_RemoteDB_data remDB = (Log_RemoteDB_data)DB_Param;
                this.ConnectionName = remDB.ConnectionName;
                DBType = remDB.DBType;
            }
            else
            {
                if (DB_Param.GetType() == typeof(Log_LocalDB_data))
                {
                    Log_LocalDB_data localDB = (Log_LocalDB_data)DB_Param;
                    this.ConnectionName = localDB.ConnectionName;
                    DBType = eDBType.SQLITE;
                    m_conData_SQLITE.SQLite_AllwaysCreateNew = localDB.bAllwaysCreateNew;
                }
                else
                {
                    Error.Show("Error DB_Param not of type  Log_RemoteDB_data or Log_LocalDB_data !");
                    return;
                }
            }

            switch (DBType)
            {
                case eDBType.MSSQL:
                    if (m_conData_MSSQL != null)
                    {
                        if (DB_Param.GetType() == typeof(Log_RemoteDB_data))
                        {
                            Log_RemoteDB_data remoteDB_Param = (Log_RemoteDB_data)DB_Param;
                            WindowsAuthentication = remoteDB_Param.bWindowsAuthentication;
                            DataSource = remoteDB_Param.DataSource;
                            DataBase = remoteDB_Param.DataBase;
                            UserName = remoteDB_Param.UserName;
                            m_conData_MSSQL.m_crypted_Password = remoteDB_Param.crypted_Password;
                            DataBaseFilePath = remoteDB_Param.strDataBaseFilePath;
                            DataBaseLogFilePath = remoteDB_Param.strDataBaseLogFilePath;
                        }
                        else
                        {
                            Error.Show("Error not Log_LocalDB_data param in function public void SetConnectionData(Object DB_Param)!");
                        }
                    }
                    else
                    {
                        Error.Show("Error: MyDataBase not created m_conData_MSSQL ==null");
                    }
                    break;

                case eDBType.MYSQL:
                    if (m_conData_MYSQL != null)
                    {
                        if (DB_Param.GetType() == typeof(Log_RemoteDB_data))
                        {
                            Log_RemoteDB_data remoteDB_Param = (Log_RemoteDB_data)DB_Param;
                            DataSource = remoteDB_Param.DataSource;
                            DataBase = remoteDB_Param.DataBase;
                            UserName = remoteDB_Param.UserName;
                            m_conData_MYSQL.m_crypted_Password = remoteDB_Param.crypted_Password;
                        }
                        else
                        {
                            Error.Show("Error not Log_LocalDB_data param in function public void SetConnectionData(Object DB_Param)!");
                        }
                    }
                    else
                    {
                        Error.Show("Error: MyDataBase not created m_conData_MSSQL ==null");
                    }
                    break;

                case eDBType.SQLITE:
                    if (m_conData_SQLITE != null)
                    {
                        if (DB_Param.GetType() == typeof(Log_LocalDB_data))
                        {
                            Log_LocalDB_data LocalDB_Param =  (Log_LocalDB_data)DB_Param;

                            if ((LocalDB_Param.DataBaseFilePath != null) && (LocalDB_Param.DataBaseFileName != null))
                            {
                                m_conData_SQLITE.DataBaseFile = LocalDB_Param.DataBaseFilePath + LocalDB_Param.DataBaseFileName;
                            }
                            else
                            {

                                Error.Show("Error ((LocalDB_Param.DataBaseFilePath != null) && (LocalDB_Param.DataBaseFileName != null)) in function public void SetConnectionData(Object DB_Param)!");
                            }
                            
                        }
                        else
                        {
                            Error.Show("Error not Log_LocalDB_data param in function public void SetConnectionData(Object DB_Param)!");
                        }
                    }
                    else
                    {
                        Error.Show("Error: MyDataBase not created m_conData_SQLITE ==null");
                    }
                    break;
            }
        }

        public bool ExecuteNonQuerySQLReturnID(string sql, List<Log_SQL_Parameter> lSQL_Parameter, ref Int64 newID, ref object ObjRet, ref string ErrorMsg, string SQlite_table_name)
        {
            //SqlConnection Conn = new SqlConnection(xString);
            if (DynSettings.bPreviewSQLBeforeExecution)
            {
                string new_sql = "";
                bool bChanged = false;
                PreviewSQLCommand(sql, lSQL_Parameter, ref new_sql, ref bChanged, "ExecuteNonQuerySQL");
                if (bChanged)
                {
                    sql = new_sql;
                }

            }
            StringBuilder sqlTran = new StringBuilder();


            try
            {
                if (Connect(ref ErrorMsg))
                {
                    switch (m_DBType)
                    {
                        case eDBType.MYSQL:
                            {
                                sqlTran.Append("START TRANSACTION; \n");
                                sqlTran.Append(sql);
                                sqlTran.Append("\nCOMMIT; \n");
                                MySqlCommand command;
                                command = new MySqlCommand(sqlTran.ToString(), m_con_MYSQL);
                                if (lSQL_Parameter != null)
                                {
                                    foreach (Log_SQL_Parameter sqlPar in lSQL_Parameter)
                                    {
                                        if (sqlPar.size > 0)
                                        {
                                            command.Parameters.Add(sqlPar.Name, sqlPar.MySQLdbType, sqlPar.size).Value = sqlPar.Value;
                                        }
                                        else
                                        {
                                            command.Parameters.Add(new MySqlParameter(sqlPar.Name, sqlPar.Value)).Value = sqlPar.Value;
                                        }
                                    }
                                }

                                command.CommandTimeout = 200000;
                                command.ExecuteNonQuery();
                                Disconnect();
                            }
                            return true;

                        case eDBType.MSSQL:
                            {
                                sqlTran.Append("BEGIN TRAN TRANSACTION_EVLicence; \n");
                                sqlTran.Append(sql);
                                sqlTran.Append("\nCOMMIT TRAN TRANSACTION_EVLicence; \n");
                                SqlCommand command;
                                command = new SqlCommand(sqlTran.ToString(), m_con_MSSQL);
                                if (lSQL_Parameter != null)
                                {
                                    foreach (Log_SQL_Parameter sqlPar in lSQL_Parameter)
                                    {
                                        if (sqlPar.size > 0)
                                        {
                                            command.Parameters.Add(sqlPar.Name, sqlPar.dbType, sqlPar.size).Value = sqlPar.Value;
                                        }
                                        else
                                        {
                                            command.Parameters.Add(new SqlParameter(sqlPar.Name, sqlPar.Value)).Value = sqlPar.Value;
                                        }
                                    }
                                }

                                command.CommandTimeout = 200000;
                                command.ExecuteNonQuery();
                                Disconnect();
                            }
                            return true;

                        case eDBType.SQLITE:
                            {
                                sqlTran.Append("BEGIN TRANSACTION; \n");
                                sqlTran.Append(sql);
                                sqlTran.Append(";\nCOMMIT TRANSACTION; \n");
                                SQLiteCommand command;
                                command = new SQLiteCommand(sqlTran.ToString(), m_con_SQLite);
                                if (lSQL_Parameter != null)
                                {
                                    foreach (Log_SQL_Parameter sqlPar in lSQL_Parameter)
                                    {
                                        if (sqlPar.size > 0)
                                        {
                                            SQLiteParameter mySQLiteParameter = new SQLiteParameter(sqlPar.Name, sqlPar.SQLiteDbType, sqlPar.size);
                                            mySQLiteParameter.Value = sqlPar.Value;
                                            command.Parameters.Add(mySQLiteParameter);

                                        }
                                        else
                                        {
                                            SQLiteParameter mySQLiteParameter = new SQLiteParameter(sqlPar.Name, sqlPar.Value);
                                            mySQLiteParameter.Value = sqlPar.Value;
                                            command.Parameters.Add(mySQLiteParameter);
                                        }
                                    }
                                }
                                command.CommandTimeout = 200000;
                                command.ExecuteNonQuery();
                                SQLiteCommand cmd = new SQLiteCommand("SELECT last_insert_rowid() from " + SQlite_table_name, m_con_SQLite);
                                object nieuweID = cmd.ExecuteScalar();
                                newID = Convert.ToInt64(nieuweID);
                                Disconnect();
                            }
                            return true;

                        default:
                            MessageBox.Show("Error eSQLType in function: ExecuteNonQuerySQL(...)");
                            return false;
                    }
                }
                else
                {
                    //               MessageBox.Show(csError, "ERROR", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (Exception ex)
            {
                //System.Windows.Forms.MessageBox.Show("SQL ERROR:" + ex.Message);
                ErrorMsg = ex.Message;
                Disconnect();

                ShowDBErrorMessage(ex.Message, lSQL_Parameter, "ExecuteNonQuerySQL");


                try
                {
                    WriteLogTable(ex);
                    return false;
                }
                catch (Exception ee)
                {
                    Disconnect();
                    Console.WriteLine(ee.ToString());
                    return false;
                    //throw new Exception(ee.ToString(), ee);
                }
            }
        }

        public bool ReadDataTable(ref DataTable dt, string sqlGetColumnsNamesAndTypes, List<Log_SQL_Parameter> lSQL_Parameter, ref string csError)
        {

            //SqlConnection Conn = new SqlConnection("Data Source=razvoj1;Initial Catalog=NOS_BIH;Persist Security Info=True;User ID=sa;Password=sa;");
            if (DynSettings.bPreviewSQLBeforeExecution)
            {
                string new_sql = "";
                bool bChanged = false;
                PreviewSQLCommand(sqlGetColumnsNamesAndTypes,null,ref new_sql,ref bChanged, "ReadDataTable");
                if (bChanged)
                {
                    sqlGetColumnsNamesAndTypes = new_sql;
                }
            }
            try
            {
                switch (m_DBType)
                {
                    case eDBType.MYSQL:
                        {
                            MySqlDataAdapter adapter = new MySqlDataAdapter();

                            if (Connect(ref csError))
                            {
                                MySqlCommand SqlCommandcommandGetColumnsNamesAndTypes = new MySqlCommand(sqlGetColumnsNamesAndTypes, m_con_MYSQL);
                                if (lSQL_Parameter != null)
                                {
                                    foreach (Log_SQL_Parameter sqlPar in lSQL_Parameter)
                                    {
                                        if (sqlPar.size > 0)
                                        {
                                            SqlCommandcommandGetColumnsNamesAndTypes.Parameters.Add(sqlPar.Name, sqlPar.MySQLdbType, sqlPar.size).Value = sqlPar.Value;
                                        }
                                        else
                                        {
                                            SqlCommandcommandGetColumnsNamesAndTypes.Parameters.Add(new MySqlParameter(sqlPar.Name, sqlPar.Value)).Value = sqlPar.Value;
                                        }
                                    }
                                }
                                adapter.SelectCommand = SqlCommandcommandGetColumnsNamesAndTypes;
                                adapter.Fill(dt);
                                adapter.Dispose();
                                SqlCommandcommandGetColumnsNamesAndTypes.Dispose();
                                Disconnect();
                            }
                            else
                            {
                                MessageBox.Show(csError, "ERROR", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                            }
                        }
                        return true;

                    case eDBType.MSSQL:
                        {
                            SqlDataAdapter adapter = new SqlDataAdapter();

                            if (Connect(ref csError))
                            {
                                SqlCommand SqlCommandcommandGetColumnsNamesAndTypes = new SqlCommand(sqlGetColumnsNamesAndTypes, m_con_MSSQL);
                                if (lSQL_Parameter != null)
                                {
                                    foreach (Log_SQL_Parameter sqlPar in lSQL_Parameter)
                                    {
                                        if (sqlPar.size > 0)
                                        {
                                            SqlCommandcommandGetColumnsNamesAndTypes.Parameters.Add(sqlPar.Name, sqlPar.dbType, sqlPar.size).Value = sqlPar.Value;
                                        }
                                        else
                                        {
                                            SqlCommandcommandGetColumnsNamesAndTypes.Parameters.Add(new SqlParameter(sqlPar.Name, sqlPar.Value)).Value = sqlPar.Value;
                                        }
                                    }
                                }

                                adapter.SelectCommand = SqlCommandcommandGetColumnsNamesAndTypes;
                                adapter.Fill(dt);
                                adapter.Dispose();
                                SqlCommandcommandGetColumnsNamesAndTypes.Dispose();
                                Disconnect();
                            }
                            else
                            {
                                MessageBox.Show(csError, "ERROR", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                            }
                        }
                        return true;

                    case eDBType.SQLITE:
                        {
                            SQLiteDataAdapter adapter = new SQLiteDataAdapter();

                            if (Connect(ref csError))
                            {
                                SQLiteCommand SqlCommandcommandGetColumnsNamesAndTypes = new SQLiteCommand(sqlGetColumnsNamesAndTypes, m_con_SQLite);
                                if (lSQL_Parameter != null)
                                {
                                    foreach (Log_SQL_Parameter sqlPar in lSQL_Parameter)
                                    {
                                        if (sqlPar.size > 0)
                                        {
                                            SQLiteParameter mySQLiteParameter = new SQLiteParameter(sqlPar.Name, sqlPar.SQLiteDbType, sqlPar.size);
                                            mySQLiteParameter.Value = sqlPar.Value;
                                            SqlCommandcommandGetColumnsNamesAndTypes.Parameters.Add(mySQLiteParameter);

                                        }
                                        else
                                        {
                                            SQLiteParameter mySQLiteParameter = new SQLiteParameter(sqlPar.Name, sqlPar.Value);
                                            mySQLiteParameter.Value = sqlPar.Value;
                                            SqlCommandcommandGetColumnsNamesAndTypes.Parameters.Add(mySQLiteParameter);
                                        }
                                    }
                                }
                                adapter.SelectCommand = SqlCommandcommandGetColumnsNamesAndTypes;
                                adapter.Fill(dt);
                                adapter.Dispose();
                                SqlCommandcommandGetColumnsNamesAndTypes.Dispose();
                                Disconnect();
                            }
                            else
                            {
                                MessageBox.Show(csError, "ERROR", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                            }
                        }
                        return true;

                    default:
                        MessageBox.Show("Error eSQLType in function: public bool ReadDataTable( ..)");
                        return false;
                }
            }
            catch (Exception ex)
            {
                Disconnect();
                csError = "Error:DBConnectionControl:ReadDataTable:Ex.Message:\r\n" + ex.Message;
                ShowDBErrorMessage(ex.Message, null, "ExecuteNonQuerySQL");

                WriteLogTable(ex);
                return false;
            }
        }

        public bool DeleteDataBase()
        {
            string sqlDropDBQuery;
            // DBParam.DatabaseName

            //sqlCreateDBQuery =	  " CREATE DATABASE " + DBParam.DatabaseName + " ON PRIMARY "
            //                    + " (NAME = " + DBParam.DataFileName +", " 
            //                    + " FILENAME = '" + DBParam.DataPathName +"', "
            //                    + " SIZE = 2MB,"
            //                    + "	FILEGROWTH =" + DBParam.DataFileGrowth  +") "
            //                    + " LOG ON (NAME =" + DBParam.LogFileName +", "
            //                    + " FILENAME = '" + DBParam.LogPathName + "', "
            //                    + " SIZE = 1MB, "								
            //                    + "	FILEGROWTH =" + DBParam.LogFileGrowth  +") ";	

            sqlDropDBQuery = @"USE Master; 
                             ALTER DATABASE " + this.DataBase + @" SET SINGLE_USER WITH ROLLBACK IMMEDIATE; 
                             DROP DATABASE " + this.DataBase + @";
                             ";

            string csError = null;

            string sLastQuestion = lngConn.s_AreYouSureToDeleteDataBase.s + " " +this.DataBase + " on server:" +this.DataSource+ "?";

            if (MessageBox.Show(sLastQuestion, lngConn.s_Question.s, MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                if (this.ExecuteNonQuerySQL_NoMultiTrans(sqlDropDBQuery, null, ref csError))
                {
                    // Data Base Created OK
                    string msg = "Database \"" + DataBase + "\" deleted OK on server:" + this.DataSource;
                    MessageBox.Show(msg, "OK", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return true;
                }
                else
                {
                    string msg = "ERROR! Database \"" + this.DataBase + "\" not deleted on server:" + this.DataSource + "\n ERROR=" + csError;
                    MessageBox.Show(msg, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

