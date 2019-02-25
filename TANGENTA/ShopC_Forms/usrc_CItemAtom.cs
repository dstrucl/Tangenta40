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

namespace ShopC_Forms
{
    public partial class usrc_Atom_CItem : UserControl
    {
        public TangentaDB.Consumption_ShopC_Item m_csci = null;

        public long Item_ID = -1;

        public delegate void delegate_btn_RemoveClick(TangentaDB.Consumption_ShopC_Item xdsci);
        public event delegate_btn_RemoveClick btn_RemoveClick = null;

        public bool FromFactory = false;
        public bool FromStock = false;

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

        public new event EventHandler<EventArgs> Click;

        protected override void OnClick(EventArgs e)
        {
            EventArgs myArgs = new EventArgs();
            EventHandler<EventArgs> myEvent = Click;
            if (myEvent != null)
                myEvent(this, myArgs);
            base.OnClick(e);
        }

        public usrc_Atom_CItem()
        {
            InitializeComponent();
            lng.s_PurchasePricePerUnit.Text(lbl_PurchasePricePerUnitWithoutDiscount);
            lng.s_PurchaseDiscount.Text(lbl_PurchasePriceDiscount);
            lng.s_PurchasePriceWithDiscount.Text(lbl_PurchasePrice);
            lng.s_Quantity.Text(lbl_Quantity);

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

        internal void DoRefresh()
        {
            if (m_csci.Item_UniqueName_v != null)
            {
                this.Item_UniqueName = m_csci.Item_UniqueName_v.v;
            }
            string sunit = "";
            if (m_csci.Unit_Symbol_v != null)
            {
                sunit = m_csci.Unit_Symbol_v.v;
            }


            if (m_csci.dQuantity_all > 0)
            {
                decimal PurchasePrice = 0;
                decimal PurchasePriceWithDiscount = 0;
                decimal TaxPrice = 0;
                decimal NetPrice = 0;
                decimal m_csci_PurchasePricePerUnit_all = m_csci.PurchasePricePerUnit * m_csci.dQuantity_all;
                txt_PurchasePricePerUnitWithoutDiscount.Text = LanguageControl.DynSettings.SetLanguageCurrencyString(m_csci.PurchasePricePerUnit, GlobalData.BaseCurrency.DecimalPlaces, GlobalData.BaseCurrency.Symbol);
                decimal purchasePricePerUnit_Discount = 0;
                if (m_csci.PurchasePricePerUnit_Discount !=-1)
                {
                    purchasePricePerUnit_Discount = 0;
                }


                m_csci.dsciS_List.GetPrices(0,
                                        purchasePricePerUnit_Discount,
                                        0,
                                        m_csci_PurchasePricePerUnit_all,
                                        ref PurchasePrice,
                                        ref PurchasePriceWithDiscount,
                                        ref TaxPrice,
                                        ref NetPrice
                                        );
           
                this.txt_Quantity.Text = m_csci.dQuantity_all.ToString() + " " + sunit;
                lbl_PurchasePriceDiscount.Visible = true;
          


                this.txt_PurchasePriceWithDiscount.Text = LanguageControl.DynSettings.SetLanguageCurrencyString(PurchasePriceWithDiscount, GlobalData.BaseCurrency.DecimalPlaces, GlobalData.BaseCurrency.Symbol);
                this.lbl_PurchasePrice.Visible = true;

                decimal dTotalDiscount = m_csci.PurchasePricePerUnit_Discount;
                txt_PurchasePriceDiscount.Text = Global.f.GetPercent(purchasePricePerUnit_Discount, GlobalData.BaseCurrency.DecimalPlaces) + "%";
            }
            else
            {
                lbl_PurchasePriceDiscount.Visible = false;
            }
        }

        internal void DoPaint(TangentaDB.Consumption_ShopC_Item xdsci, usrc_CItem_InsidePageHandler_Consumption_ShopC_Item.eMode emode)
        {
            m_csci = xdsci;
            if (emode== usrc_CItem_InsidePageHandler_Consumption_ShopC_Item.eMode.EDIT)
            {
                btn_RemoveFromBasket.Visible = true;
            }
            else
            {
                btn_RemoveFromBasket.Visible = false;
            }
            DoRefresh();
        }

        private void lbl_Item_Click(object sender, EventArgs e)
        {
            OnClick(e);
        }

        private void btn_RemoveFromBasket_Click(object sender, EventArgs e)
        {
            RemoveFromBasket();
        }

        internal void RemoveFromBasket()
        {
            if (btn_RemoveClick != null)
            {
                btn_RemoveClick(m_csci);
            }
        }

        private void lbl_Quantity_Value_Click(object sender, EventArgs e)
        {
            OnClick(e);
        }

        private void lbl_RetailPriceValue_Click(object sender, EventArgs e)
        {
            OnClick(e);
        }

        private void lbl_DiscountText_Click(object sender, EventArgs e)
        {
            OnClick(e);
        }

        private void lbl_DiscountValue_Click(object sender, EventArgs e)
        {
            OnClick(e);
        }
    }
}
