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
        public InvoiceData m_InvoiceData = null;
        private byte[] m_Doc = null;
        private usrc_Printer m_usrc_Print;
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
            lngRPM.s_btn_Tokens.Text(btn_Tokens);
            //string html_doc = Properties.Resources.html_doc;

        }
        public bool Init(byte[] xdoc, usrc_Printer xusrc_Print, usrc_Payment.ePaymentType xpaymentType, string sPaymentMethod, string sAmountReceived, string sToReturn, DateTime_v issue_time)
        {
            m_Doc = xdoc;
            m_usrc_Print = xusrc_Print;
            m_paymentType = xpaymentType;
            m_sPaymentMethod = sPaymentMethod;
            m_sAmountReceived = sAmountReceived;
            m_sToReturn = sToReturn;
            m_issue_time = issue_time;
            string s = CreateHTMLInvoiceFromTemplate(lngToken.st_Invoice,html_doc_text,Program.GetPaymentTypeString(xpaymentType));

            this.m_webBrowser.DocumentText = s;
            this.m_webBrowser.Refresh();
            this.btn_Print.Enabled = true;
            return true;
        }

        public bool Init(InvoiceData xInvoiceData)
        {
            m_InvoiceData = xInvoiceData;
            this.m_webBrowser.DocumentText = "HTML Predloga ni določena, brez nje pa ne morete tiskati računa.";
            this.m_webBrowser.Refresh();
            this.btn_Print.Enabled = false;
            return true;
        }

        public void Fill_SoldSimpleItemsData(ltext lt_token_prefix,ref UniversalInvoice.ItemSold[] ItemsSold, int start_index,int count)
        {
            int i;
            int end_index = start_index + count;
            int j = 0;
            for (i = start_index; i < end_index; i++)
            {
                DataRow dr = m_usrc_Print.m_InvoiceData.dt_Atom_Price_SimpleItem.Rows[j];

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

                lt_token_prefix.AddAtTheEnd(lngToken.st_Simple);

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


                ItemsSold[i] = new UniversalInvoice.ItemSold(lt_token_prefix,
                                                             DBTypes.func._set_string(dr["Name"]),
                                                             DBTypes.func._set_decimal(dr["RetailSimpleItemPrice"]),
                                                             "", // no unit
                                                             DBTypes.func._set_decimal(dr["RetailSimpleItemPriceWithDiscount"]),
                                                             DBTypes.func._set_string(dr["Atom_Taxation_Name"]),
                                                             Convert.ToDecimal(DBTypes.func._set_int(dr["iQuantity"])),
                                                             DBTypes.func._set_decimal(dr["Discount"]),
                                                             DBTypes.func._set_decimal(dr["ExtraDiscount"]),
                                                             DBTypes.func._set_string(dr["Atom_Currency_Symbol"]),
                                                             DBTypes.func._set_decimal(dr["Atom_Taxation_Rate"]),
                                                             DBTypes.func._set_decimal(TotalDiscount),
                                                             DBTypes.func._set_decimal(price_without_tax),
                                                             DBTypes.func._set_decimal(dr["TaxPrice"]),
                                                             DBTypes.func._set_decimal(dr["RetailSimpleItemPriceWithDiscount"]));

                j++;
            }

        }

        public void Fill_SoldItemsData(ltext lt_token_prefix,ref UniversalInvoice.ItemSold[] ItemsSold, int start_index, int count)
        {

            int i;
            int end_index = start_index + count;
            int j = 0;


            for (i = start_index; i < end_index; i++)
            {
                Atom_ProformaInvoice_Price_Item_Stock_Data appisd = (Atom_ProformaInvoice_Price_Item_Stock_Data)m_usrc_Print.m_InvoiceData.m_InvoiceDB.m_CurrentInvoice.m_Basket.Atom_ProformaInvoice_Price_Item_Stock_Data_LIST[j];

                decimal Discount = appisd.Discount.v;

                decimal ExtraDiscount = appisd.ExtraDiscount.v;

                decimal TotalDiscount = StaticLib.Func.TotalDiscount(Discount, ExtraDiscount, Program.Get_BaseCurrency_DecimalPlaces());

                decimal Atom_Taxation_Rate = appisd.Atom_Taxation_Rate.v;

                decimal RetailItemsPriceWithDiscount = 0;
                decimal ItemsTaxPrice = 0;
                decimal ItemsNetPrice = 0;

                int decimal_places = appisd.Atom_Currency_DecimalPlaces.v;

                decimal RetailPricePerUnit = appisd.RetailPricePerUnit.v;
                decimal dQuantity = appisd.dQuantity_FromStock + appisd.dQuantity_FromFactory;

                StaticLib.Func.CalculatePrice(RetailPricePerUnit, dQuantity, Discount, ExtraDiscount, Atom_Taxation_Rate, ref RetailItemsPriceWithDiscount, ref ItemsTaxPrice, ref ItemsNetPrice, decimal_places);


                ItemsSold[i] = new UniversalInvoice.ItemSold(lt_token_prefix,
                                                             DBTypes.func._set_string(appisd.Atom_Item_UniqueName.v),
                                                             DBTypes.func._set_decimal(appisd.RetailPricePerUnit.v),
                                                             DBTypes.func._set_string(appisd.Atom_Item_UniqueName.v),
                                                             DBTypes.func._set_decimal(appisd.RetailPriceWithDiscount.v),
                                                             DBTypes.func._set_string(appisd.Atom_Taxation_Name.v),
                                                             DBTypes.func._set_decimal(appisd.RetailPriceWithDiscount.v),
                                                             DBTypes.func._set_decimal(appisd.Discount.v),
                                                             DBTypes.func._set_decimal(appisd.ExtraDiscount.v),
                                                             DBTypes.func._set_string(appisd.Atom_Currency_Symbol.v),
                                                             DBTypes.func._set_decimal(appisd.Atom_Taxation_Rate.v),
                                                             DBTypes.func._set_decimal(TotalDiscount),
                                                             DBTypes.func._set_decimal(ItemsNetPrice),
                                                             DBTypes.func._set_decimal(ItemsTaxPrice),
                                                             DBTypes.func._set_decimal(RetailItemsPriceWithDiscount));

                j++;
            }

        }

        private string CreateHTMLInvoiceFromTemplate(ltext token_prefix,string html_doc_text, string payment_type)
        {

            int iCountSimpleItemsSold = m_usrc_Print.m_InvoiceData.dt_Atom_Price_SimpleItem.Rows.Count;
            int iCountItemsSold = m_usrc_Print.m_InvoiceData.m_InvoiceDB.m_CurrentInvoice.m_Basket.Atom_ProformaInvoice_Price_Item_Stock_Data_LIST.Count;

            UniversalInvoice.ItemSold[] ItemsSold = new UniversalInvoice.ItemSold[iCountSimpleItemsSold+ iCountItemsSold];
            ltext lt_SoldSimpleItemsData = token_prefix.AddAtTheEnd(lngToken.st_Simple);
            Fill_SoldSimpleItemsData(lt_SoldSimpleItemsData, ref ItemsSold,0, iCountSimpleItemsSold);
            ltext lt_SoldItemsData = token_prefix.AddAtTheEnd(lngToken.st_Physical);
            Fill_SoldItemsData(lt_SoldItemsData,ref ItemsSold, iCountSimpleItemsSold, iCountItemsSold);

            UniversalInvoice.InvoiceTemplate invt = new UniversalInvoice.InvoiceTemplate(m_usrc_Print.m_InvoiceData.MyOrganisation, m_usrc_Print.m_InvoiceData.CustomerOrganisation);

            if (m_issue_time != null)
            {
                m_usrc_Print.PrintDate_Day = m_issue_time.v.Day;
                m_usrc_Print.PrintDate_Month = m_issue_time.v.Month;
                m_usrc_Print.PrintDate_Year = m_issue_time.v.Year;
                m_usrc_Print.PrintDate_Hour = m_issue_time.v.Hour;
                m_usrc_Print.PrintDate_Min = m_issue_time.v.Minute;
            }

            return invt.CreateHTML(ref html_doc_text,
                                   m_usrc_Print.m_InvoiceData.FinancialYear,
                                   m_usrc_Print.m_InvoiceData.NumberInFinancialYear,
                                   m_usrc_Print.m_InvoiceData.MyOrganisation,
                                   "Blagajna1", //Organisation casshier
                                   m_usrc_Print.m_InvoiceData.Customer,
                                   m_usrc_Print.PrintDate_Day,
                                   m_usrc_Print.PrintDate_Month,
                                   m_usrc_Print.PrintDate_Year,
                                   m_usrc_Print.PrintDate_Hour,
                                   m_usrc_Print.PrintDate_Min,
                                   ItemsSold,
                                   m_usrc_Print.m_InvoiceData.NetSum,
                                   m_usrc_Print.m_InvoiceData.GrossSum,
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

        private void btn_Tokens_Click(object sender, EventArgs e)
        {
            Form_TemplateTokens frm_tokens = new Form_TemplateTokens(m_InvoiceData);
            frm_tokens.ShowDialog();
        }
    }
}
