namespace HUDCMS
{
    partial class Form_SetGitFolder
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
            this.usrc_SelectFolder1 = new SelectFolder.usrc_SelectFolder();
            this.btn_OK = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // usrc_SelectFolder1
            // 
            this.usrc_SelectFolder1.InitialDirectory = "C:\\";
            this.usrc_SelectFolder1.LabelText = "Git Folder";
            this.usrc_SelectFolder1.Location = new System.Drawing.Point(-2, 30);
            this.usrc_SelectFolder1.Name = "usrc_SelectFolder1";
            this.usrc_SelectFolder1.SelectedFolder = "";
            this.usrc_SelectFolder1.Size = new System.Drawing.Size(641, 25);
            this.usrc_SelectFolder1.TabIndex = 0;
            this.usrc_SelectFolder1.Title = "Select Folder";
            // 
            // btn_OK
            // 
            this.btn_OK.Location = new System.Drawing.Point(226, 71);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(88, 28);
            this.btn_OK.TabIndex = 1;
            this.btn_OK.Text = "OK";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(348, 71);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(88, 28);
            this.btn_Cancel.TabIndex = 2;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // Form_SetGitFolder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(643, 108);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.usrc_SelectFolder1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form_SetGitFolder";
            this.Text = "Set Git Folder";
            this.ResumeLayout(false);

        }

        #endregion

        private SelectFolder.usrc_SelectFolder usrc_SelectFolder1;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Button btn_Cancel;
    }
}