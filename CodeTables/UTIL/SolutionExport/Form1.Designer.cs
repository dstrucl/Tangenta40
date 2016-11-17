namespace SolutionExport
{
    partial class Form1
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
            this.btn_Parse = new System.Windows.Forms.Button();
            this.txt_Projects = new System.Windows.Forms.TextBox();
            this.lbl_Solution_File = new System.Windows.Forms.Label();
            this.lbl_ConfigurationName = new System.Windows.Forms.Label();
            this.cmb_Configuration = new System.Windows.Forms.ComboBox();
            this.cmb_Platform = new System.Windows.Forms.ComboBox();
            this.lbl_Platform = new System.Windows.Forms.Label();
            this.usrc_SelectFile1 = new SolutionExport.usrc_SelectFile();
            this.SuspendLayout();
            // 
            // btn_Parse
            // 
            this.btn_Parse.Location = new System.Drawing.Point(16, 170);
            this.btn_Parse.Name = "btn_Parse";
            this.btn_Parse.Size = new System.Drawing.Size(129, 44);
            this.btn_Parse.TabIndex = 1;
            this.btn_Parse.Text = "Parse";
            this.btn_Parse.UseVisualStyleBackColor = true;
            this.btn_Parse.Click += new System.EventHandler(this.btn_Parse_Click);
            // 
            // txt_Projects
            // 
            this.txt_Projects.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Projects.Location = new System.Drawing.Point(22, 289);
            this.txt_Projects.Multiline = true;
            this.txt_Projects.Name = "txt_Projects";
            this.txt_Projects.Size = new System.Drawing.Size(560, 512);
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
            this.cmb_Configuration.Size = new System.Drawing.Size(150, 28);
            this.cmb_Configuration.TabIndex = 6;
            this.cmb_Configuration.SelectedIndexChanged += new System.EventHandler(this.cmb_Configuration_SelectedIndexChanged);
            // 
            // cmb_Platform
            // 
            this.cmb_Platform.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cmb_Platform.FormattingEnabled = true;
            this.cmb_Platform.Location = new System.Drawing.Point(183, 94);
            this.cmb_Platform.Name = "cmb_Platform";
            this.cmb_Platform.Size = new System.Drawing.Size(150, 28);
            this.cmb_Platform.TabIndex = 8;
            // 
            // lbl_Platform
            // 
            this.lbl_Platform.AutoSize = true;
            this.lbl_Platform.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_Platform.Location = new System.Drawing.Point(18, 98);
            this.lbl_Platform.Name = "lbl_Platform";
            this.lbl_Platform.Size = new System.Drawing.Size(72, 20);
            this.lbl_Platform.TabIndex = 7;
            this.lbl_Platform.Text = "Platform:";
            // 
            // usrc_SelectFile1
            // 
            this.usrc_SelectFile1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.usrc_SelectFile1.DefaultExtension = "sln";
            this.usrc_SelectFile1.Extension = "";
            this.usrc_SelectFile1.FileName = "";
            this.usrc_SelectFile1.Location = new System.Drawing.Point(119, 13);
            this.usrc_SelectFile1.Name = "usrc_SelectFile1";
            this.usrc_SelectFile1.Path = "";
            this.usrc_SelectFile1.Size = new System.Drawing.Size(463, 32);
            this.usrc_SelectFile1.TabIndex = 3;
            this.usrc_SelectFile1.ExistingFileChanged += new SolutionExport.usrc_SelectFile.delegate_ExistingFileChanged(this.usrc_SelectFile1_ExistingFileChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 813);
            this.Controls.Add(this.cmb_Platform);
            this.Controls.Add(this.lbl_Platform);
            this.Controls.Add(this.cmb_Configuration);
            this.Controls.Add(this.lbl_ConfigurationName);
            this.Controls.Add(this.lbl_Solution_File);
            this.Controls.Add(this.usrc_SelectFile1);
            this.Controls.Add(this.txt_Projects);
            this.Controls.Add(this.btn_Parse);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_Parse;
        private System.Windows.Forms.TextBox txt_Projects;
        private usrc_SelectFile usrc_SelectFile1;
        private System.Windows.Forms.Label lbl_Solution_File;
        private System.Windows.Forms.Label lbl_ConfigurationName;
        private System.Windows.Forms.ComboBox cmb_Configuration;
        private System.Windows.Forms.ComboBox cmb_Platform;
        private System.Windows.Forms.Label lbl_Platform;
    }
}

