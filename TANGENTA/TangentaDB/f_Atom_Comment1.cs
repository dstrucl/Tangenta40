
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
        public static bool Get(string Comment, ref ID Atom_Comment1_ID)
        {
            string Err = null;
            string sql = null;
            Atom_Comment1_ID = null;
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
                    if (Atom_Comment1_ID==null)
                    {
                        Atom_Comment1_ID = new ID();
                    }
                    Atom_Comment1_ID.Set(dt.Rows[0]["ID"]);
                    return true;
                }
                else
                {
                    sql = @"insert into Atom_Comment1 (Comment) values (" + sval_Comment + ")";
                    ID xAtom_Comment1_ID = null;
                    if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar, ref xAtom_Comment1_ID, ref Err, "Atom_Comment1"))
                    {
                        if (Atom_Comment1_ID==null)
                        {
                            Atom_Comment1_ID = new ID();
                        }
                        Atom_Comment1_ID.Set(xAtom_Comment1_ID);
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
