namespace DBSync
{
    partial class Form_DBmanager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_DBmanager));
            this.btn_Change = new System.Windows.Forms.Button();
            this.lbl_DataBaseInfo = new System.Windows.Forms.Label();
            this.btn_Backup = new System.Windows.Forms.Button();
            this.btn_Exit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_Change
            // 
            this.btn_Change.Location = new System.Drawing.Point(12, 133);
            this.btn_Change.Name = "btn_Change";
            this.btn_Change.Size = new System.Drawing.Size(154, 32);
            this.btn_Change.TabIndex = 3;
            this.btn_Change.Text = "Select Another Database";
            this.btn_Change.UseVisualStyleBackColor = true;
            this.btn_Change.Click += new System.EventHandler(this.btn_Change_Click);
            // 
            // lbl_DataBaseInfo
            // 
            this.lbl_DataBaseInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_DataBaseInfo.ForeColor = System.Drawing.Color.Blue;
            this.lbl_DataBaseInfo.Location = new System.Drawing.Point(12, 6);
            this.lbl_DataBaseInfo.Name = "lbl_DataBaseInfo";
            this.lbl_DataBaseInfo.Size = new System.Drawing.Size(497, 124);
            this.lbl_DataBaseInfo.TabIndex = 4;
            this.lbl_DataBaseInfo.Text = "Database INFO";
            // 
            // btn_Backup
            // 
            this.btn_Backup.Location = new System.Drawing.Point(182, 133);
            this.btn_Backup.Name = "btn_Backup";
            this.btn_Backup.Size = new System.Drawing.Size(154, 32);
            this.btn_Backup.TabIndex = 5;
            this.btn_Backup.Text = "BACKUP";
            this.btn_Backup.UseVisualStyleBackColor = true;
            this.btn_Backup.Click += new System.EventHandler(this.btn_Backup_Click);
            // 
            // btn_Exit
            // 
            this.btn_Exit.Image = global::DB.Properties.Resources.Exit;
            this.btn_Exit.Location = new System.Drawing.Point(397, 133);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(71, 32);
            this.btn_Exit.TabIndex = 6;
            this.btn_Exit.UseVisualStyleBackColor = true;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // Form_DBmanager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 177);
            this.Controls.Add(this.btn_Exit);
            this.Controls.Add(this.btn_Backup);
            this.Controls.Add(this.lbl_DataBaseInfo);
            this.Controls.Add(this.btn_Change);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_DBmanager";
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Change;
        private System.Windows.Forms.Label lbl_DataBaseInfo;
        private System.Windows.Forms.Button btn_Backup;
        private System.Windows.Forms.Button btn_Exit;
    }
}