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

namespace ShopB
{
    public partial class Form_SimpleItem_Edit : Form
    {
        DataTable dt_SimpleItem = new DataTable();
        SQLTableControl.DBTableControl dbTables = null;
        SQLTable tbl = null;
        bool bclose = false;

        public Form_SimpleItem_Edit(SQLTableControl.DBTableControl xdbTables, SQLTable xtbl, string ColumnToOrderBy)
        {
            InitializeComponent();
            dbTables = xdbTables;
            tbl = xtbl;
            this.Text = lngRPM.s_SimpleItems.s;
            if (!usrc_EditTable.Init(dbTables, tbl,null,ColumnToOrderBy,false,null,null,false))
            {
                bclose = true;
            }
        }

        private void MyCompanyData_EditForm_Load(object sender, EventArgs e)
        {
            if (bclose)
            {
                Close();
                DialogResult = DialogResult.Abort;
            }
        }

        private void usrc_EditTable_after_InsertInDataBase(SQLTable m_tbl, long ID, bool bRes)
        {
            if (bRes)
            {

            }
        }
    }
}
