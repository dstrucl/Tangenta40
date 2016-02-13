#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion

using BlagajnaTableClass;
using DBTypes;
using LanguageControl;
using SQLTableControl;
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
        private SQLTable tbl_myCompany_Person;
        private string ColumnToOrderBy = "myCompany_Person_$_per_$_cln_$$LastName asc";
        //bool bclose = false;

        public Form_myOrg_Person_Edit(long xOffice_ID)
        {
            InitializeComponent();
            m_Office_ID = xOffice_ID;
            tbl_myCompany_Person = new SQLTable(DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(myCompany_Person)));
            this.Text = lngRPM.s_Edit_Office_Data.s;
            this.usrc_EditTable1.Title = lngRPM.s_Edit_Office_Data.s;
            string selection = @"  myCompany_Person_$_per_$_cfn_$$FirstName,
                                    myCompany_Person_$_per_$_cln_$$LastName,
                                    myCompany_Person_$_per_$$DateOfBirth,
                                    myCompany_Person_$_per_$$Tax_ID,
                                    myCompany_Person_$_per_$$Registration_ID,
                                    myCompany_Person_$_office_$_mc_$_orgd_$_org_$$Name,
                                    myCompany_Person_$_office_$$Name,
                                    myCompany_Person_$_office_$$ShortName,
                                    ID
            ";
            long_v Office_ID_v = null;
            if (m_Office_ID >= 0)
            {
                Office_ID_v = new long_v(m_Office_ID);
            }
            if (usrc_EditTable1.Init(DBSync.DBSync.DB_for_Blagajna.m_DBTables, tbl_myCompany_Person, selection, ColumnToOrderBy, false, " where  myCompany_Person_$_office_$$ID = " + m_Office_ID.ToString() + " ", null, false))
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
            this.Close();
            DialogResult = DialogResult.OK;
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
            DialogResult = DialogResult.Cancel;
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
                m_tbl.FillDataInputControl(DBSync.DBSync.DB_for_Blagajna.m_DBTables.m_con, m_Office_ID, true, ref Err);
            }
        }

        private void usrc_EditTable1_after_New(SQLTable m_tbl, bool bRes)
        {
            usrc_EditTable1.FillInitialData();
        }
        #endregion
    }
}
