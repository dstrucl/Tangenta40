namespace FiscalVerificationOfInvoices_SLO
{
    partial class Form_EnterData_to_SalesBookInvoice
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
            this.txt_SerialNumber = new System.Windows.Forms.TextBox();
            this.lbl_SerialNumber = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_InvoiceNumber = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_Write = new System.Windows.Forms.Button();
            this.lbl_Msg = new System.Windows.Forms.Label();
            this.timer_SetNext = new System.Windows.Forms.Timer(this.components);
            this.nm_UpDown_SetNumber = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nm_UpDown_SetNumber)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_SerialNumber
            // 
            this.txt_SerialNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_SerialNumber.Location = new System.Drawing.Point(311, 51);
            this.txt_SerialNumber.Name = "txt_SerialNumber";
            this.txt_SerialNumber.Size = new System.Drawing.Size(336, 31);
            this.txt_SerialNumber.TabIndex = 0;
            // 
            // lbl_SerialNumber
            // 
            this.lbl_SerialNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_SerialNumber.Location = new System.Drawing.Point(12, 54);
            this.lbl_SerialNumber.Name = "lbl_SerialNumber";
            this.lbl_SerialNumber.Size = new System.Drawing.Size(293, 20);
            this.lbl_SerialNumber.TabIndex = 1;
            this.lbl_SerialNumber.Text = "Vezana knjiga računov, serijska številka:";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(12, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(293, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Vezana knjiga računov, številka računa:";
            // 
            // txt_InvoiceNumber
            // 
            this.txt_InvoiceNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_InvoiceNumber.Location = new System.Drawing.Point(311, 95);
            this.txt_InvoiceNumber.Name = "txt_InvoiceNumber";
            this.txt_InvoiceNumber.ReadOnly = true;
            this.txt_InvoiceNumber.Size = new System.Drawing.Size(336, 26);
            this.txt_InvoiceNumber.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(12, 145);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(438, 19);
            this.label2.TabIndex = 5;
            this.label2.Text = "Številka posameznega obrazca iz vezane knjige računov:";
            // 
            // btn_Write
            // 
            this.btn_Write.Location = new System.Drawing.Point(16, 200);
            this.btn_Write.Name = "btn_Write";
            this.btn_Write.Size = new System.Drawing.Size(110, 30);
            this.btn_Write.TabIndex = 6;
            this.btn_Write.Text = "Zapiši";
            this.btn_Write.UseVisualStyleBackColor = true;
            this.btn_Write.Click += new System.EventHandler(this.btn_Write_Click);
            // 
            // lbl_Msg
            // 
            this.lbl_Msg.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_Msg.Location = new System.Drawing.Point(4, 3);
            this.lbl_Msg.Name = "lbl_Msg";
            this.lbl_Msg.Size = new System.Drawing.Size(653, 45);
            this.lbl_Msg.TabIndex = 7;
            this.lbl_Msg.Text = "Message";
            // 
            // timer_SetNext
            // 
            this.timer_SetNext.Interval = 10;
            this.timer_SetNext.Tick += new System.EventHandler(this.timer_SetNext_Tick);
            // 
            // nm_UpDown_SetNumber
            // 
            this.nm_UpDown_SetNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.nm_UpDown_SetNumber.Location = new System.Drawing.Point(433, 143);
            this.nm_UpDown_SetNumber.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nm_UpDown_SetNumber.Name = "nm_UpDown_SetNumber";
            this.nm_UpDown_SetNumber.Size = new System.Drawing.Size(81, 31);
            this.nm_UpDown_SetNumber.TabIndex = 8;
            this.nm_UpDown_SetNumber.TabStop = false;
            // 
            // Form_EnterData_to_SalesBookInvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 242);
            this.ControlBox = false;
            this.Controls.Add(this.nm_UpDown_SetNumber);
            this.Controls.Add(this.lbl_Msg);
            this.Controls.Add(this.btn_Write);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_InvoiceNumber);
            this.Controls.Add(this.lbl_SerialNumber);
            this.Controls.Add(this.txt_SerialNumber);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form_EnterData_to_SalesBookInvoice";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form_EnterData_to_SalesBookInvoice";
            this.Load += new System.EventHandler(this.Form_EnterData_to_SalesBookInvoice_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nm_UpDown_SetNumber)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_SerialNumber;
        private System.Windows.Forms.Label lbl_SerialNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_InvoiceNumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_Write;
        private System.Windows.Forms.Label lbl_Msg;
        private System.Windows.Forms.Timer timer_SetNext;
        private System.Windows.Forms.NumericUpDown nm_UpDown_SetNumber;
    }
}