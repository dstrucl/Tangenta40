namespace ShopC
{
    partial class Form_Select_Item_From_Stock
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
            this.lbl_Select = new System.Windows.Forms.Label();
            this.lbl_Quantity = new System.Windows.Forms.Label();
            this.dgvx_Item_From_Stock = new DataGridView_2xls.DataGridView2xls();
            this.lbl_Selected = new System.Windows.Forms.Label();
            this.btn_OK = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvx_Item_From_Stock)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_Select
            // 
            this.lbl_Select.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_Select.Location = new System.Drawing.Point(12, 13);
            this.lbl_Select.Name = "lbl_Select";
            this.lbl_Select.Size = new System.Drawing.Size(81, 16);
            this.lbl_Select.TabIndex = 1;
            this.lbl_Select.Text = "Select";
            // 
            // lbl_Quantity
            // 
            this.lbl_Quantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_Quantity.Location = new System.Drawing.Point(99, 13);
            this.lbl_Quantity.Name = "lbl_Quantity";
            this.lbl_Quantity.Size = new System.Drawing.Size(295, 16);
            this.lbl_Quantity.TabIndex = 2;
            this.lbl_Quantity.Text = "Quantity";
            // 
            // dgvx_Item_From_Stock
            // 
            this.dgvx_Item_From_Stock.AllowUserToAddRows = false;
            this.dgvx_Item_From_Stock.AllowUserToDeleteRows = false;
            this.dgvx_Item_From_Stock.AllowUserToOrderColumns = true;
            this.dgvx_Item_From_Stock.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvx_Item_From_Stock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvx_Item_From_Stock.DataGridViewWithRowNumber = false;
            this.dgvx_Item_From_Stock.Location = new System.Drawing.Point(13, 43);
            this.dgvx_Item_From_Stock.Name = "dgvx_Item_From_Stock";
            this.dgvx_Item_From_Stock.Size = new System.Drawing.Size(761, 349);
            this.dgvx_Item_From_Stock.TabIndex = 0;
            this.dgvx_Item_From_Stock.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvx_Item_From_Stock_CellContentClick);
            // 
            // lbl_Selected
            // 
            this.lbl_Selected.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_Selected.AutoSize = true;
            this.lbl_Selected.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_Selected.Location = new System.Drawing.Point(7, 403);
            this.lbl_Selected.Name = "lbl_Selected";
            this.lbl_Selected.Size = new System.Drawing.Size(49, 13);
            this.lbl_Selected.TabIndex = 3;
            this.lbl_Selected.Text = "Selected";
            // 
            // btn_OK
            // 
            this.btn_OK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_OK.Location = new System.Drawing.Point(294, 403);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(70, 26);
            this.btn_OK.TabIndex = 4;
            this.btn_OK.Text = "OK";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Cancel.Location = new System.Drawing.Point(485, 403);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(70, 26);
            this.btn_Cancel.TabIndex = 5;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // Form_Select_Item_From_Stock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(786, 439);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.lbl_Selected);
            this.Controls.Add(this.lbl_Quantity);
            this.Controls.Add(this.lbl_Select);
            this.Controls.Add(this.dgvx_Item_From_Stock);
            this.Name = "Form_Select_Item_From_Stock";
            this.Text = "Form_Select_Item_From_Stock";
            ((System.ComponentModel.ISupportInitialize)(this.dgvx_Item_From_Stock)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridView_2xls.DataGridView2xls dgvx_Item_From_Stock;
        private System.Windows.Forms.Label lbl_Select;
        private System.Windows.Forms.Label lbl_Quantity;
        private System.Windows.Forms.Label lbl_Selected;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Button btn_Cancel;
    }
}