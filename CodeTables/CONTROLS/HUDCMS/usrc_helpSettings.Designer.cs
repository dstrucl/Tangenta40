namespace HUDCMS
{
    partial class usrc_HelpSettings
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
            this.grp_HelpSettings = new System.Windows.Forms.GroupBox();
            this.txt_RemoteHelpURL = new System.Windows.Forms.TextBox();
            this.lbl_RemoteURL = new System.Windows.Forms.Label();
            this.usrc_SelectLocalHelpFolder = new SelectFolder.usrc_SelectFolder();
            this.grp_HelpSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // grp_HelpSettings
            // 
            this.grp_HelpSettings.Controls.Add(this.usrc_SelectLocalHelpFolder);
            this.grp_HelpSettings.Controls.Add(this.txt_RemoteHelpURL);
            this.grp_HelpSettings.Controls.Add(this.lbl_RemoteURL);
            this.grp_HelpSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grp_HelpSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.grp_HelpSettings.Location = new System.Drawing.Point(0, 0);
            this.grp_HelpSettings.Name = "grp_HelpSettings";
            this.grp_HelpSettings.Size = new System.Drawing.Size(531, 94);
            this.grp_HelpSettings.TabIndex = 9;
            this.grp_HelpSettings.TabStop = false;
            this.grp_HelpSettings.Text = "Help Settings";
            // 
            // txt_RemoteHelpURL
            // 
            this.txt_RemoteHelpURL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_RemoteHelpURL.Location = new System.Drawing.Point(219, 26);
            this.txt_RemoteHelpURL.Name = "txt_RemoteHelpURL";
            this.txt_RemoteHelpURL.Size = new System.Drawing.Size(306, 22);
            this.txt_RemoteHelpURL.TabIndex = 10;
            // 
            // lbl_RemoteURL
            // 
            this.lbl_RemoteURL.Location = new System.Drawing.Point(3, 27);
            this.lbl_RemoteURL.Name = "lbl_RemoteURL";
            this.lbl_RemoteURL.Size = new System.Drawing.Size(210, 19);
            this.lbl_RemoteURL.TabIndex = 9;
            this.lbl_RemoteURL.Text = "Remote HELP URL";
            this.lbl_RemoteURL.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // usrc_SelectLocalHelpFolder
            // 
            this.usrc_SelectLocalHelpFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.usrc_SelectLocalHelpFolder.InitialDirectory = "C:\\";
            this.usrc_SelectLocalHelpFolder.LabelText = "Local HELP folder";
            this.usrc_SelectLocalHelpFolder.Location = new System.Drawing.Point(6, 52);
            this.usrc_SelectLocalHelpFolder.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.usrc_SelectLocalHelpFolder.Name = "usrc_SelectLocalHelpFolder";
            this.usrc_SelectLocalHelpFolder.SelectedFolder = "";
            this.usrc_SelectLocalHelpFolder.Size = new System.Drawing.Size(515, 33);
            this.usrc_SelectLocalHelpFolder.TabIndex = 12;
            this.usrc_SelectLocalHelpFolder.Title = "Select Folder";
            // 
            // usrc_HelpSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.grp_HelpSettings);
            this.Name = "usrc_HelpSettings";
            this.Size = new System.Drawing.Size(531, 94);
            this.grp_HelpSettings.ResumeLayout(false);
            this.grp_HelpSettings.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.TextBox txt_RemoteHelpURL;
        public SelectFolder.usrc_SelectFolder usrc_SelectLocalHelpFolder;
        public System.Windows.Forms.GroupBox grp_HelpSettings;
        public System.Windows.Forms.Label lbl_RemoteURL;
    }
}
