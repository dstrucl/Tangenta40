using System.Windows.Forms;

namespace LanguageManager
{
    partial class Form_LanguageManager
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cmb_Platform = new System.Windows.Forms.ComboBox();
            this.lbl_Platform = new System.Windows.Forms.Label();
            this.cmb_Configuration = new System.Windows.Forms.ComboBox();
            this.lbl_ConfigurationName = new System.Windows.Forms.Label();
            this.lbl_Solution_File = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lbl_ExecutablesInSolution = new System.Windows.Forms.Label();
            this.dgvx_SelectedExecutablesInSolution = new DataGridView_2xls.DataGridView2xls();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.btn_AllSourceFiles = new System.Windows.Forms.Button();
            this.lbl_ProjectLibraries = new System.Windows.Forms.Label();
            this.dgvx_Libraries = new DataGridView_2xls.DataGridView2xls();
            this.lbl_SourceFiles = new System.Windows.Forms.Label();
            this.dgvx_SourceFiles = new DataGridView_2xls.DataGridView2xls();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.lbl_LngDictionary = new System.Windows.Forms.Label();
            this.dgvx_ltext = new DataGridView_2xls.DataGridView2xls();
            this.txt_Projects = new System.Windows.Forms.TextBox();
            this.usrc_SelectFile1 = new LanguageManager.usrc_SelectFile();
            this.btn_GetAllReferences = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvx_SelectedExecutablesInSolution)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvx_Libraries)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvx_SourceFiles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvx_ltext)).BeginInit();
            this.SuspendLayout();
            // 
            // cmb_Platform
            // 
            this.cmb_Platform.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cmb_Platform.FormattingEnabled = true;
            this.cmb_Platform.Location = new System.Drawing.Point(584, 54);
            this.cmb_Platform.Margin = new System.Windows.Forms.Padding(4);
            this.cmb_Platform.Name = "cmb_Platform";
            this.cmb_Platform.Size = new System.Drawing.Size(204, 33);
            this.cmb_Platform.TabIndex = 13;
            this.cmb_Platform.SelectedIndexChanged += new System.EventHandler(this.cmb_Platform_SelectedIndexChanged);
            // 
            // lbl_Platform
            // 
            this.lbl_Platform.AutoSize = true;
            this.lbl_Platform.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_Platform.Location = new System.Drawing.Point(476, 57);
            this.lbl_Platform.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_Platform.Name = "lbl_Platform";
            this.lbl_Platform.Size = new System.Drawing.Size(89, 25);
            this.lbl_Platform.TabIndex = 12;
            this.lbl_Platform.Text = "Platform:";
            // 
            // cmb_Configuration
            // 
            this.cmb_Configuration.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cmb_Configuration.FormattingEnabled = true;
            this.cmb_Configuration.Location = new System.Drawing.Point(236, 49);
            this.cmb_Configuration.Margin = new System.Windows.Forms.Padding(4);
            this.cmb_Configuration.Name = "cmb_Configuration";
            this.cmb_Configuration.Size = new System.Drawing.Size(209, 33);
            this.cmb_Configuration.TabIndex = 11;
            this.cmb_Configuration.SelectedIndexChanged += new System.EventHandler(this.cmb_Configuration_SelectedIndexChanged);
            // 
            // lbl_ConfigurationName
            // 
            this.lbl_ConfigurationName.AutoSize = true;
            this.lbl_ConfigurationName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_ConfigurationName.Location = new System.Drawing.Point(22, 52);
            this.lbl_ConfigurationName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_ConfigurationName.Name = "lbl_ConfigurationName";
            this.lbl_ConfigurationName.Size = new System.Drawing.Size(191, 25);
            this.lbl_ConfigurationName.TabIndex = 10;
            this.lbl_ConfigurationName.Text = "Configuration Name:";
            this.lbl_ConfigurationName.Click += new System.EventHandler(this.lbl_ConfigurationName_Click);
            // 
            // lbl_Solution_File
            // 
            this.lbl_Solution_File.AutoSize = true;
            this.lbl_Solution_File.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_Solution_File.Location = new System.Drawing.Point(19, 8);
            this.lbl_Solution_File.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_Solution_File.Name = "lbl_Solution_File";
            this.lbl_Solution_File.Size = new System.Drawing.Size(125, 25);
            this.lbl_Solution_File.TabIndex = 9;
            this.lbl_Solution_File.Text = "Solution File:";
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.Menu;
            this.splitContainer1.Panel1.Controls.Add(this.lbl_ExecutablesInSolution);
            this.splitContainer1.Panel1.Controls.Add(this.dgvx_SelectedExecutablesInSolution);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(879, 284);
            this.splitContainer1.SplitterDistance = 98;
            this.splitContainer1.TabIndex = 15;
            // 
            // lbl_ExecutablesInSolution
            // 
            this.lbl_ExecutablesInSolution.AutoSize = true;
            this.lbl_ExecutablesInSolution.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_ExecutablesInSolution.Location = new System.Drawing.Point(1, 5);
            this.lbl_ExecutablesInSolution.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_ExecutablesInSolution.Name = "lbl_ExecutablesInSolution";
            this.lbl_ExecutablesInSolution.Size = new System.Drawing.Size(183, 20);
            this.lbl_ExecutablesInSolution.TabIndex = 11;
            this.lbl_ExecutablesInSolution.Text = "Executables in Solution";
            // 
            // dgvx_SelectedExecutablesInSolution
            // 
            this.dgvx_SelectedExecutablesInSolution.AllowUserToAddRows = false;
            this.dgvx_SelectedExecutablesInSolution.AllowUserToDeleteRows = false;
            this.dgvx_SelectedExecutablesInSolution.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvx_SelectedExecutablesInSolution.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvx_SelectedExecutablesInSolution.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvx_SelectedExecutablesInSolution.DataGridViewWithRowNumber = true;
            this.dgvx_SelectedExecutablesInSolution.Location = new System.Drawing.Point(3, 28);
            this.dgvx_SelectedExecutablesInSolution.MultiSelect = false;
            this.dgvx_SelectedExecutablesInSolution.Name = "dgvx_SelectedExecutablesInSolution";
            this.dgvx_SelectedExecutablesInSolution.RowTemplate.Height = 24;
            this.dgvx_SelectedExecutablesInSolution.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvx_SelectedExecutablesInSolution.Size = new System.Drawing.Size(873, 67);
            this.dgvx_SelectedExecutablesInSolution.TabIndex = 0;
            this.dgvx_SelectedExecutablesInSolution.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvx_SelectedExecutablesInSolution_CellEndEdit);
            this.dgvx_SelectedExecutablesInSolution.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvx_SelectedExecutablesInSolution_CellMouseUp);
            // 
            // splitContainer2
            // 
            this.splitContainer2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.BackColor = System.Drawing.SystemColors.Menu;
            this.splitContainer2.Panel1.Controls.Add(this.btn_AllSourceFiles);
            this.splitContainer2.Panel1.Controls.Add(this.lbl_ProjectLibraries);
            this.splitContainer2.Panel1.Controls.Add(this.dgvx_Libraries);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.BackColor = System.Drawing.SystemColors.Menu;
            this.splitContainer2.Panel2.Controls.Add(this.lbl_SourceFiles);
            this.splitContainer2.Panel2.Controls.Add(this.dgvx_SourceFiles);
            this.splitContainer2.Size = new System.Drawing.Size(879, 182);
            this.splitContainer2.SplitterDistance = 379;
            this.splitContainer2.TabIndex = 0;
            // 
            // btn_AllSourceFiles
            // 
            this.btn_AllSourceFiles.Location = new System.Drawing.Point(228, 2);
            this.btn_AllSourceFiles.Name = "btn_AllSourceFiles";
            this.btn_AllSourceFiles.Size = new System.Drawing.Size(147, 28);
            this.btn_AllSourceFiles.TabIndex = 13;
            this.btn_AllSourceFiles.Text = "All Source files";
            this.btn_AllSourceFiles.UseVisualStyleBackColor = true;
            this.btn_AllSourceFiles.Click += new System.EventHandler(this.btn_AllSourceFiles_Click);
            // 
            // lbl_ProjectLibraries
            // 
            this.lbl_ProjectLibraries.AutoSize = true;
            this.lbl_ProjectLibraries.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_ProjectLibraries.Location = new System.Drawing.Point(5, 4);
            this.lbl_ProjectLibraries.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_ProjectLibraries.Name = "lbl_ProjectLibraries";
            this.lbl_ProjectLibraries.Size = new System.Drawing.Size(183, 20);
            this.lbl_ProjectLibraries.TabIndex = 12;
            this.lbl_ProjectLibraries.Text = "Library (DLL)  Projects";
            // 
            // dgvx_Libraries
            // 
            this.dgvx_Libraries.AllowUserToAddRows = false;
            this.dgvx_Libraries.AllowUserToDeleteRows = false;
            this.dgvx_Libraries.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvx_Libraries.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvx_Libraries.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvx_Libraries.DataGridViewWithRowNumber = true;
            this.dgvx_Libraries.Location = new System.Drawing.Point(3, 33);
            this.dgvx_Libraries.Name = "dgvx_Libraries";
            this.dgvx_Libraries.RowTemplate.Height = 24;
            this.dgvx_Libraries.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvx_Libraries.Size = new System.Drawing.Size(373, 148);
            this.dgvx_Libraries.TabIndex = 0;
            this.dgvx_Libraries.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvx_Libraries_CellMouseUp);
            // 
            // lbl_SourceFiles
            // 
            this.lbl_SourceFiles.AutoSize = true;
            this.lbl_SourceFiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_SourceFiles.Location = new System.Drawing.Point(4, 4);
            this.lbl_SourceFiles.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_SourceFiles.Name = "lbl_SourceFiles";
            this.lbl_SourceFiles.Size = new System.Drawing.Size(98, 20);
            this.lbl_SourceFiles.TabIndex = 13;
            this.lbl_SourceFiles.Text = "Source files";
            // 
            // dgvx_SourceFiles
            // 
            this.dgvx_SourceFiles.AllowUserToAddRows = false;
            this.dgvx_SourceFiles.AllowUserToDeleteRows = false;
            this.dgvx_SourceFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvx_SourceFiles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvx_SourceFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvx_SourceFiles.DataGridViewWithRowNumber = true;
            this.dgvx_SourceFiles.Location = new System.Drawing.Point(3, 27);
            this.dgvx_SourceFiles.Name = "dgvx_SourceFiles";
            this.dgvx_SourceFiles.ReadOnly = true;
            this.dgvx_SourceFiles.RowTemplate.Height = 24;
            this.dgvx_SourceFiles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvx_SourceFiles.Size = new System.Drawing.Size(490, 154);
            this.dgvx_SourceFiles.TabIndex = 1;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer3.BackColor = System.Drawing.SystemColors.Info;
            this.splitContainer3.Location = new System.Drawing.Point(8, 94);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.splitContainer1);
            this.splitContainer3.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer3_Panel1_Paint);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.BackColor = System.Drawing.SystemColors.Menu;
            this.splitContainer3.Panel2.Controls.Add(this.btn_GetAllReferences);
            this.splitContainer3.Panel2.Controls.Add(this.lbl_LngDictionary);
            this.splitContainer3.Panel2.Controls.Add(this.dgvx_ltext);
            this.splitContainer3.Size = new System.Drawing.Size(879, 497);
            this.splitContainer3.SplitterDistance = 284;
            this.splitContainer3.TabIndex = 16;
            // 
            // lbl_LngDictionary
            // 
            this.lbl_LngDictionary.AutoSize = true;
            this.lbl_LngDictionary.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_LngDictionary.Location = new System.Drawing.Point(8, 4);
            this.lbl_LngDictionary.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_LngDictionary.Name = "lbl_LngDictionary";
            this.lbl_LngDictionary.Size = new System.Drawing.Size(159, 20);
            this.lbl_LngDictionary.TabIndex = 13;
            this.lbl_LngDictionary.Text = "Language dictionary";
            // 
            // dgvx_ltext
            // 
            this.dgvx_ltext.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvx_ltext.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvx_ltext.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvx_ltext.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvx_ltext.DataGridViewWithRowNumber = true;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvx_ltext.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvx_ltext.Location = new System.Drawing.Point(5, 27);
            this.dgvx_ltext.Name = "dgvx_ltext";
            this.dgvx_ltext.RowTemplate.Height = 24;
            this.dgvx_ltext.Size = new System.Drawing.Size(871, 179);
            this.dgvx_ltext.TabIndex = 0;
            this.dgvx_ltext.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvx_ltext_CellContentClick);
            // 
            // txt_Projects
            // 
            this.txt_Projects.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Projects.Location = new System.Drawing.Point(8, 598);
            this.txt_Projects.Margin = new System.Windows.Forms.Padding(4);
            this.txt_Projects.Multiline = true;
            this.txt_Projects.Name = "txt_Projects";
            this.txt_Projects.Size = new System.Drawing.Size(869, 49);
            this.txt_Projects.TabIndex = 17;
            // 
            // usrc_SelectFile1
            // 
            this.usrc_SelectFile1.DefaultExtension = "sln";
            this.usrc_SelectFile1.Extension = "";
            this.usrc_SelectFile1.FileName = "";
            this.usrc_SelectFile1.Location = new System.Drawing.Point(187, 7);
            this.usrc_SelectFile1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.usrc_SelectFile1.Name = "usrc_SelectFile1";
            this.usrc_SelectFile1.Path = "";
            this.usrc_SelectFile1.Size = new System.Drawing.Size(678, 39);
            this.usrc_SelectFile1.TabIndex = 18;
            this.usrc_SelectFile1.ExistingFileChanged += new LanguageManager.usrc_SelectFile.delegate_ExistingFileChanged(this.usrc_SelectFile1_ExistingFileChanged);
            // 
            // btn_GetAllReferences
            // 
            this.btn_GetAllReferences.Location = new System.Drawing.Point(188, 1);
            this.btn_GetAllReferences.Name = "btn_GetAllReferences";
            this.btn_GetAllReferences.Size = new System.Drawing.Size(146, 23);
            this.btn_GetAllReferences.TabIndex = 16;
            this.btn_GetAllReferences.Text = "Get all references";
            this.btn_GetAllReferences.UseVisualStyleBackColor = true;
            this.btn_GetAllReferences.Click += new System.EventHandler(this.btn_GetAllReferences_Click);
            // 
            // Form_LanguageManager
            // 
            this.ClientSize = new System.Drawing.Size(890, 652);
            this.Controls.Add(this.usrc_SelectFile1);
            this.Controls.Add(this.txt_Projects);
            this.Controls.Add(this.splitContainer3);
            this.Controls.Add(this.cmb_Platform);
            this.Controls.Add(this.lbl_Platform);
            this.Controls.Add(this.cmb_Configuration);
            this.Controls.Add(this.lbl_ConfigurationName);
            this.Controls.Add(this.lbl_Solution_File);
            this.Name = "Form_LanguageManager";
            this.Load += new System.EventHandler(this.Form_LanguageManager_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvx_SelectedExecutablesInSolution)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvx_Libraries)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvx_SourceFiles)).EndInit();
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvx_ltext)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private ComboBox cmb_Platform;
        private Label lbl_Platform;
        private ComboBox cmb_Configuration;
        private Label lbl_ConfigurationName;
        private Label lbl_Solution_File;

        #endregion

        private usrc_SelectFile usrc_SelectFile1;
        private SplitContainer splitContainer1;
        private DataGridView_2xls.DataGridView2xls dgvx_SelectedExecutablesInSolution;
        private SplitContainer splitContainer2;
        private Label lbl_ExecutablesInSolution;
        private DataGridView_2xls.DataGridView2xls dgvx_Libraries;
        private Label lbl_ProjectLibraries;
        private Label lbl_SourceFiles;
        private DataGridView_2xls.DataGridView2xls dgvx_SourceFiles;
        private SplitContainer splitContainer3;
        private Label lbl_LngDictionary;
        private DataGridView_2xls.DataGridView2xls dgvx_ltext;
        private TextBox txt_Projects;
        private Button btn_AllSourceFiles;
        private Button btn_GetAllReferences;
    }
}

