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
using TangentaTableClass;
using TangentaDB;
using DBConnectionControl40;

namespace ShopC
{
    public partial class Form_Stock_Edit : Form
    {
        ID m_Atom_WorkPeriod_ID = null;
        DataTable dt_Stock = new DataTable();
        CodeTables.DBTableControl dbTables = null;
        SQLTable tbl = null;
        bool m_bChanged = false;
        NavigationButtons.Navigation nav = null;
        string ColumnToOrderBy = null;

        public bool Changed
        {
            get { return m_bChanged; }
        }

        public Form_Stock_Edit(ID xAtom_WorkPeriod_ID,CodeTables.DBTableControl xdbTables, SQLTable xtbl,string xColumnToOrderBy, NavigationButtons.Navigation xnav)
        {
            InitializeComponent();
            m_Atom_WorkPeriod_ID = xAtom_WorkPeriod_ID;
            nav = xnav;
            dbTables = xdbTables;
            tbl = xtbl;
            ColumnToOrderBy = xColumnToOrderBy;
            this.Text = lng.s_Stock.s;

        }


        private void Stock_EditForm_Load(object sender, EventArgs e)
        {
            string selection = @"Stock_$_ppi_$_i_$$UniqueName,Stock_$$dQuantity,Stock_$$ExpiryDate,Stock_$_ppi_$_pp_$$PurchasePricePerUnit,Stock_$_ppi_$_i_$$Description,Stock_$_ppi_$_st_$_sup_$_c_$_orgd_$_org_$$Name,Stock_$_ppi_$_i_$$Code,Stock_$_ppi_$_i_$_u_$$Name,Stock_$_ppi_$_i_$_u_$$Symbol,Stock_$_ppi_$_i_$_u_$$DecimalPlaces,Stock_$_ppi_$_i_$_u_$$StorageOption,Stock_$_ppi_$_i_$_exp_$$ExpectedShelfLifeInDays,Stock_$_ppi_$_i_$_exp_$$SaleBeforeExpiryDateInDays,Stock_$_ppi_$_i_$_exp_$$DiscardBeforeExpiryDateInDays,Stock_$_ppi_$_i_$_wrty_$$WarrantyDuration, Stock_$_ppi_$_i_$_wrty_$$WarrantyDurationType,Stock_$_ppi_$_i_$_wrty_$$WarrantyConditions,Stock_$_ppi_$_i_$_iimg_$$Image_Data,ID";
            this.Cursor = Cursors.WaitCursor;
            if (!usrc_EditTable.Init(dbTables, tbl, selection, ColumnToOrderBy, false, null, null, false, nav))
            {
                Close();
                DialogResult = DialogResult.Abort;
            }
            this.Cursor = Cursors.Arrow;
        }

        private void usrc_EditTable_after_InsertInDataBase(SQLTable m_tbl, ID ID, bool bRes)
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
                                if (col.obj is DB_decimal)
                                {
                                    dq = ((DB_decimal)col.obj).val;
                                }
                            }
                        }
                    }
                    ID JOURNAL_Stock_id = null;
                    f_JOURNAL_Stock.Get(m_Atom_WorkPeriod_ID,ID, f_JOURNAL_Stock.JOURNAL_Stock_Type_ID_new_stock_data, EventTime, dq, ref JOURNAL_Stock_id);
                }
            }
            m_bChanged = true;
        }

        private void usrc_EditTable_after_UpdateDataBase(SQLTable m_tbl, ID ID, bool bRes)
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
                                if (col.obj is DB_decimal)
                                {
                                    dq = ((DB_decimal)col.obj).val;
                                }
                            }
                        }
                    }
                    ID JOURNAL_Stock_id = null;
                    f_JOURNAL_Stock.Get(m_Atom_WorkPeriod_ID,ID, f_JOURNAL_Stock.JOURNAL_Stock_Type_ID_stock_data_changed, EventTime, dq, ref JOURNAL_Stock_id);
                }
            }
            m_bChanged = true;
        }

        private void usrc_EditTable_SetInputControlProperties(Column col,object obj)
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

        private void usrc_EditTable_after_FillDataInputControl(SQLTable m_tbl, ID ID)
        {
            int decimal_places = -1;
            if (GetDecimalPlaces_ForStockItem(m_tbl, ref decimal_places))
            {
                usrc_EditTable.CallBackSetInputControlProperties(decimal_places);
            }
        }

        private bool GetDecimalPlaces_ForStockItem(SQLTable m_tbl, ref int decimal_places)
        {
            if (m_tbl.TableName.Equals("Stock"))
            {
                foreach(Column col in m_tbl.Column)
                {
                    if (col.fKey!=null)
                    {
                        if (col.fKey.fTable!=null)
                        {
                            if (col.fKey.fTable.TableName.Equals("PurchasePrice_Item"))
                            {
                                foreach (Column col2 in col.fKey.fTable.Column)
                                {
                                    if (col2.fKey != null)
                                    {
                                        if (col2.fKey.fTable != null)
                                        {
                                            if (col2.fKey.fTable.TableName.Equals("Item"))
                                            {
                                                foreach (Column col3 in col2.fKey.fTable.Column)
                                                {
                                                    if (col3.fKey != null)
                                                    {
                                                        if (col3.fKey.fTable != null)
                                                        {
                                                            if (col3.fKey.fTable.TableName.Equals("Unit"))
                                                            {

                                                                foreach (Column col4 in col3.fKey.fTable.Column)
                                                                {
                                                                    if (col4.fKey == null)
                                                                    {
                                                                        if (col4.Name.Equals("DecimalPlaces"))
                                                                        {
                                                                            if (col4.obj is DecimalPlaces)
                                                                            {
                                                                                decimal_places = ((DecimalPlaces)col4.obj).val;
                                                                                return true;
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                LogFile.Error.Show("ERROR:Stock_EditForm:GetDecimalPlaces_ForStockItem:DecimalPlaces not found");
                return false;
            }
            else
            {
                LogFile.Error.Show("ERROR:Stock_EditForm:GetDecimalPlaces_ForStockItem:!m_tbl.TableName.Equals('Stock')");
                return false;
            }
        }

        private bool usrc_EditTable_RowReferenceFromTable_Check_NoChangeToOther(SQLTable pSQL_Table, List<usrc_RowReferencedFromTable> usrc_RowReferencedFromTable_List, ID id, ref bool bCancelDialog, ref ltext Instruction)
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
