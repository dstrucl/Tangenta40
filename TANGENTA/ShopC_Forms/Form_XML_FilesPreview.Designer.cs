namespace ShopC_Forms
{
    partial class Form_XML_FilesPreview
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.lbl_file_GLAVA = new System.Windows.Forms.Label();
            this.txt_GLAVA = new System.Windows.Forms.TextBox();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.lbl_file_POSTAVKE = new System.Windows.Forms.Label();
            this.txt_POSTAVKE = new System.Windows.Forms.TextBox();
            this.dgvx_Invoice = new DataGridView_2xls.DataGridView2xls();
            this.dgvx_Items = new DataGridView_2xls.DataGridView2xls();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvx_Invoice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvx_Items)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer1.Size = new System.Drawing.Size(859, 793);
            this.splitContainer1.SplitterDistance = 446;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.lbl_file_GLAVA);
            this.splitContainer2.Panel1.Controls.Add(this.txt_GLAVA);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.dgvx_Invoice);
            this.splitContainer2.Size = new System.Drawing.Size(446, 793);
            this.splitContainer2.SplitterDistance = 451;
            this.splitContainer2.TabIndex = 0;
            // 
            // lbl_file_GLAVA
            // 
            this.lbl_file_GLAVA.AutoSize = true;
            this.lbl_file_GLAVA.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_file_GLAVA.Location = new System.Drawing.Point(5, 9);
            this.lbl_file_GLAVA.Name = "lbl_file_GLAVA";
            this.lbl_file_GLAVA.Size = new System.Drawing.Size(51, 20);
            this.lbl_file_GLAVA.TabIndex = 3;
            this.lbl_file_GLAVA.Text = "label1";
            // 
            // txt_GLAVA
            // 
            this.txt_GLAVA.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_GLAVA.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_GLAVA.Location = new System.Drawing.Point(3, 41);
            this.txt_GLAVA.Multiline = true;
            this.txt_GLAVA.Name = "txt_GLAVA";
            this.txt_GLAVA.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_GLAVA.Size = new System.Drawing.Size(440, 407);
            this.txt_GLAVA.TabIndex = 2;
            this.txt_GLAVA.WordWrap = false;
            // 
            // splitContainer3
            // 
            this.splitContainer3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.lbl_file_POSTAVKE);
            this.splitContainer3.Panel1.Controls.Add(this.txt_POSTAVKE);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.dgvx_Items);
            this.splitContainer3.Size = new System.Drawing.Size(409, 793);
            this.splitContainer3.SplitterDistance = 453;
            this.splitContainer3.TabIndex = 0;
            // 
            // lbl_file_POSTAVKE
            // 
            this.lbl_file_POSTAVKE.AutoSize = true;
            this.lbl_file_POSTAVKE.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_file_POSTAVKE.Location = new System.Drawing.Point(13, 9);
            this.lbl_file_POSTAVKE.Name = "lbl_file_POSTAVKE";
            this.lbl_file_POSTAVKE.Size = new System.Drawing.Size(51, 20);
            this.lbl_file_POSTAVKE.TabIndex = 4;
            this.lbl_file_POSTAVKE.Text = "label1";
            // 
            // txt_POSTAVKE
            // 
            this.txt_POSTAVKE.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_POSTAVKE.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_POSTAVKE.Location = new System.Drawing.Point(3, 41);
            this.txt_POSTAVKE.Multiline = true;
            this.txt_POSTAVKE.Name = "txt_POSTAVKE";
            this.txt_POSTAVKE.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_POSTAVKE.Size = new System.Drawing.Size(403, 409);
            this.txt_POSTAVKE.TabIndex = 3;
            this.txt_POSTAVKE.WordWrap = false;
            // 
            // dgvx_Invoice
            // 
            this.dgvx_Invoice.AllowUserToAddRows = false;
            this.dgvx_Invoice.AllowUserToDeleteRows = false;
            this.dgvx_Invoice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvx_Invoice.DataGridViewWithRowNumber = false;
            this.dgvx_Invoice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvx_Invoice.Location = new System.Drawing.Point(0, 0);
            this.dgvx_Invoice.Name = "dgvx_Invoice";
            this.dgvx_Invoice.ReadOnly = true;
            this.dgvx_Invoice.Size = new System.Drawing.Size(446, 338);
            this.dgvx_Invoice.TabIndex = 0;
            // 
            // dgvx_Items
            // 
            this.dgvx_Items.AllowUserToAddRows = false;
            this.dgvx_Items.AllowUserToDeleteRows = false;
            this.dgvx_Items.AllowUserToOrderColumns = true;
            this.dgvx_Items.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvx_Items.DataGridViewWithRowNumber = false;
            this.dgvx_Items.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvx_Items.Location = new System.Drawing.Point(0, 0);
            this.dgvx_Items.Name = "dgvx_Items";
            this.dgvx_Items.ReadOnly = true;
            this.dgvx_Items.Size = new System.Drawing.Size(409, 336);
            this.dgvx_Items.TabIndex = 0;
            // 
            // Form_XML_FilesPreview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(859, 793);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form_XML_FilesPreview";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form_DURS_FilesPreview";
            this.Load += new System.EventHandler(this.Form_XML_FilesPreview_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel1.PerformLayout();
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvx_Invoice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvx_Items)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Label lbl_file_GLAVA;
        private System.Windows.Forms.TextBox txt_GLAVA;
        private DataGridView_2xls.DataGridView2xls dgvx_Invoice;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.Label lbl_file_POSTAVKE;
        private System.Windows.Forms.TextBox txt_POSTAVKE;
        private DataGridView_2xls.DataGridView2xls dgvx_Items;

    }
}