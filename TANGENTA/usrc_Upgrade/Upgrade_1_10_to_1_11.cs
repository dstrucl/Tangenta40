using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UpgradeDB
{
    internal static class Upgrade_1_10_to_1_11
    {
        internal static object UpgradeDB_1_10_to_1_11(object obj, ref string Err)
        {
            if (DBSync.DBSync.Drop_VIEWs(ref Err))
            {
                string sql = null;
                string stbl = "DocInvoice_Notice";
                if (DBSync.DBSync.TableExists(stbl, ref Err))
                {

                    sql = @"PRAGMA foreign_keys = OFF;
                    DROP TABLE " + stbl + @";
                    CREATE TABLE DocInvoice_Notice
                      (
                          'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                           DocInvoice_ID  INTEGER  NOT NULL REFERENCES DocInvoice(ID),
                          'NoticeText' TEXT NULL,
                           DocInvoice_ImageLib_ID  INTEGER  NULL REFERENCES DocInvoice_ImageLib(ID)
                      );
                    PRAGMA foreign_keys = ON;";
                }
                else
                {
                    sql = @"
                    CREATE TABLE DocInvoice_Notice
                      (
                          'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                           DocInvoice_ID  INTEGER  NOT NULL REFERENCES DocInvoice(ID),
                          'NoticeText' TEXT NULL,
                           DocInvoice_ImageLib_ID  INTEGER  NULL REFERENCES DocInvoice_ImageLib(ID)
                          
                      );
                    ";
                }
                if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                {
                    if (DBSync.DBSync.Create_VIEWs())
                    {
                        UpgradeDB_inThread.Set_DataBase_Version("1.11");
                        return true;
                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:usrc_Upgrade:UpgradeDB_1_10_to_1_11:sql = " + sql + "\r\nErr=" + Err);
                    return false;
                }

            }
            return false;
        }
    }
}
