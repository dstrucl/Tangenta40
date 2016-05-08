#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using DBTypes;
using LanguageControl;
using FiscalVerificationOfInvoices_SLO;
using InvoiceDB;
using UniversalInvoice;

namespace Tangenta
{
    public partial class usrc_Printer : UserControl
    {
        public Printer Printer = new Printer();

        Form_PrinterSettings m_frm_prn_settings = null;

        private string m_PrinterName = null;
        private string m_PaperName = null;
        public string PrinterName
        {
            get
            {
                return Printer.PrinterName;
            }
        }

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



        public InvoiceData m_InvoiceData = null;
        public StaticLib.TaxSum taxSum = null;



        float cx_paper_in_inch = 0;
        float cy_paper_in_inch = 0;

        int cx_paper_on_screen_in_pixels = 0;
        int cy_paper_on_screen_in_pixels = 0;

        public usrc_Printer()
        {
            InitializeComponent();
        }

        private void btn_Printer_Click(object sender, EventArgs e)
        {
            m_frm_prn_settings = new Form_PrinterSettings(this);
            m_frm_prn_settings.ShowDialog();
            m_frm_prn_settings = null;

        }

        internal void Print_Receipt(InvoiceData xInvoiceData, GlobalData.ePaymentType PaymentType, string sPaymentMethod, string sAmountReceived, string sToReturn, DateTime_v issue_time)
        {



            if (Printer_is_ESC_POS())
            {
                Print_Receipt_ESC_POS(xInvoiceData, PaymentType, sPaymentMethod, sAmountReceived, sToReturn, issue_time);
            }
            else
            {
                Form_Print_A4 print_A4_dlg = new Form_Print_A4(xInvoiceData, PaymentType, sPaymentMethod, sAmountReceived, sToReturn, issue_time);
                print_A4_dlg.ShowDialog();
            }
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

        internal void Print_Receipt_ESC_POS(InvoiceData xInvoiceData, GlobalData.ePaymentType PaymentType, string sPaymentMethod, string sAmountReceived, string sToReturn, DateTime_v issue_time)
        {


            //ReceiptPrinter.Print(ep.InitializePrinter());
            long journal_docinvoice_id = -1;

            try
            {
                
                if (Printer.InitializePrinter())
                {

                }
                if (Printer.PrintInBuffer)
                {
                    Printer.Clear();
                }

                if (xInvoiceData.MyOrganisation.Logo_Data != null)
                {
                    Printer.wr_BitmapByteArray570x570imagesize(xInvoiceData.MyOrganisation.Logo_Data);
                }

                Printer.wr_SelectAnInternationalCharacterSet(Printer.eCharacterSet.Slovenia_Croatia);
                Printer.wr_Paragraph(xInvoiceData.MyOrganisation.Name);
                Printer.wr_Paragraph(xInvoiceData.MyOrganisation.Address.StreetName + " " + xInvoiceData.MyOrganisation.Address.HouseNumber);
                Printer.wr_Paragraph(xInvoiceData.MyOrganisation.Address.ZIP + " " + xInvoiceData.MyOrganisation.Address.City);
                if (xInvoiceData.MyOrganisation.HomePage != null)
                {
                    if (xInvoiceData.MyOrganisation.HomePage.Length > 0)
                    {
                        Printer.wr_String("Domača stran:");
                        Printer.wr_SelectAnInternationalCharacterSet(Printer.eCharacterSet.USA);
                        Printer.wr_String(xInvoiceData.MyOrganisation.HomePage);
                        Printer.wr_SelectAnInternationalCharacterSet(Printer.eCharacterSet.Slovenia_Croatia);
                        Printer.wr_NewLine();
                        ;
                    }
                }
                if (xInvoiceData.MyOrganisation.Email != null)
                {
                    if (xInvoiceData.MyOrganisation.Email.Length > 0)
                    {
                        Printer.wr_String("EPOŠTA:");
                        Printer.wr_SelectAnInternationalCharacterSet(Printer.eCharacterSet.USA);
                        Printer.wr_String(xInvoiceData.MyOrganisation.Email);
                        Printer.wr_SelectAnInternationalCharacterSet(Printer.eCharacterSet.Slovenia_Croatia);
                    }
                }
                Printer.wr_NewLine();
                Printer.wr_Paragraph("Davčna Številka:" + xInvoiceData.MyOrganisation.Tax_ID);
                Printer.wr_NewLine(2);
                //buffer = buffer + "\x1b\x1d\x61\x0";             //Left Alignment - Refer to Pg. 3-29
                Printer.wr_SetHorizontalTabPositions(new byte[] { 2, 0x10, 0x22 });
                Printer.wr_Paragraph("Številka računa: " + xInvoiceData.FinancialYear.ToString() + "/" + xInvoiceData.NumberInFinancialYear.ToString());
                Printer.wr_Paragraph("Datum:" + xInvoiceData.IssueDate_v.v.Day.ToString() + "." + xInvoiceData.IssueDate_v.v.Month.ToString() + "." + xInvoiceData.IssueDate_v.v.Year.ToString() + "\x9" + " Čas:" + xInvoiceData.IssueDate_v.v.Hour.ToString() + ":" + xInvoiceData.IssueDate_v.v.Minute.ToString());      //Moving Horizontal Tab - Pg. 3-26
                Printer.wr_LineDelimeter();
                Printer.wr_BoldOn();

                Printer.wr_Paragraph("PRODANO:");
                Printer.wr_NewLine();
                Printer.wr_BoldOff();

                //Select Emphasized Printing - Pg. 3-14;                    //Cancel Emphasized Printing - Pg. 3-14

                taxSum = null;
                taxSum = new StaticLib.TaxSum();

                foreach (ItemSold itmsold in xInvoiceData.ItemsSold)
                {
                    Printer.wr_Paragraph(itmsold.Item_Name);
                    Printer.wr_String("Cena za enoto" + HT + itmsold.RetailPricePerUnit.ToString() + " EUR\n");
                    decimal TotalDiscount = StaticLib.Func.TotalDiscount(itmsold.Discount, itmsold.ExtraDiscount, Program.Get_BaseCurrency_DecimalPlaces());
                    decimal TotalDiscountPercent = TotalDiscount * 100;
                    if (TotalDiscountPercent > 0)
                    {
                        Printer.wr_String("Popust:" + TotalDiscountPercent.ToString() + " %\n");
                    }
                    Printer.wr_String("Količina:" + HT + itmsold.dQuantity.ToString() + "\n");
                    if (TotalDiscountPercent > 0)
                    {
                        Printer.wr_String("Cena s popustom:" + HT + HT + itmsold.PriceWithTax.ToString() + " EUR\n");
                    }
                    else
                    {
                        Printer.wr_String("Cena " + HT + HT + HT + itmsold.PriceWithTax.ToString() + " EUR\n");
                    }
                    Printer.wr_String(itmsold.TaxationName + HT + HT + itmsold.TaxPrice.ToString() + " EUR\n");
                    Printer.wr_NewLine();
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

                ////Atom_DocInvoice_Price_Item_Stock.ID AS Atom_DocInvoice_Price_Item_Stock_ID,
                ////Atom_DocInvoice_Price_Item_Stock.DocInvoice_ID,
                ////DocInvoice.Atom_myCompany_Person_ID,
                ////Atom_DocInvoice_Price_Item_Stock.Stock_ID,
                ////Atom_DocInvoice_Price_Item_Stock.Atom_Price_Item_ID,
                ////Atom_Item.ID as Atom_Item_ID,
                ////itm.ID as Item_ID,
                ////Atom_Price_Item.RetailPricePerUnit,
                ////Atom_Price_Item.Discount,
                ////Atom_DocInvoice_Price_Item_Stock.RetailPriceWithDiscount,
                ////Atom_DocInvoice_Price_Item_Stock.TaxPrice,
                ////Atom_DocInvoice_Price_Item_Stock.ExtraDiscount,
                ////Atom_DocInvoice_Price_Item_Stock.dQuantity,
                ////Atom_DocInvoice_Price_Item_Stock.ExpiryDate,
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

                //foreach (Atom_DocInvoice_Price_Item_Stock_Data appisd in xInvoiceData.m_ShopABC.m_CurrentInvoice.m_Basket.Atom_DocInvoice_Price_Item_Stock_Data_LIST)
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
                Printer.wr_LineDelimeter();

                foreach (StaticLib.Tax tax in taxSum.TaxList)
                {
                    Printer.wr_String(tax.Name + HT + HT + "" + tax.TaxAmount.ToString() + " EUR\n");
                }

                Printer.wr_String("Brez davka " + HT + HT + "" + xInvoiceData.NetSum.ToString() + " EUR\n");
                //buffer += "\x1B" + "G" + "\xFF";
                Printer.wr_String("Skupaj " + HT + HT + xInvoiceData.GrossSum.ToString() + " EUR\n");
                //buffer += "\x1B" + "G" + "\x00\n";
                if (PaymentType != GlobalData.ePaymentType.NONE)
                {
                    Printer.wr_String("Način plačila:" + sPaymentMethod + "\n");
                    if (PaymentType == GlobalData.ePaymentType.CASH)
                    {
                        Printer.wr_String("  Prejeto: " + sAmountReceived + " EUR\n");
                        Printer.wr_String("  Vrnjeno: " + sToReturn + " EUR\n");
                    }
                }

                Printer.wr_NewLine(1);
                Printer.wr_String("Številka računa za FURS:\n");
                Printer.wr_String(Program.usrc_FVI_SLO1.FursD_BussinesPremiseID + "-" + Properties.Settings.Default.ElectronicDevice_ID+"-"+ xInvoiceData.NumberInFinancialYear.ToString());
                Printer.wr_NewLine(1);
                Printer.wr_String("Oseba, ki je izdala račun:\n");
                Printer.wr_String(xInvoiceData.Invoice_Author.FirstName+" "+ xInvoiceData.Invoice_Author.LastName);

                if (xInvoiceData.FURS_QR_v!= null)
                {
                    if (xInvoiceData.FURS_Image_QRcode != null)
                    {
                        //Size size = new Size(32, 32);
                        //Image img_new = StaticLib.Func.resizeImage(xInvoiceData.FURS_Response_Data.Image_QRcode, size, System.Drawing.Imaging.ImageFormat.Bmp, System.Drawing.Imaging.PixelFormat.Format1bppIndexed);
                        //byte[] barr = StaticLib.Func.imageToByteArray(img_new);
                        Printer.wr_NewLine(1);
                        Printer.wr_String("ZOI:"+ xInvoiceData.FURS_ZOI_v.v + "\n");
                        Printer.wr_String("EOR:" + xInvoiceData.FURS_EOR_v.v + "\n");
                        Printer.wr_NewLine(1);
                        byte[] barr = StaticLib.Func.imageToByteArray(xInvoiceData.FURS_Image_QRcode);
                        Printer.wr_BitmapByteArray(barr,180);
                    }
                }

                Printer.wr_NewLine(6);
                Printer.PartialCutPaper();

                if (Printer.PrintInBuffer)
                {
                    Printer.Print_PrinterBuffer();
                }


                string s_journal_invoice_type = lngRPM.s_journal_invoice_type_Print.s;
                string s_journal_invoice_description = Printer.PrinterName;
                f_Journal_DocInvoice.Write(xInvoiceData.DocInvoice_ID, GlobalData.Atom_WorkPeriod_ID, s_journal_invoice_type, s_journal_invoice_description, null, ref journal_docinvoice_id);
            }
            catch (Exception ex)
            {
                string s_journal_invoice_type = lngRPM.s_journal_invoice_type_PrintError.s + Printer.PrinterName + "\nErr=" + ex.Message;
                string s_journal_invoice_description = Printer.PrinterName;
                f_Journal_DocInvoice.Write(xInvoiceData.DocInvoice_ID, GlobalData.Atom_WorkPeriod_ID, s_journal_invoice_type, s_journal_invoice_description, null, ref journal_docinvoice_id);
            }
        }

        public bool Init(InvoiceData x_InvoiceData)
        {
            m_InvoiceData = x_InvoiceData;
            //lbl_PrinterName.Text = lngRPM.s_Printer.s;
            Printer.PrinterName = Printer.printer_settings.PrinterName;
            //lbl_PaperName.Text = lngRPM.s_PaperName.s + ":";
            PaperName = Printer.page_settings.PaperSize.PaperName;
            //chk_PrintAll.Text = lngRPM.s_chk_PrintAll.s;
            //this.chk_PrintAll.CheckedChanged -= new System.EventHandler(this.chk_PrintAll_CheckedChanged);
            //chk_PrintAll.Checked = Properties.Settings.Default.PrintAtOnce;
            //ReceiptPrinter.PrintInBuffer = chk_PrintAll.Checked;
            //this.chk_PrintAll.CheckedChanged += new System.EventHandler(this.chk_PrintAll_CheckedChanged);


            if (Printer != null)
            {
                int iWidth_inHoundreths_of_Inch = Printer.page_settings.PaperSize.Width;

                int dpix = Printer.page_settings.PrinterResolution.X;

                cx_paper_in_inch = ((float)iWidth_inHoundreths_of_Inch) / ((float)100);
                cx_paper_on_screen_in_pixels = (int)(cx_paper_in_inch * getScalingFactorX());
                //this.pnl_paper.Width = cx_paper_on_screen_in_pixels;

                int iHeight_inHoundreths_of_Inch = Printer.page_settings.PaperSize.Height;

                int dpiy = Printer.page_settings.PrinterResolution.Y;

                cy_paper_in_inch = ((float)iHeight_inHoundreths_of_Inch) / ((float)100);
                cy_paper_on_screen_in_pixels = (int)(cy_paper_in_inch * getScalingFactorY());
                //this.pnl_paper.Height = cy_paper_on_screen_in_pixels;
                return true;

            }
            else
            {
                LogFile.Error.Show("ERROR:usrc_Invoice_Preview:Init:ReceiptPrinter == null!");
                return false;
            }
        }

        private float getScalingFactorX()
        {
            Graphics g = Graphics.FromHwnd(this.Handle);
            return g.DpiX;
        }

        private float getScalingFactorY()
        {
            Graphics g = Graphics.FromHwnd(this.Handle);
            return g.DpiY;
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
            if (m_InvoiceData.m_ShopABC.m_CurrentInvoice.m_Basket.m_Atom_DocInvoice_Price_Item_Stock_Data_LIST.Count > 0)
            {
                object o_Data = m_InvoiceData.m_ShopABC.m_CurrentInvoice.m_Basket.m_Atom_DocInvoice_Price_Item_Stock_Data_LIST[0];
                if (o_Data is Atom_DocInvoice_ShopC_Item_Price_Stock_Data)
                {
                    return (int)((Atom_DocInvoice_ShopC_Item_Price_Stock_Data)(o_Data)).Atom_Currency_DecimalPlaces.v;
                }
            }
            if (m_InvoiceData.m_ShopABC.m_CurrentInvoice.m_Basket.dtDraft_DocInvoice_Atom_Item_Stock.Rows.Count > 0)
            {
                object o_Currency_DecimalPlaces = m_InvoiceData.m_ShopABC.m_CurrentInvoice.m_Basket.dtDraft_DocInvoice_Atom_Item_Stock.Rows[0]["Atom_Currency_DecimalPlaces"];
                if (o_Currency_DecimalPlaces.GetType() == typeof(int))
                {
                    return (int)o_Currency_DecimalPlaces;
                }
            }
            return GlobalData.BaseCurrency.DecimalPlaces;
        }





        internal void PrintReport(usrc_InvoiceTable m_usrc_InvoiceTable)
        {
            // Print header
            Printer.Clear();
            Printer.wr_SelectAnInternationalCharacterSet(Printer.eCharacterSet.Slovenia_Croatia);
            Printer.wr_Paragraph(m_usrc_InvoiceTable.lbl_From_To.Text);
            Printer.wr_LineDelimeter();
            string sLine = lngRPM.s_Invoice.s + HT + lngRPM.s_MethodOfPayment.s + HT + lngRPM.s_EndPrice.s;
            Printer.wr_String(sLine);
            Printer.wr_NewLine();
            foreach (DataRow dr in m_usrc_InvoiceTable.dt_XInvoice.Rows)
            {

                if ((bool)dr["JOURNAL_DocInvoice_$_dinv_$$Draft"])
                {
                    continue;
                }
                else
                {
                    Printer.wr_NewLine();
                    int iFinYear = (int)dr["JOURNAL_DocInvoice_$_dinv_$$FinancialYear"];
                    int iNumberInFinancialYear = (int)dr["JOURNAL_DocInvoice_$_dinv_$$NumberInFinancialYear"];
                    string payment_type = (string)dr["JOURNAL_DocInvoice_$_dinv_$_inv_$_metopay_$$PaymentType"];
                    decimal GrossSum = (decimal)dr["JOURNAL_DocInvoice_$_dinv_$$GrossSum"];
                    bool Storno = (bool)dr["JOURNAL_DocInvoice_$_dinv_$_inv_$$Storno"];
                    DateTime DocInvoice_Date = (DateTime)dr["JOURNAL_DocInvoice_$$EventTime"];
                    sLine = DocInvoice_Date.ToString() + ":";
                    Printer.wr_Paragraph(sLine);
                    if (Storno)
                    {
                        sLine = "**STORNO:" + iFinYear.ToString() + "/" + iNumberInFinancialYear.ToString() + HT + payment_type + HT + GrossSum.ToString();
                    }
                    else
                    {
                        sLine = iFinYear.ToString() + "/" + iNumberInFinancialYear.ToString() + HT + payment_type + HT + GrossSum.ToString();
                    }
                    Printer.wr_Paragraph(sLine);

                }
            }
            Printer.wr_LineDelimeter();
            Printer.wr_Paragraph("");
            Printer.wr_Paragraph(m_usrc_InvoiceTable.lbl_Sum_All.Text);
            Printer.wr_Paragraph(m_usrc_InvoiceTable.lbl_Sum_Tax.Text);
            Printer.wr_Paragraph(m_usrc_InvoiceTable.lbl_Sum_WithoutTax.Text);
            Printer.wr_Paragraph(m_usrc_InvoiceTable.lbl_Payment1.Text);
            Printer.wr_Paragraph(m_usrc_InvoiceTable.lbl_Payment2.Text);
            Printer.wr_NewLine(10);
            Printer.PartialCutPaper();
            Printer.Print_PrinterBuffer();
        }


    }
}
