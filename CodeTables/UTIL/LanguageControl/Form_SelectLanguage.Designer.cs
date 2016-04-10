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
            this.lbl_SelectLanguage = new System.Windows.Forms.Label();
            this.cmb_Language = new System.Windows.Forms.ComboBox();
            this.pic_Program_Icon = new System.Windows.Forms.PictureBox();
            this.lbl_ProgramName = new System.Windows.Forms.Label();
            this.btn_OK = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Program_Icon)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_SelectLanguage
            // 
            this.lbl_SelectLanguage.AutoSize = true;
            this.lbl_SelectLanguage.Location = new System.Drawing.Point(12, 68);
            this.lbl_SelectLanguage.Name = "lbl_SelectLanguage";
            this.lbl_SelectLanguage.Size = new System.Drawing.Size(134, 20);
            this.lbl_SelectLanguage.TabIndex = 0;
            this.lbl_SelectLanguage.Text = "Select Language";
            // 
            // cmb_Language
            // 
            this.cmb_Language.FormattingEnabled = true;
            this.cmb_Language.Location = new System.Drawing.Point(16, 97);
            this.cmb_Language.Name = "cmb_Language";
            this.cmb_Language.Size = new System.Drawing.Size(370, 28);
            this.cmb_Language.TabIndex = 1;
            // 
            // pic_Program_Icon
            // 
            this.pic_Program_Icon.Location = new System.Drawing.Point(2, 3);
            this.pic_Program_Icon.Name = "pic_Program_Icon";
            this.pic_Program_Icon.Size = new System.Drawing.Size(58, 59);
            this.pic_Program_Icon.TabIndex = 2;
            this.pic_Program_Icon.TabStop = false;
            // 
            // lbl_ProgramName
            // 
            this.lbl_ProgramName.AutoSize = true;
            this.lbl_ProgramName.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_ProgramName.Location = new System.Drawing.Point(66, 9);
            this.lbl_ProgramName.Name = "lbl_ProgramName";
            this.lbl_ProgramName.Size = new System.Drawing.Size(230, 32);
            this.lbl_ProgramName.TabIndex = 3;
            this.lbl_ProgramName.Text = "Select Language";
            // 
            // btn_OK
            // 
            this.btn_OK.Location = new System.Drawing.Point(160, 132);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(84, 36);
            this.btn_OK.TabIndex = 4;
            this.btn_OK.Text = "OK";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // Form_SelectLanguage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(405, 176);
            this.ControlBox = false;
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.lbl_ProgramName);
            this.Controls.Add(this.pic_Program_Icon);
            this.Controls.Add(this.cmb_Language);
            this.Controls.Add(this.lbl_SelectLanguage);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form_SelectLanguage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.pic_Program_Icon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_SelectLanguage;
        private System.Windows.Forms.ComboBox cmb_Language;
        private System.Windows.Forms.PictureBox pic_Program_Icon;
        private System.Windows.Forms.Label lbl_ProgramName;
        private System.Windows.Forms.Button btn_OK;
    }
}