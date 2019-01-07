using DBConnectionControl40;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TangentaDB
{
    public static class f_PriceListImportType
    {
        public static ID not_defined_ID =null;
        public static ID PurchasePrices_ID = null;
        public static ID OtherPriceList_ID = null;

        public const string PriceListImportType_TABLE = "PriceListImportType";
       
        public static bool Get(Transaction transaction)
        {
            if (fs.Get_TABLE_TYPE(PriceListImportType_TABLE, lng.s_ImportType_not_defined.s, ref not_defined_ID, transaction))
            {
                if (fs.Get_TABLE_TYPE(PriceListImportType_TABLE, lng.s_ImportType_PurchasePrices.s, ref PurchasePrices_ID, transaction))
                {
                    if (fs.Get_TABLE_TYPE(PriceListImportType_TABLE, lng.s_ImportType_OtherPriceList.s, ref OtherPriceList_ID, transaction))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
