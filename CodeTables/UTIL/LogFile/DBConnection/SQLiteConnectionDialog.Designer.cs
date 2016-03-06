namespace LogFile
{
    partial class SQLiteConnectionDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SQLiteConnectionDialog));
            this.btn_OK = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.lbl_Folder = new System.Windows.Forms.Label();
            this.btn_SelectFolder = new System.Windows.Forms.Button();
            this.lbl_FileName = new System.Windows.Forms.Label();
            this.btn_SelectFile = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.cmbR_FilePath = new ComboBox_Recent.ComboBox_RecentList();
            this.cmbR_FileName = new ComboBox_Recent.ComboBox_RecentList();
            this.SuspendLayout();
            // 
            // btn_OK
            // 
            this.btn_OK.Location = new System.Drawing.Point(241, 155);
            this.btn_OK.Margin = new System.Windows.Forms.Padding(2);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(76, 20);
            this.btn_OK.TabIndex = 1;
            this.btn_OK.Text = "OK";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(348, 155);
            this.btn_Cancel.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(76, 20);
            this.btn_Cancel.TabIndex = 2;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // lbl_Folder
            // 
            this.lbl_Folder.AutoSize = true;
            this.lbl_Folder.Location = new System.Drawing.Point(8, 11);
            this.lbl_Folder.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_Folder.Name = "lbl_Folder";
            this.lbl_Folder.Size = new System.Drawing.Size(36, 13);
            this.lbl_Folder.TabIndex = 5;
            this.lbl_Folder.Text = "Folder";
            // 
            // btn_SelectFolder
            // 
            this.btn_SelectFolder.Image = ((System.Drawing.Image)(resources.GetObject("btn_SelectFolder.Image")));
            this.btn_SelectFolder.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_SelectFolder.Location = new System.Drawing.Point(376, 37);
            this.btn_SelectFolder.Margin = new System.Windows.Forms.Padding(2);
            this.btn_SelectFolder.Name = "btn_SelectFolder";
            this.btn_SelectFolder.Size = new System.Drawing.Size(165, 29);
            this.btn_SelectFolder.TabIndex = 7;
            this.btn_SelectFolder.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_SelectFolder.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_SelectFolder.UseVisualStyleBackColor = true;
            this.btn_SelectFolder.Click += new System.EventHandler(this.btn_SelectFolder_Click);
            // 
            // lbl_FileName
            // 
            this.lbl_FileName.AutoSize = true;
            this.lbl_FileName.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_FileName.Location = new System.Drawing.Point(8, 93);
            this.lbl_FileName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_FileName.Name = "lbl_FileName";
            this.lbl_FileName.Size = new System.Drawing.Size(67, 16);
            this.lbl_FileName.TabIndex = 9;
            this.lbl_FileName.Text = "FileName";
            // 
            // btn_SelectFile
            // 
            this.btn_SelectFile.Image = ((System.Drawing.Image)(resources.GetObject("btn_SelectFile.Image")));
            this.btn_SelectFile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_SelectFile.Location = new System.Drawing.Point(376, 86);
            this.btn_SelectFile.Margin = new System.Windows.Forms.Padding(2);
            this.btn_SelectFile.Name = "btn_SelectFile";
            this.btn_SelectFile.Size = new System.Drawing.Size(165, 29);
            this.btn_SelectFile.TabIndex = 10;
            this.btn_SelectFile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_SelectFile.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_SelectFile.UseVisualStyleBackColor = true;
            this.btn_SelectFile.Click += new System.EventHandler(this.btn_SelectFile_Click);
            // 
            // cmbR_FilePath
            // 
            this.cmbR_FilePath.DisplayMember = "text";
            this.cmbR_FilePath.DisplayTime = true;
            this.cmbR_FilePath.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbR_FilePath.FormattingEnabled = true;
            this.cmbR_FilePath.InsertOnKeyPress = true;
            this.cmbR_FilePath.Key = "Folder";
            this.cmbR_FilePath.Location = new System.Drawing.Point(13, 37);
            this.cmbR_FilePath.MaxRecentCount = 10;
            this.cmbR_FilePath.Name = "cmbR_FilePath";
            this.cmbR_FilePath.ReadOnly = false;
            this.cmbR_FilePath.RecentItemsFileName = "SQlite_LocalDB_FilePath.xml";
            this.cmbR_FilePath.Size = new System.Drawing.Size(352, 21);
            this.cmbR_FilePath.TabIndex = 11;
            // 
            // cmbR_FileName
            // 
            this.cmbR_FileName.DisplayMember = "text";
            this.cmbR_FileName.DisplayTime = true;
            this.cmbR_FileName.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbR_FileName.FormattingEnabled = true;
            this.cmbR_FileName.InsertOnKeyPress = true;
            this.cmbR_FileName.Key = "FileName";
            this.cmbR_FileName.Location = new System.Drawing.Point(148, 91);
            this.cmbR_FileName.MaxRecentCount = 10;
            this.cmbR_FileName.Name = "cmbR_FileName";
            this.cmbR_FileName.ReadOnly = false;
            this.cmbR_FileName.RecentItemsFileName = "SQLite_LocalDB_FileName.xml";
            this.cmbR_FileName.RecentItemsFolder = "";
            this.cmbR_FileName.Size = new System.Drawing.Size(217, 21);
            this.cmbR_FileName.TabIndex = 12;
            // 
            // SQLiteConnectionDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 201);
            this.Controls.Add(this.cmbR_FileName);
            this.Controls.Add(this.cmbR_FilePath);
            this.Controls.Add(this.btn_SelectFile);
            this.Controls.Add(this.lbl_FileName);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.btn_SelectFolder);
            this.Controls.Add(this.lbl_Folder);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "SQLiteConnectionDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SQLiteConnectionDialog";
            this.Load += new System.EventHandler(this.SQLiteConnectionDialog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Label lbl_Folder;
        private System.Windows.Forms.Button btn_SelectFolder;
        private System.Windows.Forms.Label lbl_FileName;
        private System.Windows.Forms.Button btn_SelectFile;
        private System.Windows.Forms.Timer timer1;
        private ComboBox_Recent.ComboBox_RecentList cmbR_FilePath;
        private ComboBox_Recent.ComboBox_RecentList cmbR_FileName;
    }
}