namespace DBConnectionControl40
{
    partial class Form_Backup_SQLite
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Backup_SQLite));
            this.cmbR_FilePath = new ComboBox_Recent.ComboBox_RecentList();
            this.btn_SelectFolder = new System.Windows.Forms.Button();
            this.lbl_Folder = new System.Windows.Forms.Label();
            this.lbl_FileName = new System.Windows.Forms.Label();
            this.txt_BackupFileName = new System.Windows.Forms.TextBox();
            this.btn_Save = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmbR_FilePath
            // 
            this.cmbR_FilePath.DisplayMember = "text";
            this.cmbR_FilePath.DisplayTime = true;
            this.cmbR_FilePath.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbR_FilePath.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cmbR_FilePath.FormattingEnabled = true;
            this.cmbR_FilePath.InsertOnKeyPress = true;
            this.cmbR_FilePath.Key = "Folder";
            this.cmbR_FilePath.Location = new System.Drawing.Point(25, 41);
            this.cmbR_FilePath.MaxRecentCount = 10;
            this.cmbR_FilePath.Name = "cmbR_FilePath";
            this.cmbR_FilePath.ReadOnly = false;
            this.cmbR_FilePath.RecentItemsFileName = "SQlite_LocalDB_FilePath.xml";
            this.cmbR_FilePath.RecentItemsFolder = "";
            this.cmbR_FilePath.Size = new System.Drawing.Size(578, 23);
            this.cmbR_FilePath.TabIndex = 14;
            // 
            // btn_SelectFolder
            // 
            this.btn_SelectFolder.Image = ((System.Drawing.Image)(resources.GetObject("btn_SelectFolder.Image")));
            this.btn_SelectFolder.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_SelectFolder.Location = new System.Drawing.Point(608, 39);
            this.btn_SelectFolder.Margin = new System.Windows.Forms.Padding(2);
            this.btn_SelectFolder.Name = "btn_SelectFolder";
            this.btn_SelectFolder.Size = new System.Drawing.Size(71, 29);
            this.btn_SelectFolder.TabIndex = 13;
            this.btn_SelectFolder.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_SelectFolder.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_SelectFolder.UseVisualStyleBackColor = true;
            this.btn_SelectFolder.Click += new System.EventHandler(this.btn_SelectFolder_Click);
            // 
            // lbl_Folder
            // 
            this.lbl_Folder.AutoSize = true;
            this.lbl_Folder.Location = new System.Drawing.Point(20, 15);
            this.lbl_Folder.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_Folder.Name = "lbl_Folder";
            this.lbl_Folder.Size = new System.Drawing.Size(76, 13);
            this.lbl_Folder.TabIndex = 12;
            this.lbl_Folder.Text = "Backup Folder";
            // 
            // lbl_FileName
            // 
            this.lbl_FileName.AutoSize = true;
            this.lbl_FileName.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_FileName.Location = new System.Drawing.Point(20, 87);
            this.lbl_FileName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_FileName.Name = "lbl_FileName";
            this.lbl_FileName.Size = new System.Drawing.Size(118, 16);
            this.lbl_FileName.TabIndex = 15;
            this.lbl_FileName.Text = "Backup FileName";
            // 
            // txt_BackupFileName
            // 
            this.txt_BackupFileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_BackupFileName.Location = new System.Drawing.Point(158, 81);
            this.txt_BackupFileName.Name = "txt_BackupFileName";
            this.txt_BackupFileName.Size = new System.Drawing.Size(445, 22);
            this.txt_BackupFileName.TabIndex = 16;
            // 
            // btn_Save
            // 
            this.btn_Save.Location = new System.Drawing.Point(17, 144);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(79, 31);
            this.btn_Save.TabIndex = 17;
            this.btn_Save.Text = "Save";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(158, 144);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(79, 31);
            this.btn_Cancel.TabIndex = 18;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // Form_Backup_SQLite
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 187);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.txt_BackupFileName);
            this.Controls.Add(this.lbl_FileName);
            this.Controls.Add(this.cmbR_FilePath);
            this.Controls.Add(this.btn_SelectFolder);
            this.Controls.Add(this.lbl_Folder);
            this.Name = "Form_Backup_SQLite";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Form_Backup_SQLite";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComboBox_Recent.ComboBox_RecentList cmbR_FilePath;
        private System.Windows.Forms.Button btn_SelectFolder;
        private System.Windows.Forms.Label lbl_Folder;
        private System.Windows.Forms.Label lbl_FileName;
        private System.Windows.Forms.TextBox txt_BackupFileName;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Button btn_Cancel;
    }
}