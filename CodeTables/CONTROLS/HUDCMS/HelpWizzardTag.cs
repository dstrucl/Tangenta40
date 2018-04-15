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

        private string name = null;
        public string Name
        {
            get { return name; }
        }

        public string[] values = null;
        public string[] Values
        {
            get { return values; }
        }

        public string FileName = null;
        public string Text = null;

        public HelpWizzardTag()
        {
        }

        public HelpWizzardTag(string xname, string[] xvalues)
        {
            name = xname;
            values = xvalues;
        }
    }
}
