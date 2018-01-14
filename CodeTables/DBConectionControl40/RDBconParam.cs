#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion
using DBConnectionControl_Settings;
namespace DBConnectionControl40
{
    public class RemoteDB_data
    {
        public DBConnectionControl_Settings.Settings_RemoteDB m_Settings_RemoteDB = null; 

        public string ConnectionName;

        private int Settings_Index;
        public bool bChanged = false;
        public bool bNewDatabase = false;
        public DBConnection.eDBType DBType;
        public bool bWindowsAuthentication;
        public string DataSource;
        public string DataBase;
        public string UserName;
        public string crypted_Password;
        public string strDataBaseFilePath;
        public string strDataBaseLogFilePath;

        public RemoteDB_data(bool bReset,string inifile_prefix,int i, DBConnection.eDBType xDBType, string xConnectionName)
        {
            ConnectionName = xConnectionName;
            DBType = xDBType;
            Settings_Index = i;
            m_Settings_RemoteDB = new DBConnectionControl_Settings.Settings_RemoteDB(inifile_prefix, Settings_Index);
            ReadSettings(bReset);
        }

        public bool Save(string infile_prefix,ref string Err)
        {

            bool bres = true;
            if (bChanged)
            {
                bres = m_Settings_RemoteDB.Save(
                        (uint)DBType, 
                        bWindowsAuthentication, 
                        DataSource, 
                        DataBase, 
                        UserName, 
                        crypted_Password, 
                        strDataBaseFilePath, 
                        strDataBaseLogFilePath,
                        ref Err);
                bChanged = false;
            }
            return bres;
        }

        public void ReadSettings(bool bReset)
        {
            string Err = null;
            if (m_Settings_RemoteDB.Load(bReset,ref Err))
            {
                DBType = (DBConnection.eDBType)m_Settings_RemoteDB.DBType();
                bWindowsAuthentication = m_Settings_RemoteDB.bWindowsAuthentication();
                DataSource = m_Settings_RemoteDB.DataSource();
                DataBase = m_Settings_RemoteDB.DataBase();
                UserName = m_Settings_RemoteDB.UserName();
                crypted_Password = m_Settings_RemoteDB.crypted_Password();
                strDataBaseFilePath = m_Settings_RemoteDB.strDataBaseFilePath();
                strDataBaseLogFilePath = m_Settings_RemoteDB.strDataBaseLogFilePath();
                bChanged = false;
            }
            else
            {
                LogFile.Error.Show("ERROR:RemoteDB_data:Settings not read !");
            }
            
        }


        public RemoteDB_data Clone()
        {
            RemoteDB_data new_RemoteDB_data = new RemoteDB_data(false,this.m_Settings_RemoteDB.m_inifile_prefix, this.Settings_Index, this.DBType, this.ConnectionName);
            new_RemoteDB_data.bChanged = this.bChanged;
            new_RemoteDB_data.bNewDatabase = this.bChanged;
            new_RemoteDB_data.bWindowsAuthentication = this.bWindowsAuthentication;
            new_RemoteDB_data.DataSource = this.DataSource;
            new_RemoteDB_data.DataBase = this.DataBase;
            new_RemoteDB_data.crypted_Password = this.crypted_Password;
            new_RemoteDB_data.DBType = this.DBType;
            new_RemoteDB_data.ConnectionName = this.ConnectionName;
            new_RemoteDB_data.UserName = this.UserName;
            new_RemoteDB_data.Settings_Index = this.Settings_Index;
            new_RemoteDB_data.strDataBaseFilePath = this.strDataBaseFilePath;
            new_RemoteDB_data.strDataBaseLogFilePath = this.strDataBaseLogFilePath;
            return new_RemoteDB_data;
        }
    }

    public class LocalDB_data
    {
        public DBConnectionControl_Settings.Settings_LocalDB m_Settings_LocalDB = null;

        public string ConnectionName;

        private int Settings_Index;

        public bool bChanged = false;
        public bool bNewDatabase = false;
        public string DataBaseFilePath;
        public string DataBaseFileName;
        public string crypted_Password;

        public bool bAllwaysCreateNew = false;

        public LocalDB_data(bool bReset,string inifile_prefix,int instance, string xConnectionName, bool xAllwaysCreateNew)
        {
            Settings_Index = instance;
            ConnectionName = xConnectionName;
            bAllwaysCreateNew = xAllwaysCreateNew;
            m_Settings_LocalDB = new Settings_LocalDB(inifile_prefix, Settings_Index);
            ReadSettings(bReset);
        }

        private bool ReadSettings(bool bReset)
        {
            string Err = null;
            if (m_Settings_LocalDB.Load(bReset,ref Err))
            {
                DataBaseFileName = m_Settings_LocalDB.LocalDB_DataBaseFileName();
                DataBaseFilePath = m_Settings_LocalDB.LocalDB_DataBaseFilePath();
                crypted_Password = m_Settings_LocalDB.LocalDB_crypted_Password();
                bChanged = false;
                return true;
            }
            else
            {
                LogFile.Error.Show(Err);
                return false;
            }
        }

        public bool Save(string inifile_prefix,ref string Err)
        {
            bool bres = true;
            if (bChanged)
            {
                m_Settings_LocalDB.LocalDB_DataBaseFilePath(DataBaseFilePath);
                m_Settings_LocalDB.LocalDB_DataBaseFileName(DataBaseFileName);
                m_Settings_LocalDB.LocalDB_crypted_Password(crypted_Password);
                bres = m_Settings_LocalDB.Save(ref Err);
                bChanged = false;
            }
            return bres;
        }
     
    }
}