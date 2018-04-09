using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HUDCMS
{
    public class TagForHelp
    {
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

        public TagForHelp(string xname, string[] xvalues)
        {
            name = xname;
            values = xvalues;
        }
    }
}
