namespace HUDCMS
{
    partial class Form_SetGitExeFile
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
            this.btn_OK = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.usrc_SelectFile1 = new SelectFile.usrc_SelectFile();
            this.SuspendLayout();
            // 
            // btn_OK
            // 
            this.btn_OK.Location = new System.Drawing.Point(226, 50);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(75, 23);
            this.btn_OK.TabIndex = 1;
            this.btn_OK.Text = "OK";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(352, 50);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancel.TabIndex = 2;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // usrc_SelectFile1
            // 
            this.usrc_SelectFile1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.usrc_SelectFile1.ButtonEditVisible = false;
            this.usrc_SelectFile1.ButtonSelectText = "...";
            this.usrc_SelectFile1.DefaultExtension = "txt";
            this.usrc_SelectFile1.FileName = "";
            this.usrc_SelectFile1.Filter = "Exe files (*.exe)|*.exe|All files (*.*)|*.*";
            this.usrc_SelectFile1.InitialDirectory = "C:\\";
            this.usrc_SelectFile1.LabelText = "Set Git.exe file:";
            this.usrc_SelectFile1.Location = new System.Drawing.Point(0, 11);
            this.usrc_SelectFile1.Margin = new System.Windows.Forms.Padding(2);
            this.usrc_SelectFile1.Name = "usrc_SelectFile1";
            this.usrc_SelectFile1.Size = new System.Drawing.Size(619, 27);
            this.usrc_SelectFile1.TabIndex = 0;
            this.usrc_SelectFile1.Title = "Set Git.exe file:";
            this.usrc_SelectFile1.Type = SelectFile.usrc_SelectFile.eType.SELECT;
            // 
            // Form_SetGitExeFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 85);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.usrc_SelectFile1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "Form_SetGitExeFile";
            this.Text = "Form_SetGitExeFile";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_SetGitExeFile_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private SelectFile.usrc_SelectFile usrc_SelectFile1;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Button btn_Cancel;
    }
}