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

namespace Tangenta
{
    public partial class Form_Currency_Edit : Form
    {
        DataTable dt_Taxation = new DataTable();
        CodeTables.DBTableControl dbTables = null;
        SQLTable tbl = null;
        string ColumnOrderBy = null;

        public Form_Currency_Edit(CodeTables.DBTableControl xdbTables, SQLTable xtbl, string xColumnOrderBy)
        {
            InitializeComponent();

            dbTables = xdbTables;
            tbl = xtbl;
            ColumnOrderBy = xColumnOrderBy;
            lngRPM.s_Currency.Text(this);
        }

        private void Form_Currency_Edit_Load(object sender, EventArgs e)
        {
            if (!usrc_EditTable.Init(dbTables, tbl,null, ColumnOrderBy,false,null,null,false))
            {
                Close();
                DialogResult = DialogResult.Abort;
            }
        }

        private bool CheckTaxationData(ref string Err)
        {
            string sql_Taxation = "select * from Taxation";
            DataTable dt = new DataTable();
            if (dbTables.m_con.ReadDataTable(ref dt, sql_Taxation, ref Err))
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
                Err="ERROR:Taxation_EditForm:btn_OK_Click:sql="+sql_Taxation+"\r\nErr="+Err;
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

        private void Form_Currency_Edit_FormClosing(object sender, FormClosingEventArgs e)
        {
            string Err = null;
            if (!CheckTaxationData(ref Err))
            {
                if (Err == null)
                {
                    if (MessageBox.Show(this, lngRPM.s_TaxationTableHasNoData_YouMustEnterData_close_anyway.s,"?",MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2)== DialogResult.No)
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

        private bool usrc_EditTable_RowReferenceFromTable_Check_NoChangeToOther(CodeTables.SQLTable pSQL_Table, System.Collections.Generic.List<CodeTables.usrc_RowReferencedFromTable> usrc_RowReferencedFromTable_List, CodeTables.ID_v id_v, ref bool bCancelDialog, ref ltext Instruction)
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
