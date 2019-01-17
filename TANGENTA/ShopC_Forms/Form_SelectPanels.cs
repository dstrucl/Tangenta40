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
using TangentaProperties;

namespace ShopC_Forms
{
    public partial class Form_SelectPanels : Form
    {
        private ConsumptionMan consM = null;
        private SettingsUserValues mSettingsUserValues = null;

        public Form_SelectPanels(ConsumptionMan xconsM)
        {
            InitializeComponent();
            consM = xconsM;
            Init();

        }


        private void Init()
        {
            rdb_Items.Checked = false;
            rdb_ItemsAndDoc.Checked = false;
            rdb_Doc.Checked = false;
            if (consM != null)
            {
                if (consM.Mode == ConsumptionMan.eMode.Shops)
                {
                    rdb_Items.Checked = true;
                }
                else if (consM.Mode == ConsumptionMan.eMode.Shops_and_InvoiceTable)
                {
                    rdb_ItemsAndDoc.Checked = true;
                }
                else if (consM.Mode == ConsumptionMan.eMode.InvoiceTable)
                {
                    rdb_Doc.Checked = true;
                }
                else
                {
                    LogFile.Error.Show("ERROR:Form_SelectPanels:((usrc_DocumentMan)o_usrc_DocumentMan).Mode illegal Mode!");
                }
            }
            else if (consM != null)
            {
                if (consM.Mode == ConsumptionMan.eMode.Shops)
                {
                    rdb_Items.Checked = true;
                }
                else if (consM.Mode == ConsumptionMan.eMode.Shops_and_InvoiceTable)
                {
                    rdb_ItemsAndDoc.Checked = true;
                }
                else if (consM.Mode == ConsumptionMan.eMode.InvoiceTable)
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
                consM.SetMode(ConsumptionMan.eMode.Shops);
            }
            Close();
            DialogResult = DialogResult.OK;
        }

        private void rdb_ItemsAndDoc_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_ItemsAndDoc.Checked)
            {
                consM.SetMode(ConsumptionMan.eMode.Shops_and_InvoiceTable);
                if (consM.Customer_Changed)
                {
                    consM.Customer_Changed = false;
                    consM.Delegate_control_TableOfDocuments_Init(consM, false,false, mSettingsUserValues.FinancialYear,null);
                }
            }
            Close();
            DialogResult = DialogResult.OK;
        }

        private void rdb_Doc_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_Doc.Checked)
            {
                consM.SetMode(ConsumptionMan.eMode.InvoiceTable);
                if (consM.Customer_Changed)
                {
                    consM.Customer_Changed = false;
                    consM.Delegate_control_TableOfDocuments_Init(consM, false,false, mSettingsUserValues.FinancialYear,null);
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
            //this.Top = ((usrc_DocumentMan)o_usrc_DocumentMan).btn_SelectPanels.Top + ((usrc_DocumentMan)o_usrc_DocumentMan).btn_SelectPanels.Height;
            //this.Left = ((usrc_DocumentMan)o_usrc_DocumentMan).btn_SelectPanels.Left;
        }
    }
}
