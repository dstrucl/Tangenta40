using DBConnectionControl40;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace TangentaDB
{
    public static class f_StockTakeCostName
    {
        public static bool Get(string Name, ref long ID)
        {

            string Err = null;
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            string spar_Name = "@par_Name";
            SQL_Parameter par = new SQL_Parameter(spar_Name, SQL_Parameter.eSQL_Parameter.Nvarchar, false, Name);
            lpar.Add(par);

            string sql = "select ID from StockTakeCostName where Name =" + spar_Name;
            DataTable dt = new DataTable();
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    ID = (long)dt.Rows[0]["ID"];
                    return true;
                }
                else
                {
                    sql = "insert into StockTakeCostName (Name)values(" + spar_Name + ")";
                    object oret = null;
                    if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar, ref ID, ref oret, ref Err, "StockTakeCostName"))
                    {
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:TangentaDB:f_StocTakeCostName.cs:Get:sql=" + sql + "\r\nErr=" + Err);
                    }
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:TangentaDB:f_StocTakeCostName.cs:Get:sql=" + sql + "\r\nErr=" + Err);
            }
            return false;
        }

        public static bool ReadDataTable(ref DataTable dt)
        {

            string Err = null;
            if (dt==null)
            {
                dt = new DataTable();
            }
            dt.Rows.Clear();
            string sql = "select ID,Name from StockTakeCostName";
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, ref Err))
            {
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:TangentaDB:f_StocTakeCostName.cs:ReadDataTable:sql=" + sql + "\r\nErr=" + Err);
            }
            return false;
        }
    }
}