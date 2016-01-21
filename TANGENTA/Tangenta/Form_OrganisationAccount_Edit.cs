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
using SQLTableControl.TableDocking_Form;
using InvoiceDB;

namespace Tangenta
{
    public partial class Form_OrganisationAccount_Edit : Form
    {
        List<long> List_of_Inserted_Items_ID = null; 
        DataTable dt_Item = new DataTable();
        SQLTableControl.DBTableControl dbTables = null;
        SQLTable tbl = null;
        long_v ID_v = null;
        string ColumnOrderBy = "";

        public Form_OrganisationAccount_Edit(SQLTableControl.DBTableControl xdbTables, SQLTable xtbl,string xColumnOrderBy)
        {
            InitializeComponent();
            dbTables = xdbTables;
            tbl = xtbl;
            ColumnOrderBy = xColumnOrderBy;
            this.Text = lngRPM.s_OrganisationAccount.s;

        }

        public Form_OrganisationAccount_Edit(SQLTableControl.DBTableControl xdbTables, SQLTable xtbl, string xColumnOrderBy, long ID)
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
                    OrganisationAccount_$_bankacc_$_bank_$_org_$$Name,
                    OrganisationAccount_$_bankacc_$_bank_$_org_$$Tax_ID,
                    OrganisationAccount_$_bankacc_$_bank_$_org_$$Name,
                    OrganisationAccount_$_bankacc_$$TRR,
                    OrganisationAccount_$_bankacc_$$Active,
                    OrganisationAccount_$_bankacc_$$Description,
                    OrganisationAccount_$$Description
            ";

            string sWhereCondition = "";
            return usrc_EditTable.Init(dbTables, tbl, selection, ColumnOrderBy, false, sWhereCondition, ID_v,false);

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

        private void OrganisationAccount_EditForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (f_PriceList.Check((Form)this.Parent))
            {
               
            }
        }

    }
}
