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
    public class f_StockTake_Data
    {
        public f_SupplierOrg_Data SupplierOrg_Data = null;
        public f_SupplierPerson_Data SupplierPerson_Data = null;

        private ID stocktake_id = null;
        public ID StockTake_ID
        {
            get
            {
                if (ID.Validate(stocktake_id))
                {
                    return stocktake_id;
                }
                else
                {
                    return null;
                }
            }
        }

        private string_v name_v = null;
        public string Name
        {
            get
            {
                if (name_v != null)
                {
                    return name_v.v;
                }
                else
                {
                    return null;
                }
            }
        }

        private DateTime_v stocktake_date_v = null;
        public DateTime_v StockTake_v
        {
            get
            {
                return stocktake_date_v;
            }
        }

        private decimal_v stockTakePriceTotal_v = null;
        public decimal_v StockTakePriceTotal_v
        {
            get
            {
                return stockTakePriceTotal_v;
            }
        }
        private bool_v stockTakePriceTotalWithVAT_v = null;
        public bool StockTakePriceTotalWithVAT
        {
            get
            {
                if (stockTakePriceTotalWithVAT_v != null)
                {
                    return stockTakePriceTotalWithVAT_v.v;
                }
                else
                {
                    return false;
                }
            }
        }

        private string_v description_v = null;
        public string Description
        {
            get
            {
                if (description_v != null)
                {
                    return description_v.v;
                }
                else
                {
                    return null;
                }
            }
        }


        private bool_v stockTakeDraft_v = null;
        public bool StockTakeDraft
        {
            get
            {
                if (stockTakeDraft_v != null)
                {
                    return stockTakeDraft_v.v;
                }
                else
                {
                    return false;
                }
            }
        }


        public void Set(DataRow dr)
        {
            SupplierOrg_Data = new f_SupplierOrg_Data(dr);
            SupplierPerson_Data = new f_SupplierPerson_Data(dr);
            name_v = tf.set_string(dr["StockTakeName"]);
            stocktake_date_v = tf.set_DateTime(dr["StockTake_Date"]);
            stockTakePriceTotal_v = tf.set_decimal(dr["StockTakePriceTotal"]);
            stockTakePriceTotalWithVAT_v = tf.set_bool(dr["StockTakePriceTotalWithVAT"]);
            description_v = tf.set_string(dr["StockTakeDescription"]);
            stockTakeDraft_v = tf.set_bool(dr["StockTakeDraft"]);
        }

        public f_StockTake_Data(DataRow dr)
        {
            Set(dr);
        }
    }

}
