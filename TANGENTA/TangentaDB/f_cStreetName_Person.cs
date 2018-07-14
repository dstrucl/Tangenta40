
#region LICENSE 
/*
    This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
    If a copy of the Tangenta Public License (TPL) was not distributed with this 
    file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion
using DBConnectionControl40;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBTypes;

namespace TangentaDB
{
    public static class f_cStreetName_Person
    {
        public static bool Get(string StreetName, ref ID cStreetName_Person_ID)
        {
            string Err = null;
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            string scond_StreetName = null;
            string sval_StreetName = "null";
            if (StreetName != null)
            {
                string spar_StreetName = "@par_StreetName";
                SQL_Parameter par_StreetName = new SQL_Parameter(spar_StreetName, SQL_Parameter.eSQL_Parameter.Nvarchar, false, StreetName);
                lpar.Add(par_StreetName);
                scond_StreetName = "StreetName = " + spar_StreetName;
                sval_StreetName = spar_StreetName;
            }
            else
            {
                scond_StreetName = "StreetName is null";
                sval_StreetName = "null";
            }
            DataTable dt = new DataTable();
            string sql = @"select ID from cStreetName_Person where " + scond_StreetName;
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    if (cStreetName_Person_ID==null)
                    {
                        cStreetName_Person_ID = new ID();
                    }
                    cStreetName_Person_ID.Set(dt.Rows[0]["ID"]);
                    return true;
                }
                else
                {
                    sql = @"insert into cStreetName_Person (StreetName) values (" + sval_StreetName + ")";
                    if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar, ref cStreetName_Person_ID,  ref Err, "cStreetName_Person"))
                    {
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:f_cStreetName_Person:Get:sql=" + sql + "\r\nErr=" + Err);
                        return false;
                    }
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:f_cStreetName_Person:Get:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }

        internal static bool Get(string_v streetName_v, ref ID cStreetName_Person_ID)
        {
            if (streetName_v != null)
            {
                List<SQL_Parameter> lpar = new List<SQL_Parameter>();
                string spar = "@par";
                SQL_Parameter par = new SQL_Parameter(spar, SQL_Parameter.eSQL_Parameter.Nvarchar, false, streetName_v.v);
                lpar.Add(par);
                string sql = @"select ID from cStreetName_Person where StreetName = @par";
                DataTable dt = new DataTable();
                string Err = null;
                if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
                {
                    if (dt.Rows.Count > 0)
                    {
                        if (cStreetName_Person_ID == null)
                        {
                            cStreetName_Person_ID = new ID();
                        }
                        cStreetName_Person_ID.Set(dt.Rows[0]["ID"]);
                        return true;
                    }
                    else
                    {
                        sql = @"insert into cStreetName_Person (StreetName) values (@par)";
                        if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar, ref cStreetName_Person_ID,  ref Err, "cStreetName_Person"))
                        {
                            return true;
                        }
                        else
                        {
                            LogFile.Error.Show("ERROR:TangentaDB:f_cStreetName_Person:Get(string_v streetName_v, ref ID cStreetName_Person_ID) sql=" + sql + "\r\nErr=" + Err);
                            return false;
                        }
                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:TangentaDB:f_cStreetName_Person:Get(string_v streetName_v, ref ID cStreetName_Person_ID) sql=" + sql + "\r\nErr=" + Err);
                    return false;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:TangentaDB:f_cStreetName_Person:Get(string_v streetName_v, ref ID cStreetName_Person_ID) streetName_v may not be null!");
                return false;
            }
        }
    }
}


