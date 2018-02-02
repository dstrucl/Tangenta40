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
            this.lbl_Name = new System.Windows.Forms.Label();
            this.txt_ControlName = new System.Windows.Forms.TextBox();
            this.radioButtonGlobal1 = new RadioButtonGlobal.RadioButtonGlobal();
            this.btn_Link = new System.Windows.Forms.Button();
            this.pic_Control = new System.Windows.Forms.PictureBox();
            this.list_Link = new System.Windows.Forms.ListBox();
            this.lbl_LinkedControls = new System.Windows.Forms.Label();
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
            this.txt_Control.Location = new System.Drawing.Point(5, 7);
            this.txt_Control.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.txt_Control.Name = "txt_Control";
            this.txt_Control.ReadOnly = true;
            this.txt_Control.Size = new System.Drawing.Size(600, 15);
            this.txt_Control.TabIndex = 3;
            this.txt_Control.Text = "Dialog";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.lbl_LinkedControls);
            this.panel1.Controls.Add(this.list_Link);
            this.panel1.Controls.Add(this.btn_Link);
            this.panel1.Controls.Add(this.lbl_Name);
            this.panel1.Controls.Add(this.txt_ControlName);
            this.panel1.Controls.Add(this.radioButtonGlobal1);
            this.panel1.Controls.Add(this.pic_Control);
            this.panel1.Controls.Add(this.txt_Control);
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(608, 207);
            this.panel1.TabIndex = 6;
            // 
            // lbl_Name
            // 
            this.lbl_Name.AutoSize = true;
            this.lbl_Name.Location = new System.Drawing.Point(13, 40);
            this.lbl_Name.Name = "lbl_Name";
            this.lbl_Name.Size = new System.Drawing.Size(45, 17);
            this.lbl_Name.TabIndex = 8;
            this.lbl_Name.Text = "Name";
            // 
            // txt_ControlName
            // 
            this.txt_ControlName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_ControlName.Location = new System.Drawing.Point(65, 37);
            this.txt_ControlName.Name = "txt_ControlName";
            this.txt_ControlName.ReadOnly = true;
            this.txt_ControlName.Size = new System.Drawing.Size(454, 22);
            this.txt_ControlName.TabIndex = 7;
            // 
            // radioButtonGlobal1
            // 
            this.radioButtonGlobal1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radioButtonGlobal1.BackColor = System.Drawing.SystemColors.Control;
            this.radioButtonGlobal1.Checked = false;
            this.radioButtonGlobal1.HighlightBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(247)))), ((int)(((byte)(132)))));
            this.radioButtonGlobal1.Location = new System.Drawing.Point(527, 32);
            this.radioButtonGlobal1.Margin = new System.Windows.Forms.Padding(5);
            this.radioButtonGlobal1.Name = "radioButtonGlobal1";
            this.radioButtonGlobal1.ParentBackColor = System.Drawing.SystemColors.Control;
            this.radioButtonGlobal1.Size = new System.Drawing.Size(78, 31);
            this.radioButtonGlobal1.TabIndex = 6;
            this.radioButtonGlobal1.CheckChanged += new RadioButtonGlobal.RadioButtonGlobal.delegateCheckChanged(this.radioButtonGlobal1_CheckChanged);
            this.radioButtonGlobal1.Load += new System.EventHandler(this.radioButtonGlobal1_Load);
            // 
            // btn_Link
            // 
            this.btn_Link.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Link.Image = global::HUDCMS.Properties.Resources.Link;
            this.btn_Link.Location = new System.Drawing.Point(527, 71);
            this.btn_Link.Name = "btn_Link";
            this.btn_Link.Size = new System.Drawing.Size(78, 32);
            this.btn_Link.TabIndex = 9;
            this.btn_Link.UseVisualStyleBackColor = true;
            this.btn_Link.Click += new System.EventHandler(this.btn_Link_Click);
            // 
            // pic_Control
            // 
            this.pic_Control.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pic_Control.Location = new System.Drawing.Point(4, 66);
            this.pic_Control.Margin = new System.Windows.Forms.Padding(4);
            this.pic_Control.Name = "pic_Control";
            this.pic_Control.Size = new System.Drawing.Size(195, 136);
            this.pic_Control.TabIndex = 4;
            this.pic_Control.TabStop = false;
            this.pic_Control.Click += new System.EventHandler(this.pic_Control_Click);
            // 
            // list_Link
            // 
            this.list_Link.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.list_Link.FormattingEnabled = true;
            this.list_Link.ItemHeight = 16;
            this.list_Link.Location = new System.Drawing.Point(206, 91);
            this.list_Link.Name = "list_Link";
            this.list_Link.Size = new System.Drawing.Size(313, 100);
            this.list_Link.TabIndex = 10;
            this.list_Link.Visible = false;
            // 
            // lbl_LinkedControls
            // 
            this.lbl_LinkedControls.AutoSize = true;
            this.lbl_LinkedControls.Location = new System.Drawing.Point(206, 71);
            this.lbl_LinkedControls.Name = "lbl_LinkedControls";
            this.lbl_LinkedControls.Size = new System.Drawing.Size(106, 17);
            this.lbl_LinkedControls.TabIndex = 11;
            this.lbl_LinkedControls.Text = "Linked Controls";
            // 
            // usrc_Control
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "usrc_Control";
            this.Size = new System.Drawing.Size(612, 208);
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
        private System.Windows.Forms.ListBox list_Link;
        private System.Windows.Forms.Label lbl_LinkedControls;
    }
}
