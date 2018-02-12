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
            this.txt_Control = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chk_ImageIncluded = new System.Windows.Forms.CheckBox();
            this.btn_Link = new System.Windows.Forms.Button();
            this.lbl_Name = new System.Windows.Forms.Label();
            this.txt_ControlName = new System.Windows.Forms.TextBox();
            this.radioButtonGlobal1 = new RadioButtonGlobal.RadioButtonGlobal();
            this.pic_Control = new System.Windows.Forms.PictureBox();
            this.list_Link = new System.Windows.Forms.ListBox();
            this.lbl_LinkedControls = new System.Windows.Forms.Label();
            this.lbl_ID = new System.Windows.Forms.Label();
            this.txt_ID = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Control)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_Control
            // 
            this.txt_Control.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Control.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_Control.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_Control.Location = new System.Drawing.Point(2, 10);
            this.txt_Control.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.txt_Control.Name = "txt_Control";
            this.txt_Control.ReadOnly = true;
            this.txt_Control.Size = new System.Drawing.Size(482, 12);
            this.txt_Control.TabIndex = 3;
            this.txt_Control.Text = "Dialog";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.lbl_ID);
            this.panel1.Controls.Add(this.txt_ID);
            this.panel1.Controls.Add(this.chk_ImageIncluded);
            this.panel1.Controls.Add(this.btn_Link);
            this.panel1.Controls.Add(this.lbl_Name);
            this.panel1.Controls.Add(this.txt_ControlName);
            this.panel1.Controls.Add(this.radioButtonGlobal1);
            this.panel1.Controls.Add(this.pic_Control);
            this.panel1.Controls.Add(this.txt_Control);
            this.panel1.Controls.Add(this.list_Link);
            this.panel1.Controls.Add(this.lbl_LinkedControls);
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(486, 205);
            this.panel1.TabIndex = 6;
            // 
            // chk_ImageIncluded
            // 
            this.chk_ImageIncluded.AutoSize = true;
            this.chk_ImageIncluded.Checked = true;
            this.chk_ImageIncluded.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_ImageIncluded.Location = new System.Drawing.Point(3, 74);
            this.chk_ImageIncluded.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chk_ImageIncluded.Name = "chk_ImageIncluded";
            this.chk_ImageIncluded.Size = new System.Drawing.Size(93, 17);
            this.chk_ImageIncluded.TabIndex = 12;
            this.chk_ImageIncluded.Text = "Include Image";
            this.chk_ImageIncluded.UseVisualStyleBackColor = true;
            this.chk_ImageIncluded.AppearanceChanged += new System.EventHandler(this.chk_IncludeImage);
            // 
            // btn_Link
            // 
            this.btn_Link.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Link.Image = global::HUDCMS.Properties.Resources.NoLink;
            this.btn_Link.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_Link.Location = new System.Drawing.Point(400, 57);
            this.btn_Link.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Link.Name = "btn_Link";
            this.btn_Link.Size = new System.Drawing.Size(84, 48);
            this.btn_Link.TabIndex = 9;
            this.btn_Link.Text = "Add Link";
            this.btn_Link.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_Link.UseVisualStyleBackColor = true;
            this.btn_Link.Click += new System.EventHandler(this.btn_Link_Click);
            // 
            // lbl_Name
            // 
            this.lbl_Name.AutoSize = true;
            this.lbl_Name.Location = new System.Drawing.Point(10, 32);
            this.lbl_Name.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_Name.Name = "lbl_Name";
            this.lbl_Name.Size = new System.Drawing.Size(35, 13);
            this.lbl_Name.TabIndex = 8;
            this.lbl_Name.Text = "Name";
            // 
            // txt_ControlName
            // 
            this.txt_ControlName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_ControlName.Location = new System.Drawing.Point(52, 30);
            this.txt_ControlName.Margin = new System.Windows.Forms.Padding(2);
            this.txt_ControlName.Name = "txt_ControlName";
            this.txt_ControlName.ReadOnly = true;
            this.txt_ControlName.Size = new System.Drawing.Size(364, 20);
            this.txt_ControlName.TabIndex = 7;
            // 
            // radioButtonGlobal1
            // 
            this.radioButtonGlobal1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radioButtonGlobal1.BackColor = System.Drawing.SystemColors.Control;
            this.radioButtonGlobal1.Checked = false;
            this.radioButtonGlobal1.HighlightBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(247)))), ((int)(((byte)(132)))));
            this.radioButtonGlobal1.Location = new System.Drawing.Point(422, 26);
            this.radioButtonGlobal1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioButtonGlobal1.Name = "radioButtonGlobal1";
            this.radioButtonGlobal1.ParentBackColor = System.Drawing.SystemColors.Control;
            this.radioButtonGlobal1.Size = new System.Drawing.Size(62, 25);
            this.radioButtonGlobal1.TabIndex = 6;
            this.radioButtonGlobal1.CheckChanged += new RadioButtonGlobal.RadioButtonGlobal.delegateCheckChanged(this.radioButtonGlobal1_CheckChanged);
            this.radioButtonGlobal1.SetBackColor += new RadioButtonGlobal.RadioButtonGlobal.delegateSetBackColor(this.radioButtonGlobal1_SetBackColor);
            this.radioButtonGlobal1.Load += new System.EventHandler(this.radioButtonGlobal1_Load);
            // 
            // pic_Control
            // 
            this.pic_Control.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pic_Control.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic_Control.Location = new System.Drawing.Point(3, 93);
            this.pic_Control.Name = "pic_Control";
            this.pic_Control.Size = new System.Drawing.Size(156, 109);
            this.pic_Control.TabIndex = 4;
            this.pic_Control.TabStop = false;
            // 
            // list_Link
            // 
            this.list_Link.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.list_Link.FormattingEnabled = true;
            this.list_Link.HorizontalScrollbar = true;
            this.list_Link.Location = new System.Drawing.Point(165, 93);
            this.list_Link.Margin = new System.Windows.Forms.Padding(2);
            this.list_Link.Name = "list_Link";
            this.list_Link.Size = new System.Drawing.Size(143, 108);
            this.list_Link.TabIndex = 10;
            this.list_Link.Visible = false;
            // 
            // lbl_LinkedControls
            // 
            this.lbl_LinkedControls.AutoSize = true;
            this.lbl_LinkedControls.Location = new System.Drawing.Point(165, 77);
            this.lbl_LinkedControls.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_LinkedControls.Name = "lbl_LinkedControls";
            this.lbl_LinkedControls.Size = new System.Drawing.Size(80, 13);
            this.lbl_LinkedControls.TabIndex = 11;
            this.lbl_LinkedControls.Text = "Linked Controls";
            // 
            // lbl_ID
            // 
            this.lbl_ID.AutoSize = true;
            this.lbl_ID.Location = new System.Drawing.Point(10, 55);
            this.lbl_ID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_ID.Name = "lbl_ID";
            this.lbl_ID.Size = new System.Drawing.Size(15, 13);
            this.lbl_ID.TabIndex = 14;
            this.lbl_ID.Text = "id";
            // 
            // txt_ID
            // 
            this.txt_ID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_ID.Location = new System.Drawing.Point(29, 52);
            this.txt_ID.Margin = new System.Windows.Forms.Padding(2);
            this.txt_ID.Name = "txt_ID";
            this.txt_ID.ReadOnly = true;
            this.txt_ID.Size = new System.Drawing.Size(327, 20);
            this.txt_ID.TabIndex = 13;
            // 
            // usrc_Control
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "usrc_Control";
            this.Size = new System.Drawing.Size(490, 209);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Control)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        internal System.Windows.Forms.TextBox txt_Control;
        internal System.Windows.Forms.PictureBox pic_Control;
        private System.Windows.Forms.Label lbl_Name;
        internal System.Windows.Forms.TextBox txt_ControlName;
        private RadioButtonGlobal.RadioButtonGlobal radioButtonGlobal1;
        internal System.Windows.Forms.Button btn_Link;
        internal System.Windows.Forms.ListBox list_Link;
        internal System.Windows.Forms.Label lbl_LinkedControls;
        private System.Windows.Forms.CheckBox chk_ImageIncluded;
        private System.Windows.Forms.Label lbl_ID;
        internal System.Windows.Forms.TextBox txt_ID;
    }
}
