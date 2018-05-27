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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_PrintJournal));
            this.usrc_PrintExistingInvoice1 = new TangentaPrint.usrc_PrintExistingInvoice();
            this.SuspendLayout();
            // 
            // usrc_PrintExistingInvoice1
            // 
            this.usrc_PrintExistingInvoice1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.usrc_PrintExistingInvoice1.ForeColor = System.Drawing.Color.Red;
            this.usrc_PrintExistingInvoice1.Location = new System.Drawing.Point(0, 0);
            this.usrc_PrintExistingInvoice1.Name = "usrc_PrintExistingInvoice1";
            this.usrc_PrintExistingInvoice1.Size = new System.Drawing.Size(677, 400);
            this.usrc_PrintExistingInvoice1.TabIndex = 0;
            this.usrc_PrintExistingInvoice1.Cancel += new TangentaPrint.usrc_PrintExistingInvoice.delegate_Cancel(this.usrc_PrintExistingInvoice1_Cancel);
            // 
            // Form_PrintJournal
            // 
            this.ClientSize = new System.Drawing.Size(677, 400);
            this.Controls.Add(this.usrc_PrintExistingInvoice1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_PrintJournal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);

        }

        #endregion

        private usrc_PrintExistingInvoice usrc_PrintExistingInvoice1;
    }
}