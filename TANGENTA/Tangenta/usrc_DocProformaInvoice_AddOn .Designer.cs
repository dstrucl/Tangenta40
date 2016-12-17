﻿namespace Tangenta
{
    partial class usrc_DocProformaInvoice_AddOn
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
            this.grp_MtehodOfPaymentType = new System.Windows.Forms.GroupBox();
            this.btn_Select_BankAccount = new System.Windows.Forms.Button();
            this.txt_BankAccount = new System.Windows.Forms.TextBox();
            this.grp_ValidityOfTheTender = new System.Windows.Forms.GroupBox();
            this.cmb_DaysOrMonths = new ComboBox_Recent.ComboBox_RecentList();
            this.dtP_TenderValidUntil = new System.Windows.Forms.DateTimePicker();
            this.rdb_Valid_Tender_Until = new System.Windows.Forms.RadioButton();
            this.rdb_ValidNumberOf = new System.Windows.Forms.RadioButton();
            this.nmUpDn_NumberOfDaysOrMonths = new System.Windows.Forms.NumericUpDown();
            this.grp_TermsOfPayment = new System.Windows.Forms.GroupBox();
            this.btn_Select_Terms_of_Payment = new System.Windows.Forms.Button();
            this.txt_PaymantConditionsDescription = new System.Windows.Forms.TextBox();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.dtP_DateOfIssue = new System.Windows.Forms.DateTimePicker();
            this.lbl_DateOfIssue = new System.Windows.Forms.Label();
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
            this.rdb_Payment_by_cash_or_credit_card_on_delivery.Location = new System.Drawing.Point(9, 64);
            this.rdb_Payment_by_cash_or_credit_card_on_delivery.Name = "rdb_Payment_by_cash_or_credit_card_on_delivery";
            this.rdb_Payment_by_cash_or_credit_card_on_delivery.Size = new System.Drawing.Size(321, 24);
            this.rdb_Payment_by_cash_or_credit_card_on_delivery.TabIndex = 0;
            this.rdb_Payment_by_cash_or_credit_card_on_delivery.Text = "Payment by cash or credit card on delivery";
            this.rdb_Payment_by_cash_or_credit_card_on_delivery.UseVisualStyleBackColor = true;
            this.rdb_Payment_by_cash_or_credit_card_on_delivery.CheckedChanged += new System.EventHandler(this.rdb_Payment_by_cash_or_credit_card_on_delivery_CheckedChanged);
            // 
            // btn_Print
            // 
            this.btn_Print.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_Print.ForeColor = System.Drawing.Color.Black;
            this.btn_Print.Location = new System.Drawing.Point(136, 428);
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
            this.rdb_BankAccountTransfer.Location = new System.Drawing.Point(9, 25);
            this.rdb_BankAccountTransfer.Name = "rdb_BankAccountTransfer";
            this.rdb_BankAccountTransfer.Size = new System.Drawing.Size(211, 24);
            this.rdb_BankAccountTransfer.TabIndex = 10;
            this.rdb_BankAccountTransfer.Text = "Payment on bank account";
            this.rdb_BankAccountTransfer.UseVisualStyleBackColor = true;
            this.rdb_BankAccountTransfer.CheckedChanged += new System.EventHandler(this.rdb_BankAccountTransfer_CheckedChanged_1);
            // 
            // grp_MtehodOfPaymentType
            // 
            this.grp_MtehodOfPaymentType.Controls.Add(this.btn_Select_BankAccount);
            this.grp_MtehodOfPaymentType.Controls.Add(this.txt_BankAccount);
            this.grp_MtehodOfPaymentType.Controls.Add(this.rdb_BankAccountTransfer);
            this.grp_MtehodOfPaymentType.Controls.Add(this.rdb_Payment_by_cash_or_credit_card_on_delivery);
            this.grp_MtehodOfPaymentType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.grp_MtehodOfPaymentType.Location = new System.Drawing.Point(3, 40);
            this.grp_MtehodOfPaymentType.Name = "grp_MtehodOfPaymentType";
            this.grp_MtehodOfPaymentType.Size = new System.Drawing.Size(569, 125);
            this.grp_MtehodOfPaymentType.TabIndex = 13;
            this.grp_MtehodOfPaymentType.TabStop = false;
            this.grp_MtehodOfPaymentType.Text = "Method of Payment";
            // 
            // btn_Select_BankAccount
            // 
            this.btn_Select_BankAccount.ForeColor = System.Drawing.Color.Black;
            this.btn_Select_BankAccount.Image = global::Tangenta.Properties.Resources.SelectRow;
            this.btn_Select_BankAccount.Location = new System.Drawing.Point(516, 25);
            this.btn_Select_BankAccount.Name = "btn_Select_BankAccount";
            this.btn_Select_BankAccount.Size = new System.Drawing.Size(40, 25);
            this.btn_Select_BankAccount.TabIndex = 12;
            this.btn_Select_BankAccount.UseVisualStyleBackColor = true;
            this.btn_Select_BankAccount.Click += new System.EventHandler(this.btn_Select_BankAccount_Click);
            // 
            // txt_BankAccount
            // 
            this.txt_BankAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_BankAccount.Location = new System.Drawing.Point(250, 25);
            this.txt_BankAccount.Name = "txt_BankAccount";
            this.txt_BankAccount.ReadOnly = true;
            this.txt_BankAccount.Size = new System.Drawing.Size(258, 22);
            this.txt_BankAccount.TabIndex = 11;
            // 
            // grp_ValidityOfTheTender
            // 
            this.grp_ValidityOfTheTender.Controls.Add(this.cmb_DaysOrMonths);
            this.grp_ValidityOfTheTender.Controls.Add(this.dtP_TenderValidUntil);
            this.grp_ValidityOfTheTender.Controls.Add(this.rdb_Valid_Tender_Until);
            this.grp_ValidityOfTheTender.Controls.Add(this.rdb_ValidNumberOf);
            this.grp_ValidityOfTheTender.Controls.Add(this.nmUpDn_NumberOfDaysOrMonths);
            this.grp_ValidityOfTheTender.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.grp_ValidityOfTheTender.Location = new System.Drawing.Point(12, 309);
            this.grp_ValidityOfTheTender.Name = "grp_ValidityOfTheTender";
            this.grp_ValidityOfTheTender.Size = new System.Drawing.Size(563, 113);
            this.grp_ValidityOfTheTender.TabIndex = 14;
            this.grp_ValidityOfTheTender.TabStop = false;
            this.grp_ValidityOfTheTender.Text = "Validity of the tender";
            // 
            // cmb_DaysOrMonths
            // 
            this.cmb_DaysOrMonths.DisplayMember = "text";
            this.cmb_DaysOrMonths.DisplayTime = true;
            this.cmb_DaysOrMonths.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmb_DaysOrMonths.FormattingEnabled = true;
            this.cmb_DaysOrMonths.InsertOnKeyPress = true;
            this.cmb_DaysOrMonths.Key = null;
            this.cmb_DaysOrMonths.Location = new System.Drawing.Point(143, 29);
            this.cmb_DaysOrMonths.MaxRecentCount = 10;
            this.cmb_DaysOrMonths.Name = "cmb_DaysOrMonths";
            this.cmb_DaysOrMonths.ReadOnly = false;
            this.cmb_DaysOrMonths.RecentItemsFileName = null;
            this.cmb_DaysOrMonths.RecentItemsFolder = "";
            this.cmb_DaysOrMonths.Size = new System.Drawing.Size(166, 27);
            this.cmb_DaysOrMonths.TabIndex = 5;
            this.cmb_DaysOrMonths.SelectedIndexChanged += new System.EventHandler(this.cmb_DaysOrMonths_SelectedIndexChanged);
            // 
            // dtP_TenderValidUntil
            // 
            this.dtP_TenderValidUntil.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.dtP_TenderValidUntil.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.dtP_TenderValidUntil.Location = new System.Drawing.Point(281, 76);
            this.dtP_TenderValidUntil.Name = "dtP_TenderValidUntil";
            this.dtP_TenderValidUntil.Size = new System.Drawing.Size(253, 26);
            this.dtP_TenderValidUntil.TabIndex = 4;
            this.dtP_TenderValidUntil.ValueChanged += new System.EventHandler(this.dtP_TenderValidUntil_ValueChanged);
            // 
            // rdb_Valid_Tender_Until
            // 
            this.rdb_Valid_Tender_Until.AutoSize = true;
            this.rdb_Valid_Tender_Until.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rdb_Valid_Tender_Until.ForeColor = System.Drawing.Color.Black;
            this.rdb_Valid_Tender_Until.Location = new System.Drawing.Point(17, 78);
            this.rdb_Valid_Tender_Until.Name = "rdb_Valid_Tender_Until";
            this.rdb_Valid_Tender_Until.Size = new System.Drawing.Size(95, 24);
            this.rdb_Valid_Tender_Until.TabIndex = 3;
            this.rdb_Valid_Tender_Until.TabStop = true;
            this.rdb_Valid_Tender_Until.Text = "Valid until";
            this.rdb_Valid_Tender_Until.UseVisualStyleBackColor = true;
            // 
            // rdb_ValidNumberOf
            // 
            this.rdb_ValidNumberOf.AutoSize = true;
            this.rdb_ValidNumberOf.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rdb_ValidNumberOf.ForeColor = System.Drawing.Color.Black;
            this.rdb_ValidNumberOf.Location = new System.Drawing.Point(17, 30);
            this.rdb_ValidNumberOf.Name = "rdb_ValidNumberOf";
            this.rdb_ValidNumberOf.Size = new System.Drawing.Size(101, 24);
            this.rdb_ValidNumberOf.TabIndex = 2;
            this.rdb_ValidNumberOf.TabStop = true;
            this.rdb_ValidNumberOf.Text = "Number of";
            this.rdb_ValidNumberOf.UseVisualStyleBackColor = true;
            // 
            // nmUpDn_NumberOfDaysOrMonths
            // 
            this.nmUpDn_NumberOfDaysOrMonths.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.nmUpDn_NumberOfDaysOrMonths.Location = new System.Drawing.Point(350, 30);
            this.nmUpDn_NumberOfDaysOrMonths.Name = "nmUpDn_NumberOfDaysOrMonths";
            this.nmUpDn_NumberOfDaysOrMonths.Size = new System.Drawing.Size(184, 26);
            this.nmUpDn_NumberOfDaysOrMonths.TabIndex = 1;
            this.nmUpDn_NumberOfDaysOrMonths.ValueChanged += new System.EventHandler(this.nmUpDn_NumberOfDaysOrMonths_ValueChanged);
            // 
            // grp_TermsOfPayment
            // 
            this.grp_TermsOfPayment.Controls.Add(this.btn_Select_Terms_of_Payment);
            this.grp_TermsOfPayment.Controls.Add(this.txt_PaymantConditionsDescription);
            this.grp_TermsOfPayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.grp_TermsOfPayment.Location = new System.Drawing.Point(6, 169);
            this.grp_TermsOfPayment.Name = "grp_TermsOfPayment";
            this.grp_TermsOfPayment.Size = new System.Drawing.Size(563, 134);
            this.grp_TermsOfPayment.TabIndex = 15;
            this.grp_TermsOfPayment.TabStop = false;
            this.grp_TermsOfPayment.Text = "Terms of Payment";
            // 
            // btn_Select_Terms_of_Payment
            // 
            this.btn_Select_Terms_of_Payment.ForeColor = System.Drawing.Color.Black;
            this.btn_Select_Terms_of_Payment.Image = global::Tangenta.Properties.Resources.SelectRow;
            this.btn_Select_Terms_of_Payment.Location = new System.Drawing.Point(162, 13);
            this.btn_Select_Terms_of_Payment.Name = "btn_Select_Terms_of_Payment";
            this.btn_Select_Terms_of_Payment.Size = new System.Drawing.Size(55, 26);
            this.btn_Select_Terms_of_Payment.TabIndex = 14;
            this.btn_Select_Terms_of_Payment.UseVisualStyleBackColor = true;
            this.btn_Select_Terms_of_Payment.Click += new System.EventHandler(this.btn_Select_Terms_of_Payment_Click);
            // 
            // txt_PaymantConditionsDescription
            // 
            this.txt_PaymantConditionsDescription.Location = new System.Drawing.Point(16, 45);
            this.txt_PaymantConditionsDescription.Multiline = true;
            this.txt_PaymantConditionsDescription.Name = "txt_PaymantConditionsDescription";
            this.txt_PaymantConditionsDescription.ReadOnly = true;
            this.txt_PaymantConditionsDescription.Size = new System.Drawing.Size(537, 72);
            this.txt_PaymantConditionsDescription.TabIndex = 13;
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_Cancel.ForeColor = System.Drawing.Color.Black;
            this.btn_Cancel.Image = global::Tangenta.Properties.Resources.Exit;
            this.btn_Cancel.Location = new System.Drawing.Point(444, 431);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(115, 52);
            this.btn_Cancel.TabIndex = 12;
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // dtP_DateOfIssue
            // 
            this.dtP_DateOfIssue.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.dtP_DateOfIssue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.dtP_DateOfIssue.Location = new System.Drawing.Point(258, 3);
            this.dtP_DateOfIssue.Name = "dtP_DateOfIssue";
            this.dtP_DateOfIssue.Size = new System.Drawing.Size(253, 26);
            this.dtP_DateOfIssue.TabIndex = 6;
            // 
            // lbl_DateOfIssue
            // 
            this.lbl_DateOfIssue.Location = new System.Drawing.Point(5, 3);
            this.lbl_DateOfIssue.Name = "lbl_DateOfIssue";
            this.lbl_DateOfIssue.Size = new System.Drawing.Size(247, 25);
            this.lbl_DateOfIssue.TabIndex = 16;
            this.lbl_DateOfIssue.Text = "Date of issue";
            this.lbl_DateOfIssue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // usrc_DocProformaInvoice_AddOn
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.lbl_DateOfIssue);
            this.Controls.Add(this.dtP_DateOfIssue);
            this.Controls.Add(this.grp_TermsOfPayment);
            this.Controls.Add(this.grp_ValidityOfTheTender);
            this.Controls.Add(this.grp_MtehodOfPaymentType);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_Print);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "usrc_DocProformaInvoice_AddOn";
            this.Size = new System.Drawing.Size(581, 501);
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
        private System.Windows.Forms.RadioButton rdb_ValidNumberOf;
        private System.Windows.Forms.NumericUpDown nmUpDn_NumberOfDaysOrMonths;
        private System.Windows.Forms.DateTimePicker dtP_TenderValidUntil;
        private System.Windows.Forms.RadioButton rdb_Valid_Tender_Until;
        private System.Windows.Forms.GroupBox grp_TermsOfPayment;
        private System.Windows.Forms.TextBox txt_PaymantConditionsDescription;
        private System.Windows.Forms.Button btn_Select_Terms_of_Payment;
        private ComboBox_Recent.ComboBox_RecentList cmb_DaysOrMonths;
        private System.Windows.Forms.Button btn_Select_BankAccount;
        private System.Windows.Forms.TextBox txt_BankAccount;
        private System.Windows.Forms.DateTimePicker dtP_DateOfIssue;
        private System.Windows.Forms.Label lbl_DateOfIssue;
    }
}