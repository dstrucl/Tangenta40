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
using CodeTables;

namespace ShopA
{
    public partial class Form_ShopAItem_Edit : Form
    {
        DataTable dt_ShopBItem = new DataTable();
        CodeTables.DBTableControl dbTables = null;
        SQLTable tbl = null;
        bool bclose = false;

        public Form_ShopAItem_Edit(CodeTables.DBTableControl xdbTables, SQLTable xtbl, string ColumnToOrderBy)
        {
            InitializeComponent();
            dbTables = xdbTables;
            tbl = xtbl;
            this.Text = lngRPM.s_ShopB_Items.s;
            if (!usrc_EditTable.Init(dbTables, tbl,null,ColumnToOrderBy,false,null,null,false))
            {
                bclose = true;
            }
        }

        private void MyOrganisationData_EditForm_Load(object sender, EventArgs e)
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
