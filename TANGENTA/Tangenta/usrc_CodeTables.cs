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
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CodeTables;
using TangentaTableClass;
using LanguageControl;

namespace Tangenta
{
    public partial class usrc_CodeTables : UserControl
    {
        public delegate void delegate_OK_Click();
        public event delegate_OK_Click OK_Click = null;

        public delegate void delegate_EndDialog();
        public event delegate_EndDialog EndDialog = null;
        public bool bChanged = false;
        public usrc_CodeTables()
        {
            InitializeComponent();
            lngRPM.s_btn_Taxation.Text(btn_Taxation);
            lngRPM.s_btn_Currency.Text(btn_Currency);
            lngRPM.s_btn_Units.Text(btn_Units);
            lngRPM.s_btn_WorkingPlace.Text(btn_WorkingPlace);
            lngRPM.s_btn_SimpleItem_Groups.Text(btn_SimpleItem_Groups);
            lngRPM.s_btn_ItemGroups.Text(btn_ItemGroups);
            lngRPM.s_btn_Logo.Text(btn_Logo);
            lngRPM.s_btn_DBSettings.Text(btn_DBSettings);
            lngRPM.s_btn_Stock_Address.Text(btn_Stock_Address);
            lngRPM.s_btn_TermsOfPayment.Text(btn_TermsOfPayment);
            lngRPM.s_btn_Warranty.Text(btn_Warranty);
            lngRPM.s_btn_Expiry.Text(btn_Expiry);
        }

        private void btn_Taxation_Click(object sender, EventArgs e)
        {
            SQLTable tbl_Taxation = new SQLTable(DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(Taxation)));
            Form_Taxation_Edit tax_dlg = new Form_Taxation_Edit(DBSync.DBSync.DB_for_Tangenta.m_DBTables, tbl_Taxation, "ID asc");
            if (tax_dlg.ShowDialog() == DialogResult.OK)
            {
                bChanged = tax_dlg.Changed;
            }
            End();
        }

        private void btn_Currency_Click(object sender, EventArgs e)
        {
            SQLTable tbl_Currency = new SQLTable(DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(Currency)));
            Form_Currency_Edit currency_dlg = new Form_Currency_Edit(DBSync.DBSync.DB_for_Tangenta.m_DBTables, tbl_Currency, "ID asc");
            if (currency_dlg.ShowDialog() == DialogResult.OK)
            {
                bChanged = currency_dlg.Changed;
            }
            End();
        }

        private void btn_WorkingPlace_Click(object sender, EventArgs e)
        {
            SQLTable tbl_WorkingPlace = new SQLTable(DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(WorkingPlace)));
            Form_WorkingPlace_Edit currency_dlg = new Form_WorkingPlace_Edit(DBSync.DBSync.DB_for_Tangenta.m_DBTables, tbl_WorkingPlace, "ID asc");
            if (currency_dlg.ShowDialog() == DialogResult.OK)
            {
                bChanged = currency_dlg.Changed;
            }
            End();
        }

        private void btn_Units_Click(object sender, EventArgs e)
        {
            SQLTable tbl_Unit = new SQLTable(DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(Unit)));
            Form_Unit_Edit unit_dlg = new Form_Unit_Edit(DBSync.DBSync.DB_for_Tangenta.m_DBTables, tbl_Unit, "ID asc");
            if (unit_dlg.ShowDialog() == DialogResult.OK)
            {
                bChanged = unit_dlg.Changed;
            }
            End();
        }

        private void btn_Expiry_Click(object sender, EventArgs e)
        {
            SQLTable tbl_Expiry = new SQLTable(DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(Expiry)));
            Form_Expiry_Edit unit_dlg = new Form_Expiry_Edit(DBSync.DBSync.DB_for_Tangenta.m_DBTables, tbl_Expiry, "ID asc");
            if (unit_dlg.ShowDialog() == DialogResult.OK)
            {
                bChanged = unit_dlg.Changed;
            }
            End();
        }

        private void btn_Warranty_Click(object sender, EventArgs e)
        {
            SQLTable tbl_Warranty = new SQLTable(DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(Warranty)));
            Form_Warranty_Edit unit_dlg = new Form_Warranty_Edit(DBSync.DBSync.DB_for_Tangenta.m_DBTables, tbl_Warranty, "ID asc");
            if (unit_dlg.ShowDialog() == DialogResult.OK)
            {
                bChanged = unit_dlg.Changed;
            }
            End();
        }

        private void btn_TermsOfPayment_Click(object sender, EventArgs e)
        {
            SQLTable tbl_TermsOfPayment = new SQLTable(DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(TermsOfPayment)));
            Form_TermsOfPayment_Edit unit_dlg = new Form_TermsOfPayment_Edit(DBSync.DBSync.DB_for_Tangenta.m_DBTables, tbl_TermsOfPayment, "ID asc");
            if (unit_dlg.ShowDialog() == DialogResult.OK)
            {
                bChanged = unit_dlg.Changed;
            }
            End();
        }

        private void btn_Stock_Address_Click(object sender, EventArgs e)
        {

            SQLTable tbl_StockAddress = new SQLTable(DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(Stock_AddressLevel1)));
            ShopC.Form_StockAddress_Edit unit_dlg = new ShopC.Form_StockAddress_Edit(DBSync.DBSync.DB_for_Tangenta.m_DBTables, tbl_StockAddress, "ID asc");
            if (unit_dlg.ShowDialog() == DialogResult.OK)
            {
                bChanged = unit_dlg.Changed;
            }
            End();
        }

        private void End()
        {
            if (EndDialog!=null)
            {
                EndDialog();
            }
        }
        private void btn_OK_Click(object sender, EventArgs e)
        {
            if (OK_Click!=null)
            {
                OK_Click();
            }
        }

        private void btn_DBSettings_Click(object sender, EventArgs e)
        {
            SQLTable tbl_DBSettings = new SQLTable(DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(DBSettings)));
            Form_DBSettings_Edit DBSettings_dlg = new Form_DBSettings_Edit(DBSync.DBSync.DB_for_Tangenta.m_DBTables, tbl_DBSettings, "ID asc");
            if (DBSettings_dlg.ShowDialog() == DialogResult.OK)
            {
                bChanged = DBSettings_dlg.Changed;
            }
            End();
        }

        private void btn_Logo_Click(object sender, EventArgs e)
        {
            SQLTable tbl_Logo = new SQLTable(DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(Logo)));
            Form_Logo_Edit Logo_dlg = new Form_Logo_Edit(DBSync.DBSync.DB_for_Tangenta.m_DBTables, tbl_Logo, "ID asc");
            if (Logo_dlg.ShowDialog() == DialogResult.OK)
            {
                bChanged = Logo_dlg.Changed;
            }
            End();
        }

        private void btn_ItemGroups_Click(object sender, EventArgs e)
        {

            SQLTable tbl_Item_ParentGroup1 = new SQLTable(DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(Item_ParentGroup1)));
            Form_ItemGroups_Edit Item_ParentGroup1_dlg = new Form_ItemGroups_Edit(DBSync.DBSync.DB_for_Tangenta.m_DBTables, tbl_Item_ParentGroup1, "ID asc");
            if (Item_ParentGroup1_dlg.ShowDialog() == DialogResult.OK)
            {
                bChanged = Item_ParentGroup1_dlg.Changed;
            }
            End();

        }

        private void btn_SimpleItem_Groups_Click(object sender, EventArgs e)
        {
            SQLTable tbl_SimpleItem_ParentGroup1 = new SQLTable(DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(SimpleItem_ParentGroup1)));
            Form_SimpleItemGroups_Edit SimpleItem_ParentGroup1_dlg = new Form_SimpleItemGroups_Edit(DBSync.DBSync.DB_for_Tangenta.m_DBTables, tbl_SimpleItem_ParentGroup1, "ID asc");
            if (SimpleItem_ParentGroup1_dlg.ShowDialog() == DialogResult.OK)
            {
                bChanged = SimpleItem_ParentGroup1_dlg.Changed;
            }
            End();
        }
    }
}
