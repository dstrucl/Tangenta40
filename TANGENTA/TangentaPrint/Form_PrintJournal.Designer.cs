namespace TangentaPrint

{
    partial class Form_PrintJournal
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
            this.lbl_Printer = new System.Windows.Forms.Label();
            this.lbl_PrinterNameValue = new System.Windows.Forms.Label();
            this.usrc_PrintExistingInvoice1 = new usrc_PrintExistingInvoice();
            this.SuspendLayout();
            // 
            // lbl_Printer
            // 
            this.lbl_Printer.Location = new System.Drawing.Point(3, 3);
            this.lbl_Printer.Name = "lbl_Printer";
            this.lbl_Printer.Size = new System.Drawing.Size(77, 21);
            this.lbl_Printer.TabIndex = 1;
            this.lbl_Printer.Text = "Printer:";
            this.lbl_Printer.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_PrinterNameValue
            // 
            this.lbl_PrinterNameValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_PrinterNameValue.Location = new System.Drawing.Point(96, 1);
            this.lbl_PrinterNameValue.Name = "lbl_PrinterNameValue";
            this.lbl_PrinterNameValue.Size = new System.Drawing.Size(581, 25);
            this.lbl_PrinterNameValue.TabIndex = 2;
            this.lbl_PrinterNameValue.Text = "Printer Name Value";
            this.lbl_PrinterNameValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // usrc_PrintExistingInvoice1
            // 
            this.usrc_PrintExistingInvoice1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.usrc_PrintExistingInvoice1.ForeColor = System.Drawing.Color.Red;
            this.usrc_PrintExistingInvoice1.Location = new System.Drawing.Point(-1, 33);
            this.usrc_PrintExistingInvoice1.Name = "usrc_PrintExistingInvoice1";
            this.usrc_PrintExistingInvoice1.Size = new System.Drawing.Size(678, 364);
            this.usrc_PrintExistingInvoice1.TabIndex = 0;
            this.usrc_PrintExistingInvoice1.Cancel += new usrc_PrintExistingInvoice.delegate_Cancel(this.usrc_PrintExistingInvoice1_Cancel);
            // 
            // Form_PrintExistingInvoice
            // 
            this.ClientSize = new System.Drawing.Size(677, 400);
            this.Controls.Add(this.lbl_PrinterNameValue);
            this.Controls.Add(this.lbl_Printer);
            this.Controls.Add(this.usrc_PrintExistingInvoice1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Name = "Form_PrintExistingInvoice";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);

        }

        #endregion

        private usrc_PrintExistingInvoice usrc_PrintExistingInvoice1;
        private System.Windows.Forms.Label lbl_Printer;
        private System.Windows.Forms.Label lbl_PrinterNameValue;
    }
}