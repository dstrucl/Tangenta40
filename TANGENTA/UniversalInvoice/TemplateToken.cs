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

            if (Replacement is bool_v)
            {
                if (Replacement != null)
                {
                    if (((bool_v)Replacement).v)
                    {
                        replacement = lngRPM.s_Yes.s;
                    }
                    else
                    {
                        replacement = lngRPM.s_No.s;
                    }
                }
                else
                {
                    replacement = "";
                }
            }            
            else if (Replacement is string)
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
            else if (Replacement is byte[])
            {
                //replace byte with Base64 string!
                string base64String = Convert.ToBase64String((byte[])Replacement);
                replacement = base64String;
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

        private string XReplace(ref string html_doc_template, string sx, string replacement)
        {
            string xreplacement = replacement;
            if (xreplacement == null)
            {
                xreplacement = "";
            }
            if (xreplacement.Length == 0)
            {
                if (sx.Contains("(@@@"))
                {
                    string StartTag = "";
                    int isx = html_doc_template.IndexOf(sx);
                    int iStartTagEnd = FindStartTag(ref html_doc_template, ref StartTag, isx);
                    int iEndTagStart = 0;
                    if (iStartTagEnd >= 0)
                    {
                        iEndTagStart = FindEndTag(isx, ref html_doc_template, StartTag);
                        if (iEndTagStart > 0)
                        {
                            string FirstPart = html_doc_template.Substring(0, iStartTagEnd);
                            string SecondPart = html_doc_template.Substring(iEndTagStart);
                            string sAll = FirstPart + SecondPart;
                            return FirstPart + SecondPart;
                        }
                    }
                }
                else
                {
                    return html_doc_template.Replace(sx, xreplacement);
                }
            }
            return html_doc_template.Replace(sx, xreplacement);
        }

        private int FindEndTag(int isx,ref string html_doc_template, string StartTag)
        {
            string EndTag = "</"+StartTag.Substring(1);
            int iTag = isx + 1;
            int iTagEnd = -1;
            iTag = html_doc_template.IndexOf(EndTag, iTag);
            if (iTag > 0)
            {
                iTagEnd = html_doc_template.IndexOf('>', iTag);
                if (iTagEnd>0)
                {
                    iTagEnd = iTagEnd + 1;
                }

            }
            return iTagEnd;
            
        }

        private int FindStartTag(ref string html_doc_template,ref string StartTag,int isx)
        {
            while (isx > 0)
            {
                isx--;
                if (html_doc_template[isx] == '>')
                {
                    StartTag = GetBackStartTag(ref html_doc_template,ref isx);
                    if (StartTag.Contains("<b")
                        || StartTag.Contains("<span")
                        || StartTag.Contains("<br")
                        || StartTag.Contains("<a")
                        )
                    {
                        continue;
                    }
                    else
                    {
                        int idelimiter = StartTag.IndexOfAny(new char[] { ' ', '>' });
                        if (idelimiter > 0)
                        {
                            StartTag = StartTag.Substring(0, idelimiter);
                        }
                        return isx;
                    }
                }
            }
            return -1;
        }

        private string GetBackStartTag(ref string html_doc_template, ref int isx)
        {
            int iEndStartTag = isx;
            int iStartStartTag = isx;
            while (isx > 0)
            {
                isx--;
                if (html_doc_template[isx] == '<')
                {
                    iStartStartTag = isx;
                    string sStartTag = html_doc_template.Substring(iStartStartTag, iEndStartTag - iStartStartTag);
                    return sStartTag;
                }
            }
            return null;
        }

        public int IndexOf(string s, ref int length)
        {
            int index = s.IndexOf(lt.s);
            if (index>=0)
            {
                length = lt.s.Length;
                return index;
                
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
                        index = s.IndexOf(sx);
                        if (index >=0)
                        {
                            length = sx.Length;
                            return index;
                        }
                    }
                }
                return index;
            }
        }
    }
}
