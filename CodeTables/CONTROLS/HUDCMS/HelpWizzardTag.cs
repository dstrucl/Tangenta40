using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HUDCMS
{
    public class HelpWizzardTag
    {
        public delegate void delegate_ShowWizzard(Control ctrl);
        public  delegate_ShowWizzard ShowWizzard = null;

        public delegate bool delegate_FillTextContent(HelpWizzardTagDC[] hlpTagDCs,ref string About, ref string Description);
        public delegate_FillTextContent FillTextContent = null;

        private string filessufix = null;
        public string FileSuffix
        {
            get { return filessufix; }
            set { filessufix = value; }
        }

        public HelpWizzardTagContent About = null;
        public HelpWizzardTagContent Description = null;

        public HelpWizzardTag(HelpWizzardTagDC[] xtagDCs, delegate_ShowWizzard xdelegate_ShowWizzard,
                                                delegate_FillTextContent xFillTextContent)
        {
            About = HelpWizzardTagContent.Clone(xtagDCs);
            Description = HelpWizzardTagContent.Clone(xtagDCs);
            ShowWizzard = xdelegate_ShowWizzard;
            FillTextContent = xFillTextContent;
        }

        public HelpWizzardTag(HelpWizzardTag xhlpwiztag)
        {
            if (xhlpwiztag.About != null)
            {
                About = HelpWizzardTagContent.Clone(xhlpwiztag.About.tagDCs);
            }
            if (xhlpwiztag.Description != null)
            {
                Description = HelpWizzardTagContent.Clone(xhlpwiztag.Description.tagDCs);
            }
            ShowWizzard = xhlpwiztag.ShowWizzard;
            FillTextContent = xhlpwiztag.FillTextContent;
        }

    }
}
