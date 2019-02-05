namespace ColorSettings
{
    partial class Form_ColorPicker
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_ColorPicker));
            this.btn_OK = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.usrc_Help1 = new HUDCMS.usrc_Help();
            this.lbl_ColorText1 = new System.Windows.Forms.Label();
            this.usrc_ColorPicker = new ColorSettings.usrc_ColorPicker();
            this.lbl_Control = new System.Windows.Forms.Label();
            this.txt_ControlName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btn_OK
            // 
            this.btn_OK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_OK.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_OK.Location = new System.Drawing.Point(545, 2);
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
            this.btn_Cancel.Location = new System.Drawing.Point(647, 2);
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
            this.usrc_Help1.Location = new System.Drawing.Point(749, 2);
            this.usrc_Help1.Name = "usrc_Help1";
            this.usrc_Help1.Size = new System.Drawing.Size(59, 30);
            this.usrc_Help1.TabIndex = 10;
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
            // usrc_ColorPicker
            // 
            this.usrc_ColorPicker.AutoScroll = true;
            this.usrc_ColorPicker.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.usrc_ColorPicker.ColorPickerType = "";
            this.usrc_ColorPicker.Location = new System.Drawing.Point(236, 38);
            this.usrc_ColorPicker.Name = "usrc_ColorPicker";
            this.usrc_ColorPicker.Size = new System.Drawing.Size(570, 317);
            this.usrc_ColorPicker.TabIndex = 6;
            this.usrc_ColorPicker.ColorChanged += new ColorSettings.usrc_ColorPicker.delegate_ColorChanged(this.usrc_ColorPicker_ColorChanged);
            // 
            // lbl_Control
            // 
            this.lbl_Control.AutoSize = true;
            this.lbl_Control.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Control.Location = new System.Drawing.Point(11, 9);
            this.lbl_Control.Name = "lbl_Control";
            this.lbl_Control.Size = new System.Drawing.Size(60, 20);
            this.lbl_Control.TabIndex = 14;
            this.lbl_Control.Text = "Control";
            // 
            // txt_ControlName
            // 
            this.txt_ControlName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_ControlName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ControlName.Location = new System.Drawing.Point(91, 6);
            this.txt_ControlName.Name = "txt_ControlName";
            this.txt_ControlName.ReadOnly = true;
            this.txt_ControlName.Size = new System.Drawing.Size(448, 26);
            this.txt_ControlName.TabIndex = 15;
            // 
            // Form_ColorPicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(812, 367);
            this.Controls.Add(this.txt_ControlName);
            this.Controls.Add(this.lbl_Control);
            this.Controls.Add(this.usrc_ColorPicker);
            this.Controls.Add(this.usrc_Help1);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.lbl_ColorText1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_ColorPicker";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form_ColorpairPicker";
            this.Load += new System.EventHandler(this.Form_ColorpairPicker_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Button btn_Cancel;
        private HUDCMS.usrc_Help usrc_Help1;
        private System.Windows.Forms.Label lbl_ColorText1;
        private usrc_ColorPicker usrc_ColorPicker;
        private System.Windows.Forms.Label lbl_Control;
        private System.Windows.Forms.TextBox txt_ControlName;
    }
}