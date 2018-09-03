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
    public class PrintStockTake
    {
        private int pagewidth = 0;

        private ID m_stocktake_ID = null;
        private string m_stocktakename = null;
        private DateTime m_stocktaketime = new DateTime();
        private string m_supplier = null;
        private string m_supplierTaxID = null;
        private string m_buyer = null;
        private string m_buyerTaxID = null;
        private string m_deliverynumber = null;
        private DataTable m_dt_Stock_Of_Current_StockTake = null;

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



        public PrintStockTake(ID stocktake_ID,
                             string stocktakename,
                             DateTime stocktaketime,
                             string supplier,
                             string supplierTaxID,
                             string buyer,
                             string buyerTaxID,
                             string deliverynumber,
                             DataTable xdt_Stock_Of_Current_StockTake)
        {
            m_stocktake_ID = stocktake_ID;
            m_stocktakename = stocktakename;
            m_stocktaketime = stocktaketime;
            m_supplier = supplier;
            m_supplierTaxID = supplierTaxID;
            m_buyer = buyer;
            m_buyerTaxID = buyerTaxID;
            m_deliverynumber = deliverynumber;
            m_dt_Stock_Of_Current_StockTake = xdt_Stock_Of_Current_StockTake;
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

                if (PrintersList.dt.Rows.Count > 0)
                {
                    string sPrinterName = (string)PrintersList.dt.Rows[0][PrintersList.dcol_PrinterName.ColumnName];
                    if (PrintersList.IsPrinterConnected(sPrinterName))
                    {
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

                        pagewidth = pdoc.PrinterSettings.DefaultPageSettings.PaperSize.Width;
                        pdoc.Print();
                    }
                    else
                    {
                        print_with_printer_selection(powner,pdoc);
                    }
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
            pdoc.DocumentName = "Tangenta Report"; ;
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
            Graphics graphics = e.Graphics;
            Font font = new Font("Courier New", 10);
            float fontHeight = font.GetHeight();
            int startX = 0;
            int startY = 55;
            int Offset = 40;
            int icount = m_dt_Stock_Of_Current_StockTake.Rows.Count;
            Font fArial10 = new Font(familyName: "Arial", emSize: 9, style: FontStyle.Bold);
            Font fCurierNew14 = new Font("Courier New", 14);
            String underLine = "****************";
            Offset = Offset + OFS;
            graphics.DrawString(underLine, fArial10, new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + OFS;
            string stocktake_ID = "";
            if (ID.Validate(m_stocktake_ID))
            {
                stocktake_ID = m_stocktake_ID.ToString();
            }
            graphics.DrawString(lng.s_STOCKTAKE.s + ":" + m_stocktakename, fArial10, new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + OFS;
            graphics.DrawString(lng.s_STOCKTAKE_ID.s + ":" + stocktake_ID, fArial10, new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + OFS;
            string sdate = LanguageControl.DynSettings.SetLanguageDateString(m_stocktaketime);
            graphics.DrawString(lng.s_Date.s + ":" + sdate, fArial10, new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + OFS;
            graphics.DrawString(lng.s_Supplier.s + ":" + m_supplier, fArial10, new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + OFS;
            graphics.DrawString(lng.s_SupplierTaxID.s + ":" + m_supplierTaxID, fArial10, new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + OFS;
            graphics.DrawString(lng.s_Buyer.s + ":" + m_buyer, fArial10, new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + OFS;
            graphics.DrawString(lng.s_BuyerTaxID.s + ":" + m_buyerTaxID, fArial10, new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + OFS;
            graphics.DrawString(lng.s_DeliveryNumber.s + ":" + m_deliverynumber, fArial10, new SolidBrush(Color.Black), startX, startY + Offset);

            Offset = Offset + OFS;
            graphics.DrawString(lng.s_Item.s + "/", fArial10, new SolidBrush(Color.Black), startX, startY + Offset);
            Global.g.DrawStringAlignRight(graphics,lng.s_Amount.s + " "+GlobalData.BaseCurrency.Abbreviation, fArial10, Color.Black, startX + pagewidth, startY + Offset);

            Offset = Offset + OFS;
            graphics.DrawString(lng.s_Quantity.s, fArial10, new SolidBrush(Color.Black), startX, startY + Offset);
            graphics.DrawString(lng.s_VAT.s, fArial10, new SolidBrush(Color.Black), startX + (pagewidth*34)/60, startY + Offset);
            Global.g.DrawStringAlignRight(graphics, lng.s_without_VAT.s, fArial10, Color.Black, startX + pagewidth, startY + Offset);

            underLine = "---------------------------------------";
            Offset = Offset + OFS;
            graphics.DrawString(underLine, fArial10, new SolidBrush(Color.Black), startX, startY + Offset);

            foreach (DataRow dr in m_dt_Stock_Of_Current_StockTake.Rows)
            {
                Offset = Offset + OFS/2;

                string_v item_name_v = tf.set_string(dr["UniqueName"]);
                string sitem = "";
                if (item_name_v!=null)
                {
                    sitem = item_name_v.v;
                    Offset = Offset + OFS;
                    graphics.DrawString(sitem, fArial10, new SolidBrush(Color.Black), startX, startY + Offset);
                    decimal_v dQuantity_v = tf.set_decimal(dr["dQuantity"]);
                    string sQUantity = "";
                    if (dQuantity_v!=null)
                    {
                        sQUantity = dQuantity_v.v.ToString();
                    }
                    string_v sUnitSymbol_v = tf.set_string(dr["UnitSymbol"]);
                    string sUnitSymbol = "";
                    if (sUnitSymbol_v!=null)
                    {
                        sUnitSymbol = sUnitSymbol_v.v;
                    }
                    Offset = Offset + OFS;


                    decimal_v dPurchasePricePerUnit_v = tf.set_decimal(dr["PurchasePricePerUnit"]);
                    string sPurchasePricePerUnit = "";
                    if (dPurchasePricePerUnit_v!=null)
                    {
                        sPurchasePricePerUnit = LanguageControl.DynSettings.SetLanguageCurrencyString(dPurchasePricePerUnit_v.v, GlobalData.BaseCurrency.DecimalPlaces, null);
                    }

                    string spercent = "0";
                    decimal_v dDisount_v =  tf.set_decimal(dr["Discount"]);
                    if (dDisount_v != null)
                    {
                        spercent = Global.f.GetPercent(dDisount_v.v,2);
                    }

                    graphics.DrawString(sQUantity + " "+ sUnitSymbol+" x "+ sPurchasePricePerUnit + "(-"+spercent+"%)", fArial10, new SolidBrush(Color.Black), startX, startY + Offset);

                    string staxrate = "";
                    decimal_v dTaxRate_v = tf.set_decimal(dr["TaxationRate"]);
                    if (dTaxRate_v!=null)
                    {
                        staxrate = Global.f.GetPercent(dTaxRate_v.v,1) + "%";
                    }
                    Global.g.DrawStringAlignRight(graphics, staxrate, fArial10, Color.Black, startX + (pagewidth * 44) / 60, startY + Offset);

                    string sdTotalWithoutTaxWithDiscount = "";
                    decimal_v dTotalWithoutTaxWithDiscount_v = tf.set_decimal(dr["TotalWithoutTaxWithDiscount"]);
                    if (dTotalWithoutTaxWithDiscount_v!=null)
                    {
                        sdTotalWithoutTaxWithDiscount = LanguageControl.DynSettings.SetLanguageCurrencyString(dTotalWithoutTaxWithDiscount_v.v, GlobalData.BaseCurrency.DecimalPlaces, null);
                    }
                    Global.g.DrawStringAlignRight(graphics, sdTotalWithoutTaxWithDiscount, fArial10, Color.Black, startX + pagewidth, startY + Offset);

                }
                //dr["dInitialQuantity"]
                decimal_v dTotalWithTaxWithDiscount_v = tf.set_decimal(dr["TotalWithTaxWithDiscount"]);
                string_v taxation_name_v = tf.set_string(dr["TaxationName"]);
                //dr["ImportTime"]
                //dr["ExpiryDate"]
                string_v supplier_v = tf.set_string(dr["Supplier"]);
                //dr["Symbol"]
            }
        }
    }
}
