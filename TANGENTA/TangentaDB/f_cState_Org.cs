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
    public static class f_cState_Org
    {
        public static bool Get(string State, ref long cState_Org_ID)
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
                       
            string sql = @"select ID from cState_Org where " + scond_State;
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    cState_Org_ID = (long)dt.Rows[0]["ID"];
                    return true;
                }
                else
                {
                    sql = @"insert into cState_Org (State) values (" + sval_State + ")";
                    object objretx = null;
                    if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar, ref cState_Org_ID, ref objretx, ref Err, "cState_Org"))
                    {
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:f_cState_Org:Get:sql=" + sql + "\r\nErr=" + Err);
                        return false;
                    }
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:f_cState_Org:Get:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }
       

        internal static bool Get(string_v country_v, ref long_v cState_Org_ID_v)
        {
            if (country_v != null)
            {
                List<SQL_Parameter> lpar = new List<SQL_Parameter>();
                string spar = "@par";
                SQL_Parameter par = new SQL_Parameter(spar, SQL_Parameter.eSQL_Parameter.Nvarchar, false, country_v.v);
                lpar.Add(par);
                string sql = @"select ID from cState_Org where State = @par";
                DataTable dt = new DataTable();
                string Err = null;
                if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
                {
                    if (dt.Rows.Count > 0)
                    {
                        if (cState_Org_ID_v == null)
                        {
                            cState_Org_ID_v = new long_v();
                        }
                        cState_Org_ID_v.v = (long)dt.Rows[0]["ID"];
                        return true;
                    }
                    else
                    {
                        sql = @"insert into cState_Org (State) values (@par)";
                        long cState_Org_ID = -1;
                        object oret = null;
                        if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar, ref cState_Org_ID, ref oret, ref Err, "cState_Org"))
                        {
                            if (cState_Org_ID_v == null)
                            {
                                cState_Org_ID_v = new long_v();
                            }
                            cState_Org_ID_v.v = cState_Org_ID;
                            return true;
                        }
                        else
                        {
                            LogFile.Error.Show("ERROR:TangentaDB:f_cState_Org:Get(string_v country_v, ref long_v atom_cState_Org_ID_v) sql=" + sql + "\r\nErr=" + Err);
                            return false;
                        }
                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:TangentaDB:f_cState_Org:Get(string_v country_v, ref long_v atom_cState_Org_ID_v) sql=" + sql + "\r\nErr=" + Err);
                    return false;
                }
            }
            else
            {
                cState_Org_ID_v = null;
                return true;
            }
        }

        public static bool DeleteAll()
        {

            string Err = null;
            string sql_delete = null;
            switch (DBSync.DBSync.m_DBType)
            {
                case DBConnection.eDBType.SQLITE:
                    sql_delete = @"delete from cState_Org;
                                  delete from sqlite_sequence where name = 'cState_Org";
                    break;
                case DBConnection.eDBType.MSSQL:
                    sql_delete = @"delete from cState_Org;
                                   DBCC CHECKIDENT ('[cState_Org]', RESEED, 0);";
                    break;
            }
            object oret = null;
            if (DBSync.DBSync.ExecuteNonQuerySQL(sql_delete, null, ref oret, ref Err))
            {
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:f_cState_Org:DeleteAll:sql=" + sql_delete + "\r\nErr=" + Err);
                return false;
            }
        }
    }
}
