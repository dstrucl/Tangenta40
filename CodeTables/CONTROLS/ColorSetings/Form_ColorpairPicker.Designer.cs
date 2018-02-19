namespace ColorSettings
{
    partial class Form_ColorpairPicker
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_ColorpairPicker));
            this.lbl_ColorText1 = new System.Windows.Forms.Label();
            this.btn_OK = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.usrc_Help1 = new HUDCMS.usrc_Help();
            this.usrc_ColorPicker_BackColor = new ColorSettings.usrc_ColorPicker();
            this.usrc_ColorPicker_ForeColor = new ColorSettings.usrc_ColorPicker();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_ColorText1
            // 
            this.lbl_ColorText1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.lbl_ColorText1.Location = new System.Drawing.Point(3, 38);
            this.lbl_ColorText1.Name = "lbl_ColorText1";
            this.lbl_ColorText1.Size = new System.Drawing.Size(217, 25);
            this.lbl_ColorText1.TabIndex = 0;
            this.lbl_ColorText1.Text = "label1";
            this.lbl_ColorText1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_OK
            // 
            this.btn_OK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_OK.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_OK.Location = new System.Drawing.Point(619, 2);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(96, 31);
            this.btn_OK.TabIndex = 8;
            this.btn_OK.Text = "OK";
            this.btn_OK.UseVisualStyleBackColor = false;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Cancel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_Cancel.Location = new System.Drawing.Point(721, 2);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(96, 31);
            this.btn_Cancel.TabIndex = 9;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = false;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // usrc_Help1
            // 
            this.usrc_Help1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.usrc_Help1.Location = new System.Drawing.Point(823, 2);
            this.usrc_Help1.Name = "usrc_Help1";
            this.usrc_Help1.Size = new System.Drawing.Size(59, 30);
            this.usrc_Help1.TabIndex = 10;
            // 
            // usrc_ColorPicker_BackColor
            // 
            this.usrc_ColorPicker_BackColor.AutoScroll = true;
            this.usrc_ColorPicker_BackColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.usrc_ColorPicker_BackColor.ColorPickerType = "";
            this.usrc_ColorPicker_BackColor.ColorSelected = System.Drawing.Color.White;
            this.usrc_ColorPicker_BackColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.usrc_ColorPicker_BackColor.Location = new System.Drawing.Point(0, 0);
            this.usrc_ColorPicker_BackColor.Name = "usrc_ColorPicker_BackColor";
            this.usrc_ColorPicker_BackColor.Size = new System.Drawing.Size(648, 352);
            this.usrc_ColorPicker_BackColor.TabIndex = 7;
            this.usrc_ColorPicker_BackColor.ColorChanged += new ColorSettings.usrc_ColorPicker.delegate_ColorChanged(this.usrc_ColorPicker_BackColor_ColorChanged);
            // 
            // usrc_ColorPicker_ForeColor
            // 
            this.usrc_ColorPicker_ForeColor.AutoScroll = true;
            this.usrc_ColorPicker_ForeColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.usrc_ColorPicker_ForeColor.ColorPickerType = "";
            this.usrc_ColorPicker_ForeColor.ColorSelected = System.Drawing.Color.White;
            this.usrc_ColorPicker_ForeColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.usrc_ColorPicker_ForeColor.Location = new System.Drawing.Point(0, 0);
            this.usrc_ColorPicker_ForeColor.Name = "usrc_ColorPicker_ForeColor";
            this.usrc_ColorPicker_ForeColor.Size = new System.Drawing.Size(648, 317);
            this.usrc_ColorPicker_ForeColor.TabIndex = 6;
            this.usrc_ColorPicker_ForeColor.ColorChanged += new ColorSettings.usrc_ColorPicker.delegate_ColorChanged(this.usrc_ColorPicker_ForeColor_ColorChanged);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Location = new System.Drawing.Point(233, 38);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.usrc_ColorPicker_ForeColor);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.usrc_ColorPicker_BackColor);
            this.splitContainer1.Size = new System.Drawing.Size(650, 679);
            this.splitContainer1.SplitterDistance = 319;
            this.splitContainer1.SplitterWidth = 6;
            this.splitContainer1.TabIndex = 11;
            // 
            // Form_ColorpairPicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(886, 719);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.usrc_Help1);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.lbl_ColorText1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_ColorpairPicker";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form_ColorpairPicker";
            this.Load += new System.EventHandler(this.Form_ColorpairPicker_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_ColorText1;
        private usrc_ColorPicker usrc_ColorPicker_ForeColor;
        private usrc_ColorPicker usrc_ColorPicker_BackColor;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Button btn_Cancel;
        private HUDCMS.usrc_Help usrc_Help1;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}