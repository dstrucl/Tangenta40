namespace LayoutManager
{
    partial class usrc_EditLayout
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
            this.components = new System.ComponentModel.Container();
            this.nmUpDnX = new System.Windows.Forms.NumericUpDown();
            this.nmUpDnY = new System.Windows.Forms.NumericUpDown();
            this.lbl_X = new System.Windows.Forms.Label();
            this.lbl_Y = new System.Windows.Forms.Label();
            this.btn_Up = new System.Windows.Forms.Button();
            this.btn_Down = new System.Windows.Forms.Button();
            this.btn_Left = new System.Windows.Forms.Button();
            this.btn_Right = new System.Windows.Forms.Button();
            this.lbl_Width = new System.Windows.Forms.Label();
            this.nmUpDnWidth = new System.Windows.Forms.NumericUpDown();
            this.lbl_Height = new System.Windows.Forms.Label();
            this.nmUpDnHeight = new System.Windows.Forms.NumericUpDown();
            this.btn_WidthMinus = new System.Windows.Forms.Button();
            this.btn_WidthPlus = new System.Windows.Forms.Button();
            this.btn_HeightMinus = new System.Windows.Forms.Button();
            this.btn_HeightPlus = new System.Windows.Forms.Button();
            this.txtControl = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.grpAnchor = new System.Windows.Forms.GroupBox();
            this.chkAnchorRight = new System.Windows.Forms.CheckBox();
            this.chkAnchorLeft = new System.Windows.Forms.CheckBox();
            this.chkAnchorBottom = new System.Windows.Forms.CheckBox();
            this.chkAnchorTop = new System.Windows.Forms.CheckBox();
            this.btn_ForeColorDefault = new System.Windows.Forms.Button();
            this.btn_ForeColor = new System.Windows.Forms.Button();
            this.btn_BackColor = new System.Windows.Forms.Button();
            this.btn_BackColorDefault = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbl_BackColor = new System.Windows.Forms.Label();
            this.lbl_BackColorDefault = new System.Windows.Forms.Label();
            this.lbl_ForeColor = new System.Windows.Forms.Label();
            this.lbl_ForeColorDefault = new System.Windows.Forms.Label();
            this.timer_ControlHighlight = new System.Windows.Forms.Timer(this.components);
            this.btn_Highlight = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nmUpDnX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmUpDnY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmUpDnWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmUpDnHeight)).BeginInit();
            this.grpAnchor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // nmUpDnX
            // 
            this.nmUpDnX.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nmUpDnX.Location = new System.Drawing.Point(91, 97);
            this.nmUpDnX.Name = "nmUpDnX";
            this.nmUpDnX.Size = new System.Drawing.Size(91, 26);
            this.nmUpDnX.TabIndex = 0;
            this.nmUpDnX.ValueChanged += new System.EventHandler(this.nmUpDnX_ValueChanged);
            // 
            // nmUpDnY
            // 
            this.nmUpDnY.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nmUpDnY.Location = new System.Drawing.Point(91, 129);
            this.nmUpDnY.Name = "nmUpDnY";
            this.nmUpDnY.Size = new System.Drawing.Size(91, 26);
            this.nmUpDnY.TabIndex = 1;
            this.nmUpDnY.ValueChanged += new System.EventHandler(this.nmUpDnY_ValueChanged);
            // 
            // lbl_X
            // 
            this.lbl_X.AutoSize = true;
            this.lbl_X.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_X.Location = new System.Drawing.Point(65, 102);
            this.lbl_X.Name = "lbl_X";
            this.lbl_X.Size = new System.Drawing.Size(20, 20);
            this.lbl_X.TabIndex = 2;
            this.lbl_X.Text = "X";
            // 
            // lbl_Y
            // 
            this.lbl_Y.AutoSize = true;
            this.lbl_Y.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Y.Location = new System.Drawing.Point(65, 132);
            this.lbl_Y.Name = "lbl_Y";
            this.lbl_Y.Size = new System.Drawing.Size(20, 20);
            this.lbl_Y.TabIndex = 3;
            this.lbl_Y.Text = "Y";
            // 
            // btn_Up
            // 
            this.btn_Up.Location = new System.Drawing.Point(64, 42);
            this.btn_Up.Name = "btn_Up";
            this.btn_Up.Size = new System.Drawing.Size(124, 41);
            this.btn_Up.TabIndex = 4;
            this.btn_Up.Text = "Up";
            this.btn_Up.UseVisualStyleBackColor = true;
            this.btn_Up.Click += new System.EventHandler(this.btn_Up_Click);
            // 
            // btn_Down
            // 
            this.btn_Down.Location = new System.Drawing.Point(64, 161);
            this.btn_Down.Name = "btn_Down";
            this.btn_Down.Size = new System.Drawing.Size(124, 41);
            this.btn_Down.TabIndex = 5;
            this.btn_Down.Text = "Down";
            this.btn_Down.UseVisualStyleBackColor = true;
            this.btn_Down.Click += new System.EventHandler(this.btn_Down_Click);
            // 
            // btn_Left
            // 
            this.btn_Left.Location = new System.Drawing.Point(-1, 85);
            this.btn_Left.Name = "btn_Left";
            this.btn_Left.Size = new System.Drawing.Size(56, 77);
            this.btn_Left.TabIndex = 6;
            this.btn_Left.Text = "Left";
            this.btn_Left.UseVisualStyleBackColor = true;
            this.btn_Left.Click += new System.EventHandler(this.btn_Left_Click);
            // 
            // btn_Right
            // 
            this.btn_Right.Location = new System.Drawing.Point(193, 85);
            this.btn_Right.Name = "btn_Right";
            this.btn_Right.Size = new System.Drawing.Size(60, 77);
            this.btn_Right.TabIndex = 7;
            this.btn_Right.Text = "Right";
            this.btn_Right.UseVisualStyleBackColor = true;
            this.btn_Right.Click += new System.EventHandler(this.btn_Right_Click);
            // 
            // lbl_Width
            // 
            this.lbl_Width.AutoSize = true;
            this.lbl_Width.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Width.Location = new System.Drawing.Point(297, 46);
            this.lbl_Width.Name = "lbl_Width";
            this.lbl_Width.Size = new System.Drawing.Size(50, 20);
            this.lbl_Width.TabIndex = 9;
            this.lbl_Width.Text = "Width";
            // 
            // nmUpDnWidth
            // 
            this.nmUpDnWidth.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nmUpDnWidth.Location = new System.Drawing.Point(353, 44);
            this.nmUpDnWidth.Name = "nmUpDnWidth";
            this.nmUpDnWidth.Size = new System.Drawing.Size(78, 26);
            this.nmUpDnWidth.TabIndex = 8;
            this.nmUpDnWidth.ValueChanged += new System.EventHandler(this.nmUpDnWidth_ValueChanged);
            // 
            // lbl_Height
            // 
            this.lbl_Height.AutoSize = true;
            this.lbl_Height.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Height.Location = new System.Drawing.Point(291, 87);
            this.lbl_Height.Name = "lbl_Height";
            this.lbl_Height.Size = new System.Drawing.Size(56, 20);
            this.lbl_Height.TabIndex = 11;
            this.lbl_Height.Text = "Height";
            // 
            // nmUpDnHeight
            // 
            this.nmUpDnHeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nmUpDnHeight.Location = new System.Drawing.Point(353, 85);
            this.nmUpDnHeight.Name = "nmUpDnHeight";
            this.nmUpDnHeight.Size = new System.Drawing.Size(78, 26);
            this.nmUpDnHeight.TabIndex = 10;
            this.nmUpDnHeight.ValueChanged += new System.EventHandler(this.nmUpDnHeight_ValueChanged);
            // 
            // btn_WidthMinus
            // 
            this.btn_WidthMinus.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_WidthMinus.Location = new System.Drawing.Point(446, 41);
            this.btn_WidthMinus.Name = "btn_WidthMinus";
            this.btn_WidthMinus.Size = new System.Drawing.Size(59, 29);
            this.btn_WidthMinus.TabIndex = 12;
            this.btn_WidthMinus.Text = "-";
            this.btn_WidthMinus.UseVisualStyleBackColor = true;
            this.btn_WidthMinus.Click += new System.EventHandler(this.btn_WidthMinus_Click);
            // 
            // btn_WidthPlus
            // 
            this.btn_WidthPlus.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_WidthPlus.Location = new System.Drawing.Point(514, 42);
            this.btn_WidthPlus.Name = "btn_WidthPlus";
            this.btn_WidthPlus.Size = new System.Drawing.Size(56, 29);
            this.btn_WidthPlus.TabIndex = 13;
            this.btn_WidthPlus.Text = "+";
            this.btn_WidthPlus.UseVisualStyleBackColor = true;
            this.btn_WidthPlus.Click += new System.EventHandler(this.btn_WidthPlus_Click);
            // 
            // btn_HeightMinus
            // 
            this.btn_HeightMinus.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_HeightMinus.Location = new System.Drawing.Point(450, 87);
            this.btn_HeightMinus.Name = "btn_HeightMinus";
            this.btn_HeightMinus.Size = new System.Drawing.Size(55, 29);
            this.btn_HeightMinus.TabIndex = 14;
            this.btn_HeightMinus.Text = "-";
            this.btn_HeightMinus.UseVisualStyleBackColor = true;
            this.btn_HeightMinus.Click += new System.EventHandler(this.btn_HeightMinus_Click);
            // 
            // btn_HeightPlus
            // 
            this.btn_HeightPlus.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_HeightPlus.Location = new System.Drawing.Point(515, 85);
            this.btn_HeightPlus.Name = "btn_HeightPlus";
            this.btn_HeightPlus.Size = new System.Drawing.Size(55, 27);
            this.btn_HeightPlus.TabIndex = 15;
            this.btn_HeightPlus.Text = "+";
            this.btn_HeightPlus.UseVisualStyleBackColor = true;
            this.btn_HeightPlus.Click += new System.EventHandler(this.btn_HeightPlus_Click);
            // 
            // txtControl
            // 
            this.txtControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtControl.Location = new System.Drawing.Point(102, 9);
            this.txtControl.Name = "txtControl";
            this.txtControl.Size = new System.Drawing.Size(389, 26);
            this.txtControl.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 20);
            this.label2.TabIndex = 17;
            this.label2.Text = "Control";
            // 
            // grpAnchor
            // 
            this.grpAnchor.Controls.Add(this.chkAnchorRight);
            this.grpAnchor.Controls.Add(this.chkAnchorLeft);
            this.grpAnchor.Controls.Add(this.chkAnchorBottom);
            this.grpAnchor.Controls.Add(this.chkAnchorTop);
            this.grpAnchor.Location = new System.Drawing.Point(295, 122);
            this.grpAnchor.Name = "grpAnchor";
            this.grpAnchor.Size = new System.Drawing.Size(208, 77);
            this.grpAnchor.TabIndex = 18;
            this.grpAnchor.TabStop = false;
            this.grpAnchor.Text = "Anchor";
            // 
            // chkAnchorRight
            // 
            this.chkAnchorRight.AutoSize = true;
            this.chkAnchorRight.Location = new System.Drawing.Point(119, 25);
            this.chkAnchorRight.Name = "chkAnchorRight";
            this.chkAnchorRight.Size = new System.Drawing.Size(66, 24);
            this.chkAnchorRight.TabIndex = 3;
            this.chkAnchorRight.Text = "Right";
            this.chkAnchorRight.UseVisualStyleBackColor = true;
            // 
            // chkAnchorLeft
            // 
            this.chkAnchorLeft.AutoSize = true;
            this.chkAnchorLeft.Location = new System.Drawing.Point(6, 25);
            this.chkAnchorLeft.Name = "chkAnchorLeft";
            this.chkAnchorLeft.Size = new System.Drawing.Size(56, 24);
            this.chkAnchorLeft.TabIndex = 2;
            this.chkAnchorLeft.Text = "Left";
            this.chkAnchorLeft.UseVisualStyleBackColor = true;
            // 
            // chkAnchorBottom
            // 
            this.chkAnchorBottom.AutoSize = true;
            this.chkAnchorBottom.Location = new System.Drawing.Point(67, 46);
            this.chkAnchorBottom.Name = "chkAnchorBottom";
            this.chkAnchorBottom.Size = new System.Drawing.Size(80, 24);
            this.chkAnchorBottom.TabIndex = 1;
            this.chkAnchorBottom.Text = "Bottom";
            this.chkAnchorBottom.UseVisualStyleBackColor = true;
            // 
            // chkAnchorTop
            // 
            this.chkAnchorTop.AutoSize = true;
            this.chkAnchorTop.Location = new System.Drawing.Point(69, 2);
            this.chkAnchorTop.Name = "chkAnchorTop";
            this.chkAnchorTop.Size = new System.Drawing.Size(55, 24);
            this.chkAnchorTop.TabIndex = 0;
            this.chkAnchorTop.Text = "Top";
            this.chkAnchorTop.UseVisualStyleBackColor = true;
            // 
            // btn_ForeColorDefault
            // 
            this.btn_ForeColorDefault.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ForeColorDefault.Location = new System.Drawing.Point(147, 237);
            this.btn_ForeColorDefault.Name = "btn_ForeColorDefault";
            this.btn_ForeColorDefault.Size = new System.Drawing.Size(140, 51);
            this.btn_ForeColorDefault.TabIndex = 22;
            this.btn_ForeColorDefault.Text = "Fore Color Default";
            this.btn_ForeColorDefault.UseVisualStyleBackColor = true;
            this.btn_ForeColorDefault.Click += new System.EventHandler(this.btn_ForeColorDefault_Click);
            // 
            // btn_ForeColor
            // 
            this.btn_ForeColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ForeColor.Location = new System.Drawing.Point(443, 237);
            this.btn_ForeColor.Name = "btn_ForeColor";
            this.btn_ForeColor.Size = new System.Drawing.Size(140, 51);
            this.btn_ForeColor.TabIndex = 23;
            this.btn_ForeColor.Text = "Fore Color";
            this.btn_ForeColor.UseVisualStyleBackColor = true;
            this.btn_ForeColor.Click += new System.EventHandler(this.btn_ForeColor_Click);
            // 
            // btn_BackColor
            // 
            this.btn_BackColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_BackColor.Location = new System.Drawing.Point(295, 237);
            this.btn_BackColor.Name = "btn_BackColor";
            this.btn_BackColor.Size = new System.Drawing.Size(140, 51);
            this.btn_BackColor.TabIndex = 27;
            this.btn_BackColor.Text = "Back Color";
            this.btn_BackColor.UseVisualStyleBackColor = true;
            this.btn_BackColor.Click += new System.EventHandler(this.btn_BackColor_Click);
            // 
            // btn_BackColorDefault
            // 
            this.btn_BackColorDefault.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_BackColorDefault.Location = new System.Drawing.Point(-1, 237);
            this.btn_BackColorDefault.Name = "btn_BackColorDefault";
            this.btn_BackColorDefault.Size = new System.Drawing.Size(140, 51);
            this.btn_BackColorDefault.TabIndex = 26;
            this.btn_BackColorDefault.Text = "Back Color Default";
            this.btn_BackColorDefault.UseVisualStyleBackColor = true;
            this.btn_BackColorDefault.Click += new System.EventHandler(this.btn_BackColorDefault_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Location = new System.Drawing.Point(0, 307);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(590, 286);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 19;
            this.pictureBox1.TabStop = false;
            // 
            // lbl_BackColor
            // 
            this.lbl_BackColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_BackColor.Location = new System.Drawing.Point(328, 214);
            this.lbl_BackColor.Name = "lbl_BackColor";
            this.lbl_BackColor.Size = new System.Drawing.Size(91, 20);
            this.lbl_BackColor.TabIndex = 25;
            this.lbl_BackColor.Text = "Back color:";
            this.lbl_BackColor.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lbl_BackColorDefault
            // 
            this.lbl_BackColorDefault.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_BackColorDefault.Location = new System.Drawing.Point(1, 214);
            this.lbl_BackColorDefault.Name = "lbl_BackColorDefault";
            this.lbl_BackColorDefault.Size = new System.Drawing.Size(149, 20);
            this.lbl_BackColorDefault.TabIndex = 24;
            this.lbl_BackColorDefault.Text = "Back color default:";
            // 
            // lbl_ForeColor
            // 
            this.lbl_ForeColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ForeColor.Location = new System.Drawing.Point(440, 214);
            this.lbl_ForeColor.Name = "lbl_ForeColor";
            this.lbl_ForeColor.Size = new System.Drawing.Size(130, 20);
            this.lbl_ForeColor.TabIndex = 21;
            this.lbl_ForeColor.Text = "Fore color:";
            this.lbl_ForeColor.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lbl_ForeColorDefault
            // 
            this.lbl_ForeColorDefault.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ForeColorDefault.Location = new System.Drawing.Point(156, 214);
            this.lbl_ForeColorDefault.Name = "lbl_ForeColorDefault";
            this.lbl_ForeColorDefault.Size = new System.Drawing.Size(139, 20);
            this.lbl_ForeColorDefault.TabIndex = 20;
            this.lbl_ForeColorDefault.Text = "Fore color default:";
            // 
            // timer_ControlHighlight
            // 
            this.timer_ControlHighlight.Interval = 200;
            this.timer_ControlHighlight.Tick += new System.EventHandler(this.timer_ControlHighlight_Tick);
            // 
            // btn_Highlight
            // 
            this.btn_Highlight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Highlight.Location = new System.Drawing.Point(502, 6);
            this.btn_Highlight.Name = "btn_Highlight";
            this.btn_Highlight.Size = new System.Drawing.Size(80, 28);
            this.btn_Highlight.TabIndex = 28;
            this.btn_Highlight.Text = "Highlight";
            this.btn_Highlight.UseVisualStyleBackColor = true;
            this.btn_Highlight.Click += new System.EventHandler(this.btn_Highlight_Click);
            // 
            // usrc_EditLayout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.btn_Highlight);
            this.Controls.Add(this.btn_BackColor);
            this.Controls.Add(this.btn_BackColorDefault);
            this.Controls.Add(this.lbl_BackColor);
            this.Controls.Add(this.lbl_BackColorDefault);
            this.Controls.Add(this.btn_ForeColor);
            this.Controls.Add(this.btn_ForeColorDefault);
            this.Controls.Add(this.lbl_ForeColor);
            this.Controls.Add(this.lbl_ForeColorDefault);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.grpAnchor);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtControl);
            this.Controls.Add(this.btn_HeightPlus);
            this.Controls.Add(this.btn_HeightMinus);
            this.Controls.Add(this.btn_WidthPlus);
            this.Controls.Add(this.btn_WidthMinus);
            this.Controls.Add(this.lbl_Height);
            this.Controls.Add(this.nmUpDnHeight);
            this.Controls.Add(this.lbl_Width);
            this.Controls.Add(this.nmUpDnWidth);
            this.Controls.Add(this.btn_Right);
            this.Controls.Add(this.btn_Left);
            this.Controls.Add(this.btn_Down);
            this.Controls.Add(this.btn_Up);
            this.Controls.Add(this.lbl_Y);
            this.Controls.Add(this.lbl_X);
            this.Controls.Add(this.nmUpDnY);
            this.Controls.Add(this.nmUpDnX);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "usrc_EditLayout";
            this.Size = new System.Drawing.Size(593, 596);
            ((System.ComponentModel.ISupportInitialize)(this.nmUpDnX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmUpDnY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmUpDnWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmUpDnHeight)).EndInit();
            this.grpAnchor.ResumeLayout(false);
            this.grpAnchor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nmUpDnX;
        private System.Windows.Forms.NumericUpDown nmUpDnY;
        private System.Windows.Forms.Label lbl_X;
        private System.Windows.Forms.Label lbl_Y;
        private System.Windows.Forms.Button btn_Up;
        private System.Windows.Forms.Button btn_Down;
        private System.Windows.Forms.Button btn_Left;
        private System.Windows.Forms.Button btn_Right;
        private System.Windows.Forms.Label lbl_Width;
        private System.Windows.Forms.NumericUpDown nmUpDnWidth;
        private System.Windows.Forms.Label lbl_Height;
        private System.Windows.Forms.NumericUpDown nmUpDnHeight;
        private System.Windows.Forms.Button btn_WidthMinus;
        private System.Windows.Forms.Button btn_WidthPlus;
        private System.Windows.Forms.Button btn_HeightMinus;
        private System.Windows.Forms.Button btn_HeightPlus;
        private System.Windows.Forms.TextBox txtControl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox grpAnchor;
        private System.Windows.Forms.CheckBox chkAnchorRight;
        private System.Windows.Forms.CheckBox chkAnchorLeft;
        private System.Windows.Forms.CheckBox chkAnchorBottom;
        private System.Windows.Forms.CheckBox chkAnchorTop;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btn_ForeColorDefault;
        private System.Windows.Forms.Button btn_ForeColor;
        private System.Windows.Forms.Button btn_BackColor;
        private System.Windows.Forms.Button btn_BackColorDefault;
        private System.Windows.Forms.Label lbl_BackColor;
        private System.Windows.Forms.Label lbl_BackColorDefault;
        private System.Windows.Forms.Label lbl_ForeColor;
        private System.Windows.Forms.Label lbl_ForeColorDefault;
        private System.Windows.Forms.Timer timer_ControlHighlight;
        private System.Windows.Forms.Button btn_Highlight;
    }
}
