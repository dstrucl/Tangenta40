﻿#region LICENSE 
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
using PdfSharp;
using PdfSharp.Drawing;

namespace TangentaPrint
{
    public partial class usrc_Invoice_Preview : UserControl
    {
        PdfGenerateConfig config = new PdfGenerateConfig();
        Size pageSize = new Size();

        PrintDocument pd = new PrintDocument();
        int scrollOffset = 0;
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
                        char[] chars2 = Encoding.Unicode.GetChars(m_Doc);
                        string shtml_doc_text = new string(chars2);
                        HTML_PrintingElement_List HTML_RollPaperPrintingOutput = null;
                        string s = m_InvoiceData.CreateHTML_PrintingElementList(ref shtml_doc_text, ref HTML_RollPaperPrintingOutput);
                        this.htmlPanel1.Text = s;
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
                    HTML_PrintingElement_List HTML_RollPaperPrintingOutput = null;
                    string shtml_doc_text = value;
                    string s = null;
                    if (m_InvoiceData != null)
                    {

                        s = m_InvoiceData.CreateHTML_PrintingElementList(ref shtml_doc_text,ref HTML_RollPaperPrintingOutput);
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

        public bool ShowPreview(Printer printer, string shtml_doc_text)
        {
            if (printer != null)
            {
                try
                {
                    m_Printer = printer;
                    HTML_PrintingElement_List HTML_Printing_ElementList = null;
                    string s = null;
                    double xPageHeight = 1122.51;
                    PrinterSettings psettings = new PrinterSettings();
                    psettings.PrinterName = printer.PrinterName;
                    xPageHeight = psettings.DefaultPageSettings.PaperSize.Height;

                    if (m_InvoiceData != null)
                    {
                        s = m_InvoiceData.CreateHTML_PrintingElementList(ref shtml_doc_text, ref HTML_Printing_ElementList);

                        TheArtOfDev.HtmlRenderer.Core.PageLayout pglayout = null;

                        // now get roll paper layout
                        this.htmlPanel1.GetPages(s, ref pglayout);

                        // set layout of elements
                        HTML_Printing_ElementList.SetLayout(pglayout);

                        if (pglayout.OnePageSize(xPageHeight, 0, 0))
                        {
                            s = m_InvoiceData.InsertPageNumbers(s);
                        }
                        else
                        {
                            s = m_InvoiceData.CreateHTML_PagePaperPrintingOutput(HTML_Printing_ElementList, xPageHeight);
                            s = m_InvoiceData.InsertPageNumbers(s);
                        }
                        this.htmlPanel1.Text = s;
                        return true;
                    }
                    else
                    {
                        s = shtml_doc_text;
                        this.htmlPanel1.Text = s;
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
            lngRPM.s_btn_Tokens.Text(btn_Tokens);
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
            //PrintDialog pdlg = new PrintDialog();
            //pdlg.Document = pd;
            //DialogResult dlgRes = pdlg.ShowDialog();
            //if (dlgRes == DialogResult.OK)
            //{

                pd.PrinterSettings.PrinterName = m_Printer.PrinterName;
                config.PageSize = PageSize.A4;
                config.SetMargins(20);

                XSize orgPageSize = PageSizeConverter.ToSize(config.PageSize);
                orgPageSize = new Size(Convert.ToInt32(orgPageSize.Width), Convert.ToInt32(orgPageSize.Height));
                pageSize = new Size(Convert.ToInt32(orgPageSize.Width - config.MarginLeft - config.MarginRight), Convert.ToInt32(orgPageSize.Height - config.MarginTop - config.MarginBottom));

                hc.SetHtml(htmlPanel1.Text);
                hc.Location = new PointF(config.MarginLeft, config.MarginTop);
                hc.MaxSize = new Size(Convert.ToInt32(pageSize.Width), 0);

                string shtml = htmlPanel1.Text;

                hc.SetHtml(shtml);


                scrollOffset = 0;

                hc.UseGdiPlusTextRendering = true;
                hc.ScrollOffset = new Point(0, 0);

                //SizeF szf = new SizeF(pd.DefaultPageSettings.PaperSize.Width, pd.DefaultPageSettings.PaperSize.Height);
                //hc.MaxSize = szf;
                iPage = 0;
                bFirstPagePrinting = true;
                pd.Print();

                //hc.SetHtml(htmlPanel1.Text);
                //hc.UseGdiPlusTextRendering = true;
                //scrollOffset = 0;
                //bFirstPagePrinting = true;
                //pd.Print();

            //}
        }

        private void Pd_PrintPage(object sender, PrintPageEventArgs e)
        {

            if (bFirstPagePrinting)
            {
                bFirstPagePrinting = false;
                hc.PerformLayout(e.Graphics);
                hc.GetPages();
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
                //    hc.PerformPrint(e.Graphics, 0);
                //    e.HasMorePages = false;
                //}
                XSize e_Graphics_XSize = new XSize(Convert.ToDouble(e.PageSettings.PrintableArea.Width), Convert.ToDouble(e.PageSettings.PrintableArea.Height));
                e.Graphics.IntersectClip(new RectangleF(config.MarginLeft, config.MarginTop, pageSize.Width, pageSize.Height));
                hc.ScrollOffset = new Point(0, Convert.ToInt32(scrollOffset));
                hc.PerformPaint(e.Graphics);
                scrollOffset -= pageSize.Height;
                if (scrollOffset > -hc.ActualSize.Height)
                {
                    e.HasMorePages = true;
                }
                else
                {
                    e.HasMorePages = false;
                }
            }



            //if (bFirstPagePrinting)
            //{
            //    bFirstPagePrinting = false;
            //    hc.PerformLayout(e.Graphics);
            //}

            //e.Graphics.IntersectClip(new RectangleF(e.PageSettings.PrintableArea.Left, e.PageSettings.PrintableArea.Top, e.PageSettings.PrintableArea.Width, e.PageSettings.PrintableArea.Height));
            //hc.ScrollOffset = new Point(0, scrollOffset);
            //hc.PerformPaint(e.Graphics);
            //scrollOffset -= Convert.ToInt32(e.PageSettings.PrintableArea.Height);
            //if (scrollOffset > -hc.ActualSize.Height)
            //{
            //    e.HasMorePages = true;
            //}
            //else
            //{
            //    e.HasMorePages = false;
            //}
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
