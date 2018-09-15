namespace PriseLists
{
    partial class usrc_PriceList
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
            this.lbl_PriceList = new System.Windows.Forms.Label();
            this.cmb_PriceListType = new System.Windows.Forms.ComboBox();
            this.btn_PriceListType = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_PriceList
            // 
            this.lbl_PriceList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_PriceList.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_PriceList.Location = new System.Drawing.Point(2, 1);
            this.lbl_PriceList.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_PriceList.Name = "lbl_PriceList";
            this.lbl_PriceList.Size = new System.Drawing.Size(78, 17);
            this.lbl_PriceList.TabIndex = 33;
            this.lbl_PriceList.Text = "Cenik:";
            this.lbl_PriceList.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmb_PriceListType
            // 
            this.cmb_PriceListType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmb_PriceListType.Font = new System.Drawing.Font("Miriam CLM", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.cmb_PriceListType.FormattingEnabled = true;
            this.cmb_PriceListType.Location = new System.Drawing.Point(113, 0);
            this.cmb_PriceListType.Name = "cmb_PriceListType";
            this.cmb_PriceListType.Size = new System.Drawing.Size(164, 20);
            this.cmb_PriceListType.TabIndex = 34;
            // 
            // btn_PriceListType
            // 
            this.btn_PriceListType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_PriceListType.Image = global::PriseLists.Properties.Resources.Edit;
            this.btn_PriceListType.Location = new System.Drawing.Point(80, -1);
            this.btn_PriceListType.Name = "btn_PriceListType";
            this.btn_PriceListType.Size = new System.Drawing.Size(29, 21);
            this.btn_PriceListType.TabIndex = 32;
            this.btn_PriceListType.UseVisualStyleBackColor = true;
            this.btn_PriceListType.Click += new System.EventHandler(this.btn_PriceListType_Click);
            // 
            // usrc_PriceList
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Controls.Add(this.lbl_PriceList);
            this.Controls.Add(this.cmb_PriceListType);
            this.Controls.Add(this.btn_PriceListType);
            this.Name = "usrc_PriceList";
            this.Size = new System.Drawing.Size(278, 20);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_PriceList;
        private System.Windows.Forms.Button btn_PriceListType;
        public System.Windows.Forms.ComboBox cmb_PriceListType;
    }
}
