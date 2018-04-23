using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HUDCMS
{
    public class HelpWizzardTagDC
    {

        public enum eTip { ABOUT,DESCRIPTION};

        public eTip Tip = eTip.ABOUT;

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

        public string condtition = null;
        public string Condition
        {
            get { return condtition; }
        }

        public HelpWizzardTagDC(eTip xeTip,string xname, string xtext,string xtype, string xcondition)
        {

            Tip = xeTip;
            name = xname;
            text = xtext;
            type = xtype;
            condtition = xcondition;
        }

    }
}
