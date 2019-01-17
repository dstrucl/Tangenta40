using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TangentaDB
{
    public class HTML_PrintingElement
    {
        public int index = -1;
        public int row_index = -1;
        public string TagName = null;
        public string ClassName = null;
        public string html = null;
        public double Ypos = -1;
        public double Height = -1;
        public double BotomLineDistance = -1;
        public int pagenumber = -1;

        public bool Is(string xTagName, string xClassName)
        {
            if ((TagName != null) && (xTagName != null))
            {
                if (TagName.Equals(xTagName))
                {
                    if ((ClassName!=null)&&(xClassName!=null))
                    {
                        return (ClassName.Equals(xClassName));
                    }
                }
            }
            return false;
        }
    }
}
