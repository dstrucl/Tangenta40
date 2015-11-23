namespace DBConnectionControl40
{
    partial class View_AccessRights_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(View_AccessRights_Form));
            this.dataGridView_Permissions = new System.Windows.Forms.DataGridView();
            this.lbl_Success = new System.Windows.Forms.Label();
            this.btn_OK = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Permissions)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_Permissions
            // 
            this.dataGridView_Permissions.AllowUserToAddRows = false;
            this.dataGridView_Permissions.AllowUserToDeleteRows = false;
            this.dataGridView_Permissions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_Permissions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Permissions.Location = new System.Drawing.Point(9, 114);
            this.dataGridView_Permissions.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dataGridView_Permissions.Name = "dataGridView_Permissions";
            this.dataGridView_Permissions.ReadOnly = true;
            this.dataGridView_Permissions.RowTemplate.Height = 24;
            this.dataGridView_Permissions.Size = new System.Drawing.Size(287, 167);
            this.dataGridView_Permissions.TabIndex = 10;
            // 
            // lbl_Success
            // 
            this.lbl_Success.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Success.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbl_Success.Location = new System.Drawing.Point(6, 7);
            this.lbl_Success.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_Success.Name = "lbl_Success";
            this.lbl_Success.Size = new System.Drawing.Size(287, 98);
            this.lbl_Success.TabIndex = 11;
            this.lbl_Success.Text = "Connection OK";
            // 
            // btn_OK
            // 
            this.btn_OK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_OK.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_OK.Location = new System.Drawing.Point(122, 306);
            this.btn_OK.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(72, 31);
            this.btn_OK.TabIndex = 12;
            this.btn_OK.Text = "OK";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // View_AccessRights_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(306, 347);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.lbl_Success);
            this.Controls.Add(this.dataGridView_Permissions);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "View_AccessRights_Form";
            this.Text = "View_AccessRights_Form";
            this.Load += new System.EventHandler(this.View_AccessRights_Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Permissions)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView dataGridView_Permissions;
        private System.Windows.Forms.Label lbl_Success;
        private System.Windows.Forms.Button btn_OK;
    }
}