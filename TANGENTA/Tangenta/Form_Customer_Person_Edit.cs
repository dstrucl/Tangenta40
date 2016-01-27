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
using DBTypes;
using BlagajnaTableClass;
using SQLTableControl.TableDocking_Form;
using InvoiceDB;

namespace Tangenta
{
    public partial class Form_Customer_Person_Edit : Form
    {
        public enum eCustomer_Person_EditMode { SELECT_VALID, SELECT_UNVALID, SELECT_ALL };
        private eCustomer_Person_EditMode Customer_Person_EditMode = eCustomer_Person_EditMode.SELECT_VALID;

        internal string FirstName = null;
        internal string LastName = null;
        internal string GsmNumber = null;
        internal string PhoneNumber = null;
        internal string StreetName = null;
        internal string HouseNumber = null;
        internal string ZIP = null;
        internal string City = null;
        internal string Country = null;
        internal string State = null;
        internal DateTime DateOfBirth = DateTime.MinValue;
        public long Person_ID = -1;
        public long CustomerPerson_ID = -1;

        List<long> List_of_Inserted_Items_ID = null; 
        DataTable dt_Item = new DataTable();
        SQLTableControl.DBTableControl dbTables = null;
        SQLTable tbl = null;
        long_v ID_v = null;
        string ColumnOrderBy = "";

        public Form_Customer_Person_Edit(SQLTableControl.DBTableControl xdbTables, SQLTable xtbl,string xColumnOrderBy)
        {
            InitializeComponent();
            dbTables = xdbTables;
            tbl = xtbl;
            ColumnOrderBy = xColumnOrderBy;
            this.Text = lngRPM.s_Customers_Person.s;
            this.usrc_EditTable.Title = xtbl.lngTableName.s;

        }

        public Form_Customer_Person_Edit(SQLTableControl.DBTableControl xdbTables, SQLTable xtbl, string xColumnOrderBy, long ID)
        {
            InitializeComponent();
            dbTables = xdbTables;
            tbl = xtbl;
            ColumnOrderBy = xColumnOrderBy;
            ID_v = new long_v();
            ID_v.v = ID;
            this.Text = lngRPM.s_Items.s;
            this.usrc_EditTable.Title = xtbl.lngTableName.s;
        }

        private bool Init()
        {
            string selection = @" ID,
                                  PersonData_$_per_$$Gender,
                                  PersonData_$_per_$_cfn_$$FirstName,
                                  PersonData_$_per_$_cln_$$LastName,
                                  PersonData_$_per_$$DateOfBirth,
                                  PersonData_$_per_$$Tax_ID,
                                  PersonData_$_per_$$Registration_ID,
                                  PersonData_$_cgsmnper_$$GsmNumber,
                                  PersonData_$_cphnnper_$$PhoneNumber,
                                  PersonData_$_cemailper_$$Email,
                                  PersonData_$_cadrper_$_cstrnper_$$StreetName,
                                  PersonData_$_cadrper_$_chounper_$$HouseNumber,
                                  PersonData_$_cadrper_$_zipper_$$ZIP,
                                  PersonData_$_cadrper_$_ccitper_$$City,
                                  PersonData_$_cadrper_$_ccouper_$$Country,
                                  PersonData_$_cadrper_$_cstper_$$State
            ";

            Customer_Person_EditMode = eCustomer_Person_EditMode.SELECT_ALL;
            string sWhereCondition = "";
            return usrc_EditTable.Init(dbTables, tbl, selection, ColumnOrderBy, false, sWhereCondition, ID_v, false);

        }
        private void Customer_Person_EditForm_Load(object sender, EventArgs e)
        {
            btn_BankAccounts.Text = lngRPM.s_BankAccounts.s;
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
            if (usrc_EditTable.Identity>=0)
            { 
                Form_Customer_Assign Customer_Assign_dlg = new Form_Customer_Assign(usrc_EditTable.Identity);
                if (Customer_Assign_dlg.ShowDialog()==DialogResult.Yes)
                {
                    this.FirstName = Customer_Assign_dlg.FirstName;
                    this.LastName = Customer_Assign_dlg.LastName;
                    this.GsmNumber = Customer_Assign_dlg.GsmNumber;
                    this.PhoneNumber = Customer_Assign_dlg.PhoneNumber;
                    this.StreetName = Customer_Assign_dlg.StreetName;
                    this.HouseNumber = Customer_Assign_dlg.HouseNumber;
                    this.ZIP = Customer_Assign_dlg.ZIP;
                    this.City = Customer_Assign_dlg.City;
                    this.Country = Customer_Assign_dlg.Country;
                    this.State = Customer_Assign_dlg.State;
                    this.DateOfBirth = Customer_Assign_dlg.DateOfBirth;
                    this.Person_ID = Customer_Assign_dlg.Person_ID;
                    this.CustomerPerson_ID = Customer_Assign_dlg.CustomerPerson_ID;
                    this.Close();
                    DialogResult = DialogResult.Yes;
                }
                else
                {
                    this.Close();
                    DialogResult = DialogResult.No;
                }
            }
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
            DialogResult = DialogResult.Cancel;
        }

        private void usrc_EditTable_after_InsertInDataBase(SQLTable m_tbl, long ID, bool bRes)
        {
            List_of_Inserted_Items_ID.Add(ID);
        }

        private void Item_EditForm_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        internal bool Edit_PersonData()
        {
            SQLTable tbl_PersonData = new SQLTable(DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(PersonData)));
            Form_PersonData_Edit edt_Item_dlg = new Form_PersonData_Edit(DBSync.DBSync.DB_for_Blagajna.m_DBTables,
                                                                        tbl_PersonData,
                                                            "PersonData_$_per_$_cln_$$LastName desc");
            edt_Item_dlg.ShowDialog();
            Init();
            return true;
        }

        internal bool Edit_PersonAccount()
        {
            SQLTable tbl_PersonAccount = new SQLTable(DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(PersonAccount)));
            PersonAccount_EditForm edt_Item_dlg = new PersonAccount_EditForm(DBSync.DBSync.DB_for_Blagajna.m_DBTables,
                                                                        tbl_PersonAccount,
                                                            "PersonAccount_$_per_$_cfn_$$FirstName desc");
            edt_Item_dlg.ShowDialog();
            Init();
            return true;
        }


        private void btn_BankAccounts_Click(object sender, EventArgs e)
        {
            Edit_PersonAccount();
        }

    }
}
