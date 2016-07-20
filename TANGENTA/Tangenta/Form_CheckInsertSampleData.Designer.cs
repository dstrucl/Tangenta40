namespace Tangenta
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
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.rdb_WritePredefinedDefaultDataInDataBase = new System.Windows.Forms.RadioButton();
            this.rdb_Enter_data_into_a_new_database_table = new System.Windows.Forms.RadioButton();
            this.btn_OK = new System.Windows.Forms.Button();
            this.lbl_Message2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_Message1
            // 
            this.lbl_Message1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Message1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_Message1.ForeColor = System.Drawing.Color.Blue;
            this.lbl_Message1.Location = new System.Drawing.Point(12, 10);
            this.lbl_Message1.Name = "lbl_Message1";
            this.lbl_Message1.Size = new System.Drawing.Size(616, 113);
            this.lbl_Message1.TabIndex = 0;
            this.lbl_Message1.Text = resources.GetString("lbl_Message1.Text");
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_Cancel.Location = new System.Drawing.Point(181, 323);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(112, 36);
            this.btn_Cancel.TabIndex = 1;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Visible = false;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // rdb_WritePredefinedDefaultDataInDataBase
            // 
            this.rdb_WritePredefinedDefaultDataInDataBase.AutoSize = true;
            this.rdb_WritePredefinedDefaultDataInDataBase.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rdb_WritePredefinedDefaultDataInDataBase.Location = new System.Drawing.Point(24, 126);
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
            this.rdb_Enter_data_into_a_new_database_table.Location = new System.Drawing.Point(21, 263);
            this.rdb_Enter_data_into_a_new_database_table.Name = "rdb_Enter_data_into_a_new_database_table";
            this.rdb_Enter_data_into_a_new_database_table.Size = new System.Drawing.Size(310, 22);
            this.rdb_Enter_data_into_a_new_database_table.TabIndex = 3;
            this.rdb_Enter_data_into_a_new_database_table.TabStop = true;
            this.rdb_Enter_data_into_a_new_database_table.Text = "Enter_data_into_a_new_database_table";
            this.rdb_Enter_data_into_a_new_database_table.UseVisualStyleBackColor = true;
            this.rdb_Enter_data_into_a_new_database_table.CheckedChanged += new System.EventHandler(this.rdb_Enter_data_into_a_new_database_table_CheckedChanged);
            // 
            // btn_OK
            // 
            this.btn_OK.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_OK.Location = new System.Drawing.Point(12, 323);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(112, 36);
            this.btn_OK.TabIndex = 4;
            this.btn_OK.Text = "OK";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // lbl_Message2
            // 
            this.lbl_Message2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Message2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_Message2.ForeColor = System.Drawing.Color.Blue;
            this.lbl_Message2.Location = new System.Drawing.Point(9, 204);
            this.lbl_Message2.Name = "lbl_Message2";
            this.lbl_Message2.Size = new System.Drawing.Size(616, 56);
            this.lbl_Message2.TabIndex = 5;
            this.lbl_Message2.Text = "If you want to enter your data manually than select:";
            this.lbl_Message2.Click += new System.EventHandler(this.lbl_Message2_Click);
            // 
            // Form_CheckInsertSampleData
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(640, 371);
            this.Controls.Add(this.lbl_Message2);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.rdb_Enter_data_into_a_new_database_table);
            this.Controls.Add(this.rdb_WritePredefinedDefaultDataInDataBase);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.lbl_Message1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form_CheckInsertSampleData";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form_CheckInsertSampleData";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_Message1;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.RadioButton rdb_WritePredefinedDefaultDataInDataBase;
        private System.Windows.Forms.RadioButton rdb_Enter_data_into_a_new_database_table;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Label lbl_Message2;
    }
}