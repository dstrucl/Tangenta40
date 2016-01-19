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
            this.m_usrc_Payment = new Tangenta.usrc_Payment();
            this.SuspendLayout();
            // 
            // m_usrc_Payment
            // 
            this.m_usrc_Payment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_usrc_Payment.ForeColor = System.Drawing.Color.Coral;
            this.m_usrc_Payment.Location = new System.Drawing.Point(0, 0);
            this.m_usrc_Payment.Name = "m_usrc_Payment";
            this.m_usrc_Payment.Size = new System.Drawing.Size(759, 389);
            this.m_usrc_Payment.TabIndex = 1;
            this.m_usrc_Payment.Cancel += new Tangenta.usrc_Payment.delegate_Cancel(this.m_usrc_Payment_Cancel);
            this.m_usrc_Payment.OK += new Tangenta.usrc_Payment.delegate_OK(this.m_usrc_Payment_OK);
            // 
            // Form_Payment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(759, 389);
            this.Controls.Add(this.m_usrc_Payment);
            this.Name = "Form_Payment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Receipt_Preview_Form";
            this.Load += new System.EventHandler(this.Form_Payment_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private usrc_Payment m_usrc_Payment;
    }
}