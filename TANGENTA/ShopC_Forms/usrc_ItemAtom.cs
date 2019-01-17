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
    public partial class usrc_Atom_Item : UserControl
    {
        public TangentaDB.Doc_ShopC_Item m_dsci = null;

        public long Item_ID = -1;

        public delegate void delegate_btn_RemoveClick(TangentaDB.Doc_ShopC_Item xdsci);
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

        internal void DoRefresh()
        {
            if (m_dsci.Atom_Item_UniqueName_v != null)
            {
                this.Item_UniqueName = m_dsci.Atom_Item_UniqueName_v.v;
            }
            string sunit = "";
            if (m_dsci.Atom_Unit_Symbol_v != null)
            {
                sunit = m_dsci.Atom_Unit_Symbol_v.v;
            }

         
            decimal RetailPrice = 0;
            decimal RetailPriceWithDiscount = 0;
            decimal TaxPrice = 0;
            decimal NetPrice = 0;

            m_dsci.dsciS_List.GetPrices(m_dsci.TaxationRate,
                                        m_dsci.Discount,
                                        m_dsci.ExtraDiscount,
                                        m_dsci.RetailPricePerUnit,
                                        ref RetailPrice,
                                        ref RetailPriceWithDiscount,
                                        ref TaxPrice,
                                        ref NetPrice
                                        );
            
            if (m_dsci.dQuantity_all > 0)
            {
                lbl_Quantity_Value.Text = m_dsci.dQuantity_all.ToString() + " " + sunit;
                lbl_Quantity_Value.Visible = true;
            }
            else
            {
                lbl_Quantity_Value.Visible = false;
            }


            lbl_RetailPriceValue.Text = LanguageControl.DynSettings.SetLanguageCurrencyString(RetailPriceWithDiscount, GlobalData.BaseCurrency.DecimalPlaces, GlobalData.BaseCurrency.Symbol);
            lbl_RetailPriceValue.Visible = true;

            decimal dTotalDiscount = m_dsci.Discount + m_dsci.ExtraDiscount - m_dsci.Discount * m_dsci.ExtraDiscount;
            lbl_DiscountValue.Text = Global.f.GetPercent(m_dsci.TotalDiscount, GlobalData.BaseCurrency.DecimalPlaces) + "%";

        }

        internal void DoPaint(Doc_ShopC_Item xdsci, usrc_Item_InsidePageHandler<Doc_ShopC_Item>.eMode emode)
        {
            m_dsci = xdsci;
            if (emode== usrc_Item_InsidePageHandler<Doc_ShopC_Item>.eMode.EDIT)
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
                btn_RemoveClick(m_dsci);
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
