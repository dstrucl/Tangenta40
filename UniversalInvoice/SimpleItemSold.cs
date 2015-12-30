using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XML_or_HTML_invoice_from_template
{
    public class SimpleItemSold
    {
        public string SimpleItem_name;
        public decimal RetailSimpleItemPrice;
        public decimal RetailSimpleItemPriceWithDiscount;
        public string TaxationName;
        public int iQuantity;
        public decimal Discount;
        public decimal ExtraDiscount;
        public string CurrencySymbol;
        public decimal TaxationRate;
        public decimal TotalDiscount;
        public decimal NetPrice;
        public decimal TaxPrice;
        public decimal PriceWithTax;

        public SimpleItemSold(string _SimpleItem_name,
                            decimal _RetailSimpleItemPrice,
                            decimal _RetailSimpleItemPriceWithDiscount,
                            string _TaxationName,
                            int _iQuantity,
                            decimal _Discount,
                            decimal _ExtraDiscount,
                            string _CurrencySymbol,
                            decimal _TaxationRate,
                            decimal _TotalDiscount,
                            decimal _NetPrice,
                            decimal _TaxPrice,
                            decimal _PriceWithTax)
        {
            SimpleItem_name = _SimpleItem_name;
            RetailSimpleItemPrice = _RetailSimpleItemPrice;
            RetailSimpleItemPriceWithDiscount = _RetailSimpleItemPriceWithDiscount;
            TaxationName = _TaxationName;
            iQuantity = _iQuantity;
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
