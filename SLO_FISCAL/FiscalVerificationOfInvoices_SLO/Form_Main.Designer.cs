namespace FiscalVerificationOfInvoices_SLO
{
    partial class Form_Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Main));
            this.btn_Settings = new System.Windows.Forms.Button();
            this.btn_Send_ECHO = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_SendInvoices_from_BingBookOfInvoices = new System.Windows.Forms.Button();
            this.dgvx_UnsentInvoices_from_BindingBookOfInvoices = new DataGridView_2xls.DataGridView2xls();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvx_UnsentInvoices_from_BindingBookOfInvoices)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Settings
            // 
            this.btn_Settings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Settings.Image = global::FiscalVerificationOfInvoices_SLO.Properties.Resources.FURS_Settings;
            this.btn_Settings.Location = new System.Drawing.Point(816, 6);
            this.btn_Settings.Name = "btn_Settings";
            this.btn_Settings.Size = new System.Drawing.Size(102, 38);
            this.btn_Settings.TabIndex = 3;
            this.btn_Settings.UseVisualStyleBackColor = true;
            this.btn_Settings.Click += new System.EventHandler(this.btn_Settings_Click);
            // 
            // btn_Send_ECHO
            // 
            this.btn_Send_ECHO.Location = new System.Drawing.Point(15, 6);
            this.btn_Send_ECHO.Name = "btn_Send_ECHO";
            this.btn_Send_ECHO.Size = new System.Drawing.Size(83, 38);
            this.btn_Send_ECHO.TabIndex = 4;
            this.btn_Send_ECHO.Text = "Pošlji ECHO";
            this.btn_Send_ECHO.UseVisualStyleBackColor = true;
            this.btn_Send_ECHO.Click += new System.EventHandler(this.btn_Send_ECHO_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.splitContainer1.Location = new System.Drawing.Point(4, 56);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.dgvx_UnsentInvoices_from_BindingBookOfInvoices);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Panel2Collapsed = true;
            this.splitContainer1.Size = new System.Drawing.Size(914, 670);
            this.splitContainer1.SplitterDistance = 229;
            this.splitContainer1.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(207, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Neposlani računi iz vezane knjige računov";
            // 
            // btn_SendInvoices_from_BingBookOfInvoices
            // 
            this.btn_SendInvoices_from_BingBookOfInvoices.Location = new System.Drawing.Point(104, 6);
            this.btn_SendInvoices_from_BingBookOfInvoices.Name = "btn_SendInvoices_from_BingBookOfInvoices";
            this.btn_SendInvoices_from_BingBookOfInvoices.Size = new System.Drawing.Size(254, 38);
            this.btn_SendInvoices_from_BingBookOfInvoices.TabIndex = 7;
            this.btn_SendInvoices_from_BingBookOfInvoices.Text = "Pošlji neposlane račune iz vezane knjige računov";
            this.btn_SendInvoices_from_BingBookOfInvoices.UseVisualStyleBackColor = true;
            // 
            // dgvx_UnsentInvoices_from_BindingBookOfInvoices
            // 
            this.dgvx_UnsentInvoices_from_BindingBookOfInvoices.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvx_UnsentInvoices_from_BindingBookOfInvoices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvx_UnsentInvoices_from_BindingBookOfInvoices.DataGridViewWithRowNumber = false;
            this.dgvx_UnsentInvoices_from_BindingBookOfInvoices.Location = new System.Drawing.Point(8, 26);
            this.dgvx_UnsentInvoices_from_BindingBookOfInvoices.Name = "dgvx_UnsentInvoices_from_BindingBookOfInvoices";
            this.dgvx_UnsentInvoices_from_BindingBookOfInvoices.Size = new System.Drawing.Size(903, 634);
            this.dgvx_UnsentInvoices_from_BindingBookOfInvoices.TabIndex = 9;
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(922, 728);
            this.Controls.Add(this.btn_SendInvoices_from_BingBookOfInvoices);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.btn_Send_ECHO);
            this.Controls.Add(this.btn_Settings);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form_Main";
            this.Load += new System.EventHandler(this.Form_Main_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvx_UnsentInvoices_from_BindingBookOfInvoices)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btn_Settings;
        private System.Windows.Forms.Button btn_Send_ECHO;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label1;
        private DataGridView_2xls.DataGridView2xls dgvx_UnsentInvoices_from_BindingBookOfInvoices;
        private System.Windows.Forms.Button btn_SendInvoices_from_BingBookOfInvoices;
    }
}