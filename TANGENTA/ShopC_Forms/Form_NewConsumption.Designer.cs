namespace ShopC_Forms
{
    partial class Form_NewConsumption
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_NewConsumption));
            this.btn_New_Empty_OwnUse = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.usrc_Help1 = new HUDCMS.usrc_Help();
            this.btn_New_Empty_WriteOff = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_New_Empty_OwnUse
            // 
            this.btn_New_Empty_OwnUse.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_New_Empty_OwnUse.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_New_Empty_OwnUse.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_New_Empty_OwnUse.Location = new System.Drawing.Point(3, 46);
            this.btn_New_Empty_OwnUse.Margin = new System.Windows.Forms.Padding(2);
            this.btn_New_Empty_OwnUse.Name = "btn_New_Empty_OwnUse";
            this.btn_New_Empty_OwnUse.Size = new System.Drawing.Size(415, 88);
            this.btn_New_Empty_OwnUse.TabIndex = 0;
            this.btn_New_Empty_OwnUse.Text = "New OwnUse";
            this.btn_New_Empty_OwnUse.UseVisualStyleBackColor = false;
            this.btn_New_Empty_OwnUse.Click += new System.EventHandler(this.btn_New_Empty_OwnUse_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_Cancel.Image = ((System.Drawing.Image)(resources.GetObject("btn_Cancel.Image")));
            this.btn_Cancel.Location = new System.Drawing.Point(165, 259);
            this.btn_Cancel.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(73, 29);
            this.btn_Cancel.TabIndex = 36;
            this.btn_Cancel.UseVisualStyleBackColor = false;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // usrc_Help1
            // 
            this.usrc_Help1.Location = new System.Drawing.Point(371, 5);
            this.usrc_Help1.Name = "usrc_Help1";
            this.usrc_Help1.Size = new System.Drawing.Size(42, 25);
            this.usrc_Help1.TabIndex = 40;
            // 
            // btn_New_Empty_WriteOff
            // 
            this.btn_New_Empty_WriteOff.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_New_Empty_WriteOff.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_New_Empty_WriteOff.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_New_Empty_WriteOff.Location = new System.Drawing.Point(3, 138);
            this.btn_New_Empty_WriteOff.Margin = new System.Windows.Forms.Padding(2);
            this.btn_New_Empty_WriteOff.Name = "btn_New_Empty_WriteOff";
            this.btn_New_Empty_WriteOff.Size = new System.Drawing.Size(415, 88);
            this.btn_New_Empty_WriteOff.TabIndex = 41;
            this.btn_New_Empty_WriteOff.Text = "New Write Off";
            this.btn_New_Empty_WriteOff.UseVisualStyleBackColor = false;
            this.btn_New_Empty_WriteOff.Click += new System.EventHandler(this.btn_New_Empty_WriteOff_Click);
            // 
            // Form_NewConsumption
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(418, 310);
            this.Controls.Add(this.btn_New_Empty_WriteOff);
            this.Controls.Add(this.usrc_Help1);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_New_Empty_OwnUse);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form_NewConsumption";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_New_Empty_OwnUse;
        private System.Windows.Forms.Button btn_Cancel;
        private HUDCMS.usrc_Help usrc_Help1;
        private System.Windows.Forms.Button btn_New_Empty_WriteOff;
    }
}