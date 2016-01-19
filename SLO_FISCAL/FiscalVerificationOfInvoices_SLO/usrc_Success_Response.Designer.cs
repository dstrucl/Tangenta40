namespace FiscalVerificationOfInvoices_SLO
{
    partial class usrc_Success_Response
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
            this.txt_ProtectID = new System.Windows.Forms.TextBox();
            this.lbl_ = new System.Windows.Forms.Label();
            this.lbl_MessageType = new System.Windows.Forms.Label();
            this.txt_UniqueInvoiceID = new System.Windows.Forms.TextBox();
            this.lbl_UniqueInvoiceID = new System.Windows.Forms.Label();
            this.pic_QR = new System.Windows.Forms.PictureBox();
            this.lbl_QR = new System.Windows.Forms.Label();
            this.btn_OK = new System.Windows.Forms.Button();
            this.timer_Close = new System.Windows.Forms.Timer(this.components);
            this.lbl_CountDown = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pic_QR)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_ProtectID
            // 
            this.txt_ProtectID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_ProtectID.ForeColor = System.Drawing.Color.Black;
            this.txt_ProtectID.Location = new System.Drawing.Point(153, 37);
            this.txt_ProtectID.Name = "txt_ProtectID";
            this.txt_ProtectID.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_ProtectID.Size = new System.Drawing.Size(335, 26);
            this.txt_ProtectID.TabIndex = 5;
            // 
            // lbl_
            // 
            this.lbl_.AutoSize = true;
            this.lbl_.Location = new System.Drawing.Point(3, 38);
            this.lbl_.Name = "lbl_";
            this.lbl_.Size = new System.Drawing.Size(144, 13);
            this.lbl_.TabIndex = 4;
            this.lbl_.Text = "Sporočilo ID (\"ProtectedID\"):";
            // 
            // lbl_MessageType
            // 
            this.lbl_MessageType.AutoSize = true;
            this.lbl_MessageType.Location = new System.Drawing.Point(3, 13);
            this.lbl_MessageType.Name = "lbl_MessageType";
            this.lbl_MessageType.Size = new System.Drawing.Size(72, 13);
            this.lbl_MessageType.TabIndex = 3;
            this.lbl_MessageType.Text = "Tip Sporočila:";
            // 
            // txt_UniqueInvoiceID
            // 
            this.txt_UniqueInvoiceID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_UniqueInvoiceID.ForeColor = System.Drawing.Color.DarkGreen;
            this.txt_UniqueInvoiceID.Location = new System.Drawing.Point(176, 69);
            this.txt_UniqueInvoiceID.Name = "txt_UniqueInvoiceID";
            this.txt_UniqueInvoiceID.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_UniqueInvoiceID.Size = new System.Drawing.Size(335, 26);
            this.txt_UniqueInvoiceID.TabIndex = 7;
            this.txt_UniqueInvoiceID.Text = "12345678901234567890123456";
            // 
            // lbl_UniqueInvoiceID
            // 
            this.lbl_UniqueInvoiceID.AutoSize = true;
            this.lbl_UniqueInvoiceID.Location = new System.Drawing.Point(3, 71);
            this.lbl_UniqueInvoiceID.Name = "lbl_UniqueInvoiceID";
            this.lbl_UniqueInvoiceID.Size = new System.Drawing.Size(167, 13);
            this.lbl_UniqueInvoiceID.TabIndex = 6;
            this.lbl_UniqueInvoiceID.Text = "Unikatna davčna številka računa:";
            // 
            // pic_QR
            // 
            this.pic_QR.Location = new System.Drawing.Point(72, 118);
            this.pic_QR.Name = "pic_QR";
            this.pic_QR.Size = new System.Drawing.Size(128, 128);
            this.pic_QR.TabIndex = 8;
            this.pic_QR.TabStop = false;
            // 
            // lbl_QR
            // 
            this.lbl_QR.AutoSize = true;
            this.lbl_QR.Location = new System.Drawing.Point(11, 119);
            this.lbl_QR.Name = "lbl_QR";
            this.lbl_QR.Size = new System.Drawing.Size(53, 13);
            this.lbl_QR.TabIndex = 9;
            this.lbl_QR.Text = "QR coda:";
            // 
            // btn_OK
            // 
            this.btn_OK.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_OK.Location = new System.Drawing.Point(228, 193);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(110, 53);
            this.btn_OK.TabIndex = 10;
            this.btn_OK.Text = "OK";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // timer_Close
            // 
            this.timer_Close.Interval = 1000;
            // 
            // lbl_CountDown
            // 
            this.lbl_CountDown.AutoSize = true;
            this.lbl_CountDown.Location = new System.Drawing.Point(476, 233);
            this.lbl_CountDown.Name = "lbl_CountDown";
            this.lbl_CountDown.Size = new System.Drawing.Size(0, 13);
            this.lbl_CountDown.TabIndex = 11;
            // 
            // usrc_Success_Response
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightYellow;
            this.Controls.Add(this.lbl_CountDown);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.lbl_QR);
            this.Controls.Add(this.pic_QR);
            this.Controls.Add(this.txt_UniqueInvoiceID);
            this.Controls.Add(this.lbl_UniqueInvoiceID);
            this.Controls.Add(this.txt_ProtectID);
            this.Controls.Add(this.lbl_);
            this.Controls.Add(this.lbl_MessageType);
            this.Name = "usrc_Success_Response";
            this.Size = new System.Drawing.Size(536, 260);
            this.Load += new System.EventHandler(this.usrc_Success_Response_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pic_QR)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_ProtectID;
        private System.Windows.Forms.Label lbl_;
        private System.Windows.Forms.Label lbl_MessageType;
        private System.Windows.Forms.TextBox txt_UniqueInvoiceID;
        private System.Windows.Forms.Label lbl_UniqueInvoiceID;
        private System.Windows.Forms.PictureBox pic_QR;
        private System.Windows.Forms.Label lbl_QR;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Timer timer_Close;
        private System.Windows.Forms.Label lbl_CountDown;
    }
}
