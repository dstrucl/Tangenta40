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

        public bool Get(Form MainForm,bool bReset, ref string Err, ref string IniFileFolder, string inifile_prefix, string DataBaseName, bool bChangeConnection, ref bool bNewDataBaseCreated,Image xImageCancel, ref bool bCanceled)
        {

            //string IniFileFolder = Settings.IniFileFolder;
            //string IniFileFolder = Properties.Settings.Default.IniFileFolder;
            bNewDataBaseCreated = false;
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
                DBSync.LocalDB_data_SQLite = new LocalDB_data(bReset,inifile_prefix, 1, DataBaseName, false);
            }

            if (bChangeConnection)
            {
                if (DBSync.DB_for_Tangenta.m_DBTables.CreateNewDataBaseConnection(MainForm, DBSync.LocalDB_data_SQLite,true, xImageCancel, ref bCanceled))
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
                    if (bCanceled)
                    {
                        Err = null;
                    }
                    else
                    {
                        Err = lngRPM.s_ConnectionToLocalDatabaseFailed.s;
                    }
                    return false;
                }
            }
            else
            { 
                if (DBSync.DB_for_Tangenta.m_DBTables.MakeDataBaseConnection(MainForm, DBSync.LocalDB_data_SQLite, ref bNewDataBaseCreated, xImageCancel, ref bCanceled))
                {
                    if (!DBSync.LocalDB_data_SQLite.Save(inifile_prefix, ref Err))
                    {
                        LogFile.Error.Show(Err);
                    }
                    return true;
                }
                else
                {
                    if (bCanceled)
                    {
                        Err = null;
                    }
                    else
                    {
                        Err = lngRPM.s_ConnectionToLocalDatabaseFailed.s;
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
