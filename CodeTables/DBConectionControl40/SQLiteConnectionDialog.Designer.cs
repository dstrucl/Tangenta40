namespace DBConnectionControl40
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
            ComboBox_Recent.myIteM myIteM4 = new ComboBox_Recent.myIteM();
            ComboBox_Recent.myIteM myIteM1 = new ComboBox_Recent.myIteM();
            ComboBox_Recent.myIteM myIteM5 = new ComboBox_Recent.myIteM();
            this.lbl_Folder = new System.Windows.Forms.Label();
            this.btn_SelectFolder = new System.Windows.Forms.Button();
            this.lbl_FileName = new System.Windows.Forms.Label();
            this.btn_SelectFile = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.cmbR_FilePath = new ComboBox_Recent.ComboBox_RecentList();
            this.cmbR_FileName = new ComboBox_Recent.ComboBox_RecentList();
            this.btn_SQLiteInfo = new System.Windows.Forms.Button();
            this.btn_Backup = new System.Windows.Forms.Button();
            this.usrc_NavigationButtons1 = new NavigationButtons.usrc_NavigationButtons();
            this.SuspendLayout();
            // 
            // lbl_Folder
            // 
            this.lbl_Folder.AutoSize = true;
            this.lbl_Folder.Location = new System.Drawing.Point(8, 35);
            this.lbl_Folder.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_Folder.Name = "lbl_Folder";
            this.lbl_Folder.Size = new System.Drawing.Size(36, 13);
            this.lbl_Folder.TabIndex = 5;
            this.lbl_Folder.Text = "Folder";
            this.lbl_Folder.Click += new System.EventHandler(this.lbl_Folder_Click);
            // 
            // btn_SelectFolder
            // 
            this.btn_SelectFolder.Image = ((System.Drawing.Image)(resources.GetObject("btn_SelectFolder.Image")));
            this.btn_SelectFolder.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_SelectFolder.Location = new System.Drawing.Point(440, 47);
            this.btn_SelectFolder.Margin = new System.Windows.Forms.Padding(2);
            this.btn_SelectFolder.Name = "btn_SelectFolder";
            this.btn_SelectFolder.Size = new System.Drawing.Size(123, 34);
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
            this.lbl_FileName.Location = new System.Drawing.Point(11, 96);
            this.lbl_FileName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_FileName.Name = "lbl_FileName";
            this.lbl_FileName.Size = new System.Drawing.Size(67, 16);
            this.lbl_FileName.TabIndex = 9;
            this.lbl_FileName.Text = "FileName";
            this.lbl_FileName.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btn_SelectFile
            // 
            this.btn_SelectFile.Image = ((System.Drawing.Image)(resources.GetObject("btn_SelectFile.Image")));
            this.btn_SelectFile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_SelectFile.Location = new System.Drawing.Point(440, 107);
            this.btn_SelectFile.Margin = new System.Windows.Forms.Padding(2);
            this.btn_SelectFile.Name = "btn_SelectFile";
            this.btn_SelectFile.Size = new System.Drawing.Size(123, 34);
            this.btn_SelectFile.TabIndex = 10;
            this.btn_SelectFile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_SelectFile.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_SelectFile.UseVisualStyleBackColor = true;
            this.btn_SelectFile.Click += new System.EventHandler(this.btn_SelectFile_Click);
            // 
            // cmbR_FilePath
            // 
            this.cmbR_FilePath.AskToCreateRecentItemsFolder = false;
            this.cmbR_FilePath.DisplayMember = "text";
            this.cmbR_FilePath.DisplayTime = true;
            this.cmbR_FilePath.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbR_FilePath.FormattingEnabled = true;
            this.cmbR_FilePath.InsertOnKeyPress = true;
            this.cmbR_FilePath.Items.AddRange(new object[] {
            myIteM4});
            this.cmbR_FilePath.Key = "Folder";
            this.cmbR_FilePath.Location = new System.Drawing.Point(13, 51);
            this.cmbR_FilePath.MaxRecentCount = 10;
            this.cmbR_FilePath.Name = "cmbR_FilePath";
            this.cmbR_FilePath.ReadOnly = false;
            this.cmbR_FilePath.RecentItemsFileName = "SQlite_LocalDB_FilePath.xml";
            this.cmbR_FilePath.RecentItemsFolder = "C:\\Users\\Damjan\\AppData\\Roaming\\RecentComboBoxItems";
            this.cmbR_FilePath.Size = new System.Drawing.Size(423, 21);
            this.cmbR_FilePath.TabIndex = 11;
            this.cmbR_FilePath.SelectedIndexChanged += new System.EventHandler(this.cmbR_FilePath_SelectedIndexChanged);
            // 
            // cmbR_FileName
            // 
            this.cmbR_FileName.AskToCreateRecentItemsFolder = false;
            this.cmbR_FileName.DisplayMember = "text";
            this.cmbR_FileName.DisplayTime = true;
            this.cmbR_FileName.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbR_FileName.FormattingEnabled = true;
            this.cmbR_FileName.InsertOnKeyPress = true;
            this.cmbR_FileName.Items.AddRange(new object[] {
            myIteM1,
            myIteM5});
            this.cmbR_FileName.Key = "FileName";
            this.cmbR_FileName.Location = new System.Drawing.Point(14, 115);
            this.cmbR_FileName.MaxRecentCount = 10;
            this.cmbR_FileName.Name = "cmbR_FileName";
            this.cmbR_FileName.ReadOnly = false;
            this.cmbR_FileName.RecentItemsFileName = "SQLite_LocalDB_FileName.xml";
            this.cmbR_FileName.RecentItemsFolder = "C:\\Users\\Damjan\\AppData\\Roaming\\RecentComboBoxItems";
            this.cmbR_FileName.Size = new System.Drawing.Size(421, 21);
            this.cmbR_FileName.TabIndex = 12;
            // 
            // btn_SQLiteInfo
            // 
            this.btn_SQLiteInfo.Location = new System.Drawing.Point(128, 152);
            this.btn_SQLiteInfo.Name = "btn_SQLiteInfo";
            this.btn_SQLiteInfo.Size = new System.Drawing.Size(86, 29);
            this.btn_SQLiteInfo.TabIndex = 13;
            this.btn_SQLiteInfo.Text = "SQLite Info";
            this.btn_SQLiteInfo.UseVisualStyleBackColor = true;
            this.btn_SQLiteInfo.Click += new System.EventHandler(this.btn_SQLiteInfo_Click);
            // 
            // btn_Backup
            // 
            this.btn_Backup.Location = new System.Drawing.Point(12, 152);
            this.btn_Backup.Name = "btn_Backup";
            this.btn_Backup.Size = new System.Drawing.Size(86, 29);
            this.btn_Backup.TabIndex = 14;
            this.btn_Backup.Text = "Backup";
            this.btn_Backup.UseVisualStyleBackColor = true;
            this.btn_Backup.Click += new System.EventHandler(this.btn_Backup_Click);
            // 
            // usrc_NavigationButtons1
            // 
            this.usrc_NavigationButtons1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.usrc_NavigationButtons1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.usrc_NavigationButtons1.btn1_ToolTip_Text = "";
            this.usrc_NavigationButtons1.btn2_ToolTip_Text = "";
            this.usrc_NavigationButtons1.btn3_ToolTip_Text = "";
            this.usrc_NavigationButtons1.Button_NEXT_Enabled = true;
            this.usrc_NavigationButtons1.Buttons = NavigationButtons.Navigation.eButtons.OkCancel;
            this.usrc_NavigationButtons1.ExitQuestion = "Exit Program?";
            this.usrc_NavigationButtons1.Image_Cancel = null;
            this.usrc_NavigationButtons1.Image_EXIT = null;
            this.usrc_NavigationButtons1.Image_NEXT = null;
            this.usrc_NavigationButtons1.Image_OK = null;
            this.usrc_NavigationButtons1.Image_PREV = null;
            this.usrc_NavigationButtons1.Location = new System.Drawing.Point(1, 0);
            this.usrc_NavigationButtons1.Name = "usrc_NavigationButtons1";
            this.usrc_NavigationButtons1.Size = new System.Drawing.Size(573, 26);
            this.usrc_NavigationButtons1.TabIndex = 15;
            this.usrc_NavigationButtons1.Text_Cancel = "Exit";
            this.usrc_NavigationButtons1.Text_EXIT = "Exit";
            this.usrc_NavigationButtons1.Text_NEXT = "Next";
            this.usrc_NavigationButtons1.Text_OK = "Prev";
            this.usrc_NavigationButtons1.Text_PREV = "Prev";
            this.usrc_NavigationButtons1.Visible_EXIT = true;
            this.usrc_NavigationButtons1.Visible_NEXT = true;
            this.usrc_NavigationButtons1.Visible_PREV = true;
            this.usrc_NavigationButtons1.ButtonPressed += new NavigationButtons.usrc_NavigationButtons.delegate_button_pressed(this.usrc_NavigationButtons1_ButtonPressed);
            // 
            // SQLiteConnectionDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 191);
            this.Controls.Add(this.usrc_NavigationButtons1);
            this.Controls.Add(this.btn_Backup);
            this.Controls.Add(this.btn_SQLiteInfo);
            this.Controls.Add(this.cmbR_FileName);
            this.Controls.Add(this.cmbR_FilePath);
            this.Controls.Add(this.btn_SelectFile);
            this.Controls.Add(this.lbl_FileName);
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
        private System.Windows.Forms.Label lbl_Folder;
        private System.Windows.Forms.Button btn_SelectFolder;
        private System.Windows.Forms.Label lbl_FileName;
        private System.Windows.Forms.Button btn_SelectFile;
        private System.Windows.Forms.Timer timer1;
        private ComboBox_Recent.ComboBox_RecentList cmbR_FilePath;
        private ComboBox_Recent.ComboBox_RecentList cmbR_FileName;
        private System.Windows.Forms.Button btn_SQLiteInfo;
        private System.Windows.Forms.Button btn_Backup;
        private NavigationButtons.usrc_NavigationButtons usrc_NavigationButtons1;
    }
}