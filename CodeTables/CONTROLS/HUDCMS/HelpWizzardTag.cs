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


        public HelpWizzardTagDC[] tagDCs = null;

        public HelpWizzardTag(HelpWizzardTagDC[] xtagDCs, delegate_ShowWizzard xdelegate_ShowWizzard,
                                                delegate_FillTextContent xFillTextContent)
        {
            tagDCs = xtagDCs;
            ShowWizzard = xdelegate_ShowWizzard;
            FillTextContent = xFillTextContent;
        }
    }
}
