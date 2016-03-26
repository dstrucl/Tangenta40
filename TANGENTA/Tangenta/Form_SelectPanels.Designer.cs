namespace Tangenta
{
    partial class Form_SelectPanels
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
            this.rdb_DocInvoices = new System.Windows.Forms.RadioButton();
            this.rdb_ItemsAndDocInvoices = new System.Windows.Forms.RadioButton();
            this.rdb_Items = new System.Windows.Forms.RadioButton();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rdb_DocInvoices
            // 
            this.rdb_DocInvoices.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rdb_DocInvoices.Image = global::Tangenta.Properties.Resources.ViewInvoice;
            this.rdb_DocInvoices.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.rdb_DocInvoices.Location = new System.Drawing.Point(269, 17);
            this.rdb_DocInvoices.Name = "rdb_DocInvoices";
            this.rdb_DocInvoices.Size = new System.Drawing.Size(76, 34);
            this.rdb_DocInvoices.TabIndex = 34;
            this.rdb_DocInvoices.TabStop = true;
            this.rdb_DocInvoices.UseVisualStyleBackColor = true;
            // 
            // rdb_ItemsAndDocInvoices
            // 
            this.rdb_ItemsAndDocInvoices.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rdb_ItemsAndDocInvoices.Image = global::Tangenta.Properties.Resources.EditAndViewInvoice;
            this.rdb_ItemsAndDocInvoices.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.rdb_ItemsAndDocInvoices.Location = new System.Drawing.Point(156, 17);
            this.rdb_ItemsAndDocInvoices.Name = "rdb_ItemsAndDocInvoices";
            this.rdb_ItemsAndDocInvoices.Size = new System.Drawing.Size(71, 34);
            this.rdb_ItemsAndDocInvoices.TabIndex = 33;
            this.rdb_ItemsAndDocInvoices.TabStop = true;
            this.rdb_ItemsAndDocInvoices.UseVisualStyleBackColor = true;
            // 
            // rdb_Items
            // 
            this.rdb_Items.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rdb_Items.Image = global::Tangenta.Properties.Resources.EditInvoice;
            this.rdb_Items.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.rdb_Items.Location = new System.Drawing.Point(38, 12);
            this.rdb_Items.Name = "rdb_Items";
            this.rdb_Items.Size = new System.Drawing.Size(89, 44);
            this.rdb_Items.TabIndex = 32;
            this.rdb_Items.TabStop = true;
            this.rdb_Items.UseVisualStyleBackColor = true;
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Image = global::Tangenta.Properties.Resources.Exit;
            this.btn_Cancel.Location = new System.Drawing.Point(136, 63);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(91, 36);
            this.btn_Cancel.TabIndex = 35;
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // Form_SelectPanels
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(374, 101);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.rdb_DocInvoices);
            this.Controls.Add(this.rdb_ItemsAndDocInvoices);
            this.Controls.Add(this.rdb_Items);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form_SelectPanels";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Load += new System.EventHandler(this.Form_SelectPanels_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton rdb_DocInvoices;
        private System.Windows.Forms.RadioButton rdb_ItemsAndDocInvoices;
        private System.Windows.Forms.RadioButton rdb_Items;
        private System.Windows.Forms.Button btn_Cancel;
    }
}