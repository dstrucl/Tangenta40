﻿using DBConnectionControl40;
using DBTypes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace TangentaDB
{
    public static class f_Notice
    {
        public static bool Get(string NoticeText, ref long_v Notice_ID_v)
        {
            string Err = null;
            string sql = null;
            Notice_ID_v = null;
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
            sql = @"select ID from Notice where " + scond_NoticeText;
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    Notice_ID_v = tf.set_long(dt.Rows[0]["ID"]);
                    return true;
                }
                else
                {
                    sql = @"insert into Notice (NoticeText) values (" + sval_NoticeText + ")";
                    object objretx = null;
                    long Notice_ID = -1;
                    if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar, ref Notice_ID, ref objretx, ref Err, "Notice"))
                    {
                        Notice_ID_v = new long_v(Notice_ID);
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:f_Notice:Get:sql=" + sql + "\r\nErr=" + Err);
                        return false;
                    }
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:f_Notice:Get:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }

        public static bool GetTable(ref DataTable dt)
        {
            string Err = null;
            string sql = null;

            if (dt == null)
            {
                dt = new DataTable();
            }
            dt.Columns.Clear();
            dt.Clear();
            sql = @"select ID,NoticeText from Notice";
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, null, ref Err))
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
}
