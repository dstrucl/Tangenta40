using DBConnectionControl40;
using DBTypes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace TangentaDB
{
    public class Language_definitions
    {
        public class Language
        {
            public long ID = -1;
            public int LanguageIndex = -1;
            public string Name = null;
            public string Description = null;
            public Language(string Language_Name, string Language_Description)
            {
                Name = Language_Name;
                Description = Language_Description;
            }
        }

        public List<Language> Language_list = new List<Language>();

        public long_v Language_ID_v
        {
            get
            {
                return new long_v(Language_list[LanguageControl.DynSettings.LanguageID].ID);
            }
        }
                    

        public Language_definitions()
        {

            int i = 0;
            int index = 0;
            for (i = 0; i < LanguageControl.DynSettings.s_language.sTextArr.Length; i++)
            {
                if (LanguageControl.DynSettings.s_language.sTextArr[i] != null)
                {
                    string_v Description_v = new string_v(LanguageControl.DynSettings.s_language.sTextArr[i]);
                    Language lang = new Language(LanguageControl.DynSettings.s_language.sTextArr[i], Description_v.v);
                    if (f_Language.Get(LanguageControl.DynSettings.s_language.sTextArr[i], Description_v,index, ref lang.ID))
                    {
                        Language_list.Add(lang);
                        index++;
                    }
                }
            }
        }


        public bool Read()
        {
            string Err = null;
            string sql = "select Name, Description,LanguageIndex,ID from Language";
            DataTable dt = new DataTable();
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, ref Err))
            {

                foreach (Language lang in Language_list)
                {
                    if (Get(lang, dt))
                    {
                        continue;
                    }
                    else
                    {
                        Set(lang);
                    }
                }
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:TangentaDB:Language_definitions:Read:Err=" + Err);
                return false;
            }
        }

        private bool Get(Language lang, DataTable dt)
        {
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["Name"] is string)
                {
                    string sName = (string)dr["Name"];
                    if (lang.Name.Equals(sName))
                    {
                        lang.ID = (long)dr["ID"];
                        lang.LanguageIndex = (int)dr["LanguageIndex"];
                        return true;
                    }
                }
            }
            return false;
        }

        private bool Set(Language lang)
        {
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();

            string spar_Name = "@par_Name";
            SQL_Parameter par_Name = new SQL_Parameter(spar_Name, SQL_Parameter.eSQL_Parameter.Nvarchar, false, lang.Name);
            string sval_Name = spar_Name;
            lpar.Add(par_Name);

            string sval_Description = "null";
            if (lang.Description != null)
            {
                if (lang.Description.Length > 0)
                {
                    string spar_Description = "@par_Description";
                    SQL_Parameter par_Description = new SQL_Parameter(spar_Description, SQL_Parameter.eSQL_Parameter.Nvarchar, false, lang.Description);
                    sval_Description = spar_Description;
                    lpar.Add(par_Description);
                }
            }

            string sval_LanguageIndex = "null";
            string spar_LanguageIndex = "@par_LanguageIndex";
            SQL_Parameter par_LanguageIndex = new SQL_Parameter(spar_LanguageIndex, SQL_Parameter.eSQL_Parameter.Int, false, lang.LanguageIndex);
            sval_Description = spar_LanguageIndex;
            lpar.Add(par_LanguageIndex);


            string sql = "insert into Language (Name,Description,LanguageIndex) values (" + sval_Name + "," + sval_Description + ","+ sval_LanguageIndex + ")";
            long dpt_id = -1;
            object oret = null;
            string Err = null;
            if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar, ref dpt_id, ref oret, ref Err, "Language"))
            {
                lang.ID = dpt_id;
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:TangentaDB:Language_definitions:Set:Err= " + Err);
                return false;
            }
        }
    }
}
