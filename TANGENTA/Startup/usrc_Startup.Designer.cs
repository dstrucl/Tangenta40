namespace Startup
{
    partial class usrc_Startup
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
            this.lbl_StartUp = new System.Windows.Forms.Label();
            this.web_HELP = new System.Windows.Forms.WebBrowser();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_StartUp
            // 
            this.lbl_StartUp.AutoSize = true;
            this.lbl_StartUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_StartUp.Location = new System.Drawing.Point(18, 12);
            this.lbl_StartUp.Name = "lbl_StartUp";
            this.lbl_StartUp.Size = new System.Drawing.Size(70, 26);
            this.lbl_StartUp.TabIndex = 0;
            this.lbl_StartUp.Text = "label1";
            // 
            // web_HELP
            // 
            this.web_HELP.AllowWebBrowserDrop = false;
            this.web_HELP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.web_HELP.Location = new System.Drawing.Point(0, 0);
            this.web_HELP.MinimumSize = new System.Drawing.Size(20, 20);
            this.web_HELP.Name = "web_HELP";
            this.web_HELP.ScriptErrorsSuppressed = true;
            this.web_HELP.Size = new System.Drawing.Size(506, 593);
            this.web_HELP.TabIndex = 1;
            this.web_HELP.Url = new System.Uri("http://www.24ur.com", System.UriKind.Absolute);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.web_HELP);
            this.panel1.Location = new System.Drawing.Point(347, 22);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(510, 597);
            this.panel1.TabIndex = 2;
            // 
            // usrc_Startup
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lbl_StartUp);
            this.Name = "usrc_Startup";
            this.Size = new System.Drawing.Size(869, 635);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_StartUp;
        private System.Windows.Forms.WebBrowser web_HELP;
        private System.Windows.Forms.Panel panel1;
    }
}
