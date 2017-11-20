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
            if (DBSync.DBSync.Drop_VIEWs(ref Err))
            {
                string[] new_tables = new string[] { "Atom_ItemShopA", "Atom_ItemShopA_Image", "DocInvoice_ShopA_Item" };
                if (DBSync.DBSync.CreateTables(new_tables, ref Err))
                {
                    if (DBSync.DBSync.Create_VIEWs())
                    {
                        UpgradeDB_inThread.Set_DataBase_Version("1.14");
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
