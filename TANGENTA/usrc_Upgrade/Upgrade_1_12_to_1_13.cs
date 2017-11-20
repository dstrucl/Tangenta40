using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UpgradeDB
{
    internal static class Upgrade_1_12_to_1_13
    {
        internal static object UpgradeDB_1_12_to_1_13(object obj, ref string Err)
        {
            if (DBSync.DBSync.Drop_VIEWs(ref Err))
            {
                string sql = null;
                string stbl = "FVI_SLO_Response";
                if (DBSync.DBSync.TableExists(stbl, ref Err))
                {

                    sql = @"
                    DROP TABLE " + stbl + @";
                    CREATE TABLE FVI_SLO_Response
                      (
                      'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                       Invoice_ID  INTEGER  NOT NULL REFERENCES Invoice(ID),
                      'MessageID' varchar(45) NULL,
                      'UniqueInvoiceID' varchar(45) NULL,
                      'BarCodeValue' varchar(64) NULL,
                      'Response_DateTime' DATETIME NULL
                      )
                    ";
                }
                else
                {
                    sql = @"
                    CREATE TABLE FVI_SLO_Response
                      (
                      'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                       Invoice_ID  INTEGER  NOT NULL REFERENCES Invoice(ID),
                      'MessageID' varchar(45) NULL,
                      'UniqueInvoiceID' varchar(45) NULL,
                      'BarCodeValue' varchar(64) NULL,
                      'Response_DateTime' DATETIME NULL
                      )
                    ";
                }
                if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                {
                    if (DBSync.DBSync.Create_VIEWs())
                    {
                        UpgradeDB_inThread.Set_DataBase_Version("1.13");
                        return true;
                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:usrc_Upgrade:UpgradeDB_1_08_to_1_09:sql = " + sql + "\r\nErr=" + Err);
                    return false;
                }

            }
            return false;
        }

    }
}
