﻿namespace HtmlDoc
{
    partial class HtmlTreeView_Form
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
            this.htmlTreeView_UserControl1 = new HtmlTreeView_UserControl();
            this.SuspendLayout();
            // 
            // htmlTreeView_UserControl1
            // 
            this.htmlTreeView_UserControl1.Location = new System.Drawing.Point(12, 12);
            this.htmlTreeView_UserControl1.Name = "htmlTreeView_UserControl1";
            this.htmlTreeView_UserControl1.Size = new System.Drawing.Size(260, 228);
            this.htmlTreeView_UserControl1.TabIndex = 0;
            // 
            // HtmlTreeView_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.htmlTreeView_UserControl1);
            this.Name = "HtmlTreeView_Form";
            this.Text = "HtmlTreeView_Form";
            this.ResumeLayout(false);

        }

        #endregion

        private HtmlTreeView_UserControl htmlTreeView_UserControl1;
    }
}