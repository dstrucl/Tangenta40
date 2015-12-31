namespace LogFile
{
    partial class LogAttachments_Form
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
            this.rdb_Picture = new System.Windows.Forms.RadioButton();
            this.rdb_File = new System.Windows.Forms.RadioButton();
            this.picture_Box = new System.Windows.Forms.PictureBox();
            this.lbl_Attachment_Description = new System.Windows.Forms.Label();
            this.txt_AttachmentDescription = new System.Windows.Forms.TextBox();
            this.btn_Add = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_PasteOrSelect = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picture_Box)).BeginInit();
            this.SuspendLayout();
            // 
            // rdb_Picture
            // 
            this.rdb_Picture.AutoSize = true;
            this.rdb_Picture.Location = new System.Drawing.Point(28, 5);
            this.rdb_Picture.Name = "rdb_Picture";
            this.rdb_Picture.Size = new System.Drawing.Size(58, 17);
            this.rdb_Picture.TabIndex = 0;
            this.rdb_Picture.TabStop = true;
            this.rdb_Picture.Text = "Picture";
            this.rdb_Picture.UseVisualStyleBackColor = true;
            this.rdb_Picture.Visible = false;
            this.rdb_Picture.CheckedChanged += new System.EventHandler(this.rdb_Picture_CheckedChanged);
            // 
            // rdb_File
            // 
            this.rdb_File.AutoSize = true;
            this.rdb_File.Location = new System.Drawing.Point(101, 5);
            this.rdb_File.Name = "rdb_File";
            this.rdb_File.Size = new System.Drawing.Size(41, 17);
            this.rdb_File.TabIndex = 1;
            this.rdb_File.TabStop = true;
            this.rdb_File.Text = "File";
            this.rdb_File.UseVisualStyleBackColor = true;
            this.rdb_File.Visible = false;
            // 
            // picture_Box
            // 
            this.picture_Box.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picture_Box.Location = new System.Drawing.Point(9, 72);
            this.picture_Box.Name = "picture_Box";
            this.picture_Box.Size = new System.Drawing.Size(712, 341);
            this.picture_Box.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picture_Box.TabIndex = 2;
            this.picture_Box.TabStop = false;
            // 
            // lbl_Attachment_Description
            // 
            this.lbl_Attachment_Description.Location = new System.Drawing.Point(22, 24);
            this.lbl_Attachment_Description.Name = "lbl_Attachment_Description";
            this.lbl_Attachment_Description.Size = new System.Drawing.Size(83, 17);
            this.lbl_Attachment_Description.TabIndex = 3;
            this.lbl_Attachment_Description.Text = "Description:";
            this.lbl_Attachment_Description.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txt_AttachmentDescription
            // 
            this.txt_AttachmentDescription.Location = new System.Drawing.Point(111, 25);
            this.txt_AttachmentDescription.Name = "txt_AttachmentDescription";
            this.txt_AttachmentDescription.Size = new System.Drawing.Size(388, 20);
            this.txt_AttachmentDescription.TabIndex = 4;
            // 
            // btn_Add
            // 
            this.btn_Add.Location = new System.Drawing.Point(648, 6);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(74, 24);
            this.btn_Add.TabIndex = 5;
            this.btn_Add.Text = "Add";
            this.btn_Add.UseVisualStyleBackColor = true;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(648, 38);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(74, 24);
            this.btn_Cancel.TabIndex = 6;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_PasteOrSelect
            // 
            this.btn_PasteOrSelect.Location = new System.Drawing.Point(504, 23);
            this.btn_PasteOrSelect.Name = "btn_PasteOrSelect";
            this.btn_PasteOrSelect.Size = new System.Drawing.Size(92, 25);
            this.btn_PasteOrSelect.TabIndex = 7;
            this.btn_PasteOrSelect.Text = "Paste/Select";
            this.btn_PasteOrSelect.UseVisualStyleBackColor = true;
            this.btn_PasteOrSelect.Click += new System.EventHandler(this.btn_PasteOrSelect_Click);
            // 
            // LogAttachments_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(731, 419);
            this.Controls.Add(this.btn_PasteOrSelect);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_Add);
            this.Controls.Add(this.txt_AttachmentDescription);
            this.Controls.Add(this.lbl_Attachment_Description);
            this.Controls.Add(this.picture_Box);
            this.Controls.Add(this.rdb_File);
            this.Controls.Add(this.rdb_Picture);
            this.Name = "LogAttachments_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LogAttachments_Form";
            ((System.ComponentModel.ISupportInitialize)(this.picture_Box)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rdb_Picture;
        private System.Windows.Forms.RadioButton rdb_File;
        private System.Windows.Forms.PictureBox picture_Box;
        private System.Windows.Forms.Label lbl_Attachment_Description;
        private System.Windows.Forms.TextBox txt_AttachmentDescription;
        private System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_PasteOrSelect;
    }
}