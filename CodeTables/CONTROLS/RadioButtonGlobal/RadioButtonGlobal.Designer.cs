namespace RadioButtonGlobal
{
    partial class RadioButtonGlobal
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
            this.rdb = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // rdb
            // 
            this.rdb.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdb.AutoSize = true;
            this.rdb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rdb.Image = global::RadioButtonGlobal.Properties.Resources.SelectToEdit;
            this.rdb.Location = new System.Drawing.Point(0, 0);
            this.rdb.Name = "rdb";
            this.rdb.Size = new System.Drawing.Size(114, 32);
            this.rdb.TabIndex = 1;
            this.rdb.TabStop = true;
            this.rdb.UseVisualStyleBackColor = true;
            this.rdb.CheckedChanged += new System.EventHandler(this.rdb_CheckedChanged);
            // 
            // RadioButtonGlobal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.rdb);
            this.Name = "RadioButtonGlobal";
            this.Size = new System.Drawing.Size(114, 32);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rdb;
    }
}
