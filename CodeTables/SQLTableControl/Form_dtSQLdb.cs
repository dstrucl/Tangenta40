using DBConnectionControl40;
using DBTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeTables
{
    public partial class Form_dtSQLdb : Form
    {
        private DBConnection m_con = null;

        public Form_dtSQLdb(DBConnection xcon, string sdbversion)
        {
            InitializeComponent();
            dgvx_dtSQLdb.DataSource = DBTableControl.dtSQLdb;
            this.lbl_Info.Text = "SQL data base file:\""+DBTableControl.SQLdbFile+"\"";
            splitContainer1.Panel2Collapsed = true;
            dgvx_dtSQLdb.SelectionChanged += Dgvx_dtSQLdb_SelectionChanged;
            m_con = xcon;
            this.Text = "DataBase Type:" + m_con.ServerType + " DataBase Name:\"" + m_con.DataSource + "\" DataBase Version:" + sdbversion;
        }

        private void Dgvx_dtSQLdb_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewSelectedCellCollection dgvCellCollection = this.dgvx_dtSQLdb.SelectedCells;
            if (dgvCellCollection.Count >= 1)
            {
                //lbl_test_sender_type.Text = "Count:" + dgvCellCollection.Count.ToString() + " CellType=" + dgvCellCollection[0].GetType().ToString() + " ValueType" + dgvCellCollection[0].Value.GetType().ToString() + " Value=" + dgvCellCollection[0].Value.ToString() + " Column Name = " + dgvCellCollection[0].OwningColumn.Name;
                if (dgvCellCollection[0].OwningRow.Cells[DBTableControl.col_TABLE_NAME].Value is string)
                {
                    string_v stable_name_v = tf.set_string(dgvCellCollection[0].OwningRow.Cells[DBTableControl.col_TABLE_NAME].Value);
                    if (stable_name_v!=null)
                    {
                        splitContainer1.Panel2Collapsed = false;
                        lbl_SQL_CrateTable.Text = "Table:" + stable_name_v.v;
                    }
                    string_v stable_sql_createtable_v = tf.set_string(dgvCellCollection[0].OwningRow.Cells[DBTableControl.col_SQL_CreateTABLE].Value);
                    if (stable_sql_createtable_v!=null)
                    {
                        this.fctxt_SQL_CreateTable.Text = stable_sql_createtable_v.v;
                    }
                    string_v stable_sql_viewname_v = tf.set_string(dgvCellCollection[0].OwningRow.Cells[DBTableControl.col_VIEW_NAME].Value);
                    string_v stable_sql_createview_v = tf.set_string(dgvCellCollection[0].OwningRow.Cells[DBTableControl.col_SQL_CreateVIEW].Value);

                    if (stable_sql_viewname_v!=null)
                    {
                        lbl_SQL_CreateVIEW.Text = "Name of VIEW:" + stable_sql_viewname_v.v;
                        splitContainer2.Panel2Collapsed = false;
                        if (stable_sql_createview_v != null)
                        {
                            this.fctb_SQL_CreateVIEW.Text = stable_sql_createview_v.v;
                        }
                    }
                    else
                    {
                        splitContainer2.Panel2Collapsed = true;
                    }
                    return;
                }
            }
        }

        private void btn_CopySQLCreateTable_ToClipboard_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Clipboard.SetText(fctxt_SQL_CreateTable.Text);
        }

        private void btn_CopySQLCreateVIew_ToClipboard_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Clipboard.SetText(fctb_SQL_CreateVIEW.Text);
        }
    }
}
