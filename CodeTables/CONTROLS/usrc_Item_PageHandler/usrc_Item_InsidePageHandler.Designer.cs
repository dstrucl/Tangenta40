using System;

namespace usrc_Item_PageHandler
{
    partial class usrc_Item_InsidePageHandler
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
            this.btn_Prev = new System.Windows.Forms.Button();
            this.btn_Next = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_Prev
            // 
            this.btn_Prev.Image = global::usrc_Item_PageHandler.Properties.Resources.Prev;
            this.btn_Prev.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Prev.Location = new System.Drawing.Point(3, 3);
            this.btn_Prev.Name = "btn_Prev";
            this.btn_Prev.Size = new System.Drawing.Size(100, 40);
            this.btn_Prev.TabIndex = 0;
            this.btn_Prev.Text = "1";
            this.btn_Prev.UseVisualStyleBackColor = true;
            this.btn_Prev.Visible = false;
            this.btn_Prev.Click += new System.EventHandler(this.btn_Prev_Click);
            // 
            // btn_Next
            // 
            this.btn_Next.Image = global::usrc_Item_PageHandler.Properties.Resources.Next;
            this.btn_Next.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Next.Location = new System.Drawing.Point(107, 3);
            this.btn_Next.Name = "btn_Next";
            this.btn_Next.Size = new System.Drawing.Size(100, 40);
            this.btn_Next.TabIndex = 1;
            this.btn_Next.Text = "1";
            this.btn_Next.UseVisualStyleBackColor = true;
            this.btn_Next.Visible = false;
            this.btn_Next.Click += new System.EventHandler(this.btn_Next_Click);
            // 
            // usrc_Item_InsidePageHandler
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.btn_Next);
            this.Controls.Add(this.btn_Prev);
            this.Name = "usrc_Item_InsidePageHandler";
            this.Size = new System.Drawing.Size(488, 218);
            this.Resize += new System.EventHandler(this.usrc_Item_InsidePageHandler_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Prev;
        private System.Windows.Forms.Button btn_Next;
    }
}
