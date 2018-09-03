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
using DBConnectionControl40;
using TangentaPrint;

namespace ShopC
{
    public partial class usrc_StockEditForSelectedStockTake : UserControl
    {
        private const string scol_TotalWithoutTaxWithDiscount = "TotalWithoutTaxWithDiscount";
        private const string scol_TotalWithTaxWithDiscount = "TotalWithTaxWithDiscount";

        private ID m_Atom_WorkPeriod_ID = null;

        public delegate void delegate_BtnExitPressed();
        public event delegate_BtnExitPressed BtnExitPressed = null;

        internal Form_ShopC_Item_Edit edt_Item_dlg = null;


        private bool m_PriceWithoutVAT = true;
        private bool PriceWithoutVAT
        {
            get
            {
                return m_PriceWithoutVAT;
            }
            set
            {
                m_PriceWithoutVAT = value;
            }
        }

        private bool m_Changed = false;
        public bool Changed
        {
            get { return m_Changed; }
        }



        private Form_StockTake_Edit m_Form_StockTake_Edit = null;



        private int current_index = -1;

        private ID m_CurrentItem_ID = null;
        private ID m_CurrentStock_ID = null;


        private SQLTable m_StockTakeTable = null;

        private bool m_Draft = false;

        private DataTable dt_Stock_Of_Current_StockTake = new DataTable();

        internal Doc_ShopC_Item[] aDoc_ShopC_Item = null;


        internal ID CurrentItem_ID
        {
            get { return m_CurrentItem_ID; }
            set
            {
                m_CurrentItem_ID = value;
            }

        }


        internal ID CurrentStock_ID
        {
            get { return m_CurrentStock_ID; }
            set
            {
                m_CurrentStock_ID = value;
            }

        }


        internal ID StockTake_ID
        {
            get {
                    if (m_StockTakeTable != null)
                    {
                        object o_StockTake_ID = m_StockTakeTable.Value("ID");
                        return tf.set_ID(o_StockTake_ID);
                    }
                    return null;
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

        internal string_v Description_v
        {
            get
            {
                if (m_StockTakeTable != null)
                {
                    object o_Description = m_StockTakeTable.Value("Description");
                    if (o_Description is TangentaTableClass.Description)
                    {
                        if (((TangentaTableClass.Description)o_Description).defined)
                        {
                            return new string_v(((TangentaTableClass.Description)o_Description).val);
                        }
                    }
                }
                return null;
            }
        }


        internal DateTime_v StockTake_Date_v
        {
            get
            {
                if (m_StockTakeTable != null)
                {
                    object o_StockTake_Date = m_StockTakeTable.Value("StockTake_Date");
                    if (o_StockTake_Date is TangentaTableClass.StockTake_Date)
                    {
                        if (((TangentaTableClass.StockTake_Date)o_StockTake_Date).defined)
                        {
                            return new DateTime_v(((TangentaTableClass.StockTake_Date)o_StockTake_Date).val);
                        }
                    }
                }
                return null;
            }
        }

        internal string_v ReferenceNote_v
        {
            get
            {
                if (m_StockTakeTable != null)
                {
                    object o_ReferenceNote = m_StockTakeTable.Value("StockTake_$_ref_$$ReferenceNote");
                    if (o_ReferenceNote is TangentaTableClass.ReferenceNote)
                    {
                        if (((TangentaTableClass.ReferenceNote)o_ReferenceNote).defined)
                        {
                            return new string_v(((TangentaTableClass.ReferenceNote)o_ReferenceNote).val);
                        }
                    }
                }
                return null;
            }
        }
        

        internal decimal_v StockTakePriceTotal
        {
            get
            {
                if (m_StockTakeTable != null)
                {
                    object o_StockTakePriceTotal = m_StockTakeTable.Value("StockTakePriceTotal");
                    if (o_StockTakePriceTotal is TangentaTableClass.StockTakePriceTotal)
                    {
                        if (((TangentaTableClass.StockTake_Date)o_StockTakePriceTotal).defined)
                        {
                            return  new decimal_v(((TangentaTableClass.StockTakePriceTotal)o_StockTakePriceTotal).val);
                        }
                    }
                }
                return null;
            }
        }

        internal ID Reference_ID
        {
            get
            {
                if (m_StockTakeTable != null)
                {
                    object o_Reference_ID = m_StockTakeTable.Value("Reference_ID");
                    if (o_Reference_ID is TangentaTableClass.Reference)
                    {
                        if (ID.Validate(((TangentaTableClass.Reference)o_Reference_ID).ID))
                        {
                            return ((TangentaTableClass.Reference)o_Reference_ID).ID;
                        }
                    }
                }
                return null;
            }
        }

        internal ID Supplier_ID
        {
            get
            {
                if (m_StockTakeTable != null)
                {
                    object o_Supplier_ID = m_StockTakeTable.Value("Supplier_ID");
                    if (o_Supplier_ID is TangentaTableClass.Supplier)
                    {
                        if (ID.Validate(((TangentaTableClass.Supplier)o_Supplier_ID).ID))
                        {
                            return ((TangentaTableClass.Reference)o_Supplier_ID).ID;
                        }
                    }
                }
                return null;
            }
        }

        internal string_v Supplier_Name_v
        {
            get
            {
                if (m_StockTakeTable != null)
                {
                    object o_Supplier_Name = m_StockTakeTable.Value("StockTake_$_sup_$_c_$_orgd_$_org_$$Name");
                    if (o_Supplier_Name is TangentaTableClass.Name)
                    {
                        if (((TangentaTableClass.Name)o_Supplier_Name).defined)
                        {
                            return new string_v(((TangentaTableClass.Name)o_Supplier_Name).val);
                        }
                    }
                }
                return null;
            }
        }

        internal string_v Supplier_TaxID_v
        {
            get
            {
                if (m_StockTakeTable != null)
                {
                    object o_SupplierTaxID = m_StockTakeTable.Value("StockTake_$_sup_$_c_$_orgd_$_org_$$Tax_ID");
                    if (o_SupplierTaxID is TangentaTableClass.Tax_ID)
                    {
                        if (((TangentaTableClass.Tax_ID)o_SupplierTaxID).defined)
                        {
                            return new string_v(((TangentaTableClass.Tax_ID)o_SupplierTaxID).val);
                        }
                    }
                }
                return null;
            }
        }

        internal bool_v StockTake_Draft_v
        {
            get
            {
                if (m_StockTakeTable != null)
                {
                    object o_StockTake_Draft = m_StockTakeTable.Value("StockTake_$$Draft");
                    if (o_StockTake_Draft is TangentaTableClass.Draft)
                    {
                        if (((TangentaTableClass.Draft)o_StockTake_Draft).defined)
                        {
                            return new bool_v(((TangentaTableClass.Draft)o_StockTake_Draft).val);
                        }
                    }
                }
                return null;
            }
        }

        


        public usrc_StockEditForSelectedStockTake()
        {
            InitializeComponent();
            EnableControls(false);

        }


        internal void Init(Form_StockTake_Edit xForm_StockTake_Edit,ID xAtom_WorkPeriod_ID)
        {
            m_Form_StockTake_Edit = xForm_StockTake_Edit;
            m_Atom_WorkPeriod_ID = xAtom_WorkPeriod_ID;
        }

        internal void SetItem(ID ID,string xUniqueName, string symbol,short uDecimalPlaces)
        {
            CurrentItem_ID = ID;
            lng.s_Item.TextWithToolTip(this.grp_Item, lng.s_Item.s + ":" + xUniqueName, lng.s_Item.s + ":" + xUniqueName + " " + lng.s_Unit.s + ":" + symbol + " ; " + lng.s_DecimalPlaces.s + "=" + uDecimalPlaces.ToString());
            usrc_StockTake_Item1.SetQuantity_NumericUpdDown(uDecimalPlaces);

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
            }
            edt_Item_dlg.Owner = Global.f.GetParentForm(this);
            edt_Item_dlg.Show();
        }

        internal void DoClose()
        {
            if (edt_Item_dlg!=null)
            {
                edt_Item_dlg.Close();
            }
        }

        internal void Selected_Item_Index_Changed(SQLTable m_tbl, ID iD, int index)
        {
            if (ID.Validate(iD))
            {
                if (ID.Validate(CurrentItem_ID))
                {
                    Set_cmb_PurchasePrice(iD, usrc_StockTake_Item1.Selected_Currency_ID);
                }
            }
        }

        private void Set_cmb_PurchasePrice(ID Item_ID, ID Currency_ID)
        {
            usrc_StockTake_Item1.Set_cmb_PurchasePrice(Item_ID, Currency_ID);
        }


        private void usrc_StockEditForSelectedStockTake_Load(object sender, EventArgs e)
        {

            if (!DesignMode)
            {
                lng.s_SelectedItem.Text(btn_SelectItem);
                lng.s_Add.Text(btn_Add);
                lng.s_Remove.Text(btn_Remove);
                lng.s_Update.Text(this.btn_Update);
                lng.s_ExpiryDate.Text(chk_ExpiryCheck);
                lng.s_ImportTime.Text(lbl_ImportTime);
                lng.s_Stock_Description.Text(lbl_Stock_Description);
                lng.s_btn_CloseStockTake.Text(btn_CloseStockTake);
                lng.s_btn_AdditionalCost.Text(btn_AdditionalCost);
                lng.s_lbl_PriceWithoutVAT.Text(this.lbl_TotalPriceWithoutTax);
                lng.s_lbl_Difference.Text(this.lbl_Difference);
                lng.s_lbl_TruckingCustosPlusAddtional.Text(lbl_TruckingCustosPlusAddtional);
                lng.s_lbl_TotalTax.Text(lbl_TotalTax);

                btn_Add.Visible = false;
                btn_Remove.Visible = false;
                btn_Update.Visible = false;

                // Set up the ToolTip text for the control

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

        private bool Check_PurchasePricePerUnit()
        {
            bool bTopmost = edt_Item_dlg != null;
            return usrc_StockTake_Item1.Check_PurchasePricePerUnit(bTopmost);
        }

        private bool Check_Item()
        {
           if (ID.Validate(CurrentItem_ID))
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
            bool bTopmost = edt_Item_dlg != null;
            return usrc_StockTake_Item1.Check_dQuantity(bTopmost);
        }


        private void AddItemToStockTake()
        {

            ID PurchasePrice_ID = null;
            ID Taxation_ID = usrc_StockTake_Item1.Taxation_ID;
            ID Currency_ID = usrc_StockTake_Item1.Selected_Currency_ID;
            if (TangentaDB.f_PurchasePrice.Get(usrc_StockTake_Item1.PurchasePricePerUnitWithoutTax, usrc_StockTake_Item1.Discount, PriceWithoutVAT, usrc_StockTake_Item1.VATCanNotBeDeducted, Taxation_ID, Currency_ID, ref PurchasePrice_ID))
            {
                if ((usrc_StockTake_Item1.PPriceDefined) && (ID.Validate(CurrentItem_ID)) && (ID.Validate(StockTake_ID)))
                {
                    ID PurchasePrice_Item_ID = null;
                    if (TangentaDB.f_PurchasePrice_Item.Get(CurrentItem_ID, PurchasePrice_ID, StockTake_ID, ref PurchasePrice_Item_ID))
                    {
                        DateTime_v dtExpiry_v = null;
                        if (chk_ExpiryCheck.Checked)
                        {
                            dtExpiry_v = new DateTime_v(this.TPiick_ExpiryDate.Value);
                        }
                        DateTime tImportTime = tPick_ImportTime.Value;
                        decimal dquantity = usrc_StockTake_Item1.Quantity;
                        ID Stock_AddressLevel1_ID = null;
                        ID Stock_ID = null;
                        if (TangentaDB.f_Stock.Add(m_Atom_WorkPeriod_ID, tImportTime, dquantity, dtExpiry_v, PurchasePrice_Item_ID, Stock_AddressLevel1_ID, this.txt_StockDescription.Text, ref Stock_ID))
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

        private bool Reload(ID xStockTake_ID)
        {
            dgvx_StockTakeItemsAndPrices.DataSource = null;
            this.dgvx_StockTakeItemsAndPrices.SelectionChanged -= new System.EventHandler(this.dgvx_StockTakeItemsAndPrices_SelectionChanged);
            if (TangentaDB.f_Stock.GeStockTakeItems(ref dt_Stock_Of_Current_StockTake, ref aDoc_ShopC_Item, StockTake_ID))
            {
                decimal xCalculatedSum_withouttax = 0;
                AddCalculatedColumns(dt_Stock_Of_Current_StockTake,ref xCalculatedSum_withouttax);
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
                    ((DataGridViewDisableButtonCell.DataGridViewDisableButtonCell)dgvx_StockTakeItemsAndPrices.Rows[i].Cells[0]).visible = true;
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
                    CurrentStock_ID = tf.set_ID(dt_Stock_Of_Current_StockTake.Rows[current_index]["Stock_ID"]);
                    CurrentItem_ID = tf.set_ID(dt_Stock_Of_Current_StockTake.Rows[current_index]["Item_ID"]);

                    ID xCurrency_ID = usrc_StockTake_Item1.Selected_Currency_ID;
                    if (ID.Validate(xCurrency_ID))
                    {
                        Set_cmb_PurchasePrice(CurrentItem_ID, xCurrency_ID);
                    }

                    dgvx_StockTakeItemsAndPrices.Rows[current_index].Selected = true;
                    btn_Remove.Visible = true;
                    btn_Update.Visible = true;
                }
                else
                {
                    CurrentStock_ID = null;
                    CurrentItem_ID = null;
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

        private void AddCalculatedColumns(DataTable dt_Stock_Of_Current_StockTake, ref decimal calculatedsum_withouttax)
        {
            DataColumn col_TotalWithoutTaxWithDiscount = new DataColumn(scol_TotalWithoutTaxWithDiscount, typeof(decimal));
            dt_Stock_Of_Current_StockTake.Columns.Add(col_TotalWithoutTaxWithDiscount);
            DataColumn col_TotalWithTaxWithDiscount = new DataColumn(scol_TotalWithTaxWithDiscount, typeof(decimal));
            dt_Stock_Of_Current_StockTake.Columns.Add(col_TotalWithTaxWithDiscount);
            calculatedsum_withouttax = 0;
            foreach (DataRow dr in dt_Stock_Of_Current_StockTake.Rows)
            {
                decimal xPurchasePricePerUnitWithoutTax = (decimal)dr["PurchasePricePerUnit"];
                decimal xTaxationRate = (decimal)dr["TaxationRate"];
                decimal xDiscount = (decimal)dr["Discount"];
                decimal xQuantity = (decimal)dr["dInitialQuantity"];

                decimal xPurchasePricePerUnitWithTax = xPurchasePricePerUnitWithoutTax * (1 + xTaxationRate);

                decimal xPurchasePricePerUnitWithoutTaxWithDiscount = decimal.Round(xPurchasePricePerUnitWithoutTax * (1 - xDiscount), 4);

                decimal xPurchasePricePerUnitWithTaxWithDiscount = xPurchasePricePerUnitWithoutTaxWithDiscount * (1 + xTaxationRate);

                decimal xTotalWithoutTaxWithDiscount = decimal.Round(xPurchasePricePerUnitWithoutTax * (1 - xDiscount) * xQuantity, 4);

                decimal xTotalWithTaxWithDiscount = decimal.Round(xTotalWithoutTaxWithDiscount * (1 + xTaxationRate),usrc_StockTake_Item1.Currency_DecimalPlaces);

                dr["TotalWithoutTaxWithDiscount"] = xTotalWithoutTaxWithDiscount;
                calculatedsum_withouttax += xTotalWithoutTaxWithDiscount;

                dr["TotalWithTaxWithDiscount"] = xTotalWithTaxWithDiscount;
            }
            calculatedsum_withouttax = decimal.Round(calculatedsum_withouttax, usrc_StockTake_Item1.Currency_DecimalPlaces);
        }

        private void Set_StockTakeItems_Table_headers()
        {
            dgvx_StockTakeItemsAndPrices.Columns["UniqueName"].HeaderText = lng.s_UniqueName.s;
            dgvx_StockTakeItemsAndPrices.Columns["UniqueName"].DisplayIndex = 1;
            dgvx_StockTakeItemsAndPrices.Columns["dInitialQuantity"].HeaderText = lng.s_Stock_dInitialQuantity.s;
            dgvx_StockTakeItemsAndPrices.Columns["dInitialQuantity"].DisplayIndex = 2;
            dgvx_StockTakeItemsAndPrices.Columns["dQuantity"].HeaderText = lng.s_Stock_dQuantity.s;
            dgvx_StockTakeItemsAndPrices.Columns["dQuantity"].DisplayIndex = 3;
            dgvx_StockTakeItemsAndPrices.Columns["PurchasePricePerUnit"].HeaderText = lng.s_PurchasePricePerUnit.s;
            dgvx_StockTakeItemsAndPrices.Columns["PurchasePricePerUnit"].DisplayIndex = 4;
            dgvx_StockTakeItemsAndPrices.Columns["TotalWithoutTaxWithDiscount"].HeaderText = lng.s_PriceTotalWithDiscountWithoutVAT.s;
            dgvx_StockTakeItemsAndPrices.Columns["TotalWithoutTaxWithDiscount"].DisplayIndex = 5;
            dgvx_StockTakeItemsAndPrices.Columns["TotalWithTaxWithDiscount"].HeaderText = lng.s_PriceTotalWithDiscountWithVAT.s;
            dgvx_StockTakeItemsAndPrices.Columns["TotalWithTaxWithDiscount"].DisplayIndex = 6;
            dgvx_StockTakeItemsAndPrices.Columns["TaxationName"].HeaderText = lng.s_Taxation.s;
            dgvx_StockTakeItemsAndPrices.Columns["TaxationName"].DisplayIndex = 7;
            dgvx_StockTakeItemsAndPrices.Columns["ImportTime"].HeaderText = lng.s_ImportTime.s;
            dgvx_StockTakeItemsAndPrices.Columns["ImportTime"].DisplayIndex = 8;
            dgvx_StockTakeItemsAndPrices.Columns["ExpiryDate"].HeaderText = lng.s_ExpiryDate.s;
            dgvx_StockTakeItemsAndPrices.Columns["ExpiryDate"].DisplayIndex = 9;
            dgvx_StockTakeItemsAndPrices.Columns["Supplier"].HeaderText = lng.s_Supplier.s;
            dgvx_StockTakeItemsAndPrices.Columns["Supplier"].DisplayIndex = 10;
            dgvx_StockTakeItemsAndPrices.Columns["TruckingOrganisation"].HeaderText = lng.s_TruckingOrganisation.s;
            dgvx_StockTakeItemsAndPrices.Columns["TruckingOrganisation"].DisplayIndex = 10;
            dgvx_StockTakeItemsAndPrices.Columns["Symbol"].HeaderText = lng.s_Currency.s;
            dgvx_StockTakeItemsAndPrices.Columns["Symbol"].DisplayIndex = 11;


            dgvx_StockTakeItemsAndPrices.Columns["Supplier_Tax_ID"].Visible = false;
            dgvx_StockTakeItemsAndPrices.Columns["StockTakePriceTotal"].Visible = false;
            dgvx_StockTakeItemsAndPrices.Columns["TruckingCost"].Visible = false;
            dgvx_StockTakeItemsAndPrices.Columns["Customs"].Visible = false;
            dgvx_StockTakeItemsAndPrices.Columns["PurchasePrice_ID"].Visible = false;
            dgvx_StockTakeItemsAndPrices.Columns["Currency_ID"].Visible = false;
            dgvx_StockTakeItemsAndPrices.Columns["Taxation_ID"].Visible = false;
            dgvx_StockTakeItemsAndPrices.Columns["TaxationRate"].Visible = false;
        }

        private void FillControls()
        {
            lng.s_lbl_StockTakeName.Text(lbl_StockTakeName, " : " + StockTakeName);
            if (ID.Validate(CurrentStock_ID))
            {
                bool_v StockTake_Draft_v = tf.set_bool(dt_Stock_Of_Current_StockTake.Rows[current_index]["Draft"]);
                bool bClosed = false;
                if (StockTake_Draft_v != null)
                {
                    bClosed = !StockTake_Draft_v.v;
                }

                if (bClosed)
                {
                    btn_CloseStockTake.Enabled = false;
                }
                else
                {
                    btn_CloseStockTake.Enabled = true;
                }

                string sItem_UniqueName = ((string)dt_Stock_Of_Current_StockTake.Rows[current_index]["UniqueName"]);
                string sItem_UnitName = ((string)dt_Stock_Of_Current_StockTake.Rows[current_index]["UnitName"]);
                string sItem_UnitSymbol = ((string)dt_Stock_Of_Current_StockTake.Rows[current_index]["UnitSymbol"]);
                int iItem_UnitDecimalPlaces = ((int)dt_Stock_Of_Current_StockTake.Rows[current_index]["UnitDecimalPlaces"]);
                usrc_StockTake_Item1.SetQuantity_NumericUpdDown(iItem_UnitDecimalPlaces);
                
                lng.s_Item.TextWithToolTip(grp_Item, ":" + sItem_UniqueName, lng.s_Item.s + " : " + lng.s_Unit.s + " = " + sItem_UnitSymbol + " : " + lng.s_DecimalPlaces.s + " = " + iItem_UnitDecimalPlaces.ToString());
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

                usrc_StockTake_Item1.Init(dt_Stock_Of_Current_StockTake.Rows[current_index]);


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
                lng.s_Item.TextWithToolTip(grp_Item, ":", "");
                usrc_StockTake_Item1.SetInitialValues();

                EnableControls(false);
            }
        }



        private void EnableControls(bool v)
        {
            usrc_StockTake_Item1.EnableControls(v);
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
            if (ID.Validate(StockTake_ID))
            {
                if (CalculateDifference() == 0)
                {
                    if (XMessage.Box.Show(this, lng.s_AreYouSureToLock_StockTake, "?", MessageBoxButtons.YesNo, null, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        f_StockTake.Lock(m_Atom_WorkPeriod_ID,StockTake_ID);
                        m_Changed = true;
                        m_Form_StockTake_Edit.Init();
                    }
                }
                else
                {
                    XMessage.Box.Show(this, false, lng.s_YouCanNotLock_StockTakeIfSumNotMatch,MessageBoxIcon.Warning);
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
                    CurrentStock_ID = tf.set_ID(dt_Stock_Of_Current_StockTake.Rows[current_index]["Stock_ID"]);
                    CurrentItem_ID = tf.set_ID(dt_Stock_Of_Current_StockTake.Rows[current_index]["Item_ID"]);
                    if (ID.Validate(CurrentItem_ID))
                    {
                        ID Selected_Currency_ID = null;
                        Selected_Currency_ID = usrc_StockTake_Item1.Selected_Currency_ID;
                        if (ID.Validate(Selected_Currency_ID))
                        {
                            Set_cmb_PurchasePrice(CurrentItem_ID, Selected_Currency_ID);
                        }
                    }

                }
                else
                {
                    CurrentStock_ID = null;
                    CurrentItem_ID = null;
                }
            }
            else
            {
                CurrentStock_ID = null;
                CurrentItem_ID = null;
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
                    CurrentStock_ID = tf.set_ID(dt_Stock_Of_Current_StockTake.Rows[current_index]["Stock_ID"]);
                    CurrentItem_ID = tf.set_ID(dt_Stock_Of_Current_StockTake.Rows[current_index]["Item_ID"]);
                }
                else
                {
                    CurrentStock_ID = null;
                    CurrentItem_ID = null;
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
            ID PurchasePrice_ID = null;
            ID Taxation_ID = usrc_StockTake_Item1.Taxation_ID;
            ID Currency_ID = usrc_StockTake_Item1.Selected_Currency_ID;
            if (TangentaDB.f_PurchasePrice.Get(usrc_StockTake_Item1.PurchasePricePerUnitWithoutTax, usrc_StockTake_Item1.Discount, PriceWithoutVAT, usrc_StockTake_Item1.VATCanNotBeDeducted, Taxation_ID, Currency_ID, ref PurchasePrice_ID))
            {
                if ((usrc_StockTake_Item1.PPriceDefined) && (ID.Validate(CurrentItem_ID)) && (ID.Validate(StockTake_ID)))
                {
                    ID PurchasePrice_Item_ID = null;
                    if (TangentaDB.f_PurchasePrice_Item.Get(CurrentItem_ID, PurchasePrice_ID, StockTake_ID, ref PurchasePrice_Item_ID))
                    {
                        DateTime_v dtExpiry_v = null;
                        if (chk_ExpiryCheck.Checked)
                        {
                            dtExpiry_v = new DateTime_v(this.TPiick_ExpiryDate.Value);
                        }
                        DateTime tImportTime = tPick_ImportTime.Value;
                        decimal dquantity = usrc_StockTake_Item1.Quantity;
                        ID Stock_AddressLevel1_ID = null;
                        if (TangentaDB.f_Stock.Update(m_Atom_WorkPeriod_ID, CurrentStock_ID, tImportTime, dquantity, dtExpiry_v, PurchasePrice_Item_ID, Stock_AddressLevel1_ID, this.txt_StockDescription.Text))
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

        private void Show_Documents_Where_stock_item_was_sold_or_reserved(ID Stock_ID,Doc_ShopC_Item_Data[] adata)
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
            if (ID.Validate(StockTake_ID))
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

                decimal dItemsPrice_withouttax = 0;
                decimal dItemsPrice_withttax = 0;
                foreach (DataRow dr in dt_Stock_Of_Current_StockTake.Rows)
                {
                    decimal xPurchasePricePerUnitWithoutTax = (decimal)dr["PurchasePricePerUnit"];
                    decimal xTaxationRate = (decimal)dr["TaxationRate"];
                    decimal xDiscount = (decimal)dr["Discount"];
                    decimal xQuantity = (decimal)dr["dInitialQuantity"];

                    decimal xPurchasePricePerUnitWithTax = xPurchasePricePerUnitWithoutTax * (1 + xTaxationRate);

                    decimal xPurchasePricePerUnitWithoutTaxWithDiscount = decimal.Round(xPurchasePricePerUnitWithoutTax * (1 - xDiscount), 4);

                    decimal xPurchasePricePerUnitWithTaxWithDiscount = xPurchasePricePerUnitWithoutTaxWithDiscount * (1 + xTaxationRate);

                    decimal xTotalWithoutTaxWithDiscount = decimal.Round(xPurchasePricePerUnitWithoutTax * (1 - xDiscount) * xQuantity, 4);

                    dItemsPrice_withouttax += xTotalWithoutTaxWithDiscount;

                    decimal xTotalWithTaxWithDiscount = decimal.Round(xTotalWithoutTaxWithDiscount * (1 + xTaxationRate), usrc_StockTake_Item1.Currency_DecimalPlaces);

                    dItemsPrice_withttax += xTotalWithTaxWithDiscount;

                }

                dItemsPrice_withouttax = decimal.Round(dItemsPrice_withouttax, usrc_StockTake_Item1.Currency_DecimalPlaces);
                dItemsPrice_withttax = decimal.Round(dItemsPrice_withttax, usrc_StockTake_Item1.Currency_DecimalPlaces);
                decimal dVAT = dItemsPrice_withttax - dItemsPrice_withouttax;

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
                decimal difference = dTotalPrice - dTruckingCostPLUSdCustomsPLUSdAdditionalCost - dItemsPrice_withouttax ;

                ShowComputationOfDifference(dItemsPrice_withouttax,dVAT, dTruckingCostPLUSdCustomsPLUSdAdditionalCost, difference);
                return difference;
            }
            else
            {
                return -1;
            }
        }

        private void ShowComputationOfDifference(decimal dItemsPrice_withouttax,decimal dVAT, decimal dTruckingCostPLUSdCustomsPLUSdAdditionalCost,  decimal difference)
        {
            txt_TotalPriceWithoutTax.Text = Convert.ToString(dItemsPrice_withouttax);
            txt_TruckingCustomsPlusAddtitional.Text = Convert.ToString(dTruckingCostPLUSdCustomsPLUSdAdditionalCost);
            txt_VAT.Text = Convert.ToString(dVAT);
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

        private void btn_Print_Click(object sender, EventArgs e)
        {
            DateTime xStockTake_Date = DateTime.MaxValue;
            DateTime_v xStockTake_Date_v = StockTake_Date_v;
            if (xStockTake_Date_v != null)
            {
               xStockTake_Date = xStockTake_Date_v.v;

            }
            string_v xsupplier_name_v = Supplier_Name_v;
            string suppliername = "";
            if (xsupplier_name_v!=null)
            {
                suppliername = xsupplier_name_v.v;
            }

            string_v xsupplier_taxID_v = Supplier_TaxID_v;
            string suppliertaxID = "";
            if (xsupplier_taxID_v != null)
            {
                suppliertaxID = Supplier_TaxID_v.v;
            }

            string myorg_name = "";
            if (myOrg.Name_v!=null)
            {
                myorg_name = myOrg.Name_v.v;
            }

            string myorg_TaxID = "";
            if (myOrg.Tax_ID_v != null)
            {
                myorg_TaxID = myOrg.Tax_ID_v.v;
            }

            string reference_note = "";
            string_v xReferenceNote_v = ReferenceNote_v;
            if (xReferenceNote_v!=null)
            {
                reference_note = xReferenceNote_v.v;
            }
            PrintStockTake prnstocktake = new PrintStockTake(StockTakeName,
                                                             xStockTake_Date,
                                                             suppliername,
                                                             suppliertaxID,
                                                             myorg_name,
                                                             myorg_TaxID,
                                                             reference_note,
                                                             dt_Stock_Of_Current_StockTake
                                                             );

            prnstocktake.Print(this);
        }
    }
}
