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
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvx_ShopA)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
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
            this.splitContainer1.Size = new System.Drawing.Size(755, 549);
            this.splitContainer1.SplitterDistance = 157;
            this.splitContainer1.TabIndex = 0;
            // 
            // usrc_Editor1
            // 
            this.usrc_Editor1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.usrc_Editor1.Location = new System.Drawing.Point(0, 0);
            this.usrc_Editor1.Name = "usrc_Editor1";
            this.usrc_Editor1.Size = new System.Drawing.Size(755, 157);
            this.usrc_Editor1.TabIndex = 0;
            // 
            // dgvx_ShopA
            // 
            this.dgvx_ShopA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvx_ShopA.DataGridViewWithRowNumber = false;
            this.dgvx_ShopA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvx_ShopA.Location = new System.Drawing.Point(0, 0);
            this.dgvx_ShopA.Name = "dgvx_ShopA";
            this.dgvx_ShopA.Size = new System.Drawing.Size(755, 388);
            this.dgvx_ShopA.TabIndex = 0;
            // 
            // usrc_ShopA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "usrc_ShopA";
            this.Size = new System.Drawing.Size(755, 549);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvx_ShopA)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private usrc_Editor usrc_Editor1;
        private DataGridView_2xls.DataGridView2xls dgvx_ShopA;
    }
}
