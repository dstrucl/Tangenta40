namespace Tangenta
{
    partial class Form_Settings
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
            this.btn_Stock = new System.Windows.Forms.Button();
            this.btn_MyCompany = new System.Windows.Forms.Button();
            this.btn_SimpleItems = new System.Windows.Forms.Button();
            this.btn_Stranke = new System.Windows.Forms.Button();
            this.btn_BuyerCompany = new System.Windows.Forms.Button();
            this.btn_Invoice = new System.Windows.Forms.Button();
            this.btn_Taxations = new System.Windows.Forms.Button();
            this.btn_ItemName = new System.Windows.Forms.Button();
            this.btn_DataBaseConnection = new System.Windows.Forms.Button();
            this.btn_DeleteInvoices = new System.Windows.Forms.Button();
            this.chk_AllowToEditText = new System.Windows.Forms.CheckBox();
            this.cmb_Language = new System.Windows.Forms.ComboBox();
            this.lbl_Language = new System.Windows.Forms.Label();
            this.btn_Exit = new System.Windows.Forms.Button();
            this.chk_FullScreen = new System.Windows.Forms.CheckBox();
            this.btn_Shops_in_use = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_Stock
            // 
            this.btn_Stock.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_Stock.Location = new System.Drawing.Point(7, 125);
            this.btn_Stock.Name = "btn_Stock";
            this.btn_Stock.Size = new System.Drawing.Size(145, 82);
            this.btn_Stock.TabIndex = 0;
            this.btn_Stock.Text = "ZALOGE";
            this.btn_Stock.UseVisualStyleBackColor = true;
            this.btn_Stock.Visible = false;
            this.btn_Stock.Click += new System.EventHandler(this.btn_Stock_Click);
            // 
            // btn_MyCompany
            // 
            this.btn_MyCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_MyCompany.Location = new System.Drawing.Point(460, 125);
            this.btn_MyCompany.Name = "btn_MyCompany";
            this.btn_MyCompany.Size = new System.Drawing.Size(145, 82);
            this.btn_MyCompany.TabIndex = 1;
            this.btn_MyCompany.Text = "MOJE PODJETJE";
            this.btn_MyCompany.UseVisualStyleBackColor = true;
            this.btn_MyCompany.Visible = false;
            this.btn_MyCompany.Click += new System.EventHandler(this.btn_MyCompany_Click);
            // 
            // btn_SimpleItems
            // 
            this.btn_SimpleItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_SimpleItems.Location = new System.Drawing.Point(158, 125);
            this.btn_SimpleItems.Name = "btn_SimpleItems";
            this.btn_SimpleItems.Size = new System.Drawing.Size(145, 82);
            this.btn_SimpleItems.TabIndex = 2;
            this.btn_SimpleItems.Text = "STORITVE";
            this.btn_SimpleItems.UseVisualStyleBackColor = true;
            this.btn_SimpleItems.Visible = false;
            this.btn_SimpleItems.Click += new System.EventHandler(this.btn_SimpleItems_Click);
            // 
            // btn_Stranke
            // 
            this.btn_Stranke.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_Stranke.Location = new System.Drawing.Point(309, 213);
            this.btn_Stranke.Name = "btn_Stranke";
            this.btn_Stranke.Size = new System.Drawing.Size(145, 82);
            this.btn_Stranke.TabIndex = 3;
            this.btn_Stranke.Text = "STRANKE";
            this.btn_Stranke.UseVisualStyleBackColor = true;
            this.btn_Stranke.Visible = false;
            this.btn_Stranke.Click += new System.EventHandler(this.btn_Stranke_Click);
            // 
            // btn_BuyerCompany
            // 
            this.btn_BuyerCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_BuyerCompany.Location = new System.Drawing.Point(158, 213);
            this.btn_BuyerCompany.Name = "btn_BuyerCompany";
            this.btn_BuyerCompany.Size = new System.Drawing.Size(145, 82);
            this.btn_BuyerCompany.TabIndex = 4;
            this.btn_BuyerCompany.Text = "STRANKE PODJETJA";
            this.btn_BuyerCompany.UseVisualStyleBackColor = true;
            this.btn_BuyerCompany.Visible = false;
            this.btn_BuyerCompany.Click += new System.EventHandler(this.btn_BuyerCompany_Click);
            // 
            // btn_Invoice
            // 
            this.btn_Invoice.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_Invoice.Location = new System.Drawing.Point(611, 125);
            this.btn_Invoice.Name = "btn_Invoice";
            this.btn_Invoice.Size = new System.Drawing.Size(145, 82);
            this.btn_Invoice.TabIndex = 5;
            this.btn_Invoice.Text = "IZDANI RAČUNI";
            this.btn_Invoice.UseVisualStyleBackColor = true;
            this.btn_Invoice.Visible = false;
            // 
            // btn_Taxations
            // 
            this.btn_Taxations.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_Taxations.Location = new System.Drawing.Point(7, 213);
            this.btn_Taxations.Name = "btn_Taxations";
            this.btn_Taxations.Size = new System.Drawing.Size(145, 82);
            this.btn_Taxations.TabIndex = 6;
            this.btn_Taxations.Text = "Davčne stopnje";
            this.btn_Taxations.UseVisualStyleBackColor = true;
            this.btn_Taxations.Visible = false;
            this.btn_Taxations.Click += new System.EventHandler(this.btn_Taxations_Click);
            // 
            // btn_ItemName
            // 
            this.btn_ItemName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_ItemName.Location = new System.Drawing.Point(309, 125);
            this.btn_ItemName.Name = "btn_ItemName";
            this.btn_ItemName.Size = new System.Drawing.Size(145, 82);
            this.btn_ItemName.TabIndex = 7;
            this.btn_ItemName.Text = "Artikli";
            this.btn_ItemName.UseVisualStyleBackColor = true;
            this.btn_ItemName.Visible = false;
            this.btn_ItemName.Click += new System.EventHandler(this.btn_Item_Click);
            // 
            // btn_DataBaseConnection
            // 
            this.btn_DataBaseConnection.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_DataBaseConnection.Location = new System.Drawing.Point(460, 213);
            this.btn_DataBaseConnection.Name = "btn_DataBaseConnection";
            this.btn_DataBaseConnection.Size = new System.Drawing.Size(145, 82);
            this.btn_DataBaseConnection.TabIndex = 8;
            this.btn_DataBaseConnection.Text = "Podatkovna Baza";
            this.btn_DataBaseConnection.UseVisualStyleBackColor = true;
            this.btn_DataBaseConnection.Visible = false;
            this.btn_DataBaseConnection.Click += new System.EventHandler(this.btn_DataBaseConnection_Click);
            // 
            // btn_DeleteInvoices
            // 
            this.btn_DeleteInvoices.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_DeleteInvoices.Location = new System.Drawing.Point(15, 312);
            this.btn_DeleteInvoices.Name = "btn_DeleteInvoices";
            this.btn_DeleteInvoices.Size = new System.Drawing.Size(158, 37);
            this.btn_DeleteInvoices.TabIndex = 9;
            this.btn_DeleteInvoices.Text = "Zbriši račune";
            this.btn_DeleteInvoices.UseVisualStyleBackColor = true;
            this.btn_DeleteInvoices.Visible = false;
            this.btn_DeleteInvoices.Click += new System.EventHandler(this.btn_DeleteInvoices_Click);
            // 
            // chk_AllowToEditText
            // 
            this.chk_AllowToEditText.AutoSize = true;
            this.chk_AllowToEditText.Location = new System.Drawing.Point(10, 15);
            this.chk_AllowToEditText.Name = "chk_AllowToEditText";
            this.chk_AllowToEditText.Size = new System.Drawing.Size(155, 17);
            this.chk_AllowToEditText.TabIndex = 10;
            this.chk_AllowToEditText.Text = "Allow to edit language texts";
            this.chk_AllowToEditText.UseVisualStyleBackColor = true;
            // 
            // cmb_Language
            // 
            this.cmb_Language.FormattingEnabled = true;
            this.cmb_Language.Location = new System.Drawing.Point(420, 13);
            this.cmb_Language.Name = "cmb_Language";
            this.cmb_Language.Size = new System.Drawing.Size(221, 21);
            this.cmb_Language.TabIndex = 11;
            // 
            // lbl_Language
            // 
            this.lbl_Language.Location = new System.Drawing.Point(259, 15);
            this.lbl_Language.Name = "lbl_Language";
            this.lbl_Language.Size = new System.Drawing.Size(155, 20);
            this.lbl_Language.TabIndex = 12;
            this.lbl_Language.Text = "Language:";
            this.lbl_Language.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btn_Exit
            // 
            this.btn_Exit.Image = global::Tangenta.Properties.Resources.Exit;
            this.btn_Exit.Location = new System.Drawing.Point(658, 8);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(61, 29);
            this.btn_Exit.TabIndex = 13;
            this.btn_Exit.UseVisualStyleBackColor = true;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // chk_FullScreen
            // 
            this.chk_FullScreen.AutoSize = true;
            this.chk_FullScreen.Location = new System.Drawing.Point(186, 14);
            this.chk_FullScreen.Name = "chk_FullScreen";
            this.chk_FullScreen.Size = new System.Drawing.Size(155, 17);
            this.chk_FullScreen.TabIndex = 14;
            this.chk_FullScreen.Text = "Allow to edit language texts";
            this.chk_FullScreen.UseVisualStyleBackColor = true;
            // 
            // btn_Shops_in_use
            // 
            this.btn_Shops_in_use.Location = new System.Drawing.Point(13, 47);
            this.btn_Shops_in_use.Name = "btn_Shops_in_use";
            this.btn_Shops_in_use.Size = new System.Drawing.Size(297, 31);
            this.btn_Shops_in_use.TabIndex = 15;
            this.btn_Shops_in_use.Text = "btn_Shops_in_use";
            this.btn_Shops_in_use.UseVisualStyleBackColor = true;
            this.btn_Shops_in_use.Click += new System.EventHandler(this.btn_Shops_in_use_Click);
            // 
            // Form_Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(793, 89);
            this.Controls.Add(this.btn_Shops_in_use);
            this.Controls.Add(this.chk_FullScreen);
            this.Controls.Add(this.btn_Exit);
            this.Controls.Add(this.lbl_Language);
            this.Controls.Add(this.cmb_Language);
            this.Controls.Add(this.chk_AllowToEditText);
            this.Controls.Add(this.btn_DeleteInvoices);
            this.Controls.Add(this.btn_DataBaseConnection);
            this.Controls.Add(this.btn_ItemName);
            this.Controls.Add(this.btn_Taxations);
            this.Controls.Add(this.btn_Invoice);
            this.Controls.Add(this.btn_BuyerCompany);
            this.Controls.Add(this.btn_Stranke);
            this.Controls.Add(this.btn_SimpleItems);
            this.Controls.Add(this.btn_MyCompany);
            this.Controls.Add(this.btn_Stock);
            this.Name = "Form_Settings";
            this.Text = "Edit_Form";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Settings_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Stock;
        private System.Windows.Forms.Button btn_MyCompany;
        private System.Windows.Forms.Button btn_SimpleItems;
        private System.Windows.Forms.Button btn_Stranke;
        private System.Windows.Forms.Button btn_BuyerCompany;
        private System.Windows.Forms.Button btn_Invoice;
        private System.Windows.Forms.Button btn_Taxations;
        private System.Windows.Forms.Button btn_ItemName;
        private System.Windows.Forms.Button btn_DataBaseConnection;
        private System.Windows.Forms.Button btn_DeleteInvoices;
        private System.Windows.Forms.CheckBox chk_AllowToEditText;
        private System.Windows.Forms.ComboBox cmb_Language;
        private System.Windows.Forms.Label lbl_Language;
        private System.Windows.Forms.Button btn_Exit;
        private System.Windows.Forms.CheckBox chk_FullScreen;
        private System.Windows.Forms.Button btn_Shops_in_use;
    }
}