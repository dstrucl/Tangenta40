#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DBConnectionControl_Settings
{
    public static class SettingsFunc
    {
        // Read
        public static int Number_Of_Connections = 4;

        public static bool IniReadValue_StringArr(string section_RemoteOrLocalDB, int iSectionIndex,ref string s, string sKey, ref string Err)
        {
            string section = section_RemoteOrLocalDB + iSectionIndex.ToString(); //"RemoteDB_"
            string sValue = null;
            if (IniFile.IniFile.IniReadValue(section, sKey, ref sValue, ref Err))
            {
                s = sValue;
            }
            else
            {
                return false;
            }
            return true;
        }

        public static bool IniReadValue_UIntArr(string section_prefix,int iSectionIndex,ref uint ui, string sKey, ref string Err)
        {
            string section = section_prefix + iSectionIndex.ToString(); //"RemoteDB_" 
            string sValue = null;
            if (IniFile.IniFile.IniReadValue(section, sKey, ref sValue, ref Err))
            {
                ui = Convert.ToUInt32(sValue);
            }
            else
            {
                return false;
            }
            return true;
        }

        public static bool IniReadValue_IntArr(string section_prefix,int iSectionIndex,ref int ii, string sKey, ref string Err)
        {
            string section = section_prefix + iSectionIndex.ToString(); //"RemoteDB_"
            string sValue = null;
            if (IniFile.IniFile.IniReadValue(section, sKey, ref sValue, ref Err))
            {
                ii = Convert.ToInt32(sValue);
            }
            else
            {
                return false;
            }
            return true;
        }


        public static bool IniReadValue_BoolArr(string section_prefix,int iSectionIndex, ref bool b, string sKey, ref string Err)
        {
            string section = section_prefix + iSectionIndex.ToString(); //"RemoteDB_"
            string sValue = null;
            if (IniFile.IniFile.IniReadValue(section, sKey, ref sValue, ref Err))
            {
                b = Convert.ToBoolean(sValue);
            }
            else
            {
                return false;
            }
            return true;
        }

        // Write
        public static bool IniWriteValue_StringArr(string section_prefix, int iSectionIndex, string s, string sKey, ref string Err)
        {
            string section = section_prefix + iSectionIndex.ToString();
            if (!IniFile.IniFile.IniWriteValue(section, sKey, s, ref Err))
            {
                return false;
            }
            return true;
        }

        public static bool IniWriteValue_UIntArr(string section_prefix, int iSectionIndex, uint ui, string sKey, ref string Err)
        {
            string section = section_prefix + iSectionIndex.ToString();
            string sValue = Convert.ToString(ui);
            if (!IniFile.IniFile.IniWriteValue(section, sKey, sValue, ref Err))
            {
                return false;
            }
            return true;
        }

        public static bool IniWriteValue_IntArr(string section_prefix,int iSectionIndex, int  ii, string sKey, ref string Err)
        {
            string section = section_prefix + iSectionIndex.ToString();
            string sValue = Convert.ToString(ii);
            if (!IniFile.IniFile.IniWriteValue(section, sKey, sValue, ref Err))
            {
                return false;
            }
            return true;
        }


        public static bool IniWriteValue_BoolArr(string section_prefix, int iSectionIndex, bool b, string sKey, ref string Err)
        {
            string section = section_prefix + iSectionIndex.ToString();
            string sValue = Convert.ToString(b);
            if (!IniFile.IniFile.IniWriteValue(section, sKey, sValue, ref Err))
            {
                return false;
            }
            return true;
        }
    }
}
