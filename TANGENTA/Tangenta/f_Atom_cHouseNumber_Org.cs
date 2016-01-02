using DBConnectionControl40;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tangenta
{
    public static class f_Atom_cHouseNumber_Org
    {
        public static bool Get(long cHouseNumber_Org_ID, ref long Atom_cHouseNumber_Org_ID)
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
                        if (DBSync.DBSync.ReadDataTable(ref dt, sql, ref Err))
                        {
                            if (dt.Rows.Count > 0)
                            {
                                Atom_cHouseNumber_Org_ID = (long)dt.Rows[0]["ID"];
                                return true;
                            }
                            else
                            {
                                sql = @"insert into Atom_cHouseNumber_Org (HouseNumber) values (" + sval_HouseNumber + ")";
                                object objretx = null;
                                if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar, ref Atom_cHouseNumber_Org_ID, ref objretx, ref Err, "Atom_cHouseNumber_Org"))
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
    }
}
