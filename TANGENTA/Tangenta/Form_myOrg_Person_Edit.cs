#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion

using TangentaTableClass;
using DBTypes;
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
    public partial class Form_myOrg_Person_Edit : Form
    {
        bool bclose = false;
        SQLTable tbl = null;
        long_v ID_v = null;
        private long m_Office_ID;
        private SQLTable tbl_myOrganisation_Person;
        private string ColumnToOrderBy = "myOrganisation_Person_$_per_$_cln_$$LastName asc";
        NavigationButtons.Navigation nav = null;

        public Form_myOrg_Person_Edit(long xOffice_ID,NavigationButtons.Navigation xnav)
        {
            InitializeComponent();
            nav = xnav;
            m_Office_ID = xOffice_ID;
            tbl_myOrganisation_Person = new SQLTable(DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(myOrganisation_Person)));
            lngRPM.s_myOrganisation_Person_Data.Text(this);
            this.Icon = Properties.Resources.Person;
            this.usrc_EditTable1.Title = lngRPM.s_Edit_Office_Data.s;
            string selection = @"  myOrganisation_Person_$_per_$_cfn_$$FirstName,
                                    myOrganisation_Person_$_per_$_cln_$$LastName,
                                    myOrganisation_Person_$_per_$$DateOfBirth,
                                    myOrganisation_Person_$_per_$$Tax_ID,
                                    myOrganisation_Person_$_per_$$Registration_ID,
                                    myOrganisation_Person_$_office_$_mo_$_orgd_$_org_$$Name,
                                    myOrganisation_Person_$_office_$$Name,
                                    myOrganisation_Person_$_office_$$ShortName,
                                    ID
            ";
            long_v Office_ID_v = null;
            if (m_Office_ID >= 0)
            {
                Office_ID_v = new long_v(m_Office_ID);
            }
            if (usrc_EditTable1.Init(DBSync.DBSync.DB_for_Tangenta.m_DBTables, tbl_myOrganisation_Person, selection, ColumnToOrderBy, false, " where  myOrganisation_Person_$_office_$$ID = " + m_Office_ID.ToString() + " ", null, false,nav))
            {
                usrc_EditTable1.FillInitialData();
            }
            else
            {
                bclose = true;
            }
        }

        private void Form_myOrg_Person_Edit_Load(object sender, EventArgs e)
        {
            if (bclose)
            {
                DialogResult = DialogResult.Abort;
                this.Close();
            }
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            if (usrc_EditTable1.Changed)
            {
                if (XMessage.Box.Show(this, lngRPM.s_YouDidNotWriteDataToDB_SaveData_YesOrNo, lngRPM.s_Warning.s, MessageBoxButtons.YesNo, Properties.Resources.Tangenta_Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    if (usrc_EditTable1.Save())
                    {
                        Close();
                        DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        if (XMessage.Box.Show(this, lngRPM.s_DataNotSavedEndYesNo, "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                        {
                            this.Close();
                            DialogResult = DialogResult.OK;
                        }
                    }

                }
                else
                {
                    Close();
                    DialogResult = DialogResult.OK;
                }
            }
            else
            {
                if (usrc_EditTable1.RowsCount > 0)
                {
                    Close();
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    XMessage.Box.Show(this, lngRPM.s_YouMustEnterYourOfficePersonData, "", MessageBoxButtons.OK, Properties.Resources.Tangenta_Question, MessageBoxDefaultButton.Button1);
                }
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {

            if (usrc_EditTable1.RowsCount > 0)
            {
                Close();
                DialogResult = DialogResult.OK;
            }
            else
            {
                if (XMessage.Box.Show(this, lngRPM.s_YouDidNotEnterYourOrganisationPersonData, "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    Close();
                    DialogResult = DialogResult.Cancel;
                }
            }
        }

        private void usrc_EditTable1_after_FillDataInputControl(SQLTable m_tbl, long ID)
        {

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
    }
}
