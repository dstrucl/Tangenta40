namespace DocumentManager
{
    partial class Form_SettingsUsersCompare
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
            this.dgv_AfterLoad = new System.Windows.Forms.DataGridView();
            this.dgv_AfterSave = new System.Windows.Forms.DataGridView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lbl_AfterLoad = new System.Windows.Forms.Label();
            this.lbl_AfterSave = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_AfterLoad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_AfterSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv_AfterLoad
            // 
            this.dgv_AfterLoad.AllowUserToAddRows = false;
            this.dgv_AfterLoad.AllowUserToDeleteRows = false;
            this.dgv_AfterLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_AfterLoad.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_AfterLoad.Location = new System.Drawing.Point(3, 40);
            this.dgv_AfterLoad.Name = "dgv_AfterLoad";
            this.dgv_AfterLoad.ReadOnly = true;
            this.dgv_AfterLoad.Size = new System.Drawing.Size(499, 573);
            this.dgv_AfterLoad.TabIndex = 0;
            // 
            // dgv_AfterSave
            // 
            this.dgv_AfterSave.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_AfterSave.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_AfterSave.Location = new System.Drawing.Point(3, 40);
            this.dgv_AfterSave.Name = "dgv_AfterSave";
            this.dgv_AfterSave.Size = new System.Drawing.Size(441, 570);
            this.dgv_AfterSave.TabIndex = 1;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(255)))), ((int)(((byte)(242)))));
            this.splitContainer1.Location = new System.Drawing.Point(0, 36);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lbl_AfterLoad);
            this.splitContainer1.Panel1.Controls.Add(this.dgv_AfterLoad);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lbl_AfterSave);
            this.splitContainer1.Panel2.Controls.Add(this.dgv_AfterSave);
            this.splitContainer1.Size = new System.Drawing.Size(960, 613);
            this.splitContainer1.SplitterDistance = 505;
            this.splitContainer1.SplitterWidth = 8;
            this.splitContainer1.TabIndex = 2;
            // 
            // lbl_AfterLoad
            // 
            this.lbl_AfterLoad.AutoSize = true;
            this.lbl_AfterLoad.Location = new System.Drawing.Point(10, 17);
            this.lbl_AfterLoad.Name = "lbl_AfterLoad";
            this.lbl_AfterLoad.Size = new System.Drawing.Size(56, 13);
            this.lbl_AfterLoad.TabIndex = 1;
            this.lbl_AfterLoad.Text = "After Load";
            // 
            // lbl_AfterSave
            // 
            this.lbl_AfterSave.AutoSize = true;
            this.lbl_AfterSave.Location = new System.Drawing.Point(14, 20);
            this.lbl_AfterSave.Name = "lbl_AfterSave";
            this.lbl_AfterSave.Size = new System.Drawing.Size(57, 13);
            this.lbl_AfterSave.TabIndex = 2;
            this.lbl_AfterSave.Text = "After Save";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "label1";
            // 
            // Form_SettingsUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(962, 661);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.splitContainer1);
            this.DoubleBuffered = true;
            this.Name = "Form_SettingsUsers";
            this.Text = "Form_SettingsUsers";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_AfterLoad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_AfterSave)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_AfterLoad;
        private System.Windows.Forms.DataGridView dgv_AfterSave;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label lbl_AfterLoad;
        private System.Windows.Forms.Label lbl_AfterSave;
        private System.Windows.Forms.Label label1;
    }
}