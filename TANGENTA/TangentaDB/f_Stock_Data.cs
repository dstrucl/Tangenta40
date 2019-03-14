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
    public class f_Stock_Data
    {
        private ID stock_id = null;
        private ID purchaseprice_item_id = null;

        private decimal_v dquantity_v = null;
        private DateTime_v expiryDate_v = null;
        private DateTime_v importTime_v = null;
        private string_v desctiption_v = null;
        private DataRow dr;

        public ID Stock_ID
        {
            get
            {
                if (ID.Validate(stock_id))
                {
                    return stock_id;
                }
                else
                {
                    return null;
                }
            }
        }

        public ID PurchasePrice_Item_ID
        {
            get
            {
                if (ID.Validate(purchaseprice_item_id))
                {
                    return purchaseprice_item_id;
                }
                else
                {
                    return null;
                }
            }
        }


        public decimal dQuantity
        {
            get
            {
                if (dquantity_v != null)
                {
                    return dquantity_v.v;
                }
                else
                {
                    return 0;
                }
            }
        }

        public DateTime ExpiryDate
        {
            get
            {
                if (expiryDate_v != null)
                {
                    return expiryDate_v.v;
                }
                else
                {
                    return DateTime.MinValue;
                }
            }
        }

        public DateTime ImportDate
        {
            get
            {
                if (importTime_v != null)
                {
                    return importTime_v.v;
                }
                else
                {
                    return DateTime.MinValue;
                }
            }
        }

        public string Description
        {
            get
            {
                if (desctiption_v != null)
                {
                    return desctiption_v.v;
                }
                else
                {
                    return null;
                }
            }
        }
        public f_Stock_Data(decimal_v xdquantity_v,
                          DateTime_v xexpiryDate_v,
                          DateTime_v ximportTime_v,
                          string_v xdescription_v,
                          ID xstock_id,
                          ID xpurchaseprice_item_id
                         )
        {
            dquantity_v = xdquantity_v;
            expiryDate_v = xexpiryDate_v;
            importTime_v = ximportTime_v;
            desctiption_v = xdescription_v;
            stock_id = xstock_id;
            purchaseprice_item_id = xpurchaseprice_item_id;
        }

        public f_Stock_Data(DataRow xdr)
        {
            this.dr = xdr;
            stock_id = DBTypes.tf.set_ID(dr["Stock_ID"]);
            purchaseprice_item_id = DBTypes.tf.set_ID(dr["PurchasePrice_Item_ID"]);
            expiryDate_v = DBTypes.tf.set_DateTime(dr["ExpiryDate"]);
            importTime_v = DBTypes.tf.set_DateTime(dr["Stock_ImportTime"]);
            dquantity_v = DBTypes.tf.set_decimal(dr["StockQuantity"]);
            desctiption_v = DBTypes.tf.set_string(dr["StockDescription"]);

        }
    }
}
