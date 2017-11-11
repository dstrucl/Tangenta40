using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HtmlDoc
{
    public class HtmlDoc
    {
        public delegate string deleagate_GetInnerHtml(int pos_start, int pos_end);
        public HtmlNode Root = null;
        public string shtml = null;

        public string Content;

        public HtmlDoc(string xhtml)
        {
            shtml = xhtml;
            Root = new HtmlNode(null, GetInnerHtml);
        }

        public bool Parse(ref List<string> ErrList)
        {
            int ipos = 0;
            string EndNodeName = null;
            int iMissingTagLevel = 0;
            int iMissingTagLevel_on_new_Tag = 0;


            return Root.GetNode(ref shtml, ipos, ref EndNodeName,ref iMissingTagLevel,ref iMissingTagLevel_on_new_Tag, ref ErrList);
        }

        public string GetInnerHtml(int pos_start, int pos_end)
        {
            if ((pos_start >= 0) && (pos_end > 0))
            {
                if (pos_end > pos_start)
                {
                    return shtml.Substring(pos_start, pos_end - pos_start);
                }
            }
            return "";
        }

        public void GetNodesWithName(HtmlNode parent_node, ref List<HtmlNode> node_list, string[] names)
        {
            foreach (HtmlNode node in parent_node.ChildList)
            {
                if (IsIn(node.Name, names))
                {
                    node_list.Add(node);
                }
                GetNodesWithName(node, ref node_list, names);
            }
        }


        public void GetNodesWithAttributes(HtmlNode parent_node, ref List<HtmlNode> node_list, string atr_name, string[] atr_values)
        {
            foreach (HtmlNode node in parent_node.ChildList)
            {
                if (node.Atributes != null)
                {
                    foreach (Attribute atribute in node.Atributes.Items)
                    {
                        if (atribute.Name.Equals(atr_name))
                        {
                            if (IsIn(atribute.Value, atr_values))
                            {
                                // this node is matching condition
                                node_list.Add(node);
                            }
                        }
                    }
                }
                GetNodesWithAttributes(node, ref node_list, atr_name, atr_values);
            }
        }


        public HtmlNode[] GetNodesWithAttributes(string atr_name, string[] atr_values)
        {
            List<HtmlNode> node_list = new List<HtmlNode>();
            GetNodesWithAttributes(Root, ref node_list, atr_name, atr_values);
            int iCount = node_list.Count;
            if (iCount > 0)
            {
                HtmlNode[] nodes = new HtmlNode[iCount];
                int i;
                for (i = 0; i < iCount; i++)
                {
                    nodes[i] = node_list[i];
                }
                return nodes;
            }
            else
            {
                return null;
            }
        }


        private bool IsIn(string name, string[] class_name)
        {
            foreach (string s in class_name)
            {
                if (s.Equals(name,StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }
                    
    }
}
