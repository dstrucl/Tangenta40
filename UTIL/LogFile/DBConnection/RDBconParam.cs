
namespace LogFile
{
    public class Log_RemoteDB_data
    {
        public Settings_RemoteDB m_Settings_RemoteDB = null; 

        public string ConnectionName;

        private int Settings_Index;
        public bool bChanged = false;
        public bool bNewDatabase = false;
        public Log_DBConnection.eDBType DBType;
        public bool bWindowsAuthentication;
        public string DataSource;
        public string DataBase;
        public string UserName;
        public string crypted_Password;
        public string strDataBaseFilePath;
        public string strDataBaseLogFilePath;

        public Log_RemoteDB_data(string inifile_prefix,int i, Log_DBConnection.eDBType xDBType, string xConnectionName)
        {
            ConnectionName = xConnectionName;
            DBType = xDBType;
            Settings_Index = i;
            m_Settings_RemoteDB = new Settings_RemoteDB(inifile_prefix, Settings_Index);
            ReadSettings();
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

        public void ReadSettings()
        {
            string Err = null;
            if (m_Settings_RemoteDB.Load(ref Err))
            {
                DBType = (Log_DBConnection.eDBType)m_Settings_RemoteDB.DBType();
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
                Error.Show("ERROR:Log_RemoteDB_data:Settings not read !");
            }
            
        }


        public Log_RemoteDB_data Clone()
        {
            Log_RemoteDB_data new_RemoteDB_data = new Log_RemoteDB_data(this.m_Settings_RemoteDB.m_inifile_prefix, this.Settings_Index, this.DBType, this.ConnectionName);
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

    public class Log_LocalDB_data
    {
        public Log_Settings_LocalDB m_Settings_LocalDB = null;

        public string ConnectionName;

        private int Settings_Index;

        public bool bChanged = false;
        public bool bNewDatabase = false;
        public string DataBaseFilePath;
        public string DataBaseFileName;
        public string crypted_Password;

        public bool bAllwaysCreateNew = false;

        public Log_LocalDB_data(string inifile_prefix,int instance, string xConnectionName, bool xAllwaysCreateNew)
        {
            Settings_Index = instance;
            ConnectionName = xConnectionName;
            bAllwaysCreateNew = xAllwaysCreateNew;
            m_Settings_LocalDB = new Log_Settings_LocalDB(inifile_prefix, Settings_Index);
            ReadSettings();
        }

        private void ReadSettings()
        {
            string Err = null;
            if (m_Settings_LocalDB.Load(ref Err))
            {
                DataBaseFileName = m_Settings_LocalDB.LocalDB_DataBaseFileName();
                DataBaseFilePath = m_Settings_LocalDB.LocalDB_DataBaseFilePath();
                crypted_Password = m_Settings_LocalDB.LocalDB_crypted_Password();
                bChanged = false;
            }
            else
            {
                Error.Show(Err);
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