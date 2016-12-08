using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LanguageControl;

namespace TangentaPrint
{
    public partial class usrc_Printer : UserControl
    {

        Printer m_Printer = null;

        public usrc_Printer()
        {
            InitializeComponent();
            lngRPM.s_Printning_Invoices.Text(chk_Printing_Invoices);
            lngRPM.s_Printning_ProformaInvoices.Text(chk_Printing_ProformaInvoices);
            lngRPM.s_Printning_Reports.Text(chk_Printing_ProformaInvoices);
        }

        public string PrinterName
        {
            get
            {
                if (m_Printer != null)
                {
                    return m_Printer.PrinterName;
                }
                else
                {
                    return "??";
                }
            }
            set {
                    this.m_usrc_Device.PrinterName = value;
                }
        }

        internal void Init(Printer printer)
        {
            m_Printer = printer;
            this.m_usrc_Device.Init(m_Printer);
            lngRPM.s_Printer.Text(grp_Printer, " " + (m_Printer.Index + 1).ToString());
            if (m_Printer.Index == 0)
            {
                m_Printer.bPrinting_Invoices = Properties.Settings.Default.Printer1_Printing_Invoices;
                chk_Printing_Invoices.Checked = m_Printer.bPrinting_Invoices;
                m_Printer.bPrinting_ProformaInvoices = Properties.Settings.Default.Printer1_Printing_ProformaInvoices;
                chk_Printing_ProformaInvoices.Checked = m_Printer.bPrinting_ProformaInvoices;
                m_Printer.bPrinting_Reports = Properties.Settings.Default.Printer1_Printing_Reports;
                chk_Printing_Reports.Checked = m_Printer.bPrinting_Reports;
            }
            else 
            {
                m_Printer.bPrinting_Invoices = Properties.Settings.Default.Printer2_Printing_Invoices;
                chk_Printing_Invoices.Checked = m_Printer.bPrinting_Invoices;
                m_Printer.bPrinting_ProformaInvoices = Properties.Settings.Default.Printer2_Printing_ProformaInvoices;
                chk_Printing_ProformaInvoices.Checked = m_Printer.bPrinting_ProformaInvoices;
                m_Printer.bPrinting_Reports = Properties.Settings.Default.Printer2_Printing_Reports;
                chk_Printing_Reports.Checked = m_Printer.bPrinting_Reports;
            }
        }
    }
}
