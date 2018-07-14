using DBConnectionControl40;
using DBTypes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TangentaDB
{
    public static class f_cFirstName
    {
        public static bool Get(string_v FirstName_v, ref ID cFirstName_ID)
        {
            string Err = null;
            string sql = null;
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            string scond_FirstName = null;
            string sval_FirstName = "null";
            if (FirstName_v != null)
            {
                string spar_FirstName = "@par_FirstName";
                SQL_Parameter par_FirstName = new SQL_Parameter(spar_FirstName, SQL_Parameter.eSQL_Parameter.Nvarchar, false, FirstName_v.v);
                lpar.Add(par_FirstName);
                scond_FirstName = "FirstName = " + spar_FirstName;
                sval_FirstName = spar_FirstName;
            }
            else
            {
                scond_FirstName = "FirstName is null";
                sval_FirstName = "null";
            }
            DataTable dt = new DataTable();
            dt.Columns.Clear();
            dt.Clear();
            sql = @"select ID from cFirstName where " + scond_FirstName;
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                   if (cFirstName_ID == null)
                   {
                        cFirstName_ID = new ID();
                   }
                   cFirstName_ID.Set(dt.Rows[0]["ID"]);
                   return true;
                }
                else
                {
                    sql = @"insert into cFirstName (FirstName) values (" + sval_FirstName + ")";
                    if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar, ref cFirstName_ID,  ref Err, "cFirstName"))
                    {
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:f_cFirstName:Get:sql=" + sql + "\r\nErr=" + Err);
                        return false;
                    }
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:f_cFirstName:Get:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }
    }
}
