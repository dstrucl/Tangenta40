namespace Tangenta
{
    partial class Form_XML_output
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_XML_output));
            this.btn_SelectFolder = new System.Windows.Forms.Button();
            this.lbl_Folder = new System.Windows.Forms.Label();
            this.lbl_FileNames = new System.Windows.Forms.Label();
            this.btn_Save = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.cmbR_FilePath = new ComboBox_Recent.ComboBox_RecentList();
            this.btn_View = new System.Windows.Forms.Button();
            this.SuspendLayout();
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
            this.lbl_Folder.Size = new System.Drawing.Size(92, 13);
            this.lbl_Folder.TabIndex = 12;
            this.lbl_Folder.Text = "Destination Folder";
            // 
            // lbl_FileNames
            // 
            this.lbl_FileNames.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_FileNames.Location = new System.Drawing.Point(20, 76);
            this.lbl_FileNames.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_FileNames.Name = "lbl_FileNames";
            this.lbl_FileNames.Size = new System.Drawing.Size(659, 49);
            this.lbl_FileNames.TabIndex = 15;
            this.lbl_FileNames.Text = "Backup FileName";
            // 
            // btn_Save
            // 
            this.btn_Save.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_Save.Location = new System.Drawing.Point(17, 144);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(95, 37);
            this.btn_Save.TabIndex = 17;
            this.btn_Save.Text = "Save";
            this.btn_Save.UseVisualStyleBackColor = false;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_Cancel.Image = global::Tangenta.Properties.Resources.Exit;
            this.btn_Cancel.Location = new System.Drawing.Point(158, 144);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(79, 37);
            this.btn_Cancel.TabIndex = 18;
            this.btn_Cancel.UseVisualStyleBackColor = false;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // cmbR_FilePath
            // 
            this.cmbR_FilePath.AskToCreateRecentItemsFolder = false;
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
            this.cmbR_FilePath.RecentItemsFolder = "C:\\Users\\logi\\AppData\\Local\\Microsoft\\VisualStudio\\14.0\\ProjectAssemblies\\fcmo62m" +
    "-01\\RecentComboBoxItems";
            this.cmbR_FilePath.Size = new System.Drawing.Size(578, 23);
            this.cmbR_FilePath.TabIndex = 14;
            // 
            // btn_View
            // 
            this.btn_View.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_View.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_View.Location = new System.Drawing.Point(284, 144);
            this.btn_View.Name = "btn_View";
            this.btn_View.Size = new System.Drawing.Size(95, 37);
            this.btn_View.TabIndex = 19;
            this.btn_View.Text = "View";
            this.btn_View.UseVisualStyleBackColor = false;
            this.btn_View.Visible = false;
            this.btn_View.Click += new System.EventHandler(this.btn_View_Click);
            // 
            // Form_XML_output
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 187);
            this.Controls.Add(this.btn_View);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.lbl_FileNames);
            this.Controls.Add(this.cmbR_FilePath);
            this.Controls.Add(this.btn_SelectFolder);
            this.Controls.Add(this.lbl_Folder);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_XML_output";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Form_Backup_SQLite";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_SelectFolder;
        private System.Windows.Forms.Label lbl_Folder;
        private System.Windows.Forms.Label lbl_FileNames;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_View;
        internal ComboBox_Recent.ComboBox_RecentList cmbR_FilePath;
    }
}