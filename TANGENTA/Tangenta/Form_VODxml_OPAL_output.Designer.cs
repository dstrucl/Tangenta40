namespace Tangenta
{
    partial class Form_VODxml_OPAL_output
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_VODxml_OPAL_output));
            this.btn_SelectFolder = new System.Windows.Forms.Button();
            this.lbl_Folder = new System.Windows.Forms.Label();
            this.lbl_FileNames = new System.Windows.Forms.Label();
            this.btn_Save = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.cmbR_FilePath = new ComboBox_Recent.ComboBox_RecentList();
            this.cmb_VOD_xml_shema = new ComboBox_Recent.ComboBox_RecentList();
            this.btn_Select_Shema = new System.Windows.Forms.Button();
            this.lbl_VOD_xml_shema = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgvx_Glava = new DataGridView_2xls.DataGridView2xls();
            this.lbl_Glava = new System.Windows.Forms.Label();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.lbl_Dokumenti = new System.Windows.Forms.Label();
            this.dgvx_Dokumenti = new DataGridView_2xls.DataGridView2xls();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.lbl_Knjizbe = new System.Windows.Forms.Label();
            this.dgvx_Knjizbe = new DataGridView_2xls.DataGridView2xls();
            this.lbl_Konto_Price_with_tax_for_cash = new System.Windows.Forms.Label();
            this.nmUpDn_Konto_Price_with_tax_for_cash = new System.Windows.Forms.NumericUpDown();
            this.nmUpDn_Konto_NetPrice = new System.Windows.Forms.NumericUpDown();
            this.lbl_Konto_Net_price = new System.Windows.Forms.Label();
            this.nmUpDn_Konto_VAT_general_rate = new System.Windows.Forms.NumericUpDown();
            this.lbl_End_Customers_Code = new System.Windows.Forms.Label();
            this.btn_View = new System.Windows.Forms.Button();
            this.nmUpDn_Konto_Price_with_tax_for_payment_cards = new System.Windows.Forms.NumericUpDown();
            this.lbl_Konto_Price_with_tax_for_payment_cards = new System.Windows.Forms.Label();
            this.txt_End_Customers_Name = new System.Windows.Forms.TextBox();
            this.lbl_End_Customes_Name = new System.Windows.Forms.Label();
            this.nmUpDn_End_Customers_Code = new System.Windows.Forms.NumericUpDown();
            this.lbl_Konto_VAT_general_rate = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvx_Glava)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvx_Dokumenti)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvx_Knjizbe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmUpDn_Konto_Price_with_tax_for_cash)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmUpDn_Konto_NetPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmUpDn_Konto_VAT_general_rate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmUpDn_Konto_Price_with_tax_for_payment_cards)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmUpDn_End_Customers_Code)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_SelectFolder
            // 
            this.btn_SelectFolder.Image = ((System.Drawing.Image)(resources.GetObject("btn_SelectFolder.Image")));
            this.btn_SelectFolder.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_SelectFolder.Location = new System.Drawing.Point(604, 73);
            this.btn_SelectFolder.Margin = new System.Windows.Forms.Padding(2);
            this.btn_SelectFolder.Name = "btn_SelectFolder";
            this.btn_SelectFolder.Size = new System.Drawing.Size(71, 29);
            this.btn_SelectFolder.TabIndex = 13;
            this.btn_SelectFolder.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_SelectFolder.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_SelectFolder.UseVisualStyleBackColor = true;
            this.btn_SelectFolder.Click += new System.EventHandler(this.btn_SelectFolder_Click);
            // 
            // lbl_Folder
            // 
            this.lbl_Folder.AutoSize = true;
            this.lbl_Folder.Location = new System.Drawing.Point(16, 49);
            this.lbl_Folder.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_Folder.Name = "lbl_Folder";
            this.lbl_Folder.Size = new System.Drawing.Size(92, 13);
            this.lbl_Folder.TabIndex = 12;
            this.lbl_Folder.Text = "Destination Folder";
            // 
            // lbl_FileNames
            // 
            this.lbl_FileNames.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_FileNames.Location = new System.Drawing.Point(16, 110);
            this.lbl_FileNames.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_FileNames.Name = "lbl_FileNames";
            this.lbl_FileNames.Size = new System.Drawing.Size(659, 43);
            this.lbl_FileNames.TabIndex = 15;
            this.lbl_FileNames.Text = "Backup FileName";
            // 
            // btn_Save
            // 
            this.btn_Save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Save.Location = new System.Drawing.Point(2, 677);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(95, 37);
            this.btn_Save.TabIndex = 17;
            this.btn_Save.Text = "Save";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Cancel.Image = global::Tangenta.Properties.Resources.Exit;
            this.btn_Cancel.Location = new System.Drawing.Point(940, 9);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(79, 37);
            this.btn_Cancel.TabIndex = 18;
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // cmbR_FilePath
            // 
            this.cmbR_FilePath.AskToCreateRecentItemsFolder = false;
            this.cmbR_FilePath.DisplayMember = "text";
            this.cmbR_FilePath.DisplayTime = true;
            this.cmbR_FilePath.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbR_FilePath.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cmbR_FilePath.FormattingEnabled = true;
            this.cmbR_FilePath.InsertOnKeyPress = true;
            this.cmbR_FilePath.Key = "Folder";
            this.cmbR_FilePath.Location = new System.Drawing.Point(21, 75);
            this.cmbR_FilePath.MaxRecentCount = 10;
            this.cmbR_FilePath.Name = "cmbR_FilePath";
            this.cmbR_FilePath.ReadOnly = false;
            this.cmbR_FilePath.RecentItemsFileName = "SQlite_LocalDB_FilePath.xml";
            this.cmbR_FilePath.RecentItemsFolder = "C:\\Users\\logi\\AppData\\Local\\Microsoft\\VisualStudio\\14.0\\ProjectAssemblies\\fcmo62m" +
    "-01\\RecentComboBoxItems";
            this.cmbR_FilePath.Size = new System.Drawing.Size(578, 23);
            this.cmbR_FilePath.TabIndex = 14;
            // 
            // cmb_VOD_xml_shema
            // 
            this.cmb_VOD_xml_shema.AskToCreateRecentItemsFolder = false;
            this.cmb_VOD_xml_shema.DisplayMember = "text";
            this.cmb_VOD_xml_shema.DisplayTime = true;
            this.cmb_VOD_xml_shema.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmb_VOD_xml_shema.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cmb_VOD_xml_shema.FormattingEnabled = true;
            this.cmb_VOD_xml_shema.InsertOnKeyPress = true;
            this.cmb_VOD_xml_shema.Key = "Folder";
            this.cmb_VOD_xml_shema.Location = new System.Drawing.Point(23, 27);
            this.cmb_VOD_xml_shema.MaxRecentCount = 10;
            this.cmb_VOD_xml_shema.Name = "cmb_VOD_xml_shema";
            this.cmb_VOD_xml_shema.ReadOnly = false;
            this.cmb_VOD_xml_shema.RecentItemsFileName = "SQlite_LocalDB_FilePath.xml";
            this.cmb_VOD_xml_shema.RecentItemsFolder = "C:\\Users\\logi\\AppData\\Local\\Microsoft\\VisualStudio\\14.0\\ProjectAssemblies\\fcmo62m" +
    "-01\\RecentComboBoxItems";
            this.cmb_VOD_xml_shema.Size = new System.Drawing.Size(411, 23);
            this.cmb_VOD_xml_shema.TabIndex = 21;
            // 
            // btn_Select_Shema
            // 
            this.btn_Select_Shema.Image = ((System.Drawing.Image)(resources.GetObject("btn_Select_Shema.Image")));
            this.btn_Select_Shema.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Select_Shema.Location = new System.Drawing.Point(462, 24);
            this.btn_Select_Shema.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Select_Shema.Name = "btn_Select_Shema";
            this.btn_Select_Shema.Size = new System.Drawing.Size(71, 29);
            this.btn_Select_Shema.TabIndex = 20;
            this.btn_Select_Shema.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Select_Shema.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Select_Shema.UseVisualStyleBackColor = true;
            this.btn_Select_Shema.Click += new System.EventHandler(this.btn_Select_Shema_Click);
            // 
            // lbl_VOD_xml_shema
            // 
            this.lbl_VOD_xml_shema.AutoSize = true;
            this.lbl_VOD_xml_shema.Location = new System.Drawing.Point(18, 9);
            this.lbl_VOD_xml_shema.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_VOD_xml_shema.Name = "lbl_VOD_xml_shema";
            this.lbl_VOD_xml_shema.Size = new System.Drawing.Size(92, 13);
            this.lbl_VOD_xml_shema.TabIndex = 22;
            this.lbl_VOD_xml_shema.Text = "Destination Folder";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.splitContainer1.Location = new System.Drawing.Point(2, 230);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgvx_Glava);
            this.splitContainer1.Panel1.Controls.Add(this.lbl_Glava);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1017, 441);
            this.splitContainer1.SplitterDistance = 68;
            this.splitContainer1.TabIndex = 23;
            // 
            // dgvx_Glava
            // 
            this.dgvx_Glava.AllowUserToAddRows = false;
            this.dgvx_Glava.AllowUserToDeleteRows = false;
            this.dgvx_Glava.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvx_Glava.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvx_Glava.DataGridViewWithRowNumber = false;
            this.dgvx_Glava.Location = new System.Drawing.Point(5, 20);
            this.dgvx_Glava.Name = "dgvx_Glava";
            this.dgvx_Glava.ReadOnly = true;
            this.dgvx_Glava.Size = new System.Drawing.Size(1009, 45);
            this.dgvx_Glava.TabIndex = 1;
            // 
            // lbl_Glava
            // 
            this.lbl_Glava.AutoSize = true;
            this.lbl_Glava.Location = new System.Drawing.Point(6, 4);
            this.lbl_Glava.Name = "lbl_Glava";
            this.lbl_Glava.Size = new System.Drawing.Size(35, 13);
            this.lbl_Glava.TabIndex = 0;
            this.lbl_Glava.Text = "label1";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer3);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer4);
            this.splitContainer2.Size = new System.Drawing.Size(1017, 369);
            this.splitContainer2.SplitterDistance = 500;
            this.splitContainer2.TabIndex = 0;
            // 
            // splitContainer3
            // 
            this.splitContainer3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.lbl_Dokumenti);
            this.splitContainer3.Panel1.Controls.Add(this.dgvx_Dokumenti);
            this.splitContainer3.Size = new System.Drawing.Size(500, 369);
            this.splitContainer3.SplitterDistance = 467;
            this.splitContainer3.TabIndex = 0;
            // 
            // lbl_Dokumenti
            // 
            this.lbl_Dokumenti.AutoSize = true;
            this.lbl_Dokumenti.Location = new System.Drawing.Point(9, 6);
            this.lbl_Dokumenti.Name = "lbl_Dokumenti";
            this.lbl_Dokumenti.Size = new System.Drawing.Size(58, 13);
            this.lbl_Dokumenti.TabIndex = 1;
            this.lbl_Dokumenti.Text = "Dokumenti";
            // 
            // dgvx_Dokumenti
            // 
            this.dgvx_Dokumenti.AllowUserToAddRows = false;
            this.dgvx_Dokumenti.AllowUserToDeleteRows = false;
            this.dgvx_Dokumenti.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvx_Dokumenti.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvx_Dokumenti.DataGridViewWithRowNumber = false;
            this.dgvx_Dokumenti.Location = new System.Drawing.Point(0, 26);
            this.dgvx_Dokumenti.Name = "dgvx_Dokumenti";
            this.dgvx_Dokumenti.ReadOnly = true;
            this.dgvx_Dokumenti.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvx_Dokumenti.Size = new System.Drawing.Size(463, 340);
            this.dgvx_Dokumenti.TabIndex = 0;
            // 
            // splitContainer4
            // 
            this.splitContainer4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.lbl_Knjizbe);
            this.splitContainer4.Panel1.Controls.Add(this.dgvx_Knjizbe);
            this.splitContainer4.Size = new System.Drawing.Size(513, 369);
            this.splitContainer4.SplitterDistance = 484;
            this.splitContainer4.TabIndex = 0;
            // 
            // lbl_Knjizbe
            // 
            this.lbl_Knjizbe.AutoSize = true;
            this.lbl_Knjizbe.Location = new System.Drawing.Point(3, 6);
            this.lbl_Knjizbe.Name = "lbl_Knjizbe";
            this.lbl_Knjizbe.Size = new System.Drawing.Size(41, 13);
            this.lbl_Knjizbe.TabIndex = 2;
            this.lbl_Knjizbe.Text = "Knjizbe";
            // 
            // dgvx_Knjizbe
            // 
            this.dgvx_Knjizbe.AllowUserToAddRows = false;
            this.dgvx_Knjizbe.AllowUserToDeleteRows = false;
            this.dgvx_Knjizbe.AllowUserToOrderColumns = true;
            this.dgvx_Knjizbe.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvx_Knjizbe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvx_Knjizbe.DataGridViewWithRowNumber = false;
            this.dgvx_Knjizbe.Location = new System.Drawing.Point(2, 26);
            this.dgvx_Knjizbe.Name = "dgvx_Knjizbe";
            this.dgvx_Knjizbe.ReadOnly = true;
            this.dgvx_Knjizbe.Size = new System.Drawing.Size(479, 340);
            this.dgvx_Knjizbe.TabIndex = 2;
            // 
            // lbl_Konto_Price_with_tax_for_cash
            // 
            this.lbl_Konto_Price_with_tax_for_cash.AutoSize = true;
            this.lbl_Konto_Price_with_tax_for_cash.Location = new System.Drawing.Point(69, 158);
            this.lbl_Konto_Price_with_tax_for_cash.Name = "lbl_Konto_Price_with_tax_for_cash";
            this.lbl_Konto_Price_with_tax_for_cash.Size = new System.Drawing.Size(167, 13);
            this.lbl_Konto_Price_with_tax_for_cash.TabIndex = 24;
            this.lbl_Konto_Price_with_tax_for_cash.Text = "Znesek_z_ddv Gotovina Konto = ";
            this.lbl_Konto_Price_with_tax_for_cash.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // nmUpDn_Konto_Price_with_tax_for_cash
            // 
            this.nmUpDn_Konto_Price_with_tax_for_cash.Location = new System.Drawing.Point(246, 156);
            this.nmUpDn_Konto_Price_with_tax_for_cash.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nmUpDn_Konto_Price_with_tax_for_cash.Name = "nmUpDn_Konto_Price_with_tax_for_cash";
            this.nmUpDn_Konto_Price_with_tax_for_cash.Size = new System.Drawing.Size(77, 20);
            this.nmUpDn_Konto_Price_with_tax_for_cash.TabIndex = 25;
            this.nmUpDn_Konto_Price_with_tax_for_cash.ValueChanged += new System.EventHandler(this.nmUpDn_Konto_Znesek_z_ddv_ValueChanged);
            // 
            // nmUpDn_Konto_NetPrice
            // 
            this.nmUpDn_Konto_NetPrice.Location = new System.Drawing.Point(927, 191);
            this.nmUpDn_Konto_NetPrice.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nmUpDn_Konto_NetPrice.Name = "nmUpDn_Konto_NetPrice";
            this.nmUpDn_Konto_NetPrice.Size = new System.Drawing.Size(73, 20);
            this.nmUpDn_Konto_NetPrice.TabIndex = 27;
            this.nmUpDn_Konto_NetPrice.ValueChanged += new System.EventHandler(this.nmUpDn_Konto_Osnovna_splosna_stopnja_ValueChanged);
            // 
            // lbl_Konto_Net_price
            // 
            this.lbl_Konto_Net_price.AutoSize = true;
            this.lbl_Konto_Net_price.Location = new System.Drawing.Point(745, 194);
            this.lbl_Konto_Net_price.Name = "lbl_Konto_Net_price";
            this.lbl_Konto_Net_price.Size = new System.Drawing.Size(178, 13);
            this.lbl_Konto_Net_price.TabIndex = 26;
            this.lbl_Konto_Net_price.Text = "Osnovna_splosna_stopnja  Konto = ";
            this.lbl_Konto_Net_price.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // nmUpDn_Konto_VAT_general_rate
            // 
            this.nmUpDn_Konto_VAT_general_rate.Location = new System.Drawing.Point(937, 156);
            this.nmUpDn_Konto_VAT_general_rate.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nmUpDn_Konto_VAT_general_rate.Name = "nmUpDn_Konto_VAT_general_rate";
            this.nmUpDn_Konto_VAT_general_rate.Size = new System.Drawing.Size(63, 20);
            this.nmUpDn_Konto_VAT_general_rate.TabIndex = 29;
            this.nmUpDn_Konto_VAT_general_rate.ValueChanged += new System.EventHandler(this.nmUpDn_Konto_DDV_splosna_stopnja_ValueChanged);
            // 
            // lbl_End_Customers_Code
            // 
            this.lbl_End_Customers_Code.AutoSize = true;
            this.lbl_End_Customers_Code.Location = new System.Drawing.Point(135, 194);
            this.lbl_End_Customers_Code.Name = "lbl_End_Customers_Code";
            this.lbl_End_Customers_Code.Size = new System.Drawing.Size(105, 13);
            this.lbl_End_Customers_Code.TabIndex = 30;
            this.lbl_End_Customers_Code.Text = "Končni kupci Šifra = ";
            this.lbl_End_Customers_Code.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btn_View
            // 
            this.btn_View.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_View.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_View.Location = new System.Drawing.Point(142, 677);
            this.btn_View.Name = "btn_View";
            this.btn_View.Size = new System.Drawing.Size(95, 37);
            this.btn_View.TabIndex = 19;
            this.btn_View.Text = "View";
            this.btn_View.UseVisualStyleBackColor = true;
            this.btn_View.Visible = false;
            this.btn_View.Click += new System.EventHandler(this.btn_View_Click);
            // 
            // nmUpDn_Konto_Price_with_tax_for_payment_cards
            // 
            this.nmUpDn_Konto_Price_with_tax_for_payment_cards.Location = new System.Drawing.Point(608, 156);
            this.nmUpDn_Konto_Price_with_tax_for_payment_cards.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nmUpDn_Konto_Price_with_tax_for_payment_cards.Name = "nmUpDn_Konto_Price_with_tax_for_payment_cards";
            this.nmUpDn_Konto_Price_with_tax_for_payment_cards.Size = new System.Drawing.Size(59, 20);
            this.nmUpDn_Konto_Price_with_tax_for_payment_cards.TabIndex = 33;
            this.nmUpDn_Konto_Price_with_tax_for_payment_cards.ValueChanged += new System.EventHandler(this.nmUpDn_Konto_Price_with_tax_for_payment_cards_ValueChanged);
            // 
            // lbl_Konto_Price_with_tax_for_payment_cards
            // 
            this.lbl_Konto_Price_with_tax_for_payment_cards.AutoSize = true;
            this.lbl_Konto_Price_with_tax_for_payment_cards.Location = new System.Drawing.Point(439, 158);
            this.lbl_Konto_Price_with_tax_for_payment_cards.Name = "lbl_Konto_Price_with_tax_for_payment_cards";
            this.lbl_Konto_Price_with_tax_for_payment_cards.Size = new System.Drawing.Size(163, 13);
            this.lbl_Konto_Price_with_tax_for_payment_cards.TabIndex = 32;
            this.lbl_Konto_Price_with_tax_for_payment_cards.Text = "Znesek_z_ddv  Kartice  Konto = ";
            this.lbl_Konto_Price_with_tax_for_payment_cards.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lbl_Konto_Price_with_tax_for_payment_cards.Click += new System.EventHandler(this.lbl_Konto_Price_with_tax_for_payment_cards_Click);
            // 
            // txt_End_Customers_Name
            // 
            this.txt_End_Customers_Name.Location = new System.Drawing.Point(521, 187);
            this.txt_End_Customers_Name.Name = "txt_End_Customers_Name";
            this.txt_End_Customers_Name.Size = new System.Drawing.Size(180, 20);
            this.txt_End_Customers_Name.TabIndex = 35;
            this.txt_End_Customers_Name.TextChanged += new System.EventHandler(this.txt_End_Customers_Name_TextChanged);
            // 
            // lbl_End_Customes_Name
            // 
            this.lbl_End_Customes_Name.AutoSize = true;
            this.lbl_End_Customes_Name.Location = new System.Drawing.Point(414, 191);
            this.lbl_End_Customes_Name.Name = "lbl_End_Customes_Name";
            this.lbl_End_Customes_Name.Size = new System.Drawing.Size(101, 13);
            this.lbl_End_Customes_Name.TabIndex = 34;
            this.lbl_End_Customes_Name.Text = "Končni kupci Ime = ";
            this.lbl_End_Customes_Name.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // nmUpDn_End_Customers_Code
            // 
            this.nmUpDn_End_Customers_Code.Location = new System.Drawing.Point(246, 191);
            this.nmUpDn_End_Customers_Code.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nmUpDn_End_Customers_Code.Name = "nmUpDn_End_Customers_Code";
            this.nmUpDn_End_Customers_Code.Size = new System.Drawing.Size(59, 20);
            this.nmUpDn_End_Customers_Code.TabIndex = 36;
            this.nmUpDn_End_Customers_Code.ValueChanged += new System.EventHandler(this.nmUpDn_End_Customers_Code_ValueChanged);
            // 
            // lbl_Konto_VAT_general_rate
            // 
            this.lbl_Konto_VAT_general_rate.AutoSize = true;
            this.lbl_Konto_VAT_general_rate.Location = new System.Drawing.Point(760, 158);
            this.lbl_Konto_VAT_general_rate.Name = "lbl_Konto_VAT_general_rate";
            this.lbl_Konto_VAT_general_rate.Size = new System.Drawing.Size(163, 13);
            this.lbl_Konto_VAT_general_rate.TabIndex = 37;
            this.lbl_Konto_VAT_general_rate.Text = "Znesek_z_ddv  Kartice  Konto = ";
            this.lbl_Konto_VAT_general_rate.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // Form_VODxml_OPAL_output
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1026, 716);
            this.Controls.Add(this.lbl_Konto_VAT_general_rate);
            this.Controls.Add(this.nmUpDn_End_Customers_Code);
            this.Controls.Add(this.txt_End_Customers_Name);
            this.Controls.Add(this.lbl_End_Customes_Name);
            this.Controls.Add(this.nmUpDn_Konto_Price_with_tax_for_payment_cards);
            this.Controls.Add(this.lbl_Konto_Price_with_tax_for_payment_cards);
            this.Controls.Add(this.lbl_End_Customers_Code);
            this.Controls.Add(this.nmUpDn_Konto_VAT_general_rate);
            this.Controls.Add(this.nmUpDn_Konto_NetPrice);
            this.Controls.Add(this.lbl_Konto_Net_price);
            this.Controls.Add(this.nmUpDn_Konto_Price_with_tax_for_cash);
            this.Controls.Add(this.lbl_Konto_Price_with_tax_for_cash);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.lbl_VOD_xml_shema);
            this.Controls.Add(this.cmb_VOD_xml_shema);
            this.Controls.Add(this.btn_Select_Shema);
            this.Controls.Add(this.btn_View);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.lbl_FileNames);
            this.Controls.Add(this.cmbR_FilePath);
            this.Controls.Add(this.btn_SelectFolder);
            this.Controls.Add(this.lbl_Folder);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_VODxml_OPAL_output";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Form_Backup_SQLite";
            this.Load += new System.EventHandler(this.Form_VODxml_OPAL_output_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvx_Glava)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvx_Dokumenti)).EndInit();
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvx_Knjizbe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmUpDn_Konto_Price_with_tax_for_cash)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmUpDn_Konto_NetPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmUpDn_Konto_VAT_general_rate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmUpDn_Konto_Price_with_tax_for_payment_cards)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmUpDn_End_Customers_Code)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_SelectFolder;
        private System.Windows.Forms.Label lbl_Folder;
        private System.Windows.Forms.Label lbl_FileNames;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Button btn_Cancel;
        internal ComboBox_Recent.ComboBox_RecentList cmbR_FilePath;
        internal ComboBox_Recent.ComboBox_RecentList cmb_VOD_xml_shema;
        private System.Windows.Forms.Button btn_Select_Shema;
        private System.Windows.Forms.Label lbl_VOD_xml_shema;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private DataGridView_2xls.DataGridView2xls dgvx_Glava;
        private System.Windows.Forms.Label lbl_Glava;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Label lbl_Konto_Price_with_tax_for_cash;
        private System.Windows.Forms.NumericUpDown nmUpDn_Konto_Price_with_tax_for_cash;
        private System.Windows.Forms.NumericUpDown nmUpDn_Konto_NetPrice;
        private System.Windows.Forms.Label lbl_Konto_Net_price;
        private System.Windows.Forms.NumericUpDown nmUpDn_Konto_VAT_general_rate;
        private System.Windows.Forms.Label lbl_End_Customers_Code;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.Label lbl_Dokumenti;
        private DataGridView_2xls.DataGridView2xls dgvx_Dokumenti;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.Label lbl_Knjizbe;
        private DataGridView_2xls.DataGridView2xls dgvx_Knjizbe;
        private System.Windows.Forms.Button btn_View;
        private System.Windows.Forms.NumericUpDown nmUpDn_Konto_Price_with_tax_for_payment_cards;
        private System.Windows.Forms.Label lbl_Konto_Price_with_tax_for_payment_cards;
        private System.Windows.Forms.TextBox txt_End_Customers_Name;
        private System.Windows.Forms.Label lbl_End_Customes_Name;
        private System.Windows.Forms.NumericUpDown nmUpDn_End_Customers_Code;
        private System.Windows.Forms.Label lbl_Konto_VAT_general_rate;
    }
}