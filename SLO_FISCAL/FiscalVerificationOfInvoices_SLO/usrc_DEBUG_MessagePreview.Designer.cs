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
            this.lbl_MessageType = new System.Windows.Forms.Label();
            this.lbl_MessageID = new System.Windows.Forms.Label();
            this.txt_MessageID = new System.Windows.Forms.TextBox();
            this.txt_MessageXml = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_XML_Response = new System.Windows.Forms.Label();
            this.txt_Response_XML = new System.Windows.Forms.TextBox();
            this.btn_End = new System.Windows.Forms.Button();
            this.txt_Response_MessageID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
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
            this.lbl_MessageID.Size = new System.Drawing.Size(67, 13);
            this.lbl_MessageID.TabIndex = 6;
            this.lbl_MessageID.Text = "Message ID:";
            // 
            // txt_MessageID
            // 
            this.txt_MessageID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.HistoryList;
            this.txt_MessageID.Location = new System.Drawing.Point(87, 31);
            this.txt_MessageID.Name = "txt_MessageID";
            this.txt_MessageID.Size = new System.Drawing.Size(108, 20);
            this.txt_MessageID.TabIndex = 8;
            // 
            // txt_MessageXml
            // 
            this.txt_MessageXml.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_MessageXml.Location = new System.Drawing.Point(0, 66);
            this.txt_MessageXml.Multiline = true;
            this.txt_MessageXml.Name = "txt_MessageXml";
            this.txt_MessageXml.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_MessageXml.Size = new System.Drawing.Size(459, 129);
            this.txt_MessageXml.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "XML:";
            // 
            // lbl_XML_Response
            // 
            this.lbl_XML_Response.AutoSize = true;
            this.lbl_XML_Response.Location = new System.Drawing.Point(5, 207);
            this.lbl_XML_Response.Name = "lbl_XML_Response";
            this.lbl_XML_Response.Size = new System.Drawing.Size(94, 13);
            this.lbl_XML_Response.TabIndex = 12;
            this.lbl_XML_Response.Text = "XML RESPONSE:";
            // 
            // txt_Response_XML
            // 
            this.txt_Response_XML.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Response_XML.Location = new System.Drawing.Point(3, 227);
            this.txt_Response_XML.Multiline = true;
            this.txt_Response_XML.Name = "txt_Response_XML";
            this.txt_Response_XML.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_Response_XML.Size = new System.Drawing.Size(459, 156);
            this.txt_Response_XML.TabIndex = 11;
            // 
            // btn_End
            // 
            this.btn_End.Location = new System.Drawing.Point(367, 5);
            this.btn_End.Name = "btn_End";
            this.btn_End.Size = new System.Drawing.Size(66, 23);
            this.btn_End.TabIndex = 13;
            this.btn_End.Text = "KONEC";
            this.btn_End.UseVisualStyleBackColor = true;
            this.btn_End.Click += new System.EventHandler(this.btn_End_Click);
            // 
            // txt_Response_MessageID
            // 
            this.txt_Response_MessageID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.HistoryList;
            this.txt_Response_MessageID.Location = new System.Drawing.Point(178, 201);
            this.txt_Response_MessageID.Name = "txt_Response_MessageID";
            this.txt_Response_MessageID.Size = new System.Drawing.Size(108, 20);
            this.txt_Response_MessageID.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(105, 206);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Message ID:";
            // 
            // usrc_DEBUG_MessagePreview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Controls.Add(this.txt_Response_MessageID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_End);
            this.Controls.Add(this.lbl_XML_Response);
            this.Controls.Add(this.txt_Response_XML);
            this.Controls.Add(this.txt_MessageID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl_MessageID);
            this.Controls.Add(this.lbl_MessageType);
            this.Controls.Add(this.btn_PostMessage);
            this.Controls.Add(this.txt_MessageXml);
            this.Name = "usrc_DEBUG_MessagePreview";
            this.Size = new System.Drawing.Size(465, 386);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_PostMessage;
        private System.Windows.Forms.Label lbl_MessageType;
        private System.Windows.Forms.Label lbl_MessageID;
        private System.Windows.Forms.TextBox txt_MessageID;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lbl_XML_Response;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_MessageXml;
        private System.Windows.Forms.TextBox txt_Response_XML;
        private System.Windows.Forms.Button btn_End;
        private System.Windows.Forms.TextBox txt_Response_MessageID;
        private System.Windows.Forms.Label label2;
    }
}
