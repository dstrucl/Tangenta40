namespace LoginControl
{
    partial class usrc_TaxRateReport
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
            this.txt_TaxName = new System.Windows.Forms.TextBox();
            this.lbl_Neto = new System.Windows.Forms.Label();
            this.lbl_Tax = new System.Windows.Forms.Label();
            this.txt_Neto_Value = new System.Windows.Forms.TextBox();
            this.lbl_Total = new System.Windows.Forms.Label();
            this.txt_Tax_Value = new System.Windows.Forms.TextBox();
            this.txt_Total_Value = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txt_TaxName
            // 
            this.txt_TaxName.BackColor = System.Drawing.Color.SeaShell;
            this.txt_TaxName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_TaxName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_TaxName.Location = new System.Drawing.Point(1, 4);
            this.txt_TaxName.Name = "txt_TaxName";
            this.txt_TaxName.Size = new System.Drawing.Size(77, 13);
            this.txt_TaxName.TabIndex = 0;
            this.txt_TaxName.Text = "DDV xx%";
            // 
            // lbl_Neto
            // 
            this.lbl_Neto.BackColor = System.Drawing.Color.AntiqueWhite;
            this.lbl_Neto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_Neto.Location = new System.Drawing.Point(79, 3);
            this.lbl_Neto.Name = "lbl_Neto";
            this.lbl_Neto.Size = new System.Drawing.Size(67, 14);
            this.lbl_Neto.TabIndex = 1;
            this.lbl_Neto.Text = "Neto:";
            // 
            // lbl_Tax
            // 
            this.lbl_Tax.BackColor = System.Drawing.Color.AntiqueWhite;
            this.lbl_Tax.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_Tax.Location = new System.Drawing.Point(155, 3);
            this.lbl_Tax.Name = "lbl_Tax";
            this.lbl_Tax.Size = new System.Drawing.Size(67, 14);
            this.lbl_Tax.TabIndex = 2;
            this.lbl_Tax.Text = "Tax:";
            // 
            // txt_Neto_Value
            // 
            this.txt_Neto_Value.BackColor = System.Drawing.Color.SeaShell;
            this.txt_Neto_Value.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_Neto_Value.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_Neto_Value.Location = new System.Drawing.Point(79, 16);
            this.txt_Neto_Value.Name = "txt_Neto_Value";
            this.txt_Neto_Value.Size = new System.Drawing.Size(67, 13);
            this.txt_Neto_Value.TabIndex = 3;
            this.txt_Neto_Value.Text = "Neto value";
            // 
            // lbl_Total
            // 
            this.lbl_Total.BackColor = System.Drawing.Color.AntiqueWhite;
            this.lbl_Total.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_Total.Location = new System.Drawing.Point(231, 3);
            this.lbl_Total.Name = "lbl_Total";
            this.lbl_Total.Size = new System.Drawing.Size(67, 14);
            this.lbl_Total.TabIndex = 4;
            this.lbl_Total.Text = "Total:";
            // 
            // txt_Tax_Value
            // 
            this.txt_Tax_Value.BackColor = System.Drawing.Color.SeaShell;
            this.txt_Tax_Value.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_Tax_Value.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_Tax_Value.Location = new System.Drawing.Point(155, 15);
            this.txt_Tax_Value.Name = "txt_Tax_Value";
            this.txt_Tax_Value.Size = new System.Drawing.Size(67, 13);
            this.txt_Tax_Value.TabIndex = 5;
            this.txt_Tax_Value.Text = "Tax value";
            // 
            // txt_Total_Value
            // 
            this.txt_Total_Value.BackColor = System.Drawing.Color.SeaShell;
            this.txt_Total_Value.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_Total_Value.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_Total_Value.Location = new System.Drawing.Point(231, 16);
            this.txt_Total_Value.Name = "txt_Total_Value";
            this.txt_Total_Value.Size = new System.Drawing.Size(67, 13);
            this.txt_Total_Value.TabIndex = 6;
            this.txt_Total_Value.Text = "Total value";
            // 
            // usrc_TaxRateReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.Linen;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.txt_Total_Value);
            this.Controls.Add(this.txt_Tax_Value);
            this.Controls.Add(this.lbl_Total);
            this.Controls.Add(this.txt_Neto_Value);
            this.Controls.Add(this.lbl_Tax);
            this.Controls.Add(this.lbl_Neto);
            this.Controls.Add(this.txt_TaxName);
            this.Name = "usrc_TaxRateReport";
            this.Size = new System.Drawing.Size(300, 32);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_TaxName;
        private System.Windows.Forms.Label lbl_Neto;
        private System.Windows.Forms.Label lbl_Tax;
        private System.Windows.Forms.TextBox txt_Neto_Value;
        private System.Windows.Forms.Label lbl_Total;
        private System.Windows.Forms.TextBox txt_Tax_Value;
        private System.Windows.Forms.TextBox txt_Total_Value;
    }
}
