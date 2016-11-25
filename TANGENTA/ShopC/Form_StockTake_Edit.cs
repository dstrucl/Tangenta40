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
        }

        private void Form_StockTake_Edit_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            SQLTable tbl_Stock_Take = new SQLTable(DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(Stock_Take)));
            //SQLTable tbl_Item = new SQLTable(DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(Item)));
            string ColumnToOrderBy = "Stock_Take_$$Stock_Take_Date desc";
            string selection = @"Stock_Take_$$Stock_Take_Date,
                                 Stock_Take_$$Description,
                                 Stock_Take_$$StockTakePriceTotal,
                                 Stock_Take_$_sup_$_c_$_orgd_$_org_$$Name,
                                 Stock_Take_$_sup_$_c_$_orgd_$_org_$$Tax_ID,
                                 Stock_Take_$_trc_$_c_$_orgd_$_org_$$Name,
                                 Stock_Take_$_ref_$$ReferenceNote,
                                 Stock_Take_$_trc_$$TruckingCost,
                                 Stock_Take_$_trc_$$Customs,
                                 ID";
            this.Cursor = Cursors.WaitCursor;
            if (!usrc_EditTable1.Init(dbTables, tbl_Stock_Take, selection, ColumnToOrderBy, false, null, null, false, nav))
            {
                Close();
                DialogResult = DialogResult.Abort;
            }
            usrc_EditTable1.Text(lngRPM.s_EditStockTake);
            this.Cursor = Cursors.Arrow;
        }

        private void lbl_PurchasePrice_Click(object sender, EventArgs e)
        {

        }
    }
}
