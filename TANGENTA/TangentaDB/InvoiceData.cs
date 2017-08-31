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
using ShopA_dbfunc;

namespace TangentaDB
{
    //public class FURS_Response_data
    //{
    //    public string ZOI = null;
    //    public string EOR = null;
    //    public string BarCodeValue = null;
    //    public Image Image_QRcode = null;

    //    public FURS_Response_data(string furs_UniqeMsgID, string furs_UniqeInvID,string furs_barcode_value, Image furs_Image_QRcode)
    //    {
    //        this.ZOI = furs_UniqeMsgID;
    //        this.EOR = furs_UniqeInvID;
    //        this.BarCodeValue = furs_barcode_value;
    //        this.Image_QRcode = furs_Image_QRcode;
    //    }
    //}

    public class InvoiceData
    {

        public DocInvoice_AddOn AddOnDI = null;
        public DocProformaInvoice_AddOn AddOnDPI = null;

        public enum eType { DRAFT_INVOICE, INVOICE, PROFORMA_INVOICE, STORNO, UNKNOWN };

        public eType m_eType = eType.UNKNOWN;
        private string_v Electronic_Device_Name_v = null;



        public long_v DocInvoice_Reference_ID_v = null;
        public bool bInvoiceStorno = false;
        public DateTime_v StornoIssueDate_v = null;
        public bool_v Invoice_Storno_v = null;
        public string_v Invoice_Reference_Type_v = null;



        //public FURS_Response_data FURS_Response_Data = null;

        public DataTable dt_DocInvoice = new DataTable();
        public DataTable dt_ShopB_Items = new DataTable();
        public DataTable dt_ShopA_Items = new DataTable();

        public long DocInvoice_ID = -1;
        public long_v DocInvoice_ID_v = null;



        public int FinancialYear = -1;
        public int NumberInFinancialYear = -1;
        public bool Draft = true;


        public DateTime_v IssueDate_v = null;




        public string Currency_Symbol = null;
        public int Currency_DecimalPlaces = -1;



        public decimal GrossSum = 0;


        public decimal taxsum = 0;
        public decimal NetSum = 0;

        public UniversalInvoice.Organisation MyOrganisation = null;


        public UniversalInvoice.Organisation CustomerOrganisation = null;
        public UniversalInvoice.Person CustomerPerson = null;
        public UniversalInvoice.Person Invoice_Author = null;
        public UniversalInvoice.ItemSold[] ItemsSold = null;
        public UniversalInvoice.GeneralToken GeneralToken = null;
        public UniversalInvoice.InvoiceToken InvoiceToken = null;


        public int iCountSimpleItemsSold = 0;
        public int iCountItemsSold = 0;

        string sMethodOfPayment = "";
        string sBankAccount = "";
        string sBankName = "";

        string sFiscalVerificationOfInvoicesNotDone = null;
        string sFiscalVerification_ZOI = "";
        string sFiscalVerification_EOR = "";

        public TangentaDB.ShopABC m_ShopABC = null;

        public string DocInvoice
        {
            get
            {
                if (m_ShopABC!=null)
                {
                    return m_ShopABC.DocInvoice;
                }
                else
                {
                    return null;
                }
            }
        }

        public bool IsDocInvoice
        {
            get { 
                    if (m_ShopABC!=null)
                    {
                        return m_ShopABC.IsDocInvoice;
                    }
                    else
                    {
                        return false;
                    }
                }
        }

        public bool IsDocProformaInvoice
        {
            get
            {
                if (m_ShopABC != null)
                {
                    return m_ShopABC.IsDocProformaInvoice;
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


        public InvoiceData(TangentaDB.ShopABC xShopABC, long xDocInvoice_ID,  string xElectronic_Device_Name)
        {
            m_ShopABC = xShopABC;
            DocInvoice_ID = xDocInvoice_ID;
            Electronic_Device_Name_v = new string_v(xElectronic_Device_Name);
            AddOnDI = new DocInvoice_AddOn();
            AddOnDPI = new DocProformaInvoice_AddOn();
        }

        public void Set_NumberInFinancialYear(int xNumberInFinancialYear)
        {
            NumberInFinancialYear = xNumberInFinancialYear;
            if (InvoiceToken==null)
            {
                InvoiceToken = new UniversalInvoice.InvoiceToken();
            }
            InvoiceToken.tInvoiceNumber.Set(NumberInFinancialYear.ToString());
        }

   

        public string CreateHTML_PagePaperPrintingOutput(HTML_PrintingElement_List hTML_RollPaperPrintingOutput, double xPageHeight)
        {
            //PageHeight = 1000;
            string html = hTML_RollPaperPrintingOutput.style.html;
            bool bFirstItemFound = false;
            html += @"
             <html>
                <body>
                    <page> ";
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
                return "WARNING:TangentaDB:InvoiceData:CreateHTML_PagePaperPrintingOutput:Document has no items!";
            }

            for (i = 0; i < iCount; i++)
            {
                HTML_PrintingElement pel = hTML_RollPaperPrintingOutput.elements[i];
                string shtml = null;
                if (pel.Is("div", "pagenumbers")
                    || pel.Is("div", "invoicetop")
                    || pel.Is("tr", "item")
                    || pel.Is("tr", "totalneto")
                    || pel.Is("tr", "taxsum")
                    || pel.Is("tr", "grandtotal")
                    || pel.Is("div", "invoicebottom")
                    )
                {
                    shtml = pel.html;
                    bottom += pel.Height;
                }
                else if (pel.Is("table", "tableitems"))
                {
                    shtml = pel.html;
                    bottom += Thead_Height;
                }

                if (shtml != null)
                {
                    if (bottom >= xPageHeight)
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
                            html += @"
                                                </tbody>
                                              </table>" + shtml + "\r\n";
                        }
                        else
                        {
                            if (pel.Is("tr", "item"))
                            {
                                if (!bFirstItemFound)
                                {
                                    bFirstItemFound = true;
                                    html += "\r\n<tbody>";
                                }
                            }
                            html += shtml + "\r\n";
                        }
                    }
                }
            }
            html += @"
                                        </page>
                                       </body>
                                     </html>";

            html = InsertPageNumbers(html);
            return html;
       }

        private void InsertPage(ref string html, HTML_PrintingElement_List hTML_RollPaperPrintingOutput)
        {
            html += @"</page>
                                        <page>";
            hTML_RollPaperPrintingOutput.NumberOfPages++;

            if (hTML_RollPaperPrintingOutput.pagenumber != null)
            {
                html += "\r\n" + hTML_RollPaperPrintingOutput.pagenumber.html + "\r\n";
            }
        }
        private void StartBuildHtmlElementsOnNewPage(HTML_PrintingElement pel, HTML_PrintingElement_List hTML_RollPaperPrintingOutput,ref string shtml, ref string html)
        {
            if (pel.Is("table", "tableitems"))
            {
                InsertPage(ref html, hTML_RollPaperPrintingOutput);
                html += shtml + "\r\n";
            }
            else if (pel.Is("tr", "item"))
            {
                // close table and open new page
                html += @"</tbody>
                                            </table>
                        ";

                InsertPage(ref html, hTML_RollPaperPrintingOutput);

                html += hTML_RollPaperPrintingOutput.tableitems.html;
                html += "\r\n<tbody>\r\n";
                html += shtml + "\r\n";
            }
            else if (pel.Is("tr", "totalneto"))
            {
                html += @"
                                                </tbody>
                                              </table>
                        ";
                InsertPage(ref html, hTML_RollPaperPrintingOutput);
                html += "\r\n<table class = \"tableitems\">\r\n";
                html += "\r\n<tbody>\r\n";
                html += "\r\n" + pel.html + "\r\n";
                if (pel.row_index == hTML_RollPaperPrintingOutput.rows_count - 1)
                {
                    html += @"</tbody>
                                            </table>
                                            ";
                }
            }
            else if (pel.Is("tr", "taxsum"))
            {
                html += @"
                                                </tbody>
                                              </table>
                        ";
                InsertPage(ref html, hTML_RollPaperPrintingOutput);
                html += "\r\n" + pel.html + "\r\n";
                html += "\r\n<table class = \"tableitems\">\r\n";
                html += "\r\n<tbody>\r\n";
                html += "\r\n" + pel.html + "\r\n";
                if (pel.row_index == hTML_RollPaperPrintingOutput.rows_count - 1)
                {
                    html += @"</tbody>
                                            </table>
                                            ";
                }
            }
            else if (pel.Is("tr", "grandtotal"))
            {
                html += @"
                                                </tbody>
                                              </table>
";
                InsertPage(ref html, hTML_RollPaperPrintingOutput);
                html += "\r\n<table class = \"tableitems\">\r\n";
                html += "\r\n<tbody>\r\n";
                html += "\r\n" + pel.html + "\r\n";
                if (pel.row_index == hTML_RollPaperPrintingOutput.rows_count - 1)
                {
                    html += @"</tbody>
                                            </table>
                                            ";
                }
            }
            else if (pel.Is("div", "invoicebottom"))
            {
                html += @"
                                                </tbody>
                                              </table>
                        ";
                InsertPage(ref html, hTML_RollPaperPrintingOutput);
                html += "\r\n" + pel.html + "\r\n";
                html += @"
                                        </page>
                                       </body>
                                     </html>";
            }
        }

        public string InsertPageNumbers(string html)
        {
            int index_of_page_number = -1;
            int page_number_length = -1;
            index_of_page_number = GeneralToken.tPageNumber.IndexOf(html, ref page_number_length);
            int iPage = 1;
            while (index_of_page_number >= 0)
            {
                html = html.Substring(0,index_of_page_number) + iPage.ToString() + html.Substring(index_of_page_number + page_number_length);
                index_of_page_number = GeneralToken.tPageNumber.IndexOf(html, ref page_number_length);
                if (index_of_page_number >= 0)
                {
                    iPage++;
                }
            }
            GeneralToken.tNumberOfPages.Set(iPage.ToString());
            html = GeneralToken.tNumberOfPages.Replace(html);
            return html;
        }

        public void Fill_Sold_ShopA_ItemsData(ltext lt_token_prefix, ref UniversalInvoice.ItemSold[] ItemsSold, int start_index, int count, bool bInvoiceStorno)
        {
            int i;
            int end_index = start_index + count;
            int j = 0;
            for (i = start_index; i < end_index; i++)
            {
                DataRow dr = dt_ShopA_Items.Rows[j];

                decimal Discount = 0;
                object oDiscount = dr[DocInvoice + "_ShopA_Item_$$Discount"];
                if (oDiscount is decimal)
                {
                    Discount = (decimal)oDiscount;
                }


                decimal TotalDiscount = Discount;

                decimal RetailSimpleItemPriceWithDiscount = 0;
                object o_RetailSimpleItemPriceWithDiscount = dr[DocInvoice+"_ShopA_Item_$$EndPriceWithDiscountAndTax"];
                if (o_RetailSimpleItemPriceWithDiscount.GetType() == typeof(decimal))
                {
                    RetailSimpleItemPriceWithDiscount = (decimal)o_RetailSimpleItemPriceWithDiscount;
                }

                string sUnitName = "";
                object oUnitName = dr[DocInvoice+"_ShopA_Item_$_aisha_$_u_$$Name"];
                if (oUnitName is string)
                {
                    sUnitName = (string)oUnitName;
                }

                decimal dQuantity = -1;
                object oQuantity = dr[DocInvoice+"_ShopA_Item_$$dQuantity"];
                if (oQuantity is decimal)
                {
                    dQuantity = (decimal)oQuantity;
                }

                decimal TaxPrice = -1;
                object oTaxPrice = dr[DocInvoice+"_ShopA_Item_$$TAX"];
                if (oTaxPrice is decimal)
                {
                    TaxPrice = (decimal)oTaxPrice;
                }
                decimal price_without_tax = RetailSimpleItemPriceWithDiscount - TaxPrice;

                decimal taxation_rate = DBTypes.tf._set_decimal(dr[DocInvoice+"_ShopA_Item_$_aisha_$_tax_$$Rate"]);
                decimal tax_price = DBTypes.tf._set_decimal(dr[DocInvoice+"_ShopA_Item_$$TAX"]);
                string tax_name = DBTypes.tf._set_string(dr[DocInvoice+"_ShopA_Item_$_aisha_$_tax_$$Name"]);
                if (bInvoiceStorno)
                {
                    taxSum.Add(-tax_price, -price_without_tax, tax_name, taxation_rate);
                }
                else
                { 
                    taxSum.Add(tax_price, price_without_tax, tax_name, taxation_rate);
                }

                decimal dRetailPricePerUnitWithDiscount = 0;
                if (dr[DocInvoice+"_ShopA_Item_$$PricePerUnit"] is decimal)
                {
                    dRetailPricePerUnitWithDiscount = decimal.Round((decimal)dr[DocInvoice+"_ShopA_Item_$$PricePerUnit"] * (1 - Discount), GlobalData.BaseCurrency.DecimalPlaces);
                }

                decimal dprice_without_tax = DBTypes.tf._set_decimal(price_without_tax);
                decimal dEndPriceWithDiscountAndTax = DBTypes.tf._set_decimal(dr[DocInvoice+"_ShopA_Item_$$EndPriceWithDiscountAndTax"]);
                if (bInvoiceStorno)
                {
                    tax_price = tax_price * -1;
                    dprice_without_tax = dprice_without_tax * -1;
                    dEndPriceWithDiscountAndTax = dEndPriceWithDiscountAndTax * -1;
                }

                ItemsSold[i] = new UniversalInvoice.ItemSold(lt_token_prefix, lngRPM.s_Shop_B,
                                                             DBTypes.tf._set_string(dr[DocInvoice+"_ShopA_Item_$_aisha_$$Name"]),
                                                             DBTypes.tf._set_decimal(dr[DocInvoice+"_ShopA_Item_$$PricePerUnit"]),
                                                             sUnitName, 
                                                             dRetailPricePerUnitWithDiscount,
                                                             tax_name,
                                                             dQuantity,
                                                             DBTypes.tf._set_decimal(dr[DocInvoice+"_ShopA_Item_$$Discount"]),
                                                             DBTypes.tf._set_decimal(0),
                                                             DBTypes.tf._set_string(GlobalData.BaseCurrency.Symbol),
                                                             taxation_rate,
                                                             DBTypes.tf._set_decimal(TotalDiscount),
                                                             dprice_without_tax,
                                                             tax_price,
                                                             dEndPriceWithDiscountAndTax
                                                            );

                j++;
            }

        }

        public bool SaveDocProformaInvoice(ref long docInvoice_ID, GlobalData.ePaymentType ePaymentType, long MethodOfPayment_ID, long docDuration, long docDurationType_ID, long termsOfPayment_ID, ref int xNumberInFinancialYear)
        {
            return m_ShopABC.m_CurrentInvoice.SaveDocProformaInvoice(ref DocInvoice_ID, ePaymentType, MethodOfPayment_ID, docDuration, docDurationType_ID, termsOfPayment_ID, ref xNumberInFinancialYear);
        }

        public void Fill_Sold_ShopB_ItemsData(ltext lt_token_prefix, ref UniversalInvoice.ItemSold[] ItemsSold, int start_index, int count, bool bInvoiceStorno)
        {
            int i;
            int end_index = start_index + count;
            int j = 0;
            for (i = start_index; i < end_index; i++)
            {
                DataRow dr = dt_ShopB_Items.Rows[j];

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

                decimal TotalDiscount = StaticLib.Func.TotalDiscount(Discount, ExtraDiscount, GlobalData.Get_BaseCurrency_DecimalPlaces());

                decimal RetailSimpleItemPriceWithDiscount = 0;
                object o_RetailSimpleItemPriceWithDiscount = dr["RetailSimpleItemPriceWithDiscount"];
                if (o_RetailSimpleItemPriceWithDiscount.GetType() == typeof(decimal))
                {
                    RetailSimpleItemPriceWithDiscount = (decimal)o_RetailSimpleItemPriceWithDiscount;
                }

                decimal TaxPrice = -1;
                object oTaxPrice = dr["TaxPrice"];
                if (oTaxPrice is decimal)
                {
                    TaxPrice = (decimal)oTaxPrice;
                }
                decimal price_without_tax = RetailSimpleItemPriceWithDiscount - TaxPrice;

                decimal taxation_rate = DBTypes.tf._set_decimal(dr["Atom_Taxation_Rate"]);
                decimal tax_price = DBTypes.tf._set_decimal(dr["TaxPrice"]);
                string tax_name = DBTypes.tf._set_string(dr["Atom_Taxation_Name"]);

                if (bInvoiceStorno)
                {
                    taxSum.Add(-tax_price, -price_without_tax, tax_name, taxation_rate);
                }
                else
                {
                    taxSum.Add(tax_price, price_without_tax, tax_name, taxation_rate);
                }


                
                decimal dEndPriceWithDiscountAndTax = DBTypes.tf._set_decimal(dr["RetailSimpleItemPriceWithDiscount"]);
                if (bInvoiceStorno)
                {
                    tax_price = tax_price * -1;
                    price_without_tax = price_without_tax * -1;
                    dEndPriceWithDiscountAndTax = dEndPriceWithDiscountAndTax * -1;
                }

                ItemsSold[i] = new UniversalInvoice.ItemSold(lt_token_prefix, lngRPM.s_Shop_B,
                                                             DBTypes.tf._set_string(dr["Name"]),
                                                             DBTypes.tf._set_decimal(dr["RetailSimpleItemPrice"]),
                                                             "", // no unit
                                                             DBTypes.tf._set_decimal(dr["RetailSimpleItemPriceWithDiscount"]),
                                                             tax_name,
                                                             Convert.ToDecimal(DBTypes.tf._set_int(dr["iQuantity"])),
                                                             DBTypes.tf._set_decimal(dr["Discount"]),
                                                             DBTypes.tf._set_decimal(dr["ExtraDiscount"]),
                                                             DBTypes.tf._set_string(dr["Atom_Currency_Symbol"]),
                                                             taxation_rate,
                                                             DBTypes.tf._set_decimal(TotalDiscount),
                                                             price_without_tax,
                                                             tax_price,
                                                             dEndPriceWithDiscountAndTax
                                                             );

                j++;
            }

        }


        public bool SaveDocInvoice(ref long docinvoice_ID)// GlobalData.ePaymentType m_ePaymentType, string m_sPaymentMethod, string m_sAmountReceived, string m_sToReturn, ref int xNumberInFinancialYear)
        {
            int xNumberInFinancialYear = -1;
            DateTime_v InvoiceTime_v = new DateTime_v();
            InvoiceTime_v.v = DateTime.Now;
            bool bRet = m_ShopABC.m_CurrentInvoice.SaveDocInvoice(ref DocInvoice_ID, this.AddOnDI.m_MethodOfPayment_DI.eType, this.AddOnDI.m_MethodOfPayment_DI.PaymentType, this.AddOnDI.m_MethodOfPayment_DI.m_sAmountReceived, this.AddOnDI.m_MethodOfPayment_DI.m_sToReturn, ref xNumberInFinancialYear);
            if (bRet)
            {
                docinvoice_ID = DocInvoice_ID;
                this.Set_NumberInFinancialYear(xNumberInFinancialYear);
                this.SetInvoiceTime(InvoiceTime_v);
            }
            return bRet;
        }

        public bool SetInvoiceTime(DateTime_v issue_time)
        {
            if (m_ShopABC.m_CurrentInvoice.SetInvoiceTime(issue_time))
            {
                if (issue_time != null)
                {
                    this.IssueDate_v = issue_time.Clone();
                    string stime = IssueDate_v.v.Day.ToString() + "."
                                    + IssueDate_v.v.Month.ToString() + "."
                                    + IssueDate_v.v.Year.ToString() + " "
                                    + IssueDate_v.v.Hour.ToString() + ":"
                                    + IssueDate_v.v.Minute.ToString();
                    InvoiceToken.tDateOfIssue.Set(stime);
                    InvoiceToken.tDateOfMaturity.Set(stime);
                    return true;
                }
                else
                {
                    LogFile.Error.Show("ERROR:InvoiceData:SetInvoiceTime:issue_time==null!");
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public void Fill_Sold_ShopC_ItemsData(List<object> xDocInvoice_ShopC_Item_Data_LIST, ltext lt_token_prefix, ref UniversalInvoice.ItemSold[] ItemsSold, int start_index, int count,bool bInvoiceStorno)
        {

            int i;
            int end_index = start_index + count;
            int j = 0;


            for (i = start_index; i < end_index; i++)
            {
                Atom_DocInvoice_ShopC_Item_Price_Stock_Data appisd = (Atom_DocInvoice_ShopC_Item_Price_Stock_Data)xDocInvoice_ShopC_Item_Data_LIST[j];

                decimal Discount = appisd.Discount.v;

                decimal ExtraDiscount = appisd.ExtraDiscount.v;

                decimal TotalDiscount = StaticLib.Func.TotalDiscount(Discount, ExtraDiscount, GlobalData.Get_BaseCurrency_DecimalPlaces());

                decimal Atom_Taxation_Rate = appisd.Atom_Taxation_Rate.v;

                decimal RetailItemsPriceWithDiscount = 0;
                decimal ItemsTaxPrice = 0;
                decimal ItemsNetPrice = 0;

                int decimal_places = appisd.Atom_Currency_DecimalPlaces.v;

                decimal RetailPricePerUnit = appisd.RetailPricePerUnit.v;
                decimal dQuantityAll = appisd.dQuantity_FromStock + appisd.dQuantity_FromFactory;

                StaticLib.Func.CalculatePrice(RetailPricePerUnit, dQuantityAll, Discount, ExtraDiscount, Atom_Taxation_Rate, ref RetailItemsPriceWithDiscount, ref ItemsTaxPrice, ref ItemsNetPrice, decimal_places);


                decimal taxation_rate = DBTypes.tf._set_decimal(appisd.Atom_Taxation_Rate.v);
                decimal tax_price = ItemsTaxPrice;
                string tax_name = appisd.Atom_Taxation_Name.v;

                if (bInvoiceStorno)
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
                if (bInvoiceStorno)
                {
                    tax_price = tax_price * -1;
                    dprice_without_tax = dprice_without_tax * -1;
                    dRetailItemsPriceWithDiscount = dRetailItemsPriceWithDiscount * -1;
                }


                ItemsSold[i] = new UniversalInvoice.ItemSold(lt_token_prefix, lngRPM.s_Shop_B,
                                                             DBTypes.tf._set_string(appisd.Atom_Item_UniqueName.v),
                                                             DBTypes.tf._set_decimal(appisd.RetailPricePerUnit.v),
                                                             DBTypes.tf._set_string(appisd.Atom_Unit_Name.v),
                                                             DBTypes.tf._set_decimal(appisd.RetailPriceWithDiscount.v),
                                                             DBTypes.tf._set_string(appisd.Atom_Taxation_Name.v),
                                                             DBTypes.tf._set_decimal(dQuantityAll),
                                                             DBTypes.tf._set_decimal(appisd.Discount.v),
                                                             DBTypes.tf._set_decimal(appisd.ExtraDiscount.v),
                                                             DBTypes.tf._set_string(appisd.Atom_Currency_Symbol.v),
                                                             taxation_rate,
                                                             DBTypes.tf._set_decimal(TotalDiscount),
                                                             dprice_without_tax,
                                                             tax_price,
                                                             dRetailItemsPriceWithDiscount
                                                            );
                j++;
            }

        }



        public bool Read_DocInvoice()
        {
            string sql = null;
            if (IsDocInvoice)
            {
                DocInvoice_Reference_ID_v = null;
                if (AddOnDI.b_FVI_SLO)
                {
                    sql = @"select
                                pi.ID as DocInvoice_ID,
                                pi.FinancialYear,
                                pi.NumberInFinancialYear,
                                pi.Draft,
                                piao.IssueDate,
                                pt.Identification as PaymentType_Identification,
                                GrossSum,
                                TaxSum,
                                NetSum,
                                ao.Name,
                                ao.Tax_ID,
                                ao.Registration_ID,
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
                                aorgd.BankName,
                                aorgd.TRR,
                                aoff.Name as Atom_Office_Name,
                                aed.Name as Atom_Electronic_Device_Name,
                                apfn.FirstName as My_Organisation_Person_FirstName,
                                apln.LastName as My_Organisation_Person_LastName,
                                ap.ID as Atom_MyOrganisation_Person_ID,
                                ao.Tax_ID as My_Organisation_Tax_ID,
                                ap.CardNumber,
                                amcp.UserName as My_Organisation_Person_UserName,
                                amcp.Job as My_Organisation_Job,
                                Atom_Logo.Image_Hash as Logo_Hash,
                                Atom_Logo.Image_Data as Logo_Data,
                                Atom_Logo.Description as Logo_Description,
                                acusorg.ID as Atom_Customer_Org_ID,
                                acusper.ID as Atom_Customer_Person_ID,
                                jpi.EventTime,
                                jpit.Name as JOURNAL_DocInvoice_Type_Name,
                                JOURNAL_DocInvoice_$_dinv_$_fvisres.MessageID As JOURNAL_DocInvoice_$_dinv_$_fvisres_$$MessageID,
                                JOURNAL_DocInvoice_$_dinv_$_fvisres.UniqueInvoiceID As JOURNAL_DocInvoice_$_dinv_$_fvisres_$$UniqueInvoiceID,
                                JOURNAL_DocInvoice_$_dinv_$_fvisres.BarCodeValue As JOURNAL_DocInvoice_$_dinv_$_fvisres_$$BarCodeValue,
                                JOURNAL_DocInvoice_$_dinv_$_fvisres.TestEnvironment As JOURNAL_DocInvoice_$_dinv_$_fvisres_$$TestEnvironment,
                                JOURNAL_DocInvoice_$_dinv_$_fvisbi.InvoiceNumber AS JOURNAL_DocInvoice_$_dinv_$_fvisbi_$$InvoiceNumber,
                                JOURNAL_DocInvoice_$_dinv_$_fvisbi.SetNumber AS JOURNAL_DocInvoice_$_dinv_$_fvisbi_$$SetNumber,
                                JOURNAL_DocInvoice_$_dinv_$_fvisbi.SerialNumber AS JOURNAL_DocInvoice_$_dinv_$_fvisbi_$$SerialNumber,
                                pi.Storno,
                                pi.Invoice_Reference_Type,
                                pi.Invoice_Reference_ID
                                from JOURNAL_DocInvoice jpi
                                inner join JOURNAL_DocInvoice_Type jpit on jpi.JOURNAL_DocInvoice_Type_ID = jpit.ID and ((jpit.ID = " + GlobalData.JOURNAL_DocInvoice_Type_definitions.InvoiceDraftTime.ID.ToString() + @") or (jpit.ID = " + GlobalData.JOURNAL_DocInvoice_Type_definitions.InvoiceStornoTime.ID.ToString() + @"))
                                inner join DocInvoice pi on jpi.DocInvoice_ID = pi.ID
                                inner join Atom_WorkPeriod awp on jpi.Atom_WorkPeriod_ID = awp.ID
                                inner join Atom_ElectronicDevice aed on awp.Atom_ElectronicDevice_ID = aed.ID
                                inner join Atom_myOrganisation_Person amcp on awp.Atom_myOrganisation_Person_ID = amcp.ID
                                inner join Atom_Person ap on ap.ID = amcp.Atom_Person_ID
                                inner join Atom_Office aoff on amcp.Atom_Office_ID = aoff.ID
                                inner join Atom_Office_Data aoffd on aoffd.Atom_Office_ID = aoff.ID 
                                inner join Atom_myOrganisation amc on aoff.Atom_myOrganisation_ID = amc.ID
                                inner join Atom_OrganisationData aorgd on  amc.Atom_OrganisationData_ID = aorgd.ID
                                inner join Atom_Organisation ao on aorgd.Atom_Organisation_ID = ao.ID
                                left join DocInvoiceAddOn piao on piao.DocInvoice_ID = pi.ID
                                LEFT JOIN FVI_SLO_Response JOURNAL_DocInvoice_$_dinv_$_fvisres ON JOURNAL_DocInvoice_$_dinv_$_fvisres.DocInvoice_ID = pi.ID 
                                LEFT JOIN FVI_SLO_SalesBookInvoice JOURNAL_DocInvoice_$_dinv_$_fvisbi ON JOURNAL_DocInvoice_$_dinv_$_fvisbi.DocInvoice_ID = pi.ID 
                                left join Atom_cFirstName apfn on ap.Atom_cFirstName_ID = apfn.ID 
                                left join Atom_cLastName apln on ap.Atom_cLastName_ID = apln.ID 
                                left join MethodOfPayment_DI mpdi on mpdi.ID = piao.MethodOfPayment_DI_ID
                                left join MethodOfPayment_DI_BAccount mptdiba on mptdiba.MethodOfPayment_DI_ID = mpdi.ID
                                left join Atom_BankAccount aba on mptdiba.Atom_BankAccount_ID = aba.ID
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
                                left join cHomePage_Org on aorgd.cHomePage_Org_ID = cHomePage_Org.ID
                                left join cEmail_Org on aorgd.cEmail_Org_ID = cEmail_Org.ID
                                left join cHomePage_Org aorgd_hp  on aorgd.cHomePage_Org_ID = cHomePage_Org.ID
                                left join cFaxNumber_Org on aorgd.cFaxNumber_Org_ID = cFaxNumber_Org.ID
                                left join cPhoneNumber_Org on aorgd.cPhoneNumber_Org_ID = cPhoneNumber_Org.ID
                                left join Atom_Logo on aorgd.Atom_Logo_ID = Atom_Logo.ID
                                left join Atom_Customer_Org acusorg on acusorg.ID = pi.Atom_Customer_Org_ID
                                left join Atom_Customer_Person acusper on acusper.ID = pi.Atom_Customer_Person_ID
                                where pi.ID = " + DocInvoice_ID.ToString();
                }
                else
                {
                    sql = @"select
                                pi.ID as DocInvoice_ID,
                                pi.FinancialYear,
                                pi.NumberInFinancialYear,
                                pi.Draft,
                                piao.IssueDate,
                                pt.Identification as PaymentType_Identification,
                                GrossSum,
                                TaxSum,
                                NetSum,
                                ao.Name,
                                ao.Tax_ID,
                                ao.Registration_ID,
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
                                abo.BankName,
                                aba.TRR,
                                aoff.Name as Atom_Office_Name,
                                aed.Name as Atom_Electronic_Device_Name,
                                apfn.FirstName as My_Organisation_Person_FirstName,
                                apln.LastName as My_Organisation_Person_LastName,
                                ap.ID as Atom_MyOrganisation_Person_ID,
                                ao.Tax_ID as My_Organisation_Tax_ID,
                                ap.CardNumber,
                                amcp.UserName as My_Organisation_Person_UserName,
                                amcp.Job as My_Organisation_Job,
                                Atom_Logo.Image_Hash as Logo_Hash,
                                Atom_Logo.Image_Data as Logo_Data,
                                Atom_Logo.Description as Logo_Description,
                                acusorg.ID as Atom_Customer_Org_ID,
                                acusper.ID as Atom_Customer_Person_ID,
                                jpi.EventTime,
                                jpit.Name as JOURNAL_DocInvoice_Type_Name,
                                pi.Storno,
                                pi.Invoice_Reference_Type,
                                pi.Invoice_Reference_ID
                                from JOURNAL_DocInvoice jpi
                                inner join JOURNAL_DocInvoice_Type jpit on jpi.JOURNAL_DocInvoice_Type_ID = jpit.ID and ((jpit.ID = " + GlobalData.JOURNAL_DocInvoice_Type_definitions.InvoiceDraftTime.ID.ToString() + @") or (jpit.ID = " + GlobalData.JOURNAL_DocInvoice_Type_definitions.InvoiceStornoTime.ID.ToString() + @"))
                                inner join DocInvoice pi on jpi.DocInvoice_ID = pi.ID
                                inner join Atom_WorkPeriod awp on jpi.Atom_WorkPeriod_ID = awp.ID
                                inner join Atom_ElectronicDevice aed on awp.Atom_ElectronicDevice_ID = aed.ID
                                inner join Atom_myOrganisation_Person amcp on awp.Atom_myOrganisation_Person_ID = amcp.ID
                                inner join Atom_Person ap on ap.ID = amcp.Atom_Person_ID
                                inner join Atom_Office aoff on amcp.Atom_Office_ID = aoff.ID
                                inner join Atom_Office_Data aoffd on aoffd.Atom_Office_ID = aoff.ID
                                inner join Atom_myOrganisation amc on aoff.Atom_myOrganisation_ID = amc.ID
                                inner join Atom_OrganisationData aorgd on  amc.Atom_OrganisationData_ID = aorgd.ID
                                inner join Atom_Organisation ao on aorgd.Atom_Organisation_ID = ao.ID
                                left join DocInvoiceAddOn piao on piao.DocInvoice_ID = pi.ID
                                left join Atom_cFirstName apfn on ap.Atom_cFirstName_ID = apfn.ID 
                                left join Atom_cLastName apln on ap.Atom_cLastName_ID = apln.ID 
                                left join MethodOfPayment_DI mpdi on mpdi.ID = piao.MethodOfPayment_DI_ID
                                left join MethodOfPayment_DI_BAccount mptdiba on mptdiba.MethodOfPayment_DI_ID = mptdi.ID
                                left join Atom_BankAccount aba on mptdiba.Atom_BankAccount_ID = aba.ID
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
                                left join cHomePage_Org on aorgd.cHomePage_Org_ID = cHomePage_Org.ID
                                left join cEmail_Org on aorgd.cEmail_Org_ID = cEmail_Org.ID
                                left join cHomePage_Org aorgd_hp  on aorgd.cHomePage_Org_ID = cHomePage_Org.ID
                                left join cFaxNumber_Org on aorgd.cFaxNumber_Org_ID = cFaxNumber_Org.ID
                                left join cPhoneNumber_Org on aorgd.cPhoneNumber_Org_ID = cPhoneNumber_Org.ID
                                left join Atom_Logo on aorgd.Atom_Logo_ID = Atom_Logo.ID
                                left join Atom_Customer_Org acusorg on acusorg.ID = pi.Atom_Customer_Org_ID
                                left join Atom_Customer_Person acusper on acusper.ID = pi.Atom_Customer_Person_ID
                                where pi.ID = " + DocInvoice_ID.ToString();
                    }
                }
                else if (IsDocProformaInvoice)
                {
                sql = @"select
                                pi.ID as DocProformaInvoice_ID,
                                pi.FinancialYear,
                                pi.NumberInFinancialYear,
                                pi.Draft,
                                piao.IssueDate,
                                pt.Identification as PaymentType_Identification,
                                GrossSum,
                                TaxSum,
                                NetSum,
                                ao.Name,
                                ao.Tax_ID,
                                ao.Registration_ID,
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
                                abo.BankName,
                                aba.TRR,
                                aoff.Name as Atom_Office_Name,
                                aed.Name as Atom_Electronic_Device_Name,
                                apfn.FirstName as My_Organisation_Person_FirstName,
                                apln.LastName as My_Organisation_Person_LastName,
                                ap.ID as Atom_MyOrganisation_Person_ID,
                                ao.Tax_ID as My_Organisation_Tax_ID,
                                ap.CardNumber,
                                amcp.UserName as My_Organisation_Person_UserName,
                                amcp.Job as My_Organisation_Job,
                                Atom_Logo.Image_Hash as Logo_Hash,
                                Atom_Logo.Image_Data as Logo_Data,
                                Atom_Logo.Description as Logo_Description,
                                acusorg.ID as Atom_Customer_Org_ID,
                                acusper.ID as Atom_Customer_Person_ID,
                                jpi.EventTime,
                                jpit.Name as JOURNAL_DocProformaInvoice_Type_Name
                                from JOURNAL_DocProformaInvoice jpi
                                inner join JOURNAL_DocProformaInvoice_Type jpit on jpi.JOURNAL_DocProformaInvoice_Type_ID = jpit.ID and (jpit.ID = " + GlobalData.JOURNAL_DocProformaInvoice_Type_definitions.ProformaInvoiceDraftTime.ID.ToString() + @")
                                inner join DocProformaInvoice pi on jpi.DocProformaInvoice_ID = pi.ID
                                inner join Atom_WorkPeriod awp on jpi.Atom_WorkPeriod_ID = awp.ID
                                inner join Atom_ElectronicDevice aed on awp.Atom_ElectronicDevice_ID = aed.ID
                                inner join Atom_myOrganisation_Person amcp on awp.Atom_myOrganisation_Person_ID = amcp.ID
                                inner join Atom_Person ap on ap.ID = amcp.Atom_Person_ID
                                inner join Atom_Office aoff on amcp.Atom_Office_ID = aoff.ID
                                inner join Atom_Office_Data aoffd on aoffd.Atom_Office_ID = aoff.ID 
                                inner join Atom_myOrganisation amc on aoff.Atom_myOrganisation_ID = amc.ID
                                inner join Atom_OrganisationData aorgd on  amc.Atom_OrganisationData_ID = aorgd.ID
                                inner join Atom_Organisation ao on aorgd.Atom_Organisation_ID = ao.ID
                                left join DocProformaInvoiceAddOn piao on piao.DocProformaInvoice_ID = pi.ID
                                left join Atom_cFirstName apfn on ap.Atom_cFirstName_ID = apfn.ID 
                                left join Atom_cLastName apln on ap.Atom_cLastName_ID = apln.ID 
                                left join MethodOfPayment_DPI mptdpi on mptdpi.ID = piao.MethodOfPayment_DPI_ID
                                left join MethodOfPayment_DPI_BAccount mptdpiba on mptdpiba.MethodOfPayment_DPI_ID = mptdpi.ID
                                left join Atom_BankAccount aba on mptdpiba.Atom_BankAccount_ID = aba.ID
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
                                left join cHomePage_Org on aorgd.cHomePage_Org_ID = cHomePage_Org.ID
                                left join cEmail_Org on aorgd.cEmail_Org_ID = cEmail_Org.ID
                                left join cHomePage_Org aorgd_hp  on aorgd.cHomePage_Org_ID = cHomePage_Org.ID
                                left join cFaxNumber_Org on aorgd.cFaxNumber_Org_ID = cFaxNumber_Org.ID
                                left join cPhoneNumber_Org on aorgd.cPhoneNumber_Org_ID = cPhoneNumber_Org.ID
                                left join Atom_Logo on aorgd.Atom_Logo_ID = Atom_Logo.ID
                                left join Atom_Customer_Org acusorg on acusorg.ID = pi.Atom_Customer_Org_ID
                                left join Atom_Customer_Person acusper on acusper.ID = pi.Atom_Customer_Person_ID
                                where pi.ID = " + DocInvoice_ID.ToString();
            }
            else
            {
                LogFile.Error.Show("ERROR:InvoiceData:Read_DocInvoice:DocInvoice=" + DocInvoice + " not implemented.");
                return false;
            }

            string Err = null;
            dt_DocInvoice.Clear();
            dt_DocInvoice.Columns.Clear();
            if (DBSync.DBSync.ReadDataTable(ref dt_DocInvoice, sql, ref Err))
            {
                if (dt_DocInvoice.Rows.Count == 1)
                {
                    try
                    {
                        Draft = DBTypes.tf._set_bool(dt_DocInvoice.Rows[0]["Draft"]);
                        IssueDate_v = DBTypes.tf.set_DateTime(dt_DocInvoice.Rows[0]["IssueDate"]);
                        Electronic_Device_Name_v = DBTypes.tf.set_string(dt_DocInvoice.Rows[0]["Atom_Electronic_Device_Name"]);
                        if (IsDocInvoice)
                        {
                            if (!AddOnDI.Get(DocInvoice_ID))
                            {
                                return false;
                            }
                            Invoice_Storno_v = DBTypes.tf.set_bool(dt_DocInvoice.Rows[0]["Storno"]);
                            Invoice_Reference_Type_v = DBTypes.tf.set_string(dt_DocInvoice.Rows[0]["Invoice_Reference_Type"]);
                            DocInvoice_Reference_ID_v = DBTypes.tf.set_long(dt_DocInvoice.Rows[0]["Invoice_Reference_ID"]);
                        }
                        else
                        {
                            if (!AddOnDPI.Get(DocInvoice_ID))
                            {
                                return false;
                            }
                        }
                        DocInvoice_ID_v = DBTypes.tf.set_long(dt_DocInvoice.Rows[0][DocInvoice+"_ID"]);
                        DateTime_v EventTime_v = DBTypes.tf.set_DateTime(dt_DocInvoice.Rows[0]["EventTime"]);
                        string_v EventName_v = DBTypes.tf.set_string(dt_DocInvoice.Rows[0]["JOURNAL_"+DocInvoice+"_Type_Name"]);

                        if (Draft)
                        {
                            this.m_eType = eType.DRAFT_INVOICE;
                        }
                        else
                        {
                            if (DocInvoice_ID_v != null)
                            {
                                    if (IsDocInvoice)
                                    {
                                        if (EventName_v != null)
                                        {
                                            if (EventName_v.v.Equals("InvoiceTime"))
                                            {
                                                this.m_eType = eType.INVOICE;
                                            }
                                            else if (EventName_v.v.Equals("InvoiceStornoTime"))
                                            {
                                                this.m_eType = eType.STORNO;
                                                StornoIssueDate_v = EventTime_v.Clone();
                                                if (DocInvoice_Reference_ID_v != null)
                                                {
                                                    if (IssueDate_v == null)
                                                    {
                                                        sql = "select EventTime from JOURNAL_DocInvoice where DocInvoice_ID = " + DocInvoice_Reference_ID_v.v.ToString() + " and JOURNAL_DocInvoice_Type_ID = " + GlobalData.JOURNAL_DocInvoice_Type_definitions.InvoiceTime.ID.ToString();
                                                        DataTable dt = new DataTable();
                                                        if (DBSync.DBSync.ReadDataTable(ref dt, sql, ref Err))
                                                        {
                                                            if (dt.Rows.Count == 1)
                                                            {
                                                                IssueDate_v = DBTypes.tf.set_DateTime(dt.Rows[0]["EventTime"]);
                                                            }
                                                            else
                                                            {
                                                                LogFile.Error.Show("ERROR:InvoiceData:Read_DocInvoice:this error should not happen! EventTime for InvoiceTime must be defined!");
                                                            }

                                                        }
                                                        else
                                                        {
                                                            LogFile.Error.Show("ERROR:InvoiceData:Read_DocInvoice:sql=" + sql + "\r\nERR=" + Err);
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    LogFile.Error.Show("ERROR:InvoiceData:Read_DocInvoice:this error should not happen! DocInvoice_Reference_ID_v must be defined!");
                                                }
                                            }
                                            else
                                            {
                                                if (IssueDate_v == null)
                                                {

                                                    sql = "select EventTime from JOURNAL_DocInvoice where DocInvoice_ID = " + DocInvoice_ID.ToString() + " and JOURNAL_DocInvoice_Type_ID = " + GlobalData.JOURNAL_DocInvoice_Type_definitions.InvoiceTime.ID.ToString();
                                                    DataTable dt = new DataTable();
                                                    if (DBSync.DBSync.ReadDataTable(ref dt, sql, ref Err))
                                                    {
                                                        if (dt.Rows.Count > 0)
                                                        {
                                                            IssueDate_v = DBTypes.tf.set_DateTime(dt.Rows[0]["EventTime"]);
                                                            if (dt.Rows.Count != 1)
                                                            {
                                                                LogFile.Error.Show("ERROR:InvoiceData:Read_DocInvoice:this error should not happen! EventTime for InvoiceTime must be defined!");
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        LogFile.Error.Show("ERROR:InvoiceData:Read_DocInvoice:sql=" + sql + "\r\nERR=" + Err);
                                                    }
                                                }
                                                this.m_eType = eType.UNKNOWN;
                                            }

                                        }
                                        else
                                        {
                                            LogFile.Error.Show("ERROR:InvoiceData:Read_DocInvoice:this error should not happen! EventName must be defined!");
                                        }
                                    }
                                    else if (IsDocProformaInvoice)
                                    {
                                        if (EventName_v != null)
                                        {
                                            if (EventName_v.v.Equals("ProformaInvoiceTime"))
                                            {
                                                this.m_eType = eType.INVOICE;
                                                this.IssueDate_v = EventTime_v.Clone();
                                            }
                                            else
                                            {
                                                if (IssueDate_v == null)
                                                {

                                                    sql = "select EventTime from JOURNAL_DocProformaInvoice where DocProformaInvoice_ID = " + DocInvoice_ID.ToString() + " and JOURNAL_DocProformaInvoice_Type_ID = " + GlobalData.JOURNAL_DocProformaInvoice_Type_definitions.ProformaInvoiceTime.ID.ToString();
                                                    DataTable dt = new DataTable();
                                                    if (DBSync.DBSync.ReadDataTable(ref dt, sql, ref Err))
                                                    {
                                                        if (dt.Rows.Count == 1)
                                                        {
                                                            IssueDate_v = DBTypes.tf.set_DateTime(dt.Rows[0]["EventTime"]);
                                                        }
                                                        else
                                                        {
                                                            LogFile.Error.Show("ERROR:InvoiceData:Read_DocInvoice:this error should not happen! EventTime for InvoiceTime must be defined!");
                                                        }

                                                    }
                                                    else
                                                    {
                                                        LogFile.Error.Show("ERROR:InvoiceData:Read_DocInvoice:sql=" + sql + "\r\nERR=" + Err);
                                                    }
                                                }

                                                this.m_eType = eType.UNKNOWN;
                                            }

                                        }
                                        else
                                        {
                                            LogFile.Error.Show("ERROR:InvoiceData:Read_DocInvoice:this error should not happen! EventName must be defined!");
                                        }
                                    }
                                    else
                                    {
                                        LogFile.Error.Show("ERROR:InvoiceData:Read_DocInvoice:DocInvoice="+DocInvoice+" not implemented.");
                                    }
                                }
                            else
                            {
                                this.m_eType = eType.UNKNOWN;
                            }
                        }

                        if (IsDocInvoice)
                        {
                            if (Invoice_Reference_Type_v != null)
                            {
                                if (Invoice_Reference_Type_v.v.Equals("STORNO"))
                                {
                                    if (DocInvoice_Reference_ID_v != null)
                                    {
                                        bInvoiceStorno = true;
                                    }
                                    else
                                    {
                                        LogFile.Error.Show("ERROR:usrc_Invoice_Preview:Read_DocProformaInvoice:DocProformaInvoice_Reference_ID_v can not be null when Invoice_Reference_Type_v equals 'STORNO'");
                                    }
                                }
                            }
                        }


                        GrossSum = DBTypes.tf._set_decimal(dt_DocInvoice.Rows[0]["GrossSum"]);
                        taxsum = DBTypes.tf._set_decimal(dt_DocInvoice.Rows[0]["TaxSum"]);
                        NetSum = DBTypes.tf._set_decimal(dt_DocInvoice.Rows[0]["NetSum"]);

                        if (IsDocInvoice)
                        {
                            if (bInvoiceStorno)
                            {
                                if (GrossSum > 0) GrossSum = GrossSum * -1;
                                if (taxsum > 0) taxsum = taxsum * -1;
                                if (NetSum > 0) NetSum = NetSum * -1;
                            }
                            if (AddOnDI.b_FVI_SLO)
                            {

                                //this.FVI_SLO_RealEstateBP = new UniversalInvoice.FVI_SLO_RealEstateBP(lngToken.st_Invoice,
                                //                                                                             DBTypes.tf._set_int(dt_DocProformaInvoice.Rows[0]["BuildingNumber"]),
                                //                                                                             DBTypes.tf._set_int(dt_DocProformaInvoice.Rows[0]["BuildingSectionNumber"]),
                                //                                                                             DBTypes.tf._set_string(dt_DocProformaInvoice.Rows[0]["Community"]),
                                //                                                                             DBTypes.tf._set_int(dt_DocProformaInvoice.Rows[0]["CadastralNumber"]),
                                //                                                                             DBTypes.tf._set_DateTime(dt_DocProformaInvoice.Rows[0]["ValidityDate"]),
                                //                                                                             DBTypes.tf._set_string(dt_DocProformaInvoice.Rows[0]["ClosingTag"]),
                                //                                                                             DBTypes.tf._set_string(dt_DocProformaInvoice.Rows[0]["SoftwareSupplier_TaxNumber"]),
                                //                                                                             DBTypes.tf._set_string(dt_DocProformaInvoice.Rows[0]["PremiseType"])   );
                            }

                        }

                        //byte[] barr_logoData = (byte[])dt_DocProformaInvoice.Rows[0]["Logo_Data"];
                        MyOrganisation = new UniversalInvoice.Organisation(lngToken.st_My, DBTypes.tf._set_string(dt_DocInvoice.Rows[0]["Name"]),
                                                                   DBTypes.tf._set_string(dt_DocInvoice.Rows[0]["Tax_ID"]),
                                                                   DBTypes.tf._set_string(dt_DocInvoice.Rows[0]["Registration_ID"]),
                                                                   DBTypes.tf._set_string(dt_DocInvoice.Rows[0]["Atom_Office_Name"]),
                                                                   DBTypes.tf._set_string(dt_DocInvoice.Rows[0]["BankName"]),
                                                                   DBTypes.tf._set_string(dt_DocInvoice.Rows[0]["TRR"]),
                                                                   DBTypes.tf._set_string(dt_DocInvoice.Rows[0]["Email"]),
                                                                   DBTypes.tf._set_string(dt_DocInvoice.Rows[0]["HomePage"]),
                                                                   DBTypes.tf._set_string(dt_DocInvoice.Rows[0]["PhoneNumber"]),
                                                                   DBTypes.tf._set_string(dt_DocInvoice.Rows[0]["FaxNumber"]),
                                                                   DBTypes.tf._set_byte_array(dt_DocInvoice.Rows[0]["Logo_Data"]),
                                                                   DBTypes.tf._set_string(dt_DocInvoice.Rows[0]["StreetName"]),
                                                                   DBTypes.tf._set_string(dt_DocInvoice.Rows[0]["HouseNumber"]),
                                                                   DBTypes.tf._set_string(dt_DocInvoice.Rows[0]["ZIP"]),
                                                                   DBTypes.tf._set_string(dt_DocInvoice.Rows[0]["City"]),
                                                                   DBTypes.tf._set_string(dt_DocInvoice.Rows[0]["Country"]),
                                                                   DBTypes.tf._set_string(dt_DocInvoice.Rows[0]["State"]));


                        FinancialYear = DBTypes.tf._set_int(dt_DocInvoice.Rows[0]["FinancialYear"]);
                        NumberInFinancialYear = DBTypes.tf._set_int(dt_DocInvoice.Rows[0]["NumberInFinancialYear"]);

                        sFiscalVerificationOfInvoicesNotDone = lngRPM.s_FVI_not_done.s;
                        if (IsDocInvoice)
                        {
                            if (AddOnDI.b_FVI_SLO)
                            {

                                if (!Draft)
                                {

                                    if (AddOnDI.m_MethodOfPayment_DI == null)
                                    {
                                        AddOnDI.m_MethodOfPayment_DI = new DocInvoice_AddOn.MethodOfPayment_DI();
                                    }
                                    if (AddOnDI.m_IssueDate==null)
                                    {
                                        AddOnDI.m_IssueDate = new DocInvoice_AddOn.IssueDate();
                                    }
                                    AddOnDI.m_FURS.FURS_ZOI_v = DBTypes.tf.set_string(dt_DocInvoice.Rows[0]["JOURNAL_DocInvoice_$_dinv_$_fvisres_$$MessageID"]);
                                    AddOnDI.m_FURS.FURS_EOR_v = DBTypes.tf.set_string(dt_DocInvoice.Rows[0]["JOURNAL_DocInvoice_$_dinv_$_fvisres_$$UniqueInvoiceID"]);
                                    AddOnDI.m_FURS.FURS_QR_v = DBTypes.tf.set_string(dt_DocInvoice.Rows[0]["JOURNAL_DocInvoice_$_dinv_$_fvisres_$$BarCodeValue"]);
                                    AddOnDI.m_FURS.FURS_TestEnvironment_v = DBTypes.tf.set_bool(dt_DocInvoice.Rows[0]["JOURNAL_DocInvoice_$_dinv_$_fvisres_$$TestEnvironment"]);
                                    AddOnDI.m_FURS.FURS_SalesBookInvoice_InvoiceNumber_v = DBTypes.tf.set_string(dt_DocInvoice.Rows[0]["JOURNAL_DocInvoice_$_dinv_$_fvisbi_$$InvoiceNumber"]);
                                    AddOnDI.m_FURS.FURS_SalesBookInvoice_SetNumber_v = DBTypes.tf.set_string(dt_DocInvoice.Rows[0]["JOURNAL_DocInvoice_$_dinv_$_fvisbi_$$SetNumber"]);
                                    AddOnDI.m_FURS.FURS_SalesBookInvoice_SerialNumber = DBTypes.tf.set_string(dt_DocInvoice.Rows[0]["JOURNAL_DocInvoice_$_dinv_$_fvisbi_$$SerialNumber"]);
                                    if (AddOnDI.m_FURS.Invoice_FURS_Token==null)
                                    {
                                        AddOnDI.m_FURS.Invoice_FURS_Token = new UniversalInvoice.Invoice_FURS_Token();
                                    }

                                    if (AddOnDI.m_FURS.FURS_ZOI_v != null)
                                    {
                                        sFiscalVerification_ZOI = AddOnDI.m_FURS.FURS_ZOI_v.v;
                                        if (AddOnDI.m_FURS.FURS_TestEnvironment_v!=null)
                                        {
                                            if (AddOnDI.m_FURS.FURS_TestEnvironment_v.v)
                                            {
                                                sFiscalVerification_ZOI = AddOnDI.m_FURS.FURS_ZOI_v.v + " "+lngRPM.s_Furs_Test_Environment.s+"!";
                                            }
                                        }
                                        
                                        AddOnDI.m_FURS.Invoice_FURS_Token.tUniqueMessageID.Set(sFiscalVerification_ZOI);
                                    }
                                    else
                                    {
                                        AddOnDI.m_FURS.Invoice_FURS_Token.tUniqueMessageID.Set(sFiscalVerificationOfInvoicesNotDone);
                                    }

                                    if (AddOnDI.m_FURS.FURS_EOR_v != null)
                                    {
                                        sFiscalVerification_EOR = AddOnDI.m_FURS.FURS_EOR_v.v;
                                        if (AddOnDI.m_FURS.FURS_TestEnvironment_v != null)
                                        {
                                            if (AddOnDI.m_FURS.FURS_TestEnvironment_v.v)
                                            {
                                                sFiscalVerification_EOR = AddOnDI.m_FURS.FURS_EOR_v.v + " " + lngRPM.s_Furs_Test_Environment.s + "!";
                                            }
                                        }
                                        AddOnDI.m_FURS.Invoice_FURS_Token.tUniqueInvoiceID.Set(sFiscalVerification_EOR);
                                    }
                                    else
                                    {
                                        AddOnDI.m_FURS.Invoice_FURS_Token.tUniqueInvoiceID.Set(sFiscalVerificationOfInvoicesNotDone);
                                    }

                                    if (AddOnDI.m_FURS.FURS_QR_v != null)
                                    {
                                        AddOnDI.m_FURS.Invoice_FURS_Token.tQR.Set(AddOnDI.m_FURS.FURS_QR_v.v);
                                    }
                                }
                            }
                        }

                        object oAtom_MyOrganisation_Person_ID = dt_DocInvoice.Rows[0]["Atom_MyOrganisation_Person_ID"];
                        if (oAtom_MyOrganisation_Person_ID is long)
                        {
                            long Atom_MyOrganisation_Person_ID = (long)oAtom_MyOrganisation_Person_ID;
                            Invoice_Author = f_Atom_Person.GetData(lngToken.st_IssuerOfInvoice, Atom_MyOrganisation_Person_ID);
                        }

                        object oAtom_Customer_Org_ID = dt_DocInvoice.Rows[0]["Atom_Customer_Org_ID"];
                        if (oAtom_Customer_Org_ID is long)
                        {
                            long Atom_Customer_Org_ID = (long)oAtom_Customer_Org_ID;
                            CustomerOrganisation = f_Atom_Customer_Org.GetData(lngToken.st_Customer, Atom_Customer_Org_ID);
                        }
                        else
                        {
                            CustomerOrganisation = new UniversalInvoice.Organisation(lngToken.st_Customer);
                        }


                        if (dt_DocInvoice.Rows[0]["Atom_Customer_Person_ID"] is long)
                        {
                            long Atom_Customer_Person_ID = (long)dt_DocInvoice.Rows[0]["Atom_Customer_Person_ID"];
                            CustomerPerson = f_Atom_Customer_Person.GetData(lngToken.st_Customer, Atom_Customer_Person_ID);
                        }
                        else
                        {
                            CustomerPerson = new UniversalInvoice.Person(lngToken.st_Customer);
                        }

                        long xDoc_ID = DocInvoice_ID;
                        if (IsDocInvoice)
                        {
                            if (DocInvoice_Reference_ID_v != null)
                            {
                                xDoc_ID = DocInvoice_Reference_ID_v.v;
                            }
                        }

                        if (dbfunc.Read_ShopA_Price_Item_Table(DocInvoice,xDoc_ID, ref dt_ShopA_Items))
                        {
                            if (m_ShopABC.Read_ShopB_Price_Item_Table(xDoc_ID, ref dt_ShopB_Items))
                            {
                                List<object> xDocProformaInvoice_ShopC_Item_Data_LIST = new List<object>();
                                if (this.m_eType == eType.STORNO)
                                {
                                    if (!m_ShopABC.m_CurrentInvoice.m_Basket.Read_ShopC_Price_Item_Stock_Table(DocInvoice,xDoc_ID, ref xDocProformaInvoice_ShopC_Item_Data_LIST))
                                    {
                                        return false;
                                    }
                                }
                                else
                                {
                                    xDocProformaInvoice_ShopC_Item_Data_LIST = m_ShopABC.m_CurrentInvoice.m_Basket.m_DocInvoice_ShopC_Item_Data_LIST;
                                }


                                int iCountShopAItemsSold = dt_ShopA_Items.Rows.Count;
                                int iCountShopBItemsSold = dt_ShopB_Items.Rows.Count;

                                int iCountShopCItemsSold = xDocProformaInvoice_ShopC_Item_Data_LIST.Count;

                                ItemsSold = new UniversalInvoice.ItemSold[iCountShopAItemsSold + iCountShopBItemsSold + iCountShopCItemsSold];
                                taxSum = new StaticLib.TaxSum();


                                if (IsDocInvoice)
                                {
                                    Fill_Sold_ShopA_ItemsData(lngToken.st_Invoice, ref ItemsSold, 0, iCountShopAItemsSold, bInvoiceStorno);
                                    Fill_Sold_ShopB_ItemsData(lngToken.st_Invoice, ref ItemsSold, iCountShopAItemsSold, iCountShopBItemsSold, bInvoiceStorno);
                                    Fill_Sold_ShopC_ItemsData(xDocProformaInvoice_ShopC_Item_Data_LIST, lngToken.st_Invoice, ref ItemsSold, iCountShopAItemsSold + iCountShopBItemsSold, iCountShopCItemsSold, bInvoiceStorno);
                                }
                                GeneralToken = new UniversalInvoice.GeneralToken();
                                InvoiceToken = new UniversalInvoice.InvoiceToken();

                                InvoiceToken.tFiscalYear.Set(FinancialYear.ToString());
                                InvoiceToken.tInvoiceNumber.Set(NumberInFinancialYear.ToString());
                                InvoiceToken.tCashier.Set(Electronic_Device_Name_v.v);

                                InvoiceToken.tStorno.Set("");
                                if (IsDocInvoice)
                                {
                                    if (bInvoiceStorno)
                                    {
                                        InvoiceToken.tStorno.Set(lngRPM.s_STORNO.s);
                                    }
                                }

                                if (!Draft)
                                {
                                    string stime = IssueDate_v.v.Day.ToString() + "."
                                                    + IssueDate_v.v.Month.ToString() + "."
                                                    + IssueDate_v.v.Year.ToString() + " "
                                                    + IssueDate_v.v.Hour.ToString() + ":"
                                                    + IssueDate_v.v.Minute.ToString();
                                    InvoiceToken.tDateOfIssue.Set(stime);
                                    InvoiceToken.tDateOfMaturity.Set(stime);
                                }
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                        else
                        {
                            return false;
                        }
                    }
                    catch (Exception ex)
                    {
                        LogFile.Error.Show("ERROR:usrc_Invoice_Preview:Read_DocProformaInvoice:Exception=" + ex.Message);
                        return false;
                    }
                }
                else
                {
                    if (dt_DocInvoice.Rows.Count == 0)
                    {
                        //no invoices or ProformaInvoices
                        LogFile.Error.Show("ERROR:usrc_Invoice_Preview:Read_DocProformaInvoice:dt_DocProformaInvoice.Rows.Count == 0  for DocProformaInvoice_ID=" + DocInvoice_ID.ToString() + "!\r\nsql = " + sql);
                        return false;
                    }
                    else
                    {
                        //more than one invoice or ProformaInvoice
                        LogFile.Error.Show("ERROR:usrc_Invoice_Preview:Read_DocProformaInvoice:dt_DocProformaInvoice.Rows.Count != 1! for DocProformaInvoice_ID=" + DocInvoice_ID.ToString() + "!\r\nsql = " + sql);
                        return false;
                    }
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:usrc_Invoice_Preview:Read_DocProformaInvoice:Err=" + Err);
                return false;
            }
        }

        public string GetAllTokens()
        {
            string s = "";

            foreach (UniversalInvoice.TemplateToken tt in this.GeneralToken.list)
            {
                s += "\r\n" + tt.lt.s;
            }

            foreach (UniversalInvoice.TemplateToken tt in this.InvoiceToken.list)
            {
                s += "\r\n" + tt.lt.s;
            }

            if (IsDocInvoice)
            {
                if (AddOnDI.m_FURS.Invoice_FURS_Token != null)
                {
                    foreach (UniversalInvoice.TemplateToken tt in AddOnDI.m_FURS.Invoice_FURS_Token.list)
                    {
                        s += "\r\n" + tt.lt.s;
                    }
                }
            }


            if (ItemsSold.Count() > 0)
            {
                foreach (UniversalInvoice.TemplateToken tt in this.ItemsSold[0].token.list)
                {
                    s += "\r\n" + tt.lt.s;
                }
            }

            if (IsDocInvoice)
            {
                if (AddOnDI.m_FURS.FVI_SLO_RealEstateBP != null)
                {
                    foreach (UniversalInvoice.TemplateToken tt in AddOnDI.m_FURS.FVI_SLO_RealEstateBP.token.list)
                    {
                        s += "\r\n" + tt.lt.s;
                    }
                }
            }


            foreach (UniversalInvoice.TemplateToken tt in this.MyOrganisation.token.list)
            {
                s += "\r\n" + tt.lt.s;
            }



            foreach (UniversalInvoice.TemplateToken tt in this.MyOrganisation.Address.token.list)
            {
                s += "\r\n" + tt.lt.s;
            }

            if (this.Invoice_Author != null)
            {
                foreach (UniversalInvoice.TemplateToken tt in this.Invoice_Author.token.list)
                {
                    s += "\r\n" + tt.lt.s;
                }
            }

            UniversalInvoice.Organisation xCustomerOrganisation = new UniversalInvoice.Organisation(lngToken.st_Customer,
                                                       null,
                                                       null,
                                                       null,
                                                       null,
                                                       null,
                                                       null,
                                                       null,
                                                       null,
                                                       null,
                                                       null,
                                                       null,
                                                       null,
                                                       null,
                                                       null,
                                                       null,
                                                       null,
                                                       null);

            foreach (UniversalInvoice.TemplateToken tt in xCustomerOrganisation.token.list)
            {
                s += "\r\n" + tt.lt.s;
            }
            foreach (UniversalInvoice.TemplateToken tt in xCustomerOrganisation.Address.token.list)
            {
                s += "\r\n" + tt.lt.s;
            }

            UniversalInvoice.Person xCustomerPerson = new UniversalInvoice.Person(lngToken.st_Customer, false,
                                                       null,
                                                       null,
                                                       DateTime.MinValue,
                                                       null,
                                                       null,
                                                       null,
                                                       null,
                                                       null,
                                                       null,
                                                       null,
                                                       null,
                                                       null,
                                                       null,
                                                       null,
                                                       null,
                                                       null,
                                                       null);
            foreach (UniversalInvoice.TemplateToken tt in xCustomerPerson.token.list)
            {
                s += "\r\n" + tt.lt.s;
            }
            foreach (UniversalInvoice.TemplateToken tt in xCustomerPerson.Address.token.list)
            {
                s += "\r\n" + tt.lt.s;
            }

            return s;
        }




        private void GetFursDecimalString(decimal grossSum)
        {
            throw new NotImplementedException();
        }


        public string CreateHTML_PrintingElementList(ref string html_doc_template, ref HTML_PrintingElement_List PrintingElement_List)
        {
            if (PrintingElement_List == null)
            {
                PrintingElement_List = new HTML_PrintingElement_List();
            }

            string stime = IssueDate_v.v.Day.ToString() + "."
                                           + IssueDate_v.v.Month.ToString() + "."
                                           + IssueDate_v.v.Year.ToString() + " "
                                           + IssueDate_v.v.Hour.ToString() + ":"
                                           + IssueDate_v.v.Minute.ToString();
            InvoiceToken.tDateOfIssue.Set(stime);
            InvoiceToken.tDateOfMaturity.Set(stime);

            sMethodOfPayment = "";
            if (IsDocInvoice)
            {
                sMethodOfPayment = this.AddOnDI.m_MethodOfPayment_DI.PaymentType;
                sBankAccount = this.AddOnDI.m_MethodOfPayment_DI.BankAccount;
                sBankName = this.AddOnDI.m_MethodOfPayment_DI.BankName;

            }
            else if (IsDocProformaInvoice)
            {
                sMethodOfPayment = this.AddOnDPI.m_MethodOfPayment_DPI.PaymentType;
                sBankAccount = this.AddOnDPI.m_MethodOfPayment_DPI.BankAccount;
                sBankName = this.AddOnDPI.m_MethodOfPayment_DPI.BankName;
            }
            if (sBankAccount!=null)
            {
                sBankAccount = lngRPM.s_PaymentOnBankAccount.s + ": " + sBankAccount;
            }
            else
            {
                sBankAccount = "";
            }

            if (sBankName != null)
            {
                sBankName = lngRPM.s_Bank.s + ": " + sBankName;
            }
            else
            {
                sBankName = "";
            }

            InvoiceToken.tPaymentType.Set(sMethodOfPayment);
            InvoiceToken.tPaymentToBankAccount.Set(sBankAccount);
            InvoiceToken.tPaymentToBankName.Set(sBankName);

            html_doc_template = InvoiceToken.tPaymentType.Replace(html_doc_template);
            html_doc_template = InvoiceToken.tPaymentToBankAccount.Replace(html_doc_template);
            html_doc_template = InvoiceToken.tPaymentToBankName.Replace(html_doc_template);
            html_doc_template = InvoiceToken.tStorno.Replace(html_doc_template);
            html_doc_template = InvoiceToken.tFiscalYear.Replace(html_doc_template);
            html_doc_template = InvoiceToken.tInvoiceNumber.Replace(html_doc_template);
            html_doc_template = InvoiceToken.tIssuerOfInvoice.Replace(html_doc_template);
            html_doc_template = InvoiceToken.tCashier.Replace(html_doc_template);
            html_doc_template = Invoice_Author.token.tFirstName.Replace(html_doc_template);
            html_doc_template = Invoice_Author.token.tLastName.Replace(html_doc_template);
            html_doc_template = Invoice_Author.token.tTaxID.Replace(html_doc_template);

            if (CustomerOrganisation != null)
            {
                foreach (UniversalInvoice.TemplateToken tt in CustomerOrganisation.token.list)
                {
                    html_doc_template = tt.Replace(html_doc_template);
                }

                foreach (UniversalInvoice.TemplateToken tt in CustomerOrganisation.Address.token.list)
                {
                    html_doc_template = tt.Replace(html_doc_template);
                }
            }
            if (CustomerPerson != null)
            {
                foreach (UniversalInvoice.TemplateToken tt in CustomerPerson.token.list)
                {
                    html_doc_template = tt.Replace(html_doc_template);
                }

                foreach (UniversalInvoice.TemplateToken tt in CustomerPerson.Address.token.list)
                {
                    html_doc_template = tt.Replace(html_doc_template);
                }
            }


            foreach (UniversalInvoice.TemplateToken ivt in MyOrganisation.token.list)
            {
                if (ivt.replacement != null)
                {
                    html_doc_template = ivt.Replace(html_doc_template);
                }
                else
                {
                    html_doc_template = ivt.Replace(html_doc_template);
                }
            }

            foreach (UniversalInvoice.TemplateToken ivt in MyOrganisation.Address.token.list)
            {
                if (ivt.replacement != null)
                {
                    html_doc_template = ivt.Replace(html_doc_template);
                }
                else
                {
                    html_doc_template = ivt.Replace(html_doc_template);
                }
            }

            html_doc_template = InvoiceToken.tDateOfIssue.Replace(html_doc_template);
            html_doc_template = InvoiceToken.tDateOfMaturity.Replace(html_doc_template);

            if (AddOnDI.b_FVI_SLO)
            {
                html_doc_template = AddOnDI.m_FURS.Invoice_FURS_Token.tUniqueMessageID.Replace(html_doc_template);
                html_doc_template = AddOnDI.m_FURS.Invoice_FURS_Token.tUniqueInvoiceID.Replace(html_doc_template);
                html_doc_template = AddOnDI.m_FURS.Invoice_FURS_Token.tQR.Replace(html_doc_template);
            }

            int start_index = 0;
            int iStartIndexOf_style = -1;
            int iEndIndexOf_style = -1;

            if (GetHtmlElementByTagName(html_doc_template, start_index, ref iStartIndexOf_style, ref iEndIndexOf_style, "style"))
            {
                PrintingElement_List.style = new HTML_PrintingElement();
                PrintingElement_List.style.html = html_doc_template.Substring(iStartIndexOf_style, iEndIndexOf_style - iStartIndexOf_style + 1);
            }
            else
            {
                return "ERROR:<style> not found !";
            }


            int iStartIndexOfPageNumbers = -1;
            int iEndIndexOfPageNumbers = -1;
            if (GetHtmlElementByTagNameAndClassName(html_doc_template, iEndIndexOf_style, ref iStartIndexOfPageNumbers, ref iEndIndexOfPageNumbers, "div", "pagenumbers"))
            {
                PrintingElement_List.pagenumber = new HTML_PrintingElement();
                PrintingElement_List.pagenumber.html = html_doc_template.Substring(iStartIndexOfPageNumbers, iEndIndexOfPageNumbers - iStartIndexOfPageNumbers+1);
            }

            int iStartIndexOfInvoiceTop = -1;
            int iEndIndexOfInvoiceTop = -1;

            if (GetHtmlElementByTagNameAndClassName(html_doc_template, start_index, ref iStartIndexOfInvoiceTop, ref iEndIndexOfInvoiceTop, "div", "invoicetop"))
            {
                PrintingElement_List.doctop = new HTML_PrintingElement();
                PrintingElement_List.doctop.html = html_doc_template.Substring(iStartIndexOfInvoiceTop, iEndIndexOfInvoiceTop - iStartIndexOfInvoiceTop + 1);
            }
            else
            {
                return "ERROR:<div class=\"invoicetop\"> not found !";
            }


            int iStartIndexOftable = -1;
            int iEndIndexOftable = -1;

            if (GetHtmlElementByTagNameAndClassName(html_doc_template, start_index, ref iStartIndexOftable, ref iEndIndexOftable, "table", "tableitems"))
            {
                int iStartIndexOf_Thead = -1;
                int iEndIndexOf_Thead = -1;
                if  (GetHtmlElementByTagName(html_doc_template, iStartIndexOftable,ref iStartIndexOf_Thead, ref iEndIndexOf_Thead,"thead"))
                {
                    PrintingElement_List.tableitems = new HTML_PrintingElement();
                    PrintingElement_List.tableitems.html = html_doc_template.Substring(iStartIndexOftable, iEndIndexOf_Thead - iStartIndexOftable + 1);
                }
                else
                {
                    return "ERROR:<thead> not found for <table class = \"tableitems\">!";
                }
                int iStartIndexOf_tr = -1;
                int iEndIndexOf_tr = -1;
                int ipos = 0;
                string HtmlTable_TableItems = html_doc_template.Substring(iStartIndexOftable, iEndIndexOftable - iStartIndexOftable + 1);
                if (GetHtmlElementByTagNameAndClassName(html_doc_template, iStartIndexOftable, ref iStartIndexOf_tr, ref iEndIndexOf_tr, "tr", "item"))
                {
                    string tr_RowTemplate = html_doc_template.Substring(iStartIndexOf_tr, iEndIndexOf_tr - iStartIndexOf_tr + 1);

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
                        string sRow = itms.token.tItemName.Replace(tr_RowTemplate);
                        sRow = itms.token.tPricePerUnit.Replace(sRow);
                        sRow = itms.token.tTotalDiscount.Replace(sRow);
                        sRow = itms.token.tCurrency.Replace(sRow);
                        sRow = itms.token.tUnit.Replace(sRow);
                        sRow = itms.token.tQuantity.Replace(sRow);
                        sRow = itms.token.tTaxationRatePercent.Replace(sRow);
                        sRow = itms.token.tNetPrice.Replace(sRow);
                        sRow = itms.token.tTax.Replace(sRow);
                        sRow = itms.token.tPriceWithTax.Replace(sRow);
                        html_doc_template = html_doc_template.Insert(ipos, sRow);
                        if (PrintingElement_List.items == null)
                        {
                            PrintingElement_List.items = new List<HTML_PrintingElement>();
                        }
                        HTML_PrintingElement html_item = new HTML_PrintingElement();
                        html_item.html = sRow;
                        PrintingElement_List.items.Add(html_item);
                        ipos += sRow.Length;
                    }


                    html_doc_template = tCurrency.Replace(html_doc_template);

                    InvoiceToken.tSumNetPrice.Set(NetSum.ToString());
                    html_doc_template = InvoiceToken.tSumNetPrice.Replace(html_doc_template);


                    //string s_journal_invoice_type = lngRPM.s_journal_invoice_type_Print.s;
                    //string s_journal_invoice_description = Program.ReceiptPrinter.PrinterName;
                    //long journal_docinvoice_id = -1;
                    //f_Journal_DocProformaInvoice.Write(m_usrc_Print.DocProformaInvoice_ID, Program.Atom_WorkPeriod_ID, s_journal_invoice_type, s_journal_invoice_description, null, ref journal_docinvoice_id);
                    int iStartIndexOf_NetSum = -1;
                    int iEndIndexOf_NetSum = -1;
                    if (GetHtmlElementByTagNameAndClassName(html_doc_template, ipos, ref iStartIndexOf_NetSum, ref iEndIndexOf_NetSum, "tr", "totalneto"))
                    {
                        if (PrintingElement_List.totalneto == null)
                        {
                            PrintingElement_List.totalneto = new HTML_PrintingElement();
                        }
                        PrintingElement_List.totalneto.html = html_doc_template.Substring(iStartIndexOf_NetSum, iEndIndexOf_NetSum - iStartIndexOf_NetSum + 1);
                    }
                    else
                    {
                        return "ERROR:<tr class=\"totalneto\"> not found !";
                    }



                    int itr_taxsum_start = html_doc_template.IndexOf("<tr class=\"taxsum\">", 0);
                    if (itr_taxsum_start > 0)
                    {
                        int itr_taxsum_end = html_doc_template.IndexOf("</tr>", itr_taxsum_start);
                        if (itr_taxsum_end > 0)
                        {
                            string tr_TaxSum = html_doc_template.Substring(itr_taxsum_start, itr_taxsum_end - itr_taxsum_start + 5);
                            html_doc_template = html_doc_template.Remove(itr_taxsum_start, itr_taxsum_end - itr_taxsum_start + 5);
                            ipos = itr_taxsum_start;
                            foreach (StaticLib.Tax tax in taxSum.TaxList)
                            {
                                InvoiceToken.tTaxRateName.Set(tax.Name);
                                InvoiceToken.tSumTax.Set(tax.TaxAmount.ToString());
                                string str = InvoiceToken.tTaxRateName.Replace(tr_TaxSum);
                                str = InvoiceToken.tSumTax.Replace(str);
                                html_doc_template = html_doc_template.Insert(ipos, str);
                                if (PrintingElement_List.taxsum==null)
                                {
                                    PrintingElement_List.taxsum = new List<HTML_PrintingElement>();
                                }
                                HTML_PrintingElement html_taxsum = new HTML_PrintingElement();
                                html_taxsum.html = str;
                                PrintingElement_List.taxsum.Add(html_taxsum);
                                ipos += str.Length;
                            }
                            InvoiceToken.tTotalSum.Set(GrossSum.ToString());
                            html_doc_template = InvoiceToken.tTotalSum.Replace(html_doc_template);

                            int iStartIndexOf_GrossSum = -1;
                            int iEndIndexOf_GrossSum = -1;
                            if (GetHtmlElementByTagNameAndClassName(html_doc_template, ipos, ref iStartIndexOf_GrossSum, ref iEndIndexOf_GrossSum, "tr", "grandtotal"))
                            {
                                if (PrintingElement_List.grandtotal == null)
                                {
                                    PrintingElement_List.grandtotal = new HTML_PrintingElement();
                                }
                                PrintingElement_List.grandtotal.html = html_doc_template.Substring(iStartIndexOf_GrossSum, iEndIndexOf_GrossSum - iStartIndexOf_GrossSum + 1);
                            }
                            else
                            {
                                return "ERROR:<tr class=\"grandtotal\"> not found !";
                            }
                            html_doc_template = this.AddOnDI.m_FURS.Invoice_FURS_Token.tUniqueInvoiceID.Replace(html_doc_template);
                            html_doc_template = this.AddOnDI.m_FURS.Invoice_FURS_Token.tUniqueMessageID.Replace(html_doc_template);
                            html_doc_template = this.AddOnDI.m_FURS.Invoice_FURS_Token.tQR.Replace(html_doc_template);

                            int iStartIndexOf_InvoiceBottom = -1;
                            int iEndIndexOf_InvoiceBottom = -1;
                            if (GetHtmlElementByTagNameAndClassName(html_doc_template, ipos, ref iStartIndexOf_InvoiceBottom, ref iEndIndexOf_InvoiceBottom, "div", "invoicebottom"))
                            {
                                if (PrintingElement_List.docbottom == null)
                                {
                                    PrintingElement_List.docbottom = new HTML_PrintingElement();
                                }
                                PrintingElement_List.docbottom.html = html_doc_template.Substring(iStartIndexOf_InvoiceBottom, iEndIndexOf_InvoiceBottom - iStartIndexOf_InvoiceBottom + 1);
                            }
                            else
                            {
                                return "ERROR:<div class=\"invoicebottom\"> not found !";
                            }
                            return html_doc_template;
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
                    return "ERROR:<tr class=\"row\"> not found !";
                }
            }
            else
            {
                return "ERROR:<table class=\"tableitems\"> not found !";
            }
        }

        public bool GetStartTag(string html, int start_index, ref int index_of_start_tag, ref int index_of_end_tag, string htmltagname)
        {
            index_of_start_tag = html.IndexOf("<" + htmltagname, start_index);
            if (index_of_start_tag >= 0)
            {
                index_of_end_tag = html.IndexOf(">", index_of_start_tag+1);
                if (index_of_end_tag >= 0)
                {
                    return true;
                }
                else
                {
                    LogFile.Error.Show("ERROR:TangentaDB:InvoiceDate:GetElementStartTag:HTML syntax error: End of html tag not found!");
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public bool GetEndTag(string html, int start_index, ref int index_of_start_endtag, ref int index_of_end_endtag, string htmltagname)
        {
            index_of_start_endtag = html.IndexOf("</" + htmltagname, start_index);
            if (index_of_start_endtag > 0)
            {
                index_of_end_endtag = html.IndexOf(">", index_of_start_endtag);
                if (index_of_end_endtag > 0)
                {
                    return true;
                }
                else
                {
                    LogFile.Error.Show("ERROR:TangentaDB:InvoiceDate:GetElementEndTag:HTML syntax error: End of html tag not found!");
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public bool HtmlTagContainsClassName(string html,int index_of_start_tag, int index_of_end_tag,string class_name)
        {
            string stag = html.Substring(index_of_start_tag, index_of_end_tag - index_of_start_tag);
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
                        LogFile.Error.Show("WARNING:TangentaDB:InvoiceDate:GetElementStartByClass:HTML syntax error: No \" at the end of class attribute!");
                        return false;
                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:TangentaDB:InvoiceDate:GetElementStartByClass:HTML syntax error: No \" after class attribute!");
                    return false;
                }
            }
            return false;
        }

        public bool GetHtmlElementStartIndexByTagNameAndClassName(string html,int start_index, ref int IndexOfElement, string htmltagname, string class_name)
        {
            int index_of_start_tag = 0;
            while (index_of_start_tag >= 0)
            {
                int index_of_end_tag = -1;
                if (GetStartTag(html, start_index, ref index_of_start_tag, ref index_of_end_tag, htmltagname))
                {
                    if (HtmlTagContainsClassName(html, index_of_start_tag, index_of_end_tag, class_name))
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

        public bool GetHtmlElementStartIndexByTagName(string html, int start_index, ref int IndexOfElement, string htmltagname)
        {
            int index_of_start_tag = 0;
            int index_of_end_tag = -1;
            if (GetStartTag(html, start_index, ref index_of_start_tag, ref index_of_end_tag, htmltagname))
            {
                    IndexOfElement = index_of_start_tag;
                    return true;
            }
            else
            {
                return false;
            }
        }



        public bool GetHtmlElementByTagNameAndClassName(string html, int start_index, ref int StartIndexOfElementInString, ref int EndIndexOfElementInString, string htmltagname, string class_name)
        {
            if (GetHtmlElementStartIndexByTagNameAndClassName(html, start_index, ref StartIndexOfElementInString, htmltagname, class_name))
            {
                if (GetEndOfHtmlElement(html,StartIndexOfElementInString,ref EndIndexOfElementInString,htmltagname))
                {
                    return true;
                }
            }
            return false;
        }

        public bool GetHtmlElementByTagName(string html, int start_index, ref int StartIndexOfElementInString, ref int EndIndexOfElementInString, string htmltagname)
        {
            if (GetHtmlElementStartIndexByTagName(html, start_index, ref StartIndexOfElementInString, htmltagname))
            {
                if (GetEndOfHtmlElement(html, StartIndexOfElementInString, ref EndIndexOfElementInString, htmltagname))
                {
                    return true;
                }
            }
            return false;
        }

        public bool GetEndOfHtmlElement(string html, int startIndexOfElementInString, ref int endIndexOfElementInString, string htmltagname)
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
                if (GetStartTag(html, startIndexOfElementInString + 1, ref index_of_start_start_tag, ref index_of_end_start_tag, htmltagname))
                {
                    if (GetEndTag(html, startIndexOfElementInString + 1, ref index_of_start_end_tag, ref index_of_end_end_tag, htmltagname))
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
                        if (GetEndTag(html, startIndexOfElementInString + 1, ref index_of_start_end_tag, ref index_of_end_end_tag, htmltagname))
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
