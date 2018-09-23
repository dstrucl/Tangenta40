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
    public static class f_Price_Item
    {
        public static bool Get(decimal RetailPricePerUnit,
                       decimal_v Discount_v,
                       ID Taxation_ID,
                       ID Item_ID,
                       ID PriceList_ID,
                       ref ID Price_Item_ID)
        {
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            string spar_RetailPricePerUnit = "@par_RetailPricePerUnit";
            SQL_Parameter par_RetailPricePerUnit = new SQL_Parameter(spar_RetailPricePerUnit, SQL_Parameter.eSQL_Parameter.Decimal, false, RetailPricePerUnit);
            lpar.Add(par_RetailPricePerUnit);

            string scond_RetailPricePerUnit = " RetailPricePerUnit = " + spar_RetailPricePerUnit + " ";
            string sval_RetailPricePerUnit = " " + spar_RetailPricePerUnit + " ";

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
            string sql = "select ID from Price_Item where " + scond_RetailPricePerUnit +
                                                                    " and " + scond_Discount +
                                                                    " and Taxation_ID = " + Taxation_ID.ToString() +
                                                                    " and Item_ID = " + Item_ID.ToString() +
                                                                    " and PriceList_ID = " + PriceList_ID.ToString();
            DataTable dt = new DataTable();
            string Err = null;
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    if (Price_Item_ID==null)
                    {
                        Price_Item_ID = new ID();
                    }
                    Price_Item_ID.Set(dt.Rows[0]["ID"]);
                    return true;
                }
                else
                {
                    sql = @"insert into Price_Item (RetailPricePerUnit,
                                                          Discount,
                                                          Taxation_ID,
                                                          Item_ID,
                                                          PriceList_ID
                                                          ) values
                                                          (" + sval_RetailPricePerUnit +
                                                          "," + sval_Discount +
                                                          "," + Taxation_ID.ToString() +
                                                          "," + Item_ID.ToString() +
                                                          "," + PriceList_ID.ToString() +
                                                          ")";
                    if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar, ref Price_Item_ID, ref Err, "Price_Item"))
                    {
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:f_Price_Item:Get:sql=" + sql + "\r\nErr=" + Err);
                        return false;
                    }
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:f_Price_Item:Get:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }

        public static bool Get(decimal RetailPricePerUnit,
                           decimal_v Discount_v,
                           string TaxationName,
                           decimal TaxationRate,
                           string Item_Name,
                           string UniqueName,
                           bool bToOffer,
                           Image Item_Image,
                           int_v Code_v,
                           string Unit_Name,
                           string Unit_Symbol,
                           int Unit_DecimalPlaces,
                           bool Unit_StorageOption,
                           string Unit_Description, 
                           string barcode,
                           string Item_Description,
                           f_Expiry.Expiry_v Expiry_v,
                           f_Warranty.Warranty_v Warranty_v,
                           string Item_ParentGroup1,
                           string Item_ParentGroup2,
                           string Item_ParentGroup3,
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
                           string PriceList_Description,
                           ref ID Unit_ID,
                           ref ID Currency_ID,
                           ref ID Item_ID,
                           ref ID Taxation_ID,
                           ref ID PriceList_ID,
                           ref ID Price_Item_ID)
        {
            if (f_Taxation.Get(TaxationName, TaxationRate, ref Taxation_ID))
            {
                if (f_Currency.Get(Currency_Abbreviation, Currency_Name, Currency_Symbol, CurrencyCode, Currency_DecimalPlaces, ref Currency_ID))
                {
                    if (f_Item.Get(Item_Name, UniqueName, bToOffer, Item_Image, Code_v, Unit_Name,Unit_Symbol,Unit_DecimalPlaces,Unit_StorageOption,Unit_Description,barcode, Item_Description, Expiry_v, Warranty_v, Item_ParentGroup1, Item_ParentGroup2, Item_ParentGroup3,ref Unit_ID, ref Item_ID))
                    {
                        if (f_PriceList.Get(sPriceListName, valid, Currency_ID, ValidFrom_v, ValidTo_v, CreationDate_v, PriceList_Description, ref PriceList_ID))
                        {
                            if (Get(RetailPricePerUnit, Discount_v, Taxation_ID, Item_ID, PriceList_ID, ref Price_Item_ID))
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }

        public static bool Get(
                      ID Item_ID,
                      ID PriceList_ID,
                      ref decimal_v retailPricePerUnit_v,
                      ref decimal_v discount_v,
                      ref string_v taxName_v,
                      ref decimal_v taxRate_v,
                      ref string_v priceList_Name_v,
                      ref ID price_Item_ID)
        {
            string sql = @"select  pi.ID as Price_Item_ID,
                            pi.RetailPricePerUnit as RetailPricePerUnit,
		                    pi.Discount as Discount,
		                    tax.Name as TaxName,
		                    tax.Rate as TaxRate,
		                    pl_n.Name as PriceList_Name
                            from Price_Item pi
                            inner join Taxation tax on tax.ID = pi.Taxation_ID
                            inner join PriceList pl on pl.ID = pi.PriceList_ID
                            inner join PriceList_Name pl_n on pl_n.ID = pl.PriceList_Name_ID
                            where pi.Item_ID = " + Item_ID.ToString() + " and pi.PriceList_ID = " + PriceList_ID.ToString();
            DataTable dt = new DataTable();
            string Err = null;
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    retailPricePerUnit_v = tf.set_decimal(dt.Rows[0]["RetailPricePerUnit"]);
                    discount_v = tf.set_decimal(dt.Rows[0]["Discount"]);
                    taxName_v = tf.set_string(dt.Rows[0]["TaxName"]);
                    taxRate_v = tf.set_decimal(dt.Rows[0]["TaxRate"]);
                    priceList_Name_v = tf.set_string(dt.Rows[0]["PriceList_Name"]);
                    price_Item_ID = tf.set_ID(dt.Rows[0]["Price_Item_ID"]);
                }
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:f_Price_Item:Get:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }
    }
}
