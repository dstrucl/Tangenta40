﻿namespace DBConnectionControl40
{
    partial class TestConnectionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TestConnectionForm));
            this.progressBar_Connection = new System.Windows.Forms.ProgressBar();
            this.chkBoxWindowsLogon = new System.Windows.Forms.CheckBox();
            this.label_DataBase = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblDataSource = new System.Windows.Forms.Label();
            this.timerFollow_CheckConnection = new System.Windows.Forms.Timer(this.components);
            this.label_UserName = new System.Windows.Forms.Label();
            this.label_Server = new System.Windows.Forms.Label();
            this.lblDataBase = new System.Windows.Forms.Label();
            this.btn_OK = new System.Windows.Forms.Button();
            this.lbl_ERROR = new System.Windows.Forms.Label();
            this.TimerSQLiteShowOkResult = new System.Windows.Forms.Timer(this.components);
            this.TimerSQLiteShowErrorResult = new System.Windows.Forms.Timer(this.components);
            this.btn_ChangeConnection = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // progressBar_Connection
            // 
            this.progressBar_Connection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar_Connection.Location = new System.Drawing.Point(9, 170);
            this.progressBar_Connection.Margin = new System.Windows.Forms.Padding(2);
            this.progressBar_Connection.Name = "progressBar_Connection";
            this.progressBar_Connection.Size = new System.Drawing.Size(609, 17);
            this.progressBar_Connection.TabIndex = 15;
            // 
            // chkBoxWindowsLogon
            // 
            this.chkBoxWindowsLogon.AutoSize = true;
            this.chkBoxWindowsLogon.Enabled = false;
            this.chkBoxWindowsLogon.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkBoxWindowsLogon.Location = new System.Drawing.Point(10, 97);
            this.chkBoxWindowsLogon.Margin = new System.Windows.Forms.Padding(2);
            this.chkBoxWindowsLogon.Name = "chkBoxWindowsLogon";
            this.chkBoxWindowsLogon.Size = new System.Drawing.Size(148, 24);
            this.chkBoxWindowsLogon.TabIndex = 14;
            this.chkBoxWindowsLogon.Text = "Windows Log On";
            this.chkBoxWindowsLogon.UseVisualStyleBackColor = true;
            // 
            // label_DataBase
            // 
            this.label_DataBase.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_DataBase.Location = new System.Drawing.Point(231, 30);
            this.label_DataBase.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_DataBase.Name = "label_DataBase";
            this.label_DataBase.Size = new System.Drawing.Size(396, 31);
            this.label_DataBase.TabIndex = 13;
            this.label_DataBase.Text = "DataBase:";
            this.label_DataBase.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblUserName
            // 
            this.lblUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserName.Location = new System.Drawing.Point(3, 67);
            this.lblUserName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(222, 23);
            this.lblUserName.TabIndex = 9;
            this.lblUserName.Text = "User Name:";
            this.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDataSource
            // 
            this.lblDataSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDataSource.Location = new System.Drawing.Point(10, 7);
            this.lblDataSource.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDataSource.Name = "lblDataSource";
            this.lblDataSource.Size = new System.Drawing.Size(103, 18);
            this.lblDataSource.TabIndex = 8;
            this.lblDataSource.Text = "Server:";
            this.lblDataSource.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // timerFollow_CheckConnection
            // 
            this.timerFollow_CheckConnection.Tick += new System.EventHandler(this.timerFollow_CheckConnection_Tick);
            // 
            // label_UserName
            // 
            this.label_UserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_UserName.Location = new System.Drawing.Point(231, 67);
            this.label_UserName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_UserName.Name = "label_UserName";
            this.label_UserName.Size = new System.Drawing.Size(396, 23);
            this.label_UserName.TabIndex = 12;
            this.label_UserName.Text = "User Name:";
            this.label_UserName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_Server
            // 
            this.label_Server.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Server.Location = new System.Drawing.Point(118, 6);
            this.label_Server.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_Server.Name = "label_Server";
            this.label_Server.Size = new System.Drawing.Size(257, 18);
            this.label_Server.TabIndex = 11;
            this.label_Server.Text = "Server:";
            this.label_Server.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDataBase
            // 
            this.lblDataBase.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDataBase.Location = new System.Drawing.Point(4, 33);
            this.lblDataBase.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDataBase.Name = "lblDataBase";
            this.lblDataBase.Size = new System.Drawing.Size(221, 25);
            this.lblDataBase.TabIndex = 10;
            this.lblDataBase.Text = "DataBase:";
            this.lblDataBase.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btn_OK
            // 
            this.btn_OK.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_OK.Location = new System.Drawing.Point(235, 114);
            this.btn_OK.Margin = new System.Windows.Forms.Padding(2);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(92, 46);
            this.btn_OK.TabIndex = 16;
            this.btn_OK.Text = "OK";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // lbl_ERROR
            // 
            this.lbl_ERROR.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ERROR.ForeColor = System.Drawing.Color.DarkRed;
            this.lbl_ERROR.Location = new System.Drawing.Point(10, 6);
            this.lbl_ERROR.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_ERROR.Name = "lbl_ERROR";
            this.lbl_ERROR.Size = new System.Drawing.Size(618, 18);
            this.lbl_ERROR.TabIndex = 17;
            this.lbl_ERROR.Text = "label1";
            // 
            // TimerSQLiteShowOkResult
            // 
            this.TimerSQLiteShowOkResult.Interval = 2000;
            this.TimerSQLiteShowOkResult.Tick += new System.EventHandler(this.TimerSQLiteShowOkResult_Tick);
            // 
            // TimerSQLiteShowErrorResult
            // 
            this.TimerSQLiteShowErrorResult.Interval = 10000;
            this.TimerSQLiteShowErrorResult.Tick += new System.EventHandler(this.TimerSQLiteShowErrorResult_Tick);
            // 
            // btn_ChangeConnection
            // 
            this.btn_ChangeConnection.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ChangeConnection.Image = global::DBConnectionControl40.Properties.Resources.ChangeConnection;
            this.btn_ChangeConnection.Location = new System.Drawing.Point(398, 114);
            this.btn_ChangeConnection.Margin = new System.Windows.Forms.Padding(2);
            this.btn_ChangeConnection.Name = "btn_ChangeConnection";
            this.btn_ChangeConnection.Size = new System.Drawing.Size(45, 46);
            this.btn_ChangeConnection.TabIndex = 18;
            this.btn_ChangeConnection.UseVisualStyleBackColor = true;
            this.btn_ChangeConnection.Click += new System.EventHandler(this.btn_ChangeConnection_Click);
            // 
            // TestConnectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(634, 196);
            this.ControlBox = false;
            this.Controls.Add(this.btn_ChangeConnection);
            this.Controls.Add(this.lbl_ERROR);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.progressBar_Connection);
            this.Controls.Add(this.chkBoxWindowsLogon);
            this.Controls.Add(this.label_DataBase);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.lblDataSource);
            this.Controls.Add(this.label_UserName);
            this.Controls.Add(this.label_Server);
            this.Controls.Add(this.lblDataBase);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "TestConnectionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TestConnectionForm";
            this.Load += new System.EventHandler(this.TestConnectionForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar_Connection;
        private System.Windows.Forms.CheckBox chkBoxWindowsLogon;
        private System.Windows.Forms.Label label_DataBase;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblDataSource;
        private System.Windows.Forms.Timer timerFollow_CheckConnection;
        private System.Windows.Forms.Label label_UserName;
        private System.Windows.Forms.Label label_Server;
        private System.Windows.Forms.Label lblDataBase;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Label lbl_ERROR;
        private System.Windows.Forms.Timer TimerSQLiteShowOkResult;
        private System.Windows.Forms.Timer TimerSQLiteShowErrorResult;
        private System.Windows.Forms.Button btn_ChangeConnection;
    }
}