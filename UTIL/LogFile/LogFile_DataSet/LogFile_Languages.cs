#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion

using System;
using System.Data;
using System.Collections.Generic;
using System.Windows.Forms;
namespace LogFile_DataSet
{
        public static class DynSettings 
        {
            public static int LanguageID=0;
        }

        public static class HeaderText
        {
            public static void Set(DataGridView dgv, List<ltext> col_headers)
            {
                foreach (ltext lt in col_headers)
                {
                    try
                    {
                        dgv.Columns[lt.name].HeaderText = lt.s;
                    }
                    catch
                    {
                    }
                }
            }
        }

        public class ltext
        {
            string m_name = "";
            string[] sText = {"", ""};

            public string name
            {
                get
                {
                    return m_name;
                }
            }
            
            public string s
            {
                get
                {
                    return sText[DynSettings.LanguageID];
                }
            }
            public ltext(string xname, string Lang1, string Lang2)
            {
                m_name = xname;
                sText[0] = Lang1;
                sText[1] = Lang2;
            }
        }



    public class Log_lang
    {
        public List<ltext> col_headers = new List<ltext>();
        public ltext s_TableName = new ltext(/*table name:*/"Log",/*table name in languages:*/"Log","Log");
                    public ltext id_collangname = new ltext(/*column name:*/"id",/*column name in languages:*/"id","id");

                    public ltext LogFile_id_collangname = new ltext(/*column name:*/"LogFile_id",/*column name in languages:*/"LogFile_id","LogFile_id");

                    public ltext LogTime_collangname = new ltext(/*column name:*/"LogTime",/*column name in languages:*/"LogTime","LogTime");

                    public ltext Log_Type_id_collangname = new ltext(/*column name:*/"Log_Type_id",/*column name in languages:*/"Log_Type_id","Log_Type_id");

                    public ltext Log_Description_id_collangname = new ltext(/*column name:*/"Log_Description_id",/*column name in languages:*/"Log_Description_id","Log_Description_id");

        public Log_lang()
        {
        
                    col_headers.Add(id_collangname);

                    col_headers.Add(LogFile_id_collangname);

                    col_headers.Add(LogTime_collangname);

                    col_headers.Add(Log_Type_id_collangname);

                    col_headers.Add(Log_Description_id_collangname);

               }
          }

    public class Log_Computer_lang
    {
        public List<ltext> col_headers = new List<ltext>();
        public ltext s_TableName = new ltext(/*table name:*/"Log_Computer",/*table name in languages:*/"Log_Computer","Log_Computer");
                    public ltext id_collangname = new ltext(/*column name:*/"id",/*column name in languages:*/"id","id");

                    public ltext ComputerName_collangname = new ltext(/*column name:*/"ComputerName",/*column name in languages:*/"ComputerName","ComputerName");

        public Log_Computer_lang()
        {
        
                    col_headers.Add(id_collangname);

                    col_headers.Add(ComputerName_collangname);

               }
          }

    public class Log_Description_lang
    {
        public List<ltext> col_headers = new List<ltext>();
        public ltext s_TableName = new ltext(/*table name:*/"Log_Description",/*table name in languages:*/"Log_Description","Log_Description");
                    public ltext id_collangname = new ltext(/*column name:*/"id",/*column name in languages:*/"id","id");

                    public ltext Description_collangname = new ltext(/*column name:*/"Description",/*column name in languages:*/"Description","Description");

        public Log_Description_lang()
        {
        
                    col_headers.Add(id_collangname);

                    col_headers.Add(Description_collangname);

               }
          }

    public class Log_PathFile_lang
    {
        public List<ltext> col_headers = new List<ltext>();
        public ltext s_TableName = new ltext(/*table name:*/"Log_PathFile",/*table name in languages:*/"Log_PathFile","Log_PathFile");
                    public ltext id_collangname = new ltext(/*column name:*/"id",/*column name in languages:*/"id","id");

                    public ltext PathFile_collangname = new ltext(/*column name:*/"PathFile",/*column name in languages:*/"PathFile","PathFile");

        public Log_PathFile_lang()
        {
        
                    col_headers.Add(id_collangname);

                    col_headers.Add(PathFile_collangname);

               }
          }

    public class Log_Program_lang
    {
        public List<ltext> col_headers = new List<ltext>();
        public ltext s_TableName = new ltext(/*table name:*/"Log_Program",/*table name in languages:*/"Log_Program","Log_Program");
                    public ltext id_collangname = new ltext(/*column name:*/"id",/*column name in languages:*/"id","id");

                    public ltext Program_collangname = new ltext(/*column name:*/"Program",/*column name in languages:*/"Program","Program");

        public Log_Program_lang()
        {
        
                    col_headers.Add(id_collangname);

                    col_headers.Add(Program_collangname);

               }
          }

    public class Log_Type_lang
    {
        public List<ltext> col_headers = new List<ltext>();
        public ltext s_TableName = new ltext(/*table name:*/"Log_Type",/*table name in languages:*/"Log_Type","Log_Type");
                    public ltext id_collangname = new ltext(/*column name:*/"id",/*column name in languages:*/"id","id");

                    public ltext TypeName_collangname = new ltext(/*column name:*/"TypeName",/*column name in languages:*/"TypeName","TypeName");

        public Log_Type_lang()
        {
        
                    col_headers.Add(id_collangname);

                    col_headers.Add(TypeName_collangname);

               }
          }

    public class Log_UserName_lang
    {
        public List<ltext> col_headers = new List<ltext>();
        public ltext s_TableName = new ltext(/*table name:*/"Log_UserName",/*table name in languages:*/"Log_UserName","Log_UserName");
                    public ltext id_collangname = new ltext(/*column name:*/"id",/*column name in languages:*/"id","id");

                    public ltext UserName_collangname = new ltext(/*column name:*/"UserName",/*column name in languages:*/"UserName","UserName");

        public Log_UserName_lang()
        {
        
                    col_headers.Add(id_collangname);

                    col_headers.Add(UserName_collangname);

               }
          }

    public class LogFile_lang
    {
        public List<ltext> col_headers = new List<ltext>();
        public ltext s_TableName = new ltext(/*table name:*/"LogFile",/*table name in languages:*/"LogFile","LogFile");
                    public ltext id_collangname = new ltext(/*column name:*/"id",/*column name in languages:*/"id","id");

                    public ltext LogFileImportTime_collangname = new ltext(/*column name:*/"LogFileImportTime",/*column name in languages:*/"LogFileImportTime","LogFileImportTime");

                    public ltext Log_Computer_id_collangname = new ltext(/*column name:*/"Log_Computer_id",/*column name in languages:*/"Log_Computer_id","Log_Computer_id");

                    public ltext Log_UserName_id_collangname = new ltext(/*column name:*/"Log_UserName_id",/*column name in languages:*/"Log_UserName_id","Log_UserName_id");

                    public ltext Log_Program_id_collangname = new ltext(/*column name:*/"Log_Program_id",/*column name in languages:*/"Log_Program_id","Log_Program_id");

                    public ltext Log_PathFile_id_collangname = new ltext(/*column name:*/"Log_PathFile_id",/*column name in languages:*/"Log_PathFile_id","Log_PathFile_id");

                    public ltext LogFile_Description_id_collangname = new ltext(/*column name:*/"LogFile_Description_id",/*column name in languages:*/"LogFile_Description_id","LogFile_Description_id");

        public LogFile_lang()
        {
        
                    col_headers.Add(id_collangname);

                    col_headers.Add(LogFileImportTime_collangname);

                    col_headers.Add(Log_Computer_id_collangname);

                    col_headers.Add(Log_UserName_id_collangname);

                    col_headers.Add(Log_Program_id_collangname);

                    col_headers.Add(Log_PathFile_id_collangname);

                    col_headers.Add(LogFile_Description_id_collangname);

               }
          }

    public class LogFile_Attachment_lang
    {
        public List<ltext> col_headers = new List<ltext>();
        public ltext s_TableName = new ltext(/*table name:*/"LogFile_Attachment",/*table name in languages:*/"LogFile_Attachment","LogFile_Attachment");
                    public ltext id_collangname = new ltext(/*column name:*/"id",/*column name in languages:*/"id","id");

                    public ltext LogFile_id_collangname = new ltext(/*column name:*/"LogFile_id",/*column name in languages:*/"LogFile_id","LogFile_id");

                    public ltext LogFile_Attachment_Type_id_collangname = new ltext(/*column name:*/"LogFile_Attachment_Type_id",/*column name in languages:*/"LogFile_Attachment_Type_id","LogFile_Attachment_Type_id");

                    public ltext Attachment_collangname = new ltext(/*column name:*/"Attachment",/*column name in languages:*/"Attachment","Attachment");

                    public ltext Description_collangname = new ltext(/*column name:*/"Description",/*column name in languages:*/"Description","Description");

        public LogFile_Attachment_lang()
        {
        
                    col_headers.Add(id_collangname);

                    col_headers.Add(LogFile_id_collangname);

                    col_headers.Add(LogFile_Attachment_Type_id_collangname);

                    col_headers.Add(Attachment_collangname);

                    col_headers.Add(Description_collangname);

               }
          }

    public class LogFile_Attachment_Type_lang
    {
        public List<ltext> col_headers = new List<ltext>();
        public ltext s_TableName = new ltext(/*table name:*/"LogFile_Attachment_Type",/*table name in languages:*/"LogFile_Attachment_Type","LogFile_Attachment_Type");
                    public ltext id_collangname = new ltext(/*column name:*/"id",/*column name in languages:*/"id","id");

                    public ltext Attachment_type_collangname = new ltext(/*column name:*/"Attachment_type",/*column name in languages:*/"Attachment_type","Attachment_type");

        public LogFile_Attachment_Type_lang()
        {
        
                    col_headers.Add(id_collangname);

                    col_headers.Add(Attachment_type_collangname);

               }
          }

    public class LogFile_Description_lang
    {
        public List<ltext> col_headers = new List<ltext>();
        public ltext s_TableName = new ltext(/*table name:*/"LogFile_Description",/*table name in languages:*/"LogFile_Description","LogFile_Description");
                    public ltext id_collangname = new ltext(/*column name:*/"id",/*column name in languages:*/"id","id");

                    public ltext Description_collangname = new ltext(/*column name:*/"Description",/*column name in languages:*/"Description","Description");

        public LogFile_Description_lang()
        {
        
                    col_headers.Add(id_collangname);

                    col_headers.Add(Description_collangname);

               }
          }

    public class sysdiagrams_lang
    {
        public List<ltext> col_headers = new List<ltext>();
        public ltext s_TableName = new ltext(/*table name:*/"sysdiagrams",/*table name in languages:*/"sysdiagrams","sysdiagrams");
                    public ltext name___collangname = new ltext(/*column name:*/"name__",/*column name in languages:*/"name__","name__");

                    public ltext principal_id_collangname = new ltext(/*column name:*/"principal_id",/*column name in languages:*/"principal_id","principal_id");

                    public ltext diagram_id_collangname = new ltext(/*column name:*/"diagram_id",/*column name in languages:*/"diagram_id","diagram_id");

                    public ltext version_collangname = new ltext(/*column name:*/"version",/*column name in languages:*/"version","version");

                    public ltext definition_collangname = new ltext(/*column name:*/"definition",/*column name in languages:*/"definition","definition");

        public sysdiagrams_lang()
        {
        
                    col_headers.Add(name___collangname);

                    col_headers.Add(principal_id_collangname);

                    col_headers.Add(diagram_id_collangname);

                    col_headers.Add(version_collangname);

                    col_headers.Add(definition_collangname);

               }
          }

}
