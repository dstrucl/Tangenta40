namespace TransactionLog
{
    partial class Form_TransactionLog
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
            this.usrc_TransactionLog1 = new usrc_TransactionLog();
            this.SuspendLayout();
            // 
            // usrc_TransactionLog1
            // 
            this.usrc_TransactionLog1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.usrc_TransactionLog1.Location = new System.Drawing.Point(0, 0);
            this.usrc_TransactionLog1.Name = "usrc_TransactionLog1";
            this.usrc_TransactionLog1.Size = new System.Drawing.Size(1163, 450);
            this.usrc_TransactionLog1.TabIndex = 0;
            // 
            // Form_TransactionLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1163, 450);
            this.Controls.Add(this.usrc_TransactionLog1);
            this.Name = "Form_TransactionLog";
            this.Text = "Form_TransactionLog";
            this.Load += new System.EventHandler(this.Form_TransactionLog_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private usrc_TransactionLog usrc_TransactionLog1;
    }
}