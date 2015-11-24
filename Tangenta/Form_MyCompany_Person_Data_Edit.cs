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
using BlagajnaTableClass;
namespace Tangenta
{
    public partial class Form_MyCompany_Person_Data_Edit : Form
    {
        DataTable dt_my_company = new DataTable();
        SQLTableControl.DBTableControl dbTables = null;
        SQLTable tbl = null;
        //bool bclose = false;

        public Form_MyCompany_Person_Data_Edit(SQLTableControl.DBTableControl xdbTables,SQLTable xtbl)
        {
            InitializeComponent();
            dbTables = xdbTables;
            tbl = xtbl;
        }

        private bool InitDataTable(long ID)
        {
            dt_my_company.Clear();
            string sql = @"select * from myCompany_Person_VIEW";
            string Err = null;
            if (DBSync.DBSync.ReadDataTable(ref dt_my_company,sql,ref Err))
            {
                dgvx_MyCompany.DataSource = dt_my_company;
                tbl.SetVIEW_DataGridViewImageColumns_Headers((DataGridView)dgvx_MyCompany, dbTables);
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
            if (InitDataTable(-1))
            {
                usrc_EditRow.Init(dbTables, tbl, null,false);
                if (dt_my_company.Rows.Count > 0)
                {
                    long Identity = (long)dt_my_company.Rows[0]["ID"];
                    usrc_EditRow.ShowTableRow(Identity);
                }
                return true;
            }
            else
            {
                return false;
            }

        }

        private void MyCompanyData_EditForm_Load(object sender, EventArgs e)
        {
            this.btn_BankAccounts.Text = lngRPM.s_BankAccounts.s;
            this.Text = lngRPM.s_MyCompany.s;
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
            Close();
            DialogResult = DialogResult.OK;
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Close();
            DialogResult = DialogResult.Cancel;
        }

        internal bool Edit_OrganisationData()
        {
            SQLTable tbl_OrganisationData = new SQLTable(DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(OrganisationData)));
            OrganisationData_EditForm edt_Item_dlg = new OrganisationData_EditForm(DBSync.DBSync.DB_for_Blagajna.m_DBTables,
                                                                        tbl_OrganisationData,
                                                            " OrganisationData_$_org_$$Name desc");
            edt_Item_dlg.ShowDialog();
            Init();
            return true;
        }

        internal bool Edit_OrganisationAccount()
        {
            SQLTable tbl_OrganisationAccount = new SQLTable(DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(OrganisationAccount)));
            Form_OrganisationAccount_Edit edt_Item_dlg = new Form_OrganisationAccount_Edit(DBSync.DBSync.DB_for_Blagajna.m_DBTables,
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
    }
}
