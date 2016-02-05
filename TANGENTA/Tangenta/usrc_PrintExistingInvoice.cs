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
using LanguageControl;
using DBConnectionControl40;
using BlagajnaTableClass;
using DBTypes;
using InvoiceDB;

namespace Tangenta
{
    public partial class usrc_PrintExistingInvoice : UserControl
    {
        public delegate void delegate_Cancel();
        public event delegate_Cancel Cancel;

        public InvoiceData m_InvoiceData = null;
        DateTime_v ProformaInvoiceTime_v = null;
        DataTable dt = new DataTable();


        long ProformaInvoice_ID = -1;
        public usrc_PrintExistingInvoice()
        {
            InitializeComponent();
            lbl_Invoice.Text = lngRPM.s_Journal_InvoicePrint.s;

        }


        public bool Init(InvoiceData xInvoiceData,string InvoiceNumber)
        {

            m_InvoiceData = xInvoiceData;
            ProformaInvoice_ID = m_InvoiceData.m_ShopABC.m_CurrentInvoice.ProformaInvoice_ID;
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
                                    JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper_$_acfn_$$FirstName,
                                    JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper_$_acln_$$LastName
                                    from JOURNAL_ProformaInvoice_VIEW where JOURNAL_ProformaInvoice_$_pinv_$$ID = " + ProformaInvoice_ID.ToString() + " order by ID desc";
            dt.Clear();
            string Err = null;
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, ref Err))
            {
                dgvx_Journal_InvoicePrint.DataSource = dt;
                SQLTableControl.SQLTable tbl = new SQLTableControl.SQLTable(DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(JOURNAL_ProformaInvoice)));
                tbl.SetVIEW_DataGridViewImageColumns_Headers(dgvx_Journal_InvoicePrint, DBSync.DBSync.DB_for_Blagajna.m_DBTables);
                dgvx_Journal_InvoicePrint.Columns["JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper_$_acfn_$$FirstName"].HeaderText = lngRPM.s_FirstNameOfPersonThatPrintedInvoice.s;
                dgvx_Journal_InvoicePrint.Columns["JOURNAL_ProformaInvoice_$_awperiod_$_amcper_$_aper_$_acln_$$LastName"].HeaderText = lngRPM.s_LastNameOfPersonThatPrintedInvoice.s;
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
            
            DateTime dtInvoiceTime = DateTime.MinValue;
            if (GetInvoiceTime(ref dtInvoiceTime))
            {
                if (ProformaInvoiceTime_v == null)
                {
                    ProformaInvoiceTime_v = new DateTime_v();
                }
                ProformaInvoiceTime_v.v = dtInvoiceTime;
                Program.usrc_Printer1.Print_Receipt(m_InvoiceData, GlobalData.ePaymentType.NONE, null, null, null, ProformaInvoiceTime_v);
                ShowJournal();
            }
        }

        private bool GetInvoiceTime(ref DateTime dtInvoiceTime)
        {
            string sql = @"select   JOURNAL_ProformaInvoice_$$EventTime
                                    from JOURNAL_ProformaInvoice_VIEW where 
                                    JOURNAL_ProformaInvoice_$_jpinvt_$$Name = 'InvoiceTime' and
                                    JOURNAL_ProformaInvoice_$_pinv_$$ID = " + ProformaInvoice_ID.ToString() + " order by ID desc";
            dt.Clear();
            string Err = null;
            DataTable xdt = new DataTable();
            if (DBSync.DBSync.ReadDataTable(ref xdt, sql, ref Err))
            {
                if (xdt.Rows.Count>0)
                {
                    dtInvoiceTime = (DateTime)xdt.Rows[0]["JOURNAL_ProformaInvoice_$$EventTime"];
                    return true;
                }
                else
                {
                    LogFile.Error.Show("ERROR:usrc_PrintExistingInvoice:GetInvoiceTime:sql=" + sql + "\r\nErr= xdt.Rows.Count == 0");
                    return false;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:usrc_PrintExistingInvoice:Init:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            if (Cancel!=null)
            {
                Cancel();
            }
        }
    }
}
