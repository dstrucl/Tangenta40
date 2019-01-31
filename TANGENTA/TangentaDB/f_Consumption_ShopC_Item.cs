﻿using DBConnectionControl40;
using DBTypes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace TangentaDB
{
    public static class f_Consumption_ShopC_Item
    {
        public class fData
        {
            public decimal QuantityTakenFromStock = -1;
            public DateTime ExpiryDate = DateTime.MinValue;
            public string Item_UniqueName = null;
            public string StockTakeName = null;
            public DateTime StockTakeDate = DateTime.MinValue;
        }

        public static bool Get(ID consumption_ShopC_Item_ID, ref fData data)
        {
            string Err = null;
            DataTable dt = new DataTable();
            string sql = @"select cscis.dQuantity as QuantityTakenFromStock,
                                  s.ExpiryDate,
                                  i.UniqueName,
                                  st.Name as StockTakeName,
                                  st.StockTake_Date
                                  from Consumption_ShopC_Item csci
								  inner join  Consumption_ShopC_Item_Source cscis on cscis.Consumption_ShopC_Item_ID = csci.ID
                                  inner join Stock s on cscis.Stock_ID = s.ID
                                  inner join PurchasePrice_Item ppi on s.PurchasePrice_Item_ID = ppi.ID
                                  inner join StockTake st on ppi.StockTake_ID = st.ID
                                  inner join Item i on ppi.Item_ID = i.ID
                                  where csci.ID = " + consumption_ShopC_Item_ID.ToString();
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
                    LogFile.Error.Show("ERROR:TangentaDB:f_Consumption_ShopC_Item:Get:sql=" + sql + "\r\nNo Consumption_ShopC_Item data for ID = " + consumption_ShopC_Item_ID.ToString());
                    return false;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:TangentaDB:f_Consumption_ShopC_Item:Get:sql=" + sql + "\r\nErr" + Err);
                return false;
            }

        }

        //public static bool UpdateExtraDiscount(ID doc_ShopC_Item_ID, decimal extradiscount, Transaction transaction)
        //{
        //    List<SQL_Parameter> lpar = new List<SQL_Parameter>();
        //    string spar_extraDiscount = "@par_extraDiscount";
        //    SQL_Parameter par_extraDiscount = new SQL_Parameter(spar_extraDiscount, SQL_Parameter.eSQL_Parameter.Decimal, false, extradiscount);
        //    lpar.Add(par_extraDiscount);


        //    string sql = @"update Consumption_ShopC_Item
        //                   set ExtraDiscount = " + spar_extraDiscount + @"
        //                   where ID = " + doc_ShopC_Item_ID.ToString(); ;
        //    string Err = null;
        //    if (transaction.ExecuteNonQuerySQL(DBSync.DBSync.Con,sql, lpar, ref Err))
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        LogFile.Error.Show("ERROR:TangentaDB:f_Consumption_ShopC_Item:UpdateExtraDiscount:sql=" + sql + "\r\nErr=" + Err);
        //        return false;
        //    }
        //}

        //public static bool GetItems(ID currentDoc_ID, ref DataTable dtShopCItems)
        //{
        ////    string sql = @"select 
        ////                           disci.Consumption_ID,
        ////                           disci.ID as Consumption_ShopC_Item_ID,
        ////                           ai.UniqueName as Atom_Item_UniqueName,
        ////                           disci.dQuantity,
        ////                           disci.Stock_ID,
        ////                           i.UniqueName as Item_UniqueName,
        ////                           atax.Rate as TaxRate,
        ////                           disci.ExtraDiscount,
        ////                           disci.RetailPriceWithDiscount,
        ////                           disci.TaxPrice,
        ////                           disci.Atom_Price_Item_ID,
        ////                           disci.ExpiryDate,
        ////                           api.RetailPricePerUnit as api_RetailPricePerUnit,
        ////                           api.Discount as api_Discount,
        ////                           api.Atom_Taxation_ID as api_Atom_Taxation_ID,
        ////                           api.Atom_Item_ID as api_Atom_Item_ID, 
        ////                           api.Atom_PriceList_ID as api_Atom_PriceList_ID,
								////   s.ImportTime as Stock_ImportTime,
								////   s.dQuantity as Stock_dQuantity,
								////   s.ExpiryDate as Stock_ExpiryDate,
								////   s.PurchasePrice_Item_ID as PurchasePrice_Item_ID,
								////   s.Stock_AddressLevel1_ID as Stock_AddressLevel1_ID,
								////   s.Description  as Stock_Description,
        ////                           s.ExpiryDate as Stock_ExpiriyDate,
								////   ppi.Item_ID as ppi_Item_ID,
								////   ppi.PurchasePrice_ID as ppi_PurchasePrice_ID,
								////   ppi.StockTake_ID as ppi_StockTake_ID,
        ////                          st.Name as StockTakeName,
        ////                          st.StockTake_Date,
        ////                          disci.Stock_ID as Stock_ID
        ////                          from Consumption_ShopC_Item disci
        ////                          left join Stock s on disci.Stock_ID = s.ID
								////  left join PurchasePrice_Item ppi on ppi.ID = s.PurchasePrice_Item_ID
								////  left join PurchasePrice pp on pp.ID = ppi_PurchasePrice_ID
        ////                          left join StockTake st on ppi.StockTake_ID = st.ID
								////  left join Item i on i.ID = ppi.Item_ID
        ////                          left join Atom_Price_Item api on disci.Atom_Price_Item_ID = api.ID
        ////                          left join Atom_Taxation atax on api.Atom_Taxation_ID = atax.ID
        ////                          left join Atom_Item ai on api.Atom_Item_ID = ai.ID
        ////                          left join Atom_PriceList apl on api.Atom_PriceList_ID = apl.ID
        ////                          where disci.Consumption_ID = " + currentDoc_ID.ToString();

        //    string sql = @"select
        //                           disci.Consumption_ID,
        //                           disci.ID as Consumption_ShopC_Item_ID,
        //                           ai.UniqueName as Atom_Item_UniqueName,
        //                           atax.Rate as TaxRate,
        //                           api.RetailPricePerUnit as api_RetailPricePerUnit,
        //                           api.Discount as api_Discount,
        //                           api.Atom_Taxation_ID as api_Atom_Taxation_ID,
        //                           api.Atom_Item_ID as api_Atom_Item_ID, 
        //                           api.Atom_PriceList_ID as api_Atom_PriceList_ID
        //                          from Consumption_ShopC_Item disci
        //                          inner join Atom_Price_Item api on disci.Atom_Price_Item_ID = api.ID
        //                         inner join Atom_Taxation atax on api.Atom_Taxation_ID = atax.ID
        //                         inner join Atom_Item ai on api.Atom_Item_ID = ai.ID
        //                         inner join Atom_PriceList apl on api.Atom_PriceList_ID = apl.ID
        //                          where disci.Consumption_ID = " + currentDoc_ID.ToString();
        //    if (dtShopCItems == null)
        //    {
        //        dtShopCItems = new DataTable();
        //    }
        //    else
        //    {
        //        dtShopCItems.Clear();
        //        dtShopCItems.Columns.Clear();
        //    }
        //    string Err = null;
        //    if (DBSync.DBSync.ReadDataTable(ref dtShopCItems, sql, ref Err))
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        LogFile.Error.Show("ERROR:TangentaDB:f_Consumption_ShopC_Item:GetItems:sql=" + sql + "\r\nErr" + Err);
        //        return false;
        //    }
        //}

        public static bool Delete(ID cons_ShopC_Item_ID, Transaction transaction)
        {
            string sql = "delete from Consumption_ShopC_Item where ID = " + cons_ShopC_Item_ID.ToString();
            string Err = null;
            if (transaction.ExecuteNonQuerySQL(DBSync.DBSync.Con,sql, null,  ref Err))
            {
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:TangentaDB:f_Consumption_ShopC_Item:Delete:sql=" + sql + "\r\nErr" + Err);
                return false;
            }
        }

      
     

        public static bool Insert(ID cons_ID,
                                  ID purchasePrice_Item_ID,
                                  ref ID Consumption_ShopC_Item_ID,
                                  Transaction transaction)
        {
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();


            string spar_Consumption_ID = "@par_Consumption_ID";
            SQL_Parameter par_Consumption_ID = new SQL_Parameter(spar_Consumption_ID, false, cons_ID);
            lpar.Add(par_Consumption_ID);

            string spar_PurchasePrice_Item_ID = "@par_PruchasePrice_Item_ID";
            SQL_Parameter par_PurchasePrice_Item_ID = new SQL_Parameter(spar_PurchasePrice_Item_ID, false, purchasePrice_Item_ID);
            lpar.Add(par_PurchasePrice_Item_ID);

          
            

            string sql = @"insert into Consumption_ShopC_Item
                           (
                            Consumption_ID,
                            PurchasePrice_Item_ID)
                            values
                            (
                            " + spar_Consumption_ID + @",
                            " + spar_PurchasePrice_Item_ID + ")";
            string Err = null;
            if (transaction.ExecuteNonQuerySQLReturnID(DBSync.DBSync.Con,sql, lpar, ref Consumption_ShopC_Item_ID, ref Err, "Consumption_ShopC_Item"))
            {
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:TangentaDB:f_Consumption_ShopC_Item:Insert:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }

        
    }
}
