namespace LogFile
{
    partial class ManageLogs_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManageLogs_Form));
            this.nmUpDown_LogLevel = new System.Windows.Forms.NumericUpDown();
            this.btn_SaveSettings = new System.Windows.Forms.Button();
            this.txtLogFile = new System.Windows.Forms.TextBox();
            this.btn_View = new System.Windows.Forms.Button();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lLogFile = new System.Windows.Forms.Label();
            this.lLogLevel = new System.Windows.Forms.Label();
            this.lbl_LogFileName = new System.Windows.Forms.Label();
            this.txt_LogFileName = new System.Windows.Forms.TextBox();
            this.txt_LogFolder = new System.Windows.Forms.TextBox();
            this.lbl_LogFolder = new System.Windows.Forms.Label();
            this.btn_Delete = new System.Windows.Forms.Button();
            this.lbl_MutexTimeout = new System.Windows.Forms.Label();
            this.nmUpDown_MutexTimeout = new System.Windows.Forms.NumericUpDown();
            this.txt__ExceptionLogs = new System.Windows.Forms.TextBox();
            this.btn_Log2DB = new System.Windows.Forms.Button();
            this.chk_WriteLog2DB_on_exit = new System.Windows.Forms.CheckBox();
            this.lst_ActiveLogLevels = new System.Windows.Forms.ListBox();
            this.btn_OK = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nmUpDown_LogLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmUpDown_MutexTimeout)).BeginInit();
            this.SuspendLayout();
            // 
            // nmUpDown_LogLevel
            // 
            this.nmUpDown_LogLevel.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.nmUpDown_LogLevel.Location = new System.Drawing.Point(279, 138);
            this.nmUpDown_LogLevel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nmUpDown_LogLevel.Name = "nmUpDown_LogLevel";
            this.nmUpDown_LogLevel.Size = new System.Drawing.Size(163, 27);
            this.nmUpDown_LogLevel.TabIndex = 0;
            this.nmUpDown_LogLevel.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.nmUpDown_LogLevel.ValueChanged += new System.EventHandler(this.nmUpDown_LogLevel_ValueChanged);
            // 
            // btn_SaveSettings
            // 
            this.btn_SaveSettings.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_SaveSettings.Location = new System.Drawing.Point(359, 276);
            this.btn_SaveSettings.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_SaveSettings.Name = "btn_SaveSettings";
            this.btn_SaveSettings.Size = new System.Drawing.Size(228, 33);
            this.btn_SaveSettings.TabIndex = 1;
            this.btn_SaveSettings.Text = "Save Settings";
            this.btn_SaveSettings.UseVisualStyleBackColor = true;
            this.btn_SaveSettings.Click += new System.EventHandler(this.btn_SaveSettings_Click);
            // 
            // txtLogFile
            // 
            this.txtLogFile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLogFile.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtLogFile.Location = new System.Drawing.Point(123, 17);
            this.txtLogFile.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtLogFile.Name = "txtLogFile";
            this.txtLogFile.ReadOnly = true;
            this.txtLogFile.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.txtLogFile.Size = new System.Drawing.Size(659, 27);
            this.txtLogFile.TabIndex = 2;
            // 
            // btn_View
            // 
            this.btn_View.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_View.Location = new System.Drawing.Point(808, 15);
            this.btn_View.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_View.Name = "btn_View";
            this.btn_View.Size = new System.Drawing.Size(160, 33);
            this.btn_View.TabIndex = 3;
            this.btn_View.Text = "View";
            this.btn_View.UseVisualStyleBackColor = true;
            this.btn_View.Click += new System.EventHandler(this.btn_View_Click);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnBrowse.Location = new System.Drawing.Point(785, 101);
            this.btnBrowse.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(117, 25);
            this.btnBrowse.TabIndex = 4;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnCancel.Location = new System.Drawing.Point(155, 578);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(103, 33);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lLogFile
            // 
            this.lLogFile.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lLogFile.Location = new System.Drawing.Point(8, 17);
            this.lLogFile.Name = "lLogFile";
            this.lLogFile.Size = new System.Drawing.Size(109, 28);
            this.lLogFile.TabIndex = 9;
            this.lLogFile.Text = "Log File:";
            this.lLogFile.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lLogLevel
            // 
            this.lLogLevel.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lLogLevel.Location = new System.Drawing.Point(8, 138);
            this.lLogLevel.Name = "lLogLevel";
            this.lLogLevel.Size = new System.Drawing.Size(265, 28);
            this.lLogLevel.TabIndex = 10;
            this.lLogLevel.Text = "Log Level:";
            this.lLogLevel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_LogFileName
            // 
            this.lbl_LogFileName.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_LogFileName.Location = new System.Drawing.Point(4, 63);
            this.lbl_LogFileName.Name = "lbl_LogFileName";
            this.lbl_LogFileName.Size = new System.Drawing.Size(165, 28);
            this.lbl_LogFileName.TabIndex = 11;
            this.lbl_LogFileName.Text = "Log File Name:";
            this.lbl_LogFileName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txt_LogFileName
            // 
            this.txt_LogFileName.Location = new System.Drawing.Point(176, 63);
            this.txt_LogFileName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_LogFileName.Name = "txt_LogFileName";
            this.txt_LogFileName.Size = new System.Drawing.Size(605, 22);
            this.txt_LogFileName.TabIndex = 12;
            // 
            // txt_LogFolder
            // 
            this.txt_LogFolder.Location = new System.Drawing.Point(176, 102);
            this.txt_LogFolder.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_LogFolder.Name = "txt_LogFolder";
            this.txt_LogFolder.Size = new System.Drawing.Size(605, 22);
            this.txt_LogFolder.TabIndex = 14;
            // 
            // lbl_LogFolder
            // 
            this.lbl_LogFolder.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_LogFolder.Location = new System.Drawing.Point(3, 101);
            this.lbl_LogFolder.Name = "lbl_LogFolder";
            this.lbl_LogFolder.Size = new System.Drawing.Size(167, 28);
            this.lbl_LogFolder.TabIndex = 13;
            this.lbl_LogFolder.Text = "Log Folder:";
            this.lbl_LogFolder.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btn_Delete
            // 
            this.btn_Delete.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_Delete.Location = new System.Drawing.Point(808, 53);
            this.btn_Delete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(160, 33);
            this.btn_Delete.TabIndex = 15;
            this.btn_Delete.Text = "Delete";
            this.btn_Delete.UseVisualStyleBackColor = true;
            this.btn_Delete.Click += new System.EventHandler(this.btn_Delete_Click);
            // 
            // lbl_MutexTimeout
            // 
            this.lbl_MutexTimeout.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_MutexTimeout.Location = new System.Drawing.Point(8, 234);
            this.lbl_MutexTimeout.Name = "lbl_MutexTimeout";
            this.lbl_MutexTimeout.Size = new System.Drawing.Size(235, 28);
            this.lbl_MutexTimeout.TabIndex = 17;
            this.lbl_MutexTimeout.Text = "Mutex Timeout in ms";
            this.lbl_MutexTimeout.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nmUpDown_MutexTimeout
            // 
            this.nmUpDown_MutexTimeout.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.nmUpDown_MutexTimeout.Location = new System.Drawing.Point(249, 235);
            this.nmUpDown_MutexTimeout.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nmUpDown_MutexTimeout.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nmUpDown_MutexTimeout.Name = "nmUpDown_MutexTimeout";
            this.nmUpDown_MutexTimeout.Size = new System.Drawing.Size(91, 27);
            this.nmUpDown_MutexTimeout.TabIndex = 16;
            this.nmUpDown_MutexTimeout.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            // 
            // txt__ExceptionLogs
            // 
            this.txt__ExceptionLogs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt__ExceptionLogs.Location = new System.Drawing.Point(7, 320);
            this.txt__ExceptionLogs.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt__ExceptionLogs.Multiline = true;
            this.txt__ExceptionLogs.Name = "txt__ExceptionLogs";
            this.txt__ExceptionLogs.ReadOnly = true;
            this.txt__ExceptionLogs.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt__ExceptionLogs.Size = new System.Drawing.Size(960, 238);
            this.txt__ExceptionLogs.TabIndex = 18;
            // 
            // btn_Log2DB
            // 
            this.btn_Log2DB.Enabled = false;
            this.btn_Log2DB.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_Log2DB.Image = global::LogFile.Properties.Resources.ImportLogToDB;
            this.btn_Log2DB.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Log2DB.Location = new System.Drawing.Point(808, 230);
            this.btn_Log2DB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_Log2DB.Name = "btn_Log2DB";
            this.btn_Log2DB.Size = new System.Drawing.Size(160, 33);
            this.btn_Log2DB.TabIndex = 19;
            this.btn_Log2DB.Text = "Alt+F10";
            this.btn_Log2DB.UseVisualStyleBackColor = true;
            this.btn_Log2DB.Click += new System.EventHandler(this.btn_Log2DB_Click);
            // 
            // chk_WriteLog2DB_on_exit
            // 
            this.chk_WriteLog2DB_on_exit.AutoSize = true;
            this.chk_WriteLog2DB_on_exit.Location = new System.Drawing.Point(359, 238);
            this.chk_WriteLog2DB_on_exit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chk_WriteLog2DB_on_exit.Name = "chk_WriteLog2DB_on_exit";
            this.chk_WriteLog2DB_on_exit.Size = new System.Drawing.Size(302, 21);
            this.chk_WriteLog2DB_on_exit.TabIndex = 20;
            this.chk_WriteLog2DB_on_exit.Text = "Write LogFile to DataBase On Program Exit";
            this.chk_WriteLog2DB_on_exit.UseVisualStyleBackColor = true;
            this.chk_WriteLog2DB_on_exit.CheckedChanged += new System.EventHandler(this.chk_WriteLog2DB_on_exit_CheckedChanged);
            // 
            // lst_ActiveLogLevels
            // 
            this.lst_ActiveLogLevels.FormattingEnabled = true;
            this.lst_ActiveLogLevels.ItemHeight = 16;
            this.lst_ActiveLogLevels.Location = new System.Drawing.Point(463, 138);
            this.lst_ActiveLogLevels.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lst_ActiveLogLevels.Name = "lst_ActiveLogLevels";
            this.lst_ActiveLogLevels.Size = new System.Drawing.Size(319, 84);
            this.lst_ActiveLogLevels.TabIndex = 21;
            // 
            // btn_OK
            // 
            this.btn_OK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_OK.Location = new System.Drawing.Point(17, 574);
            this.btn_OK.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(88, 36);
            this.btn_OK.TabIndex = 22;
            this.btn_OK.Text = "OK";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // ManageLogs_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(983, 622);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.lst_ActiveLogLevels);
            this.Controls.Add(this.chk_WriteLog2DB_on_exit);
            this.Controls.Add(this.btn_Log2DB);
            this.Controls.Add(this.txt__ExceptionLogs);
            this.Controls.Add(this.lbl_MutexTimeout);
            this.Controls.Add(this.nmUpDown_MutexTimeout);
            this.Controls.Add(this.btn_Delete);
            this.Controls.Add(this.txt_LogFolder);
            this.Controls.Add(this.lbl_LogFolder);
            this.Controls.Add(this.txt_LogFileName);
            this.Controls.Add(this.lbl_LogFileName);
            this.Controls.Add(this.lLogLevel);
            this.Controls.Add(this.lLogFile);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.btn_View);
            this.Controls.Add(this.txtLogFile);
            this.Controls.Add(this.btn_SaveSettings);
            this.Controls.Add(this.nmUpDown_LogLevel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ManageLogs_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ManageLogs";
            this.Load += new System.EventHandler(this.ManageLogs_Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nmUpDown_LogLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmUpDown_MutexTimeout)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nmUpDown_LogLevel;
        private System.Windows.Forms.Button btn_SaveSettings;
        private System.Windows.Forms.TextBox txtLogFile;
        private System.Windows.Forms.Button btn_View;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lLogFile;
        private System.Windows.Forms.Label lLogLevel;
        private System.Windows.Forms.Label lbl_LogFileName;
        private System.Windows.Forms.TextBox txt_LogFileName;
        private System.Windows.Forms.TextBox txt_LogFolder;
        private System.Windows.Forms.Label lbl_LogFolder;
        private System.Windows.Forms.Button btn_Delete;
        private System.Windows.Forms.Label lbl_MutexTimeout;
        private System.Windows.Forms.NumericUpDown nmUpDown_MutexTimeout;
        private System.Windows.Forms.TextBox txt__ExceptionLogs;
        private System.Windows.Forms.Button btn_Log2DB;
        private System.Windows.Forms.CheckBox chk_WriteLog2DB_on_exit;
        private System.Windows.Forms.ListBox lst_ActiveLogLevels;
        private System.Windows.Forms.Button btn_OK;
    }
}