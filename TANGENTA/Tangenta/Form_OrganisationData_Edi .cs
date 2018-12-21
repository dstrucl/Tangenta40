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
using DBConnectionControl40;

namespace Tangenta
{
    public partial class OrganisationData_EditForm : Form
    {
        private List<ID> List_of_Inserted_Items_ID = null;
        private DataTable dt_Item = new DataTable();
        private CodeTables.DBTableControl dbTables = null;
        private SQLTable tbl = null;
        private ID mID = null;
        private string ColumnOrderBy = "";
        private NavigationButtons.Navigation nav = null;
        public OrganisationData_EditForm(CodeTables.DBTableControl xdbTables, SQLTable xtbl,string xColumnOrderBy,NavigationButtons.Navigation xnav)
        {
            InitializeComponent();
            nav = xnav;
            dbTables = xdbTables;
            tbl = xtbl;
            ColumnOrderBy = xColumnOrderBy;
            this.Text = lng.s_OrganisationData.s;

        }

        public OrganisationData_EditForm(CodeTables.DBTableControl xdbTables, SQLTable xtbl, string xColumnOrderBy, ID xID, NavigationButtons.Navigation xnav)
        {
            InitializeComponent();
            nav = xnav;
            dbTables = xdbTables;
            tbl = xtbl;
            ColumnOrderBy = xColumnOrderBy;
            mID = xID;
            this.Text = lng.s_Items.s;

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
                     OrganisationData_$_cadrorg_$_ccouorg_$$Country,
                     OrganisationData_$_cadrorg_$_cstorg_$$State,
                     OrganisationData_$_cphnnorg_$$PhoneNumber,
                     OrganisationData_$_org_$$Registration_ID,
                     OrganisationData_$_logo_$$Image_Hash,
                     OrganisationData_$_logo_$$Image_Data,
                     OrganisationData_$_logo_$$Description
            ";
            string sWhereCondition = "";
            return usrc_EditTable.Init(dbTables, tbl, selection, ColumnOrderBy, false, sWhereCondition, mID,false,nav);

        }
        private void OrganisationData_EditForm_Load(object sender, EventArgs e)
        {
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
                    Transaction transaction_Form_OrganisationAccount_Edit_btn_OK_Click_usrc_EditTable_Save = new Transaction("Form_OrganisationAccount_Edit.btn_OK_Click.usrc_EditTable.Save");
                    if (usrc_EditTable.Save(transaction_Form_OrganisationAccount_Edit_btn_OK_Click_usrc_EditTable_Save))
                    {
                        if (!transaction_Form_OrganisationAccount_Edit_btn_OK_Click_usrc_EditTable_Save.Commit())
                        {
                            return;
                        }
                    }
                    else
                    {
                        transaction_Form_OrganisationAccount_Edit_btn_OK_Click_usrc_EditTable_Save.Rollback();
                        return;
                    }
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
                    Transaction transaction_Form_OrganisationAccount_Edit_btn_Cancel_Click_usrc_EditTable_Save = new Transaction("Form_OrganisationAccount_Edit.btn_Cancel_Click.usrc_EditTable.Save");
                    if (usrc_EditTable.Save(transaction_Form_OrganisationAccount_Edit_btn_Cancel_Click_usrc_EditTable_Save))
                    {
                        if (!transaction_Form_OrganisationAccount_Edit_btn_Cancel_Click_usrc_EditTable_Save.Commit())
                        {
                            return;
                        }
                    }
                    else
                    {
                        transaction_Form_OrganisationAccount_Edit_btn_Cancel_Click_usrc_EditTable_Save.Rollback();
                        return;
                    }
                }
            }
            this.Close();
            DialogResult = DialogResult.No;
        }

        private void usrc_EditTable_after_InsertInDataBase(SQLTable m_tbl, ID xID, bool bRes)
        {
            List_of_Inserted_Items_ID.Add(xID);
        }

        private void Item_EditForm_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void OrganisationData_EditForm_KeyUp(object sender, KeyEventArgs e)
        {
            this.usrc_EditTable.KeyPressed(e.KeyCode);
        }
    }
}
