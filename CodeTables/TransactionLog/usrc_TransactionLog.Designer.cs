namespace TransactionLog
{
    partial class usrc_TransactionLog
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(usrc_TransactionLog));
            this.lbl_TransactionName = new System.Windows.Forms.Label();
            this.txt_TransactionName = new System.Windows.Forms.TextBox();
            this.dgvx_TransactionLog = new DataGridView_2xls.DataGridView2xls();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.lbl_SQL_Command = new System.Windows.Forms.Label();
            this.tstxt_SQLCommand = new FastColoredTextBoxNS.FastColoredTextBox();
            this.dgvx_SQLCommand = new DataGridView_2xls.DataGridView2xls();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvx_TransactionLog)).BeginInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.tstxt_SQLCommand)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvx_SQLCommand)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_TransactionName
            // 
            this.lbl_TransactionName.AutoSize = true;
            this.lbl_TransactionName.Location = new System.Drawing.Point(5, 5);
            this.lbl_TransactionName.Name = "lbl_TransactionName";
            this.lbl_TransactionName.Size = new System.Drawing.Size(97, 13);
            this.lbl_TransactionName.TabIndex = 2;
            this.lbl_TransactionName.Text = "Transaction Name:";
            // 
            // txt_TransactionName
            // 
            this.txt_TransactionName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_TransactionName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_TransactionName.Location = new System.Drawing.Point(3, 22);
            this.txt_TransactionName.Name = "txt_TransactionName";
            this.txt_TransactionName.ReadOnly = true;
            this.txt_TransactionName.Size = new System.Drawing.Size(451, 22);
            this.txt_TransactionName.TabIndex = 1;
            // 
            // dgvx_TransactionLog
            // 
            this.dgvx_TransactionLog.AllowUserToAddRows = false;
            this.dgvx_TransactionLog.AllowUserToDeleteRows = false;
            this.dgvx_TransactionLog.AllowUserToOrderColumns = true;
            this.dgvx_TransactionLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvx_TransactionLog.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvx_TransactionLog.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvx_TransactionLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvx_TransactionLog.DataGridViewWithRowNumber = false;
            this.dgvx_TransactionLog.Location = new System.Drawing.Point(3, 48);
            this.dgvx_TransactionLog.MultiSelect = false;
            this.dgvx_TransactionLog.Name = "dgvx_TransactionLog";
            this.dgvx_TransactionLog.ReadOnly = true;
            this.dgvx_TransactionLog.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvx_TransactionLog.Size = new System.Drawing.Size(450, 465);
            this.dgvx_TransactionLog.TabIndex = 0;
            this.dgvx_TransactionLog.SelectionChanged += new System.EventHandler(this.dgvx_TransactionLog_SelectionChanged);
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.Salmon;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.splitContainer1.Panel1.Controls.Add(this.lbl_TransactionName);
            this.splitContainer1.Panel1.Controls.Add(this.txt_TransactionName);
            this.splitContainer1.Panel1.Controls.Add(this.dgvx_TransactionLog);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(844, 516);
            this.splitContainer1.SplitterDistance = 456;
            this.splitContainer1.SplitterWidth = 6;
            this.splitContainer1.TabIndex = 1;
            // 
            // splitContainer2
            // 
            this.splitContainer2.BackColor = System.Drawing.Color.SandyBrown;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer3);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.splitContainer2.Panel2.Controls.Add(this.panel1);
            this.splitContainer2.Size = new System.Drawing.Size(382, 516);
            this.splitContainer2.SplitterDistance = 235;
            this.splitContainer2.SplitterWidth = 6;
            this.splitContainer2.TabIndex = 4;
            // 
            // splitContainer3
            // 
            this.splitContainer3.BackColor = System.Drawing.Color.PowderBlue;
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.splitContainer3.Panel1.Controls.Add(this.lbl_SQL_Command);
            this.splitContainer3.Panel1.Controls.Add(this.tstxt_SQLCommand);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.splitContainer3.Panel2.Controls.Add(this.dgvx_SQLCommand);
            this.splitContainer3.Size = new System.Drawing.Size(235, 516);
            this.splitContainer3.SplitterDistance = 181;
            this.splitContainer3.SplitterWidth = 6;
            this.splitContainer3.TabIndex = 6;
            // 
            // lbl_SQL_Command
            // 
            this.lbl_SQL_Command.AutoSize = true;
            this.lbl_SQL_Command.Location = new System.Drawing.Point(7, 12);
            this.lbl_SQL_Command.Name = "lbl_SQL_Command";
            this.lbl_SQL_Command.Size = new System.Drawing.Size(80, 13);
            this.lbl_SQL_Command.TabIndex = 6;
            this.lbl_SQL_Command.Text = "SQL command:";
            // 
            // tstxt_SQLCommand
            // 
            this.tstxt_SQLCommand.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tstxt_SQLCommand.AutoCompleteBracketsList = new char[] {
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
            this.tstxt_SQLCommand.AutoIndentCharsPatterns = "";
            this.tstxt_SQLCommand.AutoScrollMinSize = new System.Drawing.Size(27, 14);
            this.tstxt_SQLCommand.BackBrush = null;
            this.tstxt_SQLCommand.CharHeight = 14;
            this.tstxt_SQLCommand.CharWidth = 8;
            this.tstxt_SQLCommand.CommentPrefix = "--";
            this.tstxt_SQLCommand.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tstxt_SQLCommand.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.tstxt_SQLCommand.Font = new System.Drawing.Font("Courier New", 9.75F);
            this.tstxt_SQLCommand.IsReplaceMode = false;
            this.tstxt_SQLCommand.Language = FastColoredTextBoxNS.Language.SQL;
            this.tstxt_SQLCommand.LeftBracket = '(';
            this.tstxt_SQLCommand.Location = new System.Drawing.Point(0, 35);
            this.tstxt_SQLCommand.Name = "tstxt_SQLCommand";
            this.tstxt_SQLCommand.Paddings = new System.Windows.Forms.Padding(0);
            this.tstxt_SQLCommand.ReadOnly = true;
            this.tstxt_SQLCommand.RightBracket = ')';
            this.tstxt_SQLCommand.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.tstxt_SQLCommand.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("tstxt_SQLCommand.ServiceColors")));
            this.tstxt_SQLCommand.Size = new System.Drawing.Size(232, 143);
            this.tstxt_SQLCommand.TabIndex = 5;
            this.tstxt_SQLCommand.Zoom = 100;
            // 
            // dgvx_SQLCommand
            // 
            this.dgvx_SQLCommand.AllowUserToAddRows = false;
            this.dgvx_SQLCommand.AllowUserToDeleteRows = false;
            this.dgvx_SQLCommand.AllowUserToOrderColumns = true;
            this.dgvx_SQLCommand.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvx_SQLCommand.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvx_SQLCommand.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvx_SQLCommand.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvx_SQLCommand.DataGridViewWithRowNumber = false;
            this.dgvx_SQLCommand.Location = new System.Drawing.Point(3, 3);
            this.dgvx_SQLCommand.MultiSelect = false;
            this.dgvx_SQLCommand.Name = "dgvx_SQLCommand";
            this.dgvx_SQLCommand.ReadOnly = true;
            this.dgvx_SQLCommand.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvx_SQLCommand.Size = new System.Drawing.Size(229, 317);
            this.dgvx_SQLCommand.TabIndex = 4;
            this.dgvx_SQLCommand.SelectionChanged += new System.EventHandler(this.dgvx_SQLCommand_SelectionChanged);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(141, 516);
            this.panel1.TabIndex = 0;
            // 
            // usrc_TransactionLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "usrc_TransactionLog";
            this.Size = new System.Drawing.Size(844, 516);
            ((System.ComponentModel.ISupportInitialize)(this.dgvx_TransactionLog)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel1.PerformLayout();
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tstxt_SQLCommand)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvx_SQLCommand)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_TransactionName;
        private System.Windows.Forms.TextBox txt_TransactionName;
        private DataGridView_2xls.DataGridView2xls dgvx_TransactionLog;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.Label lbl_SQL_Command;
        private FastColoredTextBoxNS.FastColoredTextBox tstxt_SQLCommand;
        private DataGridView_2xls.DataGridView2xls dgvx_SQLCommand;
        private System.Windows.Forms.Panel panel1;
    }
}
