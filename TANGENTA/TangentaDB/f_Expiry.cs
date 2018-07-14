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

        public static bool Get(Expiry_v expiry_v,ref ID Expiry_ID)
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
                        if (Expiry_ID == null)
                        {
                            Expiry_ID = new ID();
                        }
                        Expiry_ID.Set(dt.Rows[0]["ID"]);
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
                        if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar, ref Expiry_ID, ref Err, "Expiry"))
                        {
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
                Expiry_ID = null;
                return true;
            }
        }

        internal static bool Get(ID Expiry_ID, ref Expiry_v expiry_v)
        {
            expiry_v = null;

            List<SQL_Parameter> lpar = new List<SQL_Parameter>();


            string spar_ID = "@par_ID";
            SQL_Parameter par_ID = new SQL_Parameter(spar_ID, false, Expiry_ID);
            lpar.Add(par_ID);

            string sql = "select ExpectedShelfLifeInDays,SaleBeforeExpiryDateInDays,DiscardBeforeExpiryDateInDays,ExpiryDescription from Expiry where ID = " + spar_ID;

            DataTable dt = new DataTable();
            string Err = null;
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    if (expiry_v==null)
                    {
                        expiry_v = new Expiry_v();
                    }
                    expiry_v.DiscardBeforeExpiryDateInDays = tf._set_int(dt.Rows[0]["DiscardBeforeExpiryDateInDays"]);
                    expiry_v.SaleBeforeExpiryDateInDays = tf._set_int(dt.Rows[0]["SaleBeforeExpiryDateInDays"]);
                    expiry_v.ExpectedShelfLifeInDays= tf._set_int(dt.Rows[0]["ExpectedShelfLifeInDays"]);
                    expiry_v.ExpiryDescription = tf._set_string(dt.Rows[0]["ExpiryDescription"]);
                }
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:TangentaDB:f_Expiry:Get:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }
    }
}
