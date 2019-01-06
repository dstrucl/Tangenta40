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
using DBConnectionControl40;

namespace ShopB_Forms
{
    public partial class Form_ShopB_Item_Edit : Form
    {
        public List<ID> List_of_Inserted_Items_ID = null;

        DataTable dt_ShopBItem = new DataTable();
        CodeTables.DBTableControl dbTables = null;
        SQLTable tbl = null;
        bool bclose = false;
        NavigationButtons.Navigation nav = null;

        private bool m_bChanged = false;
        public bool Changed
        {
            get { return m_bChanged; }
        }

        public Form_ShopB_Item_Edit(CodeTables.DBTableControl xdbTables, SQLTable xtbl, string ColumnToOrderBy, NavigationButtons.Navigation xnav)
        {
            InitializeComponent();
            m_bChanged = false;
            dbTables = xdbTables;
            if (xnav == null)
            { 
                nav = new NavigationButtons.Navigation(null);
                nav.bDoModal = true;
                nav.m_eButtons = NavigationButtons.Navigation.eButtons.OkCancel;
            }
            else
            {
                nav = xnav;
            }
            
            tbl = xtbl;
            lng.s_Items.Text(this, " "+lng.s_Shop_B.s);
            List_of_Inserted_Items_ID = new List<ID>();
            rdb_OnlyInOffer.Checked = true;
            lng.s_OnlyInOffer.Text(this.rdb_OnlyInOffer);
            lng.s_AllItems.Text(this.rdb_All);
            lng.s_OnlyNotInOffer.Text(this.rdb_OnlyNotInOffer);
            usrc_NavigationButtons1.Init(xnav);
            string selection = " SimpleItem_$$Name,SimpleItem_$$Abbreviation,SimpleItem_$_siimg_$$Image_Data,SimpleItem_$_sipg1_$$Name,SimpleItem_$_sipg1_$_sipg2_$$Name,SimpleItem_$_sipg1_$_sipg2_$_sipg3_$$Name,SimpleItem_$$ToOffer,ID ";
            if (!usrc_EditTable.Init(dbTables, DBSync.DBSync.MyTransactionLog_delegates, tbl, selection, ColumnToOrderBy,false,null,null,false,nav))
            {
                bclose = true;
            }
        }


        private void MyOrganisationData_EditForm_Load(object sender, EventArgs e)
        {
            if (bclose)
            {
                Close();
                DialogResult = DialogResult.Abort;
            }
        }

        private void usrc_EditTable_after_InsertInDataBase(SQLTable m_tbl, ID ID, bool bRes)
        {
            if (bRes)
            {
                List_of_Inserted_Items_ID.Add(ID);
                m_bChanged = true;
            }
        }

        private void usrc_EditTable_after_UpdateDataBase(SQLTable m_tbl, ID ID, bool bRes)
        {
            m_bChanged = true;
        }

        private void do_OK()
        {
            if (usrc_EditTable.Changed)
            {
                if (MessageBox.Show(lng.s_DataChangedSaveYourData.s, "?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    Transaction transaction_Form_SimpleItem_Edit_do_OK_usrc_EditTable_Save = DBSync.DBSync.NewTransaction("Form_SimpleItem_Edit.do_OK.usrc_EditTable.Save");
                    if (usrc_EditTable.Save(transaction_Form_SimpleItem_Edit_do_OK_usrc_EditTable_Save))
                    {
                        transaction_Form_SimpleItem_Edit_do_OK_usrc_EditTable_Save.Commit();
                    }
                    else
                    {
                        transaction_Form_SimpleItem_Edit_do_OK_usrc_EditTable_Save.Rollback();
                    }
                }
            }
            this.Close();
            DialogResult = DialogResult.Yes;

        }

        private void do_Cancel()
        {
            if (usrc_EditTable.Changed)
            {
                if (MessageBox.Show(lng.s_DataChangedDoYouWantToCloseYesNo.s, "?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    this.Close();
                    DialogResult = DialogResult.No;
                }
            }
            else
            {
                this.Close();
                DialogResult = DialogResult.No;
            }
        }

        private void usrc_NavigationButtons1_ButtonPressed(NavigationButtons.Navigation.eEvent evt)
        {
            switch (nav.m_eButtons)
            {
                case NavigationButtons.Navigation.eButtons.OkCancel:

                    switch (evt)
                    {
                        case NavigationButtons.Navigation.eEvent.OK:
                            nav.eExitResult = evt;
                            do_OK();
                            break;
                        case NavigationButtons.Navigation.eEvent.CANCEL:
                            nav.eExitResult = evt;
                            do_Cancel();
                            break;
                    }
                    break;
                case NavigationButtons.Navigation.eButtons.PrevNextExit:
                    switch (evt)
                    {
                        case NavigationButtons.Navigation.eEvent.EXIT:
                            nav.eExitResult = evt;
                            do_Cancel();
                            break;
                        case NavigationButtons.Navigation.eEvent.PREV:
                            nav.eExitResult = evt;
                            do_Cancel();
                            break;
                        case NavigationButtons.Navigation.eEvent.NEXT:
                            nav.eExitResult = evt;
                            do_OK();
                            break;
                    }
                    break;
            }

        }

        private void Form_ShopB_Item_Edit_KeyUp(object sender, KeyEventArgs e)
        {
           this.usrc_EditTable.KeyPressed(e.KeyCode);
        }
    }
}
