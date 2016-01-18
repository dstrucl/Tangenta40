using LanguageControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversalInvoice
{
    public class Invoice_FURS_Token
    {
        public TemplateToken tUniqueMessageID;
        public TemplateToken tUniqueInvoiceID;
        public TemplateToken tQR;

        public List<TemplateToken> list = null;

        public Invoice_FURS_Token()
        {
            tUniqueMessageID = new TemplateToken(lngToken.st_Invoice, lngToken.st_UniqueMessageID.sText, null, null);
            tUniqueInvoiceID = new TemplateToken(lngToken.st_Invoice, lngToken.st_UniqueInvoiceID.sText, null, null);
            tQR = new TemplateToken(lngToken.st_Invoice, lngToken.st_QR.sText, null, null);

            list = new List<TemplateToken>();
            list.Add(tUniqueMessageID);
            list.Add(tUniqueInvoiceID);
            list.Add(tQR);
        }

    }
}
