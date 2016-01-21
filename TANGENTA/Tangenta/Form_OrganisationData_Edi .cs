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
using InvoiceDB;

namespace Tangenta
{
    public partial class OrganisationData_EditForm : Form
    {
        List<long> List_of_Inserted_Items_ID = null; 
        DataTable dt_Item = new DataTable();
        SQLTableControl.DBTableControl dbTables = null;
        SQLTable tbl = null;
        long_v ID_v = null;
        string ColumnOrderBy = "";

        public OrganisationData_EditForm(SQLTableControl.DBTableControl xdbTables, SQLTable xtbl,string xColumnOrderBy)
        {
            InitializeComponent();
            dbTables = xdbTables;
            tbl = xtbl;
            ColumnOrderBy = xColumnOrderBy;
            this.Text = lngRPM.s_OrganisationData.s;

        }

        public OrganisationData_EditForm(SQLTableControl.DBTableControl xdbTables, SQLTable xtbl, string xColumnOrderBy, long ID)
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
                     OrganisationData_$_org_$$Name,
                     OrganisationData_$_org_$$Tax_ID,
                     OrganisationData_$_cadrorg_$_cstrnorg_$$StreetName,
                     OrganisationData_$_cadrorg_$_chounorg_$$HouseNumber,
                     OrganisationData_$_cadrorg_$_cziporg_$$ZIP,
                     OrganisationData_$_cadrorg_$_ccitorg_$$City,
                     OrganisationData_$_cadrorg_$_cstorg_$$State,
                     OrganisationData_$_cadrorg_$_ccouorg_$$Country,
                     OrganisationData_$_cphnnorg_$$PhoneNumber,
                     OrganisationData_$_org_$$Registration_ID,
                     OrganisationData_$_logo_$$Image_Hash,
                     OrganisationData_$_logo_$$Image_Data,
                     OrganisationData_$_logo_$$Description
            ";
            string sWhereCondition = "";
            return usrc_EditTable.Init(dbTables, tbl, selection, ColumnOrderBy, false, sWhereCondition, ID_v,false);

        }
        private void OrganisationData_EditForm_Load(object sender, EventArgs e)
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

        private void Item_EditForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (f_PriceList.Check((Form)this.Parent))
            {
               
            }
        }

    }
}