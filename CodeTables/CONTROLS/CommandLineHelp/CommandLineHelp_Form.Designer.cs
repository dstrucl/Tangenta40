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
            this.usrc_NavigationButtons1 = new NavigationButtons.usrc_NavigationButtons();
            this.grp_CommandLineParameters = new System.Windows.Forms.GroupBox();
            this.usrc_HelpSettings1 = new HUDCMS.usrc_HelpSettings();
            this.grp_CommandLineParameters.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_Help
            // 
            this.panel_Help.AutoScroll = true;
            this.panel_Help.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel_Help.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel_Help.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Help.Location = new System.Drawing.Point(3, 18);
            this.panel_Help.Name = "panel_Help";
            this.panel_Help.Size = new System.Drawing.Size(692, 427);
            this.panel_Help.TabIndex = 2;
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
            this.usrc_NavigationButtons1.Location = new System.Drawing.Point(0, 0);
            this.usrc_NavigationButtons1.Margin = new System.Windows.Forms.Padding(4);
            this.usrc_NavigationButtons1.Name = "usrc_NavigationButtons1";
            this.usrc_NavigationButtons1.Size = new System.Drawing.Size(698, 27);
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
            // grp_CommandLineParameters
            // 
            this.grp_CommandLineParameters.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grp_CommandLineParameters.Controls.Add(this.panel_Help);
            this.grp_CommandLineParameters.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.grp_CommandLineParameters.Location = new System.Drawing.Point(0, 120);
            this.grp_CommandLineParameters.Name = "grp_CommandLineParameters";
            this.grp_CommandLineParameters.Size = new System.Drawing.Size(698, 448);
            this.grp_CommandLineParameters.TabIndex = 4;
            this.grp_CommandLineParameters.TabStop = false;
            this.grp_CommandLineParameters.Text = "Command Line Parameters";
            // 
            // usrc_HelpSettings1
            // 
            this.usrc_HelpSettings1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.usrc_HelpSettings1.Location = new System.Drawing.Point(3, 28);
            this.usrc_HelpSettings1.Name = "usrc_HelpSettings1";
            this.usrc_HelpSettings1.Size = new System.Drawing.Size(691, 90);
            this.usrc_HelpSettings1.TabIndex = 5;
            // 
            // CommandLineHelp_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(698, 568);
            this.Controls.Add(this.usrc_HelpSettings1);
            this.Controls.Add(this.grp_CommandLineParameters);
            this.Controls.Add(this.usrc_NavigationButtons1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CommandLineHelp_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CommandLineHelp_Form";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CommandLineHelp_Form_FormClosing);
            this.Load += new System.EventHandler(this.CommandLineHelp_Form_Load);
            this.grp_CommandLineParameters.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel_Help;
        private NavigationButtons.usrc_NavigationButtons usrc_NavigationButtons1;
        private System.Windows.Forms.GroupBox grp_CommandLineParameters;
        private HUDCMS.usrc_HelpSettings usrc_HelpSettings1;
    }
}