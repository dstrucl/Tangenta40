namespace TangentaPrint
{
    partial class usrc_Printer
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
            this.grp_Printer = new System.Windows.Forms.GroupBox();
            this.chk_PrintingWithHtmlTemplates = new System.Windows.Forms.CheckBox();
            this.btn_Remove = new System.Windows.Forms.Button();
            this.grp_Invoice = new System.Windows.Forms.GroupBox();
            this.grp_Payment = new System.Windows.Forms.GroupBox();
            this.chk_BankAccount = new System.Windows.Forms.CheckBox();
            this.chk_Card = new System.Windows.Forms.CheckBox();
            this.chk_Cash = new System.Windows.Forms.CheckBox();
            this.chk_Printing_Invoices = new System.Windows.Forms.CheckBox();
            this.chk_Printing_Reports = new System.Windows.Forms.CheckBox();
            this.chk_Printing_ProformaInvoices = new System.Windows.Forms.CheckBox();
            this.grp_Printer.SuspendLayout();
            this.grp_Invoice.SuspendLayout();
            this.grp_Payment.SuspendLayout();
            this.SuspendLayout();
            // 
            // grp_Printer
            // 
            this.grp_Printer.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.grp_Printer.Controls.Add(this.chk_PrintingWithHtmlTemplates);
            this.grp_Printer.Controls.Add(this.btn_Remove);
            this.grp_Printer.Controls.Add(this.grp_Invoice);
            this.grp_Printer.Controls.Add(this.chk_Printing_Reports);
            this.grp_Printer.Controls.Add(this.chk_Printing_ProformaInvoices);
            this.grp_Printer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grp_Printer.Location = new System.Drawing.Point(0, 0);
            this.grp_Printer.Name = "grp_Printer";
            this.grp_Printer.Size = new System.Drawing.Size(399, 167);
            this.grp_Printer.TabIndex = 3;
            this.grp_Printer.TabStop = false;
            this.grp_Printer.Text = "Printer 1";
            // 
            // chk_PrintingWithHtmlTemplates
            // 
            this.chk_PrintingWithHtmlTemplates.AutoSize = true;
            this.chk_PrintingWithHtmlTemplates.Location = new System.Drawing.Point(9, 47);
            this.chk_PrintingWithHtmlTemplates.Name = "chk_PrintingWithHtmlTemplates";
            this.chk_PrintingWithHtmlTemplates.Size = new System.Drawing.Size(164, 17);
            this.chk_PrintingWithHtmlTemplates.TabIndex = 7;
            this.chk_PrintingWithHtmlTemplates.Text = "Printing with HTML templates";
            this.chk_PrintingWithHtmlTemplates.UseVisualStyleBackColor = true;
            // 
            // btn_Remove
            // 
            this.btn_Remove.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_Remove.Location = new System.Drawing.Point(6, 19);
            this.btn_Remove.Name = "btn_Remove";
            this.btn_Remove.Size = new System.Drawing.Size(104, 22);
            this.btn_Remove.TabIndex = 6;
            this.btn_Remove.Text = "Remove";
            this.btn_Remove.UseVisualStyleBackColor = false;
            this.btn_Remove.Click += new System.EventHandler(this.btn_Remove_Click);
            // 
            // grp_Invoice
            // 
            this.grp_Invoice.Controls.Add(this.grp_Payment);
            this.grp_Invoice.Controls.Add(this.chk_Printing_Invoices);
            this.grp_Invoice.Location = new System.Drawing.Point(195, 19);
            this.grp_Invoice.Name = "grp_Invoice";
            this.grp_Invoice.Size = new System.Drawing.Size(198, 142);
            this.grp_Invoice.TabIndex = 5;
            this.grp_Invoice.TabStop = false;
            this.grp_Invoice.Text = "Invoice";
            // 
            // grp_Payment
            // 
            this.grp_Payment.Controls.Add(this.chk_BankAccount);
            this.grp_Payment.Controls.Add(this.chk_Card);
            this.grp_Payment.Controls.Add(this.chk_Cash);
            this.grp_Payment.Location = new System.Drawing.Point(6, 44);
            this.grp_Payment.Name = "grp_Payment";
            this.grp_Payment.Size = new System.Drawing.Size(186, 91);
            this.grp_Payment.TabIndex = 2;
            this.grp_Payment.TabStop = false;
            this.grp_Payment.Text = "Payment";
            // 
            // chk_BankAccount
            // 
            this.chk_BankAccount.AutoSize = true;
            this.chk_BankAccount.Checked = true;
            this.chk_BankAccount.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_BankAccount.Location = new System.Drawing.Point(20, 64);
            this.chk_BankAccount.Name = "chk_BankAccount";
            this.chk_BankAccount.Size = new System.Drawing.Size(94, 17);
            this.chk_BankAccount.TabIndex = 5;
            this.chk_BankAccount.Text = "Bank Account";
            this.chk_BankAccount.UseVisualStyleBackColor = true;
            // 
            // chk_Card
            // 
            this.chk_Card.AutoSize = true;
            this.chk_Card.Checked = true;
            this.chk_Card.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_Card.Location = new System.Drawing.Point(20, 42);
            this.chk_Card.Name = "chk_Card";
            this.chk_Card.Size = new System.Drawing.Size(48, 17);
            this.chk_Card.TabIndex = 4;
            this.chk_Card.Text = "Card";
            this.chk_Card.UseVisualStyleBackColor = true;
            // 
            // chk_Cash
            // 
            this.chk_Cash.AutoSize = true;
            this.chk_Cash.Checked = true;
            this.chk_Cash.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_Cash.Location = new System.Drawing.Point(20, 19);
            this.chk_Cash.Name = "chk_Cash";
            this.chk_Cash.Size = new System.Drawing.Size(50, 17);
            this.chk_Cash.TabIndex = 3;
            this.chk_Cash.Text = "Cash";
            this.chk_Cash.UseVisualStyleBackColor = true;
            // 
            // chk_Printing_Invoices
            // 
            this.chk_Printing_Invoices.AutoSize = true;
            this.chk_Printing_Invoices.Checked = true;
            this.chk_Printing_Invoices.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_Printing_Invoices.Location = new System.Drawing.Point(6, 19);
            this.chk_Printing_Invoices.Name = "chk_Printing_Invoices";
            this.chk_Printing_Invoices.Size = new System.Drawing.Size(104, 17);
            this.chk_Printing_Invoices.TabIndex = 1;
            this.chk_Printing_Invoices.Text = "Printing Invoices";
            this.chk_Printing_Invoices.UseVisualStyleBackColor = true;
            // 
            // chk_Printing_Reports
            // 
            this.chk_Printing_Reports.AutoSize = true;
            this.chk_Printing_Reports.Location = new System.Drawing.Point(9, 82);
            this.chk_Printing_Reports.Name = "chk_Printing_Reports";
            this.chk_Printing_Reports.Size = new System.Drawing.Size(101, 17);
            this.chk_Printing_Reports.TabIndex = 3;
            this.chk_Printing_Reports.Text = "Printing Reports";
            this.chk_Printing_Reports.UseVisualStyleBackColor = true;
            // 
            // chk_Printing_ProformaInvoices
            // 
            this.chk_Printing_ProformaInvoices.AutoSize = true;
            this.chk_Printing_ProformaInvoices.Location = new System.Drawing.Point(9, 105);
            this.chk_Printing_ProformaInvoices.Name = "chk_Printing_ProformaInvoices";
            this.chk_Printing_ProformaInvoices.Size = new System.Drawing.Size(149, 17);
            this.chk_Printing_ProformaInvoices.TabIndex = 2;
            this.chk_Printing_ProformaInvoices.Text = "Printing Proforma Invoices";
            this.chk_Printing_ProformaInvoices.UseVisualStyleBackColor = true;
            // 
            // usrc_Printer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grp_Printer);
            this.Name = "usrc_Printer";
            this.Size = new System.Drawing.Size(399, 167);
            this.grp_Printer.ResumeLayout(false);
            this.grp_Printer.PerformLayout();
            this.grp_Invoice.ResumeLayout(false);
            this.grp_Invoice.PerformLayout();
            this.grp_Payment.ResumeLayout(false);
            this.grp_Payment.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grp_Printer;
        private System.Windows.Forms.CheckBox chk_Printing_Reports;
        private System.Windows.Forms.CheckBox chk_Printing_ProformaInvoices;
        private System.Windows.Forms.CheckBox chk_Printing_Invoices;
        private System.Windows.Forms.GroupBox grp_Invoice;
        private System.Windows.Forms.GroupBox grp_Payment;
        private System.Windows.Forms.CheckBox chk_BankAccount;
        private System.Windows.Forms.CheckBox chk_Card;
        private System.Windows.Forms.CheckBox chk_Cash;
        private System.Windows.Forms.Button btn_Remove;
        private System.Windows.Forms.CheckBox chk_PrintingWithHtmlTemplates;
    }
}
