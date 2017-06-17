namespace TestEWSList
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.multiColumnComboBox1 = new EWSoftware.ListControls.MultiColumnComboBox();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.btnGetValue = new System.Windows.Forms.Button();
            this.txtRowNumber = new System.Windows.Forms.NumericUpDown();
            this.ilImages = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.multiColumnComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRowNumber)).BeginInit();
            this.SuspendLayout();
            // 
            // multiColumnComboBox1
            // 
            this.multiColumnComboBox1.DropDownFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.multiColumnComboBox1.Location = new System.Drawing.Point(126, 58);
            this.multiColumnComboBox1.Name = "multiColumnComboBox1";
            this.multiColumnComboBox1.Size = new System.Drawing.Size(312, 21);
            this.multiColumnComboBox1.TabIndex = 0;
            this.multiColumnComboBox1.Text = "multiColumnComboBox1";
            this.multiColumnComboBox1.DrawItemImage += new System.Windows.Forms.DrawItemEventHandler(this.multiColumnComboBox1_DrawItemImage);
            this.multiColumnComboBox1.SelectedIndexChanged += new System.EventHandler(this.multiColumnComboBox1_SelectedIndexChanged);
            // 
            // txtValue
            // 
            this.txtValue.Location = new System.Drawing.Point(163, 132);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(357, 20);
            this.txtValue.TabIndex = 1;
            // 
            // btnGetValue
            // 
            this.btnGetValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnGetValue.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnGetValue.Location = new System.Drawing.Point(321, 167);
            this.btnGetValue.Name = "btnGetValue";
            this.btnGetValue.Size = new System.Drawing.Size(75, 28);
            this.btnGetValue.TabIndex = 8;
            this.btnGetValue.Text = "&Get";
            this.btnGetValue.Click += new System.EventHandler(this.btnGetValue_Click);
            // 
            // txtRowNumber
            // 
            this.txtRowNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtRowNumber.Location = new System.Drawing.Point(216, 167);
            this.txtRowNumber.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.txtRowNumber.Name = "txtRowNumber";
            this.txtRowNumber.Size = new System.Drawing.Size(56, 20);
            this.txtRowNumber.TabIndex = 9;
            this.txtRowNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ilImages
            // 
            this.ilImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilImages.ImageStream")));
            this.ilImages.TransparentColor = System.Drawing.Color.Magenta;
            this.ilImages.Images.SetKeyName(0, "Audio.bmp");
            this.ilImages.Images.SetKeyName(1, "Bitmap.bmp");
            this.ilImages.Images.SetKeyName(2, "Disk.bmp");
            this.ilImages.Images.SetKeyName(3, "Folder.bmp");
            this.ilImages.Images.SetKeyName(4, "Waste.bmp");
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(717, 362);
            this.Controls.Add(this.txtRowNumber);
            this.Controls.Add(this.btnGetValue);
            this.Controls.Add(this.txtValue);
            this.Controls.Add(this.multiColumnComboBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.multiColumnComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRowNumber)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private EWSoftware.ListControls.MultiColumnComboBox multiColumnComboBox1;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.Button btnGetValue;
        private System.Windows.Forms.NumericUpDown txtRowNumber;
        private System.Windows.Forms.ImageList ilImages;
    }
}

