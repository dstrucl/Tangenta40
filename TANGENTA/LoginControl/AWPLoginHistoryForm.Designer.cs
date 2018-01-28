namespace LoginControl
{
    partial class AWPLoginHistoryForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AWPLoginHistoryForm));
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.lbl_LoginHistory = new System.Windows.Forms.Label();
            this.lbl_From = new System.Windows.Forms.Label();
            this.lbl_To = new System.Windows.Forms.Label();
            this.dtp_From = new System.Windows.Forms.DateTimePicker();
            this.dtp_To = new System.Windows.Forms.DateTimePicker();
            this.btn_Refresh = new System.Windows.Forms.Button();
            this.dgv_LoginHistory = new DataGridView_2xls.DataGridView2xls();
            this.lbl_TotalTimeSpan = new System.Windows.Forms.Label();
            this.lbl_WorkHoursResult = new System.Windows.Forms.Label();
            this.usrc_Help1 = new HUDCMS.usrc_Help();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_LoginHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Cancel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_Cancel.Image = ((System.Drawing.Image)(resources.GetObject("btn_Cancel.Image")));
            this.btn_Cancel.Location = new System.Drawing.Point(371, 573);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(74, 30);
            this.btn_Cancel.TabIndex = 2;
            this.btn_Cancel.UseVisualStyleBackColor = false;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // lbl_LoginHistory
            // 
            this.lbl_LoginHistory.AutoSize = true;
            this.lbl_LoginHistory.Location = new System.Drawing.Point(12, 9);
            this.lbl_LoginHistory.Name = "lbl_LoginHistory";
            this.lbl_LoginHistory.Size = new System.Drawing.Size(42, 13);
            this.lbl_LoginHistory.TabIndex = 4;
            this.lbl_LoginHistory.Text = "History:";
            // 
            // lbl_From
            // 
            this.lbl_From.AutoSize = true;
            this.lbl_From.Location = new System.Drawing.Point(30, 37);
            this.lbl_From.Name = "lbl_From";
            this.lbl_From.Size = new System.Drawing.Size(30, 13);
            this.lbl_From.TabIndex = 5;
            this.lbl_From.Text = "From";
            // 
            // lbl_To
            // 
            this.lbl_To.AutoSize = true;
            this.lbl_To.Location = new System.Drawing.Point(339, 37);
            this.lbl_To.Name = "lbl_To";
            this.lbl_To.Size = new System.Drawing.Size(20, 13);
            this.lbl_To.TabIndex = 6;
            this.lbl_To.Text = "To";
            // 
            // dtp_From
            // 
            this.dtp_From.Location = new System.Drawing.Point(133, 33);
            this.dtp_From.Name = "dtp_From";
            this.dtp_From.Size = new System.Drawing.Size(200, 20);
            this.dtp_From.TabIndex = 7;
            // 
            // dtp_To
            // 
            this.dtp_To.Location = new System.Drawing.Point(374, 32);
            this.dtp_To.Name = "dtp_To";
            this.dtp_To.Size = new System.Drawing.Size(200, 20);
            this.dtp_To.TabIndex = 8;
            // 
            // btn_Refresh
            // 
            this.btn_Refresh.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_Refresh.Location = new System.Drawing.Point(596, 30);
            this.btn_Refresh.Name = "btn_Refresh";
            this.btn_Refresh.Size = new System.Drawing.Size(108, 23);
            this.btn_Refresh.TabIndex = 9;
            this.btn_Refresh.Text = "Refresh";
            this.btn_Refresh.UseVisualStyleBackColor = false;
            this.btn_Refresh.Click += new System.EventHandler(this.btn_Refresh_Click);
            // 
            // dgv_LoginHistory
            // 
            this.dgv_LoginHistory.AllowUserToAddRows = false;
            this.dgv_LoginHistory.AllowUserToDeleteRows = false;
            this.dgv_LoginHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_LoginHistory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgv_LoginHistory.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgv_LoginHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_LoginHistory.DataGridViewWithRowNumber = false;
            this.dgv_LoginHistory.Location = new System.Drawing.Point(10, 82);
            this.dgv_LoginHistory.Name = "dgv_LoginHistory";
            this.dgv_LoginHistory.ReadOnly = true;
            this.dgv_LoginHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_LoginHistory.Size = new System.Drawing.Size(753, 485);
            this.dgv_LoginHistory.TabIndex = 0;
            // 
            // lbl_TotalTimeSpan
            // 
            this.lbl_TotalTimeSpan.AutoSize = true;
            this.lbl_TotalTimeSpan.Location = new System.Drawing.Point(13, 60);
            this.lbl_TotalTimeSpan.Name = "lbl_TotalTimeSpan";
            this.lbl_TotalTimeSpan.Size = new System.Drawing.Size(69, 13);
            this.lbl_TotalTimeSpan.TabIndex = 10;
            this.lbl_TotalTimeSpan.Text = "Working time";
            // 
            // lbl_WorkHoursResult
            // 
            this.lbl_WorkHoursResult.AutoSize = true;
            this.lbl_WorkHoursResult.Location = new System.Drawing.Point(175, 60);
            this.lbl_WorkHoursResult.Name = "lbl_WorkHoursResult";
            this.lbl_WorkHoursResult.Size = new System.Drawing.Size(107, 13);
            this.lbl_WorkHoursResult.TabIndex = 11;
            this.lbl_WorkHoursResult.Text = "lbl_WorkHoursResult";
            // 
            // usrc_Help1
            // 
            this.usrc_Help1.Location = new System.Drawing.Point(706, 1);
            this.usrc_Help1.Name = "usrc_Help1";
            this.usrc_Help1.Size = new System.Drawing.Size(56, 23);
            this.usrc_Help1.TabIndex = 12;
            // 
            // AWPLoginHistoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(774, 613);
            this.Controls.Add(this.usrc_Help1);
            this.Controls.Add(this.lbl_WorkHoursResult);
            this.Controls.Add(this.lbl_TotalTimeSpan);
            this.Controls.Add(this.btn_Refresh);
            this.Controls.Add(this.dtp_To);
            this.Controls.Add(this.dtp_From);
            this.Controls.Add(this.lbl_To);
            this.Controls.Add(this.lbl_From);
            this.Controls.Add(this.lbl_LoginHistory);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.dgv_LoginHistory);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AWPLoginHistoryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LoginHistoryForm";
            this.Load += new System.EventHandler(this.LoginHistoryForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_LoginHistory)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridView_2xls.DataGridView2xls dgv_LoginHistory;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Label lbl_LoginHistory;
        private System.Windows.Forms.Label lbl_From;
        private System.Windows.Forms.Label lbl_To;
        private System.Windows.Forms.DateTimePicker dtp_From;
        private System.Windows.Forms.DateTimePicker dtp_To;
        private System.Windows.Forms.Button btn_Refresh;
        private System.Windows.Forms.Label lbl_TotalTimeSpan;
        private System.Windows.Forms.Label lbl_WorkHoursResult;
        private HUDCMS.usrc_Help usrc_Help1;
    }
}