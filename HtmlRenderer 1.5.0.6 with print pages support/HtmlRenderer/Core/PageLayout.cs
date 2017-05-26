using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheArtOfDev.HtmlRenderer.Core.Dom;

namespace TheArtOfDev.HtmlRenderer.Core
{
    public class PageLayout
    {
        public double MaximalBottom;
        public Adapters.Entities.RPoint rp;
        public Adapters.Entities.RSize rsize;
        public Adapters.Entities.RRect rrect;
        public Adapters.Entities.RRect CLIENTrect;
        public int level = -1;
        public string html = null;
        public string text=null;
        public string html_tag_name = null;
        public Dictionary<string, string> dictionary = null;
        public List<PageLayout> childbox = null;

        internal void Set(CssBox box, int xlevel )
        {
            if (box!=null)
            {
                level = xlevel;
                if (box.HtmlTag != null)
                {
                   html_tag_name = box.HtmlTag.Name;
                   dictionary = box.HtmlTag.Attributes;
                }
                if (box.Text != null)
                {
                   
                    text = box.Text.CutSubstring();

                }
                MaximalBottom = box.GetMaximumBottom(box, 0);
                CLIENTrect = box.ClientRectangle;
                rp = box.Location;
                rsize = box.Size;
                rrect = box.Bounds;
            }
        }
    }
}
