namespace DBConnectionControl40
{
    partial class Select_DataBase_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Select_DataBase_Form));
            this.lbl_Server = new System.Windows.Forms.Label();
            this.txt_DataBaseName = new System.Windows.Forms.TextBox();
            this.listBox_DataBaseNames = new System.Windows.Forms.ListBox();
            this.lbl_Password = new System.Windows.Forms.Label();
            this.btn_CreateNewDatabase = new System.Windows.Forms.Button();
            this.lbl_UserName = new System.Windows.Forms.Label();
            this.Btn_TestConnection = new System.Windows.Forms.Button();
            this.lbl_Database = new System.Windows.Forms.Label();
            this.grpbox_ConnectToDatabaseName = new System.Windows.Forms.GroupBox();
            this.btn_GetDataBaseList = new System.Windows.Forms.Button();
            this.grpbox_LogOnToTheServer = new System.Windows.Forms.GroupBox();
            this.txt_Password = new System.Windows.Forms.TextBox();
            this.txt_UserName = new System.Windows.Forms.TextBox();
            this.radioButton_UseSQLServerAuthentication = new System.Windows.Forms.RadioButton();
            this.radioButton_UseWindowsAuthentication = new System.Windows.Forms.RadioButton();
            this.txt_ServerName = new System.Windows.Forms.TextBox();
            this.btn_Connect = new System.Windows.Forms.Button();
            this.btn_ViewRights = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.grpbox_ConnectToDatabaseName.SuspendLayout();
            this.grpbox_LogOnToTheServer.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_Server
            // 
            this.lbl_Server.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Server.Location = new System.Drawing.Point(5, -38);
            this.lbl_Server.Name = "lbl_Server";
            this.lbl_Server.Size = new System.Drawing.Size(97, 28);
            this.lbl_Server.TabIndex = 10;
            this.lbl_Server.Text = "Server:";
            // 
            // txt_DataBaseName
            // 
            this.txt_DataBaseName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txt_DataBaseName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_DataBaseName.Location = new System.Drawing.Point(243, 230);
            this.txt_DataBaseName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_DataBaseName.Name = "txt_DataBaseName";
            this.txt_DataBaseName.Size = new System.Drawing.Size(413, 30);
            this.txt_DataBaseName.TabIndex = 2;
            // 
            // listBox_DataBaseNames
            // 
            this.listBox_DataBaseNames.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox_DataBaseNames.Enabled = false;
            this.listBox_DataBaseNames.FormattingEnabled = true;
            this.listBox_DataBaseNames.ItemHeight = 23;
            this.listBox_DataBaseNames.Location = new System.Drawing.Point(5, 82);
            this.listBox_DataBaseNames.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listBox_DataBaseNames.Name = "listBox_DataBaseNames";
            this.listBox_DataBaseNames.Size = new System.Drawing.Size(649, 119);
            this.listBox_DataBaseNames.TabIndex = 1;
            this.listBox_DataBaseNames.SelectedIndexChanged += new System.EventHandler(this.listBox_DataBaseNames_SelectedIndexChanged);
            // 
            // lbl_Password
            // 
            this.lbl_Password.Location = new System.Drawing.Point(21, 149);
            this.lbl_Password.Name = "lbl_Password";
            this.lbl_Password.Size = new System.Drawing.Size(141, 27);
            this.lbl_Password.TabIndex = 4;
            this.lbl_Password.Text = "Password";
            // 
            // btn_CreateNewDatabase
            // 
            this.btn_CreateNewDatabase.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_CreateNewDatabase.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_CreateNewDatabase.Location = new System.Drawing.Point(4, 473);
            this.btn_CreateNewDatabase.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_CreateNewDatabase.Name = "btn_CreateNewDatabase";
            this.btn_CreateNewDatabase.Size = new System.Drawing.Size(219, 34);
            this.btn_CreateNewDatabase.TabIndex = 15;
            this.btn_CreateNewDatabase.Text = "Create New Database";
            this.btn_CreateNewDatabase.UseVisualStyleBackColor = true;
            this.btn_CreateNewDatabase.Click += new System.EventHandler(this.btn_CreateNewDatabase_Click);
            // 
            // lbl_UserName
            // 
            this.lbl_UserName.Location = new System.Drawing.Point(21, 108);
            this.lbl_UserName.Name = "lbl_UserName";
            this.lbl_UserName.Size = new System.Drawing.Size(133, 27);
            this.lbl_UserName.TabIndex = 3;
            this.lbl_UserName.Text = "User name";
            // 
            // Btn_TestConnection
            // 
            this.Btn_TestConnection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Btn_TestConnection.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_TestConnection.Location = new System.Drawing.Point(4, 526);
            this.Btn_TestConnection.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Btn_TestConnection.Name = "Btn_TestConnection";
            this.Btn_TestConnection.Size = new System.Drawing.Size(163, 34);
            this.Btn_TestConnection.TabIndex = 14;
            this.Btn_TestConnection.Text = "Test Connection";
            this.Btn_TestConnection.UseVisualStyleBackColor = true;
            this.Btn_TestConnection.Click += new System.EventHandler(this.Btn_TestConnection_Click);
            // 
            // lbl_Database
            // 
            this.lbl_Database.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_Database.Location = new System.Drawing.Point(5, 231);
            this.lbl_Database.Name = "lbl_Database";
            this.lbl_Database.Size = new System.Drawing.Size(229, 23);
            this.lbl_Database.TabIndex = 3;
            this.lbl_Database.Text = "Database:";
            this.lbl_Database.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // grpbox_ConnectToDatabaseName
            // 
            this.grpbox_ConnectToDatabaseName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpbox_ConnectToDatabaseName.Controls.Add(this.btn_GetDataBaseList);
            this.grpbox_ConnectToDatabaseName.Controls.Add(this.lbl_Database);
            this.grpbox_ConnectToDatabaseName.Controls.Add(this.txt_DataBaseName);
            this.grpbox_ConnectToDatabaseName.Controls.Add(this.listBox_DataBaseNames);
            this.grpbox_ConnectToDatabaseName.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpbox_ConnectToDatabaseName.Location = new System.Drawing.Point(-1, 197);
            this.grpbox_ConnectToDatabaseName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grpbox_ConnectToDatabaseName.Name = "grpbox_ConnectToDatabaseName";
            this.grpbox_ConnectToDatabaseName.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grpbox_ConnectToDatabaseName.Size = new System.Drawing.Size(660, 270);
            this.grpbox_ConnectToDatabaseName.TabIndex = 13;
            this.grpbox_ConnectToDatabaseName.TabStop = false;
            this.grpbox_ConnectToDatabaseName.Text = "Connect to a database name";
            // 
            // btn_GetDataBaseList
            // 
            this.btn_GetDataBaseList.Location = new System.Drawing.Point(5, 38);
            this.btn_GetDataBaseList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_GetDataBaseList.Name = "btn_GetDataBaseList";
            this.btn_GetDataBaseList.Size = new System.Drawing.Size(649, 30);
            this.btn_GetDataBaseList.TabIndex = 4;
            this.btn_GetDataBaseList.Text = "Get Data Base List";
            this.btn_GetDataBaseList.UseVisualStyleBackColor = true;
            this.btn_GetDataBaseList.Click += new System.EventHandler(this.btn_GetDataBaseList_Click);
            // 
            // grpbox_LogOnToTheServer
            // 
            this.grpbox_LogOnToTheServer.Controls.Add(this.txt_Password);
            this.grpbox_LogOnToTheServer.Controls.Add(this.lbl_Password);
            this.grpbox_LogOnToTheServer.Controls.Add(this.lbl_UserName);
            this.grpbox_LogOnToTheServer.Controls.Add(this.txt_UserName);
            this.grpbox_LogOnToTheServer.Controls.Add(this.radioButton_UseSQLServerAuthentication);
            this.grpbox_LogOnToTheServer.Controls.Add(this.radioButton_UseWindowsAuthentication);
            this.grpbox_LogOnToTheServer.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpbox_LogOnToTheServer.Location = new System.Drawing.Point(-1, -2);
            this.grpbox_LogOnToTheServer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grpbox_LogOnToTheServer.Name = "grpbox_LogOnToTheServer";
            this.grpbox_LogOnToTheServer.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grpbox_LogOnToTheServer.Size = new System.Drawing.Size(660, 193);
            this.grpbox_LogOnToTheServer.TabIndex = 12;
            this.grpbox_LogOnToTheServer.TabStop = false;
            this.grpbox_LogOnToTheServer.Text = "Log on to the server";
            // 
            // txt_Password
            // 
            this.txt_Password.Enabled = false;
            this.txt_Password.Location = new System.Drawing.Point(160, 146);
            this.txt_Password.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_Password.Name = "txt_Password";
            this.txt_Password.Size = new System.Drawing.Size(495, 30);
            this.txt_Password.TabIndex = 5;
            this.txt_Password.UseSystemPasswordChar = true;
            // 
            // txt_UserName
            // 
            this.txt_UserName.Enabled = false;
            this.txt_UserName.Location = new System.Drawing.Point(160, 105);
            this.txt_UserName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_UserName.Name = "txt_UserName";
            this.txt_UserName.Size = new System.Drawing.Size(495, 30);
            this.txt_UserName.TabIndex = 2;
            // 
            // radioButton_UseSQLServerAuthentication
            // 
            this.radioButton_UseSQLServerAuthentication.AutoSize = true;
            this.radioButton_UseSQLServerAuthentication.Location = new System.Drawing.Point(25, 78);
            this.radioButton_UseSQLServerAuthentication.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioButton_UseSQLServerAuthentication.Name = "radioButton_UseSQLServerAuthentication";
            this.radioButton_UseSQLServerAuthentication.Size = new System.Drawing.Size(307, 27);
            this.radioButton_UseSQLServerAuthentication.TabIndex = 1;
            this.radioButton_UseSQLServerAuthentication.TabStop = true;
            this.radioButton_UseSQLServerAuthentication.Text = "Use SQL Server  Authentication";
            this.radioButton_UseSQLServerAuthentication.UseVisualStyleBackColor = true;
            this.radioButton_UseSQLServerAuthentication.CheckedChanged += new System.EventHandler(this.radioButton_UseSQLServerAuthentication_CheckedChanged);
            // 
            // radioButton_UseWindowsAuthentication
            // 
            this.radioButton_UseWindowsAuthentication.AutoSize = true;
            this.radioButton_UseWindowsAuthentication.Location = new System.Drawing.Point(25, 44);
            this.radioButton_UseWindowsAuthentication.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioButton_UseWindowsAuthentication.Name = "radioButton_UseWindowsAuthentication";
            this.radioButton_UseWindowsAuthentication.Size = new System.Drawing.Size(278, 27);
            this.radioButton_UseWindowsAuthentication.TabIndex = 0;
            this.radioButton_UseWindowsAuthentication.TabStop = true;
            this.radioButton_UseWindowsAuthentication.Text = "Use Windows Authentication";
            this.radioButton_UseWindowsAuthentication.UseVisualStyleBackColor = true;
            this.radioButton_UseWindowsAuthentication.CheckedChanged += new System.EventHandler(this.radioButton_UseWindowsAuthentication_CheckedChanged);
            // 
            // txt_ServerName
            // 
            this.txt_ServerName.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ServerName.Location = new System.Drawing.Point(89, -38);
            this.txt_ServerName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_ServerName.Name = "txt_ServerName";
            this.txt_ServerName.ReadOnly = true;
            this.txt_ServerName.Size = new System.Drawing.Size(460, 30);
            this.txt_ServerName.TabIndex = 11;
            this.txt_ServerName.Text = "Test";
            // 
            // btn_Connect
            // 
            this.btn_Connect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Connect.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Connect.Location = new System.Drawing.Point(400, 526);
            this.btn_Connect.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_Connect.Name = "btn_Connect";
            this.btn_Connect.Size = new System.Drawing.Size(121, 34);
            this.btn_Connect.TabIndex = 16;
            this.btn_Connect.Text = "OK";
            this.btn_Connect.UseVisualStyleBackColor = true;
            this.btn_Connect.Click += new System.EventHandler(this.btn_Connect_Click);
            // 
            // btn_ViewRights
            // 
            this.btn_ViewRights.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_ViewRights.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ViewRights.Location = new System.Drawing.Point(197, 526);
            this.btn_ViewRights.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_ViewRights.Name = "btn_ViewRights";
            this.btn_ViewRights.Size = new System.Drawing.Size(172, 34);
            this.btn_ViewRights.TabIndex = 17;
            this.btn_ViewRights.Text = "ViewRights";
            this.btn_ViewRights.UseVisualStyleBackColor = true;
            this.btn_ViewRights.Click += new System.EventHandler(this.btn_ViewRights_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Cancel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Cancel.Location = new System.Drawing.Point(533, 526);
            this.btn_Cancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(121, 34);
            this.btn_Cancel.TabIndex = 18;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // Select_DataBase_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(667, 572);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_ViewRights);
            this.Controls.Add(this.lbl_Server);
            this.Controls.Add(this.btn_CreateNewDatabase);
            this.Controls.Add(this.Btn_TestConnection);
            this.Controls.Add(this.grpbox_ConnectToDatabaseName);
            this.Controls.Add(this.grpbox_LogOnToTheServer);
            this.Controls.Add(this.txt_ServerName);
            this.Controls.Add(this.btn_Connect);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Select_DataBase_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Select DataBase";
            this.Load += new System.EventHandler(this.Select_DataBase_Form_Load);
            this.grpbox_ConnectToDatabaseName.ResumeLayout(false);
            this.grpbox_ConnectToDatabaseName.PerformLayout();
            this.grpbox_LogOnToTheServer.ResumeLayout(false);
            this.grpbox_LogOnToTheServer.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_Server;
        private System.Windows.Forms.TextBox txt_DataBaseName;
        private System.Windows.Forms.ListBox listBox_DataBaseNames;
        private System.Windows.Forms.Label lbl_Password;
        private System.Windows.Forms.Button btn_CreateNewDatabase;
        private System.Windows.Forms.Label lbl_UserName;
        private System.Windows.Forms.Button Btn_TestConnection;
        private System.Windows.Forms.Label lbl_Database;
        private System.Windows.Forms.GroupBox grpbox_ConnectToDatabaseName;
        private System.Windows.Forms.GroupBox grpbox_LogOnToTheServer;
        private System.Windows.Forms.RadioButton radioButton_UseSQLServerAuthentication;
        private System.Windows.Forms.RadioButton radioButton_UseWindowsAuthentication;
        private System.Windows.Forms.TextBox txt_ServerName;
        private System.Windows.Forms.Button btn_Connect;
        private System.Windows.Forms.Button btn_GetDataBaseList;
        private System.Windows.Forms.Button btn_ViewRights;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.TextBox txt_Password;
        private System.Windows.Forms.TextBox txt_UserName;
    }
}