﻿#region LICENSE 
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
using UniqueControlNames;
using DBConnectionControl40;

namespace ShopC_Forms
{
    public partial class Form_StockItem_Edit : Form
    {
        UniqueControlName uctrln = new UniqueControlName();
        DataTable dt_Stock = new DataTable();
        CodeTables.DBTableControl dbTables = null;
        SQLTable tbl = null;
       
        TangentaDB.Item_Data m_Item_Data = null;
        ID PurchasePrice_Item_ID = null;
        private bool m_bChanged = false;
        NavigationButtons.Navigation nav = null;
        string where_condition = null;
        string ColumnToOrderBy = null;
        private ID m_Atom_WorkPeriod_ID = null;

        public Form_StockItem_Edit(ID xAtom_WorkPeriod_ID,CodeTables.DBTableControl xdbTables, SQLTable xtbl,string xwhere_condition, string xColumnToOrderBy,TangentaDB.Item_Data x_Item_Data, NavigationButtons.Navigation xnav)
        {
            InitializeComponent();
            m_Atom_WorkPeriod_ID = xAtom_WorkPeriod_ID;
            nav = xnav;
            m_Item_Data = x_Item_Data;
            lng.s_lbl_Item_Stock.Text(lbl_Item_Stock);
            this.lbl_Item.Text = m_Item_Data.Item_UniqueName_v.v;
            dbTables = xdbTables;
            tbl = xtbl;
            where_condition = xwhere_condition;
            ColumnToOrderBy = xColumnToOrderBy;
            this.Text = lng.s_Stock.s;
        }

        private void Stock_EditForm_Load(object sender, EventArgs e)
        {
            if (!Init())
            {
                Close();
                DialogResult = DialogResult.Abort;
            }
        }

        internal bool Init()
        {
            string selection = @"Stock_$_ppi_$_i_$$UniqueName,Stock_$$dQuantity,Stock_$$ExpiryDate, Stock_$_ppi_$_pp_$$PurchasePricePerUnit,Stock_$$ImportTime,Stock_$_ppi_$_i_$$Description,Stock_$_ppi_$_st_$_sup_$_c_$_orgd_$_org_$$Name,Stock_$_ppi_$_i_$$Code,Stock_$_ppi_$_i_$_u_$$Name,Stock_$_ppi_$_i_$_u_$$Symbol,Stock_$_ppi_$_i_$_u_$$DecimalPlaces,Stock_$_ppi_$_i_$_u_$$StorageOption,Stock_$_ppi_$_i_$_exp_$$ExpectedShelfLifeInDays,Stock_$_ppi_$_i_$_exp_$$SaleBeforeExpiryDateInDays,Stock_$_ppi_$_i_$_exp_$$DiscardBeforeExpiryDateInDays,Stock_$_ppi_$_i_$_wrty_$$WarrantyDuration, Stock_$_ppi_$_i_$_wrty_$$WarrantyDurationType,Stock_$_ppi_$_i_$_wrty_$$WarrantyConditions,Stock_$_ppi_$_i_$_iimg_$$Image_Data,ID";
            if (m_usrc_EditTable.Init(dbTables, DBSync.DBSync.MyTransactionLog_delegates, tbl, selection, ColumnToOrderBy, false, where_condition, null, false, nav))
            {
                if (m_usrc_EditTable.RowsCount == 0)
                {
                    if (f_PurchasePrice_Item.GetOneFrom_Item_ID(m_Item_Data.Item_ID, ref PurchasePrice_Item_ID))
                    {
                        m_usrc_EditTable.FillInitialData();
                    }
                    else
                    {
                        return false; 
                    }
                }
                m_usrc_EditTable.CallBackSetInputControlProperties(m_Item_Data.Unit_DecimalPlaces_v.v);
                return true;
            }
            else
            {
                return false; 
            }
        }
        private void m_usrc_EditTable_FillTable(SQLTable m_tbl)
        {
            if (ID.Validate(PurchasePrice_Item_ID))
            {
                if (m_tbl.TableName.ToLower().Equals("purchaseprice_item"))
                {
                    string Err = null;
                    m_tbl.FillDataInputControl(DBSync.DBSync.Con,uctrln, PurchasePrice_Item_ID, true,ref Err);
                }
            }
            else if (m_tbl.TableName.ToLower().Equals("item"))
            {
                string Err = null;
                m_tbl.FillDataInputControl(DBSync.DBSync.Con, uctrln, m_Item_Data.Item_ID,true, ref Err);
            }
        }

        private void m_usrc_EditTable_after_New(SQLTable m_tbl, bool bRes)
        {
            PurchasePrice_Item_ID = null;
            if (f_PurchasePrice_Item.GetOneFrom_Item_ID(m_Item_Data.Item_ID, ref PurchasePrice_Item_ID))
            {
                m_usrc_EditTable.FillInitialDataAndSetInputControls(m_Item_Data.Unit_DecimalPlaces_v.v);
            }

        }

        private void Form_ItemStock_Edit_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (m_usrc_EditTable.Changed)
            {
                if (XMessage.Box.Show(this, lng.s_YouHaveEnteredOrChangedDataButNotSavedThem_Save_YesNo, "", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    Transaction transaction_Form_ItemStock_Edit_FormClosing_m_usrc_EditTable_Save = DBSync.DBSync.NewTransaction("Form_ItemStock_Edit_FormClosing.m_usrc_EditTable.Save");
                    if (m_usrc_EditTable.Save(ref transaction_Form_ItemStock_Edit_FormClosing_m_usrc_EditTable_Save))
                    {
                        transaction_Form_ItemStock_Edit_FormClosing_m_usrc_EditTable_Save.Commit();
                    }
                    else
                    {
                        transaction_Form_ItemStock_Edit_FormClosing_m_usrc_EditTable_Save.Rollback();
                    }
                }
            }
        }

        private void m_usrc_EditTable_SetInputControlProperties(Column col, object obj)
        {
            if (col.Name.Equals("dQuantity"))
            {
                if (col.ownerTable.TableName.Equals("Stock"))
                {
                    if (obj is int)
                    {
                        col.InputControl.SetNumericUpDown((int)obj);
                    }
                }
            }
        }

        private void m_usrc_EditTable_after_InsertInDataBase(SQLTable m_tbl, ID ID, bool bRes, Transaction transaction)
        {
            if (bRes)
            {
                if (transaction!=null)
                {
                    if (!transaction.Commit())
                    {
                        return;
                    }
                }
                if (m_tbl.TableName.Equals("Stock"))
                {
                    DateTime EventTime = DateTime.Now;
                    decimal dq = -1;
                    foreach (Column col in m_tbl.Column)
                    {
                        if (col.Name.Equals("dQuantity"))
                        {
                            if (col.obj != null)
                            {
                                if (col.obj is DB_decimal)
                                {
                                    dq = ((DB_decimal)col.obj).val;
                                }
                            }
                        }
                    }
                    ID JOURNAL_Stock_id = null;
                    Transaction transaction_f_JOURNAL_Stock_Get = DBSync.DBSync.NewTransaction("f_JOURNAL_Stock_Get");
                    if (f_JOURNAL_Stock.Get(m_Atom_WorkPeriod_ID,ID, f_JOURNAL_Stock.JOURNAL_Stock_Type_ID_new_stock_data, EventTime, dq, ref JOURNAL_Stock_id, transaction_f_JOURNAL_Stock_Get))
                    {
                        transaction_f_JOURNAL_Stock_Get.Commit();
                    }
                    else
                    {
                        transaction_f_JOURNAL_Stock_Get.Rollback();
                    }
                }
                m_bChanged = true;
            }
            else
            {
                if (transaction!=null)
                {
                    transaction.Rollback();
                }
            }
            
        }

        private void m_usrc_EditTable_after_UpdateDataBase(SQLTable m_tbl, ID ID, bool bRes,Transaction transaction)
        {
            if (bRes)
            {
                if (transaction != null)
                {
                    if (!transaction.Commit())
                    {
                        return;
                    }
                }
                if (m_tbl.TableName.Equals("Stock"))
                {
                    DateTime EventTime = DateTime.Now;
                    decimal dq = -1;
                    foreach (Column col in m_tbl.Column)
                    {
                        if (col.Name.Equals("dQuantity"))
                        {
                            if (col.obj != null)
                            {
                                if (col.obj is DB_decimal)
                                {
                                    dq = ((DB_decimal)col.obj).val;
                                }
                            }
                        }
                    }
                    ID JOURNAL_Stock_id = null;
                    Transaction transaction_f_JOURNAL_Stock_Get = DBSync.DBSync.NewTransaction("f_JOURNAL_Stock_Get");
                    if (f_JOURNAL_Stock.Get(m_Atom_WorkPeriod_ID,ID, f_JOURNAL_Stock.JOURNAL_Stock_Type_ID_stock_data_changed, EventTime, dq, ref JOURNAL_Stock_id, transaction_f_JOURNAL_Stock_Get))
                    {
                        transaction_f_JOURNAL_Stock_Get.Commit();
                    }
                    else
                    {
                        transaction_f_JOURNAL_Stock_Get.Rollback();
                    }
                }
                m_bChanged = true;
            }
            else
            {
                if (transaction != null)
                {
                    if (!transaction.Rollback())
                    {
                        return;
                    }
                }
            }
        }

        public bool Changed
        {
            get { return m_bChanged; } 
        }

        private bool m_usrc_EditTable_RowReferenceFromTable_Check_NoChangeToOther(SQLTable pSQL_Table, List<usrc_RowReferencedFromTable> usrc_RowReferencedFromTable_List, ID id, ref bool bCancelDialog, ref ltext Instruction)
        {
            bCancelDialog = true;
            if (pSQL_Table.TableName.Equals("Stock"))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}