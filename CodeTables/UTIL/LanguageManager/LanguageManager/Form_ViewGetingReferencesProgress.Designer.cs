namespace LanguageManager
{
    partial class Form_ViewGetingReferencesProgress
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
            this.txt_output = new System.Windows.Forms.TextBox();
            this.btn_GetAllReferences = new System.Windows.Forms.Button();
            this.btn_write_lng_files = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txt_output
            // 
            this.txt_output.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_output.Location = new System.Drawing.Point(0, 37);
            this.txt_output.Multiline = true;
            this.txt_output.Name = "txt_output";
            this.txt_output.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_output.Size = new System.Drawing.Size(728, 475);
            this.txt_output.TabIndex = 0;
            // 
            // btn_GetAllReferences
            // 
            this.btn_GetAllReferences.Location = new System.Drawing.Point(12, 8);
            this.btn_GetAllReferences.Name = "btn_GetAllReferences";
            this.btn_GetAllReferences.Size = new System.Drawing.Size(146, 23);
            this.btn_GetAllReferences.TabIndex = 15;
            this.btn_GetAllReferences.Text = "Get all references";
            this.btn_GetAllReferences.UseVisualStyleBackColor = true;
            this.btn_GetAllReferences.Click += new System.EventHandler(this.btn_GetAllReferences_Click);
            // 
            // btn_write_lng_files
            // 
            this.btn_write_lng_files.Location = new System.Drawing.Point(201, 3);
            this.btn_write_lng_files.Name = "btn_write_lng_files";
            this.btn_write_lng_files.Size = new System.Drawing.Size(274, 32);
            this.btn_write_lng_files.TabIndex = 16;
            this.btn_write_lng_files.Text = "write \"lng.cs\" files";
            this.btn_write_lng_files.UseVisualStyleBackColor = true;
            this.btn_write_lng_files.Click += new System.EventHandler(this.btn_write_lng_files_Click);
            // 
            // Form_ViewGetingReferencesProgress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(728, 512);
            this.Controls.Add(this.btn_write_lng_files);
            this.Controls.Add(this.btn_GetAllReferences);
            this.Controls.Add(this.txt_output);
            this.Name = "Form_ViewGetingReferencesProgress";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form_ViewGetingReferencesProgress";
            this.Shown += new System.EventHandler(this.Form_ViewGetingReferencesProgress_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_output;
        private System.Windows.Forms.Button btn_GetAllReferences;
        private System.Windows.Forms.Button btn_write_lng_files;
    }
}