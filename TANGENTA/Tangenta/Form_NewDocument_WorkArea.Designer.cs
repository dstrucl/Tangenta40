using DocumentManager;

namespace Tangenta
{
    partial class Form_NewDocument_WorkArea
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_NewDocument_WorkArea));
            this.usrc_WorkAreaAll1 = new usrc_WorkAreaAll();
            this.SuspendLayout();
            // 
            // usrc_WorkAreaAll1
            // 
            this.usrc_WorkAreaAll1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.usrc_WorkAreaAll1.dtWorkAreaAll = null;
            this.usrc_WorkAreaAll1.Location = new System.Drawing.Point(0, 0);
            this.usrc_WorkAreaAll1.Name = "usrc_WorkAreaAll1";
            this.usrc_WorkAreaAll1.NumberOfItemsPerPage = 10;
            this.usrc_WorkAreaAll1.Size = new System.Drawing.Size(915, 553);
            this.usrc_WorkAreaAll1.TabIndex = 0;
            this.usrc_WorkAreaAll1.Selected += new usrc_WorkAreaAll.delegate_Selected(this.usrc_WorkAreaAll1_Selected);
            this.usrc_WorkAreaAll1.Exit += new usrc_WorkAreaAll.delegate_Exit(this.usrc_WorkAreaAll1_Exit);
            // 
            // Form_NewDocument_WorkArea
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(915, 553);
            this.Controls.Add(this.usrc_WorkAreaAll1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_NewDocument_WorkArea";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form_NewDocument_WorkArea";
            this.Load += new System.EventHandler(this.Form_NewDocument_WorkArea_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private usrc_WorkAreaAll usrc_WorkAreaAll1;
    }
}