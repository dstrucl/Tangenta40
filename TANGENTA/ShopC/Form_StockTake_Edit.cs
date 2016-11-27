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
using TangentaDB;
using DBTypes;

namespace ShopC
{
    public partial class Form_StockTake_Edit : Form
    {
        CodeTables.DBTableControl dbTables = null;
        internal bool Changed;

        private Navigation nav;

        public Form_StockTake_Edit(Navigation xnav, CodeTables.DBTableControl xdbTables)
        {
            InitializeComponent();
            this.nav = xnav;
            dbTables = xdbTables;
            this.Text = lngRPM.s_EditStockTakeItems.s;
            usrc_EditTable1.Text(lngRPM.s_EditStockTake);
        }

        private void Form_StockTake_Edit_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            SQLTable tbl_StockTake = new SQLTable(DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(StockTake)));
            //SQLTable tbl_Item = new SQLTable(DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(Item)));
            string ColumnToOrderBy = "StockTake_$$StockTake_Date desc";
            string selection = @"StockTake_$$StockTake_Date,
                                 StockTake_$$Description,
                                 StockTake_$$StockTakePriceTotal,
                                 StockTake_$_sup_$_c_$_orgd_$_org_$$Name,
                                 StockTake_$_sup_$_c_$_orgd_$_org_$$Tax_ID,
                                 StockTake_$_trc_$_c_$_orgd_$_org_$$Name,
                                 StockTake_$_ref_$$ReferenceNote,
                                 StockTake_$_trc_$$TruckingCost,
                                 StockTake_$_trc_$$Customs,
                                 ID";
            this.Cursor = Cursors.WaitCursor;
            if (usrc_EditTable1.Init(dbTables, tbl_StockTake, selection, ColumnToOrderBy, false, null, null, false, nav))
            {
                usrc_EditTable1.after_InsertInDataBase += Usrc_EditTable1_after_InsertInDataBase;
                usrc_StockEditForSelectedStockTake1.StockTake_ID = usrc_EditTable1.Identity;
                Show_StockTakeItems();
            }
            else
            {
                Close();
                DialogResult = DialogResult.Abort;
            }
            this.Cursor = Cursors.Arrow;
        }

        private void Usrc_EditTable1_after_InsertInDataBase(SQLTable m_tbl, long ID, bool bRes)
        {
            if (bRes)
            {
                long_v JOURNAL_StockTake_ID_v = null;
                if (TangentaDB.f_JOURNAL_StockTake.Get(ID, f_JOURNAL_StockTake.JOURNAL_StockTake_Type_ID_New_StockTake_opened, DateTime.Now, ref JOURNAL_StockTake_ID_v))
                {

                }
            }
        }

        private void Show_StockTakeItems()
        {
        }

        private void lbl_PurchasePrice_Click(object sender, EventArgs e)
        {

        }

        private void usrc_EditTable1_Load(object sender, EventArgs e)
        {

        }

        private void usrc_EditTable1_Load_1(object sender, EventArgs e)
        {

        }

        private void btn_SelectItem_Click(object sender, EventArgs e)
        {
            //Form_ShopC_Item_Edit
        }

        private void Form_StockTake_Edit_FormClosed(object sender, FormClosedEventArgs e)
        {
            usrc_StockEditForSelectedStockTake1.DoClose();
        }
    }
}
