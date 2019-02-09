using HUDCMS;

namespace ShopC_Forms
{
    partial class usrc_AddOn_Consumption
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(usrc_AddOn_Consumption));
            this.btn_Invoice_Issue = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.dtP_DateOfIssue = new System.Windows.Forms.DateTimePicker();
            this.lbl_DateOfIssue = new System.Windows.Forms.Label();
            this.usrc_Help1 = new HUDCMS.usrc_Help();
            this.lbl_WriteOffDescription = new System.Windows.Forms.Label();
            this.txt_DescriptionDescription = new System.Windows.Forms.TextBox();
            this.lbl_OwnUse_Reason_Name = new System.Windows.Forms.Label();
            this.cmb_Reason = new System.Windows.Forms.ComboBox();
            this.txt_ReasonDescription = new System.Windows.Forms.TextBox();
            this.lbl_OwnUse_Reason_Description = new System.Windows.Forms.Label();
            this.cmb_Description = new System.Windows.Forms.ComboBox();
            this.lbl_Description_Name = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_Invoice_Issue
            // 
            this.btn_Invoice_Issue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Invoice_Issue.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_Invoice_Issue.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_Invoice_Issue.ForeColor = System.Drawing.Color.Black;
            this.btn_Invoice_Issue.Location = new System.Drawing.Point(8, 549);
            this.btn_Invoice_Issue.Name = "btn_Invoice_Issue";
            this.btn_Invoice_Issue.Size = new System.Drawing.Size(398, 65);
            this.btn_Invoice_Issue.TabIndex = 7;
            this.btn_Invoice_Issue.Text = "Issue";
            this.btn_Invoice_Issue.UseVisualStyleBackColor = false;
            this.btn_Invoice_Issue.Click += new System.EventHandler(this.btn_Issue_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Cancel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_Cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_Cancel.ForeColor = System.Drawing.Color.Black;
            this.btn_Cancel.Image = ((System.Drawing.Image)(resources.GetObject("btn_Cancel.Image")));
            this.btn_Cancel.Location = new System.Drawing.Point(595, 562);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(115, 52);
            this.btn_Cancel.TabIndex = 12;
            this.btn_Cancel.UseVisualStyleBackColor = false;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // dtP_DateOfIssue
            // 
            this.dtP_DateOfIssue.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.dtP_DateOfIssue.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.dtP_DateOfIssue.Location = new System.Drawing.Point(236, 4);
            this.dtP_DateOfIssue.Name = "dtP_DateOfIssue";
            this.dtP_DateOfIssue.Size = new System.Drawing.Size(368, 29);
            this.dtP_DateOfIssue.TabIndex = 17;
            // 
            // lbl_DateOfIssue
            // 
            this.lbl_DateOfIssue.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_DateOfIssue.Location = new System.Drawing.Point(24, 8);
            this.lbl_DateOfIssue.Name = "lbl_DateOfIssue";
            this.lbl_DateOfIssue.Size = new System.Drawing.Size(206, 25);
            this.lbl_DateOfIssue.TabIndex = 22;
            this.lbl_DateOfIssue.Text = "Date of issue";
            this.lbl_DateOfIssue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // usrc_Help1
            // 
            this.usrc_Help1.Location = new System.Drawing.Point(636, 4);
            this.usrc_Help1.Name = "usrc_Help1";
            this.usrc_Help1.Size = new System.Drawing.Size(69, 29);
            this.usrc_Help1.TabIndex = 24;
            // 
            // lbl_WriteOffDescription
            // 
            this.lbl_WriteOffDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_WriteOffDescription.AutoSize = true;
            this.lbl_WriteOffDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_WriteOffDescription.Location = new System.Drawing.Point(5, 362);
            this.lbl_WriteOffDescription.Name = "lbl_WriteOffDescription";
            this.lbl_WriteOffDescription.Size = new System.Drawing.Size(152, 16);
            this.lbl_WriteOffDescription.TabIndex = 25;
            this.lbl_WriteOffDescription.Text = "Own Use Description";
            // 
            // txt_DescriptionDescription
            // 
            this.txt_DescriptionDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_DescriptionDescription.Location = new System.Drawing.Point(3, 392);
            this.txt_DescriptionDescription.Multiline = true;
            this.txt_DescriptionDescription.Name = "txt_DescriptionDescription";
            this.txt_DescriptionDescription.Size = new System.Drawing.Size(704, 129);
            this.txt_DescriptionDescription.TabIndex = 26;
            // 
            // lbl_OwnUse_Reason_Name
            // 
            this.lbl_OwnUse_Reason_Name.AutoSize = true;
            this.lbl_OwnUse_Reason_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_OwnUse_Reason_Name.Location = new System.Drawing.Point(5, 61);
            this.lbl_OwnUse_Reason_Name.Name = "lbl_OwnUse_Reason_Name";
            this.lbl_OwnUse_Reason_Name.Size = new System.Drawing.Size(172, 16);
            this.lbl_OwnUse_Reason_Name.TabIndex = 27;
            this.lbl_OwnUse_Reason_Name.Text = "Own Use Reason Name";
            // 
            // cmb_Reason
            // 
            this.cmb_Reason.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmb_Reason.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_Reason.FormattingEnabled = true;
            this.cmb_Reason.Location = new System.Drawing.Point(6, 80);
            this.cmb_Reason.Name = "cmb_Reason";
            this.cmb_Reason.Size = new System.Drawing.Size(701, 32);
            this.cmb_Reason.TabIndex = 28;
            // 
            // txt_ReasonDescription
            // 
            this.txt_ReasonDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_ReasonDescription.Location = new System.Drawing.Point(0, 145);
            this.txt_ReasonDescription.Multiline = true;
            this.txt_ReasonDescription.Name = "txt_ReasonDescription";
            this.txt_ReasonDescription.Size = new System.Drawing.Size(707, 135);
            this.txt_ReasonDescription.TabIndex = 29;
            // 
            // lbl_OwnUse_Reason_Description
            // 
            this.lbl_OwnUse_Reason_Description.AutoSize = true;
            this.lbl_OwnUse_Reason_Description.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_OwnUse_Reason_Description.Location = new System.Drawing.Point(0, 126);
            this.lbl_OwnUse_Reason_Description.Name = "lbl_OwnUse_Reason_Description";
            this.lbl_OwnUse_Reason_Description.Size = new System.Drawing.Size(210, 16);
            this.lbl_OwnUse_Reason_Description.TabIndex = 30;
            this.lbl_OwnUse_Reason_Description.Text = "Own Use Reason Description";
            // 
            // cmb_Description
            // 
            this.cmb_Description.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmb_Description.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_Description.FormattingEnabled = true;
            this.cmb_Description.Location = new System.Drawing.Point(3, 318);
            this.cmb_Description.Name = "cmb_Description";
            this.cmb_Description.Size = new System.Drawing.Size(704, 32);
            this.cmb_Description.TabIndex = 32;
            // 
            // lbl_Description_Name
            // 
            this.lbl_Description_Name.AutoSize = true;
            this.lbl_Description_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Description_Name.Location = new System.Drawing.Point(3, 299);
            this.lbl_Description_Name.Name = "lbl_Description_Name";
            this.lbl_Description_Name.Size = new System.Drawing.Size(197, 16);
            this.lbl_Description_Name.TabIndex = 31;
            this.lbl_Description_Name.Text = "Own Use Description Name";
            // 
            // usrc_OwnUse_AddOn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.cmb_Description);
            this.Controls.Add(this.lbl_Description_Name);
            this.Controls.Add(this.lbl_OwnUse_Reason_Description);
            this.Controls.Add(this.txt_ReasonDescription);
            this.Controls.Add(this.cmb_Reason);
            this.Controls.Add(this.lbl_OwnUse_Reason_Name);
            this.Controls.Add(this.txt_DescriptionDescription);
            this.Controls.Add(this.lbl_WriteOffDescription);
            this.Controls.Add(this.usrc_Help1);
            this.Controls.Add(this.lbl_DateOfIssue);
            this.Controls.Add(this.dtP_DateOfIssue);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_Invoice_Issue);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "usrc_OwnUse_AddOn";
            this.Size = new System.Drawing.Size(717, 627);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_Invoice_Issue;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.DateTimePicker dtP_DateOfIssue;
        private System.Windows.Forms.Label lbl_DateOfIssue;
        private usrc_Help usrc_Help1;
        private System.Windows.Forms.Label lbl_WriteOffDescription;
        private System.Windows.Forms.TextBox txt_DescriptionDescription;
        private System.Windows.Forms.Label lbl_OwnUse_Reason_Name;
        private System.Windows.Forms.ComboBox cmb_Reason;
        private System.Windows.Forms.TextBox txt_ReasonDescription;
        private System.Windows.Forms.Label lbl_OwnUse_Reason_Description;
        private System.Windows.Forms.ComboBox cmb_Description;
        private System.Windows.Forms.Label lbl_Description_Name;
    }
}
