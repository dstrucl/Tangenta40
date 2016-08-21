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
            this.lbl_SelectedCurrency = new System.Windows.Forms.Label();
            this.txt_SelectedCurrency = new System.Windows.Forms.TextBox();
            this.dgvx_Currency = new DataGridView_2xls.DataGridView2xls();
            this.usrc_NavigationButtons1 = new NavigationButtons.usrc_NavigationButtons();
            ((System.ComponentModel.ISupportInitialize)(this.dgvx_Currency)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_SelectedCurrency
            // 
            this.lbl_SelectedCurrency.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_SelectedCurrency.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_SelectedCurrency.Location = new System.Drawing.Point(15, 331);
            this.lbl_SelectedCurrency.Name = "lbl_SelectedCurrency";
            this.lbl_SelectedCurrency.Size = new System.Drawing.Size(126, 26);
            this.lbl_SelectedCurrency.TabIndex = 2;
            this.lbl_SelectedCurrency.Text = "label1";
            this.lbl_SelectedCurrency.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txt_SelectedCurrency
            // 
            this.txt_SelectedCurrency.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txt_SelectedCurrency.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_SelectedCurrency.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_SelectedCurrency.Location = new System.Drawing.Point(142, 331);
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
            this.dgvx_Currency.Size = new System.Drawing.Size(711, 308);
            this.dgvx_Currency.TabIndex = 0;
            this.dgvx_Currency.SelectionChanged += new System.EventHandler(this.dgvx_Currency_SelectionChanged);
            // 
            // usrc_NavigationButtons1
            // 
            this.usrc_NavigationButtons1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.usrc_NavigationButtons1.BackColor = System.Drawing.SystemColors.Control;
            this.usrc_NavigationButtons1.btn1_ToolTip_Text = "";
            this.usrc_NavigationButtons1.btn2_ToolTip_Text = "";
            this.usrc_NavigationButtons1.btn3_ToolTip_Text = "";
            this.usrc_NavigationButtons1.Buttons = NavigationButtons.Navigation.eButtons.OkCancel;
            this.usrc_NavigationButtons1.ExitQuestion = "Exit Program?";
            this.usrc_NavigationButtons1.Image_Cancel = null;
            this.usrc_NavigationButtons1.Image_EXIT = null;
            this.usrc_NavigationButtons1.Image_NEXT = ((System.Drawing.Image)(resources.GetObject("usrc_NavigationButtons1.Image_NEXT")));
            this.usrc_NavigationButtons1.Image_OK = ((System.Drawing.Image)(resources.GetObject("usrc_NavigationButtons1.Image_OK")));
            this.usrc_NavigationButtons1.Image_PREV = ((System.Drawing.Image)(resources.GetObject("usrc_NavigationButtons1.Image_PREV")));
            this.usrc_NavigationButtons1.Location = new System.Drawing.Point(5, 365);
            this.usrc_NavigationButtons1.Name = "usrc_NavigationButtons1";
            this.usrc_NavigationButtons1.Size = new System.Drawing.Size(729, 67);
            this.usrc_NavigationButtons1.TabIndex = 4;
            this.usrc_NavigationButtons1.Text_Cancel = "Exit";
            this.usrc_NavigationButtons1.Text_EXIT = "Exit";
            this.usrc_NavigationButtons1.Text_NEXT = "";
            this.usrc_NavigationButtons1.Text_OK = "";
            this.usrc_NavigationButtons1.Text_PREV = "";
            this.usrc_NavigationButtons1.Visible_EXIT = true;
            this.usrc_NavigationButtons1.Visible_NEXT = true;
            this.usrc_NavigationButtons1.Visible_PREV = true;
            this.usrc_NavigationButtons1.ButtonPressed += new NavigationButtons.usrc_NavigationButtons.delegate_button_pressed(this.usrc_NavigationButtons1_ButtonPressed);
            // 
            // Form_Select_DefaultCurrency
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(735, 435);
            this.Controls.Add(this.usrc_NavigationButtons1);
            this.Controls.Add(this.txt_SelectedCurrency);
            this.Controls.Add(this.lbl_SelectedCurrency);
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
        private System.Windows.Forms.Label lbl_SelectedCurrency;
        private System.Windows.Forms.TextBox txt_SelectedCurrency;
        private NavigationButtons.usrc_NavigationButtons usrc_NavigationButtons1;
    }
}