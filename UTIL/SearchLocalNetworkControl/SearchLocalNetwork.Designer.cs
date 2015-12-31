namespace SearchLocalNetwork
{
    partial class SearchLocalNetwork
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.chkUsePing = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.IP3 = new System.Windows.Forms.TextBox();
            this.IP2 = new System.Windows.Forms.TextBox();
            this.IP0 = new System.Windows.Forms.TextBox();
            this.IP1 = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.listBox_DNS = new System.Windows.Forms.ListBox();
            this.listBox_Gateways = new System.Windows.Forms.ListBox();
            this.chkPorts = new System.Windows.Forms.CheckBox();
            this.TextPingTimeout = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.chkPingTimeout = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chkPortRange = new System.Windows.Forms.CheckBox();
            this.lblTimeout = new System.Windows.Forms.Label();
            this.txtCeckPortTimeout = new System.Windows.Forms.TextBox();
            this.text_EndPort = new System.Windows.Forms.TextBox();
            this.label_EndPort = new System.Windows.Forms.Label();
            this.text_StartPort = new System.Windows.Forms.TextBox();
            this.txtMaxWorkingThreads = new System.Windows.Forms.TextBox();
            this.llb_MaxThreads = new System.Windows.Forms.Label();
            this.timer_ManageThreads = new System.Windows.Forms.Timer(this.components);
            this.btnCancelSearch = new System.Windows.Forms.Button();
            this.BtnSaveSettings = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button_Scan = new System.Windows.Forms.Button();
            this.timer_follow_ScannerThread = new System.Windows.Forms.Timer(this.components);
            this.ComputerName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colIP = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Panel_EndIP = new System.Windows.Forms.Panel();
            this.EndIP3 = new System.Windows.Forms.TextBox();
            this.EndIP2 = new System.Windows.Forms.TextBox();
            this.EndIP0 = new System.Windows.Forms.TextBox();
            this.EndIP1 = new System.Windows.Forms.TextBox();
            this.lbl_End_IP = new System.Windows.Forms.Label();
            this.StartIP2 = new System.Windows.Forms.TextBox();
            this.Panel_StartIP = new System.Windows.Forms.Panel();
            this.StartIP3 = new System.Windows.Forms.TextBox();
            this.StartIP0 = new System.Windows.Forms.TextBox();
            this.StartIP1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_Gateway = new System.Windows.Forms.Label();
            this.lbl_DNS = new System.Windows.Forms.Label();
            this.label_Process = new System.Windows.Forms.Label();
            this.M1 = new System.Windows.Forms.TextBox();
            this.listView_Connections = new System.Windows.Forms.ListView();
            this.btnSetRangeOnMask = new System.Windows.Forms.Button();
            this.M3 = new System.Windows.Forms.TextBox();
            this.M2 = new System.Windows.Forms.TextBox();
            this.M0 = new System.Windows.Forms.TextBox();
            this.textMaxNumberOfIPsToSearchPerThread = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.Panel_EndIP.SuspendLayout();
            this.Panel_StartIP.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkUsePing
            // 
            this.chkUsePing.AutoSize = true;
            this.chkUsePing.Location = new System.Drawing.Point(222, 17);
            this.chkUsePing.Name = "chkUsePing";
            this.chkUsePing.Size = new System.Drawing.Size(87, 21);
            this.chkUsePing.TabIndex = 3;
            this.chkUsePing.Text = "Use Ping";
            this.chkUsePing.UseVisualStyleBackColor = true;
            this.chkUsePing.CheckedChanged += new System.EventHandler(this.chkUsePing_CheckedChanged);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(261, 264);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(362, 30);
            this.label4.TabIndex = 51;
            this.label4.Text = "Max number of IP Addresses per thread to search:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.IP3);
            this.panel4.Controls.Add(this.IP2);
            this.panel4.Controls.Add(this.IP0);
            this.panel4.Controls.Add(this.IP1);
            this.panel4.Controls.Add(this.label15);
            this.panel4.Location = new System.Drawing.Point(13, 111);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(349, 40);
            this.panel4.TabIndex = 40;
            // 
            // IP3
            // 
            this.IP3.Location = new System.Drawing.Point(139, 8);
            this.IP3.Name = "IP3";
            this.IP3.Size = new System.Drawing.Size(38, 22);
            this.IP3.TabIndex = 1;
            this.IP3.Text = "192";
            // 
            // IP2
            // 
            this.IP2.Location = new System.Drawing.Point(186, 8);
            this.IP2.Name = "IP2";
            this.IP2.Size = new System.Drawing.Size(38, 22);
            this.IP2.TabIndex = 13;
            // 
            // IP0
            // 
            this.IP0.Location = new System.Drawing.Point(274, 8);
            this.IP0.Name = "IP0";
            this.IP0.Size = new System.Drawing.Size(38, 22);
            this.IP0.TabIndex = 17;
            // 
            // IP1
            // 
            this.IP1.Location = new System.Drawing.Point(230, 8);
            this.IP1.Name = "IP1";
            this.IP1.Size = new System.Drawing.Size(38, 22);
            this.IP1.TabIndex = 15;
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(-9, 7);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(142, 23);
            this.label15.TabIndex = 3;
            this.label15.Text = "This computer IP:";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // listBox_DNS
            // 
            this.listBox_DNS.FormattingEnabled = true;
            this.listBox_DNS.ItemHeight = 16;
            this.listBox_DNS.Location = new System.Drawing.Point(449, 35);
            this.listBox_DNS.Name = "listBox_DNS";
            this.listBox_DNS.Size = new System.Drawing.Size(278, 68);
            this.listBox_DNS.TabIndex = 45;
            // 
            // listBox_Gateways
            // 
            this.listBox_Gateways.FormattingEnabled = true;
            this.listBox_Gateways.ItemHeight = 16;
            this.listBox_Gateways.Location = new System.Drawing.Point(98, 35);
            this.listBox_Gateways.Name = "listBox_Gateways";
            this.listBox_Gateways.Size = new System.Drawing.Size(264, 68);
            this.listBox_Gateways.TabIndex = 44;
            // 
            // chkPorts
            // 
            this.chkPorts.AutoSize = true;
            this.chkPorts.Location = new System.Drawing.Point(218, 38);
            this.chkPorts.Name = "chkPorts";
            this.chkPorts.Size = new System.Drawing.Size(106, 21);
            this.chkPorts.TabIndex = 7;
            this.chkPorts.Text = "Check Ports";
            this.chkPorts.UseVisualStyleBackColor = true;
            this.chkPorts.CheckedChanged += new System.EventHandler(this.chkPorts_CheckedChanged);
            // 
            // TextPingTimeout
            // 
            this.TextPingTimeout.Location = new System.Drawing.Point(156, 15);
            this.TextPingTimeout.Name = "TextPingTimeout";
            this.TextPingTimeout.Size = new System.Drawing.Size(60, 22);
            this.TextPingTimeout.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.chkUsePing);
            this.panel3.Controls.Add(this.chkPingTimeout);
            this.panel3.Controls.Add(this.TextPingTimeout);
            this.panel3.Location = new System.Drawing.Point(376, 186);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(351, 59);
            this.panel3.TabIndex = 42;
            // 
            // chkPingTimeout
            // 
            this.chkPingTimeout.Location = new System.Drawing.Point(-3, 15);
            this.chkPingTimeout.Name = "chkPingTimeout";
            this.chkPingTimeout.Size = new System.Drawing.Size(154, 19);
            this.chkPingTimeout.TabIndex = 2;
            this.chkPingTimeout.Text = "Ping Timeout in ms:";
            this.chkPingTimeout.UseVisualStyleBackColor = true;
            this.chkPingTimeout.CheckedChanged += new System.EventHandler(this.chkPingTimeout_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.chkPorts);
            this.panel2.Controls.Add(this.chkPortRange);
            this.panel2.Controls.Add(this.lblTimeout);
            this.panel2.Controls.Add(this.txtCeckPortTimeout);
            this.panel2.Controls.Add(this.text_EndPort);
            this.panel2.Controls.Add(this.label_EndPort);
            this.panel2.Controls.Add(this.text_StartPort);
            this.panel2.Location = new System.Drawing.Point(13, 185);
            this.panel2.Margin = new System.Windows.Forms.Padding(1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(349, 76);
            this.panel2.TabIndex = 39;
            // 
            // chkPortRange
            // 
            this.chkPortRange.AutoSize = true;
            this.chkPortRange.Location = new System.Drawing.Point(0, 9);
            this.chkPortRange.Name = "chkPortRange";
            this.chkPortRange.Size = new System.Drawing.Size(106, 21);
            this.chkPortRange.TabIndex = 6;
            this.chkPortRange.Text = "Port Range:";
            this.chkPortRange.UseVisualStyleBackColor = true;
            this.chkPortRange.CheckedChanged += new System.EventHandler(this.chkPortRange_CheckedChanged);
            // 
            // lblTimeout
            // 
            this.lblTimeout.Location = new System.Drawing.Point(-3, 36);
            this.lblTimeout.Name = "lblTimeout";
            this.lblTimeout.Size = new System.Drawing.Size(137, 22);
            this.lblTimeout.TabIndex = 5;
            this.lblTimeout.Text = "Check Port Timeout:";
            // 
            // txtCeckPortTimeout
            // 
            this.txtCeckPortTimeout.Location = new System.Drawing.Point(139, 36);
            this.txtCeckPortTimeout.Name = "txtCeckPortTimeout";
            this.txtCeckPortTimeout.Size = new System.Drawing.Size(60, 22);
            this.txtCeckPortTimeout.TabIndex = 4;
            // 
            // text_EndPort
            // 
            this.text_EndPort.Location = new System.Drawing.Point(218, 9);
            this.text_EndPort.Name = "text_EndPort";
            this.text_EndPort.Size = new System.Drawing.Size(54, 22);
            this.text_EndPort.TabIndex = 1;
            // 
            // label_EndPort
            // 
            this.label_EndPort.Location = new System.Drawing.Point(171, 8);
            this.label_EndPort.Name = "label_EndPort";
            this.label_EndPort.Size = new System.Drawing.Size(41, 25);
            this.label_EndPort.TabIndex = 3;
            this.label_EndPort.Text = "<--->";
            this.label_EndPort.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // text_StartPort
            // 
            this.text_StartPort.Location = new System.Drawing.Point(105, 9);
            this.text_StartPort.Name = "text_StartPort";
            this.text_StartPort.Size = new System.Drawing.Size(60, 22);
            this.text_StartPort.TabIndex = 1;
            // 
            // txtMaxWorkingThreads
            // 
            this.txtMaxWorkingThreads.Location = new System.Drawing.Point(170, 272);
            this.txtMaxWorkingThreads.Name = "txtMaxWorkingThreads";
            this.txtMaxWorkingThreads.Size = new System.Drawing.Size(85, 22);
            this.txtMaxWorkingThreads.TabIndex = 50;
            // 
            // llb_MaxThreads
            // 
            this.llb_MaxThreads.Location = new System.Drawing.Point(7, 264);
            this.llb_MaxThreads.Name = "llb_MaxThreads";
            this.llb_MaxThreads.Size = new System.Drawing.Size(157, 30);
            this.llb_MaxThreads.TabIndex = 49;
            this.llb_MaxThreads.Text = "Max working threads:";
            this.llb_MaxThreads.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // timer_ManageThreads
            // 
            this.timer_ManageThreads.Tick += new System.EventHandler(this.timer_ManageThreads_Tick);
            // 
            // btnCancelSearch
            // 
            this.btnCancelSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancelSearch.Location = new System.Drawing.Point(337, 490);
            this.btnCancelSearch.Name = "btnCancelSearch";
            this.btnCancelSearch.Size = new System.Drawing.Size(110, 33);
            this.btnCancelSearch.TabIndex = 48;
            this.btnCancelSearch.Text = "Cancel Search";
            this.btnCancelSearch.UseVisualStyleBackColor = true;
            this.btnCancelSearch.Click += new System.EventHandler(this.btnCancelSearch_Click);
            // 
            // BtnSaveSettings
            // 
            this.BtnSaveSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnSaveSettings.Location = new System.Drawing.Point(472, 490);
            this.BtnSaveSettings.Name = "BtnSaveSettings";
            this.BtnSaveSettings.Size = new System.Drawing.Size(99, 33);
            this.BtnSaveSettings.TabIndex = 47;
            this.BtnSaveSettings.Text = "SaveSettings";
            this.BtnSaveSettings.UseVisualStyleBackColor = true;
            this.BtnSaveSettings.Click += new System.EventHandler(this.BtnSaveSettings_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 506);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 17);
            this.label1.TabIndex = 46;
            this.label1.Text = "Default MySQL port = 3306";
            // 
            // button_Scan
            // 
            this.button_Scan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_Scan.Location = new System.Drawing.Point(212, 490);
            this.button_Scan.Name = "button_Scan";
            this.button_Scan.Size = new System.Drawing.Size(99, 33);
            this.button_Scan.TabIndex = 33;
            this.button_Scan.Text = "Search";
            this.button_Scan.UseVisualStyleBackColor = true;
            this.button_Scan.Click += new System.EventHandler(this.button_Scan_Click);
            // 
            // timer_follow_ScannerThread
            // 
            this.timer_follow_ScannerThread.Interval = 5;
            this.timer_follow_ScannerThread.Tick += new System.EventHandler(this.timer_follow_ScannerThread_Tick);
            // 
            // ComputerName
            // 
            this.ComputerName.Text = "ComputerName";
            this.ComputerName.Width = 147;
            // 
            // colIP
            // 
            this.colIP.Text = "IP";
            this.colIP.Width = 120;
            // 
            // colNumber
            // 
            this.colNumber.Text = "Number";
            // 
            // Panel_EndIP
            // 
            this.Panel_EndIP.Controls.Add(this.EndIP3);
            this.Panel_EndIP.Controls.Add(this.EndIP2);
            this.Panel_EndIP.Controls.Add(this.EndIP0);
            this.Panel_EndIP.Controls.Add(this.EndIP1);
            this.Panel_EndIP.Controls.Add(this.lbl_End_IP);
            this.Panel_EndIP.Location = new System.Drawing.Point(376, 149);
            this.Panel_EndIP.Name = "Panel_EndIP";
            this.Panel_EndIP.Size = new System.Drawing.Size(351, 40);
            this.Panel_EndIP.TabIndex = 38;
            // 
            // EndIP3
            // 
            this.EndIP3.Location = new System.Drawing.Point(157, 8);
            this.EndIP3.Name = "EndIP3";
            this.EndIP3.Size = new System.Drawing.Size(38, 22);
            this.EndIP3.TabIndex = 1;
            // 
            // EndIP2
            // 
            this.EndIP2.Location = new System.Drawing.Point(201, 8);
            this.EndIP2.Name = "EndIP2";
            this.EndIP2.Size = new System.Drawing.Size(38, 22);
            this.EndIP2.TabIndex = 13;
            // 
            // EndIP0
            // 
            this.EndIP0.Location = new System.Drawing.Point(289, 8);
            this.EndIP0.Name = "EndIP0";
            this.EndIP0.Size = new System.Drawing.Size(38, 22);
            this.EndIP0.TabIndex = 17;
            // 
            // EndIP1
            // 
            this.EndIP1.Location = new System.Drawing.Point(245, 8);
            this.EndIP1.Name = "EndIP1";
            this.EndIP1.Size = new System.Drawing.Size(38, 22);
            this.EndIP1.TabIndex = 15;
            // 
            // lbl_End_IP
            // 
            this.lbl_End_IP.Location = new System.Drawing.Point(65, 6);
            this.lbl_End_IP.Name = "lbl_End_IP";
            this.lbl_End_IP.Size = new System.Drawing.Size(77, 25);
            this.lbl_End_IP.TabIndex = 3;
            this.lbl_End_IP.Text = "End IP:";
            this.lbl_End_IP.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // StartIP2
            // 
            this.StartIP2.Location = new System.Drawing.Point(186, 5);
            this.StartIP2.Name = "StartIP2";
            this.StartIP2.Size = new System.Drawing.Size(38, 22);
            this.StartIP2.TabIndex = 13;
            // 
            // Panel_StartIP
            // 
            this.Panel_StartIP.Controls.Add(this.StartIP3);
            this.Panel_StartIP.Controls.Add(this.StartIP2);
            this.Panel_StartIP.Controls.Add(this.StartIP0);
            this.Panel_StartIP.Controls.Add(this.StartIP1);
            this.Panel_StartIP.Controls.Add(this.label2);
            this.Panel_StartIP.Location = new System.Drawing.Point(13, 149);
            this.Panel_StartIP.Name = "Panel_StartIP";
            this.Panel_StartIP.Size = new System.Drawing.Size(349, 40);
            this.Panel_StartIP.TabIndex = 37;
            // 
            // StartIP3
            // 
            this.StartIP3.Location = new System.Drawing.Point(139, 5);
            this.StartIP3.Name = "StartIP3";
            this.StartIP3.Size = new System.Drawing.Size(38, 22);
            this.StartIP3.TabIndex = 1;
            // 
            // StartIP0
            // 
            this.StartIP0.Location = new System.Drawing.Point(274, 5);
            this.StartIP0.Name = "StartIP0";
            this.StartIP0.Size = new System.Drawing.Size(38, 22);
            this.StartIP0.TabIndex = 17;
            // 
            // StartIP1
            // 
            this.StartIP1.Location = new System.Drawing.Point(230, 5);
            this.StartIP1.Name = "StartIP1";
            this.StartIP1.Size = new System.Drawing.Size(38, 22);
            this.StartIP1.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(11, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Start IP:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_Gateway
            // 
            this.lbl_Gateway.Location = new System.Drawing.Point(10, 27);
            this.lbl_Gateway.Name = "lbl_Gateway";
            this.lbl_Gateway.Size = new System.Drawing.Size(75, 30);
            this.lbl_Gateway.TabIndex = 36;
            this.lbl_Gateway.Text = "Gateway:";
            this.lbl_Gateway.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_DNS
            // 
            this.lbl_DNS.Location = new System.Drawing.Point(378, 27);
            this.lbl_DNS.Name = "lbl_DNS";
            this.lbl_DNS.Size = new System.Drawing.Size(63, 35);
            this.lbl_DNS.TabIndex = 35;
            this.lbl_DNS.Text = "DNS:";
            this.lbl_DNS.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label_Process
            // 
            this.label_Process.Location = new System.Drawing.Point(4, 0);
            this.label_Process.Name = "label_Process";
            this.label_Process.Size = new System.Drawing.Size(720, 35);
            this.label_Process.TabIndex = 34;
            this.label_Process.Text = "Press Search button to start searching devices on network";
            // 
            // M1
            // 
            this.M1.Location = new System.Drawing.Point(245, 6);
            this.M1.Name = "M1";
            this.M1.Size = new System.Drawing.Size(38, 22);
            this.M1.TabIndex = 15;
            // 
            // listView_Connections
            // 
            this.listView_Connections.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView_Connections.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colNumber,
            this.colIP,
            this.ComputerName});
            this.listView_Connections.FullRowSelect = true;
            this.listView_Connections.GridLines = true;
            this.listView_Connections.Location = new System.Drawing.Point(10, 300);
            this.listView_Connections.MultiSelect = false;
            this.listView_Connections.Name = "listView_Connections";
            this.listView_Connections.Size = new System.Drawing.Size(717, 178);
            this.listView_Connections.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listView_Connections.TabIndex = 43;
            this.listView_Connections.UseCompatibleStateImageBehavior = false;
            this.listView_Connections.View = System.Windows.Forms.View.Details;
            this.listView_Connections.SelectedIndexChanged += new System.EventHandler(this.listView_Connections_SelectedIndexChanged);
            // 
            // btnSetRangeOnMask
            // 
            this.btnSetRangeOnMask.Location = new System.Drawing.Point(-8, 6);
            this.btnSetRangeOnMask.Name = "btnSetRangeOnMask";
            this.btnSetRangeOnMask.Size = new System.Drawing.Size(159, 26);
            this.btnSetRangeOnMask.TabIndex = 18;
            this.btnSetRangeOnMask.Text = "Set range on mask:";
            this.btnSetRangeOnMask.UseVisualStyleBackColor = true;
            this.btnSetRangeOnMask.Click += new System.EventHandler(this.btnSetRangeOnMask_Click);
            // 
            // M3
            // 
            this.M3.Location = new System.Drawing.Point(157, 6);
            this.M3.Name = "M3";
            this.M3.Size = new System.Drawing.Size(38, 22);
            this.M3.TabIndex = 1;
            // 
            // M2
            // 
            this.M2.Location = new System.Drawing.Point(201, 6);
            this.M2.Name = "M2";
            this.M2.Size = new System.Drawing.Size(38, 22);
            this.M2.TabIndex = 13;
            // 
            // M0
            // 
            this.M0.Location = new System.Drawing.Point(289, 6);
            this.M0.Name = "M0";
            this.M0.Size = new System.Drawing.Size(38, 22);
            this.M0.TabIndex = 17;
            // 
            // textMaxNumberOfIPsToSearchPerThread
            // 
            this.textMaxNumberOfIPsToSearchPerThread.Location = new System.Drawing.Point(629, 269);
            this.textMaxNumberOfIPsToSearchPerThread.Name = "textMaxNumberOfIPsToSearchPerThread";
            this.textMaxNumberOfIPsToSearchPerThread.Size = new System.Drawing.Size(98, 22);
            this.textMaxNumberOfIPsToSearchPerThread.TabIndex = 52;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSetRangeOnMask);
            this.panel1.Controls.Add(this.M3);
            this.panel1.Controls.Add(this.M2);
            this.panel1.Controls.Add(this.M0);
            this.panel1.Controls.Add(this.M1);
            this.panel1.Location = new System.Drawing.Point(376, 111);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(351, 40);
            this.panel1.TabIndex = 41;
            // 
            // SearchLocalNetwork
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.listBox_DNS);
            this.Controls.Add(this.listBox_Gateways);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.txtMaxWorkingThreads);
            this.Controls.Add(this.llb_MaxThreads);
            this.Controls.Add(this.btnCancelSearch);
            this.Controls.Add(this.BtnSaveSettings);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_Scan);
            this.Controls.Add(this.Panel_EndIP);
            this.Controls.Add(this.Panel_StartIP);
            this.Controls.Add(this.lbl_Gateway);
            this.Controls.Add(this.lbl_DNS);
            this.Controls.Add(this.label_Process);
            this.Controls.Add(this.listView_Connections);
            this.Controls.Add(this.textMaxNumberOfIPsToSearchPerThread);
            this.Controls.Add(this.panel1);
            this.Name = "SearchLocalNetwork";
            this.Size = new System.Drawing.Size(738, 533);
            this.Load += new System.EventHandler(this.SearchLocalNetwork_Load);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.Panel_EndIP.ResumeLayout(false);
            this.Panel_EndIP.PerformLayout();
            this.Panel_StartIP.ResumeLayout(false);
            this.Panel_StartIP.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkUsePing;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox IP3;
        private System.Windows.Forms.TextBox IP2;
        private System.Windows.Forms.TextBox IP0;
        private System.Windows.Forms.TextBox IP1;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ListBox listBox_DNS;
        private System.Windows.Forms.ListBox listBox_Gateways;
        private System.Windows.Forms.CheckBox chkPorts;
        private System.Windows.Forms.TextBox TextPingTimeout;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.CheckBox chkPingTimeout;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox chkPortRange;
        private System.Windows.Forms.Label lblTimeout;
        private System.Windows.Forms.TextBox txtCeckPortTimeout;
        private System.Windows.Forms.TextBox text_EndPort;
        private System.Windows.Forms.Label label_EndPort;
        private System.Windows.Forms.TextBox text_StartPort;
        private System.Windows.Forms.TextBox txtMaxWorkingThreads;
        private System.Windows.Forms.Label llb_MaxThreads;
        private System.Windows.Forms.Timer timer_ManageThreads;
        private System.Windows.Forms.Button btnCancelSearch;
        private System.Windows.Forms.Button BtnSaveSettings;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_Scan;
        private System.Windows.Forms.Timer timer_follow_ScannerThread;
        private System.Windows.Forms.ColumnHeader ComputerName;
        private System.Windows.Forms.ColumnHeader colIP;
        private System.Windows.Forms.ColumnHeader colNumber;
        private System.Windows.Forms.Panel Panel_EndIP;
        private System.Windows.Forms.TextBox EndIP3;
        private System.Windows.Forms.TextBox EndIP2;
        private System.Windows.Forms.TextBox EndIP0;
        private System.Windows.Forms.TextBox EndIP1;
        private System.Windows.Forms.Label lbl_End_IP;
        private System.Windows.Forms.TextBox StartIP2;
        private System.Windows.Forms.Panel Panel_StartIP;
        private System.Windows.Forms.TextBox StartIP3;
        private System.Windows.Forms.TextBox StartIP0;
        private System.Windows.Forms.TextBox StartIP1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_Gateway;
        private System.Windows.Forms.Label lbl_DNS;
        private System.Windows.Forms.Label label_Process;
        private System.Windows.Forms.TextBox M1;
        private System.Windows.Forms.ListView listView_Connections;
        private System.Windows.Forms.Button btnSetRangeOnMask;
        private System.Windows.Forms.TextBox M3;
        private System.Windows.Forms.TextBox M2;
        private System.Windows.Forms.TextBox M0;
        private System.Windows.Forms.TextBox textMaxNumberOfIPsToSearchPerThread;
        private System.Windows.Forms.Panel panel1;
    }
}
