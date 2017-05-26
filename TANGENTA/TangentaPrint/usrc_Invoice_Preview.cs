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

namespace TangentaPrint
{
    public partial class usrc_Invoice_Preview : UserControl
    {

        PrintDocument pd = new PrintDocument();
        int scrollOffset = 0;

        bool bFirstPage = false;

        TheArtOfDev.HtmlRenderer.WinForms.HtmlContainer hc = new TheArtOfDev.HtmlRenderer.WinForms.HtmlContainer();

        public delegate void delegate_OK();
        public event delegate_OK OK;

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
                        string s = m_InvoiceData.CreateHTML_Invoice(ref shtml_doc_text);
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
                    string shtml_doc_text = value;
                    string s = null;
                    if (m_InvoiceData != null)
                    {
                        s = m_InvoiceData.CreateHTML_Invoice(ref shtml_doc_text);
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

        public bool ShowPreview(string shtml_doc_text)
            {
                try
                {
                  
                     string s = null;
                    if (m_InvoiceData != null)
                    {
                        s = m_InvoiceData.CreateHTML_Invoice(ref shtml_doc_text);
                    }
                    else
                    {
                        s = shtml_doc_text;
                    }
                //this.htmlPanel1.Text = s;
                TheArtOfDev.HtmlRenderer.Core.PageLayout pglayout = null;
                this.htmlPanel1.GetPages(s, ref pglayout);
                return true;
                }
                catch (Exception ex)
                {
                    LogFile.Error.Show("ERROR:usrc_Invoice_Preview:propertiy:html_doc_text:Exception=" + ex.Message);
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
        public bool Init(byte[] xdoc, InvoiceData xInvoiceData, GlobalData.ePaymentType xpaymentType, string sPaymentMethod, string sAmountReceived, string sToReturn, DateTime_v issue_time)
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
            string s = m_InvoiceData.CreateHTML_Invoice(ref shtml_doc_text);
            this.htmlPanel1.Text = s;
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
            PrintDialog pdlg = new PrintDialog();
            pdlg.Document = pd;
            DialogResult dlgRes = pdlg.ShowDialog();
            if (dlgRes == DialogResult.OK)
            {
                hc.SetHtml(htmlPanel1.Text);
                hc.UseGdiPlusTextRendering = true;
                scrollOffset = 0;
                bFirstPage = true;
                pd.Print();

            }
            //m_webBrowser.ShowPrintDialog();
        }

        private void Pd_PrintPage(object sender, PrintPageEventArgs e)
        {

            if (bFirstPage)
            {
                bFirstPage = false;
                hc.PerformLayout(e.Graphics);
            }

            e.Graphics.IntersectClip(new RectangleF(e.PageSettings.PrintableArea.Left, e.PageSettings.PrintableArea.Top, e.PageSettings.PrintableArea.Width, e.PageSettings.PrintableArea.Height));
            hc.ScrollOffset = new Point(0, scrollOffset);
            hc.PerformPaint(e.Graphics);
            scrollOffset -= Convert.ToInt32(e.PageSettings.PrintableArea.Height);
            if (scrollOffset > -hc.ActualSize.Height)
            {
                e.HasMorePages = true;
            }
            else
            {
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

        private void btn_OK_Click(object sender, EventArgs e)
        {
            if (OK != null)
            {
                OK();
            }
        }
    }
}
