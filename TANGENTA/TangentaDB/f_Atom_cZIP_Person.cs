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
    public static class f_Atom_cZIP_Person
    {
        public static bool Get(ID cZIP_Person_ID, ref ID Atom_cZIP_Person_ID)
        {
            string Err = null;
            string sql = @"select ZIP from cZIP_Person where ID = " + cZIP_Person_ID.ToString();
            DataTable dt = new DataTable();
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, ref Err))
            {
                if (dt.Rows.Count > 0)
                {

                    object o_ZIP = dt.Rows[0]["ZIP"];
                    if (o_ZIP is string)
                    {
                        string ZIP = (string)o_ZIP;
                        List<SQL_Parameter> lpar = new List<SQL_Parameter>();
                        string scond_ZIP = null;
                        string sval_ZIP = "null";
                        if (ZIP != null)
                        {
                            string spar_ZIP = "@par_ZIP";
                            SQL_Parameter par_ZIP = new SQL_Parameter(spar_ZIP, SQL_Parameter.eSQL_Parameter.Nvarchar, false, ZIP);
                            lpar.Add(par_ZIP);
                            scond_ZIP = "ZIP = " + spar_ZIP;
                            sval_ZIP = spar_ZIP;
                        }
                        else
                        {
                            scond_ZIP = "ZIP is null";
                            sval_ZIP = "null";
                        }
                        dt.Columns.Clear();
                        dt.Clear();
                        sql = @"select ID from Atom_cZIP_Person where " + scond_ZIP;
                        if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
                        {
                            if (dt.Rows.Count > 0)
                            {
                                if (Atom_cZIP_Person_ID==null)
                                {
                                    Atom_cZIP_Person_ID = new ID();
                                }
                                Atom_cZIP_Person_ID.Set(dt.Rows[0]["ID"]);
                                return true;
                            }
                            else
                            {
                                sql = @"insert into Atom_cZIP_Person (ZIP) values (" + sval_ZIP + ")";
                                if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar, ref Atom_cZIP_Person_ID,  ref Err, "Atom_cZIP_Person"))
                                {
                                    return true;
                                }
                                else
                                {
                                    LogFile.Error.Show("ERROR:f_Atom_cZIP_Person:Get:sql=" + sql + "\r\nErr=" + Err);
                                    return false;
                                }
                            }
                        }
                        else
                        {
                            LogFile.Error.Show("ERROR:f_Atom_cZIP_Person:Get:sql=" + sql + "\r\nErr=" + Err);
                            return false;
                        }
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:f_Atom_cZIP_Person:Get:1:No ZIP for cZIP_Person_ID =" + cZIP_Person_ID.ToString());
                        return false;
                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:f_Atom_cZIP_Person:Get:2:No ZIP for cZIP_Person_ID =" + cZIP_Person_ID.ToString());
                    return false;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:f_Atom_cZIP_Person:Get:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }

        internal static bool Get(string_v zIP_v, ref ID atom_cZIP_Person_ID)
        {
            if (zIP_v != null)
            {
                List<SQL_Parameter> lpar = new List<SQL_Parameter>();
                string spar = "@par";
                SQL_Parameter par = new SQL_Parameter(spar, SQL_Parameter.eSQL_Parameter.Nvarchar, false, zIP_v.v);
                lpar.Add(par);
                string sql = @"select ID from Atom_cZIP_Person where ZIP = @par";
                DataTable dt = new DataTable();
                string Err = null;
                if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
                {
                    if (dt.Rows.Count > 0)
                    {
                        if (atom_cZIP_Person_ID == null)
                        {
                            atom_cZIP_Person_ID = new ID();
                        }
                        atom_cZIP_Person_ID.Set(dt.Rows[0]["ID"]);
                        return true;
                    }
                    else
                    {
                        sql = @"insert into Atom_cZIP_Person (ZIP) values (@par)";
                        if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar, ref atom_cZIP_Person_ID, ref Err, "Atom_cZIP_Person"))
                        {
                            return true;
                        }
                        else
                        {
                            LogFile.Error.Show("ERROR:TangentaDB:f_Atom_cZIP_Person:Get(string_v zIP_v, ref ID atom_cZIP_Person_ID) sql=" + sql + "\r\nErr=" + Err);
                            return false;
                        }
                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:TangentaDB:f_Atom_cZIP_Person:Get(string_v zIP_v, ref ID atom_cZIP_Person_ID) sql=" + sql + "\r\nErr=" + Err);
                    return false;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:TangentaDB:f_Atom_cZIP_Person:Get(string_v zIP_v, ref ID atom_cZIP_Person_ID) zIP_v may not be null!");
                return false;
            }
        }
    }
}
