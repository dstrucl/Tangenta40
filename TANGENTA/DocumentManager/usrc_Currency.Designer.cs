namespace DocumentManager
{
    partial class usrc_Currency
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
            this.btn_SelectCurrency = new System.Windows.Forms.Button();
            this.txt_Currency = new System.Windows.Forms.TextBox();
            this.lbl_Currency = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_SelectCurrency
            // 
            this.btn_SelectCurrency.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_SelectCurrency.AutoEllipsis = true;
            this.btn_SelectCurrency.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_SelectCurrency.Image = Properties.Resources.SelectRow;
            this.btn_SelectCurrency.Location = new System.Drawing.Point(181, 0);
            this.btn_SelectCurrency.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_SelectCurrency.Name = "btn_SelectCurrency";
            this.btn_SelectCurrency.Size = new System.Drawing.Size(42, 34);
            this.btn_SelectCurrency.TabIndex = 31;
            this.btn_SelectCurrency.UseVisualStyleBackColor = false;
            this.btn_SelectCurrency.Click += new System.EventHandler(this.btn_SelectCurrency_Click);
            // 
            // txt_Currency
            // 
            this.txt_Currency.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Currency.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_Currency.Location = new System.Drawing.Point(115, 3);
            this.txt_Currency.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_Currency.Name = "txt_Currency";
            this.txt_Currency.ReadOnly = true;
            this.txt_Currency.Size = new System.Drawing.Size(59, 29);
            this.txt_Currency.TabIndex = 30;
            // 
            // lbl_Currency
            // 
            this.lbl_Currency.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Currency.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_Currency.Location = new System.Drawing.Point(2, 8);
            this.lbl_Currency.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_Currency.Name = "lbl_Currency";
            this.lbl_Currency.Size = new System.Drawing.Size(112, 21);
            this.lbl_Currency.TabIndex = 29;
            this.lbl_Currency.Text = "Valuta:";
            this.lbl_Currency.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // usrc_Currency
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.btn_SelectCurrency);
            this.Controls.Add(this.txt_Currency);
            this.Controls.Add(this.lbl_Currency);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "usrc_Currency";
            this.Size = new System.Drawing.Size(224, 34);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txt_Currency;
        private System.Windows.Forms.Label lbl_Currency;
        internal System.Windows.Forms.Button btn_SelectCurrency;
    }
}
