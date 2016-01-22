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
        private DataTable m_dt_SimpleItem;
        private DataTable m_dt_Item;
        public Form_PriceList_NotComplete(DataTable dt_SimpleItem, DataTable dt_Item ,Form pparent)
        {
            InitializeComponent();
            m_dt_SimpleItem = dt_SimpleItem;
            m_dt_Item = dt_Item;
            this.Owner = pparent;
            this.Text = lngRPM.s_Pricelist_is_not_complete.s;
            btn_Cancel.Text = lngRPM.s_Cancel.s;
            btn_OK.Text = lngRPM.s_OK.s;
            if (m_dt_SimpleItem.Rows.Count > 0)
            {
                this.dgvx_SimpleItem_Not_in_Pricelist.DataSource = m_dt_SimpleItem;
                this.dgvx_SimpleItem_Not_in_Pricelist.Columns["PriceList"].HeaderText = lngRPM.s_PriceList.s;
                this.dgvx_SimpleItem_Not_in_Pricelist.Columns["Name"].HeaderText = lngRPM.s_Name.s;
                this.splitContainer1.Panel1Collapsed = false;
                lbl_SimpleItem_Not_in_PriceList.Text = lngRPM.s_SimpleItem_Not_in_PriceList.s;
            }
            else
            {
                this.splitContainer1.Panel1Collapsed = true;
            }
            if (m_dt_Item.Rows.Count > 0)
            {
                this.dgvx_Item_Not_in_PriceList.DataSource = m_dt_Item;
                this.dgvx_Item_Not_in_PriceList.Columns["PriceList"].HeaderText = lngRPM.s_PriceList.s;
                this.dgvx_Item_Not_in_PriceList.Columns["UniqueName"].HeaderText = lngRPM.s_UniqueName.s;
                this.dgvx_Item_Not_in_PriceList.Columns["Name"].HeaderText = lngRPM.s_Name.s;
                this.splitContainer1.Panel2Collapsed = false;
                lbl_Item_Not_in_PriceList.Text = lngRPM.s_Item_Not_in_PriceList.s;
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
