namespace FiscalVerificationOfInvoices_SLO_TEST
{
    partial class Form1
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
            this.usrc_FVI_SLO1 = new FiscalVerificationOfInvoices_SLO.usrc_FVI_SLO();
            this.btn_Start = new System.Windows.Forms.Button();
            this.btn_End = new System.Windows.Forms.Button();
            this.txt_Response_ECHO_xml = new System.Windows.Forms.TextBox();
            this.lbl_Response_ECHO = new System.Windows.Forms.Label();
            this.btn_Send_ECHO = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btn_CompareCertFileToBuiltInTestCertificate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // usrc_FVI_SLO1
            // 
            this.usrc_FVI_SLO1.FursD_ElectronicDeviceID = "";
            this.usrc_FVI_SLO1.Location = new System.Drawing.Point(12, 12);
            this.usrc_FVI_SLO1.MessageBox_Length = 100;
            this.usrc_FVI_SLO1.Name = "usrc_FVI_SLO1";
            this.usrc_FVI_SLO1.Size = new System.Drawing.Size(39, 26);
            this.usrc_FVI_SLO1.TabIndex = 0;
            this.usrc_FVI_SLO1.Response_SingleInvoice += new FiscalVerificationOfInvoices_SLO.usrc_FVI_SLO.delegate_Response_SingleInvoice(this.usrc_FVI_SLO1_Response_SingleInvoice);
            this.usrc_FVI_SLO1.Response_ManyInvoices += new FiscalVerificationOfInvoices_SLO.usrc_FVI_SLO.delegate_Response_ManyInvoices(this.usrc_FVI_SLO1_Response_ManyInvoices);
            this.usrc_FVI_SLO1.Response_PP += new FiscalVerificationOfInvoices_SLO.usrc_FVI_SLO.delegate_Response_PP(this.usrc_FVI_SLO1_Response_PP);
            this.usrc_FVI_SLO1.Response_ECHO += new FiscalVerificationOfInvoices_SLO.usrc_FVI_SLO.delegate_Response_ECHO(this.usrc_FVI_SLO1_Response_ECHO);
            this.usrc_FVI_SLO1.Load += new System.EventHandler(this.usrc_FVI_SLO1_Load);
            // 
            // btn_Start
            // 
            this.btn_Start.Location = new System.Drawing.Point(95, 12);
            this.btn_Start.Name = "btn_Start";
            this.btn_Start.Size = new System.Drawing.Size(59, 26);
            this.btn_Start.TabIndex = 1;
            this.btn_Start.Text = "START";
            this.btn_Start.UseVisualStyleBackColor = true;
            this.btn_Start.Click += new System.EventHandler(this.btn_Start_Click);
            // 
            // btn_End
            // 
            this.btn_End.Location = new System.Drawing.Point(184, 12);
            this.btn_End.Name = "btn_End";
            this.btn_End.Size = new System.Drawing.Size(59, 26);
            this.btn_End.TabIndex = 2;
            this.btn_End.Text = "END";
            this.btn_End.UseVisualStyleBackColor = true;
            this.btn_End.Click += new System.EventHandler(this.btn_End_Click);
            // 
            // txt_Response_ECHO_xml
            // 
            this.txt_Response_ECHO_xml.Location = new System.Drawing.Point(13, 73);
            this.txt_Response_ECHO_xml.Multiline = true;
            this.txt_Response_ECHO_xml.Name = "txt_Response_ECHO_xml";
            this.txt_Response_ECHO_xml.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_Response_ECHO_xml.Size = new System.Drawing.Size(580, 427);
            this.txt_Response_ECHO_xml.TabIndex = 3;
            // 
            // lbl_Response_ECHO
            // 
            this.lbl_Response_ECHO.AutoSize = true;
            this.lbl_Response_ECHO.Location = new System.Drawing.Point(14, 52);
            this.lbl_Response_ECHO.Name = "lbl_Response_ECHO";
            this.lbl_Response_ECHO.Size = new System.Drawing.Size(88, 13);
            this.lbl_Response_ECHO.TabIndex = 4;
            this.lbl_Response_ECHO.Text = "Response ECHO";
            // 
            // btn_Send_ECHO
            // 
            this.btn_Send_ECHO.Location = new System.Drawing.Point(249, 12);
            this.btn_Send_ECHO.Name = "btn_Send_ECHO";
            this.btn_Send_ECHO.Size = new System.Drawing.Size(90, 25);
            this.btn_Send_ECHO.TabIndex = 5;
            this.btn_Send_ECHO.Text = "SEND ECHO";
            this.btn_Send_ECHO.UseVisualStyleBackColor = true;
            this.btn_Send_ECHO.Click += new System.EventHandler(this.btn_Send_ECHO_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(345, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(142, 25);
            this.button1.TabIndex = 6;
            this.button1.Text = "SEND BUS. PERM.";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(493, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(101, 25);
            this.button2.TabIndex = 7;
            this.button2.Text = "SEND INVOICE";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btn_CompareCertFileToBuiltInTestCertificate
            // 
            this.btn_CompareCertFileToBuiltInTestCertificate.Location = new System.Drawing.Point(12, 506);
            this.btn_CompareCertFileToBuiltInTestCertificate.Name = "btn_CompareCertFileToBuiltInTestCertificate";
            this.btn_CompareCertFileToBuiltInTestCertificate.Size = new System.Drawing.Size(317, 25);
            this.btn_CompareCertFileToBuiltInTestCertificate.TabIndex = 8;
            this.btn_CompareCertFileToBuiltInTestCertificate.Text = "COMPARE CERTIFICATE FILE TO BUILT IN Test Certificate";
            this.btn_CompareCertFileToBuiltInTestCertificate.UseVisualStyleBackColor = true;
            this.btn_CompareCertFileToBuiltInTestCertificate.Click += new System.EventHandler(this.btn_CompareCertFileToBuiltInTestCertificate_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 557);
            this.Controls.Add(this.btn_CompareCertFileToBuiltInTestCertificate);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_Send_ECHO);
            this.Controls.Add(this.lbl_Response_ECHO);
            this.Controls.Add(this.txt_Response_ECHO_xml);
            this.Controls.Add(this.btn_End);
            this.Controls.Add(this.btn_Start);
            this.Controls.Add(this.usrc_FVI_SLO1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FiscalVerificationOfInvoices_SLO.usrc_FVI_SLO usrc_FVI_SLO1;
        private System.Windows.Forms.Button btn_Start;
        private System.Windows.Forms.Button btn_End;
        private System.Windows.Forms.TextBox txt_Response_ECHO_xml;
        private System.Windows.Forms.Label lbl_Response_ECHO;
        private System.Windows.Forms.Button btn_Send_ECHO;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btn_CompareCertFileToBuiltInTestCertificate;
    }
}

