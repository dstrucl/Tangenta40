namespace SQLTableControl
{
    partial class DataTable_Form
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
            this.dataGridView_Table = new System.Windows.Forms.DataGridView();
            this.lbl_Instruction = new System.Windows.Forms.Label();
            this.btn_CreateImportExportTemplate = new System.Windows.Forms.Button();
            this.btn_EditTable = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.lbl_test_sender_type = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Table)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_Table
            // 
            this.dataGridView_Table.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_Table.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Table.Location = new System.Drawing.Point(3, 37);
            this.dataGridView_Table.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView_Table.Name = "dataGridView_Table";
            this.dataGridView_Table.RowTemplate.Height = 24;
            this.dataGridView_Table.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView_Table.Size = new System.Drawing.Size(961, 377);
            this.dataGridView_Table.TabIndex = 0;
            this.dataGridView_Table.SelectionChanged += new System.EventHandler(this.dataGridView_Table_SelectionChanged);
            // 
            // lbl_Instruction
            // 
            this.lbl_Instruction.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Instruction.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbl_Instruction.Location = new System.Drawing.Point(47, 68);
            this.lbl_Instruction.Name = "lbl_Instruction";
            this.lbl_Instruction.Size = new System.Drawing.Size(532, 191);
            this.lbl_Instruction.TabIndex = 5;
            this.lbl_Instruction.Text = "lbl_Instruction";
            this.lbl_Instruction.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_CreateImportExportTemplate
            // 
            this.btn_CreateImportExportTemplate.Location = new System.Drawing.Point(3, 2);
            this.btn_CreateImportExportTemplate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_CreateImportExportTemplate.Name = "btn_CreateImportExportTemplate";
            this.btn_CreateImportExportTemplate.Size = new System.Drawing.Size(261, 30);
            this.btn_CreateImportExportTemplate.TabIndex = 6;
            this.btn_CreateImportExportTemplate.Text = "Create Export Import Table";
            this.btn_CreateImportExportTemplate.UseVisualStyleBackColor = true;
            this.btn_CreateImportExportTemplate.Click += new System.EventHandler(this.btn_CreateImportExportTemplate_Click);
            // 
            // btn_EditTable
            // 
            this.btn_EditTable.Location = new System.Drawing.Point(283, 4);
            this.btn_EditTable.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_EditTable.Name = "btn_EditTable";
            this.btn_EditTable.Size = new System.Drawing.Size(133, 26);
            this.btn_EditTable.TabIndex = 7;
            this.btn_EditTable.Text = "Edit Table";
            this.btn_EditTable.UseVisualStyleBackColor = true;
            this.btn_EditTable.Click += new System.EventHandler(this.btn_EditTable_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(445, 2);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(84, 28);
            this.button1.TabIndex = 8;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // lbl_test_sender_type
            // 
            this.lbl_test_sender_type.AutoSize = true;
            this.lbl_test_sender_type.Location = new System.Drawing.Point(551, 9);
            this.lbl_test_sender_type.Name = "lbl_test_sender_type";
            this.lbl_test_sender_type.Size = new System.Drawing.Size(46, 17);
            this.lbl_test_sender_type.TabIndex = 9;
            this.lbl_test_sender_type.Text = "label1";
            // 
            // DataTable_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(967, 418);
            this.Controls.Add(this.dataGridView_Table);
            this.Controls.Add(this.lbl_test_sender_type);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_EditTable);
            this.Controls.Add(this.btn_CreateImportExportTemplate);
            this.Controls.Add(this.lbl_Instruction);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "DataTable_Form";
            this.Text = "DataTable_Form";
            this.Load += new System.EventHandler(this.DataTable_Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Table)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_Instruction;
        private System.Windows.Forms.Button btn_CreateImportExportTemplate;
        private System.Windows.Forms.Button btn_EditTable;
        public System.Windows.Forms.DataGridView dataGridView_Table;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lbl_test_sender_type;
    }
}