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
            this.rdb_Doc = new System.Windows.Forms.RadioButton();
            this.rdb_ItemsAndDoc = new System.Windows.Forms.RadioButton();
            this.rdb_Items = new System.Windows.Forms.RadioButton();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.usrc_Help1 = new HUDCMS.usrc_Help();
            this.SuspendLayout();
            // 
            // rdb_Doc
            // 
            this.rdb_Doc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rdb_Doc.Image = global::Tangenta.Properties.Resources.ViewInvoice;
            this.rdb_Doc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.rdb_Doc.Location = new System.Drawing.Point(266, 55);
            this.rdb_Doc.Name = "rdb_Doc";
            this.rdb_Doc.Size = new System.Drawing.Size(76, 34);
            this.rdb_Doc.TabIndex = 34;
            this.rdb_Doc.TabStop = true;
            this.rdb_Doc.UseVisualStyleBackColor = true;
            // 
            // rdb_ItemsAndDoc
            // 
            this.rdb_ItemsAndDoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rdb_ItemsAndDoc.Image = global::Tangenta.Properties.Resources.EditAndViewInvoice;
            this.rdb_ItemsAndDoc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.rdb_ItemsAndDoc.Location = new System.Drawing.Point(153, 55);
            this.rdb_ItemsAndDoc.Name = "rdb_ItemsAndDoc";
            this.rdb_ItemsAndDoc.Size = new System.Drawing.Size(71, 34);
            this.rdb_ItemsAndDoc.TabIndex = 33;
            this.rdb_ItemsAndDoc.TabStop = true;
            this.rdb_ItemsAndDoc.UseVisualStyleBackColor = true;
            // 
            // rdb_Items
            // 
            this.rdb_Items.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rdb_Items.Image = global::Tangenta.Properties.Resources.EditInvoice;
            this.rdb_Items.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.rdb_Items.Location = new System.Drawing.Point(35, 50);
            this.rdb_Items.Name = "rdb_Items";
            this.rdb_Items.Size = new System.Drawing.Size(89, 44);
            this.rdb_Items.TabIndex = 32;
            this.rdb_Items.TabStop = true;
            this.rdb_Items.UseVisualStyleBackColor = true;
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_Cancel.Image = global::Tangenta.Properties.Resources.Exit;
            this.btn_Cancel.Location = new System.Drawing.Point(210, 5);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(91, 36);
            this.btn_Cancel.TabIndex = 35;
            this.btn_Cancel.UseVisualStyleBackColor = false;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // usrc_Help1
            // 
            this.usrc_Help1.Location = new System.Drawing.Point(320, 5);
            this.usrc_Help1.Name = "usrc_Help1";
            this.usrc_Help1.Size = new System.Drawing.Size(49, 36);
            this.usrc_Help1.TabIndex = 36;
            // 
            // Form_SelectPanels
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(374, 101);
            this.Controls.Add(this.usrc_Help1);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.rdb_Doc);
            this.Controls.Add(this.rdb_ItemsAndDoc);
            this.Controls.Add(this.rdb_Items);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form_SelectPanels";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Load += new System.EventHandler(this.Form_SelectPanels_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton rdb_Doc;
        private System.Windows.Forms.RadioButton rdb_ItemsAndDoc;
        private System.Windows.Forms.RadioButton rdb_Items;
        private System.Windows.Forms.Button btn_Cancel;
        private HUDCMS.usrc_Help usrc_Help1;
    }
}