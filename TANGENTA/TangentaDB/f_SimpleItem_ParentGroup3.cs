using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBConnectionControl40;
using System.Data;

namespace TangentaDB
{
    public static class f_SimpleItem_ParentGroup3
    {
        public static bool Get(string Name, ref long SimpleItem_ParentGroup3_ID)
        {
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            string spar_Name = "@par_Name";
            SQL_Parameter par_Name = new SQL_Parameter(spar_Name, SQL_Parameter.eSQL_Parameter.Nvarchar, false, Name);
            lpar.Add(par_Name);
            string sql = "select ID from SimpleItem_ParentGroup3 where Name = " + spar_Name;
            DataTable dt = new DataTable();
            string Err = null;
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    SimpleItem_ParentGroup3_ID = (long)dt.Rows[0]["ID"];
                    return true;
                }
                else
                {
                    sql = "insert into SimpleItem_ParentGroup3 (Name) values (" + spar_Name + ")";
                    object oret = null;
                    if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar, ref SimpleItem_ParentGroup3_ID, ref oret, ref Err, "SimpleItem_ParentGroup3"))
                    {
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:f_SimpleItem_ParentGroup3:Get:sql=" + sql + "\r\nErr=" + Err);
                        return false;
                    }
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:f_SimpleItem_ParentGroup3:Get:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }
    }
}
