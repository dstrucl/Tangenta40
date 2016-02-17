namespace Tangenta
{
    partial class Form_Settings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Settings));
            this.chk_AllowToEditText = new System.Windows.Forms.CheckBox();
            this.cmb_Language = new System.Windows.Forms.ComboBox();
            this.lbl_Language = new System.Windows.Forms.Label();
            this.btn_Exit = new System.Windows.Forms.Button();
            this.chk_FullScreen = new System.Windows.Forms.CheckBox();
            this.btn_Shops_in_use = new System.Windows.Forms.Button();
            this.btn_LogFile = new System.Windows.Forms.Button();
            this.btn_CodeTables = new System.Windows.Forms.Button();
            this.lbL_ElectronicDevice_ID = new System.Windows.Forms.Label();
            this.txt_ElectronicDevice_ID = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // chk_AllowToEditText
            // 
            this.chk_AllowToEditText.AutoSize = true;
            this.chk_AllowToEditText.Location = new System.Drawing.Point(545, 8);
            this.chk_AllowToEditText.Name = "chk_AllowToEditText";
            this.chk_AllowToEditText.Size = new System.Drawing.Size(155, 17);
            this.chk_AllowToEditText.TabIndex = 10;
            this.chk_AllowToEditText.Text = "Allow to edit language texts";
            this.chk_AllowToEditText.UseVisualStyleBackColor = true;
            // 
            // cmb_Language
            // 
            this.cmb_Language.FormattingEnabled = true;
            this.cmb_Language.Location = new System.Drawing.Point(318, 7);
            this.cmb_Language.Name = "cmb_Language";
            this.cmb_Language.Size = new System.Drawing.Size(221, 21);
            this.cmb_Language.TabIndex = 11;
            // 
            // lbl_Language
            // 
            this.lbl_Language.Location = new System.Drawing.Point(226, 9);
            this.lbl_Language.Name = "lbl_Language";
            this.lbl_Language.Size = new System.Drawing.Size(82, 20);
            this.lbl_Language.TabIndex = 12;
            this.lbl_Language.Text = "Language:";
            this.lbl_Language.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btn_Exit
            // 
            this.btn_Exit.Image = global::Tangenta.Properties.Resources.Exit;
            this.btn_Exit.Location = new System.Drawing.Point(730, 2);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(61, 29);
            this.btn_Exit.TabIndex = 13;
            this.btn_Exit.UseVisualStyleBackColor = true;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // chk_FullScreen
            // 
            this.chk_FullScreen.AutoSize = true;
            this.chk_FullScreen.Location = new System.Drawing.Point(129, 10);
            this.chk_FullScreen.Name = "chk_FullScreen";
            this.chk_FullScreen.Size = new System.Drawing.Size(77, 17);
            this.chk_FullScreen.TabIndex = 14;
            this.chk_FullScreen.Text = "Full screen";
            this.chk_FullScreen.UseVisualStyleBackColor = true;
            // 
            // btn_Shops_in_use
            // 
            this.btn_Shops_in_use.Location = new System.Drawing.Point(305, 35);
            this.btn_Shops_in_use.Name = "btn_Shops_in_use";
            this.btn_Shops_in_use.Size = new System.Drawing.Size(234, 31);
            this.btn_Shops_in_use.TabIndex = 15;
            this.btn_Shops_in_use.Text = "btn_Shops_in_use";
            this.btn_Shops_in_use.UseVisualStyleBackColor = true;
            this.btn_Shops_in_use.Click += new System.EventHandler(this.btn_Shops_in_use_Click);
            // 
            // btn_LogFile
            // 
            this.btn_LogFile.Location = new System.Drawing.Point(12, 72);
            this.btn_LogFile.Name = "btn_LogFile";
            this.btn_LogFile.Size = new System.Drawing.Size(293, 31);
            this.btn_LogFile.TabIndex = 16;
            this.btn_LogFile.Text = "LOG DATOTEKA";
            this.btn_LogFile.UseVisualStyleBackColor = true;
            this.btn_LogFile.Click += new System.EventHandler(this.btn_LogFile_Click);
            // 
            // btn_CodeTables
            // 
            this.btn_CodeTables.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_CodeTables.AutoEllipsis = true;
            this.btn_CodeTables.Image = ((System.Drawing.Image)(resources.GetObject("btn_CodeTables.Image")));
            this.btn_CodeTables.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_CodeTables.Location = new System.Drawing.Point(4, 2);
            this.btn_CodeTables.Name = "btn_CodeTables";
            this.btn_CodeTables.Size = new System.Drawing.Size(105, 32);
            this.btn_CodeTables.TabIndex = 35;
            this.btn_CodeTables.Text = "Code tables";
            this.btn_CodeTables.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_CodeTables.UseVisualStyleBackColor = true;
            this.btn_CodeTables.Click += new System.EventHandler(this.btn_CodeTables_Click);
            // 
            // lbL_ElectronicDevice_ID
            // 
            this.lbL_ElectronicDevice_ID.Location = new System.Drawing.Point(10, 44);
            this.lbL_ElectronicDevice_ID.Name = "lbL_ElectronicDevice_ID";
            this.lbL_ElectronicDevice_ID.Size = new System.Drawing.Size(135, 20);
            this.lbL_ElectronicDevice_ID.TabIndex = 36;
            this.lbL_ElectronicDevice_ID.Text = "lbL_ElectronicDevice_ID";
            this.lbL_ElectronicDevice_ID.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txt_ElectronicDevice_ID
            // 
            this.txt_ElectronicDevice_ID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_ElectronicDevice_ID.Location = new System.Drawing.Point(149, 41);
            this.txt_ElectronicDevice_ID.Name = "txt_ElectronicDevice_ID";
            this.txt_ElectronicDevice_ID.Size = new System.Drawing.Size(108, 22);
            this.txt_ElectronicDevice_ID.TabIndex = 37;
            this.txt_ElectronicDevice_ID.WordWrap = false;
            // 
            // Form_Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(793, 130);
            this.Controls.Add(this.txt_ElectronicDevice_ID);
            this.Controls.Add(this.lbL_ElectronicDevice_ID);
            this.Controls.Add(this.btn_CodeTables);
            this.Controls.Add(this.btn_LogFile);
            this.Controls.Add(this.btn_Shops_in_use);
            this.Controls.Add(this.chk_FullScreen);
            this.Controls.Add(this.btn_Exit);
            this.Controls.Add(this.lbl_Language);
            this.Controls.Add(this.cmb_Language);
            this.Controls.Add(this.chk_AllowToEditText);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_Settings";
            this.Text = "Edit_Form";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Settings_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox chk_AllowToEditText;
        private System.Windows.Forms.ComboBox cmb_Language;
        private System.Windows.Forms.Label lbl_Language;
        private System.Windows.Forms.Button btn_Exit;
        private System.Windows.Forms.CheckBox chk_FullScreen;
        private System.Windows.Forms.Button btn_Shops_in_use;
        private System.Windows.Forms.Button btn_LogFile;
        private System.Windows.Forms.Button btn_CodeTables;
        private System.Windows.Forms.Label lbL_ElectronicDevice_ID;
        private System.Windows.Forms.TextBox txt_ElectronicDevice_ID;
    }
}