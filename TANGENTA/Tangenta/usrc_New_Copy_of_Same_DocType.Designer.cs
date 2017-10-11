namespace Tangenta
{
    partial class usrc_New_Copy_of_Same_DocType
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
            this.btn_New_Copy_Of_SameDocType = new System.Windows.Forms.Button();
            this.lbl_FinancialYear = new System.Windows.Forms.Label();
            this.cmb_FinancialYear = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btn_New_Copy_Of_SameDocType
            // 
            this.btn_New_Copy_Of_SameDocType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_New_Copy_Of_SameDocType.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_New_Copy_Of_SameDocType.Location = new System.Drawing.Point(1, 2);
            this.btn_New_Copy_Of_SameDocType.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_New_Copy_Of_SameDocType.Name = "btn_New_Copy_Of_SameDocType";
            this.btn_New_Copy_Of_SameDocType.Size = new System.Drawing.Size(580, 121);
            this.btn_New_Copy_Of_SameDocType.TabIndex = 2;
            this.btn_New_Copy_Of_SameDocType.Text = "btn_New_Copy_Of_SameDocType";
            this.btn_New_Copy_Of_SameDocType.UseVisualStyleBackColor = true;
            this.btn_New_Copy_Of_SameDocType.Click += new System.EventHandler(this.btn_New_Copy_Of_SameDocType_Click);
            // 
            // lbl_FinancialYear
            // 
            this.lbl_FinancialYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lbl_FinancialYear.Location = new System.Drawing.Point(4, 129);
            this.lbl_FinancialYear.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_FinancialYear.Name = "lbl_FinancialYear";
            this.lbl_FinancialYear.Size = new System.Drawing.Size(195, 25);
            this.lbl_FinancialYear.TabIndex = 30;
            this.lbl_FinancialYear.Text = "Leto";
            this.lbl_FinancialYear.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmb_FinancialYear
            // 
            this.cmb_FinancialYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cmb_FinancialYear.FormattingEnabled = true;
            this.cmb_FinancialYear.Location = new System.Drawing.Point(209, 124);
            this.cmb_FinancialYear.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmb_FinancialYear.Name = "cmb_FinancialYear";
            this.cmb_FinancialYear.Size = new System.Drawing.Size(152, 33);
            this.cmb_FinancialYear.TabIndex = 29;
            this.cmb_FinancialYear.SelectedIndexChanged += new System.EventHandler(this.cmb_FinancialYear_SelectedIndexChanged);
            // 
            // usrc_New_Copy_of_Same_DocType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.lbl_FinancialYear);
            this.Controls.Add(this.cmb_FinancialYear);
            this.Controls.Add(this.btn_New_Copy_Of_SameDocType);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "usrc_New_Copy_of_Same_DocType";
            this.Size = new System.Drawing.Size(583, 162);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_New_Copy_Of_SameDocType;
        private System.Windows.Forms.Label lbl_FinancialYear;
        private System.Windows.Forms.ComboBox cmb_FinancialYear;
    }
}
