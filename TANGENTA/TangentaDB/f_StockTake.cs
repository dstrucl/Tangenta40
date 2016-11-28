using DBTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TangentaDB
{
    public static class f_StockTake
    {
        public static bool Lock(long StockTake_ID)
        {
            if (fs.IDisValid(StockTake_ID))
            {
                string sql = "update StockTake set Draft = 0 where ID = " + StockTake_ID.ToString();
                object ores = null;
                string Err = null;
                if (DBSync.DBSync.ExecuteNonQuerySQL(sql, null, ref ores, ref Err))
                {
                    long_v JOURNAL_StockTake_ID_v = null;
                    TangentaDB.f_JOURNAL_StockTake.Get(StockTake_ID, f_JOURNAL_StockTake.JOURNAL_StockTake_Type_ID_Opened_StockTake_closed, DateTime.Now, ref JOURNAL_StockTake_ID_v);
                    return true;
                }
                else
                {
                    LogFile.Error.Show("ERROR:TangentaDB.fs.cs:Lock:sql=" + sql + "\r\nErr=" + Err);
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:TangentaDB.fs.cs:Lock:stockTake_ID is not valid!");
            }
            return false;
        }

        public static bool UnLock(long StockTake_ID)
        {
            if (fs.IDisValid(StockTake_ID))
            {
                string sql = "update StockTake set Draft = 1 where ID = " + StockTake_ID.ToString();
                object ores = null;
                string Err = null;
                if (DBSync.DBSync.ExecuteNonQuerySQL(sql, null, ref ores, ref Err))
                {
                    long_v JOURNAL_StockTake_ID_v = null;
                    TangentaDB.f_JOURNAL_StockTake.Get(StockTake_ID, f_JOURNAL_StockTake.JOURNAL_StockTake_Type_ID_Closed_StockTake_reopened, DateTime.Now, ref JOURNAL_StockTake_ID_v);
                    return true;
                }
                else
                {
                    LogFile.Error.Show("ERROR:TangentaDB.fs.cs:UnLock:sql=" + sql + "\r\nErr=" + Err);
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:TangentaDB.fs.cs:UnLock:stockTake_ID is not valid!");
            }
            return false;
        }
    }

}
