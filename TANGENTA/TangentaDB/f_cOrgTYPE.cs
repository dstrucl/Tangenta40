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
    public static class f_cOrgTYPE
    {
        public static bool Get(string OrgTYPE, ref ID cOrgTYPE_ID, Transaction transaction)
        {

            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            string scond_OrgTYPE = null;
            string sval_OrgTYPE = "null";
            if (OrgTYPE != null)
            {
                string spar_OrgTYPE = "@par_OrgTYPE";
                SQL_Parameter par_OrgTYPE = new SQL_Parameter(spar_OrgTYPE, SQL_Parameter.eSQL_Parameter.Nvarchar, false, OrgTYPE);
                lpar.Add(par_OrgTYPE);
                scond_OrgTYPE = "OrgTYPE = " + spar_OrgTYPE;
                sval_OrgTYPE = spar_OrgTYPE;
            }
            else
            {
                scond_OrgTYPE = "OrgTYPE is null";
                sval_OrgTYPE = "null";
            }
            DataTable dt = new DataTable();
            string Err = null;
            dt.Columns.Clear();
            dt.Clear();
            string sql = @"select ID from cOrgTYPE where " + scond_OrgTYPE;
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    if (cOrgTYPE_ID==null)
                    {
                        cOrgTYPE_ID = new ID();
                    }
                    cOrgTYPE_ID.Set(dt.Rows[0]["ID"]);
                    return true;
                }
                else
                {
                    if (!transaction.Get(DBSync.DBSync.Con))
                    {
                        return false;
                    }
                    sql = @"insert into cOrgTYPE (OrgTYPE) values (" + sval_OrgTYPE + ")";
                    if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar, ref cOrgTYPE_ID, ref Err, "Atom_cOrgTYPE"))
                    {
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:f_cOrgTYPE:Get:sql=" + sql + "\r\nErr=" + Err);
                        return false;
                    }
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:f_cOrgTYPE:Get:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }

        }

        internal static bool Get(string_v OrgTYPE_v, ref ID cOrgTYPE_ID, Transaction transaction)
        {
            if (OrgTYPE_v != null)
            {
                List<SQL_Parameter> lpar = new List<SQL_Parameter>();
                string spar = "@par";
                SQL_Parameter par = new SQL_Parameter(spar, SQL_Parameter.eSQL_Parameter.Nvarchar, false, OrgTYPE_v.v);
                lpar.Add(par);
                string sql = @"select ID from cOrgTYPE where OrganisationTYPE = @par";
                DataTable dt = new DataTable();
                string Err = null;
                if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
                {
                    if (dt.Rows.Count > 0)
                    {
                        if (cOrgTYPE_ID == null)
                        {
                            cOrgTYPE_ID = new ID();
                        }
                        cOrgTYPE_ID.Set(dt.Rows[0]["ID"]);
                        return true;
                    }
                    else
                    {
                        if (!transaction.Get(DBSync.DBSync.Con))
                        {
                            return false;
                        }
                        sql = @"insert into cOrgTYPE (OrganisationTYPE) values (@par)";
                        if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar, ref cOrgTYPE_ID,  ref Err, "cOrgTYPE"))
                        {
                            return true;
                        }
                        else
                        {
                            LogFile.Error.Show("ERROR:TangentaDB:f_cOrgTYPE:Get(string_v OrgTYPE_v, ref ID cOrgTYPE_ID) sql=" + sql + "\r\nErr=" + Err);
                            return false;
                        }
                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:TangentaDB:f_cOrgTYPE:Get(string_v OrgTYPE_v, ref ID cOrgTYPE_ID) sql=" + sql + "\r\nErr=" + Err);
                    return false;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:TangentaDB:f_cOrgTYPE:Get(string_v OrgTYPE_v, ref ID cOrgTYPE_ID) OrgTYPE_v may not be null!");
                return false;
            }
        }
    }
}
