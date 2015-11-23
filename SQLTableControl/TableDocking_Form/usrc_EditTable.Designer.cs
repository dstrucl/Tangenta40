namespace SQLTableControl.TableDocking_Form
{
    partial class usrc_EditTable
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.usrc_EditRow = new SQLTableControl.TableDocking_Form.usrc_EditRow();
            this.dgvx_Table = new DataGridView_2xls.DataGridView2xls();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvx_Table)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.usrc_EditRow);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvx_Table);
            this.splitContainer1.Size = new System.Drawing.Size(943, 626);
            this.splitContainer1.SplitterDistance = 454;
            this.splitContainer1.TabIndex = 0;
            // 
            // usrc_EditRow
            // 
            this.usrc_EditRow.AllowUserToAddNew = true;
            this.usrc_EditRow.AllowUserToChange = true;
            this.usrc_EditRow.bNewDataEntry = false;
            this.usrc_EditRow.Changed = false;
            this.usrc_EditRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.usrc_EditRow.GetRandomData = true;
            this.usrc_EditRow.Location = new System.Drawing.Point(0, 0);
            this.usrc_EditRow.Name = "usrc_EditRow";
            this.usrc_EditRow.SelectionButtonVisible = true;
            this.usrc_EditRow.Size = new System.Drawing.Size(450, 622);
            this.usrc_EditRow.TabIndex = 0;
            this.usrc_EditRow.Title = "";
            this.usrc_EditRow.Title_Color = System.Drawing.SystemColors.ControlText;
            this.usrc_EditRow.Title_Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.usrc_EditRow.FillTable += new SQLTableControl.SQLTable.delegate_FillTable(this.usrc_EditRow_FillTable);
            this.usrc_EditRow.SetInputControlProperties += new SQLTableControl.SQLTable.delegate_mySetInputControlProperties(this.usrc_EditRow_SetInputControlProperties);
            this.usrc_EditRow.before_New += new SQLTableControl.TableDocking_Form.usrc_EditRow.delegate_before_New(this.usrc_EditRow_before_New);
            this.usrc_EditRow.after_New += new SQLTableControl.TableDocking_Form.usrc_EditRow.delegate_after_New(this.usrc_EditRow_after_New);
            this.usrc_EditRow.before_InsertInDataBase += new SQLTableControl.TableDocking_Form.usrc_EditRow.delegate_before_InsertInDataBase(this.usrc_EditRow_before_InsertInDataBase);
            this.usrc_EditRow.after_InsertInDataBase += new SQLTableControl.TableDocking_Form.usrc_EditRow.delegate_after_InsertInDataBase(this.usrc_EditRow_after_InsertInDataBase);
            this.usrc_EditRow.before_UpdateDataBase += new SQLTableControl.TableDocking_Form.usrc_EditRow.delegate_before_UpdateDataBase(this.usrc_EditRow_before_UpdateDataBase);
            this.usrc_EditRow.after_UpdateDataBase += new SQLTableControl.TableDocking_Form.usrc_EditRow.delegate_after_UpdateDataBase(this.usrc_EditRow_after_UpdateDataBase);
            this.usrc_EditRow.RowReferenceFromTable_Check_NoChangeToOther += new SQLTableControl.TableDocking_Form.usrc_EditRow.delegate_RowReferenceFromTable_Check_NoChangeToOther(this.usrc_EditRow_RowReferenceFromTable_Check_NoChangeToOther);
            this.usrc_EditRow.after_FillDataInputControl += new SQLTableControl.TableDocking_Form.usrc_EditRow.delegate_after_FillDataInputControl(this.usrc_EditRow_after_FillDataInputControl);
            this.usrc_EditRow.Update += new SQLTableControl.TableDocking_Form.usrc_EditRow.delegate_Update(this.usrc_EditRow_Update);
            // 
            // dgvx_Table
            // 
            this.dgvx_Table.AllowUserToAddRows = false;
            this.dgvx_Table.AllowUserToDeleteRows = false;
            this.dgvx_Table.AllowUserToOrderColumns = true;
            this.dgvx_Table.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvx_Table.DataGridViewWithRowNumber = false;
            this.dgvx_Table.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvx_Table.Location = new System.Drawing.Point(0, 0);
            this.dgvx_Table.Name = "dgvx_Table";
            this.dgvx_Table.ReadOnly = true;
            this.dgvx_Table.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvx_Table.Size = new System.Drawing.Size(481, 622);
            this.dgvx_Table.TabIndex = 0;
            this.dgvx_Table.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvx_Table_CellFormatting);
            // 
            // usrc_EditTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "usrc_EditTable";
            this.Size = new System.Drawing.Size(943, 626);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvx_Table)).EndInit();
            this.ResumeLayout(false);

        }


        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private DataGridView_2xls.DataGridView2xls dgvx_Table;
        private usrc_EditRow usrc_EditRow;
    }
}
