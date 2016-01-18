namespace FiscalVerificationOfInvoices_SLO
{
    partial class FormFURSCommunication
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
            this.components = new System.ComponentModel.Container();
            this.lbl_FURSCommunication = new System.Windows.Forms.Label();
            this.TmrStart = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // lbl_FURSCommunication
            // 
            this.lbl_FURSCommunication.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_FURSCommunication.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_FURSCommunication.ForeColor = System.Drawing.Color.Navy;
            this.lbl_FURSCommunication.Location = new System.Drawing.Point(7, 30);
            this.lbl_FURSCommunication.Name = "lbl_FURSCommunication";
            this.lbl_FURSCommunication.Size = new System.Drawing.Size(486, 38);
            this.lbl_FURSCommunication.TabIndex = 0;
            this.lbl_FURSCommunication.Text = "Prenašam podatke na FURS";
            this.lbl_FURSCommunication.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TmrStart
            // 
            this.TmrStart.Tick += new System.EventHandler(this.TmrStart_Tick);
            // 
            // FormFURSCommunication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(504, 112);
            this.Controls.Add(this.lbl_FURSCommunication);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormFURSCommunication";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormFURSCommunication";
            this.Load += new System.EventHandler(this.FormFURSCommunication_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_FURSCommunication;
        private System.Windows.Forms.Timer TmrStart;
    }
}