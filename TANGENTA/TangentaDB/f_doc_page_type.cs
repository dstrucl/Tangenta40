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
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TangentaDB
{
    public static class f_doc_page_type
    {
        public static bool Get(string Name, string_v Description_v, decimal_v Width_v,decimal_v Height_v, ref long doc_page_type_ID)
        {
            string Err = null;
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            //Table doc_page_type

            //Table Language
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

            string spar_Width = "@par_Width";
            string sval_Width = "null";
            if (Width_v != null)
            {
                SQL_Parameter par_Width = new SQL_Parameter(spar_Width, SQL_Parameter.eSQL_Parameter.Decimal, false, Width_v.v);
                lpar.Add(par_Width);
                sval_Width = spar_Width;
            }

            string spar_Height = "@par_Height";
            string sval_Height = "null";
            if (Height_v != null)
            {
                SQL_Parameter par_Height = new SQL_Parameter(spar_Height, SQL_Parameter.eSQL_Parameter.Decimal, false, Height_v.v);
                lpar.Add(par_Height);
                sval_Height = spar_Height;
            }


            string sql = "select ID from doc_page_type where Name = " + spar_Name + " and Description = " + sval_Description + " and Width = " + sval_Width + " and Height = " + sval_Height;

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
                    sql = "insert into doc_page_type (Name,Description,Width,Height)values(" + spar_Name + "," + sval_Description + "," + sval_Width + "," + sval_Height + ")";
                    object oret = null;
                    if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar, ref doc_page_type_ID, ref oret, ref Err, "doc_page_type"))
                    {
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:f_doc_page_type:Get:sql=" + sql + "\r\nErr=" + Err);
                        return false;
                    }
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:f_doc_page_type:Get:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }

        public static bool Get(long doc_page_type_ID,ref string_v Name_v,ref string_v Description_v,ref decimal_v Width_v, ref decimal_v Height_v)
        {
            string Err = null;
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            //Table doc_page_type

            //Table Language
            string spar_ID = "@par_ID";
            SQL_Parameter par_ID = new SQL_Parameter(spar_ID, SQL_Parameter.eSQL_Parameter.Bigint, false, doc_page_type_ID);
            lpar.Add(par_ID);


            string sql = "select Name,Description,Width,Height from doc_page_type where ID = "+ spar_ID;

            DataTable dt = new DataTable();
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    Name_v = tf.set_string(dt.Rows[0]["Name"]);
                    Description_v = tf.set_string(dt.Rows[0]["Description"]);
                    Width_v = tf.set_decimal(dt.Rows[0]["Width"]);
                    Height_v = tf.set_decimal(dt.Rows[0]["Height"]);
                }
                else
                {
                    Name_v = null;
                    Description_v = null;
                    Width_v = null;
                    Height_v = null;

                }
                return true;
            }
            else
            {
                Name_v = null;
                Description_v = null;
                Width_v = null;
                Height_v = null;
                LogFile.Error.Show("ERROR:f_doc_page_type:Get:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }
    }
}
