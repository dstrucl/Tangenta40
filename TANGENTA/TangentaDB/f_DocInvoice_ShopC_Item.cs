using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace TangentaDB
{
    public static class f_DocInvoice_ShopC_Item
    {
        public static bool Get(long docInvoice_ShopC_Item_ID, 
                               ref decimal QuantityTakenFromStock,
                               ref DateTime ExpiryDate,
                               ref string item_UniqueName, 
                               ref string stockTakeName, 
                               ref DateTime stockTakeDate)
        {
            string Err = null;
            DataTable dt = new DataTable();
            string sql = @"select disci.dQuantity as QuantityTakenFromStock,
                                  ExpiryDate,
                                  i.UniqueName,
                                  st.Name as StockTakeName,
                                  st.StockTakeDate
                                  from DocInvoice_ShopC_Item disci
                                  inner join Stock s on disci.Stock_ID = s.ID
                                  inner join PurchasePrice_Item ppi on s.PurchasePrice_Item_ID = ppi.ID
                                  inner join StockTake st on ppi.StockTake_ID = st.ID
                                  inner join Item i on ppi.Item_ID = i.ID
                                  where DocInvoice_ShopC_Item.ID = " + docInvoice_ShopC_Item_ID.ToString();
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    QuantityTakenFromStock = DBTypes.tf._set_decimal(dt.Rows[0]["QuantityTakenFromStock"]);
                    ExpiryDate = DBTypes.tf._set_DateTime(dt.Rows[0]["ExpiryDate"]);
                    item_UniqueName = DBTypes.tf._set_string(dt.Rows[0]["UniqueName"]);
                    stockTakeName = DBTypes.tf._set_string(dt.Rows[0]["StockTakeName"]);
                    stockTakeDate = DBTypes.tf._set_DateTime(dt.Rows[0]["StockTakeDate"]);
                    return true;
                }
                else
                {
                    LogFile.Error.Show("ERROR:TangentaDB:f_DocInvoice_ShopC_Item:Get:sql=" + sql + "\r\nNo DocInvoice_ShopC_Item data for ID = " + docInvoice_ShopC_Item_ID.ToString());
                    return false;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:TangentaDB:f_DocInvoice_ShopC_Item:Get:sql=" + sql + "\r\nErr" + Err);
                return false;
            }

        }
    }
}
