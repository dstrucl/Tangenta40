namespace ColorSettings
{
    partial class usrc_ColorPicker
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
            this.colorEditor1 = new Cyotek.Windows.Forms.ColorEditor();
            this.colorEditorManager1 = new Cyotek.Windows.Forms.ColorEditorManager();
            this.colorWheel1 = new Cyotek.Windows.Forms.ColorWheel();
            this.screenColorPicker1 = new Cyotek.Windows.Forms.ScreenColorPicker();
            this.lbl_ColorType = new System.Windows.Forms.Label();
            this.lbl_SelectedColor = new System.Windows.Forms.Label();
            this.lightnessColorSlider = new Cyotek.Windows.Forms.LightnessColorSlider();
            this.SuspendLayout();
            // 
            // colorEditor1
            // 
            this.colorEditor1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.colorEditor1.Location = new System.Drawing.Point(13, 103);
            this.colorEditor1.Name = "colorEditor1";
            this.colorEditor1.Size = new System.Drawing.Size(214, 231);
            this.colorEditor1.TabIndex = 0;
            // 
            // colorEditorManager1
            // 
            this.colorEditorManager1.ColorEditor = this.colorEditor1;
            this.colorEditorManager1.ColorWheel = this.colorWheel1;
            this.colorEditorManager1.LightnessColorSlider = this.lightnessColorSlider;
            this.colorEditorManager1.ScreenColorPicker = this.screenColorPicker1;
            this.colorEditorManager1.ColorChanged += new System.EventHandler(this.colorEditorManager1_ColorChanged);
            // 
            // colorWheel1
            // 
            this.colorWheel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.colorWheel1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.colorWheel1.Location = new System.Drawing.Point(233, 34);
            this.colorWheel1.Name = "colorWheel1";
            this.colorWheel1.Size = new System.Drawing.Size(280, 300);
            this.colorWheel1.TabIndex = 1;
            // 
            // screenColorPicker1
            // 
            this.screenColorPicker1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.screenColorPicker1.Color = System.Drawing.Color.Empty;
            this.screenColorPicker1.Location = new System.Drawing.Point(13, 34);
            this.screenColorPicker1.Name = "screenColorPicker1";
            this.screenColorPicker1.Size = new System.Drawing.Size(214, 63);
            this.screenColorPicker1.Text = "screenColorPicker1";
            // 
            // lbl_ColorType
            // 
            this.lbl_ColorType.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_ColorType.Location = new System.Drawing.Point(10, 8);
            this.lbl_ColorType.Name = "lbl_ColorType";
            this.lbl_ColorType.Size = new System.Drawing.Size(164, 23);
            this.lbl_ColorType.TabIndex = 2;
            this.lbl_ColorType.Text = "label1";
            // 
            // lbl_SelectedColor
            // 
            this.lbl_SelectedColor.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_SelectedColor.Location = new System.Drawing.Point(180, 8);
            this.lbl_SelectedColor.Name = "lbl_SelectedColor";
            this.lbl_SelectedColor.Size = new System.Drawing.Size(142, 23);
            this.lbl_SelectedColor.TabIndex = 3;
            this.lbl_SelectedColor.Text = "SelectedColor";
            // 
            // lightnessColorSlider
            // 
            this.lightnessColorSlider.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lightnessColorSlider.Location = new System.Drawing.Point(519, 34);
            this.lightnessColorSlider.Name = "lightnessColorSlider";
            this.lightnessColorSlider.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.lightnessColorSlider.Size = new System.Drawing.Size(28, 300);
            this.lightnessColorSlider.TabIndex = 28;
            // 
            // usrc_ColorPicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.lightnessColorSlider);
            this.Controls.Add(this.lbl_SelectedColor);
            this.Controls.Add(this.lbl_ColorType);
            this.Controls.Add(this.screenColorPicker1);
            this.Controls.Add(this.colorWheel1);
            this.Controls.Add(this.colorEditor1);
            this.Name = "usrc_ColorPicker";
            this.Size = new System.Drawing.Size(564, 350);
            this.ResumeLayout(false);

        }

        #endregion

        private Cyotek.Windows.Forms.ColorEditor colorEditor1;
        private Cyotek.Windows.Forms.ColorEditorManager colorEditorManager1;
        private Cyotek.Windows.Forms.ColorWheel colorWheel1;
        private Cyotek.Windows.Forms.ScreenColorPicker screenColorPicker1;
        public System.Windows.Forms.Label lbl_ColorType;
        public System.Windows.Forms.Label lbl_SelectedColor;
        private Cyotek.Windows.Forms.LightnessColorSlider lightnessColorSlider;
    }
}
