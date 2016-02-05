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

namespace InvoiceDB
{
    public class Return_to_shop_shelf_data
    {
        public string sql_update_stock;
        public long stock_id;
        public decimal dQuantity_from_basket_to_stock;

        public Return_to_shop_shelf_data(string sql_update_stock, long stock_id, decimal dQuantity_from_basket_to_stock)
        {
            // TODO: Complete member initialization
            this.sql_update_stock = sql_update_stock;
            this.stock_id = stock_id;
            this.dQuantity_from_basket_to_stock = dQuantity_from_basket_to_stock;
        }
    }
}
