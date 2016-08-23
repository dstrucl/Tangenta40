namespace Country_ISO_3166
{
    partial class Form_Select_Country_ISO_3166
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Select_Country_ISO_3166));
            this.dgvx_ISO_3166 = new DataGridView_2xls.DataGridView2xls();
            this.txt_SelectCountry = new System.Windows.Forms.TextBox();
            this.usrc_NavigationButtons1 = new NavigationButtons.usrc_NavigationButtons();
            ((System.ComponentModel.ISupportInitialize)(this.dgvx_ISO_3166)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvx_ISO_3166
            // 
            this.dgvx_ISO_3166.AllowUserToAddRows = false;
            this.dgvx_ISO_3166.AllowUserToDeleteRows = false;
            this.dgvx_ISO_3166.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvx_ISO_3166.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvx_ISO_3166.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvx_ISO_3166.DataGridViewWithRowNumber = false;
            this.dgvx_ISO_3166.Location = new System.Drawing.Point(3, 36);
            this.dgvx_ISO_3166.MultiSelect = false;
            this.dgvx_ISO_3166.Name = "dgvx_ISO_3166";
            this.dgvx_ISO_3166.ReadOnly = true;
            this.dgvx_ISO_3166.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvx_ISO_3166.Size = new System.Drawing.Size(641, 427);
            this.dgvx_ISO_3166.TabIndex = 0;
            this.dgvx_ISO_3166.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvx_ISO_3166_CellContentClick);
            // 
            // txt_SelectCountry
            // 
            this.txt_SelectCountry.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_SelectCountry.Location = new System.Drawing.Point(5, 8);
            this.txt_SelectCountry.Name = "txt_SelectCountry";
            this.txt_SelectCountry.Size = new System.Drawing.Size(345, 22);
            this.txt_SelectCountry.TabIndex = 3;
            this.txt_SelectCountry.TextChanged += new System.EventHandler(this.txt_SelectCountry_TextChanged);
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
            this.usrc_NavigationButtons1.Location = new System.Drawing.Point(3, 469);
            this.usrc_NavigationButtons1.Name = "usrc_NavigationButtons1";
            this.usrc_NavigationButtons1.Size = new System.Drawing.Size(641, 63);
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
            // Form_Select_Country_ISO_3166
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 533);
            this.Controls.Add(this.usrc_NavigationButtons1);
            this.Controls.Add(this.txt_SelectCountry);
            this.Controls.Add(this.dgvx_ISO_3166);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_Select_Country_ISO_3166";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form_Select_Country_ISO_3166";
            this.Load += new System.EventHandler(this.Form_Select_Country_ISO_3166_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvx_ISO_3166)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridView_2xls.DataGridView2xls dgvx_ISO_3166;
        private System.Windows.Forms.TextBox txt_SelectCountry;
        private NavigationButtons.usrc_NavigationButtons usrc_NavigationButtons1;
    }
}