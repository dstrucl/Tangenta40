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
    public static class f_cCity_Person
    {
        public static bool Get(string City, ref ID cCity_Person_ID)
        {

            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            string scond_City = null;
            string sval_City = "null";
            if (City != null)
            {
                string spar_City = "@par_City";
                SQL_Parameter par_City = new SQL_Parameter(spar_City, SQL_Parameter.eSQL_Parameter.Nvarchar, false, City);
                lpar.Add(par_City);
                scond_City = "City = " + spar_City;
                sval_City = spar_City;
            }
            else
            {
                scond_City = "City is null";
                sval_City = "null";
            }
            DataTable dt = new DataTable();
            string Err = null;
            dt.Columns.Clear();
            dt.Clear();
            string sql = @"select ID from cCity_Person where " + scond_City;
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    if (cCity_Person_ID==null)
                    {
                        cCity_Person_ID = new ID();
                    }
                    cCity_Person_ID.Set(dt.Rows[0]["ID"]);
                    return true;
                }
                else
                {
                    sql = @"insert into cCity_Person (City) values (" + sval_City + ")";
                    if (transaction.ExecuteNonQuerySQLReturnID(DBSync.DBSync.Con,sql, lpar, ref cCity_Person_ID,  ref Err, "Atom_cCity_Person"))
                    {
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:f_cCity_Person:Get:sql=" + sql + "\r\nErr=" + Err);
                        return false;
                    }
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:f_cCity_Person:Get:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }

        }

        internal static bool Get(string_v city_v, ref ID cCity_Person_ID)
        {
            if (city_v != null)
            {
                List<SQL_Parameter> lpar = new List<SQL_Parameter>();
                string spar = "@par";
                SQL_Parameter par = new SQL_Parameter(spar, SQL_Parameter.eSQL_Parameter.Nvarchar, false, city_v.v);
                lpar.Add(par);
                string sql = @"select ID from cCity_Person where City = @par";
                DataTable dt = new DataTable();
                string Err = null;
                if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
                {
                    if (dt.Rows.Count > 0)
                    {
                        if (cCity_Person_ID == null)
                        {
                            cCity_Person_ID = new ID();
                        }
                        cCity_Person_ID.Set(dt.Rows[0]["ID"]);
                        return true;
                    }
                    else
                    {
                        sql = @"insert into cCity_Person (City) values (@par)";
                        if (transaction.ExecuteNonQuerySQLReturnID(DBSync.DBSync.Con,sql, lpar, ref cCity_Person_ID,  ref Err, "Atom_cCity_Person"))
                        {
                            return true;
                        }
                        else
                        {
                            LogFile.Error.Show("ERROR:TangentaDB:f_cCity_Person:Get(string_v city_v, ref long_v cCity_Person_ID_v) sql=" + sql + "\r\nErr=" + Err);
                            return false;
                        }
                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:TangentaDB:f_cCity_Person:Get(string_v city_v, ref long_v cCity_Person_ID_v) sql=" + sql + "\r\nErr=" + Err);
                    return false;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:TangentaDB:f_cCity_Person:Get(string_v city_v, ref long_v cCity_Person_ID_v) city_v may not be null!");
                return false;
            }
        }
    }
}
