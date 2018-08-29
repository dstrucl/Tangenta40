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
            this.usrc_CashierActivity1 = new LoginControl.usrc_CashierActivity();
            this.SuspendLayout();
            // 
            // usrc_CashierActivity1
            // 
            this.usrc_CashierActivity1.Location = new System.Drawing.Point(2, 1);
            this.usrc_CashierActivity1.Name = "usrc_CashierActivity1";
            this.usrc_CashierActivity1.Size = new System.Drawing.Size(683, 491);
            this.usrc_CashierActivity1.TabIndex = 0;
            // 
            // Form_CloseCashier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(688, 493);
            this.Controls.Add(this.usrc_CashierActivity1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form_CloseCashier";
            this.Text = "Form_CloseCashier";
            this.ResumeLayout(false);

        }
        #endregion

        private usrc_CashierActivity usrc_CashierActivity1;
    }
}