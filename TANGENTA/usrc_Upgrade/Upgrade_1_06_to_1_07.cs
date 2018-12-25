using DBConnectionControl40;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TangentaDB;

namespace UpgradeDB
{
    internal static class Upgrade_1_06_to_1_07
    {
        internal static object UpgradeDB_1_06_to_1_07(object obj, ref string Err)
        {
            Transaction transaction_UpgradeDB_1_06_to_1_07 = new Transaction("UpgradeDB_1_06_to_1_07", DBSync.DBSync.MyTransactionLog_delegates);
            if (DBSync.DBSync.Drop_VIEWs(ref Err, transaction_UpgradeDB_1_06_to_1_07))
            {
                string[] new_tables = new string[] { "doc_page_type", "Language", "doc_type", "doc", "JOURNAL_doc_Type", "JOURNAL_doc" };
                if (DBSync.DBSync.CreateTables(new_tables, ref Err, transaction_UpgradeDB_1_06_to_1_07))
                {
                    if (DBSync.DBSync.Create_VIEWs(transaction_UpgradeDB_1_06_to_1_07))
                    {
                        if (f_doc.InsertDefault(transaction_UpgradeDB_1_06_to_1_07))
                        {
                            if (UpgradeDB_inThread.Set_DataBase_Version("1.07", transaction_UpgradeDB_1_06_to_1_07))
                            {
                                transaction_UpgradeDB_1_06_to_1_07.Commit();
                                return true;
                            }
                        }
                    }
                }
            }
            transaction_UpgradeDB_1_06_to_1_07.Rollback();
            return false;
        }
    }
}
