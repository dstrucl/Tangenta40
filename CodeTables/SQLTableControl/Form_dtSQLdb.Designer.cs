namespace CodeTables
{
    partial class Form_dtSQLdb
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_dtSQLdb));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgvx_dtSQLdb = new DataGridView_2xls.DataGridView2xls();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.fctxt_SQL_CreateTable = new FastColoredTextBoxNS.FastColoredTextBox();
            this.fctb_SQL_CreateVIEW = new FastColoredTextBoxNS.FastColoredTextBox();
            this.lbl_SQL_CrateTable = new System.Windows.Forms.Label();
            this.lbl_SQL_CreateVIEW = new System.Windows.Forms.Label();
            this.lbl_Info = new System.Windows.Forms.Label();
            this.btn_CopySQLCreateTable_ToClipboard = new System.Windows.Forms.Button();
            this.btn_CopySQLCreateVIew_ToClipboard = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvx_dtSQLdb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fctxt_SQL_CreateTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fctb_SQL_CreateVIEW)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.Bisque;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.SeaShell;
            this.splitContainer1.Panel1.Controls.Add(this.lbl_Info);
            this.splitContainer1.Panel1.Controls.Add(this.dgvx_dtSQLdb);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(783, 540);
            this.splitContainer1.SplitterDistance = 261;
            this.splitContainer1.SplitterWidth = 6;
            this.splitContainer1.TabIndex = 0;
            // 
            // dgvx_dtSQLdb
            // 
            this.dgvx_dtSQLdb.AllowUserToAddRows = false;
            this.dgvx_dtSQLdb.AllowUserToDeleteRows = false;
            this.dgvx_dtSQLdb.AllowUserToOrderColumns = true;
            this.dgvx_dtSQLdb.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvx_dtSQLdb.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvx_dtSQLdb.DataGridViewWithRowNumber = false;
            this.dgvx_dtSQLdb.Location = new System.Drawing.Point(3, 25);
            this.dgvx_dtSQLdb.MultiSelect = false;
            this.dgvx_dtSQLdb.Name = "dgvx_dtSQLdb";
            this.dgvx_dtSQLdb.ReadOnly = true;
            this.dgvx_dtSQLdb.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvx_dtSQLdb.Size = new System.Drawing.Size(777, 233);
            this.dgvx_dtSQLdb.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.BackColor = System.Drawing.Color.SeaShell;
            this.splitContainer2.Panel1.Controls.Add(this.btn_CopySQLCreateTable_ToClipboard);
            this.splitContainer2.Panel1.Controls.Add(this.lbl_SQL_CrateTable);
            this.splitContainer2.Panel1.Controls.Add(this.fctxt_SQL_CreateTable);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.BackColor = System.Drawing.Color.SeaShell;
            this.splitContainer2.Panel2.Controls.Add(this.btn_CopySQLCreateVIew_ToClipboard);
            this.splitContainer2.Panel2.Controls.Add(this.lbl_SQL_CreateVIEW);
            this.splitContainer2.Panel2.Controls.Add(this.fctb_SQL_CreateVIEW);
            this.splitContainer2.Size = new System.Drawing.Size(783, 273);
            this.splitContainer2.SplitterDistance = 392;
            this.splitContainer2.SplitterWidth = 6;
            this.splitContainer2.TabIndex = 0;
            // 
            // fctxt_SQL_CreateTable
            // 
            this.fctxt_SQL_CreateTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fctxt_SQL_CreateTable.AutoCompleteBracketsList = new char[] {
        '(',
        ')',
        '{',
        '}',
        '[',
        ']',
        '\"',
        '\"',
        '\'',
        '\''};
            this.fctxt_SQL_CreateTable.AutoScrollMinSize = new System.Drawing.Size(179, 14);
            this.fctxt_SQL_CreateTable.BackBrush = null;
            this.fctxt_SQL_CreateTable.CharHeight = 14;
            this.fctxt_SQL_CreateTable.CharWidth = 8;
            this.fctxt_SQL_CreateTable.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.fctxt_SQL_CreateTable.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.fctxt_SQL_CreateTable.Font = new System.Drawing.Font("Courier New", 9.75F);
            this.fctxt_SQL_CreateTable.IsReplaceMode = false;
            this.fctxt_SQL_CreateTable.Language = FastColoredTextBoxNS.Language.SQL;
            this.fctxt_SQL_CreateTable.Location = new System.Drawing.Point(3, 25);
            this.fctxt_SQL_CreateTable.Name = "fctxt_SQL_CreateTable";
            this.fctxt_SQL_CreateTable.Paddings = new System.Windows.Forms.Padding(0);
            this.fctxt_SQL_CreateTable.ReadOnly = true;
            this.fctxt_SQL_CreateTable.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.fctxt_SQL_CreateTable.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("fctxt_SQL_CreateTable.ServiceColors")));
            this.fctxt_SQL_CreateTable.Size = new System.Drawing.Size(386, 245);
            this.fctxt_SQL_CreateTable.TabIndex = 0;
            this.fctxt_SQL_CreateTable.Text = "fastColoredTextBox1";
            this.fctxt_SQL_CreateTable.Zoom = 100;
            // 
            // fctb_SQL_CreateVIEW
            // 
            this.fctb_SQL_CreateVIEW.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fctb_SQL_CreateVIEW.AutoCompleteBracketsList = new char[] {
        '(',
        ')',
        '{',
        '}',
        '[',
        ']',
        '\"',
        '\"',
        '\'',
        '\''};
            this.fctb_SQL_CreateVIEW.AutoScrollMinSize = new System.Drawing.Size(179, 14);
            this.fctb_SQL_CreateVIEW.BackBrush = null;
            this.fctb_SQL_CreateVIEW.CharHeight = 14;
            this.fctb_SQL_CreateVIEW.CharWidth = 8;
            this.fctb_SQL_CreateVIEW.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.fctb_SQL_CreateVIEW.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.fctb_SQL_CreateVIEW.IsReplaceMode = false;
            this.fctb_SQL_CreateVIEW.Language = FastColoredTextBoxNS.Language.SQL;
            this.fctb_SQL_CreateVIEW.Location = new System.Drawing.Point(3, 25);
            this.fctb_SQL_CreateVIEW.Name = "fctb_SQL_CreateVIEW";
            this.fctb_SQL_CreateVIEW.Paddings = new System.Windows.Forms.Padding(0);
            this.fctb_SQL_CreateVIEW.ReadOnly = true;
            this.fctb_SQL_CreateVIEW.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.fctb_SQL_CreateVIEW.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("fctb_SQL_CreateVIEW.ServiceColors")));
            this.fctb_SQL_CreateVIEW.Size = new System.Drawing.Size(379, 249);
            this.fctb_SQL_CreateVIEW.TabIndex = 1;
            this.fctb_SQL_CreateVIEW.Text = "fastColoredTextBox1";
            this.fctb_SQL_CreateVIEW.Zoom = 100;
            // 
            // lbl_SQL_CrateTable
            // 
            this.lbl_SQL_CrateTable.AutoSize = true;
            this.lbl_SQL_CrateTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_SQL_CrateTable.Location = new System.Drawing.Point(12, 5);
            this.lbl_SQL_CrateTable.Name = "lbl_SQL_CrateTable";
            this.lbl_SQL_CrateTable.Size = new System.Drawing.Size(130, 16);
            this.lbl_SQL_CrateTable.TabIndex = 1;
            this.lbl_SQL_CrateTable.Text = "lbl_SQL_CrateTable";
            // 
            // lbl_SQL_CreateVIEW
            // 
            this.lbl_SQL_CreateVIEW.AutoSize = true;
            this.lbl_SQL_CreateVIEW.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_SQL_CreateVIEW.Location = new System.Drawing.Point(15, 6);
            this.lbl_SQL_CreateVIEW.Name = "lbl_SQL_CreateVIEW";
            this.lbl_SQL_CreateVIEW.Size = new System.Drawing.Size(45, 16);
            this.lbl_SQL_CreateVIEW.TabIndex = 2;
            this.lbl_SQL_CreateVIEW.Text = "label1";
            // 
            // lbl_Info
            // 
            this.lbl_Info.AutoSize = true;
            this.lbl_Info.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_Info.Location = new System.Drawing.Point(3, 6);
            this.lbl_Info.Name = "lbl_Info";
            this.lbl_Info.Size = new System.Drawing.Size(50, 16);
            this.lbl_Info.TabIndex = 2;
            this.lbl_Info.Text = "lbl_Info";
            // 
            // btn_CopySQLCreateTable_ToClipboard
            // 
            this.btn_CopySQLCreateTable_ToClipboard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_CopySQLCreateTable_ToClipboard.Location = new System.Drawing.Point(333, 4);
            this.btn_CopySQLCreateTable_ToClipboard.Name = "btn_CopySQLCreateTable_ToClipboard";
            this.btn_CopySQLCreateTable_ToClipboard.Size = new System.Drawing.Size(55, 21);
            this.btn_CopySQLCreateTable_ToClipboard.TabIndex = 2;
            this.btn_CopySQLCreateTable_ToClipboard.Text = "Copy";
            this.btn_CopySQLCreateTable_ToClipboard.UseVisualStyleBackColor = true;
            this.btn_CopySQLCreateTable_ToClipboard.Click += new System.EventHandler(this.btn_CopySQLCreateTable_ToClipboard_Click);
            // 
            // btn_CopySQLCreateVIew_ToClipboard
            // 
            this.btn_CopySQLCreateVIew_ToClipboard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_CopySQLCreateVIew_ToClipboard.Location = new System.Drawing.Point(328, 1);
            this.btn_CopySQLCreateVIew_ToClipboard.Name = "btn_CopySQLCreateVIew_ToClipboard";
            this.btn_CopySQLCreateVIew_ToClipboard.Size = new System.Drawing.Size(55, 21);
            this.btn_CopySQLCreateVIew_ToClipboard.TabIndex = 3;
            this.btn_CopySQLCreateVIew_ToClipboard.Text = "Copy";
            this.btn_CopySQLCreateVIew_ToClipboard.UseVisualStyleBackColor = true;
            this.btn_CopySQLCreateVIew_ToClipboard.Click += new System.EventHandler(this.btn_CopySQLCreateVIew_ToClipboard_Click);
            // 
            // Form_dtSQLdb
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(783, 540);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_dtSQLdb";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form_dtSQLdb";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvx_dtSQLdb)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fctxt_SQL_CreateTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fctb_SQL_CreateVIEW)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private DataGridView_2xls.DataGridView2xls dgvx_dtSQLdb;
        private System.Windows.Forms.Label lbl_Info;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Label lbl_SQL_CrateTable;
        private FastColoredTextBoxNS.FastColoredTextBox fctxt_SQL_CreateTable;
        private System.Windows.Forms.Label lbl_SQL_CreateVIEW;
        private FastColoredTextBoxNS.FastColoredTextBox fctb_SQL_CreateVIEW;
        private System.Windows.Forms.Button btn_CopySQLCreateTable_ToClipboard;
        private System.Windows.Forms.Button btn_CopySQLCreateVIew_ToClipboard;
    }
}