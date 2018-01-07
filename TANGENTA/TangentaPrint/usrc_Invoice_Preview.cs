#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion

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
using TangentaDB;
using System.Drawing.Printing;
using TheArtOfDev.HtmlRenderer.PdfSharp;


namespace TangentaPrint
{
    public partial class usrc_Invoice_Preview : UserControl
    {
//        PdfGenerateConfig config = new PdfGenerateConfig();
        Size pageSize = new Size();

        PrintDocument pd = new PrintDocument();
        int iPage = 0;
        bool bFirstPagePrinting = false;
        Printer m_Printer = null;

        TheArtOfDev.HtmlRenderer.WinForms.HtmlContainer hc = new TheArtOfDev.HtmlRenderer.WinForms.HtmlContainer();

        public delegate void delegate_Exit();
        public event delegate_Exit Exit;

        public InvoiceData m_InvoiceData = null;
        private byte[] m_Doc = null;
        private GlobalData.ePaymentType m_paymentType;
        private string m_sPaymentMethod;
        private string m_sAmountReceived;
        private string m_sToReturn;
        private DateTime_v m_issue_time;

        public byte[] DocumentTemplate
        {
            get { return m_Doc; }
            set
            {
                m_Doc = value;
            }
        }

        public string html_doc_template_text
        {
            get
            {
                if (m_Doc != null)
                {
                    try
                    {
                        char[] chars2 = Encoding.Unicode.GetChars(m_Doc);
                        string shtml_doc_template_text = new string(chars2);
                        return shtml_doc_template_text;
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
                byte[] bytes = null;
                bytes = Encoding.UTF8.GetBytes(value);
                string myString = Encoding.UTF8.GetString(bytes);
                m_Doc = fs.GetBytes(myString);
            }
        }


        public string html_doc_text
        {
            get
            {
                if (m_Doc != null)
                {
                    try
                    {
                        bool bError = false;
                        char[] chars2 = Encoding.Unicode.GetChars(m_Doc);
                        string shtml_doc_text = new string(chars2);
                        HTML_PrintingElement_List HTML_RollPaperPrintingOutput = null;
                        StringBuilder sb_html_doc_text = new StringBuilder(shtml_doc_text, shtml_doc_text.Length * 4);
                        if (m_InvoiceData.CreateHTML_PrintingElementList(ref sb_html_doc_text, ref HTML_RollPaperPrintingOutput, ref bError))
                        {
                            this.htmlPanel1.Text = sb_html_doc_text.ToString();
                        }
                        return sb_html_doc_text.ToString();
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
                    bool bError = false;
                    HTML_PrintingElement_List HTML_RollPaperPrintingOutput = null;
                    string shtml_doc_text = value;
                    string s = null;
                    if (m_InvoiceData != null)
                    {
                        StringBuilder sb_html_doc_text = new StringBuilder(shtml_doc_text, shtml_doc_text.Length * 4);
                        m_InvoiceData.CreateHTML_PrintingElementList(ref sb_html_doc_text, ref HTML_RollPaperPrintingOutput, ref bError);
                        s = sb_html_doc_text.ToString();

                    }
                    else
                    {
                        s = shtml_doc_text;
                    }
                    this.htmlPanel1.Text = s;
                }
                catch (Exception ex)
                {
                    LogFile.Error.Show("ERROR:usrc_Invoice_Preview:propertiy:html_doc_text:Exception=" + ex.Message);
                }
            }
        }

        public double GetScreenPageHeight(TheArtOfDev.HtmlRenderer.Core.PageLayout pglayout)
        {
            if (pglayout.html_tag_name != null)
            {
                if (pglayout.html_tag_name.Equals("page"))
                {
                    return pglayout.HtmlTagRect.Height;
                }
                else if (pglayout.html_tag_name.Equals("style"))
                {
                    return -1;
                }
            }
            foreach (TheArtOfDev.HtmlRenderer.Core.PageLayout pgl in pglayout.Child_HtmlTag_PageLayout)
            {
                double page_height = GetScreenPageHeight(pgl);
                if (page_height > 0)
                {
                    return page_height;
                }
            }
            return -1;
        }

        private void ShowErrList(List<string> m_ErrList)
        {
            string sErrorReport = "Number of Errors = " + m_ErrList.Count.ToString() + "\r\n";
            int i = 0;
            foreach (string s in m_ErrList)
            {
                i++;
                sErrorReport += i.ToString() + ":" + s + "\r\n\r\n";
            }
            ltext xltext = new ltext();
            xltext.s = sErrorReport;

            XMessage.Box.Show(this, false, xltext);
        }

        public bool ShowPreview(Printer printer, string shtml_doc_text)
        {
            StringBuilder sb_html_doc_text = new StringBuilder(shtml_doc_text, shtml_doc_text.Length * 3); 
            if (printer != null)
            {
                try
                {
                    List<string> m_ErrList = new List<string>();
                    m_Printer = printer;
                    HTML_PrintingElement_List HTML_Printing_ElementList = null;
                    string s = null;
                    PrinterSettings psettings = new PrinterSettings();
                    psettings.PrinterName = printer.PrinterName;

                    if (m_InvoiceData != null)
                    {
                        bool bError = false;
                        if (m_InvoiceData.CreateHTML_PrintingElementList(ref sb_html_doc_text, ref HTML_Printing_ElementList, ref bError))
                        {
                            TheArtOfDev.HtmlRenderer.Core.PageLayout pglayout = null;

                            // now get roll paper layout
                            s = sb_html_doc_text.ToString();
                            this.htmlPanel1.GetPages(s, ref pglayout);

                            // set layout of elements
                            HTML_Printing_ElementList.SetLayout(pglayout);
                            double xPageHeight = 0;

                            if (psettings.DefaultPageSettings.PaperSize.Height > 1122.51 * 2)
                            {
                                xPageHeight = psettings.DefaultPageSettings.PaperSize.Height;
                            }
                            else
                            {
                                xPageHeight = 1122.51;
                            }
                            if (pglayout.OnePageSize(xPageHeight, xPageHeight/40, xPageHeight / 7.5))
                            {
                                m_InvoiceData.InsertPageNumbers(ref sb_html_doc_text);
                                s = sb_html_doc_text.ToString();
                            }
                            else
                            {
                                sb_html_doc_text = m_InvoiceData.CreateHTML_PagePaperPrintingOutput(HTML_Printing_ElementList, xPageHeight);
                                m_InvoiceData.InsertPageNumbers(ref sb_html_doc_text);
                            }
                        }
                        this.htmlPanel1.Text = s;
                        HtmlDoc.HtmlDoc html_doc = new HtmlDoc.HtmlDoc(s);
                        html_doc.Parse(ref m_ErrList);
                        if (m_ErrList.Count > 0)
                        {
                            ShowErrList(m_ErrList);
                        }

                        return true;
                    }
                    else
                    {
                        s = shtml_doc_text;
                        this.htmlPanel1.Text = s;
                        HtmlDoc.HtmlDoc html_doc = new HtmlDoc.HtmlDoc(s);
                        html_doc.Parse(ref m_ErrList);
                        if (m_ErrList.Count > 0)
                        {
                            ShowErrList(m_ErrList);
                        }
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    LogFile.Error.Show("ERROR:usrc_Invoice_Preview:ShowPreview:Exception=" + ex.Message);
                    return false;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:usrc_Invoice_Preview:ShowPreview: Printer is not defined ! (printer == null)");
                return false;
            }

        }


        public usrc_Invoice_Preview()
        {
            InitializeComponent();
            lng.s_btn_Tokens.Text(btn_Tokens);
            pd.PrintPage += Pd_PrintPage;
            //string html_doc = Properties.Resources.html_doc;

        }
        public bool Init(byte[] xdoc,Printer printer, InvoiceData xInvoiceData, GlobalData.ePaymentType xpaymentType, string sPaymentMethod, string sAmountReceived, string sToReturn, DateTime_v issue_time)
        {
            m_InvoiceData = xInvoiceData;
            m_paymentType = xpaymentType;
            m_sPaymentMethod = sPaymentMethod;
            m_sAmountReceived = sAmountReceived;
            m_sToReturn = sToReturn;
            m_issue_time = issue_time;
            m_Doc = xdoc;
            char[] chars2 = Encoding.Unicode.GetChars(m_Doc);
            string shtml_doc_text = new string(chars2);
            this.ShowPreview(printer,shtml_doc_text);
            this.btn_Print.Enabled = true;
            return true;
        }

        public bool Init(InvoiceData xInvoiceData)
        {
            m_InvoiceData = xInvoiceData;
            this.htmlPanel1.Text = "HTML Predloga ni določena, brez nje pa ne morete tiskati računa.";
            //this.m_webBrowser.Refresh();
            this.btn_Print.Enabled = false;
            return true;
        }


    private void btn_Print_Click(object sender, EventArgs e)
        {
            pd.PrinterSettings.PrinterName = m_Printer.PrinterName;          
            //config.PageSize = PageSize.A4;
            //config.SetMargins(20);

            //XSize xorgPageSize = PageSizeConverter.ToSize(config.PageSize);
            //Size orgPageSize = new Size(Convert.ToInt32(xorgPageSize.Width), Convert.ToInt32(xorgPageSize.Height));
            //            pageSize = new Size(Convert.ToInt32(orgPageSize.Width - config.MarginLeft - config.MarginRight), Convert.ToInt32(orgPageSize.Height - config.MarginTop - config.MarginBottom));

            pageSize = new Size(Convert.ToInt32(pd.PrinterSettings.DefaultPageSettings.PrintableArea.Size.Width), Convert.ToInt32(pd.PrinterSettings.DefaultPageSettings.PrintableArea.Size.Height));


            hc.UseGdiPlusTextRendering = true;
            hc.ScrollOffset = new Point(0, 0);

            iPage = 0;
            bFirstPagePrinting = true;
            pd.Print();

        }

        private void Pd_PrintPage(object sender, PrintPageEventArgs e)
        {

            if (bFirstPagePrinting)
            {
                string shtml = htmlPanel1.Text;
                hc.SetHtml(shtml);
                bFirstPagePrinting = false;
                hc.PerformLayout(e.Graphics);
                hc.GetPages();
                if (hc.PageListCount > 0)
                {
                    //hc.Location = new PointF(config.MarginLeft, config.MarginTop);
                    hc.MaxSize = new Size(Convert.ToInt32(pageSize.Width), 0);
                }
            }

            if (hc.PageListCount > 0)
            {
                if (iPage <= hc.PageListCount - 1)
                {
                    if (iPage == hc.PageListCount - 1)
                    {
                        hc.PerformPrint(e.Graphics, iPage);
                        e.HasMorePages = false;
                    }
                    else
                    {
                        hc.PerformPrint(e.Graphics, iPage);
                        e.HasMorePages = true;
                        iPage++;
                    }

                }
                else
                {

                }
            }
            else
            {
                hc.ScrollOffset = new Point(0, 0);
                hc.PerformPaint(e.Graphics);
                e.HasMorePages = false;
            }
        }

        private void btn_SaveAs_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            DialogResult dres = sfd.ShowDialog();
            if (dres == DialogResult.OK)
            {
                string sFileName = sfd.FileName;
                System.IO.File.WriteAllText(sFileName, this.htmlPanel1.Text, Encoding.UTF8);
            }
        }

        private void btn_Tokens_Click(object sender, EventArgs e)
        {
            Form_TemplateTokens frm_tokens = new Form_TemplateTokens(m_InvoiceData);
            frm_tokens.ShowDialog();
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            if (Exit != null)
            {
                Exit();
            }
        }
    }
}
