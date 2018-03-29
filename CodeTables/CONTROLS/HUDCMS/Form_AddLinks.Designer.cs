namespace HUDCMS
{
    partial class Form_AddLinks
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
            this.components = new System.ComponentModel.Container();
            this.MyTreeListView = new BrightIdeasSoftware.TreeListView();
            this.olvc_ControlType = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvc_ControlName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvc_ControlImage = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvc_HelpTitle = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvc_ControlUniqueName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbl_ControlUniqueName = new System.Windows.Forms.Label();
            this.txt_ControlUniqueName = new System.Windows.Forms.TextBox();
            this.btn_AddLink = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.MyTreeListView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // MyTreeListView
            // 
            this.MyTreeListView.AllColumns.Add(this.olvc_ControlType);
            this.MyTreeListView.AllColumns.Add(this.olvc_ControlName);
            this.MyTreeListView.AllColumns.Add(this.olvc_ControlImage);
            this.MyTreeListView.AllColumns.Add(this.olvc_HelpTitle);
            this.MyTreeListView.AllColumns.Add(this.olvc_ControlUniqueName);
            this.MyTreeListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MyTreeListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvc_ControlType,
            this.olvc_ControlName,
            this.olvc_ControlImage,
            this.olvc_HelpTitle,
            this.olvc_ControlUniqueName});
            this.MyTreeListView.Location = new System.Drawing.Point(0, 88);
            this.MyTreeListView.MultiSelect = false;
            this.MyTreeListView.Name = "MyTreeListView";
            this.MyTreeListView.OwnerDraw = true;
            this.MyTreeListView.ShowGroups = false;
            this.MyTreeListView.ShowImagesOnSubItems = true;
            this.MyTreeListView.Size = new System.Drawing.Size(755, 443);
            this.MyTreeListView.TabIndex = 1;
            this.MyTreeListView.UseCompatibleStateImageBehavior = false;
            this.MyTreeListView.View = System.Windows.Forms.View.Details;
            this.MyTreeListView.VirtualMode = true;
            this.MyTreeListView.SelectedIndexChanged += new System.EventHandler(this.MyTreeListView_SelectedIndexChanged);
            // 
            // olvc_ControlType
            // 
            this.olvc_ControlType.AspectName = "ControlType";
            this.olvc_ControlType.Text = "Control Type";
            this.olvc_ControlType.Width = 245;
            // 
            // olvc_ControlName
            // 
            this.olvc_ControlName.AspectName = "ControlName";
            this.olvc_ControlName.Text = "Control Name";
            this.olvc_ControlName.UseInitialLetterForGroup = true;
            this.olvc_ControlName.Width = 180;
            this.olvc_ControlName.WordWrap = true;
            // 
            // olvc_ControlImage
            // 
            this.olvc_ControlImage.AspectName = "ControlImage";
            this.olvc_ControlImage.Text = "Control Image";
            this.olvc_ControlImage.Width = 107;
            // 
            // olvc_HelpTitle
            // 
            this.olvc_HelpTitle.AspectName = "HelpTitle";
            this.olvc_HelpTitle.Text = "Help Title";
            this.olvc_HelpTitle.UseInitialLetterForGroup = true;
            this.olvc_HelpTitle.Width = 360;
            this.olvc_HelpTitle.WordWrap = true;
            // 
            // olvc_ControlUniqueName
            // 
            this.olvc_ControlUniqueName.AspectName = "ControlUniqueName";
            this.olvc_ControlUniqueName.Text = "Control Unique Name";
            this.olvc_ControlUniqueName.UseInitialLetterForGroup = true;
            this.olvc_ControlUniqueName.Width = 360;
            this.olvc_ControlUniqueName.WordWrap = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(1, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(95, 82);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // lbl_ControlUniqueName
            // 
            this.lbl_ControlUniqueName.AutoSize = true;
            this.lbl_ControlUniqueName.Location = new System.Drawing.Point(102, 25);
            this.lbl_ControlUniqueName.Name = "lbl_ControlUniqueName";
            this.lbl_ControlUniqueName.Size = new System.Drawing.Size(108, 13);
            this.lbl_ControlUniqueName.TabIndex = 3;
            this.lbl_ControlUniqueName.Text = "Control Unique Name";
            // 
            // txt_ControlUniqueName
            // 
            this.txt_ControlUniqueName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_ControlUniqueName.Location = new System.Drawing.Point(98, 45);
            this.txt_ControlUniqueName.Name = "txt_ControlUniqueName";
            this.txt_ControlUniqueName.Size = new System.Drawing.Size(656, 20);
            this.txt_ControlUniqueName.TabIndex = 4;
            // 
            // btn_AddLink
            // 
            this.btn_AddLink.Image = global::HUDCMS.Properties.Resources.Link;
            this.btn_AddLink.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_AddLink.Location = new System.Drawing.Point(231, 2);
            this.btn_AddLink.Name = "btn_AddLink";
            this.btn_AddLink.Size = new System.Drawing.Size(112, 36);
            this.btn_AddLink.TabIndex = 5;
            this.btn_AddLink.Text = "Add Link";
            this.btn_AddLink.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_AddLink.UseVisualStyleBackColor = true;
            this.btn_AddLink.Click += new System.EventHandler(this.btn_AddLink_Click);
            // 
            // Form_AddLinks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(755, 531);
            this.Controls.Add(this.btn_AddLink);
            this.Controls.Add(this.txt_ControlUniqueName);
            this.Controls.Add(this.lbl_ControlUniqueName);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.MyTreeListView);
            this.Name = "Form_AddLinks";
            this.Text = "Form_EditLinks";
            ((System.ComponentModel.ISupportInitialize)(this.MyTreeListView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BrightIdeasSoftware.TreeListView MyTreeListView;
        private BrightIdeasSoftware.OLVColumn olvc_ControlType;
        private BrightIdeasSoftware.OLVColumn olvc_ControlName;
        private BrightIdeasSoftware.OLVColumn olvc_ControlImage;
        private BrightIdeasSoftware.OLVColumn olvc_HelpTitle;
        private BrightIdeasSoftware.OLVColumn olvc_ControlUniqueName;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbl_ControlUniqueName;
        private System.Windows.Forms.TextBox txt_ControlUniqueName;
        private System.Windows.Forms.Button btn_AddLink;
    }
}