using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace DBConnectionControl_Settings
{
    public class Settings_RemoteDB
    {
        public const string const_default_ini_file_name = "DBConnectionControl_RemoteDB.ini";
        public const string const_section_prefix_RemoteDB_ = "RemoteDB_";
        public int m_SettingsIndex = -1;

        public string m_inifile_prefix = null;

        public const string const_uiRemoteDB_uiDataBaseType = "uiRemoteDB_uiDataBaseType";
        public const string const_bRemoteDB_bWindowsAuthentication = "bRemoteDB_bWindowsAuthentication";
        public const string const_sRemoteDB_DataSource ="sRemoteDB_DataSource";
        public const string const_sRemoteDB_DataBase= "sRemoteDB_DataBase";
        public const string const_sRemoteDB_UserName = "sRemoteDB_UserName";
        public const string const_sRemoteDB_Password = "sRemoteDB_Password";
        public const string const_sRemoteDB_strDataBaseFilePath = "sRemoteDB_strDataBaseFilePath";
        public const string const_sRemoteDB_strDataBaseLogFilePath ="sRemoteDB_strDataBaseLogFilePath";
        public const string const_iRemoteDB_TryToConnectTimeout_in_seconds = "iRemoteDB_TryToConnectTimeout_in_seconds";


        public enum eType { Properties_Settings_Default, IniFile_Setting};
        public eType m_eType = eType.IniFile_Setting;

        private  uint uiRemoteDB_uiDataBaseType;
        private  bool bRemoteDB_bWindowsAuthentication;
        private  string sRemoteDB_DataSource;
        private  string sRemoteDB_DataBase;
        private  string sRemoteDB_UserName;
        private  string sRemoteDB_Password;
        private  string sRemoteDB_strDataBaseFilePath;
        private  string sRemoteDB_strDataBaseLogFilePath;
        private  int iRemoteDB_TryToConnectTimeout_in_seconds;

        public  eType TYPE
        {
            get
            {
                return m_eType;
            }
            set
            {
                m_eType = value;
            }
        }

        public Settings_RemoteDB(string x_inifile_prefix,int xSettingsIndex)
        {
            m_SettingsIndex = xSettingsIndex;
            m_inifile_prefix = x_inifile_prefix;
        }

        private  void Init()
        {
            uiRemoteDB_uiDataBaseType = 0;
            bRemoteDB_bWindowsAuthentication = false;
            sRemoteDB_DataSource = "";
            sRemoteDB_DataBase = "";
            sRemoteDB_UserName = "";
            sRemoteDB_Password = "";
            sRemoteDB_strDataBaseFilePath = "";
            sRemoteDB_strDataBaseLogFilePath = "";
            iRemoteDB_TryToConnectTimeout_in_seconds = 40;
        }

        private  bool SectionExistsInIniFile()
        {
            if (File.Exists(IniFile.IniFile.path))
            {
               // int i;
                string section = null;
                section = m_inifile_prefix + const_section_prefix_RemoteDB_ + m_SettingsIndex.ToString();
                if (!IniFile.IniFile.Check_Section_And_Key(section, const_uiRemoteDB_uiDataBaseType))
                {
                    return false;
                }
                if (!IniFile.IniFile.Check_Section_And_Key(section, const_bRemoteDB_bWindowsAuthentication))
                {
                    return false;
                }
                if (!IniFile.IniFile.Check_Section_And_Key(section, const_sRemoteDB_DataSource))
                {
                    return false;
                }

                if (!IniFile.IniFile.Check_Section_And_Key(section, const_sRemoteDB_DataBase))
                {
                    return false;
                }
                if (!IniFile.IniFile.Check_Section_And_Key(section, const_sRemoteDB_UserName))
                {
                    return false;
                }
                if (!IniFile.IniFile.Check_Section_And_Key(section, const_sRemoteDB_Password))
                {
                    return false;
                }
                if (!IniFile.IniFile.Check_Section_And_Key(section, const_sRemoteDB_strDataBaseFilePath))
                {
                    return false;
                }
                if (!IniFile.IniFile.Check_Section_And_Key(section, const_sRemoteDB_strDataBaseLogFilePath))
                {
                    return false;
                }
                if (!IniFile.IniFile.Check_Section_And_Key(section, const_iRemoteDB_TryToConnectTimeout_in_seconds))
                {
                    return false;
                }

                return true;
            }
            else
            {
                return false;
            }
        }


        public  bool Load(ref string Err)
        {
            switch (m_eType)
            {
                case eType.Properties_Settings_Default:
                    switch (m_SettingsIndex)
                    {
                        case 0:
                            uiRemoteDB_uiDataBaseType = Properties.RemoteDB1.Default.RemoteDB_uiDataBaseType;
                            sRemoteDB_DataSource = Properties.RemoteDB1.Default.RemoteDB_DataSource;
                            sRemoteDB_DataBase = Properties.RemoteDB1.Default.RemoteDB_DataBase;
                            sRemoteDB_UserName = Properties.RemoteDB1.Default.RemoteDB_UserName;
                            sRemoteDB_Password = Properties.RemoteDB1.Default.RemoteDB_Password;
                            sRemoteDB_strDataBaseFilePath = Properties.RemoteDB1.Default.RemoteDB_strDataBaseFilePath;
                            sRemoteDB_strDataBaseLogFilePath = Properties.RemoteDB1.Default.RemoteDB_strDataBaseLogFilePath;
                            iRemoteDB_TryToConnectTimeout_in_seconds = Properties.RemoteDB1.Default.RemoteDB_TryToConnectTimeout_in_seconds;
                            break;
                        case 1:
                            uiRemoteDB_uiDataBaseType = Properties.RemoteDB2.Default.RemoteDB_uiDataBaseType;
                            sRemoteDB_DataSource = Properties.RemoteDB2.Default.RemoteDB_DataSource;
                            sRemoteDB_DataBase = Properties.RemoteDB2.Default.RemoteDB_DataBase;
                            sRemoteDB_UserName = Properties.RemoteDB2.Default.RemoteDB_UserName;
                            sRemoteDB_Password = Properties.RemoteDB2.Default.RemoteDB_Password;
                            sRemoteDB_strDataBaseFilePath = Properties.RemoteDB2.Default.RemoteDB_strDataBaseFilePath;
                            sRemoteDB_strDataBaseLogFilePath = Properties.RemoteDB2.Default.RemoteDB_strDataBaseLogFilePath;
                            iRemoteDB_TryToConnectTimeout_in_seconds = Properties.RemoteDB2.Default.RemoteDB_TryToConnectTimeout_in_seconds;
                            break;
                        case 2:
                            uiRemoteDB_uiDataBaseType = Properties.RemoteDB3.Default.RemoteDB_uiDataBaseType;
                            sRemoteDB_DataSource = Properties.RemoteDB3.Default.RemoteDB_DataSource;
                            sRemoteDB_DataBase = Properties.RemoteDB3.Default.RemoteDB_DataBase;
                            sRemoteDB_UserName = Properties.RemoteDB3.Default.RemoteDB_UserName;
                            sRemoteDB_Password = Properties.RemoteDB3.Default.RemoteDB_Password;
                            sRemoteDB_strDataBaseFilePath = Properties.RemoteDB3.Default.RemoteDB_strDataBaseFilePath;
                            sRemoteDB_strDataBaseLogFilePath = Properties.RemoteDB3.Default.RemoteDB_strDataBaseLogFilePath;
                            iRemoteDB_TryToConnectTimeout_in_seconds = Properties.RemoteDB3.Default.RemoteDB_TryToConnectTimeout_in_seconds;
                            break;
                        case 3:
                            uiRemoteDB_uiDataBaseType = Properties.RemoteDB4.Default.RemoteDB_uiDataBaseType;
                            sRemoteDB_DataSource = Properties.RemoteDB4.Default.RemoteDB_DataSource;
                            sRemoteDB_DataBase = Properties.RemoteDB4.Default.RemoteDB_DataBase;
                            sRemoteDB_UserName = Properties.RemoteDB4.Default.RemoteDB_UserName;
                            sRemoteDB_Password = Properties.RemoteDB4.Default.RemoteDB_Password;
                            sRemoteDB_strDataBaseFilePath = Properties.RemoteDB4.Default.RemoteDB_strDataBaseFilePath;
                            sRemoteDB_strDataBaseLogFilePath = Properties.RemoteDB4.Default.RemoteDB_strDataBaseLogFilePath;
                            iRemoteDB_TryToConnectTimeout_in_seconds = Properties.RemoteDB4.Default.RemoteDB_TryToConnectTimeout_in_seconds;
                            break;
                    }
                    return true;
                //    break;


                case eType.IniFile_Setting:


                    if (IniFile.IniFile.path == null)
                    {
                        string spath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                        int iLen = spath.Length;
                        if (iLen > 0)
                        {
                            if (spath[iLen-1]!='\\')
                            {
                                spath += '\\';
                            }
                        }
                        IniFile.IniFile.path = spath + const_default_ini_file_name;
                    }

                    if (!SectionExistsInIniFile())
                    {
                        Init();
                        if (!Save(ref Err))
                        {
                            return false;
                        }
                    }
                    string section = m_inifile_prefix + const_section_prefix_RemoteDB_;
                    if (SettingsFunc.IniReadValue_UIntArr(section, m_SettingsIndex, ref uiRemoteDB_uiDataBaseType, const_uiRemoteDB_uiDataBaseType, ref Err))
                    {
                        if (SettingsFunc.IniReadValue_BoolArr(section, m_SettingsIndex, ref  bRemoteDB_bWindowsAuthentication, const_bRemoteDB_bWindowsAuthentication, ref Err))
                        {
                            if (SettingsFunc.IniReadValue_StringArr(section, m_SettingsIndex, ref  sRemoteDB_DataSource, const_sRemoteDB_DataSource, ref Err))
                            {
                                if (SettingsFunc.IniReadValue_StringArr(section, m_SettingsIndex, ref sRemoteDB_DataBase, const_sRemoteDB_DataBase, ref Err))
                                {
                                    if (SettingsFunc.IniReadValue_StringArr(section, m_SettingsIndex, ref sRemoteDB_UserName, const_sRemoteDB_UserName, ref Err))
                                    {
                                        if (SettingsFunc.IniReadValue_StringArr(section, m_SettingsIndex, ref  sRemoteDB_Password, const_sRemoteDB_Password, ref Err))
                                        {
                                            if (SettingsFunc.IniReadValue_StringArr(section, m_SettingsIndex, ref sRemoteDB_strDataBaseFilePath, const_sRemoteDB_strDataBaseFilePath, ref Err))
                                            {
                                                if (SettingsFunc.IniReadValue_StringArr(section, m_SettingsIndex, ref  sRemoteDB_strDataBaseLogFilePath, const_sRemoteDB_strDataBaseLogFilePath, ref Err))
                                                {
                                                    if (SettingsFunc.IniReadValue_IntArr(section, m_SettingsIndex, ref  iRemoteDB_TryToConnectTimeout_in_seconds, const_iRemoteDB_TryToConnectTimeout_in_seconds, ref Err))
                                                    {
                                                        return true;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    break;

            }
            return false;
        }



        public  bool Save( ref string Err)
        {
            switch (m_eType)
            {
                case eType.Properties_Settings_Default:
                    switch (m_SettingsIndex)
                    {
                        case 0:
                            Properties.RemoteDB1.Default.RemoteDB_uiDataBaseType = uiRemoteDB_uiDataBaseType;

                            Properties.RemoteDB1.Default.RemoteDB_DataSource = sRemoteDB_DataSource;

                            Properties.RemoteDB1.Default.RemoteDB_DataBase = sRemoteDB_DataBase;

                            Properties.RemoteDB1.Default.RemoteDB_UserName = sRemoteDB_UserName;

                            Properties.RemoteDB1.Default.RemoteDB_Password = sRemoteDB_Password;

                            Properties.RemoteDB1.Default.RemoteDB_strDataBaseFilePath = sRemoteDB_strDataBaseFilePath;

                            Properties.RemoteDB1.Default.RemoteDB_strDataBaseLogFilePath = sRemoteDB_strDataBaseLogFilePath;


                            Properties.RemoteDB1.Default.RemoteDB_TryToConnectTimeout_in_seconds = iRemoteDB_TryToConnectTimeout_in_seconds;

                            Properties.RemoteDB1.Default.Save();
                            break;
                        case 1:
                            Properties.RemoteDB2.Default.RemoteDB_uiDataBaseType = uiRemoteDB_uiDataBaseType;

                            Properties.RemoteDB2.Default.RemoteDB_DataSource = sRemoteDB_DataSource;

                            Properties.RemoteDB2.Default.RemoteDB_DataBase = sRemoteDB_DataBase;

                            Properties.RemoteDB2.Default.RemoteDB_UserName = sRemoteDB_UserName;

                            Properties.RemoteDB2.Default.RemoteDB_Password = sRemoteDB_Password;

                            Properties.RemoteDB2.Default.RemoteDB_strDataBaseFilePath = sRemoteDB_strDataBaseFilePath;

                            Properties.RemoteDB2.Default.RemoteDB_strDataBaseLogFilePath = sRemoteDB_strDataBaseLogFilePath;


                            Properties.RemoteDB2.Default.RemoteDB_TryToConnectTimeout_in_seconds = iRemoteDB_TryToConnectTimeout_in_seconds;

                            Properties.RemoteDB2.Default.Save();
                            break;
                        case 2:
                            Properties.RemoteDB3.Default.RemoteDB_uiDataBaseType = uiRemoteDB_uiDataBaseType;

                            Properties.RemoteDB3.Default.RemoteDB_DataSource = sRemoteDB_DataSource;

                            Properties.RemoteDB3.Default.RemoteDB_DataBase = sRemoteDB_DataBase;

                            Properties.RemoteDB3.Default.RemoteDB_UserName = sRemoteDB_UserName;

                            Properties.RemoteDB3.Default.RemoteDB_Password = sRemoteDB_Password;

                            Properties.RemoteDB3.Default.RemoteDB_strDataBaseFilePath = sRemoteDB_strDataBaseFilePath;

                            Properties.RemoteDB3.Default.RemoteDB_strDataBaseLogFilePath = sRemoteDB_strDataBaseLogFilePath;

                            Properties.RemoteDB3.Default.RemoteDB_TryToConnectTimeout_in_seconds = iRemoteDB_TryToConnectTimeout_in_seconds;

                            Properties.RemoteDB3.Default.Save();
                            break;
                        case 3:
                            Properties.RemoteDB4.Default.RemoteDB_uiDataBaseType = uiRemoteDB_uiDataBaseType;
                            Properties.RemoteDB4.Default.RemoteDB_DataSource = sRemoteDB_DataSource;
                            Properties.RemoteDB4.Default.RemoteDB_DataBase = sRemoteDB_DataBase;
                            Properties.RemoteDB4.Default.RemoteDB_UserName = sRemoteDB_UserName;
                            Properties.RemoteDB4.Default.RemoteDB_Password = sRemoteDB_Password;
                            Properties.RemoteDB4.Default.RemoteDB_strDataBaseFilePath = sRemoteDB_strDataBaseFilePath;
                            Properties.RemoteDB4.Default.RemoteDB_strDataBaseLogFilePath = sRemoteDB_strDataBaseLogFilePath;
                            Properties.RemoteDB4.Default.RemoteDB_TryToConnectTimeout_in_seconds = iRemoteDB_TryToConnectTimeout_in_seconds;
                            Properties.RemoteDB4.Default.Save();
                            break;
                    }
                    break;

                case eType.IniFile_Setting:

                    string section = m_inifile_prefix + const_section_prefix_RemoteDB_;
                    if (SettingsFunc.IniWriteValue_UIntArr(section,m_SettingsIndex, uiRemoteDB_uiDataBaseType, const_uiRemoteDB_uiDataBaseType, ref Err))
                    {
                        if (SettingsFunc.IniWriteValue_BoolArr(section, m_SettingsIndex, bRemoteDB_bWindowsAuthentication, const_bRemoteDB_bWindowsAuthentication, ref Err))
                        {
                            if (SettingsFunc.IniWriteValue_StringArr(section, m_SettingsIndex, sRemoteDB_DataSource, const_sRemoteDB_DataSource, ref Err))
                            {
                                if (SettingsFunc.IniWriteValue_StringArr(section, m_SettingsIndex, sRemoteDB_DataBase, const_sRemoteDB_DataBase, ref Err))
                                {
                                    if (SettingsFunc.IniWriteValue_StringArr(section, m_SettingsIndex, sRemoteDB_UserName, const_sRemoteDB_UserName, ref Err))
                                    {
                                        if (SettingsFunc.IniWriteValue_StringArr(section, m_SettingsIndex, sRemoteDB_Password, const_sRemoteDB_Password, ref Err))
                                        {
                                            if (SettingsFunc.IniWriteValue_StringArr(section, m_SettingsIndex, sRemoteDB_strDataBaseFilePath, const_sRemoteDB_strDataBaseFilePath, ref Err))
                                            {
                                                if (SettingsFunc.IniWriteValue_StringArr(section, m_SettingsIndex, sRemoteDB_strDataBaseLogFilePath, const_sRemoteDB_strDataBaseLogFilePath, ref Err))
                                                {
                                                    if (SettingsFunc.IniWriteValue_IntArr(section, m_SettingsIndex, iRemoteDB_TryToConnectTimeout_in_seconds, const_iRemoteDB_TryToConnectTimeout_in_seconds, ref Err))
                                                    {
                                                        return true;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }

                    break;

                default:
                    LogFile.Error.Show("Error:Settings.Save:m_Type not implemented!");
                    break;
            }
            return false;
        }


        public  uint DBType()
        {
            return uiRemoteDB_uiDataBaseType;
        }


        public  string DataSource()
        {
            return sRemoteDB_DataSource;
        }

        public  string strDataBaseLogFilePath()
        {
            return sRemoteDB_strDataBaseLogFilePath;
        }

        public  string strDataBaseFilePath()
        {
            return sRemoteDB_strDataBaseFilePath;
        }

        public  string crypted_Password()
        {
            return sRemoteDB_Password;
        }

        public  string UserName()
        {
            return sRemoteDB_UserName;
        }

        public  string DataBase()
        {
            return sRemoteDB_DataBase;
        }

        public  bool Save(uint DBType, bool bWindowsAuthentication, string DataSource, string DataBase, string UserName, string crypted_Password, string strDataBaseFilePath, string strDataBaseLogFilePath, ref string Err)
        {
            uiRemoteDB_uiDataBaseType = DBType;
            bRemoteDB_bWindowsAuthentication = bWindowsAuthentication;
            sRemoteDB_DataSource = DataSource;
            sRemoteDB_DataBase = DataBase;
            sRemoteDB_UserName = UserName;
            sRemoteDB_Password = crypted_Password;
            sRemoteDB_strDataBaseFilePath = strDataBaseFilePath;
            sRemoteDB_strDataBaseLogFilePath = strDataBaseLogFilePath;
            return Save(ref Err);
        }

        public  bool bWindowsAuthentication()
        {
            return bRemoteDB_bWindowsAuthentication;
        }


    }
}
