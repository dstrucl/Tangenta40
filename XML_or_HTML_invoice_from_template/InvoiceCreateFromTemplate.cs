using DBTypes;
using LanguageControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XML_or_HTML_invoice_from_template
{
    public class InvoiceCreateFromTemplate
    {
        public List<InvoiceTemplateToken> InvoiceCreateToken_List_Head = new List<InvoiceTemplateToken>();
        public List<InvoiceTemplateToken> InvoiceCreateToken_List_Items = new List<InvoiceTemplateToken>();
        public List<InvoiceTemplateToken> InvoiceCreateToken_List_Result = new List<InvoiceTemplateToken>();

        public InvoiceTemplateToken FiscalYear = new InvoiceTemplateToken(new string[] { "@@FiscalYear", "@@ObračunskoLeto" }, null);
        public InvoiceTemplateToken InvoiceNumber = new InvoiceTemplateToken(new string[] { "@@InvoiceNumber", "@@ŠtevilkaRačuna" }, null);
        public InvoiceTemplateToken MyOrg_Name = new InvoiceTemplateToken(new string[] { "@@MyOrgName", "@@ImeOrganizacije" }, null);
        public InvoiceTemplateToken MyOrg_Address_Street = new InvoiceTemplateToken(new string[] { "@@MyOrgAdr_Street", "@@Naslov_Cesta" }, null);
        public InvoiceTemplateToken MyOrg_Address_HouseNumber = new InvoiceTemplateToken(new string[] { "@@MyOrgAdr_HouseNumber", "@@Naslov_HišnaŠtevilka" }, null);
        public InvoiceTemplateToken MyOrg_Address_ZIP = new InvoiceTemplateToken(new string[] { "@@MyOrgAdr_ZIP", "@@Naslov_Pošta" }, null);
        public InvoiceTemplateToken MyOrg_Address_City = new InvoiceTemplateToken(new string[] { "@@MyOrgAdr_City", "@@Naslov_Kraj" }, null);
        public InvoiceTemplateToken MyOrg_TaxID = new InvoiceTemplateToken(new string[] { "@@MyOrg_TaxID", "@@DavčnaŠtevilka" }, null);
        public InvoiceTemplateToken MyOrg_Registration_ID = new InvoiceTemplateToken(new string[] { "@@MyOrg_Registration_ID", "@@MatičnaŠtevilka" }, null);
        public InvoiceTemplateToken MyOrg_Office = new InvoiceTemplateToken(new string[] { "@@MyOrg_Office", "@@PoslovnaEnota" }, null);
        public InvoiceTemplateToken Cashier = new InvoiceTemplateToken(new string[] { "@@Cashier", "@@OznakaBlagajne" }, null);
        public InvoiceTemplateToken IssuerOfInvoice = new InvoiceTemplateToken(new string[] { "@@IssuerOfInvoice", "@@OsebaKiJeIzdalaRačun" }, null);
        public InvoiceTemplateToken MyOrg_Email = new InvoiceTemplateToken(new string[] { "@@MyOrg_Email", "@@EpoštaPodjetja" }, null);
        public InvoiceTemplateToken MyOrg_HomePage = new InvoiceTemplateToken(new string[] { "@@MyOrg_HomePage", "@@DomačaStranPodjetja" }, null);
        public InvoiceTemplateToken CustomerName = new InvoiceTemplateToken(new string[] { "@@CustomerName", "@@ImeStranke" }, null);
        public InvoiceTemplateToken CustomerAddress_StreetName = new InvoiceTemplateToken(new string[] { "@@CustomerAddress_StreetName", "@@NaslovStranke_Cesta" }, null);
        public InvoiceTemplateToken CustomerAddress_HouseNumber = new InvoiceTemplateToken(new string[] { "@@CustomerAddress_HouseNumber", "@@NaslovStranke_HišnaŠtevilka" }, null);
        public InvoiceTemplateToken CustomerAddress_ZIP = new InvoiceTemplateToken(new string[] { "@@CustomerAddress_ZIP", "@@NaslovStranke_PoštnaŠtevilka" }, null);
        public InvoiceTemplateToken CustomerAddress_City = new InvoiceTemplateToken(new string[] { "@@CustomerAddress_City", "@@NaslovStranke_Kraj" }, null);
        public InvoiceTemplateToken CustomerEmail = new InvoiceTemplateToken(new string[] { "@@CustomerEmail", "@@EPoštaStranke" }, null);

        public InvoiceTemplateToken DateOfIssue = new InvoiceTemplateToken(new string[] { "@@DateOfIssue", "@@Datum_izdaje_računa" }, null);
        public InvoiceTemplateToken DateOfMaturity = new InvoiceTemplateToken(new string[] { "@@DateOfMaturity", "@@Datum_zapadlosti_računa" }, null);

        // Start of items ****
        public InvoiceTemplateToken ItemName = new InvoiceTemplateToken(new string[] { "@@ItemName", "@@StoritevAliArtikel" }, null);
        public InvoiceTemplateToken PricePerUnit = new InvoiceTemplateToken(new string[] { "@@PricePerUnit", "@@CenaNaEnoto" }, null);
        public InvoiceTemplateToken Discount = new InvoiceTemplateToken(new string[] { "@@Discount", "@@Popust" }, null);
        public InvoiceTemplateToken Currency = new InvoiceTemplateToken(new string[] { "@@Currency", "@@Valuta" }, null);
        public InvoiceTemplateToken Unit = new InvoiceTemplateToken(new string[] { "@@Unit", "@@MerskaEnota" }, null);
        public InvoiceTemplateToken Quantity = new InvoiceTemplateToken(new string[] { "@@Quantity", "@@Količina" }, null);
        public InvoiceTemplateToken TaxationRate = new InvoiceTemplateToken(new string[] { "@@TaxationRate", "@@DavčnaStopnja" }, null);
        public InvoiceTemplateToken NetPrice = new InvoiceTemplateToken(new string[] { "@@NetPrice", "@@Cena_Brez_DDV" }, null);
        public InvoiceTemplateToken Tax = new InvoiceTemplateToken(new string[] { "@@Tax", "@@Davek" }, null);
        public InvoiceTemplateToken PriceWithTax = new InvoiceTemplateToken(new string[] { "@@PriceWithTax", "@@Cena_z_DDV" }, null);
        // End of items ****

        public InvoiceTemplateToken SumNetPrice = new InvoiceTemplateToken(new string[] { "@@SumNetPrice", "@@CenaSkupajBrezDavka" }, null);
        public InvoiceTemplateToken TaxRateName = new InvoiceTemplateToken(new string[] { "@@TaxRateName", "@@ImeDavčneStopnje" }, null);
        public InvoiceTemplateToken SumTax = new InvoiceTemplateToken(new string[] { "@@SumTax", "@@DavekSkupaj" }, null);
        public InvoiceTemplateToken TotalSum = new InvoiceTemplateToken(new string[] { "@@TotalSum", "@@KončnaCenaZDavkom" }, null);

        public InvoiceTemplateToken Notice = new InvoiceTemplateToken(new string[] { "@@Notice", "@@Dopis" }, null);
        public InvoiceTemplateToken Footer = new InvoiceTemplateToken(new string[] { "@@Footer", "@@Noga" }, null);

        public StaticLib.TaxSum taxSum = null;

        public InvoiceCreateFromTemplate()
        {
            InvoiceCreateToken_List_Head.Add(FiscalYear);
            InvoiceCreateToken_List_Head.Add(InvoiceNumber);
            InvoiceCreateToken_List_Head.Add(MyOrg_Name);
            InvoiceCreateToken_List_Head.Add(MyOrg_Address_Street);
            InvoiceCreateToken_List_Head.Add(MyOrg_Address_HouseNumber);
            InvoiceCreateToken_List_Head.Add(MyOrg_Address_ZIP);
            InvoiceCreateToken_List_Head.Add(MyOrg_Address_City);
            InvoiceCreateToken_List_Head.Add(MyOrg_TaxID);
            InvoiceCreateToken_List_Head.Add(MyOrg_Registration_ID);
            InvoiceCreateToken_List_Head.Add(MyOrg_Office);
            InvoiceCreateToken_List_Head.Add(Cashier);
            InvoiceCreateToken_List_Head.Add(IssuerOfInvoice);
            InvoiceCreateToken_List_Head.Add(MyOrg_Email);
            InvoiceCreateToken_List_Head.Add(MyOrg_HomePage);
            InvoiceCreateToken_List_Head.Add(CustomerName);
            InvoiceCreateToken_List_Head.Add(CustomerAddress_StreetName);
            InvoiceCreateToken_List_Head.Add(CustomerAddress_HouseNumber);
            InvoiceCreateToken_List_Head.Add(CustomerAddress_ZIP);
            InvoiceCreateToken_List_Head.Add(CustomerAddress_City);
            InvoiceCreateToken_List_Head.Add(CustomerEmail);
            InvoiceCreateToken_List_Head.Add(DateOfIssue);
            InvoiceCreateToken_List_Head.Add(DateOfMaturity);

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
                                   SimpleItemSold[] SimpleItemsSold,
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
            MyOrg_Name.Set(Organisation_Name);
            MyOrg_Address_Street.Set(Organisation_StreetName);
            MyOrg_Address_HouseNumber.Set(Organisation_HouseNumber);
            MyOrg_Address_ZIP.Set(Organisation_ZIP);
            MyOrg_Address_City.Set(Organisation_City);
            MyOrg_TaxID.Set(Organisation_Tax_ID);
            MyOrg_Registration_ID.Set(Organisation_Registration_ID);
            MyOrg_Office.Set(OfficeName);
            MyOrg_Email.Set(Organisation_Email);
            MyOrg_HomePage.Set(Organisation_Homepage);
            Cashier.Set(Organisation_Casshier);
            CustomerName.Set(xCustomer_Name);
            CustomerAddress_StreetName.Set(xCustomerAddress_StreetName);
            CustomerAddress_HouseNumber.Set(xCustomerAddress_HouseNumber);
            CustomerAddress_ZIP.Set(xCustomerAddress_ZIP);
            CustomerAddress_City.Set(xCustomerAddress_City);
            CustomerEmail.Set(xCustomerEmail);

            string stime = IssueDate_Day.ToString() + "."
                           + IssueDate_Month.ToString() + "."
                           + IssueDate_Year.ToString() + " "
                           + IssueDate_Hour.ToString() + ":"
                           + IssueDate_Min.ToString();
            DateOfIssue.Set(stime);
            DateOfMaturity.Set(stime);

            foreach (InvoiceTemplateToken ivt in InvoiceCreateToken_List_Head)
            {
                if (ivt.replacement != null)
                {
                    html_doc_text = html_doc_text.Replace(ivt.lt.s, ivt.replacement);
                }
                else
                {
                    html_doc_text = html_doc_text.Replace(ivt.lt.s, "");
                }
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

                        foreach (SimpleItemSold sitems in SimpleItemsSold)
                        {
                            taxSum.Add(sitems.TaxPrice, sitems.TaxationName, sitems.TaxationRate);

                            Currency.Set(sitems.CurrencySymbol);
                            ItemName.Set(sitems.SimpleItem_name);
                            PricePerUnit.Set(sitems.RetailSimpleItemPrice.ToString());
                            Unit.Set("");
                            Quantity.Set(sitems.iQuantity.ToString());
                            TaxationRate.Set(sitems.TaxationRate.ToString());

                            decimal TotalDiscount = StaticLib.Func.TotalDiscount(sitems.Discount, sitems.ExtraDiscount, decimal_places);
                            decimal TotalDiscountPercent = TotalDiscount * 100;
                            if (TotalDiscountPercent > 0)
                            {

                            }
                            this.Discount.Set(TotalDiscountPercent.ToString() + "%");

                            if (TotalDiscountPercent > 0)
                            {
                            }
                            else
                            {
                            }

                            Tax.Set(sitems.TaxPrice.ToString());

                            decimal price_without_tax = sitems.RetailSimpleItemPriceWithDiscount - sitems.TaxPrice;
                            PriceWithTax.Set(sitems.RetailSimpleItemPriceWithDiscount.ToString());

                            NetPrice.Set(price_without_tax.ToString());

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

                        foreach (ItemSold itms in ItemsSold)
                        {
                            ItemName.Set(itms.Item_UniqueName);


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
    }
}
