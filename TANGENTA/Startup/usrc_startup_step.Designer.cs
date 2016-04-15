namespace Startup
{
    partial class usrc_startup_step
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(usrc_startup_step));
            this.lbl_startup_step = new System.Windows.Forms.Label();
            this.check1 = new Check.check();
            ((System.ComponentModel.ISupportInitialize)(this.check1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_startup_step
            // 
            this.lbl_startup_step.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_startup_step.ForeColor = System.Drawing.Color.Teal;
            this.lbl_startup_step.Location = new System.Drawing.Point(3, 9);
            this.lbl_startup_step.Name = "lbl_startup_step";
            this.lbl_startup_step.Size = new System.Drawing.Size(402, 22);
            this.lbl_startup_step.TabIndex = 0;
            this.lbl_startup_step.Text = "lbl_startup_step";
            // 
            // check1
            // 
            this.check1.Image = ((System.Drawing.Image)(resources.GetObject("check1.Image")));
            this.check1.Location = new System.Drawing.Point(414, 5);
            this.check1.Name = "check1";
            this.check1.Size = new System.Drawing.Size(26, 27);
            this.check1.TabIndex = 1;
            this.check1.TabStop = false;
            this.check1.Value = false;
            // 
            // usrc_startup_step
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.check1);
            this.Controls.Add(this.lbl_startup_step);
            this.Name = "usrc_startup_step";
            this.Size = new System.Drawing.Size(447, 38);
            ((System.ComponentModel.ISupportInitialize)(this.check1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_startup_step;
        private Check.check check1;
    }
}
