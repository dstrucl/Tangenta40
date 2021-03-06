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
using System.Threading.Tasks;
using System.Windows.Forms;
using TangentaTableClass;

namespace ShopA
{
    public partial class usrc_Edit_Item_Price : UserControl
    {
        public delegate void delegate_ValueChanged(decimal d);
        public event delegate_ValueChanged ValueChanged;

        public decimal Price
        {
            get
            {
                return nm_Price.Value;
            }
        }
        public usrc_Edit_Item_Price()
        {
            InitializeComponent();
            nm_Price.ValueChanged += Nm_Price_ValueChanged;
            lng.s_lbl_Item_Price.Text(lbl_Item_Price);
        }

        private void Nm_Price_ValueChanged(object sender, EventArgs e)
        {
            if (ValueChanged!=null)
            {
                ValueChanged(nm_Price.Value);
            }
        }

        internal void set(decimal dPrice)
        {
            nm_Price.ValueChanged -= Nm_Price_ValueChanged;
            nm_Price.Value = dPrice;
            nm_Price.ValueChanged += Nm_Price_ValueChanged;
        }

        internal void Fill(ref DocInvoice_ShopA_Item m_DocInvoice_ShopA_Item)
        {
            m_DocInvoice_ShopA_Item.EndPriceWithDiscountAndTax.set(nm_Price.Value);

        }
        internal void Fill(ref DocInvoice_ShopA_Item m_DocInvoice_ShopA_Item, decimal calculated_end_price)
        {
            this.nm_Price.Value = calculated_end_price;
            Fill(ref m_DocInvoice_ShopA_Item);

        }

        internal void Clear()
        {
            this.nm_Price.ResetText();
        }
    }
}
