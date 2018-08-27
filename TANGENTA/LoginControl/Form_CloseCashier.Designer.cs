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
            this.pnl_Realisation = new System.Windows.Forms.Panel();
            this.lbl_NumberOfInvoices_Value = new System.Windows.Forms.Label();
            this.lbl_NumberOfInvoices = new System.Windows.Forms.Label();
            this.lbl_NetPrice_Value = new System.Windows.Forms.Label();
            this.lbl_NetPrice = new System.Windows.Forms.Label();
            this.lbl_TaxPrice_Value = new System.Windows.Forms.Label();
            this.lbl_TaxPrice = new System.Windows.Forms.Label();
            this.lbl_Total_Value = new System.Windows.Forms.Label();
            this.lbl_Total = new System.Windows.Forms.Label();
            this.btn_Print = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_CashierOpen_Question
            // 
            this.lbl_CashierOpen_Question.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_CashierOpen_Question.ForeColor = System.Drawing.Color.Blue;
            this.lbl_CashierOpen_Question.Location = new System.Drawing.Point(97, 325);
            this.lbl_CashierOpen_Question.Name = "lbl_CashierOpen_Question";
            this.lbl_CashierOpen_Question.Size = new System.Drawing.Size(338, 22);
            this.lbl_CashierOpen_Question.TabIndex = 5;
            this.lbl_CashierOpen_Question.Text = "Close Cashier ?";
            this.lbl_CashierOpen_Question.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_NO
            // 
            this.btn_NO.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_NO.Location = new System.Drawing.Point(315, 350);
            this.btn_NO.Name = "btn_NO";
            this.btn_NO.Size = new System.Drawing.Size(120, 84);
            this.btn_NO.TabIndex = 4;
            this.btn_NO.Text = "NO";
            this.btn_NO.UseVisualStyleBackColor = true;
            // 
            // btn_YES
            // 
            this.btn_YES.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_YES.Location = new System.Drawing.Point(180, 350);
            this.btn_YES.Name = "btn_YES";
            this.btn_YES.Size = new System.Drawing.Size(129, 84);
            this.btn_YES.TabIndex = 3;
            this.btn_YES.Text = "YES";
            this.btn_YES.UseVisualStyleBackColor = true;
            this.btn_YES.Click += new System.EventHandler(this.btn_YES_Click);
            // 
            // lbl_CashierActivityNumber
            // 
            this.lbl_CashierActivityNumber.Location = new System.Drawing.Point(10, 8);
            this.lbl_CashierActivityNumber.Name = "lbl_CashierActivityNumber";
            this.lbl_CashierActivityNumber.Size = new System.Drawing.Size(158, 17);
            this.lbl_CashierActivityNumber.TabIndex = 6;
            this.lbl_CashierActivityNumber.Text = "Cashier Activity Number:";
            this.lbl_CashierActivityNumber.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lbl_CashierActivityNumber_Value
            // 
            this.lbl_CashierActivityNumber_Value.Location = new System.Drawing.Point(167, 8);
            this.lbl_CashierActivityNumber_Value.Name = "lbl_CashierActivityNumber_Value";
            this.lbl_CashierActivityNumber_Value.Size = new System.Drawing.Size(122, 17);
            this.lbl_CashierActivityNumber_Value.TabIndex = 7;
            this.lbl_CashierActivityNumber_Value.Text = "XX";
            // 
            // lbl_CashierOpenedTime_Value
            // 
            this.lbl_CashierOpenedTime_Value.Location = new System.Drawing.Point(166, 27);
            this.lbl_CashierOpenedTime_Value.Name = "lbl_CashierOpenedTime_Value";
            this.lbl_CashierOpenedTime_Value.Size = new System.Drawing.Size(122, 17);
            this.lbl_CashierOpenedTime_Value.TabIndex = 9;
            this.lbl_CashierOpenedTime_Value.Text = "dd.mm.yyyy hh:mm:ss";
            // 
            // lbl_CashierOpenedTime
            // 
            this.lbl_CashierOpenedTime.Location = new System.Drawing.Point(9, 27);
            this.lbl_CashierOpenedTime.Name = "lbl_CashierOpenedTime";
            this.lbl_CashierOpenedTime.Size = new System.Drawing.Size(158, 17);
            this.lbl_CashierOpenedTime.TabIndex = 8;
            this.lbl_CashierOpenedTime.Text = "Time Cashier Opened:";
            this.lbl_CashierOpenedTime.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lbl_PersonWhoOpenedCashier_Value
            // 
            this.lbl_PersonWhoOpenedCashier_Value.Location = new System.Drawing.Point(170, 44);
            this.lbl_PersonWhoOpenedCashier_Value.Name = "lbl_PersonWhoOpenedCashier_Value";
            this.lbl_PersonWhoOpenedCashier_Value.Size = new System.Drawing.Size(122, 17);
            this.lbl_PersonWhoOpenedCashier_Value.TabIndex = 11;
            this.lbl_PersonWhoOpenedCashier_Value.Text = "Damjan";
            // 
            // lbl_PersonWhoOpenedCashier
            // 
            this.lbl_PersonWhoOpenedCashier.Location = new System.Drawing.Point(13, 44);
            this.lbl_PersonWhoOpenedCashier.Name = "lbl_PersonWhoOpenedCashier";
            this.lbl_PersonWhoOpenedCashier.Size = new System.Drawing.Size(158, 17);
            this.lbl_PersonWhoOpenedCashier.TabIndex = 10;
            this.lbl_PersonWhoOpenedCashier.Text = "Person who opened cashier:";
            this.lbl_PersonWhoOpenedCashier.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // pnl_Realisation
            // 
            this.pnl_Realisation.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnl_Realisation.Location = new System.Drawing.Point(16, 133);
            this.pnl_Realisation.Name = "pnl_Realisation";
            this.pnl_Realisation.Size = new System.Drawing.Size(419, 189);
            this.pnl_Realisation.TabIndex = 12;
            // 
            // lbl_NumberOfInvoices_Value
            // 
            this.lbl_NumberOfInvoices_Value.Location = new System.Drawing.Point(169, 62);
            this.lbl_NumberOfInvoices_Value.Name = "lbl_NumberOfInvoices_Value";
            this.lbl_NumberOfInvoices_Value.Size = new System.Drawing.Size(122, 17);
            this.lbl_NumberOfInvoices_Value.TabIndex = 14;
            this.lbl_NumberOfInvoices_Value.Text = "YY";
            // 
            // lbl_NumberOfInvoices
            // 
            this.lbl_NumberOfInvoices.Location = new System.Drawing.Point(12, 62);
            this.lbl_NumberOfInvoices.Name = "lbl_NumberOfInvoices";
            this.lbl_NumberOfInvoices.Size = new System.Drawing.Size(158, 17);
            this.lbl_NumberOfInvoices.TabIndex = 13;
            this.lbl_NumberOfInvoices.Text = "Number od invoices:";
            this.lbl_NumberOfInvoices.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lbl_NetPrice_Value
            // 
            this.lbl_NetPrice_Value.Location = new System.Drawing.Point(170, 79);
            this.lbl_NetPrice_Value.Name = "lbl_NetPrice_Value";
            this.lbl_NetPrice_Value.Size = new System.Drawing.Size(122, 17);
            this.lbl_NetPrice_Value.TabIndex = 16;
            this.lbl_NetPrice_Value.Text = "EUR ZZ ";
            // 
            // lbl_NetPrice
            // 
            this.lbl_NetPrice.Location = new System.Drawing.Point(13, 79);
            this.lbl_NetPrice.Name = "lbl_NetPrice";
            this.lbl_NetPrice.Size = new System.Drawing.Size(158, 17);
            this.lbl_NetPrice.TabIndex = 15;
            this.lbl_NetPrice.Text = "Net Price:";
            this.lbl_NetPrice.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lbl_TaxPrice_Value
            // 
            this.lbl_TaxPrice_Value.Location = new System.Drawing.Point(170, 96);
            this.lbl_TaxPrice_Value.Name = "lbl_TaxPrice_Value";
            this.lbl_TaxPrice_Value.Size = new System.Drawing.Size(122, 17);
            this.lbl_TaxPrice_Value.TabIndex = 18;
            this.lbl_TaxPrice_Value.Text = "EUR xx";
            this.lbl_TaxPrice_Value.Click += new System.EventHandler(this.label1_Click);
            // 
            // lbl_TaxPrice
            // 
            this.lbl_TaxPrice.Location = new System.Drawing.Point(13, 96);
            this.lbl_TaxPrice.Name = "lbl_TaxPrice";
            this.lbl_TaxPrice.Size = new System.Drawing.Size(158, 17);
            this.lbl_TaxPrice.TabIndex = 17;
            this.lbl_TaxPrice.Text = "Tax:";
            this.lbl_TaxPrice.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lbl_TaxPrice.Click += new System.EventHandler(this.label2_Click);
            // 
            // lbl_Total_Value
            // 
            this.lbl_Total_Value.Location = new System.Drawing.Point(170, 113);
            this.lbl_Total_Value.Name = "lbl_Total_Value";
            this.lbl_Total_Value.Size = new System.Drawing.Size(122, 17);
            this.lbl_Total_Value.TabIndex = 20;
            this.lbl_Total_Value.Text = "EUR yy";
            // 
            // lbl_Total
            // 
            this.lbl_Total.Location = new System.Drawing.Point(13, 113);
            this.lbl_Total.Name = "lbl_Total";
            this.lbl_Total.Size = new System.Drawing.Size(158, 17);
            this.lbl_Total.TabIndex = 19;
            this.lbl_Total.Text = "Total";
            this.lbl_Total.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btn_Print
            // 
            this.btn_Print.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_Print.Location = new System.Drawing.Point(12, 350);
            this.btn_Print.Name = "btn_Print";
            this.btn_Print.Size = new System.Drawing.Size(155, 84);
            this.btn_Print.TabIndex = 21;
            this.btn_Print.Text = "PRINT";
            this.btn_Print.UseVisualStyleBackColor = true;
            // 
            // Form_CloseCashier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 446);
            this.Controls.Add(this.btn_Print);
            this.Controls.Add(this.lbl_Total_Value);
            this.Controls.Add(this.lbl_Total);
            this.Controls.Add(this.lbl_TaxPrice_Value);
            this.Controls.Add(this.lbl_TaxPrice);
            this.Controls.Add(this.lbl_NetPrice_Value);
            this.Controls.Add(this.lbl_NetPrice);
            this.Controls.Add(this.lbl_NumberOfInvoices_Value);
            this.Controls.Add(this.lbl_NumberOfInvoices);
            this.Controls.Add(this.pnl_Realisation);
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
        private System.Windows.Forms.Panel pnl_Realisation;
        private System.Windows.Forms.Label lbl_NumberOfInvoices_Value;
        private System.Windows.Forms.Label lbl_NumberOfInvoices;
        private System.Windows.Forms.Label lbl_NetPrice_Value;
        private System.Windows.Forms.Label lbl_NetPrice;
        private System.Windows.Forms.Label lbl_TaxPrice_Value;
        private System.Windows.Forms.Label lbl_TaxPrice;
        private System.Windows.Forms.Label lbl_Total_Value;
        private System.Windows.Forms.Label lbl_Total;
        private System.Windows.Forms.Button btn_Print;
    }
}