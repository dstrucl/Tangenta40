namespace ShopC_Forms
{
    partial class Form_Show_Documents_Where_stock_item_was_sold_or_reserved
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Show_Documents_Where_stock_item_was_sold_or_reserved));
            this.dgvx_Stock_Item_OnDocument = new DataGridView_2xls.DataGridView2xls();
            this.btn_Exit = new System.Windows.Forms.Button();
            this.usrc_Help1 = new HUDCMS.usrc_Help();
            ((System.ComponentModel.ISupportInitialize)(this.dgvx_Stock_Item_OnDocument)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvx_Stock_Item_OnDocument
            // 
            this.dgvx_Stock_Item_OnDocument.AllowUserToAddRows = false;
            this.dgvx_Stock_Item_OnDocument.AllowUserToDeleteRows = false;
            this.dgvx_Stock_Item_OnDocument.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvx_Stock_Item_OnDocument.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvx_Stock_Item_OnDocument.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvx_Stock_Item_OnDocument.DataGridViewWithRowNumber = false;
            this.dgvx_Stock_Item_OnDocument.Location = new System.Drawing.Point(5, 32);
            this.dgvx_Stock_Item_OnDocument.MultiSelect = false;
            this.dgvx_Stock_Item_OnDocument.Name = "dgvx_Stock_Item_OnDocument";
            this.dgvx_Stock_Item_OnDocument.ReadOnly = true;
            this.dgvx_Stock_Item_OnDocument.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvx_Stock_Item_OnDocument.Size = new System.Drawing.Size(597, 358);
            this.dgvx_Stock_Item_OnDocument.TabIndex = 0;
            // 
            // btn_Exit
            // 
            this.btn_Exit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Exit.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_Exit.Image = Properties.Resources.Exit;
            this.btn_Exit.Location = new System.Drawing.Point(468, 2);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(78, 25);
            this.btn_Exit.TabIndex = 1;
            this.btn_Exit.UseVisualStyleBackColor = false;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // usrc_Help1
            // 
            this.usrc_Help1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.usrc_Help1.Location = new System.Drawing.Point(553, 2);
            this.usrc_Help1.Name = "usrc_Help1";
            this.usrc_Help1.Size = new System.Drawing.Size(49, 25);
            this.usrc_Help1.TabIndex = 2;
            // 
            // Form_Show_Documents_Where_stock_item_was_sold_or_reserved
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 435);
            this.Controls.Add(this.usrc_Help1);
            this.Controls.Add(this.btn_Exit);
            this.Controls.Add(this.dgvx_Stock_Item_OnDocument);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_Show_Documents_Where_stock_item_was_sold_or_reserved";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form_Show_Documents_Where_stock_item_was_sold_or_reserved";
            this.Load += new System.EventHandler(this.Form_Show_Documents_Where_stock_item_was_sold_or_reserved_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvx_Stock_Item_OnDocument)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView_2xls.DataGridView2xls dgvx_Stock_Item_OnDocument;
        private System.Windows.Forms.Button btn_Exit;
        private HUDCMS.usrc_Help usrc_Help1;
    }
}