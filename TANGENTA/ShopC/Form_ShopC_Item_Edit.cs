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

namespace ShopC
{
    public partial class Form_ShopC_Item_Edit : Form
    {
        public enum eItem_EditMode { SELECT_VALID, SELECT_UNVALID, SELECT_ALL };
        private eItem_EditMode ItemEditMode = eItem_EditMode.SELECT_VALID;
        Control ParentControl = null;
        usrc_StockEditForSelectedStockTake m_usrc_StockEditForSelectedStockTake = null;

        public List<ID> List_of_Inserted_Items_ID = null; 
        DataTable dt_Item = new DataTable();
        CodeTables.DBTableControl dbTables = null;
        SQLTable tbl = null;
        ID ID = null;
        string ColumnOrderBy = "";
        NavigationButtons.Navigation nav = null;

        private bool m_bChanged = false;
        public bool Changed
        {
            get { return m_bChanged; }
        }


        public bool bShopC_Item_NotIn_PriceList = false;

        public Form_ShopC_Item_Edit(CodeTables.DBTableControl xdbTables, SQLTable xtbl,string xColumnOrderBy, NavigationButtons.Navigation xnav)
        {
            InitializeComponent();
            nav = xnav;
            dbTables = xdbTables;
            tbl = xtbl;
            usrc_NavigationButtons1.Init(nav);
            ColumnOrderBy = xColumnOrderBy;
            lng.s_Items.Text(this, " "+lng.s_ShopC_Name.s);
            rdb_OnlyInOffer.Checked = true;
            lng.s_OnlyInOffer.Text(this.rdb_OnlyInOffer);
            lng.s_AllItems.Text(this.rdb_All);
            lng.s_OnlyNotInOffer.Text(this.rdb_OnlyNotInOffer);
        }

        public Form_ShopC_Item_Edit(CodeTables.DBTableControl xdbTables, SQLTable xtbl, string xColumnOrderBy, ID xID, Control xParentControl)
        {
            InitializeComponent();
            dbTables = xdbTables;
            tbl = xtbl;
            ColumnOrderBy = xColumnOrderBy;
            ID = xID;
            ParentControl = xParentControl;
            if (ParentControl != null)
            {
                if (ParentControl is usrc_StockEditForSelectedStockTake)
                {
                    m_usrc_StockEditForSelectedStockTake = (usrc_StockEditForSelectedStockTake)ParentControl;
                }
            }
            this.Text = lng.s_Items.s;
            rdb_OnlyInOffer.Checked = true;
            lng.s_OnlyInOffer.Text(this.rdb_OnlyInOffer);
            lng.s_AllItems.Text(this.rdb_All);
            lng.s_OnlyNotInOffer.Text(this.rdb_OnlyNotInOffer);
            if (nav==null)
            {
                nav = new NavigationButtons.Navigation(null);
                nav.m_eButtons = NavigationButtons.Navigation.eButtons.OkCancel;
                nav.eExitResult = NavigationButtons.Navigation.eEvent.NOTHING;
                usrc_NavigationButtons1.Init(nav);
            }

        }

        private bool Init()
        {
            string selection = @" Item_$$UniqueName,
                                  Item_$$Name,
                                  Item_$$Description,
                                  Item_$_ipg1_$$Name,
                                  Item_$_ipg1_$_ipg2_$$Name,
                                  Item_$_ipg1_$_ipg2_$_ipg3_$$Name,
                                  Item_$_iimg_$$Image_Data,
                                  Item_$$ToOffer,
                                  Item_$$barcode,
                                  Item_$_exp_$$ExpectedShelfLifeInDays,
                                  Item_$_exp_$$SaleBeforeExpiryDateInDays,
                                  Item_$_exp_$$DiscardBeforeExpiryDateInDays,
                                  Item_$_exp_$$ExpiryDescription,
                                  Item_$_wrty_$$WarrantyDuration,
                                  Item_$_wrty_$$WarrantyDurationType,
                                  Item_$_wrty_$$WarrantyConditions,
                                  Item_$_u_$$Name,
                                  Item_$_u_$$Symbol,
                                  Item_$_u_$$DecimalPlaces,
                                  ID
                                  
            ";
            string sWhereCondition = "";
            switch (ItemEditMode)
            {
                case eItem_EditMode.SELECT_VALID:
                    sWhereCondition = " where  Item_$$ToOffer = 1 ";
                    break;
                case eItem_EditMode.SELECT_UNVALID:
                    sWhereCondition = " where  Item_$$ToOffer = 0 ";
                    break;
            }
            return usrc_EditTable.Init(dbTables, tbl, selection, ColumnOrderBy, false, sWhereCondition, ID, false,nav);

        }
        private void MyOrganisationData_EditForm_Load(object sender, EventArgs e)
        {
            ItemEditMode = eItem_EditMode.SELECT_VALID;
            rdb_OnlyInOffer.Checked = true;
            if (Init())
            {
                rdb_All.CheckedChanged +=rdb_All_CheckedChanged;
                rdb_OnlyNotInOffer.CheckedChanged +=rdb_OnlyNotInOffer_CheckedChanged;
                rdb_OnlyInOffer.CheckedChanged +=rdb_OnlyInOffer_CheckedChanged;
                List_of_Inserted_Items_ID = new List<ID>();
            }
            else
            {
                Close();
                DialogResult = DialogResult.Abort;
            }
        }


        private void do_OK()
        {
            if (usrc_EditTable.Changed)
            {
                if (MessageBox.Show(lng.s_DataChangedSaveYourData.s, "?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    Transaction transaction_Form_ShopC_Item_Edit_do_OK_usrc_EditTable_Save = new Transaction("Form_ShopC_Item_Edit.do_OK.usrc_EditTable.Save");
                    if (usrc_EditTable.Save(transaction_Form_ShopC_Item_Edit_do_OK_usrc_EditTable_Save))
                    {
                        transaction_Form_ShopC_Item_Edit_do_OK_usrc_EditTable_Save.Commit();
                    }
                    else
                    {
                        transaction_Form_ShopC_Item_Edit_do_OK_usrc_EditTable_Save.Rollback();
                        this.Close();
                        DialogResult = DialogResult.Abort;
                        return;
                    }
                }
            }
            SetUnderlayingItem();
            this.Close();
            DialogResult = DialogResult.Yes;
        }

        private void SetUnderlayingItem()
        {
            if (m_usrc_StockEditForSelectedStockTake != null)
            {
                object oItem_UniqueName = usrc_EditTable.tbl.Value("Item_$$UniqueName");
                object oItem_Unit_Symbol = usrc_EditTable.tbl.Value("Item_$_u_$$Symbol");
                object oItem_Unit_Name = usrc_EditTable.tbl.Value("Item_$_u_$$Name");
                object oItem_Unit_DecimalPlaces = usrc_EditTable.tbl.Value("Item_$_u_$$DecimalPlaces");
                if (oItem_UniqueName is TangentaTableClass.UniqueName)
                {
                    if (((TangentaTableClass.UniqueName)oItem_UniqueName).defined)
                    {
                        string sUniqueName = ((TangentaTableClass.UniqueName)oItem_UniqueName).val;
                        string sUnitName = ((TangentaTableClass.Name)oItem_Unit_Name).val;
                        string sUnitSymbol = ((TangentaTableClass.Symbol)oItem_Unit_Symbol).val;
                        short uDecimalPlaces = ((TangentaTableClass.DecimalPlaces)oItem_Unit_DecimalPlaces).val;
                        m_usrc_StockEditForSelectedStockTake.SetItem(usrc_EditTable.Identity, sUniqueName, sUnitSymbol, uDecimalPlaces);
                    }
                }
            }
       }

        private void do_Cancel()
        {
            if (usrc_EditTable.Changed)
            {
                if (MessageBox.Show(this,lng.s_DataChangedDoYouWantToCloseYesNo.s, "?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
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

        private void usrc_EditTable_after_InsertInDataBase(SQLTable m_tbl, ID ID, bool bRes)
        {
            if (bRes)
            {
                List_of_Inserted_Items_ID.Add(ID);
                m_bChanged = true;
            }
        }

        private void Item_EditForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DataTable dt_ShopC_Item_NotIn_PriceList = new DataTable();
            bShopC_Item_NotIn_PriceList = f_PriceList.Check_All_ShopC_Items_In_PriceList(ref dt_ShopC_Item_NotIn_PriceList);
            if (bShopC_Item_NotIn_PriceList)
            {
                if (dt_ShopC_Item_NotIn_PriceList.Rows.Count > 0)
                {
                    if (PriseLists.usrc_PriceList.Ask_To_Update('C', dt_ShopC_Item_NotIn_PriceList, this))
                    {
                        Transaction transaction_Form_ShopC_Item_Edit_f_PriceList_Insert_ShopC_Items_in_PriceList = new Transaction("Form_ShopC_Item_Edit.f_PriceList.Insert_ShopC_Items_in_PriceList");
                        if (f_PriceList.Insert_ShopC_Items_in_PriceList(dt_ShopC_Item_NotIn_PriceList, this, transaction_Form_ShopC_Item_Edit_f_PriceList_Insert_ShopC_Items_in_PriceList))
                        {
                            transaction_Form_ShopC_Item_Edit_f_PriceList_Insert_ShopC_Items_in_PriceList.Commit();
                        }
                        else
                        {
                            transaction_Form_ShopC_Item_Edit_f_PriceList_Insert_ShopC_Items_in_PriceList.Rollback();
                        }
                    }
                }
            }
        }


        private void rdb_OnlyInOffer_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_OnlyInOffer.Checked)
            {
                ItemEditMode = eItem_EditMode.SELECT_VALID;
                Init();
            }
        }

        private void rdb_OnlyNotInOffer_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_OnlyNotInOffer.Checked)
            {
                ItemEditMode = eItem_EditMode.SELECT_UNVALID;
                Init();
            }
        }

        private void rdb_All_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_All.Checked)
            {
                ItemEditMode = eItem_EditMode.SELECT_ALL;
                Init();
            }
        }


        private void usrc_EditTable_after_UpdateDataBase(SQLTable m_tbl, ID ID, bool bRes)
        {
            m_bChanged = true;
        }

        private bool usrc_EditTable_RowReferenceFromTable_Check_NoChangeToOther(CodeTables.SQLTable pSQL_Table, System.Collections.Generic.List<CodeTables.usrc_RowReferencedFromTable> usrc_RowReferencedFromTable_List, ID id, ref bool bCancelDialog, ref ltext Instruction)
        {
            bCancelDialog = true;
            if (pSQL_Table.TableName.Equals("Item"))
            {
                
                return false;
            }
            else
            {
                return true;
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

        private void usrc_EditTable_SelectedIndexChanged(SQLTable m_tbl, ID ID, int index)
        {
            if (m_usrc_StockEditForSelectedStockTake!=null)
            {
                SetUnderlayingItem();
                m_usrc_StockEditForSelectedStockTake.Selected_Item_Index_Changed(m_tbl, ID, index);
            }
        }

        private void Form_ShopC_Item_Edit_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (m_usrc_StockEditForSelectedStockTake!=null)
            {
                m_usrc_StockEditForSelectedStockTake.edt_Item_dlg = null;
            }
        }

        private void Form_ShopC_Item_Edit_KeyUp(object sender, KeyEventArgs e)
        {
            this.usrc_EditTable.KeyPressed(e.KeyCode);
        }
    }
}
