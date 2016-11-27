using DBConnectionControl40;
using DBTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace TangentaDB
{
    public static class f_Stock
    {
        public static bool Add(DateTime tImportTime,decimal dQuantity,DateTime_v tExpiry_v,long PurchasePrice_Item_ID,long Stock_AddressLevel1_ID,string Description, ref long Stock_ID)
        {
            string Err = null;
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();

            string spar_ImportTime = "@par_ImportTime";
            SQL_Parameter par_ImportTime = new SQL_Parameter(spar_ImportTime, SQL_Parameter.eSQL_Parameter.Datetime, false, tImportTime);
            lpar.Add(par_ImportTime);

            string spar_dQuantity = "@par_dQuantity";
            SQL_Parameter par_dQuantity = new SQL_Parameter(spar_dQuantity, SQL_Parameter.eSQL_Parameter.Decimal, false, dQuantity);
            lpar.Add(par_dQuantity);

            string spar_tExpiry = "null";
            if (tExpiry_v != null)
            {
                spar_tExpiry = "@par_tExpiry";
                SQL_Parameter par_tExpiry = new SQL_Parameter(spar_tExpiry, SQL_Parameter.eSQL_Parameter.Datetime, false, tExpiry_v.v);
                lpar.Add(par_tExpiry);
            }

            string spar_PurchasePrice_Item_ID = "@par_PurchasePrice_Item_ID";
            SQL_Parameter par_PurchasePrice_Item_ID = new SQL_Parameter(spar_PurchasePrice_Item_ID, SQL_Parameter.eSQL_Parameter.Bigint, false, PurchasePrice_Item_ID);
            lpar.Add(par_PurchasePrice_Item_ID);

            string spar_Stock_AddressLevel1_ID = "null";
            if (Stock_AddressLevel1_ID >= 0)
            {
                spar_Stock_AddressLevel1_ID = "@par_Stock_AddressLevel1_ID";
                SQL_Parameter par_Stock_AddressLevel1_ID = new SQL_Parameter(spar_Stock_AddressLevel1_ID, SQL_Parameter.eSQL_Parameter.Bigint, false, Stock_AddressLevel1_ID);
                lpar.Add(par_Stock_AddressLevel1_ID);
            }

            string spar_Description = "null";
            if (Description != null)
            {
                if (Description.Length > 0)
                {
                    spar_Description = "@par_Description";
                    SQL_Parameter par_Description = new SQL_Parameter(spar_Description, SQL_Parameter.eSQL_Parameter.Nvarchar, false, Description);
                    lpar.Add(par_Description);
                }
            }
            string sql = "insert into Stock (ImportTime,dQuantity,ExpiryDate,PurchasePrice_Item_ID,Stock_AddressLevel1_ID,description)values(" 
                         + spar_ImportTime 
                         + "," + spar_dQuantity 
                         + "," + spar_tExpiry
                         + "," + spar_PurchasePrice_Item_ID
                         + "," + spar_Stock_AddressLevel1_ID
                         + "," + spar_Description
                         + ")";
            object oret = null;
            if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar, ref Stock_ID, ref oret, ref Err, "Stock"))
            {
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:TangentaDB:f_Stock:Add:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }

        public static bool Get_OfStockTake(ref DataTable dt_Stock_Of_Current_StockTake, long stockTake__ID)
        {
            string sql = @"select ";
            return false;

        }
    }
}
