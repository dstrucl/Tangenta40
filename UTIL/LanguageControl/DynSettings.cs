﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Data;

namespace LanguageControl
{
    public static class DynSettings
    {
        public static int MAX_NUMBER_OF_LANGUAGES = 20;
        public static int LanguageID = 0;
        public static ltext s_language = new ltext("English", "Slovensko");
        public static bool AllowToEditText = false;

        public static void LoadLanguages()
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
                dt_Languages.ReadXml(lngRPM_XML_file);
                dt_Languages.CaseSensitive = true;
                Type myType = typeof(lngRPM);
                FieldInfo[] fields = myType.GetFields();
                string sErr = "";
                foreach (FieldInfo fi in fields)
                {
                    if (fi.FieldType.Name.Equals("ltext"))
                    {
                        ltext lt = (ltext)fi.GetValue(null);
                        string sname = fi.Name;
                        DataRow[] drs = dt_Languages.Select("variable_name = '" + sname + "'");
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
                //dt_Languages.WriteXml(lngRPM_XML_file, XmlWriteMode.WriteSchema);
                if (sErr.Length > 0)
                {
                    MessageBox.Show(sErr);
                    SaveLanguages(ref dt_Languages, lngRPM_XML_file, TableName);
                }

            }
            catch (Exception Ex)
            {
                SaveLanguages(ref dt_Languages, lngRPM_XML_file, TableName);
            }

        }
        public static bool SaveLanguages(ref DataTable dt_Languages, string lngRPM_XML_file, string TableName)
        {
            try
            {
                dt_Languages.Clear();
                dt_Languages.Columns.Clear();

                Type myType = typeof(lngRPM);
                FieldInfo[] fields = myType.GetFields();
                dt_Languages.TableName = TableName;
                dt_Languages.Columns.Add("variable_name", typeof(string));
                for (int i = 0; i < DynSettings.MAX_NUMBER_OF_LANGUAGES; i++)
                {
                    string sLanguageName = "language_" + i.ToString();
                    dt_Languages.Columns.Add(sLanguageName, typeof(string));
                }
                foreach (FieldInfo fi in fields)
                {
                    if (fi.FieldType.Name.Equals("ltext"))
                    {
                        ltext lt = (ltext)fi.GetValue(null);
                        string sname = fi.Name;
                        DataRow dr = dt_Languages.NewRow();
                        dr["variable_name"] = sname;
                        for (int i = 0; i < DynSettings.MAX_NUMBER_OF_LANGUAGES; i++)
                        {
                            string sLanguageName = "language_" + i.ToString();
                            dr[sLanguageName] = lt.GetText(i);
                        }
                        dt_Languages.Rows.Add(dr);
                    }
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
    }
}