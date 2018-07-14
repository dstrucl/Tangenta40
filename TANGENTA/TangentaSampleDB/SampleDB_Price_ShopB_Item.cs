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
    public class SampleDB_Price_ShopB_Item
    {
        public decimal RetailShopB_ItemPrice = 0;
        public decimal_v Discount_v = null;
        public string TaxationName = null;
        public decimal TaxationRate = 0;
        public string ShopB_Item_Name = null;
        public string ShopB_Item_Abbreviation = null;
        public bool ShopB_Item_bToOffer = false;
        public Image ShopB_Item_Image = null;
        public int_v ShopB_Item_Code_v = null;
        public string ShopB_Item_ParentGroup1 = null;
        public string ShopB_Item_ParentGroup2 = null;
        public string ShopB_Item_ParentGroup3 = null;
        public string PriceList_Name = null;
        public bool PriceList_valid = false;
        public string Currency_Abbreviation = null;
        public string Currency_Name = null;
        public string Currency_Symbol = null;
        public int CurrencyCode = 0;
        public int Currency_DecimalPlaces = 0;
        public DateTime_v PriceList_ValidFrom_v = null;
        public DateTime_v PriceList_ValidTo_v = null;
        public DateTime_v PriceList_CreationDate_v = null;
        public string PriceList_Description = null;
        public ID Currency_ID = null;
        public ID ShopB_Item_ID = null;
        public ID Taxation_ID = null;
        public ID PriceList_ID = null;
        public ID Price_ShopB_Item_ID = null;

        public SampleDB_Price_ShopB_Item(
                                string xShopB_Item_Name,
                                string xShopB_Item_Abbreviation,
                                bool xShopB_Item_bToOffer,
                                Image xShopB_Item_Image,
                                int_v xShopB_Item_Code_v,
                                string xShopB_Item_ParentGroup1,
                                string xShopB_Item_ParentGroup2,
                                string xShopB_Item_ParentGroup3,
                                string xPriceList_Name,
                                bool xPriceList_valid,
                                DateTime_v xPriceList_ValidFrom_v,
                                DateTime_v xPriceList_ValidTo_v,
                                DateTime_v xPriceList_CreationDate_v,
                                string xPriceList_Description,
                                string xCurrency_Abbreviation,
                                string xCurrency_Name,
                                string xCurrency_Symbol,
                                int xCurrencyCode,
                                int xCurrency_DecimalPlaces,
                                string xTaxationName,
                                decimal xTaxationRate,
                                decimal xRetailShopB_ItemPrice,
                                decimal_v xDiscount_v)
        {

         ShopB_Item_Name =               xShopB_Item_Name;
         ShopB_Item_Abbreviation =       xShopB_Item_Abbreviation;
         ShopB_Item_bToOffer =           xShopB_Item_bToOffer;
         ShopB_Item_Image =              xShopB_Item_Image;
         ShopB_Item_Code_v =             xShopB_Item_Code_v;
         ShopB_Item_ParentGroup1 =       xShopB_Item_ParentGroup1;
         ShopB_Item_ParentGroup2 =       xShopB_Item_ParentGroup2;
         ShopB_Item_ParentGroup3 =       xShopB_Item_ParentGroup3;
         PriceList_Name =                xPriceList_Name;
         PriceList_valid =               xPriceList_valid;
         PriceList_ValidFrom_v =         xPriceList_ValidFrom_v;
         PriceList_ValidTo_v =           xPriceList_ValidTo_v;
         PriceList_CreationDate_v =      xPriceList_CreationDate_v;
         PriceList_Description =         xPriceList_Description;
         Currency_Abbreviation =         xCurrency_Abbreviation;
         Currency_Name =                 xCurrency_Name;
         Currency_Symbol =               xCurrency_Symbol;
         CurrencyCode =                  xCurrencyCode;
         Currency_DecimalPlaces =        xCurrency_DecimalPlaces;
         TaxationName =                  xTaxationName;
         TaxationRate =                  xTaxationRate;
         RetailShopB_ItemPrice =         xRetailShopB_ItemPrice;
         Discount_v = xDiscount_v;
        }
    }
}
