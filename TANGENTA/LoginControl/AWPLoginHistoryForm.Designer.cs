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
            this.dgv_LoginHistory = new DataGridView_2xls.DataGridView2xls();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.lbl_LoginHistory = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_LoginHistory)).BeginInit();
            this.SuspendLayout();
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
            this.dgv_LoginHistory.Location = new System.Drawing.Point(13, 43);
            this.dgv_LoginHistory.Margin = new System.Windows.Forms.Padding(4);
            this.dgv_LoginHistory.Name = "dgv_LoginHistory";
            this.dgv_LoginHistory.ReadOnly = true;
            this.dgv_LoginHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_LoginHistory.Size = new System.Drawing.Size(941, 627);
            this.dgv_LoginHistory.TabIndex = 0;
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Cancel.Image = ((System.Drawing.Image)(resources.GetObject("btn_Cancel.Image")));
            this.btn_Cancel.Location = new System.Drawing.Point(464, 678);
            this.btn_Cancel.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(92, 38);
            this.btn_Cancel.TabIndex = 2;
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // lbl_LoginHistory
            // 
            this.lbl_LoginHistory.AutoSize = true;
            this.lbl_LoginHistory.Location = new System.Drawing.Point(13, 9);
            this.lbl_LoginHistory.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_LoginHistory.Name = "lbl_LoginHistory";
            this.lbl_LoginHistory.Size = new System.Drawing.Size(56, 17);
            this.lbl_LoginHistory.TabIndex = 4;
            this.lbl_LoginHistory.Text = "History:";
            // 
            // AWPLoginHistoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(967, 727);
            this.Controls.Add(this.lbl_LoginHistory);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.dgv_LoginHistory);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
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
    }
}