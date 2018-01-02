namespace ECB_ExchangeRates_TEST
{
    partial class Form_Test
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
            this.lbl_ConvertToCurrency = new System.Windows.Forms.Label();
            this.cmb_ConvertEuroToCurrency = new System.Windows.Forms.ComboBox();
            this.lbl_AmountInEuro = new System.Windows.Forms.Label();
            this.nm_UpDn_ValueInEUR = new System.Windows.Forms.NumericUpDown();
            this.lbl_Conversion_Result = new System.Windows.Forms.Label();
            this.txt_ConversionResult = new System.Windows.Forms.TextBox();
            this.btn_Convert = new System.Windows.Forms.Button();
            this.nm_UpDn_ExchangeRateProvisionInPercent = new System.Windows.Forms.NumericUpDown();
            this.lbl_ExchangeRateProvision = new System.Windows.Forms.Label();
            this.btn_ShowWithoutParameters = new System.Windows.Forms.Button();
            this.btn_ConvertDaily = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nm_UpDn_ValueInEUR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nm_UpDn_ExchangeRateProvisionInPercent)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_ConvertToCurrency
            // 
            this.lbl_ConvertToCurrency.AutoSize = true;
            this.lbl_ConvertToCurrency.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_ConvertToCurrency.Location = new System.Drawing.Point(21, 27);
            this.lbl_ConvertToCurrency.Name = "lbl_ConvertToCurrency";
            this.lbl_ConvertToCurrency.Size = new System.Drawing.Size(204, 25);
            this.lbl_ConvertToCurrency.TabIndex = 1;
            this.lbl_ConvertToCurrency.Text = "Convert to Currency";
            // 
            // cmb_ConvertEuroToCurrency
            // 
            this.cmb_ConvertEuroToCurrency.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cmb_ConvertEuroToCurrency.FormattingEnabled = true;
            this.cmb_ConvertEuroToCurrency.Location = new System.Drawing.Point(231, 24);
            this.cmb_ConvertEuroToCurrency.Name = "cmb_ConvertEuroToCurrency";
            this.cmb_ConvertEuroToCurrency.Size = new System.Drawing.Size(165, 33);
            this.cmb_ConvertEuroToCurrency.TabIndex = 2;
            // 
            // lbl_AmountInEuro
            // 
            this.lbl_AmountInEuro.AutoSize = true;
            this.lbl_AmountInEuro.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_AmountInEuro.Location = new System.Drawing.Point(21, 82);
            this.lbl_AmountInEuro.Name = "lbl_AmountInEuro";
            this.lbl_AmountInEuro.Size = new System.Drawing.Size(140, 25);
            this.lbl_AmountInEuro.TabIndex = 3;
            this.lbl_AmountInEuro.Text = "Value in EUR";
            // 
            // nm_UpDn_ValueInEUR
            // 
            this.nm_UpDn_ValueInEUR.DecimalPlaces = 2;
            this.nm_UpDn_ValueInEUR.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.nm_UpDn_ValueInEUR.Location = new System.Drawing.Point(179, 79);
            this.nm_UpDn_ValueInEUR.Maximum = new decimal(new int[] {
            1410065408,
            2,
            0,
            0});
            this.nm_UpDn_ValueInEUR.Minimum = new decimal(new int[] {
            1215752192,
            23,
            0,
            -2147483648});
            this.nm_UpDn_ValueInEUR.Name = "nm_UpDn_ValueInEUR";
            this.nm_UpDn_ValueInEUR.Size = new System.Drawing.Size(143, 31);
            this.nm_UpDn_ValueInEUR.TabIndex = 4;
            // 
            // lbl_Conversion_Result
            // 
            this.lbl_Conversion_Result.AutoSize = true;
            this.lbl_Conversion_Result.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_Conversion_Result.Location = new System.Drawing.Point(21, 248);
            this.lbl_Conversion_Result.Name = "lbl_Conversion_Result";
            this.lbl_Conversion_Result.Size = new System.Drawing.Size(194, 25);
            this.lbl_Conversion_Result.TabIndex = 5;
            this.lbl_Conversion_Result.Text = "Conversion Result:";
            // 
            // txt_ConversionResult
            // 
            this.txt_ConversionResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_ConversionResult.Location = new System.Drawing.Point(221, 242);
            this.txt_ConversionResult.Name = "txt_ConversionResult";
            this.txt_ConversionResult.ReadOnly = true;
            this.txt_ConversionResult.Size = new System.Drawing.Size(227, 31);
            this.txt_ConversionResult.TabIndex = 6;
            // 
            // btn_Convert
            // 
            this.btn_Convert.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_Convert.Location = new System.Drawing.Point(26, 174);
            this.btn_Convert.Name = "btn_Convert";
            this.btn_Convert.Size = new System.Drawing.Size(189, 46);
            this.btn_Convert.TabIndex = 7;
            this.btn_Convert.Text = "CONVERT";
            this.btn_Convert.UseVisualStyleBackColor = true;
            this.btn_Convert.Click += new System.EventHandler(this.btn_Convert_Click);
            // 
            // nm_UpDn_ExchangeRateProvisionInPercent
            // 
            this.nm_UpDn_ExchangeRateProvisionInPercent.DecimalPlaces = 2;
            this.nm_UpDn_ExchangeRateProvisionInPercent.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.nm_UpDn_ExchangeRateProvisionInPercent.Location = new System.Drawing.Point(329, 131);
            this.nm_UpDn_ExchangeRateProvisionInPercent.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.nm_UpDn_ExchangeRateProvisionInPercent.Minimum = new decimal(new int[] {
            200,
            0,
            0,
            -2147483648});
            this.nm_UpDn_ExchangeRateProvisionInPercent.Name = "nm_UpDn_ExchangeRateProvisionInPercent";
            this.nm_UpDn_ExchangeRateProvisionInPercent.Size = new System.Drawing.Size(153, 31);
            this.nm_UpDn_ExchangeRateProvisionInPercent.TabIndex = 9;
            // 
            // lbl_ExchangeRateProvision
            // 
            this.lbl_ExchangeRateProvision.AutoSize = true;
            this.lbl_ExchangeRateProvision.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_ExchangeRateProvision.Location = new System.Drawing.Point(21, 137);
            this.lbl_ExchangeRateProvision.Name = "lbl_ExchangeRateProvision";
            this.lbl_ExchangeRateProvision.Size = new System.Drawing.Size(302, 25);
            this.lbl_ExchangeRateProvision.TabIndex = 8;
            this.lbl_ExchangeRateProvision.Text = "Exchange Rate Provision in %";
            // 
            // btn_ShowWithoutParameters
            // 
            this.btn_ShowWithoutParameters.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_ShowWithoutParameters.Location = new System.Drawing.Point(12, 321);
            this.btn_ShowWithoutParameters.Name = "btn_ShowWithoutParameters";
            this.btn_ShowWithoutParameters.Size = new System.Drawing.Size(510, 46);
            this.btn_ShowWithoutParameters.TabIndex = 10;
            this.btn_ShowWithoutParameters.Text = "Show ECB conversion dialog without parameters";
            this.btn_ShowWithoutParameters.UseVisualStyleBackColor = true;
            this.btn_ShowWithoutParameters.Click += new System.EventHandler(this.btn_ShowWithoutParameters_Click);
            // 
            // btn_ConvertDaily
            // 
            this.btn_ConvertDaily.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_ConvertDaily.Location = new System.Drawing.Point(245, 174);
            this.btn_ConvertDaily.Name = "btn_ConvertDaily";
            this.btn_ConvertDaily.Size = new System.Drawing.Size(434, 46);
            this.btn_ConvertDaily.TabIndex = 11;
            this.btn_ConvertDaily.Text = "CONVERT FROM LAST DAILY RATES";
            this.btn_ConvertDaily.UseVisualStyleBackColor = true;
            this.btn_ConvertDaily.Click += new System.EventHandler(this.btn_ConvertDaily_Click);
            // 
            // Form_Test
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 392);
            this.Controls.Add(this.btn_ConvertDaily);
            this.Controls.Add(this.btn_ShowWithoutParameters);
            this.Controls.Add(this.nm_UpDn_ExchangeRateProvisionInPercent);
            this.Controls.Add(this.lbl_ExchangeRateProvision);
            this.Controls.Add(this.btn_Convert);
            this.Controls.Add(this.txt_ConversionResult);
            this.Controls.Add(this.lbl_Conversion_Result);
            this.Controls.Add(this.nm_UpDn_ValueInEUR);
            this.Controls.Add(this.lbl_AmountInEuro);
            this.Controls.Add(this.cmb_ConvertEuroToCurrency);
            this.Controls.Add(this.lbl_ConvertToCurrency);
            this.Name = "Form_Test";
            this.Text = "Form_Test";
            ((System.ComponentModel.ISupportInitialize)(this.nm_UpDn_ValueInEUR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nm_UpDn_ExchangeRateProvisionInPercent)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_ConvertToCurrency;
        private System.Windows.Forms.ComboBox cmb_ConvertEuroToCurrency;
        private System.Windows.Forms.Label lbl_AmountInEuro;
        private System.Windows.Forms.NumericUpDown nm_UpDn_ValueInEUR;
        private System.Windows.Forms.Label lbl_Conversion_Result;
        private System.Windows.Forms.TextBox txt_ConversionResult;
        private System.Windows.Forms.Button btn_Convert;
        private System.Windows.Forms.NumericUpDown nm_UpDn_ExchangeRateProvisionInPercent;
        private System.Windows.Forms.Label lbl_ExchangeRateProvision;
        private System.Windows.Forms.Button btn_ShowWithoutParameters;
        private System.Windows.Forms.Button btn_ConvertDaily;
    }
}