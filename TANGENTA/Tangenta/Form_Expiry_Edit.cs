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

namespace Tangenta
{
    public partial class Form_Expiry_Edit : Form
    {
        private DataTable dt_Expiry = new DataTable();
        private CodeTables.DBTableControl dbTables = null;
        private SQLTable tbl = null;
        private string ColumnOrderBy = null;
        private NavigationButtons.Navigation nav = null;

        public Form_Expiry_Edit(CodeTables.DBTableControl xdbTables, SQLTable xtbl, string xColumnOrderBy,NavigationButtons.Navigation xnav)
        {
            InitializeComponent();
            nav = xnav;
            dbTables = xdbTables;
            tbl = xtbl;
            ColumnOrderBy = xColumnOrderBy;
            lng.s_Expirys.Text(this);
        }

        private void Form_Expiry_Edit_Load(object sender, EventArgs e)
        {
            if (!usrc_EditTable.Init(dbTables, tbl,null, ColumnOrderBy,false,null,null,false,nav))
            {
                Close();
                DialogResult = DialogResult.Abort;
            }
        }

        private bool CheckExpiryData(ref string Err)
        {
            string sql_Expiry = "select * from Expiry";
            DataTable dt = new DataTable();
            if (dbTables.m_con.ReadDataTable(ref dt, sql_Expiry, ref Err))
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
                Err="ERROR:Expiry_EditForm:btn_OK_Click:sql="+sql_Expiry+"\r\nErr="+Err;
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

        private void Form_Expiry_Edit_FormClosing(object sender, FormClosingEventArgs e)
        {
            string Err = null;
            if (!CheckExpiryData(ref Err))
            {
                if (Err == null)
                {
                    if (MessageBox.Show(this, lng.s_ExpiryTableHasNoData_YouMustEnterData_close_anyway.s,"?",MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2)== DialogResult.No)
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

        private void Form_Expiry_Edit_KeyUp(object sender, KeyEventArgs e)
        {
            this.usrc_EditTable.KeyPressed(e.KeyCode);
        }
    }
}
