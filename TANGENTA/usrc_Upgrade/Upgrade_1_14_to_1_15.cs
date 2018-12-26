using DBConnectionControl40;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UpgradeDB
{
    internal static class Upgrade_1_14_to_1_15
    {
        internal static object UpgradeDB_1_14_to_1_15(object obj, ref string Err)
        {
            Transaction transaction_UpgradeDB_1_14_to_1_15 = DBSync.DBSync.NewTransaction("UpgradeDB_1_14_to_1_15");

            if (DBSync.DBSync.Drop_VIEWs(ref Err, transaction_UpgradeDB_1_14_to_1_15))
            {
                string sql = null;
                sql = @"
                        CREATE TABLE Stock_backup
                        (
                        'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                        'ImportTime' DATETIME NOT NULL,
                        'dQuantity' DECIMAL(10,5) NOT NULL,
                        'ExpiryDate' DATETIME NULL,
                        PurchasePrice_Item_ID  INTEGER  NOT NULL REFERENCES PurchasePrice_Item(ID),
                        Stock_AddressLevel1_ID  INTEGER  NULL REFERENCES Stock_AddressLevel1(ID),
                        'Description' varchar(2000) NULL
                        )
                ";
                if (transaction_UpgradeDB_1_14_to_1_15.ExecuteNonQuerySQL_NoMultiTrans(DBSync.DBSync.Con,sql, null, ref Err))
                {
                    sql = @"INSERT INTO Stock_backup (ImportTime,
						 dQuantity,
						ExpiryDate,
						PurchasePrice_Item_ID,
						Stock_AddressLevel1_ID,
						Description)
						SELECT 
						ImportTime,
						 dQuantity,
						ExpiryDate,
						PurchasePrice_Item_ID,
						Stock_AddressLevel1_ID,
						Description 
						FROM Stock";
                    if (transaction_UpgradeDB_1_14_to_1_15.ExecuteNonQuerySQL_NoMultiTrans(DBSync.DBSync.Con,sql, null, ref Err))
                    {
                        sql = @"PRAGMA foreign_keys = OFF;
                        DROP TABLE Stock;
                        ALTER TABLE Stock_backup RENAME TO Stock;
                        PRAGMA foreign_keys = ON;";
                        if (transaction_UpgradeDB_1_14_to_1_15.ExecuteNonQuerySQL_NoMultiTrans(DBSync.DBSync.Con,sql, null, ref Err))
                        {
                            string[] new_tables = new string[] { "FVI_SLO_SalesBookInvoice" };
                            if (DBSync.DBSync.CreateTables(new_tables, ref Err, transaction_UpgradeDB_1_14_to_1_15))
                            {
                                if (DBSync.DBSync.Create_VIEWs(transaction_UpgradeDB_1_14_to_1_15))
                                {
                                    if (UpgradeDB_inThread.Set_DataBase_Version("1.15", transaction_UpgradeDB_1_14_to_1_15))
                                    {
                                        if (transaction_UpgradeDB_1_14_to_1_15.Commit())
                                        {
                                            return true;
                                        }
                                        else
                                        {
                                            return false;
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            transaction_UpgradeDB_1_14_to_1_15.Rollback();
                            LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_07_to_1_08_Change_Table_Atom_Person:sql=" + sql + "\r\nErr=" + Err);
                            return false;
                        }
                    }
                    else
                    {
                        transaction_UpgradeDB_1_14_to_1_15.Rollback();
                        LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_07_to_1_08_Change_Table_Atom_Person:sql=" + sql + "\r\nErr=" + Err);
                        return false;
                    }
                }
                else
                {
                    transaction_UpgradeDB_1_14_to_1_15.Rollback();
                    LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_07_to_1_08_Change_Table_Person:sql=" + sql + "\r\nErr=" + Err);
                    return false;
                }
            }
            transaction_UpgradeDB_1_14_to_1_15.Rollback();
            return false;
        }
    }
}
