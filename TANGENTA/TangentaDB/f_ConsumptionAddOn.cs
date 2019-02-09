using DBConnectionControl40;
using DBTypes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace TangentaDB
{
    public static class f_ConsumptionAddOn
    {

        public static bool Get(DateTime tConsumptionIssueTime,
                              string reasonName,
                              string reasonDescription,
                              string descriptionName,
                              string descriptionDescription,
                              ID consumption_ID,
                              ref ID consumptionReason_ID,
                              ref ID consumptionDescription_ID,
                             ref ID consumptionAddOn_ID,
                             Transaction transaction)
        {

            string Err = null;
            if (f_ConsumptionReason.Get(reasonName, reasonDescription, ref consumptionReason_ID, transaction))
            {
                if (f_ConsumptionDescription.Get(descriptionName, descriptionDescription, ref consumptionDescription_ID, transaction))
                {
                    List<SQL_Parameter> lpar = new List<SQL_Parameter>();

                    
                    string spar_tConsumptionIssueTime = "@par_tConsumptionIssueTime";
                    SQL_Parameter par_tConsumptionIssueTime = new SQL_Parameter(spar_tConsumptionIssueTime,SQL_Parameter.eSQL_Parameter.Datetime, false, tConsumptionIssueTime);
                    lpar.Add(par_tConsumptionIssueTime);

                    string spar_Consumption_ID = "@par_Consumption_ID";
                    SQL_Parameter par_Consumption_ID = new SQL_Parameter(spar_Consumption_ID, false, consumption_ID);
                    lpar.Add(par_Consumption_ID);

                    string spar_ConsumptionReason_ID = "@par_ConsumptionReason_ID";
                    SQL_Parameter par_ConsumptionReason_ID = new SQL_Parameter(spar_ConsumptionReason_ID, false, consumptionReason_ID);
                    lpar.Add(par_ConsumptionReason_ID);

                    string spar_ConsumptionDescription_ID = "@par_ConsumptionDescription_ID";
                    SQL_Parameter par_ConsumptionDescription_ID = new SQL_Parameter(spar_ConsumptionDescription_ID, false, consumptionDescription_ID);
                    lpar.Add(par_ConsumptionDescription_ID);


                    string sql = "select ID from ConsumptionAddOn where ConsumptionReason_ID = " + spar_ConsumptionReason_ID+" and ConsumptionDescription_ID = " + spar_ConsumptionDescription_ID + " and Consumption_ID = "+ spar_Consumption_ID;
                    DataTable dt = new DataTable();
                    if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
                    {
                        if (dt.Rows.Count > 0)
                        {
                            consumptionAddOn_ID = tf.set_ID(dt.Rows[0]["ID"]);
                            return true;
                        }
                        else
                        {
                            sql = "insert into ConsumptionAddOn (IssueDate,Consumption_ID,  ConsumptionReason_ID,ConsumptionDescription_ID) values (" + spar_tConsumptionIssueTime+"," + spar_Consumption_ID + ","+spar_ConsumptionReason_ID + "," + spar_ConsumptionDescription_ID+")";
                            if (transaction.ExecuteNonQuerySQLReturnID(DBSync.DBSync.Con, sql, lpar, ref consumptionReason_ID, ref Err, "ConsumptionAddOn"))
                            {
                                return true;
                            }
                            else
                            {
                                LogFile.Error.Show("ERROR:f_ConsumptionAddOn:Get:" + sql + "\r\nErr=" + Err);
                                return false;
                            }

                        }
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:TangentaDB:f_ConsumptionAddOn:Get: sql= " + sql + "\r\nErr=" + Err);
                        return false;
                    }
                }
            }
            return false;
        }

        //public static bool Get(
        //                     ID Consumption_ID,
        //                     ref ID ConsumptionAddOn_ID)
        //{

        //    if (Consumption_ID == null)
        //    {
        //        LogFile.Error.Show("ERROR:TangentaDB:f_ConsumptionAddOn:Consumption_ID_v==null");
        //        return false;
        //    }

        //    string Err = null;
        //    List<SQL_Parameter> lpar = new List<SQL_Parameter>();

        //    string spar_Consumption_ID = "@par_Consumption_ID";
        //    SQL_Parameter par_Consumption_ID = new SQL_Parameter(spar_Consumption_ID, false, Consumption_ID);
        //    lpar.Add(par_Consumption_ID);
        //    string sql = "select ID from ConsumptionAddOn where Consumption_ID = " + spar_Consumption_ID;
        //    DataTable dt = new DataTable();
        //    if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
        //    {
        //        if (dt.Rows.Count > 0)
        //        {
        //            if (ConsumptionAddOn_ID == null)
        //            {
        //                ConsumptionAddOn_ID = new ID();
        //            }
        //            ConsumptionAddOn_ID.Set(dt.Rows[0]["ID"]);
        //        }
        //        else
        //        {
        //            ConsumptionAddOn_ID = null;
        //        }
        //        return true;
        //    }
        //    else
        //    {
        //        LogFile.Error.Show("ERROR:TangentaDB:f_ConsumptionAddOn:Get: sql= " + sql + "\r\nErr=" + Err);
        //    }
        //    return false;
        //}
    }
}