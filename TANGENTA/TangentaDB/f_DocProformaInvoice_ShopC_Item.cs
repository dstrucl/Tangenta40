using DBConnectionControl40;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace TangentaDB
{
    public static class f_DocProformaInvoice_ShopC_Item
    {
        public class fData
        {
            public decimal QuantityTakenFromStock = -1;
            public string Item_UniqueName = "";
            public string StockTakeName = "";
            public DateTime ExpiryDate = DateTime.MinValue;
            public DateTime StockTakeDate = DateTime.MinValue;
        }

        public static bool Get(ID docProformaInvoice_ShopC_Item_ID,
                               ref fData ret_data)
        {
            string Err = null;
            DataTable dt = new DataTable();
            string sql = @"select dpisci.dQuantity as QuantityTakenFromStock,
                                  s.ExpiryDate,
                                  i.UniqueName,
                                  st.Name as StockTakeName,
                                  st.StockTake_Date
                                  from DocProformaInvoice_ShopC_Item dpisci
                                  inner join Stock s on dpisci.Stock_ID = s.ID
                                  inner join PurchasePrice_Item ppi on s.PurchasePrice_Item_ID = ppi.ID
                                  inner join StockTake st on ppi.StockTake_ID = st.ID
                                  inner join Item i on ppi.Item_ID = i.ID
                                  where dpisci.ID = " + docProformaInvoice_ShopC_Item_ID.ToString();
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    ret_data.QuantityTakenFromStock = DBTypes.tf._set_decimal(dt.Rows[0]["QuantityTakenFromStock"]);
                    ret_data.ExpiryDate = DBTypes.tf._set_DateTime(dt.Rows[0]["ExpiryDate"]);
                    ret_data.Item_UniqueName = DBTypes.tf._set_string(dt.Rows[0]["UniqueName"]);
                    ret_data.StockTakeName = DBTypes.tf._set_string(dt.Rows[0]["StockTakeName"]);
                    ret_data.StockTakeDate = DBTypes.tf._set_DateTime(dt.Rows[0]["StockTake_Date"]);
                    return true;
                }
                else
                {
                    LogFile.Error.Show("ERROR:TangentaDB:f_DocProformaInvoice_ShopC_Item:Get:sql=" + sql + "\r\nNo docProformaInvoice_ShopC_Item data for ID = " + docProformaInvoice_ShopC_Item_ID.ToString());
                    return false;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:TangentaDB:f_DocProformaInvoice_ShopC_Item:Get:sql=" + sql + "\r\nErr" + Err);
                return false;
            }

        }
    }
}
