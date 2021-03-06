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
    public static class f_Atom_cHouseNumber_Person
    {
        public static bool Get(long cHouseNumber_Person_ID, ref long Atom_cHouseNumber_Person_ID)
        {
            string Err = null;
            string sql = @"select HouseNumber from cHouseNumber_Person where ID = " + cHouseNumber_Person_ID.ToString();
            DataTable dt = new DataTable();
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, ref Err))
            {
                if (dt.Rows.Count > 0)
                {

                    object o_HouseNumber = dt.Rows[0]["HouseNumber"];
                    if (o_HouseNumber is string)
                    {
                        string HouseNumber = (string)o_HouseNumber;
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
                        dt.Columns.Clear();
                        dt.Clear();
                        sql = @"select ID from Atom_cHouseNumber_Person where " + scond_HouseNumber;
                        if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
                        {
                            if (dt.Rows.Count > 0)
                            {
                                Atom_cHouseNumber_Person_ID = (long)dt.Rows[0]["ID"];
                                return true;
                            }
                            else
                            {
                                sql = @"insert into Atom_cHouseNumber_Person (HouseNumber) values (" + sval_HouseNumber + ")";
                                object objretx = null;
                                if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar, ref Atom_cHouseNumber_Person_ID, ref objretx, ref Err, "Atom_cHouseNumber_Person"))
                                {
                                    return true;
                                }
                                else
                                {
                                    LogFile.Error.Show("ERROR:f_Atom_cHouseNumber_Person:Get:sql=" + sql + "\r\nErr=" + Err);
                                    return false;
                                }
                            }
                        }
                        else
                        {
                            LogFile.Error.Show("ERROR:f_Atom_cHouseNumber_Person:Get:sql=" + sql + "\r\nErr=" + Err);
                            return false;
                        }
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:f_Atom_cHouseNumber_Person:Get:1:No HouseNumber for cHouseNumber_Person_ID =" + cHouseNumber_Person_ID.ToString());
                        return false;
                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:f_Atom_cHouseNumber_Person:Get:2:No HouseNumber for cHouseNumber_Person_ID =" + cHouseNumber_Person_ID.ToString());
                    return false;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:f_Atom_cHouseNumber_Person:Get:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }

        internal static bool Get(string_v houseNumber_v, ref long_v atom_cHouseNumber_Person_ID_v)
        {
            if (houseNumber_v != null)
            {
                List<SQL_Parameter> lpar = new List<SQL_Parameter>();
                string spar = "@par";
                SQL_Parameter par = new SQL_Parameter(spar, SQL_Parameter.eSQL_Parameter.Nvarchar, false, houseNumber_v.v);
                lpar.Add(par);
                string sql = @"select ID from Atom_cHouseNumber_Person where HouseNumber = @par";
                DataTable dt = new DataTable();
                string Err = null;
                if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
                {
                    if (dt.Rows.Count > 0)
                    {
                        if (atom_cHouseNumber_Person_ID_v == null)
                        {
                            atom_cHouseNumber_Person_ID_v = new long_v();
                        }
                        atom_cHouseNumber_Person_ID_v.v = (long)dt.Rows[0]["ID"];
                        return true;
                    }
                    else
                    {
                        sql = @"insert into Atom_cHouseNumber_Person (HouseNumber) values (@par)";
                        long Atom_cHouseNumber_Person_ID = -1;
                        object oret = null;
                        if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar, ref Atom_cHouseNumber_Person_ID, ref oret, ref Err, "Atom_cHouseNumber_Person"))
                        {
                            if (atom_cHouseNumber_Person_ID_v == null)
                            {
                                atom_cHouseNumber_Person_ID_v = new long_v();
                            }
                            atom_cHouseNumber_Person_ID_v.v = Atom_cHouseNumber_Person_ID;
                            return true;
                        }
                        else
                        {
                            LogFile.Error.Show("ERROR:TangentaDB:f_Atom_cHouseNumber_Person:Get(string_v houseNumber_v, ref long_v atom_cHouseNumber_Person_ID_v) sql=" + sql + "\r\nErr=" + Err);
                            return false;
                        }
                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:TangentaDB:f_Atom_cHouseNumber_Person:Get(string_v houseNumber_v, ref long_v atom_cHouseNumber_Person_ID_v) sql=" + sql + "\r\nErr=" + Err);
                    return false;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:TangentaDB:f_Atom_cHouseNumber_Person:Get(string_v houseNumber_v, ref long_v atom_cHouseNumber_Person_ID_v) houseNumber_v may not be null!");
                return false;
            }
        }
    }
}
