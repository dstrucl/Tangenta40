namespace LoginControl
{
    partial class usrc_MethotOfPaymentReport
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
            this.pnl_MethodOfPaymentReport_byTaxiation = new System.Windows.Forms.Panel();
            this.lbl_MethodOfPayment_Name = new System.Windows.Forms.Label();
            this.lbl_Total_Value = new System.Windows.Forms.Label();
            this.lbl_Total = new System.Windows.Forms.Label();
            this.lbl_MethodOfPayment_NumOfInvoices = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pnl_MethodOfPaymentReport_byTaxiation
            // 
            this.pnl_MethodOfPaymentReport_byTaxiation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnl_MethodOfPaymentReport_byTaxiation.AutoScroll = true;
            this.pnl_MethodOfPaymentReport_byTaxiation.Location = new System.Drawing.Point(1, 21);
            this.pnl_MethodOfPaymentReport_byTaxiation.Name = "pnl_MethodOfPaymentReport_byTaxiation";
            this.pnl_MethodOfPaymentReport_byTaxiation.Size = new System.Drawing.Size(522, 85);
            this.pnl_MethodOfPaymentReport_byTaxiation.TabIndex = 0;
            // 
            // lbl_MethodOfPayment_Name
            // 
            this.lbl_MethodOfPayment_Name.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_MethodOfPayment_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_MethodOfPayment_Name.Location = new System.Drawing.Point(6, 0);
            this.lbl_MethodOfPayment_Name.Name = "lbl_MethodOfPayment_Name";
            this.lbl_MethodOfPayment_Name.Size = new System.Drawing.Size(160, 19);
            this.lbl_MethodOfPayment_Name.TabIndex = 2;
            this.lbl_MethodOfPayment_Name.Text = "Method Of Payment:";
            // 
            // lbl_Total_Value
            // 
            this.lbl_Total_Value.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Total_Value.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_Total_Value.Location = new System.Drawing.Point(319, 0);
            this.lbl_Total_Value.Name = "lbl_Total_Value";
            this.lbl_Total_Value.Size = new System.Drawing.Size(91, 19);
            this.lbl_Total_Value.TabIndex = 4;
            this.lbl_Total_Value.Text = "XX";
            // 
            // lbl_Total
            // 
            this.lbl_Total.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_Total.Location = new System.Drawing.Point(223, 0);
            this.lbl_Total.Name = "lbl_Total";
            this.lbl_Total.Size = new System.Drawing.Size(99, 19);
            this.lbl_Total.TabIndex = 3;
            this.lbl_Total.Text = "Total:";
            this.lbl_Total.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lbl_MethodOfPayment_NumOfInvoices
            // 
            this.lbl_MethodOfPayment_NumOfInvoices.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_MethodOfPayment_NumOfInvoices.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_MethodOfPayment_NumOfInvoices.Location = new System.Drawing.Point(158, 0);
            this.lbl_MethodOfPayment_NumOfInvoices.Name = "lbl_MethodOfPayment_NumOfInvoices";
            this.lbl_MethodOfPayment_NumOfInvoices.Size = new System.Drawing.Size(74, 19);
            this.lbl_MethodOfPayment_NumOfInvoices.TabIndex = 5;
            this.lbl_MethodOfPayment_NumOfInvoices.Text = "nnnn";
            // 
            // usrc_MethotOfPaymentReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbl_MethodOfPayment_NumOfInvoices);
            this.Controls.Add(this.lbl_Total_Value);
            this.Controls.Add(this.lbl_Total);
            this.Controls.Add(this.lbl_MethodOfPayment_Name);
            this.Controls.Add(this.pnl_MethodOfPaymentReport_byTaxiation);
            this.Name = "usrc_MethotOfPaymentReport";
            this.Size = new System.Drawing.Size(524, 110);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl_MethodOfPaymentReport_byTaxiation;
        private System.Windows.Forms.Label lbl_MethodOfPayment_Name;
        private System.Windows.Forms.Label lbl_Total_Value;
        private System.Windows.Forms.Label lbl_Total;
        private System.Windows.Forms.Label lbl_MethodOfPayment_NumOfInvoices;
    }
}
