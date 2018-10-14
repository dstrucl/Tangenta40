#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion
using DBConnectionControl40;
using DBTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TangentaDB
{
    public class Doc_ShopC_Item_Source
    {
        public ID Doc_ShopC_Item_Source_ID = null;
        public ID Doc_ShopC_Item_ID = null;
        public ID Stock_ID = null;
        public decimal dQuantity = 0;
        public decimal ExtraDiscount = 0;
        public decimal RetailPricePerUnit = 0;
        public decimal RetailPrice = 0;
        public decimal RetailPriceWithDiscount = 0;
        public decimal TaxPrice = 0;
        public decimal NetPrice = 0;


        public DateTime_v ExpiryDate_v = null;

        public string_v Item_UniqueName_v = null;

        public string_v StockTakeName_v = null;
        public DateTime_v StockTakeDate_v = null;

        public void Set(string docType, System.Data.DataRow dria)
        {
            Doc_ShopC_Item_ID = tf.set_ID(dria[docType + "_ShopC_Item_ID"]);
            Stock_ID = tf.set_ID(dria["Stock_ID"]);
            //Stock_ImportTime = tf.set_DateTime(dria["Stock_ImportTime"]);
            //Stock_ExpiryDate = tf.set_DateTime(dria["Stock_ExpiryDate"]);
            dQuantity = tf._set_decimal(dria["dQuantity"]);
        }

        internal void GetPrices(decimal taxRate, decimal discount, decimal retailPricePerUnit, ref decimal xRetailPrice, ref decimal xRetailPriceWithDiscount, ref decimal xTaxPrice, ref decimal xNetPrice)
        {
            int decimal_places = 2;
            if (GlobalData.BaseCurrency != null)
            {
                decimal_places = GlobalData.BaseCurrency.DecimalPlaces;
            }
            StaticLib.Func.CalculatePrice(retailPricePerUnit, dQuantity, discount, ExtraDiscount, taxRate,ref xRetailPrice, ref xRetailPriceWithDiscount, ref xTaxPrice, ref xNetPrice, decimal_places);
            this.NetPrice = xNetPrice;
        }
    }
}
