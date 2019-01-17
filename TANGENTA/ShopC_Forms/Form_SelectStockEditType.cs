using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NavigationButtons;
using CodeTables;
using TangentaTableClass;
using LanguageControl;
using DBConnectionControl40;

namespace ShopC_Forms
{
    public partial class Form_SelectStockEditType : Form
    {
        public delegate bool delegate_CheckIfAdministrator();
        public event delegate_CheckIfAdministrator CheckIfAdministrator = null ;

        public enum eAction { none, do_EditItemsInStock, do_EditStockTakeItems };
        public eAction eaction = Form_SelectStockEditType.eAction.none;
        private Navigation nav = null;
        public bool b_edt_Stock_dlg_Changed = false;
        private ID m_Atom_WorkPeriod_ID = null;

        public Form_SelectStockEditType(ID xAtom_WorkPeriod_ID,Navigation xnav)
        {
            InitializeComponent();
            m_Atom_WorkPeriod_ID = xAtom_WorkPeriod_ID;
            this.nav = xnav;
            lng.s_btn_EditItemsInStock.Text(btn_EditItemsInStock);
            lng.s_EditStockTakeItems.Text(btn_EditStockTakeItems);
            this.Text = lng.s_Select_StockEdit_Type.s;
        }

        public bool Do_Form_Stock_Edit()
        {
            SQLTable tbl_Stock = new SQLTable(DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(Stock)));
            //SQLTable tbl_Item = new SQLTable(DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(Item)));
            Form_Stock_Edit edt_Stock_dlg = new Form_Stock_Edit(m_Atom_WorkPeriod_ID,DBSync.DBSync.DB_for_Tangenta.m_DBTables,
                                                              tbl_Stock,
                                                              "Stock_$_ppi_$_i_$$Code asc", nav);
            edt_Stock_dlg.ShowDialog();
            return edt_Stock_dlg.Changed;

        }

        public bool Do_Form_StockTake_Edit()
        {
            Form_StockTake_Edit edt_StockTake_dlg = new Form_StockTake_Edit(nav, DBSync.DBSync.DB_for_Tangenta.m_DBTables, m_Atom_WorkPeriod_ID);
            edt_StockTake_dlg.ShowDialog();
            return edt_StockTake_dlg.Changed;
        }


        private void btn_EditItemsInStock_Click(object sender, EventArgs e)
        {
            this.Close();
            DialogResult = DialogResult.OK;
            eaction = eAction.do_EditItemsInStock;
            
        }

        private void btn_EditStockTakeItems_Click(object sender, EventArgs e)
        {
            this.Close();
            DialogResult = DialogResult.OK;
            eaction = eAction.do_EditStockTakeItems;
            
        }

     
        private void Form_SelectStockEditType_Load(object sender, EventArgs e)
        {
            if (CheckIfAdministrator!=null)
            {
                if (!CheckIfAdministrator())
                {
                    this.Close();
                    DialogResult = DialogResult.OK;
                    eaction = eAction.do_EditStockTakeItems;
                }
            }
        }

        private void btn_Inventura_Click(object sender, EventArgs e)
        {
            Form_ViewStock frm_inventura = new Form_ViewStock();
            frm_inventura.ShowDialog(this);

        }

        private void btn_PurchasePricesPerItem_Click(object sender, EventArgs e)
        {
            Form_View_PurchasePricesPerItem frm_PurchasePricesPerItem = new Form_View_PurchasePricesPerItem();
            frm_PurchasePricesPerItem.ShowDialog(this);
        }
    }
}