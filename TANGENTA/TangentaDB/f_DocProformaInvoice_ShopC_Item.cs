using DBConnectionControl40;
using DBTypes;
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

        public static bool GetItems(ID currentDoc_ID, ID item_ID, ref DataTable dtShopCItems)
        {
            string sql = @"select
                                   dpisci.ID as DocProformaInvoice_ShopC_Item_ID,
                                   dpisci.dQuantity,
                                   dpisci.ExtraDiscount,
                                   dpisci.RetailPriceWithDiscount,
                                   dpisci.TaxPrice,
                                   dpisci.DocProformaInvoice_ID,
                                   dpisci.Atom_Price_Item_ID,
                                   dpisci.ExpiryDate,
                                   dpisci.Stock_ID,
                                   api.RetailPricePerUnit as api_RetailPricePerUnit,
                                   api.Discount as api_Discount,
                                   api.Atom_Taxation_ID as api_Atom_Taxation_ID,
                                   api.Atom_Item_ID as api_Atom_Item_ID, 
                                   api.Atom_PriceList_ID as api_Atom_PriceList_ID,
								   s.ImportTime as Stock_ImportTime,
								   s.dQuantity as Stock_dQuantity,
								   s.ExpiryDate as Stock_ExpiryDate,
								   s.PurchasePrice_Item_ID as PurchasePrice_Item_ID,
								   s.Stock_AddressLevel1_ID as Stock_AddressLevel1_ID,
								   s.Description as Stock_Description,
                                   s.ExpiryDate as Stock_ExpiriyDate,
								   ppi.Item_ID as ppi_Item_ID,
								   ppi.PurchasePrice_ID as ppi_PurchasePrice_ID,
								   ppi.StockTake_ID as ppi_StockTake_ID,
                                  st.Name as StockTakeName,
                                  st.StockTake_Date
                                  from DocproformaInvoice_ShopC_Item dpisci
                                  left join Stock s on dpisci.Stock_ID = s.ID

                                  left join PurchasePrice_Item ppi on ppi.ID = s.PurchasePrice_Item_ID

                                  left join PurchasePrice pp on pp.ID = ppi_PurchasePrice_ID
                                  left join StockTake st on ppi.StockTake_ID = st.ID

                                  left join Item i on i.ID = ppi.Item_ID
                                  left join Atom_Price_Item api on dpisci.Atom_Price_Item_ID = api.ID
                                  left join Atom_Taxation atax on api.Atom_Taxation_ID = atax.ID
                                  left join Atom_Item ai on api.Atom_Item_ID = ai.ID
                                  left join Atom_PriceList apl on api.Atom_PriceList_ID = apl.ID
                                  where dpisci.DocProformaInvoice_ID = " + currentDoc_ID.ToString()
                                                                        + " and ppi.Item_ID = " + item_ID.ToString();
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
                LogFile.Error.Show("ERROR:TangentaDB:f_DocProformaInvoice_ShopC_Item:GetItems:sql=" + sql + "\r\nErr" + Err);
                return false;
            }

        }

        public static bool UpdateQuantity(ID doc_ShopC_Item_ID, decimal dquantity_new)
        {
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();

            string spar_dQuantity = "@par_dQuantity";
            SQL_Parameter par_dQuantity = new SQL_Parameter(spar_dQuantity, SQL_Parameter.eSQL_Parameter.Decimal, false, dquantity_new);
            lpar.Add(par_dQuantity);

            string sql = "update DocProformaInvoice_ShopC_Item set dQuantity = " + spar_dQuantity
                            + " where ID = " + doc_ShopC_Item_ID.ToString();
            object oret = null;
            string Err = null;
            if (DBSync.DBSync.ExecuteNonQuerySQL(sql, lpar, ref oret, ref Err))
            {
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:TangentaDB:f_DocProformaInvoice_ShopC_Item:UpdateQuantity:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }

        public static bool Insert(ID doc_ShopC_Item_ID,
                                  decimal xdQuantity,
                                  decimal_v extraDiscount_v,
                                  decimal retailPriceWithDiscount,
                                  decimal taxPrice,
                                  ID docProformaInvoice_ID,
                                  ID atom_Price_Item_ID,
                                  DateTime_v expiryDate_v,
                                  ID stock_ID,
                                  ref ID DocInvoice_ShopC_Item_ID)
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

            string spar_DocProformaInvoice_ID = "@par_DocProformaInvoice_ID";
            SQL_Parameter par_DocProformaInvoice_ID = new SQL_Parameter(spar_DocProformaInvoice_ID, false, docProformaInvoice_ID);
            lpar.Add(par_DocProformaInvoice_ID);

            string spar_atom_Price_Item_ID = "@par_atom_Price_Item_ID";
            SQL_Parameter par_atom_Price_Item_ID = new SQL_Parameter(spar_atom_Price_Item_ID, false, atom_Price_Item_ID);
            lpar.Add(par_atom_Price_Item_ID);

            string sval_expiryDate = "null";
            if (expiryDate_v != null)
            {
                string spar_expiryDate = "@par_expiryDate";
                SQL_Parameter par_expiryDate = new SQL_Parameter(spar_expiryDate, SQL_Parameter.eSQL_Parameter.Datetime, false, expiryDate_v.v);
                lpar.Add(par_expiryDate);
                sval_expiryDate = spar_expiryDate;
            }

            string spar_stock_ID = "@par_stock_ID";
            SQL_Parameter par_stock_ID = new SQL_Parameter(spar_stock_ID, false, stock_ID);
            lpar.Add(par_stock_ID);


            string sql = @"insert into DocProformaInvoice_ShopC_Item
                           (
                            dQuantity,
                            ExtraDiscount,
                            RetailPriceWithDiscount
                            TaxPrice
                            DocProformaInvoice_ID
                            Atom_Price_Item_ID
                            ExpiryDate
                            Stock_ID)
                            values
                            (
                            " + spar_dQuantity + @",
                            " + sval_extraDiscount + @",
                            " + spar_retailPriceWithDiscount + @",
                            " + spar_taxPrice + @",
                            " + spar_DocProformaInvoice_ID + @",
                            " + spar_atom_Price_Item_ID + @",
                            " + sval_expiryDate + @",
                            " + spar_stock_ID + @")";
            string Err = null;
            if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar, ref DocInvoice_ShopC_Item_ID, ref Err, "DocProformaInvoice_ShopC_Item"))
            {
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:TangentaDB:f_DocProformaInvoice_ShopC_Item:Insert:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }
    }
}
