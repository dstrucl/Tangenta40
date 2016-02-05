#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion
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
            tUniqueMessageID = new TemplateToken(lngToken.st_Invoice, lngToken.st_UniqueMessageID, null, null);
            tUniqueInvoiceID = new TemplateToken(lngToken.st_Invoice, lngToken.st_UniqueInvoiceID, null, null);
            tQR = new TemplateToken(lngToken.st_Invoice, lngToken.st_QR, null, null);

            list = new List<TemplateToken>();
            list.Add(tUniqueMessageID);
            list.Add(tUniqueInvoiceID);
            list.Add(tQR);
        }

    }
}
