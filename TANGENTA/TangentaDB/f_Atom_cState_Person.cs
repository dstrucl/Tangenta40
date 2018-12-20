
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
    public static class f_Atom_cState_Person
    {
        public static bool Get(ID cState_Person_ID, ref ID Atom_cState_Person_ID, Transaction transaction)
        {
            string Err = null;
            string sql = @"select State from cState_Person where ID = " + cState_Person_ID.ToString();
            DataTable dt = new DataTable();
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, ref Err))
            {
                if (dt.Rows.Count > 0)
                {

                    object o_State = dt.Rows[0]["State"];
                    if (o_State is string)
                    {
                        string State = (string)o_State;
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
                        dt.Columns.Clear();
                        dt.Clear();
                        sql = @"select ID from Atom_cState_Person where " + scond_State;
                        if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
                        {
                            if (dt.Rows.Count > 0)
                            {
                                if (Atom_cState_Person_ID==null)
                                {
                                    Atom_cState_Person_ID = new ID();
                                }
                                Atom_cState_Person_ID.Set(dt.Rows[0]["ID"]);
                                return true;
                            }
                            else
                            {
                                sql = @"insert into Atom_cState_Person (State) values (" + sval_State + ")";
                                if (transaction.ExecuteNonQuerySQLReturnID(DBSync.DBSync.Con,sql, lpar, ref Atom_cState_Person_ID, ref Err, "Atom_cState_Person"))
                                {
                                    return true;
                                }
                                else
                                {
                                    LogFile.Error.Show("ERROR:f_Atom_cState_Person:Get:sql=" + sql + "\r\nErr=" + Err);
                                    return false;
                                }
                            }
                        }
                        else
                        {
                            LogFile.Error.Show("ERROR:f_Atom_cState_Person:Get:sql=" + sql + "\r\nErr=" + Err);
                            return false;
                        }
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:f_Atom_cState_Person:Get:1:No State for cState_Person_ID =" + cState_Person_ID.ToString());
                        return false;
                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:f_Atom_cState_Person:Get:2:No State for cState_Person_ID =" + cState_Person_ID.ToString());
                    return false;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:f_Atom_cState_Person:Get:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }

        internal static bool Get(string_v country_v, ref ID atom_cState_Person_ID, Transaction transaction)
        {
            if (country_v != null)
            {
                List<SQL_Parameter> lpar = new List<SQL_Parameter>();
                string spar = "@par";
                SQL_Parameter par = new SQL_Parameter(spar, SQL_Parameter.eSQL_Parameter.Nvarchar, false, country_v.v);
                lpar.Add(par);
                string sql = @"select ID from Atom_cState_Person where State = @par";
                DataTable dt = new DataTable();
                string Err = null;
                if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
                {
                    if (dt.Rows.Count > 0)
                    {
                        if (atom_cState_Person_ID == null)
                        {
                            atom_cState_Person_ID = new ID();
                        }
                        atom_cState_Person_ID.Set(dt.Rows[0]["ID"]);
                        return true;
                    }
                    else
                    {
                        sql = @"insert into Atom_cState_Person (State) values (@par)";
                        if (transaction.ExecuteNonQuerySQLReturnID(DBSync.DBSync.Con,sql, lpar, ref atom_cState_Person_ID, ref Err, "Atom_cState_Person"))
                        {
                            return true;
                        }
                        else
                        {
                            LogFile.Error.Show("ERROR:TangentaDB:f_Atom_cState_Person:Get(string_v country_v, ref long_v atom_cState_Person_ID_v) sql=" + sql + "\r\nErr=" + Err);
                            return false;
                        }
                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:TangentaDB:f_Atom_cState_Person:Get(string_v country_v, ref long_v atom_cState_Person_ID_v) sql=" + sql + "\r\nErr=" + Err);
                    return false;
                }
            }
            else
            {
                atom_cState_Person_ID = null;
                return true;
            }
        }
    }
}
