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
using TangentaTableClass;
using CodeTables.TableDocking_Form;
using TangentaDB;
using DBConnectionControl40;

namespace Tangenta
{
    public partial class Form_Customer_Org_Edit : Form
    {
        public enum eCustomer_Org_EditMode { SELECT_VALID, SELECT_UNVALID, SELECT_ALL };

        internal string Customer_Name = null;
        internal string Tax_ID = null;
        internal string Registration_ID = null;
        internal string FaxNumber = null;
        internal string PhoneNumber = null;
        internal string StreetName = null;
        internal string HouseNumber = null;
        internal string ZIP = null;
        internal string City = null;
        internal string State = null;
        internal string Country = null;
        private List<ID> List_of_Inserted_Items_ID = null;
        private DataTable dt_Item = new DataTable();
        private CodeTables.DBTableControl dbTables = null;
        private SQLTable tbl = null;
        private ID ID = null;
        private string ColumnOrderBy = "";
        private NavigationButtons.Navigation nav = null;
        public ID Customer_OrganisationData_ID = null;


        public Form_Customer_Org_Edit(CodeTables.DBTableControl xdbTables, SQLTable xtbl,string xColumnOrderBy, NavigationButtons.Navigation xnav)
        {
            InitializeComponent();
            nav = xnav;
            dbTables = xdbTables;
            tbl = xtbl;
            ColumnOrderBy = xColumnOrderBy;
            this.Text = lng.s_Customers_org.s;

        }

        public Form_Customer_Org_Edit(CodeTables.DBTableControl xdbTables, SQLTable xtbl, string xColumnOrderBy,ID xID,NavigationButtons.Navigation xnav)
        {
            InitializeComponent();
            nav = xnav;
            dbTables = xdbTables;
            tbl = xtbl;
            ColumnOrderBy = xColumnOrderBy;
            ID = xID;
            this.Text = lng.s_Customers_org.s;

        }

        private bool Init()
        {
            string selection = @" ID,
                    Customer_Org_$_orgd_$_org_$$Name,
                    Customer_Org_$_orgd_$_org_$$Tax_ID,
                    Customer_Org_$_orgd_$_org_$$Registration_ID,
                    Customer_Org_$_orgd_$_orgt_$$OrganisationTYPE,
                    Customer_Org_$_orgd_$_cadrorg_$_cstrnorg_$$StreetName,
                    Customer_Org_$_orgd_$_cadrorg_$_chounorg_$$HouseNumber,
                    Customer_Org_$_orgd_$_cadrorg_$_ccitorg_$$City,
                    Customer_Org_$_orgd_$_cadrorg_$_cziporg_$$ZIP,
                    Customer_Org_$_orgd_$_cadrorg_$_ccouorg_$$Country,
                    Customer_Org_$_orgd_$_cadrorg_$_cstorg_$$State,
                    Customer_Org_$_orgd_$_cphnnorg_$$PhoneNumber,
                    Customer_Org_$_orgd_$_cfaxnorg_$$FaxNumber,
                    Customer_Org_$_orgd_$_cemailorg_$$Email,
                    Customer_Org_$_orgd_$_chomepgorg_$$HomePage
            ";

            //Customer_Org_EditMode = eCustomer_Org_EditMode.SELECT_ALL;
            string sWhereCondition = "";
            return usrc_EditTable.Init(dbTables,
                                       DBSync.DBSync.MyTransactionLog_delegates,
                                       tbl, selection, ColumnOrderBy, false, sWhereCondition, ID, false,nav);

        }
        private void Form_Customer_Person_Edit_Load(object sender, EventArgs e)
        {
            this.btn_BankAccounts.Text = lng.s_BankAccounts.s;
            this.btn_OrganisationData.Text = lng.s_OrganisationData.s;
            if (Init())
            {
                List_of_Inserted_Items_ID = new List<ID>();
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
                if (MessageBox.Show(lng.s_DataChangedSaveYourData.s, "?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    Transaction transaction_Form_Cutsomer_Org_Edit_btn_OK_Click_usrc_EditTable_Save = new Transaction("Form_Cutsomer_Org_Edit.btn_OK_Click.usrc_EditTable.Save", DBSync.DBSync.MyTransactionLog_delegates);
                    if (usrc_EditTable.Save(transaction_Form_Cutsomer_Org_Edit_btn_OK_Click_usrc_EditTable_Save))
                    {
                        if (!transaction_Form_Cutsomer_Org_Edit_btn_OK_Click_usrc_EditTable_Save.Commit())
                        {
                            return;
                        }
                    }
                    else
                    {
                        transaction_Form_Cutsomer_Org_Edit_btn_OK_Click_usrc_EditTable_Save.Rollback();
                        return;
                    }
                }
            }

            if (ID.Validate(usrc_EditTable.Identity))
            {
                Form_Customer_Org_Assign Customer_Assign_Org_dlg = new Form_Customer_Org_Assign(usrc_EditTable.Identity);
                if (Customer_Assign_Org_dlg.ShowDialog() == DialogResult.Yes)
                {
                    this.Customer_Name = Customer_Assign_Org_dlg.Customer_Name;
                    this.Tax_ID = Customer_Assign_Org_dlg.Tax_ID;
                    this.Registration_ID = Customer_Assign_Org_dlg.Registration_ID;
                    this.FaxNumber = Customer_Assign_Org_dlg.FaxNumber;
                    this.PhoneNumber = Customer_Assign_Org_dlg.PhoneNumber;
                    this.StreetName = Customer_Assign_Org_dlg.StreetName;
                    this.HouseNumber = Customer_Assign_Org_dlg.HouseNumber;
                    this.ZIP = Customer_Assign_Org_dlg.ZIP;
                    this.City = Customer_Assign_Org_dlg.City;
                    this.State = Customer_Assign_Org_dlg.State;
                    this.State = Customer_Assign_Org_dlg.Country;
                    this.Customer_OrganisationData_ID = Customer_Assign_Org_dlg.CustomerOrganisationData_ID;
                    this.Close();
                    DialogResult = DialogResult.Yes;
                }
                else
                {
                    this.Close();
                    DialogResult = DialogResult.No;
                }
            }

            this.Close();
            DialogResult = DialogResult.Yes;
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            if (usrc_EditTable.Changed)
            {
                if (MessageBox.Show(lng.s_DataChangedSaveYourData.s, "?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    Transaction transaction_Form_Customer_Org_Edit_btn_Cancel_Click_usrc_EditTable_Save = new Transaction("Form_Customer_Org_Edit.btn_Cancel_Click.usrc_EditTable.Save", DBSync.DBSync.MyTransactionLog_delegates);
                    if (usrc_EditTable.Save(transaction_Form_Customer_Org_Edit_btn_Cancel_Click_usrc_EditTable_Save))
                    {
                        if (!transaction_Form_Customer_Org_Edit_btn_Cancel_Click_usrc_EditTable_Save.Commit())
                        {
                            return;
                        }
                    }
                    else
                    {
                        transaction_Form_Customer_Org_Edit_btn_Cancel_Click_usrc_EditTable_Save.Rollback();
                        return;
                    }
                }
            }
            this.Close();
            DialogResult = DialogResult.No;
        }

        private void usrc_EditTable_after_InsertInDataBase(SQLTable m_tbl, ID xID, bool bRes)
        {
            List_of_Inserted_Items_ID.Add(xID);
        }

        private void Item_EditForm_FormClosing(object sender, FormClosingEventArgs e)
        {
           
        }

        internal bool Edit_OrganisationData()
        {
            SQLTable tbl_OrganisationData = new SQLTable(DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(OrganisationData)));
            OrganisationData_EditForm edt_Item_dlg = new OrganisationData_EditForm(DBSync.DBSync.DB_for_Tangenta.m_DBTables,
                                                                        tbl_OrganisationData,
                                                            " OrganisationData_$_org_$$Name desc",nav);
            edt_Item_dlg.ShowDialog();
            Init();
            return true;
        }

        internal bool Edit_OrganisationAccount()
        {
            SQLTable tbl_OrganisationAccount = new SQLTable(DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(OrganisationAccount)));
            Form_OrganisationAccount_Edit edt_Item_dlg = new Form_OrganisationAccount_Edit(DBSync.DBSync.DB_for_Tangenta.m_DBTables,
                                                                        tbl_OrganisationAccount,
                                                            " OrganisationAccount_$_org_$$Name desc",nav);
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

        private void Form_Customer_Org_Edit_KeyUp(object sender, KeyEventArgs e)
        {
            this.usrc_EditTable.KeyPressed(e.KeyCode);
        }
    }
}
