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
using CodeTables.TableDocking_Form;
using TangentaDB;
using DBConnectionControl40;

namespace Tangenta
{
    public partial class Form_OrganisationAccount_Edit : Form
    {
        private List<ID> List_of_Inserted_Items_ID = null;
        private DataTable dt_Item = new DataTable();
        private CodeTables.DBTableControl dbTables = null;
        private SQLTable tbl = null;
        private ID mID = null;
        private string ColumnOrderBy = "";
        private NavigationButtons.Navigation nav = null;

        private ID m_BankAccount_ID = null;
        public ID BankAccount_ID
        {
            get { return m_BankAccount_ID; }
        }

        private string m_BankName = null;
        public string BankName
        {
            get { return m_BankName; }
        }

        private string m_Bank_Tax_ID = null;
        public string Bank_Tax_ID
        {
            get { return m_Bank_Tax_ID; }
        }

        private string m_Bank_Registration_ID = null;
        public string Bank_Registration_ID
        {
            get { return m_Bank_Registration_ID; }
        }


        private string m_TRR = null;
        public string TRR
        {
            get { return m_TRR; }
        }

        public Form_OrganisationAccount_Edit(CodeTables.DBTableControl xdbTables, SQLTable xtbl,string xColumnOrderBy, NavigationButtons.Navigation xnav)
        {
            InitializeComponent();
            nav = xnav;
            dbTables = xdbTables;
            tbl = xtbl;
            ColumnOrderBy = xColumnOrderBy;
            this.Text = lng.s_OrganisationAccount.s;

        }

        public Form_OrganisationAccount_Edit(CodeTables.DBTableControl xdbTables, SQLTable xtbl, string xColumnOrderBy, ID xID, NavigationButtons.Navigation xnav)
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
            string selection = @"
                    OrganisationAccount_$_bankacc_$$TRR,
                    OrganisationAccount_$_bankacc_$_bank_$_org_$$Name,
                    OrganisationAccount_$_bankacc_$_bank_$_org_$$Tax_ID,
                    OrganisationAccount_$_bankacc_$_bank_$_org_$$Registration_ID,
                    OrganisationAccount_$_bankacc_$$Active,
                    OrganisationAccount_$_bankacc_$$Description,
                    OrganisationAccount_$$Description,
                    OrganisationAccount_$_bankacc_$$ID,
                    ID
            ";

            string sWhereCondition = "";
            return usrc_EditTable.Init(dbTables, DBSync.DBSync.MyTransactionLog_delegates, tbl, selection, ColumnOrderBy, false, sWhereCondition, mID,false,nav);

        }
        private void Customer_Person_EditForm_Load(object sender, EventArgs e)
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
                    Transaction transaction_Form_OrganisationAccount_Edit_btn_OK_Click_usrc_EditTable_Save = DBSync.DBSync.NewTransaction("Form_OrganisationAccount_Edit.btn_OK_Click.usrc_EditTable.Save");
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
                    Transaction transaction_Form_OrganisationAccount_Edit_btn_Cancel_Click_usrc_EditTable_Save = DBSync.DBSync.NewTransaction("Form_OrganisationAccount_Edit.btn_Cancel_Click.usrc_EditTable.Save");
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
            if (bRes)
            {
                FillProperties(m_tbl, xID);
            }
        }

        private void usrc_EditTable_SelectedIndexChanged(SQLTable m_tbl, ID xID, int index)
        {
            FillProperties(m_tbl, xID);
        }

        private void OrganisationAccount_EditForm_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void FillProperties(SQLTable m_tbl,ID xID)
        {
            this.m_BankName = null;
            object oBankName = m_tbl.Value("OrganisationAccount_$_bankacc_$_bank_$_org_$$Name");
            if (oBankName is TangentaTableClass.Name)
            {
                if (((TangentaTableClass.Name)oBankName).defined)
                {
                    this.m_BankName = ((TangentaTableClass.Name)oBankName).val;
                }
            }
            object oBank_Tax_ID = m_tbl.Value("OrganisationAccount_$_bankacc_$_bank_$_org_$$Tax_ID");
            if (oBank_Tax_ID is TangentaTableClass.Tax_ID)
            {
                if (((TangentaTableClass.Tax_ID)oBank_Tax_ID).defined)
                {
                    this.m_Bank_Tax_ID = ((TangentaTableClass.Tax_ID)oBank_Tax_ID).val;
                }
            }

            object oBank_Registration_ID = m_tbl.Value("OrganisationAccount_$_bankacc_$_bank_$_org_$$Registration_ID");
            if (oBank_Registration_ID is TangentaTableClass.Registration_ID)
            {
                if (((TangentaTableClass.Registration_ID)oBank_Registration_ID).defined)
                {
                    this.m_Bank_Registration_ID = ((TangentaTableClass.Registration_ID)oBank_Registration_ID).val;
                }
            }

            object oTRR = m_tbl.Value("OrganisationAccount_$_bankacc_$$TRR");
            this.m_TRR = null;
            if (oTRR is TangentaTableClass.TRR)
            {
                if (((TangentaTableClass.TRR)oTRR).defined)
                {
                    this.m_TRR = ((TangentaTableClass.TRR)oTRR).val;
                }
            }

            object oBankAccount_ID = tf.set_ID(m_tbl.Value("OrganisationAccount_$_bankacc_$$ID"));
            if (oBankAccount_ID is ID)
            {
                    this.m_BankAccount_ID = ((ID)oBankAccount_ID);
            }


        }

        private void Form_OrganisationAccount_Edit_KeyUp(object sender, KeyEventArgs e)
        {
            this.usrc_EditTable.KeyPressed(e.KeyCode);
        }
    }
}
