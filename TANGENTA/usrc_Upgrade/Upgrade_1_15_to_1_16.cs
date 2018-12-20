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
            if (DBSync.DBSync.Drop_VIEWs(ref Err))
            {
                string sql = null;
                sql = @"
                    ALTER TABLE Invoice ADD COLUMN Invoice_Reference_ID INTEGER NULL;
                    ALTER TABLE Invoice ADD COLUMN Invoice_Reference_Type varchar(25) NULL;
                    ";
                if (transaction.ExecuteNonQuerySQL_NoMultiTrans(DBSync.DBSync.Con,sql, null, ref Err))
                {
                    if (DBSync.DBSync.Create_VIEWs())
                    {
                        UpgradeDB_inThread.Set_DataBase_Version("1.16");
                        return true;
                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_15_to_1_16:sql=" + sql + "\r\nErr=" + Err);
                    return false;
                }
            }
            return false;
        }
    }
}
