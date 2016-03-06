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
    public partial class Form_myOrg_Office_Data_FVI_SLO_RealEstateBP : Form
    {
        private bool bclose = false;
        string ColumnToOrderBy = "FVI_SLO_RealEstateBP_$$Community asc";
        long m_Office_Data_ID = -1;
        SQLTable tbl_FVI_SLO_RealEstateBP = null;
     
        public Form_myOrg_Office_Data_FVI_SLO_RealEstateBP(long xOffice_Data_ID)
        {
            InitializeComponent();
            m_Office_Data_ID = xOffice_Data_ID;
            tbl_FVI_SLO_RealEstateBP = new SQLTable(DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(FVI_SLO_RealEstateBP)));
            this.Text = lngRPM.s_Edit_Office_Data_FVI_SLO_RealEstateBP.s;
            this.usrc_EditTable1.Title = lngRPM.s_Edit_Office_Data_FVI_SLO_RealEstateBP.s;
            string selection =    @"FVI_SLO_RealEstateBP_$_officed_$_office_$$Name,
                                    FVI_SLO_RealEstateBP_$_officed_$_office_$$ShortName,
                                    FVI_SLO_RealEstateBP_$$BuildingNumber,
                                    FVI_SLO_RealEstateBP_$$BuildingSectionNumber,
                                    FVI_SLO_RealEstateBP_$$Community,
                                    FVI_SLO_RealEstateBP_$$CadastralNumber,
                                    FVI_SLO_RealEstateBP_$$ValidityDate,
                                    FVI_SLO_RealEstateBP_$$ClosingTag,
                                    FVI_SLO_RealEstateBP_$$SoftwareSupplier_TaxNumber,
                                    FVI_SLO_RealEstateBP_$$PremiseType,
                                    ID";
            if (usrc_EditTable1.Init(DBSync.DBSync.DB_for_Tangenta.m_DBTables, tbl_FVI_SLO_RealEstateBP, selection, ColumnToOrderBy, false, " where FVI_SLO_RealEstateBP_$_officed_$$ID = " + m_Office_Data_ID.ToString() + " ", null, false))
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
            if (m_tbl.TableName.ToLower().Equals("office_data"))
            {
                string Err = null;
                m_tbl.FillDataInputControl(DBSync.DBSync.DB_for_Tangenta.m_DBTables.m_con, m_Office_Data_ID, true, ref Err);
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
                usrc_EditTable1.AllowUserToAddNew = false;
            }
        }
    }
}
