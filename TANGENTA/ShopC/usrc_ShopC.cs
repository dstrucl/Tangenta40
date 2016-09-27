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
using System.Windows.Forms;
using TangentaTableClass;
using CodeTables;
using LanguageControl;
using TangentaDB;
using PriseLists;
using DBTypes;

namespace ShopC
{
    public partial class usrc_ShopC : UserControl
    {
        public enum eMode { VIEW, EDIT };


        public delegate void delegate_ItemAdded();
        public event delegate_ItemAdded ItemAdded = null;

        public delegate void delegate_After_Atom_Item_Remove();
        public event delegate_After_Atom_Item_Remove After_Atom_Item_Remove = null;

        public delegate void delegate_PriceListChanged();
        public event delegate_PriceListChanged PriceListChanged = null;
        

        DataTable dt_Item = new DataTable();
        private TangentaDB.ShopABC m_InvoiceDB = null;
        private DBTablesAndColumnNames DBtcn = null;
        public NavigationButtons.Navigation nav = null;
       // private usrc_Invoice m_usrc_Invoice = null;
        public usrc_ShopC()
        {
            InitializeComponent();
            lngRPM.s_lbl_Stock.Text(lbl_Stock);
            lngRPM.s_lbl_Items.Text(lbl_Items);
            usrc_ItemList.Init(this.usrc_Atom_ItemsList);
        }

        public long PriceList_ID
        {
            get { return this.usrc_PriceList1.ID; }
        }


        public void Init(TangentaDB.ShopABC xm_InvoiceDB, DBTablesAndColumnNames xDBtcn, string ShopsInUse, NavigationButtons.Navigation xnav)
        {
            //Program.iGDIcUser502 = Program.getGuiResourcesUserCount();

            //m_usrc_Invoice = x_usrc_Invoice;
            m_InvoiceDB = xm_InvoiceDB;

            DBtcn = xDBtcn;
            if (DBtcn == null)
            {
                LogFile.Error.Show("ERROR:usrc_ShopC:Init:DBtcn == null!");
                DBtcn = new DBTablesAndColumnNames();
            }

            lngRPM.s_Shop_C.Text(lbl_ShopC_Name);

            this.usrc_Atom_ItemsList.Init(usrc_ItemList, xm_InvoiceDB, xDBtcn);
            this.usrc_ItemList.Init(xm_InvoiceDB, xDBtcn,this);

            this.usrc_ItemList.ItemAdded += new usrc_ItemList.delegate_ItemAdded(usrc_ItemList_ItemAdded);
            this.usrc_Atom_ItemsList.After_Atom_Item_Remove += new usrc_Atom_ItemsList.delegate_After_Atom_Item_Remove(usrc_Atom_ItemsList_After_Atom_Item_Remove);
            string Err = null;
            
             this.usrc_PriceList1.Init(GlobalData.BaseCurrency.ID, usrc_PriceList_Edit.eShopType.ShopC,ShopsInUse,xnav,  ref Err);
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
                    splitContainer3.Panel2Collapsed = true;
                    break;

                case eMode.EDIT:
                    splitContainer3.Panel2Collapsed = false;
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
            this.usrc_ItemList.Reset();
        }

        public void Clear()
        {
            this.usrc_Atom_ItemsList.Clear();
        }
        public void SetCurrentInvoice_SelectedItems()
        {
            this.usrc_Atom_ItemsList.SetCurrentInvoice_SelectedItems();
        }

        private void btn_Stock_Click(object sender, EventArgs e)
        {
            decimal count_in_baskets = 0;
            if (CountInBaskets(ref count_in_baskets))
            {
                if (count_in_baskets == 0)
                {
                    if (EditStock(nav))
                    {
                        usrc_ItemList.Get_Price_Item_Stock_Data(PriceList_ID);
                    }
                }
                else
                {
                    XMessage.Box.Show(this, lngRPM.s_YouCanNotEditStockUntilAllBasketsAreEmpty, "", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1);
                }

            }
            //Init(m_InvoiceDB, DBtcn, m_usrc_Invoice);
            //this.usrc_ItemList.Get_Price_Item_Data(PriceList_ID);
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
            SQLTable tbl_Stock = new SQLTable(DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(Stock)));
            SQLTable tbl_Item = new SQLTable(DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(Item)));
            Form_Stock_Edit edt_Stock_dlg = new Form_Stock_Edit(DBSync.DBSync.DB_for_Tangenta.m_DBTables,
                                                              tbl_Stock,
                                                              "Stock_$_ppi_$_i_$$Code asc",xnav);
            edt_Stock_dlg.ShowDialog();
            return edt_Stock_dlg.Changed;
        }

        private void btn_Items_Click(object sender, EventArgs e)
        {
            decimal count_in_baskets = 0;
            if (CountInBaskets(ref count_in_baskets))
            {
                if (count_in_baskets == 0)
                {
                    NavigationButtons.Navigation nav_EditItem = new NavigationButtons.Navigation();
                    nav_EditItem.bDoModal = true;
                    nav_EditItem.m_eButtons = NavigationButtons.Navigation.eButtons.OkCancel;
                    if (EditItem(nav_EditItem))
                    {
                        usrc_ItemList.Get_Price_Item_Stock_Data(PriceList_ID);
                    }
                }
                else
                {
                    XMessage.Box.Show(this, lngRPM.s_YouCanNotEditItemsUntilAllBasketsAreEmpty, "", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1);
                }

            }

            
        }

        public bool EditItem(NavigationButtons.Navigation xnav)
        {
            SQLTable tbl_Item = new SQLTable(DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(Item)));
            Form_ShopC_Item_Edit edt_Item_dlg = new Form_ShopC_Item_Edit(DBSync.DBSync.DB_for_Tangenta.m_DBTables,
                                                            tbl_Item,
                                                            "Item_$$Code desc",xnav);
            edt_Item_dlg.ShowDialog();

            if (edt_Item_dlg.List_of_Inserted_Items_ID.Count>0)
            {
                DataTable dt_ShopC_Items_NotIn_PriceList = new DataTable();
                if (f_PriceList.Check_All_ShopC_Items_In_PriceList(ref dt_ShopC_Items_NotIn_PriceList))
                {
                    NavigationButtons.Navigation nav_PriceList_Edit = new NavigationButtons.Navigation();
                    nav_PriceList_Edit.m_eButtons = NavigationButtons.Navigation.eButtons.OkCancel;
                    if (dt_ShopC_Items_NotIn_PriceList.Rows.Count > 0)
                    {
                        if (f_PriceList.Insert_ShopC_Items_in_PriceList(dt_ShopC_Items_NotIn_PriceList, this))
                        {
                            this.usrc_PriceList1.PriceList_Edit(true, nav_PriceList_Edit);
                            if (PriceListChanged != null)
                            {
                                PriceListChanged();
                            }
                        }
                    }
                    else
                    {
                        bool bEdit = false;
                        f_PriceList.CheckPriceUndefined_ShopC(ref bEdit);
                        if (bEdit)
                        {
                            this.usrc_PriceList1.PriceList_Edit(true, nav_PriceList_Edit);
                        }
                    }
                }
            }
            if (edt_Item_dlg.Changed)
            {
                usrc_ItemList.Get_Price_Item_Stock_Data(this.usrc_PriceList1.ID);
            }

            return edt_Item_dlg.Changed;
        }



    }
}
