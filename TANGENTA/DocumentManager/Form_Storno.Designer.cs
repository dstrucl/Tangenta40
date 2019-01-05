namespace DocumentManager
{
    partial class Form_Storno
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Storno));
            this.txt_StornoReason = new System.Windows.Forms.TextBox();
            this.lbl_StornoMessage = new System.Windows.Forms.Label();
            this.btn_Storno = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.cmb_StornoReason = new System.Windows.Forms.ComboBox();
            this.lbl_WriteReason = new System.Windows.Forms.Label();
            this.lbl_SelectExistingReason = new System.Windows.Forms.Label();
            this.usrc_Help1 = new HUDCMS.usrc_Help();
            this.SuspendLayout();
            // 
            // txt_StornoReason
            // 
            this.txt_StornoReason.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_StornoReason.Location = new System.Drawing.Point(12, 133);
            this.txt_StornoReason.Multiline = true;
            this.txt_StornoReason.Name = "txt_StornoReason";
            this.txt_StornoReason.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_StornoReason.Size = new System.Drawing.Size(679, 212);
            this.txt_StornoReason.TabIndex = 0;
            // 
            // lbl_StornoMessage
            // 
            this.lbl_StornoMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_StornoMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_StornoMessage.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lbl_StornoMessage.Location = new System.Drawing.Point(14, 8);
            this.lbl_StornoMessage.Name = "lbl_StornoMessage";
            this.lbl_StornoMessage.Size = new System.Drawing.Size(644, 49);
            this.lbl_StornoMessage.TabIndex = 1;
            this.lbl_StornoMessage.Text = "label1";
            // 
            // btn_Storno
            // 
            this.btn_Storno.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Storno.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_Storno.Location = new System.Drawing.Point(12, 356);
            this.btn_Storno.Name = "btn_Storno";
            this.btn_Storno.Size = new System.Drawing.Size(98, 30);
            this.btn_Storno.TabIndex = 2;
            this.btn_Storno.Text = "STORNO";
            this.btn_Storno.UseVisualStyleBackColor = false;
            this.btn_Storno.Click += new System.EventHandler(this.btn_Storno_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Cancel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_Cancel.Image = Properties.Resources.Exit;
            this.btn_Cancel.Location = new System.Drawing.Point(164, 356);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(98, 30);
            this.btn_Cancel.TabIndex = 3;
            this.btn_Cancel.UseVisualStyleBackColor = false;
            // 
            // cmb_StornoReason
            // 
            this.cmb_StornoReason.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmb_StornoReason.FormattingEnabled = true;
            this.cmb_StornoReason.Location = new System.Drawing.Point(12, 82);
            this.cmb_StornoReason.Name = "cmb_StornoReason";
            this.cmb_StornoReason.Size = new System.Drawing.Size(678, 21);
            this.cmb_StornoReason.TabIndex = 4;
            // 
            // lbl_WriteReason
            // 
            this.lbl_WriteReason.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_WriteReason.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_WriteReason.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lbl_WriteReason.Location = new System.Drawing.Point(12, 113);
            this.lbl_WriteReason.Name = "lbl_WriteReason";
            this.lbl_WriteReason.Size = new System.Drawing.Size(657, 16);
            this.lbl_WriteReason.TabIndex = 5;
            this.lbl_WriteReason.Text = "label1";
            // 
            // lbl_SelectExistingReason
            // 
            this.lbl_SelectExistingReason.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_SelectExistingReason.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_SelectExistingReason.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lbl_SelectExistingReason.Location = new System.Drawing.Point(12, 57);
            this.lbl_SelectExistingReason.Name = "lbl_SelectExistingReason";
            this.lbl_SelectExistingReason.Size = new System.Drawing.Size(657, 22);
            this.lbl_SelectExistingReason.TabIndex = 6;
            this.lbl_SelectExistingReason.Text = "label1";
            // 
            // usrc_Help1
            // 
            this.usrc_Help1.Location = new System.Drawing.Point(664, 4);
            this.usrc_Help1.Name = "usrc_Help1";
            this.usrc_Help1.Size = new System.Drawing.Size(35, 28);
            this.usrc_Help1.TabIndex = 7;
            // 
            // Form_Storno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(703, 393);
            this.Controls.Add(this.usrc_Help1);
            this.Controls.Add(this.lbl_SelectExistingReason);
            this.Controls.Add(this.lbl_WriteReason);
            this.Controls.Add(this.cmb_StornoReason);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_Storno);
            this.Controls.Add(this.lbl_StornoMessage);
            this.Controls.Add(this.txt_StornoReason);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_Storno";
            this.Text = "Form_Storno";
            this.Load += new System.EventHandler(this.Form_Storno_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_StornoReason;
        private System.Windows.Forms.Label lbl_StornoMessage;
        private System.Windows.Forms.Button btn_Storno;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.ComboBox cmb_StornoReason;
        private System.Windows.Forms.Label lbl_WriteReason;
        private System.Windows.Forms.Label lbl_SelectExistingReason;
        private HUDCMS.usrc_Help usrc_Help1;
    }
}