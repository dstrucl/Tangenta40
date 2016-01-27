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


namespace Tangenta
{
    public class Printer
    {
        public enum eCharacterSet { Slovenia_Croatia, USA };
        public bool m_PrintInBuffer = false;
        private string PrintBuffer = null;

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

        int max_char_in_line = 58;
        EscPos_RP58 ep_RP58 = new EscPos_RP58();
        EscPos_RP80 ep_RP80 = new EscPos_RP80();
        EscPos_Star_TSP100 ep_Star_TSP100 = new EscPos_Star_TSP100();
        object print_ESC_POS_device = null;
        private string m_PrinterName = "";


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
                        //string s= lngRPM.s_PrinterNotSuported.s;
                        //string sMsg = s.Replace("%%%",pname);
                        //MessageBox.Show(sMsg);
                        }
                    }
                    m_PrinterName = pname;
                }

        }
         
        private PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();
        public PrintDocument printDocument = null;
        public PrinterSettings printer_settings = new PrinterSettings();
        public PageSettings page_settings = null;

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

           // streamToPrint = new StreamReader("D:\\DOS\\MyFile.txt");

           // try 
           //{

           // PrintDocument pd = new PrintDocument();

           // pd.PrinterSettings = printer_settings;
           // pd.PrintPage += new PrintPageEventHandler(pd_PrintPage);
           // pd.Print();
           //}
           // finally
           // {
           //     streamToPrint.Close();
           // }

        }

       


        public bool Select(Form frm)
        {
            PrintDialog printDialog = new PrintDialog();
            printDialog.ShowNetwork = true;
            if (printDialog.ShowDialog() == DialogResult.OK)
            {

                PrinterName = printDialog.PrinterSettings.PrinterName;
                printer_settings = printDialog.PrinterSettings;
                Properties.Settings.Default.ReceiptPrinter = PrinterName;
                Properties.Settings.Default.Save();
                RawPrinterHelper.SetDefaultPrinter(PrinterName);
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
            Properties.Settings.Default.PageSettings_Landscape = page_settings.Landscape;
            Properties.Settings.Default.PageSettings_Color = page_settings.Color;
            Properties.Settings.Default.PageSettings_HardMarginX = page_settings.HardMarginX;
            Properties.Settings.Default.PageSettings_HardMarginY = page_settings.HardMarginY;
            Properties.Settings.Default.PageSettings_PaperSize_Width = page_settings.PaperSize.Width;
            Properties.Settings.Default.PageSettings_PaperSize_Height = page_settings.PaperSize.Height;
            Properties.Settings.Default.PageSettings_PaperSize_PaperName = page_settings.PaperSize.PaperName;
            Properties.Settings.Default.PageSettings_PaperSize_RawKind = (int)page_settings.PaperSize.RawKind;
            Properties.Settings.Default.PageSettings_PaperSource_RawKind = page_settings.PaperSource.RawKind;
            Properties.Settings.Default.PageSettings_PaperSource_SourceName = page_settings.PaperSource.SourceName;
            Properties.Settings.Default.PageSettings_PrinterResolution_X = page_settings.PrinterResolution.X;
            Properties.Settings.Default.PageSettings_PrinterResolution_Y = page_settings.PrinterResolution.Y;
            Properties.Settings.Default.PageSettings_PrinterResolution_Kind = (int)page_settings.PrinterResolution.Kind;
            Properties.Settings.Default.Save();
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
                        string paper_name = Properties.Settings.Default.PageSettings_PaperSize_PaperName;

                        foreach (PaperSize psize in printer_settings.PaperSizes)
                        {
                            if (psize.PaperName.Equals(paper_name))
                            {
                                pgset.PaperSize = psize;
                                break;
                            }
                        }
                        pgset.Landscape = Properties.Settings.Default.PageSettings_Landscape;
                        pgset.Color = Properties.Settings.Default.PageSettings_Color;
                        pgset.PaperSource.SourceName = Properties.Settings.Default.PageSettings_PaperSource_SourceName;
                        pgset.PaperSource.RawKind = Properties.Settings.Default.PageSettings_PaperSource_RawKind;
                        pgset.PrinterResolution.X = Properties.Settings.Default.PageSettings_PrinterResolution_X;
                        pgset.PrinterResolution.Y = Properties.Settings.Default.PageSettings_PrinterResolution_Y;
                        pgset.PrinterResolution.Kind = (PrinterResolutionKind)Properties.Settings.Default.PageSettings_PrinterResolution_Kind;
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

        public bool Define(Form frm)
        {
            string pname = Properties.Settings.Default.ReceiptPrinter;
            PrinterName = FindPrinter(pname); ;
            PageSettings pgset = null;
            if (ReadPageSettings(ref pgset))
            {
                page_settings = pgset;
            }
            if ((PrinterName == null)||(page_settings==null))
            {
                MessageBox.Show(frm, lngRPM.s_Printer.s + ":" + Properties.Settings.Default.ReceiptPrinter + lngRPM.s_NotInPrinterList.s + "\r\n" + lngRPM.s_SelectReceiptPrinter.s);
                if (Select(frm))
                {
                     return DefinePage(frm);
                }
                else
                {
                    return false;
                }
            }
            else
            {
                printer_settings.PrinterName = PrinterName;
                return true;
            }
        }

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
    }
}
