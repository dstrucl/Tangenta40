using TangentaDB;

namespace ShopC
{
    partial class usrc_Atom_ItemsList1366x768
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
            this.components = new System.ComponentModel.Container();
            this.btn_ClearAll = new System.Windows.Forms.Button();
            this.lbl_InvoiceInfo = new System.Windows.Forms.Label();
            this.usrc_Item_InsidePageHandler_ItemAtomList = new usrc_Item_InsidePageHandler_Doc_ShopC_Item();
            this.ContextMenuStrip_DocInfo = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showTablesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextMenuStrip_DocInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_ClearAll
            // 
            this.btn_ClearAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_ClearAll.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_ClearAll.Image = global::ShopC.Properties.Resources.RemoveAll;
            this.btn_ClearAll.Location = new System.Drawing.Point(334, 0);
            this.btn_ClearAll.Name = "btn_ClearAll";
            this.btn_ClearAll.Size = new System.Drawing.Size(61, 40);
            this.btn_ClearAll.TabIndex = 10;
            this.btn_ClearAll.UseVisualStyleBackColor = false;
            this.btn_ClearAll.Visible = false;
            this.btn_ClearAll.Click += new System.EventHandler(this.btn_ClearAll_Click);
            // 
            // lbl_InvoiceInfo
            // 
            this.lbl_InvoiceInfo.AutoSize = true;
            this.lbl_InvoiceInfo.ContextMenuStrip = this.ContextMenuStrip_DocInfo;
            this.lbl_InvoiceInfo.Location = new System.Drawing.Point(3, 24);
            this.lbl_InvoiceInfo.Name = "lbl_InvoiceInfo";
            this.lbl_InvoiceInfo.Size = new System.Drawing.Size(35, 13);
            this.lbl_InvoiceInfo.TabIndex = 12;
            this.lbl_InvoiceInfo.Text = "label1";
            // 
            // usrc_Item_InsidePageHandler_ItemAtomList
            // 
            this.usrc_Item_InsidePageHandler_ItemAtomList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.usrc_Item_InsidePageHandler_ItemAtomList.BackColor = System.Drawing.Color.OldLace;
            this.usrc_Item_InsidePageHandler_ItemAtomList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.usrc_Item_InsidePageHandler_ItemAtomList.CtrlHeight = 40;
            this.usrc_Item_InsidePageHandler_ItemAtomList.CtrlWidth = 350;
            this.usrc_Item_InsidePageHandler_ItemAtomList.Location = new System.Drawing.Point(0, 40);
            this.usrc_Item_InsidePageHandler_ItemAtomList.Name = "usrc_Item_InsidePageHandler_ItemAtomList";
            this.usrc_Item_InsidePageHandler_ItemAtomList.SelectedIndex = -1;
            this.usrc_Item_InsidePageHandler_ItemAtomList.Size = new System.Drawing.Size(395, 236);
            this.usrc_Item_InsidePageHandler_ItemAtomList.TabIndex = 11;
            this.usrc_Item_InsidePageHandler_ItemAtomList.SelectionChanged += new usrc_Item_InsidePage_Handler.usrc_Item_InsidePageHandler<Doc_ShopC_Item>.delegate_SelectionChanged(this.Usrc_Item_InsidePageHandler1_SelectionChanged);
            // 
            // ContextMenuStrip_DocInfo
            // 
            this.ContextMenuStrip_DocInfo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showTablesToolStripMenuItem});
            this.ContextMenuStrip_DocInfo.Name = "ContextMenuStrip_DocInfo";
            this.ContextMenuStrip_DocInfo.Size = new System.Drawing.Size(140, 26);
            // 
            // showTablesToolStripMenuItem
            // 
            this.showTablesToolStripMenuItem.Name = "showTablesToolStripMenuItem";
            this.showTablesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.showTablesToolStripMenuItem.Text = "Show Tables";
            this.showTablesToolStripMenuItem.Click += new System.EventHandler(this.showTablesToolStripMenuItem_Click);
            // 
            // usrc_Atom_ItemsList1366x768
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.lbl_InvoiceInfo);
            this.Controls.Add(this.usrc_Item_InsidePageHandler_ItemAtomList);
            this.Controls.Add(this.btn_ClearAll);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "usrc_Atom_ItemsList1366x768";
            this.Size = new System.Drawing.Size(400, 279);
            this.ContextMenuStrip_DocInfo.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_ClearAll;
        private usrc_Item_InsidePageHandler_Doc_ShopC_Item usrc_Item_InsidePageHandler_ItemAtomList;
        private System.Windows.Forms.Label lbl_InvoiceInfo;
        private System.Windows.Forms.ContextMenuStrip ContextMenuStrip_DocInfo;
        private System.Windows.Forms.ToolStripMenuItem showTablesToolStripMenuItem;
    }
}
