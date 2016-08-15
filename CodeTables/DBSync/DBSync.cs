﻿#region LICENSE 
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


        public static bool Init(Form parentform,
                                ref Form ChildForm,
                                bool bReset, 
                                string m_XmlFileName, 
                                string IniFileFolder, 
                                ref string DataBaseType,
                                bool bShowDialog,
                                bool bChangeConnection,
                                Image xImage_Cancel,
                                ref bool bNewDatabaseCreated,
                                ref bool bCanceled)
        {
            string Err = null;
            if (DB_for_Tangenta == null)
            {
                DB_for_Tangenta = new TangentaDataBaseDef.MyDataBase_Tangenta(parentform, m_XmlFileName, IniFileFolder);
            }
            DBConnection.eDBType org_m_DBType = m_DBType; 
            m_DBType = Get_DBType(parentform,ref ChildForm, ref DataBaseType, xImage_Cancel,  bShowDialog, ref bCanceled);
            if (bCanceled)
            {
                return false;
            }
            DB_for_Tangenta.Init(m_DBType);

            if (DBSync.m_DBType == DBConnection.eDBType.SQLITE)
            {
                my_StartupWindowThread.Message(lngRPM.s_CheckLocalDatabase.s + m_SQLite_Support.sGetLocalDB());

                if (m_SQLite_Support.Get(parentform, bReset, ref Err, ref IniFileFolder, IniFileFolder, "TangentaDB", bChangeConnection, ref bNewDatabaseCreated, xImage_Cancel, ref bCanceled))
                {
                    my_StartupWindowThread.Message(lngRPM.s_LocalDatabase_OK.s + m_SQLite_Support.sGetLocalDB());
                    return true;
                }
                else
                {
                    if (!bCanceled)
                    {
                        LogFile.Error.Show(lngRPM.s_CanNotReadDataBaseFile.s + " Err=" + Err);
                    }
                    return false;
                }
            }
            else
            {
                my_StartupWindowThread.Message(lngRPM.s_DataBaseFile.s);
                if (Get(parentform,bReset, ref Err, ref IniFileFolder, "TangentaDB",ref bNewDatabaseCreated, xImage_Cancel, ref bCanceled))
                {
                    my_StartupWindowThread.Message(lngRPM.s_LocalDatabase_OK.s + m_SQLite_Support.sGetLocalDB());
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


        public static Form_DBmanager.eResult DBMan(Form parentform,bool bReset, string m_XmlFileName, string IniFileFolder, ref string DataBaseType,ref string xBackupFolder,Image xImage_Cancel)
        {
            m_BackupFolder = xBackupFolder;
            Form_DBmanager dbman_dlg = new Form_DBmanager(parentform, bReset, m_XmlFileName, IniFileFolder, DataBaseType,m_BackupFolder, DB_for_Tangenta.Settings.Version.TextValue, xImage_Cancel);
            dbman_dlg.ShowDialog();
            m_BackupFolder = dbman_dlg.m_BackupFolder;
            xBackupFolder = m_BackupFolder;
            DataBaseType = dbman_dlg.m_DataBaseType;
            return dbman_dlg.m_Result;
        }



        private static DBConnection.eDBType Get_DBType(Form parentForm,ref Form GetDBType_dlg, ref string DataBaseType, Image xImage_Cancel, bool bShowDialog, ref bool bCanceled)
        {
            if (!bShowDialog)
            {
                if (DataBaseType != null)
                {
                    if (DataBaseType.Equals("SQLITE"))
                    {
                        return DBConnection.eDBType.SQLITE;
                    }
                    else if (DataBaseType.Equals("MSSQL"))
                    {
                        return DBConnection.eDBType.MSSQL;
                    }
                }
            }

            if (DataBaseType == null)
            {
                DataBaseType = "SQLITE";
            }

            GetDBType_dlg = new Form_GetDBType(DataBaseType, xImage_Cancel);
            if (parentForm != null)
            {
                GetDBType_dlg.StartPosition = FormStartPosition.CenterScreen;
                GetDBType_dlg.TopMost = true;
                GetDBType_dlg.Visible = true;
                GetDBType_dlg.Show();
                while (((Form_GetDBType)GetDBType_dlg).dlgRes==DialogResult.None)
                {
                    Application.DoEvents();
                }
            }
            else
            {
                GetDBType_dlg.ShowDialog();
            }
            if (((Form_GetDBType)GetDBType_dlg).dlgRes == DialogResult.OK)
            {
                switch (((Form_GetDBType)GetDBType_dlg).m_DBType)
                {
                    case DBConnection.eDBType.SQLITE:
                        DataBaseType = "SQLITE";
                        break;
                    case DBConnection.eDBType.MSSQL:
                        DataBaseType = "MSSQL";
                        break;
                    case DBConnection.eDBType.MYSQL:
                        DataBaseType = "MYSQL";
                        break;
                }
                return ((Form_GetDBType)GetDBType_dlg).m_DBType;
            }
            else
            {
                bCanceled = true;
                return m_DBType;
            }

        }

        public static string DataBase
        {
            get { return DB_for_Tangenta.m_DBTables.m_con.DataBase; }
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
                    return DB_for_Tangenta.m_DBTables.m_con.Settings_LocalDB.LocalDB_DataBaseFilePath() + "\\" + DB_for_Tangenta.m_DBTables.m_con.Settings_LocalDB.LocalDB_DataBaseFileName();
                }
                else
                {
                    return DB_for_Tangenta.m_DBTables.m_con.Settings_RemoteDB.DataSource();
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

        public static bool ReadDataTable(ref DataTable dt, string sql,List<SQL_Parameter> lpar, ref string Err)
        {
            return DB_for_Tangenta.m_DBTables.m_con.ReadDataTable(ref dt, sql,lpar, ref Err);
        }

        public static bool ExecuteNonQuerySQL(string sql, List<SQL_Parameter> lpar,ref object ores,ref string Err)
        {
            return DB_for_Tangenta.m_DBTables.m_con.ExecuteNonQuerySQL(sql, lpar, ref ores, ref Err);
        }

        public static bool ExecuteNonQuerySQL_NoMultiTrans(string sql, List<SQL_Parameter> lpar,ref string Err)
        {
            return DB_for_Tangenta.m_DBTables.m_con.ExecuteNonQuerySQL_NoMultiTrans(sql, lpar, ref Err);
        }
        

        public static bool ExecuteNonQuerySQLReturnID(string sql, List<SQL_Parameter> lpar, ref long id, ref object oret, ref string Err, string sTableName)
        {
            return DB_for_Tangenta.m_DBTables.m_con.ExecuteNonQuerySQLReturnID(sql, lpar, ref id, ref oret, ref Err, sTableName);
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
                    if (DB_for_Tangenta.m_DBTables.m_con.ExecuteNonQuerySQL_NoMultiTrans(tbl.sql_CreateTable,null, ref err))
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

        public static bool Get(Form parent,bool bReset, ref string Err, ref string inifile_prefix, string default_DataBase_name, ref bool bNewDataBaseCreated,Image xImageCancel, ref bool bCanceled)
        {
            if (DBSync.RemoteDB_data == null)
            {
                DBSync.RemoteDB_data = new RemoteDB_data(bReset,inifile_prefix, 1, m_DBType, default_DataBase_name);
            }


            if (DBSync.DB_for_Tangenta.m_DBTables.MakeDataBaseConnection(parent, DBSync.RemoteDB_data, ref bNewDataBaseCreated, xImageCancel, ref bCanceled))
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
                    Err = lngRPM.s_ConnectionToLocalDatabaseFailed.s;
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
