namespace HUDCMS
{
    partial class usrc_EditControl
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txt_Control = new System.Windows.Forms.TextBox();
            this.usrc_SelectPictureFile = new SelectFile.usrc_SelectFile();
            this.txt_ControlName = new System.Windows.Forms.TextBox();
            this.lbl_ControlName = new System.Windows.Forms.Label();
            this.list_Link = new System.Windows.Forms.ListBox();
            this.lbl_LinkedControls = new System.Windows.Forms.Label();
            this.nmUpDn_SnapShotMargin = new System.Windows.Forms.NumericUpDown();
            this.lbl_SnapShotMargin = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmUpDn_SnapShotMargin)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel2.AutoScroll = true;
            this.panel2.AutoScrollMargin = new System.Drawing.Size(20, 20);
            this.panel2.AutoScrollMinSize = new System.Drawing.Size(24, 24);
            this.panel2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Location = new System.Drawing.Point(10, 93);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(407, 194);
            this.panel2.TabIndex = 13;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Location = new System.Drawing.Point(2, 24);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(385, 149);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // txt_Control
            // 
            this.txt_Control.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Control.Location = new System.Drawing.Point(10, 7);
            this.txt_Control.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txt_Control.Name = "txt_Control";
            this.txt_Control.ReadOnly = true;
            this.txt_Control.Size = new System.Drawing.Size(627, 20);
            this.txt_Control.TabIndex = 12;
            // 
            // usrc_SelectPictureFile
            // 
            this.usrc_SelectPictureFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.usrc_SelectPictureFile.DefaultExtension = "txt";
            this.usrc_SelectPictureFile.FileName = "";
            this.usrc_SelectPictureFile.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            this.usrc_SelectPictureFile.InitialDirectory = "C:\\";
            this.usrc_SelectPictureFile.Location = new System.Drawing.Point(11, 56);
            this.usrc_SelectPictureFile.Margin = new System.Windows.Forms.Padding(2);
            this.usrc_SelectPictureFile.Name = "usrc_SelectPictureFile";
            this.usrc_SelectPictureFile.Size = new System.Drawing.Size(631, 24);
            this.usrc_SelectPictureFile.TabIndex = 11;
            this.usrc_SelectPictureFile.Title = "Save File";
            // 
            // txt_ControlName
            // 
            this.txt_ControlName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_ControlName.Location = new System.Drawing.Point(87, 32);
            this.txt_ControlName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txt_ControlName.Name = "txt_ControlName";
            this.txt_ControlName.ReadOnly = true;
            this.txt_ControlName.Size = new System.Drawing.Size(550, 20);
            this.txt_ControlName.TabIndex = 16;
            this.txt_ControlName.Text = "txt_ControlName";
            // 
            // lbl_ControlName
            // 
            this.lbl_ControlName.AutoSize = true;
            this.lbl_ControlName.Location = new System.Drawing.Point(12, 34);
            this.lbl_ControlName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_ControlName.Name = "lbl_ControlName";
            this.lbl_ControlName.Size = new System.Drawing.Size(71, 13);
            this.lbl_ControlName.TabIndex = 17;
            this.lbl_ControlName.Text = "Control Name";
            // 
            // list_Link
            // 
            this.list_Link.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.list_Link.FormattingEnabled = true;
            this.list_Link.HorizontalScrollbar = true;
            this.list_Link.Location = new System.Drawing.Point(421, 161);
            this.list_Link.Margin = new System.Windows.Forms.Padding(2);
            this.list_Link.Name = "list_Link";
            this.list_Link.Size = new System.Drawing.Size(143, 43);
            this.list_Link.TabIndex = 18;
            this.list_Link.Visible = false;
            // 
            // lbl_LinkedControls
            // 
            this.lbl_LinkedControls.AutoSize = true;
            this.lbl_LinkedControls.Location = new System.Drawing.Point(421, 145);
            this.lbl_LinkedControls.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_LinkedControls.Name = "lbl_LinkedControls";
            this.lbl_LinkedControls.Size = new System.Drawing.Size(80, 13);
            this.lbl_LinkedControls.TabIndex = 19;
            this.lbl_LinkedControls.Text = "Linked Controls";
            // 
            // nmUpDn_SnapShotMargin
            // 
            this.nmUpDn_SnapShotMargin.Location = new System.Drawing.Point(515, 98);
            this.nmUpDn_SnapShotMargin.Name = "nmUpDn_SnapShotMargin";
            this.nmUpDn_SnapShotMargin.Size = new System.Drawing.Size(56, 20);
            this.nmUpDn_SnapShotMargin.TabIndex = 20;
            this.nmUpDn_SnapShotMargin.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // lbl_SnapShotMargin
            // 
            this.lbl_SnapShotMargin.AutoSize = true;
            this.lbl_SnapShotMargin.Location = new System.Drawing.Point(421, 100);
            this.lbl_SnapShotMargin.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_SnapShotMargin.Name = "lbl_SnapShotMargin";
            this.lbl_SnapShotMargin.Size = new System.Drawing.Size(89, 13);
            this.lbl_SnapShotMargin.TabIndex = 21;
            this.lbl_SnapShotMargin.Text = "Snap shot margin";
            // 
            // usrc_EditControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbl_SnapShotMargin);
            this.Controls.Add(this.nmUpDn_SnapShotMargin);
            this.Controls.Add(this.list_Link);
            this.Controls.Add(this.lbl_LinkedControls);
            this.Controls.Add(this.lbl_ControlName);
            this.Controls.Add(this.txt_ControlName);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.txt_Control);
            this.Controls.Add(this.usrc_SelectPictureFile);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "usrc_EditControl";
            this.Size = new System.Drawing.Size(642, 382);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmUpDn_SnapShotMargin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txt_Control;
        private SelectFile.usrc_SelectFile usrc_SelectPictureFile;
        private System.Windows.Forms.TextBox txt_ControlName;
        private System.Windows.Forms.Label lbl_ControlName;
        private System.Windows.Forms.ListBox list_Link;
        private System.Windows.Forms.Label lbl_LinkedControls;
        internal System.Windows.Forms.NumericUpDown nmUpDn_SnapShotMargin;
        private System.Windows.Forms.Label lbl_SnapShotMargin;
    }
}
