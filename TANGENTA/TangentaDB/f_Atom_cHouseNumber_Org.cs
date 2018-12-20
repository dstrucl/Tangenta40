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
    public static class f_Atom_cHouseNumber_Org
    {
        public static bool Get(ID cHouseNumber_Org_ID, ref ID Atom_cHouseNumber_Org_ID, Transaction transaction)
        {
            string Err = null;
            string sql = @"select HouseNumber from cHouseNumber_Org where ID = " + cHouseNumber_Org_ID.ToString();
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
                        sql = @"select ID from Atom_cHouseNumber_Org where " + scond_HouseNumber;
                        if (DBSync.DBSync.ReadDataTable(ref dt, sql,lpar, ref Err))
                        {
                            if (dt.Rows.Count > 0)
                            {
                                if (Atom_cHouseNumber_Org_ID==null)
                                {
                                    Atom_cHouseNumber_Org_ID = new ID();
                                }
                                Atom_cHouseNumber_Org_ID.Set(dt.Rows[0]["ID"]);
                                return true;
                            }
                            else
                            {
                                sql = @"insert into Atom_cHouseNumber_Org (HouseNumber) values (" + sval_HouseNumber + ")";
                                if (transaction.ExecuteNonQuerySQLReturnID(DBSync.DBSync.Con,sql, lpar, ref Atom_cHouseNumber_Org_ID,  ref Err, "Atom_cHouseNumber_Org"))
                                {
                                    return true;
                                }
                                else
                                {
                                    LogFile.Error.Show("ERROR:f_Atom_cHouseNumber_Org:Get:sql=" + sql + "\r\nErr=" + Err);
                                    return false;
                                }
                            }
                        }
                        else
                        {
                            LogFile.Error.Show("ERROR:f_Atom_cHouseNumber_Org:Get:sql=" + sql + "\r\nErr=" + Err);
                            return false;
                        }
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:f_Atom_cHouseNumber_Org:Get:1:No HouseNumber for cHouseNumber_Org_ID =" + cHouseNumber_Org_ID.ToString());
                        return false;
                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:f_Atom_cHouseNumber_Org:Get:2:No HouseNumber for cHouseNumber_Org_ID =" + cHouseNumber_Org_ID.ToString());
                    return false;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:f_Atom_cHouseNumber_Org:Get:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }

        internal static bool Get(string_v houseNumber_v, ref ID atom_cHouseNumber_Org_ID, Transaction transaction)
        {
            if (houseNumber_v != null)
            {
                List<SQL_Parameter> lpar = new List<SQL_Parameter>();
                string spar = "@par";
                SQL_Parameter par = new SQL_Parameter(spar, SQL_Parameter.eSQL_Parameter.Nvarchar, false, houseNumber_v.v);
                lpar.Add(par);
                string sql = @"select ID from Atom_cHouseNumber_Org where HouseNumber = @par";
                DataTable dt = new DataTable();
                string Err = null;
                if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
                {
                    if (dt.Rows.Count > 0)
                    {
                        if (atom_cHouseNumber_Org_ID == null)
                        {
                            atom_cHouseNumber_Org_ID = new ID();
                        }
                        atom_cHouseNumber_Org_ID.Set(dt.Rows[0]["ID"]);
                        return true;
                    }
                    else
                    {
                        sql = @"insert into Atom_cHouseNumber_Org (HouseNumber) values (@par)";
                        if (transaction.ExecuteNonQuerySQLReturnID(DBSync.DBSync.Con,sql, lpar, ref atom_cHouseNumber_Org_ID,  ref Err, "Atom_cHouseNumber_Org"))
                        { 
                            return true;
                        }
                        else
                        {
                            LogFile.Error.Show("ERROR:TangentaDB:f_Atom_cHouseNumber_Org:Get(string_v houseNumber_v, ref ID atom_cHouseNumber_Org_ID) sql=" + sql + "\r\nErr=" + Err);
                            return false;
                        }
                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:TangentaDB:f_Atom_cHouseNumber_Org:Get(string_v houseNumber_v, ref ID atom_cHouseNumber_Org_ID) sql=" + sql + "\r\nErr=" + Err);
                    return false;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:TangentaDB:f_Atom_cHouseNumber_Org:Get(string_v houseNumber_v, ref ID atom_cHouseNumber_Org_ID) houseNumber_v may not be null!");
                return false;
            }
        }
    }
}
