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
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace DBSync
{
    public class SQLite_Support
    {
        NavigationButtons.Navigation nav = null;

        public SQLite_Support()
        {
        }

        internal static bool FolderExists(string IniFileFolder)
        {
            if (IniFileFolder.Length > 0)
            {
                return Directory.Exists(IniFileFolder);
            }
            return false;
        }

        public bool Check_DataBaseConnection(bool bReset, string inifile_prefix, string DataBaseName, ref bool bNewDataBaseCreated, ref bool bCanceled, string dbVersion)
        {
            if (DBSync.LocalDB_data_SQLite == null)
            {
                DBSync.LocalDB_data_SQLite = new LocalDB_data(bReset, inifile_prefix, 1, DataBaseName, false);
            }
            string Err = null;
            Transaction transaction_Check_DataBaseConnection_MakeDataBaseConnection = new Transaction("Check_DataBaseConnection.MakeDataBaseConnection");
            if (DBSync.DB_for_Tangenta.m_DBTables.MakeDataBaseConnection(nav.parentForm, DBSync.LocalDB_data_SQLite, ref bNewDataBaseCreated, nav, ref bCanceled, dbVersion, transaction_Check_DataBaseConnection_MakeDataBaseConnection))
            {
                if (transaction_Check_DataBaseConnection_MakeDataBaseConnection.Commit())
                {
                    if (!DBSync.LocalDB_data_SQLite.Save(inifile_prefix, ref Err))
                    {
                        LogFile.Error.Show(Err);
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                transaction_Check_DataBaseConnection_MakeDataBaseConnection.Rollback();
                if (bCanceled)
                {
                    Err = null;
                }
                else
                {
                    Err = lng.s_ConnectionToLocalDatabaseFailed.s;
                }
                return false;
            }
        }

        public bool Evaluate_Connection(NavigationButtons.Navigation nav,
                                        ref bool bNewDataBaseCreated,
                                        ref bool bCanceled,
                                        string dbVersion,
                                        Transaction transaction)
        {
            return DBSync.DB_for_Tangenta.m_DBTables.Evaluate_DataBaseConnection(nav.parentForm, DBSync.LocalDB_data_SQLite, ref bNewDataBaseCreated, nav, ref bCanceled, dbVersion, transaction);
        }

        public bool Startup_03_Check_DBConnection_Is_LocalDB_data_SQLite_DataBaseFileName_Defined(bool bReset,ref string IniFileFolder,string inifile_prefix,string Connection_Name)
        {
            //IniFolder should be defined in previous step
            if (!FolderExists(IniFileFolder))
            {
                IniFileFolder = Application.UserAppDataPath;
                if (!IniFileFolder.EndsWith("\\"))
                {
                    IniFileFolder += '\\';
                }
            }

            if (DBSync.LocalDB_data_SQLite == null)
            {
                DBSync.LocalDB_data_SQLite = new LocalDB_data(bReset, inifile_prefix, 1, Connection_Name, false);
            }

            if (DBSync.LocalDB_data_SQLite.DataBaseFileName != null)
            {
                if (DBSync.LocalDB_data_SQLite.DataBaseFileName.Length > 0)
                {
                    DBSync.Con.DataBaseName = DBSync.LocalDB_data_SQLite.DataBaseFilePath + DBSync.LocalDB_data_SQLite.DataBaseFileName;
                    return true; //LocalDB_data.SQLite_DataBaseFileName is defined 
                }
            }
            return false; //LocalDB_data.SQLite_DataBaseFileName is not defined
    }

        public bool Startup_03_Undo_DBConnection()
        {

            DBSync.LocalDB_data_SQLite = null;
            return false; //LocalDB_data.SQLite_DataBaseFileName is not defined
        }

        public bool Get(bool bReset, ref string Err, ref string IniFileFolder, string inifile_prefix, string DataBaseName, bool bChangeConnection, ref bool bNewDataBaseCreated, NavigationButtons.Navigation xnav, ref bool bCanceled, string dbVersion)
        {

            //string IniFileFolder = Settings.IniFileFolder;
            //string IniFileFolder = Properties.Settings.Default.IniFileFolder;
            nav = xnav;

            if (!FolderExists(IniFileFolder))
            {
                IniFileFolder = Application.UserAppDataPath;
                if (!IniFileFolder.EndsWith("\\"))
                {
                    IniFileFolder += '\\';
                }
            }

            if (bNewDataBaseCreated)
            {
                if (xnav.LastStartupDialog_TYPE.Equals("Tangenta.Form_DBSettings"))
                {
                    DBSync.LocalDB_data_SQLite = null;
                }
            }

            if (DBSync.LocalDB_data_SQLite == null)
            {
                DBSync.LocalDB_data_SQLite = new LocalDB_data(bReset,inifile_prefix, 1, DataBaseName, false);
            }

            if (bChangeConnection)
            {
                Transaction transaction_CreateNewDataBaseConnection = new Transaction("CreateNewDataBaseConnection");
                if (DBSync.DB_for_Tangenta.m_DBTables.CreateNewDataBaseConnection(DBSync.LocalDB_data_SQLite,true, nav, ref bCanceled, dbVersion, transaction_CreateNewDataBaseConnection))
                {
                    if (transaction_CreateNewDataBaseConnection.Commit())
                    {
                        bNewDataBaseCreated = true;
                        if (!DBSync.LocalDB_data_SQLite.Save(inifile_prefix, ref Err))
                        {
                            LogFile.Error.Show(Err);
                        }
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    transaction_CreateNewDataBaseConnection.Rollback();
                    if (bCanceled)
                    {
                        Err = null;
                    }
                    else
                    {
                        Err = lng.s_ConnectionToLocalDatabaseFailed.s;
                    }
                    return false;
                }
            }
            else
            {
                Transaction transaction_MakeDataBaseConnection = new Transaction("MakeDataBaseConnection");
                if (DBSync.DB_for_Tangenta.m_DBTables.MakeDataBaseConnection(nav.parentForm, DBSync.LocalDB_data_SQLite, ref bNewDataBaseCreated, nav, ref bCanceled, dbVersion, transaction_MakeDataBaseConnection))
                {
                    if (transaction_MakeDataBaseConnection.Commit())
                    {
                        if (!DBSync.LocalDB_data_SQLite.Save(inifile_prefix, ref Err))
                        {
                            LogFile.Error.Show(Err);
                        }
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    transaction_MakeDataBaseConnection.Rollback();
                    if (bCanceled)
                    {
                        Err = null;
                    }
                    else
                    {
                        Err = lng.s_ConnectionToLocalDatabaseFailed.s;
                    }
                    return false;
                }
            }
        }



        public string sGetLocalDB()
        {
            string slocDB = "";
            if (DBSync.LocalDB_data_SQLite != null)
            {
                if (DBSync.LocalDB_data_SQLite.DataBaseFileName != null)
                {
                    if (DBSync.LocalDB_data_SQLite.DataBaseFilePath != null)
                    {
                        slocDB = DBSync.LocalDB_data_SQLite.DataBaseFilePath + "\\" + DBSync.LocalDB_data_SQLite.DataBaseFileName;
                    }
                    else
                    {
                        slocDB = DBSync.LocalDB_data_SQLite.DataBaseFileName;
                    }
                }
            }
            return slocDB;
        }

    }
}
