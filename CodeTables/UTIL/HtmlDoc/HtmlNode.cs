using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HtmlDoc
{
    public class HtmlNode
    {
        public const string const_SCRIPT = "SCRIPT";
        public const string const_SCRIPT_END = "</SCRIPT";
        internal HtmlDoc.deleagate_GetInnerHtml GetInnerHtml = null;
        public bool bVoidElement = false;
        public enum Tag_TYPE { START, END };
        public enum eNodeStatus { OPENED, CLOSED_OK, CLOSED_BY_WRONG_END_TAG_TYPE, CLOSED_BY_NEXT_START_TAG_TYPE };

        public HtmlNode Parent = null;
        public Attributes Atributes;
        public List<HtmlNode> ChildList = new List<HtmlNode>();
        public int ipos_node_start = -1;
        public int ipos_node_end = -1;
        public int ipos_start = -1;
        public int ipos_end = -1;
        public int ipos_end_Content = -1;
        public eNodeStatus m_eNodeStatus = eNodeStatus.OPENED;
        public string Name = null;

    public string InnerHtml
        {
            get
            {
                return GetInnerHtml(ipos_start, ipos_end_Content);
            }
        }

        public string NodeHtml
        {
            get
            {
                return GetInnerHtml(ipos_node_start, ipos_node_end);
            }
        }

        public HtmlNode(HtmlNode xParent, HtmlDoc.deleagate_GetInnerHtml xGetInnerHtml)
        {
            Parent = xParent;
            GetInnerHtml = xGetInnerHtml;
            m_eNodeStatus = eNodeStatus.OPENED;
        }

        public bool GetNode(ref string shtml, int ipos, ref string EndTokenName, ref int iMissingTagLevel, ref int iMissingTagLevel_on_new_Tag, ref List<string> ErrorList)
        {
            string node_Name = null;
            string Err = null;

            Tag_TYPE eTagType = Tag_TYPE.START;
            int my_ipos_node_start = -1;

            int idx_tag = FindTag(ref shtml, ipos, ref my_ipos_node_start, ref eTagType);

            if (my_ipos_node_start >= 0)
            {
                ipos_node_start = my_ipos_node_start;

                int pstart = my_ipos_node_start+1;
                bool bEnd = false;
                string preview_Name = null;
                if (GetToken(ref shtml, ref pstart, ref preview_Name, ref bEnd))
                {
                    string[] table_tags_td = new string[] { "td"};
                    if (IsIn(preview_Name, table_tags_td))
                    {
                        int iMissingTagLevel_On_TD_Tag = MissingTagLevel_On_TD_Tag(this, table_tags_td);
                        if (iMissingTagLevel_On_TD_Tag > 0)
                        {
                            iMissingTagLevel_on_new_Tag = iMissingTagLevel_On_TD_Tag;
                            Err = "MissingTagLevel_On_TD_Tag ipos=" + ipos.ToString();
                            ErrorList.Add(Err);
                            return true;
                        }
                    }
                    string[] table_tags_tr = new string[] { "tr" };
                    if (IsIn(preview_Name, table_tags_tr))
                    {
                        int iMissingTagLevel_On_TD_Tag = MissingTagLevel_On_TD_Tag(this, table_tags_tr);
                        if (iMissingTagLevel_On_TD_Tag > 0)
                        {
                            iMissingTagLevel_on_new_Tag = iMissingTagLevel_On_TD_Tag;
                            Err = "MissingTagLevel_On_TD_Tag ipos=" + ipos.ToString();
                            ErrorList.Add(Err);
                            return true;
                        }
                    }
                }
              
                
            }

            if (idx_tag > 0)
            {
                if (eTagType == Tag_TYPE.END)
                {
                    bool bEnd = false;
                    if (GetToken(ref shtml, ref idx_tag, ref EndTokenName, ref bEnd))
                    {
                        ipos_end = idx_tag;
                        ipos_end_Content = idx_tag - 2;
                        return true;
                    }
                    else
                    {
                        Err = "End Token not found for Tag_TYPE.END";
                        ErrorList.Add(Err);
                        return false;
                    }
                }
                ipos = idx_tag;
                if (GetNodeParams(ref shtml, ipos, ref node_Name, ref Atributes, ref Err))
                {

                    if (node_Name.Equals(const_SCRIPT))
                    {
                        this.Name = node_Name;

                        int idx_end_Script = shtml.IndexOf(const_SCRIPT_END,ipos);
                        if (idx_end_Script > 0)
                        {
                            ipos_end = idx_end_Script + const_SCRIPT_END.Length;
                            ipos_end_Content = idx_end_Script;
                            ipos_node_end = ipos_end;
                            EndTokenName = null;
                            return true;
                        }
                        else
                        {
                            Err = "ERROR:Missing script end:" + const_SCRIPT_END;
                            ErrorList.Add(Err);
                            return false;
                        }
                    }
                    else
                    {
                        this.Name = node_Name;
                        if (IsVoidElement(node_Name))
                        {
                            ipos_end = ipos_start;
                            bVoidElement = true;
                            return true;
                        }
                        else
                        {
                            int subnote_pos = this.ipos_start;

                            while (true)
                            {
                                HtmlNode node = new HtmlNode(this, this.GetInnerHtml);
                                string sNewEndToken = null;
                                int iNewMissingTagLevel = 0;
                                int iNewMissingTagLevel_on_new_Tag = 0;
                                if (node.GetNode(ref shtml, subnote_pos, ref sNewEndToken,ref iNewMissingTagLevel,ref iNewMissingTagLevel_on_new_Tag, ref ErrorList))
                                {
                                    if (Err == null)
                                    {
                                        if (sNewEndToken != null)
                                        {
                                            //if (node_Name.Equals(sEndToken, StringComparison.OrdinalIgnoreCase))
                                            if (node_Name.Equals(sNewEndToken, StringComparison.OrdinalIgnoreCase))
                                            {
                                                ipos_end = node.ipos_end;
                                                ipos_end_Content = ipos_end - sNewEndToken.Length - 3;
                                                ipos_node_end = ipos_end;
                                                m_eNodeStatus = eNodeStatus.CLOSED_OK;
                                                return true;
                                            }
                                            else
                                            {
                                                // wrong End Tag;
                                                ipos_end = node.ipos_end;
                                                ipos_end_Content = ipos_end - sNewEndToken.Length - 3;
                                                ipos_node_end = ipos_end;
                                                m_eNodeStatus = eNodeStatus.CLOSED_BY_WRONG_END_TAG_TYPE;
                                                int iTagLevel = MissingTagLevel(this, sNewEndToken);

                                                int ilerr = node.ipos_end - this.ipos_node_start;
                                                if (ilerr > 0)
                                                {
                                                    Err = "End token mismatch > 0:\r\n" + shtml.Substring(this.ipos_node_start, ilerr) + "\r\n##\r\n End Token found = " + sNewEndToken;
                                                }
                                                else
                                                {
                                                    Err = "End token mismatch <=0:\r\n" + shtml.Substring(this.ipos_node_start) + "\r\n##\r\n End Token found = " + sNewEndToken;
                                                }
                                                ErrorList.Add(Err);

                                                if (iTagLevel > 0)
                                                {
                                                    iMissingTagLevel = iTagLevel;
                                                    return true;
                                                }

                                                return false;
                                            }
                                        }
                                        else if (iNewMissingTagLevel > 0)
                                        {
                                            iNewMissingTagLevel--;
                                            iMissingTagLevel = iNewMissingTagLevel;
                                            ipos_end = node.ipos_end;
                                            ipos_end_Content = node.ipos_end_Content;
                                            ipos_node_end = ipos_end;
                                            m_eNodeStatus = eNodeStatus.CLOSED_BY_WRONG_END_TAG_TYPE;
                                            ChildList.Add(node);
                                            return true;
                                        }
                                        else if (iNewMissingTagLevel_on_new_Tag > 0)
                                        {
                                            iNewMissingTagLevel_on_new_Tag--;
                                            iMissingTagLevel_on_new_Tag = iNewMissingTagLevel_on_new_Tag;
                                            ipos_end = node.ipos_node_start;
                                            ipos_end_Content = node.ipos_node_start;
                                            ipos_node_end = ipos_end;
                                            m_eNodeStatus = eNodeStatus.CLOSED_BY_NEXT_START_TAG_TYPE;
                                            return true; 
                                        }

                                        ChildList.Add(node);
                                    }
                                    else
                                    {
                                        return false;
                                    }
                                    subnote_pos = node.ipos_end;
                                }
                                else
                                {
                                    ipos = subnote_pos;
                                    return true;
                                }
                            }
                        }
                    }
                }
                else
                {
                    Err = "ERROR: No node data";
                    ErrorList.Add(Err);
                    return false;
                }
            }
            else
            {
                return true;
            }
        }

        private int MissingTagLevel_On_TD_Tag(HtmlNode htmlNode, string[] sTokens)
        {
            int iNodeLevel = 0;
            HtmlNode html_node = htmlNode.Parent;
            while (html_node != null)
            {
                iNodeLevel++;
                if (IsIn(html_node.Name,sTokens))
                {
                    if (html_node.m_eNodeStatus == eNodeStatus.OPENED)
                    {
                        // close node
                        html_node.m_eNodeStatus = eNodeStatus.CLOSED_BY_NEXT_START_TAG_TYPE;
                        return iNodeLevel;
                    }
                    else
                    {
                        return 0;
                    }
                }
                if (iNodeLevel == 1) // limit this logic on level 1! to just previous line!
                {
                    return 0;
                }
                html_node = html_node.Parent;
            }
            return 0;
        }


        private int MissingTagLevel(HtmlNode htmlNode, string sNewEndToken)
        {
            int iNodeLevel = 0;
            HtmlNode html_node = htmlNode.Parent;
            while (html_node != null)
            {
                iNodeLevel++;
                if (html_node.Name.Equals(sNewEndToken, StringComparison.OrdinalIgnoreCase))
                {
                    return iNodeLevel;
                }
                html_node = html_node.Parent;
            }
            return iNodeLevel;
        }

        private bool IsIn(string name, string[] class_name)
        {
            foreach (string s in class_name)
            {
                if (s.Equals(name, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }

        private bool IsVoidElement(string Name)
        {
            string[] vElements = new string[] { "area", "base", "br", "col", "command", "embed", "hr", "img", "input", "keygen", "link", "meta", "param", "source", "track", "wbr" };
            string slwrName = Name.ToLower();
            bool bRet = vElements.Contains(slwrName);
            return bRet;
        }

        private bool GetNodeParams(ref string shtml, int ipos, ref string Name, ref Attributes atributes, ref string Err)
        {
            int pstart = ipos;
            bool bEnd = false;
            if (GetToken(ref shtml, ref pstart, ref Name, ref bEnd))
            {
                if (bEnd)
                {
                    ipos_start = pstart;
                    return true;
                }
                string atr = null;
                string atr_value = "";
                while (GetToken(ref shtml, ref pstart, ref atr, ref bEnd))
                {
                    GetToken(ref shtml, ref pstart, ref atr_value, ref bEnd);
                    Attribute atribute = new Attribute(atr, atr_value);
                    if (atributes == null)
                    {
                        atributes = new Attributes();
                    }
                    atributes.Items.Add(atribute);
                    if (bEnd)
                    {
                        ipos_start = pstart;
                        return true;
                    }
                }
                ipos_start = pstart;
                return true;
            }
            else
            {
                Err = "ERROR:Node Name Not Found!";
                return false;
            }
        }

        private bool GetToken(ref string shtml, ref int xpos, ref string stoken, ref bool bEnd)
        {
            bEnd = false;
            string sValue = "";
            int i = 0;
            if (xpos < shtml.Length)
            {
                string s = shtml.Substring(xpos);
                int iLen = s.Length;
                bool bTokenFound = false;
                bool bApostroph = false;

                for (i = 0; i < iLen; i++)
                {
                    char c = s[i];
                    if (!bTokenFound)
                    {
                        if (c == '"')
                        {
                            bTokenFound = true;
                            bApostroph = true;
                            xpos++;
                        }
                        else
                        {
                            if (c == '>')
                            {
                                bEnd = true;
                                stoken = sValue;
                                xpos++;
                                return false;
                            }
                            else
                            {
                                if (IsDelimiter(c))
                                {
                                    xpos++;
                                    continue;
                                }
                                else
                                {
                                    bTokenFound = true;
                                    sValue += c;
                                    xpos++;
                                }
                            }
                        }
                    }
                    else
                    {
                        if (bApostroph)
                        {
                            if (c == '"')
                            {
                                xpos++;
                                stoken = sValue;
                                return true;
                            }
                            else
                            {
                                sValue += c;
                                xpos++;
                            }
                        }
                        else
                        {
                            if (c == '>')
                            {
                                bEnd = true;
                                stoken = sValue;
                                xpos++;
                                return true;
                            }
                            else
                            {
                                if (IsDelimiter(c))
                                {
                                    stoken = sValue;
                                    xpos++;
                                    return true;
                                }
                                else
                                {
                                    sValue += c;
                                    xpos++;
                                }
                            }
                        }
                    }
                }
                stoken = sValue;
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool IsDelimiter(char c)
        {
            return ((c == ' ') || (c == '='));
        }


        private int FindTag(ref string shtml, int xpos, ref int node_start_pos, ref Tag_TYPE eTagType)
        {
            int idx = shtml.IndexOf("<", xpos, StringComparison.OrdinalIgnoreCase);

            while (idx >= 0)
            {
                string stoken = shtml.Substring(idx, 2);
                if (stoken.Equals("</"))
                {
                    idx++;
                    idx++;
                    eTagType = Tag_TYPE.END;
                    return idx;
                }
                else if (!stoken.Equals("<!"))
                {
                    node_start_pos = idx;
                    idx++;
                    eTagType = Tag_TYPE.START;
                    return idx;
                }
                else
                {
                    idx++;
                    idx = shtml.IndexOf("<", idx, StringComparison.OrdinalIgnoreCase);
                }
            }
            return -1;
        }


    }
}
