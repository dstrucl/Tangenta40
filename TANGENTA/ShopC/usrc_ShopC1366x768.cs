﻿#region LICENSE 
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
using System.Windows.Forms;
using TangentaTableClass;
using CodeTables;
using LanguageControl;
using TangentaDB;
using PriseLists;
using DBTypes;
using DBConnectionControl40;

namespace ShopC
{
    public partial class usrc_ShopC1366x768: UserControl
    {
        /// <summary>
        /// eMode eMode { VIEW, EDIT }: VIEW mode is for closed documents (invoices, proforma invoices etc..)
        ///                             EDIT mode is for draft documents only
        /// </summary>
        public enum eMode { VIEW, EDIT };

        public delegate bool delegate_CheckIfAdministrator();
        public event delegate_CheckIfAdministrator CheckIfAdministrator = null;

        public delegate bool delegate_CheckAccessPriceList();
        public event delegate_CheckAccessPriceList CheckAccessPriceList = null;

        public delegate bool delegate_CheckAccessStock();
        public event delegate_CheckAccessStock CheckAccessStock = null;

        public delegate void delegate_ItemAdded();

        /// <summary>
        /// Raised After Item is added
        /// </summary>
        public event delegate_ItemAdded ItemAdded = null;

        public delegate void delegate_After_Atom_Item_Remove();

        /// <summary>
        /// Raised After Atom Item Removed
        /// </summary>
        public event delegate_After_Atom_Item_Remove After_Atom_Item_Remove = null;

        private ID m_Atom_WorkPeriod_ID = null;
        DataTable dt_Item = new DataTable();
        private TangentaDB.ShopABC m_InvoiceDB = null;
        private DBTablesAndColumnNames DBtcn = null;
        public NavigationButtons.Navigation nav = null;
        private string m_DocTyp = "";

        private bool m_bAutomaticSelectionOfItemsFromStock = true;
        public bool AutomaticSelectionOfItemsFromStock
        {
            get
            {
                return m_bAutomaticSelectionOfItemsFromStock;
            }

            set
            {
                m_bAutomaticSelectionOfItemsFromStock = value;
            }
        }

        public string DocTyp
        {
            get { return m_DocTyp; }
            set
            {
                string s = value;
                if (s.Equals(GlobalData.const_DocInvoice) || s.Equals(GlobalData.const_DocProformaInvoice))
                {
                    m_DocTyp = s;
                }
                
                if (this.m_usrc_Atom_ItemsList1366x768 != null)
                {
                    this.m_usrc_Atom_ItemsList1366x768.DocTyp = m_DocTyp;
                }
                if (this.m_usrc_ItemList1366x768 != null)
                {
                    this.m_usrc_ItemList1366x768.DocTyp = m_DocTyp;
                }

            }
        }
        public bool IsDocInvoice
        {
            get
            { return DocTyp.Equals(GlobalData.const_DocInvoice); }
        }

        public bool IsDocProformaInvoice
        {
            get
            { return DocTyp.Equals(GlobalData.const_DocProformaInvoice); }
        }


        private bool m_bExclusivelySellFromStock = false;
        public bool ExclusivelySellFromStock
        {
            get { return m_bExclusivelySellFromStock; }
            set { m_bExclusivelySellFromStock = value; }
        }


        //public int NumberOfGroupLevels
        //{
        //    get
        //    {
        //        if (this.usrc_ItemList1366x768 != null)
        //        {
        //           // return usrc_ItemList1366x768.NumberOfGroupLevels;
        //        }
        //        else
        //        {
        //            return 0;
        //        }
        //    }
        //}


        public usrc_ShopC1366x768()
        {
            InitializeComponent();
            //this.btn_Stock.Image = ShopC.Properties.Resources.Edit;
            //this.btn_Items.Image = ShopC.Properties.Resources.Edit;
            //this.Load += new System.EventHandler(this.usrc_ShopC_Load);

        }

        private void usrc_ShopC_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                m_usrc_ItemList1366x768.Init(this.m_usrc_Atom_ItemsList1366x768);
            }
        }

        private ID m_PriceList_ID = null;

        public ID PriceList_ID
        {
            get
            {
              return this.m_PriceList_ID;
            }
            set
            {
                m_PriceList_ID = value;
            }
        }

        public void SetColor()
        {
            //this.BackColor = Colors.ShopC.BackColor;
            //this.ForeColor = Colors.ShopC.ForeColor;
            Reset();
        }

        public void Init(ID xAtom_WorkPeriod_ID,
                        TangentaDB.ShopABC xm_InvoiceDB,
                        DBTablesAndColumnNames xDBtcn,
                        string ShopsInUse,
                        bool bAutomaticSelectionOfItemFromStock,
                        bool bExclusivelySellFromStock)

        {
            m_Atom_WorkPeriod_ID = xAtom_WorkPeriod_ID;
            m_bExclusivelySellFromStock = bExclusivelySellFromStock;
            m_InvoiceDB = xm_InvoiceDB;
            DBtcn = xDBtcn;
            if (DBtcn == null)
            {
                LogFile.Error.Show("ERROR:usrc_ShopC:Init:DBtcn == null!");
                DBtcn = new DBTablesAndColumnNames();
            }

            lng.s_ShopC_Name.Text(lbl_ShopC_Name);
            lbl_ShopC_Name.Visible = true;
            this.m_usrc_Atom_ItemsList1366x768.Init(m_Atom_WorkPeriod_ID,m_usrc_ItemList1366x768, xm_InvoiceDB, xDBtcn);
            this.m_usrc_ItemList1366x768.Init(m_Atom_WorkPeriod_ID,xm_InvoiceDB, xDBtcn, this, m_bExclusivelySellFromStock);

            this.m_usrc_ItemList1366x768.ItemAdded += new usrc_ItemList1366x768.delegate_ItemAdded(usrc_ItemList_ItemAdded);
            this.m_usrc_Atom_ItemsList1366x768.After_Atom_Item_Remove += new usrc_Atom_ItemsList1366x768.delegate_After_Atom_Item_Remove(usrc_Atom_ItemsList_After_Atom_Item_Remove);
            string Err = null;

            SetColor();
        }

        void usrc_Atom_ItemsList_After_Atom_Item_Remove()
        {
            if (After_Atom_Item_Remove != null)
            {
                After_Atom_Item_Remove();
            }
        }

        void usrc_ItemList_ItemAdded()
        {
            if (ItemAdded != null)
            {
                ItemAdded();
            }
        }

        public void SetMode(eMode mode)
        {
            switch (mode)
            {
                case eMode.VIEW:
                    //splitContainer1.Panel2Collapsed = true;
                    break;

                case eMode.EDIT:
                    //splitContainer1.Panel2Collapsed = false;
                    break;
            }

        }

        public bool GetItemData(ref int iCount)
        {
            SQLTable tbl_Item = DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(Item));


            string sql_Item = @"SELECT 
              Item.ID,
              Item.Name AS Item_Name,
              Item.UniqueName AS Item_UniqueName,
              Item_Image.Image_Hash AS Item_Image_Image_Hash,
              Item_Image.Image_Data AS Item_Image_Image_Data,
              Item.Code AS Item_Code,
              Item.ToOffer AS Item_ToOffer,
              Expiry.ExpectedShelfLifeInDays,
              Expiry.SaleBeforeExpiryDateInDays,
              Expiry.DiscardBeforeExpiryDateInDays,
              Expiry.ExpiryDescription,
              Warranty.WarrantyDuration,
              Warranty.WarrantyDurationType,
              Warranty.WarrantyConditions
             From Item 
                LEFT JOIN Item_Image ON Item.Item_Image_ID = Item_Image.ID
                LEFT JOIN Expiry ON Item.Expiry_ID = Expiry.ID
                LEFT JOIN Warranty ON Item.Warranty_ID = Warranty.ID
                where Item.ToOffer = 1
            ";

            string Err = null;
            dt_Item.Clear();
            if (DBSync.DBSync.ReadDataTable(ref dt_Item, sql_Item, ref Err))
            {
                iCount = dt_Item.Rows.Count;
                return true;

            }
            else
            {
                LogFile.Error.Show("Error Load Item data:" + Err);
                return false;
            }
        }


        private void pnl_Items_Paint(object sender, PaintEventArgs e)
        {

        }

        public void Reset()
        {
            //this.usrc_ItemList1366x768.Reset();
        }

        public void Clear()
        {
            this.m_usrc_Atom_ItemsList1366x768.Clear();
        }
        public void SetCurrentInvoice_SelectedItems()
        {
            this.m_usrc_Atom_ItemsList1366x768.SetCurrentInvoice_SelectedItems();
        }

        private void btn_Stock_Click(object sender, EventArgs e)
        {
            if (CheckAccessStock!=null)
            {
                if (!CheckAccessStock())
                {
                    return;
                }
            }

            decimal count_in_baskets = 0;
            if (CountInBaskets(ref count_in_baskets))
            {
                if (count_in_baskets == 0)
                {
                    if (EditStock(nav))
                    {
                        m_usrc_ItemList1366x768.Get_Price_Item_Stock_Data(PriceList_ID);
                        Reset();
                    }
                }
                else
                {
                    XMessage.Box.Show(this, lng.s_YouCanNotEditStockUntilAllBasketsAreEmpty, "", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1);
                }

            }
        }

        internal bool CountInBaskets(ref decimal count_in_baskets)
        {
            string sql = @"select dQuantity 
                            from DocInvoice_ShopC_Item  appis
                            inner join DocInvoice pi on appis.DocInvoice_ID = pi.ID
                            where pi.Draft = 1 and appis.Stock_ID is not null";
            DataTable dt = new DataTable();
            string Err = null;
            if (DBSync.DBSync.ReadDataTable(ref dt,sql,ref Err))
            {
                decimal  d = 0;
                int iCount = dt.Rows.Count;
                for (int i=0;i<iCount;i++)
                {
                    d += (decimal)dt.Rows[i][0];
                }
                count_in_baskets = d;
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:usrc_ItemMan:CountInBaskets:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }

        private bool EditStock(NavigationButtons.Navigation xnav)
        {
            Form_SelectStockEditType frmSelectStockEditType = new Form_SelectStockEditType(m_Atom_WorkPeriod_ID,xnav);
            frmSelectStockEditType.CheckIfAdministrator += FrmSelectStockEditType_CheckIfAdministrator;
            if (frmSelectStockEditType.ShowDialog(this) == DialogResult.OK)
            {
                if (frmSelectStockEditType.eaction == Form_SelectStockEditType.eAction.do_EditStockTakeItems)
                {
                    frmSelectStockEditType.b_edt_Stock_dlg_Changed = frmSelectStockEditType.Do_Form_StockTake_Edit();
                }
                else if (frmSelectStockEditType.eaction == Form_SelectStockEditType.eAction.do_EditItemsInStock)
                {
                    frmSelectStockEditType.b_edt_Stock_dlg_Changed = frmSelectStockEditType.Do_Form_Stock_Edit();
                }

                return frmSelectStockEditType.b_edt_Stock_dlg_Changed;
            }
            else
            {
                return false;
            }
        }

        public bool EditItem(NavigationButtons.Navigation xnav)
        {
            SQLTable tbl_Item = new SQLTable(DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(Item)));
            Form_ShopC_Item_Edit edt_Item_dlg = new Form_ShopC_Item_Edit(DBSync.DBSync.DB_for_Tangenta.m_DBTables,
                                                            tbl_Item,
                                                            "Item_$$Code desc", xnav);
            edt_Item_dlg.ShowDialog(Global.f.GetParentForm(this));

            if (edt_Item_dlg.List_of_Inserted_Items_ID.Count > 0)
            {
                DataTable dt_ShopC_Items_NotIn_PriceList = new DataTable();
                if (f_PriceList.Check_All_ShopC_Items_In_PriceList(ref dt_ShopC_Items_NotIn_PriceList))
                {
                    if (dt_ShopC_Items_NotIn_PriceList.Rows.Count > 0)
                    {
                        if (f_PriceList.Insert_ShopC_Items_in_PriceList(dt_ShopC_Items_NotIn_PriceList, this))
                        {
                            bool bPriceListChanged = false;
                            this.m_usrc_PriceList1.PriceList_Edit(true, ref bPriceListChanged);
                        }
                    }
                    else
                    {
                        bool bEdit = false;
                        f_PriceList.CheckPriceUndefined_ShopC(ref bEdit);
                        if (bEdit)
                        {
                            bool bPriceListChanged = false;
                            this.m_usrc_PriceList1.PriceList_Edit(true, ref bPriceListChanged);
                        }
                    }
                }
            }
            if (edt_Item_dlg.Changed)
            {
                m_usrc_ItemList1366x768.Get_Price_Item_Stock_Data(this.m_usrc_PriceList1.ID);
            }

            return edt_Item_dlg.Changed;
        }

        private bool FrmSelectStockEditType_CheckIfAdministrator()
        {
            if (CheckIfAdministrator!=null)
            {
                return CheckIfAdministrator();
            }
            return true;
        }

        private void usrc_PriceList1_PriceListChanged(ID xPriceList_ID)
        {
            m_usrc_ItemList1366x768.Get_Price_Item_Stock_Data(xPriceList_ID);
        }

        public bool proc_Select_ShopC_Item_from_Stock(string DocTyp,
                                                      DataTable dt_ShopC_Item_in_Stock,
                                                      Atom_DocInvoice_ShopC_Item_Price_Stock_Data xShopC_Data_Item,
                                                      decimal dStockQuantity,
                                                      decimal dFromFactoryQuantity,
                                                      ref decimal dQuantitySelectedFromStock,
                                                      ref bool bOK)
        {
            decimal dQuantityToTakeFromStock = dStockQuantity;
            string UnitSymbol = null;
            string Item_UniqueName = "";
            xShopC_Data_Item.m_ShopShelf_Source.Stock_Data_List = new List<Stock_Data>();
            if (dt_ShopC_Item_in_Stock.Rows.Count > 0)
            {
                if (dt_ShopC_Item_in_Stock.Rows[0]["Item_UniqueName"] is string)
                {
                    Item_UniqueName = (string)dt_ShopC_Item_in_Stock.Rows[0]["Item_UniqueName"];
                }
                this.m_InvoiceDB.m_CurrentDoc.m_Basket.AutomaticSelectItems(dt_ShopC_Item_in_Stock, dStockQuantity, ref dQuantitySelectedFromStock, ref UnitSymbol);
                if (dQuantitySelectedFromStock != dStockQuantity)
                {
                    string smsg = Item_UniqueName + ":" + lng.s_Stock_dQuantity.s + " = " + dQuantitySelectedFromStock.ToString() + " " + UnitSymbol;
                    if (XMessage.Box.Show(this, lng.s_NotEnoughItemsInStock_DoIgnoreStockQuestion, smsg, lng.s_Warning.s, MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        dFromFactoryQuantity += dStockQuantity - dQuantitySelectedFromStock;
                    }
                }
                if (!AutomaticSelectionOfItemsFromStock)
                {
                    Form_Select_Item_From_Stock Select_Item_From_Stock_Dialog = new Form_Select_Item_From_Stock(dt_ShopC_Item_in_Stock, dStockQuantity);
                    bOK = Select_Item_From_Stock_Dialog.ShowDialog() == DialogResult.OK;
                    if (!bOK)
                    {
                        return false;
                    }
                    dQuantitySelectedFromStock = Select_Item_From_Stock_Dialog.dQuantitySelected;


                }


                foreach (DataRow dr in dt_ShopC_Item_in_Stock.Rows)
                {
                    if (dr["TakeFromStock"] is decimal)
                    {
                        //decimal_v xStock_dQuantity = tf.set_decimal(dr["Stock_dQuantity"]);
                        //if (xStock_dQuantity != null)
                        //{
                        //    if (xStock_dQuantity.v==0)
                        //    {
                        //        continue;
                        //    }
                        //}
                        Stock_Data stock_data = new Stock_Data();
                        stock_data.Stock_ID = tf.set_ID(dr["Stock_ID"]);
                        stock_data.Stock_ImportTime = tf.set_DateTime(dr["Stock_ImportTime"]);
                        stock_data.Stock_ExpiryDate = tf.set_DateTime(dr["Stock_Expiry_Date"]);
                        decimal_v dQuantity_v = tf.set_decimal(dr["Stock_dQuantity"]);
                        stock_data.dQuantity = tf.set_decimal(dr["TakeFromStock"]);
                        decimal_v dQuantityTakenFromStock_v = tf.set_decimal(dr["TakeFromStock"]);
                        decimal dNewQuantityInStock = dQuantity_v.v - dQuantityTakenFromStock_v.v;
                        stock_data.dQuantity_New_in_Stock = new decimal_v(dNewQuantityInStock);
                        xShopC_Data_Item.m_ShopShelf_Source.Stock_Data_List.Add(stock_data);
                    }
                }
            }
            else
            {
                Item_UniqueName = xShopC_Data_Item.Atom_Item_UniqueName.v;
            }

            if (dFromFactoryQuantity > 0)
            {
                Stock_Data stock_data = new Stock_Data();
                stock_data.Stock_ID = null;
                stock_data.Stock_ImportTime = null;
                stock_data.dQuantity = new decimal_v(dFromFactoryQuantity);
                stock_data.dQuantity_New_in_Stock = null;
                DateTime dtNow = DateTime.Now;
                DateTime dtExpiry = new DateTime(dtNow.Year, dtNow.Month, dtNow.Day);
                dtExpiry = dtExpiry.AddMonths(1);
                DateTime_v ExpiryDate_v = new DateTime_v(dtExpiry);
                stock_data.Stock_ExpiryDate = ExpiryDate_v;
                Form_Stock_AvoidStock_Edit edt_Stock_AvoidStock_dlg = new Form_Stock_AvoidStock_Edit(ExpiryDate_v, Item_UniqueName);
                if (edt_Stock_AvoidStock_dlg.ShowDialog() == DialogResult.OK)
                {
                    stock_data.Stock_ExpiryDate = DateTime_v.Copy(edt_Stock_AvoidStock_dlg.ExpiryDate);
                    xShopC_Data_Item.m_ShopShelf_Source.Stock_Data_List.Add(stock_data);
                }
            }
            if (xShopC_Data_Item.m_ShopShelf_Source.dQuantity_from_stock > 0)
            {
                if (!this.m_InvoiceDB.m_CurrentDoc.Insert_DocInvoice_Atom_Price_Items_Stock(m_Atom_WorkPeriod_ID,DocTyp, ref xShopC_Data_Item, true))
                {
                    return false;
                }
            }
            if (xShopC_Data_Item.m_ShopShelf_Source.dQuantity_from_factory > 0)
            {
                if (!this.m_InvoiceDB.m_CurrentDoc.Insert_DocInvoice_Atom_Price_Items_Stock(m_Atom_WorkPeriod_ID,DocTyp, ref xShopC_Data_Item, false))
                {
                    return false;
                }
            }
            return true;
        }

        public void proc_Item_Not_In_Offer(ShopC_Item shopC_Item)
        {
            string s = "\r\n " + lng.s_Item.s + ":" + shopC_Item.UniqueName_v.v;
            XMessage.Box.Show(this, lng.s_Item_Not_In_Offer, s, lng.s_Warning.s, MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
        }

        //private bool usrc_PriceList1_CheckAccess()
        //{

        //}
        private void usrc_PriceList1_PriceListChanged()
        {

        }

    }
}
