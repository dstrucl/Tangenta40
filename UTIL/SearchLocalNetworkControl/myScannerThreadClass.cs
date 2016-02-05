#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Windows.Forms;
using System.Threading;
//using System.Threading.Tasks;
//using System.Diagnostics;

namespace SearchLocalNetwork
{
    public class ScannerThreadParam
    {
        public UInt32 ulStartAddress;
        public UInt32 ulEndAddress;
        public UInt16 ui16StartPort;
        public UInt16 ui16EndPort;
        public int CheckPortTimeout;
        public int PingTimeout;
        public bool bUsePing;
        public bool bPortRange;
        public bool bCheckPort;
        public SearchLocalNetwork UsrCtrl_SearchMySQL;

        public ScannerThreadParam(UInt32 ulstrtAddress, UInt32 ulEAddress, UInt16 StartPort, UInt16 EndPort, bool bUsePng, int pngTimeout, int chkPortTimeout, bool bScanPortRange, bool bchkPort, SearchLocalNetwork ctrl)
        {
            ulStartAddress = ulstrtAddress;
            ulEndAddress = ulEAddress;
            ui16StartPort = StartPort;
            ui16EndPort = EndPort;
            bUsePing = bUsePng;
            PingTimeout = pngTimeout;
            UsrCtrl_SearchMySQL = ctrl;
            CheckPortTimeout = chkPortTimeout;
            bPortRange = bScanPortRange;
            bCheckPort = bchkPort;

        }
    }

    public  class myScannerThreadClass
    {
//        public bool bUseConnectionPing = true;
        public bool bSend = false;
        static int PingTimeout = 3000;
        public enum eMessage { NO_MSG, MSG_STOP_SEARCHING, MSG_EXIT_THREAD };
        public List<eMessage> MessageList = new List<eMessage>();
        public List<ComputerDataFound> MessageListData = new List<ComputerDataFound>();
        public List<UInt32> MessageDoneList = new List<UInt32>();
        private bool bSearchFinished = false;
        SearchLocalNetwork usrSearchLocalNetwork = null;

        public  Mutex mutexMessageBoxScanner = new Mutex(false, "mutexMessageBoxScanner ");

        public  Thread ScannerThread = null;

        public bool StartThread(UInt32 ulStartAddress, UInt32 ulEndAddress, UInt16 ui16StartPort, UInt16 ui16EndPort,bool bUsePing, 
                                                       int iPingTimeout, 
                                                       int iCheckPortTimoeut,
                                                       bool bPortRange,
                                                       bool bCheckPorts,
                                                       SearchLocalNetwork pCtrl)
        {
                usrSearchLocalNetwork = pCtrl;
                ScannerThread = new Thread(ScanLocalNetwork);
                ScannerThreadParam scp = new ScannerThreadParam(ulStartAddress, ulEndAddress, ui16StartPort, ui16EndPort, bUsePing, iPingTimeout, iCheckPortTimoeut, bPortRange, bCheckPorts, pCtrl);
                ScannerThread.Start(scp);
                return true;
        }


        public  bool GetMessage(ref eMessage eMsg)
        {
            if (usrSearchLocalNetwork.mutexMessageBox.WaitOne())
            {
                bool bRes = false;
                if (MessageList.Count > 0)
                {
                    eMsg = MessageList[0];
                    MessageList.RemoveAt(0);
                    bRes = true;
                }
                else
                {
                    bRes = false;
                }
                usrSearchLocalNetwork.mutexMessageBox.ReleaseMutex();
                return bRes;
            }
            else
            {
                return false;
            }

        }

        public  bool SendMessage(UInt32 ui)
        {
            if (mutexMessageBoxScanner.WaitOne(100))
            {
                MessageDoneList.Add(ui);
                mutexMessageBoxScanner.ReleaseMutex();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool GetMessageSearchFinished()
        {
            bool bRes = false; ;
            if (mutexMessageBoxScanner.WaitOne(2000))
            {
                bRes = bSearchFinished;
                mutexMessageBoxScanner.ReleaseMutex();
            }
            return bRes;
        }


        public bool SendMessageSearchFinished()
        {
            if (mutexMessageBoxScanner.WaitOne(100))
            {
                bSearchFinished = true;
                mutexMessageBoxScanner.ReleaseMutex();
                return true;
            }
            else
            {
                return false;
            }
        }
        
        public  bool SendMessage(ComputerDataFound cmpData)
        {
            if (mutexMessageBoxScanner.WaitOne(100))
            {
                MessageListData.Add(cmpData);
                mutexMessageBoxScanner.ReleaseMutex();
                return true;
            }
            else
            {
                return false;
            }
        }



        public  bool PingComputer(byte[] bIP)
        {
            bool result = false;
            Ping p = null;
            try
            {
                string s = "http://" + StaticFunc.GetComputerFromIP(bIP);

                Uri url = new Uri(s);
                string pingurl = string.Format("{0}", url.Host);
                string host = pingurl;

                p = new Ping();
                PingReply reply = p.Send(host, PingTimeout);
                if (reply.Status == IPStatus.Success)
                {
                    p.Dispose();
                    return true;
                }
                p.Dispose();
            }
            catch (Exception Ex)
            {
                if (p != null)
                    p.Dispose();
               MessageBox.Show(Ex.Message, "ERROR");
            }
            return result;
        }

       public  void ScanLocalNetwork(Object data)
        {
            // UInt32 ulStartAddress,UInt32 ulEndAddress,bool bShowAll,Form_SearchMySQL_servers Form
            if (dbg.bDebugPrint) dbg.print("void ScanLocalNetwork(Object data)");

            UInt32 ulAddress;
            if (data.GetType() == typeof(ScannerThreadParam))
            {
                ScannerThreadParam scp = (ScannerThreadParam)data;
                PingTimeout = scp.PingTimeout;
                if (dbg.bDebugPrint) dbg.print("for (ulAddress = " + StaticFunc.GetComputerFromIP(StaticFunc.GetIP(scp.ulStartAddress)) + "; ulAddress <= " + StaticFunc.GetComputerFromIP(StaticFunc.GetIP(scp.ulEndAddress)) + "; ulAddress++)");

                int xDisplay = 0;
                for (ulAddress = scp.ulStartAddress; ulAddress <= scp.ulEndAddress; ulAddress++)
                {
                    if (xDisplay >= 10)
                    {
                        xDisplay = 0;
                    }

                    if (dbg.bDebugPrint) dbg.print("   ulAddress = " + StaticFunc.GetComputerFromIP(StaticFunc.GetIP(ulAddress)));
                    eMessage eMsg = eMessage.NO_MSG;
                    if (GetMessage(ref  eMsg))
                    {
                        if (eMsg == eMessage.MSG_STOP_SEARCHING)
                        {
                            if (dbg.bDebugPrint) dbg.print("eMsg == eMessage.MSG_STOP_SEARCHING");
                            //Debug.Print("\n(eMsg == Form_SearchMySQL_servers.eMessage.MSG_END_THREAD)");
                            break;
                        }
                    }
                    if (scp.bUsePing)
                    {


                        if (dbg.bDebugPrint) dbg.print("PingComputer(StaticFunc.GetIP("+StaticFunc.GetComputerFromIP(StaticFunc.GetIP(ulAddress)) +")");
                        if (PingComputer(StaticFunc.GetIP(ulAddress)))
                        {
                            if (scp.bCheckPort)
                            {
                                if (dbg.bDebugPrint) dbg.print("scp.bCheckPort= true");
                                UInt16 ui16Port;
                                for (ui16Port = scp.ui16StartPort; ui16Port <= scp.ui16EndPort; ui16Port++)
                                {
                                    //if (xDisplay == 0)
                                    //{
                                    //    //while (!SendMessage("Check Port " + StaticFunc.GetComputerFromIP(StaticFunc.GetIP(ulAddress)) + ":" + ui16Port.ToString()))
                                    //    //{
                                    //    //}
                                    //    while (!SendMessage(HowMuchDone(scp.ulStartAddress, ulAddress, scp.ulEndAddress)))
                                    //    {
                                    //    }
                                    //}
                                    //Debug.Print("Check Port " + StaticFunc.GetComputerFromIP(StaticFunc.GetIP(ulAddress)));
                                    string sMySqlServerVersion = null;
                                    //Debug.Print("\n(eMsg == Form_SearchMySQL_servers.eMessage.MSG_END_THREAD)");
                                    if (CheckPort(StaticFunc.GetComputerFromIP(StaticFunc.GetIP(ulAddress)), (int)ui16Port, ref sMySqlServerVersion, scp.CheckPortTimeout))
                                    {
                                        ComputerDataFound cmpData = new ComputerDataFound();
                                        cmpData.IpAddress = ulAddress;
                                        cmpData.Port = ui16Port;
                                        cmpData.sHostName = StaticFunc.GetComputerNameFromIP(ulAddress);
                                        cmpData.sMySQLVersion = sMySqlServerVersion;
                                        cmpData.bMySQLVersion = true;
                                        if (dbg.bDebugPrint) dbg.print("while (!SendMessage(cmpData)) MySql" + sMySqlServerVersion);
                                        while (!SendMessage(cmpData))
                                        {

                                        }
                                    }
                                    else
                                    {
                                        ComputerDataFound cmpData = new ComputerDataFound();
                                        cmpData.Port = ui16Port;
                                        cmpData.IpAddress = ulAddress;
                                        cmpData.sHostName = StaticFunc.GetComputerNameFromIP(ulAddress);
                                        cmpData.bMySQLVersion = false;
                                        if (dbg.bDebugPrint) dbg.print("while (!SendMessage(cmpData))");
                                        while (!SendMessage(cmpData))
                                        {

                                        }
                                    }
                                    if (!scp.bPortRange)
                                    {
                                        break;
                                    }
                                }
                            }
                            else
                            { // Only Ping
                                if (dbg.bDebugPrint) dbg.print("Only Ping");
                                ComputerDataFound cmpData = new ComputerDataFound();
                                cmpData.IpAddress = ulAddress;
                                cmpData.Port = 0xFFFF;
                                cmpData.sHostName = StaticFunc.GetComputerNameFromIP(ulAddress);
                                cmpData.sMySQLVersion = "";
                                cmpData.bMySQLVersion = false;
                                if (dbg.bDebugPrint) dbg.print("Only Ping while (!SendMessage(cmpData))");
                                while (!SendMessage(cmpData))
                                {
                                }
                            }
                        }
                    }
                    //else if (bUseConnectionPing)
                    //{
                    //    MySql.Data.MySqlClient.MySqlConnection Conn = new MySql.Data.MySqlClient.MySqlConnection(


                    //}
                    else
                    {
                        UInt16 ui16Port;
                        if (dbg.bDebugPrint) dbg.print(" while (!SendMessage( Check Port + StaticFunc.GetComputerFromIP(StaticFunc.GetIP(ulAddress)) + : + ui16Port.ToString()))");
                        for (ui16Port = scp.ui16StartPort; ui16Port <= scp.ui16EndPort; ui16Port++)
                        {
                            //Debug.Print("Check Port " + StaticFunc.GetComputerFromIP(StaticFunc.GetIP(ulAddress)));
                            string sMySqlServerVersion = null;
                            //Debug.Print("\n(eMsg == Form_SearchMySQL_servers.eMessage.MSG_END_THREAD)");
                            if (CheckPort(StaticFunc.GetComputerFromIP(StaticFunc.GetIP(ulAddress)), (int)ui16Port, ref sMySqlServerVersion, scp.CheckPortTimeout))
                            {
                                ComputerDataFound cmpData = new ComputerDataFound();
                                cmpData.IpAddress = ulAddress;
                                cmpData.Port = ui16Port;
                                cmpData.sHostName = StaticFunc.GetComputerNameFromIP(ulAddress);
                                cmpData.sMySQLVersion = sMySqlServerVersion;
                                cmpData.bMySQLVersion = true;
                                if (dbg.bDebugPrint) dbg.print(" while (!SendMessage(cmpData))");
                                while (!SendMessage(cmpData))
                                {

                                }
                            }
                            if (!scp.bPortRange)
                            {
                                break;
                            }

                        }
                        //Debug.Print("Check Port End" + StaticFunc.GetComputerFromIP(StaticFunc.GetIP(ulAddress)));
                    }
                    xDisplay++;
                    while (!SendMessage(1))
                    {
                    }
                }
            }
            //Debug.Print("\nExit Thread");
            if (dbg.bDebugPrint) dbg.print(" while (!SendMessageSearchFinished())");
            while (!SendMessageSearchFinished())
            {

            }

            if (dbg.bDebugPrint) dbg.print("while (!GetMassageExitThread())");
            while (!GetMassageExitThread())
            {
            }
            if (dbg.bDebugPrint) dbg.print("THREAD EXIT  THREAD EXIT THREAD EXIT THREAD EXIT THREAD EXIT THREAD EXIT!");
        }
        private bool GetMassageExitThread()
        {
            eMessage eMsg = eMessage.NO_MSG;
            if (GetMessage(ref  eMsg))
            {
                if (eMsg == eMessage.MSG_EXIT_THREAD)
                {
                    //Debug.Print("\n(eMsg == Form_SearchMySQL_servers.eMessage.MSG_END_THREAD)");
                    return true;
                }
            }
            return false;
        }
        private  bool ParseMySqlServerHandshakeInitialisationPacket(Byte[] data, int DataLength, ref string MySqlVersion)
        {
            if (DataLength >= 51)
            {
                if (data.Length >= DataLength)
                {
                    MySqlPacketHeader PacketHeader = new MySqlPacketHeader();
                    MySqlHandshakeInitializationPacket HandshakeInitializationPacket = new MySqlHandshakeInitializationPacket();
                    PacketHeader.PacketLength = data[2] * 256 + data[1] * 256 + data[0];
                    PacketHeader.PacketNumber = data[3];
                    HandshakeInitializationPacket.ProtocolVersion = data[4];
                    int i = 5;
                    HandshakeInitializationPacket.ServerVersion = "";
                    while ((i < DataLength) && (data[i] != 0))
                    {
                        HandshakeInitializationPacket.ServerVersion += (char)data[i];
                        i++;
                    }

                    if (HandshakeInitializationPacket.ProtocolVersion == 255) // MySQL has blocked this computer
                    {
                        MySqlVersion = HandshakeInitializationPacket.ServerVersion;
                        return true;
                    }

                    i++;
                    MySqlVersion = HandshakeInitializationPacket.ServerVersion;
                    HandshakeInitializationPacket.thread_id = data[i + 3] * 256 + data[i + 2] * 256 + data[i + 1] * 256 + data[i];
                    if (data[i + 12] == 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }


        private  bool CheckPort(string server, Int32 port, ref   String MySqlVersion, int timeout)
        {

            try
            {
                

                TcpClient tcp = new TcpClient();
                TaskThread Task = new TaskThread();
                if (!Task.Connect(tcp, server, port, timeout))
                {
                    return false;
                }

                NetworkStream stream = tcp.GetStream();

                int i = 0;
                while (tcp.Available == 0)
                {
                    System.Threading.Thread.Sleep(10);
                    i++;
                    if (i > 10)
                        break;
                }

                if (tcp.Available > 0)
                {
                    long datalength = tcp.Available;
                    Byte[] data = new Byte[datalength];
                    int l = stream.Read(data, 0, (int)datalength);
                    if (ParseMySqlServerHandshakeInitialisationPacket(data, (int)datalength, ref MySqlVersion))
                    {
                        stream.Close();
                        tcp.Close();
                        return true;
                    }
                    else
                    {
                        stream.Close();
                        tcp.Close();
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch //(Exception ex)
            {
                return false;
            }

        }

        public class MySqlPacketHeader
        {
            public int PacketLength = 0;
            public byte PacketNumber = 0;
        }

        public class MySqlHandshakeInitializationPacket
        {
            public byte ProtocolVersion;
            public string ServerVersion;
            public long thread_id;
            public byte[] scramble_buff = new byte[8];
            public byte filler1; //allways 0x00
            public short server_capabilities;
            public byte server_language;
            public short server_status;
            public short server_capabilities_upper_bytes;
            public byte length_of_the_scramble;
            public byte[] filler2 = new byte[10]; //allways 0x00
            public byte[] rest_of_the_plugin_provided_data = new byte[12];
            public byte ZeroByte;
        }
    }


    public class ComputerDataFound
    {
        public int MessageSentCount = 1;
        public int MessageReceiveCount = 0;
        public UInt32 IpAddress = 0;
        public UInt16 Port = 0;
        public bool bPortOpened = false;
        public string sHostName = "";
        public string sMySQLVersion = "";
        public bool bMySQLVersion = false;

        internal void Dispose()
        {
            throw new NotImplementedException();
        }
    }

    public static class ShowProcessData
    {
        public static Mutex mutexShowProcess = new Mutex(false, "mutexShowProcess ");
        public static UInt32 IpAddress = 0;
        public static UInt16 Port = 0;
    }
}
