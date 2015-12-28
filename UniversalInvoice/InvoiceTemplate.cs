using DBTypes;
using LanguageControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversalInvoice
{
    public class InvoiceTemplate
    {
        public List<TemplateToken> InvoiceCreateToken_List_Head = new List<TemplateToken>();
        public List<TemplateToken> InvoiceCreateToken_List_Items = new List<TemplateToken>();
        public List<TemplateToken> InvoiceCreateToken_List_Result = new List<TemplateToken>();

        public TemplateToken FiscalYear;
        public TemplateToken InvoiceNumber;
        public TemplateToken Cashier;
        public TemplateToken IssuerOfInvoice;

        public Organisation MyOrganisation = null;
        public Organisation CustomerOrganisation = null;
        public Person CustomerPerson  = null;


        public TemplateToken DateOfIssue = new TemplateToken(null,new string[] { "@@DateOfIssue", "@@Datum_izdaje_računa" }, null);
        public TemplateToken DateOfMaturity = new TemplateToken(null,new string[] { "@@DateOfMaturity", "@@Datum_zapadlosti_računa" }, null);
        public TemplateToken PaymentType = new TemplateToken(null,new string[] { "@@PaymentType", "@@NačinPlačila" }, null);


        // Start of items ****
        public TemplateToken ItemName = new TemplateToken(null,new string[] { "@@ItemName", "@@StoritevAliArtikel" }, null);
        public TemplateToken PricePerUnit = new TemplateToken(null,new string[] { "@@PricePerUnit", "@@CenaNaEnoto" }, null);
        public TemplateToken Discount = new TemplateToken(null,new string[] { "@@Discount", "@@Popust" }, null);
        public TemplateToken Currency = new TemplateToken(null,new string[] { "@@Currency", "@@Valuta" }, null);
        public TemplateToken Unit = new TemplateToken(null,new string[] { "@@Unit", "@@MerskaEnota" }, null);
        public TemplateToken Quantity = new TemplateToken(null,new string[] { "@@Quantity", "@@Količina" }, null);
        public TemplateToken TaxationRate = new TemplateToken(null,new string[] { "@@TaxationRate", "@@DavčnaStopnja" }, null);
        public TemplateToken NetPrice = new TemplateToken(null,new string[] { "@@NetPrice", "@@Cena_Brez_DDV" }, null);
        public TemplateToken Tax = new TemplateToken(null,new string[] { "@@Tax", "@@Davek" }, null);
        public TemplateToken PriceWithTax = new TemplateToken(null,new string[] { "@@PriceWithTax", "@@Cena_z_DDV" }, null);
        // End of items ****

        public TemplateToken SumNetPrice = new TemplateToken(null,new string[] { "@@SumNetPrice", "@@CenaSkupajBrezDavka" }, null);
        public TemplateToken TaxRateName = new TemplateToken(null,new string[] { "@@TaxRateName", "@@ImeDavčneStopnje" }, null);
        public TemplateToken SumTax = new TemplateToken(null,new string[] { "@@SumTax", "@@DavekSkupaj" }, null);
        public TemplateToken TotalSum = new TemplateToken(null,new string[] { "@@TotalSum", "@@KončnaCenaZDavkom" }, null);

        public TemplateToken Notice = new TemplateToken(null,new string[] { "@@Notice", "@@Dopis" }, null);
        public TemplateToken Footer = new TemplateToken(null,new string[] { "@@Footer", "@@Noga" }, null);

        public StaticLib.TaxSum taxSum = null;

        public InvoiceTemplate(Organisation _MyOrganisation, object customer)
        {
            FiscalYear = new TemplateToken(null, new string[] { "@@FiscalYear", "@@ObračunskoLeto" }, null);
            InvoiceNumber = new TemplateToken(null, new string[] { "@@InvoiceNumber", "@@ŠtevilkaRačuna" }, null);
            Cashier = new TemplateToken(null,new string[] { null, "@@Cashier", "@@OznakaBlagajne" }, null);
            IssuerOfInvoice = new TemplateToken(null,new string[] { null, "@@IssuerOfInvoice", "@@OsebaKiJeIzdalaRačun" }, null);
            if (customer is  Organisation)
            {
                CustomerOrganisation = (Organisation)customer;
            }
            else
            {
                CustomerPerson = (Person)customer;
            }



        InvoiceCreateToken_List_Head.Add(FiscalYear);
            InvoiceCreateToken_List_Head.Add(InvoiceNumber);
            //InvoiceCreateToken_List_Head.Add(MyOrg_Name);
            //InvoiceCreateToken_List_Head.Add(MyOrg_Address_Street);
            //InvoiceCreateToken_List_Head.Add(MyOrg_Address_HouseNumber);
            //InvoiceCreateToken_List_Head.Add(MyOrg_Address_ZIP);
            //InvoiceCreateToken_List_Head.Add(MyOrg_Address_City);
            //InvoiceCreateToken_List_Head.Add(MyOrg_TaxID);
            //InvoiceCreateToken_List_Head.Add(MyOrg_Registration_ID);
            //InvoiceCreateToken_List_Head.Add(MyOrg_BankAccount);
            //InvoiceCreateToken_List_Head.Add(MyOrg_BankName);
            //InvoiceCreateToken_List_Head.Add(MyOrg_Office);
            InvoiceCreateToken_List_Head.Add(Cashier);
            InvoiceCreateToken_List_Head.Add(IssuerOfInvoice);
            //InvoiceCreateToken_List_Head.Add(MyOrg_Email);
            //InvoiceCreateToken_List_Head.Add(MyOrg_HomePage);
            //InvoiceCreateToken_List_Head.Add(CustomerName);
            //InvoiceCreateToken_List_Head.Add(CustomerAddress_StreetName);
            //InvoiceCreateToken_List_Head.Add(CustomerAddress_HouseNumber);
            //InvoiceCreateToken_List_Head.Add(CustomerAddress_ZIP);
            //InvoiceCreateToken_List_Head.Add(CustomerAddress_City);
            //InvoiceCreateToken_List_Head.Add(CustomerEmail);
            //InvoiceCreateToken_List_Head.Add(CustomerHomePage);
            //InvoiceCreateToken_List_Head.Add(Customer_Tax_ID);
            //InvoiceCreateToken_List_Head.Add(Customer_Registration_ID);

            InvoiceCreateToken_List_Head.Add(DateOfIssue);
            InvoiceCreateToken_List_Head.Add(DateOfMaturity);
            InvoiceCreateToken_List_Head.Add(PaymentType);

            InvoiceCreateToken_List_Items.Add(ItemName);
            InvoiceCreateToken_List_Items.Add(PricePerUnit);
            InvoiceCreateToken_List_Items.Add(Discount);
            InvoiceCreateToken_List_Items.Add(Currency);
            InvoiceCreateToken_List_Items.Add(Unit);
            InvoiceCreateToken_List_Items.Add(Quantity);
            InvoiceCreateToken_List_Items.Add(TaxationRate);
            InvoiceCreateToken_List_Items.Add(NetPrice);
            InvoiceCreateToken_List_Items.Add(Tax);
            InvoiceCreateToken_List_Items.Add(PriceWithTax);

            InvoiceCreateToken_List_Result.Add(SumNetPrice);
            InvoiceCreateToken_List_Result.Add(TaxRateName);
            InvoiceCreateToken_List_Result.Add(SumTax);
            InvoiceCreateToken_List_Result.Add(TotalSum);


        }

        public string CreateHTML(ref string html_doc_text,
                                   int FinancialYear,
                                   int NumberInFinancialYear,
                                   Organisation MyOrg,
                                   string Organisation_Casshier,
                                   object customer,
                                   int IssueDate_Day,
                                   int IssueDate_Month,
                                   int IssueDate_Year,
                                   int IssueDate_Hour,
                                   int IssueDate_Min,
                                   ItemSold[] ItemsSold,
                                   decimal NetSum,
                                   decimal GrossSum,
                                   string payment_type,
                                   int decimal_places
                                   /*string m_sAmountReceived,
                                   string m_sToReturn,
                                   DateTime_v m_issue_time,*/
                                   )
        {
            FiscalYear.Set(FinancialYear.ToString());
            InvoiceNumber.Set(NumberInFinancialYear.ToString());
            //MyOrg_Name.Set(Organisation_Name);
            //MyOrg_Address_Street.Set(Organisation_StreetName);
            //MyOrg_Address_HouseNumber.Set(Organisation_HouseNumber);
            //MyOrg_Address_ZIP.Set(Organisation_ZIP);
            //MyOrg_Address_City.Set(Organisation_City);
            //MyOrg_TaxID.Set(Organisation_Tax_ID);
            //MyOrg_Registration_ID.Set(Organisation_Registration_ID);
            //MyOrg_Office.Set(OfficeName);
            //MyOrg_Email.Set(Organisation_Email);
            //MyOrg_HomePage.Set(Organisation_Homepage);
            Cashier.Set(Organisation_Casshier);
            //CustomerName.Set(xCustomer_Name);
            //CustomerAddress_StreetName.Set(xCustomerAddress_StreetName);
            //CustomerAddress_HouseNumber.Set(xCustomerAddress_HouseNumber);
            //CustomerAddress_ZIP.Set(xCustomerAddress_ZIP);
            //CustomerAddress_City.Set(xCustomerAddress_City);
            //CustomerEmail.Set(xCustomerEmail);

            string stime = IssueDate_Day.ToString() + "."
                           + IssueDate_Month.ToString() + "."
                           + IssueDate_Year.ToString() + " "
                           + IssueDate_Hour.ToString() + ":"
                           + IssueDate_Min.ToString();
            DateOfIssue.Set(stime);
            DateOfMaturity.Set(stime);

            foreach (TemplateToken ivt in InvoiceCreateToken_List_Head)
            {
                if (ivt.replacement != null)
                {
                    html_doc_text = html_doc_text.Replace(ivt.lt.s, ivt.replacement);
                }
                else
                {
                    html_doc_text = html_doc_text.Replace(ivt.lt.s, "");
                }
                html_doc_text = html_doc_text.Replace(DateOfIssue.lt.s, DateOfIssue.replacement);
                html_doc_text = html_doc_text.Replace(DateOfMaturity.lt.s, DateOfMaturity.replacement);
            }


            int itbody = html_doc_text.IndexOf("<tbody>", 0);
            if (itbody > 0)
            {
                int itr_start = html_doc_text.IndexOf("<tr class=\"row\">", itbody);
                if (itr_start > 0)
                {
                    int itr_end = html_doc_text.IndexOf("</tr>", itr_start);
                    if (itr_end > 0)
                    {

                        string tr_RowTemplate = html_doc_text.Substring(itr_start, itr_end - itr_start + 5);

                        taxSum = new StaticLib.TaxSum();

                        html_doc_text = html_doc_text.Remove(itr_start, itr_end - itr_start + 5);

                        int ipos = itr_start;

                        foreach (ItemSold itms in ItemsSold)
                        {
                            ItemName.Set(itms.Item_Name);

                            decimal RetailItemsPriceWithDiscount = 0;
                            decimal ItemsTaxPrice = 0;
                            decimal ItemsNetPrice = 0;

                            StaticLib.Func.CalculatePrice(itms.RetailPricePerUnit, itms.dQuantity, itms.Discount, itms.ExtraDiscount, itms.TaxationRate, ref RetailItemsPriceWithDiscount, ref ItemsTaxPrice, ref ItemsNetPrice, decimal_places);

                            taxSum.Add(ItemsTaxPrice, itms.TaxationName,itms.TaxationRate);

                            decimal TotalDiscount = StaticLib.Func.TotalDiscount(itms.Discount,itms.ExtraDiscount,decimal_places);
                            decimal TotalDiscountPercent = TotalDiscount * 100;

                            PricePerUnit.Set(itms.RetailPricePerUnit.ToString());
                            this.Discount.Set(TotalDiscountPercent.ToString() + "%");
                            Currency.Set(itms.CurrencySymbol);
                            Unit.Set(itms.UnitName);
                            Quantity.Set(itms.dQuantity.ToString());
                            TaxationRate.Set(itms.TaxationRate.ToString());
                            NetPrice.Set(ItemsNetPrice.ToString());
                            Tax.Set(ItemsTaxPrice.ToString());
                            PriceWithTax.Set(RetailItemsPriceWithDiscount.ToString());

                            string sRow = tr_RowTemplate.Replace(ItemName.lt.s, ItemName.replacement);
                            sRow = sRow.Replace(PricePerUnit.lt.s, PricePerUnit.replacement);
                            sRow = sRow.Replace(this.Discount.lt.s, this.Discount.replacement);
                            sRow = sRow.Replace(Currency.lt.s, Currency.replacement);
                            sRow = sRow.Replace(Unit.lt.s, Unit.replacement);
                            sRow = sRow.Replace(Quantity.lt.s, Quantity.replacement);
                            sRow = sRow.Replace(TaxationRate.lt.s, TaxationRate.replacement);
                            sRow = sRow.Replace(NetPrice.lt.s, NetPrice.replacement);
                            sRow = sRow.Replace(Tax.lt.s, Tax.replacement);
                            sRow = sRow.Replace(PriceWithTax.lt.s, PriceWithTax.replacement);
                            html_doc_text = html_doc_text.Insert(ipos, sRow);
                            ipos += sRow.Length;
                        }


                        html_doc_text = html_doc_text.Replace(Currency.lt.s, Currency.replacement);

                        SumNetPrice.Set(NetSum.ToString());
                        html_doc_text = html_doc_text.Replace(SumNetPrice.lt.s, SumNetPrice.replacement);


                        //string s_journal_invoice_type = lngRPM.s_journal_invoice_type_Print.s;
                        //string s_journal_invoice_description = Program.ReceiptPrinter.PrinterName;
                        //long journal_proformainvoice_id = -1;
                        //f_Journal_ProformaInvoice.Write(m_usrc_Print.ProformaInvoice_ID, Program.Atom_WorkPeriod_ID, s_journal_invoice_type, s_journal_invoice_description, null, ref journal_proformainvoice_id);
                        int itr_taxsum_start = html_doc_text.IndexOf("<tr class=\"taxsum\">", itr_end);
                        if (itr_taxsum_start > 0)
                        {
                            int itr_taxsum_end = html_doc_text.IndexOf("</tr>", itr_taxsum_start);
                            if (itr_taxsum_end > 0)
                            {
                                string tr_TaxSum = html_doc_text.Substring(itr_taxsum_start, itr_taxsum_end - itr_taxsum_start + 5);
                                html_doc_text = html_doc_text.Remove(itr_taxsum_start, itr_taxsum_end - itr_taxsum_start + 5);
                                ipos = itr_taxsum_start;
                                foreach (StaticLib.Tax tax in taxSum.TaxList)
                                {
                                    TaxRateName.Set(tax.Name);
                                    SumTax.Set(tax.Sum.ToString());
                                    string str = tr_TaxSum.Replace(TaxRateName.lt.s, TaxRateName.replacement);
                                    str = str.Replace(SumTax.lt.s, SumTax.replacement);
                                    html_doc_text = html_doc_text.Insert(ipos, str);
                                    ipos += str.Length;
                                }
                                TotalSum.Set(GrossSum.ToString());
                                html_doc_text = html_doc_text.Replace(TotalSum.lt.s, TotalSum.replacement);
                                return html_doc_text;
                            }
                            else
                            {
                                return "ERROR:itr_taxsum_end <= 0";
                            }
                        }
                        else
                        {
                            return "ERROR:itr_taxsum_start <= 0";
                        }
                    }
                    else
                    {
                        return "ERROR:itr_end <= 0";
                    }
                }
                else
                {
                    return "ERROR:itr_start <= 0";
                }
            }
            else
            {
                return "ERROR:itbody <= 0";
            }
        }

        public string Create_FVI_SLO_XML_Invoice(ref string XML_Invoice_template,
                           int FinancialYear,
                           int NumberInFinancialYear,
                           string Organisation_Name,
                           string Organisation_StreetName,
                           string Organisation_HouseNumber,
                           string Organisation_ZIP,
                           string Organisation_City,
                           string Organisation_Tax_ID,
                           string Organisation_Registration_ID,
                           string OfficeName,
                           string Organisation_Email,
                           string Organisation_Homepage,
                           string Organisation_Casshier,
                           string xCustomer_Name,
                           string xCustomerAddress_StreetName,
                           string xCustomerAddress_HouseNumber,
                           string xCustomerAddress_ZIP,
                           string xCustomerAddress_City,
                           string xCustomerEmail,
                           int IssueDate_Day,
                           int IssueDate_Month,
                           int IssueDate_Year,
                           int IssueDate_Hour,
                           int IssueDate_Min,
                           ItemSold[] ItemsSold,
                           decimal NetSum,
                           decimal GrossSum,
                           int decimal_places
                           /*string m_sAmountReceived,
                           string m_sToReturn,
                           DateTime_v m_issue_time,*/
                           )
        {
            FiscalYear.Set(FinancialYear.ToString());
            InvoiceNumber.Set(NumberInFinancialYear.ToString());
            //MyOrg_Name.Set(Organisation_Name);
            //MyOrg_Address_Street.Set(Organisation_StreetName);
            //MyOrg_Address_HouseNumber.Set(Organisation_HouseNumber);
            //MyOrg_Address_ZIP.Set(Organisation_ZIP);
            //MyOrg_Address_City.Set(Organisation_City);
            //MyOrg_TaxID.Set(Organisation_Tax_ID);
            //MyOrg_Registration_ID.Set(Organisation_Registration_ID);
            //MyOrg_Office.Set(OfficeName);
            //MyOrg_Email.Set(Organisation_Email);
            //MyOrg_HomePage.Set(Organisation_Homepage);
            Cashier.Set(Organisation_Casshier);
            //CustomerName.Set(xCustomer_Name);
            //CustomerAddress_StreetName.Set(xCustomerAddress_StreetName);
            //CustomerAddress_HouseNumber.Set(xCustomerAddress_HouseNumber);
            //CustomerAddress_ZIP.Set(xCustomerAddress_ZIP);
            //CustomerAddress_City.Set(xCustomerAddress_City);
            //CustomerEmail.Set(xCustomerEmail);

            string stime = IssueDate_Day.ToString() + "."
                           + IssueDate_Month.ToString() + "."
                           + IssueDate_Year.ToString() + " "
                           + IssueDate_Hour.ToString() + ":"
                           + IssueDate_Min.ToString();
            DateOfIssue.Set(stime);
            DateOfMaturity.Set(stime);

            foreach (TemplateToken ivt in InvoiceCreateToken_List_Head)
            {
                if (ivt.replacement != null)
                {
                    XML_Invoice_template = XML_Invoice_template.Replace(ivt.lt.s, ivt.replacement);
                }
                else
                {
                    XML_Invoice_template = XML_Invoice_template.Replace(ivt.lt.s, "");
                }
            }


            int itbody = XML_Invoice_template.IndexOf("<tbody>", 0);
            if (itbody > 0)
            {
                int itr_start = XML_Invoice_template.IndexOf("<tr class=\"row\">", itbody);
                if (itr_start > 0)
                {
                    int itr_end = XML_Invoice_template.IndexOf("</tr>", itr_start);
                    if (itr_end > 0)
                    {

                        string tr_RowTemplate = XML_Invoice_template.Substring(itr_start, itr_end - itr_start + 5);

                        taxSum = new StaticLib.TaxSum();

                        XML_Invoice_template = XML_Invoice_template.Remove(itr_start, itr_end - itr_start + 5);

                        int ipos = itr_start;

                        foreach (ItemSold itms in ItemsSold)
                        {
                            ItemName.Set(itms.Item_Name);

                            decimal RetailItemsPriceWithDiscount = 0;
                            decimal ItemsTaxPrice = 0;
                            decimal ItemsNetPrice = 0;

                            StaticLib.Func.CalculatePrice(itms.RetailPricePerUnit, itms.dQuantity, itms.Discount, itms.ExtraDiscount, itms.TaxationRate, ref RetailItemsPriceWithDiscount, ref ItemsTaxPrice, ref ItemsNetPrice, decimal_places);

                            taxSum.Add(ItemsTaxPrice, itms.TaxationName, itms.TaxationRate);

                            decimal TotalDiscount = StaticLib.Func.TotalDiscount(itms.Discount, itms.ExtraDiscount, decimal_places);
                            decimal TotalDiscountPercent = TotalDiscount * 100;

                            PricePerUnit.Set(itms.RetailPricePerUnit.ToString());
                            this.Discount.Set(TotalDiscountPercent.ToString() + "%");
                            Currency.Set(itms.CurrencySymbol);
                            Unit.Set(itms.UnitName);
                            Quantity.Set(itms.dQuantity.ToString());
                            TaxationRate.Set(itms.TaxationRate.ToString());
                            NetPrice.Set(ItemsNetPrice.ToString());
                            Tax.Set(ItemsTaxPrice.ToString());
                            PriceWithTax.Set(RetailItemsPriceWithDiscount.ToString());

                            string sRow = tr_RowTemplate.Replace(ItemName.lt.s, ItemName.replacement);
                            sRow = sRow.Replace(PricePerUnit.lt.s, PricePerUnit.replacement);
                            sRow = sRow.Replace(this.Discount.lt.s, this.Discount.replacement);
                            sRow = sRow.Replace(Currency.lt.s, Currency.replacement);
                            sRow = sRow.Replace(Unit.lt.s, Unit.replacement);
                            sRow = sRow.Replace(Quantity.lt.s, Quantity.replacement);
                            sRow = sRow.Replace(TaxationRate.lt.s, TaxationRate.replacement);
                            sRow = sRow.Replace(NetPrice.lt.s, NetPrice.replacement);
                            sRow = sRow.Replace(Tax.lt.s, Tax.replacement);
                            sRow = sRow.Replace(PriceWithTax.lt.s, PriceWithTax.replacement);
                            XML_Invoice_template = XML_Invoice_template.Insert(ipos, sRow);
                            ipos += sRow.Length;
                        }


                        XML_Invoice_template = XML_Invoice_template.Replace(Currency.lt.s, Currency.replacement);

                        SumNetPrice.Set(NetSum.ToString());
                        XML_Invoice_template = XML_Invoice_template.Replace(SumNetPrice.lt.s, SumNetPrice.replacement);


                        //string s_journal_invoice_type = lngRPM.s_journal_invoice_type_Print.s;
                        //string s_journal_invoice_description = Program.ReceiptPrinter.PrinterName;
                        //long journal_proformainvoice_id = -1;
                        //f_Journal_ProformaInvoice.Write(m_usrc_Print.ProformaInvoice_ID, Program.Atom_WorkPeriod_ID, s_journal_invoice_type, s_journal_invoice_description, null, ref journal_proformainvoice_id);
                        int itr_taxsum_start = XML_Invoice_template.IndexOf("<tr class=\"taxsum\">", itr_end);
                        if (itr_taxsum_start > 0)
                        {
                            int itr_taxsum_end = XML_Invoice_template.IndexOf("</tr>", itr_taxsum_start);
                            if (itr_taxsum_end > 0)
                            {
                                string tr_TaxSum = XML_Invoice_template.Substring(itr_taxsum_start, itr_taxsum_end - itr_taxsum_start + 5);
                                XML_Invoice_template = XML_Invoice_template.Remove(itr_taxsum_start, itr_taxsum_end - itr_taxsum_start + 5);
                                ipos = itr_taxsum_start;
                                foreach (StaticLib.Tax tax in taxSum.TaxList)
                                {
                                    TaxRateName.Set(tax.Name);
                                    SumTax.Set(tax.Sum.ToString());
                                    string str = tr_TaxSum.Replace(TaxRateName.lt.s, TaxRateName.replacement);
                                    str = str.Replace(SumTax.lt.s, SumTax.replacement);
                                    XML_Invoice_template = XML_Invoice_template.Insert(ipos, str);
                                    ipos += str.Length;
                                }
                                TotalSum.Set(GrossSum.ToString());
                                XML_Invoice_template = XML_Invoice_template.Replace(TotalSum.lt.s, TotalSum.replacement);
                                return XML_Invoice_template;
                            }
                            else
                            {
                                return "ERROR:itr_taxsum_end <= 0";
                            }
                        }
                        else
                        {
                            return "ERROR:itr_taxsum_start <= 0";
                        }
                    }
                    else
                    {
                        return "ERROR:itr_end <= 0";
                    }
                }
                else
                {
                    return "ERROR:itr_start <= 0";
                }
            }
            else
            {
                return "ERROR:itbody <= 0";
            }
        }
    }
}
