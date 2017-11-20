using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UpgradeDB
{
    internal static class Upgrade_1_05_to_1_06
    {
        internal static object UpgradeDB_1_05_to_1_06(object obj, ref string Err)
        {
            //DBSync.DBSync.DB_for_Tangenta
            if (DBSync.DBSync.Drop_VIEWs(ref Err))
            {
                if (DBSync.DBSync.Create_VIEWs())
                {
                    UpgradeDB_inThread.Set_DataBase_Version("1.06");
                    return true;
                }
            }
            return false;
        }

    }
}
