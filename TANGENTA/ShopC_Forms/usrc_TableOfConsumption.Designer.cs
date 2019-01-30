namespace ShopC_Forms
{
    partial class usrc_TableOfConsumption
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(usrc_TableOfConsumption));
            this.lbl_From_To = new System.Windows.Forms.Label();
            this.lbl_Sum_All = new System.Windows.Forms.Label();
            this.lbl_Sum_WithoutTax = new System.Windows.Forms.Label();
            this.lbl_Sum_Tax = new System.Windows.Forms.Label();
            this.dgvx_XConsumption = new DataGridView_2xls.DataGridView2xls();
            this.lbl_Payment1 = new System.Windows.Forms.Label();
            this.lbl_Payment2 = new System.Windows.Forms.Label();
            this.btn_Print = new System.Windows.Forms.Button();
            this.btn_TimeSpan = new System.Windows.Forms.Button();
            this.lbl_SelectionDescription = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvx_XConsumption)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_From_To
            // 
            this.lbl_From_To.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_From_To.Location = new System.Drawing.Point(126, 22);
            this.lbl_From_To.Name = "lbl_From_To";
            this.lbl_From_To.Size = new System.Drawing.Size(427, 18);
            this.lbl_From_To.TabIndex = 1;
            this.lbl_From_To.Text = "Time from - to";
            // 
            // lbl_Sum_All
            // 
            this.lbl_Sum_All.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_Sum_All.Location = new System.Drawing.Point(126, 40);
            this.lbl_Sum_All.Name = "lbl_Sum_All";
            this.lbl_Sum_All.Size = new System.Drawing.Size(132, 17);
            this.lbl_Sum_All.TabIndex = 3;
            this.lbl_Sum_All.Text = "Sum All";
            // 
            // lbl_Sum_WithoutTax
            // 
            this.lbl_Sum_WithoutTax.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_Sum_WithoutTax.Location = new System.Drawing.Point(387, 40);
            this.lbl_Sum_WithoutTax.Name = "lbl_Sum_WithoutTax";
            this.lbl_Sum_WithoutTax.Size = new System.Drawing.Size(165, 17);
            this.lbl_Sum_WithoutTax.TabIndex = 4;
            this.lbl_Sum_WithoutTax.Text = "Sum Without Tax";
            // 
            // lbl_Sum_Tax
            // 
            this.lbl_Sum_Tax.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_Sum_Tax.Location = new System.Drawing.Point(256, 40);
            this.lbl_Sum_Tax.Name = "lbl_Sum_Tax";
            this.lbl_Sum_Tax.Size = new System.Drawing.Size(132, 17);
            this.lbl_Sum_Tax.TabIndex = 5;
            this.lbl_Sum_Tax.Text = "Sum Tax";
            // 
            // dgvx_XConsumption
            // 
            this.dgvx_XConsumption.AllowUserToAddRows = false;
            this.dgvx_XConsumption.AllowUserToDeleteRows = false;
            this.dgvx_XConsumption.AllowUserToOrderColumns = true;
            this.dgvx_XConsumption.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvx_XConsumption.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvx_XConsumption.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvx_XConsumption.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvx_XConsumption.DataGridViewWithRowNumber = true;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvx_XConsumption.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvx_XConsumption.Location = new System.Drawing.Point(4, 59);
            this.dgvx_XConsumption.Name = "dgvx_XConsumption";
            this.dgvx_XConsumption.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvx_XConsumption.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvx_XConsumption.Size = new System.Drawing.Size(826, 544);
            this.dgvx_XConsumption.TabIndex = 0;
            this.dgvx_XConsumption.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvx_XConsumption_CellFormatting);
            this.dgvx_XConsumption.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvx_XConsumption_CellMouseDown);
            this.dgvx_XConsumption.Sorted += new System.EventHandler(this.dgvx_XConsumption_Sorted);
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
            this.btn_Print.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_Print.CausesValidation = false;
            this.btn_Print.Image = ((System.Drawing.Image)(resources.GetObject("btn_Print.Image")));
            this.btn_Print.Location = new System.Drawing.Point(65, 4);
            this.btn_Print.Name = "btn_Print";
            this.btn_Print.Size = new System.Drawing.Size(55, 51);
            this.btn_Print.TabIndex = 8;
            this.btn_Print.UseVisualStyleBackColor = false;
            this.btn_Print.Click += new System.EventHandler(this.btn_Print_Click);
            // 
            // btn_TimeSpan
            // 
            this.btn_TimeSpan.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_TimeSpan.Image = ((System.Drawing.Image)(resources.GetObject("btn_TimeSpan.Image")));
            this.btn_TimeSpan.Location = new System.Drawing.Point(3, 4);
            this.btn_TimeSpan.Name = "btn_TimeSpan";
            this.btn_TimeSpan.Size = new System.Drawing.Size(55, 51);
            this.btn_TimeSpan.TabIndex = 2;
            this.btn_TimeSpan.UseVisualStyleBackColor = false;
            this.btn_TimeSpan.Click += new System.EventHandler(this.btn_TimeSpan_Click);
            // 
            // lbl_SelectionDescription
            // 
            this.lbl_SelectionDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_SelectionDescription.Location = new System.Drawing.Point(126, 4);
            this.lbl_SelectionDescription.Name = "lbl_SelectionDescription";
            this.lbl_SelectionDescription.Size = new System.Drawing.Size(427, 18);
            this.lbl_SelectionDescription.TabIndex = 9;
            this.lbl_SelectionDescription.Text = "Selection Description: All invoices or invoices of single user";
            // 
            // usrc_TableOfConsumption
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.lbl_SelectionDescription);
            this.Controls.Add(this.btn_Print);
            this.Controls.Add(this.lbl_Payment2);
            this.Controls.Add(this.lbl_Payment1);
            this.Controls.Add(this.lbl_Sum_Tax);
            this.Controls.Add(this.lbl_Sum_WithoutTax);
            this.Controls.Add(this.lbl_Sum_All);
            this.Controls.Add(this.btn_TimeSpan);
            this.Controls.Add(this.lbl_From_To);
            this.Controls.Add(this.dgvx_XConsumption);
            this.Name = "usrc_TableOfConsumption";
            this.Size = new System.Drawing.Size(831, 604);
            ((System.ComponentModel.ISupportInitialize)(this.dgvx_XConsumption)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView_2xls.DataGridView2xls dgvx_XConsumption;
        private System.Windows.Forms.Button btn_TimeSpan;
        private System.Windows.Forms.Button btn_Print;
        internal System.Windows.Forms.Label lbl_From_To;
        internal System.Windows.Forms.Label lbl_Sum_All;
        internal System.Windows.Forms.Label lbl_Sum_WithoutTax;
        internal System.Windows.Forms.Label lbl_Sum_Tax;
        internal System.Windows.Forms.Label lbl_Payment1;
        internal System.Windows.Forms.Label lbl_Payment2;
        internal System.Windows.Forms.Label lbl_SelectionDescription;
    }
}
