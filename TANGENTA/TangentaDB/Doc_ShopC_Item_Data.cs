using DBConnectionControl40;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TangentaDB
{
    public class Doc_ShopC_Item_Data
    {
        private ID m_DocInvoice_ID = null;
        public ID DocInvoice_ID
        {
            get { return m_DocInvoice_ID; }
        }
        private ID m_DocInvoice_ShopC_Item_ID = null;
        public ID DocInvoice_ShopC_Item_ID
        {
            get { return m_DocInvoice_ShopC_Item_ID; }
        }

        private ID m_DocProformaInvoice_ID = null;
        public ID DocProformaInvoice_ID
        {
            get { return m_DocProformaInvoice_ID; }
        }

        private ID m_DocProformaInvoice_ShopC_Item_ID = null;
        public ID DocProformaInvoice_ShopC_Item_ID
        {
            get { return m_DocProformaInvoice_ShopC_Item_ID; }
        }

        public Doc_ShopC_Item_Data(ID xDocInvoice_ID, ID xDocInvoice_ShopC_Item_ID, ID xDocProformaInvoice_ID, ID xDocProformaInvoice_ShopC_Item_ID)
        {
            this.m_DocInvoice_ID = xDocInvoice_ID;
            this.m_DocInvoice_ShopC_Item_ID = xDocInvoice_ShopC_Item_ID;
            this.m_DocProformaInvoice_ID = xDocProformaInvoice_ID;
            this.m_DocProformaInvoice_ShopC_Item_ID = xDocProformaInvoice_ShopC_Item_ID;
        }
    }
}
