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
    public class f_PurchasePrice_Data
    {
        private ID purchasePrice_ID = null;
        public ID PurchasePrice_ID
        {
            get
            {
                if (ID.Validate(purchasePrice_ID))
                {
                    return purchasePrice_ID;
                }
                else
                {
                    return null;
                }
            }
        }

        private decimal_v purchasePricePerUnit_v = null;
        public decimal PurchasePricePerUnit
        {
            get
            {
                if (purchasePricePerUnit_v != null)
                {
                    return purchasePricePerUnit_v.v;
                }
                else
                {
                    return 0;
                }
            }
        }

        private decimal_v discount_v = null;
        public decimal Discount
        {
            get
            {
                if (discount_v != null)
                {
                    return discount_v.v;
                }
                else
                {
                    return 0;
                }
            }
        }

        private DateTime_v purchasePriceDate_v = null;
        public DateTime PurchasePriceDate
        {
            get
            {
                if (purchasePriceDate_v != null)
                {
                    return purchasePriceDate_v.v;
                }
                else
                {
                    return DateTime.MinValue;
                }
            }
        }

        private bool_v priceWithoutVAT_v = null;
        public bool PriceWithoutVAT
        {
            get
            {
                if (priceWithoutVAT_v != null)
                {
                    return priceWithoutVAT_v.v;
                }
                else
                {
                    return true;
                }
            }
        }


        private bool_v m_VATCanNotBeDeducted_v = null;
        public bool VATCanNotBeDeducted
        {
            get
            {
                if (m_VATCanNotBeDeducted_v != null)
                {
                    return m_VATCanNotBeDeducted_v.v;
                }
                else
                {
                    return false;
                }
            }
        }
        public f_Currency_Data Currency_Data = null;
        public f_Taxation_Data Taxation_Data = null;


        public void Set(DataRow dr, f_DocInvoice_ShopC_Item_Source.Col c)
        {
            purchasePrice_ID = tf.set_ID(dr[c.PurchasePrice_ID]);
            Currency_Data = new f_Currency_Data(dr,c);
            Taxation_Data = new f_Taxation_Data(dr,c);
            purchasePricePerUnit_v = tf.set_decimal(dr[c.PurchasePricePerUnit]);
            discount_v = tf.set_decimal(dr[c.PurchasePrice_Discount]);
            priceWithoutVAT_v = tf.set_bool(dr[c.PurchasePriceWithoutVAT]);
            m_VATCanNotBeDeducted_v = tf.set_bool(dr[c.PurchasePriceVATCanNotBeDeducted]);
        }

       
        public f_PurchasePrice_Data(DataRow dr, f_DocInvoice_ShopC_Item_Source.Col c) 
        {
            Set(dr,c);
        }
    }
}
