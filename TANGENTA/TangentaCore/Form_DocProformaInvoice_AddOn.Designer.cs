namespace TangentaCore
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
            this.usrc_DocProformaInvoice_AddOn1 = new usrc_DocProformaInvoice_AddOn();
            this.SuspendLayout();
            // 
            // usrc_DocProformaInvoice_AddOn1
            // 
            this.usrc_DocProformaInvoice_AddOn1.BackColor = System.Drawing.SystemColors.Control;
            this.usrc_DocProformaInvoice_AddOn1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.usrc_DocProformaInvoice_AddOn1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.usrc_DocProformaInvoice_AddOn1.ForeColor = System.Drawing.Color.Black;
            this.usrc_DocProformaInvoice_AddOn1.Location = new System.Drawing.Point(0, 0);
            this.usrc_DocProformaInvoice_AddOn1.Margin = new System.Windows.Forms.Padding(2);
            this.usrc_DocProformaInvoice_AddOn1.Name = "usrc_DocProformaInvoice_AddOn1";
            this.usrc_DocProformaInvoice_AddOn1.Size = new System.Drawing.Size(656, 618);
            this.usrc_DocProformaInvoice_AddOn1.TabIndex = 0;
            this.usrc_DocProformaInvoice_AddOn1.Cancel += new usrc_DocProformaInvoice_AddOn.delegate_Cancel(this.usrc_DocProformaInvoice_AddOn1_Cancel);
            this.usrc_DocProformaInvoice_AddOn1.OK += new usrc_DocProformaInvoice_AddOn.delegate_OK(this.usrc_DocProformaInvoice_AddOn1_OK);
            // 
            // Form_DocProformaInvoice_AddOn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(656, 618);
            this.Controls.Add(this.usrc_DocProformaInvoice_AddOn1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_DocProformaInvoice_AddOn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Receipt_Preview_Form";
            this.Load += new System.EventHandler(this.Form_DocProformaInvoice_Payment_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private usrc_DocProformaInvoice_AddOn usrc_DocProformaInvoice_AddOn1;
    }
}