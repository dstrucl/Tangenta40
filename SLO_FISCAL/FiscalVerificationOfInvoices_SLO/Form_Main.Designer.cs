namespace FiscalVerificationOfInvoices_SLO
{
    partial class Form_MainFiscal
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_MainFiscal));
            this.btn_Settings = new System.Windows.Forms.Button();
            this.btn_Send_ECHO = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Settings
            // 
            this.btn_Settings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Settings.Image = global::FiscalVerificationOfInvoices_SLO.Properties.Resources.FURS_Settings;
            this.btn_Settings.Location = new System.Drawing.Point(816, 6);
            this.btn_Settings.Name = "btn_Settings";
            this.btn_Settings.Size = new System.Drawing.Size(102, 38);
            this.btn_Settings.TabIndex = 3;
            this.btn_Settings.UseVisualStyleBackColor = true;
            this.btn_Settings.Click += new System.EventHandler(this.btn_Settings_Click);
            // 
            // btn_Send_ECHO
            // 
            this.btn_Send_ECHO.Location = new System.Drawing.Point(15, 6);
            this.btn_Send_ECHO.Name = "btn_Send_ECHO";
            this.btn_Send_ECHO.Size = new System.Drawing.Size(83, 38);
            this.btn_Send_ECHO.TabIndex = 4;
            this.btn_Send_ECHO.Text = "Pošlji ECHO";
            this.btn_Send_ECHO.UseVisualStyleBackColor = true;
            this.btn_Send_ECHO.Click += new System.EventHandler(this.btn_Send_ECHO_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.splitContainer1.Location = new System.Drawing.Point(4, 56);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Panel2Collapsed = true;
            this.splitContainer1.Size = new System.Drawing.Size(914, 670);
            this.splitContainer1.SplitterDistance = 229;
            this.splitContainer1.TabIndex = 6;
            // 
            // Form_MainFiscal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(922, 728);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.btn_Send_ECHO);
            this.Controls.Add(this.btn_Settings);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_MainFiscal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form_Main";
            this.Load += new System.EventHandler(this.Form_Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btn_Settings;
        private System.Windows.Forms.Button btn_Send_ECHO;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}