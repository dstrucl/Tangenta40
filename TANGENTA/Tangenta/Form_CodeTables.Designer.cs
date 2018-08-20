namespace Tangenta
{
    partial class Form_CodeTables
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_CodeTables));
            this.usrc_CodeTables1 = new Tangenta.usrc_CodeTables();
            this.usrc_Help1 = new HUDCMS.usrc_Help();
            this.btn_MyOrganisation = new System.Windows.Forms.Button();
            this.txt_MyOrganisation = new System.Windows.Forms.TextBox();
            this.lbl_MyOrganisation = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // usrc_CodeTables1
            // 
            this.usrc_CodeTables1.Location = new System.Drawing.Point(12, 110);
            this.usrc_CodeTables1.Name = "usrc_CodeTables1";
            this.usrc_CodeTables1.Size = new System.Drawing.Size(611, 197);
            this.usrc_CodeTables1.TabIndex = 0;
            this.usrc_CodeTables1.OK_Click += new Tangenta.usrc_CodeTables.delegate_OK_Click(this.usrc_CodeTables1_OK_Click);
            this.usrc_CodeTables1.EndDialog += new Tangenta.usrc_CodeTables.delegate_EndDialog(this.usrc_CodeTables1_EndDialog);
            this.usrc_CodeTables1.Load += new System.EventHandler(this.usrc_CodeTables1_Load);
            // 
            // usrc_Help1
            // 
            this.usrc_Help1.Location = new System.Drawing.Point(571, 12);
            this.usrc_Help1.Name = "usrc_Help1";
            this.usrc_Help1.Size = new System.Drawing.Size(42, 26);
            this.usrc_Help1.TabIndex = 1;
            // 
            // btn_MyOrganisation
            // 
            this.btn_MyOrganisation.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_MyOrganisation.Image = ((System.Drawing.Image)(resources.GetObject("btn_MyOrganisation.Image")));
            this.btn_MyOrganisation.Location = new System.Drawing.Point(147, 59);
            this.btn_MyOrganisation.Name = "btn_MyOrganisation";
            this.btn_MyOrganisation.Size = new System.Drawing.Size(50, 30);
            this.btn_MyOrganisation.TabIndex = 38;
            this.btn_MyOrganisation.UseVisualStyleBackColor = false;
            // 
            // txt_MyOrganisation
            // 
            this.txt_MyOrganisation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_MyOrganisation.Location = new System.Drawing.Point(202, 56);
            this.txt_MyOrganisation.Margin = new System.Windows.Forms.Padding(2);
            this.txt_MyOrganisation.Multiline = true;
            this.txt_MyOrganisation.Name = "txt_MyOrganisation";
            this.txt_MyOrganisation.Size = new System.Drawing.Size(415, 34);
            this.txt_MyOrganisation.TabIndex = 36;
            // 
            // lbl_MyOrganisation
            // 
            this.lbl_MyOrganisation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_MyOrganisation.AutoSize = true;
            this.lbl_MyOrganisation.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_MyOrganisation.Location = new System.Drawing.Point(16, 65);
            this.lbl_MyOrganisation.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_MyOrganisation.Name = "lbl_MyOrganisation";
            this.lbl_MyOrganisation.Size = new System.Drawing.Size(126, 17);
            this.lbl_MyOrganisation.TabIndex = 37;
            this.lbl_MyOrganisation.Text = "My Organisation";
            // 
            // Form_CodeTables
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(617, 302);
            this.Controls.Add(this.btn_MyOrganisation);
            this.Controls.Add(this.txt_MyOrganisation);
            this.Controls.Add(this.lbl_MyOrganisation);
            this.Controls.Add(this.usrc_Help1);
            this.Controls.Add(this.usrc_CodeTables1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_CodeTables";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form_CodeTables";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private usrc_CodeTables usrc_CodeTables1;
        private HUDCMS.usrc_Help usrc_Help1;
        private System.Windows.Forms.Button btn_MyOrganisation;
        private System.Windows.Forms.TextBox txt_MyOrganisation;
        private System.Windows.Forms.Label lbl_MyOrganisation;
    }
}