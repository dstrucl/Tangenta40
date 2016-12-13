namespace Tangenta
{
    partial class Form_DocProformaInvoice_AddOn
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
            this.m_usrc_DocProformaInvoice_AddOn = new Tangenta.usrc_DocProformaInvoice_AddOn();
            this.SuspendLayout();
            // 
            // m_usrc_DocProformaInvoice_AddOn
            // 
            this.m_usrc_DocProformaInvoice_AddOn.AutoScroll = true;
            this.m_usrc_DocProformaInvoice_AddOn.BackColor = System.Drawing.SystemColors.Control;
            this.m_usrc_DocProformaInvoice_AddOn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_usrc_DocProformaInvoice_AddOn.ForeColor = System.Drawing.Color.Red;
            this.m_usrc_DocProformaInvoice_AddOn.Location = new System.Drawing.Point(0, 0);
            this.m_usrc_DocProformaInvoice_AddOn.Name = "m_usrc_DocProformaInvoice_AddOn";
            this.m_usrc_DocProformaInvoice_AddOn.Size = new System.Drawing.Size(575, 506);
            this.m_usrc_DocProformaInvoice_AddOn.TabIndex = 0;
            // 
            // Form_DocProformaInvoice_Payment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(575, 506);
            this.Controls.Add(this.m_usrc_DocProformaInvoice_AddOn);
            this.Name = "Form_DocProformaInvoice_Payment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Receipt_Preview_Form";
            this.Load += new System.EventHandler(this.Form_DocProformaInvoice_Payment_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private usrc_DocProformaInvoice_AddOn m_usrc_DocProformaInvoice_AddOn;
    }
}