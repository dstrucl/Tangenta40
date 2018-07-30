using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LanguageControl;

namespace Tangenta
{
    public partial class usrc_ShopsInuse : UserControl
    {
        public SettingsUserValues mSettingsUserValues = null;
        public usrc_ShopsInuse()
        {
            InitializeComponent();
            lng.s_Shops_In_Use.Text(grp_ShopsInUse);
            lng.s_chk_A_in_use.Text(chk_A_in_use);
            lng.s_chk_B_in_use.Text(chk_B_in_use);
            lng.s_chk_C_in_use.Text(chk_C_in_use);
            lng.s_lbl_ShopA_Name.Text(lbl_ShopA_Name);
            lng.s_lbl_ShopB_Name.Text(lbl_ShopB_Name);
            lng.s_lbl_ShopC_Name.Text(lbl_ShopC_Name);
            string shinuse = Program.Shops_in_use;
            lng.s_Shop_A.Text(txt_ShopA_Name);
            lng.s_Shop_B.Text(txt_ShopB_Name);
            lng.s_Shop_C.Text(txt_ShopC_Name);
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
        }

        internal bool do_OK()
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
            if (shinuse.Length == 0)
            {
                MessageBox.Show(this, lng.s_YouMustSelectAtLeastOneShop.s, lng.s_Warning.s,  MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return false;
            }
            lng.s_Shop_A.sText(DynSettings.LanguageID, txt_ShopA_Name.Text);
            lng.s_Shop_B.sText(DynSettings.LanguageID, txt_ShopB_Name.Text);
            lng.s_Shop_C.sText(DynSettings.LanguageID, txt_ShopC_Name.Text);
            ShopA.lng.s_ShopA_Name.sText(DynSettings.LanguageID, txt_ShopA_Name.Text);
            ShopB.lng.s_ShopB_Name.sText(DynSettings.LanguageID, txt_ShopB_Name.Text);
            ShopC.lng.s_ShopC_Name.sText(DynSettings.LanguageID, txt_ShopC_Name.Text);

            DynSettings.LanguageTextSave();
            if (mSettingsUserValues == null)
            {
                Properties.Settings.Default.eShopsInUse = shinuse;
                Properties.Settings.Default.Save();
            }
            else
            {
                mSettingsUserValues.eShopsInUse = shinuse;
            }
            return true;
        }
    }
}
