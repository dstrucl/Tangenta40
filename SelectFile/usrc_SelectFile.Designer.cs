namespace SelectFile
{
    partial class usrc_SelectFile
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txt_File = new System.Windows.Forms.TextBox();
            this.btn_Save = new System.Windows.Forms.Button();
            this.rbtn_Edit = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txt_File
            // 
            this.txt_File.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_File.Location = new System.Drawing.Point(127, 7);
            this.txt_File.Name = "txt_File";
            this.txt_File.Size = new System.Drawing.Size(557, 22);
            this.txt_File.TabIndex = 1;
            // 
            // btn_Save
            // 
            this.btn_Save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Save.DialogResult = System.Windows.Forms.DialogResult.Retry;
            this.btn_Save.Location = new System.Drawing.Point(690, 3);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(62, 26);
            this.btn_Save.TabIndex = 3;
            this.btn_Save.Text = "Save";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // rbtn_Edit
            // 
            this.rbtn_Edit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbtn_Edit.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbtn_Edit.Location = new System.Drawing.Point(758, 4);
            this.rbtn_Edit.Name = "rbtn_Edit";
            this.rbtn_Edit.Size = new System.Drawing.Size(62, 26);
            this.rbtn_Edit.TabIndex = 4;
            this.rbtn_Edit.Text = "Edit";
            this.rbtn_Edit.UseVisualStyleBackColor = true;
            this.rbtn_Edit.CheckedChanged += new System.EventHandler(this.rbtn_Edit_CheckedChanged);
            // 
            // usrc_SelectFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.rbtn_Edit);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.txt_File);
            this.Controls.Add(this.label1);
            this.Name = "usrc_SelectFile";
            this.Size = new System.Drawing.Size(831, 35);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_File;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.RadioButton rbtn_Edit;
    }
}
