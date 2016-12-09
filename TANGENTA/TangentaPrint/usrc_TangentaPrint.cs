using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TangentaDB;
using DBTypes;

namespace TangentaPrint
{
    public partial class usrc_TangentaPrint : UserControl
    {
        private string m_DocInvoice = null;

        public string DocInvoice
        {
        get
        {return  m_DocInvoice; }
        set 
            {
            m_DocInvoice = value; 
            }
        }

        public bool IsDocInvoice
        {
            get {if (m_DocInvoice !=null)
                {
                    if (m_DocInvoice.ToUpper().Equals("DOCINVOICE"))
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        public bool IsDocProformaInvoice
        {
            get
            {
                if (m_DocInvoice != null)
                {
                    if (m_DocInvoice.ToUpper().Equals("DOCPROFORMAINVOICE"))
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        private int m_NumberOfPrinters = 2;

        public void Init(object p)
        {
            throw new NotImplementedException();
        }

        public int NumberOfPrinters
        {
            get { return m_NumberOfPrinters; }
        }
        public Printer[] Printers = null;

        public string PrinterName { get; set; }

        public usrc_TangentaPrint()
        {
            InitializeComponent();
            Printers = new Printer[NumberOfPrinters];
            for (int i = 0; i < Printers.Length; i++)
            {
                Printers[i] = new Printer(i);
            }

        }

        public bool Init(InvoiceData m_InvoiceData,string xDocInvoice )
        {
            //Printer selected_printer = null;
            m_DocInvoice = xDocInvoice;
            this.DocInvoice = xDocInvoice;
            return true;
            //return SelectPrinter(m_InvoiceData, ref selected_printer);
        }

        private bool SelectPrinter(InvoiceData m_InvoiceData, ref Printer selected_printer)
        {
            selected_printer = null;
            List<Printer> PrinterList = new List<Printer>();
            if (IsDocProformaInvoice)
            {
                foreach (Printer printer in Printers)
                {
                    if (printer.PrinterName != null)
                    {
                        if ((printer.PrinterName.Length > 0) && (!printer.PrinterName.Contains("?")))
                        {
                            if (printer.bPrinting_ProformaInvoices)
                            {
                                PrinterList.Add(printer);
                            }

                        }
                    }
                }
                if (PrinterList.Count == 1)
                {
                    PrinterList[0].Init(m_InvoiceData);
                }
                else if (PrinterList.Count > 1)
                {
                    //Select Printer from predefined_printers
                    Form_SelectPrinter_from_predefined_printer_list printer_list_dlg = new Form_SelectPrinter_from_predefined_printer_list(PrinterList);
                    printer_list_dlg.ShowDialog(this);
                    selected_printer = printer_list_dlg.selected_printer;
                }

                if (selected_printer!=null)
                {
                    selected_printer.Init(m_InvoiceData);
                    return true;
                }
                else
                {
                    //Select Printer from PrintDialog as usual
                }
            }
            return false;
        }

        public int Get_CurrencyD_DecimalPlaces()
        {
            return 2;
        }

        public void Print_Receipt(InvoiceData m_InvoiceData, GlobalData.ePaymentType ePaymentType, string sPaymentMethod, string sAmountReceived, string sToReturn, DateTime_v issue_time)
        {
        }

        public void Print_ProformaInvoice(InvoiceData m_InvoiceData,
                                          GlobalData.ePaymentType ePaymentType,
                                          string sPaymentMethod,
                                          string sBank,
                                          string sBankAccount,
                                          string sTermsOfPayment_Description,
                                          long DurationType,
                                          long Duration,
                                          DateTime_v issue_time)
        {
            Printer selected_printer = null;
            if (SelectPrinter(m_InvoiceData, ref selected_printer))
            {
                selected_printer.Print_ProformaInvoice(m_InvoiceData,
                                        2,
                                        ePaymentType,
                                        sPaymentMethod,
                                        sBank,
                                        sBankAccount,
                                        sTermsOfPayment_Description,
                                        DurationType,
                                        Duration,
                                        issue_time
                                        );
            }
        }

        public void PrintReport(object m_usrc_InvoiceTable)
        {
            throw new NotImplementedException();
        }

        private void btn_Printers_Click(object sender, EventArgs e)
        {
            SelectPrinters();
        }

        private void SelectPrinters()
        {
            Form_DefinePrinters frm_select_printers = new Form_DefinePrinters(this);
            frm_select_printers.ShowDialog();
        }

        public bool GetReceiptPrinter()
        {
            throw new NotImplementedException();
        }
    }
}
