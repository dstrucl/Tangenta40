using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LanguageControl;
using StaticLib;

namespace SQLTableControl.TableDocking_Form
{
    public partial class TableView_Form : Form
    {
        DataTable m_dt;
        ViewXml m_ViewXml;
        TableDockingForm m_TableDockingForm;
        DBTableControl m_DBTables;
        SQLTable m_tbl;
        TableDockingFormXml m_pTableDockingFormXml;
        int m_Index;

        public TableView_Form(int iIndex, DBTableControl dbTables, SQLTable tbl, TableDockingForm dtF, ViewXml xViewXml)
        {
            m_Index = iIndex;
            m_DBTables = dbTables;
            m_tbl = tbl;
            m_TableDockingForm = dtF;
            m_ViewXml = xViewXml;
            m_pTableDockingFormXml = m_DBTables.m_xml.GetTableDockingFormXml(m_tbl.TableName);
            if (m_pTableDockingFormXml.m_TableViewFormXml[iIndex] == null)
            {
                m_pTableDockingFormXml.m_TableViewFormXml[iIndex] = new TableViewFormXml();
            }
            m_pTableDockingFormXml.m_TableViewFormXml[iIndex].m_DefaultViewXml = xViewXml;
            InitializeComponent();

            dataGridView_Table.ReadOnly = true;

            tsmi_Select_View.Text = lngRPM.s_SelectView.s;
            this.Text = lngRPM.s_View.s + " " + m_Index.ToString() + "   " + m_tbl.lngTableName.s;
            //            this.Text = m_tbl.lngTableName.s + " " + lngRPM.s_View.s + ":" + m_ViewXml.Name;
            string csError = "";
            this.label_PrimaryView.Text = lngRPM.s_PrimaryView.s;
            this.label_ViewName.Text = lngRPM.s_View.s;
            chkBox_BindWith_EditTable_Form.Text = lngRPM.s_ConnectWithEditTableForm.s;
            FillDataTable(ref csError);

        }

        public bool FillDataTable(ref string csError)
        {
            if (m_ViewXml != null)
            {
                this.lblViewName.Text = m_ViewXml.Name;

                if (m_pTableDockingFormXml.m_TableViewFormXml[m_Index].m_DefaultViewXml != null)
                {
                    this.lblPrimaryView.Text = m_pTableDockingFormXml.m_TableViewFormXml[m_Index].m_DefaultViewXml.Name;
                }

                if (m_dt != null)
                {
                    m_dt.Dispose();
                    m_dt = null;
                }
                m_dt = new DataTable();
                if (m_tbl.GetTableView(m_DBTables.m_con, m_ViewXml, ref m_dt, ref csError))
                {
                    dataGridView_Table.DataSource = m_dt;
                    for (int i = 0; i < dataGridView_Table.Columns.Count; i++)
                    if (dataGridView_Table.Columns[i] is DataGridViewImageColumn)
                    {
                        ((DataGridViewImageColumn)dataGridView_Table.Columns[i]).ImageLayout = DataGridViewImageCellLayout.Zoom;
                    }

                    //DoFormatting(dataGridView_Table);
                    dataGridView_Table.AllowUserToResizeColumns = true;
                    dataGridView_Table.Visible = true;
                    dataGridView_Table.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);
                    this.lbl_Rows_Count.Text = lngRPM.sRowsCount.s + m_dt.Rows.Count.ToString();
                    return true;
                }
                else
                {
                    this.lbl_Rows_Count.Text = lngRPM.sRowsCount.s + "0";
                    return false;
                }
            }
            else
            {
                this.lbl_Rows_Count.Text = lngRPM.sRowsCount.s + "0";
                return false;
            }
        }

        private void DoFormatting(DataGridView dgv)
        {

            int icol_Gender = GetColumnIndex(dgv, "Gender");
            if (icol_Gender >= 0)
            {
                dgv.Columns[icol_Gender].DefaultCellStyle.FormatProvider = new BoolFormatter();
                dgv.Columns[icol_Gender].DefaultCellStyle.Format = "Gender";
            }
        }

        private int GetColumnIndex(DataGridView dgv, string sColumnName)
        {
            int iRes = -1;
            try
            {
                int icol = dgv.Columns[sColumnName].Index;
                iRes = icol;
            }
            catch
            {
                iRes = -1;
            }
            return iRes;
        }

        private void TableView_Form_Load(object sender, EventArgs e)
        {
        }

        private void tsmi_Select_View_Click(object sender, EventArgs e)
        {
            SelectView_Form SelectView_FormDialog = new SelectView_Form(this, m_tbl, m_pTableDockingFormXml, m_ViewXml, m_DBTables.m_xml, SelectView_Form.FormMode.SELECT);
            if (SelectView_FormDialog.ShowDialog() == DialogResult.OK)
            {
                m_ViewXml = SelectView_FormDialog.m_ViewXml_Selected;
                string csError = "";
                if (SelectView_FormDialog.bDefaultView)
                {
                    m_pTableDockingFormXml.m_TableViewFormXml[m_Index].m_DefaultViewXml = SelectView_FormDialog.m_ViewXml_Selected;
                    m_pTableDockingFormXml.m_TableViewFormXml[m_Index].sDefaultView = SelectView_FormDialog.m_ViewXml_Selected.Name;
                }
                FillDataTable(ref csError);
            }
        }

        internal void EditSelectedRow()
        {
            DataGridViewSelectedCellCollection dgvCellCollection = dataGridView_Table.SelectedCells;
            if (dgvCellCollection.Count >= 1)
            {
                //lbl_test_sender_type.Text = "Count:" + dgvCellCollection.Count.ToString() + " CellType=" + dgvCellCollection[0].GetType().ToString() + " ValueType" + dgvCellCollection[0].Value.GetType().ToString() + " Value=" + dgvCellCollection[0].Value.ToString() + " Column Name = " + dgvCellCollection[0].OwningColumn.Name;
                if (dgvCellCollection[0].OwningRow.Cells["ID"].Value.GetType() == typeof(long))
                {
                    long Identity = (long)dgvCellCollection[0].OwningRow.Cells["ID"].Value;
                    if (this.m_TableDockingForm.m_EditTable_Form != null)
                    {
                        m_TableDockingForm.m_EditTable_Form.ShowTableRow(Identity);
                    }
                }
            }
            else
            {
                //lbl_test_sender_type.Text = "Num Selected cels = 0";
            }

        }
        private void dataGridView_Table_SelectionChanged(object sender, EventArgs e)
        {
            if (chkBox_BindWith_EditTable_Form.Checked)
            {
                EditSelectedRow();
            }
        }

        private void label_ViewName_Click(object sender, EventArgs e)
        {

        }

        private void label_PrimaryView_Click(object sender, EventArgs e)
        {

        }

        private void lblPrimaryView_Click(object sender, EventArgs e)
        {

        }

       


        internal void UpdateForm()
        {
            string csError = null;
            this.FillDataTable(ref csError);
        }

        private void chkBox_BindWith_EditTable_Form_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBox_BindWith_EditTable_Form.Checked)
            {
                EditSelectedRow();
            }
        }

        private void dataGridView_Table_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //DataGridView dgv = (DataGridView)sender;
            //if (dgv.Columns[e.ColumnIndex].Name.Equals("Gender"))
            //{
            //    if (e.Value is bool)
            //    {
            //        bool value = (bool)e.Value;
            //        e.Value = (value) ? "M" : "Ž";
            //        e.FormattingApplied = true;
            //    }
            //}
            DataGridViewColumn col = dataGridView_Table.Columns[e.ColumnIndex];

            try
            {
                if (col.Name == "Gender")
                {
                    bool isMale = Convert.ToBoolean(e.Value);
                    e.Value = isMale ? "M" : "Ž";
                }
            }
            catch (Exception ex)
            {
                e.Value = "?";
            }

        }

        private DataGridViewTextBoxColumn textBoxColumn = null;

        private void dataGridView_Table_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            // Avoid recursion
            if (e.Column == textBoxColumn) return;

            DataGridView gridView = sender as DataGridView;
            if (gridView == null) return;

            if (e.Column is DataGridViewCheckBoxColumn)
            {
                textBoxColumn = new DataGridViewTextBoxColumn();
                textBoxColumn.Name = e.Column.Name;
                textBoxColumn.HeaderText = e.Column.HeaderText;
                textBoxColumn.DataPropertyName = e.Column.DataPropertyName;

                gridView.Columns.Insert(e.Column.Index, textBoxColumn);
                gridView.Columns.Remove(e.Column);
            }

        }

    }
    public class BoolFormatter : ICustomFormatter, IFormatProvider
    {
        public object GetFormat(Type formatType)
        {

            if (formatType == typeof(ICustomFormatter))
            {
                return this;
            }
            return null;
        }

        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            if (arg == null)
            {
                return string.Empty;
            }

            bool value = (bool)arg;
            switch (format ?? string.Empty)
            {
                case "Gender":
                    {
                        return (value) ? "M" : "Ž";
                    }
                case "YesNo":
                    {
                        return (value) ? "Yes" : "No";
                    }
                case "OnOff":
                    {
                        return (value) ? "On" : "Off";
                    }
                default:
                    {
                        return value.ToString();//true/false
                    }
            }
        }
    }
}
