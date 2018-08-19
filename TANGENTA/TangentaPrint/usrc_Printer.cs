using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LanguageControl;
using System.Drawing.Printing;

namespace TangentaPrint
{
    public partial class usrc_Printer : UserControl
    {

        Form_DefinePrinters m_Form_DefinePrinters = null;
        Printer m_Printer = null;

        public bool bChanged = false;

        public int m_index = -1;

        
        public bool PrintingWithHtmlTemplates
        {
            get
            {
                return Properties.Settings.Default.PrintingWithHtmlTemplates;
            }
            set
            {
                Properties.Settings.Default.PrintingWithHtmlTemplates = value;
                Properties.Settings.Default.Save();
            }

        }

        public bool bInvoicePrinting
        {
            get { return this.chk_Printing_Invoices.Checked; }
        }
        public bool bInvoicePrinting_PaymentCash
        {
            get { return this.chk_Cash.Checked; }
        }
        public bool bInvoicePrinting_PaymentCard
        {
            get { return this.chk_Card.Checked; }
        }
        public bool bInvoicePrinting_PaymentBankAccount
        {
            get { return this.chk_BankAccount.Checked; }
        }

        public bool bPrinting_Reports
        {
            get { return this.chk_Printing_Reports.Checked; }
        }
        public bool bPrinting_ProformaInvoices
        {
            get { return this.chk_Printing_ProformaInvoices.Checked; }
        }


        public usrc_Printer()
        {
            InitializeComponent();
            lng.s_Invoices.Text(grp_Invoice);
            lng.s_Remove.Text(btn_Remove);
            lng.s_Printning_Invoices.Text(chk_Printing_Invoices);
            lng.s_Printning_ProformaInvoices.Text(chk_Printing_ProformaInvoices);
            lng.s_Printning_Reports.Text(chk_Printing_Reports);
            lng.s_Printning_MothodOfPayment.Text(grp_Payment);
            lng.s_Printning_MothodOfPayment_Cash.Text(chk_Cash);
            lng.s_Printning_MothodOfPayment_Card.Text(chk_Card);
            lng.s_Printning_MothodOfPayment_BankAccount.Text(chk_BankAccount);

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
                    this.grp_Printer.Text = value;
                }
        }

        internal void Init(int IndexInPrinterList, Form_DefinePrinters xForm_DefinePrinters, bool bInstalled)
        {
            this.bChanged = false;
            this.m_index = IndexInPrinterList;
            m_Form_DefinePrinters = xForm_DefinePrinters;
            if (bInstalled)
            {
                this.grp_Printer.Text = (string)PrintersList.dt.Rows[IndexInPrinterList][PrintersList.dcol_PrinterName];
                PrinterSettings printerSettings = new PrinterSettings();
                printerSettings.PrinterName = this.grp_Printer.Text;
                if ((printerSettings.DefaultPageSettings.PaperSize.Width == 284)&& (printerSettings.DefaultPageSettings.PaperSize.Height > 12000))
                {
                    //Rol paper 80 mm
                    chk_PrintingWithHtmlTemplates.Checked = PrintingWithHtmlTemplates;
                    chk_PrintingWithHtmlTemplates.CheckedChanged += Chk_PrintingWithHtmlTemplates_CheckedChanged;
                }
            }
            else
            {
                this.grp_Printer.Text = lng.sPrinterNotFound.s+":"+(string)PrintersList.dt.Rows[IndexInPrinterList][PrintersList.dcol_PrinterName];
                this.grp_Printer.BackColor = Color.DarkGray;
                this.grp_Printer.ForeColor = Color.Red;
            }

            this.chk_Printing_Invoices.Checked = (bool)PrintersList.dt.Rows[IndexInPrinterList][PrintersList.dcol_InvoicePrinting.ColumnName];
            this.chk_Cash.Checked = (bool)PrintersList.dt.Rows[IndexInPrinterList][PrintersList.dcol_InvoicePrinting_PaymentCash.ColumnName];
            this.chk_Card.Checked = (bool)PrintersList.dt.Rows[IndexInPrinterList][PrintersList.dcol_InvoicePrinting_PaymentCard.ColumnName];
            this.chk_BankAccount.Checked = (bool)PrintersList.dt.Rows[IndexInPrinterList][PrintersList.dcol_InvoicePrinting_PaymentBankAccount.ColumnName];
            this.chk_Printing_Reports.Checked = (bool)PrintersList.dt.Rows[IndexInPrinterList][PrintersList.dcol_ReportsPrinting.ColumnName];
            this.chk_Printing_ProformaInvoices.Checked = (bool)PrintersList.dt.Rows[IndexInPrinterList][PrintersList.dcol_ProformaInvoicePrinting.ColumnName];

            this.chk_Printing_ProformaInvoices.CheckedChanged += new System.EventHandler(this.chk_CheckedChanged);

            this.chk_Printing_Invoices.CheckedChanged += new System.EventHandler(this.chk_CheckedChanged);
            this.chk_Cash.CheckedChanged += new System.EventHandler(this.chk_CheckedChanged);
            this.chk_Card.CheckedChanged += new System.EventHandler(this.chk_CheckedChanged);
            this.chk_BankAccount.CheckedChanged += new System.EventHandler(this.chk_CheckedChanged);
            this.chk_Printing_Reports.CheckedChanged += new System.EventHandler(this.chk_CheckedChanged);
            this.chk_Printing_ProformaInvoices.CheckedChanged += new System.EventHandler(this.chk_CheckedChanged);
        }

        private void Chk_PrintingWithHtmlTemplates_CheckedChanged(object sender, EventArgs e)
        {
            PrintingWithHtmlTemplates = chk_PrintingWithHtmlTemplates.Checked;
        }

        private void chk_CheckedChanged(object sender, EventArgs e)
        {
            bChanged = true;
        }


        private void btn_Remove_Click(object sender, EventArgs e)
        {
           if (m_Form_DefinePrinters!=null)
           {
                m_Form_DefinePrinters.Remove(m_index);
           }
        }

    }
}
