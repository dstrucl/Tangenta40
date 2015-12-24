using LanguageControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBTypes;
using System.Data;

namespace Tangenta
{
    public class InvoiceCreateFromTemplate
    {
        public List<InvoiceCreateToken> InvoiceCreateToken_List_Head = new List<InvoiceCreateToken>();
        public List<InvoiceCreateToken> InvoiceCreateToken_List_Items = new List<InvoiceCreateToken>();
        public List<InvoiceCreateToken> InvoiceCreateToken_List_Result = new List<InvoiceCreateToken>();

        public InvoiceCreateToken FiscalYear = new InvoiceCreateToken(new string[] {"@@FiscalYear", "@@ObračunskoLeto"},null);
        public InvoiceCreateToken InvoiceNumber = new InvoiceCreateToken(new string[] {"@@InvoiceNumber", "@@ŠtevilkaRačuna" },null);
        public InvoiceCreateToken MyOrg_Name = new InvoiceCreateToken(new string[] { "@@MyOrgName", "@@ImeOrganizacije" }, null);
        public InvoiceCreateToken MyOrg_Address_Street = new InvoiceCreateToken(new string[] { "@@MyOrgAdr_Street", "@@Naslov_Cesta" }, null);
        public InvoiceCreateToken MyOrg_Address_HouseNumber = new InvoiceCreateToken(new string[] { "@@MyOrgAdr_HouseNumber", "@@Naslov_HišnaŠtevilka" }, null);
        public InvoiceCreateToken MyOrg_Address_ZIP = new InvoiceCreateToken(new string[] { "@@MyOrgAdr_ZIP", "@@Naslov_Pošta" }, null);
        public InvoiceCreateToken MyOrg_Address_City = new InvoiceCreateToken(new string[] { "@@MyOrgAdr_City", "@@Naslov_Kraj" }, null);
        public InvoiceCreateToken MyOrg_TaxID = new InvoiceCreateToken(new string[] { "@@MyOrg_TaxID", "@@DavčnaŠtevilka" }, null);
        public InvoiceCreateToken MyOrg_Registration_ID = new InvoiceCreateToken(new string[] { "@@MyOrg_Registration_ID", "@@MatičnaŠtevilka" }, null);
        public InvoiceCreateToken MyOrg_Office = new InvoiceCreateToken(new string[] { "@@MyOrg_Office", "@@PoslovnaEnota" }, null);
        public InvoiceCreateToken Cashier = new InvoiceCreateToken(new string[] { "@@Cashier", "@@OznakaBlagajne" }, null);
        public InvoiceCreateToken IssuerOfInvoice = new InvoiceCreateToken(new string[] { "@@IssuerOfInvoice", "@@OsebaKiJeIzdalaRačun" }, null);
        public InvoiceCreateToken MyOrg_Email = new InvoiceCreateToken(new string[] { "@@MyOrg_Email", "@@EpoštaPodjetja" }, null);
        public InvoiceCreateToken MyOrg_HomePage = new InvoiceCreateToken(new string[] { "@@MyOrg_HomePage", "@@DomačaStranPodjetja" }, null);
        public InvoiceCreateToken CustomerName = new InvoiceCreateToken(new string[] { "@@CustomerName", "@@ImeStranke" }, null);
        public InvoiceCreateToken CustomerAddress_StreetName = new InvoiceCreateToken(new string[] { "@@CustomerAddress_StreetName", "@@NaslovStranke_Cesta" }, null);
        public InvoiceCreateToken CustomerAddress_HouseNumber = new InvoiceCreateToken(new string[] { "@@CustomerAddress_HouseNumber", "@@NaslovStranke_HišnaŠtevilka" }, null);
        public InvoiceCreateToken CustomerAddress_ZIP = new InvoiceCreateToken(new string[] { "@@CustomerAddress_ZIP", "@@NaslovStranke_PoštnaŠtevilka" }, null);
        public InvoiceCreateToken CustomerAddress_City = new InvoiceCreateToken(new string[] { "@@CustomerAddress_City", "@@NaslovStranke_Kraj" }, null);
        public InvoiceCreateToken CustomerEmail = new InvoiceCreateToken(new string[] { "@@CustomerEmail", "@@EPoštaStranke" }, null);

        public InvoiceCreateToken DateOfIssue = new InvoiceCreateToken(new string[] { "@@DateOfIssue", "@@Datum_izdaje_računa" }, null);
        public InvoiceCreateToken DateOfMaturity = new InvoiceCreateToken(new string[] { "@@DateOfMaturity", "@@Datum_zapadlosti_računa" }, null);

        // Start of items ****
        public InvoiceCreateToken ItemName = new InvoiceCreateToken(new string[] { "@@ItemName", "@@StoritevAliArtikel" }, null);
        public InvoiceCreateToken PricePerUnit = new InvoiceCreateToken(new string[] { "@@PricePerUnit", "@@CenaNaEnoto" }, null);
        public InvoiceCreateToken Discount = new InvoiceCreateToken(new string[] { "@@Discount", "@@Popust" }, null);
        public InvoiceCreateToken Currency = new InvoiceCreateToken(new string[] { "@@Currency", "@@Valuta" }, null);
        public InvoiceCreateToken Unit = new InvoiceCreateToken(new string[] { "@@Unit", "@@MerskaEnota" }, null);
        public InvoiceCreateToken Quantity = new InvoiceCreateToken(new string[] { "@@Quantity", "@@Količina" }, null);
        public InvoiceCreateToken TaxationRate = new InvoiceCreateToken(new string[] { "@@TaxationRate", "@@DavčnaStopnja" }, null);
        public InvoiceCreateToken NetPrice = new InvoiceCreateToken(new string[] { "@@NetPrice", "@@Cena_Brez_DDV" }, null);
        public InvoiceCreateToken Tax = new InvoiceCreateToken(new string[] { "@@Tax", "@@Davek" }, null);
        public InvoiceCreateToken PriceWithTax = new InvoiceCreateToken(new string[] { "@@PriceWithTax", "@@Cena_z_DDV" }, null);
        // End of items ****

        public InvoiceCreateToken SumNetPrice = new InvoiceCreateToken(new string[] { "@@SumNetPrice", "@@CenaSkupajBrezDavka" }, null);
        public InvoiceCreateToken TaxRateName = new InvoiceCreateToken(new string[] { "@@TaxRateName", "@@ImeDavčneStopnje" }, null);
        public InvoiceCreateToken SumTax = new InvoiceCreateToken(new string[] { "@@SumTax", "@@DavekSkupaj" }, null);
        public InvoiceCreateToken TotalSum = new InvoiceCreateToken(new string[] { "@@TotalSum", "@@KončnaCenaZDavkom" }, null);

        public InvoiceCreateToken Notice = new InvoiceCreateToken(new string[] { "@@Notice", "@@Dopis"}, null);
        public InvoiceCreateToken Footer = new InvoiceCreateToken(new string[] { "@@Footer", "@@Noga" }, null);
        public TaxSum taxSum = null;

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
        internal string Create(ref string html_doc_text, 
                               usrc_Print m_usrc_Print, 
                               usrc_Payment.ePaymentType m_paymentType, 
                               string m_sPaymentMethod, 
                               string m_sAmountReceived, 
                               string m_sToReturn, 
                               DateTime_v m_issue_time)
        {
            FiscalYear.Set(m_usrc_Print.FinancialYear.ToString());
            InvoiceNumber.Set(m_usrc_Print.NumberInFinancialYear.ToString());
            MyOrg_Name.Set(m_usrc_Print.Organisation_Name);
            MyOrg_Address_Street.Set(m_usrc_Print.Organisation_StreetName);
            MyOrg_Address_HouseNumber.Set(m_usrc_Print.Organisation_HouseNumber);
            MyOrg_Address_ZIP.Set(m_usrc_Print.Organisation_ZIP);
            MyOrg_Address_City.Set(m_usrc_Print.Organisation_City);
            MyOrg_TaxID.Set(m_usrc_Print.Organisation_Tax_ID);
            MyOrg_Registration_ID.Set(m_usrc_Print.Organisation_Registration_ID);
            MyOrg_Office.Set(m_usrc_Print.OfficeName);
            MyOrg_Email.Set(m_usrc_Print.Email);
            MyOrg_HomePage.Set(m_usrc_Print.HomePage);
            Cashier.Set("B1");
            CustomerName.Set(null);
            CustomerAddress_StreetName.Set(null);
            CustomerAddress_HouseNumber.Set(null);
            CustomerAddress_ZIP.Set(null);
            CustomerAddress_City.Set(null);
            CustomerEmail.Set(null);



            string stime = m_usrc_Print.PrintDate_Day.ToString() + "."
                           + m_usrc_Print.PrintDate_Month.ToString() + "."
                           + m_usrc_Print.PrintDate_Year.ToString() + " "
                           + m_usrc_Print.PrintDate_Hour.ToString() + ":"
                           + m_usrc_Print.PrintDate_Min.ToString();
            DateOfIssue.Set(stime);
            DateOfMaturity.Set(stime);

            foreach (InvoiceCreateToken ivt in InvoiceCreateToken_List_Head)
            {
                if (ivt.replacement!=null)
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

                        taxSum = new TaxSum();

                        html_doc_text = html_doc_text.Remove(itr_start, itr_end - itr_start + 5);

                        int ipos = itr_start;
                        foreach (DataRow dr in m_usrc_Print.dt_Atom_Price_SimpleItem.Rows)
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

                            string CurrencySymbol = null;
                            object oCurrencySymbol = dr["Atom_Currency_Symbol"];
                            if (oCurrencySymbol is string)
                            {
                                CurrencySymbol = (string)oCurrencySymbol;
                            }

                            if (CurrencySymbol!=null)
                            {
                                Currency.Set(CurrencySymbol);
                            }

                            ItemName.Set(SimpleItem_name);
                            PricePerUnit.Set(RetailSimpleItemPrice.ToString());

                            Unit.Set("");
                            Quantity.Set(iQuantity.ToString());
                            TaxationRate.Set(((decimal)dr["Atom_Taxation_Rate"]).ToString());

                            decimal TotalDiscount = Program.TotalDiscount(Discount, ExtraDiscount);
                            decimal TotalDiscountPercent = TotalDiscount * 100;
                            if (TotalDiscountPercent > 0)
                            {
                                
                            }
                            this.Discount.Set(TotalDiscountPercent.ToString()+"%");

                            if (TotalDiscountPercent > 0)
                            {
                            }
                            else
                            {
                            }

                            Tax.Set(TaxPrice.ToString());

                            decimal price_without_tax = RetailSimpleItemPriceWithDiscount - TaxPrice;
                            PriceWithTax.Set(RetailSimpleItemPriceWithDiscount.ToString());

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

                       

                        foreach (Atom_ProformaInvoice_Price_Item_Stock_Data appisd in m_usrc_Print.m_InvoiceDB.m_CurrentInvoice.m_Basket.Atom_ProformaInvoice_Price_Item_Stock_Data_LIST)
                        {
                            string Item_UniqueName = appisd.Atom_Item_UniqueName.v;

                            decimal RetailPricePerUnit = appisd.RetailPricePerUnit.v;

                            ItemName.Set(Item_UniqueName);


                            decimal RetailItemPriceWithDiscount = appisd.RetailPriceWithDiscount.v;




                            decimal dQuantity = appisd.dQuantity_FromStock + appisd.dQuantity_FromFactory;

                            string Atom_Unit_Name = appisd.Atom_Unit_Name.v;


                            decimal Discount = appisd.Discount.v;

                            decimal ExtraDiscount = appisd.ExtraDiscount.v;


                            decimal TotalDiscount = Program.TotalDiscount(Discount, ExtraDiscount);
                            decimal TotalDiscountPercent = TotalDiscount * 100;
                            if (TotalDiscountPercent > 0)
                            {
                            }
                        
                            decimal Atom_Taxation_Rate = appisd.Atom_Taxation_Rate.v;

                            decimal RetailItemsPriceWithDiscount = 0;
                            decimal ItemsTaxPrice = 0;
                            decimal ItemsNetPrice = 0;

                            int decimal_places = appisd.Atom_Currency_DecimalPlaces.v;

                            Program.CalculatePrice(RetailPricePerUnit, dQuantity, Discount, ExtraDiscount, Atom_Taxation_Rate, ref RetailItemsPriceWithDiscount, ref ItemsTaxPrice, ref ItemsNetPrice, decimal_places);

                            if (TotalDiscountPercent > 0)
                            {
                            }
                            else
                            {
                            }

                            string TaxationName = appisd.Atom_Taxation_Name.v;

                            decimal TaxPrice = appisd.TaxPrice.v;

                            taxSum.Add(ItemsTaxPrice, TaxationName, Atom_Taxation_Rate);


                            PricePerUnit.Set(RetailPricePerUnit.ToString());
                            this.Discount.Set(TotalDiscountPercent.ToString() + "%");
                            Currency.Set(appisd.Atom_Currency_Symbol.v);
                            Unit.Set(appisd.Atom_Unit_Name.vs);
                            Quantity.Set(appisd.dQuantity_all.v.ToString());
                            TaxationRate.Set(appisd.Atom_Taxation_Rate.v.ToString());
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
                        

                        if (m_paymentType != usrc_Payment.ePaymentType.NONE)
                        {
                            if (m_paymentType == usrc_Payment.ePaymentType.CASH)
                            {
                            }
                        }

                        html_doc_text = html_doc_text.Replace(Currency.lt.s, Currency.replacement);

                        SumNetPrice.Set(m_usrc_Print.NetSum.ToString());
                        html_doc_text = html_doc_text.Replace(SumNetPrice.lt.s, SumNetPrice.replacement);


                        string s_journal_invoice_type = lngRPM.s_journal_invoice_type_Print.s;
                        string s_journal_invoice_description = Program.ReceiptPrinter.PrinterName;
                        long journal_proformainvoice_id = -1;
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
                                foreach (Tax tax in taxSum.TaxList)
                                {
                                    TaxRateName.Set(tax.Name);
                                    SumTax.Set(tax.Sum.ToString());
                                    string str = tr_TaxSum.Replace(TaxRateName.lt.s, TaxRateName.replacement);
                                    str = str.Replace(SumTax.lt.s, SumTax.replacement);
                                    html_doc_text = html_doc_text.Insert(ipos, str);
                                    ipos += str.Length;
                                }
                                TotalSum.Set(m_usrc_Print.GrossSum.ToString());
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
