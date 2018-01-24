#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LanguageControl;

namespace CodeTables
{
    public partial class EditTable_Assistant_Form : Form
    {
        long Identity = -1;
        usrc_myGroupBox m_MyGroupBox;
        SQLTable m_tbl;
        DataTable m_dt;
        DBTableControl m_DBTables;
        int m_xpos = 0;
        int m_ypos = 0;
        ID_v my_start_up_id_v = null;

        public EditTable_Assistant_Form(usrc_myGroupBox mygrpbox, SQLTable tbl,ID_v id_v, DBTableControl xDBTables,int xpos, int ypos)
        {
            my_start_up_id_v = id_v;
            m_xpos = xpos;
            m_ypos = ypos;
            m_DBTables = xDBTables;
            m_MyGroupBox = mygrpbox;
            m_tbl = tbl;
            InitializeComponent();
            btn_Cancel.Text = lng.s_Cancel.s;
            this.Text = tbl.lngTableName.s + " (" + tbl.TableName + ")";
            string csError="";
            FillDataTable(ref csError);

        }

        public bool FillDataTable(ref string csError)
        {
            if (m_dt != null)
            {
                m_dt.Dispose();
                m_dt = null;
            }
            m_dt = new DataTable();
            if (m_tbl.GetTableView(m_DBTables.m_con, ref m_dt, ref csError,1000))
            {
                dataGridView.DataSource = m_dt;
                m_tbl.SetVIEW_DataGridViewImageColumns_Headers((DataGridView)dataGridView, m_DBTables);
                dataGridView.Visible = true;
                dataGridView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);
                dataGridView.ClearSelection();
                dataGridView.CurrentCell = null;
                Globals.ShowID_In_DataGrid(dataGridView);
                if (my_start_up_id_v != null)
                {
                    DataRow[] drs = m_dt.Select("ID = " + my_start_up_id_v.v.ToString());
                    if (drs.Count() > 0)
                    {
                        int idx = m_dt.Rows.IndexOf(drs[0]);
                        dataGridView.Rows[idx].Selected = true;
                        dataGridView.CurrentCell = dataGridView.Rows[idx].Cells[0];
                    }
                }
                
                return true;
            }
            else
            {
                return false;
            }
        }

        //private void dataGridView_SelectionChanged(object sender, EventArgs e)
        //{
        //    DataGridViewSelectedCellCollection dgvCellCollection = dataGridView.SelectedCells;
        //    if (dgvCellCollection.Count >= 1)
        //    {
        //        //lbl_test_sender_type.Text = "Count:" + dgvCellCollection.Count.ToString() + " CellType=" + dgvCellCollection[0].GetType().ToString() + " ValueType" + dgvCellCollection[0].Value.GetType().ToString() + " Value=" + dgvCellCollection[0].Value.ToString() + " Column Name = " + dgvCellCollection[0].OwningColumn.Name;
        //        if (dgvCellCollection[0].OwningRow.Cells["ID"].Value.GetType() == typeof(long))
        //        {
        //            Identity = (long)dgvCellCollection[0].OwningRow.Cells["ID"].Value;
        //            m_MyGroupBox.pSQL_Table.iFillTableData = -1;
        //            m_MyGroupBox.FillInputControls(Identity,false);
        //        }
        //    }
        // }

        private void EditTable_Assistant_Form_Load(object sender, EventArgs e)
        {
            this.Left = m_xpos;
            this.Top = m_ypos;
            if (m_dt.Rows.Count > 0)
            {
                dataGridView.Rows[0].Selected = false;
            }
            //this.dataGridView.SelectionChanged += new System.EventHandler(this.dataGridView_SelectionChanged);
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
            DialogResult = DialogResult.Cancel;
        }

        private void dataGridView_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.Close();
                DialogResult = DialogResult.OK;
            }
            else if (e.KeyCode == Keys.Escape)
            {
                this.Close();
                DialogResult = DialogResult.Cancel;
            }
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
                DataGridViewSelectedCellCollection dgvCellCollection = dataGridView.SelectedCells;
                if (dgvCellCollection.Count >= 1)
                {
                    //lbl_test_sender_type.Text = "Count:" + dgvCellCollection.Count.ToString() + " CellType=" + dgvCellCollection[0].GetType().ToString() + " ValueType" + dgvCellCollection[0].Value.GetType().ToString() + " Value=" + dgvCellCollection[0].Value.ToString() + " Column Name = " + dgvCellCollection[0].OwningColumn.Name;
                    if (dgvCellCollection[0].OwningRow.Cells["ID"].Value.GetType() == typeof(long))
                    {
                        Identity = (long)dgvCellCollection[0].OwningRow.Cells["ID"].Value;
                        m_MyGroupBox.pSQL_Table.iFillTableData = -1;
                        m_MyGroupBox.FillInputControls(Identity,false);
                    }
                }
            this.Close();
            DialogResult = DialogResult.OK;
        }
    }
}
