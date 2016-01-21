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
            this.dgv_SelectedSimpleItems = new System.Windows.Forms.DataGridView();
            this.pnl_DataGrid = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgv_SimpleItems = new System.Windows.Forms.DataGridView();
            this.usrc_Item_Group_Handler = new usrc_Item_Group_Handler.usrc_Item_Group_Handler();
            this.lbl_SelectedSimpleItems = new System.Windows.Forms.Label();
            this.lbl_GroupPath = new System.Windows.Forms.Label();
            this.btn_edit_SimpleItems = new System.Windows.Forms.Button();
            this.lbl_SimpleItems = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_SelectedSimpleItems)).BeginInit();
            this.pnl_DataGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_SimpleItems)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer2
            // 
            this.splitContainer2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer2.Location = new System.Drawing.Point(2, 26);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(2);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.dgv_SelectedSimpleItems);
            this.splitContainer2.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.pnl_DataGrid);
            this.splitContainer2.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer2.Size = new System.Drawing.Size(810, 416);
            this.splitContainer2.SplitterDistance = 330;
            this.splitContainer2.SplitterWidth = 3;
            this.splitContainer2.TabIndex = 1;
            // 
            // dgv_SelectedSimpleItems
            // 
            this.dgv_SelectedSimpleItems.AllowUserToAddRows = false;
            this.dgv_SelectedSimpleItems.AllowUserToDeleteRows = false;
            this.dgv_SelectedSimpleItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_SelectedSimpleItems.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgv_SelectedSimpleItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_SelectedSimpleItems.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_SelectedSimpleItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_SelectedSimpleItems.GridColor = System.Drawing.SystemColors.ControlText;
            this.dgv_SelectedSimpleItems.Location = new System.Drawing.Point(0, 0);
            this.dgv_SelectedSimpleItems.Margin = new System.Windows.Forms.Padding(2);
            this.dgv_SelectedSimpleItems.Name = "dgv_SelectedSimpleItems";
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.dgv_SelectedSimpleItems.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_SelectedSimpleItems.RowTemplate.Height = 24;
            this.dgv_SelectedSimpleItems.Size = new System.Drawing.Size(330, 416);
            this.dgv_SelectedSimpleItems.TabIndex = 0;
            this.dgv_SelectedSimpleItems.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_SelectedSimpleItems_CellMouseUp);
            // 
            // pnl_DataGrid
            // 
            this.pnl_DataGrid.Controls.Add(this.splitContainer1);
            this.pnl_DataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_DataGrid.Location = new System.Drawing.Point(0, 0);
            this.pnl_DataGrid.Name = "pnl_DataGrid";
            this.pnl_DataGrid.Size = new System.Drawing.Size(477, 416);
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
            this.splitContainer1.Panel1.Controls.Add(this.dgv_SimpleItems);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.usrc_Item_Group_Handler);
            this.splitContainer1.Size = new System.Drawing.Size(477, 416);
            this.splitContainer1.SplitterDistance = 328;
            this.splitContainer1.TabIndex = 21;
            // 
            // dgv_SimpleItems
            // 
            this.dgv_SimpleItems.AllowUserToAddRows = false;
            this.dgv_SimpleItems.AllowUserToDeleteRows = false;
            this.dgv_SimpleItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv_SimpleItems.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgv_SimpleItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_SimpleItems.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_SimpleItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_SimpleItems.Location = new System.Drawing.Point(0, 0);
            this.dgv_SimpleItems.Margin = new System.Windows.Forms.Padding(2);
            this.dgv_SimpleItems.MultiSelect = false;
            this.dgv_SimpleItems.Name = "dgv_SimpleItems";
            this.dgv_SimpleItems.ReadOnly = true;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(0, 5, 0, 10);
            this.dgv_SimpleItems.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgv_SimpleItems.RowTemplate.Height = 32;
            this.dgv_SimpleItems.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_SimpleItems.Size = new System.Drawing.Size(328, 416);
            this.dgv_SimpleItems.TabIndex = 1;
            this.dgv_SimpleItems.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_SimpleItems_CellContentClick);
            this.dgv_SimpleItems.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_SimpleItems_CellMouseDown);
            this.dgv_SimpleItems.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_SimpleItems_CellMouseEnter);
            this.dgv_SimpleItems.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_SimpleItems_CellMouseLeave);
            this.dgv_SimpleItems.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_SimpleItems_CellMouseUp);
            // 
            // usrc_Item_Group_Handler
            // 
            this.usrc_Item_Group_Handler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.usrc_Item_Group_Handler.Location = new System.Drawing.Point(0, 0);
            this.usrc_Item_Group_Handler.Name = "usrc_Item_Group_Handler";
            this.usrc_Item_Group_Handler.Size = new System.Drawing.Size(145, 416);
            this.usrc_Item_Group_Handler.TabIndex = 20;
            this.usrc_Item_Group_Handler.GroupsRedefined += new usrc_Item_Group_Handler.usrc_Item_Group_Handler.delegate_GroupsRedefined(this.usrc_Item_Group_Handler_GroupsRedefined);
            this.usrc_Item_Group_Handler.PaintGroup += new usrc_Item_Group_Handler.usrc_Item_Group_Handler.delegate_PaintGroup(this.usrc_Item_Group_Handler_GroupChanged);
            // 
            // lbl_SelectedSimpleItems
            // 
            this.lbl_SelectedSimpleItems.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_SelectedSimpleItems.AutoSize = true;
            this.lbl_SelectedSimpleItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_SelectedSimpleItems.Location = new System.Drawing.Point(3, 2);
            this.lbl_SelectedSimpleItems.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_SelectedSimpleItems.Name = "lbl_SelectedSimpleItems";
            this.lbl_SelectedSimpleItems.Size = new System.Drawing.Size(148, 17);
            this.lbl_SelectedSimpleItems.TabIndex = 3;
            this.lbl_SelectedSimpleItems.Text = "Opravljene Storitve";
            // 
            // lbl_GroupPath
            // 
            this.lbl_GroupPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_GroupPath.AutoSize = true;
            this.lbl_GroupPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_GroupPath.Location = new System.Drawing.Point(332, 6);
            this.lbl_GroupPath.Name = "lbl_GroupPath";
            this.lbl_GroupPath.Size = new System.Drawing.Size(20, 16);
            this.lbl_GroupPath.TabIndex = 21;
            this.lbl_GroupPath.Text = "...";
            // 
            // btn_edit_SimpleItems
            // 
            this.btn_edit_SimpleItems.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_edit_SimpleItems.Image = Properties.Resources.Edit;
            this.btn_edit_SimpleItems.Location = new System.Drawing.Point(766, 0);
            this.btn_edit_SimpleItems.Name = "btn_edit_SimpleItems";
            this.btn_edit_SimpleItems.Size = new System.Drawing.Size(32, 25);
            this.btn_edit_SimpleItems.TabIndex = 18;
            this.btn_edit_SimpleItems.UseVisualStyleBackColor = true;
            this.btn_edit_SimpleItems.Click += new System.EventHandler(this.btn_edit_SimpleItems_Click);
            // 
            // lbl_SimpleItems
            // 
            this.lbl_SimpleItems.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_SimpleItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_SimpleItems.Location = new System.Drawing.Point(616, 5);
            this.lbl_SimpleItems.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_SimpleItems.Name = "lbl_SimpleItems";
            this.lbl_SimpleItems.Size = new System.Drawing.Size(146, 17);
            this.lbl_SimpleItems.TabIndex = 4;
            this.lbl_SimpleItems.Text = "Storitve";
            this.lbl_SimpleItems.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // usrc_SimpleItemMan
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.lbl_GroupPath);
            this.Controls.Add(this.lbl_SelectedSimpleItems);
            this.Controls.Add(this.splitContainer2);
            this.Controls.Add(this.lbl_SimpleItems);
            this.Controls.Add(this.btn_edit_SimpleItems);
            this.Name = "usrc_SimpleItemMan";
            this.Size = new System.Drawing.Size(810, 444);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_SelectedSimpleItems)).EndInit();
            this.pnl_DataGrid.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_SimpleItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Label lbl_SelectedSimpleItems;
        internal System.Windows.Forms.DataGridView dgv_SelectedSimpleItems;
        private System.Windows.Forms.Button btn_edit_SimpleItems;
        private System.Windows.Forms.Label lbl_SimpleItems;
        internal System.Windows.Forms.DataGridView dgv_SimpleItems;
        private System.Windows.Forms.Panel pnl_DataGrid;
        private usrc_Item_Group_Handler.usrc_Item_Group_Handler usrc_Item_Group_Handler;
        private System.Windows.Forms.Label lbl_GroupPath;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}
