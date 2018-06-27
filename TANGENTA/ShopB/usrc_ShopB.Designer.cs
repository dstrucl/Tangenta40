namespace ShopB
{
    partial class usrc_ShopB
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.dgv_SelectedShopB_Items = new System.Windows.Forms.DataGridView();
            this.pnl_DataGrid = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgv_ShopB_Items = new System.Windows.Forms.DataGridView();
            this.m_usrc_Item_Group_Handler = new usrc_Item_Group_Handler.usrc_Item_Group_Handler();
            this.lbl_ShopB_Name = new System.Windows.Forms.Label();
            this.lbl_GroupPath = new System.Windows.Forms.Label();
            this.btn_edit_ShopB_Items = new System.Windows.Forms.Button();
            this.lbl_ShopB_Items = new System.Windows.Forms.Label();
            this.usrc_PriceList1 = new PriseLists.usrc_PriceList();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_SelectedShopB_Items)).BeginInit();
            this.pnl_DataGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ShopB_Items)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer2
            // 
            this.splitContainer2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer2.Location = new System.Drawing.Point(2, 30);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(2);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.dgv_SelectedShopB_Items);
            this.splitContainer2.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.pnl_DataGrid);
            this.splitContainer2.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer2.Size = new System.Drawing.Size(810, 409);
            this.splitContainer2.SplitterDistance = 330;
            this.splitContainer2.SplitterWidth = 3;
            this.splitContainer2.TabIndex = 1;
            // 
            // dgv_SelectedShopB_Items
            // 
            this.dgv_SelectedShopB_Items.AllowUserToAddRows = false;
            this.dgv_SelectedShopB_Items.AllowUserToDeleteRows = false;
            this.dgv_SelectedShopB_Items.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgv_SelectedShopB_Items.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgv_SelectedShopB_Items.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_SelectedShopB_Items.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_SelectedShopB_Items.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_SelectedShopB_Items.GridColor = System.Drawing.SystemColors.ControlText;
            this.dgv_SelectedShopB_Items.Location = new System.Drawing.Point(0, 0);
            this.dgv_SelectedShopB_Items.Margin = new System.Windows.Forms.Padding(2);
            this.dgv_SelectedShopB_Items.Name = "dgv_SelectedShopB_Items";
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.dgv_SelectedShopB_Items.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_SelectedShopB_Items.RowTemplate.Height = 24;
            this.dgv_SelectedShopB_Items.Size = new System.Drawing.Size(330, 409);
            this.dgv_SelectedShopB_Items.TabIndex = 0;
            this.dgv_SelectedShopB_Items.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_SelectedShopB_Items_CellMouseUp);
            // 
            // pnl_DataGrid
            // 
            this.pnl_DataGrid.Controls.Add(this.splitContainer1);
            this.pnl_DataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_DataGrid.Location = new System.Drawing.Point(0, 0);
            this.pnl_DataGrid.Name = "pnl_DataGrid";
            this.pnl_DataGrid.Size = new System.Drawing.Size(477, 409);
            this.pnl_DataGrid.TabIndex = 19;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgv_ShopB_Items);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.m_usrc_Item_Group_Handler);
            this.splitContainer1.Size = new System.Drawing.Size(477, 409);
            this.splitContainer1.SplitterDistance = 328;
            this.splitContainer1.TabIndex = 21;
            // 
            // dgv_ShopB_Items
            // 
            this.dgv_ShopB_Items.AllowUserToAddRows = false;
            this.dgv_ShopB_Items.AllowUserToDeleteRows = false;
            this.dgv_ShopB_Items.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv_ShopB_Items.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_ShopB_Items.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_ShopB_Items.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_ShopB_Items.Location = new System.Drawing.Point(0, 0);
            this.dgv_ShopB_Items.Margin = new System.Windows.Forms.Padding(2);
            this.dgv_ShopB_Items.MultiSelect = false;
            this.dgv_ShopB_Items.Name = "dgv_ShopB_Items";
            this.dgv_ShopB_Items.ReadOnly = true;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(0, 5, 0, 10);
            this.dgv_ShopB_Items.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgv_ShopB_Items.RowTemplate.Height = 48;
            this.dgv_ShopB_Items.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_ShopB_Items.Size = new System.Drawing.Size(328, 409);
            this.dgv_ShopB_Items.TabIndex = 1;
            this.dgv_ShopB_Items.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_ShopB_Items_CellContentClick);
            this.dgv_ShopB_Items.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_ShopB_Items_CellMouseDown);
            this.dgv_ShopB_Items.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_ShopB_Items_CellMouseEnter);
            this.dgv_ShopB_Items.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_ShopB_Items_CellMouseLeave);
            this.dgv_ShopB_Items.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_ShopB_Items_CellMouseUp);
            // 
            // m_usrc_Item_Group_Handler
            // 
            this.m_usrc_Item_Group_Handler.Button_Height = 32;
            this.m_usrc_Item_Group_Handler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_usrc_Item_Group_Handler.Font_Height = 10;
            this.m_usrc_Item_Group_Handler.Location = new System.Drawing.Point(0, 0);
            this.m_usrc_Item_Group_Handler.Name = "m_usrc_Item_Group_Handler";
            this.m_usrc_Item_Group_Handler.ShopName = "";
            this.m_usrc_Item_Group_Handler.Size = new System.Drawing.Size(145, 409);
            this.m_usrc_Item_Group_Handler.TabIndex = 20;
            this.m_usrc_Item_Group_Handler.GroupsRedefined += new usrc_Item_Group_Handler.usrc_Item_Group_Handler.delegate_GroupsRedefined(this.usrc_Item_Group_Handler_GroupsRedefined);
            this.m_usrc_Item_Group_Handler.PaintGroup += new usrc_Item_Group_Handler.usrc_Item_Group_Handler.delegate_PaintGroup(this.usrc_Item_Group_Handler_GroupChanged);
            // 
            // lbl_ShopB_Name
            // 
            this.lbl_ShopB_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_ShopB_Name.Location = new System.Drawing.Point(5, 5);
            this.lbl_ShopB_Name.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_ShopB_Name.Name = "lbl_ShopB_Name";
            this.lbl_ShopB_Name.Size = new System.Drawing.Size(142, 17);
            this.lbl_ShopB_Name.TabIndex = 3;
            this.lbl_ShopB_Name.Text = "Shop B";
            // 
            // lbl_GroupPath
            // 
            this.lbl_GroupPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_GroupPath.AutoSize = true;
            this.lbl_GroupPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_GroupPath.Location = new System.Drawing.Point(442, 5);
            this.lbl_GroupPath.Name = "lbl_GroupPath";
            this.lbl_GroupPath.Size = new System.Drawing.Size(20, 16);
            this.lbl_GroupPath.TabIndex = 21;
            this.lbl_GroupPath.Text = "...";
            // 
            // btn_edit_ShopB_Items
            // 
            this.btn_edit_ShopB_Items.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_edit_ShopB_Items.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_edit_ShopB_Items.Image = global::ShopB.Properties.Resources.Edit;
            this.btn_edit_ShopB_Items.Location = new System.Drawing.Point(742, 1);
            this.btn_edit_ShopB_Items.Name = "btn_edit_ShopB_Items";
            this.btn_edit_ShopB_Items.Size = new System.Drawing.Size(32, 25);
            this.btn_edit_ShopB_Items.TabIndex = 18;
            this.btn_edit_ShopB_Items.UseVisualStyleBackColor = false;
            this.btn_edit_ShopB_Items.Click += new System.EventHandler(this.btn_edit_ShopB_Items_Click);
            // 
            // lbl_ShopB_Items
            // 
            this.lbl_ShopB_Items.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_ShopB_Items.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_ShopB_Items.Location = new System.Drawing.Point(594, 6);
            this.lbl_ShopB_Items.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_ShopB_Items.Name = "lbl_ShopB_Items";
            this.lbl_ShopB_Items.Size = new System.Drawing.Size(146, 17);
            this.lbl_ShopB_Items.TabIndex = 4;
            this.lbl_ShopB_Items.Text = "Items B";
            this.lbl_ShopB_Items.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // usrc_PriceList1
            // 
            this.usrc_PriceList1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.usrc_PriceList1.Location = new System.Drawing.Point(150, 2);
            this.usrc_PriceList1.Name = "usrc_PriceList1";
            this.usrc_PriceList1.Size = new System.Drawing.Size(260, 24);
            this.usrc_PriceList1.TabIndex = 22;
            this.usrc_PriceList1.PriceListChanged += new PriseLists.usrc_PriceList.delegate_PriceListChanged(this.usrc_PriceList1_PriceListChanged);
            this.usrc_PriceList1.CheckAccess += new PriseLists.usrc_PriceList.delegate_CheckAccess(this.usrc_PriceList1_CheckAccess);
            // 
            // usrc_ShopB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.lbl_ShopB_Name);
            this.Controls.Add(this.usrc_PriceList1);
            this.Controls.Add(this.lbl_GroupPath);
            this.Controls.Add(this.splitContainer2);
            this.Controls.Add(this.lbl_ShopB_Items);
            this.Controls.Add(this.btn_edit_ShopB_Items);
            this.Name = "usrc_ShopB";
            this.Size = new System.Drawing.Size(810, 441);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_SelectedShopB_Items)).EndInit();
            this.pnl_DataGrid.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ShopB_Items)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Label lbl_ShopB_Name;
        internal System.Windows.Forms.DataGridView dgv_SelectedShopB_Items;
        private System.Windows.Forms.Button btn_edit_ShopB_Items;
        private System.Windows.Forms.Label lbl_ShopB_Items;
        internal System.Windows.Forms.DataGridView dgv_ShopB_Items;
        private System.Windows.Forms.Panel pnl_DataGrid;
        private usrc_Item_Group_Handler.usrc_Item_Group_Handler m_usrc_Item_Group_Handler;
        private System.Windows.Forms.Label lbl_GroupPath;
        private System.Windows.Forms.SplitContainer splitContainer1;
        public PriseLists.usrc_PriceList usrc_PriceList1;
    }
}
