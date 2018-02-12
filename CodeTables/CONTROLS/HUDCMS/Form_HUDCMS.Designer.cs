namespace HUDCMS
{
    partial class Form_HUDCMS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_HUDCMS));
            this.grp_Style = new System.Windows.Forms.GroupBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.usrc_SelectHtmlFile = new SelectFile.usrc_SelectFile();
            this.usrc_SelectStyleFile = new SelectFile.usrc_SelectFile();
            this.usrc_EditControl1 = new HUDCMS.usrc_EditControl();
            this.grp_Style.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grp_Style
            // 
            this.grp_Style.Controls.Add(this.usrc_SelectStyleFile);
            this.grp_Style.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grp_Style.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.grp_Style.Location = new System.Drawing.Point(7, 2);
            this.grp_Style.Margin = new System.Windows.Forms.Padding(2);
            this.grp_Style.Name = "grp_Style";
            this.grp_Style.Padding = new System.Windows.Forms.Padding(2);
            this.grp_Style.Size = new System.Drawing.Size(428, 68);
            this.grp_Style.TabIndex = 6;
            this.grp_Style.TabStop = false;
            this.grp_Style.Text = "Style";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Location = new System.Drawing.Point(2, 59);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(2);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            this.splitContainer1.Panel1.Controls.Add(this.grp_Style);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.usrc_EditControl1);
            this.splitContainer1.Size = new System.Drawing.Size(1022, 512);
            this.splitContainer1.SplitterDistance = 439;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 8;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(7, 74);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(428, 432);
            this.panel1.TabIndex = 7;
            // 
            // usrc_SelectHtmlFile
            // 
            this.usrc_SelectHtmlFile.DefaultExtension = "txt";
            this.usrc_SelectHtmlFile.FileName = "";
            this.usrc_SelectHtmlFile.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            this.usrc_SelectHtmlFile.InitialDirectory = "C:\\";
            this.usrc_SelectHtmlFile.Location = new System.Drawing.Point(11, 13);
            this.usrc_SelectHtmlFile.Margin = new System.Windows.Forms.Padding(2);
            this.usrc_SelectHtmlFile.Name = "usrc_SelectHtmlFile";
            this.usrc_SelectHtmlFile.Size = new System.Drawing.Size(1003, 27);
            this.usrc_SelectHtmlFile.TabIndex = 9;
            this.usrc_SelectHtmlFile.Title = "Save File";
            this.usrc_SelectHtmlFile.SaveFile += new SelectFile.usrc_SelectFile.delegate_SaveFile(this.usrc_SelectHtmlFile_SaveFile);
            // 
            // usrc_SelectStyleFile
            // 
            this.usrc_SelectStyleFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.usrc_SelectStyleFile.DefaultExtension = "txt";
            this.usrc_SelectStyleFile.FileName = "";
            this.usrc_SelectStyleFile.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            this.usrc_SelectStyleFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.usrc_SelectStyleFile.InitialDirectory = "C:\\";
            this.usrc_SelectStyleFile.Location = new System.Drawing.Point(12, 27);
            this.usrc_SelectStyleFile.Margin = new System.Windows.Forms.Padding(2);
            this.usrc_SelectStyleFile.Name = "usrc_SelectStyleFile";
            this.usrc_SelectStyleFile.Size = new System.Drawing.Size(410, 20);
            this.usrc_SelectStyleFile.TabIndex = 0;
            this.usrc_SelectStyleFile.Title = "Save File";
            // 
            // usrc_EditControl1
            // 
            this.usrc_EditControl1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.usrc_EditControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.usrc_EditControl1.Enabled = false;
            this.usrc_EditControl1.Location = new System.Drawing.Point(0, 0);
            this.usrc_EditControl1.Margin = new System.Windows.Forms.Padding(2);
            this.usrc_EditControl1.Name = "usrc_EditControl1";
            this.usrc_EditControl1.Size = new System.Drawing.Size(574, 508);
            this.usrc_EditControl1.SnapShotMargin = 4;
            this.usrc_EditControl1.TabIndex = 1;
            // 
            // Form_HUDCMS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1025, 571);
            this.Controls.Add(this.usrc_SelectHtmlFile);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_HUDCMS";
            this.Text = "Form_HUDCMS";
            this.Load += new System.EventHandler(this.Form_HUDCMS_Load);
            this.grp_Style.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox grp_Style;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private SelectFile.usrc_SelectFile usrc_SelectStyleFile;
        internal usrc_EditControl usrc_EditControl1;
        internal System.Windows.Forms.Panel panel1;
        internal SelectFile.usrc_SelectFile usrc_SelectHtmlFile;
    }
}