﻿namespace FiscalVerificationOfInvoices_SLO
{
    partial class usrc_FVI_SLO
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
            this.btn_FVI = new System.Windows.Forms.Button();
            this.timer_MessagePump = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // btn_FVI
            // 
            this.btn_FVI.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_FVI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_FVI.Image = global::FiscalVerificationOfInvoices_SLO.Properties.Resources.TAX_Office_Connection_NONE;
            this.btn_FVI.Location = new System.Drawing.Point(0, 0);
            this.btn_FVI.Name = "btn_FVI";
            this.btn_FVI.Size = new System.Drawing.Size(33, 26);
            this.btn_FVI.TabIndex = 0;
            this.btn_FVI.UseVisualStyleBackColor = false;
            this.btn_FVI.Click += new System.EventHandler(this.btn_FVI_Click);
            // 
            // timer_MessagePump
            // 
            this.timer_MessagePump.Tick += new System.EventHandler(this.timer_MessagePump_Tick);
            // 
            // usrc_FVI_SLO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btn_FVI);
            this.Name = "usrc_FVI_SLO";
            this.Size = new System.Drawing.Size(33, 26);
            this.Load += new System.EventHandler(this.usrc_FVI_SLO_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_FVI;
        private System.Windows.Forms.Timer timer_MessagePump;
    }
}
