namespace Tangenta
{
    partial class Form_DBSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_DBSettings));
            this.lbl_Administrator_Password = new System.Windows.Forms.Label();
            this.usrc_NavigationButtons1 = new NavigationButtons.usrc_NavigationButtons();
            this.usrc_Password1 = new Password.usrc_PasswordDefinition();
            this.chk_StockCheckAtStartup = new System.Windows.Forms.CheckBox();
            this.rdb_MultiUserOperation = new System.Windows.Forms.RadioButton();
            this.lbl_DataBaseVersion = new System.Windows.Forms.Label();
            this.grp_OperationMode = new System.Windows.Forms.GroupBox();
            this.chk_SingleUserLoginAsAdministrator = new System.Windows.Forms.CheckBox();
            this.rdb_SingleUser = new System.Windows.Forms.RadioButton();
            this.grp_OperationMode.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_Administrator_Password
            // 
            this.lbl_Administrator_Password.AutoSize = true;
            this.lbl_Administrator_Password.Location = new System.Drawing.Point(34, 88);
            this.lbl_Administrator_Password.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_Administrator_Password.Name = "lbl_Administrator_Password";
            this.lbl_Administrator_Password.Size = new System.Drawing.Size(156, 17);
            this.lbl_Administrator_Password.TabIndex = 1;
            this.lbl_Administrator_Password.Text = "Administrator Password";
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
            this.usrc_NavigationButtons1.Location = new System.Drawing.Point(4, 285);
            this.usrc_NavigationButtons1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.usrc_NavigationButtons1.Name = "usrc_NavigationButtons1";
            this.usrc_NavigationButtons1.Size = new System.Drawing.Size(481, 79);
            this.usrc_NavigationButtons1.TabIndex = 2;
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
            // usrc_Password1
            // 
            this.usrc_Password1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.usrc_Password1.Location = new System.Drawing.Point(31, 109);
            this.usrc_Password1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.usrc_Password1.MaxLength = 32;
            this.usrc_Password1.MinPasswordLength = 5;
            this.usrc_Password1.Name = "usrc_Password1";
            this.usrc_Password1.PasswordLocked = true;
            this.usrc_Password1.ReadOnly = false;
            this.usrc_Password1.Size = new System.Drawing.Size(326, 84);
            this.usrc_Password1.TabIndex = 0;
            // 
            // chk_StockCheckAtStartup
            // 
            this.chk_StockCheckAtStartup.AutoSize = true;
            this.chk_StockCheckAtStartup.Location = new System.Drawing.Point(13, 256);
            this.chk_StockCheckAtStartup.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chk_StockCheckAtStartup.Name = "chk_StockCheckAtStartup";
            this.chk_StockCheckAtStartup.Size = new System.Drawing.Size(175, 21);
            this.chk_StockCheckAtStartup.TabIndex = 3;
            this.chk_StockCheckAtStartup.Text = "Stock Check At Startup";
            this.chk_StockCheckAtStartup.UseVisualStyleBackColor = true;
            // 
            // rdb_MultiUserOperation
            // 
            this.rdb_MultiUserOperation.AutoSize = true;
            this.rdb_MultiUserOperation.Location = new System.Drawing.Point(8, 24);
            this.rdb_MultiUserOperation.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rdb_MultiUserOperation.Name = "rdb_MultiUserOperation";
            this.rdb_MultiUserOperation.Size = new System.Drawing.Size(90, 21);
            this.rdb_MultiUserOperation.TabIndex = 4;
            this.rdb_MultiUserOperation.Text = "Multi user";
            this.rdb_MultiUserOperation.UseVisualStyleBackColor = true;
            this.rdb_MultiUserOperation.CheckedChanged += new System.EventHandler(this.rdb_MultiUserOperation_CheckedChanged);
            // 
            // lbl_DataBaseVersion
            // 
            this.lbl_DataBaseVersion.AutoSize = true;
            this.lbl_DataBaseVersion.Location = new System.Drawing.Point(20, 6);
            this.lbl_DataBaseVersion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_DataBaseVersion.Name = "lbl_DataBaseVersion";
            this.lbl_DataBaseVersion.Size = new System.Drawing.Size(126, 17);
            this.lbl_DataBaseVersion.TabIndex = 5;
            this.lbl_DataBaseVersion.Text = "Data Base Version";
            // 
            // grp_OperationMode
            // 
            this.grp_OperationMode.Controls.Add(this.chk_SingleUserLoginAsAdministrator);
            this.grp_OperationMode.Controls.Add(this.rdb_SingleUser);
            this.grp_OperationMode.Controls.Add(this.rdb_MultiUserOperation);
            this.grp_OperationMode.Controls.Add(this.lbl_Administrator_Password);
            this.grp_OperationMode.Controls.Add(this.usrc_Password1);
            this.grp_OperationMode.Location = new System.Drawing.Point(13, 38);
            this.grp_OperationMode.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grp_OperationMode.Name = "grp_OperationMode";
            this.grp_OperationMode.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grp_OperationMode.Size = new System.Drawing.Size(469, 210);
            this.grp_OperationMode.TabIndex = 6;
            this.grp_OperationMode.TabStop = false;
            this.grp_OperationMode.Text = "Operation Mode";
            // 
            // chk_SingleUserLoginAsAdministrator
            // 
            this.chk_SingleUserLoginAsAdministrator.AutoSize = true;
            this.chk_SingleUserLoginAsAdministrator.Location = new System.Drawing.Point(242, 54);
            this.chk_SingleUserLoginAsAdministrator.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chk_SingleUserLoginAsAdministrator.Name = "chk_SingleUserLoginAsAdministrator";
            this.chk_SingleUserLoginAsAdministrator.Size = new System.Drawing.Size(171, 21);
            this.chk_SingleUserLoginAsAdministrator.TabIndex = 6;
            this.chk_SingleUserLoginAsAdministrator.Text = "Login as Administrator";
            this.chk_SingleUserLoginAsAdministrator.UseVisualStyleBackColor = true;
            // 
            // rdb_SingleUser
            // 
            this.rdb_SingleUser.AutoSize = true;
            this.rdb_SingleUser.Location = new System.Drawing.Point(9, 52);
            this.rdb_SingleUser.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rdb_SingleUser.Name = "rdb_SingleUser";
            this.rdb_SingleUser.Size = new System.Drawing.Size(100, 21);
            this.rdb_SingleUser.TabIndex = 5;
            this.rdb_SingleUser.Text = "Single user";
            this.rdb_SingleUser.UseVisualStyleBackColor = true;
            // 
            // Form_DBSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(491, 364);
            this.Controls.Add(this.grp_OperationMode);
            this.Controls.Add(this.lbl_DataBaseVersion);
            this.Controls.Add(this.chk_StockCheckAtStartup);
            this.Controls.Add(this.usrc_NavigationButtons1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form_DBSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.grp_OperationMode.ResumeLayout(false);
            this.grp_OperationMode.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Password.usrc_PasswordDefinition usrc_Password1;
        private System.Windows.Forms.Label lbl_Administrator_Password;
        private NavigationButtons.usrc_NavigationButtons usrc_NavigationButtons1;
        private System.Windows.Forms.CheckBox chk_StockCheckAtStartup;
        private System.Windows.Forms.RadioButton rdb_MultiUserOperation;
        private System.Windows.Forms.Label lbl_DataBaseVersion;
        private System.Windows.Forms.GroupBox grp_OperationMode;
        private System.Windows.Forms.CheckBox chk_SingleUserLoginAsAdministrator;
        private System.Windows.Forms.RadioButton rdb_SingleUser;
    }
}