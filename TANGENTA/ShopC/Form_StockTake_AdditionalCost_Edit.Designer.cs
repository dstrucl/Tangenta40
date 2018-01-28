namespace ShopC
{
    partial class Form_StockTake_AdditionalCost_Edit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_StockTake_AdditionalCost_Edit));
            this.cmb_StocTakeCostName = new System.Windows.Forms.ComboBox();
            this.nmUpDn_Cost = new System.Windows.Forms.NumericUpDown();
            this.txt_Description = new System.Windows.Forms.TextBox();
            this.lbl_StocTakeCostName = new System.Windows.Forms.Label();
            this.lbl_Cost = new System.Windows.Forms.Label();
            this.lbl_StockTakeCostDescription = new System.Windows.Forms.Label();
            this.btn_Add = new System.Windows.Forms.Button();
            this.btn_Update = new System.Windows.Forms.Button();
            this.btn_Remove = new System.Windows.Forms.Button();
            this.dgvx_StockTakeAdditionalCost = new DataGridView_2xls.DataGridView2xls();
            this.btn_Exit = new System.Windows.Forms.Button();
            this.usrc_Help1 = new HUDCMS.usrc_Help();
            ((System.ComponentModel.ISupportInitialize)(this.nmUpDn_Cost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvx_StockTakeAdditionalCost)).BeginInit();
            this.SuspendLayout();
            // 
            // cmb_StocTakeCostName
            // 
            this.cmb_StocTakeCostName.FormattingEnabled = true;
            this.cmb_StocTakeCostName.Location = new System.Drawing.Point(12, 25);
            this.cmb_StocTakeCostName.Name = "cmb_StocTakeCostName";
            this.cmb_StocTakeCostName.Size = new System.Drawing.Size(167, 21);
            this.cmb_StocTakeCostName.TabIndex = 1;
            // 
            // nmUpDn_Cost
            // 
            this.nmUpDn_Cost.Location = new System.Drawing.Point(190, 25);
            this.nmUpDn_Cost.Maximum = new decimal(new int[] {
            1410065408,
            2,
            0,
            0});
            this.nmUpDn_Cost.Name = "nmUpDn_Cost";
            this.nmUpDn_Cost.Size = new System.Drawing.Size(87, 20);
            this.nmUpDn_Cost.TabIndex = 2;
            // 
            // txt_Description
            // 
            this.txt_Description.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Description.Location = new System.Drawing.Point(292, 36);
            this.txt_Description.Multiline = true;
            this.txt_Description.Name = "txt_Description";
            this.txt_Description.Size = new System.Drawing.Size(275, 38);
            this.txt_Description.TabIndex = 3;
            // 
            // lbl_StocTakeCostName
            // 
            this.lbl_StocTakeCostName.AutoSize = true;
            this.lbl_StocTakeCostName.Location = new System.Drawing.Point(16, 9);
            this.lbl_StocTakeCostName.Name = "lbl_StocTakeCostName";
            this.lbl_StocTakeCostName.Size = new System.Drawing.Size(115, 13);
            this.lbl_StocTakeCostName.TabIndex = 4;
            this.lbl_StocTakeCostName.Text = "StockTake Cost Name";
            // 
            // lbl_Cost
            // 
            this.lbl_Cost.AutoSize = true;
            this.lbl_Cost.Location = new System.Drawing.Point(196, 9);
            this.lbl_Cost.Name = "lbl_Cost";
            this.lbl_Cost.Size = new System.Drawing.Size(34, 13);
            this.lbl_Cost.TabIndex = 5;
            this.lbl_Cost.Text = "Price:";
            // 
            // lbl_StockTakeCostDescription
            // 
            this.lbl_StockTakeCostDescription.AutoSize = true;
            this.lbl_StockTakeCostDescription.Location = new System.Drawing.Point(289, 17);
            this.lbl_StockTakeCostDescription.Name = "lbl_StockTakeCostDescription";
            this.lbl_StockTakeCostDescription.Size = new System.Drawing.Size(140, 13);
            this.lbl_StockTakeCostDescription.TabIndex = 6;
            this.lbl_StockTakeCostDescription.Text = "StockTake Cost Description";
            // 
            // btn_Add
            // 
            this.btn_Add.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_Add.Location = new System.Drawing.Point(12, 52);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(62, 22);
            this.btn_Add.TabIndex = 7;
            this.btn_Add.Text = "Add";
            this.btn_Add.UseVisualStyleBackColor = false;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // btn_Update
            // 
            this.btn_Update.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_Update.Location = new System.Drawing.Point(80, 52);
            this.btn_Update.Name = "btn_Update";
            this.btn_Update.Size = new System.Drawing.Size(99, 22);
            this.btn_Update.TabIndex = 8;
            this.btn_Update.Text = "Update";
            this.btn_Update.UseVisualStyleBackColor = false;
            this.btn_Update.Click += new System.EventHandler(this.btn_Update_Click);
            // 
            // btn_Remove
            // 
            this.btn_Remove.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_Remove.Location = new System.Drawing.Point(190, 52);
            this.btn_Remove.Name = "btn_Remove";
            this.btn_Remove.Size = new System.Drawing.Size(87, 22);
            this.btn_Remove.TabIndex = 9;
            this.btn_Remove.Text = "Remove";
            this.btn_Remove.UseVisualStyleBackColor = false;
            this.btn_Remove.Click += new System.EventHandler(this.btn_Remove_Click);
            // 
            // dgvx_StockTakeAdditionalCost
            // 
            this.dgvx_StockTakeAdditionalCost.AllowUserToAddRows = false;
            this.dgvx_StockTakeAdditionalCost.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvx_StockTakeAdditionalCost.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvx_StockTakeAdditionalCost.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvx_StockTakeAdditionalCost.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvx_StockTakeAdditionalCost.DataGridViewWithRowNumber = false;
            this.dgvx_StockTakeAdditionalCost.Location = new System.Drawing.Point(1, 80);
            this.dgvx_StockTakeAdditionalCost.MultiSelect = false;
            this.dgvx_StockTakeAdditionalCost.Name = "dgvx_StockTakeAdditionalCost";
            this.dgvx_StockTakeAdditionalCost.ReadOnly = true;
            this.dgvx_StockTakeAdditionalCost.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvx_StockTakeAdditionalCost.Size = new System.Drawing.Size(574, 426);
            this.dgvx_StockTakeAdditionalCost.TabIndex = 0;
            // 
            // btn_Exit
            // 
            this.btn_Exit.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_Exit.Image = global::ShopC.Properties.Resources.Exit;
            this.btn_Exit.Location = new System.Drawing.Point(445, 2);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(72, 28);
            this.btn_Exit.TabIndex = 10;
            this.btn_Exit.UseVisualStyleBackColor = false;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // usrc_Help1
            // 
            this.usrc_Help1.Location = new System.Drawing.Point(527, 2);
            this.usrc_Help1.Name = "usrc_Help1";
            this.usrc_Help1.Size = new System.Drawing.Size(39, 28);
            this.usrc_Help1.TabIndex = 11;
            // 
            // Form_StockTake_AdditionalCost_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 506);
            this.Controls.Add(this.usrc_Help1);
            this.Controls.Add(this.btn_Exit);
            this.Controls.Add(this.btn_Remove);
            this.Controls.Add(this.btn_Update);
            this.Controls.Add(this.btn_Add);
            this.Controls.Add(this.lbl_StockTakeCostDescription);
            this.Controls.Add(this.lbl_Cost);
            this.Controls.Add(this.lbl_StocTakeCostName);
            this.Controls.Add(this.txt_Description);
            this.Controls.Add(this.nmUpDn_Cost);
            this.Controls.Add(this.cmb_StocTakeCostName);
            this.Controls.Add(this.dgvx_StockTakeAdditionalCost);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_StockTake_AdditionalCost_Edit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form_StockTake_AdditionalCost";
            this.Load += new System.EventHandler(this.Form_StockTake_AdditionalCost_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nmUpDn_Cost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvx_StockTakeAdditionalCost)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridView_2xls.DataGridView2xls dgvx_StockTakeAdditionalCost;
        private System.Windows.Forms.ComboBox cmb_StocTakeCostName;
        private System.Windows.Forms.NumericUpDown nmUpDn_Cost;
        private System.Windows.Forms.TextBox txt_Description;
        private System.Windows.Forms.Label lbl_StocTakeCostName;
        private System.Windows.Forms.Label lbl_Cost;
        private System.Windows.Forms.Label lbl_StockTakeCostDescription;
        private System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.Button btn_Update;
        private System.Windows.Forms.Button btn_Remove;
        private System.Windows.Forms.Button btn_Exit;
        private HUDCMS.usrc_Help usrc_Help1;
    }
}