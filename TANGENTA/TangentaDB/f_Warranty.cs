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

        public static bool Get(Warranty_v warranty_v, ref long_v Warranty_ID_v)
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
                        if (Warranty_ID_v == null)
                        {
                            Warranty_ID_v = new long_v();
                        }
                        Warranty_ID_v.v = (long)dt.Rows[0]["ID"];
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
                        long Warranty_ID = -1;
                        object oret = null;
                        if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar, ref Warranty_ID, ref oret, ref Err, "Warranty"))
                        {
                            if (Warranty_ID_v == null)
                            {
                                Warranty_ID_v = new long_v();
                            }
                            Warranty_ID_v.v = Warranty_ID;
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
                Warranty_ID_v = null;
                return true;
            }
        }
    }
}
