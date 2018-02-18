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
            this.lbl_startup_step.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lbl_startup_step.Location = new System.Drawing.Point(2, 7);
            this.lbl_startup_step.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_startup_step.Name = "lbl_startup_step";
            this.lbl_startup_step.Size = new System.Drawing.Size(302, 18);
            this.lbl_startup_step.TabIndex = 0;
            this.lbl_startup_step.Text = "lbl_startup_step";
            // 
            // check1
            // 
            this.check1.Image = ((System.Drawing.Image)(resources.GetObject("check1.Image")));
            this.check1.Location = new System.Drawing.Point(310, 4);
            this.check1.Margin = new System.Windows.Forms.Padding(2);
            this.check1.Name = "check1";
            this.check1.Size = new System.Drawing.Size(20, 22);
            this.check1.State = Check.check.eState.UNDEFINED;
            this.check1.TabIndex = 1;
            this.check1.TabStop = false;
            // 
            // usrc_startup_step
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.check1);
            this.Controls.Add(this.lbl_startup_step);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "usrc_startup_step";
            this.Size = new System.Drawing.Size(335, 31);
            ((System.ComponentModel.ISupportInitialize)(this.check1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_startup_step;
        internal Check.check check1;
    }
}
