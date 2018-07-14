using DBConnectionControl40;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace TangentaDB
{
    public static class f_StockTakeCostDescription
    {
        public static bool Get(string Description, ref ID ID)
        {

            string Err = null;
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            string spar_Description = "@par_Description";
            SQL_Parameter par = new SQL_Parameter(spar_Description, SQL_Parameter.eSQL_Parameter.Nvarchar, false, Description);
            lpar.Add(par);

            string sql = "select ID from StockTakeCostDescription where Description =" + spar_Description;
            DataTable dt = new DataTable();
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    if (ID==null)
                    {
                        ID = new ID();
                    }
                    ID.Set(dt.Rows[0]["ID"]);
                    return true;
                }
                else
                {
                    sql = "insert into StockTakeCostDescription (Description)values(" + spar_Description + ")";
                    if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar, ref ID, ref Err, "StockTakeCostDescription"))
                    {
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:TangentaDB:f_StocTakeCostDescription.cs:Get:sql=" + sql + "\r\nErr=" + Err);
                    }
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:TangentaDB:f_StocTakeCostDescription.cs:Get:sql=" + sql + "\r\nErr=" + Err);
            }
            return false;
        }
    }
}
