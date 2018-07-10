﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBConnectionControl40;

namespace TangentaDB
{
    public static class f_Atom_MAC_address
    {
        public static bool Get(ref long Atom_MAC_address_ID)
        {
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            string MAC_address = LogFile.LogFile.GetMACAddress();

            string Err = null;
            DataTable dt = new DataTable();

            string scond_MAC_address = null;
            string sval_MAC_address = "null";
            if (MAC_address != null)
            {
                string spar_MAC_address = "@par_MAC_address";
                SQL_Parameter par_MAC_address = new SQL_Parameter(spar_MAC_address, SQL_Parameter.eSQL_Parameter.Nvarchar, false, MAC_address);
                lpar.Add(par_MAC_address);
                scond_MAC_address = "MAC_address = " + spar_MAC_address;
                sval_MAC_address = spar_MAC_address;
            }
            else
            {
                scond_MAC_address = "MAC_address is null";
                sval_MAC_address = "null";
            }

            string sql = @"select ID from Atom_MAC_address
                                                where " + scond_MAC_address;

            if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    Atom_MAC_address_ID = (long)dt.Rows[0]["ID"];
                    return true;
                }
                else
                {
                    sql = @"insert into Atom_MAC_address (MAC_address) values (" + sval_MAC_address + ")";
                    object objretx = null;
                    if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar, ref Atom_MAC_address_ID, ref objretx, ref Err, "Atom_MAC_address"))
                    {
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:f_Atom_MAC_address:GetName:" + sql + "\r\nErr=" + Err);
                        return false;
                    }
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:f_Atom_MAC_address:Get:" + sql + "\r\nErr=" + Err);
                return false;
            }
        }
    }
}