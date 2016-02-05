using DBConnectionControl40;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBTypes;

namespace InvoiceDB
{
    public static class f_Atom_cZIP_Org
    {
        public static bool Get(long cZIP_Org_ID, ref long Atom_cZIP_Org_ID)
        {
            string Err = null;
            string sql = @"select ZIP from cZIP_Org where ID = " + cZIP_Org_ID.ToString();
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
                        sql = @"select ID from Atom_cZIP_Org where " + scond_ZIP;
                        if (DBSync.DBSync.ReadDataTable(ref dt, sql,lpar, ref Err))
                        {
                            if (dt.Rows.Count > 0)
                            {
                                Atom_cZIP_Org_ID = (long)dt.Rows[0]["ID"];
                                return true;
                            }
                            else
                            {
                                sql = @"insert into Atom_cZIP_Org (ZIP) values (" + sval_ZIP + ")";
                                object objretx = null;
                                if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar, ref Atom_cZIP_Org_ID, ref objretx, ref Err, "Atom_cZIP_Org"))
                                {
                                    return true;
                                }
                                else
                                {
                                    LogFile.Error.Show("ERROR:f_Atom_cZIP_Org:Get:sql=" + sql + "\r\nErr=" + Err);
                                    return false;
                                }
                            }
                        }
                        else
                        {
                            LogFile.Error.Show("ERROR:f_Atom_cZIP_Org:Get:sql=" + sql + "\r\nErr=" + Err);
                            return false;
                        }
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:f_Atom_cZIP_Org:Get:1:No ZIP for cZIP_Org_ID =" + cZIP_Org_ID.ToString());
                        return false;
                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:f_Atom_cZIP_Org:Get:2:No ZIP for cZIP_Org_ID =" + cZIP_Org_ID.ToString());
                    return false;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:f_Atom_cZIP_Org:Get:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }

        internal static bool Get(string_v zIP_v, ref long_v atom_cZIP_Org_ID_v)
        {
            if (zIP_v != null)
            {
                List<SQL_Parameter> lpar = new List<SQL_Parameter>();
                string spar = "@par";
                SQL_Parameter par = new SQL_Parameter(spar, SQL_Parameter.eSQL_Parameter.Nvarchar, false, zIP_v.v);
                lpar.Add(par);
                string sql = @"select ID from Atom_cZIP_Org where ZIP = @par";
                DataTable dt = new DataTable();
                string Err = null;
                if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
                {
                    if (dt.Rows.Count > 0)
                    {
                        if (atom_cZIP_Org_ID_v == null)
                        {
                            atom_cZIP_Org_ID_v = new long_v();
                        }
                        atom_cZIP_Org_ID_v.v = (long)dt.Rows[0]["ID"];
                        return true;
                    }
                    else
                    {
                        sql = @"insert into Atom_cZIP_Org (ZIP) values (@par)";
                        long Atom_cZIP_Org_ID = -1;
                        object oret = null;
                        if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar, ref Atom_cZIP_Org_ID, ref oret, ref Err, "Atom_cZIP_Org"))
                        {
                            if (atom_cZIP_Org_ID_v == null)
                            {
                                atom_cZIP_Org_ID_v = new long_v();
                            }
                            atom_cZIP_Org_ID_v.v = Atom_cZIP_Org_ID;
                            return true;
                        }
                        else
                        {
                            LogFile.Error.Show("ERROR:InvoiceDB:f_Atom_cZIP_Org:Get(string_v zIP_v, ref long_v atom_cZIP_Org_ID_v) sql=" + sql + "\r\nErr=" + Err);
                            return false;
                        }
                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:InvoiceDB:f_Atom_cZIP_Org:Get(string_v zIP_v, ref long_v atom_cZIP_Org_ID_v) sql=" + sql + "\r\nErr=" + Err);
                    return false;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:InvoiceDB:f_Atom_cZIP_Org:Get(string_v zIP_v, ref long_v atom_cZIP_Org_ID_v) zIP_v may not be null!");
                return false;
            }
        }
    }
}
