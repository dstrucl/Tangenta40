﻿#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion
using TangentaDB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TangentaTableClass;
using LanguageControl;

namespace ShopC
{
    public partial class usrc_Atom_Item : UserControl
    {
        public TangentaDB.Atom_DocInvoice_ShopC_Item_Price_Stock_Data m_appisd = null;
        public long Item_ID = -1;
        public delegate void delegate_btn_RemoveClick(usrc_Atom_Item x_usrc_Atom_Item, bool bFactory);
        public event delegate_btn_RemoveClick btn_RemoveClick = null;
        private TangentaDB.ShopABC m_InvoiceDB = null;
        public bool FromFactory = false;
        public bool FromStock = false;
        private decimal dQuantity_FromStock = 0;
        private decimal dQuantity_FromFactory = 0;
        Control[] info_ctrls = null;
        private Control[] ctrla = null;
        private int[] ctrla_left = null;
        private int PictureBox_Width = 0;
        public usrc_Atom_Item()
        {
            InitializeComponent();
            this.lbl_RetailPriceText.Text = lng.s_RetailPrice.s;
            this.lbl_DiscountText.Text = lng.s_Discount.s;
            this.lbl_Quantity.Text = lng.s_Quantity.s;
            this.lbl_WithoutTaxPrice.Text = lng.s_WithoutTaxPrice.s;
            this.lbl_TaxPrice.Text = lng.s_TaxPrice.s;
            this.lbl_RetailPriceWithDiscount.Text = lng.s_RetailPriceWithDiscount.s;
            ctrla = new Control[this.Controls.Count];
            ctrla_left= new int[this.Controls.Count];
            info_ctrls = new Control[] { lbl_Quantity, lbl_RetailPriceText, lbl_DiscountText, lbl_Quantity_Value, lbl_RetailPriceValue, lbl_DiscountValue, lbl_WithoutTaxPrice, lbl_TaxPrice, lbl_RetailPriceWithDiscount, txt_NetPrice, txt_TaxPrice, txt_RetailSimpleItemPriceWithDiscount };
            for (int i = 0; i < this.Controls.Count; i++)
            {
                ctrla[i] = this.Controls[i];
                ctrla_left[i] = ctrla[i].Left;
                if (ctrla[i].Name.Equals("btn_pic_Image"))
                {
                    PictureBox_Width = ctrla[i].Width;
                }
            }

        }

        internal void DoPaint(TangentaDB.ShopABC xInvoiceDB, Atom_DocInvoice_ShopC_Item_Price_Stock_Data appisd)
        {
            //appisd.Set(m_dr);
            m_InvoiceDB = xInvoiceDB;
            m_appisd = appisd;
            this.lbl_Item.Text = appisd.Atom_Item_UniqueName.v;
            if (appisd.Atom_Item_Image_Data != null)
            {
                try
                {
                    ImageConverter ic = new ImageConverter();
                    this.btn_pic_Image.Image = (Image)ic.ConvertFrom(appisd.Atom_Item_Image_Data.v);
                    this.btn_pic_Image.Text = "";
                    int ctrla_Count = ctrla.Count();
                    for (int i=0;i<ctrla_Count;i++)
                    {
                        if (ctrla[i].Name.Equals("btn_pic_Image"))
                        {
                            ctrla[i].Visible = true;
                            continue;
                        }
                        else
                        {
                            ctrla[i].Left = ctrla_left[i];
                        }
                    }

                }
                catch
                {
                }
            }
            else
            {
                this.btn_pic_Image.Image = null;
                this.btn_pic_Image.Text = "?";
                int ctrla_Count = ctrla.Count();
                for (int i = 0; i < ctrla_Count; i++)
                {
                    if (ctrla[i].Name.Equals("btn_pic_Image"))
                    {
                        ctrla[i].Visible = false;
                        continue;
                    }
                    else
                    {
                        ctrla[i].Left = ctrla_left[i] - PictureBox_Width;
                    }
                }
            }

            decimal Discount = 0;
            decimal ExtraDiscount = 0;
            decimal RetailPrice = 0;
            decimal RetailPriceWithDiscount = 0;
            decimal TaxPrice = 0;
            string TaxName = null;
            decimal TaxRate = 0;

            decimal NetPrice = 0;
            GetPrices(appisd,
                        ref  Discount,
                        ref  ExtraDiscount,
                        ref  RetailPrice,
                        ref  RetailPriceWithDiscount,
                        ref  TaxPrice,
                        ref TaxName,
                        ref  TaxRate,
                        ref  NetPrice);

            this.txt_RetailSimpleItemPriceWithDiscount.Text = RetailPriceWithDiscount.ToString();
            this.txt_TaxPrice.Text = TaxPrice.ToString();
            this.txt_NetPrice.Text = NetPrice.ToString();

            dQuantity_FromStock = appisd.dQuantity_FromStock;
            dQuantity_FromFactory = appisd.dQuantity_FromFactory;

            this.txt_FromStockCount.Text = dQuantity_FromStock.ToString();//m_Item_Data.nmUpDn_StockQuantity_Value.ToString();
            this.txt_FromFactoryCount.Text = dQuantity_FromFactory.ToString();//m_Item_Data.nmUpDn_FactoryQuantity_Value.ToString();

            this.lbl_RetailPriceValue.Text = RetailPrice.ToString();

            string unit_symbol = null;
            if (appisd.Atom_Unit_Symbol!=null)
            {
                unit_symbol = appisd.Atom_Unit_Symbol.v;
            }
            if (unit_symbol == null)
            {
                unit_symbol = "";
            }

            FromStock = dQuantity_FromStock > 0;
            FromFactory = dQuantity_FromFactory > 0;

            decimal dQuantity_all = dQuantity_FromStock + dQuantity_FromFactory;
            this.lbl_Quantity_Value.Text = dQuantity_all.ToString() + " " + unit_symbol;

            int FromStock_Width = 0;
            if (FromStock)
            {
                this.txt_FromStockCount.Text = dQuantity_FromStock.ToString();
                this.txt_FromStockCount.Visible = true;
                this.btn_RemoveFromBasketToStock.Visible = true;
            }
            else
            {
                FromStock_Width = this.btn_RemoveFromBasketToStock.Width+2; 
                this.txt_FromStockCount.Visible = false;
                this.btn_RemoveFromBasketToStock.Visible = false;
            }

            int FromFactory_Width = 0;

            if (FromFactory)
            {
                this.txt_FromFactoryCount.Text = dQuantity_FromFactory.ToString();
                this.txt_FromFactoryCount.Visible = true;
                this.btn_RemoveFromBasketToFactory.Visible = true;
            }
            else
            {
                FromFactory_Width = this.btn_RemoveFromBasketToFactory.Width+2;
                this.txt_FromFactoryCount.Visible = false;
                this.btn_RemoveFromBasketToFactory.Visible = false;
            }

            set_offset(btn_RemoveFromBasketToFactory, FromStock_Width);
            set_offset(txt_FromFactoryCount, FromStock_Width);

            int ioffs = FromStock_Width+FromFactory_Width;
            set_offset(ioffs);


            decimal TotalDiscount = StaticLib.Func.TotalDiscount(Discount, ExtraDiscount,GlobalData.Get_BaseCurrency_DecimalPlaces());

            if (TotalDiscount > 0)
            {
                decimal percent = TotalDiscount * 100;
                this.lbl_DiscountValue.Text = percent.ToString() + "%";
                this.lbl_DiscountText.Visible = true;
                this.lbl_DiscountValue.Visible = true;
            }
            else
            {
                this.lbl_DiscountValue.Visible = false;
                this.lbl_DiscountText.Visible = false;
            }

            if (m_InvoiceDB.m_CurrentInvoice.bDraft)
            {
                this.btn_RemoveFromBasketToFactory.Enabled = true;
                this.btn_RemoveFromBasketToStock.Enabled = true;
            }
            else
            {
                this.btn_RemoveFromBasketToFactory.Enabled = false;
                this.btn_RemoveFromBasketToStock.Enabled = false;
            }


        }

        private void set_offset(int ioffs)
        {
            int iCount = ctrla.Count();
            for (int i=0; i<iCount; i++)
            {
                int jCount = info_ctrls.Count();
                for (int j=0; j<jCount; j++)
                {
                    if (ctrla[i] == info_ctrls[j])
                    {
                        ctrla[i].Left = ctrla[i].Left - ioffs;
                    }
                }
            }
        }

        private void set_offset(Control ctrl,int ioffs)
        {
            int iCount = ctrla.Count();
            for (int i = 0; i < iCount; i++)
            {
                if (ctrla[i] == ctrl)
                {
                    ctrla[i].Left = ctrla[i].Left - ioffs;
                }
            }
        }

        internal void GetPrices(TangentaDB.Atom_DocInvoice_ShopC_Item_Price_Stock_Data appisd,
                                ref decimal Discount, ref decimal ExtraDiscount, ref decimal RetailPrice, ref decimal RetailPriceWithDiscount,
                                ref decimal TaxPrice,
                                ref string TaxName,
                                ref decimal TaxRate,
                                ref decimal NetPrice)
        {
            decimal dquantity_all = 0;
            decimal RetailPricePerUnit = 0;
            int i = 0;
            int iCount = appisd.m_ShopShelf_Source.Stock_Data_List.Count;
            Discount = appisd.Discount.v;
            ExtraDiscount = appisd.ExtraDiscount.v;
            RetailPricePerUnit = appisd.RetailPricePerUnit.v;
            TaxRate = appisd.Atom_Taxation_Rate.v;
            if (TaxName == null)
            {
                TaxName = appisd.Atom_Taxation_Name.v;
            }

            if (iCount > 0)
            {
                for (i = 0; i < iCount; i++)
                {
                    Stock_Data stock_data = appisd.m_ShopShelf_Source.Stock_Data_List[i];
                    if (stock_data.Stock_ID!=null)
                    { 
                        dquantity_all += stock_data.dQuantity_from_stock.v;
                    }
                    else
                    {
                        dquantity_all += stock_data.dQuantity_from_factory.v;
                    }
                }
                RetailPrice = RetailPricePerUnit * dquantity_all;
                int decimal_places = 2;
                if (GlobalData.BaseCurrency != null)
                {
                    decimal_places = GlobalData.BaseCurrency.DecimalPlaces;
                }
                StaticLib.Func.CalculatePrice(RetailPricePerUnit, dquantity_all, Discount, ExtraDiscount, TaxRate, ref RetailPriceWithDiscount, ref TaxPrice, ref NetPrice, decimal_places);
            }
        }



        internal bool SameItem(long xitem_id)
        {
            if (xitem_id == Item_ID)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void btn_Stock_Click(object sender, EventArgs e)
        {

        }

        private void btn_Stock_Return_Click(object sender, EventArgs e)
        {

        }

        private void lbl_Price_Click(object sender, EventArgs e)
        {

        }

        private void btn_RemoveFromBasketToStock_Click(object sender, EventArgs e)
        {
            if (btn_RemoveClick != null)
            {
                btn_RemoveClick(this,false);
            }
        }

        private void btn_RemoveFromBasketToFactory_Click(object sender, EventArgs e)
        {
            if (btn_RemoveClick != null)
            {
                btn_RemoveClick(this, true);
            }
        }

        private void btn_EditItem_Click(object sender, EventArgs e)
        {

        }

        private void btn_pic_Image_Click(object sender, EventArgs e)
        {
            Form_Atom_Item_View itma_frm = new Form_Atom_Item_View(m_InvoiceDB,this.m_appisd.Atom_Item_ID.v);
            itma_frm.ShowDialog();
        }

        private void lbl_Item_Click(object sender, EventArgs e)
        {
            Form_Atom_Item_View itma_frm = new Form_Atom_Item_View(m_InvoiceDB, this.m_appisd.Atom_Item_ID.v);
            itma_frm.ShowDialog();
        }
    }
}
