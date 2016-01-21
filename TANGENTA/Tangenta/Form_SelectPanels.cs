﻿using System;
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
            rdb_ItemsAndProformaInvoices.Checked = false;
            rdb_ProformaInvoices.Checked = false;
            m_usrc_InvoiceMan = x_usrc_InvoiceMan;
            if (m_usrc_InvoiceMan.Mode == usrc_InvoiceMan.eMode.Items)
            {
                rdb_Items.Checked = true;
            }
            else if (m_usrc_InvoiceMan.Mode == usrc_InvoiceMan.eMode.Items_and_ProformaInvoices)
            {
                rdb_ItemsAndProformaInvoices.Checked = true;
            }
            else if (m_usrc_InvoiceMan.Mode == usrc_InvoiceMan.eMode.ProformaInvoices)
            {
                rdb_ProformaInvoices.Checked = true;
            }
            else
            {
                LogFile.Error.Show("ERROR:Form_SelectPanels:m_usrc_InvoiceMan.Mode illegal Mode!");
            }

            this.rdb_ProformaInvoices.CheckedChanged += new System.EventHandler(this.rdb_ProformaInvoices_CheckedChanged);
            this.rdb_ItemsAndProformaInvoices.CheckedChanged += new System.EventHandler(this.rdb_ItemsAndProformaInvoices_CheckedChanged);
            this.rdb_Items.CheckedChanged += new System.EventHandler(this.rdb_Items_CheckedChanged);

        }

        private void rdb_Items_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_Items.Checked)
            {
                m_usrc_InvoiceMan.SetMode(usrc_InvoiceMan.eMode.Items);
            }
            Close();
            DialogResult = DialogResult.OK;
        }

        private void rdb_ItemsAndProformaInvoices_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_ItemsAndProformaInvoices.Checked)
            {
                m_usrc_InvoiceMan.SetMode(usrc_InvoiceMan.eMode.Items_and_ProformaInvoices);
                if (m_usrc_InvoiceMan.Customer_Changed)
                {
                    m_usrc_InvoiceMan.Customer_Changed = false;
                    m_usrc_InvoiceMan.m_usrc_InvoiceTable.Init(m_usrc_InvoiceMan.m_usrc_Invoice.eInvoiceType, false, Properties.Settings.Default.FinancialYear);
                }
            }
            Close();
            DialogResult = DialogResult.OK;
        }

        private void rdb_ProformaInvoices_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_ProformaInvoices.Checked)
            {
                m_usrc_InvoiceMan.SetMode(usrc_InvoiceMan.eMode.ProformaInvoices);
                if (m_usrc_InvoiceMan.Customer_Changed)
                {
                    m_usrc_InvoiceMan.Customer_Changed = false;
                    m_usrc_InvoiceMan.m_usrc_InvoiceTable.Init(m_usrc_InvoiceMan.m_usrc_Invoice.eInvoiceType, false, Properties.Settings.Default.FinancialYear);
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