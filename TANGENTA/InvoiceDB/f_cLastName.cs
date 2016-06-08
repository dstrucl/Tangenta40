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
    public static class f_cLastName
    {
        public static bool Get(string_v LastName_v, ref long cLastName_ID)
        {
            string Err = null;
            string sql = null;
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            string scond_LastName = null;
            string sval_LastName = "null";
            if (LastName_v != null)
            {
                string spar_LastName = "@par_LastName";
                SQL_Parameter par_LastName = new SQL_Parameter(spar_LastName, SQL_Parameter.eSQL_Parameter.Nvarchar, false, LastName_v.v);
                lpar.Add(par_LastName);
                scond_LastName = "LastName = " + spar_LastName;
                sval_LastName = spar_LastName;
            }
            else
            {
                scond_LastName = "LastName is null";
                sval_LastName = "null";
            }
            DataTable dt = new DataTable();
            dt.Columns.Clear();
            dt.Clear();
            sql = @"select ID from cLastName where " + scond_LastName;
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    cLastName_ID = (long)dt.Rows[0]["ID"];
                    return true;
                }
                else
                {
                    sql = @"insert into cLastName (LastName) values (" + sval_LastName + ")";
                    object objretx = null;
                    if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar, ref cLastName_ID, ref objretx, ref Err, "cLastName"))
                    {
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:f_cLastName:Get:sql=" + sql + "\r\nErr=" + Err);
                        return false;
                    }
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:f_cLastName:Get:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }
    }
}
