using DBConnectionControl40;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace TangentaDB
{
    public static class f_PurchasePrice
    {
        private static DataTable dtPurchasePrice = null;

        public static bool Get(decimal PricePerUnit,long ID_Taxation,long ID_Currency, ref long PurchasePrice_ID)
        {
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();

            string spar_PricePerUnit = "@par_PricePerUnit";
            SQL_Parameter par_PricePerUnit = new SQL_Parameter(spar_PricePerUnit, SQL_Parameter.eSQL_Parameter.Decimal, false, PricePerUnit);
            lpar.Add(par_PricePerUnit);

            string spar_ID_Taxation = "@par_ID_Taxation";
            SQL_Parameter par_ID_Taxation = new SQL_Parameter(spar_ID_Taxation, SQL_Parameter.eSQL_Parameter.Bigint, false, ID_Taxation);
            lpar.Add(par_ID_Taxation);

            string spar_ID_Currency = "@par_ID_Currency";
            SQL_Parameter par_ID_Currency = new SQL_Parameter(spar_ID_Currency, SQL_Parameter.eSQL_Parameter.Bigint, false, ID_Currency);
            lpar.Add(par_ID_Currency);

            string sql = "select ID from PurchasePrice where PurchasePricePerUnit = " + spar_PricePerUnit + " and  Currency_ID = " + spar_ID_Currency + " and Taxation_ID = " + spar_ID_Taxation;
            DataTable dt = new DataTable();
            string Err = null;
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    PurchasePrice_ID = (long)dt.Rows[0]["ID"];
                    return true;
                }
                else
                {
                    DateTime dtPurchasePriceDate = DateTime.Now;
                    string spar_PurchasePriceDate = "@par_PurchasePriceDate";
                    SQL_Parameter par_PurchasePriceDate = new SQL_Parameter(spar_PurchasePriceDate, SQL_Parameter.eSQL_Parameter.Datetime, false, dtPurchasePriceDate);
                    lpar.Add(par_PurchasePriceDate);
                    sql = "insert into PurchasePrice (PurchasePricePerUnit,Currency_ID,Taxation_ID,PurchasePriceDate)values(" + spar_PricePerUnit + "," + spar_ID_Currency + "," + spar_ID_Taxation + ","+ spar_PurchasePriceDate + ")";
                    object oret = null;
                    if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar, ref PurchasePrice_ID, ref oret, ref Err, "PurchasePrice"))
                    {
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:TangentaDB:f_PurchasePrice:Get:sql=" + sql + "\r\nErr=" + Err);
                        return false;
                    }
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:TangentaDB:f_PurchasePrice:Get:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }
    }
}
