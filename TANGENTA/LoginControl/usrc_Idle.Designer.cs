namespace LoginControl
{
    partial class usrc_Idle
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
            this.btn_WebBrowserGoHome = new System.Windows.Forms.Button();
            this.btn_WebBrowserGoForward = new System.Windows.Forms.Button();
            this.btn_WebBrowserGoBack = new System.Windows.Forms.Button();
            this.txt_URL = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_WebBrowserGoHome
            // 
            this.btn_WebBrowserGoHome.Location = new System.Drawing.Point(45, 1);
            this.btn_WebBrowserGoHome.Name = "btn_WebBrowserGoHome";
            this.btn_WebBrowserGoHome.Size = new System.Drawing.Size(43, 38);
            this.btn_WebBrowserGoHome.TabIndex = 10;
            this.btn_WebBrowserGoHome.Text = "..";
            this.btn_WebBrowserGoHome.UseVisualStyleBackColor = true;
            // 
            // btn_WebBrowserGoForward
            // 
            this.btn_WebBrowserGoForward.Location = new System.Drawing.Point(88, 1);
            this.btn_WebBrowserGoForward.Name = "btn_WebBrowserGoForward";
            this.btn_WebBrowserGoForward.Size = new System.Drawing.Size(43, 38);
            this.btn_WebBrowserGoForward.TabIndex = 9;
            this.btn_WebBrowserGoForward.Text = "-->";
            this.btn_WebBrowserGoForward.UseVisualStyleBackColor = true;
            // 
            // btn_WebBrowserGoBack
            // 
            this.btn_WebBrowserGoBack.Location = new System.Drawing.Point(2, 1);
            this.btn_WebBrowserGoBack.Name = "btn_WebBrowserGoBack";
            this.btn_WebBrowserGoBack.Size = new System.Drawing.Size(43, 38);
            this.btn_WebBrowserGoBack.TabIndex = 8;
            this.btn_WebBrowserGoBack.Text = "<--";
            this.btn_WebBrowserGoBack.UseVisualStyleBackColor = true;
            // 
            // txt_URL
            // 
            this.txt_URL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_URL.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_URL.ForeColor = System.Drawing.Color.Silver;
            this.txt_URL.Location = new System.Drawing.Point(134, 4);
            this.txt_URL.Multiline = true;
            this.txt_URL.Name = "txt_URL";
            this.txt_URL.ReadOnly = true;
            this.txt_URL.Size = new System.Drawing.Size(195, 34);
            this.txt_URL.TabIndex = 7;
            this.txt_URL.Text = "label1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(335, 1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(79, 38);
            this.button1.TabIndex = 11;
            this.button1.Text = "-->";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(420, 1);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(74, 38);
            this.button2.TabIndex = 12;
            this.button2.Text = "-->";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(552, 1);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(133, 38);
            this.button3.TabIndex = 13;
            this.button3.Text = "-->";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // usrc_Idle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_WebBrowserGoHome);
            this.Controls.Add(this.btn_WebBrowserGoForward);
            this.Controls.Add(this.btn_WebBrowserGoBack);
            this.Controls.Add(this.txt_URL);
            this.Name = "usrc_Idle";
            this.Size = new System.Drawing.Size(688, 523);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_WebBrowserGoHome;
        private System.Windows.Forms.Button btn_WebBrowserGoForward;
        private System.Windows.Forms.Button btn_WebBrowserGoBack;
        public System.Windows.Forms.TextBox txt_URL;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}
