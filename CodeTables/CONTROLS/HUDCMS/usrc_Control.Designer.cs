namespace HUDCMS
{
    partial class usrc_Control
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
            this.lbl_Control = new System.Windows.Forms.Label();
            this.pic_Control = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.usrc_SelectPictureFile = new SelectFile.usrc_SelectFile();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Control)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_Control
            // 
            this.lbl_Control.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Control.AutoSize = true;
            this.lbl_Control.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_Control.Location = new System.Drawing.Point(9, 10);
            this.lbl_Control.Name = "lbl_Control";
            this.lbl_Control.Size = new System.Drawing.Size(54, 17);
            this.lbl_Control.TabIndex = 3;
            this.lbl_Control.Text = "Dialog";
            // 
            // pic_Control
            // 
            this.pic_Control.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pic_Control.Location = new System.Drawing.Point(4, 78);
            this.pic_Control.Margin = new System.Windows.Forms.Padding(4);
            this.pic_Control.Name = "pic_Control";
            this.pic_Control.Size = new System.Drawing.Size(103, 71);
            this.pic_Control.TabIndex = 4;
            this.pic_Control.TabStop = false;
            this.pic_Control.Click += new System.EventHandler(this.pic_Control_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.pic_Control);
            this.panel1.Controls.Add(this.lbl_Control);
            this.panel1.Controls.Add(this.usrc_SelectPictureFile);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(686, 166);
            this.panel1.TabIndex = 6;
            // 
            // usrc_SelectPictureFile
            // 
            this.usrc_SelectPictureFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.usrc_SelectPictureFile.DefaultExtension = "txt";
            this.usrc_SelectPictureFile.FileName = "";
            this.usrc_SelectPictureFile.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            this.usrc_SelectPictureFile.InitialDirectory = "C:\\";
            this.usrc_SelectPictureFile.Location = new System.Drawing.Point(4, 37);
            this.usrc_SelectPictureFile.Name = "usrc_SelectPictureFile";
            this.usrc_SelectPictureFile.Size = new System.Drawing.Size(679, 34);
            this.usrc_SelectPictureFile.TabIndex = 5;
            this.usrc_SelectPictureFile.Title = "Save File";
            // 
            // usrc_Control
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.panel1);
            this.Name = "usrc_Control";
            this.Size = new System.Drawing.Size(692, 172);
            ((System.ComponentModel.ISupportInitialize)(this.pic_Control)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_Control;
        private System.Windows.Forms.PictureBox pic_Control;
        private SelectFile.usrc_SelectFile usrc_SelectPictureFile;
        private System.Windows.Forms.Panel panel1;
    }
}
