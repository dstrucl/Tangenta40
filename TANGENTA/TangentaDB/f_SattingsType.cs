using DBConnectionControl40;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TangentaDB
{
    public class f_SattingsType
    {
        public static bool Get(string xSettingsType, ref ID SettingsType_ID)
        {
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();

            string Err = null;
            DataTable dt = new DataTable();

            string scond_SettingsType = null;
            string sval_SettingsType = "null";
            if (xSettingsType != null)
            {
                string spar_SettingsType = "@par_SettingsType";
                SQL_Parameter par_SettingsType = new SQL_Parameter(spar_SettingsType, SQL_Parameter.eSQL_Parameter.Nvarchar, false, xSettingsType);
                lpar.Add(par_SettingsType);
                scond_SettingsType = "Typ = " + spar_SettingsType;
                sval_SettingsType = spar_SettingsType;
            }
            else
            {
                scond_SettingsType = " Typ is null";
                sval_SettingsType = "null";
            }

            string sql = @"select ID from SettingsType
                                                where " + scond_SettingsType;

            if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    if (SettingsType_ID == null)
                    {
                        SettingsType_ID = new ID();
                    }
                    SettingsType_ID.Set(dt.Rows[0]["ID"]);
                    return true;
                }
                else
                {
                    sql = @"insert into SettingsType (Typ) values (" + sval_SettingsType + ")";
                    if (transaction.ExecuteNonQuerySQLReturnID(DBSync.DBSync.Con,sql, lpar, ref SettingsType_ID, ref Err, "SettingsType"))
                    {
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:f_SettingsType:Get:" + sql + "\r\nErr=" + Err);
                        return false;
                    }
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:f_SettingsType:Get:" + sql + "\r\nErr=" + Err);
                return false;
            }
        }

    }
}
