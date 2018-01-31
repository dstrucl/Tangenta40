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
            this.radioButtonGlobal1 = new RadioButtonGlobal.RadioButtonGlobal();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Control)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_Control
            // 
            this.lbl_Control.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Control.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_Control.Location = new System.Drawing.Point(7, 8);
            this.lbl_Control.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_Control.Name = "lbl_Control";
            this.lbl_Control.Size = new System.Drawing.Size(406, 13);
            this.lbl_Control.TabIndex = 3;
            this.lbl_Control.Text = "Dialog";
            // 
            // pic_Control
            // 
            this.pic_Control.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pic_Control.Location = new System.Drawing.Point(3, 62);
            this.pic_Control.Name = "pic_Control";
            this.pic_Control.Size = new System.Drawing.Size(82, 57);
            this.pic_Control.TabIndex = 4;
            this.pic_Control.TabStop = false;
            this.pic_Control.Click += new System.EventHandler(this.pic_Control_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.radioButtonGlobal1);
            this.panel1.Controls.Add(this.pic_Control);
            this.panel1.Controls.Add(this.lbl_Control);
            this.panel1.Controls.Add(this.usrc_SelectPictureFile);
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(486, 133);
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
            this.usrc_SelectPictureFile.Location = new System.Drawing.Point(10, 30);
            this.usrc_SelectPictureFile.Margin = new System.Windows.Forms.Padding(2);
            this.usrc_SelectPictureFile.Name = "usrc_SelectPictureFile";
            this.usrc_SelectPictureFile.Size = new System.Drawing.Size(474, 27);
            this.usrc_SelectPictureFile.TabIndex = 5;
            this.usrc_SelectPictureFile.Title = "Save File";
            // 
            // radioButtonGlobal1
            // 
            this.radioButtonGlobal1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radioButtonGlobal1.Checked = false;
            this.radioButtonGlobal1.Location = new System.Drawing.Point(418, 2);
            this.radioButtonGlobal1.Name = "radioButtonGlobal1";
            this.radioButtonGlobal1.Size = new System.Drawing.Size(62, 25);
            this.radioButtonGlobal1.TabIndex = 6;
            this.radioButtonGlobal1.CheckChanged += new RadioButtonGlobal.RadioButtonGlobal.delegateCheckChanged(this.radioButtonGlobal1_CheckChanged);
            // 
            // usrc_Control
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "usrc_Control";
            this.Size = new System.Drawing.Size(490, 138);
            ((System.ComponentModel.ISupportInitialize)(this.pic_Control)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_Control;
        private System.Windows.Forms.PictureBox pic_Control;
        private SelectFile.usrc_SelectFile usrc_SelectPictureFile;
        private System.Windows.Forms.Panel panel1;
        private RadioButtonGlobal.RadioButtonGlobal radioButtonGlobal1;
    }
}
