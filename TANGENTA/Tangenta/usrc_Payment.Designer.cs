namespace Tangenta
{
    partial class usrc_Payment
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
            this.rdb_PaymentCard = new System.Windows.Forms.RadioButton();
            this.rdb_AllreadyPayed = new System.Windows.Forms.RadioButton();
            this.lbl_Amount = new System.Windows.Forms.Label();
            this.txt__Amount = new System.Windows.Forms.TextBox();
            this.txt_ToReturn = new System.Windows.Forms.TextBox();
            this.lbl_ToReturn = new System.Windows.Forms.Label();
            this.btn_Print = new System.Windows.Forms.Button();
            this.txt_AmountReceived = new System.Windows.Forms.TextBox();
            this.lbl_AmountReceived = new System.Windows.Forms.Label();
            this.rdb_BankAccountTransfer = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // rdb_Cash
            // 
            this.rdb_Cash.AutoSize = true;
            this.rdb_Cash.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rdb_Cash.ForeColor = System.Drawing.Color.Black;
            this.rdb_Cash.Location = new System.Drawing.Point(117, 3);
            this.rdb_Cash.Name = "rdb_Cash";
            this.rdb_Cash.Size = new System.Drawing.Size(108, 35);
            this.rdb_Cash.TabIndex = 0;
            this.rdb_Cash.Text = "CASH";
            this.rdb_Cash.UseVisualStyleBackColor = true;
            // 
            // rdb_PaymentCard
            // 
            this.rdb_PaymentCard.AutoSize = true;
            this.rdb_PaymentCard.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rdb_PaymentCard.ForeColor = System.Drawing.Color.Black;
            this.rdb_PaymentCard.Location = new System.Drawing.Point(117, 55);
            this.rdb_PaymentCard.Name = "rdb_PaymentCard";
            this.rdb_PaymentCard.Size = new System.Drawing.Size(220, 35);
            this.rdb_PaymentCard.TabIndex = 1;
            this.rdb_PaymentCard.Text = "CREDIT CARD";
            this.rdb_PaymentCard.UseVisualStyleBackColor = true;
            // 
            // rdb_AllreadyPayed
            // 
            this.rdb_AllreadyPayed.AutoSize = true;
            this.rdb_AllreadyPayed.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rdb_AllreadyPayed.ForeColor = System.Drawing.Color.Black;
            this.rdb_AllreadyPayed.Location = new System.Drawing.Point(117, 107);
            this.rdb_AllreadyPayed.Name = "rdb_AllreadyPayed";
            this.rdb_AllreadyPayed.Size = new System.Drawing.Size(214, 35);
            this.rdb_AllreadyPayed.TabIndex = 2;
            this.rdb_AllreadyPayed.Text = "Allready Payed";
            this.rdb_AllreadyPayed.UseVisualStyleBackColor = true;
            // 
            // lbl_Amount
            // 
            this.lbl_Amount.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_Amount.ForeColor = System.Drawing.Color.Black;
            this.lbl_Amount.Location = new System.Drawing.Point(40, 161);
            this.lbl_Amount.Name = "lbl_Amount";
            this.lbl_Amount.Size = new System.Drawing.Size(207, 37);
            this.lbl_Amount.TabIndex = 3;
            this.lbl_Amount.Text = "Amount:";
            this.lbl_Amount.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lbl_Amount.Click += new System.EventHandler(this.lbl_Amount_Click);
            // 
            // txt__Amount
            // 
            this.txt__Amount.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt__Amount.Location = new System.Drawing.Point(252, 161);
            this.txt__Amount.Name = "txt__Amount";
            this.txt__Amount.Size = new System.Drawing.Size(256, 38);
            this.txt__Amount.TabIndex = 4;
            this.txt__Amount.TextChanged += new System.EventHandler(this.txt__Amount_TextChanged);
            // 
            // txt_ToReturn
            // 
            this.txt_ToReturn.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_ToReturn.ForeColor = System.Drawing.Color.Tomato;
            this.txt_ToReturn.Location = new System.Drawing.Point(252, 262);
            this.txt_ToReturn.Name = "txt_ToReturn";
            this.txt_ToReturn.Size = new System.Drawing.Size(256, 38);
            this.txt_ToReturn.TabIndex = 6;
            this.txt_ToReturn.Visible = false;
            // 
            // lbl_ToReturn
            // 
            this.lbl_ToReturn.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_ToReturn.ForeColor = System.Drawing.Color.Black;
            this.lbl_ToReturn.Location = new System.Drawing.Point(49, 265);
            this.lbl_ToReturn.Name = "lbl_ToReturn";
            this.lbl_ToReturn.Size = new System.Drawing.Size(197, 33);
            this.lbl_ToReturn.TabIndex = 5;
            this.lbl_ToReturn.Text = "Vračilo:";
            this.lbl_ToReturn.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lbl_ToReturn.Visible = false;
            // 
            // btn_Print
            // 
            this.btn_Print.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_Print.ForeColor = System.Drawing.Color.Black;
            this.btn_Print.Location = new System.Drawing.Point(153, 306);
            this.btn_Print.Name = "btn_Print";
            this.btn_Print.Size = new System.Drawing.Size(197, 55);
            this.btn_Print.TabIndex = 7;
            this.btn_Print.Text = "Print";
            this.btn_Print.UseVisualStyleBackColor = true;
            this.btn_Print.Click += new System.EventHandler(this.btn_Print_Click);
            // 
            // txt_AmountReceived
            // 
            this.txt_AmountReceived.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_AmountReceived.ForeColor = System.Drawing.Color.Olive;
            this.txt_AmountReceived.Location = new System.Drawing.Point(252, 210);
            this.txt_AmountReceived.Name = "txt_AmountReceived";
            this.txt_AmountReceived.Size = new System.Drawing.Size(256, 38);
            this.txt_AmountReceived.TabIndex = 9;
            this.txt_AmountReceived.Visible = false;
            // 
            // lbl_AmountReceived
            // 
            this.lbl_AmountReceived.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_AmountReceived.ForeColor = System.Drawing.Color.Black;
            this.lbl_AmountReceived.Location = new System.Drawing.Point(-13, 213);
            this.lbl_AmountReceived.Name = "lbl_AmountReceived";
            this.lbl_AmountReceived.Size = new System.Drawing.Size(259, 37);
            this.lbl_AmountReceived.TabIndex = 8;
            this.lbl_AmountReceived.Text = "Amount Received:";
            this.lbl_AmountReceived.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lbl_AmountReceived.Visible = false;
            // 
            // rdb_BankAccountTransfer
            // 
            this.rdb_BankAccountTransfer.AutoSize = true;
            this.rdb_BankAccountTransfer.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rdb_BankAccountTransfer.ForeColor = System.Drawing.Color.Black;
            this.rdb_BankAccountTransfer.Location = new System.Drawing.Point(339, 3);
            this.rdb_BankAccountTransfer.Name = "rdb_BankAccountTransfer";
            this.rdb_BankAccountTransfer.Size = new System.Drawing.Size(200, 35);
            this.rdb_BankAccountTransfer.TabIndex = 10;
            this.rdb_BankAccountTransfer.Text = "Bank Account";
            this.rdb_BankAccountTransfer.UseVisualStyleBackColor = true;
            // 
            // usrc_Payment
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.rdb_BankAccountTransfer);
            this.Controls.Add(this.txt_AmountReceived);
            this.Controls.Add(this.lbl_AmountReceived);
            this.Controls.Add(this.btn_Print);
            this.Controls.Add(this.txt_ToReturn);
            this.Controls.Add(this.lbl_ToReturn);
            this.Controls.Add(this.txt__Amount);
            this.Controls.Add(this.lbl_Amount);
            this.Controls.Add(this.rdb_AllreadyPayed);
            this.Controls.Add(this.rdb_PaymentCard);
            this.Controls.Add(this.rdb_Cash);
            this.ForeColor = System.Drawing.Color.Red;
            this.Name = "usrc_Payment";
            this.Size = new System.Drawing.Size(615, 369);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rdb_Cash;
        private System.Windows.Forms.RadioButton rdb_PaymentCard;
        private System.Windows.Forms.RadioButton rdb_AllreadyPayed;
        private System.Windows.Forms.Label lbl_Amount;
        private System.Windows.Forms.TextBox txt__Amount;
        private System.Windows.Forms.TextBox txt_ToReturn;
        private System.Windows.Forms.Label lbl_ToReturn;
        private System.Windows.Forms.Button btn_Print;
        private System.Windows.Forms.TextBox txt_AmountReceived;
        private System.Windows.Forms.Label lbl_AmountReceived;
        private System.Windows.Forms.RadioButton rdb_BankAccountTransfer;
    }
}
