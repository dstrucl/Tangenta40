﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InvoiceDB;

namespace ShopA
{
    public partial class usrc_Editor : UserControl
    {
        public usrc_Editor()
        {
            InitializeComponent();
        }

        private void usrc_Edit_Item_Name2_Load(object sender, EventArgs e)
        {

        }

        internal void Init(ShopABC m_ShopBC)
        {
            this.usrc_Edit_Item_Tax1.Init(m_ShopBC.m_xTaxationList);
        }
    }
}
