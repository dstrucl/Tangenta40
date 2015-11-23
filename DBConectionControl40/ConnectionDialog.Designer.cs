namespace DBConnectionControl40
{
    partial class ConnectionDialog
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
            ComboBox_Recent.myIteM myIteM1 = new ComboBox_Recent.myIteM();
            ComboBox_Recent.myIteM myIteM2 = new ComboBox_Recent.myIteM();
            ComboBox_Recent.myIteM myIteM3 = new ComboBox_Recent.myIteM();
            ComboBox_Recent.myIteM myIteM4 = new ComboBox_Recent.myIteM();
            ComboBox_Recent.myIteM myIteM5 = new ComboBox_Recent.myIteM();
            ComboBox_Recent.myIteM myIteM6 = new ComboBox_Recent.myIteM();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConnectionDialog));
            this.rdb_SQL_Server_Authentication = new System.Windows.Forms.RadioButton();
            this.rdb_UseWindowsAuthentication = new System.Windows.Forms.RadioButton();
            this.btn_Browse_Databases_onServer = new System.Windows.Forms.Button();
            this.btn_Browse_servers = new System.Windows.Forms.Button();
            this.lbl_Instruction = new System.Windows.Forms.Label();
            this.button_end = new System.Windows.Forms.Button();
            this.lbl_DataBase = new System.Windows.Forms.Label();
            this.lbl_Server = new System.Windows.Forms.Label();
            this.btn_Action = new System.Windows.Forms.Button();
            this.lbl_UserName = new System.Windows.Forms.Label();
            this.lbl_Password = new System.Windows.Forms.Label();
            this.txt_Password = new System.Windows.Forms.TextBox();
            this.grpServerType = new System.Windows.Forms.GroupBox();
            this.radioButton_MySqlServer = new System.Windows.Forms.RadioButton();
            this.radioButton_MicrosoftSQL = new System.Windows.Forms.RadioButton();
            this.cmb_UserName = new ComboBox_Recent.ComboBox_RecentList();
            this.cmb_DataBaseName = new ComboBox_Recent.ComboBox_RecentList();
            this.cmb_ServerName = new ComboBox_Recent.ComboBox_RecentList();
            this.grpServerType.SuspendLayout();
            this.SuspendLayout();
            // 
            // rdb_SQL_Server_Authentication
            // 
            this.rdb_SQL_Server_Authentication.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdb_SQL_Server_Authentication.Location = new System.Drawing.Point(134, 197);
            this.rdb_SQL_Server_Authentication.Margin = new System.Windows.Forms.Padding(2);
            this.rdb_SQL_Server_Authentication.Name = "rdb_SQL_Server_Authentication";
            this.rdb_SQL_Server_Authentication.Size = new System.Drawing.Size(196, 21);
            this.rdb_SQL_Server_Authentication.TabIndex = 40;
            this.rdb_SQL_Server_Authentication.TabStop = true;
            this.rdb_SQL_Server_Authentication.Text = "SQL Server Authentication";
            this.rdb_SQL_Server_Authentication.UseVisualStyleBackColor = true;
            this.rdb_SQL_Server_Authentication.CheckedChanged += new System.EventHandler(this.rdb_SQL_Server_Authentication_CheckedChanged);
            // 
            // rdb_UseWindowsAuthentication
            // 
            this.rdb_UseWindowsAuthentication.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdb_UseWindowsAuthentication.Location = new System.Drawing.Point(134, 169);
            this.rdb_UseWindowsAuthentication.Margin = new System.Windows.Forms.Padding(2);
            this.rdb_UseWindowsAuthentication.Name = "rdb_UseWindowsAuthentication";
            this.rdb_UseWindowsAuthentication.Size = new System.Drawing.Size(196, 21);
            this.rdb_UseWindowsAuthentication.TabIndex = 39;
            this.rdb_UseWindowsAuthentication.TabStop = true;
            this.rdb_UseWindowsAuthentication.Text = "Windows Authentication";
            this.rdb_UseWindowsAuthentication.UseVisualStyleBackColor = true;
            this.rdb_UseWindowsAuthentication.CheckedChanged += new System.EventHandler(this.rdb_UseWindowsAuthentication_CheckedChanged);
            // 
            // btn_Browse_Databases_onServer
            // 
            this.btn_Browse_Databases_onServer.Enabled = false;
            this.btn_Browse_Databases_onServer.Location = new System.Drawing.Point(422, 132);
            this.btn_Browse_Databases_onServer.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Browse_Databases_onServer.Name = "btn_Browse_Databases_onServer";
            this.btn_Browse_Databases_onServer.Size = new System.Drawing.Size(63, 21);
            this.btn_Browse_Databases_onServer.TabIndex = 38;
            this.btn_Browse_Databases_onServer.Text = "Browse...";
            this.btn_Browse_Databases_onServer.UseVisualStyleBackColor = true;
            this.btn_Browse_Databases_onServer.Click += new System.EventHandler(this.btn_Browse_Databases_onServer_Click);
            // 
            // btn_Browse_servers
            // 
            this.btn_Browse_servers.Location = new System.Drawing.Point(422, 104);
            this.btn_Browse_servers.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Browse_servers.Name = "btn_Browse_servers";
            this.btn_Browse_servers.Size = new System.Drawing.Size(63, 24);
            this.btn_Browse_servers.TabIndex = 37;
            this.btn_Browse_servers.Text = "Browse...";
            this.btn_Browse_servers.UseVisualStyleBackColor = true;
            this.btn_Browse_servers.Click += new System.EventHandler(this.btn_Browse_servers_Click);
            // 
            // lbl_Instruction
            // 
            this.lbl_Instruction.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Instruction.Location = new System.Drawing.Point(3, 4);
            this.lbl_Instruction.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_Instruction.Name = "lbl_Instruction";
            this.lbl_Instruction.Size = new System.Drawing.Size(482, 56);
            this.lbl_Instruction.TabIndex = 36;
            this.lbl_Instruction.Text = "label1";
            this.lbl_Instruction.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // button_end
            // 
            this.button_end.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_end.Location = new System.Drawing.Point(352, 280);
            this.button_end.Margin = new System.Windows.Forms.Padding(2);
            this.button_end.Name = "button_end";
            this.button_end.Size = new System.Drawing.Size(64, 28);
            this.button_end.TabIndex = 35;
            this.button_end.Text = "Končaj";
            this.button_end.UseVisualStyleBackColor = true;
            this.button_end.Click += new System.EventHandler(this.button_end_Click);
            // 
            // lbl_DataBase
            // 
            this.lbl_DataBase.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_DataBase.Location = new System.Drawing.Point(3, 134);
            this.lbl_DataBase.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_DataBase.Name = "lbl_DataBase";
            this.lbl_DataBase.Size = new System.Drawing.Size(116, 16);
            this.lbl_DataBase.TabIndex = 32;
            this.lbl_DataBase.Text = "Podatkovna baza:";
            this.lbl_DataBase.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_Server
            // 
            this.lbl_Server.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Server.Location = new System.Drawing.Point(3, 109);
            this.lbl_Server.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_Server.Name = "lbl_Server";
            this.lbl_Server.Size = new System.Drawing.Size(116, 16);
            this.lbl_Server.TabIndex = 31;
            this.lbl_Server.Text = "Strežnik:";
            this.lbl_Server.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btn_Action
            // 
            this.btn_Action.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Action.Location = new System.Drawing.Point(134, 280);
            this.btn_Action.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Action.Name = "btn_Action";
            this.btn_Action.Size = new System.Drawing.Size(208, 28);
            this.btn_Action.TabIndex = 30;
            this.btn_Action.Text = "Poveži se na bazo podatkov";
            this.btn_Action.UseVisualStyleBackColor = true;
            this.btn_Action.Click += new System.EventHandler(this.btn_Action_Click);
            // 
            // lbl_UserName
            // 
            this.lbl_UserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_UserName.Location = new System.Drawing.Point(3, 225);
            this.lbl_UserName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_UserName.Name = "lbl_UserName";
            this.lbl_UserName.Size = new System.Drawing.Size(116, 16);
            this.lbl_UserName.TabIndex = 29;
            this.lbl_UserName.Text = "Uporabniško ime:";
            this.lbl_UserName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_Password
            // 
            this.lbl_Password.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Password.Location = new System.Drawing.Point(3, 256);
            this.lbl_Password.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_Password.Name = "lbl_Password";
            this.lbl_Password.Size = new System.Drawing.Size(116, 16);
            this.lbl_Password.TabIndex = 28;
            this.lbl_Password.Text = "Geslo:";
            this.lbl_Password.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txt_Password
            // 
            this.txt_Password.Enabled = false;
            this.txt_Password.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Password.Location = new System.Drawing.Point(134, 254);
            this.txt_Password.Margin = new System.Windows.Forms.Padding(2);
            this.txt_Password.Name = "txt_Password";
            this.txt_Password.Size = new System.Drawing.Size(284, 23);
            this.txt_Password.TabIndex = 26;
            this.txt_Password.UseSystemPasswordChar = true;
            // 
            // grpServerType
            // 
            this.grpServerType.Controls.Add(this.radioButton_MySqlServer);
            this.grpServerType.Controls.Add(this.radioButton_MicrosoftSQL);
            this.grpServerType.Location = new System.Drawing.Point(134, 62);
            this.grpServerType.Margin = new System.Windows.Forms.Padding(2);
            this.grpServerType.Name = "grpServerType";
            this.grpServerType.Padding = new System.Windows.Forms.Padding(2);
            this.grpServerType.Size = new System.Drawing.Size(284, 40);
            this.grpServerType.TabIndex = 43;
            this.grpServerType.TabStop = false;
            this.grpServerType.Text = "Select Server";
            // 
            // radioButton_MySqlServer
            // 
            this.radioButton_MySqlServer.AutoSize = true;
            this.radioButton_MySqlServer.Location = new System.Drawing.Point(170, 18);
            this.radioButton_MySqlServer.Margin = new System.Windows.Forms.Padding(2);
            this.radioButton_MySqlServer.Name = "radioButton_MySqlServer";
            this.radioButton_MySqlServer.Size = new System.Drawing.Size(92, 17);
            this.radioButton_MySqlServer.TabIndex = 44;
            this.radioButton_MySqlServer.TabStop = true;
            this.radioButton_MySqlServer.Text = "MySQL server";
            this.radioButton_MySqlServer.UseVisualStyleBackColor = true;
            this.radioButton_MySqlServer.CheckedChanged += new System.EventHandler(this.radioButton_MySqlServer_CheckedChanged);
            // 
            // radioButton_MicrosoftSQL
            // 
            this.radioButton_MicrosoftSQL.AutoSize = true;
            this.radioButton_MicrosoftSQL.Location = new System.Drawing.Point(14, 17);
            this.radioButton_MicrosoftSQL.Margin = new System.Windows.Forms.Padding(2);
            this.radioButton_MicrosoftSQL.Name = "radioButton_MicrosoftSQL";
            this.radioButton_MicrosoftSQL.Size = new System.Drawing.Size(126, 17);
            this.radioButton_MicrosoftSQL.TabIndex = 43;
            this.radioButton_MicrosoftSQL.TabStop = true;
            this.radioButton_MicrosoftSQL.Text = "Microsoft SQL Server";
            this.radioButton_MicrosoftSQL.UseVisualStyleBackColor = true;
            this.radioButton_MicrosoftSQL.CheckedChanged += new System.EventHandler(this.radioButton_MicrosoftSQL_CheckedChanged);
            // 
            // cmb_UserName
            // 
            this.cmb_UserName.DisplayMember = "text";
            this.cmb_UserName.DisplayTime = false;
            this.cmb_UserName.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmb_UserName.FormattingEnabled = true;
            this.cmb_UserName.InsertOnKeyPress = true;
            this.cmb_UserName.Items.AddRange(new object[] {
            myIteM1});
            this.cmb_UserName.Key = "UserName";
            this.cmb_UserName.Location = new System.Drawing.Point(134, 228);
            this.cmb_UserName.MaxRecentCount = 10;
            this.cmb_UserName.Name = "cmb_UserName";
            this.cmb_UserName.ReadOnly = false;
            this.cmb_UserName.RecentItemsFileName = "ComboBoxRecentXmlFile_UserName.xml";
            this.cmb_UserName.Size = new System.Drawing.Size(282, 21);
            this.cmb_UserName.TabIndex = 49;
            // 
            // cmb_DataBaseName
            // 
            this.cmb_DataBaseName.DisplayMember = "text";
            this.cmb_DataBaseName.DisplayTime = false;
            this.cmb_DataBaseName.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmb_DataBaseName.FormattingEnabled = true;
            this.cmb_DataBaseName.InsertOnKeyPress = true;
            this.cmb_DataBaseName.Items.AddRange(new object[] {
            myIteM2,
            myIteM3,
            myIteM4,
            myIteM5});
            this.cmb_DataBaseName.Key = "DataBaseName";
            this.cmb_DataBaseName.Location = new System.Drawing.Point(123, 135);
            this.cmb_DataBaseName.MaxRecentCount = 10;
            this.cmb_DataBaseName.Name = "cmb_DataBaseName";
            this.cmb_DataBaseName.ReadOnly = false;
            this.cmb_DataBaseName.RecentItemsFileName = "ComboBoxRecentXmlFile_DataBaseName.xml";
            this.cmb_DataBaseName.Size = new System.Drawing.Size(293, 21);
            this.cmb_DataBaseName.TabIndex = 48;
            // 
            // cmb_ServerName
            // 
            this.cmb_ServerName.DisplayMember = "text";
            this.cmb_ServerName.DisplayTime = false;
            this.cmb_ServerName.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmb_ServerName.FormattingEnabled = true;
            this.cmb_ServerName.InsertOnKeyPress = true;
            this.cmb_ServerName.Items.AddRange(new object[] {
            myIteM6});
            this.cmb_ServerName.Key = "ServerName";
            this.cmb_ServerName.Location = new System.Drawing.Point(124, 108);
            this.cmb_ServerName.MaxRecentCount = 10;
            this.cmb_ServerName.Name = "cmb_ServerName";
            this.cmb_ServerName.ReadOnly = false;
            this.cmb_ServerName.RecentItemsFileName = "ComboBoxRecentXmlFile_ServerName.xml";
            this.cmb_ServerName.Size = new System.Drawing.Size(292, 21);
            this.cmb_ServerName.TabIndex = 47;
            this.cmb_ServerName.TextChanged += new System.EventHandler(this.cmb_ServerName_TextChanged);
            // 
            // ConnectionDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 319);
            this.Controls.Add(this.cmb_UserName);
            this.Controls.Add(this.cmb_DataBaseName);
            this.Controls.Add(this.cmb_ServerName);
            this.Controls.Add(this.grpServerType);
            this.Controls.Add(this.rdb_SQL_Server_Authentication);
            this.Controls.Add(this.rdb_UseWindowsAuthentication);
            this.Controls.Add(this.btn_Browse_Databases_onServer);
            this.Controls.Add(this.btn_Browse_servers);
            this.Controls.Add(this.lbl_Instruction);
            this.Controls.Add(this.button_end);
            this.Controls.Add(this.lbl_DataBase);
            this.Controls.Add(this.lbl_Server);
            this.Controls.Add(this.btn_Action);
            this.Controls.Add(this.lbl_UserName);
            this.Controls.Add(this.lbl_Password);
            this.Controls.Add(this.txt_Password);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ConnectionDialog";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ConnectionDialog";
            this.Load += new System.EventHandler(this.ConnectionDialog_Load);
            this.grpServerType.ResumeLayout(false);
            this.grpServerType.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rdb_SQL_Server_Authentication;
        private System.Windows.Forms.RadioButton rdb_UseWindowsAuthentication;
        private System.Windows.Forms.Button btn_Browse_Databases_onServer;
        private System.Windows.Forms.Button btn_Browse_servers;
        private System.Windows.Forms.Label lbl_Instruction;
        private System.Windows.Forms.Button button_end;
        private System.Windows.Forms.Label lbl_DataBase;
        private System.Windows.Forms.Label lbl_Server;
        private System.Windows.Forms.Button btn_Action;
        private System.Windows.Forms.Label lbl_UserName;
        private System.Windows.Forms.Label lbl_Password;
        private System.Windows.Forms.TextBox txt_Password;
        private System.Windows.Forms.GroupBox grpServerType;
        private System.Windows.Forms.RadioButton radioButton_MySqlServer;
        private System.Windows.Forms.RadioButton radioButton_MicrosoftSQL;
        private ComboBox_Recent.ComboBox_RecentList cmb_UserName;
        private ComboBox_Recent.ComboBox_RecentList cmb_DataBaseName;
        private ComboBox_Recent.ComboBox_RecentList cmb_ServerName;
    }
}