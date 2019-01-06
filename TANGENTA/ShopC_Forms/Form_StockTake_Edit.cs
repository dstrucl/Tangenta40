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
using HUDCMS;
using DBConnectionControl40;

namespace ShopC_Forms
{
    public partial class Form_StockTake_Edit : Form
    {
        private HUDCMS.HelpWizzardTagDC tagDCTop = null;
        private HUDCMS.HelpWizzardTagDC tagDC_StockTakeEmpty_true = null;
        private HUDCMS.HelpWizzardTagDC tagDC_StockTakeEmpty_false = null;
        private HUDCMS.HelpWizzardTagDC tagDCBottom = null;

        internal HUDCMS.HelpWizzardTagDC[] TagDCs = null;

        private Form_StockTake_Edit_WizzardForHelp frm_StockTake_Edit_WizzardForHelp = null;

        private ID m_Atom_WorkPeriod_ID = null;

        CodeTables.DBTableControl dbTables = null;

        private bool m_Changed = false;
        internal bool Changed
        {
            get { return m_Changed; }
        }


        private int StockTake_Draft_column_index = -1;

        private Navigation nav;

        private SQLTable m_StockTakeTable = null;


        internal SQLTable StockTakeTable
        {
            get { return m_StockTakeTable;
                }
            set
            {
                m_StockTakeTable = value;
                usrc_StockEditForSelectedStockTake1.StockTakeTable = m_StockTakeTable;
            }
        }


        public decimal StockTakePriceTotal
        { 
            get
            {
                object oTotalPriceValue = m_StockTakeTable.Value("StockTake_$$StockTakePriceTotal");
                if (oTotalPriceValue is TangentaTableClass.StockTakePriceTotal)
                {
                    if (((TangentaTableClass.StockTakePriceTotal)oTotalPriceValue).defined)
                    {
                        return ((TangentaTableClass.StockTakePriceTotal)oTotalPriceValue).val;
                    }
                }
                return 0;
            }
        }

        public string StockTakeName
        {
            get {
                    if (m_StockTakeTable != null)
                    {
                        object oValue = m_StockTakeTable.Value("StockTake_$$Name");
                        if (oValue is TangentaTableClass.Name)
                        {
                            if (((TangentaTableClass.Name)oValue).defined)
                            {
                                return ((TangentaTableClass.Name)oValue).val;
                            }
                        }
                    }
                    return null;
               }
        }

        public ID StockTake_ID
        {
            get {
                    if (m_StockTakeTable!=null)
                    {
                        object oValue = m_StockTakeTable.Value("ID");
                        if (oValue != null)
                        {
                                return tf.set_ID(oValue);
                        }
                    }
                    return null;
                }
        }


        public Form_StockTake_Edit(Navigation xnav, CodeTables.DBTableControl xdbTables,ID xAtom_WorkPeriod_ID)
        {
            InitializeComponent();
            m_Atom_WorkPeriod_ID = xAtom_WorkPeriod_ID;
            this.nav = xnav;
            dbTables = xdbTables;
            this.Text = lng.s_EditStockTakeItems.s;
            usrc_EditTable1.Text(lng.s_EditStockTake);
            usrc_StockEditForSelectedStockTake1.Init(this, m_Atom_WorkPeriod_ID);
        }


        private void Form_StockTake_Edit_Load(object sender, EventArgs e)
        {
        if (!Init())
            {
                DialogResult = DialogResult.Abort;
                Close();
            }
            SetNewFormTag();
        }

        internal bool Init()
        {
            this.Cursor = Cursors.WaitCursor;
            SQLTable tbl_StockTake = new SQLTable(DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(StockTake)));
            string ColumnToOrderBy = "StockTake_$$Draft desc, StockTake_$$StockTake_Date desc";
            string selection = @"ID,
                                 StockTake_$$Name,
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
            if (usrc_EditTable1.Init(dbTables, DBSync.DBSync.MyTransactionLog_delegates, tbl_StockTake, selection, ColumnToOrderBy, false, null, null, false, nav))
            {
                usrc_EditTable1.after_InsertInDataBase += Usrc_EditTable1_after_InsertInDataBase;
                if (ID.Validate(usrc_EditTable1.Identity))
                {
                    splitContainer1.Panel2Collapsed = false;
                }
                else
                {
                    splitContainer1.Panel2Collapsed = true;
                }

                StockTakeTable = usrc_EditTable1.tbl;
                Show_StockTakeItems();
            }
            else
            {
                this.Cursor = Cursors.Arrow;
                return false;
            }
            this.Cursor = Cursors.Arrow;
            return true;
        }

        private void Usrc_EditTable1_after_InsertInDataBase(SQLTable m_tbl, ID ID, bool bRes)
        {
            if (bRes)
            {
                ID JOURNAL_StockTake_ID = null;
                splitContainer1.Panel2Collapsed = false;
                Transaction transaction_Form_StockTake_Edit_Usrc_EditTable1_after_InsertInDataBase_f_JOURNAL_StockTake_Get = DBSync.DBSync.NewTransaction("Form_StockTake_Edit.Usrc_EditTable1_after_InsertInDataBase.f_JOURNAL_StockTake.Get");
                if (TangentaDB.f_JOURNAL_StockTake.Get(m_Atom_WorkPeriod_ID,
                                                      ID,
                                                      f_JOURNAL_StockTake.JOURNAL_StockTake_Type_ID_New_StockTake_opened,
                                                      DateTime.Now,
                                                      ref JOURNAL_StockTake_ID,
                                                      transaction_Form_StockTake_Edit_Usrc_EditTable1_after_InsertInDataBase_f_JOURNAL_StockTake_Get))
                {
                    if (transaction_Form_StockTake_Edit_Usrc_EditTable1_after_InsertInDataBase_f_JOURNAL_StockTake_Get.Commit())
                    {
                        StockTakeTable = m_tbl;
                        Show_StockTakeItems(m_tbl);
                    }
                }
                else
                {
                    transaction_Form_StockTake_Edit_Usrc_EditTable1_after_InsertInDataBase_f_JOURNAL_StockTake_Get.Rollback();
                }
            }
        }

        private void Show_StockTakeItems(SQLTable m_tbl)
        {
            if (ID.Validate(StockTake_ID))
            {
                splitContainer1.Panel2Collapsed = false;
                usrc_StockEditForSelectedStockTake1.Reload(m_tbl);
            }
            else
            {
                splitContainer1.Panel2Collapsed = true;
            }
        }


        private void Show_StockTakeItems()
        {
            if (ID.Validate(StockTake_ID))
            {
                splitContainer1.Panel2Collapsed = false;
                usrc_StockEditForSelectedStockTake1.Reload(StockTakeTable);
            }
            else
            {
                splitContainer1.Panel2Collapsed = true;
            }
        }


        private void Form_StockTake_Edit_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (usrc_EditTable1.Changed)
            {
                m_Changed = true;
            }
            if (usrc_StockEditForSelectedStockTake1.Changed)
            {
                m_Changed = true;
            }
            if (this.usrc_StockEditForSelectedStockTake1.Changed)
            {
                m_Changed = true;
            }
            usrc_StockEditForSelectedStockTake1.DoClose();
        }

        private void usrc_EditTable1_SelectedIndexChanged(SQLTable m_tbl, ID ID, int index)
        {
            StockTakeTable = m_tbl;
            Show_StockTakeItems();
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

        private void SetNewFormTag()
        {

            tagDCTop = new HelpWizzardTagDC( "Top", "", null, null);


            tagDC_StockTakeEmpty_true = new HelpWizzardTagDC( "StockTakeEmpty", "", "bool", "true");
            tagDC_StockTakeEmpty_false = new HelpWizzardTagDC("StockTakeEmpty", "", "bool", "false");


            tagDCBottom = new HelpWizzardTagDC("Bottom", "", null, null);


            TagDCs = new HUDCMS.HelpWizzardTagDC[] {
            tagDCTop,
            tagDC_StockTakeEmpty_true,
            tagDC_StockTakeEmpty_false,
            tagDCBottom
            };

            HUDCMS.HelpWizzardTag hlpwizTag = new HelpWizzardTag(TagDCs, null, null);
            hlpwizTag.DefaultControlWidth = this.Width;
            hlpwizTag.DefaultControlHeight = this.Height;



            long numberOfAll = -1;
            string[] sTagConditions = null;

            string sxmlfilesuffix = "";
            string sNewTag = GetStringTag(ref numberOfAll, ref sTagConditions, ref sxmlfilesuffix);

            hlpwizTag.FileSuffix = sNewTag;
            hlpwizTag.XmlFileSuffix = sxmlfilesuffix;
            hlpwizTag.ShowWizzard = HelpWizzardShow;

            this.Tag = hlpwizTag;
        }

        internal string GetStringTag(ref long numberOfAll, ref string[] sTagConditions, ref string sXMLFiletag)
        {
            string sNewTag = "_";
            sXMLFiletag = "_";
            List<string> tag_conditions = new List<string>();
            if (this.splitContainer1.Panel2Collapsed)
            {
                sNewTag += "ET";
                sXMLFiletag += "ET";
                tag_conditions.Add(tagDC_StockTakeEmpty_true.NamedCondition);
            }
            else 
            {
                numberOfAll = fs.NumberOfProformaInvoicesInDatabase();
                sNewTag += "EF";
                sXMLFiletag += "EF";
                tag_conditions.Add(tagDC_StockTakeEmpty_false.NamedCondition);
            }

            int iconditions_count = tag_conditions.Count;
            sTagConditions = new string[iconditions_count];
            for (int i = 0; i < iconditions_count; i++)
            {
                sTagConditions[i] = tag_conditions[i];
            }
            return sNewTag;
        }

        public void HelpWizzardShow(Control ctrl, HUDCMS.MyControl root_ctrl,string xheader, string xstyleFile)
        {
            if (frm_StockTake_Edit_WizzardForHelp != null)
            {
                if (frm_StockTake_Edit_WizzardForHelp.IsDisposed)
                {
                    frm_StockTake_Edit_WizzardForHelp = null;
                }

            }
            if (frm_StockTake_Edit_WizzardForHelp == null)
            {
                frm_StockTake_Edit_WizzardForHelp = new Form_StockTake_Edit_WizzardForHelp(ctrl, root_ctrl, xheader, xstyleFile);
                frm_StockTake_Edit_WizzardForHelp.Owner = this;
            }
            frm_StockTake_Edit_WizzardForHelp.Show();
        }
    }
}
