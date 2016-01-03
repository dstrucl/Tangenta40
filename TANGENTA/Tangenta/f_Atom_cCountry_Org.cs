using DBConnectionControl40;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tangenta
{
    public static class f_Atom_cCountry_Org
    {
        public static bool Get(long cCountry_Org_ID, ref long Atom_cCountry_Org_ID)
        {
            string Err = null;
            string sql = @"select Country from cCountry_Org where ID = " + cCountry_Org_ID.ToString();
            DataTable dt = new DataTable();
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, ref Err))
            {
                if (dt.Rows.Count > 0)
                {

                    object o_Country = dt.Rows[0]["Country"];
                    if (o_Country is string)
                    {
                        string Country = (string)o_Country;
                        List<SQL_Parameter> lpar = new List<SQL_Parameter>();
                        string scond_Country = null;
                        string sval_Country = "null";
                        if (Country != null)
                        {
                            string spar_Country = "@par_Country";
                            SQL_Parameter par_Country = new SQL_Parameter(spar_Country, SQL_Parameter.eSQL_Parameter.Nvarchar, false, Country);
                            lpar.Add(par_Country);
                            scond_Country = "Country = " + spar_Country;
                            sval_Country = spar_Country;
                        }
                        else
                        {
                            scond_Country = "Country is null";
                            sval_Country = "null";
                        }
                        dt.Columns.Clear();
                        dt.Clear();
                        sql = @"select ID from Atom_cCountry_Org where " + scond_Country;
                        if (DBSync.DBSync.ReadDataTable(ref dt, sql,lpar, ref Err))
                        {
                            if (dt.Rows.Count > 0)
                            {
                                Atom_cCountry_Org_ID = (long)dt.Rows[0]["ID"];
                                return true;
                            }
                            else
                            {
                                sql = @"insert into Atom_cCountry_Org (Country) values (" + sval_Country + ")";
                                object objretx = null;
                                if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar, ref Atom_cCountry_Org_ID, ref objretx, ref Err, "Atom_cCountry_Org"))
                                {
                                    return true;
                                }
                                else
                                {
                                    LogFile.Error.Show("ERROR:f_Atom_cCountry_Org:Get:sql=" + sql + "\r\nErr=" + Err);
                                    return false;
                                }
                            }
                        }
                        else
                        {
                            LogFile.Error.Show("ERROR:f_Atom_cCountry_Org:Get:sql=" + sql + "\r\nErr=" + Err);
                            return false;
                        }
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:f_Atom_cCountry_Org:Get:1:No Country for cCountry_Org_ID =" + cCountry_Org_ID.ToString());
                        return false;
                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:f_Atom_cCountry_Org:Get:2:No Country for cCountry_Org_ID =" + cCountry_Org_ID.ToString());
                    return false;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:f_Atom_cCountry_Org:Get:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }
    }
}
