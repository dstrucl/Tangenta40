using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HtmlDoc
{
    public class Attribute
    {
        public string Name;
        public string Value;
        public Attribute(string xName, string xvalue)
        {
            Name = xName;
            Value = xvalue;
        }
    }
}
