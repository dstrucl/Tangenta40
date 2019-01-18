namespace ShopC_Forms
{
    partial class Form_OwnUse
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
            this.usrc_ConsumptionMan1 = new ShopC_Forms.usrc_ConsumptionMan();
            this.SuspendLayout();
            // 
            // usrc_ConsumptionMan1
            // 
            this.usrc_ConsumptionMan1.BackColor = System.Drawing.SystemColors.Control;
            this.usrc_ConsumptionMan1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.usrc_ConsumptionMan1.DocTyp = null;
            this.usrc_ConsumptionMan1.Location = new System.Drawing.Point(0, 0);
            this.usrc_ConsumptionMan1.Name = "usrc_ConsumptionMan1";
            this.usrc_ConsumptionMan1.Size = new System.Drawing.Size(1203, 544);
            this.usrc_ConsumptionMan1.TabIndex = 0;
            // 
            // Form_OwnUse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1203, 544);
            this.Controls.Add(this.usrc_ConsumptionMan1);
            this.Name = "Form_OwnUse";
            this.Text = "Form_OwnUse";
            this.ResumeLayout(false);

        }

        #endregion
        private usrc_ConsumptionMan usrc_ConsumptionMan1;
    }
}