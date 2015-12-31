namespace Tangenta
{
    partial class usrc_InvoiceTable
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lbl_From_To = new System.Windows.Forms.Label();
            this.lbl_Sum_All = new System.Windows.Forms.Label();
            this.lbl_Sum_WithoutTax = new System.Windows.Forms.Label();
            this.lbl_Sum_Tax = new System.Windows.Forms.Label();
            this.dgvx_XInvoice = new DataGridView_2xls.DataGridView2xls();
            this.lbl_Payment1 = new System.Windows.Forms.Label();
            this.lbl_Payment2 = new System.Windows.Forms.Label();
            this.btn_Print = new System.Windows.Forms.Button();
            this.btn_TimeSpan = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvx_XInvoice)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_From_To
            // 
            this.lbl_From_To.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_From_To.Location = new System.Drawing.Point(126, 1);
            this.lbl_From_To.Name = "lbl_From_To";
            this.lbl_From_To.Size = new System.Drawing.Size(427, 18);
            this.lbl_From_To.TabIndex = 1;
            this.lbl_From_To.Text = "Prikaži vse";
            // 
            // lbl_Sum_All
            // 
            this.lbl_Sum_All.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_Sum_All.Location = new System.Drawing.Point(126, 21);
            this.lbl_Sum_All.Name = "lbl_Sum_All";
            this.lbl_Sum_All.Size = new System.Drawing.Size(132, 17);
            this.lbl_Sum_All.TabIndex = 3;
            this.lbl_Sum_All.Text = "Prikaži vse";
            // 
            // lbl_Sum_WithoutTax
            // 
            this.lbl_Sum_WithoutTax.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_Sum_WithoutTax.Location = new System.Drawing.Point(387, 24);
            this.lbl_Sum_WithoutTax.Name = "lbl_Sum_WithoutTax";
            this.lbl_Sum_WithoutTax.Size = new System.Drawing.Size(165, 15);
            this.lbl_Sum_WithoutTax.TabIndex = 4;
            this.lbl_Sum_WithoutTax.Text = "Prikaži vse";
            // 
            // lbl_Sum_Tax
            // 
            this.lbl_Sum_Tax.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_Sum_Tax.Location = new System.Drawing.Point(256, 21);
            this.lbl_Sum_Tax.Name = "lbl_Sum_Tax";
            this.lbl_Sum_Tax.Size = new System.Drawing.Size(132, 17);
            this.lbl_Sum_Tax.TabIndex = 5;
            this.lbl_Sum_Tax.Text = "Prikaži vse";
            // 
            // dgvx_XInvoice
            // 
            this.dgvx_XInvoice.AllowDrop = true;
            this.dgvx_XInvoice.AllowUserToAddRows = false;
            this.dgvx_XInvoice.AllowUserToDeleteRows = false;
            this.dgvx_XInvoice.AllowUserToOrderColumns = true;
            this.dgvx_XInvoice.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvx_XInvoice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvx_XInvoice.DataGridViewWithRowNumber = true;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvx_XInvoice.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvx_XInvoice.Location = new System.Drawing.Point(4, 42);
            this.dgvx_XInvoice.MultiSelect = false;
            this.dgvx_XInvoice.Name = "dgvx_XInvoice";
            this.dgvx_XInvoice.ReadOnly = true;
            this.dgvx_XInvoice.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvx_XInvoice.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvx_XInvoice.Size = new System.Drawing.Size(826, 561);
            this.dgvx_XInvoice.TabIndex = 0;
            this.dgvx_XInvoice.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvx_XInvoice_CellFormatting);
            // 
            // lbl_Payment1
            // 
            this.lbl_Payment1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_Payment1.Location = new System.Drawing.Point(559, 1);
            this.lbl_Payment1.Name = "lbl_Payment1";
            this.lbl_Payment1.Size = new System.Drawing.Size(180, 19);
            this.lbl_Payment1.TabIndex = 6;
            this.lbl_Payment1.Text = "Prikaži vse";
            // 
            // lbl_Payment2
            // 
            this.lbl_Payment2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_Payment2.Location = new System.Drawing.Point(559, 21);
            this.lbl_Payment2.Name = "lbl_Payment2";
            this.lbl_Payment2.Size = new System.Drawing.Size(180, 16);
            this.lbl_Payment2.TabIndex = 7;
            this.lbl_Payment2.Text = "Prikaži vse";
            // 
            // btn_Print
            // 
            this.btn_Print.CausesValidation = false;
            this.btn_Print.Image = global::Tangenta.Properties.Resources.Print;
            this.btn_Print.Location = new System.Drawing.Point(71, 1);
            this.btn_Print.Name = "btn_Print";
            this.btn_Print.Size = new System.Drawing.Size(55, 37);
            this.btn_Print.TabIndex = 8;
            this.btn_Print.UseVisualStyleBackColor = true;
            this.btn_Print.Click += new System.EventHandler(this.btn_Print_Click);
            // 
            // btn_TimeSpan
            // 
            this.btn_TimeSpan.Image = global::Tangenta.Properties.Resources.TimeSpan;
            this.btn_TimeSpan.Location = new System.Drawing.Point(3, 1);
            this.btn_TimeSpan.Name = "btn_TimeSpan";
            this.btn_TimeSpan.Size = new System.Drawing.Size(56, 38);
            this.btn_TimeSpan.TabIndex = 2;
            this.btn_TimeSpan.UseVisualStyleBackColor = true;
            this.btn_TimeSpan.Click += new System.EventHandler(this.btn_TimeSpan_Click);
            // 
            // usrc_InvoiceTable
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.btn_Print);
            this.Controls.Add(this.lbl_Payment2);
            this.Controls.Add(this.lbl_Payment1);
            this.Controls.Add(this.lbl_Sum_Tax);
            this.Controls.Add(this.lbl_Sum_WithoutTax);
            this.Controls.Add(this.lbl_Sum_All);
            this.Controls.Add(this.btn_TimeSpan);
            this.Controls.Add(this.lbl_From_To);
            this.Controls.Add(this.dgvx_XInvoice);
            this.Name = "usrc_InvoiceTable";
            this.Size = new System.Drawing.Size(831, 604);
            ((System.ComponentModel.ISupportInitialize)(this.dgvx_XInvoice)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView_2xls.DataGridView2xls dgvx_XInvoice;
        private System.Windows.Forms.Button btn_TimeSpan;
        private System.Windows.Forms.Button btn_Print;
        internal System.Windows.Forms.Label lbl_From_To;
        internal System.Windows.Forms.Label lbl_Sum_All;
        internal System.Windows.Forms.Label lbl_Sum_WithoutTax;
        internal System.Windows.Forms.Label lbl_Sum_Tax;
        internal System.Windows.Forms.Label lbl_Payment1;
        internal System.Windows.Forms.Label lbl_Payment2;

    }
}
