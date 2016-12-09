﻿#region LICENSE 
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
using CodeTables.TableDocking_Form;
using TangentaDB;

namespace Tangenta
{
    public partial class Form_OrganisationAccount_Edit : Form
    {
        private List<long> List_of_Inserted_Items_ID = null;
        private DataTable dt_Item = new DataTable();
        private CodeTables.DBTableControl dbTables = null;
        private SQLTable tbl = null;
        private long_v ID_v = null;
        private string ColumnOrderBy = "";
        private NavigationButtons.Navigation nav = null;

        private long m_OgranisationAccount_ID = -1;
        public long OgranisationAccount_ID
        {
            get { return m_OgranisationAccount_ID; }
        }

        private string m_BankName = null;
        public string BankName
        {
            get { return m_BankName; }
        }

        private string m_TRR = null;
        public string TRR
        {
            get { return m_TRR; }
        }

        public Form_OrganisationAccount_Edit(CodeTables.DBTableControl xdbTables, SQLTable xtbl,string xColumnOrderBy, NavigationButtons.Navigation xnav)
        {
            InitializeComponent();
            nav = xnav;
            dbTables = xdbTables;
            tbl = xtbl;
            ColumnOrderBy = xColumnOrderBy;
            this.Text = lngRPM.s_OrganisationAccount.s;

        }

        public Form_OrganisationAccount_Edit(CodeTables.DBTableControl xdbTables, SQLTable xtbl, string xColumnOrderBy, long ID, NavigationButtons.Navigation xnav)
        {
            InitializeComponent();
            nav = xnav;
            dbTables = xdbTables;
            tbl = xtbl;
            ColumnOrderBy = xColumnOrderBy;
            ID_v = new long_v();
            ID_v.v = ID;
            this.Text = lngRPM.s_Items.s;

        }

        private bool Init()
        {
            string selection = @"
                    OrganisationAccount_$_bankacc_$$TRR,
                    OrganisationAccount_$_bankacc_$_bank_$_org_$$Name,
                    OrganisationAccount_$_bankacc_$_bank_$_org_$$Tax_ID,
                    OrganisationAccount_$_bankacc_$$Active,
                    OrganisationAccount_$_bankacc_$$Description,
                    OrganisationAccount_$$Description,
                    ID
            ";

            string sWhereCondition = "";
            return usrc_EditTable.Init(dbTables, tbl, selection, ColumnOrderBy, false, sWhereCondition, ID_v,false,nav);

        }
        private void Customer_Person_EditForm_Load(object sender, EventArgs e)
        {
            if (Init())
            {
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
            this.Close();
            DialogResult = DialogResult.Yes;
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
            if (bRes)
            {
                FillProperties(m_tbl, ID);
            }
        }

        private void usrc_EditTable_SelectedIndexChanged(SQLTable m_tbl, long ID, int index)
        {
            FillProperties(m_tbl, ID);
        }

        private void OrganisationAccount_EditForm_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void FillProperties(SQLTable m_tbl,long ID)
        {
            this.m_OgranisationAccount_ID = ID;
            this.m_BankName = null;
            object oBankName = m_tbl.Value("OrganisationAccount_$_bankacc_$_bank_$_org_$$Name");
            if (oBankName is TangentaTableClass.Name)
            {
                if (((TangentaTableClass.Name)oBankName).defined)
                {
                    this.m_BankName = ((TangentaTableClass.Name)oBankName).val;
                }
            }
            object oTRR = m_tbl.Value("OrganisationAccount_$_bankacc_$$TRR");
            this.m_TRR = null;
            if (oTRR is TangentaTableClass.TRR)
            {
                if (((TangentaTableClass.TRR)oTRR).defined)
                {
                    this.m_TRR = ((TangentaTableClass.TRR)oTRR).val;
                }
            }
        }
    }
}
