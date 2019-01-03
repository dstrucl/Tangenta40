﻿namespace Tangenta
{
    partial class usrc_DocumentEditor1366x768
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
            this.txt_Number = new System.Windows.Forms.TextBox();
            this.lbl_Number = new System.Windows.Forms.Label();
            this.lbl_Sum = new System.Windows.Forms.Label();
            this.btn_Issue = new System.Windows.Forms.Button();
            this.chk_Storno = new System.Windows.Forms.CheckBox();
            this.btn_Show_Shops = new System.Windows.Forms.Button();
            this.m_usrc_ShopB1366x768 = new ShopB.usrc_ShopB1366x768();
            this.m_usrc_ShopA1366x768 = new ShopA.usrc_ShopA1366x768();
            this.usrc_AddOn1 = new Tangenta.usrc_AddOn();
            this.usrc_Customer = new Tangenta.usrc_Customer();
            this.m_usrc_ShopC1366x768 = new ShopC.usrc_ShopC1366x768();
            this.btn_New = new System.Windows.Forms.Button();
            this.usrc_Item1366x768_selected1 = new ShopC.usrc_Item1366x768_selected();
            this.SuspendLayout();
            // 
            // txt_Number
            // 
            this.txt_Number.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_Number.Location = new System.Drawing.Point(81, 3);
            this.txt_Number.Name = "txt_Number";
            this.txt_Number.ReadOnly = true;
            this.txt_Number.Size = new System.Drawing.Size(104, 24);
            this.txt_Number.TabIndex = 22;
            // 
            // lbl_Number
            // 
            this.lbl_Number.AutoSize = true;
            this.lbl_Number.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_Number.Location = new System.Drawing.Point(2, 4);
            this.lbl_Number.Name = "lbl_Number";
            this.lbl_Number.Size = new System.Drawing.Size(77, 20);
            this.lbl_Number.TabIndex = 23;
            this.lbl_Number.Text = "Številka:";
            // 
            // lbl_Sum
            // 
            this.lbl_Sum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_Sum.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_Sum.Location = new System.Drawing.Point(3, 697);
            this.lbl_Sum.Name = "lbl_Sum";
            this.lbl_Sum.Size = new System.Drawing.Size(170, 29);
            this.lbl_Sum.TabIndex = 30;
            this.lbl_Sum.Text = "SKUPAJ";
            // 
            // btn_Issue
            // 
            this.btn_Issue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Issue.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_Issue.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_Issue.Location = new System.Drawing.Point(3, 727);
            this.btn_Issue.Name = "btn_Issue";
            this.btn_Issue.Size = new System.Drawing.Size(150, 41);
            this.btn_Issue.TabIndex = 32;
            this.btn_Issue.Text = "Issue";
            this.btn_Issue.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_Issue.UseVisualStyleBackColor = false;
            this.btn_Issue.Click += new System.EventHandler(this.btn_Issue_Click);
            // 
            // chk_Storno
            // 
            this.chk_Storno.Appearance = System.Windows.Forms.Appearance.Button;
            this.chk_Storno.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.chk_Storno.Location = new System.Drawing.Point(938, 685);
            this.chk_Storno.Name = "chk_Storno";
            this.chk_Storno.Size = new System.Drawing.Size(60, 82);
            this.chk_Storno.TabIndex = 39;
            this.chk_Storno.Text = "Storno";
            this.chk_Storno.UseVisualStyleBackColor = true;
            this.chk_Storno.CheckedChanged += new System.EventHandler(this.chk_Storno_CheckedChanged);
            // 
            // btn_Show_Shops
            // 
            this.btn_Show_Shops.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_Show_Shops.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_Show_Shops.Location = new System.Drawing.Point(868, 685);
            this.btn_Show_Shops.Name = "btn_Show_Shops";
            this.btn_Show_Shops.Size = new System.Drawing.Size(68, 82);
            this.btn_Show_Shops.TabIndex = 41;
            this.btn_Show_Shops.Text = "trgovine";
            this.btn_Show_Shops.UseVisualStyleBackColor = false;
            this.btn_Show_Shops.Click += new System.EventHandler(this.btn_Select_Shops_Click);
            // 
            // m_usrc_ShopB1366x768
            // 
            this.m_usrc_ShopB1366x768.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.m_usrc_ShopB1366x768.DocTyp = "";
            this.m_usrc_ShopB1366x768.Location = new System.Drawing.Point(0, 220);
            this.m_usrc_ShopB1366x768.Name = "m_usrc_ShopB1366x768";
            this.m_usrc_ShopB1366x768.Size = new System.Drawing.Size(1006, 140);
            this.m_usrc_ShopB1366x768.TabIndex = 45;
            // 
            // m_usrc_ShopA1366x768
            // 
            this.m_usrc_ShopA1366x768.BackColor = System.Drawing.SystemColors.Control;
            this.m_usrc_ShopA1366x768.Location = new System.Drawing.Point(0, 40);
            this.m_usrc_ShopA1366x768.Name = "m_usrc_ShopA1366x768";
            this.m_usrc_ShopA1366x768.Size = new System.Drawing.Size(1006, 180);
            this.m_usrc_ShopA1366x768.TabIndex = 44;
            // 
            // usrc_AddOn1
            // 
            this.usrc_AddOn1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.usrc_AddOn1.BackColor = System.Drawing.Color.LemonChiffon;
            this.usrc_AddOn1.Location = new System.Drawing.Point(159, 689);
            this.usrc_AddOn1.Name = "usrc_AddOn1";
            this.usrc_AddOn1.Size = new System.Drawing.Size(177, 79);
            this.usrc_AddOn1.TabIndex = 40;
            // 
            // usrc_Customer
            // 
            this.usrc_Customer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.usrc_Customer.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.usrc_Customer.DocTyp = "";
            this.usrc_Customer.Location = new System.Drawing.Point(193, 2);
            this.usrc_Customer.Margin = new System.Windows.Forms.Padding(4);
            this.usrc_Customer.Name = "usrc_Customer";
            this.usrc_Customer.Size = new System.Drawing.Size(809, 35);
            this.usrc_Customer.TabIndex = 33;
            // 
            // m_usrc_ShopC1366x768
            // 
            this.m_usrc_ShopC1366x768.AutomaticSelectionOfItemsFromStock = true;
            this.m_usrc_ShopC1366x768.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.m_usrc_ShopC1366x768.ExclusivelySellFromStock = false;
            this.m_usrc_ShopC1366x768.Location = new System.Drawing.Point(0, 360);
            this.m_usrc_ShopC1366x768.Margin = new System.Windows.Forms.Padding(4);
            this.m_usrc_ShopC1366x768.Name = "m_usrc_ShopC1366x768";
            this.m_usrc_ShopC1366x768.Size = new System.Drawing.Size(1006, 320);
            this.m_usrc_ShopC1366x768.TabIndex = 46;
            // 
            // btn_New
            // 
            this.btn_New.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_New.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_New.Image = global::Tangenta.Properties.Resources.New;
            this.btn_New.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_New.Location = new System.Drawing.Point(756, 685);
            this.btn_New.Name = "btn_New";
            this.btn_New.Size = new System.Drawing.Size(111, 82);
            this.btn_New.TabIndex = 48;
            this.btn_New.Text = "Nov";
            this.btn_New.UseVisualStyleBackColor = false;
            this.btn_New.Click += new System.EventHandler(this.btn_New_Click);
            // 
            // usrc_Item1366x768_selected1
            // 
            this.usrc_Item1366x768_selected1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(249)))), ((int)(((byte)(166)))));
            this.usrc_Item1366x768_selected1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.usrc_Item1366x768_selected1.Location = new System.Drawing.Point(338, 679);
            this.usrc_Item1366x768_selected1.Margin = new System.Windows.Forms.Padding(4);
            this.usrc_Item1366x768_selected1.Name = "usrc_Item1366x768_selected1";
            this.usrc_Item1366x768_selected1.Size = new System.Drawing.Size(413, 88);
            this.usrc_Item1366x768_selected1.TabIndex = 49;
            // 
            // usrc_DocumentEditor1366x768
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.usrc_Item1366x768_selected1);
            this.Controls.Add(this.btn_New);
            this.Controls.Add(this.m_usrc_ShopC1366x768);
            this.Controls.Add(this.m_usrc_ShopB1366x768);
            this.Controls.Add(this.m_usrc_ShopA1366x768);
            this.Controls.Add(this.btn_Show_Shops);
            this.Controls.Add(this.usrc_AddOn1);
            this.Controls.Add(this.chk_Storno);
            this.Controls.Add(this.usrc_Customer);
            this.Controls.Add(this.btn_Issue);
            this.Controls.Add(this.lbl_Sum);
            this.Controls.Add(this.lbl_Number);
            this.Controls.Add(this.txt_Number);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "usrc_DocumentEditor1366x768";
            this.Size = new System.Drawing.Size(1006, 768);
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion
        private System.Windows.Forms.TextBox txt_Number;
        private System.Windows.Forms.Label lbl_Number;
        private System.Windows.Forms.Button btn_Issue;
        private usrc_Customer usrc_Customer;
        private System.Windows.Forms.CheckBox chk_Storno;
        private usrc_AddOn usrc_AddOn1;
        public System.Windows.Forms.Button btn_Show_Shops;
        public System.Windows.Forms.Label lbl_Sum;
        internal ShopA.usrc_ShopA1366x768 m_usrc_ShopA1366x768;
        internal ShopB.usrc_ShopB1366x768 m_usrc_ShopB1366x768;
        internal ShopC.usrc_ShopC1366x768 m_usrc_ShopC1366x768;
        internal System.Windows.Forms.Button btn_New;
        private ShopC.usrc_Item1366x768_selected usrc_Item1366x768_selected1;
    }
}
