using LanguageControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversalInvoice
{
    public class TemplateToken
    {
        public string replacement;
        public ltext lt = null;
        public TemplateToken(ltext token_prefix,string[] TokenInLanguage, string Replacement)
        {
            lt = new ltext();
            lt.sText = TokenInLanguage;
            if (token_prefix != null)
            {
                int i = 0;
                int iCount = lt.sText.Length;
                for (i = 0; i < iCount; i++)
                {
                    if (TokenInLanguage[i] != null)
                    {
                        if (TokenInLanguage[i].Length > 3)
                        {
                            TokenInLanguage[i] = TokenInLanguage[i].Insert(2, token_prefix.sText[i]);
                        }
                    }
                }
            }
            replacement = Replacement;
        }

        internal void Set(string v)
        {
            replacement = v;
        }
    }
}
