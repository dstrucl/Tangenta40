﻿using DBConnectionControl40;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace TangentaDB
{
    public static class f_PriceList_Name
    {
        public static bool Get(string Name, ref long Atom_PriceList_Name_ID)
        {

            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            string scond_Name = null;
            string sval_Name = "null";
            if (Name != null)
            {
                string spar_Name = "@par_Name";
                SQL_Parameter par_Name = new SQL_Parameter(spar_Name, SQL_Parameter.eSQL_Parameter.Nvarchar, false, Name);
                lpar.Add(par_Name);
                scond_Name = " Name = " + spar_Name;
                sval_Name = spar_Name;
            }
            else
            {
                scond_Name = "Name is null";
                sval_Name = "null";
            }
            DataTable dt = new DataTable();
            string Err = null;
            dt.Columns.Clear();
            dt.Clear();
            string sql = @"select ID from PriceList_Name where " + scond_Name;
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    Atom_PriceList_Name_ID = (long)dt.Rows[0]["ID"];
                    return true;
                }
                else
                {
                    sql = @"insert into PriceList_Name (Name) values (" + sval_Name + ")";
                    object objretx = null;
                    if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar, ref Atom_PriceList_Name_ID, ref objretx, ref Err, "PriceList_Name"))
                    {
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:f_PriceList_Name:Get:sql=" + sql + "\r\nErr=" + Err);
                        return false;
                    }
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:f_PriceList_Name:Get:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }
    }
}
