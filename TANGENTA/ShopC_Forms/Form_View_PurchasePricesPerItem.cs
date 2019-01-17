using DBConnectionControl40;
using DBTypes;
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
using TangentaPrint;

namespace ShopC_Forms
{
    public partial class Form_View_PurchasePricesPerItem : Form
    {
        private DataTable dtItems = null;
        private int itemscount = 0;
        private DataTable dtPurchasePriceOfItem = null;
        private DataTable dtStockOfItem = null;
        private DataTable dtItemInStock = null;
        private DataTable dtShopCItemInStock = null;
        public Form_View_PurchasePricesPerItem()
        {
            InitializeComponent();
            lng.s_InventoryOfStock.Text(this);
            lng.s_lbl_StockItems.Text(lbl_StockItems);
            lng.s_lbl_StockOfItem.Text(lbl_StockOfItem);
        }

        private void Form_ViewStock_Load(object sender, EventArgs e)
        {
            dtStockOfItem = new DataTable();
            DataColumn dcol_Item_ID = new DataColumn("Item_ID", typeof(long));
            DataColumn dcol_Item_UniqueName = new DataColumn("Item_UniqueName", typeof(string));
            DataColumn dcol_Item_Group1 = new DataColumn("Group1", typeof(string));
            DataColumn dcol_Item_Group2 = new DataColumn("Group2", typeof(string));
            DataColumn dcol_Item_Group3 = new DataColumn("Group3", typeof(string));
            DataColumn dcol_QuantityInStock = new DataColumn("QuantityInStock", typeof(decimal));
            DataColumn dcol_NewQuantityInStock = new DataColumn("NewQuantityInStock", typeof(decimal));
            DataColumn dcol_StockChangeQuantity = new DataColumn("StockChangeQuantity", typeof(decimal));
            DataColumn dcol_PriceValueOfStock = new DataColumn("PriceValueOfStock", typeof(decimal));
            DataColumn dcol_Unit_Name = new DataColumn("Unit_Name", typeof(string));
            DataColumn dcol_Unit_Symbol = new DataColumn("Unit_Symbol", typeof(string));
            DataColumn dcol_Unit_DecimalPlaces = new DataColumn("Unit_DecimalPlaces", typeof(int));
            DataColumn dcol_PurchasePricePerUnit = new DataColumn("PurchasePricePerUnit", typeof(decimal));
            DataColumn dcol_PurchasePricePerUnitWithDiscount = new DataColumn("PurchasePricePerUnitWithDiscount", typeof(decimal));
            DataColumn dcol_PurchaseDiscount = new DataColumn("PurchaseDiscount", typeof(decimal));
            DataColumn dcol_PurchasePriceWithoutVAT = new DataColumn("PurchasePriceWithoutVAT", typeof(decimal));
            DataColumn dcol_TaxationName = new DataColumn("TaxationName", typeof(string));

            dcol_Item_UniqueName.ReadOnly = true; ;
            dcol_QuantityInStock.ReadOnly = true;
            dcol_NewQuantityInStock.ReadOnly = false;
            dcol_StockChangeQuantity.ReadOnly = true;
            dcol_PriceValueOfStock.ReadOnly = true;
            dcol_Unit_Name.ReadOnly = true;
            dcol_Unit_Symbol.ReadOnly = true;
            dcol_Unit_DecimalPlaces.ReadOnly = true;
            dcol_Item_ID.ReadOnly = true;


            dtStockOfItem.Columns.Add(dcol_Item_UniqueName);
            dtStockOfItem.Columns.Add(dcol_Item_Group1);
            dtStockOfItem.Columns.Add(dcol_Item_Group2);
            dtStockOfItem.Columns.Add(dcol_Item_Group3);
            dtStockOfItem.Columns.Add(dcol_PurchasePricePerUnit);
            dtStockOfItem.Columns.Add(dcol_PurchaseDiscount);
            dtStockOfItem.Columns.Add(dcol_PurchasePricePerUnitWithDiscount);
            dtStockOfItem.Columns.Add(dcol_PurchasePriceWithoutVAT);
            dtStockOfItem.Columns.Add(dcol_TaxationName);
            dtStockOfItem.Columns.Add(dcol_QuantityInStock);
            dtStockOfItem.Columns.Add(dcol_NewQuantityInStock);
            dtStockOfItem.Columns.Add(dcol_StockChangeQuantity);
            dtStockOfItem.Columns.Add(dcol_PriceValueOfStock);
            dtStockOfItem.Columns.Add(dcol_Unit_Name);
            dtStockOfItem.Columns.Add(dcol_Unit_Symbol);
            dtStockOfItem.Columns.Add(dcol_Unit_DecimalPlaces);
            dtStockOfItem.Columns.Add(dcol_Item_ID);

            if (TangentaDB.f_Item.GetItemDataWidthPurchasePrices(ref dtItems, ref itemscount))
            {
                for (int i = 0; i < itemscount; i++)
                {
                    DataRow drItem = dtItems.Rows[i];
                    DataRow drStockOfItem = dtStockOfItem.NewRow();
                    ID item_ID = tf.set_ID(drItem["ID"]);
                    drStockOfItem["Item_ID"] = drItem["ID"];
                    drStockOfItem["Item_UniqueName"] = drItem["Item_UniqueName"];
                    drStockOfItem["Group1"] = drItem["Group1"];
                    drStockOfItem["Group2"] = drItem["Group2"];
                    drStockOfItem["Group3"] = drItem["Group3"];
                    decimal dPurchasePricePerUnit = 0;
                    decimal_v dPurchasePricePerUnit_v = tf.set_decimal(drItem["PurchasePricePerUnit"]);
                    if (dPurchasePricePerUnit_v != null)
                    {
                        dPurchasePricePerUnit = dPurchasePricePerUnit_v.v;
                    }
                    drStockOfItem["PurchasePricePerUnit"] = dPurchasePricePerUnit;

                    decimal dPurchaseDiscount = 0;
                    decimal_v dPurchaseDiscount_v = tf.set_decimal(drItem["PurchaseDiscount"]);
                    if (dPurchaseDiscount_v != null)
                    {
                        dPurchaseDiscount = dPurchaseDiscount_v.v;
                    }

                    drStockOfItem["PurchaseDiscount"] = decimal.Round(dPurchaseDiscount,4);


                    drStockOfItem["PurchasePricePerUnitWithDiscount"] = decimal.Round(dPurchasePricePerUnit*(1- dPurchaseDiscount),4);

                    drStockOfItem["PurchasePriceWithoutVAT"] = drItem["PurchasePriceWithoutVAT"];

                    drStockOfItem["TaxationName"] = drItem["TaxationName"];
                    DataTable xdtShopCItemInStock = null;
                    string order_by = " order by i.UniqueName asc ";
                    if (TangentaDB.f_Stock.GetItemInStock(item_ID, ref xdtShopCItemInStock, order_by))
                    {
                        decimal drawquantity = TangentaDB.f_Stock.GetQuantityInStock(xdtShopCItemInStock);
                        decimal dQuantityInStock = decimal.Round(drawquantity, 4);
                        drStockOfItem["QuantityInStock"] = dQuantityInStock;
                        decimal dPriceValueOfStock = decimal.Round(TangentaDB.f_Stock.GetPriceValueInStock(xdtShopCItemInStock)* drawquantity, 4);
                        drStockOfItem["PriceValueOfStock"] = dPriceValueOfStock;
                        drStockOfItem["Unit_Name"] = drItem["Unit_Name"];
                        drStockOfItem["Unit_Symbol"] = drItem["Unit_Symbol"];
                        drStockOfItem["Unit_Name"] = drItem["Unit_Name"];
                        drStockOfItem["Unit_DecimalPlaces"] = drItem["Unit_DecimalPlaces"];
                        dtStockOfItem.Rows.Add(drStockOfItem);
                    }
                    else
                    {
                        this.Close();
                        DialogResult = DialogResult.Abort;
                    }

                }
                dgvx_Items_in_Stock.DataSource = dtStockOfItem;
                dgvx_Items_in_Stock.Columns["Item_UniqueName"].HeaderText = lng.s_Item_UniqueName.s;
                dgvx_Items_in_Stock.Columns["QuantityInStock"].HeaderText = lng.s_QuantityInStock.s;
                dgvx_Items_in_Stock.Columns["NewQuantityInStock"].HeaderText = lng.s_NewQuantityInStock.s;
                dgvx_Items_in_Stock.Columns["StockChangeQuantity"].HeaderText = lng.s_StockChangeQuantity.s;
                dgvx_Items_in_Stock.Columns["PriceValueOfStock"].HeaderText = lng.s_PriceValueOfStock.s;
                dgvx_Items_in_Stock.Columns["Unit_Name"].HeaderText = lng.s_Unit_Name.s;
                dgvx_Items_in_Stock.Columns["Unit_Symbol"].HeaderText = lng.s_Unit_Symbol.s;
                dgvx_Items_in_Stock.Columns["Unit_DecimalPlaces"].HeaderText = lng.s_Unit_DecimalPlaces.s;

                dgvx_Items_in_Stock.Columns["Group1"].HeaderText = lng.s_Group1.s;
                dgvx_Items_in_Stock.Columns["Group2"].HeaderText = lng.s_Group2.s;
                dgvx_Items_in_Stock.Columns["Group3"].HeaderText = lng.s_Group3.s;

                dgvx_Items_in_Stock.Columns["PurchasePricePerUnit"].HeaderText = lng.s_PurchasePricePerUnit.s;
                dgvx_Items_in_Stock.Columns["PurchaseDiscount"].HeaderText = lng.s_PurchaseDiscount.s;
                dgvx_Items_in_Stock.Columns["PurchasePricePerUnitWithDiscount"].HeaderText = lng.s_PurchasePricePerUnitWithDiscount.s;
                dgvx_Items_in_Stock.Columns["PurchasePriceWithoutVAT"].HeaderText = lng.s_PurchasePriceWithoutVAT.s;

                this.dgvx_Items_in_Stock.SelectionChanged += new System.EventHandler(this.dgvx_Items_in_Stock_SelectionChanged);
                return;
            }
            this.Close();
            DialogResult = DialogResult.Abort;

        }

        private void dgvx_Items_in_Stock_SelectionChanged(object sender, EventArgs e)
        {
            if (sender is DataGridView)
            {
                DataGridView dataGridView_Table = (DataGridView)sender;
                DataGridViewSelectedCellCollection dgvCellCollection = dataGridView_Table.SelectedCells;
                if (dgvCellCollection.Count >= 1)
                {
                    if (dgvCellCollection[0].OwningRow.Cells["Item_ID"].Value is long)
                    {

                        ID item_ID = tf.set_ID(dgvCellCollection[0].OwningRow.Cells["Item_ID"].Value);
                        if (ID.Validate(item_ID))
                        {
                            ShowStockOfItem(item_ID);
                        }
                    }
                }
            }
        }

        private void ShowStockOfItem(ID item_ID)
        {
            txt_Item_UniqueName.Text = "";
            if (TangentaDB.f_Stock.GetItemInStock(item_ID, ref dtShopCItemInStock))
            {
                int icount = dtShopCItemInStock.Rows.Count;
                dgvx_SingleItemStockData.DataSource = dtShopCItemInStock;
                if (icount > 0)
                {
                    string_v Item_UniqueName_v = tf.set_string(dtShopCItemInStock.Rows[0]["Item_UniqueName"]);
                    if (Item_UniqueName_v != null)
                    {
                        txt_Item_UniqueName.Text = Item_UniqueName_v.v;
                        dgvx_SingleItemStockData.Columns["Item_UniqueName"].HeaderText = lng.s_Item_UniqueName.s;
                        dgvx_SingleItemStockData.Columns["Stock_ImportTime"].HeaderText = lng.s_Stock_ImportTime.s;
                        dgvx_SingleItemStockData.Columns["Stock_dQuantity"].HeaderText = lng.s_Stock_dQuantity.s;
                    }
                }
            }
        }

        private void btn_Print_Click(object sender, EventArgs e)
        {
            Printer printer = null;
            if (!PrintersList.PrintingStockWithHtmlTemplate(ref printer))
            {
                PrintStockOfItems prnStockOfItems = new PrintStockOfItems(printer.PrinterName, dtStockOfItem);

                if (prnStockOfItems.Print(this))
                {
                }
            }
        }

        private void btn_Export_toFile_Click(object sender, EventArgs e)
        {
            int iCount = dtStockOfItem.Rows.Count;
            string sReport = "PODATKI O NABAVNIH CENAH\r\n";
            for (int i=0;i<iCount;i++)
            {
                int j = i + 1;
                sReport += "\r\n\r\n(" + j.ToString()+".)";
                DataRow dr = dtStockOfItem.Rows[i];
                sReport += getString(dr["Item_UniqueName"])+"\r\n";
                sReport += getString(dr["Group1"]) + "\r\n";
                sReport += getString(dr["Group2"]) + "\r\n";
                sReport += getString(dr["Group3"]) + "\r\n";
                sReport += "Merska enota:" +getString(dr["Unit_Name"]) + "\r\n";

                sReport += getStringFromMoney("Nabavna cena na enoto brez popusta: ",dr["PurchasePricePerUnit"]) + "\r\n";
                sReport += getStringFromDecimal("Popust na nabavno ceno: ", dr["PurchaseDiscount"]) + "\r\n";
                sReport += getStringFromMoney("Nabavna cena na enoto s popustom: ", dr["PurchasePricePerUnitWithDiscount"]) + "\r\n";
            }

        }

        private string getStringFromMoney(string v1, object v2)
        {
            if (v2 is decimal)
            {
                return v1+LanguageControl.DynSettings.SetLanguageCurrencyString((decimal)v2,2,GlobalData.BaseCurrency.Symbol);
            }
            else
            {
                return "";
            }
        }
        private string getStringFromDecimal(string v1, object v2)
        {
            if (v2 is decimal)
            {
                return v1 + Convert.ToString(decimal.Round((decimal)v2,4));
            }
            else
            {
                return "";
            }
        }

        private string getString(object v)
        {
            if (v is string)
            {
                return (string)v;
            }
            else
            {
                return "";
            }
        }
    }
}
