#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;
using LanguageControl;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.ComponentModel;
using TangentaDB;
using DBTypes;
using UniversalInvoice;
using System.Data;
using DBConnectionControl40;

namespace TangentaPrint
{
    public class Printer
    {
        private PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();
        public PrintDocument printDocument = null;
        public PrinterSettings printer_settings = new PrinterSettings();
        public PageSettings page_settings = null;

        public enum eCharacterSet { Slovenia_Croatia, USA };
        public bool m_PrintInBuffer = false;
        private string PrintBuffer = null;


        private string m_PrinterName = null;
        private string m_PaperName = null;

        public usrc_Printer m_usrc_Printer = null;



        public InvoiceData m_InvoiceData = null;
        public StaticLib.TaxSum taxSum = null;


        private int m_Index = -1;
        public int Index
        {
            get { return m_Index; }
            set { m_Index = value; }
        }

        internal bool GetPrinter()
        {
            if (this.m_Index >= 0)
            {
                if (PrintersList.dt.Rows.Count > this.m_Index)
                {
                    string PrinterName = (string)PrintersList.dt.Rows[this.m_Index][PrintersList.dcol_PrinterName];
                    foreach (string printer in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
                    {
                        if (PrinterName.Equals(printer))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;

        }


        public Printer(string printer_name)
        {
            this.m_PrinterName = printer_name;
        }


        private bool m_bPrinting_Invoices = false;
        public bool bPrinting_Invoices
        {
            get { return m_bPrinting_Invoices; }
            set
            {
                m_bPrinting_Invoices = value;
            }
        }
        private bool m_bPrinting_ProformaInvoices = false;
        public bool bPrinting_ProformaInvoices
        {
            get { return m_bPrinting_ProformaInvoices; }
            set
            {
                m_bPrinting_ProformaInvoices = value;
            }
        }

        private bool m_bPrinting_Reports = false;
        public bool bPrinting_Reports
        {
            get { return m_bPrinting_Reports; }
            set
            {
                m_bPrinting_Reports = value;
            }
        }



        public double PageHeight
        {
            get
            {
                if (this.printer_settings == null)
                {
                    this.printer_settings = new PrinterSettings();
                }
                printer_settings.PrinterName = PrinterName;
                double paper_size_height = (double)printer_settings.DefaultPageSettings.PaperSize.Height;
                return paper_size_height;
            }
        }

        float cx_paper_in_inch = 0;
        float cy_paper_in_inch = 0;

        int cx_paper_on_screen_in_pixels = 0;
        int cy_paper_on_screen_in_pixels = 0;

        public string PaperName
        {
            get
            {
                return m_PaperName;
            }
            set
            {
                m_PaperName = value;
                if (m_PaperName != null)
                {
                    //lbl_PaperName_Value.Text = m_PaperName;
                }
            }
        }

        public string HT = "\x09"; //CarriageReturn
        [DllImport("gdi32.dll")]
        static extern int GetDeviceCaps(IntPtr hdc, int nIndex);


        public bool PrintInBuffer
        {
            get { return m_PrintInBuffer; }

            set { m_PrintInBuffer = value;
                }
        }

        public void Clear()
        {
            PrintBuffer = null;
        }

        public bool Print_PrinterBuffer()
        {
            if (PrintInBuffer)
            {
                if (PrintBuffer != null)
                {
                    return RawPrinterHelper.SendStringToPrinter(printer_settings.PrinterName, PrintBuffer);
                }
                else
                {
                    LogFile.Error.Show("ERROR:Printer:Print_PrinterBuffer:PrintBuffer == null");
                    return false;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:Printer:Print_PrinterBuffer:PrintInBuffer == False");
                return false;
            }
        }

        internal void Print()
        {
            throw new NotImplementedException();
        }

        int max_char_in_line = 58;
        EscPos_RP58 ep_RP58 = new EscPos_RP58();
        EscPos_RP80 ep_RP80 = new EscPos_RP80();
        EscPos_Star_TSP100 ep_Star_TSP100 = new EscPos_Star_TSP100();
        object print_ESC_POS_device = null;


        public class RawPrinterHelper
        {
            // Structure and API declarions:
            [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
            public class DOCINFOA
            {
                [MarshalAs(UnmanagedType.LPStr)]
                public string pDocName;
                [MarshalAs(UnmanagedType.LPStr)]
                public string pOutputFile;
                [MarshalAs(UnmanagedType.LPStr)]
                public string pDataType;
            }
            [DllImport("winspool.Drv", EntryPoint = "OpenPrinterA", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
            public static extern bool OpenPrinter([MarshalAs(UnmanagedType.LPStr)] string szPrinter, out IntPtr hPrinter, IntPtr pd);

            [DllImport("winspool.Drv", EntryPoint = "ClosePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
            public static extern bool ClosePrinter(IntPtr hPrinter);

            [DllImport("winspool.Drv", EntryPoint = "StartDocPrinterA", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
            public static extern bool StartDocPrinter(IntPtr hPrinter, Int32 level, [In, MarshalAs(UnmanagedType.LPStruct)] DOCINFOA di);

            [DllImport("winspool.Drv", EntryPoint = "EndDocPrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
            public static extern bool EndDocPrinter(IntPtr hPrinter);

            [DllImport("winspool.Drv", EntryPoint = "StartPagePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
            public static extern bool StartPagePrinter(IntPtr hPrinter);

            [DllImport("winspool.Drv", EntryPoint = "EndPagePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
            public static extern bool EndPagePrinter(IntPtr hPrinter);

            [DllImport("winspool.Drv", EntryPoint = "WritePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
            public static extern bool WritePrinter(IntPtr hPrinter, IntPtr pBytes, Int32 dwCount, out Int32 dwWritten);

            [DllImport("winspool.drv", CharSet = CharSet.Auto, SetLastError = true)]
            public static extern bool SetDefaultPrinter(string Name);


            // SendBytesToPrinter()
            // When the function is given a printer name and an unmanaged array
            // of bytes, the function sends those bytes to the print queue.
            // Returns true on success, false on failure.


            public static bool SendBytesToPrinter(string szPrinterName, IntPtr pBytes, Int32 dwCount)
            {
                Int32 dwError = 0, dwWritten = 0;
                IntPtr hPrinter = new IntPtr(0);
                DOCINFOA di = new DOCINFOA();
                bool bSuccess = false; // Assume failure unless you specifically succeed.

                di.pDocName = "My C#.NET RAW Document";
                di.pDataType = "RAW";

                // Open the printer.
                if (OpenPrinter(szPrinterName.Normalize(), out hPrinter, IntPtr.Zero))
                {
                    // Start a document.
                    if (StartDocPrinter(hPrinter, 1, di))
                    {
                        // Start a page.
                        if (StartPagePrinter(hPrinter))
                        {
                            // Write your bytes.
                            bSuccess = WritePrinter(hPrinter, pBytes, dwCount, out dwWritten);
                            EndPagePrinter(hPrinter);
                        }
                        EndDocPrinter(hPrinter);
                    }
                    ClosePrinter(hPrinter);
                }
                // If you did not succeed, GetLastError may give more information
                // about why not.
                if (bSuccess == false)
                {
                    dwError = Marshal.GetLastWin32Error();
                    string errorMessage = new Win32Exception(Marshal.GetLastWin32Error()).Message;
                    throw new System.ApplicationException(errorMessage);
                }
                return bSuccess;
            }


            public static bool SendStringToPrinter(string szPrinterName, string szString)
            {
                IntPtr pBytes;
                Int32 dwCount;
                // How many characters are in the string?
                dwCount = szString.Length;
                // Assume that the printer is expecting ANSI text, and then convert
                // the string to ANSI text.
                pBytes = Marshal.StringToCoTaskMemAnsi(szString);
                // Send the converted ANSI string to the printer.
                SendBytesToPrinter(szPrinterName, pBytes, dwCount);
                Marshal.FreeCoTaskMem(pBytes);
                return true;
            }
        }


        public Printer(int i)
        {
            m_Index = i;
        }

        public Printer ThisPrinter
        {
            get { return this; }
        }

        internal void Print_Receipt(ID xAtom_WorkPeriod_ID,
                                    InvoiceData xInvoiceData, 
                                    string FursD_BussinesPremiseID,
                                    string ElectronicDevice_ID,
                                    int BaseCurrencyDecimalPlaces,
                                    GlobalData.ePaymentType PaymentType, string sPaymentMethod, string sAmountReceived, string sToReturn, DateTime_v issue_time,
                                    Form_PrintDocument.delegate_Door_OpenIfUserIsAdministrator xDoor_OpenIfUserIsAdministrator,
                                    NavigationButtons.Navigation nav)
        {

            if (Printer_is_ESC_POS())
            {
                Print_Receipt_ESC_POS(xAtom_WorkPeriod_ID,xInvoiceData, FursD_BussinesPremiseID,ElectronicDevice_ID, BaseCurrencyDecimalPlaces, PaymentType, sPaymentMethod, sAmountReceived, sToReturn, issue_time);
            }
            else
            {
                Form_PrintDocument print_A4_dlg = new Form_PrintDocument(xAtom_WorkPeriod_ID, xInvoiceData, nav.btn3_Image, xDoor_OpenIfUserIsAdministrator);
                print_A4_dlg.ShowDialog();
            }
        }



        public string PrinterName
        {
            get {return m_PrinterName;}
            set {
                    string pname = value;
                    if (pname!=null)
                    { 
                        if (pname.Contains("RP80"))
                        {
                            print_ESC_POS_device = ep_RP80;
                            max_char_in_line = 48;
                        }
                        else if (pname.Contains("RP58"))
                        {
                            print_ESC_POS_device = ep_RP58;
                            max_char_in_line = 32;
                        }
                        else if (pname.Contains("Star TSP100"))
                        {
                            print_ESC_POS_device = ep_Star_TSP100;
                            max_char_in_line = 42;
                        }
                        else
                        {
                            print_ESC_POS_device = null;
                        //string s= lng.s_PrinterNotSuported.s;
                        //string sMsg = s.Replace("%%%",pname);
                        //MessageBox.Show(sMsg);
                        }
                    }
                    m_PrinterName = pname;
                    if (this.m_usrc_Printer!=null)
                    {
                        this.m_usrc_Printer.PrinterName = m_PrinterName;
                    }
                }

        }




        private string FindPrinter(string printerName)
        {

            foreach (string printer in  PrinterSettings.InstalledPrinters)
            {
                if (printer.ToLower().Equals(printerName.ToLower()))
                {
                    return printer;
                }
            }
            return null; // printDocument.PrinterSettings.PrinterName;
        }

        
        public bool Print(string buffer)
        {



            // Allow the user to select a printer.
                // Send a printer-specific to the printer.
            if (PrintInBuffer)
            {
                if (PrintBuffer==null)
                {
                    PrintBuffer = buffer;
                }
                else
                {
                    PrintBuffer += buffer;
                }
                return true;
            }
            else
            { 
                return RawPrinterHelper.SendStringToPrinter(printer_settings.PrinterName, buffer);
            }   
        }

       


        public bool Select(Form frm)
        {
            PrintDialog printDialog = new PrintDialog();
            printDialog.ShowNetwork = true;
            if (printDialog.ShowDialog() == DialogResult.OK)
            {

                PrinterName = printDialog.PrinterSettings.PrinterName;
                printer_settings = printDialog.PrinterSettings;
                Properties.Settings.Default.Save();
                //RawPrinterHelper.SetDefaultPrinter(PrinterName);
                return true;
            }
            return false;

        }
        public bool SelectPageSettings()
        {
            
            PageSetupDialog page_stpdlg = new PageSetupDialog();

            
            // Initialize the dialog's PrinterSettings property to hold user
            // defined printer settings
            if (page_settings==null)
            {
                page_settings = new System.Drawing.Printing.PageSettings();
            }
            page_stpdlg.PageSettings = page_settings;
                

            // Initialize dialog's PrinterSettings property to hold user
            // set printer settings.
            if (printer_settings == null)
            {
                printer_settings = new System.Drawing.Printing.PrinterSettings();
            }
            page_stpdlg.PrinterSettings = printer_settings;
                

            //Do not show the network in the printer dialog.
            page_stpdlg.ShowNetwork = false;

            //Show the dialog storing the result.
            DialogResult result = page_stpdlg.ShowDialog();

            // If the result is OK, display selected settings in
            // ListBox1. These values can be used when printing the
            // document.
            if (result == DialogResult.OK)
            {
                page_settings = page_stpdlg.PageSettings;
                SavePageSettings(page_settings);
                return true;
            }
            else
            {
                return false;
            }

        }

        private void SavePageSettings(PageSettings page_settings)
        {
            //Properties.Settings.Default.Printer1_PageSettings_Landscape = page_settings.Landscape;
            //Properties.Settings.Default.Printer1_PageSettings_Color = page_settings.Color;
            //Properties.Settings.Default.Printer1_PageSettings_HardMarginX = page_settings.HardMarginX;
            //Properties.Settings.Default.Printer1_PageSettings_HardMarginY = page_settings.HardMarginY;
            //Properties.Settings.Default.Printer1_PageSettings_PaperSize_Width = page_settings.PaperSize.Width;
            //Properties.Settings.Default.Printer1_PageSettings_PaperSize_Height = page_settings.PaperSize.Height;
            //Properties.Settings.Default.Printer1_PageSettings_PaperSize_PaperName = page_settings.PaperSize.PaperName;
            //Properties.Settings.Default.Printer1_PageSettings_PaperSize_RawKind = (int)page_settings.PaperSize.RawKind;
            //Properties.Settings.Default.Printer1_PageSettings_PaperSource_RawKind = page_settings.PaperSource.RawKind;
            //Properties.Settings.Default.Printer1_PageSettings_PaperSource_SourceName = page_settings.PaperSource.SourceName;
            //Properties.Settings.Default.Printer1_PageSettings_PrinterResolution_X = page_settings.PrinterResolution.X;
            //Properties.Settings.Default.Printer1_PageSettings_PrinterResolution_Y = page_settings.PrinterResolution.Y;
            //Properties.Settings.Default.Printer1_PageSettings_PrinterResolution_Kind = (int)page_settings.PrinterResolution.Kind;
            //Properties.Settings.Default.Save();
        }

        private bool ReadPageSettings(ref PageSettings pgset)
        {
                try
                {
                    if (pgset == null)
                    {
                        pgset = new PageSettings();
                    }
                    if (pgset.PaperSource.SourceName.Length > 0)
                    {
                        //string paper_name = Properties.Settings.Default.Printer1_PageSettings_PaperSize_PaperName;

                        foreach (PaperSize psize in printer_settings.PaperSizes)
                        {
                            //if (psize.PaperName.Equals(paper_name))
                            //{
                            //    pgset.PaperSize = psize;
                            //    break;
                            //}
                        }
                        //pgset.Landscape = Properties.Settings.Default.Printer1_PageSettings_Landscape;
                        //pgset.Color = Properties.Settings.Default.Printer1_PageSettings_Color;
                        //pgset.PaperSource.SourceName = Properties.Settings.Default.Printer1_PageSettings_PaperSource_SourceName;
                        //pgset.PaperSource.RawKind = Properties.Settings.Default.Printer1_PageSettings_PaperSource_RawKind;
                        //pgset.PrinterResolution.X = Properties.Settings.Default.Printer1_PageSettings_PrinterResolution_X;
                        //pgset.PrinterResolution.Y = Properties.Settings.Default.Printer1_PageSettings_PrinterResolution_Y;
                        //pgset.PrinterResolution.Kind = (PrinterResolutionKind)Properties.Settings.Default.Printer1_PageSettings_PrinterResolution_Kind;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception ex)
                {
                   LogFile.Error.Show("ERROR:ReadPageSettings:Exception=" + ex.Message);
                   return false;
                }
        }

//        public bool Define(Form frm)
//        {
////            string pname = Properties.Settings.Default.Printer1_PrinterName;
////            PrinterName = FindPrinter(pname); ;
//            PageSettings pgset = null;
//            if (ReadPageSettings(ref pgset))
//            {
//                page_settings = pgset;
//            }
//            if ((PrinterName == null)||(page_settings==null))
//            {
//  //              MessageBox.Show(frm, lng.s_Printer.s + ":" + Properties.Settings.Default.Printer1_PrinterName + lng.s_NotInPrinterList.s + "\r\n" + lng.s_SelectReceiptPrinter.s);
//                if (Select(frm))
//                {
//                     return DefinePage(frm);
//                }
//                else
//                {
//                    return false;
//                }
//            }
//            else
//            {
//                printer_settings.PrinterName = PrinterName;
//                return true;
//            }
//        }

        private bool FindPaper(string paper_name, ref PaperSize psize)
        {
            if (paper_name != null)
            {
                if ((paper_name.Length > 0))
                {
                    foreach (PaperSize xpsize in printer_settings.PaperSizes)
                    {
                        if (xpsize.PaperName.Equals(paper_name))
                        {
                            psize = xpsize;
                            return true;
                        }
                    }
                }
            }
            return false;

        }
        public bool DefinePage(Form frm)
        {
            PageSettings pgset = null;
            if (ReadPageSettings(ref pgset))
            {
                PaperSize psize = null;
                if (FindPaper(pgset.PaperSize.PaperName, ref psize))
                {
                    pgset.PaperSize = psize;
                    page_settings = pgset;
                    return true;
                }
                else
                {
                    if (page_settings == null)
                    {
                        return SelectPageSettings();
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            else
            {
                return SelectPageSettings();
            }
        }

        internal void wr_BitmapByteArrayTo570x570imagesize(byte[] Logo_Data)
        {
            if (print_ESC_POS_device==null)
            {
                return;
            }
            if (print_ESC_POS_device is EscPos_RP80)
            {
                string buf = "";
                buf = ep_RP80.GetBitmapString570x570imagesize(Logo_Data);// ep.LF + ep.CR;
                Print(buf);
            }
            else if (print_ESC_POS_device is EscPos_Star_TSP100)
            {
                string buf = "";
                buf = ep_Star_TSP100.GetBitmapString(Logo_Data);// ep.LF + ep.CR;
                Print(buf);
            }
        }

        internal void wr_BitmapByteArray570x570imagesize(byte[] Logo_Data)
        {
            if (print_ESC_POS_device == null)
            {
                return;
            }
            if (print_ESC_POS_device is EscPos_RP80)
            {
                string buf = "";
                buf = ep_RP80.GetBitmapString570x570imagesize(Logo_Data);// ep.LF + ep.CR;
                Print(buf);
            }
            else if (print_ESC_POS_device is EscPos_Star_TSP100)
            {
                string buf = "";
                buf = ep_Star_TSP100.GetBitmapString(Logo_Data);// ep.LF + ep.CR;
                Print(buf);
            }
        }

        internal void wr_BitmapByteArray(byte[] Logo_Data, double xwidth)
        {
            if (print_ESC_POS_device == null)
            {
                return;
            }
            if (print_ESC_POS_device is EscPos_RP80)
            {
                string buf = "";
                buf = ep_RP80.GetBitmapString(Logo_Data, xwidth);// ep.LF + ep.CR;
                Print(buf);
            }
            else if (print_ESC_POS_device is EscPos_Star_TSP100)
            {
                string buf = "";
                buf = ep_Star_TSP100.GetBitmapString(Logo_Data);// ep.LF + ep.CR;
                Print(buf);
            }
        }

        internal void wr_SelectAnInternationalCharacterSet(eCharacterSet eSet)
        {
            string buffer = null;
            if (print_ESC_POS_device==null)
            {
                return;
            }
            if (print_ESC_POS_device is EscPos_RP80)
            {
                switch (eSet)
                {
                    case eCharacterSet.Slovenia_Croatia:
                        buffer = ep_RP80.SelectAnInternationalCharacterSet(EscPos_RP80.eCharacterSet.Slovenia_Croatia); // "\x1b\x1d\x61\x1";             //Center Alignment - Refer to Pg. 3-29
                        //buffer = buffer + "\x5B" + "If loaded.. Logo1 goes here" + "\x5D\n";
                        buffer += ep_RP80.SelectCharacterCodeTable(EscPos_RP80.eCodeTable.WCP1250_Central_Europe);
                        Print(buffer);
                        break;
                    case eCharacterSet.USA:
                        buffer = ep_RP80.SelectAnInternationalCharacterSet(EscPos_RP80.eCharacterSet.USA) + ep_RP80.SelectCharacterCodeTable(EscPos_RP80.eCodeTable.CP437_USA_Standard_Europe);
                        Print(buffer);
                        break;
                }
            }
            else if (print_ESC_POS_device is EscPos_RP58)
            {
                switch (eSet)
                {
                    case eCharacterSet.Slovenia_Croatia:
                        return;
                        //buffer = ep_RP58.SelectAnInternationalCharacterSet(EscPos_RP58.eCharacterSet.Slovenia_Croatia); // "\x1b\x1d\x61\x1";             //Center Alignment - Refer to Pg. 3-29
                        ////buffer = buffer + "\x5B" + "If loaded.. Logo1 goes here" + "\x5D\n";
                        //buffer += ep_RP80.SelectCharacterCodeTable(EscPos_RP80.eCodeTable.WCP1250_Central_Europe);
                        //Print(buffer);
                        //break;
                    case eCharacterSet.USA:
                        buffer = ep_RP58.SelectAnInternationalCharacterSet(EscPos_RP58.eCharacterSet.USA) + ep_RP58.SelectCharacterCodeTable(EscPos_RP58.eCodeTable.CP437_USA_Standard_Europe);
                        Print(buffer);
                        break;
                }
            }
            else if (print_ESC_POS_device is EscPos_Star_TSP100)
            {
                switch (eSet)
                {
                    case eCharacterSet.Slovenia_Croatia:
                        buffer = ep_Star_TSP100.SelectAnInternationalCharacterSet(EscPos_Star_TSP100.eCharacterSet.Slovenia_Croatia); // "\x1b\x1d\x61\x1";             //Center Alignment - Refer to Pg. 3-29
                        //buffer = buffer + "\x5B" + "If loaded.. Logo1 goes here" + "\x5D\n";
                        buffer += ep_Star_TSP100.SelectCharacterCodeTable(EscPos_Star_TSP100.eCodeTable.Codepage_1250);
                        Print(buffer);
                        break;
                    case eCharacterSet.USA:
                        buffer = ep_Star_TSP100.SelectAnInternationalCharacterSet(EscPos_Star_TSP100.eCharacterSet.USA) + ep_RP58.SelectCharacterCodeTable(EscPos_RP58.eCodeTable.CP437_USA_Standard_Europe);
                        Print(buffer);
                        break;
                }
            }

        }

        internal void wr_Paragraph(string s_in)
        {
            string buffer = wordwrap(s_in) + "\n";
            Print(buffer);
        }

        private string wordwrap(string s_in)
        {
            string sline = "";
            string swrapped = "";
            string[] slist = s_in.Split(new char[] { ' ' });
            string sx = null;
            int i = 0;
            int iCount = slist.Count();
            for (i = 0; i < iCount;i++ )
            {
                sx = sline + ' ' + slist[i];
                if (sx.Length < max_char_in_line)
                {
                    sline = sx;
                }
                else
                {
                    sline += "\n";
                    swrapped += sline;
                    sline = "";
                }
            }
            swrapped += sline;
            return swrapped;
        }

        internal void wr_String(string p)
        {
            Print(p);
        }

        internal void wr_NewLine()
        {
            Print("\n");
        }

        internal void wr_NewLine(int iCount)
        {
            int i = 0;
            for (i=0;i<iCount;i++)
            {
                wr_NewLine();
            }
        }

        internal void wr_SetHorizontalTabPositions(byte[] p)
        {
            string buffer = null;
            if (print_ESC_POS_device==null)
            {
                return;
            }
            if (print_ESC_POS_device is EscPos_RP80)
            {
                buffer = ep_RP80.SetHorizontalTabPositions(p);// "\x1b\x44\x2\x10\x22\x0";      //Setting Horizontal Tab - Pg. 3-27
                Print(buffer);
            }
            else if (print_ESC_POS_device is EscPos_RP58)
            {
                buffer = ep_RP58.SetHorizontalTabPositions(p);// "\x1b\x44\x2\x10\x22\x0";      //Setting Horizontal Tab - Pg. 3-27
                Print(buffer);
            }
            else if (print_ESC_POS_device is EscPos_Star_TSP100)
            {
                buffer = ep_Star_TSP100.SetHorizontalTabPositions(p);// "\x1b\x44\x2\x10\x22\x0";      //Setting Horizontal Tab - Pg. 3-27
                Print(buffer);
            }

        }

        internal void wr_LineDelimeter()
        {
            int i = 0;
            string s = "";
            for (i = 0; i < max_char_in_line;i++ )
            {
                s += '-';
            }
            s += '\n';
            Print(s);
        }

        internal void wr_BoldOn()
        {
            string buffer = null;
            if (print_ESC_POS_device==null)
            {
                return;
            }
            if (print_ESC_POS_device is EscPos_RP80)
            {
                buffer = ep_RP80.TurnEmphasizedModeOnOff(EscPos_RP80.eEmphasizedMode.ON);                    //Select Emphasized Printing - Pg. 3-14
                Print(buffer);
            }
            else if (print_ESC_POS_device is EscPos_RP58)
            {
                buffer = ep_RP58.TurnEmphasizedModeOnOff(EscPos_RP58.eEmphasizedMode.ON);                    //Select Emphasized Printing - Pg. 3-14
                Print(buffer);
            }
            else if (print_ESC_POS_device is EscPos_Star_TSP100)
            {
                buffer = ep_Star_TSP100.TurnEmphasizedModeOnOff(EscPos_Star_TSP100.eEmphasizedMode.ON);                    //Select Emphasized Printing - Pg. 3-14
                Print(buffer);
            }
        }

        internal void wr_BoldOff()
        {
            string buffer = null;
            if (print_ESC_POS_device==null)
            {
                return;
            }
            if (print_ESC_POS_device is EscPos_RP80)
            {
                buffer = ep_RP80.TurnEmphasizedModeOnOff(EscPos_RP80.eEmphasizedMode.OFF);
                Print(buffer);
            }
            else if (print_ESC_POS_device is EscPos_RP58)
            {
                buffer = ep_RP58.TurnEmphasizedModeOnOff(EscPos_RP58.eEmphasizedMode.OFF);
                Print(buffer);
            }
            else if (print_ESC_POS_device is EscPos_Star_TSP100)
            {
                buffer = ep_Star_TSP100.TurnEmphasizedModeOnOff(EscPos_Star_TSP100.eEmphasizedMode.OFF);
                Print(buffer);
            }
        }

        internal void PartialCutPaper()
        {
            string buffer = null;
            if (print_ESC_POS_device==null)
            {
                return;
            }
            if (print_ESC_POS_device is EscPos_RP80)
            {
                buffer = ep_RP80.PartialCutPaper();
                Print(buffer);
            }
            else if (print_ESC_POS_device is EscPos_RP58)
            {
                // no cutter
                //buffer = ep_RP80.PartialCutPaper();
            }
            else if (print_ESC_POS_device is EscPos_Star_TSP100)
            {
                buffer = ep_Star_TSP100.PartialCutPaper();
                Print(buffer);
            }
            
        }

        internal bool InitializePrinter()
        {
            string buffer = null;
            if (print_ESC_POS_device == null)
            {
                LogFile.Error.Show("ERROR:Printer:InitializePrinter:print_device == null");
                return false;
            }
            if (print_ESC_POS_device is EscPos_RP80)
            {
                buffer = ep_RP80.InitializePrinter();
                Print(buffer);
            }
            else if (print_ESC_POS_device is EscPos_RP58)
            {
                // no cutter
                buffer = ep_RP80.InitializePrinter();
                Print(buffer);
            }
            else if (print_ESC_POS_device is EscPos_Star_TSP100)
            {
                buffer = ep_Star_TSP100.InitializePrinter();
                Print(buffer);
            }
            else
            {
                LogFile.Error.Show("ERROR:Printer:InitializePrinter:print_device == " + print_ESC_POS_device.GetType().ToString()+ " not supported");
                return false;
            }
            return true;
        }

        private bool Printer_is_ESC_POS()
        {
            string[] esc_pos_printer_ident = new string[] { "RP80", "RP58", "TSP100" };
            foreach (string prn_ident in esc_pos_printer_ident)
            {
                if (PrinterName.Contains(prn_ident))
                {
                    return true;
                }
            }
            return false;
        }

        internal void Print_Receipt_ESC_POS(ID xAtom_WorkPeriod_ID,
                                            InvoiceData xInvoiceData,
                                            string FursD_BussinesPremiseID,
                                            string ElectronicDevice_ID,
                                            int BaseCurrency_DecimalPlaces,
                                            GlobalData.ePaymentType PaymentType, string sPaymentMethod, string sAmountReceived, string sToReturn, DateTime_v issue_time)
        {


            //ReceiptPrinter.Print(ep.InitializePrinter());
            ID journal_docinvoice_id = null;

            try
            {

                if (InitializePrinter())
                {

                }
                if (PrintInBuffer)
                {
                    Clear();
                }

                if (xInvoiceData.MyOrganisation.Logo_Data != null)
                {
                    this.wr_BitmapByteArray570x570imagesize(xInvoiceData.MyOrganisation.Logo_Data);
                }

                wr_SelectAnInternationalCharacterSet(Printer.eCharacterSet.Slovenia_Croatia);
                wr_Paragraph(xInvoiceData.MyOrganisation.Name);
                wr_Paragraph(xInvoiceData.MyOrganisation.Address.StreetName + " " + xInvoiceData.MyOrganisation.Address.HouseNumber);
                wr_Paragraph(xInvoiceData.MyOrganisation.Address.ZIP + " " + xInvoiceData.MyOrganisation.Address.City);
                if (xInvoiceData.MyOrganisation.HomePage != null)
                {
                    if (xInvoiceData.MyOrganisation.HomePage.Length > 0)
                    {
                        wr_String("Domača stran:");
                        wr_SelectAnInternationalCharacterSet(Printer.eCharacterSet.USA);
                        wr_String(xInvoiceData.MyOrganisation.HomePage);
                        wr_SelectAnInternationalCharacterSet(Printer.eCharacterSet.Slovenia_Croatia);
                        wr_NewLine();
                        ;
                    }
                }
                if (xInvoiceData.MyOrganisation.Email != null)
                {
                    if (xInvoiceData.MyOrganisation.Email.Length > 0)
                    {
                        wr_String("EPOŠTA:");
                        wr_SelectAnInternationalCharacterSet(Printer.eCharacterSet.USA);
                        wr_String(xInvoiceData.MyOrganisation.Email);
                        wr_SelectAnInternationalCharacterSet(Printer.eCharacterSet.Slovenia_Croatia);
                    }
                }
                wr_NewLine();
                wr_Paragraph("Davčna Številka:" + xInvoiceData.MyOrganisation.Tax_ID);
                wr_NewLine(2);
                //buffer = buffer + "\x1b\x1d\x61\x0";             //Left Alignment - Refer to Pg. 3-29
                wr_SetHorizontalTabPositions(new byte[] { 2, 0x10, 0x22 });
                wr_Paragraph("Številka računa: " + xInvoiceData.FinancialYear.ToString() + "/" + xInvoiceData.NumberInFinancialYear.ToString());
                wr_Paragraph("Datum:" + xInvoiceData.IssueDate_v.v.Day.ToString() + "." + xInvoiceData.IssueDate_v.v.Month.ToString() + "." + xInvoiceData.IssueDate_v.v.Year.ToString() + "\x9" + " Čas:" + xInvoiceData.IssueDate_v.v.Hour.ToString() + ":" + xInvoiceData.IssueDate_v.v.Minute.ToString());      //Moving Horizontal Tab - Pg. 3-26
                wr_LineDelimeter();
                wr_BoldOn();

                wr_Paragraph("PRODANO:");
                wr_NewLine();
                wr_BoldOff();

                //Select Emphasized Printing - Pg. 3-14;                    //Cancel Emphasized Printing - Pg. 3-14

                taxSum = null;
                taxSum = new StaticLib.TaxSum();

                foreach (ItemSold itmsold in xInvoiceData.ItemsSold)
                {
                    wr_Paragraph(itmsold.Item_Name);
                    wr_String("Cena za enoto" + HT + itmsold.RetailPricePerUnit.ToString() + " EUR\n");
                    decimal TotalDiscount = StaticLib.Func.TotalDiscount(itmsold.Discount, itmsold.ExtraDiscount, BaseCurrency_DecimalPlaces);
                    decimal TotalDiscountPercent = TotalDiscount * 100;
                    if (TotalDiscountPercent > 0)
                    {
                        wr_String("Popust:" + TotalDiscountPercent.ToString() + " %\n");
                    }
                    wr_String("Količina:" + HT + itmsold.dQuantity.ToString() + "\n");
                    if (TotalDiscountPercent > 0)
                    {
                        wr_String("Cena s popustom:" + HT + HT + itmsold.PriceWithTax.ToString() + " EUR\n");
                    }
                    else
                    {
                        wr_String("Cena " + HT + HT + HT + itmsold.PriceWithTax.ToString() + " EUR\n");
                    }
                    wr_String(itmsold.TaxationName + HT + HT + itmsold.TaxPrice.ToString() + " EUR\n");
                    wr_NewLine();
                }

                //foreach (DataRow dr in xInvoiceData.dt_ShopB_Items.Rows)
                //{
                //    object o_SimpleItem_name = dr["Name"];
                //    string SimpleItem_name = null;
                //    if (o_SimpleItem_name.GetType() == typeof(string))
                //    {
                //        SimpleItem_name = (string)o_SimpleItem_name;
                //    }

                //    decimal RetailSimpleItemPrice = 0;
                //    object o_RetailSimpleItemPrice = dr["RetailSimpleItemPrice"];
                //    if (o_RetailSimpleItemPrice.GetType() == typeof(decimal))
                //    {
                //        RetailSimpleItemPrice = (decimal)o_RetailSimpleItemPrice;
                //    }

                //    decimal RetailSimpleItemPriceWithDiscount = 0;
                //    object o_RetailSimpleItemPriceWithDiscount = dr["RetailSimpleItemPriceWithDiscount"];
                //    if (o_RetailSimpleItemPriceWithDiscount.GetType() == typeof(decimal))
                //    {
                //        RetailSimpleItemPriceWithDiscount = (decimal)o_RetailSimpleItemPriceWithDiscount;
                //    }

                //    string TaxationName = "Davek ???";
                //    object oTaxationName = dr["Atom_Taxation_Name"];
                //    if (oTaxationName is string)
                //    {
                //        TaxationName = (string)oTaxationName;
                //    }

                //    decimal TaxPrice = -1;
                //    object oTaxPrice = dr["TaxPrice"];
                //    if (oTaxPrice is decimal)
                //    {
                //        TaxPrice = (decimal)oTaxPrice;
                //        taxSum.Add(TaxPrice, 0, (string)dr["Atom_Taxation_Name"], (decimal)dr["Atom_Taxation_Rate"]);
                //    }

                //    int iQuantity = -1;
                //    object oQuantity = dr["iQuantity"];
                //    if (oQuantity is int)
                //    {
                //        iQuantity = (int)oQuantity;
                //    }

                //    decimal Discount = 0;
                //    object oDiscount = dr["Discount"];
                //    if (oDiscount is decimal)
                //    {
                //        Discount = (decimal)oDiscount;
                //    }

                //    decimal ExtraDiscount = 0;
                //    object oExtraDiscount = dr["ExtraDiscount"];
                //    if (oExtraDiscount is decimal)
                //    {
                //        ExtraDiscount = (decimal)oExtraDiscount;
                //    }

                //    Printer.wr_Paragraph(SimpleItem_name);
                //    Printer.wr_String("Cena za enoto" + HT + RetailSimpleItemPrice.ToString() + " EUR\n");
                //    decimal TotalDiscount = StaticLib.Func.TotalDiscount(Discount, ExtraDiscount, Program.Get_BaseCurrency_DecimalPlaces());
                //    decimal TotalDiscountPercent = TotalDiscount * 100;
                //    if (TotalDiscountPercent > 0)
                //    {
                //        Printer.wr_String("Popust:" + TotalDiscountPercent.ToString() + " %\n");
                //    }
                //    Printer.wr_String("Količina:" + HT + iQuantity.ToString() + "\n");
                //    if (TotalDiscountPercent > 0)
                //    {
                //        Printer.wr_String("Cena s popustom:" + HT + HT + RetailSimpleItemPriceWithDiscount.ToString() + " EUR\n");
                //    }
                //    else
                //    {
                //        Printer.wr_String("Cena " + HT + HT + HT + RetailSimpleItemPriceWithDiscount.ToString() + " EUR\n");
                //    }
                //    Printer.wr_String(TaxationName + HT + HT + TaxPrice.ToString() + " EUR\n");
                //    Printer.wr_NewLine();

                //}

                ////DocInvoice_ShopC_Item.ID AS DocInvoice_ShopC_Item_ID,
                ////DocInvoice_ShopC_Item.DocInvoice_ID,
                ////DocInvoice.Atom_myOrganisation_Person_ID,
                ////DocInvoice_ShopC_Item.Stock_ID,
                ////DocInvoice_ShopC_Item.Atom_Price_Item_ID,
                ////Atom_Item.ID as Atom_Item_ID,
                ////itm.ID as Item_ID,
                ////Atom_Price_Item.RetailPricePerUnit,
                ////Atom_Price_Item.Discount,
                ////DocInvoice_ShopC_Item.RetailPriceWithDiscount,
                ////DocInvoice_ShopC_Item.TaxPrice,
                ////DocInvoice_ShopC_Item.ExtraDiscount,
                ////DocInvoice_ShopC_Item.dQuantity,
                ////DocInvoice_ShopC_Item.ExpiryDate,
                ////Atom_Item.UniqueName AS Atom_Item_UniqueName,
                ////Atom_Item_Name.Name AS Atom_Item_Name_Name,
                ////Atom_Item_barcode.barcode AS Atom_Item_barcode_barcode,
                ////Atom_Taxation.Name AS Atom_Taxation_Name,
                ////Atom_Taxation.Rate AS Atom_Taxation_Rate,
                ////Atom_Item_Description.Description AS Atom_Item_Description_Description,
                ////Atom_Item.Atom_Warranty_ID,
                ////Atom_Warranty.WarrantyDurationType AS Atom_Warranty_WarrantyDurationType,
                ////Atom_Warranty.WarrantyDuration AS Atom_Warranty_WarrantyDuration,
                ////Atom_Warranty.WarrantyConditions AS Atom_Warranty_WarrantyConditions,
                ////Atom_Item.Atom_Expiry_ID,
                ////Atom_Expiry.ExpectedShelfLifeInDays AS Atom_Expiry_ExpectedShelfLifeInDays,
                ////Atom_Expiry.SaleBeforeExpiryDateInDays AS Atom_Expiry_SaleBeforeExpiryDateInDays,
                ////Atom_Expiry.DiscardBeforeExpiryDateInDays AS Atom_Expiry_DiscardBeforeExpiryDateInDays,
                ////Atom_Expiry.ExpiryDescription AS Atom_Expiry_ExpiryDescription,
                ////puitms.Item_ID AS Stock_Item_ID,
                ////Stock.ImportTime AS Stock_ImportTime,
                ////Stock.dQuantity AS Stock_dQuantity,
                ////Stock.ExpiryDate AS Stock_ExpiryDate,
                ////Atom_Unit.Name AS Atom_Unit_Name,
                ////Atom_Unit.Symbol AS Atom_Unit_Symbol,
                ////Atom_Unit.DecimalPlaces AS Atom_Unit_DecimalPlaces,
                ////Atom_Unit.Description AS Atom_Unit_Description,
                ////Atom_Unit.StorageOption AS Atom_Unit_StorageOption,
                ////Atom_PriceList.Name AS Atom_PriceList_Name,
                ////Atom_Currency.Name AS Atom_Currency_Name,
                ////Atom_Currency.Abbreviation AS Atom_Currency_Abbreviation,
                ////Atom_Currency.Symbol AS Atom_Currency_Symbol,
                ////Atom_Currency.DecimalPlaces AS Atom_Currency_DecimalPlaces
                //Printer.wr_NewLine();

                //foreach (DocInvoice_ShopC_Item_Data appisd in xInvoiceData.m_ShopABC.m_CurrentInvoice.m_Basket.DocInvoice_ShopC_Item_Data_LIST)
                //{
                //    string Item_UniqueName = appisd.Atom_Item_UniqueName.v;

                //    decimal RetailPricePerUnit = appisd.RetailPricePerUnit.v;


                //    decimal RetailItemPriceWithDiscount = appisd.RetailPriceWithDiscount.v;

                //    Printer.wr_String(Item_UniqueName + "\n");

                //    decimal dQuantity = appisd.dQuantity_FromStock + appisd.dQuantity_FromFactory;

                //    string Atom_Unit_Name = appisd.Atom_Unit_Name.v;


                //    Printer.wr_String("Cena za 1 " + Atom_Unit_Name + " = " + RetailPricePerUnit.ToString() + " EUR\n");

                //    decimal Discount = appisd.Discount.v;

                //    decimal ExtraDiscount = appisd.ExtraDiscount.v;


                //    decimal TotalDiscount = StaticLib.Func.TotalDiscount(Discount, ExtraDiscount, Program.Get_BaseCurrency_DecimalPlaces());
                //    decimal TotalDiscountPercent = TotalDiscount * 100;
                //    if (TotalDiscountPercent > 0)
                //    {
                //        Printer.wr_String("Popust:" + TotalDiscountPercent.ToString() + " %\n");
                //    }
                //    Printer.wr_String("Količina:" + HT + dQuantity.ToString() + " " + Atom_Unit_Name + "\n");

                //    decimal Atom_Taxation_Rate = appisd.Atom_Taxation_Rate.v;

                //    decimal RetailItemsPriceWithDiscount = 0;
                //    decimal ItemsTaxPrice = 0;
                //    decimal ItemsNetPrice = 0;

                //    int decimal_places = appisd.Atom_Currency_DecimalPlaces.v;

                //    StaticLib.Func.CalculatePrice(RetailPricePerUnit, dQuantity, Discount, ExtraDiscount, Atom_Taxation_Rate, ref RetailItemsPriceWithDiscount, ref ItemsTaxPrice, ref ItemsNetPrice, decimal_places);

                //    if (TotalDiscountPercent > 0)
                //    {
                //        Printer.wr_String("Cena s popustom:" + HT + HT + RetailItemsPriceWithDiscount.ToString() + " EUR\n");
                //    }
                //    else
                //    {
                //        Printer.wr_String("Cena " + HT + HT + HT + RetailItemsPriceWithDiscount.ToString() + " EUR\n");
                //    }

                //    string TaxationName = appisd.Atom_Taxation_Name.v;

                //    decimal TaxPrice = appisd.TaxPrice.v;

                //    taxSum.Add(ItemsTaxPrice, 0, TaxationName, Atom_Taxation_Rate);


                //    Printer.wr_String(TaxationName + HT + HT + ItemsTaxPrice.ToString() + " EUR\n");
                //    Printer.wr_NewLine();

                //}
                wr_LineDelimeter();

                foreach (StaticLib.Tax tax in taxSum.TaxList)
                {
                    wr_String(tax.Name + HT + HT + "" + tax.TaxAmount.ToString() + " EUR\n");
                }

                wr_String("Brez davka " + HT + HT + "" + xInvoiceData.NetSum.ToString() + " EUR\n");
                //buffer += "\x1B" + "G" + "\xFF";
                wr_String("Skupaj " + HT + HT + xInvoiceData.GrossSum.ToString() + " EUR\n");
                //buffer += "\x1B" + "G" + "\x00\n";
                if (PaymentType != GlobalData.ePaymentType.ANY_TYPE)
                {
                    wr_String("Način plačila:" + sPaymentMethod + "\n");
                    if (PaymentType == GlobalData.ePaymentType.CASH)
                    {
                        wr_String("  Prejeto: " + sAmountReceived + " EUR\n");
                        wr_String("  Vrnjeno: " + sToReturn + " EUR\n");
                    }
                }

                wr_NewLine(1);
                wr_String("Številka računa za FURS:\n");
                wr_String(FursD_BussinesPremiseID + "-" + ElectronicDevice_ID + "-" + xInvoiceData.NumberInFinancialYear.ToString());
                wr_NewLine(1);
                wr_String("Oseba, ki je izdala račun:\n");
                wr_String(xInvoiceData.Invoice_Author.FirstName + " " + xInvoiceData.Invoice_Author.LastName);

                if (xInvoiceData.AddOnDI.m_FURS.FURS_QR_v != null)
                {
                    if (xInvoiceData.AddOnDI.m_FURS.FURS_Image_QRcode != null)
                    {
                        //Size size = new Size(32, 32);
                        //Image img_new = StaticLib.Func.resizeImage(xInvoiceData.FURS_Response_Data.Image_QRcode, size, System.Drawing.Imaging.ImageFormat.Bmp, System.Drawing.Imaging.PixelFormat.Format1bppIndexed);
                        //byte[] barr = StaticLib.Func.imageToByteArray(img_new);
                        wr_NewLine(1);
                        wr_String("ZOI:" + xInvoiceData.AddOnDI.m_FURS.FURS_ZOI_v.v + "\n");
                        wr_String("EOR:" + xInvoiceData.AddOnDI.m_FURS.FURS_EOR_v.v + "\n");
                        wr_NewLine(1);
                        byte[] barr = StaticLib.Func.imageToByteArray(xInvoiceData.AddOnDI.m_FURS.FURS_Image_QRcode);
                        wr_BitmapByteArray(barr, 180);
                    }
                }

                wr_NewLine(6);
                PartialCutPaper();

                if (PrintInBuffer)
                {
                    Print_PrinterBuffer();
                }


                string s_journal_invoice_type = lng.s_journal_invoice_type_Print.s;
                string s_journal_invoice_description = PrinterName;
                f_Journal_DocInvoice.Write(xInvoiceData.DocInvoice_ID, xAtom_WorkPeriod_ID, s_journal_invoice_type, s_journal_invoice_description, null, ref journal_docinvoice_id);
            }
            catch (Exception ex)
            {
                string s_journal_invoice_type = lng.s_journal_invoice_type_PrintError.s + PrinterName + "\nErr=" + ex.Message;
                string s_journal_invoice_description = PrinterName;
                f_Journal_DocInvoice.Write(xInvoiceData.DocInvoice_ID, xAtom_WorkPeriod_ID, s_journal_invoice_type, s_journal_invoice_description, null, ref journal_docinvoice_id);
            }
        }

        public bool Init(InvoiceData x_InvoiceData)
        {
            m_InvoiceData = x_InvoiceData;
            //lbl_PrinterName.Text = lng.s_Printer.s;
            PrinterName = printer_settings.PrinterName;
            //lbl_PaperName.Text = lng.s_PaperName.s + ":";
            if (page_settings != null)
            {
                PaperName = page_settings.PaperSize.PaperName;
            }
            else
            {
                PaperName = "??";
            }
            //chk_PrintAll.Text = lng.s_chk_PrintAll.s;
            //this.chk_PrintAll.CheckedChanged -= new System.EventHandler(this.chk_PrintAll_CheckedChanged);
            //chk_PrintAll.Checked = Properties.Settings.Default.PrintAtOnce;
            //ReceiptPrinter.PrintInBuffer = chk_PrintAll.Checked;
            //this.chk_PrintAll.CheckedChanged += new System.EventHandler(this.chk_PrintAll_CheckedChanged);


            if (page_settings != null)
            {
                int iWidth_inHoundreths_of_Inch = page_settings.PaperSize.Width;

                int dpix = page_settings.PrinterResolution.X;

                cx_paper_in_inch = ((float)iWidth_inHoundreths_of_Inch) / ((float)100);
                cx_paper_on_screen_in_pixels = (int)(cx_paper_in_inch * getScalingFactorX());
                //this.pnl_paper.Width = cx_paper_on_screen_in_pixels;

                int iHeight_inHoundreths_of_Inch = page_settings.PaperSize.Height;

                int dpiy = page_settings.PrinterResolution.Y;

                cy_paper_in_inch = ((float)iHeight_inHoundreths_of_Inch) / ((float)100);
                cy_paper_on_screen_in_pixels = (int)(cy_paper_in_inch * getScalingFactorY());
                //this.pnl_paper.Height = cy_paper_on_screen_in_pixels;
            }
            return true;
        }

        private float getScalingFactorX()
        {
            return 1;
            //Graphics g = Graphics.FromHwnd();
            //return g.DpiX;
        }

        private float getScalingFactorY()
        {
            return 1;
            //Graphics g = Graphics.FromHwnd(this.Handle);
            //return g.DpiY;
        }



        internal int Get_CurrencyD_DecimalPlaces()
        {
            if (m_InvoiceData.dt_ShopB_Items.Rows.Count > 0)
            {
                object o_Currency_DecimalPlaces = m_InvoiceData.dt_ShopB_Items.Rows[0]["Atom_Currency_DecimalPlaces"];
                if (o_Currency_DecimalPlaces.GetType() == typeof(int))
                {
                    return (int)o_Currency_DecimalPlaces;
                }
            }
            if (m_InvoiceData.m_ShopABC.m_CurrentDoc.m_Basket.m_DocInvoice_ShopC_Item_Data_LIST.Count > 0)
            {
                object o_Data = m_InvoiceData.m_ShopABC.m_CurrentDoc.m_Basket.m_DocInvoice_ShopC_Item_Data_LIST[0];
                if (o_Data is Atom_DocInvoice_ShopC_Item_Price_Stock_Data)
                {
                    return (int)((Atom_DocInvoice_ShopC_Item_Price_Stock_Data)(o_Data)).Atom_Currency_DecimalPlaces.v;
                }
            }
            if (m_InvoiceData.m_ShopABC.m_CurrentDoc.m_Basket.dtDraft_DocInvoice_Atom_Item_Stock.Rows.Count > 0)
            {
                object o_Currency_DecimalPlaces = m_InvoiceData.m_ShopABC.m_CurrentDoc.m_Basket.dtDraft_DocInvoice_Atom_Item_Stock.Rows[0]["Atom_Currency_DecimalPlaces"];
                if (o_Currency_DecimalPlaces.GetType() == typeof(int))
                {
                    return (int)o_Currency_DecimalPlaces;
                }
            }
            return GlobalData.BaseCurrency.DecimalPlaces;
        }
    }
}
