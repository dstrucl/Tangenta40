namespace TangentaCore
{
    partial class Form_Customer_Org_Assign
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Customer_Org_Assign));
            this.lbl_Instruction_part1 = new System.Windows.Forms.Label();
            this.lbl_Instruction_part2 = new System.Windows.Forms.Label();
            this.btn_Yes = new System.Windows.Forms.Button();
            this.btn_No = new System.Windows.Forms.Button();
            this.lbl_Org = new System.Windows.Forms.TextBox();
            this.usrc_Help1 = new HUDCMS.usrc_Help();
            this.SuspendLayout();
            // 
            // lbl_Instruction_part1
            // 
            this.lbl_Instruction_part1.AutoSize = true;
            this.lbl_Instruction_part1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lbl_Instruction_part1.Location = new System.Drawing.Point(18, 11);
            this.lbl_Instruction_part1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_Instruction_part1.Name = "lbl_Instruction_part1";
            this.lbl_Instruction_part1.Size = new System.Drawing.Size(99, 16);
            this.lbl_Instruction_part1.TabIndex = 0;
            this.lbl_Instruction_part1.Text = "Želite osebo:";
            // 
            // lbl_Instruction_part2
            // 
            this.lbl_Instruction_part2.AutoSize = true;
            this.lbl_Instruction_part2.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lbl_Instruction_part2.Location = new System.Drawing.Point(18, 203);
            this.lbl_Instruction_part2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_Instruction_part2.Name = "lbl_Instruction_part2";
            this.lbl_Instruction_part2.Size = new System.Drawing.Size(99, 16);
            this.lbl_Instruction_part2.TabIndex = 2;
            this.lbl_Instruction_part2.Text = "Želite osebo:";
            // 
            // btn_Yes
            // 
            this.btn_Yes.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_Yes.Cursor = System.Windows.Forms.Cursors.PanSW;
            this.btn_Yes.Location = new System.Drawing.Point(260, 244);
            this.btn_Yes.Name = "btn_Yes";
            this.btn_Yes.Size = new System.Drawing.Size(91, 32);
            this.btn_Yes.TabIndex = 3;
            this.btn_Yes.Text = "button1";
            this.btn_Yes.UseVisualStyleBackColor = false;
            this.btn_Yes.Click += new System.EventHandler(this.btn_Yes_Click);
            // 
            // btn_No
            // 
            this.btn_No.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_No.Location = new System.Drawing.Point(390, 244);
            this.btn_No.Name = "btn_No";
            this.btn_No.Size = new System.Drawing.Size(91, 32);
            this.btn_No.TabIndex = 4;
            this.btn_No.Text = "button1";
            this.btn_No.UseVisualStyleBackColor = false;
            this.btn_No.Click += new System.EventHandler(this.btn_No_Click);
            // 
            // lbl_Org
            // 
            this.lbl_Org.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbl_Org.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_Org.Location = new System.Drawing.Point(29, 30);
            this.lbl_Org.Multiline = true;
            this.lbl_Org.Name = "lbl_Org";
            this.lbl_Org.ReadOnly = true;
            this.lbl_Org.Size = new System.Drawing.Size(667, 158);
            this.lbl_Org.TabIndex = 5;
            // 
            // usrc_Help1
            // 
            this.usrc_Help1.Location = new System.Drawing.Point(702, 0);
            this.usrc_Help1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.usrc_Help1.Name = "usrc_Help1";
            this.usrc_Help1.Size = new System.Drawing.Size(38, 30);
            this.usrc_Help1.TabIndex = 6;
            // 
            // Form_Customer_Org_Assign
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(743, 288);
            this.Controls.Add(this.usrc_Help1);
            this.Controls.Add(this.lbl_Org);
            this.Controls.Add(this.btn_No);
            this.Controls.Add(this.btn_Yes);
            this.Controls.Add(this.lbl_Instruction_part2);
            this.Controls.Add(this.lbl_Instruction_part1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_Customer_Org_Assign";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form_Customer_Add";
            this.Load += new System.EventHandler(this.Form_Customer_Assign_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_Instruction_part1;
        private System.Windows.Forms.Label lbl_Instruction_part2;
        private System.Windows.Forms.Button btn_Yes;
        private System.Windows.Forms.Button btn_No;
        private System.Windows.Forms.TextBox lbl_Org;
        private HUDCMS.usrc_Help usrc_Help1;
    }
}