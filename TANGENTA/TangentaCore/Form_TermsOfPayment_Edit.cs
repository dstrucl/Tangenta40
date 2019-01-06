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
using DBConnectionControl40;

namespace TangentaCore
{
    public partial class Form_TermsOfPayment_Edit : Form
    {
        private DataTable dt_TermsOfPayment = new DataTable();
        private CodeTables.DBTableControl dbTables = null;
        private SQLTable tbl = null;
        private string ColumnOrderBy = null;
        private NavigationButtons.Navigation nav = null;

        private ID m_TermsOfPayment_ID = null;
        public ID TermsOfPayment_ID
        {
            get { return m_TermsOfPayment_ID; }
        }

        private string m_Description = null;
        public string Description
        {
            get { return m_Description; }
        }

        public Form_TermsOfPayment_Edit(CodeTables.DBTableControl xdbTables, SQLTable xtbl, string xColumnOrderBy,NavigationButtons.Navigation xnav)
        {
            InitializeComponent();
            nav = xnav;
            dbTables = xdbTables;
            tbl = xtbl;
            ColumnOrderBy = xColumnOrderBy;
            lng.s_TermsOfPayments.Text(this);
        }

        private void Form_TermsOfPayment_Edit_Load(object sender, EventArgs e)
        {
            if (!usrc_EditTable.Init(dbTables, DBSync.DBSync.MyTransactionLog_delegates, tbl,null, ColumnOrderBy,false,null,null,false,nav))
            {
                Close();
                DialogResult = DialogResult.Abort;
            }
        }

        private bool CheckTermsOfPaymentData(ref string Err)
        {
            string sql_TermsOfPayment = "select Description,ID from TermsOfPayment";
            DataTable dt = new DataTable();
            if (dbTables.Con.ReadDataTable(ref dt, sql_TermsOfPayment, ref Err))
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
                Err="ERROR:TermsOfPayment_EditForm:btn_OK_Click:sql="+sql_TermsOfPayment+"\r\nErr="+Err;
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

        private void Form_TermsOfPayment_Edit_FormClosing(object sender, FormClosingEventArgs e)
        {
            string Err = null;
            if (!CheckTermsOfPaymentData(ref Err))
            {
                if (Err == null)
                {
                    if (MessageBox.Show(this, lng.s_TermsOfPaymentTableHasNoData_YouMustEnterData_close_anyway.s,"?",MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2)== DialogResult.No)
                    {
                        e.Cancel = true;
                    }
                }
                else
                {
                    LogFile.Error.Show(Err);
                }
            }
        }


        public bool Changed { get; set; }

        private bool usrc_EditTable_RowReferenceFromTable_Check_NoChangeToOther(CodeTables.SQLTable pSQL_Table, System.Collections.Generic.List<CodeTables.usrc_RowReferencedFromTable> usrc_RowReferencedFromTable_List, ID id, ref bool bCancelDialog, ref ltext Instruction)
        {
            bCancelDialog = false;

            return false;

        }

        private bool usrc_EditTable_RowReferenceFromTable_Check_NoChangeToOther(SQLTable pSQL_Table)
        {
            return default(bool);
        }

        private void usrc_EditTable_after_InsertInDataBase(SQLTable m_tbl, ID xID, bool bRes)
        {
            if (bRes)
            {
                FillProperties(m_tbl, xID);
            }
        }
        private void FillProperties(SQLTable m_tbl, ID ID)
        {
            this.m_TermsOfPayment_ID = ID;
            this.m_Description = null;
            object oDescription = m_tbl.Value("Description");
            if (oDescription is TangentaTableClass.Description)
            {
                if (((TangentaTableClass.Description)oDescription).defined)
                {
                    this.m_Description = ((TangentaTableClass.Description)oDescription).val;
                }
            }
        }

        private void usrc_EditTable_SelectedIndexChanged(SQLTable m_tbl, ID xID, int index)
        {
            FillProperties(m_tbl, xID);
        }
    }
}
