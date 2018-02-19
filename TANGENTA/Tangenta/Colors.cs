using ColorSettings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tangenta
{
    public static class Colors
    {
        public static CtrlColors DocInvoice = new CtrlColors("DocInvoice", 9, Properties.Settings.Default.Color_DocInvoiceBackGround, Properties.Settings.Default.Color_DocInvoiceForeGround);
        public static CtrlColors DocProformaInvoice= new CtrlColors("DocProformaInvoice", 9, Properties.Settings.Default.Color_DocProformaInvoiceBackGround, Properties.Settings.Default.Color_DocProformaInvoiceForeGround);
    }
}
