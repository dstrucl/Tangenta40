using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheArtOfDev.HtmlRenderer.Core.Dom;

namespace TheArtOfDev.HtmlRenderer.Core
{
    public class PageLayout
    {
        public Adapters.Entities.RRect HtmlTagRect;
        public string html_tag_name = null;
        public Dictionary<string, string> dictionary = null;
        public List<PageLayout> Child_HtmlTag_PageLayout = null;

        public List<PageLayout> ItemList
        {
            get { if (html_tag_name.Equals("tbody"))
                  {
                    return Child_HtmlTag_PageLayout;
                  }
                  else
                  {
                    if (Child_HtmlTag_PageLayout != null)
                    {
                        foreach (PageLayout pgl in Child_HtmlTag_PageLayout)
                        {
                            List<PageLayout> list = pgl.ItemList;
                            if (list!=null)
                            {
                                return list;
                            }
                        }
                        return null;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }

        internal void Set(CssBox box)
        {
            if (box!=null)
            {
                if (box.HtmlTag != null)
                {
                   html_tag_name = box.HtmlTag.Name;
                   dictionary = box.HtmlTag.Attributes;
                }
              
                HtmlTagRect = new Adapters.Entities.RRect(-1, -1, 0, 0);
                box.GetHtmlTagRect(box,ref HtmlTagRect);
             }
        }

        public bool OnePageSize(double PageHeight,double TopMargin,double BottomMargin)
        {
            if (html_tag_name != null)
            {
                if (html_tag_name.Equals("body"))
                {
                    double PrintableAreaHeight = PageHeight - TopMargin - BottomMargin;
                    if (HtmlTagRect.Height <= PrintableAreaHeight)
                    {
                        return true;
                    }
                }
            }
            else
            {
                foreach(PageLayout pgl in Child_HtmlTag_PageLayout)
                {
                    if (pgl.OnePageSize(PageHeight, TopMargin, BottomMargin))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
