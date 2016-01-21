using DBConnectionControl40;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceDB
{
    public static class f_Atom_cCity_Org
    {
        public static bool Get(long cCity_Org_ID, ref long Atom_cCity_Org_ID)
        {
            string Err = null;
            string sql = @"select City from cCity_Org where ID = " + cCity_Org_ID.ToString();
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
                        sql = @"select ID from Atom_cCity_Org where " + scond_City;
                        if (DBSync.DBSync.ReadDataTable(ref dt, sql,lpar, ref Err))
                        {
                            if (dt.Rows.Count > 0)
                            {
                                Atom_cCity_Org_ID = (long)dt.Rows[0]["ID"];
                                return true;
                            }
                            else
                            {
                                sql = @"insert into Atom_cCity_Org (City) values (" + sval_City + ")";
                                object objretx = null;
                                if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar, ref Atom_cCity_Org_ID, ref objretx, ref Err, "Atom_cCity_Org"))
                                {
                                    return true;
                                }
                                else
                                {
                                    LogFile.Error.Show("ERROR:f_Atom_cCity_Org:Get:sql=" + sql + "\r\nErr=" + Err);
                                    return false;
                                }
                            }
                        }
                        else
                        {
                            LogFile.Error.Show("ERROR:f_Atom_cCity_Org:Get:sql=" + sql + "\r\nErr=" + Err);
                            return false;
                        }
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:f_Atom_cCity_Org:Get:1:No City for cCity_Org_ID =" + cCity_Org_ID.ToString());
                        return false;
                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:f_Atom_cCity_Org:Get:2:No City for cCity_Org_ID =" + cCity_Org_ID.ToString());
                    return false;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:f_Atom_cCity_Org:Get:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }
    }
}
