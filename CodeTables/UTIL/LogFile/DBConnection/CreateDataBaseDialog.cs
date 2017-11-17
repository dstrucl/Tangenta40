#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using LanguageControl;

namespace LogFile
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class CreateDataBase_Form : System.Windows.Forms.Form
	{
        enum eSelectDataBaseFileTYPE  {E_CANCEL, E_SELECT_WITH_FILE_BROWSER, E_SELECT_WITH_TEXT_BOX_ONLY};
        public Log_DBConnection m_con = null;
        public String m_SelectedPath = "";
        public bool m_bPermissionsOK = false;

        public Process_CreateDatabase_Timer m_Process_CreateDatabase_Timer;
        private System.Windows.Forms.Button button_Cancel;
        public Button btn_CreateDatabase;
        public TabControl tabControl_CreateDialog;
		private System.Windows.Forms.TabPage tabGeneral;
		private System.Windows.Forms.Label lbl_DataBase_name;
		private System.Windows.Forms.TextBox textBox_DataBaseName;
		private System.Windows.Forms.TabPage tabDataFile;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.RadioButton rdb_FileGrowthByPercent;
        private System.Windows.Forms.RadioButton rdb_FileGrowthInMB;
		private System.Windows.Forms.TextBox textBox_DataBaseFilePath;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TabPage tabLogFile;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox6;
		private System.Windows.Forms.RadioButton rdb_LogFileGrowthByPercent;
        private System.Windows.Forms.RadioButton rdb_LogFileGrowthInMB;
		private System.Windows.Forms.TextBox textBox_DataBaseLogFilePath;
        private System.Windows.Forms.Button button4;
        public Timer timer1;
        public DataGridView dataGridView_Permissions;
        private Label lblFileSizeAtInitState;
        private Label lbl_InitialLogFileSize;
        private GroupBox grpMaxLogFileSize;
        private GroupBox grpMaxDataBaseFileSize;
        private RadioButton rdbMaxDataBaseFileSizeUNLIMITED;
        private RadioButton rdbMaxDataBaseFileSizeInGB;
        private RadioButton rdbMaxLogFileSizeUNLIMITED;
        private RadioButton rdbMaxLogFileSizeInMB;
        private NumericUpDown nupdn_InitialFileSizeInMB;
        private NumericUpDown nupdn_FileGrowthByPercent;
        private NumericUpDown nupdn_FileGrowthInMB;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private NumericUpDown nupdn_MaxDataBaseFileSizeInGB;
        private NumericUpDown nupdn_InitialLogFileSizeInMB;
        private NumericUpDown nupdn_MaxLogFileSizeInMB;
        private NumericUpDown nupdn_LogFileGrowthByPercent;
        private NumericUpDown nupdn_LogFileGrowthInMB;
        public Label lbl_Message;
        private IContainer components;


        public CreateDataBase_Form(ref Log_DBConnection con)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
            m_con = con;

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		struct DatabaseParam 
		{
			public string	ServerName;
			public string	DatabaseName;
			//Data file parameters
			public string	DataFileName;
			public string	DataPathName;
			public string	InitialDataFileSize;
            public string   DataFileGrowth;
            public string   DataFileMaxSize;
            //Log file parameters
			public string	LogFileName;
			public string	LogPathName;
			public string	LogFileSize;
			public string	LogFileMaxSize;
			public string	LogFileGrowth;					
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateDataBase_Form));
            this.button_Cancel = new System.Windows.Forms.Button();
            this.btn_CreateDatabase = new System.Windows.Forms.Button();
            this.tabControl_CreateDialog = new System.Windows.Forms.TabControl();
            this.tabGeneral = new System.Windows.Forms.TabPage();
            this.lbl_DataBase_name = new System.Windows.Forms.Label();
            this.textBox_DataBaseName = new System.Windows.Forms.TextBox();
            this.tabDataFile = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.nupdn_InitialFileSizeInMB = new System.Windows.Forms.NumericUpDown();
            this.lblFileSizeAtInitState = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.nupdn_FileGrowthByPercent = new System.Windows.Forms.NumericUpDown();
            this.nupdn_FileGrowthInMB = new System.Windows.Forms.NumericUpDown();
            this.rdb_FileGrowthByPercent = new System.Windows.Forms.RadioButton();
            this.rdb_FileGrowthInMB = new System.Windows.Forms.RadioButton();
            this.grpMaxDataBaseFileSize = new System.Windows.Forms.GroupBox();
            this.nupdn_MaxDataBaseFileSizeInGB = new System.Windows.Forms.NumericUpDown();
            this.rdbMaxDataBaseFileSizeUNLIMITED = new System.Windows.Forms.RadioButton();
            this.rdbMaxDataBaseFileSizeInGB = new System.Windows.Forms.RadioButton();
            this.textBox_DataBaseFilePath = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.tabLogFile = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.nupdn_InitialLogFileSizeInMB = new System.Windows.Forms.NumericUpDown();
            this.button4 = new System.Windows.Forms.Button();
            this.textBox_DataBaseLogFilePath = new System.Windows.Forms.TextBox();
            this.grpMaxLogFileSize = new System.Windows.Forms.GroupBox();
            this.nupdn_MaxLogFileSizeInMB = new System.Windows.Forms.NumericUpDown();
            this.rdbMaxLogFileSizeUNLIMITED = new System.Windows.Forms.RadioButton();
            this.rdbMaxLogFileSizeInMB = new System.Windows.Forms.RadioButton();
            this.lbl_InitialLogFileSize = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.nupdn_LogFileGrowthByPercent = new System.Windows.Forms.NumericUpDown();
            this.nupdn_LogFileGrowthInMB = new System.Windows.Forms.NumericUpDown();
            this.rdb_LogFileGrowthByPercent = new System.Windows.Forms.RadioButton();
            this.rdb_LogFileGrowthInMB = new System.Windows.Forms.RadioButton();
            this.dataGridView_Permissions = new System.Windows.Forms.DataGridView();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.lbl_Message = new System.Windows.Forms.Label();
            this.tabControl_CreateDialog.SuspendLayout();
            this.tabGeneral.SuspendLayout();
            this.tabDataFile.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupdn_InitialFileSizeInMB)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupdn_FileGrowthByPercent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupdn_FileGrowthInMB)).BeginInit();
            this.grpMaxDataBaseFileSize.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupdn_MaxDataBaseFileSizeInGB)).BeginInit();
            this.tabLogFile.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupdn_InitialLogFileSizeInMB)).BeginInit();
            this.grpMaxLogFileSize.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupdn_MaxLogFileSizeInMB)).BeginInit();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupdn_LogFileGrowthByPercent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupdn_LogFileGrowthInMB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Permissions)).BeginInit();
            this.SuspendLayout();
            // 
            // button_Cancel
            // 
            this.button_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_Cancel.Location = new System.Drawing.Point(467, 307);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(75, 22);
            this.button_Cancel.TabIndex = 6;
            this.button_Cancel.Text = "&Cancel";
            this.button_Cancel.Click += new System.EventHandler(this.button_Cancel_Click);
            // 
            // btn_CreateDatabase
            // 
            this.btn_CreateDatabase.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_CreateDatabase.Location = new System.Drawing.Point(372, 307);
            this.btn_CreateDatabase.Name = "btn_CreateDatabase";
            this.btn_CreateDatabase.Size = new System.Drawing.Size(75, 22);
            this.btn_CreateDatabase.TabIndex = 5;
            this.btn_CreateDatabase.Text = "&OK";
            this.btn_CreateDatabase.Click += new System.EventHandler(this.btn_CreateDatabase_Click);
            // 
            // tabControl_CreateDialog
            // 
            this.tabControl_CreateDialog.Controls.Add(this.tabGeneral);
            this.tabControl_CreateDialog.Controls.Add(this.tabDataFile);
            this.tabControl_CreateDialog.Controls.Add(this.tabLogFile);
            this.tabControl_CreateDialog.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl_CreateDialog.Location = new System.Drawing.Point(2, 10);
            this.tabControl_CreateDialog.Name = "tabControl_CreateDialog";
            this.tabControl_CreateDialog.SelectedIndex = 0;
            this.tabControl_CreateDialog.Size = new System.Drawing.Size(540, 237);
            this.tabControl_CreateDialog.TabIndex = 4;
            this.tabControl_CreateDialog.Visible = false;
            // 
            // tabGeneral
            // 
            this.tabGeneral.Controls.Add(this.lbl_DataBase_name);
            this.tabGeneral.Controls.Add(this.textBox_DataBaseName);
            this.tabGeneral.Location = new System.Drawing.Point(4, 26);
            this.tabGeneral.Name = "tabGeneral";
            this.tabGeneral.Size = new System.Drawing.Size(532, 207);
            this.tabGeneral.TabIndex = 0;
            this.tabGeneral.Text = "General";
            this.tabGeneral.UseVisualStyleBackColor = true;
            // 
            // lbl_DataBase_name
            // 
            this.lbl_DataBase_name.Location = new System.Drawing.Point(117, 40);
            this.lbl_DataBase_name.Name = "lbl_DataBase_name";
            this.lbl_DataBase_name.Size = new System.Drawing.Size(115, 24);
            this.lbl_DataBase_name.TabIndex = 1;
            this.lbl_DataBase_name.Text = "DatabaseName";
            // 
            // textBox_DataBaseName
            // 
            this.textBox_DataBaseName.Location = new System.Drawing.Point(237, 40);
            this.textBox_DataBaseName.Name = "textBox_DataBaseName";
            this.textBox_DataBaseName.Size = new System.Drawing.Size(167, 23);
            this.textBox_DataBaseName.TabIndex = 0;
            this.textBox_DataBaseName.Text = "DB_EVLICENCE";
            this.textBox_DataBaseName.TextChanged += new System.EventHandler(this.textBox_DataBaseName_TextChanged);
            // 
            // tabDataFile
            // 
            this.tabDataFile.Controls.Add(this.groupBox1);
            this.tabDataFile.Controls.Add(this.textBox_DataBaseFilePath);
            this.tabDataFile.Controls.Add(this.button1);
            this.tabDataFile.Location = new System.Drawing.Point(4, 26);
            this.tabDataFile.Name = "tabDataFile";
            this.tabDataFile.Size = new System.Drawing.Size(532, 207);
            this.tabDataFile.TabIndex = 1;
            this.tabDataFile.Text = "Data file";
            this.tabDataFile.UseVisualStyleBackColor = true;
            this.tabDataFile.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.nupdn_InitialFileSizeInMB);
            this.groupBox1.Controls.Add(this.lblFileSizeAtInitState);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.grpMaxDataBaseFileSize);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.groupBox1.Location = new System.Drawing.Point(2, 38);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(546, 176);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "File properties";
            // 
            // nupdn_InitialFileSizeInMB
            // 
            this.nupdn_InitialFileSizeInMB.Location = new System.Drawing.Point(221, 36);
            this.nupdn_InitialFileSizeInMB.Name = "nupdn_InitialFileSizeInMB";
            this.nupdn_InitialFileSizeInMB.Size = new System.Drawing.Size(68, 23);
            this.nupdn_InitialFileSizeInMB.TabIndex = 13;
            this.nupdn_InitialFileSizeInMB.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // lblFileSizeAtInitCountry
            // 
            this.lblFileSizeAtInitState.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblFileSizeAtInitState.Location = new System.Drawing.Point(13, 39);
            this.lblFileSizeAtInitState.Name = "lblFileSizeAtInitState";
            this.lblFileSizeAtInitState.Size = new System.Drawing.Size(196, 16);
            this.lblFileSizeAtInitState.TabIndex = 8;
            this.lblFileSizeAtInitState.Text = "File Size At Init State in MB:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.nupdn_FileGrowthByPercent);
            this.groupBox2.Controls.Add(this.nupdn_FileGrowthInMB);
            this.groupBox2.Controls.Add(this.rdb_FileGrowthByPercent);
            this.groupBox2.Controls.Add(this.rdb_FileGrowthInMB);
            this.groupBox2.Location = new System.Drawing.Point(8, 72);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(228, 96);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "File growth";
            // 
            // nupdn_FileGrowthByPercent
            // 
            this.nupdn_FileGrowthByPercent.Location = new System.Drawing.Point(132, 59);
            this.nupdn_FileGrowthByPercent.Name = "nupdn_FileGrowthByPercent";
            this.nupdn_FileGrowthByPercent.Size = new System.Drawing.Size(78, 23);
            this.nupdn_FileGrowthByPercent.TabIndex = 8;
            this.nupdn_FileGrowthByPercent.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // nupdn_FileGrowthInMB
            // 
            this.nupdn_FileGrowthInMB.Location = new System.Drawing.Point(132, 23);
            this.nupdn_FileGrowthInMB.Name = "nupdn_FileGrowthInMB";
            this.nupdn_FileGrowthInMB.Size = new System.Drawing.Size(78, 23);
            this.nupdn_FileGrowthInMB.TabIndex = 7;
            this.nupdn_FileGrowthInMB.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // rdb_FileGrowthByPercent
            // 
            this.rdb_FileGrowthByPercent.Checked = true;
            this.rdb_FileGrowthByPercent.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rdb_FileGrowthByPercent.Location = new System.Drawing.Point(16, 57);
            this.rdb_FileGrowthByPercent.Name = "rdb_FileGrowthByPercent";
            this.rdb_FileGrowthByPercent.Size = new System.Drawing.Size(104, 24);
            this.rdb_FileGrowthByPercent.TabIndex = 1;
            this.rdb_FileGrowthByPercent.TabStop = true;
            this.rdb_FileGrowthByPercent.Text = "By percent";
            this.rdb_FileGrowthByPercent.CheckedChanged += new System.EventHandler(this.rdb_FileGrowthByPercent_CheckedChanged);
            // 
            // rdb_FileGrowthInMB
            // 
            this.rdb_FileGrowthInMB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rdb_FileGrowthInMB.Location = new System.Drawing.Point(16, 22);
            this.rdb_FileGrowthInMB.Name = "rdb_FileGrowthInMB";
            this.rdb_FileGrowthInMB.Size = new System.Drawing.Size(126, 24);
            this.rdb_FileGrowthInMB.TabIndex = 0;
            this.rdb_FileGrowthInMB.Text = "in megabytes";
            this.rdb_FileGrowthInMB.CheckedChanged += new System.EventHandler(this.rdb_FileGrowthInMB_CheckedChanged);
            // 
            // grpMaxDataBaseFileSize
            // 
            this.grpMaxDataBaseFileSize.Controls.Add(this.nupdn_MaxDataBaseFileSizeInGB);
            this.grpMaxDataBaseFileSize.Controls.Add(this.rdbMaxDataBaseFileSizeUNLIMITED);
            this.grpMaxDataBaseFileSize.Controls.Add(this.rdbMaxDataBaseFileSizeInGB);
            this.grpMaxDataBaseFileSize.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpMaxDataBaseFileSize.Location = new System.Drawing.Point(270, 82);
            this.grpMaxDataBaseFileSize.Name = "grpMaxDataBaseFileSize";
            this.grpMaxDataBaseFileSize.Size = new System.Drawing.Size(271, 72);
            this.grpMaxDataBaseFileSize.TabIndex = 12;
            this.grpMaxDataBaseFileSize.TabStop = false;
            this.grpMaxDataBaseFileSize.Text = "Max DataBase File Size";
            // 
            // nupdn_MaxDataBaseFileSizeInGB
            // 
            this.nupdn_MaxDataBaseFileSizeInGB.Location = new System.Drawing.Point(180, 34);
            this.nupdn_MaxDataBaseFileSizeInGB.Name = "nupdn_MaxDataBaseFileSizeInGB";
            this.nupdn_MaxDataBaseFileSizeInGB.Size = new System.Drawing.Size(78, 23);
            this.nupdn_MaxDataBaseFileSizeInGB.TabIndex = 9;
            this.nupdn_MaxDataBaseFileSizeInGB.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // rdbMaxDataBaseFileSizeUNLIMITED
            // 
            this.rdbMaxDataBaseFileSizeUNLIMITED.AutoSize = true;
            this.rdbMaxDataBaseFileSizeUNLIMITED.Location = new System.Drawing.Point(8, 34);
            this.rdbMaxDataBaseFileSizeUNLIMITED.Name = "rdbMaxDataBaseFileSizeUNLIMITED";
            this.rdbMaxDataBaseFileSizeUNLIMITED.Size = new System.Drawing.Size(99, 21);
            this.rdbMaxDataBaseFileSizeUNLIMITED.TabIndex = 18;
            this.rdbMaxDataBaseFileSizeUNLIMITED.TabStop = true;
            this.rdbMaxDataBaseFileSizeUNLIMITED.Text = "UNLIMITED";
            this.rdbMaxDataBaseFileSizeUNLIMITED.UseVisualStyleBackColor = true;
            this.rdbMaxDataBaseFileSizeUNLIMITED.CheckedChanged += new System.EventHandler(this.rdbMaxDataBaseFileSizeUNLIMITED_CheckedChanged);
            // 
            // rdbMaxDataBaseFileSizeInGB
            // 
            this.rdbMaxDataBaseFileSizeInGB.AutoSize = true;
            this.rdbMaxDataBaseFileSizeInGB.Location = new System.Drawing.Point(111, 36);
            this.rdbMaxDataBaseFileSizeInGB.Name = "rdbMaxDataBaseFileSizeInGB";
            this.rdbMaxDataBaseFileSizeInGB.Size = new System.Drawing.Size(65, 21);
            this.rdbMaxDataBaseFileSizeInGB.TabIndex = 17;
            this.rdbMaxDataBaseFileSizeInGB.TabStop = true;
            this.rdbMaxDataBaseFileSizeInGB.Text = "in GB:";
            this.rdbMaxDataBaseFileSizeInGB.UseVisualStyleBackColor = true;
            this.rdbMaxDataBaseFileSizeInGB.CheckedChanged += new System.EventHandler(this.rdbMaxDataBaseFileSizeInMB_CheckedChanged);
            // 
            // textBox_DataBaseFilePath
            // 
            this.textBox_DataBaseFilePath.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox_DataBaseFilePath.Location = new System.Drawing.Point(17, 14);
            this.textBox_DataBaseFilePath.Name = "textBox_DataBaseFilePath";
            this.textBox_DataBaseFilePath.Size = new System.Drawing.Size(200, 23);
            this.textBox_DataBaseFilePath.TabIndex = 1;
            this.textBox_DataBaseFilePath.Text = "D:\\DB_EVLICENCE.mdf";
            this.textBox_DataBaseFilePath.TextChanged += new System.EventHandler(this.textBox_DataBaseFilePath_TextChanged);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button1.Location = new System.Drawing.Point(290, 15);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 22);
            this.button1.TabIndex = 0;
            this.button1.Text = "Browse...";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tabLogFile
            // 
            this.tabLogFile.Controls.Add(this.groupBox4);
            this.tabLogFile.Location = new System.Drawing.Point(4, 26);
            this.tabLogFile.Name = "tabLogFile";
            this.tabLogFile.Size = new System.Drawing.Size(532, 207);
            this.tabLogFile.TabIndex = 2;
            this.tabLogFile.Text = "Log file";
            this.tabLogFile.UseVisualStyleBackColor = true;
            this.tabLogFile.Visible = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.nupdn_InitialLogFileSizeInMB);
            this.groupBox4.Controls.Add(this.button4);
            this.groupBox4.Controls.Add(this.textBox_DataBaseLogFilePath);
            this.groupBox4.Controls.Add(this.grpMaxLogFileSize);
            this.groupBox4.Controls.Add(this.lbl_InitialLogFileSize);
            this.groupBox4.Controls.Add(this.groupBox6);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(2, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(544, 204);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Log File properties";
            // 
            // nupdn_InitialLogFileSizeInMB
            // 
            this.nupdn_InitialLogFileSizeInMB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nupdn_InitialLogFileSizeInMB.Location = new System.Drawing.Point(195, 65);
            this.nupdn_InitialLogFileSizeInMB.Name = "nupdn_InitialLogFileSizeInMB";
            this.nupdn_InitialLogFileSizeInMB.Size = new System.Drawing.Size(58, 23);
            this.nupdn_InitialLogFileSizeInMB.TabIndex = 16;
            this.nupdn_InitialLogFileSizeInMB.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(459, 23);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 22);
            this.button4.TabIndex = 4;
            this.button4.Text = "Browse...";
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // textBox_DataBaseLogFilePath
            // 
            this.textBox_DataBaseLogFilePath.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_DataBaseLogFilePath.Location = new System.Drawing.Point(12, 23);
            this.textBox_DataBaseLogFilePath.Name = "textBox_DataBaseLogFilePath";
            this.textBox_DataBaseLogFilePath.Size = new System.Drawing.Size(442, 23);
            this.textBox_DataBaseLogFilePath.TabIndex = 5;
            this.textBox_DataBaseLogFilePath.TextChanged += new System.EventHandler(this.textBox_DataBaseLogFilePath_TextChanged);
            // 
            // grpMaxLogFileSize
            // 
            this.grpMaxLogFileSize.Controls.Add(this.nupdn_MaxLogFileSizeInMB);
            this.grpMaxLogFileSize.Controls.Add(this.rdbMaxLogFileSizeUNLIMITED);
            this.grpMaxLogFileSize.Controls.Add(this.rdbMaxLogFileSizeInMB);
            this.grpMaxLogFileSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpMaxLogFileSize.Location = new System.Drawing.Point(283, 120);
            this.grpMaxLogFileSize.Name = "grpMaxLogFileSize";
            this.grpMaxLogFileSize.Size = new System.Drawing.Size(251, 63);
            this.grpMaxLogFileSize.TabIndex = 15;
            this.grpMaxLogFileSize.TabStop = false;
            this.grpMaxLogFileSize.Text = "Max Log File Size";
            // 
            // nupdn_MaxLogFileSizeInMB
            // 
            this.nupdn_MaxLogFileSizeInMB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nupdn_MaxLogFileSizeInMB.Location = new System.Drawing.Point(176, 28);
            this.nupdn_MaxLogFileSizeInMB.Name = "nupdn_MaxLogFileSizeInMB";
            this.nupdn_MaxLogFileSizeInMB.Size = new System.Drawing.Size(67, 23);
            this.nupdn_MaxLogFileSizeInMB.TabIndex = 17;
            this.nupdn_MaxLogFileSizeInMB.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // rdbMaxLogFileSizeUNLIMITED
            // 
            this.rdbMaxLogFileSizeUNLIMITED.AutoSize = true;
            this.rdbMaxLogFileSizeUNLIMITED.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbMaxLogFileSizeUNLIMITED.Location = new System.Drawing.Point(14, 28);
            this.rdbMaxLogFileSizeUNLIMITED.Name = "rdbMaxLogFileSizeUNLIMITED";
            this.rdbMaxLogFileSizeUNLIMITED.Size = new System.Drawing.Size(99, 21);
            this.rdbMaxLogFileSizeUNLIMITED.TabIndex = 16;
            this.rdbMaxLogFileSizeUNLIMITED.TabStop = true;
            this.rdbMaxLogFileSizeUNLIMITED.Text = "UNLIMITED";
            this.rdbMaxLogFileSizeUNLIMITED.UseVisualStyleBackColor = true;
            this.rdbMaxLogFileSizeUNLIMITED.CheckedChanged += new System.EventHandler(this.rdbMaxLogFileSizeUNLIMITED_CheckedChanged);
            // 
            // rdbMaxLogFileSizeInMB
            // 
            this.rdbMaxLogFileSizeInMB.AutoSize = true;
            this.rdbMaxLogFileSizeInMB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbMaxLogFileSizeInMB.Location = new System.Drawing.Point(117, 28);
            this.rdbMaxLogFileSizeInMB.Name = "rdbMaxLogFileSizeInMB";
            this.rdbMaxLogFileSizeInMB.Size = new System.Drawing.Size(65, 21);
            this.rdbMaxLogFileSizeInMB.TabIndex = 15;
            this.rdbMaxLogFileSizeInMB.TabStop = true;
            this.rdbMaxLogFileSizeInMB.Text = "in MB:";
            this.rdbMaxLogFileSizeInMB.UseVisualStyleBackColor = true;
            // 
            // lbl_InitialLogFileSize
            // 
            this.lbl_InitialLogFileSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_InitialLogFileSize.Location = new System.Drawing.Point(17, 65);
            this.lbl_InitialLogFileSize.Name = "lbl_InitialLogFileSize";
            this.lbl_InitialLogFileSize.Size = new System.Drawing.Size(206, 16);
            this.lbl_InitialLogFileSize.TabIndex = 11;
            this.lbl_InitialLogFileSize.Text = "Initial Log File Size in MB";
            this.lbl_InitialLogFileSize.Click += new System.EventHandler(this.lbl_InitialLogFileSize_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.nupdn_LogFileGrowthByPercent);
            this.groupBox6.Controls.Add(this.nupdn_LogFileGrowthInMB);
            this.groupBox6.Controls.Add(this.rdb_LogFileGrowthByPercent);
            this.groupBox6.Controls.Add(this.rdb_LogFileGrowthInMB);
            this.groupBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox6.Location = new System.Drawing.Point(5, 105);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(248, 88);
            this.groupBox6.TabIndex = 0;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "File growth";
            // 
            // nupdn_LogFileGrowthByPercent
            // 
            this.nupdn_LogFileGrowthByPercent.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nupdn_LogFileGrowthByPercent.Location = new System.Drawing.Point(140, 62);
            this.nupdn_LogFileGrowthByPercent.Name = "nupdn_LogFileGrowthByPercent";
            this.nupdn_LogFileGrowthByPercent.Size = new System.Drawing.Size(92, 23);
            this.nupdn_LogFileGrowthByPercent.TabIndex = 3;
            this.nupdn_LogFileGrowthByPercent.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // nupdn_LogFileGrowthInMB
            // 
            this.nupdn_LogFileGrowthInMB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nupdn_LogFileGrowthInMB.Location = new System.Drawing.Point(138, 29);
            this.nupdn_LogFileGrowthInMB.Name = "nupdn_LogFileGrowthInMB";
            this.nupdn_LogFileGrowthInMB.Size = new System.Drawing.Size(94, 23);
            this.nupdn_LogFileGrowthInMB.TabIndex = 2;
            this.nupdn_LogFileGrowthInMB.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // rdb_LogFileGrowthByPercent
            // 
            this.rdb_LogFileGrowthByPercent.Location = new System.Drawing.Point(16, 62);
            this.rdb_LogFileGrowthByPercent.Name = "rdb_LogFileGrowthByPercent";
            this.rdb_LogFileGrowthByPercent.Size = new System.Drawing.Size(119, 21);
            this.rdb_LogFileGrowthByPercent.TabIndex = 4;
            this.rdb_LogFileGrowthByPercent.Text = "In Percentage";
            this.rdb_LogFileGrowthByPercent.CheckedChanged += new System.EventHandler(this.rdb_LogFileGrowthByPercent_CheckedChanged);
            // 
            // rdb_LogFileGrowthInMB
            // 
            this.rdb_LogFileGrowthInMB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdb_LogFileGrowthInMB.Location = new System.Drawing.Point(17, 28);
            this.rdb_LogFileGrowthInMB.Name = "rdb_LogFileGrowthInMB";
            this.rdb_LogFileGrowthInMB.Size = new System.Drawing.Size(118, 24);
            this.rdb_LogFileGrowthInMB.TabIndex = 0;
            this.rdb_LogFileGrowthInMB.Text = "in megabytes";
            this.rdb_LogFileGrowthInMB.CheckedChanged += new System.EventHandler(this.rdb_FileGrowthInMegaBytes_CheckedChanged);
            // 
            // dataGridView_Permissions
            // 
            this.dataGridView_Permissions.AllowUserToAddRows = false;
            this.dataGridView_Permissions.AllowUserToDeleteRows = false;
            this.dataGridView_Permissions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_Permissions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_Permissions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Permissions.Location = new System.Drawing.Point(2, 26);
            this.dataGridView_Permissions.Name = "dataGridView_Permissions";
            this.dataGridView_Permissions.ReadOnly = true;
            this.dataGridView_Permissions.RowTemplate.Height = 24;
            this.dataGridView_Permissions.Size = new System.Drawing.Size(652, 266);
            this.dataGridView_Permissions.TabIndex = 8;
            this.dataGridView_Permissions.Visible = false;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lbl_Message
            // 
            this.lbl_Message.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_Message.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbl_Message.Location = new System.Drawing.Point(21, 250);
            this.lbl_Message.Name = "lbl_Message";
            this.lbl_Message.Size = new System.Drawing.Size(142, 32);
            this.lbl_Message.TabIndex = 9;
            this.lbl_Message.Text = "label1";
            // 
            // CreateDataBase_Form
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(669, 340);
            this.Controls.Add(this.lbl_Message);
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.btn_CreateDatabase);
            this.Controls.Add(this.tabControl_CreateDialog);
            this.Controls.Add(this.dataGridView_Permissions);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "CreateDataBase_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Create SQL Server Database";
            this.Load += new System.EventHandler(this.CreateDataBase_Form_Load);
            this.tabControl_CreateDialog.ResumeLayout(false);
            this.tabGeneral.ResumeLayout(false);
            this.tabGeneral.PerformLayout();
            this.tabDataFile.ResumeLayout(false);
            this.tabDataFile.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nupdn_InitialFileSizeInMB)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nupdn_FileGrowthByPercent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupdn_FileGrowthInMB)).EndInit();
            this.grpMaxDataBaseFileSize.ResumeLayout(false);
            this.grpMaxDataBaseFileSize.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupdn_MaxDataBaseFileSizeInGB)).EndInit();
            this.tabLogFile.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupdn_InitialLogFileSizeInMB)).EndInit();
            this.grpMaxLogFileSize.ResumeLayout(false);
            this.grpMaxLogFileSize.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupdn_MaxLogFileSizeInMB)).EndInit();
            this.groupBox6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nupdn_LogFileGrowthByPercent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupdn_LogFileGrowthInMB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Permissions)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>



		private void button4_Click(object sender, System.EventArgs e)
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.InitialDirectory = "D:\\" ;
			saveFileDialog.Filter = "Data files (*.ldf)|*.ldf" ;
			saveFileDialog.FilterIndex = 2 ;		
			saveFileDialog.RestoreDirectory = true ;			
			//saveFileDialog.FileName += textBox_DataBaseLo
			if(saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				textBox_DataBaseLogFilePath.Text = saveFileDialog.FileName;						
			}				
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog();// new OpenFileDialog();

			saveFileDialog.InitialDirectory = "D:\\" ;
			saveFileDialog.Filter = "Data files (*.mdf)|*.mdf" ;
			saveFileDialog.FilterIndex = 2 ;		
			saveFileDialog.RestoreDirectory = true ;			
//			saveFileDialog.FileName += textBox_DataFileName.Text;
			if(saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				textBox_DataBaseFilePath.Text = saveFileDialog.FileName;				
			}		
		}






		private bool CreateDatabase(DatabaseParam DBParam)
		{
			string sqlCreateDBQuery;
            // DBParam.DatabaseName
			
            //sqlCreateDBQuery =	  " CREATE DATABASE " + DBParam.DatabaseName + " ON PRIMARY "
            //                    + " (NAME = " + DBParam.DataFileName +", " 
            //                    + " FILENAME = '" + DBParam.DataPathName +"', "
            //                    + " SIZE = 2MB,"
            //                    + "	FILEGROWTH =" + DBParam.DataFileGrowth  +") "
            //                    + " LOG ON (NAME =" + DBParam.LogFileName +", "
            //                    + " FILENAME = '" + DBParam.LogPathName + "', "
            //                    + " SIZE = 1MB, "								
            //                    + "	FILEGROWTH =" + DBParam.LogFileGrowth  +") ";	
	
            sqlCreateDBQuery = "CREATE DATABASE " + DBParam.DatabaseName +" ON PRIMARY " 
            + "(NAME = '" + DBParam.DataFileName+ "', " 
            + "FILENAME = '"+ DBParam.DataPathName + "', " 
            + "SIZE = " +DBParam.InitialDataFileSize+ "MB,"
            + "MAXSIZE = " + DBParam.DataFileMaxSize + ", FILEGROWTH = " + DBParam.DataFileGrowth + ") " +
            "LOG ON (NAME = '"+DBParam.LogFileName+"', " +
            "FILENAME = '" + DBParam.LogPathName+ "', "
            + "SIZE = "+DBParam.LogFileSize +  "MB, " +
            "MAXSIZE = "+DBParam.LogFileMaxSize+ ", " +
            "FILEGROWTH = " + DBParam.LogFileGrowth+");";


            string csError= null;
            string savedDataBaseName = m_con.DataBase;
            m_con.DataBase = "";
            //m_con.conData.SetConnectionString();

            if (this.m_con.ExecuteNonQuerySQL_NoMultiTrans(sqlCreateDBQuery, null, ref csError))
            {
                // Data Base Created OK
                m_con.DataBase = DBParam.DatabaseName;
                string msg = "Database \"" + DBParam.DatabaseName + "\" created OK on server:" + this.m_con.DataSource;
                MessageBox.Show(msg, "OK", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return true;
            }
            else
            {
                m_con.DataBase = savedDataBaseName;
                //m_con.conData.SetConnectionString();
                string msg = "ERROR! Database \"" + DBParam.DatabaseName + "\" not created on server:" + this.m_con.DataSource + "\n ERROR=" + csError;
                MessageBox.Show(msg, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
		}

        private void CreateDataBase_Form_Load(object sender, EventArgs e)
        {
            textBox_DataBaseName.Text = m_con.DataBase;
            textBox_DataBaseFilePath.Text = m_con.DataBaseFilePath;

            // DataFile
            this.rdb_FileGrowthInMB.Enabled = true;
            this.rdb_FileGrowthInMB.Checked = true;

            this.rdbMaxDataBaseFileSizeInGB.Enabled = true;
            this.rdbMaxDataBaseFileSizeUNLIMITED.Enabled = true;
            this.rdbMaxDataBaseFileSizeUNLIMITED.Checked = true;

            // Log File
            this.rdb_LogFileGrowthInMB.Enabled = true;
            this.rdb_LogFileGrowthInMB.Checked = true;

            this.rdbMaxLogFileSizeInMB.Enabled = true;
            this.rdbMaxLogFileSizeUNLIMITED.Enabled = true;
            this.rdbMaxLogFileSizeUNLIMITED.Checked = true;


            textBox_DataBaseFilePath.Text = m_SelectedPath + textBox_DataBaseName.Text + ".mdb"; ;
            textBox_DataBaseLogFilePath.Text = m_SelectedPath + textBox_DataBaseName.Text + "_LOG.log"; ;


            this.tabGeneral.Text = lng.s_General.s;
            this.Text = lng.s_CreateDataBaseDialog_Form_Title.s;
            lbl_DataBase_name.Text = lng.s_DataBaseName.s;
            this.m_Process_CreateDatabase_Timer = new Process_CreateDatabase_Timer(this);
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            switch (m_Process_CreateDatabase_Timer.Process_CreateDatabase_Timer_Tick())
            {
            case Process_CreateDatabase_Timer.Process_CreateDatabase_ENUM.STOP_CREATE:

                Cursor = Cursors.Arrow;
                timer1.Enabled = false;
                m_SelectedPath = Environment.CurrentDirectory;
                String strRoot = System.IO.Path.GetPathRoot(m_con.DataBaseFilePath);
                String strDir = System.IO.Path.GetDirectoryName(m_con.DataBaseFilePath);
                if ((strDir.Length == 0)||(strRoot.Length==0))
                {
                    //SelectPath
                    string xComputerName = GetComputerNameFromDataSource(m_con.DataSource);
                    string thisComputerName = SystemInformation.ComputerName;
                    eSelectDataBaseFileTYPE eRes;
                    if (thisComputerName.Equals(xComputerName))
                    {
                        DialogResult dWarningResult = MessageBox.Show(lng.s_OnServerDatabaseConstructionFileInstructions.s,lng.s_Warning.s,MessageBoxButtons.YesNoCancel,MessageBoxIcon.Warning);
                        switch (dWarningResult)
                        {
                            case DialogResult.Yes:
                                eRes = eSelectDataBaseFileTYPE.E_SELECT_WITH_FILE_BROWSER;
                                break;
                            default:
                                eRes = eSelectDataBaseFileTYPE.E_CANCEL;
                                break;
                        }
                    }
                    else
                    {
                        DialogResult dWarningResult = MessageBox.Show(lng.s_OnLocalComputerDatabaseConstructionFileInstructions.s,lng.s_Warning.s,MessageBoxButtons.YesNoCancel,MessageBoxIcon.Warning);
                        switch (dWarningResult)
                        {
                            case DialogResult.Yes:
                                eRes = eSelectDataBaseFileTYPE.E_SELECT_WITH_TEXT_BOX_ONLY;
                                break;
                            default:
                                eRes = eSelectDataBaseFileTYPE.E_CANCEL;
                                break;
                        }
                    }

                    if (eRes == eSelectDataBaseFileTYPE.E_SELECT_WITH_FILE_BROWSER)
                    {
                        FolderBrowserDialog pfbd = new FolderBrowserDialog();
                        pfbd.RootFolder =  Environment.SpecialFolder.MyComputer;
                        DialogResult dRes = pfbd.ShowDialog(this);
                        if (dRes == DialogResult.OK)
                        {

                            if (pfbd.SelectedPath.EndsWith("\\"))
                            {
                                m_SelectedPath = pfbd.SelectedPath;

                            }
                            else
                            {
                                m_SelectedPath = pfbd.SelectedPath + "\\";
                            }

                            textBox_DataBaseFilePath.Text = m_SelectedPath + textBox_DataBaseName.Text + ".mdb"; ;
                            textBox_DataBaseLogFilePath.Text = m_SelectedPath + textBox_DataBaseName.Text + "_LOG.log"; ;
                            Cursor = Cursors.Arrow;
                            return;
                        }
                    }
                    if (eRes == eSelectDataBaseFileTYPE.E_SELECT_WITH_TEXT_BOX_ONLY)
                    {
                        TextBoxDialog_Form txtBoxDlg = new TextBoxDialog_Form(lng.s_EnterDataBaseFileOnServer.s,lng.s_EnterDataBaseFileOnServerIfYouKnowDrivesAndFoldersOnServer.s,textBox_DataBaseName.Text,lng.s_DataBaseFileNameCanNotBeEmpty.s,true);
                        if (txtBoxDlg.ShowDialog()== DialogResult.OK)
                        {
                            m_SelectedPath = Path.GetPathRoot(txtBoxDlg.m_Result);
                            textBox_DataBaseFilePath.Text = txtBoxDlg.m_Result + ".mdb";
                            textBox_DataBaseLogFilePath.Text = txtBoxDlg.m_Result + "_LOG.log"; ;
                        }
                        else
                        {
                            Close();
                            DialogResult = DialogResult.Cancel;
                            return;
                        }
                    }
                    else
                    {
                        Close();
                        DialogResult = DialogResult.Cancel;
                        return;
                    }
                }
                Cursor = Cursors.Arrow;
                break;

            case Process_CreateDatabase_Timer.Process_CreateDatabase_ENUM.STOP:
                timer1.Enabled = false;
                Cursor = Cursors.Arrow;
                break;

            default:
                timer1.Enabled = true;
                break;
            }
        }

        private string GetComputerNameFromDataSource(string xDataSource)
        {
            int i = xDataSource.IndexOf('\\');
            if (i >= 0)
            {
                string sComputerName = xDataSource.Substring(0, i);
                return sComputerName;
            }
            else
            {
                return xDataSource;
            }
        }

        private string GetFileNameWithOutExtensionFromPath(string strPath)
        {
            String str;
            str  = System.IO.Path.GetFileNameWithoutExtension(strPath);
            return str;
        }

        private void btn_CreateDatabase_Click(object sender, EventArgs e)
        {
            if (m_bPermissionsOK)
            {
                DatabaseParam DBParam = new DatabaseParam();
                DBParam.ServerName = m_con.DataSource;
                DBParam.DatabaseName = textBox_DataBaseName.Text;

                DBParam.InitialDataFileSize = this.nupdn_InitialFileSizeInMB.Value.ToString();




                //Assign Data file parameters
                DBParam.DataFileName = GetFileNameWithOutExtensionFromPath(textBox_DataBaseFilePath.Text);

                DBParam.DataPathName = textBox_DataBaseFilePath.Text;

                if (rdb_FileGrowthInMB.Checked == true)
                {
                    DBParam.DataFileGrowth = this.nupdn_FileGrowthInMB.Value.ToString() + "MB";
                }
                else
                {
                    DBParam.DataFileGrowth = this.nupdn_LogFileGrowthByPercent.ToString() + "%";
                }
                if (rdbMaxDataBaseFileSizeUNLIMITED.Checked == true)
                {
                    DBParam.DataFileMaxSize = "UNLIMITED";
                }
                else
                {
                    DBParam.DataFileMaxSize = this.nupdn_MaxDataBaseFileSizeInGB.Value.ToString() + "GB";
                }


                //Assign Log file parameters
                DBParam.LogFileName = GetFileNameWithOutExtensionFromPath(textBox_DataBaseLogFilePath.Text);
                DBParam.LogFileSize = this.nupdn_InitialLogFileSizeInMB.Value.ToString();//1MB at the init state
                DBParam.LogPathName = textBox_DataBaseLogFilePath.Text;

                if (rdb_LogFileGrowthInMB.Checked == true)
                {
                    DBParam.LogFileGrowth = this.nupdn_LogFileGrowthInMB.Value.ToString() + "MB";
                }
                else
                {
                    DBParam.LogFileGrowth = this.nupdn_LogFileGrowthByPercent.Value.ToString() + "%";
                }

                if (rdbMaxLogFileSizeUNLIMITED.Checked == true)
                {
                    DBParam.LogFileMaxSize = "UNLIMITED";
                }
                else
                {
                    DBParam.LogFileMaxSize = this.nupdn_MaxLogFileSizeInMB + " MB";
                }




                if (CreateDatabase(DBParam))
                {
                    this.Close();
                    DialogResult = DialogResult.OK;
                }
            }
            else
            {
                this.Close();
                DialogResult = DialogResult.Cancel;
            }

        }

        private void textBox_DataBaseLogFilePath_TextChanged(object sender, EventArgs e)
        {
            //m_con.conData.strDataBaseLogFilePath = textBox_DataBaseLogFilePath.Text;
            //this.m_SelectedPath = System.IO.Path.GetDirectoryName(m_con.conData.strDataBaseLogFilePath);
        }

        private void textBox_DataBaseFilePath_TextChanged(object sender, EventArgs e)
        {
            //m_con.conData.strDataBaseFilePath = textBox_DataBaseFilePath.Text;
            //this.m_SelectedPath = System.IO.Path.GetDirectoryName(m_con.conData.strDataBaseFilePath);

        }

        private void SetOtherFilesFromDataBaseName(String str)
        {
            this.textBox_DataBaseFilePath.Text = this.m_SelectedPath + str + ".mdb";
            this.textBox_DataBaseLogFilePath.Text = this.m_SelectedPath + str + "_LOG.log";
            m_con.DataBaseFilePath = this.textBox_DataBaseFilePath.Text;
            m_con.DataBaseLogFilePath = this.textBox_DataBaseLogFilePath.Text;
        }

        private void textBox_DataBaseName_TextChanged(object sender, EventArgs e)
        {
            //m_con.conData.DataBase = textBox_DataBaseName.Text;
            SetOtherFilesFromDataBaseName(textBox_DataBaseName.Text);
        }

        private void rdb_FileGrowthInMegaBytes_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_LogFileGrowthInMB.Checked == true)
            {
                this.nupdn_LogFileGrowthInMB.Enabled = true;
                this.nupdn_LogFileGrowthByPercent.Enabled = false;
            }
            else
            {
                this.nupdn_LogFileGrowthInMB.Enabled = false;
                this.nupdn_LogFileGrowthByPercent.Enabled = true;
            }
        }

        private void lbl_InitialLogFileSize_Click(object sender, EventArgs e)
        {

        }

        private void txtInitialLogFileSize_TextChanged(object sender, EventArgs e)
        {

        }


        private void txtFileGrowthInMB_TextChanged(object sender, EventArgs e)
        {

        }

        private void rdb_FileGrowthInMB_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_FileGrowthInMB.Checked == true)
            {
                this.nupdn_FileGrowthInMB.Enabled = true;
                this.nupdn_FileGrowthByPercent.Enabled = false;
            }
            else
            {
                this.nupdn_LogFileGrowthInMB.Enabled = false;
                this.nupdn_LogFileGrowthByPercent.Enabled = true;
            }

        }

        private void rdbMaxDataBaseFileSizeUNLIMITED_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbMaxDataBaseFileSizeUNLIMITED.Checked == true)
            {
                this.nupdn_MaxDataBaseFileSizeInGB.Enabled = false;
            }
            else
            {
                this.nupdn_MaxDataBaseFileSizeInGB.Enabled = true;
            }

        }

        private void rdbMaxLogFileSizeUNLIMITED_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbMaxLogFileSizeUNLIMITED.Checked == true)
            {
                this.nupdn_MaxLogFileSizeInMB.Enabled = false;
            }
            else
            {
                this.nupdn_MaxLogFileSizeInMB.Enabled = true;
            }
        }

        private string ReverseScroll(VScrollBar vscrlbar)
        {
            int iv = vscrlbar.Maximum - vscrlbar.Value;
            return iv.ToString();
        }

        private void rdb_LogFileGrowthByPercent_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rdb_LogFileGrowthByPercent.Checked == true)
            {
                this.nupdn_LogFileGrowthInMB.Enabled = false;
                this.nupdn_LogFileGrowthByPercent.Enabled = true;
            }
            else
            {
                this.nupdn_LogFileGrowthInMB.Enabled = true;
                this.nupdn_LogFileGrowthByPercent.Enabled = false;
            }

        }

        private void rdb_FileGrowthByPercent_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rdb_FileGrowthByPercent.Checked==true)
            {
                this.nupdn_FileGrowthByPercent.Enabled = true;
                this.nupdn_FileGrowthInMB.Enabled = false;
            }
            else
            {
                this.nupdn_FileGrowthByPercent.Enabled = false;
                this.nupdn_FileGrowthInMB.Enabled = true;
            }

        }

        private void rdbMaxDataBaseFileSizeInMB_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rdbMaxDataBaseFileSizeInGB.Checked == true)
            {
                this.nupdn_MaxDataBaseFileSizeInGB.Enabled = true;
            }
            else
            {
                this.nupdn_MaxDataBaseFileSizeInGB.Enabled = false;
            }

        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            Close();
            DialogResult = DialogResult.Cancel;

        }
	}
}
