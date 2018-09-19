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
    public partial class usrc_ShopsInUse : UserControl
    {
        private SettingsUserValues m_SettingsUserValues = null;
        public SettingsUserValues SettingsUserValues
        {
            get {
                return m_SettingsUserValues;
                }
            set
            {
                m_SettingsUserValues = value;
            }
        }

        public usrc_ShopsInUse()
        {
            InitializeComponent();
            lng.s_Shops_In_Use.Text(grp_ShopsInUse);
            lng.s_chk_A_in_use.Text(chk_A_in_use);
            lng.s_chk_B_in_use.Text(chk_B_in_use);
            lng.s_chk_C_in_use.Text(chk_C_in_use);
            lng.s_lbl_ShopA_Name.Text(lbl_ShopA_Name);
            lng.s_lbl_ShopB_Name.Text(lbl_ShopB_Name);
            lng.s_lbl_ShopC_Name.Text(lbl_ShopC_Name);
            lng.s_Shop_A.Text(txt_ShopA_Name);
            lng.s_Shop_B.Text(txt_ShopB_Name);
            lng.s_Shop_C.Text(txt_ShopC_Name);
            chk_A_in_use.Checked = false;
            chk_B_in_use.Checked = false;
            chk_C_in_use.Checked = false;
        }

        public void Init()
        {
            string shinuse = ShopsUse.ShopsInUse_Get(SettingsUserValues);

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
            string shInUse = "";
            if (chk_A_in_use.Checked)
            {
                shInUse += "A";
            }
            if (chk_B_in_use.Checked)
            {
                shInUse += "B";
            }
            if (chk_C_in_use.Checked)
            {
                shInUse += "C";
            }
            if (shInUse.Length == 0)
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
            if (SettingsUserValues == null)
            {
                Properties.Settings.Default.eShopsInUse = shInUse;
                Properties.Settings.Default.Save();
            }
            else
            {
                SettingsUserValues.eShopsInUse = shInUse;
            }
            return true;
        }
    }
}
