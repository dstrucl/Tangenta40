#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion

using LanguageControl;
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
    public partial class Form_ShopsInUse : Form
    {
        private usrc_Main m_usrc_Main;


        public Form_ShopsInUse(usrc_Main xusrc_Main)
        {
            InitializeComponent();
            lngRPM.s_Shops_In_Use.Text(this);
            lngRPM.s_chk_A_in_use.Text(chk_A_in_use);
            lngRPM.s_chk_B_in_use.Text(chk_B_in_use);
            lngRPM.s_chk_C_in_use.Text(chk_C_in_use);
            lngRPM.s_lbl_ShopA_Name.Text(lbl_ShopA_Name);
            lngRPM.s_lbl_ShopB_Name.Text(lbl_ShopB_Name);
            lngRPM.s_lbl_ShopC_Name.Text(lbl_ShopC_Name);
            wb1.DocumentText = Properties.Resources.SLO_Help_Shops_in_use;
            string shinuse = Program.Shops_in_use;
            lngRPM.s_Shop_A.Text(txt_ShopA_Name);
            lngRPM.s_Shop_B.Text(txt_ShopB_Name);
            lngRPM.s_Shop_C.Text(txt_ShopC_Name);
            chk_A_in_use.Checked = false;
            chk_B_in_use.Checked = false;
            chk_C_in_use.Checked = false;
            if (shinuse.Contains("A"))
            {
                chk_A_in_use.Checked = true;
            }
            if (shinuse.Contains("B"))
            {
                chk_B_in_use.Checked = true;
            }
            if (shinuse.Contains("C"))
            {
                chk_C_in_use.Checked = true;
            }
            this.m_usrc_Main = xusrc_Main;
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            string shinuse = "";
            if (chk_A_in_use.Checked)
            {
                shinuse += "A";
            }
            if (chk_B_in_use.Checked)
            {
                shinuse += "B";
            }
            if (chk_C_in_use.Checked)
            {
                shinuse += "C";
            }
            if (shinuse.Length==0)
            {
                MessageBox.Show(this, lngRPM.s_Warning.s, lngRPM.s_YouMustSelectAtLeastOneShop.s, MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return;
            }
            lngRPM.s_Shop_A.sText(DynSettings.LanguageID,txt_ShopA_Name.Text);
            lngRPM.s_Shop_B.sText(DynSettings.LanguageID,txt_ShopB_Name.Text);
            lngRPM.s_Shop_C.sText(DynSettings.LanguageID,txt_ShopC_Name.Text);
            DynSettings.LanguageTextSave();
            Properties.Settings.Default.eShopsInUse = shinuse;
            Properties.Settings.Default.Save();
            if (m_usrc_Main!=null)
            {
                if (m_usrc_Main.m_usrc_InvoiceMan !=null)
                {
                    if (m_usrc_Main.m_usrc_InvoiceMan.m_usrc_Invoice!=null)
                    {
                        if (m_usrc_Main.m_usrc_InvoiceMan.m_usrc_Invoice.DBtcn != null)
                        {
                            m_usrc_Main.m_usrc_InvoiceMan.m_usrc_Invoice.Set_eShopsMode(shinuse);
                        }
                    }
                }
            }
            this.Close();
            DialogResult = DialogResult.OK;
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
            DialogResult = DialogResult.Cancel;
        }
    }
}
