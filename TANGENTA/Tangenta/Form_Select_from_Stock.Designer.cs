namespace Tangenta
{
    partial class Form_Select_from_Stock
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Select_from_Stock));
            this.lbl_Item = new System.Windows.Forms.Label();
            this.txt_Item = new System.Windows.Forms.TextBox();
            this.dgv_Stock = new System.Windows.Forms.DataGridView();
            this.txt_InStock = new System.Windows.Forms.TextBox();
            this.lbl_InStock = new System.Windows.Forms.Label();
            this.btn_OK = new System.Windows.Forms.Button();
            this.txt_ToSelect = new System.Windows.Forms.TextBox();
            this.lbl_ToSelect = new System.Windows.Forms.Label();
            this.txt_Selected = new System.Windows.Forms.TextBox();
            this.lbl_Selected = new System.Windows.Forms.Label();
            this.usrc_Help1 = new HUDCMS.usrc_Help();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Stock)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_Item
            // 
            this.lbl_Item.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_Item.Location = new System.Drawing.Point(12, 13);
            this.lbl_Item.Name = "lbl_Item";
            this.lbl_Item.Size = new System.Drawing.Size(123, 23);
            this.lbl_Item.TabIndex = 0;
            this.lbl_Item.Text = "Item";
            this.lbl_Item.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txt_Item
            // 
            this.txt_Item.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Item.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txt_Item.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_Item.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_Item.Location = new System.Drawing.Point(136, 14);
            this.txt_Item.Name = "txt_Item";
            this.txt_Item.ReadOnly = true;
            this.txt_Item.Size = new System.Drawing.Size(572, 19);
            this.txt_Item.TabIndex = 1;
            // 
            // dgv_Stock
            // 
            this.dgv_Stock.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_Stock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Stock.Location = new System.Drawing.Point(1, 76);
            this.dgv_Stock.Name = "dgv_Stock";
            this.dgv_Stock.Size = new System.Drawing.Size(845, 387);
            this.dgv_Stock.TabIndex = 2;
            // 
            // txt_InStock
            // 
            this.txt_InStock.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txt_InStock.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_InStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_InStock.Location = new System.Drawing.Point(129, 53);
            this.txt_InStock.Name = "txt_InStock";
            this.txt_InStock.ReadOnly = true;
            this.txt_InStock.Size = new System.Drawing.Size(103, 19);
            this.txt_InStock.TabIndex = 4;
            // 
            // lbl_InStock
            // 
            this.lbl_InStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_InStock.Location = new System.Drawing.Point(9, 52);
            this.lbl_InStock.Name = "lbl_InStock";
            this.lbl_InStock.Size = new System.Drawing.Size(110, 23);
            this.lbl_InStock.TabIndex = 3;
            this.lbl_InStock.Text = "InStock";
            this.lbl_InStock.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btn_OK
            // 
            this.btn_OK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_OK.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_OK.Location = new System.Drawing.Point(720, 10);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(62, 30);
            this.btn_OK.TabIndex = 5;
            this.btn_OK.Text = "OK";
            this.btn_OK.UseVisualStyleBackColor = false;
            // 
            // txt_ToSelect
            // 
            this.txt_ToSelect.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txt_ToSelect.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_ToSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_ToSelect.Location = new System.Drawing.Point(418, 51);
            this.txt_ToSelect.Name = "txt_ToSelect";
            this.txt_ToSelect.ReadOnly = true;
            this.txt_ToSelect.Size = new System.Drawing.Size(103, 19);
            this.txt_ToSelect.TabIndex = 7;
            // 
            // lbl_ToSelect
            // 
            this.lbl_ToSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_ToSelect.Location = new System.Drawing.Point(238, 52);
            this.lbl_ToSelect.Name = "lbl_ToSelect";
            this.lbl_ToSelect.Size = new System.Drawing.Size(174, 23);
            this.lbl_ToSelect.TabIndex = 6;
            this.lbl_ToSelect.Text = "To Select";
            this.lbl_ToSelect.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txt_Selected
            // 
            this.txt_Selected.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txt_Selected.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_Selected.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_Selected.Location = new System.Drawing.Point(734, 52);
            this.txt_Selected.Name = "txt_Selected";
            this.txt_Selected.ReadOnly = true;
            this.txt_Selected.Size = new System.Drawing.Size(103, 19);
            this.txt_Selected.TabIndex = 9;
            // 
            // lbl_Selected
            // 
            this.lbl_Selected.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_Selected.Location = new System.Drawing.Point(554, 51);
            this.lbl_Selected.Name = "lbl_Selected";
            this.lbl_Selected.Size = new System.Drawing.Size(174, 23);
            this.lbl_Selected.TabIndex = 8;
            this.lbl_Selected.Text = "Selected";
            this.lbl_Selected.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // usrc_Help1
            // 
            this.usrc_Help1.Location = new System.Drawing.Point(789, 11);
            this.usrc_Help1.Name = "usrc_Help1";
            this.usrc_Help1.Size = new System.Drawing.Size(48, 29);
            this.usrc_Help1.TabIndex = 10;
            // 
            // Form_Select_from_Stock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(846, 464);
            this.Controls.Add(this.usrc_Help1);
            this.Controls.Add(this.txt_Selected);
            this.Controls.Add(this.lbl_Selected);
            this.Controls.Add(this.txt_ToSelect);
            this.Controls.Add(this.lbl_ToSelect);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.txt_InStock);
            this.Controls.Add(this.lbl_InStock);
            this.Controls.Add(this.dgv_Stock);
            this.Controls.Add(this.txt_Item);
            this.Controls.Add(this.lbl_Item);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_Select_from_Stock";
            this.Text = "Select From Stock";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Stock)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_Item;
        private System.Windows.Forms.TextBox txt_Item;
        private System.Windows.Forms.DataGridView dgv_Stock;
        private System.Windows.Forms.TextBox txt_InStock;
        private System.Windows.Forms.Label lbl_InStock;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.TextBox txt_ToSelect;
        private System.Windows.Forms.Label lbl_ToSelect;
        private System.Windows.Forms.TextBox txt_Selected;
        private System.Windows.Forms.Label lbl_Selected;
        private HUDCMS.usrc_Help usrc_Help1;
    }
}