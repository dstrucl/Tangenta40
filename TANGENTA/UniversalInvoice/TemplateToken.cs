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
        public const string START_TAG = "(@@";
        public const string END_TAG = "@@)";
        public string replacement;
        public ltext lt = null;

        public TemplateToken(ltext token_prefix, ltext TokenInLanguage, object Replacement, string sFormat)
        {
            lt = new ltext();
            lt.sText(TokenInLanguage);
            if (token_prefix != null)
            {
                int i = 0;
                int iCount = lt.sText_Length;
                for (i = 0; i < iCount; i++)
                {
                    if (TokenInLanguage.sText(i) != null)
                    {
                        if (TokenInLanguage.sText(i).Contains(START_TAG))
                        {
                            continue;
                        }
                        else
                        { 
                            string token = null;
                            token = START_TAG + token_prefix.sText(i) + "_" + TokenInLanguage.sText(i)+ END_TAG;
                            lt.sText(i,token);
                        }
                    }
                }
            }
            else
            {
                int i = 0;
                int iCount = lt.sText_Length;
                for (i = 0; i < iCount; i++)
                {
                    if (TokenInLanguage.sText(i) != null)
                    {
                        if (TokenInLanguage.sText(i).Contains(START_TAG))
                        {
                            continue;
                        }
                        else
                        {
                            string token = null;
                            token = START_TAG + TokenInLanguage.sText(i) + END_TAG;
                            lt.sText(i,token);
                        }
                    }
                }
            }

            if (Replacement is string)
            {
                replacement = (string) Replacement;
            }
            else if (Replacement is int)
            {
                replacement = Convert.ToString(Replacement);
            }
            else if (Replacement is DateTime)
            {
                DateTime time = (DateTime)Replacement;
                if (sFormat != null)
                {
                    if (sFormat.Equals("YYYY-MM-DD"))
                    {
                        replacement = GetString(time.Year, 4) + "-" + GetString(time.Month, 2) + "-" + GetString(time.Day, 2);
                    }
                }
            }
        }


        public TemplateToken(ltext token_prefix, string[] TokenInLanguage, object Replacement, string sFormat)
        {
            lt = new ltext();
            lt.sText(TokenInLanguage);
            if (token_prefix != null)
            {
                int i = 0;
                int iCount = lt.sText_Length;
                for (i = 0; i < iCount; i++)
                {
                    if (i < TokenInLanguage.Length)
                    {
                        if (TokenInLanguage[i] != null)
                        {
                            if (TokenInLanguage[i].Contains(START_TAG))
                            {
                                continue;
                            }
                            else
                            {
                                string token = null;
                                token = START_TAG + token_prefix.sText(i) + "_" + TokenInLanguage[i] + END_TAG;
                                lt.sText(i, token);
                            }
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }
            else
            {
                int i = 0;
                int iCount = lt.sText_Length;
                for (i = 0; i < iCount; i++)
                {
                    if (i < TokenInLanguage.Length)
                    {
                        if (TokenInLanguage[i] != null)
                        {
                            if (TokenInLanguage[i].Contains(START_TAG))
                            {
                                continue;
                            }
                            else
                            {
                                string token = null;
                                token = START_TAG + TokenInLanguage[i] + END_TAG;
                                lt.sText(i, token);
                            }
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }

            if (Replacement is string)
            {
                replacement = (string)Replacement;
            }
            else if (Replacement is int)
            {
                replacement = Convert.ToString(Replacement);
            }
            else if (Replacement is DateTime)
            {
                DateTime time = (DateTime)Replacement;
                if (sFormat != null)
                {
                    if (sFormat.Equals("YYYY-MM-DD"))
                    {
                        replacement = GetString(time.Year, 4) + "-" + GetString(time.Month, 2) + "-" + GetString(time.Day, 2);
                    }
                }
            }
        }


        public string GetString(int i, int places)
        {
            string s = i.ToString();
            while (s.Length<places)
            {
                s = '0' + s;
            }
            return s;
        }

        public void Set(string v)
        {
            replacement = v;
        }

        public string Replace(string html_doc_template)
        {
            if (html_doc_template.Contains(lt.s))
            {
                return html_doc_template.Replace(lt.s, this.replacement);
            }
            else
            {
                //replace if token is written in other languages
                int i = 0;
                int iCount = lt.sText_Length;
                for (i = 0; i < iCount; i++)
                {
                    if (i == DynSettings.LanguageID)
                    {
                        continue;
                    }
                    string sx = lt.sText(i);
                    if (sx != null)
                    {
                        if (html_doc_template.Contains(sx))
                        {
                            return html_doc_template.Replace(sx, this.replacement);
                        }
                    }
                }
                return html_doc_template;
            }
        }
    }
}
