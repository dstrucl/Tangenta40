using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LanguageControl;
using CodeTables;
using DBTypes;

namespace ShopC
{
    public partial class usrc_StockEditForSelectedStockTake : UserControl
    {
        long CurrentItem_ID = -1;
        private Form_ShopC_Item_Edit edt_Item_dlg = null;
        DataTable dt_PurchasePrices = null;
        public long StockTake_ID = -1;
        DataTable dt_Stock_Of_Current_StockTake = new DataTable();


        public usrc_StockEditForSelectedStockTake()
        {
            InitializeComponent();
            lngRPM.s_SelectedItem.Text(btn_SelectItem);
            lngRPM.s_Add.Text(btn_Add);
            lngRPM.s_Remove.Text(btn_Remove);
            lngRPM.s_Update.Text(btn_Remove);
            lngRPM.s_Quantity.Text(lbl_Quantity);
            lngRPM.s_PurchasePricePerUnit.Text(lbl_PurchasePrice);
            lngRPM.s_Taxation.Text(lbl_Taxation);
            lngRPM.s_Currency.Text(lbl_Currency);
            lngRPM.s_ExpiryDate.Text(chk_ExpiryCheck);
            lngRPM.s_ImportTime.Text(lbl_ImportTime);
            lngRPM.s_Stock_Description.Text(lbl_Stock_Description);
        }

        private void btn_SelectItem_Click(object sender, EventArgs e)
        {
            if (edt_Item_dlg == null)
            {
                SQLTable tbl_Item = new SQLTable(DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(TangentaTableClass.Item)));
                edt_Item_dlg = new Form_ShopC_Item_Edit(DBSync.DBSync.DB_for_Tangenta.m_DBTables,
                                                                tbl_Item,
                                                                "Item_$$Code desc", CurrentItem_ID,this);
                edt_Item_dlg.TopMost = true;
            }
            edt_Item_dlg.Show();
        }

        internal void DoClose()
        {
            if (edt_Item_dlg!=null)
            {
                edt_Item_dlg.Close();
            }
        }

        internal void Selected_Item_Index_Changed(SQLTable m_tbl, long iD, int index)
        {
            if (iD >= 0)
            {
                CurrentItem_ID = iD;
                object ovalue = m_tbl.Value("UniqueName");
                if (ovalue !=null)
                {
                    if (ovalue is TangentaTableClass.UniqueName)
                    {
                        if (((TangentaTableClass.UniqueName)ovalue).defined)
                        {
                            string Item_UniqueName = ((TangentaTableClass.UniqueName)ovalue).val;
                            this.lbl_Item.Text = Item_UniqueName;
                        }
                    }
                }
                object oID = cmb_Currency.ValueMember;
                long Selected_Currency_ID = -1;
                if (oID is long)
                {
                    Selected_Currency_ID = (long)oID;
                }
                Set_cmb_PurchasePrice(iD, Selected_Currency_ID);
            }
        }

        private void Set_cmb_PurchasePrice(long iD, long Currency_ID)
        {
            if (dt_PurchasePrices == null)
            {
                string Err = null;
                string sql = null;
                if (Currency_ID >= 0)
                {
                    sql = @"select PurchasePricePerUnit from PurchasePrice_Item ppi
                               inner join PurchasePrice pp on ppi.PurchasePrice_ID = pp.ID
                               inner join Currency c on pp.Currency_ID = c.ID 
                               where Item_ID = " + iD.ToString() + " and Currency.ID = " + Currency_ID.ToString();
                }
                else
                {
                    sql = @"select PurchasePricePerUnit from PurchasePrice_Item ppi
                               inner join PurchasePrice pp on ppi.PurchasePrice_ID = pp.ID
                               inner join Currency c on pp.Currency_ID = c.ID 
                               where Item_ID = " + iD.ToString();
                }
                dt_PurchasePrices = new DataTable();
                if (!DBSync.DBSync.ReadDataTable(ref dt_PurchasePrices, sql, ref Err))
                {
                    LogFile.Error.Show("ERROR:ShopC:usrc_StockEditForSelectedStockTake.cs:Set_cmb_PurchasePrice:sql=" + sql + "\r\nErr=" + Err);
                    dt_PurchasePrices.Dispose();
                    dt_PurchasePrices = null;
                }
            }
            if (dt_PurchasePrices != null)
            {
                cmb_PurchasePrice.DataSource = dt_PurchasePrices;
                cmb_PurchasePrice.DisplayMember = "PurchasePricePerUnit";
                cmb_PurchasePrice.ValueMember = "PurchasePricePerUnit";
            }
        }

        private void usrc_StockEditForSelectedStockTake_Load(object sender, EventArgs e)
        {
            cmb_Taxation.DataSource = TangentaDB.f_Taxation.GetTable(false);
            cmb_Taxation.DisplayMember = "Name";
            cmb_Taxation.ValueMember = "ID";
            cmb_Currency.DataSource = TangentaDB.f_Currency.GetTable(false);
            cmb_Currency.DisplayMember = "Symbol";
            cmb_Currency.ValueMember = "ID";
            if (TangentaDB.myOrg.Default_Currency_ID >= 0)
            {
                cmb_Currency.SelectedIndex = (int)(TangentaDB.myOrg.Default_Currency_ID - 1);
            }
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            AddItemToStock();
        }

        private void AddItemToStock()
        {
            bool bPPriceDefined = false;
            decimal pprice = 0;
            object oDecimalValue = cmb_PurchasePrice.SelectedValue;
            if (oDecimalValue is decimal)
            {
                pprice = (decimal)oDecimalValue;
                bPPriceDefined = true;
            }
            if (!bPPriceDefined)
            {
                string sValue = cmb_PurchasePrice.Text;
                if (sValue.Length > 0)
                {
                    try
                    {
                        pprice = Convert.ToDecimal(sValue);
                        bPPriceDefined = true;
                    }
                    catch (Exception ex)
                    {
                        XMessage.Box.ShowTopMost(this, lngRPM.s_InvalidPurchasePrice, lngRPM.s_Warning.s, MessageBoxButtons.OK, null, MessageBoxDefaultButton.Button1);
                    }
                }
            }

            long PurchasePrice_ID = -1;
            long Taxation_ID = (long)cmb_Taxation.SelectedValue;
            long Currency_ID = (long)cmb_Currency.SelectedValue;
            if (TangentaDB.f_PurchasePrice.Get(pprice, Taxation_ID, Currency_ID, ref PurchasePrice_ID))
            {
                if ((bPPriceDefined)&& (CurrentItem_ID >= 0)&&(StockTake_ID>=0))
                {
                    long PurchasePrice_Item_ID = -1;
                    if (TangentaDB.f_PurchasePrice_Item.Get(CurrentItem_ID, PurchasePrice_ID, StockTake_ID, ref PurchasePrice_Item_ID))
                    {
                        DateTime_v dtExpiry_v = null;
                        if (chk_ExpiryCheck.Checked)
                        {
                            dtExpiry_v = new DateTime_v(this.TPiick_ExpiryDate.Value);
                        }
                        DateTime tImportTime = tPick_ImportTime.Value;
                        decimal dquantity = nmUpDn_Quantity.Value;
                        long Stock_AddressLevel1_ID = -1;
                        long Stock_ID = -1;
                        if (TangentaDB.f_Stock.Add(tImportTime, dquantity, dtExpiry_v, PurchasePrice_Item_ID, Stock_AddressLevel1_ID,this.txt_StockDescription.Text,ref Stock_ID))
                        {
                            ShowStock_ForCurrent_StockTakeID(Stock_ID);
                            return;
                        }
                    }
                }
            }
        }

        private void ShowStock_ForCurrent_StockTakeID(long StockTake__ID)
        {
            dt_Stock_Of_Current_StockTake.Rows.Clear();
            if (TangentaDB.f_Stock.Get_OfStockTake(ref dt_Stock_Of_Current_StockTake,StockTake__ID))
            {
                dgvx_StockTakeItemsAndPrices.DataSource = dt_Stock_Of_Current_StockTake;
            }
        }
    }
}
