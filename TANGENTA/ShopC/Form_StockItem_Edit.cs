﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LanguageControl;
using SQLTableControl;
using DBTypes;
using InvoiceDB;

namespace ShopC
{
    public partial class Form_StockItem_Edit : Form
    {
        DataTable dt_Stock = new DataTable();
        SQLTableControl.DBTableControl dbTables = null;
        SQLTable tbl = null;
        bool bclose = false;
        bool bInitData = false;
        InvoiceDB.Item_Data m_Item_Data = null;
        long_v PurchasePrice_Item_ID = null;
        private bool m_bChanged = false;

        public Form_StockItem_Edit(SQLTableControl.DBTableControl xdbTables, SQLTable xtbl,string where_condition, string ColumnToOrderBy,InvoiceDB.Item_Data x_Item_Data)
        {
            InitializeComponent();
            m_Item_Data = x_Item_Data;
            lngRPM.s_lbl_Item_Stock.Text(lbl_Item_Stock);
            this.lbl_Item.Text = m_Item_Data.Item_UniqueName.v;
            dbTables = xdbTables;
            tbl = xtbl;
            this.Text = lngRPM.s_Stock.s;
            string selection = @"Stock_$_ppi_$_i_$$UniqueName,Stock_$$dQuantity,Stock_$$ExpiryDate, Stock_$_ppi_$_pp_$$PurchasePricePerUnit,Stock_$$ImportTime,Stock_$_ppi_$_i_$$Description,Stock_$_ppi_$_pp_$_sup_$_org_$$Name,Stock_$_ppi_$_i_$$Code,Stock_$_ppi_$_i_$_u_$$Name,Stock_$_ppi_$_i_$_u_$$Symbol,Stock_$_ppi_$_i_$_u_$$DecimalPlaces,Stock_$_ppi_$_i_$_u_$$StorageOption,Stock_$_ppi_$_i_$_exp_$$ExpectedShelfLifeInDays,Stock_$_ppi_$_i_$_exp_$$SaleBeforeExpiryDateInDays,Stock_$_ppi_$_i_$_exp_$$DiscardBeforeExpiryDateInDays,Stock_$_ppi_$_i_$_wrty_$$WarrantyDuration, Stock_$_ppi_$_i_$_wrty_$$WarrantyDurationType,Stock_$_ppi_$_i_$_wrty_$$WarrantyConditions,Stock_$_ppi_$_i_$_iimg_$$Image_Data,ID";
            if (m_usrc_EditTable.Init(dbTables, tbl, selection,ColumnToOrderBy,false,where_condition,null,false))
            {
                if (m_usrc_EditTable.RowsCount==0)
                {
                    if (f_PurchasePrice_Item.GetOneFrom_Item_ID(m_Item_Data.Item_ID.v, ref PurchasePrice_Item_ID))
                    {
                        m_usrc_EditTable.FillInitialData();
                    }
                    else
                    {
                        bclose = true;
                        return;
                    }
                }
                m_usrc_EditTable.CallBackSetInputControlProperties(m_Item_Data.Unit_DecimalPlaces.v);
            }
            else
            {
                bclose = true;
            }
        }

        private void Stock_EditForm_Load(object sender, EventArgs e)
        {
            if (bclose)
            {
                Close();
                DialogResult = DialogResult.Abort;
            }
        }

        private void m_usrc_EditTable_FillTable(SQLTable m_tbl)
        {
            if (PurchasePrice_Item_ID!=null)
            {
                if (m_tbl.TableName.ToLower().Equals("purchaseprice_item"))
                {
                    string Err = null;
                    m_tbl.FillDataInputControl(DBSync.DBSync.DB_for_Blagajna.m_DBTables.m_con, PurchasePrice_Item_ID.v, true,ref Err);
                }
            }
            else if (m_tbl.TableName.ToLower().Equals("item"))
            {
                string Err = null;
                m_tbl.FillDataInputControl(DBSync.DBSync.DB_for_Blagajna.m_DBTables.m_con, m_Item_Data.Item_ID.v,true, ref Err);
            }
        }

        private void m_usrc_EditTable_after_New(SQLTable m_tbl, bool bRes)
        {
            PurchasePrice_Item_ID = null;
            if (f_PurchasePrice_Item.GetOneFrom_Item_ID(m_Item_Data.Item_ID.v, ref PurchasePrice_Item_ID))
            {
                m_usrc_EditTable.FillInitialData();
                m_usrc_EditTable.CallBackSetInputControlProperties(m_Item_Data.Unit_DecimalPlaces.v);
            }

        }

        private void Form_ItemStock_Edit_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (m_usrc_EditTable.Changed)
            {
                if (XMessage.Box.Show(this, lngRPM.s_YouHaveEnteredOrChangedDataButNotSavedThem_Save_YesNo, "", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    m_usrc_EditTable.Save();
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

        private void m_usrc_EditTable_after_InsertInDataBase(SQLTable m_tbl, long ID, bool bRes)
        {
            if (bRes)
            {
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
                                if (col.obj is DB_decimal2)
                                {
                                    dq = ((DB_decimal2)col.obj).val;
                                }
                            }
                        }
                    }
                    long_v JOURNAL_Stock_id = null;
                    f_JOURNAL_Stock.Get(ID, f_JOURNAL_Stock.JOURNAL_Stock_Type_ID_new_stock_data, EventTime, dq, ref JOURNAL_Stock_id);
                }
            }
            m_bChanged = true;
        }

        private void m_usrc_EditTable_after_UpdateDataBase(SQLTable m_tbl, long ID, bool bRes)
        {
            if (bRes)
            {
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
                                if (col.obj is DB_decimal2)
                                {
                                    dq = ((DB_decimal2)col.obj).val;
                                }
                            }
                        }
                    }
                    long_v JOURNAL_Stock_id = null;
                    f_JOURNAL_Stock.Get(ID, f_JOURNAL_Stock.JOURNAL_Stock_Type_ID_stock_data_changed, EventTime, dq, ref JOURNAL_Stock_id);
                }
            }
            m_bChanged = true;
        }

        public bool Changed
        {
            get { return m_bChanged; } 
        }

        private bool m_usrc_EditTable_RowReferenceFromTable_Check_NoChangeToOther(SQLTable pSQL_Table, List<usrc_RowReferencedFromTable> usrc_RowReferencedFromTable_List, SQLTableControl.ID_v id_v, ref bool bCancelDialog, ref ltext Instruction)
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