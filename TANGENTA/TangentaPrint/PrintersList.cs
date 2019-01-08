using DBTypes;
using NavigationButtons;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Management;
using System.Reflection;
using System.Text;

namespace TangentaPrint
{
    public static class PrintersList
    {
        public const string PRNTERS_SETTINGS_SUB_FOLDER = "\\TangentaSettings";
        
        public static DataTable dt = new DataTable();
        public static string PrinterListFileName = "TangentaPrinterList.xml";
        public static string PrinterSettingsFolderName = "";

        public static string PrinterListFile
        {
            get { return PrinterSettingsFolderName + "\\" + PrinterListFileName; }
        }

        public static string PrinterName(DataRow dr)
        {
            string_v PrinterName_v = tf.set_string(dr["PrinterName"]);
            if (PrinterName_v != null)
            {
                return PrinterName_v.v;
            }
            else
            {
                return null;
            }

        }
        public static bool InvoicePrinting(DataRow dr)
        {
            bool_v InvoicePrinting_v = tf.set_bool(dr["InvoicePrinting"]);
            if (InvoicePrinting_v!=null)
            {
                return InvoicePrinting_v.v;
            }
            else
            {
                return false;
            }
        }
       

        public static bool InvoicePrinting_PaymentCash(DataRow dr)
        {
            bool_v InvoicePrinting_PaymentCash_v = tf.set_bool(dr["InvoicePrinting_PaymentCash"]);
            if (InvoicePrinting_PaymentCash_v != null)
            {
                return InvoicePrinting_PaymentCash_v.v;
            }
            else
            {
                return false;
            }
        }

        public static bool InvoicePrinting_PaymentCard(DataRow dr)
        {
            bool_v InvoicePrinting_PaymentCard_v = tf.set_bool(dr["InvoicePrinting_PaymentCard"]);
            if (InvoicePrinting_PaymentCard_v != null)
            {
                return InvoicePrinting_PaymentCard_v.v;
            }
            else
            {
                return false;
            }
        }

        public static bool InvoicePrinting_PaymentBankAccount(DataRow dr)
        {
            bool_v InvoicePrinting_PaymentBankAccount_v = tf.set_bool(dr["InvoicePrinting_PaymentBankAccount"]);
            if (InvoicePrinting_PaymentBankAccount_v != null)
            {
                return InvoicePrinting_PaymentBankAccount_v.v;
            }
            else
            {
                return false;
            }
        }

        public static bool ProformaInvoicePrinting(DataRow dr)
        {
            bool_v ProformaInvoicePrinting_v = tf.set_bool(dr["ProformaInvoicePrinting"]);
            if (ProformaInvoicePrinting_v != null)
            {
                return ProformaInvoicePrinting_v.v;
            }
            else
            {
                return false;
            }
        }

        public static bool ReportsPrinting(DataRow dr)
        {
            bool_v ReportsPrinting_v = tf.set_bool(dr["ReportsPrinting"]);
            if (ReportsPrinting_v != null)
            {
                return ReportsPrinting_v.v;
            }
            else
            {
                return false;
            }
        }


        public static bool PrintingWithHtmlTemplates(DataRow dr)
        {
            bool_v PrintingWithHtmlTemplates_v = tf.set_bool(dr["PrintingWithHtmlTemplates"]);
            if (PrintingWithHtmlTemplates_v != null)
            {
                return PrintingWithHtmlTemplates_v.v;
            }
            else
            {
                return false;
            }
        }






        public static DataColumn dcol_PrinterName = null;
        public static DataColumn dcol_InvoicePrinting = null;
        public static DataColumn dcol_InvoicePrinting_PaymentCash = null;
        public static DataColumn dcol_InvoicePrinting_PaymentCard = null;
        public static DataColumn dcol_InvoicePrinting_PaymentBankAccount = null;

        public static DataColumn dcol_ProformaInvoicePrinting = null;

        public static DataColumn dcol_ReportsPrinting = null;

        public static DataColumn dcol_PrintingWithHtmlTemplates = null;

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

        public static bool Read(bool bReset2FactorySettings)
        {
            if (bReset2FactorySettings)
            {
                try
                {
                    if (File.Exists(PrinterListFile))
                    {
                        File.Delete(PrinterListFile);
                    }
                }
                catch (Exception ex)
                {
                    LogFile.Error.Show("ERROR:TangentaPrint:PrintersList:Read(bReset2FactorySettings = true):Exception = " + ex.Message);
                }
            }

                if (File.Exists(PrinterListFile))
            {
                try
                {
                    XmlReadMode xml_readmode = dt.ReadXml(PrinterListFile);
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


            PrinterSettingsFolderName = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + PRNTERS_SETTINGS_SUB_FOLDER;
            ComboBox_Recent.ComboBox_RecentList.GrantFolderAccess(PrinterSettingsFolderName);

            dcol_PrinterName = new DataColumn("PrinterName",typeof(string));
            dcol_InvoicePrinting = new DataColumn("InvoicePrinting", typeof(bool)); ;
            dcol_InvoicePrinting_PaymentCash = new DataColumn("InvoicePrinting_PaymentCash", typeof(bool)); ; ;
            dcol_InvoicePrinting_PaymentCard = new DataColumn("InvoicePrinting_PaymentCard", typeof(bool)); ; ;
            dcol_InvoicePrinting_PaymentBankAccount = new DataColumn("InvoicePrinting_PaymentBankAccount", typeof(bool)); ; ;

            dcol_ProformaInvoicePrinting = new DataColumn("ProformaInvoicePrinting", typeof(bool)); ;

            dcol_ReportsPrinting = new DataColumn("ReportsPrinting", typeof(bool));

            dcol_PrintingWithHtmlTemplates = new DataColumn("PrintingWithHtmlTemplates", typeof(bool));

            dt.Rows.Clear();
            dt.Columns.Clear();

            dt.TableName = "ListOfPrinters";
            dt.Columns.Add(dcol_PrinterName);
            dt.Columns.Add(dcol_InvoicePrinting);
            dt.Columns.Add(dcol_InvoicePrinting_PaymentCash);
            dt.Columns.Add(dcol_InvoicePrinting_PaymentCard);
            dt.Columns.Add(dcol_InvoicePrinting_PaymentBankAccount);
            dt.Columns.Add(dcol_ProformaInvoicePrinting);

            dt.Columns.Add(dcol_ReportsPrinting);

            dt.Columns.Add(dcol_PrintingWithHtmlTemplates);

        }

        internal static void Fill(int x_index, 
                                  bool bInvoicePrinting, 
                                  bool bInvoicePrinting_PaymentCash, 
                                  bool bInvoicePrinting_PaymentCard, 
                                  bool bInvoicePrinting_PaymentBankAccount, 
                                  bool bPrinting_ProformaInvoices, 
                                  bool bPrinting_Reports,
                                  bool bPrintingWithHtmlTemplates)
        {
            dt.Rows[x_index][dcol_InvoicePrinting] = bInvoicePrinting;
            dt.Rows[x_index][dcol_InvoicePrinting_PaymentCash] = bInvoicePrinting_PaymentCash;
            dt.Rows[x_index][dcol_InvoicePrinting_PaymentCard] = bInvoicePrinting_PaymentCard;
            dt.Rows[x_index][dcol_InvoicePrinting_PaymentBankAccount] = bInvoicePrinting_PaymentBankAccount;
            dt.Rows[x_index][dcol_ProformaInvoicePrinting] = bPrinting_ProformaInvoices;
            dt.Rows[x_index][dcol_ReportsPrinting] = bPrinting_Reports;
            dt.Rows[x_index][dcol_PrintingWithHtmlTemplates] = bPrintingWithHtmlTemplates;
        }


        internal static bool Save()
        {
            try
            {
                dt.WriteXml(PrinterListFile, XmlWriteMode.WriteSchema);
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

        public static bool Startup_12_Show_Form_DefinePrinters(Navigation xnav)
        {
            xnav.ShowForm(new Form_DefinePrinters(ref dt, xnav, null), typeof(Form_DefinePrinters).ToString());
            return true;
        }

        internal static int Add(Printer prn)
        {
            DataRow dr = dt.NewRow();
            dr[dcol_PrinterName.ColumnName] = prn.PrinterName;
            if (prn.Index==0)
            {
                dr[dcol_InvoicePrinting] = true;
                dr[dcol_InvoicePrinting_PaymentBankAccount] = true;
                dr[dcol_InvoicePrinting_PaymentCash] = true;
                dr[dcol_InvoicePrinting_PaymentCard] = true;
                dr[dcol_ProformaInvoicePrinting] = true;
                dr[dcol_ReportsPrinting] = true;
            }
            else
            {
                dr[dcol_InvoicePrinting.ColumnName] = false;
                dr[dcol_InvoicePrinting_PaymentBankAccount.ColumnName] = false;
                dr[dcol_InvoicePrinting_PaymentCash.ColumnName] = false;
                dr[dcol_InvoicePrinting_PaymentCard.ColumnName] = false;
                dr[dcol_ProformaInvoicePrinting.ColumnName] = false;
                dr[dcol_ReportsPrinting.ColumnName] = false;
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

            dt.Rows.Add(dr);
            prn.Index = dt.Rows.IndexOf(dr);
            return prn.Index;
        }

        //public static bool IsPrinterConnected(string printername)
        //{
        //    bool printerStatus = false;
        //    try
        //    {
        //        PrintDocument pd = new PrintDocument
        //        {
        //            PrinterSettings = new PrinterSettings
        //            {
        //                PrinterName = printername
        //            }
        //        };
        //        printerStatus = pd.PrinterSettings.IsValid;
        //    }
        //    catch (System.Exception ex)
        //    {
        //    }
        //    return printerStatus;
        //}
        public static bool IsPrinterConnected(string printername)
        {
            // Set management scope
            ManagementScope scope = new ManagementScope(@"\root\cimv2");
            scope.Connect();

            // Select Printers from WMI Object Collections
            ManagementObjectSearcher searcher = new
             ManagementObjectSearcher("SELECT * FROM Win32_Printer");

            string printerName = "";
            foreach (ManagementObject printer in searcher.Get())
            {
                printerName = printer["Name"].ToString().ToLower();
                if (printerName.Equals(printername.ToLower()))
                {
                    Console.WriteLine("Printer = " + printer["Name"]);
                    if (printer["WorkOffline"].ToString().ToLower().Equals("true"))
                    {
                        // printer is offline by user
                        return false;
                        //Console.WriteLine("Your Plug-N-Play printer is not connected.");
                    }
                    else
                    {
                        // printer is not offline
                        //Console.WriteLine("Your Plug-N-Play printer is connected.");
                        return true;
                    }
                }
            }
            return false;
        }

        public static bool PrintingWithHtmlTemplate(string doctype, ref Printer printer)
        {
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        string printername = PrinterName(dr);

                        if (doctype.Equals("DocInvoice"))
                        {
                            if (InvoicePrinting(dr))
                            {
                                if (PrintingWithHtmlTemplates(dr))
                                {
                                    if (IsPrinterConnected(printername))
                                    {
                                        return true;
                                    }
                                }
                                else
                                {
                                    printer = new Printer(printername);
                                }
                            }
                        }
                    }
                }
            }
            return false;
        }

   
    }
}
