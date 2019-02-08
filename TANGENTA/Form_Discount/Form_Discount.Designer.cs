namespace Form_Discount
{
    partial class Form_Discount
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Discount));
            this.rdb_0 = new System.Windows.Forms.RadioButton();
            this.rdb_2 = new System.Windows.Forms.RadioButton();
            this.rdb_3 = new System.Windows.Forms.RadioButton();
            this.rdb_5 = new System.Windows.Forms.RadioButton();
            this.rdb_7 = new System.Windows.Forms.RadioButton();
            this.nm_UpDown_Discount = new System.Windows.Forms.NumericUpDown();
            this.rdb_Custom = new System.Windows.Forms.RadioButton();
            this.rdb_EndPrice = new System.Windows.Forms.RadioButton();
            this.nm_UpDown_EndPrice = new System.Windows.Forms.NumericUpDown();
            this.rdb_10 = new System.Windows.Forms.RadioButton();
            this.rdb_15 = new System.Windows.Forms.RadioButton();
            this.rdb_20 = new System.Windows.Forms.RadioButton();
            this.btn_OK = new System.Windows.Forms.Button();
            this.btn_PurchasePriceInfo = new System.Windows.Forms.Button();
            this.usrc_Help1 = new HUDCMS.usrc_Help();
            ((System.ComponentModel.ISupportInitialize)(this.nm_UpDown_Discount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nm_UpDown_EndPrice)).BeginInit();
            this.SuspendLayout();
            // 
            // rdb_0
            // 
            this.rdb_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rdb_0.Location = new System.Drawing.Point(12, 12);
            this.rdb_0.Name = "rdb_0";
            this.rdb_0.Size = new System.Drawing.Size(143, 54);
            this.rdb_0.TabIndex = 0;
            this.rdb_0.TabStop = true;
            this.rdb_0.Text = "0%";
            this.rdb_0.UseVisualStyleBackColor = true;
            // 
            // rdb_2
            // 
            this.rdb_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rdb_2.Location = new System.Drawing.Point(12, 78);
            this.rdb_2.Name = "rdb_2";
            this.rdb_2.Size = new System.Drawing.Size(155, 54);
            this.rdb_2.TabIndex = 1;
            this.rdb_2.TabStop = true;
            this.rdb_2.Text = "2%";
            this.rdb_2.UseVisualStyleBackColor = true;
            // 
            // rdb_3
            // 
            this.rdb_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rdb_3.Location = new System.Drawing.Point(12, 144);
            this.rdb_3.Name = "rdb_3";
            this.rdb_3.Size = new System.Drawing.Size(155, 54);
            this.rdb_3.TabIndex = 2;
            this.rdb_3.TabStop = true;
            this.rdb_3.Text = "3%";
            this.rdb_3.UseVisualStyleBackColor = true;
            // 
            // rdb_5
            // 
            this.rdb_5.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rdb_5.Location = new System.Drawing.Point(12, 210);
            this.rdb_5.Name = "rdb_5";
            this.rdb_5.Size = new System.Drawing.Size(169, 54);
            this.rdb_5.TabIndex = 3;
            this.rdb_5.TabStop = true;
            this.rdb_5.Text = "5%";
            this.rdb_5.UseVisualStyleBackColor = true;
            // 
            // rdb_7
            // 
            this.rdb_7.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rdb_7.Location = new System.Drawing.Point(219, 12);
            this.rdb_7.Name = "rdb_7";
            this.rdb_7.Size = new System.Drawing.Size(155, 54);
            this.rdb_7.TabIndex = 4;
            this.rdb_7.TabStop = true;
            this.rdb_7.Text = "7%";
            this.rdb_7.UseVisualStyleBackColor = true;
            // 
            // nm_UpDown_Discount
            // 
            this.nm_UpDown_Discount.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.nm_UpDown_Discount.Location = new System.Drawing.Point(223, 284);
            this.nm_UpDown_Discount.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.nm_UpDown_Discount.Name = "nm_UpDown_Discount";
            this.nm_UpDown_Discount.Size = new System.Drawing.Size(222, 62);
            this.nm_UpDown_Discount.TabIndex = 9;
            this.nm_UpDown_Discount.ThousandsSeparator = true;
            this.nm_UpDown_Discount.ValueChanged += new System.EventHandler(this.nm_UpDown_Discount_ValueChanged_1);
            // 
            // rdb_Custom
            // 
            this.rdb_Custom.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rdb_Custom.Location = new System.Drawing.Point(12, 288);
            this.rdb_Custom.Name = "rdb_Custom";
            this.rdb_Custom.Size = new System.Drawing.Size(205, 54);
            this.rdb_Custom.TabIndex = 8;
            this.rdb_Custom.TabStop = true;
            this.rdb_Custom.Text = "20%";
            this.rdb_Custom.UseVisualStyleBackColor = true;
            // 
            // rdb_EndPrice
            // 
            this.rdb_EndPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rdb_EndPrice.Location = new System.Drawing.Point(12, 360);
            this.rdb_EndPrice.Name = "rdb_EndPrice";
            this.rdb_EndPrice.Size = new System.Drawing.Size(514, 54);
            this.rdb_EndPrice.TabIndex = 10;
            this.rdb_EndPrice.TabStop = true;
            this.rdb_EndPrice.Text = "20%";
            this.rdb_EndPrice.UseVisualStyleBackColor = true;
            // 
            // nm_UpDown_EndPrice
            // 
            this.nm_UpDown_EndPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.nm_UpDown_EndPrice.Location = new System.Drawing.Point(219, 414);
            this.nm_UpDown_EndPrice.Maximum = new decimal(new int[] {
            276447232,
            23283,
            0,
            0});
            this.nm_UpDown_EndPrice.Name = "nm_UpDown_EndPrice";
            this.nm_UpDown_EndPrice.Size = new System.Drawing.Size(222, 62);
            this.nm_UpDown_EndPrice.TabIndex = 11;
            this.nm_UpDown_EndPrice.ThousandsSeparator = true;
            // 
            // rdb_10
            // 
            this.rdb_10.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rdb_10.Location = new System.Drawing.Point(219, 78);
            this.rdb_10.Name = "rdb_10";
            this.rdb_10.Size = new System.Drawing.Size(155, 54);
            this.rdb_10.TabIndex = 5;
            this.rdb_10.TabStop = true;
            this.rdb_10.Text = "10%";
            this.rdb_10.UseVisualStyleBackColor = true;
            // 
            // rdb_15
            // 
            this.rdb_15.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rdb_15.Location = new System.Drawing.Point(219, 144);
            this.rdb_15.Name = "rdb_15";
            this.rdb_15.Size = new System.Drawing.Size(143, 54);
            this.rdb_15.TabIndex = 6;
            this.rdb_15.TabStop = true;
            this.rdb_15.Text = "15%";
            this.rdb_15.UseVisualStyleBackColor = true;
            // 
            // rdb_20
            // 
            this.rdb_20.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rdb_20.Location = new System.Drawing.Point(219, 210);
            this.rdb_20.Name = "rdb_20";
            this.rdb_20.Size = new System.Drawing.Size(143, 54);
            this.rdb_20.TabIndex = 7;
            this.rdb_20.TabStop = true;
            this.rdb_20.Text = "20%";
            this.rdb_20.UseVisualStyleBackColor = true;
            // 
            // btn_OK
            // 
            this.btn_OK.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_OK.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_OK.Location = new System.Drawing.Point(223, 482);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(171, 57);
            this.btn_OK.TabIndex = 12;
            this.btn_OK.Text = "OK";
            this.btn_OK.UseVisualStyleBackColor = false;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // btn_PurchasePriceInfo
            // 
            this.btn_PurchasePriceInfo.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_PurchasePriceInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_PurchasePriceInfo.Location = new System.Drawing.Point(386, 61);
            this.btn_PurchasePriceInfo.Name = "btn_PurchasePriceInfo";
            this.btn_PurchasePriceInfo.Size = new System.Drawing.Size(222, 83);
            this.btn_PurchasePriceInfo.TabIndex = 13;
            this.btn_PurchasePriceInfo.Text = "PurchasePriceInfo";
            this.btn_PurchasePriceInfo.UseVisualStyleBackColor = false;
            this.btn_PurchasePriceInfo.Click += new System.EventHandler(this.btn_PurchasePriceInfo_Click);
            // 
            // usrc_Help1
            // 
            this.usrc_Help1.Location = new System.Drawing.Point(550, 12);
            this.usrc_Help1.Name = "usrc_Help1";
            this.usrc_Help1.Size = new System.Drawing.Size(58, 32);
            this.usrc_Help1.TabIndex = 14;
            // 
            // Form_Discount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(620, 551);
            this.Controls.Add(this.usrc_Help1);
            this.Controls.Add(this.btn_PurchasePriceInfo);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.rdb_20);
            this.Controls.Add(this.rdb_10);
            this.Controls.Add(this.rdb_15);
            this.Controls.Add(this.nm_UpDown_EndPrice);
            this.Controls.Add(this.rdb_EndPrice);
            this.Controls.Add(this.rdb_Custom);
            this.Controls.Add(this.nm_UpDown_Discount);
            this.Controls.Add(this.rdb_7);
            this.Controls.Add(this.rdb_5);
            this.Controls.Add(this.rdb_3);
            this.Controls.Add(this.rdb_2);
            this.Controls.Add(this.rdb_0);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_Discount";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.nm_UpDown_Discount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nm_UpDown_EndPrice)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton rdb_0;
        private System.Windows.Forms.RadioButton rdb_2;
        private System.Windows.Forms.RadioButton rdb_3;
        private System.Windows.Forms.RadioButton rdb_5;
        private System.Windows.Forms.RadioButton rdb_7;
        private System.Windows.Forms.NumericUpDown nm_UpDown_Discount;
        private System.Windows.Forms.RadioButton rdb_Custom;
        private System.Windows.Forms.RadioButton rdb_EndPrice;
        private System.Windows.Forms.NumericUpDown nm_UpDown_EndPrice;
        private System.Windows.Forms.RadioButton rdb_10;
        private System.Windows.Forms.RadioButton rdb_15;
        private System.Windows.Forms.RadioButton rdb_20;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Button btn_PurchasePriceInfo;
        private HUDCMS.usrc_Help usrc_Help1;
    }
}