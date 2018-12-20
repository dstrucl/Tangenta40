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
    public static class f_cZIP_Org
    {
        public static bool Get(string ZIP, ref ID cZIP_Org_ID, Transaction transaction)
        {
            string Err = null;
           
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
            DataTable dt = new DataTable();
            string sql = @"select ID from cZIP_Org where " + scond_ZIP;
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    if (cZIP_Org_ID==null)
                    {
                        cZIP_Org_ID = new ID();
                    }
                    cZIP_Org_ID.Set(dt.Rows[0]["ID"]);
                    return true;
                }
                else
                {
                  
                    sql = @"insert into cZIP_Org (ZIP) values (" + sval_ZIP + ")";
                    if (transaction.ExecuteNonQuerySQLReturnID(DBSync.DBSync.Con,sql, lpar, ref cZIP_Org_ID,  ref Err, "cZIP_Org"))
                    {
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:f_cZIP_Org:Get:sql=" + sql + "\r\nErr=" + Err);
                        return false;
                    }
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:f_cZIP_Org:Get:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
       }

        internal static bool Get(string_v zIP_v, ref ID cZIP_Org_ID, Transaction transaction)
        {
            if (zIP_v != null)
            {
                List<SQL_Parameter> lpar = new List<SQL_Parameter>();
                string spar = "@par";
                SQL_Parameter par = new SQL_Parameter(spar, SQL_Parameter.eSQL_Parameter.Nvarchar, false, zIP_v.v);
                lpar.Add(par);
                string sql = @"select ID from cZIP_Org where ZIP = @par";
                DataTable dt = new DataTable();
                string Err = null;
                if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
                {
                    if (dt.Rows.Count > 0)
                    {
                        if (cZIP_Org_ID == null)
                        {
                            cZIP_Org_ID = new ID();
                        }
                        cZIP_Org_ID.Set(dt.Rows[0]["ID"]);
                        return true;
                    }
                    else
                    {
                        
                        sql = @"insert into cZIP_Org (ZIP) values (@par)";
                        if (transaction.ExecuteNonQuerySQLReturnID(DBSync.DBSync.Con,sql, lpar, ref cZIP_Org_ID, ref Err, "cZIP_Org"))
                        {
                            return true;
                        }
                        else
                        {
                            LogFile.Error.Show("ERROR:TangentaDB:f_cZIP_Org:Get(string_v zIP_v, ref ID cZIP_Org_ID) sql=" + sql + "\r\nErr=" + Err);
                            return false;
                        }
                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:TangentaDB:f_cZIP_Org:Get(string_v zIP_v, ref ID cZIP_Org_ID) sql=" + sql + "\r\nErr=" + Err);
                    return false;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:TangentaDB:f_cZIP_Org:Get(string_v zIP_v, ref ID cZIP_Org_ID) zIP_v may not be null!");
                return false;
            }
        }

        public static bool DeleteAll(Transaction transaction)
        {
            return fs.DeleteAll("cZIP_Org",transaction);
        }
    }
}
