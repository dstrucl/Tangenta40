using DBConnectionControl40;
using DBTypes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace TangentaDB
{
    public static class f_Atom_Notice
    {
        public static bool Get(string NoticeText, ref ID Atom_Notice_ID,
                               Transaction transaction
                              )
        {
            string Err = null;
            string sql = null;
            Atom_Notice_ID = null;
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            if (NoticeText == null)
            {
                return true;
            }
            string spar_NoticeText = "@par_NoticeText";
            SQL_Parameter par_NoticeText = new SQL_Parameter(spar_NoticeText, SQL_Parameter.eSQL_Parameter.Nvarchar, false, NoticeText);
            lpar.Add(par_NoticeText);
            string scond_NoticeText = "NoticeText = " + spar_NoticeText;
            string sval_NoticeText = spar_NoticeText;

            DataTable dt = new DataTable();
            dt.Columns.Clear();
            dt.Clear();
            sql = @"select ID from Atom_Notice where " + scond_NoticeText;
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    if (Atom_Notice_ID==null)
                    {
                        Atom_Notice_ID = new ID();
                    }
                    Atom_Notice_ID.Set(dt.Rows[0]["ID"]);
                    return true;
                }
                else
                {
                    sql = @"insert into Atom_Notice (NoticeText) values (" + sval_NoticeText + ")";
                    if (transaction.ExecuteNonQuerySQLReturnID(DBSync.DBSync.Con,sql, lpar, ref Atom_Notice_ID,  ref Err, "Atom_Notice"))
                    {
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:f_Atom_Notice:Get:sql=" + sql + "\r\nErr=" + Err);
                        return false;
                    }
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:f_Atom_Notice:Get:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }
    }
}
