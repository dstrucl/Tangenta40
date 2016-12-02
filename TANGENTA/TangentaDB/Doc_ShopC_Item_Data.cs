using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TangentaDB
{
    public class Doc_ShopC_Item_Data
    {
        private long m_DocInvoice_ID = -1;
        public long DocInvoice_ID
        {
            get { return m_DocInvoice_ID; }
        }
        private  long m_DocInvoice_ShopC_Item_ID = -1;
        public long DocInvoice_ShopC_Item_ID
        {
            get { return m_DocInvoice_ShopC_Item_ID; }
        }

        private long m_DocProformaInvoice_ID = -1;
        public long DocProformaInvoice_ID
        {
            get { return m_DocProformaInvoice_ID; }
        }

        private long m_DocProformaInvoice_ShopC_Item_ID = -1;
        public long DocProformaInvoice_ShopC_Item_ID
        {
            get { return m_DocProformaInvoice_ShopC_Item_ID; }
        }

        public Doc_ShopC_Item_Data(long xDocInvoice_ID, long xDocInvoice_ShopC_Item_ID, long xDocProformaInvoice_ID, long xDocProformaInvoice_ShopC_Item_ID)
        {
            this.m_DocInvoice_ID = xDocInvoice_ID;
            this.m_DocInvoice_ShopC_Item_ID = xDocInvoice_ShopC_Item_ID;
            this.m_DocProformaInvoice_ID = xDocProformaInvoice_ID;
            this.m_DocProformaInvoice_ShopC_Item_ID = xDocProformaInvoice_ShopC_Item_ID;
        }
    }
}
