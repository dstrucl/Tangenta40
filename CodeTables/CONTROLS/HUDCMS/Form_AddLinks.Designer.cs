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
            this.olvc_ControlLinks = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvc_HelpTitle = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvc_ControlUniqueName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            ((System.ComponentModel.ISupportInitialize)(this.MyTreeListView)).BeginInit();
            this.SuspendLayout();
            // 
            // MyTreeListView
            // 
            this.MyTreeListView.AllColumns.Add(this.olvc_ControlType);
            this.MyTreeListView.AllColumns.Add(this.olvc_ControlName);
            this.MyTreeListView.AllColumns.Add(this.olvc_ControlImage);
            this.MyTreeListView.AllColumns.Add(this.olvc_ControlLinks);
            this.MyTreeListView.AllColumns.Add(this.olvc_HelpTitle);
            this.MyTreeListView.AllColumns.Add(this.olvc_ControlUniqueName);
            this.MyTreeListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvc_ControlType,
            this.olvc_ControlName,
            this.olvc_ControlImage,
            this.olvc_ControlLinks,
            this.olvc_HelpTitle,
            this.olvc_ControlUniqueName});
            this.MyTreeListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MyTreeListView.Location = new System.Drawing.Point(0, 0);
            this.MyTreeListView.MultiSelect = false;
            this.MyTreeListView.Name = "MyTreeListView";
            this.MyTreeListView.OwnerDraw = true;
            this.MyTreeListView.ShowGroups = false;
            this.MyTreeListView.ShowImagesOnSubItems = true;
            this.MyTreeListView.Size = new System.Drawing.Size(755, 531);
            this.MyTreeListView.TabIndex = 1;
            this.MyTreeListView.UseCompatibleStateImageBehavior = false;
            this.MyTreeListView.View = System.Windows.Forms.View.Details;
            this.MyTreeListView.VirtualMode = true;
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
            // olvc_ControlLinks
            // 
            this.olvc_ControlLinks.AspectName = "ControlLinks";
            this.olvc_ControlLinks.Text = "Control Links";
            this.olvc_ControlLinks.UseInitialLetterForGroup = true;
            this.olvc_ControlLinks.Width = 180;
            this.olvc_ControlLinks.WordWrap = true;
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
            // Form_AddLinks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(755, 531);
            this.Controls.Add(this.MyTreeListView);
            this.Name = "Form_AddLinks";
            this.Text = "Form_EditLinks";
            ((System.ComponentModel.ISupportInitialize)(this.MyTreeListView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private BrightIdeasSoftware.TreeListView MyTreeListView;
        private BrightIdeasSoftware.OLVColumn olvc_ControlType;
        private BrightIdeasSoftware.OLVColumn olvc_ControlName;
        private BrightIdeasSoftware.OLVColumn olvc_ControlImage;
        private BrightIdeasSoftware.OLVColumn olvc_ControlLinks;
        private BrightIdeasSoftware.OLVColumn olvc_HelpTitle;
        private BrightIdeasSoftware.OLVColumn olvc_ControlUniqueName;
    }
}