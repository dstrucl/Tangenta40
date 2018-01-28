namespace PriseLists
{
    partial class Form_PriceList_NotComplete
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_PriceList_NotComplete));
            this.btn_OK = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.dgvx_Item_Not_in_Pricelist = new DataGridView_2xls.DataGridView2xls();
            this.lbl_Item_Not_in_PriceList = new System.Windows.Forms.Label();
            this.usrc_Help1 = new HUDCMS.usrc_Help();
            this.usrc_Help2 = new HUDCMS.usrc_Help();
            ((System.ComponentModel.ISupportInitialize)(this.dgvx_Item_Not_in_Pricelist)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_OK
            // 
            this.btn_OK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_OK.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_OK.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_OK.Location = new System.Drawing.Point(7, 335);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(89, 27);
            this.btn_OK.TabIndex = 3;
            this.btn_OK.Text = "OK";
            this.btn_OK.UseVisualStyleBackColor = false;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Cancel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_Cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_Cancel.Location = new System.Drawing.Point(155, 335);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(89, 27);
            this.btn_Cancel.TabIndex = 4;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = false;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // dgvx_Item_Not_in_Pricelist
            // 
            this.dgvx_Item_Not_in_Pricelist.AllowUserToAddRows = false;
            this.dgvx_Item_Not_in_Pricelist.AllowUserToDeleteRows = false;
            this.dgvx_Item_Not_in_Pricelist.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvx_Item_Not_in_Pricelist.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvx_Item_Not_in_Pricelist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvx_Item_Not_in_Pricelist.DataGridViewWithRowNumber = false;
            this.dgvx_Item_Not_in_Pricelist.Location = new System.Drawing.Point(7, 29);
            this.dgvx_Item_Not_in_Pricelist.Name = "dgvx_Item_Not_in_Pricelist";
            this.dgvx_Item_Not_in_Pricelist.ReadOnly = true;
            this.dgvx_Item_Not_in_Pricelist.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvx_Item_Not_in_Pricelist.Size = new System.Drawing.Size(552, 300);
            this.dgvx_Item_Not_in_Pricelist.TabIndex = 5;
            // 
            // lbl_Item_Not_in_PriceList
            // 
            this.lbl_Item_Not_in_PriceList.AutoSize = true;
            this.lbl_Item_Not_in_PriceList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_Item_Not_in_PriceList.Location = new System.Drawing.Point(14, 6);
            this.lbl_Item_Not_in_PriceList.Name = "lbl_Item_Not_in_PriceList";
            this.lbl_Item_Not_in_PriceList.Size = new System.Drawing.Size(51, 20);
            this.lbl_Item_Not_in_PriceList.TabIndex = 6;
            this.lbl_Item_Not_in_PriceList.Text = "label1";
            // 
            // usrc_Help1
            // 
            this.usrc_Help1.Location = new System.Drawing.Point(-23, -46);
            this.usrc_Help1.Name = "usrc_Help1";
            this.usrc_Help1.Size = new System.Drawing.Size(56, 61);
            this.usrc_Help1.TabIndex = 7;
            // 
            // usrc_Help2
            // 
            this.usrc_Help2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.usrc_Help2.Location = new System.Drawing.Point(514, 0);
            this.usrc_Help2.Name = "usrc_Help2";
            this.usrc_Help2.Size = new System.Drawing.Size(44, 26);
            this.usrc_Help2.TabIndex = 8;
            // 
            // Form_PriceList_NotComplete
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(564, 368);
            this.Controls.Add(this.usrc_Help2);
            this.Controls.Add(this.usrc_Help1);
            this.Controls.Add(this.dgvx_Item_Not_in_Pricelist);
            this.Controls.Add(this.lbl_Item_Not_in_PriceList);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_OK);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_PriceList_NotComplete";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PriceList_NotComplete_Form";
            this.Load += new System.EventHandler(this.PriceList_NotComplete_Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvx_Item_Not_in_Pricelist)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Button btn_Cancel;
        private DataGridView_2xls.DataGridView2xls dgvx_Item_Not_in_Pricelist;
        private System.Windows.Forms.Label lbl_Item_Not_in_PriceList;
        private HUDCMS.usrc_Help usrc_Help1;
        private HUDCMS.usrc_Help usrc_Help2;
    }
}