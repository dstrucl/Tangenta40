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
        public decimal_v Price_Item_Discount = null;
        public ID PriceList_ID = null;
        public string_v PriceList_Name = null;
        public string_v Currency_Name = null;
        public string_v Currency_Abbreviation = null;
        public string_v Currency_Symbol = null;
        public int_v Currency_DecimalPlaces = null;
        public ID Stock_ID = null;
        public DateTime_v Stock_ExpiryDate = null;
        public decimal_v Stock_dQuantity = null;
        public decimal_v RetailPricePerUnit = null;
        public DateTime_v Stock_ImportTime = null;
        public bool_v StockTake_Draft = null;
        public ID Item_ID = null;
        public string_v Item_UniqueName = null;
        public string_v Item_Name = null;
        public string_v Item_barcode = null;
        public ID Item_Image_ID = null;
        public byte_array_v Item_Image_Image_Data = null;
        public string_v Item_Image_Image_Hash = null;
        public string_v Item_Description = null;
        public string_v Unit_Name = null;
        public string_v Unit_Symbol = null;
        public int_v Unit_DecimalPlaces = null;
        public bool_v Unit_StorageOption = null;
        public string_v Unit_Description = null;
        public int_v Expiry_ExpectedShelfLifeInDays = null;
        public int_v Expiry_SaleBeforeExpiryDateInDays = null;
        public int_v Expiry_DiscardBeforeExpiryDateInDays = null;
        public string_v Expiry_Description = null;
        public ID Item_Expiry_ID = null;
        public bool_v Item_ToOffer = null;
        public ID Item_Warranty_ID = null;
        public string_v Warranty_WarrantyConditions = null;
        public int_v Warranty_WarrantyDuration = null;
        public short_v Warranty_WarrantyDurationType = null;
        public ID Taxation_ID = null;
        public string_v Taxation_Name = null;
        public decimal_v Taxation_Rate = null;
        public decimal_v PurchasePricePerUnit = null;
        public string_v PurchaseOrganisation_Name = null;
        public PostAddress_v PurchaseOrganisation_Address = new PostAddress_v();
        public DateTime_v ExpiryDate;
        public string s1_name;
        public string s2_name;
        public string s3_name;

        public List<Stock_Data> Stock_Data_List = new List<Stock_Data>();

        public Item_Data()
        {
        }

        public void Set_Price_Item_Stock(DataRow xdr)
        {
            Price_Item_ID = tf.set_ID(xdr["Price_Item_ID"]);
            Price_Item_Discount = tf.set_decimal(xdr["Price_Item_Discount"]);
            PriceList_ID = tf.set_ID(xdr["PriceList_ID"]);
            PriceList_Name = tf.set_string(xdr["PriceList_Name"]);
            Currency_Name = tf.set_string(xdr["Currency_Name"]); ;
            Currency_Abbreviation = tf.set_string(xdr["Currency_Abbreviation"]);
            Currency_Symbol = tf.set_string(xdr["Currency_Symbol"]);
            Currency_DecimalPlaces = tf.set_int(xdr["Currency_DecimalPlaces"]);
            Stock_ID = tf.set_ID(xdr["Stock_ID"]);
            Stock_ExpiryDate = tf.set_DateTime(xdr["Stock_ExpiryDate"]);
            Stock_dQuantity = tf.set_decimal(xdr["Stock_dQuantity"]);
            RetailPricePerUnit = tf.set_decimal(xdr["RetailPricePerUnit"]);
            Stock_ImportTime = tf.set_DateTime(xdr["Stock_ImportTime"]);
            StockTake_Draft = tf.set_bool(xdr["StockTake_Draft"]);
            Item_ID = tf.set_ID(xdr["Item_ID"]);
            Item_UniqueName = tf.set_string(xdr["Item_UniqueName"]);
            Item_Name = tf.set_string(xdr["Item_Name"]);
            Item_barcode = tf.set_string(xdr["Item_barcode"]);
            Item_Image_ID = tf.set_ID(xdr["Item_Image_ID"]);
            Item_Image_Image_Data = tf.set_byte_array(xdr["Item_Image_Image_Data"]);
            Item_Image_Image_Hash = tf.set_string(xdr["Item_Image_Image_Hash"]);
            Item_Description = tf.set_string(xdr["Item_Description"]);
            Unit_Name = tf.set_string(xdr["Unit_Name"]);
            Unit_Symbol = tf.set_string(xdr["Unit_Symbol"]);
            Unit_DecimalPlaces = tf.set_int(xdr["Unit_DecimalPlaces"]);
            Unit_StorageOption = tf.set_bool(xdr["Unit_StorageOption"]);
            Unit_Description = tf.set_string(xdr["Unit_Description"]);
            Unit_Name = tf.set_string(xdr["Unit_Name"]);
            Expiry_ExpectedShelfLifeInDays = tf.set_int(xdr["Expiry_ExpectedShelfLifeInDays"]);
            Expiry_SaleBeforeExpiryDateInDays = tf.set_int(xdr["Expiry_SaleBeforeExpiryDateInDays"]);
            Expiry_DiscardBeforeExpiryDateInDays = tf.set_int(xdr["Expiry_DiscardBeforeExpiryDateInDays"]);
            Expiry_Description = tf.set_string(xdr["Expiry_ExpiryDescription"]);
            Item_Expiry_ID = tf.set_ID(xdr["Expiry_ID"]);
            Item_ToOffer = tf.set_bool(xdr["Item_ToOffer"]);
            Item_Warranty_ID = tf.set_ID(xdr["Warranty_ID"]);
            Warranty_WarrantyConditions = tf.set_string(xdr["Warranty_WarrantyConditions"]);
            Warranty_WarrantyDuration = tf.set_int(xdr["Warranty_WarrantyDuration"]);
            Warranty_WarrantyDurationType = tf.set_short(fs.MyConvertToShort(xdr["Warranty_WarrantyDurationType"]));
            Taxation_ID = tf.set_ID(xdr["Taxation_ID"]);
            Taxation_Name = tf.set_string(xdr["Taxation_Name"]);
            Taxation_Rate = tf.set_decimal(xdr["Taxation_Rate"]);
            PurchasePricePerUnit = tf.set_decimal(xdr["PurchasePricePerUnit"]);
            PurchaseOrganisation_Name = tf.set_string(xdr["PurchaseOrganisation_Name"]);
            PurchaseOrganisation_Address.StreetName_v = tf.set_dstring(xdr["StreetName"]);
            PurchaseOrganisation_Address.HouseNumber_v = tf.set_dstring(xdr["HouseNumber"]);
            PurchaseOrganisation_Address.City_v = tf.set_dstring(xdr["City"]);
            PurchaseOrganisation_Address.ZIP_v = tf.set_dstring(xdr["ZIP"]);
            PurchaseOrganisation_Address.Country_v = tf.set_dstring(xdr["Country"]);
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
                                if (stock_data.dQuantity != null)
                                {
                                    d += stock_data.dQuantity.v;
                                }
                            }
                        }
                    }
                }
                return d;
            }
        }
    }
}
