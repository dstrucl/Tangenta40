﻿using DBConnectionControl40;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tangenta
{
    public static class f_Atom_cStreetName_Org
    {
        public static bool Get(long cStreetName_Org_ID,ref long Atom_cStreetName_Org_ID)
        {
            string Err = null;
            string sql = @"select StreetName from cStreetName_Org where ID = " + cStreetName_Org_ID.ToString();
            DataTable dt = new DataTable();
            if (DBSync.DBSync.ReadDataTable(ref dt,sql,ref Err))
            {
                if (dt.Rows.Count>0)
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
                        sql = @"select ID from Atom_cStreetName_Org where " + scond_StreetName;
                        if (DBSync.DBSync.ReadDataTable(ref dt, sql, ref Err))
                        {
                            if (dt.Rows.Count > 0)
                            {
                                Atom_cStreetName_Org_ID = (long)dt.Rows[0]["ID"];
                                return true;
                            }
                            else
                            {
                                sql = @"insert into Atom_cStreetName_Org (StreetName) values (" + sval_StreetName+")";
                                object objretx = null;
                                if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar, ref Atom_cStreetName_Org_ID, ref objretx, ref Err, "Atom_cStreetName_Org"))
                                {
                                    return true;
                                }
                                else
                                {
                                    LogFile.Error.Show("ERROR:f_Atom_cStreetName_Org:Get:sql=" + sql + "\r\nErr=" + Err);
                                    return false;
                                }
                            }
                        }
                        else
                        {
                            LogFile.Error.Show("ERROR:f_Atom_cStreetName_Org:Get:sql=" + sql + "\r\nErr=" + Err);
                            return false;
                        }
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:f_Atom_cStreetName_Org:Get:1:No StreetName for cStreetName_Org_ID =" + cStreetName_Org_ID.ToString());
                        return false;
                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:f_Atom_cStreetName_Org:Get:2:No StreetName for cStreetName_Org_ID =" + cStreetName_Org_ID.ToString());
                    return false;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:f_Atom_cStreetName_Org:Get:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }
    }
}
