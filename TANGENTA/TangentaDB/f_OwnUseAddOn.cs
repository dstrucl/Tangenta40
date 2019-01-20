using DBConnectionControl40;
using DBTypes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace TangentaDB
{
    public static class f_OwnUseAddOn
    {

        public static bool Get(DateTime tOwnUseIssueTime,
                              string reasonName,
                              string reasonDescription,
                              string descriptionName,
                              string descriptionDescription,
                              ID consumption_ID,
                              ref ID ownUseReason_ID,
                              ref ID ownUseDescription_ID,
                             ref ID ownUseAddOn_ID,
                             Transaction transaction)
        {

            string Err = null;
            if (f_OwnUseReason.Get(reasonName, reasonDescription, ref ownUseReason_ID, transaction))
            {
                if (f_OwnUseDescription.Get(descriptionName, descriptionDescription, ref ownUseDescription_ID, transaction))
                {
                    List<SQL_Parameter> lpar = new List<SQL_Parameter>();

                    
                    string spar_tOwnUseIssueTime = "@par_tOwnUseIssueTime";
                    SQL_Parameter par_tOwnUseIssueTime = new SQL_Parameter(spar_tOwnUseIssueTime,SQL_Parameter.eSQL_Parameter.Datetime, false, tOwnUseIssueTime);
                    lpar.Add(par_tOwnUseIssueTime);

                    string spar_Consumption_ID = "@par_Consumption_ID";
                    SQL_Parameter par_Consumption_ID = new SQL_Parameter(spar_Consumption_ID, false, consumption_ID);
                    lpar.Add(par_Consumption_ID);

                    string spar_OwnUseReason_ID = "@par_OwnUseReason_ID";
                    SQL_Parameter par_OwnUseReason_ID = new SQL_Parameter(spar_OwnUseReason_ID, false, ownUseReason_ID);
                    lpar.Add(par_OwnUseReason_ID);

                    string spar_OwnUseDescription_ID = "@par_OwnUseDescription_ID";
                    SQL_Parameter par_OwnUseDescription_ID = new SQL_Parameter(spar_OwnUseDescription_ID, false, ownUseDescription_ID);
                    lpar.Add(par_OwnUseDescription_ID);


                    string sql = "select ID from OwnUseAddOn where OwnUseReason_ID = " + spar_OwnUseReason_ID+" and OwnUseDescription_ID = " + spar_OwnUseDescription_ID + " and Consumption_ID = "+ spar_Consumption_ID;
                    DataTable dt = new DataTable();
                    if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
                    {
                        if (dt.Rows.Count > 0)
                        {
                            ownUseAddOn_ID = tf.set_ID(dt.Rows[0]["ID"]);
                            return true;
                        }
                        else
                        {
                            sql = "insert into OwnUseAddOn (IssueDate,Consumption_ID,  OwnUseReason_ID,OwnUseDescription_ID) values (" + spar_tOwnUseIssueTime+"," + spar_Consumption_ID + ","+spar_OwnUseReason_ID + "," + spar_OwnUseDescription_ID+")";
                            if (transaction.ExecuteNonQuerySQLReturnID(DBSync.DBSync.Con, sql, lpar, ref ownUseReason_ID, ref Err, "OwnUseAddOn"))
                            {
                                return true;
                            }
                            else
                            {
                                LogFile.Error.Show("ERROR:f_OwnUseAddOn:Get:" + sql + "\r\nErr=" + Err);
                                return false;
                            }

                        }
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:TangentaDB:f_OwnUseAddOn:Get: sql= " + sql + "\r\nErr=" + Err);
                        return false;
                    }
                }
            }
            return false;
        }

        //public static bool Get(
        //                     ID OwnUse_ID,
        //                     ref ID OwnUseAddOn_ID)
        //{

        //    if (OwnUse_ID == null)
        //    {
        //        LogFile.Error.Show("ERROR:TangentaDB:f_OwnUseAddOn:OwnUse_ID_v==null");
        //        return false;
        //    }

        //    string Err = null;
        //    List<SQL_Parameter> lpar = new List<SQL_Parameter>();

        //    string spar_OwnUse_ID = "@par_OwnUse_ID";
        //    SQL_Parameter par_OwnUse_ID = new SQL_Parameter(spar_OwnUse_ID, false, OwnUse_ID);
        //    lpar.Add(par_OwnUse_ID);
        //    string sql = "select ID from OwnUseAddOn where OwnUse_ID = " + spar_OwnUse_ID;
        //    DataTable dt = new DataTable();
        //    if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
        //    {
        //        if (dt.Rows.Count > 0)
        //        {
        //            if (OwnUseAddOn_ID == null)
        //            {
        //                OwnUseAddOn_ID = new ID();
        //            }
        //            OwnUseAddOn_ID.Set(dt.Rows[0]["ID"]);
        //        }
        //        else
        //        {
        //            OwnUseAddOn_ID = null;
        //        }
        //        return true;
        //    }
        //    else
        //    {
        //        LogFile.Error.Show("ERROR:TangentaDB:f_OwnUseAddOn:Get: sql= " + sql + "\r\nErr=" + Err);
        //    }
        //    return false;
        //}
    }
}