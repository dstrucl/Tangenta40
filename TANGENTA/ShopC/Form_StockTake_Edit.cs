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
        public string StockTakeName = null;
        private int StockTake_Draft_column_index = -1;

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
            string ColumnToOrderBy = "StockTake_$$Draft desc, StockTake_$$StockTake_Date desc";
            string selection = @"StockTake_$$Name,
                                 StockTake_$$StockTake_Date,
                                 StockTake_$$Description,
                                 StockTake_$$StockTakePriceTotal,
                                 StockTake_$_sup_$_c_$_orgd_$_org_$$Name,
                                 StockTake_$_sup_$_c_$_orgd_$_org_$$Tax_ID,
                                 StockTake_$_trc_$_c_$_orgd_$_org_$$Name,
                                 StockTake_$_ref_$$ReferenceNote,
                                 StockTake_$_trc_$$TruckingCost,
                                 StockTake_$_trc_$$Customs,
                                 StockTake_$$Draft,
                                 ID";
            this.Cursor = Cursors.WaitCursor;
            if (usrc_EditTable1.Init(dbTables, tbl_StockTake, selection, ColumnToOrderBy, false, null, null, false, nav))
            {
                usrc_EditTable1.after_InsertInDataBase += Usrc_EditTable1_after_InsertInDataBase;
                if (fs.IDisValid(usrc_EditTable1.Identity))
                {
                    splitContainer1.Panel2Collapsed = false;
                }
                else
                {
                    splitContainer1.Panel2Collapsed = true;
                }

                object oVal = usrc_EditTable1.tbl.Value("StockTake_$$Name");
                if (oVal is TangentaTableClass.Name)
                {
                    if (((TangentaTableClass.Name)oVal).defined)
                    {
                        StockTakeName = ((TangentaTableClass.Name)oVal).val;
                        usrc_StockEditForSelectedStockTake1.StockTakeName = StockTakeName;
                        usrc_StockEditForSelectedStockTake1.StockTakeTable = usrc_EditTable1.tbl;
                    }
                }
                //Show_StockTakeItems(usrc_EditTable1.Identity);
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
                splitContainer1.Panel2Collapsed = false;
                object oValue = m_tbl.Value("StockTake_$$Name");
                if (oValue is TangentaTableClass.Name)
                {
                    if (((TangentaTableClass.Name)oValue).defined)
                    {
                        StockTakeName = ((TangentaTableClass.Name)oValue).val;
                        usrc_StockEditForSelectedStockTake1.StockTakeName = StockTakeName;
                        usrc_StockEditForSelectedStockTake1.StockTakeTable = m_tbl;
                    }
                }


                if (TangentaDB.f_JOURNAL_StockTake.Get(ID, f_JOURNAL_StockTake.JOURNAL_StockTake_Type_ID_New_StockTake_opened, DateTime.Now, ref JOURNAL_StockTake_ID_v))
                {

                }
            }
        }

        private void Show_StockTakeItems(long ID,string StockTakeName)
        {
            if (ID >= 0)
            {
                splitContainer1.Panel2Collapsed = false;
                usrc_StockEditForSelectedStockTake1.ShowStock_For_StockTakeID(ID, StockTakeName);
            }
            else
            {
                splitContainer1.Panel2Collapsed = true;
            }
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

        private void usrc_EditTable1_SelectedIndexChanged(SQLTable m_tbl, long ID, int index)
        {
            object oValue = m_tbl.Value("StockTake_$$Name");
            if (oValue is TangentaTableClass.Name)
            {
                if (((TangentaTableClass.Name)oValue).defined)
                {
                    StockTakeName = ((TangentaTableClass.Name)oValue).val;
                    usrc_StockEditForSelectedStockTake1.StockTakeTable = m_tbl;
                }
            }
            Show_StockTakeItems(ID, StockTakeName);
        }

        private void usrc_StockEditForSelectedStockTake1_BtnExitPressed()
        {
            this.Close();
            DialogResult = DialogResult.OK;
        }

        private void usrc_EditTable1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (StockTake_Draft_column_index <0)
            {
                StockTake_Draft_column_index = ((DataGridView_2xls.DataGridView2xls)sender).Columns["StockTake_$$Draft"].Index;
            }
            if (((DataGridView_2xls.DataGridView2xls)sender).DataSource is DataTable)
            {
                if (e.RowIndex >= 0)
                {
                    if ((bool)((DataTable)((DataGridView_2xls.DataGridView2xls)sender).DataSource).Rows[e.RowIndex][StockTake_Draft_column_index])
                    {
                        e.CellStyle.BackColor = Color.White;
                    }
                    else
                    {
                        e.CellStyle.BackColor = Color.LightGreen;
                    }
                }
            }
        }
    }
}
