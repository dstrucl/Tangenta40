using DBConnectionControl40;
using DBTypes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TangentaDB
{
    public class f_PurchasePrice_Item_Data
    {
        public ID Item_ID = null;
        public ID PurchasePrice_ID = null;
        public ID StockTake_ID = null;

        public f_PurchasePrice_Data PurchasePrice_Data = null;
        public f_StockTake_Data StockTake_Data = null;

        public f_PurchasePrice_Item_Data(DataRow dr, f_DocInvoice_ShopC_Item_Source.Col c)
        {
            Item_ID = tf.set_ID(dr[c.Item_ID]);
            PurchasePrice_ID = tf.set_ID(dr[c.PurchasePrice_ID]);
            StockTake_ID = tf.set_ID(dr[c.StockTake_ID]);
            PurchasePrice_Data = new f_PurchasePrice_Data(dr, c);
            StockTake_Data = new f_StockTake_Data(dr, c);

        }
    }
}
