namespace CodeTables.TableDocking_Form
{
    partial class TableView_Form
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsmi_Select_View = new System.Windows.Forms.ToolStripMenuItem();
            this.lblPrimaryView = new System.Windows.Forms.Label();
            this.lblViewName = new System.Windows.Forms.Label();
            this.label_ViewName = new System.Windows.Forms.Label();
            this.chkBox_BindWith_EditTable_Form = new System.Windows.Forms.CheckBox();
            this.label_PrimaryView = new System.Windows.Forms.Label();
            this.lbl_Rows_Count = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Table)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_Table
            // 
            this.dataGridView_Table.AllowUserToAddRows = false;
            this.dataGridView_Table.AllowUserToDeleteRows = false;
            this.dataGridView_Table.AllowUserToOrderColumns = true;
            this.dataGridView_Table.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_Table.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dataGridView_Table.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Table.Location = new System.Drawing.Point(2, 73);
            this.dataGridView_Table.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView_Table.MultiSelect = false;
            this.dataGridView_Table.Name = "dataGridView_Table";
            this.dataGridView_Table.RowTemplate.Height = 24;
            this.dataGridView_Table.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_Table.Size = new System.Drawing.Size(1001, 395);
            this.dataGridView_Table.TabIndex = 1;
            this.dataGridView_Table.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView_Table_CellFormatting);
            this.dataGridView_Table.SelectionChanged += new System.EventHandler(this.dataGridView_Table_SelectionChanged);
            this.dataGridView_Table.ColumnAdded += new System.Windows.Forms.DataGridViewColumnEventHandler(this.dataGridView_Table_ColumnAdded);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1003, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsmi_Select_View
            // 
            this.tsmi_Select_View.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmi_Select_View.Name = "tsmi_Select_View";
            this.tsmi_Select_View.Size = new System.Drawing.Size(82, 20);
            this.tsmi_Select_View.Text = "Select View";
            this.tsmi_Select_View.Click += new System.EventHandler(this.tsmi_Select_View_Click);
            // 
            // lblPrimaryView
            // 
            this.lblPrimaryView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblPrimaryView.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrimaryView.ForeColor = System.Drawing.SystemColors.InfoText;
            this.lblPrimaryView.Location = new System.Drawing.Point(705, 35);
            this.lblPrimaryView.Name = "lblPrimaryView";
            this.lblPrimaryView.Size = new System.Drawing.Size(286, 24);
            this.lblPrimaryView.TabIndex = 12;
            this.lblPrimaryView.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblPrimaryView.Click += new System.EventHandler(this.lblPrimaryView_Click);
            // 
            // lblViewName
            // 
            this.lblViewName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblViewName.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblViewName.ForeColor = System.Drawing.SystemColors.InfoText;
            this.lblViewName.Location = new System.Drawing.Point(705, 0);
            this.lblViewName.Name = "lblViewName";
            this.lblViewName.Size = new System.Drawing.Size(286, 24);
            this.lblViewName.TabIndex = 10;
            this.lblViewName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_ViewName
            // 
            this.label_ViewName.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_ViewName.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label_ViewName.Location = new System.Drawing.Point(644, 0);
            this.label_ViewName.Name = "label_ViewName";
            this.label_ViewName.Size = new System.Drawing.Size(54, 24);
            this.label_ViewName.TabIndex = 9;
            this.label_ViewName.Text = "label1";
            this.label_ViewName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label_ViewName.Click += new System.EventHandler(this.label_ViewName_Click);
            // 
            // chkBox_BindWith_EditTable_Form
            // 
            this.chkBox_BindWith_EditTable_Form.AutoSize = true;
            this.chkBox_BindWith_EditTable_Form.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkBox_BindWith_EditTable_Form.Location = new System.Drawing.Point(12, 27);
            this.chkBox_BindWith_EditTable_Form.Name = "chkBox_BindWith_EditTable_Form";
            this.chkBox_BindWith_EditTable_Form.Size = new System.Drawing.Size(102, 21);
            this.chkBox_BindWith_EditTable_Form.TabIndex = 13;
            this.chkBox_BindWith_EditTable_Form.Text = "checkBox1";
            this.chkBox_BindWith_EditTable_Form.UseVisualStyleBackColor = true;
            this.chkBox_BindWith_EditTable_Form.CheckedChanged += new System.EventHandler(this.chkBox_BindWith_EditTable_Form_CheckedChanged);
            // 
            // label_PrimaryView
            // 
            this.label_PrimaryView.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_PrimaryView.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label_PrimaryView.Location = new System.Drawing.Point(545, 36);
            this.label_PrimaryView.Name = "label_PrimaryView";
            this.label_PrimaryView.Size = new System.Drawing.Size(153, 23);
            this.label_PrimaryView.TabIndex = 11;
            this.label_PrimaryView.Text = "label1";
            this.label_PrimaryView.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label_PrimaryView.Click += new System.EventHandler(this.label_PrimaryView_Click);
            // 
            // lbl_Rows_Count
            // 
            this.lbl_Rows_Count.AutoSize = true;
            this.lbl_Rows_Count.Location = new System.Drawing.Point(12, 49);
            this.lbl_Rows_Count.Name = "lbl_Rows_Count";
            this.lbl_Rows_Count.Size = new System.Drawing.Size(89, 17);
            this.lbl_Rows_Count.TabIndex = 14;
            this.lbl_Rows_Count.Text = "Rows Count";
            // 
            // TableView_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1003, 471);
            this.Controls.Add(this.lbl_Rows_Count);
            this.Controls.Add(this.chkBox_BindWith_EditTable_Form);
            this.Controls.Add(this.lblPrimaryView);
            this.Controls.Add(this.label_PrimaryView);
            this.Controls.Add(this.lblViewName);
            this.Controls.Add(this.label_ViewName);
            this.Controls.Add(this.dataGridView_Table);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "TableView_Form";
            this.Text = "TableView_Form";
            this.Load += new System.EventHandler(this.TableView_Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Table)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataGridView dataGridView_Table;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Select_View;
        private System.Windows.Forms.Label lblPrimaryView;
        private System.Windows.Forms.Label lblViewName;
        private System.Windows.Forms.Label label_ViewName;
        private System.Windows.Forms.CheckBox chkBox_BindWith_EditTable_Form;
        private System.Windows.Forms.Label label_PrimaryView;
        private System.Windows.Forms.Label lbl_Rows_Count;
    }
}