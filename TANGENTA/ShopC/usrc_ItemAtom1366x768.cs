#region LICENSE 
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
using usrc_Item_InsidePage_Handler;

namespace ShopC
{
    public partial class usrc_Atom_Item1366x768 : UserControl
    {
        public TangentaDB.Atom_DocInvoice_ShopC_Item_Price_Stock_Data m_appisd = null;

        public long Item_ID = -1;

        public delegate void delegate_btn_RemoveClick(TangentaDB.Atom_DocInvoice_ShopC_Item_Price_Stock_Data appisd);
        public event delegate_btn_RemoveClick btn_RemoveClick = null;


        private TangentaDB.ShopABC m_InvoiceDB = null;
        public bool FromFactory = false;
        public bool FromStock = false;
        private decimal dQuantity_FromStock = 0;
        private decimal dQuantity_FromFactory = 0;
        private int[] ctrla_left = null;
        private int PictureBox_Width = 0;

        public string Item_UniqueName
        {
            get
            {
                return lbl_Item_UniqueName.Text;
            }
            internal set
            {
                lbl_Item_UniqueName.Text = value; 
            }
        }

        public usrc_Atom_Item1366x768()
        {
            InitializeComponent();
            this.lbl_DiscountText.Text = lng.s_Discount.s;
        }

        internal void SelectControl(object oData, bool selected)
        {
            if (selected)
            {
                this.BackColor = ColorSettings.Sheme.Current().Colorpair[4].BackColor;
            }
            else
            {
                this.BackColor = ColorSettings.Sheme.Current().Colorpair[5].BackColor;
            }
        }


        internal void DoPaint(Atom_DocInvoice_ShopC_Item_Price_Stock_Data appisd, usrc_Item_InsidePageHandler.eMode emode)
        {
            m_appisd = appisd;
            if (emode== usrc_Item_InsidePageHandler.eMode.EDIT)
            {
                btn_RemoveFromBasket.Visible = true;
            }
            else
            {
                btn_RemoveFromBasket.Visible = false;
            }

            if (appisd.Atom_Item_UniqueName != null)
            {
                this.Item_UniqueName = appisd.Atom_Item_UniqueName.v;
            }
            string sunit = "";
            if (appisd.Atom_Unit_Symbol!=null)
            {
                sunit = appisd.Atom_Unit_Symbol.v;
            }

            decimal Discount = 0;
            decimal ExtraDiscount = 0;
            decimal RetailPrice = 0;
            decimal RetailPriceWithDiscount = 0;
            decimal TaxPrice = 0;
            string TaxName = null;
            decimal TaxRate = 0;

            decimal NetPrice = 0;
            m_appisd.GetPrices(
                        ref Discount,
                        ref ExtraDiscount,
                        ref RetailPrice,
                        ref RetailPriceWithDiscount,
                        ref TaxPrice,
                        ref TaxName,
                        ref TaxRate,
                        ref NetPrice);

            decimal dquantityall = -1;
            if (appisd.dQuantity_all!=null)
            {
                dquantityall = appisd.dQuantity_all.v;
                lbl_Quantity_Value.Text = dquantityall.ToString() + " " + sunit;
                lbl_Quantity_Value.Visible = true;
            }
            else
            {
                lbl_Quantity_Value.Visible = false;
            }


            lbl_RetailPriceValue.Text = LanguageControl.DynSettings.SetLanguageCurrencyString(RetailPriceWithDiscount, GlobalData.BaseCurrency.DecimalPlaces, GlobalData.BaseCurrency.Symbol);
            lbl_RetailPriceValue.Visible = true;

            decimal discount = 0;
            if (appisd.Discount!=null)
            {
                discount = appisd.Discount.v;
            }
            decimal extradiscount = 0;
            if (appisd.ExtraDiscount != null)
            {
                extradiscount = appisd.ExtraDiscount.v;
            }
            decimal dTotalDiscount = discount + extradiscount - discount * extradiscount;
            lbl_DiscountValue.Text = Global.f.GetPercent(dTotalDiscount, 3)+"%";
        }

        private void lbl_Item_Click(object sender, EventArgs e)
        {
            Form_Atom_Item_View itma_frm = new Form_Atom_Item_View(m_InvoiceDB, this.m_appisd.Atom_Item_ID);
            itma_frm.ShowDialog();
        }

        private void btn_RemoveFromBasket_Click(object sender, EventArgs e)
        {
            if (btn_RemoveClick!=null)
            {
                btn_RemoveClick(m_appisd);
            }
        }
    }
}
