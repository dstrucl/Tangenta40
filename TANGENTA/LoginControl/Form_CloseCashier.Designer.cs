namespace LoginControl
{
    partial class Form_CloseCashier
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
            this.lbl_CashierOpen_Question = new System.Windows.Forms.Label();
            this.btn_NO = new System.Windows.Forms.Button();
            this.btn_YES = new System.Windows.Forms.Button();
            this.lbl_CashierActivityNumber = new System.Windows.Forms.Label();
            this.lbl_CashierActivityNumber_Value = new System.Windows.Forms.Label();
            this.lbl_CashierOpenedTime_Value = new System.Windows.Forms.Label();
            this.lbl_CashierOpenedTime = new System.Windows.Forms.Label();
            this.lbl_PersonWhoOpenedCashier_Value = new System.Windows.Forms.Label();
            this.lbl_PersonWhoOpenedCashier = new System.Windows.Forms.Label();
            this.pnl_Realisation_ByTaxRate = new System.Windows.Forms.Panel();
            this.lbl_NumberOfInvoices_Value = new System.Windows.Forms.Label();
            this.lbl_NumberOfInvoices = new System.Windows.Forms.Label();
            this.lbl_NetPrice_Value = new System.Windows.Forms.Label();
            this.lbl_NetPrice = new System.Windows.Forms.Label();
            this.lbl_TaxPrice_Value = new System.Windows.Forms.Label();
            this.lbl_TaxPrice = new System.Windows.Forms.Label();
            this.lbl_Total_Value = new System.Windows.Forms.Label();
            this.lbl_Total = new System.Windows.Forms.Label();
            this.btn_Print = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_ReportByPaymentMethod = new System.Windows.Forms.Label();
            this.lbl_Report_ByTaxiation = new System.Windows.Forms.Label();
            this.lbl_FromInvoice = new System.Windows.Forms.Label();
            this.lbl_FromInvoice_Value = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_ToInvoice = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_CashierOpen_Question
            // 
            this.lbl_CashierOpen_Question.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_CashierOpen_Question.ForeColor = System.Drawing.Color.Blue;
            this.lbl_CashierOpen_Question.Location = new System.Drawing.Point(97, 532);
            this.lbl_CashierOpen_Question.Name = "lbl_CashierOpen_Question";
            this.lbl_CashierOpen_Question.Size = new System.Drawing.Size(338, 22);
            this.lbl_CashierOpen_Question.TabIndex = 5;
            this.lbl_CashierOpen_Question.Text = "Close Cashier ?";
            this.lbl_CashierOpen_Question.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_NO
            // 
            this.btn_NO.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_NO.Location = new System.Drawing.Point(410, 564);
            this.btn_NO.Name = "btn_NO";
            this.btn_NO.Size = new System.Drawing.Size(117, 112);
            this.btn_NO.TabIndex = 4;
            this.btn_NO.Text = "NO";
            this.btn_NO.UseVisualStyleBackColor = true;
            // 
            // btn_YES
            // 
            this.btn_YES.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_YES.Location = new System.Drawing.Point(233, 564);
            this.btn_YES.Name = "btn_YES";
            this.btn_YES.Size = new System.Drawing.Size(155, 112);
            this.btn_YES.TabIndex = 3;
            this.btn_YES.Text = "YES";
            this.btn_YES.UseVisualStyleBackColor = true;
            this.btn_YES.Click += new System.EventHandler(this.btn_YES_Click);
            // 
            // lbl_CashierActivityNumber
            // 
            this.lbl_CashierActivityNumber.Location = new System.Drawing.Point(10, 8);
            this.lbl_CashierActivityNumber.Name = "lbl_CashierActivityNumber";
            this.lbl_CashierActivityNumber.Size = new System.Drawing.Size(83, 17);
            this.lbl_CashierActivityNumber.TabIndex = 6;
            this.lbl_CashierActivityNumber.Text = "Cashier Activity Number:";
            this.lbl_CashierActivityNumber.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lbl_CashierActivityNumber_Value
            // 
            this.lbl_CashierActivityNumber_Value.Location = new System.Drawing.Point(99, 8);
            this.lbl_CashierActivityNumber_Value.Name = "lbl_CashierActivityNumber_Value";
            this.lbl_CashierActivityNumber_Value.Size = new System.Drawing.Size(68, 17);
            this.lbl_CashierActivityNumber_Value.TabIndex = 7;
            this.lbl_CashierActivityNumber_Value.Text = "XX";
            // 
            // lbl_CashierOpenedTime_Value
            // 
            this.lbl_CashierOpenedTime_Value.Location = new System.Drawing.Point(170, 53);
            this.lbl_CashierOpenedTime_Value.Name = "lbl_CashierOpenedTime_Value";
            this.lbl_CashierOpenedTime_Value.Size = new System.Drawing.Size(122, 17);
            this.lbl_CashierOpenedTime_Value.TabIndex = 9;
            this.lbl_CashierOpenedTime_Value.Text = "dd.mm.yyyy hh:mm:ss";
            // 
            // lbl_CashierOpenedTime
            // 
            this.lbl_CashierOpenedTime.Location = new System.Drawing.Point(13, 53);
            this.lbl_CashierOpenedTime.Name = "lbl_CashierOpenedTime";
            this.lbl_CashierOpenedTime.Size = new System.Drawing.Size(158, 17);
            this.lbl_CashierOpenedTime.TabIndex = 8;
            this.lbl_CashierOpenedTime.Text = "Time Cashier Opened:";
            this.lbl_CashierOpenedTime.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lbl_PersonWhoOpenedCashier_Value
            // 
            this.lbl_PersonWhoOpenedCashier_Value.Location = new System.Drawing.Point(170, 70);
            this.lbl_PersonWhoOpenedCashier_Value.Name = "lbl_PersonWhoOpenedCashier_Value";
            this.lbl_PersonWhoOpenedCashier_Value.Size = new System.Drawing.Size(122, 17);
            this.lbl_PersonWhoOpenedCashier_Value.TabIndex = 11;
            this.lbl_PersonWhoOpenedCashier_Value.Text = "Damjan";
            // 
            // lbl_PersonWhoOpenedCashier
            // 
            this.lbl_PersonWhoOpenedCashier.Location = new System.Drawing.Point(13, 70);
            this.lbl_PersonWhoOpenedCashier.Name = "lbl_PersonWhoOpenedCashier";
            this.lbl_PersonWhoOpenedCashier.Size = new System.Drawing.Size(158, 17);
            this.lbl_PersonWhoOpenedCashier.TabIndex = 10;
            this.lbl_PersonWhoOpenedCashier.Text = "Person who opened cashier:";
            this.lbl_PersonWhoOpenedCashier.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // pnl_Realisation_ByTaxRate
            // 
            this.pnl_Realisation_ByTaxRate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnl_Realisation_ByTaxRate.Location = new System.Drawing.Point(3, 150);
            this.pnl_Realisation_ByTaxRate.Name = "pnl_Realisation_ByTaxRate";
            this.pnl_Realisation_ByTaxRate.Size = new System.Drawing.Size(524, 125);
            this.pnl_Realisation_ByTaxRate.TabIndex = 12;
            // 
            // lbl_NumberOfInvoices_Value
            // 
            this.lbl_NumberOfInvoices_Value.Location = new System.Drawing.Point(313, 8);
            this.lbl_NumberOfInvoices_Value.Name = "lbl_NumberOfInvoices_Value";
            this.lbl_NumberOfInvoices_Value.Size = new System.Drawing.Size(122, 17);
            this.lbl_NumberOfInvoices_Value.TabIndex = 14;
            this.lbl_NumberOfInvoices_Value.Text = "YY";
            // 
            // lbl_NumberOfInvoices
            // 
            this.lbl_NumberOfInvoices.Location = new System.Drawing.Point(156, 8);
            this.lbl_NumberOfInvoices.Name = "lbl_NumberOfInvoices";
            this.lbl_NumberOfInvoices.Size = new System.Drawing.Size(158, 17);
            this.lbl_NumberOfInvoices.TabIndex = 13;
            this.lbl_NumberOfInvoices.Text = "Number od invoices:";
            this.lbl_NumberOfInvoices.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lbl_NetPrice_Value
            // 
            this.lbl_NetPrice_Value.Location = new System.Drawing.Point(13, 108);
            this.lbl_NetPrice_Value.Name = "lbl_NetPrice_Value";
            this.lbl_NetPrice_Value.Size = new System.Drawing.Size(105, 17);
            this.lbl_NetPrice_Value.TabIndex = 16;
            this.lbl_NetPrice_Value.Text = "EUR ZZ ";
            // 
            // lbl_NetPrice
            // 
            this.lbl_NetPrice.Location = new System.Drawing.Point(13, 91);
            this.lbl_NetPrice.Name = "lbl_NetPrice";
            this.lbl_NetPrice.Size = new System.Drawing.Size(80, 17);
            this.lbl_NetPrice.TabIndex = 15;
            this.lbl_NetPrice.Text = "Net Price:";
            // 
            // lbl_TaxPrice_Value
            // 
            this.lbl_TaxPrice_Value.Location = new System.Drawing.Point(119, 108);
            this.lbl_TaxPrice_Value.Name = "lbl_TaxPrice_Value";
            this.lbl_TaxPrice_Value.Size = new System.Drawing.Size(100, 17);
            this.lbl_TaxPrice_Value.TabIndex = 18;
            this.lbl_TaxPrice_Value.Text = "EUR xx";
            this.lbl_TaxPrice_Value.Click += new System.EventHandler(this.label1_Click);
            // 
            // lbl_TaxPrice
            // 
            this.lbl_TaxPrice.Location = new System.Drawing.Point(119, 91);
            this.lbl_TaxPrice.Name = "lbl_TaxPrice";
            this.lbl_TaxPrice.Size = new System.Drawing.Size(80, 17);
            this.lbl_TaxPrice.TabIndex = 17;
            this.lbl_TaxPrice.Text = "Tax:";
            this.lbl_TaxPrice.Click += new System.EventHandler(this.label2_Click);
            // 
            // lbl_Total_Value
            // 
            this.lbl_Total_Value.Location = new System.Drawing.Point(225, 108);
            this.lbl_Total_Value.Name = "lbl_Total_Value";
            this.lbl_Total_Value.Size = new System.Drawing.Size(100, 17);
            this.lbl_Total_Value.TabIndex = 20;
            this.lbl_Total_Value.Text = "EUR yy";
            // 
            // lbl_Total
            // 
            this.lbl_Total.Location = new System.Drawing.Point(225, 91);
            this.lbl_Total.Name = "lbl_Total";
            this.lbl_Total.Size = new System.Drawing.Size(80, 17);
            this.lbl_Total.TabIndex = 19;
            this.lbl_Total.Text = "Total:";
            // 
            // btn_Print
            // 
            this.btn_Print.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_Print.Location = new System.Drawing.Point(13, 564);
            this.btn_Print.Name = "btn_Print";
            this.btn_Print.Size = new System.Drawing.Size(196, 112);
            this.btn_Print.TabIndex = 21;
            this.btn_Print.Text = "PRINT";
            this.btn_Print.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Location = new System.Drawing.Point(3, 303);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(524, 224);
            this.panel1.TabIndex = 13;
            // 
            // lbl_ReportByPaymentMethod
            // 
            this.lbl_ReportByPaymentMethod.Location = new System.Drawing.Point(0, 283);
            this.lbl_ReportByPaymentMethod.Name = "lbl_ReportByPaymentMethod";
            this.lbl_ReportByPaymentMethod.Size = new System.Drawing.Size(158, 17);
            this.lbl_ReportByPaymentMethod.TabIndex = 22;
            this.lbl_ReportByPaymentMethod.Text = "Report By Payment Type";
            // 
            // lbl_Report_ByTaxiation
            // 
            this.lbl_Report_ByTaxiation.Location = new System.Drawing.Point(0, 130);
            this.lbl_Report_ByTaxiation.Name = "lbl_Report_ByTaxiation";
            this.lbl_Report_ByTaxiation.Size = new System.Drawing.Size(158, 17);
            this.lbl_Report_ByTaxiation.TabIndex = 23;
            this.lbl_Report_ByTaxiation.Text = "Report By Taxation Rate";
            // 
            // lbl_FromInvoice
            // 
            this.lbl_FromInvoice.Location = new System.Drawing.Point(13, 30);
            this.lbl_FromInvoice.Name = "lbl_FromInvoice";
            this.lbl_FromInvoice.Size = new System.Drawing.Size(89, 17);
            this.lbl_FromInvoice.TabIndex = 24;
            this.lbl_FromInvoice.Text = "from Inv.:";
            this.lbl_FromInvoice.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lbl_FromInvoice_Value
            // 
            this.lbl_FromInvoice_Value.Location = new System.Drawing.Point(99, 30);
            this.lbl_FromInvoice_Value.Name = "lbl_FromInvoice_Value";
            this.lbl_FromInvoice_Value.Size = new System.Drawing.Size(86, 17);
            this.lbl_FromInvoice_Value.TabIndex = 25;
            this.lbl_FromInvoice_Value.Text = "x-y-zzz/yyyy";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(283, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 17);
            this.label1.TabIndex = 27;
            this.label1.Text = "x-y-zzz/yyyy";
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // lbl_ToInvoice
            // 
            this.lbl_ToInvoice.Location = new System.Drawing.Point(188, 30);
            this.lbl_ToInvoice.Name = "lbl_ToInvoice";
            this.lbl_ToInvoice.Size = new System.Drawing.Size(89, 17);
            this.lbl_ToInvoice.TabIndex = 26;
            this.lbl_ToInvoice.Text = "To Inv.:";
            this.lbl_ToInvoice.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lbl_ToInvoice.Click += new System.EventHandler(this.label2_Click_1);
            // 
            // Form_CloseCashier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 681);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl_ToInvoice);
            this.Controls.Add(this.lbl_FromInvoice_Value);
            this.Controls.Add(this.lbl_FromInvoice);
            this.Controls.Add(this.lbl_Report_ByTaxiation);
            this.Controls.Add(this.lbl_ReportByPaymentMethod);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btn_Print);
            this.Controls.Add(this.lbl_Total_Value);
            this.Controls.Add(this.lbl_Total);
            this.Controls.Add(this.lbl_TaxPrice_Value);
            this.Controls.Add(this.lbl_TaxPrice);
            this.Controls.Add(this.lbl_NetPrice_Value);
            this.Controls.Add(this.lbl_NetPrice);
            this.Controls.Add(this.lbl_NumberOfInvoices_Value);
            this.Controls.Add(this.lbl_NumberOfInvoices);
            this.Controls.Add(this.pnl_Realisation_ByTaxRate);
            this.Controls.Add(this.lbl_PersonWhoOpenedCashier_Value);
            this.Controls.Add(this.lbl_PersonWhoOpenedCashier);
            this.Controls.Add(this.lbl_CashierOpenedTime_Value);
            this.Controls.Add(this.lbl_CashierOpenedTime);
            this.Controls.Add(this.lbl_CashierActivityNumber_Value);
            this.Controls.Add(this.lbl_CashierActivityNumber);
            this.Controls.Add(this.lbl_CashierOpen_Question);
            this.Controls.Add(this.btn_NO);
            this.Controls.Add(this.btn_YES);
            this.Name = "Form_CloseCashier";
            this.Text = "Form_CloseCashier";
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.Label lbl_CashierOpen_Question;
        private System.Windows.Forms.Button btn_NO;
        private System.Windows.Forms.Button btn_YES;
        private System.Windows.Forms.Label lbl_CashierActivityNumber;
        private System.Windows.Forms.Label lbl_CashierActivityNumber_Value;
        private System.Windows.Forms.Label lbl_CashierOpenedTime_Value;
        private System.Windows.Forms.Label lbl_CashierOpenedTime;
        private System.Windows.Forms.Label lbl_PersonWhoOpenedCashier_Value;
        private System.Windows.Forms.Label lbl_PersonWhoOpenedCashier;
        private System.Windows.Forms.Panel pnl_Realisation_ByTaxRate;
        private System.Windows.Forms.Label lbl_NumberOfInvoices_Value;
        private System.Windows.Forms.Label lbl_NumberOfInvoices;
        private System.Windows.Forms.Label lbl_NetPrice_Value;
        private System.Windows.Forms.Label lbl_NetPrice;
        private System.Windows.Forms.Label lbl_TaxPrice_Value;
        private System.Windows.Forms.Label lbl_TaxPrice;
        private System.Windows.Forms.Label lbl_Total_Value;
        private System.Windows.Forms.Label lbl_Total;
        private System.Windows.Forms.Button btn_Print;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl_ReportByPaymentMethod;
        private System.Windows.Forms.Label lbl_Report_ByTaxiation;
        private System.Windows.Forms.Label lbl_FromInvoice;
        private System.Windows.Forms.Label lbl_FromInvoice_Value;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_ToInvoice;
    }
}