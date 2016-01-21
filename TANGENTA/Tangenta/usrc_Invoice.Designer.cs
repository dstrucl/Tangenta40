namespace Tangenta
{
    partial class usrc_Invoice
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(usrc_Invoice));
            this.txt_MyCompany = new System.Windows.Forms.TextBox();
            this.lbl_MyCompany = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.cmb_select_my_Company_Person = new System.Windows.Forms.ComboBox();
            this.txt_Number = new System.Windows.Forms.TextBox();
            this.lbl_Number = new System.Windows.Forms.Label();
            this.btn_edit_MyCompany_Person = new System.Windows.Forms.Button();
            this.lbl_Currency = new System.Windows.Forms.Label();
            this.txt_Currency = new System.Windows.Forms.TextBox();
            this.btn_SelectBaseCurrency = new System.Windows.Forms.Button();
            this.lbl_Sum = new System.Windows.Forms.Label();
            this.btn_Issue = new System.Windows.Forms.Button();
            this.rdbStore_SimpleItem = new System.Windows.Forms.RadioButton();
            this.rdbStore_Item = new System.Windows.Forms.RadioButton();
            this.rdbStore_SimpleItem_And_Item = new System.Windows.Forms.RadioButton();
            this.chk_Head = new System.Windows.Forms.CheckBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.btn_CodeTables = new System.Windows.Forms.Button();
            this.chk_Storno = new System.Windows.Forms.CheckBox();
            this.usrc_Notice1 = new Tangenta.usrc_Notice();
            this.usrc_PriceList = new Tangenta.usrc_PriceList();
            this.usrc_Customer = new Tangenta.usrc_Customer();
            this.usrc_SimpleItemMan = new Tangenta.usrc_ShopB();
            this.usrc_ItemMan = new Tangenta.usrc_ShopC();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_MyCompany
            // 
            this.txt_MyCompany.Location = new System.Drawing.Point(320, 6);
            this.txt_MyCompany.Margin = new System.Windows.Forms.Padding(2);
            this.txt_MyCompany.Multiline = true;
            this.txt_MyCompany.Name = "txt_MyCompany";
            this.txt_MyCompany.Size = new System.Drawing.Size(399, 34);
            this.txt_MyCompany.TabIndex = 1;
            // 
            // lbl_MyCompany
            // 
            this.lbl_MyCompany.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_MyCompany.AutoSize = true;
            this.lbl_MyCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_MyCompany.Location = new System.Drawing.Point(1, 11);
            this.lbl_MyCompany.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_MyCompany.Name = "lbl_MyCompany";
            this.lbl_MyCompany.Size = new System.Drawing.Size(78, 17);
            this.lbl_MyCompany.TabIndex = 2;
            this.lbl_MyCompany.Text = "Izdajatelj:";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Location = new System.Drawing.Point(3, 2);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(2);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.usrc_SimpleItemMan);
            this.splitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.usrc_ItemMan);
            this.splitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer1.Size = new System.Drawing.Size(1014, 611);
            this.splitContainer1.SplitterDistance = 322;
            this.splitContainer1.SplitterWidth = 3;
            this.splitContainer1.TabIndex = 3;
            // 
            // cmb_select_my_Company_Person
            // 
            this.cmb_select_my_Company_Person.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cmb_select_my_Company_Person.FormattingEnabled = true;
            this.cmb_select_my_Company_Person.Location = new System.Drawing.Point(125, 7);
            this.cmb_select_my_Company_Person.Name = "cmb_select_my_Company_Person";
            this.cmb_select_my_Company_Person.Size = new System.Drawing.Size(186, 24);
            this.cmb_select_my_Company_Person.TabIndex = 21;
            // 
            // txt_Number
            // 
            this.txt_Number.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_Number.Location = new System.Drawing.Point(79, 3);
            this.txt_Number.Name = "txt_Number";
            this.txt_Number.ReadOnly = true;
            this.txt_Number.Size = new System.Drawing.Size(137, 26);
            this.txt_Number.TabIndex = 22;
            // 
            // lbl_Number
            // 
            this.lbl_Number.AutoSize = true;
            this.lbl_Number.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_Number.Location = new System.Drawing.Point(2, 6);
            this.lbl_Number.Name = "lbl_Number";
            this.lbl_Number.Size = new System.Drawing.Size(77, 20);
            this.lbl_Number.TabIndex = 23;
            this.lbl_Number.Text = "Številka:";
            // 
            // btn_edit_MyCompany_Person
            // 
            this.btn_edit_MyCompany_Person.Image = ((System.Drawing.Image)(resources.GetObject("btn_edit_MyCompany_Person.Image")));
            this.btn_edit_MyCompany_Person.Location = new System.Drawing.Point(82, 6);
            this.btn_edit_MyCompany_Person.Name = "btn_edit_MyCompany_Person";
            this.btn_edit_MyCompany_Person.Size = new System.Drawing.Size(35, 28);
            this.btn_edit_MyCompany_Person.TabIndex = 17;
            this.btn_edit_MyCompany_Person.UseVisualStyleBackColor = true;
            this.btn_edit_MyCompany_Person.Click += new System.EventHandler(this.btn_edit_MyCompany_Click_1);
            // 
            // lbl_Currency
            // 
            this.lbl_Currency.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_Currency.Location = new System.Drawing.Point(746, 7);
            this.lbl_Currency.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_Currency.Name = "lbl_Currency";
            this.lbl_Currency.Size = new System.Drawing.Size(59, 17);
            this.lbl_Currency.TabIndex = 25;
            this.lbl_Currency.Text = "Valuta:";
            this.lbl_Currency.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txt_Currency
            // 
            this.txt_Currency.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_Currency.Location = new System.Drawing.Point(846, 0);
            this.txt_Currency.Name = "txt_Currency";
            this.txt_Currency.ReadOnly = true;
            this.txt_Currency.Size = new System.Drawing.Size(64, 26);
            this.txt_Currency.TabIndex = 27;
            // 
            // btn_SelectBaseCurrency
            // 
            this.btn_SelectBaseCurrency.AutoEllipsis = true;
            this.btn_SelectBaseCurrency.Image = ((System.Drawing.Image)(resources.GetObject("btn_SelectBaseCurrency.Image")));
            this.btn_SelectBaseCurrency.Location = new System.Drawing.Point(808, -1);
            this.btn_SelectBaseCurrency.Name = "btn_SelectBaseCurrency";
            this.btn_SelectBaseCurrency.Size = new System.Drawing.Size(34, 29);
            this.btn_SelectBaseCurrency.TabIndex = 28;
            this.btn_SelectBaseCurrency.UseVisualStyleBackColor = true;
            this.btn_SelectBaseCurrency.Click += new System.EventHandler(this.btn_SelectBaseCurrency_Click);
            // 
            // lbl_Sum
            // 
            this.lbl_Sum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_Sum.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_Sum.Location = new System.Drawing.Point(4, 741);
            this.lbl_Sum.Name = "lbl_Sum";
            this.lbl_Sum.Size = new System.Drawing.Size(224, 33);
            this.lbl_Sum.TabIndex = 30;
            this.lbl_Sum.Text = "SKUPAJ";
            // 
            // btn_Issue
            // 
            this.btn_Issue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Issue.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_Issue.Location = new System.Drawing.Point(274, 736);
            this.btn_Issue.Name = "btn_Issue";
            this.btn_Issue.Size = new System.Drawing.Size(150, 41);
            this.btn_Issue.TabIndex = 32;
            this.btn_Issue.Text = "Issue";
            this.btn_Issue.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_Issue.UseVisualStyleBackColor = true;
            this.btn_Issue.Click += new System.EventHandler(this.btn_Issue_Click);
            // 
            // rdbStore_SimpleItem
            // 
            this.rdbStore_SimpleItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rdbStore_SimpleItem.Location = new System.Drawing.Point(315, 3);
            this.rdbStore_SimpleItem.Name = "rdbStore_SimpleItem";
            this.rdbStore_SimpleItem.Size = new System.Drawing.Size(104, 24);
            this.rdbStore_SimpleItem.TabIndex = 34;
            this.rdbStore_SimpleItem.Text = "A";
            this.rdbStore_SimpleItem.UseVisualStyleBackColor = true;
            this.rdbStore_SimpleItem.CheckedChanged += new System.EventHandler(this.rdbStore_SimpleItem_CheckedChanged);
            // 
            // rdbStore_Item
            // 
            this.rdbStore_Item.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rdbStore_Item.Location = new System.Drawing.Point(429, 3);
            this.rdbStore_Item.Name = "rdbStore_Item";
            this.rdbStore_Item.Size = new System.Drawing.Size(119, 24);
            this.rdbStore_Item.TabIndex = 35;
            this.rdbStore_Item.Text = "B";
            this.rdbStore_Item.UseVisualStyleBackColor = true;
            this.rdbStore_Item.CheckedChanged += new System.EventHandler(this.rdbStore_Item_CheckedChanged);
            // 
            // rdbStore_SimpleItem_And_Item
            // 
            this.rdbStore_SimpleItem_And_Item.Checked = true;
            this.rdbStore_SimpleItem_And_Item.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rdbStore_SimpleItem_And_Item.Location = new System.Drawing.Point(554, 3);
            this.rdbStore_SimpleItem_And_Item.Name = "rdbStore_SimpleItem_And_Item";
            this.rdbStore_SimpleItem_And_Item.Size = new System.Drawing.Size(188, 24);
            this.rdbStore_SimpleItem_And_Item.TabIndex = 36;
            this.rdbStore_SimpleItem_And_Item.TabStop = true;
            this.rdbStore_SimpleItem_And_Item.Text = "A && B";
            this.rdbStore_SimpleItem_And_Item.UseVisualStyleBackColor = true;
            this.rdbStore_SimpleItem_And_Item.CheckedChanged += new System.EventHandler(this.rdbStore_SimpleItem_And_Item_CheckedChanged);
            // 
            // chk_Head
            // 
            this.chk_Head.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.chk_Head.Location = new System.Drawing.Point(222, 2);
            this.chk_Head.Name = "chk_Head";
            this.chk_Head.Size = new System.Drawing.Size(83, 28);
            this.chk_Head.TabIndex = 37;
            this.chk_Head.Text = "Glava";
            this.chk_Head.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer2.Location = new System.Drawing.Point(-1, 34);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.btn_CodeTables);
            this.splitContainer2.Panel1.Controls.Add(this.txt_MyCompany);
            this.splitContainer2.Panel1.Controls.Add(this.lbl_MyCompany);
            this.splitContainer2.Panel1.Controls.Add(this.btn_edit_MyCompany_Person);
            this.splitContainer2.Panel1.Controls.Add(this.cmb_select_my_Company_Person);
            this.splitContainer2.Panel1.Controls.Add(this.usrc_PriceList);
            this.splitContainer2.Panel1.Controls.Add(this.usrc_Customer);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer1);
            this.splitContainer2.Size = new System.Drawing.Size(1021, 697);
            this.splitContainer2.SplitterDistance = 78;
            this.splitContainer2.TabIndex = 38;
            // 
            // btn_CodeTables
            // 
            this.btn_CodeTables.AutoEllipsis = true;
            this.btn_CodeTables.Image = ((System.Drawing.Image)(resources.GetObject("btn_CodeTables.Image")));
            this.btn_CodeTables.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_CodeTables.Location = new System.Drawing.Point(804, 43);
            this.btn_CodeTables.Name = "btn_CodeTables";
            this.btn_CodeTables.Size = new System.Drawing.Size(107, 29);
            this.btn_CodeTables.TabIndex = 34;
            this.btn_CodeTables.Text = "Code tables";
            this.btn_CodeTables.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_CodeTables.UseVisualStyleBackColor = true;
            this.btn_CodeTables.Click += new System.EventHandler(this.btn_CodeTables_Click);
            // 
            // chk_Storno
            // 
            this.chk_Storno.AutoSize = true;
            this.chk_Storno.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.chk_Storno.Location = new System.Drawing.Point(918, 1);
            this.chk_Storno.Name = "chk_Storno";
            this.chk_Storno.Size = new System.Drawing.Size(84, 28);
            this.chk_Storno.TabIndex = 39;
            this.chk_Storno.Text = "Storno";
            this.chk_Storno.UseVisualStyleBackColor = true;
            this.chk_Storno.CheckedChanged += new System.EventHandler(this.chk_Storno_CheckedChanged);
            // 
            // usrc_Notice1
            // 
            this.usrc_Notice1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.usrc_Notice1.BackColor = System.Drawing.Color.LemonChiffon;
            this.usrc_Notice1.Location = new System.Drawing.Point(452, 736);
            this.usrc_Notice1.Name = "usrc_Notice1";
            this.usrc_Notice1.Size = new System.Drawing.Size(567, 42);
            this.usrc_Notice1.TabIndex = 40;
            // 
            // usrc_PriceList
            // 
            this.usrc_PriceList.Location = new System.Drawing.Point(725, 8);
            this.usrc_PriceList.Margin = new System.Windows.Forms.Padding(4);
            this.usrc_PriceList.Name = "usrc_PriceList";
            this.usrc_PriceList.Size = new System.Drawing.Size(276, 31);
            this.usrc_PriceList.TabIndex = 29;
            // 
            // usrc_Customer
            // 
            this.usrc_Customer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.usrc_Customer.BackColor = System.Drawing.SystemColors.Control;
            this.usrc_Customer.Location = new System.Drawing.Point(6, 44);
            this.usrc_Customer.Margin = new System.Windows.Forms.Padding(4);
            this.usrc_Customer.Name = "usrc_Customer";
            this.usrc_Customer.Size = new System.Drawing.Size(788, 29);
            this.usrc_Customer.TabIndex = 33;
            this.usrc_Customer.aa_Customer_Person_Changed += new Tangenta.usrc_Customer.delegate_Customer_Person_Changed(this.usrc_Customer_Customer_Person_Changed);
            this.usrc_Customer.aa_Customer_Org_Changed += new Tangenta.usrc_Customer.delegate_Customer_Org_Changed(this.usrc_Customer_Customer_Org_Changed);
            this.usrc_Customer.aa_Customer_Removed += new Tangenta.usrc_Customer.delegate_Customer_Removed(this.usrc_Customer_aa_Customer_Removed);
            this.usrc_Customer.Load += new System.EventHandler(this.usrc_Customer_Load);
            // 
            // usrc_SimpleItemMan
            // 
            this.usrc_SimpleItemMan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.usrc_SimpleItemMan.Location = new System.Drawing.Point(0, 0);
            this.usrc_SimpleItemMan.Margin = new System.Windows.Forms.Padding(4);
            this.usrc_SimpleItemMan.Name = "usrc_SimpleItemMan";
            this.usrc_SimpleItemMan.Size = new System.Drawing.Size(1010, 318);
            this.usrc_SimpleItemMan.TabIndex = 0;
            // 
            // usrc_ItemMan
            // 
            this.usrc_ItemMan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.usrc_ItemMan.Location = new System.Drawing.Point(0, 0);
            this.usrc_ItemMan.Margin = new System.Windows.Forms.Padding(4);
            this.usrc_ItemMan.Name = "usrc_ItemMan";
            this.usrc_ItemMan.Size = new System.Drawing.Size(1010, 282);
            this.usrc_ItemMan.TabIndex = 0;
            this.usrc_ItemMan.ItemAdded += new Tangenta.usrc_ShopC.delegate_ItemAdded(this.usrc_ItemMan_ItemAdded);
            this.usrc_ItemMan.After_Atom_Item_Remove += new Tangenta.usrc_ShopC.delegate_After_Atom_Item_Remove(this.usrc_ItemMan_After_Atom_Item_Remove);
            // 
            // usrc_Invoice
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.usrc_Notice1);
            this.Controls.Add(this.chk_Storno);
            this.Controls.Add(this.splitContainer2);
            this.Controls.Add(this.chk_Head);
            this.Controls.Add(this.rdbStore_SimpleItem_And_Item);
            this.Controls.Add(this.rdbStore_Item);
            this.Controls.Add(this.rdbStore_SimpleItem);
            this.Controls.Add(this.btn_Issue);
            this.Controls.Add(this.lbl_Sum);
            this.Controls.Add(this.btn_SelectBaseCurrency);
            this.Controls.Add(this.txt_Currency);
            this.Controls.Add(this.lbl_Currency);
            this.Controls.Add(this.lbl_Number);
            this.Controls.Add(this.txt_Number);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "usrc_Invoice";
            this.Size = new System.Drawing.Size(1025, 779);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private System.Windows.Forms.TextBox txt_MyCompany;
        private System.Windows.Forms.Label lbl_MyCompany;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btn_edit_MyCompany_Person;
        private System.Windows.Forms.ComboBox cmb_select_my_Company_Person;
        private System.Windows.Forms.TextBox txt_Number;
        private System.Windows.Forms.Label lbl_Number;
        internal usrc_ShopB usrc_SimpleItemMan;
        internal usrc_ShopC usrc_ItemMan;
        private System.Windows.Forms.Label lbl_Currency;
        private System.Windows.Forms.TextBox txt_Currency;
        private System.Windows.Forms.Button btn_SelectBaseCurrency;
        internal usrc_PriceList usrc_PriceList;
        private System.Windows.Forms.Label lbl_Sum;
        private System.Windows.Forms.Button btn_Issue;
        private usrc_Customer usrc_Customer;
        private System.Windows.Forms.RadioButton rdbStore_SimpleItem;
        private System.Windows.Forms.RadioButton rdbStore_Item;
        private System.Windows.Forms.RadioButton rdbStore_SimpleItem_And_Item;
        private System.Windows.Forms.CheckBox chk_Head;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.CheckBox chk_Storno;
        private System.Windows.Forms.Button btn_CodeTables;
        private usrc_Notice usrc_Notice1;
    }
}
