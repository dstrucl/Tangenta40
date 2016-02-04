using BlagajnaTableClass;
using DBTypes;
using LanguageControl;
using SQLTableControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tangenta
{
    public partial class Form_myOrg_Person_Edit : Form
    {
        DataTable dt_my_company = new DataTable();
        SQLTableControl.DBTableControl dbTables = null;
        SQLTable tbl = null;
        long_v ID_v = null;
        //bool bclose = false;

        public Form_myOrg_Person_Edit(SQLTableControl.DBTableControl xdbTables, long_v xID_v, SQLTable xtbl)
        {
            InitializeComponent();
            dbTables = xdbTables;
            tbl = xtbl;
            ID_v = xID_v;
        }

        private void Form_myOrg_Person_Edit_Load(object sender, EventArgs e)
        {
            this.usrc_EditTable1.Init(dbTables, tbl, null, null, true, null, ID_v, false);
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
    }
}
