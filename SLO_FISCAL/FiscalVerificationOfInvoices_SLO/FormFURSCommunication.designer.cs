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
            this.lbl_TEST_Environment = new System.Windows.Forms.Label();
            this.Lbl_errorDesc = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_FURSCommunication
            // 
            this.lbl_FURSCommunication.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_FURSCommunication.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_FURSCommunication.ForeColor = System.Drawing.Color.Navy;
            this.lbl_FURSCommunication.Location = new System.Drawing.Point(7, 35);
            this.lbl_FURSCommunication.Name = "lbl_FURSCommunication";
            this.lbl_FURSCommunication.Size = new System.Drawing.Size(486, 38);
            this.lbl_FURSCommunication.TabIndex = 0;
            this.lbl_FURSCommunication.Text = "Prenašam podatke na FURS";
            this.lbl_FURSCommunication.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TmrStart
            // 
            this.TmrStart.Interval = 200;
            this.TmrStart.Tick += new System.EventHandler(this.TmrStart_Tick);
            // 
            // lbl_TEST_Environment
            // 
            this.lbl_TEST_Environment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_TEST_Environment.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_TEST_Environment.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lbl_TEST_Environment.Location = new System.Drawing.Point(10, 5);
            this.lbl_TEST_Environment.Name = "lbl_TEST_Environment";
            this.lbl_TEST_Environment.Size = new System.Drawing.Size(486, 26);
            this.lbl_TEST_Environment.TabIndex = 1;
            this.lbl_TEST_Environment.Text = "TESTNO OKOLJE";
            // 
            // Lbl_errorDesc
            // 
            this.Lbl_errorDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Lbl_errorDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Lbl_errorDesc.ForeColor = System.Drawing.Color.Navy;
            this.Lbl_errorDesc.Location = new System.Drawing.Point(12, 73);
            this.Lbl_errorDesc.Name = "Lbl_errorDesc";
            this.Lbl_errorDesc.Size = new System.Drawing.Size(486, 69);
            this.Lbl_errorDesc.TabIndex = 2;
            this.Lbl_errorDesc.Text = "Prenašam podatke na FURS";
            this.Lbl_errorDesc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormFURSCommunication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(504, 151);
            this.Controls.Add(this.Lbl_errorDesc);
            this.Controls.Add(this.lbl_TEST_Environment);
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
        private System.Windows.Forms.Label lbl_TEST_Environment;
        private System.Windows.Forms.Label Lbl_errorDesc;
    }
}