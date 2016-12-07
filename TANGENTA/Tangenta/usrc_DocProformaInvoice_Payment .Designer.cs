namespace Tangenta
{
    partial class usrc_DocProformaInvoice_Payment
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
            this.rdb_Payment_by_cash_or_credit_card_on_delivery = new System.Windows.Forms.RadioButton();
            this.btn_Print = new System.Windows.Forms.Button();
            this.rdb_BankAccountTransfer = new System.Windows.Forms.RadioButton();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.grp_MtehodOfPaymentType = new System.Windows.Forms.GroupBox();
            this.grp_ValidityOfTheTender = new System.Windows.Forms.GroupBox();
            this.nmUpDn_NumberOfDaysOrMonths = new System.Windows.Forms.NumericUpDown();
            this.rbtn_NumberOf = new System.Windows.Forms.RadioButton();
            this.rdb_Valid_Tender_Until = new System.Windows.Forms.RadioButton();
            this.dtP_TenderValidUntil = new System.Windows.Forms.DateTimePicker();
            this.grp_TermsOfPayment = new System.Windows.Forms.GroupBox();
            this.txt_PaymantConditionsDescription = new System.Windows.Forms.TextBox();
            this.btn_Select_Terms_of_Payment = new System.Windows.Forms.Button();
            this.cmb_DaysOrMonths = new ComboBox_Recent.ComboBox_RecentList();
            this.grp_MtehodOfPaymentType.SuspendLayout();
            this.grp_ValidityOfTheTender.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmUpDn_NumberOfDaysOrMonths)).BeginInit();
            this.grp_TermsOfPayment.SuspendLayout();
            this.SuspendLayout();
            // 
            // rdb_Payment_by_cash_or_credit_card_on_delivery
            // 
            this.rdb_Payment_by_cash_or_credit_card_on_delivery.AutoSize = true;
            this.rdb_Payment_by_cash_or_credit_card_on_delivery.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rdb_Payment_by_cash_or_credit_card_on_delivery.ForeColor = System.Drawing.Color.Black;
            this.rdb_Payment_by_cash_or_credit_card_on_delivery.Location = new System.Drawing.Point(20, 70);
            this.rdb_Payment_by_cash_or_credit_card_on_delivery.Name = "rdb_Payment_by_cash_or_credit_card_on_delivery";
            this.rdb_Payment_by_cash_or_credit_card_on_delivery.Size = new System.Drawing.Size(321, 24);
            this.rdb_Payment_by_cash_or_credit_card_on_delivery.TabIndex = 0;
            this.rdb_Payment_by_cash_or_credit_card_on_delivery.Text = "Payment by cash or credit card on delivery";
            this.rdb_Payment_by_cash_or_credit_card_on_delivery.UseVisualStyleBackColor = true;
            // 
            // btn_Print
            // 
            this.btn_Print.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_Print.ForeColor = System.Drawing.Color.Black;
            this.btn_Print.Location = new System.Drawing.Point(168, 440);
            this.btn_Print.Name = "btn_Print";
            this.btn_Print.Size = new System.Drawing.Size(197, 55);
            this.btn_Print.TabIndex = 7;
            this.btn_Print.Text = "Print";
            this.btn_Print.UseVisualStyleBackColor = true;
            this.btn_Print.Click += new System.EventHandler(this.btn_Print_Click);
            // 
            // rdb_BankAccountTransfer
            // 
            this.rdb_BankAccountTransfer.AutoSize = true;
            this.rdb_BankAccountTransfer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rdb_BankAccountTransfer.ForeColor = System.Drawing.Color.Black;
            this.rdb_BankAccountTransfer.Location = new System.Drawing.Point(20, 31);
            this.rdb_BankAccountTransfer.Name = "rdb_BankAccountTransfer";
            this.rdb_BankAccountTransfer.Size = new System.Drawing.Size(211, 24);
            this.rdb_BankAccountTransfer.TabIndex = 10;
            this.rdb_BankAccountTransfer.Text = "Payment on bank account";
            this.rdb_BankAccountTransfer.UseVisualStyleBackColor = true;
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_Cancel.ForeColor = System.Drawing.Color.Black;
            this.btn_Cancel.Image = global::Tangenta.Properties.Resources.Exit;
            this.btn_Cancel.Location = new System.Drawing.Point(454, 441);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(115, 52);
            this.btn_Cancel.TabIndex = 12;
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // grp_MtehodOfPaymentType
            // 
            this.grp_MtehodOfPaymentType.Controls.Add(this.rdb_BankAccountTransfer);
            this.grp_MtehodOfPaymentType.Controls.Add(this.rdb_Payment_by_cash_or_credit_card_on_delivery);
            this.grp_MtehodOfPaymentType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.grp_MtehodOfPaymentType.Location = new System.Drawing.Point(3, 3);
            this.grp_MtehodOfPaymentType.Name = "grp_MtehodOfPaymentType";
            this.grp_MtehodOfPaymentType.Size = new System.Drawing.Size(569, 125);
            this.grp_MtehodOfPaymentType.TabIndex = 13;
            this.grp_MtehodOfPaymentType.TabStop = false;
            this.grp_MtehodOfPaymentType.Text = "Method of Payment";
            // 
            // grp_ValidityOfTheTender
            // 
            this.grp_ValidityOfTheTender.Controls.Add(this.cmb_DaysOrMonths);
            this.grp_ValidityOfTheTender.Controls.Add(this.dtP_TenderValidUntil);
            this.grp_ValidityOfTheTender.Controls.Add(this.rdb_Valid_Tender_Until);
            this.grp_ValidityOfTheTender.Controls.Add(this.rbtn_NumberOf);
            this.grp_ValidityOfTheTender.Controls.Add(this.nmUpDn_NumberOfDaysOrMonths);
            this.grp_ValidityOfTheTender.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.grp_ValidityOfTheTender.Location = new System.Drawing.Point(6, 310);
            this.grp_ValidityOfTheTender.Name = "grp_ValidityOfTheTender";
            this.grp_ValidityOfTheTender.Size = new System.Drawing.Size(563, 124);
            this.grp_ValidityOfTheTender.TabIndex = 14;
            this.grp_ValidityOfTheTender.TabStop = false;
            this.grp_ValidityOfTheTender.Text = "Validity of the tender";
            // 
            // nmUpDn_NumberOfDaysOrMonths
            // 
            this.nmUpDn_NumberOfDaysOrMonths.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.nmUpDn_NumberOfDaysOrMonths.Location = new System.Drawing.Point(354, 35);
            this.nmUpDn_NumberOfDaysOrMonths.Name = "nmUpDn_NumberOfDaysOrMonths";
            this.nmUpDn_NumberOfDaysOrMonths.Size = new System.Drawing.Size(184, 26);
            this.nmUpDn_NumberOfDaysOrMonths.TabIndex = 1;
            // 
            // rbtn_NumberOf
            // 
            this.rbtn_NumberOf.AutoSize = true;
            this.rbtn_NumberOf.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rbtn_NumberOf.ForeColor = System.Drawing.Color.Black;
            this.rbtn_NumberOf.Location = new System.Drawing.Point(21, 35);
            this.rbtn_NumberOf.Name = "rbtn_NumberOf";
            this.rbtn_NumberOf.Size = new System.Drawing.Size(101, 24);
            this.rbtn_NumberOf.TabIndex = 2;
            this.rbtn_NumberOf.TabStop = true;
            this.rbtn_NumberOf.Text = "Number of";
            this.rbtn_NumberOf.UseVisualStyleBackColor = true;
            // 
            // rdb_Valid_Tender_Until
            // 
            this.rdb_Valid_Tender_Until.AutoSize = true;
            this.rdb_Valid_Tender_Until.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rdb_Valid_Tender_Until.ForeColor = System.Drawing.Color.Black;
            this.rdb_Valid_Tender_Until.Location = new System.Drawing.Point(21, 83);
            this.rdb_Valid_Tender_Until.Name = "rdb_Valid_Tender_Until";
            this.rdb_Valid_Tender_Until.Size = new System.Drawing.Size(95, 24);
            this.rdb_Valid_Tender_Until.TabIndex = 3;
            this.rdb_Valid_Tender_Until.TabStop = true;
            this.rdb_Valid_Tender_Until.Text = "Valid until";
            this.rdb_Valid_Tender_Until.UseVisualStyleBackColor = true;
            // 
            // dtP_TenderValidUntil
            // 
            this.dtP_TenderValidUntil.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.dtP_TenderValidUntil.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.dtP_TenderValidUntil.Location = new System.Drawing.Point(128, 83);
            this.dtP_TenderValidUntil.Name = "dtP_TenderValidUntil";
            this.dtP_TenderValidUntil.Size = new System.Drawing.Size(253, 26);
            this.dtP_TenderValidUntil.TabIndex = 4;
            // 
            // grp_TermsOfPayment
            // 
            this.grp_TermsOfPayment.Controls.Add(this.btn_Select_Terms_of_Payment);
            this.grp_TermsOfPayment.Controls.Add(this.txt_PaymantConditionsDescription);
            this.grp_TermsOfPayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.grp_TermsOfPayment.Location = new System.Drawing.Point(6, 132);
            this.grp_TermsOfPayment.Name = "grp_TermsOfPayment";
            this.grp_TermsOfPayment.Size = new System.Drawing.Size(563, 170);
            this.grp_TermsOfPayment.TabIndex = 15;
            this.grp_TermsOfPayment.TabStop = false;
            this.grp_TermsOfPayment.Text = "Terms of Payment";
            // 
            // txt_PaymantConditionsDescription
            // 
            this.txt_PaymantConditionsDescription.Location = new System.Drawing.Point(17, 45);
            this.txt_PaymantConditionsDescription.Multiline = true;
            this.txt_PaymantConditionsDescription.Name = "txt_PaymantConditionsDescription";
            this.txt_PaymantConditionsDescription.Size = new System.Drawing.Size(536, 100);
            this.txt_PaymantConditionsDescription.TabIndex = 13;
            // 
            // btn_Select_Terms_of_Payment
            // 
            this.btn_Select_Terms_of_Payment.ForeColor = System.Drawing.Color.Black;
            this.btn_Select_Terms_of_Payment.Location = new System.Drawing.Point(162, 15);
            this.btn_Select_Terms_of_Payment.Name = "btn_Select_Terms_of_Payment";
            this.btn_Select_Terms_of_Payment.Size = new System.Drawing.Size(229, 26);
            this.btn_Select_Terms_of_Payment.TabIndex = 14;
            this.btn_Select_Terms_of_Payment.Text = "Select Terms Of Payment";
            this.btn_Select_Terms_of_Payment.UseVisualStyleBackColor = true;
            // 
            // cmb_DaysOrMonths
            // 
            this.cmb_DaysOrMonths.DisplayMember = "text";
            this.cmb_DaysOrMonths.DisplayTime = true;
            this.cmb_DaysOrMonths.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmb_DaysOrMonths.FormattingEnabled = true;
            this.cmb_DaysOrMonths.InsertOnKeyPress = true;
            this.cmb_DaysOrMonths.Key = null;
            this.cmb_DaysOrMonths.Location = new System.Drawing.Point(147, 34);
            this.cmb_DaysOrMonths.MaxRecentCount = 10;
            this.cmb_DaysOrMonths.Name = "cmb_DaysOrMonths";
            this.cmb_DaysOrMonths.ReadOnly = false;
            this.cmb_DaysOrMonths.RecentItemsFileName = null;
            this.cmb_DaysOrMonths.RecentItemsFolder = "";
            this.cmb_DaysOrMonths.Size = new System.Drawing.Size(166, 27);
            this.cmb_DaysOrMonths.TabIndex = 5;
            // 
            // usrc_DocProformaInvoice_Payment
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.grp_TermsOfPayment);
            this.Controls.Add(this.grp_ValidityOfTheTender);
            this.Controls.Add(this.grp_MtehodOfPaymentType);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_Print);
            this.ForeColor = System.Drawing.Color.Red;
            this.Name = "usrc_DocProformaInvoice_Payment";
            this.Size = new System.Drawing.Size(581, 500);
            this.grp_MtehodOfPaymentType.ResumeLayout(false);
            this.grp_MtehodOfPaymentType.PerformLayout();
            this.grp_ValidityOfTheTender.ResumeLayout(false);
            this.grp_ValidityOfTheTender.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmUpDn_NumberOfDaysOrMonths)).EndInit();
            this.grp_TermsOfPayment.ResumeLayout(false);
            this.grp_TermsOfPayment.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton rdb_Payment_by_cash_or_credit_card_on_delivery;
        private System.Windows.Forms.Button btn_Print;
        private System.Windows.Forms.RadioButton rdb_BankAccountTransfer;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.GroupBox grp_MtehodOfPaymentType;
        private System.Windows.Forms.GroupBox grp_ValidityOfTheTender;
        private System.Windows.Forms.RadioButton rbtn_NumberOf;
        private System.Windows.Forms.NumericUpDown nmUpDn_NumberOfDaysOrMonths;
        private System.Windows.Forms.DateTimePicker dtP_TenderValidUntil;
        private System.Windows.Forms.RadioButton rdb_Valid_Tender_Until;
        private System.Windows.Forms.GroupBox grp_TermsOfPayment;
        private System.Windows.Forms.TextBox txt_PaymantConditionsDescription;
        private System.Windows.Forms.Button btn_Select_Terms_of_Payment;
        private ComboBox_Recent.ComboBox_RecentList cmb_DaysOrMonths;
    }
}
