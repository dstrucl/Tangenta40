namespace CodeTables
{
    partial class usrc_NumericUpDown
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
            this.btn_Plus = new System.Windows.Forms.Button();
            this.btn_Minus = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txt_Value
            // 
            this.txt_Value.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_Value.Location = new System.Drawing.Point(4, 7);
            this.txt_Value.Name = "txt_Value";
            this.txt_Value.Size = new System.Drawing.Size(156, 20);
            this.txt_Value.TabIndex = 0;
            // 
            // btn_Plus
            // 
            this.btn_Plus.Image = global::CodeTables.Properties.Resources.Up;
            this.btn_Plus.Location = new System.Drawing.Point(162, 0);
            this.btn_Plus.Name = "btn_Plus";
            this.btn_Plus.Size = new System.Drawing.Size(30, 19);
            this.btn_Plus.TabIndex = 1;
            this.btn_Plus.UseVisualStyleBackColor = true;
            this.btn_Plus.Click += new System.EventHandler(this.btn_Plus_Click);
            // 
            // btn_Minus
            // 
            this.btn_Minus.Image = global::CodeTables.Properties.Resources.Down;
            this.btn_Minus.Location = new System.Drawing.Point(162, 17);
            this.btn_Minus.Name = "btn_Minus";
            this.btn_Minus.Size = new System.Drawing.Size(30, 19);
            this.btn_Minus.TabIndex = 2;
            this.btn_Minus.UseVisualStyleBackColor = true;
            this.btn_Minus.Click += new System.EventHandler(this.btn_Minus_Click);
            // 
            // usrc_NumericUpDown
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.Controls.Add(this.btn_Minus);
            this.Controls.Add(this.btn_Plus);
            this.Controls.Add(this.txt_Value);
            this.Name = "usrc_NumericUpDown";
            this.Size = new System.Drawing.Size(195, 36);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_Value;
        private System.Windows.Forms.Button btn_Plus;
        private System.Windows.Forms.Button btn_Minus;
    }
}
