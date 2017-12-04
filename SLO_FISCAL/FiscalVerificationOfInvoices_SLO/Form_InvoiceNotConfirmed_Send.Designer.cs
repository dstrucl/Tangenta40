namespace FiscalVerificationOfInvoices_SLO
{
    partial class Form_InvoiceNotConfirmed_Send
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
            this.dgvx_Invoice_Unsent = new System.Windows.Forms.DataGridView();
            this.lbl_Invoice_UnsentMsg = new System.Windows.Forms.Label();
            this.btn_Cancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvx_Invoice_Unsent)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvx_Invoice_Unsent
            // 
            this.dgvx_Invoice_Unsent.AllowUserToAddRows = false;
            this.dgvx_Invoice_Unsent.AllowUserToDeleteRows = false;
            this.dgvx_Invoice_Unsent.AllowUserToOrderColumns = true;
            this.dgvx_Invoice_Unsent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvx_Invoice_Unsent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvx_Invoice_Unsent.Location = new System.Drawing.Point(15, 70);
            this.dgvx_Invoice_Unsent.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvx_Invoice_Unsent.Name = "dgvx_Invoice_Unsent";
            this.dgvx_Invoice_Unsent.ReadOnly = true;
            this.dgvx_Invoice_Unsent.Size = new System.Drawing.Size(980, 428);
            this.dgvx_Invoice_Unsent.TabIndex = 0;
            // 
            // lbl_Invoice_UnsentMsg
            // 
            this.lbl_Invoice_UnsentMsg.AutoSize = true;
            this.lbl_Invoice_UnsentMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_Invoice_UnsentMsg.ForeColor = System.Drawing.Color.Maroon;
            this.lbl_Invoice_UnsentMsg.Location = new System.Drawing.Point(15, 11);
            this.lbl_Invoice_UnsentMsg.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_Invoice_UnsentMsg.Name = "lbl_Invoice_UnsentMsg";
            this.lbl_Invoice_UnsentMsg.Size = new System.Drawing.Size(310, 25);
            this.lbl_Invoice_UnsentMsg.TabIndex = 1;
            this.lbl_Invoice_UnsentMsg.Text = "lbl_SalesBookInvoice_UnsentMsg";
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Cancel.Image = global::FiscalVerificationOfInvoices_SLO.Properties.Resources.Exit;
            this.btn_Cancel.Location = new System.Drawing.Point(15, 506);
            this.btn_Cancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(122, 48);
            this.btn_Cancel.TabIndex = 2;
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // Form_InvoiceNotConfirmed_Send
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1010, 566);
            this.ControlBox = false;
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.lbl_Invoice_UnsentMsg);
            this.Controls.Add(this.dgvx_Invoice_Unsent);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form_InvoiceNotConfirmed_Send";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Form_SalesBookInvoice_Send_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvx_Invoice_Unsent)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvx_Invoice_Unsent;
        private System.Windows.Forms.Label lbl_Invoice_UnsentMsg;
        private System.Windows.Forms.Button btn_Cancel;
    }
}