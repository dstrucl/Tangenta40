using DBConnectionControl40;
using DBTypes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace TangentaDB
{
    public static class f_TermsOfPayment
    {
        public static bool Get(string Description, ref long_v TermsOfPayment_ID_v)
        {
            if (Description != null)
            {
                List<SQL_Parameter> lpar = new List<SQL_Parameter>();
                string Err = null;
                DataTable dt = new DataTable();

                string scond_Description = " Description is null ";
                string sval_Description = " null ";

                if (Description != null)
                {
                    string spar_Description = "@par_Description";
                    SQL_Parameter par_Description = new SQL_Parameter(spar_Description, SQL_Parameter.eSQL_Parameter.Nvarchar, false, Description);
                    lpar.Add(par_Description);
                    scond_Description = " Description = " + spar_Description;
                    sval_Description = " " + spar_Description + " ";
                }

                string sql = " select ID from TermsOfPayment where " + scond_Description;
                if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
                {
                    if (dt.Rows.Count > 0)
                    {
                        if (TermsOfPayment_ID_v == null)
                        {
                            TermsOfPayment_ID_v = new long_v();
                        }
                        TermsOfPayment_ID_v.v = (long)dt.Rows[0]["ID"];
                        return true;
                    }
                    else
                    {

                        sql = @" insert into  TermsOfPayment (Description) values
                                                      (" + sval_Description + ")";
                        long TermsOfPayment_ID = -1;
                        object oret = null;
                        if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar, ref TermsOfPayment_ID, ref oret, ref Err, "TermsOfPayment"))
                        {
                            if (TermsOfPayment_ID_v == null)
                            {
                                TermsOfPayment_ID_v = new long_v();
                            }
                            TermsOfPayment_ID_v.v = TermsOfPayment_ID;
                            return true;
                        }
                        else
                        {
                            LogFile.Error.Show("ERROR:f_TermsOfPayment:Get:sql=" + sql + "\r\nErr=" + Err);
                            return false;
                        }
                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:f_TermsOfPayment:Get:sql=" + sql + "\r\nErr=" + Err);
                    return false;
                }
            }
            else
            {
                TermsOfPayment_ID_v = null;
                return true;
            }
        }
    }
}
