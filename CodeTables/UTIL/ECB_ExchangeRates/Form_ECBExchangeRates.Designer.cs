namespace ECB_ExchangeRates
{
    partial class Form_ECBExchangeRates
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_ECBExchangeRates));
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.lblRef = new System.Windows.Forms.Label();
            this.lbl_To = new System.Windows.Forms.Label();
            this.lbl_From = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_Calculate = new System.Windows.Forms.Button();
            this.txtHowMany = new System.Windows.Forms.TextBox();
            this.txtBelob = new System.Windows.Forms.TextBox();
            this.lbl_ToCountryExchange = new System.Windows.Forms.Label();
            this.lbl_FromCountryExchange = new System.Windows.Forms.Label();
            this.lbl_Date = new System.Windows.Forms.Label();
            this.cmbToCountry = new System.Windows.Forms.ComboBox();
            this.cmbFromCountry = new System.Windows.Forms.ComboBox();
            this.cmbDate = new System.Windows.Forms.ComboBox();
            this.grp_ExchangeRateProvision = new System.Windows.Forms.GroupBox();
            this.rdb_0 = new System.Windows.Forms.RadioButton();
            this.rdb_1 = new System.Windows.Forms.RadioButton();
            this.rdb_2 = new System.Windows.Forms.RadioButton();
            this.rdb_2_5 = new System.Windows.Forms.RadioButton();
            this.rdb_3 = new System.Windows.Forms.RadioButton();
            this.rdb_8 = new System.Windows.Forms.RadioButton();
            this.rdb_7 = new System.Windows.Forms.RadioButton();
            this.rdb_6 = new System.Windows.Forms.RadioButton();
            this.rdb_5 = new System.Windows.Forms.RadioButton();
            this.rdb_4 = new System.Windows.Forms.RadioButton();
            this.rdb_30 = new System.Windows.Forms.RadioButton();
            this.rdb_25 = new System.Windows.Forms.RadioButton();
            this.rdb_20 = new System.Windows.Forms.RadioButton();
            this.rdb_15 = new System.Windows.Forms.RadioButton();
            this.rdb_10 = new System.Windows.Forms.RadioButton();
            this.nmUpDn_ExchangeRateProvision = new System.Windows.Forms.NumericUpDown();
            this.rdb_nmUpDn = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.grp_ExchangeRateProvision.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmUpDn_ExchangeRateProvision)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGrid1
            // 
            this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid1.CaptionBackColor = System.Drawing.SystemColors.HighlightText;
            this.dataGrid1.CaptionForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.CaptionText = "Exchange Rate pr. day";
            this.dataGrid1.DataMember = "";
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(4, 37);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new System.Drawing.Size(829, 429);
            this.dataGrid1.TabIndex = 1;
            // 
            // lblRef
            // 
            this.lblRef.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblRef.Location = new System.Drawing.Point(12, 9);
            this.lblRef.Name = "lblRef";
            this.lblRef.Size = new System.Drawing.Size(620, 23);
            this.lblRef.TabIndex = 15;
            this.lblRef.Text = "Reference :";
            // 
            // lbl_To
            // 
            this.lbl_To.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_To.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbl_To.Location = new System.Drawing.Point(356, 519);
            this.lbl_To.Name = "lbl_To";
            this.lbl_To.Size = new System.Drawing.Size(40, 24);
            this.lbl_To.TabIndex = 28;
            this.lbl_To.Text = "To";
            // 
            // lbl_From
            // 
            this.lbl_From.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_From.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbl_From.Location = new System.Drawing.Point(356, 479);
            this.lbl_From.Name = "lbl_From";
            this.lbl_From.Size = new System.Drawing.Size(40, 23);
            this.lbl_From.TabIndex = 27;
            this.lbl_From.Text = "From";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(510, 519);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 23);
            this.label5.TabIndex = 26;
            this.label5.Text = "---";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(510, 479);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 23);
            this.label4.TabIndex = 25;
            this.label4.Text = "---";
            // 
            // btn_Calculate
            // 
            this.btn_Calculate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Calculate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btn_Calculate.Location = new System.Drawing.Point(404, 551);
            this.btn_Calculate.Name = "btn_Calculate";
            this.btn_Calculate.Size = new System.Drawing.Size(112, 23);
            this.btn_Calculate.TabIndex = 24;
            this.btn_Calculate.Text = "Calculate";
            this.btn_Calculate.Click += new System.EventHandler(this.btnCalculat_Click);
            // 
            // txtHowMany
            // 
            this.txtHowMany.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtHowMany.Location = new System.Drawing.Point(404, 519);
            this.txtHowMany.Name = "txtHowMany";
            this.txtHowMany.ReadOnly = true;
            this.txtHowMany.Size = new System.Drawing.Size(100, 20);
            this.txtHowMany.TabIndex = 23;
            // 
            // txtBelob
            // 
            this.txtBelob.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtBelob.Location = new System.Drawing.Point(404, 479);
            this.txtBelob.Name = "txtBelob";
            this.txtBelob.Size = new System.Drawing.Size(100, 20);
            this.txtBelob.TabIndex = 22;
            this.txtBelob.Text = "100,00";
            // 
            // lbl_ToCountryExchange
            // 
            this.lbl_ToCountryExchange.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_ToCountryExchange.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbl_ToCountryExchange.Location = new System.Drawing.Point(212, 527);
            this.lbl_ToCountryExchange.Name = "lbl_ToCountryExchange";
            this.lbl_ToCountryExchange.Size = new System.Drawing.Size(128, 16);
            this.lbl_ToCountryExchange.TabIndex = 21;
            this.lbl_ToCountryExchange.Text = "To County exchange :";
            // 
            // lbl_FromCountryExchange
            // 
            this.lbl_FromCountryExchange.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_FromCountryExchange.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbl_FromCountryExchange.Location = new System.Drawing.Point(60, 527);
            this.lbl_FromCountryExchange.Name = "lbl_FromCountryExchange";
            this.lbl_FromCountryExchange.Size = new System.Drawing.Size(128, 16);
            this.lbl_FromCountryExchange.TabIndex = 20;
            this.lbl_FromCountryExchange.Text = "From County exchange :";
            // 
            // lbl_Date
            // 
            this.lbl_Date.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_Date.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbl_Date.Location = new System.Drawing.Point(12, 479);
            this.lbl_Date.Name = "lbl_Date";
            this.lbl_Date.Size = new System.Drawing.Size(100, 16);
            this.lbl_Date.TabIndex = 19;
            this.lbl_Date.Text = "Date :";
            // 
            // cmbToCountry
            // 
            this.cmbToCountry.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmbToCountry.ItemHeight = 13;
            this.cmbToCountry.Location = new System.Drawing.Point(212, 543);
            this.cmbToCountry.Name = "cmbToCountry";
            this.cmbToCountry.Size = new System.Drawing.Size(128, 21);
            this.cmbToCountry.TabIndex = 18;
            // 
            // cmbFromCountry
            // 
            this.cmbFromCountry.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmbFromCountry.ItemHeight = 13;
            this.cmbFromCountry.Location = new System.Drawing.Point(60, 543);
            this.cmbFromCountry.Name = "cmbFromCountry";
            this.cmbFromCountry.Size = new System.Drawing.Size(128, 21);
            this.cmbFromCountry.TabIndex = 17;
            // 
            // cmbDate
            // 
            this.cmbDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmbDate.ItemHeight = 13;
            this.cmbDate.Location = new System.Drawing.Point(12, 495);
            this.cmbDate.Name = "cmbDate";
            this.cmbDate.Size = new System.Drawing.Size(160, 21);
            this.cmbDate.TabIndex = 16;
            // 
            // grp_ExchangeRateProvision
            // 
            this.grp_ExchangeRateProvision.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grp_ExchangeRateProvision.Controls.Add(this.rdb_nmUpDn);
            this.grp_ExchangeRateProvision.Controls.Add(this.nmUpDn_ExchangeRateProvision);
            this.grp_ExchangeRateProvision.Controls.Add(this.rdb_30);
            this.grp_ExchangeRateProvision.Controls.Add(this.rdb_25);
            this.grp_ExchangeRateProvision.Controls.Add(this.rdb_20);
            this.grp_ExchangeRateProvision.Controls.Add(this.rdb_15);
            this.grp_ExchangeRateProvision.Controls.Add(this.rdb_10);
            this.grp_ExchangeRateProvision.Controls.Add(this.rdb_8);
            this.grp_ExchangeRateProvision.Controls.Add(this.rdb_7);
            this.grp_ExchangeRateProvision.Controls.Add(this.rdb_6);
            this.grp_ExchangeRateProvision.Controls.Add(this.rdb_5);
            this.grp_ExchangeRateProvision.Controls.Add(this.rdb_4);
            this.grp_ExchangeRateProvision.Controls.Add(this.rdb_3);
            this.grp_ExchangeRateProvision.Controls.Add(this.rdb_2_5);
            this.grp_ExchangeRateProvision.Controls.Add(this.rdb_2);
            this.grp_ExchangeRateProvision.Controls.Add(this.rdb_1);
            this.grp_ExchangeRateProvision.Controls.Add(this.rdb_0);
            this.grp_ExchangeRateProvision.Location = new System.Drawing.Point(560, 472);
            this.grp_ExchangeRateProvision.Name = "grp_ExchangeRateProvision";
            this.grp_ExchangeRateProvision.Size = new System.Drawing.Size(264, 112);
            this.grp_ExchangeRateProvision.TabIndex = 29;
            this.grp_ExchangeRateProvision.TabStop = false;
            this.grp_ExchangeRateProvision.Text = "Exchange Rate Provision";
            // 
            // rdb_0
            // 
            this.rdb_0.AutoSize = true;
            this.rdb_0.Location = new System.Drawing.Point(18, 19);
            this.rdb_0.Name = "rdb_0";
            this.rdb_0.Size = new System.Drawing.Size(39, 17);
            this.rdb_0.TabIndex = 0;
            this.rdb_0.TabStop = true;
            this.rdb_0.Text = "0%";
            this.rdb_0.UseVisualStyleBackColor = true;
            // 
            // rdb_1
            // 
            this.rdb_1.AutoSize = true;
            this.rdb_1.Location = new System.Drawing.Point(63, 19);
            this.rdb_1.Name = "rdb_1";
            this.rdb_1.Size = new System.Drawing.Size(39, 17);
            this.rdb_1.TabIndex = 1;
            this.rdb_1.TabStop = true;
            this.rdb_1.Text = "1%";
            this.rdb_1.UseVisualStyleBackColor = true;
            // 
            // rdb_2
            // 
            this.rdb_2.AutoSize = true;
            this.rdb_2.Location = new System.Drawing.Point(106, 19);
            this.rdb_2.Name = "rdb_2";
            this.rdb_2.Size = new System.Drawing.Size(39, 17);
            this.rdb_2.TabIndex = 2;
            this.rdb_2.TabStop = true;
            this.rdb_2.Text = "2%";
            this.rdb_2.UseVisualStyleBackColor = true;
            // 
            // rdb_2_5
            // 
            this.rdb_2_5.AutoSize = true;
            this.rdb_2_5.Location = new System.Drawing.Point(151, 20);
            this.rdb_2_5.Name = "rdb_2_5";
            this.rdb_2_5.Size = new System.Drawing.Size(48, 17);
            this.rdb_2_5.TabIndex = 3;
            this.rdb_2_5.TabStop = true;
            this.rdb_2_5.Text = "2,5%";
            this.rdb_2_5.UseVisualStyleBackColor = true;
            // 
            // rdb_3
            // 
            this.rdb_3.AutoSize = true;
            this.rdb_3.Location = new System.Drawing.Point(205, 20);
            this.rdb_3.Name = "rdb_3";
            this.rdb_3.Size = new System.Drawing.Size(39, 17);
            this.rdb_3.TabIndex = 4;
            this.rdb_3.TabStop = true;
            this.rdb_3.Text = "3%";
            this.rdb_3.UseVisualStyleBackColor = true;
            // 
            // rdb_8
            // 
            this.rdb_8.AutoSize = true;
            this.rdb_8.Location = new System.Drawing.Point(206, 42);
            this.rdb_8.Name = "rdb_8";
            this.rdb_8.Size = new System.Drawing.Size(39, 17);
            this.rdb_8.TabIndex = 9;
            this.rdb_8.TabStop = true;
            this.rdb_8.Text = "8%";
            this.rdb_8.UseVisualStyleBackColor = true;
            // 
            // rdb_7
            // 
            this.rdb_7.AutoSize = true;
            this.rdb_7.Location = new System.Drawing.Point(152, 42);
            this.rdb_7.Name = "rdb_7";
            this.rdb_7.Size = new System.Drawing.Size(39, 17);
            this.rdb_7.TabIndex = 8;
            this.rdb_7.TabStop = true;
            this.rdb_7.Text = "7%";
            this.rdb_7.UseVisualStyleBackColor = true;
            // 
            // rdb_6
            // 
            this.rdb_6.AutoSize = true;
            this.rdb_6.Location = new System.Drawing.Point(107, 41);
            this.rdb_6.Name = "rdb_6";
            this.rdb_6.Size = new System.Drawing.Size(39, 17);
            this.rdb_6.TabIndex = 7;
            this.rdb_6.TabStop = true;
            this.rdb_6.Text = "6%";
            this.rdb_6.UseVisualStyleBackColor = true;
            // 
            // rdb_5
            // 
            this.rdb_5.AutoSize = true;
            this.rdb_5.Location = new System.Drawing.Point(64, 41);
            this.rdb_5.Name = "rdb_5";
            this.rdb_5.Size = new System.Drawing.Size(39, 17);
            this.rdb_5.TabIndex = 6;
            this.rdb_5.TabStop = true;
            this.rdb_5.Text = "5%";
            this.rdb_5.UseVisualStyleBackColor = true;
            // 
            // rdb_4
            // 
            this.rdb_4.AutoSize = true;
            this.rdb_4.Location = new System.Drawing.Point(19, 41);
            this.rdb_4.Name = "rdb_4";
            this.rdb_4.Size = new System.Drawing.Size(39, 17);
            this.rdb_4.TabIndex = 5;
            this.rdb_4.TabStop = true;
            this.rdb_4.Text = "4%";
            this.rdb_4.UseVisualStyleBackColor = true;
            // 
            // rdb_30
            // 
            this.rdb_30.AutoSize = true;
            this.rdb_30.Location = new System.Drawing.Point(206, 65);
            this.rdb_30.Name = "rdb_30";
            this.rdb_30.Size = new System.Drawing.Size(45, 17);
            this.rdb_30.TabIndex = 14;
            this.rdb_30.TabStop = true;
            this.rdb_30.Text = "30%";
            this.rdb_30.UseVisualStyleBackColor = true;
            // 
            // rdb_25
            // 
            this.rdb_25.AutoSize = true;
            this.rdb_25.Location = new System.Drawing.Point(152, 65);
            this.rdb_25.Name = "rdb_25";
            this.rdb_25.Size = new System.Drawing.Size(45, 17);
            this.rdb_25.TabIndex = 13;
            this.rdb_25.TabStop = true;
            this.rdb_25.Text = "25%";
            this.rdb_25.UseVisualStyleBackColor = true;
            // 
            // rdb_20
            // 
            this.rdb_20.AutoSize = true;
            this.rdb_20.Location = new System.Drawing.Point(107, 64);
            this.rdb_20.Name = "rdb_20";
            this.rdb_20.Size = new System.Drawing.Size(45, 17);
            this.rdb_20.TabIndex = 12;
            this.rdb_20.TabStop = true;
            this.rdb_20.Text = "20%";
            this.rdb_20.UseVisualStyleBackColor = true;
            // 
            // rdb_15
            // 
            this.rdb_15.AutoSize = true;
            this.rdb_15.Location = new System.Drawing.Point(64, 64);
            this.rdb_15.Name = "rdb_15";
            this.rdb_15.Size = new System.Drawing.Size(45, 17);
            this.rdb_15.TabIndex = 11;
            this.rdb_15.TabStop = true;
            this.rdb_15.Text = "15%";
            this.rdb_15.UseVisualStyleBackColor = true;
            // 
            // rdb_10
            // 
            this.rdb_10.AutoSize = true;
            this.rdb_10.Location = new System.Drawing.Point(19, 64);
            this.rdb_10.Name = "rdb_10";
            this.rdb_10.Size = new System.Drawing.Size(45, 17);
            this.rdb_10.TabIndex = 10;
            this.rdb_10.TabStop = true;
            this.rdb_10.Text = "10%";
            this.rdb_10.UseVisualStyleBackColor = true;
            // 
            // nmUpDn_ExchangeRateProvision
            // 
            this.nmUpDn_ExchangeRateProvision.Location = new System.Drawing.Point(39, 86);
            this.nmUpDn_ExchangeRateProvision.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.nmUpDn_ExchangeRateProvision.Name = "nmUpDn_ExchangeRateProvision";
            this.nmUpDn_ExchangeRateProvision.Size = new System.Drawing.Size(79, 20);
            this.nmUpDn_ExchangeRateProvision.TabIndex = 15;
            // 
            // rdb_nmUpDn
            // 
            this.rdb_nmUpDn.AutoSize = true;
            this.rdb_nmUpDn.Location = new System.Drawing.Point(19, 89);
            this.rdb_nmUpDn.Name = "rdb_nmUpDn";
            this.rdb_nmUpDn.Size = new System.Drawing.Size(14, 13);
            this.rdb_nmUpDn.TabIndex = 16;
            this.rdb_nmUpDn.TabStop = true;
            this.rdb_nmUpDn.UseVisualStyleBackColor = true;
            // 
            // Form_ECBExchangeRates
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(836, 588);
            this.Controls.Add(this.grp_ExchangeRateProvision);
            this.Controls.Add(this.lbl_To);
            this.Controls.Add(this.lbl_From);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btn_Calculate);
            this.Controls.Add(this.txtHowMany);
            this.Controls.Add(this.txtBelob);
            this.Controls.Add(this.lbl_ToCountryExchange);
            this.Controls.Add(this.lbl_FromCountryExchange);
            this.Controls.Add(this.lbl_Date);
            this.Controls.Add(this.cmbToCountry);
            this.Controls.Add(this.cmbFromCountry);
            this.Controls.Add(this.cmbDate);
            this.Controls.Add(this.lblRef);
            this.Controls.Add(this.dataGrid1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_ECBExchangeRates";
            this.Text = "Form_ECBexchangeReates";
            this.Load += new System.EventHandler(this.Form_ECBExchangeReates_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.grp_ExchangeRateProvision.ResumeLayout(false);
            this.grp_ExchangeRateProvision.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmUpDn_ExchangeRateProvision)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGrid dataGrid1;
        private System.Windows.Forms.Label lblRef;
        private System.Windows.Forms.Label lbl_To;
        private System.Windows.Forms.Label lbl_From;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_Calculate;
        private System.Windows.Forms.TextBox txtHowMany;
        private System.Windows.Forms.TextBox txtBelob;
        private System.Windows.Forms.Label lbl_ToCountryExchange;
        private System.Windows.Forms.Label lbl_FromCountryExchange;
        private System.Windows.Forms.Label lbl_Date;
        private System.Windows.Forms.ComboBox cmbToCountry;
        private System.Windows.Forms.ComboBox cmbFromCountry;
        private System.Windows.Forms.ComboBox cmbDate;
        private System.Windows.Forms.GroupBox grp_ExchangeRateProvision;
        private System.Windows.Forms.NumericUpDown nmUpDn_ExchangeRateProvision;
        private System.Windows.Forms.RadioButton rdb_30;
        private System.Windows.Forms.RadioButton rdb_25;
        private System.Windows.Forms.RadioButton rdb_20;
        private System.Windows.Forms.RadioButton rdb_15;
        private System.Windows.Forms.RadioButton rdb_10;
        private System.Windows.Forms.RadioButton rdb_8;
        private System.Windows.Forms.RadioButton rdb_7;
        private System.Windows.Forms.RadioButton rdb_6;
        private System.Windows.Forms.RadioButton rdb_5;
        private System.Windows.Forms.RadioButton rdb_4;
        private System.Windows.Forms.RadioButton rdb_3;
        private System.Windows.Forms.RadioButton rdb_2_5;
        private System.Windows.Forms.RadioButton rdb_2;
        private System.Windows.Forms.RadioButton rdb_1;
        private System.Windows.Forms.RadioButton rdb_0;
        private System.Windows.Forms.RadioButton rdb_nmUpDn;
    }
}