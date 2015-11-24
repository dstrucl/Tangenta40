using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BlagajnaTableClass;
using SQLTableControl;
using LanguageControl;

namespace Tangenta
{
    public partial class usrc_ItemMan : UserControl
    {
        public delegate void delegate_ItemAdded();
        public event delegate_ItemAdded ItemAdded = null;

        public delegate void delegate_After_Atom_Item_Remove();
        public event delegate_After_Atom_Item_Remove After_Atom_Item_Remove = null;

        public delegate void delegate_PriceListChanged();
        public event delegate_PriceListChanged PriceListChanged = null;
        

        DataTable dt_Item = new DataTable();
        private InvoiceDB m_InvoiceDB = null;
        private DBTablesAndColumnNames DBtcn = null;
        private usrc_Invoice m_usrc_Invoice = null;
        public usrc_ItemMan()
        {
            InitializeComponent();
            lngRPM.s_lbl_StoreA_SelectetItems.Text(lbl_StoreA_SelectetItems);
            lngRPM.s_lbl_Stock.Text(lbl_Stock);
            lngRPM.s_lbl_Items.Text(lbl_Items);
            usrc_ItemList.Init(this.usrc_Atom_ItemsList);
        }


        

        public long PriceList_ID
        {
            get
            {
                if (m_usrc_Invoice != null)
                {
                    return m_usrc_Invoice.PriceList_ID;
                }
                else
                {
                    if (DesignMode)
                    {
                        return -1;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:usrc_ItemMan: public long PriceList_ID:usrc_Invoice == null!");
                        return -1;
                    }
                }
            }
        }

        internal void Init(InvoiceDB xm_InvoiceDB, DBTablesAndColumnNames xDBtcn, usrc_Invoice x_usrc_Invoice)
        {
            //Program.iGDIcUser502 = Program.getGuiResourcesUserCount();

            m_usrc_Invoice = x_usrc_Invoice;
            m_InvoiceDB = xm_InvoiceDB;
            DBtcn = xDBtcn;

            this.usrc_Atom_ItemsList.Init(usrc_ItemList, xm_InvoiceDB, xDBtcn);
            this.usrc_ItemList.Init(xm_InvoiceDB, xDBtcn,this);

            this.usrc_ItemList.ItemAdded += new usrc_ItemList.delegate_ItemAdded(usrc_ItemList_ItemAdded);
            this.usrc_Atom_ItemsList.After_Atom_Item_Remove += new usrc_Atom_ItemsList.delegate_After_Atom_Item_Remove(usrc_Atom_ItemsList_After_Atom_Item_Remove);
            

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

        internal void SetMode(usrc_Invoice.emode mode)
        {
            switch (mode)
            {
                case usrc_Invoice.emode.view_eInvoiceType:
                    splitContainer3.Panel2Collapsed = true;
                    break;

                case usrc_Invoice.emode.edit_eInvoiceType:
                    splitContainer3.Panel2Collapsed = false;
                    break;
            }

        }

        internal bool GetItemData(ref int iCount)
        {
            SQLTable tbl_Item = DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(Item));


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

        internal void Reset()
        {
            this.usrc_ItemList.Reset();
        }

        internal void Clear()
        {
            this.usrc_Atom_ItemsList.Clear();
        }
        internal void SetCurrentInvoice_SelectedItems()
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
                    if (EditStock())
                    {
                        usrc_ItemList.Get_Price_Item_Stock_Data(this.m_usrc_Invoice.usrc_PriceList.ID);
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
                            from Atom_ProformaInvoice_Price_Item_Stock  appis
                            inner join ProformaInvoice pi on appis.ProformaInvoice_ID = pi.ID
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

        private bool EditStock()
        {
            SQLTable tbl_Stock = new SQLTable(DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(Stock)));
            SQLTable tbl_Item = new SQLTable(DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(Item)));
            Form_Stock_Edit edt_Stock_dlg = new Form_Stock_Edit(DBSync.DBSync.DB_for_Blagajna.m_DBTables,
                                                              tbl_Stock,
                                                              "Stock_$_ppi_$_i_$$Code asc");
            edt_Stock_dlg.ShowDialog();
            return edt_Stock_dlg.Changed;
        }

        private void btn_Items_Click(object sender, EventArgs e)
        {
            EditItem();
        }

        internal bool EditItem()
        {
            SQLTable tbl_Item = new SQLTable(DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(Item)));
            Form_Item_Edit edt_Item_dlg = new Form_Item_Edit(DBSync.DBSync.DB_for_Blagajna.m_DBTables,
                                                            tbl_Item,
                                                            "Item_$$Code desc");
            edt_Item_dlg.ShowDialog();

            if (edt_Item_dlg.Changed)
            {
                usrc_ItemList.Get_Price_Item_Stock_Data(this.m_usrc_Invoice.usrc_PriceList.ID);
            }

            if (edt_Item_dlg.bPriceListChanged)
            {
                if (PriceListChanged!=null)
                {
                    PriceListChanged();
                }
            }

            return true;
        }



    }
}
