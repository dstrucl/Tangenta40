using DBConnectionControl40;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TangentaDB
{
    public static class f_PriceListCheckType
    {
        public const string PriceListCheckType_TABLE = "PriceListCheckType";

        public static ID not_defined_ID = null;
        public static ID OnStartupOnEachDay_ID = null;
        public static ID OnStartupOnDayOfWeek_ID = null;
        public static ID OnStartupOnDayOfMonth_ID = null;

        public static bool Get(Transaction transaction)
        {
            if (fs.Get_TABLE_TYPE(PriceListCheckType_TABLE, lng.s_ImportCheck_not_defined.s, ref not_defined_ID, transaction))
            {
                if (fs.Get_TABLE_TYPE(PriceListCheckType_TABLE, lng.s_ImportCheck_OnStartupEachDay.s, ref OnStartupOnEachDay_ID, transaction))
                {
                    if (fs.Get_TABLE_TYPE(PriceListCheckType_TABLE, lng.s_ImportCheck_OnStartupEachWeek.s, ref OnStartupOnDayOfWeek_ID, transaction))
                    {
                        if (fs.Get_TABLE_TYPE(PriceListCheckType_TABLE, lng.s_ImportCheck_OnStartupEachMonth.s, ref OnStartupOnDayOfMonth_ID, transaction))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
    }
}
