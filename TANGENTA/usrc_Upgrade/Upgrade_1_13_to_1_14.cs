using DBConnectionControl40;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UpgradeDB
{
    internal static class Upgrade_1_13_to_1_14
    {
        internal static object UpgradeDB_1_13_to_1_14(object obj, ref string Err)
        {
            Transaction transaction_UpgradeDB_1_13_to_1_14 = new Transaction("UpgradeDB_1_13_to_1_14");
            if (DBSync.DBSync.Drop_VIEWs(ref Err, transaction_UpgradeDB_1_13_to_1_14))
            {
                string[] new_tables = new string[] { "Atom_ItemShopA", "Atom_ItemShopA_Image", "DocInvoice_ShopA_Item" };
                if (DBSync.DBSync.CreateTables(new_tables, ref Err, transaction_UpgradeDB_1_13_to_1_14))
                {
                    if (DBSync.DBSync.Create_VIEWs(transaction_UpgradeDB_1_13_to_1_14))
                    {
                        if (UpgradeDB_inThread.Set_DataBase_Version("1.14", transaction_UpgradeDB_1_13_to_1_14))
                        {
                            transaction_UpgradeDB_1_13_to_1_14.Commit();
                            return true;
                        }
                    }
                }
            }
            transaction_UpgradeDB_1_13_to_1_14.Rollback();
            return false;
        }
    }
}
