namespace Tangenta
{
    partial class Form_ShowShops
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
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.rdb_AB = new System.Windows.Forms.RadioButton();
            this.rdb_B = new System.Windows.Forms.RadioButton();
            this.rdb_A = new System.Windows.Forms.RadioButton();
            this.rdb_C = new System.Windows.Forms.RadioButton();
            this.rdb_BC = new System.Windows.Forms.RadioButton();
            this.rdb_AC = new System.Windows.Forms.RadioButton();
            this.rdb_ABC = new System.Windows.Forms.RadioButton();
            this.usrc_Help1 = new HUDCMS.usrc_Help();
            this.SuspendLayout();
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_Cancel.Image = global::Tangenta.Properties.Resources.Exit;
            this.btn_Cancel.Location = new System.Drawing.Point(10, 226);
            this.btn_Cancel.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(73, 29);
            this.btn_Cancel.TabIndex = 35;
            this.btn_Cancel.UseVisualStyleBackColor = false;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // rdb_AB
            // 
            this.rdb_AB.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rdb_AB.Location = new System.Drawing.Point(10, 101);
            this.rdb_AB.Margin = new System.Windows.Forms.Padding(2);
            this.rdb_AB.Name = "rdb_AB";
            this.rdb_AB.Size = new System.Drawing.Size(349, 23);
            this.rdb_AB.TabIndex = 39;
            this.rdb_AB.Text = "A && B";
            this.rdb_AB.UseVisualStyleBackColor = true;
            // 
            // rdb_B
            // 
            this.rdb_B.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rdb_B.Location = new System.Drawing.Point(10, 38);
            this.rdb_B.Margin = new System.Windows.Forms.Padding(2);
            this.rdb_B.Name = "rdb_B";
            this.rdb_B.Size = new System.Drawing.Size(349, 23);
            this.rdb_B.TabIndex = 38;
            this.rdb_B.Text = "B";
            this.rdb_B.UseVisualStyleBackColor = true;
            // 
            // rdb_A
            // 
            this.rdb_A.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rdb_A.Location = new System.Drawing.Point(10, 7);
            this.rdb_A.Margin = new System.Windows.Forms.Padding(2);
            this.rdb_A.Name = "rdb_A";
            this.rdb_A.Size = new System.Drawing.Size(310, 23);
            this.rdb_A.TabIndex = 37;
            this.rdb_A.Text = "A";
            this.rdb_A.UseVisualStyleBackColor = true;
            this.rdb_A.CheckedChanged += new System.EventHandler(this.rdb_A_CheckedChanged_1);
            // 
            // rdb_C
            // 
            this.rdb_C.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rdb_C.Location = new System.Drawing.Point(10, 70);
            this.rdb_C.Margin = new System.Windows.Forms.Padding(2);
            this.rdb_C.Name = "rdb_C";
            this.rdb_C.Size = new System.Drawing.Size(349, 23);
            this.rdb_C.TabIndex = 40;
            this.rdb_C.Text = "C";
            this.rdb_C.UseVisualStyleBackColor = true;
            // 
            // rdb_BC
            // 
            this.rdb_BC.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rdb_BC.Location = new System.Drawing.Point(10, 163);
            this.rdb_BC.Margin = new System.Windows.Forms.Padding(2);
            this.rdb_BC.Name = "rdb_BC";
            this.rdb_BC.Size = new System.Drawing.Size(349, 23);
            this.rdb_BC.TabIndex = 41;
            this.rdb_BC.Text = "B && C";
            this.rdb_BC.UseVisualStyleBackColor = true;
            // 
            // rdb_AC
            // 
            this.rdb_AC.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rdb_AC.Location = new System.Drawing.Point(10, 132);
            this.rdb_AC.Margin = new System.Windows.Forms.Padding(2);
            this.rdb_AC.Name = "rdb_AC";
            this.rdb_AC.Size = new System.Drawing.Size(349, 23);
            this.rdb_AC.TabIndex = 42;
            this.rdb_AC.Text = "A && C";
            this.rdb_AC.UseVisualStyleBackColor = true;
            // 
            // rdb_ABC
            // 
            this.rdb_ABC.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rdb_ABC.Location = new System.Drawing.Point(10, 194);
            this.rdb_ABC.Margin = new System.Windows.Forms.Padding(2);
            this.rdb_ABC.Name = "rdb_ABC";
            this.rdb_ABC.Size = new System.Drawing.Size(349, 23);
            this.rdb_ABC.TabIndex = 43;
            this.rdb_ABC.Text = "A && B && C";
            this.rdb_ABC.UseVisualStyleBackColor = true;
            // 
            // usrc_Help1
            // 
            this.usrc_Help1.Location = new System.Drawing.Point(325, 4);
            this.usrc_Help1.Name = "usrc_Help1";
            this.usrc_Help1.Size = new System.Drawing.Size(33, 29);
            this.usrc_Help1.TabIndex = 44;
            // 
            // Form_ShowShops
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(361, 265);
            this.Controls.Add(this.usrc_Help1);
            this.Controls.Add(this.rdb_ABC);
            this.Controls.Add(this.rdb_AC);
            this.Controls.Add(this.rdb_BC);
            this.Controls.Add(this.rdb_C);
            this.Controls.Add(this.rdb_AB);
            this.Controls.Add(this.rdb_B);
            this.Controls.Add(this.rdb_A);
            this.Controls.Add(this.btn_Cancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form_ShowShops";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Load += new System.EventHandler(this.Form_SelectPanels_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.RadioButton rdb_AB;
        private System.Windows.Forms.RadioButton rdb_B;
        private System.Windows.Forms.RadioButton rdb_A;
        private System.Windows.Forms.RadioButton rdb_C;
        private System.Windows.Forms.RadioButton rdb_BC;
        private System.Windows.Forms.RadioButton rdb_AC;
        private System.Windows.Forms.RadioButton rdb_ABC;
        private HUDCMS.usrc_Help usrc_Help1;
    }
}