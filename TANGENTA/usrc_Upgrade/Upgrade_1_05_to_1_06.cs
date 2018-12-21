using DBConnectionControl40;
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
            Transaction transaction_UpgradeDB_1_05_to_1_06 = new Transaction("UpgradeDB_1_05_to_1_06");
            //DBSync.DBSync.DB_for_Tangenta
            if (DBSync.DBSync.Drop_VIEWs(ref Err, transaction_UpgradeDB_1_05_to_1_06))
            {
                if (DBSync.DBSync.Create_VIEWs(transaction_UpgradeDB_1_05_to_1_06))
                {
                    if (UpgradeDB_inThread.Set_DataBase_Version("1.06", transaction_UpgradeDB_1_05_to_1_06))
                    {
                        return true;
                    }
                }
            }
            transaction_UpgradeDB_1_05_to_1_06.Rollback();
            return false;
        }

    }
}
