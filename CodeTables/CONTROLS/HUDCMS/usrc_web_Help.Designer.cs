﻿namespace HUDCMS
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
            this.chk_local = new System.Windows.Forms.CheckBox();
            this.btn_HUDCMS = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // webBrowser1
            // 
            this.webBrowser1.AllowWebBrowserDrop = false;
            this.webBrowser1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowser1.IsWebBrowserContextMenuEnabled = false;
            this.webBrowser1.Location = new System.Drawing.Point(2, 27);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.ScriptErrorsSuppressed = true;
            this.webBrowser1.Size = new System.Drawing.Size(683, 517);
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
            // chk_local
            // 
            this.chk_local.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chk_local.AutoSize = true;
            this.chk_local.Location = new System.Drawing.Point(527, 3);
            this.chk_local.Name = "chk_local";
            this.chk_local.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chk_local.Size = new System.Drawing.Size(98, 21);
            this.chk_local.TabIndex = 2;
            this.chk_local.Text = "checkBox1";
            this.chk_local.UseVisualStyleBackColor = true;
            this.chk_local.CheckedChanged += new System.EventHandler(this.chk_local_CheckedChanged);
            // 
            // btn_HUDCMS
            // 
            this.btn_HUDCMS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_HUDCMS.Image = global::HUDCMS.Properties.Resources.Edit;
            this.btn_HUDCMS.Location = new System.Drawing.Point(632, 1);
            this.btn_HUDCMS.Name = "btn_HUDCMS";
            this.btn_HUDCMS.Size = new System.Drawing.Size(34, 23);
            this.btn_HUDCMS.TabIndex = 3;
            this.btn_HUDCMS.UseVisualStyleBackColor = true;
            this.btn_HUDCMS.Click += new System.EventHandler(this.btn_HUDCMS_Click);
            // 
            // usrc_web_Help
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.GreenYellow;
            this.Controls.Add(this.btn_HUDCMS);
            this.Controls.Add(this.chk_local);
            this.Controls.Add(this.lbl_URL);
            this.Controls.Add(this.webBrowser1);
            this.Name = "usrc_web_Help";
            this.Size = new System.Drawing.Size(686, 545);
            this.Load += new System.EventHandler(this.usrc_web_Help_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.WebBrowser webBrowser1;
        public System.Windows.Forms.Label lbl_URL;
        private System.Windows.Forms.CheckBox chk_local;
        private System.Windows.Forms.Button btn_HUDCMS;
    }
}
