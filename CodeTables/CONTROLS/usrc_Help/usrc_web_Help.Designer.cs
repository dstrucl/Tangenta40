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
            this.chk_Local = new System.Windows.Forms.CheckBox();
            this.btnEdit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // webBrowser1
            // 
            this.webBrowser1.AllowWebBrowserDrop = false;
            this.webBrowser1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowser1.IsWebBrowserContextMenuEnabled = false;
            this.webBrowser1.Location = new System.Drawing.Point(2, 24);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.ScriptErrorsSuppressed = true;
            this.webBrowser1.Size = new System.Drawing.Size(683, 520);
            this.webBrowser1.TabIndex = 0;
            // 
            // lbl_URL
            // 
            this.lbl_URL.AutoSize = true;
            this.lbl_URL.Location = new System.Drawing.Point(5, 2);
            this.lbl_URL.Name = "lbl_URL";
            this.lbl_URL.Size = new System.Drawing.Size(46, 17);
            this.lbl_URL.TabIndex = 1;
            this.lbl_URL.Text = "label1";
            // 
            // chk_Local
            // 
            this.chk_Local.AutoSize = true;
            this.chk_Local.Location = new System.Drawing.Point(489, -1);
            this.chk_Local.Name = "chk_Local";
            this.chk_Local.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chk_Local.Size = new System.Drawing.Size(94, 21);
            this.chk_Local.TabIndex = 2;
            this.chk_Local.Text = "chk_Local";
            this.chk_Local.UseVisualStyleBackColor = true;
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(600, -1);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(38, 24);
            this.btnEdit.TabIndex = 3;
            this.btnEdit.UseVisualStyleBackColor = true;
            // 
            // usrc_web_Help
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.GreenYellow;
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.chk_Local);
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
        private System.Windows.Forms.CheckBox chk_Local;
        private System.Windows.Forms.Button btnEdit;
    }
}
