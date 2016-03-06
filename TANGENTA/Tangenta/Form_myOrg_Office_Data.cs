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
    public partial class Form_myOrg_Office_Data : Form
    {
        private bool bclose = false;
        string ColumnToOrderBy = "Office_Data_$_office_$$Name asc";
        long m_Office_ID = -1;
        SQLTable tbl_Office_Data = null;
     
        public Form_myOrg_Office_Data(long xOffice_ID)
        {
            InitializeComponent();
            lngRPM.s_Edit_Office_Data_FVI_SLO_RealEstateBP.Text(this.btn_FVI_SLO_RealEstateBP);
            m_Office_ID = xOffice_ID;
            tbl_Office_Data = new SQLTable(DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(Office_Data)));
            this.Text = lngRPM.s_Edit_Office_Data.s;
            this.usrc_EditTable1.Title = lngRPM.s_Edit_Office_Data.s;
            string selection = @" Office_Data_$_office_$_mc_$_orgd_$_org_$$Name,
                                    Office_Data_$_office_$$Name,
                                    Office_Data_$_office_$$ShortName,
                                    Office_Data_$_cadrorg_$_cstrnorg_$$StreetName,
                                    Office_Data_$_cadrorg_$_chounorg_$$HouseNumber,
                                    Office_Data_$_cadrorg_$_cziporg_$$ZIP,
                                    Office_Data_$_cadrorg_$_ccitorg_$$City,
                                    Office_Data_$_cadrorg_$_cstorg_$$Country,
                                    Office_Data_$_cadrorg_$_ccouorg_$$State,
                                    ID";
            if (usrc_EditTable1.Init(DBSync.DBSync.DB_for_Tangenta.m_DBTables, tbl_Office_Data, selection, ColumnToOrderBy, false, " where  Office_Data_$_office_$$ID = " + m_Office_ID.ToString()+" ", null, false))
            {
                if (usrc_EditTable1.RowsCount > 0)
                {
                    usrc_EditTable1.AllowUserToAddNew = false;
                }
                else
                {
                    usrc_EditTable1.FillInitialData();
                    usrc_EditTable1.AllowUserToAddNew = true;
                }
            }
            else
            {
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
            if (m_tbl.TableName.ToLower().Equals("office"))
            {
                string Err = null;
                m_tbl.FillDataInputControl(DBSync.DBSync.DB_for_Tangenta.m_DBTables.m_con, m_Office_ID, true, ref Err);
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
                myOrg.Get(1);
                if (Program.b_FVI_SLO)
                {
                    this.Cursor = Cursors.WaitCursor;
                    Form_myOrg_Office_Data_FVI_SLO_RealEstateBP frm_offd_fvislo_resbp = new Form_myOrg_Office_Data_FVI_SLO_RealEstateBP(ID);
                    frm_offd_fvislo_resbp.ShowDialog();
                    this.Cursor = Cursors.Arrow;
                }
                this.usrc_EditTable1.AllowUserToAddNew = false; //Only one row !!!
            }
        }

        private void btn_FVI_SLO_RealEstateBP_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            Form_myOrg_Office_Data_FVI_SLO_RealEstateBP frm_offd_fvislo_resbp = new Form_myOrg_Office_Data_FVI_SLO_RealEstateBP(this.usrc_EditTable1.Identity);
            frm_offd_fvislo_resbp.ShowDialog();
            this.Cursor = Cursors.Arrow;
        }

    }
}
