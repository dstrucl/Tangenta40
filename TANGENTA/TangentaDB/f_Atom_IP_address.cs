using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using DBConnectionControl40;

namespace TangentaDB
{
    public static class f_Atom_IP_address
    {
        public static string Get()
        {
            UnicastIPAddressInformation mostSuitableIp = null;

            var networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();

            foreach (var network in networkInterfaces)
            {
                if (network.OperationalStatus != OperationalStatus.Up)
                    continue;

                var properties = network.GetIPProperties();

                if (properties.GatewayAddresses.Count == 0)
                    continue;

                foreach (var address in properties.UnicastAddresses)
                {
                    if (address.Address.AddressFamily != AddressFamily.InterNetwork)
                        continue;

                    if (IPAddress.IsLoopback(address.Address))
                        continue;

                    if (!address.IsDnsEligible)
                    {
                        if (mostSuitableIp == null)
                            mostSuitableIp = address;
                        continue;
                    }

                    // The best IP is the IP got from DHCP server
                    if (address.PrefixOrigin != PrefixOrigin.Dhcp)
                    {
                        if (mostSuitableIp == null || !mostSuitableIp.IsDnsEligible)
                            mostSuitableIp = address;
                        continue;
                    }

                    return address.Address.ToString();
                }
            }

            return mostSuitableIp != null
                ? mostSuitableIp.Address.ToString()
                : "";
        }


        public static bool Get(string xIP_address,ref ID Atom_IP_address_ID, Transaction transaction)
        {
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();

            string Err = null;
            DataTable dt = new DataTable();

            string scond_IP_address = null;
            string sval_IP_address = "null";
            if (xIP_address != null)
            {
                string spar_IP_address = "@par_IP_address";
                SQL_Parameter par_IP_address = new SQL_Parameter(spar_IP_address, SQL_Parameter.eSQL_Parameter.Nvarchar, false, xIP_address);
                lpar.Add(par_IP_address);
                scond_IP_address = "IP_address = " + spar_IP_address;
                sval_IP_address = spar_IP_address;
            }
            else
            {
                scond_IP_address = "IP_address is null";
                sval_IP_address = "null";
            }

            string sql = @"select ID from Atom_IP_address
                                                where " + scond_IP_address;

            if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    if (Atom_IP_address_ID==null)
                    {
                        Atom_IP_address_ID = new ID();
                    }
                    Atom_IP_address_ID.Set(dt.Rows[0]["ID"]);
                    return true;
                }
                else
                {
                    sql = @"insert into Atom_IP_address (IP_address) values (" + sval_IP_address + ")";
                    if (transaction.ExecuteNonQuerySQLReturnID(DBSync.DBSync.Con,sql, lpar, ref Atom_IP_address_ID,  ref Err, "Atom_IP_address"))
                    {
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:f_Atom_IP_address:GetName:" + sql + "\r\nErr=" + Err);
                        return false;
                    }
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:f_Atom_IP_address:Get:" + sql + "\r\nErr=" + Err);
                return false;
            }
        }

        public static bool Get(ref ID Atom_IP_address_ID, Transaction transaction)
        {
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            string IP_address = Get();
            return f_Atom_IP_address.Get(IP_address, ref Atom_IP_address_ID, transaction);
        }
    }
}
