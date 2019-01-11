using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TangentaDB;

namespace PriseLists
{
    public partial class Form_PriceList_Import : Form
    {
        DataTable dtPriceList = null;
        DataTable dtItemsPurchasePrice = null;
        public Form_PriceList_Import()
        {

            InitializeComponent();
            lng.s_Form_PriceList_Import.Text(this);
            lng.s_btn_Import.Text(this.btn_Import);
            lng.s_rdb_AllPricesUndefined.Text(rdb_AllPricesUndefined);
            lng.s_rdb_Import_From_PurchasePriceList_other_leave_undefined.Text(rdb_Import_From_PurchasePriceList_other_leave_undefined);
            lng.s_rdb_Import_From_other_PriceList.Text(rdb_Import_From_other_PriceList);
            lng.s_rdb_Import_purchase_prices_and_from_other_price_list.Text(rdb_Import_purchase_prices_and_from_other_price_list);
        }

        private void Form_PriceList_Import_Load(object sender, EventArgs e)
        {

            if (TangentaDB.f_PriceList.GetTable(ref dtPriceList))
            {
                this.DialogResult = DialogResult.Abort;
                this.Close();
                return;
            }
            if (dtPriceList.Rows.Count == 0)
            {
                rdb_AllPricesUndefined.Enabled = true;
                btn_Import.Enabled = true;
                rdb_Import_From_PurchasePriceList_other_leave_undefined.Enabled = false;
                rdb_Import_From_other_PriceList.Enabled = false;
                rdb_Import_purchase_prices_and_from_other_price_list.Enabled = false;
                nmUpDnOPL_Import_From_other_PriceList.Enabled = false;
                nmUpDnOPL_Import_purchase_prices_and_from_other_price_list.Enabled = false;
                nmUpDnPP_Import_From_PurchasePriceList_other_leave_undefined.Enabled = false;
                nmUpDnPP_Import_purchase_prices_and_from_other_price_list.Enabled = false;
                cmb_Import_From_other_PriceList.Enabled = false;
                cmb_Import_purchase_prices_and_from_other_price_list.Enabled = false;
            }
            else if (dtPriceList.Rows.Count == 1)
            {
                rdb_AllPricesUndefined.Enabled = true;
                btn_Import.Enabled = true;
                if (!f_PurchasePrice_Item.GetLastItemsPurchasePriceTable(ref dtItemsPurchasePrice))
                {
                    this.DialogResult = DialogResult.Abort;
                    this.Close();
                    return;
                }
                int iCount = dtItemsPurchasePrice.Rows.Count;
                if (iCount > 0)
                {
                    rdb_Import_From_PurchasePriceList_other_leave_undefined.Enabled = true;
                    rdb_Import_From_other_PriceList.Enabled = false;
                    rdb_Import_purchase_prices_and_from_other_price_list.Enabled = false;
                    nmUpDnOPL_Import_From_other_PriceList.Enabled = true;
                    nmUpDnOPL_Import_purchase_prices_and_from_other_price_list.Enabled = false;
                    nmUpDnPP_Import_From_PurchasePriceList_other_leave_undefined.Enabled = false;
                    nmUpDnPP_Import_purchase_prices_and_from_other_price_list.Enabled = false;
                    cmb_Import_From_other_PriceList.Enabled = false;
                    cmb_Import_purchase_prices_and_from_other_price_list.Enabled = false;
                }
                else
                {
                    rdb_Import_From_PurchasePriceList_other_leave_undefined.Enabled = false;
                    rdb_Import_From_other_PriceList.Enabled = false;
                    rdb_Import_purchase_prices_and_from_other_price_list.Enabled = false;
                    nmUpDnOPL_Import_From_other_PriceList.Enabled = false;
                    nmUpDnOPL_Import_purchase_prices_and_from_other_price_list.Enabled = false;
                    nmUpDnPP_Import_From_PurchasePriceList_other_leave_undefined.Enabled = false;
                    nmUpDnPP_Import_purchase_prices_and_from_other_price_list.Enabled = false;
                    cmb_Import_From_other_PriceList.Enabled = false;
                    cmb_Import_purchase_prices_and_from_other_price_list.Enabled = false;
                }

            }
            else if (dtPriceList.Rows.Count > 1)
            {

                rdb_AllPricesUndefined.Enabled = true;
                btn_Import.Enabled = true;
                if (!f_PurchasePrice_Item.GetLastItemsPurchasePriceTable(ref dtItemsPurchasePrice))
                {
                    this.DialogResult = DialogResult.Abort;
                    this.Close();
                    return;
                }
                int iCount = dtItemsPurchasePrice.Rows.Count;
                if (iCount > 0)
                {
                    rdb_Import_From_PurchasePriceList_other_leave_undefined.Enabled = true;
                    rdb_Import_From_other_PriceList.Enabled = true;
                    rdb_Import_purchase_prices_and_from_other_price_list.Enabled = true;
                    nmUpDnOPL_Import_From_other_PriceList.Enabled = true;
                    nmUpDnOPL_Import_purchase_prices_and_from_other_price_list.Enabled = true;
                    nmUpDnPP_Import_From_PurchasePriceList_other_leave_undefined.Enabled = true;
                    nmUpDnPP_Import_purchase_prices_and_from_other_price_list.Enabled = true;
                    cmb_Import_From_other_PriceList.Enabled = true;
                    cmb_Import_purchase_prices_and_from_other_price_list.Enabled = true;
                }
                else
                {
                    rdb_Import_From_PurchasePriceList_other_leave_undefined.Enabled = false;
                    rdb_Import_From_other_PriceList.Enabled = true;
                    rdb_Import_purchase_prices_and_from_other_price_list.Enabled = false;
                    nmUpDnOPL_Import_From_other_PriceList.Enabled = true;
                    nmUpDnOPL_Import_purchase_prices_and_from_other_price_list.Enabled = false;
                    nmUpDnPP_Import_From_PurchasePriceList_other_leave_undefined.Enabled = false;
                    nmUpDnPP_Import_purchase_prices_and_from_other_price_list.Enabled = false;
                    cmb_Import_From_other_PriceList.Enabled = true;
                    cmb_Import_purchase_prices_and_from_other_price_list.Enabled = false;
                }
            }
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
            DialogResult = DialogResult.Cancel;
        }
    }
}
