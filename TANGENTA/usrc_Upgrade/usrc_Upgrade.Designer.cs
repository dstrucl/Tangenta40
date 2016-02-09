namespace usrc_Upgrade
{
    partial class usrc_Upgrade
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
            this.btn_Upgrade = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_Upgrade
            // 
            this.btn_Upgrade.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Upgrade.Image = global::Tangenta.Properties.Resources.UpgradeDataBase;
            this.btn_Upgrade.Location = new System.Drawing.Point(0, 0);
            this.btn_Upgrade.Name = "btn_Upgrade";
            this.btn_Upgrade.Size = new System.Drawing.Size(27, 24);
            this.btn_Upgrade.TabIndex = 0;
            this.btn_Upgrade.UseVisualStyleBackColor = true;
            this.btn_Upgrade.Click += new System.EventHandler(this.btn_Upgrade_Click);
            // 
            // usrc_Upgrade
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.btn_Upgrade);
            this.Name = "usrc_Upgrade";
            this.Size = new System.Drawing.Size(28, 25);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Upgrade;
    }
}
