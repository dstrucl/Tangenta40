using BlagajnaDataBaseDef;
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

        public bool Get(Form MainForm, ref string Err, ref string IniFileFolder, string inifile_prefix, string DataBaseName, bool bChangeConnection)
        {

            //string IniFileFolder = Settings.IniFileFolder;
            //string IniFileFolder = Properties.Settings.Default.IniFileFolder;
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
                DBSync.LocalDB_data_SQLite = new LocalDB_data(inifile_prefix, 1, DataBaseName, false);
            }

            if (bChangeConnection)
            {
                if (DBSync.DB_for_Blagajna.m_DBTables.CreateNewDataBaseConnection(MainForm, DBSync.LocalDB_data_SQLite,true))
                {
                    if (!DBSync.LocalDB_data_SQLite.Save(inifile_prefix, ref Err))
                    {
                        LogFile.Error.Show(Err);
                    }
                    return true;
                }
                else
                {
                    Err = lngRPM.s_ConnectionToLocalDatabaseFailed.s;
                    return false;
                }
            }
            else
            { 
                if (DBSync.DB_for_Blagajna.m_DBTables.MakeDataBaseConnection(MainForm, DBSync.LocalDB_data_SQLite))
                {
                    if (!DBSync.LocalDB_data_SQLite.Save(inifile_prefix, ref Err))
                    {
                        LogFile.Error.Show(Err);
                    }
                    return true;
                }
                else
                {
                    Err = lngRPM.s_ConnectionToLocalDatabaseFailed.s;
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
