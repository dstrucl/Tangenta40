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
        public enum eType { DRAFT_INVOICE, INVOICE, PROFORMA_INVOICE, STORNO, UNKNOWN };

        public eType m_eType = eType.UNKNOWN;
        private bool b_FVI_SLO = false;
        private string CasshierName = "";


        public string_v FURS_ZOI_v = null;
        public string_v FURS_EOR_v = null;
        public string_v FURS_QR_v = null;
        public Image FURS_Image_QRcode = null;

        public string_v FURS_SalesBookInvoice_InvoiceNumber_v = null;
        public string_v FURS_SalesBookInvoice_SetNumber_v = null;
        public string_v FURS_SalesBookInvoice_SerialNumber = null;




        //public FURS_Response_data FURS_Response_Data = null;

        public DataTable dt_DocInvoice = new DataTable();
        public DataTable dt_ShopB_Items = new DataTable();
        public DataTable dt_ShopA_Items = new DataTable();

        public long DocInvoice_ID = -1;
        public long_v DocInvoice_ID_v = null;
        public long_v DocInvoice_Reference_ID_v = null;


        public int FinancialYear = -1;
        public int NumberInFinancialYear = -1;
        public bool Draft = true;
        public bool_v Invoice_Storno_v = null;
        public string_v Invoice_Reference_Type_v = null;


        public DateTime_v IssueDate_v = null;
        public DateTime_v StornoIssueDate_v = null;


        public string Currency_Symbol = null;
        public int Currency_DecimalPlaces = -1;



        public decimal GrossSum = 0;


        public decimal taxsum = 0;
        public decimal NetSum = 0;

        public UniversalInvoice.Organisation MyOrganisation = null;
        public UniversalInvoice.FVI_SLO_RealEstateBP FVI_SLO_RealEstateBP = null;
        public UniversalInvoice.Organisation CustomerOrganisation = null;
        public UniversalInvoice.Person CustomerPerson = null;
        public UniversalInvoice.Person Invoice_Author = null;
        public UniversalInvoice.ItemSold[] ItemsSold = null;
        public UniversalInvoice.InvoiceToken InvoiceToken = null;
        public UniversalInvoice.Invoice_FURS_Token Invoice_FURS_Token = null;

        public int iCountSimpleItemsSold = 0;
        public int iCountItemsSold = 0;


        public TangentaDB.ShopABC m_ShopABC = null;


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


        public InvoiceData(TangentaDB.ShopABC xInvoiceDB, long xDocProformaInvoice_ID, bool xb_FVI_SLO, string xCasshierName)
        {
            m_ShopABC = xInvoiceDB;
            DocInvoice_ID = xDocProformaInvoice_ID;
            Invoice_FURS_Token = new UniversalInvoice.Invoice_FURS_Token();
            b_FVI_SLO = xb_FVI_SLO;
            CasshierName = xCasshierName;
        }

        public void Set_NumberInFinancialYear(int xNumberInFinancialYear)
        {
            NumberInFinancialYear = xNumberInFinancialYear;
            InvoiceToken.tInvoiceNumber.Set(NumberInFinancialYear.ToString());
        }



        public void Fill_Sold_ShopA_ItemsData(string DocInvoice,ltext lt_token_prefix, ref UniversalInvoice.ItemSold[] ItemsSold, int start_index, int count, bool bInvoiceStorno)
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


        public bool Write_FURS_Response_Data()
        {
            object oret = null;
            string Err = null;
            string sql = null;
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            string spar_Invoice_ID = "@par_Invoice_ID";
            SQL_Parameter par_Invoice_ID = new SQL_Parameter(spar_Invoice_ID, SQL_Parameter.eSQL_Parameter.Bigint, false, DocInvoice_ID_v.v);
            lpar.Add(par_Invoice_ID);
            sql = "select ID from fvi_slo_response where DocInvoice_ID = " + spar_Invoice_ID;
            DataTable dt = new DataTable();
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    LogFile.Error.Show("ERROR:InvoiceData:Write_FURS_Response_Data:sql=" + sql + "\r\n Invoice was confirmed in the past: Invoice_ID" + DocInvoice_ID_v.v.ToString() + " fvi_slo_response.ID=" + ((long)dt.Rows[0]["ID"]).ToString());
                    return true;

                }
            }
            string spar_MessageID = "@par_MessageID";
            SQL_Parameter par_MessageID = new SQL_Parameter(spar_MessageID, SQL_Parameter.eSQL_Parameter.Nvarchar, false, FURS_ZOI_v.v);
            lpar.Add(par_MessageID);


            string spar_UniqueInvoiceID = "@par_UniqueInvoiceID";
            SQL_Parameter par_UniqueInvoiceID = new SQL_Parameter(spar_UniqueInvoiceID, SQL_Parameter.eSQL_Parameter.Nvarchar, false, FURS_EOR_v.v);
            lpar.Add(par_UniqueInvoiceID);

            string spar_BarCodeValue = "@par_BarCodeValue";
            SQL_Parameter par_BarCodeValue = new SQL_Parameter(spar_BarCodeValue, SQL_Parameter.eSQL_Parameter.Nvarchar, false, FURS_QR_v.v);
            lpar.Add(par_BarCodeValue);

            DateTime resp_datetime = DateTime.Now;
            string spar_Response_DateTime = "@par_Response_DateTime";
            SQL_Parameter par_Response_DateTime = new SQL_Parameter(spar_Response_DateTime, SQL_Parameter.eSQL_Parameter.Datetime, false, resp_datetime);
            lpar.Add(par_Response_DateTime);


            sql = "insert into fvi_slo_response (DocInvoice_ID,MessageID,UniqueInvoiceID,BarCodeValue,Response_DateTime) values (" + spar_Invoice_ID + "," + spar_MessageID + "," + spar_UniqueInvoiceID + "," + spar_BarCodeValue + "," + spar_Response_DateTime + ")";
            long id = -1;
            if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar, ref id, ref oret, ref Err, "fvi_slo_response"))
            {
                Set_Invoice_Furs_Token();
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:InvoiceData:Write_FURS_Response_Data:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }


        public void Set_Invoice_Furs_Token()
        {
            if (Invoice_FURS_Token == null)
            {
                Invoice_FURS_Token = new UniversalInvoice.Invoice_FURS_Token();
            }
            Invoice_FURS_Token.tUniqueMessageID.Set(this.FURS_ZOI_v.v);
            Invoice_FURS_Token.tUniqueInvoiceID.Set(this.FURS_EOR_v.v);

            if (this.FURS_Image_QRcode != null)
            {
                using (MemoryStream m = new MemoryStream())
                {
                    this.FURS_Image_QRcode.Save(m, this.FURS_Image_QRcode.RawFormat);
                    byte[] imageBytes = m.ToArray();

                    // Convert byte[] to Base64 String
                    string base64String = Convert.ToBase64String(imageBytes);
                    Invoice_FURS_Token.tQR.Set(base64String);
                }
            }
        }



        public bool Read_FURS_Response_Data(long DocProformaInvoice_ID, ref DataTable dt)
        {
            string sql = "select MessageID,UniqueInvoiceID,BarCodeValue from fvi_slo_response where DocInvoice_ID = " + DocProformaInvoice_ID.ToString();
            string Err = null;
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    FURS_ZOI_v = tf.set_string(dt.Rows[0]["MessageID"]);
                    FURS_EOR_v = tf.set_string(dt.Rows[0]["UniqueInvoiceID"]);
                    FURS_QR_v = tf.set_string(dt.Rows[0]["BarCodeValue"]);
                    this.FURS_Image_QRcode = null;
                }
                else
                {
                    if (Invoice_FURS_Token == null)
                    {
                        Invoice_FURS_Token = new UniversalInvoice.Invoice_FURS_Token();
                    }
                    Invoice_FURS_Token.tUniqueMessageID.Set("");
                    Invoice_FURS_Token.tUniqueInvoiceID.Set("");
                    Invoice_FURS_Token.tQR.Set("");
                }
                return true;

            }
            else
            {
                LogFile.Error.Show("ERROR:InvoiceData:Read_FURS_Response_Data:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }

        public bool SaveDocInvoice(ref long docinvoice_ID, GlobalData.ePaymentType m_ePaymentType, string m_sPaymentMethod, string m_sAmountReceived, string m_sToReturn, ref int xNumberInFinancialYear)
        {
            return m_ShopABC.m_CurrentInvoice.SaveDocInvoice(ref DocInvoice_ID, m_ePaymentType, m_sPaymentMethod, m_sAmountReceived, m_sToReturn, ref xNumberInFinancialYear);
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



        public bool Read_DocInvoice(string DocInvoice)
        {
            string sql = null;
            DocInvoice_Reference_ID_v = null;
            if (b_FVI_SLO)
            {
                if (DocInvoice.Equals("DocInvoice"))
                {
                    sql = @"select
                                 pi.ID as DocInvoice_ID,
                                 pi.FinancialYear,
                                 pi.NumberInFinancialYear,
                                 pi.Draft,
                                 mpay.PaymentType,
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
                                 JOURNAL_DocInvoice_$_dinv_$_fvisres.MessageID As JOURNAL_DocInvoice_$_dinv_$_fvisbi_$$MessageID,
                                 JOURNAL_DocInvoice_$_dinv_$_fvisres.UniqueInvoiceID As JOURNAL_DocInvoice_$_dinv_$_fvisbi_$$UniqueInvoiceID,
                                 JOURNAL_DocInvoice_$_dinv_$_fvisres.BarCodeValue As JOURNAL_DocInvoice_$_dinv_$_fvisbi_$$BarCodeValue,
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
                                 inner join Atom_myOrganisation_Person amcp on awp.Atom_myOrganisation_Person_ID = amcp.ID
                                 inner join Atom_Person ap on ap.ID = amcp.Atom_Person_ID
                                 inner join Atom_Office aoff on amcp.Atom_Office_ID = aoff.ID
                                 inner join Atom_Office_Data aoffd on aoffd.Atom_Office_ID = aoff.ID 
                                 inner join Atom_myOrganisation amc on aoff.Atom_myOrganisation_ID = amc.ID
                                 inner join Atom_OrganisationData aorgd on  amc.Atom_OrganisationData_ID = aorgd.ID
                                 inner join Atom_Organisation ao on aorgd.Atom_Organisation_ID = ao.ID
                                 LEFT JOIN FVI_SLO_Response JOURNAL_DocInvoice_$_dinv_$_fvisres ON JOURNAL_DocInvoice_$_dinv_$_fvisres.DocInvoice_ID = pi.ID 
                                 LEFT JOIN FVI_SLO_SalesBookInvoice JOURNAL_DocInvoice_$_dinv_$_fvisbi ON JOURNAL_DocInvoice_$_dinv_$_fvisbi.DocInvoice_ID = pi.ID 
                                 left join Atom_cFirstName apfn on ap.Atom_cFirstName_ID = apfn.ID 
                                 left join Atom_cLastName apln on ap.Atom_cLastName_ID = apln.ID 
                                 left join MethodOfPayment mpay on pi.MethodOfPayment_ID = mpay.ID
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
                else if (DocInvoice.Equals("DocProformaInvoice"))
                {
                    sql = @"select
                                 pi.ID as DocProformaInvoice_ID,
                                 pi.FinancialYear,
                                 pi.NumberInFinancialYear,
                                 pi.Draft,
                                 mpay.PaymentType,
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
                                 inner join Atom_myOrganisation_Person amcp on awp.Atom_myOrganisation_Person_ID = amcp.ID
                                 inner join Atom_Person ap on ap.ID = amcp.Atom_Person_ID
                                 inner join Atom_Office aoff on amcp.Atom_Office_ID = aoff.ID
                                 inner join Atom_Office_Data aoffd on aoffd.Atom_Office_ID = aoff.ID 
                                 inner join Atom_myOrganisation amc on aoff.Atom_myOrganisation_ID = amc.ID
                                 inner join Atom_OrganisationData aorgd on  amc.Atom_OrganisationData_ID = aorgd.ID
                                 inner join Atom_Organisation ao on aorgd.Atom_Organisation_ID = ao.ID
                                 left join Atom_cFirstName apfn on ap.Atom_cFirstName_ID = apfn.ID 
                                 left join Atom_cLastName apln on ap.Atom_cLastName_ID = apln.ID 
                                 left join MethodOfPayment mpay on pi.MethodOfPayment_ID = mpay.ID
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

            }
            else
            {
                if (DocInvoice.Equals("DocInvoice"))
                {
                    sql = @"select
                                 pi.ID as DocInvoice_ID,
                                 pi.FinancialYear,
                                 pi.NumberInFinancialYear,
                                 pi.Draft,
                                 mpay.PaymentType,
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
                                 inner join Atom_myOrganisation_Person amcp on Atom_WorkPeriod.Atom_myOrganisation_Person_ID = amcp.ID
                                 inner join Atom_Person ap on ap.ID = amcp.Atom_Person_ID
                                 inner join Atom_Office aoff on amcp.Atom_Office_ID = aoff.ID
                                 inner join Atom_Office_Data aoffd on aoffd.Atom_Office_ID = aoff.ID
                                 inner join Atom_myOrganisation amc on aoff.Atom_myOrganisation_ID = amc.ID
                                 inner join Atom_OrganisationData aorgd on  amc.Atom_OrganisationData_ID = aorgd.ID
                                 inner join Atom_Organisation ao on aorgd.Atom_Organisation_ID = ao.ID
                                 left join Atom_cFirstName apfn on ap.Atom_cFirstName_ID = apfn.ID 
                                 left join Atom_cLastName apln on ap.Atom_cLastName_ID = apln.ID 
                                 left join MethodOfPayment mpay on pi.MethodOfPayment_ID = mpay.ID
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
                else if (DocInvoice.Equals("DocProformaInvoice"))
                {
                    sql = @"select
                                 pi.ID as DocProformaInvoice_ID,
                                 pi.FinancialYear,
                                 pi.NumberInFinancialYear,
                                 pi.Draft,
                                 mpay.PaymentType,
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
                                 inner join JOURNAL_DocProformaInvoice_Type jpit on jpi.JOURNAL_DocProformaInvoice_Type_ID = jpit.ID and ((jpit.ID = " + GlobalData.JOURNAL_DocProformaInvoice_Type_definitions.ProformaInvoiceDraftTime.ID.ToString() + @")
                                 inner join DocProformaInvoice pi on jpi.DocProformaInvoice_ID = pi.ID
                                 inner join Atom_WorkPeriod awp on jpi.Atom_WorkPeriod_ID = awp.ID
                                 inner join Atom_myOrganisation_Person amcp on Atom_WorkPeriod.Atom_myOrganisation_Person_ID = amcp.ID
                                 inner join Atom_Person ap on ap.ID = amcp.Atom_Person_ID
                                 inner join Atom_Office aoff on amcp.Atom_Office_ID = aoff.ID
                                 inner join Atom_Office_Data aoffd on aoffd.Atom_Office_ID = aoff.ID
                                 inner join Atom_myOrganisation amc on aoff.Atom_myOrganisation_ID = amc.ID
                                 inner join Atom_OrganisationData aorgd on  amc.Atom_OrganisationData_ID = aorgd.ID
                                 inner join Atom_Organisation ao on aorgd.Atom_Organisation_ID = ao.ID
                                 left join Atom_cFirstName apfn on ap.Atom_cFirstName_ID = apfn.ID 
                                 left join Atom_cLastName apln on ap.Atom_cLastName_ID = apln.ID 
                                 left join MethodOfPayment mpay on pi.MethodOfPayment_ID = mpay.ID
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
            }
            string Err = null;
            if (DBSync.DBSync.ReadDataTable(ref dt_DocInvoice, sql, ref Err))
            {
                if (dt_DocInvoice.Rows.Count == 1)
                {
                    try
                    {
                        Draft = DBTypes.tf._set_bool(dt_DocInvoice.Rows[0]["Draft"]);
                        if (DocInvoice.ToUpper().Equals("DOCINVOICE"))
                        {
                            Invoice_Storno_v = DBTypes.tf.set_bool(dt_DocInvoice.Rows[0]["Storno"]);
                            Invoice_Reference_Type_v = DBTypes.tf.set_string(dt_DocInvoice.Rows[0]["Invoice_Reference_Type"]);
                            DocInvoice_Reference_ID_v = DBTypes.tf.set_long(dt_DocInvoice.Rows[0]["Invoice_Reference_ID"]);
                        }
                        else
                        {
                            Invoice_Storno_v = null;
                            Invoice_Reference_Type_v = null;
                            DocInvoice_Reference_ID_v = null;
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
                                    if (DocInvoice.Equals("DocInvoice"))
                                    {
                                        if (EventName_v != null)
                                        {
                                            if (EventName_v.v.Equals("InvoiceTime"))
                                            {
                                                this.m_eType = eType.INVOICE;
                                                this.IssueDate_v = EventTime_v.Clone();
                                            }
                                            else if (EventName_v.v.Equals("InvoiceStornoTime"))
                                            {
                                                this.m_eType = eType.STORNO;
                                                this.StornoIssueDate_v = EventTime_v.Clone();
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
                                    else if (DocInvoice.Equals("DocProformaInvoice"))
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

                                                    sql = "select EventTime from JOURNAL_DocProformaInvoice where DocProformaInvoice_ID = " + DocInvoice_ID.ToString() + " and JOURNAL_DocInvoice_Type_ID = " + GlobalData.JOURNAL_DocInvoice_Type_definitions.InvoiceTime.ID.ToString();
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

                        bool bInvoiceStorno = false;
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


                        GrossSum = DBTypes.tf._set_decimal(dt_DocInvoice.Rows[0]["GrossSum"]);
                        taxsum = DBTypes.tf._set_decimal(dt_DocInvoice.Rows[0]["TaxSum"]);
                        NetSum = DBTypes.tf._set_decimal(dt_DocInvoice.Rows[0]["NetSum"]);

                        if (bInvoiceStorno)
                        {
                            if (GrossSum > 0) GrossSum = GrossSum * -1;
                            if (taxsum > 0) taxsum = taxsum * -1;
                            if (NetSum > 0) NetSum = NetSum * -1;
                        }

                        if (b_FVI_SLO)
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

                            if (DocInvoice.Equals("DocInvoice"))
                            {
                                if (b_FVI_SLO)
                                {
                                    if (!Draft)
                                    {

                                        FURS_ZOI_v = DBTypes.tf.set_string(dt_DocInvoice.Rows[0]["JOURNAL_DocInvoice_$_dinv_$_fvisbi_$$MessageID"]);
                                        FURS_EOR_v = DBTypes.tf.set_string(dt_DocInvoice.Rows[0]["JOURNAL_DocInvoice_$_dinv_$_fvisbi_$$UniqueInvoiceID"]);
                                        FURS_QR_v = DBTypes.tf.set_string(dt_DocInvoice.Rows[0]["JOURNAL_DocInvoice_$_dinv_$_fvisbi_$$BarCodeValue"]);
                                        FURS_SalesBookInvoice_InvoiceNumber_v = DBTypes.tf.set_string(dt_DocInvoice.Rows[0]["JOURNAL_DocInvoice_$_dinv_$_fvisbi_$$InvoiceNumber"]);
                                        FURS_SalesBookInvoice_SetNumber_v = DBTypes.tf.set_string(dt_DocInvoice.Rows[0]["JOURNAL_DocInvoice_$_dinv_$_fvisbi_$$SetNumber"]);
                                        FURS_SalesBookInvoice_SerialNumber = DBTypes.tf.set_string(dt_DocInvoice.Rows[0]["JOURNAL_DocInvoice_$_dinv_$_fvisbi_$$SerialNumber"]);
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

                        long xDocProformaInvoice_ID = DocInvoice_ID;
                        if (DocInvoice_Reference_ID_v != null)
                        {
                            xDocProformaInvoice_ID = DocInvoice_Reference_ID_v.v;
                        }

                        if (dbfunc.Read_ShopA_Price_Item_Table(DocInvoice,xDocProformaInvoice_ID, ref dt_ShopA_Items))
                        {
                            if (m_ShopABC.Read_ShopB_Price_Item_Table(xDocProformaInvoice_ID, ref dt_ShopB_Items))
                            {
                                List<object> xDocProformaInvoice_ShopC_Item_Data_LIST = new List<object>();
                                if (this.m_eType == eType.STORNO)
                                {
                                    if (!m_ShopABC.m_CurrentInvoice.m_Basket.Read_ShopC_Price_Item_Stock_Table(DocInvoice,xDocProformaInvoice_ID, ref xDocProformaInvoice_ShopC_Item_Data_LIST))
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


                                Fill_Sold_ShopA_ItemsData(DocInvoice,lngToken.st_Invoice, ref ItemsSold, 0, iCountShopAItemsSold, bInvoiceStorno);
                                Fill_Sold_ShopB_ItemsData(lngToken.st_Invoice, ref ItemsSold, iCountShopAItemsSold, iCountShopBItemsSold, bInvoiceStorno);
                                Fill_Sold_ShopC_ItemsData(xDocProformaInvoice_ShopC_Item_Data_LIST, lngToken.st_Invoice, ref ItemsSold, iCountShopAItemsSold + iCountShopBItemsSold, iCountShopCItemsSold, bInvoiceStorno);

                                InvoiceToken = new UniversalInvoice.InvoiceToken();

                                InvoiceToken.tFiscalYear.Set(FinancialYear.ToString());
                                InvoiceToken.tInvoiceNumber.Set(NumberInFinancialYear.ToString());
                                InvoiceToken.tCashier.Set(CasshierName);

                                InvoiceToken.tStorno.Set("");
                                if (bInvoiceStorno)
                                {
                                    InvoiceToken.tStorno.Set(lngRPM.s_STORNO.s);
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
                    LogFile.Error.Show("ERROR:usrc_Invoice_Preview:Read_DocProformaInvoice:dt_DocProformaInvoice.Rows.Count != 1! for DocProformaInvoice_ID=" + DocInvoice_ID.ToString() + "!\r\nsql = " + sql);
                    return false;
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

            foreach (UniversalInvoice.TemplateToken tt in this.InvoiceToken.list)
            {
                s += "\r\n" + tt.lt.s;
            }

            if (Invoice_FURS_Token != null)
            {
                foreach (UniversalInvoice.TemplateToken tt in this.Invoice_FURS_Token.list)
                {
                    s += "\r\n" + tt.lt.s;
                }
            }


            if (ItemsSold.Count() > 0)
            {
                foreach (UniversalInvoice.TemplateToken tt in this.ItemsSold[0].token.list)
                {
                    s += "\r\n" + tt.lt.s;
                }
            }

            if (this.FVI_SLO_RealEstateBP != null)
            {
                foreach (UniversalInvoice.TemplateToken tt in this.FVI_SLO_RealEstateBP.token.list)
                {
                    s += "\r\n" + tt.lt.s;
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

        private string sStorno(bool bStorno)
        {
            if (bStorno)
            {
                return "";
            }
            else
            {
                return "";
            }
        }

        public string Create_furs_InvoiceXML(bool bStorno, string InvoiceXmlTemplate, string FursD_MyOrgTaxID, string FursD_BussinesPremiseID, string CasshierName, string FursD_InvoiceAuthorTaxID, string stornoReferenceInvoiceNumber, string stornoReferenceInvoiceIssueDateTime)
        {
            try
            {
                //                string InvoiceXmlTemplate = Properties.Resources.FVI_SLO_Invoice;
                XmlDocument xdoc = new XmlDocument();
                xdoc.LoadXml(InvoiceXmlTemplate);
                XmlNodeList ndl_TaxNumber = xdoc.GetElementsByTagName("fu:TaxNumber");
                //string sInnerText_MyOrgTaxID = Program.usrc_FVI_SLO1.FursD_MyOrgTaxID; // "10329048";//MyOrganisation.Tax_ID;
                ndl_TaxNumber.Item(0).InnerText = FursD_MyOrgTaxID;//Program.usrc_FVI_SLO1.FursD_MyOrgTaxID; //MyOrganisation.Tax_ID;
                XmlNodeList ndl_IssueDateTime = xdoc.GetElementsByTagName("fu:IssueDateTime");
                ndl_IssueDateTime.Item(0).InnerText = fs.GetFURS_Time_Formated(IssueDate_v.v);
                XmlNodeList ndl_BusinessPremiseID = xdoc.GetElementsByTagName("fu:BusinessPremiseID");
                //string sInnerText_FursD_BussinesPremiseID = Program.usrc_FVI_SLO1.FursD_BussinesPremiseID;
                ndl_BusinessPremiseID.Item(0).InnerText = FursD_BussinesPremiseID;// Program.usrc_FVI_SLO1.FursD_BussinesPremiseID; // "36CF"; //MyOrganisation.Atom_Office_Name;
                XmlNodeList ndl_ElectronicDeviceID = xdoc.GetElementsByTagName("fu:ElectronicDeviceID");
                ndl_ElectronicDeviceID.Item(0).InnerText = CasshierName;//Properties.Settings.Default.CasshierName;
                XmlNodeList ndl_InvoiceNumber = xdoc.GetElementsByTagName("fu:InvoiceNumber");
                ndl_InvoiceNumber.Item(0).InnerText = NumberInFinancialYear.ToString();
                XmlNodeList ndl_InvoiceAmount = xdoc.GetElementsByTagName("fu:InvoiceAmount");
                ndl_InvoiceAmount.Item(0).InnerText = sStorno(bStorno) + fs.GetFursDecimalString(GrossSum);
                XmlNodeList ndl_PaymentAmount = xdoc.GetElementsByTagName("fu:PaymentAmount");
                ndl_PaymentAmount.Item(0).InnerText = sStorno(bStorno) + fs.GetFursDecimalString(GrossSum);

                XmlNodeList ndl_TaxesPerSeller = xdoc.GetElementsByTagName("fu:TaxesPerSeller");
                string s_innertext = "";
                foreach (StaticLib.Tax tax in taxSum.TaxList)
                {
                    string sVat = "<fu:VAT>\r\n" +
                                          "<fu:TaxRate>" + sStorno(bStorno) + fs.GetFursDecimalString(tax.Rate * 100) + "</fu:TaxRate>\r\n" +
                                          "<fu:TaxableAmount>" + sStorno(bStorno) + fs.GetFursDecimalString(tax.TaxableAmount) + "</fu:TaxableAmount>\r\n" +
                                          "<fu:TaxAmount>" + sStorno(bStorno) + fs.GetFursDecimalString(tax.TaxAmount) + "</fu:TaxAmount>\r\n" +
                                   "</fu:VAT>" + "\r\n";
                    s_innertext += sVat;
                }
                ndl_TaxesPerSeller.Item(0).InnerXml = s_innertext;

                XmlNodeList ndl_OperatorTaxNumber = xdoc.GetElementsByTagName("fu:OperatorTaxNumber");

                string sFursD_InvoiceAuthorTaxID = FursD_InvoiceAuthorTaxID;// Program.usrc_FVI_SLO1.FursD_InvoiceAuthorTaxID;

                //Invoice_Author.Tax_ID = "59729481";

                Invoice_Author.Tax_ID = FursD_InvoiceAuthorTaxID;// Program.usrc_FVI_SLO1.FursD_InvoiceAuthorTaxID;


                ndl_OperatorTaxNumber.Item(0).InnerText = Invoice_Author.Tax_ID;

                //LK storno 
                if (bStorno)
                {
                    XmlNodeList Fu_Invoice = xdoc.GetElementsByTagName("fu:Invoice");
                    string ns = Fu_Invoice.Item(0).GetNamespaceOfPrefix("fu");

                    XmlNode xReferenceInvoice = xdoc.CreateNode("element", "ReferenceInvoice", ns);
                    XmlNode xReferenceInvoiceIdentifier = xdoc.CreateNode("element", "ReferenceInvoiceIdentifier", ns);
                    XmlNode xBusinessPremiseID = xdoc.CreateNode("element", "BusinessPremiseID", ns);
                    XmlNode xElectronicDeviceID = xdoc.CreateNode("element", "ElectronicDeviceID", ns);
                    XmlNode xInvoiceNumber = xdoc.CreateNode("element", "InvoiceNumber", ns);
                    XmlNode xReferenceInvoiceIssueDateTime = xdoc.CreateNode("element", "ReferenceInvoiceIssueDateTime", ns);
                    xReferenceInvoice.Prefix = "fu";
                    xReferenceInvoiceIdentifier.Prefix = "fu";
                    xBusinessPremiseID.Prefix = "fu";
                    xElectronicDeviceID.Prefix = "fu";
                    xInvoiceNumber.Prefix = "fu";
                    xReferenceInvoiceIssueDateTime.Prefix = "fu";


                    xBusinessPremiseID.InnerText = FursD_BussinesPremiseID;
                    xElectronicDeviceID.InnerText = CasshierName;
                    xInvoiceNumber.InnerText = stornoReferenceInvoiceNumber;
                    xReferenceInvoiceIssueDateTime.InnerText = stornoReferenceInvoiceIssueDateTime;

                    xReferenceInvoiceIdentifier.AppendChild(xBusinessPremiseID);
                    xReferenceInvoiceIdentifier.AppendChild(xElectronicDeviceID);
                    xReferenceInvoiceIdentifier.AppendChild(xInvoiceNumber);
                    xReferenceInvoice.AppendChild(xReferenceInvoiceIdentifier);
                    xReferenceInvoice.AppendChild(xReferenceInvoiceIssueDateTime);
                    Fu_Invoice.Item(0).AppendChild(xReferenceInvoice);

                    //<fu:ReferenceInvoice>
                    //  <fu:ReferenceInvoiceIdentifier >  
                    //    <fu:BusinessPremiseID > TRGOVINA1 </ fu:BusinessPremiseID >
                    //    <fu:ElectronicDeviceID > BLAG2 </ fu:ElectronicDeviceID >
                    //    <fu:InvoiceNumber > 145 </ fu:InvoiceNumber >
                    //  </fu:ReferenceInvoiceIdentifier >
                    //  <fu:ReferenceInvoiceIssueDateTime > 2015 - 09 - 07T12: 12:54 </ fu:ReferenceInvoiceIssueDateTime >
                    //</fu:ReferenceInvoice >
                }

                string InvoiceXml = XmlDcoumentToString(xdoc);
                return InvoiceXml;
            }
            catch (Exception Ex)
            {
                LogFile.Error.Show("ERROR:InvoiceData:Create_furs_InvoiceXML:Exception = " + Ex.Message);
                return null;
            }

        }

        public string Create_furs_SalesBookInvoiceXML(string InvoiceXmlTemplate, string FursD_MyOrgTaxID, string FursD_BussinesPremiseID, string SalesBookSetNumber, string SalesBookSerialNumber)
        {
            try
            {
                XmlDocument xdoc = new XmlDocument();
                xdoc.LoadXml(InvoiceXmlTemplate);
                XmlNodeList ndl_TaxNumber = xdoc.GetElementsByTagName("fu:TaxNumber");
                ndl_TaxNumber.Item(0).InnerText = FursD_MyOrgTaxID;
                XmlNodeList ndl_IssueDateTime = xdoc.GetElementsByTagName("fu:IssueDate");
                ndl_IssueDateTime.Item(0).InnerText = IssueDate_v.v.ToString("yyyy-MM-dd");
                XmlNodeList ndl_BusinessPremiseID = xdoc.GetElementsByTagName("fu:BusinessPremiseID");
                ndl_BusinessPremiseID.Item(0).InnerText = FursD_BussinesPremiseID;
                XmlNodeList ndl_InvoiceNumber = xdoc.GetElementsByTagName("fu:InvoiceNumber");
                ndl_InvoiceNumber.Item(0).InnerText = NumberInFinancialYear.ToString();
                XmlNodeList ndl_InvoiceAmount = xdoc.GetElementsByTagName("fu:InvoiceAmount");
                ndl_InvoiceAmount.Item(0).InnerText = fs.GetFursDecimalString(GrossSum);
                XmlNodeList ndl_PaymentAmount = xdoc.GetElementsByTagName("fu:PaymentAmount");
                ndl_PaymentAmount.Item(0).InnerText = fs.GetFursDecimalString(GrossSum);

                XmlNodeList ndl_TaxesPerSeller = xdoc.GetElementsByTagName("fu:TaxesPerSeller");
                string s_innertext = "";
                foreach (StaticLib.Tax tax in taxSum.TaxList)
                {
                    string sVat = "<fu:VAT>\r\n" +
                                          "<fu:TaxRate>" + fs.GetFursDecimalString(tax.Rate * 100) + "</fu:TaxRate>\r\n" +
                                          "<fu:TaxableAmount>" + fs.GetFursDecimalString(tax.TaxableAmount) + "</fu:TaxableAmount>\r\n" +
                                          "<fu:TaxAmount>" + fs.GetFursDecimalString(tax.TaxAmount) + "</fu:TaxAmount>\r\n" +
                                   "</fu:VAT>" + "\r\n";
                    s_innertext += sVat;
                }
                ndl_TaxesPerSeller.Item(0).InnerXml = s_innertext;

                // salesbook stuff
                XmlNodeList ndl_SetNumber = xdoc.GetElementsByTagName("fu:SetNumber");
                ndl_SetNumber.Item(0).InnerText = Convert.ToInt32(SalesBookSetNumber).ToString("D2");

                XmlNodeList ndl_SerialNumber = xdoc.GetElementsByTagName("fu:SerialNumber");
                ndl_SerialNumber.Item(0).InnerText = SalesBookSerialNumber;


                string InvoiceXml = XmlDcoumentToString(xdoc);
                return InvoiceXml;
            }
            catch (Exception Ex)
            {
                LogFile.Error.Show("ERROR:InvoiceData:Create_furs_SalesBookInvoiceXML:Exception = " + Ex.Message);
                return null;
            }


        }


        private void GetFursDecimalString(decimal grossSum)
        {
            throw new NotImplementedException();
        }

        private string XmlDcoumentToString(XmlDocument xmlDoc)
        {
            var settings = new XmlWriterSettings();
            settings.OmitXmlDeclaration = false;
            settings.Indent = true;
            settings.NewLineOnAttributes = true;

            var stringBuilder = new StringBuilder();
            using (var xmlWriter = XmlWriter.Create(stringBuilder, settings))
            {
                xmlDoc.Save(xmlWriter);
            }

            return stringBuilder.ToString();
        }

        public string CreateHTML_Invoice(ref string html_doc_template)
        {
            string stime = IssueDate_v.v.Day.ToString() + "."
                                           + IssueDate_v.v.Month.ToString() + "."
                                           + IssueDate_v.v.Year.ToString() + " "
                                           + IssueDate_v.v.Hour.ToString() + ":"
                                           + IssueDate_v.v.Minute.ToString();
            InvoiceToken.tDateOfIssue.Set(stime);
            InvoiceToken.tDateOfMaturity.Set(stime);

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

            html_doc_template = Invoice_FURS_Token.tUniqueMessageID.Replace(html_doc_template);
            html_doc_template = Invoice_FURS_Token.tUniqueInvoiceID.Replace(html_doc_template);
            html_doc_template = Invoice_FURS_Token.tQR.Replace(html_doc_template);


            int itbody = html_doc_template.IndexOf("<tbody>", 0);
            if (itbody > 0)
            {
                int itr_start = html_doc_template.IndexOf("<tr class=\"row\">", itbody);
                if (itr_start > 0)
                {
                    int itr_end = html_doc_template.IndexOf("</tr>", itr_start);
                    if (itr_end > 0)
                    {

                        string tr_RowTemplate = html_doc_template.Substring(itr_start, itr_end - itr_start + 5);


                        html_doc_template = html_doc_template.Remove(itr_start, itr_end - itr_start + 5);

                        int ipos = itr_start;

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
                            ipos += sRow.Length;
                        }


                        html_doc_template = tCurrency.Replace(html_doc_template);

                        InvoiceToken.tSumNetPrice.Set(NetSum.ToString());
                        html_doc_template = InvoiceToken.tSumNetPrice.Replace(html_doc_template);


                        //string s_journal_invoice_type = lngRPM.s_journal_invoice_type_Print.s;
                        //string s_journal_invoice_description = Program.ReceiptPrinter.PrinterName;
                        //long journal_docinvoice_id = -1;
                        //f_Journal_DocProformaInvoice.Write(m_usrc_Print.DocProformaInvoice_ID, Program.Atom_WorkPeriod_ID, s_journal_invoice_type, s_journal_invoice_description, null, ref journal_docinvoice_id);
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
                                    ipos += str.Length;
                                }
                                InvoiceToken.tTotalSum.Set(GrossSum.ToString());
                                html_doc_template = InvoiceToken.tTotalSum.Replace(html_doc_template);
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
