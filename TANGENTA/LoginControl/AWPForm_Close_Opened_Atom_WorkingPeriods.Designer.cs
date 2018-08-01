namespace LoginControl
{
    partial class AWPForm_Close_Opened_Atom_WorkingPeriods
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
            this.dgvx_Close_Opened_Atom_WorkingPeriods = new DataGridView_2xls.DataGridView2xls();
            this.btn_Close_Opened_Atom_WorkingPeriods = new System.Windows.Forms.Button();
            this.lbl_Instruction = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvx_Close_Opened_Atom_WorkingPeriods)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvx_Close_Opened_Atom_WorkingPeriods
            // 
            this.dgvx_Close_Opened_Atom_WorkingPeriods.AllowUserToAddRows = false;
            this.dgvx_Close_Opened_Atom_WorkingPeriods.AllowUserToDeleteRows = false;
            this.dgvx_Close_Opened_Atom_WorkingPeriods.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvx_Close_Opened_Atom_WorkingPeriods.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvx_Close_Opened_Atom_WorkingPeriods.DataGridViewWithRowNumber = false;
            this.dgvx_Close_Opened_Atom_WorkingPeriods.Location = new System.Drawing.Point(2, 101);
            this.dgvx_Close_Opened_Atom_WorkingPeriods.Name = "dgvx_Close_Opened_Atom_WorkingPeriods";
            this.dgvx_Close_Opened_Atom_WorkingPeriods.ReadOnly = true;
            this.dgvx_Close_Opened_Atom_WorkingPeriods.Size = new System.Drawing.Size(877, 220);
            this.dgvx_Close_Opened_Atom_WorkingPeriods.TabIndex = 0;
            // 
            // btn_Close_Opened_Atom_WorkingPeriods
            // 
            this.btn_Close_Opened_Atom_WorkingPeriods.Location = new System.Drawing.Point(2, 62);
            this.btn_Close_Opened_Atom_WorkingPeriods.Name = "btn_Close_Opened_Atom_WorkingPeriods";
            this.btn_Close_Opened_Atom_WorkingPeriods.Size = new System.Drawing.Size(248, 33);
            this.btn_Close_Opened_Atom_WorkingPeriods.TabIndex = 1;
            this.btn_Close_Opened_Atom_WorkingPeriods.Text = "Close_Opened_Atom_WorkingPeriods";
            this.btn_Close_Opened_Atom_WorkingPeriods.UseVisualStyleBackColor = true;
            this.btn_Close_Opened_Atom_WorkingPeriods.Click += new System.EventHandler(this.btn_Close_Opened_Atom_WorkingPeriods_Click);
            // 
            // lbl_Instruction
            // 
            this.lbl_Instruction.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Instruction.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_Instruction.ForeColor = System.Drawing.Color.Blue;
            this.lbl_Instruction.Location = new System.Drawing.Point(8, 4);
            this.lbl_Instruction.Name = "lbl_Instruction";
            this.lbl_Instruction.Size = new System.Drawing.Size(871, 55);
            this.lbl_Instruction.TabIndex = 2;
            this.lbl_Instruction.Text = "Some working periods were not closed";
            // 
            // AWPForm_Close_Opened_Atom_WorkingPeriods
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(883, 321);
            this.Controls.Add(this.lbl_Instruction);
            this.Controls.Add(this.btn_Close_Opened_Atom_WorkingPeriods);
            this.Controls.Add(this.dgvx_Close_Opened_Atom_WorkingPeriods);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "AWPForm_Close_Opened_Atom_WorkingPeriods";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AWPForm_Close_Opened_Atom_WorkingPeriods";
            this.Load += new System.EventHandler(this.AWPForm_Close_Opened_Atom_WorkingPeriods_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvx_Close_Opened_Atom_WorkingPeriods)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView_2xls.DataGridView2xls dgvx_Close_Opened_Atom_WorkingPeriods;
        private System.Windows.Forms.Button btn_Close_Opened_Atom_WorkingPeriods;
        private System.Windows.Forms.Label lbl_Instruction;
    }
}