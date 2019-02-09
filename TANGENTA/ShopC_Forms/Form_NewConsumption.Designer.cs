namespace ShopC_Forms
{
    partial class Form_NewConsumption
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_NewConsumption));
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.usrc_Help1 = new HUDCMS.usrc_Help();
            this.dgvx_ConsumptionType = new DataGridView_2xls.DataGridView2xls();
            ((System.ComponentModel.ISupportInitialize)(this.dgvx_ConsumptionType)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_Cancel.Image = ((System.Drawing.Image)(resources.GetObject("btn_Cancel.Image")));
            this.btn_Cancel.Location = new System.Drawing.Point(160, 365);
            this.btn_Cancel.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(73, 29);
            this.btn_Cancel.TabIndex = 36;
            this.btn_Cancel.UseVisualStyleBackColor = false;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // usrc_Help1
            // 
            this.usrc_Help1.Location = new System.Drawing.Point(371, 5);
            this.usrc_Help1.Name = "usrc_Help1";
            this.usrc_Help1.Size = new System.Drawing.Size(42, 25);
            this.usrc_Help1.TabIndex = 40;
            // 
            // dgvx_ConsumptionType
            // 
            this.dgvx_ConsumptionType.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvx_ConsumptionType.DataGridViewWithRowNumber = false;
            this.dgvx_ConsumptionType.Location = new System.Drawing.Point(12, 67);
            this.dgvx_ConsumptionType.Name = "dgvx_ConsumptionType";
            this.dgvx_ConsumptionType.Size = new System.Drawing.Size(394, 268);
            this.dgvx_ConsumptionType.TabIndex = 41;
            // 
            // Form_NewConsumption
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(418, 405);
            this.Controls.Add(this.dgvx_ConsumptionType);
            this.Controls.Add(this.usrc_Help1);
            this.Controls.Add(this.btn_Cancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form_NewConsumption";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Form_NewConsumption_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvx_ConsumptionType)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btn_Cancel;
        private HUDCMS.usrc_Help usrc_Help1;
        private DataGridView_2xls.DataGridView2xls dgvx_ConsumptionType;
    }
}