namespace FiscalVerificationOfInvoices_SLO
{
    partial class FormFURSCommunicationERRORhandler
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
            this.btn_TryAagin = new System.Windows.Forms.Button();
            this.btn_WriteInSalesBook = new System.Windows.Forms.Button();
            this.lbl_Message = new System.Windows.Forms.Label();
            this.lbl_ErrorMessage = new System.Windows.Forms.Label();
            this.btn_CheckInternetConnection = new System.Windows.Forms.Button();
            this.btn_SendLater = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_TryAagin
            // 
            this.btn_TryAagin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_TryAagin.Location = new System.Drawing.Point(204, 302);
            this.btn_TryAagin.Name = "btn_TryAagin";
            this.btn_TryAagin.Size = new System.Drawing.Size(181, 55);
            this.btn_TryAagin.TabIndex = 0;
            this.btn_TryAagin.Text = "Try Again";
            this.btn_TryAagin.UseVisualStyleBackColor = true;
            this.btn_TryAagin.Click += new System.EventHandler(this.btn_TryAagin_Click);
            // 
            // btn_WriteInSalesBook
            // 
            this.btn_WriteInSalesBook.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_WriteInSalesBook.Location = new System.Drawing.Point(399, 302);
            this.btn_WriteInSalesBook.Name = "btn_WriteInSalesBook";
            this.btn_WriteInSalesBook.Size = new System.Drawing.Size(181, 55);
            this.btn_WriteInSalesBook.TabIndex = 1;
            this.btn_WriteInSalesBook.Text = "Write In Sales Book";
            this.btn_WriteInSalesBook.UseVisualStyleBackColor = true;
            this.btn_WriteInSalesBook.Click += new System.EventHandler(this.btn_WriteInSalesBook_Click);
            // 
            // lbl_Message
            // 
            this.lbl_Message.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Message.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_Message.ForeColor = System.Drawing.Color.Blue;
            this.lbl_Message.Location = new System.Drawing.Point(6, 50);
            this.lbl_Message.Name = "lbl_Message";
            this.lbl_Message.Size = new System.Drawing.Size(774, 245);
            this.lbl_Message.TabIndex = 2;
            this.lbl_Message.Text = "label1";
            // 
            // lbl_ErrorMessage
            // 
            this.lbl_ErrorMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_ErrorMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_ErrorMessage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.lbl_ErrorMessage.Location = new System.Drawing.Point(6, 9);
            this.lbl_ErrorMessage.Name = "lbl_ErrorMessage";
            this.lbl_ErrorMessage.Size = new System.Drawing.Size(774, 40);
            this.lbl_ErrorMessage.TabIndex = 3;
            this.lbl_ErrorMessage.Text = "label1";
            // 
            // btn_CheckInternetConnection
            // 
            this.btn_CheckInternetConnection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_CheckInternetConnection.Location = new System.Drawing.Point(594, 302);
            this.btn_CheckInternetConnection.Name = "btn_CheckInternetConnection";
            this.btn_CheckInternetConnection.Size = new System.Drawing.Size(181, 55);
            this.btn_CheckInternetConnection.TabIndex = 4;
            this.btn_CheckInternetConnection.Text = "Check Internet_Connection";
            this.btn_CheckInternetConnection.UseVisualStyleBackColor = true;
            this.btn_CheckInternetConnection.Click += new System.EventHandler(this.btn_CheckInternetConnection_Click);
            // 
            // btn_SendLater
            // 
            this.btn_SendLater.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_SendLater.Location = new System.Drawing.Point(9, 302);
            this.btn_SendLater.Name = "btn_SendLater";
            this.btn_SendLater.Size = new System.Drawing.Size(181, 55);
            this.btn_SendLater.TabIndex = 5;
            this.btn_SendLater.Text = "Send Later";
            this.btn_SendLater.UseVisualStyleBackColor = true;
            this.btn_SendLater.Click += new System.EventHandler(this.btn_SendLater_Click);
            // 
            // FormFURSCommunicationERRORhandler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(789, 363);
            this.ControlBox = false;
            this.Controls.Add(this.btn_SendLater);
            this.Controls.Add(this.btn_CheckInternetConnection);
            this.Controls.Add(this.lbl_ErrorMessage);
            this.Controls.Add(this.lbl_Message);
            this.Controls.Add(this.btn_WriteInSalesBook);
            this.Controls.Add(this.btn_TryAagin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "FormFURSCommunicationERRORhandler";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormFURSCommunicationERRORhandler";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_TryAagin;
        private System.Windows.Forms.Button btn_WriteInSalesBook;
        private System.Windows.Forms.Label lbl_Message;
        private System.Windows.Forms.Label lbl_ErrorMessage;
        private System.Windows.Forms.Button btn_CheckInternetConnection;
        private System.Windows.Forms.Button btn_SendLater;
    }
}