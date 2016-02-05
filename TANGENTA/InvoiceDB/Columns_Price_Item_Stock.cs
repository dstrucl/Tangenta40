#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceDB
{
    public class Columns_Price_Item_Stock
    {

        public int icol_Price_Item_ID = -1;
        public int icol_PriceList_ID = -1;
        public int icol_PriceList_Name = -1;
        public int icol_Currency_Name = -1;
        public int icol_Currency_Abbreviation = -1;
        public int icol_Currency_Symbol = -1;
        public int icol_Currency_DecimalPlaces = -1;
        public int icol_Stock_ID = -1;
        public int icol_RetailPricePerUnit = -1;
        public int icol_PurchasePricePerUnit = -1;
        public int icol_Discount = -1;
        public int icol_Taxation_ID = -1;
        public int icol_Taxation_Rate = -1;
        public int icol_Taxation_Name = -1;
        public int icol_Stock_ExpiryDate = -1;
        public int icol_Stock_dQuantity = -1;
        public int icol_Stock_ImportTime = -1;
        public int icol_Item_ID = -1;
        public int icol_Item_UniqueName = -1;
        public int icol_Item_Name = -1;
        public int icol_Item_barcode = -1;
        public int icol_Item_Image_ID = -1;
        public int icol_Unit_Name = -1;
        public int icol_Unit_Symbol = -1;
        public int icol_Unit_DecimalPlaces = -1;
        public int icol_Unit_StorageOption = -1;
        public int icol_Unit_Description = -1;
        public int icol_Item_Image_Image_Data = -1;
        public int icol_Item_Image_Image_Hash = -1;
        public int icol_Item_Description = -1;
        public int icol_Expiry_ID = -1;
        public int icol_Expiry_ExpectedShelfLifeInDays = -1;
        public int icol_Expiry_SaleBeforeExpiryDateInDays = -1;
        public int icol_Expiry_DiscardBeforeExpiryDateInDays = -1;
        public int icol_Expiry_ExpiryDescription = -1;
        public int icol_Item_ToOffer = -1;
        public int icol_Warranty_ID = -1;
        public int icol_Warranty_WarrantyConditions = -1;
        public int icol_Warranty_WarrantyDuration = -1;
        public int icol_Warranty_WarrantyDurationType = -1;
        public int icol_PurchaseCompany_Name = -1;
        public int icol_StreetName = -1;
        public int icol_HouseNumber = -1;
        public int icol_City = -1;
        public int icol_ZIP = -1;
        public int icol_State = -1;
        public int icol_Country = -1;
        public int icol_s1_name = -1;
        public int icol_s2_name = -1;
        public int icol_s3_name = -1;

        public bool Defined
        {
            get { return icol_Price_Item_ID >= 0; }
        }
        public string sPrice_Item_ID = "Price_Item_ID";
        public string sPriceList_ID = "PriceList_ID";
        public string sPriceList_Name = "PriceList_Name";
        public string sCurrency_Name = "Currency_Name";
        public string sCurrency_Abbreviation = "Currency_Abbreviation";
        public string sCurrency_Symbol = "Currency_Symbol";
        public string sCurrency_DecimalPlaces = "Currency_DecimalPlaces";

        public string sStock_ID = "Stock_ID";
        public string sRetailPricePerUnit = "RetailPricePerUnit";
        public string sPurchasePricePerUnit = "PurchasePricePerUnit";
        public string sPrice_Item_Discount = "Price_Item_Discount";
        public string sTaxation_ID = "Taxation_ID";
        public string sTaxation_Rate = "Taxation_Rate";
        public string sTaxation_Name = "Taxation_Name";
        public string sStock_ExpiryDate = "Stock_ExpiryDate";
        public string sStock_dQuantity = "Stock_dQuantity";
        public string sStock_ImportTime = "Stock_ImportTime";
        public string sItem_ID = "Item_ID";
        public string sItem_UniqueName = "Item_UniqueName";
        public string sItem_Name = "Item_Name";
        public string sItem_barcode = "Item_barcode";
        public string sItem_Image_ID = "Item_Image_ID";
        public string sUnit_Name = "Unit_Name";
        public string sUnit_Symbol = "Unit_Symbol";
        public string sUnit_DecimalPlaces = "Unit_DecimalPlaces";
        public string sUnit_StorageOption = "Unit_StorageOption";
        public string sUnit_Description = "Unit_Description";
        public string sItem_Image_Image_Data = "Item_Image_Image_Data";
        public string sItem_Image_Image_Hash = "Item_Image_Image_Hash";
        public string sItem_Description = "Item_Description";
        public string sExpiry_ID = "Expiry_ID";
        public string sExpiry_ExpectedShelfLifeInDays = "Expiry_ExpectedShelfLifeInDays";
        public string sExpiry_SaleBeforeExpiryDateInDays = "Expiry_SaleBeforeExpiryDateInDays";
        public string sExpiry_DiscardBeforeExpiryDateInDays = "Expiry_DiscardBeforeExpiryDateInDays";
        public string sExpiry_ExpiryDescription = "Expiry_ExpiryDescription";
        public string sItem_ToOffer = "Item_ToOffer";
        public string sWarranty_ID = "Warranty_ID";
        public string sWarranty_WarrantyConditions = "Warranty_WarrantyConditions";
        public string sWarranty_WarrantyDuration = "Warranty_WarrantyDuration";
        public string sWarranty_WarrantyDurationType = "Warranty_WarrantyDurationType";
        public string sPurchaseCompany_Name = "PurchaseCompany_Name";
        public string sStreetName = "StreetName";
        public string sHouseNumber = "HouseNumber";
        public string sCity = "City";
        public string sZIP = "ZIP";
        public string sState = "State";
        public string sCountry = "Country";
        public string ss1_name = "s1_name";
        public string ss2_name = "s2_name";
        public string ss3_name = "s3_name";

        public void Set(DataTable dt)
        {
            if (Defined)
            {
                return;
            }
            icol_Price_Item_ID = dt.Columns.IndexOf(sPrice_Item_ID);
            icol_PriceList_ID = dt.Columns.IndexOf(sPriceList_ID);
            icol_PriceList_Name = dt.Columns.IndexOf(sPriceList_Name);
            icol_Currency_Name = dt.Columns.IndexOf(sCurrency_Name);
            icol_Currency_Abbreviation = dt.Columns.IndexOf(sCurrency_Abbreviation); ;
            icol_Currency_Symbol = dt.Columns.IndexOf(sCurrency_Symbol); ;
            icol_Currency_DecimalPlaces = dt.Columns.IndexOf(sCurrency_DecimalPlaces); ;

            icol_Stock_ID = dt.Columns.IndexOf(sStock_ID);
            icol_RetailPricePerUnit = dt.Columns.IndexOf(sRetailPricePerUnit);
            icol_PurchasePricePerUnit = dt.Columns.IndexOf(sPurchasePricePerUnit);
            icol_Discount = dt.Columns.IndexOf(sPrice_Item_Discount);
            icol_Taxation_ID = dt.Columns.IndexOf(sTaxation_ID);
            icol_Taxation_Rate = dt.Columns.IndexOf(sTaxation_Rate);
            icol_Taxation_Name = dt.Columns.IndexOf(sTaxation_Name);
            icol_Taxation_Rate = dt.Columns.IndexOf(sTaxation_Rate);
            icol_Stock_ExpiryDate = dt.Columns.IndexOf(sStock_ExpiryDate);
            icol_Stock_dQuantity = dt.Columns.IndexOf(sStock_dQuantity);
            icol_Stock_ImportTime = dt.Columns.IndexOf(sStock_ImportTime);
            icol_Item_ID = dt.Columns.IndexOf(sItem_ID);
            icol_Item_UniqueName = dt.Columns.IndexOf(sItem_UniqueName);
            icol_Item_Name = dt.Columns.IndexOf(sItem_Name);
            icol_Item_barcode = dt.Columns.IndexOf(sItem_barcode);
            icol_Item_Image_ID = dt.Columns.IndexOf(sItem_Image_ID);
            icol_Unit_Name = dt.Columns.IndexOf(sUnit_Name);
            icol_Unit_Symbol = dt.Columns.IndexOf(sUnit_Symbol);
            icol_Unit_DecimalPlaces = dt.Columns.IndexOf(sUnit_DecimalPlaces);
            icol_Unit_StorageOption = dt.Columns.IndexOf(sUnit_StorageOption);
            icol_Unit_Description = dt.Columns.IndexOf(sUnit_Description);
            icol_Item_Image_Image_Data = dt.Columns.IndexOf(sItem_Image_Image_Data);
            icol_Item_Image_Image_Hash = dt.Columns.IndexOf(sItem_Image_Image_Hash);
            icol_Item_Description = dt.Columns.IndexOf(sItem_Description);
            icol_Expiry_ID = dt.Columns.IndexOf(sExpiry_ID);
            icol_Expiry_ExpectedShelfLifeInDays = dt.Columns.IndexOf(sExpiry_ExpectedShelfLifeInDays);
            icol_Expiry_SaleBeforeExpiryDateInDays = dt.Columns.IndexOf(sExpiry_SaleBeforeExpiryDateInDays);
            icol_Expiry_DiscardBeforeExpiryDateInDays = dt.Columns.IndexOf(sExpiry_DiscardBeforeExpiryDateInDays);
            icol_Expiry_ExpiryDescription = dt.Columns.IndexOf(sExpiry_ExpiryDescription);
            icol_Item_ToOffer = dt.Columns.IndexOf(sItem_ToOffer);
            icol_Warranty_ID = dt.Columns.IndexOf(sWarranty_ID);
            icol_Warranty_WarrantyConditions = dt.Columns.IndexOf(sWarranty_WarrantyConditions);
            icol_Warranty_WarrantyDuration = dt.Columns.IndexOf(sWarranty_WarrantyDuration);
            icol_Warranty_WarrantyDurationType = dt.Columns.IndexOf(sWarranty_WarrantyDurationType);
            icol_PurchaseCompany_Name = dt.Columns.IndexOf(sPurchaseCompany_Name);
            icol_StreetName = dt.Columns.IndexOf(sStreetName);
            icol_HouseNumber = dt.Columns.IndexOf(sHouseNumber);
            icol_City = dt.Columns.IndexOf(sCity);
            icol_ZIP = dt.Columns.IndexOf(sZIP);
            icol_State = dt.Columns.IndexOf(sState);
            icol_Country = dt.Columns.IndexOf(sCountry);
            icol_s1_name = dt.Columns.IndexOf(ss1_name);
            icol_s2_name = dt.Columns.IndexOf(ss2_name);
            icol_s3_name = dt.Columns.IndexOf(ss3_name);
        }
    }
}
