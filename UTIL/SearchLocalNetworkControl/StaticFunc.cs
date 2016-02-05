#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion
using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace SearchLocalNetwork
{
    public static class StaticFunc
    {
        public static byte[] GetIP(UInt32 ul)
        {
            byte[] b = new byte[4];
            b[0] = (byte)((ul & 0xFF000000) >> 24);
            b[1] = (byte)((ul & 0xFF0000) >> 16);
            b[2] = (byte)((ul & 0xFF00) >> 8);
            b[3] = (byte)((ul & 0xFF));
            return b;
        }

        public static UInt32 GetIPUInt32(byte[] b)
        {
            UInt32 ul;
            ul = b[0];
            ul = ul << 8;
            ul = ul + b[1];
            ul = ul << 8;
            ul = ul + b[2];
            ul = ul << 8;
            ul = ul + b[3];
            return ul;
        }

        public static string GetComputerFromIP(Byte[] b)
        {
            string s = "";
            int i;
            for (i = 0; i < b.Length; i++)
            {
                if (i < 3)
                {
                    s = s + b[i].ToString() + ".";
                }
                else
                {
                    s = s + b[i].ToString();
                }
            }
            return s;
        }

        public static bool isNullIP(Byte[] b)
        {
            int i;
            for (i = 0; i < b.Length; i++)
            {
                if (b[i] != 0)
                {
                    return false;
                }
            }
            return true;
        }

        public static string GetComputerNameFromIP(UInt32 ulAddress)
        {
            IPHostEntry hostInfo;
            String s = StaticFunc.GetComputerFromIP(GetIP(ulAddress));
            IPAddress hostIPAddress = IPAddress.Parse(s);
            try
            {
                hostInfo = Dns.GetHostEntry(hostIPAddress);
                try
                {
                    return hostInfo.HostName;
                }
                catch //(Exception ex)
                {
                    return null;
                }
            }
            catch //(Exception ex)
            {
                return null;
            }
        }
    }
    public class IPAdressFound
    {
        public enum eHostType { GATEWAY, UKNOWN, COMPUTER_DEVICE };
        public UInt32 uInt32Address;
        public string sHostName;
        public eHostType eType;
        public IPAdressFound(eHostType eTyp, UInt32 uiAddress, string s)
        {
            eType = eTyp;
            uInt32Address = uiAddress;
            sHostName = s;
        }
    }
}
