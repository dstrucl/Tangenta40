namespace Tangenta
{
    partial class Form_CodeTables
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_CodeTables));
            this.usrc_CodeTables1 = new Tangenta.usrc_CodeTables();
            this.SuspendLayout();
            // 
            // usrc_CodeTables1
            // 
            this.usrc_CodeTables1.Location = new System.Drawing.Point(-4, 2);
            this.usrc_CodeTables1.Name = "usrc_CodeTables1";
            this.usrc_CodeTables1.Size = new System.Drawing.Size(611, 218);
            this.usrc_CodeTables1.TabIndex = 0;
            this.usrc_CodeTables1.OK_Click += new Tangenta.usrc_CodeTables.delegate_OK_Click(this.usrc_CodeTables1_OK_Click);
            this.usrc_CodeTables1.EndDialog += new Tangenta.usrc_CodeTables.delegate_EndDialog(this.usrc_CodeTables1_EndDialog);
            this.usrc_CodeTables1.Load += new System.EventHandler(this.usrc_CodeTables1_Load);
            // 
            // Form_CodeTables
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(607, 222);
            this.Controls.Add(this.usrc_CodeTables1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_CodeTables";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form_CodeTables";
            this.ResumeLayout(false);

        }

        #endregion

        private usrc_CodeTables usrc_CodeTables1;
    }
}