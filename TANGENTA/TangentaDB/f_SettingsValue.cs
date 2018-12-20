using DBConnectionControl40;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TangentaDB
{
    public static class f_SettingsValue
    {
        public static bool Get(string xSettingsValue, ref ID SettingsValue_ID, Transaction transaction)
        {
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();

            string Err = null;
            DataTable dt = new DataTable();

            string scond_SettingsValue = null;
            string sval_SettingsValue = "null";
            if (xSettingsValue != null)
            {
                string spar_SettingsValue = "@par_SettingsValue";
                SQL_Parameter par_SettingsValue = new SQL_Parameter(spar_SettingsValue, SQL_Parameter.eSQL_Parameter.Nvarchar, false, xSettingsValue);
                lpar.Add(par_SettingsValue);
                scond_SettingsValue = "SettingsVal = " + spar_SettingsValue;
                sval_SettingsValue = spar_SettingsValue;
            }
            else
            {
                scond_SettingsValue = " SettingsVal is null";
                sval_SettingsValue = "null";
            }

            string sql = @"select ID from SettingsValue
                                                where " + scond_SettingsValue;

            if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    if (SettingsValue_ID == null)
                    {
                        SettingsValue_ID = new ID();
                    }
                    SettingsValue_ID.Set(dt.Rows[0]["ID"]);
                    return true;
                }
                else
                {
                    sql = @"insert into SettingsValue (SettingsVal) values (" + sval_SettingsValue + ")";
                    if (transaction.ExecuteNonQuerySQLReturnID(DBSync.DBSync.Con,sql, lpar, ref SettingsValue_ID, ref Err, "SettingsValue"))
                    {
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:f_SettingsValue:Get:" + sql + "\r\nErr=" + Err);
                        return false;
                    }
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:f_SettingsValue:Get:" + sql + "\r\nErr=" + Err);
                return false;
            }
        }

    }
}
