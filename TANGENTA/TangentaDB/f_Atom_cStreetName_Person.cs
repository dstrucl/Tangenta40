﻿#region LICENSE 
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
    public static class f_Atom_cStreetName_Person
    {
        public static bool Get(ID cStreetName_Person_ID, ref ID Atom_cStreetName_Person_ID, Transaction transaction)
        {
            string Err = null;
            string sql = @"select StreetName from cStreetName_Person where ID = " + cStreetName_Person_ID.ToString();
            DataTable dt = new DataTable();
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, ref Err))
            {
                if (dt.Rows.Count > 0)
                {

                    object o_StreetName = dt.Rows[0]["StreetName"];
                    if (o_StreetName is string)
                    {
                        string StreetName = (string)o_StreetName;
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
                        dt.Columns.Clear();
                        dt.Clear();
                        sql = @"select ID from Atom_cStreetName_Person where " + scond_StreetName;
                        if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
                        {
                            if (dt.Rows.Count > 0)
                            {
                                if (Atom_cStreetName_Person_ID==null)
                                {
                                    Atom_cStreetName_Person_ID = new ID();
                                }
                                Atom_cStreetName_Person_ID.Set(dt.Rows[0]["ID"]);
                                return true;
                            }
                            else
                            {
                                sql = @"insert into Atom_cStreetName_Person (StreetName) values (" + sval_StreetName + ")";
                                if (transaction.ExecuteNonQuerySQLReturnID(DBSync.DBSync.Con,sql, lpar, ref Atom_cStreetName_Person_ID, ref Err, "Atom_cStreetName_Person"))
                                {
                                    return true;
                                }
                                else
                                {
                                    LogFile.Error.Show("ERROR:f_Atom_cStreetName_Person:Get:sql=" + sql + "\r\nErr=" + Err);
                                    return false;
                                }
                            }
                        }
                        else
                        {
                            LogFile.Error.Show("ERROR:f_Atom_cStreetName_Person:Get:sql=" + sql + "\r\nErr=" + Err);
                            return false;
                        }
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:f_Atom_cStreetName_Person:Get:1:No StreetName for cStreetName_Person_ID =" + cStreetName_Person_ID.ToString());
                        return false;
                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:f_Atom_cStreetName_Person:Get:2:No StreetName for cStreetName_Person_ID =" + cStreetName_Person_ID.ToString());
                    return false;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:f_Atom_cStreetName_Person:Get:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }

        internal static bool Get(string_v streetName_v, ref ID atom_cStreetName_Person_ID, Transaction transaction)
        {
            if (streetName_v != null)
            {
                List<SQL_Parameter> lpar = new List<SQL_Parameter>();
                string spar = "@par";
                SQL_Parameter par = new SQL_Parameter(spar, SQL_Parameter.eSQL_Parameter.Nvarchar, false, streetName_v.v);
                lpar.Add(par);
                string sql = @"select ID from Atom_cStreetName_Person where StreetName = @par";
                DataTable dt = new DataTable();
                string Err = null;
                if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
                {
                    if (dt.Rows.Count > 0)
                    {
                        if (atom_cStreetName_Person_ID == null)
                        {
                            atom_cStreetName_Person_ID = new ID();
                        }
                        atom_cStreetName_Person_ID.Set(dt.Rows[0]["ID"]);
                        return true;
                    }
                    else
                    {
                       
                        sql = @"insert into Atom_cStreetName_Person (StreetName) values (@par)";
                        if (transaction.ExecuteNonQuerySQLReturnID(DBSync.DBSync.Con,sql, lpar, ref atom_cStreetName_Person_ID,  ref Err, "Atom_cStreetName_Person"))
                        {
                            return true;
                        }
                        else
                        {
                            LogFile.Error.Show("ERROR:TangentaDB:f_Atom_cStreetName_Person:Get(string_v streetName_v, ref ID atom_cStreetName_Person_ID) sql=" + sql + "\r\nErr=" + Err);
                            return false;
                        }
                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:TangentaDB:f_Atom_cStreetName_Person:Get(string_v streetName_v, ref ID atom_cStreetName_Person_ID) sql=" + sql + "\r\nErr=" + Err);
                    return false;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:TangentaDB:f_Atom_cStreetName_Person:Get(string_v streetName_v, ref ID atom_cStreetName_Person_ID) streetName_v may not be null!");
                return false;
            }
        }
    }
}
