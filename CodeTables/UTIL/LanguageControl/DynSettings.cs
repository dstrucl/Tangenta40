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
using System.Windows.Forms;
using System.Reflection;
using System.Data;
using System.Drawing;
using System.IO;

namespace LanguageControl
{
    public static class DynSettings
    {
        public const string LANGUAGE_SETTINGS_SUB_FOLDER = "\\TangentaSettings";
        public const string LANGUAGE_COLUMN_PREFIX = "language_";
        internal const string DICTIONARY = "LanguageDictionary";
        internal const string MODULE_NAME = "ModuleName";
        internal const string VARIABLE_NAME = "variable_name";
        public const int NotDefined_ID = -1;
        public const int English_ID = 0;
        public const int Slovensko_ID = 1;

        internal static string LanguageSettingsFolderName = "";

        public static int MAX_NUMBER_OF_LANGUAGES = 20;
        public static int LanguageID = 0;
        public static ltext s_language = new ltext("English", "Slovensko");




        public static bool AllowToEditText = false;

        public static List<string> LanguagePrefixList = null;

        internal static List<language_library> LanguageLibraryList = new List<language_library>();


        public static string GetLanguagePrefix(int Languge_ID)
        {
            switch (Languge_ID)
            {
                case 0:
                    return "eng";
                case 1:
                    return "slo";

            }
            return "???";
        }
        public static void InitLanguagePrefixList()
        {
            LanguagePrefixList = new List<string>();
            LanguagePrefixList.Add(GetLanguagePrefix(English_ID));
            LanguagePrefixList.Add(GetLanguagePrefix(Slovensko_ID));
        }

        public static void Init()
        {

            LanguageSettingsFolderName = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + LANGUAGE_SETTINGS_SUB_FOLDER;
            if (!Directory.Exists(LanguageSettingsFolderName))
            {
                try
                {
                    Directory.CreateDirectory(LanguageSettingsFolderName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR:Canot create directory:\"" + LanguageSettingsFolderName + "\"! Exception ex = " + ex.Message);
                }
            }
            ComboBox_Recent.ComboBox_RecentList.GrantFolderAccess(LanguageSettingsFolderName);
        }

        public static void AddLanguageLibrary(FieldInfo[] xFields, string xModuleName)
        {
            foreach(language_library lng_lib in LanguageLibraryList)
            {
                if (lng_lib.ModuleName.Equals(xModuleName))
                {
                    lng_lib.Fields = xFields;
                    return;
                }
            }
            language_library xlng_lib = new language_library(xModuleName, xFields);
            LanguageLibraryList.Add(xlng_lib);

        }

        public static string LanguagePrefix
        { get
            {
                return GetLanguagePrefix(LanguageID);
            }
        }

        public static void LoadLanguages(bool bReset2FactorySettings)
        {
            DataTable dt_Languages = null;
            LoadLanguages(ref dt_Languages, bReset2FactorySettings);
        }

        public static void LoadLanguages(ref DataTable dt_Languages,bool bReset2FactorySettings)
        {
            string TableName = DICTIONARY;


            string sAppDataFolder = LanguageSettingsFolderName;

            if (sAppDataFolder[sAppDataFolder.Length - 1] != '\\')
            {
                sAppDataFolder += "\\";
            }
            string lngRPM_XML_file = sAppDataFolder + TableName;
            try
            {
                if (bReset2FactorySettings)
                {
                    File.Delete(lngRPM_XML_file);
                }
                else
                {

                    if (dt_Languages == null)
                    {
                        Create_dt_Language(ref dt_Languages);

                    }
                    dt_Languages.ReadXml(lngRPM_XML_file);
                    dt_Languages.CaseSensitive = true;

                    string sErr = "";
                    foreach (language_library xlng_lib in LanguageLibraryList)
                    {
                        foreach (FieldInfo fi in xlng_lib.Fields)
                        {
                            if (fi.FieldType.Name.Equals("ltext"))
                            {
                                ltext lt = (ltext)fi.GetValue(null);
                                string sname = fi.Name;
                                DataRow[] drs = dt_Languages.Select(MODULE_NAME + " = '" + xlng_lib.ModuleName + "' and " + VARIABLE_NAME + " = '" + sname + "'");
                                if (drs.Count() == 1)
                                {
                                    lt.SetTextFromDataRow(drs[0]);
                                }
                                else
                                {
                                    if (drs.Count() > 1)
                                    {
                                        MessageBox.Show("ERROR:LoadLanguages:More than one definition for language varibale:" + sname);
                                    }
                                    else
                                    {
                                        if (sErr.Length == 0)
                                        {
                                            sErr += "ERROR:LoadLanguages:No definition for language variables:'" + sname + "'";
                                        }
                                        else
                                        {
                                            sErr += ",'" + sname + "'";
                                        }
                                    }
                                }
                            }
                        }
                    }
                    //dt_Languages.WriteXml(lngRPM_XML_file, XmlWriteMode.WriteSchema);
                    if (sErr.Length > 0)
                    {
                        MessageBox.Show(sErr);
                        SaveLanguages(ref dt_Languages, lngRPM_XML_file, TableName);
                    }
                }
            }
            catch
            {
                SaveLanguages(ref dt_Languages, lngRPM_XML_file, TableName);
            }
        }

        public static string SetLanguageDecimalString(decimal xdecimal, int decimalplaces, string unitsymbol)
        {
            string sdecimal = xdecimal.ToString();
            string sdectotal = null;

            int idecimalpoint = sdecimal.IndexOfAny(new char[] { '.', ',' });
            if (idecimalpoint >= 0)
            {
                string[] spart = sdecimal.Split(new char[] { '.', ',' });
                if (spart.Length == 2)
                {
                    string sdec = spart[1];
                    while (sdec.Length < decimalplaces)
                    {
                        sdec += '0';
                    }
                    sdectotal = spart[0] + lng.s_DecimalPoint.s + sdec;
                }
                if (spart.Length == 1)
                {
                    string sdec = "";
                    while (sdec.Length < decimalplaces)
                    {
                        sdec += '0';
                    }
                    sdectotal = spart[0] + lng.s_DecimalPoint.s + sdec;
                }
            }
            else
            {
                string sdec = "";
                while (sdec.Length < decimalplaces)
                {
                    sdec += '0';
                }
                sdectotal = sdecimal + lng.s_DecimalPoint.s + sdec; 
            }
            if (sdectotal!=null)
            {
                if (unitsymbol != null)
                {
                    sdectotal += " " + unitsymbol;
                }
                return sdectotal;
            }
            return "Err decimal";
        }

        public static string SetLanguageCurrencyString(decimal xdecimal, int decimalplaces, string symbol)
        {
            string sdecimal = xdecimal.ToString();
            string sdectotal = null;

            int idecimalpoint = sdecimal.IndexOfAny(new char[] { '.', ',' });
            if (idecimalpoint >= 0)
            {
                string[] spart = sdecimal.Split(new char[] { '.', ',' });
                if (spart.Length == 2)
                {
                    string sdec = spart[1];
                    while (sdec.Length < decimalplaces)
                    {
                        sdec += '0';
                    }
                    sdectotal = spart[0] + lng.s_DecimalPoint.s + sdec;
                }
                if (spart.Length == 1)
                {
                    string sdec = "";
                    while (sdec.Length < decimalplaces)
                    {
                        sdec += '0';
                    }
                    sdectotal = spart[0] + lng.s_DecimalPoint.s + sdec;
                }
            }
            else
            {
                string sdec = "";
                while (sdec.Length < decimalplaces)
                {
                    sdec += '0';
                }
                sdectotal = sdecimal + lng.s_DecimalPoint.s + sdec;
            }
            if (sdectotal != null)
            {
                if (symbol != null)
                {
                    sdectotal += " " + symbol;
                }
                return sdectotal;
            }
            return "Err decimal";
        }

        public static void LanguageTextSave()
        {
            DataTable dt_Languages = null;
            string TableName = DICTIONARY;
           
            string sAppDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            if (sAppDataFolder[sAppDataFolder.Length - 1] != '\\')
            {
                sAppDataFolder += "\\";
            }
            string lngRPM_XML_file = sAppDataFolder + TableName;
            DynSettings.SaveLanguages(ref dt_Languages, lngRPM_XML_file, TableName);
        }


        public static bool SaveLanguages(ref DataTable dt_Languages, string lngRPM_XML_file, string TableName)
        {
            try
            {
                if (dt_Languages == null)
                {
                    Create_dt_Language(ref dt_Languages);

                }
                else
                {
                    dt_Languages.Clear();
                }
                foreach (language_library xlng_lib in LanguageLibraryList)
                {
                    FillLanguages(ref dt_Languages,xlng_lib.Fields, xlng_lib.ModuleName);
                }

                dt_Languages.WriteXml(lngRPM_XML_file, XmlWriteMode.WriteSchema);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR:DynSettings:SaveLanguages:Exception=" + ex.Message + "\r\nStackTrace=" + ex.StackTrace);
                return false;
            }
        }



        internal static void Create_dt_Language(ref DataTable dt_Languages)
        {
            dt_Languages = new DataTable();
            dt_Languages.TableName = DICTIONARY;
            dt_Languages.Columns.Add(MODULE_NAME, typeof(string));
            dt_Languages.Columns.Add(VARIABLE_NAME, typeof(string));
            for (int i = 0; i < DynSettings.MAX_NUMBER_OF_LANGUAGES; i++)
            {
                string sLanguageName = LANGUAGE_COLUMN_PREFIX + i.ToString();
                dt_Languages.Columns.Add(sLanguageName, typeof(string));
            }
        }

        public static void FillLanguages(ref DataTable dt_Languages,FieldInfo[] fields,string ModuleName)
        {


            string sErr = "";
            foreach (FieldInfo fi in fields)
            {
                if (fi.FieldType.Name.Equals("ltext"))
                {
                    ltext lt = (ltext)fi.GetValue(null);
                    if (lt != null)
                    {
                        string sname = fi.Name;
                        DataRow dr = dt_Languages.NewRow();
                        dr[MODULE_NAME] = ModuleName;
                        dr[VARIABLE_NAME] = sname;
                        for (int i = 0; i < DynSettings.MAX_NUMBER_OF_LANGUAGES; i++)
                        {
                            string sLanguageName = "language_" + i.ToString();
                            dr[sLanguageName] = lt.GetText(i);
                        }
                        dt_Languages.Rows.Add(dr);
                    }
                    else
                    {
                        string xsname = fi.Name;
                        if (xsname==null)
                        {
                            xsname = "/*Name not defined !*/";
                        }
                        sErr += "\r\nModule:"+ ModuleName + " Variable " + xsname + " of ltext type is null";
                    }
                }
            }
            if (sErr.Length>0)
            {
                MessageBox.Show(sErr);
            }
        }

        public static bool SelectLanguage(Icon Program_icon, string Program_name,int Language_ID, NavigationButtons.Navigation xnav)
        {
            Form_SelectLanguage frm_sel_language = new Form_SelectLanguage(Program_icon, Program_name, Language_ID, xnav);
            if (frm_sel_language.ShowDialog()==DialogResult.OK)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

        private static string set_zero_in_front(string s,int iplaces)
        {
            if (s != null)
            {
                while (s.Length < iplaces)
                {
                    s = '0' + s;
                }
                return s;
            }
            else
            {
                return "ERR!";
            }
        }

        public static string SetLanguageDateTimeString(DateTime datetime)
        {
            if (LanguageID == Slovensko_ID)
            {
                string shour = datetime.Hour.ToString();
                if (shour.Length==1)
                {
                    shour = "0" + shour;
                }
                string sminute = datetime.Minute.ToString();
                if (sminute.Length == 1)
                {
                    sminute = "0" + sminute;
                }
                string ssec = datetime.Second.ToString();
                if (ssec.Length == 1)
                {
                    ssec = "0" + ssec;
                }
                return datetime.Day.ToString() + "."
                                    + datetime.Month.ToString() + "."
                                    + datetime.Year.ToString() + " "
                                    + shour + ":" + sminute + ":" + ssec;
            }
            else
            {
                // according to ISO 8601 Data elements and interchange formats
                return datetime.Year.ToString() + "-"
                                    + set_zero_in_front(datetime.Month.ToString(), 2) + "-"
                                    + set_zero_in_front(datetime.Day.ToString(), 2) + " "
                                    + set_zero_in_front(datetime.Hour.ToString(), 2) + ":"
                                    + set_zero_in_front(datetime.Minute.ToString(), 2);

            }

        }

        public static string SetLanguageDateString(DateTime datetime)
        {
            if (LanguageID==Slovensko_ID)
            {
                return datetime.Day.ToString() + "."
                                    + datetime.Month.ToString() + "."
                                    + datetime.Year.ToString();
            }
            else
            {
                // according to ISO 8601 Data elements and interchange formats
                return datetime.Year.ToString() + "-"
                                    + set_zero_in_front(datetime.Month.ToString(),2) + "-"
                                    + set_zero_in_front(datetime.Day.ToString(),2);

            }
            
        }
    }
}
