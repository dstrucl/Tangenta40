using DBConnectionControl40;
using DBTypes;
using System.Data;

namespace UpgradeDB
{




    internal static class Upgrade_1_29_to_1_30
    {
        private static CashierActivityList cashierActivityList = new CashierActivityList();

        internal static object UpgradeDB_1_29_to_1_30(object obj, ref string Err)
        {
            Transaction transaction_UpgradeDB_1_29_to_1_30 = DBSync.DBSync.NewTransaction("UpgradeDB_1_29_to_1_30");
            cashierActivityList.Clear();
            if (DBSync.DBSync.Drop_VIEWs(ref Err, transaction_UpgradeDB_1_29_to_1_30))
            {
                string[] new_tables = new string[] {
                                        "ConsumptionType",
                                        "Consumption",
                                        "Consumption_ShopC_Item",
                                        "Consumption_ShopC_Item_Source",
                                        "ItemComponent",
                                        "ItemAssembled",
                                    };

                if (!DBSync.DBSync.CreateTables(new_tables, ref Err, transaction_UpgradeDB_1_29_to_1_30))
                {
                    transaction_UpgradeDB_1_29_to_1_30.Rollback();
                    return false;
                }

                if (DBSync.DBSync.Create_VIEWs(transaction_UpgradeDB_1_29_to_1_30))
                {
                    if (UpgradeDB_inThread.Set_DataBase_Version("1.30", transaction_UpgradeDB_1_29_to_1_30))
                    {
                        transaction_UpgradeDB_1_29_to_1_30.Commit();
                        return true;
                    }
                    else
                    {
                        transaction_UpgradeDB_1_29_to_1_30.Rollback();
                        return false;
                    }
                }
                else
                {
                    transaction_UpgradeDB_1_29_to_1_30.Rollback();
                    return false;
                }
            }
            else
            {
                transaction_UpgradeDB_1_29_to_1_30.Rollback();
                return false;
            }
        }
    }
}
