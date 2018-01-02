namespace Tangenta
{
    partial class Form_ProgramSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_ProgramSettings));
            this.chk_AllowToEditText = new System.Windows.Forms.CheckBox();
            this.cmb_Language = new System.Windows.Forms.ComboBox();
            this.lbl_Language = new System.Windows.Forms.Label();
            this.chk_FullScreen = new System.Windows.Forms.CheckBox();
            this.btn_LogFile = new System.Windows.Forms.Button();
            this.lbL_ElectronicDevice_ID = new System.Windows.Forms.Label();
            this.txt_ElectronicDevice_ID = new System.Windows.Forms.TextBox();
            this.usrc_NavigationButtons1 = new NavigationButtons.usrc_NavigationButtons();
            this.usrc_ShopsInuse1 = new Tangenta.usrc_ShopsInuse();
            this.btn_DBSettings = new System.Windows.Forms.Button();
            this.lbl_AppData = new System.Windows.Forms.Label();
            this.txt_ApplicationDataFolder = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // chk_AllowToEditText
            // 
            this.chk_AllowToEditText.AutoSize = true;
            this.chk_AllowToEditText.Location = new System.Drawing.Point(126, 51);
            this.chk_AllowToEditText.Name = "chk_AllowToEditText";
            this.chk_AllowToEditText.Size = new System.Drawing.Size(155, 17);
            this.chk_AllowToEditText.TabIndex = 10;
            this.chk_AllowToEditText.Text = "Allow to edit language texts";
            this.chk_AllowToEditText.UseVisualStyleBackColor = true;
            // 
            // cmb_Language
            // 
            this.cmb_Language.FormattingEnabled = true;
            this.cmb_Language.Location = new System.Drawing.Point(345, 7);
            this.cmb_Language.Name = "cmb_Language";
            this.cmb_Language.Size = new System.Drawing.Size(221, 21);
            this.cmb_Language.TabIndex = 11;
            // 
            // lbl_Language
            // 
            this.lbl_Language.Location = new System.Drawing.Point(253, 9);
            this.lbl_Language.Name = "lbl_Language";
            this.lbl_Language.Size = new System.Drawing.Size(82, 20);
            this.lbl_Language.TabIndex = 12;
            this.lbl_Language.Text = "Language:";
            this.lbl_Language.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // chk_FullScreen
            // 
            this.chk_FullScreen.AutoSize = true;
            this.chk_FullScreen.Location = new System.Drawing.Point(12, 51);
            this.chk_FullScreen.Name = "chk_FullScreen";
            this.chk_FullScreen.Size = new System.Drawing.Size(77, 17);
            this.chk_FullScreen.TabIndex = 14;
            this.chk_FullScreen.Text = "Full screen";
            this.chk_FullScreen.UseVisualStyleBackColor = true;
            // 
            // btn_LogFile
            // 
            this.btn_LogFile.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_LogFile.Location = new System.Drawing.Point(437, 41);
            this.btn_LogFile.Name = "btn_LogFile";
            this.btn_LogFile.Size = new System.Drawing.Size(129, 43);
            this.btn_LogFile.TabIndex = 16;
            this.btn_LogFile.Text = "LOG DATOTEKA";
            this.btn_LogFile.UseVisualStyleBackColor = false;
            this.btn_LogFile.Click += new System.EventHandler(this.btn_LogFile_Click);
            // 
            // lbL_ElectronicDevice_ID
            // 
            this.lbL_ElectronicDevice_ID.Location = new System.Drawing.Point(0, 10);
            this.lbL_ElectronicDevice_ID.Name = "lbL_ElectronicDevice_ID";
            this.lbL_ElectronicDevice_ID.Size = new System.Drawing.Size(138, 20);
            this.lbL_ElectronicDevice_ID.TabIndex = 36;
            this.lbL_ElectronicDevice_ID.Text = "lbL_ElectronicDevice_ID";
            this.lbL_ElectronicDevice_ID.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txt_ElectronicDevice_ID
            // 
            this.txt_ElectronicDevice_ID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_ElectronicDevice_ID.Location = new System.Drawing.Point(139, 7);
            this.txt_ElectronicDevice_ID.Name = "txt_ElectronicDevice_ID";
            this.txt_ElectronicDevice_ID.Size = new System.Drawing.Size(111, 22);
            this.txt_ElectronicDevice_ID.TabIndex = 37;
            this.txt_ElectronicDevice_ID.WordWrap = false;
            // 
            // usrc_NavigationButtons1
            // 
            this.usrc_NavigationButtons1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.usrc_NavigationButtons1.Location = new System.Drawing.Point(10, 273);
            this.usrc_NavigationButtons1.Name = "usrc_NavigationButtons1";
            this.usrc_NavigationButtons1.Size = new System.Drawing.Size(563, 62);
            this.usrc_NavigationButtons1.TabIndex = 39;
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
            // usrc_ShopsInuse1
            // 
            this.usrc_ShopsInuse1.Location = new System.Drawing.Point(3, 90);
            this.usrc_ShopsInuse1.Name = "usrc_ShopsInuse1";
            this.usrc_ShopsInuse1.Size = new System.Drawing.Size(570, 125);
            this.usrc_ShopsInuse1.TabIndex = 38;
            // 
            // btn_DBSettings
            // 
            this.btn_DBSettings.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_DBSettings.Image = global::Tangenta.Properties.Resources.DBSettings;
            this.btn_DBSettings.Location = new System.Drawing.Point(380, 41);
            this.btn_DBSettings.Name = "btn_DBSettings";
            this.btn_DBSettings.Size = new System.Drawing.Size(51, 43);
            this.btn_DBSettings.TabIndex = 40;
            this.btn_DBSettings.UseVisualStyleBackColor = false;
            this.btn_DBSettings.Click += new System.EventHandler(this.btn_DBSettings_Click);
            // 
            // lbl_AppData
            // 
            this.lbl_AppData.AutoSize = true;
            this.lbl_AppData.Location = new System.Drawing.Point(5, 220);
            this.lbl_AppData.Name = "lbl_AppData";
            this.lbl_AppData.Size = new System.Drawing.Size(88, 13);
            this.lbl_AppData.TabIndex = 42;
            this.lbl_AppData.Text = "\"AppData folder\"";
            // 
            // txt_ApplicationDataFolder
            // 
            this.txt_ApplicationDataFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_ApplicationDataFolder.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txt_ApplicationDataFolder.Location = new System.Drawing.Point(3, 236);
            this.txt_ApplicationDataFolder.Name = "txt_ApplicationDataFolder";
            this.txt_ApplicationDataFolder.ReadOnly = true;
            this.txt_ApplicationDataFolder.Size = new System.Drawing.Size(570, 20);
            this.txt_ApplicationDataFolder.TabIndex = 41;
            // 
            // Form_ProgramSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(576, 338);
            this.Controls.Add(this.lbl_AppData);
            this.Controls.Add(this.txt_ApplicationDataFolder);
            this.Controls.Add(this.btn_DBSettings);
            this.Controls.Add(this.usrc_NavigationButtons1);
            this.Controls.Add(this.usrc_ShopsInuse1);
            this.Controls.Add(this.txt_ElectronicDevice_ID);
            this.Controls.Add(this.lbL_ElectronicDevice_ID);
            this.Controls.Add(this.btn_LogFile);
            this.Controls.Add(this.chk_FullScreen);
            this.Controls.Add(this.lbl_Language);
            this.Controls.Add(this.cmb_Language);
            this.Controls.Add(this.chk_AllowToEditText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_ProgramSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit_Form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox chk_AllowToEditText;
        private System.Windows.Forms.ComboBox cmb_Language;
        private System.Windows.Forms.Label lbl_Language;
        private System.Windows.Forms.CheckBox chk_FullScreen;
        private System.Windows.Forms.Button btn_LogFile;
        private System.Windows.Forms.Label lbL_ElectronicDevice_ID;
        private System.Windows.Forms.TextBox txt_ElectronicDevice_ID;
        private usrc_ShopsInuse usrc_ShopsInuse1;
        private NavigationButtons.usrc_NavigationButtons usrc_NavigationButtons1;
        private System.Windows.Forms.Button btn_DBSettings;
        private System.Windows.Forms.Label lbl_AppData;
        private System.Windows.Forms.TextBox txt_ApplicationDataFolder;
    }
}