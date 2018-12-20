using System;
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
        public static string Get()
        {
            return LogFile.LogFile.GetMACAddress();
        }

        public static bool Get(ref ID Atom_MAC_address_ID)
        {
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            string MAC_address = f_Atom_MAC_address.Get();
            return f_Atom_MAC_address.Get(MAC_address, ref Atom_MAC_address_ID);
        }

        public static bool Get(string xMAC_address,ref ID Atom_MAC_address_ID)
        {
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();

            string Err = null;
            DataTable dt = new DataTable();

            string scond_MAC_address = null;
            string sval_MAC_address = "null";
            if (xMAC_address != null)
            {
                string spar_MAC_address = "@par_MAC_address";
                SQL_Parameter par_MAC_address = new SQL_Parameter(spar_MAC_address, SQL_Parameter.eSQL_Parameter.Nvarchar, false, xMAC_address);
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
                    if (Atom_MAC_address_ID == null)
                    {
                        Atom_MAC_address_ID = new ID();
                    }
                    Atom_MAC_address_ID.Set(dt.Rows[0]["ID"]);
                    return true;
                }
                else
                {
                    sql = @"insert into Atom_MAC_address (MAC_address) values (" + sval_MAC_address + ")";
                    if (transaction.ExecuteNonQuerySQLReturnID(DBSync.DBSync.Con,sql, lpar, ref Atom_MAC_address_ID, ref Err, "Atom_MAC_address"))
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
