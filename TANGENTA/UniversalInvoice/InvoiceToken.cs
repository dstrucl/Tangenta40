#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion
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
        public TemplateToken tOfferValidUntil = null;
        public TemplateToken tPaymentType = null;
        public TemplateToken tPaymentToBankAccount = null;
        public TemplateToken tPaymentToBankName = null;
        public TemplateToken tSumNetPrice = null;
        public TemplateToken tTaxRateName = null;
        public TemplateToken tSumTax = null;
        public TemplateToken tTotalSum = null;
        public TemplateToken tStorno = null;
        public TemplateToken tNotice = null;
        public TemplateToken tCopyPrintInfo = null;


        public List<TemplateToken> list = null;

        public InvoiceToken(bool xbIsDocInvoice)
        {
            ltext ltDocInvoice = null;
            if (xbIsDocInvoice)
            {
                ltDocInvoice = lng.st_Invoice;
            }
            else
            {
                ltDocInvoice = lng.st_ProformaInvoice;
            }

        
            
            tFiscalYear = new TemplateToken(ltDocInvoice, lng.st_FiscalYear, null,null);
            tInvoiceNumber = new TemplateToken(ltDocInvoice, lng.st_Number, null,null);
            tCashier = new TemplateToken(ltDocInvoice, lng.st_Cashier, null, null);
            tIssuerOfInvoice = new TemplateToken(ltDocInvoice, lng.st_IssuerOfInvoice, null,null);


            tDateOfIssue = new TemplateToken(ltDocInvoice, lng.st_DateOfIssue, null,null);
            if (xbIsDocInvoice)
            {
                tOfferValidUntil = null;
                tDateOfMaturity = new TemplateToken(ltDocInvoice, lng.st_DateOfMaturity, null, null);
            }
            else
            {
                tDateOfMaturity = null;
                tOfferValidUntil = new TemplateToken(ltDocInvoice, lng.st_OfferValidUntil, null, null);
            }
        
            tPaymentType = new TemplateToken(ltDocInvoice, lng.st_PaymentType, null, null);
            tPaymentToBankAccount = new TemplateToken(ltDocInvoice, lng.st_PaymentToBankAccount, null, null);
            tPaymentToBankName = new TemplateToken(ltDocInvoice, lng.st_PaymentToBankName, null, null);


            tSumNetPrice = new TemplateToken(ltDocInvoice, lng.st_SumNetPrice, null, null);
            tTaxRateName = new TemplateToken(ltDocInvoice, lng.st_TaxRateName, null, null);
            tSumTax = new TemplateToken(ltDocInvoice, lng.st_SumTax, null, null);
            tTotalSum = new TemplateToken(ltDocInvoice, lng.st_TotalSum, null, null);

            if (xbIsDocInvoice)
            {
                tStorno = new TemplateToken(lng.st_Invoice, lng.st_Storno, null, null);
            }
            else
            {
                tStorno = null;
            }

            tNotice = new TemplateToken(ltDocInvoice, lng.st_Notice, null, null);
            tCopyPrintInfo = new TemplateToken(ltDocInvoice, lng.st_CopyPrintInfo, null, null);


            list = new List<TemplateToken>();
            list.Add(tFiscalYear);
            list.Add(tInvoiceNumber);
            list.Add(tCashier);
            list.Add(tIssuerOfInvoice);
            list.Add(tDateOfIssue);
            
            list.Add(tPaymentType);
            list.Add(tPaymentToBankAccount);
            list.Add(tPaymentToBankName);
            list.Add(tSumNetPrice);
            list.Add(tTaxRateName);
            list.Add(tSumTax);
            list.Add(tTotalSum);
            if (xbIsDocInvoice)
            {
                list.Add(tDateOfMaturity);
                list.Add(tStorno);
            }
            else
            {
                list.Add(tOfferValidUntil);
            }
            list.Add(tNotice);
            list.Add(tCopyPrintInfo);
        }
    }
}
