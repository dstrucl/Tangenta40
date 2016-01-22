namespace ShopA
{
    partial class usrc_Editor
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.usrc_Edit_Item_Name1 = new ShopA.usrc_Edit_Item_Name();
            this.usrc_Edit_Item_Description1 = new ShopA.usrc_Edit_Item_Description();
            this.usrc_Edit_Item_Tax1 = new ShopA.usrc_Edit_Item_Tax();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Panel1.Controls.Add(this.usrc_Edit_Item_Name1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(711, 162);
            this.splitContainer1.SplitterDistance = 186;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer2.Panel1.Controls.Add(this.usrc_Edit_Item_Description1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer2.Panel2.Controls.Add(this.usrc_Edit_Item_Tax1);
            this.splitContainer2.Size = new System.Drawing.Size(521, 162);
            this.splitContainer2.SplitterDistance = 173;
            this.splitContainer2.TabIndex = 0;
            // 
            // usrc_Edit_Item_Name1
            // 
            this.usrc_Edit_Item_Name1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.usrc_Edit_Item_Name1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.usrc_Edit_Item_Name1.Location = new System.Drawing.Point(0, 0);
            this.usrc_Edit_Item_Name1.Name = "usrc_Edit_Item_Name1";
            this.usrc_Edit_Item_Name1.Size = new System.Drawing.Size(186, 162);
            this.usrc_Edit_Item_Name1.TabIndex = 0;
            // 
            // usrc_Edit_Item_Description1
            // 
            this.usrc_Edit_Item_Description1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.usrc_Edit_Item_Description1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.usrc_Edit_Item_Description1.Location = new System.Drawing.Point(0, 0);
            this.usrc_Edit_Item_Description1.Name = "usrc_Edit_Item_Description1";
            this.usrc_Edit_Item_Description1.Size = new System.Drawing.Size(173, 162);
            this.usrc_Edit_Item_Description1.TabIndex = 0;
            // 
            // usrc_Edit_Item_Tax1
            // 
            this.usrc_Edit_Item_Tax1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.usrc_Edit_Item_Tax1.Location = new System.Drawing.Point(7, 4);
            this.usrc_Edit_Item_Tax1.Name = "usrc_Edit_Item_Tax1";
            this.usrc_Edit_Item_Tax1.Size = new System.Drawing.Size(122, 46);
            this.usrc_Edit_Item_Tax1.TabIndex = 0;
            // 
            // usrc_Editor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "usrc_Editor";
            this.Size = new System.Drawing.Size(711, 162);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private usrc_Edit_Item_Name usrc_Edit_Item_Name1;
        private usrc_Edit_Item_Description usrc_Edit_Item_Description1;
        private usrc_Edit_Item_Tax usrc_Edit_Item_Tax1;
    }
}
