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
using TangentaTableClass;
using StaticLib;

namespace TangentaPrint
{
    public class PrintStockOfItems
    {
        private int OFS = 18;
        private int pagewidth = 0;
        private Font fArial8 = new Font(familyName: "Arial", emSize: 8, style: FontStyle.Bold);
        private Font fArial8r = new Font(familyName: "Arial", emSize: 8, style: FontStyle.Regular);
        private Font fArial9 = new Font(familyName: "Arial", emSize: 9, style: FontStyle.Bold);
        private Font fArial9r = new Font(familyName: "Arial", emSize: 9, style: FontStyle.Regular);
        private Font fArial12 = new Font(familyName: "Arial", emSize: 12, style: FontStyle.Bold);
        private Font fArial12r = new Font(familyName: "Arial", emSize: 12, style: FontStyle.Regular);

        Font fCurierNew14 = new Font("Courier New", 14);

        private DataTable dtStockOfItem = null;
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



        public PrintStockOfItems(string printer_name, DataTable xdtStockOfItem)
        {
            m_printer_name = printer_name;
            dtStockOfItem = xdtStockOfItem;

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

            if (m_printer_name != null)
            {
                ps.PrinterName = m_printer_name;// (string)PrintersList.dt.Rows[0][PrintersList.dcol_PrinterName.ColumnName];
                Font font = new Font("Courier New", 15);

               
                pdoc.PrinterSettings = ps;

                pdoc.DocumentName = "Tangenta Invoice"; ;
                

                pdoc.PrintPage += new PrintPageEventHandler(pdoc_PrintPage);

                pagewidth = pdoc.PrinterSettings.DefaultPageSettings.PaperSize.Width;
                pdoc.Print();
            }
            else
            {
                print_with_printer_selection(powner, pdoc);
            }
            return true;
        }

        private void print_with_printer_selection(Control powner, PrintDocument pdoc)
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

        private void pdoc_PrintPage(object sender, PrintPageEventArgs e)
        {


            Graphics graphics = e.Graphics;
            Font font = new Font("Courier New", 10);

            Pen pen1 = new Pen(Color.Black, 1);
            Pen pen2 = new Pen(Color.Black, 2);
            Pen pen3 = new Pen(Color.Black, 3);
            float fontHeight = font.GetHeight();
            float startX = 0;
            float startY = 35;
            float Offset = 0;

            Offset = Offset + OFS;


            graphics.DrawImage(Properties.Resources.Tangenta_Logo1colorH32, startX, startY + Offset);
            graphics.DrawString(lng.s_PrintStockOfItems.s + ": " + LanguageControl.DynSettings.SetLanguageDateString(DateTime.Now), fArial12, new SolidBrush(Color.Black), startX + 8, startY + Offset + 8);
            Offset = Offset + OFS + 32;

            Offset = Offset + OFS + OFS / 5;
            graphics.DrawLine(pen1, startX, startY + Offset, startX + pagewidth, startY + Offset);

            graphics.DrawString(lng.s_Item.s, fArial8r, new SolidBrush(Color.Black), startX, startY + Offset + 2);
            graphics.DrawString(lng.s_Quantity.s + ",", fArial8r, new SolidBrush(Color.Black), startX + pagewidth * 1 / 2 - 2, startY + Offset + 2);
             Global.g.DrawStringAlignRight(graphics, lng.s_StockPriceValue.s, fArial8r, Color.Black, startX + pagewidth, startY + Offset + 2);

            Offset = Offset + OFS;
            graphics.DrawLine(pen1, startX, startY + Offset, startX + pagewidth, startY + Offset);
            Offset = Offset + 8;
            int iNum = 1;
            foreach (DataRow dr in dtStockOfItem.Rows)
            {
                ID item_ID = tf.set_ID(dr["Item_ID"]);
                string_v item_UniqueName_v = tf.set_string(dr["Item_UniqueName"]);
                string sunit_name = "";
                string_v UnitName_v = tf.set_string(dr["Unit_Name"]);
                if (UnitName_v != null)
                {
                    sunit_name = UnitName_v.v;
                }
                float xofs = 0;
                if (item_UniqueName_v != null)
                {
                    graphics.DrawString(iNum.ToString(), fArial8, new SolidBrush(Color.Black), startX, startY + Offset + 2);
                   
                    Global.g.DrawWordWrap(graphics, item_UniqueName_v.v, fArial8r, Color.Black, startX+32, startY + Offset, pagewidth * 1 / 2 - 34, ref xofs);
    
                    DataTable xdtShopCItemInStock = null;
                    if (TangentaDB.f_Stock.GetItemInStock(item_ID, ref xdtShopCItemInStock))
                    {
                        decimal drawquantity = TangentaDB.f_Stock.GetQuantityInStock(xdtShopCItemInStock);
                        decimal quantityInStock = decimal.Round(drawquantity, 4);
                        graphics.DrawString(quantityInStock.ToString() + " " + sunit_name, fArial8r, new SolidBrush(Color.Black), startX + pagewidth * 1 / 2 + 2, startY + Offset + 2);

                        decimal priceValueInStock = decimal.Round(TangentaDB.f_Stock.GetPriceValueInStock(xdtShopCItemInStock)* drawquantity, 4);


                        string sPriceWithoutVAT = price2string(priceValueInStock);
                        Global.g.DrawStringAlignRight(graphics, sPriceWithoutVAT, fArial8r, Color.Black, startX + pagewidth, startY + Offset);

                        Offset = Offset + xofs + 5;
                    }
                    else
                    {
                        Offset = Offset + xofs + 5;
                    }
                    iNum++;
                }
            }
            Offset = Offset + OFS + OFS / 5;
            graphics.DrawLine(pen1, startX, startY + Offset, startX + pagewidth, startY + Offset);
            Offset = Offset + OFS + OFS / 5;
            graphics.DrawLine(pen1, startX, startY + Offset, startX + pagewidth, startY + Offset);

        }

        private string price2string(decimal price)
        {
            return LanguageControl.DynSettings.SetLanguageCurrencyString(price, GlobalData.BaseCurrency.DecimalPlaces, null) + " " + GlobalData.BaseCurrency.Symbol;
        }

        
    }
}
