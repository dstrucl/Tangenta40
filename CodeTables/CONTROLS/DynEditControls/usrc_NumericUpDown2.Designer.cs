namespace DynEditControls
{
    partial class usrc_NumericUpDown2
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
            this.txt_Value = new System.Windows.Forms.TextBox();
            this.btn_Minus = new System.Windows.Forms.Button();
            this.btn_Plus = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txt_Value
            // 
            this.txt_Value.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Value.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_Value.Location = new System.Drawing.Point(0, 12);
            this.txt_Value.Name = "txt_Value";
            this.txt_Value.Size = new System.Drawing.Size(30, 20);
            this.txt_Value.TabIndex = 0;
            // 
            // btn_Minus
            // 
            this.btn_Minus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Minus.Image = global::DynEditControls.Properties.Resources.minus;
            this.btn_Minus.Location = new System.Drawing.Point(78, -1);
            this.btn_Minus.Name = "btn_Minus";
            this.btn_Minus.Size = new System.Drawing.Size(44, 47);
            this.btn_Minus.TabIndex = 2;
            this.btn_Minus.UseVisualStyleBackColor = true;
            this.btn_Minus.Click += new System.EventHandler(this.btn_Minus_Click);
            // 
            // btn_Plus
            // 
            this.btn_Plus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Plus.Image = global::DynEditControls.Properties.Resources.plus;
            this.btn_Plus.Location = new System.Drawing.Point(32, -1);
            this.btn_Plus.Name = "btn_Plus";
            this.btn_Plus.Size = new System.Drawing.Size(44, 47);
            this.btn_Plus.TabIndex = 1;
            this.btn_Plus.UseVisualStyleBackColor = true;
            this.btn_Plus.Click += new System.EventHandler(this.btn_Plus_Click);
            // 
            // usrc_NumericUpDown2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Controls.Add(this.btn_Minus);
            this.Controls.Add(this.btn_Plus);
            this.Controls.Add(this.txt_Value);
            this.Name = "usrc_NumericUpDown2";
            this.Size = new System.Drawing.Size(121, 45);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_Value;
        private System.Windows.Forms.Button btn_Plus;
        private System.Windows.Forms.Button btn_Minus;
    }
}
