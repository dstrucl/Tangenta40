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
using System.IO;

namespace TangentaPrint
{
    public class PrintDocInvoice
    {
        private int pagewidth = 0;

        private InvoiceData m_invoiceData = null;
        private string m_printer_name = null;

        private int m_MaxTextLineLength = 80;
        public int MaxTextLineLength
        {
            get {
                return m_MaxTextLineLength;
                }
            set
            {
                m_MaxTextLineLength = value;
            }
        }



        public PrintDocInvoice(string printer_name,InvoiceData invoiceData)
        {
            m_printer_name = printer_name;
            m_invoiceData = invoiceData;
          
        }


        private string sline(char ch)
        {
            return new String(ch, MaxTextLineLength);
        }
        
        public bool Save(Form parentform)
        {
            //    int icount = report.ItemList.Count;
            //    StringBuilder sb = new StringBuilder(3000);
            //    addLine(sb, sline('*'));
            //    addLine(sb, lng.s_IncomeForOrg.s + ":" + report.HeadR.OrganisationName);
            //    addLine(sb, lng.s_OfficeName.s + ":" + report.HeadR.OfficeName);
            //    addLine(sb, lng.s_ElectronicDevice.s + ":" + report.HeadR.ElectronicDevice);
            //    addLine(sb, report.HeadR.From_To);
            //    foreach (StaticLib.Tax tx in report.HeadR.TaxSum.TaxList)
            //    {
            //        addLine(sb, tx.Name + ":" + tx.TaxAmount.ToString());
            //    }
            //    addLine(sb, lng.s_TaxTotal.s + ":" + report.HeadR.TaxTotal.ToString());
            //    addLine(sb, lng.s_NetSum.s + ":" + report.HeadR.NetSum.ToString());
            //    addLine(sb, lng.s_Total.s + ":" + report.HeadR.Total.ToString());
            //    addLine(sb, lng.s_NumberOfInvoices.s + ":" + report.HeadR.NumberOfInvoices.ToString());
            //    foreach (TangentaDB.Report.PaymentType pt in report.HeadR.PaymentTypeList.items)
            //    {
            //        addLine(sb, pt.Name + ":" + pt.Count.ToString());
            //        addLine(sb, pt.Name + " Osnova:" + pt.Net.ToString());
            //        addLine(sb, pt.Name + " Obračunani DDV:" + pt.TaxTotal.ToString());
            //        addLine(sb, pt.Name + " Skupaj z DDV:" + pt.Total.ToString());
            //    }

            //    string underLine = null;
            //    if (PrintSingleInvoices)
            //    {
            //        for (int i = 0; i < icount; i++)
            //        {
            //            int iInv = i + 1;
            //            underLine = iInv.ToString() + " -----------------------------------";
            //            addLine(sb, underLine);
            //            Report.Item itm = report.ItemList[i];
            //            addLine(sb, lng.s_InvoiceNumber.s + ":" + itm.InvoiceNumber);
            //            addLine(sb, lng.s_IssueTime.s + ":" + itm.IssueTime);
            //            StaticLib.TaxSum tsum = itm.TaxSum;
            //            foreach (StaticLib.Tax tax in tsum.TaxList)
            //            {
            //                addLine(sb, tax.Name + ":" + tax.TaxAmount.ToString());
            //            }

            //            addLine(sb, lng.s_TaxTotal.s + ":" + tsum.Value.ToString());

            //            //Offset = Offset + OFS;
            //            //graphics.DrawString(lng.s_TaxTotalcheck.s + ":" + itm.TaxTotal.ToString(), myFont1, new SolidBrush(Color.Black), startX, startY + Offset);

            //            addLine(sb, lng.s_NetSum.s + ":" + itm.NetSum.ToString());

            //            addLine(sb, lng.s_Total.s + ":" + itm.Total.ToString());

            //            addLine(sb, lng.s_MethodOfPayment.s + ":" + itm.MethodOfPayment);

            //            addLine(sb, lng.s_IssuerPerson.s + ":" + itm.IssuerPerson);
            //        }
            //    }
            //    else
            //    {
            //        underLine = " -----------------------------------";
            //        addLine(sb, underLine);
            //    }
            //    string textFileName = "??";
            //    try
            //    {
            //        SaveFileDialog sfd = new SaveFileDialog();
            //        string s1 = report.HeadR.From_To.Replace(' ', '_');
            //        string s2 = s1.Replace('.', '-');
            //        string s3 = s2.Replace(':', '_');
            //        sfd.FileName = "TangentaReport"+s3+".txt";
            //        if (sfd.ShowDialog(parentform) == DialogResult.OK)
            //        {
            //            textFileName = sfd.FileName;
            //            File.WriteAllText(textFileName, sb.ToString(), Encoding.UTF8);
            //        }
            //        return true;
            //    }
            //    catch (Exception ex)
            //    {
            //        LogFile.Error.Show("ERROR:TangentaPrint:PrintReport:Save:Can not write to file ='" + textFileName + "'\r\nException=" + ex.Message);
            //        return false;
            //    }
            //}
            //else
            //{
            //    return false;
            //}
            return false;
        }

        private void addLine(StringBuilder sb, string s)
        {
            sb.Append(s + "\r\n");
        }

        public bool Print(Control powner)
        {
                PrintDocument pdoc = new PrintDocument();

                PrinterSettings ps = new PrinterSettings();

                if (m_printer_name!=null)
                {
                    ps.PrinterName = m_printer_name;// (string)PrintersList.dt.Rows[0][PrintersList.dcol_PrinterName.ColumnName];
                    Font font = new Font("Courier New", 15);

                    //PaperSize psize = new PaperSize("Custom", 100, 200);
                    //ps.DefaultPageSettings.PaperSize = psize;

                    pdoc.PrinterSettings = ps;

                    pdoc.DocumentName = "Tangenta Invoice"; ;
                    //pd.Document = pdoc;
                    //pd.Document.DefaultPageSettings.PaperSize = psize;
                    //pdoc.DefaultPageSettings.PaperSize.Height =320;
                    //pdoc.DefaultPageSettings.PaperSize.Height = 820;

                    //pdoc.DefaultPageSettings.PaperSize.Width = 520;

                    pdoc.PrintPage += new PrintPageEventHandler(pdoc_PrintPage);

                    pagewidth = pdoc.PrinterSettings.DefaultPageSettings.PaperSize.Width;
                    pdoc.Print();
                }
                else
                {
                    print_with_printer_selection(powner,pdoc);
                }
                return true;
        }

        private void print_with_printer_selection(Control powner,PrintDocument pdoc)
        {
            Font font = new Font("Courier New", 15);
            pdoc.DocumentName = "Tangenta Invoice"; ;
            PrintDialog pd = new PrintDialog();
            pdoc.PrintPage += new PrintPageEventHandler(pdoc_PrintPage);
            pd.Document = pdoc;
            DialogResult result = pd.ShowDialog(powner);
            if (result == DialogResult.OK)
            {
                pagewidth = pdoc.PrinterSettings.DefaultPageSettings.PaperSize.Width;
                PrintPreviewDialog pp = new PrintPreviewDialog();
                pp.Document = pd.Document;
                result = pp.ShowDialog(powner);
                if (result == DialogResult.OK)
                {
                    pdoc.Print();
                }
            }
        }

        void pdoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            int OFS = 18;
            int OFS1 = 8;
            int OFS2 = 16;

            Graphics graphics = e.Graphics;
            Font font = new Font("Courier New", 10);

            Pen pen1 = new Pen(Color.Black, 1);
            Pen pen2 = new Pen(Color.Black, 2);
            Pen pen3 = new Pen(Color.Black, 3);
            float fontHeight = font.GetHeight();
            float startX = 0;
            float startY = 35;
            float Offset = 40;

            Font fArial8 = new Font(familyName: "Arial", emSize: 8, style: FontStyle.Bold);
            Font fArial8r = new Font(familyName: "Arial", emSize: 8, style: FontStyle.Regular);
            Font fArial9 = new Font(familyName: "Arial", emSize: 9, style: FontStyle.Bold);
            Font fArial12 = new Font(familyName: "Arial", emSize: 12, style: FontStyle.Bold);
            Font fCurierNew14 = new Font("Courier New", 14);

            //String underLine = "****************************************";
            //Offset = Offset + OFS;
            //graphics.DrawString(underLine, fArial10, new SolidBrush(Color.Black), startX, startY + Offset);
            //graphics.DrawLine(pen3, fArial10, new SolidBrush(Color.Black), startX, startY + Offset);

            Offset = Offset + OFS;
           // string stocktake_ID = "";
           
            graphics.DrawImage(Properties.Resources.Tangenta_Logo1colorH32, startX, startY + Offset);
            graphics.DrawString(lng.s_DocInvoice.s + ":", fArial12, new SolidBrush(Color.Black), startX + 8, startY + Offset + 8);
            Offset = Offset + OFS+32;
            //graphics.DrawString(lng.s_STOCKTAKE_ID.s + ":" + stocktake_ID, fArial12, new SolidBrush(Color.Black), startX, startY + Offset);
            //Offset = Offset + OFS;
            //string sdate = LanguageControl.DynSettings.SetLanguageDateString(m_stocktaketime);
            //graphics.DrawString(lng.s_Date.s + ":" + sdate, fArial9, new SolidBrush(Color.Black), startX, startY + Offset);
            //Offset = Offset + OFS;
            //graphics.DrawString(lng.s_Supplier.s + ":" + m_supplier, fArial9, new SolidBrush(Color.Black), startX, startY + Offset);
            //Offset = Offset + OFS;
            //graphics.DrawString(lng.s_SupplierTaxID.s + ":" + m_supplierTaxID, fArial9, new SolidBrush(Color.Black), startX, startY + Offset);
            //Offset = Offset + OFS;
            //graphics.DrawString(lng.s_Buyer.s + ":" + m_buyer, fArial9, new SolidBrush(Color.Black), startX, startY + Offset);
            //Offset = Offset + OFS;
            //graphics.DrawString(lng.s_BuyerTaxID.s + ":" + m_buyerTaxID, fArial9, new SolidBrush(Color.Black), startX, startY + Offset);
            //Offset = Offset + OFS;
            //graphics.DrawString(lng.s_DeliveryNumber.s + ":" + m_deliverynumber, fArial9, new SolidBrush(Color.Black), startX, startY + Offset);

            //Offset = Offset + OFS+OFS/2;
            //graphics.DrawString(lng.s_Item.s + "/", fArial9, new SolidBrush(Color.Black), startX, startY + Offset);
            //Global.g.DrawStringAlignRight(graphics,lng.s_Amount.s + " "+GlobalData.BaseCurrency.Abbreviation, fArial9, Color.Black, startX + pagewidth, startY + Offset);

            //Offset = Offset + OFS;
            //graphics.DrawString(lng.s_Quantity.s, fArial9, new SolidBrush(Color.Black), startX, startY + Offset);
            //graphics.DrawString(lng.s_VAT.s, fArial9, new SolidBrush(Color.Black), startX + (pagewidth*34)/60, startY + Offset);
            //Global.g.DrawStringAlignRight(graphics, lng.s_without_VAT.s, fArial9, Color.Black, startX + pagewidth, startY + Offset);

            ////underLine = "---------------------------------------";
            ////Offset = Offset + OFS;
            ////graphics.DrawString(underLine, fArial10, new SolidBrush(Color.Black), startX, startY + Offset);
            //Offset = Offset + OFS+ OFS/5;
            //graphics.DrawLine(pen1, startX, startY + Offset, startX+pagewidth, startY + Offset);

            //decimal dTotalAllWithoutTaxWithDiscount = 0;
            //StaticLib.TaxSum taxSum = new StaticLib.TaxSum();
            //int n = 1;
            //foreach (DataRow dr in m_dt_Stock_Of_Current_StockTake.Rows)
            //{

            //    string_v item_name_v = tf.set_string(dr["UniqueName"]);
            //    string sitem = "";
            //    if (item_name_v!=null)
            //    {
            //        sitem = item_name_v.v;
            //        Offset = Offset + OFS2;
                    
            //        graphics.DrawString("(" + n.ToString() + ") ", fArial8r, new SolidBrush(Color.Black), startX, startY + Offset);
            //        float ofsx = 0;
            //        Global.g.DrawWordWrap(graphics, sitem, fArial9, Color.Black, startX+(pagewidth*6)/60, startY + Offset, pagewidth, ref ofsx);
            //        decimal_v dQuantity_v = tf.set_decimal(dr["dQuantity"]);
            //        string sQUantity = "";
            //        if (dQuantity_v!=null)
            //        {
            //            sQUantity = dQuantity_v.v.ToString();
            //        }
            //        string_v sUnitSymbol_v = tf.set_string(dr["UnitSymbol"]);
            //        string sUnitSymbol = "";
            //        if (sUnitSymbol_v!=null)
            //        {
            //            sUnitSymbol = sUnitSymbol_v.v;
            //        }


            //        decimal_v dPurchasePricePerUnit_v = tf.set_decimal(dr["PurchasePricePerUnit"]);
            //        string sPurchasePricePerUnit = "";
            //        if (dPurchasePricePerUnit_v!=null)
            //        {
            //            sPurchasePricePerUnit = LanguageControl.DynSettings.SetLanguageCurrencyString(dPurchasePricePerUnit_v.v, GlobalData.BaseCurrency.DecimalPlaces, null);
            //        }

            //        string spercent = "0";
            //        decimal_v dDisount_v =  tf.set_decimal(dr["Discount"]);
            //        if (dDisount_v != null)
            //        {
            //            spercent = Global.f.GetPercent(dDisount_v.v,2);
            //        }

            //        Offset = Offset + ofsx+2;
            //        graphics.DrawString(sQUantity + " "+ sUnitSymbol+" x "+ sPurchasePricePerUnit + "(-"+spercent+"%)", fArial9, new SolidBrush(Color.Black), startX, startY + Offset);

            //        string staxrate = "";
            //        decimal dTaxRate = 0;
            //        decimal_v dTaxRate_v = tf.set_decimal(dr["TaxationRate"]);
            //        if (dTaxRate_v!=null)
            //        {
            //            dTaxRate = dTaxRate_v.v;
            //            staxrate = Global.f.GetPercent(dTaxRate_v.v,1) + "%";
            //        }
            //        Global.g.DrawStringAlignRight(graphics, staxrate, fArial9, Color.Black, startX + (pagewidth * 44) / 60, startY + Offset);

            //        string sdTotalWithoutTaxWithDiscount = "";
            //        decimal dTotalWithoutTaxWithDiscount = 0;
            //        decimal_v dTotalWithoutTaxWithDiscount_v = tf.set_decimal(dr["TotalWithoutTaxWithDiscount"]);
            //        if (dTotalWithoutTaxWithDiscount_v!=null)
            //        {
            //            dTotalWithoutTaxWithDiscount = dTotalWithoutTaxWithDiscount_v.v;
            //            dTotalAllWithoutTaxWithDiscount += dTotalWithoutTaxWithDiscount_v.v;
            //            sdTotalWithoutTaxWithDiscount = LanguageControl.DynSettings.SetLanguageCurrencyString(dTotalWithoutTaxWithDiscount_v.v, GlobalData.BaseCurrency.DecimalPlaces, null);
            //        }
            //        Global.g.DrawStringAlignRight(graphics, sdTotalWithoutTaxWithDiscount, fArial9, Color.Black, startX + pagewidth, startY + Offset);

            //        decimal dtax = dTotalWithoutTaxWithDiscount * dTaxRate;
            //        taxSum.Add(dtax,dTotalWithoutTaxWithDiscount, staxrate, dTaxRate);
            //        n++;
            //        Offset = Offset + OFS1;
            //    }

            //}
            ////Offset = Offset + OFS;
            ////graphics.DrawString(underLine, fArial10, new SolidBrush(Color.Black), startX, startY + Offset);
            //Offset = Offset + OFS + OFS / 5;
            //graphics.DrawLine(pen1, startX, startY + Offset, startX + pagewidth, startY + Offset);

            //dTotalAllWithoutTaxWithDiscount = decimal.Round(dTotalAllWithoutTaxWithDiscount, GlobalData.BaseCurrency.DecimalPlaces);
            //string sdTotalAllWithoutTaxWithDiscount = LanguageControl.DynSettings.SetLanguageCurrencyString(dTotalAllWithoutTaxWithDiscount, GlobalData.BaseCurrency.DecimalPlaces, null);

            //Offset = Offset + OFS;
            //graphics.DrawString(lng.s_Total_without_VAT.s + ":", fArial9, new SolidBrush(Color.Black), startX, startY + Offset);
            //Global.g.DrawStringAlignRight(graphics, sdTotalAllWithoutTaxWithDiscount, fArial9, Color.Black, startX + pagewidth, startY + Offset);

            //decimal dTaxTotal = 0;
            //foreach (StaticLib.Tax tax in taxSum.TaxList)
            //{
            //    Offset = Offset + OFS;
            //    graphics.DrawString(lng.s_Plus_VAT.s + " " + tax.Name + " " + lng.s_From_Base.s + " " + sdTotalAllWithoutTaxWithDiscount, fArial9, new SolidBrush(Color.Black), startX, startY + Offset);
            //    dTaxTotal += tax.TaxAmount;
            //    decimal dTaxBase = decimal.Round(tax.TaxAmount, GlobalData.BaseCurrency.DecimalPlaces);
            //    string sdTax = LanguageControl.DynSettings.SetLanguageCurrencyString(dTaxBase, GlobalData.BaseCurrency.DecimalPlaces, null);
            //    Global.g.DrawStringAlignRight(graphics, sdTax, fArial9, Color.Black, startX + pagewidth, startY + Offset);
            //}
            //Offset = Offset + OFS;
            //graphics.DrawString(lng.s_Total_with_VAT.s + ":", fArial9, new SolidBrush(Color.Black), startX, startY + Offset);
            //dTaxTotal = decimal.Round(dTaxTotal, GlobalData.BaseCurrency.DecimalPlaces);
            //decimal dAllTotal = dTaxTotal + dTotalAllWithoutTaxWithDiscount;
            //string sdTaxTotal = LanguageControl.DynSettings.SetLanguageCurrencyString(dAllTotal, GlobalData.BaseCurrency.DecimalPlaces, null);
            //Global.g.DrawStringAlignRight(graphics, sdTaxTotal, fArial9, Color.Black, startX + pagewidth, startY + Offset);


            ////dr["dInitialQuantity"]
            //decimal_v dTotalWithTaxWithDiscount_v = tf.set_decimal(dr["TotalWithTaxWithDiscount"]);
            //string_v taxation_name_v = tf.set_string(dr["TaxationName"]);
            ////dr["ImportTime"]
            ////dr["ExpiryDate"]
            //string_v supplier_v = tf.set_string(dr["Supplier"]);
            ////dr["Symbol"]
        }
    }
}
