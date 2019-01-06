namespace DocumentManager
{
    partial class usrc_Price_ItemOrSimpleItem
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
            this.lbl_PriceListType = new System.Windows.Forms.Label();
            this.txt_PriceListType = new System.Windows.Forms.TextBox();
            this.usrc_EditTable = new CodeTables.TableDocking_Form.usrc_EditTable();
            this.SuspendLayout();
            // 
            // lbl_PriceListType
            // 
            this.lbl_PriceListType.AutoSize = true;
            this.lbl_PriceListType.Location = new System.Drawing.Point(6, 4);
            this.lbl_PriceListType.Name = "lbl_PriceListType";
            this.lbl_PriceListType.Size = new System.Drawing.Size(73, 13);
            this.lbl_PriceListType.TabIndex = 1;
            this.lbl_PriceListType.Text = "PriceList Item:";
            // 
            // txt_PriceListType
            // 
            this.txt_PriceListType.Location = new System.Drawing.Point(89, 1);
            this.txt_PriceListType.Name = "txt_PriceListType";
            this.txt_PriceListType.Size = new System.Drawing.Size(134, 20);
            this.txt_PriceListType.TabIndex = 2;
            // 
            // usrc_EditTable
            // 
            this.usrc_EditTable.AllowUserToAddNew = true;
            this.usrc_EditTable.AllowUserToChange = true;
            this.usrc_EditTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.usrc_EditTable.GetRandomData = true;
            this.usrc_EditTable.Location = new System.Drawing.Point(6, 32);
            this.usrc_EditTable.Name = "usrc_EditTable";
            this.usrc_EditTable.SelectionButtonVisible = true;
            this.usrc_EditTable.Size = new System.Drawing.Size(391, 271);
            this.usrc_EditTable.TabIndex = 3;
            this.usrc_EditTable.Title = "";
            this.usrc_EditTable.Title_Color = System.Drawing.SystemColors.ControlText;
            this.usrc_EditTable.Title_Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            // 
            // usrc_Price_ItemOrSimpleItem
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.usrc_EditTable);
            this.Controls.Add(this.txt_PriceListType);
            this.Controls.Add(this.lbl_PriceListType);
            this.Name = "usrc_Price_ItemOrSimpleItem";
            this.Size = new System.Drawing.Size(398, 304);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_PriceListType;
        private System.Windows.Forms.TextBox txt_PriceListType;
        private CodeTables.TableDocking_Form.usrc_EditTable usrc_EditTable;
    }
}
