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
            this.lbl_MethodOfPayment_Name = new System.Windows.Forms.Label();
            this.txt_Total_Value = new System.Windows.Forms.TextBox();
            this.lbl_Total = new System.Windows.Forms.Label();
            this.txt_MethodOfPayment_NumOfInvoices = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lbl_MethodOfPayment_Name
            // 
            this.lbl_MethodOfPayment_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_MethodOfPayment_Name.Location = new System.Drawing.Point(-2, 3);
            this.lbl_MethodOfPayment_Name.Name = "lbl_MethodOfPayment_Name";
            this.lbl_MethodOfPayment_Name.Size = new System.Drawing.Size(105, 15);
            this.lbl_MethodOfPayment_Name.TabIndex = 2;
            this.lbl_MethodOfPayment_Name.Text = "Method Of Payment:";
            // 
            // txt_Total_Value
            // 
            this.txt_Total_Value.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txt_Total_Value.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_Total_Value.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_Total_Value.Location = new System.Drawing.Point(220, 4);
            this.txt_Total_Value.Name = "txt_Total_Value";
            this.txt_Total_Value.Size = new System.Drawing.Size(90, 13);
            this.txt_Total_Value.TabIndex = 4;
            this.txt_Total_Value.Text = "XX";
            // 
            // lbl_Total
            // 
            this.lbl_Total.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_Total.Location = new System.Drawing.Point(166, 4);
            this.lbl_Total.Name = "lbl_Total";
            this.lbl_Total.Size = new System.Drawing.Size(54, 12);
            this.lbl_Total.TabIndex = 3;
            this.lbl_Total.Text = "Total:";
            this.lbl_Total.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txt_MethodOfPayment_NumOfInvoices
            // 
            this.txt_MethodOfPayment_NumOfInvoices.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txt_MethodOfPayment_NumOfInvoices.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_MethodOfPayment_NumOfInvoices.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_MethodOfPayment_NumOfInvoices.Location = new System.Drawing.Point(109, 3);
            this.txt_MethodOfPayment_NumOfInvoices.Name = "txt_MethodOfPayment_NumOfInvoices";
            this.txt_MethodOfPayment_NumOfInvoices.Size = new System.Drawing.Size(56, 13);
            this.txt_MethodOfPayment_NumOfInvoices.TabIndex = 5;
            this.txt_MethodOfPayment_NumOfInvoices.Text = "nnnn";
            // 
            // usrc_MethotOfPaymentReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.txt_MethodOfPayment_NumOfInvoices);
            this.Controls.Add(this.txt_Total_Value);
            this.Controls.Add(this.lbl_Total);
            this.Controls.Add(this.lbl_MethodOfPayment_Name);
            this.Name = "usrc_MethotOfPaymentReport";
            this.Size = new System.Drawing.Size(317, 26);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbl_MethodOfPayment_Name;
        private System.Windows.Forms.Label lbl_Total;
        private System.Windows.Forms.TextBox txt_MethodOfPayment_NumOfInvoices;
        private System.Windows.Forms.TextBox txt_Total_Value;
    }
}
