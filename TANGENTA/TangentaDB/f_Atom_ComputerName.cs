﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBConnectionControl40;

namespace TangentaDB
{
    public static class f_Atom_ComputerName
    {
        public static bool Get(ref long Atom_ComputerName_ID)
        {
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            string ComputerName = Environment.MachineName;

            string Err = null;
            DataTable dt = new DataTable();

            string scond_ComputerName = null;
            string sval_ComputerName = "null";
            if (ComputerName != null)
            {
                string spar_ComputerName = "@par_ComputerName";
                SQL_Parameter par_ComputerName = new SQL_Parameter(spar_ComputerName, SQL_Parameter.eSQL_Parameter.Nvarchar, false, ComputerName);
                lpar.Add(par_ComputerName);
                scond_ComputerName = "Name = " + spar_ComputerName;
                sval_ComputerName = spar_ComputerName;
            }
            else
            {
                scond_ComputerName = "Name is null";
                sval_ComputerName = "null";
            }

            string sql = @"select ID from Atom_ComputerName
                                                where " + scond_ComputerName;

            if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    Atom_ComputerName_ID = (long)dt.Rows[0]["ID"];
                    return true;
                }
                else
                {
                    sql = @"insert into Atom_ComputerName (Name) values (" + sval_ComputerName+ ")";
                    object objretx = null;
                    if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar, ref Atom_ComputerName_ID, ref objretx, ref Err, "Atom_ComputerName"))
                    {
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:f_Atom_ComputerName:GetName:" + sql + "\r\nErr=" + Err);
                        return false;
                    }
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:f_Atom_ComputerName:Get:" + sql + "\r\nErr=" + Err);
                return false;
            }
        }
    }
}