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
        public static string GetMACAddress()
        {
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            string sMacAddress = null;
            foreach (NetworkInterface adapter in nics)
            {
                if (sMacAddress == String.Empty)// only return MAC Address from first card  
                {
                    //IPInterfaceProperties properties = adapter.GetIPProperties(); Line is not required
                    sMacAddress = adapter.GetPhysicalAddress().ToString();
                }
            } return sMacAddress;
        }

        public static string LocalIPAddress()
        {
            IPHostEntry host;
            string localIP = null;
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    localIP = ip.ToString();
                    break;
                }
            }
            return localIP;
        }

        public static bool Get(ref long Atom_Computer_ID)
        {
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            string ComputerName = Environment.MachineName;
            string UserName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            string MAC_Address = GetMACAddress();
            string IP_Address = GetMACAddress();


            string Err = null;
            DataTable dt = new DataTable();

            string scond_ComputerName = null;
            string sval_ComputerName = "null";
            if (ComputerName!=null)
            {
                string spar_ComputerName ="@par_ComputerName";
                SQL_Parameter par_ComputerName  = new SQL_Parameter(spar_ComputerName,SQL_Parameter.eSQL_Parameter.Nvarchar,false,ComputerName);
                lpar.Add(par_ComputerName);
                scond_ComputerName = "Name = " + spar_ComputerName;
                sval_ComputerName = spar_ComputerName;
            }
            else
            {
                scond_ComputerName = "Name is null";
                sval_ComputerName = "null";
            }

            string scond_UserName = null;
            string sval_UserName = "null";
            if (UserName != null)
            {
                string spar_UserName = "@par_UserName";
                SQL_Parameter par_UserName = new SQL_Parameter(spar_UserName, SQL_Parameter.eSQL_Parameter.Nvarchar, false, UserName);
                lpar.Add(par_UserName);
                scond_UserName = "UserName = " + spar_UserName;
                sval_UserName = spar_UserName;
            }
            else
            {
                scond_UserName = "UserName is null";
                sval_UserName = "null";
            }

            string scond_MAC_Address = null;
            string sval_MAC_Address = "null";
            if (MAC_Address != null)
            {
                string spar_MAC_Address = "@par_MAC_Address";
                SQL_Parameter par_MAC_Address = new SQL_Parameter(spar_MAC_Address, SQL_Parameter.eSQL_Parameter.Nvarchar, false, MAC_Address);
                lpar.Add(par_MAC_Address);
                scond_MAC_Address = "MAC_Address = " + spar_MAC_Address;
                sval_MAC_Address = spar_MAC_Address;
            }
            else
            {
                scond_MAC_Address = "MAC_Address is null";
                sval_MAC_Address = "null";
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
                                                    where (" + scond_ComputerName + ") and (" + scond_UserName + ") and (" + scond_MAC_Address + ") and (" + scond_IP_Address+")";

            if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    Atom_Computer_ID = (long)dt.Rows[0]["ID"];
                    return true;
                }
                else
                {
                    sql = @"insert into Atom_Computer (Name,UserName,MAC_address,IP_address) values (" + sval_ComputerName + "," + sval_UserName + "," + sval_MAC_Address + "," + sval_IP_Address + ")";
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

    }
}
