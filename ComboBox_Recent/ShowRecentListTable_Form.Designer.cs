namespace ComboBox_Recent
{
    partial class ShowRecentListTable_Form
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
            this.dgv_RecentItems = new System.Windows.Forms.DataGridView();
            this.btn_OK = new System.Windows.Forms.Button();
            this.txt_XmlFile = new System.Windows.Forms.TextBox();
            this.lbl_XmlFile = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_RecentItems)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_RecentItems
            // 
            this.dgv_RecentItems.AllowUserToAddRows = false;
            this.dgv_RecentItems.AllowUserToDeleteRows = false;
            this.dgv_RecentItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_RecentItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgv_RecentItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_RecentItems.Location = new System.Drawing.Point(3, 35);
            this.dgv_RecentItems.Name = "dgv_RecentItems";
            this.dgv_RecentItems.ReadOnly = true;
            this.dgv_RecentItems.Size = new System.Drawing.Size(865, 445);
            this.dgv_RecentItems.TabIndex = 0;
            // 
            // btn_OK
            // 
            this.btn_OK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_OK.Location = new System.Drawing.Point(394, 489);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(66, 26);
            this.btn_OK.TabIndex = 1;
            this.btn_OK.Text = "OK";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // txt_XmlFile
            // 
            this.txt_XmlFile.Location = new System.Drawing.Point(64, 9);
            this.txt_XmlFile.Name = "txt_XmlFile";
            this.txt_XmlFile.ReadOnly = true;
            this.txt_XmlFile.Size = new System.Drawing.Size(616, 20);
            this.txt_XmlFile.TabIndex = 2;
            // 
            // lbl_XmlFile
            // 
            this.lbl_XmlFile.AutoSize = true;
            this.lbl_XmlFile.Location = new System.Drawing.Point(12, 9);
            this.lbl_XmlFile.Name = "lbl_XmlFile";
            this.lbl_XmlFile.Size = new System.Drawing.Size(46, 13);
            this.lbl_XmlFile.TabIndex = 3;
            this.lbl_XmlFile.Text = "Xml File:";
            // 
            // ShowRecentListTable_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(869, 527);
            this.Controls.Add(this.lbl_XmlFile);
            this.Controls.Add(this.txt_XmlFile);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.dgv_RecentItems);
            this.Name = "ShowRecentListTable_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Recent List Table";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_RecentItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_RecentItems;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.TextBox txt_XmlFile;
        private System.Windows.Forms.Label lbl_XmlFile;
    }
}