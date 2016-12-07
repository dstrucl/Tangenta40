namespace Tangenta
{
    partial class Form_SelectPrinters
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_SelectPrinters));
            this.usrc_Printer1 = new Tangenta.usrc_Printer();
            this.usrc_Printer2 = new Tangenta.usrc_Printer();
            this.grp_Printer1 = new System.Windows.Forms.GroupBox();
            this.grp_Printer2 = new System.Windows.Forms.GroupBox();
            this.usrc_Printer3 = new Tangenta.usrc_Printer();
            this.chk_Printer1_Printnig_Invoices = new System.Windows.Forms.CheckBox();
            this.chk_Printer1_Printing_Proforma_Invoices = new System.Windows.Forms.CheckBox();
            this.chk_Printer2_Printing_ProformaInvoices = new System.Windows.Forms.CheckBox();
            this.chk_Printer2_Printing_Invoices = new System.Windows.Forms.CheckBox();
            this.usrc_NavigationButtons1 = new NavigationButtons.usrc_NavigationButtons();
            this.grp_Printer1.SuspendLayout();
            this.grp_Printer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // usrc_Printer1
            // 
            this.usrc_Printer1.Location = new System.Drawing.Point(6, 26);
            this.usrc_Printer1.Name = "usrc_Printer1";
            this.usrc_Printer1.PaperName = null;
            this.usrc_Printer1.Size = new System.Drawing.Size(241, 28);
            this.usrc_Printer1.TabIndex = 0;
            // 
            // usrc_Printer2
            // 
            this.usrc_Printer2.Location = new System.Drawing.Point(279, 45);
            this.usrc_Printer2.Name = "usrc_Printer2";
            this.usrc_Printer2.PaperName = null;
            this.usrc_Printer2.Size = new System.Drawing.Size(263, 28);
            this.usrc_Printer2.TabIndex = 1;
            // 
            // grp_Printer1
            // 
            this.grp_Printer1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.grp_Printer1.Controls.Add(this.chk_Printer1_Printing_Proforma_Invoices);
            this.grp_Printer1.Controls.Add(this.chk_Printer1_Printnig_Invoices);
            this.grp_Printer1.Controls.Add(this.usrc_Printer1);
            this.grp_Printer1.Location = new System.Drawing.Point(11, 13);
            this.grp_Printer1.Name = "grp_Printer1";
            this.grp_Printer1.Size = new System.Drawing.Size(253, 145);
            this.grp_Printer1.TabIndex = 2;
            this.grp_Printer1.TabStop = false;
            this.grp_Printer1.Text = "Printer 1";
            // 
            // grp_Printer2
            // 
            this.grp_Printer2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.grp_Printer2.Controls.Add(this.chk_Printer2_Printing_ProformaInvoices);
            this.grp_Printer2.Controls.Add(this.usrc_Printer3);
            this.grp_Printer2.Controls.Add(this.chk_Printer2_Printing_Invoices);
            this.grp_Printer2.Location = new System.Drawing.Point(271, 12);
            this.grp_Printer2.Name = "grp_Printer2";
            this.grp_Printer2.Size = new System.Drawing.Size(271, 146);
            this.grp_Printer2.TabIndex = 3;
            this.grp_Printer2.TabStop = false;
            this.grp_Printer2.Text = "Printer 2";
            // 
            // usrc_Printer3
            // 
            this.usrc_Printer3.Location = new System.Drawing.Point(6, 28);
            this.usrc_Printer3.Name = "usrc_Printer3";
            this.usrc_Printer3.PaperName = null;
            this.usrc_Printer3.Size = new System.Drawing.Size(259, 28);
            this.usrc_Printer3.TabIndex = 0;
            // 
            // chk_Printer1_Printnig_Invoices
            // 
            this.chk_Printer1_Printnig_Invoices.AutoSize = true;
            this.chk_Printer1_Printnig_Invoices.Checked = true;
            this.chk_Printer1_Printnig_Invoices.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_Printer1_Printnig_Invoices.Location = new System.Drawing.Point(23, 77);
            this.chk_Printer1_Printnig_Invoices.Name = "chk_Printer1_Printnig_Invoices";
            this.chk_Printer1_Printnig_Invoices.Size = new System.Drawing.Size(104, 17);
            this.chk_Printer1_Printnig_Invoices.TabIndex = 1;
            this.chk_Printer1_Printnig_Invoices.Text = "Printing Invoices";
            this.chk_Printer1_Printnig_Invoices.UseVisualStyleBackColor = true;
            // 
            // chk_Printer1_Printing_Proforma_Invoices
            // 
            this.chk_Printer1_Printing_Proforma_Invoices.AutoSize = true;
            this.chk_Printer1_Printing_Proforma_Invoices.Location = new System.Drawing.Point(23, 100);
            this.chk_Printer1_Printing_Proforma_Invoices.Name = "chk_Printer1_Printing_Proforma_Invoices";
            this.chk_Printer1_Printing_Proforma_Invoices.Size = new System.Drawing.Size(149, 17);
            this.chk_Printer1_Printing_Proforma_Invoices.TabIndex = 2;
            this.chk_Printer1_Printing_Proforma_Invoices.Text = "Printing Proforma Invoices";
            this.chk_Printer1_Printing_Proforma_Invoices.UseVisualStyleBackColor = true;
            // 
            // chk_Printer2_Printing_ProformaInvoices
            // 
            this.chk_Printer2_Printing_ProformaInvoices.AutoSize = true;
            this.chk_Printer2_Printing_ProformaInvoices.Checked = true;
            this.chk_Printer2_Printing_ProformaInvoices.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_Printer2_Printing_ProformaInvoices.Location = new System.Drawing.Point(8, 101);
            this.chk_Printer2_Printing_ProformaInvoices.Name = "chk_Printer2_Printing_ProformaInvoices";
            this.chk_Printer2_Printing_ProformaInvoices.Size = new System.Drawing.Size(149, 17);
            this.chk_Printer2_Printing_ProformaInvoices.TabIndex = 4;
            this.chk_Printer2_Printing_ProformaInvoices.Text = "Printing Proforma Invoices";
            this.chk_Printer2_Printing_ProformaInvoices.UseVisualStyleBackColor = true;
            // 
            // chk_Printer2_Printing_Invoices
            // 
            this.chk_Printer2_Printing_Invoices.AutoSize = true;
            this.chk_Printer2_Printing_Invoices.Location = new System.Drawing.Point(8, 78);
            this.chk_Printer2_Printing_Invoices.Name = "chk_Printer2_Printing_Invoices";
            this.chk_Printer2_Printing_Invoices.Size = new System.Drawing.Size(104, 17);
            this.chk_Printer2_Printing_Invoices.TabIndex = 3;
            this.chk_Printer2_Printing_Invoices.Text = "Printing Invoices";
            this.chk_Printer2_Printing_Invoices.UseVisualStyleBackColor = true;
            // 
            // usrc_NavigationButtons1
            // 
            this.usrc_NavigationButtons1.BackColor = System.Drawing.SystemColors.Control;
            this.usrc_NavigationButtons1.btn1_ToolTip_Text = "";
            this.usrc_NavigationButtons1.btn2_ToolTip_Text = "";
            this.usrc_NavigationButtons1.btn3_ToolTip_Text = "";
            this.usrc_NavigationButtons1.Button_NEXT_Enabled = true;
            this.usrc_NavigationButtons1.Buttons = NavigationButtons.Navigation.eButtons.OkCancel;
            this.usrc_NavigationButtons1.ExitQuestion = "Exit Program?";
            this.usrc_NavigationButtons1.Image_Cancel = null;
            this.usrc_NavigationButtons1.Image_EXIT = null;
            this.usrc_NavigationButtons1.Image_NEXT = ((System.Drawing.Image)(resources.GetObject("usrc_NavigationButtons1.Image_NEXT")));
            this.usrc_NavigationButtons1.Image_OK = ((System.Drawing.Image)(resources.GetObject("usrc_NavigationButtons1.Image_OK")));
            this.usrc_NavigationButtons1.Image_PREV = ((System.Drawing.Image)(resources.GetObject("usrc_NavigationButtons1.Image_PREV")));
            this.usrc_NavigationButtons1.Location = new System.Drawing.Point(17, 164);
            this.usrc_NavigationButtons1.Name = "usrc_NavigationButtons1";
            this.usrc_NavigationButtons1.Size = new System.Drawing.Size(525, 63);
            this.usrc_NavigationButtons1.TabIndex = 4;
            this.usrc_NavigationButtons1.Text_Cancel = "Exit";
            this.usrc_NavigationButtons1.Text_EXIT = "Exit";
            this.usrc_NavigationButtons1.Text_NEXT = "";
            this.usrc_NavigationButtons1.Text_OK = "";
            this.usrc_NavigationButtons1.Text_PREV = "";
            this.usrc_NavigationButtons1.Visible_EXIT = true;
            this.usrc_NavigationButtons1.Visible_NEXT = true;
            this.usrc_NavigationButtons1.Visible_PREV = true;
            // 
            // Form_SelectPrinters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 230);
            this.Controls.Add(this.usrc_NavigationButtons1);
            this.Controls.Add(this.grp_Printer2);
            this.Controls.Add(this.usrc_Printer2);
            this.Controls.Add(this.grp_Printer1);
            this.Name = "Form_SelectPrinters";
            this.Text = "Form_SelectPrinters";
            this.grp_Printer1.ResumeLayout(false);
            this.grp_Printer1.PerformLayout();
            this.grp_Printer2.ResumeLayout(false);
            this.grp_Printer2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private usrc_Printer usrc_Printer1;
        private usrc_Printer usrc_Printer2;
        private System.Windows.Forms.GroupBox grp_Printer1;
        private System.Windows.Forms.GroupBox grp_Printer2;
        private usrc_Printer usrc_Printer3;
        private System.Windows.Forms.CheckBox chk_Printer1_Printing_Proforma_Invoices;
        private System.Windows.Forms.CheckBox chk_Printer1_Printnig_Invoices;
        private System.Windows.Forms.CheckBox chk_Printer2_Printing_ProformaInvoices;
        private System.Windows.Forms.CheckBox chk_Printer2_Printing_Invoices;
        private NavigationButtons.usrc_NavigationButtons usrc_NavigationButtons1;
    }
}