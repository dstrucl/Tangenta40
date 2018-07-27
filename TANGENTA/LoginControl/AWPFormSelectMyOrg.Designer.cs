namespace LoginControl
{
    partial class AWPFormSelectMyOrgPer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AWPFormSelectMyOrgPer));
            this.dgvx = new DataGridView_2xls.DataGridView2xls();
            this.btn_Select = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.lbl_SelectedPerson = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvx)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvx
            // 
            this.dgvx.AllowUserToAddRows = false;
            this.dgvx.AllowUserToDeleteRows = false;
            this.dgvx.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvx.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvx.DataGridViewWithRowNumber = false;
            this.dgvx.Location = new System.Drawing.Point(1, 34);
            this.dgvx.Name = "dgvx";
            this.dgvx.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvx.Size = new System.Drawing.Size(577, 359);
            this.dgvx.TabIndex = 0;
            // 
            // btn_Select
            // 
            this.btn_Select.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_Select.Image = ((System.Drawing.Image)(resources.GetObject("btn_Select.Image")));
            this.btn_Select.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Select.Location = new System.Drawing.Point(6, 3);
            this.btn_Select.Name = "btn_Select";
            this.btn_Select.Size = new System.Drawing.Size(121, 25);
            this.btn_Select.TabIndex = 1;
            this.btn_Select.Text = "Select Person";
            this.btn_Select.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Select.UseVisualStyleBackColor = false;
            this.btn_Select.Click += new System.EventHandler(this.btn_Select_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Cancel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_Cancel.Image = ((System.Drawing.Image)(resources.GetObject("btn_Cancel.Image")));
            this.btn_Cancel.Location = new System.Drawing.Point(509, 3);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(58, 25);
            this.btn_Cancel.TabIndex = 2;
            this.btn_Cancel.UseVisualStyleBackColor = false;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // lbl_SelectedPerson
            // 
            this.lbl_SelectedPerson.AutoSize = true;
            this.lbl_SelectedPerson.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_SelectedPerson.Location = new System.Drawing.Point(133, 9);
            this.lbl_SelectedPerson.Name = "lbl_SelectedPerson";
            this.lbl_SelectedPerson.Size = new System.Drawing.Size(100, 13);
            this.lbl_SelectedPerson.TabIndex = 3;
            this.lbl_SelectedPerson.Text = "Selected Person";
            // 
            // AWPFormSelectMyOrgPer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(579, 394);
            this.Controls.Add(this.lbl_SelectedPerson);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_Select);
            this.Controls.Add(this.dgvx);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AWPFormSelectMyOrgPer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AWPFormSelectMyOrganisationPersonNotInLoginUsers";
            this.Load += new System.EventHandler(this.AWPFormSelectMyOrgPer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvx)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridView_2xls.DataGridView2xls dgvx;
        private System.Windows.Forms.Button btn_Select;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Label lbl_SelectedPerson;
    }
}