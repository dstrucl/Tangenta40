namespace LanguageControl
{
    partial class Form_ltext_Edit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_ltext_Edit));
            this.dgv_Lng = new System.Windows.Forms.DataGridView();
            this.btn_OK = new System.Windows.Forms.Button();
            this.btn_Dictionary = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Lng)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_Lng
            // 
            this.dgv_Lng.AllowUserToAddRows = false;
            this.dgv_Lng.AllowUserToDeleteRows = false;
            this.dgv_Lng.AllowUserToOrderColumns = true;
            this.dgv_Lng.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_Lng.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv_Lng.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Lng.Location = new System.Drawing.Point(4, 38);
            this.dgv_Lng.Name = "dgv_Lng";
            this.dgv_Lng.Size = new System.Drawing.Size(243, 297);
            this.dgv_Lng.TabIndex = 0;
            // 
            // btn_OK
            // 
            this.btn_OK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_OK.Location = new System.Drawing.Point(78, 342);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(65, 29);
            this.btn_OK.TabIndex = 1;
            this.btn_OK.Text = "OK";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // btn_Dictionary
            // 
            this.btn_Dictionary.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Dictionary.Location = new System.Drawing.Point(31, 8);
            this.btn_Dictionary.Name = "btn_Dictionary";
            this.btn_Dictionary.Size = new System.Drawing.Size(216, 24);
            this.btn_Dictionary.TabIndex = 2;
            this.btn_Dictionary.Text = "Dictionary";
            this.btn_Dictionary.UseVisualStyleBackColor = true;
            this.btn_Dictionary.Click += new System.EventHandler(this.btn_Dictionary_Click);
            // 
            // Form_ltext_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(249, 377);
            this.Controls.Add(this.btn_Dictionary);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.dgv_Lng);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_ltext_Edit";
            this.Text = "Form_ltext_Edit";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Lng)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_Lng;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Button btn_Dictionary;
    }
}