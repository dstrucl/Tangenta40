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
using InvoiceDB;
using ShopA_dbfunc;

namespace Tangenta
{
    public class FURS_Response_data
    {
        public string UniqueMessageID = null;
        public string UniqueInvoiceID = null;
        public string BarCodeValue = null;
        public Image Image_QRcode = null;

        public FURS_Response_data(string furs_UniqeMsgID, string furs_UniqeInvID,string furs_barcode_value, Image img_QR)
        {
            this.UniqueMessageID = furs_UniqeMsgID;
            this.UniqueInvoiceID = furs_UniqeInvID;
            this.BarCodeValue = furs_barcode_value;
            this.Image_QRcode = img_QR;
        }
    }

    public class InvoiceData
    {

        public FURS_Response_data FURS_Response_Data = null;

        public DataTable dt_ProformaInvoice = new DataTable();
        public DataTable dt_ShopB_Items = new DataTable();
        public DataTable dt_ShopA_Items = new DataTable();

        public long ProformaInvoice_ID = -1;
        public long Invoice_ID = -1;

        public int FinancialYear = -1;
        public int NumberInFinancialYear = -1;
        public bool Draft = true;

        public int IssueDate_Hour = 0;
        public int IssueDate_Min = 0;
        public int IssueDate_Sec = 0;



        public int IssueDate_Day = 0;
        public int IssueDate_Month = 0;
        public int IssueDate_Year = 0;

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


        public InvoiceDB.ShopABC m_ShopABC = null;


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


        public InvoiceData(InvoiceDB.ShopABC xInvoiceDB, long xProformaInvoice_ID)
        {
            m_ShopABC = xInvoiceDB;
            ProformaInvoice_ID = xProformaInvoice_ID;
            Invoice_FURS_Token = new UniversalInvoice.Invoice_FURS_Token();
        }

        internal void Set_NumberInFinancialYear(int xNumberInFinancialYear)
        {
            NumberInFinancialYear = xNumberInFinancialYear;
            InvoiceToken.tInvoiceNumber.Set(NumberInFinancialYear.ToString());
        }



        public void Fill_Sold_ShopA_ItemsData(ltext lt_token_prefix, ref UniversalInvoice.ItemSold[] ItemsSold, int start_index, int count)
        {
            int i;
            int end_index = start_index + count;
            int j = 0;
            for (i = start_index; i < end_index; i++)
            {
                DataRow dr = dt_ShopA_Items.Rows[j];

                decimal Discount = 0;
                object oDiscount = dr["Atom_ItemShopA_Price_$$Discount"];
                if (oDiscount is decimal)
                {
                    Discount = (decimal)oDiscount;
                }


                decimal TotalDiscount = Discount;

                decimal RetailSimpleItemPriceWithDiscount = 0;
                object o_RetailSimpleItemPriceWithDiscount = dr["Atom_ItemShopA_Price_$$EndPriceWithDiscountAndTax"];
                if (o_RetailSimpleItemPriceWithDiscount.GetType() == typeof(decimal))
                {
                    RetailSimpleItemPriceWithDiscount = (decimal)o_RetailSimpleItemPriceWithDiscount;
                }

                string sUnitName = "";
                object oUnitName = dr["Atom_ItemShopA_Price_$_aisha_$_u_$$Name"];
                if (oUnitName is string)
                {
                    sUnitName = (string)oUnitName;
                }

                decimal dQuantity = -1;    
                object oQuantity = dr["Atom_ItemShopA_Price_$$dQuantity"];
                if (oQuantity is decimal)
                {
                    dQuantity = (decimal)oQuantity;
                }

                decimal TaxPrice = -1;
                object oTaxPrice = dr["Atom_ItemShopA_Price_$$TAX"];
                if (oTaxPrice is decimal)
                {
                    TaxPrice = (decimal)oTaxPrice;
                }
                decimal price_without_tax = RetailSimpleItemPriceWithDiscount - TaxPrice;

                decimal taxation_rate = DBTypes.tf._set_decimal(dr["Atom_ItemShopA_Price_$_aisha_$_tax_$$Rate"]);
                decimal tax_price = DBTypes.tf._set_decimal(dr["Atom_ItemShopA_Price_$$TAX"]);
                string tax_name = DBTypes.tf._set_string(dr["Atom_ItemShopA_Price_$_aisha_$_tax_$$Name"]);
                taxSum.Add(tax_price, price_without_tax, tax_name, taxation_rate);

                decimal dRetailPricePerUnitWithDiscount = 0;
                if (dr["Atom_ItemShopA_Price_$$PricePerUnit"] is decimal)
                {
                    dRetailPricePerUnitWithDiscount = decimal.Round((decimal)dr["Atom_ItemShopA_Price_$$PricePerUnit"]*(1- Discount),GlobalData.BaseCurrency.DecimalPlaces);
                }


                ItemsSold[i] = new UniversalInvoice.ItemSold(lt_token_prefix, lngRPM.s_Shop_B,
                                                             DBTypes.tf._set_string(dr["Atom_ItemShopA_Price_$_aisha_$$Name"]),
                                                             DBTypes.tf._set_decimal(dr["Atom_ItemShopA_Price_$$PricePerUnit"]),
                                                             "", // no unit
                                                             dRetailPricePerUnitWithDiscount,
                                                             tax_name,
                                                             dQuantity,
                                                             DBTypes.tf._set_decimal(dr["Atom_ItemShopA_Price_$$Discount"]),
                                                             DBTypes.tf._set_decimal(0),
                                                             DBTypes.tf._set_string(GlobalData.BaseCurrency.Symbol),
                                                             taxation_rate,
                                                             DBTypes.tf._set_decimal(TotalDiscount),
                                                             DBTypes.tf._set_decimal(price_without_tax),
                                                             tax_price,
                                                             DBTypes.tf._set_decimal(dr["Atom_ItemShopA_Price_$$EndPriceWithDiscountAndTax"]));

                j++;
            }

        }



        public void Fill_Sold_ShopB_ItemsData(ltext lt_token_prefix, ref UniversalInvoice.ItemSold[] ItemsSold, int start_index, int count)
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

                decimal TotalDiscount = StaticLib.Func.TotalDiscount(Discount, ExtraDiscount, Program.Get_BaseCurrency_DecimalPlaces());

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

                decimal taxation_rate  = DBTypes.tf._set_decimal(dr["Atom_Taxation_Rate"]);
                decimal tax_price = DBTypes.tf._set_decimal(dr["TaxPrice"]);
                string tax_name = DBTypes.tf._set_string(dr["Atom_Taxation_Name"]);
                taxSum.Add(tax_price, price_without_tax, tax_name, taxation_rate);

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
                                                             DBTypes.tf._set_decimal(price_without_tax),
                                                             tax_price,
                                                             DBTypes.tf._set_decimal(dr["RetailSimpleItemPriceWithDiscount"]));

                j++;
            }

        }

        
        internal bool Write_FURS_Response_Data()
        {
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            string spar_Invoice_ID = "@par_Invoice_ID";
            SQL_Parameter par_Invoice_ID = new SQL_Parameter(spar_Invoice_ID, SQL_Parameter.eSQL_Parameter.Bigint, false, Invoice_ID);
            lpar.Add(par_Invoice_ID);

            string spar_MessageID = "@par_MessageID";
            SQL_Parameter par_MessageID = new SQL_Parameter(spar_MessageID, SQL_Parameter.eSQL_Parameter.Nvarchar, false, FURS_Response_Data.UniqueMessageID);
            lpar.Add(par_MessageID);


            string spar_UniqueInvoiceID = "@par_UniqueInvoiceID";
            SQL_Parameter par_UniqueInvoiceID = new SQL_Parameter(spar_UniqueInvoiceID, SQL_Parameter.eSQL_Parameter.Nvarchar, false, FURS_Response_Data.UniqueInvoiceID);
            lpar.Add(par_UniqueInvoiceID);

            string spar_BarCodeValue = "@par_BarCodeValue";
            SQL_Parameter par_BarCodeValue = new SQL_Parameter(spar_BarCodeValue, SQL_Parameter.eSQL_Parameter.Nvarchar, false, FURS_Response_Data.BarCodeValue);
            lpar.Add(par_BarCodeValue);

            DateTime resp_datetime = DateTime.Now;
            string spar_Response_DateTime = "@par_Response_DateTime";
            SQL_Parameter par_Response_DateTime = new SQL_Parameter(spar_Response_DateTime, SQL_Parameter.eSQL_Parameter.Datetime, false, resp_datetime);
            lpar.Add(par_Response_DateTime);


            string sql = "insert into fvi_slo_response (Invoice_ID,MessageID,UniqueInvoiceID,BarCodeValue,Response_DateTime) values (" + spar_Invoice_ID + "," + spar_MessageID + "," + spar_UniqueInvoiceID +","+ spar_BarCodeValue + "," + spar_Response_DateTime + ")";
            long id = -1;
            object oret = null;
            string Err = null;
            if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql,lpar, ref id, ref oret,ref Err, "fvi_slo_response"))
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


        private void Set_Invoice_Furs_Token()
        {
            if (Invoice_FURS_Token == null)
            {
                Invoice_FURS_Token = new UniversalInvoice.Invoice_FURS_Token();
            }
            Invoice_FURS_Token.tUniqueMessageID.Set(FURS_Response_Data.UniqueMessageID);
            Invoice_FURS_Token.tUniqueInvoiceID.Set(FURS_Response_Data.UniqueInvoiceID);
            using (MemoryStream m = new MemoryStream())
            {
                FURS_Response_Data.Image_QRcode.Save(m, FURS_Response_Data.Image_QRcode.RawFormat);
                byte[] imageBytes = m.ToArray();

                // Convert byte[] to Base64 String
                string base64String = Convert.ToBase64String(imageBytes);
                Invoice_FURS_Token.tQR.Set(base64String);
            }
        }



        internal bool Read_FURS_Response_Data(long Invoice_ID)
        {
            string sql = "select MessageID,UniqueInvoiceID,BarCodeValue from fvi_slo_response where Invoice_ID = " + Invoice_ID.ToString();
            string Err = null;
            DataTable dt = new DataTable();
            if (DBSync.DBSync.ReadDataTable(ref dt,sql, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    string UniqMsgID = (string)dt.Rows[0]["MessageID"];
                    string UniqInvID = (string)dt.Rows[0]["UniqueInvoiceID"];
                    string QRBarCodeValue = (string)dt.Rows[0]["BarCodeValue"];
                    Image Img_QR = Program.usrc_FVI_SLO1.GetQRImage(QRBarCodeValue);
                    FURS_Response_Data = new FURS_Response_data(UniqMsgID, UniqInvID, QRBarCodeValue, Img_QR);
                    Set_Invoice_Furs_Token();
                }
                else
                {
                    FURS_Response_Data = null;
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

        internal bool Save(ref long proformaInvoice_ID, GlobalData.ePaymentType m_ePaymentType, string m_sPaymentMethod, string m_sAmountReceived, string m_sToReturn, ref int xNumberInFinancialYear)
        {
            return m_ShopABC.m_CurrentInvoice.Save(ref ProformaInvoice_ID, m_ePaymentType, m_sPaymentMethod, m_sAmountReceived, m_sToReturn, ref xNumberInFinancialYear);
        }

        internal bool SetInvoiceTime(DateTime_v issue_time)
        {
            if (m_ShopABC.m_CurrentInvoice.SetInvoiceTime(issue_time))
            {
                if (issue_time != null)
                {
                    IssueDate_Year = issue_time.v.Year;
                    IssueDate_Month = issue_time.v.Month;
                    IssueDate_Day = issue_time.v.Day;
                    IssueDate_Hour = issue_time.v.Hour;
                    IssueDate_Min = issue_time.v.Minute;
                    IssueDate_Sec = issue_time.v.Second;
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

        public void Fill_Sold_ShopC_ItemsData(ltext lt_token_prefix, ref UniversalInvoice.ItemSold[] ItemsSold, int start_index, int count)
        {

            int i;
            int end_index = start_index + count;
            int j = 0;


            for (i = start_index; i < end_index; i++)
            {
                Atom_ProformaInvoice_Price_Item_Stock_Data appisd = (Atom_ProformaInvoice_Price_Item_Stock_Data)m_ShopABC.m_CurrentInvoice.m_Basket.Atom_ProformaInvoice_Price_Item_Stock_Data_LIST[j];

                decimal Discount = appisd.Discount.v;

                decimal ExtraDiscount = appisd.ExtraDiscount.v;

                decimal TotalDiscount = StaticLib.Func.TotalDiscount(Discount, ExtraDiscount, Program.Get_BaseCurrency_DecimalPlaces());

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

                taxSum.Add(tax_price, ItemsNetPrice, tax_name, taxation_rate);

                ItemsSold[i] = new UniversalInvoice.ItemSold(lt_token_prefix,lngRPM.s_Shop_B,
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
                                                             DBTypes.tf._set_decimal(ItemsNetPrice),
                                                             DBTypes.tf._set_decimal(ItemsTaxPrice),
                                                             DBTypes.tf._set_decimal(RetailItemsPriceWithDiscount));
                j++;
            }

        }



        public bool Read_ProformaInvoice()
        {
            string sql = null;
            if (Program.b_FVI_SLO)
            {

                sql = @"select
                                 inv.ID as Invoice_ID,
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
                                 Atom_cState_Org.State,
                                 Atom_cCountry_Org.Country,
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
                                 acusper.ID as Atom_Customer_Person_ID
                                 from JOURNAL_ProformaInvoice
                                 inner join JOURNAL_ProformaInvoice_Type on JOURNAL_ProformaInvoice.JOURNAL_ProformaInvoice_Type_ID = JOURNAL_ProformaInvoice_Type.ID and (JOURNAL_ProformaInvoice_Type.ID = " + GlobalData.JOURNAL_ProformaInvoice_Type_definitions.InvoiceDraftTime.ID.ToString() + @")
                                 inner join ProformaInvoice pi on JOURNAL_ProformaInvoice.ProformaInvoice_ID = pi.ID
                                 inner join Atom_WorkPeriod awp on JOURNAL_ProformaInvoice.Atom_WorkPeriod_ID = awp.ID
                                 inner join Atom_myCompany_Person amcp on awp.Atom_myCompany_Person_ID = amcp.ID
                                 inner join Atom_Person ap on ap.ID = amcp.ID
                                 inner join Atom_Office aoff on amcp.Atom_Office_ID = aoff.ID
                                 inner join Atom_Office_Data aoffd on aoffd.Atom_Office_ID = aoff.ID and aoffd.Atom_myCompany_Person_ID = awp.Atom_myCompany_Person_ID
                                 inner join Atom_myCompany amc on aoff.Atom_myCompany_ID = amc.ID
                                 inner join Atom_OrganisationData aorgd on  amc.Atom_OrganisationData_ID = aorgd.ID
                                 inner join Atom_Organisation ao on aorgd.Atom_Organisation_ID = ao.ID
                                 left join Invoice inv on pi.Invoice_ID = inv.ID
                                 left join Atom_cFirstName apfn on ap.Atom_cFirstName_ID = apfn.ID 
                                 left join Atom_cLastName apln on ap.Atom_cLastName_ID = apln.ID 
                                 left join MethodOfPayment mpay on inv.MethodOfPayment_ID = mpay.ID
                                 left join cOrgTYPE aorgd_cOrgTYPE on aorgd.cOrgTYPE_ID = aorgd_cOrgTYPE.ID
                                 left join Atom_cAddress_Org acaorg on aorgd.Atom_cAddress_Org_ID = acaorg.ID
                                 left join Atom_cStreetName_Org on acaorg.Atom_cStreetName_Org_ID = Atom_cStreetName_Org.ID
                                 left join Atom_cHouseNumber_Org on acaorg.Atom_cHouseNumber_Org_ID = Atom_cHouseNumber_Org.ID
                                 left join Atom_cCity_Org on acaorg.Atom_cCity_Org_ID = Atom_cCity_Org.ID
                                 left join Atom_cZIP_Org on acaorg.Atom_cZIP_Org_ID = Atom_cZIP_Org.ID
                                 left join Atom_cState_Org on acaorg.Atom_cState_Org_ID = Atom_cState_Org.ID
                                 left join Atom_cCountry_Org on acaorg.Atom_cCountry_Org_ID = Atom_cCountry_Org.ID
                                 left join cHomePage_Org on aorgd.cHomePage_Org_ID = cHomePage_Org.ID
                                 left join cEmail_Org on aorgd.cEmail_Org_ID = cEmail_Org.ID
                                 left join cHomePage_Org aorgd_hp  on aorgd.cHomePage_Org_ID = cHomePage_Org.ID
                                 left join cFaxNumber_Org on aorgd.cFaxNumber_Org_ID = cFaxNumber_Org.ID
                                 left join cPhoneNumber_Org on aorgd.cPhoneNumber_Org_ID = cPhoneNumber_Org.ID
                                 left join Atom_Logo on aorgd.Atom_Logo_ID = Atom_Logo.ID
                                 left join Atom_Customer_Org acusorg on acusorg.ID = pi.Atom_Customer_Org_ID
                                 left join Atom_Customer_Person acusper on acusper.ID = pi.Atom_Customer_Person_ID
                                 where pi.ID = " + ProformaInvoice_ID.ToString();
            }
            else
            {
                sql = @"select
                                 inv.ID as Invoice_ID,
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
                                 Atom_cState_Org.State,
                                 Atom_cCountry_Org.Country,
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
                                 acusper.ID as Atom_Customer_Person_ID
                                 from JOURNAL_ProformaInvoice
                                 inner join JOURNAL_ProformaInvoice_Type on JOURNAL_ProformaInvoice.JOURNAL_ProformaInvoice_Type_ID = JOURNAL_ProformaInvoice_Type.ID and (JOURNAL_ProformaInvoice_Type.ID = " + GlobalData.JOURNAL_ProformaInvoice_Type_definitions.InvoiceDraftTime.ID.ToString() + @")
                                 inner join ProformaInvoice pi on JOURNAL_ProformaInvoice.ProformaInvoice_ID = pi.ID
                                 inner join Atom_WorkPeriod on JOURNAL_ProformaInvoice.Atom_WorkPeriod_ID = Atom_WorkPeriod.ID
                                 inner join Atom_myCompany_Person amcp on Atom_WorkPeriod.Atom_myCompany_Person_ID = amcp.ID
                                 inner join Atom_Person ap on ap.ID = amcp.ID
                                 inner join Atom_Office aoff on amcp.Atom_Office_ID = aoff.ID
                                 inner join Atom_Office_Data aoffd on aoffd.Atom_Office_ID = aoff.ID and aoffd.Atom_myCompany_Person_ID = awp.Atom_myCompany_Person_ID
                                 inner join Atom_myCompany amc on aoff.Atom_myCompany_ID = amc.ID
                                 inner join Atom_OrganisationData aorgd on  amc.Atom_OrganisationData_ID = aorgd.ID
                                 inner join Atom_Organisation ao on aorgd.Atom_Organisation_ID = ao.ID
                                 left join Invoice inv on pi.Invoice_ID = inv.ID
                                 left join Atom_cFirstName apfn on ap.Atom_cFirstName_ID = apfn.ID 
                                 left join Atom_cLastName apln on ap.Atom_cLastName_ID = apln.ID 
                                 left join MethodOfPayment mpay on inv.MethodOfPayment_ID = mpay.ID
                                 left join cOrgTYPE aorgd_cOrgTYPE on aorgd.cOrgTYPE_ID = aorgd_cOrgTYPE.ID
                                 left join Atom_cAddress_Org acaorg on aorgd.Atom_cAddress_Org_ID = acaorg.ID
                                 left join Atom_cStreetName_Org on acaorg.Atom_cStreetName_Org_ID = Atom_cStreetName_Org.ID
                                 left join Atom_cHouseNumber_Org on acaorg.Atom_cHouseNumber_Org_ID = Atom_cHouseNumber_Org.ID
                                 left join Atom_cCity_Org on acaorg.Atom_cCity_Org_ID = Atom_cCity_Org.ID
                                 left join Atom_cZIP_Org on acaorg.Atom_cZIP_Org_ID = Atom_cZIP_Org.ID
                                 left join Atom_cState_Org on acaorg.Atom_cState_Org_ID = Atom_cState_Org.ID
                                 left join Atom_cCountry_Org on acaorg.Atom_cCountry_Org_ID = Atom_cCountry_Org.ID
                                 left join cHomePage_Org on aorgd.cHomePage_Org_ID = cHomePage_Org.ID
                                 left join cEmail_Org on aorgd.cEmail_Org_ID = cEmail_Org.ID
                                 left join cHomePage_Org aorgd_hp  on aorgd.cHomePage_Org_ID = cHomePage_Org.ID
                                 left join cFaxNumber_Org on aorgd.cFaxNumber_Org_ID = cFaxNumber_Org.ID
                                 left join cPhoneNumber_Org on aorgd.cPhoneNumber_Org_ID = cPhoneNumber_Org.ID
                                 left join Atom_Logo on aorgd.Atom_Logo_ID = Atom_Logo.ID
                                 left join Atom_Customer_Org acusorg on acusorg.ID = pi.Atom_Customer_Org_ID
                                 left join Atom_Customer_Person acusper on acusper.ID = pi.Atom_Customer_Person_ID
                                 where pi.ID = " + ProformaInvoice_ID.ToString();
            }
            string Err = null;
            if (DBSync.DBSync.ReadDataTable(ref dt_ProformaInvoice, sql, ref Err))
            {
                if (dt_ProformaInvoice.Rows.Count == 1)
                {
                    try
                    {
                        Draft = DBTypes.tf._set_bool(dt_ProformaInvoice.Rows[0]["Draft"]);
                        GrossSum = DBTypes.tf._set_decimal(dt_ProformaInvoice.Rows[0]["GrossSum"]);
                        taxsum = DBTypes.tf._set_decimal(dt_ProformaInvoice.Rows[0]["TaxSum"]);
                        NetSum = DBTypes.tf._set_decimal(dt_ProformaInvoice.Rows[0]["NetSum"]);
                        

                        if (Program.b_FVI_SLO)
                        {

                            //this.FVI_SLO_RealEstateBP = new UniversalInvoice.FVI_SLO_RealEstateBP(lngToken.st_Invoice,
                            //                                                                             DBTypes.tf._set_int(dt_ProformaInvoice.Rows[0]["BuildingNumber"]),
                            //                                                                             DBTypes.tf._set_int(dt_ProformaInvoice.Rows[0]["BuildingSectionNumber"]),
                            //                                                                             DBTypes.tf._set_string(dt_ProformaInvoice.Rows[0]["Community"]),
                            //                                                                             DBTypes.tf._set_int(dt_ProformaInvoice.Rows[0]["CadastralNumber"]),
                            //                                                                             DBTypes.tf._set_DateTime(dt_ProformaInvoice.Rows[0]["ValidityDate"]),
                            //                                                                             DBTypes.tf._set_string(dt_ProformaInvoice.Rows[0]["ClosingTag"]),
                            //                                                                             DBTypes.tf._set_string(dt_ProformaInvoice.Rows[0]["SoftwareSupplier_TaxNumber"]),
                            //                                                                             DBTypes.tf._set_string(dt_ProformaInvoice.Rows[0]["PremiseType"])   );
                        }

                        byte[] barr_logoData = (byte[])dt_ProformaInvoice.Rows[0]["Logo_Data"];
                        MyOrganisation = new UniversalInvoice.Organisation(lngToken.st_My, DBTypes.tf._set_string(dt_ProformaInvoice.Rows[0]["Name"]),
                                                                   DBTypes.tf._set_string(dt_ProformaInvoice.Rows[0]["Tax_ID"]),
                                                                   DBTypes.tf._set_string(dt_ProformaInvoice.Rows[0]["Registration_ID"]),
                                                                   DBTypes.tf._set_string(dt_ProformaInvoice.Rows[0]["Atom_Office_Name"]),
                                                                   DBTypes.tf._set_string(dt_ProformaInvoice.Rows[0]["BankName"]),
                                                                   DBTypes.tf._set_string(dt_ProformaInvoice.Rows[0]["TRR"]),
                                                                   DBTypes.tf._set_string(dt_ProformaInvoice.Rows[0]["Email"]),
                                                                   DBTypes.tf._set_string(dt_ProformaInvoice.Rows[0]["HomePage"]),
                                                                   DBTypes.tf._set_string(dt_ProformaInvoice.Rows[0]["PhoneNumber"]),
                                                                   DBTypes.tf._set_string(dt_ProformaInvoice.Rows[0]["FaxNumber"]),
                                                                   DBTypes.tf._set_byte_array(dt_ProformaInvoice.Rows[0]["Logo_Data"]),
                                                                   DBTypes.tf._set_string(dt_ProformaInvoice.Rows[0]["StreetName"]),
                                                                   DBTypes.tf._set_string(dt_ProformaInvoice.Rows[0]["HouseNumber"]),
                                                                   DBTypes.tf._set_string(dt_ProformaInvoice.Rows[0]["ZIP"]),
                                                                   DBTypes.tf._set_string(dt_ProformaInvoice.Rows[0]["City"]),
                                                                   DBTypes.tf._set_string(dt_ProformaInvoice.Rows[0]["State"]),
                                                                   DBTypes.tf._set_string(dt_ProformaInvoice.Rows[0]["Country"]));


                        Invoice_ID = DBTypes.tf._set_long(dt_ProformaInvoice.Rows[0]["Invoice_ID"]);
                        FinancialYear = DBTypes.tf._set_int(dt_ProformaInvoice.Rows[0]["FinancialYear"]);
                        NumberInFinancialYear = DBTypes.tf._set_int(dt_ProformaInvoice.Rows[0]["NumberInFinancialYear"]);

                        if (Program.b_FVI_SLO)
                        {
                            if (!Draft)
                            {
                                this.Read_FURS_Response_Data(Invoice_ID);
                            }
                        }

                        object oAtom_MyOrganisation_Person_ID = dt_ProformaInvoice.Rows[0]["Atom_MyOrganisation_Person_ID"];
                        if (oAtom_MyOrganisation_Person_ID is long)
                        {
                            long Atom_MyOrganisation_Person_ID = (long)oAtom_MyOrganisation_Person_ID;
                            Invoice_Author = f_Atom_Person.GetData(lngToken.st_IssuerOfInvoice, Atom_MyOrganisation_Person_ID);
                        }

                        object oAtom_Customer_Org_ID = dt_ProformaInvoice.Rows[0]["Atom_Customer_Org_ID"];
                        if (oAtom_Customer_Org_ID is long)
                        {
                            long Atom_Customer_Org_ID = (long)oAtom_Customer_Org_ID;
                            CustomerOrganisation = f_Atom_OrganisationData.GetData(lngToken.st_Customer, Atom_Customer_Org_ID);
                        }
                        else
                        {
                            CustomerOrganisation = new UniversalInvoice.Organisation(lngToken.st_Customer);
                        }
                        
                        
                        if (dt_ProformaInvoice.Rows[0]["Atom_Customer_Person_ID"] is long)
                        {
                            long Atom_Customer_Person_ID = (long)dt_ProformaInvoice.Rows[0]["Atom_Customer_Person_ID"];
                            CustomerPerson = f_Atom_Person.GetData(lngToken.st_Customer, Atom_Customer_Person_ID);
                        }
                        else
                        {
                            CustomerPerson = new UniversalInvoice.Person(lngToken.st_Customer);
                        }


                        if (dbfunc.Read_ShopA_Price_Item_Table(ProformaInvoice_ID, ref dt_ShopA_Items))
                        {
                            if (m_ShopABC.Read_ShopB_Price_Item_Table(ProformaInvoice_ID, ref dt_ShopB_Items))
                            {

                                int iCountShopAItemsSold = dt_ShopA_Items.Rows.Count;
                                int iCountShopBItemsSold = dt_ShopB_Items.Rows.Count;
                                int iCountShopCItemsSold = m_ShopABC.m_CurrentInvoice.m_Basket.Atom_ProformaInvoice_Price_Item_Stock_Data_LIST.Count;

                                ItemsSold = new UniversalInvoice.ItemSold[iCountShopAItemsSold + iCountShopBItemsSold + iCountShopCItemsSold];
                                taxSum = new StaticLib.TaxSum();
                                Fill_Sold_ShopA_ItemsData(lngToken.st_Invoice, ref ItemsSold, 0, iCountShopAItemsSold);
                                Fill_Sold_ShopB_ItemsData(lngToken.st_Invoice, ref ItemsSold, iCountShopAItemsSold, iCountShopBItemsSold);
                                Fill_Sold_ShopC_ItemsData(lngToken.st_Invoice, ref ItemsSold, iCountShopAItemsSold + iCountShopBItemsSold, iCountShopCItemsSold);

                                InvoiceToken = new UniversalInvoice.InvoiceToken();

                                InvoiceToken.tFiscalYear.Set(FinancialYear.ToString());
                                InvoiceToken.tInvoiceNumber.Set(NumberInFinancialYear.ToString());
                                InvoiceToken.tCashier.Set(Properties.Settings.Default.CasshierName);

                                string stime = IssueDate_Day.ToString() + "."
                                               + IssueDate_Month.ToString() + "."
                                               + IssueDate_Year.ToString() + " "
                                               + IssueDate_Hour.ToString() + ":"
                                               + IssueDate_Min.ToString();
                                InvoiceToken.tDateOfIssue.Set(stime);
                                InvoiceToken.tDateOfMaturity.Set(stime);


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

            UniversalInvoice.Person xCustomerPerson = new UniversalInvoice.Person(lngToken.st_Customer,false,
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

        
        internal string Create_furs_InvoiceXML()
        {
            try
            {
                string InvoiceXmlTemplate = Properties.Resources.FVI_SLO_Invoice;
                XmlDocument xdoc = new XmlDocument();
                xdoc.LoadXml(InvoiceXmlTemplate);
                XmlNodeList ndl_TaxNumber = xdoc.GetElementsByTagName("fu:TaxNumber");
                //string sInnerText_MyOrgTaxID = Program.usrc_FVI_SLO1.FursD_MyOrgTaxID; // "10329048";//MyOrganisation.Tax_ID;
                ndl_TaxNumber.Item(0).InnerText = Program.usrc_FVI_SLO1.FursD_MyOrgTaxID; //MyOrganisation.Tax_ID;
                XmlNodeList ndl_IssueDateTime = xdoc.GetElementsByTagName("fu:IssueDateTime");
                ndl_IssueDateTime.Item(0).InnerText = fs.GetString(IssueDate_Year, 4) + "-"
                                                    + fs.GetString(IssueDate_Month, 2) + "-"
                                                    + fs.GetString(IssueDate_Day, 2) + "T"
                                                    + fs.GetString(IssueDate_Hour, 2) + ":"
                                                    + fs.GetString(IssueDate_Min, 2) + ":"
                                                    + fs.GetString(IssueDate_Sec, 2);
                XmlNodeList ndl_BusinessPremiseID = xdoc.GetElementsByTagName("fu:BusinessPremiseID");
                //string sInnerText_FursD_BussinesPremiseID = Program.usrc_FVI_SLO1.FursD_BussinesPremiseID;
                ndl_BusinessPremiseID.Item(0).InnerText = Program.usrc_FVI_SLO1.FursD_BussinesPremiseID; // "36CF"; //MyOrganisation.Atom_Office_Name;
                XmlNodeList ndl_ElectronicDeviceID = xdoc.GetElementsByTagName("fu:ElectronicDeviceID");
                ndl_ElectronicDeviceID.Item(0).InnerText = Properties.Settings.Default.CasshierName;
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

                XmlNodeList ndl_OperatorTaxNumber = xdoc.GetElementsByTagName("fu:OperatorTaxNumber");

                string sFursD_InvoiceAuthorTaxID = Program.usrc_FVI_SLO1.FursD_InvoiceAuthorTaxID;

                //Invoice_Author.Tax_ID = "59729481";

                Invoice_Author.Tax_ID = Program.usrc_FVI_SLO1.FursD_InvoiceAuthorTaxID;


                ndl_OperatorTaxNumber.Item(0).InnerText = Invoice_Author.Tax_ID;

                string InvoiceXml = XmlDcoumentToString(xdoc);
                return InvoiceXml;
            }
            catch (Exception Ex)
            {
                LogFile.Error.Show("ERROR:InvoiceData:Create_furs_InvoiceXML:Exception = " + Ex.Message);
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
            string stime = IssueDate_Day.ToString() + "."
                                           + IssueDate_Month.ToString() + "."
                                           + IssueDate_Year.ToString() + " "
                                           + IssueDate_Hour.ToString() + ":"
                                           + IssueDate_Min.ToString();
            InvoiceToken.tDateOfIssue.Set(stime);
            InvoiceToken.tDateOfMaturity.Set(stime);

            html_doc_template = html_doc_template.Replace(InvoiceToken.tFiscalYear.lt.s, InvoiceToken.tFiscalYear.replacement);
            html_doc_template = html_doc_template.Replace(InvoiceToken.tInvoiceNumber.lt.s, InvoiceToken.tInvoiceNumber.replacement);
            html_doc_template = html_doc_template.Replace(InvoiceToken.tIssuerOfInvoice.lt.s, InvoiceToken.tIssuerOfInvoice.replacement);
            html_doc_template = html_doc_template.Replace(InvoiceToken.tCashier.lt.s, InvoiceToken.tCashier.replacement);
            html_doc_template = html_doc_template.Replace(Invoice_Author.token.tFirstName.lt.s, Invoice_Author.token.tFirstName.replacement);
            html_doc_template = html_doc_template.Replace(Invoice_Author.token.tLastName.lt.s, Invoice_Author.token.tLastName.replacement);
            html_doc_template = html_doc_template.Replace(Invoice_Author.token.tTaxID.lt.s, Invoice_Author.token.tTaxID.replacement);

            foreach (UniversalInvoice.TemplateToken tt in CustomerOrganisation.token.list)
            {
                html_doc_template = html_doc_template.Replace(tt.lt.s, tt.replacement);
            }

            foreach (UniversalInvoice.TemplateToken tt in CustomerOrganisation.Address.token.list)
            {
                html_doc_template = html_doc_template.Replace(tt.lt.s, tt.replacement);
            }

            foreach (UniversalInvoice.TemplateToken tt in CustomerPerson.token.list)
            {
                html_doc_template = html_doc_template.Replace(tt.lt.s, tt.replacement);
            }

            foreach (UniversalInvoice.TemplateToken tt in CustomerPerson.Address.token.list)
            {
                html_doc_template = html_doc_template.Replace(tt.lt.s, tt.replacement);
            }


            foreach (UniversalInvoice.TemplateToken ivt in MyOrganisation.token.list)
            {
                if (ivt.replacement != null)
                {
                    html_doc_template = html_doc_template.Replace(ivt.lt.s, ivt.replacement);
                }
                else
                {
                    html_doc_template = html_doc_template.Replace(ivt.lt.s, "");
                }
            }

            foreach (UniversalInvoice.TemplateToken ivt in MyOrganisation.Address.token.list)
            {
                if (ivt.replacement != null)
                {
                    html_doc_template = html_doc_template.Replace(ivt.lt.s, ivt.replacement);
                }
                else
                {
                    html_doc_template = html_doc_template.Replace(ivt.lt.s, "");
                }
            }

            html_doc_template = html_doc_template.Replace(InvoiceToken.tDateOfIssue.lt.s, InvoiceToken.tDateOfIssue.replacement);
            html_doc_template = html_doc_template.Replace(InvoiceToken.tDateOfMaturity.lt.s, InvoiceToken.tDateOfMaturity.replacement);

            html_doc_template = html_doc_template.Replace(Invoice_FURS_Token.tUniqueMessageID.lt.s, Invoice_FURS_Token.tUniqueMessageID.replacement);
            html_doc_template = html_doc_template.Replace(Invoice_FURS_Token.tUniqueInvoiceID.lt.s, Invoice_FURS_Token.tUniqueInvoiceID.replacement);
            html_doc_template = html_doc_template.Replace(Invoice_FURS_Token.tQR.lt.s, Invoice_FURS_Token.tQR.replacement);


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
                            string sRow = tr_RowTemplate.Replace(itms.token.tItemName.lt.s, itms.token.tItemName.replacement);
                            sRow = sRow.Replace(itms.token.tPricePerUnit.lt.s, itms.token.tPricePerUnit.replacement);
                            sRow = sRow.Replace(itms.token.tTotalDiscount.lt.s, itms.token.tTotalDiscount.replacement);
                            sRow = sRow.Replace(itms.token.tCurrency.lt.s, itms.token.tCurrency.replacement);
                            sRow = sRow.Replace(itms.token.tUnit.lt.s, itms.token.tUnit.replacement);
                            sRow = sRow.Replace(itms.token.tQuantity.lt.s, itms.token.tQuantity.replacement);
                            sRow = sRow.Replace(itms.token.tTaxationRatePercent.lt.s, itms.token.tTaxationRatePercent.replacement);
                            sRow = sRow.Replace(itms.token.tNetPrice.lt.s, itms.token.tNetPrice.replacement);
                            sRow = sRow.Replace(itms.token.tTax.lt.s, itms.token.tTax.replacement);
                            sRow = sRow.Replace(itms.token.tPriceWithTax.lt.s, itms.token.tPriceWithTax.replacement);
                            html_doc_template = html_doc_template.Insert(ipos, sRow);
                            ipos += sRow.Length;
                        }


                        html_doc_template = html_doc_template.Replace(tCurrency.lt.s, tCurrency.replacement);

                        InvoiceToken.tSumNetPrice.Set(NetSum.ToString());
                        html_doc_template = html_doc_template.Replace(InvoiceToken.tSumNetPrice.lt.s, InvoiceToken.tSumNetPrice.replacement);


                        //string s_journal_invoice_type = lngRPM.s_journal_invoice_type_Print.s;
                        //string s_journal_invoice_description = Program.ReceiptPrinter.PrinterName;
                        //long journal_proformainvoice_id = -1;
                        //f_Journal_ProformaInvoice.Write(m_usrc_Print.ProformaInvoice_ID, Program.Atom_WorkPeriod_ID, s_journal_invoice_type, s_journal_invoice_description, null, ref journal_proformainvoice_id);
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
                                    string str = tr_TaxSum.Replace(InvoiceToken.tTaxRateName.lt.s, InvoiceToken.tTaxRateName.replacement);
                                    str = str.Replace(InvoiceToken.tSumTax.lt.s, InvoiceToken.tSumTax.replacement);
                                    html_doc_template = html_doc_template.Insert(ipos, str);
                                    ipos += str.Length;
                                }
                                InvoiceToken.tTotalSum.Set(GrossSum.ToString());
                                html_doc_template = html_doc_template.Replace(InvoiceToken.tTotalSum.lt.s, InvoiceToken.tTotalSum.replacement);
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
