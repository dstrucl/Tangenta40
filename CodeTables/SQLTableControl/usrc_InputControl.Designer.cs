namespace CodeTables
{
    partial class usrc_InputControl
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
            this.usrc_lbl = new CodeTables.usrc_InputControl_Label();
            this.pic_Changed = new PictureBoxChanged();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Changed)).BeginInit();
            this.SuspendLayout();
            // 
            // usrc_lbl
            // 
            this.usrc_lbl.AutoSize = true;
            this.usrc_lbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.usrc_lbl.Location = new System.Drawing.Point(13, 3);
            this.usrc_lbl.Name = "usrc_lbl";
            this.usrc_lbl.Size = new System.Drawing.Size(151, 23);
            this.usrc_lbl.TabIndex = 0;
            // 
            // pic_Changed
            // 
            this.pic_Changed.Image = global::CodeTables.Properties.Resources.ObjectChanged;
            this.pic_Changed.Location = new System.Drawing.Point(0, 6);
            this.pic_Changed.Name = "pic_Changed";
            this.pic_Changed.Size = new System.Drawing.Size(12, 16);
            this.pic_Changed.TabIndex = 1;
            this.pic_Changed.TabStop = false;
            // 
            // usrc_InputControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lime;
            this.Controls.Add(this.pic_Changed);
            this.Controls.Add(this.usrc_lbl);
            this.Name = "usrc_InputControl";
            this.Size = new System.Drawing.Size(481, 29);
            ((System.ComponentModel.ISupportInitialize)(this.pic_Changed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public usrc_InputControl_Label usrc_lbl;
        private PictureBoxChanged pic_Changed;


    }
}
