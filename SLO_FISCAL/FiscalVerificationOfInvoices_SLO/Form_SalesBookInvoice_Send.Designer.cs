namespace FiscalVerificationOfInvoices_SLO
{
    partial class Form_SalesBookInvoice_Send
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
            this.dgvx_SalesBookInvoice_Unsent = new System.Windows.Forms.DataGridView();
            this.lbl_SalesBookInvoice_UnsentMsg = new System.Windows.Forms.Label();
            this.btn_Cancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvx_SalesBookInvoice_Unsent)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvx_SalesBookInvoice_Unsent
            // 
            this.dgvx_SalesBookInvoice_Unsent.AllowUserToAddRows = false;
            this.dgvx_SalesBookInvoice_Unsent.AllowUserToDeleteRows = false;
            this.dgvx_SalesBookInvoice_Unsent.AllowUserToOrderColumns = true;
            this.dgvx_SalesBookInvoice_Unsent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvx_SalesBookInvoice_Unsent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvx_SalesBookInvoice_Unsent.Location = new System.Drawing.Point(12, 56);
            this.dgvx_SalesBookInvoice_Unsent.Name = "dgvx_SalesBookInvoice_Unsent";
            this.dgvx_SalesBookInvoice_Unsent.ReadOnly = true;
            this.dgvx_SalesBookInvoice_Unsent.Size = new System.Drawing.Size(784, 342);
            this.dgvx_SalesBookInvoice_Unsent.TabIndex = 0;
            // 
            // lbl_SalesBookInvoice_UnsentMsg
            // 
            this.lbl_SalesBookInvoice_UnsentMsg.AutoSize = true;
            this.lbl_SalesBookInvoice_UnsentMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_SalesBookInvoice_UnsentMsg.ForeColor = System.Drawing.Color.Maroon;
            this.lbl_SalesBookInvoice_UnsentMsg.Location = new System.Drawing.Point(12, 9);
            this.lbl_SalesBookInvoice_UnsentMsg.Name = "lbl_SalesBookInvoice_UnsentMsg";
            this.lbl_SalesBookInvoice_UnsentMsg.Size = new System.Drawing.Size(251, 20);
            this.lbl_SalesBookInvoice_UnsentMsg.TabIndex = 1;
            this.lbl_SalesBookInvoice_UnsentMsg.Text = "lbl_SalesBookInvoice_UnsentMsg";
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Cancel.Image = global::FiscalVerificationOfInvoices_SLO.Properties.Resources.Exit;
            this.btn_Cancel.Location = new System.Drawing.Point(12, 405);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(98, 38);
            this.btn_Cancel.TabIndex = 2;
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // Form_SalesBookInvoice_Send
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(808, 453);
            this.ControlBox = false;
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.lbl_SalesBookInvoice_UnsentMsg);
            this.Controls.Add(this.dgvx_SalesBookInvoice_Unsent);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "Form_SalesBookInvoice_Send";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vezana Knjiga Računov - neposlani računi:";
            this.Load += new System.EventHandler(this.Form_SalesBookInvoice_Send_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvx_SalesBookInvoice_Unsent)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvx_SalesBookInvoice_Unsent;
        private System.Windows.Forms.Label lbl_SalesBookInvoice_UnsentMsg;
        private System.Windows.Forms.Button btn_Cancel;
    }
}