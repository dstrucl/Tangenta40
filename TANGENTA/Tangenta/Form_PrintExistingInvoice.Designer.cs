namespace Tangenta
{
    partial class Form_PrintExistingInvoice
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
            this.SuspendLayout();
            // 
            // Form_PrintExistingInvoice
            // 
            this.ClientSize = new System.Drawing.Size(677, 400);
            this.Name = "Form_PrintExistingInvoice";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        internal usrc_Invoice_Preview usrc_Invoice_Preview;
        private usrc_PrinterSettings m_usrc_Print;
        private System.Windows.Forms.Button btn_Cancel;
        private usrc_PrintExistingInvoice m_usrc_PrintExistingInvoice;
    }
}