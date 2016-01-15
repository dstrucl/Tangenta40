namespace FiscalVerificationOfInvoices_SLO
{
    partial class usrc_DEBUG_MessagePreview
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
            this.btn_PostMessage = new System.Windows.Forms.Button();
            this.txt_MessageXml = new System.Windows.Forms.TextBox();
            this.lbl_MessageType = new System.Windows.Forms.Label();
            this.lbl_MessageID = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_PostMessage
            // 
            this.btn_PostMessage.Location = new System.Drawing.Point(254, 34);
            this.btn_PostMessage.Name = "btn_PostMessage";
            this.btn_PostMessage.Size = new System.Drawing.Size(208, 26);
            this.btn_PostMessage.TabIndex = 4;
            this.btn_PostMessage.Text = "PostMessage --> Thread_FVI_Message ";
            this.btn_PostMessage.UseVisualStyleBackColor = true;
            this.btn_PostMessage.Click += new System.EventHandler(this.btn_PostMessage_Click);
            // 
            // txt_MessageXml
            // 
            this.txt_MessageXml.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_MessageXml.Location = new System.Drawing.Point(3, 86);
            this.txt_MessageXml.Multiline = true;
            this.txt_MessageXml.Name = "txt_MessageXml";
            this.txt_MessageXml.Size = new System.Drawing.Size(459, 366);
            this.txt_MessageXml.TabIndex = 3;
            // 
            // lbl_MessageType
            // 
            this.lbl_MessageType.AutoSize = true;
            this.lbl_MessageType.Location = new System.Drawing.Point(14, 11);
            this.lbl_MessageType.Name = "lbl_MessageType";
            this.lbl_MessageType.Size = new System.Drawing.Size(90, 13);
            this.lbl_MessageType.TabIndex = 5;
            this.lbl_MessageType.Text = "lbl_MessageType";
            // 
            // lbl_MessageID
            // 
            this.lbl_MessageID.AutoSize = true;
            this.lbl_MessageID.Location = new System.Drawing.Point(14, 34);
            this.lbl_MessageID.Name = "lbl_MessageID";
            this.lbl_MessageID.Size = new System.Drawing.Size(77, 13);
            this.lbl_MessageID.TabIndex = 6;
            this.lbl_MessageID.Text = "lbl_MessageID";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "XML:";
            // 
            // usrc_DEBUG_MessagePreview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl_MessageID);
            this.Controls.Add(this.lbl_MessageType);
            this.Controls.Add(this.btn_PostMessage);
            this.Controls.Add(this.txt_MessageXml);
            this.Name = "usrc_DEBUG_MessagePreview";
            this.Size = new System.Drawing.Size(465, 452);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_PostMessage;
        private System.Windows.Forms.TextBox txt_MessageXml;
        private System.Windows.Forms.Label lbl_MessageType;
        private System.Windows.Forms.Label lbl_MessageID;
        private System.Windows.Forms.Label label1;
    }
}
