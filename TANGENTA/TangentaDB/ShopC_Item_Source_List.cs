using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBConnectionControl40;

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

        public void Add(Doc_ShopC_Item_Source dsciS)
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

            foreach (Doc_ShopC_Item_Source dsciSx in dsciS_list)
            {
                decimal xRetailPrice = 0;
                decimal xRetailPriceWithDiscount = 0;
                decimal xTaxPrice = 0;
                decimal xNetPrice = 0;
                dsciSx.GetPrices(
                TaxRate,
                Discount,
                RetailPricePerUnit,
                ref xRetailPrice,
                ref xRetailPriceWithDiscount,
                ref xTaxPrice,
                ref xNetPrice);
                RetailPrice += xRetailPrice;
                RetailPriceWithDiscount += xRetailPriceWithDiscount;
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

        internal decimal TaxPrice(decimal retailPricePerUnit, decimal discount, decimal extraDiscount, decimal taxationRate)
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

            return xTaxPrice;
        }

        internal decimal NetPrice(decimal retailPricePerUnit, decimal discount, decimal extraDiscount, decimal taxationRate)
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

            return xNetPrice;
        }

        internal bool Get(ID doc_ShopC_Item_ID)
        {
            DataTable dt = null;
            if (f_DocInvoice_ShopC_Item_Source.Get(doc_ShopC_Item_ID,ref dt))
            {
                dsciS_list.Clear();
                foreach (DataRow dr in dt.Rows)
                {
                 
                    Doc_ShopC_Item_Source xdsciS = new Doc_ShopC_Item_Source();
                    xdsciS.Stock_ID = DBTypes.tf.set_ID(dt.Rows[0]["Stock_ID"]);
                    xdsciS.dQuantity = DBTypes.tf._set_decimal(dt.Rows[0]["dQuantity"]);
                    xdsciS.RetailPriceWithDiscount = DBTypes.tf._set_decimal(dt.Rows[0]["RetailPriceWithDiscount"]);
                    xdsciS.TaxPrice = DBTypes.tf._set_decimal(dt.Rows[0]["TaxPrice"]);
                    xdsciS.ExpiryDate_v = DBTypes.tf.set_DateTime(dt.Rows[0]["ExpiryDate"]);
                    xdsciS.Item_UniqueName_v = DBTypes.tf.set_string(dt.Rows[0]["Item_UniqueName"]);
                    xdsciS.StockTakeName_v = DBTypes.tf.set_string(dt.Rows[0]["StockTakeName"]);
                    xdsciS.StockTakeDate_v = DBTypes.tf.set_DateTime(dt.Rows[0]["StockTake_Date"]);

                    xdsciS.Doc_ShopC_Item_ID = DBTypes.tf.set_ID(dt.Rows[0]["Doc_ShopC_Item_ID"]);
                    xdsciS.Doc_ShopC_Item_Source_ID = DBTypes.tf.set_ID(dt.Rows[0]["Doc_ShopC_Item_Source_ID"]);
               
                    dsciS_list.Add(xdsciS);
                }
                return true;
            }
            return false;
        }

        internal bool RemoveSources(string docTyp, Item_Data xdata)
        {
           foreach (Doc_ShopC_Item_Source xdsciS in dsciS_list)
           {
                if (ID.Validate(xdsciS.Stock_ID))
                {
                    if (xdsciS.SendBackToStock(docTyp, xdsciS.dQuantity,xdata))
                    {

                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    //this is factory_resource
                    if (!xdsciS.RemoveFactory(docTyp,xdsciS.dQuantity))
                    {
                        return false;
                    }
                }
           }
            dsciS_list.Clear();
            return true;

        }

        internal void Get(ID Doc_ShopC_Item_ID,List<Stock_Data> stock_Data_List, decimal dQuantity)
        {
            throw new NotImplementedException();
        }
    }
}
