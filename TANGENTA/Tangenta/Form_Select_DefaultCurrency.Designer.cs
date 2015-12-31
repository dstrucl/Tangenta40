namespace Tangenta
{
    partial class Form_Select_DefaultCurrency
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Select_DefaultCurrency));
            this.btn_OK = new System.Windows.Forms.Button();
            this.lbl_SelectedCurrency = new System.Windows.Forms.Label();
            this.txt_SelectedCurrency = new System.Windows.Forms.TextBox();
            this.dgvx_Currency = new DataGridView_2xls.DataGridView2xls();
            ((System.ComponentModel.ISupportInitialize)(this.dgvx_Currency)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_OK
            // 
            this.btn_OK.Location = new System.Drawing.Point(304, 349);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(82, 26);
            this.btn_OK.TabIndex = 1;
            this.btn_OK.Text = "OK";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // lbl_SelectedCurrency
            // 
            this.lbl_SelectedCurrency.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_SelectedCurrency.Location = new System.Drawing.Point(19, 312);
            this.lbl_SelectedCurrency.Name = "lbl_SelectedCurrency";
            this.lbl_SelectedCurrency.Size = new System.Drawing.Size(126, 26);
            this.lbl_SelectedCurrency.TabIndex = 2;
            this.lbl_SelectedCurrency.Text = "label1";
            this.lbl_SelectedCurrency.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txt_SelectedCurrency
            // 
            this.txt_SelectedCurrency.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_SelectedCurrency.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_SelectedCurrency.Location = new System.Drawing.Point(146, 312);
            this.txt_SelectedCurrency.Name = "txt_SelectedCurrency";
            this.txt_SelectedCurrency.ReadOnly = true;
            this.txt_SelectedCurrency.Size = new System.Drawing.Size(240, 26);
            this.txt_SelectedCurrency.TabIndex = 3;
            this.txt_SelectedCurrency.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // dgvx_Currency
            // 
            this.dgvx_Currency.AllowUserToAddRows = false;
            this.dgvx_Currency.AllowUserToDeleteRows = false;
            this.dgvx_Currency.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvx_Currency.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvx_Currency.DataGridViewWithRowNumber = false;
            this.dgvx_Currency.Location = new System.Drawing.Point(12, 12);
            this.dgvx_Currency.Name = "dgvx_Currency";
            this.dgvx_Currency.ReadOnly = true;
            this.dgvx_Currency.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvx_Currency.Size = new System.Drawing.Size(711, 281);
            this.dgvx_Currency.TabIndex = 0;
            this.dgvx_Currency.SelectionChanged += new System.EventHandler(this.dgvx_Currency_SelectionChanged);
            // 
            // Form_Select_DefaultCurrency
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(735, 387);
            this.Controls.Add(this.txt_SelectedCurrency);
            this.Controls.Add(this.lbl_SelectedCurrency);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.dgvx_Currency);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_Select_DefaultCurrency";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Select_DefaultCurrency_Form";
            this.Load += new System.EventHandler(this.Select_DefaultCurrency_Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvx_Currency)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridView_2xls.DataGridView2xls dgvx_Currency;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Label lbl_SelectedCurrency;
        private System.Windows.Forms.TextBox txt_SelectedCurrency;
    }
}