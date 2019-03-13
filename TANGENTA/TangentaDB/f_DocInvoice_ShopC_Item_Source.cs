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
                                   discis.DocInvoice_ShopC_Item_ID as Doc_ShopC_Item_ID,
                                   discis.ID as Doc_ShopC_Item_Source_ID,
                                   discis.Stock_ID as Stock_ID,
                                   discis.dQuantity as dQuantity,
                                   discis.RetailPriceWithDiscount as RetailPriceWithDiscount,
                                   discis.TaxPrice as TaxPrice,
                                  s.ExpiryDate as ExpiryDate,
                                  i.UniqueName as Item_UniqueName,
                                  st.Name as StockTakeName,
                                  st.StockTake_Date as StockTake_Date
                                  from DocInvoice_ShopC_Item_Source discis
                                  left join Stock s on discis.Stock_ID = s.ID
                                  left join PurchasePrice_Item ppi on s.PurchasePrice_Item_ID = ppi.ID
                                  left join StockTake st on ppi.StockTake_ID = st.ID
                                  left join Item i on ppi.Item_ID = i.ID
                                  where discis.DocInvoice_ShopC_Item_ID = " + docInvoice_ShopC_Item_ID.ToString();
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, ref Err))
            {
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:TangentaDB:f_DocInvoice_ShopC_Item_Source:Get:sql=" + sql + "\r\nErr" + Err);
                return false;
            }

        }

        public static bool Get(ID docInvoice_ShopC_Item_Source_ID, ref Doc_ShopC_Item_Source xdsciS)
        {
            string Err = null;
            DataTable dt = new DataTable();
            string sql = @" select
									i.UniqueName as Item_UniqueName,
									discis.dQuantity as dQuantity,
									discis.SourceDiscount as SourceDiscount,
									discis.RetailPriceWithDiscount as RetailPriceWithDiscount,
									discis.TaxPrice as TaxPrice,
									s.ImportTime as Stock_ImportTime,
									s.dQuantity as StockQuantity,
									s.ExpiryDate as ExpiryDate,
									s.Description as StockDescription,
									pp.PurchasePricePerUnit as PurchasePricePerUnit,
									pp.PurchasePriceDate as PurchasePriceDate,
									pp.Discount as PurchasePrice_Discount,
									pp.PriceWithoutVAT as PurchasePriceWithoutVAT,
									pp.VATCanNotBeDeducted as PurchasePriceVATCanNotBeDeducted,

									cur.Name as Currency_Name,
									cur.Symbol as Currency_Symbold,
									cur.Abbreviation as Currency_Abbreviation,
									cur.CurrencyCode as Currency_Code,
									cur.DecimalPlaces as Currency_DecimalPlaces,
									tax.Name as Taxation_Name,
									tax.Rate as Taxation_Rate,
									st.Name as StockTakeName,
									st.StockTake_Date as StockTake_Date,
                                    st.StockTakePriceTotal as StockTakePriceTotal,
									st.StockTakePriceTotalWithVAT as StockTakePriceTotalWithVAT,
									st.Description as StockTakeDescription,
									st.Draft as StockTakeDraft,
								    r.ReferenceNote as ReferenceNote,
									r.ReferenceDate as ReferenceDate,
									ri.Image_Data as ReferenceImage_Data,
									ri.Image_Hash as ReferenceImage_Hash,
									st.ID as StockTake_ID,
									discis.Stock_ID as Stock_ID,
									discis.DocInvoice_ShopC_Item_ID as Doc_ShopC_Item_ID,
									discis.ID as Doc_ShopC_Item_Source_ID,
									pp.ID as PurchasePrice_ID,
									r.ID as Reference_ID
								   from DocInvoice_ShopC_Item_Source discis
                                  inner join Stock s on discis.Stock_ID = s.ID
								  left join Stock_AddressLevel1 sa1 on s.Stock_AddressLevel1_ID = sa1.ID
								  left join Stock_AddressLevel2 sa2 on sa1.Stock_AddressLevel2_ID = sa2.ID
								  left join Stock_AddressLevel3 sa3 on sa2.Stock_AddressLevel3_ID = sa3.ID
                                  inner join PurchasePrice_Item ppi on s.PurchasePrice_Item_ID = ppi.ID
                                  inner join Item i on ppi.Item_ID = i.ID
								  inner join PurchasePrice pp on ppi.PurchasePrice_ID = pp.ID
								  inner join Currency cur on pp.Currency_ID = cur.ID
								  inner join Taxation tax on pp.Taxation_ID = tax.ID
                                  inner join StockTake st on ppi.StockTake_ID = st.ID
								  left join Reference r on st.Reference_ID = r.ID
								  left join Reference_Image ri on r.Reference_Image_ID = ri.ID
								  inner join Supplier su on st.Supplier_ID = su.ID
								  inner join Contact c on su.Contact_ID = c.ID
								  left join OrganisationData orgd on c.OrganisationData_ID = orgd.ID
								  left join Organisation org on orgd.Organisation_ID = org.ID
								  left join cOrgTYPE corgt on orgd.cOrgTYPE_ID = corgt.ID
								  left join cAddress_Org caorg on orgd.cAddress_Org_ID = caorg.ID
								  left join cPhoneNumber_Org cpnorg on orgd.cPhoneNumber_Org_ID = cpnorg.ID
								  left join cFaxNumber_Org cfnorg on  orgd.cFaxNumber_Org_ID = cfnorg.ID
								  left join cEmail_Org ceorg on orgd.cEmail_Org_ID  = ceorg.ID
								  left join cHomePage_Org chporg on orgd.cHomePage_Org_ID = chporg.ID
								  left join Logo logorg on orgd.Logo_ID = logorg.ID
								  left join Person per on c.Person_ID = per.ID
								  left join cFirstName cfnper  on per.cFirstName_ID = cfnper.ID

                                  where discis.ID = " + docInvoice_ShopC_Item_Source_ID.ToString();
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    if (xdsciS==null)
                    {
                        xdsciS = new Doc_ShopC_Item_Source();
                    }
                    xdsciS.Stock_ID = DBTypes.tf.set_ID(dt.Rows[0]["Stock_ID"]);
                    xdsciS.dQuantity = DBTypes.tf._set_decimal(dt.Rows[0]["dQuantity"]);
                    xdsciS.RetailPriceWithDiscount = DBTypes.tf._set_decimal(dt.Rows[0]["RetailPriceWithDiscount"]);
                    xdsciS.TaxPrice = DBTypes.tf._set_decimal(dt.Rows[0]["TaxPrice"]);
                    xdsciS.ExpiryDate_v = DBTypes.tf.set_DateTime(dt.Rows[0]["ExpiryDate"]);
                    xdsciS.Item_UniqueName_v = DBTypes.tf.set_string(dt.Rows[0]["Item_UniqueName"]);
                    xdsciS.StockTakeName_v = DBTypes.tf.set_string(dt.Rows[0]["StockTakeName"]);
                    xdsciS.StockTakeDate_v = DBTypes.tf.set_DateTime(dt.Rows[0]["StockTake_Date"]);

                    xdsciS.Doc_ShopC_Item_ID = DBTypes.tf.set_ID(dt.Rows[0]["Doc_ShopC_Item_ID"]);
                    xdsciS.Doc_ShopC_Item_Source_ID = DBTypes.tf.set_ID(dt.Rows[0]["Doc_ShopC_Item_Source_ID"]);
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

        public static bool Delete(ID doc_ShopC_Item_Source_ID, Transaction transaction)
        {
            string sql = "delete from DocInvoice_ShopC_Item_Source where ID = " + doc_ShopC_Item_Source_ID.ToString();
            string Err = null;
            if (transaction.ExecuteNonQuerySQL(DBSync.DBSync.Con,sql, null, ref Err))
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

        public static bool UpdateQuantity(ID doc_ShopC_Item_Source_ID, decimal dquantity_new, Transaction transaction)
        {
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();

            string spar_dQuantity = "@par_dQuantity";
            SQL_Parameter par_dQuantity = new SQL_Parameter(spar_dQuantity, SQL_Parameter.eSQL_Parameter.Decimal, false, dquantity_new);
            lpar.Add(par_dQuantity);

            string sql = "update DocInvoice_ShopC_Item_Source set dQuantity = " + spar_dQuantity
                            + " where ID = " + doc_ShopC_Item_Source_ID.ToString();
            string Err = null;
            if (transaction.ExecuteNonQuerySQL(DBSync.DBSync.Con,sql, lpar,  ref Err))
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
                                  ref ID DocInvoice_ShopC_Item_Source_ID,
                                  Transaction transaction)
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
                            SourceDiscount,
                            RetailPriceWithDiscount,
                            TaxPrice,
                            ExpiryDate,
                            Stock_ID)
                            values
                            (
                            " + spar_Doc_ShopC_Item_ID + @",
                            " + spar_dQuantity + @",
                            0,
                            " + spar_retailPriceWithDiscount + @",
                            " + spar_taxPrice + @",
                            " + sval_expiryDate + @",
                            " + sval_stock_ID + @")";
            string Err = null;
            if (transaction.ExecuteNonQuerySQLReturnID(DBSync.DBSync.Con,sql, lpar, ref DocInvoice_ShopC_Item_Source_ID, ref Err, "DocInvoice_ShopC_Item_Source"))
            {
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:TangentaDB:f_DocInvoice_ShopC_Item_Source:Insert:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }

       
        internal static bool Update(ID doc_ShopC_Item_Source_ID, decimal dnewQuantity, decimal retailPriceWithDiscount, decimal taxPrice, Transaction transaction)
        {
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();

            string spar_dQuantity = "@par_dQuantity";
            SQL_Parameter par_dQuantity = new SQL_Parameter(spar_dQuantity, SQL_Parameter.eSQL_Parameter.Decimal, false, dnewQuantity);
            lpar.Add(par_dQuantity);


            string spar_retailPriceWithDiscount = "@par_retailPriceWithDiscount";
            SQL_Parameter par_retailPriceWithDiscount = new SQL_Parameter(spar_retailPriceWithDiscount, SQL_Parameter.eSQL_Parameter.Decimal, false, retailPriceWithDiscount);
            lpar.Add(par_retailPriceWithDiscount);

            string spar_taxPrice = "@par_taxPrice";
            SQL_Parameter par_taxPrice = new SQL_Parameter(spar_taxPrice, SQL_Parameter.eSQL_Parameter.Decimal, false, taxPrice);
            lpar.Add(par_taxPrice);


            string sql = @"update DocInvoice_ShopC_Item_Source set
                           
                            dQuantity = " + spar_dQuantity + @",
                            RetailPriceWithDiscount =" + spar_retailPriceWithDiscount + @",
                            TaxPrice = " + spar_taxPrice + @" 
                            where ID = " + doc_ShopC_Item_Source_ID.ToString();
            string Err = null;
            if (transaction.ExecuteNonQuerySQL(DBSync.DBSync.Con,sql, lpar,  ref Err))
            {
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:TangentaDB:f_DocInvoice_ShopC_Item_Source:Update:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }
    }
}
