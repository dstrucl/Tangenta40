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
    public static class f_cState_Person
    {
        public static bool Get(string State, ref long cState_Person_ID)
        {
            string Err = null;

            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            string scond_State = null;
            string sval_State = "null";
            if (State != null)
            {
                string spar_State = "@par_State";
                SQL_Parameter par_State = new SQL_Parameter(spar_State, SQL_Parameter.eSQL_Parameter.Nvarchar, false, State);
                lpar.Add(par_State);
                scond_State = "State = " + spar_State;
                sval_State = spar_State;
            }
            else
            {
                scond_State = "State is null";
                sval_State = "null";
            }
            DataTable dt = new DataTable();

            string sql = @"select ID from cState_Person where " + scond_State;
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    cState_Person_ID = (long)dt.Rows[0]["ID"];
                    return true;
                }
                else
                {
                    sql = @"insert into cState_Person (State) values (" + sval_State + ")";
                    object objretx = null;
                    if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar, ref cState_Person_ID, ref objretx, ref Err, "cState_Person"))
                    {
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:f_cState_Person:Get:sql=" + sql + "\r\nErr=" + Err);
                        return false;
                    }
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:f_cState_Person:Get:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }


        internal static bool Get(string_v country_v, ref long_v cState_Person_ID_v)
        {
            if (country_v != null)
            {
                List<SQL_Parameter> lpar = new List<SQL_Parameter>();
                string spar = "@par";
                SQL_Parameter par = new SQL_Parameter(spar, SQL_Parameter.eSQL_Parameter.Nvarchar, false, country_v.v);
                lpar.Add(par);
                string sql = @"select ID from cState_Person where State = @par";
                DataTable dt = new DataTable();
                string Err = null;
                if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
                {
                    if (dt.Rows.Count > 0)
                    {
                        if (cState_Person_ID_v == null)
                        {
                            cState_Person_ID_v = new long_v();
                        }
                        cState_Person_ID_v.v = (long)dt.Rows[0]["ID"];
                        return true;
                    }
                    else
                    {
                        sql = @"insert into cState_Person (State) values (@par)";
                        long cState_Person_ID = -1;
                        object oret = null;
                        if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar, ref cState_Person_ID, ref oret, ref Err, "cState_Person"))
                        {
                            if (cState_Person_ID_v == null)
                            {
                                cState_Person_ID_v = new long_v();
                            }
                            cState_Person_ID_v.v = cState_Person_ID;
                            return true;
                        }
                        else
                        {
                            LogFile.Error.Show("ERROR:TangentaDB:f_cState_Person:Get(string_v country_v, ref long_v atom_cState_Person_ID_v) sql=" + sql + "\r\nErr=" + Err);
                            return false;
                        }
                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:TangentaDB:f_cState_Person:Get(string_v country_v, ref long_v atom_cState_Person_ID_v) sql=" + sql + "\r\nErr=" + Err);
                    return false;
                }
            }
            else
            {
                cState_Person_ID_v = null;
                return true;
            }
        }
    }
}
