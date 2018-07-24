namespace Tangenta
{
    partial class Form_SettingsSelect
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
            this.btn_Backup = new System.Windows.Forms.Button();
            this.btn_CodeTables = new System.Windows.Forms.Button();
            this.usrc_TangentaPrint1 = new TangentaPrint.usrc_TangentaPrint();
            this.btn_Settings = new System.Windows.Forms.Button();
            this.btn_Exit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_Backup
            // 
            this.btn_Backup.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_Backup.Image = global::Tangenta.Properties.Resources.UpgradeDataBase;
            this.btn_Backup.Location = new System.Drawing.Point(180, 11);
            this.btn_Backup.Name = "btn_Backup";
            this.btn_Backup.Size = new System.Drawing.Size(75, 64);
            this.btn_Backup.TabIndex = 38;
            this.btn_Backup.UseVisualStyleBackColor = false;
            this.btn_Backup.Click += new System.EventHandler(this.btn_Backup_Click);
            // 
            // btn_CodeTables
            // 
            this.btn_CodeTables.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_CodeTables.Image = global::Tangenta.Properties.Resources.CodeTablesImage;
            this.btn_CodeTables.Location = new System.Drawing.Point(10, 11);
            this.btn_CodeTables.Name = "btn_CodeTables";
            this.btn_CodeTables.Size = new System.Drawing.Size(75, 64);
            this.btn_CodeTables.TabIndex = 39;
            this.btn_CodeTables.UseVisualStyleBackColor = false;
            this.btn_CodeTables.Click += new System.EventHandler(this.btn_CodeTables_Click);
            // 
            // usrc_TangentaPrint1
            // 
            this.usrc_TangentaPrint1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.usrc_TangentaPrint1.Location = new System.Drawing.Point(95, 11);
            this.usrc_TangentaPrint1.Margin = new System.Windows.Forms.Padding(4);
            this.usrc_TangentaPrint1.Name = "usrc_TangentaPrint1";
            this.usrc_TangentaPrint1.Size = new System.Drawing.Size(75, 64);
            this.usrc_TangentaPrint1.TabIndex = 37;
            // 
            // btn_Settings
            // 
            this.btn_Settings.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_Settings.Image = global::Tangenta.Properties.Resources.Settings;
            this.btn_Settings.Location = new System.Drawing.Point(265, 11);
            this.btn_Settings.Name = "btn_Settings";
            this.btn_Settings.Size = new System.Drawing.Size(75, 64);
            this.btn_Settings.TabIndex = 40;
            this.btn_Settings.UseVisualStyleBackColor = false;
            this.btn_Settings.Click += new System.EventHandler(this.btn_Settings_Click);
            // 
            // btn_Exit
            // 
            this.btn_Exit.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_Exit.Image = global::Tangenta.Properties.Resources.Exit;
            this.btn_Exit.Location = new System.Drawing.Point(350, 11);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(75, 64);
            this.btn_Exit.TabIndex = 41;
            this.btn_Exit.UseVisualStyleBackColor = false;
            // 
            // Form_SettingsSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 87);
            this.Controls.Add(this.btn_Exit);
            this.Controls.Add(this.btn_Settings);
            this.Controls.Add(this.btn_Backup);
            this.Controls.Add(this.btn_CodeTables);
            this.Controls.Add(this.usrc_TangentaPrint1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form_SettingsSelect";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form_SettingsSelect";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Backup;
        private System.Windows.Forms.Button btn_CodeTables;
        private TangentaPrint.usrc_TangentaPrint usrc_TangentaPrint1;
        private System.Windows.Forms.Button btn_Settings;
        private System.Windows.Forms.Button btn_Exit;
    }
}