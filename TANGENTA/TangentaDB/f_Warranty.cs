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
    public static class f_Warranty
    {
        public class Warranty_v
        {
            public int WarrantyDuration = 0;
            public int WarrantyDurationType = 0;
            public string WarrantyConditions = null;
        }

        public static bool Get(Warranty_v warranty_v, ref ID Warranty_ID, Transaction transaction)
        {
            if (warranty_v != null)
            {
                List<SQL_Parameter> lpar = new List<SQL_Parameter>();
                string Err = null;
                DataTable dt = new DataTable();

                string scond_WarrantyConditions = " WarrantyConditions is null ";
                string sval_WarrantyConditions = " null ";

                if (warranty_v.WarrantyConditions != null)
                {
                    string spar_WarrantyConditions = "@par_WarrantyConditions";
                    SQL_Parameter par_WarrantyConditions = new SQL_Parameter(spar_WarrantyConditions, SQL_Parameter.eSQL_Parameter.Nvarchar, false, warranty_v.WarrantyConditions);
                    lpar.Add(par_WarrantyConditions);
                    scond_WarrantyConditions = " WarrantyConditions = " + spar_WarrantyConditions;
                    sval_WarrantyConditions = " " + spar_WarrantyConditions + " ";
                }

                string sql = " select ID from Warranty where WarrantyDuration = " + warranty_v.WarrantyDuration.ToString() +
                                                           " and WarrantyDurationType = " + warranty_v.WarrantyDurationType.ToString() +
                                                           " and " + scond_WarrantyConditions;
                if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
                {
                    if (dt.Rows.Count > 0)
                    {
                        if (Warranty_ID == null)
                        {
                            Warranty_ID = new ID();
                        }
                        Warranty_ID.Set(dt.Rows[0]["ID"]);
                        return true;
                    }
                    else
                    {

                        sql = @" insert into  Warranty (WarrantyDuration,
                                                      WarrantyDurationType,
                                                      WarrantyConditions) values
                                                      (" + warranty_v.WarrantyDuration.ToString() + ","
                                                         + warranty_v.WarrantyDurationType.ToString() + ","
                                                         + sval_WarrantyConditions + ")";
                        if (transaction.ExecuteNonQuerySQLReturnID(DBSync.DBSync.Con,sql, lpar, ref Warranty_ID, ref Err, "Warranty"))
                        {
                            return true;
                        }
                        else
                        {
                            LogFile.Error.Show("ERROR:f_Warranty:Get:sql=" + sql + "\r\nErr=" + Err);
                            return false;
                        }
                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:f_Warranty:Get:sql=" + sql + "\r\nErr=" + Err);
                    return false;
                }
            }
            else
            {
                Warranty_ID = null;
                return true;
            }
        }

        internal static bool Get(ID Warranty_ID, ref Warranty_v warranty_v)
        {
            warranty_v = null;

            List<SQL_Parameter> lpar = new List<SQL_Parameter>();


            string spar_ID = "@par_ID";
            SQL_Parameter par_ID = new SQL_Parameter(spar_ID, false, Warranty_ID);
            lpar.Add(par_ID);

            string sql = "select WarrantyDuration,WarrantyDurationType,WarrantyConditions from Warranty where ID = " + spar_ID;

            DataTable dt = new DataTable();
            string Err = null;
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    if (warranty_v == null)
                    {
                        warranty_v = new Warranty_v();
                    }
                    warranty_v.WarrantyDuration = tf._set_int(dt.Rows[0]["WarrantyDuration"]);
                    warranty_v.WarrantyDurationType = tf._set_int(dt.Rows[0]["WarrantyDurationType"]);
                    warranty_v.WarrantyConditions = tf._set_string(dt.Rows[0]["WarrantyConditions"]);
                }
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:TangentaDB:f_Warranty:Get:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }
    }
}
