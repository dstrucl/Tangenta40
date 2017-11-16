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
        internal const string MODULE_NAME = "ModuleName";
        internal const string VARIABLE_NAME = "variable_name";
        public const int NotDefined_ID = -1;
        public const int English_ID = 0;
        public const int Slovensko_ID = 1;

        public static int MAX_NUMBER_OF_LANGUAGES = 20;
        public static int LanguageID = 0;
        public static ltext s_language = new ltext("English", "Slovensko");


        public static bool AllowToEditText = false;
        private static DataTable dt_Languages = null;

        internal static List<language_library> LanguageLibraryList = new List<language_library>();

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

                switch (LanguageID)
                {
                    case English_ID:
                        return "eng";
                    case Slovensko_ID:
                        return "slo";
                    default:
                        return "unknown_lang";
                }
            }
        }

        public static void LoadLanguages(bool bReset2FactorySettings)
        {
            DataTable dt_Languages = new DataTable();
            string TableName = "lngRPM";
            string sAppDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
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
                                DataRow[] drs = dt_Languages.Select(MODULE_NAME +  " = '" + xlng_lib.ModuleName + "' and "+ VARIABLE_NAME + " = '" + sname + "'");
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

        public static void LanguageTextSave()
        {
            DataTable dt_Languages = new DataTable();
            string TableName = "lngRPM";
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
                if (dt_Languages != null)
                {
                    dt_Languages.Clear();
                    dt_Languages.Columns.Clear();
                }
                foreach (language_library xlng_lib in LanguageLibraryList)
                {
                    FillLanguages(xlng_lib.Fields, xlng_lib.ModuleName);
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

        public static void FillLanguages(FieldInfo[] fields,string ModuleName)
        {
            
            if (dt_Languages == null)
            {
                dt_Languages.Columns.Add(MODULE_NAME, typeof(string));
                dt_Languages.Columns.Add(VARIABLE_NAME, typeof(string));
                for (int i = 0; i < DynSettings.MAX_NUMBER_OF_LANGUAGES; i++)
                {
                    string sLanguageName = "language_" + i.ToString();
                    dt_Languages.Columns.Add(sLanguageName, typeof(string));
                }

            }
           
            foreach (FieldInfo fi in fields)
            {
                if (fi.FieldType.Name.Equals("ltext"))
                {
                    ltext lt = (ltext)fi.GetValue(null);
                    string sname = fi.Name;
                    DataRow dr = dt_Languages.NewRow();
                    dr[MODULE_NAME] = ModuleName;
                    dr[VARIABLE_NAME] = sname;
                    for (int i = 0; i<DynSettings.MAX_NUMBER_OF_LANGUAGES; i++)
                    {
                        string sLanguageName = "language_" + i.ToString();
                        dr[sLanguageName] = lt.GetText(i);
                    }
                    dt_Languages.Rows.Add(dr);
                }
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
                return datetime.Day.ToString() + "."
                                    + datetime.Month.ToString() + "."
                                    + datetime.Year.ToString() + " "
                                    + datetime.Hour.ToString() + ":"
                                    + datetime.Minute.ToString();
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
