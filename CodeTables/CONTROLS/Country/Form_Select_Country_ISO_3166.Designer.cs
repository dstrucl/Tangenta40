namespace Country_ISO_3166
{
    partial class Form_Select_Country_ISO_3166
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Select_Country_ISO_3166));
            this.dgvx_ISO_3166 = new DataGridView_2xls.DataGridView2xls();
            this.btn_OK = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.txt_SelectCountry = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvx_ISO_3166)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvx_ISO_3166
            // 
            this.dgvx_ISO_3166.AllowUserToAddRows = false;
            this.dgvx_ISO_3166.AllowUserToDeleteRows = false;
            this.dgvx_ISO_3166.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvx_ISO_3166.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvx_ISO_3166.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvx_ISO_3166.DataGridViewWithRowNumber = false;
            this.dgvx_ISO_3166.Location = new System.Drawing.Point(3, 36);
            this.dgvx_ISO_3166.MultiSelect = false;
            this.dgvx_ISO_3166.Name = "dgvx_ISO_3166";
            this.dgvx_ISO_3166.ReadOnly = true;
            this.dgvx_ISO_3166.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvx_ISO_3166.Size = new System.Drawing.Size(347, 453);
            this.dgvx_ISO_3166.TabIndex = 0;
            // 
            // btn_OK
            // 
            this.btn_OK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_OK.Location = new System.Drawing.Point(5, 495);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(51, 29);
            this.btn_OK.TabIndex = 1;
            this.btn_OK.Text = "OK";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Cancel.Location = new System.Drawing.Point(240, 495);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(72, 29);
            this.btn_Cancel.TabIndex = 2;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // txt_SelectCountry
            // 
            this.txt_SelectCountry.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_SelectCountry.Location = new System.Drawing.Point(5, 8);
            this.txt_SelectCountry.Name = "txt_SelectCountry";
            this.txt_SelectCountry.Size = new System.Drawing.Size(345, 22);
            this.txt_SelectCountry.TabIndex = 3;
            this.txt_SelectCountry.TextChanged += new System.EventHandler(this.txt_SelectCountry_TextChanged);
            // 
            // Form_Select_Country_ISO_3166
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 533);
            this.Controls.Add(this.txt_SelectCountry);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.dgvx_ISO_3166);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_Select_Country_ISO_3166";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form_Select_Country_ISO_3166";
            this.Load += new System.EventHandler(this.Form_Select_Country_ISO_3166_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvx_ISO_3166)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridView_2xls.DataGridView2xls dgvx_ISO_3166;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.TextBox txt_SelectCountry;
    }
}