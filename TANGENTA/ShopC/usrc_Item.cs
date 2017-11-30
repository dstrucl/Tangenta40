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
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TangentaTableClass;
using DBTypes;
using CodeTables;
using LanguageControl;
using TangentaDB;
using Form_Discount;

namespace ShopC
{
    public partial class usrc_Item : UserControl
    {
        public delegate void delegate_ItemAdded2Basket();
        public event delegate_ItemAdded2Basket ItemAdded2Basket = null;

        public delegate void delegate_ItemChanged(object obj);
        public event delegate_ItemChanged ItemChanged = null;

        public delegate void delegate_StockChanged(object obj);
        public event delegate_StockChanged StockChanged = null;

        //usrc_ItemList

        public TangentaDB.Item_Data m_Item_Data = null;

        bool disposed = false;

        public enum eMode { STOCK, FACTORY, STOCK_AND_FACTORY,NONE }
        public eMode Mode = eMode.STOCK_AND_FACTORY;

        public usrc_Atom_ItemsList m_usrc_Atom_ItemsList = null;
        public usrc_ItemList m_usrc_ItemList = null;

        public decimal ExtraDiscount = 0;
        public usrc_Atom_Item m_usrc_Atom_Item = null;
        private Color DefaultColor = Color.Gray;

        private int x0_pic_Item = 0;
        private int x1_btn_EditItem = 0;
        private int x2_btn_NoStock = 0;
        private int x3_lbl_ItemPrice = 0;

        private int cx_lbl_Item_large_width = 0;
        private int cx_lbl_Item_small_width = 0;
        public NavigationButtons.Navigation nav = null;

        public usrc_Item()
        {
            InitializeComponent();
            x0_pic_Item = pic_Item.Left;
            x1_btn_EditItem = btn_EditItem.Left;
            x2_btn_NoStock = btn_NoStock.Left;
            x3_lbl_ItemPrice = lbl_ItemPrice.Left;
            cx_lbl_Item_small_width = lbl_Item.Width;
            cx_lbl_Item_large_width = cx_lbl_Item_small_width + x1_btn_EditItem - x0_pic_Item;
            
            DefaultColor = BackColor;
        }


        // Protected implementation of Dispose pattern. 
        protected override void Dispose(bool disposing)
        {
            if (disposed)
                return;

            this.nmUpDn_StockQuantity.ValueChanged -=  (System.EventHandler)this.nmUpDn_StockQuantity_ValueChanged;
            this.nmUpDn_FactoryQuantity.ValueChanged -= (System.EventHandler) this.nmUpDn_FactoryQuantity_ValueChanged;
            this.btn_Discount.Click -= (System.EventHandler)this.btn_Discount_Click;
            this.btn_EditItem.Click -=  (System.EventHandler)this.btn_EditItem_Click;
            this.btn_NoStock.Click -= (System.EventHandler) this.btn_Factory_Click;
            this.btn_Stock.Click -= (System.EventHandler) this.btn_Stock_Click;

            if (disposing)
            {
                int i= 0;
                for (i = Controls.Count-1;i >= 0 ;i--)
                {
                    Control c = Controls[i];
                    Controls.Remove(c);
                    c.Dispose();
                }
                Controls.Clear();
            }

            // Free any unmanaged objects here. 
            //
            disposed = true;
            // Call base class implementation. 
            base.Dispose(disposing);
        }


        public decimal dQuantity
        {
            get
            {
                switch (Mode)
                {
                    case eMode.STOCK_AND_FACTORY:
                        return GetValue(nmUpDn_StockQuantity) + GetValue(nmUpDn_FactoryQuantity);

                    case eMode.STOCK:
                        return GetValue(nmUpDn_StockQuantity);

                    case eMode.FACTORY:
                        return GetValue(nmUpDn_FactoryQuantity);

                    case eMode.NONE:
                        return 0;

                    default:
                        LogFile.Error.Show("ERROR:usrc_Item:dQuantity:Invalid Mode !");
                        return 0;
                }
            }
        }

        private decimal GetValue(NumericUpDown nmUpDn_Quantity)
        {
            if (nmUpDn_Quantity.Visible)
            {
                return nmUpDn_Quantity.Value;
            }
            else
            {
                return 0;
            }
        }

        private void RePaint()
        {
            decimal dAllStockQuantity = 0;

            dAllStockQuantity = m_Item_Data.dQuantity_OfStockItems;

            if (dAllStockQuantity > 0)
            {
                
                    nmUpDn_StockQuantity.Maximum = Convert.ToDecimal(dAllStockQuantity);
                    fs.SetNumericUpDown(ref nmUpDn_StockQuantity, m_Item_Data.Unit_DecimalPlaces.v);
                    nmUpDn_StockQuantity.Maximum = Convert.ToDecimal(dAllStockQuantity);
                    fs.SetNumericUpDown(ref nmUpDn_FactoryQuantity, m_Item_Data.Unit_DecimalPlaces.v);
                    Paint_Item_Mode(eMode.STOCK_AND_FACTORY);
            }
            else
            {
                fs.SetNumericUpDown(ref nmUpDn_StockQuantity, m_Item_Data.Unit_DecimalPlaces.v);
                fs.SetNumericUpDown(ref nmUpDn_FactoryQuantity, m_Item_Data.Unit_DecimalPlaces.v);
                nmUpDn_FactoryQuantity.Maximum = decimal.MaxValue;
                Paint_Item_Mode(eMode.FACTORY);
            }

            this.txt_InStock.Text = dAllStockQuantity.ToString();
            if (m_Item_Data.Item_UniqueName != null)
            {
                this.lbl_Item.Text = m_Item_Data.Item_UniqueName.v;
            }
            if (m_Item_Data.Item_Description != null)
            {
                this.txt_Item_Description.Text = m_Item_Data.Item_Description.v;
            }


            Set_txt_Price();

            if (m_Item_Data.Item_Image_ID != null)
            {
                if (m_Item_Data.Item_Image_Image_Data != null)
                {
                    try
                    {
                        ImageConverter ic = new ImageConverter();
                        this.pic_Item.Image = (Image)ic.ConvertFrom(m_Item_Data.Item_Image_Image_Data.v);
                        this.pic_Item.Visible = true;
                    }
                    catch
                    {
                    }
                }
            }
            Set_btn_Discount_Text();
        }
        internal void DoPaint(TangentaDB.Item_Data xItem_Data, string[] s_name_Group,usrc_Atom_ItemsList x_usrc_Atom_ItemsList)
        {
            m_Item_Data = xItem_Data;
            m_Item_Data.m_s_name_Group = s_name_Group;
            m_usrc_Atom_ItemsList = x_usrc_Atom_ItemsList;
            RePaint();
        }




        private void Paint_Item_Mode(eMode xeMode)
        {
            Atom_DocInvoice_ShopC_Item_Price_Stock_Data appisd_in_Basket = m_usrc_Atom_ItemsList.m_ShopBC.m_CurrentInvoice.m_Basket.Contains(m_Item_Data);
            int xStart = x0_pic_Item;
            switch (xeMode)
            {
                case eMode.STOCK_AND_FACTORY:
                    if (m_Item_Data.Item_Image_Image_Data!=null)
                    {
                        xStart = x1_btn_EditItem;
                    }
                    pic_Item.Visible = false;
                    btn_EditItem.Visible = true;
                    btn_EditItem.Left = xStart;
                    lbl_Item.Left = xStart + btn_EditItem.Width + 2;
                    lbl_Item.Width = cx_lbl_Item_large_width;
                    if (appisd_in_Basket != null)
                    {
                        btn_Discount.Visible = false;
                        if (appisd_in_Basket.m_ShopShelf_Source.dQuantity_from_stock == 0)
                        {
                            btn_Stock.Visible = true;
                            btn_Stock.Left = xStart;
                            nmUpDn_StockQuantity.Visible = true;
                            nmUpDn_StockQuantity.Left = btn_Stock.Left + btn_Stock.Width + 2;
                            if (appisd_in_Basket.m_ShopShelf_Source.dQuantity_from_factory == 0)
                            {
                                btn_NoStock.Visible = true;
                                btn_NoStock.Left = nmUpDn_StockQuantity.Left + nmUpDn_StockQuantity.Width + 10;
                                nmUpDn_FactoryQuantity.Visible = true;
                                nmUpDn_FactoryQuantity.Left = btn_NoStock.Left + btn_NoStock.Width + 2;
                                Mode = eMode.STOCK_AND_FACTORY;
                            }
                            else
                            {
                                Mode = eMode.STOCK;
                                btn_NoStock.Visible = false;
                                nmUpDn_FactoryQuantity_Hide();
                            }
                        }
                        else
                        {
                            btn_Stock.Visible = false;
                            nmUpDn_StockQuantity.Visible = false;
                            //lbl_InStock.Visible = false;
                            //txt_InStock.Visible = false;

                            lbl_ItemPrice.Left = txt_InStock.Left+2;
                            txt_Price.Left = lbl_ItemPrice.Left + lbl_ItemPrice.Width + 2;
                            btn_Discount.Left = txt_Price.Left + txt_Price.Width + 2;
                            txt_Item_Description.Left = btn_Discount.Left + btn_Discount.Width + 2;

                            if (appisd_in_Basket.m_ShopShelf_Source.dQuantity_from_factory == 0)
                            {
                                Mode = eMode.FACTORY;
                                btn_NoStock.Visible = true;
                                btn_NoStock.Left = xStart;
                                nmUpDn_FactoryQuantity.Visible = true;
                                nmUpDn_FactoryQuantity.Left = btn_NoStock.Left + btn_NoStock.Width + 2;
                                Set_bottom_line();
                            }
                            else
                            {
                                Mode = eMode.NONE;
                                btn_NoStock.Visible = false;
                                nmUpDn_FactoryQuantity_Hide();
                            }
                        }
                    }
                    else
                    {
                        Mode = eMode.STOCK_AND_FACTORY;
                        lbl_ItemPrice.Visible = true;
                        txt_Price.Visible = true;
                        btn_Discount.Visible = true;
                        btn_Stock.Visible = true;
                        btn_Stock.Left = xStart;
                        nmUpDn_StockQuantity.Visible = true;
                        nmUpDn_StockQuantity.Left = btn_Stock.Left + btn_Stock.Width + 2;
                        txt_InStock.Visible = true;
                        lbl_InStock.Visible = true;
                        btn_NoStock.Visible = true;
                        btn_NoStock.Left = nmUpDn_StockQuantity.Left + nmUpDn_StockQuantity.Width + 10;
                        nmUpDn_FactoryQuantity.Visible = true;
                        nmUpDn_FactoryQuantity.Left = btn_NoStock.Left + btn_NoStock.Width + 2;
                        Set_bottom_line();
                    }
                    this.BackColor = DefaultColor;
                    break;

                case eMode.STOCK:
                    this.BackColor = DefaultColor;
                    break;

                case eMode.FACTORY:
                    xStart = x0_pic_Item;
                    if (m_Item_Data.Item_Image_Image_Data!=null)
                    {
                        xStart = x1_btn_EditItem;
                    }
                    pic_Item.Visible = false;
                    btn_EditItem.Visible = true;
                    btn_EditItem.Left = xStart;
                    lbl_Item.Left = xStart + btn_EditItem.Width + 2;
                    lbl_Item.Width = cx_lbl_Item_large_width;
                    lbl_InStock.Visible = false;
                    txt_InStock.Visible = false;
                    lbl_ItemPrice.Left = xStart;
                    txt_Price.Left = lbl_ItemPrice.Left + lbl_ItemPrice.Width + 2;
                    btn_Discount.Left = txt_Price.Left + txt_Price.Width + 2;
                    txt_Item_Description.Left = btn_Discount.Left + btn_Discount.Width + 2;

                    if (appisd_in_Basket != null)
                    {
                        btn_Stock.Visible = false;
                        nmUpDn_StockQuantity.Visible = false;
                        lbl_InStock.Visible = false;
                        txt_InStock.Visible = false;
                        if (appisd_in_Basket.m_ShopShelf_Source.dQuantity_from_factory == 0)
                        {
                            Mode = eMode.FACTORY;
                            btn_NoStock.Visible = true;
                            btn_NoStock.Left = xStart;
                            nmUpDn_FactoryQuantity.Visible = true;
                            nmUpDn_FactoryQuantity.Left = btn_NoStock.Left + btn_NoStock.Width + 2;
                        }
                        else
                        {
                            //Mode = eMode.NONE;
                            btn_NoStock.Visible = false;
                            this.nmUpDn_StockQuantity.Visible = false;
                            //this.nmUpDn_FactoryQuantity.Visible = true;
                            this.nmUpDn_FactoryQuantity.Visible = false;
                        }
                    }
                    else
                    {
                        Mode = eMode.FACTORY;
                        lbl_ItemPrice.Visible = true;
                        txt_Price.Visible = true;
                        btn_Discount.Visible = true;
                        btn_Stock.Visible = false;
                        nmUpDn_StockQuantity.Visible = false;
                        lbl_InStock.Visible = false;
                        txt_InStock.Visible = false;
                        btn_NoStock.Visible = true;
                        btn_NoStock.Left = xStart;
                        nmUpDn_FactoryQuantity.Visible = true;
                        nmUpDn_FactoryQuantity.Left = btn_NoStock.Left + btn_NoStock.Width + 2;
                    }

                    //m_Arrangement.Set(0, btn_NoStock, nmUpDn_FactoryQuantity, m_usrc_Atom_ItemsList.m_InvoiceDB.m_CurrentInvoice.m_Basket.Contains(m_Item_Data));
                    this.BackColor = GlobalData.Color_Factory;
                    break;
            }
        }

        private void Set_bottom_line()
        {
            lbl_InStock.Left = 2;
            txt_InStock.Left = lbl_InStock.Left + lbl_InStock.Width + 2;
            lbl_ItemPrice.Left = txt_InStock.Left + txt_InStock.Width + 2;
            txt_Price.Left = lbl_ItemPrice.Left + lbl_ItemPrice.Width + 2;
            btn_Discount.Left = txt_Price.Left + txt_Price.Width + 2;

            int desc_left_After_btn_Discount = btn_Discount.Left + btn_Discount.Width + 2;
            int desc_left_After_nmUpDn_FactoryQuantity = nmUpDn_FactoryQuantity.Left + nmUpDn_FactoryQuantity.Width + 2;
            int desc_left = 0;
            if (nmUpDn_FactoryQuantity.Visible)
            {
                if (desc_left_After_btn_Discount > desc_left_After_nmUpDn_FactoryQuantity)
                {
                    desc_left = desc_left_After_btn_Discount;
                }
                else
                {
                    desc_left = desc_left_After_nmUpDn_FactoryQuantity;
                }
            }
            else
            {
                desc_left = desc_left_After_btn_Discount;
            }
            txt_Item_Description.Left = desc_left;

        }

        private void nmUpDn_FactoryQuantity_Hide()
        {
            nmUpDn_FactoryQuantity.Visible = false;  
        }

        private void Set_btn_Discount_Text()
        {
            decimal TotalDiscount = StaticLib.Func.TotalDiscount(this.m_Item_Data.Price_Item_Discount.v, ExtraDiscount,GlobalData.Get_BaseCurrency_DecimalPlaces());
            this.btn_Discount.Text = decimal.Round((TotalDiscount * 100), GlobalData.Get_BaseCurrency_DecimalPlaces()).ToString();
        }

        private void Set_txt_Price()
        {

            decimal RetailPriceWithDiscount = 0;
            decimal RetailPriceWithDiscount_WithoutTax = 0;
            decimal TaxPrice = 0;

            int decimal_places = 2;
            if (GlobalData.BaseCurrency != null)
            {
                decimal_places = GlobalData.BaseCurrency.DecimalPlaces;
            }
            StaticLib.Func.CalculatePrice(m_Item_Data.RetailPricePerUnit.v, this.dQuantity, m_Item_Data.Price_Item_Discount.v, ExtraDiscount, m_Item_Data.Taxation_Rate.v, ref RetailPriceWithDiscount, ref  TaxPrice, ref  RetailPriceWithDiscount_WithoutTax, decimal_places);
            decimal EndPrice = decimal.Round(RetailPriceWithDiscount, GlobalData.Get_BaseCurrency_DecimalPlaces());
            this.txt_Price.Text = EndPrice.ToString();
        }



        private void btn_Stock_Click(object sender, EventArgs e)
        {
            //appisd.Set(this, ref m_usrc_Atom_ItemsList.m_InvoiceDB.m_CurrentInvoice.m_Basket.DocInvoice_ShopC_Item_Data_LIST, false);
            Atom_DocInvoice_ShopC_Item_Price_Stock_Data appisd = null;
            m_usrc_Atom_ItemsList.m_ShopBC.m_CurrentInvoice.m_Basket.Add(m_usrc_Atom_ItemsList.m_ShopBC.m_CurrentInvoice.Doc_ID,
                                                                        this,
                                                                        m_Item_Data,
                                                                        nmUpDn_FactoryQuantity.Value,
                                                                        nmUpDn_StockQuantity.Value,
                                                                        ref appisd, false);

            usrc_Atom_Item uia = m_usrc_Atom_ItemsList.AddFromStock(appisd);
            if (uia != null)
            {
                if (ItemAdded2Basket != null)
                {
                    ItemAdded2Basket();
                }
                this.HideStock();
            }
            RePaint();
        }

        private void btn_Factory_Click(object sender, EventArgs e)
        {
            //bool bNew = false;
            if (m_Item_Data.Expiry_ID != null)
            {
                if (EditStock_AvoidStock())
                {
                    Atom_DocInvoice_ShopC_Item_Price_Stock_Data appisd = null;
                    m_usrc_Atom_ItemsList.m_ShopBC.m_CurrentInvoice.m_Basket.Add(m_usrc_Atom_ItemsList.m_ShopBC.m_CurrentInvoice.Doc_ID,
                                                                                   this,
                                                                                   m_Item_Data,
                                                                                   nmUpDn_FactoryQuantity.Value,
                                                                                   nmUpDn_StockQuantity.Value,
                                                                                   ref appisd, true);
                    usrc_Atom_Item uia = m_usrc_Atom_ItemsList.AddFromFactory(appisd);
                    if (uia != null)
                    {
                        if (ItemAdded2Basket != null)
                        {
                            ItemAdded2Basket();
                        }
                        this.HideFactory();
                    }
                }
            }
            else
            {
                Atom_DocInvoice_ShopC_Item_Price_Stock_Data appisd = null;
                m_usrc_Atom_ItemsList.m_ShopBC.m_CurrentInvoice.m_Basket.Add(m_usrc_Atom_ItemsList.m_ShopBC.m_CurrentInvoice.Doc_ID,
                                                                                this,
                                                                                m_Item_Data,
                                                                                nmUpDn_FactoryQuantity.Value,
                                                                                nmUpDn_StockQuantity.Value,
                                                                                ref appisd,
                                                                                true);
                usrc_Atom_Item uia = m_usrc_Atom_ItemsList.AddFromFactory(appisd);
                if (uia != null)
                {
                    ItemAdded2Basket();
                    this.HideFactory();
                }
            }

        }

        private bool EditStock_AvoidStock()
        {
            DateTime_v ExpiryDate_v = m_Item_Data.ExpiryDate;
            if (ExpiryDate_v == null)
            {
                DateTime dtNow = DateTime.Now;
                DateTime dtExpiry = new DateTime(dtNow.Year, dtNow.Month, dtNow.Day);
                dtExpiry = dtExpiry.AddMonths(1);
                ExpiryDate_v = new DateTime_v(dtExpiry);
            }
            Form_Stock_AvoidStock_Edit edt_Stock_AvoidStock_dlg = new Form_Stock_AvoidStock_Edit(ExpiryDate_v, m_Item_Data.Item_UniqueName.v);
            if (edt_Stock_AvoidStock_dlg.ShowDialog() == DialogResult.OK)
            {
                m_Item_Data.ExpiryDate = DateTime_v.Copy(edt_Stock_AvoidStock_dlg.ExpiryDate);
                return true;
            }
            else
            {
                return false;
            }
        }


        private void btn_EditItem_Click(object sender, EventArgs e)
        {
            EditItemStock(nav);
        }

        private void EditItemStock(NavigationButtons.Navigation xnav)
        {
            decimal dCountInBaskets = -1;
            if (m_usrc_ItemList.m_usrc_ItemMan.CountInBaskets(ref dCountInBaskets))
            {
                if (dCountInBaskets == 0)
                {
                    SQLTable tbl_Stock = new SQLTable(DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(Stock)));
                    SQLTable tbl_Item = new SQLTable(DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(Item)));
                    Form_StockItem_Edit edt_ItemStock_dlg = new Form_StockItem_Edit(DBSync.DBSync.DB_for_Tangenta.m_DBTables,
                                                                      tbl_Stock,
                                                                      " where Stock_$_ppi_$_i_$$ID = " + m_Item_Data.Item_ID.v.ToString()+" ",
                                                                      "Stock_$_ppi_$_i_$$Code desc",m_Item_Data, xnav);
                    edt_ItemStock_dlg.ShowDialog();
                    if (edt_ItemStock_dlg.Changed)
                    {
                        if (StockChanged!=null)
                        {
                            StockChanged(m_Item_Data);
                        }
                    }
                }
                else
                {
                    XMessage.Box.Show(this, lng.s_YouCanNotEditStockUntilAllBasketsAreEmpty, "", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1);
                }
            }
        }

        private bool EditItem()
        {
            long ID = m_Item_Data.Item_ID.v;
            SQLTable tbl_Item = new SQLTable(DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(Item)));
            Form_ShopC_Item_Edit edt_Item_dlg = new Form_ShopC_Item_Edit(DBSync.DBSync.DB_for_Tangenta.m_DBTables,
                                                            tbl_Item,
                                                            "Item_$$Code desc", ID,this);
            edt_Item_dlg.ShowDialog();
            if (edt_Item_dlg.Changed)
            {
                if (ItemChanged!=null)
                {
                    ItemChanged(m_Item_Data);
                }
            }
            return true;

        }
        private void btn_Discount_Click(object sender, EventArgs e)
        {
            decimal_v AveragePruchasePricePerUnit = Get_AveragePurchasePricePerUnit();
            if (m_Item_Data.RetailPricePerUnit != null)
            {
                Form_Discount.Form_Discount discount_frm = new Form_Discount.Form_Discount(m_Item_Data.RetailPricePerUnit.v, AveragePruchasePricePerUnit, ExtraDiscount, m_Item_Data.Item_UniqueName.v);
                discount_frm.ShowDialog();
                ExtraDiscount = discount_frm.ExtraDiscount;
                m_Item_Data.ExtraDiscount = ExtraDiscount;
                Set_btn_Discount_Text();
                Set_txt_Price();
            }
            else
            {
                LogFile.Error.Show("ERROR:usrc_Item:btn_Discount_Click:RetailPricePerUnit not defined !");
            }
        }

        private decimal Get_AverageRetailPricePerUnit()
        {
            decimal dcount = 0;
            decimal RetailPricePerUnit_Sum = 0;
            dcount += nmUpDn_FactoryQuantity.Value;
            if (dcount != 0)
            { 
                return RetailPricePerUnit_Sum / dcount;
            }
            else
            {
                LogFile.Error.Show("WARNING:iCount==0");
                return 0;
            }
        }

        private decimal_v Get_AveragePurchasePricePerUnit()
        {
            if (m_Item_Data != null)
            {
                return m_Item_Data.PurchasePricePerUnit;
            }
            else
            {
                return null;
            }
        }

        internal void HideStock()
        {
            this.btn_Stock.Visible = false;
            //this.txt_InStock.Visible = false;
            this.nmUpDn_StockQuantity.Visible = false;
            HideAll();
        }
        internal void HideFactory()
        {
            this.btn_NoStock.Visible = false;
            this.nmUpDn_FactoryQuantity.Visible = false;
            HideAll();
        }

        private void HideAll()
        {
            if (!this.nmUpDn_FactoryQuantity.Visible && !this.nmUpDn_StockQuantity.Visible)
            {
                this.lbl_ItemPrice.Visible = false;
                this.txt_Price.Visible = false;
                btn_Discount.Visible = false;
            }
            else
            {
                this.lbl_ItemPrice.Visible = true;
                this.txt_Price.Visible = true;
                btn_Discount.Visible = true;

            }
        }


        private void nmUpDn_StockQuantity_ValueChanged(object sender, EventArgs e)
        {
            if (this.nmUpDn_StockQuantity.Value != 0)
            {
                this.btn_Stock.Enabled = true;
            }
            else
            {
                this.btn_Stock.Enabled = false;
            }

            Set_txt_Price();
        }

        private void nmUpDn_FactoryQuantity_ValueChanged(object sender, EventArgs e)
        {
            if (this.nmUpDn_FactoryQuantity.Value != 0)
            {
                this.btn_NoStock.Enabled = true;
            }
            else
            {
                this.btn_NoStock.Enabled = false;
            }
            Set_txt_Price();
        }



        private void lbl_Item_Click(object sender, EventArgs e)
        {
            decimal dCountInBaskets = -1;
            if (m_usrc_ItemList.m_usrc_ItemMan.CountInBaskets(ref dCountInBaskets))
            {
                if (dCountInBaskets == 0)
                {
                    EditItem();
                }
                else
                {
                    XMessage.Box.Show(this, lng.s_YouCanNotEditItemsUntilAllBasketsAreEmpty, "", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1);
                }
            }

        }
    }
}
