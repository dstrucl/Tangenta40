namespace CodeTables
{
    partial class ResizeImage_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ResizeImage_Form));
            this.panel_Source = new System.Windows.Forms.Panel();
            this.pictureBox_Source = new System.Windows.Forms.PictureBox();
            this.pictureBox_Destination = new System.Windows.Forms.PictureBox();
            this.panel_Destination = new System.Windows.Forms.Panel();
            this.lblSourceWidth = new System.Windows.Forms.Label();
            this.lblSourceHeight = new System.Windows.Forms.Label();
            this.numericUpDown_TargetWidth = new System.Windows.Forms.NumericUpDown();
            this.lblDestinationWidth = new System.Windows.Forms.Label();
            this.numericUpDown_TargetHeight = new System.Windows.Forms.NumericUpDown();
            this.lblDestinationHeight = new System.Windows.Forms.Label();
            this.chkBox_KeepAspectRatio = new System.Windows.Forms.CheckBox();
            this.btnChangeSize = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.lbl_SourceSize = new System.Windows.Forms.Label();
            this.lbl_DestinationSize = new System.Windows.Forms.Label();
            this.cmbBoxPictureFormat = new System.Windows.Forms.ComboBox();
            this.lbl_Format = new System.Windows.Forms.Label();
            this.btnRotate90clockwise = new System.Windows.Forms.Button();
            this.btnRotate90contra_clockwise = new System.Windows.Forms.Button();
            this.btnFlipHorisontal = new System.Windows.Forms.Button();
            this.btnFlipVertical = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel_Source.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Source)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Destination)).BeginInit();
            this.panel_Destination.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_TargetWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_TargetHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_Source
            // 
            this.panel_Source.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_Source.AutoScroll = true;
            this.panel_Source.Controls.Add(this.pictureBox_Source);
            this.panel_Source.Location = new System.Drawing.Point(1, 72);
            this.panel_Source.Margin = new System.Windows.Forms.Padding(4);
            this.panel_Source.Name = "panel_Source";
            this.panel_Source.Size = new System.Drawing.Size(332, 343);
            this.panel_Source.TabIndex = 0;
            // 
            // pictureBox_Source
            // 
            this.pictureBox_Source.Location = new System.Drawing.Point(7, 4);
            this.pictureBox_Source.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox_Source.Name = "pictureBox_Source";
            this.pictureBox_Source.Size = new System.Drawing.Size(239, 192);
            this.pictureBox_Source.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox_Source.TabIndex = 0;
            this.pictureBox_Source.TabStop = false;
            // 
            // pictureBox_Destination
            // 
            this.pictureBox_Destination.Location = new System.Drawing.Point(4, 4);
            this.pictureBox_Destination.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox_Destination.Name = "pictureBox_Destination";
            this.pictureBox_Destination.Size = new System.Drawing.Size(274, 214);
            this.pictureBox_Destination.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox_Destination.TabIndex = 0;
            this.pictureBox_Destination.TabStop = false;
            // 
            // panel_Destination
            // 
            this.panel_Destination.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_Destination.AutoScroll = true;
            this.panel_Destination.Controls.Add(this.pictureBox_Destination);
            this.panel_Destination.Location = new System.Drawing.Point(4, 165);
            this.panel_Destination.Margin = new System.Windows.Forms.Padding(4);
            this.panel_Destination.Name = "panel_Destination";
            this.panel_Destination.Size = new System.Drawing.Size(409, 250);
            this.panel_Destination.TabIndex = 1;
            // 
            // lblSourceWidth
            // 
            this.lblSourceWidth.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSourceWidth.Location = new System.Drawing.Point(10, 36);
            this.lblSourceWidth.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSourceWidth.Name = "lblSourceWidth";
            this.lblSourceWidth.Size = new System.Drawing.Size(153, 32);
            this.lblSourceWidth.TabIndex = 2;
            this.lblSourceWidth.Text = "Width";
            this.lblSourceWidth.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSourceHeight
            // 
            this.lblSourceHeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSourceHeight.Location = new System.Drawing.Point(171, 37);
            this.lblSourceHeight.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSourceHeight.Name = "lblSourceHeight";
            this.lblSourceHeight.Size = new System.Drawing.Size(133, 32);
            this.lblSourceHeight.TabIndex = 4;
            this.lblSourceHeight.Text = "Height";
            this.lblSourceHeight.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numericUpDown_TargetWidth
            // 
            this.numericUpDown_TargetWidth.Location = new System.Drawing.Point(327, 76);
            this.numericUpDown_TargetWidth.Margin = new System.Windows.Forms.Padding(4);
            this.numericUpDown_TargetWidth.Name = "numericUpDown_TargetWidth";
            this.numericUpDown_TargetWidth.Size = new System.Drawing.Size(83, 23);
            this.numericUpDown_TargetWidth.TabIndex = 7;
            this.numericUpDown_TargetWidth.ValueChanged += new System.EventHandler(this.numericUpDown_TargetWidth_ValueChanged);
            // 
            // lblDestinationWidth
            // 
            this.lblDestinationWidth.Location = new System.Drawing.Point(224, 72);
            this.lblDestinationWidth.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDestinationWidth.Name = "lblDestinationWidth";
            this.lblDestinationWidth.Size = new System.Drawing.Size(95, 32);
            this.lblDestinationWidth.TabIndex = 6;
            this.lblDestinationWidth.Text = "Width";
            this.lblDestinationWidth.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblDestinationWidth.Click += new System.EventHandler(this.lblDestinationWidth_Click);
            // 
            // numericUpDown_TargetHeight
            // 
            this.numericUpDown_TargetHeight.Location = new System.Drawing.Point(327, 103);
            this.numericUpDown_TargetHeight.Margin = new System.Windows.Forms.Padding(4);
            this.numericUpDown_TargetHeight.Name = "numericUpDown_TargetHeight";
            this.numericUpDown_TargetHeight.Size = new System.Drawing.Size(83, 23);
            this.numericUpDown_TargetHeight.TabIndex = 9;
            this.numericUpDown_TargetHeight.ValueChanged += new System.EventHandler(this.numericUpDown_TargetHeight_ValueChanged);
            // 
            // lblDestinationHeight
            // 
            this.lblDestinationHeight.Location = new System.Drawing.Point(231, 97);
            this.lblDestinationHeight.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDestinationHeight.Name = "lblDestinationHeight";
            this.lblDestinationHeight.Size = new System.Drawing.Size(77, 32);
            this.lblDestinationHeight.TabIndex = 8;
            this.lblDestinationHeight.Text = "Height";
            this.lblDestinationHeight.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblDestinationHeight.Click += new System.EventHandler(this.lblDestinationHeight_Click);
            // 
            // chkBox_KeepAspectRatio
            // 
            this.chkBox_KeepAspectRatio.Location = new System.Drawing.Point(257, 37);
            this.chkBox_KeepAspectRatio.Name = "chkBox_KeepAspectRatio";
            this.chkBox_KeepAspectRatio.Size = new System.Drawing.Size(174, 24);
            this.chkBox_KeepAspectRatio.TabIndex = 10;
            this.chkBox_KeepAspectRatio.Text = "checkBox1";
            this.chkBox_KeepAspectRatio.UseVisualStyleBackColor = true;
            this.chkBox_KeepAspectRatio.CheckedChanged += new System.EventHandler(this.chkBox_KeepAspectRatio_CheckedChanged);
            // 
            // btnChangeSize
            // 
            this.btnChangeSize.Location = new System.Drawing.Point(8, 76);
            this.btnChangeSize.Name = "btnChangeSize";
            this.btnChangeSize.Size = new System.Drawing.Size(216, 36);
            this.btnChangeSize.TabIndex = 11;
            this.btnChangeSize.Text = "> Change Size >";
            this.btnChangeSize.UseVisualStyleBackColor = true;
            this.btnChangeSize.Click += new System.EventHandler(this.btnChangeSize_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOK.Location = new System.Drawing.Point(2, 426);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(95, 31);
            this.btnOK.TabIndex = 12;
            this.btnOK.Text = "btn_OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Cancel.Location = new System.Drawing.Point(103, 426);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(95, 31);
            this.btn_Cancel.TabIndex = 13;
            this.btn_Cancel.Text = "btn_OK";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // lbl_SourceSize
            // 
            this.lbl_SourceSize.Location = new System.Drawing.Point(13, 8);
            this.lbl_SourceSize.Name = "lbl_SourceSize";
            this.lbl_SourceSize.Size = new System.Drawing.Size(291, 20);
            this.lbl_SourceSize.TabIndex = 14;
            this.lbl_SourceSize.Text = "label1";
            this.lbl_SourceSize.Click += new System.EventHandler(this.lbl_SourceSize_Click);
            // 
            // lbl_DestinationSize
            // 
            this.lbl_DestinationSize.Location = new System.Drawing.Point(5, 8);
            this.lbl_DestinationSize.Name = "lbl_DestinationSize";
            this.lbl_DestinationSize.Size = new System.Drawing.Size(149, 20);
            this.lbl_DestinationSize.TabIndex = 15;
            this.lbl_DestinationSize.Text = "label1";
            // 
            // cmbBoxPictureFormat
            // 
            this.cmbBoxPictureFormat.FormattingEnabled = true;
            this.cmbBoxPictureFormat.Items.AddRange(new object[] {
            "Jpeg",
            "Gif",
            "Bmp",
            "Bmp 1Bit",
            "Png",
            "Tiff"});
            this.cmbBoxPictureFormat.Location = new System.Drawing.Point(104, 36);
            this.cmbBoxPictureFormat.Name = "cmbBoxPictureFormat";
            this.cmbBoxPictureFormat.Size = new System.Drawing.Size(143, 25);
            this.cmbBoxPictureFormat.TabIndex = 16;
            // 
            // lbl_Format
            // 
            this.lbl_Format.Location = new System.Drawing.Point(28, 41);
            this.lbl_Format.Name = "lbl_Format";
            this.lbl_Format.Size = new System.Drawing.Size(70, 20);
            this.lbl_Format.TabIndex = 17;
            this.lbl_Format.Text = "label1";
            this.lbl_Format.Click += new System.EventHandler(this.lbl_Format_Click);
            // 
            // btnRotate90clockwise
            // 
            this.btnRotate90clockwise.Image = ((System.Drawing.Image)(resources.GetObject("btnRotate90clockwise.Image")));
            this.btnRotate90clockwise.Location = new System.Drawing.Point(42, 119);
            this.btnRotate90clockwise.Name = "btnRotate90clockwise";
            this.btnRotate90clockwise.Size = new System.Drawing.Size(30, 40);
            this.btnRotate90clockwise.TabIndex = 18;
            this.btnRotate90clockwise.UseVisualStyleBackColor = true;
            this.btnRotate90clockwise.Click += new System.EventHandler(this.btnRotate90clockwise_Click);
            // 
            // btnRotate90contra_clockwise
            // 
            this.btnRotate90contra_clockwise.Image = ((System.Drawing.Image)(resources.GetObject("btnRotate90contra_clockwise.Image")));
            this.btnRotate90contra_clockwise.Location = new System.Drawing.Point(7, 119);
            this.btnRotate90contra_clockwise.Name = "btnRotate90contra_clockwise";
            this.btnRotate90contra_clockwise.Size = new System.Drawing.Size(30, 40);
            this.btnRotate90contra_clockwise.TabIndex = 19;
            this.btnRotate90contra_clockwise.UseVisualStyleBackColor = true;
            this.btnRotate90contra_clockwise.Click += new System.EventHandler(this.btnRotate90contra_clockwise_Click);
            // 
            // btnFlipHorisontal
            // 
            this.btnFlipHorisontal.Image = ((System.Drawing.Image)(resources.GetObject("btnFlipHorisontal.Image")));
            this.btnFlipHorisontal.Location = new System.Drawing.Point(112, 119);
            this.btnFlipHorisontal.Name = "btnFlipHorisontal";
            this.btnFlipHorisontal.Size = new System.Drawing.Size(42, 40);
            this.btnFlipHorisontal.TabIndex = 20;
            this.btnFlipHorisontal.UseVisualStyleBackColor = true;
            this.btnFlipHorisontal.Click += new System.EventHandler(this.btnFlipHorisontal_Click);
            // 
            // btnFlipVertical
            // 
            this.btnFlipVertical.Image = ((System.Drawing.Image)(resources.GetObject("btnFlipVertical.Image")));
            this.btnFlipVertical.Location = new System.Drawing.Point(76, 119);
            this.btnFlipVertical.Name = "btnFlipVertical";
            this.btnFlipVertical.Size = new System.Drawing.Size(30, 40);
            this.btnFlipVertical.TabIndex = 21;
            this.btnFlipVertical.UseVisualStyleBackColor = true;
            this.btnFlipVertical.Click += new System.EventHandler(this.btnFlipVertical_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(2, 1);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lblSourceWidth);
            this.splitContainer1.Panel1.Controls.Add(this.panel_Source);
            this.splitContainer1.Panel1.Controls.Add(this.lblSourceHeight);
            this.splitContainer1.Panel1.Controls.Add(this.lbl_SourceSize);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.chkBox_KeepAspectRatio);
            this.splitContainer1.Panel2.Controls.Add(this.btnFlipVertical);
            this.splitContainer1.Panel2.Controls.Add(this.btnFlipHorisontal);
            this.splitContainer1.Panel2.Controls.Add(this.panel_Destination);
            this.splitContainer1.Panel2.Controls.Add(this.btnRotate90contra_clockwise);
            this.splitContainer1.Panel2.Controls.Add(this.lblDestinationWidth);
            this.splitContainer1.Panel2.Controls.Add(this.btnRotate90clockwise);
            this.splitContainer1.Panel2.Controls.Add(this.numericUpDown_TargetWidth);
            this.splitContainer1.Panel2.Controls.Add(this.lblDestinationHeight);
            this.splitContainer1.Panel2.Controls.Add(this.lbl_Format);
            this.splitContainer1.Panel2.Controls.Add(this.numericUpDown_TargetHeight);
            this.splitContainer1.Panel2.Controls.Add(this.cmbBoxPictureFormat);
            this.splitContainer1.Panel2.Controls.Add(this.btnChangeSize);
            this.splitContainer1.Panel2.Controls.Add(this.lbl_DestinationSize);
            this.splitContainer1.Size = new System.Drawing.Size(761, 419);
            this.splitContainer1.SplitterDistance = 338;
            this.splitContainer1.SplitterWidth = 6;
            this.splitContainer1.TabIndex = 22;
            // 
            // ResizeImage_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(766, 461);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btnOK);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ResizeImage_Form";
            this.Text = "ResizeImage_Form";
            this.panel_Source.ResumeLayout(false);
            this.panel_Source.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Source)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Destination)).EndInit();
            this.panel_Destination.ResumeLayout(false);
            this.panel_Destination.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_TargetWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_TargetHeight)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_Source;
        private System.Windows.Forms.PictureBox pictureBox_Source;
        private System.Windows.Forms.PictureBox pictureBox_Destination;
        private System.Windows.Forms.Panel panel_Destination;
        private System.Windows.Forms.Label lblSourceWidth;
        private System.Windows.Forms.Label lblSourceHeight;
        private System.Windows.Forms.NumericUpDown numericUpDown_TargetWidth;
        private System.Windows.Forms.Label lblDestinationWidth;
        private System.Windows.Forms.NumericUpDown numericUpDown_TargetHeight;
        private System.Windows.Forms.Label lblDestinationHeight;
        private System.Windows.Forms.CheckBox chkBox_KeepAspectRatio;
        private System.Windows.Forms.Button btnChangeSize;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Label lbl_SourceSize;
        private System.Windows.Forms.Label lbl_DestinationSize;
        private System.Windows.Forms.ComboBox cmbBoxPictureFormat;
        private System.Windows.Forms.Label lbl_Format;
        private System.Windows.Forms.Button btnRotate90clockwise;
        private System.Windows.Forms.Button btnRotate90contra_clockwise;
        private System.Windows.Forms.Button btnFlipHorisontal;
        private System.Windows.Forms.Button btnFlipVertical;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}