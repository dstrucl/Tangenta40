using DBConnectionControl40;
using DBTypes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace TangentaDB
{
    public static class f_Bank
    {
        public static bool Get(
                ID Organisation_ID,
                ref ID Bank_ID,
                Transaction transaction)
        {
            string Err = null;

            string Organisation_ID_v_cond = "Organisation_ID is null";
            string Organisation_ID_v_Value = "null";

            if (Organisation_ID != null)
            {
                Organisation_ID_v_Value = Organisation_ID.ToString();
                Organisation_ID_v_cond = "Organisation_ID = " + Organisation_ID.ToString();
            }


            string sql_select = "select ID from Bank where " + Organisation_ID_v_cond;
            DataTable dt = new DataTable();
            if (DBSync.DBSync.ReadDataTable(ref dt, sql_select, null, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    if (Bank_ID == null)
                    {
                        Bank_ID = new ID();
                    }
                    Bank_ID.Set(dt.Rows[0]["ID"]);
                    return true;
                }
                else
                {
                    string sql_insert = @"insert into Bank (Organisation_ID) values (
                                                                            " + Organisation_ID_v_Value + ")";
                    if (transaction.ExecuteNonQuerySQLReturnID(DBSync.DBSync.Con,sql_insert, null, ref Bank_ID,  ref Err, "Bank"))
                    {
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:f_Bank:Get:sql=" + sql_insert + "\r\nErr=" + Err);
                    }
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:f_Bank:Get:sql=" + sql_select + "\r\nErr=" + Err);
            }
            return false;
        }

        public static bool DeleteAll(Transaction transaction)
        {
            return fs.DeleteAll("Bank", transaction);
        }
    }
}
