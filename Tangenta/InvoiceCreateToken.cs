using LanguageControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tangenta
{
    public class InvoiceCreateToken
    {
        public string replacement;
        public ltext lt = null;
        public InvoiceCreateToken(string[] TokenInLanguage, string Replacement)
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
