namespace ShopC_Forms
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
            this.usrc_Help1 = new HUDCMS.usrc_Help();
            this.rdb_ForDay = new System.Windows.Forms.RadioButton();
            this.dateTimePicker_ForDay = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // btn_OK
            // 
            this.btn_OK.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_OK.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_OK.Location = new System.Drawing.Point(581, 3);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(81, 34);
            this.btn_OK.TabIndex = 0;
            this.btn_OK.Text = "OK";
            this.btn_OK.UseVisualStyleBackColor = false;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_Cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_Cancel.Image = TangentaResources.Properties.Resources.Exit;
            this.btn_Cancel.Location = new System.Drawing.Point(668, 3);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(81, 34);
            this.btn_Cancel.TabIndex = 1;
            this.btn_Cancel.UseVisualStyleBackColor = false;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // dateTimePicker_From
            // 
            this.dateTimePicker_From.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.dateTimePicker_From.Location = new System.Drawing.Point(108, 252);
            this.dateTimePicker_From.Name = "dateTimePicker_From";
            this.dateTimePicker_From.Size = new System.Drawing.Size(525, 38);
            this.dateTimePicker_From.TabIndex = 2;
            // 
            // dateTimePicker_To
            // 
            this.dateTimePicker_To.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.dateTimePicker_To.Location = new System.Drawing.Point(119, 296);
            this.dateTimePicker_To.Name = "dateTimePicker_To";
            this.dateTimePicker_To.Size = new System.Drawing.Size(532, 38);
            this.dateTimePicker_To.TabIndex = 3;
            // 
            // lbl_From
            // 
            this.lbl_From.AutoSize = true;
            this.lbl_From.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_From.Location = new System.Drawing.Point(25, 255);
            this.lbl_From.Name = "lbl_From";
            this.lbl_From.Size = new System.Drawing.Size(50, 31);
            this.lbl_From.TabIndex = 4;
            this.lbl_From.Text = "Od";
            // 
            // lbl_To
            // 
            this.lbl_To.AutoSize = true;
            this.lbl_To.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_To.Location = new System.Drawing.Point(30, 299);
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
            this.rdb_All.Location = new System.Drawing.Point(30, 53);
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
            this.rdb_CurrentDay.Location = new System.Drawing.Point(119, 53);
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
            this.rdb_ThisWeek.Location = new System.Drawing.Point(253, 53);
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
            this.rdb_LastMonth.Location = new System.Drawing.Point(26, 109);
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
            this.rdb_ThisYear.Location = new System.Drawing.Point(208, 109);
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
            this.rdb_TimeSpan.Location = new System.Drawing.Point(30, 219);
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
            this.rdb_ThisMonth.Location = new System.Drawing.Point(648, 55);
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
            this.rdb_LastYear.Location = new System.Drawing.Point(389, 109);
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
            this.rdb_LastWeek.Location = new System.Drawing.Point(441, 53);
            this.rdb_LastWeek.Name = "rdb_LastWeek";
            this.rdb_LastWeek.Size = new System.Drawing.Size(143, 33);
            this.rdb_LastWeek.TabIndex = 14;
            this.rdb_LastWeek.Text = "Last Week";
            this.rdb_LastWeek.UseVisualStyleBackColor = true;
            // 
            // usrc_Help1
            // 
            this.usrc_Help1.Location = new System.Drawing.Point(767, 3);
            this.usrc_Help1.Name = "usrc_Help1";
            this.usrc_Help1.Size = new System.Drawing.Size(58, 34);
            this.usrc_Help1.TabIndex = 15;
            // 
            // rdb_ForDay
            // 
            this.rdb_ForDay.AutoSize = true;
            this.rdb_ForDay.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rdb_ForDay.Location = new System.Drawing.Point(31, 165);
            this.rdb_ForDay.Name = "rdb_ForDay";
            this.rdb_ForDay.Size = new System.Drawing.Size(109, 33);
            this.rdb_ForDay.TabIndex = 16;
            this.rdb_ForDay.Text = "ForDay";
            this.rdb_ForDay.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker_ForDay
            // 
            this.dateTimePicker_ForDay.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.dateTimePicker_ForDay.Location = new System.Drawing.Point(146, 165);
            this.dateTimePicker_ForDay.Name = "dateTimePicker_ForDay";
            this.dateTimePicker_ForDay.Size = new System.Drawing.Size(463, 38);
            this.dateTimePicker_ForDay.TabIndex = 17;
            // 
            // Form_Select_TimeSpan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(829, 352);
            this.Controls.Add(this.dateTimePicker_ForDay);
            this.Controls.Add(this.rdb_ForDay);
            this.Controls.Add(this.usrc_Help1);
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
        private HUDCMS.usrc_Help usrc_Help1;
        private System.Windows.Forms.RadioButton rdb_ForDay;
        private System.Windows.Forms.DateTimePicker dateTimePicker_ForDay;
    }
}