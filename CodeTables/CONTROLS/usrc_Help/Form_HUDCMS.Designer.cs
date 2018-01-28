namespace HUDCMS
{
    partial class Form_HUDCMS
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
            this.pic_Form = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Form)).BeginInit();
            this.SuspendLayout();
            // 
            // pic_Form
            // 
            this.pic_Form.Location = new System.Drawing.Point(12, 12);
            this.pic_Form.Name = "pic_Form";
            this.pic_Form.Size = new System.Drawing.Size(285, 258);
            this.pic_Form.TabIndex = 0;
            this.pic_Form.TabStop = false;
            // 
            // Form_HUDCMS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(806, 662);
            this.Controls.Add(this.pic_Form);
            this.Name = "Form_HUDCMS";
            this.Text = "Form_HUDCMS";
            ((System.ComponentModel.ISupportInitialize)(this.pic_Form)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pic_Form;
    }
}