namespace FiscalVerificationOfInvoices_SLO
{
    partial class usrc_Error_Response
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
            this.lbl_MessageType = new System.Windows.Forms.Label();
            this.lbl_ErrorMessage = new System.Windows.Forms.Label();
            this.txt_ErrorMessage = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lbl_MessageType
            // 
            this.lbl_MessageType.AutoSize = true;
            this.lbl_MessageType.Location = new System.Drawing.Point(12, 13);
            this.lbl_MessageType.Name = "lbl_MessageType";
            this.lbl_MessageType.Size = new System.Drawing.Size(72, 13);
            this.lbl_MessageType.TabIndex = 0;
            this.lbl_MessageType.Text = "Tip Sporočila:";
            // 
            // lbl_ErrorMessage
            // 
            this.lbl_ErrorMessage.AutoSize = true;
            this.lbl_ErrorMessage.Location = new System.Drawing.Point(12, 38);
            this.lbl_ErrorMessage.Name = "lbl_ErrorMessage";
            this.lbl_ErrorMessage.Size = new System.Drawing.Size(53, 13);
            this.lbl_ErrorMessage.TabIndex = 1;
            this.lbl_ErrorMessage.Text = "NAPAKA:";
            // 
            // txt_ErrorMessage
            // 
            this.txt_ErrorMessage.ForeColor = System.Drawing.Color.Black;
            this.txt_ErrorMessage.Location = new System.Drawing.Point(83, 37);
            this.txt_ErrorMessage.Multiline = true;
            this.txt_ErrorMessage.Name = "txt_ErrorMessage";
            this.txt_ErrorMessage.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_ErrorMessage.Size = new System.Drawing.Size(312, 46);
            this.txt_ErrorMessage.TabIndex = 2;
            // 
            // usrc_Error_Response
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.Controls.Add(this.txt_ErrorMessage);
            this.Controls.Add(this.lbl_ErrorMessage);
            this.Controls.Add(this.lbl_MessageType);
            this.Name = "usrc_Error_Response";
            this.Size = new System.Drawing.Size(409, 117);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_MessageType;
        private System.Windows.Forms.Label lbl_ErrorMessage;
        private System.Windows.Forms.TextBox txt_ErrorMessage;
    }
}
