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
        public static CtrlColors DocInvoice = new CtrlColors("DocInvoice", 14, Properties.Settings.Default.Color_DocInvoiceBackGround, Properties.Settings.Default.Color_DocInvoiceForeGround);
        public static CtrlColors DocProformaInvoice= new CtrlColors("DocProformaInvoice", 15, Properties.Settings.Default.Color_DocProformaInvoiceBackGround, Properties.Settings.Default.Color_DocProformaInvoiceForeGround);
        public static CtrlColors m_usrc_DocumentEditor = new CtrlColors("DocumentEditor", 11, Properties.Settings.Default.Color_DocProformaInvoiceBackGround, Properties.Settings.Default.Color_DocProformaInvoiceForeGround);
        public static CtrlColors m_usrc_TableOfDocuments = new CtrlColors("TableOfDocuments", 12, Properties.Settings.Default.Color_DocProformaInvoiceBackGround, Properties.Settings.Default.Color_DocProformaInvoiceForeGround);
    }
}
