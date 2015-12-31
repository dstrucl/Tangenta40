using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DBTypes
{
    public static class Settings
    {
        public enum eType {Properties_Settings_Default,IniFile_Setting,DataBase_Settings};
        public static eType m_eType = eType.Properties_Settings_Default;

        public static eType TYPE
        {
            get {
                return m_eType;
            }
            set {
                m_eType = value;
            }
        }

        //public static string SaveFileFolder
        //{
        //    get
        //    {
        //        switch (m_eType)
        //        {
        //            case eType.Properties_Settings_Default:
        //                return Properties.Settings.Default.SaveFileFolder;
        //            break;
        //            default:
        //               LogFile.Error.Show("Error:m_Type not implemented!");
        //               return null;

        //        }
        //    }
        //    set
        //    {
        //        switch (m_eType)
        //        {
        //            case eType.Properties_Settings_Default:
        //                Properties.Settings.Default.SaveFileFolder = value;
        //                break;
        //            default:
        //                LogFile.Error.Show("Error:m_Type not implemented!");
        //                break;
        //        }
        //    }
        //}

        internal static void Save()
        {
            switch (m_eType)
            {
                case eType.Properties_Settings_Default:
                    Properties.Settings.Default.Save();
                    break;
                default:
                    LogFile.Error.Show("Error:m_Type not implemented!");
                    break;
            }
            
        }
    }
}
