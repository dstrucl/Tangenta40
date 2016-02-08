namespace FiscalVerificationOfInvoices_SLO
{
    partial class Form_Settings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Settings));
            this.chk_DebugAndTest = new System.Windows.Forms.CheckBox();
            this.lbl_timeOutInSec = new System.Windows.Forms.Label();
            this.nm_UpDown_timeOutInSec = new System.Windows.Forms.NumericUpDown();
            this.btn_OK = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.nm_TimeToShoqSuccessfulFURS_Transaction = new System.Windows.Forms.NumericUpDown();
            this.lbl_TimeToShowFURSSuccessfulResult = new System.Windows.Forms.Label();
            this.nm_QRSizeWidth = new System.Windows.Forms.NumericUpDown();
            this.lbl_QRSizeWidth = new System.Windows.Forms.Label();
            this.rdb_FURS_Environment = new System.Windows.Forms.RadioButton();
            this.rdb_FURS_TEST_Environment = new System.Windows.Forms.RadioButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.txt_SalesBookInvoice_Current_SerialNumber = new System.Windows.Forms.TextBox();
            this.grp_SalesBookInvoice = new System.Windows.Forms.GroupBox();
            this.lbl_SalesBookInvoice_Current_SerialNumber = new System.Windows.Forms.Label();
            this.lbl_SalesBookInvoice_Last_SetNumber = new System.Windows.Forms.Label();
            this.lbl_SalesBookInvoice_SerialNumber_Format = new System.Windows.Forms.Label();
            this.txt_SalesBookInvoice_SerialNumber_Format = new System.Windows.Forms.TextBox();
            this.lbl_SalesBookInvoice_NumberOfAllSetsWithinOneBook = new System.Windows.Forms.Label();
            this.nmUpDn_SalesBookInvoice_NumberOfAllSetsWithinOneBook = new System.Windows.Forms.NumericUpDown();
            this.usrc_FURS_environment_settings = new FiscalVerificationOfInvoices_SLO.usrc_FURS_environment_settings();
            this.usrc_FURS_environment_settings_TEST = new FiscalVerificationOfInvoices_SLO.usrc_FURS_environment_settings();
            this.nm_UpDn_SalesBookInvoice_Last_SetNumber = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nm_UpDown_timeOutInSec)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nm_TimeToShoqSuccessfulFURS_Transaction)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nm_QRSizeWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.grp_SalesBookInvoice.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmUpDn_SalesBookInvoice_NumberOfAllSetsWithinOneBook)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nm_UpDn_SalesBookInvoice_Last_SetNumber)).BeginInit();
            this.SuspendLayout();
            // 
            // chk_DebugAndTest
            // 
            this.chk_DebugAndTest.AutoSize = true;
            this.chk_DebugAndTest.Location = new System.Drawing.Point(345, 36);
            this.chk_DebugAndTest.Name = "chk_DebugAndTest";
            this.chk_DebugAndTest.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chk_DebugAndTest.Size = new System.Drawing.Size(91, 17);
            this.chk_DebugAndTest.TabIndex = 0;
            this.chk_DebugAndTest.Text = "Debug && Test";
            this.chk_DebugAndTest.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.chk_DebugAndTest.UseVisualStyleBackColor = true;
            // 
            // lbl_timeOutInSec
            // 
            this.lbl_timeOutInSec.AutoSize = true;
            this.lbl_timeOutInSec.Location = new System.Drawing.Point(11, 36);
            this.lbl_timeOutInSec.Name = "lbl_timeOutInSec";
            this.lbl_timeOutInSec.Size = new System.Drawing.Size(252, 13);
            this.lbl_timeOutInSec.TabIndex = 10;
            this.lbl_timeOutInSec.Text = "Dovoljen čas (\"timeout\") za transakcijo v sekundah:";
            // 
            // nm_UpDown_timeOutInSec
            // 
            this.nm_UpDown_timeOutInSec.Location = new System.Drawing.Point(279, 33);
            this.nm_UpDown_timeOutInSec.Maximum = new decimal(new int[] {
            120,
            0,
            0,
            0});
            this.nm_UpDown_timeOutInSec.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.nm_UpDown_timeOutInSec.Name = "nm_UpDown_timeOutInSec";
            this.nm_UpDown_timeOutInSec.Size = new System.Drawing.Size(49, 20);
            this.nm_UpDown_timeOutInSec.TabIndex = 11;
            this.nm_UpDown_timeOutInSec.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // btn_OK
            // 
            this.btn_OK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_OK.Location = new System.Drawing.Point(8, 824);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(87, 25);
            this.btn_OK.TabIndex = 12;
            this.btn_OK.Text = "OK";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Cancel.Location = new System.Drawing.Point(129, 824);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(87, 25);
            this.btn_Cancel.TabIndex = 13;
            this.btn_Cancel.Text = "PREKINI";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // nm_TimeToShoqSuccessfulFURS_Transaction
            // 
            this.nm_TimeToShoqSuccessfulFURS_Transaction.Location = new System.Drawing.Point(279, 8);
            this.nm_TimeToShoqSuccessfulFURS_Transaction.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nm_TimeToShoqSuccessfulFURS_Transaction.Name = "nm_TimeToShoqSuccessfulFURS_Transaction";
            this.nm_TimeToShoqSuccessfulFURS_Transaction.Size = new System.Drawing.Size(49, 20);
            this.nm_TimeToShoqSuccessfulFURS_Transaction.TabIndex = 15;
            this.nm_TimeToShoqSuccessfulFURS_Transaction.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // lbl_TimeToShowFURSSuccessfulResult
            // 
            this.lbl_TimeToShowFURSSuccessfulResult.AutoSize = true;
            this.lbl_TimeToShowFURSSuccessfulResult.Location = new System.Drawing.Point(11, 10);
            this.lbl_TimeToShowFURSSuccessfulResult.Name = "lbl_TimeToShowFURSSuccessfulResult";
            this.lbl_TimeToShowFURSSuccessfulResult.Size = new System.Drawing.Size(253, 13);
            this.lbl_TimeToShowFURSSuccessfulResult.TabIndex = 14;
            this.lbl_TimeToShowFURSSuccessfulResult.Text = "Čas prikaza uspešne FURS transakcije v sekundah:";
            // 
            // nm_QRSizeWidth
            // 
            this.nm_QRSizeWidth.Location = new System.Drawing.Point(431, 8);
            this.nm_QRSizeWidth.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nm_QRSizeWidth.Minimum = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.nm_QRSizeWidth.Name = "nm_QRSizeWidth";
            this.nm_QRSizeWidth.Size = new System.Drawing.Size(71, 20);
            this.nm_QRSizeWidth.TabIndex = 17;
            this.nm_QRSizeWidth.Value = new decimal(new int[] {
            128,
            0,
            0,
            0});
            // 
            // lbl_QRSizeWidth
            // 
            this.lbl_QRSizeWidth.AutoSize = true;
            this.lbl_QRSizeWidth.Location = new System.Drawing.Point(342, 11);
            this.lbl_QRSizeWidth.Name = "lbl_QRSizeWidth";
            this.lbl_QRSizeWidth.Size = new System.Drawing.Size(82, 13);
            this.lbl_QRSizeWidth.TabIndex = 16;
            this.lbl_QRSizeWidth.Text = "Širina QR kode:";
            // 
            // rdb_FURS_Environment
            // 
            this.rdb_FURS_Environment.AutoSize = true;
            this.rdb_FURS_Environment.Location = new System.Drawing.Point(14, 58);
            this.rdb_FURS_Environment.Name = "rdb_FURS_Environment";
            this.rdb_FURS_Environment.Size = new System.Drawing.Size(140, 17);
            this.rdb_FURS_Environment.TabIndex = 20;
            this.rdb_FURS_Environment.TabStop = true;
            this.rdb_FURS_Environment.Text = "rdb_FURS_Environment";
            this.rdb_FURS_Environment.UseVisualStyleBackColor = true;
            // 
            // rdb_FURS_TEST_Environment
            // 
            this.rdb_FURS_TEST_Environment.AutoSize = true;
            this.rdb_FURS_TEST_Environment.Location = new System.Drawing.Point(160, 59);
            this.rdb_FURS_TEST_Environment.Name = "rdb_FURS_TEST_Environment";
            this.rdb_FURS_TEST_Environment.Size = new System.Drawing.Size(174, 17);
            this.rdb_FURS_TEST_Environment.TabIndex = 21;
            this.rdb_FURS_TEST_Environment.TabStop = true;
            this.rdb_FURS_TEST_Environment.Text = "rdb_FURS_TEST_Environment";
            this.rdb_FURS_TEST_Environment.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Location = new System.Drawing.Point(8, 79);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.usrc_FURS_environment_settings);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.usrc_FURS_environment_settings_TEST);
            this.splitContainer1.Size = new System.Drawing.Size(910, 739);
            this.splitContainer1.SplitterDistance = 363;
            this.splitContainer1.TabIndex = 22;
            // 
            // txt_SalesBookInvoice_Current_SerialNumber
            // 
            this.txt_SalesBookInvoice_Current_SerialNumber.Location = new System.Drawing.Point(126, 18);
            this.txt_SalesBookInvoice_Current_SerialNumber.Name = "txt_SalesBookInvoice_Current_SerialNumber";
            this.txt_SalesBookInvoice_Current_SerialNumber.Size = new System.Drawing.Size(90, 20);
            this.txt_SalesBookInvoice_Current_SerialNumber.TabIndex = 24;
            this.txt_SalesBookInvoice_Current_SerialNumber.Text = "1234-1234567";
            // 
            // grp_SalesBookInvoice
            // 
            this.grp_SalesBookInvoice.Controls.Add(this.nm_UpDn_SalesBookInvoice_Last_SetNumber);
            this.grp_SalesBookInvoice.Controls.Add(this.nmUpDn_SalesBookInvoice_NumberOfAllSetsWithinOneBook);
            this.grp_SalesBookInvoice.Controls.Add(this.lbl_SalesBookInvoice_NumberOfAllSetsWithinOneBook);
            this.grp_SalesBookInvoice.Controls.Add(this.lbl_SalesBookInvoice_SerialNumber_Format);
            this.grp_SalesBookInvoice.Controls.Add(this.txt_SalesBookInvoice_SerialNumber_Format);
            this.grp_SalesBookInvoice.Controls.Add(this.lbl_SalesBookInvoice_Last_SetNumber);
            this.grp_SalesBookInvoice.Controls.Add(this.lbl_SalesBookInvoice_Current_SerialNumber);
            this.grp_SalesBookInvoice.Controls.Add(this.txt_SalesBookInvoice_Current_SerialNumber);
            this.grp_SalesBookInvoice.Location = new System.Drawing.Point(508, 6);
            this.grp_SalesBookInvoice.Name = "grp_SalesBookInvoice";
            this.grp_SalesBookInvoice.Size = new System.Drawing.Size(405, 69);
            this.grp_SalesBookInvoice.TabIndex = 27;
            this.grp_SalesBookInvoice.TabStop = false;
            this.grp_SalesBookInvoice.Text = "Vezana knjiga računov";
            // 
            // lbl_SalesBookInvoice_Current_SerialNumber
            // 
            this.lbl_SalesBookInvoice_Current_SerialNumber.AutoSize = true;
            this.lbl_SalesBookInvoice_Current_SerialNumber.Location = new System.Drawing.Point(2, 22);
            this.lbl_SalesBookInvoice_Current_SerialNumber.Name = "lbl_SalesBookInvoice_Current_SerialNumber";
            this.lbl_SalesBookInvoice_Current_SerialNumber.Size = new System.Drawing.Size(121, 13);
            this.lbl_SalesBookInvoice_Current_SerialNumber.TabIndex = 28;
            this.lbl_SalesBookInvoice_Current_SerialNumber.Text = "Tekoča serijska številka";
            this.lbl_SalesBookInvoice_Current_SerialNumber.Click += new System.EventHandler(this.label1_Click);
            // 
            // lbl_SalesBookInvoice_Last_SetNumber
            // 
            this.lbl_SalesBookInvoice_Last_SetNumber.AutoSize = true;
            this.lbl_SalesBookInvoice_Last_SetNumber.Location = new System.Drawing.Point(4, 48);
            this.lbl_SalesBookInvoice_Last_SetNumber.Name = "lbl_SalesBookInvoice_Last_SetNumber";
            this.lbl_SalesBookInvoice_Last_SetNumber.Size = new System.Drawing.Size(102, 13);
            this.lbl_SalesBookInvoice_Last_SetNumber.TabIndex = 29;
            this.lbl_SalesBookInvoice_Last_SetNumber.Text = "Zadnja številka seta";
            // 
            // lbl_SalesBookInvoice_SerialNumber_Format
            // 
            this.lbl_SalesBookInvoice_SerialNumber_Format.AutoSize = true;
            this.lbl_SalesBookInvoice_SerialNumber_Format.Location = new System.Drawing.Point(229, 21);
            this.lbl_SalesBookInvoice_SerialNumber_Format.Name = "lbl_SalesBookInvoice_SerialNumber_Format";
            this.lbl_SalesBookInvoice_SerialNumber_Format.Size = new System.Drawing.Size(42, 13);
            this.lbl_SalesBookInvoice_SerialNumber_Format.TabIndex = 31;
            this.lbl_SalesBookInvoice_SerialNumber_Format.Text = "Format:";
            // 
            // txt_SalesBookInvoice_SerialNumber_Format
            // 
            this.txt_SalesBookInvoice_SerialNumber_Format.Location = new System.Drawing.Point(273, 18);
            this.txt_SalesBookInvoice_SerialNumber_Format.Name = "txt_SalesBookInvoice_SerialNumber_Format";
            this.txt_SalesBookInvoice_SerialNumber_Format.Size = new System.Drawing.Size(126, 20);
            this.txt_SalesBookInvoice_SerialNumber_Format.TabIndex = 30;
            this.txt_SalesBookInvoice_SerialNumber_Format.Text = "1234-1234567";
            // 
            // lbl_SalesBookInvoice_NumberOfAllSetsWithinOneBook
            // 
            this.lbl_SalesBookInvoice_NumberOfAllSetsWithinOneBook.AutoSize = true;
            this.lbl_SalesBookInvoice_NumberOfAllSetsWithinOneBook.Location = new System.Drawing.Point(163, 48);
            this.lbl_SalesBookInvoice_NumberOfAllSetsWithinOneBook.Name = "lbl_SalesBookInvoice_NumberOfAllSetsWithinOneBook";
            this.lbl_SalesBookInvoice_NumberOfAllSetsWithinOneBook.Size = new System.Drawing.Size(180, 13);
            this.lbl_SalesBookInvoice_NumberOfAllSetsWithinOneBook.TabIndex = 33;
            this.lbl_SalesBookInvoice_NumberOfAllSetsWithinOneBook.Text = "Število vseh setov znotraj ene knjige";
            // 
            // nmUpDn_SalesBookInvoice_NumberOfAllSetsWithinOneBook
            // 
            this.nmUpDn_SalesBookInvoice_NumberOfAllSetsWithinOneBook.Location = new System.Drawing.Point(346, 45);
            this.nmUpDn_SalesBookInvoice_NumberOfAllSetsWithinOneBook.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nmUpDn_SalesBookInvoice_NumberOfAllSetsWithinOneBook.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmUpDn_SalesBookInvoice_NumberOfAllSetsWithinOneBook.Name = "nmUpDn_SalesBookInvoice_NumberOfAllSetsWithinOneBook";
            this.nmUpDn_SalesBookInvoice_NumberOfAllSetsWithinOneBook.Size = new System.Drawing.Size(54, 20);
            this.nmUpDn_SalesBookInvoice_NumberOfAllSetsWithinOneBook.TabIndex = 34;
            this.nmUpDn_SalesBookInvoice_NumberOfAllSetsWithinOneBook.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // usrc_FURS_environment_settings
            // 
            this.usrc_FURS_environment_settings.AutoScroll = true;
            this.usrc_FURS_environment_settings.BackColor = System.Drawing.SystemColors.Control;
            this.usrc_FURS_environment_settings.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.usrc_FURS_environment_settings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.usrc_FURS_environment_settings.Location = new System.Drawing.Point(0, 0);
            this.usrc_FURS_environment_settings.Name = "usrc_FURS_environment_settings";
            this.usrc_FURS_environment_settings.Size = new System.Drawing.Size(906, 359);
            this.usrc_FURS_environment_settings.TabIndex = 18;
            // 
            // usrc_FURS_environment_settings_TEST
            // 
            this.usrc_FURS_environment_settings_TEST.AutoScroll = true;
            this.usrc_FURS_environment_settings_TEST.BackColor = System.Drawing.SystemColors.Control;
            this.usrc_FURS_environment_settings_TEST.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.usrc_FURS_environment_settings_TEST.Dock = System.Windows.Forms.DockStyle.Fill;
            this.usrc_FURS_environment_settings_TEST.Location = new System.Drawing.Point(0, 0);
            this.usrc_FURS_environment_settings_TEST.Name = "usrc_FURS_environment_settings_TEST";
            this.usrc_FURS_environment_settings_TEST.Size = new System.Drawing.Size(906, 368);
            this.usrc_FURS_environment_settings_TEST.TabIndex = 19;
            // 
            // nm_UpDn_SalesBookInvoice_Last_SetNumber
            // 
            this.nm_UpDn_SalesBookInvoice_Last_SetNumber.Location = new System.Drawing.Point(107, 45);
            this.nm_UpDn_SalesBookInvoice_Last_SetNumber.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nm_UpDn_SalesBookInvoice_Last_SetNumber.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nm_UpDn_SalesBookInvoice_Last_SetNumber.Name = "nm_UpDn_SalesBookInvoice_Last_SetNumber";
            this.nm_UpDn_SalesBookInvoice_Last_SetNumber.Size = new System.Drawing.Size(51, 20);
            this.nm_UpDn_SalesBookInvoice_Last_SetNumber.TabIndex = 35;
            this.nm_UpDn_SalesBookInvoice_Last_SetNumber.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // Form_Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(925, 858);
            this.Controls.Add(this.grp_SalesBookInvoice);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.rdb_FURS_TEST_Environment);
            this.Controls.Add(this.rdb_FURS_Environment);
            this.Controls.Add(this.nm_QRSizeWidth);
            this.Controls.Add(this.lbl_QRSizeWidth);
            this.Controls.Add(this.nm_TimeToShoqSuccessfulFURS_Transaction);
            this.Controls.Add(this.lbl_TimeToShowFURSSuccessfulResult);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.nm_UpDown_timeOutInSec);
            this.Controls.Add(this.lbl_timeOutInSec);
            this.Controls.Add(this.chk_DebugAndTest);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_Settings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nastavitve za komunikacijo z DAVČNO UPRAVO";
            ((System.ComponentModel.ISupportInitialize)(this.nm_UpDown_timeOutInSec)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nm_TimeToShoqSuccessfulFURS_Transaction)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nm_QRSizeWidth)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.grp_SalesBookInvoice.ResumeLayout(false);
            this.grp_SalesBookInvoice.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmUpDn_SalesBookInvoice_NumberOfAllSetsWithinOneBook)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nm_UpDn_SalesBookInvoice_Last_SetNumber)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chk_DebugAndTest;
        private System.Windows.Forms.Label lbl_timeOutInSec;
        private System.Windows.Forms.NumericUpDown nm_UpDown_timeOutInSec;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.NumericUpDown nm_TimeToShoqSuccessfulFURS_Transaction;
        private System.Windows.Forms.Label lbl_TimeToShowFURSSuccessfulResult;
        private System.Windows.Forms.NumericUpDown nm_QRSizeWidth;
        private System.Windows.Forms.Label lbl_QRSizeWidth;
        private usrc_FURS_environment_settings usrc_FURS_environment_settings;
        private usrc_FURS_environment_settings usrc_FURS_environment_settings_TEST;
        private System.Windows.Forms.RadioButton rdb_FURS_Environment;
        private System.Windows.Forms.RadioButton rdb_FURS_TEST_Environment;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox txt_SalesBookInvoice_Current_SerialNumber;
        private System.Windows.Forms.GroupBox grp_SalesBookInvoice;
        private System.Windows.Forms.Label lbl_SalesBookInvoice_Current_SerialNumber;
        private System.Windows.Forms.Label lbl_SalesBookInvoice_Last_SetNumber;
        private System.Windows.Forms.Label lbl_SalesBookInvoice_SerialNumber_Format;
        private System.Windows.Forms.TextBox txt_SalesBookInvoice_SerialNumber_Format;
        private System.Windows.Forms.NumericUpDown nmUpDn_SalesBookInvoice_NumberOfAllSetsWithinOneBook;
        private System.Windows.Forms.Label lbl_SalesBookInvoice_NumberOfAllSetsWithinOneBook;
        private System.Windows.Forms.NumericUpDown nm_UpDn_SalesBookInvoice_Last_SetNumber;
    }
}