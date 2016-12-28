namespace TangentaPrint
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
            this.btn_Print = new System.Windows.Forms.Button();
            this.btn_SaveAs = new System.Windows.Forms.Button();
            this.btn_Tokens = new System.Windows.Forms.Button();
            this.btn_OK = new System.Windows.Forms.Button();
            this.htmlPanel1 = new TheArtOfDev.HtmlRenderer.WinForms.HtmlPanel();
            this.SuspendLayout();
            // 
            // btn_Print
            // 
            this.btn_Print.Image = global::TangentaPrint.Properties.Resources.Print;
            this.btn_Print.Location = new System.Drawing.Point(89, 3);
            this.btn_Print.Name = "btn_Print";
            this.btn_Print.Size = new System.Drawing.Size(69, 39);
            this.btn_Print.TabIndex = 3;
            this.btn_Print.UseVisualStyleBackColor = true;
            this.btn_Print.Click += new System.EventHandler(this.btn_Print_Click);
            // 
            // btn_SaveAs
            // 
            this.btn_SaveAs.Image = global::TangentaPrint.Properties.Resources.SaveHtml;
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
            // htmlPanel1
            // 
            this.htmlPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.htmlPanel1.AutoScroll = true;
            this.htmlPanel1.AutoScrollMinSize = new System.Drawing.Size(488, 20);
            this.htmlPanel1.BackColor = System.Drawing.SystemColors.Window;
            this.htmlPanel1.BaseStylesheet = null;
            this.htmlPanel1.Location = new System.Drawing.Point(3, 58);
            this.htmlPanel1.Name = "htmlPanel1";
            this.htmlPanel1.Size = new System.Drawing.Size(488, 593);
            this.htmlPanel1.TabIndex = 7;
            this.htmlPanel1.Text = "htmlPanel1";
            // 
            // usrc_Invoice_Preview
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoScroll = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.Controls.Add(this.htmlPanel1);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.btn_Tokens);
            this.Controls.Add(this.btn_SaveAs);
            this.Controls.Add(this.btn_Print);
            this.Name = "usrc_Invoice_Preview";
            this.Size = new System.Drawing.Size(494, 651);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PageSetupDialog pageSetupDialog1;
        private System.Windows.Forms.Button btn_Print;
        private System.Windows.Forms.Button btn_SaveAs;
        private System.Windows.Forms.Button btn_Tokens;
        private System.Windows.Forms.Button btn_OK;
        private TheArtOfDev.HtmlRenderer.WinForms.HtmlPanel htmlPanel1;
    }
}
