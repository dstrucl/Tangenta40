namespace Tangenta
{
    partial class Form_Select_TimeSpan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Select_TimeSpan));
            this.btn_OK = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.dateTimePicker_From = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_To = new System.Windows.Forms.DateTimePicker();
            this.lbl_From = new System.Windows.Forms.Label();
            this.lbl_To = new System.Windows.Forms.Label();
            this.rdb_All = new System.Windows.Forms.RadioButton();
            this.rdb_CurrentDay = new System.Windows.Forms.RadioButton();
            this.rdb_ThisWeek = new System.Windows.Forms.RadioButton();
            this.rdb_LastMonth = new System.Windows.Forms.RadioButton();
            this.rdb_ThisYear = new System.Windows.Forms.RadioButton();
            this.rdb_TimeSpan = new System.Windows.Forms.RadioButton();
            this.rdb_ThisMonth = new System.Windows.Forms.RadioButton();
            this.rdb_LastYear = new System.Windows.Forms.RadioButton();
            this.rdb_LastWeek = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // btn_OK
            // 
            this.btn_OK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_OK.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_OK.Location = new System.Drawing.Point(254, 173);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(81, 34);
            this.btn_OK.TabIndex = 0;
            this.btn_OK.Text = "OK";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_Cancel.Image = global::Tangenta.Properties.Resources.Exit;
            this.btn_Cancel.Location = new System.Drawing.Point(386, 173);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(81, 34);
            this.btn_Cancel.TabIndex = 1;
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // dateTimePicker_From
            // 
            this.dateTimePicker_From.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.dateTimePicker_From.Location = new System.Drawing.Point(100, 119);
            this.dateTimePicker_From.Name = "dateTimePicker_From";
            this.dateTimePicker_From.Size = new System.Drawing.Size(271, 38);
            this.dateTimePicker_From.TabIndex = 2;
            // 
            // dateTimePicker_To
            // 
            this.dateTimePicker_To.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.dateTimePicker_To.Location = new System.Drawing.Point(510, 118);
            this.dateTimePicker_To.Name = "dateTimePicker_To";
            this.dateTimePicker_To.Size = new System.Drawing.Size(271, 38);
            this.dateTimePicker_To.TabIndex = 3;
            // 
            // lbl_From
            // 
            this.lbl_From.AutoSize = true;
            this.lbl_From.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_From.Location = new System.Drawing.Point(17, 122);
            this.lbl_From.Name = "lbl_From";
            this.lbl_From.Size = new System.Drawing.Size(50, 31);
            this.lbl_From.TabIndex = 4;
            this.lbl_From.Text = "Od";
            // 
            // lbl_To
            // 
            this.lbl_To.AutoSize = true;
            this.lbl_To.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_To.Location = new System.Drawing.Point(421, 121);
            this.lbl_To.Name = "lbl_To";
            this.lbl_To.Size = new System.Drawing.Size(44, 31);
            this.lbl_To.TabIndex = 5;
            this.lbl_To.Text = "do";
            // 
            // rdb_All
            // 
            this.rdb_All.AutoSize = true;
            this.rdb_All.Checked = true;
            this.rdb_All.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rdb_All.Location = new System.Drawing.Point(27, 10);
            this.rdb_All.Name = "rdb_All";
            this.rdb_All.Size = new System.Drawing.Size(58, 33);
            this.rdb_All.TabIndex = 6;
            this.rdb_All.TabStop = true;
            this.rdb_All.Text = "All";
            this.rdb_All.UseVisualStyleBackColor = true;
            // 
            // rdb_CurrentDay
            // 
            this.rdb_CurrentDay.AutoSize = true;
            this.rdb_CurrentDay.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rdb_CurrentDay.Location = new System.Drawing.Point(116, 10);
            this.rdb_CurrentDay.Name = "rdb_CurrentDay";
            this.rdb_CurrentDay.Size = new System.Drawing.Size(99, 33);
            this.rdb_CurrentDay.TabIndex = 7;
            this.rdb_CurrentDay.Text = "Today";
            this.rdb_CurrentDay.UseVisualStyleBackColor = true;
            // 
            // rdb_ThisWeek
            // 
            this.rdb_ThisWeek.AutoSize = true;
            this.rdb_ThisWeek.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rdb_ThisWeek.Location = new System.Drawing.Point(250, 10);
            this.rdb_ThisWeek.Name = "rdb_ThisWeek";
            this.rdb_ThisWeek.Size = new System.Drawing.Size(146, 33);
            this.rdb_ThisWeek.TabIndex = 8;
            this.rdb_ThisWeek.Text = "This Week";
            this.rdb_ThisWeek.UseVisualStyleBackColor = true;
            // 
            // rdb_LastMonth
            // 
            this.rdb_LastMonth.AutoSize = true;
            this.rdb_LastMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rdb_LastMonth.Location = new System.Drawing.Point(23, 66);
            this.rdb_LastMonth.Name = "rdb_LastMonth";
            this.rdb_LastMonth.Size = new System.Drawing.Size(147, 33);
            this.rdb_LastMonth.TabIndex = 9;
            this.rdb_LastMonth.Text = "Last Month";
            this.rdb_LastMonth.UseVisualStyleBackColor = true;
            // 
            // rdb_ThisYear
            // 
            this.rdb_ThisYear.AutoSize = true;
            this.rdb_ThisYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rdb_ThisYear.Location = new System.Drawing.Point(205, 66);
            this.rdb_ThisYear.Name = "rdb_ThisYear";
            this.rdb_ThisYear.Size = new System.Drawing.Size(135, 33);
            this.rdb_ThisYear.TabIndex = 10;
            this.rdb_ThisYear.Text = "This Year";
            this.rdb_ThisYear.UseVisualStyleBackColor = true;
            // 
            // rdb_TimeSpan
            // 
            this.rdb_TimeSpan.AutoSize = true;
            this.rdb_TimeSpan.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rdb_TimeSpan.Location = new System.Drawing.Point(581, 65);
            this.rdb_TimeSpan.Name = "rdb_TimeSpan";
            this.rdb_TimeSpan.Size = new System.Drawing.Size(149, 33);
            this.rdb_TimeSpan.TabIndex = 11;
            this.rdb_TimeSpan.Text = "Time Span";
            this.rdb_TimeSpan.UseVisualStyleBackColor = true;
            // 
            // rdb_ThisMonth
            // 
            this.rdb_ThisMonth.AutoSize = true;
            this.rdb_ThisMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rdb_ThisMonth.Location = new System.Drawing.Point(645, 12);
            this.rdb_ThisMonth.Name = "rdb_ThisMonth";
            this.rdb_ThisMonth.Size = new System.Drawing.Size(150, 33);
            this.rdb_ThisMonth.TabIndex = 12;
            this.rdb_ThisMonth.Text = "This Month";
            this.rdb_ThisMonth.UseVisualStyleBackColor = true;
            // 
            // rdb_LastYear
            // 
            this.rdb_LastYear.AutoSize = true;
            this.rdb_LastYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rdb_LastYear.Location = new System.Drawing.Point(386, 66);
            this.rdb_LastYear.Name = "rdb_LastYear";
            this.rdb_LastYear.Size = new System.Drawing.Size(132, 33);
            this.rdb_LastYear.TabIndex = 13;
            this.rdb_LastYear.Text = "Last Year";
            this.rdb_LastYear.UseVisualStyleBackColor = true;
            // 
            // rdb_LastWeek
            // 
            this.rdb_LastWeek.AutoSize = true;
            this.rdb_LastWeek.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rdb_LastWeek.Location = new System.Drawing.Point(438, 10);
            this.rdb_LastWeek.Name = "rdb_LastWeek";
            this.rdb_LastWeek.Size = new System.Drawing.Size(143, 33);
            this.rdb_LastWeek.TabIndex = 14;
            this.rdb_LastWeek.Text = "Last Week";
            this.rdb_LastWeek.UseVisualStyleBackColor = true;
            // 
            // Form_Select_TimeSpan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(829, 219);
            this.Controls.Add(this.rdb_LastWeek);
            this.Controls.Add(this.rdb_LastYear);
            this.Controls.Add(this.rdb_ThisMonth);
            this.Controls.Add(this.rdb_TimeSpan);
            this.Controls.Add(this.rdb_ThisYear);
            this.Controls.Add(this.rdb_LastMonth);
            this.Controls.Add(this.rdb_ThisWeek);
            this.Controls.Add(this.rdb_CurrentDay);
            this.Controls.Add(this.rdb_All);
            this.Controls.Add(this.lbl_To);
            this.Controls.Add(this.lbl_From);
            this.Controls.Add(this.dateTimePicker_To);
            this.Controls.Add(this.dateTimePicker_From);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_OK);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_Select_TimeSpan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form_Select_TimeSpan";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.DateTimePicker dateTimePicker_From;
        private System.Windows.Forms.DateTimePicker dateTimePicker_To;
        private System.Windows.Forms.Label lbl_From;
        private System.Windows.Forms.Label lbl_To;
        private System.Windows.Forms.RadioButton rdb_All;
        private System.Windows.Forms.RadioButton rdb_CurrentDay;
        private System.Windows.Forms.RadioButton rdb_ThisWeek;
        private System.Windows.Forms.RadioButton rdb_LastMonth;
        private System.Windows.Forms.RadioButton rdb_ThisYear;
        private System.Windows.Forms.RadioButton rdb_TimeSpan;
        private System.Windows.Forms.RadioButton rdb_ThisMonth;
        private System.Windows.Forms.RadioButton rdb_LastYear;
        private System.Windows.Forms.RadioButton rdb_LastWeek;
    }
}