using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TangentaDB
{

    public class HTML_PrintingOutput
    {
        public HTML_PrintingElement style = null;
        public HTML_PrintingElement pagenumber = null;
        public HTML_PrintingElement invoicetop = null;
        public HTML_PrintingElement tableitems = null;
        public List<HTML_PrintingElement> items = null;
        public HTML_PrintingElement totalneto = null;
        public List<HTML_PrintingElement> taxsum = null;
        public HTML_PrintingElement grandtotal = null;
        public HTML_PrintingElement invoicebottom = null;
    }
}
