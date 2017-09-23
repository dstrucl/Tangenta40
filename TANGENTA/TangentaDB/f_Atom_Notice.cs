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
        public static bool Get(string NoticeText, ref long_v Atom_Notice_ID_v)
        {
            string Err = null;
            string sql = null;
            Atom_Notice_ID_v = null;
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
                    Atom_Notice_ID_v =tf.set_long(dt.Rows[0]["ID"]);
                    return true;
                }
                else
                {
                    sql = @"insert into Atom_Notice (NoticeText) values (" + sval_NoticeText + ")";
                    object objretx = null;
                    long Atom_Notice_ID = -1;
                    if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar, ref Atom_Notice_ID, ref objretx, ref Err, "Atom_Notice"))
                    {
                        Atom_Notice_ID_v = new long_v(Atom_Notice_ID);
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
