using DBConnectionControl40;
using DBTypes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TangentaDB
{
    public static class f_Price_SimpleItem
    {
        public static bool Get(decimal RetailSimpleItemPrice, 
                               decimal_v Discount_v,
                               ID Taxation_ID,
                               ID SimpleItem_ID,
                               ID PriceList_ID,
                               ref ID Price_SimpleItem_ID)
        {
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            string spar_RetailSimpleItemPrice = "@par_RetailSimpleItemPrice";
            SQL_Parameter par_RetailSimpleItemPrice = new SQL_Parameter(spar_RetailSimpleItemPrice, SQL_Parameter.eSQL_Parameter.Decimal, false, RetailSimpleItemPrice);
            lpar.Add(par_RetailSimpleItemPrice);

            string scond_RetailSimpleItemPrice = " RetailSimpleItemPrice = " + spar_RetailSimpleItemPrice + " ";
            string sval_RetailSimpleItemPrice = " " + spar_RetailSimpleItemPrice + " ";

            string scond_Discount = " Discount is null ";
            string sval_Discount = " null ";
            if (Discount_v != null)
            {
                string spar_Discount = "@par_Discount";
                SQL_Parameter par_Discount = new SQL_Parameter(spar_Discount, SQL_Parameter.eSQL_Parameter.Decimal, false, Discount_v.v);
                lpar.Add(par_Discount);
                scond_Discount = " Discount = " + spar_Discount + " ";
                sval_Discount = " " + spar_Discount + " ";
            }
            string sql = "select ID from Price_SimpleItem where " + scond_RetailSimpleItemPrice +
                                                                    " and " + scond_Discount +
                                                                    " and Taxation_ID = " + Taxation_ID.ToString() +
                                                                    " and SimpleItem_ID = " + SimpleItem_ID.ToString() +
                                                                    " and PriceList_ID = " + PriceList_ID.ToString();
            DataTable dt = new DataTable();
            string Err = null;
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
            {
                if (dt.Rows.Count>0)
                {
                    if (Price_SimpleItem_ID==null)
                    {
                        Price_SimpleItem_ID = new ID();
                    }
                    Price_SimpleItem_ID.Set(dt.Rows[0]["ID"]);
                    return true;
                }
                else
                {
                    sql = @"insert into Price_SimpleItem (RetailSimpleItemPrice,
                                                          Discount,
                                                          Taxation_ID,
                                                          SimpleItem_ID,
                                                          PriceList_ID
                                                          ) values
                                                          (" + sval_RetailSimpleItemPrice +
                                                          "," + sval_Discount +
                                                          "," + Taxation_ID.ToString() +
                                                          "," + SimpleItem_ID.ToString() +
                                                          "," + PriceList_ID.ToString() +
                                                          ")";
                    if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql,lpar,ref Price_SimpleItem_ID, ref Err, "Price_SimpleItem"))
                    {
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:f_Price_SimpleItem:Get:sql=" + sql + "\r\nErr=" + Err);
                        return false;
                    }
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:f_Price_SimpleItem:Get:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }

        public static bool Get(decimal RetailSimpleItemPrice,
                           decimal_v Discount_v,
                           string TaxationName, 
                           decimal TaxationRate,
                           string SimpleItem_Name, 
                           string Abbreviation, 
                           bool bToOffer, 
                           Image SimpleItem_Image, 
                           int_v Code_v, 
                           string SimpleItem_ParentGroup1, 
                           string SimpleItem_ParentGroup2, 
                           string SimpleItem_ParentGroup3,
                           string sPriceListName,
                           bool valid,
                           string Currency_Abbreviation,
                           string Currency_Name, 
                           string Currency_Symbol, 
                           int CurrencyCode, 
                           int Currency_DecimalPlaces, 
                           DateTime_v ValidFrom_v, 
                           DateTime_v ValidTo_v, 
                           DateTime_v CreationDate_v, 
                           string Description,
                           ref ID Currency_ID,
                           ref ID SimpleItem_ID,
                           ref ID Taxation_ID,
                           ref ID PriceList_ID,
                           ref ID Price_SimpleItem_ID)
        {
            if (f_Taxation.Get(TaxationName, TaxationRate,ref Taxation_ID))
            {
                if (f_Currency.Get(Currency_Abbreviation, Currency_Name, Currency_Symbol, CurrencyCode, Currency_DecimalPlaces, ref Currency_ID))
                {
                    if (f_SimpleItem.Get(SimpleItem_Name, Abbreviation, bToOffer, SimpleItem_Image, Code_v, SimpleItem_ParentGroup1, SimpleItem_ParentGroup2, SimpleItem_ParentGroup3, ref SimpleItem_ID))
                    {
                        if (f_PriceList.Get(sPriceListName, valid, Currency_ID, ValidFrom_v, ValidTo_v, CreationDate_v, Description, ref PriceList_ID))
                        {
                            if (Get(RetailSimpleItemPrice, Discount_v, Taxation_ID, SimpleItem_ID, PriceList_ID, ref Price_SimpleItem_ID))
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }

        internal static bool Get(ID PriceList_ID, ID SimpleItem_ID, ref ID price_SimpleItem_ID,ref decimal_v RetailSimpleItemPrice_v, ref decimal_v discount_v, ref ID taxation_ID, ref string_v taxation_Name_v, ref decimal_v taxation_Rate_v)
        {
            string Err = null;
            price_SimpleItem_ID = null;
            RetailSimpleItemPrice_v = null;
            discount_v = null;
            taxation_ID = null;
            taxation_Name_v = null;
            taxation_Rate_v = null;

            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            string spar_PriceList_ID = "@par_PriceList_ID";
            SQL_Parameter par_PriceList_ID = new SQL_Parameter(spar_PriceList_ID,  false, PriceList_ID);
            lpar.Add(par_PriceList_ID);
            string spar_SimpleItem_ID = "@par_SimpleItem_ID";
            SQL_Parameter par_SimpleItem_ID = new SQL_Parameter(spar_SimpleItem_ID, false, SimpleItem_ID);
            lpar.Add(par_SimpleItem_ID);
            DataTable dt = new DataTable();
            string sql = "select ID,RetailSimpleItemPrice,Discount,Taxation_ID from Price_SimpleItem where SimpleItem_ID=" + spar_SimpleItem_ID + " and PriceList_ID = " + spar_PriceList_ID;
            if (DBSync.DBSync.ReadDataTable(ref dt, sql,lpar, ref Err))
            {
                if (dt.Rows.Count>0)
                {
                    if (price_SimpleItem_ID==null)
                    {
                        price_SimpleItem_ID = new ID();
                    }
                    price_SimpleItem_ID.Set(dt.Rows[0]["ID"]);
                    RetailSimpleItemPrice_v = tf.set_decimal(dt.Rows[0]["RetailSimpleItemPrice"]);
                    discount_v = tf.set_decimal(dt.Rows[0]["Discount"]);
                    if (taxation_ID==null)
                    {
                        taxation_ID = new ID();
                    }
                    taxation_ID.Set(dt.Rows[0]["Taxation_ID"]);
                    if (ID.Validate(taxation_ID))
                    {
                        return f_Taxation.Get(taxation_ID, ref taxation_Name_v, ref taxation_Rate_v);
                    }
                }
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:f_Price_SimpleItem:Get:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }
    }
}
