using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LanguageControl;
using TangentaDB;

namespace TangentaPrint
{
    public partial class usrc_SelectPrintTemplate : UserControl
    {
        public Printer.StandardPages PageType
        {
            get
            { return Printer.StandardPages.A4; }
        }

        public Printer.PageOreintation PageOrientation
        {
            get { return Printer.PageOreintation.PORTRAIT; }
        }

        public int SelectedLangugage
        {
            get { return 1; }
        }

        
        public string TemplateName
        {
            get { return cmb_SelectPrintTemplate.Text; }
            set { cmb_SelectPrintTemplate.Text = value; }
        }

        public usrc_SelectPrintTemplate()
        {
            InitializeComponent();

            lngRPM.s_Language.Text(lbl_Language);
            lngRPM.s_PaperSize.Text(grp_PaperSize);
            lngRPM.s_Template.Text(lbl_Template, ":");
            lngRPM.s_A4.Text(rdb_A4);
            lngRPM.s_Roll_80.Text(rdb_80);
            lngRPM.s_Roll_58.Text(rdb_58);
            lngRPM.s_PaperOrientation.Text(grp_Orientation);
            lngRPM.s_PaperOrientation_Portrait.Text(rdb_Portrait);
            lngRPM.s_PaperOrientation_Landscape.Text(rdb_Landscape);
            cmb_Language.DataSource = LanguageControl.DynSettings.s_language.sTextArr;
            cmb_Language.SelectedIndex = LanguageControl.DynSettings.LanguageID;
        }


        internal bool Init(InvoiceData m_InvoiceData)
        {
            if (m_InvoiceData.IsDocInvoice)
            {
                switch (m_InvoiceData.AddOnDI.m_MethodOfPayment.eType)
                {
                    case GlobalData.ePaymentType.CASH:
                    case GlobalData.ePaymentType.CASH_OR_PAYMENT_CARD:
                    case GlobalData.ePaymentType.PAYMENT_CARD:
                        break;
                    default:
                        rdb_A4.Checked = true;
                        grp_Orientation.Enabled = true;
                        rdb_Portrait.Checked = true;
                        break;

                }
            }
            else if (m_InvoiceData.IsDocProformaInvoice)
            {
                rdb_A4.Checked = true;
                grp_Orientation.Enabled = true;
                rdb_Portrait.Checked = true;
            }
            else
            {
                LogFile.Error.Show("ERROR:Form_SelectTemplate:Form_SelectTemplate:Unknown document type!");
                return false;
            }
            return true;
        }
    }
}
