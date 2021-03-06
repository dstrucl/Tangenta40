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
    public static class f_Atom_cCity_Person
    {
        public static bool Get(long cCity_Person_ID, ref long Atom_cCity_Person_ID)
        {
            string Err = null;
            string sql = @"select City from cCity_Person where ID = " + cCity_Person_ID.ToString();
            DataTable dt = new DataTable();
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, ref Err))
            {
                if (dt.Rows.Count > 0)
                {

                    object o_City = dt.Rows[0]["City"];
                    if (o_City is string)
                    {
                        string City = (string)o_City;
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
                        dt.Columns.Clear();
                        dt.Clear();
                        sql = @"select ID from Atom_cCity_Person where " + scond_City;
                        if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
                        {
                            if (dt.Rows.Count > 0)
                            {
                                Atom_cCity_Person_ID = (long)dt.Rows[0]["ID"];
                                return true;
                            }
                            else
                            {
                                sql = @"insert into Atom_cCity_Person (City) values (" + sval_City + ")";
                                object objretx = null;
                                if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar, ref Atom_cCity_Person_ID, ref objretx, ref Err, "Atom_cCity_Person"))
                                {
                                    return true;
                                }
                                else
                                {
                                    LogFile.Error.Show("ERROR:f_Atom_cCity_Person:Get:sql=" + sql + "\r\nErr=" + Err);
                                    return false;
                                }
                            }
                        }
                        else
                        {
                            LogFile.Error.Show("ERROR:f_Atom_cCity_Person:Get:sql=" + sql + "\r\nErr=" + Err);
                            return false;
                        }
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:f_Atom_cCity_Person:Get:1:No City for cCity_Person_ID =" + cCity_Person_ID.ToString());
                        return false;
                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:f_Atom_cCity_Person:Get:2:No City for cCity_Person_ID =" + cCity_Person_ID.ToString());
                    return false;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:f_Atom_cCity_Person:Get:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }

        internal static bool Get(string_v city_v, ref long_v atom_cCity_Person_ID_v)
        {
            if (city_v != null)
            {
                List<SQL_Parameter> lpar = new List<SQL_Parameter>();
                string spar = "@par";
                SQL_Parameter par = new SQL_Parameter(spar, SQL_Parameter.eSQL_Parameter.Nvarchar, false, city_v.v);
                lpar.Add(par);
                string sql = @"select ID from Atom_cCity_Person where City = @par";
                DataTable dt = new DataTable();
                string Err = null;
                if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
                {
                    if (dt.Rows.Count > 0)
                    {
                        if (atom_cCity_Person_ID_v == null)
                        {
                            atom_cCity_Person_ID_v = new long_v();
                        }
                        atom_cCity_Person_ID_v.v = (long)dt.Rows[0]["ID"];
                        return true;
                    }
                    else
                    {
                        sql = @"insert into Atom_cCity_Person (City) values (@par)";
                        long Atom_cCity_Person_ID = -1;
                        object oret = null;
                        if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar, ref Atom_cCity_Person_ID, ref oret, ref Err, "Atom_cCity_Person"))
                        {
                            if (atom_cCity_Person_ID_v == null)
                            {
                                atom_cCity_Person_ID_v = new long_v();
                            }
                            atom_cCity_Person_ID_v.v = Atom_cCity_Person_ID;
                            return true;
                        }
                        else
                        {
                            LogFile.Error.Show("ERROR:TangentaDB:f_Atom_cCity_Person:Get(string_v city_v, ref long_v atom_cCity_Person_ID_v) sql=" + sql + "\r\nErr=" + Err);
                            return false;
                        }
                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:TangentaDB:f_Atom_cCity_Person:Get(string_v city_v, ref long_v atom_cCity_Person_ID_v) sql=" + sql + "\r\nErr=" + Err);
                    return false;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:TangentaDB:f_Atom_cCity_Person:Get(string_v city_v, ref long_v atom_cCity_Person_ID_v) city_v may not be null!");
                return false;
            }
        }
    }
}
