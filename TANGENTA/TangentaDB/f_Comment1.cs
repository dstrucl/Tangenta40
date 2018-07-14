using DBConnectionControl40;
using DBTypes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace TangentaDB
{
    public static class f_Comment1
    {
        public static bool Get(string Comment, ref ID Comment1_ID)
        {
            string Err = null;
            string sql = null;
            Comment1_ID = null;
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            if (Comment == null)
            {
                return true;
            }
            string spar_Comment = "@par_Comment";
            SQL_Parameter par_Comment = new SQL_Parameter(spar_Comment, SQL_Parameter.eSQL_Parameter.Nvarchar, false, Comment);
            lpar.Add(par_Comment);
            string scond_Comment = "Comment = " + spar_Comment;
            string sval_Comment = spar_Comment;

            DataTable dt = new DataTable();
            dt.Columns.Clear();
            dt.Clear();
            sql = @"select ID from Comment1 where " + scond_Comment;
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    if (Comment1_ID==null)
                    {
                        Comment1_ID = new ID();
                    }
                    Comment1_ID.Set(dt.Rows[0]["ID"]);
                    return true;
                }
                else
                {
                    sql = @"insert into Comment1 (Comment) values (" + sval_Comment + ")";
                    if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar, ref Comment1_ID, ref Err, "Comment1"))
                    {
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:f_Comment1:Get:sql=" + sql + "\r\nErr=" + Err);
                        return false;
                    }
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:f_Comment1:Get:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }
    }
}
