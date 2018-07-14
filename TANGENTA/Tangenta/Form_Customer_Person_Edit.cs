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
    public partial class Form_Customer_Person_Edit : Form
    {
        public enum eCustomer_Person_EditMode { SELECT_VALID, SELECT_UNVALID, SELECT_ALL };

        internal string FirstName = null;
        internal string LastName = null;
        internal string GsmNumber = null;
        internal string PhoneNumber = null;
        internal string StreetName = null;
        internal string HouseNumber = null;
        internal string ZIP = null;
        internal string City = null;
        internal string State = null;
        internal string Country= null;
        internal DateTime DateOfBirth = DateTime.MinValue;
        public ID Person_ID = null;
        public ID CustomerPerson_ID = null;
        private List<ID> List_of_Inserted_Items_ID = null;
        private DataTable dt_Item = new DataTable();
        private CodeTables.DBTableControl dbTables = null;
        private SQLTable tbl = null;
        private ID mID = null;
        private string ColumnOrderBy = "";
        private NavigationButtons.Navigation nav = null;

        public Form_Customer_Person_Edit(CodeTables.DBTableControl xdbTables, SQLTable xtbl,string xColumnOrderBy, NavigationButtons.Navigation xnav)
        {
            InitializeComponent();
            nav = xnav;
            dbTables = xdbTables;
            tbl = xtbl;
            ColumnOrderBy = xColumnOrderBy;
            this.Text = lng.s_Customers_Person.s;
            this.usrc_EditTable.Title = xtbl.lngTableName.s;

        }

        public Form_Customer_Person_Edit(CodeTables.DBTableControl xdbTables, SQLTable xtbl, string xColumnOrderBy, ID xID)
        {
            InitializeComponent();
            dbTables = xdbTables;
            tbl = xtbl;
            ColumnOrderBy = xColumnOrderBy;
            mID = xID;
            this.Text = lng.s_Items.s;
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
                                  PersonData_$_cadrper_$_ccouper_$$State,
                                  PersonData_$_cadrper_$_cstper_$$Country
            ";
            string sWhereCondition = "";
            tbl.SetAsFirstColumn("Person_ID");
            //tbl.SetColumnStyle("Person_ID",Column.eStyle.ReadOnlyTable);
            return usrc_EditTable.Init(dbTables, tbl, selection, ColumnOrderBy, false, sWhereCondition, mID, false,nav);

        }
        private void Customer_Person_EditForm_Load(object sender, EventArgs e)
        {
            btn_BankAccounts.Text = lng.s_BankAccounts.s;
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
                    usrc_EditTable.Save();
                }
            }
            if (ID.Validate(usrc_EditTable.Identity))
            { 
                Form_Customer_Person_Assign Customer_Assign_dlg = new Form_Customer_Person_Assign(usrc_EditTable.Identity);
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
                    this.State = Customer_Assign_dlg.State;
                    this.State= Customer_Assign_dlg.Country;
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
                if (MessageBox.Show(lng.s_DataChangedSaveYourData.s, "?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    usrc_EditTable.Save();
                }
            }
            this.Close();
            DialogResult = DialogResult.Cancel;
        }

        private void usrc_EditTable_after_InsertInDataBase(SQLTable m_tbl, ID xID, bool bRes)
        {
            List_of_Inserted_Items_ID.Add(xID);
        }

        private void Item_EditForm_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        internal bool Edit_PersonData()
        {
            SQLTable tbl_PersonData = new SQLTable(DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(PersonData)));
            Form_PersonData_Edit edt_Item_dlg = new Form_PersonData_Edit(DBSync.DBSync.DB_for_Tangenta.m_DBTables,
                                                                        tbl_PersonData,
                                                            "PersonData_$_per_$_cln_$$LastName desc",nav);
            edt_Item_dlg.ShowDialog();
            Init();
            return true;
        }

        internal bool Edit_PersonAccount()
        {
            SQLTable tbl_PersonAccount = new SQLTable(DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(PersonAccount)));
            PersonAccount_EditForm edt_Item_dlg = new PersonAccount_EditForm(DBSync.DBSync.DB_for_Tangenta.m_DBTables,
                                                                        tbl_PersonAccount,
                                                            "PersonAccount_$_per_$_cfn_$$FirstName desc",nav);
            edt_Item_dlg.ShowDialog();
            Init();
            return true;
        }


        private void btn_BankAccounts_Click(object sender, EventArgs e)
        {
            Edit_PersonAccount();
        }

        private void Form_Customer_Person_Edit_KeyUp(object sender, KeyEventArgs e)
        {
            this.usrc_EditTable.KeyPressed(e.KeyCode);
        }
    }
}
