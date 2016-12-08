namespace TangentaPrint
{
    partial class Form_DeviceSettings
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
            this.m_usrc_DeviceSettings = new TangentaPrint.usrc_DeviceSettings();
            this.SuspendLayout();
            // 
            // m_usrc_DeviceSettings
            // 
            this.m_usrc_DeviceSettings.Location = new System.Drawing.Point(12, 7);
            this.m_usrc_DeviceSettings.Name = "m_usrc_DeviceSettings";
            this.m_usrc_DeviceSettings.Size = new System.Drawing.Size(523, 48);
            this.m_usrc_DeviceSettings.TabIndex = 0;
            // 
            // Form_DeviceSettings
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(553, 67);
            this.Controls.Add(this.m_usrc_DeviceSettings);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form_DeviceSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nastavitve Tiskalnika";
            this.Load += new System.EventHandler(this.Form_PrinterSettings_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private usrc_DeviceSettings m_usrc_DeviceSettings;
    }
}