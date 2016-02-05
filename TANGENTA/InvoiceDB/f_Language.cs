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

namespace InvoiceDB
{
    public static class f_Language
    {
        public static bool Get(string Name,string_v Description_v,ref long Language_ID)
        {
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();

            //Table Language
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

            string sql = "select ID from Language where Name = " + spar_Name + " and Description = " + sval_Description;
            DataTable dt = new DataTable();
            string Err = null;
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    Language_ID = (long)dt.Rows[0]["ID"];
                    return true;
                }
                else
                {
                    sql = "insert into Language (Name,Description,bDefault)values(" + spar_Name + "," + sval_Description + ",0)";
                    object oret = null;
                    if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar, ref Language_ID, ref oret, ref Err, "Language"))
                    {
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:f_doc:InsertDefault:sql=" + sql + "\r\nErr=" + Err);
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
        public static bool SetDefault(long Language_ID)
        {
            object oret = null;
            string Err = null;
            string sql = "update Language set bDefault = 0";
            if (DBSync.DBSync.ExecuteNonQuerySQL(sql,null, ref oret, ref Err))
            {
                sql = "update Language set bDefault = 1 where ID = " + Language_ID.ToString();
                if (DBSync.DBSync.ExecuteNonQuerySQL(sql, null, ref oret, ref Err))
                {
                    return true;
                }
                else
                {
                    LogFile.Error.Show("ERROR:f_doc:SetDefault:sql=" + sql + "\r\nErr=" + Err);
                    return false;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:f_doc:SetDefault:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }
    }
}
