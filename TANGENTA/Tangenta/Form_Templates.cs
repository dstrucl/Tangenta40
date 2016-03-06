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
using DBTypes;
using InvoiceDB;

namespace Tangenta
{
    public partial class Form_Templates : Form
    {
        public enum eTemplates { SELECT_VALID, SELECT_UNVALID, SELECT_ALL };
        private eTemplates eTemplatesSelectionMode = eTemplates.SELECT_VALID;

        List<long> List_of_Inserted_Items_ID = null;

        DataTable dt_Item = new DataTable();
        CodeTables.DBTableControl dbTables = null;
        SQLTable tbl = null;
        public long_v ID_v = null;
        string ColumnOrderBy = "";
        private bool m_bChanged = false;

        public bool bPriceListChanged = false;

        public Form_Templates(CodeTables.DBTableControl xdbTables, SQLTable xtbl,string xColumnOrderBy)
        {
            InitializeComponent();
            dbTables = xdbTables;
            tbl = xtbl;
            ColumnOrderBy = xColumnOrderBy;
            this.Text = lngRPM.s_Items.s;
            rdb_OnlyInOffer.Checked = true;
            this.rdb_OnlyInOffer.Text = lngRPM.s_OnlyInOffer.s;
            this.rdb_All.Text = lngRPM.s_AllItems.s;
            this.rdb_OnlyNotInOffer.Text = lngRPM.s_OnlyNotInOffer.s;

        }

        public Form_Templates(CodeTables.DBTableControl xdbTables, SQLTable xtbl, string xColumnOrderBy, long ID)
        {
            InitializeComponent();
            dbTables = xdbTables;
            tbl = xtbl;
            ColumnOrderBy = xColumnOrderBy;
            ID_v = new long_v();
            ID_v.v = ID;
            this.Text = lngRPM.s_Items.s;
            rdb_OnlyInOffer.Checked = true;
            this.rdb_OnlyInOffer.Text = lngRPM.s_OnlyInOffer.s;
            this.rdb_All.Text = lngRPM.s_AllItems.s;
            this.rdb_OnlyNotInOffer.Text = lngRPM.s_OnlyNotInOffer.s;

        }

        private bool Init()
        {
            string selection = @"ID,
                                doc_$$Name,
                                doc_$$Description,
                                doc_$$xDocument,
                                doc_$$Active,
                                doc_$_doctype_$$ID,
                                doc_$_doctype_$$Name,
                                doc_$_doctype_$$Description
            ";
            string sWhereCondition = "";
            switch (eTemplatesSelectionMode)
            {
                case eTemplates.SELECT_VALID:
                    sWhereCondition = " where  doc_$$Active = 1 ";
                    break;
                case eTemplates.SELECT_UNVALID:
                    sWhereCondition = " where  doc_$$Active = 0 ";
                    break;
            }
            return usrc_EditTable.Init(dbTables, tbl, selection, ColumnOrderBy, false, sWhereCondition, ID_v, false);

        }
        private void MyCompanyData_EditForm_Load(object sender, EventArgs e)
        {
            eTemplatesSelectionMode = eTemplates.SELECT_VALID;
            rdb_OnlyInOffer.Checked = true;
            if (Init())
            {
                rdb_All.CheckedChanged +=rdb_All_CheckedChanged;
                rdb_OnlyNotInOffer.CheckedChanged +=rdb_OnlyNotInOffer_CheckedChanged;
                rdb_OnlyInOffer.CheckedChanged +=rdb_OnlyInOffer_CheckedChanged;
                List_of_Inserted_Items_ID = new List<long>();
            }
            else
            {
                Close();
                DialogResult = DialogResult.Abort;
            }
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

            long id = usrc_EditTable.Identity;

            if (ID_v == null)
            {
                ID_v = new long_v();
            }

            ID_v.v = id;

            this.Close();
            DialogResult = DialogResult.OK;

        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            if (usrc_EditTable.Changed)
            {
                if (MessageBox.Show(lngRPM.s_DataChangedSaveYourData.s, "?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    usrc_EditTable.Save();
                }
            }
            this.Close();
            DialogResult = DialogResult.No;
        }

        private void usrc_EditTable_after_InsertInDataBase(SQLTable m_tbl, long ID, bool bRes)
        {
            List_of_Inserted_Items_ID.Add(ID);
            m_bChanged = true;
        }

        private void Item_EditForm_FormClosing(object sender, FormClosingEventArgs e)
        {
        }


        private void rdb_OnlyInOffer_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_OnlyInOffer.Checked)
            {
                eTemplatesSelectionMode = eTemplates.SELECT_VALID;
                Init();
            }
        }

        private void rdb_OnlyNotInOffer_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_OnlyNotInOffer.Checked)
            {
                eTemplatesSelectionMode = eTemplates.SELECT_UNVALID;
                Init();
            }
        }

        private void rdb_All_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_All.Checked)
            {
                eTemplatesSelectionMode = eTemplates.SELECT_ALL;
                Init();
            }
        }

        public bool Changed 
        {
            get {return m_bChanged;}
        }

        private void usrc_EditTable_after_UpdateDataBase(SQLTable m_tbl, long ID, bool bRes)
        {
            m_bChanged = true;
        }

        private bool usrc_EditTable_RowReferenceFromTable_Check_NoChangeToOther(CodeTables.SQLTable pSQL_Table, System.Collections.Generic.List<CodeTables.usrc_RowReferencedFromTable> usrc_RowReferencedFromTable_List, CodeTables.ID_v id_v, ref bool bCancelDialog, ref ltext Instruction)
        {
            bCancelDialog = true;
            if (pSQL_Table.TableName.Equals("Item"))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void usrc_EditTable_dgvx_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }
    }
}
