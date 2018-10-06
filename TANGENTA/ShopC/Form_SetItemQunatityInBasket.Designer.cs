namespace ShopC
{
    partial class Form_SetItemQuantityInBasket
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
            this.usrc_SetItemQuantityInBasket1 = new ShopC.usrc_SetItemQuantityInBasket();
            this.SuspendLayout();
            // 
            // usrc_SetItemQuantityInBasket1
            // 
            this.usrc_SetItemQuantityInBasket1.BackColor = System.Drawing.Color.YellowGreen;
            this.usrc_SetItemQuantityInBasket1.Location = new System.Drawing.Point(3, 3);
            this.usrc_SetItemQuantityInBasket1.Name = "usrc_SetItemQuantityInBasket1";
            this.usrc_SetItemQuantityInBasket1.Size = new System.Drawing.Size(1038, 320);
            this.usrc_SetItemQuantityInBasket1.TabIndex = 0;
            this.usrc_SetItemQuantityInBasket1.ExitClick += new ShopC.usrc_SetItemQuantityInBasket.delegate_ExitClick(this.usrc_SetItemQuantityInBasket1_ExitClick);
            // 
            // Form_SetItemQuantityInBasket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1040, 324);
            this.Controls.Add(this.usrc_SetItemQuantityInBasket1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form_SetItemQuantityInBasket";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);

        }

        #endregion

        private usrc_SetItemQuantityInBasket usrc_SetItemQuantityInBasket1;
    }
}