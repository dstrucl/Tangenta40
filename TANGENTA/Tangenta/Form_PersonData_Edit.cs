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
using InvoiceDB;

namespace Tangenta
{
    public partial class Form_PersonData_Edit : Form
    {
        List<long> List_of_Inserted_Items_ID = null; 
        DataTable dt_Item = new DataTable();
        SQLTableControl.DBTableControl dbTables = null;
        SQLTable tbl = null;
        long_v ID_v = null;
        string ColumnOrderBy = "";

        public Form_PersonData_Edit(SQLTableControl.DBTableControl xdbTables, SQLTable xtbl,string xColumnOrderBy)
        {
            InitializeComponent();
            dbTables = xdbTables;
            tbl = xtbl;
            ColumnOrderBy = xColumnOrderBy;
            this.Text = lngRPM.s_Customers_Person.s;

        }

        public Form_PersonData_Edit(SQLTableControl.DBTableControl xdbTables, SQLTable xtbl, string xColumnOrderBy, long ID)
        {
            InitializeComponent();
            dbTables = xdbTables;
            tbl = xtbl;
            ColumnOrderBy = xColumnOrderBy;
            ID_v = new long_v();
            ID_v.v = ID;
            this.Text = lngRPM.s_Items.s;

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
                    PersonData_$_cadrper_$_ccouper_$$Country,
                    PersonData_$_cadrper_$_cstper_$$State,
                    PersonData_$$CardNumber,
                    PersonData_$_cardtper_$$CardType,
                    PersonData_$_perimg_$$Image_Data,
                    PersonData_$$Description
            ";

            string sWhereCondition = "";
            return usrc_EditTable.Init(dbTables, tbl, selection, ColumnOrderBy, false, sWhereCondition, ID_v, false);

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
        }

    }
}
