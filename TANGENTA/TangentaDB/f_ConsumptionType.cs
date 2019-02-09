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
    public static class f_ConsumptionType
    {
        public const string const_ConsumptionWriteOff = "WriteOff";
        public const string const_ConsumptionOwnUse = "OwnUse";
        public const string const_ConsumptionSoldByGiftCertificate = "SoldByGiftCertificate";

        public static ID ConsumptionType_WriteOff_ID = null;
        public static ID ConsumptionType_OwnUse_ID = null;
        public static ID ConsumptionType_SoldByGiftCertificate_ID = null;

        public static bool Get(string name,string description, ref ID consumptionType_ID, Transaction transaction)
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

            string sql = @"select ID, Description from ConsumptionType
                                                where " + scond_Name+ " and "+ scond_Description;

            if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    consumptionType_ID = tf.set_ID(dt.Rows[0]["ID"]);
                    string ownUseReasonDescription = tf._set_string(dt.Rows[0]["Description"]);
                    if ((ownUseReasonDescription == null) && (description == null))
                    {
                        return true;
                    }
                    else
                    {
                        if ((ownUseReasonDescription != null) && (description != null))
                        {
                            if (ownUseReasonDescription.Equals(description))
                            {
                                return true;
                            }
                            else
                            {
                                sql = @"update ConsumptionType set Description = " + sval_Description+  " where ID = "+ consumptionType_ID.ToString();
                            }
                        }
                        else
                        {
                            sql = @"update ConsumptionType set Description = " + sval_Description + " where ID = " + consumptionType_ID.ToString();
                        }
                        if (transaction.ExecuteNonQuerySQL(DBSync.DBSync.Con, sql, lpar, ref Err))
                        {
                            return true;
                        }
                        else
                        {
                            LogFile.Error.Show("ERROR:f_ConsumptionType:Get:" + sql + "\r\nErr=" + Err);
                            return false;
                        }
                    }
                }
                else
                {
                    sql = @"insert into ConsumptionType (Name,Description) values (" + sval_Name + ","+ sval_Description + ")";
                    if (transaction.ExecuteNonQuerySQLReturnID(DBSync.DBSync.Con, sql, lpar, ref consumptionType_ID, ref Err, "ConsumptionType"))
                    {
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:f_ConsumptionType:Get:" + sql + "\r\nErr=" + Err);
                        return false;
                    }
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:f_OwnUseReason:Get:" + sql + "\r\nErr=" + Err);
                return false;
            }
        }

        public static bool GetTable(ref DataTable dt)
        {
          
            string Err = null;
            if (dt!=null)
            {
                dt.Dispose();
                dt = null;
            }
            dt = new DataTable();

            string sql = @"select ID,Name, Description from ConsumptionType";

            if (DBSync.DBSync.ReadDataTable(ref dt, sql,  ref Err))
            {
                 return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:f_OwnUseReason:GetTable:" + sql + "\r\nErr=" + Err);
                return false;
            }
        }

        internal static bool GetDefaultConsumptionTypes(Transaction transaction_Type_definitions_Read)
        {
            if (f_ConsumptionType.Get(const_ConsumptionWriteOff, lng.s_WriteOff.s, ref ConsumptionType_WriteOff_ID, transaction_Type_definitions_Read))
            {
                if (f_ConsumptionType.Get(const_ConsumptionOwnUse, lng.s_OwnUse.s, ref ConsumptionType_OwnUse_ID, transaction_Type_definitions_Read)) 
                {
                    if (f_ConsumptionType.Get(const_ConsumptionSoldByGiftCertificate, lng.s_SoldByGiftCertificate.s, ref ConsumptionType_SoldByGiftCertificate_ID, transaction_Type_definitions_Read))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
