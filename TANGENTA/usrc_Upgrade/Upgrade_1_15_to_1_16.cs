using DBConnectionControl40;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UpgradeDB
{
    internal static class Upgrade_1_15_to_1_16
    {

        internal static object UpgradeDB_1_15_to_1_16(object obj, ref string Err)
        {
            Transaction transaction_UpgradeDB_1_15_to_1_16 = new Transaction("UpgradeDB_1_15_to_1_16");
            if (DBSync.DBSync.Drop_VIEWs(ref Err, transaction_UpgradeDB_1_15_to_1_16))
            {
                string sql = null;
                sql = @"
                    ALTER TABLE Invoice ADD COLUMN Invoice_Reference_ID INTEGER NULL;
                    ALTER TABLE Invoice ADD COLUMN Invoice_Reference_Type varchar(25) NULL;
                    ";
                if (transaction_UpgradeDB_1_15_to_1_16.ExecuteNonQuerySQL_NoMultiTrans(DBSync.DBSync.Con,sql, null, ref Err))
                {
                    if (DBSync.DBSync.Create_VIEWs(transaction_UpgradeDB_1_15_to_1_16))
                    {
                        if (UpgradeDB_inThread.Set_DataBase_Version("1.16", transaction_UpgradeDB_1_15_to_1_16))
                        {
                            if (transaction_UpgradeDB_1_15_to_1_16.Commit())
                            {
                                return true;
                            }
                        }
                    }
                }
                else
                {
                    transaction_UpgradeDB_1_15_to_1_16.Rollback();
                    LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_15_to_1_16:sql=" + sql + "\r\nErr=" + Err);
                    return false;
                }
            }
            transaction_UpgradeDB_1_15_to_1_16.Rollback();
            return false;
        }
    }
}
