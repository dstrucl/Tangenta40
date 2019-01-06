namespace TangentaCore
{
    partial class usrc_PurchasePrice_Edit
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
            this.usrc_EditTable_PurchasePriceList = new CodeTables.TableDocking_Form.usrc_EditTable();
            this.usrc_EditTable_PurchaseItem = new CodeTables.TableDocking_Form.usrc_EditTable();
            this.txt_PriceList_Name = new System.Windows.Forms.TextBox();
            this.lbl_PurchasePrice_Date = new System.Windows.Forms.Label();
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
            this.splitContainer1.Panel1.Controls.Add(this.usrc_EditTable_PurchasePriceList);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.usrc_EditTable_PurchaseItem);
            this.splitContainer1.Panel2.Controls.Add(this.txt_PriceList_Name);
            this.splitContainer1.Panel2.Controls.Add(this.lbl_PurchasePrice_Date);
            this.splitContainer1.Size = new System.Drawing.Size(890, 743);
            this.splitContainer1.SplitterDistance = 158;
            this.splitContainer1.TabIndex = 3;
            // 
            // usrc_EditTable_PurchasePriceList
            // 
            this.usrc_EditTable_PurchasePriceList.AllowUserToAddNew = true;
            this.usrc_EditTable_PurchasePriceList.AllowUserToChange = true;
            this.usrc_EditTable_PurchasePriceList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.usrc_EditTable_PurchasePriceList.GetRandomData = false;
            this.usrc_EditTable_PurchasePriceList.Location = new System.Drawing.Point(3, 3);
            this.usrc_EditTable_PurchasePriceList.Name = "usrc_EditTable_PurchasePriceList";
            this.usrc_EditTable_PurchasePriceList.SelectionButtonVisible = true;
            this.usrc_EditTable_PurchasePriceList.Size = new System.Drawing.Size(880, 147);
            this.usrc_EditTable_PurchasePriceList.TabIndex = 0;
            this.usrc_EditTable_PurchasePriceList.Title = "label1";
            this.usrc_EditTable_PurchasePriceList.Title_Color = System.Drawing.SystemColors.ControlText;
            this.usrc_EditTable_PurchasePriceList.Title_Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.usrc_EditTable_PurchasePriceList.before_InsertInDataBase += new CodeTables.TableDocking_Form.usrc_EditTable.delegate_before_InsertInDataBase(this.usrc_EditTable_PurchasePrice_before_InsertInDataBase);
            this.usrc_EditTable_PurchasePriceList.after_InsertInDataBase += new CodeTables.TableDocking_Form.usrc_EditTable.delegate_after_InsertInDataBase(this.usrc_EditTable_PurchasePrice_after_InsertInDataBase);
            this.usrc_EditTable_PurchasePriceList.SelectedIndexChanged += new CodeTables.TableDocking_Form.usrc_EditTable.delegate_SelectedIndexChanged(this.usrc_EditTable_PriceList_SelectedIndexChanged);
            // 
            // usrc_EditTable_PurchaseItem
            // 
            this.usrc_EditTable_PurchaseItem.AllowUserToAddNew = false;
            this.usrc_EditTable_PurchaseItem.AllowUserToChange = true;
            this.usrc_EditTable_PurchaseItem.GetRandomData = false;
            this.usrc_EditTable_PurchaseItem.Location = new System.Drawing.Point(3, 34);
            this.usrc_EditTable_PurchaseItem.Name = "usrc_EditTable_PurchaseItem";
            this.usrc_EditTable_PurchaseItem.SelectionButtonVisible = true;
            this.usrc_EditTable_PurchaseItem.Size = new System.Drawing.Size(881, 540);
            this.usrc_EditTable_PurchaseItem.TabIndex = 5;
            this.usrc_EditTable_PurchaseItem.Title = "label1";
            this.usrc_EditTable_PurchaseItem.Title_Color = System.Drawing.SystemColors.ControlText;
            this.usrc_EditTable_PurchaseItem.Title_Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            // 
            // txt_PriceList_Name
            // 
            this.txt_PriceList_Name.Location = new System.Drawing.Point(121, 8);
            this.txt_PriceList_Name.Name = "txt_PriceList_Name";
            this.txt_PriceList_Name.ReadOnly = true;
            this.txt_PriceList_Name.Size = new System.Drawing.Size(268, 20);
            this.txt_PriceList_Name.TabIndex = 4;
            // 
            // lbl_PurchasePrice_Date
            // 
            this.lbl_PurchasePrice_Date.Location = new System.Drawing.Point(5, 6);
            this.lbl_PurchasePrice_Date.Name = "lbl_PurchasePrice_Date";
            this.lbl_PurchasePrice_Date.Size = new System.Drawing.Size(110, 23);
            this.lbl_PurchasePrice_Date.TabIndex = 3;
            this.lbl_PurchasePrice_Date.Text = "NABAVNI CENIK:";
            this.lbl_PurchasePrice_Date.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // usrc_PurchasePrice_Edit
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_OK);
            this.Name = "usrc_PurchasePrice_Edit";
            this.Size = new System.Drawing.Size(896, 773);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }


        private CodeTables.TableDocking_Form.usrc_EditTable usrc_EditTable_PurchasePriceList;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox txt_PriceList_Name;
        private System.Windows.Forms.Label lbl_PurchasePrice_Date;

        #endregion
        private CodeTables.TableDocking_Form.usrc_EditTable usrc_EditTable_PurchaseItem;
    }
}
