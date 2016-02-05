using DBTypes;
using LanguageControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversalInvoice
{
    public class InvoiceToken
    {
        public TemplateToken tFiscalYear;
        public TemplateToken tInvoiceNumber;
        public TemplateToken tCashier;
        public TemplateToken tIssuerOfInvoice;
        public TemplateToken tDateOfIssue = null;
        public TemplateToken tDateOfMaturity = null;
        public TemplateToken tPaymentType = null;
        public TemplateToken tSumNetPrice = null;
        public TemplateToken tTaxRateName = null;
        public TemplateToken tSumTax = null;
        public TemplateToken tTotalSum = null;

        public TemplateToken tNotice = null;
        public TemplateToken tFooter = null;

        public List<TemplateToken> list = null;

        public InvoiceToken()
        {
            tFiscalYear = new TemplateToken(lngToken.st_Invoice, lngToken.st_FiscalYear, null,null);
            tInvoiceNumber = new TemplateToken(lngToken.st_Invoice, lngToken.st_Number, null,null);
            tCashier = new TemplateToken(lngToken.st_Invoice, lngToken.st_Cashier, null, null);
            tIssuerOfInvoice = new TemplateToken(lngToken.st_Invoice, lngToken.st_IssuerOfInvoice, null,null);


            tDateOfIssue = new TemplateToken(lngToken.st_Invoice, lngToken.st_DateOfIssue, null,null);
            tDateOfMaturity = new TemplateToken(lngToken.st_Invoice, lngToken.st_DateOfMaturity, null, null);
            tPaymentType = new TemplateToken(lngToken.st_Invoice, lngToken.st_PaymentType, null, null);


            tSumNetPrice = new TemplateToken(lngToken.st_Invoice, lngToken.st_SumNetPrice, null, null);
            tTaxRateName = new TemplateToken(lngToken.st_Invoice, lngToken.st_TaxRateName, null, null);
            tSumTax = new TemplateToken(lngToken.st_Invoice, lngToken.st_SumTax, null, null);
            tTotalSum = new TemplateToken(lngToken.st_Invoice, lngToken.st_TotalSum, null, null);

            tNotice = new TemplateToken(lngToken.st_Invoice, lngToken.st_Notice, null, null);
            tFooter = new TemplateToken(lngToken.st_Invoice, lngToken.st_Footer, null, null);

            list = new List<TemplateToken>();
            list.Add(tFiscalYear);
            list.Add(tInvoiceNumber);
            list.Add(tCashier);
            list.Add(tIssuerOfInvoice);
            list.Add(tDateOfIssue);
            list.Add(tDateOfMaturity);
            list.Add(tPaymentType);
            list.Add(tSumNetPrice);
            list.Add(tTaxRateName);
            list.Add(tSumTax);
            list.Add(tTotalSum);
            list.Add(tNotice);
            list.Add(tFooter);
        }
    }
}
