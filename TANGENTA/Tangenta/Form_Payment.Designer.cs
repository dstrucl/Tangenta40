namespace Tangenta
{
    partial class Form_Payment
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.usrc_Invoice_Preview = new Tangenta.usrc_Invoice_Preview();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.m_usrc_Payment = new Tangenta.usrc_Payment();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Location = new System.Drawing.Point(-1, 12);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.usrc_Invoice_Preview);
            this.splitContainer1.Panel1Collapsed = true;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btn_Cancel);
            this.splitContainer1.Panel2.Controls.Add(this.m_usrc_Payment);
            this.splitContainer1.Size = new System.Drawing.Size(1002, 635);
            this.splitContainer1.SplitterDistance = 360;
            this.splitContainer1.TabIndex = 1;
            // 
            // usrc_Invoice_Preview
            // 
            this.usrc_Invoice_Preview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.usrc_Invoice_Preview.AutoScroll = true;
            this.usrc_Invoice_Preview.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.usrc_Invoice_Preview.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.usrc_Invoice_Preview.html_doc_text = "Document Template not set";
            this.usrc_Invoice_Preview.Location = new System.Drawing.Point(3, 3);
            this.usrc_Invoice_Preview.Name = "usrc_Invoice_Preview";
            this.usrc_Invoice_Preview.Size = new System.Drawing.Size(352, 1162);
            this.usrc_Invoice_Preview.TabIndex = 0;
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Retry;
            this.btn_Cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_Cancel.Location = new System.Drawing.Point(3, 574);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(178, 56);
            this.btn_Cancel.TabIndex = 12;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // m_usrc_Payment
            // 
            this.m_usrc_Payment.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_usrc_Payment.ForeColor = System.Drawing.Color.Coral;
            this.m_usrc_Payment.Location = new System.Drawing.Point(3, 61);
            this.m_usrc_Payment.Name = "m_usrc_Payment";
            this.m_usrc_Payment.Size = new System.Drawing.Size(994, 507);
            this.m_usrc_Payment.TabIndex = 0;
            this.m_usrc_Payment.DoPrint += new Tangenta.usrc_Payment.delegate_DoPrint(this.usrc_Payment_DoPrint);
            // 
            // Form_Payment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1004, 665);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form_Payment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Receipt_Preview_Form";
            this.Load += new System.EventHandler(this.Form_Receipt_Preview_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private usrc_Payment m_usrc_Payment;
        internal usrc_Invoice_Preview usrc_Invoice_Preview;
        private System.Windows.Forms.Button btn_Cancel;
    }
}