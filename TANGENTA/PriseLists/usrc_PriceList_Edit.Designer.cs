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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(usrc_PriceList_Edit));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.usrc_EditTable_PriceList = new CodeTables.TableDocking_Form.usrc_EditTable();
            this.txt_PriceList_Name = new System.Windows.Forms.TextBox();
            this.lbl_PriceList_Name = new System.Windows.Forms.Label();
            this.usrc_EditTable_Shop_Prices = new CodeTables.TableDocking_Form.usrc_EditTable();
            this.rdb_OnlyUnvalid = new System.Windows.Forms.RadioButton();
            this.rdb_All = new System.Windows.Forms.RadioButton();
            this.rdb_OnlyValid = new System.Windows.Forms.RadioButton();
            this.usrc_NavigationButtons1 = new NavigationButtons.usrc_NavigationButtons();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
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
            this.splitContainer1.Size = new System.Drawing.Size(890, 709);
            this.splitContainer1.SplitterDistance = 150;
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
            this.usrc_EditTable_PriceList.Size = new System.Drawing.Size(880, 139);
            this.usrc_EditTable_PriceList.TabIndex = 0;
            this.usrc_EditTable_PriceList.Title = "label1";
            this.usrc_EditTable_PriceList.Title_Color = System.Drawing.SystemColors.ControlText;
            this.usrc_EditTable_PriceList.Title_Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.usrc_EditTable_PriceList.FillTable += new CodeTables.TableDocking_Form.usrc_EditTable.delegate_FillTable(this.usrc_EditTable_PriceList_FillTable);
            this.usrc_EditTable_PriceList.SetInputControlProperties += new CodeTables.TableDocking_Form.usrc_EditTable.delegate_SetInputControlProperties(this.usrc_EditTable_PriceList_SetInputControlProperties);
            this.usrc_EditTable_PriceList.before_InsertInDataBase += new CodeTables.TableDocking_Form.usrc_EditTable.delegate_before_InsertInDataBase(this.usrc_EditTable_PriceList_before_InsertInDataBase);
            this.usrc_EditTable_PriceList.after_InsertInDataBase += new CodeTables.TableDocking_Form.usrc_EditTable.delegate_after_InsertInDataBase(this.usrc_EditTable_PriceList_after_InsertInDataBase);
            this.usrc_EditTable_PriceList.after_UpdateDataBase += new CodeTables.TableDocking_Form.usrc_EditTable.delegate_after_UpdateDataBase(this.usrc_EditTable_PriceList_after_UpdateDataBase);
            this.usrc_EditTable_PriceList.SelectedIndexChanged += new CodeTables.TableDocking_Form.usrc_EditTable.delegate_SelectedIndexChanged(this.usrc_EditTable_PriceList_SelectedIndexChanged);
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
            this.usrc_EditTable_Shop_Prices.Size = new System.Drawing.Size(881, 514);
            this.usrc_EditTable_Shop_Prices.TabIndex = 7;
            this.usrc_EditTable_Shop_Prices.Title = "label1";
            this.usrc_EditTable_Shop_Prices.Title_Color = System.Drawing.SystemColors.ControlText;
            this.usrc_EditTable_Shop_Prices.Title_Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.usrc_EditTable_Shop_Prices.after_InsertInDataBase += new CodeTables.TableDocking_Form.usrc_EditTable.delegate_after_InsertInDataBase(this.usrc_EditTable_Shop_Prices_after_InsertInDataBase);
            this.usrc_EditTable_Shop_Prices.after_UpdateDataBase += new CodeTables.TableDocking_Form.usrc_EditTable.delegate_after_UpdateDataBase(this.usrc_EditTable_Shop_Prices_after_UpdateDataBase);
            this.usrc_EditTable_Shop_Prices.CellFormatting += new CodeTables.TableDocking_Form.usrc_EditTable.delegate_CellFormatting(this.usrc_EditTable_Shop_Prices_CellFormatting);
            // 
            // rdb_OnlyUnvalid
            // 
            this.rdb_OnlyUnvalid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rdb_OnlyUnvalid.AutoSize = true;
            this.rdb_OnlyUnvalid.Location = new System.Drawing.Point(186, 727);
            this.rdb_OnlyUnvalid.Name = "rdb_OnlyUnvalid";
            this.rdb_OnlyUnvalid.Size = new System.Drawing.Size(85, 17);
            this.rdb_OnlyUnvalid.TabIndex = 6;
            this.rdb_OnlyUnvalid.TabStop = true;
            this.rdb_OnlyUnvalid.Text = "Only Unvalid";
            this.rdb_OnlyUnvalid.UseVisualStyleBackColor = true;
            // 
            // rdb_All
            // 
            this.rdb_All.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rdb_All.AutoSize = true;
            this.rdb_All.Location = new System.Drawing.Point(387, 727);
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
            this.rdb_OnlyValid.Location = new System.Drawing.Point(11, 727);
            this.rdb_OnlyValid.Name = "rdb_OnlyValid";
            this.rdb_OnlyValid.Size = new System.Drawing.Size(72, 17);
            this.rdb_OnlyValid.TabIndex = 4;
            this.rdb_OnlyValid.TabStop = true;
            this.rdb_OnlyValid.Text = "Only Valid";
            this.rdb_OnlyValid.UseVisualStyleBackColor = true;
            // 
            // usrc_NavigationButtons1
            // 
            this.usrc_NavigationButtons1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.usrc_NavigationButtons1.BackColor = System.Drawing.SystemColors.Control;
            this.usrc_NavigationButtons1.btn1_ToolTip_Text = "";
            this.usrc_NavigationButtons1.btn2_ToolTip_Text = "";
            this.usrc_NavigationButtons1.btn3_ToolTip_Text = "";
            this.usrc_NavigationButtons1.Button_NEXT_Enabled = true;
            this.usrc_NavigationButtons1.Buttons = NavigationButtons.Navigation.eButtons.OkCancel;
            this.usrc_NavigationButtons1.ExitQuestion = "Exit Program?";
            this.usrc_NavigationButtons1.Image_Cancel = null;
            this.usrc_NavigationButtons1.Image_EXIT = null;
            this.usrc_NavigationButtons1.Image_NEXT = ((System.Drawing.Image)(resources.GetObject("usrc_NavigationButtons1.Image_NEXT")));
            this.usrc_NavigationButtons1.Image_OK = ((System.Drawing.Image)(resources.GetObject("usrc_NavigationButtons1.Image_OK")));
            this.usrc_NavigationButtons1.Image_PREV = ((System.Drawing.Image)(resources.GetObject("usrc_NavigationButtons1.Image_PREV")));
            this.usrc_NavigationButtons1.Location = new System.Drawing.Point(3, 718);
            this.usrc_NavigationButtons1.Name = "usrc_NavigationButtons1";
            this.usrc_NavigationButtons1.Size = new System.Drawing.Size(890, 63);
            this.usrc_NavigationButtons1.TabIndex = 7;
            this.usrc_NavigationButtons1.Text_Cancel = "Exit";
            this.usrc_NavigationButtons1.Text_EXIT = "Exit";
            this.usrc_NavigationButtons1.Text_NEXT = "";
            this.usrc_NavigationButtons1.Text_OK = "";
            this.usrc_NavigationButtons1.Text_PREV = "";
            this.usrc_NavigationButtons1.Visible_EXIT = true;
            this.usrc_NavigationButtons1.Visible_NEXT = true;
            this.usrc_NavigationButtons1.Visible_PREV = true;
            this.usrc_NavigationButtons1.ButtonPressed += new NavigationButtons.usrc_NavigationButtons.delegate_button_pressed(this.usrc_NavigationButtons1_ButtonPressed);
            // 
            // usrc_PriceList_Edit
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.rdb_OnlyUnvalid);
            this.Controls.Add(this.rdb_All);
            this.Controls.Add(this.rdb_OnlyValid);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.usrc_NavigationButtons1);
            this.Name = "usrc_PriceList_Edit";
            this.Size = new System.Drawing.Size(896, 784);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        private CodeTables.TableDocking_Form.usrc_EditTable usrc_EditTable_PriceList;
        private System.Windows.Forms.SplitContainer splitContainer1;
        #endregion
        private System.Windows.Forms.RadioButton rdb_OnlyUnvalid;
        private System.Windows.Forms.RadioButton rdb_All;
        private System.Windows.Forms.RadioButton rdb_OnlyValid;
        private CodeTables.TableDocking_Form.usrc_EditTable usrc_EditTable_Shop_Prices;
        private System.Windows.Forms.Label lbl_PriceList_Name;
        private System.Windows.Forms.TextBox txt_PriceList_Name;
        private NavigationButtons.usrc_NavigationButtons usrc_NavigationButtons1;
    }
}
