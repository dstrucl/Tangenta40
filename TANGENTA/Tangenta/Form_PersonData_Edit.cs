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
using TangentaDB;

namespace Tangenta
{
    public partial class Form_PersonData_Edit : Form
    {
        List<long> List_of_Inserted_Items_ID = null; 
        DataTable dt_Item = new DataTable();
        CodeTables.DBTableControl dbTables = null;
        SQLTable tbl = null;
        long_v ID_v = null;
        string ColumnOrderBy = "";
        string sWhereCondition = "";
        NavigationButtons.Navigation nav = null;
        private long m_Person_ID = -1;

        public Form_PersonData_Edit(CodeTables.DBTableControl xdbTables, SQLTable xtbl,string xColumnOrderBy,NavigationButtons.Navigation xnav)
        {
            InitializeComponent();
            nav = xnav;
            dbTables = xdbTables;
            tbl = xtbl;
            ColumnOrderBy = xColumnOrderBy;
            this.Text = lng.s_Customers_Person.s;

        }

        public Form_PersonData_Edit(long Person_ID,CodeTables.DBTableControl xdbTables, SQLTable xtbl, string xColumnOrderBy,long PersonData_ID,  NavigationButtons.Navigation xnav)
        {
            InitializeComponent();
            nav = xnav;
            dbTables = xdbTables;
            tbl = xtbl;
            ColumnOrderBy = xColumnOrderBy;
            ID_v = new long_v();
            ID_v.v = PersonData_ID;
            lng.s_OtherPersonDana.Text(this);
            m_Person_ID = Person_ID;
        }

        public Form_PersonData_Edit(long Person_ID,string xWhereCondition, CodeTables.DBTableControl xdbTables, SQLTable xtbl, string xColumnOrderBy, long PersonData_ID, NavigationButtons.Navigation xnav)
        {
            InitializeComponent();
            nav = xnav;
            dbTables = xdbTables;
            tbl = xtbl;
            ColumnOrderBy = xColumnOrderBy;
            ID_v = new long_v();
            ID_v.v = PersonData_ID;
            lng.s_OtherPersonDana.Text(this);
            m_Person_ID = Person_ID;
            sWhereCondition = xWhereCondition;
        }

        private bool Init()
        {
            string selection = @" ID,
                    PersonData_$_per_$_cfn_$$FirstName,
                    PersonData_$_per_$_cln_$$LastName,
                    PersonData_$_per_$$Gender,
                    PersonData_$_cgsmnper_$$GsmNumber,
                    PersonData_$_cphnnper_$$PhoneNumber,
                    PersonData_$_cemailper_$$Email,
                    PersonData_$_per_$$Tax_ID,
                    PersonData_$_per_$$Registration_ID,
                    PersonData_$_cadrper_$_cstrnper_$$StreetName,
                    PersonData_$_cadrper_$_chounper_$$HouseNumber,
                    PersonData_$_cadrper_$_zipper_$$ZIP,
                    PersonData_$_cadrper_$_ccitper_$$City,
                    PersonData_$_cadrper_$_ccouper_$$State,
                    PersonData_$_cadrper_$_cstper_$$Country,
                    PersonData_$$CardNumber,
                    PersonData_$_cardtper_$$CardType,
                    PersonData_$_perimg_$$Image_Data,
                    PersonData_$$Description
            ";

            usrc_EditTable.AllowUserToAddNew = false;
            tbl.SetColumnStyle("Person_ID", Column.eStyle.ReadOnlyTable);
            if (usrc_EditTable.Init(dbTables, tbl, selection, ColumnOrderBy, false, sWhereCondition, ID_v, false,nav))
            {
                usrc_EditTable.FillInitialData();
                string s_Person = "";
                object oFirstName = usrc_EditTable.GetColumnObject("PersonData_$_per_$_cfn_$$FirstName");
                if (oFirstName is string)
                {
                    s_Person = lng.s_Person.s + " " + (string)oFirstName;
                }
                object oLastName = usrc_EditTable.GetColumnObject("PersonData_$_per_$_cln_$$LastName");
                if (oLastName is string)
                {
                    s_Person += " " + (string)oLastName;
                }
                usrc_EditTable.Title = s_Person;
                return true;
            }
            else
            {
                return false;
            }

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
                if (MessageBox.Show(lng.s_DataChangedSaveYourData.s, "?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
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
                if (MessageBox.Show(lng.s_DataChangedSaveYourData.s, "?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
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
        }

        private void usrc_EditTable_FillTable(SQLTable m_tbl)
        {
            if (m_Person_ID >= 0)
            {
                if (m_tbl.TableName.ToLower().Equals("Person"))
                {
                    string Err = null;
                    m_tbl.FillDataInputControl(DBSync.DBSync.DB_for_Tangenta.m_DBTables.m_con, m_Person_ID, true, ref Err);
                }
            }
        }
    }
}
