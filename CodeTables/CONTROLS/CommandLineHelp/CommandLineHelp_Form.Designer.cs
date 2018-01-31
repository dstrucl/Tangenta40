namespace CommandLineHelp
{
    partial class CommandLineHelp_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CommandLineHelp_Form));
            this.panel_Help = new System.Windows.Forms.Panel();
            this.lbl_RemoteURL = new System.Windows.Forms.Label();
            this.txt_RemoteHelpURL = new System.Windows.Forms.TextBox();
            this.usrc_NavigationButtons1 = new NavigationButtons.usrc_NavigationButtons();
            this.usrc_SelectLocalHelpFolder = new SelectFolder.usrc_SelectFolder();
            this.SuspendLayout();
            // 
            // panel_Help
            // 
            this.panel_Help.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_Help.AutoScroll = true;
            this.panel_Help.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel_Help.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel_Help.Location = new System.Drawing.Point(1, 98);
            this.panel_Help.Name = "panel_Help";
            this.panel_Help.Size = new System.Drawing.Size(617, 406);
            this.panel_Help.TabIndex = 2;
            // 
            // lbl_RemoteURL
            // 
            this.lbl_RemoteURL.Location = new System.Drawing.Point(12, 66);
            this.lbl_RemoteURL.Name = "lbl_RemoteURL";
            this.lbl_RemoteURL.Size = new System.Drawing.Size(138, 19);
            this.lbl_RemoteURL.TabIndex = 5;
            this.lbl_RemoteURL.Text = "Remote HELP URL";
            this.lbl_RemoteURL.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txt_RemoteHelpURL
            // 
            this.txt_RemoteHelpURL.Location = new System.Drawing.Point(156, 65);
            this.txt_RemoteHelpURL.Name = "txt_RemoteHelpURL";
            this.txt_RemoteHelpURL.Size = new System.Drawing.Size(456, 20);
            this.txt_RemoteHelpURL.TabIndex = 6;
            // 
            // usrc_NavigationButtons1
            // 
            this.usrc_NavigationButtons1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.usrc_NavigationButtons1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
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
            this.usrc_NavigationButtons1.Location = new System.Drawing.Point(0, -2);
            this.usrc_NavigationButtons1.Margin = new System.Windows.Forms.Padding(4);
            this.usrc_NavigationButtons1.Name = "usrc_NavigationButtons1";
            this.usrc_NavigationButtons1.Size = new System.Drawing.Size(617, 27);
            this.usrc_NavigationButtons1.TabIndex = 3;
            this.usrc_NavigationButtons1.Text_Cancel = "Exit";
            this.usrc_NavigationButtons1.Text_EXIT = "Exit";
            this.usrc_NavigationButtons1.Text_NEXT = "";
            this.usrc_NavigationButtons1.Text_OK = "";
            this.usrc_NavigationButtons1.Text_PREV = "";
            this.usrc_NavigationButtons1.Visible_EXIT = true;
            this.usrc_NavigationButtons1.Visible_NEXT = true;
            this.usrc_NavigationButtons1.Visible_PREV = true;
            this.usrc_NavigationButtons1.ButtonPressed += new NavigationButtons.usrc_NavigationButtons.delegate_button_pressed(this.usrc_NavigationButtons1_ButtonPressed);
            this.usrc_NavigationButtons1.HelpClicked += new HUDCMS.usrc_Help.delegate_HelpClicked(this.usrc_NavigationButtons1_HelpClicked);
            // 
            // usrc_SelectLocalHelpFolder
            // 
            this.usrc_SelectLocalHelpFolder.InitialDirectory = "C:\\";
            this.usrc_SelectLocalHelpFolder.LabelText = "Local HELP folder";
            this.usrc_SelectLocalHelpFolder.Location = new System.Drawing.Point(12, 34);
            this.usrc_SelectLocalHelpFolder.Name = "usrc_SelectLocalHelpFolder";
            this.usrc_SelectLocalHelpFolder.SelectedFolder = "";
            this.usrc_SelectLocalHelpFolder.Size = new System.Drawing.Size(600, 25);
            this.usrc_SelectLocalHelpFolder.TabIndex = 7;
            this.usrc_SelectLocalHelpFolder.Title = "Select Folder";
            // 
            // CommandLineHelp_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(617, 504);
            this.Controls.Add(this.usrc_SelectLocalHelpFolder);
            this.Controls.Add(this.txt_RemoteHelpURL);
            this.Controls.Add(this.lbl_RemoteURL);
            this.Controls.Add(this.usrc_NavigationButtons1);
            this.Controls.Add(this.panel_Help);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CommandLineHelp_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CommandLineHelp_Form";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CommandLineHelp_Form_FormClosing);
            this.Load += new System.EventHandler(this.CommandLineHelp_Form_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel_Help;
        private NavigationButtons.usrc_NavigationButtons usrc_NavigationButtons1;
        private System.Windows.Forms.Label lbl_RemoteURL;
        private System.Windows.Forms.TextBox txt_RemoteHelpURL;
        private SelectFolder.usrc_SelectFolder usrc_SelectLocalHelpFolder;
    }
}