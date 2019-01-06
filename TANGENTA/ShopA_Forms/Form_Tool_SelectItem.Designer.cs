namespace ShopA_Forms
{
    partial class Form_Tool_SelectItem
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
            this.dgvx_Item = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvx_Item)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvx_Item
            // 
            this.dgvx_Item.AllowUserToAddRows = false;
            this.dgvx_Item.AllowUserToDeleteRows = false;
            this.dgvx_Item.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvx_Item.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvx_Item.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvx_Item.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvx_Item.Location = new System.Drawing.Point(0, 0);
            this.dgvx_Item.Name = "dgvx_Item";
            this.dgvx_Item.ReadOnly = true;
            this.dgvx_Item.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvx_Item.Size = new System.Drawing.Size(527, 431);
            this.dgvx_Item.TabIndex = 0;
            // 
            // Form_Tool_SelectItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(527, 431);
            this.Controls.Add(this.dgvx_Item);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "Form_Tool_SelectItem";
            this.Text = "Form_Tool_SelectItem";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_Tool_SelectItem_FormClosed);
            this.Load += new System.EventHandler(this.Form_Tool_SelectItem_Load);
            this.Shown += new System.EventHandler(this.Form_Tool_SelectItem_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvx_Item)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvx_Item;
    }
}