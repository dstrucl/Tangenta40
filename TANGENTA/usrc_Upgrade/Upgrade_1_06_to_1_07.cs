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
            if (DBSync.DBSync.Drop_VIEWs(ref Err))
            {
                string[] new_tables = new string[] { "doc_page_type", "Language", "doc_type", "doc", "JOURNAL_doc_Type", "JOURNAL_doc" };
                if (DBSync.DBSync.CreateTables(new_tables, ref Err))
                {
                    if (DBSync.DBSync.Create_VIEWs())
                    {
                        if (f_doc.InsertDefault())
                        {
                            UpgradeDB_inThread.Set_DataBase_Version("1.07");
                            return true;
                        }
                    }
                }
            }
            return false;
        }
    }
}
