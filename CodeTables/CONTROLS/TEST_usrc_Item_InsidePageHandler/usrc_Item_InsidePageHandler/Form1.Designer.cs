﻿namespace usrc_Item_InsidePageHandler
{
    partial class Form1
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
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nmUpDn_SelectItem = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_Page = new System.Windows.Forms.Label();
            this.rdb_Array = new System.Windows.Forms.RadioButton();
            this.rdb_List = new System.Windows.Forms.RadioButton();
            this.numUpDn_decimal = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btn_usrc_GroupHandler = new System.Windows.Forms.Button();
            this.usrc_Item_InsidePageHandler2 = new usrc_Item_PageHandler.usrc_Item_InsidePageHandler();
            this.usrc_Item_InsideGroup_Handler1 = new usrc_Item_Group_Handler.usrc_Item_InsideGroup_Handler();
            this.usrc_Item_InsidePageHandler1 = new usrc_Item_PageHandler.usrc_Item_InsidePageHandler();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmUpDn_SelectItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDn_decimal)).BeginInit();
            this.SuspendLayout();
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(36, 31);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(182, 20);
            this.numericUpDown1.TabIndex = 1;
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(82, 89);
            this.numericUpDown2.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(71, 20);
            this.numericUpDown2.TabIndex = 2;
            this.numericUpDown2.ValueChanged += new System.EventHandler(this.numericUpDown2_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Show Page";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(246, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Select Item";
            // 
            // nmUpDn_SelectItem
            // 
            this.nmUpDn_SelectItem.Location = new System.Drawing.Point(314, 84);
            this.nmUpDn_SelectItem.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nmUpDn_SelectItem.Name = "nmUpDn_SelectItem";
            this.nmUpDn_SelectItem.Size = new System.Drawing.Size(71, 20);
            this.nmUpDn_SelectItem.TabIndex = 4;
            this.nmUpDn_SelectItem.ValueChanged += new System.EventHandler(this.nmUpDn_SelectItem_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(412, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Page:";
            // 
            // lbl_Page
            // 
            this.lbl_Page.AutoSize = true;
            this.lbl_Page.Location = new System.Drawing.Point(454, 96);
            this.lbl_Page.Name = "lbl_Page";
            this.lbl_Page.Size = new System.Drawing.Size(35, 13);
            this.lbl_Page.TabIndex = 7;
            this.lbl_Page.Text = "label4";
            // 
            // rdb_Array
            // 
            this.rdb_Array.AutoSize = true;
            this.rdb_Array.Location = new System.Drawing.Point(17, 8);
            this.rdb_Array.Name = "rdb_Array";
            this.rdb_Array.Size = new System.Drawing.Size(62, 17);
            this.rdb_Array.TabIndex = 8;
            this.rdb_Array.Text = "ARRAY";
            this.rdb_Array.UseVisualStyleBackColor = true;
            // 
            // rdb_List
            // 
            this.rdb_List.AutoSize = true;
            this.rdb_List.Checked = true;
            this.rdb_List.Location = new System.Drawing.Point(82, 8);
            this.rdb_List.Name = "rdb_List";
            this.rdb_List.Size = new System.Drawing.Size(48, 17);
            this.rdb_List.TabIndex = 9;
            this.rdb_List.TabStop = true;
            this.rdb_List.Text = "LIST";
            this.rdb_List.UseVisualStyleBackColor = true;
            // 
            // numUpDn_decimal
            // 
            this.numUpDn_decimal.Location = new System.Drawing.Point(342, 5);
            this.numUpDn_decimal.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.numUpDn_decimal.Minimum = new decimal(new int[] {
            1000000,
            0,
            0,
            -2147483648});
            this.numUpDn_decimal.Name = "numUpDn_decimal";
            this.numUpDn_decimal.Size = new System.Drawing.Size(114, 20);
            this.numUpDn_decimal.TabIndex = 12;
            this.numUpDn_decimal.ValueChanged += new System.EventHandler(this.numUpDn_decimal_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(217, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "TestDecimalConversion";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(462, 5);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(109, 20);
            this.textBox1.TabIndex = 14;
            // 
            // btn_usrc_GroupHandler
            // 
            this.btn_usrc_GroupHandler.Location = new System.Drawing.Point(362, 41);
            this.btn_usrc_GroupHandler.Name = "btn_usrc_GroupHandler";
            this.btn_usrc_GroupHandler.Size = new System.Drawing.Size(191, 32);
            this.btn_usrc_GroupHandler.TabIndex = 15;
            this.btn_usrc_GroupHandler.Text = "TEST usrc_Item_Group_Handler";
            this.btn_usrc_GroupHandler.UseVisualStyleBackColor = true;
            this.btn_usrc_GroupHandler.Click += new System.EventHandler(this.btn_usrc_GroupHandler_Click);
            // 
            // usrc_Item_InsidePageHandler2
            // 
            this.usrc_Item_InsidePageHandler2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.usrc_Item_InsidePageHandler2.BackColor = System.Drawing.Color.MistyRose;
            this.usrc_Item_InsidePageHandler2.Location = new System.Drawing.Point(0, 294);
            this.usrc_Item_InsidePageHandler2.Name = "usrc_Item_InsidePageHandler2";
            this.usrc_Item_InsidePageHandler2.SelectedIndex = -1;
            this.usrc_Item_InsidePageHandler2.Size = new System.Drawing.Size(582, 106);
            this.usrc_Item_InsidePageHandler2.TabIndex = 11;
            // 
            // usrc_Item_InsideGroup_Handler1
            // 
            this.usrc_Item_InsideGroup_Handler1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.usrc_Item_InsideGroup_Handler1.Button_Height = 40;
            this.usrc_Item_InsideGroup_Handler1.Font_Height = 10;
            this.usrc_Item_InsideGroup_Handler1.Location = new System.Drawing.Point(0, 421);
            this.usrc_Item_InsideGroup_Handler1.Name = "usrc_Item_InsideGroup_Handler1";
            this.usrc_Item_InsideGroup_Handler1.Size = new System.Drawing.Size(582, 120);
            this.usrc_Item_InsideGroup_Handler1.TabIndex = 10;
            // 
            // usrc_Item_InsidePageHandler1
            // 
            this.usrc_Item_InsidePageHandler1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.usrc_Item_InsidePageHandler1.BackColor = System.Drawing.Color.MistyRose;
            this.usrc_Item_InsidePageHandler1.Location = new System.Drawing.Point(0, 115);
            this.usrc_Item_InsidePageHandler1.Name = "usrc_Item_InsidePageHandler1";
            this.usrc_Item_InsidePageHandler1.SelectedIndex = -1;
            this.usrc_Item_InsidePageHandler1.Size = new System.Drawing.Size(582, 106);
            this.usrc_Item_InsidePageHandler1.TabIndex = 0;
            this.usrc_Item_InsidePageHandler1.CreateControl += new usrc_Item_PageHandler.usrc_Item_InsidePageHandler.delegate_CreateControl(this.usrc_Item_InsidePageHandler1_CreateControl);
            this.usrc_Item_InsidePageHandler1.FillControl += new usrc_Item_PageHandler.usrc_Item_InsidePageHandler.delegate_FillControl(this.usrc_Item_InsidePageHandler1_FillControl);
            this.usrc_Item_InsidePageHandler1.SelectControl += new usrc_Item_PageHandler.usrc_Item_InsidePageHandler.delegate_SelectControl(this.usrc_Item_InsidePageHandler1_SelectControl);
            this.usrc_Item_InsidePageHandler1.Select += new usrc_Item_PageHandler.usrc_Item_InsidePageHandler.delegate_Select(this.usrc_Item_InsidePageHandler1_Select);
            this.usrc_Item_InsidePageHandler1.SelectionChanged += new usrc_Item_PageHandler.usrc_Item_InsidePageHandler.delegate_SelectionChanged(this.usrc_Item_InsidePageHandler1_SelectionChanged);
            this.usrc_Item_InsidePageHandler1.PageChanged += new usrc_Item_PageHandler.usrc_Item_InsidePageHandler.delegate_PageChanged(this.usrc_Item_InsidePageHandler1_PageChanged);
            this.usrc_Item_InsidePageHandler1.Deselect += new usrc_Item_PageHandler.usrc_Item_InsidePageHandler.delegate_Deselect(this.usrc_Item_InsidePageHandler1_Deselect);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 563);
            this.Controls.Add(this.btn_usrc_GroupHandler);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numUpDn_decimal);
            this.Controls.Add(this.usrc_Item_InsidePageHandler2);
            this.Controls.Add(this.usrc_Item_InsideGroup_Handler1);
            this.Controls.Add(this.rdb_List);
            this.Controls.Add(this.rdb_Array);
            this.Controls.Add(this.lbl_Page);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nmUpDn_SelectItem);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDown2);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.usrc_Item_InsidePageHandler1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmUpDn_SelectItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDn_decimal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private usrc_Item_PageHandler.usrc_Item_InsidePageHandler usrc_Item_InsidePageHandler1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nmUpDn_SelectItem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl_Page;
        private System.Windows.Forms.RadioButton rdb_Array;
        private System.Windows.Forms.RadioButton rdb_List;
        private usrc_Item_Group_Handler.usrc_Item_InsideGroup_Handler usrc_Item_InsideGroup_Handler1;
        private usrc_Item_PageHandler.usrc_Item_InsidePageHandler usrc_Item_InsidePageHandler2;
        private System.Windows.Forms.NumericUpDown numUpDn_decimal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btn_usrc_GroupHandler;
    }
}

