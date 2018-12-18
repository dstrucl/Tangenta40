#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion
using TangentaDataBaseDef;
using DBConnectionControl40;
using LanguageControl;
using CodeTables;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using NavigationButtons;
using static CodeTables.DBTableControl;

namespace DBSync
{
    public static class DBSync
    {
        internal static StartupWindowThread my_StartupWindowThread = new StartupWindowThread();

        public static MyDataBase_Tangenta DB_for_Tangenta = null;

        public static SQLite_Support m_SQLite_Support = new SQLite_Support();

        public static RemoteDB_data RemoteDB_data = null;
        public static LocalDB_data LocalDB_data_SQLite = null;


        public static DBConnection.eDBType m_DBType = DBConnection.eDBType.SQLITE;


        public static string m_BackupFolder;

        public static bool Drop_VIEWs(ref string Err)
        {
            return DB_for_Tangenta.DropViews(ref Err);
        }

        public static bool Create_VIEWs()
        {
            return DB_for_Tangenta.Create_VIEWs();
        }

        public static bool Startup_02_Get_eDBType_and_DB_for_Tangenta(string DataBaseType, ref DBConnection.eDBType eDBType,Form parentForm,string IniFileFolder,string m_XmlFileName)
        {
            if (DataBaseType != null)
            {
                if (DataBaseType.Equals("SQLITE"))
                {
                    eDBType = DBConnection.eDBType.SQLITE;
                    m_DBType = eDBType;
                    if (DB_for_Tangenta == null)
                    {
                        DB_for_Tangenta = new TangentaDataBaseDef.MyDataBase_Tangenta(parentForm, m_XmlFileName, IniFileFolder);
                        DB_for_Tangenta.Init(eDBType);
                    }
                    return true;
                }
                else if (DataBaseType.Equals("MSSQL"))
                {
                    eDBType = DBConnection.eDBType.MSSQL;
                    m_DBType = eDBType;
                    if (DB_for_Tangenta == null)
                    {
                        DB_for_Tangenta = new TangentaDataBaseDef.MyDataBase_Tangenta(parentForm, m_XmlFileName, IniFileFolder);
                        DB_for_Tangenta.Init(eDBType);
                    }
                    return true;
                }
                else
                {
                    LogFile.Error.Show("ERROR:DDBSync:Get_eDBType:DataBaseType=" + DataBaseType + " not implemented!");
                    return false;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:DDBSync:Get_eDBType:DataBaseType==null!");
                return false;
            }
        }

        public static bool Startup_03_Check_DBConnection_Is_DataBase_Defined(bool bReset, ref string IniFileFolder, string inifile_prefix, string Connection_Name)
        {
            if (DBSync.m_DBType == DBConnection.eDBType.SQLITE)
            {
                return m_SQLite_Support.Startup_03_Check_DBConnection_Is_LocalDB_data_SQLite_DataBaseFileName_Defined(bReset, ref IniFileFolder, MyDataBase_Tangenta.DataBaseFilePrefix, Connection_Name);
            }
            else
            {
                return Startup_03_Check_DBConnection_Is_RemotelDB_data_DataBase_Defined( bReset, IniFileFolder, MyDataBase_Tangenta.DataBaseFilePrefix, Connection_Name);
            }
        }

        public static bool Startup_03_Undo_DBConnection()
        {
            if (DBSync.m_DBType == DBConnection.eDBType.SQLITE)
            {
                return m_SQLite_Support.Startup_03_Undo_DBConnection();
            }
            else
            {
                RemoteDB_data = null;
                return true;
            }
        }

        public static bool Startup_03_Set_LocalDB_From_SQLiteConnectionDialog(SQLiteConnectionDialog frm_SQLiteConnectionDialog)
        {
            LocalDB_data_SQLite.DataBaseFileName = frm_SQLiteConnectionDialog.DataBaseFile_name;
            LocalDB_data_SQLite.DataBaseFilePath = frm_SQLiteConnectionDialog.DataBaseFile_path;
            LocalDB_data_SQLite.bChanged = true;
            string Err = null;
            if (LocalDB_data_SQLite.Save(MyDataBase_Tangenta.DataBaseFilePrefix,ref Err))
            {
                // Connect to create SQLite file !
                if (DB_for_Tangenta.m_DBTables.m_con.Connect(ref Err))
                {
                    DB_for_Tangenta.m_DBTables.m_con.Disconnect();
                    return true;
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

        public static bool Startup_03_Show_ConnectionDialog(NavigationButtons.Navigation nav)
        {
            return DBSync.DB_for_Tangenta.m_DBTables.m_con.Startup_03_Show_ConnectionDialog(nav);
        }

        public static bool Init_DBType(bool bReset, string IniFileFolder, ref string DataBaseType, bool bChangeConnection, ref bool bNewDatabaseCreated, NavigationButtons.Navigation xnav, ref bool bCanceled)
        {
            string Err = null;
            if (DBSync.m_DBType == DBConnection.eDBType.SQLITE)
            {
                bool bGet = m_SQLite_Support.Get(bReset, ref Err, ref IniFileFolder, IniFileFolder, "TangentaDB", bChangeConnection, ref bNewDatabaseCreated, xnav, ref bCanceled,MyDataBase_Tangenta.VERSION);
                if (xnav.bDoModal)
                {
                    if (xnav.eExitResult == NavigationButtons.Navigation.eEvent.PREV)
                    {
                        bCanceled = false;
                        DataBaseType = "";
                        return true;
                    }
                    if (bGet)
                    {
                        my_StartupWindowThread.Message(lng.s_LocalDatabase_OK.s + m_SQLite_Support.sGetLocalDB());
                        return true;
                    }
                    else
                    {
                        if (!bCanceled)
                        {
                            LogFile.Error.Show(lng.s_CanNotReadDataBaseFile.s + " Err=" + Err);
                        }
                        return false;
                    }
                }
                else
                {
                    return bGet;
                }
            }
            else
            {
                my_StartupWindowThread.Message(lng.s_DataBaseFile.s);
                if (Get(xnav.parentForm, bReset, ref Err, ref IniFileFolder, "TangentaDB", ref bNewDatabaseCreated, xnav, ref bCanceled))
                {
                    my_StartupWindowThread.Message(lng.s_LocalDatabase_OK.s + m_SQLite_Support.sGetLocalDB());
                    return true;
                }
                else
                {
                    if (bCanceled)
                    {
                        return false;
                    }
                    else
                    {
                        LogFile.Error.Show("Napaka:Povezava na podatkovne baze za Blagajno ni uspela: Err=" + Err);
                        return false;
                    }
                }
            }

        }

        public static bool Startup_03_CheckDataBaseTables(Form pParentForm, ref bool bCancel)
        {
            string Err = null;
            int iTablesCount = -1;
            if (DB_for_Tangenta_SessionConnect(ref Err))
            {
                if (DB_for_Tangenta.m_DBTables.TableCountInDatabase(ref iTablesCount))
                {
                    if (iTablesCount == 0)
                    {
                        if (DB_for_Tangenta.m_DBTables.CreateDatabaseTables(false, ref bCancel, MyDataBase_Tangenta.VERSION))
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
                LogFile.Error.Show("ERROR:DBSync:DBsync:Startup_03_CheckDataBaseTables:Startup_03_CheckDataBaseTables:DB_for_Tangenta_SessionConnect failed! Err=" + Err);
                return false;
            }
        }

        public static bool Startup_03_CreateNewDatabase(Form pParentForm,ref bool bNewDatabase, ref bool bCancel)
        {
            return DB_for_Tangenta.m_DBTables.m_con.Startup_03_CreateNewDataBaseConnection(pParentForm, ref bNewDatabase, ref bCancel);
        }

        public static bool Evaluate_InitDBType(bool bReset, string IniFileFolder, ref string DataBaseType, bool bChangeConnection, ref bool bNewDatabaseCreated, NavigationButtons.Navigation xnav, ref bool bCanceled,string dbVersion)
        {
            string Err = null;           
            if (DBSync.m_DBType == DBConnection.eDBType.SQLITE)
            {
                my_StartupWindowThread.Message(lng.s_CheckLocalDatabase.s + m_SQLite_Support.sGetLocalDB());
                bool bGet = m_SQLite_Support.Evaluate_Connection(xnav, ref bNewDatabaseCreated, ref bCanceled, dbVersion);
                if (xnav.bDoModal)
                {
                    if (xnav.eExitResult == NavigationButtons.Navigation.eEvent.PREV)
                    {
                        bCanceled = false;
                        DataBaseType = "";
                        return true;
                    }
                    if (bGet)
                    {
                        my_StartupWindowThread.Message(lng.s_LocalDatabase_OK.s + m_SQLite_Support.sGetLocalDB());
                        return true;
                    }
                    else
                    {
                        if (!bCanceled)
                        {
                            LogFile.Error.Show(lng.s_CanNotReadDataBaseFile.s + " Err=" + Err);
                        }
                        return false;
                    }
                }
                else
                {
                    return bGet;
                }
            }
            else
            {
                my_StartupWindowThread.Message(lng.s_DataBaseFile.s);
                if (Get(xnav.parentForm, bReset, ref Err, ref IniFileFolder, "TangentaDB", ref bNewDatabaseCreated, xnav, ref bCanceled))
                {
                    my_StartupWindowThread.Message(lng.s_LocalDatabase_OK.s + m_SQLite_Support.sGetLocalDB());
                    return true;
                }
                else
                {
                    if (bCanceled)
                    {
                        return false;
                    }
                    else
                    {
                        LogFile.Error.Show("Napaka:Povezava na podatkovne baze za Blagajno ni uspela: Err=" + Err);
                        return false;
                    }
                }
            }

        }

        public static Form_DBmanager.eResult DBMan(Form parentform,bool bReset, string m_XmlFileName, string IniFileFolder, ref string DataBaseType,ref string xBackupFolder, NavigationButtons.Navigation xnav)
        {
            m_BackupFolder = xBackupFolder;
            Form_DBmanager dbman_dlg = new Form_DBmanager(parentform, bReset, m_XmlFileName, IniFileFolder, DataBaseType,m_BackupFolder, DB_for_Tangenta.Settings.Version.TextValue, xnav);
            dbman_dlg.ShowDialog();
            m_BackupFolder = dbman_dlg.m_BackupFolder;
            xBackupFolder = m_BackupFolder;
            DataBaseType = dbman_dlg.m_DataBaseType;
            return dbman_dlg.m_Result;
        }


        public static bool Show_Get_DBTypeForm(ref string DataBaseType, NavigationButtons.Navigation xnav)
        {
            if (xnav.ChildDialog!=null)
            {
                if (!xnav.ChildDialog.IsDisposed)
                {
                    xnav.ChildDialog.Close();
                }
                xnav.ChildDialog.Dispose();
            }

            xnav.ShowForm(new Form_GetDBType(DataBaseType, xnav),typeof(Form_GetDBType).ToString());
            return true;
        }


        public static string DataBase
        {
            get {
                    if (DB_for_Tangenta!=null)
                    {
                        if (DB_for_Tangenta.m_DBTables!=null)
                        {
                            if (DB_for_Tangenta.m_DBTables.m_con!=null)
                            {
                                return DB_for_Tangenta.m_DBTables.m_con.DataBase;
                            }
                        }
                    }
                    return null;
                }
        }

        public static string ServerType
        {
            get { return DB_for_Tangenta.m_DBTables.m_con.ServerType; }
        }

        public static string DataSource
        {
            get
            {
                if (DB_for_Tangenta.m_DBTables.m_con.DBType == DBConnection.eDBType.SQLITE)
                {
                    return DB_for_Tangenta.m_DBTables.m_con.DataBaseFilePath + "\\" + DB_for_Tangenta.m_DBTables.m_con.DataBaseName;
                }
                else
                {
                    return DB_for_Tangenta.m_DBTables.m_con.DataSource;
                }
            }
        }

        public static string DataBase_BackupTemp
        {
            get { return DB_for_Tangenta.m_DBTables.m_con.DataBase_BackupTemp; }
        }

        public static bool ReadDataTable(ref DataTable dt,string sql,ref string Err)
        {
            return DB_for_Tangenta.m_DBTables.m_con.ReadDataTable(ref dt, sql, ref Err);
        }


        public static bool DB_for_Tangenta_SessionConnect(ref string Err)
        {
            return DB_for_Tangenta.m_DBTables.m_con.SessionConnect(ref Err);
        }

        public static bool DB_for_Tangenta_SessionDisconnect()
        {
            if (DB_for_Tangenta!=null)
            {
                if (DB_for_Tangenta.m_DBTables!=null)
                {
                    if (DB_for_Tangenta.m_DBTables.m_con!=null)
                    {
                        return DB_for_Tangenta.m_DBTables.m_con.SessionDisconnect();
                    }
                }
            }
            return true;
        }


        public static bool ReadDataTable(ref DataTable dt, string sql,List<SQL_Parameter> lpar, ref string Err)
        {
            return DB_for_Tangenta.m_DBTables.m_con.ReadDataTable(ref dt, sql,lpar, ref Err);
        }

        public static bool ExecuteNonQuerySQL(string sql, List<SQL_Parameter> lpar,ref string Err)
        {
            return DB_for_Tangenta.m_DBTables.m_con.ExecuteNonQuerySQL(sql, lpar, ref Err);
        }

        public static bool ExecuteNonQuerySQL_NoMultiTrans(string sql, List<SQL_Parameter> lpar,ref string Err)
        {
            return DB_for_Tangenta.m_DBTables.m_con.ExecuteNonQuerySQL(sql, lpar, ref Err);
        }
        

        public static bool ExecuteNonQuerySQLReturnID(string sql, List<SQL_Parameter> lpar, ref ID id,  ref string Err, string sTableName)
        {
            return DB_for_Tangenta.m_DBTables.m_con.ExecuteNonQuerySQLReturnID(sql, lpar, ref id, ref Err, sTableName);
        }

        public static bool CreateTables(string[] new_tables,ref string Err)
        {
            Err = null;
            foreach (string stbl in new_tables)
            {
                string err = null;
                SQLTable tbl = DB_for_Tangenta.m_DBTables.GetTable(stbl);
                if (tbl != null)
                {
                    if (DB_for_Tangenta.m_DBTables.m_con.ExecuteNonQuerySQL(tbl.sql_CreateTable,null, ref err))
                    {
                        continue;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:DBSync:DBSync:CreateTables:sql=" + tbl.sql_CreateTable + "\r\nErr=" + Err);
                        Err = err;
                        return false;
                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:DBSync:DBSync:CreateTables:Table " + stbl + " not found in m_DBTables.items !");
                    Err = err;
                    return false;
                }
            }
            return true;
        }

        public static bool Startup_03_Check_DBConnection_Is_RemotelDB_data_DataBase_Defined(bool bReset,string IniFileFolder, string inifile_prefix, string default_DataBase_name)
        {
            if (DBSync.RemoteDB_data == null)
            {
                DBSync.RemoteDB_data = new RemoteDB_data(bReset, inifile_prefix, 1, m_DBType, default_DataBase_name);
            }
            if (DBSync.RemoteDB_data.DataBase!=null)
            {
                if (DBSync.RemoteDB_data.DataBase.Length>0)
                {
                    return true;
                }
            }
            return false;
        }

     

        public static bool Get(Form parent,bool bReset, ref string Err, ref string inifile_prefix, string default_DataBase_name, ref bool bNewDataBaseCreated,NavigationButtons.Navigation nav, ref bool bCanceled)
        {
            if (DBSync.RemoteDB_data == null)
            {
                DBSync.RemoteDB_data = new RemoteDB_data(bReset,inifile_prefix, 1, m_DBType, default_DataBase_name);
            }


            if (DBSync.DB_for_Tangenta.m_DBTables.MakeDataBaseConnection(parent, DBSync.RemoteDB_data, ref bNewDataBaseCreated, nav, ref bCanceled, MyDataBase_Tangenta.VERSION))
            {
                if (!DBSync.RemoteDB_data.Save(inifile_prefix, ref Err))
                {
                    LogFile.Error.Show(Err);
                }
                return true;
            }
            else
            {
                if (bCanceled)
                {
                    return false;
                }
                else
                {
                    Err = lng.s_ConnectionToLocalDatabaseFailed.s;
                    LogFile.Error.Show(Err);
                    return false;
                }
            }

        }

        public static string sTop(int p)
        {
            if (m_DBType == DBConnection.eDBType.MSSQL)
            {
                return " TOP " + p.ToString() + " ";
            }
            else
            {
                return "";
            }
        }

        public static string sLimit(int p)
        {
            if (m_DBType == DBConnection.eDBType.MSSQL)
            {
                return "";
            }
            else
            {
                return " limit " + p.ToString() + " ";
            }

        }

        public static bool TableExists(string table_name, ref string err)
        {
            return DB_for_Tangenta.m_DBTables.m_con.TableExists(table_name, ref err);
        }
    }
}
