#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion
//Form_myOrg_Edit.Designer.cs:line 145
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
using TangentaTableClass;
using TangentaDB;

namespace Tangenta
{
    public partial class Form_myOrg_Edit : Form
    {
        DataTable dt_my_company = new DataTable();
        CodeTables.DBTableControl dbTables = null;
        SQLTable tbl = null;
        //bool bclose = false;

        public Form_myOrg_Edit(CodeTables.DBTableControl xdbTables,SQLTable xtbl,bool bAllowNew)
        {
            InitializeComponent();
            dbTables = xdbTables;
            tbl = xtbl;
            usrc_EditRow.AllowUserToAddNew = bAllowNew;
            lngRPM.s_Edit_Offices.Text(btn_Office);
        }

        private bool InitDataTable(long ID)
        {
            dt_my_company.Clear();
            string sql = null;
             sql = @"select * from myOrganisation_VIEW";

            string Err = null;
            if (DBSync.DBSync.ReadDataTable(ref dt_my_company,sql,ref Err))
            {
                dgvx_MyOrganisation.DataSource = dt_my_company;
                tbl.SetVIEW_DataGridViewImageColumns_Headers((DataGridView)dgvx_MyOrganisation, dbTables);
                foreach (DataGridViewColumn dgvc in dgvx_MyOrganisation.Columns)
                {
                    if (dgvc.HeaderText.Equals("ID"))
                    {
                        dgvc.Visible = false;
                    }
                }
                return true;
            }
            else
            {
                LogFile.Error.Show(Err);
                return false;
            }
        }

        private bool Init()
        {
            Cursor = Cursors.WaitCursor;
            if (InitDataTable(-1))
            {
                usrc_EditRow.Init(dbTables, tbl, null,false);
                if (dt_my_company.Rows.Count > 0)
                {
                    long Identity = (long)dt_my_company.Rows[0]["ID"];
                    usrc_EditRow.ShowTableRow(Identity);
                    usrc_EditRow.AllowUserToAddNew = false;
                }
                else
                {
                    usrc_EditRow.AllowUserToAddNew = true;
                }
                Cursor = Cursors.Arrow;
                return true;
            }
            else
            {
                Cursor = Cursors.Arrow;
                return false;
            }

        }

        private void MyOrganisationData_EditForm_Load(object sender, EventArgs e)
        {
            this.btn_BankAccounts.Text = lngRPM.s_BankAccounts.s;
            this.Text = lngRPM.s_MyOrganisation.s;
            if (!Init())
            {
                Close();
                DialogResult = DialogResult.Abort;
            }
        }

        private void usrc_EditTable_Update(bool res,long ID, string Err)
        {
            if (res)
            {
                InitDataTable(ID);
                usrc_EditRow.ShowTableRow(ID);
            }
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            if (usrc_EditRow.Changed)
            {
                if (XMessage.Box.Show(this, lngRPM.s_YouDidNotWriteDataToDB_SaveData_YesOrNo, lngRPM.s_Warning.s, MessageBoxButtons.YesNo, Properties.Resources.Tangenta_Question, MessageBoxDefaultButton.Button1)== DialogResult.Yes)
                {
                    Close();
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    Close();
                    DialogResult = DialogResult.OK;
                }
            }
            else
            {
                if (dt_my_company.Rows.Count > 0)
                {
                    Close();
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    XMessage.Box.Show(this, lngRPM.s_YouMustEnterYourOrganisationData, "", MessageBoxButtons.OK, Properties.Resources.Tangenta_Question, MessageBoxDefaultButton.Button1);
                }
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {

            if (dt_my_company.Rows.Count > 0)
            {
                Close();
                DialogResult = DialogResult.OK;
            }
            else
            {
                if (XMessage.Box.Show(this, lngRPM.s_YouDidNotEnterYourOrganisationData, "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    Close();
                    DialogResult = DialogResult.Cancel;
                }
            }
            
        }

        internal bool Edit_OrganisationData()
        {
            SQLTable tbl_OrganisationData = new SQLTable(DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(OrganisationData)));
            OrganisationData_EditForm edt_Item_dlg = new OrganisationData_EditForm(DBSync.DBSync.DB_for_Tangenta.m_DBTables,
                                                                        tbl_OrganisationData,
                                                            " OrganisationData_$_org_$$Name desc");
            edt_Item_dlg.ShowDialog();
            Init();
            return true;
        }

        internal bool Edit_OrganisationAccount()
        {
            SQLTable tbl_OrganisationAccount = new SQLTable(DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(OrganisationAccount)));
            Form_OrganisationAccount_Edit edt_Item_dlg = new Form_OrganisationAccount_Edit(DBSync.DBSync.DB_for_Tangenta.m_DBTables,
                                                                        tbl_OrganisationAccount,
                                                            " OrganisationAccount_$_org_$$Name desc");
            edt_Item_dlg.ShowDialog();
            Init();
            return true;
        }
        private void btn_OrganisationData_Click(object sender, EventArgs e)
        {
            Edit_OrganisationData();
        }

        private void btn_BankAccounts_Click(object sender, EventArgs e)
        {
            Edit_OrganisationAccount();
        }

        private void usrc_EditRow_after_InsertInDataBase(SQLTable m_tbl, long id, bool bRes)
        {
            if (bRes)
            {
                usrc_EditRow.AllowUserToAddNew = false;
                myOrg.Get(1);
            }
        }

        private void btn_Office_Edit(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            Form_myOrg_Office frm_office = new Form_myOrg_Office();
            frm_office.ShowDialog();
            this.Cursor = Cursors.Arrow;
        }
    }
}
