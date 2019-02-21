using ColorSettings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopC_Forms
{

    public static class Colors
    {
        public static CtrlColors Row_WriteOff = new CtrlColors(lng.s_CtrlColors_Row_WriteOff.s, 1, TangentaProperties.Properties.Settings.Default.Color_DocProformaInvoiceBackGround, TangentaProperties.Properties.Settings.Default.Color_DocProformaInvoiceForeGround);
        public static CtrlColors Row_OwnUse = new CtrlColors(lng.s_CtrlColors_Row_OwnUse.s, 1, TangentaProperties.Properties.Settings.Default.Color_DocProformaInvoiceBackGround, TangentaProperties.Properties.Settings.Default.Color_DocProformaInvoiceForeGround);
        public static CtrlColors Row_SoldByGiftCertificate = new CtrlColors(lng.s_CtrlColors_Row_SoldByGiftCertificate.s, 1, TangentaProperties.Properties.Settings.Default.Color_DocProformaInvoiceBackGround, TangentaProperties.Properties.Settings.Default.Color_DocProformaInvoiceForeGround);
        public static CtrlColors m_usrc_TableOfComsumption = new CtrlColors(lng.s_CtrlColors_TableOfConsumption.s, 12, TangentaProperties.Properties.Settings.Default.Color_DocProformaInvoiceBackGround, TangentaProperties.Properties.Settings.Default.Color_DocProformaInvoiceForeGround);
        public static CtrlColors m_usrc_ConsumptionEditor = new CtrlColors(lng.s_CtrlColors_TableOfConsumption.s, 11, TangentaProperties.Properties.Settings.Default.Color_DocProformaInvoiceBackGround, TangentaProperties.Properties.Settings.Default.Color_DocProformaInvoiceForeGround);
        public static void Init()
        {
        }

    }
}