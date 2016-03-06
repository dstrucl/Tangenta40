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
    public partial class SelectID_Table_Assistant_Form : Form
    {
        public long ID = -1;
        string m_sql = null;
        SQLTable m_tbl;
        DataTable m_dt;
        DBTableControl m_DBTables;
        string[] ColumnToView = null;

        public SelectID_Table_Assistant_Form(SQLTable tbl, DBTableControl xDBTables,string[] xsCoumnsToView)
        {
            m_DBTables = xDBTables;
            m_tbl = tbl;
            m_sql = null;
            InitializeComponent();
            this.Text = tbl.lngTableName.s + " (" + tbl.TableName + ")";
            string csError="";
            ColumnToView = xsCoumnsToView;
            FillDataTable(ref csError);
            this.btn_Cancel.Text = lngRPM.s_Cancel.s;
            
        }

        public SelectID_Table_Assistant_Form(string sql, SQLTable tbl, DBTableControl xDBTables, string[] xsCoumnsToView)
        {

            InitializeComponent();
            m_sql = sql;
            m_DBTables = xDBTables;
            m_tbl = tbl;
            this.Text = tbl.lngTableName.s + " (" + tbl.TableName + ")";
            string csError = "";
            ColumnToView = xsCoumnsToView;
            FillDataTable(ref csError);
            this.btn_Cancel.Text = lngRPM.s_Cancel.s;

        }

        public bool FillDataTable(ref string csError)
        {

            if (m_dt != null)
            {
                m_dt.Dispose();
                m_dt = null;
            }
            m_dt = new DataTable();

            if (m_sql != null)
            {
                string Err = null;
                if (m_DBTables.m_con.ReadDataTable(ref m_dt, m_sql,ref Err))
                {
                    dataGridView.DataSource = m_dt;
                    string[] table_names = new string[]{"cGsmNumber_Person",
                                                        "cPhoneNumber_Person",
                                                        "cEmail_Person",
                                                        "cStreetName_Person",
                                                        "cHouseNumber_Person",
                                                        "cCity_Person",
                                                        "cZIP_Person",
                                                        "cCountry_Person",
                                                        "cState_Person",
                                                        "PersonData",
                                                        "PersonImage"
                                                        };
                    m_DBTables.SetVIEW_DataGridViewImageColumns_Headers((DataGridView)dataGridView, m_tbl, table_names);
                    ArrangeColumns();
                    return true;
                }
                else
                {
                    LogFile.Error.Show("ERROR:CodeTables:SelectID_Table_Assistant_Form:FillDataTable:sql=" + m_sql + "\r\nErr=" + Err);
                    return false;
                }
            }
            else
            {
                if (m_tbl.GetTableView(m_DBTables.m_con, ref m_dt, ref csError, 1000))
                {
                    dataGridView.DataSource = m_dt;
                    m_tbl.SetVIEW_DataGridViewImageColumns_Headers((DataGridView)dataGridView, m_DBTables);
                    ArrangeColumns();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        private void ArrangeColumns()
        {
            dataGridView.Visible = true;
            dataGridView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);
            if (ColumnToView != null)
            {
                foreach (DataGridViewColumn dgvc in dataGridView.Columns)
                {
                    dgvc.Visible = false;
                }
                int i = 0;
                int iCount = ColumnToView.Count();
                string scolname = null;
                for (i = 0; i < iCount; i++)
                {
                    scolname = ColumnToView[i];
                    dataGridView.Columns[scolname].Visible = true;
                    dataGridView.Columns[scolname].DisplayIndex = i;
                }

            }

        }
        private void dataGridView_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewSelectedCellCollection dgvCellCollection = dataGridView.SelectedCells;
            if (dgvCellCollection.Count >= 1)
            {
                //lbl_test_sender_type.Text = "Count:" + dgvCellCollection.Count.ToString() + " CellType=" + dgvCellCollection[0].GetType().ToString() + " ValueType" + dgvCellCollection[0].Value.GetType().ToString() + " Value=" + dgvCellCollection[0].Value.ToString() + " Column Name = " + dgvCellCollection[0].OwningColumn.Name;
                if (dgvCellCollection[0].OwningRow.Cells["ID"].Value.GetType() == typeof(long))
                {
                    ID = (long)dgvCellCollection[0].OwningRow.Cells["ID"].Value;
                }
            }
         }

        private void EditTable_Assistant_Form_Load(object sender, EventArgs e)
        {
            if (m_dt.Rows.Count > 0)
            {
                dataGridView.Rows[0].Selected = false;
            }
            this.dataGridView.SelectionChanged += new System.EventHandler(this.dataGridView_SelectionChanged);
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            ID = -1;
            this.Close();
            DialogResult = DialogResult.Cancel;
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            this.Close();
            DialogResult = DialogResult.OK;
        }

    }
}
