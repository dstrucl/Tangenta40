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
            this.chk_FVI_CARD_PAYMENT = new System.Windows.Forms.CheckBox();
            this.chk_FVI_PAYMENT_ON_BANK_ACCOUNT = new System.Windows.Forms.CheckBox();
            this.chk_FVI_CASH_PAYMENT = new System.Windows.Forms.CheckBox();
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
            // chk_FVI_CARD_PAYMENT
            // 
            this.chk_FVI_CARD_PAYMENT.AutoSize = true;
            this.chk_FVI_CARD_PAYMENT.Location = new System.Drawing.Point(15, 86);
            this.chk_FVI_CARD_PAYMENT.Name = "chk_FVI_CARD_PAYMENT";
            this.chk_FVI_CARD_PAYMENT.Size = new System.Drawing.Size(186, 17);
            this.chk_FVI_CARD_PAYMENT.TabIndex = 6;
            this.chk_FVI_CARD_PAYMENT.Text = "Fiscal verification of card payment";
            this.chk_FVI_CARD_PAYMENT.UseVisualStyleBackColor = true;
            this.chk_FVI_CARD_PAYMENT.CheckedChanged += new System.EventHandler(this.chk_FVI_CARD_PAYMENT_CheckedChanged);
            // 
            // chk_FVI_PAYMENT_ON_BANK_ACCOUNT
            // 
            this.chk_FVI_PAYMENT_ON_BANK_ACCOUNT.AutoSize = true;
            this.chk_FVI_PAYMENT_ON_BANK_ACCOUNT.Location = new System.Drawing.Point(15, 109);
            this.chk_FVI_PAYMENT_ON_BANK_ACCOUNT.Name = "chk_FVI_PAYMENT_ON_BANK_ACCOUNT";
            this.chk_FVI_PAYMENT_ON_BANK_ACCOUNT.Size = new System.Drawing.Size(248, 17);
            this.chk_FVI_PAYMENT_ON_BANK_ACCOUNT.TabIndex = 7;
            this.chk_FVI_PAYMENT_ON_BANK_ACCOUNT.Text = "Fiscal verification of payment on Bank Account";
            this.chk_FVI_PAYMENT_ON_BANK_ACCOUNT.UseVisualStyleBackColor = true;
            this.chk_FVI_PAYMENT_ON_BANK_ACCOUNT.CheckedChanged += new System.EventHandler(this.chk_FVI_PAYMENT_ON_BANK_ACCOUNT_CheckedChanged);
            // 
            // chk_FVI_CASH_PAYMENT
            // 
            this.chk_FVI_CASH_PAYMENT.AutoSize = true;
            this.chk_FVI_CASH_PAYMENT.Location = new System.Drawing.Point(15, 63);
            this.chk_FVI_CASH_PAYMENT.Name = "chk_FVI_CASH_PAYMENT";
            this.chk_FVI_CASH_PAYMENT.Size = new System.Drawing.Size(188, 17);
            this.chk_FVI_CASH_PAYMENT.TabIndex = 8;
            this.chk_FVI_CASH_PAYMENT.Text = "Fiscal verification of cash payment";
            this.chk_FVI_CASH_PAYMENT.UseVisualStyleBackColor = true;
            this.chk_FVI_CASH_PAYMENT.CheckedChanged += new System.EventHandler(this.chk_FVI_CASH_PAYMENT_CheckedChanged);
            // 
            // Form_MainFiscal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(689, 137);
            this.Controls.Add(this.chk_FVI_CASH_PAYMENT);
            this.Controls.Add(this.chk_FVI_PAYMENT_ON_BANK_ACCOUNT);
            this.Controls.Add(this.chk_FVI_CARD_PAYMENT);
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
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_Settings;
        private System.Windows.Forms.Button btn_Send_ECHO;
        private System.Windows.Forms.Button btn_CheckInvoice;
        private System.Windows.Forms.CheckBox chk_FVI_CARD_PAYMENT;
        private System.Windows.Forms.CheckBox chk_FVI_PAYMENT_ON_BANK_ACCOUNT;
        private System.Windows.Forms.CheckBox chk_FVI_CASH_PAYMENT;
    }
}