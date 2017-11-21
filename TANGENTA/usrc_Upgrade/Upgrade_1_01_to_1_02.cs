using CodeTables;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using TangentaTableClass;

namespace UpgradeDB
{
    internal static class Upgrade_1_01_to_1_02
    {
        internal static Old_tables_1_04_to_1_05 m_Old_tables_1_04_to_1_05 = null;
        internal static UpgradeDB_inThread.eUpgrade m_eUpgrade = UpgradeDB_inThread.eUpgrade.none;

        private static List<TableDataItem> TableDataItem_List = new List<TableDataItem>();
        private static Database_Upgrade_WindowsForm_Thread wfp_ui_thread = null;
        internal static object UpgradeDB_1_01_to_1_02(object obj, ref string Err)
        {
            wfp_ui_thread = new Database_Upgrade_WindowsForm_Thread();
            wfp_ui_thread.Start();

            List<DataTable> dt_List = new List<DataTable>();
            SQLTable tbl = DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(Price_Item));
            wfp_ui_thread.Message("$$$" + lng.s_UpgradeDatabase.s + " 1.01 -> 1.02");
            wfp_ui_thread.Message(lng.s_ReadTable.s + tbl.TableName);
            SQLTable xtbl = new SQLTable(tbl);
            xtbl.CreateTableTree(DBSync.DBSync.DB_for_Tangenta.m_DBTables.items);
            TableDataItem dt_Price_Item = new TableDataItem(xtbl, ref dt_List, null, ref Err);
            if (Err != null)
            {

                wfp_ui_thread.End();
                LogFile.Error.Show("ERROR:usrc_Upgrade:UpgradeDB_1_01_to_1_02:TableName=" + tbl.TableName + ";Err=" + Err);
                return false;
            }
            TableDataItem_List.Add(dt_Price_Item);

            tbl = DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(Price_SimpleItem));
            wfp_ui_thread.Message(lng.s_ReadTable.s + tbl.TableName);
            xtbl = new SQLTable(tbl);
            xtbl.CreateTableTree(DBSync.DBSync.DB_for_Tangenta.m_DBTables.items);
            TableDataItem dt_Price_SimpleItem = new TableDataItem(xtbl, ref dt_List, null, ref Err);
            if (Err != null)
            {
                wfp_ui_thread.End();
                LogFile.Error.Show("ERROR:usrc_Upgrade:UpgradeDB_1_01_to_1_02:TableName=" + tbl.TableName + ";Err=" + Err);
                return false;
            }
            TableDataItem_List.Add(dt_Price_SimpleItem);

            tbl = DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(OrganisationAccount));
            wfp_ui_thread.Message(lng.s_ReadTable.s + tbl.TableName);
            xtbl = new SQLTable(tbl);
            xtbl.CreateTableTree(DBSync.DBSync.DB_for_Tangenta.m_DBTables.items);
            TableDataItem dt_OrganisationAccount = new TableDataItem(xtbl, ref dt_List, null, ref Err);
            if (Err != null)
            {
                wfp_ui_thread.End();
                LogFile.Error.Show("ERROR:usrc_Upgrade:UpgradeDB_1_01_to_1_02:TableName=" + tbl.TableName + ";Err=" + Err);
                return false;
            }
            TableDataItem_List.Add(dt_OrganisationAccount);


            wfp_ui_thread.Message(lng.s_BackupOfExistingDatabase.s + DBSync.DBSync.DataBase + " -> " + DBSync.DBSync.DataBase_BackupTemp);

            if (DBSync.DBSync.DB_for_Tangenta.DataBase_Make_BackupTemp())
            {
                if (DBSync.DBSync.DB_for_Tangenta.DataBase_Delete())
                {
                    if (DBSync.DBSync.DB_for_Tangenta.DataBase_Create())
                    {
                        wfp_ui_thread.Message(lng.s_ImportData.s);
                        if (Write_TableDataItem_List(m_eUpgrade, m_Old_tables_1_04_to_1_05))
                        {
                            UpgradeDB_inThread.Set_DataBase_Version("1.02");
                        }
                    }
                }
            }
            wfp_ui_thread.End();
            return true;
        }

        private static bool Write_TableDataItem_List(UpgradeDB_inThread.eUpgrade eUpgr, Old_tables_1_04_to_1_05 m_Old_tables_1_04_to_1_05)
        {
            foreach (TableDataItem tdi in TableDataItem_List)
            {
                if (!tdi.Write2DB(wfp_ui_thread, eUpgr, m_Old_tables_1_04_to_1_05))
                {
                    return false;
                }
            }
            return true;
        }

    }
}
