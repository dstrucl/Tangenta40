namespace TangentaCore
{
    partial class Form_NewDocument_WizzardForHelp
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
            this.bn_Cancel = new System.Windows.Forms.Button();
            this.btn_Start = new System.Windows.Forms.Button();
            this.lbl_StepDocInvoice = new System.Windows.Forms.Label();
            this.txt_DocumentType = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // bn_Cancel
            // 
            this.bn_Cancel.Location = new System.Drawing.Point(354, 1);
            this.bn_Cancel.Name = "bn_Cancel";
            this.bn_Cancel.Size = new System.Drawing.Size(51, 28);
            this.bn_Cancel.TabIndex = 0;
            this.bn_Cancel.Text = "Cancel";
            this.bn_Cancel.UseVisualStyleBackColor = true;
            this.bn_Cancel.Click += new System.EventHandler(this.bn_Cancel_Click);
            // 
            // btn_Start
            // 
            this.btn_Start.Location = new System.Drawing.Point(123, 6);
            this.btn_Start.Name = "btn_Start";
            this.btn_Start.Size = new System.Drawing.Size(102, 23);
            this.btn_Start.TabIndex = 3;
            this.btn_Start.Text = "Make HTML";
            this.btn_Start.UseVisualStyleBackColor = true;
            this.btn_Start.Click += new System.EventHandler(this.btn_Start_Click);
            // 
            // lbl_StepDocInvoice
            // 
            this.lbl_StepDocInvoice.Location = new System.Drawing.Point(5, 47);
            this.lbl_StepDocInvoice.Name = "lbl_StepDocInvoice";
            this.lbl_StepDocInvoice.Size = new System.Drawing.Size(118, 19);
            this.lbl_StepDocInvoice.TabIndex = 4;
            this.lbl_StepDocInvoice.Text = "XML file:";
            this.lbl_StepDocInvoice.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txt_DocumentType
            // 
            this.txt_DocumentType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_DocumentType.BackColor = System.Drawing.Color.White;
            this.txt_DocumentType.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_DocumentType.Location = new System.Drawing.Point(123, 52);
            this.txt_DocumentType.Name = "txt_DocumentType";
            this.txt_DocumentType.ReadOnly = true;
            this.txt_DocumentType.Size = new System.Drawing.Size(280, 13);
            this.txt_DocumentType.TabIndex = 5;
            // 
            // Form_NewDocument_WizzardForHelp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 96);
            this.Controls.Add(this.txt_DocumentType);
            this.Controls.Add(this.lbl_StepDocInvoice);
            this.Controls.Add(this.btn_Start);
            this.Controls.Add(this.bn_Cancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "Form_NewDocument_WizzardForHelp";
            this.Text = "Help Wizzard for Form_NewDocument";
            this.Load += new System.EventHandler(this.Form_NewDocument_WizzardForHelp_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bn_Cancel;
        private System.Windows.Forms.Button btn_Start;
        private System.Windows.Forms.Label lbl_StepDocInvoice;
        private System.Windows.Forms.TextBox txt_DocumentType;
    }
}