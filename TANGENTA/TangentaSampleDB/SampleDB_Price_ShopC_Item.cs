using DBConnectionControl40;
using DBTypes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TangentaSampleDB
{
    public class SampleDB_Price_ShopC_Item
    {
        public decimal ShopC_Price_Item_RetailPricePerUnit = 0;
        public decimal_v ShopC_Price_Item_Discount_v = null;

        public string ShopC_Price_Item_TaxationName = null;
        public decimal ShopC_Price_Item_TaxationRate = 0;


        public int_v ShopC_Item_Code = null;
        public string ShopC_Item_UniqueName = null;
        public string ShopC_Item_Name = null;

        public string ShopC_Item_ParentGroup1 = null;
        public string ShopC_Item_ParentGroup2 = null;
        public string ShopC_Item_ParentGroup3 = null;

        public string ShopC_Item_Unit_Name = null;
        public string ShopC_Item_Unit_Symbol = null;
        public int ShopC_Item_Unit_DecimalPlaces = -1;
        public bool ShopC_Item_Unit_StorageOption = false;
        public string ShopC_Item_Unit_Description = null;

        public string ShopC_Item_barcode = null;
        public string ShopC_Item_Description = null;

        public int ShopC_Item_Expiry_ExpectedShelfLifeInDays = -1;
        public int ShopC_Item_Expiry_SaleBeforeExpiryDateInDays = -1;
        public int ShopC_Item_Expiry_DiscardBeforeExpiryDateInDays = -1;
        public string ShopC_Item_Expiry_ExpiryDescription = null;

        public int ShopC_Item_Warranty_WarrantyDuration = -1;
        public int ShopC_Item_Warranty_WarrantyDurationType = -1;
        public string ShopC_Item_Warranty_WarrantyConditions = null;

        public Image ShopC_Item_Image = null;

        public bool ShopC_Item_ToOffer = false;


        public string ShopC_Price_Item_PriceList_Name = null;
        public bool ShopC_Price_Item_PriceList_valid = false;

        public string ShopC_Price_Item_Currency_Abbreviation = null;
        public string ShopC_Price_Item_Currency_Name = null;
        public string ShopC_Price_Item_Currency_Symbol = null;
        public int ShopC_Price_Item_CurrencyCode = 0;
        public int ShopC_Price_Item_Currency_DecimalPlaces = 0;

        public DateTime_v ShopC_Price_Item_PriceList_ValidFrom_v = null;
        public DateTime_v ShopC_Price_Item_PriceList_ValidTo_v = null;
        public DateTime_v ShopC_Price_Item_PriceList_CreationDate_v = null;
        public string ShopC_Price_Item_PriceList_Description = null;

        public ID ShopC_Price_Item_Item_ID = null;
        public ID ShopC_Item_Unit_ID = null;
        public ID ShopC_Item_Expiry_ID = null;
        public ID ShopC_Item_Warranty_ID = null;
        public ID ShopC_Price_Item_Taxation_ID = null;
        public ID ShopC_Price_Item_PriceList_ID = null;
        public ID ShopC_Price_Item_Currency_ID = null;
        public ID ShopC_Price_Item_ID = null;
        public ID ShopC_Item_Image_ID = null;

        public SampleDB_Price_ShopC_Item(   string xShopC_Item_UniqueName,
                                            string xShopC_Item_Name,
                                            int_v xShopC_Item_Code,
                                            string xShopC_Item_ParentGroup1,
                                            string xShopC_Item_ParentGroup2,
                                            string xShopC_Item_ParentGroup3,
                                            string xShopC_Item_Unit_Name,
                                            string xShopC_Item_Unit_Symbol,
                                            int xShopC_Item_Unit_DecimalPlaces,
                                            bool xShopC_Item_Unit_StorageOption,
                                            string xShopC_Item_Unit_Description,
                                            string xShopC_Item_barcode,
                                            string xShopC_Item_Description,
                                            int xShopC_Item_Expiry_ExpectedShelfLifeInDays,
                                            int xShopC_Item_Expiry_SaleBeforeExpiryDateInDays,
                                            int xShopC_Item_Expiry_DiscardBeforeExpiryDateInDays,
                                            string xShopC_Item_Expiry_ExpiryDescription,
                                            int xShopC_Item_Warranty_WarrantyDuration,
                                            int xShopC_Item_Warranty_WarrantyDurationType,
                                            string xShopC_Item_Warranty_WarrantyConditions,
                                            Image xShopC_Item_Image,
                                            bool xShopC_Item_ToOffer,
                                            string xShopC_Price_Item_PriceList_Name,
                                            bool xShopC_Price_Item_PriceList_valid,
                                            string xShopC_Price_Item_Currency_Abbreviation,
                                            string xShopC_Price_Item_Currency_Name,
                                            string xShopC_Price_Item_Currency_Symbol,
                                            int xShopC_Price_Item_CurrencyCode,
                                            int xShopC_Price_Item_Currency_DecimalPlaces,
                                            DateTime_v xShopC_Price_Item_PriceList_ValidFrom_v,
                                            DateTime_v xShopC_Price_Item_PriceList_ValidTo_v,
                                            DateTime_v xShopC_Price_Item_PriceList_CreationDate_v,
                                            string xShopC_Price_Item_PriceList_Description,
                                            string xShopC_Price_Item_TaxationName,
                                            decimal xShopC_Price_Item_TaxationRate,
                                            decimal xShopC_Price_Item_RetailPricePerUnit,
                                            decimal_v xShopC_Price_Item_Discount_v
                                            )
        {

            ShopC_Price_Item_RetailPricePerUnit = xShopC_Price_Item_RetailPricePerUnit;
            ShopC_Price_Item_Discount_v = xShopC_Price_Item_Discount_v;
            ShopC_Price_Item_TaxationName = xShopC_Price_Item_TaxationName;
            ShopC_Price_Item_TaxationRate = xShopC_Price_Item_TaxationRate;
            ShopC_Item_Code = xShopC_Item_Code;
            ShopC_Item_UniqueName = xShopC_Item_UniqueName;
            ShopC_Item_Name = xShopC_Item_Name;
            ShopC_Item_ParentGroup1 = xShopC_Item_ParentGroup1;
            ShopC_Item_ParentGroup2 = xShopC_Item_ParentGroup2;
            ShopC_Item_ParentGroup3 = xShopC_Item_ParentGroup3;
            ShopC_Item_Unit_Name = xShopC_Item_Unit_Name;
            ShopC_Item_Unit_Symbol = xShopC_Item_Unit_Symbol;
            ShopC_Item_Unit_DecimalPlaces = xShopC_Item_Unit_DecimalPlaces;
            ShopC_Item_Unit_StorageOption = xShopC_Item_Unit_StorageOption;
            ShopC_Item_Unit_Description = xShopC_Item_Unit_Description;
            ShopC_Item_barcode = xShopC_Item_barcode;
            ShopC_Item_Description = xShopC_Item_Description;
            ShopC_Item_Expiry_ExpectedShelfLifeInDays = xShopC_Item_Expiry_ExpectedShelfLifeInDays;
            ShopC_Item_Expiry_SaleBeforeExpiryDateInDays = xShopC_Item_Expiry_SaleBeforeExpiryDateInDays;
            ShopC_Item_Expiry_DiscardBeforeExpiryDateInDays = xShopC_Item_Expiry_DiscardBeforeExpiryDateInDays;
            ShopC_Item_Expiry_ExpiryDescription = xShopC_Item_Expiry_ExpiryDescription;
            ShopC_Item_Warranty_WarrantyDuration = xShopC_Item_Warranty_WarrantyDuration;
            ShopC_Item_Warranty_WarrantyDurationType = xShopC_Item_Warranty_WarrantyDurationType;
            ShopC_Item_Warranty_WarrantyConditions = xShopC_Item_Warranty_WarrantyConditions;
            ShopC_Item_Image = xShopC_Item_Image;
            ShopC_Item_ToOffer = xShopC_Item_ToOffer;
            ShopC_Price_Item_PriceList_Name = xShopC_Price_Item_PriceList_Name;
            ShopC_Price_Item_PriceList_valid = xShopC_Price_Item_PriceList_valid;
            ShopC_Price_Item_Currency_Abbreviation = xShopC_Price_Item_Currency_Abbreviation;
            ShopC_Price_Item_Currency_Name = xShopC_Price_Item_Currency_Name;
            ShopC_Price_Item_Currency_Symbol = xShopC_Price_Item_Currency_Symbol;
            ShopC_Price_Item_CurrencyCode = xShopC_Price_Item_CurrencyCode;
            ShopC_Price_Item_Currency_DecimalPlaces = xShopC_Price_Item_Currency_DecimalPlaces;
            ShopC_Price_Item_PriceList_ValidFrom_v = xShopC_Price_Item_PriceList_ValidFrom_v;
            ShopC_Price_Item_PriceList_ValidTo_v = xShopC_Price_Item_PriceList_ValidTo_v;
            ShopC_Price_Item_PriceList_CreationDate_v = xShopC_Price_Item_PriceList_CreationDate_v;
            ShopC_Price_Item_PriceList_Description = xShopC_Price_Item_PriceList_Description;
        }
    }
}
