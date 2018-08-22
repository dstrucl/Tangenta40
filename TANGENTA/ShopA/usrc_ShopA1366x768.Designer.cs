namespace ShopA
{
    partial class usrc_ShopA1366x768
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
            this.usrc_Editor1366x768_1 = new ShopA.usrc_Editor1366x768();
            this.dgvx_ShopA = new DataGridView_2xls.DataGridView2xls();
            ((System.ComponentModel.ISupportInitialize)(this.dgvx_ShopA)).BeginInit();
            this.SuspendLayout();
            // 
            // usrc_Editor1366x768_1
            // 
            this.usrc_Editor1366x768_1.AutoScroll = true;
            this.usrc_Editor1366x768_1.BackColor = System.Drawing.SystemColors.Control;
            this.usrc_Editor1366x768_1.Location = new System.Drawing.Point(0, 0);
            this.usrc_Editor1366x768_1.Name = "usrc_Editor1366x768_1";
            this.usrc_Editor1366x768_1.Size = new System.Drawing.Size(1006, 80);
            this.usrc_Editor1366x768_1.TabIndex = 0;
            this.usrc_Editor1366x768_1.AddRow += new ShopA.usrc_Editor1366x768.delegate_AddRow(this.usrc_Editor1_AddRow);
            this.usrc_Editor1366x768_1.EditUnits += new ShopA.usrc_Editor1366x768.delegate_EditUnis(this.usrc_Editor1_EditUnits);
            // 
            // dgvx_ShopA
            // 
            this.dgvx_ShopA.AllowUserToAddRows = false;
            this.dgvx_ShopA.AllowUserToDeleteRows = false;
            this.dgvx_ShopA.AllowUserToOrderColumns = true;
            this.dgvx_ShopA.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvx_ShopA.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvx_ShopA.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvx_ShopA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvx_ShopA.DataGridViewWithRowNumber = false;
            this.dgvx_ShopA.Location = new System.Drawing.Point(0, 80);
            this.dgvx_ShopA.Name = "dgvx_ShopA";
            this.dgvx_ShopA.ReadOnly = true;
            this.dgvx_ShopA.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvx_ShopA.Size = new System.Drawing.Size(1006, 80);
            this.dgvx_ShopA.TabIndex = 0;
            this.dgvx_ShopA.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvx_ShopA_CellMouseUp);
            // 
            // usrc_ShopA1366x768
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.MistyRose;
            this.Controls.Add(this.usrc_Editor1366x768_1);
            this.Controls.Add(this.dgvx_ShopA);
            this.Name = "usrc_ShopA1366x768";
            this.Size = new System.Drawing.Size(1006, 160);
            this.Load += new System.EventHandler(this.usrc_ShopA1366x768_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvx_ShopA)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DataGridView_2xls.DataGridView2xls dgvx_ShopA;
        public usrc_Editor1366x768 usrc_Editor1366x768_1;
    }
}
