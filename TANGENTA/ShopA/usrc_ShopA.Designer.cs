namespace ShopA
{
    partial class usrc_ShopA
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.usrc_Editor1 = new ShopA.usrc_Editor();
            this.dgvx_ShopA = new DataGridView_2xls.DataGridView2xls();
            this.lbl_ShopA_Name = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvx_ShopA)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.splitContainer1.Location = new System.Drawing.Point(0, 20);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.usrc_Editor1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvx_ShopA);
            this.splitContainer1.Size = new System.Drawing.Size(722, 529);
            this.splitContainer1.SplitterDistance = 175;
            this.splitContainer1.TabIndex = 0;
            // 
            // usrc_Editor1
            // 
            this.usrc_Editor1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.usrc_Editor1.AutoScroll = true;
            this.usrc_Editor1.BackColor = System.Drawing.SystemColors.Control;
            this.usrc_Editor1.Location = new System.Drawing.Point(0, 0);
            this.usrc_Editor1.Name = "usrc_Editor1";
            this.usrc_Editor1.Size = new System.Drawing.Size(722, 182);
            this.usrc_Editor1.TabIndex = 0;
            this.usrc_Editor1.AddRow += new ShopA.usrc_Editor.delegate_AddRow(this.usrc_Editor1_AddRow);
            this.usrc_Editor1.EditUnits += new ShopA.usrc_Editor.delegate_EditUnis(this.usrc_Editor1_EditUnits);
            // 
            // dgvx_ShopA
            // 
            this.dgvx_ShopA.AllowUserToAddRows = false;
            this.dgvx_ShopA.AllowUserToDeleteRows = false;
            this.dgvx_ShopA.AllowUserToOrderColumns = true;
            this.dgvx_ShopA.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvx_ShopA.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvx_ShopA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvx_ShopA.DataGridViewWithRowNumber = false;
            this.dgvx_ShopA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvx_ShopA.Location = new System.Drawing.Point(0, 0);
            this.dgvx_ShopA.Name = "dgvx_ShopA";
            this.dgvx_ShopA.ReadOnly = true;
            this.dgvx_ShopA.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvx_ShopA.Size = new System.Drawing.Size(722, 350);
            this.dgvx_ShopA.TabIndex = 0;
            this.dgvx_ShopA.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvx_ShopA_CellMouseUp);
            // 
            // lbl_ShopA_Name
            // 
            this.lbl_ShopA_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.lbl_ShopA_Name.Location = new System.Drawing.Point(3, 0);
            this.lbl_ShopA_Name.Name = "lbl_ShopA_Name";
            this.lbl_ShopA_Name.Size = new System.Drawing.Size(716, 19);
            this.lbl_ShopA_Name.TabIndex = 8;
            this.lbl_ShopA_Name.Text = "A";
            // 
            // usrc_ShopA
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.lbl_ShopA_Name);
            this.Controls.Add(this.splitContainer1);
            this.Name = "usrc_ShopA";
            this.Size = new System.Drawing.Size(722, 549);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvx_ShopA)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DataGridView_2xls.DataGridView2xls dgvx_ShopA;
        public usrc_Editor usrc_Editor1;
        internal System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label lbl_ShopA_Name;
    }
}
