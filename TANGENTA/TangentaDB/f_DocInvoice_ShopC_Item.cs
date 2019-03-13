using DBConnectionControl40;
using DBTypes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace TangentaDB
{
    public static class f_DocInvoice_ShopC_Item
    {
        public class fData
        {

            public string AtomItem_UniqueName = null;
            public string AtomItem_Name = null;
            public string AtomItem_Description = null;
            public string AtomUnit_Name = null;
            public string AtomUnit_Symbol = null;
            public int_v AtomUnit_DecimalPlaces_v = null;
            public bool_v AtomUnit_StorageOption_v = null;
            public string AtomUnit_Description;
            public decimal_v ExtraDiscount_v = null;
            public decimal_v RetailPricePerUnit_v = null;
            public string AtomItemBarcode = null;
            public decimal_v Discount_v = null;
            public string Atom_TaxationName = null;
            public decimal_v Atom_TaxationRate_v = null;
            public string AtomPriceList_Name = null;
            public int_v AtomExpiry_ExpectedShelfLifeInDays_v = null;
            public int_v AtomExpiry_SaleBeforeExpiryDateInDays_v = null;
            public int_v AtomExpiry_DiscardBeforeExpiryDateInDays_v = null;
            public string AtomExpiry_ExpiryDescription = null;

            public int_v Atom_WarrantyDuration_v = null;
            public int_v Atom_WarrantyDurationType_v = null;
            public string Atom_WarrantyConditions = null;

            public ID DocInvoice_ID = null;
            public ID DocInvoice_ShopC_Item_ID = null;
	        public ID Atom_Price_Item_ID = null;
        }

        public static bool Get(ID docInvoice_ShopC_Item_ID, ref fData data)
        {
            string Err = null;
            DataTable dt = new DataTable();
            string sql = @"select 					
    ai.UniqueName as AtomItem_UniqueName,
    ain.Name as AtomItem_Name,
	aid.Description as AtomItem_Description,
	au.Name as AtomUnit_Name,
	au.Symbol as AtomUnit_Symbol,
	au.DecimalPlaces as AtomUnit_DecimalPlaces,
	au.StorageOption as AtomUnit_StorageOption,
	au.Description as AtomUnit_Description,
	disci.ExtraDiscount as ExtraDiscount,
	api.RetailPricePerUnit as RetailPricePerUnit,
	aib.barcode as AtomItemBarcode,
	api.Discount as Discount,
	atax.Name as Atom_TaxationName,
	atax.Rate as Atom_TaxationRate,
	apln.Name as AtomPriceList_Name,
	ae.ExpectedShelfLifeInDays as AtomExpiry_ExpectedShelfLifeInDays,
    ae.SaleBeforeExpiryDateInDays as AtomExpiry_SaleBeforeExpiryDateInDays,
	ae.DiscardBeforeExpiryDateInDays as AtomExpiry_DiscardBeforeExpiryDateInDays,
	ae.ExpiryDescription as AtomExpiry_ExpiryDescription,
	
	aw.WarrantyDuration as Atom_WarrantyDuration,
    aw.WarrantyDurationType as  Atom_WarrantyDurationType,
	aw.WarrantyConditions as Atom_WarrantyConditions,
	
    disci.DocInvoice_ID as DocInvoice_ID,
	disci.ID as DocInvoice_ShopC_Item_ID,
	api.ID as Atom_Price_Item_ID
	
	from DocInvoice_ShopC_Item disci
	inner join Atom_Price_Item api on disci.Atom_Price_Item_ID = api.ID
    inner join Atom_Taxation atax on api.Atom_Taxation_ID = atax.ID
	inner join Atom_Item ai on api.Atom_Item_ID = ai.ID
	left join Atom_Item_Name ain on ai.Atom_Item_Name_ID = ain.ID
	inner join Atom_Unit au on ai.Atom_Unit_ID = au.ID
	left join Atom_Item_barcode aib on ai.Atom_Item_barcode_ID = aib.ID
	left join Atom_Item_Description aid on ai.Atom_Item_Description_ID = aid.ID
	left join  Atom_Expiry ae on ai.Atom_Expiry_ID = ae.ID
	left join Atom_Warranty aw on ai.Atom_Warranty_ID = aw.ID
	inner join Atom_PriceList apl on api.Atom_PriceList_ID = apl.ID
	inner join Atom_PriceList_Name apln on apl.Atom_PriceList_Name_ID = apln.ID
                                  where disci.ID = " + docInvoice_ShopC_Item_ID.ToString();
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, ref Err))
            {
                if (dt.Rows.Count > 0)
                {

                    data.AtomItem_UniqueName = tf._set_string(dt.Rows[0]["AtomItem_UniqueName"]);
                    data.AtomItem_Name = tf._set_string(dt.Rows[0]["AtomItem_Name"]);
                    data.AtomItem_Description = tf._set_string(dt.Rows[0]["AtomItem_Description"]); 
                    data.AtomUnit_Name = tf._set_string(dt.Rows[0]["AtomUnit_Name"]);
                    data.AtomUnit_Symbol = tf._set_string(dt.Rows[0]["AtomUnit_Symbol"]);
                    data.AtomUnit_DecimalPlaces_v = tf.set_int(dt.Rows[0]["AtomUnit_DecimalPlaces"]);
                    data.AtomUnit_StorageOption_v = tf.set_bool(dt.Rows[0]["AtomUnit_StorageOption"]);
                    data.AtomUnit_Description = tf._set_string(dt.Rows[0]["AtomUnit_Description"]);
                    data.ExtraDiscount_v = tf.set_decimal(dt.Rows[0]["ExtraDiscount"]);
                    data.RetailPricePerUnit_v =  tf.set_decimal(dt.Rows[0]["RetailPricePerUnit"]); 
                    data.AtomItemBarcode = tf._set_string(dt.Rows[0]["AtomItemBarcode"]); 
                    data.Discount_v = tf.set_decimal(dt.Rows[0]["Discount"]); 
                    data.Atom_TaxationName =  tf._set_string(dt.Rows[0]["Atom_TaxationName"]); 
                    data.Atom_TaxationRate_v = tf.set_decimal(dt.Rows[0]["Atom_TaxationRate"]); 
                    data.AtomPriceList_Name = tf._set_string(dt.Rows[0]["AtomPriceList_Name"]); 
                    data.AtomExpiry_ExpectedShelfLifeInDays_v = tf.set_int(dt.Rows[0]["AtomExpiry_ExpectedShelfLifeInDays"]);
                    data.AtomExpiry_SaleBeforeExpiryDateInDays_v = tf.set_int(dt.Rows[0]["AtomExpiry_SaleBeforeExpiryDateInDays"]);
                    data.AtomExpiry_DiscardBeforeExpiryDateInDays_v = tf.set_int(dt.Rows[0]["AtomExpiry_DiscardBeforeExpiryDateInDays"]);
                    data. AtomExpiry_ExpiryDescription = tf._set_string(dt.Rows[0]["AtomExpiry_ExpiryDescription"]); 

                    data.Atom_WarrantyDuration_v = tf.set_int(dt.Rows[0]["Atom_WarrantyDuration"]); 
                    data.Atom_WarrantyDurationType_v = tf.set_int(dt.Rows[0]["Atom_WarrantyDurationType"]); 
                    data.Atom_WarrantyConditions =  tf._set_string(dt.Rows[0]["Atom_WarrantyConditions"]); 

                    data.DocInvoice_ID = tf.set_ID(dt.Rows[0]["DocInvoice_ID"]);
                    data.DocInvoice_ShopC_Item_ID = tf.set_ID(dt.Rows[0]["DocInvoice_ShopC_Item_ID"]);
                    data.Atom_Price_Item_ID = tf.set_ID(dt.Rows[0]["Atom_Price_Item_ID"]);
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

        public static bool UpdateExtraDiscount(ID doc_ShopC_Item_ID, decimal extradiscount, Transaction transaction)
        {
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            string spar_extraDiscount = "@par_extraDiscount";
            SQL_Parameter par_extraDiscount = new SQL_Parameter(spar_extraDiscount, SQL_Parameter.eSQL_Parameter.Decimal, false, extradiscount);
            lpar.Add(par_extraDiscount);


            string sql = @"update DocInvoice_ShopC_Item
                           set ExtraDiscount = " + spar_extraDiscount + @"
                           where ID = " + doc_ShopC_Item_ID.ToString(); ;
            string Err = null;
            if (transaction.ExecuteNonQuerySQL(DBSync.DBSync.Con,sql, lpar, ref Err))
            {
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:TangentaDB:f_DocInvoice_ShopC_Item:UpdateExtraDiscount:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }

        public static bool GetItems(ID currentDoc_ID, ref DataTable dtShopCItems)
        {
        //    string sql = @"select 
        //                           disci.DocInvoice_ID,
        //                           disci.ID as DocInvoice_ShopC_Item_ID,
        //                           ai.UniqueName as Atom_Item_UniqueName,
        //                           disci.dQuantity,
        //                           disci.Stock_ID,
        //                           i.UniqueName as Item_UniqueName,
        //                           atax.Rate as TaxRate,
        //                           disci.ExtraDiscount,
        //                           disci.RetailPriceWithDiscount,
        //                           disci.TaxPrice,
        //                           disci.Atom_Price_Item_ID,
        //                           disci.ExpiryDate,
        //                           api.RetailPricePerUnit as api_RetailPricePerUnit,
        //                           api.Discount as api_Discount,
        //                           api.Atom_Taxation_ID as api_Atom_Taxation_ID,
        //                           api.Atom_Item_ID as api_Atom_Item_ID, 
        //                           api.Atom_PriceList_ID as api_Atom_PriceList_ID,
								//   s.ImportTime as Stock_ImportTime,
								//   s.dQuantity as Stock_dQuantity,
								//   s.ExpiryDate as Stock_ExpiryDate,
								//   s.PurchasePrice_Item_ID as PurchasePrice_Item_ID,
								//   s.Stock_AddressLevel1_ID as Stock_AddressLevel1_ID,
								//   s.Description  as Stock_Description,
        //                           s.ExpiryDate as Stock_ExpiriyDate,
								//   ppi.Item_ID as ppi_Item_ID,
								//   ppi.PurchasePrice_ID as ppi_PurchasePrice_ID,
								//   ppi.StockTake_ID as ppi_StockTake_ID,
        //                          st.Name as StockTakeName,
        //                          st.StockTake_Date,
        //                          disci.Stock_ID as Stock_ID
        //                          from DocInvoice_ShopC_Item disci
        //                          left join Stock s on disci.Stock_ID = s.ID
								//  left join PurchasePrice_Item ppi on ppi.ID = s.PurchasePrice_Item_ID
								//  left join PurchasePrice pp on pp.ID = ppi_PurchasePrice_ID
        //                          left join StockTake st on ppi.StockTake_ID = st.ID
								//  left join Item i on i.ID = ppi.Item_ID
        //                          left join Atom_Price_Item api on disci.Atom_Price_Item_ID = api.ID
        //                          left join Atom_Taxation atax on api.Atom_Taxation_ID = atax.ID
        //                          left join Atom_Item ai on api.Atom_Item_ID = ai.ID
        //                          left join Atom_PriceList apl on api.Atom_PriceList_ID = apl.ID
        //                          where disci.DocInvoice_ID = " + currentDoc_ID.ToString();

            string sql = @"select
                                   disci.DocInvoice_ID,
                                   disci.ID as DocInvoice_ShopC_Item_ID,
                                   ai.UniqueName as Atom_Item_UniqueName,
                                   atax.Rate as TaxRate,
                                   api.RetailPricePerUnit as api_RetailPricePerUnit,
                                   api.Discount as api_Discount,
                                   api.Atom_Taxation_ID as api_Atom_Taxation_ID,
                                   api.Atom_Item_ID as api_Atom_Item_ID, 
                                   api.Atom_PriceList_ID as api_Atom_PriceList_ID
                                  from DocInvoice_ShopC_Item disci
                                  inner join Atom_Price_Item api on disci.Atom_Price_Item_ID = api.ID
                                 inner join Atom_Taxation atax on api.Atom_Taxation_ID = atax.ID
                                 inner join Atom_Item ai on api.Atom_Item_ID = ai.ID
                                 inner join Atom_PriceList apl on api.Atom_PriceList_ID = apl.ID
                                  where disci.DocInvoice_ID = " + currentDoc_ID.ToString();
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
                LogFile.Error.Show("ERROR:TangentaDB:f_DocInvoice_ShopC_Item:GetItems:sql=" + sql + "\r\nErr" + Err);
                return false;
            }
        }

        public static bool Delete(ID doc_ShopC_Item_ID, Transaction transaction)
        {
            string sql = "delete from DocInvoice_ShopC_Item where ID = " + doc_ShopC_Item_ID.ToString();
            string Err = null;
            if (transaction.ExecuteNonQuerySQL(DBSync.DBSync.Con,sql, null,  ref Err))
            {
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:TangentaDB:f_DocInvoice_ShopC_Item:Delete:sql=" + sql + "\r\nErr" + Err);
                return false;
            }
        }

        //public static bool GetItems(ID currentDoc_ID,ID item_ID, ref DataTable dtShopCItems)
        //{
        //    //  string sql = @"select 
        //    //                         disci.DocInvoice_ID,
        //    //                         disci.ID as DocInvoice_ShopC_Item_ID,
        //    //                         ai.UniqueName as Atom_Item_UniqueName,
        //    //                         disci.dQuantity as dQuantity,
        //    //                         disci.Stock_ID,
        //    //                         i.UniqueName as Item_UniqueName,
        //    //                         atax.Rate as TaxRate,
        //    //                         disci.ExtraDiscount as ExtraDiscount,
        //    //                         disci.RetailPriceWithDiscount as RetailPriceWithDiscount,
        //    //                         disci.TaxPrice as TaxPrice,
        //    //                         disci.Atom_Price_Item_ID as Atom_Price_Item_ID,
        //    //                         disci.ExpiryDate as ExpiryDate,
        //    //                         api.RetailPricePerUnit as api_RetailPricePerUnit,
        //    //                         api.Discount as api_Discount,
        //    //                         api.Atom_Taxation_ID as api_Atom_Taxation_ID,
        //    //                         api.Atom_Item_ID as api_Atom_Item_ID, 
        //    //                         api.Atom_PriceList_ID as api_Atom_PriceList_ID,
        //    // s.ImportTime as Stock_ImportTime,
        //    // s.dQuantity as Stock_dQuantity,
        //    // s.ExpiryDate as Stock_ExpiryDate,
        //    // s.PurchasePrice_Item_ID as PurchasePrice_Item_ID,
        //    // s.Stock_AddressLevel1_ID as Stock_AddressLevel1_ID,
        //    // s.Description  as Stock_Description,
        //    //                         s.ExpiryDate as Stock_ExpiriyDate,
        //    // ppi.Item_ID as ppi_Item_ID,
        //    // ppi.PurchasePrice_ID as ppi_PurchasePrice_ID,
        //    // ppi.StockTake_ID as ppi_StockTake_ID,
        //    //                        st.Name as StockTakeName,
        //    //                        st.StockTake_Date,
        //    //                        disci.Stock_ID as Stock_ID
        //    //                        from DocInvoice_ShopC_Item disci
        //    //                        left join Stock s on disci.Stock_ID = s.ID
        //    //                        left join JOURNAL_Stock js on js.Stock_ID = s.ID
        //    //                        left join JOURNAL_Stock_Type jst on jst.ID = js.JOURNAL_Stock_Type_ID and jst.Name = 'New Stock Data'
        //    //left join PurchasePrice_Item ppi on ppi.ID = s.PurchasePrice_Item_ID
        //    //left join PurchasePrice pp on pp.ID = ppi_PurchasePrice_ID
        //    //                        left join StockTake st on ppi.StockTake_ID = st.ID
        //    //left join Item i on i.ID = ppi.Item_ID
        //    //                        left join Atom_Price_Item api on disci.Atom_Price_Item_ID = api.ID
        //    //                        left join Atom_Taxation atax on api.Atom_Taxation_ID = atax.ID
        //    //                        left join Atom_Item ai on api.Atom_Item_ID = ai.ID
        //    //                        left join Atom_PriceList apl on api.Atom_PriceList_ID = apl.ID
        //    //                        where disci.DocInvoice_ID = " + currentDoc_ID.ToString() + " and ppi.Item_ID = "+ item_ID.ToString()
        //    //                        + " order by js.EventTime asc";
        //    string sql = @"select
        //                           disci.ID as DocInvoice_ShopC_Item_ID,
        //                           ai.UniqueName as Atom_Item_UniqueName,
        //                           atax.Rate as TaxRate,
        //                           api.RetailPricePerUnit as api_RetailPricePerUnit,
        //                           api.Discount as api_Discount,
        //                           api.Atom_Taxation_ID as api_Atom_Taxation_ID,
        //                           api.Atom_Item_ID as api_Atom_Item_ID, 
        //                           api.Atom_PriceList_ID as api_Atom_PriceList_ID
        //                          from DocInvoice_ShopC_Item disci
        //                          inner join Atom_Price_Item api on disci.Atom_Price_Item_ID = api.ID
        //                         inner join Atom_Taxation atax on api.Atom_Taxation_ID = atax.ID
        //                         inner join Atom_Item ai on api.Atom_Item_ID = ai.ID
        //                         inner join Atom_PriceList apl on api.Atom_PriceList_ID = apl.ID
        //                            where disci.DocInvoice_ID = " + currentDoc_ID.ToString() + " and ppi.Item_ID = " + item_ID.ToString();
        //    //                        + " order by js.EventTime asc";

        //    if (dtShopCItems == null)
        //    {
        //        dtShopCItems = new DataTable();
        //    }
        //    else
        //    {
        //        dtShopCItems.Dispose();
        //        dtShopCItems = new DataTable();
        //    }
        //    string Err = null;
        //    if (DBSync.DBSync.ReadDataTable(ref dtShopCItems, sql, ref Err))
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        LogFile.Error.Show("ERROR:TangentaDB:f_DocInvoice_ShopC_Item:GetItems:sql=" + sql + "\r\nErr" + Err);
        //        return false;
        //    }
        //}

     

        public static bool Insert(ID docInvoice_ID,
                                  ID atom_Price_Item_ID,
                                  decimal extraDiscount,
                                  ref ID DocInvoice_ShopC_Item_ID,
                                  Transaction transaction)
        {
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();


            string spar_DocInvoice_ID = "@par_DocInvoice_ID";
            SQL_Parameter par_DocInvoice_ID = new SQL_Parameter(spar_DocInvoice_ID, false, docInvoice_ID);
            lpar.Add(par_DocInvoice_ID);

            string spar_atom_Price_Item_ID = "@par_atom_Price_Item_ID";
            SQL_Parameter par_atom_Price_Item_ID = new SQL_Parameter(spar_atom_Price_Item_ID, false, atom_Price_Item_ID);
            lpar.Add(par_atom_Price_Item_ID);

            string spar_extraDiscount = "@par_extraDiscount";
            SQL_Parameter par_extraDiscount = new SQL_Parameter(spar_extraDiscount,SQL_Parameter.eSQL_Parameter.Decimal, false, extraDiscount);
            lpar.Add(par_extraDiscount);
            

            string sql = @"insert into DocInvoice_ShopC_Item
                           (
                            DocInvoice_ID,
                            Atom_Price_Item_ID,
                            ExtraDiscount)
                            values
                            (
                            " + spar_DocInvoice_ID + @",
                            " + spar_atom_Price_Item_ID + @",
                            " + spar_extraDiscount + ")";
            string Err = null;
            if (transaction.ExecuteNonQuerySQLReturnID(DBSync.DBSync.Con,sql, lpar, ref DocInvoice_ShopC_Item_ID, ref Err, "DocInvoice_ShopC_Item"))
            {
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:TangentaDB:f_DocInvoice_ShopC_Item:Insert:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }

        internal static bool Get(ID doc_ID, ID atom_Price_Item_ID, decimal extraDiscount, ref ID doc_ShopC_Item_ID)
        {
            throw new NotImplementedException();
        }
    }
}
