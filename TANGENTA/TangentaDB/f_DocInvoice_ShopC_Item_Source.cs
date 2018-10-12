using DBConnectionControl40;
using DBTypes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace TangentaDB
{
    public static class f_DocInvoice_ShopC_Item_Source
    {
        public class fData
        {
            public decimal QuantityTakenFromStock = -1;
            public DateTime ExpiryDate = DateTime.MinValue;
            public string Item_UniqueName = null;
            public string StockTakeName = null;
            public DateTime StockTakeDate = DateTime.MinValue;
        }

        public static bool Get(ID docInvoice_ShopC_Item_Source_ID, ref fData data)
        {
            string Err = null;
            DataTable dt = new DataTable();
            string sql = @" select discis.dQuantity as QuantityTakenFromStock,
                                  s.ExpiryDate,
                                  i.UniqueName,
                                  st.Name as StockTakeName,
                                  st.StockTake_Date
                                  from DocInvoice_ShopC_Item_Source discis
                                  inner join Stock s on discis.Stock_ID = s.ID
                                  inner join PurchasePrice_Item ppi on s.PurchasePrice_Item_ID = ppi.ID
                                  inner join StockTake st on ppi.StockTake_ID = st.ID
                                  inner join Item i on ppi.Item_ID = i.ID
                                  where discis.ID = " + docInvoice_ShopC_Item_Source_ID.ToString();
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    data.QuantityTakenFromStock = DBTypes.tf._set_decimal(dt.Rows[0]["QuantityTakenFromStock"]);
                    data.ExpiryDate = DBTypes.tf._set_DateTime(dt.Rows[0]["ExpiryDate"]);
                    data.Item_UniqueName = DBTypes.tf._set_string(dt.Rows[0]["UniqueName"]);
                    data.StockTakeName = DBTypes.tf._set_string(dt.Rows[0]["StockTakeName"]);
                    data.StockTakeDate = DBTypes.tf._set_DateTime(dt.Rows[0]["StockTake_Date"]);
                    return true;
                }
                else
                {
                    LogFile.Error.Show("ERROR:TangentaDB:f_DocInvoice_ShopC_Item_Source:Get:sql=" + sql + "\r\nNo DocInvoice_ShopC_Item data for ID = " + docInvoice_ShopC_Item_Source_ID.ToString());
                    return false;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:TangentaDB:f_DocInvoice_ShopC_Item_Source:Get:sql=" + sql + "\r\nErr" + Err);
                return false;
            }

        }

        public static bool GetItem_Source(ID DocInvoice_ShopC_Item_ID, ref DataTable dtShopCItems)
        {
            string sql = @"select 
                                   
                                   discis.ID as DocInvoice_ShopC_Item_Source_ID,
                                   discis.dQuantity,
                                   discis.Stock_ID,
                                   i.UniqueName as Item_UniqueName,
                                   discis.ExtraDiscount,
                                   discis.RetailPriceWithDiscount,
                                   discis.TaxPrice,
                                   discis.ExpiryDate,
								   s.ImportTime as Stock_ImportTime,
								   s.dQuantity as Stock_dQuantity,
								   s.ExpiryDate as Stock_ExpiryDate,
								   s.PurchasePrice_Item_ID as PurchasePrice_Item_ID,
								   s.Stock_AddressLevel1_ID as Stock_AddressLevel1_ID,
								   s.Description  as Stock_Description,
                                   s.ExpiryDate as Stock_ExpiriyDate,
								   ppi.Item_ID as ppi_Item_ID,
								   ppi.PurchasePrice_ID as ppi_PurchasePrice_ID,
								   ppi.StockTake_ID as ppi_StockTake_ID,
                                  st.Name as StockTakeName,
                                  st.StockTake_Date,
                                  discis.Stock_ID as Stock_ID
                                  from DocInvoice_ShopC_Item_Source discis
                                  left join Stock s on discis.Stock_ID = s.ID
								  left join PurchasePrice_Item ppi on ppi.ID = s.PurchasePrice_Item_ID
								  left join PurchasePrice pp on pp.ID = ppi_PurchasePrice_ID
                                  left join StockTake st on ppi.StockTake_ID = st.ID
								  left join Item i on i.ID = ppi.Item_ID
                                  where discis.DocInvoice_ShopC_Item_ID = " + DocInvoice_ShopC_Item_ID.ToString();

            if (dtShopCItems == null)
            {
                dtShopCItems = new DataTable();
            }
            else
            {
                dtShopCItems.Clear();
                dtShopCItems.Columns.Clear();
            }
            string Err = null;
            if (DBSync.DBSync.ReadDataTable(ref dtShopCItems, sql, ref Err))
            {
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:TangentaDB:f_DocInvoice_ShopC_Item_Source:GetItems:sql=" + sql + "\r\nErr" + Err);
                return false;
            }
        }

        public static bool Delete(ID doc_ShopC_Item_Source_ID)
        {
            string sql = "delete from DocInvoice_ShopC_Item_Source where ID = " + doc_ShopC_Item_Source_ID.ToString();
            object objret = null;
            string Err = null;
            if (DBSync.DBSync.ExecuteNonQuerySQL(sql, null, ref objret, ref Err))
            {
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:TangentaDB:f_DocInvoice_ShopC_Item_Source:Delete:sql=" + sql + "\r\nErr" + Err);
                return false;
            }
        }

        public static bool GetItems(ID Doc_ShopC_Item_ID,ID item_ID, ref DataTable dtShopCItems)
        {
            string sql = @"select 
                                   discis.ID as DocInvoice_ShopC_Item_Source_ID,
                                   discis.dQuantity as dQuantity,
                                   discis.Stock_ID,
                                   i.UniqueName as Item_UniqueName,
                                   discis.ExtraDiscount as ExtraDiscount,
                                   discis.RetailPriceWithDiscount as RetailPriceWithDiscount,
                                   discis.TaxPrice as TaxPrice,
                                   discis.ExpiryDate as ExpiryDate,
								   s.ImportTime as Stock_ImportTime,
								   s.dQuantity as Stock_dQuantity,
								   s.ExpiryDate as Stock_ExpiryDate,
								   s.PurchasePrice_Item_ID as PurchasePrice_Item_ID,
								   s.Stock_AddressLevel1_ID as Stock_AddressLevel1_ID,
								   s.Description  as Stock_Description,
                                   s.ExpiryDate as Stock_ExpiriyDate,
								   ppi.Item_ID as ppi_Item_ID,
								   ppi.PurchasePrice_ID as ppi_PurchasePrice_ID,
								   ppi.StockTake_ID as ppi_StockTake_ID,
                                  st.Name as StockTakeName,
                                  st.StockTake_Date
                                  from DocInvoice_ShopC_Item_Source discis
                                  left join Stock s on discis.Stock_ID = s.ID
                                  left join JOURNAL_Stock js on js.Stock_ID = s.ID
                                  left join JOURNAL_Stock_Type jst on jst.ID = js.JOURNAL_Stock_Type_ID and jst.Name = 'New Stock Data'
								  left join PurchasePrice_Item ppi on ppi.ID = s.PurchasePrice_Item_ID
								  left join PurchasePrice pp on pp.ID = ppi_PurchasePrice_ID
                                  left join StockTake st on ppi.StockTake_ID = st.ID
								  left join Item i on i.ID = ppi.Item_ID
                                  where discis.DocInvoice_ShopC_Item_ID =" + Doc_ShopC_Item_ID.ToString() + " and ppi.Item_ID = "+ item_ID.ToString()
                                  + " order by js.EventTime asc";

            if (dtShopCItems == null)
            {
                dtShopCItems = new DataTable();
            }
            else
            {
                dtShopCItems.Dispose();
                dtShopCItems = new DataTable();
            }
            string Err = null;
            if (DBSync.DBSync.ReadDataTable(ref dtShopCItems, sql, ref Err))
            {
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:TangentaDB:f_DocInvoice_ShopC_Item_Source:GetItems:sql=" + sql + "\r\nErr" + Err);
                return false;
            }
        }

        public static bool UpdateQuantity(ID doc_ShopC_Item_Source_ID, decimal dquantity_new)
        {
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();

            string spar_dQuantity = "@par_dQuantity";
            SQL_Parameter par_dQuantity = new SQL_Parameter(spar_dQuantity, SQL_Parameter.eSQL_Parameter.Decimal, false, dquantity_new);
            lpar.Add(par_dQuantity);

            string sql = "update DocInvoice_ShopC_Item_Source set dQuantity = " + spar_dQuantity
                            + " where ID = " + doc_ShopC_Item_Source_ID.ToString();
            object oret = null;
            string Err = null;
            if (DBSync.DBSync.ExecuteNonQuerySQL(sql, lpar, ref oret, ref Err))
            {
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:TangentaDB:f_DocInvoice_ShopC_Item_Source:UpdateQuantity:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }

        public static bool Insert(ID doc_ShopC_Item_ID,
                                  decimal xdQuantity,
                                  decimal_v extraDiscount_v,
                                  decimal retailPriceWithDiscount,
                                  decimal taxPrice,
                                  DateTime_v expiryDate_v,
                                  ID stock_ID,
                                  ref ID DocInvoice_ShopC_Item_Source_ID)
        {
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();

            string spar_dQuantity = "@par_dQuantity";
            SQL_Parameter par_dQuantity = new SQL_Parameter(spar_dQuantity, SQL_Parameter.eSQL_Parameter.Decimal, false, xdQuantity);
            lpar.Add(par_dQuantity);

            string sval_extraDiscount = "null";
            if (extraDiscount_v != null)
            {
                string spar_extraDiscount = "@par_extraDiscount";
                SQL_Parameter par_extraDiscount = new SQL_Parameter(spar_extraDiscount, SQL_Parameter.eSQL_Parameter.Decimal, false, extraDiscount_v.v);
                lpar.Add(par_extraDiscount);
                sval_extraDiscount = spar_extraDiscount;
            }

            string spar_retailPriceWithDiscount = "@par_retailPriceWithDiscount";
            SQL_Parameter par_retailPriceWithDiscount = new SQL_Parameter(spar_retailPriceWithDiscount, SQL_Parameter.eSQL_Parameter.Decimal, false, retailPriceWithDiscount);
            lpar.Add(par_retailPriceWithDiscount);

            string spar_taxPrice = "@par_taxPrice";
            SQL_Parameter par_taxPrice = new SQL_Parameter(spar_taxPrice, SQL_Parameter.eSQL_Parameter.Decimal, false, taxPrice);
            lpar.Add(par_taxPrice);

            string spar_Doc_ShopC_Item_ID = "@par_DocInvoice_ShopC_Item_ID";
            SQL_Parameter par_Doc_ShopC_Item_ID = new SQL_Parameter(spar_Doc_ShopC_Item_ID, false, doc_ShopC_Item_ID);
            lpar.Add(par_Doc_ShopC_Item_ID);

            string sval_expiryDate = "null";
            if (expiryDate_v!=null)
            {
                string spar_expiryDate = "@par_expiryDate";
                SQL_Parameter par_expiryDate = new SQL_Parameter(spar_expiryDate,SQL_Parameter.eSQL_Parameter.Datetime, false, expiryDate_v.v);
                lpar.Add(par_expiryDate);
                sval_expiryDate = spar_expiryDate;
            }

            string sval_stock_ID = "null";
            if (ID.Validate(stock_ID))
            {
                string spar_stock_ID = "@par_stock_ID";
                SQL_Parameter par_stock_ID = new SQL_Parameter(spar_stock_ID, false, stock_ID);
                lpar.Add(par_stock_ID);
                sval_stock_ID = spar_stock_ID;
            }


            string sql = @"insert into DocInvoice_ShopC_Item_Source
                           (
                            DocInvoice_ShopC_Item_ID,
                            dQuantity,
                            ExtraDiscount,
                            RetailPriceWithDiscount,
                            TaxPrice,
                            DocInvoice_ID,
                            ExpiryDate,
                            Stock_ID)
                            values
                            (
                            " + spar_Doc_ShopC_Item_ID + @",
                            " + spar_dQuantity + @",
                            " + sval_extraDiscount + @",
                            " + spar_retailPriceWithDiscount + @",
                            " + spar_taxPrice + @",
                            " + sval_expiryDate + @",
                            " + sval_stock_ID + @")";
            string Err = null;
            if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar, ref DocInvoice_ShopC_Item_Source_ID, ref Err, "DocInvoice_ShopC_Item_Source"))
            {
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:TangentaDB:f_DocInvoice_ShopC_Item_Source:Insert:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }
    }
}
