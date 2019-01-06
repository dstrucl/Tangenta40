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
        public static CtrlColors HeadColor = new CtrlColors(lng.s_CtrlColors_HeadColor.s, 7, TangentaSettings.Properties.Settings.Default.Color_DocInvoiceBackGround, TangentaSettings.Properties.Settings.Default.Color_DocInvoiceForeGround);
        public static CtrlColors DocInvoice = new CtrlColors(lng.s_CtrlColors_DocInvoice.s, 14, TangentaSettings.Properties.Settings.Default.Color_DocInvoiceBackGround, TangentaSettings.Properties.Settings.Default.Color_DocInvoiceForeGround);
        public static CtrlColors DocProformaInvoice = new CtrlColors(lng.s_CtrlColors_DocProformaInvoice.s, 15, TangentaSettings.Properties.Settings.Default.Color_DocProformaInvoiceBackGround, TangentaSettings.Properties.Settings.Default.Color_DocProformaInvoiceForeGround);
        public static CtrlColors m_usrc_DocumentEditor = new CtrlColors(lng.s_CtrlColors_DocumentEditor.s, 11, TangentaSettings.Properties.Settings.Default.Color_DocProformaInvoiceBackGround, TangentaSettings.Properties.Settings.Default.Color_DocProformaInvoiceForeGround);
        public static CtrlColors m_usrc_TableOfDocuments = new CtrlColors(lng.s_CtrlColors_TableOfDocuments.s, 12, TangentaSettings.Properties.Settings.Default.Color_DocProformaInvoiceBackGround, TangentaSettings.Properties.Settings.Default.Color_DocProformaInvoiceForeGround);
        public static void Init()
        {
        }

    }
}


