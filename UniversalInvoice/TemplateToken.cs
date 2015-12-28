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
        public TemplateToken(ltext token_prefix,string[] TokenInLanguage, object Replacement)
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
                            string token = null;
                            if (token_prefix!= null)
                            {
                                token = "@@" + token_prefix.sText[i] + TokenInLanguage[i];
                            }
                            else
                            {
                                token = "@@" + TokenInLanguage[i];
                            }
                        }
                    }
                }
            }

            if (Replacement is string)
            {
                replacement = (string) Replacement;
            }
            else
            {
                replacement = null;
            }
        }

        internal void Set(string v)
        {
            replacement = v;
        }
    }
}
