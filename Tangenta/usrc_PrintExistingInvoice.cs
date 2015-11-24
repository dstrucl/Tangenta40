using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LanguageControl;
using DBConnectionControl40;
using BlagajnaTableClass;
using DBTypes;

namespace Tangenta
{
    public partial class usrc_PrintExistingInvoice : UserControl
    {
        public delegate void delegate_DoPrint_Existing_Invoice(DateTime_v issue_time);
        public event delegate_DoPrint_Existing_Invoice aa_DoPrint_Existing_Invoice;
        DateTime_v ProformaInvoiceTime_v = null;
        DataTable dt = new DataTable();


        long ProformaInvoice_ID = -1;
        public usrc_PrintExistingInvoice()
        {
            InitializeComponent();
            lbl_Invoice.Text = lngRPM.s_Journal_InvoicePrint.s;

        }


        public bool Init(long xProformaInvoice_ID,string InvoiceNumber)
        {
            ProformaInvoice_ID = xProformaInvoice_ID;
            lbl_Invoice_value.Text = InvoiceNumber;
            btn_Print.Text = lngRPM.s_Print.s;
            return ShowJournal();
        }


        public bool ShowJournal()
        {
            string sql = @"select   ID,
                                    JOURNAL_ProformaInvoice_$_pinv_$$FinancialYear,
                                    JOURNAL_ProformaInvoice_$_pinv_$$NumberInFinancialYear,
                                    JOURNAL_ProformaInvoice_$_jpinvt_$$Name,
                                    JOURNAL_ProformaInvoice_$_jpinvt_$$Description,
                                    JOURNAL_ProformaInvoice_$$EventTime,
                                    JOURNAL_ProformaInvoice_$_pinv_$$GrossSum,
                                    JOURNAL_ProformaInvoice_$_pinv_$$TaxSum,
                                    JOURNAL_ProformaInvoice_$_pinv_$$NetSum,
                                    JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_acfn_$$FirstName,
                                    JOURNAL_ProformaInvoice_$_pinv_$_acusper_$_aper_$_acln_$$LastName,
                                    JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$$FirstName,
                                    JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$$LastName
                                    from JOURNAL_ProformaInvoice_VIEW where JOURNAL_ProformaInvoice_$_pinv_$$ID = " + ProformaInvoice_ID.ToString() + " order by ID desc";
            dt.Clear();
            string Err = null;
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, ref Err))
            {
                dgvx_Journal_InvoicePrint.DataSource = dt;
                SQLTableControl.SQLTable tbl = new SQLTableControl.SQLTable(DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(JOURNAL_ProformaInvoice)));
                tbl.SetVIEW_DataGridViewImageColumns_Headers(dgvx_Journal_InvoicePrint, DBSync.DBSync.DB_for_Blagajna.m_DBTables);
                dgvx_Journal_InvoicePrint.Columns["JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$$FirstName"].HeaderText = lngRPM.s_FirstNameOfPersonThatPrintedInvoice.s;
                dgvx_Journal_InvoicePrint.Columns["JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$$FirstName"].HeaderText = lngRPM.s_LastNameOfPersonThatPrintedInvoice.s;
                if (dt.Rows.Count>0)
                {
                    if (dt.Rows[0]["JOURNAL_ProformaInvoice_$$EventTime"] is DateTime)
                    {
                        if (ProformaInvoiceTime_v==null)
                        {
                            ProformaInvoiceTime_v = new DateTime_v();
                        }
                        ProformaInvoiceTime_v.v = (DateTime)dt.Rows[0]["JOURNAL_ProformaInvoice_$$EventTime"];
                    }
                }
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:usrc_PrintExistingInvoice:Init:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }

        }

        private void btn_Print_Click(object sender, EventArgs e)
        {
            
            if (aa_DoPrint_Existing_Invoice != null)
            {
                    aa_DoPrint_Existing_Invoice(ProformaInvoiceTime_v);
                    ShowJournal();
            }
        }

    }
}
