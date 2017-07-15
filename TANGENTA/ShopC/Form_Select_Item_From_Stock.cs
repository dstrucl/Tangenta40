using LanguageControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ShopC
{
    public partial class Form_Select_Item_From_Stock : Form
    {
        public decimal dQuantitySelected = 0;
        private DataTable dt_ShopC_Item_in_Stock = null;
        private decimal dQuantity = 0;
        string UnitSymbol = null;
        public Form_Select_Item_From_Stock(DataTable xdt_ShopC_Item_in_Stock, decimal xdQuantity)
        {
            InitializeComponent();
            dt_ShopC_Item_in_Stock = xdt_ShopC_Item_in_Stock;
            dQuantity = xdQuantity;
            lngRPM.s_OK.Text(btn_OK);
            lngRPM.s_Cancel.Text(btn_Cancel);
            this.Icon = Properties.Resources.StockOutReference;
            lngRPM.s_Select.Text(lbl_Select);
            lbl_Quantity.Text = dQuantity.ToString() + " " + (string)dt_ShopC_Item_in_Stock.Rows[0]["UnitSymbol"] + " " + (string)dt_ShopC_Item_in_Stock.Rows[0]["Item_UniqueName"];
            lngRPM.s_Form_SelectItemFromStock.Text(this);

            dgvx_Item_From_Stock.DataSource = dt_ShopC_Item_in_Stock;

            foreach (DataGridViewColumn dgvcol in dgvx_Item_From_Stock.Columns)
            {
                dgvcol.Visible = false;
            }
            dgvx_Item_From_Stock.Columns["Stock_dQuantity"].HeaderText = lngRPM.s_Quantity.s;
            dgvx_Item_From_Stock.Columns["Stock_dQuantity"].Visible = true;
            dgvx_Item_From_Stock.Columns["Stock_dQuantity"].DisplayIndex = 0;
            dgvx_Item_From_Stock.Columns["Stock_dQuantity"].ReadOnly = true;

            dgvx_Item_From_Stock.Columns["Stock_Expiry_Date"].HeaderText = lngRPM.s_ExpiryDate.s;
            dgvx_Item_From_Stock.Columns["Stock_Expiry_Date"].Visible = true;
            dgvx_Item_From_Stock.Columns["Stock_Expiry_Date"].DisplayIndex = 1;
            dgvx_Item_From_Stock.Columns["Stock_Expiry_Date"].ReadOnly = true;

            dgvx_Item_From_Stock.Columns["TakeFromStock"].HeaderText = lngRPM.s_QuantityTakenFromStock.s;
            dgvx_Item_From_Stock.Columns["TakeFromStock"].Visible = true;
            dgvx_Item_From_Stock.Columns["TakeFromStock"].DisplayIndex = 2;
            dgvx_Item_From_Stock.Columns["TakeFromStock"].ReadOnly = false;
            dgvx_Item_From_Stock.Columns["TakeFromStock"].DefaultCellStyle.BackColor = Color.Goldenrod;

            DataGridViewButtonColumn dgvbc_plus = new DataGridViewButtonColumn();
            dgvbc_plus.Text = "+";
            DataGridViewButtonColumn dgvbc_minus = new DataGridViewButtonColumn();
            dgvbc_minus.ValueType = typeof(string);
            dgvbc_minus.Text = "-";
            dgvbc_minus.HeaderText = "-";
            dgvbc_minus.Name = "MinusButton";
            dgvbc_minus.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dgvbc_minus.UseColumnTextForButtonValue = true;
            dgvbc_plus.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dgvbc_plus.HeaderText = "+";
            dgvbc_plus.Name = "PlusButton";
            dgvbc_plus.UseColumnTextForButtonValue = true;
            dgvx_Item_From_Stock.Columns.Add(dgvbc_plus);
            dgvx_Item_From_Stock.Columns.Add(dgvbc_minus);
            dgvbc_minus.DisplayIndex = 3;
            dgvbc_plus.DisplayIndex = 4;

            dgvx_Item_From_Stock.Columns["StockTake_Name"].HeaderText = lngRPM.s_StockTakeName.s;
            dgvx_Item_From_Stock.Columns["StockTake_Name"].Visible = true;
            dgvx_Item_From_Stock.Columns["StockTake_Name"].DisplayIndex = 5;
            dgvx_Item_From_Stock.Columns["StockTake_Name"].ReadOnly = true;

            dgvx_Item_From_Stock.Columns["StockTake_Date"].HeaderText = lngRPM.s_StockTakeDate.s;
            dgvx_Item_From_Stock.Columns["StockTake_Date"].Visible = true;
            dgvx_Item_From_Stock.Columns["StockTake_Date"].DisplayIndex = 6;
            dgvx_Item_From_Stock.Columns["StockTake_Date"].ReadOnly = true;

            dgvx_Item_From_Stock.Columns["Supplier"].HeaderText = lngRPM.s_Supplier.s;
            dgvx_Item_From_Stock.Columns["Supplier"].Visible = true;
            dgvx_Item_From_Stock.Columns["Supplier"].DisplayIndex = 7;
            dgvx_Item_From_Stock.Columns["Supplier"].ReadOnly = true;

            dgvx_Item_From_Stock.Columns["Stock_ImportTime"].HeaderText = lngRPM.s_ImportTime.s;
            dgvx_Item_From_Stock.Columns["Stock_ImportTime"].Visible = true;
            dgvx_Item_From_Stock.Columns["Stock_ImportTime"].DisplayIndex = 8;
            dgvx_Item_From_Stock.Columns["Stock_ImportTime"].ReadOnly = true;
            ShowSelected();
        }

        private void dgvx_Item_From_Stock_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                if (((DataGridViewButtonColumn)senderGrid.Columns[e.ColumnIndex]).Text.Equals("-"))
                {
                    decimal d = (decimal)dt_ShopC_Item_in_Stock.Rows[e.RowIndex]["TakeFromStock"];
                    if (d > 0)
                    {
                        d = d - 1;
                        if (d < 0)
                        {
                            d = 0;
                        }
                    }
                    dt_ShopC_Item_in_Stock.Rows[e.RowIndex]["TakeFromStock"] = d;
                    ShowSelected();
                }
                if (((DataGridViewButtonColumn)senderGrid.Columns[e.ColumnIndex]).Text.Equals("+"))
                {
                    decimal dQinStock = (decimal)dt_ShopC_Item_in_Stock.Rows[e.RowIndex]["Stock_dQuantity"];
                    decimal d = (decimal)dt_ShopC_Item_in_Stock.Rows[e.RowIndex]["TakeFromStock"];
                    if (d < dQinStock)
                    {
                        d = d + 1;
                        if (d > dQinStock)
                        {
                            d = dQinStock;
                        }
                    }
                    dt_ShopC_Item_in_Stock.Rows[e.RowIndex]["TakeFromStock"] = d;
                    ShowSelected();
                }
            }

        }

        private void ShowSelected()
        {
            dQuantitySelected = 0;
            foreach (DataRow dr in dt_ShopC_Item_in_Stock.Rows)
            {
                dQuantitySelected += (decimal)dr["TakeFromStock"];
            }
            lngRPM.s_SelectedQuantity.Text(lbl_Select, " " + dQuantitySelected.ToString() + " " + UnitSymbol);
            if (dQuantitySelected == dQuantity)
            {
                lbl_Select.ForeColor = Color.DarkGreen;
            }
            else
            {
                lbl_Select.ForeColor = Color.Red;
            }
            lbl_Select.Refresh();
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            ShowSelected();
            if (dQuantitySelected != dQuantity)
            {
                if (XMessage.Box.Show(this, lngRPM.s_YourSelectedQuantityIsNotEqualTo, lngRPM.s_Warning.s, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
