using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TangentaDB
{
    public class ShopC_Item_Source_List
    {
        public List<Doc_ShopC_Item_Source> dsciS_list = new List<Doc_ShopC_Item_Source>();

        public decimal dQuantity_from_stock
        {
            get
            {
                decimal d = 0;
                foreach (Doc_ShopC_Item_Source xdsciS in dsciS_list)
                {
                  
                    //not draft
                    if (xdsciS.Stock_ID != null)
                    {
                        d += xdsciS.dQuantity;
                    }

                }
                return d;
            }
        }

        public decimal dQuantity_from_factory
        {
            get
            {
                decimal d = 0;
                foreach (Doc_ShopC_Item_Source xdsciS in dsciS_list)
                {
                    if (xdsciS.Stock_ID == null)
                    {
                        d += xdsciS.dQuantity;
                    }
                }
                return d;
            }
        }

        public decimal dQuantity_all
        {
            get
            {
                decimal d = 0;
                foreach (Doc_ShopC_Item_Source dsciSx in dsciS_list)
                {
                    d += dsciSx.dQuantity;
                }
                return d;
            }
        }

        public void Clear()
        {
            dsciS_list.Clear();
        }

        internal void Add(Doc_ShopC_Item_Source dsciS)
        {
            dsciS_list.Add(dsciS);
        }

        public void GetPrices(
                decimal TaxRate,
                decimal Discount,
                decimal ExtraDiscount,
                decimal RetailPricePerUnit,
                ref decimal RetailPrice,
                ref decimal RetailPriceWithDiscount,
                ref decimal TaxPrice,
                ref decimal NetPrice)
        {
          
            foreach (Doc_ShopC_Item_Source dsciSx in dsciS_list )
            {
                decimal xRetailPrice = 0;
                decimal xRetailPriceWithDiscount = 0;
                decimal xTaxPrice = 0;
                decimal xNetPrice = 0;
                dsciSx.GetPrices(
                TaxRate,
                Discount,
                ExtraDiscount,
                RetailPricePerUnit,
                ref xRetailPrice,
                ref xRetailPriceWithDiscount,
                ref xTaxPrice,
                ref xNetPrice);
                RetailPrice += xRetailPrice;
                RetailPricePerUnit += xRetailPriceWithDiscount;
                TaxPrice += xTaxPrice;
                NetPrice += xNetPrice;
            }
        }

        internal decimal RetailPriceWithDiscount(decimal retailPricePerUnit, decimal discount, decimal extraDiscount, decimal taxationRate)
        {
            decimal xRetailPrice = 0;
            decimal xRetailPriceWithDiscount = 0;
            decimal xTaxPrice = 0;
            decimal xNetPrice = 0;

            GetPrices(
                 taxationRate,
                 discount,
                 extraDiscount,
                 retailPricePerUnit,
                ref xRetailPrice,
                ref xRetailPriceWithDiscount,
                ref xTaxPrice,
                ref xNetPrice);

            return xRetailPriceWithDiscount;
        }
    }
}
