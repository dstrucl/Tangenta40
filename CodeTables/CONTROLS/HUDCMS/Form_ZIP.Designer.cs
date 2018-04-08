namespace HUDCMS
{
    partial class Form_ZIP
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
            this.usrc_SelectFolder_OfHelp = new SelectFolder.usrc_SelectFolder();
            this.usrc_SelectFolder_DestinationFolder = new SelectFolder.usrc_SelectFolder();
            this.btn_Compress = new System.Windows.Forms.Button();
            this.lbl_Result = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // usrc_SelectFolder_OfHelp
            // 
            this.usrc_SelectFolder_OfHelp.InitialDirectory = "C:\\";
            this.usrc_SelectFolder_OfHelp.LabelText = "Help Folder";
            this.usrc_SelectFolder_OfHelp.Location = new System.Drawing.Point(12, 12);
            this.usrc_SelectFolder_OfHelp.Name = "usrc_SelectFolder_OfHelp";
            this.usrc_SelectFolder_OfHelp.SelectedFolder = "";
            this.usrc_SelectFolder_OfHelp.Size = new System.Drawing.Size(598, 25);
            this.usrc_SelectFolder_OfHelp.TabIndex = 0;
            this.usrc_SelectFolder_OfHelp.Title = "Select Folder";
            // 
            // usrc_SelectFolder_DestinationFolder
            // 
            this.usrc_SelectFolder_DestinationFolder.InitialDirectory = "C:\\";
            this.usrc_SelectFolder_DestinationFolder.LabelText = "DestinationFolder";
            this.usrc_SelectFolder_DestinationFolder.Location = new System.Drawing.Point(12, 43);
            this.usrc_SelectFolder_DestinationFolder.Name = "usrc_SelectFolder_DestinationFolder";
            this.usrc_SelectFolder_DestinationFolder.SelectedFolder = "";
            this.usrc_SelectFolder_DestinationFolder.Size = new System.Drawing.Size(598, 25);
            this.usrc_SelectFolder_DestinationFolder.TabIndex = 1;
            this.usrc_SelectFolder_DestinationFolder.Title = "Select Folder";
            // 
            // btn_Compress
            // 
            this.btn_Compress.Location = new System.Drawing.Point(214, 79);
            this.btn_Compress.Name = "btn_Compress";
            this.btn_Compress.Size = new System.Drawing.Size(179, 41);
            this.btn_Compress.TabIndex = 2;
            this.btn_Compress.Text = "Make Zip File";
            this.btn_Compress.UseVisualStyleBackColor = true;
            this.btn_Compress.Click += new System.EventHandler(this.btn_Compress_Click);
            // 
            // lbl_Result
            // 
            this.lbl_Result.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Result.Location = new System.Drawing.Point(14, 126);
            this.lbl_Result.Name = "lbl_Result";
            this.lbl_Result.Size = new System.Drawing.Size(596, 79);
            this.lbl_Result.TabIndex = 3;
            this.lbl_Result.Text = "Result:";
            // 
            // Form_ZIP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 206);
            this.Controls.Add(this.lbl_Result);
            this.Controls.Add(this.btn_Compress);
            this.Controls.Add(this.usrc_SelectFolder_DestinationFolder);
            this.Controls.Add(this.usrc_SelectFolder_OfHelp);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "Form_ZIP";
            this.Text = "Compress Help Files to ZIP file";
            this.Load += new System.EventHandler(this.Form_ZIP_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private SelectFolder.usrc_SelectFolder usrc_SelectFolder_OfHelp;
        private SelectFolder.usrc_SelectFolder usrc_SelectFolder_DestinationFolder;
        private System.Windows.Forms.Button btn_Compress;
        private System.Windows.Forms.Label lbl_Result;
    }
}