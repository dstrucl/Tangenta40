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
        public static bool Get(string Description, ref ID TermsOfPayment_ID)
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
                        if (TermsOfPayment_ID == null)
                        {
                            TermsOfPayment_ID = new ID();
                        }
                        TermsOfPayment_ID.Set(dt.Rows[0]["ID"]);
                        return true;
                    }
                    else
                    {

                        sql = @" insert into  TermsOfPayment (Description) values
                                                      (" + sval_Description + ")";
                        if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar, ref TermsOfPayment_ID, ref Err, "TermsOfPayment"))
                        {
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
                TermsOfPayment_ID = null;
                return true;
            }
        }

        public static bool Get(ID TermsOfPayment_ID, ref string_v xDescription_v)
        {
            DataTable dt = new DataTable();
            string Err = null;
            string sql = " select Description from TermsOfPayment where ID = " + TermsOfPayment_ID.ToString();
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    xDescription_v = tf.set_string(dt.Rows[0]["Description"]);
                }
                else
                {
                    xDescription_v = null;
                }
                return true;
            }
            else
            {
                xDescription_v = null;
                LogFile.Error.Show("ERROR:TangentaDB:f_TermsOfPayment:Get:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }
    }
}
