namespace SQLTableControl
{
    partial class usrc_RowReferencedFromTable
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
            this.lbl_TableName = new System.Windows.Forms.Label();
            this.txt_TableName = new System.Windows.Forms.TextBox();
            this.lbl_ReferencedTableRow = new System.Windows.Forms.Label();
            this.txt_ReferencedTableRow = new System.Windows.Forms.TextBox();
            this.dgvx_References = new DataGridView_2xls.DataGridView2xls();
            ((System.ComponentModel.ISupportInitialize)(this.dgvx_References)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_TableName
            // 
            this.lbl_TableName.Location = new System.Drawing.Point(3, 5);
            this.lbl_TableName.Name = "lbl_TableName";
            this.lbl_TableName.Size = new System.Drawing.Size(95, 13);
            this.lbl_TableName.TabIndex = 1;
            this.lbl_TableName.Text = "Table Name:";
            this.lbl_TableName.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txt_TableName
            // 
            this.txt_TableName.Location = new System.Drawing.Point(102, 1);
            this.txt_TableName.Name = "txt_TableName";
            this.txt_TableName.ReadOnly = true;
            this.txt_TableName.Size = new System.Drawing.Size(164, 20);
            this.txt_TableName.TabIndex = 2;
            // 
            // lbl_ReferencedTableRow
            // 
            this.lbl_ReferencedTableRow.Location = new System.Drawing.Point(272, 5);
            this.lbl_ReferencedTableRow.Name = "lbl_ReferencedTableRow";
            this.lbl_ReferencedTableRow.Size = new System.Drawing.Size(148, 13);
            this.lbl_ReferencedTableRow.TabIndex = 3;
            this.lbl_ReferencedTableRow.Text = "Referenced Table Row:";
            this.lbl_ReferencedTableRow.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txt_ReferencedTableRow
            // 
            this.txt_ReferencedTableRow.Location = new System.Drawing.Point(419, 0);
            this.txt_ReferencedTableRow.Name = "txt_ReferencedTableRow";
            this.txt_ReferencedTableRow.ReadOnly = true;
            this.txt_ReferencedTableRow.Size = new System.Drawing.Size(238, 20);
            this.txt_ReferencedTableRow.TabIndex = 4;
            // 
            // dgvx_References
            // 
            this.dgvx_References.AllowUserToAddRows = false;
            this.dgvx_References.AllowUserToDeleteRows = false;
            this.dgvx_References.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvx_References.DataGridViewWithRowNumber = false;
            this.dgvx_References.Location = new System.Drawing.Point(4, 21);
            this.dgvx_References.Name = "dgvx_References";
            this.dgvx_References.ReadOnly = true;
            this.dgvx_References.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvx_References.Size = new System.Drawing.Size(655, 172);
            this.dgvx_References.TabIndex = 5;
            // 
            // usrc_RowReferencedFromTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txt_ReferencedTableRow);
            this.Controls.Add(this.lbl_ReferencedTableRow);
            this.Controls.Add(this.txt_TableName);
            this.Controls.Add(this.lbl_TableName);
            this.Controls.Add(this.dgvx_References);
            this.Name = "usrc_RowReferencedFromTable";
            this.Size = new System.Drawing.Size(664, 196);
            ((System.ComponentModel.ISupportInitialize)(this.dgvx_References)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridView_2xls.DataGridView2xls dgvx_References;
        private System.Windows.Forms.Label lbl_TableName;
        private System.Windows.Forms.TextBox txt_TableName;
        private System.Windows.Forms.Label lbl_ReferencedTableRow;
        private System.Windows.Forms.TextBox txt_ReferencedTableRow;
    }
}
