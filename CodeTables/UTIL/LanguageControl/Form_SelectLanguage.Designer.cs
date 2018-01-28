namespace LanguageControl
{
    partial class Form_SelectLanguage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_SelectLanguage));
            this.lbl_SelectLanguage = new System.Windows.Forms.Label();
            this.cmb_Language = new System.Windows.Forms.ComboBox();
            this.lbl_ProgramName = new System.Windows.Forms.Label();
            this.pic_Program_Icon = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.usrc_NavigationButtons1 = new NavigationButtons.usrc_NavigationButtons();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Program_Icon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_SelectLanguage
            // 
            this.lbl_SelectLanguage.AutoSize = true;
            this.lbl_SelectLanguage.Location = new System.Drawing.Point(56, 76);
            this.lbl_SelectLanguage.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_SelectLanguage.Name = "lbl_SelectLanguage";
            this.lbl_SelectLanguage.Size = new System.Drawing.Size(115, 17);
            this.lbl_SelectLanguage.TabIndex = 0;
            this.lbl_SelectLanguage.Text = "Select Language";
            // 
            // cmb_Language
            // 
            this.cmb_Language.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmb_Language.FormattingEnabled = true;
            this.cmb_Language.Location = new System.Drawing.Point(41, 278);
            this.cmb_Language.Margin = new System.Windows.Forms.Padding(2);
            this.cmb_Language.Name = "cmb_Language";
            this.cmb_Language.Size = new System.Drawing.Size(218, 25);
            this.cmb_Language.TabIndex = 1;
            this.cmb_Language.SelectedIndexChanged += new System.EventHandler(this.cmb_Language_SelectedIndexChanged);
            // 
            // lbl_ProgramName
            // 
            this.lbl_ProgramName.AutoSize = true;
            this.lbl_ProgramName.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_ProgramName.Location = new System.Drawing.Point(55, 47);
            this.lbl_ProgramName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_ProgramName.Name = "lbl_ProgramName";
            this.lbl_ProgramName.Size = new System.Drawing.Size(175, 26);
            this.lbl_ProgramName.TabIndex = 3;
            this.lbl_ProgramName.Text = "Select Language";
            // 
            // pic_Program_Icon
            // 
            this.pic_Program_Icon.Location = new System.Drawing.Point(4, 42);
            this.pic_Program_Icon.Margin = new System.Windows.Forms.Padding(2);
            this.pic_Program_Icon.Name = "pic_Program_Icon";
            this.pic_Program_Icon.Size = new System.Drawing.Size(46, 47);
            this.pic_Program_Icon.TabIndex = 2;
            this.pic_Program_Icon.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::LanguageControl.Properties.Resources.LanguageStandardIcon;
            this.pictureBox1.Location = new System.Drawing.Point(2, 97);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(297, 177);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // usrc_NavigationButtons1
            // 
            this.usrc_NavigationButtons1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.usrc_NavigationButtons1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.usrc_NavigationButtons1.BackColor = System.Drawing.SystemColors.Control;
            this.usrc_NavigationButtons1.btn1_ToolTip_Text = "";
            this.usrc_NavigationButtons1.btn2_ToolTip_Text = "";
            this.usrc_NavigationButtons1.btn3_ToolTip_Text = "";
            this.usrc_NavigationButtons1.Button_NEXT_Enabled = true;
            this.usrc_NavigationButtons1.Buttons = NavigationButtons.Navigation.eButtons.OkCancel;
            this.usrc_NavigationButtons1.ExitQuestion = "Exit Program?";
            this.usrc_NavigationButtons1.Image_Cancel = null;
            this.usrc_NavigationButtons1.Image_EXIT = null;
            this.usrc_NavigationButtons1.Image_NEXT = ((System.Drawing.Image)(resources.GetObject("usrc_NavigationButtons1.Image_NEXT")));
            this.usrc_NavigationButtons1.Image_OK = ((System.Drawing.Image)(resources.GetObject("usrc_NavigationButtons1.Image_OK")));
            this.usrc_NavigationButtons1.Image_PREV = ((System.Drawing.Image)(resources.GetObject("usrc_NavigationButtons1.Image_PREV")));
            this.usrc_NavigationButtons1.Location = new System.Drawing.Point(2, 9);
            this.usrc_NavigationButtons1.Margin = new System.Windows.Forms.Padding(4);
            this.usrc_NavigationButtons1.Name = "usrc_NavigationButtons1";
            this.usrc_NavigationButtons1.Size = new System.Drawing.Size(297, 31);
            this.usrc_NavigationButtons1.TabIndex = 7;
            this.usrc_NavigationButtons1.Text_Cancel = "Exit";
            this.usrc_NavigationButtons1.Text_EXIT = "Exit";
            this.usrc_NavigationButtons1.Text_NEXT = "";
            this.usrc_NavigationButtons1.Text_OK = "";
            this.usrc_NavigationButtons1.Text_PREV = "";
            this.usrc_NavigationButtons1.Visible_EXIT = true;
            this.usrc_NavigationButtons1.Visible_NEXT = true;
            this.usrc_NavigationButtons1.Visible_PREV = true;
            this.usrc_NavigationButtons1.ButtonPressed += new NavigationButtons.usrc_NavigationButtons.delegate_button_pressed(this.usrc_NavigationButtons1_ButtonPressed);
            // 
            // Form_SelectLanguage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(300, 314);
            this.ControlBox = false;
            this.Controls.Add(this.usrc_NavigationButtons1);
            this.Controls.Add(this.lbl_ProgramName);
            this.Controls.Add(this.pic_Program_Icon);
            this.Controls.Add(this.cmb_Language);
            this.Controls.Add(this.lbl_SelectLanguage);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form_SelectLanguage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.pic_Program_Icon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_SelectLanguage;
        private System.Windows.Forms.ComboBox cmb_Language;
        private System.Windows.Forms.PictureBox pic_Program_Icon;
        private System.Windows.Forms.Label lbl_ProgramName;
        private System.Windows.Forms.PictureBox pictureBox1;
        private NavigationButtons.usrc_NavigationButtons usrc_NavigationButtons1;
    }
}