namespace DBSync
{
    partial class Form_GetDBType
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_GetDBType));
            this.lbl_SelectDataBase = new System.Windows.Forms.Label();
            this.rdb_SQLite = new System.Windows.Forms.RadioButton();
            this.rdb_MSSQL = new System.Windows.Forms.RadioButton();
            this.usrc_NavigationButtons1 = new NavigationButtons.usrc_NavigationButtons();
            this.SuspendLayout();
            // 
            // lbl_SelectDataBase
            // 
            this.lbl_SelectDataBase.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_SelectDataBase.Location = new System.Drawing.Point(15, 32);
            this.lbl_SelectDataBase.Name = "lbl_SelectDataBase";
            this.lbl_SelectDataBase.Size = new System.Drawing.Size(299, 32);
            this.lbl_SelectDataBase.TabIndex = 0;
            // 
            // rdb_SQLite
            // 
            this.rdb_SQLite.AutoSize = true;
            this.rdb_SQLite.Location = new System.Drawing.Point(74, 71);
            this.rdb_SQLite.Name = "rdb_SQLite";
            this.rdb_SQLite.Size = new System.Drawing.Size(57, 17);
            this.rdb_SQLite.TabIndex = 1;
            this.rdb_SQLite.TabStop = true;
            this.rdb_SQLite.Text = "SQLite";
            this.rdb_SQLite.UseVisualStyleBackColor = true;
            // 
            // rdb_MSSQL
            // 
            this.rdb_MSSQL.AutoSize = true;
            this.rdb_MSSQL.Location = new System.Drawing.Point(178, 71);
            this.rdb_MSSQL.Name = "rdb_MSSQL";
            this.rdb_MSSQL.Size = new System.Drawing.Size(62, 17);
            this.rdb_MSSQL.TabIndex = 2;
            this.rdb_MSSQL.TabStop = true;
            this.rdb_MSSQL.Text = "MSSQL";
            this.rdb_MSSQL.UseVisualStyleBackColor = true;
            // 
            // usrc_NavigationButtons1
            // 
            this.usrc_NavigationButtons1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.usrc_NavigationButtons1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.usrc_NavigationButtons1.btn1_ToolTip_Text = "";
            this.usrc_NavigationButtons1.btn2_ToolTip_Text = "";
            this.usrc_NavigationButtons1.btn3_ToolTip_Text = "";
            this.usrc_NavigationButtons1.Button_NEXT_Enabled = true;
            this.usrc_NavigationButtons1.Buttons = NavigationButtons.Navigation.eButtons.OkCancel;
            this.usrc_NavigationButtons1.ExitQuestion = "Exit Program?";
            this.usrc_NavigationButtons1.Image_Cancel = null;
            this.usrc_NavigationButtons1.Image_EXIT = null;
            this.usrc_NavigationButtons1.Image_NEXT = ((System.Drawing.Image)(resources.GetObject("usrc_NavigationButtons1.Image_NEXT")));
            this.usrc_NavigationButtons1.Image_OK = ((System.Drawing.Image)(resources.GetObject("usrc_NavigationButtons1.Image_OK")));
            this.usrc_NavigationButtons1.Image_PREV = ((System.Drawing.Image)(resources.GetObject("usrc_NavigationButtons1.Image_PREV")));
            this.usrc_NavigationButtons1.Location = new System.Drawing.Point(0, 0);
            this.usrc_NavigationButtons1.Name = "usrc_NavigationButtons1";
            this.usrc_NavigationButtons1.Size = new System.Drawing.Size(326, 27);
            this.usrc_NavigationButtons1.TabIndex = 3;
            this.usrc_NavigationButtons1.Text_Cancel = "Exit";
            this.usrc_NavigationButtons1.Text_EXIT = "Exit";
            this.usrc_NavigationButtons1.Text_NEXT = "";
            this.usrc_NavigationButtons1.Text_OK = "";
            this.usrc_NavigationButtons1.Text_PREV = "";
            this.usrc_NavigationButtons1.Visible_EXIT = true;
            this.usrc_NavigationButtons1.Visible_NEXT = true;
            this.usrc_NavigationButtons1.Visible_PREV = true;
            this.usrc_NavigationButtons1.ButtonPressed += new NavigationButtons.usrc_NavigationButtons.delegate_button_pressed(this.usrc_NavigationButtons1_ButtonPressed);
            // 
            // Form_GetDBType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(326, 100);
            this.Controls.Add(this.usrc_NavigationButtons1);
            this.Controls.Add(this.rdb_MSSQL);
            this.Controls.Add(this.rdb_SQLite);
            this.Controls.Add(this.lbl_SelectDataBase);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_GetDBType";
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_SelectDataBase;
        private System.Windows.Forms.RadioButton rdb_SQLite;
        private System.Windows.Forms.RadioButton rdb_MSSQL;
        private NavigationButtons.usrc_NavigationButtons usrc_NavigationButtons1;
    }
}