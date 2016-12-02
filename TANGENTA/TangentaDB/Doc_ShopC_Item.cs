using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace TangentaDB
{
    public class Doc_ShopC_Item
    {
        public Doc_ShopC_Item_Data[] adata = null;

        public long Stock_ID = -1;

        public Doc_ShopC_Item(long xStock_ID, DataRow[] drs_DocInvoice, DataRow[] drs_DocProformaInvoice)
        {
            Stock_ID = xStock_ID;
            int iCount1 = drs_DocInvoice.Length;
            int iCount2 = drs_DocProformaInvoice.Length;
            int iCountAll = iCount1 + iCount2;
            if (iCountAll > 0)
            {
                adata = new Doc_ShopC_Item_Data[iCountAll];
                int i = 0;
                while (i< iCount1)
                {
                    adata[i] = new Doc_ShopC_Item_Data((long)drs_DocInvoice[i]["DocInvoice_ID"],
                                                       (long)drs_DocInvoice[i]["ID"],
                                                       -1,
                                                       -1);
                    i++;
                }
                int j = 0;
                while (j < iCount2)
                {
                    adata[i] = new Doc_ShopC_Item_Data(-1,
                                                       -1,
                                                       (long)drs_DocProformaInvoice[j]["DocProformaInvoice_ID"],
                                                       (long)drs_DocProformaInvoice[j]["ID"]);
                    i++;
                    j++;
                }
            }
        }
    }
}
