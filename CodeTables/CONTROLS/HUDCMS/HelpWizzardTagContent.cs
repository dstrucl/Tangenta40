using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

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

        internal void Parse(string sxml, string xControlUniqueName)
        {
            try
            {
                XDocument xdoc = XDocument.Parse("<Root>"+sxml+"</Root>");
                if (xdoc != null)
                {
                    foreach (HelpWizzardTagDC tdc in this.tagDCs)
                    {
                        string xclassname = tdc.Name + "$" + tdc.condition;
                        XElement xel_HelpWizzardTagDC = null;
                        if (MyControl.FindXElement(xdoc, ref xel_HelpWizzardTagDC, "HelpWizzardTagDC", "class", xclassname, xControlUniqueName))
                        {
                            tdc.Text = MyControl.InnerXml(xel_HelpWizzardTagDC);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR:HUDCCMS:HelpWizzardTagContent:Parse");
            }
        }
    }
}
