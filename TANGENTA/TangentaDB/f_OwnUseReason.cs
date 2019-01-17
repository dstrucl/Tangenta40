﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBConnectionControl40;

namespace TangentaDB
{
    public static class f_OwnUseReason
    {
        public static string Get()
        {
            return Environment.MachineName;
        }
        public static bool Get(ref ID OwnUseReason_ID, Transaction transaction)
        {
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            string ComputerName = f_OwnUseReason.Get();
            return f_OwnUseReason.Get(ComputerName, ref OwnUseReason_ID, transaction);
        }

        public static bool Get(string xComputerName, ref ID OwnUseReason_ID, Transaction transaction)
        {
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
        
            string Err = null;
            DataTable dt = new DataTable();

            string scond_ComputerName = null;
            string sval_ComputerName = "null";
            if (xComputerName != null)
            {
                string spar_ComputerName = "@par_Name";
                SQL_Parameter par_ComputerName = new SQL_Parameter(spar_ComputerName, SQL_Parameter.eSQL_Parameter.Nvarchar, false, xComputerName);
                lpar.Add(par_ComputerName);
                scond_ComputerName = "Name = " + spar_ComputerName;
                sval_ComputerName = spar_ComputerName;
            }
            else
            {
                scond_ComputerName = "Name is null";
                sval_ComputerName = "null";
            }

            string sql = @"select ID from OwnUseReason
                                                where " + scond_ComputerName;

            if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    if (OwnUseReason_ID==null)
                    {
                        OwnUseReason_ID = new ID();
                    }
                    OwnUseReason_ID.Set(dt.Rows[0]["ID"]);
                    return true;
                }
                else
                {
                    sql = @"insert into OwnUseReason (Name) values (" + sval_ComputerName + ")";
                    if (transaction.ExecuteNonQuerySQLReturnID(DBSync.DBSync.Con,sql, lpar, ref OwnUseReason_ID,  ref Err, "OwnUseReason"))
                    {
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:f_OwnUseReason:GetName:" + sql + "\r\nErr=" + Err);
                        return false;
                    }
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:f_OwnUseReason:Get:" + sql + "\r\nErr=" + Err);
                return false;
            }
        }
    }
}
