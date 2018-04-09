namespace Tangenta
{
    partial class Form_Document_WizzardForHelp
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
            this.components = new System.ComponentModel.Container();
            this.bn_Cancel = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.lbl_StepInterval = new System.Windows.Forms.Label();
            this.btn_Start = new System.Windows.Forms.Button();
            this.lbl_StepDocInvoice = new System.Windows.Forms.Label();
            this.txt_DocumentType = new System.Windows.Forms.TextBox();
            this.txt_InvoiceTableVisible = new System.Windows.Forms.TextBox();
            this.lbl_InvoiceTable_Visible = new System.Windows.Forms.Label();
            this.txt_InvoiceHeadVisible = new System.Windows.Forms.TextBox();
            this.lbl_InvoiceHead_Visible = new System.Windows.Forms.Label();
            this.txt_ShopsVisible = new System.Windows.Forms.TextBox();
            this.lbl_Shops_Visible = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // bn_Cancel
            // 
            this.bn_Cancel.Location = new System.Drawing.Point(354, 1);
            this.bn_Cancel.Name = "bn_Cancel";
            this.bn_Cancel.Size = new System.Drawing.Size(51, 28);
            this.bn_Cancel.TabIndex = 0;
            this.bn_Cancel.Text = "Cancel";
            this.bn_Cancel.UseVisualStyleBackColor = true;
            this.bn_Cancel.Click += new System.EventHandler(this.bn_Cancel_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(96, 14);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            20000,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(83, 20);
            this.numericUpDown1.TabIndex = 1;
            this.numericUpDown1.Value = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            // 
            // lbl_StepInterval
            // 
            this.lbl_StepInterval.AutoSize = true;
            this.lbl_StepInterval.Location = new System.Drawing.Point(12, 16);
            this.lbl_StepInterval.Name = "lbl_StepInterval";
            this.lbl_StepInterval.Size = new System.Drawing.Size(67, 13);
            this.lbl_StepInterval.TabIndex = 2;
            this.lbl_StepInterval.Text = "Step Interval";
            // 
            // btn_Start
            // 
            this.btn_Start.Location = new System.Drawing.Point(204, 14);
            this.btn_Start.Name = "btn_Start";
            this.btn_Start.Size = new System.Drawing.Size(75, 23);
            this.btn_Start.TabIndex = 3;
            this.btn_Start.Text = "Start";
            this.btn_Start.UseVisualStyleBackColor = true;
            this.btn_Start.Click += new System.EventHandler(this.btn_Start_Click);
            // 
            // lbl_StepDocInvoice
            // 
            this.lbl_StepDocInvoice.Location = new System.Drawing.Point(5, 47);
            this.lbl_StepDocInvoice.Name = "lbl_StepDocInvoice";
            this.lbl_StepDocInvoice.Size = new System.Drawing.Size(118, 19);
            this.lbl_StepDocInvoice.TabIndex = 4;
            this.lbl_StepDocInvoice.Text = "Document Type:";
            this.lbl_StepDocInvoice.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txt_DocumentType
            // 
            this.txt_DocumentType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_DocumentType.BackColor = System.Drawing.Color.White;
            this.txt_DocumentType.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_DocumentType.Location = new System.Drawing.Point(123, 52);
            this.txt_DocumentType.Name = "txt_DocumentType";
            this.txt_DocumentType.ReadOnly = true;
            this.txt_DocumentType.Size = new System.Drawing.Size(280, 13);
            this.txt_DocumentType.TabIndex = 5;
            // 
            // txt_InvoiceTableVisible
            // 
            this.txt_InvoiceTableVisible.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_InvoiceTableVisible.BackColor = System.Drawing.Color.White;
            this.txt_InvoiceTableVisible.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_InvoiceTableVisible.Location = new System.Drawing.Point(123, 71);
            this.txt_InvoiceTableVisible.Name = "txt_InvoiceTableVisible";
            this.txt_InvoiceTableVisible.ReadOnly = true;
            this.txt_InvoiceTableVisible.Size = new System.Drawing.Size(280, 13);
            this.txt_InvoiceTableVisible.TabIndex = 7;
            // 
            // lbl_InvoiceTable_Visible
            // 
            this.lbl_InvoiceTable_Visible.Location = new System.Drawing.Point(5, 66);
            this.lbl_InvoiceTable_Visible.Name = "lbl_InvoiceTable_Visible";
            this.lbl_InvoiceTable_Visible.Size = new System.Drawing.Size(118, 19);
            this.lbl_InvoiceTable_Visible.TabIndex = 6;
            this.lbl_InvoiceTable_Visible.Text = "InvoiceTable Visible:";
            this.lbl_InvoiceTable_Visible.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txt_InvoiceHeadVisible
            // 
            this.txt_InvoiceHeadVisible.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_InvoiceHeadVisible.BackColor = System.Drawing.Color.White;
            this.txt_InvoiceHeadVisible.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_InvoiceHeadVisible.Location = new System.Drawing.Point(123, 90);
            this.txt_InvoiceHeadVisible.Name = "txt_InvoiceHeadVisible";
            this.txt_InvoiceHeadVisible.ReadOnly = true;
            this.txt_InvoiceHeadVisible.Size = new System.Drawing.Size(280, 13);
            this.txt_InvoiceHeadVisible.TabIndex = 9;
            // 
            // lbl_InvoiceHead_Visible
            // 
            this.lbl_InvoiceHead_Visible.Location = new System.Drawing.Point(5, 85);
            this.lbl_InvoiceHead_Visible.Name = "lbl_InvoiceHead_Visible";
            this.lbl_InvoiceHead_Visible.Size = new System.Drawing.Size(118, 19);
            this.lbl_InvoiceHead_Visible.TabIndex = 8;
            this.lbl_InvoiceHead_Visible.Text = "Invoice Head Visible:";
            this.lbl_InvoiceHead_Visible.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txt_ShopsVisible
            // 
            this.txt_ShopsVisible.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_ShopsVisible.BackColor = System.Drawing.Color.White;
            this.txt_ShopsVisible.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_ShopsVisible.Location = new System.Drawing.Point(123, 109);
            this.txt_ShopsVisible.Name = "txt_ShopsVisible";
            this.txt_ShopsVisible.ReadOnly = true;
            this.txt_ShopsVisible.Size = new System.Drawing.Size(280, 13);
            this.txt_ShopsVisible.TabIndex = 11;
            // 
            // lbl_Shops_Visible
            // 
            this.lbl_Shops_Visible.Location = new System.Drawing.Point(5, 104);
            this.lbl_Shops_Visible.Name = "lbl_Shops_Visible";
            this.lbl_Shops_Visible.Size = new System.Drawing.Size(118, 19);
            this.lbl_Shops_Visible.TabIndex = 10;
            this.lbl_Shops_Visible.Text = "Shops Visible:";
            this.lbl_Shops_Visible.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Form_Document_WizzardForHelp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 236);
            this.Controls.Add(this.txt_ShopsVisible);
            this.Controls.Add(this.lbl_Shops_Visible);
            this.Controls.Add(this.txt_InvoiceHeadVisible);
            this.Controls.Add(this.lbl_InvoiceHead_Visible);
            this.Controls.Add(this.txt_InvoiceTableVisible);
            this.Controls.Add(this.lbl_InvoiceTable_Visible);
            this.Controls.Add(this.txt_DocumentType);
            this.Controls.Add(this.lbl_StepDocInvoice);
            this.Controls.Add(this.btn_Start);
            this.Controls.Add(this.lbl_StepInterval);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.bn_Cancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "Form_Document_WizzardForHelp";
            this.Text = "Help Wizzard";
            this.Load += new System.EventHandler(this.Form_Document_WizzardForHelp_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bn_Cancel;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label lbl_StepInterval;
        private System.Windows.Forms.Button btn_Start;
        private System.Windows.Forms.Label lbl_StepDocInvoice;
        private System.Windows.Forms.TextBox txt_DocumentType;
        private System.Windows.Forms.TextBox txt_InvoiceTableVisible;
        private System.Windows.Forms.Label lbl_InvoiceTable_Visible;
        private System.Windows.Forms.TextBox txt_InvoiceHeadVisible;
        private System.Windows.Forms.Label lbl_InvoiceHead_Visible;
        private System.Windows.Forms.TextBox txt_ShopsVisible;
        private System.Windows.Forms.Label lbl_Shops_Visible;
    }
}