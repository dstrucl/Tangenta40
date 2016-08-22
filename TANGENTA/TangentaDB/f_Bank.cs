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
                long_v Organisation_ID_v,
                ref long_v Bank_ID_v)
        {
            string Err = null;

            string Organisation_ID_v_cond = "Organisation_ID is null";
            string Organisation_ID_v_Value = "null";

            if (Organisation_ID_v != null)
            {
                Organisation_ID_v_Value = Organisation_ID_v.v.ToString();
                Organisation_ID_v_cond = "Organisation_ID = " + Organisation_ID_v.v.ToString();
            }


            string sql_select = "select ID from Bank where " + Organisation_ID_v_cond;
            DataTable dt = new DataTable();
            if (DBSync.DBSync.ReadDataTable(ref dt, sql_select, null, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    if (Bank_ID_v == null)
                    {
                        Bank_ID_v = new long_v();
                    }
                    Bank_ID_v.v = (long)dt.Rows[0]["ID"];
                    return true;
                }
                else
                {
                    string sql_insert = @"insert into Bank (Organisation_ID) values (
                                                                            " + Organisation_ID_v_Value + ")";
                    object oret = null;
                    long Bank_ID = -1;
                    if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql_insert, null, ref Bank_ID, ref oret, ref Err, "Bank"))
                    {
                        if (Bank_ID_v == null)
                        {
                            Bank_ID_v = new long_v();
                        }
                        Bank_ID_v.v = Bank_ID;
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

        public static bool DeleteAll()
        {
            return fs.DeleteAll("Bank");
        }
    }
}
