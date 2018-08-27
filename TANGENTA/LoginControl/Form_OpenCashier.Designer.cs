namespace LoginControl
{
    partial class Form_OpenCashier
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
            this.btn_YES = new System.Windows.Forms.Button();
            this.btn_NO = new System.Windows.Forms.Button();
            this.lbl_CashierOpen_Info = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_YES
            // 
            this.btn_YES.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_YES.Location = new System.Drawing.Point(112, 157);
            this.btn_YES.Name = "btn_YES";
            this.btn_YES.Size = new System.Drawing.Size(129, 84);
            this.btn_YES.TabIndex = 0;
            this.btn_YES.Text = "YES";
            this.btn_YES.UseVisualStyleBackColor = true;
            this.btn_YES.Click += new System.EventHandler(this.btn_YES_Click);
            // 
            // btn_NO
            // 
            this.btn_NO.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_NO.Location = new System.Drawing.Point(260, 157);
            this.btn_NO.Name = "btn_NO";
            this.btn_NO.Size = new System.Drawing.Size(120, 84);
            this.btn_NO.TabIndex = 1;
            this.btn_NO.Text = "NO";
            this.btn_NO.UseVisualStyleBackColor = true;
            this.btn_NO.Click += new System.EventHandler(this.btn_NO_Click);
            // 
            // lbl_CashierOpen_Info
            // 
            this.lbl_CashierOpen_Info.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_CashierOpen_Info.ForeColor = System.Drawing.Color.Blue;
            this.lbl_CashierOpen_Info.Location = new System.Drawing.Point(24, 26);
            this.lbl_CashierOpen_Info.Name = "lbl_CashierOpen_Info";
            this.lbl_CashierOpen_Info.Size = new System.Drawing.Size(426, 111);
            this.lbl_CashierOpen_Info.TabIndex = 2;
            this.lbl_CashierOpen_Info.Text = "Open Cashier ?";
            this.lbl_CashierOpen_Info.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form_OpenCashier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 253);
            this.Controls.Add(this.lbl_CashierOpen_Info);
            this.Controls.Add(this.btn_NO);
            this.Controls.Add(this.btn_YES);
            this.Name = "Form_OpenCashier";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form_OpenCashier";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_YES;
        private System.Windows.Forms.Button btn_NO;
        private System.Windows.Forms.Label lbl_CashierOpen_Info;
    }
}