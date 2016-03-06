namespace DBConnectionControl40
{
    partial class Connection_Control
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Connection_Control));
            this.lbl_ServerType = new System.Windows.Forms.Label();
            this.lbl_DataSourceAndDatabase = new System.Windows.Forms.Label();
            this.btn_ConnectionDialog = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_ServerType
            // 
            this.lbl_ServerType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_ServerType.AutoSize = true;
            this.lbl_ServerType.Location = new System.Drawing.Point(78, 6);
            this.lbl_ServerType.Name = "lbl_ServerType";
            this.lbl_ServerType.Size = new System.Drawing.Size(68, 13);
            this.lbl_ServerType.TabIndex = 0;
            this.lbl_ServerType.Text = "Server Type:";
            // 
            // lbl_DataSourceAndDatabase
            // 
            this.lbl_DataSourceAndDatabase.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_DataSourceAndDatabase.AutoSize = true;
            this.lbl_DataSourceAndDatabase.Location = new System.Drawing.Point(76, 26);
            this.lbl_DataSourceAndDatabase.Name = "lbl_DataSourceAndDatabase";
            this.lbl_DataSourceAndDatabase.Size = new System.Drawing.Size(141, 13);
            this.lbl_DataSourceAndDatabase.TabIndex = 1;
            this.lbl_DataSourceAndDatabase.Text = "Data Source And Database:";
            // 
            // btn_ConnectionDialog
            // 
            this.btn_ConnectionDialog.Image = ((System.Drawing.Image)(resources.GetObject("btn_ConnectionDialog.Image")));
            this.btn_ConnectionDialog.Location = new System.Drawing.Point(3, 6);
            this.btn_ConnectionDialog.Name = "btn_ConnectionDialog";
            this.btn_ConnectionDialog.Size = new System.Drawing.Size(60, 35);
            this.btn_ConnectionDialog.TabIndex = 2;
            this.btn_ConnectionDialog.UseVisualStyleBackColor = true;
            this.btn_ConnectionDialog.Click += new System.EventHandler(this.btn_ConnectionDialog_Click);
            // 
            // Connection_Control
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.btn_ConnectionDialog);
            this.Controls.Add(this.lbl_DataSourceAndDatabase);
            this.Controls.Add(this.lbl_ServerType);
            this.Name = "Connection_Control";
            this.Size = new System.Drawing.Size(618, 47);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_ServerType;
        private System.Windows.Forms.Button btn_ConnectionDialog;
        internal System.Windows.Forms.Label lbl_DataSourceAndDatabase;
    }
}
