namespace TangentaPrint
{
    partial class Form_PrinterSettings
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
            this.usrc_PrinterSettings1 = new usrc_PrinterSettings();
            this.SuspendLayout();
            // 
            // usrc_PrinterSettings1
            // 
            this.usrc_PrinterSettings1.Location = new System.Drawing.Point(12, 7);
            this.usrc_PrinterSettings1.Name = "usrc_PrinterSettings1";
            this.usrc_PrinterSettings1.Size = new System.Drawing.Size(523, 48);
            this.usrc_PrinterSettings1.TabIndex = 0;
            // 
            // Form_PrinterSettings
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(553, 67);
            this.Controls.Add(this.usrc_PrinterSettings1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form_PrinterSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Nastavitve Tiskalnika";
            this.Load += new System.EventHandler(this.Form_PrinterSettings_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private usrc_PrinterSettings usrc_PrinterSettings1;
    }
}