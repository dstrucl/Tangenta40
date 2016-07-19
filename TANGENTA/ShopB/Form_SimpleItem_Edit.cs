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

namespace ShopB
{
    public partial class Form_ShopB_Item_Edit : Form
    {
        public List<long> List_of_Inserted_Items_ID = null;

        DataTable dt_ShopBItem = new DataTable();
        CodeTables.DBTableControl dbTables = null;
        SQLTable tbl = null;
        bool bclose = false;

        private bool m_bChanged = false;
        public bool Changed
        {
            get { return m_bChanged; }
        }

        public Form_ShopB_Item_Edit(CodeTables.DBTableControl xdbTables, SQLTable xtbl, string ColumnToOrderBy)
        {
            InitializeComponent();
            m_bChanged = false;
            dbTables = xdbTables;
            tbl = xtbl;
            lngRPM.s_Items.Text(this, " "+lngRPM.s_Shop_B.s);
            List_of_Inserted_Items_ID = new List<long>();
            rdb_OnlyInOffer.Checked = true;
            lngRPM.s_OnlyInOffer.Text(this.rdb_OnlyInOffer);
            lngRPM.s_AllItems.Text(this.rdb_All);
            lngRPM.s_OnlyNotInOffer.Text(this.rdb_OnlyNotInOffer);
            lngRPM.s_OK.Text(btn_OK);
            lngRPM.s_Cancel.Text(btn_Cancel);
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
                List_of_Inserted_Items_ID.Add(ID);
                m_bChanged = true;
            }
        }

        private void usrc_EditTable_after_UpdateDataBase(SQLTable m_tbl, long ID, bool bRes)
        {
            m_bChanged = true;
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            if (usrc_EditTable.Changed)
            {
                if (MessageBox.Show(lngRPM.s_DataChangedSaveYourData.s, "?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    usrc_EditTable.Save();
                }
            }
            this.Close();
            DialogResult = DialogResult.Yes;

        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            if (usrc_EditTable.Changed)
            {
                if (MessageBox.Show(lngRPM.s_DataChangedDoYouWantToCloseYesNo.s, "?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    this.Close();
                    DialogResult = DialogResult.No;
                }
            }
            else
            {
                this.Close();
                DialogResult = DialogResult.No;
            }
        }
    }
}
