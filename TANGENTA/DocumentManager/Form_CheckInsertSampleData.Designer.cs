namespace DocumentManager
{
    partial class Form_CheckInsertSampleData
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_CheckInsertSampleData));
            this.lbl_Message1 = new System.Windows.Forms.Label();
            this.rdb_WritePredefinedDefaultDataInDataBase = new System.Windows.Forms.RadioButton();
            this.rdb_Enter_data_into_a_new_database_table = new System.Windows.Forms.RadioButton();
            this.lbl_Message2 = new System.Windows.Forms.Label();
            this.usrc_NavigationButtons1 = new NavigationButtons.usrc_NavigationButtons();
            this.SuspendLayout();
            // 
            // lbl_Message1
            // 
            this.lbl_Message1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Message1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_Message1.ForeColor = System.Drawing.Color.Blue;
            this.lbl_Message1.Location = new System.Drawing.Point(10, 43);
            this.lbl_Message1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_Message1.Name = "lbl_Message1";
            this.lbl_Message1.Size = new System.Drawing.Size(493, 90);
            this.lbl_Message1.TabIndex = 0;
            this.lbl_Message1.Text = resources.GetString("lbl_Message1.Text");
            // 
            // rdb_WritePredefinedDefaultDataInDataBase
            // 
            this.rdb_WritePredefinedDefaultDataInDataBase.AutoSize = true;
            this.rdb_WritePredefinedDefaultDataInDataBase.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rdb_WritePredefinedDefaultDataInDataBase.Location = new System.Drawing.Point(19, 136);
            this.rdb_WritePredefinedDefaultDataInDataBase.Margin = new System.Windows.Forms.Padding(2);
            this.rdb_WritePredefinedDefaultDataInDataBase.Name = "rdb_WritePredefinedDefaultDataInDataBase";
            this.rdb_WritePredefinedDefaultDataInDataBase.Size = new System.Drawing.Size(321, 22);
            this.rdb_WritePredefinedDefaultDataInDataBase.TabIndex = 2;
            this.rdb_WritePredefinedDefaultDataInDataBase.TabStop = true;
            this.rdb_WritePredefinedDefaultDataInDataBase.Text = "Write predefined data into a new database";
            this.rdb_WritePredefinedDefaultDataInDataBase.UseVisualStyleBackColor = true;
            // 
            // rdb_Enter_data_into_a_new_database_table
            // 
            this.rdb_Enter_data_into_a_new_database_table.AutoSize = true;
            this.rdb_Enter_data_into_a_new_database_table.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rdb_Enter_data_into_a_new_database_table.Location = new System.Drawing.Point(17, 245);
            this.rdb_Enter_data_into_a_new_database_table.Margin = new System.Windows.Forms.Padding(2);
            this.rdb_Enter_data_into_a_new_database_table.Name = "rdb_Enter_data_into_a_new_database_table";
            this.rdb_Enter_data_into_a_new_database_table.Size = new System.Drawing.Size(310, 22);
            this.rdb_Enter_data_into_a_new_database_table.TabIndex = 3;
            this.rdb_Enter_data_into_a_new_database_table.TabStop = true;
            this.rdb_Enter_data_into_a_new_database_table.Text = "Enter_data_into_a_new_database_table";
            this.rdb_Enter_data_into_a_new_database_table.UseVisualStyleBackColor = true;
            this.rdb_Enter_data_into_a_new_database_table.CheckedChanged += new System.EventHandler(this.rdb_Enter_data_into_a_new_database_table_CheckedChanged);
            // 
            // lbl_Message2
            // 
            this.lbl_Message2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Message2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_Message2.ForeColor = System.Drawing.Color.Blue;
            this.lbl_Message2.Location = new System.Drawing.Point(7, 198);
            this.lbl_Message2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_Message2.Name = "lbl_Message2";
            this.lbl_Message2.Size = new System.Drawing.Size(493, 45);
            this.lbl_Message2.TabIndex = 5;
            this.lbl_Message2.Text = "If you want to enter your data manually than select:";
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
            this.usrc_NavigationButtons1.ExitQuestion = "Exit Program?";
            this.usrc_NavigationButtons1.Image_Cancel = null;
            this.usrc_NavigationButtons1.Image_EXIT = null;
            this.usrc_NavigationButtons1.Image_NEXT = ((System.Drawing.Image)(resources.GetObject("usrc_NavigationButtons1.Image_NEXT")));
            this.usrc_NavigationButtons1.Image_OK = ((System.Drawing.Image)(resources.GetObject("usrc_NavigationButtons1.Image_OK")));
            this.usrc_NavigationButtons1.Image_PREV = ((System.Drawing.Image)(resources.GetObject("usrc_NavigationButtons1.Image_PREV")));
            this.usrc_NavigationButtons1.Location = new System.Drawing.Point(1, 0);
            this.usrc_NavigationButtons1.Name = "usrc_NavigationButtons1";
            this.usrc_NavigationButtons1.Size = new System.Drawing.Size(511, 28);
            this.usrc_NavigationButtons1.TabIndex = 6;
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
            // Form_CheckInsertSampleData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(512, 310);
            this.Controls.Add(this.usrc_NavigationButtons1);
            this.Controls.Add(this.lbl_Message2);
            this.Controls.Add(this.rdb_Enter_data_into_a_new_database_table);
            this.Controls.Add(this.rdb_WritePredefinedDefaultDataInDataBase);
            this.Controls.Add(this.lbl_Message1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form_CheckInsertSampleData";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form_CheckInsertSampleData";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_Message1;
        private System.Windows.Forms.RadioButton rdb_WritePredefinedDefaultDataInDataBase;
        private System.Windows.Forms.RadioButton rdb_Enter_data_into_a_new_database_table;
        private System.Windows.Forms.Label lbl_Message2;
        private NavigationButtons.usrc_NavigationButtons usrc_NavigationButtons1;
    }
}