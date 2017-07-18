namespace FiscalVerificationOfInvoices_SLO
{
    partial class Form_BussinesPremisse
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
            this.btn_Exit = new System.Windows.Forms.Button();
            this.lbl_msg = new System.Windows.Forms.Label();
            this.usrc_FURS_BussinesPremiseData1 = new FiscalVerificationOfInvoices_SLO.usrc_FURS_BussinesPremiseData();
            this.SuspendLayout();
            // 
            // btn_Exit
            // 
            this.btn_Exit.Location = new System.Drawing.Point(320, 291);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(110, 35);
            this.btn_Exit.TabIndex = 1;
            this.btn_Exit.Text = "button1";
            this.btn_Exit.UseVisualStyleBackColor = true;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // lbl_msg
            // 
            this.lbl_msg.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_msg.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_msg.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbl_msg.Location = new System.Drawing.Point(10, 11);
            this.lbl_msg.Name = "lbl_msg";
            this.lbl_msg.Size = new System.Drawing.Size(759, 41);
            this.lbl_msg.TabIndex = 2;
            this.lbl_msg.Text = "label1";
            // 
            // usrc_FURS_BussinesPremiseData1
            // 
            this.usrc_FURS_BussinesPremiseData1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.usrc_FURS_BussinesPremiseData1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.usrc_FURS_BussinesPremiseData1.Location = new System.Drawing.Point(5, 55);
            this.usrc_FURS_BussinesPremiseData1.Name = "usrc_FURS_BussinesPremiseData1";
            this.usrc_FURS_BussinesPremiseData1.ReadOnly = false;
            this.usrc_FURS_BussinesPremiseData1.Size = new System.Drawing.Size(764, 230);
            this.usrc_FURS_BussinesPremiseData1.TabIndex = 3;
            this.usrc_FURS_BussinesPremiseData1.FURS_BussinesPremiseData_SignedUp += new FiscalVerificationOfInvoices_SLO.usrc_FURS_BussinesPremiseData.delegate_FURS_BussinesPremiseData_SignedUp(this.usrc_FURS_BussinesPremiseData1_FURS_BussinesPremiseData_SignedUp);
            // 
            // Form_BussinesPremisse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(777, 337);
            this.Controls.Add(this.usrc_FURS_BussinesPremiseData1);
            this.Controls.Add(this.lbl_msg);
            this.Controls.Add(this.btn_Exit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "Form_BussinesPremisse";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form_BussinesPremisse";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btn_Exit;
        private System.Windows.Forms.Label lbl_msg;
        private usrc_FURS_BussinesPremiseData usrc_FURS_BussinesPremiseData1;
    }
}