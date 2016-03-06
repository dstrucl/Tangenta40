namespace CodeTables
{
    partial class VirtualSecretary_Form
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
            this.btnStartPause = new System.Windows.Forms.Button();
            this.pictureBox_Secretary = new System.Windows.Forms.PictureBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lbl_NumberOfEntries = new System.Windows.Forms.Label();
            this.nmUpDown_Entries = new System.Windows.Forms.NumericUpDown();
            this.btnSettings = new System.Windows.Forms.Button();
            this.timer_EnterData = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Secretary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmUpDown_Entries)).BeginInit();
            this.SuspendLayout();
            // 
            // btnStartPause
            // 
            this.btnStartPause.Font = new System.Drawing.Font("Courier New", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartPause.Location = new System.Drawing.Point(12, 52);
            this.btnStartPause.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnStartPause.Name = "btnStartPause";
            this.btnStartPause.Size = new System.Drawing.Size(96, 28);
            this.btnStartPause.TabIndex = 1;
            this.btnStartPause.Text = "button1";
            this.btnStartPause.UseVisualStyleBackColor = true;
            this.btnStartPause.Click += new System.EventHandler(this.btnStartPause_Click);
            // 
            // pictureBox_Secretary
            // 
            this.pictureBox_Secretary.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox_Secretary.Image = global::CodeTables.Properties.Resources.JimCarreyWaits2;
            this.pictureBox_Secretary.Location = new System.Drawing.Point(-1, 0);
            this.pictureBox_Secretary.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox_Secretary.Name = "pictureBox_Secretary";
            this.pictureBox_Secretary.Size = new System.Drawing.Size(741, 468);
            this.pictureBox_Secretary.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_Secretary.TabIndex = 0;
            this.pictureBox_Secretary.TabStop = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Font = new System.Drawing.Font("Courier New", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(636, 427);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(93, 26);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "button2";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lbl_NumberOfEntries
            // 
            this.lbl_NumberOfEntries.AutoSize = true;
            this.lbl_NumberOfEntries.Font = new System.Drawing.Font("Courier New", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_NumberOfEntries.Location = new System.Drawing.Point(12, 11);
            this.lbl_NumberOfEntries.Name = "lbl_NumberOfEntries";
            this.lbl_NumberOfEntries.Size = new System.Drawing.Size(149, 20);
            this.lbl_NumberOfEntries.TabIndex = 3;
            this.lbl_NumberOfEntries.Text = "Število Vnosov";
            // 
            // nmUpDown_Entries
            // 
            this.nmUpDown_Entries.Font = new System.Drawing.Font("Courier New", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nmUpDown_Entries.Location = new System.Drawing.Point(167, 9);
            this.nmUpDown_Entries.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nmUpDown_Entries.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nmUpDown_Entries.Name = "nmUpDown_Entries";
            this.nmUpDown_Entries.Size = new System.Drawing.Size(191, 27);
            this.nmUpDown_Entries.TabIndex = 4;
            this.nmUpDown_Entries.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnSettings
            // 
            this.btnSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSettings.AutoSize = true;
            this.btnSettings.Font = new System.Drawing.Font("Courier New", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSettings.Location = new System.Drawing.Point(578, 9);
            this.btnSettings.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(151, 30);
            this.btnSettings.TabIndex = 5;
            this.btnSettings.Text = "button1";
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // timer_EnterData
            // 
            this.timer_EnterData.Interval = 2;
            this.timer_EnterData.Tick += new System.EventHandler(this.timer_EnterData_Tick);
            // 
            // VirtualSecretary_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(741, 465);
            this.Controls.Add(this.btnSettings);
            this.Controls.Add(this.nmUpDown_Entries);
            this.Controls.Add(this.lbl_NumberOfEntries);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnStartPause);
            this.Controls.Add(this.pictureBox_Secretary);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "VirtualSecretary_Form";
            this.Text = "VirtualSecretary_Form";
            this.Load += new System.EventHandler(this.VirtualSecretary_Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Secretary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmUpDown_Entries)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_Secretary;
        private System.Windows.Forms.Button btnStartPause;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lbl_NumberOfEntries;
        private System.Windows.Forms.NumericUpDown nmUpDown_Entries;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Timer timer_EnterData;
    }
}