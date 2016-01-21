namespace ShopC
{
    partial class Form_StockItem_Edit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_StockItem_Edit));
            this.lbl_Item_Stock = new System.Windows.Forms.Label();
            this.lbl_Item = new System.Windows.Forms.Label();
            this.m_usrc_EditTable = new SQLTableControl.TableDocking_Form.usrc_EditTable();
            this.SuspendLayout();
            // 
            // lbl_Item_Stock
            // 
            this.lbl_Item_Stock.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_Item_Stock.Location = new System.Drawing.Point(15, 9);
            this.lbl_Item_Stock.Name = "lbl_Item_Stock";
            this.lbl_Item_Stock.Size = new System.Drawing.Size(301, 29);
            this.lbl_Item_Stock.TabIndex = 1;
            this.lbl_Item_Stock.Text = "Stocks for Item:";
            this.lbl_Item_Stock.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lbl_Item
            // 
            this.lbl_Item.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_Item.Location = new System.Drawing.Point(317, 9);
            this.lbl_Item.Name = "lbl_Item";
            this.lbl_Item.Size = new System.Drawing.Size(502, 29);
            this.lbl_Item.TabIndex = 2;
            this.lbl_Item.Text = "Item Unique Name";
            // 
            // m_usrc_EditTable
            // 
            this.m_usrc_EditTable.AllowUserToAddNew = true;
            this.m_usrc_EditTable.AllowUserToChange = true;
            this.m_usrc_EditTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_usrc_EditTable.GetRandomData = false;
            this.m_usrc_EditTable.Location = new System.Drawing.Point(2, 41);
            this.m_usrc_EditTable.Name = "m_usrc_EditTable";
            this.m_usrc_EditTable.SelectionButtonVisible = true;
            this.m_usrc_EditTable.Size = new System.Drawing.Size(904, 566);
            this.m_usrc_EditTable.TabIndex = 0;
            this.m_usrc_EditTable.Title = "";
            this.m_usrc_EditTable.Title_Color = System.Drawing.SystemColors.ControlText;
            this.m_usrc_EditTable.Title_Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.m_usrc_EditTable.FillTable += new SQLTableControl.TableDocking_Form.usrc_EditTable.delegate_FillTable(this.m_usrc_EditTable_FillTable);
            this.m_usrc_EditTable.SetInputControlProperties += new SQLTableControl.TableDocking_Form.usrc_EditTable.delegate_SetInputControlProperties(this.m_usrc_EditTable_SetInputControlProperties);
            this.m_usrc_EditTable.after_New += new SQLTableControl.TableDocking_Form.usrc_EditTable.delegate_after_New(this.m_usrc_EditTable_after_New);
            this.m_usrc_EditTable.after_InsertInDataBase += new SQLTableControl.TableDocking_Form.usrc_EditTable.delegate_after_InsertInDataBase(this.m_usrc_EditTable_after_InsertInDataBase);
            this.m_usrc_EditTable.after_UpdateDataBase += new SQLTableControl.TableDocking_Form.usrc_EditTable.delegate_after_UpdateDataBase(this.m_usrc_EditTable_after_UpdateDataBase);
            this.m_usrc_EditTable.RowReferenceFromTable_Check_NoChangeToOther += new SQLTableControl.TableDocking_Form.usrc_EditTable.delegate_RowReferenceFromTable_Check_NoChangeToOther(this.m_usrc_EditTable_RowReferenceFromTable_Check_NoChangeToOther);
            // 
            // Form_StockItem_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(905, 607);
            this.Controls.Add(this.lbl_Item);
            this.Controls.Add(this.lbl_Item_Stock);
            this.Controls.Add(this.m_usrc_EditTable);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_StockItem_Edit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Item_EditForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_ItemStock_Edit_FormClosing);
            this.Load += new System.EventHandler(this.Stock_EditForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private SQLTableControl.TableDocking_Form.usrc_EditTable m_usrc_EditTable;
        private System.Windows.Forms.Label lbl_Item_Stock;
        private System.Windows.Forms.Label lbl_Item;



    }
}