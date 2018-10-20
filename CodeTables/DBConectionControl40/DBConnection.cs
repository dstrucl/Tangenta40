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

 
namespace DBConnectionControl40
{
    [ToolboxItem(true)]
    //[ToolboxBitmapAttribute(typeof(SQLServerConnection), "SQLServerConnection2.bmp")]
    //[ToolboxBitmap(@"E:\ManualReader\ctLogina\SearchLocalNetworkControl\Resources\SearchLocalNetwork.bmp")]
    //[ToolboxBitmap(@"E:\ManualReader\ctLogina\DBConnection\Resources\DBConnection.SQLServerConnection.bmp")]
    //[ToolboxBitmap(typeof(DBConnection.SQLServerConnection), "DBConnection.SQLServerConnection.bmp")]
    //[ToolboxBitmap(typeof(DBConnection.SQLServerConnection), "Resources\\DBConnection.SQLServerConnection.bmp")]
    //F:\\RFID\\DBProjects\\DBConnection
    [ToolboxBitmap("E:\\ManualReader\\ctlogina\\DBConectionControl4\\Resources\\DBConnection.ico")]
    public partial class DBConnection : Component
    {
        public const string BACKUPTEMP = "backuptemp";
        public string m_inifile_prefix = null;

        private bool m_bOpened = false;
        private bool m_bBatchOpen = false;
        private bool m_bSessionConnected = false;



        private SqlConnection m_con_MSSQL = null;
        private SqlTransaction MSSQLTran = null;

        private MySqlConnection m_con_MYSQL = null;
        private MySqlTransaction MYSQLTran = null;

        private SQLiteConnection m_con_SQLite = null;
        private SQLiteTransaction SQLiteTran = null;


        public enum eStartPositionOfTestConnectionForm { CENTER_SCREEN, TOP_LEFT_CORNER, TOP_RIGHT_CORNER, BOTTOM_LEFT_CORNER, BOTTOM_RIGHT_CORNER }

        private eStartPositionOfTestConnectionForm m_eStartPositionOfTestConnectionForm = eStartPositionOfTestConnectionForm.CENTER_SCREEN;

        public eStartPositionOfTestConnectionForm StartPositionOfTestConnectionForm
        {
            get {return m_eStartPositionOfTestConnectionForm;}
            set { m_eStartPositionOfTestConnectionForm = value; }
        }

        #region PUBLIC CONSTRUCTORS

        public object DB_Param = null; // this object can be of type RemoteDB_data or  LocalDB_data
        
        public DBConnectionControl_Settings.Settings_LocalDB.eType Settings_LocalDB_eType
        {
            get
            {
                if (DB_Param != null)
                {
                    if (DBType != eDBType.SQLITE)
                    {
                        LocalDB_data rdbdata = (LocalDB_data)DB_Param;
                        return rdbdata.m_Settings_LocalDB.m_eType;
                    }
                    else
                    {
                        return DBConnectionControl_Settings.Settings_LocalDB.eType.IniFile_Setting;
                    }
                }
                else
                {
                    return DBConnectionControl_Settings.Settings_LocalDB.eType.IniFile_Setting;
                }
            }

            set
            {
                if (DB_Param != null)
                {
                    if (DBType != eDBType.SQLITE)
                    {
                        LocalDB_data rdbdata = (LocalDB_data)DB_Param;
                        rdbdata.m_Settings_LocalDB.m_eType = value;
                    }
                }
            }
        }


        public DBConnectionControl_Settings.Settings_RemoteDB.eType Settings_RemoteDB_eType
        {
            get
            {
                if (DB_Param != null)
                {
                    if (DBType != eDBType.SQLITE)
                    {
                        RemoteDB_data rdbdata = (RemoteDB_data)DB_Param;
                        return rdbdata.m_Settings_RemoteDB.m_eType;
                    }
                    else
                    {
                        return DBConnectionControl_Settings.Settings_RemoteDB.eType.IniFile_Setting;
                    }
                }
                else
                {
                    return DBConnectionControl_Settings.Settings_RemoteDB.eType.IniFile_Setting;
                }
            }

            set
            {
                if (DB_Param != null)
                {
                    if (DBType != eDBType.SQLITE)
                    {
                        RemoteDB_data rdbdata = (RemoteDB_data)DB_Param;
                        rdbdata.m_Settings_RemoteDB.m_eType = value;
                    }
                }
            }
        }

        public DBConnection()
        {
            m_con_SQLite = new SQLiteConnection();
            m_con_MYSQL = new MySqlConnection();
            m_con_MSSQL = new SqlConnection();
            InitializeComponent();
        }

        public DBConnection(string rfolder)
        {
            m_con_SQLite = new SQLiteConnection();
            m_con_MYSQL = new MySqlConnection();
            m_con_MSSQL = new SqlConnection();
            InitializeComponent();
            m_RecentItemsFolder = rfolder;

        }

        public DBConnection(IContainer container)
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
                LogFile.Error.Show("Exception = " + ex.Message + "\r\nInner Exception = " + inner_ex); 
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
        private string m_BackupFolder = "";



        #endregion

        #region PUBLIC

        #region PUBLIC ENUMS

        public enum  eDBType:int  { MSSQL, MYSQL, SQLITE };
        public enum ConnectResult_ENUM { OK, OK_SAVE, CANCELED,CONNECTION_DIALOGE_SHOWED,SHOW_CONNECTION_DIALOG_AGAIN };

        #endregion PUBLIC ENUMS

        #region PUBLIC PROPERTIES

        public bool SessionConnected
        {
            get { return m_bSessionConnected; }
        }

        public bool BatchOpen
        {
            get { return m_bBatchOpen; }
            set { m_bBatchOpen = value; }
        }

        public bool SessionConnect(ref string sError)
        {
            if (BatchOpen)
            {
                m_bSessionConnected = true;
                return true;
            }
            else
            {
                if (m_bBatchOpen)
                {
                    if (m_bOpened)
                    {
                        m_bSessionConnected = true;
                        return true;
                    }
                }

                if (Connect(ref sError))
                {
                    m_bBatchOpen = true;
                    m_bSessionConnected = true;
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool SessionDisconnect()
        {
            if (BatchOpen)
            {
                if (Disconnect())
                {
                    m_bBatchOpen = false;
                    m_bSessionConnected = false;
                    return true;
                }
                else
                {
                    m_bSessionConnected = false;
                    return false;
                }
            }
            else
            {
                if (!m_bBatchOpen)
                {
                    if (!m_bOpened)
                    {
                        m_bSessionConnected = false;
                        return true;
                    }
                    else
                    {
                        if (Disconnect())
                        {
                            m_bBatchOpen = false;
                            m_bSessionConnected = false;
                            return true;
                        }
                        else
                        {
                            m_bSessionConnected = false;
                            return false;
                        }
                    }
                }
                else
                {
                    m_bSessionConnected = false;
                    return true;
                }
            }
        }

        public enum eSQLITEFileExist { OK,NOT_EXISTS,CONNECTION_FILE_NOT_DEFINED};

        internal eSQLITEFileExist SQLITEFileExist(ref string sqlitefile)
        {
            if (m_conData_SQLITE != null)
            {
                sqlitefile = m_conData_SQLITE.DataBaseFile;
                if (File.Exists(sqlitefile))
                {
                    return eSQLITEFileExist.OK;
                }
                else
                {
                    return eSQLITEFileExist.NOT_EXISTS;
                }
            }
            else
            {
                return eSQLITEFileExist.CONNECTION_FILE_NOT_DEFINED;
            }
        }

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

        public string BackupFolder
        {
            get { return m_BackupFolder; }
            set { m_BackupFolder = value; }
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
                                    MessageBox.Show("Error setting property WindowsAuthentication in module DBConnection. MYSQL server does not support Windows Authentication");
                                    break;

                                case eDBType.SQLITE:
                                    MessageBox.Show("Error setting property WindowsAuthentication in module DBConnection. SQLite database does not support Windows Authentication");
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

        public string DataBaseName
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
                        int i = m_conData_SQLITE.DataBaseFile.LastIndexOf('\\');
                        if (i > 0)
                        {
                            return m_conData_SQLITE.DataBaseFile.Substring(i+1);
                        }
                        else
                        {
                            return m_conData_SQLITE.DataBaseFile;
                        }

                }
                return null;
            }
            set
            {
                switch (m_DBType)
                {
                    case eDBType.MSSQL:
                        MessageBox.Show("Error setting property DataBaseFile in module DBConnection. MSSQL server does not support DataBaseFile definition");
                        break;

                    case eDBType.MYSQL:
                        MessageBox.Show("Error setting property DataBaseFilePath in module DBConnection. MYSQL server does not support DataBaseFilePath definition");
                        break;

                    case eDBType.SQLITE:
                        m_conData_SQLITE.DataBaseFile = value;
                        break;

                }
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
                        MessageBox.Show("Error setting property DataBaseFile in module DBConnection. MSSQL server does not support DataBaseFile definition");
                        break;

                    case eDBType.MYSQL:
                        MessageBox.Show("Error setting property DataBaseFilePath in module DBConnection. MYSQL server does not support DataBaseFilePath definition");
                        break;

                    case eDBType.SQLITE:
                        m_conData_SQLITE.DataBaseFile = value;
                        break;

                }
            }
        }

        public DateTime SQLiteDataBaseFileCreationTime
        {
            get
            {
                switch (m_DBType)
                {
                    case eDBType.MSSQL:
                        LogFile.LogFile.Write(LogFile.LogFile.LOG_LEVEL_RUN_RELEASE, "Error: SQLiteDataBaseFileCreationTime is not supported for eDBType.MSSQL!");
                        return DateTime.MinValue;

                    case eDBType.MYSQL:
                        LogFile.LogFile.Write(LogFile.LogFile.LOG_LEVEL_RUN_RELEASE, "Error: SQLiteDataBaseFileCreationTime is not supported for eDBType.MYSQL!");
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
                        LogFile.LogFile.Write(LogFile.LogFile.LOG_LEVEL_RUN_RELEASE, "Error: Property:DataBaseFilePath is not supported for eDBType.MYSQL!");
                        return null; 

                    case eDBType.SQLITE:
                        return m_conData_SQLITE.DataBaseFilePath;

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
                        MessageBox.Show("Error setting property DataBaseFilePath in module DBConnection. MYSQL server does not support DataBaseFilePath definition");
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
                        MessageBox.Show("Error setting property DataBaseLogFilePath in module DBConnection. MYSQL server does not support DataBaseLogFilePath definition");
                        break;

                    case eDBType.SQLITE:
                        MessageBox.Show("Error setting property DataBaseLogFilePath in module DBConnection. SQLite does not support DataBaseLogFilePath definition");
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
                if ((tables != null) && (columns != null))
                {
                    return true;
                }
                else
                {
                    string serverversion = null;
                    System.Data.SQLite.SQLiteFactory factory = System.Data.SQLite.SQLiteFactory.Instance;
                    DbConnection connection = factory.CreateConnection();
                    connection.ConnectionString = ConnectionString;
                    connection.Open();
                    serverversion = connection.ServerVersion;
                    if (tables == null)
                    {
                        tables = connection.GetSchema("Tables");
                    }
                    if (columns == null)
                    {
                        columns = connection.GetSchema("Columns");
                    }
                    connection.Close();
                    return true;
                }
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

        public bool Startup_03_Show_TestConnectionForm(Form pParentForm,NavigationButtons.Navigation xnav)
        {
            //xnav.ShowForm(new TestConnectionForm(pParentForm, this, true, true, lng.s_TestConnection.s),typeof(TestConnectionForm).ToString());
            TestConnectionForm tconform = new TestConnectionForm(pParentForm, this, true, true, lng.s_TestConnection.s);
            xnav.ShowForm(tconform, null);
            return true;
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
                        if (pParentForm != null)
                        {
                            tConForm.TopMost = pParentForm.TopMost;
                        }
                        if (tConForm.ShowDialog(pParentForm) == DialogResult.OK)
                        {
                            tConForm.Dispose();
                            string Err = null;
                            if (SessionConnect(ref Err))
                            {
                                return true;
                            }
                            else
                            {

                                LogFile.Error.Show("ERROR:DBConnectionControl40:DBConnection:CheckDataBaseConnection:SessionConnect failed Err=" + Err);
                                tConForm.Dispose();
                                return false;
                            }
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
                    if (pParentForm != null)
                    {
                        tConForm.TopMost = pParentForm.TopMost;
                    }
                    if (tConForm.ShowDialog(pParentForm) == DialogResult.OK)
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
                    LogFile.Error.Show("ERROR:DBConnectionControl40:RenameFile_ToDateTimeVersion:Cannot find unique file name!");
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
                LogFile.Error.Show("ERROR:DBConnectionControl40:RenameFile_ToDateTimeVersion:Ex=" + Ex.Message);
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
            return CheckDataBaseConnection(null, lng.s_TestConnection.s);
        }

        public bool CreateNewDataBaseConnection(Object DB_Param, NavigationButtons.Navigation xnav, ref bool bCanceled)
        {
            string myConnectionName = null;
            if (DB_Param is RemoteDB_data)
            {
                myConnectionName = ((RemoteDB_data)DB_Param).ConnectionName;
            }
            else if (DB_Param is LocalDB_data)
            {
                myConnectionName = ((LocalDB_data)DB_Param).ConnectionName;
            }


            SetConnectionData(DB_Param);
            bool bxNewDatabase = false;
            while (true)
            {
                DBConnection.ConnectResult_ENUM dRes;
                string sConnectionToDBase = null;
                if (DB_Param.GetType() == typeof(RemoteDB_data))
                {
                    RemoteDB_data xRemoteDB_data = (RemoteDB_data)DB_Param;
                    sConnectionToDBase = xRemoteDB_data.ConnectionName;
                }
                else if (DB_Param.GetType() == typeof(LocalDB_data))
                {
                    LocalDB_data xLocalDB_data =(LocalDB_data)DB_Param;
                    sConnectionToDBase = xLocalDB_data.ConnectionName;
                }
                else
                {
                    MessageBox.Show("ERROR:DBConnection:CreateNewDataBaseConnection Object DB_Param not valid !");
                    return false;
                }
                dRes = do_ConnectionDialog(sConnectionToDBase, ref bxNewDatabase, xnav, ref bCanceled, myConnectionName);
                switch (dRes)
                {
                    case DBConnection.ConnectResult_ENUM.OK_SAVE:
                    case DBConnection.ConnectResult_ENUM.OK:
                        switch (DBType)
                        {
                            case DBConnection.eDBType.MSSQL:
                                {
                                    RemoteDB_data remote_DB_Param = (RemoteDB_data)DB_Param;
                                    if (remote_DB_Param.DBType != DBConnection.eDBType.MSSQL)
                                    {
                                        remote_DB_Param.DBType = DBConnection.eDBType.MSSQL;
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

                            case DBConnection.eDBType.MYSQL:
                                {
                                    RemoteDB_data remote_DB_Param = (RemoteDB_data)DB_Param;
                                    if (remote_DB_Param.DBType != DBConnection.eDBType.MYSQL)
                                    {
                                        remote_DB_Param.DBType = DBConnection.eDBType.MYSQL;
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

                            case DBConnection.eDBType.SQLITE:
                                LocalDB_data local_DB_Param = (LocalDB_data)DB_Param;
                                local_DB_Param.bChanged = true;
                                local_DB_Param.bNewDatabase = bxNewDatabase;
                                local_DB_Param.DataBaseFileName = m_conData_SQLITE.DataBaseFileName;
                                local_DB_Param.DataBaseFilePath = m_conData_SQLITE.DataBaseFilePath;
                                break;
                        }
                       // DB_Param = DB_Param;
                        return true;

                    case DBConnection.ConnectResult_ENUM.CANCELED:
                        return false;
                }
            }
        }

        public bool SetNewConnection(Form pParentForm, object xDB_Param, NavigationButtons.Navigation nav, ref bool bCanceled)
        {
            bool bxNewDatabase = false;
            string myConnectionName = null;
            if (xDB_Param is RemoteDB_data)
            {
                myConnectionName = ((RemoteDB_data)xDB_Param).ConnectionName;
            }
            else if (xDB_Param is LocalDB_data)
            {
                myConnectionName = ((LocalDB_data)xDB_Param).ConnectionName;
            }
            while (true)
            {
                DBConnection.ConnectResult_ENUM dRes;
                nav.eExitResult = NavigationButtons.Navigation.eEvent.NOTHING;
                dRes = do_ConnectionDialog(this.ConnectionName, ref bxNewDatabase, nav, ref bCanceled,myConnectionName);
                switch (dRes)
                {
                    case DBConnection.ConnectResult_ENUM.CONNECTION_DIALOGE_SHOWED:
                        return true;

                    case DBConnection.ConnectResult_ENUM.OK_SAVE:
                    case DBConnection.ConnectResult_ENUM.OK:
                        switch (DBType)
                        {
                            case DBConnection.eDBType.MSSQL:
                                {
                                    RemoteDB_data remote_DB_Param = (RemoteDB_data)xDB_Param;
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

                            case DBConnection.eDBType.MYSQL:
                                {
                                    RemoteDB_data remote_DB_Param = (RemoteDB_data)xDB_Param;
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

                            case DBConnection.eDBType.SQLITE:
                                LocalDB_data local_DB_Param = (LocalDB_data)xDB_Param;
                                local_DB_Param.bChanged = true;
                                local_DB_Param.bNewDatabase = bxNewDatabase;
                                local_DB_Param.DataBaseFileName = m_conData_SQLITE.DataBaseFileName;
                                local_DB_Param.DataBaseFilePath = m_conData_SQLITE.DataBaseFilePath;
                                break;
                        }

                        DB_Param = xDB_Param;
                        return true;

                    case DBConnection.ConnectResult_ENUM.CANCELED:
                        bCanceled = true;
                        return false;
                }
            }

        }

        public bool MakeDataBaseConnection(Form pParentForm, Object xDB_Param,NavigationButtons.Navigation nav, ref bool bCanceled)
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
            if (CheckDataBaseConnection(pParentForm, lng.s_TestConnection.s))
            {
                DB_Param = xDB_Param;
                return true;
            }
            else
            {
                if (SetNewConnection(pParentForm, xDB_Param, nav, ref bCanceled))
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


        public bool Evaluate_MakeDataBaseConnection(Form pParentForm, Object xDB_Param, NavigationButtons.Navigation nav, ref bool bCanceled)
        {
            //SetConnectionData(xDB_Param);
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
            if (CheckDataBaseConnection(pParentForm, lng.s_TestConnection.s))
            {
                DB_Param = xDB_Param;
                return true;
            }
            else
            {
                return false;
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
                LogFile.LogFile.Write(LogFile.LogFile.LOG_LEVEL_RUN_RELEASE,"Error:CheckConnectionToServerOnly: Exception = "+ex.Message);
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

        

        public bool Connect_Batch(ref string sError)
        {
            if (m_bBatchOpen)
            {
                if (m_bOpened)
                {
                    return true;
                }
            }
            return Connect(ref sError);
        }

        public bool Disconnect_Batch()
        {
            if (m_bBatchOpen)
            {
                return true;
            }
            else
            {
                return Disconnect();
            }
        }


        public bool BeginTransaction(ref string sError)
        {
            //ProgramDiagnostic.Diagnostic.Meassure("Connect START", null);
            try
            {
                //SetConnectionString();
                switch (m_DBType)
                {
                    case eDBType.MYSQL:
                        if (m_con_MYSQL.State == ConnectionState.Open)
                        {
                            MYSQLTran= m_con_MYSQL.BeginTransaction();
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    case eDBType.MSSQL:
                        if (m_con_MSSQL.State == ConnectionState.Open)
                        {
                            MSSQLTran = m_con_MSSQL.BeginTransaction();
                            return true;
                        }
                        else
                        {
                            return false;
                        }


                    case eDBType.SQLITE:
                        if (m_con_SQLite.State == ConnectionState.Open)
                        {
                            SQLiteTran = m_con_SQLite.BeginTransaction();
                            return true;
                        }
                        else
                        {
                            return false;
                        }

                    default:
                        //ProgramDiagnostic.Diagnostic.Meassure("Connect END with ERROR", null);
                        MessageBox.Show("Error unknown eSQLType in function: public bool BeginTransaction(ref string sError)");
                        return false;
                }
            }
            catch (Exception ex)
            {
                sError = SetBeginTransactionError() + "\n" + ex.Message;
                if (dbg.bON) dbg.Print(sError);
                Log.Write(1, sError);
                //ProgramDiagnostic.Diagnostic.Meassure("Connect END with ERROR", null);
                return false;
            }
        }

        private string SetBeginTransactionError()
        {
            switch (m_DBType)
            {
                case eDBType.MYSQL:
                    return "ERROR BeginTransaction failed for MySQL Server Authetnication:\"" + m_conData_MYSQL.m_DataSource + "\" DataBase:\"" + m_conData_MYSQL.m_DataBase + "\" UserName:\"" + m_conData_MYSQL.m_UserName + "\" and Password:*******\n";

                case eDBType.MSSQL:
                    if (m_conData_MSSQL.m_bWindowsAuthentication)
                    {
                        return "ERROR BeginTransaction failed for SQL WINDOWS Authetnication:\"" + m_conData_MSSQL.m_DataSource + "\" DataBase:\"" + m_conData_MSSQL.m_DataBase + "\" UserName:\"" + m_conData_MSSQL.m_WindowsAuthentication_UserName + "\"\n";
                    }
                    else
                    {
                        return "ERROR BeginTransaction failed for SQL Server Authetnication:\"" + m_conData_MSSQL.m_DataSource + "\" DataBase:\"" + m_conData_MSSQL.m_DataBase + "\" UserName:\"" + m_conData_MSSQL.m_UserName + "\" and Password:*******\n";
                    }

                case eDBType.SQLITE:
                    return "ERROR BeginTransaction failed for SQLite DataBaseFile:\"" + this.SQLiteDataBaseFile + "\"\n";

                default:
                    MessageBox.Show("ERROR eSQLType in function:private string SetBeginTransactionError()");
                    return "ERROR eSQLType in function:        private string SetBeginTransactionError()";

            }
        }

        public bool CommitTransaction(ref string sError)
        {
            //ProgramDiagnostic.Diagnostic.Meassure("Connect START", null);
            try
            {
                //SetConnectionString();
                switch (m_DBType)
                {
                    case eDBType.MYSQL:
                        if (MYSQLTran != null)
                        {
                            MYSQLTran.Commit();
                            MYSQLTran = null;
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    case eDBType.MSSQL:
                        if (MSSQLTran!=null)
                        {
                            MSSQLTran.Commit();
                            MSSQLTran = null;
                            return true;
                        }
                        else
                        {
                            return false;
                        }


                    case eDBType.SQLITE:
                        if (SQLiteTran!=null)
                        {
                            SQLiteTran.Commit();
                            SQLiteTran = null;
                            return true;
                        }
                        else
                        {
                            return false;
                        }

                    default:
                        //ProgramDiagnostic.Diagnostic.Meassure("Connect END with ERROR", null);
                        MessageBox.Show("Error unknown eSQLType in function: public bool CommitTransaction(ref string sError)");
                        return false;
                }
            }
            catch (Exception ex)
            {
                sError = SetCommitTransactionError() + "\n" + ex.Message;
                if (dbg.bON) dbg.Print(sError);
                Log.Write(1, sError);
                //ProgramDiagnostic.Diagnostic.Meassure("Connect END with ERROR", null);
                return false;
            }
        }

        private string SetCommitTransactionError()
        {
            switch (m_DBType)
            {
                case eDBType.MYSQL:
                    return "ERROR CommitTransaction failed for MySQL Server Authetnication:\"" + m_conData_MYSQL.m_DataSource + "\" DataBase:\"" + m_conData_MYSQL.m_DataBase + "\" UserName:\"" + m_conData_MYSQL.m_UserName + "\" and Password:*******\n";

                case eDBType.MSSQL:
                    if (m_conData_MSSQL.m_bWindowsAuthentication)
                    {
                        return "ERROR CommitTransaction failed for SQL WINDOWS Authetnication:\"" + m_conData_MSSQL.m_DataSource + "\" DataBase:\"" + m_conData_MSSQL.m_DataBase + "\" UserName:\"" + m_conData_MSSQL.m_WindowsAuthentication_UserName + "\"\n";
                    }
                    else
                    {
                        return "ERROR CommitTransaction failed for SQL Server Authetnication:\"" + m_conData_MSSQL.m_DataSource + "\" DataBase:\"" + m_conData_MSSQL.m_DataBase + "\" UserName:\"" + m_conData_MSSQL.m_UserName + "\" and Password:*******\n";
                    }

                case eDBType.SQLITE:
                    return "ERROR CommitTransaction failed for SQLite DataBaseFile:\"" + this.SQLiteDataBaseFile + "\"\n";

                default:
                    MessageBox.Show("ERROR eSQLType in function:private string CommitTransaction()");
                    return "ERROR eSQLType in function:        private string CommitTransaction()";

            }
        }


        public bool RollbackTransaction(ref string sError)
        {
            //ProgramDiagnostic.Diagnostic.Meassure("Connect START", null);
            try
            {
                //SetConnectionString();
                switch (m_DBType)
                {
                    case eDBType.MYSQL:
                        if (MYSQLTran != null)
                        {
                            MYSQLTran.Rollback();
                            MYSQLTran = null;
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    case eDBType.MSSQL:
                        if (MSSQLTran != null)
                        {
                            MSSQLTran.Rollback();
                            MSSQLTran = null;
                            return true;
                        }
                        else
                        {
                            return false;
                        }


                    case eDBType.SQLITE:
                        if (SQLiteTran != null)
                        {
                            SQLiteTran.Rollback();
                            SQLiteTran = null;
                            return true;
                        }
                        else
                        {
                            return false;
                        }

                    default:
                        //ProgramDiagnostic.Diagnostic.Meassure("Connect END with ERROR", null);
                        MessageBox.Show("Error unknown eSQLType in function: public bool RollbackTransaction(ref string sError)");
                        return false;
                }
            }
            catch (Exception ex)
            {
                sError = SetRollbackTransactionError() + "\n" + ex.Message;
                if (dbg.bON) dbg.Print(sError);
                Log.Write(1, sError);
                //ProgramDiagnostic.Diagnostic.Meassure("Connect END with ERROR", null);
                return false;
            }
        }

        private string SetRollbackTransactionError()
        {
            switch (m_DBType)
            {
                case eDBType.MYSQL:
                    return "ERROR RollbackTransaction failed for MySQL Server Authetnication:\"" + m_conData_MYSQL.m_DataSource + "\" DataBase:\"" + m_conData_MYSQL.m_DataBase + "\" UserName:\"" + m_conData_MYSQL.m_UserName + "\" and Password:*******\n";

                case eDBType.MSSQL:
                    if (m_conData_MSSQL.m_bWindowsAuthentication)
                    {
                        return "ERROR RollbackTransaction failed for SQL WINDOWS Authetnication:\"" + m_conData_MSSQL.m_DataSource + "\" DataBase:\"" + m_conData_MSSQL.m_DataBase + "\" UserName:\"" + m_conData_MSSQL.m_WindowsAuthentication_UserName + "\"\n";
                    }
                    else
                    {
                        return "ERROR RollbackTransaction failed for SQL Server Authetnication:\"" + m_conData_MSSQL.m_DataSource + "\" DataBase:\"" + m_conData_MSSQL.m_DataBase + "\" UserName:\"" + m_conData_MSSQL.m_UserName + "\" and Password:*******\n";
                    }

                case eDBType.SQLITE:
                    return "ERROR RollbackTransaction failed for SQLite DataBaseFile:\"" + this.SQLiteDataBaseFile + "\"\n";

                default:
                    MessageBox.Show("ERROR eSQLType in function:private string RollbackTransaction()");
                    return "ERROR eSQLType in function:        private string RollbackTransaction()";

            }
        }

        public bool Connect(ref string sError)
        {
            ProgramDiagnostic.Diagnostic.Meassure("Connect START",null);
            try
            {
                SetConnectionString();
                switch (m_DBType)
                {
                    case eDBType.MYSQL:
                        m_con_MYSQL.Open();
                        m_bOpened = true;
                        ProgramDiagnostic.Diagnostic.Meassure("Connect END",null);
                        return true;
                    case eDBType.MSSQL:
                        m_con_MSSQL.Open();
                        m_bOpened = true;
                        ProgramDiagnostic.Diagnostic.Meassure("Connect END", null);
                        return true;

                    case eDBType.SQLITE:
                        m_con_SQLite.Open();
                        m_bOpened = true;
                        ProgramDiagnostic.Diagnostic.Meassure("Connect END", null);
                        return true;

                    default:
                        ProgramDiagnostic.Diagnostic.Meassure("Connect END with ERROR", null);
                        MessageBox.Show("Error unknown eSQLType in function: public bool Connect(ref string sError)");
                        return false;
                }
            }
            catch (Exception ex)
            {
                sError = SetConnectionError() +"\n" + ex.Message;
                if (dbg.bON) dbg.Print(sError);
                Log.Write(1, sError);
                ProgramDiagnostic.Diagnostic.Meassure("Connect END with ERROR", null);
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
            ProgramDiagnostic.Diagnostic.Meassure("Disconnect START",null);
            try
            {
                switch (m_DBType)
                {
                    case eDBType.MYSQL:
                        m_con_MYSQL.Close();
                        m_bOpened = false;
                        ProgramDiagnostic.Diagnostic.Meassure("Disconnect END", null);
                        return true;

                    case eDBType.MSSQL:
                        m_con_MSSQL.Close();
                        m_bOpened = false;
                        ProgramDiagnostic.Diagnostic.Meassure("Disconnect END", null);
                        return true;

                    case eDBType.SQLITE:
                        m_con_SQLite.Close();
                        m_bOpened = false;
                        ProgramDiagnostic.Diagnostic.Meassure("Disconnect END", null);
                        return true;

                    default:
                        ProgramDiagnostic.Diagnostic.Meassure("Disconnect END Error", null);
                        MessageBox.Show("Error unknown eSQLType in function:  public bool Disconnect().");
                        return false;
                }
            }
            catch (Exception ex)
            {
                ProgramDiagnostic.Diagnostic.Meassure("Disconnect END ERROR", null);
                MessageBox.Show("Error can not disconnect from:" + ConnectionString + "\n\n Exception = " + ex.Message, "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public bool Startup_03_Show_ConnectionDialog(NavigationButtons.Navigation nav)
        {
            string sTitle = lng.s_Connection_to_Database.s + this.DataBase;
            switch (m_DBType)
            {
                //case eDBType.MYSQL:
                //    if ((m_conData_MYSQL.m_DataSource.Length > 0) && (m_conData_MYSQL.m_DataBase.Length > 0))
                //    {
                //        ConnectionDialog = new ConnectionDialog(ConnectionDialog.ConnectionDialog_enum.EditLoginAndPassword, this, sTitle, nav);
                //    }
                //    else
                //    {
                //        ConnectionDialog = new ConnectionDialog(ConnectionDialog.ConnectionDialog_enum.EditAll, this, sTitle, nav);
                //    }
                //    break;

                case eDBType.MSSQL:
                    if ((m_conData_MSSQL.m_DataSource.Length > 0) && (m_conData_MSSQL.m_DataBase.Length > 0))
                    {
                        ConnectionDialog = new ConnectionDialog(ConnectionDialog.ConnectionDialog_enum.EditLoginAndPassword, this, sTitle, nav);
                    }
                    else
                    {
                        ConnectionDialog = new ConnectionDialog(ConnectionDialog.ConnectionDialog_enum.EditAll, this, sTitle, nav);
                    }
                    nav.ShowForm(ConnectionDialog, ConnectionDialog.GetType().ToString());
                    return true;

                case eDBType.SQLITE:

                    SQLiteConnectionDialog = new SQLiteConnectionDialog(m_conData_SQLITE, this.RecentItemsFolder, this.BackupFolder, nav, this.ConnectionName);
                    nav.ShowForm(SQLiteConnectionDialog, SQLiteConnectionDialog.GetType().ToString());
                    return true;


                default:
                    MessageBox.Show("Error unknown eSQLType in function:  public ConnectResult_ENUM do_ConnectionDialog(string sTitle).");
                    return false;
            }
        }

        public ConnectResult_ENUM do_ConnectionDialog(string sTitle, ref bool bNewDatabase, NavigationButtons.Navigation nav, ref bool bCanceled, string myConnectionName)
        {
                bNewDatabase = false;
                switch (m_DBType)
                {
                    case eDBType.MYSQL:
                        if ((m_conData_MYSQL.m_DataSource.Length > 0) && (m_conData_MYSQL.m_DataBase.Length > 0))
                        {
                            ConnectionDialog = new ConnectionDialog(ConnectionDialog.ConnectionDialog_enum.EditLoginAndPassword, this, sTitle, nav);
                        }
                        else
                        {
                            ConnectionDialog = new ConnectionDialog(ConnectionDialog.ConnectionDialog_enum.EditAll, this, sTitle, nav);
                        }
                        break;

                    case eDBType.MSSQL:
                        if ((m_conData_MSSQL.m_DataSource.Length > 0) && (m_conData_MSSQL.m_DataBase.Length > 0))
                        {
                            ConnectionDialog = new ConnectionDialog(ConnectionDialog.ConnectionDialog_enum.EditLoginAndPassword, this, sTitle, nav);
                        }
                        else
                        {
                            ConnectionDialog = new ConnectionDialog(ConnectionDialog.ConnectionDialog_enum.EditAll, this, sTitle, nav);
                        }
                        break;

                    case eDBType.SQLITE:

                        SQLiteConnectionDialog = new SQLiteConnectionDialog(m_conData_SQLITE,this.RecentItemsFolder, this.BackupFolder, nav, myConnectionName);
                        break;


                    default:
                        MessageBox.Show("Error unknown eSQLType in function:  public ConnectResult_ENUM do_ConnectionDialog(string sTitle).");
                        break;
                }

            while (true)
            {

                if (m_DBType == eDBType.SQLITE)
                {
                    if (nav.bDoModal)
                    {
                        SQLiteConnectionDialog.ShowDialog(nav.parentForm);
                        this.BackupFolder = SQLiteConnectionDialog.BackupFolder;
                    }
                    else
                    {
                        nav.ShowForm(SQLiteConnectionDialog, SQLiteConnectionDialog.GetType().ToString());
                    }
                }
                else 
                {
                    nav.ShowForm(ConnectionDialog, ConnectionDialog.GetType().ToString());
                }

                if (nav.bDoModal)
                {
                    ConnectResult_ENUM eRes = EvaluateConnectionDialogResult(sTitle,nav,ref bNewDatabase, ref bCanceled);
                    switch (eRes)
                    {
                        case ConnectResult_ENUM.CANCELED:
                        case ConnectResult_ENUM.OK:
                        case ConnectResult_ENUM.OK_SAVE:
                            return eRes;
                        default:
                            continue;
                    }
                }
                else
                {
                    return ConnectResult_ENUM.CONNECTION_DIALOGE_SHOWED;
                }
            }
        }

        public bool Startup_03_CreateNewDataBaseConnection(Form pParentForm,ref bool bNewDatabase,ref bool bCancel)
        {
            bNewDatabase = false;
            bCancel = false;
            if (MessageBox.Show(pParentForm, lng.s_CreateNewDatabase.s, lng.s_CreateNewDatabase.s, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.OK)
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

                            if (Connect_ToServerOnly(ref sErr))
                            {
                                if (m_DBType == eDBType.SQLITE)
                                {
                                    try
                                    {
                                        SQLiteCommand cmd = m_con_SQLite.CreateCommand();
                                        cmd.CommandText = "PRAGMA foreign_keys = ON;";
                                        cmd.ExecuteNonQuery();
                                    }
                                    catch (Exception ex)
                                    {
                                        LogFile.Error.Show("ERROR:SQLite:PRAGMA foreign_keys = ON;! " + ex.Message);
                                        return false;
                                    }
                                }
                                Disconnect();
                                bNewDatabase = true;
                                return true;
                            }
                            else
                            {
                                LogFile.Error.Show(sErr);
                                return false;
                            }
                        }
                        else
                        {
                            MessageBox.Show(lng.s_Already_exist.s + ":" + DataBase);
                            return true;
                        }

                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:DBConnectionControl40:DBConnection:Startup_03_CreateNewDataBaseConnection: m_DBType = "+ m_DBType.ToString() +" is not implemented!");
                        return false;
                    }
                }
                catch (Exception ex)
                {
                   LogFile.Error.Show("ERROR SQLITE:Excpetion = " + ex.Message);
                    return false;
                }
            }
            else
            {
                bCancel = true;
                return true;
            }
        }
        public ConnectResult_ENUM EvaluateConnectionDialogResult(string sTitle,NavigationButtons.Navigation xnav,ref bool bNewDatabase, ref bool bCanceled)
        {
            if (xnav.eExitResult == NavigationButtons.Navigation.eEvent.PREV)
            {
                return ConnectResult_ENUM.CANCELED;
            }

            if ((xnav.eExitResult == NavigationButtons.Navigation.eEvent.EXIT) || (xnav.eExitResult == NavigationButtons.Navigation.eEvent.CANCEL))
            {
                bCanceled = true;
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
            else if ((xnav.eExitResult == NavigationButtons.Navigation.eEvent.NEXT) || (xnav.eExitResult == NavigationButtons.Navigation.eEvent.OK))
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
                          
                            if (Connect_ToServerOnly(ref sErr))
                            {
                                if (m_DBType == eDBType.SQLITE)
                                {
                                    try
                                    {
                                        SQLiteCommand cmd = m_con_SQLite.CreateCommand();
                                        cmd.CommandText = "PRAGMA foreign_keys = ON;";
                                        cmd.ExecuteNonQuery();
                                    }
                                    catch (Exception ex)
                                    {
                                        LogFile.Error.Show("ERROR:SQLite:PRAGMA foreign_keys = ON;! " + ex.Message);
                                    }
                                }
                                Disconnect();
                                bNewDatabase = true;
                            }
                            else
                            {
                                LogFile.Error.Show(sErr);
                                return ConnectResult_ENUM.SHOW_CONNECTION_DIALOG_AGAIN;
                            }
                        }

                    }
                    else
                    {
                        bNewDatabase = ConnectionDialog.m_bNewDataBase;
                    }

                    if (this.CheckDataBaseConnection(xnav.parentForm, sTitle))
                    {
                        if ((xnav.eExitResult == NavigationButtons.Navigation.eEvent.NEXT) || (xnav.eExitResult == NavigationButtons.Navigation.eEvent.OK))
                        {
                            return ConnectResult_ENUM.OK;
                        }
                        else if ((xnav.eExitResult == NavigationButtons.Navigation.eEvent.NEXT) || (xnav.eExitResult == NavigationButtons.Navigation.eEvent.OK))
                        {
                            ConnectionDialog.my_ConnectionDialog_enum = ConnectionDialog.ConnectionDialog_enum.SaveConnectionData;
                            ConnectionDialog.ShowDialog(xnav.parentForm);
                            xnav.eExitResult = ConnectionDialog.eExitEvent;
                            if ((xnav.eExitResult == NavigationButtons.Navigation.eEvent.NEXT) || (xnav.eExitResult == NavigationButtons.Navigation.eEvent.OK))
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
                        LogFile.Error.Show("ERROR SQLITE:Excpetion = " + ex.Message);
                    }
                }
            }
            return ConnectResult_ENUM.SHOW_CONNECTION_DIALOG_AGAIN;
        }
    
        public bool WizzardForDataBaseConnection(Form m_ParentForm,                    
                    string sTitle,ref bool bNewDatabase)
        {

            return false;
        }

        public bool FillDataTable(ref DataTable dt, string sqlGetColumnsNamesAndTypes, List<SQL_Parameter> lSQL_Parameter, ref string csError)
        {
            //SqlConnection Conn = new SqlConnection("Data Source=razvoj1;Initial Catalog=NOS_BIH;Persist Security Info=True;User ID=sa;Password=sa;");
            ProgramDiagnostic.Diagnostic.Meassure("FillDataTable START", sqlGetColumnsNamesAndTypes);
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

                            if (Connect_Batch(ref csError))
                            {
                                MySqlCommand SqlCommandcommandGetColumnsNamesAndTypes = new MySqlCommand(sqlGetColumnsNamesAndTypes, m_con_MYSQL);
                                SqlCommandcommandGetColumnsNamesAndTypes.CommandTimeout = CommandTimeout;
                                if (lSQL_Parameter != null)
                                {
                                    foreach (SQL_Parameter sqlPar in lSQL_Parameter)
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
                                Disconnect_Batch();
                            }
                            else
                            {
                                MessageBox.Show(csError, "ERROR", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                            }
                        }
                        ProgramDiagnostic.Diagnostic.Meassure("FillDataTable END", null);
                        return true;

                    case eDBType.MSSQL:
                        {
                            SqlDataAdapter adapter = new SqlDataAdapter();

                            if (Connect_Batch(ref csError))
                            {
                                SqlCommand SqlCommandcommandGetColumnsNamesAndTypes = new SqlCommand(sqlGetColumnsNamesAndTypes, m_con_MSSQL);
                                if (lSQL_Parameter != null)
                                {
                                    foreach (SQL_Parameter sqlPar in lSQL_Parameter)
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
                                Disconnect_Batch();
                            }
                            else
                            {
                                MessageBox.Show(csError, "ERROR", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                            }
                        }
                        ProgramDiagnostic.Diagnostic.Meassure("FillDataTable END", null);
                        return true;

                    case eDBType.SQLITE:
                        {
                            SQLiteDataAdapter adapter = new SQLiteDataAdapter();

                            if (Connect_Batch(ref csError))
                            {

                                SQLiteCommand SqlCommandcommandGetColumnsNamesAndTypes = new SQLiteCommand(sqlGetColumnsNamesAndTypes, m_con_SQLite);
                                if (lSQL_Parameter != null)
                                {
                                    foreach (SQL_Parameter sqlPar in lSQL_Parameter)
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
                                Disconnect_Batch();
                            }
                            else
                            {
                                MessageBox.Show(csError, "ERROR", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                            }
                        }
                        ProgramDiagnostic.Diagnostic.Meassure("FillDataTable END", null);
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
                ProgramDiagnostic.Diagnostic.Meassure("FillDataTable END ERROR", null);
                return false;
            }
        }
        
        public bool ReadDataTable(ref DataTable dt, string sqlGetColumnsNamesAndTypes, ref string csError)
        {

            ProgramDiagnostic.Diagnostic.Meassure("ReadDataTable START", sqlGetColumnsNamesAndTypes);

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

                            if (Connect_Batch(ref csError))
                            {
                                MySqlCommand SqlCommandcommandGetColumnsNamesAndTypes = new MySqlCommand(sqlGetColumnsNamesAndTypes, m_con_MYSQL);
                                adapter.SelectCommand = SqlCommandcommandGetColumnsNamesAndTypes;
                                adapter.Fill(dt);
                                adapter.Dispose();
                                SqlCommandcommandGetColumnsNamesAndTypes.Dispose();
                                Disconnect_Batch();
                            }
                            else
                            {
                                MessageBox.Show(csError, "ERROR", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                            }
                        }
                        ProgramDiagnostic.Diagnostic.Meassure("ReadDataTable END",null);
                        return true;

                    case eDBType.MSSQL:
                        {
                            SqlDataAdapter adapter = new SqlDataAdapter();

                            if (Connect_Batch(ref csError))
                            {
                                SqlCommand SqlCommandcommandGetColumnsNamesAndTypes = new SqlCommand(sqlGetColumnsNamesAndTypes, m_con_MSSQL);
                                adapter.SelectCommand = SqlCommandcommandGetColumnsNamesAndTypes;
                                adapter.Fill(dt);
                                adapter.Dispose();
                                SqlCommandcommandGetColumnsNamesAndTypes.Dispose();
                                Disconnect_Batch();
                            }
                            else
                            {
                                MessageBox.Show(csError, "ERROR", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                            }
                        }
                        ProgramDiagnostic.Diagnostic.Meassure("ReadDataTable END", null);
                        return true;

                    case eDBType.SQLITE:
                        {
                            SQLiteDataAdapter adapter = new SQLiteDataAdapter();

                            if (Connect_Batch(ref csError))
                            {
                                SQLiteCommand SqlCommandcommandGetColumnsNamesAndTypes = new SQLiteCommand(sqlGetColumnsNamesAndTypes, m_con_SQLite);
                                adapter.SelectCommand = SqlCommandcommandGetColumnsNamesAndTypes;
                                adapter.Fill(dt);
                                adapter.Dispose();
                                SqlCommandcommandGetColumnsNamesAndTypes.Dispose();
                                Disconnect_Batch();
                            }
                            else
                            {
                                MessageBox.Show(csError, "ERROR", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                            }
                        }
                        ProgramDiagnostic.Diagnostic.Meassure("ReadDataTable END", null);
                        return true;

                    default:
                        MessageBox.Show("Error eSQLType in function: public bool ReadDataTable( ..)");
                        ProgramDiagnostic.Diagnostic.Meassure("ReadDataTable END ERROR", null);
                        return false;
                }
            }
            catch (Exception ex)
            {
                Disconnect();

                ShowDBErrorMessage(ex.Message, null, "ExecuteNonQuerySQL");
                csError = "ERROR:" + ex.Message;

                WriteLogTable(ex);
                ProgramDiagnostic.Diagnostic.Meassure("ReadDataTable END ERROR", null);
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
            ProgramDiagnostic.Diagnostic.Meassure("ReadDataSet START", sqlGetColumnsNamesAndTypes);
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
                            if (Connect_Batch(ref sError))
                            {
                                MySqlCommand SqlCommandcommandGetColumnsNamesAndTypes = new MySqlCommand(sqlGetColumnsNamesAndTypes, m_con_MYSQL);
                                adapter.SelectCommand = SqlCommandcommandGetColumnsNamesAndTypes;
                                adapter.Fill(ds);
                                adapter.Dispose();
                                SqlCommandcommandGetColumnsNamesAndTypes.Dispose();
                                Disconnect_Batch();
                            }
                            else
                            {
                                MessageBox.Show(sError, "ERROR", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                            }
                        }
                        ProgramDiagnostic.Diagnostic.Meassure("ReadDataSet END", null);
                        return true;
                    case eDBType.MSSQL:
                        {
                            SqlDataAdapter adapter = new SqlDataAdapter();
                            string sError = "";
                            if (Connect_Batch(ref sError))
                            {
                                SqlCommand SqlCommandcommandGetColumnsNamesAndTypes = new SqlCommand(sqlGetColumnsNamesAndTypes, m_con_MSSQL);
                                adapter.SelectCommand = SqlCommandcommandGetColumnsNamesAndTypes;
                                adapter.Fill(ds);
                                adapter.Dispose();
                                SqlCommandcommandGetColumnsNamesAndTypes.Dispose();
                                Disconnect_Batch();
                            }
                            else
                            {
                                MessageBox.Show(sError, "ERROR", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                            }
                        }
                        ProgramDiagnostic.Diagnostic.Meassure("ReadDataSet END", null);
                        return true;

                    case eDBType.SQLITE:
                        {
                            SQLiteDataAdapter adapter = new SQLiteDataAdapter();
                            string sError = "";
                            if (Connect_Batch(ref sError))
                            {
                                SQLiteCommand SqlCommandcommandGetColumnsNamesAndTypes = new SQLiteCommand(sqlGetColumnsNamesAndTypes, m_con_SQLite);
                                adapter.SelectCommand = SqlCommandcommandGetColumnsNamesAndTypes;
                                adapter.Fill(ds);
                                adapter.Dispose();
                                SqlCommandcommandGetColumnsNamesAndTypes.Dispose();
                                Disconnect_Batch();
                            }
                            else
                            {
                                MessageBox.Show(sError, "ERROR", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                            }
                        }
                        ProgramDiagnostic.Diagnostic.Meassure("ReadDataSet END", null);
                        return true;


                    default:
                        MessageBox.Show("ERROR eSQLType in function:public bool ReadDataSet(..)");
                        ProgramDiagnostic.Diagnostic.Meassure("ReadDataSet END", null);
                        return false;
                }
            }
            catch (Exception ex)
            {
                //System.Windows.Forms.MessageBox.Show("SQL ERROR:" + ex.Message);
                Disconnect();

                ShowDBErrorMessage(ex.Message, null, "ReadDataSet");
                WriteLogTable(ex);
                ProgramDiagnostic.Diagnostic.Meassure("ReadDataSet END", null);
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

        public bool ExecuteQuerySQL(StringBuilder sql,List<SQL_Parameter> lSQL_Parameter, ref ID id_new, ref string csError,string SQlite_table_name)
        {
            //SqlConnection Conn = new SqlConnection("Data Source=razvoj1;Initial Catalog=NOS_BIH;Persist Security Info=True;User ID=sa;Password=sa;");

            ProgramDiagnostic.Diagnostic.Meassure("ExecuteQuerySQL START", sql.ToString());
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

            id_new = null;
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
                            if (Connect_Batch(ref sError))
                            {
                                command = new MySqlCommand(sqlTran.ToString(), m_con_MYSQL);
                                command.CommandTimeout = 20000;
                                if (lSQL_Parameter != null)
                                {
                                    foreach (SQL_Parameter sqlPar in lSQL_Parameter)
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
                                            id_new = new ID(s);
                                        }
                                    }
                                    else if (ReturnObject.GetType() == typeof(Int32))
                                    {
                                        id_new = new ID(ReturnObject);
                                    }
                                    else if (ReturnObject.GetType() == typeof(Int64))
                                    {
                                        id_new = new ID(ReturnObject);
                                    }
                                }
                                Disconnect_Batch();
                                ProgramDiagnostic.Diagnostic.Meassure("ExecuteQuerySQL END", null);
                                return true;
                            }
                            else
                            {
                                MessageBox.Show(sError, "ERROR", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                                ProgramDiagnostic.Diagnostic.Meassure("ExecuteQuerySQL END", null);
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
                            if (Connect_Batch(ref sError))
                            {
                                command = new SqlCommand(sqlTran.ToString(), m_con_MSSQL);
                                command.CommandTimeout = 200000;
                                if (lSQL_Parameter != null)
                                {
                                    foreach (SQL_Parameter sqlPar in lSQL_Parameter)
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
                                            id_new = new ID(s);
                                        }
                                    }
                                }
                                Disconnect_Batch();
                                ProgramDiagnostic.Diagnostic.Meassure("ExecuteQuerySQL END", null);
                                return true;
                            }
                            else
                            {
                                MessageBox.Show(sError, "ERROR", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                                ProgramDiagnostic.Diagnostic.Meassure("ExecuteQuerySQL END", null);
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
                            if (Connect_Batch(ref sError))
                            {
                                command = new SQLiteCommand(sqlTran.ToString(), m_con_SQLite);
                                command.CommandTimeout = 200000;
                                if (lSQL_Parameter != null)
                                {
                                    foreach (SQL_Parameter sqlPar in lSQL_Parameter)
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
                                Disconnect_Batch();
                                if (ReturnObject == null)
                                {
                                    //SQLiteCommand cmd = new SQLiteCommand("SELECT last_insert_rowid() AS ID" , m_con_SQLite);
                                    // On different Sqlite.dll runs different !
//                                    SQLiteCommand cmd = new SQLiteCommand("SELECT last_insert_rowid() from " + SQlite_table_name, m_con_SQLite);
                                    SQLiteCommand cmd = new SQLiteCommand("SELECT last_insert_rowid()", m_con_SQLite);
                                    // Bepaal de nieuwe ID en sla deze op in het juiste veld
                                    if (Connect_Batch(ref sError))
                                    {
                                        object nieuweID = cmd.ExecuteScalar();
                                        id_new = new ID(nieuweID);
                                        Disconnect_Batch();
                                    }
                                    else
                                    {
                                        LogFile.Error.Show(sError);
                                        ProgramDiagnostic.Diagnostic.Meassure("ExecuteQuerySQL END", null);
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
                                            id_new = new ID(ReturnObject);
                                        }
                                    }
                                    else if (ReturnObject.GetType() == typeof(long))
                                    {
                                        id_new = new ID(ReturnObject); 
                                    }
                                    else if (ReturnObject.GetType() == typeof(Int32))
                                    {
                                        id_new = new ID(ReturnObject); 
                                    }
                                    else if (ReturnObject.GetType() == typeof(Int64))
                                    {
                                        id_new = new ID(ReturnObject); 
                                    }
                                }
                                ProgramDiagnostic.Diagnostic.Meassure("ExecuteQuerySQL END", null);
                                return true;
                            }
                            else
                            {
                                LogFile.Error.Show(sError);
                                ProgramDiagnostic.Diagnostic.Meassure("ExecuteQuerySQL END ERROR", null);
                                return false;
                            }
                        }
                        //break;

                    default:
                        LogFile.Error.Show("Error eSQLType in function:public bool ExecuteQuerySQL(...)");
                        ProgramDiagnostic.Diagnostic.Meassure("ExecuteQuerySQL END ERROR", null);
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
                ProgramDiagnostic.Diagnostic.Meassure("ExecuteQuerySQL END ERROR", null);
                return false;
            }
        }

        public bool ExecuteNonQuerySQL(string sql, List<SQL_Parameter> lSQL_Parameter, ref object Result, ref string ErrorMsg)
        {
            //SqlConnection Conn = new SqlConnection(xString);
            ProgramDiagnostic.Diagnostic.Meassure("ExecuteNonQuerySQL START", sql);
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
                if (Connect_Batch(ref ErrorMsg))
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
                                foreach (SQL_Parameter sqlPar in lSQL_Parameter)
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
                            Disconnect_Batch();
                        }
                        ProgramDiagnostic.Diagnostic.Meassure("ExecuteNonQuerySQL END", null);
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
                                foreach (SQL_Parameter sqlPar in lSQL_Parameter)
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
                            Disconnect_Batch();
                            ProgramDiagnostic.Diagnostic.Meassure("ExecuteNonQuerySQL END", null);
                            return true;
                        }
                      //  return true;

                        case eDBType.SQLITE:
                        {
                            sqlTran.Append("BEGIN TRANSACTION; \n");
                            sqlTran.Append(sql);
                            sqlTran.Append(";\nCOMMIT TRANSACTION; \n");
                            SQLiteCommand command;
                            command = new SQLiteCommand(sqlTran.ToString(), m_con_SQLite);
                            if (lSQL_Parameter != null)
                            {
                                foreach (SQL_Parameter sqlPar in lSQL_Parameter)
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
                            Disconnect_Batch();
                        }
                        ProgramDiagnostic.Diagnostic.Meassure("ExecuteNonQuerySQL END", null);
                        return true;

                        default:
                            MessageBox.Show("Error eSQLType in function: ExecuteNonQuerySQL(...)");
                            ProgramDiagnostic.Diagnostic.Meassure("ExecuteNonQuerySQL END ERROR", null);
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
                    ProgramDiagnostic.Diagnostic.Meassure("ExecuteNonQuerySQL END ERROR", null);
                    return false;
                }
                catch (Exception ee)
                {
                    Disconnect();
                    Console.WriteLine(ee.ToString());
                    ProgramDiagnostic.Diagnostic.Meassure("ExecuteNonQuerySQL END ERROR", null);
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

        public bool ExecuteNonQuerySQL_NoMultiTrans(string sql, List<SQL_Parameter> lSQL_Parameter, ref string ErrorMsg)
        {
            //SqlConnection Conn = new SqlConnection(xString);
            ProgramDiagnostic.Diagnostic.Meassure("ExecuteNonQuerySQL_NoMultiTrans START", sql);
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
                if (Connect_Batch(ref ErrorMsg))
                {
                    switch (m_DBType)
                    {
                        case eDBType.MYSQL:
                         {
                            MySqlCommand command;
                            command = new MySqlCommand(sql, m_con_MYSQL);
                            if (lSQL_Parameter != null)
                            {
                                foreach (SQL_Parameter sqlPar in lSQL_Parameter)
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
                            Disconnect_Batch();
                         }
                        ProgramDiagnostic.Diagnostic.Meassure("ExecuteNonQuerySQL_NoMultiTrans END",null);
                        return true;

                        case eDBType.MSSQL:
                        {

                            SqlCommand command;
                            SqlParameter OutPar = null;
                            command = new SqlCommand(sql, m_con_MSSQL);
                            if (lSQL_Parameter != null)
                            {
                                foreach (SQL_Parameter sqlPar in lSQL_Parameter)
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


                            command.CommandTimeout = 200000;
                            command.ExecuteNonQuery();
                            Disconnect_Batch();
                            if (!SetOuputParamaters(lSQL_Parameter, command.Parameters, ref ErrorMsg))
                            {
                                ProgramDiagnostic.Diagnostic.Meassure("ExecuteNonQuerySQL_NoMultiTrans END ret false", null);
                                return false;
                            }
                        }
                        ProgramDiagnostic.Diagnostic.Meassure("ExecuteNonQuerySQL_NoMultiTrans END", null);
                        return true;

                        case eDBType.SQLITE:
                        {

                            SQLiteCommand command;
                            command = new SQLiteCommand(sql, m_con_SQLite);
                            if (lSQL_Parameter != null)
                            {
                                foreach (SQL_Parameter sqlPar in lSQL_Parameter)
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
                            Disconnect_Batch();

                        }
                        ProgramDiagnostic.Diagnostic.Meassure("ExecuteNonQuerySQL_NoMultiTrans END", null);
                        return true;

                        default:
                            MessageBox.Show("Error eSQLType in function public bool ExecuteNonQuerySQL_NoMultiTrans(...)");
                            ProgramDiagnostic.Diagnostic.Meassure("ExecuteNonQuerySQL_NoMultiTrans END ERROR", null);
                            return false;
                    }
                }
                else
                {
                    ProgramDiagnostic.Diagnostic.Meassure("ExecuteNonQuerySQL_NoMultiTrans END ret false", null);
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
                ProgramDiagnostic.Diagnostic.Meassure("ExecuteNonQuerySQL_NoMultiTrans END ERROR", null);
                return false;
            }
        }

        private bool SetOuputParamaters(List<SQL_Parameter> lSQL_Parameter, SqlParameterCollection sqlParameterCollection, ref string ErrorMsg)
        {
            if (lSQL_Parameter != null)
            {
                int i = 0;
                int iCount = lSQL_Parameter.Count;
                for (i = 0; i < iCount; i++)
                {
                    if (lSQL_Parameter[i].IsOutputParameter)
                    {
                        string Err = null;
                        if (!GetParametersValue(lSQL_Parameter[i].Name, ref lSQL_Parameter[i].Value, sqlParameterCollection, ref Err))
                        {
                            ErrorMsg = "ERROR:DBConnection:ExecuteNonQuerySQL_NoMultiTrans:GetParametersValue:Err=" + Err;
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        private bool GetParametersValue(string Name,ref object value, SqlParameterCollection sqlParameterCollection, ref string Err)
        {
            foreach (SqlParameter spar in sqlParameterCollection)
            {
                if (spar.ParameterName.Equals(Name))
                {
                    value = spar.Value;
                    return true;
                }
            }
            return false;
        }

        private bool Execute_SQLReadData(string sql, List<SQL_Parameter> lSQL_Parameter,out SQLReaderTable ReaderTable, ref string ErrorMsg)
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
                if (Connect_Batch(ref ErrorMsg))
                {
                    switch (m_DBType)
                    {
                        case eDBType.MYSQL:
                        {
                            MySqlCommand command;
                            command = new MySqlCommand(sql, m_con_MYSQL);
                            if (lSQL_Parameter != null)
                            {
                                foreach (SQL_Parameter sqlPar in lSQL_Parameter)
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

                            Disconnect_Batch();
                        }
                        return true;


                        case eDBType.MSSQL:
                        {
                            SqlCommand command;
                            command = new SqlCommand(sql, m_con_MSSQL);
                            if (lSQL_Parameter != null)
                            {
                                foreach (SQL_Parameter sqlPar in lSQL_Parameter)
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


                            Disconnect_Batch();
                        }
                        return true;

                        case eDBType.SQLITE:
                        {
                            SQLiteCommand command;
                            command = new SQLiteCommand(sql, m_con_SQLite);
                            if (lSQL_Parameter != null)
                            {
                                foreach (SQL_Parameter sqlPar in lSQL_Parameter)
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

                            Disconnect_Batch();
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

        private void PreviewSQLCommand(string sql, List<SQL_Parameter> lSQL_Parameter, ref string OutString, ref bool bChanged, string Title)
        {
            bChanged = false;
            SqlBuilder.Forms.frmEditor frmEditor = new SqlBuilder.Forms.frmEditor(sql,lSQL_Parameter, Title);
            if (frmEditor.ShowDialog()==DialogResult.OK)
            {
                bChanged = true;
                OutString = frmEditor.s_sql_text;
            }
        }

        private void ShowDBErrorMessage(string ErrorMsg, List<SQL_Parameter> lSQL_Parameter, string Title)
        {
            if (m_ShowDBErrorMessages)
            {
                SqlBuilder.Forms.frmEditor frmEditor = new SqlBuilder.Forms.frmEditor(ErrorMsg, lSQL_Parameter, Title);
                if (frmEditor.ShowDialog() == DialogResult.OK)
                {
                }
            }
        }

        public string DataBase_BackupTemp
        {
            get
            {
                switch (m_DBType)
                {
                    case eDBType.MYSQL:
                        if (m_conData_MYSQL != null)
                        {
                            return m_conData_MYSQL.m_DataBase + BACKUPTEMP;
                        }
                        else
                        {
                            return null;
                        }

                    case eDBType.MSSQL:
                        if (m_conData_MSSQL != null)
                        {
                            return m_conData_MSSQL.m_DataBase + BACKUPTEMP;
                        }
                        else
                        {
                            return null;
                        }

                    case eDBType.SQLITE:
                        return m_conData_SQLITE.DataBaseFile + BACKUPTEMP;
                    default:
                        LogFile.Error.Show("Error: Illegal m_DBType in properrty DataBase");
                        return "";

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
                        LogFile.Error.Show("Error: Illegal m_DBType in properrty DataBase");
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
                        LogFile.Error.Show("Error: Illegal m_DBType in properrty DataBase");
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
                        LogFile.Error.Show("Error in get property UserName:  SQLITE does not support UserName");
                        return "";
                    default:
                        LogFile.Error.Show("Error in get property UserName:  unvalid m_DBType");
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
                        LogFile.Error.Show("Error in property:  public string UserName : SQLITE does not have user name!");
                        break;
                    default:
                        LogFile.Error.Show("Error in set property UserName:  unvalid m_DBType");
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
                            return "Data Source=" + m_conData_SQLITE.DataBaseFile + ";Version=3;foreign keys=true;";//Password=Logina2761962SQLite";

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
            if (DB_Param.GetType() == typeof(RemoteDB_data))
            {
                RemoteDB_data remDB = (RemoteDB_data)DB_Param;
                this.ConnectionName = remDB.ConnectionName;
                DBType = remDB.DBType;
            }
            else
            {
                if (DB_Param.GetType() == typeof(LocalDB_data))
                {
                    LocalDB_data localDB = (LocalDB_data)DB_Param;
                    this.ConnectionName = localDB.ConnectionName;
                    DBType = eDBType.SQLITE;
                    m_conData_SQLITE.SQLite_AllwaysCreateNew = localDB.bAllwaysCreateNew;
                }
                else
                {
                    LogFile.Error.Show("Error DB_Param not of type  RemoteDB_data or LocalDB_data !");
                    return;
                }
            }

            switch (DBType)
            {
                case eDBType.MSSQL:
                    if (m_conData_MSSQL != null)
                    {
                        if (DB_Param.GetType() == typeof(RemoteDB_data))
                        {
                            RemoteDB_data remoteDB_Param = (RemoteDB_data)DB_Param;
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
                            LogFile.Error.Show("Error not LocalDB_data param in function public void SetConnectionData(Object DB_Param)!");
                        }
                    }
                    else
                    {
                        LogFile.Error.Show("Error: MyDataBase not created m_conData_MSSQL ==null");
                    }
                    break;

                case eDBType.MYSQL:
                    if (m_conData_MYSQL != null)
                    {
                        if (DB_Param.GetType() == typeof(RemoteDB_data))
                        {
                            RemoteDB_data remoteDB_Param = (RemoteDB_data)DB_Param;
                            DataSource = remoteDB_Param.DataSource;
                            DataBase = remoteDB_Param.DataBase;
                            UserName = remoteDB_Param.UserName;
                            m_conData_MYSQL.m_crypted_Password = remoteDB_Param.crypted_Password;
                        }
                        else
                        {
                            LogFile.Error.Show("Error not LocalDB_data param in function public void SetConnectionData(Object DB_Param)!");
                        }
                    }
                    else
                    {
                        LogFile.Error.Show("Error: MyDataBase not created m_conData_MSSQL ==null");
                    }
                    break;

                case eDBType.SQLITE:
                    if (m_conData_SQLITE != null)
                    {
                        if (DB_Param.GetType() == typeof(LocalDB_data))
                        {
                            LocalDB_data LocalDB_Param =  (LocalDB_data)DB_Param;

                            if ((LocalDB_Param.DataBaseFilePath != null) && (LocalDB_Param.DataBaseFileName != null))
                            {
                                m_conData_SQLITE.DataBaseFile = LocalDB_Param.DataBaseFilePath + LocalDB_Param.DataBaseFileName;
                            }
                            else
                            {

                                LogFile.Error.Show("Error ((LocalDB_Param.DataBaseFilePath != null) && (LocalDB_Param.DataBaseFileName != null)) in function public void SetConnectionData(Object DB_Param)!");
                            }
                            
                        }
                        else
                        {
                            LogFile.Error.Show("Error not LocalDB_data param in function public void SetConnectionData(Object DB_Param)!");
                        }
                    }
                    else
                    {
                        LogFile.Error.Show("Error: MyDataBase not created m_conData_SQLITE ==null");
                    }
                    break;
            }
        }

        public bool ExecuteNonQuerySQLReturnID(string sql, List<SQL_Parameter> lSQL_Parameter, ref ID newID, ref string ErrorMsg, string SQlite_table_name)
        {
            //SqlConnection Conn = new SqlConnection(xString);
            ProgramDiagnostic.Diagnostic.Meassure("ExecuteNonQuerySQLReturnID START", sql);

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
                if (Connect_Batch(ref ErrorMsg))
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
                                    foreach (SQL_Parameter sqlPar in lSQL_Parameter)
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
                                Disconnect_Batch();
                            }
                            ProgramDiagnostic.Diagnostic.Meassure("ExecuteNonQuerySQLReturnID END", null);
                            return true;

                        case eDBType.MSSQL:
                            {
                                //sqlTran.Append("BEGIN TRAN TRANSACTION_EVLicence; \n");
                                sqlTran.Append(sql);
                                //sqlTran.Append("\nCOMMIT TRAN TRANSACTION_EVLicence; \n");
                                sqlTran.Append(";SELECT SCOPE_IDENTITY();");
                                SqlCommand command;
                                command = new SqlCommand(sqlTran.ToString(), m_con_MSSQL);
                                if (lSQL_Parameter != null)
                                {
                                    foreach (SQL_Parameter sqlPar in lSQL_Parameter)
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

                                 //Convert.ToInt64(nieuweID);
                                newID = new ID(Convert.ToInt64(command.ExecuteScalar()));
                                //command.ExecuteNonQuery();
                                Disconnect_Batch();
                            }
                            ProgramDiagnostic.Diagnostic.Meassure("ExecuteNonQuerySQLReturnID END", null);
                            return true;

                        case eDBType.SQLITE:
                            {
                                //sqlTran.Append("BEGIN TRANSACTION; \n");
                                sqlTran.Append(sql);
                                //sqlTran.Append(";\nCOMMIT TRANSACTION; \n");
                                SQLiteCommand command;
                                command = new SQLiteCommand(sqlTran.ToString(), m_con_SQLite);
                                if (lSQL_Parameter != null)
                                {
                                    foreach (SQL_Parameter sqlPar in lSQL_Parameter)
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
                                newID = new ID(cmd.ExecuteScalar());
                                Disconnect_Batch();
                            }
                            ProgramDiagnostic.Diagnostic.Meassure("ExecuteNonQuerySQLReturnID END", null);
                            return true;

                        default:
                            MessageBox.Show("Error eSQLType in function: ExecuteNonQuerySQL(...)");
                            ProgramDiagnostic.Diagnostic.Meassure("ExecuteNonQuerySQLReturnID END Error", null);
                            return false;
                    }
                }
                else
                {
                    //               MessageBox.Show(csError, "ERROR", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                    ProgramDiagnostic.Diagnostic.Meassure("ExecuteNonQuerySQLReturnID END false", null);
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
                    ProgramDiagnostic.Diagnostic.Meassure("ExecuteNonQuerySQLReturnID END Error", null);

                    return false;
                }
                catch (Exception ee)
                {
                    Disconnect();
                    Console.WriteLine(ee.ToString());
                    ProgramDiagnostic.Diagnostic.Meassure("ExecuteNonQuerySQLReturnID END Error", null);
                    return false;
                    //throw new Exception(ee.ToString(), ee);
                }
            }
        }

        public bool ReadDataTable(ref DataTable dt, string sqlGetColumnsNamesAndTypes, List<SQL_Parameter> lSQL_Parameter, ref string csError)
        {
            ProgramDiagnostic.Diagnostic.Meassure("ReadDataTable(2) START", sqlGetColumnsNamesAndTypes);

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

                            if (Connect_Batch(ref csError))
                            {
                                MySqlCommand SqlCommandcommandGetColumnsNamesAndTypes = new MySqlCommand(sqlGetColumnsNamesAndTypes, m_con_MYSQL);
                                if (lSQL_Parameter != null)
                                {
                                    foreach (SQL_Parameter sqlPar in lSQL_Parameter)
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
                                Disconnect_Batch();
                            }
                            else
                            {
                                MessageBox.Show(csError, "ERROR", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                            }
                        }
                        ProgramDiagnostic.Diagnostic.Meassure("ReadDataTable(2)  END", null);
                        return true;

                    case eDBType.MSSQL:
                        {
                            SqlDataAdapter adapter = new SqlDataAdapter();

                            if (Connect_Batch(ref csError))
                            {
                                SqlCommand SqlCommandcommandGetColumnsNamesAndTypes = new SqlCommand(sqlGetColumnsNamesAndTypes, m_con_MSSQL);
                                if (lSQL_Parameter != null)
                                {
                                    foreach (SQL_Parameter sqlPar in lSQL_Parameter)
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
                                Disconnect_Batch();
                            }
                            else
                            {
                                MessageBox.Show(csError, "ERROR", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                            }
                        }
                        ProgramDiagnostic.Diagnostic.Meassure("ReadDataTable(2)  END", null);
                        return true;

                    case eDBType.SQLITE:
                        {
                            SQLiteDataAdapter adapter = new SQLiteDataAdapter();

                            if (Connect_Batch(ref csError))
                            {
                                SQLiteCommand SqlCommandcommandGetColumnsNamesAndTypes = new SQLiteCommand(sqlGetColumnsNamesAndTypes, m_con_SQLite);
                                if (lSQL_Parameter != null)
                                {
                                    foreach (SQL_Parameter sqlPar in lSQL_Parameter)
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
                                Disconnect_Batch();
                            }
                            else
                            {
                                MessageBox.Show(csError, "ERROR", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                            }
                        }
                        ProgramDiagnostic.Diagnostic.Meassure("ReadDataTable(2)  END", null);
                        return true;

                    default:
                        MessageBox.Show("Error eSQLType in function: public bool ReadDataTable( ..)");
                        ProgramDiagnostic.Diagnostic.Meassure("ReadDataTable(2)  END ERROR", null);
                        return false;
                }
            }
            catch (Exception ex)
            {
                Disconnect();
                csError = "Error:DBConnectionControl:ReadDataTable:Ex.Message:\r\n" + ex.Message;
                ShowDBErrorMessage(ex.Message, null, "ExecuteNonQuerySQL");

                WriteLogTable(ex);
                ProgramDiagnostic.Diagnostic.Meassure("ReadDataTable(2)  END ERROR", null);
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

            string sLastQuestion = lng.s_AreYouSureToDeleteDataBase.s + " " +this.DataBase + " on server:" +this.DataSource+ "?";

            if (MessageBox.Show(sLastQuestion, lng.s_Question.s, MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
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

        public bool DataBase_Make_BackupTemp()
        {
            switch (m_DBType)
            {
                case eDBType.MYSQL:
                    return DataBase_Make_BackupTemp_MYSQL();

                case eDBType.MSSQL:
                     return DataBase_Make_BackupTemp_MSSQL();

                case eDBType.SQLITE:
                     return DataBase_Make_BackupTemp_SQLite();

                default:
                    MessageBox.Show("Error eSQLType in function: public bool DataBase_Make_BackupTemp( ..)");
                    return false;
            }
        }

        public bool DataBase_Backup(string BackupFullFileNamePath)
        {
            switch (m_DBType)
            {
                case eDBType.MYSQL:
                    return DataBase_Make_Backup_MYSQL(BackupFullFileNamePath);

                case eDBType.MSSQL:
                    return DataBase_Make_Backup_MSSQL(BackupFullFileNamePath);

                case eDBType.SQLITE:
                    return DataBase_Make_Backup_SQLite(BackupFullFileNamePath);

                default:
                    MessageBox.Show("Error eSQLType in function: public bool DataBase_Make_BackupTemp( ..)");
                    return false;
            }
        }

        public bool DataBase_Restore(string BackupFullFileNamePath)
        {
            switch (m_DBType)
            {
                case eDBType.MYSQL:
                    return DataBase_Restore_MYSQL(BackupFullFileNamePath);

                case eDBType.MSSQL:
                    return DataBase_Restore_MSSQL(BackupFullFileNamePath);

                case eDBType.SQLITE:
                    return DataBase_Restore_SQLite(BackupFullFileNamePath);

                default:
                    MessageBox.Show("Error eSQLType in function: public bool DataBase_Make_BackupTemp( ..)");
                    return false;
            }
        }

        private bool DataBase_Restore_SQLite(string BackupFullFileNamePath)
        {
            string FullFileNamePath = this.m_conData_SQLITE.DataBaseFile;
            string DestinationFullFileNamePath = GetBackUpName();
            try
            {
                File.Copy(BackupFullFileNamePath, FullFileNamePath,true);
                return true;

            }
            catch (Exception Ex)
            {
                LogFile.Error.Show("ERROR:DBConnection:DataBase_Restore_SQLite:Backup file = \""+ BackupFullFileNamePath +"\"\r\nException = " + Ex.Message);
                return false;
            }
        }

        private bool DataBase_Restore_MSSQL(string backupName)
        {
            LogFile.Error.Show("ERROR:DBConnection:DataBase_Restore_MSSQL:Not implemented !");
            return false;
        }

        private bool DataBase_Restore_MYSQL(string backupName)
        {
            LogFile.Error.Show("ERROR:DBConnection:DataBase_Restore_MYSQL:Not implemented !");
            return false;
        }

        private bool DataBase_Make_Backup_MYSQL(string BackupFullFileNamePath)
        {
            LogFile.Error.Show("ERROR:DBConnection:DataBase_Make_Backup_MSSQL: Procedure not implemented!");
            return false;
        }

        private bool DataBase_Make_Backup_MSSQL(string BackupFullFileNamePath)
        {
            LogFile.Error.Show("ERROR:DBConnection:DataBase_Make_Backup_MSSQL: Procedure not implemented!");
            return false;
        }

        private bool DataBase_Make_Backup_SQLite(string BackupFullFileNamePath)
        {
            string FullFileNamePath = this.m_conData_SQLITE.DataBaseFile;
            if (BackupFullFileNamePath==null)
            {
                string full_path = System.IO.Path.GetDirectoryName(FullFileNamePath);
                string file_name = System.IO.Path.GetFileName(FullFileNamePath);
                if ((full_path[full_path.Length-1]!='\\') && (full_path[full_path.Length - 1] != '/'))
                {
                    full_path += '\\';
                }
                BackupFullFileNamePath = full_path +"BACKUP_"+ file_name;
            }

            try
            {
                File.Copy(FullFileNamePath, BackupFullFileNamePath);
                return true;

            }
            catch (Exception Ex)
            {
                LogFile.Error.Show("ERROR:DBConnection:DataBase_Make_BackupTemp_SQLite:Exception=" + Ex.Message);
                return false;
            }

        }

        private string GetBackUpName()
        {
            return null;
        }

        public bool DataBase_Delete_BackupTemp()
        {
            switch (m_DBType)
            {
                case eDBType.MYSQL:
                    return DataBase_Delete_BackupTemp_MYSQL();

                case eDBType.MSSQL:
                    return DataBase_Delete_BackupTemp_MSSQL();

                case eDBType.SQLITE:
                    return DataBase_Delete_BackupTemp_SQLite();

                default:
                    MessageBox.Show("Error eSQLType in function: public bool DataBase_Make_BackupTemp( ..)");
                    return false;
            }
        }

        private bool DataBase_Delete_BackupTemp_MYSQL()
        {
            throw new NotImplementedException();
        }

        private bool DataBase_Delete_BackupTemp_MSSQL()
        {
            throw new NotImplementedException();
        }

        

        private bool DataBase_Make_BackupTemp_SQLite()
        {
            string FullFileNamePath = this.m_conData_SQLITE.DataBaseFile;
            string DestinationFullFileNamePath = FullFileNamePath+BACKUPTEMP;
            try
            {
                File.Copy(FullFileNamePath, DestinationFullFileNamePath);
                return true;

            }
            catch (Exception Ex)
            {
                LogFile.Error.Show("ERROR:DBConnection:DataBase_Make_BackupTemp_SQLite:Exception=" + Ex.Message);
                return false;
            }
        }
        private bool DataBase_Delete_BackupTemp_SQLite()
        {
            string FullFileNamePath = this.m_conData_SQLITE.DataBaseFile;
            string DestinationFullFileNamePath = FullFileNamePath + BACKUPTEMP;
            try
            {
                File.Delete(DestinationFullFileNamePath);
                return true;

            }
            catch (Exception Ex)
            {
                LogFile.Error.Show("ERROR:DBConnection:DataBase_Make_BackupTemp_SQLite:Exception=" + Ex.Message);
                return false;
            }
        }




        private bool DataBase_Make_BackupTemp_MSSQL()
        {
            throw new NotImplementedException();
        }

        private bool DataBase_Make_BackupTemp_MYSQL()
        {
            throw new NotImplementedException();
        }

        public bool DataBase_Delete()
        {
            string FullFileNamePath = this.m_conData_SQLITE.DataBaseFile;
            try
            {
                File.Delete(FullFileNamePath);
                return true;

            }
            catch (Exception Ex)
            {
                LogFile.Error.Show("ERROR:DBConnection:DataBase_Make_BackupTemp_SQLite:Exception=" + Ex.Message);
                return false;
            }
        }

        public bool DataBase_Create()
        {
            try
            {
                if (m_DBType == eDBType.SQLITE)
                {
                    string sErr = null;
                    if (!File.Exists(DataBase))
                    {
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
                            if (m_DBType == eDBType.SQLITE)
                            {
                                try
                                {
                                    SQLiteCommand cmd = m_con_SQLite.CreateCommand();
                                    cmd.CommandText = "PRAGMA foreign_keys = ON;";
                                    cmd.ExecuteNonQuery();
                                    Disconnect();
                                    return true;
                                }
                                catch (Exception ex)
                                {
                                    LogFile.Error.Show("ERROR:DBConnection:DataBase_Create:Execption="+ex.Message);
                                    return false;
                                }
                            }
                            Disconnect();
                        }
                        else
                        {
                            LogFile.Error.Show("ERROR:DBConnection:DataBase_Create:Err="+sErr);
                            return false;
                        }
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:DBConnection:DataBase_Create:File:" + DataBase+" allready exist, can not overwrite database!");
                        return false;
                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:DBConnection:DataBase_Create::Implemented only for SQLite database!");
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                LogFile.Error.Show("DBConnection:DataBase_Create:Exception=" + ex.Message);
                return false;
            }
        }

        public bool TableExists(string TableName, ref string csError)
        {
            //string strTableNameAndSchema = " SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = '"+tbl.TableName+"'";
            //string strCheckTable =   m_strSQLUseDatabase + String.Format(
            //      "IF OBJECT_ID('{0}', 'U') IS NOT NULL SELECT 'true' ELSE SELECT 'false' ",strTableNameAndSchema
            //      );
            string strCheckTable = null;
            switch (DBType)
            {
                case DBConnection.eDBType.MYSQL:
                    strCheckTable = "SELECT COUNT(*) as res FROM information_schema.tables WHERE table_schema = '" + this.DataBase + "' AND table_name = '" + TableName + "';";
                    break;
                case DBConnection.eDBType.MSSQL:
                    strCheckTable = "\nUSE " + this.DataBase + "\n IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE='BASE TABLE' AND TABLE_NAME='" + TableName + "') SELECT 1 AS res ELSE SELECT 0 AS res";
                    break;
                case DBConnection.eDBType.SQLITE:
                    strCheckTable = "SELECT COUNT(*) as res FROM sqlite_master WHERE type = 'table' AND name = '" + TableName + "'";
                    break;
            }
            StringBuilder strB_CheckTable = new StringBuilder(strCheckTable);
            DataTable dt = new DataTable();
            if (this.ReadDataTable(ref dt,strCheckTable,ref csError))
            {
                if (dt.Rows.Count>0)
                {
                    int res = (int)dt.Rows[0]["res"];
                    if (res > 0)
                    {
                        return true;
                    }
                    else
                    {
                        csError = lng.s_Error.s + ": " + lng.sTableIsMissing.s + ":" + TableName;
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

    }
}

