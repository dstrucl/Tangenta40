namespace LogFile
{
    partial class Log2DB_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Log2DB_Form));
            this.lbl_LogFile = new System.Windows.Forms.Label();
            this.btn_View = new System.Windows.Forms.Button();
            this.txtLogFile = new System.Windows.Forms.TextBox();
            this.txt_ConnectionString = new System.Windows.Forms.TextBox();
            this.lbl_ConnectionString = new System.Windows.Forms.Label();
            this.btn_Write2DB = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.lbl_LogFile_Lines = new System.Windows.Forms.Label();
            this.txt_NumberOfLines = new System.Windows.Forms.TextBox();
            this.txt_Description = new System.Windows.Forms.TextBox();
            this.lbl_Description = new System.Windows.Forms.Label();
            this.btn_Attachment = new System.Windows.Forms.Button();
            this.dgv_Attachments = new System.Windows.Forms.DataGridView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btn_LogFileDB_Analyzer = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Attachments)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_LogFile
            // 
            this.lbl_LogFile.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_LogFile.Location = new System.Drawing.Point(12, 11);
            this.lbl_LogFile.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_LogFile.Name = "lbl_LogFile";
            this.lbl_LogFile.Size = new System.Drawing.Size(82, 23);
            this.lbl_LogFile.TabIndex = 12;
            this.lbl_LogFile.Text = "Log File:";
            this.lbl_LogFile.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btn_View
            // 
            this.btn_View.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_View.Location = new System.Drawing.Point(676, 9);
            this.btn_View.Margin = new System.Windows.Forms.Padding(2);
            this.btn_View.Name = "btn_View";
            this.btn_View.Size = new System.Drawing.Size(190, 27);
            this.btn_View.TabIndex = 11;
            this.btn_View.Text = "View";
            this.btn_View.UseVisualStyleBackColor = true;
            this.btn_View.Click += new System.EventHandler(this.btn_View_Click);
            // 
            // txtLogFile
            // 
            this.txtLogFile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLogFile.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtLogFile.Location = new System.Drawing.Point(98, 11);
            this.txtLogFile.Margin = new System.Windows.Forms.Padding(2);
            this.txtLogFile.Name = "txtLogFile";
            this.txtLogFile.ReadOnly = true;
            this.txtLogFile.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.txtLogFile.Size = new System.Drawing.Size(560, 23);
            this.txtLogFile.TabIndex = 10;
            // 
            // txt_ConnectionString
            // 
            this.txt_ConnectionString.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_ConnectionString.Location = new System.Drawing.Point(283, 76);
            this.txt_ConnectionString.Name = "txt_ConnectionString";
            this.txt_ConnectionString.ReadOnly = true;
            this.txt_ConnectionString.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.txt_ConnectionString.Size = new System.Drawing.Size(581, 20);
            this.txt_ConnectionString.TabIndex = 14;
            // 
            // lbl_ConnectionString
            // 
            this.lbl_ConnectionString.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_ConnectionString.Location = new System.Drawing.Point(12, 77);
            this.lbl_ConnectionString.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_ConnectionString.Name = "lbl_ConnectionString";
            this.lbl_ConnectionString.Size = new System.Drawing.Size(267, 23);
            this.lbl_ConnectionString.TabIndex = 13;
            this.lbl_ConnectionString.Text = "DataBase Connection:";
            this.lbl_ConnectionString.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btn_Write2DB
            // 
            this.btn_Write2DB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Write2DB.Image = global::LogFile.Properties.Resources.ImportLogToDB;
            this.btn_Write2DB.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Write2DB.Location = new System.Drawing.Point(22, 389);
            this.btn_Write2DB.Name = "btn_Write2DB";
            this.btn_Write2DB.Size = new System.Drawing.Size(198, 24);
            this.btn_Write2DB.TabIndex = 15;
            this.btn_Write2DB.Text = "Write to DB";
            this.btn_Write2DB.UseVisualStyleBackColor = true;
            this.btn_Write2DB.Click += new System.EventHandler(this.btn_Write2DB_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Cancel.Location = new System.Drawing.Point(227, 389);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(65, 24);
            this.btn_Cancel.TabIndex = 16;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // lbl_LogFile_Lines
            // 
            this.lbl_LogFile_Lines.Location = new System.Drawing.Point(32, 44);
            this.lbl_LogFile_Lines.Name = "lbl_LogFile_Lines";
            this.lbl_LogFile_Lines.Size = new System.Drawing.Size(368, 27);
            this.lbl_LogFile_Lines.TabIndex = 17;
            this.lbl_LogFile_Lines.Text = "LogFile Number of Lines:";
            this.lbl_LogFile_Lines.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txt_NumberOfLines
            // 
            this.txt_NumberOfLines.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_NumberOfLines.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_NumberOfLines.Location = new System.Drawing.Point(400, 46);
            this.txt_NumberOfLines.Margin = new System.Windows.Forms.Padding(2);
            this.txt_NumberOfLines.Name = "txt_NumberOfLines";
            this.txt_NumberOfLines.ReadOnly = true;
            this.txt_NumberOfLines.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.txt_NumberOfLines.Size = new System.Drawing.Size(81, 23);
            this.txt_NumberOfLines.TabIndex = 18;
            this.txt_NumberOfLines.TextChanged += new System.EventHandler(this.txt_NumberOfLines_TextChanged);
            // 
            // txt_Description
            // 
            this.txt_Description.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Description.Location = new System.Drawing.Point(3, 31);
            this.txt_Description.Multiline = true;
            this.txt_Description.Name = "txt_Description";
            this.txt_Description.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_Description.Size = new System.Drawing.Size(420, 239);
            this.txt_Description.TabIndex = 19;
            // 
            // lbl_Description
            // 
            this.lbl_Description.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_Description.Location = new System.Drawing.Point(2, 11);
            this.lbl_Description.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_Description.Name = "lbl_Description";
            this.lbl_Description.Size = new System.Drawing.Size(82, 17);
            this.lbl_Description.TabIndex = 20;
            this.lbl_Description.Text = "Description:";
            this.lbl_Description.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // btn_Attachment
            // 
            this.btn_Attachment.Location = new System.Drawing.Point(4, 5);
            this.btn_Attachment.Name = "btn_Attachment";
            this.btn_Attachment.Size = new System.Drawing.Size(110, 23);
            this.btn_Attachment.TabIndex = 22;
            this.btn_Attachment.Text = "Add Attachment";
            this.btn_Attachment.UseVisualStyleBackColor = true;
            this.btn_Attachment.Click += new System.EventHandler(this.btn_Attachment_Click);
            // 
            // dgv_Attachments
            // 
            this.dgv_Attachments.AllowUserToAddRows = false;
            this.dgv_Attachments.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_Attachments.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv_Attachments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Attachments.Location = new System.Drawing.Point(4, 32);
            this.dgv_Attachments.Name = "dgv_Attachments";
            this.dgv_Attachments.RowTemplate.Height = 100;
            this.dgv_Attachments.Size = new System.Drawing.Size(402, 238);
            this.dgv_Attachments.TabIndex = 23;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Location = new System.Drawing.Point(18, 102);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgv_Attachments);
            this.splitContainer1.Panel1.Controls.Add(this.btn_Attachment);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.txt_Description);
            this.splitContainer1.Panel2.Controls.Add(this.lbl_Description);
            this.splitContainer1.Size = new System.Drawing.Size(848, 278);
            this.splitContainer1.SplitterDistance = 413;
            this.splitContainer1.TabIndex = 24;
            // 
            // btn_LogFileDB_Analyzer
            // 
            this.btn_LogFileDB_Analyzer.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_LogFileDB_Analyzer.Image = global::LogFile.Properties.Resources.ImportLogToDB_Analyzer;
            this.btn_LogFileDB_Analyzer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_LogFileDB_Analyzer.Location = new System.Drawing.Point(676, 42);
            this.btn_LogFileDB_Analyzer.Margin = new System.Windows.Forms.Padding(2);
            this.btn_LogFileDB_Analyzer.Name = "btn_LogFileDB_Analyzer";
            this.btn_LogFileDB_Analyzer.Size = new System.Drawing.Size(190, 27);
            this.btn_LogFileDB_Analyzer.TabIndex = 25;
            this.btn_LogFileDB_Analyzer.Text = "LogFile DB Analyzer";
            this.btn_LogFileDB_Analyzer.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_LogFileDB_Analyzer.UseVisualStyleBackColor = true;
            this.btn_LogFileDB_Analyzer.Click += new System.EventHandler(this.btn_LogFileDB_Analyzer_Click);
            // 
            // Log2DB_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(874, 416);
            this.Controls.Add(this.btn_LogFileDB_Analyzer);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.txt_NumberOfLines);
            this.Controls.Add(this.lbl_LogFile_Lines);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_Write2DB);
            this.Controls.Add(this.txt_ConnectionString);
            this.Controls.Add(this.lbl_ConnectionString);
            this.Controls.Add(this.lbl_LogFile);
            this.Controls.Add(this.btn_View);
            this.Controls.Add(this.txtLogFile);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Log2DB_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Log2DB_Form";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Attachments)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_LogFile;
        private System.Windows.Forms.Button btn_View;
        private System.Windows.Forms.TextBox txtLogFile;
        private System.Windows.Forms.TextBox txt_ConnectionString;
        private System.Windows.Forms.Label lbl_ConnectionString;
        private System.Windows.Forms.Button btn_Write2DB;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Label lbl_LogFile_Lines;
        private System.Windows.Forms.TextBox txt_NumberOfLines;
        private System.Windows.Forms.TextBox txt_Description;
        private System.Windows.Forms.Label lbl_Description;
        private System.Windows.Forms.Button btn_Attachment;
        private System.Windows.Forms.DataGridView dgv_Attachments;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btn_LogFileDB_Analyzer;
    }
}