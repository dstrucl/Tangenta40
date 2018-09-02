namespace LoginControl
{
    partial class Form_CloseCashier
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
            this.btn_YesPrint = new System.Windows.Forms.Button();
            this.lbl_CashierClose_Question = new System.Windows.Forms.Label();
            this.btn_NO = new System.Windows.Forms.Button();
            this.btn_YES = new System.Windows.Forms.Button();
            this.usrc_CashierActivity1 = new LoginControl.usrc_CashierActivity();
            this.SuspendLayout();
            // 
            // btn_YesPrint
            // 
            this.btn_YesPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_YesPrint.Image = global::LoginControl.Properties.Resources.Print;
            this.btn_YesPrint.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btn_YesPrint.Location = new System.Drawing.Point(3, 246);
            this.btn_YesPrint.Name = "btn_YesPrint";
            this.btn_YesPrint.Size = new System.Drawing.Size(291, 100);
            this.btn_YesPrint.TabIndex = 51;
            this.btn_YesPrint.Text = "PRINT";
            this.btn_YesPrint.UseVisualStyleBackColor = true;
            this.btn_YesPrint.Click += new System.EventHandler(this.btn_YesPrint_Click);
            // 
            // lbl_CashierClose_Question
            // 
            this.lbl_CashierClose_Question.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_CashierClose_Question.ForeColor = System.Drawing.Color.Blue;
            this.lbl_CashierClose_Question.Location = new System.Drawing.Point(181, 209);
            this.lbl_CashierClose_Question.Name = "lbl_CashierClose_Question";
            this.lbl_CashierClose_Question.Size = new System.Drawing.Size(338, 31);
            this.lbl_CashierClose_Question.TabIndex = 50;
            this.lbl_CashierClose_Question.Text = "Close Cashier ?";
            this.lbl_CashierClose_Question.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_NO
            // 
            this.btn_NO.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_NO.Location = new System.Drawing.Point(543, 246);
            this.btn_NO.Name = "btn_NO";
            this.btn_NO.Size = new System.Drawing.Size(142, 100);
            this.btn_NO.TabIndex = 49;
            this.btn_NO.Text = "NO";
            this.btn_NO.UseVisualStyleBackColor = true;
            this.btn_NO.Click += new System.EventHandler(this.btn_NO_Click);
            // 
            // btn_YES
            // 
            this.btn_YES.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_YES.Location = new System.Drawing.Point(309, 246);
            this.btn_YES.Name = "btn_YES";
            this.btn_YES.Size = new System.Drawing.Size(228, 100);
            this.btn_YES.TabIndex = 48;
            this.btn_YES.Text = "YES";
            this.btn_YES.UseVisualStyleBackColor = true;
            this.btn_YES.Click += new System.EventHandler(this.btn_YES_Click);
            // 
            // usrc_CashierActivity1
            // 
            this.usrc_CashierActivity1.Location = new System.Drawing.Point(2, 2);
            this.usrc_CashierActivity1.Name = "usrc_CashierActivity1";
            this.usrc_CashierActivity1.Size = new System.Drawing.Size(684, 201);
            this.usrc_CashierActivity1.TabIndex = 0;
            // 
            // Form_CloseCashier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(685, 356);
            this.Controls.Add(this.btn_YesPrint);
            this.Controls.Add(this.lbl_CashierClose_Question);
            this.Controls.Add(this.btn_NO);
            this.Controls.Add(this.btn_YES);
            this.Controls.Add(this.usrc_CashierActivity1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form_CloseCashier";
            this.Text = "Form_CloseCashier";
            this.Load += new System.EventHandler(this.Form_CloseCashier_Load);
            this.ResumeLayout(false);

        }
        #endregion

        private usrc_CashierActivity usrc_CashierActivity1;
        private System.Windows.Forms.Button btn_YesPrint;
        private System.Windows.Forms.Label lbl_CashierClose_Question;
        private System.Windows.Forms.Button btn_NO;
        private System.Windows.Forms.Button btn_YES;
    }
}