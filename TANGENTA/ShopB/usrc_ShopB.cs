using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using SQLTableControl;
using BlagajnaTableClass;
using LanguageControl;
using DBConnectionControl40;
using InvoiceDB;
using FormDiscount;
using PriseLists;

namespace ShopB
{
    public partial class usrc_ShopB : UserControl
    {
        public enum eMode { VIEW,EDIT};

        private DataGridViewTextBoxColumn col_Discount = null;
        private DataGridViewTextBoxColumn dgv_total_discount_column = null;

        private int idgv_SimpleItems_Width_default = -1;
        long m_PriceList_id = -1;
        DataTable dt_Group = new DataTable();
        DataTable dt_SimpleItem = new DataTable();
        DataTable dt_Price_SimpleItem_Group = new DataTable();
        public enum eLayout {NONE,DRAFT,VIEW }
        private eLayout Layout = eLayout.NONE;

        DataTable dt_Price_SimpleItem = new DataTable();

        public DataTable dt_SelectedSimpleItem = new DataTable();

        InvoiceDB.ShopBC m_InvoiceDB = null;
        DBTablesAndColumnNames DBtcn = null;

        string column_SelectedSimpleItem_btn_discount = "btn_discount";
        string column_SelectedSimpleItem_btn_deselect = "btn_deselect";
        string column_total_discount = "total_discount";
        string btn_Select_Name = "btn_Select";

        public usrc_ShopB()
        {
            InitializeComponent();
            idgv_SimpleItems_Width_default = this.dgv_SimpleItems.Width;
            lngRPM.s_lbl_SelectedSimpleItems.Text(lbl_ShopB_Name);
            lngRPM.s_lbl_SimpleItems.Text(lbl_SimpleItems);
        }

        public delegate void delegate_ItemUpdated(long ID,DataTable dt_SelectedSimpleItem);
        public event delegate_ItemUpdated aa_ItemUpdated = null;

        public delegate void delegate_ItemAdded(long ID,DataTable dt_SelectedSimpleItem);
        public event delegate_ItemAdded aa_ItemAdded = null;

        public delegate void delegate_ItemRemoved(long ID, DataTable dt_SelectedSimpleItem);
        public event delegate_ItemRemoved aa_ItemRemoved = null;

        public delegate void delegate_ExtraDiscount(long ID, DataTable dt_SelectedSimpleItem);
        public event delegate_ExtraDiscount aa_ExtraDiscount = null;


        public void Init(ShopBC x_InvoiceDB, DBTablesAndColumnNames xDBtcn)
        {
            lngRPM.s_Shop_B.Text(lbl_ShopB_Name);

            Layout = eLayout.NONE;
            m_InvoiceDB = x_InvoiceDB;
            DBtcn = xDBtcn;
            dt_Price_SimpleItem_Group.Clear();
            dt_Price_SimpleItem_Group.Columns.Clear();

            dgv_SelectedSimpleItems.DataSource = null;
            dgv_SelectedSimpleItems.Rows.Clear();
            dgv_SelectedSimpleItems.Columns.Clear();
            dgv_SimpleItems.DataSource = null;
            dgv_SimpleItems.Rows.Clear();
            dgv_SimpleItems.Columns.Clear();

            dt_SelectedSimpleItem.Clear();
            dt_SelectedSimpleItem.Columns.Clear();

            col_Discount = null;
            dgv_total_discount_column = null;

            dt_SelectedSimpleItem.Columns.Add(DBtcn.column_SelectedSimpleItem_dt_SimpleItem_Index, DBtcn.column_SelectedSimpleItem_dt_SimpleItem_Index_TYPE);
            dt_SelectedSimpleItem.Columns.Add(DBtcn.column_Selected_Atom_Price_SimpleItem_ID, DBtcn.column_Selected_Atom_Price_SimpleItem_ID_TYPE);
            dt_SelectedSimpleItem.Columns.Add(DBtcn.column_SelectedSimpleItemName, DBtcn.column_SelectedSimpleItemName_TYPE);
            dt_SelectedSimpleItem.Columns.Add(DBtcn.column_SelectedSimpleItemPriceWithoutTax, DBtcn.column_SelectedSimpleItemPriceWithoutTax_TYPE);
            dt_SelectedSimpleItem.Columns.Add(DBtcn.column_SelectedSimpleItemPriceTax, DBtcn.column_SelectedSimpleItemPriceTax_TYPE);

            dt_SelectedSimpleItem.Columns.Add(DBtcn.column_SelectedSimpleItem_TaxName, DBtcn.column_SelectedSimpleItem_TaxName_TYPE);
            dt_SelectedSimpleItem.Columns.Add(DBtcn.column_SelectedSimpleItem_TaxRate, DBtcn.column_SelectedSimpleItem_TaxRate_TYPE);

            dt_SelectedSimpleItem.Columns.Add(DBtcn.column_SelectedSimpleItemPrice, DBtcn.column_SelectedSimpleItemPrice_TYPE);
            dt_SelectedSimpleItem.Columns.Add(DBtcn.column_SelectedSimpleItemPriceDiscount, DBtcn.column_SelectedSimpleItemPriceDiscount_TYPE);
            dt_SelectedSimpleItem.Columns.Add(DBtcn.column_SelectedSimpleItem_SimpleItem_ID, DBtcn.column_SelectedSimpleItem_SimpleItem_ID_TYPE);
            dt_SelectedSimpleItem.Columns.Add(DBtcn.column_SelectedSimpleItem_Count, DBtcn.column_SelectedSimpleItem_Count_TYPE);
            dt_SelectedSimpleItem.Columns.Add(DBtcn.column_SelectedSimpleItem_ExtraDiscount, DBtcn.column_SelectedSimpleItem_ExtraDiscount_TYPE);
            string Err = null;
            this.usrc_PriceList1.Init(GlobalData.BaseCurrency.ID, usrc_PriceList_Edit.eShopType.ShopB, ref Err);
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

        private int FindRow_in_dt_Price_SimpleItem(long id)
        {
            int iRes = -1;
            int iRow = 0;
            int iRowCount = dt_Price_SimpleItem.Rows.Count;
            if (iRowCount > 0)
            {
                for (iRow = 0; iRow < iRowCount; iRow++)
                {
                    long lid = (long)dt_Price_SimpleItem.Rows[iRow]["ID"];
                    if (lid == id)
                    {
                        return iRow;
                    }
                }
            }
            return iRes;
        }

        private void SetGridButtonState(DataGridView dgv, int rowIndex, int columnIndex, PushButtonState pushButtonState)
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
                        buttonCell.ButtonState = pushButtonState;
                    }
                }
            }
        }

        public void SetCurrentInvoice_SelectedSimpleItems()
        {
            m_InvoiceDB.m_CurrentInvoice.Set_SelectedSimpleItems(dgv_SelectedSimpleItems, dt_SelectedSimpleItem, dgv_SimpleItems, dt_Price_SimpleItem);
        }



        private void dgv_SimpleItems_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            SetGridButtonState(dgv_SimpleItems, e.RowIndex, e.ColumnIndex, PushButtonState.Pressed);
        }
        private void dgv_SimpleItems_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            SetGridButtonState(dgv_SimpleItems, e.RowIndex, e.ColumnIndex, PushButtonState.Hot);
        }

        private void dgv_SimpleItems_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            SetGridButtonState(dgv_SimpleItems, e.RowIndex, e.ColumnIndex, PushButtonState.Normal);
        }

        private void dgv_SimpleItems_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            SetGridButtonState(dgv_SimpleItems, e.RowIndex, e.ColumnIndex, PushButtonState.Normal);
            SimpleItemSelect(e.RowIndex);
        }

        private void SimpleItemSelect(int iSimpleItemRow)
        {
            // new SimpleItem
            string Err = null;
            if (iSimpleItemRow >= 0)
            {
                long Price_SimpleItem_ID = (long)dt_Price_SimpleItem.Rows[iSimpleItemRow]["ID"];

                string PriceList_Name = (string)dt_Price_SimpleItem.Rows[iSimpleItemRow]["PriceList_Name"]; 
                string SimpleItem_Name = (string)dt_Price_SimpleItem.Rows[iSimpleItemRow][DBtcn.colSimpleItemName]; 
                string SimpleItem_Abbreviation = (string)dt_Price_SimpleItem.Rows[iSimpleItemRow][DBtcn.colSimpleItemAbbreviation];
                string SimpleItem_Taxation_Name = (string)dt_Price_SimpleItem.Rows[iSimpleItemRow][DBtcn.colSimpleItemTaxation_Name];
                decimal SimpleItem_Taxation_Rate = (decimal)dt_Price_SimpleItem.Rows[iSimpleItemRow][DBtcn.colSimpleItemTaxation_Rate];
                decimal SimpleItem_RetailSimpleItemPrice_WithoutPriceListDiscount = (decimal)dt_Price_SimpleItem.Rows[iSimpleItemRow][DBtcn.colPriceSimpleItemRetailSimpleItemPrice];
                decimal SimpleItem_RetailSimpleItemPrice = SimpleItem_RetailSimpleItemPrice_WithoutPriceListDiscount - SimpleItem_RetailSimpleItemPrice_WithoutPriceListDiscount * (decimal)dt_Price_SimpleItem.Rows[iSimpleItemRow]["Discount"];
                string SimpleItem_Image_Image_Hash = null;
                byte[] SimpleItem_Image_Image_Data = null;

                if (dt_Price_SimpleItem.Rows[iSimpleItemRow][DBtcn.colSimpleItem_SimpleItem_Image_Image_Hash].GetType() == typeof(string))
                {
                    SimpleItem_Image_Image_Hash = (string)dt_Price_SimpleItem.Rows[iSimpleItemRow][DBtcn.colSimpleItem_SimpleItem_Image_Image_Hash];
                }
                if (dt_Price_SimpleItem.Rows[iSimpleItemRow][DBtcn.colSimpleItem_SimpleItem_Image_Image_Data].GetType() == typeof(byte[]))
                {
                    SimpleItem_Image_Image_Data = (byte[])dt_Price_SimpleItem.Rows[iSimpleItemRow][DBtcn.colSimpleItem_SimpleItem_Image_Image_Data];
                }

                int iSelectedSimpleItemRow = FindRow_in_dt_SelectedSimpleItem(Price_SimpleItem_ID);
                if (iSelectedSimpleItemRow >= 0)
                {
                    int iCount = (int)dt_SelectedSimpleItem.Rows[iSelectedSimpleItemRow][DBtcn.column_SelectedSimpleItem_Count];
                    iCount++;
                    decimal RetailPrice_per_unit = (decimal)dt_Price_SimpleItem.Rows[iSimpleItemRow][DBtcn.colPriceSimpleItemRetailSimpleItemPrice];
                    decimal Discount = (decimal)dt_Price_SimpleItem.Rows[iSimpleItemRow]["Discount"]; 
                    decimal ExtraDiscount = (decimal)dt_SelectedSimpleItem.Rows[iSelectedSimpleItemRow][DBtcn.column_SelectedSimpleItem_ExtraDiscount];
                    decimal TaxPrice = 0;
                    decimal RetailSimpleItemPriceWithDiscount = 0;
                    decimal PriceWithoutTax = 0;
                    string Taxation_Name = (string)dt_Price_SimpleItem.Rows[iSimpleItemRow][DBtcn.colSimpleItemTaxation_Name];
                    decimal Taxation_Rate = (decimal)dt_Price_SimpleItem.Rows[iSimpleItemRow][DBtcn.colSimpleItemTaxation_Rate];
                    long PriceSimpleItem_Atom_SimpleItem_ID = (long)dt_SelectedSimpleItem.Rows[iSelectedSimpleItemRow][DBtcn.column_Selected_Atom_Price_SimpleItem_ID];
                    if (m_InvoiceDB.Update_SelectedSimpleItem(PriceSimpleItem_Atom_SimpleItem_ID,
                                                           iCount,
                                                           Discount,
                                                           ExtraDiscount,
                                                           RetailPrice_per_unit,
                                                           Taxation_Name,
                                                           Taxation_Rate,
                                                           ref RetailSimpleItemPriceWithDiscount,
                                                           ref TaxPrice,
                                                           ref PriceWithoutTax,
                                                           ref Err))
                    {
                        dt_SelectedSimpleItem.Rows[iSelectedSimpleItemRow][DBtcn.column_SelectedSimpleItem_Count] = iCount;
                        dt_SelectedSimpleItem.Rows[iSelectedSimpleItemRow][DBtcn.column_SelectedSimpleItemPriceWithoutTax] = PriceWithoutTax;
                        dt_SelectedSimpleItem.Rows[iSelectedSimpleItemRow][DBtcn.column_SelectedSimpleItemPriceTax] = TaxPrice;
                        dt_SelectedSimpleItem.Rows[iSelectedSimpleItemRow][DBtcn.column_SelectedSimpleItem_TaxName] = Taxation_Name;
                        dt_SelectedSimpleItem.Rows[iSelectedSimpleItemRow][DBtcn.column_SelectedSimpleItem_TaxRate] = Taxation_Rate;
                        dt_SelectedSimpleItem.Rows[iSelectedSimpleItemRow][DBtcn.column_SelectedSimpleItemPrice] = RetailSimpleItemPriceWithDiscount;
                        dgv_SelectedSimpleItems.Rows[iSelectedSimpleItemRow].Cells[column_SelectedSimpleItem_btn_discount].Value = ExtraDiscount;
                        if (aa_ItemUpdated != null)
                        {
                            aa_ItemUpdated(PriceSimpleItem_Atom_SimpleItem_ID,dt_SelectedSimpleItem);
                        }
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:usrc_Invoice:SimpleItemSelect:Err=" + Err);
                    }
                }
                else
                {
                    decimal RetailPriceWithDiscount = 0;
                    decimal RetailSimpleItemPrice = 0;
                    decimal Discount = 0; 
                    decimal ExtraDiscount = 0;
                    decimal Taxation_Rate = 0;
                    string Taxation_Name = null;
                    decimal Tax = 0;
                    int iCount = 1;
                    long Atom_Price_SimpleItem_ID = -1;
                    decimal PriceWithoutTax = 0;


                    if (f_Atom_Price_SimpleItem.Get(Price_SimpleItem_ID,
                                                    m_InvoiceDB.m_CurrentInvoice.ProformaInvoice_ID,
                                                    ref Atom_Price_SimpleItem_ID,
                                                    ref iCount,
                                                    ref RetailSimpleItemPrice,
                                                    ref Discount,
                                                    ref ExtraDiscount,
                                                    ref Taxation_Rate,
                                                    ref Taxation_Name,
                                                    ref RetailPriceWithDiscount,
                                                    ref Tax,
                                                    ref PriceWithoutTax
                                                    ))
                    {
                        if (this.m_InvoiceDB.Read_Atom_Price_SimpleItem_Table(m_InvoiceDB.m_CurrentInvoice.ProformaInvoice_ID,ref m_InvoiceDB.m_CurrentInvoice.dtCurrent_Atom_Price_SimpleItem))
                        {
                            DataRow dr = dt_SelectedSimpleItem.NewRow();
                            dr[DBtcn.column_SelectedSimpleItemPriceDiscount] = Discount;
                            dr[DBtcn.column_SelectedSimpleItem_ExtraDiscount] = ExtraDiscount;
                            dr[DBtcn.column_SelectedSimpleItem_dt_SimpleItem_Index] = iSimpleItemRow;
                            dr[DBtcn.column_Selected_Atom_Price_SimpleItem_ID] = Atom_Price_SimpleItem_ID;
                            dr[DBtcn.column_SelectedSimpleItem_SimpleItem_ID] = Price_SimpleItem_ID;
                            dr[DBtcn.column_SelectedSimpleItem_Count] = 1;
                            dr[DBtcn.column_SelectedSimpleItemName] = SimpleItem_Name;
                            dr[DBtcn.column_SelectedSimpleItemPriceWithoutTax] = PriceWithoutTax;
                            dr[DBtcn.column_SelectedSimpleItemPriceTax] = Tax;
                            dr[DBtcn.column_SelectedSimpleItem_TaxName] = Taxation_Name;
                            dr[DBtcn.column_SelectedSimpleItem_TaxRate] = Taxation_Rate;
                            dr[DBtcn.column_SelectedSimpleItemPrice] = RetailPriceWithDiscount;
                            dt_SelectedSimpleItem.Rows.Add(dr);
                            if (Layout!=eLayout.DRAFT)
                            {
                                SetDraftButtons();
                            }
                            dgv_SelectedSimpleItems.Rows[dt_SelectedSimpleItem.Rows.Count-1].Cells[column_SelectedSimpleItem_btn_discount].Value = ExtraDiscount;

                            if (aa_ItemAdded != null)
                            {
                                aa_ItemAdded(Atom_Price_SimpleItem_ID,dt_SelectedSimpleItem);
                            }

                        }
                    }
                }
                dgv_SelectedSimpleItems.Refresh();
            }
        }

        private void SelectExtraDiscount(int iSelectedSimpleItemRow)
        {
            string Err = null;
            long Atom_SimpleItem_ID = (long)dt_SelectedSimpleItem.Rows[iSelectedSimpleItemRow][DBtcn.column_Selected_Atom_Price_SimpleItem_ID];
            string SimpleItem_Name = (string)dt_SelectedSimpleItem.Rows[iSelectedSimpleItemRow][DBtcn.column_SelectedSimpleItemName];
            object obj_Discount = dt_SelectedSimpleItem.Rows[iSelectedSimpleItemRow][DBtcn.column_SelectedSimpleItemPriceDiscount];
            decimal Discount = 0;
            if (obj_Discount.GetType() == typeof(decimal))
            {
                Discount = (decimal)obj_Discount;
            }

            int iSimpleItemRow = (int)dt_SelectedSimpleItem.Rows[iSelectedSimpleItemRow][DBtcn.column_SelectedSimpleItem_dt_SimpleItem_Index];
            decimal RetailPricePerUnit = (decimal)dt_Price_SimpleItem.Rows[iSimpleItemRow][DBtcn.colPriceSimpleItemRetailSimpleItemPrice];
            decimal ExtraDiscount = 0;
            if (iSelectedSimpleItemRow >= 0)
            {
                ExtraDiscount = (decimal)dt_SelectedSimpleItem.Rows[iSelectedSimpleItemRow][DBtcn.column_SelectedSimpleItem_ExtraDiscount];
            }
            Form_Discount discount_frm = new Form_Discount(RetailPricePerUnit, null,ExtraDiscount, SimpleItem_Name);
            if (discount_frm.ShowDialog() == DialogResult.OK)
            {
                ExtraDiscount = discount_frm.ExtraDiscount;
                int iCount = (int)dt_SelectedSimpleItem.Rows[iSelectedSimpleItemRow][DBtcn.column_SelectedSimpleItem_Count];
                long lid = (long)dt_SelectedSimpleItem.Rows[iSelectedSimpleItemRow][DBtcn.column_SelectedSimpleItem_SimpleItem_ID];
                if (iSimpleItemRow >= 0)
                {

                    decimal RetailSimpleItemPrice = (decimal)dt_Price_SimpleItem.Rows[iSimpleItemRow][DBtcn.colPriceSimpleItemRetailSimpleItemPrice];
                    decimal TaxPrice = 0;
                    decimal RetailSimpleItemPriceWithDiscount = 0;
                    decimal PriceWithoutTax = 0;
                    string Taxation_Name = (string)dt_Price_SimpleItem.Rows[iSimpleItemRow][DBtcn.colSimpleItemTaxation_Name];
                    decimal Taxation_Rate = (decimal)dt_Price_SimpleItem.Rows[iSimpleItemRow][DBtcn.colSimpleItemTaxation_Rate];
                    if (m_InvoiceDB.Update_SelectedSimpleItem(Atom_SimpleItem_ID,
                                                           iCount,
                                                           Discount,
                                                           ExtraDiscount,
                                                           RetailSimpleItemPrice,
                                                           Taxation_Name,
                                                           Taxation_Rate,
                                                           ref RetailSimpleItemPriceWithDiscount,
                                                           ref TaxPrice,
                                                           ref PriceWithoutTax,
                                                           ref Err))
                    {
                        dt_SelectedSimpleItem.Rows[iSelectedSimpleItemRow][DBtcn.column_SelectedSimpleItem_Count] = iCount;
                        dt_SelectedSimpleItem.Rows[iSelectedSimpleItemRow][DBtcn.column_SelectedSimpleItemPriceWithoutTax] = PriceWithoutTax;
                        dt_SelectedSimpleItem.Rows[iSelectedSimpleItemRow][DBtcn.column_SelectedSimpleItem_ExtraDiscount] = ExtraDiscount;
                        dt_SelectedSimpleItem.Rows[iSelectedSimpleItemRow][DBtcn.column_SelectedSimpleItemPriceTax] = TaxPrice;
                        dt_SelectedSimpleItem.Rows[iSelectedSimpleItemRow][DBtcn.column_SelectedSimpleItem_TaxName] = Taxation_Name;
                        dt_SelectedSimpleItem.Rows[iSelectedSimpleItemRow][DBtcn.column_SelectedSimpleItem_TaxRate] = Taxation_Rate;
                        dt_SelectedSimpleItem.Rows[iSelectedSimpleItemRow][DBtcn.column_SelectedSimpleItemPrice] = RetailSimpleItemPriceWithDiscount;
                        //dgv_SelectedSimpleItems.Rows[iSelectedSimpleItemRow].Cells["btn_discount"].Value = ExtraDiscount.ToString();
                        dgv_SelectedSimpleItems.Rows[iSelectedSimpleItemRow].Cells["btn_discount"].Value = ExtraDiscount;
                        if (aa_ExtraDiscount != null)
                        {
                            aa_ExtraDiscount(Atom_SimpleItem_ID, dt_SelectedSimpleItem);
                        }
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:usrc_Invoice:SimpleItemDeselect:m_InvoiceDB.Update_SelectedSimpleItem:Err=" + Err);
                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:usrc_Invoice:SimpleItemDeselect:ERROR:can not find iSimpleItemRow!");
                }
            }
        }


        private int FindRow_in_dt_SelectedSimpleItem(long id)
        {
            int iRes = -1;
            int iRow = 0;
            int iRowCount = dt_SelectedSimpleItem.Rows.Count;
            if (iRowCount > 0)
            {
                for (iRow = 0; iRow < iRowCount; iRow++)
                {
                    long lid = (long)dt_SelectedSimpleItem.Rows[iRow][DBtcn.column_SelectedSimpleItem_SimpleItem_ID];
                    if (lid == id)
                    {
                        return iRow;
                    }
                }
            }
            return iRes;
        }


        private void dgv_SelectedSimpleItems_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {

            if ((e.ColumnIndex >= 0)&&(e.RowIndex>=0))
            {
                SetGridButtonState(dgv_SelectedSimpleItems, e.RowIndex, e.ColumnIndex, PushButtonState.Normal);
                if (dgv_SelectedSimpleItems.Columns[e.ColumnIndex].Name.Equals(column_SelectedSimpleItem_btn_deselect))
                {
                    SimpleItemDeselect(e.RowIndex);
                }
                if (dgv_SelectedSimpleItems.Columns[e.ColumnIndex].Name.Equals(column_SelectedSimpleItem_btn_discount))
                {
                    SelectExtraDiscount(e.RowIndex);
                }
            }
        }


        private void SimpleItemDeselect(int iSelectedSimpleItemRow)
        {
            // new SimpleItem
            string Err = null;
            if (iSelectedSimpleItemRow >= 0)
            {
                long Atom_Price_SimpleItem_ID = (long)dt_SelectedSimpleItem.Rows[iSelectedSimpleItemRow][DBtcn.column_Selected_Atom_Price_SimpleItem_ID];
                int iCount = (int)dt_SelectedSimpleItem.Rows[iSelectedSimpleItemRow][DBtcn.column_SelectedSimpleItem_Count];
                long lid = (long)dt_SelectedSimpleItem.Rows[iSelectedSimpleItemRow][DBtcn.column_SelectedSimpleItem_SimpleItem_ID];
                if (iCount > 1)
                {
                    iCount--;
                    int iSimpleItemRow = FindRow_in_dt_Price_SimpleItem(lid);
                    if (iSimpleItemRow >= 0)
                    {
                        decimal RetailPrice_per_unit = (decimal)dt_Price_SimpleItem.Rows[iSimpleItemRow][DBtcn.colPriceSimpleItemRetailSimpleItemPrice];
                        decimal Discount = (decimal)dt_Price_SimpleItem.Rows[iSimpleItemRow]["Discount"]; ;
                        decimal ExtraDiscount = (decimal)dt_SelectedSimpleItem.Rows[iSelectedSimpleItemRow][DBtcn.column_SelectedSimpleItem_ExtraDiscount];
                        decimal TaxPrice = 0;
                        decimal RetailSimpleItemPriceWithDiscount = 0;
                        decimal PriceWithoutTax = 0;
                        string Taxation_Name = (string)dt_Price_SimpleItem.Rows[iSimpleItemRow][DBtcn.colSimpleItemTaxation_Name];
                        decimal Taxation_Rate = (decimal)dt_Price_SimpleItem.Rows[iSimpleItemRow][DBtcn.colSimpleItemTaxation_Rate];
                        if (m_InvoiceDB.Update_SelectedSimpleItem(Atom_Price_SimpleItem_ID,
                                                               iCount,
                                                               Discount,
                                                               ExtraDiscount,
                                                               RetailPrice_per_unit,
                                                               Taxation_Name,
                                                               Taxation_Rate,
                                                               ref RetailSimpleItemPriceWithDiscount,
                                                               ref TaxPrice,
                                                               ref PriceWithoutTax,
                                                               ref Err))
                        {
                            dt_SelectedSimpleItem.Rows[iSelectedSimpleItemRow][DBtcn.column_SelectedSimpleItem_Count] = iCount;
                            dt_SelectedSimpleItem.Rows[iSelectedSimpleItemRow][DBtcn.column_SelectedSimpleItemPriceWithoutTax] = PriceWithoutTax;
                            dt_SelectedSimpleItem.Rows[iSelectedSimpleItemRow][DBtcn.column_SelectedSimpleItemPriceTax] = TaxPrice;
                            dt_SelectedSimpleItem.Rows[iSelectedSimpleItemRow][DBtcn.column_SelectedSimpleItem_TaxName] = Taxation_Name;
                            dt_SelectedSimpleItem.Rows[iSelectedSimpleItemRow][DBtcn.column_SelectedSimpleItem_TaxRate] = Taxation_Rate;
                            dt_SelectedSimpleItem.Rows[iSelectedSimpleItemRow][DBtcn.column_SelectedSimpleItemPrice] = RetailSimpleItemPriceWithDiscount;
                            dgv_SelectedSimpleItems.Rows[iSelectedSimpleItemRow].Cells["btn_discount"].Value = ExtraDiscount;
                        }
                        else
                        {
                            LogFile.Error.Show("ERROR:usrc_Invoice:SimpleItemDeselect:m_InvoiceDB.Update_SelectedSimpleItem:Err=" + Err);
                        }
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:usrc_Invoice:SimpleItemDeselect:ERROR:can not find iSimpleItemRow!");
                    }
                }
                else
                {
                    if (m_InvoiceDB.Delete_SelectedSimpleItem(Atom_Price_SimpleItem_ID,
                                                            ref Err))
                    {
                        dt_SelectedSimpleItem.Rows.RemoveAt(iSelectedSimpleItemRow);
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:usrc_Invoice:SimpleItemDeselect:m_InvoiceDB.Update_SelectedSimpleItem:Err=" + Err);
                    }

                }
                dgv_SelectedSimpleItems.Refresh();
                if (this.aa_ItemRemoved != null)
                {
                    aa_ItemRemoved(lid, dt_SelectedSimpleItem);
                }

            }
        }

        public void SetDraftButtons()
        {
            if ((Layout == eLayout.VIEW)||(Layout == eLayout.NONE))
            {
                if (Layout == eLayout.VIEW)
                {
                    if (FindColumn(dgv_SelectedSimpleItems, column_total_discount))
                    {
                        this.dgv_SelectedSimpleItems.Columns.Remove(column_total_discount);
                    }
                    dgv_total_discount_column = null;
                }

                DataGridViewImageButtonColumn btn_Discount = null;

                btn_Discount = new DataGridViewImageButtonColumn(DataGridViewImageButtonColumn.eselection.discount);
                btn_Discount.HeaderText = "";
                btn_Discount.Text = "";
                btn_Discount.Name = column_SelectedSimpleItem_btn_discount;
                btn_Discount.Width = 32;
                this.dgv_SelectedSimpleItems.Columns.Insert(4, btn_Discount);
                DataGridViewImageButtonColumn btn_Remove = new DataGridViewImageButtonColumn(DataGridViewImageButtonColumn.eselection.deselect);
                btn_Remove.HeaderText = "Odstrani";
                btn_Remove.Text = "-";
                btn_Remove.Name = column_SelectedSimpleItem_btn_deselect;
                this.dgv_SelectedSimpleItems.Columns.Add(btn_Remove);
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
                    this.dgv_SelectedSimpleItems.Columns.Remove(column_SelectedSimpleItem_btn_discount);
                    this.dgv_SelectedSimpleItems.Columns.Remove(column_SelectedSimpleItem_btn_deselect);
                }
                if (!FindColumn(dgv_SelectedSimpleItems, column_total_discount))
                {
                    dgv_total_discount_column = null;
                }


                if (dgv_total_discount_column == null)
                {
                    dgv_total_discount_column = new DataGridViewTextBoxColumn();
                    dgv_total_discount_column.Name = column_total_discount;
                    dgv_total_discount_column.HeaderText = lngRPM.s_TotalDiscount.s;
                    this.dgv_SelectedSimpleItems.Columns.Add(dgv_total_discount_column);
                }
                this.dgv_SelectedSimpleItems.Columns[DBtcn.column_SelectedSimpleItemPriceDiscount].Visible = true;
                this.dgv_SelectedSimpleItems.Columns[DBtcn.column_SelectedSimpleItem_ExtraDiscount].Visible = true;

                this.dgv_SelectedSimpleItems.Columns[DBtcn.column_SelectedSimpleItemPriceDiscount].HeaderText = lngRPM.s_PriceListDiscount.s;
                this.dgv_SelectedSimpleItems.Columns[DBtcn.column_SelectedSimpleItem_ExtraDiscount].HeaderText = lngRPM.s_ExtraDiscount.s;
                this.dgv_SelectedSimpleItems.Columns[column_total_discount].HeaderText = lngRPM.s_TotalDiscount.s;
                Layout = eLayout.VIEW;
            }
            if (col_Discount == null)
            { 
                col_Discount = new DataGridViewTextBoxColumn();
                col_Discount.HeaderText = lngRPM.s_Discount.s;
                col_Discount.Name = column_SelectedSimpleItem_btn_discount;
                col_Discount.Width = 32;
                this.dgv_SelectedSimpleItems.Columns.Insert(4, col_Discount);
            }
        }

        public void Set_dgv_SelectedSimpleItems()
        {
            try
            {
                dt_SelectedSimpleItem.Rows.Clear();
                dgv_SelectedSimpleItems.DataSource = dt_SelectedSimpleItem;
                this.dgv_SelectedSimpleItems.Columns[DBtcn.column_SelectedSimpleItemName].HeaderText = "Storitev";
                //this.dgv_SelectedSimpleItems.Columns[DBtcn.column_SelectedSimpleItemName].MinimumWidth = 120;
                //this.dgv_SelectedSimpleItems.Columns[DBtcn.column_SelectedSimpleItemName].Width = 120;
                this.dgv_SelectedSimpleItems.Columns[DBtcn.column_SelectedSimpleItemPriceWithoutTax].HeaderText = "Cena brez davka";
                this.dgv_SelectedSimpleItems.Columns[DBtcn.column_SelectedSimpleItemPriceTax].HeaderText = "Davek";
                this.dgv_SelectedSimpleItems.Columns[DBtcn.column_SelectedSimpleItemPrice].HeaderText = "Končna cena";
                this.dgv_SelectedSimpleItems.Columns[DBtcn.column_SelectedSimpleItem_Count].HeaderText = "Količina";
                this.dgv_SelectedSimpleItems.Columns[DBtcn.column_SelectedSimpleItemPriceDiscount].Visible = false;
                this.dgv_SelectedSimpleItems.Columns[DBtcn.column_SelectedSimpleItem_SimpleItem_ID].Visible = false;
                this.dgv_SelectedSimpleItems.Columns[DBtcn.column_Selected_Atom_Price_SimpleItem_ID].Visible = false;
                this.dgv_SelectedSimpleItems.Columns[DBtcn.column_SelectedSimpleItem_dt_SimpleItem_Index].Visible = false;
                this.dgv_SelectedSimpleItems.Columns[DBtcn.column_SelectedSimpleItem_ExtraDiscount].Visible = false;

                this.dgv_SelectedSimpleItems.Columns[DBtcn.column_SelectedSimpleItem_TaxName].Visible = false;
                this.dgv_SelectedSimpleItems.Columns[DBtcn.column_SelectedSimpleItem_TaxRate].Visible = false;

            }
            catch (Exception Ex)
            {
                LogFile.Error.Show("ERROR:Set_dgv_SelectedSimpleItems:Exception=" + Ex.Message);
            }
        }

        public bool GetSimpleItemData(ref int iCount)
        {
            SQLTable tbl_SimpleItem = DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(SimpleItem));


            string sql_SimpleItem = @"SELECT 
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
            dt_SimpleItem.Clear();
            if (DBSync.DBSync.ReadDataTable(ref dt_SimpleItem, sql_SimpleItem, ref Err))
            {
                iCount = dt_SimpleItem.Rows.Count;
                return true;

            }
            else
            {
                LogFile.Error.Show("Error Load SimpleItem data:" + Err);
                return false;
            }
        }

        private bool SetGroups(long PriceList_id)
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
                usrc_Item_Group_Handler.Set_Groups(dt_Group);
                return true;
                
            }
            else
            {
                LogFile.Error.Show("ERROR:usrc_SimpleItemMan:SetGroups:sql=" + sql_Group + "\r\nErr=" + Err);
                return false;
            }

        }


        public bool Get_Price_SimpleItem_Data(ref int iCount_Price_SimpleItem_Data,long PriceList_id)
        {
            m_PriceList_id = PriceList_id;
            SQLTable tbl_SimpleItem = DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(SimpleItem));

            if (SetGroups(PriceList_id))
            {
                iCount_Price_SimpleItem_Data = dt_Price_SimpleItem.Rows.Count;
                return true;
            }
            else
            {
                return false;
            }
        }


        private bool No_btn_Select_column(DataGridView dgv_SimpleItems)
        {
            foreach (DataGridViewColumn dgvcol in dgv_SimpleItems.Columns)
            {
                if (dgvcol.Name.Equals(btn_Select_Name))
                {
                    return false;
                }
            }
            return true;
        }

        private void btn_edit_SimpleItems_Click(object sender, EventArgs e)
        {
            EditSimpleItem();
        }

        public bool EditSimpleItem()
        {
            SQLTable tbl_SimpleItem=new SQLTable(DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(SimpleItem)));
            Form_SimpleItem_Edit edt_SimpleItem_dlg = new Form_SimpleItem_Edit(DBSync.DBSync.DB_for_Blagajna.m_DBTables,
                                                                    tbl_SimpleItem,
                                                                    "SimpleItem_$$Code desc");
            edt_SimpleItem_dlg.ShowDialog();
            int iCount = 0;
            this.GetSimpleItemData(ref iCount);
            SetGroups(m_PriceList_id);
            return true;
        }

        private void usrc_Item_Group_Handler_GroupChanged(string[] s_name)
        {
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            string s_group_condition = fs.GetGroupCondition(ref lpar,s_name);


            string sql_SimpleItem = @"SELECT 
                  Price_SimpleItem.ID,
                  SimpleItem.Abbreviation AS SimpleItem_Abbreviation,
                  Price_SimpleItem.RetailSimpleItemPrice,
                  SimpleItem.Name AS SimpleItem_Name,
                  Price_SimpleItem.Discount,
                  PriceList.Name As PriceList_Name,
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
                  INNER JOIN Taxation ON  Price_SimpleItem.Taxation_ID = Taxation.ID
                  INNER JOIN SimpleItem ON  Price_SimpleItem.SimpleItem_ID = SimpleItem.ID
                  LEFT JOIN SimpleItem_Image ON SimpleItem.SimpleItem_Image_ID = SimpleItem_Image.ID
                  LEFT JOIN SimpleItem_ParentGroup1 s1 ON SimpleItem.SimpleItem_ParentGroup1_ID = s1.ID
                  LEFT JOIN SimpleItem_ParentGroup2 s2 ON s1.SimpleItem_ParentGroup2_ID = s2.ID
                  LEFT JOIN SimpleItem_ParentGroup3 s3 ON s2.SimpleItem_ParentGroup3_ID = s3.ID
                  where SimpleItem.ToOffer = 1 and Price_SimpleItem.RetailSimpleItemPrice>=0 and Price_SimpleItem.PriceList_ID = " + m_PriceList_id.ToString() + s_group_condition;

            string Err = null;
            dt_Price_SimpleItem.Clear();
            dt_Price_SimpleItem.Columns.Clear();
            
            dgv_SimpleItems.DataSource = null;
            dgv_SimpleItems.Columns.Clear();
            dgv_SimpleItems.Rows.Clear();
            if (DBSync.DBSync.ReadDataTable(ref dt_Price_SimpleItem, sql_SimpleItem,lpar, ref Err))
            {
                lbl_GroupPath.Text = usrc_Item_Group_Handler.GroupPath;
                dgv_SimpleItems.DataSource = dt_Price_SimpleItem;
                int col_count = dgv_SimpleItems.Columns.Count;
                dgv_SimpleItems.Columns[DBtcn.colSimpleItem_ID].Visible = false;
                dgv_SimpleItems.Columns[DBtcn.colSimpleItem_SimpleItem_Image_Image_Hash].Visible = false;

                dgv_SimpleItems.Columns["SimpleItem_Abbreviation"].HeaderText = lngRPM.s_dgv_SimpleItems_column_SimpleItem_Abbreviation.s;
                dgv_SimpleItems.Columns["RetailSimpleItemPrice"].HeaderText = lngRPM.s_dgv_SimpleItems_column_RetailSimpleItemPrice.s;
                dgv_SimpleItems.Columns["SimpleItem_Name"].HeaderText = lngRPM.s_dgv_SimpleItems_column_SimpleItem_Name.s;
                dgv_SimpleItems.Columns["Discount"].HeaderText = lngRPM.s_dgv_SimpleItems_column_Discount.s;
                dgv_SimpleItems.Columns["PriceList_Name"].HeaderText = lngRPM.s_dgv_SimpleItems_column_PriceList_Name.s;
                dgv_SimpleItems.Columns["Taxation_Name"].HeaderText = lngRPM.s_dgv_SimpleItems_column_Taxation_Name.s;
                dgv_SimpleItems.Columns["Taxation_Rate"].HeaderText = lngRPM.s_dgv_SimpleItems_column_Taxation_Rate.s;
                dgv_SimpleItems.Columns["SimpleItem_Code"].HeaderText = lngRPM.s_dgv_SimpleItems_column_SimpleItem_Code.s;
                dgv_SimpleItems.Columns["SimpleItem_Image_Image_Data"].HeaderText = lngRPM.s_dgv_SimpleItems_column_SimpleItem_Image_Image_Data.s;
                dgv_SimpleItems.Columns["s1_name"].HeaderText = lngRPM.s_dgv_SimpleItems_column_s1_name.s;
                dgv_SimpleItems.Columns["s2_name"].HeaderText = lngRPM.s_dgv_SimpleItems_column_s2_name.s;
                dgv_SimpleItems.Columns["s3_name"].HeaderText = lngRPM.s_dgv_SimpleItems_column_s3_name.s;


                if (No_btn_Select_column(dgv_SimpleItems))
                {
                    DataGridViewImageButtonColumn btn = new DataGridViewImageButtonColumn(DataGridViewImageButtonColumn.eselection.select);
                    btn.HeaderText = "Izberi";
                    btn.Text = "<-";
                    btn.Name = btn_Select_Name;
                    dgv_SimpleItems.Columns.Insert(1, btn);
                }

                //sgroup_list.SetGroups(ref dt_Price_SimpleItem_Group, dt_Price_SimpleItem, pnl_Group, dgv_SimpleItems);

            }
            else
            {
                LogFile.Error.Show("Error Load SimpleItem data:" + Err);
            }
        }

        private void dgv_SimpleItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void usrc_Item_Group_Handler_GroupsRedefined(int Level)
        {
            if (Level == 0)
            {
                dgv_SimpleItems.Width = splitContainer2.Panel2.Width - 4;
                usrc_Item_Group_Handler.Visible = false;
            }
            else
            {
                usrc_Item_Group_Handler.Visible = true;
                dgv_SimpleItems.Width = usrc_Item_Group_Handler.Left - dgv_SimpleItems.Left-2;
            }

        }
    }
}
