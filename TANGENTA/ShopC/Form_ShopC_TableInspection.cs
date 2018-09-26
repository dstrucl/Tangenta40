using DBConnectionControl40;
using DBTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TangentaDB;

namespace ShopC
{
    public partial class Form_ShopC_TableInspection : Form
    {
        private string col_ID = null;
        private const string col_NumberInFinancialYear = "NumberInFinancialYear";
        private const string col_FinancialYear = "FinancialYear";
        private const string col_IssueDate = "IssueDate";
        private const string col_GrossSum = "GrossSum";

        private static Form_ShopC_TableInspection frmshopc_table_inspection = null;

        private DataTable dtDoc = null;
        private DataTable dtShopCItems = null;
        private DataTable dtStock = null;

        private ID CurrentDoc_ID = null;
        private ShopABC m_ShopABC = null;

        public Form_ShopC_TableInspection()
        {
            InitializeComponent();
            this.rdb_Invoice.Checked = true;
            this.rdb_Invoice.CheckedChanged += Rdb_Invoice_CheckedChanged;
            this.rdb_ProformaInvoice.CheckedChanged += Rdb_ProformaInvoice_CheckedChanged;

        }

        public Form_ShopC_TableInspection(ShopABC x_ShopABC)
        {
            InitializeComponent();
            this.m_ShopABC = x_ShopABC;
            this.rdb_Invoice.Checked = x_ShopABC.IsDocInvoice;
            this.rdb_ProformaInvoice.Checked = x_ShopABC.IsDocProformaInvoice;
            this.rdb_Invoice.CheckedChanged += Rdb_Invoice_CheckedChanged;
            this.rdb_ProformaInvoice.CheckedChanged += Rdb_ProformaInvoice_CheckedChanged;
        }

        private void Rdb_ProformaInvoice_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_ProformaInvoice.Checked)
            {
                Init();
            }
        }

        private void Rdb_Invoice_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_Invoice.Checked)
            {
                Init();
            }
        }

        private void Form_ShopC_TableInspection_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            dgvx_ShopC_Docs.SelectionChanged -= Dgvx_ShopC_Docs_SelectionChanged;
            if (!Init())
            {
                this.Close();
                DialogResult = DialogResult.Abort;
            }
            else
            {
                this.Cursor = Cursors.WaitCursor;
                if (this.rdb_Invoice.Checked)
                {
                    col_ID = "DocInvoice_ID";
                }
                else
                {
                    col_ID = "DocProformaInvoice_ID";
                }
                dgvx_ShopC_Docs.SelectionChanged += Dgvx_ShopC_Docs_SelectionChanged;
                if (m_ShopABC != null)
                {
                    foreach (DataGridViewRow dgvr in dgvx_ShopC_Docs.Rows)
                    {
                        ID xdoc_ID = tf.set_ID(dgvr.Cells[col_ID].Value);
                        if (xdoc_ID.Equals(m_ShopABC.m_CurrentDoc.Doc_ID))
                        {
                            dgvr.Selected = true;
                            dgvx_ShopC_Docs.CurrentCell = dgvr.Cells[0];
                            this.Cursor = Cursors.Arrow;
                            return;
                        }
                        else
                        {
                            dgvr.Selected = true;
                        }
                    }
                }
                this.Cursor = Cursors.Arrow;
            }
            
        }

        private void Dgvx_ShopC_Docs_SelectionChanged(object sender, EventArgs e)
        {

  
        if (this.rdb_Invoice.Checked)
        {
            col_ID = "DocInvoice_ID";
        }
        else
        {
            col_ID = "DocProformaInvoice_ID";
        }
        DataGridViewSelectedCellCollection dgvCellCollection = this.dgvx_ShopC_Docs.SelectedCells;
        if (dgvCellCollection.Count >= 1)
        {
            //lbl_test_sender_type.Text = "Count:" + dgvCellCollection.Count.ToString() + " CellType=" + dgvCellCollection[0].GetType().ToString() + " ValueType" + dgvCellCollection[0].Value.GetType().ToString() + " Value=" + dgvCellCollection[0].Value.ToString() + " Column Name = " + dgvCellCollection[0].OwningColumn.Name;
            CurrentDoc_ID = tf.set_ID(dgvCellCollection[0].OwningRow.Cells[col_ID].Value);
            if (ID.Validate(CurrentDoc_ID))
            {
                int_v NumberInFinancialYear_v = tf.set_int(dgvCellCollection[0].OwningRow.Cells[col_NumberInFinancialYear].Value);
                int_v FinancialYear_v = tf.set_int(dgvCellCollection[0].OwningRow.Cells[col_FinancialYear].Value);

                DateTime_v IssueDate_v = null;
                if (rdb_Invoice.Checked)
                {
                    IssueDate_v = tf.set_DateTime(dgvCellCollection[0].OwningRow.Cells[col_IssueDate].Value);
                }

                decimal_v GrossSum_v = tf.set_decimal(dgvCellCollection[0].OwningRow.Cells[col_GrossSum].Value);

                string sNumberInFinancialYear = "";
                if (NumberInFinancialYear_v!=null)
                {
                    sNumberInFinancialYear = NumberInFinancialYear_v.v.ToString();
                }
                string sFinancialYear = "";
                if (FinancialYear_v != null)
                {
                    sFinancialYear = FinancialYear_v.v.ToString();
                }

                string sGrossSum = "";
                if (GrossSum_v != null)
                {
                    sGrossSum = "Invoice Total:"+ LanguageControl.DynSettings.SetLanguageCurrencyString(GrossSum_v.v,GlobalData.BaseCurrency.DecimalPlaces, GlobalData.BaseCurrency.Symbol);
                }

                string sIssueDate = "";
                if (IssueDate_v!=null)
                {
                    sIssueDate = "IssueDate:"+ LanguageControl.DynSettings.SetLanguageDateTimeString(IssueDate_v.v);
                }
                if (GrossSum_v != null)
                {
                    sGrossSum = "Invoice Total:" + LanguageControl.DynSettings.SetLanguageCurrencyString(GrossSum_v.v, GlobalData.BaseCurrency.DecimalPlaces, GlobalData.BaseCurrency.Symbol);
                }

                string sDocID = null;
                if (rdb_Invoice.Checked)
                {
                    sDocID = "DocInvoice_ID";
                }
                else
                {
                    sDocID = "DocProformaInvoice_ID";
                }

                lbl_Doc_Info.Text = sDocID + "=" + CurrentDoc_ID.ToString()
                                    + " " + sNumberInFinancialYear + "/" + sFinancialYear
                                    + " " + sIssueDate 
                                    + " " + sGrossSum;
                }
                showShopCItems(CurrentDoc_ID);
            }
        }

        private bool showShopCItems(ID currentDoc_ID)
        {
            this.dgvx_DocID_ShopC_Items.SelectionChanged -= new System.EventHandler(this.dgvx_DocID_ShopC_Items_SelectionChanged);
            this.dgvx_DocID_ShopC_Items.ClearSelection();
            dgvx_DocID_ShopC_Items.DataSource = null;
            if (rdb_Invoice.Checked)
            {
                if (f_DocInvoice_ShopC_Item.GetItems(currentDoc_ID, ref dtShopCItems))
                {
                    dgvx_DocID_ShopC_Items.DataSource = dtShopCItems;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if (f_DocProformaInvoice.GetItems(currentDoc_ID, ref dtShopCItems))
                {
                    dgvx_DocID_ShopC_Items.DataSource = dtShopCItems;
                }
                else
                {
                    return false;
                }
            }
            this.dgvx_DocID_ShopC_Items.SelectionChanged += new System.EventHandler(this.dgvx_DocID_ShopC_Items_SelectionChanged);
            return true;
        }

        private bool Init()
        {
            this.Cursor = Cursors.WaitCursor;

            this.dgvx_DocID_ShopC_Items.SelectionChanged -= new System.EventHandler(this.dgvx_DocID_ShopC_Items_SelectionChanged);

            dgvx_ShopC_Docs.DataSource = null;
            if (this.rdb_Invoice.Checked)
            {
                if (chk_OnlyFromStock.Checked)
                {
                    if (f_DocInvoice.Get_ShopC_Invoices_FromStock(ref dtDoc))
                    {
                        dgvx_ShopC_Docs.DataSource = dtDoc;
                    }
                    else
                    {
                        this.Cursor = Cursors.Arrow;
                        return false;
                    }
                }
                else
                {
                    if (f_DocInvoice.Get_ShopC_Invoices(ref dtDoc))
                    {
                        dgvx_ShopC_Docs.DataSource = dtDoc;
                    }
                    else
                    {
                        this.Cursor = Cursors.Arrow;
                        return false;
                    }
                }
            }
            else
            {
                if (chk_OnlyFromStock.Checked)
                {
                    if (f_DocProformaInvoice.Get_ShopC_ProformaInvoices_FromStock(ref dtDoc))
                    {
                        dgvx_ShopC_Docs.DataSource = dtDoc;
                    }
                    else
                    {
                        this.Cursor = Cursors.Arrow;
                        return false;
                    }
                }
                else
                {
                    if (f_DocProformaInvoice.Get_ShopC_ProformaInvoices(ref dtDoc))
                    {
                        dgvx_ShopC_Docs.DataSource = dtDoc;
                    }
                    else
                    {
                        this.Cursor = Cursors.Arrow;
                        return false;
                    }
                }
            }
            dgvx_Stock.DataSource = null;
            if (f_Stock.GetStock(ref dtStock))
            {
                dgvx_Stock.DataSource = dtStock;
                lbl_Stock_Info.Text = "Stock data for all";
            }
            else
            {
                this.Cursor = Cursors.Arrow;
                return false;
            }
            this.Cursor = Cursors.Arrow;
            return true;
        }

        private void btn_Reload_Click(object sender, EventArgs e)
        {
            Init();
        }

        public static void DoShow(Form pform)
        {
            if (frmshopc_table_inspection != null)
            {
                if (frmshopc_table_inspection.IsDisposed)
                {
                    frmshopc_table_inspection = null;
                }
            }
            if (frmshopc_table_inspection == null)
            {
                frmshopc_table_inspection = new Form_ShopC_TableInspection();

                frmshopc_table_inspection.Owner = pform;
            }
            frmshopc_table_inspection.Show();
        }

        internal static void DoShow(Form pform, ShopABC m_ShopBC)
        {
            pform.Cursor = Cursors.WaitCursor;
            if (frmshopc_table_inspection != null)
            {
                if (frmshopc_table_inspection.IsDisposed)
                {
                    frmshopc_table_inspection = null;
                }
            }
            if (frmshopc_table_inspection == null)
            {
                frmshopc_table_inspection = new Form_ShopC_TableInspection(m_ShopBC);

                frmshopc_table_inspection.Owner = pform;
            }
            frmshopc_table_inspection.Show();
            pform.Cursor = Cursors.Arrow;
        }

        private void dgvx_DocID_ShopC_Items_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewSelectedCellCollection dgvCellCollection = this.dgvx_DocID_ShopC_Items.SelectedCells;
            if (dgvCellCollection.Count >= 1)
            {
                //lbl_test_sender_type.Text = "Count:" + dgvCellCollection.Count.ToString() + " CellType=" + dgvCellCollection[0].GetType().ToString() + " ValueType" + dgvCellCollection[0].Value.GetType().ToString() + " Value=" + dgvCellCollection[0].Value.ToString() + " Column Name = " + dgvCellCollection[0].OwningColumn.Name;
                string_v item_Unique_name_v = tf.set_string(dgvCellCollection[0].OwningRow.Cells["Atom_Item_UniqueName"].Value);
                if (item_Unique_name_v != null)
                {
                    dgvx_Stock.DataSource = null;
                    if (f_Stock.GetStock(ref dtStock, item_Unique_name_v.v))
                    {
                        dgvx_Stock.DataSource = dtStock;
                        lbl_Stock_Info.Text = "Stock data for " + "\"" + item_Unique_name_v.v + "\"";
                    }
                }
            }
        }
   }
}
