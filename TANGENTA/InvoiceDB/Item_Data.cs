using DBTypes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceDB
{
    public class Item_Data
    {
        public string[] m_s_name_Group = null;
        public decimal nmUpDn_FactoryQuantity_Value = 0;
        public decimal nmUpDn_StockQuantity_Value = 0;
        public decimal ExtraDiscount = 0;

        public long_v Price_Item_ID = null;
        public decimal_v Price_Item_Discount = null;
        public long_v PriceList_ID = null;
        public string_v PriceList_Name = null;
        public string_v Currency_Name = null;
        public string_v Currency_Abbreviation = null;
        public string_v Currency_Symbol = null;
        public int_v Currency_DecimalPlaces = null;
        public long_v Stock_ID = null;
        public DateTime_v Stock_ExpiryDate = null;
        public decimal_v Stock_dQuantity = null;
        public decimal_v RetailPricePerUnit = null;
        public DateTime_v Stock_ImportTime = null;
        public long_v Item_ID = null;
        public string_v Item_UniqueName = null;
        public string_v Item_Name = null;
        public string_v Item_barcode = null;
        public long_v Item_Image_ID = null;
        public byte_array_v Item_Image_Image_Data = null;
        public string_v Item_Image_Image_Hash = null;
        public string_v Item_Description = null;
        public string_v Unit_Name = null;
        public string_v Unit_Symbol = null;
        public int_v Unit_DecimalPlaces = null;
        public bool_v Unit_StorageOption = null;
        public string_v Unit_Description = null;
        public long_v Expiry_ID = null;
        public int_v Expiry_ExpectedShelfLifeInDays = null;
        public int_v Expiry_SaleBeforeExpiryDateInDays = null;
        public int_v Expiry_DiscardBeforeExpiryDateInDays = null;
        public string_v Expiry_Description = null;
        public long_v Item_Expiry_ID = null;
        public bool_v Item_ToOffer = null;
        public long_v Item_Warranty_ID = null;
        public long_v Warranty_ID = null;
        public string_v Warranty_WarrantyConditions = null;
        public int_v Warranty_WarrantyDuration = null;
        public short_v Warranty_WarrantyDurationType = null;
        public long_v Taxation_ID = null;
        public string_v Taxation_Name = null;
        public decimal_v Taxation_Rate = null;
        public decimal_v PurchasePricePerUnit = null;
        public string_v PurchaseCompany_Name = null;
        public PostAddress_v PurchaseCompany_Address = new PostAddress_v();
        public DateTime_v ExpiryDate;
        public string s1_name;
        public string s2_name;
        public string s3_name;

        public List<Stock_Data> Stock_Data_List = new List<Stock_Data>();

        public void Set_Price_Item_Stock(DataRow xdr)
        {
            Price_Item_ID = func.set_long(xdr["Price_Item_ID"]);
            Price_Item_Discount = func.set_decimal(xdr["Price_Item_Discount"]);
            PriceList_ID = func.set_long(xdr["PriceList_ID"]);
            PriceList_Name = func.set_string(xdr["PriceList_Name"]);
            Currency_Name = func.set_string(xdr["Currency_Name"]); ;
            Currency_Abbreviation = func.set_string(xdr["Currency_Abbreviation"]);
            Currency_Symbol = func.set_string(xdr["Currency_Symbol"]);
            Currency_DecimalPlaces = func.set_int(xdr["Currency_DecimalPlaces"]);
            Stock_ID = func.set_long(xdr["Stock_ID"]);
            Stock_ExpiryDate = func.set_DateTime(xdr["Stock_ExpiryDate"]);
            Stock_dQuantity = func.set_decimal(xdr["Stock_dQuantity"]);
            RetailPricePerUnit = func.set_decimal(xdr["RetailPricePerUnit"]);
            Stock_ImportTime = func.set_DateTime(xdr["Stock_ImportTime"]);
            Item_ID = func.set_long(xdr["Item_ID"]);
            Item_UniqueName = func.set_string(xdr["Item_UniqueName"]);
            Item_Name = func.set_string(xdr["Item_Name"]);
            Item_barcode = func.set_string(xdr["Item_barcode"]);
            Item_Image_ID = func.set_long(xdr["Item_Image_ID"]);
            Item_Image_Image_Data = func.set_byte_array(xdr["Item_Image_Image_Data"]);
            Item_Image_Image_Hash = func.set_string(xdr["Item_Image_Image_Hash"]);
            Item_Description = func.set_string(xdr["Item_Description"]);
            Unit_Name = func.set_string(xdr["Unit_Name"]);
            Unit_Symbol = func.set_string(xdr["Unit_Symbol"]);
            Unit_DecimalPlaces = func.set_int(xdr["Unit_DecimalPlaces"]);
            Unit_StorageOption = func.set_bool(xdr["Unit_StorageOption"]);
            Unit_Description = func.set_string(xdr["Unit_Description"]);
            Expiry_ID = func.set_long(xdr["Expiry_ID"]);
            Unit_Name = func.set_string(xdr["Unit_Name"]);
            Expiry_ExpectedShelfLifeInDays = func.set_int(xdr["Expiry_ExpectedShelfLifeInDays"]);
            Expiry_SaleBeforeExpiryDateInDays = func.set_int(xdr["Expiry_SaleBeforeExpiryDateInDays"]);
            Expiry_DiscardBeforeExpiryDateInDays = func.set_int(xdr["Expiry_DiscardBeforeExpiryDateInDays"]);
            Expiry_Description = func.set_string(xdr["Expiry_ExpiryDescription"]);
            Item_Expiry_ID = func.set_long(xdr["Expiry_ID"]);
            Item_ToOffer = func.set_bool(xdr["Item_ToOffer"]);
            Item_Warranty_ID = func.set_long(xdr["Warranty_ID"]);
            Warranty_ID = func.set_long(xdr["Warranty_ID"]);
            Warranty_WarrantyConditions = func.set_string(xdr["Warranty_WarrantyConditions"]);
            Warranty_WarrantyDuration = func.set_int(xdr["Warranty_WarrantyDuration"]);
            Warranty_WarrantyDurationType = func.set_short(xdr["Warranty_WarrantyDurationType"]);
            Taxation_ID = func.set_long(xdr["Taxation_ID"]);
            Taxation_Name = func.set_string(xdr["Taxation_Name"]);
            Taxation_Rate = func.set_decimal(xdr["Taxation_Rate"]);
            PurchasePricePerUnit = func.set_decimal(xdr["PurchasePricePerUnit"]);
            PurchaseCompany_Name = func.set_string(xdr["PurchaseCompany_Name"]);
            PurchaseCompany_Address.StreetName_v = func.set_string(xdr["StreetName"]);
            PurchaseCompany_Address.HouseNumber_v = func.set_string(xdr["HouseNumber"]);
            PurchaseCompany_Address.City_v = func.set_string(xdr["City"]);
            PurchaseCompany_Address.ZIP_v = func.set_string(xdr["ZIP"]);
            PurchaseCompany_Address.State_v = func.set_string(xdr["State"]);
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

        //public void Get_price_item_factory()
        //{
        //    price_item_factory = new CurrentInvoice.Price_Item_Stock();
        //    price_item_factory = price_item_stock.Clone();
        //    price_item_factory.Stock_ID = null;
        //    price_item_factory.Stock_ExpiryDate = null;
        //    price_item_factory.Stock_dQuantity = null;
        //}


        public decimal dQuantity_OfStockItems
        {
            get
            {
                decimal d = 0;
                foreach (Stock_Data stock_data in this.Stock_Data_List)
                {
                    if (stock_data.Stock_ID != null)
                    {
                        if (stock_data.dQuantity != null)
                        {
                            d += stock_data.dQuantity.v;
                        }

                    }
                }
                return d;
            }
        }
    }
}
