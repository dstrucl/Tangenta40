using DBConnectionControl40;
using DBTypes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TangentaDB
{
    public static class f_Expiry
    {
        public class Expiry_v
        {
            public int ExpectedShelfLifeInDays = 0;
            public int SaleBeforeExpiryDateInDays = 0;
            public int DiscardBeforeExpiryDateInDays = 0;
            public string ExpiryDescription = null;
        }

        public static bool Get(Expiry_v expiry_v,ref long_v Expiry_ID_v)
        {
            if (expiry_v != null)
            {
                List<SQL_Parameter> lpar = new List<SQL_Parameter>();
                string Err = null;
                DataTable dt = new DataTable();

                string scond_ExpiryDescription = " ExpiryDescription is null ";
                string sval_ExpiryDescription = " null ";

                if (expiry_v.ExpiryDescription != null)
                {
                    string spar_ExpiryDescription = "@par_ExpiryDescription";
                    SQL_Parameter par_ExpiryDescription = new SQL_Parameter(spar_ExpiryDescription, SQL_Parameter.eSQL_Parameter.Nvarchar,false, expiry_v.ExpiryDescription);
                    lpar.Add(par_ExpiryDescription);
                    scond_ExpiryDescription = " ExpiryDescription = "+ spar_ExpiryDescription;
                    sval_ExpiryDescription = " " + spar_ExpiryDescription + " ";
                }

                string sql = " select ID from Expiry where ExpectedShelfLifeInDays = " + expiry_v.ExpectedShelfLifeInDays.ToString() +
                                                           " and SaleBeforeExpiryDateInDays = " + expiry_v.SaleBeforeExpiryDateInDays.ToString() +
                                                           " and DiscardBeforeExpiryDateInDays = " + expiry_v.DiscardBeforeExpiryDateInDays.ToString() +
                                                           " and " + scond_ExpiryDescription;
                if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
                {
                    if (dt.Rows.Count > 0)
                    {
                        if (Expiry_ID_v == null)
                        {
                            Expiry_ID_v = new long_v();
                        }
                        Expiry_ID_v.v = (long)dt.Rows[0]["ID"];
                        return true;
                    }
                    else
                    {

                        sql = @" insert into  Expiry (ExpectedShelfLifeInDays,
                                                      SaleBeforeExpiryDateInDays,
                                                      DiscardBeforeExpiryDateInDays,
                                                      ExpiryDescription) values
                                                      (" + expiry_v.ExpectedShelfLifeInDays.ToString() + ","
                                                         + expiry_v.SaleBeforeExpiryDateInDays.ToString() + ","
                                                         + expiry_v.DiscardBeforeExpiryDateInDays.ToString() + ","
                                                         + sval_ExpiryDescription + ")";
                        long Expiry_ID = -1;
                        object oret = null;
                        if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar, ref Expiry_ID, ref oret, ref Err, "Expiry"))
                        {
                            if (Expiry_ID_v == null)
                            {
                                Expiry_ID_v = new long_v();
                            }
                            Expiry_ID_v.v = Expiry_ID;
                            return true;
                        }
                        else
                        {
                            LogFile.Error.Show("ERROR:f_Expiry:Get:sql=" + sql + "\r\nErr=" + Err);
                            return false;
                        }
                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:f_Expiry:Get:sql=" + sql + "\r\nErr=" + Err);
                    return false;
                }
            }
            else
            {
                Expiry_ID_v = null;
                return true;
            }
        }
    }
}
