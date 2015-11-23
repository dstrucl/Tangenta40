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
            this.btn_OK = new System.Windows.Forms.Button();
            this.btn_Exit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_SelectDataBase
            // 
            this.lbl_SelectDataBase.AutoSize = true;
            this.lbl_SelectDataBase.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_SelectDataBase.Location = new System.Drawing.Point(12, 6);
            this.lbl_SelectDataBase.Name = "lbl_SelectDataBase";
            this.lbl_SelectDataBase.Size = new System.Drawing.Size(0, 20);
            this.lbl_SelectDataBase.TabIndex = 0;
            // 
            // rdb_SQLite
            // 
            this.rdb_SQLite.AutoSize = true;
            this.rdb_SQLite.Location = new System.Drawing.Point(17, 43);
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
            this.rdb_MSSQL.Location = new System.Drawing.Point(171, 43);
            this.rdb_MSSQL.Name = "rdb_MSSQL";
            this.rdb_MSSQL.Size = new System.Drawing.Size(62, 17);
            this.rdb_MSSQL.TabIndex = 2;
            this.rdb_MSSQL.TabStop = true;
            this.rdb_MSSQL.Text = "MSSQL";
            this.rdb_MSSQL.UseVisualStyleBackColor = true;
            // 
            // btn_OK
            // 
            this.btn_OK.Location = new System.Drawing.Point(69, 79);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(90, 32);
            this.btn_OK.TabIndex = 3;
            this.btn_OK.Text = "OK";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // btn_Exit
            // 
            this.btn_Exit.Image = global::DB.Properties.Resources.Exit;
            this.btn_Exit.Location = new System.Drawing.Point(143, 142);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(90, 32);
            this.btn_Exit.TabIndex = 4;
            this.btn_Exit.UseVisualStyleBackColor = true;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // Form_GetDBType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(249, 182);
            this.Controls.Add(this.btn_Exit);
            this.Controls.Add(this.btn_OK);
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
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Button btn_Exit;
    }
}