namespace HUDCMS
{
    partial class Form_ViewImageFileResults
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
            this.dgv_Dic = new System.Windows.Forms.DataGridView();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_Erease = new System.Windows.Forms.Button();
            this.btn_Refresh = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Dic)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_Dic
            // 
            this.dgv_Dic.AllowUserToAddRows = false;
            this.dgv_Dic.AllowUserToDeleteRows = false;
            this.dgv_Dic.AllowUserToOrderColumns = true;
            this.dgv_Dic.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_Dic.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgv_Dic.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Dic.Location = new System.Drawing.Point(2, 27);
            this.dgv_Dic.Name = "dgv_Dic";
            this.dgv_Dic.ReadOnly = true;
            this.dgv_Dic.Size = new System.Drawing.Size(848, 633);
            this.dgv_Dic.TabIndex = 0;
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Cancel.Location = new System.Drawing.Point(787, 2);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(63, 21);
            this.btn_Cancel.TabIndex = 1;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_Erease
            // 
            this.btn_Erease.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Erease.Location = new System.Drawing.Point(718, 2);
            this.btn_Erease.Name = "btn_Erease";
            this.btn_Erease.Size = new System.Drawing.Size(63, 21);
            this.btn_Erease.TabIndex = 3;
            this.btn_Erease.Text = "Delate All";
            this.btn_Erease.UseVisualStyleBackColor = true;
            this.btn_Erease.Click += new System.EventHandler(this.btn_Erease_Click);
            // 
            // btn_Refresh
            // 
            this.btn_Refresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Refresh.Location = new System.Drawing.Point(649, 2);
            this.btn_Refresh.Name = "btn_Refresh";
            this.btn_Refresh.Size = new System.Drawing.Size(63, 21);
            this.btn_Refresh.TabIndex = 4;
            this.btn_Refresh.Text = "Refresh";
            this.btn_Refresh.UseVisualStyleBackColor = true;
            this.btn_Refresh.Click += new System.EventHandler(this.btn_Refresh_Click);
            // 
            // Form_ViewImageFileResults
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(855, 658);
            this.Controls.Add(this.btn_Refresh);
            this.Controls.Add(this.btn_Erease);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.dgv_Dic);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "Form_ViewImageFileResults";
            this.Text = "Image File Result";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Dic)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_Dic;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_Erease;
        private System.Windows.Forms.Button btn_Refresh;
    }
}