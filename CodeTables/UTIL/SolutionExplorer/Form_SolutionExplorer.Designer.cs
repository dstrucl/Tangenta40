namespace SolutionExplorer
{
    partial class Form_SolutionExplorer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_SolutionExplorer));
            this.txt_Projects = new System.Windows.Forms.TextBox();
            this.lbl_Solution_File = new System.Windows.Forms.Label();
            this.lbl_ConfigurationName = new System.Windows.Forms.Label();
            this.cmb_Configuration = new System.Windows.Forms.ComboBox();
            this.cmb_Platform = new System.Windows.Forms.ComboBox();
            this.lbl_Platform = new System.Windows.Forms.Label();
            this.dgvx_SelectedExecutablesInSolution = new DataGridView_2xls.DataGridView2xls();
            this.lbl_ExecutablesInSolution = new System.Windows.Forms.Label();
            this.dgvx_Libraries = new DataGridView_2xls.DataGridView2xls();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.lbl_ProjectLibraries = new System.Windows.Forms.Label();
            this.lbl_External_References = new System.Windows.Forms.Label();
            this.dgvx_ExternalDLLReferences = new DataGridView_2xls.DataGridView2xls();
            this.btn_NSIS = new System.Windows.Forms.Button();
            this.btn_INNO_Installer = new System.Windows.Forms.Button();
            this.usrc_SelectFile1 = new SolutionExplorer.usrc_SelectFile();
            ((System.ComponentModel.ISupportInitialize)(this.dgvx_SelectedExecutablesInSolution)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvx_Libraries)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvx_ExternalDLLReferences)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_Projects
            // 
            this.txt_Projects.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Projects.Location = new System.Drawing.Point(16, 702);
            this.txt_Projects.Multiline = true;
            this.txt_Projects.Name = "txt_Projects";
            this.txt_Projects.Size = new System.Drawing.Size(912, 120);
            this.txt_Projects.TabIndex = 2;
            // 
            // lbl_Solution_File
            // 
            this.lbl_Solution_File.AutoSize = true;
            this.lbl_Solution_File.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_Solution_File.Location = new System.Drawing.Point(12, 19);
            this.lbl_Solution_File.Name = "lbl_Solution_File";
            this.lbl_Solution_File.Size = new System.Drawing.Size(100, 20);
            this.lbl_Solution_File.TabIndex = 4;
            this.lbl_Solution_File.Text = "Solution File:";
            // 
            // lbl_ConfigurationName
            // 
            this.lbl_ConfigurationName.AutoSize = true;
            this.lbl_ConfigurationName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_ConfigurationName.Location = new System.Drawing.Point(17, 55);
            this.lbl_ConfigurationName.Name = "lbl_ConfigurationName";
            this.lbl_ConfigurationName.Size = new System.Drawing.Size(154, 20);
            this.lbl_ConfigurationName.TabIndex = 5;
            this.lbl_ConfigurationName.Text = "Configuration Name:";
            // 
            // cmb_Configuration
            // 
            this.cmb_Configuration.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cmb_Configuration.FormattingEnabled = true;
            this.cmb_Configuration.Location = new System.Drawing.Point(182, 51);
            this.cmb_Configuration.Name = "cmb_Configuration";
            this.cmb_Configuration.Size = new System.Drawing.Size(158, 28);
            this.cmb_Configuration.TabIndex = 6;
            this.cmb_Configuration.SelectedIndexChanged += new System.EventHandler(this.cmb_Configuration_SelectedIndexChanged);
            // 
            // cmb_Platform
            // 
            this.cmb_Platform.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cmb_Platform.FormattingEnabled = true;
            this.cmb_Platform.Location = new System.Drawing.Point(447, 51);
            this.cmb_Platform.Name = "cmb_Platform";
            this.cmb_Platform.Size = new System.Drawing.Size(154, 28);
            this.cmb_Platform.TabIndex = 8;
            this.cmb_Platform.SelectedIndexChanged += new System.EventHandler(this.cmb_Platform_SelectedIndexChanged);
            // 
            // lbl_Platform
            // 
            this.lbl_Platform.AutoSize = true;
            this.lbl_Platform.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_Platform.Location = new System.Drawing.Point(369, 59);
            this.lbl_Platform.Name = "lbl_Platform";
            this.lbl_Platform.Size = new System.Drawing.Size(72, 20);
            this.lbl_Platform.TabIndex = 7;
            this.lbl_Platform.Text = "Platform:";
            // 
            // dgvx_SelectedExecutablesInSolution
            // 
            this.dgvx_SelectedExecutablesInSolution.AllowUserToAddRows = false;
            this.dgvx_SelectedExecutablesInSolution.AllowUserToDeleteRows = false;
            this.dgvx_SelectedExecutablesInSolution.AllowUserToOrderColumns = true;
            this.dgvx_SelectedExecutablesInSolution.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvx_SelectedExecutablesInSolution.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvx_SelectedExecutablesInSolution.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvx_SelectedExecutablesInSolution.DataGridViewWithRowNumber = true;
            this.dgvx_SelectedExecutablesInSolution.Location = new System.Drawing.Point(3, 34);
            this.dgvx_SelectedExecutablesInSolution.Name = "dgvx_SelectedExecutablesInSolution";
            this.dgvx_SelectedExecutablesInSolution.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvx_SelectedExecutablesInSolution.Size = new System.Drawing.Size(901, 255);
            this.dgvx_SelectedExecutablesInSolution.TabIndex = 9;
            this.dgvx_SelectedExecutablesInSolution.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvx_SelectedExecutablesInSolution_CellEndEdit);
            this.dgvx_SelectedExecutablesInSolution.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvx_SelectedExecutablesInSolution_CellMouseUp);
            this.dgvx_SelectedExecutablesInSolution.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvx_SelectedExecutablesInSolution_CellValidated);
            // 
            // lbl_ExecutablesInSolution
            // 
            this.lbl_ExecutablesInSolution.AutoSize = true;
            this.lbl_ExecutablesInSolution.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_ExecutablesInSolution.Location = new System.Drawing.Point(3, 11);
            this.lbl_ExecutablesInSolution.Name = "lbl_ExecutablesInSolution";
            this.lbl_ExecutablesInSolution.Size = new System.Drawing.Size(174, 20);
            this.lbl_ExecutablesInSolution.TabIndex = 10;
            this.lbl_ExecutablesInSolution.Text = "Executables in Solution";
            // 
            // dgvx_Libraries
            // 
            this.dgvx_Libraries.AllowUserToAddRows = false;
            this.dgvx_Libraries.AllowUserToDeleteRows = false;
            this.dgvx_Libraries.AllowUserToOrderColumns = true;
            this.dgvx_Libraries.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvx_Libraries.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvx_Libraries.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvx_Libraries.DataGridViewWithRowNumber = true;
            this.dgvx_Libraries.Location = new System.Drawing.Point(7, 38);
            this.dgvx_Libraries.Name = "dgvx_Libraries";
            this.dgvx_Libraries.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvx_Libraries.Size = new System.Drawing.Size(431, 261);
            this.dgvx_Libraries.TabIndex = 11;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(21, 98);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgvx_SelectedExecutablesInSolution);
            this.splitContainer1.Panel1.Controls.Add(this.lbl_ExecutablesInSolution);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(907, 598);
            this.splitContainer1.SplitterDistance = 292;
            this.splitContainer1.TabIndex = 12;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.lbl_ProjectLibraries);
            this.splitContainer2.Panel1.Controls.Add(this.dgvx_Libraries);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.lbl_External_References);
            this.splitContainer2.Panel2.Controls.Add(this.dgvx_ExternalDLLReferences);
            this.splitContainer2.Size = new System.Drawing.Size(907, 302);
            this.splitContainer2.SplitterDistance = 441;
            this.splitContainer2.TabIndex = 0;
            // 
            // lbl_ProjectLibraries
            // 
            this.lbl_ProjectLibraries.AutoSize = true;
            this.lbl_ProjectLibraries.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_ProjectLibraries.Location = new System.Drawing.Point(3, 15);
            this.lbl_ProjectLibraries.Name = "lbl_ProjectLibraries";
            this.lbl_ProjectLibraries.Size = new System.Drawing.Size(165, 20);
            this.lbl_ProjectLibraries.TabIndex = 11;
            this.lbl_ProjectLibraries.Text = "Library (DLL)  Projects";
            // 
            // lbl_External_References
            // 
            this.lbl_External_References.AutoSize = true;
            this.lbl_External_References.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_External_References.Location = new System.Drawing.Point(3, 15);
            this.lbl_External_References.Name = "lbl_External_References";
            this.lbl_External_References.Size = new System.Drawing.Size(198, 20);
            this.lbl_External_References.TabIndex = 12;
            this.lbl_External_References.Text = "External (DLL) References";
            // 
            // dgvx_ExternalDLLReferences
            // 
            this.dgvx_ExternalDLLReferences.AllowUserToAddRows = false;
            this.dgvx_ExternalDLLReferences.AllowUserToDeleteRows = false;
            this.dgvx_ExternalDLLReferences.AllowUserToOrderColumns = true;
            this.dgvx_ExternalDLLReferences.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvx_ExternalDLLReferences.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvx_ExternalDLLReferences.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvx_ExternalDLLReferences.DataGridViewWithRowNumber = true;
            this.dgvx_ExternalDLLReferences.Location = new System.Drawing.Point(3, 38);
            this.dgvx_ExternalDLLReferences.Name = "dgvx_ExternalDLLReferences";
            this.dgvx_ExternalDLLReferences.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvx_ExternalDLLReferences.Size = new System.Drawing.Size(456, 261);
            this.dgvx_ExternalDLLReferences.TabIndex = 12;
            // 
            // btn_NSIS
            // 
            this.btn_NSIS.Location = new System.Drawing.Point(761, 59);
            this.btn_NSIS.Name = "btn_NSIS";
            this.btn_NSIS.Size = new System.Drawing.Size(164, 33);
            this.btn_NSIS.TabIndex = 14;
            this.btn_NSIS.Text = "NSIS installer";
            this.btn_NSIS.UseVisualStyleBackColor = true;
            this.btn_NSIS.Click += new System.EventHandler(this.btn_NSIS_Click);
            // 
            // btn_INNO_Installer
            // 
            this.btn_INNO_Installer.Location = new System.Drawing.Point(761, 11);
            this.btn_INNO_Installer.Name = "btn_INNO_Installer";
            this.btn_INNO_Installer.Size = new System.Drawing.Size(164, 33);
            this.btn_INNO_Installer.TabIndex = 15;
            this.btn_INNO_Installer.Text = "INNO  installer";
            this.btn_INNO_Installer.UseVisualStyleBackColor = true;
            this.btn_INNO_Installer.Click += new System.EventHandler(this.btn_INNO_Installer_Click);
            // 
            // usrc_SelectFile1
            // 
            this.usrc_SelectFile1.DefaultExtension = "sln";
            this.usrc_SelectFile1.Extension = "";
            this.usrc_SelectFile1.FileName = "";
            this.usrc_SelectFile1.Location = new System.Drawing.Point(118, 12);
            this.usrc_SelectFile1.Name = "usrc_SelectFile1";
            this.usrc_SelectFile1.Path = "";
            this.usrc_SelectFile1.Size = new System.Drawing.Size(525, 32);
            this.usrc_SelectFile1.TabIndex = 13;
            this.usrc_SelectFile1.ExistingFileChanged += new SolutionExplorer.usrc_SelectFile.delegate_ExistingFileChanged(this.usrc_SelectFile1_ExistingFileChanged);
            // 
            // Form_SolutionExplorer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(940, 834);
            this.Controls.Add(this.btn_INNO_Installer);
            this.Controls.Add(this.btn_NSIS);
            this.Controls.Add(this.usrc_SelectFile1);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.cmb_Platform);
            this.Controls.Add(this.lbl_Platform);
            this.Controls.Add(this.cmb_Configuration);
            this.Controls.Add(this.lbl_ConfigurationName);
            this.Controls.Add(this.lbl_Solution_File);
            this.Controls.Add(this.txt_Projects);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_SolutionExplorer";
            this.Text = "Solution Explorer";
            this.Load += new System.EventHandler(this.Form_SolutionExplorer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvx_SelectedExecutablesInSolution)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvx_Libraries)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvx_ExternalDLLReferences)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        private System.Windows.Forms.TextBox txt_Projects;
        private System.Windows.Forms.Label lbl_Solution_File;
        private System.Windows.Forms.Label lbl_ConfigurationName;
        private System.Windows.Forms.ComboBox cmb_Configuration;
        private System.Windows.Forms.ComboBox cmb_Platform;
        private System.Windows.Forms.Label lbl_Platform;
        private DataGridView_2xls.DataGridView2xls dgvx_SelectedExecutablesInSolution;
        private System.Windows.Forms.Label lbl_ExecutablesInSolution;
        private DataGridView_2xls.DataGridView2xls dgvx_Libraries;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Label lbl_ProjectLibraries;
        private System.Windows.Forms.Label lbl_External_References;
        private DataGridView_2xls.DataGridView2xls dgvx_ExternalDLLReferences;
        private usrc_SelectFile usrc_SelectFile1;
        private System.Windows.Forms.Button btn_NSIS;
        private System.Windows.Forms.Button btn_INNO_Installer;
    }
}
