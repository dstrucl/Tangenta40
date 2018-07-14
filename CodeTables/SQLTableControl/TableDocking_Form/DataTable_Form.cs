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
using DBConnectionControl40;

namespace CodeTables
{
    public partial class DataTable_Form : Form
    {
        public enum DataTable_Form_ENUM { CREATE, EDIT_OR_DELETE };
        DataTable m_dt;
        DataTable_Form_ENUM m_Mode;

        //MyDataBase m_DB;
        DBTableControl m_DBTables;
        SQLTable m_tbl;

        public TableDockingForm m_TableDockingForm;

        public DataTable_Form(DBTableControl dbTables, SQLTable tbl, DataTable_Form_ENUM eMode, TableDockingForm pForm)
        {
            //m_DB = pDB;
            m_DBTables = dbTables;
            m_Mode = eMode;
            m_tbl = tbl;

            m_TableDockingForm = pForm;


            this.Icon = Properties.Resources.table;
            InitializeComponent();
            SetControls(m_tbl);
        }


        public bool FillDataTable(ref DataTable dt,SQLTable tbl,ref string csError)
        {
            if (dt != null)
            {
                dt.Dispose();
                dt = null;
            }
            dt = new DataTable();

            if (m_tbl.GetTableData(m_DBTables.m_con, ref m_dt, ref csError,100,null))
            {
                dataGridView_Table.DataSource = m_dt;
                dataGridView_Table.Visible = true;
                dataGridView_Table.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);
                return true;
            }
            else
            {
                return false;
            }
        }

        internal void SetControls(SQLTable tbl)
        {
            try
            {
                m_tbl = tbl;
                this.btn_CreateImportExportTemplate.Text = lng.s_ExportTemplateToolStripMenuItem.s;

                if (m_Mode == DataTable_Form_ENUM.EDIT_OR_DELETE)
                {
                    lbl_Instruction.Visible = false;
                    //btn_DeleteRows.Text = lng.s_DeleteRows.s;
                    //btn_Create.Text = lng.s_Create.s;
                    //btn_Edit.Text = lng.s_Edit.s;
                    //btn_Delete.Text = lng.s_Delete.s;
                    //dataGridView_Table.DataSource = m_dt;
                    //dataGridView_Table.Visible = true;
                    //dataGridView_Table.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);
                    string csError = "";
      
                    if (!FillDataTable(ref m_dt,tbl, ref csError))
                    {
                        MessageBox.Show(csError);
                    }
                    else
                    {
                        this.Text = m_tbl.lngTableName.s + " (" + m_dt.TableName + ")";
                    }
                    if (m_dt.Rows.Count > 0)
                    {
                        //                       btn_DeleteRows.Enabled = true;
                    }
                    else
                    {
                        //                        btn_DeleteRows.Enabled = false;
                    }

                    this.Update();
                }
                else
                {
                    lbl_Instruction.Visible = true;
                    lbl_Instruction.Text = lng.s_CreateTableInstruction.s + "'" + m_dt.TableName + "'.";
                    //btn_DeleteRows.Enabled = false;
                    //btn_Create.Enabled = true;
                    //btn_Edit.Enabled = false;
                    //btn_Delete.Enabled = false;
                    //btn_Create.Text = lng.s_Create.s;
                    //btn_Edit.Text = lng.s_Edit.s;
                    //btn_Delete.Text = lng.s_Delete.s;
                    dataGridView_Table.Visible = false;

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(lng.s_Err_TableNameDoesNotExist.s + m_dt.TableName + "\n\"Exception\"=" + ex.Message);
            }
        }

        private void DataTable_Form_Load(object sender, EventArgs e)
        {
        }

        private void btn_CreateImportExportTemplate_Click(object sender, EventArgs e)
        {
            StringBuilder sExportImportTamplate = new StringBuilder();
            sExportImportTamplate.Append("// 1\n");
            sExportImportTamplate.Append("<" + m_tbl.TableName + ">\n");
            m_tbl.CreateImportExportTemplate("", ref sExportImportTamplate);
            sExportImportTamplate.Append("</" + m_tbl.TableName + ">\n");
            TextEditorDialog Editor = new TextEditorDialog(sExportImportTamplate.ToString(), m_tbl.TableName + ".txt", Globals.MainWindow);
            Editor.ShowDialog();
        }

        private void btn_EditTable_Click(object sender, EventArgs e)
        {
            //EditTable_Form EditTableDlg = new EditTable_Form(m_DB, m_tbl,this);
            //EditTableDlg.Owner = this;
            //EditTableDlg.Show();
        }



        //private void button1_Click(object sender, EventArgs e)
        //{
        //    DataAdapter_Form DAdapterForm = new DataAdapter_Form();
        //    DAdapterForm.Show();

        //}

        private void dataGridView_Table_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewSelectedCellCollection dgvCellCollection = dataGridView_Table.SelectedCells;
            if (dgvCellCollection.Count >= 1)
            {
                lbl_test_sender_type.Text = "Count:" + dgvCellCollection.Count.ToString() + " CellType=" + dgvCellCollection[0].GetType().ToString() + " ValueType" + dgvCellCollection[0].Value.GetType().ToString() + " Value=" + dgvCellCollection[0].Value.ToString() + " Column Name = " + dgvCellCollection[0].OwningColumn.Name;
                if (dgvCellCollection[0].OwningRow.Cells["ID"].Value.GetType() == typeof(int))
                {
                    ID Identity = new ID(dgvCellCollection[0].OwningRow.Cells["ID"].Value);
                    if (this.m_TableDockingForm.m_EditTable_Form != null)
                    {
                        m_TableDockingForm.m_EditTable_Form.ShowTableRow(Identity);
                    }
                }
            }
            else
            {
                lbl_test_sender_type.Text = "Num Selected cels = 0";
            }
        }


        internal void UpdateForm()
        {
            string csError = null;
            FillDataTable(ref m_dt, m_tbl, ref csError);
        }
    }
}
