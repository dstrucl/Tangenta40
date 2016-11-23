namespace SolutionExplorer
{
    partial class Form_INNO_Setup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_INNO_Setup));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.txt_INNO_Script_File_Template = new DigitalRune.Windows.TextEditor.TextEditorControl();
            this.lbl_INNO_Script_Template = new System.Windows.Forms.Label();
            this.btn_Build_INNO_Script = new System.Windows.Forms.Button();
            this.usrc_SelectFile_INNO_Script_Template = new SolutionExplorer.usrc_SelectFile();
            this.txt_INNO_Script_File = new DigitalRune.Windows.TextEditor.TextEditorControl();
            this.usrc_SelectFile_INNO_Script_File = new SolutionExplorer.usrc_SelectFile();
            this.lbl_INNO_Output_Script_file = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.txt_INNO_Script_File_Template);
            this.splitContainer1.Panel1.Controls.Add(this.lbl_INNO_Script_Template);
            this.splitContainer1.Panel1.Controls.Add(this.btn_Build_INNO_Script);
            this.splitContainer1.Panel1.Controls.Add(this.usrc_SelectFile_INNO_Script_Template);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.txt_INNO_Script_File);
            this.splitContainer1.Panel2.Controls.Add(this.usrc_SelectFile_INNO_Script_File);
            this.splitContainer1.Panel2.Controls.Add(this.lbl_INNO_Output_Script_file);
            this.splitContainer1.Size = new System.Drawing.Size(989, 785);
            this.splitContainer1.SplitterDistance = 602;
            this.splitContainer1.TabIndex = 10;
            // 
            // txt_INNO_Script_File_Template
            // 
            this.txt_INNO_Script_File_Template.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_INNO_Script_File_Template.Location = new System.Drawing.Point(3, 70);
            this.txt_INNO_Script_File_Template.Name = "txt_INNO_Script_File_Template";
            this.txt_INNO_Script_File_Template.Size = new System.Drawing.Size(596, 712);
            this.txt_INNO_Script_File_Template.TabIndex = 9;
            // 
            // lbl_INNO_Script_Template
            // 
            this.lbl_INNO_Script_Template.AutoSize = true;
            this.lbl_INNO_Script_Template.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_INNO_Script_Template.Location = new System.Drawing.Point(3, 9);
            this.lbl_INNO_Script_Template.Name = "lbl_INNO_Script_Template";
            this.lbl_INNO_Script_Template.Size = new System.Drawing.Size(162, 20);
            this.lbl_INNO_Script_Template.TabIndex = 5;
            this.lbl_INNO_Script_Template.Text = "INNO Script Template";
            // 
            // btn_Build_INNO_Script
            // 
            this.btn_Build_INNO_Script.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Build_INNO_Script.Location = new System.Drawing.Point(444, 3);
            this.btn_Build_INNO_Script.Name = "btn_Build_INNO_Script";
            this.btn_Build_INNO_Script.Size = new System.Drawing.Size(141, 53);
            this.btn_Build_INNO_Script.TabIndex = 8;
            this.btn_Build_INNO_Script.Text = "Build INNO Srcipt file from Template";
            this.btn_Build_INNO_Script.UseVisualStyleBackColor = true;
            this.btn_Build_INNO_Script.Click += new System.EventHandler(this.btn_Build_INNO_Script_Click);
            // 
            // usrc_SelectFile_INNO_Script_Template
            // 
            this.usrc_SelectFile_INNO_Script_Template.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.usrc_SelectFile_INNO_Script_Template.DefaultExtension = "nsit";
            this.usrc_SelectFile_INNO_Script_Template.Extension = "";
            this.usrc_SelectFile_INNO_Script_Template.FileName = "";
            this.usrc_SelectFile_INNO_Script_Template.Location = new System.Drawing.Point(3, 32);
            this.usrc_SelectFile_INNO_Script_Template.Name = "usrc_SelectFile_INNO_Script_Template";
            this.usrc_SelectFile_INNO_Script_Template.Path = "";
            this.usrc_SelectFile_INNO_Script_Template.Size = new System.Drawing.Size(435, 32);
            this.usrc_SelectFile_INNO_Script_Template.TabIndex = 0;
            this.usrc_SelectFile_INNO_Script_Template.ExistingFileChanged += new SolutionExplorer.usrc_SelectFile.delegate_ExistingFileChanged(this.usrc_SelectFile_INNO_Script_Template_ExistingFileChanged);
            // 
            // txt_INNO_Script_File
            // 
            this.txt_INNO_Script_File.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_INNO_Script_File.Location = new System.Drawing.Point(3, 70);
            this.txt_INNO_Script_File.Name = "txt_INNO_Script_File";
            this.txt_INNO_Script_File.Size = new System.Drawing.Size(377, 712);
            this.txt_INNO_Script_File.TabIndex = 10;
            // 
            // usrc_SelectFile_INNO_Script_File
            // 
            this.usrc_SelectFile_INNO_Script_File.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.usrc_SelectFile_INNO_Script_File.DefaultExtension = "nsi";
            this.usrc_SelectFile_INNO_Script_File.Extension = "";
            this.usrc_SelectFile_INNO_Script_File.FileName = "";
            this.usrc_SelectFile_INNO_Script_File.Location = new System.Drawing.Point(3, 32);
            this.usrc_SelectFile_INNO_Script_File.Name = "usrc_SelectFile_INNO_Script_File";
            this.usrc_SelectFile_INNO_Script_File.Path = "";
            this.usrc_SelectFile_INNO_Script_File.Size = new System.Drawing.Size(377, 32);
            this.usrc_SelectFile_INNO_Script_File.TabIndex = 6;
            this.usrc_SelectFile_INNO_Script_File.ExistingFileChanged += new SolutionExplorer.usrc_SelectFile.delegate_ExistingFileChanged(this.usrc_SelectFile_INNO_Script_File_ExistingFileChanged);
            // 
            // lbl_INNO_Output_Script_file
            // 
            this.lbl_INNO_Output_Script_file.AutoSize = true;
            this.lbl_INNO_Output_Script_file.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_INNO_Output_Script_file.Location = new System.Drawing.Point(12, 9);
            this.lbl_INNO_Output_Script_file.Name = "lbl_INNO_Output_Script_file";
            this.lbl_INNO_Output_Script_file.Size = new System.Drawing.Size(169, 20);
            this.lbl_INNO_Output_Script_file.TabIndex = 7;
            this.lbl_INNO_Output_Script_file.Text = "INNO Output Script file";
            // 
            // Form_INNO_Setup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(989, 785);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_INNO_Setup";
            this.Text = "INNO Create Installer ";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_INNO_Setup_FormClosed);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private usrc_SelectFile usrc_SelectFile_INNO_Script_Template;
        private System.Windows.Forms.Label lbl_INNO_Script_Template;
        private System.Windows.Forms.Label lbl_INNO_Output_Script_file;
        private usrc_SelectFile usrc_SelectFile_INNO_Script_File;
        private System.Windows.Forms.Button btn_Build_INNO_Script;
        private DigitalRune.Windows.TextEditor.TextEditorControl txt_INNO_Script_File_Template;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private DigitalRune.Windows.TextEditor.TextEditorControl txt_INNO_Script_File;
    }
}