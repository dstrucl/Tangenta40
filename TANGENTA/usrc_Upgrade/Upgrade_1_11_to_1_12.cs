using DBConnectionControl40;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UpgradeDB
{
    internal static class Upgrade_1_11_to_1_12
    {
        internal static object UpgradeDB_1_11_to_1_12(object obj, ref string Err)
        {
            Transaction transaction_UpgradeDB_1_11_to_1_12 = new Transaction("UpgradeDB_1_11_to_1_12");
            if (DBSync.DBSync.Drop_VIEWs(ref Err, transaction_UpgradeDB_1_11_to_1_12))
            {
                string sql = null;
                string stbl = "DocInvoice_Notice";
                if (DBSync.DBSync.TableExists(stbl, ref Err))
                {

                    sql = @"PRAGMA foreign_keys = OFF;
                    DROP TABLE " + stbl + @";
                    CREATE TABLE Notice
                      (
                          'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                          'Name' varchar(264) NOT NULL,
                          'NoticeText' TEXT NOT NULL,
                          'Description' varchar(2000) NULL
                      );

                    CREATE TABLE DocInvoice_Notice
                      (
                          'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                           DocInvoice_ID  INTEGER  NOT NULL REFERENCES DocInvoice(ID),
                           Notice_ID  INTEGER  NOT NULL REFERENCES Notice(ID),
                           DocInvoice_ImageLib_ID  INTEGER  NULL REFERENCES DocInvoice_ImageLib(ID)
                      );
                    PRAGMA foreign_keys = ON;";
                }
                else
                {
                    sql = @"
                    CREATE TABLE Notice
                      (
                          'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                          'Name' varchar(264) NOT NULL,
                          'NoticeText' TEXT NOT NULL,
                          'Description' varchar(2000) NULL
                      );

                    CREATE TABLE DocInvoice_Notice
                      (
                          'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                           DocInvoice_ID  INTEGER  NOT NULL REFERENCES DocInvoice(ID),
                           Notice_ID  INTEGER  NOT NULL REFERENCES Notice(ID),
                           DocInvoice_ImageLib_ID  INTEGER  NULL REFERENCES DocInvoice_ImageLib(ID)
                      );
                    ";
                }
                if (transaction_UpgradeDB_1_11_to_1_12.ExecuteNonQuerySQL_NoMultiTrans(DBSync.DBSync.Con,sql, null, ref Err))
                {
                    if (DBSync.DBSync.Create_VIEWs(transaction_UpgradeDB_1_11_to_1_12))
                    {
                        if (UpgradeDB_inThread.Set_DataBase_Version("1.12", transaction_UpgradeDB_1_11_to_1_12))
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    transaction_UpgradeDB_1_11_to_1_12.Rollback();
                    LogFile.Error.Show("ERROR:usrc_Upgrade:UpgradeDB_1_08_to_1_09:sql = " + sql + "\r\nErr=" + Err);
                    return false;
                }

            }
            transaction_UpgradeDB_1_11_to_1_12.Rollback();
            return false;
        }
    }
}
