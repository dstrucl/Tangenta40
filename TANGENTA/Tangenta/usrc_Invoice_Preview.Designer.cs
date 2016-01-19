namespace Tangenta
{
    partial class usrc_Invoice_Preview
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
            this.pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
            this.m_webBrowser = new System.Windows.Forms.WebBrowser();
            this.btn_Print = new System.Windows.Forms.Button();
            this.btn_SaveAs = new System.Windows.Forms.Button();
            this.btn_Tokens = new System.Windows.Forms.Button();
            this.btn_OK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // m_webBrowser
            // 
            this.m_webBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_webBrowser.Location = new System.Drawing.Point(3, 48);
            this.m_webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.m_webBrowser.Name = "m_webBrowser";
            this.m_webBrowser.Size = new System.Drawing.Size(488, 600);
            this.m_webBrowser.TabIndex = 2;
            // 
            // btn_Print
            // 
            this.btn_Print.Image = global::Tangenta.Properties.Resources.Print;
            this.btn_Print.Location = new System.Drawing.Point(89, 3);
            this.btn_Print.Name = "btn_Print";
            this.btn_Print.Size = new System.Drawing.Size(69, 39);
            this.btn_Print.TabIndex = 3;
            this.btn_Print.UseVisualStyleBackColor = true;
            this.btn_Print.Click += new System.EventHandler(this.btn_Print_Click);
            // 
            // btn_SaveAs
            // 
            this.btn_SaveAs.Image = global::Tangenta.Properties.Resources.SaveHtml;
            this.btn_SaveAs.Location = new System.Drawing.Point(3, 3);
            this.btn_SaveAs.Name = "btn_SaveAs";
            this.btn_SaveAs.Size = new System.Drawing.Size(69, 39);
            this.btn_SaveAs.TabIndex = 4;
            this.btn_SaveAs.UseVisualStyleBackColor = true;
            this.btn_SaveAs.Click += new System.EventHandler(this.btn_SaveAs_Click);
            // 
            // btn_Tokens
            // 
            this.btn_Tokens.Location = new System.Drawing.Point(164, 10);
            this.btn_Tokens.Name = "btn_Tokens";
            this.btn_Tokens.Size = new System.Drawing.Size(258, 25);
            this.btn_Tokens.TabIndex = 5;
            this.btn_Tokens.Text = "button1";
            this.btn_Tokens.UseVisualStyleBackColor = true;
            this.btn_Tokens.Click += new System.EventHandler(this.btn_Tokens_Click);
            // 
            // btn_OK
            // 
            this.btn_OK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_OK.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_OK.Location = new System.Drawing.Point(434, 3);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(55, 39);
            this.btn_OK.TabIndex = 6;
            this.btn_OK.Text = "OK";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // usrc_Invoice_Preview
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoScroll = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.btn_Tokens);
            this.Controls.Add(this.btn_SaveAs);
            this.Controls.Add(this.btn_Print);
            this.Controls.Add(this.m_webBrowser);
            this.Name = "usrc_Invoice_Preview";
            this.Size = new System.Drawing.Size(494, 651);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PageSetupDialog pageSetupDialog1;
        private System.Windows.Forms.WebBrowser m_webBrowser;
        private System.Windows.Forms.Button btn_Print;
        private System.Windows.Forms.Button btn_SaveAs;
        private System.Windows.Forms.Button btn_Tokens;
        private System.Windows.Forms.Button btn_OK;
    }
}
