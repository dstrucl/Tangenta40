using LanguageControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversalInvoice
{
    public class ItemSoldToken
    {
        // Start of items ****
        public TemplateToken tItemName = null;
        public TemplateToken tPricePerUnit = null;
        public TemplateToken tDiscount = null;
        public TemplateToken tDiscountPercent = null;
        public TemplateToken tExtraDiscount = null;
        public TemplateToken tExtraDiscountPercent = null;
        public TemplateToken tCurrency = null;
        public TemplateToken tUnit = null;
        public TemplateToken tQuantity = null;
        public TemplateToken tTaxationRate = null;
        public TemplateToken tTaxationRatePercent = null;
        public TemplateToken tTotalDiscount = null;
        public TemplateToken tTotalDiscountPercent = null;
        public TemplateToken tNetPrice = null;
        public TemplateToken tTax = null;
        public TemplateToken tPriceWithTax = null;
        public TemplateToken tStoreDivision = null;
        // End of items ****
        public List<TemplateToken> list = null;

        public ItemSoldToken( ltext token_prefix,
                              ltext lt_StoreDivision,
                              string _Item_Name,
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
            tStoreDivision = new TemplateToken(token_prefix, new string[] { "StoreDivision", "OddelekProdaje" }, lt_StoreDivision.s, null);
            tItemName = new TemplateToken(token_prefix, new string[] { "Name", "Ime" }, _Item_Name, null);
            tPricePerUnit = new TemplateToken(token_prefix, new string[] { "PricePerUnit", "CenaNaEnoto" }, _RetailPricePerUnit.ToString(), null);
            tUnit = new TemplateToken(token_prefix, new string[] { "Unit", "MerskaEnota" }, _UnitName, null);
            tDiscount = new TemplateToken(token_prefix, new string[] {"Discount", "Popust" }, _Discount.ToString(), null);
            tDiscountPercent = new TemplateToken(token_prefix, new string[] { "DiscountPercent", "PopustVProcentih" }, (_Discount*100).ToString()+"%", null);
            tExtraDiscount = new TemplateToken(token_prefix, new string[] { "ExtraDiscount", "DodatniPopust" }, _ExtraDiscount.ToString(), null);
            tExtraDiscountPercent = new TemplateToken(token_prefix, new string[] { "ExtraDiscountPercent", "DodatniPopustVProcentih" }, (_ExtraDiscount*100).ToString()+"%", null);
            tCurrency = new TemplateToken(token_prefix, new string[] { "Currency", "Valuta" }, _CurrencySymbol, null);
            if (_dQuantity >= 0)
            {
                tQuantity = new TemplateToken(token_prefix, new string[] { "Quantity", "Količina" }, _dQuantity.ToString(), null);
            }
            else
            {
                tQuantity = new TemplateToken(token_prefix, new string[] { "Quantity", "Količina" }, "", null);
            }
            tTaxationRate = new TemplateToken(token_prefix, new string[] { "TaxationRate", "DavčnaStopnja" }, _TaxationRate.ToString(), null);
            tTaxationRatePercent = new TemplateToken(token_prefix, new string[] { "TaxationRatePercent", "DavčnaStopnjaVProcentih" }, (_TaxationRate*100).ToString()+"%", null);
            tTotalDiscount = new TemplateToken(token_prefix, new string[] { "TotalDiscount", "CelotenPopust" }, _TotalDiscount.ToString(), null);
            tTotalDiscountPercent = new TemplateToken(token_prefix, new string[] { "TotalDiscountPercent", "CelotenPopustVProcentih" }, (_TotalDiscount * 100).ToString() + "%", null);
            tNetPrice = new TemplateToken(token_prefix, new string[] { "NetPrice", "Cena_Brez_DDV" }, _NetPrice.ToString(), null);
            tTax = new TemplateToken(token_prefix, new string[] { "Tax", "Davek" }, _TaxPrice.ToString(), null);
            tPriceWithTax = new TemplateToken(token_prefix, new string[] { "PriceWithTax", "Cena_z_DDV" }, _PriceWithTax.ToString(), null);

            list = new List<TemplateToken>();
            list.Add(tStoreDivision);
            list.Add(tItemName);
            list.Add(tPricePerUnit);
            list.Add(tUnit);
            list.Add(tDiscount);
            list.Add(tDiscountPercent);
            list.Add(tExtraDiscount);
            list.Add(tExtraDiscountPercent);
            list.Add(tCurrency);
            list.Add(tQuantity);
            list.Add(tTaxationRate);
            list.Add(tTaxationRatePercent);
            list.Add(tTotalDiscount);
            list.Add(tTotalDiscountPercent);
            list.Add(tNetPrice);
            list.Add(tTax);
            list.Add(tPriceWithTax);
        }
    }
}
