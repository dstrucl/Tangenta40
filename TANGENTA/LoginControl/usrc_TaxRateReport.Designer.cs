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
            this.lbl_TaxName = new System.Windows.Forms.Label();
            this.lbl_Neto = new System.Windows.Forms.Label();
            this.lbl_Tax = new System.Windows.Forms.Label();
            this.lbl_Neto_Value = new System.Windows.Forms.Label();
            this.lbl_Total = new System.Windows.Forms.Label();
            this.lbl_Tax_Value = new System.Windows.Forms.Label();
            this.lbl_Total_Value = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_TaxName
            // 
            this.lbl_TaxName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_TaxName.Location = new System.Drawing.Point(5, 2);
            this.lbl_TaxName.Name = "lbl_TaxName";
            this.lbl_TaxName.Size = new System.Drawing.Size(134, 22);
            this.lbl_TaxName.TabIndex = 0;
            this.lbl_TaxName.Text = "DDV xx%";
            this.lbl_TaxName.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lbl_Neto
            // 
            this.lbl_Neto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_Neto.Location = new System.Drawing.Point(145, 2);
            this.lbl_Neto.Name = "lbl_Neto";
            this.lbl_Neto.Size = new System.Drawing.Size(104, 22);
            this.lbl_Neto.TabIndex = 1;
            this.lbl_Neto.Text = "Neto:";
            // 
            // lbl_Tax
            // 
            this.lbl_Tax.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_Tax.Location = new System.Drawing.Point(274, 2);
            this.lbl_Tax.Name = "lbl_Tax";
            this.lbl_Tax.Size = new System.Drawing.Size(104, 22);
            this.lbl_Tax.TabIndex = 2;
            this.lbl_Tax.Text = "Tax:";
            // 
            // lbl_Neto_Value
            // 
            this.lbl_Neto_Value.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_Neto_Value.Location = new System.Drawing.Point(145, 20);
            this.lbl_Neto_Value.Name = "lbl_Neto_Value";
            this.lbl_Neto_Value.Size = new System.Drawing.Size(123, 22);
            this.lbl_Neto_Value.TabIndex = 3;
            this.lbl_Neto_Value.Text = "Neto value";
            // 
            // lbl_Total
            // 
            this.lbl_Total.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_Total.Location = new System.Drawing.Point(384, 2);
            this.lbl_Total.Name = "lbl_Total";
            this.lbl_Total.Size = new System.Drawing.Size(110, 22);
            this.lbl_Total.TabIndex = 4;
            this.lbl_Total.Text = "Total:";
            // 
            // lbl_Tax_Value
            // 
            this.lbl_Tax_Value.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_Tax_Value.Location = new System.Drawing.Point(274, 20);
            this.lbl_Tax_Value.Name = "lbl_Tax_Value";
            this.lbl_Tax_Value.Size = new System.Drawing.Size(104, 22);
            this.lbl_Tax_Value.TabIndex = 5;
            this.lbl_Tax_Value.Text = "Tax value";
            // 
            // lbl_Total_Value
            // 
            this.lbl_Total_Value.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_Total_Value.Location = new System.Drawing.Point(384, 20);
            this.lbl_Total_Value.Name = "lbl_Total_Value";
            this.lbl_Total_Value.Size = new System.Drawing.Size(128, 22);
            this.lbl_Total_Value.TabIndex = 6;
            this.lbl_Total_Value.Text = "Total value";
            // 
            // usrc_TaxRateReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Linen;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.lbl_Total_Value);
            this.Controls.Add(this.lbl_Tax_Value);
            this.Controls.Add(this.lbl_Total);
            this.Controls.Add(this.lbl_Neto_Value);
            this.Controls.Add(this.lbl_Tax);
            this.Controls.Add(this.lbl_Neto);
            this.Controls.Add(this.lbl_TaxName);
            this.Name = "usrc_TaxRateReport";
            this.Size = new System.Drawing.Size(515, 40);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_TaxName;
        private System.Windows.Forms.Label lbl_Neto;
        private System.Windows.Forms.Label lbl_Tax;
        private System.Windows.Forms.Label lbl_Neto_Value;
        private System.Windows.Forms.Label lbl_Total;
        private System.Windows.Forms.Label lbl_Tax_Value;
        private System.Windows.Forms.Label lbl_Total_Value;
    }
}
