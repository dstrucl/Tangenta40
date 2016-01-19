namespace Tangenta
{
    partial class usrc_Main
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
            this.btn_Exit = new System.Windows.Forms.Button();
            this.m_usrc_Help = new usrc_Help.usrc_Help();
            this.usrc_FVI_SLO1 = new FiscalVerificationOfInvoices_SLO.usrc_FVI_SLO();
            this.m_usrc_DBSettings = new Tangenta.usrc_DBSettings();
            this.m_usrc_InvoiceMan = new Tangenta.usrc_InvoiceMan();
            this.usrc_Printer1 = new Tangenta.usrc_Printer();
            this.SuspendLayout();
            // 
            // btn_Exit
            // 
            this.btn_Exit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Exit.Image = global::Tangenta.Properties.Resources.Exit;
            this.btn_Exit.Location = new System.Drawing.Point(852, 1);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(63, 31);
            this.btn_Exit.TabIndex = 3;
            this.btn_Exit.UseVisualStyleBackColor = true;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // m_usrc_Help
            // 
            this.m_usrc_Help.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_usrc_Help.Location = new System.Drawing.Point(808, 1);
            this.m_usrc_Help.Name = "m_usrc_Help";
            this.m_usrc_Help.Size = new System.Drawing.Size(40, 31);
            this.m_usrc_Help.TabIndex = 5;
            // 
            // usrc_FVI_SLO1
            // 
            this.usrc_FVI_SLO1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.usrc_FVI_SLO1.Location = new System.Drawing.Point(590, 1);
            this.usrc_FVI_SLO1.MessageBox_Length = 100;
            this.usrc_FVI_SLO1.Name = "usrc_FVI_SLO1";
            this.usrc_FVI_SLO1.Size = new System.Drawing.Size(40, 31);
            this.usrc_FVI_SLO1.TabIndex = 6;
            // 
            // m_usrc_DBSettings
            // 
            this.m_usrc_DBSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_usrc_DBSettings.Location = new System.Drawing.Point(647, 1);
            this.m_usrc_DBSettings.Name = "m_usrc_DBSettings";
            this.m_usrc_DBSettings.Size = new System.Drawing.Size(110, 31);
            this.m_usrc_DBSettings.TabIndex = 4;
            this.m_usrc_DBSettings.Backup += new Tangenta.usrc_DBSettings.delegate_Backup(this.m_usrc_DBSettings_Backup);
            this.m_usrc_DBSettings.Settings_Click += new Tangenta.usrc_DBSettings.delegate_Settings_Click(this.m_usrc_DBSettings_Settings_Click);
            // 
            // m_usrc_InvoiceMan
            // 
            this.m_usrc_InvoiceMan.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_usrc_InvoiceMan.Location = new System.Drawing.Point(-20, 0);
            this.m_usrc_InvoiceMan.Name = "m_usrc_InvoiceMan";
            this.m_usrc_InvoiceMan.Size = new System.Drawing.Size(938, 605);
            this.m_usrc_InvoiceMan.TabIndex = 2;
            // 
            // usrc_Printer1
            // 
            this.usrc_Printer1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.usrc_Printer1.Location = new System.Drawing.Point(764, 1);
            this.usrc_Printer1.Name = "usrc_Printer1";
            this.usrc_Printer1.PaperName = null;
            this.usrc_Printer1.Size = new System.Drawing.Size(40, 31);
            this.usrc_Printer1.TabIndex = 7;
            this.usrc_Printer1.Load += new System.EventHandler(this.usrc_Printer1_Load);
            // 
            // usrc_Main
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.usrc_Printer1);
            this.Controls.Add(this.usrc_FVI_SLO1);
            this.Controls.Add(this.m_usrc_Help);
            this.Controls.Add(this.m_usrc_DBSettings);
            this.Controls.Add(this.btn_Exit);
            this.Controls.Add(this.m_usrc_InvoiceMan);
            this.Name = "usrc_Main";
            this.Size = new System.Drawing.Size(918, 605);
            this.ResumeLayout(false);

        }

        #endregion

        internal usrc_InvoiceMan m_usrc_InvoiceMan;
        private System.Windows.Forms.Button btn_Exit;
        private usrc_DBSettings m_usrc_DBSettings;
        private usrc_Help.usrc_Help m_usrc_Help;
        public FiscalVerificationOfInvoices_SLO.usrc_FVI_SLO usrc_FVI_SLO1;
        private usrc_Printer usrc_Printer1;
    }
}
