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
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("ControlType", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("ControlName", System.Windows.Forms.HorizontalAlignment.Left);
            this.btn_Add = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txt_Control = new System.Windows.Forms.TextBox();
            this.usrc_SelectPictureFile = new SelectFile.usrc_SelectFile();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Add
            // 
            this.btn_Add.Location = new System.Drawing.Point(35, 79);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(73, 29);
            this.btn_Add.TabIndex = 15;
            this.btn_Add.Text = "Add";
            this.btn_Add.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            listViewGroup1.Header = "ControlType";
            listViewGroup1.Name = "ControlType";
            listViewGroup2.Header = "ControlName";
            listViewGroup2.Name = "ControlName";
            this.listView1.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2});
            this.listView1.Location = new System.Drawing.Point(35, 114);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(165, 256);
            this.listView1.TabIndex = 14;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.AutoScroll = true;
            this.panel2.AutoScrollMargin = new System.Drawing.Size(20, 20);
            this.panel2.AutoScrollMinSize = new System.Drawing.Size(24, 24);
            this.panel2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Location = new System.Drawing.Point(434, 76);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(287, 294);
            this.panel2.TabIndex = 13;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(263, 261);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // txt_Control
            // 
            this.txt_Control.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Control.Location = new System.Drawing.Point(13, 15);
            this.txt_Control.Name = "txt_Control";
            this.txt_Control.ReadOnly = true;
            this.txt_Control.Size = new System.Drawing.Size(703, 22);
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
            this.usrc_SelectPictureFile.Location = new System.Drawing.Point(13, 42);
            this.usrc_SelectPictureFile.Margin = new System.Windows.Forms.Padding(2);
            this.usrc_SelectPictureFile.Name = "usrc_SelectPictureFile";
            this.usrc_SelectPictureFile.Size = new System.Drawing.Size(709, 29);
            this.usrc_SelectPictureFile.TabIndex = 11;
            this.usrc_SelectPictureFile.Title = "Save File";
            // 
            // usrc_EditControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btn_Add);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.txt_Control);
            this.Controls.Add(this.usrc_SelectPictureFile);
            this.Name = "usrc_EditControl";
            this.Size = new System.Drawing.Size(724, 385);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txt_Control;
        private SelectFile.usrc_SelectFile usrc_SelectPictureFile;
    }
}
