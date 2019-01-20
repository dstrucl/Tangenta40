using HUDCMS;

namespace ShopC_Forms
{
    partial class usrc_WriteOff_AddOn
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(usrc_WriteOff_AddOn));
            this.btn_Consumption_Issue = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.dtP_DateOfIssue = new System.Windows.Forms.DateTimePicker();
            this.lbl_DateOfIssue = new System.Windows.Forms.Label();
            this.usrc_Help1 = new HUDCMS.usrc_Help();
            this.lbl_WriteOffDescription = new System.Windows.Forms.Label();
            this.txt_Description = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btn_Consumption_Issue
            // 
            this.btn_Consumption_Issue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Consumption_Issue.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_Consumption_Issue.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_Consumption_Issue.ForeColor = System.Drawing.Color.Black;
            this.btn_Consumption_Issue.Location = new System.Drawing.Point(20, 267);
            this.btn_Consumption_Issue.Name = "btn_Consumption_Issue";
            this.btn_Consumption_Issue.Size = new System.Drawing.Size(398, 65);
            this.btn_Consumption_Issue.TabIndex = 7;
            this.btn_Consumption_Issue.Text = "Issue";
            this.btn_Consumption_Issue.UseVisualStyleBackColor = false;
            this.btn_Consumption_Issue.Click += new System.EventHandler(this.btn_Consumption_Issue_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Cancel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_Cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_Cancel.ForeColor = System.Drawing.Color.Black;
            this.btn_Cancel.Image = ((System.Drawing.Image)(resources.GetObject("btn_Cancel.Image")));
            this.btn_Cancel.Location = new System.Drawing.Point(590, 280);
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
            this.lbl_WriteOffDescription.AutoSize = true;
            this.lbl_WriteOffDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_WriteOffDescription.Location = new System.Drawing.Point(17, 54);
            this.lbl_WriteOffDescription.Name = "lbl_WriteOffDescription";
            this.lbl_WriteOffDescription.Size = new System.Drawing.Size(150, 16);
            this.lbl_WriteOffDescription.TabIndex = 25;
            this.lbl_WriteOffDescription.Text = "Write Off Description";
            // 
            // txt_Description
            // 
            this.txt_Description.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Description.Location = new System.Drawing.Point(19, 73);
            this.txt_Description.Multiline = true;
            this.txt_Description.Name = "txt_Description";
            this.txt_Description.Size = new System.Drawing.Size(686, 188);
            this.txt_Description.TabIndex = 26;
            // 
            // usrc_WriteOff_AddOn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.txt_Description);
            this.Controls.Add(this.lbl_WriteOffDescription);
            this.Controls.Add(this.usrc_Help1);
            this.Controls.Add(this.lbl_DateOfIssue);
            this.Controls.Add(this.dtP_DateOfIssue);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_Consumption_Issue);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "usrc_WriteOff_AddOn";
            this.Size = new System.Drawing.Size(720, 345);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_Consumption_Issue;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.DateTimePicker dtP_DateOfIssue;
        private System.Windows.Forms.Label lbl_DateOfIssue;
        private usrc_Help usrc_Help1;
        private System.Windows.Forms.Label lbl_WriteOffDescription;
        private System.Windows.Forms.TextBox txt_Description;
    }
}
