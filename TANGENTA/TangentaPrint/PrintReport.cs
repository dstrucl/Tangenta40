using DBConnectionControl40;
using DBTypes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TangentaDB;
using Tangenta_DefaultPrintTemplates;
using System.Windows.Forms;
using static TangentaPrint.Report;

namespace TangentaPrint
{
    public class PrintReport
    {

        private Report report = null;

        private string sTimeSpan = null;
        private DateTime_v dt1_v = null;
        private DateTime_v dt2_v = null;
        private DataTable m_dt_XInvoice = null;

        public PrintReport(DataTable x_dt_XInvoice,
                           string xsTimeSpan,
                           DateTime_v xdt1_v,
                           DateTime_v xdt2_v)
        {
            m_dt_XInvoice = x_dt_XInvoice;
            sTimeSpan = xsTimeSpan;
            dt1_v = xdt1_v;
            dt2_v = xdt2_v;
        }

        public bool Print()
        {
            report  = new Report(sTimeSpan, dt1_v, dt2_v);
            if (report.Get(m_dt_XInvoice))
            { 
              
                PrintDocument pdoc = new PrintDocument();

                PrinterSettings ps = new PrinterSettings();

                if (PrintersList.dt.Rows.Count > 0)
                {
                    string sPrinterName = (string)PrintersList.dt.Rows[0][PrintersList.dcol_PrinterName.ColumnName];
                    ps.PrinterName = sPrinterName;// (string)PrintersList.dt.Rows[0][PrintersList.dcol_PrinterName.ColumnName];
                    Font font = new Font("Courier New", 15);

                    //PaperSize psize = new PaperSize("Custom", 100, 200);
                    //ps.DefaultPageSettings.PaperSize = psize;

                    pdoc.PrinterSettings = ps;

                    pdoc.DocumentName = "Tangenta Report"; ;
                    //pd.Document = pdoc;
                    //pd.Document.DefaultPageSettings.PaperSize = psize;
                    //pdoc.DefaultPageSettings.PaperSize.Height =320;
                    //pdoc.DefaultPageSettings.PaperSize.Height = 820;

                    //pdoc.DefaultPageSettings.PaperSize.Width = 520;

                    pdoc.PrintPage += new PrintPageEventHandler(pdoc_PrintPage);

                    pdoc.Print();
                }
                else
                {
                    Font font = new Font("Courier New", 15);
                    pdoc.DocumentName = "Tangenta Report"; ;
                    PrintDialog pd = new PrintDialog();
                    pd.Document = pdoc;
                    DialogResult result = pd.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        PrintPreviewDialog pp = new PrintPreviewDialog();
                        pp.Document = pd.Document;
                        result = pp.ShowDialog();
                        if (result == DialogResult.OK)
                        {
                            pdoc.Print();
                        }
                    }
                }
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:TangentaPrint:PrintReport:Print: m_dt_XInvoice==null");
                return false;
            }
        }

        void pdoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            int OFS = 18;
            Graphics graphics = e.Graphics;
            Font font = new Font("Courier New", 10);
            float fontHeight = font.GetHeight();
            int startX = 0;
            int startY = 55;
            int Offset = 40;
            int icount = report.ItemList.Count;
            Font myFont1 = new Font("Courier New", 10, FontStyle.Bold);
            Font myFont2 = new Font("Courier New", 14);
            String underLine = "****************";
            Offset = Offset + OFS;
            graphics.DrawString(underLine, myFont1, new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + OFS;
            graphics.DrawString(lng.s_IncomeForOrg.s + ":" + report.HeadR.OrganisationName, myFont1, new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + OFS;
            graphics.DrawString(lng.s_OfficeName.s + ":" + report.HeadR.OfficeName, myFont1, new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + OFS;
            graphics.DrawString(lng.s_ElectronicDevice.s + ":" + report.HeadR.ElectronicDevice, myFont1, new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + OFS;
            graphics.DrawString(report.HeadR.From_To, myFont1, new SolidBrush(Color.Black), startX, startY + Offset);
            foreach (StaticLib.Tax tx in report.HeadR.TaxSum.TaxList)
            {
                Offset = Offset + OFS;
                graphics.DrawString(tx.Name + ":" + tx.TaxAmount.ToString(), myFont1, new SolidBrush(Color.Black), startX, startY + Offset);
            }
            Offset = Offset + OFS;
            graphics.DrawString(lng.s_TaxTotal.s + ":" + report.HeadR.TaxTotal.ToString(), myFont1, new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + OFS;
            graphics.DrawString(lng.s_NetSum.s + ":" + report.HeadR.NetSum.ToString(), myFont1, new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + OFS;
            graphics.DrawString(lng.s_Total.s + ":" + report.HeadR.Total.ToString(), myFont1, new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + OFS;
            graphics.DrawString(lng.s_NumberOfInvoices.s + ":" + report.HeadR.NumberOfInvoices.ToString(), myFont1, new SolidBrush(Color.Black), startX, startY + Offset);
            foreach (PaymentType pt in report.HeadR.PaymentTypeList.items)
            {
                Offset = Offset + OFS;
                graphics.DrawString(pt.Name + ":" + pt.Count.ToString(), myFont1, new SolidBrush(Color.Black), startX, startY + Offset);
            }

            for (int i=0;i< icount;i++)
            {
                Offset = Offset + OFS;
                int iInv = i + 1;
                underLine = iInv.ToString()+ " -----------------------------------";
                graphics.DrawString(underLine, myFont1, new SolidBrush(Color.Black), startX, startY + Offset);
                Report.Item itm= report.ItemList[i];
                Offset = Offset + OFS;
                graphics.DrawString(lng.s_InvoiceNumber.s+":" + itm.InvoiceNumber, myFont1, new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + OFS;
                graphics.DrawString(lng.s_IssueTime.s + ":" + itm.IssueTime, myFont1, new SolidBrush(Color.Black), startX, startY + Offset);

                StaticLib.TaxSum tsum = itm.TaxSum;
                foreach (StaticLib.Tax tax in tsum.TaxList)
                {
                    Offset = Offset + OFS;
                    graphics.DrawString(tax.Name +":"+ tax.TaxAmount.ToString(), myFont1, new SolidBrush(Color.Black), startX, startY + Offset);
                }

                Offset = Offset + OFS;
                graphics.DrawString(lng.s_TaxTotal.s +":"+ tsum.Value.ToString(), myFont1, new SolidBrush(Color.Black), startX, startY + Offset);

                //Offset = Offset + OFS;
                //graphics.DrawString(lng.s_TaxTotalcheck.s + ":" + itm.TaxTotal.ToString(), myFont1, new SolidBrush(Color.Black), startX, startY + Offset);

                Offset = Offset + OFS;
                graphics.DrawString(lng.s_NetSum.s + ":" + itm.NetSum.ToString(), myFont1, new SolidBrush(Color.Black), startX, startY + Offset);

                Offset = Offset + OFS;
                graphics.DrawString(lng.s_Total.s + ":" + itm.Total.ToString(), myFont1, new SolidBrush(Color.Black), startX, startY + Offset);

                Offset = Offset + OFS;
                graphics.DrawString(lng.s_MethodOfPayment.s + ":" + itm.MethodOfPayment, myFont1, new SolidBrush(Color.Black), startX, startY + Offset);

                Offset = Offset + OFS;
                graphics.DrawString(lng.s_IssuerPerson.s + ":" + itm.IssuerPerson, myFont1, new SolidBrush(Color.Black), startX, startY + Offset);

            }

            //graphics.DrawString("Ticket No:" + this.TicketNo, new Font("Courier New", 14), new SolidBrush(Color.Black), startX, startY + Offset);
            //Offset = Offset + 20;
            //graphics.DrawString("Ticket Date :" + this.ticketDate, new Font("Courier New", 12), new SolidBrush(Color.Black), startX, startY + Offset);
            //Offset = Offset + 20;
            //String underLine = "------------------------------------------";
            //graphics.DrawString(underLine, new Font("Courier New", 10), new SolidBrush(Color.Black), startX, startY + Offset);

            //Offset = Offset + 20;
            //String Source = this.source;
            //graphics.DrawString("From " + Source + " To " + Destination, new Font("Courier New", 10), new SolidBrush(Color.Black), startX, startY + Offset);

            //Offset = Offset + 20;
            //String Grosstotal = "Total Amount to Pay = " + this.amount;

            //Offset = Offset + 20;
            //underLine = "------------------------------------------";
            //graphics.DrawString(underLine, new Font("Courier New", 10), new SolidBrush(Color.Black), startX, startY + Offset);
            //Offset = Offset + 20;

            //graphics.DrawString(Grosstotal, new Font("Courier New", 10), new SolidBrush(Color.Black), startX, startY + Offset);
            //Offset = Offset + 20;
            //String DrawnBy = this.drawnBy;
            // graphics.DrawString("Conductor - " + DrawnBy, new Font("Courier New", 10), new SolidBrush(Color.Black), startX, startY + Offset);
        }
    }
}
