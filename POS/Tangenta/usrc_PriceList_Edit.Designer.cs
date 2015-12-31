namespace Tangenta
{
    partial class usrc_PriceList_Edit
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
            this.btn_OK = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.usrc_EditTable_PriceList = new SQLTableControl.TableDocking_Form.usrc_EditTable();
            this.chk_Items = new System.Windows.Forms.CheckBox();
            this.chk_View_SimpleItems = new System.Windows.Forms.CheckBox();
            this.txt_PriceList_Name = new System.Windows.Forms.TextBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.usrc_EditTable_SimpleItem = new SQLTableControl.TableDocking_Form.usrc_EditTable();
            this.usrc_EditTable_Item = new SQLTableControl.TableDocking_Form.usrc_EditTable();
            this.lbl_PriceList_Name = new System.Windows.Forms.Label();
            this.rdb_OnlyUnvalid = new System.Windows.Forms.RadioButton();
            this.rdb_All = new System.Windows.Forms.RadioButton();
            this.rdb_OnlyValid = new System.Windows.Forms.RadioButton();
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
            // btn_OK
            // 
            this.btn_OK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_OK.Location = new System.Drawing.Point(3, 749);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(55, 24);
            this.btn_OK.TabIndex = 1;
            this.btn_OK.Text = "OK";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Cancel.Location = new System.Drawing.Point(127, 749);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(55, 24);
            this.btn_Cancel.TabIndex = 2;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.usrc_EditTable_PriceList);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.chk_Items);
            this.splitContainer1.Panel2.Controls.Add(this.chk_View_SimpleItems);
            this.splitContainer1.Panel2.Controls.Add(this.txt_PriceList_Name);
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Panel2.Controls.Add(this.lbl_PriceList_Name);
            this.splitContainer1.Size = new System.Drawing.Size(890, 743);
            this.splitContainer1.SplitterDistance = 158;
            this.splitContainer1.TabIndex = 3;
            // 
            // usrc_EditTable_PriceList
            // 
            this.usrc_EditTable_PriceList.AllowUserToAddNew = true;
            this.usrc_EditTable_PriceList.AllowUserToChange = true;
            this.usrc_EditTable_PriceList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.usrc_EditTable_PriceList.GetRandomData = false;
            this.usrc_EditTable_PriceList.Location = new System.Drawing.Point(3, 3);
            this.usrc_EditTable_PriceList.Name = "usrc_EditTable_PriceList";
            this.usrc_EditTable_PriceList.SelectionButtonVisible = false;
            this.usrc_EditTable_PriceList.Size = new System.Drawing.Size(880, 147);
            this.usrc_EditTable_PriceList.TabIndex = 0;
            this.usrc_EditTable_PriceList.Title = "label1";
            this.usrc_EditTable_PriceList.Title_Color = System.Drawing.SystemColors.ControlText;
            this.usrc_EditTable_PriceList.Title_Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.usrc_EditTable_PriceList.before_InsertInDataBase += new SQLTableControl.TableDocking_Form.usrc_EditTable.delegate_before_InsertInDataBase(this.usrc_EditTable_PriceList_before_InsertInDataBase);
            this.usrc_EditTable_PriceList.after_InsertInDataBase += new SQLTableControl.TableDocking_Form.usrc_EditTable.delegate_after_InsertInDataBase(this.usrc_EditTable_PriceList_after_InsertInDataBase);
            this.usrc_EditTable_PriceList.SelectedIndexChanged += new SQLTableControl.TableDocking_Form.usrc_EditTable.delegate_SelectedIndexChanged(this.usrc_EditTable_PriceList_SelectedIndexChanged);
            // 
            // chk_Items
            // 
            this.chk_Items.AutoSize = true;
            this.chk_Items.Checked = true;
            this.chk_Items.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_Items.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.chk_Items.Location = new System.Drawing.Point(491, 8);
            this.chk_Items.Name = "chk_Items";
            this.chk_Items.Size = new System.Drawing.Size(68, 24);
            this.chk_Items.TabIndex = 6;
            this.chk_Items.Text = "Items";
            this.chk_Items.UseVisualStyleBackColor = true;
            this.chk_Items.CheckedChanged += new System.EventHandler(this.chk_Items_CheckedChanged);
            // 
            // chk_View_SimpleItems
            // 
            this.chk_View_SimpleItems.AutoSize = true;
            this.chk_View_SimpleItems.Checked = true;
            this.chk_View_SimpleItems.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_View_SimpleItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.chk_View_SimpleItems.Location = new System.Drawing.Point(385, 8);
            this.chk_View_SimpleItems.Name = "chk_View_SimpleItems";
            this.chk_View_SimpleItems.Size = new System.Drawing.Size(116, 24);
            this.chk_View_SimpleItems.TabIndex = 5;
            this.chk_View_SimpleItems.Text = "SimpleItems";
            this.chk_View_SimpleItems.UseVisualStyleBackColor = true;
            this.chk_View_SimpleItems.CheckedChanged += new System.EventHandler(this.chk_View_SimpleItems_CheckedChanged);
            // 
            // txt_PriceList_Name
            // 
            this.txt_PriceList_Name.Location = new System.Drawing.Point(81, 8);
            this.txt_PriceList_Name.Name = "txt_PriceList_Name";
            this.txt_PriceList_Name.ReadOnly = true;
            this.txt_PriceList_Name.Size = new System.Drawing.Size(268, 20);
            this.txt_PriceList_Name.TabIndex = 4;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer2.Location = new System.Drawing.Point(3, 32);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.usrc_EditTable_SimpleItem);
            this.splitContainer2.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer2_Panel1_Paint);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.usrc_EditTable_Item);
            this.splitContainer2.Size = new System.Drawing.Size(885, 542);
            this.splitContainer2.SplitterDistance = 167;
            this.splitContainer2.TabIndex = 2;
            // 
            // usrc_EditTable_SimpleItem
            // 
            this.usrc_EditTable_SimpleItem.AllowUserToAddNew = false;
            this.usrc_EditTable_SimpleItem.AllowUserToChange = true;
            this.usrc_EditTable_SimpleItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.usrc_EditTable_SimpleItem.GetRandomData = false;
            this.usrc_EditTable_SimpleItem.Location = new System.Drawing.Point(0, 0);
            this.usrc_EditTable_SimpleItem.Name = "usrc_EditTable_SimpleItem";
            this.usrc_EditTable_SimpleItem.SelectionButtonVisible = false;
            this.usrc_EditTable_SimpleItem.Size = new System.Drawing.Size(881, 163);
            this.usrc_EditTable_SimpleItem.TabIndex = 0;
            this.usrc_EditTable_SimpleItem.Title = "label1";
            this.usrc_EditTable_SimpleItem.Title_Color = System.Drawing.SystemColors.ControlText;
            this.usrc_EditTable_SimpleItem.Title_Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.usrc_EditTable_SimpleItem.after_InsertInDataBase += new SQLTableControl.TableDocking_Form.usrc_EditTable.delegate_after_InsertInDataBase(this.usrc_EditTable_PriceList_after_InsertInDataBase);
            this.usrc_EditTable_SimpleItem.CellFormatting += new SQLTableControl.TableDocking_Form.usrc_EditTable.delegate_CellFormatting(this.usrc_EditTable_SimpleItem_CellFormatting);
            this.usrc_EditTable_SimpleItem.RowReferenceFromTable_Check_NoChangeToOther += new SQLTableControl.TableDocking_Form.usrc_EditTable.delegate_RowReferenceFromTable_Check_NoChangeToOther(this.usrc_EditTable_SimpleItem_RowReferenceFromTable_Check_NoChangeToOther);
            // 
            // usrc_EditTable_Item
            // 
            this.usrc_EditTable_Item.AllowUserToAddNew = false;
            this.usrc_EditTable_Item.AllowUserToChange = true;
            this.usrc_EditTable_Item.Dock = System.Windows.Forms.DockStyle.Fill;
            this.usrc_EditTable_Item.GetRandomData = false;
            this.usrc_EditTable_Item.Location = new System.Drawing.Point(0, 0);
            this.usrc_EditTable_Item.Name = "usrc_EditTable_Item";
            this.usrc_EditTable_Item.SelectionButtonVisible = false;
            this.usrc_EditTable_Item.Size = new System.Drawing.Size(881, 367);
            this.usrc_EditTable_Item.TabIndex = 2;
            this.usrc_EditTable_Item.Title = "label1";
            this.usrc_EditTable_Item.Title_Color = System.Drawing.SystemColors.ControlText;
            this.usrc_EditTable_Item.Title_Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.usrc_EditTable_Item.after_InsertInDataBase += new SQLTableControl.TableDocking_Form.usrc_EditTable.delegate_after_InsertInDataBase(this.usrc_EditTable_PriceList_after_InsertInDataBase);
            this.usrc_EditTable_Item.CellFormatting += new SQLTableControl.TableDocking_Form.usrc_EditTable.delegate_CellFormatting(this.usrc_EditTable_Item_CellFormatting);
            // 
            // lbl_PriceList_Name
            // 
            this.lbl_PriceList_Name.Location = new System.Drawing.Point(5, 6);
            this.lbl_PriceList_Name.Name = "lbl_PriceList_Name";
            this.lbl_PriceList_Name.Size = new System.Drawing.Size(70, 23);
            this.lbl_PriceList_Name.TabIndex = 3;
            this.lbl_PriceList_Name.Text = "Cenik:";
            this.lbl_PriceList_Name.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // rdb_OnlyUnvalid
            // 
            this.rdb_OnlyUnvalid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rdb_OnlyUnvalid.AutoSize = true;
            this.rdb_OnlyUnvalid.Location = new System.Drawing.Point(406, 752);
            this.rdb_OnlyUnvalid.Name = "rdb_OnlyUnvalid";
            this.rdb_OnlyUnvalid.Size = new System.Drawing.Size(72, 17);
            this.rdb_OnlyUnvalid.TabIndex = 6;
            this.rdb_OnlyUnvalid.TabStop = true;
            this.rdb_OnlyUnvalid.Text = "Only Valid";
            this.rdb_OnlyUnvalid.UseVisualStyleBackColor = true;
            // 
            // rdb_All
            // 
            this.rdb_All.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rdb_All.AutoSize = true;
            this.rdb_All.Location = new System.Drawing.Point(620, 752);
            this.rdb_All.Name = "rdb_All";
            this.rdb_All.Size = new System.Drawing.Size(36, 17);
            this.rdb_All.TabIndex = 5;
            this.rdb_All.TabStop = true;
            this.rdb_All.Text = "All";
            this.rdb_All.UseVisualStyleBackColor = true;
            // 
            // rdb_OnlyValid
            // 
            this.rdb_OnlyValid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rdb_OnlyValid.AutoSize = true;
            this.rdb_OnlyValid.Location = new System.Drawing.Point(211, 752);
            this.rdb_OnlyValid.Name = "rdb_OnlyValid";
            this.rdb_OnlyValid.Size = new System.Drawing.Size(72, 17);
            this.rdb_OnlyValid.TabIndex = 4;
            this.rdb_OnlyValid.TabStop = true;
            this.rdb_OnlyValid.Text = "Only Valid";
            this.rdb_OnlyValid.UseVisualStyleBackColor = true;
            // 
            // usrc_PriceList_Edit
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.rdb_OnlyUnvalid);
            this.Controls.Add(this.rdb_All);
            this.Controls.Add(this.rdb_OnlyValid);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_OK);
            this.Name = "usrc_PriceList_Edit";
            this.Size = new System.Drawing.Size(896, 773);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        private SQLTableControl.TableDocking_Form.usrc_EditTable usrc_EditTable_PriceList;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private SQLTableControl.TableDocking_Form.usrc_EditTable usrc_EditTable_SimpleItem;
        private System.Windows.Forms.TextBox txt_PriceList_Name;
        private System.Windows.Forms.Label lbl_PriceList_Name;
        private System.Windows.Forms.CheckBox chk_Items;
        private System.Windows.Forms.CheckBox chk_View_SimpleItems;
        private SQLTableControl.TableDocking_Form.usrc_EditTable usrc_EditTable_Item;
        #endregion
        private System.Windows.Forms.RadioButton rdb_OnlyUnvalid;
        private System.Windows.Forms.RadioButton rdb_All;
        private System.Windows.Forms.RadioButton rdb_OnlyValid;
    }
}
