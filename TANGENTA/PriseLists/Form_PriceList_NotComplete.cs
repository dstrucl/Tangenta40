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
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LanguageControl;

namespace PriseLists
{
    public partial class Form_PriceList_NotComplete : Form
    {
        private DataTable m_dt_Item;
        private char m_chShop;
        public Form_PriceList_NotComplete(char xchShop, DataTable dt_Item, Control pparent_ctrl)
        {
            InitializeComponent();
            m_chShop = xchShop;
            m_dt_Item = dt_Item;
            //this.Parent = pparent_ctrl;
            this.Text = lng.s_Pricelist_is_not_complete.s;
            btn_Cancel.Text = lng.s_Cancel.s;
            btn_OK.Text = lng.s_OK.s;
            if (dt_Item.Rows.Count > 0)
            {
                if (m_chShop == 'B')
                {
                    this.dgvx_Item_Not_in_Pricelist.DataSource = m_dt_Item;
                    this.dgvx_Item_Not_in_Pricelist.Columns["PriceList"].HeaderText = lng.s_PriceList.s;
                    this.dgvx_Item_Not_in_Pricelist.Columns["Name"].HeaderText = lng.s_Name.s;
                    lbl_Item_Not_in_PriceList.Text = lng.s_SimpleItem_Not_in_PriceList.s;
                }
                else if (m_chShop == 'C')
                {
                    this.dgvx_Item_Not_in_Pricelist.DataSource = m_dt_Item;
                    this.dgvx_Item_Not_in_Pricelist.Columns["PriceList"].HeaderText = lng.s_PriceList.s;
                    this.dgvx_Item_Not_in_Pricelist.Columns["UniqueName"].HeaderText = lng.s_UniqueName.s;
                    lbl_Item_Not_in_PriceList.Text = lng.s_Item_Not_in_PriceList.s;
                }
            }
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            Close();
            DialogResult = DialogResult.OK;

        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Close();
            DialogResult = DialogResult.Cancel;
        }

        private void PriceList_NotComplete_Form_Load(object sender, EventArgs e)
        {
        }

    }
}
