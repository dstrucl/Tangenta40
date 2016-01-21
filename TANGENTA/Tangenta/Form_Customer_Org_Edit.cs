﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LanguageControl;
using SQLTableControl;
using DBTypes;
using BlagajnaTableClass;
using SQLTableControl.TableDocking_Form;
using InvoiceDB;

namespace Tangenta
{
    public partial class Form_Customer_Org_Edit : Form
    {
        public enum eCustomer_Org_EditMode { SELECT_VALID, SELECT_UNVALID, SELECT_ALL };
        private eCustomer_Org_EditMode Customer_Person_EditMode = eCustomer_Org_EditMode.SELECT_VALID;

        List<long> List_of_Inserted_Items_ID = null; 
        DataTable dt_Item = new DataTable();
        SQLTableControl.DBTableControl dbTables = null;
        SQLTable tbl = null;
        long_v ID_v = null;
        string ColumnOrderBy = "";

        public Form_Customer_Org_Edit(SQLTableControl.DBTableControl xdbTables, SQLTable xtbl,string xColumnOrderBy)
        {
            InitializeComponent();
            dbTables = xdbTables;
            tbl = xtbl;
            ColumnOrderBy = xColumnOrderBy;
            this.Text = lngRPM.s_Customers_org.s;

        }

        public Form_Customer_Org_Edit(SQLTableControl.DBTableControl xdbTables, SQLTable xtbl, string xColumnOrderBy,long ID)
        {
            InitializeComponent();
            dbTables = xdbTables;
            tbl = xtbl;
            ColumnOrderBy = xColumnOrderBy;
            ID_v = new long_v();
            ID_v.v = ID;
            this.Text = lngRPM.s_Customers_org.s;

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
                    Customer_Org_$_orgd_$_cadrorg_$_cstorg_$$State,
                    Customer_Org_$_orgd_$_cadrorg_$_ccouorg_$$Country,
                    Customer_Org_$_orgd_$_cphnnorg_$$PhoneNumber,
                    Customer_Org_$_orgd_$_cfaxnorg_$$FaxNumber,
                    Customer_Org_$_orgd_$_cemailorg_$$Email,
                    Customer_Org_$_orgd_$_chomepgorg_$$HomePage
            ";

            Customer_Person_EditMode = eCustomer_Org_EditMode.SELECT_ALL;
            string sWhereCondition = "";
            return usrc_EditTable.Init(dbTables, tbl, selection, ColumnOrderBy, false, sWhereCondition, ID_v, false);

        }
        private void Form_Customer_Person_Edit_Load(object sender, EventArgs e)
        {
            this.btn_BankAccounts.Text = lngRPM.s_BankAccounts.s;
            this.btn_OrganisationData.Text = lngRPM.s_OrganisationData.s;
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

        private void Update_PriceList()
        {
            if (List_of_Inserted_Items_ID.Count > 0)
            {
                f_PriceList.Update(this);
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
        }

        private void Item_EditForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (f_PriceList.Check((Form)this.Parent))
            {
               
            }
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
