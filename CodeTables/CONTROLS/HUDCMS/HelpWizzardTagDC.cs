using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HUDCMS
{
    public class HelpWizzardTagDC
    {

        private string name = null;
        public string Name
        {
            get { return name; }
        }

        public string text = null;
        public string Text
        {
            get { return text; }
            set { text = value; }
        }

        public string type = null;
        public string Type
        {
            get { return type; }
        }

        public string condition = null;
        public string Condition
        {
            get { return condition; }
        }

        public string NamedCondition
        {
            get { return Name + "$" + Condition; }
        }
        public HelpWizzardTagDC(string xname, string xtext,string xtype, string xcondition)
        {

            name = xname;
            text = xtext;
            type = xtype;
            condition = xcondition;
        }

    }
}
