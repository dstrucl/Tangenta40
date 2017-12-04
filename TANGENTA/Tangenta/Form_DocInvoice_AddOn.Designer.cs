namespace Tangenta
{
    partial class Form_DocInvoice_AddOn
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_DocInvoice_AddOn));
            this.m_usrc_DocInvoice_AddOn = new Tangenta.usrc_DocInvoice_AddOn();
            this.SuspendLayout();
            // 
            // m_usrc_DocInvoice_AddOn
            // 
            this.m_usrc_DocInvoice_AddOn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_usrc_DocInvoice_AddOn.ForeColor = System.Drawing.Color.Black;
            this.m_usrc_DocInvoice_AddOn.Location = new System.Drawing.Point(0, 0);
            this.m_usrc_DocInvoice_AddOn.Margin = new System.Windows.Forms.Padding(5);
            this.m_usrc_DocInvoice_AddOn.Name = "m_usrc_DocInvoice_AddOn";
            this.m_usrc_DocInvoice_AddOn.Size = new System.Drawing.Size(890, 742);
            this.m_usrc_DocInvoice_AddOn.TabIndex = 1;
            this.m_usrc_DocInvoice_AddOn.Cancel += new Tangenta.usrc_DocInvoice_AddOn.delegate_Cancel(this.m_usrc_Payment_Cancel);
            this.m_usrc_DocInvoice_AddOn.Issue += new Tangenta.usrc_DocInvoice_AddOn.delegate_Issue(this.m_usrc_Payment_Issue);
            // 
            // Form_DocInvoice_AddOn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(890, 742);
            this.Controls.Add(this.m_usrc_DocInvoice_AddOn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form_DocInvoice_AddOn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Receipt_Preview_Form";
            this.Load += new System.EventHandler(this.Form_Payment_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private usrc_DocInvoice_AddOn m_usrc_DocInvoice_AddOn;
    }
}