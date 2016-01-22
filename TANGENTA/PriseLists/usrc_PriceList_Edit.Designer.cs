namespace PriseLists
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
            this.txt_PriceList_Name = new System.Windows.Forms.TextBox();
            this.lbl_PriceList_Name = new System.Windows.Forms.Label();
            this.usrc_EditTable_Shop_Prices = new SQLTableControl.TableDocking_Form.usrc_EditTable();
            this.rdb_OnlyUnvalid = new System.Windows.Forms.RadioButton();
            this.rdb_All = new System.Windows.Forms.RadioButton();
            this.rdb_OnlyValid = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
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
            this.splitContainer1.Panel2.Controls.Add(this.txt_PriceList_Name);
            this.splitContainer1.Panel2.Controls.Add(this.lbl_PriceList_Name);
            this.splitContainer1.Panel2.Controls.Add(this.usrc_EditTable_Shop_Prices);
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
            // txt_PriceList_Name
            // 
            this.txt_PriceList_Name.Location = new System.Drawing.Point(81, 8);
            this.txt_PriceList_Name.Name = "txt_PriceList_Name";
            this.txt_PriceList_Name.ReadOnly = true;
            this.txt_PriceList_Name.Size = new System.Drawing.Size(268, 20);
            this.txt_PriceList_Name.TabIndex = 9;
            // 
            // lbl_PriceList_Name
            // 
            this.lbl_PriceList_Name.Location = new System.Drawing.Point(5, 6);
            this.lbl_PriceList_Name.Name = "lbl_PriceList_Name";
            this.lbl_PriceList_Name.Size = new System.Drawing.Size(70, 23);
            this.lbl_PriceList_Name.TabIndex = 8;
            this.lbl_PriceList_Name.Text = "Cenik:";
            this.lbl_PriceList_Name.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // usrc_EditTable_Shop_Prices
            // 
            this.usrc_EditTable_Shop_Prices.AllowUserToAddNew = false;
            this.usrc_EditTable_Shop_Prices.AllowUserToChange = true;
            this.usrc_EditTable_Shop_Prices.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.usrc_EditTable_Shop_Prices.GetRandomData = false;
            this.usrc_EditTable_Shop_Prices.Location = new System.Drawing.Point(3, 34);
            this.usrc_EditTable_Shop_Prices.Name = "usrc_EditTable_Shop_Prices";
            this.usrc_EditTable_Shop_Prices.SelectionButtonVisible = false;
            this.usrc_EditTable_Shop_Prices.Size = new System.Drawing.Size(881, 540);
            this.usrc_EditTable_Shop_Prices.TabIndex = 7;
            this.usrc_EditTable_Shop_Prices.Title = "label1";
            this.usrc_EditTable_Shop_Prices.Title_Color = System.Drawing.SystemColors.ControlText;
            this.usrc_EditTable_Shop_Prices.Title_Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.usrc_EditTable_Shop_Prices.CellFormatting += new SQLTableControl.TableDocking_Form.usrc_EditTable.delegate_CellFormatting(this.usrc_EditTable_Shop_Prices_CellFormatting);
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        private SQLTableControl.TableDocking_Form.usrc_EditTable usrc_EditTable_PriceList;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.SplitContainer splitContainer1;
        #endregion
        private System.Windows.Forms.RadioButton rdb_OnlyUnvalid;
        private System.Windows.Forms.RadioButton rdb_All;
        private System.Windows.Forms.RadioButton rdb_OnlyValid;
        private SQLTableControl.TableDocking_Form.usrc_EditTable usrc_EditTable_Shop_Prices;
        private System.Windows.Forms.Label lbl_PriceList_Name;
        private System.Windows.Forms.TextBox txt_PriceList_Name;
    }
}
