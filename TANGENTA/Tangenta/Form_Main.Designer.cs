namespace Tangenta
{
    partial class Form_Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Main));
            this.m_usrc_Main = new Tangenta.usrc_Main();
            this.SuspendLayout();
            // 
            // m_usrc_Main
            // 
            this.m_usrc_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_usrc_Main.Location = new System.Drawing.Point(0, 0);
            this.m_usrc_Main.Name = "m_usrc_Main";
            this.m_usrc_Main.Size = new System.Drawing.Size(896, 616);
            this.m_usrc_Main.TabIndex = 0;
            this.m_usrc_Main.Exit_Click += new Tangenta.usrc_Main.delegate_Exit_Click(this.m_usrc_Main_Exit_Click);
            this.m_usrc_Main.Load += new System.EventHandler(this.m_usrc_Main_Load);
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(896, 616);
            this.Controls.Add(this.m_usrc_Main);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "Form_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Main_Form_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private usrc_Main m_usrc_Main;

    }
}

