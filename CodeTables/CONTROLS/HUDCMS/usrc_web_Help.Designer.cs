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
            this.components = new System.ComponentModel.Container();
            this.txt_URL = new System.Windows.Forms.TextBox();
            this.chk_local = new System.Windows.Forms.CheckBox();
            this.btn_HUDCMS = new System.Windows.Forms.Button();
            this.btn_WebBrowserGoBack = new System.Windows.Forms.Button();
            this.btn_WebBrowserGoForward = new System.Windows.Forms.Button();
            this.btn_WebBrowserGoHome = new System.Windows.Forms.Button();
            this.txt_Saved = new System.Windows.Forms.TextBox();
            this.timer_LastSave = new System.Windows.Forms.Timer(this.components);
            this.cmb_Language = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // txt_URL
            // 
            this.txt_URL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_URL.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_URL.ForeColor = System.Drawing.Color.Silver;
            this.txt_URL.Location = new System.Drawing.Point(101, 6);
            this.txt_URL.Name = "txt_URL";
            this.txt_URL.ReadOnly = true;
            this.txt_URL.Size = new System.Drawing.Size(327, 13);
            this.txt_URL.TabIndex = 1;
            this.txt_URL.Text = "label1";
            this.txt_URL.DoubleClick += new System.EventHandler(this.txt_URL_DoubleClick);
            // 
            // chk_local
            // 
            this.chk_local.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chk_local.ForeColor = System.Drawing.Color.Gray;
            this.chk_local.Location = new System.Drawing.Point(591, 5);
            this.chk_local.Name = "chk_local";
            this.chk_local.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chk_local.Size = new System.Drawing.Size(146, 17);
            this.chk_local.TabIndex = 2;
            this.chk_local.Text = "checkBox1";
            this.chk_local.UseVisualStyleBackColor = true;
            this.chk_local.CheckedChanged += new System.EventHandler(this.chk_local_CheckedChanged);
            // 
            // btn_HUDCMS
            // 
            this.btn_HUDCMS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_HUDCMS.Image = global::HUDCMS.Properties.Resources.Edit;
            this.btn_HUDCMS.Location = new System.Drawing.Point(739, 1);
            this.btn_HUDCMS.Name = "btn_HUDCMS";
            this.btn_HUDCMS.Size = new System.Drawing.Size(34, 23);
            this.btn_HUDCMS.TabIndex = 3;
            this.btn_HUDCMS.UseVisualStyleBackColor = true;
            this.btn_HUDCMS.Click += new System.EventHandler(this.btn_HUDCMS_Click);
            // 
            // btn_WebBrowserGoBack
            // 
            this.btn_WebBrowserGoBack.Location = new System.Drawing.Point(-1, -1);
            this.btn_WebBrowserGoBack.Name = "btn_WebBrowserGoBack";
            this.btn_WebBrowserGoBack.Size = new System.Drawing.Size(36, 24);
            this.btn_WebBrowserGoBack.TabIndex = 4;
            this.btn_WebBrowserGoBack.Text = "<--";
            this.btn_WebBrowserGoBack.UseVisualStyleBackColor = true;
            this.btn_WebBrowserGoBack.Click += new System.EventHandler(this.btn_WebBrowserGoBack_Click);
            // 
            // btn_WebBrowserGoForward
            // 
            this.btn_WebBrowserGoForward.Location = new System.Drawing.Point(66, -1);
            this.btn_WebBrowserGoForward.Name = "btn_WebBrowserGoForward";
            this.btn_WebBrowserGoForward.Size = new System.Drawing.Size(29, 24);
            this.btn_WebBrowserGoForward.TabIndex = 5;
            this.btn_WebBrowserGoForward.Text = "-->";
            this.btn_WebBrowserGoForward.UseVisualStyleBackColor = true;
            this.btn_WebBrowserGoForward.Click += new System.EventHandler(this.btn_WebBrowserGoForward_Click);
            // 
            // btn_WebBrowserGoHome
            // 
            this.btn_WebBrowserGoHome.Location = new System.Drawing.Point(36, -1);
            this.btn_WebBrowserGoHome.Name = "btn_WebBrowserGoHome";
            this.btn_WebBrowserGoHome.Size = new System.Drawing.Size(29, 24);
            this.btn_WebBrowserGoHome.TabIndex = 6;
            this.btn_WebBrowserGoHome.Text = "..";
            this.btn_WebBrowserGoHome.UseVisualStyleBackColor = true;
            this.btn_WebBrowserGoHome.Click += new System.EventHandler(this.btn_WebBrowserGoHome_Click);
            // 
            // txt_Saved
            // 
            this.txt_Saved.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Saved.BackColor = System.Drawing.Color.GreenYellow;
            this.txt_Saved.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_Saved.Location = new System.Drawing.Point(501, 6);
            this.txt_Saved.Name = "txt_Saved";
            this.txt_Saved.ReadOnly = true;
            this.txt_Saved.Size = new System.Drawing.Size(92, 13);
            this.txt_Saved.TabIndex = 7;
            this.txt_Saved.Text = "Saved 10:00";
            // 
            // timer_LastSave
            // 
            this.timer_LastSave.Tick += new System.EventHandler(this.timer_LastSave_Tick);
            // 
            // cmb_Language
            // 
            this.cmb_Language.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmb_Language.FormattingEnabled = true;
            this.cmb_Language.Location = new System.Drawing.Point(434, 3);
            this.cmb_Language.Name = "cmb_Language";
            this.cmb_Language.Size = new System.Drawing.Size(61, 21);
            this.cmb_Language.TabIndex = 8;
            this.cmb_Language.Text = "slo";
            // 
            // usrc_web_Help
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.GreenYellow;
            this.Controls.Add(this.cmb_Language);
            this.Controls.Add(this.txt_Saved);
            this.Controls.Add(this.btn_WebBrowserGoHome);
            this.Controls.Add(this.btn_WebBrowserGoForward);
            this.Controls.Add(this.btn_WebBrowserGoBack);
            this.Controls.Add(this.btn_HUDCMS);
            this.Controls.Add(this.chk_local);
            this.Controls.Add(this.txt_URL);
            this.Name = "usrc_web_Help";
            this.Size = new System.Drawing.Size(775, 545);
            this.Load += new System.EventHandler(this.usrc_web_Help_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox txt_URL;
        private System.Windows.Forms.CheckBox chk_local;
        private System.Windows.Forms.Button btn_HUDCMS;
        private System.Windows.Forms.Button btn_WebBrowserGoBack;
        private System.Windows.Forms.Button btn_WebBrowserGoForward;
        private System.Windows.Forms.Button btn_WebBrowserGoHome;
        private System.Windows.Forms.TextBox txt_Saved;
        private System.Windows.Forms.Timer timer_LastSave;
        private System.Windows.Forms.ComboBox cmb_Language;
    }
}
