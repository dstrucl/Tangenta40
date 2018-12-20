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
using System.Windows.Forms;

namespace TangentaDB
{
    public static class f_Language
    {
        public static bool Get(string Name,string_v Description_v,int Index,ref ID Language_ID, Transaction transaction)
        {
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();

            //Table Language
            string spar_LanguageIndex = "@par_LanguageIndex";
            SQL_Parameter par_LanguageIndex = new SQL_Parameter(spar_LanguageIndex, SQL_Parameter.eSQL_Parameter.Int, false, Index);
            lpar.Add(par_LanguageIndex);

            string spar_Name = "@par_Name";
            SQL_Parameter par_Name = new SQL_Parameter(spar_Name, SQL_Parameter.eSQL_Parameter.Nvarchar, false, Name);
            lpar.Add(par_Name);

            string spar_Description = "@par_Description";
            string sval_Description = "null";
            if (Description_v != null)
            {
                SQL_Parameter par_Description = new SQL_Parameter(spar_Description, SQL_Parameter.eSQL_Parameter.Nvarchar, false, Description_v.v);
                lpar.Add(par_Description);
                sval_Description = spar_Description;
            }

            string sql = "select ID from Language where LanguageIndex = "+ spar_LanguageIndex + " and Name = " + spar_Name + " and Description = " + sval_Description;
            DataTable dt = new DataTable();
            string Err = null;
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    if (Language_ID==null)
                    {
                        Language_ID = new ID();
                    }
                    Language_ID.Set(dt.Rows[0]["ID"]);
                    return true;
                }
                else
                {
                    sql = "insert into Language (LanguageIndex,Name,Description,bDefault)values(" + spar_LanguageIndex + "," + spar_Name + "," + sval_Description + ",0)";
                    if (transaction.ExecuteNonQuerySQLReturnID(DBSync.DBSync.Con,sql, lpar, ref Language_ID, ref Err, "Language"))
                    {
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:f_Language:Get:sql=" + sql + "\r\nErr=" + Err);
                        return false;
                    }
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:f_Language:Get:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }
 
        public static bool Get(ID Language_ID, ref string_v Name_v,ref string_v Description_v,ref int_v LanguageIndex_v)
        {
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();

            //Table Language
            string spar_Language_ID = "@par_Language_ID";
            SQL_Parameter par_Language_ID = new SQL_Parameter(spar_Language_ID, false, Language_ID);
            lpar.Add(par_Language_ID);


            string sql = "select Name,Description,LanguageIndex from Language where ID = " + spar_Language_ID;
            DataTable dt = new DataTable();
            string Err = null;
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    Name_v = tf.set_string(dt.Rows[0]["Name"]);
                    Description_v = tf.set_string(dt.Rows[0]["Description"]);
                    LanguageIndex_v = tf.set_int(dt.Rows[0]["LanguageIndex"]);
                }
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:f_Language:Get:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }

        public static bool SetDefault(ID Language_ID, Transaction transaction)
        {
            string Err = null;
            string sql = "update Language set bDefault = 0";
            if (transaction.ExecuteNonQuerySQL(DBSync.DBSync.Con,sql, null,  ref Err))
            {
                sql = "update Language set bDefault = 1 where ID = " + Language_ID.ToString();
                if (transaction.ExecuteNonQuerySQL(DBSync.DBSync.Con,sql, null,  ref Err))
                {
                    return true;
                }
                else
                {
                    LogFile.Error.Show("ERROR:f_Language:SetDefault:sql=" + sql + "\r\nErr=" + Err);
                    return false;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:f_Language:SetDefault:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }

        public static bool SetDefault(int LanguageIndex, Transaction transaction)
        {

            string Err = null;
            string sql = "update Language set bDefault = 0";
            if (transaction.ExecuteNonQuerySQL(DBSync.DBSync.Con,sql, null, ref Err))
            {
                sql = "update Language set bDefault = 1 where LanguageIndex = " + LanguageIndex.ToString();
                if (transaction.ExecuteNonQuerySQL(DBSync.DBSync.Con,sql, null, ref Err))
                {
                    return true;
                }
                else
                {
                    LogFile.Error.Show("ERROR:f_Language:SetDefault:sql=" + sql + "\r\nErr=" + Err);
                    return false;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:f_Language:SetDefault:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }
    }
}
