
using DBConnectionControl40;
using DBTypes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace TangentaDB
{
    public static class f_Atom_Comment1
    {
        public static bool Get(string Comment, ref long_v Atom_Comment1_ID_v)
        {
            string Err = null;
            string sql = null;
            Atom_Comment1_ID_v = null;
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
            sql = @"select ID from Atom_Comment1 where " + scond_Comment;
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    Atom_Comment1_ID_v =tf.set_long(dt.Rows[0]["ID"]);
                    return true;
                }
                else
                {
                    sql = @"insert into Atom_Comment1 (Comment) values (" + sval_Comment + ")";
                    object objretx = null;
                    long Atom_Comment1_ID = -1;
                    if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar, ref Atom_Comment1_ID, ref objretx, ref Err, "Atom_Comment1"))
                    {
                        Atom_Comment1_ID_v = new long_v(Atom_Comment1_ID);
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:f_Atom_Comment1:Get:sql=" + sql + "\r\nErr=" + Err);
                        return false;
                    }
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:f_Atom_Comment1:Get:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }
    }
}
