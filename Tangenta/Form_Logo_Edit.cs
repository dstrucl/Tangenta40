using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LanguageControl;
using SQLTableControl;

namespace Tangenta
{
    public partial class Form_Logo_Edit : Form
    {
        DataTable dt_Logo = new DataTable();
        SQLTableControl.DBTableControl dbTables = null;
        SQLTable tbl = null;
        string ColumnOrderBy = null;

        public Form_Logo_Edit(SQLTableControl.DBTableControl xdbTables, SQLTable xtbl, string xColumnOrderBy)
        {
            InitializeComponent();

            dbTables = xdbTables;
            tbl = xtbl;
            ColumnOrderBy = xColumnOrderBy;
            lngRPM.s_Logos.Text(this);
        }

        private void Form_Logo_Edit_Load(object sender, EventArgs e)
        {
            if (!usrc_EditTable.Init(dbTables, tbl,null, ColumnOrderBy,false,null,null,false))
            {
                Close();
                DialogResult = DialogResult.Abort;
            }
        }

        private bool CheckLogoData(ref string Err)
        {
            string sql_Logo = "select * from Logo";
            DataTable dt = new DataTable();
            if (dbTables.m_con.ReadDataTable(ref dt, sql_Logo, ref Err))
            {
                int Count;
                Count = dt.Rows.Count;
                if (Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                Err="ERROR:Logo_EditForm:btn_OK_Click:sql="+sql_Logo+"\r\nErr="+Err;
                return false;
            }

        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            this.Close();
            DialogResult = DialogResult.OK;
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
            DialogResult = DialogResult.Cancel;
        }

        private void Form_Logo_Edit_FormClosing(object sender, FormClosingEventArgs e)
        {
        }


        public bool Changed { get; set; }

        private bool usrc_EditTable_RowReferenceFromTable_Check_NoChangeToOther(SQLTableControl.SQLTable pSQL_Table, System.Collections.Generic.List<SQLTableControl.usrc_RowReferencedFromTable> usrc_RowReferencedFromTable_List, SQLTableControl.ID_v id_v, ref bool bCancelDialog, ref ltext Instruction)
        {
            bCancelDialog = false;

            return false;

        }

        private bool usrc_EditTable_RowReferenceFromTable_Check_NoChangeToOther(SQLTable pSQL_Table)
        {
            return default(bool);
        }
    }
}
