namespace Excell_Export
{
    partial class Progress_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Progress_Form));
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.lbl_Rows_Columns = new System.Windows.Forms.Label();
            this.lbl_Export_To_File = new System.Windows.Forms.Label();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.lbl_PercentDone = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 80);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(383, 9);
            this.progressBar.TabIndex = 0;
            this.progressBar.UseWaitCursor = true;
            // 
            // lbl_Rows_Columns
            // 
            this.lbl_Rows_Columns.AutoSize = true;
            this.lbl_Rows_Columns.Location = new System.Drawing.Point(23, 31);
            this.lbl_Rows_Columns.Name = "lbl_Rows_Columns";
            this.lbl_Rows_Columns.Size = new System.Drawing.Size(85, 13);
            this.lbl_Rows_Columns.TabIndex = 1;
            this.lbl_Rows_Columns.Text = "Rows x Columns";
            this.lbl_Rows_Columns.UseWaitCursor = true;
            // 
            // lbl_Export_To_File
            // 
            this.lbl_Export_To_File.AutoSize = true;
            this.lbl_Export_To_File.Location = new System.Drawing.Point(23, 9);
            this.lbl_Export_To_File.Name = "lbl_Export_To_File";
            this.lbl_Export_To_File.Size = new System.Drawing.Size(68, 13);
            this.lbl_Export_To_File.TabIndex = 2;
            this.lbl_Export_To_File.Text = "Export to file:";
            this.lbl_Export_To_File.UseWaitCursor = true;
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(158, 96);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 21);
            this.btn_Cancel.TabIndex = 3;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.UseWaitCursor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // lbl_PercentDone
            // 
            this.lbl_PercentDone.AutoSize = true;
            this.lbl_PercentDone.Location = new System.Drawing.Point(23, 57);
            this.lbl_PercentDone.Name = "lbl_PercentDone";
            this.lbl_PercentDone.Size = new System.Drawing.Size(78, 13);
            this.lbl_PercentDone.TabIndex = 4;
            this.lbl_PercentDone.Text = "Percent DONE";
            this.lbl_PercentDone.UseWaitCursor = true;
            // 
            // Progress_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 125);
            this.Controls.Add(this.lbl_PercentDone);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.lbl_Export_To_File);
            this.Controls.Add(this.lbl_Rows_Columns);
            this.Controls.Add(this.progressBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Progress_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.UseWaitCursor = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Progress_Form_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Cancel;
        internal System.Windows.Forms.ProgressBar progressBar;
        internal System.Windows.Forms.Label lbl_Rows_Columns;
        internal System.Windows.Forms.Label lbl_Export_To_File;
        internal System.Windows.Forms.Label lbl_PercentDone;
    }
}