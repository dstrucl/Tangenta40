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
using StaticLib;

namespace TangentaPrint
{
    public class PrintCashierActivity
    {
        private int pagewidth = 0;
        private CashierActivity ca = null;

        public PrintCashierActivity(CashierActivity xca)
        {
            this.ca = xca;
        }

        public bool Print()
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
                pagewidth = pdoc.PrinterSettings.DefaultPageSettings.PaperSize.Width;

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
                        pagewidth = pdoc.PrinterSettings.DefaultPageSettings.PaperSize.Width;
                        pdoc.Print();
                    }
                }
            }
            return true;
        }

        private void DrawStringAlignCenter(Graphics graphics,string s,Font font,Color color,int ypos)
        {
            SizeF sf = graphics.MeasureString(s, font);
            float fwidth = pagewidth;
            float fxpos = fwidth / 2 - sf.Width / 2;
            graphics.DrawString(s, font, new SolidBrush(color), fxpos, ypos);

        }

        private void DrawStringAlignRight(Graphics graphics, string s, Font font, Color color, int xpos_rightalignemnt, int ypos)
        {
            SizeF sf = graphics.MeasureString(s, font);
            float fxpos = xpos_rightalignemnt - sf.Width;
            graphics.DrawString(s, font, new SolidBrush(color), fxpos, ypos);

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
            Font mFCurrier10 = new Font("Courier New", 10, FontStyle.Bold);
            Font mFArial10 = new Font("Arial", 10, FontStyle.Bold);
            Font myFont2 = new Font("Courier New", 14);
            String underLine = "********************************";
            Offset = Offset + OFS;
            graphics.DrawString(underLine, mFCurrier10, new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + OFS;
            string myOrg_Name = "";
            if (myOrg.Name_v!=null)
            {
                myOrg_Name = myOrg.Name_v.v;
            }

            string sStreetName = "";
            if (myOrg.Address_v!=null)
            {
                if (myOrg.Address_v.StreetName_v != null)
                {
                    sStreetName = myOrg.Address_v.StreetName_v.v;
                }
            }

            string sHouseNumber = "";
            if (myOrg.Address_v != null)
            {
                if (myOrg.Address_v.HouseNumber_v != null)
                {
                    sHouseNumber = myOrg.Address_v.HouseNumber_v.v;
                }
            }

            string sZIP = "";
            if (myOrg.Address_v != null)
            {
                if (myOrg.Address_v.ZIP_v != null)
                {
                    sZIP = myOrg.Address_v.ZIP_v.v;
                }
            }

            string sCity = "";
            if (myOrg.Address_v != null)
            {
                if (myOrg.Address_v.City_v != null)
                {
                    sCity = myOrg.Address_v.City_v.v;
                }
            }

            DrawStringAlignCenter(graphics, myOrg_Name, mFCurrier10, Color.Black, startY + Offset);
            Offset = Offset + OFS;

            string saddress = sStreetName + " " + sHouseNumber + ", " + sZIP + " " + sCity;
            DrawStringAlignCenter(graphics, saddress, mFCurrier10, Color.Black, startY + Offset);
            Offset = Offset + OFS;

            string sOfficeName = "";
            if (myOrg.m_myOrg_Office != null)
            {
                if (myOrg.m_myOrg_Office.Name_v != null)
                {
                    sOfficeName = myOrg.m_myOrg_Office.Name_v.v;
                }
            }
            DrawStringAlignCenter(graphics,lng.s_BussinessUnit.s + sOfficeName, mFCurrier10, Color.Black, startY + Offset);
            Offset = Offset + OFS;


            string sOfficeStreetName = "";
            if (myOrg.m_myOrg_Office != null)
            {
                if (myOrg.m_myOrg_Office.Address_v != null)
                {
                    if (myOrg.m_myOrg_Office.Address_v.StreetName_v != null)
                    {
                        sOfficeStreetName = myOrg.m_myOrg_Office.Address_v.StreetName_v.v;
                    }
                }
            }

            string sOfficeHouseNumber = "";
            if (myOrg.m_myOrg_Office != null)
            {
                if (myOrg.m_myOrg_Office.Address_v != null)
                {
                    if (myOrg.m_myOrg_Office.Address_v.HouseNumber_v != null)
                    {
                        sOfficeHouseNumber = myOrg.m_myOrg_Office.Address_v.HouseNumber_v.v;
                    }
                }
            }


            string sOfficeZIP = "";
            if (myOrg.m_myOrg_Office != null)
            {
                if (myOrg.m_myOrg_Office.Address_v != null)
                {
                    if (myOrg.m_myOrg_Office.Address_v.ZIP_v != null)
                    {
                        sOfficeZIP = myOrg.m_myOrg_Office.Address_v.ZIP_v.v;
                    }
                }
            }

            string sOfficeCity = "";
            if (myOrg.m_myOrg_Office != null)
            {
                if (myOrg.m_myOrg_Office.Address_v != null)
                {
                    if (myOrg.m_myOrg_Office.Address_v.ZIP_v != null)
                    {
                        sOfficeCity = myOrg.m_myOrg_Office.Address_v.City_v.v;
                    }
                }
            }

            string sOffice_address = sOfficeStreetName + " " + sOfficeHouseNumber + ", " + sOfficeZIP + " " + sOfficeCity;
            DrawStringAlignCenter(graphics, sOffice_address, mFCurrier10, Color.Black, startY + Offset);
            Offset = Offset + OFS;

            string sTaxID = "";
            if (myOrg.Tax_ID_v != null)
            {
                sTaxID = myOrg.Tax_ID_v.v;
            }

            string sCountryPrefix = "";
            if (myOrg.m_myOrg_Office != null)
            {
                if (myOrg.m_myOrg_Office.Address_v != null)
                {
                    if (myOrg.m_myOrg_Office.Address_v.Country_ISO_3166_a2_v != null)
                    {

                        sCountryPrefix = myOrg.m_myOrg_Office.Address_v.Country_ISO_3166_a2_v.v;
                    }
                }
            }


            DrawStringAlignCenter(graphics, lng.s_TaxID_for_VAT.s+ sCountryPrefix+ sTaxID, mFCurrier10, Color.Black, startY + Offset);
            Offset = Offset + OFS;


            graphics.DrawString(" -----------------------------------", mFCurrier10, new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + OFS;

            string sElectronicDeviceName = "";
            if (myOrg.m_myOrg_Office != null)
            {
                if (myOrg.m_myOrg_Office.m_myOrg_Office_ElectronicDevice != null)
                {
                    if (myOrg.m_myOrg_Office.m_myOrg_Office_ElectronicDevice.ElectronicDevice_Name != null)
                    {

                        sElectronicDeviceName =myOrg.m_myOrg_Office.m_myOrg_Office_ElectronicDevice.ElectronicDevice_Name;
                    }
                }
            }

            string sClosingCashierNum = lng.s_CashierClose_Number.s.Replace("(@@EDName@@)", sElectronicDeviceName) + ca.CashierActivityNumber.ToString();

            graphics.DrawString(sClosingCashierNum, mFArial10, new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + OFS;

            string sOpenningDate = Global.f.GetStringDate(ca.FirstLogin);
            string sOpenningTime = Global.f.GetStringTime(ca.FirstLogin);

            graphics.DrawString(lng.s_SaleStartDate.s, mFArial10, new SolidBrush(Color.Black), startX, startY + Offset);
            graphics.DrawString(sOpenningDate, mFArial10, new SolidBrush(Color.Black), startX + (pagewidth * 12) / 20, startY + Offset);
            graphics.DrawString(sOpenningTime, mFArial10, new SolidBrush(Color.Black), startX + (pagewidth * 17) / 20, startY + Offset);
            Offset = Offset + OFS;

            string sClosingDate = Global.f.GetStringDate(ca.LastLogin);
            string sClosingTime = Global.f.GetStringTime(ca.LastLogin);

            graphics.DrawString(lng.s_SaleEndDate.s, mFArial10, new SolidBrush(Color.Black), startX, startY + Offset);
            graphics.DrawString(sClosingDate, mFArial10, new SolidBrush(Color.Black), startX + (pagewidth * 12) / 20, startY + Offset);
            graphics.DrawString(sClosingTime, mFArial10, new SolidBrush(Color.Black), startX + (pagewidth * 17) / 20, startY + Offset);
            Offset = Offset + OFS;


            graphics.DrawString(" -----------------------------------", mFCurrier10, new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + OFS;

            graphics.DrawString(lng.s_InvoicesIssued.s, mFArial10, new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + OFS;

            string sInvoiceFrom = null;
            string sInvoiceTo = null;
            if (ca.DocInvoice_ID_List.Count > 0)
            {
                CashierActivity.DocInvoiceData dif = ca.DocInvoice_ID_List[0];
                sInvoiceFrom = Tangenta_DefaultPrintTemplates.TemplatesLoader.SetInvoiceNumber(dif.Atom_Office_ShortName,
                                                                                               dif.Atom_ElectronicDevice_Name,
                                                                                               dif.NumberInFinancialYear,
                                                                                               dif.FinancialYear,
                                                                                               dif.Storno,
                                                                                               lng.s_Storno.s);
                if (ca.DocInvoice_ID_List.Count > 1)
                {
                    CashierActivity.DocInvoiceData dil = ca.DocInvoice_ID_List[ca.DocInvoice_ID_List.Count - 1];
                    sInvoiceTo = Tangenta_DefaultPrintTemplates.TemplatesLoader.SetInvoiceNumber(dil.Atom_Office_ShortName,
                                                                                                   dil.Atom_ElectronicDevice_Name,
                                                                                                   dil.NumberInFinancialYear,
                                                                                                   dil.FinancialYear,
                                                                                                   dil.Storno,
                                                                                                   lng.s_Storno.s);

                }

                if (sInvoiceFrom != null)
                {
                    graphics.DrawString(lng.s_From.s, mFArial10, new SolidBrush(Color.Black), startX, startY + Offset);
                    graphics.DrawString(sInvoiceFrom, mFArial10, new SolidBrush(Color.Black), startX + (pagewidth * 4) / 40, startY + Offset);
                    if (sInvoiceTo != null)
                    {
                        graphics.DrawString(lng.s_To.s, mFArial10, new SolidBrush(Color.Black), startX + (pagewidth * 20) / 40, startY + Offset);
                        graphics.DrawString(sInvoiceTo, mFArial10, new SolidBrush(Color.Black), startX + (pagewidth * 23) / 40, startY + Offset);
                    }
                }
                Offset = Offset + OFS;
            }

            string scurrencyid = TangentaDB.GlobalData.BaseCurrency.Symbol;

            graphics.DrawString(lng.s_NumberOfInvoices.s+":", mFArial10, new SolidBrush(Color.Black), startX, startY + Offset);
            graphics.DrawString(ca.NumberOfInvoices.ToString(), mFArial10, new SolidBrush(Color.Black), startX + (pagewidth * 17) / 20, startY + Offset);
            Offset = Offset + OFS;

            graphics.DrawString(lng.s_Total_turnover.s + ":", mFArial10, new SolidBrush(Color.Black), startX, startY + Offset);
            string sTotal = LanguageControl.DynSettings.SetLanguageCurrencyString(ca.Total, TangentaDB.GlobalData.BaseCurrency.DecimalPlaces, scurrencyid);
            DrawStringAlignRight(graphics,sTotal, mFArial10, Color.Black, startX + pagewidth, startY + Offset);
            Offset = Offset + OFS;

            graphics.DrawString(" -----------------------------------", mFCurrier10, new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + OFS;

            foreach (Tax tax in ca.TaxSum.TaxList)
            {
                graphics.DrawString(tax.Name, mFArial10, new SolidBrush(Color.Black), startX, startY + Offset);
                graphics.DrawString(lng.s_TaxBase.s, mFArial10, new SolidBrush(Color.Black), startX + (pagewidth * 10) / 40, startY + Offset);
                string sTaxBase = LanguageControl.DynSettings.SetLanguageCurrencyString(tax.TaxableAmount, TangentaDB.GlobalData.BaseCurrency.DecimalPlaces, scurrencyid);
                DrawStringAlignRight(graphics, sTaxBase, mFArial10, Color.Black, startX + pagewidth, startY + Offset);
                Offset = Offset + OFS;

                graphics.DrawString(lng.s_CalculatedVAT.s, mFArial10, new SolidBrush(Color.Black), startX + (pagewidth * 10) / 40, startY + Offset);
                string sTaxAmount = LanguageControl.DynSettings.SetLanguageCurrencyString(tax.TaxAmount, TangentaDB.GlobalData.BaseCurrency.DecimalPlaces, scurrencyid);
                DrawStringAlignRight(graphics, sTaxAmount, mFArial10, Color.Black, startX + pagewidth, startY + Offset);
                Offset = Offset + OFS;

                graphics.DrawString(lng.s_Total.s, mFArial10, new SolidBrush(Color.Black), startX + (pagewidth * 10) / 40, startY + Offset);
                decimal dtotal = tax.TaxableAmount + tax.TaxAmount;
                string stotal = LanguageControl.DynSettings.SetLanguageCurrencyString(dtotal, TangentaDB.GlobalData.BaseCurrency.DecimalPlaces, scurrencyid);
                DrawStringAlignRight(graphics, stotal, mFArial10, Color.Black, startX + pagewidth, startY + Offset);
                Offset = Offset + OFS;
            }
            Offset = Offset + OFS;

            graphics.DrawString(lng.s_MethodOfPayment.s, mFCurrier10, new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + OFS;
            graphics.DrawString(" -----------------------------------", mFCurrier10, new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + OFS;

            foreach (Report.PaymentType pt in ca.PaymentList.items)
            {
                graphics.DrawString(pt.Name, mFArial10, new SolidBrush(Color.Black), startX, startY + Offset);
                string sAmount = LanguageControl.DynSettings.SetLanguageCurrencyString(pt.Total, TangentaDB.GlobalData.BaseCurrency.DecimalPlaces, scurrencyid);
                DrawStringAlignRight(graphics, sAmount, mFArial10, Color.Black, startX + pagewidth, startY + Offset);
                Offset = Offset + OFS;
            }
            graphics.DrawString(" -----------------------------------", mFCurrier10, new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + OFS;
            DrawStringAlignCenter(graphics,"www.tangenta.si", mFCurrier10, Color.Black,startY + Offset);
        }
    }
}
