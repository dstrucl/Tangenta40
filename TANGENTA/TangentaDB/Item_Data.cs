#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion
using DBConnectionControl40;
using DBTypes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TangentaDB
{
    public class Item_Data
    {
        public string[] m_s_name_Group = null;
        public decimal nmUpDn_FactoryQuantity_Value = 0;
        public decimal nmUpDn_StockQuantity_Value = 0;
        public decimal ExtraDiscount = 0;

        public ID Price_Item_ID = null;
        public decimal_v Price_Item_Discount_v = null;
        public ID PriceList_ID = null;
        public string_v PriceList_Name_v = null;
        public string_v Currency_Name_v = null;
        public string_v Currency_Abbreviation_v = null;
        public string_v Currency_Symbol_v = null;
        public int_v Currency_DecimalPlaces = null;
        public ID Stock_ID = null;
        public DateTime_v Stock_ExpiryDate_v = null;
        public decimal_v Stock_dQuantity_v = null;
        public decimal_v RetailPricePerUnit_v = null;
        public DateTime_v Stock_ImportTime_v = null;
        public bool_v StockTake_Draft_v = null;
        public ID Item_ID = null;
        public string_v Item_UniqueName_v = null;
        public string_v Item_Name_v = null;
        public string_v Item_barcode_v = null;
        public ID Item_Image_ID = null;
        public byte_array_v Item_Image_Image_Data_v = null;
        public string_v Item_Image_Image_Hash_v = null;
        public string_v Item_Description_v = null;
        public string_v Unit_Name_v = null;
        public string_v Unit_Symbol_v = null;
        public int_v Unit_DecimalPlaces_v = null;
        public bool_v Unit_StorageOption_v = null;
        public string_v Unit_Description_v = null;
        public int_v Expiry_ExpectedShelfLifeInDays_v = null;
        public int_v Expiry_SaleBeforeExpiryDateInDays_v = null;
        public int_v Expiry_DiscardBeforeExpiryDateInDays_v = null;
        public string_v Expiry_Description_v = null;
        public ID Item_Expiry_ID = null;
        public bool_v Item_ToOffer_v = null;

     

        public ID Item_Warranty_ID = null;
        public string_v Warranty_WarrantyConditions_v = null;
        public int_v Warranty_WarrantyDuration_v = null;
        public short_v Warranty_WarrantyDurationType_v = null;
        public ID Taxation_ID = null;
        public string_v Taxation_Name_v = null;
        public decimal_v Taxation_Rate_v = null;
        public decimal_v PurchasePricePerUnit_v = null;
        public string_v PurchaseOrganisation_Name_v = null;
        public PostAddress_v PurchaseOrganisation_Address_v = new PostAddress_v();
        public DateTime_v ExpiryDate_v;
        public string s1_name = null;
        public string s2_name = null;
        public string s3_name = null;

        public List<Stock_Data> Stock_Data_List = new List<Stock_Data>();

        public decimal Taxation_Rate
        {
            get
            {
                if (Taxation_Rate_v != null)
                {
                    return Taxation_Rate_v.v;
                }
                return 0;
            }
        }

        public string Item_UniqueName
        {
            get
            {
                if (Item_UniqueName_v!=null)
                {
                    return Item_UniqueName_v.v;
                }
                return null;
            }
        }
        public Item_Data()
        {
        }

        public void Set_Price_Item_Stock(DataRow xdr)
        {
            Price_Item_ID = tf.set_ID(xdr["Price_Item_ID"]);
            Price_Item_Discount_v = tf.set_decimal(xdr["Price_Item_Discount"]);
            PriceList_ID = tf.set_ID(xdr["PriceList_ID"]);
            PriceList_Name_v = tf.set_string(xdr["PriceList_Name"]);
            Currency_Name_v = tf.set_string(xdr["Currency_Name"]); ;
            Currency_Abbreviation_v = tf.set_string(xdr["Currency_Abbreviation"]);
            Currency_Symbol_v = tf.set_string(xdr["Currency_Symbol"]);
            Currency_DecimalPlaces = tf.set_int(xdr["Currency_DecimalPlaces"]);
            Stock_ID = tf.set_ID(xdr["Stock_ID"]);
            Stock_ExpiryDate_v = tf.set_DateTime(xdr["Stock_ExpiryDate"]);
            Stock_dQuantity_v = tf.set_decimal(xdr["Stock_dQuantity"]);
            RetailPricePerUnit_v = tf.set_decimal(xdr["RetailPricePerUnit"]);
            Price_Item_Discount_v = tf.set_decimal(xdr["Price_Item_Discount"]);
            Stock_ImportTime_v = tf.set_DateTime(xdr["Stock_ImportTime"]);
            StockTake_Draft_v = tf.set_bool(xdr["StockTake_Draft"]);
            Item_ID = tf.set_ID(xdr["Item_ID"]);
            Item_UniqueName_v = tf.set_string(xdr["Item_UniqueName"]);
            Item_Name_v = tf.set_string(xdr["Item_Name"]);
            Item_barcode_v = tf.set_string(xdr["Item_barcode"]);
            Item_Image_ID = tf.set_ID(xdr["Item_Image_ID"]);
            Item_Image_Image_Data_v = tf.set_byte_array(xdr["Item_Image_Image_Data"]);
            Item_Image_Image_Hash_v = tf.set_string(xdr["Item_Image_Image_Hash"]);
            Item_Description_v = tf.set_string(xdr["Item_Description"]);
            Unit_Name_v = tf.set_string(xdr["Unit_Name"]);
            Unit_Symbol_v = tf.set_string(xdr["Unit_Symbol"]);
            Unit_DecimalPlaces_v = tf.set_int(xdr["Unit_DecimalPlaces"]);
            Unit_StorageOption_v = tf.set_bool(xdr["Unit_StorageOption"]);
            Unit_Description_v = tf.set_string(xdr["Unit_Description"]);
            Unit_Name_v = tf.set_string(xdr["Unit_Name"]);
            Expiry_ExpectedShelfLifeInDays_v = tf.set_int(xdr["Expiry_ExpectedShelfLifeInDays"]);
            Expiry_SaleBeforeExpiryDateInDays_v = tf.set_int(xdr["Expiry_SaleBeforeExpiryDateInDays"]);
            Expiry_DiscardBeforeExpiryDateInDays_v = tf.set_int(xdr["Expiry_DiscardBeforeExpiryDateInDays"]);
            Expiry_Description_v = tf.set_string(xdr["Expiry_ExpiryDescription"]);
            Item_Expiry_ID = tf.set_ID(xdr["Expiry_ID"]);
            Item_ToOffer_v = tf.set_bool(xdr["Item_ToOffer"]);
            Item_Warranty_ID = tf.set_ID(xdr["Warranty_ID"]);
            Warranty_WarrantyConditions_v = tf.set_string(xdr["Warranty_WarrantyConditions"]);
            Warranty_WarrantyDuration_v = tf.set_int(xdr["Warranty_WarrantyDuration"]);
            Warranty_WarrantyDurationType_v = tf.set_short(fs.MyConvertToShort(xdr["Warranty_WarrantyDurationType"]));
            Taxation_ID = tf.set_ID(xdr["Taxation_ID"]);
            Taxation_Name_v = tf.set_string(xdr["Taxation_Name"]);
            Taxation_Rate_v = tf.set_decimal(xdr["Taxation_Rate"]);
            PurchasePricePerUnit_v = tf.set_decimal(xdr["PurchasePricePerUnit"]);
            PurchaseOrganisation_Name_v = tf.set_string(xdr["PurchaseOrganisation_Name"]);
            PurchaseOrganisation_Address_v.StreetName_v = tf.set_dstring(xdr["StreetName"]);
            PurchaseOrganisation_Address_v.HouseNumber_v = tf.set_dstring(xdr["HouseNumber"]);
            PurchaseOrganisation_Address_v.City_v = tf.set_dstring(xdr["City"]);
            PurchaseOrganisation_Address_v.ZIP_v = tf.set_dstring(xdr["ZIP"]);
            PurchaseOrganisation_Address_v.Country_v = tf.set_dstring(xdr["Country"]);
            if (xdr["s1_name"] is string)
            {
                s1_name = (string)xdr["s1_name"];
            }
            if (xdr["s2_name"] is string)
            {
                s2_name = (string)xdr["s2_name"];
            }
            if (xdr["s3_name"] is string)
            {
                s3_name = (string)xdr["s3_name"];
            }
        }


        public decimal dQuantity_OfStockItems
        {
            get
            {
                decimal d = 0;
                foreach (Stock_Data stock_data in this.Stock_Data_List)
                {
                    if (stock_data.Stock_ID != null)
                    {
                        if (stock_data.StockTake_Draft != null)
                        {
                            if (stock_data.StockTake_Draft.v == false)
                            {
                                if (stock_data.dQuantity_v != null)
                                {
                                    d += stock_data.dQuantity_v.v;
                                }
                            }
                        }
                    }
                }
                return d;
            }
        }

        public decimal Discount {
            get
            {
                if (this.Price_Item_Discount_v!=null)
                {
                    return Price_Item_Discount_v.v;
                }
                else
                {
                    return 0;
                }
            }
        }

        public void SetNewStock(ID stock_ID, decimal dnewinstock)
        {
           foreach(Stock_Data std in this.Stock_Data_List)
           {
                if ((std.Stock_ID==null)&&(std.dQuantity_v==null))
                {
                    std.Stock_ID = tf.set_ID(stock_ID);
                    std.dQuantity_v = tf.set_decimal(dnewinstock);
                    return;
                }
           }

            Stock_Data xstd = new Stock_Data();
            xstd.Stock_ID = tf.set_ID(stock_ID);
            xstd.dQuantity_v = tf.set_decimal(dnewinstock);
            this.Stock_Data_List.Add(xstd);

        }

        internal bool ReceiveBackToStock(ID stock_ID, decimal xdQuantity)
        {
            if (ID.Validate(stock_ID))
            {
                foreach (Stock_Data std in this.Stock_Data_List)
                {
                    if (ID.Validate(std.Stock_ID))
                    {
                        if (std.Stock_ID.Equals(stock_ID))
                        {
                            if (std.dQuantity_v==null)
                            {
                                std.dQuantity_v = new decimal_v();
                            }
                            decimal dnew_quantity_in_stock = std.dQuantity_v.v + xdQuantity;
                            if (f_Stock.UpdateQuantity(stock_ID, dnew_quantity_in_stock))
                            {
                                std.dQuantity_v.v = dnew_quantity_in_stock;
                                return true;
                            }
                        }
                    }
                    //else
                    //{
                    //    LogFile.Error.Show("ERROR:TangentaDB:Item_Data:ReceiveBackToStock:std.Stock_ID is not valid!");
                    //}
                    return true;
                }
                // THIS ITEM has no stock his it is FACTORY ITEM
                //LogFile.Error.Show("ERROR:TangentaDB:Item_Data:ReceiveBackToStock:stock_ID was not found in m_ShopSehlf!!");
            }
            else
            {
                LogFile.Error.Show("ERROR:TangentaDB:Item_Data:ReceiveBackToStock:stock_ID is not valid!");

            }
            return false;
        }

        internal Stock_Data Find_Stock_Data(Stock_Data stdtaken)
        {
            if (ID.Validate(stdtaken.Stock_ID))
            {
                foreach (Stock_Data stdx in this.Stock_Data_List)
                {
                    if (ID.Validate(stdx.Stock_ID))
                    {
                        if (stdx.Stock_ID.Equals(stdtaken.Stock_ID))
                        {
                            return stdx;
                        }
                    }
                }
            }
            return null;
        }
    }
}
