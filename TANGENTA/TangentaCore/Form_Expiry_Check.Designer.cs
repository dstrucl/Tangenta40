using System.Data;
using System.Windows.Forms;

namespace TangentaCore
{
    partial class Form_Expiry_Check
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Expiry_Check));
            this.btn_OK = new System.Windows.Forms.Button();
            this.lbl_Legend = new System.Windows.Forms.Label();
            this.lbl_Color_Items_for_discount = new System.Windows.Forms.Label();
            this.lbl_Color_ItemsToDestroy = new System.Windows.Forms.Label();
            this.lbl_Items_for_discount = new System.Windows.Forms.Label();
            this.lbl_ItemsToDestroy = new System.Windows.Forms.Label();
            this.lbl_Items_WithNoExpiryData = new System.Windows.Forms.Label();
            this.lbl_Color_ItemsWithNoExpiryData = new System.Windows.Forms.Label();
            this.dgvx_ExpiryCheck = new DataGridView_2xls.DataGridView2xls();
            this.usrc_Help1 = new HUDCMS.usrc_Help();
            ((System.ComponentModel.ISupportInitialize)(this.dgvx_ExpiryCheck)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_OK
            // 
            this.btn_OK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_OK.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_OK.Location = new System.Drawing.Point(446, 509);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(89, 28);
            this.btn_OK.TabIndex = 1;
            this.btn_OK.Text = "OK";
            this.btn_OK.UseVisualStyleBackColor = false;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // lbl_Legend
            // 
            this.lbl_Legend.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_Legend.Location = new System.Drawing.Point(12, 5);
            this.lbl_Legend.Name = "lbl_Legend";
            this.lbl_Legend.Size = new System.Drawing.Size(99, 21);
            this.lbl_Legend.TabIndex = 2;
            this.lbl_Legend.Text = "Legenda:";
            this.lbl_Legend.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lbl_Color_Items_for_discount
            // 
            this.lbl_Color_Items_for_discount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.lbl_Color_Items_for_discount.Location = new System.Drawing.Point(128, 3);
            this.lbl_Color_Items_for_discount.Name = "lbl_Color_Items_for_discount";
            this.lbl_Color_Items_for_discount.Size = new System.Drawing.Size(18, 17);
            this.lbl_Color_Items_for_discount.TabIndex = 3;
            // 
            // lbl_Color_ItemsToDestroy
            // 
            this.lbl_Color_ItemsToDestroy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.lbl_Color_ItemsToDestroy.Location = new System.Drawing.Point(128, 23);
            this.lbl_Color_ItemsToDestroy.Name = "lbl_Color_ItemsToDestroy";
            this.lbl_Color_ItemsToDestroy.Size = new System.Drawing.Size(18, 17);
            this.lbl_Color_ItemsToDestroy.TabIndex = 4;
            // 
            // lbl_Items_for_discount
            // 
            this.lbl_Items_for_discount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.lbl_Items_for_discount.Location = new System.Drawing.Point(152, 3);
            this.lbl_Items_for_discount.Name = "lbl_Items_for_discount";
            this.lbl_Items_for_discount.Size = new System.Drawing.Size(527, 17);
            this.lbl_Items_for_discount.TabIndex = 5;
            // 
            // lbl_ItemsToDestroy
            // 
            this.lbl_ItemsToDestroy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.lbl_ItemsToDestroy.Location = new System.Drawing.Point(152, 23);
            this.lbl_ItemsToDestroy.Name = "lbl_ItemsToDestroy";
            this.lbl_ItemsToDestroy.Size = new System.Drawing.Size(527, 17);
            this.lbl_ItemsToDestroy.TabIndex = 6;
            // 
            // lbl_Items_WithNoExpiryData
            // 
            this.lbl_Items_WithNoExpiryData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.lbl_Items_WithNoExpiryData.Location = new System.Drawing.Point(152, 43);
            this.lbl_Items_WithNoExpiryData.Name = "lbl_Items_WithNoExpiryData";
            this.lbl_Items_WithNoExpiryData.Size = new System.Drawing.Size(527, 17);
            this.lbl_Items_WithNoExpiryData.TabIndex = 8;
            // 
            // lbl_Color_ItemsWithNoExpiryData
            // 
            this.lbl_Color_ItemsWithNoExpiryData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.lbl_Color_ItemsWithNoExpiryData.Location = new System.Drawing.Point(128, 43);
            this.lbl_Color_ItemsWithNoExpiryData.Name = "lbl_Color_ItemsWithNoExpiryData";
            this.lbl_Color_ItemsWithNoExpiryData.Size = new System.Drawing.Size(18, 17);
            this.lbl_Color_ItemsWithNoExpiryData.TabIndex = 7;
            // 
            // dgvx_ExpiryCheck
            // 
            this.dgvx_ExpiryCheck.AllowUserToAddRows = false;
            this.dgvx_ExpiryCheck.AllowUserToDeleteRows = false;
            this.dgvx_ExpiryCheck.AllowUserToOrderColumns = true;
            this.dgvx_ExpiryCheck.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvx_ExpiryCheck.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvx_ExpiryCheck.DataGridViewWithRowNumber = false;
            this.dgvx_ExpiryCheck.Location = new System.Drawing.Point(1, 64);
            this.dgvx_ExpiryCheck.Name = "dgvx_ExpiryCheck";
            this.dgvx_ExpiryCheck.ReadOnly = true;
            this.dgvx_ExpiryCheck.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvx_ExpiryCheck.Size = new System.Drawing.Size(974, 441);
            this.dgvx_ExpiryCheck.TabIndex = 0;
            this.dgvx_ExpiryCheck.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvx_ExpiryCheck_CellFormatting);
            // 
            // usrc_Help1
            // 
            this.usrc_Help1.Location = new System.Drawing.Point(917, 5);
            this.usrc_Help1.Name = "usrc_Help1";
            this.usrc_Help1.Size = new System.Drawing.Size(58, 31);
            this.usrc_Help1.TabIndex = 9;
            // 
            // Form_Expiry_Check
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(979, 539);
            this.Controls.Add(this.usrc_Help1);
            this.Controls.Add(this.lbl_Items_WithNoExpiryData);
            this.Controls.Add(this.lbl_Color_ItemsWithNoExpiryData);
            this.Controls.Add(this.lbl_ItemsToDestroy);
            this.Controls.Add(this.lbl_Items_for_discount);
            this.Controls.Add(this.lbl_Color_ItemsToDestroy);
            this.Controls.Add(this.lbl_Color_Items_for_discount);
            this.Controls.Add(this.lbl_Legend);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.dgvx_ExpiryCheck);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_Expiry_Check";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form_Expiry_Check";
            this.Load += new System.EventHandler(this.Form_Expiry_Check_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvx_ExpiryCheck)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView_2xls.DataGridView2xls dgvx_ExpiryCheck;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Label lbl_Legend;
        private System.Windows.Forms.Label lbl_Color_Items_for_discount;
        private System.Windows.Forms.Label lbl_Color_ItemsToDestroy;
        private System.Windows.Forms.Label lbl_Items_for_discount;
        private System.Windows.Forms.Label lbl_ItemsToDestroy;
        private Label lbl_Items_WithNoExpiryData;
        private Label lbl_Color_ItemsWithNoExpiryData;
        private HUDCMS.usrc_Help usrc_Help1;
    }
}