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
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using CodeTables;
using TangentaTableClass;
using LanguageControl;
using DBConnectionControl40;
using TangentaDB;
using Form_Discount;
using PriseLists;
using DBTypes;

namespace ShopB
{
    public partial class usrc_ShopB1366x768 : UserControl
    {
        public enum eMode { VIEW,EDIT};

        public delegate bool delegate_CheckAccessPriceList();
        public event delegate_CheckAccessPriceList CheckAccessPriceList = null;

        private DataGridViewTextBoxColumn col_Discount = null;
        private DataGridViewTextBoxColumn dgv_total_discount_column = null;

        private int idgv_ShopB_Items_Width_default = -1;
        ID m_PriceList_id = null;
        DataTable dt_Group = new DataTable();
        DataTable dt_ShopBItem = new DataTable();
        DataTable dt_Price_ShopBItem_Group = new DataTable();
        public enum eLayout {NONE,DRAFT,VIEW }
        private  new eLayout Layout = eLayout.NONE;

        DataTable dt_Price_ShopBItem = new DataTable();

        public DataTable dt_SelectedShopBItem = new DataTable();

        TangentaDB.ShopABC m_InvoiceDB = null;
        DBTablesAndColumnNames DBtcn = null;


        private string m_DocTyp = "";

        public string DocTyp
        {
            get { return m_DocTyp; }
            set
            {
                m_DocTyp = value;
            }
        }
        public bool IsDocInvoice
        {
            get
            { return DocTyp.Equals(GlobalData.const_DocInvoice); }
        }

        public bool IsDocProformaInvoice
        {
            get
            { return DocTyp.Equals(GlobalData.const_DocProformaInvoice); }
        }

        public int NumberOfGroupLevels
        {
            get
            {
                if (m_usrc_Item_Group_Handler!=null)
                {
                    return m_usrc_Item_Group_Handler.NumberOfGroupLevels;
                }
                else
                {
                    return 0;
                }
            }
        }

        public usrc_ShopB1366x768()
        {
            InitializeComponent();
            idgv_ShopB_Items_Width_default = this.dgv_ShopB_Items.Width;
        }

        public delegate void delegate_ItemUpdated(ID ID,DataTable dt_SelectedShopBItem);
        public event delegate_ItemUpdated aa_ItemUpdated = null;

        public delegate void delegate_ItemAdded(ID ID,DataTable dt_SelectedShopBItem);
        public event delegate_ItemAdded aa_ItemAdded = null;

        public delegate void delegate_ItemRemoved(ID ID, DataTable dt_SelectedShopBItem);
        public event delegate_ItemRemoved aa_ItemRemoved = null;

        public delegate void delegate_ExtraDiscount(ID ID, DataTable dt_SelectedShopBItem);
        public event delegate_ExtraDiscount aa_ExtraDiscount = null;


        public void SetColor()
        {
            this.BackColor = Colors.ShopB.BackColor;
            this.ForeColor = Colors.ShopB.ForeColor;
        }

        public void Init(ShopABC x_InvoiceDB, DBTablesAndColumnNames xDBtcn, string shops_in_use)
        {
            lng.s_ShopB_Name.Text(lbl_ShopB_Name);

            Layout = eLayout.NONE;
            m_InvoiceDB = x_InvoiceDB;
            DBtcn = xDBtcn;
            dt_Price_ShopBItem_Group.Clear();
            dt_Price_ShopBItem_Group.Columns.Clear();

            dgv_SelectedShopB_Items.DataSource = null;
            dgv_SelectedShopB_Items.Rows.Clear();
            dgv_SelectedShopB_Items.Columns.Clear();
            dgv_ShopB_Items.DataSource = null;
            dgv_ShopB_Items.Rows.Clear();
            dgv_ShopB_Items.Columns.Clear();

            dt_SelectedShopBItem.Clear();
            dt_SelectedShopBItem.Columns.Clear();

            col_Discount = null;
            dgv_total_discount_column = null;

            if (DBtcn == null)
            {
                LogFile.Error.Show("ERROR:usrc_ShopB:Init:DBtcn == null!");
                DBtcn = new DBTablesAndColumnNames();
            }
            //dt_SelectedShopBItem.Columns.Add(DBtcn.column_SelectedShopBItem_dt_ShopBItem_Index, DBtcn.column_SelectedShopBItem_dt_ShopBItem_Index_TYPE);

            dt_SelectedShopBItem.Columns.Add(DBtcn.column_Selected_Atom_Price_ShopBItem_ID, DBtcn.column_Selected_Atom_Price_ShopBItem_ID_TYPE);
            dt_SelectedShopBItem.Columns.Add(DBtcn.column_SelectedShopBItemName, DBtcn.column_SelectedShopBItemName_TYPE);
            dt_SelectedShopBItem.Columns.Add(DBtcn.column_SelectedShopBItemPrice, DBtcn.column_SelectedShopBItemPrice_TYPE);
            dt_SelectedShopBItem.Columns.Add(DBtcn.column_SelectedShopBItemPriceTax, DBtcn.column_SelectedShopBItemPriceTax_TYPE);
            dt_SelectedShopBItem.Columns.Add(DBtcn.column_SelectedShopBItem_TaxName, DBtcn.column_SelectedShopBItem_TaxName_TYPE);
            dt_SelectedShopBItem.Columns.Add(DBtcn.column_SelectedShopBItem_TaxRate, DBtcn.column_SelectedShopBItem_TaxRate_TYPE);
            dt_SelectedShopBItem.Columns.Add(DBtcn.column_SelectedShopBItemPriceWithoutTax, DBtcn.column_SelectedShopBItemPriceWithoutTax_TYPE);
            dt_SelectedShopBItem.Columns.Add(DBtcn.column_SelectedShopBItemPriceDiscount, DBtcn.column_SelectedShopBItemPriceDiscount_TYPE);
            dt_SelectedShopBItem.Columns.Add(DBtcn.column_SelectedShopBItem_ShopBItem_ID, DBtcn.column_SelectedShopBItem_ShopBItem_ID_TYPE);
            dt_SelectedShopBItem.Columns.Add(DBtcn.column_SelectedShopBItemRetailPricePerUnit, DBtcn.column_SelectedShopBItemRetailPricePerUnit_TYPE);
            dt_SelectedShopBItem.Columns.Add(DBtcn.column_SelectedShopBItem_Count, DBtcn.column_SelectedShopBItem_Count_TYPE);
            dt_SelectedShopBItem.Columns.Add(DBtcn.column_SelectedShopBItem_ExtraDiscount, DBtcn.column_SelectedShopBItem_ExtraDiscount_TYPE);
            string Err = null;
            this.m_usrc_Item_Group_Handler.ShopName = lng.s_Shop_B.s;
            SetColor();
       }

        public void SetMode(eMode mode)
        {
            switch (mode)
            {
                case eMode.VIEW:
                    splitContainer2.Panel2Collapsed = true;
                    lbl_GroupPath.Visible = false;
                    break;

                case eMode.EDIT:
                    splitContainer2.Panel2Collapsed = false;
                    lbl_GroupPath.Visible = true;
                    break;
            }

        }

        private int FindRow_in_dt_Price_ShopBItem(ID id)
        {
            int iRes = -1;
            int iRow = 0;
            int iRowCount = dt_Price_ShopBItem.Rows.Count;
            if (iRowCount > 0)
            {
                for (iRow = 0; iRow < iRowCount; iRow++)
                {
                    ID lid = tf.set_ID(dt_Price_ShopBItem.Rows[iRow]["ID"]);
                    if (lid.Equals(id))
                    {
                        return iRow;
                    }
                }
            }
            return iRes;
        }

        private void SetGridButtonCountry(DataGridView dgv, int rowIndex, int columnIndex, PushButtonState pushButtonState)
        {
            if ((rowIndex > -1) && (columnIndex > -1))
            {
                if (dgv.Columns[columnIndex].GetType().Equals(typeof(DataGridViewImageButtonColumn)))
                {
                    DataGridViewImageButtonCell buttonCell =
                        (DataGridViewImageButtonCell)dgv.
                        Rows[rowIndex].Cells[columnIndex];

                    if (buttonCell.Enabled)
                    {
                        buttonCell.ButtonState= pushButtonState;
                    }
                }
            }
        }

        public void SetCurrentInvoice_SelectedShopB_Items()
        {
            m_InvoiceDB.m_CurrentDoc.Set_SelectedShopB_Items(DocTyp,dgv_SelectedShopB_Items, dt_SelectedShopBItem, dgv_ShopB_Items, dt_Price_ShopBItem);
        }



        private void dgv_ShopB_Items_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            SetGridButtonCountry(dgv_ShopB_Items, e.RowIndex, e.ColumnIndex, PushButtonState.Pressed);
        }
        private void dgv_ShopB_Items_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            SetGridButtonCountry(dgv_ShopB_Items, e.RowIndex, e.ColumnIndex, PushButtonState.Hot);
        }

        private void dgv_ShopB_Items_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            SetGridButtonCountry(dgv_ShopB_Items, e.RowIndex, e.ColumnIndex, PushButtonState.Normal);
        }

        private void dgv_ShopB_Items_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            SetGridButtonCountry(dgv_ShopB_Items, e.RowIndex, e.ColumnIndex, PushButtonState.Normal);
            ShopBItemSelect(e.RowIndex);
        }

        private void ShopBItemSelect(int iShopBItemRow)
        {
            // new ShopBItem
            string Err = null;
            if (iShopBItemRow >= 0)
            {
                ID Price_ShopBItem_ID = tf.set_ID(dt_Price_ShopBItem.Rows[iShopBItemRow]["ID"]);

                string PriceList_Name = (string)dt_Price_ShopBItem.Rows[iShopBItemRow]["PriceList_Name"]; 
                string ShopBItem_Name = (string)dt_Price_ShopBItem.Rows[iShopBItemRow][DBtcn.colShopBItemName]; 
                string ShopBItem_Abbreviation = (string)dt_Price_ShopBItem.Rows[iShopBItemRow][DBtcn.colShopBItemAbbreviation];
                string ShopBItem_Taxation_Name = (string)dt_Price_ShopBItem.Rows[iShopBItemRow][DBtcn.colShopBItemTaxation_Name];
                decimal ShopBItem_Taxation_Rate = (decimal)dt_Price_ShopBItem.Rows[iShopBItemRow][DBtcn.colShopBItemTaxation_Rate];
                decimal ShopBItem_RetailShopBItemPrice_WithoutPriceListDiscount = (decimal)dt_Price_ShopBItem.Rows[iShopBItemRow][DBtcn.colPriceShopBItemRetailShopBItemPrice];
                object oDiscount = dt_Price_ShopBItem.Rows[iShopBItemRow]["Discount"];
                decimal Discount = 0;
                decimal ExtraDiscount = 0;

                if (oDiscount is decimal)
                {
                    Discount = (decimal)oDiscount;
                }

                decimal ShopBItem_RetailShopBItemPrice = ShopBItem_RetailShopBItemPrice_WithoutPriceListDiscount - ShopBItem_RetailShopBItemPrice_WithoutPriceListDiscount * Discount;
                string ShopBItem_Image_Image_Hash = null;
                byte[] ShopBItem_Image_Image_Data = null;

                if (dt_Price_ShopBItem.Rows[iShopBItemRow][DBtcn.colShopBItem_ShopBItem_Image_Image_Hash].GetType() == typeof(string))
                {
                    ShopBItem_Image_Image_Hash = (string)dt_Price_ShopBItem.Rows[iShopBItemRow][DBtcn.colShopBItem_ShopBItem_Image_Image_Hash];
                }
                if (dt_Price_ShopBItem.Rows[iShopBItemRow][DBtcn.colShopBItem_ShopBItem_Image_Image_Data].GetType() == typeof(byte[]))
                {
                    ShopBItem_Image_Image_Data = (byte[])dt_Price_ShopBItem.Rows[iShopBItemRow][DBtcn.colShopBItem_ShopBItem_Image_Image_Data];
                }

                int iSelectedShopBItemRow = FindRow_in_dt_SelectedShopBItem(Price_ShopBItem_ID);
                if (iSelectedShopBItemRow >= 0)
                {
                    int iCount = (int)dt_SelectedShopBItem.Rows[iSelectedShopBItemRow][DBtcn.column_SelectedShopBItem_Count];
                    iCount++;
                    decimal RetailPrice_per_unit = (decimal)dt_Price_ShopBItem.Rows[iShopBItemRow][DBtcn.colPriceShopBItemRetailShopBItemPrice];
                    Discount = 0;
                    oDiscount = dt_Price_ShopBItem.Rows[iShopBItemRow]["Discount"]; 
                    if (oDiscount is decimal)
                    {
                        Discount = (decimal)oDiscount;
                    }
                    object oExtraDiscount = dt_SelectedShopBItem.Rows[iSelectedShopBItemRow][DBtcn.column_SelectedShopBItem_ExtraDiscount];

                    if (oExtraDiscount is decimal)
                    {
                        ExtraDiscount = (decimal)oExtraDiscount;
                    }
                    decimal TaxPrice = 0;
                    decimal RetailShopBItemPriceWithDiscount = 0;
                    decimal PriceWithoutTax = 0;
                    string Taxation_Name = (string)dt_Price_ShopBItem.Rows[iShopBItemRow][DBtcn.colShopBItemTaxation_Name];
                    decimal Taxation_Rate = (decimal)dt_Price_ShopBItem.Rows[iShopBItemRow][DBtcn.colShopBItemTaxation_Rate];
                    ID PriceShopBItem_Atom_ShopBItem_ID = tf.set_ID(dt_SelectedShopBItem.Rows[iSelectedShopBItemRow][DBtcn.column_Selected_Atom_Price_ShopBItem_ID]);
                    if (m_InvoiceDB.Update_SelectedSimpleItem(PriceShopBItem_Atom_ShopBItem_ID,
                                                           iCount,
                                                           Discount,
                                                           ExtraDiscount,
                                                           RetailPrice_per_unit,
                                                           Taxation_Name,
                                                           Taxation_Rate,
                                                           ref RetailShopBItemPriceWithDiscount,
                                                           ref TaxPrice,
                                                           ref PriceWithoutTax,
                                                           ref Err))
                    {
                        dt_SelectedShopBItem.Rows[iSelectedShopBItemRow][DBtcn.column_SelectedShopBItem_Count] = iCount;
                        dt_SelectedShopBItem.Rows[iSelectedShopBItemRow][DBtcn.column_SelectedShopBItemPriceWithoutTax] = PriceWithoutTax;
                        dt_SelectedShopBItem.Rows[iSelectedShopBItemRow][DBtcn.column_SelectedShopBItemPriceTax] = TaxPrice;
                        dt_SelectedShopBItem.Rows[iSelectedShopBItemRow][DBtcn.column_SelectedShopBItem_TaxName] = Taxation_Name;
                        dt_SelectedShopBItem.Rows[iSelectedShopBItemRow][DBtcn.column_SelectedShopBItem_TaxRate] = Taxation_Rate;
                        dt_SelectedShopBItem.Rows[iSelectedShopBItemRow][DBtcn.column_SelectedShopBItemPrice] = RetailShopBItemPriceWithDiscount;
                        dgv_SelectedShopB_Items.Rows[iSelectedShopBItemRow].Cells[DBtcn.column_SelectedShopBItem_btn_discount].Value = ExtraDiscount;
                        if (aa_ItemUpdated != null)
                        {
                            aa_ItemUpdated(PriceShopBItem_Atom_ShopBItem_ID,dt_SelectedShopBItem);
                        }
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:usrc_Invoice:ShopBItemSelect:Err=" + Err);
                    }
                }
                else
                {
                    decimal RetailPriceWithDiscount = 0;
                    decimal RetailShopBItemPrice = 0;
                    Discount = 0; 
                    ExtraDiscount = 0;
                    decimal Taxation_Rate = 0;
                    string Taxation_Name = null;
                    decimal Tax = 0;
                    int iCount = 1;
                    ID Atom_Price_ShopBItem_ID = null;
                    decimal PriceWithoutTax = 0;


                    if (f_Atom_Price_ShopBItem.Get(DocTyp,
                                                    Price_ShopBItem_ID,
                                                    m_InvoiceDB.m_CurrentDoc.Doc_ID,
                                                    ref Atom_Price_ShopBItem_ID,
                                                    ref iCount,
                                                    ref RetailShopBItemPrice,
                                                    ref Discount,
                                                    ref ExtraDiscount,
                                                    ref Taxation_Rate,
                                                    ref Taxation_Name,
                                                    ref RetailPriceWithDiscount,
                                                    ref Tax,
                                                    ref PriceWithoutTax
                                                    ))
                    {
                        if (this.m_InvoiceDB.Read_ShopB_Price_Item_Table(m_InvoiceDB.m_CurrentDoc.Doc_ID,ref m_InvoiceDB.m_CurrentDoc.dtCurrent_Atom_Price_ShopBItem))
                        {
                            DataRow dr = dt_SelectedShopBItem.NewRow();
                            dr[DBtcn.column_SelectedShopBItemPriceDiscount] = Discount;
                            dr[DBtcn.column_SelectedShopBItem_ExtraDiscount] = ExtraDiscount;
                            dr[DBtcn.column_Selected_Atom_Price_ShopBItem_ID] = Atom_Price_ShopBItem_ID.V;
                            dr[DBtcn.column_SelectedShopBItem_ShopBItem_ID] = Price_ShopBItem_ID.V;
                            dr[DBtcn.column_SelectedShopBItem_Count] = 1;
                            dr[DBtcn.column_SelectedShopBItemName] = ShopBItem_Name;
                            dr[DBtcn.column_SelectedShopBItemPriceWithoutTax] = PriceWithoutTax;
                            dr[DBtcn.column_SelectedShopBItemPriceTax] = Tax;
                            dr[DBtcn.column_SelectedShopBItem_TaxName] = Taxation_Name;
                            dr[DBtcn.column_SelectedShopBItem_TaxRate] = Taxation_Rate;
                            dr[DBtcn.column_SelectedShopBItemPrice] = RetailPriceWithDiscount;
                            dr[DBtcn.column_SelectedShopBItemRetailPricePerUnit] = RetailShopBItemPrice;
                            dt_SelectedShopBItem.Rows.Add(dr);
                            if (Layout!=eLayout.DRAFT)
                            {
                                SetDraftButtons();
                            }
                            dgv_SelectedShopB_Items.Rows[dt_SelectedShopBItem.Rows.Count-1].Cells[DBtcn.column_SelectedShopBItem_btn_discount].Value = ExtraDiscount;

                            if (aa_ItemAdded != null)
                            {
                                aa_ItemAdded(Atom_Price_ShopBItem_ID,dt_SelectedShopBItem);
                            }

                        }
                    }
                }
                dgv_SelectedShopB_Items.Refresh();
            }
        }


        private void SelectExtraDiscount(int iSelectedShopBItemRow)
        {
            string Err = null;
            ID Atom_ShopBItem_ID = tf.set_ID(dt_SelectedShopBItem.Rows[iSelectedShopBItemRow][DBtcn.column_Selected_Atom_Price_ShopBItem_ID]);
            string ShopBItem_Name = (string)dt_SelectedShopBItem.Rows[iSelectedShopBItemRow][DBtcn.column_SelectedShopBItemName];
            object obj_Discount = dt_SelectedShopBItem.Rows[iSelectedShopBItemRow][DBtcn.column_SelectedShopBItemPriceDiscount];
            decimal Discount = 0;
            if (obj_Discount.GetType() == typeof(decimal))
            {
                Discount = (decimal)obj_Discount;
            }


            decimal RetailPricePerUnit = (decimal)dt_SelectedShopBItem.Rows[iSelectedShopBItemRow][DBtcn.column_SelectedShopBItemRetailPricePerUnit];
            decimal ExtraDiscount = 0;
            if (iSelectedShopBItemRow >= 0)
            {
                ExtraDiscount = (decimal)dt_SelectedShopBItem.Rows[iSelectedShopBItemRow][DBtcn.column_SelectedShopBItem_ExtraDiscount];
            }
            Form_Discount.Form_Discount discount_frm = new Form_Discount.Form_Discount(RetailPricePerUnit, null,ExtraDiscount, ShopBItem_Name);
            if (discount_frm.ShowDialog() == DialogResult.OK)
            {
                ExtraDiscount = discount_frm.ExtraDiscount;
                int iCount = (int)dt_SelectedShopBItem.Rows[iSelectedShopBItemRow][DBtcn.column_SelectedShopBItem_Count];
                long lid = (long)dt_SelectedShopBItem.Rows[iSelectedShopBItemRow][DBtcn.column_SelectedShopBItem_ShopBItem_ID];

                decimal RetailShopBItemPrice = (decimal)dt_SelectedShopBItem.Rows[iSelectedShopBItemRow][DBtcn.column_SelectedShopBItemRetailPricePerUnit];
                decimal TaxPrice = 0;
                decimal RetailShopBItemPriceWithDiscount = 0;
                decimal PriceWithoutTax = 0;
                string Taxation_Name = (string)dt_SelectedShopBItem.Rows[iSelectedShopBItemRow][DBtcn.column_SelectedShopBItem_TaxName];
                decimal Taxation_Rate = (decimal)dt_SelectedShopBItem.Rows[iSelectedShopBItemRow][DBtcn.column_SelectedShopBItem_TaxRate];
                if (m_InvoiceDB.Update_SelectedSimpleItem(Atom_ShopBItem_ID,
                                                        iCount,
                                                        Discount,
                                                        ExtraDiscount,
                                                        RetailShopBItemPrice,
                                                        Taxation_Name,
                                                        Taxation_Rate,
                                                        ref RetailShopBItemPriceWithDiscount,
                                                        ref TaxPrice,
                                                        ref PriceWithoutTax,
                                                        ref Err))
                {
                    dt_SelectedShopBItem.Rows[iSelectedShopBItemRow][DBtcn.column_SelectedShopBItem_Count] = iCount;
                    dt_SelectedShopBItem.Rows[iSelectedShopBItemRow][DBtcn.column_SelectedShopBItemPriceWithoutTax] = PriceWithoutTax;
                    dt_SelectedShopBItem.Rows[iSelectedShopBItemRow][DBtcn.column_SelectedShopBItem_ExtraDiscount] = ExtraDiscount;
                    dt_SelectedShopBItem.Rows[iSelectedShopBItemRow][DBtcn.column_SelectedShopBItemPriceTax] = TaxPrice;
                    dt_SelectedShopBItem.Rows[iSelectedShopBItemRow][DBtcn.column_SelectedShopBItem_TaxName] = Taxation_Name;
                    dt_SelectedShopBItem.Rows[iSelectedShopBItemRow][DBtcn.column_SelectedShopBItem_TaxRate] = Taxation_Rate;
                    dt_SelectedShopBItem.Rows[iSelectedShopBItemRow][DBtcn.column_SelectedShopBItemPrice] = RetailShopBItemPriceWithDiscount;
                    dgv_SelectedShopB_Items.Rows[iSelectedShopBItemRow].Cells["btn_discount"].Value = ExtraDiscount;
                    if (aa_ExtraDiscount != null)
                    {
                        aa_ExtraDiscount(Atom_ShopBItem_ID, dt_SelectedShopBItem);
                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:usrc_Invoice:ShopBItemDeselect:m_InvoiceDB.Update_SelectedShopBItem:Err=" + Err);
                }
            }
        }


        private int FindRow_in_dt_SelectedShopBItem(ID id)
        {
            int iRes = -1;
            int iRow = 0;
            int iRowCount = dt_SelectedShopBItem.Rows.Count;
            if (iRowCount > 0)
            {
                for (iRow = 0; iRow < iRowCount; iRow++)
                {
                    ID lid = tf.set_ID(dt_SelectedShopBItem.Rows[iRow][DBtcn.column_SelectedShopBItem_ShopBItem_ID]);
                    if (lid.Equals(id))
                    {
                        return iRow;
                    }
                }
            }
            return iRes;
        }


        private void dgv_SelectedShopB_Items_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {

            if ((e.ColumnIndex >= 0)&&(e.RowIndex>=0))
            {
                SetGridButtonCountry(dgv_SelectedShopB_Items, e.RowIndex, e.ColumnIndex, PushButtonState.Normal);
                if (dgv_SelectedShopB_Items.Columns[e.ColumnIndex].Name.Equals(DBtcn.column_SelectedShopBItem_btn_deselect))
                {
                    ShopBItemDeselect(e.RowIndex);
                }
                if (dgv_SelectedShopB_Items.Columns[e.ColumnIndex].Name.Equals(DBtcn.column_SelectedShopBItem_btn_discount))
                {
                    SelectExtraDiscount(e.RowIndex);
                }
            }
        }

        private bool GetSelectedShopBItemRowData(ID lid,
                                                int iSelectedShopBItemRow,
                                                ID Atom_Price_ShopBItem_ID,
                                                int iCount,
                                                ref decimal RetailPrice_per_unit,
                                                ref decimal Discount,
                                                ref decimal ExtraDiscount,
                                                ref decimal TaxPrice,
                                                ref decimal RetailShopBItemPriceWithDiscount,
                                                ref decimal PriceWithoutTax,
                                                ref string Taxation_Name,
                                                ref decimal Taxation_Rate)
        {
            string Err = null;
            int iShopBItemRow = FindRow_in_dt_Price_ShopBItem(lid);
            if (iShopBItemRow >= 0)
            {
                RetailPrice_per_unit = (decimal)dt_Price_ShopBItem.Rows[iShopBItemRow][DBtcn.colPriceShopBItemRetailShopBItemPrice];
                Discount = 0;
                if (dt_Price_ShopBItem.Rows[iShopBItemRow]["Discount"] is decimal)
                {
                    Discount = (decimal)dt_Price_ShopBItem.Rows[iShopBItemRow]["Discount"];
                }
                ExtraDiscount = 0;
                if (dt_SelectedShopBItem.Rows[iSelectedShopBItemRow][DBtcn.column_SelectedShopBItem_ExtraDiscount] is decimal)
                {
                    ExtraDiscount = (decimal)dt_SelectedShopBItem.Rows[iSelectedShopBItemRow][DBtcn.column_SelectedShopBItem_ExtraDiscount];
                }
                TaxPrice = 0;
                RetailShopBItemPriceWithDiscount = 0;
                PriceWithoutTax = 0;
                Taxation_Name = (string)dt_Price_ShopBItem.Rows[iShopBItemRow][DBtcn.colShopBItemTaxation_Name];
                Taxation_Rate = (decimal)dt_Price_ShopBItem.Rows[iShopBItemRow][DBtcn.colShopBItemTaxation_Rate];
                return true;
            }
            else
            {
                // Row not found because group changed in between !
                string sql_ShopBItem = @"SELECT 
                                                 Price_SimpleItem.ID,
                                                 Price_SimpleItem.RetailSimpleItemPrice,
                                                 Price_SimpleItem.Discount,
                                                 Taxation.Name AS Taxation_Name,
                                                 Taxation.Rate AS Taxation_Rate,
                                                 SimpleItem.Name
                                                 From Price_SimpleItem
                                                 INNER JOIN PriceList ON  Price_SimpleItem.PriceList_ID = PriceList.ID
                                                 INNER JOIN Taxation ON  Price_SimpleItem.Taxation_ID = Taxation.ID
                                                 INNER JOIN SimpleItem ON  Price_SimpleItem.SimpleItem_ID = SimpleItem.ID
                                                 where Price_SimpleItem.ID = " + lid.ToString();

                DataTable dt = new DataTable();
                if (DBSync.DBSync.ReadDataTable(ref dt, sql_ShopBItem, ref Err))
                {
                    if (dt.Rows.Count > 0)
                    {
                        RetailPrice_per_unit = (decimal)dt.Rows[0]["RetailSimpleItemPrice"];
                        Discount = 0;
                        if (dt.Rows[0]["Discount"] is decimal)
                        {
                            Discount = (decimal)dt.Rows[0]["Discount"];
                        }
                        ExtraDiscount = 0;
                        if (dt_SelectedShopBItem.Rows[iSelectedShopBItemRow][DBtcn.column_SelectedShopBItem_ExtraDiscount] is decimal)
                        {
                            ExtraDiscount = (decimal)dt_SelectedShopBItem.Rows[iSelectedShopBItemRow][DBtcn.column_SelectedShopBItem_ExtraDiscount];
                        }
                        TaxPrice = 0;
                        RetailShopBItemPriceWithDiscount = 0;
                        PriceWithoutTax = 0;
                        Taxation_Name = (string)dt.Rows[0]["Taxation_Name"];
                        Taxation_Rate = (decimal)dt.Rows[0]["Taxation_Rate"];
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:usrc_Invoice:ShopBItemDeselect:ERROR:can not find iShopBItemRow!");
                    }
                }
            }
            return false;
        }

        private void ShopBItemDeselect(int iSelectedShopBItemRow)
        {
            // new ShopBItem
            string Err = null;
            if (iSelectedShopBItemRow >= 0)
            {
                ID Atom_Price_ShopBItem_ID = tf.set_ID(dt_SelectedShopBItem.Rows[iSelectedShopBItemRow][DBtcn.column_Selected_Atom_Price_ShopBItem_ID]);
                int iCount = (int)dt_SelectedShopBItem.Rows[iSelectedShopBItemRow][DBtcn.column_SelectedShopBItem_Count];
                ID lid = tf.set_ID(dt_SelectedShopBItem.Rows[iSelectedShopBItemRow][DBtcn.column_SelectedShopBItem_ShopBItem_ID]);
                if (iCount > 1)
                {
                    iCount--;
                    decimal RetailPrice_per_unit = -1;
                    decimal Discount = 0;
                    decimal ExtraDiscount = 0;
                    decimal TaxPrice = 0;
                    decimal RetailShopBItemPriceWithDiscount = 0;
                    decimal PriceWithoutTax = 0;
                    string Taxation_Name = null;
                    decimal Taxation_Rate = 0;
                    if (GetSelectedShopBItemRowData(lid,
                                                iSelectedShopBItemRow,
                                                Atom_Price_ShopBItem_ID,
                                                iCount,
                                                ref RetailPrice_per_unit,
                                                ref Discount,
                                                ref ExtraDiscount,
                                                ref TaxPrice,
                                                ref RetailShopBItemPriceWithDiscount,
                                                ref PriceWithoutTax,
                                                ref Taxation_Name,
                                                ref Taxation_Rate))
                    {
                        if (m_InvoiceDB.Update_SelectedSimpleItem(Atom_Price_ShopBItem_ID,
                                       iCount,
                                       Discount,
                                       ExtraDiscount,
                                       RetailPrice_per_unit,
                                       Taxation_Name,
                                       Taxation_Rate,
                                       ref RetailShopBItemPriceWithDiscount,
                                       ref TaxPrice,
                                       ref PriceWithoutTax,
                                       ref Err))
                        {
                            dt_SelectedShopBItem.Rows[iSelectedShopBItemRow][DBtcn.column_SelectedShopBItem_Count] = iCount;
                            dt_SelectedShopBItem.Rows[iSelectedShopBItemRow][DBtcn.column_SelectedShopBItemPriceWithoutTax] = PriceWithoutTax;
                            dt_SelectedShopBItem.Rows[iSelectedShopBItemRow][DBtcn.column_SelectedShopBItemPriceTax] = TaxPrice;
                            dt_SelectedShopBItem.Rows[iSelectedShopBItemRow][DBtcn.column_SelectedShopBItem_TaxName] = Taxation_Name;
                            dt_SelectedShopBItem.Rows[iSelectedShopBItemRow][DBtcn.column_SelectedShopBItem_TaxRate] = Taxation_Rate;
                            dt_SelectedShopBItem.Rows[iSelectedShopBItemRow][DBtcn.column_SelectedShopBItemPrice] = RetailShopBItemPriceWithDiscount;
                            dgv_SelectedShopB_Items.Rows[iSelectedShopBItemRow].Cells["btn_discount"].Value = ExtraDiscount;
                        }
                        else
                        {
                            LogFile.Error.Show("ERROR:usrc_Invoice:ShopBItemDeselect:m_InvoiceDB.Update_SelectedShopBItem:Err=" + Err);
                        }
                    }
                }
                else
                {
                    if (m_InvoiceDB.Delete_SelectedSimpleItem(Atom_Price_ShopBItem_ID,
                                                            ref Err))
                    {
                        dt_SelectedShopBItem.Rows.RemoveAt(iSelectedShopBItemRow);
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:usrc_Invoice:ShopBItemDeselect:m_InvoiceDB.Update_SelectedShopBItem:Err=" + Err);
                    }

                }
                dgv_SelectedShopB_Items.Refresh();
                if (this.aa_ItemRemoved != null)
                {
                    aa_ItemRemoved(lid, dt_SelectedShopBItem);
                }

            }
        }

        public void SetDraftButtons()
        {
            if ((Layout == eLayout.VIEW)||(Layout == eLayout.NONE))
            {
                if (Layout == eLayout.VIEW)
                {
                    if (FindColumn(dgv_SelectedShopB_Items, DBtcn.column_total_discount))
                    {
                        this.dgv_SelectedShopB_Items.Columns.Remove(DBtcn.column_total_discount);
                    }
                    dgv_total_discount_column = null;
                }

                DataGridViewImageButtonColumn btn_Discount = null;

                btn_Discount = new DataGridViewImageButtonColumn(DataGridViewImageButtonColumn.eselection.discount);
                btn_Discount.HeaderText = "";
                btn_Discount.Text = "";
                btn_Discount.Name = DBtcn.column_SelectedShopBItem_btn_discount;
                btn_Discount.Width = 32;
                this.dgv_SelectedShopB_Items.Columns.Insert(2, btn_Discount);
                DataGridViewImageButtonColumn btn_Remove = new DataGridViewImageButtonColumn(DataGridViewImageButtonColumn.eselection.deselect);
                btn_Remove.HeaderText = "Odstrani";
                btn_Remove.Text = "-";
                btn_Remove.Name = DBtcn.column_SelectedShopBItem_btn_deselect;
                this.dgv_SelectedShopB_Items.Columns.Insert(0,btn_Remove);
                Layout = eLayout.DRAFT;
            }

        }

        private bool FindColumn(DataGridView dgv, string column_name)
        {
            foreach (DataGridViewColumn dgvcol in dgv.Columns)
            {
                if (dgvcol.Name.Equals(column_name))
                {
                    return true;
                }
            }
            return false;
        }

        public void SetViewButtons()
        {
            if ((Layout == eLayout.DRAFT) || (Layout == eLayout.NONE))
            {
                if (Layout == eLayout.DRAFT)
                {
                    this.dgv_SelectedShopB_Items.Columns.Remove(DBtcn.column_SelectedShopBItem_btn_discount);
                    this.dgv_SelectedShopB_Items.Columns.Remove(DBtcn.column_SelectedShopBItem_btn_deselect);
                }
                if (!FindColumn(dgv_SelectedShopB_Items, DBtcn.column_total_discount))
                {
                    dgv_total_discount_column = null;
                }


                if (dgv_total_discount_column == null)
                {
                    dgv_total_discount_column = new DataGridViewTextBoxColumn();
                    dgv_total_discount_column.Name = DBtcn.column_total_discount;
                    dgv_total_discount_column.HeaderText = lng.s_TotalDiscount.s;
                    this.dgv_SelectedShopB_Items.Columns.Add(dgv_total_discount_column);
                }
                this.dgv_SelectedShopB_Items.Columns[DBtcn.column_SelectedShopBItemPriceDiscount].Visible = true;
                this.dgv_SelectedShopB_Items.Columns[DBtcn.column_SelectedShopBItem_ExtraDiscount].Visible = true;

                this.dgv_SelectedShopB_Items.Columns[DBtcn.column_SelectedShopBItemPriceDiscount].HeaderText = lng.s_PriceListDiscount.s;
                this.dgv_SelectedShopB_Items.Columns[DBtcn.column_SelectedShopBItem_ExtraDiscount].HeaderText = lng.s_ExtraDiscount.s;
                this.dgv_SelectedShopB_Items.Columns[DBtcn.column_total_discount].HeaderText = lng.s_TotalDiscount.s;
                if (col_Discount == null)
                {
                    col_Discount = new DataGridViewTextBoxColumn();
                    col_Discount.HeaderText = lng.s_Discount.s;
                    col_Discount.Name = DBtcn.column_SelectedShopBItem_btn_discount;
                    col_Discount.Width = 32;
                    this.dgv_SelectedShopB_Items.Columns.Insert(4, col_Discount);
                }
                Layout = eLayout.VIEW;
            }
            else
            {
                if (col_Discount != null)
                {
                    int iIndex = this.dgv_SelectedShopB_Items.Columns.IndexOf(col_Discount);
                    if (iIndex >= 0)
                    {
                        this.dgv_SelectedShopB_Items.Columns.RemoveAt(iIndex);
                    }
                    col_Discount = null;
                }
                else
                {
                    foreach (DataGridViewColumn dgvc in this.dgv_SelectedShopB_Items.Columns)
                    {
                        if (dgvc.Name.Equals(DBtcn.column_SelectedShopBItem_btn_discount))
                        {
                            this.dgv_SelectedShopB_Items.Columns.Remove(dgvc);
                            break;
                        }
                    }
                }
            }
            
        }

        public void Set_dgv_SelectedShopB_Items()
        {
            try
            {
                dt_SelectedShopBItem.Rows.Clear();
                dgv_SelectedShopB_Items.DataSource = dt_SelectedShopBItem;
                m_InvoiceDB.Set_dgv_selected_ShopB_Items_Columns(dgv_SelectedShopB_Items);
                
            }
            catch (Exception Ex)
            {
                LogFile.Error.Show("ERROR:Set_dgv_SelectedShopB_Items:Exception=" + Ex.Message);
            }
        }

        public bool GetShopBItemData(ref int iCount)
        {
            SQLTable tbl_ShopBItem = DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(SimpleItem));


            string sql_ShopBItem = @"SELECT 
              SimpleItem.ID,
              SimpleItem.Name AS SimpleItem_Name,
              SimpleItem.Abbreviation AS SimpleItem_Abbreviation,
              SimpleItem_Image.Image_Hash AS SimpleItem_Image_Image_Hash,
              SimpleItem_Image.Image_Data AS SimpleItem_Image_Image_Data,
              SimpleItem.Code AS SimpleItem_Code,
              SimpleItem.ToOffer AS SimpleItem_ToOffer
             From SimpleItem 
                LEFT JOIN SimpleItem_Image ON SimpleItem.SimpleItem_Image_ID = SimpleItem_Image.ID
                where SimpleItem.ToOffer = 1
            ";


            string Err = null;
            dt_ShopBItem.Clear();
            dt_ShopBItem.Columns.Clear();
            if (DBSync.DBSync.ReadDataTable(ref dt_ShopBItem, sql_ShopBItem, ref Err))
            {
                iCount = dt_ShopBItem.Rows.Count;
                return true;

            }
            else
            {
                LogFile.Error.Show("Error Load SimpleItem data:" + Err);
                return false;
            }
        }

        private bool SetGroups(ID PriceList_id)
        {
            string sql_Group = @"SELECT 
              s1.Name as s1_name,
              s2.Name as s2_name,
              s3.Name as s3_name
              From Price_SimpleItem
              INNER JOIN PriceList ON  Price_SimpleItem.PriceList_ID = PriceList.ID
              INNER JOIN Taxation ON  Price_SimpleItem.Taxation_ID = Taxation.ID
              INNER JOIN SimpleItem ON  Price_SimpleItem.SimpleItem_ID = SimpleItem.ID
              LEFT JOIN SimpleItem_Image ON SimpleItem.SimpleItem_Image_ID = SimpleItem_Image.ID
              LEFT JOIN SimpleItem_ParentGroup1 s1 ON SimpleItem.SimpleItem_ParentGroup1_ID = s1.ID
              LEFT JOIN SimpleItem_ParentGroup2 s2 ON s1.SimpleItem_ParentGroup2_ID = s2.ID
              LEFT JOIN SimpleItem_ParentGroup3 s3 ON s2.SimpleItem_ParentGroup3_ID = s3.ID
              where SimpleItem.ToOffer = 1 and Price_SimpleItem.RetailSimpleItemPrice>=0 and Price_SimpleItem.PriceList_ID = " + PriceList_id.ToString() + @"
		       group by s1.Name,s2.Name,s3.Name";

            dt_Group = new DataTable();
            string Err = null;
            if (DBSync.DBSync.ReadDataTable(ref dt_Group, sql_Group, ref Err))
            {
                if (m_usrc_Item_Group_Handler.Set_Groups(dt_Group))
                {
                    splitContainer1.Panel2Collapsed = false;
                    if (m_usrc_Item_Group_Handler.NumberOfGroupLevels>1)
                    {
                        StaticLib.Func.SetSplitContainerValue(splitContainer1,splitContainer1.Width-32, ref Err);
                    }
                    else
                    {
                        StaticLib.Func.SetSplitContainerValue(splitContainer1, splitContainer1.Width - 82, ref Err);
                    }
                    if (dt_Group.Rows.Count > 0)
                    {
                        string s1_name = null;
                        string s2_name = null;
                        string s3_name = null;
                        if (dt_Group.Rows[0]["s1_name"] is string)
                        {
                            s1_name = (string)dt_Group.Rows[0]["s1_name"];
                        }
                        if (dt_Group.Rows[0]["s2_name"] is string)
                        {
                            s2_name = (string)dt_Group.Rows[0]["s2_name"];
                        }
                        if (dt_Group.Rows[0]["s3_name"] is string)
                        {
                            s3_name = (string)dt_Group.Rows[0]["s3_name"];
                        }

                        string[] sGroup = new string[] { s1_name, s2_name, s3_name };
                        m_usrc_Item_Group_Handler.Select(sGroup);
                    }
                    return true;
                }
                else
                {
                    splitContainer1.Panel2Collapsed = true;
                    string[] sGroup = new string[] { null, null, null };
                    m_usrc_Item_Group_Handler.Select(sGroup);
                    return true;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:usrc_ShopBItemMan:SetGroups:sql=" + sql_Group + "\r\nErr=" + Err);
                return false;
            }

        }


        public bool Get_Price_ShopBItem_Data(ref int iCount_Price_ShopBItem_Data,ID PriceList_id)
        {
            m_PriceList_id = PriceList_id;
            SQLTable tbl_ShopBItem = DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(SimpleItem));

            if (SetGroups(PriceList_id))
            {
                iCount_Price_ShopBItem_Data = dt_Price_ShopBItem.Rows.Count;
                return true;
            }
            else
            {
                return false;
            }
        }


        private bool No_btn_Select_column(DataGridView dgv_ShopB_Items)
        {
            foreach (DataGridViewColumn dgvcol in dgv_ShopB_Items.Columns)
            {
                if (dgvcol.Name.Equals(DBtcn.btn_Select_Name))
                {
                    return false;
                }
            }
            return true;
        }

        private void usrc_Item_Group_Handler_GroupChanged(string[] s_name)
        {
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            string s_group_condition = fs.GetGroupCondition(ref lpar,s_name);


            string sql_ShopBItem = @"SELECT 
                  Price_SimpleItem.ID,
                  SimpleItem.Abbreviation AS SimpleItem_Abbreviation,
                  Price_SimpleItem.RetailSimpleItemPrice,
                  SimpleItem.Name AS SimpleItem_Name,
                  Price_SimpleItem.Discount,
                  PriceList_Name.Name As PriceList_Name,
                  Taxation.Name AS Taxation_Name,
                  Taxation.Rate AS Taxation_Rate,
                  SimpleItem_Image.Image_Hash AS SimpleItem_Image_Image_Hash,
                  SimpleItem_Image.Image_Data AS SimpleItem_Image_Image_Data,
                  SimpleItem.Code AS SimpleItem_Code,
                  SimpleItem.ToOffer AS SimpleItem_ToOffer,
                  s1.Name as s1_name,
                  s2.Name as s2_name,
                  s3.Name as s3_name
                  From Price_SimpleItem
                  INNER JOIN PriceList ON  Price_SimpleItem.PriceList_ID = PriceList.ID
                  INNER JOIN PriceList_Name ON  PriceList.PriceList_Name_ID = PriceList_Name.ID
                  INNER JOIN Taxation ON  Price_SimpleItem.Taxation_ID = Taxation.ID
                  INNER JOIN SimpleItem ON  Price_SimpleItem.SimpleItem_ID = SimpleItem.ID
                  LEFT JOIN SimpleItem_Image ON SimpleItem.SimpleItem_Image_ID = SimpleItem_Image.ID
                  LEFT JOIN SimpleItem_ParentGroup1 s1 ON SimpleItem.SimpleItem_ParentGroup1_ID = s1.ID
                  LEFT JOIN SimpleItem_ParentGroup2 s2 ON s1.SimpleItem_ParentGroup2_ID = s2.ID
                  LEFT JOIN SimpleItem_ParentGroup3 s3 ON s2.SimpleItem_ParentGroup3_ID = s3.ID
                  where SimpleItem.ToOffer = 1 and Price_SimpleItem.RetailSimpleItemPrice>=0 and Price_SimpleItem.PriceList_ID = " + m_PriceList_id.ToString() + s_group_condition;

            string Err = null;
            dt_Price_ShopBItem.Clear();
            dt_Price_ShopBItem.Columns.Clear();
            
            dgv_ShopB_Items.DataSource = null;
            dgv_ShopB_Items.Columns.Clear();
            dgv_ShopB_Items.Rows.Clear();
            if (DBSync.DBSync.ReadDataTable(ref dt_Price_ShopBItem, sql_ShopBItem,lpar, ref Err))
            {
                lbl_GroupPath.Text = m_usrc_Item_Group_Handler.GroupPath;
                dgv_ShopB_Items.DataSource = dt_Price_ShopBItem;
                int col_count = dgv_ShopB_Items.Columns.Count;
                dgv_ShopB_Items.Columns[DBtcn.colShopBItem_ID].Visible = false;
                dgv_ShopB_Items.Columns[DBtcn.colShopBItem_ShopBItem_Image_Image_Hash].Visible = false;

                dgv_ShopB_Items.Columns["SimpleItem_Abbreviation"].HeaderText = lng.s_dgv_SimpleItems_column_SimpleItem_Abbreviation.s;
                dgv_ShopB_Items.Columns["RetailSimpleItemPrice"].HeaderText = lng.s_dgv_SimpleItems_column_RetailSimpleItemPrice.s;
                dgv_ShopB_Items.Columns["SimpleItem_Name"].HeaderText = lng.s_dgv_SimpleItems_column_SimpleItem_Name.s;
                dgv_ShopB_Items.Columns["Discount"].HeaderText = lng.s_dgv_SimpleItems_column_Discount.s;
                dgv_ShopB_Items.Columns["PriceList_Name"].HeaderText = lng.s_dgv_SimpleItems_column_PriceList_Name.s;
                dgv_ShopB_Items.Columns["Taxation_Name"].HeaderText = lng.s_dgv_SimpleItems_column_Taxation_Name.s;
                dgv_ShopB_Items.Columns["Taxation_Rate"].HeaderText = lng.s_dgv_SimpleItems_column_Taxation_Rate.s;
                dgv_ShopB_Items.Columns["SimpleItem_Code"].HeaderText = lng.s_dgv_SimpleItems_column_SimpleItem_Code.s;
                dgv_ShopB_Items.Columns["SimpleItem_Image_Image_Data"].HeaderText = lng.s_dgv_SimpleItems_column_SimpleItem_Image_Image_Data.s;
                dgv_ShopB_Items.Columns["s1_name"].HeaderText = lng.s_dgv_SimpleItems_column_s1_name.s;
                dgv_ShopB_Items.Columns["s2_name"].HeaderText = lng.s_dgv_SimpleItems_column_s2_name.s;
                dgv_ShopB_Items.Columns["s3_name"].HeaderText = lng.s_dgv_SimpleItems_column_s3_name.s;


                if (No_btn_Select_column(dgv_ShopB_Items))
                {
                    DataGridViewImageButtonColumn btn = new DataGridViewImageButtonColumn(DataGridViewImageButtonColumn.eselection.select);
                    btn.HeaderText = "Izberi";
                    btn.Text = "<-";
                    btn.Name = DBtcn.btn_Select_Name;
                    dgv_ShopB_Items.Columns.Insert(1, btn);
                }
            }
            else
            {
                LogFile.Error.Show("Error Load ShopBItem data:" + Err);
            }
        }

        private void dgv_ShopB_Items_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void usrc_Item_Group_Handler_GroupsRedefined(int Level)
        {
            if (Level == 0)
            {
                dgv_ShopB_Items.Width = splitContainer2.Panel2.Width - 4;
                m_usrc_Item_Group_Handler.SetVisible(false);
            }
            else
            {
                m_usrc_Item_Group_Handler.SetVisible(true);
                dgv_ShopB_Items.Width = m_usrc_Item_Group_Handler.Left - dgv_ShopB_Items.Left-2;
            }

        }

        private void usrc_PriceList1_PriceListChanged(ID xPriceList_ID)
        {
            int iCount = 0;
            m_PriceList_id = xPriceList_ID;
            this.GetShopBItemData(ref iCount);
            SetGroups(m_PriceList_id);
        }

        private bool usrc_PriceList1_CheckAccess()
        {
            if (CheckAccessPriceList!=null)
            {
                return CheckAccessPriceList();
            }
            else
            {
                return true;
            }
        }
    }
}