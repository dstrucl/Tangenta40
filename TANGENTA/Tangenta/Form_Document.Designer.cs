namespace Tangenta
{
    partial class Form_Document
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_NewDocument));
            this.m_usrc_Main = new Tangenta.usrc_DocumentMan();
            this.SuspendLayout();
            // 
            // m_usrc_Main
            // 
            this.m_usrc_Main.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_usrc_Main.AutoScroll = true;
            this.m_usrc_Main.Location = new System.Drawing.Point(0, 0);
            this.m_usrc_Main.Name = "m_usrc_Main";
            this.m_usrc_Main.Size = new System.Drawing.Size(1000, 643);
            this.m_usrc_Main.TabIndex = 0;
            this.m_usrc_Main.Exit_Click += new Tangenta.usrc_DocumentMan.delegate_Exit_Click(this.m_usrc_Main_Exit_Click);
            // 
            // Form_Document
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1000, 644);
            this.Controls.Add(this.m_usrc_Main);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "Form_Document";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Form_Load);
            this.Shown += new System.EventHandler(this.Form_Document_Shown);
            this.ResumeLayout(false);

        }

        #endregion

        internal usrc_DocumentMan m_usrc_Main;
    }
}

