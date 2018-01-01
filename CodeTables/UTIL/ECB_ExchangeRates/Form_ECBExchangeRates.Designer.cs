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
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
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
            this.dataGrid1.Size = new System.Drawing.Size(637, 332);
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
            this.lbl_To.Location = new System.Drawing.Point(356, 422);
            this.lbl_To.Name = "lbl_To";
            this.lbl_To.Size = new System.Drawing.Size(40, 24);
            this.lbl_To.TabIndex = 28;
            this.lbl_To.Text = "To";
            // 
            // lbl_From
            // 
            this.lbl_From.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_From.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbl_From.Location = new System.Drawing.Point(356, 382);
            this.lbl_From.Name = "lbl_From";
            this.lbl_From.Size = new System.Drawing.Size(40, 23);
            this.lbl_From.TabIndex = 27;
            this.lbl_From.Text = "From";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(510, 422);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 23);
            this.label5.TabIndex = 26;
            this.label5.Text = "---";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(510, 382);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 23);
            this.label4.TabIndex = 25;
            this.label4.Text = "---";
            // 
            // btn_Calculate
            // 
            this.btn_Calculate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Calculate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btn_Calculate.Location = new System.Drawing.Point(404, 454);
            this.btn_Calculate.Name = "btn_Calculate";
            this.btn_Calculate.Size = new System.Drawing.Size(112, 23);
            this.btn_Calculate.TabIndex = 24;
            this.btn_Calculate.Text = "Calculate";
            this.btn_Calculate.Click += new System.EventHandler(this.btnCalculat_Click);
            // 
            // txtHowMany
            // 
            this.txtHowMany.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtHowMany.Location = new System.Drawing.Point(404, 422);
            this.txtHowMany.Name = "txtHowMany";
            this.txtHowMany.ReadOnly = true;
            this.txtHowMany.Size = new System.Drawing.Size(100, 20);
            this.txtHowMany.TabIndex = 23;
            // 
            // txtBelob
            // 
            this.txtBelob.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtBelob.Location = new System.Drawing.Point(404, 382);
            this.txtBelob.Name = "txtBelob";
            this.txtBelob.Size = new System.Drawing.Size(100, 20);
            this.txtBelob.TabIndex = 22;
            this.txtBelob.Text = "100,00";
            // 
            // lbl_ToCountryExchange
            // 
            this.lbl_ToCountryExchange.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_ToCountryExchange.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbl_ToCountryExchange.Location = new System.Drawing.Point(212, 430);
            this.lbl_ToCountryExchange.Name = "lbl_ToCountryExchange";
            this.lbl_ToCountryExchange.Size = new System.Drawing.Size(128, 16);
            this.lbl_ToCountryExchange.TabIndex = 21;
            this.lbl_ToCountryExchange.Text = "To County exchange :";
            // 
            // lbl_FromCountryExchange
            // 
            this.lbl_FromCountryExchange.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_FromCountryExchange.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbl_FromCountryExchange.Location = new System.Drawing.Point(60, 430);
            this.lbl_FromCountryExchange.Name = "lbl_FromCountryExchange";
            this.lbl_FromCountryExchange.Size = new System.Drawing.Size(128, 16);
            this.lbl_FromCountryExchange.TabIndex = 20;
            this.lbl_FromCountryExchange.Text = "From County exchange :";
            // 
            // lbl_Date
            // 
            this.lbl_Date.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_Date.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbl_Date.Location = new System.Drawing.Point(12, 382);
            this.lbl_Date.Name = "lbl_Date";
            this.lbl_Date.Size = new System.Drawing.Size(100, 16);
            this.lbl_Date.TabIndex = 19;
            this.lbl_Date.Text = "Date :";
            // 
            // cmbToCountry
            // 
            this.cmbToCountry.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmbToCountry.ItemHeight = 13;
            this.cmbToCountry.Location = new System.Drawing.Point(212, 446);
            this.cmbToCountry.Name = "cmbToCountry";
            this.cmbToCountry.Size = new System.Drawing.Size(128, 21);
            this.cmbToCountry.TabIndex = 18;
            // 
            // cmbFromCountry
            // 
            this.cmbFromCountry.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmbFromCountry.ItemHeight = 13;
            this.cmbFromCountry.Location = new System.Drawing.Point(60, 446);
            this.cmbFromCountry.Name = "cmbFromCountry";
            this.cmbFromCountry.Size = new System.Drawing.Size(128, 21);
            this.cmbFromCountry.TabIndex = 17;
            // 
            // cmbDate
            // 
            this.cmbDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmbDate.ItemHeight = 13;
            this.cmbDate.Location = new System.Drawing.Point(12, 398);
            this.cmbDate.Name = "cmbDate";
            this.cmbDate.Size = new System.Drawing.Size(160, 21);
            this.cmbDate.TabIndex = 16;
            // 
            // Form_ECBExchangeRates
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 491);
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
            this.Name = "Form_ECBExchangeRates";
            this.Text = "Form_ECBexchangeReates";
            this.Load += new System.EventHandler(this.Form_ECBExchangeReates_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
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
    }
}