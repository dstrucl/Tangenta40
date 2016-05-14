// Copyright (c) 2011 rubicon IT GmbH
using TangentaTableClass;
using DBTypes;
using InvoiceDB;
using LanguageControl;
using CodeTables;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tangenta
{
    public partial class Form_myOrg_Office : Form
    {
        private bool bclose = false;
        string ColumnToOrderBy = "Office_$_mo_$_orgd_$_org_$$Name asc";
        long myOrganisation_ID = -1;
        SQLTable tbl_Office = null;

        public Form_myOrg_Office()
        {
            InitializeComponent();
            lngRPM.s_Edit_Office_Data.Text(btn_Office_Data_And_FVI_SLO_RealEstateBP);
            if (myOrg.ID_v != null)
            {
                myOrganisation_ID = myOrg.ID_v.v;
                tbl_Office = new SQLTable(DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(Office)));
                this.Text = lngRPM.s_Edit_Offices.s;
                this.usrc_EditTable1.Title = lngRPM.s_Edit_Offices.s;
                long_v myOrganisation_ID_v = new long_v(myOrganisation_ID);
                string selection = "Office_$$Name,Office_$$ShortName,Office_$_mo_$_orgd_$_org_$$Name,Office_$_mo_$_orgd_$_orgt_$$OrganisationTYPE,Office_$_mo_$_orgd_$_org_$$Tax_ID,ID";
                string where_condition = " where Office_$_mo_$$ID = " + myOrganisation_ID.ToString() + " ";
                if (usrc_EditTable1.Init(DBSync.DBSync.DB_for_Tangenta.m_DBTables, tbl_Office, selection, ColumnToOrderBy, false, null, null, false))
                {
                    usrc_EditTable1.FillInitialData();
                }
                else
                {
                    bclose = true;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:Tangenta:Form_myOrg_Offices_Edit():myOrg.ID_v is not defined!");
                bclose = true;
            }
        }
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
            DialogResult = DialogResult.Cancel;
        }

        #region Fill ReadOnlyDaTa
        private void usrc_EditTable1_FillTable(SQLTable m_tbl)
        {
            if (m_tbl.TableName.ToLower().Equals("myorganisation"))
            {
                string Err = null;
                m_tbl.FillDataInputControl(DBSync.DBSync.DB_for_Tangenta.m_DBTables.m_con, myOrganisation_ID, true, ref Err);
            }
        }

        private void usrc_EditTable1_after_New(SQLTable m_tbl, bool bRes)
        {
            usrc_EditTable1.FillInitialData();
        }
        #endregion

        private void Form_myOrg_Offices_Edit_Load(object sender, EventArgs e)
        {
            if (bclose)
            {
                DialogResult = DialogResult.Abort;
                this.Close();
            }
        }

        private void usrc_EditTable1_after_InsertInDataBase(SQLTable m_tbl, long ID, bool bRes)
        {
            if (bRes)
            {
                this.Cursor = Cursors.WaitCursor;
                Form_myOrg_Office_Data frm_offdata = new Form_myOrg_Office_Data(ID);
                frm_offdata.ShowDialog(this);
                this.Cursor = Cursors.Arrow;
                myOrg.Get(1);
            }
        }

        private void btn_Office_Data_And_FVI_SLO_RealEstateBP_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            Form_myOrg_Office_Data frm_offdata = new Form_myOrg_Office_Data(this.usrc_EditTable1.Identity);
            frm_offdata.ShowDialog(this);
            this.Cursor = Cursors.Arrow;
        }

    }
}
