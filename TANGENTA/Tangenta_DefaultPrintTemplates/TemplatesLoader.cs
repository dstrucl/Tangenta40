using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace Tangenta_DefaultPrintTemplates
{
    public static class TemplatesLoader
    {

        public static string[] My_Organisation_OfficeShortName_TOKEN = new string[] { "(@@My_Organisation_OfficeShortName@@)", "(@@Moja_Organizacija_PoslovnaEnotaKratkoIme@@)" };
        public static string[] Invoice_Cashier_TOKEN = new string[] { "(@@Invoice_Cashier@@)", "(@@Račun_OznakaBlagajne@@)" };
        public static string[] Invoice_Number_TOKEN = new string[] { "(@@Invoice_Number@@)", "(@@Račun_Številka@@)" };
        public static string[] Invoice_FiscalYear_TOKEN = new string[] { "(@@Invoice_FiscalYear@@)", "(@@Račun_ObračunskoLeto@@)" };
        public static string[] Invoice_Storno_TOKEN = new string[] { "(@@Invoice_Storno@@)", "(@@Račun_Stornacija@@)" };

        public static string[] InvoiceNumberTemplate_TOKEN = new string[] { "(@@@InvoiceNumberTemplate@@@)", "(@@@PredlogaŠtevilkeRačuna@@@)" };
        public static string[] InvoiceNumberTemplate = new string[] { "", "" };

        /// <summary>
        /// Templates to showcase the HTML Renderer capabilities
        /// </summary>
        private static readonly List<HtmlTemplate> _templates = new List<HtmlTemplate>();



        /// <summary>
        /// Init.
        /// </summary>
        public static void Init()
        {
            LoadSamples();
        }

        /// <summary>
        /// Samples to showcase the HTML Renderer capabilities
        /// </summary>
        public static List<HtmlTemplate> Templates
        {
            get { return _templates; }
        }

    
        /// <summary>
        /// Loads the tree of document samples
        /// </summary>
        private static void LoadSamples()
        {
            InvoiceNumberTemplate[LanguageControl.DynSettings.English_ID] = SetInvoiceNumberFormat_TEMPLATE(LanguageControl.DynSettings.English_ID);
            InvoiceNumberTemplate[LanguageControl.DynSettings.Slovensko_ID] = SetInvoiceNumberFormat_TEMPLATE(LanguageControl.DynSettings.Slovensko_ID);

            var names = Assembly.GetExecutingAssembly().GetManifestResourceNames();
            Array.Sort(names);
            foreach (string name in names)
            {
                int extPos = name.LastIndexOf('.');
                int namePos = extPos > 0 && name.Length > 1 ? name.LastIndexOf('.', extPos - 1) : 0;
                string ext = name.Substring(extPos >= 0 ? extPos : 0);
                string shortName = namePos > 0 && name.Length > 2 ? name.Substring(namePos + 1, name.Length - namePos - ext.Length - 1) : name;

                if (".htm".IndexOf(ext, StringComparison.Ordinal) >= 0)
                {
                    var resourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(name);
                    if (resourceStream != null)
                    {
                        using (var sreader = new StreamReader(resourceStream, Encoding.Default))
                        {
                            string html = sreader.ReadToEnd();
                            html = html.Replace(InvoiceNumberTemplate_TOKEN[LanguageControl.DynSettings.English_ID], InvoiceNumberTemplate[LanguageControl.DynSettings.English_ID]);
                            html = html.Replace(InvoiceNumberTemplate_TOKEN[LanguageControl.DynSettings.Slovensko_ID], InvoiceNumberTemplate[LanguageControl.DynSettings.Slovensko_ID]);
                            _templates.Add(new HtmlTemplate(shortName, name, html));
                        }
                    }
                }
            }
        }

        private static string SetInvoiceNumberFormat_TEMPLATE(int ilang)
        {
            return My_Organisation_OfficeShortName_TOKEN[ilang] + "-" + Invoice_Cashier_TOKEN[ilang] + "-" + Invoice_Number_TOKEN[ilang] + "/" + Invoice_FiscalYear_TOKEN[ilang] + " " + Invoice_Storno_TOKEN[ilang];
        }

        public static string SetInvoiceNumber(string xAtomOfficeShortName,
                                              string xAtomElectronicDeviceName,
                                              int xNumberInFinancialYear,
                                              int xFinancialYear,
                                              bool bStorno,
                                              string storno_in_language)
        {
            int ilang = LanguageControl.DynSettings.LanguageID;
            string sInvoiceNum = InvoiceNumberTemplate[ilang];
            sInvoiceNum = sInvoiceNum.Replace(My_Organisation_OfficeShortName_TOKEN[ilang], xAtomOfficeShortName);
            sInvoiceNum = sInvoiceNum.Replace(Invoice_Cashier_TOKEN[ilang], xAtomElectronicDeviceName);
            sInvoiceNum = sInvoiceNum.Replace(Invoice_Number_TOKEN[ilang], xNumberInFinancialYear.ToString());
            sInvoiceNum = sInvoiceNum.Replace(Invoice_FiscalYear_TOKEN[ilang], xFinancialYear.ToString());
            if (bStorno)
            {
                sInvoiceNum = sInvoiceNum.Replace(Invoice_Storno_TOKEN[ilang], storno_in_language);
            }
            else
            {
                sInvoiceNum = sInvoiceNum.Replace(Invoice_Storno_TOKEN[ilang], "");
            }
            return sInvoiceNum;
        }
    }
}