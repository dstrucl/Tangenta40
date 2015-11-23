namespace LogFile
{
    partial class WriteLog2DB_Form
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
            this.components = new System.ComponentModel.Container();
            this.lbl_LogFile = new System.Windows.Forms.Label();
            this.lbl_Progress = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.timer_WriteLog = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // lbl_LogFile
            // 
            this.lbl_LogFile.Location = new System.Drawing.Point(8, 9);
            this.lbl_LogFile.Name = "lbl_LogFile";
            this.lbl_LogFile.Size = new System.Drawing.Size(447, 16);
            this.lbl_LogFile.TabIndex = 0;
            this.lbl_LogFile.Text = "label1";
            // 
            // lbl_Progress
            // 
            this.lbl_Progress.Location = new System.Drawing.Point(7, 37);
            this.lbl_Progress.Name = "lbl_Progress";
            this.lbl_Progress.Size = new System.Drawing.Size(448, 16);
            this.lbl_Progress.TabIndex = 1;
            this.lbl_Progress.Text = "label1";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(4, 64);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(455, 10);
            this.progressBar.TabIndex = 2;
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(183, 89);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(100, 23);
            this.btn_Cancel.TabIndex = 3;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // timer_WriteLog
            // 
            this.timer_WriteLog.Tick += new System.EventHandler(this.timer_WriteLog_Tick);
            // 
            // WriteLog2DB_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 120);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.lbl_Progress);
            this.Controls.Add(this.lbl_LogFile);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "WriteLog2DB_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WriteLog2DB_Form";
            this.Load += new System.EventHandler(this.WriteLog2DB_Form_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_LogFile;
        private System.Windows.Forms.Label lbl_Progress;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Timer timer_WriteLog;
    }
}