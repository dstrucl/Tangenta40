#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LanguageControl;

namespace UniversalInvoice
{
    public class ItemSold
    {
        public string Item_Name;
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
        public string StoreDivision;

        public ItemSoldToken token = null;

        public ItemSold(ltext token_prefix, ltext lt_StoreDivision,
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
                        decimal _PriceWithTax
                        )
        {
            StoreDivision = lt_StoreDivision.s;
            Item_Name = _Item_Name;
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
            ltext token_ItemSold = token_prefix.AddAtTheEnd(lng.st_Item);
            token = new ItemSoldToken(token_ItemSold,
                                     lt_StoreDivision,
                                    _Item_Name,
                                    _RetailPricePerUnit,
                                    _UnitName,
                                    _RetailPricePerUnitWithDiscount,
                                    _TaxationName,
                                    _dQuantity,
                                    _Discount,
                                    _ExtraDiscount,
                                    _CurrencySymbol,
                                    _TaxationRate,
                                    _TotalDiscount,
                                    _NetPrice,
                                    _TaxPrice,
                                    _PriceWithTax);


    }
}
}
