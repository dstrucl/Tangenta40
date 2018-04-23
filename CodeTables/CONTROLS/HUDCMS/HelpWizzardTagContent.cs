using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HUDCMS
{
    public class HelpWizzardTagContent
    {
        public HelpWizzardTagDC[] tagDCs = null;

        public static HelpWizzardTagContent Clone(HelpWizzardTagDC[] stagDCs)
        {
            HelpWizzardTagContent hlpwizcontent = new HelpWizzardTagContent();
            if (stagDCs!=null)
            {
                int icount = stagDCs.Length;
                if (icount>0)
                {
                    hlpwizcontent.tagDCs = new HelpWizzardTagDC[icount];
                    for (int i=0;i<icount;i++)
                    {
                         
                        HelpWizzardTagDC stdc = stagDCs[i];
                        HelpWizzardTagDC tdc = new HelpWizzardTagDC(stdc.Tip,
                                                        stdc.Name,
                                                        stdc.Text,
                                                        stdc.Type,
                                                        stdc.Condition
                                                        );
                        hlpwizcontent.tagDCs[i] = tdc;
                    }
                }
            }
            return hlpwizcontent;
        }
    }
}
