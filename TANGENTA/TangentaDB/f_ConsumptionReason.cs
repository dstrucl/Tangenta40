using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBConnectionControl40;
using DBTypes;

namespace TangentaDB
{
    public static class f_ConsumptionReason
    {

        public static bool Get(string name,string description, ref ID consumptionReason_ID, Transaction transaction)
        {
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
        
            string Err = null;
            DataTable dt = new DataTable();

            string scond_Name = null;
            string sval_Name = "null";
            if (name != null)
            {
                string spar_Name = "@par_Name";
                SQL_Parameter par_Name = new SQL_Parameter(spar_Name, SQL_Parameter.eSQL_Parameter.Nvarchar, false, name);
                lpar.Add(par_Name);
                scond_Name = "Name = " + spar_Name;
                sval_Name = spar_Name;
            }
            else
            {
                scond_Name = "Name is null";
                sval_Name = "null";
            }


            string scond_Description = null;
            string sval_Description = "null";
            if (name != null)
            {
                string spar_Description = "@par_Description";
                SQL_Parameter par_Description = new SQL_Parameter(spar_Description, SQL_Parameter.eSQL_Parameter.Nvarchar, false, description);
                lpar.Add(par_Description);
                scond_Description = "Description = " + spar_Description;
                sval_Description = spar_Description;
            }
            else
            {
                scond_Description = "Description is null";
                sval_Description = "null";
            }

            string sql = @"select ID, Description from ConsumptionReason
                                                where " + scond_Name;

            if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    consumptionReason_ID = tf.set_ID(dt.Rows[0]["ID"]);
                    string consumptionReasonDescription = tf._set_string(dt.Rows[0]["Description"]);
                    if ((consumptionReasonDescription == null) && (description == null))
                    {
                        return true;
                    }
                    else
                    {
                        if ((consumptionReasonDescription != null) && (description != null))
                        {
                            if (consumptionReasonDescription.Equals(description))
                            {
                                return true;
                            }
                            else
                            {
                                sql = @"update ConsumptionReason set Description = " + sval_Description+  " where ID = "+ consumptionReason_ID.ToString();
                            }
                        }
                        else
                        {
                            sql = @"update ConsumptionReason set Description = " + sval_Description + " where ID = " + consumptionReason_ID.ToString();
                        }
                        if (transaction.ExecuteNonQuerySQL(DBSync.DBSync.Con, sql, lpar, ref Err))
                        {
                            return true;
                        }
                        else
                        {
                            LogFile.Error.Show("ERROR:f_ConsumptionReason:Get:" + sql + "\r\nErr=" + Err);
                            return false;
                        }
                    }
                }
                else
                {
                    sql = @"insert into ConsumptionReason (Name,Description) values (" + sval_Name + ","+ sval_Description + ")";
                    if (transaction.ExecuteNonQuerySQLReturnID(DBSync.DBSync.Con, sql, lpar, ref consumptionReason_ID, ref Err, "ConsumptionReason"))
                    {
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:f_ConsumptionReason:Get:" + sql + "\r\nErr=" + Err);
                        return false;
                    }
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:f_ConsumptionReason:Get:" + sql + "\r\nErr=" + Err);
                return false;
            }
        }

        public static bool GetTable(ref DataTable dtConsumptionReason)
        {
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();

            string Err = null;

            string sql = @"select ID,Name, Description from ConsumptionReason";
            if (dtConsumptionReason!=null)
            {
                dtConsumptionReason.Dispose();
                dtConsumptionReason = null;
            }
            
            dtConsumptionReason = new DataTable();
            

            if (DBSync.DBSync.ReadDataTable(ref dtConsumptionReason, sql,  ref Err))
            {
               return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:f_ConsumptionReason:GetTable:" + sql + "\r\nErr=" + Err);
                return false;
            }
        }
    }
}
