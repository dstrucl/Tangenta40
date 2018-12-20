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
            private string m_Name = null;

            private ID m_ID = null;
            public ID ID
            {
                get { return m_ID; }
                set { m_ID = value; }
            }

            public string Name
            {
                get { return m_Name; }
                set { m_Name = value; }
            }

            private int m_LanguageIndex = -1;
            public int LanguageIndex
            {
                get { return m_LanguageIndex; }
                set { m_LanguageIndex = value; }
            }

            public string m_Description = null;
            public string Description
            {
                get { return m_Description; }
                set { m_Description = value; }
            }
            public Language(string Language_Name, string Language_Description)
            {
                m_Name = Language_Name;
                m_Description = Language_Description;
            }
        }

        public List<Language> Language_list = new List<Language>();

        public ID Language_ID
        {
            get
            {
                return new ID(Language_list[LanguageControl.DynSettings.LanguageID].ID);
            }
        }


        public Language_definitions()
        {
        }

        public bool Get(Transaction transaction)
        {
            int i = 0;
            int index = 0;
            string err = null;
            for (i = 0; i < LanguageControl.DynSettings.s_language.sTextArr.Length; i++)
            {
                if (LanguageControl.DynSettings.s_language.sTextArr[i] != null)
                {
                    string_v Description_v = new string_v(LanguageControl.DynSettings.s_language.sTextArr[i]);
                    Language lang = new Language(LanguageControl.DynSettings.s_language.sTextArr[i], Description_v.v);
                    ID xLanguage_ID = null;
                    if (f_Language.Get(LanguageControl.DynSettings.s_language.sTextArr[i], Description_v, index, ref xLanguage_ID, transaction))
                    {
                        lang.ID = xLanguage_ID;
                        Language_list.Add(lang);
                        index++;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return true;
        }



        public bool Read(Transaction transaction)
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
                        Set(lang, transaction);
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
                        lang.ID = tf.set_ID(dr["ID"]);
                        lang.LanguageIndex = (int)dr["LanguageIndex"];
                        return true;
                    }
                }
            }
            return false;
        }

        private bool Set(Language lang, Transaction transaction)
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

          
            string sql = "insert into Language (Name,Description,LanguageIndex) values (" + sval_Name + "," + sval_Description + "," + sval_LanguageIndex + ")";
            ID dpt_id = null;
            string Err = null;
            if (transaction.ExecuteNonQuerySQLReturnID(DBSync.DBSync.Con,sql, lpar, ref dpt_id, ref Err, "Language"))
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
    

