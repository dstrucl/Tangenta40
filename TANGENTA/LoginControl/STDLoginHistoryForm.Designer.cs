namespace LoginControl
{
    partial class STDLoginHistoryForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(STDLoginHistoryForm));
            this.dgv_LoginHistory = new DataGridView_2xls.DataGridView2xls();
            this.dgv_ActiveUsers = new DataGridView_2xls.DataGridView2xls();
            this.btn_OK = new System.Windows.Forms.Button();
            this.lbl_ActiveUsers = new System.Windows.Forms.Label();
            this.lbl_LoginHistory = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_LoginHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ActiveUsers)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_LoginHistory
            // 
            this.dgv_LoginHistory.AllowUserToAddRows = false;
            this.dgv_LoginHistory.AllowUserToDeleteRows = false;
            this.dgv_LoginHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_LoginHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_LoginHistory.Location = new System.Drawing.Point(3, 217);
            this.dgv_LoginHistory.Name = "dgv_LoginHistory";
            this.dgv_LoginHistory.ReadOnly = true;
            this.dgv_LoginHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_LoginHistory.Size = new System.Drawing.Size(841, 324);
            this.dgv_LoginHistory.TabIndex = 0;
            // 
            // dgv_ActiveUsers
            // 
            this.dgv_ActiveUsers.AllowUserToAddRows = false;
            this.dgv_ActiveUsers.AllowUserToDeleteRows = false;
            this.dgv_ActiveUsers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_ActiveUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_ActiveUsers.Location = new System.Drawing.Point(3, 27);
            this.dgv_ActiveUsers.Name = "dgv_ActiveUsers";
            this.dgv_ActiveUsers.ReadOnly = true;
            this.dgv_ActiveUsers.Size = new System.Drawing.Size(841, 134);
            this.dgv_ActiveUsers.TabIndex = 1;
            // 
            // btn_OK
            // 
            this.btn_OK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_OK.Location = new System.Drawing.Point(394, 558);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(69, 31);
            this.btn_OK.TabIndex = 2;
            this.btn_OK.Text = "OK";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // lbl_ActiveUsers
            // 
            this.lbl_ActiveUsers.AutoSize = true;
            this.lbl_ActiveUsers.Location = new System.Drawing.Point(6, 11);
            this.lbl_ActiveUsers.Name = "lbl_ActiveUsers";
            this.lbl_ActiveUsers.Size = new System.Drawing.Size(67, 13);
            this.lbl_ActiveUsers.TabIndex = 3;
            this.lbl_ActiveUsers.Text = "Active Users";
            // 
            // lbl_LoginHistory
            // 
            this.lbl_LoginHistory.AutoSize = true;
            this.lbl_LoginHistory.Location = new System.Drawing.Point(0, 192);
            this.lbl_LoginHistory.Name = "lbl_LoginHistory";
            this.lbl_LoginHistory.Size = new System.Drawing.Size(42, 13);
            this.lbl_LoginHistory.TabIndex = 4;
            this.lbl_LoginHistory.Text = "History:";
            // 
            // LoginHistoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(845, 591);
            this.Controls.Add(this.lbl_LoginHistory);
            this.Controls.Add(this.lbl_ActiveUsers);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.dgv_ActiveUsers);
            this.Controls.Add(this.dgv_LoginHistory);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LoginHistoryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LoginHistoryForm";
            this.Load += new System.EventHandler(this.LoginHistoryForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_LoginHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ActiveUsers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridView_2xls.DataGridView2xls dgv_LoginHistory;
        private DataGridView_2xls.DataGridView2xls dgv_ActiveUsers;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Label lbl_ActiveUsers;
        private System.Windows.Forms.Label lbl_LoginHistory;
    }
}