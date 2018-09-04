﻿using DBConnectionControl40;
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


        void pdoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            int OFS = 18;
            Graphics graphics = e.Graphics;
            Font font = new Font("Courier New", 10);
            float fontHeight = font.GetHeight();
            Pen pen1 = new Pen(Color.Black, 1);
            int startX = 0;
            int startY = 55;
            int Offset = 40;
            Font mFCurrier10 = new Font("Courier New", 10, FontStyle.Bold);
            Font mFArial10 = new Font("Arial", 10, FontStyle.Bold);
            Font fArial12 = new Font(familyName: "Arial", emSize: 12, style: FontStyle.Bold);
            Font myFont2 = new Font("Courier New", 14);


            string sElectronicDeviceName = "";
            if (myOrg.m_myOrg_Office != null)
            {
                if (myOrg.m_myOrg_Office.m_myOrg_Office_ElectronicDevice != null)
                {
                    if (myOrg.m_myOrg_Office.m_myOrg_Office_ElectronicDevice.ElectronicDevice_Name != null)
                    {

                        sElectronicDeviceName = myOrg.m_myOrg_Office.m_myOrg_Office_ElectronicDevice.ElectronicDevice_Name;
                    }
                }
            }

            graphics.DrawImage(Properties.Resources.Tangenta_Logo1colorH32, startX, startY + Offset);
            graphics.DrawString(lng.s_CASHIER.s+" "+ sElectronicDeviceName+ " "+lng.s_CLOSE.s+":" +ca.CashierActivityNumber.ToString(), fArial12, new SolidBrush(Color.Black), startX + 8, startY + Offset + 8);

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

            Offset = Offset + OFS + 16;
            Global.g.DrawStringAlignCenter(graphics, myOrg_Name, mFArial10, Color.Black, startY + Offset,pagewidth);
            Offset = Offset + OFS;

            string saddress = sStreetName + " " + sHouseNumber + ", " + sZIP + " " + sCity;
            Global.g.DrawStringAlignCenter(graphics, saddress, mFArial10, Color.Black, startY + Offset,pagewidth);
            Offset = Offset + OFS;

            string sOfficeName = "";
            if (myOrg.m_myOrg_Office != null)
            {
                if (myOrg.m_myOrg_Office.Name_v != null)
                {
                    sOfficeName = myOrg.m_myOrg_Office.Name_v.v;
                }
            }
            Global.g.DrawStringAlignCenter(graphics,lng.s_BussinessUnit.s + sOfficeName, mFArial10, Color.Black, startY + Offset, pagewidth);
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
            Global.g.DrawStringAlignCenter(graphics, sOffice_address, mFArial10, Color.Black, startY + Offset, pagewidth);

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

            Offset = Offset + OFS;
            Global.g.DrawStringAlignCenter(graphics, lng.s_TaxID_for_VAT.s+ sCountryPrefix+ sTaxID, mFArial10, Color.Black, startY + Offset,pagewidth);
            
            // DRAW LINE ___________________________________________________________
            Offset = Offset + OFS;
            graphics.DrawLine(pen1, startX, startY + Offset, startX + pagewidth, startY + Offset);



            string sClosingCashierNum = lng.s_CashierClose_Number.s.Replace("(@@EDName@@)", sElectronicDeviceName) + ca.CashierActivityNumber.ToString();

            Offset = Offset + OFS / 2;
            graphics.DrawString(sClosingCashierNum, mFArial10, new SolidBrush(Color.Black), startX, startY + Offset);

            string sOpenningDate = Global.f.GetStringDate(ca.FirstLogin);
            string sOpenningTime = Global.f.GetStringTime(ca.FirstLogin);

            Offset = Offset + OFS;
            graphics.DrawString(lng.s_SaleStartDate.s, mFArial10, new SolidBrush(Color.Black), startX, startY + Offset);
            graphics.DrawString(sOpenningDate, mFArial10, new SolidBrush(Color.Black), startX + (pagewidth * 12) / 20, startY + Offset);
            graphics.DrawString(sOpenningTime, mFArial10, new SolidBrush(Color.Black), startX + (pagewidth * 17) / 20, startY + Offset);
            Offset = Offset + OFS;

            string sClosingDate = Global.f.GetStringDate(ca.LastLogin);
            string sClosingTime = Global.f.GetStringTime(ca.LastLogin);

            graphics.DrawString(lng.s_SaleEndDate.s, mFArial10, new SolidBrush(Color.Black), startX, startY + Offset);
            graphics.DrawString(sClosingDate, mFArial10, new SolidBrush(Color.Black), startX + (pagewidth * 12) / 20, startY + Offset);
            graphics.DrawString(sClosingTime, mFArial10, new SolidBrush(Color.Black), startX + (pagewidth * 17) / 20, startY + Offset);


            // DRAW LINE ___________________________________________________________
            Offset = Offset + OFS + OFS / 5;
            graphics.DrawLine(pen1, startX, startY + Offset, startX + pagewidth, startY + Offset);

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
            Global.g.DrawStringAlignRight(graphics,sTotal, mFArial10, Color.Black, startX + pagewidth, startY + Offset);

            // DRAW LINE ___________________________________________________________
            Offset = Offset + OFS + OFS / 5;
            graphics.DrawLine(pen1, startX, startY + Offset, startX + pagewidth, startY + Offset);

            Offset = Offset + OFS;
            foreach (Tax tax in ca.TaxSum.TaxList)
            {
                graphics.DrawString(tax.Name, mFArial10, new SolidBrush(Color.Black), startX, startY + Offset);
                graphics.DrawString(lng.s_TaxBase.s, mFArial10, new SolidBrush(Color.Black), startX + (pagewidth * 10) / 40, startY + Offset);
                string sTaxBase = LanguageControl.DynSettings.SetLanguageCurrencyString(tax.TaxableAmount, TangentaDB.GlobalData.BaseCurrency.DecimalPlaces, scurrencyid);
                Global.g.DrawStringAlignRight(graphics, sTaxBase, mFArial10, Color.Black, startX + pagewidth, startY + Offset);
                Offset = Offset + OFS;

                graphics.DrawString(lng.s_CalculatedVAT.s, mFArial10, new SolidBrush(Color.Black), startX + (pagewidth * 10) / 40, startY + Offset);
                string sTaxAmount = LanguageControl.DynSettings.SetLanguageCurrencyString(tax.TaxAmount, TangentaDB.GlobalData.BaseCurrency.DecimalPlaces, scurrencyid);
                Global.g.DrawStringAlignRight(graphics, sTaxAmount, mFArial10, Color.Black, startX + pagewidth, startY + Offset);
                Offset = Offset + OFS;

                graphics.DrawString(lng.s_TotalWithVAT.s, mFArial10, new SolidBrush(Color.Black), startX + (pagewidth * 10) / 40, startY + Offset);
                decimal dtotal = tax.TaxableAmount + tax.TaxAmount;
                string stotal = LanguageControl.DynSettings.SetLanguageCurrencyString(dtotal, TangentaDB.GlobalData.BaseCurrency.DecimalPlaces, scurrencyid);
                Global.g.DrawStringAlignRight(graphics, stotal, mFArial10, Color.Black, startX + pagewidth, startY + Offset);
                Offset = Offset + OFS;
            }
            Offset = Offset + OFS;

            graphics.DrawString(lng.s_MethodOfPayment.s, mFArial10, new SolidBrush(Color.Black), startX, startY + Offset);

            // DRAW LINE ___________________________________________________________
            Offset = Offset + OFS;
            graphics.DrawLine(pen1, startX, startY + Offset, startX + pagewidth, startY + Offset);

            Offset = Offset + OFS;

            foreach (Report.PaymentType pt in ca.PaymentList.items)
            {
                graphics.DrawString(pt.Name, mFArial10, new SolidBrush(Color.Black), startX, startY + Offset);
                string sAmount = LanguageControl.DynSettings.SetLanguageCurrencyString(pt.Total, TangentaDB.GlobalData.BaseCurrency.DecimalPlaces, scurrencyid);
                Global.g.DrawStringAlignRight(graphics, sAmount, mFArial10, Color.Black, startX + pagewidth, startY + Offset);
                Offset = Offset + OFS;
            }

            // DRAW LINE ___________________________________________________________
            graphics.DrawLine(pen1, startX, startY + Offset, startX + pagewidth, startY + Offset);
            Offset = Offset + OFS;
            Global.g.DrawStringAlignCenter(graphics,"www.tangenta.si", mFCurrier10, Color.Black,startY + Offset,pagewidth);
        }
    }
}
