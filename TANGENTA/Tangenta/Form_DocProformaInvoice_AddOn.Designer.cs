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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_DocProformaInvoice_AddOn));
            this.m_usrc_DocProformaInvoice_AddOn = new Tangenta.usrc_DocProformaInvoice_AddOn();
            this.SuspendLayout();
            // 
            // m_usrc_DocProformaInvoice_AddOn
            // 
            this.m_usrc_DocProformaInvoice_AddOn.AutoScroll = true;
            this.m_usrc_DocProformaInvoice_AddOn.BackColor = System.Drawing.SystemColors.Control;
            this.m_usrc_DocProformaInvoice_AddOn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_usrc_DocProformaInvoice_AddOn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.m_usrc_DocProformaInvoice_AddOn.ForeColor = System.Drawing.Color.Black;
            this.m_usrc_DocProformaInvoice_AddOn.Location = new System.Drawing.Point(0, 0);
            this.m_usrc_DocProformaInvoice_AddOn.Name = "m_usrc_DocProformaInvoice_AddOn";
            this.m_usrc_DocProformaInvoice_AddOn.Size = new System.Drawing.Size(573, 618);
            this.m_usrc_DocProformaInvoice_AddOn.TabIndex = 0;
            this.m_usrc_DocProformaInvoice_AddOn.Cancel += new Tangenta.usrc_DocProformaInvoice_AddOn.delegate_Cancel(this.m_usrc_DocProformaInvoice_AddOn_Cancel);
            this.m_usrc_DocProformaInvoice_AddOn.OK += new Tangenta.usrc_DocProformaInvoice_AddOn.delegate_OK(this.m_usrc_DocProformaInvoice_AddOn_OK);
            // 
            // Form_DocProformaInvoice_AddOn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(573, 618);
            this.Controls.Add(this.m_usrc_DocProformaInvoice_AddOn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_DocProformaInvoice_AddOn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Receipt_Preview_Form";
            this.Load += new System.EventHandler(this.Form_DocProformaInvoice_Payment_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private usrc_DocProformaInvoice_AddOn m_usrc_DocProformaInvoice_AddOn;
    }
}