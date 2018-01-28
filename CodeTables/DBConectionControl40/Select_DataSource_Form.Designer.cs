namespace DBConnectionControl40
{
    partial class Select_DataSource_Form
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Select_DataSource_Form));
            this.lbl_Select_server_and_press_ok = new System.Windows.Forms.Label();
            this.lbl_Progress = new System.Windows.Forms.Label();
            this.Timer_ShowServers = new System.Windows.Forms.Timer(this.components);
            this.btn_OK = new System.Windows.Forms.Button();
            this.btn_CANCEL = new System.Windows.Forms.Button();
            this.dataGridView_SELECT_SERVER = new System.Windows.Forms.DataGridView();
            this.textBox_SelectedServer = new System.Windows.Forms.TextBox();
            this.lbl_SelectedServer = new System.Windows.Forms.Label();
            this.rdbHostName = new System.Windows.Forms.RadioButton();
            this.rdbIPAddress = new System.Windows.Forms.RadioButton();
            this.searchLocalNetwork = new SearchLocalNetwork.SearchLocalNetwork();
            this.usrc_Help1 = new HUDCMS.usrc_Help();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_SELECT_SERVER)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_Select_server_and_press_ok
            // 
            this.lbl_Select_server_and_press_ok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_Select_server_and_press_ok.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Select_server_and_press_ok.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbl_Select_server_and_press_ok.Location = new System.Drawing.Point(183, 502);
            this.lbl_Select_server_and_press_ok.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_Select_server_and_press_ok.Name = "lbl_Select_server_and_press_ok";
            this.lbl_Select_server_and_press_ok.Size = new System.Drawing.Size(244, 26);
            this.lbl_Select_server_and_press_ok.TabIndex = 9;
            this.lbl_Select_server_and_press_ok.Text = "Select Server and press :";
            this.lbl_Select_server_and_press_ok.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lbl_Progress
            // 
            this.lbl_Progress.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Progress.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Progress.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbl_Progress.Location = new System.Drawing.Point(1, 90);
            this.lbl_Progress.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_Progress.Name = "lbl_Progress";
            this.lbl_Progress.Size = new System.Drawing.Size(578, 170);
            this.lbl_Progress.TabIndex = 8;
            this.lbl_Progress.Text = "Please wait\r\nwhile browsing local network for database servers...\r\n";
            this.lbl_Progress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Timer_ShowServers
            // 
            this.Timer_ShowServers.Interval = 10;
            this.Timer_ShowServers.Tick += new System.EventHandler(this.Timer_ShowServers_Tick);
            // 
            // btn_OK
            // 
            this.btn_OK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_OK.Location = new System.Drawing.Point(428, 497);
            this.btn_OK.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(54, 29);
            this.btn_OK.TabIndex = 7;
            this.btn_OK.Text = "OK";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // btn_CANCEL
            // 
            this.btn_CANCEL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_CANCEL.Location = new System.Drawing.Point(499, 497);
            this.btn_CANCEL.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_CANCEL.Name = "btn_CANCEL";
            this.btn_CANCEL.Size = new System.Drawing.Size(51, 28);
            this.btn_CANCEL.TabIndex = 6;
            this.btn_CANCEL.Text = "Cancel";
            this.btn_CANCEL.UseVisualStyleBackColor = true;
            this.btn_CANCEL.Click += new System.EventHandler(this.btn_CANCEL_Click);
            // 
            // dataGridView_SELECT_SERVER
            // 
            this.dataGridView_SELECT_SERVER.AllowUserToAddRows = false;
            this.dataGridView_SELECT_SERVER.AllowUserToDeleteRows = false;
            this.dataGridView_SELECT_SERVER.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_SELECT_SERVER.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_SELECT_SERVER.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dataGridView_SELECT_SERVER.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_SELECT_SERVER.Location = new System.Drawing.Point(9, 10);
            this.dataGridView_SELECT_SERVER.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dataGridView_SELECT_SERVER.MultiSelect = false;
            this.dataGridView_SELECT_SERVER.Name = "dataGridView_SELECT_SERVER";
            this.dataGridView_SELECT_SERVER.ReadOnly = true;
            this.dataGridView_SELECT_SERVER.RowTemplate.Height = 24;
            this.dataGridView_SELECT_SERVER.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_SELECT_SERVER.Size = new System.Drawing.Size(562, 388);
            this.dataGridView_SELECT_SERVER.StandardTab = true;
            this.dataGridView_SELECT_SERVER.TabIndex = 5;
            this.dataGridView_SELECT_SERVER.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_SELECT_SERVER_RowEnter);
            this.dataGridView_SELECT_SERVER.SelectionChanged += new System.EventHandler(this.dataGridView_SELECT_SERVER_SelectionChanged);
            // 
            // textBox_SelectedServer
            // 
            this.textBox_SelectedServer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBox_SelectedServer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.textBox_SelectedServer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_SelectedServer.Location = new System.Drawing.Point(146, 468);
            this.textBox_SelectedServer.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox_SelectedServer.Name = "textBox_SelectedServer";
            this.textBox_SelectedServer.Size = new System.Drawing.Size(404, 23);
            this.textBox_SelectedServer.TabIndex = 11;
            // 
            // lbl_SelectedServer
            // 
            this.lbl_SelectedServer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_SelectedServer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_SelectedServer.Location = new System.Drawing.Point(10, 468);
            this.lbl_SelectedServer.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_SelectedServer.Name = "lbl_SelectedServer";
            this.lbl_SelectedServer.Size = new System.Drawing.Size(131, 24);
            this.lbl_SelectedServer.TabIndex = 12;
            this.lbl_SelectedServer.Text = "Selected Server = ";
            // 
            // rdbHostName
            // 
            this.rdbHostName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rdbHostName.AutoSize = true;
            this.rdbHostName.Location = new System.Drawing.Point(104, 503);
            this.rdbHostName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rdbHostName.Name = "rdbHostName";
            this.rdbHostName.Size = new System.Drawing.Size(78, 17);
            this.rdbHostName.TabIndex = 14;
            this.rdbHostName.TabStop = true;
            this.rdbHostName.Text = "Host Name";
            this.rdbHostName.UseVisualStyleBackColor = true;
            this.rdbHostName.CheckedChanged += new System.EventHandler(this.rdbHostName_CheckedChanged);
            // 
            // rdbIPAddress
            // 
            this.rdbIPAddress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rdbIPAddress.AutoSize = true;
            this.rdbIPAddress.Location = new System.Drawing.Point(14, 503);
            this.rdbIPAddress.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rdbIPAddress.Name = "rdbIPAddress";
            this.rdbIPAddress.Size = new System.Drawing.Size(76, 17);
            this.rdbIPAddress.TabIndex = 15;
            this.rdbIPAddress.TabStop = true;
            this.rdbIPAddress.Text = "IP Address";
            this.rdbIPAddress.UseVisualStyleBackColor = true;
            this.rdbIPAddress.CheckedChanged += new System.EventHandler(this.rdbIPAddress_CheckedChanged);
            // 
            // searchLocalNetwork
            // 
            this.searchLocalNetwork.Location = new System.Drawing.Point(6, 10);
            this.searchLocalNetwork.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.searchLocalNetwork.Name = "searchLocalNetwork";
            this.searchLocalNetwork.Size = new System.Drawing.Size(573, 461);
            this.searchLocalNetwork.TabIndex = 16;
            // 
            // usrc_Help1
            // 
            this.usrc_Help1.Location = new System.Drawing.Point(518, 10);
            this.usrc_Help1.Margin = new System.Windows.Forms.Padding(4);
            this.usrc_Help1.Name = "usrc_Help1";
            this.usrc_Help1.Size = new System.Drawing.Size(50, 23);
            this.usrc_Help1.TabIndex = 20;
            // 
            // Select_DataSource_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 535);
            this.Controls.Add(this.usrc_Help1);
            this.Controls.Add(this.searchLocalNetwork);
            this.Controls.Add(this.rdbIPAddress);
            this.Controls.Add(this.rdbHostName);
            this.Controls.Add(this.lbl_SelectedServer);
            this.Controls.Add(this.textBox_SelectedServer);
            this.Controls.Add(this.lbl_Select_server_and_press_ok);
            this.Controls.Add(this.lbl_Progress);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.btn_CANCEL);
            this.Controls.Add(this.dataGridView_SELECT_SERVER);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Select_DataSource_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Select_Server_Form";
            this.Activated += new System.EventHandler(this.Select_DataSource_Form_Activated);
            this.Load += new System.EventHandler(this.Select_Server_Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_SELECT_SERVER)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_Select_server_and_press_ok;
        private System.Windows.Forms.Label lbl_Progress;
        private System.Windows.Forms.Timer Timer_ShowServers;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Button btn_CANCEL;
        private System.Windows.Forms.DataGridView dataGridView_SELECT_SERVER;
        private System.Windows.Forms.TextBox textBox_SelectedServer;
        private System.Windows.Forms.Label lbl_SelectedServer;
        private System.Windows.Forms.RadioButton rdbHostName;
        private System.Windows.Forms.RadioButton rdbIPAddress;
        private SearchLocalNetwork.SearchLocalNetwork searchLocalNetwork;
        private HUDCMS.usrc_Help usrc_Help1;
    }
}