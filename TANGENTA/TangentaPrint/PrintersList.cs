using NavigationButtons;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace TangentaPrint
{
    public static class PrintersList
    {
        public static DataTable dt = new DataTable();
        public static DataTable dtPrinterObject = new DataTable();
        public static string PrinterListFile = "TangentaPrinterList.xml";

        public static DataColumn dcol_PrinterName = null;
        public static DataColumn dcol_InvoicePrinting = null;
        public static DataColumn dcol_InvoicePrinting_PaymentCash = null;
        public static DataColumn dcol_InvoicePrinting_PaymentCard = null;
        public static DataColumn dcol_InvoicePrinting_PaymentBankAccount = null;

        public static DataColumn dcol_ProformaInvoicePrinting = null;

        public static DataColumn dcol_ReportsPrinting = null;

        public static DataColumn dcol_PrinterObject = null;


        public static DataColumn dcol_PageSettings_Landscape =  null;
        public static DataColumn dcol_PageSettings_Color = null;
        public static DataColumn dcol_PageSettings_HardMarginX = null;
        public static DataColumn dcol_PageSettings_HardMarginY = null; 
        public static DataColumn dcol_PageSettings_PaperSize_Width = null;
        public static DataColumn dcol_PageSettings_PaperSize_Height = null;
        public static DataColumn dcol_PageSettings_PaperSize_PaperName = null;
        public static DataColumn dcol_PageSettings_PaperSize_RawKind = null;
        public static DataColumn dcol_PageSettings_PaperSource_RawKind = null;
        public static DataColumn dcol_PageSettings_PaperSource_SourceName = null;
        public static DataColumn dcol_PageSettings_PrinterResolution_X = null;
        public static DataColumn dcol_PageSettings_PrinterResolution_Y = null;
        public static DataColumn dcol_PageSettings_PrinterResolution_Kind = null;

        public static bool Read()
        {
            if (File.Exists(PrinterListFile))
            {
                try
                {
                    XmlReadMode xml_readmode = dt.ReadXml(PrinterListFile);
                    dtPrinterObject.Rows.Clear();
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            Printer printer = new Printer(i);
                            printer.Index = i;
                            DataRow dr = dtPrinterObject.NewRow();
                            dr[dcol_PrinterObject] = printer;
                            dtPrinterObject.Rows.Add(dr);
                        }
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    LogFile.Error.Show("Error read:" + PrinterListFile + "\r\nex.Message=" + ex.Message);
                }
            }
            return false;
        }

        public static void Init()
        {
            dcol_PrinterName = new DataColumn("PrinterName",typeof(string));
            dcol_InvoicePrinting = new DataColumn("InvoicePrinting", typeof(bool)); ;
            dcol_InvoicePrinting_PaymentCash = new DataColumn("InvoicePrinting_PaymentCash", typeof(bool)); ; ;
            dcol_InvoicePrinting_PaymentCard = new DataColumn("InvoicePrinting_PaymentCard", typeof(bool)); ; ;
            dcol_InvoicePrinting_PaymentBankAccount = new DataColumn("InvoicePrinting_PaymentBankAccount", typeof(bool)); ; ;

            dcol_ProformaInvoicePrinting = new DataColumn("ProformaInvoicePrinting", typeof(bool)); ;

            dcol_ReportsPrinting = new DataColumn("ReportsPrinting", typeof(bool));

            //dcol_PageSettings_Landscape =  new DataColumn("Landscape", typeof(bool)); 
            //dcol_PageSettings_Color = new DataColumn("Color", typeof(bool)); 
            //dcol_PageSettings_HardMarginX = new DataColumn("HardMarginX ", typeof(float));
            //dcol_PageSettings_HardMarginY = new DataColumn("HardMarginY", typeof(float));
            //dcol_PageSettings_PaperSize_Width = new DataColumn("PaperSize_Width", typeof(int));
            //dcol_PageSettings_PaperSize_Height = new DataColumn("PaperSize_Height", typeof(int));
            //dcol_PageSettings_PaperSize_PaperName = new DataColumn("PaperSize_PaperName", typeof(string));
            //dcol_PageSettings_PaperSize_RawKind = new DataColumn("PaperSize_RawKind", typeof(int)); 
            //dcol_PageSettings_PaperSource_RawKind = new DataColumn("PaperSource_RawKind", typeof(int));
            //dcol_PageSettings_PaperSource_SourceName = new DataColumn("PaperSource_SourceName", typeof(string));
            //dcol_PageSettings_PrinterResolution_X = new DataColumn("PrinterResolution_X", typeof(int));
            //dcol_PageSettings_PrinterResolution_Y = new DataColumn("PrinterResolution_Y", typeof(int));
            //dcol_PageSettings_PrinterResolution_Kind = new DataColumn("PrinterResolution_Kind", typeof(System.Drawing.Printing.PrinterResolutionKind));


            dt.Rows.Clear();
            dt.Columns.Clear();

            dt.TableName = "ListOfPrinters";
            dt.Columns.Add(dcol_PrinterName);
            dt.Columns.Add(dcol_InvoicePrinting);
            dt.Columns.Add(dcol_InvoicePrinting_PaymentCash);
            dt.Columns.Add(dcol_InvoicePrinting_PaymentCard);
            dt.Columns.Add(dcol_InvoicePrinting_PaymentBankAccount);
            dt.Columns.Add(dcol_ProformaInvoicePrinting);

            //dt.Columns.Add(dcol_PageSettings_Landscape);
            //dt.Columns.Add(dcol_PageSettings_Color);
            //dt.Columns.Add(dcol_PageSettings_HardMarginX);
            //dt.Columns.Add(dcol_PageSettings_HardMarginY);
            //dt.Columns.Add(dcol_PageSettings_PaperSize_Width);
            //dt.Columns.Add(dcol_PageSettings_PaperSize_Height);
            //dt.Columns.Add(dcol_PageSettings_PaperSize_PaperName);
            //dt.Columns.Add(dcol_PageSettings_PaperSize_RawKind);
            //dt.Columns.Add(dcol_PageSettings_PaperSource_RawKind);
            //dt.Columns.Add(dcol_PageSettings_PaperSource_SourceName);
            //dt.Columns.Add(dcol_PageSettings_PrinterResolution_X);
            //dt.Columns.Add(dcol_PageSettings_PrinterResolution_Y);
            //dt.Columns.Add(dcol_PageSettings_PrinterResolution_Kind);

            dt.Columns.Add(dcol_ReportsPrinting);





            dcol_PrinterObject = new DataColumn("PrinterObject", typeof(object));


            dtPrinterObject.Rows.Clear();
            dtPrinterObject.Columns.Clear();
            dtPrinterObject.Columns.Add(dcol_PrinterObject);

        }

        internal static void Fill(int x_index, 
                                  bool bInvoicePrinting, 
                                  bool bInvoicePrinting_PaymentCash, 
                                  bool bInvoicePrinting_PaymentCard, 
                                  bool bInvoicePrinting_PaymentBankAccount, 
                                  bool bPrinting_ProformaInvoices, 
                                  bool bPrinting_Reports)
        {
            dt.Rows[x_index][dcol_InvoicePrinting] = bInvoicePrinting;
            dt.Rows[x_index][dcol_InvoicePrinting_PaymentCash] = bInvoicePrinting_PaymentCash;
            dt.Rows[x_index][dcol_InvoicePrinting_PaymentCard] = bInvoicePrinting_PaymentCard;
            dt.Rows[x_index][dcol_InvoicePrinting_PaymentBankAccount] = bInvoicePrinting_PaymentBankAccount;
            dt.Rows[x_index][dcol_ProformaInvoicePrinting] = bPrinting_ProformaInvoices;
            dt.Rows[x_index][dcol_ReportsPrinting] = bPrinting_Reports;
        }


        internal static bool Save()
        {
            try
            {
                dt.WriteXml(PrinterListFile,XmlWriteMode.WriteSchema);
                return true;
            }
            catch (Exception ex)
            {
                LogFile.Error.Show("Error write:" + PrinterListFile + "\r\nex.Message=" + ex.Message);
            }
            return false;
        }

        internal static bool Contains(string printerName)
        {
            foreach (DataRow dr in dt.Rows)
            {
                if (((string)dr[dcol_PrinterName.ColumnName]).Equals(printerName))
                {
                    return true;
                }
            }
            return false;
        }

        public static bool Define(Navigation xnav)
        {
            Form_DefinePrinters frm_printer_list = new Form_DefinePrinters(ref dt, xnav, null);
            xnav.ChildDialog = frm_printer_list;
            xnav.ShowDialog();
            return true;
        }

        internal static int Add(Printer prn)
        {
            DataRow dr = dt.NewRow();
            DataRow drPrinterObject = dtPrinterObject.NewRow();
            dr[dcol_PrinterName.ColumnName] = prn.PrinterName;
            dt.Rows.Add(dr);
            prn.Index = dt.Rows.IndexOf(dr);
            if (prn.Index==0)
            {
                dr[dcol_InvoicePrinting] = true;
                dr[dcol_InvoicePrinting_PaymentBankAccount] = true;
                dr[dcol_InvoicePrinting_PaymentCash] = true;
                dr[dcol_InvoicePrinting_PaymentCard] = true;
                dr[dcol_ProformaInvoicePrinting] = true;
                dr[dcol_ReportsPrinting] = true;

                drPrinterObject[dcol_PrinterObject] = prn;
            }
            else
            {
                dr[dcol_InvoicePrinting.ColumnName] = false;
                dr[dcol_InvoicePrinting_PaymentBankAccount.ColumnName] = false;
                dr[dcol_InvoicePrinting_PaymentCash.ColumnName] = false;
                dr[dcol_InvoicePrinting_PaymentCard.ColumnName] = false;
                dr[dcol_ProformaInvoicePrinting.ColumnName] = false;
                dr[dcol_ReportsPrinting.ColumnName] = false;
                drPrinterObject[dcol_PrinterObject] = prn;
            }

            //dt.Rows[prn.Index][dcol_PageSettings_Landscape] = prn.
            //dt.Rows[prn.Index][dcol_PageSettings_Color] = 
            //dt.Rows[prn.Index][dcol_PageSettings_HardMarginX] = 
            //dt.Rows[prn.Index][dcol_PageSettings_HardMarginY] = 
            //dt.Rows[prn.Index][dcol_PageSettings_PaperSize_Width] = 
            //dt.Rows[prn.Index][dcol_PageSettings_PaperSize_Height] = 
            //dt.Rows[prn.Index][dcol_PageSettings_PaperSize_PaperName] = 
            //dt.Rows[prn.Index][dcol_PageSettings_PaperSize_RawKind] = 
            //dt.Rows[prn.Index][dcol_PageSettings_PaperSource_RawKind] = 
            //dt.Rows[prn.Index][dcol_PageSettings_PaperSource_SourceName] = 
            //dt.Rows[prn.Index][dcol_PageSettings_PrinterResolution_X] = 
            //dt.Rows[prn.Index][dcol_PageSettings_PrinterResolution_Y] = 
            //dt.Rows[prn.Index][dcol_PageSettings_PrinterResolution_Kind] = 


            return prn.Index;
        }
    }
}
