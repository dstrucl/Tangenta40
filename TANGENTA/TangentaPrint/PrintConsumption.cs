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
    public class PrintConsumption
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
//        private ConsumptionData m_ConsumptionData = null;
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



        public PrintConsumption(string printer_name)
        {
            m_printer_name = printer_name;
          
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
            
           
            Graphics graphics = e.Graphics;
            Font font = new Font("Courier New", 10);

            Pen pen1 = new Pen(Color.Black, 1);
            Pen pen2 = new Pen(Color.Black, 2);
            Pen pen3 = new Pen(Color.Black, 3);
            float fontHeight = font.GetHeight();
            float startX = 0;
            float startY = 35;
            float Offset = 0;

          

            //String underLine = "****************************************";
            //Offset = Offset + OFS;
            //graphics.DrawString(underLine, fArial10, new SolidBrush(Color.Black), startX, startY + Offset);
            //graphics.DrawLine(pen3, fArial10, new SolidBrush(Color.Black), startX, startY + Offset);

            Offset = Offset + OFS;
            // string stocktake_ID = "";
            string sInvoiceNumber = "";

            //if (m_ConsumptionData.PrintCopyInfo.Length>0)
            //{
            //    sInvoiceNumber += m_ConsumptionData + ":" + m_ConsumptionData.PrintCopyInfo + ":" + m_ConsumptionData.GetInvoiceNumberString();
            //}
            //else
            //{
              //  sInvoiceNumber += m_ConsumptionData + ":" + m_ConsumptionData.GetInvoiceNumberString();
            //}
            //graphics.DrawImage(Properties.Resources.Tangenta_Logo1colorH32, startX, startY + Offset);
            //graphics.DrawString(lng.s_DocInvoice.s + " " + lng.s_num.s + ":" + m_ConsumptionData.GetInvoiceNumberString(), fArial12, new SolidBrush(Color.Black), startX + 8, startY + Offset + 8);
            //Offset = Offset + OFS+16;
            //if (m_ConsumptionData.PrintCopyInfo.Length > 0)
            //{
            //    graphics.DrawString(m_ConsumptionData.PrintCopyInfo, fArial12r, new SolidBrush(Color.Black), startX + 8, startY + Offset + 8);
            //    Offset = Offset + OFS+16;
            //}
            //if (m_ConsumptionData.Invoice_Storno_v!=null)
            //{
            //    if(m_ConsumptionData.Invoice_Storno_v.v)
            //    {
            //        graphics.DrawString(lng.s_Storno.s, fArial12, new SolidBrush(Color.Black), startX + 8, startY + Offset + 8);
            //        Offset = Offset + OFS + 16;
            //    }
            //}

            //Image logoImage = m_ConsumptionData.GetOrganisationLogoImage();
            //if (logoImage!=null)
            //{
            //     float logo_width = 200;
            //     float logo_height = 80;
            //     graphics.DrawImage(logoImage, startX+40, startY + Offset, logo_width, logo_height);
            //     Offset = Offset + logo_height + OFS / 5;
            //}
           
            //graphics.DrawLine(pen1, startX, startY + Offset, startX+pagewidth, startY + Offset);
            //if (m_ConsumptionData.CustomerIsDefined())
            //{
            //    printCustomer(graphics, ref Offset, startX, startY);
            //}
            //graphics.DrawString(lng.s_Issuer.s + ":", fArial9, new SolidBrush(Color.Black), startX, startY + Offset);
            //Offset = Offset + 2;

            //int xofst = 80;
            //graphics.DrawString(m_ConsumptionData.MyOrganisation.Name, fArial8r, new SolidBrush(Color.Black), startX+ xofst, startY + Offset);
            //Offset = Offset + 2 * OFS / 3;
            //graphics.DrawString(m_ConsumptionData.MyOrganisation.Address.StreetName+ " "
            //                   + m_ConsumptionData.MyOrganisation.Address.HouseNumber+"," 
            //                   + m_ConsumptionData.MyOrganisation.Address.ZIP + " "
            //                   + m_ConsumptionData.MyOrganisation.Address.City, fArial8r, new SolidBrush(Color.Black), startX + xofst, startY + Offset);
            //Offset = Offset + 2 * OFS / 3;

            //graphics.DrawString(lng.s_Tax_ID.s+": "+m_ConsumptionData.MyOrganisation.Tax_ID, fArial8r, new SolidBrush(Color.Black), startX + xofst, startY + Offset);
            //Offset = Offset + 2 * OFS / 3;

            //graphics.DrawString(lng.s_Registration_ID.s + ": " + m_ConsumptionData.MyOrganisation.Registration_ID, fArial8r, new SolidBrush(Color.Black), startX + xofst, startY + Offset);
            //Offset = Offset + 2 * OFS / 3;

            //graphics.DrawString(lng.s_OfficeName.s + ": " + m_ConsumptionData.MyOrganisation.Atom_Office_Name, fArial8r, new SolidBrush(Color.Black), startX + xofst, startY + Offset);
            //Offset = Offset + 2 * OFS / 3;

            
            //string selectronicdevicename = "";
            //if (m_ConsumptionData.Electronic_Device_Name_v!=null)
            //{
            //    selectronicdevicename = m_ConsumptionData.Electronic_Device_Name_v.v;

            //}
            //graphics.DrawString(lng.s_ElectronicDevice.s + ": " + selectronicdevicename, fArial8r, new SolidBrush(Color.Black), startX + xofst, startY + Offset);
            //Offset = Offset + 2 * OFS / 3;

            //string sIssuerPerson = "";
            //if (m_ConsumptionData.My_Organisation_Person_FirstName_v!=null)
            //{
            //    sIssuerPerson += m_ConsumptionData.My_Organisation_Person_FirstName_v.v;
            //}
            //if (m_ConsumptionData.My_Organisation_Person_LastName_v != null)
            //{
            //    sIssuerPerson += " " + m_ConsumptionData.My_Organisation_Person_LastName_v.v;
            //}
            //graphics.DrawString(lng.s_IssuerPerson.s + ": " + sIssuerPerson, fArial8r, new SolidBrush(Color.Black), startX + xofst, startY + Offset);
            //Offset = Offset + 2 * OFS / 3;

            //if (m_ConsumptionData.MyOrganisation.PhoneNumber != null)
            //{
            //    if (m_ConsumptionData.MyOrganisation.PhoneNumber.Length>0)
            //    {
            //        graphics.DrawString(lng.s_PhoneNumber.s + ": " + m_ConsumptionData.MyOrganisation.PhoneNumber, fArial8r, new SolidBrush(Color.Black), startX + xofst, startY + Offset);
            //        Offset = Offset + 2 * OFS / 3;
            //    }
            //}
            
            //if (m_ConsumptionData.MyOrganisation.Email!=null)
            //{
            //    if(m_ConsumptionData.MyOrganisation.Email.Length>0)
            //    {
            //        graphics.DrawString(lng.s_Email.s + ": " + m_ConsumptionData.MyOrganisation.Email, fArial8r, new SolidBrush(Color.Black), startX + xofst, startY + Offset);
            //        Offset = Offset + 2 * OFS / 3;
            //    }
            //}


            //if (m_ConsumptionData.MyOrganisation.HomePage != null)
            //{
            //    if (m_ConsumptionData.MyOrganisation.HomePage.Length > 0)
            //    {
            //        graphics.DrawString(lng.s_Homepage.s + ": " + m_ConsumptionData.MyOrganisation.HomePage, fArial8r, new SolidBrush(Color.Black), startX + xofst, startY + Offset);
            //        Offset = Offset + OFS;
            //    }
            //}

            //if (m_ConsumptionData.MyOrganisation.Comment1!=null)
            //{
            //    if (m_ConsumptionData.MyOrganisation.Comment1.Length>0)
            //    {
            //        float xofsComment1 = 0;
            //        Global.g.DrawWordWrap(graphics, m_ConsumptionData.MyOrganisation.Comment1, fArial8r, Color.Black, startX+ xofst, startY + Offset, pagewidth, ref xofsComment1);
            //        Offset = Offset + xofsComment1+ 8;
            //    }
            //}
            //string sinvoicetime = LanguageControl.DynSettings.SetLanguageDateTimeString(m_ConsumptionData.IssueDate_v.v);

            //graphics.DrawString(lng.s_IssueTime.s + ": " + sinvoicetime, fArial9, new SolidBrush(Color.Black), startX, startY + Offset);
            //Offset = Offset + OFS;

            //if (m_ConsumptionData.Atom_WorkArea_Name_v!=null)
            //{
            //    if (m_ConsumptionData.Atom_WorkArea_Name_v.v != null)
            //    {
            //        graphics.DrawString(lng.s_WorkArea.s + ": " + m_ConsumptionData.Atom_WorkArea_Name_v.v, fArial9, new SolidBrush(Color.Black), startX, startY + Offset);
            //        Offset = Offset + OFS;
            //    } 
            //}
            
            //graphics.DrawString(lng.s_ItemOrService.s, fArial8r, new SolidBrush(Color.Black), startX, startY + Offset+2);
            //graphics.DrawString(lng.s_Quantity.s+",", fArial8r, new SolidBrush(Color.Black), startX + pagewidth * 1 / 2-2, startY + Offset + 2);
            //graphics.DrawString(lng.s_TaxationRate.s+",", fArial8r, new SolidBrush(Color.Black), startX+ pagewidth * 1 / 2 + 40, startY + Offset+2);
            //Global.g.DrawStringAlignRight(graphics, lng.s_PriceWithTax.s, fArial8r, Color.Black, startX + pagewidth, startY + Offset+2);

            //Offset = Offset + OFS;
            //graphics.DrawLine(pen1, startX, startY + Offset, startX + pagewidth, startY + Offset);
            //Offset = Offset + 8;
            //foreach (UniversalInvoice.ItemSold itm in m_ConsumptionData.ItemsSold)
            //{
            //    float xofs = 0;
            //    Global.g.DrawWordWrap(graphics, itm.Item_Name, fArial8r, Color.Black, startX, startY + Offset, pagewidth * 1/2-2, ref xofs);
            //    graphics.DrawString(itm.dQuantity.ToString(), fArial8r, new SolidBrush(Color.Black), startX + pagewidth * 1 / 2 + 2, startY + Offset + 2);
            //    string staxname = itm.TaxationName;
            //    int iddv = staxname.IndexOf("DDV");
            //    if (iddv>=0)
            //    {
            //        staxname = staxname.Substring(3);
            //    }
            //    graphics.DrawString(staxname, fArial8r, new SolidBrush(Color.Black), startX + pagewidth * 1 / 2 + 40, startY + Offset + 2);
            //    string sPriceWithVAT = price2string(itm.PriceWithTax);
            //    Global.g.DrawStringAlignRight(graphics,sPriceWithVAT, fArial8r, Color.Black, startX + pagewidth, startY + Offset);
            //    if (itm.TotalDiscount!=0)
            //    {
            //        Offset = Offset + xofs;
            //        graphics.DrawString(lng.s_Discount.s + " "+Global.f.GetPercent(itm.TotalDiscount, 2)+ "%", fArial8r, new SolidBrush(Color.Black), startX, startY + Offset + 2);
                    
            //    }
            //    Offset = Offset + xofs + 5;
                
            //}
            //graphics.DrawLine(pen1, startX, startY + Offset, startX + pagewidth, startY + Offset);

            //graphics.DrawString(lng.s_Total_without_VAT.s, fArial8r, new SolidBrush(Color.Black), startX, startY + Offset + 2);
            //string sPriceWithoutVAT = price2string(m_ConsumptionData.NetSum);
            //Global.g.DrawStringAlignRight(graphics, sPriceWithoutVAT, fArial8r, Color.Black, startX + pagewidth, startY + Offset);
            //Offset = Offset + OFS;
            //foreach (Tax tax in m_ConsumptionData.taxSum.TaxList)
            //{
            //    graphics.DrawString(lng.s_TaxationRate.s, fArial8r, new SolidBrush(Color.Black), startX, startY + Offset + 2);
            //    graphics.DrawString(tax.Name, fArial8r, new SolidBrush(Color.Black), startX+100, startY + Offset + 2);

            //    string sPriceVAT = price2string(tax.TaxAmount);
            //    Global.g.DrawStringAlignRight(graphics, sPriceVAT, fArial8r, Color.Black, startX + pagewidth, startY + Offset);
            //    Offset = Offset + OFS;
            //}

            //graphics.DrawString(lng.s_TaxTotal.s, fArial8r, new SolidBrush(Color.Black), startX, startY + Offset);
            //string sVAT = price2string(m_ConsumptionData.taxsum);
            //Global.g.DrawStringAlignRight(graphics, sVAT, fArial8r, Color.Black, startX + pagewidth, startY + Offset);
            //Offset = Offset + OFS;

            //graphics.DrawString(lng.s_TotalWithVAT.s, fArial9, new SolidBrush(Color.Black), startX, startY + Offset);
            //string sTotal = price2string(m_ConsumptionData.GrossSum);
            //Global.g.DrawStringAlignRight(graphics, sTotal, fArial9, Color.Black, startX + pagewidth, startY + Offset);
            //Offset = Offset + OFS;

            ////graphics.DrawString(lng.s_MethodOfPayment.s + " " + m_ConsumptionData.AddOnWriteOff.MyMethodOfPayment_DI.PaymentType, fArial9, new SolidBrush(Color.Black), startX, startY + Offset);
            ////Offset = Offset + OFS;

            ////string sNoticeText = m_ConsumptionData.AddOnDI.m_NoticeText;
            ////if (sNoticeText!=null)
            ////{
            ////    if (sNoticeText.Length>0)
            ////    {
            ////        Offset = Offset + 16;
            ////        float xofsnotice = 0;
            ////        Global.g.DrawWordWrap(graphics, sNoticeText, fArial8r, Color.Black, startX, startY + Offset, pagewidth, ref xofsnotice);
            ////        Offset = Offset + xofsnotice + OFS;
            ////    }
            ////}



            //graphics.DrawImage(Properties.Resources.Tangenta_Logo1colorH32, startX, startY + Offset);
            //graphics.DrawString(lng.s_TangentaInvoicingAdd.s, fArial12r, new SolidBrush(Color.Black), startX + 8, startY + Offset + 8);

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

        private string price2string(decimal price)
        {
          return  LanguageControl.DynSettings.SetLanguageCurrencyString(price, GlobalData.BaseCurrency.DecimalPlaces, null)+" "+ GlobalData.BaseCurrency.Symbol;
        }

       
    }
}
