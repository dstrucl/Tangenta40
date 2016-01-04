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
using LanguageControl;
using DBTypes;
using FiscalVerificationOfInvoices_SLO;

namespace Tangenta
{
    public partial class usrc_Printer : UserControl
    {


        private string m_PrinterName = null;
        private string m_PaperName = null;
        public string PrinterName
        {
            get
            {
                return m_PrinterName;
            }
            set
            {
                m_PrinterName = value;
                if (m_PrinterName != null)
                {
                    lbl_PrinterName_Value.Text = m_PrinterName;
                }
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
                    lbl_PaperName_Value.Text = m_PaperName;
                }
            }
        }

        public string HT = "\x09"; //CarriageReturn
        private long myCompany_Person_ID = -1;
        [DllImport("gdi32.dll")]
        static extern int GetDeviceCaps(IntPtr hdc, int nIndex);



        public InvoiceData m_InvoiceData = null;
        public StaticLib.TaxSum taxSum = null;
        
        private long_v Atom_Customer_Org_ID = null;
        private long_v Atom_Customer_Person_ID = null;


        float cx_paper_in_inch = 0;
        float cy_paper_in_inch = 0;

        int cx_paper_on_screen_in_pixels = 0;
        int cy_paper_on_screen_in_pixels = 0;


        public usrc_Printer()
        {
            InitializeComponent();
        }



        internal void Print_Receipt(InvoiceData xInvoiceData, usrc_Payment.ePaymentType PaymentType, string sPaymentMethod, string sAmountReceived, string sToReturn, DateTime_v issue_time)
        {


            string furs_XML = "";
            string furs_UniqeMsgID = "";
            string furs_UniqeInvID = "";

            //TODO:
            //naredi xml


            //pošlji 

            Program.usrc_FVI_SLO1.Send_SingleInvoice( furs_XML,this.Parent ,ref furs_UniqeMsgID, ref furs_UniqeInvID);

            if (Program.b_FVI_SLO)
            {
              //  furs_XML Program.usrc_FVI_SLO1.Send_SingleInvoice(furs_ID, furs_XML);
            }
            if (Printer_is_ESC_POS())
            {
                Print_Receipt_ESC_POS(xInvoiceData,PaymentType, sPaymentMethod, sAmountReceived, sToReturn, issue_time);
            }
            else
            {
                Form_Print_A4 print_A4_dlg = new Form_Print_A4(this,PaymentType, sPaymentMethod, sAmountReceived, sToReturn, issue_time);
                print_A4_dlg.ShowDialog();
            }
        }
    

        private void FVI_SLO_GetResponse(ref string fVI_MessageID, ref string fVI_UniqueInvoiceID)
        {
            throw new NotImplementedException();
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

        internal void Print_Receipt_ESC_POS(InvoiceData xInvoiceData,usrc_Payment.ePaymentType PaymentType, string sPaymentMethod, string sAmountReceived, string sToReturn, DateTime_v issue_time)
        {
          
            
            //Program.ReceiptPrinter.Print(ep.InitializePrinter());
            long journal_proformainvoice_id = -1;

            try
            {
                if (Program.ReceiptPrinter.InitializePrinter())
                {

                }
                if (Program.ReceiptPrinter.PrintInBuffer)
                {
                    Program.ReceiptPrinter.Clear();
                }

                if (xInvoiceData.Logo_Data != null)
                {
                   Program.ReceiptPrinter.wr_Logo(xInvoiceData.Logo_Data);
                }

                Program.ReceiptPrinter.wr_SelectAnInternationalCharacterSet(Printer.eCharacterSet.Slovenia_Croatia);
                Program.ReceiptPrinter.wr_Paragraph(m_InvoiceData.MyOrganisation.Name);
                Program.ReceiptPrinter.wr_Paragraph(m_InvoiceData.MyOrganisation.Address.StreetName + " " + m_InvoiceData.MyOrganisation.Address.HouseNumber);
                Program.ReceiptPrinter.wr_Paragraph(m_InvoiceData.MyOrganisation.Address.ZIP + " " + m_InvoiceData.MyOrganisation.Address.City);
                if (m_InvoiceData.MyOrganisation.HomePage != null)
                {
                    if (m_InvoiceData.MyOrganisation.HomePage.Length > 0)
                    {
                        Program.ReceiptPrinter.wr_String("Domača stran:");
                        Program.ReceiptPrinter.wr_SelectAnInternationalCharacterSet(Printer.eCharacterSet.USA);
                        Program.ReceiptPrinter.wr_String(m_InvoiceData.MyOrganisation.HomePage);
                        Program.ReceiptPrinter.wr_SelectAnInternationalCharacterSet(Printer.eCharacterSet.Slovenia_Croatia);
                        Program.ReceiptPrinter.wr_NewLine();
                        ;
                    }
                }
                if (m_InvoiceData.MyOrganisation.Email != null)
                {
                    if (m_InvoiceData.MyOrganisation.Email.Length > 0)
                    {
                        Program.ReceiptPrinter.wr_String("EPOŠTA:");
                        Program.ReceiptPrinter.wr_SelectAnInternationalCharacterSet(Printer.eCharacterSet.USA);
                        Program.ReceiptPrinter.wr_String(m_InvoiceData.MyOrganisation.Email);
                        Program.ReceiptPrinter.wr_SelectAnInternationalCharacterSet(Printer.eCharacterSet.Slovenia_Croatia);
                    }
                }
                Program.ReceiptPrinter.wr_NewLine();
                Program.ReceiptPrinter.wr_Paragraph("Davčna Številka:" + m_InvoiceData.MyOrganisation.Tax_ID);
                Program.ReceiptPrinter.wr_NewLine(2);
                //buffer = buffer + "\x1b\x1d\x61\x0";             //Left Alignment - Refer to Pg. 3-29
                Program.ReceiptPrinter.wr_SetHorizontalTabPositions(new byte[] { 2, 0x10, 0x22 });
                Program.ReceiptPrinter.wr_Paragraph("Številka računa: " + m_InvoiceData.FinancialYear.ToString() + "/" + m_InvoiceData.NumberInFinancialYear.ToString());
                Program.ReceiptPrinter.wr_Paragraph("Datum:" + xInvoiceData.IssueDate_Day.ToString() + "." + xInvoiceData.IssueDate_Month.ToString() + "." + xInvoiceData.IssueDate_Year.ToString() + "\x9" + " Čas:" + xInvoiceData.IssueDate_Hour.ToString() + ":" + xInvoiceData.IssueDate_Min.ToString());      //Moving Horizontal Tab - Pg. 3-26
                Program.ReceiptPrinter.wr_LineDelimeter();
                Program.ReceiptPrinter.wr_BoldOn();

                Program.ReceiptPrinter.wr_Paragraph("PRODANO:");
                Program.ReceiptPrinter.wr_NewLine();
                Program.ReceiptPrinter.wr_BoldOff();
    
                                   //Select Emphasized Printing - Pg. 3-14;                    //Cancel Emphasized Printing - Pg. 3-14

                taxSum = null;
                taxSum = new StaticLib.TaxSum();

                foreach (DataRow dr in m_InvoiceData.dt_Atom_Price_SimpleItem.Rows)
                {
                    object o_SimpleItem_name = dr["Name"];
                    string SimpleItem_name = null;
                    if (o_SimpleItem_name.GetType() == typeof(string))
                    {
                        SimpleItem_name = (string)o_SimpleItem_name;
                    }

                    decimal RetailSimpleItemPrice = 0;
                    object o_RetailSimpleItemPrice = dr["RetailSimpleItemPrice"];
                    if (o_RetailSimpleItemPrice.GetType() == typeof(decimal))
                    {
                        RetailSimpleItemPrice = (decimal)o_RetailSimpleItemPrice;
                    }

                    decimal RetailSimpleItemPriceWithDiscount = 0;
                    object o_RetailSimpleItemPriceWithDiscount = dr["RetailSimpleItemPriceWithDiscount"];
                    if (o_RetailSimpleItemPriceWithDiscount.GetType() == typeof(decimal))
                    {
                        RetailSimpleItemPriceWithDiscount = (decimal)o_RetailSimpleItemPriceWithDiscount;
                    }

                    string TaxationName = "Davek ???";
                    object oTaxationName = dr["Atom_Taxation_Name"];
                    if (oTaxationName is string)
                    {
                        TaxationName = (string)oTaxationName;
                    }

                    decimal TaxPrice = -1;
                    object oTaxPrice = dr["TaxPrice"];
                    if (oTaxPrice is decimal)
                    {
                        TaxPrice = (decimal)oTaxPrice;
                        taxSum.Add(TaxPrice, (string)dr["Atom_Taxation_Name"], (decimal)dr["Atom_Taxation_Rate"]);
                    }

                    int iQuantity = -1;
                    object oQuantity = dr["iQuantity"];
                    if (oQuantity is int)
                    {
                        iQuantity = (int)oQuantity;
                    }

                    decimal Discount = 0;
                    object oDiscount = dr["Discount"];
                    if (oDiscount is decimal)
                    {
                        Discount = (decimal)oDiscount;
                    }

                    decimal ExtraDiscount = 0;
                    object oExtraDiscount = dr["ExtraDiscount"];
                    if (oExtraDiscount is decimal)
                    {
                        ExtraDiscount = (decimal)oExtraDiscount;
                    }

                    Program.ReceiptPrinter.wr_Paragraph(SimpleItem_name);
                    Program.ReceiptPrinter.wr_String("Cena za enoto" + HT + RetailSimpleItemPrice.ToString() + " EUR\n");
                    decimal TotalDiscount = StaticLib.Func.TotalDiscount(Discount, ExtraDiscount,Program.Get_BaseCurrency_DecimalPlaces());
                    decimal TotalDiscountPercent = TotalDiscount * 100;
                    if (TotalDiscountPercent > 0)
                    {
                        Program.ReceiptPrinter.wr_String("Popust:" + TotalDiscountPercent.ToString() + " %\n");
                    }
                        Program.ReceiptPrinter.wr_String("Količina:" + HT + iQuantity.ToString() + "\n");
                    if (TotalDiscountPercent > 0)
                    {
                        Program.ReceiptPrinter.wr_String("Cena s popustom:" + HT + HT + RetailSimpleItemPriceWithDiscount.ToString() + " EUR\n");
                    }
                    else
                    {
                        Program.ReceiptPrinter.wr_String("Cena " + HT + HT + HT + RetailSimpleItemPriceWithDiscount.ToString() + " EUR\n");
                    }
                    Program.ReceiptPrinter.wr_String(TaxationName + HT + HT + TaxPrice.ToString() + " EUR\n");
                    Program.ReceiptPrinter.wr_NewLine();

                }

                //Atom_ProformaInvoice_Price_Item_Stock.ID AS Atom_ProformaInvoice_Price_Item_Stock_ID,
                //Atom_ProformaInvoice_Price_Item_Stock.ProformaInvoice_ID,
                //ProformaInvoice.Atom_myCompany_Person_ID,
                //Atom_ProformaInvoice_Price_Item_Stock.Stock_ID,
                //Atom_ProformaInvoice_Price_Item_Stock.Atom_Price_Item_ID,
                //Atom_Item.ID as Atom_Item_ID,
                //itm.ID as Item_ID,
                //Atom_Price_Item.RetailPricePerUnit,
                //Atom_Price_Item.Discount,
                //Atom_ProformaInvoice_Price_Item_Stock.RetailPriceWithDiscount,
                //Atom_ProformaInvoice_Price_Item_Stock.TaxPrice,
                //Atom_ProformaInvoice_Price_Item_Stock.ExtraDiscount,
                //Atom_ProformaInvoice_Price_Item_Stock.dQuantity,
                //Atom_ProformaInvoice_Price_Item_Stock.ExpiryDate,
                //Atom_Item.UniqueName AS Atom_Item_UniqueName,
                //Atom_Item_Name.Name AS Atom_Item_Name_Name,
                //Atom_Item_barcode.barcode AS Atom_Item_barcode_barcode,
                //Atom_Taxation.Name AS Atom_Taxation_Name,
                //Atom_Taxation.Rate AS Atom_Taxation_Rate,
                //Atom_Item_Description.Description AS Atom_Item_Description_Description,
                //Atom_Item.Atom_Warranty_ID,
                //Atom_Warranty.WarrantyDurationType AS Atom_Warranty_WarrantyDurationType,
                //Atom_Warranty.WarrantyDuration AS Atom_Warranty_WarrantyDuration,
                //Atom_Warranty.WarrantyConditions AS Atom_Warranty_WarrantyConditions,
                //Atom_Item.Atom_Expiry_ID,
                //Atom_Expiry.ExpectedShelfLifeInDays AS Atom_Expiry_ExpectedShelfLifeInDays,
                //Atom_Expiry.SaleBeforeExpiryDateInDays AS Atom_Expiry_SaleBeforeExpiryDateInDays,
                //Atom_Expiry.DiscardBeforeExpiryDateInDays AS Atom_Expiry_DiscardBeforeExpiryDateInDays,
                //Atom_Expiry.ExpiryDescription AS Atom_Expiry_ExpiryDescription,
                //puitms.Item_ID AS Stock_Item_ID,
                //Stock.ImportTime AS Stock_ImportTime,
                //Stock.dQuantity AS Stock_dQuantity,
                //Stock.ExpiryDate AS Stock_ExpiryDate,
                //Atom_Unit.Name AS Atom_Unit_Name,
                //Atom_Unit.Symbol AS Atom_Unit_Symbol,
                //Atom_Unit.DecimalPlaces AS Atom_Unit_DecimalPlaces,
                //Atom_Unit.Description AS Atom_Unit_Description,
                //Atom_Unit.StorageOption AS Atom_Unit_StorageOption,
                //Atom_PriceList.Name AS Atom_PriceList_Name,
                //Atom_Currency.Name AS Atom_Currency_Name,
                //Atom_Currency.Abbreviation AS Atom_Currency_Abbreviation,
                //Atom_Currency.Symbol AS Atom_Currency_Symbol,
                //Atom_Currency.DecimalPlaces AS Atom_Currency_DecimalPlaces
                Program.ReceiptPrinter.wr_NewLine();

                foreach (Atom_ProformaInvoice_Price_Item_Stock_Data appisd in m_InvoiceData.m_InvoiceDB.m_CurrentInvoice.m_Basket.Atom_ProformaInvoice_Price_Item_Stock_Data_LIST)
                {
                    string Item_UniqueName = appisd.Atom_Item_UniqueName.v;

                    decimal RetailPricePerUnit = appisd.RetailPricePerUnit.v;


                    decimal RetailItemPriceWithDiscount =  appisd.RetailPriceWithDiscount.v;

                    Program.ReceiptPrinter.wr_String(Item_UniqueName + "\n");

                    decimal dQuantity = appisd.dQuantity_FromStock + appisd.dQuantity_FromFactory;

                    string Atom_Unit_Name = appisd.Atom_Unit_Name.v;


                    Program.ReceiptPrinter.wr_String("Cena za 1 " + Atom_Unit_Name + " = " + RetailPricePerUnit.ToString() + " EUR\n");

                    decimal Discount = appisd.Discount.v;

                    decimal ExtraDiscount = appisd.ExtraDiscount.v;


                    decimal TotalDiscount = StaticLib.Func.TotalDiscount(Discount, ExtraDiscount,Program.Get_BaseCurrency_DecimalPlaces());
                    decimal TotalDiscountPercent = TotalDiscount * 100;
                    if (TotalDiscountPercent > 0)
                    {
                        Program.ReceiptPrinter.wr_String("Popust:" + TotalDiscountPercent.ToString() + " %\n");
                    }
                    Program.ReceiptPrinter.wr_String("Količina:" + HT + dQuantity.ToString() + " " + Atom_Unit_Name + "\n");

                    decimal Atom_Taxation_Rate = appisd.Atom_Taxation_Rate.v;
                    
                    decimal RetailItemsPriceWithDiscount = 0;
                    decimal ItemsTaxPrice = 0;
                    decimal ItemsNetPrice = 0;

                    int decimal_places = appisd.Atom_Currency_DecimalPlaces.v;

                    StaticLib.Func.CalculatePrice(RetailPricePerUnit, dQuantity, Discount, ExtraDiscount, Atom_Taxation_Rate, ref RetailItemsPriceWithDiscount, ref ItemsTaxPrice, ref ItemsNetPrice, decimal_places);

                    if (TotalDiscountPercent > 0)
                    {
                        Program.ReceiptPrinter.wr_String("Cena s popustom:" + HT + HT + RetailItemsPriceWithDiscount.ToString() + " EUR\n");
                    }
                    else
                    {
                        Program.ReceiptPrinter.wr_String("Cena " + HT + HT + HT + RetailItemsPriceWithDiscount.ToString() + " EUR\n");
                    }

                    string TaxationName = appisd.Atom_Taxation_Name.v;

                    decimal TaxPrice = appisd.TaxPrice.v;

                    taxSum.Add(ItemsTaxPrice, TaxationName, Atom_Taxation_Rate);


                    Program.ReceiptPrinter.wr_String(TaxationName + HT + HT + ItemsTaxPrice.ToString() + " EUR\n");
                    Program.ReceiptPrinter.wr_NewLine();

                }
                Program.ReceiptPrinter.wr_LineDelimeter();

                foreach (StaticLib.Tax tax in taxSum.TaxList)
                {
                    Program.ReceiptPrinter.wr_String(tax.Name +  HT + HT + "" + tax.Sum.ToString() + " EUR\n");
                }
                
                Program.ReceiptPrinter.wr_String("Brez davka " +  HT + HT + "" + m_InvoiceData.NetSum.ToString() + " EUR\n");
                //buffer += "\x1B" + "G" + "\xFF";
                Program.ReceiptPrinter.wr_String("Skupaj " + HT + HT + m_InvoiceData.GrossSum.ToString() + " EUR\n"); 
                //buffer += "\x1B" + "G" + "\x00\n";
                if (PaymentType != usrc_Payment.ePaymentType.NONE)
                { 
                    Program.ReceiptPrinter.wr_String("Način plačila:" + sPaymentMethod + "\n");
                    if (PaymentType == usrc_Payment.ePaymentType.CASH)
                    {
                        Program.ReceiptPrinter.wr_String("  Prejeto: " + sAmountReceived + " EUR\n");
                        Program.ReceiptPrinter.wr_String("  Vrnjeno: " + sToReturn + " EUR\n");
                    }
                }
                Program.ReceiptPrinter.wr_NewLine(6);
                Program.ReceiptPrinter.PartialCutPaper();

                if (Program.ReceiptPrinter.PrintInBuffer)
                {
                    Program.ReceiptPrinter.Print_PrinterBuffer();
                }
            

                string s_journal_invoice_type = lngRPM.s_journal_invoice_type_Print.s;
                string s_journal_invoice_description = Program.ReceiptPrinter.PrinterName;
                f_Journal_ProformaInvoice.Write(m_InvoiceData.ProformaInvoice_ID, Program.Atom_WorkPeriod_ID, s_journal_invoice_type, s_journal_invoice_description,null, ref journal_proformainvoice_id);
            }
            catch (Exception ex)
            {
                string s_journal_invoice_type = lngRPM.s_journal_invoice_type_PrintError.s + Program.ReceiptPrinter.PrinterName+ "\nErr="+ex.Message;
                string s_journal_invoice_description = Program.ReceiptPrinter.PrinterName;
                f_Journal_ProformaInvoice.Write(m_InvoiceData.ProformaInvoice_ID, Program.Atom_WorkPeriod_ID, s_journal_invoice_type, s_journal_invoice_description,null, ref journal_proformainvoice_id);
            }
        }

        public bool Init(InvoiceData x_InvoiceData)
        {
            m_InvoiceData = x_InvoiceData;
            lbl_PrinterName.Text = lngRPM.s_Printer.s;
            PrinterName = Program.ReceiptPrinter.printer_settings.PrinterName;
            lbl_PaperName.Text = lngRPM.s_PaperName.s + ":";
            PaperName = Program.ReceiptPrinter.page_settings.PaperSize.PaperName;
            chk_PrintAll.Text = lngRPM.s_chk_PrintAll.s;
            this.chk_PrintAll.CheckedChanged -= new System.EventHandler(this.chk_PrintAll_CheckedChanged);
            chk_PrintAll.Checked = Properties.Settings.Default.PrintAtOnce;
            Program.ReceiptPrinter.PrintInBuffer = chk_PrintAll.Checked;
            this.chk_PrintAll.CheckedChanged += new System.EventHandler(this.chk_PrintAll_CheckedChanged);
 

            if (Program.ReceiptPrinter != null)
            {
                int iWidth_inHoundreths_of_Inch = Program.ReceiptPrinter.page_settings.PaperSize.Width;

                int dpix = Program.ReceiptPrinter.page_settings.PrinterResolution.X;

                cx_paper_in_inch = ((float)iWidth_inHoundreths_of_Inch) / ((float)100);
                cx_paper_on_screen_in_pixels = (int)(cx_paper_in_inch * getScalingFactorX());
                //this.pnl_paper.Width = cx_paper_on_screen_in_pixels;

                int iHeight_inHoundreths_of_Inch = Program.ReceiptPrinter.page_settings.PaperSize.Height;

                int dpiy = Program.ReceiptPrinter.page_settings.PrinterResolution.Y;

                cy_paper_in_inch = ((float)iHeight_inHoundreths_of_Inch) / ((float)100);
                cy_paper_on_screen_in_pixels = (int)(cy_paper_in_inch * getScalingFactorY());
                //this.pnl_paper.Height = cy_paper_on_screen_in_pixels;
                return true;

            }
            else
            {
                LogFile.Error.Show("ERROR:usrc_Invoice_Preview:Init:Program.ReceiptPrinter == null!");
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
            if (m_InvoiceData.dt_Atom_Price_SimpleItem.Rows.Count > 0)
            {
                object o_Currency_DecimalPlaces = m_InvoiceData.dt_Atom_Price_SimpleItem.Rows[0]["Atom_Currency_DecimalPlaces"];
                if (o_Currency_DecimalPlaces.GetType() == typeof(int))
                {
                    return (int)o_Currency_DecimalPlaces;
                }
            }
            if (m_InvoiceData.m_InvoiceDB.m_CurrentInvoice.m_Basket.Atom_ProformaInvoice_Price_Item_Stock_Data_LIST.Count >0)
            {
                object o_Data = m_InvoiceData.m_InvoiceDB.m_CurrentInvoice.m_Basket.Atom_ProformaInvoice_Price_Item_Stock_Data_LIST[0];
                if (o_Data is Atom_ProformaInvoice_Price_Item_Stock_Data)
                {
                    return (int)((Atom_ProformaInvoice_Price_Item_Stock_Data)(o_Data)).Atom_Currency_DecimalPlaces.v;
                }
            }
            if (m_InvoiceData.m_InvoiceDB.m_CurrentInvoice.m_Basket.dtDraft_ProformaInvoice_Atom_Item_Stock.Rows.Count > 0)
            {
                object o_Currency_DecimalPlaces = m_InvoiceData.m_InvoiceDB.m_CurrentInvoice.m_Basket.dtDraft_ProformaInvoice_Atom_Item_Stock.Rows[0]["Atom_Currency_DecimalPlaces"];
                if (o_Currency_DecimalPlaces.GetType() == typeof(int))
                {
                    return (int)o_Currency_DecimalPlaces;
                }
            }
            LogFile.Error.Show("ERROR:usrc_Print:Get_CurrencyD_DecimalPlaces:NUmber of decimal places not found!Returned 2 decimal places.");
            return 2;
        }

        private void btn_SelectPrinter_Click(object sender, EventArgs e)
        {
            if (Program.ReceiptPrinter.Select(null))
            {
                PrinterName = Program.ReceiptPrinter.printer_settings.PrinterName;
                PaperName = Program.ReceiptPrinter.page_settings.PaperSize.PaperName;
            }
        }

        private void btn_PageSetup_Click(object sender, EventArgs e)
        {
            Program.ReceiptPrinter.SelectPageSettings();
        }

        private void chk_PrintAll_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.PrintAtOnce =chk_PrintAll.Checked;
            Program.ReceiptPrinter.PrintInBuffer = chk_PrintAll.Checked;
            Properties.Settings.Default.Save();
        }





        internal void PrintReport(usrc_InvoiceTable m_usrc_InvoiceTable)
        {
            // Print header
            Program.ReceiptPrinter.Clear();
            Program.ReceiptPrinter.wr_SelectAnInternationalCharacterSet(Printer.eCharacterSet.Slovenia_Croatia);
            Program.ReceiptPrinter.wr_Paragraph(m_usrc_InvoiceTable.lbl_From_To.Text);
            Program.ReceiptPrinter.wr_LineDelimeter();
            string sLine = lngRPM.s_Invoice.s+HT+lngRPM.s_MethodOfPayment.s+HT+lngRPM.s_EndPrice.s;
            Program.ReceiptPrinter.wr_String(sLine);
            Program.ReceiptPrinter.wr_NewLine();
            foreach (DataRow dr in m_usrc_InvoiceTable.dt_XInvoice.Rows)
            {

                if ((bool)dr["JOURNAL_ProformaInvoice_$_pinv_$$Draft"])
                {
                    continue;
                }
                else
                {
                    Program.ReceiptPrinter.wr_NewLine();
                    int iFinYear = (int)dr["JOURNAL_ProformaInvoice_$_pinv_$$FinancialYear"];
                    int iNumberInFinancialYear = (int)dr["JOURNAL_ProformaInvoice_$_pinv_$$NumberInFinancialYear"];
                    string payment_type = (string)dr["JOURNAL_ProformaInvoice_$_pinv_$_inv_$_metopay_$$PaymentType"];
                    decimal GrossSum = (decimal)dr["JOURNAL_ProformaInvoice_$_pinv_$$GrossSum"];
                    bool Storno = (bool)dr["JOURNAL_ProformaInvoice_$_pinv_$_inv_$$Storno"];
                    DateTime ProformaInvoice_Date = (DateTime)dr["JOURNAL_ProformaInvoice_$$EventTime"];
                    sLine = ProformaInvoice_Date.ToString() + ":";
                    Program.ReceiptPrinter.wr_Paragraph(sLine);
                    if (Storno)
                    {
                        sLine = "**STORNO:" + iFinYear.ToString() + "/" + iNumberInFinancialYear.ToString() + HT + payment_type + HT + GrossSum.ToString();
                    }
                    else
                    {
                        sLine = iFinYear.ToString() + "/" + iNumberInFinancialYear.ToString() + HT + payment_type + HT + GrossSum.ToString();
                    }
                    Program.ReceiptPrinter.wr_Paragraph(sLine);

                }
            }
            Program.ReceiptPrinter.wr_LineDelimeter();
            Program.ReceiptPrinter.wr_Paragraph("");
            Program.ReceiptPrinter.wr_Paragraph(m_usrc_InvoiceTable.lbl_Sum_All.Text);
            Program.ReceiptPrinter.wr_Paragraph(m_usrc_InvoiceTable.lbl_Sum_Tax.Text);
            Program.ReceiptPrinter.wr_Paragraph(m_usrc_InvoiceTable.lbl_Sum_WithoutTax.Text);
            Program.ReceiptPrinter.wr_Paragraph(m_usrc_InvoiceTable.lbl_Payment1.Text);
            Program.ReceiptPrinter.wr_Paragraph(m_usrc_InvoiceTable.lbl_Payment2.Text);
            Program.ReceiptPrinter.wr_NewLine(10);
            Program.ReceiptPrinter.PartialCutPaper();
            Program.ReceiptPrinter.Print_PrinterBuffer();
        }
    }
}
