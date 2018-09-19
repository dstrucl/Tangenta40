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
        private usrc_DocumentMan m_usrc_DocumentMan = null;
        private usrc_DocumentMan1366x768 m_usrc_DocumentMan1366x768 = null;
        private SettingsUserValues mSettingsUserValues = null;

        public Form_SelectPanels(usrc_DocumentMan x_usrc_DocumentMan, SettingsUserValues xSettingsUserValues)
        {
            InitializeComponent();
            mSettingsUserValues = xSettingsUserValues;
            m_usrc_DocumentMan = x_usrc_DocumentMan;
            Init();

        }

        public Form_SelectPanels(usrc_DocumentMan1366x768 x_usrc_DocumentMan1366x768, SettingsUserValues xSettingsUserValues)
        {
            InitializeComponent();
            mSettingsUserValues = xSettingsUserValues;
            m_usrc_DocumentMan1366x768 = x_usrc_DocumentMan1366x768;
            Init();

        }

        private void Init()
        {
            rdb_Items.Checked = false;
            rdb_ItemsAndDoc.Checked = false;
            rdb_Doc.Checked = false;
            if (m_usrc_DocumentMan != null)
            {
                if (m_usrc_DocumentMan.Mode == usrc_DocumentMan.eMode.Shops)
                {
                    rdb_Items.Checked = true;
                }
                else if (m_usrc_DocumentMan.Mode == usrc_DocumentMan.eMode.Shops_and_InvoiceTable)
                {
                    rdb_ItemsAndDoc.Checked = true;
                }
                else if (m_usrc_DocumentMan.Mode == usrc_DocumentMan.eMode.InvoiceTable)
                {
                    rdb_Doc.Checked = true;
                }
                else
                {
                    LogFile.Error.Show("ERROR:Form_SelectPanels:m_usrc_DocumentMan.Mode illegal Mode!");
                }
            }
            else if (m_usrc_DocumentMan1366x768 != null)
            {
                if (m_usrc_DocumentMan1366x768.DocM.Mode == DocumentMan.eMode.Shops)
                {
                    rdb_Items.Checked = true;
                }
                else if (m_usrc_DocumentMan1366x768.DocM.Mode == DocumentMan.eMode.Shops_and_InvoiceTable)
                {
                    rdb_ItemsAndDoc.Checked = true;
                }
                else if (m_usrc_DocumentMan1366x768.DocM.Mode == DocumentMan.eMode.InvoiceTable)
                {
                    rdb_Doc.Checked = true;
                }
                else
                {
                    LogFile.Error.Show("ERROR:Form_SelectPanels:m_usrc_DocumentMan1366x768.Mode illegal Mode!");
                }
            }

            this.rdb_Doc.CheckedChanged += new System.EventHandler(this.rdb_Doc_CheckedChanged);
            this.rdb_ItemsAndDoc.CheckedChanged += new System.EventHandler(this.rdb_ItemsAndDoc_CheckedChanged);
            this.rdb_Items.CheckedChanged += new System.EventHandler(this.rdb_Items_CheckedChanged);

        }
        private void rdb_Items_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_Items.Checked)
            {
                m_usrc_DocumentMan.SetMode(usrc_DocumentMan.eMode.Shops);
            }
            Close();
            DialogResult = DialogResult.OK;
        }

        private void rdb_ItemsAndDoc_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_ItemsAndDoc.Checked)
            {
                m_usrc_DocumentMan.SetMode(usrc_DocumentMan.eMode.Shops_and_InvoiceTable);
                if (m_usrc_DocumentMan.Customer_Changed)
                {
                    m_usrc_DocumentMan.Customer_Changed = false;
                    m_usrc_DocumentMan.m_usrc_TableOfDocuments.Init(m_usrc_DocumentMan.m_usrc_DocumentEditor.DocTyp, false,false, mSettingsUserValues.FinancialYear,null);
                }
            }
            Close();
            DialogResult = DialogResult.OK;
        }

        private void rdb_Doc_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_Doc.Checked)
            {
                m_usrc_DocumentMan.SetMode(usrc_DocumentMan.eMode.InvoiceTable);
                if (m_usrc_DocumentMan.Customer_Changed)
                {
                    m_usrc_DocumentMan.Customer_Changed = false;
                    m_usrc_DocumentMan.m_usrc_TableOfDocuments.Init(m_usrc_DocumentMan.m_usrc_DocumentEditor.DocTyp, false,false, mSettingsUserValues.FinancialYear,null);
                }
            }
            Close();
            DialogResult = DialogResult.OK;
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Close();
            DialogResult = DialogResult.Cancel;
        }

        private void Form_SelectPanels_Load(object sender, EventArgs e)
        {
            this.Top = m_usrc_DocumentMan.btn_SelectPanels.Top + m_usrc_DocumentMan.btn_SelectPanels.Height;
            this.Left = m_usrc_DocumentMan.btn_SelectPanels.Left;
        }
    }
}
