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

namespace TangentaDB
{
    public class Columns_PurchasePrice_CItem_Stock
    {

        //public int icol_Price_Item_ID = -1;
        //public int icol_PriceList_ID = -1;
        //public int icol_PriceList_Name = -1;
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
        public int icol_PurchaseOrganisation_Name = -1;
        public int icol_StreetName = -1;
        public int icol_HouseNumber = -1;
        public int icol_City = -1;
        public int icol_ZIP = -1;
        public int icol_Country= -1;
        public int icol_State = -1;
        public int icol_s1_name = -1;
        public int icol_s2_name = -1;
        public int icol_s3_name = -1;

        public bool Defined
        {
            get { return icol_Stock_ID >= 0; }
        }
        //public string sPrice_Item_ID = "Price_Item_ID";
        //public string sPriceList_ID = "PriceList_ID";
        //public string sPriceList_Name = "PriceList_Name";
        public string sCurrency_Name = "PurchasePrice_Item_$_pp_$_Cur_$$Name";
        public string sCurrency_Abbreviation = "PurchasePrice_Item_$_pp_$_Cur_$$Abbreviation";
        public string sCurrency_Symbol = "PurchasePrice_Item_$_pp_$_Cur_$$Symbol";
        public string sCurrency_DecimalPlaces = "PurchasePrice_Item_$_pp_$_Cur_$$DecimalPlaces";

        public string sStock_ID = "Stock_ID";
        //public string sRetailPricePerUnit = "RetailPricePerUnit";
        public string sPurchasePricePerUnit = "PurchasePrice_Item_$_pp_$$PurchasePricePerUnit";
        public string sPurchasePrice_Item_Discount = "PurchasePrice_Item_$_pp_$$Discount";
        public string sTaxation_ID = "PurchasePrice_Item_$_pp_$_tax_$$ID";
        public string sTaxation_Rate = "PurchasePrice_Item_$_pp_$_tax_$$Rate";
        public string sTaxation_Name = "PurchasePrice_Item_$_pp_$_tax_$$Name";
        public string sStock_ExpiryDate = "Stock_ExpiryDate";
        public string sStock_dQuantity = "Stock_dQuantity";
        public string sStock_ImportTime = "Stock_ImportTime";
        public string sStockTake_Draft = "PurchasePrice_Item_$_st_$$Draft";
        public string sItem_ID = "PurchasePrice_Item_$_i_$$ID";
        public string sItem_UniqueName = "PurchasePrice_Item_$_i_$$UniqueName";
        public string sItem_Name = "PurchasePrice_Item_$_i_$$Name";
        public string sItem_barcode = "PurchasePrice_Item_$_i_$$barcode";
        public string sItem_Image_ID = "PurchasePrice_Item_$_i_$_iimg_$$ID";
        public string sUnit_Name = "PurchasePrice_Item_$_i_$_u_$$Name";
        public string sUnit_Symbol = "PurchasePrice_Item_$_i_$_u_$$Symbol";
        public string sUnit_DecimalPlaces = "PurchasePrice_Item_$_i_$_u_$$DecimalPlaces";
        public string sUnit_StorageOption = " PurchasePrice_Item_$_i_$_u_$$StorageOption";
        public string sUnit_Description = "PurchasePrice_Item_$_i_$_u_$$Description";
        public string sItem_Image_Image_Data = "PurchasePrice_Item_$_i_$_iimg_$$Image_Data";
        public string sItem_Image_Image_Hash = "PurchasePrice_Item_$_i_$_iimg_$$Image_Hash";
        public string sItem_Description = "PurchasePrice_Item_$_i_$$Description";
        public string sExpiry_ID = "PurchasePrice_Item_$_i_$_exp_$$ID";
        public string sExpiry_ExpectedShelfLifeInDays = "PurchasePrice_Item_$_i_$_exp_$$ExpectedShelfLifeInDays";
        public string sExpiry_SaleBeforeExpiryDateInDays = "PurchasePrice_Item_$_i_$_exp_$$SaleBeforeExpiryDateInDays";
        public string sExpiry_DiscardBeforeExpiryDateInDays = "PurchasePrice_Item_$_i_$_exp_$$DiscardBeforeExpiryDateInDays";
        public string sExpiry_ExpiryDescription = "PurchasePrice_Item_$_i_$_exp_$$ExpiryDescription";
        public string sItem_ToOffer = "PurchasePrice_Item_$_i_$$ToOffer";
        public string sWarranty_ID = "PurchasePrice_Item_$_i_$_wrty_$$ID";
        public string sWarranty_WarrantyConditions = "PurchasePrice_Item_$_i_$_wrty_$$WarrantyConditions";
        public string sWarranty_WarrantyDuration = "PurchasePrice_Item_$_i_$_wrty_$$WarrantyDuration";
        public string sWarranty_WarrantyDurationType = "PurchasePrice_Item_$_i_$_wrty_$$WarrantyDurationType";
        public string sPurchaseOrganisation_Name = "PurchasePrice_Item_$_st_$_sup_$_c_$_orgd_$_org_$$Name";
        public string sStreetName = "PurchasePrice_Item_$_st_$_sup_$_c_$_orgd_$_cadrorg_$_cstrnorg_$$StreetName";
        public string sHouseNumber = "PurchasePrice_Item_$_st_$_sup_$_c_$_orgd_$_cadrorg_$_chounorg_$$HouseNumber";
        public string sCity = "PurchasePrice_Item_$_st_$_sup_$_c_$_orgd_$_cadrorg_$_ccitorg_$$City";
        public string sZIP = "PurchasePrice_Item_$_st_$_sup_$_c_$_orgd_$_cadrorg_$_cziporg_$$ZIP";
        public string sCountry= "PurchasePrice_Item_$_st_$_sup_$_c_$_orgd_$_cadrorg_$_ccouorg_$$Country";
        public string sState = "PurchasePrice_Item_$_st_$_sup_$_c_$_orgd_$_cadrorg_$_cstorg_$$State";
        public string ss1_name = "s1_name";
        public string ss2_name = "s2_name";
        public string ss3_name = "s3_name";

        public void Set(DataTable dt)
        {
            
            if (Defined)
            {
                return;
            }
            //icol_Price_Item_ID = dt.Columns.IndexOf(sPrice_Item_ID);
            //icol_PriceList_ID = dt.Columns.IndexOf(sPriceList_ID);
            //icol_PriceList_Name = dt.Columns.IndexOf(sPriceList_Name);
            icol_Currency_Name = dt.Columns.IndexOf(sCurrency_Name);
            icol_Currency_Abbreviation = dt.Columns.IndexOf(sCurrency_Abbreviation); ;
            icol_Currency_Symbol = dt.Columns.IndexOf(sCurrency_Symbol); ;
            icol_Currency_DecimalPlaces = dt.Columns.IndexOf(sCurrency_DecimalPlaces); ;

            
            //icol_RetailPricePerUnit = dt.Columns.IndexOf(sRetailPricePerUnit);
            icol_PurchasePricePerUnit = dt.Columns.IndexOf(sPurchasePricePerUnit);
            icol_Discount = dt.Columns.IndexOf(sPurchasePrice_Item_Discount);
            icol_Taxation_ID = dt.Columns.IndexOf(sTaxation_ID);
            icol_Taxation_Rate = dt.Columns.IndexOf(sTaxation_Rate);
            icol_Taxation_Name = dt.Columns.IndexOf(sTaxation_Name);
            icol_Taxation_Rate = dt.Columns.IndexOf(sTaxation_Rate);
            icol_Stock_ID = dt.Columns.IndexOf(sStock_ID);
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
            icol_PurchaseOrganisation_Name = dt.Columns.IndexOf(sPurchaseOrganisation_Name);
            icol_StreetName = dt.Columns.IndexOf(sStreetName);
            icol_HouseNumber = dt.Columns.IndexOf(sHouseNumber);
            icol_City = dt.Columns.IndexOf(sCity);
            icol_ZIP = dt.Columns.IndexOf(sZIP);
            icol_Country= dt.Columns.IndexOf(sCountry);
            icol_State = dt.Columns.IndexOf(sState);
            icol_s1_name = dt.Columns.IndexOf(ss1_name);
            icol_s2_name = dt.Columns.IndexOf(ss2_name);
            icol_s3_name = dt.Columns.IndexOf(ss3_name);
        }
    }
}
