using DataGridView_2xls;

namespace TangentaPrint
{
    partial class usrc_PrintExistingInvoice
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
            this.lbl_Invoice = new System.Windows.Forms.Label();
            this.lbl_Invoice_value = new System.Windows.Forms.Label();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.dgvx_Journal_InvoicePrint = new DataGridView_2xls.DataGridView2xls();
            this.usrc_Help1 = new HUDCMS.usrc_Help();
            ((System.ComponentModel.ISupportInitialize)(this.dgvx_Journal_InvoicePrint)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_Invoice
            // 
            this.lbl_Invoice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_Invoice.ForeColor = System.Drawing.Color.Black;
            this.lbl_Invoice.Location = new System.Drawing.Point(3, 8);
            this.lbl_Invoice.Name = "lbl_Invoice";
            this.lbl_Invoice.Size = new System.Drawing.Size(237, 20);
            this.lbl_Invoice.TabIndex = 9;
            this.lbl_Invoice.Text = "Dnevnik tiskanj računa:";
            this.lbl_Invoice.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_Invoice_value
            // 
            this.lbl_Invoice_value.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_Invoice_value.ForeColor = System.Drawing.Color.Black;
            this.lbl_Invoice_value.Location = new System.Drawing.Point(246, 9);
            this.lbl_Invoice_value.Name = "lbl_Invoice_value";
            this.lbl_Invoice_value.Size = new System.Drawing.Size(265, 19);
            this.lbl_Invoice_value.TabIndex = 10;
            this.lbl_Invoice_value.Text = "Dnevnik tiskanj računa:";
            this.lbl_Invoice_value.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Cancel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_Cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_Cancel.ForeColor = System.Drawing.Color.Black;
            this.btn_Cancel.Image = global::TangentaPrint.Properties.Resources.Exit;
            this.btn_Cancel.Location = new System.Drawing.Point(555, 3);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(57, 24);
            this.btn_Cancel.TabIndex = 11;
            this.btn_Cancel.UseVisualStyleBackColor = false;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // dgvx_Journal_InvoicePrint
            // 
            this.dgvx_Journal_InvoicePrint.AllowUserToAddRows = false;
            this.dgvx_Journal_InvoicePrint.AllowUserToDeleteRows = false;
            this.dgvx_Journal_InvoicePrint.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvx_Journal_InvoicePrint.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvx_Journal_InvoicePrint.DataGridViewWithRowNumber = false;
            this.dgvx_Journal_InvoicePrint.Location = new System.Drawing.Point(3, 34);
            this.dgvx_Journal_InvoicePrint.Name = "dgvx_Journal_InvoicePrint";
            this.dgvx_Journal_InvoicePrint.ReadOnly = true;
            this.dgvx_Journal_InvoicePrint.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvx_Journal_InvoicePrint.Size = new System.Drawing.Size(612, 332);
            this.dgvx_Journal_InvoicePrint.TabIndex = 8;
            // 
            // usrc_Help1
            // 
            this.usrc_Help1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.usrc_Help1.Location = new System.Drawing.Point(517, 3);
            this.usrc_Help1.Name = "usrc_Help1";
            this.usrc_Help1.Size = new System.Drawing.Size(32, 24);
            this.usrc_Help1.TabIndex = 12;
            // 
            // usrc_PrintExistingInvoice
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.usrc_Help1);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.lbl_Invoice_value);
            this.Controls.Add(this.lbl_Invoice);
            this.Controls.Add(this.dgvx_Journal_InvoicePrint);
            this.ForeColor = System.Drawing.Color.Red;
            this.Name = "usrc_PrintExistingInvoice";
            this.Size = new System.Drawing.Size(615, 369);
            ((System.ComponentModel.ISupportInitialize)(this.dgvx_Journal_InvoicePrint)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DataGridView2xls dgvx_Journal_InvoicePrint;
        private System.Windows.Forms.Label lbl_Invoice;
        private System.Windows.Forms.Label lbl_Invoice_value;
        private System.Windows.Forms.Button btn_Cancel;
        private HUDCMS.usrc_Help usrc_Help1;
    }
}
