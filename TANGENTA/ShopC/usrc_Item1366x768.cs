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
using DBConnectionControl40;
using DynEditControls;

namespace ShopC
{
    public partial class usrc_Item1366x768 : UserControl
    {
        public delegate void delegate_ItemAdded2Basket();
        public event delegate_ItemAdded2Basket ItemAdded2Basket = null;

        public delegate void delegate_ItemChanged(object obj);
        public event delegate_ItemChanged ItemChanged = null;

        public delegate void delegate_StockChanged(object obj);
        public event delegate_StockChanged StockChanged = null;

        //usrc_ItemList
        private bool m_bExclusivelySellFromStock = false;

        private ID m_Atom_WorkPeriod_ID = null;

        public bool ExclusivelySellFromStock
        {
            get { return m_bExclusivelySellFromStock; }
            set { m_bExclusivelySellFromStock = value;
                if (m_bExclusivelySellFromStock)
                {
                    //if (uItemFactory != null)
                    //{
                    //    uItemFactory.Visible = false;
                    //}
                }
                else
                {
                    //if (uItemFactory != null)
                    //{
                    //    uItemFactory.Visible = true;
                    //}
                }
            }
        }
        public string PriceText
        {
            get
            {
                return uItemStock.Label2;
            }
            set
            {
                uItemStock.Label2 = value;
            }
        }
        public TangentaDB.Item_Data m_Item_Data = null;

        bool disposed = false;

        public enum eMode { STOCK, FACTORY, STOCK_AND_FACTORY,NONE }
        public eMode Mode = eMode.STOCK_AND_FACTORY;

        public usrc_Atom_ItemsList1366x768 m_usrc_Atom_ItemsList = null;
        public usrc_ItemList1366x768 m_usrc_ItemList = null;

        public decimal ExtraDiscount = 0;
        public usrc_Atom_Item m_usrc_Atom_Item = null;
        private Color DefaultColor = Color.Gray;

        private int x0_pic_Item_Left = 0;
        private int x1_lbl_Item_Left = 0;

        private int x1_btn_EditItem_Left = 0;

        private int x2_uItemFactory_Left = 0;
        private int x2_uItemFactory_Top = 0;
        private int x2_uItemFactory_Height = 0;
        private int x2_uItemFactory_Width = 0;

        private int x2_uItemStock_Left = 0;
        private int x2_uItemStock_Top = 0;
        private int x2_uItemStock_Height = 0;
        private int x2_uItemStock_Width = 0;



        private int cx_lbl_Item_large_width = 0;
        private int cx_lbl_Item_small_width = 0;
        public NavigationButtons.Navigation nav = null;

        public usrc_Item1366x768()
        {
            InitializeComponent();
        }

        public usrc_Item1366x768(ID xAtom_WorkPeriod_ID)
        {
            InitializeComponent();
            m_Atom_WorkPeriod_ID = xAtom_WorkPeriod_ID;
            uItemStock.Label1 = lng.s_lbl_Cost.s;
            uItemStock.Label3 = lng.s_Quantity.s;
            uItemStock.Label5 = lng.s_StockShort.s;

            //uItemFactory.PriceLabelText = lng.s_lbl_Cost.s;
            //uItemFactory.QuantityText = lng.s_Quantity.s;
            //uItemFactory.StockLabelText = "";
            //uItemFactory.StockText = "";

            //x0_pic_Item_Left = pic_Item.Left;

            //x1_lbl_Item_Left = lbl_Item.Left;

            //x1_btn_EditItem_Left = btn_EditItem.Left;


            //x2_uItemFactory_Left = uItemFactory.Left;
            //x2_uItemFactory_Top = uItemFactory.Top;
            //x2_uItemFactory_Height = uItemFactory.Height;
            //x2_uItemFactory_Width = uItemFactory.Width;

            x2_uItemStock_Left = uItemStock.Left;
            x2_uItemStock_Top = uItemStock.Top;
            x2_uItemStock_Height = uItemStock.Height;
            x2_uItemStock_Width = uItemStock.Width;

            //cx_lbl_Item_small_width = lbl_Item.Width;
            cx_lbl_Item_large_width = cx_lbl_Item_small_width + x1_btn_EditItem_Left - x0_pic_Item_Left;
            
            DefaultColor = BackColor;
        }


        // Protected implementation of Dispose pattern. 
        protected override void Dispose(bool disposing)
        {
            if (disposed)
                return;

            this.uItemStock.ValueChanged -=  (System.EventHandler)this.uItemStock_ValueChanged;
//            this.uItemFactory.ValueChanged -= (System.EventHandler) this.uItemFactory_ValueChanged;
            this.btn_Discount.Click -= (System.EventHandler)this.btn_Discount_Click;
//            this.btn_EditItem.Click -=  (System.EventHandler)this.btn_EditItem_Click;
//            this.uItemFactory.Click -= (System.EventHandler) this.uItemFactory_Click;
            this.uItemStock.Click -= (System.EventHandler) this.uItemStock_Click;

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
//                        return GetValue(uItemStock) + GetValue(uItemFactory);

                    case eMode.STOCK:
 //                       return GetValue(uItemStock);

                    case eMode.FACTORY:
//                        return GetValue(uItemFactory);

                    case eMode.NONE:
                        return 0;

                    default:
                        LogFile.Error.Show("ERROR:usrc_Item:dQuantity:Invalid Mode !");
                        return 0;
                }
            }
        }

        private decimal GetValue(usrc_btn_Item uItem)
        {
            if (uItem.Visible)
            {
                return uItemStock.Value;
            }
            else
            {
                return 0;
            }
        }

        private void setNumericUpDown(ref usrc_btn_Item uItem, object DecimalPlaces)
        {
            uItem.DecimalPlaces = Convert.ToInt32(DecimalPlaces);
            decimal dincrement = fs.Increment(DecimalPlaces);
            uItem.Increment = dincrement;
            uItem.Minimum = dincrement;
            uItem.Value = dincrement;
        }

        private void RePaint()
        {
            decimal dAllStockQuantity = 0;

            dAllStockQuantity = m_Item_Data.dQuantity_OfStockItems;

            if (dAllStockQuantity > 0)
            {

                uItemStock.Maximum = Convert.ToDecimal(dAllStockQuantity);
                //setNumericUpDown(ref uItemStock, m_Item_Data.Unit_DecimalPlaces.v);
                uItemStock.Maximum = Convert.ToDecimal(dAllStockQuantity);
                //setNumericUpDown(ref uItemFactory, m_Item_Data.Unit_DecimalPlaces.v);
                //uItemFactory.Minimum = 0;
                //uItemFactory.Value = 0;
                Paint_Item_Mode(eMode.STOCK_AND_FACTORY);
            }
            else
            {
                //setNumericUpDown(ref uItemStock, m_Item_Data.Unit_DecimalPlaces.v);
                uItemStock.Minimum = 0;
                uItemStock.Value = 0;
                //setNumericUpDown(ref uItemFactory, m_Item_Data.Unit_DecimalPlaces.v);
                //uItemFactory.Minimum = 0;
                //uItemFactory.Value = 0;
                //uItemFactory.Maximum = decimal.MaxValue;
                Paint_Item_Mode(eMode.FACTORY);
            }

            //StockText = dAllStockQuantity.ToString();

            if (m_Item_Data.Item_UniqueName != null)
            {
                //this.lbl_Item.Text = m_Item_Data.Item_UniqueName.v;
            }
            if (m_Item_Data.Item_Description != null)
            {
                //this.txt_Item_Description.Text = m_Item_Data.Item_Description.v;
            }


            Set_txt_Price();

            if (m_Item_Data.Item_Image_ID != null)
            {
                if (m_Item_Data.Item_Image_Image_Data != null)
                {
                    try
                    {
                        // ImageConverter ic = new ImageConverter();
                        //                        this.pic_Item.Image = (Image)ic.ConvertFrom(m_Item_Data.Item_Image_Image_Data.v);
                        //                        this.pic_Item.Visible = true;
                    }
                    catch
                    {
                    }
                }
            }
            Set_btn_Discount_Text();
        }
        internal void DoPaint(TangentaDB.Item_Data xItem_Data, string[] s_name_Group,usrc_Atom_ItemsList1366x768 x_usrc_Atom_ItemsList)
        {
            m_Item_Data = xItem_Data;
            m_Item_Data.m_s_name_Group = s_name_Group;
            m_usrc_Atom_ItemsList = x_usrc_Atom_ItemsList;
            RePaint();
        }




        private void Paint_Item_Mode(eMode xeMode)
        {
            if (m_usrc_Atom_ItemsList != null)
            {
                if (m_usrc_Atom_ItemsList.m_ShopBC != null)
                {
                    if (m_usrc_Atom_ItemsList.m_ShopBC.m_CurrentDoc != null)
                    {
                        if (m_usrc_Atom_ItemsList.m_ShopBC.m_CurrentDoc.m_Basket != null)
                        {
                            Atom_DocInvoice_ShopC_Item_Price_Stock_Data appisd_in_Basket = m_usrc_Atom_ItemsList.m_ShopBC.m_CurrentDoc.m_Basket.Contains(m_Item_Data);
                            int xStart = x0_pic_Item_Left;
                            switch (xeMode)
                            {
                                case eMode.STOCK_AND_FACTORY:
                                    if (m_Item_Data.Item_Image_Image_Data != null)
                                    {
                                        xStart = x1_lbl_Item_Left;
                                    }
                                    //pic_Item.Visible = false;
                                    //lbl_Item.Left = xStart + 2;
                                    //lbl_Item.Width = cx_lbl_Item_large_width;
                                    if (appisd_in_Basket != null)
                                    {
                                        btn_Discount.Visible = false;
                                        if (appisd_in_Basket.m_ShopShelf_Source.dQuantity_from_stock == 0)
                                        {
                                            uItemStock.Visible = true;
                                            uItemStock.Left = xStart;
                                            if (appisd_in_Basket.m_ShopShelf_Source.dQuantity_from_factory == 0)
                                            {
                                                if (!ExclusivelySellFromStock)
                                                {
                                                    //uItemFactory.Visible = true;
                                                    //uItemFactory.Left = uItemStock.Left + uItemStock.Width + 10;
                                                }

                                                Mode = eMode.STOCK_AND_FACTORY;
                                            }
                                            else
                                            {
                                                Mode = eMode.STOCK;
//                                                uItemFactory.Visible = false;
                                                nmUpDn_FactoryQuantity_Hide();
                                            }
                                        }
                                        else
                                        {
                                            uItemStock.Visible = false;
                                            //txt_Item_Description.Left = btn_Discount.Left + btn_Discount.Width + 2;

                                            if (appisd_in_Basket.m_ShopShelf_Source.dQuantity_from_factory == 0)
                                            {
                                                Mode = eMode.FACTORY;
                                                if (!ExclusivelySellFromStock)
                                                {
                                                    //uItemFactory.Visible = true;
                                                    //uItemFactory.Left = xStart;
                                                    //uItemFactory.Top = x2_uItemStock_Top;
                                                    //uItemFactory.Width = x2_uItemStock_Width;
                                                    //uItemFactory.Height = x2_uItemStock_Height;
                                                }
                                            }
                                            else
                                            {
                                                Mode = eMode.NONE;
//                                                uItemFactory.Visible = false;
                                                nmUpDn_FactoryQuantity_Hide();
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Mode = eMode.STOCK_AND_FACTORY;
                                        btn_Discount.Visible = true;
                                        uItemStock.Visible = true;
                                        uItemStock.Left = xStart;

                                        if (!ExclusivelySellFromStock)
                                        {
                                        //    uItemFactory.Visible = true;
                                        //    uItemFactory.Top = x2_uItemStock_Top;
                                        //    uItemFactory.Width = x2_uItemStock_Width;
                                        //    uItemFactory.Height = x2_uItemStock_Height;
                                        //    uItemFactory.Left = uItemStock.Left + uItemStock.Width + 10;
                                        }
                                    }
                                    this.BackColor = Colors.ItemFromStock.BackColor;
                                    this.ForeColor = Colors.ItemFromStock.ForeColor;
                                    break;

                                case eMode.STOCK:
                                    this.BackColor = Colors.ItemFromStock.BackColor;
                                    this.ForeColor = Colors.ItemFromStock.ForeColor;
                                    break;

                                case eMode.FACTORY:
                                    xStart = x0_pic_Item_Left;
                                    if (m_Item_Data.Item_Image_Image_Data != null)
                                    {
                                        xStart = x1_btn_EditItem_Left;
                                    }
                                    //pic_Item.Visible = false;
                                    //lbl_Item.Left = xStart + 2;
                                    //lbl_Item.Width = cx_lbl_Item_large_width;
                                    //txt_Item_Description.Left = btn_Discount.Left + btn_Discount.Width + 2;

                                    if (appisd_in_Basket != null)
                                    {
                                        uItemStock.Visible = false;
                                        if (appisd_in_Basket.m_ShopShelf_Source.dQuantity_from_factory == 0)
                                        {
                                            Mode = eMode.FACTORY;
                                            //uItemFactory.Visible = true;
                                            //uItemFactory.Left = xStart;
                                        }
                                        else
                                        {
                                            //Mode = eMode.NONE;
//                                            uItemFactory.Visible = false;
                                        }
                                    }
                                    else
                                    {
                                        Mode = eMode.FACTORY;
                                        btn_Discount.Visible = true;
                                        uItemStock.Visible = false;
                                        if (!ExclusivelySellFromStock)
                                        {
                                            //uItemFactory.Visible = true;
                                            //uItemFactory.Left = xStart;
                                            //uItemFactory.Top = x2_uItemStock_Top;
                                            //uItemFactory.Width = x2_uItemStock_Width;
                                            //uItemFactory.Height = x2_uItemStock_Height;
                                        }
                                    }
                                    //m_Arrangement.Set(0, uItemFactory, nmUpDn_FactoryQuantity, m_usrc_Atom_ItemsList.m_InvoiceDB.m_CurrentInvoice.m_Basket.Contains(m_Item_Data));
                                    this.BackColor = Colors.ItemFromFactory.BackColor;
                                    this.ForeColor = Colors.ItemFromFactory.ForeColor;

                                    break;
                            }
                            ShowPriceAndDiscount();
                        }
                    }
                }
            }
        }

        private void ShowPriceAndDiscount()
        {
            if ((uItemStock.Visible)  /*||(uItemFactory.Visible)*/)
            {
                btn_Discount.Visible = true;
                if (true /*uItemFactory.Visible */)
                {
                    //btn_Discount.Left = uItemFactory.Left + uItemFactory.Width + 2;
                    //txt_Item_Description.Left = btn_Discount.Left;
                    btn_Discount.Width = this.Width - btn_Discount.Left - 4;
                    //txt_Item_Description.Width = this.Width - txt_Item_Description.Left - 4;
                }
                else if (uItemStock.Visible)
                {
                    btn_Discount.Left = uItemStock.Left + uItemStock.Width + 2;
                    //txt_Item_Description.Left = btn_Discount.Left;
                    btn_Discount.Width = this.Width - btn_Discount.Left - 4;
                    //txt_Item_Description.Width = this.Width - txt_Item_Description.Left - 4;
                }
            }
            else
            {
                btn_Discount.Visible = false;
                // txt_Item_Description.Visible = false;
            }
        }

        private void nmUpDn_FactoryQuantity_Hide()
        {
           //uItemFactory.Visible = false;  
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

            decimal dquantity = this.dQuantity;
            if (ExclusivelySellFromStock)
            {
               //dquantity = GetValue(uItemStock);
            }      
            StaticLib.Func.CalculatePrice(m_Item_Data.RetailPricePerUnit.v, dquantity, m_Item_Data.Price_Item_Discount.v, ExtraDiscount, m_Item_Data.Taxation_Rate.v, ref RetailPriceWithDiscount, ref TaxPrice, ref RetailPriceWithDiscount_WithoutTax, decimal_places);
            
            decimal EndPrice = decimal.Round(RetailPriceWithDiscount, GlobalData.Get_BaseCurrency_DecimalPlaces());
            if (uItemStock.Visible)
            {
                PriceText = EndPrice.ToString();
            }
            //if (uItemFactory.Visible)
            //{
            //    uItemFactory.PriceText = EndPrice.ToString();
            //}
        }



        private void uItemStock_Click(object sender, EventArgs e)
        {
            Atom_DocInvoice_ShopC_Item_Price_Stock_Data appisd = null;
            //m_usrc_Atom_ItemsList.m_ShopBC.m_CurrentDoc.m_Basket.Add(m_usrc_Atom_ItemsList.m_ShopBC.m_CurrentDoc.Doc_ID,
            //                                                            this,
            //                                                            m_Item_Data,
            //                                                            uItemFactory.Value,
            //                                                            uItemStock.Value,
            //                                                            ref appisd, false);

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

        private void uItemFactory_Click(object sender, EventArgs e)
        {
            if (ID.Validate(m_Item_Data.Item_Expiry_ID))
            {
                if (EditStock_AvoidStock())
                {
                    Atom_DocInvoice_ShopC_Item_Price_Stock_Data appisd = null;
                    //m_usrc_Atom_ItemsList.m_ShopBC.m_CurrentDoc.m_Basket.Add(m_usrc_Atom_ItemsList.m_ShopBC.m_CurrentDoc.Doc_ID,
                    //                                                               this,
                    //                                                               m_Item_Data,
                    //                                                               uItemFactory.Value,
                    //                                                               uItemStock.Value,
                    //                                                               ref appisd, true);
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
                //m_usrc_Atom_ItemsList.m_ShopBC.m_CurrentDoc.m_Basket.Add(m_usrc_Atom_ItemsList.m_ShopBC.m_CurrentDoc.Doc_ID,
                //                                                                this,
                //                                                                m_Item_Data,
                //                                                                uItemFactory.Value,
                //                                                                uItemStock.Value,
                //                                                                ref appisd,
                //                                                                true);
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
                    Form_StockItem_Edit edt_ItemStock_dlg = new Form_StockItem_Edit(m_Atom_WorkPeriod_ID,DBSync.DBSync.DB_for_Tangenta.m_DBTables,
                                                                      tbl_Stock,
                                                                      " where Stock_$_ppi_$_i_$$ID = " + m_Item_Data.Item_ID.ToString()+" ",
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
            ID ID = m_Item_Data.Item_ID;
            SQLTable tbl_Item = new SQLTable(DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(Item)));
            Form_ShopC_Item_Edit edt_Item_dlg = new Form_ShopC_Item_Edit(DBSync.DBSync.DB_for_Tangenta.m_DBTables,
                                                            tbl_Item,
                                                            "Item_$$Code desc", ID,this);
            edt_Item_dlg.ShowDialog(Global.f.GetParentForm(this));
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
//            dcount += uItemFactory.Value;
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
            this.uItemStock.Visible = false;
            HideAll();
        }
        internal void HideFactory()
        {
            //this.uItemFactory.Visible = false;
            HideAll();
        }

        private void HideAll()
        {
            if (/*!this.uItemFactory.Visible && */ !this.uItemStock.Visible)
            {
                btn_Discount.Visible = false;
                //txt_Item_Description.Visible = false;
            }
            else
            {
                btn_Discount.Visible = true;
                //txt_Item_Description.Visible = true;
            }
        }


        private void uItemStock_ValueChanged(object sender, EventArgs e)
        {

            Set_txt_Price();
        }

        private void uItemFactory_ValueChanged(object sender, EventArgs e)
        {
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
