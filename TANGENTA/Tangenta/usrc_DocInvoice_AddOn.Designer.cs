namespace Tangenta
{
    partial class usrc_DocInvoice_AddOn
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
            this.rdb_Cash = new System.Windows.Forms.RadioButton();
            this.rdb_AllreadyPayed = new System.Windows.Forms.RadioButton();
            this.btn_Invoice_Issue = new System.Windows.Forms.Button();
            this.rdb_BankAccountTransfer = new System.Windows.Forms.RadioButton();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.lbl_PaymentDeadline = new System.Windows.Forms.Label();
            this.dtP_DateOfIssue = new System.Windows.Forms.DateTimePicker();
            this.grp_TermsOfPayment = new System.Windows.Forms.GroupBox();
            this.btn_Select_Terms_of_Payment = new System.Windows.Forms.Button();
            this.txt_PaymantConditionsDescription = new System.Windows.Forms.TextBox();
            this.grp_MtehodOfPaymentType = new System.Windows.Forms.GroupBox();
            this.rdb_CARD = new System.Windows.Forms.RadioButton();
            this.btn_Select_BankAccount = new System.Windows.Forms.Button();
            this.txt_BankAccount = new System.Windows.Forms.TextBox();
            this.lbl_DateOfIssue = new System.Windows.Forms.Label();
            this.dtP_PaymentDeadline = new System.Windows.Forms.DateTimePicker();
            this.usrc_Notice1 = new Tangenta.usrc_Notice();
            this.grp_TermsOfPayment.SuspendLayout();
            this.grp_MtehodOfPaymentType.SuspendLayout();
            this.SuspendLayout();
            // 
            // rdb_Cash
            // 
            this.rdb_Cash.AutoSize = true;
            this.rdb_Cash.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rdb_Cash.ForeColor = System.Drawing.Color.Black;
            this.rdb_Cash.Location = new System.Drawing.Point(14, 37);
            this.rdb_Cash.Name = "rdb_Cash";
            this.rdb_Cash.Size = new System.Drawing.Size(88, 29);
            this.rdb_Cash.TabIndex = 0;
            this.rdb_Cash.Text = "CASH";
            this.rdb_Cash.UseVisualStyleBackColor = true;
            // 
            // rdb_AllreadyPayed
            // 
            this.rdb_AllreadyPayed.AutoSize = true;
            this.rdb_AllreadyPayed.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rdb_AllreadyPayed.ForeColor = System.Drawing.Color.Black;
            this.rdb_AllreadyPayed.Location = new System.Drawing.Point(447, 37);
            this.rdb_AllreadyPayed.Name = "rdb_AllreadyPayed";
            this.rdb_AllreadyPayed.Size = new System.Drawing.Size(175, 29);
            this.rdb_AllreadyPayed.TabIndex = 2;
            this.rdb_AllreadyPayed.Text = "Allready Payed";
            this.rdb_AllreadyPayed.UseVisualStyleBackColor = true;
            // 
            // btn_Invoice_Issue
            // 
            this.btn_Invoice_Issue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Invoice_Issue.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_Invoice_Issue.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_Invoice_Issue.ForeColor = System.Drawing.Color.Black;
            this.btn_Invoice_Issue.Location = new System.Drawing.Point(20, 486);
            this.btn_Invoice_Issue.Name = "btn_Invoice_Issue";
            this.btn_Invoice_Issue.Size = new System.Drawing.Size(398, 65);
            this.btn_Invoice_Issue.TabIndex = 7;
            this.btn_Invoice_Issue.Text = "Issue";
            this.btn_Invoice_Issue.UseVisualStyleBackColor = false;
            this.btn_Invoice_Issue.Click += new System.EventHandler(this.btn_Issue_Click);
            // 
            // rdb_BankAccountTransfer
            // 
            this.rdb_BankAccountTransfer.AutoSize = true;
            this.rdb_BankAccountTransfer.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rdb_BankAccountTransfer.ForeColor = System.Drawing.Color.Black;
            this.rdb_BankAccountTransfer.Location = new System.Drawing.Point(14, 92);
            this.rdb_BankAccountTransfer.Name = "rdb_BankAccountTransfer";
            this.rdb_BankAccountTransfer.Size = new System.Drawing.Size(163, 29);
            this.rdb_BankAccountTransfer.TabIndex = 10;
            this.rdb_BankAccountTransfer.Text = "Bank Account";
            this.rdb_BankAccountTransfer.UseVisualStyleBackColor = true;
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Cancel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_Cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_Cancel.ForeColor = System.Drawing.Color.Black;
            this.btn_Cancel.Image = global::Tangenta.Properties.Resources.Exit;
            this.btn_Cancel.Location = new System.Drawing.Point(590, 499);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(115, 52);
            this.btn_Cancel.TabIndex = 12;
            this.btn_Cancel.UseVisualStyleBackColor = false;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // lbl_PaymentDeadline
            // 
            this.lbl_PaymentDeadline.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_PaymentDeadline.Location = new System.Drawing.Point(23, 334);
            this.lbl_PaymentDeadline.Name = "lbl_PaymentDeadline";
            this.lbl_PaymentDeadline.Size = new System.Drawing.Size(228, 32);
            this.lbl_PaymentDeadline.TabIndex = 20;
            this.lbl_PaymentDeadline.Text = "Payment Deadline";
            this.lbl_PaymentDeadline.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtP_DateOfIssue
            // 
            this.dtP_DateOfIssue.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.dtP_DateOfIssue.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.dtP_DateOfIssue.Location = new System.Drawing.Point(264, 5);
            this.dtP_DateOfIssue.Name = "dtP_DateOfIssue";
            this.dtP_DateOfIssue.Size = new System.Drawing.Size(441, 29);
            this.dtP_DateOfIssue.TabIndex = 17;
            // 
            // grp_TermsOfPayment
            // 
            this.grp_TermsOfPayment.Controls.Add(this.btn_Select_Terms_of_Payment);
            this.grp_TermsOfPayment.Controls.Add(this.txt_PaymantConditionsDescription);
            this.grp_TermsOfPayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.grp_TermsOfPayment.Location = new System.Drawing.Point(20, 189);
            this.grp_TermsOfPayment.Name = "grp_TermsOfPayment";
            this.grp_TermsOfPayment.Size = new System.Drawing.Size(687, 135);
            this.grp_TermsOfPayment.TabIndex = 19;
            this.grp_TermsOfPayment.TabStop = false;
            this.grp_TermsOfPayment.Text = "Terms of Payment";
            // 
            // btn_Select_Terms_of_Payment
            // 
            this.btn_Select_Terms_of_Payment.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_Select_Terms_of_Payment.ForeColor = System.Drawing.Color.Black;
            this.btn_Select_Terms_of_Payment.Image = global::Tangenta.Properties.Resources.SelectRow;
            this.btn_Select_Terms_of_Payment.Location = new System.Drawing.Point(192, 13);
            this.btn_Select_Terms_of_Payment.Name = "btn_Select_Terms_of_Payment";
            this.btn_Select_Terms_of_Payment.Size = new System.Drawing.Size(55, 26);
            this.btn_Select_Terms_of_Payment.TabIndex = 14;
            this.btn_Select_Terms_of_Payment.UseVisualStyleBackColor = false;
            this.btn_Select_Terms_of_Payment.Click += new System.EventHandler(this.btn_Select_Terms_of_Payment_Click);
            // 
            // txt_PaymantConditionsDescription
            // 
            this.txt_PaymantConditionsDescription.Location = new System.Drawing.Point(16, 45);
            this.txt_PaymantConditionsDescription.Multiline = true;
            this.txt_PaymantConditionsDescription.Name = "txt_PaymantConditionsDescription";
            this.txt_PaymantConditionsDescription.ReadOnly = true;
            this.txt_PaymantConditionsDescription.Size = new System.Drawing.Size(642, 72);
            this.txt_PaymantConditionsDescription.TabIndex = 13;
            this.txt_PaymantConditionsDescription.TextChanged += new System.EventHandler(this.txt_PaymantConditionsDescription_TextChanged);
            // 
            // grp_MtehodOfPaymentType
            // 
            this.grp_MtehodOfPaymentType.Controls.Add(this.rdb_CARD);
            this.grp_MtehodOfPaymentType.Controls.Add(this.btn_Select_BankAccount);
            this.grp_MtehodOfPaymentType.Controls.Add(this.txt_BankAccount);
            this.grp_MtehodOfPaymentType.Controls.Add(this.rdb_Cash);
            this.grp_MtehodOfPaymentType.Controls.Add(this.rdb_BankAccountTransfer);
            this.grp_MtehodOfPaymentType.Controls.Add(this.rdb_AllreadyPayed);
            this.grp_MtehodOfPaymentType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.grp_MtehodOfPaymentType.Location = new System.Drawing.Point(20, 46);
            this.grp_MtehodOfPaymentType.Name = "grp_MtehodOfPaymentType";
            this.grp_MtehodOfPaymentType.Size = new System.Drawing.Size(687, 137);
            this.grp_MtehodOfPaymentType.TabIndex = 18;
            this.grp_MtehodOfPaymentType.TabStop = false;
            this.grp_MtehodOfPaymentType.Text = "Method of Payment";
            // 
            // rdb_CARD
            // 
            this.rdb_CARD.AutoSize = true;
            this.rdb_CARD.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rdb_CARD.ForeColor = System.Drawing.Color.Black;
            this.rdb_CARD.Location = new System.Drawing.Point(207, 37);
            this.rdb_CARD.Name = "rdb_CARD";
            this.rdb_CARD.Size = new System.Drawing.Size(89, 29);
            this.rdb_CARD.TabIndex = 13;
            this.rdb_CARD.Text = "CARD";
            this.rdb_CARD.UseVisualStyleBackColor = true;
            // 
            // btn_Select_BankAccount
            // 
            this.btn_Select_BankAccount.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_Select_BankAccount.ForeColor = System.Drawing.Color.Black;
            this.btn_Select_BankAccount.Image = global::Tangenta.Properties.Resources.SelectRow;
            this.btn_Select_BankAccount.Location = new System.Drawing.Point(618, 99);
            this.btn_Select_BankAccount.Name = "btn_Select_BankAccount";
            this.btn_Select_BankAccount.Size = new System.Drawing.Size(40, 25);
            this.btn_Select_BankAccount.TabIndex = 12;
            this.btn_Select_BankAccount.UseVisualStyleBackColor = false;
            this.btn_Select_BankAccount.Click += new System.EventHandler(this.btn_Select_BankAccount_Click);
            // 
            // txt_BankAccount
            // 
            this.txt_BankAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_BankAccount.Location = new System.Drawing.Point(378, 100);
            this.txt_BankAccount.Name = "txt_BankAccount";
            this.txt_BankAccount.ReadOnly = true;
            this.txt_BankAccount.Size = new System.Drawing.Size(234, 22);
            this.txt_BankAccount.TabIndex = 11;
            // 
            // lbl_DateOfIssue
            // 
            this.lbl_DateOfIssue.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_DateOfIssue.Location = new System.Drawing.Point(24, 8);
            this.lbl_DateOfIssue.Name = "lbl_DateOfIssue";
            this.lbl_DateOfIssue.Size = new System.Drawing.Size(231, 25);
            this.lbl_DateOfIssue.TabIndex = 22;
            this.lbl_DateOfIssue.Text = "Date of issue";
            this.lbl_DateOfIssue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtP_PaymentDeadline
            // 
            this.dtP_PaymentDeadline.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.dtP_PaymentDeadline.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.dtP_PaymentDeadline.Location = new System.Drawing.Point(259, 332);
            this.dtP_PaymentDeadline.Name = "dtP_PaymentDeadline";
            this.dtP_PaymentDeadline.Size = new System.Drawing.Size(320, 29);
            this.dtP_PaymentDeadline.TabIndex = 21;
            // 
            // usrc_Notice1
            // 
            this.usrc_Notice1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.usrc_Notice1.Location = new System.Drawing.Point(27, 370);
            this.usrc_Notice1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.usrc_Notice1.Name = "usrc_Notice1";
            this.usrc_Notice1.Size = new System.Drawing.Size(678, 110);
            this.usrc_Notice1.TabIndex = 23;
            // 
            // usrc_DocInvoice_AddOn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.usrc_Notice1);
            this.Controls.Add(this.lbl_DateOfIssue);
            this.Controls.Add(this.dtP_PaymentDeadline);
            this.Controls.Add(this.lbl_PaymentDeadline);
            this.Controls.Add(this.dtP_DateOfIssue);
            this.Controls.Add(this.grp_TermsOfPayment);
            this.Controls.Add(this.grp_MtehodOfPaymentType);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_Invoice_Issue);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "usrc_DocInvoice_AddOn";
            this.Size = new System.Drawing.Size(720, 564);
            this.grp_TermsOfPayment.ResumeLayout(false);
            this.grp_TermsOfPayment.PerformLayout();
            this.grp_MtehodOfPaymentType.ResumeLayout(false);
            this.grp_MtehodOfPaymentType.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton rdb_Cash;
        private System.Windows.Forms.RadioButton rdb_AllreadyPayed;
        private System.Windows.Forms.Button btn_Invoice_Issue;
        private System.Windows.Forms.RadioButton rdb_BankAccountTransfer;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Label lbl_PaymentDeadline;
        private System.Windows.Forms.DateTimePicker dtP_DateOfIssue;
        private System.Windows.Forms.GroupBox grp_TermsOfPayment;
        private System.Windows.Forms.Button btn_Select_Terms_of_Payment;
        private System.Windows.Forms.TextBox txt_PaymantConditionsDescription;
        private System.Windows.Forms.GroupBox grp_MtehodOfPaymentType;
        private System.Windows.Forms.RadioButton rdb_CARD;
        private System.Windows.Forms.Button btn_Select_BankAccount;
        private System.Windows.Forms.TextBox txt_BankAccount;
        private System.Windows.Forms.Label lbl_DateOfIssue;
        private System.Windows.Forms.DateTimePicker dtP_PaymentDeadline;
        private usrc_Notice usrc_Notice1;
    }
}
