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

namespace Tangenta
{
    public partial class usrc_Print : UserControl
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
        public DataTable dt_ProformaInvoice = new DataTable();
        public DataTable dt_Atom_Price_SimpleItem = new DataTable();
        public long ProformaInvoice_ID = -1;
        public long Invoice_ID = -1;
        [DllImport("gdi32.dll")]
        static extern int GetDeviceCaps(IntPtr hdc, int nIndex);


        public int PrintDate_Hour = 0;
        public int PrintDate_Min = 0;
        public int PrintDate_Sec = 0;
        public byte[] Logo_Data = null;
        public string Logo_Description = null;
        public string Organisation_Name = null;
        
        public int PrintDate_Day = 0;
        public int PrintDate_Month = 0;
        public int PrintDate_Year = 0;

        public string Currency_Symbol = null;
        public int Currency_DecimalPlaces = -1;

        InvoiceDB m_InvoiceDB = null;
        public int FinancialYear = -1;
        public int NumberInFinancialYear = -1;
        public decimal GrossSum = 0;
        public decimal taxsum = 0;
        public TaxSum taxSum = null;
        public decimal NetSum = 0;
        public string Organisation_Tax_ID = null;
        public string Organisation_Registration_ID = null;
        public string Organisation_ZIP = null;
        public string Organisation_StreetName = null;
        public string Organisation_HouseNumber = null;
        public string Organisation_City = null;
        public string Organisation_State = null;
        public string Organisation_Country = null;
        public string HomePage = null;
        public string Email = null;

        float cx_paper_in_inch = 0;
        float cy_paper_in_inch = 0;

        int cx_paper_on_screen_in_pixels = 0;
        int cy_paper_on_screen_in_pixels = 0;


        public usrc_Print()
        {
            InitializeComponent();
        }

        internal bool Read_ProformaInvoice()
        {
            string sql = @"select
                                 inv.ID as Invoice_ID,
                                 ProformaInvoice.FinancialYear,
                                 ProformaInvoice.NumberInFinancialYear,
                                 mpay.PaymentType,
                                 GrossSum,
                                 TaxSum,
                                 NetSum,
                                 Atom_Organisation.Name,
                                 Atom_Organisation.Tax_ID,
                                 Atom_Organisation.Registration_ID,
                                 Atom_cStreetName_Org.StreetName,
                                 Atom_cHouseNumber_Org.HouseNumber,
                                 Atom_cCity_Org.City,
                                 Atom_cZIP_Org.ZIP,
                                 Atom_cState_Org.State,
                                 Atom_cCountry_Org.Country,
                                 cHomePage_Org.HomePage,
                                 cEmail_Org.Email,
                                 Atom_Office.Name as Atom_Office_Name,
                                 Atom_myCompany_Person.UserName,
                                 Atom_myCompany_Person.FirstName,
                                 Atom_myCompany_Person.LastName,
                                 Atom_myCompany_Person.Job,
                                 Atom_Logo.Image_Hash as Logo_Hash,
                                 Atom_Logo.Image_Data as Logo_Data,
                                 Atom_Logo.Description as Logo_Description
                                 from JOURNAL_ProformaInvoice 
                                 inner join JOURNAL_ProformaInvoice_Type on JOURNAL_ProformaInvoice.JOURNAL_ProformaInvoice_Type_ID = JOURNAL_ProformaInvoice_Type.ID and (JOURNAL_ProformaInvoice_Type.ID = " + Program.JOURNAL_ProformaInvoice_Type_definitions.InvoiceDraftTime.ID.ToString() + @")
                                 inner join ProformaInvoice on JOURNAL_ProformaInvoice.ProformaInvoice_ID = ProformaInvoice.ID
                                 inner join Atom_WorkPeriod on JOURNAL_ProformaInvoice.Atom_WorkPeriod_ID = Atom_WorkPeriod.ID
                                 inner join Atom_myCompany_Person on Atom_WorkPeriod.Atom_myCompany_Person_ID = Atom_myCompany_Person.ID
                                 inner join Atom_Office on Atom_myCompany_Person.Atom_Office_ID = Atom_Office.ID
                                 inner join Atom_myCompany on Atom_Office.Atom_myCompany_ID = Atom_myCompany.ID
                                 inner join Atom_OrganisationData on Atom_myCompany.Atom_OrganisationData_ID = Atom_OrganisationData.ID
                                 inner join Atom_Organisation on Atom_OrganisationData.Atom_Organisation_ID = Atom_Organisation.ID
                                 left join Invoice inv on ProformaInvoice.Invoice_ID = inv.ID
                                 left join MethodOfPayment mpay on inv.MethodOfPayment_ID = mpay.ID
                                 left join cOrgTYPE on Atom_OrganisationData.cOrgTYPE_ID = cOrgTYPE.ID
                                 left join Atom_cAddress_Org on Atom_OrganisationData.Atom_cAddress_Org_ID = Atom_cAddress_Org.ID
                                 left join Atom_cStreetName_Org on Atom_cAddress_Org.Atom_cStreetName_Org_ID = Atom_cStreetName_Org.ID
                                 left join Atom_cHouseNumber_Org on Atom_cAddress_Org.Atom_cHouseNumber_Org_ID = Atom_cHouseNumber_Org.ID
                                 left join Atom_cCity_Org on Atom_cAddress_Org.Atom_cCity_Org_ID = Atom_cCity_Org.ID
                                 left join Atom_cZIP_Org on Atom_cAddress_Org.Atom_cZIP_Org_ID = Atom_cZIP_Org.ID
                                 left join Atom_cState_Org on Atom_cAddress_Org.Atom_cState_Org_ID = Atom_cState_Org.ID
                                 left join Atom_cCountry_Org on Atom_cAddress_Org.Atom_cCountry_Org_ID = Atom_cCountry_Org.ID
                                 left join cHomePage_Org on Atom_OrganisationData.cHomePage_Org_ID = cHomePage_Org.ID
                                 left join cEmail_Org on Atom_OrganisationData.cEmail_Org_ID = cEmail_Org.ID
                                 left join Atom_Logo on Atom_OrganisationData.Atom_Logo_ID = Atom_Logo.ID
                                 where ProformaInvoice.ID = " + ProformaInvoice_ID.ToString();

            string Err = null;
            if (DBSync.DBSync.ReadDataTable(ref dt_ProformaInvoice, sql, ref Err))
            {
                if (dt_ProformaInvoice.Rows.Count == 1)
                {
                    try
                    {
                        GrossSum = (decimal)dt_ProformaInvoice.Rows[0]["GrossSum"];
                        taxsum = (decimal)dt_ProformaInvoice.Rows[0]["TaxSum"];
                        NetSum = (decimal)dt_ProformaInvoice.Rows[0]["NetSum"];
                        Organisation_Name = (string)dt_ProformaInvoice.Rows[0]["Name"];
                        Organisation_Tax_ID = (string)dt_ProformaInvoice.Rows[0]["Tax_ID"];
                        object o_Organisation_Registration_ID = dt_ProformaInvoice.Rows[0]["Registration_ID"];
                        if (o_Organisation_Registration_ID.GetType() == typeof(string))
                        {
                            Organisation_Registration_ID = (string)o_Organisation_Registration_ID;
                        }

                        Organisation_StreetName = (string)dt_ProformaInvoice.Rows[0]["StreetName"];
                        Organisation_HouseNumber = (string)dt_ProformaInvoice.Rows[0]["HouseNumber"];
                        Organisation_ZIP = (string)dt_ProformaInvoice.Rows[0]["ZIP"];

                        Organisation_City = (string)dt_ProformaInvoice.Rows[0]["City"];
                        Organisation_State = (string)dt_ProformaInvoice.Rows[0]["State"];
                        object oCountry = dt_ProformaInvoice.Rows[0]["Country"];
                        if (oCountry.GetType() == typeof(string))
                        {
                            Organisation_Country = (string)oCountry;
                        }
                        else
                        {
                            Organisation_Country = null;
                        }
                        object oLogo_Data = dt_ProformaInvoice.Rows[0]["Logo_Data"];
                        if (oLogo_Data is byte[])
                        {
                            Logo_Data = (byte[])oLogo_Data;
                        }
                        else
                        {
                            Logo_Data = null;
                        }

                        object oInvoice_ID = dt_ProformaInvoice.Rows[0]["Invoice_ID"];
                        if (oInvoice_ID is long)
                        {
                            Invoice_ID = (long)oInvoice_ID;
                        }
                        else
                        {
                            Invoice_ID = -1;
                        }

                        object oFinancialYear = dt_ProformaInvoice.Rows[0]["FinancialYear"];
                        if (oFinancialYear is int)
                        {
                            FinancialYear = (int)oFinancialYear;
                        }
                        else
                        {
                            FinancialYear = -1;
                        }

                        object oNumberInFinancialYear = dt_ProformaInvoice.Rows[0]["NumberInFinancialYear"];
                        if (oNumberInFinancialYear is int)
                        {
                            NumberInFinancialYear = (int)oNumberInFinancialYear;
                        }
                        else
                        {
                            NumberInFinancialYear = -1;
                        }

                        object oHomePage = dt_ProformaInvoice.Rows[0]["HomePage"];
                        if (oHomePage is string)
                        {
                            HomePage = (string)oHomePage;
                        }
                        else
                        {
                            HomePage = null;
                        }

                        object oEmail = dt_ProformaInvoice.Rows[0]["Email"];
                        if (oEmail is string)
                        {
                            Email = (string)oEmail;
                        }
                        else
                        {
                            Email = null;
                        }

                        if (m_InvoiceDB.Read_Atom_Price_SimpleItem_Table(ProformaInvoice_ID, ref dt_Atom_Price_SimpleItem))
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    catch (Exception ex)
                    {
                        LogFile.Error.Show("ERROR:usrc_Invoice_Preview:Read_ProformaInvoice:Exception=" + ex.Message);
                        return false;
                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:usrc_Invoice_Preview:Read_ProformaInvoice:dt_ProformaInvoice.Rows.Count != 1! for ProformaInvoice_ID=" + ProformaInvoice_ID.ToString() + "!\r\nsql = " + sql);
                    return false;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:usrc_Invoice_Preview:Read_ProformaInvoice:Err=" + Err);
                return false;
            }

        }

        internal void Print_Receipt(usrc_Payment.ePaymentType PaymentType, string sPaymentMethod, string sAmountReceived, string sToReturn, DateTime_v issue_time)
        {

            if (Printer_is_ESC_POS())
            {
                Print_Receipt_ESC_POS(PaymentType, sPaymentMethod, sAmountReceived, sToReturn, issue_time);
            }
            else
            {
                Form_Print_A4 print_A4_dlg = new Form_Print_A4();
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

        internal void Print_Receipt_ESC_POS(usrc_Payment.ePaymentType PaymentType, string sPaymentMethod, string sAmountReceived, string sToReturn, DateTime_v issue_time)
        {
            if (issue_time!=null)
            { 
                PrintDate_Hour = issue_time.v.Hour; ;
                PrintDate_Min = issue_time.v.Minute;
                PrintDate_Sec = issue_time.v.Second;

                PrintDate_Day = issue_time.v.Day;
                PrintDate_Month = issue_time.v.Month;
                PrintDate_Year = issue_time.v.Year;
            }
            
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

                if (Logo_Data != null)
                {
                   Program.ReceiptPrinter.wr_Logo(Logo_Data);
                }

                Program.ReceiptPrinter.wr_SelectAnInternationalCharacterSet(Printer.eCharacterSet.Slovenia_Croatia);
                Program.ReceiptPrinter.wr_Paragraph(Organisation_Name);
                Program.ReceiptPrinter.wr_Paragraph(Organisation_StreetName + " " + Organisation_HouseNumber);
                Program.ReceiptPrinter.wr_Paragraph(Organisation_ZIP + " " + Organisation_City);
                if (HomePage != null)
                {
                    if (HomePage.Length > 0)
                    {
                        Program.ReceiptPrinter.wr_String("Domača stran:");
                        Program.ReceiptPrinter.wr_SelectAnInternationalCharacterSet(Printer.eCharacterSet.USA);
                        Program.ReceiptPrinter.wr_String(HomePage);
                        Program.ReceiptPrinter.wr_SelectAnInternationalCharacterSet(Printer.eCharacterSet.Slovenia_Croatia);
                        Program.ReceiptPrinter.wr_NewLine();
                        ;
                    }
                }
                if (Email != null)
                {
                    if (Email.Length > 0)
                    {
                        Program.ReceiptPrinter.wr_String("EPOŠTA:");
                        Program.ReceiptPrinter.wr_SelectAnInternationalCharacterSet(Printer.eCharacterSet.USA);
                        Program.ReceiptPrinter.wr_String(Email);
                        Program.ReceiptPrinter.wr_SelectAnInternationalCharacterSet(Printer.eCharacterSet.Slovenia_Croatia);
                    }
                }
                Program.ReceiptPrinter.wr_NewLine();
                Program.ReceiptPrinter.wr_Paragraph("Davčna Številka:" + Organisation_Tax_ID);
                Program.ReceiptPrinter.wr_NewLine(2);
                //buffer = buffer + "\x1b\x1d\x61\x0";             //Left Alignment - Refer to Pg. 3-29
                Program.ReceiptPrinter.wr_SetHorizontalTabPositions(new byte[] { 2, 0x10, 0x22 });
                Program.ReceiptPrinter.wr_Paragraph("Številka računa: " + FinancialYear.ToString() + "/" + NumberInFinancialYear.ToString());
                Program.ReceiptPrinter.wr_Paragraph("Datum:" + PrintDate_Day.ToString() + "." + PrintDate_Month.ToString() + "." + PrintDate_Year.ToString() + "\x9" + " Čas:" + PrintDate_Hour.ToString() + ":" + PrintDate_Min.ToString());      //Moving Horizontal Tab - Pg. 3-26
                Program.ReceiptPrinter.wr_LineDelimeter();
                Program.ReceiptPrinter.wr_BoldOn();

                Program.ReceiptPrinter.wr_Paragraph("PRODANO:");
                Program.ReceiptPrinter.wr_NewLine();
                Program.ReceiptPrinter.wr_BoldOff();
    
                                   //Select Emphasized Printing - Pg. 3-14;                    //Cancel Emphasized Printing - Pg. 3-14

                taxSum = null;
                taxSum = new TaxSum();

                foreach (DataRow dr in dt_Atom_Price_SimpleItem.Rows)
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
                    decimal TotalDiscount = Program.TotalDiscount(Discount, ExtraDiscount);
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

                foreach (Atom_ProformaInvoice_Price_Item_Stock_Data appisd in this.m_InvoiceDB.m_CurrentInvoice.m_Basket.Atom_ProformaInvoice_Price_Item_Stock_Data_LIST)
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


                    decimal TotalDiscount = Program.TotalDiscount(Discount, ExtraDiscount);
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

                    Program.CalculatePrice(RetailPricePerUnit, dQuantity, Discount, ExtraDiscount, Atom_Taxation_Rate, ref RetailItemsPriceWithDiscount, ref ItemsTaxPrice, ref ItemsNetPrice, decimal_places);

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

                foreach (Tax tax in taxSum.TaxList)
                {
                    Program.ReceiptPrinter.wr_String(tax.Name +  HT + HT + "" + tax.Sum.ToString() + " EUR\n");
                }
                
                Program.ReceiptPrinter.wr_String("Brez davka " +  HT + HT + "" + this.NetSum.ToString() + " EUR\n");
                //buffer += "\x1B" + "G" + "\xFF";
                Program.ReceiptPrinter.wr_String("Skupaj " + HT + HT + this.GrossSum.ToString() + " EUR\n"); 
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
                f_Journal_ProformaInvoice.Write(ProformaInvoice_ID, Program.Atom_WorkPeriod_ID, s_journal_invoice_type, s_journal_invoice_description,null, ref journal_proformainvoice_id);
            }
            catch (Exception ex)
            {
                string s_journal_invoice_type = lngRPM.s_journal_invoice_type_PrintError.s + Program.ReceiptPrinter.PrinterName+ "\nErr="+ex.Message;
                string s_journal_invoice_description = Program.ReceiptPrinter.PrinterName;
                f_Journal_ProformaInvoice.Write(ProformaInvoice_ID, Program.Atom_WorkPeriod_ID, s_journal_invoice_type, s_journal_invoice_description,null, ref journal_proformainvoice_id);
            }
        }

        public bool Init(long xProformaInvoice_ID, InvoiceDB x_InvoiceDB,long xmyCompany_Person_ID)
        {
            myCompany_Person_ID = xmyCompany_Person_ID;
            ProformaInvoice_ID = xProformaInvoice_ID;
            m_InvoiceDB = x_InvoiceDB;
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
                if ((x_InvoiceDB!=null)&&(xProformaInvoice_ID>=0))
                { 
                    if (Read_ProformaInvoice())
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
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
            if (dt_Atom_Price_SimpleItem.Rows.Count > 0)
            {
                object o_Currency_DecimalPlaces = dt_Atom_Price_SimpleItem.Rows[0]["Atom_Currency_DecimalPlaces"];
                if (o_Currency_DecimalPlaces.GetType() == typeof(int))
                {
                    return (int)o_Currency_DecimalPlaces;
                }
            }
            if (this.m_InvoiceDB.m_CurrentInvoice.m_Basket.Atom_ProformaInvoice_Price_Item_Stock_Data_LIST.Count >0)
            {
                object o_Data = this.m_InvoiceDB.m_CurrentInvoice.m_Basket.Atom_ProformaInvoice_Price_Item_Stock_Data_LIST[0];
                if (o_Data is Atom_ProformaInvoice_Price_Item_Stock_Data)
                {
                    return (int)((Atom_ProformaInvoice_Price_Item_Stock_Data)(o_Data)).Atom_Currency_DecimalPlaces.v;
                }
            }
            if (this.m_InvoiceDB.m_CurrentInvoice.m_Basket.dtDraft_ProformaInvoice_Atom_Item_Stock.Rows.Count > 0)
            {
                object o_Currency_DecimalPlaces = this.m_InvoiceDB.m_CurrentInvoice.m_Basket.dtDraft_ProformaInvoice_Atom_Item_Stock.Rows[0]["Atom_Currency_DecimalPlaces"];
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
