using DBConnectionControl40;
using DBTypes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace TangentaDB
{
    public static class f_Consumption_ShopC_Item_Source
    {

        public static bool Get(ID docInvoice_ShopC_Item_ID,ref DataTable dt)
        {
            string Err = null;
            if (dt!=null)
            {
                dt.Dispose();
                dt = null;
            }
            dt = new DataTable();
            string sql = @" select
                                   cscis.Consumption_ShopC_Item_ID as Consumption_ShopC_Item_ID,
                                   cscis.ID as Consumption_ShopC_Item_Source_ID,
                                   cscis.Stock_ID as Stock_ID,
                                   cscis.dQuantity as dQuantity,
                                   s.dQuantity as Stock_dQuantity,
								   s.ImportTime as Stock_ImportTime,
								   s.ExpiryDate as ExpiryDate,
                                   pp.PurchasePricePerUnit as PurchasePricePerUnit,
                                   pp.Discount as PurchasePricePerUnit_Discount,
                                   t.Name as Taxation_Name,
                                   t.Rate as Taxation_Rate,
                                  i.UniqueName as Item_UniqueName,
                                  st.Name as StockTakeName,
                                  st.StockTake_Date as StockTake_Date
                                  from Consumption_ShopC_Item_Source cscis
                                  inner join Stock s on cscis.Stock_ID = s.ID
                                  inner join PurchasePrice_Item ppi on s.PurchasePrice_Item_ID = ppi.ID
								  inner join PurchasePrice pp on ppi.PurchasePrice_ID = pp.ID
                                  inner join Taxation t on pp.Taxation_ID = t.ID
                                  inner join Currency c on pp.Currency_ID = c.ID
                                  left join StockTake st on ppi.StockTake_ID = st.ID
                                  left join Item i on ppi.Item_ID = i.ID
                                  where cscis.Consumption_ShopC_Item_ID = " + docInvoice_ShopC_Item_ID.ToString();
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, ref Err))
            {
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:TangentaDB:f_Consumption_ShopC_Item_Source:Get:sql=" + sql + "\r\nErr" + Err);
                return false;
            }

        }


        public static bool Delete(ID consumption_ShopC_Item_Source_ID, Transaction transaction)
        {
            string sql = "delete from Consumption_ShopC_Item_Source where ID = " + consumption_ShopC_Item_Source_ID.ToString();
            string Err = null;
            if (transaction.ExecuteNonQuerySQL(DBSync.DBSync.Con,sql, null, ref Err))
            {
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:TangentaDB:f_Consumption_ShopC_Item_Source:Delete:sql=" + sql + "\r\nErr" + Err);
                return false;
            }
        }

       

        public static bool UpdateQuantity(ID doc_ShopC_Item_Source_ID, decimal dquantity_new, Transaction transaction)
        {
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();

            string spar_dQuantity = "@par_dQuantity";
            SQL_Parameter par_dQuantity = new SQL_Parameter(spar_dQuantity, SQL_Parameter.eSQL_Parameter.Decimal, false, dquantity_new);
            lpar.Add(par_dQuantity);

            string sql = "update Consumption_ShopC_Item_Source set dQuantity = " + spar_dQuantity
                            + " where ID = " + doc_ShopC_Item_Source_ID.ToString();
            string Err = null;
            if (transaction.ExecuteNonQuerySQL(DBSync.DBSync.Con,sql, lpar,  ref Err))
            {
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:TangentaDB:f_Consumption_ShopC_Item_Source:UpdateQuantity:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }

        public static bool Insert(ID cons_ShopC_Item_ID,
                                  ID stock_ID,
                                  decimal xdQuantity,
                                  ref ID Consumption_ShopC_Item_Source_ID,
                                  Transaction transaction)
        {
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();

            string spar_dQuantity = "@par_dQuantity";
            SQL_Parameter par_dQuantity = new SQL_Parameter(spar_dQuantity, SQL_Parameter.eSQL_Parameter.Decimal, false, xdQuantity);
            lpar.Add(par_dQuantity);


            string spar_Consumption_ShopC_Item_ID = "@par_Consumption_ShopC_Item_ID";
            SQL_Parameter par_Doc_ShopC_Item_ID = new SQL_Parameter(spar_Consumption_ShopC_Item_ID, false, cons_ShopC_Item_ID);
            lpar.Add(par_Doc_ShopC_Item_ID);

           
            string sval_stock_ID = "null";
            if (ID.Validate(stock_ID))
            {
                string spar_stock_ID = "@par_stock_ID";
                SQL_Parameter par_stock_ID = new SQL_Parameter(spar_stock_ID, false, stock_ID);
                lpar.Add(par_stock_ID);
                sval_stock_ID = spar_stock_ID;
            }


            string sql = @"insert into Consumption_ShopC_Item_Source
                           (
                            Consumption_ShopC_Item_ID,
                            Stock_ID,
                            dQuantity
                            )
                            values
                            (
                            " + spar_Consumption_ShopC_Item_ID + @",
                            " + sval_stock_ID + @",
                            " + spar_dQuantity + ")";
            string Err = null;
            if (transaction.ExecuteNonQuerySQLReturnID(DBSync.DBSync.Con,sql, lpar, ref Consumption_ShopC_Item_Source_ID, ref Err, "Consumption_ShopC_Item_Source"))
            {
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:TangentaDB:f_Consumption_ShopC_Item_Source:Insert:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }

       
        internal static bool Update(ID doc_ShopC_Item_Source_ID, decimal dnewQuantity, Transaction transaction)
        {
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();

            string spar_dQuantity = "@par_dQuantity";
            SQL_Parameter par_dQuantity = new SQL_Parameter(spar_dQuantity, SQL_Parameter.eSQL_Parameter.Decimal, false, dnewQuantity);
            lpar.Add(par_dQuantity);


           


            string sql = @"update Consumption_ShopC_Item_Source set
                           
                            dQuantity = " + spar_dQuantity + @" 
                            where ID = " + doc_ShopC_Item_Source_ID.ToString();
            string Err = null;
            if (transaction.ExecuteNonQuerySQL(DBSync.DBSync.Con,sql, lpar,  ref Err))
            {
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:TangentaDB:f_Consumption_ShopC_Item_Source:Update:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }
    }
}
