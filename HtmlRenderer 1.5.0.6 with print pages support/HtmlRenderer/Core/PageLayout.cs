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
    }
}
