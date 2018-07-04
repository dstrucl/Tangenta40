#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion
using DBConnectionControl40;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TangentaDB
{
    public static class f_Atom_Computer
    {

        public static string GetLocalIpAddress()
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


        public static bool Get(ref long Atom_Computer_ID)
        {
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            long Atom_ComputerName_ID = -1;
            long Atom_ComputerUsername_ID = -1;
            long Atom_MAC_address_ID = -1;
            string IP_Address = GetLocalIpAddress();


            string Err = null;
            DataTable dt = new DataTable();

            if (f_Atom_ComputerName.Get(ref Atom_ComputerName_ID))
            {
                string scond_Atom_ComputerName_ID = null;
                string sval_Atom_ComputerName_ID = "null";
                if (Atom_ComputerName_ID >= 0)
                {
                    string spar_Atom_ComputerName_ID = "@par_ComputerName";
                    SQL_Parameter par_Atom_ComputerName_ID = new SQL_Parameter(spar_Atom_ComputerName_ID, SQL_Parameter.eSQL_Parameter.Bigint, false, Atom_ComputerName_ID);
                    lpar.Add(par_Atom_ComputerName_ID);
                    scond_Atom_ComputerName_ID = "Atom_ComputerName_ID = " + spar_Atom_ComputerName_ID;
                    sval_Atom_ComputerName_ID = spar_Atom_ComputerName_ID;
                }
                else
                {
                    scond_Atom_ComputerName_ID = "Atom_ComputerName_ID is null";
                    sval_Atom_ComputerName_ID = "null";
                }

                if (f_Atom_ComputerUsername.Get(ref Atom_ComputerUsername_ID))
                {
                    string scond_Atom_ComputerUsername_ID = null;
                    string sval_Atom_ComputerUsername_ID = "null";
                    if (Atom_ComputerUsername_ID >= 0)
                    {
                        string spar_Atom_ComputerUsername_ID = "@par_Atom_ComputerUsername_ID";
                        SQL_Parameter par_Atom_ComputerUsername_ID = new SQL_Parameter(spar_Atom_ComputerUsername_ID, SQL_Parameter.eSQL_Parameter.Bigint, false, Atom_ComputerUsername_ID);
                        lpar.Add(par_Atom_ComputerUsername_ID);
                        scond_Atom_ComputerUsername_ID = "Atom_ComputerUsername_ID = " + spar_Atom_ComputerUsername_ID;
                        sval_Atom_ComputerUsername_ID = spar_Atom_ComputerUsername_ID;
                    }
                    else
                    {
                        scond_Atom_ComputerUsername_ID = "Atom_ComputerUsername_ID is null";
                        sval_Atom_ComputerUsername_ID = "null";
                    }

                    if (f_Atom_MAC_address.Get(ref Atom_MAC_address_ID))
                    {
                        string scond_Atom_MAC_address_ID = null;
                        string sval_Atom_MAC_address_ID = "null";
                        if (Atom_MAC_address_ID >= 0)
                        {
                            string spar_Atom_MAC_address_ID = "@par_Atom_MAC_address_ID";
                            SQL_Parameter par_Atom_MAC_address_ID = new SQL_Parameter(spar_Atom_MAC_address_ID, SQL_Parameter.eSQL_Parameter.Bigint, false, Atom_MAC_address_ID);
                            lpar.Add(par_Atom_MAC_address_ID);
                            scond_Atom_MAC_address_ID = "Atom_MAC_address_ID = " + spar_Atom_MAC_address_ID;
                            sval_Atom_MAC_address_ID = spar_Atom_MAC_address_ID;
                        }
                        else
                        {
                            scond_Atom_MAC_address_ID = "Atom_MAC_address_ID is null";
                            sval_Atom_MAC_address_ID = "null";
                        }

                        string scond_IP_Address = null;
                        string sval_IP_Address = "null";
                        if (IP_Address != null)
                        {
                            string spar_IP_Address = "@par_IP_Address";
                            SQL_Parameter par_IP_Address = new SQL_Parameter(spar_IP_Address, SQL_Parameter.eSQL_Parameter.Nvarchar, false, IP_Address);
                            lpar.Add(par_IP_Address);
                            scond_IP_Address = "IP_Address = " + spar_IP_Address;
                            sval_IP_Address = spar_IP_Address;
                        }
                        else
                        {
                            scond_IP_Address = "IP_Address is null";
                            sval_IP_Address = "null";
                        }

                        string sql = @"select ID from Atom_Computer
                                                                where (" + scond_Atom_ComputerName_ID + ") and (" + scond_Atom_ComputerUsername_ID + ") and (" + scond_Atom_MAC_address_ID + ") and (" + scond_IP_Address + ")";

                        if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
                        {
                            if (dt.Rows.Count > 0)
                            {
                                Atom_Computer_ID = (long)dt.Rows[0]["ID"];
                                return true;
                            }
                            else
                            {
                                sql = @"insert into Atom_Computer (Atom_ComputerName_ID,Atom_ComputerUsername_ID,Atom_MAC_address_ID,IP_address) values (" + sval_Atom_ComputerName_ID + "," + sval_Atom_ComputerUsername_ID + "," + sval_Atom_MAC_address_ID + "," + sval_IP_Address + ")";
                                object objretx = null;
                                if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar, ref Atom_Computer_ID, ref objretx, ref Err, "Atom_Computer"))
                                {
                                    return true;
                                }
                                else
                                {
                                    LogFile.Error.Show("ERROR:f_Atom_Computer:Get:" + sql + "\r\nErr=" + Err);
                                    return false;
                                }
                            }
                        }
                        else
                        {
                            LogFile.Error.Show("ERROR:f_Atom_Computer:Get:" + sql + "\r\nErr=" + Err);
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
