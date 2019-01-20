#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion
using LanguageControl;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBTypes;
using System.Xml;
using System.Drawing;
using DBConnectionControl40;
using System.IO;
using TangentaDB;
using UniversalInvoice;

namespace ShopC_Forms
{

    public class ConsumptionData
    {
        public delegate string delegate_ConsumptionType();

        private WriteOffAddOn m_WriteOffAddOn = null;
        public WriteOffAddOn AddOnWriteOff
        {
            get
            {
                return m_WriteOffAddOn;
            }
            set
            {
                m_WriteOffAddOn = value;
            }
        }

        private OwnUseAddOn m_OwnUseAddOn = null;
        public OwnUseAddOn AddOnOwnUse
        {
            get
            {
                return m_OwnUseAddOn;
            }
            set
            {
                m_OwnUseAddOn = value;
            }
        }


        public enum eType { DRAFT_INVOICE, INVOICE, PROFORMA_INVOICE, STORNO, UNKNOWN };

        public eType m_eType = eType.UNKNOWN;

        public string GetConsumptionNumberString()
        {
            string sED = "";
            if (Electronic_Device_Name_v != null)
            {
                sED = Electronic_Device_Name_v.v;
            }
            string sOfficeShortName = "";

            if (MyOrganisation != null)
            {
                if (MyOrganisation.Atom_Office_ShortName != null)
                {
                    sOfficeShortName = MyOrganisation.Atom_Office_ShortName;
                }
            }
            string snumber = sOfficeShortName + "-" + sED + "-" + NumberInFinancialYear.ToString() + "/" + FinancialYear.ToString();
            return snumber;
        }        

        public string_v Electronic_Device_Name_v = null;

        public DateTime_v PrintingTime_v = null;
        //public string PrintCopyInfo = "";

        public ID Consumption_ID = null;

        public ID Consumption_Reference_ID = null;

        public bool bConsumptionStorno = false;
        public DateTime_v StornoIssueDate_v = null;
        public bool_v Consumption_Storno_v = null;
        public string_v Atom_WorkArea_Name_v = null;
        public string_v Consumption_Reference_Type_v = null;



        //public FURS_Response_data FURS_Response_Data = null;

        public DataTable dt_Consumption = new DataTable();




        public int FinancialYear = -1;
        public int NumberInFinancialYear = -1;
        public bool Draft = true;


        public DateTime_v IssueDate_v = null;




        public xCurrency Currency = new xCurrency();



        public decimal GrossSum = 0;


        public decimal taxsum = 0;
        public decimal NetSum = 0;

        public UniversalInvoice.Organisation MyOrganisation = null;


        public UniversalInvoice.Organisation CustomerOrganisation = null;
        public UniversalInvoice.Person CustomerPerson = null;
        public UniversalInvoice.Person Consumption_Author = null;
        public UniversalInvoice.ItemSold[] ItemsSold = null;
        public UniversalInvoice.GeneralToken GeneralToken = null;
        public UniversalInvoice.InvoiceToken ConsumptionToken = null;

        public string_v My_Organisation_Person_FirstName_v = null;
        public string_v My_Organisation_Person_LastName_v = null;


        public int iCountSimpleItemsSold = 0;
        public int iCountItemsSold = 0;

        string sMethodOfPayment = "";
        string sBankAccount = "";
        string sBankName = "";


        private CurrentConsumption m_CurrentConsumption = null;

        private delegate_ConsumptionType m_delegate_ConsumptionType = null;
        public delegate_ConsumptionType Delegate_ConsumptionType
        {
            get
            {
                return m_delegate_ConsumptionType;
            }
        }

        public string Consumption
        {
            get
            {
                if (m_delegate_ConsumptionType != null)
                {
                    return m_delegate_ConsumptionType();
                }
                else
                {
                    return null;
                }
            }
        }

        public bool IsWriteOff
        {
            get { 
                    if (m_delegate_ConsumptionType != null)
                    {
                        return m_delegate_ConsumptionType().Equals(GlobalData.const_ConsumptionWriteOff);
                    }
                    else
                    {
                        return false;
                    }
                }
        }

        public bool IsOwnUse
        {
            get
            {
                if (m_delegate_ConsumptionType != null)
                {
                    return m_delegate_ConsumptionType().Equals(GlobalData.const_ConsumptionOwnUse);
                }
                else
                {
                    return false;
                }
            }
        }

        public StaticLib.TaxSum taxSum = null;


        public object Customer
        {
            get
            {
                if (CustomerOrganisation != null)
                {
                    return CustomerOrganisation;
                }
                else if (CustomerPerson != null)
                {
                    return CustomerPerson;
                }
                else
                {
                    return null;
                }
            }
        }

        public ConsumptionData(delegate_ConsumptionType xdelegate_ConsumptionType, ID xConsumption_ID,  string xElectronic_Device_Name)
        {
            m_delegate_ConsumptionType = xdelegate_ConsumptionType;
            Consumption_ID = xConsumption_ID;
            Electronic_Device_Name_v = new string_v(xElectronic_Device_Name);
            AddOnWriteOff = new WriteOffAddOn();
            AddOnOwnUse = new OwnUseAddOn();
        }

        public void Set_NumberInFinancialYear(int xNumberInFinancialYear)
        {
            NumberInFinancialYear = xNumberInFinancialYear;
            if (ConsumptionToken==null)
            {
                ConsumptionToken = new UniversalInvoice.InvoiceToken(IsWriteOff);
            }
            ConsumptionToken.tInvoiceNumber.Set(NumberInFinancialYear.ToString());
        }

   

        public StringBuilder CreateHTML_PagePaperPrintingOutput(HTML_PrintingElement_List hTML_RollPaperPrintingOutput, double xPageHeight)
        {
            //PageHeight = 1000;
            StringBuilder html = new StringBuilder(hTML_RollPaperPrintingOutput.style.html, hTML_RollPaperPrintingOutput.style.html.Length*4);
            bool bFirstItemFound = false;
            html.Append(@"
             <html>
                <body>
                    <page> ");
            double bottom = 0;
            int i = 0;
            int iCount = hTML_RollPaperPrintingOutput.elements.Count;
            hTML_RollPaperPrintingOutput.NumberOfPages = 1;

            double Thead_Height = -1;
            if (hTML_RollPaperPrintingOutput.items.Count > 0)
            {
                Thead_Height = hTML_RollPaperPrintingOutput.items[0].Ypos - hTML_RollPaperPrintingOutput.tableitems.Ypos;
            }
            else
            {
                return new StringBuilder("WARNING:TangentaDB:ConsumptionData:CreateHTML_PagePaperPrintingOutput:Document has no items!");
            }

            for (i = 0; i < iCount; i++)
            {
                HTML_PrintingElement pel = hTML_RollPaperPrintingOutput.elements[i];
                StringBuilder shtml = null;
                if (pel.Is("div", "pagenumbers")
                    || pel.Is("div", "invoicetop")
                    || pel.Is("tr", "item")
                    || pel.Is("tr", "totalneto")
                    || pel.Is("tr", "taxsum")
                    || pel.Is("tr", "grandtotal")
                    || pel.Is("div", "invoicebottom")
                    )
                {
                    shtml = new StringBuilder(pel.html);
                    bottom += pel.Height;
                }
                else if (pel.Is("table", "tableitems"))
                {
                    shtml = new StringBuilder(pel.html);
                    bottom += Thead_Height;
                }

                if (shtml != null)
                {
                    if (bottom >= xPageHeight- xPageHeight / (7.5))
                    {
                        //new page
                        StartBuildHtmlElementsOnNewPage(pel, hTML_RollPaperPrintingOutput,ref shtml, ref html);
                        bottom = 0;
                    }
                    else
                    {
                        //BuildHtmlElements(pel, hTML_RollPaperPrintingOutput, ref shtml, ref html);
                        if (pel.Is("div", "invoicebottom"))
                        {
                            html.Append(@"
                                                </tbody>
                                              </table>" + shtml + "\r\n");
                        }
                        else
                        {
                            if (pel.Is("tr", "item"))
                            {
                                if (!bFirstItemFound)
                                {
                                    bFirstItemFound = true;
                                    html.Append("\r\n<tbody>");
                                }
                            }
                            html.Append(shtml + "\r\n");
                        }
                    }
                }
            }
            html.Append(@"
                                        </page>
                                       </body>
                                     </html>");

            InsertPageNumbers(ref html);
            return html;
       }

        public bool CustomerIsDefined()
        {
            if (Customer!=null)
            {
                if (Customer is UniversalInvoice.Organisation)
                {
                    UniversalInvoice.Organisation uorg = (UniversalInvoice.Organisation)Customer;
                    if (uorg.Name!=null)
                    {
                        return uorg.Name.Length > 0;
                    }
                }
                if (Customer is UniversalInvoice.Person)
                {
                    UniversalInvoice.Person uper = (UniversalInvoice.Person)Customer;
                    if (uper.FirstName != null)
                    {
                        if (uper.FirstName.Length > 0)
                        {
                                return true;
                        }
                    }
                    if (uper.LastName != null)
                    {
                        if (uper.LastName.Length > 0)
                        {
                           return true;
                        }
                    }
                }
            }
            return false;
        }

        public Image GetOrganisationLogoImage()
        {
            if (MyOrganisation!=null)
            {
                if (MyOrganisation.Logo_Data!=null)
                {
                    return DBTypes.func.byteArrayToImage(MyOrganisation.Logo_Data);
                }
            }
            return null;
        }

        private void InsertPage(ref StringBuilder html, HTML_PrintingElement_List hTML_RollPaperPrintingOutput)
        {
            html.Append(@"</page>
                                        <page>");
            hTML_RollPaperPrintingOutput.NumberOfPages++;

            if (hTML_RollPaperPrintingOutput.pagenumber != null)
            {
                html.Append("\r\n" + hTML_RollPaperPrintingOutput.pagenumber.html + "\r\n");
            }
        }

        //public bool SetCopyPrintInfo(ID xAtom_WorkPeriod_ID,string printer_name, Transaction transaction)
        //{
        //    if (PrintCopyInfo.Length == 0)
        //    {
        //        string s_journal_invoice_type = f_Journal_Consumption.ORIGINALPRINT;
        //        string s_journal_invoice_description = "";
        //        if (printer_name != null)
        //        {
        //                s_journal_invoice_description = printer_name;
                    
        //        }
        //        if (!OriginalOrCopyPrint(s_journal_invoice_description,
        //                                         s_journal_invoice_type,
        //                                         xAtom_WorkPeriod_ID,
        //                                         transaction))
        //        {
        //            return false;
        //        }


        //    }
        //    else
        //    {
        //        string s_journal_invoice_type = f_Journal_Consumption.COPYPRINT;
        //        string s_journal_invoice_description = "";
        //        if (printer_name != null)
        //        {
        //                s_journal_invoice_description = printer_name;
        //        }

        //        if (!OriginalOrCopyPrint(s_journal_invoice_description,
        //                                        s_journal_invoice_type,
        //                                        xAtom_WorkPeriod_ID,
        //                                        transaction))
        //        {
        //            return false;
        //        }

        //    }
        //    return true;
        //}

        private void StartBuildHtmlElementsOnNewPage(HTML_PrintingElement pel, HTML_PrintingElement_List hTML_RollPaperPrintingOutput,ref StringBuilder shtml, ref StringBuilder html)
        {
            if (pel.Is("table", "tableitems"))
            {
                InsertPage(ref html, hTML_RollPaperPrintingOutput);
                html.Append(shtml + "\r\n");
            }
            else if (pel.Is("tr", "item"))
            {
                // close table and open new page
                html.Append(@"</tbody>
                                            </table>
                        ");

                InsertPage(ref html, hTML_RollPaperPrintingOutput);

                html.Append(hTML_RollPaperPrintingOutput.tableitems.html);
                html.Append("\r\n<tbody>\r\n");
                html.Append(shtml + "\r\n");
            }
            else if (pel.Is("tr", "totalneto"))
            {
                html.Append(@"
                                                </tbody>
                                              </table>
                        ");
                InsertPage(ref html, hTML_RollPaperPrintingOutput);
                html.Append("\r\n<table class = \"tableitems\">\r\n");
                html.Append("\r\n<tbody>\r\n");
                html.Append("\r\n" + pel.html + "\r\n");
                if (pel.row_index == hTML_RollPaperPrintingOutput.rows_count - 1)
                {
                    html.Append(@"</tbody>
                                            </table>
                                            ");
                }
            }
            else if (pel.Is("tr", "taxsum"))
            {
                html.Append(@"
                                                </tbody>
                                              </table>
                        ");
                InsertPage(ref html, hTML_RollPaperPrintingOutput);
                html.Append("\r\n" + pel.html + "\r\n");
                html.Append("\r\n<table class = \"tableitems\">\r\n");
                html.Append("\r\n<tbody>\r\n");
                html.Append("\r\n" + pel.html + "\r\n");
                if (pel.row_index == hTML_RollPaperPrintingOutput.rows_count - 1)
                {
                    html.Append(@"</tbody>
                                            </table>
                                            ");
                }
            }
            else if (pel.Is("tr", "grandtotal"))
            {
                html.Append(@"
                                                </tbody>
                                              </table>
");
                InsertPage(ref html, hTML_RollPaperPrintingOutput);
                html.Append("\r\n<table class = \"tableitems\">\r\n");
                html.Append("\r\n<tbody>\r\n");
                html.Append("\r\n" + pel.html + "\r\n");
                if (pel.row_index == hTML_RollPaperPrintingOutput.rows_count - 1)
                {
                    html.Append(@"</tbody>
                                            </table>
                                            ");
                }
            }
            else if (pel.Is("div", "invoicebottom"))
            {
                html.Append(@"
                                                </tbody>
                                              </table>
                        ");
                InsertPage(ref html, hTML_RollPaperPrintingOutput);
                html.Append("\r\n" + pel.html + "\r\n");
                html.Append(@"
                                        </page>
                                       </body>
                                     </html>");
            }
        }

        public bool OriginalOrCopyPrint(string s_journal_invoice_description,string s_journal_invoice_type,ID xAtom_WorkPeriod_ID,Transaction transaction)
        {
            ID journal_Consumption_id = null;
            return f_Journal_Consumption.Write(Consumption_ID, xAtom_WorkPeriod_ID, s_journal_invoice_type, s_journal_invoice_description, PrintingTime_v, ref journal_Consumption_id, transaction);
        }

        public void InsertPageNumbers(ref StringBuilder html)
        {
            int index_of_page_number = -1;
            int page_number_length = -1;
            index_of_page_number = GeneralToken.tPageNumber.IndexOf(html, ref page_number_length);
            if (index_of_page_number >= 0)
            {
                StringBuilder sb = null;
                int iPage = 1;
                while (index_of_page_number >= 0)
                {

                    int isbLen = html.Length;
                    sb = new StringBuilder(html.ToString(0, index_of_page_number));
                    sb.Append(iPage.ToString());
                    sb.Append(html.ToString(index_of_page_number + page_number_length, isbLen - index_of_page_number - page_number_length));
                    index_of_page_number = GeneralToken.tPageNumber.IndexOf(html, index_of_page_number+1, ref page_number_length);
                    if (index_of_page_number >= 0)
                    {
                        iPage++;
                    }
                    else
                    {
                        break;
                    }
                }
                GeneralToken.tNumberOfPages.Set(iPage.ToString());
                GeneralToken.tNumberOfPages.Replace(ref sb);
                html = sb;
            }
        }

        public void AddOn_Get()
        {
            if (IsWriteOff)
            {
                AddOnWriteOff.Get(Consumption_ID);
            }
            else if (IsOwnUse)
            {
                AddOnOwnUse.Get(Consumption_ID);
            }
            else
            {
                LogFile.Error.Show("ERROR:TangentaDB:ConsumptionData:AddOn_Get():Document type not implemented!");
            }
        }

        public bool SaveConsumptionOwnUse(ref ID Consumption_ID,string ElectronicDevice_Name,ID xAtom_WorkPeriod_ID, Transaction transaction)
        {
            int xNumberInFinancialYear = -1;
            DateTime_v ConsumptionTime_v = new DateTime_v();
            ConsumptionTime_v.v = DateTime.Now;
            bool bRet= m_CurrentConsumption.SaveConsumptionOwnUse(Consumption,ref Consumption_ID, AddOnOwnUse, ElectronicDevice_Name, ref xNumberInFinancialYear, transaction);
            if (bRet)
            {
                Consumption_ID = Consumption_ID;
                this.Set_NumberInFinancialYear(xNumberInFinancialYear);
                this.SetConsumptionTime(ConsumptionTime_v, xAtom_WorkPeriod_ID, transaction);
            }
            return bRet;
        }



        public bool SaveConsumption(ref ID Consumption_ID,CashierActivity ca, string ElectronicDevice_Name, ID xAtom_WorkPeriod_ID, Transaction transaction)// GlobalData.ePaymentType m_ePaymentType, string m_sPaymentMethod, string m_sAmountReceived, string m_sToReturn, ref int xNumberInFinancialYear)
        {
            int xNumberInFinancialYear = -1;
            bool bRet = m_CurrentConsumption.SaveConsumptionWriteOff(Consumption,ref Consumption_ID, this.AddOnWriteOff,ca, ElectronicDevice_Name, ref xNumberInFinancialYear, transaction);
            if (bRet)
            {
                Consumption_ID = Consumption_ID;
                this.Set_NumberInFinancialYear(xNumberInFinancialYear);
                DateTime_v ConsumptionTime_v = new DateTime_v(AddOnWriteOff.MyIssueDate.Date);
                this.SetConsumptionTime(ConsumptionTime_v, xAtom_WorkPeriod_ID, transaction);
            }
            return bRet;
        }

        public bool SetConsumptionTime(DateTime_v issue_time,ID xAtom_WorkPeriod_ID, Transaction transaction)
        {
            bool bRet = false;
           
                bRet = m_CurrentConsumption.SetConsumptionTime(issue_time, xAtom_WorkPeriod_ID, transaction);
           

            if (bRet)
            {
                if (issue_time != null)
                {
                    this.IssueDate_v = issue_time.Clone();
                    string stime = LanguageControl.DynSettings.SetLanguageDateTimeString(IssueDate_v.v);

                                
                    ConsumptionToken.tDateOfIssue.Set(stime);
                    if (IsWriteOff)
                    {
                        //if (ConsumptionToken.tDateOfMaturity == null)
                        //{
                        //    ConsumptionToken.tDateOfMaturity = new TemplateToken(lng.st_Consumption, lng.st_DateOfMaturity, null, null);
                        //}

                        //if (AddOnWriteOff.MyPaymentDeadline != null)
                        //{
                         
                        //    stime = LanguageControl.DynSettings.SetLanguageDateString(AddOnWriteOff.MyPaymentDeadline.Date);
                        //    ConsumptionToken.tDateOfMaturity.Set(stime);
                        //}
                        //else
                        //{
                        //    ConsumptionToken.tDateOfMaturity.Set("");
                        //}
                    }
                    if (IsOwnUse)
                    {
                        //if (ConsumptionToken.tOfferValidUntil==null)
                        //{
                        //    ConsumptionToken.tOfferValidUntil = new TemplateToken(lng.st_ProformaConsumption, lng.st_OfferValidUntil, null, null);
                        //}
                        //stime = LanguageControl.DynSettings.SetLanguageDateString(AddOnDPI.m_Duration.ValidUntil(IssueDate_v.v));
                        //ConsumptionToken.tOfferValidUntil.Set(stime);
                    }
                   
                    return true;
                }
                else
                {
                    LogFile.Error.Show("ERROR:ConsumptionData:SetConsumptionTime:issue_time==null!");
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public void Fill_Sold_ShopC_ItemsData(List<TangentaDB.Consumption_ShopC_Item> xConsumption_ShopC_Item_Data_LIST, ltext lt_token_prefix, ref UniversalInvoice.ItemSold[] ItemsSold, int start_index, int count,bool bConsumptionStorno)
        {

            int i;
            int end_index = start_index + count;
            int j = 0;


            for (i = start_index; i < end_index; i++)
            {
                TangentaDB.Consumption_ShopC_Item xdsci = (TangentaDB.Consumption_ShopC_Item)xConsumption_ShopC_Item_Data_LIST[j];

                decimal Discount = xdsci.Discount;

                decimal ExtraDiscount = xdsci.ExtraDiscount;

                decimal TotalDiscount = StaticLib.Func.TotalDiscount(Discount, ExtraDiscount, Currency.DecimalPlaces);

                decimal Atom_Taxation_Rate = xdsci.Atom_Taxation_Rate_v.v;

                decimal RetailItemsPriceWithDiscount = 0;
                decimal ItemsTaxPrice = 0;
                decimal ItemsNetPrice = 0;

                int decimal_places = xdsci.Atom_Currency_DecimalPlaces_v.v;

                decimal RetailPricePerUnit = xdsci.RetailPricePerUnit;
                decimal dQuantityAll = xdsci.dQuantity_FromStock + xdsci.dQuantity_FromFactory;

                StaticLib.Func.CalculatePrice(RetailPricePerUnit, dQuantityAll, Discount, ExtraDiscount, Atom_Taxation_Rate, ref RetailItemsPriceWithDiscount, ref ItemsTaxPrice, ref ItemsNetPrice, decimal_places);


                decimal taxation_rate = DBTypes.tf._set_decimal(xdsci.Atom_Taxation_Rate_v.v);
                decimal tax_price = ItemsTaxPrice;
                string tax_name = xdsci.Atom_Taxation_Name_v.v;

                if (bConsumptionStorno)
                {
                    taxSum.Add(-tax_price, -ItemsNetPrice, tax_name, taxation_rate);
                }
                else
                {
                    taxSum.Add(tax_price, ItemsNetPrice, tax_name, taxation_rate);
                }


                decimal dRetailItemsPriceWithDiscount = DBTypes.tf._set_decimal(RetailItemsPriceWithDiscount);
                tax_price = DBTypes.tf._set_decimal(ItemsTaxPrice);
                decimal dprice_without_tax = DBTypes.tf._set_decimal(ItemsNetPrice);
                if (bConsumptionStorno)
                {
                    tax_price = tax_price * -1;
                    dprice_without_tax = dprice_without_tax * -1;
                    dRetailItemsPriceWithDiscount = dRetailItemsPriceWithDiscount * -1;
                }


                ItemsSold[i] = new UniversalInvoice.ItemSold(lt_token_prefix, lng.s_Shop_C,
                                                             DBTypes.tf._set_string(xdsci.Atom_Item_UniqueName_v.v),
                                                             DBTypes.tf._set_decimal(xdsci.RetailPricePerUnit),
                                                             DBTypes.tf._set_string(xdsci.Atom_Unit_Name_v.v),
                                                             DBTypes.tf._set_decimal(xdsci.RetailPriceWithDiscount),
                                                             DBTypes.tf._set_string(xdsci.Atom_Taxation_Name_v.v),
                                                             DBTypes.tf._set_decimal(dQuantityAll),
                                                             DBTypes.tf._set_decimal(xdsci.Discount),
                                                             DBTypes.tf._set_decimal(xdsci.ExtraDiscount),
                                                             DBTypes.tf._set_string(xdsci.Atom_Currency_Symbol_v.v),
                                                             taxation_rate,
                                                             DBTypes.tf._set_decimal(TotalDiscount),
                                                             dprice_without_tax,
                                                             tax_price,
                                                             dRetailItemsPriceWithDiscount
                                                            );
                j++;
            }

        }

      

        public bool Read_Consumption(Transaction transaction)
        {
            string sql = null;

            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            string spar_Doc_ID = "@par_Doc_ID";
            SQL_Parameter par_Doc_ID = new SQL_Parameter(spar_Doc_ID, SQL_Parameter.eSQL_Parameter.Bigint, false, Consumption_ID);
            lpar.Add(par_Doc_ID);


            if (IsWriteOff)
            {
                Consumption_Reference_ID = null;
                sql = @"select
                            pi.ID as Consumption_ID,
                            pi.FinancialYear,
                            pi.NumberInFinancialYear,
                            pi.Draft,
                            piao.IssueDate,
                            pt.Identification as PaymentType_Identification,
                            GrossSum,
                            TaxSum,
                            NetSum,
                            acur.ID as Atom_Currency_ID,
                            acur.Name as CurrencyName,
                            acur.Symbol as CurrencySymbol,
                            acur.Abbreviation as CurrencyAbbreviation,
                            acur.CurrencyCode as CurrencyCode,
                            acur.DecimalPlaces as CurrencyDecimalPlaces,
                            ao.Name,
                            ao.Tax_ID,
                            ao.Registration_ID,
                            ao.TaxPayer,
                            acmt1.Comment as Comment1,
                            Atom_cStreetName_Org.StreetName,
                            Atom_cHouseNumber_Org.HouseNumber,
                            Atom_cCity_Org.City,
                            Atom_cZIP_Org.ZIP,
                            Atom_cCountry_Org.Country,
                            Atom_cState_Org.State,
                            cEmail_Org.Email,
                            aorgd_hp.HomePage,
                            cPhoneNumber_Org.PhoneNumber,
                            cFaxNumber_Org.FaxNumber,
                            abo.Name as BankName,
                            aba.TRR,
                            aoff.Name as Atom_Office_Name,
                            aoff.ShortName as Atom_Office_ShortName,
                            aed.Name as Atom_Electronic_Device_Name,
                            apfn.FirstName as My_Organisation_Person_FirstName,
                            apln.LastName as My_Organisation_Person_LastName,
                            ap.ID as Atom_Person_ID,
                            ap.CardNumber,
                            amcp.Job as My_Organisation_Job,
                            Atom_Logo.Image_Hash as Logo_Hash,
                            Atom_Logo.Image_Data as Logo_Data,
                            Atom_Logo.Description as Logo_Description,
                            acusorg.ID as Atom_Customer_Org_ID,
                            acusper.ID as Atom_Customer_Person_ID,
                            jpi.EventTime,
                            jpit.Name as JOURNAL_Consumption_Type_Name,
                            pi.Storno,
                            pi.Consumption_Reference_Type,
                            awa.Name as Atom_WorkArea_Name,
                            pi.Consumption_Reference_ID
                            from JOURNAL_Consumption jpi
                            inner join JOURNAL_Consumption_Type jpit on jpi.JOURNAL_Consumption_Type_ID = jpit.ID and ((jpit.ID = " + GlobalData.JOURNAL_Consumption_Type_definitions.ConsumptionDraftTime.ID.ToString() + @") or (jpit.ID = " + GlobalData.JOURNAL_Consumption_Type_definitions.ConsumptionStornoTime.ID.ToString() + @"))
                            inner join Consumption pi on jpi.Consumption_ID = pi.ID
                            inner join Atom_Currency acur on pi.Atom_Currency_ID = acur.ID
                            inner join Atom_WorkPeriod awp on jpi.Atom_WorkPeriod_ID = awp.ID
                            inner join Atom_ElectronicDevice aed on awp.Atom_ElectronicDevice_ID = aed.ID
                            inner join Atom_myOrganisation_Person amcp on awp.Atom_myOrganisation_Person_ID = amcp.ID
                            inner join Atom_Person ap on ap.ID = amcp.Atom_Person_ID
                            inner join Atom_Office aoff on amcp.Atom_Office_ID = aoff.ID
                            inner join Atom_Office_Data aoffd on aoffd.Atom_Office_ID = aoff.ID
                            inner join Atom_myOrganisation amc on aoff.Atom_myOrganisation_ID = amc.ID
                            inner join Atom_OrganisationData aorgd on  amc.Atom_OrganisationData_ID = aorgd.ID
                            inner join Atom_Organisation ao on aorgd.Atom_Organisation_ID = ao.ID
                            left join Atom_Comment1 acmt1 on ao.Atom_Comment1_ID = acmt1.ID
                            left join Consumption_Atom_WorkArea diawa on pi.ID = diawa.Consumption_ID
                            left join Atom_WorkArea awa on awa.ID = diawa.Atom_WorkArea_ID
                            left join ConsumptionAddOn piao on piao.Consumption_ID = pi.ID
                            left join Atom_cFirstName apfn on ap.Atom_cFirstName_ID = apfn.ID 
                            left join Atom_cLastName apln on ap.Atom_cLastName_ID = apln.ID 
                            left join MethodOfPayment_DI mpdi on mpdi.ID = piao.MethodOfPayment_DI_ID
                            left join Atom_BankAccount aba on mpdi.Atom_BankAccount_ID = aba.ID
                            left join Atom_Bank ab on aba.Atom_Bank_ID = ab.ID
                            left join Atom_Organisation abo on ab.Atom_Organisation_ID = abo.ID
                            left join PaymentType pt on mpdi.PaymentType_ID = pt.ID
                            left join cOrgTYPE aorgd_cOrgTYPE on aorgd.cOrgTYPE_ID = aorgd_cOrgTYPE.ID
                            left join Atom_cAddress_Org acaorg on aorgd.Atom_cAddress_Org_ID = acaorg.ID
                            left join Atom_cStreetName_Org on acaorg.Atom_cStreetName_Org_ID = Atom_cStreetName_Org.ID
                            left join Atom_cHouseNumber_Org on acaorg.Atom_cHouseNumber_Org_ID = Atom_cHouseNumber_Org.ID
                            left join Atom_cCity_Org on acaorg.Atom_cCity_Org_ID = Atom_cCity_Org.ID
                            left join Atom_cZIP_Org on acaorg.Atom_cZIP_Org_ID = Atom_cZIP_Org.ID
                            left join Atom_cCountry_Org on acaorg.Atom_cCountry_Org_ID = Atom_cCountry_Org.ID
                            left join Atom_cState_Org on acaorg.Atom_cState_Org_ID = Atom_cState_Org.ID
                            left join cEmail_Org on aorgd.cEmail_Org_ID = cEmail_Org.ID
                            left join cHomePage_Org aorgd_hp  on aorgd.cHomePage_Org_ID = aorgd_hp.ID
                            left join cFaxNumber_Org on aorgd.cFaxNumber_Org_ID = cFaxNumber_Org.ID
                            left join cPhoneNumber_Org on aorgd.cPhoneNumber_Org_ID = cPhoneNumber_Org.ID
                            left join Atom_Logo on aorgd.Atom_Logo_ID = Atom_Logo.ID
                            left join Atom_Customer_Org acusorg on acusorg.ID = pi.Atom_Customer_Org_ID
                            left join Atom_Customer_Person acusper on acusper.ID = pi.Atom_Customer_Person_ID
                            where pi.ID = " + spar_Doc_ID;
                }
                else if (IsOwnUse)
                {
                    sql = @"select
                                pi.ID as DocProformaConsumption_ID,
                                pi.FinancialYear,
                                pi.NumberInFinancialYear,
                                pi.Draft,
                                piao.IssueDate,
                                pt.Identification as PaymentType_Identification,
                                GrossSum,
                                TaxSum,
                                NetSum,
                                acur.ID  as Atom_Currency_ID,
                                acur.Name as CurrencyName,
                                acur.Symbol as CurrencySymbol,
                                acur.Abbreviation as CurrencyAbbreviation,
                                acur.CurrencyCode as CurrencyCode,
                                acur.DecimalPlaces as CurrencyDecimalPlaces,
                                ao.Name,
                                ao.Tax_ID,
                                ao.Registration_ID,
                                ao.TaxPayer,
                                acmt1.Comment as Comment1,
                                Atom_cStreetName_Org.StreetName,
                                Atom_cHouseNumber_Org.HouseNumber,
                                Atom_cCity_Org.City,
                                Atom_cZIP_Org.ZIP,
                                Atom_cCountry_Org.Country,
                                Atom_cState_Org.State,
                                cEmail_Org.Email,
                                aorgd_hp.HomePage,
                                cPhoneNumber_Org.PhoneNumber,
                                cFaxNumber_Org.FaxNumber,
                                abo.Name as BankName,
                                aba.TRR,
                                aoff.Name as Atom_Office_Name,
                                aoff.ShortName as Atom_Office_ShortName,
                                aed.Name as Atom_Electronic_Device_Name,
                                apfn.FirstName as My_Organisation_Person_FirstName,
                                apln.LastName as My_Organisation_Person_LastName,
                                ap.ID as Atom_Person_ID,
                                ap.CardNumber,
                                amcp.Job as My_Organisation_Job,
                                Atom_Logo.Image_Hash as Logo_Hash,
                                Atom_Logo.Image_Data as Logo_Data,
                                Atom_Logo.Description as Logo_Description,
                                acusorg.ID as Atom_Customer_Org_ID,
                                acusper.ID as Atom_Customer_Person_ID,
                                jpi.EventTime,
                                jpit.Name as JOURNAL_DocProformaConsumption_Type_Name
                                from JOURNAL_DocProformaConsumption jpi
                                inner join JOURNAL_DocProformaConsumption_Type jpit on jpi.JOURNAL_DocProformaConsumption_Type_ID = jpit.ID and (jpit.ID = " + GlobalData.JOURNAL_Consumption_Type_definitions.ConsumptionDraftTime.ID.ToString() + @")
                                inner join DocProformaConsumption pi on jpi.DocProformaConsumption_ID = pi.ID
                                inner join Atom_Currency acur on pi.Atom_Currency_ID = acur.ID
                                inner join Atom_WorkPeriod awp on jpi.Atom_WorkPeriod_ID = awp.ID
                                inner join Atom_ElectronicDevice aed on awp.Atom_ElectronicDevice_ID = aed.ID
                                inner join Atom_myOrganisation_Person amcp on awp.Atom_myOrganisation_Person_ID = amcp.ID
                                inner join Atom_Person ap on ap.ID = amcp.Atom_Person_ID
                                inner join Atom_Office aoff on amcp.Atom_Office_ID = aoff.ID
                                inner join Atom_Office_Data aoffd on aoffd.Atom_Office_ID = aoff.ID 
                                inner join Atom_myOrganisation amc on aoff.Atom_myOrganisation_ID = amc.ID
                                inner join Atom_OrganisationData aorgd on  amc.Atom_OrganisationData_ID = aorgd.ID
                                inner join Atom_Organisation ao on aorgd.Atom_Organisation_ID = ao.ID
                                left join Atom_Comment1 acmt1 on ao.Atom_Comment1_ID = acmt1.ID
                                left join DocProformaConsumptionAddOn piao on piao.DocProformaConsumption_ID = pi.ID
                                left join Atom_cFirstName apfn on ap.Atom_cFirstName_ID = apfn.ID 
                                left join Atom_cLastName apln on ap.Atom_cLastName_ID = apln.ID 
                                left join MethodOfPayment_DPI mptdpi on mptdpi.ID = piao.MethodOfPayment_DPI_ID
                                left join Atom_BankAccount aba on mptdpi.Atom_BankAccount_ID = aba.ID
                                left join Atom_Bank ab on aba.Atom_Bank_ID = ab.ID
                                left join Atom_Organisation abo on ab.Atom_Organisation_ID = abo.ID
                                left join PaymentType pt on mptdpi.PaymentType_ID = pt.ID
                                left join cOrgTYPE aorgd_cOrgTYPE on aorgd.cOrgTYPE_ID = aorgd_cOrgTYPE.ID
                                left join Atom_cAddress_Org acaorg on aorgd.Atom_cAddress_Org_ID = acaorg.ID
                                left join Atom_cStreetName_Org on acaorg.Atom_cStreetName_Org_ID = Atom_cStreetName_Org.ID
                                left join Atom_cHouseNumber_Org on acaorg.Atom_cHouseNumber_Org_ID = Atom_cHouseNumber_Org.ID
                                left join Atom_cCity_Org on acaorg.Atom_cCity_Org_ID = Atom_cCity_Org.ID
                                left join Atom_cZIP_Org on acaorg.Atom_cZIP_Org_ID = Atom_cZIP_Org.ID
                                left join Atom_cCountry_Org on acaorg.Atom_cCountry_Org_ID = Atom_cCountry_Org.ID
                                left join Atom_cState_Org on acaorg.Atom_cState_Org_ID = Atom_cState_Org.ID
                                left join cEmail_Org on aorgd.cEmail_Org_ID = cEmail_Org.ID
                                left join cHomePage_Org aorgd_hp  on aorgd.cHomePage_Org_ID = aorgd_hp.ID
                                left join cFaxNumber_Org on aorgd.cFaxNumber_Org_ID = cFaxNumber_Org.ID
                                left join cPhoneNumber_Org on aorgd.cPhoneNumber_Org_ID = cPhoneNumber_Org.ID
                                left join Atom_Logo on aorgd.Atom_Logo_ID = Atom_Logo.ID
                                left join Atom_Customer_Org acusorg on acusorg.ID = pi.Atom_Customer_Org_ID
                                left join Atom_Customer_Person acusper on acusper.ID = pi.Atom_Customer_Person_ID
                                where pi.ID = " + spar_Doc_ID;
            }
            else
            {
                LogFile.Error.Show("ERROR:ConsumptionData:Read_Consumption:Consumption=" + Consumption + " not implemented.");
                return false;
            }

            string Err = null;
            dt_Consumption.Clear();
            dt_Consumption.Columns.Clear();
            if (DBSync.DBSync.ReadDataTable(ref dt_Consumption, sql,lpar, ref Err))
            {
                if (dt_Consumption.Rows.Count == 1)
                {
                    try
                    {
                        Draft = DBTypes.tf._set_bool(dt_Consumption.Rows[0]["Draft"]);
                        IssueDate_v = DBTypes.tf.set_DateTime(dt_Consumption.Rows[0]["IssueDate"]);
                        Electronic_Device_Name_v = DBTypes.tf.set_string(dt_Consumption.Rows[0]["Atom_Electronic_Device_Name"]);

                        Currency.ID = tf.set_ID(dt_Consumption.Rows[0]["Atom_Currency_ID"]);
                        Currency.Name = (string)dt_Consumption.Rows[0]["CurrencyName"];
                        Currency.Symbol = (string)dt_Consumption.Rows[0]["CurrencySymbol"];
                        Currency.Abbreviation = (string)dt_Consumption.Rows[0]["CurrencyAbbreviation"];
                        Currency.CurrencyCode = (int)dt_Consumption.Rows[0]["CurrencyCode"];
                        Currency.DecimalPlaces = (int)dt_Consumption.Rows[0]["CurrencyDecimalPlaces"];
                        My_Organisation_Person_FirstName_v = DBTypes.tf.set_string(dt_Consumption.Rows[0]["My_Organisation_Person_FirstName"]);
                        My_Organisation_Person_LastName_v = DBTypes.tf.set_string(dt_Consumption.Rows[0]["My_Organisation_Person_LastName"]);

                        if (IsWriteOff)
                        {
                            if (!AddOnWriteOff.Get(Consumption_ID))
                            {
                                return false;
                            }
                            Atom_WorkArea_Name_v = DBTypes.tf.set_string(dt_Consumption.Rows[0]["Atom_WorkArea_Name"]);
                            Consumption_Storno_v = DBTypes.tf.set_bool(dt_Consumption.Rows[0]["Storno"]);
                            Consumption_Reference_Type_v = DBTypes.tf.set_string(dt_Consumption.Rows[0]["Consumption_Reference_Type"]);
                            Consumption_Reference_ID = DBTypes.tf.set_ID(dt_Consumption.Rows[0]["Consumption_Reference_ID"]);
                        }
                        else
                        {
                            if (!AddOnOwnUse.Get(Consumption_ID))
                            {
                                return false;
                            }
                        }
                        Consumption_ID = DBTypes.tf.set_ID(dt_Consumption.Rows[0][Consumption+"_ID"]);
                        DateTime_v EventTime_v = DBTypes.tf.set_DateTime(dt_Consumption.Rows[0]["EventTime"]);
                        string_v EventName_v = DBTypes.tf.set_string(dt_Consumption.Rows[0]["JOURNAL_"+Consumption+"_Type_Name"]);

                        if (Draft)
                        {
                            this.m_eType = eType.DRAFT_INVOICE;
                        }
                        else
                        {
                            if (ID.Validate(Consumption_ID))
                            {
                                    if (IsWriteOff)
                                    {
                                        if (EventName_v != null)
                                        {
                                            if (EventName_v.v.Equals("ConsumptionTime"))
                                            {
                                                this.m_eType = eType.INVOICE;
                                            }
                                            else if (EventName_v.v.Equals("ConsumptionStornoTime"))
                                            {
                                                this.m_eType = eType.STORNO;
                                                StornoIssueDate_v = EventTime_v.Clone();
                                                if (ID.Validate(Consumption_Reference_ID))
                                                {
                                                    if (IssueDate_v == null)
                                                    {
                                                        sql = "select EventTime from JOURNAL_Consumption where Consumption_ID = " + Consumption_Reference_ID.ToString() + " and JOURNAL_Consumption_Type_ID = " + GlobalData.JOURNAL_Consumption_Type_definitions.ConsumptionTime.ID.ToString();
                                                        DataTable dt = new DataTable();
                                                        if (DBSync.DBSync.ReadDataTable(ref dt, sql, ref Err))
                                                        {
                                                            if (dt.Rows.Count == 1)
                                                            {
                                                                IssueDate_v = DBTypes.tf.set_DateTime(dt.Rows[0]["EventTime"]);
                                                            }
                                                            else
                                                            {
                                                                LogFile.Error.Show("ERROR:ConsumptionData:Read_Consumption:this error should not happen! EventTime for ConsumptionTime must be defined!");
                                                            }

                                                        }
                                                        else
                                                        {
                                                            LogFile.Error.Show("ERROR:ConsumptionData:Read_Consumption:sql=" + sql + "\r\nERR=" + Err);
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    LogFile.Error.Show("ERROR:ConsumptionData:Read_Consumption:this error should not happen! Consumption_Reference_ID_v must be defined!");
                                                }
                                            }
                                            else
                                            {
                                                if (IssueDate_v == null)
                                                {

                                                    sql = "select EventTime from JOURNAL_Consumption where Consumption_ID = " + Consumption_ID.ToString() + " and JOURNAL_Consumption_Type_ID = " + GlobalData.JOURNAL_Consumption_Type_definitions.ConsumptionTime.ID.ToString();
                                                    DataTable dt = new DataTable();
                                                    if (DBSync.DBSync.ReadDataTable(ref dt, sql, ref Err))
                                                    {
                                                        if (dt.Rows.Count > 0)
                                                        {
                                                            IssueDate_v = DBTypes.tf.set_DateTime(dt.Rows[0]["EventTime"]);
                                                            if (dt.Rows.Count != 1)
                                                            {
                                                                LogFile.Error.Show("ERROR:ConsumptionData:Read_Consumption:this error should not happen! EventTime for ConsumptionTime must be defined!");
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        LogFile.Error.Show("ERROR:ConsumptionData:Read_Consumption:sql=" + sql + "\r\nERR=" + Err);
                                                    }
                                                }
                                                this.m_eType = eType.UNKNOWN;
                                            }

                                        }
                                        else
                                        {
                                            LogFile.Error.Show("ERROR:ConsumptionData:Read_Consumption:this error should not happen! EventName must be defined!");
                                        }
                                    }
                                    else if (IsOwnUse)
                                    {
                                        if (EventName_v != null)
                                        {
                                            if (EventName_v.v.Equals("ProformaConsumptionTime"))
                                            {
                                                this.m_eType = eType.INVOICE;
                                                this.IssueDate_v = EventTime_v.Clone();
                                            }
                                            else
                                            {
                                                if (IssueDate_v == null)
                                                {

                                                    sql = "select EventTime from JOURNAL_Consumption where Consumption_ID = " + Consumption_ID.ToString() + " and JOURNAL_DocProformaConsumption_Type_ID = " + GlobalData.JOURNAL_Consumption_Type_definitions.ConsumptionTime.ID.ToString();
                                                    DataTable dt = new DataTable();
                                                    if (DBSync.DBSync.ReadDataTable(ref dt, sql, ref Err))
                                                    {
                                                        if (dt.Rows.Count == 1)
                                                        {
                                                            IssueDate_v = DBTypes.tf.set_DateTime(dt.Rows[0]["EventTime"]);
                                                        }
                                                        else
                                                        {
                                                            LogFile.Error.Show("ERROR:ConsumptionData:Read_Consumption:this error should not happen! EventTime for ConsumptionTime must be defined!");
                                                        }

                                                    }
                                                    else
                                                    {
                                                        LogFile.Error.Show("ERROR:ConsumptionData:Read_Consumption:sql=" + sql + "\r\nERR=" + Err);
                                                    }
                                                }

                                                this.m_eType = eType.UNKNOWN;
                                            }

                                        }
                                        else
                                        {
                                            LogFile.Error.Show("ERROR:ConsumptionData:Read_Consumption:this error should not happen! EventName must be defined!");
                                        }
                                    }
                                    else
                                    {
                                        LogFile.Error.Show("ERROR:ConsumptionData:Read_Consumption:Consumption="+Consumption+" not implemented.");
                                    }
                                }
                            else
                            {
                                this.m_eType = eType.UNKNOWN;
                            }
                        }

                        if (IsWriteOff)
                        {
                            if (Consumption_Reference_Type_v != null)
                            {
                                if (Consumption_Reference_Type_v.v.Equals("STORNO"))
                                {
                                    if (ID.Validate(Consumption_Reference_ID))
                                    {
                                        bConsumptionStorno = true;
                                    }
                                    else
                                    {
                                        LogFile.Error.Show("ERROR:usrc_Consumption_Preview:Read_DocProformaConsumption:DocProformaConsumption_Reference_ID_v can not be null when Consumption_Reference_Type_v equals 'STORNO'");
                                    }
                                }
                            }
                        }


                        GrossSum = DBTypes.tf._set_decimal(dt_Consumption.Rows[0]["GrossSum"]);
                        taxsum = DBTypes.tf._set_decimal(dt_Consumption.Rows[0]["TaxSum"]);
                        NetSum = DBTypes.tf._set_decimal(dt_Consumption.Rows[0]["NetSum"]);

                        if (IsWriteOff)
                        {
                            if (bConsumptionStorno)
                            {
                                if (GrossSum > 0) GrossSum = GrossSum * -1;
                                if (taxsum > 0) taxsum = taxsum * -1;
                                if (NetSum > 0) NetSum = NetSum * -1;
                            }
                        }

                        //byte[] barr_logoData = (byte[])dt_DocProformaConsumption.Rows[0]["Logo_Data"];
                        MyOrganisation = new UniversalInvoice.Organisation(lng.st_My, DBTypes.tf._set_string(dt_Consumption.Rows[0]["Name"]),
                                                                   DBTypes.tf._set_string(dt_Consumption.Rows[0]["Tax_ID"]),
                                                                   DBTypes.tf._set_string(dt_Consumption.Rows[0]["Registration_ID"]),
                                                                   DBTypes.tf.set_bool(dt_Consumption.Rows[0]["TaxPayer"]),
                                                                   DBTypes.tf.set_string(dt_Consumption.Rows[0]["Comment1"]),
                                                                   DBTypes.tf._set_string(dt_Consumption.Rows[0]["Atom_Office_Name"]),
                                                                   DBTypes.tf._set_string(dt_Consumption.Rows[0]["Atom_Office_ShortName"]), 
                                                                   DBTypes.tf._set_string(dt_Consumption.Rows[0]["BankName"]),
                                                                   DBTypes.tf._set_string(dt_Consumption.Rows[0]["TRR"]),
                                                                   DBTypes.tf._set_string(dt_Consumption.Rows[0]["Email"]),
                                                                   DBTypes.tf._set_string(dt_Consumption.Rows[0]["HomePage"]),
                                                                   DBTypes.tf._set_string(dt_Consumption.Rows[0]["PhoneNumber"]),
                                                                   DBTypes.tf._set_string(dt_Consumption.Rows[0]["FaxNumber"]),
                                                                   DBTypes.tf._set_byte_array(dt_Consumption.Rows[0]["Logo_Data"]),
                                                                   DBTypes.tf._set_string(dt_Consumption.Rows[0]["StreetName"]),
                                                                   DBTypes.tf._set_string(dt_Consumption.Rows[0]["HouseNumber"]),
                                                                   DBTypes.tf._set_string(dt_Consumption.Rows[0]["ZIP"]),
                                                                   DBTypes.tf._set_string(dt_Consumption.Rows[0]["City"]),
                                                                   DBTypes.tf._set_string(dt_Consumption.Rows[0]["Country"]),
                                                                   DBTypes.tf._set_string(dt_Consumption.Rows[0]["State"]));


                        FinancialYear = DBTypes.tf._set_int(dt_Consumption.Rows[0]["FinancialYear"]);
                        NumberInFinancialYear = DBTypes.tf._set_int(dt_Consumption.Rows[0]["NumberInFinancialYear"]);


                        ID xAtom_Person_ID = tf.set_ID(dt_Consumption.Rows[0]["Atom_Person_ID"]);
                        if (ID.Validate(xAtom_Person_ID))
                        {
                            Consumption_Author = f_Atom_Person.GetData(lng.st_IssuerOfConsumption, xAtom_Person_ID);
                        }

                        if (IsWriteOff)
                        {
                        }



                        ID xDoc_ID = Consumption_ID;
                        if (IsWriteOff)
                        {
                            if (ID.Validate(Consumption_Reference_ID))
                            {
                                xDoc_ID = Consumption_Reference_ID;
                            }
                        }

                            List<TangentaDB.Consumption_ShopC_Item> xDocProformaConsumption_ShopC_Item_Data_LIST = new List<TangentaDB.Consumption_ShopC_Item>();
                            if (this.m_eType == eType.STORNO)
                            {
                                if (!m_CurrentConsumption.m_Basket.Read_Consumption_ShopC_Item_Table(Consumption,xDoc_ID, ref xDocProformaConsumption_ShopC_Item_Data_LIST, transaction))
                                {
                                    return false;
                                }
                            }
                            else
                            {
                                xDocProformaConsumption_ShopC_Item_Data_LIST = m_CurrentConsumption.m_Basket.Basket_Consumption_ShopC_Item_LIST;
                            }



                            int iCountShopCItemsSold = xDocProformaConsumption_ShopC_Item_Data_LIST.Count;

                            ItemsSold = new UniversalInvoice.ItemSold[iCountShopCItemsSold];
                            taxSum = new StaticLib.TaxSum();


                            Fill_Sold_ShopC_ItemsData(xDocProformaConsumption_ShopC_Item_Data_LIST, lng.st_WriteOff, ref ItemsSold,0, iCountShopCItemsSold, bConsumptionStorno);
                            GeneralToken = new UniversalInvoice.GeneralToken();
                            ConsumptionToken = new UniversalInvoice.InvoiceToken(IsWriteOff);

                            ConsumptionToken.tFiscalYear.Set(FinancialYear.ToString());
                            ConsumptionToken.tInvoiceNumber.Set(NumberInFinancialYear.ToString());
                            ConsumptionToken.tCashier.Set(Electronic_Device_Name_v.v);

                            if (IsWriteOff)
                            {
                                ConsumptionToken.tStorno.Set("");
                                if (bConsumptionStorno)
                                {
                                    ConsumptionToken.tStorno.Set(lng.s_STORNO.s);
                                }

                            //PrintCopyInfo = GetPrintCopyInfo(Consumption_ID);
                            //ConsumptionToken.tCopyPrintInfo.Set(PrintCopyInfo);
                        }

                        if (!Draft)
                            {
                                string stime = LanguageControl.DynSettings.SetLanguageDateTimeString(IssueDate_v.v);
                                ConsumptionToken.tDateOfIssue.Set(stime);
                                if (IsWriteOff)
                                {
                                    //if (AddOnWriteOff.MyPaymentDeadline != null)
                                    //{
                                    //    stime = LanguageControl.DynSettings.SetLanguageDateString(AddOnWriteOff.MyPaymentDeadline.Date);
                                    //    ConsumptionToken.tDateOfMaturity.Set(stime);
                                    //}
                                    //else
                                    //{
                                    //    ConsumptionToken.tDateOfMaturity.Set("");
                                    //}
                                }
                                else
                                {
                                    //stime = LanguageControl.DynSettings.SetLanguageDateString(AddOnDPI.m_Duration.ValidUntil(IssueDate_v.v));
                                    //ConsumptionToken.tOfferValidUntil.Set(stime);
                                }
                            }
                            return true;
                    }
                    catch (Exception ex)
                    {
                        LogFile.Error.Show("ERROR:usrc_Consumption_Preview:Read_DocProformaConsumption:Exception=" + ex.Message);
                        return false;
                    }
                }
                else
                {
                    if (dt_Consumption.Rows.Count == 0)
                    {
                        //no invoices or ProformaConsumptions
                        LogFile.Error.Show("ERROR:usrc_Consumption_Preview:Read_DocProformaConsumption:dt_DocProformaConsumption.Rows.Count == 0  for DocProformaConsumption_ID=" + Consumption_ID.ToString() + "!\r\nsql = " + sql);
                        return false;
                    }
                    else
                    {
                        //more than one invoice or ProformaConsumption
                        LogFile.Error.Show("ERROR:usrc_Consumption_Preview:Read_DocProformaConsumption:dt_DocProformaConsumption.Rows.Count != 1! for DocProformaConsumption_ID=" + Consumption_ID.ToString() + "!\r\nsql = " + sql);
                        return false;
                    }
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:usrc_Consumption_Preview:Read_DocProformaConsumption:Err=" + Err);
                return false;
            }
        }

        internal bool Issue(OwnUseAddOn ownuse_add_on, Transaction transaction)
        {
            if (f_Consumption.Get
        }

        //private string GetPrintCopyInfo(ID Consumption_ID)
        //{
        //    DateTime xtime = DateTime.Now;
        //    this.PrintingTime_v = new DateTime_v(xtime);
        //    if (f_Journal_Consumption.OriginalPrinted(Consumption_ID))
        //    {
        //        int copy_printed_count = 1;
        //        f_Journal_Consumption.GetCopyPrintedCount(Consumption_ID, ref copy_printed_count);
        //        int this_copy_number = copy_printed_count + 1;
        //        return lng.s_CopyPrintNumber.s + this_copy_number.ToString() +" "+ fs.GetFURS_Time_Formated(xtime);
        //    }
        //    else
        //    {
        //        return "";
        //    }

        //}

        public string GetAllTokens()
        {
            string s = "";

            foreach (UniversalInvoice.TemplateToken tt in this.GeneralToken.list)
            {
                s += "\r\n" + tt.lt.s;
            }

            foreach (UniversalInvoice.TemplateToken tt in this.ConsumptionToken.list)
            {
                s += "\r\n" + tt.lt.s;
            }

            if (IsWriteOff)
            {
                //if (AddOnWriteOff.m_FURS.Consumption_FURS_Token != null)
                //{
                //    foreach (UniversalInvoice.TemplateToken tt in AddOnWriteOff.m_FURS.Consumption_FURS_Token.list)
                //    {
                //        s += "\r\n" + tt.lt.s;
                //    }
                //}
            }


            if (ItemsSold.Count() > 0)
            {
                foreach (UniversalInvoice.TemplateToken tt in this.ItemsSold[0].token.list)
                {
                    s += "\r\n" + tt.lt.s;
                }
            }

            if (IsWriteOff)
            {
                //if (AddOnWriteOff.m_FURS.FVI_SLO_RealEstateBP != null)
                //{
                //    foreach (UniversalInvoice.TemplateToken tt in AddOnWriteOff.m_FURS.FVI_SLO_RealEstateBP.token.list)
                //    {
                //        s += "\r\n" + tt.lt.s;
                //    }
                //}
            }


            foreach (UniversalInvoice.TemplateToken tt in this.MyOrganisation.token.list)
            {
                s += "\r\n" + tt.lt.s;
            }



            foreach (UniversalInvoice.TemplateToken tt in this.MyOrganisation.Address.token.list)
            {
                s += "\r\n" + tt.lt.s;
            }

            if (this.Consumption_Author != null)
            {
                foreach (UniversalInvoice.TemplateToken tt in this.Consumption_Author.token.list)
                {
                    s += "\r\n" + tt.lt.s;
                }
            }

            //UniversalInvoice.Organisation xCustomerOrganisation = new UniversalInvoice.Organisation(lng.st_Customer,
            //                                           null,
            //                                           null,
            //                                           null,
            //                                           null,
            //                                           null,
            //                                           null,
            //                                           null,
            //                                           null,
            //                                           null,
            //                                           null,
            //                                           null,
            //                                           null,
            //                                           null,
            //                                           null,
            //                                           null,
            //                                           null,
            //                                           null,
            //                                           null,
            //                                           null,
            //                                           null);

            //foreach (UniversalInvoice.TemplateToken tt in xCustomerOrganisation.token.list)
            //{
            //    s += "\r\n" + tt.lt.s;
            //}
            //foreach (UniversalInvoice.TemplateToken tt in xCustomerOrganisation.Address.token.list)
            //{
            //    s += "\r\n" + tt.lt.s;
            //}

            //UniversalInvoice.Person xCustomerPerson = new UniversalInvoice.Person(lng.st_Customer, false,
            //                                           null,
            //                                           null,
            //                                           DateTime.MinValue,
            //                                           null,
            //                                           null,
            //                                           null,
            //                                           null,
            //                                           null,
            //                                           null,
            //                                           null,
            //                                           null,
            //                                           null,
            //                                           null,
            //                                           null,
            //                                           null,
            //                                           null,
            //                                           null);
            //foreach (UniversalInvoice.TemplateToken tt in xCustomerPerson.token.list)
            //{
            //    s += "\r\n" + tt.lt.s;
            //}
            //foreach (UniversalInvoice.TemplateToken tt in xCustomerPerson.Address.token.list)
            //{
            //    s += "\r\n" + tt.lt.s;
            //}

            return s;
        }






        public bool CreateHTML_PrintingElementList(ref StringBuilder html_doc_template, ref HTML_PrintingElement_List PrintingElement_List, ref bool bError)
        {
            bError = false;
            if (PrintingElement_List == null)
            {
                PrintingElement_List = new HTML_PrintingElement_List();
            }

            string stime = LanguageControl.DynSettings.SetLanguageDateTimeString(IssueDate_v.v); 
            ConsumptionToken.tDateOfIssue.Set(stime);

            if (IsWriteOff)
            {
                //if (AddOnWriteOff.MyPaymentDeadline != null)
                //{
                //    stime = LanguageControl.DynSettings.SetLanguageDateString(AddOnWriteOff.MyPaymentDeadline.Date);
                //    ConsumptionToken.tDateOfMaturity.Set(stime);
                //}
                //else
                //{
                //    ConsumptionToken.tDateOfMaturity.Set("");
                //}
                if (AddOnWriteOff.m_NoticeText!=null)
                {
                    ConsumptionToken.tNotice.Set(AddOnWriteOff.m_NoticeText);
                }
                else
                {
                    ConsumptionToken.tNotice.Set("");
                }
            }
            else
            {
                //stime = LanguageControl.DynSettings.SetLanguageDateString(AddOnOwnUse.m_Duration.ValidUntil(IssueDate_v.v));
                //ConsumptionToken.tOfferValidUntil.Set(stime);
                //if (AddOnDPI.m_NoticeText != null)
                //{
                //    ConsumptionToken.tNotice.Set(AddOnDPI.m_NoticeText);
                //}
                //else
                //{
                //    ConsumptionToken.tNotice.Set("");
                //}

            }


            sMethodOfPayment = "";
            sBankAccount = "";
            sBankName = "";
            if (IsWriteOff)
            {
                //sMethodOfPayment = this.AddOnWriteOff.MyMethodOfPayment_DI.PaymentType;
                //if (this.AddOnWriteOff.MyMethodOfPayment_DI.m_MyOrgBankAccountPayment != null)
                //{
                //    sBankAccount = this.AddOnWriteOff.MyMethodOfPayment_DI.m_MyOrgBankAccountPayment.BankAccount;
                //    sBankName = this.AddOnWriteOff.MyMethodOfPayment_DI.m_MyOrgBankAccountPayment.BankName;
                //}

            }
            else if (IsOwnUse)
            {
                //sMethodOfPayment = this.AddOnDPI.m_MethodOfPayment_DPI.PaymentType;
                //if (this.AddOnDPI.m_MethodOfPayment_DPI.m_MyOrgBankAccountPayment != null)
                //{
                //    sBankAccount = this.AddOnDPI.m_MethodOfPayment_DPI.m_MyOrgBankAccountPayment.BankAccount;
                //    sBankName = this.AddOnDPI.m_MethodOfPayment_DPI.m_MyOrgBankAccountPayment.BankName;
                //}
            }
            //if (sBankAccount!=null)
            //{
            //    if (sBankAccount.Length > 0)
            //    {
            //        sBankAccount = lng.s_PaymentOnBankAccount.s + ": " + sBankAccount;
            //    }
            //    else
            //    {
            //        sBankAccount = "";
            //    }
            //}
            //else
            //{
            //    sBankAccount = "";
            //}

            //if (sBankName != null)
            //{
            //    if (sBankName.Length > 0)
            //    {
            //        sBankName = lng.s_Bank.s + ": " + sBankName;
            //    }
            //    else
            //    {
            //        sBankName = "";
            //    }

            //}
            //else
            //{
            //    sBankName = "";
            //}

            ConsumptionToken.tPaymentType.Set(sMethodOfPayment);
            ConsumptionToken.tPaymentToBankAccount.Set(sBankAccount);
            ConsumptionToken.tPaymentToBankName.Set(sBankName);

            ConsumptionToken.tPaymentType.Replace(ref html_doc_template);
            ConsumptionToken.tPaymentToBankAccount.Replace(ref html_doc_template);
            ConsumptionToken.tPaymentToBankName.Replace(ref html_doc_template);
            if (IsWriteOff)
            {
                ConsumptionToken.tStorno.Replace(ref html_doc_template);
                ConsumptionToken.tCopyPrintInfo.Replace(ref html_doc_template);
            }
            ConsumptionToken.tFiscalYear.Replace(ref html_doc_template);
            ConsumptionToken.tInvoiceNumber.Replace(ref html_doc_template);
            ConsumptionToken.tIssuerOfInvoice.Replace(ref html_doc_template);

            ConsumptionToken.tCashier.Replace(ref html_doc_template);
            ConsumptionToken.tNotice.Replace(ref html_doc_template);

            Consumption_Author.token.tFirstName.Replace(ref html_doc_template);
            Consumption_Author.token.tLastName.Replace(ref html_doc_template);
            Consumption_Author.token.tTaxID.Replace(ref html_doc_template);

            if (CustomerOrganisation != null)
            {
                foreach (UniversalInvoice.TemplateToken tt in CustomerOrganisation.token.list)
                {
                    tt.Replace(ref html_doc_template);
                }

                foreach (UniversalInvoice.TemplateToken tt in CustomerOrganisation.Address.token.list)
                {
                    tt.Replace(ref html_doc_template);
                }
            }
            if (CustomerPerson != null)
            {
                foreach (UniversalInvoice.TemplateToken tt in CustomerPerson.token.list)
                {
                    tt.Replace(ref html_doc_template);
                }

                foreach (UniversalInvoice.TemplateToken tt in CustomerPerson.Address.token.list)
                {
                    tt.Replace(ref html_doc_template);
                }
            }


            foreach (UniversalInvoice.TemplateToken ivt in MyOrganisation.token.list)
            {
                if (ivt.replacement != null)
                {
                    ivt.Replace(ref html_doc_template);
                }
                else
                {
                    ivt.Replace(ref html_doc_template);
                }
            }

            foreach (UniversalInvoice.TemplateToken ivt in MyOrganisation.Address.token.list)
            {
                if (ivt.replacement != null)
                {
                    ivt.Replace(ref html_doc_template);
                }
                else
                {
                    ivt.Replace(ref html_doc_template);
                }
            }

            ConsumptionToken.tDateOfIssue.Replace(ref html_doc_template);
          

            if (IsWriteOff)
            {
                ConsumptionToken.tDateOfMaturity.Replace(ref html_doc_template);
               
            }
            else
            {
                ConsumptionToken.tOfferValidUntil.Replace(ref html_doc_template);
            }
            int start_index = 0;
            int iStartIndexOf_style = -1;
            int iEndIndexOf_style = -1;

            if (GetHtmlElementByTagName(ref html_doc_template, start_index, ref iStartIndexOf_style, ref iEndIndexOf_style, "style"))
            {
                PrintingElement_List.style = new HTML_PrintingElement();
                PrintingElement_List.style.html = html_doc_template.ToString().Substring(iStartIndexOf_style, iEndIndexOf_style - iStartIndexOf_style + 1);
            }
            else
            {
                bError = true;
                html_doc_template = new StringBuilder("ERROR:&lt;style&gt; not found !");
                return  false;
            }


            int iStartIndexOfPageNumbers = -1;
            int iEndIndexOfPageNumbers = -1;
            if (GetHtmlElementByTagNameAndClassName(ref html_doc_template, iEndIndexOf_style, ref iStartIndexOfPageNumbers, ref iEndIndexOfPageNumbers, "div", "pagenumbers"))
            {
                PrintingElement_List.pagenumber = new HTML_PrintingElement();
                PrintingElement_List.pagenumber.html = html_doc_template.ToString().Substring(iStartIndexOfPageNumbers, iEndIndexOfPageNumbers - iStartIndexOfPageNumbers+1);
            }

            int iStartIndexOfConsumptionTop = -1;
            int iEndIndexOfConsumptionTop = -1;

            if (GetHtmlElementByTagNameAndClassName(ref html_doc_template, start_index, ref iStartIndexOfConsumptionTop, ref iEndIndexOfConsumptionTop, "div", "invoicetop"))
            {
                PrintingElement_List.doctop = new HTML_PrintingElement();
                PrintingElement_List.doctop.html = html_doc_template.ToString().Substring(iStartIndexOfConsumptionTop, iEndIndexOfConsumptionTop - iStartIndexOfConsumptionTop + 1);
            }
            else
            {
                bError = true;
                html_doc_template = new StringBuilder("ERROR:&lt;div class=\"invoicetop\"&gt; not found !");
                return  false;
            }


            int iStartIndexOftable = -1;
            int iEndIndexOftable = -1;

            if (GetHtmlElementByTagNameAndClassName(ref html_doc_template, start_index, ref iStartIndexOftable, ref iEndIndexOftable, "table", "tableitems"))
            {
                int iStartIndexOf_Thead = -1;
                int iEndIndexOf_Thead = -1;
                if  (GetHtmlElementByTagName(ref html_doc_template, iStartIndexOftable,ref iStartIndexOf_Thead, ref iEndIndexOf_Thead,"thead"))
                {
                    PrintingElement_List.tableitems = new HTML_PrintingElement();
                    PrintingElement_List.tableitems.html = html_doc_template.ToString().Substring(iStartIndexOftable, iEndIndexOf_Thead - iStartIndexOftable + 1);
                }
                else
                {
                    bError = true;
                    html_doc_template = new StringBuilder("ERROR:&lt;thead&gt; not found for &ltable class = \"tableitems\"&gt;!");
                    return false;
                }
                int iStartIndexOf_tr = -1;
                int iEndIndexOf_tr = -1;
                int ipos = 0;
                string HtmlTable_TableItems = html_doc_template.ToString().Substring(iStartIndexOftable, iEndIndexOftable - iStartIndexOftable + 1);
                if (GetHtmlElementByTagNameAndClassName(ref html_doc_template, iStartIndexOftable, ref iStartIndexOf_tr, ref iEndIndexOf_tr, "tr", "item"))
                {
                    string tr_RowTemplate = html_doc_template.ToString().Substring(iStartIndexOf_tr, iEndIndexOf_tr - iStartIndexOf_tr + 1);

                    html_doc_template = html_doc_template.Remove(iStartIndexOf_tr, iEndIndexOf_tr - iStartIndexOf_tr + 1);

                    ipos = iStartIndexOf_tr;

                    UniversalInvoice.TemplateToken tCurrency = null;
                    foreach (UniversalInvoice.ItemSold itms in ItemsSold)
                    {
                        if (tCurrency == null)
                        {
                            if (itms.token.tCurrency != null)
                            {
                                tCurrency = itms.token.tCurrency;
                            }
                        }
                        if (itms.dQuantity <= 0)
                        {
                            itms.token.tQuantity.Set("");
                            itms.token.tUnit.Set("");
                            itms.token.tPricePerUnit.Set("");
                        }

                        if (itms.TotalDiscount <= 0)
                        {
                            itms.token.tDiscount.Set("");
                            itms.token.tDiscountPercent.Set("");
                            itms.token.tExtraDiscount.Set("");
                            itms.token.tExtraDiscountPercent.Set("");
                            itms.token.tTotalDiscount.Set("");
                            itms.token.tTotalDiscountPercent.Set("");


                        }

                        StringBuilder sb_RowTemplate = new StringBuilder(tr_RowTemplate, tr_RowTemplate.Length * 2);

                        itms.token.tItemName.Replace(ref sb_RowTemplate);
                        itms.token.tPricePerUnit.Replace(ref sb_RowTemplate);
                        itms.token.tTotalDiscount.Replace(ref sb_RowTemplate);
                        itms.token.tCurrency.Replace(ref sb_RowTemplate);
                        itms.token.tUnit.Replace(ref sb_RowTemplate);
                        itms.token.tQuantity.Replace(ref sb_RowTemplate);
                        itms.token.tTaxationRatePercent.Replace(ref sb_RowTemplate);
                        itms.token.tNetPrice.Replace(ref sb_RowTemplate);
                        itms.token.tTax.Replace(ref sb_RowTemplate);
                        itms.token.tPriceWithTax.Replace(ref sb_RowTemplate);
                        string sRow = sb_RowTemplate.ToString();
                        string s = html_doc_template.ToString().Insert(ipos, sRow);
                        html_doc_template = new StringBuilder(s, s.Length * 2);

                        if (PrintingElement_List.items == null)
                        {
                            PrintingElement_List.items = new List<HTML_PrintingElement>();
                        }
                        HTML_PrintingElement html_item = new HTML_PrintingElement();
                        html_item.html = sRow;
                        PrintingElement_List.items.Add(html_item);
                        ipos += sRow.Length;



                    }


                    tCurrency.Replace(ref html_doc_template);

                    ConsumptionToken.tSumNetPrice.Set(NetSum.ToString());
                    ConsumptionToken.tSumNetPrice.Replace(ref html_doc_template);


                    //string s_journal_invoice_type = lng.s_journal_invoice_type_Print.s;
                    //string s_journal_invoice_description = Program.ReceiptPrinter.PrinterName;
                    //long journal_Consumption_id = -1;
                    //f_Journal_DocProformaConsumption.Write(m_usrc_Print.DocProformaConsumption_ID, Program.Atom_WorkPeriod_ID, s_journal_invoice_type, s_journal_invoice_description, null, ref journal_Consumption_id);
                    int iStartIndexOf_NetSum = -1;
                    int iEndIndexOf_NetSum = -1;
                    if (GetHtmlElementByTagNameAndClassName(ref html_doc_template, ipos, ref iStartIndexOf_NetSum, ref iEndIndexOf_NetSum, "tr", "totalneto"))
                    {
                        if (PrintingElement_List.totalneto == null)
                        {
                            PrintingElement_List.totalneto = new HTML_PrintingElement();
                        }
                        PrintingElement_List.totalneto.html = html_doc_template.ToString().Substring(iStartIndexOf_NetSum, iEndIndexOf_NetSum - iStartIndexOf_NetSum + 1);
                    }
                    else
                    {
                        bError = true;
                        html_doc_template = new StringBuilder("ERROR:&lt;tr class=\"totalneto\"&gt; not found !");
                        return false;
                    }



                    int itr_taxsum_start = html_doc_template.ToString().IndexOf("<tr class=\"taxsum\">", 0);
                    if (itr_taxsum_start > 0)
                    {
                        int itr_taxsum_end = html_doc_template.ToString().IndexOf("</tr>", itr_taxsum_start);
                        if (itr_taxsum_end > 0)
                        {
                            string tr_TaxSum = html_doc_template.ToString().Substring(itr_taxsum_start, itr_taxsum_end - itr_taxsum_start + 5);
                            html_doc_template = html_doc_template.Remove(itr_taxsum_start, itr_taxsum_end - itr_taxsum_start + 5);
                            ipos = itr_taxsum_start;
                            foreach (StaticLib.Tax tax in taxSum.TaxList)
                            {
                                ConsumptionToken.tTaxRateName.Set(tax.Name);
                                ConsumptionToken.tSumTax.Set(tax.TaxAmount.ToString());
                                StringBuilder sb_TaxSum = new StringBuilder(tr_TaxSum, tr_TaxSum.Length*3);
                                ConsumptionToken.tTaxRateName.Replace(ref sb_TaxSum);
                                ConsumptionToken.tSumTax.Replace(ref sb_TaxSum);
                                html_doc_template.Insert(ipos, sb_TaxSum.ToString());
                                if (PrintingElement_List.taxsum==null)
                                {
                                    PrintingElement_List.taxsum = new List<HTML_PrintingElement>();
                                }
                                HTML_PrintingElement html_taxsum = new HTML_PrintingElement();
                                html_taxsum.html = sb_TaxSum.ToString();
                                PrintingElement_List.taxsum.Add(html_taxsum);
                                ipos += sb_TaxSum.Length;
                            }
                            ConsumptionToken.tTotalSum.Set(GrossSum.ToString());
                            ConsumptionToken.tTotalSum.Replace(ref html_doc_template);

                            int iStartIndexOf_GrossSum = -1;
                            int iEndIndexOf_GrossSum = -1;
                            if (GetHtmlElementByTagNameAndClassName(ref html_doc_template, ipos, ref iStartIndexOf_GrossSum, ref iEndIndexOf_GrossSum, "tr", "grandtotal"))
                            {
                                if (PrintingElement_List.grandtotal == null)
                                {
                                    PrintingElement_List.grandtotal = new HTML_PrintingElement();
                                }
                                PrintingElement_List.grandtotal.html = html_doc_template.ToString().Substring(iStartIndexOf_GrossSum, iEndIndexOf_GrossSum - iStartIndexOf_GrossSum + 1);
                            }
                            else
                            {
                                bError = true;
                                html_doc_template = new StringBuilder("ERROR:&lt;tr class=\"grandtotal\"&gt; not found !");
                                return false;
                            }
                            if (IsWriteOff)
                            {
                                
                            }
                            int iStartIndexOf_ConsumptionBottom = -1;
                            int iEndIndexOf_ConsumptionBottom = -1;
                            if (GetHtmlElementByTagNameAndClassName(ref html_doc_template, ipos, ref iStartIndexOf_ConsumptionBottom, ref iEndIndexOf_ConsumptionBottom, "div", "invoicebottom"))
                            {
                                if (PrintingElement_List.docbottom == null)
                                {
                                    PrintingElement_List.docbottom = new HTML_PrintingElement();
                                }
                                PrintingElement_List.docbottom.html = html_doc_template.ToString().Substring(iStartIndexOf_ConsumptionBottom, iEndIndexOf_ConsumptionBottom - iStartIndexOf_ConsumptionBottom + 1);
                            }
                            else
                            {
                                bError = true;
                                html_doc_template = new StringBuilder("ERROR:&lt;div class=\"invoicebottom\"&gt; not found !");
                                return false;
                            }
                            return true;
                        }
                        else
                        {
                            bError = true;
                            html_doc_template = new StringBuilder("ERROR:itr_taxsum_end &lt;= 0");
                            return false;
                        }
                    }
                    else
                    {
                        bError = true;
                        html_doc_template = new StringBuilder("ERROR:itr_taxsum_start &lt;= 0");
                        return false;
                    }
                }
                else
                {
                    bError = true;
                    html_doc_template = new StringBuilder("ERROR:&lt;tr class=\"row\"&gt; not found !");
                    return false;
                }
            }
            else
            {
                bError = true;
                html_doc_template = new StringBuilder("ERROR:&lt;table class=\"tableitems\"&gt; not found !");
                return false;
            }
        }

        public bool GetStartTag(ref StringBuilder html, int start_index, ref int index_of_start_tag, ref int index_of_end_tag, string htmltagname)
        {
            index_of_start_tag = html.ToString().IndexOf("<" + htmltagname, start_index);
            if (index_of_start_tag >= 0)
            {
                index_of_end_tag = html.ToString().IndexOf(">", index_of_start_tag+1);
                if (index_of_end_tag >= 0)
                {
                    return true;
                }
                else
                {
                    LogFile.Error.Show("ERROR:TangentaDB:ConsumptionDate:GetElementStartTag:HTML syntax error: End of html tag not found!");
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public bool GetEndTag(ref StringBuilder html, int start_index, ref int index_of_start_endtag, ref int index_of_end_endtag, string htmltagname)
        {
            index_of_start_endtag = html.ToString().IndexOf("</" + htmltagname, start_index);
            if (index_of_start_endtag > 0)
            {
                index_of_end_endtag = html.ToString().IndexOf(">", index_of_start_endtag);
                if (index_of_end_endtag > 0)
                {
                    return true;
                }
                else
                {
                    LogFile.Error.Show("ERROR:TangentaDB:ConsumptionDate:GetElementEndTag:HTML syntax error: End of html tag not found!");
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public bool HtmlTagContainsClassName(ref StringBuilder html,int index_of_start_tag, int index_of_end_tag,string class_name)
        {
            string stag = html.ToString().Substring(index_of_start_tag, index_of_end_tag - index_of_start_tag);
            fs.RemoveToManySpaces(ref stag);
            int iclass = stag.IndexOf("class=", 0);
            if (iclass > 0)
            {
                int iStartBracets = stag.IndexOf("\"", iclass);
                if (iStartBracets > 0)
                {
                    int iEndBracets = stag.IndexOf("\"", iStartBracets + 1);
                    if (iEndBracets > 0)
                    {
                        if (iEndBracets - iStartBracets > 1)
                        {
                            string sClassName = stag.Substring(iStartBracets + 1, iEndBracets - iStartBracets - 1);
                            if (sClassName.Equals(class_name))
                            {
                                return true;
                            }
                        }
                    }
                    else
                    {
                        LogFile.Error.Show("WARNING:TangentaDB:ConsumptionDate:GetElementStartByClass:HTML syntax error: No \" at the end of class attribute!");
                        return false;
                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:TangentaDB:ConsumptionDate:GetElementStartByClass:HTML syntax error: No \" after class attribute!");
                    return false;
                }
            }
            return false;
        }

        public bool GetHtmlElementStartIndexByTagNameAndClassName(ref StringBuilder html,int start_index, ref int IndexOfElement, string htmltagname, string class_name)
        {
            int index_of_start_tag = 0;
            while (index_of_start_tag >= 0)
            {
                int index_of_end_tag = -1;
                if (GetStartTag(ref html, start_index, ref index_of_start_tag, ref index_of_end_tag, htmltagname))
                {
                    if (HtmlTagContainsClassName(ref html, index_of_start_tag, index_of_end_tag, class_name))
                    {
                        IndexOfElement = index_of_start_tag;
                        return true;
                    }
                    start_index = index_of_end_tag;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        public bool GetHtmlElementStartIndexByTagName(ref StringBuilder html, int start_index, ref int IndexOfElement, string htmltagname)
        {
            int index_of_start_tag = 0;
            int index_of_end_tag = -1;
            if (GetStartTag(ref html, start_index, ref index_of_start_tag, ref index_of_end_tag, htmltagname))
            {
                    IndexOfElement = index_of_start_tag;
                    return true;
            }
            else
            {
                return false;
            }
        }



        public bool GetHtmlElementByTagNameAndClassName(ref StringBuilder html, int start_index, ref int StartIndexOfElementInString, ref int EndIndexOfElementInString, string htmltagname, string class_name)
        {
            if (GetHtmlElementStartIndexByTagNameAndClassName(ref html, start_index, ref StartIndexOfElementInString, htmltagname, class_name))
            {
                if (GetEndOfHtmlElement(ref html,StartIndexOfElementInString,ref EndIndexOfElementInString,htmltagname))
                {
                    string xs = html.ToString().Substring(StartIndexOfElementInString, EndIndexOfElementInString + htmltagname.Length + 3 - StartIndexOfElementInString);
                    return true;
                }
            }
            return false;
        }

        public bool GetHtmlElementByTagName(ref StringBuilder html, int start_index, ref int StartIndexOfElementInString, ref int EndIndexOfElementInString, string htmltagname)
        {
            if (GetHtmlElementStartIndexByTagName(ref html, start_index, ref StartIndexOfElementInString, htmltagname))
            {
                if (GetEndOfHtmlElement(ref html, StartIndexOfElementInString, ref EndIndexOfElementInString, htmltagname))
                {
                    return true;
                }
            }
            return false;
        }

        public bool GetEndOfHtmlElement(ref StringBuilder html, int startIndexOfElementInString, ref int endIndexOfElementInString, string htmltagname)
        {
            int index_of_start_end_tag = -1;
            int index_of_end_end_tag = -1;
            int html_length = html.Length;
            int index_of_start_start_tag = -1;
            int index_of_end_start_tag = -1;
            int NestingLevel = 0;
            while (startIndexOfElementInString < html_length)
            {
                // check for nesting tag
                if (GetStartTag(ref html, startIndexOfElementInString + 1, ref index_of_start_start_tag, ref index_of_end_start_tag, htmltagname))
                {
                    if (GetEndTag(ref html, startIndexOfElementInString + 1, ref index_of_start_end_tag, ref index_of_end_end_tag, htmltagname))
                    {
                        if (index_of_start_start_tag < index_of_end_end_tag)
                        {
                            // nesting
                            startIndexOfElementInString = index_of_end_start_tag;
                            NestingLevel++;
                        }
                        else
                        {
                            if (NestingLevel > 0)
                            {
                                NestingLevel--;
                                startIndexOfElementInString = index_of_end_end_tag;
                            }
                            else
                            {
                                endIndexOfElementInString = index_of_end_end_tag;
                                return true;
                            }
                        }
                    }
                    else
                    {
                        return false;
                    }

                }
                else
                {
                    while (NestingLevel >=0)
                    {
                        if (GetEndTag(ref html, startIndexOfElementInString + 1, ref index_of_start_end_tag, ref index_of_end_end_tag, htmltagname))
                        {
                            startIndexOfElementInString = index_of_end_end_tag;
                        }
                        else
                        {
                            return false;
                        }
                        NestingLevel--;
                    }
                    endIndexOfElementInString = index_of_end_end_tag;
                    return true;
                }
            }
            return false;
        }
    }
}
