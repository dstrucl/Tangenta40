namespace SQLTableControl
{
    partial class TableDockingForm
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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.tsmi_Data_Editor = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_View_Manager = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_SaveWindowConfiguration = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_Edit_XML_configuration = new System.Windows.Forms.ToolStripMenuItem();
            this._docker = new Crom.Controls.Docking.DockContainer();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_Data_Editor,
            this.tsmi_View_Manager,
            this.tsmi_SaveWindowConfiguration,
            this.tsmi_Edit_XML_configuration});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip.Size = new System.Drawing.Size(856, 24);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip1";
            // 
            // tsmi_Data_Editor
            // 
            this.tsmi_Data_Editor.Name = "tsmi_Data_Editor";
            this.tsmi_Data_Editor.Size = new System.Drawing.Size(77, 20);
            this.tsmi_Data_Editor.Text = "Data Editor";
            this.tsmi_Data_Editor.Click += new System.EventHandler(this.tsmi_Data_Editor_Click);
            // 
            // tsmi_View_Manager
            // 
            this.tsmi_View_Manager.Name = "tsmi_View_Manager";
            this.tsmi_View_Manager.Size = new System.Drawing.Size(94, 20);
            this.tsmi_View_Manager.Text = "View Manager";
            this.tsmi_View_Manager.Click += new System.EventHandler(this.tsmi_View_Manager_Click);
            // 
            // tsmi_SaveWindowConfiguration
            // 
            this.tsmi_SaveWindowConfiguration.Name = "tsmi_SaveWindowConfiguration";
            this.tsmi_SaveWindowConfiguration.Size = new System.Drawing.Size(167, 20);
            this.tsmi_SaveWindowConfiguration.Text = "Save Window Configuration";
            this.tsmi_SaveWindowConfiguration.Click += new System.EventHandler(this.tsmi_SaveWindowConfiguration_Click);
            // 
            // tsmi_Edit_XML_configuration
            // 
            this.tsmi_Edit_XML_configuration.Name = "tsmi_Edit_XML_configuration";
            this.tsmi_Edit_XML_configuration.Size = new System.Drawing.Size(141, 20);
            this.tsmi_Edit_XML_configuration.Text = "Edit XML configuration";
            this.tsmi_Edit_XML_configuration.Visible = false;
            this.tsmi_Edit_XML_configuration.Click += new System.EventHandler(this.tsmi_Edit_XML_configuration_Click);
            // 
            // _docker
            // 
            this._docker.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._docker.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(118)))), ((int)(((byte)(118)))));
            this._docker.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this._docker.CanMoveByMouseFilledForms = true;
            this._docker.Location = new System.Drawing.Point(0, 24);
            this._docker.Margin = new System.Windows.Forms.Padding(2);
            this._docker.Name = "_docker";
            this._docker.Size = new System.Drawing.Size(857, 420);
            this._docker.TabIndex = 0;
            this._docker.TitleBarGradientColor1 = System.Drawing.SystemColors.Control;
            this._docker.TitleBarGradientColor2 = System.Drawing.Color.White;
            this._docker.TitleBarGradientSelectedColor1 = System.Drawing.Color.DarkGray;
            this._docker.TitleBarGradientSelectedColor2 = System.Drawing.Color.White;
            this._docker.TitleBarTextColor = System.Drawing.Color.Black;
            this._docker.FormClosed += new System.EventHandler<Crom.Controls.Docking.FormEventArgs>(this._docker_FormClosed);
            // 
            // TableDockingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(856, 443);
            this.Controls.Add(this._docker);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "TableDockingForm";
            this.Text = "TableDockingForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.TableDockingForm_FormClosed);
            this.Load += new System.EventHandler(this.TableDockingForm_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Crom.Controls.Docking.DockContainer _docker;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Data_Editor;
        private System.Windows.Forms.ToolStripMenuItem tsmi_View_Manager;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Edit_XML_configuration;
        private System.Windows.Forms.ToolStripMenuItem tsmi_SaveWindowConfiguration;
    }
}