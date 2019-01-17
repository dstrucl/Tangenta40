﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBConnectionControl40;

namespace TangentaDB
{
    public static class f_OwnUseDescription
    {
        public static string Get()
        {
            return Environment.MachineName;
        }
        public static bool Get(ref ID OwnUseDescription_ID, Transaction transaction)
        {
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            string ComputerName = f_OwnUseDescription.Get();
            return f_OwnUseDescription.Get(ComputerName, ref OwnUseDescription_ID, transaction);
        }

        public static bool Get(string xComputerName, ref ID OwnUseDescription_ID, Transaction transaction)
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

            string sql = @"select ID from OwnUseDescription
                                                where " + scond_ComputerName;

            if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    if (OwnUseDescription_ID==null)
                    {
                        OwnUseDescription_ID = new ID();
                    }
                    OwnUseDescription_ID.Set(dt.Rows[0]["ID"]);
                    return true;
                }
                else
                {
                    sql = @"insert into OwnUseDescription (Name) values (" + sval_ComputerName + ")";
                    if (transaction.ExecuteNonQuerySQLReturnID(DBSync.DBSync.Con,sql, lpar, ref OwnUseDescription_ID,  ref Err, "OwnUseDescription"))
                    {
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:f_OwnUseDescription:GetName:" + sql + "\r\nErr=" + Err);
                        return false;
                    }
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:f_OwnUseDescription:Get:" + sql + "\r\nErr=" + Err);
                return false;
            }
        }
    }
}
