#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Net.NetworkInformation;
using System.Net;
using System.Net.Sockets;
using System.Diagnostics;
using System.Collections;


namespace SearchLocalNetwork
{
//    [ToolboxBitmap(typeof(SearchLocalNetwork), "SearchLocalNetwork.SearchLocalNetwork.bmp")]
    //[ToolboxBitmap(typeof(TestControl), "namespace.TestControl.bmp")]
    [ToolboxItem(true)]
    //[ToolboxBitmapAttribute(typeof(SearchLocalNetwork), "SearchLocalNetwork.SearchLocalNetwork.bmp")]
    [ToolboxBitmap(@"E:\ManualReader\ctLogina\SearchLocalNetworkControl\Resources\SearchLocalNetwork4.bmp")]
    public partial class SearchLocalNetwork : UserControl
    {
        public delegate void SelectionChangedDelegate(string HostName,byte[] bAdress,UInt16 uiPort);
        public  Mutex mutexMessageBox = new Mutex(false);
        private string sColIP = "IP";
        private string sColPort = "Port";
        private string sColComputerName = "ComputerName";
        private string sColServer = "Server";

        private UInt32 ulIpMask;
        private UInt32 ulCommonIpAddress;
        private byte[] IpMask = new byte[4];
        private UInt32 uiAllDone = 0;

        System.Net.Sockets.TcpClient clientSocket = new System.Net.Sockets.TcpClient();
        UInt32 ulStartAddress;
        UInt32 ulEndAddress;
        UInt32 ulManagedAddress;
        UInt32 ulSearchRangePerThread;

        List<UInt32> sProcessDoneList = new List<UInt32>();
        List<ComputerDataFound> ComputerDataFoundList = new List<ComputerDataFound>();

        List<TextBox> lTextBox_StartAddress;
        List<TextBox> lTextBox_EndAddress;
        List<myScannerThreadClass> ThreadList = new List<myScannerThreadClass>();

        UInt16 ui16StartPort;
        UInt16 ui16EndPort;
        byte[] bStartAddress;
        byte[] bEndAddress;
        List<UInt32> IPAddressList = new List<UInt32>();

        private IPComapare ipCompare = new IPComapare();


        delegate void AddToListViewCallback(string s);
        delegate void ShowProcessCallback(string text);
        //delegate void AddIPAddressCallback(UInt32 ulIP);

        public SearchLocalNetwork()
        {
            InitializeComponent();
        }

        public static bool GatewayAddresses(ref List<byte[]> GatewayList, ref List<byte[]> DNS_List, ref byte[] bAddress, ref byte[] bMask)
        {


            NetworkInterface[] adapters = NetworkInterface.GetAllNetworkInterfaces();
            int iAdapterCount = adapters.Length;
            int iAdapter;
            for (iAdapter = 0; iAdapter < iAdapterCount; iAdapter++)
            {
                NetworkInterface adapter = adapters[iAdapter];
                if ((adapter.NetworkInterfaceType == NetworkInterfaceType.Ethernet) || (adapter.NetworkInterfaceType == NetworkInterfaceType.Wireless80211))
                {
                    IPInterfaceProperties adapterProperties = adapter.GetIPProperties();
                    GatewayIPAddressInformationCollection addresses = adapterProperties.GatewayAddresses;
                    if (addresses.Count > 0)
                    {
                        foreach (GatewayIPAddressInformation address in addresses)
                        {
                            GatewayList.Add(address.Address.GetAddressBytes());
                        }
                        Console.WriteLine();
                    }

                    System.Net.NetworkInformation.IPAddressCollection IPDnsAdressses = adapterProperties.DnsAddresses;
                    if (IPDnsAdressses.Count > 0)
                    {
                        int iCount = IPDnsAdressses.Count;
                        int i;
                        for (i = 0; i < iCount; i++)
                        {
                            if (IPDnsAdressses[i].AddressFamily == AddressFamily.InterNetwork)
                            {
                                Byte[] b = IPDnsAdressses[i].GetAddressBytes();
                                DNS_List.Add(b);
                            }
                        }
                    }
                    UnicastIPAddressInformationCollection UnicastIPInfoCol = adapter.GetIPProperties().UnicastAddresses;
                    foreach (UnicastIPAddressInformation UnicatIPInfo in UnicastIPInfoCol)
                    {
                        IPAddress ipaMask = UnicatIPInfo.IPv4Mask;
                        IPAddress ipa = UnicatIPInfo.Address;
                        if (ipa.AddressFamily == AddressFamily.InterNetwork)
                        {
                            if (ipaMask != null)
                            {
                                bMask = ipaMask.GetAddressBytes();
                                bAddress = ipa.GetAddressBytes();
                            }
                        }
                    }

                }
            }
            return true;
        }

        public class IPComapare : IComparer
        {
            public int Compare(object x, object y)
            {
                ListViewItem itemA = (ListViewItem)x;
                ListViewItem itemB = (ListViewItem)y;

                IPAddress AddressA = IPAddress.Parse(itemA.Text);
                UInt32 uiAddressA = StaticFunc.GetIPUInt32(AddressA.GetAddressBytes());

                IPAddress AddressB = IPAddress.Parse(itemB.Text);
                UInt32 uiAddressB = StaticFunc.GetIPUInt32(AddressB.GetAddressBytes());

                if (uiAddressA < uiAddressB)
                    return -1;

                if (uiAddressA > uiAddressB)
                    return 1;

                if (uiAddressA == uiAddressB)
                    return 0;

                return 0;
            }
        }


        public UInt32 GetIPfromTextBoxes(List<TextBox> lTextB)
        {
            int i;
            UInt32 ip = 0;
            for (i = 0; i < 4; i++)
            {
                ip = ((UInt32)(ip << 8)) + Convert.ToUInt32(lTextB[i].Text);
            }
            return ip;
        }



        public void WriteIPinTextBoxes(List<TextBox> lTextB, byte[] bAddress)
        {
            int i;

            for (i = 0; i < 4; i++)
            {
                lTextB[i].Text = bAddress[i].ToString("D3");
            }
        }

        private void SetRangeFromMask()
        {
            ulIpMask = IpMask[0];
            ulIpMask = ulIpMask << 8;
            ulIpMask = ulIpMask + IpMask[1];
            ulIpMask = ulIpMask << 8;
            ulIpMask = ulIpMask + IpMask[2];
            ulIpMask = ulIpMask << 8;
            ulIpMask = ulIpMask + IpMask[3];
            ulStartAddress = ulCommonIpAddress & ulIpMask;
            UInt32 nulIpMask = (~ulIpMask);
            ulEndAddress = ulCommonIpAddress | nulIpMask;
            WriteIPinTextBoxes(lTextBox_StartAddress, StaticFunc.GetIP(ulStartAddress));
            WriteIPinTextBoxes(lTextBox_EndAddress, StaticFunc.GetIP(ulEndAddress));
        }

        private void SearchLocalNetwork_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.bPingTimeout)
            {
                this.chkPingTimeout.CheckState = CheckState.Checked;
                this.TextPingTimeout.Enabled = true;
            }
            else
            {
                this.chkPingTimeout.CheckState = CheckState.Unchecked;
                this.TextPingTimeout.Enabled = false;
            }

            if (Properties.Settings.Default.chkShowAll)
            {
                chkUsePing.CheckState = CheckState.Checked;
                chkPingTimeout.Enabled = true;
                if (chkPingTimeout.Checked)
                {
                    this.TextPingTimeout.Enabled = true;
                }
                else
                {
                    this.TextPingTimeout.Enabled = false;
                }
            }
            else
            {
                chkUsePing.CheckState = CheckState.Unchecked;
            }

            if (Properties.Settings.Default.bScanPortRange)
            {
                chkPortRange.CheckState = CheckState.Checked;
                this.text_EndPort.Enabled = true;
            }
            else
            {
                chkPortRange.CheckState = CheckState.Unchecked;
                this.text_EndPort.Enabled = false;
            }

            if (Properties.Settings.Default.bCheckPort)
            {
                this.chkPorts.CheckState = CheckState.Checked;
                this.text_EndPort.Enabled = true;
                this.text_StartPort.Enabled = true;
                this.chkPortRange.Enabled = true;
            }
            else
            {
                chkPorts.CheckState = CheckState.Unchecked;
                this.text_EndPort.Enabled = false;
                this.text_StartPort.Enabled = false;
                this.chkPortRange.Enabled = false;
            }


            string myHost = System.Net.Dns.GetHostName();
            List<byte[]> GatewayList = new List<byte[]>();
            List<byte[]> DNS_List = new List<byte[]>();
            byte[] CommonIpAddress = new byte[4];
            GatewayAddresses(ref  GatewayList, ref DNS_List, ref CommonIpAddress, ref IpMask);
            listBox_Gateways.Items.Clear();


            foreach (byte[] b in GatewayList)
            {
                if (!StaticFunc.isNullIP(b))
                {
                    listBox_Gateways.Items.Add(StaticFunc.GetComputerFromIP(b));
                }
            }

            foreach (byte[] b in DNS_List)
            {
                if (!StaticFunc.isNullIP(b))
                {
                    listBox_DNS.Items.Add(StaticFunc.GetComputerFromIP(b));
                }
            }

            List<TextBox> lTextBox_ThisComputerIP = new List<TextBox>();
            lTextBox_ThisComputerIP.Add(IP3);
            lTextBox_ThisComputerIP.Add(IP2);
            lTextBox_ThisComputerIP.Add(IP1);
            lTextBox_ThisComputerIP.Add(IP0);
            WriteIPinTextBoxes(lTextBox_ThisComputerIP, CommonIpAddress);

            List<TextBox> lTextBox_Mask = new List<TextBox>();
            lTextBox_Mask.Add(M3);
            lTextBox_Mask.Add(M2);
            lTextBox_Mask.Add(M1);
            lTextBox_Mask.Add(M0);

            WriteIPinTextBoxes(lTextBox_Mask, IpMask);

            ulCommonIpAddress = StaticFunc.GetIPUInt32(CommonIpAddress);


            IPAddress AddressStart = IPAddress.Parse(Properties.Settings.Default.StartIP);
            ulStartAddress = StaticFunc.GetIPUInt32(AddressStart.GetAddressBytes());
            IPAddress AddressEnd = IPAddress.Parse(Properties.Settings.Default.EndIP);
            ulEndAddress = StaticFunc.GetIPUInt32(AddressEnd.GetAddressBytes());


            UInt32 ulDif = ulEndAddress - ulStartAddress;
            bStartAddress = StaticFunc.GetIP(ulStartAddress);
            bEndAddress = StaticFunc.GetIP(ulEndAddress);

            lTextBox_StartAddress = new List<TextBox>();
            lTextBox_StartAddress.Add(StartIP3);
            lTextBox_StartAddress.Add(StartIP2);
            lTextBox_StartAddress.Add(StartIP1);
            lTextBox_StartAddress.Add(StartIP0);
            WriteIPinTextBoxes(lTextBox_StartAddress, bStartAddress);




            lTextBox_EndAddress = new List<TextBox>();
            lTextBox_EndAddress.Add(EndIP3);
            lTextBox_EndAddress.Add(EndIP2);
            lTextBox_EndAddress.Add(EndIP1);
            lTextBox_EndAddress.Add(EndIP0);
            WriteIPinTextBoxes(lTextBox_EndAddress, bEndAddress);

            txtMaxWorkingThreads.Text = Properties.Settings.Default.iMaxWorkingThreads.ToString();
            textMaxNumberOfIPsToSearchPerThread.Text = Properties.Settings.Default.MaxNumberOfIPsToSearchPerThread.ToString();

            this.text_StartPort.Text = Properties.Settings.Default.StartPort.ToString("D4");
            this.text_EndPort.Text = Properties.Settings.Default.EndPort.ToString("D4");

            TextPingTimeout.Text = Properties.Settings.Default.PingTimeout.ToString();

            txtCeckPortTimeout.Text = Properties.Settings.Default.CheckPortTimeout.ToString();

            ui16StartPort = Convert.ToUInt16(this.text_StartPort.Text);
            ui16EndPort = Convert.ToUInt16(this.text_EndPort.Text);
            IPComapare listView_Connections_Comparer = new IPComapare();
            this.listView_Connections.ListViewItemSorter = listView_Connections_Comparer;
            //PingComputer();

        }

        public bool AllowClosing()
        {
            if (ThreadList.Count >  0)
            {
                if (MessageBox.Show("Are you sure you want to stop thread scanning? ", "Close Form", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    // Cancel the Closing event
                    return false;
                }
                else
                {

                    do
                    {
                        while (!SendMessage(myScannerThreadClass.eMessage.MSG_STOP_SEARCHING))
                        {
                            //Debug.Print("\nNot Sent SendMessage(eMessage.MSG_END_THREAD)");
                        }
                        List<myScannerThreadClass> ThreadsToRemove = new List<myScannerThreadClass>();
                        foreach (myScannerThreadClass thrcls in ThreadList)
                        {
                            if (thrcls.GetMessageSearchFinished())
                            {
                                if (thrcls.mutexMessageBoxScanner.WaitOne(2000))
                                {
                                    thrcls.MessageList.Add(myScannerThreadClass.eMessage.MSG_EXIT_THREAD);
                                    thrcls.mutexMessageBoxScanner.ReleaseMutex();
                                    while (thrcls.ScannerThread.ThreadState == System.Threading.ThreadState.Running)
                                    {
                                        System.Threading.Thread.Sleep(100);
                                    }
                                    ThreadsToRemove.Add(thrcls);
                                }
                            }
                        }
                        foreach (myScannerThreadClass thrcls in ThreadsToRemove)
                        {
                            ThreadList.Remove(thrcls);
                        }

                    } while (ThreadList.Count > 0);

                    label_Process.Text = "Thread Canceled; Computer devices found = " + listView_Connections.Items.Count.ToString();
                }
            }
            return true;
        }

        private void button_Scan_Click(object sender, EventArgs e)
        {
            if (dbg.bDebugPrint) dbg.print(" button_Scanner_Click(object sender, EventArgs e)");
            if (ThreadList.Count == 0)
            {
                if (dbg.bDebugPrint) dbg.print(" ThreadList.Count == 0");
                ulStartAddress = GetIPfromTextBoxes(lTextBox_StartAddress);
                ulManagedAddress = ulStartAddress;
                ulEndAddress = GetIPfromTextBoxes(lTextBox_EndAddress);
                ulSearchRangePerThread = Convert.ToUInt32(textMaxNumberOfIPsToSearchPerThread.Text);
                Properties.Settings.Default.iMaxWorkingThreads = Convert.ToInt32(this.txtMaxWorkingThreads.Text);
                uiAllDone = 0;

                if (dbg.bDebugPrint) dbg.print("  Properties.Settings.Default.iMaxWorkingThreads =  " + Properties.Settings.Default.iMaxWorkingThreads.ToString());

                if (dbg.bDebugPrint) dbg.print(" ThreadManagerExecuteAllThreads() ");
                this.listView_Connections.Clear();



                this.listView_Connections.View = View.Details;


                ColumnHeader ch1 = listView_Connections.Columns.Add(sColIP);
                ch1.Width = 120;
                if (this.chkPorts.Checked)
                {
                    ColumnHeader ch1A = listView_Connections.Columns.Add(sColPort);
                    ch1A.Width = 60;
                }

                ColumnHeader ch2 = listView_Connections.Columns.Add(sColComputerName);
                ch2.Width = 240;

                if (this.chkPorts.Checked)
                {
                    ColumnHeader ch3 = listView_Connections.Columns.Add(sColServer);
                    ch3.Width = 240;
                }

                if (ThreadManagerExecuteAllThreads())
                {
                }
                else
                {
                    timer_ManageThreads.Enabled = true;
                }
            }
            else
            {
                MessageBox.Show("Number of search threads is " + ThreadList.Count.ToString() + ". You can not start new search. Please wait the threads are finished or press Cancel.", "Warning");
            }

        }
        private void AddInListView(ComputerDataFound cmpData)
        {
            if (this.listView_Connections.View == View.List)
            {
                if (cmpData.Port != 0xFFFF)
                {
                    if (cmpData.bMySQLVersion)
                    {
                        this.listView_Connections.Items.Add(StaticFunc.GetComputerFromIP(StaticFunc.GetIP(cmpData.IpAddress)) + " : " + cmpData.Port.ToString() + " \"" + cmpData.sHostName + "\", MySQL Version = " + cmpData.sMySQLVersion);
                    }
                    else
                    {
                        this.listView_Connections.Items.Add(StaticFunc.GetComputerFromIP(StaticFunc.GetIP(cmpData.IpAddress)) + " : \"" + cmpData.sHostName + "\"");
                    }
                }
                else
                {
                    this.listView_Connections.Items.Add(StaticFunc.GetComputerFromIP(StaticFunc.GetIP(cmpData.IpAddress)) + " : \"" + cmpData.sHostName + "\"");
                }
            }
            else if (this.listView_Connections.View == View.Details)
            {
                if (cmpData.Port != 0xFFFF)
                {
                    if (cmpData.bMySQLVersion)
                    {

                        ListViewItem lvi = new ListViewItem();
                        lvi.Tag = 0;
                        lvi.Text = StaticFunc.GetComputerFromIP(StaticFunc.GetIP(cmpData.IpAddress));
                        lvi.Name = sColIP;

                        ListViewItem.ListViewSubItem subItemPort = new ListViewItem.ListViewSubItem(lvi, sColPort);
                        subItemPort.Name = sColPort;
                        subItemPort.Text = cmpData.Port.ToString();
                        lvi.SubItems.Add(subItemPort);

                        ListViewItem.ListViewSubItem subItem = new ListViewItem.ListViewSubItem(lvi, sColComputerName);
                        subItem.Name = sColComputerName;
                        subItem.Text = cmpData.sHostName;
                        lvi.SubItems.Add(subItem);


                        ListViewItem.ListViewSubItem subItemServer = new ListViewItem.ListViewSubItem(lvi, sColServer);
                        subItemServer.Name = sColServer;
                        subItemServer.Text = cmpData.sMySQLVersion;
                        lvi.SubItems.Add(subItemServer);
                        listView_Connections.Items.Add(lvi);

                    }
                    else
                    {
                        ListViewItem lvi = new ListViewItem();
                        lvi.Tag = 0;
                        lvi.Text = StaticFunc.GetComputerFromIP(StaticFunc.GetIP(cmpData.IpAddress));
                        lvi.Name = sColIP;

                        ListViewItem.ListViewSubItem subItemPort = new ListViewItem.ListViewSubItem(lvi, sColPort);
                        subItemPort.Name = sColPort;
                        subItemPort.Text = cmpData.Port.ToString();
                        lvi.SubItems.Add(subItemPort);

                        ListViewItem.ListViewSubItem subItem = new ListViewItem.ListViewSubItem(lvi, sColComputerName);
                        subItem.Name = sColComputerName;
                        subItem.Text = cmpData.sHostName;
                        lvi.SubItems.Add(subItem);


                        //ListViewItem.ListViewSubItem subItemServer = new ListViewItem.ListViewSubItem(lvi, sColIP);
                        //subItemServer.Name = sColServer;
                        //subItemServer.Text = cmpData.sMySQLVersion;
                        //lvi.SubItems.Add(subItemServer);
                        listView_Connections.Items.Add(lvi);
                    }
                }
                else
                {
                    ListViewItem lvi = new ListViewItem();
                    lvi.Tag = 0;
                    lvi.Text = StaticFunc.GetComputerFromIP(StaticFunc.GetIP(cmpData.IpAddress));
                    lvi.Name = sColIP;

                    ListViewItem.ListViewSubItem subItem = new ListViewItem.ListViewSubItem(lvi, sColComputerName);
                    subItem.Name = sColComputerName;
                    subItem.Text = cmpData.sHostName;
                    lvi.SubItems.Add(subItem);


                    //ListViewItem.ListViewSubItem subItemServer = new ListViewItem.ListViewSubItem(lvi, sColIP);
                    //subItemServer.Name = sColServer;
                    //subItemServer.Text = cmpData.sMySQLVersion;
                    //lvi.SubItems.Add(subItemServer);
                    listView_Connections.Items.Add(lvi);
                }
            }
        }

        private void timer_follow_ScannerThread_Tick(object sender, EventArgs e)
        {

            UInt32 ui = 0;
            while (GetMessage(ref ui))
            {
                //Debug.Print("\nGetMessage("+s+")");
                uiAllDone += ui;
            }
            UInt32 ulProc;
            if (ulEndAddress > ulStartAddress)
            {
                ulProc = (uiAllDone * 100) / (ulEndAddress - ulStartAddress);
            }
            else
            {
                ulProc = 100;
            }
            this.label_Process.Text = "Progress : " + ulProc.ToString() + "%";

            ComputerDataFound cmpData = null;
            while (GetMessage(ref cmpData))
            {
                //Debug.Print("\nGetMessage( IP )");
                AddInListView(cmpData);

            }

            List<myScannerThreadClass> ThreadsToRemove = new List<myScannerThreadClass>();
            foreach (myScannerThreadClass thrcls in ThreadList)
            {
                if (thrcls.GetMessageSearchFinished())
                {
                    if (thrcls.mutexMessageBoxScanner.WaitOne(2000))
                    {
                        thrcls.MessageList.Add(myScannerThreadClass.eMessage.MSG_EXIT_THREAD);
                        thrcls.mutexMessageBoxScanner.ReleaseMutex();
                        while (thrcls.ScannerThread.ThreadState == System.Threading.ThreadState.Running)
                        {
                            System.Threading.Thread.Sleep(100);
                        }
                        ThreadsToRemove.Add(thrcls);
                    }
                }
            }

            foreach (myScannerThreadClass thrcls in ThreadsToRemove)
            {
                ThreadList.Remove(thrcls);
            }

            if (ThreadList.Count == 0)
            {
                if (ulManagedAddress > ulEndAddress)
                {
                    label_Process.Text = "Thread finished; Computer devices found = " + listView_Connections.Items.Count.ToString();
                    if (ulManagedAddress > ulEndAddress)
                    {
                        timer_follow_ScannerThread.Enabled = false;
                    }
                }
            }

        }

        public bool SendMessage(myScannerThreadClass.eMessage eMsg)
        {


            foreach (myScannerThreadClass thrclass in ThreadList)
            {
                if (thrclass.bSend)
                {
                    if (thrclass.mutexMessageBoxScanner.WaitOne(2000))
                    {
                        thrclass.MessageList.Add(eMsg);
                        thrclass.mutexMessageBoxScanner.ReleaseMutex();
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public bool GetMessage(ref UInt32 uiDone)
        {
            // first empty all MessageBoxes of all threads
            int AllCount = ThreadList.Count;
            foreach (myScannerThreadClass thrcls in ThreadList)
            {
                if (thrcls.mutexMessageBoxScanner.WaitOne(2000))
                {
                    if (thrcls.MessageDoneList.Count > 0)
                    {
                        sProcessDoneList.Add(thrcls.MessageDoneList[0]);
                        thrcls.MessageDoneList.RemoveAt(0);
                    }
                    thrcls.mutexMessageBoxScanner.ReleaseMutex();
                }
            }

            if (sProcessDoneList.Count > 0)
            {
                uiDone = sProcessDoneList[0];
                sProcessDoneList.RemoveAt(0);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool GetMessage(ref ComputerDataFound cmpDataOut)
        {
            // First empty all MessageBoxes

            foreach (myScannerThreadClass thrcls in ThreadList)
            {
                if (thrcls.mutexMessageBoxScanner.WaitOne(2000))
                {
                    if (thrcls.MessageListData.Count > 0)
                    {
                        ComputerDataFound cmpData = new ComputerDataFound();
                        cmpData.bMySQLVersion = thrcls.MessageListData[0].bMySQLVersion;
                        cmpData.bPortOpened = thrcls.MessageListData[0].bPortOpened;
                        cmpData.IpAddress = thrcls.MessageListData[0].IpAddress;
                        cmpData.sHostName = thrcls.MessageListData[0].sHostName;
                        cmpData.Port = thrcls.MessageListData[0].Port;
                        cmpData.sMySQLVersion = thrcls.MessageListData[0].sMySQLVersion;
                        ComputerDataFoundList.Add(cmpData);
                        thrcls.MessageListData.RemoveAt(0);
                    }
                    thrcls.mutexMessageBoxScanner.ReleaseMutex();
                }
            }

            if (ComputerDataFoundList.Count > 0)
            {
                ComputerDataFound cmpD = new ComputerDataFound();
                cmpD.bMySQLVersion = ComputerDataFoundList[0].bMySQLVersion;
                cmpD.bPortOpened = ComputerDataFoundList[0].bPortOpened;
                cmpD.IpAddress = ComputerDataFoundList[0].IpAddress;
                cmpD.sHostName = ComputerDataFoundList[0].sHostName;
                cmpD.Port = ComputerDataFoundList[0].Port;
                cmpD.sMySQLVersion = ComputerDataFoundList[0].sMySQLVersion;
                ComputerDataFoundList.RemoveAt(0);
                cmpDataOut = cmpD;
                return true;

            }
            else
            {
                cmpDataOut = null;
                return false;
            }
        }

        private void BtnSaveSettings_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.bPingTimeout = this.chkPingTimeout.Checked;
            Properties.Settings.Default.CheckPortTimeout = Convert.ToInt32(this.txtCeckPortTimeout.Text);
            Properties.Settings.Default.PingTimeout = Convert.ToInt32(this.TextPingTimeout.Text);
            ulStartAddress = GetIPfromTextBoxes(lTextBox_StartAddress);
            ulEndAddress = GetIPfromTextBoxes(lTextBox_EndAddress);
            Properties.Settings.Default.StartPort = Convert.ToInt32(this.text_StartPort.Text);
            Properties.Settings.Default.EndPort = Convert.ToInt32(this.text_EndPort.Text);
            Properties.Settings.Default.StartIP = StaticFunc.GetComputerFromIP(StaticFunc.GetIP(ulStartAddress));
            Properties.Settings.Default.EndIP = StaticFunc.GetComputerFromIP(StaticFunc.GetIP(ulEndAddress));
            Properties.Settings.Default.chkShowAll = this.chkUsePing.Checked;
            Properties.Settings.Default.bScanPortRange = this.chkPortRange.Checked;
            Properties.Settings.Default.bPingTimeout = this.chkPingTimeout.Checked;
            Properties.Settings.Default.iMaxWorkingThreads = Convert.ToInt32(txtMaxWorkingThreads.Text);
            Properties.Settings.Default.MaxNumberOfIPsToSearchPerThread = Convert.ToInt32(textMaxNumberOfIPsToSearchPerThread.Text);

            Properties.Settings.Default.Save();

        }

        private void btnCancelSearch_Click(object sender, EventArgs e)
        {
            while (!SendMessage(myScannerThreadClass.eMessage.MSG_STOP_SEARCHING))
            {

            }

            UInt32 ui = 0;
            while (GetMessage(ref ui))
            {
                //Debug.Print("\nGetMessage("+s+")");
                uiAllDone += ui;
            }

            UInt32 ulProc = (uiAllDone * 100) / (ulEndAddress - ulStartAddress);
            this.label_Process.Text = "Progress : %" + ulProc.ToString();

            ComputerDataFound cmpData = null;
            while (GetMessage(ref cmpData))
            {
                //Debug.Print("\nGetMessage( IP )");
                if (cmpData.bMySQLVersion)
                {
                    this.listView_Connections.Items.Add(StaticFunc.GetComputerFromIP(StaticFunc.GetIP(cmpData.IpAddress)) + " : " + cmpData.Port.ToString() + " \"" + cmpData.sHostName + "\", MySQL Version = " + cmpData.sMySQLVersion);
                }
                else
                {
                    this.listView_Connections.Items.Add(StaticFunc.GetComputerFromIP(StaticFunc.GetIP(cmpData.IpAddress)) + " : \"" + cmpData.sHostName + "\"");
                }
                cmpData.Dispose(); //cmpData no mre needed, disopse it !
            }
            bool bSearchEnd = false;

            while (!bSearchEnd)
            {
                bSearchEnd = true;
                List<myScannerThreadClass> Threads2Remove = new List<myScannerThreadClass>();

                foreach (myScannerThreadClass thrcls in ThreadList)
                {
                    if (thrcls.GetMessageSearchFinished())
                    {
                        if (thrcls.mutexMessageBoxScanner.WaitOne(2000))
                        {
                            thrcls.MessageList.Add(myScannerThreadClass.eMessage.MSG_EXIT_THREAD);
                            thrcls.mutexMessageBoxScanner.ReleaseMutex();
                            while (thrcls.ScannerThread.ThreadState == System.Threading.ThreadState.Running)
                            {
                                System.Threading.Thread.Sleep(100);
                            }
                            Threads2Remove.Add(thrcls);
                        }
                    }
                    else
                    {
                        bSearchEnd = false;
                    }
                }

                foreach (myScannerThreadClass thrcls in Threads2Remove)
                {
                    ThreadList.Remove(thrcls);
                }
            }
            label_Process.Text = "Thread canceled; Computer devices found = " + listView_Connections.Items.Count.ToString();
            timer_follow_ScannerThread.Enabled = false;

        }

        private void chkPorts_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPorts.Checked)
            {
                this.text_StartPort.Enabled = true;
                this.chkPortRange.Enabled = true;
                if (chkPortRange.Checked)
                {
                    this.text_EndPort.Enabled = true;
                }
                else
                {
                    this.text_EndPort.Enabled = false;
                }
            }
            else
            {
                this.text_EndPort.Enabled = false;
                this.text_StartPort.Enabled = false;
                chkPortRange.Enabled = false;
            }
        }

        private void chkPortRange_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPortRange.Checked)
            {
                this.text_EndPort.Enabled = true;
            }
            else
            {
                this.text_EndPort.Enabled = false;
            }

        }

        private void chkPingTimeout_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkPingTimeout.Checked)
            {
                this.TextPingTimeout.Enabled = true;
            }
            else
            {
                this.TextPingTimeout.Enabled = false;
            }

        }

        private void chkUsePing_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkUsePing.Checked)
            {
                chkPingTimeout.Enabled = true;
                this.TextPingTimeout.Enabled = true;
            }
            else
            {
                chkPingTimeout.Enabled = false;
                this.TextPingTimeout.Enabled = false;
            }

        }

        private void btnSetRangeOnMask_Click(object sender, EventArgs e)
        {
            SetRangeFromMask();

        }

        private bool ThreadManagerExecuteAllThreads()
        {

            int iAwailableThreadCount = Properties.Settings.Default.iMaxWorkingThreads - ThreadList.Count;

            if (ulManagedAddress <= ulEndAddress)
            {
                while (true)
                {
                    if (iAwailableThreadCount > 0)
                    {
                        if (dbg.bDebugPrint) dbg.print(" iAwailableThreadCount =  " + iAwailableThreadCount.ToString());

                        UInt32 ulThreadsEndAddress = ulManagedAddress + ulSearchRangePerThread;
                        if (ulThreadsEndAddress > ulEndAddress)
                        {
                            ulThreadsEndAddress = ulEndAddress;
                        }
                        Properties.Settings.Default.PingTimeout = Convert.ToInt32(this.TextPingTimeout.Text);
                        Properties.Settings.Default.CheckPortTimeout = Convert.ToInt32(this.txtCeckPortTimeout.Text);
                        Properties.Settings.Default.chkShowAll = this.chkUsePing.Checked;
                        Properties.Settings.Default.bCheckPort = this.chkPorts.Checked;
                        Properties.Settings.Default.bScanPortRange = chkPortRange.Checked;
                        ui16StartPort = Convert.ToUInt16(this.text_StartPort.Text);
                        ui16EndPort = Convert.ToUInt16(this.text_EndPort.Text);


                        myScannerThreadClass ScannerThreadClass = new myScannerThreadClass();
                        if (dbg.bDebugPrint) dbg.print("ScannerThreadClass.StartThread(\n       StartAdress= " + StaticFunc.GetComputerFromIP(StaticFunc.GetIP(ulManagedAddress)) +
                                                                  ",\n     EndAdress= " + StaticFunc.GetComputerFromIP(StaticFunc.GetIP(ulThreadsEndAddress)) +
                                                                  ",\n     StartPort = " + ui16StartPort.ToString() +
                                                                  ",\n     EndPort = " + ui16EndPort.ToString() +
                                                                  ",\n     busePing = " + chkUsePing.Checked.ToString() +
                                                                  ",\n     PingTimoeut = " + Properties.Settings.Default.PingTimeout.ToString() +
                                                                  ",\n     CheckPortTimeout = " + Properties.Settings.Default.CheckPortTimeout.ToString() +
                                                                  ",\n     bScanPortRange = " + Properties.Settings.Default.bScanPortRange.ToString() +
                                                                  ",\n     bCheckPort = " + Properties.Settings.Default.bCheckPort.ToString() +
                                                                  ",\n      = Form_SearchMySQL_servers" +
                                                                  "\n)"
                                                                  );

                        if (ScannerThreadClass.StartThread(ulManagedAddress,
                                                           ulThreadsEndAddress,
                                                           ui16StartPort,
                                                           ui16EndPort,
                                                        Properties.Settings.Default.chkShowAll,
                                                        Properties.Settings.Default.PingTimeout,
                                                        Properties.Settings.Default.CheckPortTimeout,
                                                        Properties.Settings.Default.bScanPortRange,
                                                        Properties.Settings.Default.bCheckPort,
                                                        this))
                        {
                            if (dbg.bDebugPrint) dbg.print("ScannerThreadClass.ScannerThread.ManagedThreadId = " + ScannerThreadClass.ScannerThread.ManagedThreadId.ToString());
                            ThreadList.Add(ScannerThreadClass);
                            iAwailableThreadCount--;
                            ulManagedAddress = ulThreadsEndAddress + 1;
                            timer_follow_ScannerThread.Enabled = true;
                        }

                        if (ulManagedAddress > ulEndAddress)
                        {
                            if (dbg.bDebugPrint) dbg.print("NO iAwailableThreadCount ");
                            if (dbg.bDebugPrint) dbg.print("return false from ThreadManagerExecuteAllThreads");
                            return true;
                        }
                    }
                    else
                    {
                        if (ulManagedAddress > ulEndAddress)
                        {
                            if (dbg.bDebugPrint) dbg.print("Finished ");
                            if (dbg.bDebugPrint) dbg.print("return false from ThreadManagerExecuteAllThreads");
                            return true;
                        }
                        else
                        {
                            if (dbg.bDebugPrint) dbg.print("NO iAwailableThreadCount ");
                            if (dbg.bDebugPrint) dbg.print("return true from ThreadManagerExecuteAllThreads");
                            return false;
                        }
                    }
                }
            }
            return false;
        }

        private void timer_ManageThreads_Tick(object sender, EventArgs e)
        {
            if (dbg.bDebugPrint) dbg.print(" timer_ManageThreads_Tick ThreadManagerExecuteAllThreads() ");

            if (ThreadManagerExecuteAllThreads())
            {
                timer_ManageThreads.Enabled = false;
            }

        }

        public delegate void SelectedServerChangedHandler(string HostName, byte[] bAdress, UInt16 uiPort);
        // Declare the event, which is associated with our
        // delegate SubmitClickedHandler(). Add some attributes
        // for the Visual C# control property.
        [Category("Action")]
        [Description("Fires when SelectedIndexChanged.")]
        public event SelectedServerChangedHandler SelectedServerChanged;
        // Add a protected method called OnSubmitClicked().
        // You may use this in child classes instead of adding
        // event handlers.


        public  void listView_Connections_SelectedIndexChanged(object sender, EventArgs e)
        {
            String sIP;
            String sPort;
            UInt16 uiPort;
            String sHostName;
            byte[] bAdress;
            ListView.SelectedListViewItemCollection ItemCollection = this.listView_Connections.SelectedItems;
            if (ItemCollection != null)
            {
                if (ItemCollection.Count > 0)
                {
                    sIP = ItemCollection[0].SubItems["IP"].Text;
                    IPAddress Address = IPAddress.Parse(sIP);
                    bAdress = Address.GetAddressBytes();
                    sPort = "";
                    if (ItemCollection[0].SubItems["Port"] != null)
                    {
                        sPort = ItemCollection[0].SubItems["Port"].Text;
                    }
                    sHostName = ItemCollection[0].SubItems["ComputerName"].Text;
                    uiPort = Convert.ToUInt16(sPort);
                    SelectedServerChanged(sHostName, bAdress, uiPort);
                }
            }
        }
    }

    public static class dbg
    {
        public static bool bDebugPrint = Properties.Settings.Default.bDebugPrint;
        public static void print(string s)
        {
            int threadId = System.Threading.Thread.CurrentThread.ManagedThreadId;
            System.Diagnostics.Debug.Print("\n" + threadId.ToString() + " :" + s + "\n");
        }
    }

}
