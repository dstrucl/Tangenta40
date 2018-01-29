namespace HUDCMS
{
    partial class usrc_web_Help
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
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.lbl_URL = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // webBrowser1
            // 
            this.webBrowser1.AllowWebBrowserDrop = false;
            this.webBrowser1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowser1.IsWebBrowserContextMenuEnabled = false;
            this.webBrowser1.Location = new System.Drawing.Point(2, 20);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.ScriptErrorsSuppressed = true;
            this.webBrowser1.Size = new System.Drawing.Size(683, 524);
            this.webBrowser1.TabIndex = 0;
            // 
            // lbl_URL
            // 
            this.lbl_URL.AutoSize = true;
            this.lbl_URL.Location = new System.Drawing.Point(5, 2);
            this.lbl_URL.Name = "lbl_URL";
            this.lbl_URL.Size = new System.Drawing.Size(35, 13);
            this.lbl_URL.TabIndex = 1;
            this.lbl_URL.Text = "label1";
            // 
            // usrc_web_Help
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.lbl_URL);
            this.Controls.Add(this.webBrowser1);
            this.Name = "usrc_web_Help";
            this.Size = new System.Drawing.Size(686, 545);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.WebBrowser webBrowser1;
        public System.Windows.Forms.Label lbl_URL;
    }
}
