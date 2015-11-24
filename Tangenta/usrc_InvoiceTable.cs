using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SQLTableControl;
using BlagajnaTableClass;
using DBConnectionControl40;
using LanguageControl;

namespace Tangenta
{
    public partial class usrc_InvoiceTable : UserControl
    {
        public enum eMode { All, Today, ThisWeek, LastWeek, ThisMonth, LastMonth, ThisYear, LastYear, TimeSpan };
        public delegate void delegate_SelectedInvoiceChanged(long Invoice_ID, bool bInitialise);
        public event delegate_SelectedInvoiceChanged SelectedInvoiceChanged;
        public Color ColorDraft;
        public Color ColorStorno;

        public bool m_bInvoice = false;
        public string cond = null;

        public string ExtraCondition = null;
        public List<SQL_Parameter> lpar_ExtraCondition = null;
        public DateTime dtStartTime;
        public DateTime dtEndTime;
        public eMode Mode = eMode.All;

        public string sFromTo_Suffix = "";
        public DataTable dt_XInvoice = new DataTable();

        private usrc_Invoice.enum_Invoice enum_Invoice;
        private int iColIndex_ProformaInvoice_Draft = -1;
        private int iColIndex_ProformaInvoice_Invoice_Storno = -1;

        public usrc_InvoiceTable()
        {
            InitializeComponent();
            ExtensionMethods.DoubleBuffered(this.dgvx_XInvoice, true);
            dtStartTime = DateTime.Now;
            dtEndTime = DateTime.Now;
            lbl_From_To.Text = lngRPM.s_AllData.s;


        }

        internal int Init(usrc_Invoice.enum_Invoice xenum_Invoice, bool bNew)
        {
            ColorDraft = Properties.Settings.Default.ColorDraft;
            ColorStorno = Properties.Settings.Default.ColorStorno;
            int iRowsCount = -1;
            enum_Invoice = xenum_Invoice;
            switch (enum_Invoice)
            {
                case usrc_Invoice.enum_Invoice.Invoice:
                    this.dgvx_XInvoice.SelectionChanged -= new System.EventHandler(this.dgvx_XInvoice_SelectionChanged);
                    iRowsCount = Init_Invoice(true, bNew);
                    ShowOrEditSelectedRow(true);
                    this.dgvx_XInvoice.SelectionChanged += new System.EventHandler(this.dgvx_XInvoice_SelectionChanged);
                    break;
                case usrc_Invoice.enum_Invoice.ProformaInvoice:
                    iRowsCount = Init_ProformaInvoice();
                    break;
            }
            return iRowsCount;
        }

        private int Init_ProformaInvoice()
        {
            int iRowsCount = -1;
            return iRowsCount;
        }

        private int Init_Invoice(bool bInvoice, bool bNew)
        {
            m_bInvoice = bInvoice;
            int iRowsCount = -1;
            string s_JOURNAL_ProformaInvoice_Type_ID = Program.JOURNAL_ProformaInvoice_Type_definitions.InvoiceDraftTime.ID.ToString();

            if (bInvoice)
            {
                cond = " where JOURNAL_ProformaInvoice_$_pinv_$_inv_$$ID is not null ";
            }
            else
            {
                cond = " where JOURNAL_ProformaInvoice_$_pinv_$_inv_$$ID is null ";
            }

            if (ExtraCondition!=null)
            {
                s_JOURNAL_ProformaInvoice_Type_ID = Program.JOURNAL_ProformaInvoice_Type_definitions.InvoiceTime.ID.ToString();
                cond += " and " + ExtraCondition;
            }
            else
            {
                lpar_ExtraCondition = null;
            }

            string sql = @" select 
                            JOURNAL_ProformaInvoice_$_pinv_$$FinancialYear,
                            JOURNAL_ProformaInvoice_$_pinv_$$Draft,
                            JOURNAL_ProformaInvoice_$_pinv_$$DraftNumber,
                            JOURNAL_ProformaInvoice_$_pinv_$$NumberInFinancialYear,
                            JOURNAL_ProformaInvoice_$_pinv_$$GrossSum,
                            JOURNAL_ProformaInvoice_$$EventTime,
                            JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_acfn_$$FirstName,
                            JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_acln_$$LastName,
                            JOURNAL_ProformaInvoice_$_pinv_$_inv_$_metopay_$$PaymentType,
                            JOURNAL_ProformaInvoice_$_pinv_$$NetSum,
                            JOURNAL_ProformaInvoice_$_pinv_$$TaxSum,
                            JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_acadrper_$_astrnper_$$StreetName,
                            JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_acadrper_$_ahounper_$$HouseNumber,
                            JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_acadrper_$_azipper_$$ZIP,
                            JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_acadrper_$_acitper_$$City,
                            JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_agsmnper_$$GsmNumber,
                            JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_aphnnper_$$PhoneNumber,
                            JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_aemailper_$$Email,
                            JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$$DateOfBirth,
                            JOURNAL_ProformaInvoice_$_pinv_$_acusorg_$_aorg_$$Name,
                            JOURNAL_ProformaInvoice_$_pinv_$_acusorg_$_aorg_$$Tax_ID,
                            JOURNAL_ProformaInvoice_$_pinv_$_acusorg_$_aorg_$$Registration_ID
                            JOURNAL_ProformaInvoice_$_pinv_$_inv_$$Paid,
                            JOURNAL_ProformaInvoice_$_pinv_$_inv_$$Storno,
                            JOURNAL_ProformaInvoice_$_pinv_$$Discount,
                            JOURNAL_ProformaInvoice_$_pinv_$$EndSum,
                            JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$$UserName,
                            JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$$FirstName,
                            JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$$LastName,
                            JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aoffice_$$Name,
                            JOURNAL_ProformaInvoice_$_pinv_$_inv_$$ID
                            from JOURNAL_ProformaInvoice_VIEW " + cond +" and JOURNAL_ProformaInvoice_$_jpinvt_$$ID = " + s_JOURNAL_ProformaInvoice_Type_ID + " order by JOURNAL_ProformaInvoice_$_pinv_$$FinancialYear desc,JOURNAL_ProformaInvoice_$_pinv_$$Draft desc, JOURNAL_ProformaInvoice_$_pinv_$$NumberInFinancialYear desc, JOURNAL_ProformaInvoice_$_pinv_$$DraftNumber desc";
            int iCurrentSelectedRow = -1;
            if (!bNew)
            {
                DataGridViewSelectedRowCollection dgvxc = dgvx_XInvoice.SelectedRows;
                if (dgvxc.Count>0)
                {
                    DataGridViewRow dgvr = dgvxc[0];
                    iCurrentSelectedRow = dgvx_XInvoice.Rows.IndexOf(dgvr);
                }
            }
            //this.dgvx_XInvoice.SelectionChanged -= new System.EventHandler(this.dgvx_XInvoice_SelectionChanged); // remove handler
            dt_XInvoice.Clear();
            dt_XInvoice.Columns.Clear();
            string Err = null;
            iColIndex_ProformaInvoice_Draft = -1;
            iColIndex_ProformaInvoice_Invoice_Storno = -1;
            bool bRes = DBSync.DBSync.ReadDataTable(ref dt_XInvoice, sql, lpar_ExtraCondition, ref Err);
            if (bRes)
            {
                dgvx_XInvoice.DataSource = dt_XInvoice;
                iColIndex_ProformaInvoice_Draft = dt_XInvoice.Columns.IndexOf("JOURNAL_ProformaInvoice_$_pinv_$$Draft");
                iColIndex_ProformaInvoice_Invoice_Storno = dt_XInvoice.Columns.IndexOf("JOURNAL_ProformaInvoice_$_pinv_$_inv_$$Storno");

                SetLabels();
                //this.dgvx_XInvoice.SelectionChanged += new System.EventHandler(this.dgvx_XInvoice_SelectionChanged); // Add Handler
                SQLTable tbl = new SQLTable(DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(ProformaInvoice)));
                tbl.SetVIEW_DataGridViewImageColumns_Headers((DataGridView)dgvx_XInvoice, DBSync.DBSync.DB_for_Blagajna.m_DBTables);
                iRowsCount = dt_XInvoice.Rows.Count;
                if (!bNew)
                {
                    if (iRowsCount > 0)
                    {
                        if (iCurrentSelectedRow >= 0)
                        {
                            dgvx_XInvoice.Rows[iCurrentSelectedRow].Selected = true;


                        }
                    }
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:usrc_InvoiceTable:Init_Invoice Err=" + Err);
            }
            return iRowsCount;
        }

        private decimal Sum(string ColumnName)
        {
            decimal sum = 0;
            int iColDraft = dt_XInvoice.Columns.IndexOf("JOURNAL_ProformaInvoice_$_pinv_$$Draft");
            int iCol = dt_XInvoice.Columns.IndexOf(ColumnName);
            int iCount = dt_XInvoice.Rows.Count;
            int i = 0;
            for (i=0;i<iCount;i++)
            {
                if ((bool)dt_XInvoice.Rows[i][iColDraft])
                {
                    continue;
                }
                else
                { 
                    sum += (decimal)dt_XInvoice.Rows[i][iCol];
                }
            }
            return sum;
        }

        private void SumPayments(SumPaymentList xSumPaymentList)
        {

            int iColDraft = dt_XInvoice.Columns.IndexOf("JOURNAL_ProformaInvoice_$_pinv_$$Draft");
            int iCol = dt_XInvoice.Columns.IndexOf("JOURNAL_ProformaInvoice_$_pinv_$$GrossSum");
            int iColPayment = dt_XInvoice.Columns.IndexOf("JOURNAL_ProformaInvoice_$_pinv_$_inv_$_metopay_$$PaymentType");
            
            int iCount = dt_XInvoice.Rows.Count;
            int i = 0;
            for (i = 0; i < iCount; i++)
            {
                if ((bool)dt_XInvoice.Rows[i][iColDraft])
                {
                    continue;
                }
                else
                { 
                    xSumPaymentList.Add((decimal)dt_XInvoice.Rows[i][iCol], (string)dt_XInvoice.Rows[i][iColPayment]);
                }
            }
        }

        private void SetLabels()
        {
            if (dt_XInvoice.Rows.Count>0)
            { 
                string currency_symbol = Program.BaseCurrency.Symbol;
                SumPaymentList xSumPaymentList = new SumPaymentList();
                SumPayments(xSumPaymentList);
                if (xSumPaymentList.SumPayment_List.Count > 0)
                {
                    lbl_Payment1.Text = xSumPaymentList.SumPayment_List[0].PaymentType + " = " + xSumPaymentList.SumPayment_List[0].Sum.ToString() + " " + currency_symbol;
                }
                if (xSumPaymentList.SumPayment_List.Count > 1)
                {
                    lbl_Payment2.Text = xSumPaymentList.SumPayment_List[1].PaymentType + " = " + xSumPaymentList.SumPayment_List[1].Sum.ToString() + " " + currency_symbol;
                }

                decimal gross_sum = Sum("JOURNAL_ProformaInvoice_$_pinv_$$GrossSum");
                decimal net_sum = Sum("JOURNAL_ProformaInvoice_$_pinv_$$NetSum");
                decimal tax_sum = Sum("JOURNAL_ProformaInvoice_$_pinv_$$TaxSum");
                lbl_Sum_All.Text = lngRPM.s_Sum_All.s + gross_sum.ToString() + " " + currency_symbol;
                lbl_Sum_Tax.Text = lngRPM.s_Sum_Tax.s + tax_sum.ToString() + " " + currency_symbol; ;
                lbl_Sum_WithoutTax.Text = lngRPM.s_Sum_WithoutTax.s + net_sum.ToString() + " " + currency_symbol; 

            }
            else
            {
                lbl_Sum_All.Text = "";
                lbl_Sum_Tax.Text = "";
                lbl_Sum_WithoutTax.Text = "";
                lbl_Payment2.Text = "";
                lbl_Payment1.Text = "";

            }


        }

        private void ShowOrEditSelectedRow(bool bInitialise)
        {
            if (SelectedInvoiceChanged!=null)
            { 
                DataGridViewSelectedCellCollection dgvCellCollection = this.dgvx_XInvoice.SelectedCells;
                if (dgvCellCollection.Count >= 1)
                {
                    //lbl_test_sender_type.Text = "Count:" + dgvCellCollection.Count.ToString() + " CellType=" + dgvCellCollection[0].GetType().ToString() + " ValueType" + dgvCellCollection[0].Value.GetType().ToString() + " Value=" + dgvCellCollection[0].Value.ToString() + " Column Name = " + dgvCellCollection[0].OwningColumn.Name;
                    if (dgvCellCollection[0].OwningRow.Cells["JOURNAL_ProformaInvoice_$_pinv_$_inv_$$ID"].Value is long)
                    {
                        long Identity = (long)dgvCellCollection[0].OwningRow.Cells["JOURNAL_ProformaInvoice_$_pinv_$_inv_$$ID"].Value;
                        SelectedInvoiceChanged(Identity, bInitialise);
                        return;
                    }
                }
                SelectedInvoiceChanged(-1, bInitialise);
            }
        }

        private void dgvx_XInvoice_SelectionChanged(object sender, EventArgs e)
        {
            ShowOrEditSelectedRow(false);
        }

        private void btn_TimeSpan_Click(object sender, EventArgs e)
        {
            Form_Select_TimeSpan frm_timespan = new Form_Select_TimeSpan(this);
            if (frm_timespan.ShowDialog()== DialogResult.OK)
            {
                Program.Cursor_Wait();
                Init(enum_Invoice, true);
                Program.Cursor_Arrow();
            }
        }


        internal void SetMode(eMode eMode, string sText)
        {
            Mode = eMode;
            lbl_From_To.Text = sText;
        }

        private string sTimeSpan()
        {
            return " " + lngRPM.s_from.s + " " + sDate(dtStartTime) + " " + lngRPM.s_to.s +" "+ sDate(DayMinus(dtEndTime)) ;
        }

        private string sTimeSpan_Suffix()
        {
            return "_"+sDate_Suffix(dtStartTime) + "__" + sDate_Suffix(DayMinus(dtEndTime));
        }

        private DateTime DayMinus(DateTime date)
        {
            DateTime dt = date.AddDays(-1);
            return dt;
        }

        private string sDate(DateTime date)
        {
            return date.Day.ToString() + "." + date.Month.ToString() + "." + date.Year.ToString();
        }

        private string sDate_Suffix(DateTime date)
        {
            return "_"+ date.Day.ToString() + "_" + date.Month.ToString() + "_" + date.Year.ToString();
        }

        private void SetTimeSpanParam_Ex(DateTime xdtStartTime,DateTime xdtEndTime)
        {
            string sparam1 = "@par_ProformaInvoiceTime_Start";
            string sparam2 = "@par_ProformaInvoiceTime_End";
            dtStartTime = xdtStartTime;
            dtEndTime = xdtEndTime;
            lpar_ExtraCondition = null;
            lpar_ExtraCondition = new List<DBConnectionControl40.SQL_Parameter>();
            SQL_Parameter par1 = new SQL_Parameter(sparam1, SQL_Parameter.eSQL_Parameter.Datetime, false, dtStartTime);
            lpar_ExtraCondition.Add(par1);
            SQL_Parameter par2 = new SQL_Parameter(sparam2, SQL_Parameter.eSQL_Parameter.Datetime, false, dtEndTime);
            lpar_ExtraCondition.Add(par2);
            ExtraCondition = " (JOURNAL_ProformaInvoice_$$EventTime >= " + sparam1 + ") and ( JOURNAL_ProformaInvoice_$$EventTime < " + sparam2 + ") ";

        }
        internal void SetTimeSpanParam(eMode eMode, DateTime xdtStartTime, DateTime xdtEndTime)
        {
            Mode = eMode;
            if (eMode == usrc_InvoiceTable.eMode.All)
            {
                lbl_From_To.Text = lngRPM.s_ShowAll.s;
                sFromTo_Suffix = "";
                ExtraCondition = null;
                lpar_ExtraCondition = null;
            }
            else
            {
                SetTimeSpanParam_Ex(xdtStartTime, xdtEndTime);
                switch (eMode)
                {
                    case usrc_InvoiceTable.eMode.Today:
                        lbl_From_To.Text = lngRPM.s_Today.s + " " + sDate(dtStartTime);
                        sFromTo_Suffix = sDate_Suffix(dtStartTime);
                        break;
                    case usrc_InvoiceTable.eMode.ThisWeek:
                        lbl_From_To.Text = lngRPM.s_ThisWeek.s + sTimeSpan();
                        sFromTo_Suffix = sTimeSpan_Suffix();
                        break;

                    case usrc_InvoiceTable.eMode.LastWeek:
                        lbl_From_To.Text = lngRPM.s_LastWeek.s + sTimeSpan();
                        sFromTo_Suffix = sTimeSpan_Suffix();
                        break;
                    case usrc_InvoiceTable.eMode.ThisMonth:
                        lbl_From_To.Text = lngRPM.s_ThisMonth.s + sTimeSpan();
                        sFromTo_Suffix = sTimeSpan_Suffix();
                        break;
                    case usrc_InvoiceTable.eMode.LastMonth:
                        lbl_From_To.Text = lngRPM.s_LastMonth.s + sTimeSpan();
                        sFromTo_Suffix = sTimeSpan_Suffix();
                        break;
                    case usrc_InvoiceTable.eMode.ThisYear:
                        lbl_From_To.Text = lngRPM.s_ThisYear.s + sTimeSpan();
                        sFromTo_Suffix = sTimeSpan_Suffix();
                        break;
                    case usrc_InvoiceTable.eMode.LastYear:
                        lbl_From_To.Text = lngRPM.s_LastYear.s + sTimeSpan();
                        sFromTo_Suffix = sTimeSpan_Suffix();
                        break;
                    case usrc_InvoiceTable.eMode.TimeSpan:
                        lbl_From_To.Text = lngRPM.s_TimeSpan.s + sTimeSpan();
                        sFromTo_Suffix = sTimeSpan_Suffix();
                        break;
                }
            }
        }

        private void dgvx_XInvoice_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

            DataGridView dgv = (DataGridView)sender;
            if (e.RowIndex>=0)
            {
                if ((iColIndex_ProformaInvoice_Draft >= 0) && (iColIndex_ProformaInvoice_Invoice_Storno>=0))
                {
                    if ((bool)dt_XInvoice.Rows[e.RowIndex][iColIndex_ProformaInvoice_Draft])
                    {
                        e.CellStyle.BackColor = ColorDraft;
                    }
                    else if ((bool)dt_XInvoice.Rows[e.RowIndex][iColIndex_ProformaInvoice_Invoice_Storno])
                    {
                        e.CellStyle.BackColor = ColorStorno;
                    }
                    else
                    {
                        e.CellStyle.BackColor = Color.White;
                    }
                }
            }
        }

        private void btn_Print_Click(object sender, EventArgs e)
        {
            Form_PrintReport frm_print = new Form_PrintReport(this);
            frm_print.ShowDialog();
        }
    }
}
