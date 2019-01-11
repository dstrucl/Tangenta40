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
using TangentaPrint;

namespace ShopC_Forms
{
    public partial class Form_Inventura : Form
    {
        private DataTable dtItems = null;
        private int itemscount = 0;
        private DataTable dtStockOfItem = null;
        private DataTable dtItemInStock = null;
        private DataTable dtShopCItemInStock = null;
        public Form_Inventura()
        {
            InitializeComponent();
            lng.s_InventoryOfStock.Text(this);
            lng.s_lbl_StockItems.Text(lbl_StockItems);
            lng.s_lbl_StockOfItem.Text(lbl_StockOfItem);
        }

        private void Form_Inventura_Load(object sender, EventArgs e)
        {
            dtStockOfItem = new DataTable();
            DataColumn dcol_Item_ID = new DataColumn("Item_ID", typeof(long));
            DataColumn dcol_Item_UniqueName = new DataColumn("Item_UniqueName", typeof(string));
            DataColumn dcol_QuantityInStock = new DataColumn("QuantityInStock", typeof(decimal));
            DataColumn dcol_NewQuantityInStock = new DataColumn("NewQuantityInStock", typeof(decimal));
            DataColumn dcol_StockChangeQuantity = new DataColumn("StockChangeQuantity", typeof(decimal));
            DataColumn dcol_PriceValueOfStock = new DataColumn("PriceValueOfStock", typeof(decimal));
            DataColumn dcol_Unit_Name = new DataColumn("Unit_Name", typeof(string));
            DataColumn dcol_Unit_Symbol = new DataColumn("Unit_Symbol", typeof(string));
            DataColumn dcol_Unit_DecimalPlaces = new DataColumn("Unit_DecimalPlaces", typeof(int));

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
            dtStockOfItem.Columns.Add(dcol_QuantityInStock);
            dtStockOfItem.Columns.Add(dcol_NewQuantityInStock);
            dtStockOfItem.Columns.Add(dcol_StockChangeQuantity);
            dtStockOfItem.Columns.Add(dcol_PriceValueOfStock);
            dtStockOfItem.Columns.Add(dcol_Unit_Name);
            dtStockOfItem.Columns.Add(dcol_Unit_Symbol);
            dtStockOfItem.Columns.Add(dcol_Unit_DecimalPlaces);
            dtStockOfItem.Columns.Add(dcol_Item_ID);

            if (TangentaDB.f_Item.GetItemData(ref dtItems, ref itemscount))
            {
                for (int i = 0; i < itemscount; i++)
                {
                    DataRow drItem = dtItems.Rows[i];
                    DataRow drStockOfItem = dtStockOfItem.NewRow();
                    ID item_ID = tf.set_ID(drItem["ID"]);
                    drStockOfItem["Item_ID"] = drItem["ID"];
                    drStockOfItem["Item_UniqueName"] = drItem["Item_UniqueName"];
                    DataTable xdtShopCItemInStock = null;
                    if (TangentaDB.f_Stock.GetItemInStock(item_ID, ref xdtShopCItemInStock))
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
    }
}
