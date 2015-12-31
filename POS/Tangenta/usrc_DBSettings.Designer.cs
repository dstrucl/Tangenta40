namespace Tangenta
{
    partial class usrc_DBSettings
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_Settings = new System.Windows.Forms.Button();
            this.m_usrc_Upgrade = new Tangenta.usrc_Upgrade();
            this.SuspendLayout();
            // 
            // btn_Settings
            // 
            this.btn_Settings.Image = global::Tangenta.Properties.Resources.DBSettings;
            this.btn_Settings.Location = new System.Drawing.Point(46, 0);
            this.btn_Settings.Name = "btn_Settings";
            this.btn_Settings.Size = new System.Drawing.Size(62, 32);
            this.btn_Settings.TabIndex = 0;
            this.btn_Settings.UseVisualStyleBackColor = true;
            this.btn_Settings.Click += new System.EventHandler(this.btn_Settings_Click);
            // 
            // m_usrc_Upgrade
            // 
            this.m_usrc_Upgrade.Location = new System.Drawing.Point(-1, 0);
            this.m_usrc_Upgrade.Name = "m_usrc_Upgrade";
            this.m_usrc_Upgrade.Size = new System.Drawing.Size(43, 33);
            this.m_usrc_Upgrade.TabIndex = 1;
            this.m_usrc_Upgrade.Backup += new Tangenta.usrc_Upgrade.delegate_Backup(this.m_usrc_Upgrade_Backup);
            this.m_usrc_Upgrade.Load += new System.EventHandler(this.m_usrc_Upgrade_Load);
            // 
            // usrc_DBSettings
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.m_usrc_Upgrade);
            this.Controls.Add(this.btn_Settings);
            this.Name = "usrc_DBSettings";
            this.Size = new System.Drawing.Size(109, 31);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Settings;
        private usrc_Upgrade m_usrc_Upgrade;
    }
}
