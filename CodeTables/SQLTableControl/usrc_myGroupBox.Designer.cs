namespace CodeTables
{
    partial class usrc_myGroupBox
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
            this.grpBox = new System.Windows.Forms.GroupBox();
            this.pic_Changed = new CodeTables.PictureBoxChanged();
            this.grpBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Changed)).BeginInit();
            this.SuspendLayout();
            // 
            // grpBox
            // 
            this.grpBox.AutoSize = true;
            this.grpBox.Controls.Add(this.pic_Changed);
            this.grpBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.grpBox.Location = new System.Drawing.Point(0, 0);
            this.grpBox.Margin = new System.Windows.Forms.Padding(7);
            this.grpBox.Name = "grpBox";
            this.grpBox.Size = new System.Drawing.Size(441, 308);
            this.grpBox.TabIndex = 0;
            this.grpBox.TabStop = false;
            this.grpBox.Text = "gprBox";
            // 
            // pic_Changed
            // 
            this.pic_Changed.Changed = false;
            this.pic_Changed.Image = global::CodeTables.Properties.Resources.ObjectNotChanged;
            this.pic_Changed.Location = new System.Drawing.Point(0, 1);
            this.pic_Changed.Name = "pic_Changed";
            this.pic_Changed.Size = new System.Drawing.Size(8, 16);
            this.pic_Changed.TabIndex = 0;
            this.pic_Changed.TabStop = false;
            // 
            // usrc_myGroupBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpBox);
            this.Name = "usrc_myGroupBox";
            this.Size = new System.Drawing.Size(441, 308);
            this.grpBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pic_Changed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.GroupBox grpBox;
        private CodeTables.PictureBoxChanged pic_Changed;

    }
}
