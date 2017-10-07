#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion
using DBConnectionControl40;
using DBTypes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TangentaDB
{
    public static class f_doc_type
    {
        public static bool Get(string Name, string_v Description_v, long_v Language_ID_v, long_v doc_page_type_ID_v, ref long doc_page_type_ID)
        {
            string Err = null;
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            //Table doc_page_type


            string spar_Name = "@par_Name";
            SQL_Parameter par_Name = new SQL_Parameter(spar_Name, SQL_Parameter.eSQL_Parameter.Nvarchar, false, Name);
            lpar.Add(par_Name);


            string sval_Description = "null";

            if (Description_v != null)
            {
                string spar_Description = "@par_Description";

                SQL_Parameter par_Description = new SQL_Parameter(spar_Description, SQL_Parameter.eSQL_Parameter.Nvarchar, false, Description_v.v);
                lpar.Add(par_Description);
                sval_Description = spar_Description;
            }


            string sval_Language_ID = "null";

            if (Language_ID_v != null)
            {
                string spar_Language_ID = "@par_Language_ID";

                SQL_Parameter par_Language_ID = new SQL_Parameter(spar_Language_ID, SQL_Parameter.eSQL_Parameter.Bigint, false, Language_ID_v.v);
                lpar.Add(par_Language_ID);
                sval_Language_ID = spar_Language_ID;
            }

            string sval_doc_page_type_ID = "null";

            if (doc_page_type_ID_v != null)
            {
                string spar_doc_page_type_ID = "@par_doc_page_type_ID";

                SQL_Parameter par_doc_page_type_ID = new SQL_Parameter(spar_doc_page_type_ID, SQL_Parameter.eSQL_Parameter.Bigint, false, doc_page_type_ID_v.v);
                lpar.Add(par_doc_page_type_ID);
                sval_doc_page_type_ID = spar_doc_page_type_ID;
            }

            string sql = "select ID from doc_type where Name = " + spar_Name + " and Description = " + sval_Description + " and Language_ID = " + sval_Language_ID + " and doc_page_type_ID = " + sval_doc_page_type_ID;

            DataTable dt = new DataTable();
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    doc_page_type_ID = (long)dt.Rows[0]["ID"];
                    return true;
                }
                else
                {
                    sql = "insert into doc_type (Name,Description,Language_ID,doc_page_type_ID)values(" + spar_Name + "," + sval_Description +","+ sval_Language_ID + "," + sval_doc_page_type_ID + ")";
                    object oret = null;
                    if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar, ref doc_page_type_ID, ref oret, ref Err, "doc_page_type"))
                    {
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:f_doc_type:Get:sql=" + sql + "\r\nErr=" + Err);
                        return false;
                    }
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:f_doc_type:Get:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }
        public static bool Get(long doc_type_ID,ref string_v Name_v, ref string_v Description_v)
        {
            string Err = null;
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            //Table doc_page_type


            string spar_doc_type_ID = "@par_doc_type_ID";
            SQL_Parameter par_doc_type_ID = new SQL_Parameter(spar_doc_type_ID, SQL_Parameter.eSQL_Parameter.Bigint, false, doc_type_ID);
            lpar.Add(par_doc_type_ID);


            string sql = "select Name,Description from doc_type where ID = " + spar_doc_type_ID;

            Name_v = null;
            Description_v = null;
            DataTable dt = new DataTable();
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    Name_v = tf.set_string(dt.Rows[0]["Name"]);
                    Description_v = tf.set_string(dt.Rows[0]["Description"]);
                }
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:f_doc_type:Get:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }
    }
}
