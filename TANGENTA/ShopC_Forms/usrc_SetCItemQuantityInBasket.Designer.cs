namespace ShopC_Forms
{
    partial class usrc_SetCItemQuantityInBasket
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(usrc_SetCItemQuantityInBasket));
            this.lbl_Item_UniqueName = new System.Windows.Forms.Label();
            this.lbl_ItemDescription = new System.Windows.Forms.Label();
            this.lb_ItemInfo = new System.Windows.Forms.Label();
            this.btn_Change = new System.Windows.Forms.Button();
            this.grp_From_Stock = new System.Windows.Forms.GroupBox();
            this.usrc_nmUpDn_FromStock = new DynEditControls.usrc_NumericUpDown3();
            this.btn_Exit = new System.Windows.Forms.Button();
            this.btn_Discount = new System.Windows.Forms.Button();
            this.btn_EditItem = new System.Windows.Forms.Button();
            this.pic_Item = new System.Windows.Forms.PictureBox();
            this.btn_Del = new System.Windows.Forms.Button();
            this.btn_DelBack = new System.Windows.Forms.Button();
            this.usrc_NumKeys1 = new usrc_NumKeypad.usrc_NumKeys();
            this.grp_From_Stock.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Item)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_Item_UniqueName
            // 
            this.lbl_Item_UniqueName.BackColor = System.Drawing.SystemColors.MenuBar;
            this.lbl_Item_UniqueName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_Item_UniqueName.Location = new System.Drawing.Point(4, 4);
            this.lbl_Item_UniqueName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_Item_UniqueName.Name = "lbl_Item_UniqueName";
            this.lbl_Item_UniqueName.Size = new System.Drawing.Size(638, 25);
            this.lbl_Item_UniqueName.TabIndex = 15;
            this.lbl_Item_UniqueName.Text = "label1";
            // 
            // lbl_ItemDescription
            // 
            this.lbl_ItemDescription.BackColor = System.Drawing.SystemColors.MenuBar;
            this.lbl_ItemDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_ItemDescription.Location = new System.Drawing.Point(4, 33);
            this.lbl_ItemDescription.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_ItemDescription.Name = "lbl_ItemDescription";
            this.lbl_ItemDescription.Size = new System.Drawing.Size(638, 25);
            this.lbl_ItemDescription.TabIndex = 22;
            this.lbl_ItemDescription.Text = "label1";
            // 
            // lb_ItemInfo
            // 
            this.lb_ItemInfo.BackColor = System.Drawing.SystemColors.MenuBar;
            this.lb_ItemInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lb_ItemInfo.Location = new System.Drawing.Point(4, 61);
            this.lb_ItemInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_ItemInfo.Name = "lb_ItemInfo";
            this.lb_ItemInfo.Size = new System.Drawing.Size(638, 25);
            this.lb_ItemInfo.TabIndex = 24;
            this.lb_ItemInfo.Text = "label2";
            this.lb_ItemInfo.Visible = false;
            // 
            // btn_Change
            // 
            this.btn_Change.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_Change.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_Change.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Change.Location = new System.Drawing.Point(409, 241);
            this.btn_Change.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Change.Name = "btn_Change";
            this.btn_Change.Size = new System.Drawing.Size(196, 68);
            this.btn_Change.TabIndex = 25;
            this.btn_Change.Text = "Change";
            this.btn_Change.UseVisualStyleBackColor = false;
            this.btn_Change.Click += new System.EventHandler(this.btn_Change_Click);
            // 
            // grp_From_Stock
            // 
            this.grp_From_Stock.Controls.Add(this.usrc_nmUpDn_FromStock);
            this.grp_From_Stock.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.grp_From_Stock.Location = new System.Drawing.Point(3, 95);
            this.grp_From_Stock.Name = "grp_From_Stock";
            this.grp_From_Stock.Size = new System.Drawing.Size(385, 139);
            this.grp_From_Stock.TabIndex = 28;
            this.grp_From_Stock.TabStop = false;
            this.grp_From_Stock.Text = "From Stock";
            // 
            // usrc_nmUpDn_FromStock
            // 
            this.usrc_nmUpDn_FromStock.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.usrc_nmUpDn_FromStock.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.usrc_nmUpDn_FromStock.DecimalPlaces = 2;
            this.usrc_nmUpDn_FromStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.usrc_nmUpDn_FromStock.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.usrc_nmUpDn_FromStock.Label1 = "";
            this.usrc_nmUpDn_FromStock.Label2 = "";
            this.usrc_nmUpDn_FromStock.Label3 = "";
            this.usrc_nmUpDn_FromStock.Label4 = "";
            this.usrc_nmUpDn_FromStock.Location = new System.Drawing.Point(6, 21);
            this.usrc_nmUpDn_FromStock.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.usrc_nmUpDn_FromStock.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.usrc_nmUpDn_FromStock.Name = "usrc_nmUpDn_FromStock";
            this.usrc_nmUpDn_FromStock.ReadOnly = false;
            this.usrc_nmUpDn_FromStock.Size = new System.Drawing.Size(370, 109);
            this.usrc_nmUpDn_FromStock.TabIndex = 0;
            this.usrc_nmUpDn_FromStock.Type = DynEditControls.usrc_NumericUpDown3.eType.INTEGER;
            this.usrc_nmUpDn_FromStock.Unit = "";
            this.usrc_nmUpDn_FromStock.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.usrc_nmUpDn_FromStock.ValueMultiplier = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.usrc_nmUpDn_FromStock.TextEnter += new System.EventHandler(this.usrc_nmUpDn_FromStock_TextEnter);
            // 
            // btn_Exit
            // 
            this.btn_Exit.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_Exit.Image = ((System.Drawing.Image)(resources.GetObject("btn_Exit.Image")));
            this.btn_Exit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Exit.Location = new System.Drawing.Point(7, 241);
            this.btn_Exit.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(163, 68);
            this.btn_Exit.TabIndex = 23;
            this.btn_Exit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Exit.UseVisualStyleBackColor = false;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // btn_Discount
            // 
            this.btn_Discount.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_Discount.Image = ((System.Drawing.Image)(resources.GetObject("btn_Discount.Image")));
            this.btn_Discount.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Discount.Location = new System.Drawing.Point(210, 241);
            this.btn_Discount.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Discount.Name = "btn_Discount";
            this.btn_Discount.Size = new System.Drawing.Size(178, 68);
            this.btn_Discount.TabIndex = 19;
            this.btn_Discount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Discount.UseVisualStyleBackColor = false;
            this.btn_Discount.Click += new System.EventHandler(this.btn_Discount_Click);
            // 
            // btn_EditItem
            // 
            this.btn_EditItem.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_EditItem.Image = ((System.Drawing.Image)(resources.GetObject("btn_EditItem.Image")));
            this.btn_EditItem.Location = new System.Drawing.Point(681, 243);
            this.btn_EditItem.Margin = new System.Windows.Forms.Padding(4);
            this.btn_EditItem.Name = "btn_EditItem";
            this.btn_EditItem.Size = new System.Drawing.Size(115, 68);
            this.btn_EditItem.TabIndex = 17;
            this.btn_EditItem.UseVisualStyleBackColor = false;
            this.btn_EditItem.Visible = false;
            // 
            // pic_Item
            // 
            this.pic_Item.Location = new System.Drawing.Point(646, 4);
            this.pic_Item.Margin = new System.Windows.Forms.Padding(4);
            this.pic_Item.Name = "pic_Item";
            this.pic_Item.Size = new System.Drawing.Size(146, 87);
            this.pic_Item.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic_Item.TabIndex = 16;
            this.pic_Item.TabStop = false;
            // 
            // btn_Del
            // 
            this.btn_Del.Location = new System.Drawing.Point(808, 8);
            this.btn_Del.Name = "btn_Del";
            this.btn_Del.Size = new System.Drawing.Size(109, 42);
            this.btn_Del.TabIndex = 31;
            this.btn_Del.Text = "DEL";
            this.btn_Del.UseVisualStyleBackColor = true;
            this.btn_Del.Click += new System.EventHandler(this.btn_Del_Click);
            // 
            // btn_DelBack
            // 
            this.btn_DelBack.Location = new System.Drawing.Point(922, 8);
            this.btn_DelBack.Name = "btn_DelBack";
            this.btn_DelBack.Size = new System.Drawing.Size(106, 42);
            this.btn_DelBack.TabIndex = 32;
            this.btn_DelBack.Text = "<=";
            this.btn_DelBack.UseVisualStyleBackColor = true;
            this.btn_DelBack.Click += new System.EventHandler(this.btn_DelBack_Click);
            // 
            // usrc_NumKeys1
            // 
            this.usrc_NumKeys1.DecimalPoint = ',';
            this.usrc_NumKeys1.Location = new System.Drawing.Point(803, 51);
            this.usrc_NumKeys1.Name = "usrc_NumKeys1";
            this.usrc_NumKeys1.Size = new System.Drawing.Size(233, 266);
            this.usrc_NumKeys1.TabIndex = 30;
            this.usrc_NumKeys1.ButtonClicked += new usrc_NumKeypad.usrc_NumKeys.delegate_ButtonClicked(this.usrc_NumKeys1_ButtonClicked);
            // 
            // usrc_SetCItemQuantityInBasket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.YellowGreen;
            this.Controls.Add(this.btn_DelBack);
            this.Controls.Add(this.btn_Del);
            this.Controls.Add(this.usrc_NumKeys1);
            this.Controls.Add(this.grp_From_Stock);
            this.Controls.Add(this.btn_Change);
            this.Controls.Add(this.lb_ItemInfo);
            this.Controls.Add(this.btn_Exit);
            this.Controls.Add(this.lbl_ItemDescription);
            this.Controls.Add(this.btn_Discount);
            this.Controls.Add(this.btn_EditItem);
            this.Controls.Add(this.pic_Item);
            this.Controls.Add(this.lbl_Item_UniqueName);
            this.Name = "usrc_SetCItemQuantityInBasket";
            this.Size = new System.Drawing.Size(1030, 320);
            this.grp_From_Stock.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pic_Item)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btn_Discount;
        private System.Windows.Forms.Button btn_EditItem;
        internal System.Windows.Forms.PictureBox pic_Item;
        internal System.Windows.Forms.Label lbl_Item_UniqueName;
        internal System.Windows.Forms.Label lbl_ItemDescription;
        private System.Windows.Forms.Button btn_Exit;
        internal System.Windows.Forms.Label lb_ItemInfo;
        private System.Windows.Forms.Button btn_Change;
        private System.Windows.Forms.GroupBox grp_From_Stock;
        private DynEditControls.usrc_NumericUpDown3 usrc_nmUpDn_FromStock;
        private usrc_NumKeypad.usrc_NumKeys usrc_NumKeys1;
        private System.Windows.Forms.Button btn_Del;
        private System.Windows.Forms.Button btn_DelBack;
    }
}
