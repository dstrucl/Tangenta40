using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IniFile;
using System.IO;
using System.Windows.Forms;
namespace DBConnectionControl_Settings
{
    public  class Settings_LocalDB
    {

        public string m_inifile_prefix = null;

        public const string const_sLocalDB_DataBaseFilePath = "sLocalDB_DataBaseFilePath";
        public const string const_sLocalDB_DataBaseFileName = "sLocalDB_DataBaseFileName";
        public const string const_sLocalDB_crypted_Password = "sLocalDB_crypted_Password";

        public const string const_section_prefix_LocalDB_ = "LocalDB_";

        public enum eType { Properties_Settings_Default, IniFile_Setting };

        public  eType m_eType = eType.IniFile_Setting;

        public int m_iSettingsIndex = -1;

        public  string sLocalDB_DataBaseFilePath = null;
        public  string sLocalDB_DataBaseFileName = null;
        public  string sLocalDB_crypted_Password = null;

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

        public Settings_LocalDB(string x_inifile_prefix, int iSettingsIndex)
        {
            m_iSettingsIndex = iSettingsIndex;
            m_inifile_prefix = x_inifile_prefix;
        }

        public  bool Load(ref string Err)
        {

            switch (m_eType)
            {
                case eType.Properties_Settings_Default:

                    switch (m_iSettingsIndex)
                    {
                        case 0:
                            sLocalDB_DataBaseFilePath = Properties.LocalDB1.Default.LocalDB_DataBaseFilePath;
                            sLocalDB_DataBaseFileName = Properties.LocalDB1.Default.LocalDB_DataBaseFileName;
                            sLocalDB_crypted_Password = Properties.LocalDB1.Default.LocalDB_crypted_Password;
                            break;
                        case 1:
                            sLocalDB_DataBaseFilePath = Properties.LocalDB2.Default.LocalDB_DataBaseFilePath;
                            sLocalDB_DataBaseFileName = Properties.LocalDB2.Default.LocalDB_DataBaseFileName;
                            sLocalDB_crypted_Password = Properties.LocalDB2.Default.LocalDB_crypted_Password;
                            break;
                        case 2:
                            sLocalDB_DataBaseFilePath = Properties.LocalDB3.Default.LocalDB_DataBaseFilePath;
                            sLocalDB_DataBaseFileName = Properties.LocalDB3.Default.LocalDB_DataBaseFileName;
                            sLocalDB_crypted_Password = Properties.LocalDB3.Default.LocalDB_crypted_Password;
                            break;
                        case 3:
                            sLocalDB_DataBaseFilePath = Properties.LocalDB4.Default.LocalDB_DataBaseFilePath;
                            sLocalDB_DataBaseFileName = Properties.LocalDB4.Default.LocalDB_DataBaseFileName;
                            sLocalDB_crypted_Password = Properties.LocalDB4.Default.LocalDB_crypted_Password;
                            break;
                    }
                    return true;
                    break;

                case eType.IniFile_Setting:
                    if (!SectionExistsInIniFile())
                    {
                        Init();
                        if (!Save(ref Err))
                        {
                            return false;
                        }
                    }

                    string section = m_inifile_prefix + const_section_prefix_LocalDB_;

                    if (SettingsFunc.IniReadValue_StringArr(section,m_iSettingsIndex, ref sLocalDB_DataBaseFilePath, const_sLocalDB_DataBaseFilePath,ref Err))
                    {
                        if (SettingsFunc.IniReadValue_StringArr(section, m_iSettingsIndex,ref sLocalDB_DataBaseFileName, const_sLocalDB_DataBaseFileName, ref Err))
                        {
                            if (SettingsFunc.IniReadValue_StringArr(section, m_iSettingsIndex,ref sLocalDB_crypted_Password, const_sLocalDB_crypted_Password, ref Err))
                            {
                                return true;
                            }
                        }
                    }
                    return false;
                    break;
            }
            return false;
        }

        private  void Init()
        {
            sLocalDB_DataBaseFilePath = "";
            sLocalDB_DataBaseFileName = "";
            sLocalDB_crypted_Password = "";
        }

        private  bool SectionExistsInIniFile()
        {
            if (File.Exists(IniFile.IniFile.path))
            {
                string section = null;
                section = m_inifile_prefix + const_section_prefix_LocalDB_ + m_iSettingsIndex.ToString();
                if (!IniFile.IniFile.Check_Section_And_Key(section, const_sLocalDB_DataBaseFilePath))
                {
                    return false;
                }
                if (!IniFile.IniFile.Check_Section_And_Key(section, const_sLocalDB_DataBaseFileName))
                {
                    return false;
                }
                if (!IniFile.IniFile.Check_Section_And_Key(section, const_sLocalDB_crypted_Password))
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


        public  bool Save(ref string Err)
        {
            switch (m_eType)
            {
                case eType.Properties_Settings_Default:
                    switch (m_iSettingsIndex)
                    {
                        case 0:
                            Properties.LocalDB1.Default.LocalDB_DataBaseFileName = sLocalDB_DataBaseFileName;
                            Properties.LocalDB1.Default.LocalDB_DataBaseFilePath = sLocalDB_DataBaseFilePath;
                            Properties.LocalDB1.Default.LocalDB_crypted_Password = sLocalDB_crypted_Password;
                            Properties.LocalDB1.Default.Save();
                            break;
                        case 1:
                            Properties.LocalDB2.Default.LocalDB_DataBaseFileName = sLocalDB_DataBaseFileName;
                            Properties.LocalDB2.Default.LocalDB_DataBaseFilePath = sLocalDB_DataBaseFilePath;
                            Properties.LocalDB2.Default.LocalDB_crypted_Password = sLocalDB_crypted_Password;
                            Properties.LocalDB2.Default.Save();
                            break;
                        case 2:
                            Properties.LocalDB3.Default.LocalDB_DataBaseFileName = sLocalDB_DataBaseFileName;
                            Properties.LocalDB3.Default.LocalDB_DataBaseFilePath = sLocalDB_DataBaseFilePath;
                            Properties.LocalDB3.Default.LocalDB_crypted_Password = sLocalDB_crypted_Password;
                            Properties.LocalDB3.Default.Save();
                            break;
                        case 3:
                            Properties.LocalDB4.Default.LocalDB_DataBaseFileName = sLocalDB_DataBaseFileName;
                            Properties.LocalDB4.Default.LocalDB_DataBaseFilePath = sLocalDB_DataBaseFilePath;
                            Properties.LocalDB4.Default.LocalDB_crypted_Password = sLocalDB_crypted_Password;
                            Properties.LocalDB4.Default.Save();
                            break;
                    }

                    return true;
                    break;

                case eType.IniFile_Setting:
                    string section = m_inifile_prefix + const_section_prefix_LocalDB_;
                    if (SettingsFunc.IniWriteValue_StringArr(section,m_iSettingsIndex, sLocalDB_DataBaseFileName, const_sLocalDB_DataBaseFileName, ref Err))
                    {
                        if (SettingsFunc.IniWriteValue_StringArr(section, m_iSettingsIndex, sLocalDB_DataBaseFilePath, const_sLocalDB_DataBaseFilePath, ref Err))
                        {
                            if (SettingsFunc.IniWriteValue_StringArr(section, m_iSettingsIndex, sLocalDB_crypted_Password, const_sLocalDB_crypted_Password, ref Err))
                            {
                                return true;
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


        public  string LocalDB_DataBaseFilePath()
        {
            switch (m_eType)
            {

                case eType.Properties_Settings_Default:
                    switch (m_iSettingsIndex)
                    {
                        case 0:
                            return Properties.LocalDB1.Default.LocalDB_DataBaseFilePath;
                            break;
                        case 1:
                            return Properties.LocalDB2.Default.LocalDB_DataBaseFilePath;
                            break;
                        case 2:
                            return Properties.LocalDB3.Default.LocalDB_DataBaseFilePath;
                            break;
                        case 3:
                            return Properties.LocalDB4.Default.LocalDB_DataBaseFilePath;
                            break;
                        default:
                            LogFile.Error.Show("Error:Settings.(string)LocalDB_DataBaseFilePath:Settings_Index=" + m_iSettingsIndex.ToString() + " not implemented in!");
                            return Properties.LocalDB1.Default.LocalDB_DataBaseFilePath;
                            break;
                    }
                    break;

                case eType.IniFile_Setting:
                     return sLocalDB_DataBaseFilePath;
                     break;


                default:
                    LogFile.Error.Show("Error:Settings.LocalDB_DataBaseFilePath:m_Type not implemented in!");
                    return null;
                    break;
            }
        }

        public  void LocalDB_DataBaseFilePath(string sValue)
        {
            switch (m_eType)
            {

                case eType.Properties_Settings_Default:
                    switch (m_iSettingsIndex)
                    {
                        case 0:
                            Properties.LocalDB1.Default.LocalDB_DataBaseFilePath = sValue;
                            break;
                        case 1:
                            Properties.LocalDB2.Default.LocalDB_DataBaseFilePath = sValue;
                            break;
                        case 2:
                            Properties.LocalDB3.Default.LocalDB_DataBaseFilePath = sValue;
                            break;
                        case 3:
                            Properties.LocalDB4.Default.LocalDB_DataBaseFilePath = sValue;
                            break;

                        default:
                            LogFile.Error.Show("Error:Settings.(void)LocalDB_DataBaseFilePath:Settings_Index=" + m_iSettingsIndex.ToString() + " not implemented in!");
                            break;
                    }
                    break;
                case eType.IniFile_Setting:
                    sLocalDB_DataBaseFilePath = sValue;
                    break;

                default:
                    LogFile.Error.Show("Error:Settings.LocalDB_DataBaseFilePath:m_Type not implemented in!");
                    break;
            }
        }


        public  string LocalDB_DataBaseFileName()
        {
            switch (m_eType)
            {

                case eType.Properties_Settings_Default:
                    switch (m_iSettingsIndex)
                    {
                        case 0:
                            return Properties.LocalDB1.Default.LocalDB_DataBaseFileName;
                            break;
                        case 1:
                            return Properties.LocalDB2.Default.LocalDB_DataBaseFileName;
                            break;
                        case 2:
                            return Properties.LocalDB3.Default.LocalDB_DataBaseFileName;
                            break;
                        case 3:
                            return Properties.LocalDB4.Default.LocalDB_DataBaseFileName;
                            break;
                        default:
                            LogFile.Error.Show("Error:Settings.(string)LocalDB_DataBaseFileName:Settings_Index=" + m_iSettingsIndex.ToString() + " not implemented in!");
                            return Properties.LocalDB1.Default.LocalDB_DataBaseFileName;
                            break;
                    }
                    break;
                case eType.IniFile_Setting:
                    return sLocalDB_DataBaseFileName;
                    break;

                default:
                    LogFile.Error.Show("Error:Settings.LocalDB_DataBaseFileName:m_Type not implemented in!");
                    return null;
                    break;
            }
        }

        public  void LocalDB_DataBaseFileName( string sValue)
        {
            switch (m_eType)
            {

                case eType.Properties_Settings_Default:
                    switch (m_iSettingsIndex)
                    {
                        case 0:
                            Properties.LocalDB1.Default.LocalDB_DataBaseFileName = sValue;
                            break;
                        case 1:
                            Properties.LocalDB2.Default.LocalDB_DataBaseFileName = sValue;
                            break;
                        case 2:
                            Properties.LocalDB3.Default.LocalDB_DataBaseFileName = sValue;
                            break;
                        case 3:
                            Properties.LocalDB4.Default.LocalDB_DataBaseFileName = sValue;
                            break;
                        default:
                            LogFile.Error.Show("Error:Settings.(void)LocalDB_DataBaseFileName:Settings_Index=" + m_iSettingsIndex.ToString() + " not implemented in!");
                            break;
                    }
                    break;

                case eType.IniFile_Setting:
                    sLocalDB_DataBaseFileName = sValue;
                    break;

                default:
                    LogFile.Error.Show("Error:Settings.LocalDB_DataBaseFileName:m_Type not implemented in!");
                    break;
            }
        }


        public  string LocalDB_crypted_Password()
        {
            switch (m_eType)
            {

                case eType.Properties_Settings_Default:
                    switch (m_iSettingsIndex)
                    {
                        case 0:
                            return Properties.LocalDB1.Default.LocalDB_crypted_Password;
                        case 1:
                            return Properties.LocalDB2.Default.LocalDB_crypted_Password;
                        case 2:
                            return Properties.LocalDB3.Default.LocalDB_crypted_Password;
                        case 3:
                            return Properties.LocalDB4.Default.LocalDB_crypted_Password;
                        default:
                            LogFile.Error.Show("Error:Settings.(string)LocalDB_crypted_Password:Settings_Index=" + m_iSettingsIndex.ToString() + " not implemented in!");
                            return Properties.LocalDB1.Default.LocalDB_crypted_Password;
                    }
                    break;

                case eType.IniFile_Setting:
                    return sLocalDB_crypted_Password;
                    break;


                default:
                    LogFile.Error.Show("Error:Settings.LocalDB_crypted_Password:m_Type not implemented in!");
                    return null;
            }
        }

        public  void LocalDB_crypted_Password(string sValue)
        {
            switch (m_eType)
            {

                case eType.Properties_Settings_Default:
                    switch (m_iSettingsIndex)
                    {
                        case 0:
                            Properties.LocalDB1.Default.LocalDB_crypted_Password = sValue;
                            break;
                        case 1:
                            Properties.LocalDB2.Default.LocalDB_crypted_Password = sValue;
                            break;
                        case 2:
                            Properties.LocalDB3.Default.LocalDB_crypted_Password = sValue;
                            break;
                        case 3:
                            Properties.LocalDB4.Default.LocalDB_crypted_Password = sValue;
                            break;
                        default:
                            LogFile.Error.Show("Error:Settings.(void)LocalDB_crypted_Password:Settings_Index=" + m_iSettingsIndex.ToString() + " not implemented in!");
                            break;
                    }
                    break;

                case eType.IniFile_Setting:
                    sLocalDB_crypted_Password = sValue;
                    break;

                default:
                    LogFile.Error.Show("Error:Settings.LocalDB_crypted_Password:m_Type not implemented in!");
                    break;
            }
        }

    }
}
