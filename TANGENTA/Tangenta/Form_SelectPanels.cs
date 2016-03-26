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
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tangenta
{
    public partial class Form_SelectPanels : Form
    {
        usrc_InvoiceMan m_usrc_InvoiceMan = null;
        public Form_SelectPanels(usrc_InvoiceMan x_usrc_InvoiceMan)
        {
            InitializeComponent();
            rdb_Items.Checked = false;
            rdb_ItemsAndDocInvoices.Checked = false;
            rdb_DocInvoices.Checked = false;
            m_usrc_InvoiceMan = x_usrc_InvoiceMan;
            if (m_usrc_InvoiceMan.Mode == usrc_InvoiceMan.eMode.Shops)
            {
                rdb_Items.Checked = true;
            }
            else if (m_usrc_InvoiceMan.Mode == usrc_InvoiceMan.eMode.Shops_and_InvoiceTable)
            {
                rdb_ItemsAndDocInvoices.Checked = true;
            }
            else if (m_usrc_InvoiceMan.Mode == usrc_InvoiceMan.eMode.InvoiceTable)
            {
                rdb_DocInvoices.Checked = true;
            }
            else
            {
                LogFile.Error.Show("ERROR:Form_SelectPanels:m_usrc_InvoiceMan.Mode illegal Mode!");
            }

            this.rdb_DocInvoices.CheckedChanged += new System.EventHandler(this.rdb_DocInvoices_CheckedChanged);
            this.rdb_ItemsAndDocInvoices.CheckedChanged += new System.EventHandler(this.rdb_ItemsAndDocInvoices_CheckedChanged);
            this.rdb_Items.CheckedChanged += new System.EventHandler(this.rdb_Items_CheckedChanged);

        }

        private void rdb_Items_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_Items.Checked)
            {
                m_usrc_InvoiceMan.SetMode(usrc_InvoiceMan.eMode.Shops);
            }
            Close();
            DialogResult = DialogResult.OK;
        }

        private void rdb_ItemsAndDocInvoices_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_ItemsAndDocInvoices.Checked)
            {
                m_usrc_InvoiceMan.SetMode(usrc_InvoiceMan.eMode.Shops_and_InvoiceTable);
                if (m_usrc_InvoiceMan.Customer_Changed)
                {
                    m_usrc_InvoiceMan.Customer_Changed = false;
                    m_usrc_InvoiceMan.m_usrc_InvoiceTable.Init(m_usrc_InvoiceMan.m_usrc_Invoice.eInvoiceType, false,false, Properties.Settings.Default.FinancialYear);
                }
            }
            Close();
            DialogResult = DialogResult.OK;
        }

        private void rdb_DocInvoices_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_DocInvoices.Checked)
            {
                m_usrc_InvoiceMan.SetMode(usrc_InvoiceMan.eMode.InvoiceTable);
                if (m_usrc_InvoiceMan.Customer_Changed)
                {
                    m_usrc_InvoiceMan.Customer_Changed = false;
                    m_usrc_InvoiceMan.m_usrc_InvoiceTable.Init(m_usrc_InvoiceMan.m_usrc_Invoice.eInvoiceType, false,false, Properties.Settings.Default.FinancialYear);
                }
            }
            Close();
            DialogResult = DialogResult.OK;
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Close();
            DialogResult = DialogResult.OK;
        }

        private void Form_SelectPanels_Load(object sender, EventArgs e)
        {
            this.Top = m_usrc_InvoiceMan.btn_SelectPanels.Top + m_usrc_InvoiceMan.btn_SelectPanels.Height;
            this.Left = m_usrc_InvoiceMan.btn_SelectPanels.Left;
        }
    }
}
