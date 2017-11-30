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
using TangentaDB;

namespace ShopC
{
    public partial class usrc_StockEditForSelectedStockTake : UserControl
    {
        public delegate void delegate_BtnExitPressed();
        public event delegate_BtnExitPressed BtnExitPressed = null;

        internal Form_ShopC_Item_Edit edt_Item_dlg = null;

        private bool m_Changed = false;
        public bool Changed
        {
            get { return m_Changed; }
        }

        private DataTable dt_PurchasePrices = null;

        private int current_index = -1;

        private long m_CurrentItem_ID = -1;
        private long m_CurrentStock_ID = -1;


        private SQLTable m_StockTakeTable = null;

        private bool m_Draft = false;

        private DataTable dt_Stock_Of_Current_StockTake = new DataTable();
        internal Doc_ShopC_Item[] aDoc_ShopC_Item = null;


        internal long CurrentItem_ID
        {
            get { return m_CurrentItem_ID; }
            set
            {
                m_CurrentItem_ID = value;
            }

        }


        internal long CurrentStock_ID
        {
            get { return m_CurrentStock_ID; }
            set
            {
                m_CurrentStock_ID = value;
            }

        }


        internal long StockTake_ID
        {
            get {
                    if (m_StockTakeTable != null)
                    {
                        object o_StockTake_ID = m_StockTakeTable.Value("ID");
                        if (o_StockTake_ID is DBTypes.ID)
                        {
                            if (((DBTypes.ID)o_StockTake_ID).defined)
                            {
                                return ((DBTypes.ID)o_StockTake_ID).val;
                            }
                        }
                    }
                    return -1;
                }
            }


        internal bool Draft
        {
            get { return m_Draft; }
            set { m_Draft = value;
                  grp_Item.Enabled = m_Draft;
                  btn_Add.Enabled = m_Draft;
                  btn_Update.Enabled = m_Draft;
                  btn_Remove.Enabled = m_Draft;
                  tPick_ImportTime.Enabled = m_Draft;
                  TPiick_ExpiryDate.Enabled = m_Draft;
                }
        }

        internal SQLTable StockTakeTable
        {
            get { return m_StockTakeTable; }
            set
            {
                m_StockTakeTable =value;
                if (m_StockTakeTable!=null)
                {
                    object oDraft = m_StockTakeTable.Value("Draft");
                    if (oDraft is TangentaTableClass.Draft)
                    {
                        Draft = ((TangentaTableClass.Draft)oDraft).val;
                        if (Draft)
                        {
                            grp_Item.Enabled = true;
                            if (dt_Stock_Of_Current_StockTake!=null)
                            {
                                if (dt_Stock_Of_Current_StockTake.Rows.Count>0)
                                {
                                    btn_Add.Visible = true;
                                    btn_Update.Visible = true;
                                    btn_Remove.Visible = true;
                                }
                                else 
                                {
                                    btn_Add.Visible = true;
                                    btn_Update.Visible = false;
                                    btn_Remove.Visible = false;
                                }
                            }
                        }
                        else
                        {
                            grp_Item.Enabled = false;
                            btn_Add.Visible = false;
                            btn_Update.Visible = false;
                            btn_Remove.Visible = false;
                        }
                    }
                }
            }
        }

        internal string StockTakeName
        {
               get {
                    if (m_StockTakeTable != null)
                    {
                        object o_StockTake_Name = m_StockTakeTable.Value("Name");
                        if (o_StockTake_Name is TangentaTableClass.Name)
                        {
                            if (((TangentaTableClass.Name)o_StockTake_Name).defined)
                            {
                                return ((TangentaTableClass.Name)o_StockTake_Name).val;
                            }
                        }
                    }
                    return "";
                }
        }



        public usrc_StockEditForSelectedStockTake()
        {
            InitializeComponent();
            nmUpDn_Quantity.Maximum = decimal.MaxValue;
            EnableControls(false);
        }

        internal void SetItem(long ID,string xUniqueName, string symbol,short uDecimalPlaces)
        {
            CurrentItem_ID = ID;
            lng.s_Item.TextWithToolTip(this.grp_Item, lng.s_Item.s + ":" + xUniqueName, lng.s_Item.s+ ":" + xUniqueName+" "+lng.s_Unit.s + ":"+symbol + " ; "+lng.s_DecimalPlaces.s+"="+ uDecimalPlaces.ToString());
            fs.SetNumericUpDown(ref nmUpDn_Quantity, uDecimalPlaces);
            nmUpDn_Quantity.Maximum = decimal.MaxValue;

            EnableControls(true);
        }

        private void btn_SelectItem_Click(object sender, EventArgs e)
        {
            if (edt_Item_dlg == null)
            {
                SQLTable tbl_Item = new SQLTable(DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(TangentaTableClass.Item)));
                edt_Item_dlg = new Form_ShopC_Item_Edit(DBSync.DBSync.DB_for_Tangenta.m_DBTables,
                                                                tbl_Item,
                                                                "Item_$$Code desc", CurrentItem_ID, this);
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
                if (fs.IDisValid(CurrentItem_ID))
                {
                    object oID = cmb_Currency.ValueMember;
                    long Selected_Currency_ID = -1;
                    if (oID is long)
                    {
                        Selected_Currency_ID = (long)oID;
                    }
                    Set_cmb_PurchasePrice(iD, Selected_Currency_ID);
                }
            }
        }

        private void Set_cmb_PurchasePrice(long Item_ID, long Currency_ID)
        {
            if (dt_PurchasePrices == null)
            {
                string Err = null;
                string sql = null;
                if (Currency_ID >= 0)
                {
                    if (DBSync.DBSync.DB_for_Tangenta.m_DBTables.m_con.DBType == DBConnectionControl40.DBConnection.eDBType.SQLITE)
                    {
                        sql = @"select PurchasePricePerUnit from PurchasePrice_Item ppi
                               inner join StockTake st on ppi.StockTake_ID = st.ID
                               inner join PurchasePrice pp on ppi.PurchasePrice_ID = pp.ID
                               inner join Currency c on pp.Currency_ID = c.ID 
                               where Item_ID = " + Item_ID.ToString()
                               + " and Currency_ID = " + Currency_ID.ToString()
                               + " order by StockTake_Date desc limit 20";
                        ;
                    }
                    else if (DBSync.DBSync.DB_for_Tangenta.m_DBTables.m_con.DBType == DBConnectionControl40.DBConnection.eDBType.MSSQL)
                    {
                        sql = @"select top 20 PurchasePricePerUnit from PurchasePrice_Item ppi
                               inner join StockTake st on ppi.StockTake_ID = st.ID
                               inner join PurchasePrice pp on ppi.PurchasePrice_ID = pp.ID
                               inner join Currency c on pp.Currency_ID = c.ID 
                               where Item_ID = " + Item_ID.ToString()
                               + " and Currency_ID = " + Currency_ID.ToString()
                               + " order by StockTake_Date";
                        ;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:Shop_C:usrc_StockEditForSelectedStockTake:Set_cmb_PurchasePrice:Err = " + DBSync.DBSync.DB_for_Tangenta.m_DBTables.m_con.DBType.ToString() + " not implemented");
                        return;
                    }
                }
                else
                {
                    if (DBSync.DBSync.DB_for_Tangenta.m_DBTables.m_con.DBType == DBConnectionControl40.DBConnection.eDBType.SQLITE)
                    {
                        sql = @"select PurchasePricePerUnit from PurchasePrice_Item ppi
                               inner join StockTake st on ppi.StockTake_ID = st.ID
                               inner join PurchasePrice pp on ppi.PurchasePrice_ID = pp.ID
                               inner join Currency c on pp.Currency_ID = c.ID 
                               where Item_ID = " + Item_ID.ToString()
                               + " order by StockTake_Date desc limit 20 ";
                    }
                    else if (DBSync.DBSync.DB_for_Tangenta.m_DBTables.m_con.DBType == DBConnectionControl40.DBConnection.eDBType.MSSQL)
                    {
                        sql = @"select top 20 PurchasePricePerUnit from PurchasePrice_Item ppi
                               inner join StockTake st on ppi.StockTake_ID = st.ID
                               inner join PurchasePrice pp on ppi.PurchasePrice_ID = pp.ID
                               inner join Currency c on pp.Currency_ID = c.ID 
                               where Item_ID = " + Item_ID.ToString()
                               + " order by StockTake_Date desc";
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:Shop_C:usrc_StockEditForSelectedStockTake:Set_cmb_PurchasePrice:Err = " + DBSync.DBSync.DB_for_Tangenta.m_DBTables.m_con.DBType.ToString() + " not implemented");
                        return;
                    }
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

            if (!DesignMode)
            {
                lng.s_SelectedItem.Text(btn_SelectItem);
                lng.s_Add.Text(btn_Add);
                lng.s_Remove.Text(btn_Remove);
                lng.s_Update.Text(this.btn_Update);
                lng.s_Quantity.Text(lbl_Quantity);
                lng.s_PurchasePricePerUnit.Text(lbl_PurchasePrice);
                lng.s_Taxation.Text(lbl_Taxation);
                lng.s_Currency.Text(lbl_Currency);
                lng.s_ExpiryDate.Text(chk_ExpiryCheck);
                lng.s_ImportTime.Text(lbl_ImportTime);
                lng.s_Stock_Description.Text(lbl_Stock_Description);
                lng.s_btn_CloseStockTake.Text(btn_CloseStockTake);
                lng.s_btn_AdditionalCost.Text(btn_AdditionalCost);
                lng.s_lbl_StockTakeTotalPrice.Text(this.lbl_TotalPrice);

                btn_Add.Visible = false;
                btn_Remove.Visible = false;
                btn_Update.Visible = false;
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
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            if (Check())
            {
                AddItemToStockTake();
            }
        }

        private bool Check()
        {
            if (Check_Item())
            {
                if (Check_dQuantity())
                {
                    if (Check_PurchasePricePerUnit())
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool Check_Item()
        {
           if (fs.IDisValid(CurrentItem_ID))
           {
                return true;
           }
           else
            {
                bool bTopmost = edt_Item_dlg != null;
                XMessage.Box.Show(bTopmost, this, lng.s_ItemIsNotDefined, "?", MessageBoxButtons.OK, null, MessageBoxDefaultButton.Button1);
                return false;
            }
        }

        private bool Check_dQuantity()
        {
            decimal dquantity = nmUpDn_Quantity.Value;
            if (dquantity == 0)
            {
                bool bTopmost = edt_Item_dlg != null;
                if (XMessage.Box.Show(bTopmost,this, lng.s_dQuantityEqualsZero_InsertItemInStock,"?",MessageBoxButtons.YesNo,null,MessageBoxDefaultButton.Button2)== DialogResult.Yes)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
        }

        private bool Check_PurchasePricePerUnit()
        {
            decimal d = 0;
            bool bTopmost = edt_Item_dlg != null;
            try
            {
                d = Convert.ToDecimal(cmb_PurchasePrice.Text);
            }
            catch
            {
                XMessage.Box.Show(bTopmost, this, lng.s_PurchasePricePerUnitIsNotDefined, "?", MessageBoxButtons.OK, null, MessageBoxDefaultButton.Button1);
                return false;
            }
             if (d == 0)
            {
                if (XMessage.Box.Show(bTopmost, this, lng.s_PurchasePriceIsZeroAreYouSure, "?", MessageBoxButtons.YesNo, null, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }

        }

        private void AddItemToStockTake()
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
                    catch 
                    {
                        XMessage.Box.ShowTopMost(this, lng.s_InvalidPurchasePrice, lng.s_Warning.s, MessageBoxButtons.OK, null, MessageBoxDefaultButton.Button1);
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
                            m_Changed = true;
                            if (Reload(StockTakeTable))
                            {
                                CurrentStock_ID = Stock_ID;
                                DataRow[] drs = dt_Stock_Of_Current_StockTake.Select("Stock_ID = " + CurrentStock_ID);
                                if (drs.Length > 0)
                                {
                                    current_index = this.dt_Stock_Of_Current_StockTake.Rows.IndexOf(drs[0]);
                                    this.dgvx_StockTakeItemsAndPrices.Rows[current_index].Selected = true;
                                }

                            }
                            return;
                        }
                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:ShopC:usrc_StockEditForSelectedStockTake.cs:AddItemToStock:Err=!((bPPriceDefined)&& (CurrentItem_ID >= 0)&&(StockTake_ID>=0))");
                }
            }
        }

        internal bool Reload(SQLTable tbl_StockTake)
        {
            StockTakeTable = tbl_StockTake;
            return Reload(this.StockTake_ID);
        }

        private bool Reload(long xStockTake_ID)
        {
            dgvx_StockTakeItemsAndPrices.DataSource = null;
            dt_Stock_Of_Current_StockTake.Rows.Clear();
            this.dgvx_StockTakeItemsAndPrices.SelectionChanged -= new System.EventHandler(this.dgvx_StockTakeItemsAndPrices_SelectionChanged);
            if (TangentaDB.f_Stock.GeStockTakeItems(ref dt_Stock_Of_Current_StockTake, ref aDoc_ShopC_Item, StockTake_ID))
            {
                dgvx_StockTakeItemsAndPrices.Columns.Clear();
                dgvx_StockTakeItemsAndPrices.DataSource = dt_Stock_Of_Current_StockTake;

                //insert button _column
                DataGridViewButtonColumn dgvbc = new DataGridViewButtonColumn();
                dgvbc.CellTemplate = new DataGridViewDisableButtonCell.DataGridViewDisableButtonCell();
                dgvbc.UseColumnTextForButtonValue = true;
                dgvbc.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvbc.Width = 32;
                dgvbc.Text = "Info";
                dgvbc.Name = "";
                dgvbc.DataPropertyName = "";
                dgvx_StockTakeItemsAndPrices.Columns.Insert(0, dgvbc);

                for (int i = 0; i < dt_Stock_Of_Current_StockTake.Rows.Count; i++)
                {
                    ((DataGridViewDisableButtonCell.DataGridViewDisableButtonCell)dgvx_StockTakeItemsAndPrices.Rows[i].Cells[0]).visible = false;
                    ((DataGridViewDisableButtonCell.DataGridViewDisableButtonCell)dgvx_StockTakeItemsAndPrices.Rows[i].Cells[0]).Enabled = false;
                    ((DataGridViewDisableButtonCell.DataGridViewDisableButtonCell)dgvx_StockTakeItemsAndPrices.Rows[i].Cells[0]).Style.BackColor = Color.White;
                    if (aDoc_ShopC_Item[i] != null)
                    {
                        if (aDoc_ShopC_Item[i].adata != null)
                        {
                            if (aDoc_ShopC_Item[i].adata.Length > 0)
                            {
                                ((DataGridViewDisableButtonCell.DataGridViewDisableButtonCell)dgvx_StockTakeItemsAndPrices.Rows[i].Cells[0]).visible = true;
                                ((DataGridViewDisableButtonCell.DataGridViewDisableButtonCell)dgvx_StockTakeItemsAndPrices.Rows[i].Cells[0]).Enabled = true;
                                ((DataGridViewDisableButtonCell.DataGridViewDisableButtonCell)dgvx_StockTakeItemsAndPrices.Rows[i].Cells[0]).Style.BackColor = Color.LightPink;
                            }
                        }
                    }
                }

                if (dt_Stock_Of_Current_StockTake.Rows.Count > 0 && current_index < 0)
                {
                    current_index = 0;
                }
                if (current_index >= dt_Stock_Of_Current_StockTake.Rows.Count)
                {
                    if (dt_Stock_Of_Current_StockTake.Rows.Count == 0)
                    {
                        current_index = -1;
                    }
                    else
                    {
                        current_index = dt_Stock_Of_Current_StockTake.Rows.Count - 1;
                    }
                }
                if (current_index >= 0)
                {
                    CurrentStock_ID = (long)dt_Stock_Of_Current_StockTake.Rows[current_index]["Stock_ID"];
                    CurrentItem_ID = (long)dt_Stock_Of_Current_StockTake.Rows[current_index]["Item_ID"];
                    object ocurrency_id = cmb_Currency.SelectedValue;
                    long xCurrency_ID = -1;
                    if (ocurrency_id != null)
                    {
                        if (ocurrency_id is long)
                        {
                            xCurrency_ID = (long)ocurrency_id;
                        }
                    }
                    if (xCurrency_ID >= 0)
                    {
                        Set_cmb_PurchasePrice(CurrentItem_ID, xCurrency_ID);
                    }
                    dgvx_StockTakeItemsAndPrices.Rows[current_index].Selected = true;
                    btn_Remove.Visible = true;
                    btn_Update.Visible = true;
                }
                else
                {
                    CurrentStock_ID = -1;
                    CurrentItem_ID = -1;
                    btn_Remove.Visible = false;
                    btn_Update.Visible = false;
                }



                this.dgvx_StockTakeItemsAndPrices.SelectionChanged += new System.EventHandler(this.dgvx_StockTakeItemsAndPrices_SelectionChanged);
                Set_StockTakeItems_Table_headers();
                FillControls();
                this.CalculateDifference();
                return true;
            }
            return false;
        }

        private void Set_StockTakeItems_Table_headers()
        {
            dgvx_StockTakeItemsAndPrices.Columns["UniqueName"].HeaderText = lng.s_UniqueName.s;
            dgvx_StockTakeItemsAndPrices.Columns["UniqueName"].DisplayIndex = 0;
            dgvx_StockTakeItemsAndPrices.Columns["dInitialQuantity"].HeaderText = lng.s_Stock_dInitialQuantity.s;
            dgvx_StockTakeItemsAndPrices.Columns["dInitialQuantity"].DisplayIndex = 1;
            dgvx_StockTakeItemsAndPrices.Columns["dQuantity"].HeaderText = lng.s_Stock_dQuantity.s;
            dgvx_StockTakeItemsAndPrices.Columns["dQuantity"].DisplayIndex = 2;
            dgvx_StockTakeItemsAndPrices.Columns["ImportTime"].HeaderText = lng.s_ImportTime.s;
            dgvx_StockTakeItemsAndPrices.Columns["ExpiryDate"].HeaderText = lng.s_ExpiryDate.s;
            dgvx_StockTakeItemsAndPrices.Columns["PurchasePricePerUnit"].HeaderText = lng.s_PurchasePricePerUnit.s;
            dgvx_StockTakeItemsAndPrices.Columns["Symbol"].HeaderText = lng.s_Currency.s;
            dgvx_StockTakeItemsAndPrices.Columns["Supplier"].HeaderText = lng.s_Supplier.s;
            dgvx_StockTakeItemsAndPrices.Columns["TaxationName"].HeaderText = lng.s_Taxation.s;
            dgvx_StockTakeItemsAndPrices.Columns["TruckingOrganisation"].HeaderText = lng.s_TruckingOrganisation.s;
            dgvx_StockTakeItemsAndPrices.Columns["Supplier_Tax_ID"].Visible = false;
            dgvx_StockTakeItemsAndPrices.Columns["StockTakePriceTotal"].Visible = false;
            dgvx_StockTakeItemsAndPrices.Columns["TruckingCost"].Visible = false;
            dgvx_StockTakeItemsAndPrices.Columns["Customs"].Visible = false;
            dgvx_StockTakeItemsAndPrices.Columns["PurchasePrice_ID"].Visible = false;
            dgvx_StockTakeItemsAndPrices.Columns["Currency_ID"].Visible = false;
            dgvx_StockTakeItemsAndPrices.Columns["Taxation_ID"].Visible = false;
        }

        private void FillControls()
        {
            lng.s_lbl_StockTakeName.Text(lbl_StockTakeName, " : " + StockTakeName);
            if (fs.IDisValid(CurrentStock_ID))
            {
                string sItem_UniqueName =((string)dt_Stock_Of_Current_StockTake.Rows[current_index]["UniqueName"]);
                string sItem_UnitName = ((string)dt_Stock_Of_Current_StockTake.Rows[current_index]["UnitName"]);
                string sItem_UnitSymbol = ((string)dt_Stock_Of_Current_StockTake.Rows[current_index]["UnitSymbol"]);
                int iItem_UnitDecimalPlaces = ((int)dt_Stock_Of_Current_StockTake.Rows[current_index]["UnitDecimalPlaces"]);
                fs.SetNumericUpDown(ref nmUpDn_Quantity, iItem_UnitDecimalPlaces);
                lng.s_Item.TextWithToolTip(grp_Item, ":" + sItem_UniqueName, lng.s_Item.s+" : "+lng.s_Unit.s+ " = "+ sItem_UnitSymbol+" : "+lng.s_DecimalPlaces.s+" = "+ iItem_UnitDecimalPlaces.ToString());
                nmUpDn_Quantity.Value = ((decimal)dt_Stock_Of_Current_StockTake.Rows[current_index]["dQuantity"]);
                tPick_ImportTime.Value = ((DateTime)dt_Stock_Of_Current_StockTake.Rows[current_index]["ImportTime"]);
                object oExpiryDate = dt_Stock_Of_Current_StockTake.Rows[current_index]["ExpiryDate"];
                if (oExpiryDate is DateTime)
                {
                    chk_ExpiryCheck.Checked = true;
                    this.TPiick_ExpiryDate.Value = ((DateTime)oExpiryDate);
                }
                else
                {
                    chk_ExpiryCheck.Checked = false;
                    this.TPiick_ExpiryDate.Enabled = false;
                }
                cmb_Taxation.SelectedIndex = Convert.ToInt32(dt_Stock_Of_Current_StockTake.Rows[current_index]["Taxation_ID"])-1;
                cmb_Currency.SelectedIndex = Convert.ToInt32(dt_Stock_Of_Current_StockTake.Rows[current_index]["Currency_ID"])-1;
                cmb_PurchasePrice.Text = Convert.ToString(dt_Stock_Of_Current_StockTake.Rows[current_index]["PurchasePricePerUnit"]);
                txt_StockDescription.Text = "";
                object oDescription = dt_Stock_Of_Current_StockTake.Rows[current_index]["Description"];
                if (oDescription is string)
                {
                    txt_StockDescription.Text = (string)oDescription;
                }
                EnableControls(true);
            }
            else
            {
                lng.s_Item.TextWithToolTip(grp_Item, ":","");
                cmb_PurchasePrice.Text = "";
                nmUpDn_Quantity.Minimum = 0;
                nmUpDn_Quantity.Value = 0;
                EnableControls(false);
            }
        }

        private void EnableControls(bool v)
        {
            nmUpDn_Quantity.Enabled = v;
            cmb_PurchasePrice.Enabled = v;
            cmb_Taxation.Enabled = v;
            cmb_Currency.Enabled = v;
            tPick_ImportTime.Enabled = v;
            TPiick_ExpiryDate.Enabled = v;
            chk_ExpiryCheck.Enabled = v;
            txt_StockDescription.Enabled = v;
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            if (BtnExitPressed!=null)
            {
                BtnExitPressed();
            }
        }

        private void btn_CloseStockTake_Click(object sender, EventArgs e)
        {
            if (fs.IDisValid(StockTake_ID))
            {
                if (CalculateDifference() == 0)
                {
                    if (XMessage.Box.Show(this, lng.s_AreYouSureToLock_StockTake, "?", MessageBoxButtons.YesNo, null, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        f_StockTake.Lock(StockTake_ID);
                        m_Changed = true;
                    }
                }
                else
                {
                    XMessage.Box.Show(this, false, lng.s_YouCanNotLock_StockTakeIfSumNotMatch);
                }
            }
        }

        private void dgvx_StockTakeItemsAndPrices_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection dgvxrc = dgvx_StockTakeItemsAndPrices.SelectedRows;
            if (dgvxrc.Count > 0)
            {
                current_index = dgvxrc[0].Index;
                if (current_index >= 0)
                {
                    CurrentStock_ID = (long)dt_Stock_Of_Current_StockTake.Rows[current_index]["Stock_ID"];
                    CurrentItem_ID = (long)dt_Stock_Of_Current_StockTake.Rows[current_index]["Item_ID"];
                }
                else
                {
                    CurrentStock_ID = -1;
                    CurrentItem_ID = -1;
                }
            }
            else
            {
                CurrentStock_ID = -1;
                CurrentItem_ID = -1;
            }
            FillControls();
        }


        private void chk_ExpiryCheck_CheckedChanged(object sender, EventArgs e)
        {
            this.TPiick_ExpiryDate.Enabled = chk_ExpiryCheck.Checked;
        }

        private void btn_AdditionalCost_Click(object sender, EventArgs e)
        {
            Form_StockTake_AdditionalCost_Edit frm_add_cost = new Form_StockTake_AdditionalCost_Edit(this.StockTake_ID, this.StockTakeName);
            frm_add_cost.ShowDialog(this);
            if (frm_add_cost.Changed)
            {
                this.m_Changed = true;
                this.CalculateDifference();
            }
        }

        private void btn_Remove_Click(object sender, EventArgs e)
        {
            RemoveItemFromStockTake();
        }

        private void RemoveItemFromStockTake()
        {
            if (f_Stock.Remove(this.CurrentStock_ID,this.StockTake_ID))
            {
                m_Changed = true;
                Reload(StockTakeTable);
                if (dt_Stock_Of_Current_StockTake.Rows.Count == 0)
                {
                    current_index = -1;
                }
                if (current_index >= dt_Stock_Of_Current_StockTake.Rows.Count)
                {
                    current_index = dt_Stock_Of_Current_StockTake.Rows.Count - 1;
                }
                if (current_index >= 0)
                {
                    CurrentStock_ID = (long)dt_Stock_Of_Current_StockTake.Rows[current_index]["Stock_ID"];
                    CurrentItem_ID = (long)dt_Stock_Of_Current_StockTake.Rows[current_index]["Item_ID"];
                }
                else
                {
                    CurrentStock_ID = -1;
                    CurrentItem_ID = -1;
                }
                FillControls();
            }
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            if (Check_dQuantity())
            {
                UpdateStock();
            }
        }

        public void UpdateStock()
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
                    catch 
                    {
                        XMessage.Box.ShowTopMost(this, lng.s_InvalidPurchasePrice, lng.s_Warning.s, MessageBoxButtons.OK, null, MessageBoxDefaultButton.Button1);
                    }
                }
            }

            long PurchasePrice_ID = -1;
            long Taxation_ID = (long)cmb_Taxation.SelectedValue;
            long Currency_ID = (long)cmb_Currency.SelectedValue;
            if (TangentaDB.f_PurchasePrice.Get(pprice, Taxation_ID, Currency_ID, ref PurchasePrice_ID))
            {
                if ((bPPriceDefined) && (CurrentItem_ID >= 0) && (StockTake_ID >= 0))
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
                        if (TangentaDB.f_Stock.Update(CurrentStock_ID,tImportTime, dquantity, dtExpiry_v, PurchasePrice_Item_ID, Stock_AddressLevel1_ID, this.txt_StockDescription.Text))
                        {
                            m_Changed = true;
                            if (Reload(StockTakeTable))
                            {
                                DataRow[] drs = dt_Stock_Of_Current_StockTake.Select("Stock_ID = " + CurrentStock_ID);
                                if (drs.Length > 0)
                                {
                                    current_index = this.dt_Stock_Of_Current_StockTake.Rows.IndexOf(drs[0]);
                                    this.dgvx_StockTakeItemsAndPrices.Rows[current_index].Selected = true;
                                }

                            }
                            return;
                        }
                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:ShopC:usrc_StockEditForSelectedStockTake.cs:AddItemToStock:Err=!((bPPriceDefined)&& (CurrentItem_ID >= 0)&&(StockTake_ID>=0))");
                }
            }
        }

        private void Show_Documents_Where_stock_item_was_sold_or_reserved(long Stock_ID,Doc_ShopC_Item_Data[] adata)
        {
            Form_Show_Documents_Where_stock_item_was_sold_or_reserved frs = new Form_Show_Documents_Where_stock_item_was_sold_or_reserved(Stock_ID, adata);
            frs.ShowDialog(this);
        }

        private void dgvx_StockTakeItemsAndPrices_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == 0)
                {
                    if (aDoc_ShopC_Item[e.RowIndex] != null)
                    {
                        if (aDoc_ShopC_Item[e.RowIndex].adata != null)
                        {
                            if (aDoc_ShopC_Item[e.RowIndex].adata.Length > 0)
                            {
                                Show_Documents_Where_stock_item_was_sold_or_reserved(aDoc_ShopC_Item[e.RowIndex].Stock_ID, aDoc_ShopC_Item[e.RowIndex].adata);
                            }
                        }
                    }
                }
            }
        }

        internal decimal CalculateDifference()
        {
            if (fs.IDisValid(StockTake_ID))
            {
                object oTotalPrice = m_StockTakeTable.Value("StockTakePriceTotal");
                decimal dTotalPrice = 0;
                if (oTotalPrice is TangentaTableClass.StockTakePriceTotal)
                {
                    if (((TangentaTableClass.StockTakePriceTotal)oTotalPrice).defined)
                    {
                        dTotalPrice = ((TangentaTableClass.StockTakePriceTotal)oTotalPrice).val;
                    }
                }
                decimal dTruckingCost = 0;
                decimal dCustoms = 0;
                object oTruckingCosts = m_StockTakeTable.Value("StockTake_$_trc_$$TruckingCost");
                if (oTruckingCosts is TangentaTableClass.TruckingCost)
                {
                    if (((TangentaTableClass.TruckingCost)oTruckingCosts).defined)
                    {
                        dTruckingCost = ((TangentaTableClass.TruckingCost)oTruckingCosts).val;
                    }
                    
                }
                object oCustoms = m_StockTakeTable.Value("StockTake_$_trc_$$Customs");
                if (oCustoms is TangentaTableClass.Customs)
                {
                    if (((TangentaTableClass.Customs)oCustoms).defined)
                    {
                        dCustoms = ((TangentaTableClass.Customs)oCustoms).val;
                    }
                }

                decimal dItemsPrice = 0;
                foreach (DataRow dr in dt_Stock_Of_Current_StockTake.Rows)
                {
                    decimal dQuantity = (decimal)dr["dInitialQuantity"];
                    decimal dPurchasePricePerUnit = (decimal)dr["PurchasePricePerUnit"];
                    dItemsPrice += dQuantity * dPurchasePricePerUnit;
                }
                decimal dAdditionalCost = 0;
                DataTable dtStockTake_AdditionalCost = new DataTable();
                if (TangentaDB.f_StockTake_AdditionalCost.ReadDataTable(ref dtStockTake_AdditionalCost, StockTake_ID))
                {
                    foreach (DataRow dr in dtStockTake_AdditionalCost.Rows)
                    {
                        decimal addCost = (decimal)dr["Cost"];
                        dAdditionalCost += addCost;
                    }
                }
                decimal dTruckingCostPLUSdCustomsPLUSdAdditionalCost =  dTruckingCost + dCustoms + dAdditionalCost;
                decimal difference = dTotalPrice - dTruckingCostPLUSdCustomsPLUSdAdditionalCost - dItemsPrice ;

                ShowComputationOfDifference(dTotalPrice, dTruckingCostPLUSdCustomsPLUSdAdditionalCost, dItemsPrice,difference);
                return difference;
            }
            else
            {
                return -1;
            }
        }

        private void ShowComputationOfDifference(decimal dTotalPrice, decimal dTruckingCostPLUSdCustomsPLUSdAdditionalCost, decimal dItemsPrice, decimal difference)
        {
            txt_TotalPrice.Text = Convert.ToString(dTotalPrice);
            txt_TruckingCustomsPlusAddtitional.Text = Convert.ToString(dTruckingCostPLUSdCustomsPLUSdAdditionalCost);
            txt_ItemsPrice.Text = Convert.ToString(dItemsPrice);
            if (difference != 0)
            {
                txt_Difference.BackColor = Color.LightPink;
            }
            else
            {
                txt_Difference.BackColor = Color.LightGreen;
            }
            txt_Difference.Text = Convert.ToString(difference);
        }
    }
}
