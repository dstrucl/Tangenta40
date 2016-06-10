using DBTypes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TangentaSampleDB
{
    public class SampleDB_Price_SimpleItem
    {
        public decimal RetailSimpleItemPrice = 0;
        public decimal_v Discount_v = null;
        public string TaxationName = null;
        public decimal TaxationRate = 0;
        public string SimpleItem_Name = null;
        public string SimpleItem_Abbreviation = null;
        public bool SimpleItem_bToOffer = false;
        public Image SimpleItem_Image = null;
        public int_v SimpleItem_Code_v = null;
        public string SimpleItem_ParentGroup1 = null;
        public string SimpleItem_ParentGroup2 = null;
        public string SimpleItem_ParentGroup3 = null;
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
        public long Currency_ID = -1;
        public long SimpleItem_ID = -1;
        public long Taxation_ID = -1;
        public long PriceList_ID = -1;
        public long Price_SimpleItem_ID = -1;

        public SampleDB_Price_SimpleItem(
                                string xSimpleItem_Name,
                                string xSimpleItem_Abbreviation,
                                bool xSimpleItem_bToOffer,
                                Image xSimpleItem_Image,
                                int_v xSimpleItem_Code_v,
                                string xSimpleItem_ParentGroup1,
                                string xSimpleItem_ParentGroup2,
                                string xSimpleItem_ParentGroup3,
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
                                decimal xRetailSimpleItemPrice,
                                decimal_v xDiscount_v)
        {

         SimpleItem_Name =               xSimpleItem_Name;
         SimpleItem_Abbreviation =       xSimpleItem_Abbreviation;
         SimpleItem_bToOffer =           xSimpleItem_bToOffer;
         SimpleItem_Image =              xSimpleItem_Image;
         SimpleItem_Code_v =             xSimpleItem_Code_v;
         SimpleItem_ParentGroup1 =       xSimpleItem_ParentGroup1;
         SimpleItem_ParentGroup2 =       xSimpleItem_ParentGroup2;
         SimpleItem_ParentGroup3 =       xSimpleItem_ParentGroup3;
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
         RetailSimpleItemPrice =         xRetailSimpleItemPrice;
         Discount_v = xDiscount_v;
        }
    }
}
