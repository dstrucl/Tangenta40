﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BlagajnaTableClass;

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

        internal void Fill(ref Atom_ItemShopA_Price m_Atom_ItemShopA_Price)
        {
            m_Atom_ItemShopA_Price.EndPriceWithDiscountAndTax.set(nm_Price.Value);

        }
        internal void Fill(ref Atom_ItemShopA_Price m_Atom_ItemShopA_Price, decimal calculated_end_price)
        {
            this.nm_Price.Value = calculated_end_price;
            Fill(ref m_Atom_ItemShopA_Price);

        }
    }
}
