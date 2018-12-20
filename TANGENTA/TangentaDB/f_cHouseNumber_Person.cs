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
    public static class f_cHouseNumber_Person
    {
        public static bool Get(string HouseNumber, ref ID cHouseNumber_Person_ID, Transaction transaction)
        {
            string Err = null;
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            string scond_HouseNumber = null;
            string sval_HouseNumber = "null";
            if (HouseNumber != null)
            {
                string spar_HouseNumber = "@par_HouseNumber";
                SQL_Parameter par_HouseNumber = new SQL_Parameter(spar_HouseNumber, SQL_Parameter.eSQL_Parameter.Nvarchar, false, HouseNumber);
                lpar.Add(par_HouseNumber);
                scond_HouseNumber = "HouseNumber = " + spar_HouseNumber;
                sval_HouseNumber = spar_HouseNumber;
            }
            else
            {
                scond_HouseNumber = "HouseNumber is null";
                sval_HouseNumber = "null";
            }
            DataTable dt = new DataTable();
            string sql = @"select ID from cHouseNumber_Person where " + scond_HouseNumber;
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    if (cHouseNumber_Person_ID==null)
                    {
                        cHouseNumber_Person_ID = new ID();
                    }
                    cHouseNumber_Person_ID.Set(dt.Rows[0]["ID"]);
                    return true;
                }
                else
                {
                    sql = @"insert into cHouseNumber_Person (HouseNumber) values (" + sval_HouseNumber + ")";
                    if (transaction.ExecuteNonQuerySQLReturnID(DBSync.DBSync.Con,sql, lpar, ref cHouseNumber_Person_ID,  ref Err, "cHouseNumber_Person"))
                    {
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:f_cHouseNumber_Person:Get:sql=" + sql + "\r\nErr=" + Err);
                        return false;
                    }
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:f_cHouseNumber_Person:Get:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }

        internal static bool Get(string_v houseNumber_v, ref ID cHouseNumber_Person_ID, Transaction transaction)
        {
            if (houseNumber_v != null)
            {
                List<SQL_Parameter> lpar = new List<SQL_Parameter>();
                string spar = "@par";
                SQL_Parameter par = new SQL_Parameter(spar, SQL_Parameter.eSQL_Parameter.Nvarchar, false, houseNumber_v.v);
                lpar.Add(par);
                string sql = @"select ID from cHouseNumber_Person where HouseNumber = @par";
                DataTable dt = new DataTable();
                string Err = null;
                if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
                {
                    if (dt.Rows.Count > 0)
                    {
                        if (cHouseNumber_Person_ID == null)
                        {
                            cHouseNumber_Person_ID = new ID();
                        }
                        cHouseNumber_Person_ID.Set(dt.Rows[0]["ID"]);
                        return true;
                    }
                    else
                    {
                        sql = @"insert into cHouseNumber_Person (HouseNumber) values (@par)";
                        if (transaction.ExecuteNonQuerySQLReturnID(DBSync.DBSync.Con,sql, lpar, ref cHouseNumber_Person_ID,  ref Err, "cHouseNumber_Person"))
                        {
                            return true;
                        }
                        else
                        {
                            LogFile.Error.Show("ERROR:TangentaDB:f_cHouseNumber_Person:Get(string_v houseNumber_v, ref ID atom_cHouseNumber_Person_ID_v) sql=" + sql + "\r\nErr=" + Err);
                            return false;
                        }
                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:TangentaDB:f_cHouseNumber_Person:Get(string_v houseNumber_v, ref ID atom_cHouseNumber_Person_ID_v) sql=" + sql + "\r\nErr=" + Err);
                    return false;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:TangentaDB:f_cHouseNumber_Person:Get(string_v houseNumber_v, ref ID atom_cHouseNumber_Person_ID_v) houseNumber_v may not be null!");
                return false;
            }
        }
    }
}
