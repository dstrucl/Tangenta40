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
            this.m_usrc_Device = new TangentaPrint.usrc_Device();
            this.chk_Printing_Reports = new System.Windows.Forms.CheckBox();
            this.chk_Printing_ProformaInvoices = new System.Windows.Forms.CheckBox();
            this.chk_Printing_Invoices = new System.Windows.Forms.CheckBox();
            this.usrc_Printer1 = new TangentaPrint.usrc_Device();
            this.grp_Printer.SuspendLayout();
            this.SuspendLayout();
            // 
            // grp_Printer
            // 
            this.grp_Printer.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.grp_Printer.Controls.Add(this.m_usrc_Device);
            this.grp_Printer.Controls.Add(this.chk_Printing_Reports);
            this.grp_Printer.Controls.Add(this.chk_Printing_ProformaInvoices);
            this.grp_Printer.Controls.Add(this.chk_Printing_Invoices);
            this.grp_Printer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grp_Printer.Location = new System.Drawing.Point(0, 0);
            this.grp_Printer.Name = "grp_Printer";
            this.grp_Printer.Size = new System.Drawing.Size(226, 159);
            this.grp_Printer.TabIndex = 3;
            this.grp_Printer.TabStop = false;
            this.grp_Printer.Text = "Printer 1";
            // 
            // m_usrc_Device
            // 
            this.m_usrc_Device.Location = new System.Drawing.Point(4, 20);
            this.m_usrc_Device.Name = "m_usrc_Device";
            this.m_usrc_Device.Size = new System.Drawing.Size(216, 28);
            this.m_usrc_Device.TabIndex = 4;
            // 
            // chk_Printing_Reports
            // 
            this.chk_Printing_Reports.AutoSize = true;
            this.chk_Printing_Reports.Location = new System.Drawing.Point(23, 122);
            this.chk_Printing_Reports.Name = "chk_Printing_Reports";
            this.chk_Printing_Reports.Size = new System.Drawing.Size(101, 17);
            this.chk_Printing_Reports.TabIndex = 3;
            this.chk_Printing_Reports.Text = "Printing Reports";
            this.chk_Printing_Reports.UseVisualStyleBackColor = true;
            // 
            // chk_Printing_ProformaInvoices
            // 
            this.chk_Printing_ProformaInvoices.AutoSize = true;
            this.chk_Printing_ProformaInvoices.Location = new System.Drawing.Point(23, 90);
            this.chk_Printing_ProformaInvoices.Name = "chk_Printing_ProformaInvoices";
            this.chk_Printing_ProformaInvoices.Size = new System.Drawing.Size(149, 17);
            this.chk_Printing_ProformaInvoices.TabIndex = 2;
            this.chk_Printing_ProformaInvoices.Text = "Printing Proforma Invoices";
            this.chk_Printing_ProformaInvoices.UseVisualStyleBackColor = true;
            // 
            // chk_Printing_Invoices
            // 
            this.chk_Printing_Invoices.AutoSize = true;
            this.chk_Printing_Invoices.Checked = true;
            this.chk_Printing_Invoices.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_Printing_Invoices.Location = new System.Drawing.Point(23, 61);
            this.chk_Printing_Invoices.Name = "chk_Printing_Invoices";
            this.chk_Printing_Invoices.Size = new System.Drawing.Size(104, 17);
            this.chk_Printing_Invoices.TabIndex = 1;
            this.chk_Printing_Invoices.Text = "Printing Invoices";
            this.chk_Printing_Invoices.UseVisualStyleBackColor = true;
            // 
            // usrc_Printer1
            // 
            this.usrc_Printer1.Location = new System.Drawing.Point(6, 26);
            this.usrc_Printer1.Name = "usrc_Printer1";
            this.usrc_Printer1.Size = new System.Drawing.Size(241, 28);
            this.usrc_Printer1.TabIndex = 0;
            // 
            // usrc_Printer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grp_Printer);
            this.Name = "usrc_Printer";
            this.Size = new System.Drawing.Size(226, 159);
            this.grp_Printer.ResumeLayout(false);
            this.grp_Printer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grp_Printer;
        private System.Windows.Forms.CheckBox chk_Printing_Reports;
        private System.Windows.Forms.CheckBox chk_Printing_ProformaInvoices;
        private System.Windows.Forms.CheckBox chk_Printing_Invoices;
        private usrc_Device usrc_Printer1;
        internal usrc_Device m_usrc_Device;
    }
}
