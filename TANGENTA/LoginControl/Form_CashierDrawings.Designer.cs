namespace LoginControl
{
    partial class Form_CashierDrawings
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
            this.usrc_CashierActivity1 = new LoginControl.usrc_CashierActivity();
            this.btn_PrintSingle = new System.Windows.Forms.Button();
            this.btn_Exit = new System.Windows.Forms.Button();
            this.dgvx_CashierDrawings = new DataGridView_2xls.DataGridView2xls();
            this.btn_PrintMany = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvx_CashierDrawings)).BeginInit();
            this.SuspendLayout();
            // 
            // usrc_CashierActivity1
            // 
            this.usrc_CashierActivity1.Location = new System.Drawing.Point(1, 53);
            this.usrc_CashierActivity1.Name = "usrc_CashierActivity1";
            this.usrc_CashierActivity1.Size = new System.Drawing.Size(684, 188);
            this.usrc_CashierActivity1.TabIndex = 0;
            // 
            // btn_PrintSingle
            // 
            this.btn_PrintSingle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_PrintSingle.Location = new System.Drawing.Point(1, 1);
            this.btn_PrintSingle.Name = "btn_PrintSingle";
            this.btn_PrintSingle.Size = new System.Drawing.Size(255, 46);
            this.btn_PrintSingle.TabIndex = 51;
            this.btn_PrintSingle.Text = "PRINT";
            this.btn_PrintSingle.UseVisualStyleBackColor = true;
            this.btn_PrintSingle.Click += new System.EventHandler(this.btn_PrintSingle_Click);
            // 
            // btn_Exit
            // 
            this.btn_Exit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_Exit.Image = global::LoginControl.Properties.Resources.Exit;
            this.btn_Exit.Location = new System.Drawing.Point(554, 1);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(132, 46);
            this.btn_Exit.TabIndex = 49;
            this.btn_Exit.UseVisualStyleBackColor = true;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // dgvx_CashierDrawings
            // 
            this.dgvx_CashierDrawings.AllowUserToAddRows = false;
            this.dgvx_CashierDrawings.AllowUserToDeleteRows = false;
            this.dgvx_CashierDrawings.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvx_CashierDrawings.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvx_CashierDrawings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvx_CashierDrawings.DataGridViewWithRowNumber = false;
            this.dgvx_CashierDrawings.Location = new System.Drawing.Point(5, 247);
            this.dgvx_CashierDrawings.Name = "dgvx_CashierDrawings";
            this.dgvx_CashierDrawings.ReadOnly = true;
            this.dgvx_CashierDrawings.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvx_CashierDrawings.ShowRowErrors = false;
            this.dgvx_CashierDrawings.Size = new System.Drawing.Size(681, 377);
            this.dgvx_CashierDrawings.TabIndex = 52;
            // 
            // btn_PrintMany
            // 
            this.btn_PrintMany.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_PrintMany.Location = new System.Drawing.Point(262, 1);
            this.btn_PrintMany.Name = "btn_PrintMany";
            this.btn_PrintMany.Size = new System.Drawing.Size(286, 46);
            this.btn_PrintMany.TabIndex = 53;
            this.btn_PrintMany.Text = "PRINT";
            this.btn_PrintMany.UseVisualStyleBackColor = true;
            this.btn_PrintMany.Click += new System.EventHandler(this.btn_PrintMany_Click);
            // 
            // Form_CashierDrawings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(688, 631);
            this.Controls.Add(this.btn_PrintMany);
            this.Controls.Add(this.dgvx_CashierDrawings);
            this.Controls.Add(this.btn_PrintSingle);
            this.Controls.Add(this.btn_Exit);
            this.Controls.Add(this.usrc_CashierActivity1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "Form_CashierDrawings";
            this.Text = "Form_CloseCashier";
            this.Load += new System.EventHandler(this.Form_CashierDrawings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvx_CashierDrawings)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private usrc_CashierActivity usrc_CashierActivity1;
        private System.Windows.Forms.Button btn_PrintSingle;
        private System.Windows.Forms.Button btn_Exit;
        private DataGridView_2xls.DataGridView2xls dgvx_CashierDrawings;
        private System.Windows.Forms.Button btn_PrintMany;
    }
}