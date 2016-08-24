namespace Startup
{
    partial class usrc_Startup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(usrc_Startup));
            this.lbl_StartUp = new System.Windows.Forms.Label();
            this.usrc_web_Help1 = new usrc_Help.usrc_web_Help();
            this.usrc_NavigationButtons1 = new NavigationButtons.usrc_NavigationButtons();
            this.timer_Startup = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // lbl_StartUp
            // 
            this.lbl_StartUp.AutoSize = true;
            this.lbl_StartUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_StartUp.Location = new System.Drawing.Point(18, 12);
            this.lbl_StartUp.Name = "lbl_StartUp";
            this.lbl_StartUp.Size = new System.Drawing.Size(70, 26);
            this.lbl_StartUp.TabIndex = 0;
            this.lbl_StartUp.Text = "label1";
            // 
            // usrc_web_Help1
            // 
            this.usrc_web_Help1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.usrc_web_Help1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.usrc_web_Help1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.usrc_web_Help1.LocalUrl = "Local URL:";
            this.usrc_web_Help1.Location = new System.Drawing.Point(359, 3);
            this.usrc_web_Help1.Name = "usrc_web_Help1";
            this.usrc_web_Help1.RemoteUrl = "Remote URL:";
            this.usrc_web_Help1.Size = new System.Drawing.Size(507, 565);
            this.usrc_web_Help1.TabIndex = 1;
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
            this.usrc_NavigationButtons1.Location = new System.Drawing.Point(3, 570);
            this.usrc_NavigationButtons1.Name = "usrc_NavigationButtons1";
            this.usrc_NavigationButtons1.Size = new System.Drawing.Size(859, 64);
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
            // timer_Startup
            // 
            this.timer_Startup.Tick += new System.EventHandler(this.timer_Startup_Tick);
            // 
            // usrc_Startup
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.usrc_NavigationButtons1);
            this.Controls.Add(this.usrc_web_Help1);
            this.Controls.Add(this.lbl_StartUp);
            this.Name = "usrc_Startup";
            this.Size = new System.Drawing.Size(869, 635);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_StartUp;
        public usrc_Help.usrc_web_Help usrc_web_Help1;
        private NavigationButtons.usrc_NavigationButtons usrc_NavigationButtons1;
        public System.Windows.Forms.Timer timer_Startup;
    }
}
