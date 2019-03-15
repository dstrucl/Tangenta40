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
                    if (xdsciS.Stock_Data.Stock_ID != null)
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
                    if (xdsciS.Stock_Data.Stock_ID == null)
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
                ExtraDiscount,
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
                f_DocInvoice_ShopC_Item_Source.Col c = new f_DocInvoice_ShopC_Item_Source.Col();
                dsciS_list.Clear();
                foreach (DataRow dr in dt.Rows)
                {
                 
                    Doc_ShopC_Item_Source xdsciS = new Doc_ShopC_Item_Source(dr, c);
                   
               
                    dsciS_list.Add(xdsciS);
                }
                return true;
            }
            return false;
        }

        internal bool RemoveSources(string docTyp, Item_Data xdata, Transaction transaction)
        {
           foreach (Doc_ShopC_Item_Source xdsciS in dsciS_list)
           {
                if (ID.Validate(xdsciS.Stock_Data.Stock_ID))
                {
                    if (xdsciS.SendBackToStock(docTyp, xdsciS.dQuantity,xdata, transaction))
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
                    if (!xdsciS.RemoveFactory(docTyp,xdsciS.dQuantity, transaction))
                    {
                        return false;
                    }
                }
           }
            dsciS_list.Clear();
            return true;

        }

        internal bool RemoveStockSources(string docTyp, Item_Data xdata,decimal dQuantity_To_Put_back_inStock, Transaction transaction)
        {
            foreach (Doc_ShopC_Item_Source xdsciS in dsciS_list)
            {
                if (dQuantity_To_Put_back_inStock > 0)
                {
                    if (ID.Validate(xdsciS.Stock_Data.Stock_ID))
                    {
                        if (dQuantity_To_Put_back_inStock > xdsciS.dQuantity)
                        {
                            decimal dQuantityToPutBack2Stock = xdsciS.dQuantity;
                            if (xdsciS.SendBackToStock(docTyp, dQuantityToPutBack2Stock, null, transaction))
                            {
                                
                                dQuantity_To_Put_back_inStock = dQuantity_To_Put_back_inStock - dQuantityToPutBack2Stock;
                               Stock_Data xstd = xdata.Find_Stock_Data(xdsciS.Stock_Data.Stock_ID);
                                if (xstd!=null)
                                {
                                    if (xstd.dQuantity_v==null)
                                    {
                                        xstd.dQuantity_v = new DBTypes.decimal_v(0);
                                    }
                                    xstd.dQuantity_v.v += dQuantityToPutBack2Stock;
                                }
                                else
                                {
                                    LogFile.Error.Show("ERROR:TangentaDB:ShopC_Item_Source_List:RemoveStockSources:1:Can not find Stock_Data in Item_Data!");
                                    return false;
                                }
                                
                            }
                            else
                            {
                                return false;
                            }
                        }
                        else
                        {
                            if (xdsciS.SendBackToStock(docTyp, dQuantity_To_Put_back_inStock, null, transaction))
                            {
                                Stock_Data xstd = xdata.Find_Stock_Data(xdsciS.Stock_Data.Stock_ID);
                                if (xstd != null)
                                {
                                    if (xstd.dQuantity_v == null)
                                    {
                                        xstd.dQuantity_v = new DBTypes.decimal_v(0);
                                    }
                                    xstd.dQuantity_v.v += dQuantity_To_Put_back_inStock;
                                    dQuantity_To_Put_back_inStock = 0;
                                }
                                else
                                {
                                    LogFile.Error.Show("ERROR:TangentaDB:ShopC_Item_Source_List:RemoveStockSources:2:Can not find Stock_Data in Item_Data!");
                                    return false;
                                }
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }
                }
                else
                {
                    break;
                }
            }

            // make list of empty source elements
            List<Doc_ShopC_Item_Source> dsciSl = new List<Doc_ShopC_Item_Source>();
            foreach (Doc_ShopC_Item_Source xdsciS in dsciS_list)
            {
                if (xdsciS.dQuantity==0)
                {
                    dsciSl.Add(xdsciS);
                }
            }

            // purge list of empty source elements
            foreach (Doc_ShopC_Item_Source xdsciS in dsciSl)
            {
                dsciS_list.Remove(xdsciS);
            }

            return true;

        }

        internal void Get(ID Doc_ShopC_Item_ID,Item_Data idata, decimal dQuantity)
        {
            
        }

        internal Doc_ShopC_Item_Source Find(Stock_Data stdx)
        {
            foreach (Doc_ShopC_Item_Source dsciSx in this.dsciS_list)
            {
                if (ID.Validate(dsciSx.Stock_Data.Stock_ID))
                {
                    if (dsciSx.Stock_Data.Stock_ID.Equals(stdx.Stock_ID))
                    {
                        return dsciSx;
                    }
                }
            }
            return null;
        }

        internal Doc_ShopC_Item_Source FindFactory()
        {
            foreach (Doc_ShopC_Item_Source dsciSx in this.dsciS_list)
            {
                if (!ID.Validate(dsciSx.Stock_Data.Stock_ID))
                {
                    return dsciSx;
                }
            }
            return null;
        }

        internal void RemoveFactory_from_list()
        {
            List< Doc_ShopC_Item_Source > dsciSxL = new List<Doc_ShopC_Item_Source>();
            foreach (Doc_ShopC_Item_Source dsciSx in this.dsciS_list)
            {
                if (!ID.Validate(dsciSx.Stock_Data.Stock_ID))
                {
                    dsciSxL.Add(dsciSx);
                }
            }
            foreach (Doc_ShopC_Item_Source dsciSx in dsciSxL)
            {
                dsciS_list.Remove(dsciSx);
            }
        }

        internal void RemoveStock_from_list()
        {
            List<Doc_ShopC_Item_Source> dsciSxL = new List<Doc_ShopC_Item_Source>();
            foreach (Doc_ShopC_Item_Source dsciSx in this.dsciS_list)
            {
                if (ID.Validate(dsciSx.Stock_Data.Stock_ID))
                {
                    dsciSxL.Add(dsciSx);
                }
            }
            foreach (Doc_ShopC_Item_Source dsciSx in dsciSxL)
            {
                dsciS_list.Remove(dsciSx);
            }
        }
    }
}
