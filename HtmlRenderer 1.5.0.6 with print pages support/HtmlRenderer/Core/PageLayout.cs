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

        public string ClassName
                { get
                    {
                        if (this.dictionary != null)
                        {
                            if (this.dictionary.ContainsKey("class"))
                            {
                                return this.dictionary["class"];
                            }
                        }
                        return null;
                    }
                }

        public List<PageLayout> ItemList(string html_tag_name)
        {
            if (html_tag_name.Equals(html_tag_name))
            {
                return Child_HtmlTag_PageLayout;
                }
                else
                {
                if (Child_HtmlTag_PageLayout != null)
                {
                    foreach (PageLayout pgl in Child_HtmlTag_PageLayout)
                    {
                        List<PageLayout> list = pgl.ItemList(html_tag_name);
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

        public void GetPageLayout(string xhtml_tag_name, string class_name, ref List<PageLayout> taxSumPageLayout_list)
        {
            if (IsHtmlElementOfClassName(xhtml_tag_name, class_name))
            {
                if (taxSumPageLayout_list==null)
                {
                    taxSumPageLayout_list = new List<PageLayout>();
                }
                taxSumPageLayout_list.Add(this);
            }
            if (Child_HtmlTag_PageLayout != null)
            {
                foreach (PageLayout pgl in Child_HtmlTag_PageLayout)
                {
                    pgl.GetPageLayout(xhtml_tag_name, class_name, ref taxSumPageLayout_list);
                }
            }
        }

        public void GetElementsCount(string xhtml_tag_name, string[] classes,ref int iCount)
        {
            int i = iCount;
            if (IsHtmlElementOfClassesName(xhtml_tag_name, classes))
            {
                iCount++;
            }
            else if (Child_HtmlTag_PageLayout != null)
            {
                foreach (PageLayout pgl in Child_HtmlTag_PageLayout)
                {
                    pgl.GetElementsCount(xhtml_tag_name, classes,ref iCount);
                }
            }
        }


        public bool SetElementLayout(string xhtml_tag_name, string class_name,ref string xTagName,ref string xClassName, ref double Y, ref double height)
        {
            if (IsHtmlElementOfClassName(xhtml_tag_name, class_name))
            {
                xTagName = xhtml_tag_name;
                xClassName = class_name;
                Y = this.HtmlTagRect.Y;
                height = this.HtmlTagRect.Height;
                return true;
            }
            else
            {
                if (Child_HtmlTag_PageLayout != null)
                {
                    foreach (PageLayout pgl in Child_HtmlTag_PageLayout)
                    {
                        if (pgl.SetElementLayout(xhtml_tag_name, class_name,ref xTagName,ref xClassName,ref Y, ref height))
                        { 
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        private bool IsHtmlElementOfTagName(string xhtml_tag_name)
        {
            if (this.html_tag_name != null)
            {
                if (this.html_tag_name.Equals(xhtml_tag_name))
                {
                    return true;
                }
            }
            return false;
        }

    private bool IsHtmlElementOfClassesName(string xhtml_tag_name, string[] xclasses_name)
    {
        if (this.html_tag_name != null)
        {
            if (this.html_tag_name.Equals(xhtml_tag_name))
            {
                if (this.dictionary != null)
                {
                    if (this.dictionary.ContainsKey("class"))
                    {
                        string dclass = this.dictionary["class"];
                        if (dclass != null)
                        {
                            foreach (string xclass_name in xclasses_name)
                            {
                                if (dclass.Equals(xclass_name))
                                {
                                    return true;
                                }
                            }
                        }
                    }
                }
            }
        }
        return false;
    }

    private bool IsHtmlElementOfClassName(string xhtml_tag_name, string xclass_name)
        {
            if (this.html_tag_name!=null)
            {
                if (this.html_tag_name.Equals(xhtml_tag_name))
                {
                    if (this.dictionary != null)
                    {
                        if (this.dictionary.ContainsKey("class"))
                        {
                            string dclass = this.dictionary["class"];
                            if (dclass != null)
                            {
                                if (dclass.Equals(xclass_name))
                                {
                                    return true;
                                }
                            }
                        }
                    }
                }
            }
            return false;
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
                if (html_tag_name.Equals("html"))
                {
                    double PrintableAreaHeight = PageHeight - TopMargin - BottomMargin;
                    if (HtmlTagRect.Height <= PrintableAreaHeight)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            else
            {
                if (Child_HtmlTag_PageLayout != null)
                {
                    foreach (PageLayout pgl in Child_HtmlTag_PageLayout)
                    {
                        if (pgl.OnePageSize(PageHeight, TopMargin, BottomMargin))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
    }
}
