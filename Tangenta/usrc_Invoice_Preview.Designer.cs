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
            this.btn_Print.Location = new System.Drawing.Point(3, 3);
            this.btn_Print.Name = "btn_Print";
            this.btn_Print.Size = new System.Drawing.Size(69, 39);
            this.btn_Print.TabIndex = 3;
            this.btn_Print.UseVisualStyleBackColor = true;
            this.btn_Print.Click += new System.EventHandler(this.btn_Print_Click);
            // 
            // usrc_Invoice_Preview
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoScroll = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
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
    }
}
