namespace Tangenta
{
    partial class usrc_DocumentEditor1366x768
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
            this.txt_Number = new System.Windows.Forms.TextBox();
            this.lbl_Number = new System.Windows.Forms.Label();
            this.lbl_Sum = new System.Windows.Forms.Label();
            this.btn_Issue = new System.Windows.Forms.Button();
            this.chk_Head = new System.Windows.Forms.CheckBox();
            this.chk_Storno = new System.Windows.Forms.CheckBox();
            this.btn_Show_Shops = new System.Windows.Forms.Button();
            this.usrc_ShopB1 = new ShopB.usrc_ShopB();
            this.usrc_ShopA1366x7681 = new ShopA.usrc_ShopA1366x768();
            this.usrc_AddOn1 = new Tangenta.usrc_AddOn();
            this.usrc_Customer = new Tangenta.usrc_Customer();
            this.usrc_Item1366x7681 = new ShopC.usrc_Item1366x768();
            this.usrc_ShopC1366x7681 = new ShopC.usrc_ShopC1366x768();
            this.SuspendLayout();
            // 
            // txt_Number
            // 
            this.txt_Number.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_Number.Location = new System.Drawing.Point(81, 3);
            this.txt_Number.Name = "txt_Number";
            this.txt_Number.ReadOnly = true;
            this.txt_Number.Size = new System.Drawing.Size(104, 24);
            this.txt_Number.TabIndex = 22;
            // 
            // lbl_Number
            // 
            this.lbl_Number.AutoSize = true;
            this.lbl_Number.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_Number.Location = new System.Drawing.Point(2, 4);
            this.lbl_Number.Name = "lbl_Number";
            this.lbl_Number.Size = new System.Drawing.Size(77, 20);
            this.lbl_Number.TabIndex = 23;
            this.lbl_Number.Text = "Številka:";
            // 
            // lbl_Sum
            // 
            this.lbl_Sum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_Sum.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_Sum.Location = new System.Drawing.Point(3, 635);
            this.lbl_Sum.Name = "lbl_Sum";
            this.lbl_Sum.Size = new System.Drawing.Size(170, 29);
            this.lbl_Sum.TabIndex = 30;
            this.lbl_Sum.Text = "SKUPAJ";
            // 
            // btn_Issue
            // 
            this.btn_Issue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Issue.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_Issue.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_Issue.Location = new System.Drawing.Point(3, 665);
            this.btn_Issue.Name = "btn_Issue";
            this.btn_Issue.Size = new System.Drawing.Size(150, 41);
            this.btn_Issue.TabIndex = 32;
            this.btn_Issue.Text = "Issue";
            this.btn_Issue.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_Issue.UseVisualStyleBackColor = false;
            this.btn_Issue.Click += new System.EventHandler(this.btn_Issue_Click);
            // 
            // chk_Head
            // 
            this.chk_Head.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.chk_Head.Location = new System.Drawing.Point(191, 1);
            this.chk_Head.Name = "chk_Head";
            this.chk_Head.Size = new System.Drawing.Size(65, 36);
            this.chk_Head.TabIndex = 37;
            this.chk_Head.Text = "Glava";
            this.chk_Head.UseVisualStyleBackColor = true;
            this.chk_Head.CheckedChanged += new System.EventHandler(this.chk_Head_CheckedChanged_1);
            // 
            // chk_Storno
            // 
            this.chk_Storno.Appearance = System.Windows.Forms.Appearance.Button;
            this.chk_Storno.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.chk_Storno.Location = new System.Drawing.Point(896, 635);
            this.chk_Storno.Name = "chk_Storno";
            this.chk_Storno.Size = new System.Drawing.Size(107, 65);
            this.chk_Storno.TabIndex = 39;
            this.chk_Storno.Text = "Storno";
            this.chk_Storno.UseVisualStyleBackColor = true;
            this.chk_Storno.CheckedChanged += new System.EventHandler(this.chk_Storno_CheckedChanged);
            // 
            // btn_Show_Shops
            // 
            this.btn_Show_Shops.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_Show_Shops.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_Show_Shops.Location = new System.Drawing.Point(608, 635);
            this.btn_Show_Shops.Name = "btn_Show_Shops";
            this.btn_Show_Shops.Size = new System.Drawing.Size(107, 65);
            this.btn_Show_Shops.TabIndex = 41;
            this.btn_Show_Shops.Text = "trgovine";
            this.btn_Show_Shops.UseVisualStyleBackColor = false;
            this.btn_Show_Shops.Click += new System.EventHandler(this.btn_Select_Shops_Click);
            // 
            // usrc_ShopB1
            // 
            this.usrc_ShopB1.DocTyp = "";
            this.usrc_ShopB1.Location = new System.Drawing.Point(0, 220);
            this.usrc_ShopB1.Name = "usrc_ShopB1";
            this.usrc_ShopB1.Size = new System.Drawing.Size(1006, 119);
            this.usrc_ShopB1.SplitContainer1_spd = 408;
            this.usrc_ShopB1.SplitContainer2_spd = 409;
            this.usrc_ShopB1.TabIndex = 45;
            // 
            // usrc_ShopA1366x7681
            // 
            this.usrc_ShopA1366x7681.BackColor = System.Drawing.SystemColors.Control;
            this.usrc_ShopA1366x7681.Location = new System.Drawing.Point(0, 40);
            this.usrc_ShopA1366x7681.Name = "usrc_ShopA1366x7681";
            this.usrc_ShopA1366x7681.Size = new System.Drawing.Size(1006, 180);
            this.usrc_ShopA1366x7681.TabIndex = 44;
            // 
            // usrc_AddOn1
            // 
            this.usrc_AddOn1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.usrc_AddOn1.BackColor = System.Drawing.Color.LemonChiffon;
            this.usrc_AddOn1.Location = new System.Drawing.Point(721, 635);
            this.usrc_AddOn1.Name = "usrc_AddOn1";
            this.usrc_AddOn1.Size = new System.Drawing.Size(169, 65);
            this.usrc_AddOn1.TabIndex = 40;
            // 
            // usrc_Customer
            // 
            this.usrc_Customer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.usrc_Customer.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.usrc_Customer.DocTyp = "";
            this.usrc_Customer.Location = new System.Drawing.Point(259, 4);
            this.usrc_Customer.Margin = new System.Windows.Forms.Padding(4);
            this.usrc_Customer.Name = "usrc_Customer";
            this.usrc_Customer.Size = new System.Drawing.Size(743, 31);
            this.usrc_Customer.TabIndex = 33;
            this.usrc_Customer.aa_Customer_Person_Changed += new Tangenta.usrc_Customer.delegate_Customer_Person_Changed(this.usrc_Customer_Customer_Person_Changed);
            this.usrc_Customer.aa_Customer_Org_Changed += new Tangenta.usrc_Customer.delegate_Customer_Org_Changed(this.usrc_Customer_Customer_Org_Changed);
            this.usrc_Customer.aa_Customer_Removed += new Tangenta.usrc_Customer.delegate_Customer_Removed(this.usrc_Customer_aa_Customer_Removed);
            // 
            // usrc_Item1366x7681
            // 
            this.usrc_Item1366x7681.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(249)))), ((int)(((byte)(166)))));
            this.usrc_Item1366x7681.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.usrc_Item1366x7681.ExclusivelySellFromStock = false;
            this.usrc_Item1366x7681.Location = new System.Drawing.Point(204, 624);
            this.usrc_Item1366x7681.Margin = new System.Windows.Forms.Padding(4);
            this.usrc_Item1366x7681.Name = "usrc_Item1366x7681";
            this.usrc_Item1366x7681.PriceText = "Price:";
            this.usrc_Item1366x7681.Size = new System.Drawing.Size(397, 82);
            this.usrc_Item1366x7681.TabIndex = 47;
            // 
            // usrc_ShopC1366x7681
            // 
            this.usrc_ShopC1366x7681.AutomaticSelectionOfItemsFromStock = true;
            this.usrc_ShopC1366x7681.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.usrc_ShopC1366x7681.DocTyp = "";
            this.usrc_ShopC1366x7681.ExclusivelySellFromStock = false;
            this.usrc_ShopC1366x7681.Location = new System.Drawing.Point(1, 340);
            this.usrc_ShopC1366x7681.Margin = new System.Windows.Forms.Padding(4);
            this.usrc_ShopC1366x7681.Name = "usrc_ShopC1366x7681";
            this.usrc_ShopC1366x7681.PriceList_ID = null;
            this.usrc_ShopC1366x7681.Size = new System.Drawing.Size(1006, 280);
            this.usrc_ShopC1366x7681.TabIndex = 46;
            // 
            // usrc_DocumentEditor1366x768
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.usrc_Item1366x7681);
            this.Controls.Add(this.usrc_ShopC1366x7681);
            this.Controls.Add(this.usrc_ShopB1);
            this.Controls.Add(this.usrc_ShopA1366x7681);
            this.Controls.Add(this.btn_Show_Shops);
            this.Controls.Add(this.usrc_AddOn1);
            this.Controls.Add(this.chk_Storno);
            this.Controls.Add(this.usrc_Customer);
            this.Controls.Add(this.chk_Head);
            this.Controls.Add(this.btn_Issue);
            this.Controls.Add(this.lbl_Sum);
            this.Controls.Add(this.lbl_Number);
            this.Controls.Add(this.txt_Number);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "usrc_DocumentEditor1366x768";
            this.Size = new System.Drawing.Size(1006, 706);
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion
        private System.Windows.Forms.TextBox txt_Number;
        private System.Windows.Forms.Label lbl_Number;
        private System.Windows.Forms.Button btn_Issue;
        private usrc_Customer usrc_Customer;
        private System.Windows.Forms.CheckBox chk_Head;
        private System.Windows.Forms.CheckBox chk_Storno;
        private usrc_AddOn usrc_AddOn1;
        public System.Windows.Forms.Button btn_Show_Shops;
        public System.Windows.Forms.Label lbl_Sum;
        private ShopA.usrc_ShopA1366x768 usrc_ShopA1366x7681;
        private ShopB.usrc_ShopB usrc_ShopB1;
        private ShopC.usrc_ShopC1366x768 usrc_ShopC1366x7681;
        private ShopC.usrc_Item1366x768 usrc_Item1366x7681;
    }
}
