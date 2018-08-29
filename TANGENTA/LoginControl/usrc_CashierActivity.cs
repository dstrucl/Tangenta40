using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TangentaDB;

namespace LoginControl
{
    public partial class usrc_CashierActivity : UserControl
    {
        public delegate void delegate_btn_Yes_Click();
        public event delegate_btn_Yes_Click Yes_Click = null;

        public delegate void delegate_btn_No_Click();
        public event delegate_btn_No_Click No_Click = null;

        public delegate void delegate_btn_YesPrint_Click();
        public event delegate_btn_YesPrint_Click YesPrint_Click = null;

        private CashierActivity m_ca = null;

        public usrc_CashierActivity()
        {
            InitializeComponent();
        }

        public void Init(CashierActivity ca)
        {
            lng.s_lbl_CashierOpen_Question.Text(lbl_CashierOpen_Question);
            lng.s_btn_NO.Text(btn_NO);
            lng.s_btn_YES.Text(btn_YES);
            lng.s_lbl_CashierActivityNumber.Text(lbl_CashierActivityNumber);
            lng.s_lbl_CashierOpenedTime.Text(lbl_CashierOpenedTime);
            lng.s_lbl_PersonWhoOpenedCashier.Text(lbl_PersonWhoOpenedCashier);
            lng.s_pnl_Realisation_ByTaxRate.Text(pnl_Realisation_ByTaxRate);
            lng.s_lbl_NumberOfInvoices.Text(lbl_NumberOfInvoices);
            lng.s_lbl_NetPrice.Text(lbl_NetPrice);
            lng.s_lbl_TaxPrice.Text(lbl_TaxPrice);
            lng.s_lbl_Total.Text(lbl_Total);
            lng.s_btn_YesPrint.Text(btn_YesPrint);
            lng.s_lbl_ReportByPaymentMethod.Text(lbl_ReportByPaymentMethod);
            lng.s_lbl_Report_ByTaxiation.Text(lbl_Report_ByTaxiation);
            lng.s_lbl_FromInvoice.Text(lbl_Report_ByTaxiation);
            lng.s_lbl_ToInvoice.Text(lbl_ToInvoice);

            this.txt_CashierActivityNumber_Value.Text = ca.CashierActivityNumber.ToString();
            this.txt_NumberOfInvoices_Value.Text = ca.NumberOfInvoices.ToString();

            int iInvCount = ca.DocInvoice_ID_List.Count;
            if (iInvCount > 0)
            {
                this.txt_ToInvoice_Value.Visible = true;
                this.lbl_ToInvoice.Visible = true;
                this.txt_FromInvoice_Value.Text = Tangenta_DefaultPrintTemplates.TemplatesLoader.SetInvoiceNumber(ca.Atom_Office_ShortName,
                                                                                                                  ca.Atom_ElectronicDevice_Name,
                                                                                                                  ca.DocInvoice_ID_List[0].NumberInFinancialYear,
                                                                                                                  ca.DocInvoice_ID_List[0].FinancialYear,
                                                                                                                  ca.DocInvoice_ID_List[0].Storno,
                                                                                                                  lng.s_Storno.s
                                                                                                                  );
                int ilast = iInvCount - 1;
                this.txt_ToInvoice_Value.Text = Tangenta_DefaultPrintTemplates.TemplatesLoader.SetInvoiceNumber(ca.Atom_Office_ShortName,
                                                                                                                  ca.Atom_ElectronicDevice_Name,
                                                                                                                  ca.DocInvoice_ID_List[ilast].NumberInFinancialYear,
                                                                                                                  ca.DocInvoice_ID_List[ilast].FinancialYear,
                                                                                                                  ca.DocInvoice_ID_List[ilast].Storno,
                                                                                                                  lng.s_Storno.s);
            }
            else
            {
                this.txt_FromInvoice_Value.Text = lng.s_No_Issued_Invoices.s;
                this.txt_ToInvoice_Value.Visible = false;
                this.lbl_ToInvoice.Visible = false;
            }
            this.txt_CashierOpenedTime_Value.Text = LanguageControl.DynSettings.SetLanguageDateTimeString(ca.FirstLogin);
            this.txt_PersonWhoOpenedCashier_Value.Text = ca.CashierActivityOpened_Person(ca.CashierActivityOpened_ID);
            this.txt_NetPrice_Value.Text = LanguageControl.DynSettings.SetLanguageCurrencyString(ca.NetTotal, TangentaDB.GlobalData.BaseCurrency.DecimalPlaces, TangentaDB.GlobalData.BaseCurrency.Symbol);
            this.txt_TaxPrice_Value.Text = LanguageControl.DynSettings.SetLanguageCurrencyString(ca.TaxTotal, TangentaDB.GlobalData.BaseCurrency.DecimalPlaces, TangentaDB.GlobalData.BaseCurrency.Symbol);
            this.txt_Total_Value.Text = LanguageControl.DynSettings.SetLanguageCurrencyString(ca.Total, TangentaDB.GlobalData.BaseCurrency.DecimalPlaces, TangentaDB.GlobalData.BaseCurrency.Symbol);
            int ypos = 1;
            int idx = 1;
            this.pnl_Realisation_ByTaxRate.Controls.Clear();
            foreach (StaticLib.Tax tax in ca.TaxSum.TaxList )
            {
                decimal dtotal = tax.TaxableAmount * (1 + tax.Rate);
                usrc_TaxRateReport usrctreport = new usrc_TaxRateReport(tax.Name, tax.TaxableAmount, tax.TaxAmount, dtotal);
                usrctreport.Name = "usrc_TaxRateReport" + idx.ToString();
                usrctreport.Left = 1;
                usrctreport.Top = ypos;
                this.pnl_Realisation_ByTaxRate.Controls.Add(usrctreport);
                ypos += usrctreport.Height + 2;
                idx++;
            }
            ypos = 1;
            idx = 1;
            pnl_ByPayment.Controls.Clear();
            foreach (Report.PaymentType pt in ca.PaymentList.items)
            {
                usrc_MethotOfPaymentReport usrc_mopr = new usrc_MethotOfPaymentReport();
                usrc_mopr.Name = "usrc_MethotOfPaymentReport" + idx.ToString();
                usrc_mopr.Left = 1;
                usrc_mopr.Top = ypos;
                usrc_mopr.Init(pt);
                ypos += usrc_mopr.Height + 2;
                pnl_ByPayment.Controls.Add(usrc_mopr);
                idx++;
            }
        }

        private void btn_YES_Click(object sender, EventArgs e)
        {
            this.m_ca.Close(m_ca.Last_Atom_WorkPeriod_ID);
            if (this.Yes_Click != null)
            {
                this.Yes_Click();
            }
        }

        private void btn_NO_Click(object sender, EventArgs e)
        {
            if (this.No_Click != null)
            {
                this.No_Click();
            }
        }

        private void btn_YesPrint_Click(object sender, EventArgs e)
        {
            if (this.YesPrint_Click != null)
            {
                this.YesPrint_Click();
            }
        }
    }
}
