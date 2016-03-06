namespace CodeTables
{
    partial class CreateView_Form
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
            this.menuStrip_File = new System.Windows.Forms.MenuStrip();
            this.tsmi_Select_View = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_CreateNew = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_Save = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_Show = new System.Windows.Forms.ToolStripMenuItem();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.label_ViewName = new System.Windows.Forms.Label();
            this.lblViewName = new System.Windows.Forms.Label();
            this.lblPrimaryView = new System.Windows.Forms.Label();
            this.label_PrimaryView = new System.Windows.Forms.Label();
            this.grb_ShowLimits = new System.Windows.Forms.GroupBox();
            this.chk_Limit = new System.Windows.Forms.CheckBox();
            this.chk_Descending = new System.Windows.Forms.CheckBox();
            this.nmUpDn_Limit = new System.Windows.Forms.NumericUpDown();
            this.tsmi_DeleteView = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip_File.SuspendLayout();
            this.grb_ShowLimits.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmUpDn_Limit)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip_File
            // 
            this.menuStrip_File.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_Select_View,
            this.tsmi_Show,
            this.tsmi_Save,
            this.tsmi_CreateNew,
            this.tsmi_DeleteView});
            this.menuStrip_File.Location = new System.Drawing.Point(0, 0);
            this.menuStrip_File.Name = "menuStrip_File";
            this.menuStrip_File.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip_File.Size = new System.Drawing.Size(981, 24);
            this.menuStrip_File.TabIndex = 0;
            this.menuStrip_File.Text = "File";
            // 
            // tsmi_Select_View
            // 
            this.tsmi_Select_View.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmi_Select_View.Name = "tsmi_Select_View";
            this.tsmi_Select_View.Size = new System.Drawing.Size(92, 20);
            this.tsmi_Select_View.Text = "Select View";
            this.tsmi_Select_View.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tsmi_Select_View.Click += new System.EventHandler(this.tsmi_Select_View_Click);
            // 
            // tsmi_CreateNew
            // 
            this.tsmi_CreateNew.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmi_CreateNew.Name = "tsmi_CreateNew";
            this.tsmi_CreateNew.Size = new System.Drawing.Size(97, 20);
            this.tsmi_CreateNew.Text = "Create New ";
            this.tsmi_CreateNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tsmi_CreateNew.Click += new System.EventHandler(this.tsmi_CreateNew_Click);
            // 
            // tsmi_Save
            // 
            this.tsmi_Save.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmi_Save.Name = "tsmi_Save";
            this.tsmi_Save.Size = new System.Drawing.Size(52, 20);
            this.tsmi_Save.Text = "Save";
            this.tsmi_Save.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tsmi_Save.Click += new System.EventHandler(this.tsmi_Save_Click);
            // 
            // tsmi_Show
            // 
            this.tsmi_Show.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmi_Show.Name = "tsmi_Show";
            this.tsmi_Show.Size = new System.Drawing.Size(54, 20);
            this.tsmi_Show.Text = "Show";
            this.tsmi_Show.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tsmi_Show.Click += new System.EventHandler(this.tsmi_Show_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AllowDrop = true;
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(242, 70);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(731, 249);
            this.flowLayoutPanel1.TabIndex = 1;
            this.flowLayoutPanel1.WrapContents = false;
            this.flowLayoutPanel1.SizeChanged += new System.EventHandler(this.flowLayoutPanel1_SizeChanged);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AllowDrop = true;
            this.flowLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.flowLayoutPanel2.AutoScroll = true;
            this.flowLayoutPanel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 27);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(218, 292);
            this.flowLayoutPanel2.TabIndex = 4;
            this.flowLayoutPanel2.WrapContents = false;
            // 
            // label_ViewName
            // 
            this.label_ViewName.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_ViewName.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label_ViewName.Location = new System.Drawing.Point(459, 6);
            this.label_ViewName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_ViewName.Name = "label_ViewName";
            this.label_ViewName.Size = new System.Drawing.Size(65, 19);
            this.label_ViewName.TabIndex = 5;
            this.label_ViewName.Text = "label1";
            this.label_ViewName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblViewName
            // 
            this.lblViewName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblViewName.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblViewName.ForeColor = System.Drawing.SystemColors.InfoText;
            this.lblViewName.Location = new System.Drawing.Point(528, 6);
            this.lblViewName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblViewName.Name = "lblViewName";
            this.lblViewName.Size = new System.Drawing.Size(130, 19);
            this.lblViewName.TabIndex = 6;
            this.lblViewName.Text = "label2";
            this.lblViewName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPrimaryView
            // 
            this.lblPrimaryView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblPrimaryView.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrimaryView.ForeColor = System.Drawing.SystemColors.InfoText;
            this.lblPrimaryView.Location = new System.Drawing.Point(829, 5);
            this.lblPrimaryView.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPrimaryView.Name = "lblPrimaryView";
            this.lblPrimaryView.Size = new System.Drawing.Size(141, 19);
            this.lblPrimaryView.TabIndex = 8;
            this.lblPrimaryView.Text = "label2";
            this.lblPrimaryView.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblPrimaryView.Click += new System.EventHandler(this.label1_Click);
            // 
            // label_PrimaryView
            // 
            this.label_PrimaryView.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_PrimaryView.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label_PrimaryView.Location = new System.Drawing.Point(670, 6);
            this.label_PrimaryView.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_PrimaryView.Name = "label_PrimaryView";
            this.label_PrimaryView.Size = new System.Drawing.Size(155, 18);
            this.label_PrimaryView.TabIndex = 7;
            this.label_PrimaryView.Text = "label1";
            this.label_PrimaryView.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label_PrimaryView.Click += new System.EventHandler(this.label2_Click);
            // 
            // grb_ShowLimits
            // 
            this.grb_ShowLimits.Controls.Add(this.chk_Limit);
            this.grb_ShowLimits.Controls.Add(this.chk_Descending);
            this.grb_ShowLimits.Controls.Add(this.nmUpDn_Limit);
            this.grb_ShowLimits.Location = new System.Drawing.Point(242, 27);
            this.grb_ShowLimits.Name = "grb_ShowLimits";
            this.grb_ShowLimits.Size = new System.Drawing.Size(296, 37);
            this.grb_ShowLimits.TabIndex = 19;
            this.grb_ShowLimits.TabStop = false;
            this.grb_ShowLimits.Text = "View";
            // 
            // chk_Limit
            // 
            this.chk_Limit.Location = new System.Drawing.Point(6, 15);
            this.chk_Limit.Name = "chk_Limit";
            this.chk_Limit.Size = new System.Drawing.Size(92, 17);
            this.chk_Limit.TabIndex = 17;
            this.chk_Limit.Text = "Limit";
            this.chk_Limit.UseVisualStyleBackColor = true;
            // 
            // chk_Descending
            // 
            this.chk_Descending.Location = new System.Drawing.Point(193, 15);
            this.chk_Descending.Name = "chk_Descending";
            this.chk_Descending.Size = new System.Drawing.Size(103, 20);
            this.chk_Descending.TabIndex = 16;
            this.chk_Descending.Text = "Ascending";
            this.chk_Descending.UseVisualStyleBackColor = true;
            // 
            // nmUpDn_Limit
            // 
            this.nmUpDn_Limit.Location = new System.Drawing.Point(104, 14);
            this.nmUpDn_Limit.Name = "nmUpDn_Limit";
            this.nmUpDn_Limit.Size = new System.Drawing.Size(74, 20);
            this.nmUpDn_Limit.TabIndex = 15;
            // 
            // tsmi_DeleteView
            // 
            this.tsmi_DeleteView.Font = new System.Drawing.Font("Arial", 10.2F);
            this.tsmi_DeleteView.Name = "tsmi_DeleteView";
            this.tsmi_DeleteView.Size = new System.Drawing.Size(94, 20);
            this.tsmi_DeleteView.Text = "Delete View";
            this.tsmi_DeleteView.Click += new System.EventHandler(this.deleteViewToolStripMenuItem_Click);
            // 
            // CreateView_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(981, 328);
            this.Controls.Add(this.grb_ShowLimits);
            this.Controls.Add(this.lblPrimaryView);
            this.Controls.Add(this.label_PrimaryView);
            this.Controls.Add(this.lblViewName);
            this.Controls.Add(this.label_ViewName);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.menuStrip_File);
            this.MainMenuStrip = this.menuStrip_File;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "CreateView_Form";
            this.Text = "CreateView_Form";
            this.Load += new System.EventHandler(this.CreateView_Form_Load);
            this.TextChanged += new System.EventHandler(this.CreateView_Form_TextChanged);
            this.menuStrip_File.ResumeLayout(false);
            this.menuStrip_File.PerformLayout();
            this.grb_ShowLimits.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nmUpDn_Limit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip_File;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Save;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Select_View;
        private System.Windows.Forms.Label label_ViewName;
        private System.Windows.Forms.Label lblViewName;
        private System.Windows.Forms.Label lblPrimaryView;
        private System.Windows.Forms.Label label_PrimaryView;
        private System.Windows.Forms.ToolStripMenuItem tsmi_CreateNew;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Show;
        private System.Windows.Forms.GroupBox grb_ShowLimits;
        private System.Windows.Forms.CheckBox chk_Descending;
        private System.Windows.Forms.NumericUpDown nmUpDn_Limit;
        private System.Windows.Forms.CheckBox chk_Limit;
        private System.Windows.Forms.ToolStripMenuItem tsmi_DeleteView;
    }
}