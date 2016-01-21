using DBConnectionControl40;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceDB
{
        public static class f_Office
        {
            public static bool Get(
                                    string Office_Name,
                                    long myCompany_ID,
                                    ref long Office_ID)
            {

                List<SQL_Parameter> lpar = new List<SQL_Parameter>();

                string scond_Office_Name = null;
                string sval_Office_Name = "null";
                if (Office_Name != null)
                {
                    string spar_Office_Name = "@par_Office_Name";
                    SQL_Parameter par_Office_Name = new SQL_Parameter(spar_Office_Name, SQL_Parameter.eSQL_Parameter.Nvarchar, false, Office_Name);
                    lpar.Add(par_Office_Name);
                    scond_Office_Name = "Name = " + spar_Office_Name;
                    sval_Office_Name = spar_Office_Name;
                }
                else
                {
                    scond_Office_Name = "Name is null";
                    sval_Office_Name = "null";
                }

                string scond_myCompany_ID = null;
                string sval_myCompany_ID = "null";
                if (myCompany_ID >= 0)
                {
                    string spar_myCompany_ID = "@par_myCompany_ID";
                    SQL_Parameter par_myCompany_ID = new SQL_Parameter(spar_myCompany_ID, SQL_Parameter.eSQL_Parameter.Bigint, false, myCompany_ID);
                    lpar.Add(par_myCompany_ID);
                    scond_myCompany_ID = "myCompany_ID = " + spar_myCompany_ID;
                    sval_myCompany_ID = spar_myCompany_ID;
                }
                else
                {
                    scond_myCompany_ID = "myCompany_ID is null";
                    sval_myCompany_ID = "null";
                }

                string sql = @"select ID from Office
                                        where (" + scond_Office_Name + ") and (" + scond_myCompany_ID + ")";
                string Err = null;
                DataTable dt = new DataTable();
                if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
                {
                    if (dt.Rows.Count > 0)
                    {
                        Office_ID = (long)dt.Rows[0]["ID"];
                        return true;
                    }
                    else
                    {
                        sql = @"insert into Office (myCompany_ID,
                                                            Name) values ("
                                                                + sval_myCompany_ID + ","
                                                                + sval_Office_Name +
                                                                ")";
                        object objretx = null;
                        if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar, ref Office_ID, ref objretx, ref Err, "Office"))
                        {
                            return true;
                        }
                        else
                        {
                            LogFile.Error.Show("ERROR:f_Office:Get:" + sql + "\r\nErr=" + Err);
                            return false;
                        }
                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:f_Office:Get:" + sql + "\r\nErr=" + Err);
                    return false;
                }
            }
        }
}
