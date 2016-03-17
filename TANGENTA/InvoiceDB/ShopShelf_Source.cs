#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion
using DBTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceDB
{
    public class ShopShelf_Source
    {
        public List<Stock_Data> Stock_Data_List = new List<Stock_Data>();

        public decimal dQuantity_all
        {
            get
            {
                decimal d = 0;
                foreach (Stock_Data stock in Stock_Data_List)
                {
                    if (stock.Stock_ID != null)
                    {
                        if (stock.dQuantity_from_stock != null)
                        {
                            d += stock.dQuantity_from_stock.v;
                        }
                    }
                    else
                    {
                        if (stock.dQuantity_from_factory != null)
                        {
                            d += stock.dQuantity_from_factory.v;
                        }
                    }
                }
                return d;
            }
        }

        public decimal dQuantity_from_stock
        {
            get
            {
                decimal d = 0;
                foreach (Stock_Data stock in Stock_Data_List)
                {
                    if (stock.Stock_ID != null)
                    {
                        d += stock.dQuantity_from_stock.v;
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
                foreach (Stock_Data stock in Stock_Data_List)
                {
                    if (stock.Stock_ID == null)
                    {
                        d += stock.dQuantity_from_factory.v;
                    }
                }
                return d;
            }
        }

        public void Clear()
        {
            Stock_Data_List.Clear();
        }

        private static bool IsNull_Stock_ExpiryDate(Stock_Data z)
        {
            if (z == null)
            {
                return true;
            }
            else
            {
                if (z.Stock_ExpiryDate == null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        private static int Compare_Stock_ExpiryDate(Stock_Data x, Stock_Data y)
        {
            if (IsNull_Stock_ExpiryDate(x))
            {
                if (IsNull_Stock_ExpiryDate(y))
                {
                    // If x is null and y is null, they're
                    // equal. 
                    return 0;
                }
                else
                {
                    // If x is null and y is not null, y
                    // is greater. 
                    return -1;
                }
            }
            else
            {
                // If x is not null...
                //
                if (IsNull_Stock_ExpiryDate(y))
                // ...and y is null, x is greater.
                {
                    return 1;
                }
                else
                {
                    // ...and y is not null, compare the 
                    // lengths of the two strings.
                    //
                    int retval = x.Stock_ExpiryDate.v.CompareTo(y.Stock_ExpiryDate.v);
                    return retval;
                }
            }

        }


        public void Add_Stock_Data(Item_Data xItem_Data, decimal xFactoryQuantity,decimal xStockQuantity,  bool b_from_factory)
        {
            if (b_from_factory)
            {
                Stock_Data stock_data = new Stock_Data();
                if (stock_data.dQuantity == null)
                {
                    stock_data.dQuantity = new decimal_v();
                }
                stock_data.dQuantity.v = xFactoryQuantity;
                Stock_Data_List.Add(stock_data);
            }
            else
            {
                decimal dquantity = xStockQuantity;
                xItem_Data.Stock_Data_List.Sort((x, y) => Compare_Stock_ExpiryDate(x,y));
                foreach (Stock_Data sd in xItem_Data.Stock_Data_List)
                {
                    if (dquantity > 0)
                    {
                        if (sd.dQuantity_from_stock != null)
                        {
                            Stock_Data stock_data = new Stock_Data();
                            if (dquantity > sd.dQuantity_from_stock.v)
                            {
                                dquantity -= sd.dQuantity_from_stock.v;
                                if (stock_data.dQuantity == null)
                                {
                                    stock_data.dQuantity = new decimal_v();
                                }
                                stock_data.dQuantity.v = sd.dQuantity_from_stock.v;
                                sd.dQuantity.v = 0;
                                if (stock_data.dQuantity_New_in_Stock == null)
                                {
                                    stock_data.dQuantity_New_in_Stock = new decimal_v();
                                }
                                stock_data.dQuantity_New_in_Stock.v = 0;
                                stock_data.Stock_ID = new long_v();
                                stock_data.Stock_ID.v = sd.Stock_ID.v;
                                Stock_Data_List.Add(stock_data);
                            }
                            else
                            {
                                if (stock_data.dQuantity_from_stock == null)
                                {
                                    stock_data.dQuantity = new decimal_v();
                                }
                                stock_data.dQuantity.v = dquantity;
                                sd.dQuantity.v -= dquantity;
                                if (stock_data.dQuantity_New_in_Stock == null)
                                {
                                    stock_data.dQuantity_New_in_Stock = new decimal_v();
                                }
                                stock_data.dQuantity_New_in_Stock.v = sd.dQuantity.v;
                                stock_data.Stock_ID = new long_v();
                                stock_data.Stock_ID.v = sd.Stock_ID.v;
                                dquantity = 0;
                                Stock_Data_List.Add(stock_data);
                            }
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }
    }
}
