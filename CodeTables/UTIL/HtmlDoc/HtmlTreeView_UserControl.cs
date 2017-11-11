using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HtmlDoc
{
    public partial class HtmlTreeView_UserControl : UserControl
    {
        HtmlDoc m_htmdoc = null;
        public HtmlTreeView_UserControl()
        {
            InitializeComponent();
        }


        public void BuildTreeView(HtmlDoc html_doc)
        {
            trV_Html.Nodes.Clear();
            if (html_doc != null)
            {
                m_htmdoc = html_doc;

                AddNodes(ref m_htmdoc.shtml, m_htmdoc.Root);
                trV_Html.ExpandAll();
            }
        }

        private void AddNodes(ref string shtml, HtmlNode htmlNode)
        {
            TreeNode trn = trV_Html.Nodes.Add(GetHtmlNodeData(htmlNode, ref shtml));
            foreach (HtmlNode xnode in htmlNode.ChildList)
            {
                AddNode(trn, xnode, ref shtml);
            }

        }

        private void AddNode(TreeNode trn, HtmlNode xnode, ref string shtml)
        {
            TreeNode trn2 = new TreeNode(GetHtmlNodeData(xnode, ref shtml));
            trn.Nodes.Add(trn2);
            foreach (HtmlNode node in xnode.ChildList)
            {
                AddNode(trn2, node, ref shtml);
            }
        }

        private string GetHtmlNodeData(HtmlNode xnode, ref string shtml)
        {
            string s = "<" + xnode.Name + GetHtmlNodeAttributesData(xnode) + ">" + xnode.InnerHtml + "</" + xnode.Name + ">";
            return s;
        }

        private string GetHtmlNodeAttributesData(HtmlNode xnode)
        {
            string s = "";
            if (xnode.Atributes != null)
            {
                foreach (Attribute atr in xnode.Atributes.Items)
                {
                    s += " " + atr.Name + " = \"" + atr.Value + "\"";
                }
            }
            return s;
        }

    }
}
