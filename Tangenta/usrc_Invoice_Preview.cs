using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LanguageControl;
using System.Runtime.InteropServices;
using DBConnectionControl40;
using DBTypes;

namespace Tangenta
{
    public partial class usrc_Invoice_Preview : UserControl
    {
        private byte[] m_Doc = null;
        private usrc_Print m_usrc_Print;
        private usrc_Payment.ePaymentType m_paymentType;
        private string m_sPaymentMethod;
        private string m_sAmountReceived;
        private string m_sToReturn;
        private DateTime_v m_issue_time;

        public string html_doc_text
        {
            get
            {
                if (m_Doc != null)
                {
                    try
                    {
                        char[] chars = Encoding.UTF8.GetChars(m_Doc);
                        string s = new string(chars);
                        return s;
                    }
                    catch
                    {
                        return "Error can not decode template!";
                    }
                }
                else
                {
                    return "Document Template not set";
                }
            }

            set
            {
                try
                {
                    m_Doc = System.Text.Encoding.UTF8.GetBytes(value);
                }
                catch (Exception ex)
                {
                    LogFile.Error.Show("ERROR:usrc_Invoice_Preview:propertiy:html_doc_text:Exception=" + ex.Message);
                }
            }
        }

        private usrc_InvoiceMan m_usrc_InvoiceMan = null;


        public usrc_Invoice_Preview()
        {
            InitializeComponent();

            //string html_doc = Properties.Resources.html_doc;

        }
        public bool Init(byte[] xdoc, usrc_Print xusrc_Print, usrc_Payment.ePaymentType xpaymentType, string sPaymentMethod, string sAmountReceived, string sToReturn, DateTime_v issue_time)
        {
            m_Doc = xdoc;
            m_usrc_Print = xusrc_Print;
            m_paymentType = xpaymentType;
            m_sPaymentMethod = sPaymentMethod;
            m_sAmountReceived = sAmountReceived;
            m_sToReturn = sToReturn;
            m_issue_time = issue_time;
            string s = CreateHTMLInvoiceFromTemplate(html_doc_text,Program.GetPaymentTypeString(xpaymentType));

            this.m_webBrowser.DocumentText = s;
            this.m_webBrowser.Refresh();
            return true;
        }

        public void Fill_SoldSimpleItemsData(ref UniversalInvoice.ItemSold[] ItemsSold, int start_index,int count)
        {
            int i;
            int end_index = start_index + count;
            int j = 0;
            for (i = start_index; i < end_index; i++)
            {
                DataRow dr = m_usrc_Print.dt_Atom_Price_SimpleItem.Rows[j];
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
                }

                int iQuantity = -1;
                object oQuantity = dr["iQuantity"];
                if (oQuantity is int)
                {
                    iQuantity = (int)oQuantity;
                }

                decimal dQuantity = Convert.ToDecimal(iQuantity);
                
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

                decimal TotalDiscount = StaticLib.Func.TotalDiscount(Discount, ExtraDiscount, Program.Get_BaseCurrency_DecimalPlaces());
                decimal TotalDiscountPercent = TotalDiscount * 100;
                if (TotalDiscountPercent > 0)
                {

                }

                if (TotalDiscountPercent > 0)
                {
                }
                else
                {
                }

                decimal price_without_tax = RetailSimpleItemPriceWithDiscount - TaxPrice;

                ItemsSold[i] = new UniversalInvoice.ItemSold(SimpleItem_name,
                                                                              RetailSimpleItemPrice,
                                                                              "", /* Unit Name not defined */
                                                                              RetailSimpleItemPriceWithDiscount,
                                                                              TaxationName,
                                                                              dQuantity,
                                                                              Discount,
                                                                              ExtraDiscount,
                                                                              CurrencySymbol,
                                                                              (decimal)dr["Atom_Taxation_Rate"],
                                                                              TotalDiscount,
                                                                              price_without_tax,
                                                                              TaxPrice,
                                                                              RetailSimpleItemPriceWithDiscount);
                j++;
            }

        }

        public void Fill_SoldItemsData(ref UniversalInvoice.ItemSold[] ItemsSold, int start_index, int count)
        {

            int i;
            int end_index = start_index + count;
            int j = 0;
            for (i = start_index; i < end_index; i++)
            {
                Atom_ProformaInvoice_Price_Item_Stock_Data appisd = (Atom_ProformaInvoice_Price_Item_Stock_Data)m_usrc_Print.m_InvoiceDB.m_CurrentInvoice.m_Basket.Atom_ProformaInvoice_Price_Item_Stock_Data_LIST[j];

                string Item_UniqueName = appisd.Atom_Item_UniqueName.v;

                decimal RetailPricePerUnit = appisd.RetailPricePerUnit.v;

                decimal RetailItemPriceWithDiscount = appisd.RetailPriceWithDiscount.v;

                decimal dQuantity = appisd.dQuantity_FromStock + appisd.dQuantity_FromFactory;

                string Atom_Unit_Name = appisd.Atom_Unit_Name.v;

                decimal Discount = appisd.Discount.v;

                decimal ExtraDiscount = appisd.ExtraDiscount.v;

                decimal TotalDiscount = StaticLib.Func.TotalDiscount(Discount, ExtraDiscount, Program.Get_BaseCurrency_DecimalPlaces());
                decimal TotalDiscountPercent = TotalDiscount * 100;
                if (TotalDiscountPercent > 0)
                {
                }

                decimal Atom_Taxation_Rate = appisd.Atom_Taxation_Rate.v;

                decimal RetailItemsPriceWithDiscount = 0;
                decimal ItemsTaxPrice = 0;
                decimal ItemsNetPrice = 0;

                int decimal_places = appisd.Atom_Currency_DecimalPlaces.v;

                StaticLib.Func.CalculatePrice(RetailPricePerUnit, dQuantity, Discount, ExtraDiscount, Atom_Taxation_Rate, ref RetailItemsPriceWithDiscount, ref ItemsTaxPrice, ref ItemsNetPrice, decimal_places);

                if (TotalDiscountPercent > 0)
                {
                }
                else
                {
                }

                string TaxationName = appisd.Atom_Taxation_Name.v;

                decimal TaxPrice = appisd.TaxPrice.v;

                ItemsSold[i] = new UniversalInvoice.ItemSold(Item_UniqueName,
                                                                              RetailPricePerUnit,
                                                                              appisd.Atom_Unit_Name.vs,
                                                                              RetailItemPriceWithDiscount,
                                                                              TaxationName,
                                                                              appisd.dQuantity_all.v,
                                                                              TotalDiscountPercent,
                                                                              ExtraDiscount,
                                                                              appisd.Atom_Currency_Symbol.v,
                                                                              appisd.Atom_Taxation_Rate.v,
                                                                              TotalDiscountPercent,
                                                                              ItemsNetPrice,
                                                                              ItemsTaxPrice,
                                                                              RetailItemsPriceWithDiscount
                                                                              );
                j++;
            }

        }

        private string CreateHTMLInvoiceFromTemplate(string html_doc_text, string payment_type)
        {

            int iCountSimpleItemsSold = m_usrc_Print.dt_Atom_Price_SimpleItem.Rows.Count;
            int iCountItemsSold = m_usrc_Print.m_InvoiceDB.m_CurrentInvoice.m_Basket.Atom_ProformaInvoice_Price_Item_Stock_Data_LIST.Count;

            UniversalInvoice.ItemSold[] ItemsSold = new UniversalInvoice.ItemSold[iCountSimpleItemsSold+ iCountItemsSold];

            Fill_SoldSimpleItemsData(ref ItemsSold,0, iCountSimpleItemsSold);
            Fill_SoldItemsData(ref ItemsSold, iCountSimpleItemsSold, iCountItemsSold);


            UniversalInvoice.InvoiceTemplate invt = new UniversalInvoice.InvoiceTemplate(m_usrc_Print.MyOrganisation, m_usrc_Print.CustomerOrganisation);

            if (m_issue_time != null)
            {
                m_usrc_Print.PrintDate_Day = m_issue_time.v.Day;
                m_usrc_Print.PrintDate_Month = m_issue_time.v.Month;
                m_usrc_Print.PrintDate_Year = m_issue_time.v.Year;
                m_usrc_Print.PrintDate_Hour = m_issue_time.v.Hour;
                m_usrc_Print.PrintDate_Min = m_issue_time.v.Minute;
            }

            return invt.CreateHTML(ref html_doc_text,
                                   m_usrc_Print.FinancialYear,
                                   m_usrc_Print.NumberInFinancialYear,
                                   m_usrc_Print.MyOrganisation,
                                   "Blagajna1", //Organisation casshier
                                   m_usrc_Print.Customer,
                                   m_usrc_Print.PrintDate_Day,
                                   m_usrc_Print.PrintDate_Month,
                                   m_usrc_Print.PrintDate_Year,
                                   m_usrc_Print.PrintDate_Hour,
                                   m_usrc_Print.PrintDate_Min,
                                   ItemsSold,
                                   m_usrc_Print.NetSum,
                                   m_usrc_Print.GrossSum,
                                   payment_type,
                                   Program.Get_BaseCurrency_DecimalPlaces());
        
    }

    private void btn_Print_Click(object sender, EventArgs e)
        {
            m_webBrowser.ShowPrintDialog();
        }

        private void btn_SaveAs_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            DialogResult dres = sfd.ShowDialog();
            if (dres == DialogResult.OK)
            {
                string sFileName = sfd.FileName;
                System.IO.File.WriteAllText(sFileName, this.m_webBrowser.DocumentText, Encoding.UTF8);
            }
        }
    }
}
