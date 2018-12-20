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
    public static class f_StornoName
    {
        public static bool Get(string stornoName, ref ID cStornoName_ID, Transaction transaction)
        {
            string Err = null;
            string sql = null;
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            string scond_StornoName = null;
            string sval_StornoName = "null";
            if (stornoName != null)
            {
                string spar_StornoName = "@par_StornoName";
                SQL_Parameter par_StornoName = new SQL_Parameter(spar_StornoName, SQL_Parameter.eSQL_Parameter.Nvarchar, false, stornoName);
                lpar.Add(par_StornoName);
                scond_StornoName = "Name = " + spar_StornoName;
                sval_StornoName = spar_StornoName;
            }
            else
            {
                scond_StornoName = "Name is null";
                sval_StornoName = "null";
            }
            DataTable dt = new DataTable();
            dt.Columns.Clear();
            dt.Clear();
            sql = @"select ID from StornoName where " + scond_StornoName;
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                   if (cStornoName_ID == null)
                   {
                        cStornoName_ID = new ID();
                   }
                   cStornoName_ID.Set(dt.Rows[0]["ID"]);
                   return true;
                }
                else
                {
                    sql = @"insert into StornoName (Name) values (" + sval_StornoName + ")";
                    if (transaction.ExecuteNonQuerySQLReturnID(DBSync.DBSync.Con,sql, lpar, ref cStornoName_ID,  ref Err, "cStornoName"))
                    {
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:f_StornoName:Get:sql=" + sql + "\r\nErr=" + Err);
                        return false;
                    }
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:f_StornoName:Get:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }
    }
}
