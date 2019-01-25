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

namespace ShopC_Forms
{
    public partial class usrc_CItem : UserControl
    {

        public new event EventHandler<EventArgs> Click;

        protected override void OnClick(EventArgs e)
        {
            EventArgs myArgs = new EventArgs();
            EventHandler<EventArgs> myEvent = Click;
            if (myEvent != null)
                myEvent(this, myArgs);
            base.OnClick(e);
        }

        //public delegate void delegate_ItemAdded2Basket();
        //public event delegate_ItemAdded2Basket ItemAdded2Basket = null;

        //public delegate void delegate_ItemChanged(object obj);
        //public event delegate_ItemChanged ItemChanged = null;

        //public delegate void delegate_StockChanged(object obj);
        //public event delegate_StockChanged StockChanged = null;

        //usrc_ItemList
        private bool m_bExclusivelySellFromStock = false;


        public bool ExclusivelySellFromStock
        {
            get { return m_bExclusivelySellFromStock; }
            set { m_bExclusivelySellFromStock = value;
            }
        }

        public TangentaDB.Item_Data m_Item_Data = null;

        bool disposed = false;



        internal void SelectControl(Item_Data iData, bool selected)
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

        public NavigationButtons.Navigation nav = null;

        public usrc_CItem()
        {
            InitializeComponent();
        }

        // Protected implementation of Dispose pattern. 
        protected override void Dispose(bool disposing)
        {
            if (disposed)
                return;

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


        public string Item_UniqueName
        {
            get
            {
                return this.lbl_Item_UniqueName.Text;
            }
            internal set
            {
                this.lbl_Item_UniqueName.Text = value; 
            }
        }


        internal void DoPaint(Item_Data idata, BasketConsumption xBasket)
        {
            if (idata != null)
            {
                if (idata.Item_UniqueName_v != null)
                {
                    this.Item_UniqueName = idata.Item_UniqueName_v.v;
                }

                decimal dAllStockQuantity = 0;

                if (xBasket!=null)
                {
                    if (xBasket.IsInBasket(this.Item_UniqueName))
                    {
                        this.picInBasket.Visible = true;
                    }
                    else
                    {
                        this.picInBasket.Visible = false;
                    }
                }
                dAllStockQuantity = idata.dQuantity_OfStockItems;

                string sunit = "";
                if (idata.Unit_Symbol_v!=null)
                {
                    sunit = idata.Unit_Symbol_v.v;
                }

                
                if (dAllStockQuantity > 0)
                {
                    
                    lbl_InStock.Text = lng.s_StockShort.s + ":" + dAllStockQuantity.ToString()+" "+ sunit;
                    lbl_InStock.Visible = true;
                }
                else
                {
                    lbl_InStock.Visible = false;
                }

                decimal dRetailPricePerUnit = -1;
                if (idata.RetailPricePerUnit_v!=null)
                {
                    dRetailPricePerUnit = idata.RetailPricePerUnit_v.v;
                    lbl_Price.Text = LanguageControl.DynSettings.SetLanguageCurrencyString(dRetailPricePerUnit, GlobalData.BaseCurrency.DecimalPlaces, GlobalData.BaseCurrency.Symbol);
                    lbl_Price.Visible = true;
                }
                else
                {
                    lbl_Price.Visible = false;
                }
            }
        }

        private void lbl_Item_UniqueName_Click(object sender, EventArgs e)
        {
            OnClick(e);
        }

        private void lbl_Price_Click(object sender, EventArgs e)
        {
            OnClick(e);
        }

        private void lbl_InStock_Click(object sender, EventArgs e)
        {
            OnClick(e);
        }

        private void picInBasket_Click(object sender, EventArgs e)
        {
            OnClick(e);
        }
    }
}
