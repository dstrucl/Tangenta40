namespace LogFile
{
    partial class LogFileAnalyzer_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogFileAnalyzer_Form));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.lbl_Program = new System.Windows.Forms.Label();
            this.dgv_Program = new System.Windows.Forms.DataGridView();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.dgv_Computer = new System.Windows.Forms.DataGridView();
            this.lbl_Computer = new System.Windows.Forms.Label();
            this.dgv_UserName = new System.Windows.Forms.DataGridView();
            this.lbl_UserName = new System.Windows.Forms.Label();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer5 = new System.Windows.Forms.SplitContainer();
            this.dgv_LogFile = new System.Windows.Forms.DataGridView();
            this.lbl_LogFile = new System.Windows.Forms.Label();
            this.lbl_LogFile_Attachment = new System.Windows.Forms.Label();
            this.dgv_LogFile_Attachment = new System.Windows.Forms.DataGridView();
            this.lbl_Log = new System.Windows.Forms.Label();
            this.dgv_Log = new System.Windows.Forms.DataGridView();
            this.nmUpDn_Limit = new System.Windows.Forms.NumericUpDown();
            this.lbl_Limit = new System.Windows.Forms.Label();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Program)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Computer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_UserName)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.splitContainer5.Panel1.SuspendLayout();
            this.splitContainer5.Panel2.SuspendLayout();
            this.splitContainer5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_LogFile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_LogFile_Attachment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Log)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmUpDn_Limit)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Location = new System.Drawing.Point(0, 58);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer3);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(832, 506);
            this.splitContainer1.SplitterDistance = 277;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer3
            // 
            this.splitContainer3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.lbl_Program);
            this.splitContainer3.Panel1.Controls.Add(this.dgv_Program);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.splitContainer4);
            this.splitContainer3.Size = new System.Drawing.Size(277, 506);
            this.splitContainer3.SplitterDistance = 144;
            this.splitContainer3.TabIndex = 0;
            // 
            // lbl_Program
            // 
            this.lbl_Program.AutoSize = true;
            this.lbl_Program.Location = new System.Drawing.Point(4, 4);
            this.lbl_Program.Name = "lbl_Program";
            this.lbl_Program.Size = new System.Drawing.Size(46, 13);
            this.lbl_Program.TabIndex = 1;
            this.lbl_Program.Text = "Program";
            // 
            // dgv_Program
            // 
            this.dgv_Program.AllowUserToAddRows = false;
            this.dgv_Program.AllowUserToDeleteRows = false;
            this.dgv_Program.AllowUserToOrderColumns = true;
            this.dgv_Program.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_Program.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv_Program.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgv_Program.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Program.Location = new System.Drawing.Point(3, 28);
            this.dgv_Program.Name = "dgv_Program";
            this.dgv_Program.ReadOnly = true;
            this.dgv_Program.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Program.Size = new System.Drawing.Size(267, 107);
            this.dgv_Program.TabIndex = 0;
            this.dgv_Program.SelectionChanged += new System.EventHandler(this.dgv_Program_SelectionChanged);
            // 
            // splitContainer4
            // 
            this.splitContainer4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            this.splitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.dgv_Computer);
            this.splitContainer4.Panel1.Controls.Add(this.lbl_Computer);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.dgv_UserName);
            this.splitContainer4.Panel2.Controls.Add(this.lbl_UserName);
            this.splitContainer4.Size = new System.Drawing.Size(277, 358);
            this.splitContainer4.SplitterDistance = 166;
            this.splitContainer4.TabIndex = 0;
            // 
            // dgv_Computer
            // 
            this.dgv_Computer.AllowUserToAddRows = false;
            this.dgv_Computer.AllowUserToDeleteRows = false;
            this.dgv_Computer.AllowUserToOrderColumns = true;
            this.dgv_Computer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_Computer.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv_Computer.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgv_Computer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Computer.Location = new System.Drawing.Point(3, 20);
            this.dgv_Computer.Name = "dgv_Computer";
            this.dgv_Computer.ReadOnly = true;
            this.dgv_Computer.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Computer.Size = new System.Drawing.Size(267, 136);
            this.dgv_Computer.TabIndex = 2;
            this.dgv_Computer.SelectionChanged += new System.EventHandler(this.dgv_Computer_SelectionChanged);
            // 
            // lbl_Computer
            // 
            this.lbl_Computer.AutoSize = true;
            this.lbl_Computer.Location = new System.Drawing.Point(5, 4);
            this.lbl_Computer.Name = "lbl_Computer";
            this.lbl_Computer.Size = new System.Drawing.Size(52, 13);
            this.lbl_Computer.TabIndex = 0;
            this.lbl_Computer.Text = "Computer";
            // 
            // dgv_UserName
            // 
            this.dgv_UserName.AllowUserToAddRows = false;
            this.dgv_UserName.AllowUserToDeleteRows = false;
            this.dgv_UserName.AllowUserToOrderColumns = true;
            this.dgv_UserName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_UserName.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv_UserName.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgv_UserName.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_UserName.Location = new System.Drawing.Point(4, 20);
            this.dgv_UserName.Name = "dgv_UserName";
            this.dgv_UserName.ReadOnly = true;
            this.dgv_UserName.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_UserName.Size = new System.Drawing.Size(267, 160);
            this.dgv_UserName.TabIndex = 3;
            this.dgv_UserName.SelectionChanged += new System.EventHandler(this.dgv_UserName_SelectionChanged);
            // 
            // lbl_UserName
            // 
            this.lbl_UserName.AutoSize = true;
            this.lbl_UserName.Location = new System.Drawing.Point(4, 4);
            this.lbl_UserName.Name = "lbl_UserName";
            this.lbl_UserName.Size = new System.Drawing.Size(57, 13);
            this.lbl_UserName.TabIndex = 0;
            this.lbl_UserName.Text = "UserName";
            // 
            // splitContainer2
            // 
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer5);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.lbl_Log);
            this.splitContainer2.Panel2.Controls.Add(this.dgv_Log);
            this.splitContainer2.Size = new System.Drawing.Size(551, 506);
            this.splitContainer2.SplitterDistance = 206;
            this.splitContainer2.TabIndex = 0;
            // 
            // splitContainer5
            // 
            this.splitContainer5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer5.Location = new System.Drawing.Point(0, 0);
            this.splitContainer5.Name = "splitContainer5";
            // 
            // splitContainer5.Panel1
            // 
            this.splitContainer5.Panel1.Controls.Add(this.dgv_LogFile);
            this.splitContainer5.Panel1.Controls.Add(this.lbl_LogFile);
            // 
            // splitContainer5.Panel2
            // 
            this.splitContainer5.Panel2.Controls.Add(this.lbl_LogFile_Attachment);
            this.splitContainer5.Panel2.Controls.Add(this.dgv_LogFile_Attachment);
            this.splitContainer5.Size = new System.Drawing.Size(551, 206);
            this.splitContainer5.SplitterDistance = 330;
            this.splitContainer5.TabIndex = 3;
            // 
            // dgv_LogFile
            // 
            this.dgv_LogFile.AllowUserToAddRows = false;
            this.dgv_LogFile.AllowUserToDeleteRows = false;
            this.dgv_LogFile.AllowUserToOrderColumns = true;
            this.dgv_LogFile.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_LogFile.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv_LogFile.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgv_LogFile.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_LogFile.Location = new System.Drawing.Point(6, 28);
            this.dgv_LogFile.Name = "dgv_LogFile";
            this.dgv_LogFile.ReadOnly = true;
            this.dgv_LogFile.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_LogFile.Size = new System.Drawing.Size(317, 171);
            this.dgv_LogFile.TabIndex = 3;
            this.dgv_LogFile.SelectionChanged += new System.EventHandler(this.dgv_LogFile_SelectionChanged);
            // 
            // lbl_LogFile
            // 
            this.lbl_LogFile.AutoSize = true;
            this.lbl_LogFile.Location = new System.Drawing.Point(3, 4);
            this.lbl_LogFile.Name = "lbl_LogFile";
            this.lbl_LogFile.Size = new System.Drawing.Size(41, 13);
            this.lbl_LogFile.TabIndex = 2;
            this.lbl_LogFile.Text = "LogFile";
            // 
            // lbl_LogFile_Attachment
            // 
            this.lbl_LogFile_Attachment.AutoSize = true;
            this.lbl_LogFile_Attachment.Location = new System.Drawing.Point(3, 4);
            this.lbl_LogFile_Attachment.Name = "lbl_LogFile_Attachment";
            this.lbl_LogFile_Attachment.Size = new System.Drawing.Size(61, 13);
            this.lbl_LogFile_Attachment.TabIndex = 4;
            this.lbl_LogFile_Attachment.Text = "Attachment";
            // 
            // dgv_LogFile_Attachment
            // 
            this.dgv_LogFile_Attachment.AllowUserToAddRows = false;
            this.dgv_LogFile_Attachment.AllowUserToDeleteRows = false;
            this.dgv_LogFile_Attachment.AllowUserToOrderColumns = true;
            this.dgv_LogFile_Attachment.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_LogFile_Attachment.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv_LogFile_Attachment.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgv_LogFile_Attachment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_LogFile_Attachment.Location = new System.Drawing.Point(3, 28);
            this.dgv_LogFile_Attachment.Name = "dgv_LogFile_Attachment";
            this.dgv_LogFile_Attachment.ReadOnly = true;
            this.dgv_LogFile_Attachment.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_LogFile_Attachment.Size = new System.Drawing.Size(207, 171);
            this.dgv_LogFile_Attachment.TabIndex = 3;
            this.dgv_LogFile_Attachment.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_LogFile_Attachment_CellClick);
            // 
            // lbl_Log
            // 
            this.lbl_Log.AutoSize = true;
            this.lbl_Log.Location = new System.Drawing.Point(3, 6);
            this.lbl_Log.Name = "lbl_Log";
            this.lbl_Log.Size = new System.Drawing.Size(25, 13);
            this.lbl_Log.TabIndex = 4;
            this.lbl_Log.Text = "Log";
            // 
            // dgv_Log
            // 
            this.dgv_Log.AllowUserToAddRows = false;
            this.dgv_Log.AllowUserToDeleteRows = false;
            this.dgv_Log.AllowUserToOrderColumns = true;
            this.dgv_Log.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_Log.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv_Log.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgv_Log.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Log.Location = new System.Drawing.Point(3, 22);
            this.dgv_Log.Name = "dgv_Log";
            this.dgv_Log.ReadOnly = true;
            this.dgv_Log.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Log.Size = new System.Drawing.Size(541, 265);
            this.dgv_Log.TabIndex = 3;
            // 
            // nmUpDn_Limit
            // 
            this.nmUpDn_Limit.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nmUpDn_Limit.Location = new System.Drawing.Point(59, 20);
            this.nmUpDn_Limit.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.nmUpDn_Limit.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.nmUpDn_Limit.Name = "nmUpDn_Limit";
            this.nmUpDn_Limit.Size = new System.Drawing.Size(100, 20);
            this.nmUpDn_Limit.TabIndex = 1;
            this.nmUpDn_Limit.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // lbl_Limit
            // 
            this.lbl_Limit.AutoSize = true;
            this.lbl_Limit.Location = new System.Drawing.Point(6, 22);
            this.lbl_Limit.Name = "lbl_Limit";
            this.lbl_Limit.Size = new System.Drawing.Size(28, 13);
            this.lbl_Limit.TabIndex = 2;
            this.lbl_Limit.Text = "Limit";
            // 
            // LogFileAnalyzer_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 564);
            this.Controls.Add(this.lbl_Limit);
            this.Controls.Add(this.nmUpDn_Limit);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LogFileAnalyzer_Form";
            this.Text = "LogFileAnalyzer_Form";
            this.Load += new System.EventHandler(this.LogFileAnalyzer_Form_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel1.PerformLayout();
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Program)).EndInit();
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel1.PerformLayout();
            this.splitContainer4.Panel2.ResumeLayout(false);
            this.splitContainer4.Panel2.PerformLayout();
            this.splitContainer4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Computer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_UserName)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer5.Panel1.ResumeLayout(false);
            this.splitContainer5.Panel1.PerformLayout();
            this.splitContainer5.Panel2.ResumeLayout(false);
            this.splitContainer5.Panel2.PerformLayout();
            this.splitContainer5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_LogFile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_LogFile_Attachment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Log)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmUpDn_Limit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Label lbl_Program;
        private System.Windows.Forms.DataGridView dgv_Program;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.DataGridView dgv_Computer;
        private System.Windows.Forms.Label lbl_Computer;
        private System.Windows.Forms.DataGridView dgv_UserName;
        private System.Windows.Forms.Label lbl_UserName;
        private System.Windows.Forms.SplitContainer splitContainer5;
        private System.Windows.Forms.Label lbl_LogFile;
        private System.Windows.Forms.DataGridView dgv_LogFile;
        private System.Windows.Forms.Label lbl_LogFile_Attachment;
        private System.Windows.Forms.DataGridView dgv_LogFile_Attachment;
        private System.Windows.Forms.Label lbl_Log;
        private System.Windows.Forms.DataGridView dgv_Log;
        private System.Windows.Forms.NumericUpDown nmUpDn_Limit;
        private System.Windows.Forms.Label lbl_Limit;
    }
}