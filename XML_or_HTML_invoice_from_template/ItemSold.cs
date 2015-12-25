using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XML_or_HTML_invoice_from_template
{
    public class ItemSold
    {
        public string Item_UniqueName;
        public decimal RetailPricePerUnit;
        public string UnitName;
        public decimal RetailPricePerUnitWithDiscount;
        public string TaxationName;
        public decimal dQuantity;
        public decimal Discount;
        public decimal ExtraDiscount;
        public string CurrencySymbol;
        public decimal TaxationRate;
        public decimal TotalDiscount;
        public decimal NetPrice;
        public decimal TaxPrice;
        public decimal PriceWithTax;

        public ItemSold(string _Item_UniqueName,
                            decimal _RetailPricePerUnit,
                            string _UnitName,
                            decimal _RetailPricePerUnitWithDiscount,
                            string _TaxationName,
                            decimal _dQuantity,
                            decimal _Discount,
                            decimal _ExtraDiscount,
                            string _CurrencySymbol,
                            decimal _TaxationRate,
                            decimal _TotalDiscount,
                            decimal _NetPrice,
                            decimal _TaxPrice,
                            decimal _PriceWithTax)
        {
            Item_UniqueName = _Item_UniqueName;
            RetailPricePerUnit = _RetailPricePerUnit;
            UnitName = _UnitName;
            RetailPricePerUnitWithDiscount = _RetailPricePerUnitWithDiscount;
            TaxationName = _TaxationName;
            dQuantity = _dQuantity;
            Discount = _Discount;
            ExtraDiscount = _ExtraDiscount;
            CurrencySymbol = _CurrencySymbol;
            TaxationRate = _TaxationRate;
            TotalDiscount = _TotalDiscount;
            NetPrice = _NetPrice;
            TaxPrice = _TaxPrice;
            PriceWithTax = _PriceWithTax;
        }
    }
}
