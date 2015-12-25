using LanguageControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XML_or_HTML_invoice_from_template
{
    public class InvoiceTemplateToken
    {
        public string replacement;
        public ltext lt = null;
        public InvoiceTemplateToken(string[] TokenInLanguage, string Replacement)
        {
            lt = new ltext();
            lt.sText = TokenInLanguage;
            replacement = Replacement;
        }

        internal void Set(string v)
        {
            replacement = v;
        }
    }
}
