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
            this.btn_CheckInvoice = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_Settings
            // 
            this.btn_Settings.Image = global::FiscalVerificationOfInvoices_SLO.Properties.Resources.FURS_Settings;
            this.btn_Settings.Location = new System.Drawing.Point(104, 6);
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
            // btn_CheckInvoice
            // 
            this.btn_CheckInvoice.Location = new System.Drawing.Point(212, 6);
            this.btn_CheckInvoice.Name = "btn_CheckInvoice";
            this.btn_CheckInvoice.Size = new System.Drawing.Size(467, 38);
            this.btn_CheckInvoice.TabIndex = 5;
            this.btn_CheckInvoice.Text = "CheckInvoice";
            this.btn_CheckInvoice.UseVisualStyleBackColor = true;
            this.btn_CheckInvoice.Click += new System.EventHandler(this.btn_CheckInvoice_Click);
            // 
            // Form_MainFiscal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(689, 54);
            this.Controls.Add(this.btn_CheckInvoice);
            this.Controls.Add(this.btn_Send_ECHO);
            this.Controls.Add(this.btn_Settings);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_MainFiscal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form_Main";
            this.Load += new System.EventHandler(this.Form_Main_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btn_Settings;
        private System.Windows.Forms.Button btn_Send_ECHO;
        private System.Windows.Forms.Button btn_CheckInvoice;
    }
}